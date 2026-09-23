from odoo import fields, models


class iwmn_r81dmstandard(models.Model):
    _inherit = "iwmn.r81dmstandard"
    _rec_name = "standard_name"
    _order = "standard_name, id"

    standard_id = fields.Char(
        string="Standard_ID",
        required=True,
        index=True,
        size=20,
    )

    standard_name = fields.Char(
        string="Standard_Name",
        required=True,
        size=100,
    )

    used = fields.Boolean(
        string="Used",
        required=True,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )
