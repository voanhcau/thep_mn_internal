from odoo import fields, models


class iwmn_r81dmhd(models.Model):
    _inherit = "iwmn.r81dmhd"
    _rec_name = "ten_hd"
    _order = "ten_hd, id"

    ma_hd = fields.Char(
        string="Ma_Hd",
        required=True,
        index=True,
        size=50,
    )

    ten_hd = fields.Char(
        string="Ten_Hd",
        required=True,
        size=100,
    )

    ngay_ky = fields.Date(
        string="Ngay_Ky",
        required=True,
    )

    so_hd = fields.Char(
        string="So_Hd",
        size=50,
    )

    tk = fields.Char(
        string="Tk",
        required=True,
        index=True,
        size=50,
    )

    ma_dt = fields.Char(
        string="Ma_Dt",
        required=True,
        index=True,
        size=20,
    )

    tien_hd = fields.Float(
        string="Tien_Hd",
        required=True,
        digits=(19, 4),
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

    loai_hd = fields.Char(
        string="Loai_Hd",
        required=True,
        size=1,
    )

    tien_hd_nt = fields.Float(
        string="Tien_Hd_Nt",
        required=True,
        digits=(19, 4),
    )

    tien_no0 = fields.Float(
        string="Tien_No0",
        required=True,
        digits=(19, 4),
    )

    tien_no_nt0 = fields.Float(
        string="Tien_No_Nt0",
        required=True,
        digits=(19, 4),
    )

    tien_tt0 = fields.Float(
        string="Tien_Tt0",
        required=True,
        digits=(19, 4),
    )

    tien_tt_nt0 = fields.Float(
        string="Tien_Tt_Nt0",
        required=True,
        digits=(19, 4),
    )

    tien_no = fields.Float(
        string="Tien_No",
        required=True,
        digits=(19, 4),
    )

    tien_no_nt = fields.Float(
        string="Tien_No_Nt",
        required=True,
        digits=(19, 4),
    )

    ngay_hd_bd = fields.Date(
        string="Ngay_Hd_Bd",
        required=True,
    )

    ngay_hd_kt = fields.Date(
        string="Ngay_Hd_Kt",
        required=True,
    )

    lai_suat_th = fields.Float(
        string="Lai_Suat_TH",
        required=True,
        digits=(19, 4),
    )

    lai_suat_qh = fields.Float(
        string="Lai_Suat_QH",
        required=True,
        digits=(19, 4),
    )

    ngay_chd_tgd = fields.Date(
        string="Ngay_CHD_TGD",
        required=True,
    )

    ngay_nhd_khvt = fields.Date(
        string="Ngay_NHD_KHVT",
        required=True,
    )

    ngay_chd_kttc = fields.Date(
        string="Ngay_CHD_KTTC",
        required=True,
    )

    note = fields.Char(
        string="Note",
        required=True,
        size=1000,
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

    auto_number = fields.Integer(
        string="Auto_Number",
        required=True,
    )

    nguoi_ky = fields.Char(
        string="Nguoi_Ky",
        required=True,
        size=50,
    )

    ngay_tl = fields.Date(
        string="Ngay_Tl",
        required=True,
    )

    ngay_phai_thu1 = fields.Date(
        string="Ngay_Phai_Thu1",
        required=True,
    )

    ngay_phai_thu2 = fields.Date(
        string="Ngay_Phai_Thu2",
        required=True,
    )

    ngay_phai_thu3 = fields.Date(
        string="Ngay_Phai_Thu3",
        required=True,
    )

    ngay_phai_thu4 = fields.Date(
        string="Ngay_Phai_Thu4",
        required=True,
    )

    ngay_phai_thu5 = fields.Date(
        string="Ngay_Phai_Thu5",
        required=True,
    )

    tien_phai_thu1 = fields.Float(
        string="Tien_Phai_Thu1",
        required=True,
        digits=(19, 4),
    )

    nhan_hieu = fields.Char(
        string="Nhan_Hieu",
        required=True,
        size=100,
    )

    tien_phai_thu2 = fields.Float(
        string="Tien_Phai_Thu2",
        required=True,
        digits=(19, 4),
    )

    dieu_khoan_tt2 = fields.Char(
        string="Dieu_Khoan_Tt2",
        required=True,
        size=100,
    )

    tien_phai_thu3 = fields.Float(
        string="Tien_Phai_Thu3",
        required=True,
        digits=(19, 4),
    )

    dieu_khoan_tt3 = fields.Char(
        string="Dieu_Khoan_Tt3",
        required=True,
        size=100,
    )

    tien_phai_thu4 = fields.Float(
        string="Tien_Phai_Thu4",
        required=True,
        digits=(19, 4),
    )

    dieu_khoan_tt4 = fields.Char(
        string="Dieu_Khoan_Tt4",
        required=True,
        size=100,
    )

    tien_phai_thu5 = fields.Float(
        string="Tien_Phai_Thu5",
        required=True,
        digits=(19, 4),
    )

    dieu_khoan_tt5 = fields.Char(
        string="Dieu_Khoan_Tt5",
        required=True,
        size=100,
    )

    ma_nh_hd = fields.Char(
        string="Ma_Nh_Hd",
        required=True,
        index=True,
        size=20,
    )

    ky_han_tt = fields.Integer(
        string="Ky_Han_Tt",
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

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    tien_bao_lanh = fields.Float(
        string="Tien_Bao_Lanh",
        required=True,
        digits=(19, 4),
    )

    ma_dt_nhbl = fields.Char(
        string="Ma_Dt_NhBl",
        required=True,
        index=True,
        size=20,
    )

    ngay_ship_hd = fields.Date(
        string="Ngay_Ship_Hd",
        required=True,
    )

    ngay_tu = fields.Date(
        string="Ngay_Tu",
        required=True,
    )

    thoi_gian_gh = fields.Float(
        string="Thoi_Gian_Gh",
        digits=(19, 4),
    )

    ngay_gh = fields.Date(
        string="Ngay_Gh",
        required=True,
    )

    file_name = fields.Char(
        string="File_Name",
        required=True,
        size=200,
    )

    file_tag = fields.Char(
        string="File_Tag",
        required=True,
        size=5,
    )

    so_luong = fields.Float(
        string="So_Luong",
        required=True,
        digits=(19, 4),
    )

    don_gia = fields.Float(
        string="Don_Gia",
        required=True,
        digits=(19, 4),
    )

    tien_cam_co = fields.Float(
        string="Tien_Cam_Co",
        required=True,
        digits=(19, 4),
    )

    tien_tin_chap = fields.Float(
        string="Tien_Tin_Chap",
        required=True,
        digits=(19, 4),
    )

    dieu_kien_tt = fields.Char(
        string="Dieu_Kien_Tt",
        required=True,
        size=100,
    )

    dia_diem_gh = fields.Char(
        string="Dia_Diem_Gh",
        required=True,
        size=100,
    )

    ma_hd_goc = fields.Char(
        string="Ma_Hd_Goc",
        required=True,
        index=True,
        size=50,
    )

    nuocnk_xk = fields.Char(
        string="NuocNK_XK",
        required=True,
        size=100,
    )

    stt_dt = fields.Char(
        string="Stt_DT",
        required=True,
        size=15,
    )

    ma_ctrinh = fields.Char(
        string="Ma_CTrinh",
        required=True,
        index=True,
        size=20,
    )

    so_qd = fields.Char(
        string="So_Qd",
        required=True,
        size=20,
    )

    lock = fields.Boolean(
        string="Lock",
        required=True,
    )

    user_lock = fields.Char(
        string="User_Lock",
        required=True,
        size=50,
    )

    ghi_chu_lock = fields.Char(
        string="Ghi_Chu_Lock",
        required=True,
        size=100,
    )

    tien_tin_chap_nt = fields.Float(
        string="Tien_Tin_Chap_Nt",
        required=True,
        digits=(19, 4),
    )

    tien_cam_co_nt = fields.Float(
        string="Tien_Cam_Co_Nt",
        required=True,
        digits=(19, 4),
    )

    file_path = fields.Char(
        string="File_Path",
        required=True,
        size=200,
    )

    last_tien_log = fields.Char(
        string="Last_Tien_Log",
        required=True,
        size=50,
    )

    note_tien = fields.Char(
        string="Note_Tien",
        required=True,
        size=1000,
    )

    is_hd_nt = fields.Boolean(
        string="Is_Hd_Nt",
        required=True,
    )

    ma_bp = fields.Char(
        string="Ma_Bp",
        required=True,
        index=True,
        size=20,
    )

    ma_dt_cbnv = fields.Char(
        string="Ma_Dt_CbNv",
        required=True,
        index=True,
        size=20,
    )

    dia_diem_bh = fields.Char(
        string="Dia_Diem_Bh",
        required=True,
        size=200,
    )

    don_gia_nt = fields.Float(
        string="Don_Gia_Nt",
        required=True,
        digits=(19, 4),
    )

    is_giaon = fields.Boolean(
        string="Is_GiaoN",
        required=True,
    )

    dgoi = fields.Char(
        string="DGoi",
        required=True,
        size=100,
    )

    ptien = fields.Char(
        string="PTien",
        required=True,
        size=100,
    )

    htttoan = fields.Char(
        string="HTTToan",
        required=True,
        size=100,
    )

    is_nhan = fields.Boolean(
        string="Is_Nhan",
        required=True,
    )

    user_nhan = fields.Char(
        string="User_Nhan",
        required=True,
        size=50,
    )
