from odoo import fields, models


class iwmn_r81dmxervc(models.Model):
    _inherit = "iwmn.r81dmxervc"
    _rec_name = "ten_tx"
    _order = "ten_tx, id"

    so_xe = fields.Char(
        string="So_Xe",
        required=True,
        size=20,
    )

    id_cm = fields.Char(
        string="ID_CM",
        required=True,
        size=50,
    )

    id_bl = fields.Char(
        string="ID_BL",
        required=True,
        size=50,
    )

    ten_tx = fields.Char(
        string="Ten_Tx",
        required=True,
        size=100,
    )

    tai_trong = fields.Float(
        string="Tai_Trong",
        required=True,
        digits=(19, 4),
    )
