from odoo import fields, models


class iwmn_r81dmcanchuan(models.Model):
    _inherit = "iwmn.r81dmcanchuan"
    _rec_name = "so_luong"
    _order = "so_luong, id"

    loai_sp = fields.Char(
        string="Loai_Sp",
        required=True,
        size=20,
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
        required=True,
    )

    so_luong = fields.Float(
        string="So_Luong",
        required=True,
        digits=(19, 4),
    )
