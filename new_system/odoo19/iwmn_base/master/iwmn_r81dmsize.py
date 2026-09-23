from odoo import fields, models


class iwmn_r81dmsize(models.Model):
    _inherit = "iwmn.r81dmsize"
    _rec_name = "ten_size"
    _order = "ten_size, id"

    ma_size = fields.Char(
        string="Ma_Size",
        required=True,
        index=True,
        size=20,
    )

    ten_size = fields.Char(
        string="Ten_Size",
        required=True,
        size=100,
    )

    length = fields.Float(
        string="Length",
        required=True,
        digits=(19, 4),
    )

    diameter = fields.Float(
        string="Diameter",
        required=True,
        digits=(19, 4),
    )

    dmin = fields.Float(
        string="DMin",
        required=True,
        digits=(19, 4),
    )

    dmax = fields.Float(
        string="DMax",
        required=True,
        digits=(19, 4),
    )

    barweight_bk = fields.Char(
        string="BarWeight_Bk",
        required=True,
        size=50,
    )

    minweight = fields.Float(
        string="MinWeight",
        required=True,
        digits=(19, 4),
    )

    maxweight = fields.Float(
        string="MaxWeight",
        required=True,
        digits=(19, 4),
    )

    ngay_begin = fields.Date(
        string="Ngay_Begin",
        required=True,
    )

    ngay_end = fields.Date(
        string="Ngay_End",
        required=True,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=3,
    )
