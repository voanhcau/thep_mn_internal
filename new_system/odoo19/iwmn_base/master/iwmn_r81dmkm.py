from odoo import fields, models


class iwmn_r81dmkm(models.Model):
    _inherit = "iwmn.r81dmkm"
    _rec_name = "ten_km"
    _order = "ten_km, id"

    ma_km = fields.Char(
        string="Ma_Km",
        required=True,
        index=True,
        size=20,
    )

    ten_km = fields.Char(
        string="Ten_Km",
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

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_km_parent = fields.Char(
        string="Ma_Km_Parent",
        index=True,
        size=20,
    )

    nh_cuoi = fields.Char(
        string="Nh_Cuoi",
        required=True,
        size=1,
    )

    note = fields.Char(
        string="Note",
        size=1000,
    )
