from odoo import fields, models


class iwmn_r81equipmentinfoct(models.Model):
    _inherit = "iwmn.r81equipmentinfoct"
    _rec_name = "ma_data"
    _order = "ma_data, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    host_ip = fields.Char(
        string="Host_IP",
        required=True,
        size=20,
    )

    equip_id = fields.Char(
        string="Equip_ID",
        required=True,
        size=20,
    )

    stx = fields.Char(
        string="STX",
        required=True,
        size=20,
    )

    etx = fields.Char(
        string="ETX",
        required=True,
        size=20,
    )

    value_len = fields.Char(
        string="Value_Len",
        required=True,
        size=10,
    )

    used = fields.Boolean(
        string="Used",
        required=True,
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
