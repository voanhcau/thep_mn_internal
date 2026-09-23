from odoo import fields, models


class iwmn_r81dmcant(models.Model):
    _inherit = "iwmn.r81dmcant"
    _rec_name = "ma_ca"
    _order = "ma_ca, id"

    ma_ca = fields.Char(
        string="Ma_Ca",
        required=True,
        index=True,
        size=20,
    )

    ky_hieu = fields.Char(
        string="Ky_Hieu",
        required=True,
        size=5,
    )

    gio_bd = fields.Char(
        string="Gio_BD",
        required=True,
        size=16,
    )

    gio_kt = fields.Char(
        string="Gio_KT",
        required=True,
        size=16,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=5,
    )

    loai = fields.Char(
        string="Loai",
        required=True,
        size=2,
    )
