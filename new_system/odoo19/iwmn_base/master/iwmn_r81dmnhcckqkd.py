from odoo import fields, models


class iwmn_r81dmnhcckqkd(models.Model):
    _inherit = "iwmn.r81dmnhcckqkd"
    _rec_name = "ten_nh_cc"
    _order = "ten_nh_cc, id"

    ma_nh_cc = fields.Char(
        string="Ma_Nh_CC",
        required=True,
        index=True,
        size=20,
    )

    ten_nh_cc = fields.Char(
        string="Ten_Nh_CC",
        required=True,
        size=200,
    )

    ma_nh_cc_parent = fields.Char(
        string="Ma_Nh_CC_Parent",
        index=True,
        size=20,
    )

    nh_cuoi = fields.Boolean(
        string="Nh_Cuoi",
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
