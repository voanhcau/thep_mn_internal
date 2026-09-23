from odoo import fields, models


class iwmn_r81dmbanve(models.Model):
    """Drawing master data from legacy MSSQL table dbo.R81DMBANVE."""

    _inherit = "iwmn.r81dmbanve"
    _rec_name = "ma_banve"
    _order = "ma_banve, id"

    ma_banve = fields.Char(
        string="Mã bản vẽ",
        size=50,
        required=True,
        index=True,
    )
    ten_banve = fields.Char(
        string="Tên bản vẽ",
        size=100,
    )
    file_name = fields.Char(
        string="Tên file",
        size=100,
    )
    tag = fields.Char(
        string="Tag",
        size=5,
    )
    image = fields.Binary(
        string="Hình ảnh",
        attachment=False,
    )
    create_log = fields.Char(
        string="Create Log",
        size=50,
    )
    lastmodify_log = fields.Char(
        string="Last Modify Log",
        size=50,
    )
    ma_data = fields.Char(
        string="Mã dữ liệu",
        size=5,
    )
