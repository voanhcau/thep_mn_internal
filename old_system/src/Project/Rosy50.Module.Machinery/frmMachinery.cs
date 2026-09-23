using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using System.Data.SqlClient;

namespace RosyModule.Machinery
{
    public partial class frmMachinery : RosySystem.Customize.frmView
    {
        public DataSet dsMachinery = new DataSet("dsMachinery");
        string strReportFile = string.Empty;
        object objActive = null;

        DataTable dtDmNhVtTb = new DataTable();
        BindingSource bdsDmNhVtTb = new BindingSource();
        rsTreeList tlDmNhVtTb = new rsTreeList();
        DataRow drDmNhVtTb;

        DataSet dsDmCtVtTb = new DataSet();
        DataTable dtDmCtVtTb = new DataTable();
        BindingSource bdsDmCtVtTb = new BindingSource();
        rsTreeList tlDmCtVtTb = new rsTreeList();
        DataRow drDmCtVtTb;

        DataSet dsDmBtVtTb = new DataSet();
        DataTable dtDmBtVtTb = new DataTable();
        BindingSource bdsDmBtVtTb = new BindingSource();
        rsTreeList tlDmBtVtTb = new rsTreeList();
        DataRow drDmBtVtTb;

       
        
        // Tab Lịch sử bảo trì
        DataSet dsLichSu = new DataSet();
        DataTable dtLichSu = new DataTable();
        BindingSource bdsLichSu = new BindingSource();
        rsTreeList tlLichSu = new rsTreeList();
        DataRow drLichSu;

        DataTable dtLichSu_DK = new DataTable();
        BindingSource bdsLichSu_DK = new BindingSource();
        rsDataGridView dgvLichSu_DK = new rsDataGridView();
        DataRow drLichSu_DK;

        DataTable dtLichSu_TT = new DataTable();
        BindingSource bdsLichSu_TT = new BindingSource();
        rsDataGridView dgvLichSu_TT = new rsDataGridView();
        DataRow drLichSu_TT;

        DataTable dtLichSu_VT = new DataTable();
        BindingSource bdsLichSu_VT = new BindingSource();
        rsDataGridView dgvLichSu_VT = new rsDataGridView();

      
        // hết
        //DataTable dtMoTaChung = new DataTable();
        //BindingSource bdsMoTaChung = new BindingSource();
        //rsDataGridView dgvMoTaChung = new rsDataGridView();
        //DataRow drMoTaChung;



        DataTable dtBbNhTb = new DataTable();
        BindingSource bdsBbNhTb = new BindingSource();
        rsDataGridView dgvBbNhTb = new rsDataGridView();
        DataRow drBbNhTb;

        DataTable dtPTKT = new DataTable();
        BindingSource bdsPTKT = new BindingSource();
        rsDataGridView dgvPTKT = new rsDataGridView();
        DataRow drPTKT;

        DataTable dtPTDP = new DataTable();
        BindingSource bdsPTDP = new BindingSource();
        rsDataGridView dgvPTDP = new rsDataGridView();
        DataRow drPTDP;

        //DataTable dtTanSoTb = new DataTable();
        //BindingSource bdsTanSoTb = new BindingSource();
        //rsDataGridView dgvTanSoTb = new rsDataGridView();
        //DataRow drTanSoTb;

        DataTable dtLyLich = new DataTable();
        BindingSource bdsLyLich = new BindingSource();
        rsDataGridView dgvLyLich = new rsDataGridView();
        DataRow drLyLich;

        DataTable dtCongViecBT = new DataTable();
        BindingSource bdsCongViecBT = new BindingSource();
        rsDataGridView dgvCongViecBT = new rsDataGridView();
        DataRow drCongViecBT;

        DataTable dtCongViecCT = new DataTable();
        BindingSource bdsCongViecCT = new BindingSource();
        rsDataGridView dgvCongViecCT = new rsDataGridView();
        DataRow drCongViecCT;

        DataTable dtPhuTungBT = new DataTable();
        BindingSource bdsPhuTungBT = new BindingSource();
        rsDataGridView dgvPhuTungBT = new rsDataGridView();
        DataRow drPhuTungBT;

        DataTable dtTaiLieu = new DataTable();
        BindingSource bdsTaiLieu = new BindingSource();
        rsDataGridView dgvTaiLieu = new rsDataGridView();
        DataRow drTaiLieu;

		DataTable dtKHBTSC = new DataTable();
		BindingSource bdsKHBTSC = new BindingSource();
		rsDataGridView dgvKHBTSC = new rsDataGridView();

        DataTable dtNhanVien = new DataTable();
        BindingSource bdsNhanVien = new BindingSource();
        rsDataGridView dgvNhanVien = new rsDataGridView();
        DataRow drNhanVien;

        private DataRow drCurrent;
        
        public frmMachinery()
        {
            InitializeComponent();
           
            tlDmCtVtTb.KeyDown += new KeyEventHandler(tlDmCtVtTb_KeyDown);
            tlDmNhVtTb.KeyDown += new KeyEventHandler(tlDmNhVtTb_KeyDown);
           
            //dgvTanSoTb.KeyDown += new KeyEventHandler(dgvTanSoTb_KeyDown);
            dgvCongViecCT.KeyDown += new KeyEventHandler(dgvCongViecCT_KeyDown);
            dgvPTKT.KeyDown+=new KeyEventHandler(dgvPTKT_KeyDown);
            dgvPTDP.KeyDown += new KeyEventHandler(dgvPTDP_KeyDown);
            dgvCongViecBT.KeyDown += new KeyEventHandler(dgvCongViecBT_KeyDown);
            dgvPhuTungBT.KeyDown += new KeyEventHandler(dgvPhuTungBT_KeyDown);
            dgvTaiLieu.KeyDown += new KeyEventHandler(dgvTaiLieu_KeyDown);
            dgvLyLich.KeyDown += new KeyEventHandler(dgvLyLich_KeyDown);
            dgvNhanVien.KeyDown += new KeyEventHandler(dgvNhanVien_KeyDown);
            dgvTaiLieu.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvTaiLieu_CellMouseClick);

            bdsDmNhVtTb.PositionChanged += new EventHandler(bdsDmNhVtTb_PositionChanged);
            bdsDmCtVtTb.PositionChanged += new EventHandler(bdsDmVtTb_PositionChanged);
            bdsCongViecBT.PositionChanged += new EventHandler(bdsCongViecBT_PositionChanged);
            //bdsLichSu.PositionChanged += new EventHandler(bdsLichSu_PositionChanged);
            bdsLichSu_DK.PositionChanged += new EventHandler(bdsLichSu_DK_PositionChanged);
            //bdsLichSu_TT.PositionChanged += new EventHandler(bdsLichSu_TT_PositionChanged);

            btPreview.Click += new EventHandler(btPreview_Click);
            btPreview_KHBT.Click += new EventHandler(btPreview_KHBT_Click);
            
            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btAddVTPT.Click += new EventHandler(btAddVTPT_Click);
            btAdd_DNX.Click += new EventHandler(btAdd_DNX_Click);
            btAdd_PYC.Click += new EventHandler(btAdd_PYC_Click);
            btAdd_PYCCK.Click += new EventHandler(btAdd_PYCCK_Click);
            btUpdateTKho.Click += new EventHandler(btUpdateTKho_Click);
            btCreate_Path.Click += new EventHandler(btCreate_Path_Click);
            btGetfile.Click += new EventHandler(btGetfile_Click);
            btImport.Click += new EventHandler(btImport_Click);
            btCopyCV.Click += new EventHandler(btCopyCV_Click);

            dgvLyLich.Enter += new EventHandler(dgvLyLich_Enter);
            dgvPTDP.Enter += new EventHandler(dgvPTDP_Enter);
            dgvPTKT.Enter += new EventHandler(dgvPTKT_Enter);
        }

       

       

        

        
        void btUpdateTKho_Click(object sender, EventArgs e)
        {
            FillData();
        }

        public override void Load()
        {
            if (Element.sysIs_Admin || Common.CheckPermission("GETFILEMACHINE", enuPermission_Type.Allow_Access))
            {
                btGetfile.Visible = true;
                btCreate_Path.Visible = true;
            }
            else
            {
                btGetfile.Visible = false;
                btCreate_Path.Visible = false;
            }
            this.Build();
            this.FillData();
            this.Show();
            this.tabChange();
            BindingData();
            tlDmNhVtTb.Focus();
        }
        private void Build()
        {
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            //Nhóm thiết bị
            tlDmNhVtTb.KeyFieldName = "MA_NH_TB";
            tlDmNhVtTb.ParentFieldName = "MA_NH_TB_PARENT";
            tlDmNhVtTb.Dock = DockStyle.Fill;
            tlDmNhVtTb.strZone = "DMNHTB";
            tlDmNhVtTb.BuildTreeList(this.isLookup);
            this.tabDmNhVtTb.Controls.Add(tlDmNhVtTb);

            tlDmCtVtTb.KeyFieldName = "MA_TB";
            tlDmCtVtTb.ParentFieldName = "MA_NH_TB";
            tlDmCtVtTb.Dock = DockStyle.Fill;
            tlDmCtVtTb.strZone = "DMCTVTTB";
            tlDmCtVtTb.BuildTreeList(this.isLookup);
            this.pageDmCtVtTb.Controls.Add(tlDmCtVtTb);

            //Cấu trúc thiết bị

            dgvPTKT.Dock = DockStyle.Fill;
            dgvPTKT.strZone = "DMVTTB";
            dgvPTKT.BuildGridView(this.isLookup);
            this.pagePTKT.Controls.Add(dgvPTKT);

            dgvPTDP.Dock = DockStyle.Fill;
            dgvPTDP.strZone = "DMVTTB";
            dgvPTDP.BuildGridView(this.isLookup);
            this.pagePTDP.Controls.Add(dgvPTDP);

           
            //
            //dgvTanSoTb.Dock = DockStyle.Fill;
            //dgvTanSoTb.strZone = "TANSOBT";
            //dgvTanSoTb.BuildGridView(this.isLookup);
            //this.pageTanSoTb.Controls.Add(dgvTanSoTb);

            dgvLyLich.Dock = DockStyle.Fill;
            dgvLyLich.strZone = "LYLICHBT";
            dgvLyLich.BuildGridView(this.isLookup);
            this.pageLyLich.Controls.Add(dgvLyLich);

            if (dgvLyLich.Columns.Contains("Tinh_Trang"))
            {
                dgvLyLich.Columns["Tinh_Trang"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvLyLich.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvLyLich.Columns.Contains("Cong_Viec"))
            {
                dgvLyLich.Columns["Cong_Viec"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvLyLich.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            dgvCongViecCT.Dock = DockStyle.Fill;
            dgvCongViecCT.strZone = "CONGVIECBT";
            dgvCongViecCT.BuildGridView(this.isLookup);
            this.pageCongViec.Controls.Add(dgvCongViecCT);
           

            dgvCongViecBT.bSortMode = false;
            dgvCongViecBT.Dock = DockStyle.Fill;
            dgvCongViecBT.strZone = "CONGVIECBT";
            dgvCongViecBT.BuildGridView();
            this.pageCongViecBT.Controls.Add(dgvCongViecBT);

            dgvPhuTungBT.Dock = DockStyle.Fill;
            dgvPhuTungBT.strZone = "PHUTUNGBT";
            dgvPhuTungBT.BuildGridView();
            this.pagePhuTungBT.Controls.Add(dgvPhuTungBT);

            //Lịch sử
            dgvLichSu_DK.Dock = DockStyle.Fill;
            dgvLichSu_DK.strZone = "HISTORY_DK";
            dgvLichSu_DK.BuildGridView();
            this.pageLichSu_DK.Controls.Add(dgvLichSu_DK);

            dgvLichSu_TT.Dock = DockStyle.Fill;
            dgvLichSu_TT.strZone = "HISTORY_TT";
            dgvLichSu_TT.BuildGridView();
            this.pageLichSu_TT.Controls.Add(dgvLichSu_TT);

            dgvLichSu_VT.Dock = DockStyle.Fill;
            dgvLichSu_VT.strZone = "HISTORY_VT";
            dgvLichSu_VT.BuildGridView();
            this.pageLichSu_VT.Controls.Add(dgvLichSu_VT);

            dgvTaiLieu.Dock = DockStyle.Fill;
            dgvTaiLieu.strZone = "TAILIEUBT";
            dgvTaiLieu.BuildGridView();
            this.pageTaiLieu.Controls.Add(dgvTaiLieu);

            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.strZone = "NHANVIENTB";
            dgvNhanVien.BuildGridView();
            this.pageNhanVien.Controls.Add(dgvNhanVien);
           
        }

        private void FillData()
        {
            dsMachinery.Clear();
            dsMachinery = SQLExec.ExecuteReturnDs("sp_GetVoucher_Machinery", CommandType.StoredProcedure);

            //Nhóm vật tư thiết bị
            dtDmNhVtTb = dsMachinery.Tables[0];
            bdsDmNhVtTb.DataSource = dtDmNhVtTb;
            tlDmNhVtTb.DataSource = bdsDmNhVtTb;

            ////Mô tả thiết bị
            //dtMoTaChung = dsMachinery.Tables[1];
            //bdsMoTaChung.DataSource = dtMoTaChung;
            //dgvMoTaChung.DataSource = bdsMoTaChung;
            //////Kế hoạch bảo trì
            //dtTanSoNhTb = dsMachinery.Tables[2];
            //bdsTanSoNhTb.DataSource = dtTanSoNhTb;
            //dgvTanSoNhTb.DataSource = bdsTanSoNhTb;

            //////cập nhật lý lịch
            //dtBbNhTb = dsMachinery.Tables[3];
            //bdsBbNhTb.DataSource = dtBbNhTb;
            //dgvBbNhTb.DataSource = bdsBbNhTb;

            tlDmNhVtTb.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNhVtTb.strZone + "'");

            ////cấu trúc vật tư thiết bị
         
            //dsDmCtVtTb = SQLExec.ExecuteReturnDs("sp_GetVoucher_MachineryCT", CommandType.StoredProcedure);

            dtDmCtVtTb = dsMachinery.Tables[1];
            bdsDmCtVtTb.DataSource = dtDmCtVtTb;
            tlDmCtVtTb.DataSource = bdsDmCtVtTb;

            ////Phụ tùng kèm theo
            dtPTKT = dsMachinery.Tables[2];
            bdsPTKT.DataSource = dtPTKT;
            dgvPTKT.DataSource = bdsPTKT;

            ////Phụ tùng dự phòng chính yếu
            dtPTDP = dsMachinery.Tables[3];
            bdsPTDP.DataSource = dtPTDP;
            dgvPTDP.DataSource = bdsPTDP;
           
            ////Công việc
            dtCongViecCT = dsMachinery.Tables[4];
            bdsCongViecCT.DataSource = dtCongViecCT;
            dgvCongViecCT.DataSource = bdsCongViecCT;

            //////Tần số thiết bị
            //dtTanSoTb = dsMachinery.Tables[5];
            //bdsTanSoTb.DataSource = dtTanSoTb;
            //dgvTanSoTb.DataSource = bdsTanSoTb;

            ////Lý lịch thiết bị
            dtLyLich = dsMachinery.Tables[5];
            bdsLyLich.DataSource = dtLyLich;
            dgvLyLich.DataSource = bdsLyLich;

            ////Tài liệu thiết bị
            dtTaiLieu = dsMachinery.Tables[6];
            bdsTaiLieu.DataSource = dtTaiLieu;
            dgvTaiLieu.DataSource = bdsTaiLieu;

            ////Tài liệu thiết bị
            dtNhanVien = dsMachinery.Tables[7];
            bdsNhanVien.DataSource = dtNhanVien;
            dgvNhanVien.DataSource = bdsNhanVien;

            //Bảo trì định kỳ vật tư thiết bị
            dsDmBtVtTb = SQLExec.ExecuteReturnDs("sp_GetVoucher_MachineryBT", CommandType.StoredProcedure);
           

            //Chu kỳ BTTB định kỳ
            dtCongViecBT = dsDmBtVtTb.Tables[0];
            bdsCongViecBT.DataSource = dtCongViecBT;
            dgvCongViecBT.DataSource = bdsCongViecBT;

            //Chu kỳ BTTB định kỳ
            dtPhuTungBT = dsDmBtVtTb.Tables[1];
            bdsPhuTungBT.DataSource = dtPhuTungBT;
            dgvPhuTungBT.DataSource = bdsPhuTungBT;

           //Lịch sử
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            dsLichSu = SQLExec.ExecuteReturnDs("sp_GetVoucher_MachineryLS", ht, CommandType.StoredProcedure);
            //dtLichSu = dsLichSu.Tables[0];
            //bdsLichSu.DataSource = dtLichSu;
            //tlLichSu.DataSource = bdsLichSu;

            //Lịch sử BTTB định kỳ
            dtLichSu_DK = dsLichSu.Tables[0];
            bdsLichSu_DK.DataSource = dtLichSu_DK;
            dgvLichSu_DK.DataSource = bdsLichSu_DK;

            //Lịch sử BTTB tập trung
            dtLichSu_TT = dsLichSu.Tables[1];
            bdsLichSu_TT.DataSource = dtLichSu_TT;
            dgvLichSu_TT.DataSource = bdsLichSu_TT;

            //Lịch sử vật tư
            dtLichSu_VT = dsLichSu.Tables[2];
            bdsLichSu_VT.DataSource = dtLichSu_VT;
            dgvLichSu_VT.DataSource = bdsLichSu_VT;

            bdsSearch = bdsDmNhVtTb;
            ExportControl = tlDmNhVtTb;
        }
        private void BindingData()
        {
            //Phần nhóm thiết bị
            foreach (Control ctrl in pageCauTrucTB.Controls)
            {
                if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    string strFieldName = ctrl.Name.Substring(3);

                    if (((DataTable)bdsDmCtVtTb.DataSource).Columns.Contains(strFieldName))
                        ctrl.DataBindings.Add("Text", bdsDmCtVtTb, strFieldName);
                }
            }
        }
        #region LoadPicture
        private object LoadResource(string strFile_Name)
        {
            if (strFile_Name != null)
            {
                System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                hashtable.Add("FILE_NAME", strFile_Name);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM R06Resource WHERE File_Name = @File_Name", hashtable, CommandType.Text);
                if (((obj2 != null) && (obj2 != System.DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return obj2;
                }
            }
            return null;
        }

        private void LoadPicture()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDialog.Filter = fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*"; ;

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            FileInfo fiImage = new FileInfo(fileDialog.FileName);
            FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            //picImage.Image = new Bitmap(Image.FromStream(fs), picImage.Size);
            //picImage.SizeMode = PictureBoxSizeMode.Zoom;

            //SavePicture();
        }
        #endregion
        #region Print
        private bool print(bool bPreview)
        {
            string strReportFile = string.Empty;

            if (bdsDmCtVtTb.Position < 0)
                return false;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            if (!dtDmCtVtTb.Columns.Contains("NGAY_CT"))
                dtDmCtVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

            if (!dtDmCtVtTb.Columns.Contains("REPORT_FILE"))
                dtDmCtVtTb.Columns.Add("REPORT_FILE", typeof(string));
            
            strReportFile = "rptLyLichTb2";
            //frmIn_LyLichTB frm = new frmIn_LyLichTB();
            //frm.Load(drDmCtVtTb);

            //if (frm.isAccept)
            //{
            //    if (frm.rdbLyLich1.Checked)
            //        strReportFile = "rptLyLichTb1";
            //    else if (frm.rdbLyLich2.Checked)
            //        
            //    else
            //        strReportFile = "rptLyLichTb3";
            //}
            drDmCtVtTb["REPORT_FILE"] = strReportFile;
            drDmCtVtTb["NGAY_CT"] = Element.sysNgay_Ct2;

            Hashtable ht = new Hashtable();
            ht.Add("MA_TB", drDmCtVtTb["Ma_Tb"].ToString());

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLyLichMMTB", ht, CommandType.StoredProcedure);
            DataTable dtHeader = ds.Tables[0];
            DataTable dtDetail = ds.Tables[1];

            //if (frm.rdbLyLich1.Checked || frm.rdbLyLich2.Checked)
            //    dtDetail = ds.Tables[1];
            //else
                //dtDetail = ds.Tables[2];

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drDmCtVtTb, dtDetail, bPreview, true);


        }

        private bool printDetail_Tb(bool bPreview)
        {
            if (bdsDmNhVtTb.Position < 0)
                return false;

            //if (bdsDmVtTb.Position < 0)
            //    return false;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            //drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            //Load form chọn in
            string strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
            string strMa_Bp = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt_CbNv + "'");
            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drDmNhVtTb, false, strMa_Bp);

            if (frm.isAccept)
            {
                string strLoai_BTTB = "";

                if (frm.rdbPlan_BTTB_NB.Checked == true)
                    strLoai_BTTB = "NB";
                else
                    strLoai_BTTB = "BN";

                Hashtable ht = new Hashtable();
                //ht.Add("MA_NH_TB", drDmNhVtTb["Ma_Nh_Tb"].ToString());
                ht.Add("MA_NH_TB", frm.txtMa_Nh_Tb.Text);
                ht.Add("LOAI_BTTB", strLoai_BTTB);
                ht.Add("NAM", frm.txtNam.Text);
                ht.Add("MA_DVCS", Element.sysMa_DvCs);

                DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLichBTTB", ht, CommandType.StoredProcedure);
                dtHeader = ds.Tables[0];
                dtDetail = ds.Tables[1];

                if (strLoai_BTTB == "BN")
                    strReportFile = "rptPlan_BTTB_BN";
                else
                    strReportFile = "rptPlan_BTTB_NB";

                if (!dtDmNhVtTb.Columns.Contains("REPORT_FILE"))
                    dtDmNhVtTb.Columns.Add("REPORT_FILE", typeof(string));

                if (!dtDmNhVtTb.Columns.Contains("NGAY_CT"))
                    dtDmNhVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

                drDmNhVtTb["REPORT_FILE"] = strReportFile;
                drDmNhVtTb["NGAY_CT"] = Element.sysNgay_Ct2;
                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                return frmPrint.Load(drDmNhVtTb, dtDetail, bPreview, true);

            }
            else
                return false;
        }

        private void Design()
        {
            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drDmNhVtTb, true,"");

            //string strLoai_BTTB = "ALL";
            if (frm.isAccept)
            {
                if (frm.rdbPlan_BTTB_NB.Checked == true)
                    strReportFile = "rptPlan_BTTB_NB";
                else if (frm.rdbPlan_BTTB_BN.Checked == true)
                    strReportFile = "rptPlan_BTTB_BN";
                else if (frm.rdbLyLich2.Checked == true)
                    strReportFile = "rptLyLichTb2";
               
            }
            else
                return;

            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }

        private bool SaveResource(string strFile_Name, object objFile_Content)
        {
            string str;
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            hashtable.Add("FILE_NAME", strFile_Name);
            hashtable.Add("FILE_CONTENT", (objFile_Content == null) ? ((object)new byte[0]) : ((object)((byte[])objFile_Content)));
            if (DataTool.SQLCheckExist("R06Resource", new string[] { "File_Name" }, new object[] { strFile_Name }))
            {
                str = "UPDATE R06Resource SET File_Content = @File_Content WHERE File_Name = @File_Name";
            }
            else
            {
                str = "INSERT INTO R06Resource (File_Name, File_Content) VALUES (@File_Name, @File_Content)";
            }
            return SQLExec.Execute(str, hashtable, CommandType.Text);
        }
        #endregion
        #region New,Edit, Delete
        void Machinery_Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dòng hiện tại
            if (bdsDmNhVtTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmNhVtTb.Current).Row, ref drDmNhVtTb);
            else
                drDmNhVtTb = dtDmNhVtTb.NewRow();

            //if (enuNew_Edit == enuEdit.New)
            //    drDmNhVtTb["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];

            frmMachinery_Edit frmEdit = new frmMachinery_Edit();
            frmEdit.Load(enuNew_Edit, drDmNhVtTb);

            //Khi người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmNhVtTb.Position >= 0)
                        dtDmNhVtTb.ImportRow(drDmNhVtTb);
                    else
                        dtDmNhVtTb.Rows.Add(drDmNhVtTb);

                    bdsDmNhVtTb.Position = bdsDmNhVtTb.Find("Ma_Nh_Tb", drDmNhVtTb["Ma_Nh_Tb"]);
                }
                else
                    Common.CopyDataRow(drDmNhVtTb, ((DataRowView)bdsDmNhVtTb.Current).Row);

              
                
                dtDmNhVtTb.AcceptChanges();
            }
            else
                dtDmNhVtTb.RejectChanges();
        }

        void Machinery_Delete()
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            
            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("R06DmNhTb", drDmNhVtTb))
                {
                    bdsDmNhVtTb.RemoveAt(bdsDmNhVtTb.Position);
                    dtDmNhVtTb.AcceptChanges();
                }
            }
        }


        void DmCtVtTb_Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dòng hiện tại
            if (bdsDmCtVtTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmCtVtTb.Current).Row, ref drDmCtVtTb);
            else
                drDmCtVtTb = dtDmCtVtTb.NewRow();

            //if (enuNew_Edit == enuEdit.New)
            //    drDmNhVtTb["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];

            frmMachineryCT_Edit frmEdit1 = new frmMachineryCT_Edit();
            frmEdit1.Load(enuNew_Edit, drDmCtVtTb);

            //Khi người dùng chọn chấp nhận
            if (frmEdit1.isAccept)
            {
                //drDmCtVtTb["Ma_Nh_Tb"] = drDmCtVtTb["Ma_Nh_Tb"].ToString()+ drDmCtVtTb["Loai_Tb"].ToString();
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmCtVtTb.Position >= 0)
                        dtDmCtVtTb.ImportRow(drDmCtVtTb);
                    else
                        dtDmCtVtTb.Rows.Add(drDmCtVtTb);

                    bdsDmCtVtTb.Position = bdsDmCtVtTb.Find("Ma_Tb", drDmCtVtTb["Ma_Tb"]);
                }
                else
                    Common.CopyDataRow(drDmCtVtTb, ((DataRowView)bdsDmCtVtTb.Current).Row);



                dtDmCtVtTb.AcceptChanges();
            }
            else
                dtDmCtVtTb.RejectChanges();
        }

        void DmCtVtTb_Delete()
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("R06DmTb", drDmCtVtTb))
                {
                    bdsDmCtVtTb.RemoveAt(bdsDmCtVtTb.Position);
                    dtDmCtVtTb.AcceptChanges();
                }
            }
            else
                Common.MsgOk("Bạn không có quyền xóa");
        }


        void btAdd_PYCCK_Click(object sender, EventArgs e)
        {

            frmVoucher_View frm = new frmVoucher_View();
            frm.Load_MaChine("PYCCK", true);
        }

        void btAdd_PYC_Click(object sender, EventArgs e)
        {
            frmVoucher_View frm = new frmVoucher_View();
            frm.Load_MaChine("PYCPT", true);
        }


        void btAdd_DNX_Click(object sender, EventArgs e)
        {
            frmDNX_View frm = new frmDNX_View();
            frm.Load("DNX");
        }



        void tabDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabChange();
        }

        void tabChange()
        {

        }



        void btDelete_Click(object sender, EventArgs e)
        {
            Machinery_Delete();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            Machinery_Edit(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            Machinery_Edit(enuEdit.New);
        }

        void btAddVTPT_Click(object sender, EventArgs e)
        {
            if (rsTabControl3.SelectedTab == pageCauTrucTB && tabPTTB.SelectedTab == pagePTKT)
            {
                frmAddList_VTTB frm = new frmAddList_VTTB();
                frm.Load();

                if (frm.Is_Accept)
                    Save_PKKT(frm.dtDmVt, "1");
            }
            else if (rsTabControl3.SelectedTab == pageCauTrucTB && tabPTTB.SelectedTab == pagePTDP)
            {
                frmAddList_VTTB frm = new frmAddList_VTTB();
                frm.Load();

                if (frm.Is_Accept)
                    Save_PKKT(frm.dtDmVt, "2");
            }
            else if (rsTabControl3.SelectedTab == pageCongViecBT && tabPhuTungBTDK.SelectedTab == pagePhuTungBT)
            {
                frmAddList_VTTB frm = new frmAddList_VTTB();
                frm.Load();

                if (frm.Is_Accept)
                {
                    Save_PhuTungBTDK(frm.dtDmVt);
                }
            }
            else
                Common.MsgOk("Vui lòng chọn form add vật tư !!! ");
        }

        bool Save_PhuTungBTDK(DataTable dtImport_PhuTung)
        {
            if (dtCongViecBT == null)
                return false;
            drCongViecBT = ((DataRowView)bdsCongViecBT.Current).Row;

            if (dtImport_PhuTung == null)
                return false;

            DataTable dtImport = dtImport_PhuTung.Clone();

            DataRow[] Result = dtImport_PhuTung.Select("CHON = 1");

            foreach (DataRow drImport in Result)
                dtImport.ImportRow(drImport);

            SqlCommand sqlCom = SQLExec.GetSQLCommand();
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.Add("CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.Add("MA_NH_TB", drDmNhVtTb["Ma_Nh_Tb"]);
            sqlCom.Parameters.Add("STT_ND", drCongViecBT["Stt_ND"]);
            sqlCom.Parameters.Add("MA_DVCS", Element.sysMa_DvCs);

            sqlCom.CommandText = "Sp_ImportTVP_PHUTUNGBTDK";

            SqlParameter sqlPara = new SqlParameter();
            sqlPara.ParameterName = "@TVP_Import";
            sqlPara.SqlDbType = SqlDbType.Structured;
            sqlPara.TypeName = "TVP_PHUTUNGBTDK";
            sqlPara.Value = Voucher.GetTVPValue("R06PHUTUNGBTDK", "TVP_PHUTUNGBTDK", dtImport);

            sqlCom.Parameters.Add(sqlPara);
            try
            {
                sqlCom.ExecuteNonQuery();

                Common.MsgOk(Languages.GetLanguage("IMPORT_SUCCESS"));

                DataTable dtEditCt = dtPhuTungBT;
                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

                foreach (DataRow dr in dtImport.Rows)
                {
                    DataRow drEditCt = dtPhuTungBT.NewRow();
                    Common.CopyDataRow(drEditCtNew, drEditCt);

                    drEditCt["Ma_Vt"] = dr["Ma_Vt"];
                    drEditCt["Ten_Vt"] = dr["Ten_Vt"];
                    drEditCt["Dvt"] = dr["Dvt"];
                    drEditCt["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];

                    drEditCt["Stt_Nd"] = drCongViecBT["Stt_Nd"];
                    drEditCt["So_Luong"] = 1;



                    dtPhuTungBT.Rows.Add(drEditCt);
                    drEditCt.AcceptChanges();
                }


            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.Message);
                return false;
            }
            // 
            return true;
        }

        bool Save_PKKT(DataTable dtImport_PTKT, string strLoai_VtPt)
        {
            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;
            if (drDmCtVtTb["Ma_Tb"].ToString().Length <= 4)
            {
                Common.MsgOk("Vui lòng chọn lại thiết bị");
                return false;
            }
            if (dtImport_PTKT == null)
                return false;

            DataTable dtImport = dtImport_PTKT.Clone();

            DataRow[] Result = dtImport_PTKT.Select("CHON = 1");

            foreach (DataRow drImport in Result)
                dtImport.ImportRow(drImport);

            SqlCommand sqlCom = SQLExec.GetSQLCommand();
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.Add("CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.Add("MA_DVCS", Element.sysMa_DvCs);
            sqlCom.Parameters.Add("MA_TB", drDmCtVtTb["Ma_Tb"]);
            sqlCom.Parameters.Add("LOAI_VTPT", strLoai_VtPt);

            sqlCom.CommandText = "Sp_ImportTVP_PTKT";

            SqlParameter sqlPara = new SqlParameter();
            sqlPara.ParameterName = "@TVP_Import";
            sqlPara.SqlDbType = SqlDbType.Structured;
            sqlPara.TypeName = "TVP_PTKT";
            sqlPara.Value = Voucher.GetTVPValue("R06VTTB", "TVP_PTKT", dtImport);

            sqlCom.Parameters.Add(sqlPara);
            try
            {
                sqlCom.ExecuteNonQuery();
                Common.MsgOk(Languages.GetLanguage("IMPORT_SUCCESS"));
                if (strLoai_VtPt == "1")
                {
                    DataTable dtEditCt = dtPTKT;
                    DataRow drEditCtNew = dtEditCt.NewRow();
                    Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

                    foreach (DataRow dr in dtImport.Rows)
                    {
                        DataRow drEditCt = dtPTKT.NewRow();
                        Common.CopyDataRow(drEditCtNew, drEditCt);

                        drEditCt["Ma_Vt"] = dr["Ma_Vt"];
                        drEditCt["Ten_Vt"] = dr["Ten_Vt"];
                        drEditCt["Dvt"] = dr["Dvt"];
                        drEditCt["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
                        drEditCt["So_Luong_LD"] = 1;



                        dtPTKT.Rows.Add(drEditCt);
                        drEditCt.AcceptChanges();
                    }
                }
                else
                {
                    DataTable dtEditCt = dtPTDP;
                    DataRow drEditCtNew = dtEditCt.NewRow();
                    Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

                    foreach (DataRow dr in dtImport.Rows)
                    {
                        DataRow drEditCt = dtPTDP.NewRow();
                        Common.CopyDataRow(drEditCtNew, drEditCt);

                        drEditCt["Ma_Vt"] = dr["Ma_Vt"];
                        drEditCt["Ten_Vt"] = dr["Ten_Vt"];
                        drEditCt["Dvt"] = dr["Dvt"];
                        drEditCt["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
                        drEditCt["So_Luong_LD"] = 1;



                        dtPTDP.Rows.Add(drEditCt);
                        drEditCt.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.Message);
                return false;
            }
            // 
            return true;
        }
        void btPreview_Click(object sender, EventArgs e)
        {
            this.print(true);
        }
        void btPreview_KHBT_Click(object sender, EventArgs e)
        {
            printDetail_Tb(true);
        }
        void dgvPhuTungBT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditPhuTungBTDK(enuEdit.New);
                    break;
                case Keys.F3:
                    EditPhuTungBTDK(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deletePhuTungBTDK();
                    break;
            }
        }
        void dgvCongViecBT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditCongViecBTDK(enuEdit.New);
                    break;
                case Keys.F3:
                    EditCongViecBTDK(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteCongViecBTDK();
                    break;
            }
        }
        void dgvPTKT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditPTKT(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditPTKT(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deletePTKT();
                    break;


            }
        }
        void dgvPTDP_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditPTDP(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditPTDP(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deletePTDP();
                    break;


            }
        }
        void tlDmCtVtTb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    DmCtVtTb_Edit(enuEdit.New);
                    break;
                case Keys.F3:
                    DmCtVtTb_Edit(enuEdit.Edit);
                    break;
                case Keys.F8:
                    DmCtVtTb_Delete();
                    break;
            }
        }
        void tlDmNhVtTb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            this.print(true);
                            break;

                        case Keys.Shift:
                            this.Design();
                            break;

                        case Keys.None:
                            this.print(false);
                            break;
                    }
                    break;
            }
        }
        void dgvCongViecCT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditCongViecCT(enuEdit.New);
                    break;
                case Keys.F3:
                    EditCongViecCT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteCongViecCT();
                    break;
            }
        }
        //void dgvTanSoTb_KeyDown(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.F2:
        //            EditTanSoTb(enuEdit.New);
        //            break;
        //        case Keys.F3:
        //            EditTanSoTb(enuEdit.Edit);
        //            break;
        //        case Keys.F8:
        //            deleteTanSoTb();
        //            break;
        //    }
        //}
        void dgvLyLich_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditLyLich(enuEdit.New);
                    break;
                case Keys.F3:
                    EditLyLich(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteLyLich();
                    break;
            }
        }
        void dgvTaiLieu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditTaiLieu(enuEdit.New);
                    break;
                case Keys.F3:
                    EditTaiLieu(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteTaiLieu();
                    break;
            }
           
        }
        void dgvNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditNhanVien(enuEdit.New);
                    break;
                case Keys.F3:
                    EditNhanVien(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteNhanVien();
                    break;
            }

        }
        void dgvTaiLieu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsTaiLieu.Current).Row;
            DataGridViewCell dgvCell = dgvTaiLieu.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "OPEN")
            {
                Voucher.Open_File_Dm((string)drCurrent["File_Path"]);
                //object objFile = (object)drCurrent["File_Path"];
                //string strPath = (string)drCurrent["File_Path"];

                //if (objFile != null && objFile != DBNull.Value)// && ((Byte[])objFile).Length > 0)
                //{
                //    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.ReadWrite);
                //    //fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
                //    fileStream.Close();
                //    System.Diagnostics.Process.Start(strPath);
                //}
            }
        }
       
        
        void deleteTaiLieu()
        {
            if (bdsTaiLieu.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsTaiLieu.Current).Row;
            string strFile = (string)drCurrent["File_Path"];

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06TAILIEUTB", drCurrent))
            {
                Voucher.Delete_File_Dm((string)drCurrent["File_Path"]);
                bdsTaiLieu.RemoveAt(bdsTaiLieu.Position);
                dtTaiLieu.AcceptChanges();
            }
        }
        void deleteNhanVien()
        {
            if (bdsNhanVien.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsNhanVien.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06NHANVIENTB", drCurrent))
            {
                bdsNhanVien.RemoveAt(bdsNhanVien.Position);
                dtNhanVien.AcceptChanges();
            }
        }
        void deleteLyLich()
        {
            if (bdsLyLich.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsLyLich.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06LYLICHTB", drCurrent))
            {
                bdsLyLich.RemoveAt(bdsLyLich.Position);
                dtLyLich.AcceptChanges();
            }
        }
        //void deleteTanSoNhTb()
        //{
        //    if (bdsTanSoNhTb.Position < 0)
        //        return;

        //    DataRow drCurrent = ((DataRowView)bdsTanSoNhTb.Current).Row;

        //    if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
        //        return;

        //    if (DataTool.SQLDelete("R06TSNHTB", drCurrent))
        //    {
        //        bdsTanSoNhTb.RemoveAt(bdsTanSoNhTb.Position);
        //        dtTanSoNhTb.AcceptChanges();
        //    }
        //}
        void deletePTDP()
        {
            if (bdsPTDP.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPTDP.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06VTTB", drCurrent))
            {
                bdsPTDP.RemoveAt(bdsPTDP.Position);
                dtPTDP.AcceptChanges();
            }
        }
        void deletePTKT()
        {
            if (bdsPTKT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPTKT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06VTTB", drCurrent))
            {
                bdsPTKT.RemoveAt(bdsPTKT.Position);
                dtPTKT.AcceptChanges();
            }
        }
        void deleteCongViecCT()
        {
            if (bdsCongViecCT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsCongViecCT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06CONGVIECBTDK", drCurrent))
            {
                bdsCongViecCT.RemoveAt(bdsCongViecCT.Position);
                dtCongViecCT.AcceptChanges();
            }
        }

        void deletePhuTungBTDK()
        {
            if (bdsPhuTungBT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPhuTungBT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06PHUTUNGBTDK", drCurrent))
            {
                bdsPhuTungBT.RemoveAt(bdsPhuTungBT.Position);
                dtPhuTungBT.AcceptChanges();
            }
        }

        void deleteKHBTSC()
        {
            if (bdsKHBTSC.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsKHBTSC.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06KHBTSC", drCurrent))
            {
                bdsKHBTSC.RemoveAt(bdsKHBTSC.Position);
                dtKHBTSC.AcceptChanges();
            }
        }

        //void deleteTanSoTB()
        //{
        //    if (bdsTanSoTb.Position < 0)
        //        return;

        //    DataRow drCurrent = ((DataRowView)bdsTanSoTb.Current).Row;

        //    if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
        //        return;

        //    if (DataTool.SQLDelete("R06TSVTTB", drCurrent))
        //    {
        //        bdsTanSoTb.RemoveAt(bdsTanSoTb.Position);
        //        dtTanSoTb.AcceptChanges();
        //    }
        //}

        void deleteCongViecBTDK()
        {
            if (bdsCongViecBT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsCongViecBT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06CONGVIECBTDK", drCurrent))
            {
                bdsCongViecBT.RemoveAt(bdsCongViecBT.Position);
                dtCongViecBT.AcceptChanges();
            }
        }

        //void deleteImage()
        //{
        //    if (bdsDmVtTb.Position < 0)
        //        return;

        //    if (!Common.MsgYes_No("Bạn muốn remove hình ảnh"))
        //        return;

        //    drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;
        //    Hashtable ht = new Hashtable();

        //    ht.Add("MA_VT_TB", (string)drDmVtTb["Ma_Vt"]);

        //    SQLExec.Execute("UPDATE R81DMVT SET Hinh = NULL WHERE Ma_Vt = @Ma_Vt_Tb", ht, CommandType.Text);

        //    loadImage();
        //}
        void EditPhuTungBTDK(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;
            if (bdsCongViecBT.Position < 0)
                return;

            if (bdsPhuTungBT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            drCongViecBT = ((DataRowView)bdsCongViecBT.Current).Row;

            //Copy dong hien tai
            if (bdsPhuTungBT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPhuTungBT.Current).Row, ref drCurrent);
            else
                drCurrent = dtPhuTungBT.NewRow();

            drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            drCurrent["Stt_Nd"] = drCongViecBT["Stt_Nd"];

            frmPhuTungBTDK_Edit frmEdit = new frmPhuTungBTDK_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", frmEdit.txtMa_Vt.Text);
                drCurrent["Ten_Vt"] = drDmVt["Ten_Vt"];
                drCurrent["Dvt"] = drDmVt["Dvt"];

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPhuTungBT.Position >= 0)
                        dtPhuTungBT.ImportRow(drCurrent);
                    else
                        dtPhuTungBT.Rows.Add(drCurrent);

                    bdsPhuTungBT.Position = bdsPhuTungBT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPhuTungBT.Current).Row);
                
                dtPhuTungBT.AcceptChanges();
            }
            else
                dtPhuTungBT.RejectChanges();
        }
        
       
        void EditCongViecBTDK(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;


            if (bdsCongViecBT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;


            //Copy dong hien tai
            if (bdsCongViecBT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCongViecBT.Current).Row, ref drCurrent);
            else
                drCurrent = dtCongViecBT.NewRow();

            drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];

            frmCongViecBTDK_Edit frmEdit = new frmCongViecBTDK_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsCongViecBT.Position >= 0)
                        dtCongViecBT.ImportRow(drCurrent);
                    else
                        dtCongViecBT.Rows.Add(drCurrent);

                    bdsCongViecBT.Position = bdsCongViecBT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongViecBT.Current).Row);

                dtCongViecBT.AcceptChanges();
            }
            else
                dtCongViecBT.RejectChanges();
        }
        //void EditMoTaChung(enuEdit enuNew_Edit)
        //{
        //    if (bdsDmNhVtTb.Position < 0)
        //        return;

        //    if (bdsMoTaChung.Position < 0 && enuNew_Edit == enuEdit.Edit)
        //        return;

        //    drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

        //    //Copy dong hien tai
        //    if (bdsMoTaChung.Position >= 0)
        //        Common.CopyDataRow(((DataRowView)bdsMoTaChung.Current).Row, ref drCurrent);
        //    else
        //        drCurrent = dtMoTaChung.NewRow();

        //    drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
        //    frmMoTaChung_Edit frmEdit = new frmMoTaChung_Edit();
        //    frmEdit.Load(enuNew_Edit, drCurrent);

        //    if (frmEdit.isAccept)
        //    {
        //        if (enuNew_Edit == enuEdit.New)
        //        {
        //            if (bdsMoTaChung.Position >= 0)
        //                dtMoTaChung.ImportRow(drCurrent);
        //            else
        //                dtMoTaChung.Rows.Add(drCurrent);

        //            bdsMoTaChung.Position = bdsMoTaChung.Find("Ident00", drCurrent["Ident00"]);
        //        }
        //        else
        //            Common.CopyDataRow(drCurrent, ((DataRowView)bdsMoTaChung.Current).Row);

        //        dtMoTaChung.AcceptChanges();
        //    }
        //    else
        //        dtMoTaChung.RejectChanges();
        //}

        void EditPTKT(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsPTKT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsPTKT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPTKT.Current).Row, ref drCurrent);
            else
                drCurrent = dtPTKT.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            frmPTKT_Edit frmEdit = new frmPTKT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, "1");

            if (frmEdit.isAccept)
            {
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", frmEdit.txtMa_Vt.Text);
                drCurrent["Ten_Vt"] = drDmVt["Ten_Vt"];
                drCurrent["Dvt"] = drDmVt["Dvt"];

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPTKT.Position >= 0)
                        dtPTKT.ImportRow(drCurrent);
                    else
                        dtPTKT.Rows.Add(drCurrent);

                    bdsPTKT.Position = bdsPTKT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPTKT.Current).Row);

                dtPTKT.AcceptChanges();
            }
            else
                dtPTKT.RejectChanges();
        }
        void EditPTDP(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsPTDP.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsPTDP.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPTDP.Current).Row, ref drCurrent);
            else
                drCurrent = dtPTDP.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            frmPTKT_Edit frmEdit = new frmPTKT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, "2");

            if (frmEdit.isAccept)
            {
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", frmEdit.txtMa_Vt.Text);
                drCurrent["Ten_Vt"] = drDmVt["Ten_Vt"];
                drCurrent["Dvt"] = drDmVt["Dvt"];

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPTDP.Position >= 0)
                        dtPTDP.ImportRow(drCurrent);
                    else
                        dtPTDP.Rows.Add(drCurrent);

                    bdsPTDP.Position = bdsPTDP.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPTDP.Current).Row);

                dtPTDP.AcceptChanges();
            }
            else
                dtPTDP.RejectChanges();
        }
        void EditCongViecCT(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsCongViecCT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;
            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsCongViecCT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCongViecCT.Current).Row, ref drCurrent);
            else
                drCurrent = dtCongViecCT.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
            frmCongViecBTDK_Edit frmEdit = new frmCongViecBTDK_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                DataTable dtPhan_Loai_Cv = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMTYPE WHERE Type = 'LOAI_CV_BTTB' AND TYPE_ID = '" + drCurrent["Phan_Loai_Cv"].ToString() + "'");
                DataRow drPhan_Loai_Cv = dtPhan_Loai_Cv.Rows[0];
                drCurrent["Ten_Phan_Loai_Cv"] = drPhan_Loai_Cv["Type_Name"];
                
                if (enuNew_Edit == enuEdit.New)
                {
                    drCurrent["Ten_Tb"] = drDmCtVtTb["Ten_Tb"];
                    if (bdsCongViecCT.Position >= 0)
                    {
                        dtCongViecCT.ImportRow(drCurrent);
                        dtCongViecBT.ImportRow(drCurrent);
                    }
                    else
                    {
                        dtCongViecCT.Rows.Add(drCurrent);
                        dtCongViecBT.ImportRow(drCurrent);
                        
                    }
                    bdsCongViecCT.Position = bdsCongViecCT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongViecCT.Current).Row);
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongViecBT.Current).Row);
                }
                dtCongViecCT.AcceptChanges();
            }
            else
                dtCongViecCT.RejectChanges();
        }

        void EditTanSoTb(enuEdit enuNew_Edit)
        {
            //if (bdsDmCtVtTb.Position < 0)
            //    return;

            //if (bdsTanSoTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
            //    return;

            //drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            ////Copy dòng hiện tại
            //if (bdsTanSoTb.Position >= 0)
            //    Common.CopyDataRow(((DataRowView)bdsTanSoTb.Current).Row, ref drCurrent);
            //else
            //    drCurrent = dtTanSoTb.NewRow();

            //drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
     
            //frmKHBTTB_Edit frmEdit = new frmKHBTTB_Edit();
            //frmEdit.Load(enuNew_Edit, drCurrent);

            //if (frmEdit.isAccept)
            //{

            //    if (drCurrent.Table.Columns.Contains("Ten_Tan_So"))
            //        drCurrent["Ten_Tan_So"] = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", drCurrent["Tan_So"].ToString());
            //    if (drCurrent.Table.Columns.Contains("Noi_Dung_Th"))
            //        drCurrent["Noi_Dung_Th"] = frmEdit.txtNoi_Dung.Text;
                
            //    if (enuNew_Edit == enuEdit.New)
            //    {
            //        if (bdsTanSoTb.Position >= 0)
            //            dtTanSoTb.ImportRow(drCurrent);
            //        else
            //            dtTanSoTb.Rows.Add(drCurrent);

            //        bdsTanSoTb.Position = bdsTanSoTb.Find("Ident00", drCurrent["Ident00"]);
            //    }
            //    else
            //        Common.CopyDataRow(drCurrent, ((DataRowView)bdsTanSoTb.Current).Row);

            //    dtTanSoTb.AcceptChanges();
            //}
            //else
            //    dtTanSoTb.RejectChanges();
        }
        void EditTaiLieu(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsTaiLieu.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsTaiLieu.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTaiLieu.Current).Row, ref drCurrent);
            else
                drCurrent = dtTaiLieu.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            frmTaiLieu_Edit frmEdit = new frmTaiLieu_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTaiLieu.Position >= 0)
                        dtTaiLieu.ImportRow(drCurrent);
                    else
                        dtTaiLieu.Rows.Add(drCurrent);

                    bdsTaiLieu.Position = bdsTaiLieu.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTaiLieu.Current).Row);

                dtTaiLieu.AcceptChanges();
            }
            else
                dtTaiLieu.RejectChanges();
        }
        void EditNhanVien(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsNhanVien.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsNhanVien.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsNhanVien.Current).Row, ref drCurrent);
            else
                drCurrent = dtNhanVien.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            frmNhanVienTB_Edit frmEdit = new frmNhanVienTB_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsNhanVien.Position >= 0)
                        dtNhanVien.ImportRow(drCurrent);
                    else
                        dtNhanVien.Rows.Add(drCurrent);

                    bdsNhanVien.Position = bdsNhanVien.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsNhanVien.Current).Row);

                dtNhanVien.AcceptChanges();
            }
            else
                dtNhanVien.RejectChanges();
        }
        void EditLyLich(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsLyLich.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsLyLich.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsLyLich.Current).Row, ref drCurrent);
            else
                drCurrent = dtLyLich.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            frmLyLichTb_Edit frmEdit = new frmLyLichTb_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsLyLich.Position >= 0)
                        dtLyLich.ImportRow(drCurrent);
                    else
                        dtLyLich.Rows.Add(drCurrent);

                    bdsLyLich.Position = bdsLyLich.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsLyLich.Current).Row);

                dtLyLich.AcceptChanges();
            }
            else
                dtLyLich.RejectChanges();
        }
        void bdsDmVtTb_PositionChanged(object sender, EventArgs e)
        {
            FilterDetail();
        }

        void bdsCongViecBT_PositionChanged(object sender, EventArgs e)
        {
            if (bdsCongViecBT.Position < 0)
                return;

            if (((DataRowView)bdsCongViecBT.Current).Row != null)
            {
                drCongViecBT = ((DataRowView)bdsCongViecBT.Current).Row;


                bdsPhuTungBT.Filter = "Ma_Tb = '" + (string)drCongViecBT["Ma_Tb"] + "' AND Stt_ND = " + drCongViecBT["Stt_ND"] + "";
            }
        }
        private void FilterDetail()
        {

            if (bdsDmCtVtTb.Position < 0)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //foreach (DataGridViewRow dgvRow in dgvTaiLieu.Rows)
            //{
            //    object strDownLoad = "DownLoad";
            //    dgvRow.Cells["Open"].Value = (object)strDownLoad;
            //}

            //bdsTanSoTb.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsPTKT.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsPTDP.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsCongViecCT.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsCongViecBT.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsPhuTungBT.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsLyLich.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsLichSu_TT.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsLichSu_DK.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsTaiLieu.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsNhanVien.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            loadImage();
        }
        
        private void FilterDetailBT()
        {
            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            bdsCongViecBT.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            bdsPhuTungBT.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
        }
        private void loadImage()
        {
            //object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DMVT WHERE Ma_Vt = '" + drDmVtTb["Ma_Vt"].ToString() + "'");

            //if (objPic == DBNull.Value)
            //    picImage.Image = null;
            //else
            //    picImage.Image = new Bitmap(Image.FromStream(new MemoryStream((Byte[])objPic)), picImage.Size);
        }

        void bdsLichSu_TT_PositionChanged(object sender, EventArgs e)
        {
            if (bdsLichSu_TT.Position < 0)
                return;
            drLichSu_TT = ((DataRowView)bdsLichSu_TT.Current).Row;
            bdsLichSu_VT.Clear();
            bdsLichSu_VT.Filter = "Stt_Org = '" + (string)drLichSu_TT["Stt"] + "' AND Stt0_Org = " + Convert.ToDouble(drLichSu_TT["Stt0"]) + " ";
        }
        void dgvLyLich_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvLyLich;
        }
        void dgvPTKT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvPTKT;
        }

        void dgvPTDP_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvPTDP;
        }
        void bdsLichSu_DK_PositionChanged(object sender, EventArgs e)
        {
            if (bdsLichSu_DK.Position < 0)
                return;
            drLichSu_DK = ((DataRowView)bdsLichSu_DK.Current).Row;
            //bdsLichSu_VT.Clear();
            bdsLichSu_VT.Filter = "Stt_Org = '" + (string)drLichSu_DK["Stt"] + "' AND Stt0_Org = " + Convert.ToDouble(drLichSu_DK["Stt0"]) + " ";
        }
       

        void bdsDmNhVtTb_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
           
            bdsDmCtVtTb.Filter = "Ma_Nh_Tb_Parent = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
           
            //tabDmVtTb.SelectedTab = tabDmVtTb;
            this.FilterDetail();
            //this.FilterDetailCT();
            this.FilterDetailBT();
        }
        void btCopyCV_Click(object sender, EventArgs e)
        {
            frmCopyCVBT frm = new frmCopyCVBT();
            frm.Load();
        }
        void btImport_Click(object sender, EventArgs e)
        {
            frmChonImpTB frm = new frmChonImpTB();
            frm.Load();
            if (frm.rdbImpLyLich.Checked ==  true)
                ImportLyLich();
            else
                ImportVTPT();
        }
        void ImportVTPT()
        {
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("LYLICH");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                string strSQL = string.Empty;
                foreach (DataRow dr in frmImport.dtImport.Rows)
                {
                    if (DataTool.SQLCheckExist("R06VTTB", new string[] { "Ma_Tb", "Ma_Vt", "Loai_VtPt" }, new object[] { dr["Ma_Tb"].ToString(), dr["Ma_Vt"].ToString(), dr["Loai_VtPt"].ToString() }))
                    {
                        string strMsg = "Mã thiết bị = {" + dr["Ma_Tb"].ToString() + "}, Ma_Vt = {" + dr["Ma_Vt"].ToString() + "}, Loai_VtPy = {" + dr["Loai_VtPt"].ToString() + "}";
                        strMsg += Element.sysLanguage == enuLanguageType.English ? " already exist, do you want to add more?" : " đã tồn tại, Bạn không tạo 2 dòng có mã thiết bị VTPT cùng loại!!!";
                        Common.MsgOk(strMsg);
                        continue;


                    }
                    else
                    {
                        strSQL = "INSERT INTO R06VTTB (Ma_Tb, Ma_Vt, So_Luong_LD, Vi_Tri_Sd, Create_Log, Ma_DvCs, Loai_VtPt) SELECT '" + dr["Ma_Tb"].ToString() + "', '" + dr["Ma_Vt"].ToString() + "', " + dr["So_Luong_LD"].ToString() + ", '" + dr["Vi_Tri_Sd"].ToString() + "', '" + Common.GetCurrent_Log() + "', 'A01','" + dr["Loai_VtPt"].ToString() + "'";
                        SQLExec.Execute(strSQL);
                    }
                }
            }
            FillData();
        }
        void ImportLyLich()
        {
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("LYLICH");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                string strSQL = string.Empty;
                foreach (DataRow dr in frmImport.dtImport.Rows)
                {
                    if (DataTool.SQLCheckExist("R06LYLICHTB", new string[] { "Ma_Tb", "Ngay_BT", "Tinh_Trang", "Cong_Viec" }, new object[] { dr["Ma_Tb"].ToString(), Convert.ToDateTime(dr["Ngay_BT"]), dr["Tinh_Trang"].ToString(), dr["Cong_Viec"].ToString() }))
                    {
                        string strMsg = "Mã thiết bị = {" + dr["Ma_Tb"].ToString() + "}, Ngay_BT = {" + dr["Ngay_BT"].ToString() + "}, Tinh_Trang = {" + dr["Tinh_Trang"].ToString() + "}, Cong_Viec = {" + dr["Cong_Viec"].ToString() + "}";
                        strMsg += Element.sysLanguage == enuLanguageType.English ? " already exist, do you want to add more?" : " đã tồn tại, Bạn vui lòng kiểm tra lại";
                        Common.MsgOk(strMsg);
                        continue;


                    }
                    else
                    {
                        strSQL = "INSERT INTO R06LYLICHTB (Ma_Tb, Ngay_BT, Is_Kh, Is_Bt, Tinh_Trang, Cong_Viec, Ket_Qua, Ten_Vt, Ma_DvCs, Create_Log, LastModify_Log) "+
                                "SELECT '" + dr["Ma_Tb"].ToString() + "', CONVERT(VARCHAR(11),'" + Convert.ToDateTime(dr["Ngay_BT"].ToString()) + "',103), ISNULL('" + dr["Is_Kh"].ToString() + "',''), ISNULL('" + dr["Is_Bt"].ToString() + "',''), "+
                                "ISNULL(N'" + dr["Tinh_Trang"].ToString() + "',''), ISNULL(N'" + dr["Cong_Viec"].ToString() + "',''), ISNULL(N'" + dr["Ket_Qua"].ToString() + "',''), ISNULL(N'" + dr["Ten_Vt"].ToString() + "',''),'A01', '" + Common.GetCurrent_Log() + "',''";
                        
                        SQLExec.Execute(strSQL);
                    }
                }
            }
            FillData();
        }
        void btGetfile_Click(object sender, EventArgs e)
        {
            string strPath = string.Empty;
            string strPath_Cum = string.Empty;
            string strPath_Nhom_Tb = string.Empty;
            string strPath_Tb = string.Empty;
            string strPath_Tb_Co = string.Empty;
            string strPath_Tb_Dien = string.Empty;
            string strPath_Tb_Khac = string.Empty;
            string strFileName = string.Empty;
            string strMa_Tb = string.Empty;
            string strSQLEXEC = string.Empty;
            DataTable dt_Cum;
            DataTable dt_Nhom_Tb;
            DataTable dt_Tb;
           
            string[] strFilePathCo;
            string[] strFilePathDien;
            string[] strFilePathKhac;
            //Path tại server
            strPath = Parameters.GetParaValue("PATH_QLTB").ToString();
            //Database Table path
            dt_Cum = SQLExec.ExecuteReturnDt("SELECT Cum FROM vw_ThietBi WHERE Cum <> '' GROUP BY Cum");
            
                foreach (DataRow dr_Cum in dt_Cum.Rows)
                {
                    strPath_Cum = Path.Combine(strPath, (string)dr_Cum["Cum"]);
                    dt_Nhom_Tb = SQLExec.ExecuteReturnDt("SELECT Ma_Nh_Tb FROM vw_ThietBi WHERE Cum = '" + dr_Cum["Cum"] + "' GROUP BY Ma_Nh_Tb");
                    foreach (DataRow dr_Nhom_Tb in dt_Nhom_Tb.Rows)
                    {
                        strPath_Nhom_Tb = Path.Combine(strPath_Cum, (string)dr_Nhom_Tb["Ma_Nh_Tb"]);
                        dt_Tb = SQLExec.ExecuteReturnDt("SELECT Ma_Tb FROM vw_ThietBi WHERE Ma_Nh_Tb = '" + dr_Nhom_Tb["Ma_Nh_Tb"] + "' GROUP BY Ma_Tb");
                        foreach (DataRow dr_Tb in dt_Tb.Rows)
                        {
                            strMa_Tb = (string)dr_Tb["Ma_Tb"];
                            strPath_Tb = Path.Combine(strPath_Nhom_Tb, (string)dr_Tb["Ma_Tb"]);
                            //Lấy file phần cơ
                            strPath_Tb_Co = Path.Combine(strPath_Tb, "CO");
                            strFilePathCo = Directory.GetFiles(strPath_Tb_Co);
                            // Add các Path File vào R06TAILIEUTB
                            foreach (string fileName in strFilePathCo)
                            {
                               
                                    strFileName = Path.Combine(strPath_Tb_Co, Path.GetFileName(fileName).Trim());
                                    if (!DataTool.SQLCheckExist("R06TAILIEUTB", new string[] { "Ma_Tb", "File_Path" }, new object[] { strMa_Tb, strFileName }))
                                    {
                                        strSQLEXEC = "INSERT INTO R06TAILIEUTB(Ma_Tb, File_Path, Create_Log, LastModify_Log, Ma_Data, Loai_TaiLieu)" +
                                            "SELECT '" + strMa_Tb + "', N'" + strFileName + "','','','A01','CO'";
                                        try
                                        {
                                            SQLExec.Execute(strSQLEXEC);
                                        }


                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Có lỗi xảy ra :" + ex.Message + strMa_Tb);
                                        }
                                    }
                            }
                            //Lấy file phần cơ
                            strPath_Tb_Dien = Path.Combine(strPath_Tb, "DIEN");
                            strFilePathDien = Directory.GetFiles(strPath_Tb_Dien);
                            // Add các Path File vào R06TAILIEUTB
                            foreach (string fileName in strFilePathDien)
                            {
                               
                                strFileName = Path.Combine(strPath_Tb_Dien, Path.GetFileName(fileName).Trim());
                                if (!DataTool.SQLCheckExist("R06TAILIEUTB", new string[] { "Ma_Tb", "File_Path" }, new object[] { strMa_Tb, strFileName }))
                                {
                                    strSQLEXEC = "INSERT INTO R06TAILIEUTB(Ma_Tb, File_Path, Create_Log, LastModify_Log, Ma_Data, Loai_TaiLieu)" +
                                        "SELECT '" + strMa_Tb + "', N'" + strFileName + "','','','A01','DIEN'";
                                    try
                                    {
                                        SQLExec.Execute(strSQLEXEC);
                                    }

                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Có lỗi xảy ra :" + ex.Message + strMa_Tb);
                                    }
                                }
                            }
                            //Lấy file phần khác
                            strPath_Tb_Khac = Path.Combine(strPath_Tb, "KHAC");
                            strFilePathKhac = Directory.GetFiles(strPath_Tb_Khac);
                            // Add các Path File vào R06TAILIEUTB
                            foreach (string fileName in strFilePathKhac)
                            {
                                
                                strFileName = Path.Combine(strPath_Tb_Khac, Path.GetFileName(fileName).Trim());
                                if (!DataTool.SQLCheckExist("R06TAILIEUTB", new string[] { "Ma_Tb", "File_Path" }, new object[] { strMa_Tb, strFileName }))
                                {
                                    strSQLEXEC = "INSERT INTO R06TAILIEUTB(Ma_Tb, File_Path, Create_Log, LastModify_Log, Ma_Data, Loai_TaiLieu)" +
                                        "SELECT '" + strMa_Tb + "', N'" + strFileName + "','','','A01','KHAC'";
                                    try
                                    {
                                        SQLExec.Execute(strSQLEXEC);
                                    }

                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Có lỗi xảy ra :" + ex.Message + strMa_Tb);
                                    }
                                }
                            }
                        }
                    }
                }
           
            Common.MsgOk("Hoàn thành lấy file");
        }
        void btCreate_Path_Click(object sender, EventArgs e)
        {
            string strPath = string.Empty;
            string strPath_Cum = string.Empty;
            string strPath_Nhom_Tb = string.Empty;
            string strPath_Tb = string.Empty;
            string strPath_Tb_Co = string.Empty;
            string strPath_Tb_Dien = string.Empty;
            string strPath_Tb_Khac = string.Empty;
            DataTable dt_Cum;
            DataTable dt_Nhom_Tb;
            DataTable dt_Tb;

            //Path tại server
            strPath = Parameters.GetParaValue("PATH_QLTB").ToString();
            //Database Table path
            dt_Cum = SQLExec.ExecuteReturnDt("SELECT Cum FROM vw_ThietBi WHERE  Cum <> '' GROUP BY Cum");
            
            //tạo thư muc cụm
            foreach (DataRow dr_Cum in dt_Cum.Rows)
            {
                strPath_Cum = Path.Combine(strPath, (string)dr_Cum["Cum"]);
                if (!Directory.Exists(strPath_Cum))
                {
                    Directory.CreateDirectory(strPath_Cum);
                }
                
                dt_Nhom_Tb = SQLExec.ExecuteReturnDt("SELECT Ma_Nh_Tb FROM vw_ThietBi WHERE Cum = '" + dr_Cum["Cum"] + "' GROUP BY Ma_Nh_Tb");
                foreach (DataRow dr_Nhom_Tb in dt_Nhom_Tb.Rows)
                {
                    strPath_Nhom_Tb = Path.Combine(strPath_Cum, (string)dr_Nhom_Tb["Ma_Nh_Tb"]);
                    if (!Directory.Exists(strPath_Nhom_Tb))
                        Directory.CreateDirectory(strPath_Nhom_Tb);
                        dt_Tb = SQLExec.ExecuteReturnDt("SELECT Ma_Tb FROM vw_ThietBi WHERE Ma_Nh_Tb = '" + dr_Nhom_Tb["Ma_Nh_Tb"] + "' GROUP BY Ma_Tb");
                        foreach (DataRow dr_Tb in dt_Tb.Rows)
                        {
                            strPath_Tb = Path.Combine(strPath_Nhom_Tb, (string)dr_Tb["Ma_Tb"]);
                            if (!Directory.Exists(strPath_Tb))
                                Directory.CreateDirectory(strPath_Tb);
                            strPath_Tb_Co = Path.Combine(strPath_Tb, "CO");
                            if (!Directory.Exists(strPath_Tb_Co))
                            {
                                Directory.CreateDirectory(strPath_Tb_Co);
                            }
                            strPath_Tb_Dien = Path.Combine(strPath_Tb, "DIEN");
                            if (!Directory.Exists(strPath_Tb_Dien))
                            {
                                Directory.CreateDirectory(strPath_Tb_Dien);
                            }
                            strPath_Tb_Khac = Path.Combine(strPath_Tb, "KHAC");
                            if (!Directory.Exists(strPath_Tb_Khac))
                            {
                                Directory.CreateDirectory(strPath_Tb_Khac);
                            }
                            
                        }
                    }
                
                
            }
            Common.MsgOk("Hoàn thành tạo folder");
        }
        
#endregion
        //private void SavePicture()
        //{
        //    if (bdsDmVtTb.Position < 0)
        //        return;

        //    drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

        //    Hashtable ht = new Hashtable();
        //    ht.Add("MA_VT", (string)drDmVtTb["Ma_Vt"]);

        //    //if (picImage.Image != null)
        //    //{
        //    //    byte[] barrImg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(picImage.Image).ConvertTo(picImage.Image, typeof(byte[]));
        //    //    ht["HINH"] = barrImg;
        //    //    SQLExec.Execute("UPDATE R81DmVt SET Hinh = @Hinh WHERE Ma_Vt = @Ma_Vt", ht, CommandType.Text);
        //    //}
        //    //else
        //    //{
        //    //    ht["HINH"] = new byte[] { };
        //    //    SQLExec.Execute("UPDATE R81DmVt SET Hinh = Null WHERE Ma_Vt = = @Ma_Vt", ht, CommandType.Text);
        //    //}

        //    loadImage();
        //}

    }
}
