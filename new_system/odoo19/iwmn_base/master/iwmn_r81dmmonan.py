from odoo import fields, models


class iwmn_r81dmmonan(models.Model):
    _inherit = "iwmn.r81dmmonan"
    _rec_name = "ten_man"
    _order = "ten_man, id"

    ma_man = fields.Char(
        string="Ma_MAn",
        required=True,
        index=True,
        size=20,
    )

    ten_man = fields.Char(
        string="Ten_MAn",
        required=True,
        size=100,
    )

    ma_man_parent = fields.Char(
        string="Ma_MAn_Parent",
        index=True,
        size=20,
    )

    nh_cuoi = fields.Boolean(
        string="Nh_Cuoi",
        required=True,
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
        size=50,
    )
