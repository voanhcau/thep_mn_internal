from odoo import fields, models


class iwmn_r81dmthue(models.Model):
    _inherit = "iwmn.r81dmthue"
    _rec_name = "ten_thue"
    _order = "ten_thue, id"

    ma_thue = fields.Char(
        string="Ma_Thue",
        required=True,
        index=True,
        size=20,
    )

    ten_thue = fields.Char(
        string="Ten_Thue",
        required=True,
        size=100,
    )

    thue_suat = fields.Integer(
        string="Thue_Suat",
        required=True,
    )

    loai_thue = fields.Char(
        string="Loai_Thue",
        required=True,
        size=1,
    )

    tk = fields.Char(
        string="Tk",
        required=True,
        index=True,
        size=10,
    )

    phan_loai_thue = fields.Char(
        string="Phan_Loai_Thue",
        size=20,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
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

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )
