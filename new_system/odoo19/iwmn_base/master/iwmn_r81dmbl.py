from odoo import fields, models


class iwmn_r81dmbl(models.Model):
    _inherit = "iwmn.r81dmbl"
    _rec_name = "so_bl"
    _order = "so_bl, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        required=True,
        index=True,
        size=20,
    )

    ma_hd = fields.Char(
        string="Ma_HD",
        index=True,
        size=50,
    )

    so_bl = fields.Char(
        string="So_BL",
        required=True,
        size=50,
    )

    tien_bao_lanh = fields.Float(
        string="Tien_Bao_Lanh",
        required=True,
        digits=(19, 4),
    )

    ngay_bd_bl = fields.Date(
        string="Ngay_BD_BL",
        required=True,
    )

    ngay_kt_bl = fields.Date(
        string="Ngay_KT_BL",
        required=True,
    )

    ma_dt_bl = fields.Char(
        string="Ma_Dt_BL",
        required=True,
        index=True,
        size=20,
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

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        required=True,
        size=100,
    )

    lock = fields.Boolean(
        string="Lock",
        required=True,
    )

    user_lock = fields.Char(
        string="User_Lock",
        size=50,
    )

    ghi_chu_lock = fields.Char(
        string="Ghi_Chu_Lock",
        size=100,
    )

    tien_bao_lanh_nt = fields.Float(
        string="Tien_Bao_Lanh_Nt",
        required=True,
        digits=(19, 4),
    )

    ngay_begin = fields.Date(
        string="Ngay_Begin",
        required=True,
    )

    ngay_end = fields.Date(
        string="Ngay_End",
        required=True,
    )

    so_bl_goc = fields.Char(
        string="So_BL_Goc",
        required=True,
        size=50,
    )

    note = fields.Char(
        string="Note",
        size=200,
    )

    ma_tte = fields.Char(
        string="Ma_Tte",
        required=True,
        index=True,
        size=5,
    )

    ty_gia = fields.Float(
        string="Ty_Gia",
        required=True,
        digits=(19, 4),
    )

    ngay_ph = fields.Datetime(
        string="Ngay_Ph",
        required=True,
    )
