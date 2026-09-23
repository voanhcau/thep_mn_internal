from odoo import fields, models


class iwmn_r81dmctrinh(models.Model):
    _inherit = "iwmn.r81dmctrinh"
    _rec_name = "ten_ctrinh"
    _order = "ten_ctrinh, id"

    ma_ctrinh = fields.Char(
        string="Ma_CTrinh",
        size=20,
        required=True,
        index=True,
    )
    ten_ctrinh = fields.Char(
        string="Ten_CTrinh",
        size=200,
        required=True,
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
        size=3,
        required=True,
        index=True,
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
    ma_kv = fields.Char(
        string="Ma_Kv",
        size=20,
        index=True,
    )
    ma_ctrinh_parent = fields.Char(
        string="Ma_Ctrinh_Parent",
        size=20,
        index=True,
    )
    nh_cuoi = fields.Boolean(
        string="Nh_Cuoi",
        required=True,
    )
