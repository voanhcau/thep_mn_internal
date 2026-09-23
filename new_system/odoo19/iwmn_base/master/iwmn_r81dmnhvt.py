from odoo import fields, models


class iwmn_r81dmnhvt(models.Model):
    _inherit = "iwmn.r81dmnhvt"
    _rec_name = "ten_nh_vt"
    _order = "ten_nh_vt, id"

    ma_nh_vt = fields.Char(
        string="Ma_Nh_Vt",
        required=True,
        index=True,
        size=20,
    )

    ten_nh_vt = fields.Char(
        string="Ten_Nh_Vt",
        required=True,
        size=100,
    )

    ma_nh_vt_parent = fields.Char(
        string="Ma_Nh_Vt_Parent",
        index=True,
        size=20,
    )

    nh_cuoi = fields.Char(
        string="Nh_Cuoi",
        required=True,
        size=1,
    )

    loai_nh_vt = fields.Char(
        string="Loai_Nh_Vt",
        required=True,
        size=3,
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

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        size=100,
    )
