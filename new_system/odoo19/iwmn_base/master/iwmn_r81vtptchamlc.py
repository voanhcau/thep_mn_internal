from odoo import fields, models


class iwmn_r81vtptchamlc(models.Model):
    _inherit = "iwmn.r81vtptchamlc"
    _rec_name = "ten_cbnv"
    _order = "ten_cbnv, id"

    ma_vt = fields.Char(
        string="Ma_Vt",
        index=True,
        size=255,
    )

    so_luong = fields.Float(
        string="So_Luong",
    )

    ngay_nk = fields.Datetime(
        string="Ngay_NK",
    )

    ten_cbnv = fields.Char(
        string="Ten_CBNV",
        size=255,
    )

    muc_dich = fields.Char(
        string="Muc_Dich",
        size=255,
    )

    is_clc = fields.Boolean(
        string="Is_CLC",
        required=True,
    )

    ma_kho = fields.Char(
        string="Ma_Kho",
        index=True,
        size=20,
    )

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
        required=True,
    )
