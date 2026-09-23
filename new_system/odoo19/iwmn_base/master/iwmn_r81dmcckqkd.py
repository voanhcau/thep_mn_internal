from odoo import fields, models


class iwmn_r81dmcckqkd(models.Model):
    _inherit = "iwmn.r81dmcckqkd"
    _rec_name = "ten_cc"
    _order = "ten_cc, id"

    ma_cc = fields.Char(
        string="Ma_CC",
        required=True,
        index=True,
        size=20,
    )

    ten_cc = fields.Char(
        string="Ten_CC",
        required=True,
        size=200,
    )

    ma_tb = fields.Char(
        string="Ma_Tb",
        required=True,
        index=True,
        size=20,
    )

    file_path = fields.Char(
        string="File_Path",
        required=True,
        size=300,
    )

    ma_nh_cc = fields.Char(
        string="Ma_Nh_CC",
        required=True,
        index=True,
        size=20,
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

    ngay_cc = fields.Datetime(
        string="Ngay_CC",
        required=True,
    )

    ma_nh_tb = fields.Char(
        string="Ma_Nh_Tb",
        required=True,
        index=True,
        size=20,
    )
