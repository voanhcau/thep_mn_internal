from odoo import fields, models


class iwmn_r81dmttccong(models.Model):
    _inherit = "iwmn.r81dmttccong"
    _rec_name = "ten_cc"
    _order = "ten_cc, id"

    ma_cc = fields.Char(
        string="Ma_CC",
        required=True,
        index=True,
        size=20,
    )

    ten_cc = fields.Char(
        string="Ten_CC",
        required=True,
        size=500,
    )

    an_sang = fields.Float(
        string="An_Sang",
        required=True,
        digits=(19, 4),
    )

    an_trua = fields.Float(
        string="An_Trua",
        required=True,
        digits=(19, 4),
    )

    an_chieu = fields.Float(
        string="An_Chieu",
        required=True,
        digits=(19, 4),
    )

    an_khuya = fields.Float(
        string="An_Khuya",
        required=True,
        digits=(19, 4),
    )

    an_sang_sau = fields.Float(
        string="An_Sang_Sau",
        required=True,
        digits=(19, 4),
    )

    create_log = fields.Char(
        string="Create_Log",
        size=20,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=20,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=5,
    )

    an_khuya_sau = fields.Float(
        string="An_Khuya_Sau",
        required=True,
        digits=(19, 4),
    )
