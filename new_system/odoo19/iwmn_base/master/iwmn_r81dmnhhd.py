from odoo import fields, models


class iwmn_r81dmnhhd(models.Model):
    _inherit = "iwmn.r81dmnhhd"
    _rec_name = "ten_nh_hd"
    _order = "ten_nh_hd, id"

    ma_nh_hd = fields.Char(
        string="Ma_Nh_Hd",
        required=True,
        index=True,
        size=20,
    )

    ten_nh_hd = fields.Char(
        string="Ten_Nh_Hd",
        required=True,
        size=100,
    )

    ma_nh_hd_parent = fields.Char(
        string="Ma_Nh_Hd_Parent",
        index=True,
        size=20,
    )

    nh_cuoi = fields.Char(
        string="Nh_Cuoi",
        required=True,
        size=1,
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
