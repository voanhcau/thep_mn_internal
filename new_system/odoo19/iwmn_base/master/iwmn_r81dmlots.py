from odoo import fields, models


class iwmn_r81dmlots(models.Model):
    _inherit = "iwmn.r81dmlots"
    _rec_name = "lot_name"
    _order = "lot_name, id"

    lot_id = fields.Char(
        string="Lot_ID",
        required=True,
        size=20,
    )

    lot_name = fields.Char(
        string="Lot_Name",
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
