from odoo import fields, models


class iwmn_r81dmnhlopdt(models.Model):
    _inherit = "iwmn.r81dmnhlopdt"
    _rec_name = "ten_nh_lopdt"
    _order = "ten_nh_lopdt, id"

    ma_nh_lopdt = fields.Char(
        string="Ma_Nh_LopDT",
        required=True,
        index=True,
        size=20,
    )

    ten_nh_lopdt = fields.Char(
        string="Ten_Nh_LopDT",
        required=True,
        size=200,
    )

    ngay_begin = fields.Datetime(
        string="Ngay_Begin",
        required=True,
    )

    ngay_end = fields.Datetime(
        string="Ngay_End",
        required=True,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=5,
    )

    ma_nh_lopdt_parent = fields.Char(
        string="Ma_Nh_LopDT_Parent",
        index=True,
        size=20,
    )

    nh_cuoi = fields.Boolean(
        string="Nh_Cuoi",
        required=True,
    )
