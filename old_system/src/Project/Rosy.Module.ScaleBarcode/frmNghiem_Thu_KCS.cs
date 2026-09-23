using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;



namespace RosyModule.ScaleBarcode
{
	public partial class frmNghiem_Thu_KCS : RosySystem.Customize.frmView
	{
		#region Declare
        
		public DataTable dtThepThanh;
        public DataTable dtThepTron;
        public DataTable dtPhoi;
        public DataTable dtNotDuyet;
        DataTable dtVoucher;
        BindingSource bdsThepThanh = new BindingSource();
        BindingSource bdsThepTron = new BindingSource();
        BindingSource bdsPhoi = new BindingSource();
        BindingSource bdsNotDuyet = new BindingSource();
        string strReportFile = string.Empty;
		
		DataRow drDuyet;
        DataRow drCurrent;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		
		public bool Is_Accept = false;
		#endregion

		#region Contructor

        public frmNghiem_Thu_KCS()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            dgvThepThanh.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvPhanHoiKHVT_CellMouseClick);
            dgvThepThanh.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
            dgvThepTron.CellValidating += new DataGridViewCellValidatingEventHandler(dgvPhanHoiKTCDAT_CellValidating);
            dgvThepTron.CellValidated += new DataGridViewCellEventHandler(dgvThepTron_CellValidated);

            txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);

            btRefresh.Click += new EventHandler(btRefresh_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            this.KeyDown += new KeyEventHandler(frmNghiem_Thu_KCS_KeyDown);
            btDuyet_PKD.Click += new EventHandler(btDuyet_PKD_Click);
            btDuyet_PQLCL.Click += new EventHandler(btDuyet_PQLCL_Click);
            btDuyet_PXC.Click += new EventHandler(btDuyet_PXC_Click);
            btDuyet_PXL.Click += new EventHandler(btDuyet_PXL_Click);

            btDel_Data.Click += new EventHandler(btDel_Data_Click);
		}

       

       
		#endregion

		#region Method

		public void Load()
		{

            dteNgay_Sx.Text = Library.DateToStr(DateTime.Now);

			Build();
			FillData();
			BindingLanguage();
            
            chkDuyet.Visible = false;
            btDuyet_PKD.Visible = false;
            btDuyet_PQLCL.Visible = false;
            btDuyet_PXL.Visible = false;
            btDuyet_PXC.Visible = false;

            dgvThepThanh.Visible = false;
            dgvThepTron.Visible = true;
            dgvPhoi.Visible = false;
            cboXuong.SelectedIndex = 0;
      
            if (!Element.sysIs_Admin)
            {
                if (Common.CheckPermission("KCS_QLCL", enuPermission_Type.Allow_Access))
                { chkDuyet.Visible = true; btDuyet_PQLCL.Visible = true;
               
                }
                else if (Common.CheckPermission("KCS_PKD", enuPermission_Type.Allow_Access))
                {
                    chkDuyet.Visible = true; btDuyet_PKD.Visible = true; this.btgAccept.btAccept.Visible = false; dgvThepThanh.ReadOnly = true; dgvThepTron.ReadOnly = true; dgvPhoi.ReadOnly = true; btDel_Data.Visible = false;
                 
                }
                else if (Common.CheckPermission("KCS_PXC", enuPermission_Type.Allow_Access) && rdbPhoi.Checked == true ) // là nghiệm thu luyện
                {
                    chkDuyet.Visible = true; btDuyet_PXC.Visible = true; this.btgAccept.btAccept.Visible = false; dgvThepThanh.ReadOnly = true; dgvThepTron.ReadOnly = true; dgvPhoi.ReadOnly = true; btDel_Data.Visible = false;
               
                }
                else if (Common.CheckPermission("KCS_PXC", enuPermission_Type.Allow_Access)) // là nghiệm thu cán
                {
                    chkDuyet.Visible = true; btDuyet_PXC.Visible = true; this.btgAccept.btAccept.Visible = false; dgvThepThanh.ReadOnly = true; dgvThepTron.ReadOnly = true; dgvPhoi.ReadOnly = true; btDel_Data.Visible = false;

                }
                else if (Common.CheckPermission("KCS_PXL", enuPermission_Type.Allow_Access))
                { chkDuyet.Visible = true; btDuyet_PXL.Visible = true; this.btgAccept.btAccept.Visible = false; dgvThepThanh.ReadOnly = true; dgvThepTron.ReadOnly = true; dgvPhoi.ReadOnly = true; btDel_Data.Visible = false; }

                if (!Common.CheckPermission("QUERY_KCS", enuPermission_Type.Allow_New))
                {
                    this.btgAccept.btAccept.Visible = false; dgvThepThanh.ReadOnly = false; dgvThepTron.ReadOnly = false; dgvPhoi.ReadOnly = false; btDel_Data.Visible = false;
                }
            }
            else
            {
                btDuyet_PKD.Visible = true;
                btDuyet_PQLCL.Visible = true;
                btDuyet_PXL.Visible = true;
                btDuyet_PXC.Visible = true;
            }
            
            this.LoadDicName();
			this.Show();
		}

		void LoadDicName()
		{
			
		}
        private void DataGridView_Language()
        {
            if (rdbPhoi.Checked == false)
            {
                if (dgvThepThanh.Columns.Contains("Try_ID"))
                    dgvThepThanh.Columns["Try_ID"].HeaderText = "Số Barcode";

                if (dgvThepTron.Columns.Contains("Try_ID"))
                    dgvThepTron.Columns["Try_ID"].HeaderText = "Số Barcode";

                pnlPhoi.Visible = false;
                pnlThep.Visible = true;
            }
            if (rdbPhoi.Checked == true)
            {
                if (dgvPhoi.Columns.Contains("So_Bo_PH"))
                    dgvPhoi.Columns["So_Bo_PH"].HeaderText = "Số cây PH";
                if (dgvPhoi.Columns.Contains("So_Luong_PH"))
                    dgvPhoi.Columns["So_Luong_PH"].HeaderText = "KL Phôi PH";
                if (dgvPhoi.Columns.Contains("So_Bo_CXL"))
                    dgvPhoi.Columns["So_Bo_CXL"].HeaderText = "Số cây CXL";
                if (dgvPhoi.Columns.Contains("So_Luong_CXL"))
                    dgvPhoi.Columns["So_Luong_CXL"].HeaderText = "KL Phôi CXL";

                pnlPhoi.Visible = true;
                pnlThep.Visible = false;
            }
        }
		void Build()
		{
            //txtMa_Vt_Sp.bUseAutoDropDown = true;

			dgvThepThanh.strZone = "KCS_THEP_THANH";
            dgvThepTron.strZone = "KCS_THEP_TRON";
            dgvPhoi.strZone = "KCS_PHOI";
            dgvNotDuyet.strZone = "KCS_NOTDUYET";

			dgvThepThanh.BuildGridView();
			dgvThepTron.BuildGridView();
            dgvPhoi.BuildGridView();
            dgvNotDuyet.BuildGridView();

            foreach (DataGridViewColumn dgvc in dgvNotDuyet.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvThepTron.Columns)
				dgvc.ReadOnly = true;

            if (dgvThepTron.Columns.Contains("D_Max"))
                dgvThepTron.Columns["D_Max"].ReadOnly = false;
            if (dgvThepTron.Columns.Contains("D_Min"))
                dgvThepTron.Columns["D_Min"].ReadOnly = false;
            if (dgvThepTron.Columns.Contains("CL_BeMat"))
                dgvThepTron.Columns["CL_BeMat"].ReadOnly = false;
            if (dgvThepTron.Columns.Contains("Ghi_Chu"))
                dgvThepTron.Columns["Ghi_Chu"].ReadOnly = false;


            foreach (DataGridViewColumn dgvc in dgvThepThanh.Columns)
                dgvc.ReadOnly = true;

            if (dgvThepThanh.Columns.Contains("So_Vet_ND"))
                dgvThepThanh.Columns["So_Vet_ND"].ReadOnly = false;
            if (dgvThepThanh.Columns.Contains("CHIEU_DAI"))
                dgvThepThanh.Columns["CHIEU_DAI"].ReadOnly = false;
            if (dgvThepThanh.Columns.Contains("KHAC"))
                dgvThepThanh.Columns["KHAC"].ReadOnly = false;
            if (dgvThepThanh.Columns.Contains("DON_TRONG"))
                dgvThepThanh.Columns["DON_TRONG"].ReadOnly = false;
            if (dgvThepThanh.Columns.Contains("Ghi_Chu"))
                dgvThepThanh.Columns["Ghi_Chu"].ReadOnly = false;

            foreach (DataGridViewColumn dgvc in dgvPhoi.Columns)
                dgvc.ReadOnly = true;

            if (this.dgvPhoi.Columns.Contains("No_Melt"))
                this.dgvPhoi.Columns["No_Melt"].Frozen = true;

            if (dgvPhoi.Columns.Contains("KT_D1"))
                dgvPhoi.Columns["KT_D1"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("KT_D2"))
                dgvPhoi.Columns["KT_D2"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("KT_D3"))
                dgvPhoi.Columns["KT_D3"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("KT_D4"))
                dgvPhoi.Columns["KT_D4"].ReadOnly = false;

            if (dgvPhoi.Columns.Contains("DC_D1"))
                dgvPhoi.Columns["DC_D1"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("DC_D2"))
                dgvPhoi.Columns["DC_D2"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("DC_D3"))
                dgvPhoi.Columns["DC_D3"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("DC_D4"))
                dgvPhoi.Columns["DC_D4"].ReadOnly = false;

            if (dgvPhoi.Columns.Contains("Length_D1"))
                dgvPhoi.Columns["Length_D1"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("Length_D2"))
                dgvPhoi.Columns["Length_D2"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("Length_D3"))
                dgvPhoi.Columns["Length_D3"].ReadOnly = false;
            if (dgvPhoi.Columns.Contains("Length_D4"))
                dgvPhoi.Columns["Length_D4"].ReadOnly = false;

            if (dgvPhoi.Columns.Contains("Ghi_Chu"))
                dgvPhoi.Columns["Ghi_Chu"].ReadOnly = false;
		}

		void FillData()
		{
			
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_SX", dteNgay_Sx.Text);
			htPara.Add("CA", cboCa.Text);
			htPara.Add("SO_CT", txtSo_Ct.Text);
			htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
            htPara.Add("XUONG", cboXuong.SelectedItem);
            htPara.Add("SO_CT_LXH", rdbThepGC.Checked ? "GCPOM" : "");
            htPara.Add("IS_THANH", txtMa_Vt_Sp.Text.StartsWith("BD")? 1 : 0 );

            dtVoucher = SQLExec.ExecuteReturnDt("sp_GetKCSThanhTron", htPara, CommandType.StoredProcedure);

            if (Common.CheckPermission("KCS_QLCL", enuPermission_Type.Allow_Access))
            {
                if (dtVoucher.Rows.Count > 0)
                    chkDuyet.Checked = Convert.ToBoolean(dtVoucher.Rows[0]["Duyet_QLCL"]);
            }
            else if (Common.CheckPermission("KCS_PKD", enuPermission_Type.Allow_Access))
            {
                if (dtVoucher.Rows.Count > 0)
                    chkDuyet.Checked = Convert.ToBoolean(dtVoucher.Rows[0]["Duyet_PKD"]);
            }
            else if (Common.CheckPermission("KCS_PXC", enuPermission_Type.Allow_Access))
            {
                if (dtVoucher.Rows.Count > 0)
                    chkDuyet.Checked = Convert.ToBoolean(dtVoucher.Rows[0]["Duyet_PXC"]);
            }
            else if (Common.CheckPermission("KCS_PXL", enuPermission_Type.Allow_Access))
            {
                if (dtVoucher.Rows.Count > 0)
                    chkDuyet.Checked = Convert.ToBoolean(dtVoucher.Rows[0]["Duyet_PXL"]);
            }

            DataSet ds = SQLExec.ExecuteReturnDs("sp_GetKCSThanhTron", htPara, CommandType.StoredProcedure);
            if (txtMa_Vt_Sp.Text.StartsWith("BD"))
                dtThepThanh = ds.Tables[0];
            else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
                dtThepTron = ds.Tables[0];
            else if (txtMa_Vt_Sp.Text.StartsWith("A"))
                dtPhoi = ds.Tables[0];

            dtNotDuyet = ds.Tables[1];



            bdsThepThanh.DataSource = dtThepThanh;
            bdsThepTron.DataSource = dtThepTron;
            bdsPhoi.DataSource = dtPhoi;
            bdsNotDuyet.DataSource = dtNotDuyet;

            dgvThepThanh.DataSource = bdsThepThanh;
            dgvThepTron.DataSource = bdsThepTron;
            dgvPhoi.DataSource = bdsPhoi;
            dgvNotDuyet.DataSource = bdsNotDuyet;

            if (txtMa_Vt_Sp.Text.StartsWith("BD"))
            {
                numTBo.Value = Common.SumDCValue(dtThepThanh, "SO_LUONG_Bo_PH", "") + Common.SumDCValue(dtThepThanh, "SO_LUONG_Bo_CXL", "");
                numTKhoi_Luong.Value = Common.SumDCValue(dtThepThanh, "SO_LUONG_PH", "") + Common.SumDCValue(dtThepThanh, "SO_LUONG_CXL", "");
                numTBo_CXL.Value = Common.SumDCValue(dtThepThanh, "SO_LUONG_BO_CXL", "");
                numTKhoi_Luong_CXL.Value = Common.SumDCValue(dtThepThanh, "SO_LUONG_CXL", "");
                numTBo_PH.Value = Common.SumDCValue(dtThepThanh, "SO_LUONG_BO_PH", "");
                numTKhoi_Luong_PH.Value = Common.SumDCValue(dtThepThanh, "SO_LUONG_PH", "");

                numSo_Luong_Dau_Mau.Value = Common.MaxDCValue(dtThepThanh, "SO_LUONG_DAU_MAU");
                numSo_Luong_Thep_Ngan.Value = Common.MaxDCValue(dtThepThanh, "SO_LUONG_THEP_NGAN");

            }
            else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
            {
                numTBo.Value = Common.SumDCValue(dtThepTron, "SO_LUONG_Bo_PH", "") + Common.SumDCValue(dtThepTron, "SO_LUONG_Bo_CXL", "");
                numTKhoi_Luong.Value = Common.SumDCValue(dtThepTron, "SO_LUONG_PH", "") + Common.SumDCValue(dtThepTron, "SO_LUONG_CXL", "");
                numTBo_CXL.Value = Common.SumDCValue(dtThepTron, "SO_LUONG_BO_CXL", "");
                numTKhoi_Luong_CXL.Value = Common.SumDCValue(dtThepTron, "SO_LUONG_CXL", "");
                numTBo_PH.Value = Common.SumDCValue(dtThepTron, "SO_LUONG_BO_PH", "");
                numTKhoi_Luong_PH.Value = Common.SumDCValue(dtThepTron, "SO_LUONG_PH", "");

                numSo_Luong_Dau_Mau.Value = Common.MaxDCValue(dtThepTron, "SO_LUONG_DAU_MAU");
                numSo_Luong_Thep_Ngan.Value = Common.MaxDCValue(dtThepTron, "SO_LUONG_THEP_NGAN");

            }
            else if (txtMa_Vt_Sp.Text.StartsWith("A"))
            {
                numTBo.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_BO_CXL", "") + Common.SumDCValue(dtPhoi, "SO_LUONG_BO_PH", "");
                numTKhoi_Luong.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_CXL", "") + Common.SumDCValue(dtPhoi, "SO_LUONG_PH", "");
                numTBo_CXL.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_BO_CXL", "");
                numTKhoi_Luong_CXL.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_CXL", "");
                numTBo_PH.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_BO_PH", "");
                numTKhoi_Luong_PH.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_PH", "");

                numSL_Phoi_Nong.Value = Common.SumDCValue(dtPhoi, "SL_PHOI_NONG", "");
                numSo_Luong_Nong.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_NONG", "");
                numSL_Phoi_TG.Value = Common.SumDCValue(dtPhoi, "SL_PHOI_TG", "");
                numSo_Luong_TG.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_TG", "");
                numSL_Phoi_Nguoi.Value = Common.SumDCValue(dtPhoi, "SL_PHOI_NGUOI", "");
                numSo_Luong_Nguoi.Value = Common.SumDCValue(dtPhoi, "SO_LUONG_NGUOI", "");

            }

            DataGrideView_Visible();

            DataGridView_Language();
		}
        void DataGrideView_Visible()
        {
            if (txtMa_Vt_Sp.Text.StartsWith("BD"))
            { dgvThepThanh.Visible = true; dgvThepTron.Visible = false; dgvPhoi.Visible = false; }
            else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
            { dgvThepThanh.Visible = false; dgvThepTron.Visible = true; dgvPhoi.Visible = false; }
            else
            { dgvThepThanh.Visible = false; dgvThepTron.Visible = false; dgvPhoi.Visible = true; 
                dgvPhoi.Columns["DUYET_PXC"].HeaderText = "Thủ kho phôi";
                dgvPhoi.Columns["DUYET_LOG_PXC"].HeaderText = "Nhật ký duyệt thủ kho phôi";
            }
        }
		bool FormCheckValid()
		{

			return true;
		}
        void btRefresh_Click(object sender, EventArgs e)
        {
            Build();
            FillData();
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            print(true);
        }
        private void Design()
        {

            if (txtMa_Vt_Sp.Text.StartsWith("BD"))
                strReportFile = "rptKCS_THANH";
            else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
                strReportFile = "rptKCS_TRON";
            else if (txtMa_Vt_Sp.Text.StartsWith("A") && txtSo_Ct.Text == "1")
                strReportFile = "rptKCS_PHOI1";
            else if (txtMa_Vt_Sp.Text.StartsWith("A") && txtSo_Ct.Text == "2")
                strReportFile = "rptKCS_PHOI2";

            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }
        
        private bool print(bool bPreview)
        {
            if (bdsThepThanh.Position < 0 && bdsThepTron.Position < 0 && bdsPhoi.Position < 0)
                return false;
            if (txtMa_Vt_Sp.Text.StartsWith("B"))
            {
                if (txtMa_Vt_Sp.Text.StartsWith("BD"))
                    strReportFile = "rptKCS_THANH";
                else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
                    strReportFile = "rptKCS_TRON";
                
                Hashtable ht = new Hashtable();
                ht.Add("CA_SX", cboCa.Text);
                ht.Add("NGAY_CT", dteNgay_Sx.Text);
                ht.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
                ht.Add("SO_CT", txtSo_Ct.Text);

                DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintKCSThanhTron", ht, CommandType.StoredProcedure);
                DataTable dtHeader = ds.Tables[0];
                DataTable dtDetail = ds.Tables[1];


                if (!dtHeader.Columns.Contains("REPORT_FILE"))
                    dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                if (!dtHeader.Columns.Contains("NGAY_CT"))
                    dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

                dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
                dtHeader.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);
            }
            else
            {
                int ii = 1; int ij = 2; bool bKT = false;
                while (ii <= ij)
                {
                    if (ii == 1)
                        strReportFile = "rptKCS_PHOI1";
                    else
                    {
                        strReportFile = "rptKCS_PHOI2";
                        bKT = true;
                    }

                    Hashtable ht = new Hashtable();
                    ht.Add("CA_SX", cboCa.Text);
                    ht.Add("NGAY_CT", dteNgay_Sx.Text);
                    ht.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
                    ht.Add("SO_CT", txtSo_Ct.Text);
                    ht.Add("KT", bKT);

                    DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintKCSThanhTron", ht, CommandType.StoredProcedure);
                    DataTable dtHeader = ds.Tables[0];
                    DataTable dtDetail = ds.Tables[1];


                    if (!dtHeader.Columns.Contains("REPORT_FILE"))
                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                    if (!dtHeader.Columns.Contains("NGAY_CT"))
                        dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

                    dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
                    dtHeader.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

                    RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                    frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);

                    ii++;
                }
            }
            return true;
        }
		#endregion

		#region Event
        void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Sp.Text.Trim();
            bool bRequire = false;
            
            DataRow drLookup;

            if(rdbThep.Checked == true)
                drLookup = Lookup.ShowLookup("MA_VT_SP_KCS", strValue, bRequire, "Ngay_Nhap = '" + dteNgay_Sx.Text + "' AND Ca = '" + cboCa.Text + "' AND Loai = 'CAN'");
            else if (rdbThepGC.Checked == true)
                drLookup = Lookup.ShowLookup("MA_VT_SP_KCS", strValue, bRequire, "Ngay_Nhap = '" + dteNgay_Sx.Text + "' AND Ca = '" + cboCa.Text + "' AND Loai LIKE 'CANGC%'");
            else
                drLookup = Lookup.ShowLookup("Ma_Vt_Sp_Sx", strValue, bRequire, "Loai_SP = 'NPHOI' AND Ngay_Nhap = '" + dteNgay_Sx.Text + "' AND Ca = '" + cboCa.Text + "'");
            

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Sp.Text = string.Empty;
                

            }
            else
            {

                if (rdbThep.Checked == true || rdbThepGC.Checked == true)
                    txtMa_Vt_Sp.Text = ((string)drLookup["Ma_Vt_Sp_Kcs"]).Trim();
                else
                    txtMa_Vt_Sp.Text = ((string)drLookup["Ma_Vt_Sp_Sx"]).Trim();
              
                FillData();
            }
            
        }
        void dgvPhanHoiKHVT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            //drCurrent["Is_Vt_Tt"] = true;
        }
        void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
          
        }
        void dgvPhanHoiKTCDAT_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;
           
        }
        void dgvThepTron_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsThepTron.Current).Row;
            string strColumn_Name = dgvThepTron.Columns[e.ColumnIndex].DataPropertyName;
            if (Common.Inlist(strColumn_Name, "D_MAX,D_MIN,CL_BEMAT"))
            {
                drCurrent["OVAL"] = Convert.ToDouble(drCurrent["D_MAX"]) - Convert.ToDouble(drCurrent["D_MIN"]);
            }
        }
      
       
        #endregion

        #region Update
      

		bool Update_Ct()
		{
            string strSo_Ct_LXH = rdbThepGC.Checked ? "GCPOM" : "";
            if (Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_QLCL FROM R11NGHIEMTHUSP WHERE Ca_Sx LIKE '" + cboCa.Text + "%' " +
                    " AND Ngay_Ct = '" + dteNgay_Sx.Text + "' AND Ma_Vt_Sp = '" + txtMa_Vt_Sp.Text + "' AND Xuong = '" + cboXuong.SelectedItem + "' " +
                    " AND So_Ct_LXH = '" + strSo_Ct_LXH + "' GROUP BY Duyet_QLCL")))
            {
                Common.MsgOk("Dữ liệu đã được PQLCL duyệt không cho phép sửa!!!");
                return false; 
            }

            DataTable dtSave = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R11NGHIEMTHUSP WHERE 0 =1 ");
            Hashtable htNew = new Hashtable();
            htNew.Add("NGAY_SX", dteNgay_Sx.Text);
            htNew.Add("CA_SX", cboCa.Text);
            htNew.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
            htNew.Add("XUONG", cboXuong.SelectedItem);
            htNew.Add("SO_CT_LXH", strSo_Ct_LXH);
            string strNewEdit = SQLExec.ExecuteReturnDt("SELECT * FROM R11NGHIEMTHUSP WHERE Ca_Sx LIKE '%' + @Ca_Sx + '%' " +
                    " AND Ngay_Ct = @Ngay_Sx AND Ma_Vt_Sp = @Ma_Vt_Sp AND So_Ct_LXH = @So_Ct_LXH AND Xuong = @Xuong", htNew, CommandType.Text).Rows.Count >= 1 ? "E" : "N";
            
            if (txtMa_Vt_Sp.Text.StartsWith("BD"))
            {
                Common.CopyDataColumn(dtThepThanh, dtSave, "");
               
                foreach(DataRow drThanh in dtThepThanh.Rows)
                {
                    DataRow drNew = dtSave.NewRow();
                    Common.CopyDataRow(drThanh, drNew);

                    if (strNewEdit == "N")
                    {
                        drNew["Create_Log"] = Common.GetCurrent_Log();
                        drNew["So_Luong_Dau_Mau"] = numSo_Luong_Dau_Mau.Value;
                        drNew["So_Luong_Thep_Ngan"] = numSo_Luong_Thep_Ngan.Value;
                        drNew["Note"] = txtNote.Text;
                    }
                    else
                    {
                        drNew["LastModify_Log"] = Common.GetCurrent_Log();
                        drNew["So_Luong_Dau_Mau"] = numSo_Luong_Dau_Mau.Value;
                        drNew["So_Luong_Thep_Ngan"] = numSo_Luong_Thep_Ngan.Value;
                        drNew["Note"] = txtNote.Text;
                    }
                    if (Common.CheckPermission("KCS_QLCL", enuPermission_Type.Allow_Access))
                    {
                        drNew["Duyet_QLCL"] = chkDuyet.Checked;
                        drNew["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
                    }
                    dtSave.Rows.Add(drNew);
                }
            }
            else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
            {
                Common.CopyDataColumn(dtThepTron, dtSave, "");
                foreach (DataRow drTron in dtThepTron.Rows)
                {
                    DataRow drNew = dtSave.NewRow();
                    Common.CopyDataRow(drTron, drNew);

                    if (strNewEdit == "N")
                    {
                        drNew["Create_Log"] = Common.GetCurrent_Log();
                        drNew["So_Luong_Dau_Mau"] = numSo_Luong_Dau_Mau.Value;
                        drNew["So_Luong_Thep_Ngan"] = numSo_Luong_Thep_Ngan.Value;
                        drNew["Note"] = txtNote.Text;
                    }
                    else
                    {
                        drNew["LastModify_Log"] = Common.GetCurrent_Log();
                        drNew["So_Luong_Dau_Mau"] = numSo_Luong_Dau_Mau.Value;
                        drNew["So_Luong_Thep_Ngan"] = numSo_Luong_Thep_Ngan.Value;
                        drNew["Note"] = txtNote.Text;
                    }
                    if (Common.CheckPermission("KCS_QLCL", enuPermission_Type.Allow_Access) && chkDuyet.Checked == true)
                    {
                        drNew["Duyet_QLCL"] = chkDuyet.Checked;
                        drNew["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
                    }
                    dtSave.Rows.Add(drNew);
                }
            }
            else if (txtMa_Vt_Sp.Text.StartsWith("A"))
            {
                Common.CopyDataColumn(dtPhoi, dtSave, "");
                foreach (DataRow drTron in dtPhoi.Rows)
                {
                    DataRow drNew = dtSave.NewRow();
                    Common.CopyDataRow(drTron, drNew);

                    if (strNewEdit == "N")
                    {
                        drNew["Create_Log"] = Common.GetCurrent_Log();
                        drNew["Note"] = txtNote.Text;
                    }
                    else
                    {
                        drNew["LastModify_Log"] = Common.GetCurrent_Log();
                        drNew["Note"] = txtNote.Text;
                    }

                    if (Common.CheckPermission("KCS_QLCL", enuPermission_Type.Allow_Access))
                    {
                        drNew["Duyet_QLCL"] = chkDuyet.Checked;
                        drNew["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
                    }

                    dtSave.Rows.Add(drNew);
                }
            }

            //kiểm tra trùng dữ liệu
            string strNo_Melt = string.Empty;
            string strTry_ID = string.Empty;
            string strTry_ID_Goc = string.Empty;
            string strXuong = string.Empty;
            string strFilter = string.Empty;
            string strDon_Trong = string.Empty;
            string strGhi_Chu = string.Empty;
            foreach (DataRow dr in dtSave.Rows)
            {
                strNo_Melt = dr["No_Melt"].ToString();
                strTry_ID = dr["Try_ID"].ToString();
                strTry_ID_Goc = dr["Try_ID_Goc"].ToString();
                strXuong = dr["Xuong"].ToString();
                strSo_Ct_LXH = dr["So_Ct_LXH"].ToString();
                strFilter = "No_Melt = '"+ strNo_Melt + "' AND Try_ID = '" + strTry_ID + "' AND Try_ID_Goc = '" + strTry_ID_Goc + "'"+
                    " AND Xuong = '" + strXuong + "'  AND So_Ct_LXH = '" + strSo_Ct_LXH + "' AND Don_Trong = '" + strDon_Trong + "' AND Ghi_Chu = '" + strGhi_Chu + "' ";
                if (dtSave.Select(strFilter).Length > 1)
                {
                    Common.MsgOk("Dữ liệu đang bị trùng thông tin. Báo lại PCNTT để kiểm tra trước khi lưu.");
                    return false;
                }
            }

            Update(strNewEdit, dtSave);
			return true;
		}

        private void Update(string strNewEdit, DataTable dtImport)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();


            //#region Update chứng từ
            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@strNew_Edit", strNewEdit);
            sqlCom.Parameters.AddWithValue("@Ngay_Ct", Library.StrToDate(dteNgay_Sx.Text));
            sqlCom.Parameters.AddWithValue("@Ca_Sx", cboCa.Text);
            sqlCom.Parameters.AddWithValue("@Ma_Vt_Sp", txtMa_Vt_Sp.Text);
            sqlCom.Parameters.AddWithValue("@Xuong", cboXuong.SelectedItem);
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_KCSNTSP";


            //Tạo Table cho TVP_CtSO
            paraCt.TypeName = "TVP_KCSNTSP";
            paraCt.Value = Voucher.GetTVPValue("R11NGHIEMTHUSP", "TVP_KCSNTSP", dtImport);
            sqlCom.Parameters.Add(paraCt);


            //
            try
            {
                sqlCom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.Clear();
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
               
            }
        }
		bool Save()
		{
            
            if (!Update_Ct())
                return false;

			return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.Is_Accept = true;
                Common.MsgOk("Đã cập nhật xong dữ liệu");
			}
		}

		

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
        }
        void btDel_Data_Click(object sender, EventArgs e)
        {

            string strColumnList = "D_MAX,D_MIN,CL_BEMAT,SO_VET_ND,CHIEU_DAI,KHAC,DON_TRONG,GHI_CHU";

            if (txtMa_Vt_Sp.Text.StartsWith("BD"))
            {
                foreach (string strColumn in strColumnList.Split(','))
                {
                    if (dgvThepThanh.Columns.Contains(strColumn))
                        foreach (DataRow dr in dtThepThanh.Rows)
                            if (Common.Inlist(strColumn,"CL_BEMAT,DON_TRONG,GHI_CHU"))
                                dr[strColumn] = "";
                            else
                                dr[strColumn] = 0;

                }
            }
            else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
            {
                foreach (string strColumn in strColumnList.Split(','))
                {
                    if (dgvThepTron.Columns.Contains(strColumn))
                        foreach (DataRow dr in dtThepTron.Rows)
                            if (Common.Inlist(strColumn, "CL_BEMAT,DON_TRONG,GHI_CHU"))
                                dr[strColumn] = "";
                            else
                                dr[strColumn] = 0;

                }
            }
            else if (txtMa_Vt_Sp.Text.StartsWith("A"))
            {
                foreach (string strColumn in strColumnList.Split(','))
                {
                    if (dgvPhoi.Columns.Contains(strColumn))
                        foreach (DataRow dr in dtPhoi.Rows)
                            if (Common.Inlist(strColumn, "CL_BEMAT,DON_TRONG,GHI_CHU"))
                                dr[strColumn] = "";
                            else
                                dr[strColumn] = 0;

                }
            }
        }
        void btDuyet_PXL_Click(object sender, EventArgs e)
        {
            if (bdsPhoi.Position < 0)
                return;
            

            dgvThepThanh.ReadOnly = true;
            dgvThepTron.ReadOnly = true;
            dgvPhoi.ReadOnly = true;

            Voucher.DuyetNghiemThu("R11NGHIEMTHUSP", txtMa_Vt_Sp.Text, Convert.ToDateTime(dteNgay_Sx.Text), cboCa.Text, "DUYET_QLCL", "DUYET_PXL", chkDuyet.Checked, "DUYET_LOG_PXL");
            FillData();
            //DataTable dtSave = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R11NGHIEMTHUSP WHERE 0 =1 ");
            //if (txtMa_Vt_Sp.Text.StartsWith("A"))
            //{
            //    Common.CopyDataColumn(dtPhoi, dtSave, "");
            //    foreach (DataRow drThanh in dtPhoi.Rows)
            //    {
            //        DataRow drNew = dtSave.NewRow();
            //        Common.CopyDataRow(drThanh, drNew);
            //        drNew["Duyet_PXL"] = chkDuyet.Checked;
            //        drNew["Duyet_Log_PXL"] = Common.GetCurrent_Log();
            //        dtSave.Rows.Add(drNew);

            //        drThanh["Duyet_PXL"] = chkDuyet.Checked;
            //        drThanh["Duyet_Log_PXL"] = Common.GetCurrent_Log();
            //    }

            //}
            //Update("E", dtSave);

            if(chkDuyet.Checked == true)
                Common.MsgOk("Bạn đã duyệt xong");
            else
                Common.MsgOk("Bạn đã gỡ duyệt xong");
        }

        void btDuyet_PXC_Click(object sender, EventArgs e)
        {
            if (bdsThepThanh.Position < 0 && bdsThepTron.Position < 0 && bdsPhoi.Position < 0)
                return;

            chkDuyet.Visible = true;
            
            dgvThepThanh.ReadOnly = true;
            dgvThepTron.ReadOnly = true;
            dgvPhoi.ReadOnly = true;

            DataTable dtSave = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R11NGHIEMTHUSP WHERE 0 =1 ");
            if (txtMa_Vt_Sp.Text.StartsWith("B"))
            {

                Voucher.DuyetNghiemThu("R11NGHIEMTHUSP", txtMa_Vt_Sp.Text, Convert.ToDateTime(dteNgay_Sx.Text), cboCa.Text, "DUYET_QLCL", "DUYET_PXC", chkDuyet.Checked, "DUYET_LOG_PXC");
                FillData();
            //    Common.CopyDataColumn(dtThepThanh, dtSave, "");
            //    foreach (DataRow drThanh in dtThepThanh.Rows)
            //    {
            //        DataRow drNew = dtSave.NewRow();
            //        Common.CopyDataRow(drThanh, drNew);
            //        drNew["Duyet_PXC"] = chkDuyet.Checked;
            //        drNew["Duyet_Log_PXC"] = Common.GetCurrent_Log();
            //        dtSave.Rows.Add(drNew);

            //        drThanh["Duyet_PXC"] = chkDuyet.Checked;
            //        drThanh["Duyet_Log_PXC"] = Common.GetCurrent_Log();
            //    }

            //}
            //else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
            //{
            //    Common.CopyDataColumn(dtThepTron, dtSave, "");
            //    foreach (DataRow drThanh in dtThepTron.Rows)
            //    {
            //        DataRow drNew = dtSave.NewRow();
            //        Common.CopyDataRow(drThanh, drNew);
            //        drNew["Duyet_PXC"] = chkDuyet.Checked;
            //        drNew["Duyet_Log_PXC"] = Common.GetCurrent_Log();
            //        dtSave.Rows.Add(drNew);

            //        drThanh["Duyet_PXC"] = chkDuyet.Checked;
            //        drThanh["Duyet_Log_PXC"] = Common.GetCurrent_Log();
            //    }

            }
            else if (txtMa_Vt_Sp.Text.StartsWith("A"))
            {
                Voucher.DuyetNghiemThu("R11NGHIEMTHUSP", txtMa_Vt_Sp.Text, Convert.ToDateTime(dteNgay_Sx.Text), cboCa.Text, "DUYET_PXL", "DUYET_PXC", chkDuyet.Checked, "DUYET_LOG_PXC");
                FillData();
                //Common.CopyDataColumn(dtPhoi, dtSave, "");
                //foreach (DataRow drThanh in dtPhoi.Rows)
                //{
                //    DataRow drNew = dtSave.NewRow();
                //    Common.CopyDataRow(drThanh, drNew);
                //    drNew["Duyet_PXC"] = chkDuyet.Checked;
                //    drNew["Duyet_Log_PXC"] = Common.GetCurrent_Log();
                //    dtSave.Rows.Add(drNew);

                //    drThanh["Duyet_PXC"] = chkDuyet.Checked;
                //    drThanh["Duyet_Log_PXC"] = Common.GetCurrent_Log();
                //}

            }
            //Update("E", dtSave);
            if (chkDuyet.Checked == true)
                Common.MsgOk("Bạn đã duyệt xong");
            else
                Common.MsgOk("Bạn đã gỡ duyệt xong");

        }

        void btDuyet_PQLCL_Click(object sender, EventArgs e)
        {
            if (bdsThepThanh.Position < 0 && bdsThepTron.Position < 0 && bdsPhoi.Position < 0)
                return;
            Voucher.DuyetNghiemThu("R11NGHIEMTHUSP", txtMa_Vt_Sp.Text, Convert.ToDateTime(dteNgay_Sx.Text), cboCa.Text, "", "DUYET_QLCL", chkDuyet.Checked, "DUYET_LOG_QLCL");
            FillData();
        
            //DataTable dtSave = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R11NGHIEMTHUSP WHERE 0 =1 ");

            //if(txtMa_Vt_Sp.Text.StartsWith("BD"))
            //{
            //    Common.CopyDataColumn(dtThepThanh, dtSave, "");
            //    foreach (DataRow drThanh in dtThepThanh.Rows)
            //    {
            //        DataRow drNew = dtSave.NewRow();
            //        Common.CopyDataRow(drThanh, drNew);
            //        drNew["Duyet_QLCL"] = chkDuyet.Checked;
            //        drNew["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
            //        dtSave.Rows.Add(drNew);

            //        drThanh["Duyet_QLCL"] = chkDuyet.Checked;
            //        drThanh["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
            //    }

            //}
            //else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
            //{
            //    Common.CopyDataColumn(dtThepTron, dtSave, "");
            //    foreach (DataRow drThanh in dtThepTron.Rows)
            //    {
            //        DataRow drNew = dtSave.NewRow();
            //        Common.CopyDataRow(drThanh, drNew);
            //        drNew["Duyet_QLCL"] = chkDuyet.Checked;
            //        drNew["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
            //        dtSave.Rows.Add(drNew);

            //        drThanh["Duyet_QLCL"] = chkDuyet.Checked;
            //        drThanh["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
            //    }

            //}
            //else if (txtMa_Vt_Sp.Text.StartsWith("A"))
            //{
            //    Common.CopyDataColumn(dtPhoi, dtSave, "");
            //    foreach (DataRow drThanh in dtPhoi.Rows)
            //    {
            //        DataRow drNew = dtSave.NewRow();
            //        Common.CopyDataRow(drThanh, drNew);
            //        drNew["Duyet_QLCL"] = chkDuyet.Checked;
            //        drNew["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
            //        dtSave.Rows.Add(drNew);

            //        drThanh["Duyet_QLCL"] = chkDuyet.Checked;
            //        drThanh["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
            //    }

            //}
            //Update("E", dtSave);
            if (chkDuyet.Checked == true)
                Common.MsgOk("Bạn đã duyệt xong");
            else
                Common.MsgOk("Bạn đã gỡ duyệt xong");
        }
        
        void btDuyet_PKD_Click(object sender, EventArgs e)
        {
            if (bdsThepThanh.Position < 0 && bdsThepTron.Position < 0)
                return;
            Voucher.DuyetNghiemThu("R11NGHIEMTHUSP", txtMa_Vt_Sp.Text, Convert.ToDateTime(dteNgay_Sx.Text), cboCa.Text, "DUYET_PXC", "DUYET_PKD", chkDuyet.Checked, "DUYET_LOG_PKD");
            FillData();
           //CODE CŨ
            //DataTable dtSave = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R11NGHIEMTHUSP WHERE 0 =1 ");
            //if (txtMa_Vt_Sp.Text.StartsWith("BD"))
            //{
            //    Common.CopyDataColumn(dtThepThanh, dtSave, "");
            //    foreach (DataRow drThanh in dtThepThanh.Rows)
            //    {
            //        DataRow drNew = dtSave.NewRow();
            //        Common.CopyDataRow(drThanh, drNew);
            //        drNew["Duyet_PKD"] = chkDuyet.Checked;
            //        drNew["DUYET_LOG_QLCL"] = Common.GetCurrent_Log();
            //        dtSave.Rows.Add(drNew);

            //        drThanh["Duyet_QLCL"] = chkDuyet.Checked;
            //        drThanh["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
            //    }

            //}
            //else if (txtMa_Vt_Sp.Text.StartsWith("BR"))
            //{
            //    Common.CopyDataColumn(dtThepTron, dtSave, "");
            //    foreach (DataRow drThanh in dtThepTron.Rows)
            //    {
            //        DataRow drNew = dtSave.NewRow();
            //        Common.CopyDataRow(drThanh, drNew);
            //        drNew["Duyet_PQLCL"] = chkDuyet.Checked;
            //        drNew["DUYET_LOG_QLCL"] = Common.GetCurrent_Log();
            //        dtSave.Rows.Add(drNew);

            //        drThanh["Duyet_QLCL"] = chkDuyet.Checked;
            //        drThanh["Duyet_Log_QLCL"] = Common.GetCurrent_Log();
            //    }

            //}
            //Update("E", dtSave);
        }
        #endregion
        void frmNghiem_Thu_KCS_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        
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

    }

}