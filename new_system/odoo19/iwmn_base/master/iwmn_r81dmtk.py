from odoo import fields, models


class iwmn_r81dmtk(models.Model):
    _inherit = "iwmn.r81dmtk"
    _rec_name = "ten_tk"
    _order = "ten_tk, id"

    tk = fields.Char(
        string="Tk",
        required=True,
        index=True,
        size=10,
    )

    ten_tk = fields.Char(
        string="Ten_Tk",
        required=True,
        size=100,
    )

    ten_tke = fields.Char(
        string="Ten_TkE",
        size=100,
    )

    tk_parent = fields.Char(
        string="Tk_Parent",
        size=10,
    )

    tk_cuoi = fields.Boolean(
        string="Tk_Cuoi",
        required=True,
    )

    tk_sp = fields.Boolean(
        string="Tk_Sp",
        required=True,
    )

    tk_dt = fields.Boolean(
        string="Tk_Dt",
        required=True,
    )

    tk_km = fields.Boolean(
        string="Tk_Km",
        required=True,
    )

    so_tk_nh = fields.Char(
        string="So_Tk_Nh",
        size=20,
    )

    ten_tk_nh = fields.Char(
        string="Ten_Tk_Nh",
        size=100,
    )

    ten_tp_nh = fields.Char(
        string="Ten_Tp_Nh",
        size=100,
    )

    ngay_begin = fields.Datetime(
        string="Ngay_Begin",
        required=True,
    )

    ngay_end = fields.Datetime(
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

    ma_tte_goc = fields.Char(
        string="Ma_Tte_Goc",
        required=True,
        index=True,
        size=5,
    )

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ten_tkc = fields.Char(
        string="Ten_TkC",
        size=100,
    )

    ky_hieu_mau = fields.Char(
        string="Ky_Hieu_Mau",
        size=20,
    )

    ma_tap_doan = fields.Char(
        string="Ma_Tap_Doan",
        index=True,
        size=20,
    )
