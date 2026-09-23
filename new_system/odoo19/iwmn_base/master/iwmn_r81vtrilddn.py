from odoo import fields, models


class iwmn_r81vtrilddn(models.Model):
    _inherit = "iwmn.r81vtrilddn"
    _rec_name = "ten_vtri"
    _order = "ten_vtri, id"

    ma_vi_tri = fields.Char(
        string="Ma_Vi_Tri",
        required=True,
        index=True,
        size=20,
    )

    loai_ct = fields.Char(
        string="Loai_Ct",
        required=True,
        size=10,
    )

    ten_vtri = fields.Char(
        string="Ten_Vtri",
        required=True,
        size=200,
    )

    vi_tri_ld = fields.Char(
        string="Vi_Tri_Ld",
        required=True,
        size=200,
    )

    so_seri = fields.Char(
        string="So_Seri",
        required=True,
        size=200,
    )

    ma_bp = fields.Char(
        string="Ma_Bp",
        required=True,
        index=True,
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

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=5,
    )
