from odoo import fields, models


class iwmn_r81dmctauto(models.Model):
    _inherit = "iwmn.r81dmctauto"
    _rec_name = "description"
    _order = "description, id"

    ma_ct = fields.Char(
        string="Ma_Ct",
        required=True,
        index=True,
        size=5,
    )

    description = fields.Char(
        string="Description",
        required=True,
        size=200,
    )

    so_xe = fields.Char(
        string="So_Xe",
        required=True,
        size=20,
    )

    so_xa_lan_tau = fields.Char(
        string="So_Xa_Lan_Tau",
        size=20,
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        required=True,
        index=True,
        size=20,
    )

    ma_vt_sp = fields.Char(
        string="Ma_Vt_Sp",
        required=True,
        index=True,
        size=20,
    )

    dien_giai = fields.Char(
        string="Dien_Giai",
        required=True,
        size=200,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )
