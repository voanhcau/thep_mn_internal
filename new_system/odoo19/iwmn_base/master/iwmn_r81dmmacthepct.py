from odoo import fields, models


class iwmn_r81dmmacthepct(models.Model):
    _inherit = "iwmn.r81dmmacthepct"
    _rec_name = "ma_data"
    _order = "ma_data, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    grade_id = fields.Char(
        string="Grade_ID",
        required=True,
        index=True,
        size=20,
    )

    standard_id = fields.Char(
        string="Standard_ID",
        required=True,
        index=True,
        size=20,
    )

    ngay_ap = fields.Datetime(
        string="Ngay_Ap",
        required=True,
    )

    bend_standard = fields.Char(
        string="Bend_Standard",
        required=True,
        size=50,
    )

    chemis_standard = fields.Char(
        string="Chemis_Standard",
        required=True,
        size=50,
    )

    pull_standard = fields.Char(
        string="Pull_Standard",
        required=True,
        size=50,
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
        size=3,
    )
