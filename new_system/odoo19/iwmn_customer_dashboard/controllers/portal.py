import base64
import re
from datetime import date
from decimal import Decimal, InvalidOperation, ROUND_HALF_UP

from odoo import fields, http
from odoo.exceptions import ValidationError
from odoo.http import content_disposition, request
from odoo.addons.sale.controllers.portal import CustomerPortal as SaleCustomerPortal
from odoo.osv import expression
from odoo.tools.mimetypes import guess_mimetype

from ..services import (
    BarWeightApiError,
    BarWeightApiService,
    CreditLimitApiError,
    CreditLimitApiService,
    DriverVehicleApiError,
    DriverVehicleApiService,
)


DELIVERY_AREAS = {
    "phu_my": "Phú Mỹ",
    "can_tho": "Cần Thơ",
    "phu_quoc": "Phú Quốc",
    "da_nang": "Đà Nẵng",
    "nha_trang": "Nha Trang",
    "di_an": "Dĩ An - Bình Dương",
}

CREDIT_DETAIL_TYPES = {
    "overdue": {"label": "Nợ quá hạn", "stt": 0, "level": None, "icon": "fa-exclamation-triangle", "debt": True},
    "not-due": {"label": "Nợ trong hạn", "stt": 1, "level": None, "icon": "fa-clock-o", "debt": True},
    "pending-approvals": {"label": "Đơn hàng chờ duyệt", "stt": 2, "level": None, "icon": "fa-hourglass-half"},
    "invoices": {"label": "Hóa đơn", "stt": 5, "level": 4, "icon": "fa-file-text-o"},
    "approved-deliveries": {"label": "Lệnh duyệt chờ giao hàng", "stt": 5, "level": 6, "icon": "fa-truck"},
    "warehouse-issues": {"label": "PXK/NMHH", "stt": 5, "level": 10, "icon": "fa-cubes"},
    "consigned-goods": {"label": "Ký gửi", "stt": 5, "level": 12, "icon": "fa-archive"},
}

DETAIL_FIELD_LABELS = {
    "content": "Nội dung",
    "amount": "Tổng tiền",
    "quantity": "Khối lượng",
    "deliveryOrderQuantity": "Khối lượng LXH",
    "paymentMethod": "Hình thức thanh toán",
    "warehouseCode": "Tên kho",
    "vehicleNumber": "Số xe",
    "bargeNumber": "Số xà lan",
    "deliveryOrderNumber": "Số LXH",
}

DETAIL_FIELD_ICONS = {
    "amount": "fa-money",
    "quantity": "fa-balance-scale",
    "deliveryOrderQuantity": "fa-balance-scale",
    "paymentMethod": "fa-credit-card",
    "warehouseCode": "fa-building-o",
    "vehicleNumber": "fa-truck",
    "bargeNumber": "fa-ship",
    "deliveryOrderNumber": "fa-file-text-o",
}


def _product_search_domain(term):
    return [
        ("ma_nh_vt", "=", "THEPCANDAI"),
        "|", ("ma_vt", "ilike", term), ("ten_vt", "ilike", term),
    ]


def _product_type_for_product(product):
    return "coil" if (product.ma_size or "").strip().upper().startswith("R") and product.num_bars == 0 else "bar"


def _product_search_item(product):
    return {
        "id": product.id,
        "code": product.ma_vt,
        "name": product.ten_vt or "",
        "product_type": _product_type_for_product(product),
        "size_code": product.ma_size or "",
        "steel_grade": product.grade_id or product.mac_thep or "",
        "length_m": product.length or 0,
        "num_bars": product.num_bars or 0,
        "uom": product.dvt or "",
        "image_url": f"/my/orders/products/{product.id}/image",
    }


def _normalize_size_term(term):
    term = (term or "").strip()
    reversed_size = re.fullmatch(r"([0-9]+)([A-Za-z])", term)
    return f"{reversed_size.group(2).upper()}{reversed_size.group(1)}" if reversed_size else term


def _quick_product_options(product_model, domain, field_name, term):
    groups = product_model.read_group(domain, [field_name], [field_name], lazy=False)
    if field_name == "length":
        values = {
            format(float(value), ".12g") for row in groups
            if isinstance(value := row.get(field_name), (int, float))
            and not isinstance(value, bool) and value >= 0
        }
    else:
        values = {row[field_name] for row in groups if row.get(field_name) not in (False, None, "")}
    if field_name == "ma_size":
        normalized_term = _normalize_size_term(term)
        if normalized_term != term:
            exact = [value for value in values if str(value).casefold() == normalized_term.casefold()]
            if exact:
                return sorted((str(value) for value in exact), key=str.casefold)
        term = normalized_term
    return sorted((str(value) for value in values if term.casefold() in str(value).casefold()), key=str.casefold)


def _quick_grade_options(product_model, grade_model, domain, term):
    available_codes = _quick_product_options(product_model, domain, "grade_id", "")
    if not available_codes:
        return []
    names = {}
    for grade in grade_model.search([("grade_id", "in", available_codes)], order="id asc"):
        names.setdefault(grade.grade_id.casefold(), grade.grade_name or "")
    search_term = term.casefold()
    return [
        {"code": code, "name": names.get(code.casefold(), "")}
        for code in available_codes
        if search_term in code.casefold() or search_term in names.get(code.casefold(), "").casefold()
    ]


def _quick_length_options(product_model, domain, term):
    lengths = {}
    for product in product_model.search(domain):
        if product.length < 0:
            continue
        value = format(float(product.length), ".12g")
        if term.casefold() not in value.casefold():
            continue
        lengths[value] = lengths.get(value, False) or product.is_default
    return sorted(lengths, key=lambda value: (not lengths[value], float(value)))


def _contract_search_domain(partner_code, report_date, term=None):
    domain = [
        ("ma_dt", "=", (partner_code or "").strip()),
        ("ngay_hd_bd", "<=", report_date),
        ("ngay_hd_kt", ">=", report_date),
    ]
    term = (term or "").strip()
    if term:
        domain += [
            "|", "|",
            ("ma_hd", "ilike", term),
            ("so_hd", "ilike", term),
            ("ten_hd", "ilike", term),
        ]
    return domain


def _contract_label(contract):
    parts = [contract.ma_hd]
    if contract.so_hd and contract.so_hd != contract.ma_hd:
        parts.append(contract.so_hd)
    if contract.ten_hd and contract.ten_hd not in parts:
        parts.append(contract.ten_hd)
    return " - ".join(filter(None, parts))


def _warehouse_search_domain(partner_code, term=None):
    partner_code = (partner_code or "").strip()
    if not partner_code:
        return [("id", "=", 0)]
    term = (term or "").strip()
    domain = [("ma_dt", "=", partner_code)]
    if term:
        domain += ["|", ("ma_kho", "ilike", term), ("ten_kho", "ilike", term)]
    return domain


def _warehouse_label(warehouse):
    return " - ".join(filter(None, [warehouse.ma_kho, warehouse.ten_kho]))


def _project_search_domain(term=None):
    term = (term or "").strip()
    return [
        "|",
        ("ma_ctrinh", "ilike", term),
        ("ten_ctrinh", "ilike", term),
    ] if term else []


def _project_label(project):
    return " - ".join(filter(None, [project.ma_ctrinh, project.ten_ctrinh]))


def _project_appendix_search_domain(project_code, term=None):
    project_code = (project_code or "").strip()
    if not project_code:
        return [("id", "=", 0)]
    term = (term or "").strip()
    domain = [("ma_ctrinh", "=", project_code)]
    if term:
        domain += [
            "|",
            ("ma_plctrinh", "ilike", term),
            ("ten_plctrinh", "ilike", term),
        ]
    return domain


def _project_appendix_label(project_appendix):
    return " - ".join(filter(None, [
        project_appendix.ma_plctrinh,
        project_appendix.ten_plctrinh,
    ]))


def _calculate_barem_weights(base_weight, standard_bundle, length_m, num_bars):
    length = Decimal(str(length_m))
    bar_weight = Decimal(str(base_weight))
    if length != Decimal("11.7"):
        bar_weight = (bar_weight / Decimal("11.7") * length).quantize(
            Decimal("0.0001"), rounding=ROUND_HALF_UP,
        )
        bundle_weight = float((bar_weight * num_bars).quantize(
            Decimal("1"), rounding=ROUND_HALF_UP,
        ))
    else:
        bundle_weight = standard_bundle
    return {
        "bar_weight_kg": float(bar_weight),
        "bundle_weight_kg": bundle_weight,
        "bars_per_bundle": num_bars,
    }


def _normalize_bar_entry(bundle_text, loose_text, bars_per_bundle):
    if bars_per_bundle <= 0:
        raise ValueError("Vật tư chưa có số cây mỗi bó.")
    bundle_text = str(bundle_text or "0").strip()
    loose_text = str(loose_text or "0").strip()
    if not re.fullmatch(r"[0-9]+", bundle_text) or not re.fullmatch(r"[0-9]+", loose_text):
        raise ValueError("Số bó và số cây lẻ phải là số nguyên không âm.")
    total_bars = int(bundle_text) * bars_per_bundle + int(loose_text)
    bundles, loose_bars = divmod(total_bars, bars_per_bundle)
    return bundles, loose_bars, total_bars


def _customer_order_domain(user_id, commercial_partner_id, erp_partner_id=None):
    domains = [
        [("portal_user_id", "=", user_id)],
        [("partner_id", "child_of", commercial_partner_id)],
    ]
    if erp_partner_id:
        domains.append([("erp_partner_id", "=", erp_partner_id)])
    return expression.OR(domains)


def _resolve_erp_partner(partner):
    """Prefer the portal contact's ERP customer, then its company mapping."""
    return (
        partner.iwmn_credit_partner_id
        or partner.commercial_partner_id.iwmn_credit_partner_id
    )


def _number(value):
    try:
        return max(0.0, float(str(value or "0").replace(" ", "").replace(",", ".")))
    except (TypeError, ValueError):
        return 0.0


def _format_identity(value):
    digits = re.sub(r"\D", "", value or "")
    if len(digits) in (9, 12):
        return ".".join(digits[index:index + 3] for index in range(0, len(digits), 3))
    return value.strip() if value else ""


def _driver_lookup_identity(value):
    """Normalize the portal's dotted identity into the legacy store format."""
    digits = re.sub(r"\D", "", value or "")
    if len(digits) not in (9, 12):
        return ""
    return "-".join(digits[index:index + 3] for index in range(0, len(digits), 3))


def _apply_order_shape_change(line_commands, order_shape, previous_shape=None, previous_line_shapes=(), confirmed=False):
    """Synchronize saved lines only when the order-level shape actually changes."""
    if order_shape == "mixed" or not previous_shape or order_shape == previous_shape:
        return None
    effective_shapes = {
        shape if shape in ("straight", "bent") else ("bent" if previous_shape == "bent" else "straight")
        for shape in previous_line_shapes
    }
    submitted_shapes = {values.get("steel_shape") for _, _, values in line_commands}
    if (len(effective_shapes) > 1 or len(submitted_shapes) > 1) and not confirmed:
        return "Chi tiết đơn đang có cả Thẳng và Bẻ cong. Vui lòng xác nhận trước khi đổi toàn bộ chi tiết."
    for _, _, values in line_commands:
        values["steel_shape"] = order_shape
    return None


def _is_refresh_requested(value):
    return str(value or "").strip().casefold() in ("1", "true", "yes")


def _is_money_column(column_name):
    normalized = re.sub(r"[^a-z0-9]", "", (column_name or "").casefold())
    return normalized.startswith((
        "tien", "thanhtien", "tongtien", "tongno", "du", "dongia",
        "giatri", "psno", "psco", "amount", "balance",
    ))


def _normalized_row(row):
    if not isinstance(row, dict):
        return {}
    return {re.sub(r"[^a-z0-9]", "", str(key).casefold()): value for key, value in row.items()}


def _row_value(row, name, default=None):
    return _normalized_row(row).get(re.sub(r"[^a-z0-9]", "", name.casefold()), default)


def _row_number(row, name):
    return _money(_row_value(row, name))


def _row_integer(row, name):
    try:
        return int(_row_value(row, name))
    except (TypeError, ValueError):
        return None


def _row_bold(row):
    value = _row_value(row, "bold")
    return value is True or str(value or "").strip().casefold() in ("1", "true", "yes")


def _dashboard_rows(payload):
    return [row for row in (payload or []) if isinstance(row, dict)] if isinstance(payload, list) else []


def _find_dashboard_row(rows, stt, *, bold=None, level=None):
    for row in _dashboard_rows(rows):
        if _row_integer(row, "sequence") != stt and _row_integer(row, "stt") != stt:
            continue
        if bold is not None and _row_bold(row) != bold:
            continue
        if level is not None and _row_integer(row, "level") != level:
            continue
        return row
    return {}


def _dashboard_amount(rows, stt, *, level=None):
    row = _find_dashboard_row(rows, stt, bold=True, level=level)
    if not row and level is not None:
        row = _find_dashboard_row(rows, stt, level=level)
    return _row_number(row, "amount") or _row_number(row, "ttien")


def _dashboard_detail_rows(rows, detail_type):
    return [
        row for row in _dashboard_rows(rows)
        if (_row_integer(row, "sequence") == detail_type["stt"] or _row_integer(row, "stt") == detail_type["stt"])
        and not _row_bold(row)
        and (detail_type.get("level") is None or _row_integer(row, "level") == detail_type["level"])
    ]


def _display_detail_value(row, key):
    aliases = {
        "content": ("content", "noi_dung"),
        "amount": ("amount", "ttien"),
        "quantity": ("quantity", "so_luong"),
        "deliveryOrderQuantity": ("deliveryOrderQuantity", "so_luong_lxh"),
        "paymentMethod": ("paymentMethod", "ht_tt"),
        "warehouseCode": ("warehouseCode", "ma_kho"),
        "vehicleNumber": ("vehicleNumber", "so_xe"),
        "bargeNumber": ("bargeNumber", "so_xa_lan_tau"),
        "deliveryOrderNumber": ("deliveryOrderNumber", "so_lxh"),
    }
    for alias in aliases[key]:
        value = _row_value(row, alias)
        if value not in (None, "", "NULL"):
            return value
    return None


def _prepare_credit_detail_table(rows, detail_type, warehouse_names=None):
    warehouse_names = warehouse_names or {}
    debt_fields = ("amount", "quantity", "deliveryOrderQuantity", "warehouseCode", "vehicleNumber", "bargeNumber")
    order_fields = ("amount", "quantity", "warehouseCode", "vehicleNumber", "bargeNumber")
    field_keys = debt_fields if detail_type.get("debt") else order_fields
    items = []
    for source_row in _dashboard_detail_rows(rows, detail_type):
        cells = []
        for key in field_keys:
            value = _display_detail_value(source_row, key)
            if key == "warehouseCode" and value not in (None, "", "NULL"):
                value = warehouse_names.get(str(value).strip().casefold(), value)
            is_number = isinstance(value, (int, float)) and not isinstance(value, bool)
            cells.append({
                "key": key,
                "label": DETAIL_FIELD_LABELS[key],
                "icon": DETAIL_FIELD_ICONS.get(key),
                "value": float(value) if is_number else value,
                "is_money": key == "amount" and is_number,
                "is_number": key in ("quantity", "deliveryOrderQuantity") and is_number,
                "visible": value not in (None, "", "NULL"),
            })
        items.append({
            "title": _display_detail_value(source_row, "content") or _display_detail_value(source_row, "deliveryOrderNumber") or "Khoản chi tiết",
            "reference": _display_detail_value(source_row, "deliveryOrderNumber"),
            "cells": cells,
        })
    return {"rows": items}


def _credit_detail_total(rows, detail_key):
    dashboard = _prepare_dashboard(rows)
    metrics = (
        dashboard["debt"].get("detail_metrics", [])
        + [dashboard["approval_payment"]]
        + dashboard["limits"].get("detail_metrics", [])
    )
    for item in metrics:
        if item["key"] == detail_key:
            return float(item["value"])
    return 0.0


def _money(value):
    try:
        return Decimal(str(value or 0))
    except (InvalidOperation, TypeError, ValueError):
        return Decimal("0")


def _percentage(value, total):
    if total <= 0:
        return Decimal("0")
    return min(Decimal("100"), max(Decimal("0"), value * Decimal("100") / total))


def _select_customer_summary(rows, partner_code):
    rows = _dashboard_rows(rows)
    if not rows:
        return []
    normalized_code = partner_code.strip().casefold()
    matching = [
        row for row in rows
        if str(_row_value(row, "partnerCode") or "").strip().casefold() == normalized_code
    ]
    return matching or rows


def _api_date(value):
    if not value:
        return None
    try:
        parsed = fields.Date.to_date(str(value)[:10])
    except (TypeError, ValueError):
        return None
    return parsed if parsed and parsed.year > 1900 else None


def _prepare_dashboard(report_rows, report_date=None):
    rows = _dashboard_rows(report_rows)
    report_date = _api_date(report_date) or date.today()

    overdue = abs(_dashboard_amount(rows, 0))
    not_due = abs(_dashboard_amount(rows, 1))
    pending_approvals = abs(_dashboard_amount(rows, 2))
    total_debt = overdue + not_due

    guarantee = abs(_dashboard_amount(rows, 4, level=2))
    unsecured = abs(_dashboard_amount(rows, 4, level=3))
    cash = abs(_dashboard_amount(rows, 5, level=1))
    contractual_limit = abs(_dashboard_amount(rows, 4)) or guarantee + unsecured
    invoices = abs(_dashboard_amount(rows, 5, level=3))
    approved_deliveries = abs(_dashboard_amount(rows, 5, level=5))
    warehouse_issues = abs(_dashboard_amount(rows, 5, level=9))
    consigned_goods = abs(_dashboard_amount(rows, 5, level=11))

    available_sources = guarantee + unsecured + cash
    used = invoices + approved_deliveries + warehouse_issues + consigned_goods
    remaining = available_sources - used
    used_percent = _percentage(used, available_sources)

    source_segments = [
        {"key": "guarantee", "label": "Bảo lãnh", "value": float(guarantee), "color": "#4f8f79"},
        {"key": "unsecured", "label": "Tín chấp", "value": float(unsecured), "color": "#8ab7a7"},
        {"key": "cash", "label": "Tiền thanh toán", "value": float(cash), "color": "#f5a35b"},
    ]
    chart_values = [
        ("invoices", "Hóa đơn", invoices, "#ac76a4"),
        ("approved-deliveries", "Lệnh duyệt chờ giao", approved_deliveries, "#de8871"),
        ("warehouse-issues", "PXK/NMHH", warehouse_issues, "#ebb85f"),
        ("consigned-goods", "Ký gửi", consigned_goods, "#8fb9a9"),
        ("remaining", "Khả năng mua hàng", max(Decimal("0"), remaining), "#4f8f79"),
    ]
    chart_total = max(available_sources, used, Decimal("1"))
    segments = []
    cursor = Decimal("0")
    for key, label, value, color in chart_values:
        percent = value * Decimal("100") / chart_total
        start, cursor = cursor, cursor + percent
        segments.append({
            "key": key,
            "label": label,
            "value": float(value),
            "percent": float(percent),
            "start": float(start),
            "end": float(min(Decimal("100"), cursor)),
            "color": color,
        })
    gradient = ", ".join(
        f"{segment['color']} {segment['start']:.2f}% {segment['end']:.2f}%"
        for segment in segments if segment["percent"] > 0 and segment["start"] < 100
    ) or "#dfe7e3 0% 100%"

    overdue_days = 0
    for row in _dashboard_detail_rows(rows, CREDIT_DETAIL_TYPES["overdue"]):
        document_date = _api_date(_row_value(row, "documentDate") or _row_value(row, "ngay_ct"))
        if document_date:
            overdue_days = max(overdue_days, max(0, (report_date - document_date).days))

    detail_metrics = [
        {
            "key": "invoices",
            "label": "Hóa đơn",
            "value": float(invoices),
            "api_field": "Stt=5,Level=3",
            "icon": "fa-file-text-o",
        },
        {
            "key": "approved-deliveries",
            "label": "Lệnh duyệt chờ giao hàng",
            "value": float(approved_deliveries),
            "api_field": "Stt=5,Level=5",
            "icon": "fa-truck",
        },
        {
            "key": "warehouse-issues",
            "label": "PXK/NMHH",
            "value": float(warehouse_issues),
            "api_field": "Stt=5,Level=9",
            "icon": "fa-cubes",
        },
        {
            "key": "consigned-goods",
            "label": "Ký gửi",
            "value": float(consigned_goods),
            "api_field": "Stt=5,Level=11",
            "icon": "fa-archive",
        },
    ]
    return {
        "debt": {
            "not_due": float(not_due),
            "overdue": float(overdue),
            "total": float(total_debt),
            "overdue_days": overdue_days,
            "overdue_days_display": overdue_days,
            "detail_metrics": [
                {"key": "not-due", "label": "Nợ trong hạn", "value": float(not_due), "icon": "fa-clock-o"},
                {"key": "overdue", "label": "Nợ quá hạn", "value": float(overdue), "icon": "fa-exclamation"},
            ],
        },
        "approval_payment": {
            "key": "pending-approvals",
            "label": "Tiền cần thanh toán để duyệt hàng",
            "value": float(pending_approvals),
            "icon": "fa-hourglass-half",
        },
        "limits": {
            "segments": segments,
            "source_segments": source_segments,
            "structure_total": float(available_sources),
            "contractual_total": float(contractual_limit),
            "cash": float(cash),
            "remaining": float(remaining),
            "used": float(used),
            "used_percent": float(used_percent),
            "is_exceeded": remaining < 0,
            "gradient": gradient,
            "detail_metrics": detail_metrics,
        },
    }


class IwmnCustomerPortal(SaleCustomerPortal):
    def _order_partner(self):
        return request.env.user.partner_id.commercial_partner_id.sudo()

    def _erp_partner(self):
        return _resolve_erp_partner(request.env.user.partner_id.sudo())

    def _portal_order_domain(self):
        """Return every order belonging to the current customer's portal scope.

        Older/imported orders may point to a child contact instead of the
        commercial partner. Orders created by the same portal account or linked
        to the same ERP customer must remain visible as well.
        """
        partner = self._order_partner()
        erp_partner = self._erp_partner()
        return _customer_order_domain(request.env.user.id, partner.id, erp_partner.id)

    def _find_portal_order(self, order_id, extra_domain=None):
        domain = expression.AND([
            self._portal_order_domain(),
            [("id", "=", order_id)] + (extra_domain or []),
        ])
        return request.env["iwmn.customer.order"].sudo().search(domain, limit=1)

    def _active_contracts(self, term=None, limit=10):
        erp_partner = self._erp_partner()
        if not erp_partner or not erp_partner.ma_dt:
            return request.env["iwmn.r81dmhd"]
        report_date = fields.Date.context_today(request.env.user)
        return request.env["iwmn.r81dmhd"].sudo().search(
            _contract_search_domain(erp_partner.ma_dt, report_date, term),
            order="ngay_hd_bd asc, id asc",
            limit=limit,
        )

    @staticmethod
    def _contract_item(contract):
        return {
            "id": contract.id,
            "code": contract.ma_hd or "",
            "number": contract.so_hd or "",
            "name": contract.ten_hd or "",
            "label": _contract_label(contract),
            "start_date": fields.Date.to_string(contract.ngay_hd_bd),
            "end_date": fields.Date.to_string(contract.ngay_hd_kt),
        }

    def _warehouses(self, term=None, limit=10):
        erp_partner = self._erp_partner()
        return request.env["iwmn.r81dmkho"].sudo().search(
            _warehouse_search_domain(erp_partner.ma_dt if erp_partner else "", term),
            order="ma_kho asc, id asc", limit=limit,
        )

    @staticmethod
    def _warehouse_item(warehouse):
        return {
            "id": warehouse.id,
            "code": warehouse.ma_kho or "",
            "name": warehouse.ten_kho or "",
            "label": _warehouse_label(warehouse),
        }

    def _projects(self, term=None, limit=10):
        return request.env["iwmn.r81dmctrinh"].sudo().search(
            _project_search_domain(term),
            order="ma_ctrinh asc, id asc",
            limit=limit,
        )

    @staticmethod
    def _project_item(project):
        return {
            "id": project.id,
            "code": project.ma_ctrinh or "",
            "name": project.ten_ctrinh or "",
            "label": _project_label(project),
        }

    def _project_appendices(self, project_code, term=None, limit=10):
        return request.env["iwmn.r81dmplctrinh"].sudo().search(
            _project_appendix_search_domain(project_code, term),
            order="ma_plctrinh asc, id asc",
            limit=limit,
        )

    @staticmethod
    def _project_appendix_item(project_appendix):
        return {
            "id": project_appendix.id,
            "appendix_code": project_appendix.ma_plctrinh or "",
            "project_code": project_appendix.ma_ctrinh or "",
            "name": project_appendix.ten_plctrinh or "",
            "label": _project_appendix_label(project_appendix),
        }

    def _empty_order_form(self):
        partner = self._order_partner()
        return {
            "customer_reference": "",
            "order_date": fields.Date.context_today(request.env.user),
            "requested_delivery_date": "",
            "project_name": "",
            "project_code": "",
            "subproject_name": "",
            "subproject_code": "",
            "project_id": "",
            "project_query": "",
            "project_appendix_id": "",
            "project_appendix_query": "",
            "so_luong_cnxx": 0,
            "contract_number": "",
            "contract_id": "",
            "contract_query": "",
            "warehouse_id": "",
            "ma_kho": "",
            "warehouse_query": "",
            "delivery_type": "HD",
            "payment_method": "tra_cham_40",
            "delivery_area": "phu_my",
            "transport_method": "xe",
            "steel_shape": "straight",
            "cnxx_show_project": False,
            "other_requirements": "",
            "customer_name": partner.name,
        }

    def _extract_order_rows(self):
        form = request.httprequest.form
        line_fields = {
            "product_id": form.getlist("line_product_id"),
            "product_query": form.getlist("line_product_query"),
            "product_type": form.getlist("line_product_type"),
            "size_code": form.getlist("line_size_code"),
            "steel_grade": form.getlist("line_steel_grade"),
            "length_m": form.getlist("line_length_m"),
            "total_bar_qty": form.getlist("line_total_bar_qty"),
            "order_bundle_qty": form.getlist("line_order_bundle_qty"),
            "order_loose_bar_qty": form.getlist("line_order_loose_bar_qty"),
            "requested_weight_kg": form.getlist("line_requested_weight_kg"),
            "coil_cut_qty": form.getlist("line_coil_cut_qty"),
            "customer_unit_price": form.getlist("line_customer_unit_price"),
            "steel_shape": form.getlist("line_steel_shape"),
            "note": form.getlist("line_note"),
        }
        line_count = max((len(values) for values in line_fields.values()), default=0)
        lines = [
            {key: (values[index] if index < len(values) else "") for key, values in line_fields.items()}
            for index in range(line_count)
        ]
        vehicle = {
            "license_plate": form.get("vehicle_license_plate", ""),
            "barge_number": form.get("vehicle_barge_number", ""),
            "driver_name": form.get("vehicle_driver_name", ""),
            "driver_identity": form.get("vehicle_driver_identity", ""),
            "driver_phone": form.get("vehicle_driver_phone", ""),
        }
        return lines, vehicle

    def _barem_values(self, product):
        empty = {"bar_weight_kg": 0.0, "bundle_weight_kg": 0.0,
                 "bars_per_bundle": product.num_bars if product else 0}
        if not product or not product.ma_size or not product.grade_id or not product.length or not product.num_bars:
            return empty
        barems = request.env["iwmn.r81dmbarems"].sudo().search([
            ("ma_size", "=ilike", product.ma_size),
            ("grade_id", "=ilike", product.grade_id),
        ])
        if not barems:
            return empty
        base_weight = min(barems.mapped("barem_kg"))
        standard_bundle = min(barems.mapped("barem_tc_tb"))
        return _calculate_barem_weights(base_weight, standard_bundle, product.length, product.num_bars)

    def _prepare_order_commands(self, lines):
        errors = []
        line_commands = []
        for index, line in enumerate(lines, start=1):
            product_query = (line.get("product_query") or "").strip()
            if not product_query and not any(str(value or "").strip() for value in line.values()):
                continue
            product_id = int(line.get("product_id")) if str(line.get("product_id") or "").isdigit() else 0
            product = request.env["iwmn.r81dmvt"].sudo().search(
                [("id", "=", product_id), ("ma_nh_vt", "=", "THEPCANDAI")], limit=1
            )
            if not product:
                errors.append(f"Dòng hàng {index}: vui lòng chọn một sản phẩm trong danh sách gợi ý.")
            if product:
                product_query = f"{product.ma_vt} - {product.ten_vt or ''}".strip(" -")
            product_type = _product_type_for_product(product) if product else "bar"
            line["product_type"] = product_type
            total_bar_qty = 0
            requested_weight = _number(line.get("requested_weight_kg"))
            coil_cut_qty = int(_number(line.get("coil_cut_qty")))
            size_code = (product.ma_size or "").strip() if product else (line.get("size_code") or "").strip()
            steel_grade = ((product.grade_id or product.mac_thep or "").strip() if product else (line.get("steel_grade") or "").strip())
            length_m = product.length if product else _number(line.get("length_m"))
            barem = self._barem_values(product) if product_type == "bar" else {}
            if product_type == "bar" and barem.get("bars_per_bundle", 0) > 0:
                try:
                    ordered_bundles, ordered_loose, total_bar_qty = _normalize_bar_entry(
                        line.get("order_bundle_qty"), line.get("order_loose_bar_qty"), barem["bars_per_bundle"],
                    )
                except ValueError as exception:
                    errors.append(f"Dòng hàng {index}: {exception}")
                else:
                    line["order_bundle_qty"] = str(ordered_bundles)
                    line["order_loose_bar_qty"] = str(ordered_loose)
            if not product_query:
                errors.append(f"Dòng hàng {index}: vui lòng nhập mã hoặc tên sản phẩm.")
            if product_type == "bar" and total_bar_qty <= 0:
                errors.append(f"Dòng hàng {index}: tổng số cây phải lớn hơn 0.")
            if product_type == "bar" and barem.get("bars_per_bundle", 0) <= 0:
                errors.append(f"Dòng hàng {index}: vật tư chưa có số cây mỗi bó để quy đổi.")
            if product_type == "coil" and requested_weight <= 0:
                errors.append(f"Dòng hàng {index}: khối lượng thép cuộn phải lớn hơn 0 kg.")
            if product_type == "coil" and coil_cut_qty <= 0:
                errors.append(f"Dòng hàng {index}: số cuộn cần cắt phải lớn hơn 0.")
            line_commands.append((0, 0, {
                "sequence": index * 10,
                "product_id": product.id,
                "product_query": product_query,
                "product_type": product_type,
                "size_code": size_code,
                "steel_grade": steel_grade,
                "length_m": length_m,
                "total_bar_qty": total_bar_qty,
                "bar_input_mode": "bundles",
                "requested_weight_kg": requested_weight,
                "coil_cut_qty": coil_cut_qty if product_type == "coil" else 0,
                "bar_weight_kg": barem.get("bar_weight_kg", 0),
                "bundle_weight_kg": barem.get("bundle_weight_kg", 0),
                "bars_per_bundle": barem.get("bars_per_bundle", 0),
                "customer_unit_price": _number(line.get("customer_unit_price")),
                "steel_shape": line.get("steel_shape") if line.get("steel_shape") in ("straight", "bent") else "straight",
                "note": (line.get("note") or "").strip(),
            }))
        if not line_commands:
            errors.append("Vui lòng thêm ít nhất một sản phẩm.")

        return line_commands, errors

    def _prepare_order_form_values(self, form=None, lines=None, vehicle=None, errors=None, order=None):
        form = form or self._empty_order_form()
        contracts = self._active_contracts()
        if not form.get("contract_number") and contracts:
            first_contract = contracts[0]
            form["contract_id"] = first_contract.id
            form["contract_number"] = first_contract.ma_hd or ""
            form["contract_query"] = _contract_label(first_contract)
        elif form.get("contract_number") and not form.get("contract_query"):
            selected_contract = contracts.filtered(
                lambda contract: contract.ma_hd == form.get("contract_number")
            )[:1]
            form["contract_id"] = selected_contract.id if selected_contract else ""
            form["contract_query"] = (
                _contract_label(selected_contract) if selected_contract else form.get("contract_number")
            )
        values = self._prepare_portal_layout_values()
        values.update({
            "page_name": "customer_order_new",
            "form": form,
            "lines": lines or [{"product_type": "bar", "steel_shape": "bent" if form.get("steel_shape") == "bent" else "straight"}],
            "vehicle": vehicle if vehicle is not None else {
                "driver_name": request.env.user.partner_id.name or "",
                "driver_identity": "",
                "driver_phone": "",
            },
            "form_errors": errors or [],
            "delivery_areas": DELIVERY_AREAS,
            "editing_order": order,
        })
        erp_partner = self._erp_partner()
        values["erp_partner"] = erp_partner
        values["contracts"] = contracts
        return values

    def _order_edit_values(self, order):
        selected_project = order.r81dmctrinh_id
        if not selected_project and order.project_code:
            selected_project = request.env["iwmn.r81dmctrinh"].sudo().search(
                [("ma_ctrinh", "=", order.project_code)], limit=1,
            )
        form = {
            "customer_reference": order.customer_reference,
            "order_date": order.order_date,
            "requested_delivery_date": order.requested_delivery_date or "",
            "project_name": order.project_name or "",
            "project_code": order.project_code or "",
            "subproject_name": order.subproject_name or "",
            "subproject_code": order.subproject_code or "",
            "project_id": selected_project.id or "",
            "project_query": _project_label(selected_project) if selected_project else (order.project_name or ""),
            "project_appendix_id": order.r81dmplctrinh_id.id or "",
            "project_appendix_query": (
                _project_appendix_label(order.r81dmplctrinh_id)
                if order.r81dmplctrinh_id else ""
            ),
            "so_luong_cnxx": order.so_luong_cnxx,
            "contract_number": order.contract_number or "",
            "contract_id": order.r81dmhd_id.id or "",
            "contract_query": _contract_label(order.r81dmhd_id) if order.r81dmhd_id else (order.contract_number or ""),
            "warehouse_id": order.r81dmkho_id.id or "",
            "ma_kho": order.ma_kho or "",
            "warehouse_query": _warehouse_label(order.r81dmkho_id) if order.r81dmkho_id else (order.ma_kho or ""),
            "delivery_type": order.delivery_type,
            "payment_method": order.payment_method,
            "delivery_area": order.delivery_area,
            "transport_method": order.transport_method,
            "steel_shape": order.steel_shape,
            "cnxx_show_project": order.cnxx_show_project,
            "other_requirements": order.other_requirements or "",
        }
        lines = [{
            "product_id": line.product_id.id or "",
            "product_query": line.product_query,
            "product_type": _product_type_for_product(line.product_id) if line.product_id else line.product_type,
            "size_code": line.size_code or "",
            "steel_grade": line.steel_grade or "",
            "length_m": line.length_m or "",
            "total_bar_qty": line.total_bar_qty or "",
            "bars_per_bundle": line.product_id.num_bars or line.bars_per_bundle or 0,
            "order_bundle_qty": line.bundle_qty or "",
            "order_loose_bar_qty": line.loose_bar_qty or "",
            "requested_weight_kg": line.requested_weight_kg or "",
            "coil_cut_qty": line.coil_cut_qty or "",
            "customer_unit_price": line.customer_unit_price or "",
            "steel_shape": line.steel_shape if line.steel_shape in ("straight", "bent") else ("bent" if order.steel_shape == "bent" else "straight"),
            "note": line.note or "",
        } for line in order.line_ids]
        legacy_vehicle = order.vehicle_ids[:1]
        vehicle = {
            "license_plate": order.vehicle_license_plate or (legacy_vehicle.license_plate if legacy_vehicle else ""),
            "barge_number": order.vehicle_barge_number or (legacy_vehicle.barge_number if legacy_vehicle else ""),
            "driver_name": order.vehicle_driver_name or (legacy_vehicle.driver_name if legacy_vehicle else ""),
            "driver_identity": order.vehicle_driver_identity or (legacy_vehicle.driver_identity if legacy_vehicle else ""),
            "driver_phone": order.vehicle_driver_phone or (legacy_vehicle.driver_phone if legacy_vehicle else ""),
        }
        return form, lines or [{"product_type": "bar", "steel_shape": "bent" if order.steel_shape == "bent" else "straight"}], vehicle

    @http.route(["/my", "/my/home"], type="http", auth="user", website=True)
    def home(self, **kwargs):
        values = self._prepare_portal_layout_values()
        commercial_partner = request.env.user.partner_id.commercial_partner_id.sudo()
        erp_partner = self._erp_partner()
        report_date = fields.Date.context_today(request.env.user)
        values.update({
            "page_name": "dashboard",
            "customer_name": erp_partner.ten_dt if erp_partner else commercial_partner.name,
            "report_date": report_date,
            "dashboard": _prepare_dashboard(None),
            "has_credit_data": False,
            "dashboard_error": None,
            "dashboard_cache_used": False,
            "dashboard_fetched_at": None,
        })

        if not erp_partner:
            values["dashboard_error"] = "Tài khoản chưa được gắn mã khách hàng ERP."
        else:
            cache_model = request.env["iwmn.customer.credit.dashboard.cache"].sudo()
            dashboard_cache = cache_model.get_for(erp_partner, report_date)
            force_refresh = _is_refresh_requested(kwargs.get("refresh"))
            cached_rows = dashboard_cache.summary_json if (
                dashboard_cache and isinstance(dashboard_cache.summary_json, list)
            ) else None
            summary = cached_rows if not force_refresh else None

            if summary:
                values["dashboard_cache_used"] = True
                values["dashboard_fetched_at"] = dashboard_cache.fetched_at
            else:
                try:
                    rows = CreditLimitApiService(request.env).get_summary(
                        erp_partner.ma_dt, report_date
                    )
                    summary = _select_customer_summary(rows, erp_partner.ma_dt)
                    if summary:
                        dashboard_cache = cache_model.store_summary(
                            erp_partner, report_date, summary
                        )
                        if force_refresh:
                            return request.redirect("/my")
                        values["dashboard_fetched_at"] = dashboard_cache.fetched_at
                    elif cached_rows:
                        summary = cached_rows
                        values["dashboard_cache_used"] = True
                        values["dashboard_fetched_at"] = dashboard_cache.fetched_at
                        values["dashboard_error"] = (
                            "Không có dữ liệu mới; đang hiển thị dữ liệu đã lưu gần nhất."
                        )
                    else:
                        values["dashboard_error"] = "Chưa có dữ liệu hạn mức tại ngày báo cáo."
                except CreditLimitApiError as exception:
                    if cached_rows:
                        summary = cached_rows
                        values["dashboard_cache_used"] = True
                        values["dashboard_fetched_at"] = dashboard_cache.fetched_at
                        values["dashboard_error"] = (
                            f"{exception} Đang hiển thị dữ liệu đã lưu gần nhất."
                        )
                    else:
                        values["dashboard_error"] = str(exception)

            if summary:
                values["dashboard"] = _prepare_dashboard(summary, report_date)
                values["has_credit_data"] = True

        return request.render("iwmn_customer_dashboard.portal_credit_dashboard", values)

    @http.route(
        "/my/credit-limit-details/<string:detail_key>",
        type="http", auth="user", website=True, methods=["GET"],
    )
    def portal_credit_limit_details(self, detail_key, **kwargs):
        detail_type = CREDIT_DETAIL_TYPES.get(detail_key)
        if not detail_type:
            return request.not_found()

        values = self._prepare_portal_layout_values()
        erp_partner = self._erp_partner()
        report_date = fields.Date.context_today(request.env.user)
        values.update({
            "page_name": "credit_limit_details",
            "detail_type": detail_type,
            "report_date": report_date,
            "erp_partner": erp_partner,
            "detail_table": {"rows": []},
            "detail_total": 0.0,
            "detail_count": 0,
            "detail_error": None,
        })
        if not erp_partner:
            values["detail_error"] = "Tài khoản chưa được gắn mã khách hàng ERP."
        else:
            try:
                api_service = CreditLimitApiService(request.env)
                cache_model = request.env["iwmn.customer.credit.dashboard.cache"].sudo()
                dashboard_cache = cache_model.get_for(erp_partner, report_date)
                summary = dashboard_cache.summary_json if (
                    dashboard_cache and isinstance(dashboard_cache.summary_json, list)
                ) else None
                if not summary:
                    summary_rows = api_service.get_summary(erp_partner.ma_dt, report_date)
                    summary = _select_customer_summary(summary_rows, erp_partner.ma_dt)
                    if summary:
                        cache_model.store_summary(erp_partner, report_date, summary)
                values["detail_total"] = _credit_detail_total(summary, detail_key)
                detail_rows = _dashboard_detail_rows(summary, detail_type)
                warehouse_codes = {
                    str(code).strip()
                    for code in (_display_detail_value(row, "warehouseCode") for row in detail_rows)
                    if code not in (None, "", "NULL")
                }
                warehouse_names = {}
                if warehouse_codes:
                    warehouses = request.env["iwmn.r81dmkho"].sudo().search([
                        ("ma_kho", "in", sorted(warehouse_codes)),
                    ])
                    warehouse_names = {
                        (warehouse.ma_kho or "").strip().casefold(): warehouse.ten_kho or warehouse.ma_kho
                        for warehouse in warehouses
                        if warehouse.ma_kho
                    }
                values["detail_table"] = _prepare_credit_detail_table(
                    summary, detail_type, warehouse_names,
                )
                values["detail_count"] = len(values["detail_table"]["rows"])
            except CreditLimitApiError as exception:
                values["detail_error"] = str(exception)

        return request.render(
            "iwmn_customer_dashboard.portal_credit_limit_details", values
        )

    @http.route(["/my/orders", "/my/orders/page/<int:page>"], type="http", auth="user", website=True)
    def portal_my_orders(self, page=1, **kwargs):
        orders = request.env["iwmn.customer.order"].sudo().search(
            self._portal_order_domain(), order="create_date desc, id desc", limit=100
        )
        values = self._prepare_portal_layout_values()
        values.update({"page_name": "customer_orders", "orders": orders})
        return request.render("iwmn_customer_dashboard.portal_customer_orders", values)

    @http.route("/my/orders/barem", type="http", auth="user", methods=["GET"])
    def portal_order_barem(self, product_id=None, **kwargs):
        product = request.env["iwmn.r81dmvt"].sudo().search([
            ("id", "=", int(product_id) if str(product_id or "").isdigit() else 0),
            ("ma_nh_vt", "=", "THEPCANDAI"),
        ], limit=1)
        return request.make_json_response(self._barem_values(product))

    @http.route("/my/orders/weight", type="http", auth="user", methods=["GET"])
    def portal_order_weight(self, product_id=None, total_bar_qty=None, **kwargs):
        product = request.env["iwmn.r81dmvt"].sudo().search([
            ("id", "=", int(product_id) if str(product_id or "").isdigit() else 0),
            ("ma_nh_vt", "=", "THEPCANDAI"),
        ], limit=1)
        total = int(total_bar_qty) if str(total_bar_qty or "").isdigit() else 0
        if not product or _product_type_for_product(product) != "bar" or product.num_bars <= 0 or total <= 0:
            return request.make_json_response({"error": "Vật tư hoặc số cây không hợp lệ."}, status=400)
        bundles, loose_bars = divmod(total, product.num_bars)
        try:
            weight = BarWeightApiService(request.env).calculate(product.ma_vt, bundles, loose_bars)
        except BarWeightApiError as exception:
            return request.make_json_response({"error": str(exception)}, status=503)
        rounded = int(weight.quantize(Decimal("1"), rounding=ROUND_HALF_UP))
        return request.make_json_response({
            "weight_kg": rounded,
            "bundle_qty": bundles,
            "loose_bar_qty": loose_bars,
            "bars_per_bundle": product.num_bars,
        })

    @http.route("/my/orders/products", type="http", auth="user", methods=["GET"])
    def portal_order_products(self, q=None, **kwargs):
        term = (q or "").strip()[:100]
        if not term:
            return request.make_json_response({"items": []})
        products = request.env["iwmn.r81dmvt"].sudo().search(
            _product_search_domain(term),
            order="ma_vt asc, id asc",
            limit=10,
        )
        return request.make_json_response({"items": [_product_search_item(product) for product in products]})

    @http.route("/my/orders/products/quick", type="http", auth="user", methods=["GET"])
    def portal_order_products_quick(self, stage=None, size=None, grade=None, q=None, **kwargs):
        stage = (stage or "").strip()
        size = _normalize_size_term((size or "")[:100])
        grade = (grade or "").strip()[:20]
        term = (q or "").strip()[:100]
        if stage not in ("size", "grade", "length") or (stage != "size" and not size):
            return request.make_json_response({"options": []}, status=400)
        product_model = request.env["iwmn.r81dmvt"].sudo()
        domain = [("ma_nh_vt", "=", "THEPCANDAI")]
        if stage == "size":
            field_name = "ma_size"
        else:
            domain.append(("ma_size", "=ilike", size))
            if stage == "grade":
                field_name = "grade_id"
            else:
                if not grade:
                    return request.make_json_response({"options": []}, status=400)
                domain.append(("grade_id", "=ilike", grade))
                field_name = "length"
        if stage == "grade":
            options = _quick_grade_options(
                product_model, request.env["iwmn.r81dmmacthep"].sudo(), domain, term,
            )
        elif stage == "length":
            options = _quick_length_options(product_model, domain, term)
        else:
            options = _quick_product_options(product_model, domain, field_name, term)
        result = {"options": options if stage == "size" else options[:10], "unique": len(options) == 1}
        selected_option = (options[0] if len(options) == 1 else next(
            (option for option in options if option.casefold() == term.casefold()), None
        )) if stage == "length" else None
        if selected_option:
            selected_length = float(selected_option)
            matches = product_model.search(domain + [("length", "=", selected_length)], order="ma_vt asc, id asc", limit=11)
            result["products"] = [_product_search_item(product) for product in matches[:10]]
            result["unique_product"] = _product_search_item(matches[0]) if len(matches) == 1 else None
        return request.make_json_response(result)

    @http.route("/my/orders/contracts", type="http", auth="user", methods=["GET"])
    def portal_order_contracts(self, q=None, **kwargs):
        term = (q or "").strip()[:100]
        contracts = self._active_contracts(term)
        return request.make_json_response({
            "items": [self._contract_item(contract) for contract in contracts],
        })

    @http.route("/my/orders/warehouses", type="http", auth="user", methods=["GET"])
    def portal_order_warehouses(self, q=None, **kwargs):
        warehouses = self._warehouses((q or "").strip()[:100])
        return request.make_json_response({
            "items": [self._warehouse_item(warehouse) for warehouse in warehouses],
        })

    @http.route("/my/orders/driver-vehicle", type="http", auth="user", methods=["GET"])
    def portal_order_driver_vehicle(self, identity=None, document_date=None, **kwargs):
        normalized_identity = _driver_lookup_identity(identity)
        if not normalized_identity:
            return request.make_json_response(
                {"error": "CCCD/CMT phải gồm 9 hoặc 12 chữ số."}, status=400,
            )
        try:
            lookup_date = fields.Date.to_date(document_date) if document_date else fields.Date.context_today(request.env.user)
        except (TypeError, ValueError):
            return request.make_json_response({"error": "Ngày đơn hàng không hợp lệ."}, status=400)
        try:
            result = DriverVehicleApiService(request.env).find(
                normalized_identity, fields.Date.to_string(lookup_date),
            )
        except DriverVehicleApiError as exception:
            return request.make_json_response({"error": str(exception)}, status=502)
        if not result:
            return request.make_json_response({"found": False})
        return request.make_json_response({"found": True, **result})

    @http.route("/my/orders/projects", type="http", auth="user", methods=["GET"])
    def portal_order_projects(self, q=None, **kwargs):
        projects = self._projects((q or "").strip()[:100])
        return request.make_json_response({
            "items": [self._project_item(item) for item in projects],
        })

    @http.route("/my/orders/project-appendices", type="http", auth="user", methods=["GET"])
    def portal_order_project_appendices(self, project_id=None, q=None, **kwargs):
        selected_project = request.env["iwmn.r81dmctrinh"]
        if str(project_id or "").isdigit():
            selected_project = request.env["iwmn.r81dmctrinh"].sudo().search(
                [("id", "=", int(project_id))], limit=1,
            )
        project_appendices = self._project_appendices(
            selected_project.ma_ctrinh if selected_project else "",
            (q or "").strip()[:100],
        )
        return request.make_json_response({
            "items": [self._project_appendix_item(item) for item in project_appendices],
        })

    @http.route("/my/orders/products/<int:product_id>/image", type="http", auth="user", methods=["GET"])
    def portal_order_product_image(self, product_id, **kwargs):
        product = request.env["iwmn.r81dmvt"].sudo().search(
            [("id", "=", product_id), ("ma_nh_vt", "=", "THEPCANDAI")], limit=1
        )
        if not product:
            return request.not_found()
        if not product.portal_image:
            fallback = "steel-coil.svg" if _product_type_for_product(product) == "coil" else "steel-bars.svg"
            return request.redirect(f"/iwmn_customer_dashboard/static/src/img/{fallback}")
        image = base64.b64decode(product.portal_image)
        return request.make_response(
            image,
            headers=[("Content-Type", guess_mimetype(image)), ("Cache-Control", "private, max-age=3600")],
        )

    @http.route("/my/orders/new", type="http", auth="user", website=True, methods=["GET", "POST"])
    def portal_order_new(self, **post):
        if request.httprequest.method == "GET":
            return request.render(
                "iwmn_customer_dashboard.portal_customer_order_form",
                self._prepare_order_form_values(),
            )

        form = self._empty_order_form()
        form.update(post)
        form["cnxx_show_project"] = bool(post.get("cnxx_show_project"))
        lines, vehicle = self._extract_order_rows()
        line_commands, errors = self._prepare_order_commands(lines)
        partner = self._order_partner()
        erp_partner = self._erp_partner()
        editing_order = request.env["iwmn.customer.order"]
        if post.get("order_id"):
            editing_order = self._find_portal_order(
                int(post["order_id"]) if str(post["order_id"]).isdigit() else 0,
                [("state", "=", "draft")],
            )
            if not editing_order:
                return request.not_found()

        order_shape = post.get("steel_shape") if post.get("steel_shape") in ("straight", "bent", "mixed") else "straight"
        if editing_order:
            shape_error = _apply_order_shape_change(
                line_commands,
                order_shape,
                previous_shape=editing_order.steel_shape,
                previous_line_shapes=editing_order.line_ids.mapped("steel_shape"),
                confirmed=post.get("shape_change_confirmed") == "1",
            )
            if shape_error:
                errors.append(shape_error)
            elif order_shape != editing_order.steel_shape and order_shape != "mixed":
                for line in lines:
                    line["steel_shape"] = order_shape

        reference = (post.get("customer_reference") or "").strip()
        driver_name = (vehicle.get("driver_name") or "").strip()
        identity = _format_identity(vehicle.get("driver_identity"))
        driver_phone = (vehicle.get("driver_phone") or "").strip()
        identity_digits = re.sub(r"\D", "", identity)
        area = post.get("delivery_area")
        cnxx_quantity_text = str(post.get("so_luong_cnxx") or "0").strip()
        if not re.fullmatch(r"[0-9]+", cnxx_quantity_text):
            errors.append("Số lượng giấy CNXX phải là số nguyên không âm.")
            cnxx_quantity = 0
        else:
            cnxx_quantity = int(cnxx_quantity_text)
        if not reference:
            errors.append("Vui lòng nhập số PO/ký hiệu đơn hàng của khách.")
        if not erp_partner:
            errors.append("Tài khoản chưa được gắn mã khách hàng ERP. Vui lòng liên hệ TMN.")
        contract_number = (post.get("contract_number") or "").strip()
        contract_id = int(post.get("contract_id")) if str(post.get("contract_id") or "").isdigit() else 0
        selected_contract = request.env["iwmn.r81dmhd"]
        if contract_number or contract_id:
            report_date = fields.Date.context_today(request.env.user)
            contract_domain = _contract_search_domain(
                erp_partner.ma_dt if erp_partner else "", report_date
            )
            contract_domain.append(
                ("id", "=", contract_id) if contract_id else ("ma_hd", "=", contract_number)
            )
            selected_contract = request.env["iwmn.r81dmhd"].sudo().search(contract_domain, limit=1)
            if not selected_contract:
                errors.append("Hợp đồng đã chọn không thuộc khách hàng hoặc không còn hiệu lực tại ngày hiện tại.")
            else:
                contract_number = selected_contract.ma_hd or ""
        selected_project = request.env["iwmn.r81dmctrinh"]
        project_id = (
            int(post.get("project_id"))
            if str(post.get("project_id") or "").isdigit() else 0
        )
        project_query = (post.get("project_query") or "").strip()
        if project_id:
            selected_project = request.env["iwmn.r81dmctrinh"].sudo().search(
                [("id", "=", project_id)], limit=1,
            )
        if project_query and not selected_project:
            errors.append("Vui lòng chọn công trình trong danh sách gợi ý.")
        if selected_project:
            form["project_id"] = selected_project.id
            form["project_query"] = _project_label(selected_project)

        selected_project_appendix = request.env["iwmn.r81dmplctrinh"]
        project_appendix_id = (
            int(post.get("project_appendix_id"))
            if str(post.get("project_appendix_id") or "").isdigit() else 0
        )
        project_appendix_query = (post.get("project_appendix_query") or "").strip()
        if project_appendix_id and selected_project:
            selected_project_appendix = request.env["iwmn.r81dmplctrinh"].sudo().search(
                [
                    ("id", "=", project_appendix_id),
                    ("ma_ctrinh", "=", selected_project.ma_ctrinh),
                ], limit=1,
            )
        if project_appendix_query and not selected_project_appendix:
            errors.append("Vui lòng chọn phụ lục thuộc công trình đã chọn trong danh sách gợi ý.")
        if selected_project_appendix:
            form["project_appendix_id"] = selected_project_appendix.id
            form["project_appendix_query"] = _project_appendix_label(selected_project_appendix)
        selected_warehouse = request.env["iwmn.r81dmkho"]
        if post.get("delivery_type") == "KG":
            warehouse_id = int(post.get("warehouse_id")) if str(post.get("warehouse_id") or "").isdigit() else 0
            if warehouse_id:
                selected_warehouse = request.env["iwmn.r81dmkho"].sudo().search(
                    [
                        ("id", "=", warehouse_id),
                        ("ma_dt", "=", (erp_partner.ma_dt or "").strip()),
                    ], limit=1,
                )
            if not selected_warehouse:
                errors.append("Vui lòng chọn kho ký gửi trong danh sách gợi ý.")
            else:
                form["ma_kho"] = selected_warehouse.ma_kho or ""
                form["warehouse_query"] = _warehouse_label(selected_warehouse)
        if not driver_name:
            errors.append("Vui lòng nhập tên tài xế.")
        if len(identity_digits) not in (9, 12):
            errors.append("CCCD/CMT tài xế phải gồm 9 hoặc 12 chữ số.")
        if area not in DELIVERY_AREAS:
            errors.append("Vui lòng chọn khu vực giao/nhận hàng hợp lệ.")
        payment_method = post.get("payment_method")
        if payment_method not in ("tra_cham", "tra_cham_40"):
            errors.append("Vui lòng chọn hình thức thanh toán hợp lệ.")
        transport_method = post.get("transport_method")
        if transport_method not in ("xe", "salan"):
            errors.append("Vui lòng chọn một phương tiện vận chuyển.")
        if post.get("order_action") == "submit":
            if transport_method == "xe" and not (vehicle.get("license_plate") or "").strip():
                errors.append("Vui lòng nhập biển số xe trước khi gửi đơn.")
            if transport_method == "salan" and not (vehicle.get("barge_number") or "").strip():
                errors.append("Vui lòng nhập số xà lan trước khi gửi đơn.")
        try:
            order_date = fields.Date.to_date(post.get("order_date"))
        except (TypeError, ValueError):
            order_date = None
        try:
            delivery_date = fields.Date.to_date(post.get("requested_delivery_date")) if post.get("requested_delivery_date") else None
        except (TypeError, ValueError):
            delivery_date = None
            errors.append("Ngày dự kiến nhận hàng không hợp lệ.")
        if not order_date:
            errors.append("Ngày đơn hàng không hợp lệ.")
        if order_date and delivery_date and delivery_date < order_date:
            errors.append("Ngày dự kiến nhận hàng không được trước ngày đơn hàng.")

        if errors:
            return request.render(
                "iwmn_customer_dashboard.portal_customer_order_form",
                self._prepare_order_form_values(form, lines, vehicle, errors, editing_order),
            )

        order_values = {
            "partner_id": partner.id,
            "erp_partner_id": erp_partner.id,
            "portal_user_id": request.env.user.id,
            "customer_reference": reference,
            "order_date": order_date,
            "requested_delivery_date": delivery_date,
            "receiver_name": driver_name,
            "receiver_identity": identity,
            "receiver_phone": driver_phone,
            "project_name": selected_project.ten_ctrinh or False,
            "project_code": selected_project.ma_ctrinh or False,
            "r81dmctrinh_id": selected_project.id or False,
            "subproject_name": selected_project_appendix.ten_plctrinh or False,
            "subproject_code": selected_project_appendix.ma_plctrinh or False,
            "r81dmplctrinh_id": selected_project_appendix.id or False,
            "so_luong_cnxx": cnxx_quantity,
            "contract_number": contract_number,
            "r81dmhd_id": selected_contract.id or False,
            "ma_kho": selected_warehouse.ma_kho or False,
            "r81dmkho_id": selected_warehouse.id or False,
            "delivery_type": post.get("delivery_type") if post.get("delivery_type") in ("HD", "KG", "GK") else "HD",
            "payment_method": payment_method,
            "delivery_area": area,
            "transport_method": transport_method,
            "vehicle_license_plate": (vehicle.get("license_plate") or "").strip().upper(),
            "vehicle_barge_number": (vehicle.get("barge_number") or "").strip().upper(),
            "vehicle_driver_name": driver_name,
            "vehicle_driver_identity": identity,
            "vehicle_driver_phone": driver_phone,
            "steel_shape": order_shape,
            "cnxx_show_project": bool(post.get("cnxx_show_project")),
            "other_requirements": (post.get("other_requirements") or "").strip(),
            "line_ids": ([(5, 0, 0)] if editing_order else []) + line_commands,
        }
        try:
            with request.env.cr.savepoint():
                if editing_order:
                    editing_order.write(order_values)
                    order = editing_order
                else:
                    order = request.env["iwmn.customer.order"].sudo().create(order_values)
                if post.get("order_action") == "submit":
                    order.action_submit()
        except ValidationError as exception:
            errors.append(str(exception))
            return request.render(
                "iwmn_customer_dashboard.portal_customer_order_form",
                self._prepare_order_form_values(form, lines, vehicle, errors, editing_order),
            )
        if post.get("order_action") == "submit":
            return request.redirect(f"/my/orders/{order.id}?sent=1")
        return request.redirect(f"/my/orders/{order.id}?saved=1")

    @http.route("/my/orders/<int:order_id>/edit", type="http", auth="user", website=True)
    def portal_order_edit(self, order_id, **kwargs):
        order = self._find_portal_order(order_id, [("state", "=", "draft")])
        if not order:
            return request.not_found()
        form, lines, vehicle = self._order_edit_values(order)
        return request.render(
            "iwmn_customer_dashboard.portal_customer_order_form",
            self._prepare_order_form_values(form, lines, vehicle, order=order),
        )

    @http.route("/my/orders/<int:order_id>", type="http", auth="user", website=True)
    def portal_order_page(self, order_id, **kwargs):
        order = self._find_portal_order(order_id)
        if not order:
            return request.not_found()
        values = self._prepare_portal_layout_values()
        values.update({
            "page_name": "customer_order_detail",
            "order": order,
            "saved": kwargs.get("saved") == "1",
            "sent": kwargs.get("sent") == "1",
            "vehicles_updated": kwargs.get("vehicles") == "1",
            "cancelled": kwargs.get("cancelled") == "1",
            "submit_error": kwargs.get("submit_error") == "1",
            "vehicle_error": kwargs.get("vehicle_error") == "1",
            "can_update_vehicles": order.gate_state == "not_arrived" and order.state not in ("cancelled", "delivered", "documents_issued", "closed"),
            "can_cancel": order.gate_state != "exited" and order.state not in ("cancelled", "delivered", "documents_issued", "closed"),
        })
        return request.render("iwmn_customer_dashboard.portal_customer_order_detail", values)

    @http.route("/my/orders/<int:order_id>/cnxx", type="http", auth="user", methods=["GET"])
    def portal_order_cnxx(self, order_id, **kwargs):
        order = self._find_portal_order(order_id)
        if not order or not order.cnxx_file:
            return request.not_found()
        filename = order.cnxx_filename or f"CNXX-{order.name.replace('/', '-')}.pdf"
        return request.make_response(
            base64.b64decode(order.cnxx_file),
            headers=[
                ("Content-Type", "application/pdf"),
                ("Content-Disposition", content_disposition(filename)),
                ("X-Content-Type-Options", "nosniff"),
            ],
        )

    @http.route("/my/orders/<int:order_id>/print", type="http", auth="user", methods=["GET"])
    def portal_order_print(self, order_id, **kwargs):
        order = self._find_portal_order(order_id, [("submitted_at", "!=", False)])
        if not order:
            return request.not_found()
        pdf, _ = request.env["ir.actions.report"].sudo()._render_qweb_pdf(
            "iwmn_customer_dashboard.action_report_customer_order", [order.id]
        )
        filename = f"Phieu-dat-hang-{order.name.replace('/', '-')}.pdf"
        return request.make_response(pdf, headers=[
            ("Content-Type", "application/pdf"),
            ("Content-Disposition", content_disposition(filename)),
            ("X-Content-Type-Options", "nosniff"),
            ("Cache-Control", "private, no-store"),
        ])

    @http.route("/my/orders/<int:order_id>/vehicles", type="http", auth="user", website=True, methods=["POST"])
    def portal_order_update_vehicles(self, order_id, **post):
        order = self._find_portal_order(
            order_id,
            [
                ("gate_state", "=", "not_arrived"),
                ("state", "not in", ("cancelled", "delivered", "documents_issued", "closed")),
            ],
        )
        if not order:
            return request.not_found()
        _, vehicle = self._extract_order_rows()
        driver_name = (vehicle.get("driver_name") or "").strip()
        driver_identity = _format_identity(vehicle.get("driver_identity"))
        identity_digits = re.sub(r"\D", "", driver_identity)
        if (
            (order.transport_method == "xe" and not (vehicle.get("license_plate") or "").strip())
            or (order.transport_method == "salan" and not (vehicle.get("barge_number") or "").strip())
            or not driver_name
            or len(identity_digits) not in (9, 12)
        ):
            return request.redirect(f"/my/orders/{order.id}?vehicle_error=1")
        order.write({
            "vehicle_license_plate": (vehicle.get("license_plate") or "").strip().upper(),
            "vehicle_barge_number": (vehicle.get("barge_number") or "").strip().upper(),
            "vehicle_driver_name": driver_name,
            "vehicle_driver_identity": driver_identity,
            "vehicle_driver_phone": (vehicle.get("driver_phone") or "").strip(),
        })
        return request.redirect(f"/my/orders/{order.id}?vehicles=1")

    @http.route("/my/orders/<int:order_id>/cancel", type="http", auth="user", website=True, methods=["POST"])
    def portal_order_cancel(self, order_id, **post):
        order = self._find_portal_order(
            order_id,
            [
                ("gate_state", "!=", "exited"),
                ("state", "not in", ("cancelled", "delivered", "documents_issued", "closed")),
            ],
        )
        if not order:
            return request.not_found()
        order.action_cancel_by_customer((post.get("cancellation_reason") or "").strip())
        return request.redirect(f"/my/orders/{order.id}?cancelled=1")

    @http.route("/my/orders/<int:order_id>/submit", type="http", auth="user", website=True, methods=["POST"])
    def portal_order_submit(self, order_id, **post):
        order = self._find_portal_order(order_id, [("state", "=", "draft")])
        if not order:
            return request.not_found()
        try:
            order.action_submit()
        except ValidationError:
            return request.redirect(f"/my/orders/{order.id}?submit_error=1")
        return request.redirect(f"/my/orders/{order.id}?sent=1")
