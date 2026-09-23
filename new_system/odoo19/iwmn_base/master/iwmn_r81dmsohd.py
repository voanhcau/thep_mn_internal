from odoo import fields, models


class iwmn_r81dmsohd(models.Model):
    _inherit = "iwmn.r81dmsohd"
    _rec_name = "so_ct"
    _order = "so_ct, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ngay_ct = fields.Datetime(
        string="Ngay_Ct",
    )

    so_ct = fields.Char(
        string="So_Ct",
        size=20,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )
