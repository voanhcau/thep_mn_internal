from odoo import fields, models


class iwmn_r81hschayhao(models.Model):
    _inherit = "iwmn.r81hschayhao"
    _rec_name = "ma_size"
    _order = "ma_size, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_size = fields.Char(
        string="Ma_Size",
        index=True,
        size=20,
    )

    loai_nap = fields.Char(
        string="Loai_Nap",
        size=20,
    )

    he_so = fields.Float(
        string="He_So",
        digits=(19, 4),
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
    )

    ma_dvcs = fields.Char(
        string="Ma_DvCs",
        index=True,
        size=5,
    )
