from odoo import fields, models


class iwmn_r81dmvttt(models.Model):
    _inherit = "iwmn.r81dmvttt"
    _rec_name = "ma_nh_tt"
    _order = "ma_nh_tt, id"

    ma_nh_tt = fields.Char(
        string="Ma_Nh_Tt",
        required=True,
        index=True,
        size=20,
    )

    ma_vt_list = fields.Char(
        string="Ma_Vt_List",
        required=True,
        index=True,
        size=1000,
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
        index=True,
        size=5,
    )
