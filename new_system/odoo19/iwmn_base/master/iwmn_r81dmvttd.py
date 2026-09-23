from odoo import fields, models


class iwmn_r81dmvttd(models.Model):
    _inherit = "iwmn.r81dmvttd"
    _rec_name = "ten_vt_td"
    _order = "ten_vt_td, id"

    ma_vt_td = fields.Char(
        string="Ma_Vt_TD",
        required=True,
        index=True,
        size=20,
    )

    ten_vt_td = fields.Char(
        string="Ten_Vt_Td",
        required=True,
        size=1000,
    )

    ma_vt_list = fields.Char(
        string="Ma_Vt_List",
        required=True,
        index=True,
        size=500,
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
