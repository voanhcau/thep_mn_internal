from odoo import fields, models


class iwmn_r81dmdt_xncn(models.Model):
    _inherit = "iwmn.r81dmdt_xncn"
    _rec_name = "ma_dt"
    _order = "ma_dt, id"

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

    member_id = fields.Char(
        string="Member_ID",
        required=True,
        size=20,
    )

    email = fields.Char(
        string="Email",
        size=500,
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
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
