from odoo import fields, models


class iwmn_r81dmqdct(models.Model):
    _inherit = "iwmn.r81dmqdct"
    _rec_name = "so_qd"
    _order = "so_qd, id"

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    so_qd = fields.Char(
        string="So_Qd",
        required=True,
        size=20,
    )

    ma_dt_list = fields.Char(
        string="Ma_Dt_List",
        index=True,
        size=200,
    )

    ma_kho_list = fields.Char(
        string="Ma_Kho_List",
        index=True,
        size=200,
    )

    grade_id_list = fields.Char(
        string="Grade_ID_List",
        size=200,
    )

    tu_ngay = fields.Datetime(
        string="Tu_Ngay",
        required=True,
    )

    den_ngay = fields.Datetime(
        string="Den_Ngay",
        required=True,
    )

    sl_hd = fields.Float(
        string="SL_HD",
        required=True,
        digits=(19, 4),
    )

    sl_ck = fields.Float(
        string="SL_CK",
        required=True,
        digits=(19, 4),
    )

    sl_ck1 = fields.Float(
        string="SL_CK1",
        required=True,
        digits=(19, 4),
    )

    sl_ck2 = fields.Float(
        string="SL_CK2",
        required=True,
        digits=(19, 4),
    )

    muc_ck = fields.Float(
        string="Muc_CK",
        required=True,
        digits=(19, 4),
    )

    is_lk = fields.Boolean(
        string="Is_Lk",
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

    file_re = fields.Char(
        string="File_Re",
        size=20,
    )

    not_ma_dt_list = fields.Char(
        string="Not_Ma_Dt_List",
        size=200,
    )

    ghi_chu = fields.Char(
        string="Ghi_Chu",
        size=200,
    )
