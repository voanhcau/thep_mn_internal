from odoo import fields, models


class iwmn_r81dmqdcan(models.Model):
    _inherit = "iwmn.r81dmqdcan"
    _rec_name = "ident00"
    _order = "ident00, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    loai_thep = fields.Char(
        string="Loai_Thep",
        required=True,
        size=20,
    )

    duong_kinh = fields.Char(
        string="Duong_Kinh",
        required=True,
        size=20,
    )

    tieu_hao_gas = fields.Float(
        string="Tieu_Hao_Gas",
        required=True,
        digits=(19, 4),
    )

    tieu_hao_dien = fields.Float(
        string="Tieu_Hao_Dien",
        required=True,
        digits=(19, 4),
    )

    tieu_hao_phoi = fields.Float(
        string="Tieu_Hao_Phoi",
        required=True,
        digits=(19, 4),
    )

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        size=300,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
        required=True,
    )
