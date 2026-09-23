from odoo import fields, models


class iwmn_r81baremphoi(models.Model):
    """Barem phoi migrated from legacy MSSQL table dbo.R81BAREMPHOI."""

    _inherit = "iwmn.r81baremphoi"
    _rec_name = "loai_phoi"
    _order = "ngay_ap desc, id desc"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi tương ứng trong bảng MSSQL dbo.R81BAREMPHOI.",
    )
    loai_phoi = fields.Char(
        string="Loại phôi",
        size=20,
        required=True,
    )
    ngay_ap = fields.Datetime(
        string="Ngày áp dụng",
        required=True,
    )
    barem = fields.Float(
        string="Barem",
        digits=(19, 4),
        required=True,
    )
