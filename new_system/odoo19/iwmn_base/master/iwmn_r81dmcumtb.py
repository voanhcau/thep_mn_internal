from odoo import fields, models


class iwmn_r81dmcumtb(models.Model):
    _inherit = "iwmn.r81dmcumtb"
    _rec_name = "ten_cum"
    _order = "ten_cum, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_cum = fields.Char(
        string="Ma_Cum",
        required=True,
        index=True,
        size=20,
    )

    ten_cum = fields.Char(
        string="Ten_Cum",
        size=200,
    )

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        size=100,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )

    nhom = fields.Char(
        string="Nhom",
        size=100,
    )
