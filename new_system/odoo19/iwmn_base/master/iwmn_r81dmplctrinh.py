from odoo import fields, models


class iwmn_r81dmplctrinh(models.Model):
    _inherit = "iwmn.r81dmplctrinh"
    _rec_name = "ten_plctrinh"
    _order = "ten_plctrinh, id"

    ma_plctrinh = fields.Char(
        string="Ma_PLCTrinh",
        required=True,
        index=True,
        size=20,
    )

    ma_ctrinh = fields.Char(
        string="Ma_CTrinh",
        required=True,
        index=True,
        size=20,
    )

    ten_plctrinh = fields.Char(
        string="Ten_PLCTrinh",
        required=True,
        size=200,
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
