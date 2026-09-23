from odoo import fields, models


class iwmn_r81ngaylecty_ct(models.Model):
    _inherit = "iwmn.r81ngaylecty_ct"
    _rec_name = "ma_bp_list_lam"
    _order = "ma_bp_list_lam, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ngay_cham_cong = fields.Datetime(
        string="Ngay_Cham_Cong",
        required=True,
    )

    ma_bp_list_lam = fields.Char(
        string="Ma_Bp_List_Lam",
        required=True,
        index=True,
        size=500,
    )

    kip = fields.Char(
        string="Kip",
        size=1,
    )
