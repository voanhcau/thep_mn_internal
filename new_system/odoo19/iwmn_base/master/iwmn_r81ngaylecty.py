from odoo import fields, models


class iwmn_r81ngaylecty(models.Model):
    _inherit = "iwmn.r81ngaylecty"
    _rec_name = "ma_data"
    _order = "ma_data, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    tu_ngay = fields.Datetime(
        string="Tu_Ngay",
        required=True,
    )

    den_ngay = fields.Datetime(
        string="Den_Ngay",
        required=True,
    )

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        required=True,
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
        index=True,
        size=5,
    )

    loai = fields.Char(
        string="Loai",
        required=True,
        size=5,
    )
