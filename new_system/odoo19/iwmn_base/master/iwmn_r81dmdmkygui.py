from odoo import fields, models


class iwmn_r81dmdmkygui(models.Model):
    _inherit = "iwmn.r81dmdmkygui"
    _rec_name = "so_luong"
    _order = "so_luong, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    ma_kho = fields.Char(
        string="Ma_Kho",
        index=True,
        size=20,
    )

    grade_id = fields.Char(
        string="Grade_Id",
        index=True,
        size=20,
    )

    is_cuon = fields.Boolean(
        string="Is_Cuon",
    )

    is_cay = fields.Boolean(
        string="Is_Cay",
    )

    so_luong = fields.Float(
        string="So_Luong",
        digits=(19, 4),
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
    )

    ma_data = fields.Char(
        string="Ma_Data",
        index=True,
        size=3,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=50,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=50,
    )
