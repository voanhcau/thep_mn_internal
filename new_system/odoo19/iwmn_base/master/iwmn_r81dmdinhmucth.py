from odoo import fields, models


class iwmn_r81dmdinhmucth(models.Model):
    _inherit = "iwmn.r81dmdinhmucth"
    _rec_name = "ten_chi_tieu"
    _order = "ten_chi_tieu, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_chi_tieu = fields.Char(
        string="Ma_Chi_Tieu",
        index=True,
        size=20,
    )

    ten_chi_tieu = fields.Char(
        string="Ten_Chi_Tieu",
        size=100,
    )

    dvt = fields.Char(
        string="Dvt",
        size=50,
    )

    dinh_muc = fields.Float(
        string="Dinh_Muc",
        digits=(19, 4),
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        index=True,
        size=5,
    )
