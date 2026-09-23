from odoo import fields, models


class iwmn_r81dmbpct(models.Model):
    _inherit = "iwmn.r81dmbpct"
    _rec_name = "ten_bp_ct"
    _order = "ten_bp_ct, id"

    ma_bp_ct = fields.Char(
        string="Ma_Bp_Ct",
        required=True,
        index=True,
        size=20,
    )

    ten_bp_ct = fields.Char(
        string="Ten_Bp_Ct",
        required=True,
        size=200,
    )

    ma_bp = fields.Char(
        string="Ma_Bp",
        index=True,
        size=20,
    )

    nh_cuoi = fields.Boolean(
        string="Nh_Cuoi",
        required=True,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=5,
    )

    loai_pbql = fields.Char(
        string="Loai_PBQL",
        size=2,
    )

    ma_bp_ct_cha = fields.Char(
        string="Ma_Bp_Ct_Cha",
        index=True,
        size=20,
    )

    ma_bp_luong = fields.Char(
        string="Ma_Bp_Luong",
        index=True,
        size=200,
    )

    is_cong = fields.Boolean(
        string="Is_Cong",
        required=True,
    )

    is_ca = fields.Boolean(
        string="Is_Ca",
        required=True,
    )

    ma_bp_luong_ca = fields.Char(
        string="Ma_Bp_Luong_Ca",
        index=True,
        size=100,
    )

    loai_cc = fields.Char(
        string="Loai_CC",
        size=3,
    )

    is_kt = fields.Boolean(
        string="Is_Kt",
        required=True,
    )
