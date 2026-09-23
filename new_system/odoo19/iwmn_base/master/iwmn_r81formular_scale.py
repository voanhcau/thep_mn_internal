from odoo import fields, models


class iwmn_r81formular_scale(models.Model):
    _inherit = "iwmn.r81formular_scale"
    _rec_name = "description"
    _order = "description, id"

    formular_id = fields.Char(
        string="Formular_ID",
        required=True,
        size=50,
    )

    description = fields.Char(
        string="Description",
        required=True,
        size=200,
    )

    condition = fields.Char(
        string="Condition",
        required=True,
        size=100,
    )

    formular = fields.Char(
        string="Formular",
        required=True,
        size=200,
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
