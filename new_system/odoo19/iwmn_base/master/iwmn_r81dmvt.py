from odoo import fields, models


class iwmn_r81dmvt(models.Model):
    _inherit = "iwmn.r81dmvt"
    _rec_name = "ten_vt"
    _order = "ten_vt, id"

    ma_vt = fields.Char(
        string="Ma_Vt",
        required=True,
        index=True,
        size=20,
    )

    ten_vt = fields.Char(
        string="Ten_Vt",
        size=500,
    )

    ma_nh_vt = fields.Char(
        string="Ma_Nh_Vt",
        required=True,
        index=True,
        size=20,
    )

    dvt = fields.Char(
        string="Dvt",
        required=False,
        size=10,
    )

    dvt1 = fields.Char(
        string="Dvt1",
        required=False,
        size=10,
    )

    he_so1 = fields.Float(
        string="He_So1",
        required=False,
        digits=(9, 5),
    )

    dvt2 = fields.Char(
        string="Dvt2",
        required=False,
        size=10,
    )

    he_so2 = fields.Float(
        string="He_So2",
        required=False,
        digits=(9, 5),
    )

    dvt3 = fields.Char(
        string="Dvt3",
        required=False,
        size=10,
    )

    he_so3 = fields.Float(
        string="He_So3",
        required=False,
        digits=(9, 5),
    )

    sl_ton_min = fields.Float(
        string="Sl_Ton_Min",
        required=False,
        digits=(19, 4),
    )

    sl_ton_max = fields.Float(
        string="Sl_Ton_Max",
        required=False,
        digits=(19, 4),
    )

    loai_vt = fields.Char(
        string="Loai_Vt",
        required=False,
        size=1,
    )

    tk_vtu = fields.Char(
        string="Tk_Vtu",
        required=False,
        size=20,
    )

    tk_gvon = fields.Char(
        string="Tk_GVon",
        required=False,
        size=20,
    )

    tk_dthu = fields.Char(
        string="Tk_DThu",
        required=False,
        size=20,
    )

    tk_hbtl = fields.Char(
        string="Tk_Hbtl",
        required=False,
        size=20,
    )

    ma_vt_sp = fields.Char(
        string="Ma_Vt_Sp",
        required=False,
        index=True,
        size=20,
    )

    ma_vt_gt = fields.Char(
        string="Ma_Vt_Gt",
        required=False,
        index=True,
        size=20,
    )

    ngay_begin = fields.Date(
        string="Ngay_Begin",
        required=False,
    )

    ngay_end = fields.Date(
        string="Ngay_End",
        required=False,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=False,
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

    so_the = fields.Char(
        string="So_The",
        required=False,
        size=20,
    )

    cong_suat = fields.Char(
        string="Cong_Suat",
        required=False,
        size=50,
    )

    nam_sx = fields.Char(
        string="Nam_Sx",
        required=False,
        size=20,
    )

    nuoc_sx = fields.Char(
        string="Nuoc_Sx",
        required=False,
        size=50,
    )

    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi trong MSSQL (Ident00).",
    )

    length = fields.Float(
        string="Length",
        required=False,
        digits=(19, 4),
    )

    is_default = fields.Boolean(
        string="Chiều dài mặc định",
        default=False,
        index=True,
        help="Ưu tiên chiều dài này khi khách chọn vật tư theo Size và Mác thép.",
    )

    diameter = fields.Float(
        string="Diameter",
        required=False,
        digits=(19, 4),
    )

    dmax = fields.Float(
        string="DMax",
        required=False,
        digits=(19, 4),
    )

    dmin = fields.Float(
        string="DMin",
        required=False,
        digits=(19, 4),
    )

    barweight = fields.Float(
        string="BarWeight",
        required=False,
        digits=(18, 6),
    )

    minweight = fields.Float(
        string="MinWeight",
        required=False,
        digits=(19, 4),
    )

    maxweight = fields.Float(
        string="MaxWeight",
        required=False,
        digits=(19, 4),
    )

    num_bars = fields.Integer(
        string="Num_Bars",
        required=False,
    )

    loai_phoi = fields.Char(
        string="Loai_Phoi",
        required=False,
        size=10,
    )

    mac_thep = fields.Char(
        string="Mac_Thep",
        required=False,
        size=50,
    )

    khu_vuc = fields.Char(
        string="Khu_Vuc",
        required=False,
        size=50,
    )

    don_trong = fields.Float(
        string="Don_Trong",
        required=False,
        digits=(19, 4),
    )

    tg_duyet_dh = fields.Float(
        string="Tg_Duyet_Dh",
        required=False,
        digits=(19, 4),
    )

    thang_ton_kho = fields.Float(
        string="Thang_Ton_Kho",
        required=False,
        digits=(19, 4),
    )

    quy_cach_dk = fields.Char(
        string="Quy_Cach_Dk",
        required=False,
        size=100,
    )

    thong_so_kt = fields.Char(
        string="Thong_So_Kt",
        required=False,
        size=2000,
    )

    ma_tb_nha_sx = fields.Char(
        string="Ma_Tb_Nha_Sx",
        index=True,
        size=300,
    )

    ten_nha_sx = fields.Char(
        string="Ten_Nha_Sx",
        required=False,
        size=100,
    )

    vi_tri_ld = fields.Char(
        string="Vi_Tri_Ld",
        required=False,
        size=200,
    )

    barem = fields.Float(
        string="Barem",
        required=False,
        digits=(19, 4),
    )

    ma_vt_chung = fields.Char(
        string="Ma_Vt_Chung",
        required=False,
        index=True,
        size=20,
    )

    ma_vt_ap = fields.Char(
        string="Ma_Vt_Ap",
        required=False,
        index=True,
        size=20,
    )

    ma_nhom = fields.Char(
        string="Ma_Nhom",
        required=False,
        index=True,
        size=20,
    )

    ma_dv_sd = fields.Char(
        string="Ma_Dv_Sd",
        required=False,
        index=True,
        size=20,
    )

    ma_cum = fields.Char(
        string="Ma_Cum",
        required=False,
        index=True,
        size=20,
    )

    ma_tb = fields.Char(
        string="Ma_Tb",
        required=False,
        index=True,
        size=20,
    )

    ten_vt_old = fields.Char(
        string="Ten_Vt_Old",
        required=False,
        size=300,
    )

    vat_tu_old = fields.Char(
        string="Vat_Tu_Old",
        required=False,
        size=20,
    )

    ten_vt_chuan = fields.Char(
        string="Ten_Vt_Chuan",
        required=False,
        size=100,
    )

    ma_tb_nhom = fields.Char(
        string="Ma_Tb_Nhom",
        required=False,
        index=True,
        size=10,
    )

    ma_size = fields.Char(
        string="Ma_Size",
        required=False,
        index=True,
        size=20,
    )

    grade_id = fields.Char(
        string="Grade_ID",
        required=False,
        index=True,
        size=20,
    )

    barem_standard = fields.Float(
        string="Barem_Standard",
        required=False,
        digits=(19, 4),
    )

    tieu_hao = fields.Float(
        string="Tieu_Hao",
        required=False,
        digits=(19, 4),
    )

    ten_vte = fields.Char(
        string="Ten_VtE",
        required=False,
        size=100,
    )

    phan_loai_sp = fields.Char(
        string="Phan_Loai_Sp",
        required=False,
        size=20,
    )

    ma_nhom_cu = fields.Char(
        string="Ma_Nhom_Cu",
        required=False,
        index=True,
        size=1,
    )

    ma_tb_nhom_cu = fields.Char(
        string="Ma_Tb_Nhom_Cu",
        required=False,
        index=True,
        size=4,
    )

    is_hide = fields.Boolean(
        string="Is_Hide",
        required=False,
    )

    is_tieuhao = fields.Boolean(
        string="Is_TieuHao",
        required=False,
    )

    barem_bo = fields.Float(
        string="Barem_Bo",
        required=False,
        digits=(19, 4),
    )

    barem_cay = fields.Float(
        string="Barem_Cay",
        required=False,
        digits=(19, 4),
    )

    mo_ta_bs = fields.Char(
        string="Mo_Ta_Bs",
        required=False,
        size=200,
    )

    is_ptro = fields.Boolean(
        string="Is_PTro",
        required=False,
    )

    muc_dich_ptro = fields.Char(
        string="Muc_Dich_PTro",
        required=False,
        size=200,
    )

    ly_do = fields.Char(
        string="Ly_Do",
        required=False,
        size=500,
    )
