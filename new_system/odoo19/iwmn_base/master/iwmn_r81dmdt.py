from odoo import fields, models


class iwmn_r81dmdt(models.Model):
    _inherit = "iwmn.r81dmdt"
    _rec_name = "ten_dt"
    _order = "ten_dt, id"

    ma_dt = fields.Char(
        string="Ma_Dt",
        required=True,
        index=True,
        size=20,
    )

    ten_dt = fields.Char(
        string="Ten_Dt",
        required=True,
        size=300,
    )

    ma_nh_dt = fields.Char(
        string="Ma_Nh_Dt",
        required=True,
        index=True,
        size=20,
    )

    dia_chi = fields.Char(
        string="Dia_Chi",
        size=300,
    )

    so_phone = fields.Char(
        string="So_Phone",
        size=50,
    )

    so_fax = fields.Char(
        string="So_Fax",
        size=50,
    )

    ma_so_thue = fields.Char(
        string="Ma_So_Thue",
        index=True,
        size=20,
    )

    so_tk_nh = fields.Char(
        string="So_Tk_NH",
        size=50,
    )

    ten_nh = fields.Char(
        string="Ten_NH",
        size=200,
    )

    ong_ba = fields.Char(
        string="Ong_Ba",
        size=160,
    )

    chuc_vu = fields.Char(
        string="Chuc_Vu",
        size=100,
    )

    tien_no_max = fields.Float(
        string="Tien_No_Max",
        required=True,
        digits=(19, 4),
    )

    loai_dt = fields.Char(
        string="Loai_Dt",
        required=True,
        size=1,
    )

    ten_tp = fields.Char(
        string="Ten_TP",
        size=100,
    )

    email = fields.Char(
        string="Email",
        size=100,
    )

    ma_dt_cbnv = fields.Char(
        string="Ma_Dt_CbNv",
        index=True,
        size=20,
    )

    ma_kv = fields.Char(
        string="Ma_Kv",
        index=True,
        size=20,
    )

    ma_dt_gia = fields.Char(
        string="Ma_Dt_Gia",
        index=True,
        size=20,
    )

    auto_number = fields.Integer(
        string="Auto_Number",
        required=True,
    )

    website = fields.Char(
        string="Website",
        size=100,
    )

    ngay_vao_lam = fields.Date(
        string="Ngay_Vao_Lam",
        required=True,
    )

    tinh_trang = fields.Char(
        string="Tinh_Trang",
        size=10,
    )

    von_csh = fields.Char(
        string="Von_CSH",
        size=50,
    )

    nganh_nghe = fields.Char(
        string="Nganh_Nghe",
        size=50,
    )

    quy_mo = fields.Char(
        string="Quy_Mo",
        size=50,
    )

    sp_used = fields.Char(
        string="SP_Used",
        size=50,
    )

    nam_used = fields.Integer(
        string="Nam_Used",
        required=True,
    )

    type = fields.Char(
        string="Type",
        required=True,
        size=1,
    )

    deleted = fields.Boolean(
        string="Deleted",
        required=True,
    )

    note = fields.Char(
        string="Note",
        size=1000,
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

    ma_bp = fields.Char(
        string="Ma_Bp",
        index=True,
        size=20,
    )

    ngay_sinh = fields.Date(
        string="Ngay_Sinh",
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

    so_thekcb = fields.Char(
        string="So_TheKCB",
        size=50,
    )

    gioi_tinh = fields.Char(
        string="Gioi_Tinh",
        size=10,
    )

    noi_sinh = fields.Char(
        string="Noi_Sinh",
        size=100,
    )

    dan_toc = fields.Char(
        string="Dan_Toc",
        size=50,
    )

    ton_giao = fields.Char(
        string="Ton_Giao",
        size=50,
    )

    quoc_tich = fields.Char(
        string="Quoc_Tich",
        size=50,
    )

    so_cmnd = fields.Char(
        string="So_CMND",
        size=50,
    )

    nguyen_quan = fields.Char(
        string="Nguyen_Quan",
        size=100,
    )

    so_tk = fields.Char(
        string="So_Tk",
        size=50,
    )

    ngan_hang = fields.Char(
        string="Ngan_Hang",
        size=100,
    )

    tinh_trang_hn = fields.Char(
        string="Tinh_Trang_HN",
        size=30,
    )

    so_sobhxh = fields.Char(
        string="So_SoBHXH",
        size=50,
    )

    hinh = fields.Binary(
        string="Hinh",
    )

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    chi_nhanh_nh = fields.Char(
        string="Chi_Nhanh_Nh",
        size=150,
    )

    tag = fields.Char(
        string="Tag",
        size=50,
    )

    name_file = fields.Char(
        string="Name_File",
        size=200,
    )

    ma_dt_chung = fields.Char(
        string="Ma_Dt_Chung",
        index=True,
        size=1000,
    )

    ten_dt_vc = fields.Char(
        string="Ten_Dt_Vc",
        size=100,
    )

    is_barem = fields.Boolean(
        string="Is_Barem",
        required=True,
    )

    ma_tap_doan = fields.Char(
        string="Ma_Tap_Doan",
        index=True,
        size=5,
    )

    cap_ngay = fields.Datetime(
        string="Cap_Ngay",
        required=True,
    )

    cap_tai = fields.Char(
        string="Cap_Tai",
        size=100,
    )

    ma_cham_cong = fields.Char(
        string="Ma_Cham_Cong",
        index=True,
        size=20,
    )

    ma_bp_ct = fields.Char(
        string="Ma_Bp_Ct",
        index=True,
        size=20,
    )

    ngay_nghi_lam = fields.Datetime(
        string="Ngay_Nghi_Lam",
        required=True,
    )

    ly_do_nghi = fields.Char(
        string="Ly_Do_Nghi",
        size=100,
    )

    tp_gd = fields.Char(
        string="Tp_Gd",
        size=100,
    )

    tp_bt = fields.Char(
        string="Tp_Bt",
        size=100,
    )

    trinh_do_vh = fields.Char(
        string="Trinh_Do_VH",
        size=10,
    )

    trinh_do_dt = fields.Char(
        string="Trinh_Do_DT",
        size=100,
    )

    noi_dt = fields.Char(
        string="Noi_DT",
        size=300,
    )

    khoa = fields.Char(
        string="Khoa",
        size=100,
    )

    chuyen_nganh = fields.Char(
        string="Chuyen_Nganh",
        size=100,
    )

    nam_tn = fields.Integer(
        string="Nam_TN",
        required=True,
    )

    xep_loai = fields.Char(
        string="Xep_Loai",
        size=100,
    )

    nghe_nghiep = fields.Char(
        string="Nghe_Nghiep",
        size=100,
    )

    dia_chi_hktt = fields.Char(
        string="Dia_Chi_HKTT",
        size=200,
    )

    xa_phuong_hktt = fields.Char(
        string="Xa_Phuong_HKTT",
        size=100,
    )

    quan_huyen_hktt = fields.Char(
        string="Quan_Huyen_HKTT",
        size=100,
    )

    tinh_tp_hktt = fields.Char(
        string="Tinh_TP_HKTT",
        size=100,
    )

    xa_phuong_hn = fields.Char(
        string="Xa_Phuong_HN",
        size=100,
    )

    quan_huyen_hn = fields.Char(
        string="Quan_Huyen_HN",
        size=100,
    )

    tinh_tp_hn = fields.Char(
        string="Tinh_TP_HN",
        size=100,
    )

    ho_ten_lh = fields.Char(
        string="Ho_Ten_LH",
        size=100,
    )

    loai_qh_lh = fields.Char(
        string="Loai_QH_LH",
        size=100,
    )

    so_phone_lh = fields.Char(
        string="So_Phone_LH",
        size=100,
    )

    dia_chi_lh = fields.Char(
        string="Dia_Chi_LH",
        size=100,
    )

    trang_thai_lv = fields.Char(
        string="Trang_Thai_LV",
        size=100,
    )

    ma_dt_cbnv_qltt = fields.Char(
        string="Ma_Dt_CbNv_QLTT",
        index=True,
        size=100,
    )

    ma_dt_cbnv_qlgt = fields.Char(
        string="Ma_Dt_CbNv_QLGT",
        index=True,
        size=100,
    )

    is_cd = fields.Boolean(
        string="Is_CD",
        required=True,
    )

    is_dv = fields.Boolean(
        string="Is_DV",
        required=True,
    )

    ngay_vao_dv = fields.Datetime(
        string="Ngay_Vao_Dv",
        required=True,
    )

    is_dtn = fields.Boolean(
        string="Is_DTN",
        required=True,
    )

    ngay_vao_dtn = fields.Datetime(
        string="Ngay_Vao_DTN",
        required=True,
    )

    chuc_vu_dtn = fields.Char(
        string="Chuc_Vu_DTN",
        size=100,
    )

    noi_kn_dtn = fields.Char(
        string="Noi_Kn_DTN",
        size=100,
    )

    thanh_phan_gd = fields.Char(
        string="Thanh_Phan_GD",
        size=100,
    )

    thanh_phan_bt = fields.Char(
        string="Thanh_Phan_BT",
        size=100,
    )

    ngay_cap_hc = fields.Datetime(
        string="Ngay_Cap_HC",
        required=True,
    )

    ngay_hh_hc = fields.Datetime(
        string="Ngay_HH_HC",
        required=True,
    )

    so_hc = fields.Char(
        string="So_HC",
        size=50,
    )

    noi_cap_hc = fields.Char(
        string="Noi_Cap_HC",
        size=100,
    )

    ngay_thu_viec = fields.Datetime(
        string="Ngay_Thu_Viec",
        required=True,
    )

    is_qs = fields.Boolean(
        string="Is_QS",
        required=True,
    )

    ngay_nhap_qs = fields.Datetime(
        string="Ngay_Nhap_QS",
        required=True,
    )

    ngay_xuat_qs = fields.Datetime(
        string="Ngay_Xuat_QS",
        required=True,
    )

    cap_bac_qs = fields.Char(
        string="Cap_Bac_QS",
        size=100,
    )

    chuc_vu_qs = fields.Char(
        string="Chuc_Vu_QS",
        size=100,
    )

    don_vi_qs = fields.Char(
        string="Don_Vi_QS",
        size=100,
    )

    ly_do_qs = fields.Char(
        string="Ly_Do_QS",
        size=100,
    )

    nguoi_lh = fields.Char(
        string="Nguoi_Lh",
        size=100,
    )

    ten_nv_ck = fields.Char(
        string="Ten_Nv_Ck",
        size=100,
    )

    nhom_mau = fields.Char(
        string="Nhom_Mau",
        size=5,
    )

    ngay_kn_dang = fields.Datetime(
        string="Ngay_Kn_Dang",
        required=True,
    )

    so_the_dang = fields.Char(
        string="So_The_Dang",
        size=20,
    )

    trinh_do_cm = fields.Char(
        string="Trinh_Do_CM",
        size=100,
    )

    trinh_do_ll = fields.Char(
        string="Trinh_Do_LL",
        size=100,
    )

    ngay_vao_cd = fields.Datetime(
        string="Ngay_Vao_CD",
        required=True,
    )

    ngoai_ngu = fields.Char(
        string="Ngoai_Ngu",
        size=100,
    )

    trinh_do_dt_khac = fields.Char(
        string="Trinh_Do_DT_Khac",
        size=100,
    )

    noi_dt_khac = fields.Char(
        string="Noi_DT_Khac",
        size=100,
    )

    khoa_khac = fields.Char(
        string="Khoa_Khac",
        size=100,
    )

    chuyen_nganh_khac = fields.Char(
        string="Chuyen_Nganh_Khac",
        size=100,
    )

    xep_loai_khac = fields.Char(
        string="Xep_Loai_Khac",
        size=100,
    )

    tk_cn = fields.Char(
        string="Tk_Cn",
        required=True,
        size=20,
    )

    loai_dtcs = fields.Char(
        string="Loai_DtCs",
        size=100,
    )

    locked = fields.Boolean(
        string="Locked",
        required=True,
    )

    so_nha_hktt = fields.Char(
        string="So_Nha_HKTT",
        size=200,
    )

    so_nha_hn = fields.Char(
        string="So_Nha_HN",
        size=200,
    )

    dia_chi_pm = fields.Char(
        string="Dia_Chi_PM",
        size=300,
    )

    phongnnc = fields.Char(
        string="PhongNNC",
        size=10,
    )

    quoc_gia = fields.Char(
        string="Quoc_Gia",
        size=150,
    )

    ghi_chu_dt = fields.Char(
        string="Ghi_Chu_Dt",
        size=3000,
    )
