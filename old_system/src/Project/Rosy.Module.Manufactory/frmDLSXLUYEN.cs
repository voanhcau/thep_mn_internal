using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using RosySystem.Control;
using RosyModule;
using System.Data.SqlClient;
using RosySystem.Customize;
using RosySystem.Public;
using System.IO;

namespace RosyModule.Manufactory
{
	public partial class frmDLSXLUYEN : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
        object objActive = null;

		DataSet dsVoucher = new DataSet();
		DataTable dtEditPh;
        DataTable dtEditPh_Dest;
		DataTable dtEditCt;
        DataTable dtEditCt_SuCo;
        DataTable dtEditCt_TSQT;
        DataTable dtEditCt_THHB;
        DataTable dtEditCt_THTB;
        DataTable dtEditCt_THCN;
        DataTable dtEditCt_GiaoCa;
        DataTable dtEditCt_KienNghi;
        
        DataTable dtEditCt_NhapPhoi;
        

        DataRow drEditPh;
		DataRow drEditCt;
        DataRow drEditCt_SuCo;
        DataRow drEditCt_TSQT;
        DataRow drEditCt_THCN;
        DataRow drEditCt_THTB;
        DataRow drEditCt_THHB;
        DataRow drEditCt_GiaoCa;
        DataRow drEditCt_KienNghi;
       
        DataRow drEditCt_NhapPhoi;
        

		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
        BindingSource bdsEditCt_SuCo = new BindingSource();
        BindingSource bdsEditCt_TSQT = new BindingSource();
        BindingSource bdsEditCt_THCN = new BindingSource();
        BindingSource bdsEditCt_THTB = new BindingSource();
        BindingSource bdsEditCt_THHB = new BindingSource();
        BindingSource bdsEditCt_NhapPhoi = new BindingSource();
        BindingSource bdsEditCt_GiaoCa = new BindingSource();
        BindingSource bdsEditCt_KienNghi = new BindingSource();
        

		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;

        string strStt_Org = string.Empty;
        string strStt = string.Empty;
        string strSo_Ct = string.Empty;
        public string strLoai_Sx = "LUYEN";
        string strMa_Dt_CbNv = string.Empty;
		#endregion

        public frmDLSXLUYEN()
		{
			InitializeComponent();

            dgvTHCN.Enter += new EventHandler(dgvTHCN_Enter);
            dgvTHHB.Enter += new EventHandler(dgvTHHB_Enter);
            dgvTHTB.Enter += new EventHandler(dgvTHTB_Enter);
            dgvSuCo.Enter += new EventHandler(dgvSuCo_Enter);
            dgvTSQT.Enter+=new EventHandler(dgvTSQT_Enter);
            dgvGiaoCa.Enter += new EventHandler(dgvGiaoCa_Enter);
            dgvKienNghi.Enter += new EventHandler(dgvKienNghi_Enter);
            dgvNhapPhoiKCS.Enter += new EventHandler(dgvNhapPhoiKCS_Enter);


            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);           
            cboCa_Sx.SelectedValueChanged += new EventHandler(cboCa_Sx_SelectedValueChanged);
            cboCa.SelectedIndexChanged += new EventHandler(cboCa_SelectedIndexChanged);
           
            this.btFirst.Click += new EventHandler(btFirst_Click);
			this.btNext.Click += new EventHandler(btNext_Click);
			this.btPrevious.Click += new EventHandler(btPrevious_Click);
			this.btLast.Click += new EventHandler(btLast_Click);


          
            this.btTao_Ca.Click += new EventHandler(btTao_Ca_Click);
            this.btKet_Thuc_Ca.Click += new EventHandler(btKet_Thuc_Ca_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
            this.btImport.Click += new EventHandler(btImport_Click);
            this.btImport_All.Click += new EventHandler(btImport_All_Click);

            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
		}

        

        new public void Load()
		{
            DateTime dteNgay_Ct2 = DateTime.Now;
            DateTime dteNgay_Ct1 = dteNgay_Ct2.AddDays((-dteNgay_Ct2.Day) + 1);

            this.dteNgay_Ct1.Text = Library.DateToStr(dteNgay_Ct1);
            this.dteNgay_Ct2.Text = Library.DateToStr(dteNgay_Ct2);

			this.Build();
			this.FillData();
			this.Init_Ct();
            LoadDicName();

			this.Show();
		}

        private void LoadDicName()
        {
           ////Truong ca
           // if (strMa_Dt_CbNv.Trim() != string.Empty)
           //     lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);
           // else
           //     lbtTen_Dt_CbNv.Text = string.Empty;

        }
		private void Build()
		{
            dgvTHHB.bSortMode = false;
            dgvTHHB.strZone = "THSXLUYEN";
            dgvTHHB.BuildGridView();
          

            dgvTHCN.bSortMode = false;
            dgvTHCN.strZone = "THSXLUYEN";
            dgvTHCN.BuildGridView();

            dgvTHTB.bSortMode = false;
            dgvTHTB.strZone = "THSXLUYEN";
            dgvTHTB.BuildGridView();

            dgvGiaoCa.bSortMode = false;
            dgvGiaoCa.strZone = "THSXLUYEN";
            dgvGiaoCa.BuildGridView();


            dgvKienNghi.bSortMode = false;
            dgvKienNghi.strZone = "THSXLUYEN";
            dgvKienNghi.BuildGridView();

            dgvSuCo.bSortMode = false;
            dgvSuCo.strZone = "SUCO_SXLUYEN";
            dgvSuCo.BuildGridView();

            dgvTSQT.bSortMode = false;
            dgvTSQT.strZone = "TSQTLUYEN";
            dgvTSQT.BuildGridView();

            dgvNhapPhoiKCS.bSortMode = false;
            dgvNhapPhoiKCS.strZone = "PHOILUYEN";
            dgvNhapPhoiKCS.BuildGridView();

            

            this.DataGridView_Language();

         

            foreach (DataGridViewColumn dgvc in dgvSuCo.Columns)
                dgvc.ReadOnly = true;

        
		}

		private void DataGridView_Language()
		{
		
			
		}

		private void Init_Ct()
		{

            //btInherit.Enabled = false;
          
		}
        private void FillData(string strStt_Current)
        {
            Hashtable ht = new Hashtable();


            ht.Add("STT", strStt_Current);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLSXLUYEN", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;
           
            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }
            Hashtable ht1 = new Hashtable();
            ht1.Add("STT", strStt_Current);
            DataTable dtLoadCombo = SQLExec.ExecuteReturnDt("SELECT Stt, Ca_SX +' '+ STR(DAY(T1.Ngay_Sx),2) AS Ca_SX FROM R80PH_QLSX T1 JOIN R81DMCASX T2 ON T1.Ngay_Sx = T2.Ngay_Sx AND T1.Ca_SX = T2.Ca WHERE T1.Stt = @Stt AND Loai_SX = 'LUYEN' ORDER BY T1.Ngay_Sx, Kip DESC", ht1, CommandType.Text);
            cboCa_Sx.DataSource = dtLoadCombo;
            cboCa_Sx.ValueMember = "STT";
            cboCa_Sx.DisplayMember = "CA_SX";
            LoadDicName();
            //LoadCombo();
            //this.ExportControl = dgvEditCt;
            strStt = strStt_Current;
        }
		private void FillData()
		{
            Hashtable ht = new Hashtable();
         
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("LOAI_SX", "LUYEN");
            ht.Add("CA_SX", cboCa_Sx.Text);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLSXLUYEN", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }

            LoadCombo();
            LoadDicName();
            //this.ExportControl = dgvEditCt;
		}
        private void LoadCombo()
        {
            LoadDicName();
            Hashtable ht1 = new Hashtable();
            ht1.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht1.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht1.Add("LOAI_SX", "LUYEN");

            DataTable dtLoadCombo = SQLExec.ExecuteReturnDt("SELECT Stt, Ca_SX +' '+ STR(DAY(T1.Ngay_Sx),2) AS Ca_SX FROM R80PH_QLSX T1 JOIN R81DMCASX T2 ON T1.Ngay_Sx = T2.Ngay_Sx AND T1.Ca_SX = T2.Ca WHERE T1.Ngay_Sx <= @Ngay_Ct2 AND T1.Ngay_Sx >= @Ngay_Ct1 AND Loai_Sx = @Loai_Sx GROUP BY Stt, Ca_SX, T1.Ngay_Sx, Kip ORDER BY T1.Ngay_Sx DESC, Kip DESC", ht1, CommandType.Text);
            cboCa_Sx.DataSource = dtLoadCombo;
            cboCa_Sx.ValueMember = "STT";
            cboCa_Sx.DisplayMember = "CA_SX";

        }
      
        private void FillData_Voucher_Ph()
        {
            if (!string.IsNullOrEmpty(strStt))
            {
                DataRow[] arrdrEditPh_Dest = dtEditPh.Select("Stt = '" + strStt + "'");
                if (arrdrEditPh_Dest.Length > 0 && arrdrEditPh_Dest.Length == 1)
                {
                    if (this.dtEditPh_Dest != null)
                        this.dtEditPh_Dest.Rows.Clear();

                    this.dtEditPh_Dest = dtEditPh.Clone();

                    foreach (DataRow dr in arrdrEditPh_Dest)
                        this.dtEditPh_Dest.ImportRow(dr);

                    this.bdsEditPh.Position = this.bdsEditPh.Find("STT", strStt);
                    this.lbtRecorde.Text = this.bdsEditPh.Position + 1 + "/" + this.bdsEditPh.Count;

                    this.ScaterMemvar_Voucher_Edit(this.dtEditPh_Dest.Rows[0]);
                    this.FillData_Voucher_Ct();
                }
            }
            else
                this.Reset_Voucher_Edit();
        }
        private void FillData_Voucher_Ct()
        {
            Hashtable ht = new Hashtable();

            ht.Add("STT", this.strStt);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLSXLUYEN", ht, CommandType.StoredProcedure);

            dtEditCt_SuCo = dsVoucher.Tables[1];
            bdsEditCt_SuCo.DataSource = dtEditCt_SuCo;
            dgvSuCo.DataSource = bdsEditCt_SuCo;

            dtEditCt_TSQT = dsVoucher.Tables[2];
            bdsEditCt_TSQT.DataSource = dtEditCt_TSQT;
            dgvTSQT.DataSource = bdsEditCt_TSQT;
            if (dtEditCt_TSQT != null)
                numSo_Phut_Ngung.Value = Common.SumDCValue(dtEditCt_TSQT, "SuCoCN", "") + Common.SumDCValue(dtEditCt_TSQT, "SuCoCNBB", "") + Common.SumDCValue(dtEditCt_TSQT, "SuCoTB", "") + Common.SumDCValue(dtEditCt_TSQT, "SuCoKhac", "");
            dtEditCt_NhapPhoi = dsVoucher.Tables[3];
            bdsEditCt_NhapPhoi.DataSource = dtEditCt_NhapPhoi;
            dgvNhapPhoiKCS.DataSource = bdsEditCt_NhapPhoi;
            if (dtEditCt_NhapPhoi != null)
            {
                numSo_Luong_KCS.Value = Common.SumDCValue(dtEditCt_NhapPhoi, "So_Luong", "");
                numSo_Luong_Cay_KCS.Value = Common.SumDCValue(dtEditCt_NhapPhoi, "So_Luong_Cay", "");
            }

            dtEditCt_THCN = dsVoucher.Tables[4];
            bdsEditCt_THCN.DataSource = dtEditCt_THCN;
            dgvTHCN.DataSource = bdsEditCt_THCN;

            dtEditCt_THHB = dsVoucher.Tables[5];
            bdsEditCt_THHB.DataSource = dtEditCt_THHB;
            dgvTHHB.DataSource = bdsEditCt_THHB;

            dtEditCt_THTB = dsVoucher.Tables[6];
            bdsEditCt_THTB.DataSource = dtEditCt_THTB;
            dgvTHTB.DataSource = bdsEditCt_THTB;

            dtEditCt_GiaoCa = dsVoucher.Tables[7];
            bdsEditCt_GiaoCa.DataSource = dtEditCt_GiaoCa;
            dgvGiaoCa.DataSource = bdsEditCt_GiaoCa;

            dtEditCt_KienNghi = dsVoucher.Tables[8];
            bdsEditCt_KienNghi.DataSource = dtEditCt_KienNghi;
            dgvKienNghi.DataSource = bdsEditCt_KienNghi;

           
        }
        private void Reset_Voucher_Edit()
        {

            cboCa.Text = txtTen_Dt_CbNv_Vang.Text = txtTinh_Trang_ATLD.Text = txtTinh_Trang_CLSP.Text = txtMa_Dt_CbNv.Text = string.Empty;// = txtDanh_Gia_Ca.Text = txtTinh_Trang_Giao_Ca.Text 
            numSL_Gang.Value = numSL_Lieu_HMS.Value = numSL_Lieu_Khac.Value = numSL_Lieu_Noi.Value = numSL_Lieu_TauVun.Value = numLech_Test_CMM.Value = 
                    numSo_Luong_Cay_KCS.Value = numSo_Luong_KCS.Value = numSo_Phut_Ngung.Value = 0;
          
            if (dtEditCt_SuCo != null)
                dtEditCt_SuCo.Rows.Clear();
            if (dtEditCt_TSQT != null)
                dtEditCt_TSQT.Rows.Clear();
            if (dtEditCt_GiaoCa != null)
                dtEditCt_GiaoCa.Rows.Clear();
            if (dtEditCt_KienNghi != null)
                dtEditCt_KienNghi.Rows.Clear(); 
            if (dtEditCt_THCN != null)
                dtEditCt_THCN.Rows.Clear();
            if (dtEditCt_THTB != null)
                dtEditCt_THTB.Rows.Clear();
            if (dtEditCt_THHB != null)
                dtEditCt_THHB.Rows.Clear();
          
        }
	
        private void ScaterMemvar_Voucher_Edit(DataRow drEditPh_Dest)
        {
            strMa_Dt_CbNv = (string)drEditPh_Dest["Ma_Dt_CbNv"];
            dteNgay_Sx.Text = Library.DateToStr(Convert.ToDateTime(drEditPh_Dest["Ngay_Sx"]));
            cboCa.Text = (string)drEditPh_Dest["Ca_Sx"];
           
            txtTen_Dt_CbNv_Vang.Text = (string)drEditPh_Dest["Ten_Dt_CbNv_Vang"];
            txtMa_Dt_CbNv.Text = (string)drEditPh_Dest["Ma_Dt_CbNv"];
            //txtTinh_Trang_Giao_Ca.Text = (string)drEditPh_Dest["Tinh_Trang_Giao_Ca"];
            //txtDanh_Gia_Ca.Text = (string)drEditPh_Dest["Danh_Gia_Ca"];
            txtTinh_Trang_ATLD.Text = (string)drEditPh_Dest["Tinh_Trang_ATLD"];
            txtTinh_Trang_CLSP.Text = (string)drEditPh_Dest["Tinh_Trang_CLSP"];
            numLech_Test_CMM.Value = Convert.ToDouble(drEditPh_Dest["Lech_Test_CMM"]);
            numSL_Gang.Value = Convert.ToDouble(drEditPh_Dest["Sl_Gang"]);
            //numSL_GangCt.Value = Convert.ToDouble(drEditPh_Dest["Sl_GangCt"]);
            numSL_Lieu_HMS.Value = Convert.ToDouble(drEditPh_Dest["SL_Lieu_HMS"]);
            numSL_Lieu_TauVun.Value = Convert.ToDouble(drEditPh_Dest["SL_Lieu_TauVun"]);
            numSL_Lieu_Khac.Value = Convert.ToDouble(drEditPh_Dest["SL_Lieu_Khac"]);
            numSL_Lieu_Noi.Value = Convert.ToDouble(drEditPh_Dest["SL_Lieu_Noi"]);

         
        }
        
        
        

        void btTao_Ca_Click(object sender, EventArgs e)
        {
            enuNew_Edit_Voucher = enuEdit.New;
            Reset_Voucher_Edit();
            dteNgay_Sx.Focus();

            dteNgay_Sx.Text = Library.DateToStr(DateTime.Now);
            dteNgay_Sx.ReadOnly = false;

            txtTen_Dt_CbNv_Vang.ReadOnly = false;

            strStt = Common.GetNewStt("11", true);
            btSave.Enabled = true;
        }

        void btKet_Thuc_Ca_Click(object sender, EventArgs e)
        {
            enuNew_Edit_Voucher = enuEdit.Edit;
            dteNgay_Sx.ReadOnly = false;

            txtTen_Dt_CbNv_Vang.ReadOnly = false;
       
         
            //txtTinh_Trang_Giao_Ca.ReadOnly = false;

            btSave.Enabled = true;
        }
        void ImportAll()
        {
            //Khai báo biến
            DataTable dtImport;
            string strPathFile = Path.Combine(Parameters.GetParaValue("PATH_IMPORT_DLSX").ToString(), "Import_ALL.XLSX");
            int RowHearder = 1; int ColEnd = 0;
            int FromRow = 2; int ToRow = 100;
            
            int i = 1; int j = 3;

           //Chuẩn bị
            while (i <= j)
            {
                if (i == 1) //Sheet 1 DLSX
                {

                    ColEnd = 70;
                    dtImport = Voucher.ReadExcelToFrom(strPathFile, 1, Convert.ToInt32(RowHearder), Convert.ToInt32(ColEnd), Convert.ToInt32(FromRow), Convert.ToInt32(ToRow));

                    //Xử lý DL Import
                    if (dtImport != null)
                    {
                        //Set giá trị
                        if (dtImport.Columns.Contains("MgOball"))
                        {
                            string strColumnName = string.Empty;
                            string strColumnType = string.Empty;
                            string strSQLExec = string.Empty;
                            foreach (DataColumn dc in dtImport.Columns)
                            {
                                strColumnName = dc.ColumnName;
                                strSQLExec = "select name from sys.columns where  OBJECT_NAME(OBJECT_ID) = 'R11DLSXLUYEN' AND system_type_id = 60 AND name = '" + strColumnName + "'";
                                strColumnType = (string)SQLExec.ExecuteReturnValue(strSQLExec);
                                if (strColumnName == strColumnType)
                                {
                                    foreach (DataRow dr in dtImport.Rows)
                                        if (dr[strColumnName] == null || dr[strColumnName] == "" || dr[strColumnName] == string.Empty)
                                            dr[strColumnName] = 0;
                                }
                            }

                        }
                        //lưu vào CSDL
                        UpdateDLSX(dtImport);
                        dtImport.Clear();
                    }
                }
                else if (i == 2)//Sheet 2 DLSC
                {
                    ColEnd = 6; ToRow = 150;
                    dtImport = Voucher.ReadExcelToFrom(strPathFile, 2, Convert.ToInt32(RowHearder), Convert.ToInt32(ColEnd), Convert.ToInt32(FromRow), Convert.ToInt32(ToRow));
                    //lưu vào CSDL
                    UpdateSuCo(dtImport);
                    dtImport.Clear();
                }

                else if (i == 3)//Sheet 3 DLCHUNG
                {
                    ColEnd = 2; ToRow = 150;
                    dtImport = Voucher.ReadExcelToFrom(strPathFile, 3, Convert.ToInt32(RowHearder), Convert.ToInt32(ColEnd), Convert.ToInt32(FromRow), Convert.ToInt32(ToRow));
                    //lưu vào CSDL
                    UpdateTHSXLUYEN(dtImport);
                    dtImport.Clear();
                }
                i = i + 1;
            }
        }
       void UpdateTHSXLUYEN(DataTable dtImport)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@strNew_Edit", "N");
            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@STT", strStt);

            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_THSXLUYEN";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_THSXLUYEN";
            paraCt.Value = Voucher.GetTVPValue("R11THSXLUYEN", "TVP_THSXLUYEN", dtImport);
            sqlCom.Parameters.Add(paraCt);

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
        void ImportTHSXLUYEN()
        {
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("THSX");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                UpdateTHSXLUYEN(frmImport.dtImport);
            }
        }
        void UpdateDLSX(DataTable dtImport)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@strNew_Edit", "N");
            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@STT", strStt);
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_DLSXLUYEN";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_DLSXLUYEN";
            paraCt.Value = Voucher.GetTVPValue("R11DLSXLUYEN", "TVP_DLSXLUYEN", dtImport);
            sqlCom.Parameters.Add(paraCt);

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
       
        void ImportDLSX()
        {
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("DLSX");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                UpdateDLSX(frmImport.dtImport);
            }
        }
        void UpdateSuCo(DataTable dtImport)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@strNew_Edit", "N");
            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@STT", strStt);
            
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_SUCOLUYEN";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_SUCOLUYEN";
            paraCt.Value = Voucher.GetTVPValue("R11SUCOLUYEN", "TVP_SUCOLUYEN", dtImport);
            sqlCom.Parameters.Add(paraCt);

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
        void ImportSuCo()
        {
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("SUCO");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                UpdateSuCo(frmImport.dtImport);
            }
        }
        void btImport_All_Click(object sender, EventArgs e)
        {
            if (Common.MsgYes_No("Bạn có muốn import dữ liệu trong ca " + cboCa.Text + "", "Y"))
            {
                ImportAll();
                Common.MsgOk("Đã hoàn thành. Xin cảm ơn !!! ");
            }
            else
                Common.MsgOk("Bạn đã không import dữ liệu. Xin cảm ơn !!! ");
            FillData(strStt);
        }

        void btImport_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvTHCN || this.objActive == dgvTHHB || this.objActive == dgvTHTB)
                ImportTHSXLUYEN();
            else if(this.objActive == dgvTSQT)
                ImportDLSX();
            else if (this.objActive == dgvSuCo)
                ImportSuCo();
            
            FillData(strStt);
            //bdsEditPh.mo
        }
        void btSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Common.MsgOk("Cập nhật thành công!");

                btSave.Enabled = false;
            }
        }
		bool Save()
		{
            string strSQLEXEC = string.Empty;
            Hashtable ht = new Hashtable();

            if (enuNew_Edit_Voucher == enuEdit.New)
            {
                if (cboCa.Text == "")
                {
                    Common.MsgCancel("Bạn phải chọn ca làm việc");
                    return false;
                }
                if (cboCa.Text != "" && (DataTool.SQLCheckExist("R80PH_QLSX", new string[] { "Ngay_Sx", "Ca_Sx", "Loai_Sx" }, new object[] { dteNgay_Sx.Text, cboCa.Text, "LUYEN" })))
                {
                    Common.MsgCancel("Ca " + cboCa.Text + " ngày " + dteNgay_Sx.Text + " đã được tạo. Vui lòng chọn ca làm việc khác !!!");
                    return false;
                }
                ht.Add("STT", strStt);
                ht.Add("LOAI_SX", "LUYEN");
                ht.Add("NGAY_SX", dteNgay_Sx.Text);
                ht.Add("CA_SX", cboCa.Text);
                
                ht.Add("TEN_DT_CBNV_VANG", txtTen_Dt_CbNv_Vang.Text);
                

                ht.Add("SL_LIEU_NOI", numSL_Lieu_Noi.Value);
                ht.Add("SL_LIEU_HMS", numSL_Lieu_HMS.Value);
                ht.Add("SL_LIEU_TAUVUN", numSL_Lieu_TauVun.Value);
                ht.Add("SL_GANG", numSL_Gang.Value);
                //ht.Add("SL_GANGCT", numSL_GangCt.Value);
                ht.Add("SL_LIEU_KHAC", numSL_Lieu_Khac.Value);
                ht.Add("LECH_TEST_CMM", numLech_Test_CMM.Value);
                ht.Add("MA_DT_CBNV", txtMa_Dt_CbNv.Text);
                ht.Add("TINH_TRANG_ATLD", txtTinh_Trang_ATLD.Text);
                ht.Add("TINH_TRANG_CLSP", txtTinh_Trang_CLSP.Text);
                ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                ht.Add("MA_DVCS", Element.sysMa_DvCs);

                strSQLEXEC = "INSERT INTO R80PH_QLSX(Stt, Loai_Sx, Ngay_Sx, Ca_SX, Ten_Dt_CbNv_Vang, Sl_Lieu_Noi, Sl_Lieu_HMS, Sl_Lieu_TauVun, Sl_Gang, Sl_Lieu_Khac, Lech_Test_CMM, Tinh_Trang_ATLD, Tinh_Trang_CLSP, Ma_Dt_CbNv, Create_Log, Ma_DvCs) " +
                                "VALUES (@Stt, @Loai_Sx, @Ngay_Sx, @Ca_SX, @Ten_Dt_CbNv_Vang, @Sl_Lieu_Noi, @Sl_Lieu_HMS, @Sl_Lieu_TauVun, @Sl_Gang, @Sl_Lieu_Khac, @Lech_Test_CMM, @Tinh_Trang_ATLD, @Tinh_Trang_CLSP, @Ma_Dt_CbNv, @Create_Log, @Ma_DvCs)";
            }
            else
            {
                

                ht.Add("STT", strStt);
                ht.Add("NGAY_SX", dteNgay_Sx.Text);
                ht.Add("CA_SX", cboCa.Text);
          
                ht.Add("TEN_DT_CBNV_VANG", txtTen_Dt_CbNv_Vang.Text);
                //ht.Add("DANH_GIA_CA", txtDanh_Gia_Ca.Text);
                ht.Add("TINH_TRANG_ATLD", txtTinh_Trang_ATLD.Text);
                ht.Add("TINH_TRANG_CLSP", txtTinh_Trang_CLSP.Text);
                //,Tinh_Trang_Giao_Ca = @Tinh_Trang_Giao_Ca, 

                ht.Add("SL_LIEU_NOI", numSL_Lieu_Noi.Value);
                ht.Add("SL_LIEU_HMS", numSL_Lieu_HMS.Value);
                ht.Add("SL_LIEU_TAUVUN", numSL_Lieu_TauVun.Value);
                ht.Add("SL_GANG", numSL_Gang.Value);
                ht.Add("SL_LIEU_KHAC", numSL_Lieu_Khac.Value);
                ht.Add("LECH_TEST_CMM", numLech_Test_CMM.Value);
                ht.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
                ht.Add("MA_DT_CBNV", txtMa_Dt_CbNv.Text);
                
                strSQLEXEC = "UPDATE R80PH_QLSX SET Ngay_Sx = @Ngay_Sx, Ca_Sx = @Ca_Sx, Ten_Dt_CbNv_Vang = @Ten_Dt_CbNv_Vang, " +
                " Sl_Lieu_Noi = @Sl_Lieu_Noi, Sl_Lieu_HMS = @Sl_Lieu_HMS, Sl_Lieu_TauVun = @Sl_Lieu_TauVun, Sl_Gang = @Sl_Gang, " +
                " Sl_Lieu_Khac = @Sl_Lieu_Khac, Lech_Test_CMM = @Lech_Test_CMM, Ma_Dt_CbNv = @Ma_Dt_CbNv," +
                " Tinh_Trang_ATLD = @Tinh_Trang_ATLD, Tinh_Trang_CLSP = @Tinh_Trang_CLSP, " +
                " LastModify_Log = @LastModify_Log WHERE Stt = @Stt";
            }
			try
			{
                SQLExec.Execute(strSQLEXEC, ht, CommandType.Text);
				//Update to PH
                this.FillData(strStt);
                
			}
			catch (Exception ex)
			{
		    	MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
			}

			
            return true;
		}
       
        

        void dgvSuCo_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvSuCo;
        }

        void dgvTHCN_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTHCN;
        }
        void dgvTHHB_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTHHB;
        }
        void dgvTHTB_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTHTB;
        }
        void dgvTSQT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTSQT;
        }
        
        void dgvNhapPhoiKCS_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNhapPhoiKCS;
        }

        void dgvKienNghi_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvKienNghi;
        }

        void dgvGiaoCa_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvGiaoCa;
        }
        void cboCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCa.Text != "")
            {
                DataTable dtDmCaSx = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R81DMCASX WHERE Ngay_Sx = '" + dteNgay_Sx.Text + "' AND Ca = '" + cboCa.Text + "'");
                DataTable dtPH = SQLExec.ExecuteReturnDt("SELECT Ma_Dt_CbNv FROM R80PH_QLSX WHERE Ngay_Sx = '" + dteNgay_Sx.Text + "' AND Ca_SX = '" + cboCa.Text + "' AND Loai_SX = 'LUYEN'");
                if (dtDmCaSx.Rows.Count == 0)
                {
                    Common.MsgOk("Ngày " + dteNgay_Sx.Text + " không có ca " + cboCa.Text + ". Bạn vui lòng chọn ca khác!!!");
                    cboCa.Text = "";
                }
                else
                {
                    lbtGio_Ra_Vao_Ca.Text = "Giờ vào " + dtDmCaSx.Rows[0]["Gio_Begin"].ToString() + " giờ ra " + dtDmCaSx.Rows[0]["Gio_End"];
                    
                    if(dtPH.Rows.Count>0)
                        lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", dtPH.Rows[0]["Ma_Dt_CbNv"].ToString());
                }
            }
        }
        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
            }
        }
        void cboCa_Sx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCa_Sx.SelectedValue != null)
            {
                if (cboCa_Sx.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    this.strStt = cboCa_Sx.SelectedValue == null ? string.Empty : cboCa_Sx.SelectedValue.ToString();
                    this.FillData_Voucher_Ph();
                }
            }
        }
        public override void Edit(enuEdit enuNew_Edit)
        {
           
            if (this.objActive == dgvTHCN)
                this.Edit_THCN(enuNew_Edit);
            else if (this.objActive == dgvSuCo)
                this.Edit_SuCo(enuNew_Edit);
            //else if (this.objActive == dgvTSQT)
            //    this.Edit_TSQTCan(enuNew_Edit);
          
        }
        public override void Delete()
        {
            if (this.objActive == dgvTHCN)
                this.Delete_THCN();
            else if (this.objActive == dgvTHTB)
                this.Delete_THTB();
            else if (this.objActive == dgvTHHB)
                this.Delete_THHB();
            else if (this.objActive == dgvGiaoCa)
                this.Delete_GiaoCa();
            else if (this.objActive == dgvKienNghi)
                this.Delete_KienNghi();
            else if (this.objActive == dgvSuCo)
                this.Delete_SuCo();
            else if (this.objActive == dgvTSQT)
                this.Delete_TSQTCan();
           

        }
        void btNew_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.New;
            Edit(enuNew_Edit_Voucher);
           
        }
        void btEdit_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.Edit;
            Edit(enuNew_Edit_Voucher);
        }
       
        void btDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }



        private void Edit_THCN(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_THCN.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_THCN.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_THCN.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_THCN.NewRow();

            frmTHSXLuyen_Edit frmEdit = new frmTHSXLuyen_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, "CN");

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_THCN.Position >= 0)
                        dtEditCt_THCN.ImportRow(drCurrent);
                    else
                        dtEditCt_THCN.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_THCN.Current).Row);
                }


                bdsEditCt_THCN.Position = bdsEditCt_THCN.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_THCN.AcceptChanges();
            }
            else
                dtEditCt_THCN.RejectChanges();
        }


        private void Edit_SuCo(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_SuCo.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_SuCo.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_SuCo.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_SuCo.NewRow();

            //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            //{
            //    if (bdsEditCt_SuCo.Position < 0)
            //        Common.CopyDataRow(drEditCt_SuCo, drCurrent, strStt);

            //    drCurrent["Stt"] = drEditPh["Stt"];

            //}

            frmSuCoLuyen_Edit frmEdit = new frmSuCoLuyen_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmSuCo = DataTool.SQLGetDataRowByID("R81DMSUCO", "Ma_Su_Co", drCurrent["Ma_Su_Co"].ToString());
                drCurrent["Ten_Su_Co"] = drDmSuCo["Ten_Su_Co"];
                drCurrent["Loai_Su_Co"] = drDmSuCo["Loai_Su_Co"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_SuCo.Position >= 0)
                        dtEditCt_SuCo.ImportRow(drCurrent);
                    else
                        dtEditCt_SuCo.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_SuCo.Current).Row);
                }
                

                bdsEditCt_SuCo.Position = bdsEditCt_SuCo.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_SuCo.AcceptChanges();
            }
            else
                dtEditCt_SuCo.RejectChanges();
        }
       
        private void Edit_TSQTCan(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_TSQT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_TSQT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_TSQT.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_TSQT.NewRow();

            frmTSQTLuyen_Edit frmEdit = new frmTSQTLuyen_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_TSQT.Position >= 0)
                        dtEditCt_TSQT.ImportRow(drCurrent);
                    else
                        dtEditCt_TSQT.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_TSQT.Current).Row);
                }
                bdsEditCt_TSQT.Position = bdsEditCt_TSQT.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_TSQT.AcceptChanges();
            }
            else
                dtEditCt_TSQT.RejectChanges();
        }
       
        private void Delete_SuCo()
        {
            if (bdsEditCt_SuCo.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_SuCo.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11SUCOLUYEN", drCurrent))
            {
                bdsEditCt_SuCo.RemoveAt(bdsEditCt_SuCo.Position);
                dtEditCt_SuCo.AcceptChanges();
            }
        }
       
       
        private void Delete_TSQTCan()
        {
            if (bdsEditCt_TSQT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_TSQT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11DLSXLUYEN", drCurrent))
            {
                bdsEditCt_TSQT.RemoveAt(bdsEditCt_TSQT.Position);
                dtEditCt_TSQT.AcceptChanges();
            }
        }
        
        
        private void Delete_THCN()
        {
            if (bdsEditCt_THCN.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_THCN.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11THSXLUYEN", drCurrent))
            {
                bdsEditCt_THCN.RemoveAt(bdsEditCt_THCN.Position);
                dtEditCt_THCN.AcceptChanges();
            }
        }

        private void Delete_THTB()
        {
            if (bdsEditCt_THTB.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_THTB.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11THSXLUYEN", drCurrent))
            {
                bdsEditCt_THTB.RemoveAt(bdsEditCt_THTB.Position);
                dtEditCt_THTB.AcceptChanges();
            }
        }
        private void Delete_THHB()
        {
            if (bdsEditCt_THHB.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_THHB.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11THSXLUYEN", drCurrent))
            {
                bdsEditCt_THHB.RemoveAt(bdsEditCt_THHB.Position);
                dtEditCt_THHB.AcceptChanges();
            }
        }
        private void Delete_GiaoCa()
        {
            if (bdsEditCt_GiaoCa.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_GiaoCa.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11THSXLUYEN", drCurrent))
            {
                bdsEditCt_GiaoCa.RemoveAt(bdsEditCt_GiaoCa.Position);
                dtEditCt_GiaoCa.AcceptChanges();
            }
        }
        private void Delete_KienNghi()
        {
            if (bdsEditCt_KienNghi.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_KienNghi.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11THSXLUYEN", drCurrent))
            {
                bdsEditCt_KienNghi.RemoveAt(bdsEditCt_KienNghi.Position);
                dtEditCt_KienNghi.AcceptChanges();
            }
        }
		#region Event
		
		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

         
            bdsEditCt.EndEdit();//Cap nhat lai DataSource
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
            Hashtable ht = new Hashtable();

            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("LOAI_SX", "LUYEN");
        
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLSXLUYEN", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }
            this.bdsEditPh.MoveLast();
            //bdsEditPh.Position = bdsEditPh.Count;
            LoadCombo();
		}

		void btPrevious_Click(object sender, EventArgs e)
		{
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MovePrevious();
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCa_Sx.SelectedValue != null)
            {
                LoadDicName();
                this.cboCa_Sx.SelectedValue = this.strStt;
            }
		}

		void btLast_Click(object sender, EventArgs e)
		{
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MoveLast();
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCa_Sx.SelectedValue != null)
            {
                LoadDicName();
                this.cboCa_Sx.SelectedValue = this.strStt;
            }
		}

		void btNext_Click(object sender, EventArgs e)
		{
            if (bdsEditPh.Position < 0)
                return;

            if (this.bdsEditPh.Position + 1 < this.bdsEditPh.Count)
            {
                this.bdsEditPh.MoveNext();
                this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

                if (cboCa_Sx.SelectedValue != null)
                {
                    LoadDicName();
                    this.cboCa_Sx.SelectedValue = this.strStt;
                }
            }
		}

        void btFirst_Click(object sender, EventArgs e)
        {
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MoveFirst();

            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCa_Sx.SelectedValue != null)
            {
                LoadDicName();
                this.cboCa_Sx.SelectedValue = this.strStt;
            }

        }

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
            //switch (e.KeyCode)
            //{
            //    case Keys.F8:

            //        if (dgvEditCt.Focused == false)
            //            return;

            //        if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            //            return;

            //        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            //        drCurrent["Deleted"] = !((bool)drCurrent["Deleted"]);

            //        if ((bool)drCurrent["Deleted"] == true)
            //        {
            //            Font font = new Font(dgvEditCt.Font.FontFamily, dgvEditCt.Font.Size, FontStyle.Strikeout);
            //            dgvEditCt.CurrentRow.DefaultCellStyle.Font = font;
            //        }
            //        else
            //        {
            //            dgvEditCt.CurrentRow.DefaultCellStyle.Font = dgvEditCt.Font;
            //        }
            //        break;
            //}
		}
        void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

         
        }
        void dgvEditCt_Validated(object sender, EventArgs e)
        {
            
        }
	
		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{
				case Keys.F9:
					this.btRefresh_Click(null, null);
					return;

               
				case Keys.F12:
					if (e.Modifiers == Keys.Control)
						base.OnKeyDown(e);
				
					return;

			    
			}

			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
                //if (!Common.CheckPermission("ACCESS_FILTER_DT_TCB", enuPermission_Type.Allow_Access))
                //    dteNgay_Ct1.Enabled = dteNgay_Ct2.Enabled = false;

                //this.btEdit.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
			}

		}

      
	}
}
