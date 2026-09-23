from odoo import fields, models


class iwmn_r81equipmentinfo(models.Model):
    _inherit = "iwmn.r81equipmentinfo"
    _rec_name = "description"
    _order = "description, id"

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
        size=50,
    )

    description = fields.Char(
        string="Description",
        required=True,
        size=100,
    )

    port_name = fields.Char(
        string="Port_Name",
        size=20,
    )

    baudrate = fields.Char(
        string="BaudRate",
        size=20,
    )

    parity = fields.Char(
        string="Parity",
        size=20,
    )

    databits = fields.Char(
        string="DataBits",
        size=10,
    )

    stopbits = fields.Char(
        string="StopBits",
        size=20,
    )

    handshake = fields.Char(
        string="Handshake",
        size=20,
    )

    zero_coefficient = fields.Float(
        string="Zero_Coefficient",
        required=True,
        digits=(19, 4),
    )

    span_coefficient = fields.Float(
        string="Span_Coefficient",
        required=True,
        digits=(19, 4),
    )

    net_weight_min = fields.Float(
        string="Net_Weight_Min",
        required=True,
        digits=(19, 4),
    )

    net_weight_max = fields.Float(
        string="Net_Weight_Max",
        required=True,
        digits=(19, 4),
    )

    slopes_up = fields.Float(
        string="Slopes_Up",
        required=True,
        digits=(19, 4),
    )

    slopes_down = fields.Float(
        string="Slopes_Down",
        required=True,
        digits=(19, 4),
    )

    stable_count = fields.Integer(
        string="Stable_Count",
        required=True,
    )

    num_ticket_print = fields.Integer(
        string="Num_Ticket_Print",
        required=True,
    )

    print_barcode = fields.Char(
        string="Print_Barcode",
        size=100,
    )

    print_report = fields.Char(
        string="Print_Report",
        size=100,
    )

    print_eticket = fields.Char(
        string="Print_Eticket",
        size=100,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )

    status_input_type = fields.Char(
        string="Status_Input_Type",
        size=20,
    )

    stx = fields.Char(
        string="STX",
        size=10,
    )

    etx = fields.Char(
        string="ETX",
        size=10,
    )

    value_len = fields.Char(
        string="Value_Len",
        size=10,
    )

    plc_port_name = fields.Char(
        string="PLC_Port_Name",
        size=20,
    )

    stable_time = fields.Integer(
        string="Stable_Time",
        required=True,
    )

    stable_range = fields.Integer(
        string="Stable_Range",
        required=True,
    )

    can = fields.Char(
        string="Can",
        size=5,
    )

    khoi_luong_old = fields.Float(
        string="Khoi_Luong_Old",
        required=True,
        digits=(19, 4),
    )

    loai_can = fields.Char(
        string="Loai_Can",
        size=10,
    )

    note = fields.Char(
        string="Note",
        size=500,
    )

    loai_sp = fields.Char(
        string="Loai_Sp",
        size=20,
    )
