from odoo import fields, models


class iwmn_r81dmkhoct(models.Model):
    _inherit = "iwmn.r81dmkhoct"
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

    ma_dt = fields.Char(
        string="Ma_Dt",
        required=True,
        index=True,
        size=20,
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
        required=True,
    )

    sl_dm_kg = fields.Float(
        string="Sl_Dm_Kg",
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

    ma_data = fields.Char(
        string="Ma_Data",
        index=True,
        size=5,
    )
