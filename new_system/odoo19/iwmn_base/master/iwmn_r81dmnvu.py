from odoo import fields, models


class iwmn_r81dmnvu(models.Model):
    _inherit = "iwmn.r81dmnvu"
    _rec_name = "ten_nvu"
    _order = "ten_nvu, id"

    ma_nvu = fields.Char(
        string="Ma_Nvu",
        required=True,
        index=True,
        size=100,
    )

    ten_nvu = fields.Char(
        string="Ten_Nvu",
        required=True,
        size=100,
    )

    ma_nvu_parent = fields.Char(
        string="Ma_Nvu_Parent",
        index=True,
        size=100,
    )

    ma_ct = fields.Char(
        string="Ma_Ct",
        required=True,
        index=True,
        size=50,
    )

    ma_ct_rule = fields.Char(
        string="Ma_Ct_Rule",
        required=True,
        index=True,
        size=1,
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        index=True,
        size=200,
    )

    ma_dt_rule = fields.Char(
        string="Ma_Dt_Rule",
        required=True,
        index=True,
        size=1,
    )

    tk_no = fields.Char(
        string="Tk_No",
        size=100,
    )

    tk_no_rule = fields.Char(
        string="Tk_No_Rule",
        required=True,
        size=1,
    )

    tk_co = fields.Char(
        string="Tk_Co",
        size=100,
    )

    tk_co_rule = fields.Char(
        string="Tk_Co_Rule",
        required=True,
        size=1,
    )

    ma_bp = fields.Char(
        string="Ma_Bp",
        index=True,
        size=200,
    )

    ma_bp_rule = fields.Char(
        string="Ma_Bp_Rule",
        required=True,
        index=True,
        size=1,
    )

    ma_km = fields.Char(
        string="Ma_Km",
        index=True,
        size=200,
    )

    ma_km_rule = fields.Char(
        string="Ma_Km_Rule",
        required=True,
        index=True,
        size=1,
    )

    ma_vt_sp = fields.Char(
        string="Ma_Vt_Sp",
        index=True,
        size=200,
    )

    ma_vt_sp_rule = fields.Char(
        string="Ma_Vt_Sp_Rule",
        required=True,
        index=True,
        size=1,
    )

    ma_hd = fields.Char(
        string="Ma_Hd",
        index=True,
        size=200,
    )

    ma_hd_rule = fields.Char(
        string="Ma_Hd_Rule",
        required=True,
        index=True,
        size=1,
    )

    ma_job = fields.Char(
        string="Ma_Job",
        index=True,
        size=200,
    )

    ma_job_rule = fields.Char(
        string="Ma_Job_Rule",
        required=True,
        index=True,
        size=1,
    )

    ma_thue = fields.Char(
        string="Ma_Thue",
        index=True,
        size=200,
    )

    ma_thue_rule = fields.Char(
        string="Ma_Thue_Rule",
        required=True,
        index=True,
        size=1,
    )

    ma_kho = fields.Char(
        string="Ma_Kho",
        index=True,
        size=200,
    )

    ma_kho_rule = fields.Char(
        string="Ma_Kho_Rule",
        required=True,
        index=True,
        size=1,
    )

    ma_dt_cbnv = fields.Char(
        string="Ma_Dt_CbNv",
        index=True,
        size=200,
    )

    ma_dt_cbnv_rule = fields.Char(
        string="Ma_Dt_CbNv_Rule",
        required=True,
        index=True,
        size=1,
    )

    posted = fields.Boolean(
        string="Posted",
        required=True,
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
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

    tk_no2 = fields.Char(
        string="Tk_No2",
        size=100,
    )

    tk_no2_rule = fields.Char(
        string="TK_NO2_RULE",
        required=True,
        size=1,
    )

    tk_co2 = fields.Char(
        string="Tk_Co2",
        size=100,
    )

    tk_co2_rule = fields.Char(
        string="TK_CO2_RULE",
        required=True,
        size=1,
    )

    default_duyet = fields.Boolean(
        string="Default_Duyet",
        required=True,
    )

    default_autocost = fields.Boolean(
        string="Default_AuToCost",
        required=True,
    )

    ma_khon = fields.Char(
        string="Ma_KhoN",
        index=True,
        size=20,
    )

    is_not_lock = fields.Boolean(
        string="Is_Not_Lock",
        required=True,
    )

    ma_nvu_px = fields.Char(
        string="Ma_Nvu_PX",
        index=True,
        size=20,
    )

    ma_nvu_hd = fields.Char(
        string="Ma_Nvu_HD",
        index=True,
        size=20,
    )

    isautohd = fields.Boolean(
        string="IsAutoHD",
        required=True,
    )

    ma_ky_hieu_hd = fields.Char(
        string="Ma_Ky_Hieu_Hd",
        index=True,
        size=20,
    )

    so_seri0 = fields.Char(
        string="So_Seri0",
        size=20,
    )
