from odoo import fields, models


class iwmn_r81dmloaihang(models.Model):
    _inherit = "iwmn.r81dmloaihang"
    _rec_name = "ten_loai_hang"
    _order = "ten_loai_hang, id"

    ma_loai_hang = fields.Char(
        string="Ma_Loai_Hang",
        required=True,
        index=True,
        size=50,
    )

    ten_loai_hang = fields.Char(
        string="Ten_Loai_Hang",
        required=True,
        size=300,
    )

    quy_cach = fields.Char(
        string="Quy_Cach",
        size=300,
    )

    ma_dvcs = fields.Char(
        string="Ma_Dvcs",
        required=True,
        index=True,
        size=10,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )

    giah2_nhat = fields.Float(
        string="GiaH2_Nhat",
        required=True,
        digits=(19, 4),
    )

    giah2_my = fields.Float(
        string="GiaH2_My",
        required=True,
        digits=(19, 4),
    )

    giah2_namphi = fields.Float(
        string="GiaH2_NamPhi",
        required=True,
        digits=(19, 4),
    )

    giah2_uc = fields.Float(
        string="GiaH2_Uc",
        required=True,
        digits=(19, 4),
    )

    giah2_kored = fields.Float(
        string="GiaH2_Kored",
        required=True,
        digits=(19, 4),
    )
