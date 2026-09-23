import base64
import re
import logging
from decimal import Decimal, ROUND_HALF_UP
from pathlib import Path

from odoo import SUPERUSER_ID, api, fields, models
from odoo.exceptions import ValidationError
from odoo.orm.registry import Registry

from ..services.order_sync import OrderSyncError, OrderSyncService
from ..services.bar_weight_api import BarWeightApiError, BarWeightApiService


_logger = logging.getLogger(__name__)


def _sync_order_after_commit(database_name, order_id):
    try:
        with Registry(database_name).cursor() as cursor:
            environment = api.Environment(cursor, SUPERUSER_ID, {})
            order = environment["iwmn.customer.order"].browse(order_id).exists()
            if order:
                order._sync_legacy_order()
            cursor.commit()
    except Exception as exception:
        _logger.warning("R04CTDH post-commit sync failed for order %s: %s", order_id, type(exception).__name__)


ORDER_STATES = [
    ("draft", "Nháp"), ("waiting_confirmation", "Chờ TMN xác nhận"),
    ("waiting_payment", "Chờ thanh toán"), ("waiting_approval", "Chờ duyệt"),
    ("waiting_delivery", "Chờ giao hàng"), ("delivered", "Đã giao"),
    ("cancelled", "Đã hủy"), ("closed", "Đã đóng"),
    ("documents_issued", "Đã phát hành chứng từ"),
]

DELIVERY_AREAS = [
    ("phu_my", "Phú Mỹ"), ("can_tho", "Cần Thơ"), ("phu_quoc", "Phú Quốc"),
    ("da_nang", "Đà Nẵng"), ("nha_trang", "Nha Trang"),
    ("di_an", "Dĩ An - Bình Dương"),
]

WAREHOUSE_CODES_BY_AREA = {
    "phu_my": ("04TP", "052TMN", "552TMN_NB", "552TMN_TD"),
    "can_tho": ("051CT", "551CT_NB", "551CT_TD"),
    "phu_quoc": ("051P2", "551P2_NB", "551P2_TD"),
    "da_nang": ("051D2", "551D2_NB", "551D2_TD"),
    "nha_trang": ("051NT", "551NT_NB", "551NT_TD"),
    "di_an": ("055POM1",),
}


class IwmnR81DmVtPortal(models.Model):
    _inherit = "iwmn.r81dmvt"

    portal_image = fields.Image(
        string="Hình ảnh trên portal", max_width=1024, max_height=1024,
        help="Ảnh minh họa hiển thị trong danh sách gợi ý và giỏ hàng của khách.",
    )


class IwmnCustomerOrderContract(models.Model):
    _name = "iwmn.customer.order.contract"
    _description = "Danh mục hợp đồng dành cho portal đặt hàng"
    _rec_name = "contract_number"
    _order = "contract_number"

    erp_partner_id = fields.Many2one(
        "iwmn.r81dmdt", string="Khách hàng ERP", required=True, index=True, ondelete="cascade"
    )
    contract_number = fields.Char(string="Số hợp đồng", required=True, index=True)
    active = fields.Boolean(default=True)

    _contract_partner_unique = models.Constraint(
        "UNIQUE(erp_partner_id, contract_number)", "Hợp đồng này đã có trong danh mục của khách hàng."
    )


class IwmnCustomerOrderProject(models.Model):
    _name = "iwmn.customer.order.project"
    _description = "Danh mục công trình dành cho portal đặt hàng"
    _rec_name = "project_name"
    _order = "project_name"

    erp_partner_id = fields.Many2one(
        "iwmn.r81dmdt", string="Khách hàng ERP", required=True, index=True, ondelete="cascade"
    )
    project_code = fields.Char(string="Mã công trình", index=True)
    project_name = fields.Char(string="Tên công trình", required=True, index=True)
    subproject_code = fields.Char(string="Mã phụ lục/công trình con")
    subproject_name = fields.Char(string="Tên phụ lục/công trình con")
    active = fields.Boolean(default=True)


class IwmnCustomerOrder(models.Model):
    _name = "iwmn.customer.order"
    _description = "Đơn đặt hàng từ portal khách hàng"
    _order = "create_date desc, id desc"

    @api.model
    def _report_logo_data_uri(self):
        logo_path = Path(__file__).resolve().parents[1] / "static" / "src" / "img" / "order_report_logo.png"
        return "data:image/png;base64," + base64.b64encode(logo_path.read_bytes()).decode("ascii")

    name = fields.Char(string="Mã đơn portal", required=True, copy=False, default="Mới", index=True)
    partner_id = fields.Many2one("res.partner", string="Khách hàng", required=True, index=True, ondelete="restrict")
    erp_partner_id = fields.Many2one("iwmn.r81dmdt", string="Khách hàng ERP", index=True, ondelete="restrict")
    portal_user_id = fields.Many2one("res.users", string="Người tạo trên portal", required=True, index=True, ondelete="restrict")
    customer_reference = fields.Char(string="Số PO/ký hiệu của khách", required=True, index=True)
    contract_number = fields.Char(string="Số hợp đồng")
    r81dmhd_id = fields.Many2one(
        "iwmn.r81dmhd", string="Hợp đồng ERP", index=True, ondelete="restrict",
    )
    ma_kho = fields.Char(string="Mã kho ký gửi")
    r81dmkho_id = fields.Many2one(
        "iwmn.r81dmkho", string="Kho ký gửi ERP", index=True, ondelete="restrict",
    )
    project_code = fields.Char(string="Mã công trình")
    project_name = fields.Char(string="Tên công trình")
    r81dmctrinh_id = fields.Many2one(
        "iwmn.r81dmctrinh", string="Công trình ERP", index=True, ondelete="restrict",
    )
    subproject_code = fields.Char(string="Mã phụ lục/công trình con")
    subproject_name = fields.Char(string="Tên phụ lục/công trình con")
    r81dmplctrinh_id = fields.Many2one(
        "iwmn.r81dmplctrinh", string="Phụ lục ERP", index=True, ondelete="restrict",
    )
    so_luong_cnxx = fields.Integer(string="Số lượng giấy CNXX", default=0)
    order_date = fields.Date(string="Ngày đơn hàng", required=True, default=fields.Date.context_today)
    requested_delivery_date = fields.Date(string="Ngày dự kiến nhận hàng")
    delivery_type = fields.Selection(
        [("HD", "Xuất hóa đơn"), ("KG", "Ký gửi"), ("GK", "Gửi kho")],
        string="Hình thức giao nhận", required=True, default="HD",
    )
    payment_method = fields.Selection(
        [("tra_cham", "Trả chậm"), ("tra_cham_40", "Trả chậm 40 ngày")],
        string="Hình thức thanh toán", required=True, default="tra_cham_40",
    )
    delivery_area = fields.Selection(DELIVERY_AREAS, string="Khu vực giao/nhận hàng", required=True)
    assigned_warehouse_codes = fields.Char(
        string="Kho nội bộ được phân bổ",
        help="PKD phân bổ một hoặc nhiều kho sau khi tiếp nhận đơn. Khách hàng không chọn trường này.",
    )
    allowed_warehouse_codes = fields.Char(string="Các kho hợp lệ", compute="_compute_allowed_warehouses")
    transport_method = fields.Selection(
        [("xe", "Xe"), ("salan", "Xà lan")],
        string="Phương tiện vận chuyển", required=True, default="xe",
    )
    vehicle_license_plate = fields.Char(string="Biển số xe")
    vehicle_barge_number = fields.Char(string="Số xà lan")
    vehicle_driver_name = fields.Char(string="Tên tài xế")
    vehicle_driver_identity = fields.Char(string="CCCD/CMT tài xế")
    vehicle_driver_phone = fields.Char(string="Số điện thoại tài xế")
    # Kept as synchronized legacy aliases for reports/integrations created before
    # the portal switched to one canonical set of driver fields.
    receiver_name = fields.Char(string="Tên tài xế (tương thích)")
    receiver_identity = fields.Char(string="CCCD/CMT tài xế (tương thích)")
    receiver_phone = fields.Char(string="Số điện thoại tài xế (tương thích)")
    steel_shape = fields.Selection(
        [("straight", "Thẳng"), ("bent", "Bẻ cong"), ("mixed", "Cả hai")],
        string="Hình dạng", required=True, default="straight",
    )
    cnxx_show_project = fields.Boolean(string="Hiển thị tên công trình trên CNXX")
    other_requirements = fields.Text(string="Yêu cầu khác")
    state = fields.Selection(ORDER_STATES, string="Trạng thái", required=True, default="draft", index=True)
    gate_state = fields.Selection(
        [("not_arrived", "Chưa đến cổng"), ("at_gate", "Đã đến cổng"), ("exited", "Đã ra cổng")],
        string="Trạng thái tại cổng", required=True, default="not_arrived",
    )
    state_label = fields.Char(string="Tên trạng thái", compute="_compute_selection_labels")
    delivery_type_label = fields.Char(string="Tên hình thức giao nhận", compute="_compute_selection_labels")
    payment_method_label = fields.Char(string="Tên hình thức thanh toán", compute="_compute_selection_labels")
    delivery_area_label = fields.Char(string="Tên khu vực", compute="_compute_selection_labels")
    transport_method_label = fields.Char(string="Tên phương tiện", compute="_compute_selection_labels")
    steel_shape_label = fields.Char(string="Tên loại thép", compute="_compute_selection_labels")
    submitted_at = fields.Datetime(string="Thời điểm gửi xác nhận", readonly=True)
    legacy_sync_state = fields.Selection(
        [("not_synced", "Chưa gửi"), ("pending", "Đang chờ"),
         ("synced", "Đã đồng bộ"), ("failed", "Lỗi đồng bộ")],
        string="Đồng bộ R04CTDH", default="not_synced", readonly=True, copy=False,
    )
    legacy_sync_error = fields.Char(string="Lỗi đồng bộ R04CTDH", readonly=True, copy=False)
    legacy_synced_at = fields.Datetime(string="Lần đồng bộ R04CTDH", readonly=True, copy=False)
    legacy_sync_attempts = fields.Integer(string="Số lần thử đồng bộ", readonly=True, copy=False)
    cancellation_reason = fields.Text(string="Lý do hủy/đóng")
    socp_number = fields.Char(string="Số SOCP nội bộ", readonly=True, copy=False)
    invoice_url = fields.Char(string="Liên kết hóa đơn điện tử")
    cnxx_file = fields.Binary(string="File CNXX", attachment=True)
    cnxx_filename = fields.Char(string="Tên file CNXX")
    line_ids = fields.One2many("iwmn.customer.order.line", "order_id", string="Hàng hóa", copy=True)
    vehicle_ids = fields.One2many(
        "iwmn.customer.order.vehicle", "order_id", string="Phương tiện cũ", copy=True,
        help="Dữ liệu tương thích từ phiên bản cho phép nhiều phương tiện; không dùng cho đơn mới.",
    )
    total_weight_kg = fields.Float(string="Tổng khối lượng (kg)", compute="_compute_totals", store=True, digits=(16, 0))
    official_amount = fields.Monetary(string="Tổng tiền chính thức", compute="_compute_totals", store=True, currency_field="currency_id")
    currency_id = fields.Many2one("res.currency", string="Tiền tệ", default=lambda self: self.env.company.currency_id, required=True)

    @api.depends("line_ids.weight_kg", "line_ids.official_subtotal")
    def _compute_totals(self):
        for order in self:
            order.total_weight_kg = sum(order.line_ids.mapped("weight_kg"))
            order.official_amount = sum(order.line_ids.mapped("official_subtotal"))

    @api.depends("state", "delivery_type", "payment_method", "delivery_area", "transport_method", "steel_shape")
    def _compute_selection_labels(self):
        labels = {
            "state": "state_label", "delivery_type": "delivery_type_label",
            "payment_method": "payment_method_label",
            "delivery_area": "delivery_area_label", "transport_method": "transport_method_label",
            "steel_shape": "steel_shape_label",
        }
        for order in self:
            for source, target in labels.items():
                setattr(order, target, dict(order._fields[source]._description_selection(order.env)).get(order[source], ""))

    @api.depends("delivery_area")
    def _compute_allowed_warehouses(self):
        for order in self:
            order.allowed_warehouse_codes = ", ".join(WAREHOUSE_CODES_BY_AREA.get(order.delivery_area, ()))

    @api.model_create_multi
    def create(self, vals_list):
        for vals in vals_list:
            self._synchronize_driver_values(vals)
            if vals.get("name", "Mới") == "Mới":
                vals["name"] = self.env["ir.sequence"].next_by_code("iwmn.customer.order") or "Mới"
        return super().create(vals_list)

    def write(self, vals):
        vals = dict(vals)
        self._synchronize_driver_values(vals)
        return super().write(vals)

    @staticmethod
    def _synchronize_driver_values(vals):
        for driver_field, legacy_field in (
            ("vehicle_driver_name", "receiver_name"),
            ("vehicle_driver_identity", "receiver_identity"),
            ("vehicle_driver_phone", "receiver_phone"),
        ):
            if driver_field in vals:
                vals[legacy_field] = vals[driver_field]
            elif legacy_field in vals:
                vals[driver_field] = vals[legacy_field]

    def action_submit(self):
        for order in self:
            if order.state != "draft":
                continue
            if not order.line_ids:
                raise ValidationError("Đơn hàng cần có ít nhất một sản phẩm.")
            order._validate_transport_details()
            order._validate_driver_details()
            order.write({
                "state": "waiting_confirmation", "submitted_at": fields.Datetime.now(),
                "legacy_sync_state": "pending", "legacy_sync_error": False,
            })
            database_name, order_id = self.env.cr.dbname, order.id
            self.env.cr.postcommit.add(
                lambda db=database_name, oid=order_id: _sync_order_after_commit(db, oid)
            )

    def _sync_legacy_order(self):
        self.ensure_one()
        if self.state in ("draft", "cancelled") or self.legacy_sync_state == "synced":
            return
        attempts = self.legacy_sync_attempts + 1
        try:
            OrderSyncService(self.env).sync(self)
        except OrderSyncError as exception:
            self.write({
                "legacy_sync_state": "failed", "legacy_sync_error": str(exception),
                "legacy_sync_attempts": attempts,
            })
        except Exception as exception:
            _logger.warning("R04CTDH sync failed for order %s: %s", self.id, type(exception).__name__)
            self.write({
                "legacy_sync_state": "failed",
                "legacy_sync_error": "Đồng bộ SQL Server thất bại; hệ thống sẽ thử lại.",
                "legacy_sync_attempts": attempts,
            })
        else:
            self.write({
                "legacy_sync_state": "synced", "legacy_sync_error": False,
                "legacy_synced_at": fields.Datetime.now(), "legacy_sync_attempts": attempts,
            })

    @api.model
    def cron_retry_legacy_sync(self):
        orders = self.search([
            ("state", "not in", ("draft", "cancelled")),
            ("legacy_sync_state", "in", ("pending", "failed")),
        ], order="id asc", limit=20)
        for order in orders:
            order._sync_legacy_order()

    def action_reset_draft(self):
        self.filtered(lambda order: order.state == "waiting_confirmation").state = "draft"

    def action_cancel_by_customer(self, reason=None):
        for order in self:
            if order.gate_state == "exited" or order.state in ("delivered", "documents_issued", "closed"):
                raise ValidationError("Không thể hủy đơn sau khi phương tiện đã ra cổng hoặc đã giao hàng.")
            if order.state != "cancelled":
                order.write({"state": "cancelled", "cancellation_reason": reason or "Khách hàng hủy trên portal"})

    def _validate_transport_details(self):
        for order in self:
            if order.transport_method == "xe" and not order.vehicle_license_plate:
                raise ValidationError("Vui lòng nhập biển số xe.")
            if order.transport_method == "salan" and not order.vehicle_barge_number:
                raise ValidationError("Vui lòng nhập số xà lan.")

    def _validate_driver_details(self):
        for order in self:
            if not (order.vehicle_driver_name or "").strip():
                raise ValidationError("Vui lòng nhập tên tài xế.")
            digits = re.sub(r"\D", "", order.vehicle_driver_identity or "")
            if len(digits) not in (9, 12):
                raise ValidationError("CCCD/CMT tài xế phải gồm 9 hoặc 12 chữ số.")

    def init(self):
        """Move the first legacy vehicle onto the order when upgrading old databases."""
        self.env.cr.execute("""
            UPDATE iwmn_customer_order
               SET vehicle_driver_name = COALESCE(NULLIF(vehicle_driver_name, ''), receiver_name),
                   vehicle_driver_identity = COALESCE(NULLIF(vehicle_driver_identity, ''), receiver_identity),
                   vehicle_driver_phone = COALESCE(NULLIF(vehicle_driver_phone, ''), receiver_phone),
                   receiver_name = COALESCE(NULLIF(receiver_name, ''), vehicle_driver_name),
                   receiver_identity = COALESCE(NULLIF(receiver_identity, ''), vehicle_driver_identity),
                   receiver_phone = COALESCE(NULLIF(receiver_phone, ''), vehicle_driver_phone)
        """)
        self.env.cr.execute("""
            UPDATE iwmn_customer_order
               SET transport_method = CASE transport_method
                   WHEN 'truck' THEN 'xe'
                   WHEN 'barge' THEN 'salan'
                   ELSE transport_method
               END
             WHERE transport_method IN ('truck', 'barge')
        """)
        self.env.cr.execute("SELECT to_regclass('iwmn_customer_order_line')")
        if self.env.cr.fetchone()[0]:
            self.env.cr.execute("""
                UPDATE iwmn_customer_order_line AS line
                   SET steel_shape = CASE WHEN customer_order.steel_shape = 'bent' THEN 'bent' ELSE 'straight' END
                  FROM iwmn_customer_order AS customer_order
                 WHERE line.order_id = customer_order.id AND line.steel_shape = 'inherit'
            """)
        self.env.cr.execute("SELECT to_regclass('iwmn_customer_order_vehicle')")
        if not self.env.cr.fetchone()[0]:
            self.env.cr.execute("""
                UPDATE iwmn_customer_order SET transport_method = 'xe'
                 WHERE transport_method = 'both'
            """)
            return
        self.env.cr.execute("""
            WITH first_vehicle AS (
                SELECT DISTINCT ON (order_id) *
                  FROM iwmn_customer_order_vehicle
                 ORDER BY order_id, sequence, id
            )
            UPDATE iwmn_customer_order AS customer_order
               SET vehicle_license_plate = COALESCE(customer_order.vehicle_license_plate, vehicle.license_plate),
                   vehicle_barge_number = COALESCE(customer_order.vehicle_barge_number, vehicle.barge_number),
                   vehicle_driver_name = COALESCE(customer_order.vehicle_driver_name, vehicle.driver_name),
                   vehicle_driver_identity = COALESCE(customer_order.vehicle_driver_identity, vehicle.driver_identity),
                   vehicle_driver_phone = COALESCE(customer_order.vehicle_driver_phone, vehicle.driver_phone),
                   transport_method = CASE
                       WHEN customer_order.transport_method = 'both' AND vehicle.license_plate IS NOT NULL THEN 'xe'
                       WHEN customer_order.transport_method = 'both' THEN 'salan'
                       ELSE customer_order.transport_method
                   END
              FROM first_vehicle AS vehicle
             WHERE vehicle.order_id = customer_order.id
               AND (customer_order.vehicle_license_plate IS NULL
                 OR customer_order.vehicle_barge_number IS NULL
                 OR customer_order.vehicle_driver_name IS NULL
                 OR customer_order.vehicle_driver_identity IS NULL
                 OR customer_order.vehicle_driver_phone IS NULL
                 OR customer_order.transport_method = 'both')
        """)
        self.env.cr.execute("""
            UPDATE iwmn_customer_order
               SET transport_method = 'xe'
             WHERE transport_method = 'both'
        """)

    @api.constrains("vehicle_driver_identity", "receiver_identity")
    def _check_driver_identity(self):
        for order in self:
            identity = order.vehicle_driver_identity or order.receiver_identity or ""
            digits = re.sub(r"\D", "", identity)
            if identity and len(digits) not in (9, 12):
                raise ValidationError("CCCD/CMT tài xế phải gồm 9 hoặc 12 chữ số.")

    @api.constrains("so_luong_cnxx")
    def _check_so_luong_cnxx(self):
        for order in self:
            if order.so_luong_cnxx < 0:
                raise ValidationError("Số lượng giấy CNXX không được âm.")

    @api.constrains("r81dmctrinh_id", "r81dmplctrinh_id")
    def _check_project_appendix(self):
        for order in self:
            if (
                order.r81dmctrinh_id
                and order.r81dmplctrinh_id
                and (order.r81dmctrinh_id.ma_ctrinh or "").strip()
                != (order.r81dmplctrinh_id.ma_ctrinh or "").strip()
            ):
                raise ValidationError("Phụ lục phải thuộc công trình đã chọn.")

    @api.constrains("order_date", "requested_delivery_date")
    def _check_delivery_date(self):
        for order in self:
            if order.requested_delivery_date and order.requested_delivery_date < order.order_date:
                raise ValidationError("Ngày dự kiến nhận hàng không được trước ngày đơn hàng.")

    @api.constrains("delivery_area", "assigned_warehouse_codes")
    def _check_assigned_warehouses(self):
        for order in self:
            if not order.assigned_warehouse_codes:
                continue
            entered = {code.strip().upper() for code in re.split(r"[,;]", order.assigned_warehouse_codes) if code.strip()}
            allowed = set(WAREHOUSE_CODES_BY_AREA.get(order.delivery_area, ()))
            invalid = entered - allowed
            if invalid:
                raise ValidationError("Kho %s không thuộc khu vực đã chọn." % ", ".join(sorted(invalid)))


class IwmnCustomerOrderVehicle(models.Model):
    _name = "iwmn.customer.order.vehicle"
    _description = "Phương tiện nhận hàng của đơn portal"
    _order = "sequence, id"

    sequence = fields.Integer(default=10)
    order_id = fields.Many2one("iwmn.customer.order", required=True, ondelete="cascade", index=True)
    license_plate = fields.Char(string="Số xe")
    barge_number = fields.Char(string="Số xà lan")
    driver_name = fields.Char(string="Tài xế/người nhận")
    driver_identity = fields.Char(string="CCCD/CMT")
    driver_phone = fields.Char(string="Số điện thoại")


class IwmnCustomerOrderLine(models.Model):
    _name = "iwmn.customer.order.line"
    _description = "Dòng hàng của đơn portal"
    _order = "sequence, id"

    sequence = fields.Integer(default=10)
    order_id = fields.Many2one("iwmn.customer.order", required=True, ondelete="cascade", index=True)
    product_id = fields.Many2one(
        "iwmn.r81dmvt", string="Sản phẩm ERP", index=True, ondelete="restrict",
        help="Sản phẩm được khách chọn từ danh mục R81DMVT, giới hạn nhóm THEPCANDAI.",
    )
    product_query = fields.Char(string="Mã hoặc tên sản phẩm", required=True)
    product_type = fields.Selection([("bar", "Thép cây"), ("coil", "Thép cuộn")], string="Dạng sản phẩm", required=True, default="bar")
    size_code = fields.Char(string="Kích thước/size")
    steel_grade = fields.Char(string="Mác thép")
    length_m = fields.Float(string="Chiều dài (m)", digits=(10, 2))
    bar_input_mode = fields.Selection(
        [("bars", "Nhập theo cây"), ("bundles", "Nhập theo bó và cây lẻ")],
        string="Cách nhập thép cây", default="bars", required=True,
    )
    total_bar_qty = fields.Integer(string="Tổng số cây")
    bars_per_bundle = fields.Integer(string="Số cây/bó", readonly=True)
    bundle_qty = fields.Integer(string="Số bó", compute="_compute_quantity", store=True)
    loose_bar_qty = fields.Integer(string="Số cây lẻ", compute="_compute_quantity", store=True)
    bar_weight_kg = fields.Float(string="Kg/cây", digits=(16, 4), readonly=True)
    bundle_weight_kg = fields.Float(string="Kg/bó tiêu chuẩn", digits=(16, 4), readonly=True)
    requested_weight_kg = fields.Float(string="Khối lượng thép cuộn (kg)", digits=(16, 3))
    coil_cut_qty = fields.Integer(string="Số cuộn cần cắt")
    weight_kg = fields.Float(string="Khối lượng (kg)", compute="_compute_quantity", store=True, digits=(16, 0))
    customer_unit_price = fields.Monetary(string="Đơn giá khách thỏa thuận", currency_field="currency_id", help="Giá tham khảo do khách nhập; không phải giá chính thức.")
    official_unit_price = fields.Monetary(string="Đơn giá chính thức", currency_field="currency_id", help="PKD cập nhật; không hiển thị quyết định giá nội bộ.")
    price_adjustment = fields.Monetary(string="Điều chỉnh giá", currency_field="currency_id")
    official_subtotal = fields.Monetary(string="Thành tiền chính thức", compute="_compute_official_subtotal", store=True, currency_field="currency_id")
    currency_id = fields.Many2one(related="order_id.currency_id", store=True, readonly=True)
    stock_status = fields.Selection(
        [("pending", "Chờ TMN kiểm tra"), ("available", "Đủ hàng"), ("partial", "Thiếu một phần"), ("unavailable", "Chưa có hàng")],
        string="Tình trạng tồn kho", required=True, default="pending",
    )
    steel_shape = fields.Selection(
        [("straight", "Thẳng"), ("bent", "Bẻ cong")],
        string="Hình dạng", default="straight", required=True,
    )
    note = fields.Char(string="Ghi chú")

    @api.depends("product_type", "product_id", "total_bar_qty", "bars_per_bundle", "bar_weight_kg", "bundle_weight_kg", "requested_weight_kg")
    def _compute_quantity(self):
        for line in self:
            if line.product_type == "coil":
                line.bundle_qty = line.loose_bar_qty = 0
                line.weight_kg = float(Decimal(str(max(line.requested_weight_kg, 0))).quantize(
                    Decimal("1"), rounding=ROUND_HALF_UP,
                ))
                continue
            total = max(line.total_bar_qty, 0)
            if line.bars_per_bundle > 0:
                line.bundle_qty, line.loose_bar_qty = divmod(total, line.bars_per_bundle)
            else:
                line.bundle_qty, line.loose_bar_qty = 0, total
            if line.product_id and total > 0:
                try:
                    api_weight = BarWeightApiService(line.env).calculate(
                        line.product_id.ma_vt, line.bundle_qty, line.loose_bar_qty,
                    )
                except BarWeightApiError as exception:
                    raise ValidationError(str(exception)) from exception
                line.weight_kg = float(api_weight.quantize(Decimal("1"), rounding=ROUND_HALF_UP))
                continue
            # Legacy lines without an ERP product remain readable and editable.
            loose_weight = (Decimal(str(line.loose_bar_qty)) * Decimal(str(line.bar_weight_kg))).quantize(
                Decimal("1"), rounding=ROUND_HALF_UP,
            )
            line.weight_kg = float((
                Decimal(str(line.bundle_qty)) * Decimal(str(line.bundle_weight_kg)) + loose_weight
            ).quantize(Decimal("1"), rounding=ROUND_HALF_UP)) if line.bars_per_bundle > 0 else 0

    @api.depends("weight_kg", "official_unit_price", "price_adjustment")
    def _compute_official_subtotal(self):
        for line in self:
            unit_price = line.official_unit_price + line.price_adjustment
            line.official_subtotal = line.weight_kg * unit_price if unit_price > 0 else 0

    @api.constrains("product_type", "total_bar_qty", "requested_weight_kg", "coil_cut_qty", "weight_kg")
    def _check_positive_quantity(self):
        for line in self:
            if line.product_type == "bar" and line.total_bar_qty <= 0:
                raise ValidationError("Tổng số cây phải lớn hơn 0 đối với thép cây.")
            if line.product_type == "coil" and line.requested_weight_kg <= 0:
                raise ValidationError("Khối lượng kg phải lớn hơn 0 đối với thép cuộn.")
            if line.product_type == "coil" and line.coil_cut_qty <= 0:
                raise ValidationError("Số cuộn cần cắt phải lớn hơn 0 đối với thép cuộn.")
            if line.weight_kg <= 0:
                raise ValidationError("Chưa tính được khối lượng sản phẩm; vui lòng kiểm tra barem hoặc số kg.")

    @api.constrains("product_id")
    def _check_product_group(self):
        for line in self:
            if line.product_id and line.product_id.ma_nh_vt != "THEPCANDAI":
                raise ValidationError("Chỉ được chọn sản phẩm thuộc nhóm THEPCANDAI.")
