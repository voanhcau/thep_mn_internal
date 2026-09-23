from odoo import fields, models


class iwmn_r81dmme(models.Model):
    _inherit = "iwmn.r81dmme"
    _rec_name = "ident00"
    _order = "ident00, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    nam = fields.Integer(
        string="Nam",
    )

    me = fields.Char(
        string="Me",
        size=10,
    )
