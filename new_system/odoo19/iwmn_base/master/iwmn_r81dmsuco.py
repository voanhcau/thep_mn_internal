from odoo import fields, models


class iwmn_r81dmsuco(models.Model):
    _inherit = "iwmn.r81dmsuco"
    _rec_name = "ten_su_co"
    _order = "ten_su_co, id"

    ma_su_co = fields.Char(
        string="Ma_Su_Co",
        required=True,
        index=True,
        size=20,
    )

    ten_su_co = fields.Char(
        string="Ten_Su_Co",
        required=True,
        size=1000,
    )

    loai_su_co = fields.Char(
        string="Loai_Su_Co",
        required=True,
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

    ma_dvcs = fields.Char(
        string="Ma_DvCs",
        required=True,
        index=True,
        size=5,
    )
