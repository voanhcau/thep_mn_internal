from odoo import fields, models


class iwmn_r81dmvtthtx(models.Model):
    _inherit = "iwmn.r81dmvtthtx"
    _rec_name = "so_luong_cbnv"
    _order = "so_luong_cbnv, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_vt = fields.Char(
        string="Ma_Vt",
        index=True,
        size=20,
    )

    ma_bp = fields.Char(
        string="Ma_Bp",
        index=True,
        size=20,
    )

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        size=200,
    )

    dinh_muc = fields.Float(
        string="Dinh_Muc",
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

    ngay_begin = fields.Datetime(
        string="Ngay_Begin",
    )

    ngay_end = fields.Datetime(
        string="Ngay_End",
    )

    ma_dvcs = fields.Char(
        string="Ma_DvCs",
        required=True,
        index=True,
        size=5,
    )

    so_luong_cbnv = fields.Float(
        string="So_Luong_CBNV",
        required=True,
        digits=(19, 4),
    )

    loai_th = fields.Char(
        string="Loai_Th",
        size=50,
    )
