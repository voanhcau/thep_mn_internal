from odoo import fields, models


class iwmn_r81dmkv(models.Model):
    _inherit = "iwmn.r81dmkv"
    _rec_name = "ten_kv"
    _order = "ten_kv, id"

    ma_kv = fields.Char(
        string="Ma_Kv",
        required=True,
        index=True,
        size=20,
    )

    ten_kv = fields.Char(
        string="Ten_Kv",
        required=True,
        size=100,
    )

    ngay_begin = fields.Date(
        string="Ngay_Begin",
        required=True,
    )

    ngay_end = fields.Date(
        string="Ngay_End",
        required=True,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=3,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_kv_parent = fields.Char(
        string="Ma_Kv_Parent",
        index=True,
        size=20,
    )
