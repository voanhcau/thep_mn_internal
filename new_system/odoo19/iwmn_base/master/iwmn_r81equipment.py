from odoo import fields, models


class iwmn_r81equipment(models.Model):
    _inherit = "iwmn.r81equipment"
    _rec_name = "host_ip"
    _order = "host_ip, id"

    host_ip = fields.Char(
        string="Host_IP",
        required=True,
        size=20,
    )

    host_name = fields.Char(
        string="Host_Name",
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

    loai_can = fields.Char(
        string="Loai_Can",
        required=True,
        size=10,
    )
