from odoo import fields, models


class iwmn_r81dmngachluong(models.Model):
    _inherit = "iwmn.r81dmngachluong"
    _rec_name = "ten_bac"
    _order = "ten_bac, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_vtri_nv = fields.Char(
        string="Ma_Vtri_NV",
        index=True,
        size=20,
    )

    chuc_danh = fields.Char(
        string="Chuc_Danh",
        size=200,
    )

    ten_bac = fields.Char(
        string="Ten_Bac",
        size=20,
    )

    bac_luong = fields.Char(
        string="Bac_Luong",
        size=20,
    )

    bang_luong = fields.Char(
        string="Bang_Luong",
        size=20,
    )

    muc_luong = fields.Float(
        string="Muc_Luong",
        digits=(19, 4),
    )

    ma_data = fields.Char(
        string="Ma_Data",
        index=True,
        size=5,
    )

    diem_vtri_nv = fields.Float(
        string="Diem_VTri_NV",
        required=True,
        digits=(19, 4),
    )

    ngay_begin = fields.Datetime(
        string="Ngay_Begin",
        required=True,
    )

    ngay_end = fields.Datetime(
        string="Ngay_End",
        required=True,
    )

    loai_ngach = fields.Char(
        string="Loai_Ngach",
        size=5,
    )
