from odoo import fields, models


class iwmn_r81bangcandoi(models.Model):
    """Material balance master data from legacy MSSQL table dbo.R81BANGCANDOI."""

    _inherit = "iwmn.r81bangcandoi"
    _rec_name = "ma_vt"
    _order = "nam desc, ma_vt, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi tương ứng trong bảng MSSQL dbo.R81BANGCANDOI.",
    )
    nam = fields.Integer(
        string="Năm",
        required=True,
    )
    loai_ps = fields.Char(
        string="Loại phát sinh",
        size=10,
        required=True,
    )
    ma_vt = fields.Char(
        string="Mã vật tư",
        size=20,
        required=True,
        index=True,
    )
    thang01 = fields.Float(string="Tháng 01", digits=(19, 4), required=True)
    thang02 = fields.Float(string="Tháng 02", digits=(19, 4), required=True)
    thang03 = fields.Float(string="Tháng 03", digits=(19, 4), required=True)
    thang04 = fields.Float(string="Tháng 04", digits=(19, 4), required=True)
    thang05 = fields.Float(string="Tháng 05", digits=(19, 4), required=True)
    thang06 = fields.Float(string="Tháng 06", digits=(19, 4), required=True)
    thang07 = fields.Float(string="Tháng 07", digits=(19, 4), required=True)
    thang08 = fields.Float(string="Tháng 08", digits=(19, 4), required=True)
    thang09 = fields.Float(string="Tháng 09", digits=(19, 4), required=True)
    thang10 = fields.Float(string="Tháng 10", digits=(19, 4), required=True)
    thang11 = fields.Float(string="Tháng 11", digits=(19, 4), required=True)
    thang12 = fields.Float(string="Tháng 12", digits=(19, 4), required=True)
    ma_dvcs = fields.Char(
        string="Mã đơn vị cơ sở",
        size=10,
        required=True,
    )
    create_log = fields.Char(
        string="Create Log",
        size=50,
    )
    lastmodify_log = fields.Char(
        string="Last Modify Log",
        size=50,
    )
    tieu_hao = fields.Float(
        string="Tiêu hao",
        digits=(19, 4),
        required=True,
    )
