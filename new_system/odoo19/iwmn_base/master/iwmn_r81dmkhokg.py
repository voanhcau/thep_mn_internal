from odoo import fields, models


class iwmn_r81dmkhokg(models.Model):
    _inherit = "iwmn.r81dmkhokg"
    _rec_name = "ma_kho"
    _order = "ma_kho, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_kho = fields.Char(
        string="Ma_Kho",
        required=True,
        index=True,
        size=20,
    )

    pt_vc = fields.Char(
        string="Pt_Vc",
        required=True,
        size=20,
    )

    han_hd = fields.Char(
        string="Han_HD",
        required=True,
        size=20,
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
        required=True,
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
        required=True,
        index=True,
        size=5,
    )
