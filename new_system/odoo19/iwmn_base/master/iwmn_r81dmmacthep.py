from odoo import fields, models


class iwmn_r81dmmacthep(models.Model):
    _inherit = "iwmn.r81dmmacthep"
    _rec_name = "grade_name"
    _order = "grade_name, id"

    grade_id = fields.Char(
        string="Grade_ID",
        required=True,
        index=True,
        size=20,
    )

    grade_name = fields.Char(
        string="Grade_Name",
        required=True,
        size=100,
    )

    standard_id = fields.Char(
        string="Standard_ID",
        required=True,
        index=True,
        size=20,
    )

    create_log = fields.Char(
        string="CREATE_LOG",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )

    bend_standard = fields.Char(
        string="Bend_Standard",
        size=100,
    )

    chemis_standard = fields.Char(
        string="Chemis_Standard",
        size=100,
    )

    pull_standard = fields.Char(
        string="Pull_Standard",
        size=100,
    )

    ngay_begin = fields.Datetime(
        string="Ngay_Begin",
        required=True,
    )

    ngay_end = fields.Datetime(
        string="Ngay_End",
        required=True,
    )
