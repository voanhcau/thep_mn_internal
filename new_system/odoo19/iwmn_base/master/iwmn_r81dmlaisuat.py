from odoo import fields, models


class iwmn_r81dmlaisuat(models.Model):
    _inherit = "iwmn.r81dmlaisuat"
    _rec_name = "so_ngay_ck_thang"
    _order = "so_ngay_ck_thang, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    lai_suat = fields.Float(
        string="Lai_Suat",
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

    thang = fields.Integer(
        string="Thang",
        required=True,
    )

    nam = fields.Integer(
        string="Nam",
        required=True,
    )

    so_ngay_ck_thang = fields.Integer(
        string="So_Ngay_Ck_Thang",
        required=True,
    )

    gia_ck_thang = fields.Integer(
        string="Gia_Ck_Thang",
        required=True,
    )
