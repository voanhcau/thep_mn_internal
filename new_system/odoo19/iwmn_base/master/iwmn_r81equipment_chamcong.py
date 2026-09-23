from odoo import fields, models


class iwmn_r81equipment_chamcong(models.Model):
    _inherit = "iwmn.r81equipment_chamcong"
    _rec_name = "ma_data"
    _order = "ma_data, id"

    equipment_ip = fields.Char(
        string="Equipment_IP",
        required=True,
        size=50,
    )

    equipment_name = fields.Char(
        string="Equipment_Name",
        required=True,
        size=50,
    )

    loai = fields.Char(
        string="Loai",
        size=1,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        index=True,
        size=5,
    )

    equipment_id = fields.Char(
        string="Equipment_ID",
        required=True,
        size=20,
    )

    equipment_type = fields.Char(
        string="Equipment_Type",
        required=True,
        size=10,
    )

    port_name = fields.Integer(
        string="Port_Name",
        required=True,
    )
