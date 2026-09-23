from odoo import fields, models


class iwmn_r81laisuat(models.Model):
    _inherit = "iwmn.r81laisuat"
    _rec_name = "ident00"
    _order = "ident00, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
    )

    lai_suat = fields.Float(
        string="Lai_Suat",
        digits=(19, 4),
    )
