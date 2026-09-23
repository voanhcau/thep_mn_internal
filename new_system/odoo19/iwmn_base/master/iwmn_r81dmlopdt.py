from odoo import fields, models


class iwmn_r81dmlopdt(models.Model):
    _inherit = "iwmn.r81dmlopdt"
    _rec_name = "ma_lopdt"
    _order = "ma_lopdt, id"

    ma_lopdt = fields.Char(
        string="Ma_LopDT",
        required=True,
        index=True,
        size=20,
    )

    ma_nh_lopdt = fields.Char(
        string="Ma_Nh_LopDT",
        required=True,
        index=True,
        size=20,
    )

    noi_dung = fields.Char(
        string="Noi_Dung",
        required=True,
        size=200,
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        index=True,
        size=20,
    )

    ngay_bd = fields.Datetime(
        string="Ngay_BD",
        required=True,
    )

    ngay_kt = fields.Datetime(
        string="Ngay_KT",
        required=True,
    )

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        size=200,
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

    tien = fields.Float(
        string="Tien",
        required=True,
        digits=(19, 4),
    )

    giang_vien = fields.Char(
        string="Giang_Vien",
        size=200,
    )
