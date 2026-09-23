from odoo import fields, models


class iwmn_r81bangcandoi_new(models.Model):
    """Material balance master data from legacy table dbo.R81BANGCANDOI_NEW."""

    _inherit = "iwmn.r81bangcandoi_new"
    _rec_name = "ten_ps"
    _order = "nam desc, ma_vt, stt_ps, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi tương ứng trong bảng MSSQL dbo.R81BANGCANDOI_NEW.",
    )
    nam = fields.Integer(
        string="Năm",
        required=True,
    )
    ma_vt = fields.Char(
        string="Mã vật tư",
        size=20,
        required=True,
        index=True,
    )
    stt_ps = fields.Float(
        string="STT phát sinh",
        digits=(19, 4),
        required=True,
    )
    ma_ps = fields.Char(
        string="Mã phát sinh",
        size=20,
        required=True,
    )
    ten_ps = fields.Char(
        string="Tên phát sinh",
        size=200,
        required=True,
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
