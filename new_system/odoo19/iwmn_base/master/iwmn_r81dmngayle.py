from odoo import fields, models


class iwmn_r81dmngayle(models.Model):
    _inherit = "iwmn.r81dmngayle"
    _rec_name = "ma_dt"
    _order = "ma_dt, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ngay_ct1 = fields.Datetime(
        string="Ngay_Ct1",
    )

    ngay_ct2 = fields.Datetime(
        string="Ngay_Ct2",
    )

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        size=200,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    nam = fields.Integer(
        string="Nam",
        required=True,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        index=True,
        size=20,
    )

    tk = fields.Char(
        string="Tk",
        index=True,
        size=20,
    )
