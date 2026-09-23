from odoo import fields, models


class iwmn_r81dmdinhmucnl(models.Model):
    _inherit = "iwmn.r81dmdinhmucnl"
    _rec_name = "ma_nh_vt"
    _order = "ma_nh_vt, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_nh_vt = fields.Char(
        string="Ma_Nh_Vt",
        required=True,
        index=True,
        size=20,
    )

    mac_thep = fields.Char(
        string="Mac_Thep",
        size=50,
    )

    dinh_muc = fields.Float(
        string="Dinh_Muc",
        required=True,
        digits=(19, 4),
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )

    grade_id = fields.Char(
        string="Grade_ID",
        index=True,
        size=20,
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
        required=True,
    )
