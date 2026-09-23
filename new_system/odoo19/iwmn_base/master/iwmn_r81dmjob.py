from odoo import fields, models


class iwmn_r81dmjob(models.Model):
    _inherit = "iwmn.r81dmjob"
    _rec_name = "ten_job"
    _order = "ten_job, id"

    ma_job = fields.Char(
        string="Ma_Job",
        required=True,
        index=True,
        size=20,
    )

    ten_job = fields.Char(
        string="Ten_Job",
        required=True,
        size=100,
    )

    ngay_begin = fields.Date(
        string="Ngay_Begin",
        required=True,
    )

    ngay_end = fields.Date(
        string="Ngay_End",
        required=True,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=3,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    nh_cuoi = fields.Boolean(
        string="Nh_Cuoi",
        required=True,
    )

    ma_job_parent = fields.Char(
        string="Ma_Job_Parent",
        index=True,
        size=20,
    )

    ma_xe = fields.Char(
        string="Ma_Xe",
        index=True,
        size=20,
    )
