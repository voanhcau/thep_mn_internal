from odoo import fields, models


class iwmn_r81dmcotinh(models.Model):
    _inherit = "iwmn.r81dmcotinh"
    _rec_name = "description"
    _order = "description, id"

    ma_co_tinh = fields.Char(
        string="Ma_Co_Tinh",
        required=True,
        index=True,
        size=20,
    )

    description = fields.Char(
        string="Description",
        size=200,
    )

    grade_id = fields.Char(
        string="Grade_ID",
        required=True,
        index=True,
        size=20,
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

    yeildp_min = fields.Float(
        string="YeildP_Min",
        required=True,
        digits=(19, 4),
    )

    yeildp_max = fields.Float(
        string="YeildP_Max",
        required=True,
        digits=(19, 4),
    )

    yeildh_min = fields.Float(
        string="YeildH_Min",
        required=True,
        digits=(19, 4),
    )

    yeildh_max = fields.Float(
        string="YeildH_Max",
        required=True,
        digits=(19, 4),
    )

    yeild24h_min = fields.Float(
        string="Yeild24H_Min",
        required=True,
        digits=(19, 4),
    )

    yeild24h_max = fields.Float(
        string="Yeild24H_Max",
        required=True,
        digits=(19, 4),
    )

    tensionp_min = fields.Float(
        string="TensionP_Min",
        required=True,
        digits=(19, 4),
    )

    tensionp_max = fields.Float(
        string="TensionP_Max",
        required=True,
        digits=(19, 4),
    )

    tensionh_min = fields.Float(
        string="TensionH_Min",
        required=True,
        digits=(19, 4),
    )

    tensionh_max = fields.Float(
        string="TensionH_Max",
        required=True,
        digits=(19, 4),
    )

    tension24h_min = fields.Float(
        string="Tension24H_Min",
        required=True,
        digits=(19, 4),
    )

    tension24h_max = fields.Float(
        string="Tension24H_Max",
        required=True,
        digits=(19, 4),
    )

    elong_min = fields.Float(
        string="Elong_Min",
        required=True,
        digits=(19, 4),
    )

    elong_max = fields.Float(
        string="Elong_Max",
        required=True,
        digits=(19, 4),
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
