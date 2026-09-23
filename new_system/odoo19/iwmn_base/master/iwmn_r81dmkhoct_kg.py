from odoo import fields, models


class iwmn_r81dmkhoct_kg(models.Model):
    _inherit = "iwmn.r81dmkhoct_kg"
    _rec_name = "so_qd"
    _order = "so_qd, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        required=True,
        index=True,
        size=20,
    )

    ma_nh_kg = fields.Char(
        string="Ma_Nh_Kg",
        index=True,
        size=20,
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
        required=True,
    )

    ngay_bd = fields.Datetime(
        string="Ngay_Bd",
        required=True,
    )

    ngay_kt = fields.Datetime(
        string="Ngay_Kt",
        required=True,
    )

    sl_dm_kg = fields.Float(
        string="Sl_Dm_Kg",
        required=True,
        digits=(19, 4),
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

    ma_kho_list = fields.Char(
        string="Ma_Kho_List",
        index=True,
        size=1000,
    )

    so_qd = fields.Char(
        string="So_Qd",
        size=20,
    )

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        size=1000,
    )
