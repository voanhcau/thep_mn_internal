from odoo import fields, models


class iwmn_r81dmcksl(models.Model):
    _inherit = "iwmn.r81dmcksl"
    _rec_name = "so_qd_gia"
    _order = "so_qd_gia, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    tu_sl = fields.Float(
        string="Tu_Sl",
        digits=(19, 4),
    )

    den_sl = fields.Float(
        string="Den_Sl",
        digits=(19, 4),
    )

    gia = fields.Float(
        string="Gia",
        digits=(19, 4),
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
    )

    ma_dt_list = fields.Char(
        string="Ma_Dt_List",
        index=True,
        size=100,
    )

    so_qd_gia = fields.Char(
        string="So_Qd_Gia",
        size=20,
    )

    ngay_kthuc = fields.Datetime(
        string="Ngay_KThuc",
        required=True,
    )
