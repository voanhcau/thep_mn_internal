from odoo import fields, models


class iwmn_r81dmcl(models.Model):
    _inherit = "iwmn.r81dmcl"
    _rec_name = "ten_cl"
    _order = "ten_cl, id"

    ma_cl = fields.Char(
        string="Ma_CL",
        required=True,
        index=True,
        size=20,
    )

    ten_cl = fields.Char(
        string="Ten_CL",
        required=True,
        size=100,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=3,
    )
