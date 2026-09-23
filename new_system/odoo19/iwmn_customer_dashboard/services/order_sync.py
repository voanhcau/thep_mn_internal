import logging
from decimal import Decimal, ROUND_HALF_UP

import requests


_logger = logging.getLogger(__name__)


class OrderSyncError(Exception):
    """Safe message for a failed R04CTDH synchronization."""


def build_r04ctdh_rows(order):
    """Build the complete, replaceable R04CTDH snapshot for one Odoo order."""
    common = {
        "idWebHeader": order.id,
        "maDt": order.erp_partner_id.ma_dt or "",
        "ngayCt": order.order_date.isoformat(),
        "soDh": order.customer_reference or "",
        "soXe": order.vehicle_license_plate or "",
        "soXaLanTau": order.vehicle_barge_number or "",
        "ptVc": order.transport_method or "",
        "htTt": order.payment_method or "",
        "maHd": order.r81dmhd_id.ma_hd or order.contract_number or "",
        "maPlCtrinh": order.r81dmplctrinh_id.ma_plctrinh or order.subproject_code or "",
        "idDtVc": order.vehicle_driver_identity or "",
        "tenDtVc": order.vehicle_driver_name or "",
        "isCnxx": bool(order.cnxx_show_project),
        "soLuongCnxx": order.so_luong_cnxx or 0,
        "maKhoN": order.r81dmkho_id.ma_kho or order.ma_kho or "",
        "createLog": f"ODOO-WEB:{order.id}",
        "lastModifyLog": f"ODOO-WEB:{order.id}",
    }
    return [{
        **common,
        "idWebDetail": line.id,
        "dienGiai": line.note or "",
        "maVt": line.product_id.ma_vt or "",
        "tenVt": line.product_id.ten_vt or "",
        "dvt": line.product_id.dvt or "",
        "soLuongBo": line.bundle_qty or 0,
        "soLuongCayLe": line.loose_bar_qty or 0,
        "soLuongCay": line.total_bar_qty or 0,
        "soLuong": int(Decimal(str(max(line.weight_kg, 0))).quantize(
            Decimal("1"), rounding=ROUND_HALF_UP,
        )),
        "boBe": "true" if line.steel_shape == "straight" else "false",
        "boThang": "false" if line.steel_shape == "straight" else "true",
    } for line in order.line_ids]


class OrderSyncService:
    def __init__(self, env):
        params = env["ir.config_parameter"].sudo()
        self.base_url = (params.get_param("iwmn_customer_dashboard.api_url") or "").rstrip("/")
        self.client_id = params.get_param("iwmn_customer_dashboard.client_id") or ""
        self.client_secret = params.get_param("iwmn_customer_dashboard.client_secret") or ""
        try:
            self.timeout = min(max(int(params.get_param("iwmn_customer_dashboard.timeout") or 15), 3), 60)
        except (TypeError, ValueError):
            self.timeout = 15

    def sync(self, order):
        if not self.base_url or not self.client_id or not self.client_secret:
            raise OrderSyncError("Chưa cấu hình kết nối IntegrationHub để đồng bộ đơn hàng.")
        rows = build_r04ctdh_rows(order)
        if not rows or not order.erp_partner_id.ma_dt or any(not row["maVt"] for row in rows):
            raise OrderSyncError("Đơn hàng thiếu mã khách hàng hoặc mã sản phẩm ERP.")
        try:
            token_response = requests.post(
                f"{self.base_url}/connect/token",
                data={
                    "grant_type": "client_credentials",
                    "client_id": self.client_id,
                    "client_secret": self.client_secret,
                    "scope": "orders.write",
                },
                timeout=self.timeout,
            )
            if not token_response.ok:
                _logger.warning("Order sync token request returned HTTP %s", token_response.status_code)
                raise OrderSyncError("Không thể xác thực quyền ghi đơn hàng với IntegrationHub.")
            token = token_response.json().get("access_token")
            if not token:
                raise OrderSyncError("IntegrationHub không trả về token hợp lệ.")
            response = requests.put(
                f"{self.base_url}/api/v1/orders/customer-orders/{order.id}/r04ctdh",
                json={"rows": rows},
                headers={"Authorization": f"Bearer {token}", "Accept": "application/json"},
                timeout=self.timeout,
            )
        except requests.RequestException as exception:
            _logger.warning("Order %s could not reach IntegrationHub: %s", order.id, type(exception).__name__)
            raise OrderSyncError("Không thể kết nối IntegrationHub để đồng bộ đơn hàng.") from exception
        except ValueError as exception:
            raise OrderSyncError("Phản hồi IntegrationHub không hợp lệ.") from exception
        if not response.ok:
            _logger.warning("Order %s sync returned HTTP %s", order.id, response.status_code)
            raise OrderSyncError(f"IntegrationHub từ chối đồng bộ đơn hàng (HTTP {response.status_code}).")
