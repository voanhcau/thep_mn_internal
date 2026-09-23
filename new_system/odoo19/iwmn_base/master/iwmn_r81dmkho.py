from odoo import fields, models


class iwmn_r81dmkho(models.Model):
    _inherit = "iwmn.r81dmkho"
    _rec_name = "ten_kho"
    _order = "ten_kho, id"

    ma_kho = fields.Char(
        string="Ma_Kho",
        required=True,
        index=True,
        size=20,
    )

    ten_kho = fields.Char(
        string="Ten_Kho",
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

    stt = fields.Integer(
        string="Stt",
        required=True,
    )

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    tk_vtu = fields.Char(
        string="Tk_Vtu",
        size=20,
    )

    is_ketoan = fields.Boolean(
        string="Is_Ketoan",
        required=True,
    )

    tk_gvon = fields.Char(
        string="Tk_GVon",
        size=20,
    )

    dia_chi = fields.Char(
        string="Dia_Chi",
        size=100,
    )

    ten_thu_kho = fields.Char(
        string="Ten_Thu_Kho",
        size=100,
    )

    ten_ct_giao = fields.Char(
        string="Ten_Ct_Giao",
        size=100,
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        index=True,
        size=20,
    )

    sl_dm_kg = fields.Float(
        string="Sl_Dm_Kg",
        required=True,
        digits=(19, 4),
    )

    han_hd = fields.Integer(
        string="Han_HD",
        required=True,
    )

    note = fields.Char(
        string="Note",
        size=200,
    )

    ma_nh_kg = fields.Char(
        string="Ma_Nh_Kg",
        index=True,
        size=20,
    )
