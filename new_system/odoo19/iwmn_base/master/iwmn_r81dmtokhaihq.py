from odoo import fields, models


class iwmn_r81dmtokhaihq(models.Model):
    _inherit = "iwmn.r81dmtokhaihq"
    _rec_name = "ten_vt"
    _order = "ten_vt, id"

    so_tkhai = fields.Char(
        string="So_TKhai",
        required=True,
        size=30,
    )

    loai_tkhai = fields.Char(
        string="Loai_TKhai",
        required=True,
        size=1,
    )

    ngay_tkhai = fields.Datetime(
        string="Ngay_Tkhai",
        required=True,
    )

    ngay_tddky = fields.Datetime(
        string="Ngay_TDDKy",
        required=True,
    )

    ma_dt_hq = fields.Char(
        string="Ma_Dt_Hq",
        index=True,
        size=20,
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        index=True,
        size=20,
    )

    van_don = fields.Char(
        string="Van_Don",
        size=20,
    )

    dia_diem_dh = fields.Char(
        string="Dia_Diem_Dh",
        size=200,
    )

    dia_diem_xh = fields.Char(
        string="Dia_Diem_Xh",
        size=200,
    )

    pt_vc = fields.Char(
        string="Pt_Vc",
        size=50,
    )

    ngay_hang_den = fields.Datetime(
        string="Ngay_Hang_Den",
        required=True,
    )

    so_luong = fields.Float(
        string="So_Luong",
        required=True,
        digits=(19, 4),
    )

    trong_luong = fields.Float(
        string="Trong_Luong",
        required=True,
        digits=(19, 4),
    )

    dvt = fields.Char(
        string="Dvt",
        size=50,
    )

    so_ct0 = fields.Char(
        string="So_Ct0",
        size=20,
    )

    ngay_ct0 = fields.Datetime(
        string="Ngay_Ct0",
        required=True,
    )

    pt_tt = fields.Char(
        string="Pt_Tt",
        size=50,
    )

    loai_gia = fields.Char(
        string="Loai_Gia",
        size=50,
    )

    ma_tte = fields.Char(
        string="Ma_Tte",
        index=True,
        size=50,
    )

    ty_gia = fields.Float(
        string="Ty_Gia",
        required=True,
        digits=(19, 4),
    )

    tien_nt = fields.Float(
        string="Tien_Nt",
        required=True,
        digits=(19, 4),
    )

    tien = fields.Float(
        string="Tien",
        required=True,
        digits=(19, 4),
    )

    tien_bhiem = fields.Float(
        string="Tien_BHiem",
        required=True,
        digits=(19, 4),
    )

    tien5 = fields.Float(
        string="Tien5",
        required=True,
        digits=(19, 4),
    )

    tien3 = fields.Float(
        string="Tien3",
        required=True,
        digits=(19, 4),
    )

    ttien = fields.Float(
        string="TTien",
        required=True,
        digits=(19, 4),
    )

    ma_hd = fields.Char(
        string="Ma_Hd",
        index=True,
        size=50,
    )

    ngay_cap_phep = fields.Datetime(
        string="Ngay_Cap_Phep",
        required=True,
    )

    ngay_ht_ktra = fields.Datetime(
        string="Ngay_Ht_Ktra",
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

    ngay_van_don = fields.Datetime(
        string="Ngay_Van_Don",
        required=True,
    )

    ten_vt = fields.Char(
        string="Ten_Vt",
        size=300,
    )

    don_gia_nt = fields.Float(
        string="Don_Gia_Nt",
        required=True,
        digits=(19, 4),
    )

    thue_nk = fields.Float(
        string="Thue_NK",
        required=True,
        digits=(19, 4),
    )

    thue_gtgt = fields.Float(
        string="Thue_GTGT",
        required=True,
        digits=(19, 4),
    )

    ma_dt_ck = fields.Char(
        string="Ma_Dt_CK",
        index=True,
        size=20,
    )

    note = fields.Char(
        string="Note",
        size=200,
    )
