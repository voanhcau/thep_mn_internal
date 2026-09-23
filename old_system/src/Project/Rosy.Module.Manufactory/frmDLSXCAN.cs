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

namespace RosyModule.Manufactory
{
	public partial class frmDLSXCAN : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
        object objActive = null;

		DataSet dsVoucher = new DataSet();
		DataTable dtEditPh;
        DataTable dtEditPh_Dest;
		DataTable dtEditCt;
        DataTable dtEditCt_ThietBi;
        DataTable dtEditCt_SuCo;
        DataTable dtEditCt_DLSXPhoi;
        DataTable dtEditCt_DLSXThep;
        DataTable dtEditCt_TSQT;
        DataTable dtEditCt_PhoiGiao;
        DataTable dtEditCt_ThepNgan;
       


        DataRow drEditPh;
		DataRow drEditCt;
        DataRow drEditCt_ThietBi;
        DataRow drEditCt_SuCo;
        DataRow drEditCt_DLSXPhoi;
        DataRow drEditCt_DLSXThep;
        DataRow drEditCt_TSQT;
        DataRow drEditCt_PhoiGiao;
        
      
    


		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
        BindingSource bdsEditCt_ThietBi = new BindingSource();
        BindingSource bdsEditCt_SuCo = new BindingSource();
        BindingSource bdsEditCt_DLSXPhoi = new BindingSource();
        BindingSource bdsEditCt_DLSXThep = new BindingSource();
        BindingSource bdsEditCt_TSQT = new BindingSource();
        BindingSource bdsEditCt_PhoiGiao = new BindingSource();
      
       

		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;

        string strStt_Org = string.Empty;
        string strStt = string.Empty;
        string strSo_Ct = string.Empty;
        public string strLoai_Sx = "CAN";
		#endregion

        public frmDLSXCAN()
		{
			InitializeComponent();

            dgvThietBi.Enter += new EventHandler(dgvThietBi_Enter);
            dgvSuCo.Enter += new EventHandler(dgvSuCo_Enter);
            dgvXuatPhoi.Enter += new EventHandler(dgvDLSX_Enter);
            dgvNhapThep.Enter += new EventHandler(dgvNhapThep_Enter);
            dgvTSQT.Enter+=new EventHandler(dgvTSQT_Enter);
            dgvPhoiGiao.Enter += new EventHandler(dgvPhoiGiao_Enter);
         

            this.btRefresh.Click += new EventHandler(btRefresh_Click);           
            cboCa_Sx.SelectedValueChanged += new EventHandler(cboCa_Sx_SelectedValueChanged);
            cboCa.SelectedIndexChanged += new EventHandler(cboCa_SelectedIndexChanged);
           
            this.btFirst.Click += new EventHandler(btFirst_Click);
			this.btNext.Click += new EventHandler(btNext_Click);
			this.btPrevious.Click += new EventHandler(btPrevious_Click);
			this.btLast.Click += new EventHandler(btLast_Click);


            numSl_Phoi_Dai_Nhan.Validated += new EventHandler(numSl_Phoi_Dai_Nhan_Validated);
            numSl_Phoi_TLo_Nhan.Validated += new EventHandler(numSl_Phoi_Dai_Nhan_Validated);
            numSl_Phoi_San_Nhan.Validated += new EventHandler(numSl_Phoi_Dai_Nhan_Validated);
            numSl_Phoi_HLo_Nhan.Validated += new EventHandler(numSl_Phoi_Dai_Nhan_Validated);
            numSl_Phoi_Dai_Giao.Validated += new EventHandler(numSl_Phoi_Dai_Nhan_Validated);
            numSl_Phoi_TLo_Giao.Validated += new EventHandler(numSl_Phoi_Dai_Nhan_Validated);
            numSl_Phoi_San_Giao.Validated += new EventHandler(numSl_Phoi_Dai_Nhan_Validated);
            numSl_Phoi_HLo_Giao.Validated += new EventHandler(numSl_Phoi_Dai_Nhan_Validated);

            this.btTao_Ca.Click += new EventHandler(btTao_Ca_Click);
            this.btKet_Thuc_Ca.Click += new EventHandler(btKet_Thuc_Ca_Click);
            this.btSave.Click += new EventHandler(btSave_Click);

            this.btUpdateXuatPhoi.Click += new EventHandler(btUpdateXuatPhoi_Click);
            this.btGiaoPhoi.Click += new EventHandler(btGiaoPhoi_Click);
            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btExit.Click += new EventHandler(btExit_Click);
		}

        void btGiaoPhoi_Click(object sender, EventArgs e)
        {
            GetGiaoPhoi();
        }

        void GetGiaoPhoi()
        {
            //Tự động lấy dữ liệu trước ca
            if (cboCa.Text != "" && numSo_Dien_Dau.Value != 0)
            {
                Hashtable htTruocCa = new Hashtable();
                htTruocCa.Add("NGAY_SX", dteNgay_Sx.Text);
                htTruocCa.Add("CA", cboCa.Text);
                DataTable dtTruocCa = SQLExec.ExecuteReturnDt("sp_GetTruocCaCan", htTruocCa, CommandType.StoredProcedure);

                if (dtTruocCa.Rows.Count == 1)
                {
                    DataRow drTruocCa = dtTruocCa.Rows[0];
                    //numSo_Dien_Dau.Value = Convert.ToDouble(drTruocCa["So_Dien_Cuoi"]);
                    //numSo_Gas_Dau.Value = Convert.ToDouble(drTruocCa["So_Gas_Cuoi"]);
                    //numSl_Phoi_TLo_Nhan.Value = Convert.ToDouble(drTruocCa["Sl_Phoi_TLo_Giao"]);
                    //numSl_Phoi_San_Nhan.Value = Convert.ToDouble(drTruocCa["Sl_Phoi_San_Giao"]);
                    //numSl_Phoi_HLo_Nhan.Value = Convert.ToDouble(drTruocCa["Sl_Phoi_HLo_Giao"]);
                    

                    //Lấy dữ liệu phôi giao từ ca trước
                    Hashtable ht = new Hashtable();
                    ht.Add("STT_DAU", drTruocCa["Stt"]);
                    ht.Add("STT", strStt);
                    ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                    DataTable dtGiaoPhoi = SQLExec.ExecuteReturnDt("sp_ImportPhoiGiao", ht, CommandType.StoredProcedure);
                    if (dtGiaoPhoi.Rows.Count > 0)
                    {
                        bdsEditCt_PhoiGiao.DataSource = dtGiaoPhoi;
                        dgvPhoiGiao.DataSource = bdsEditCt_PhoiGiao;

                        numSl_Phoi_TLo_Nhan.Value = Common.SumDCValue(dtGiaoPhoi, "Sl_Phoi_TLo", "");
                        numSl_Phoi_San_Nhan.Value = Common.SumDCValue(dtGiaoPhoi, "Sl_Phoi_San", "");
                        //numSl_Phoi_HLo_Nhan.Value = Common.SumDCValue(dtGiaoPhoi, "Sl_Phoi_HLo", "");

                        //Lưu lại thông tin ca
                        Hashtable ht1 = new Hashtable();
                        ht1.Add("STT", strStt);
                        ht1.Add("SL_PHOI_TLO_NHAN", numSl_Phoi_TLo_Nhan.Value);
                        ht1.Add("SL_PHOI_SAN_NHAN", numSl_Phoi_San_Nhan.Value);
                        ht1.Add("SL_PHOI_HLO_NHAN", numSl_Phoi_HLo_Nhan.Value);
                        string SQLEXEC = "UPDATE R80PH_QLSX SET Sl_Phoi_TLo_Nhan = @Sl_Phoi_TLo_Nhan, Sl_Phoi_San_Nhan = @Sl_Phoi_San_Nhan, Sl_Phoi_HLo_Nhan = @Sl_Phoi_HLo_Nhan WHERE Stt = @Stt";
                        SQLExec.Execute(SQLEXEC, ht1, CommandType.Text);
                    }
                }
            }
              
           
        }

        

        new public void Load()
		{

           
            DateTime dteNgay_Ct2 = DateTime.Now;
            DateTime dteNgay_Ct1 = dteNgay_Ct2.AddDays((-dteNgay_Ct2.Day)+1);

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


            if (txtMa_Vt_Sp_TNgan.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp_TNgan.Text.Trim());
            }
            else
                lbtTen_Vt_Sp.Text = string.Empty;

        }
		private void Build()
		{
            dgvThietBi.bSortMode = false;
            dgvThietBi.strZone = "THIETBI_SXCAN";
            dgvThietBi.BuildGridView();

            dgvSuCo.bSortMode = false;
            dgvSuCo.strZone = "SUCO_SXCAN";
            dgvSuCo.BuildGridView();

            if (dgvSuCo.Columns.Contains("Nguyen_Nhan"))
            {
                dgvSuCo.Columns["Nguyen_Nhan"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvSuCo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvSuCo.Columns.Contains("Khac_Phuc"))
            {
                dgvSuCo.Columns["Khac_Phuc"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvSuCo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            dgvXuatPhoi.bSortMode = false;
            dgvXuatPhoi.strZone = "DLSX_SXPHOI";
            dgvXuatPhoi.BuildGridView();

            dgvNhapThep.bSortMode = false;
            dgvNhapThep.strZone = "DLSX_SXTHEP";
            dgvNhapThep.BuildGridView();


            dgvTSQT.bSortMode = false;
            dgvTSQT.strZone = "TSQTCAN";
            dgvTSQT.BuildGridView();

            dgvPhoiGiao.bSortMode = false;
            dgvPhoiGiao.strZone = "PHOIGIAO";
            dgvPhoiGiao.BuildGridView();

        

           

            this.DataGridView_Language();

            foreach (DataGridViewColumn dgvc in dgvThietBi.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvSuCo.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXuatPhoi.Columns)
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
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLSXCAN", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }

            LoadCombo();
            //this.ExportControl = dgvEditCt;
            strStt = strStt_Current;
        }
		private void FillData()
		{
            Hashtable ht = new Hashtable();
         
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("LOAI_SX", "CAN");
            ht.Add("CA_SX", cboCa_Sx.Text);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLSXCAN", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }

            LoadCombo();
            CalChenh_Phoi();
            //this.ExportControl = dgvEditCt;
		}
        private void LoadCombo()
        {
            LoadDicName();
            Hashtable ht1 = new Hashtable();
            ht1.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht1.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht1.Add("LOAI_SX", "CAN");

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
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLSXCAN", ht, CommandType.StoredProcedure);

           
            dtEditCt_ThietBi = dsVoucher.Tables[1];
            bdsEditCt_ThietBi.DataSource = dtEditCt_ThietBi;
            dgvThietBi.DataSource = bdsEditCt_ThietBi;

            dtEditCt_SuCo = dsVoucher.Tables[2];
            bdsEditCt_SuCo.DataSource = dtEditCt_SuCo;
            dgvSuCo.DataSource = bdsEditCt_SuCo;

            dtEditCt_DLSXPhoi = dsVoucher.Tables[3];
            bdsEditCt_DLSXPhoi.DataSource = dtEditCt_DLSXPhoi;
            dgvXuatPhoi.DataSource = bdsEditCt_DLSXPhoi;

            dtEditCt_DLSXThep = dsVoucher.Tables[4];
            bdsEditCt_DLSXThep.DataSource = dtEditCt_DLSXThep;
            dgvNhapThep.DataSource = bdsEditCt_DLSXThep;

            dtEditCt_TSQT = dsVoucher.Tables[5];
            bdsEditCt_TSQT.DataSource = dtEditCt_TSQT;
            dgvTSQT.DataSource = bdsEditCt_TSQT;

            dtEditCt_PhoiGiao = dsVoucher.Tables[6];
            bdsEditCt_PhoiGiao.DataSource = dtEditCt_PhoiGiao;
            dgvPhoiGiao.DataSource = bdsEditCt_PhoiGiao;

          

          

            CalChenh_Phoi();
        }
        private void Reset_Voucher_Edit()
        {

            cboCa.Text = txtTen_Dt_CbNv_Vang.Text = txtTinh_Trang_Giao_Ca.Text = txtTinh_Trang_Nhan_Ca.Text = txtMa_Vt_Sp_TNgan.Text = txtDanh_Gia_Ca.Text = txtGhi_Chu.Text = string.Empty;
            numSo_Dien_Dau.Value = numSo_Dien_Cuoi.Value = numSo_Gas_Dau.Value = numSo_Gas_Cuoi.Value = 0;
            numSl_Phoi_HLo_Nhan.Value = numSl_Phoi_San_Nhan.Value = numSl_Phoi_TLo_Nhan.Value = numSl_Phoi_Dai_Nhan.Value = 0;
            numSl_Phoi_HLo_Giao.Value = numSl_Phoi_San_Giao.Value = numSl_Phoi_TLo_Giao.Value = numSl_Phoi_Dai_Giao.Value = numSl_Phoi_Xau.Value = numSl_Dau_Mau.Value = numSl_Thep_Ngan.Value = 0;

            if (dtEditCt_ThietBi != null)
                dtEditCt_ThietBi.Rows.Clear();
            if (dtEditCt_SuCo != null)
                dtEditCt_SuCo.Rows.Clear();
            if (dtEditCt_DLSXPhoi != null)
                dtEditCt_DLSXPhoi.Rows.Clear();
            if (dtEditCt_DLSXThep != null)
                dtEditCt_DLSXThep.Rows.Clear();
            if (dtEditCt_TSQT != null)
                dtEditCt_TSQT.Rows.Clear();
            if (dtEditCt_PhoiGiao != null)
                dtEditCt_PhoiGiao.Rows.Clear();
            if (dtEditCt_ThepNgan != null)
                dtEditCt_ThepNgan.Rows.Clear();
           
            
        }
	
        private void ScaterMemvar_Voucher_Edit(DataRow drEditPh_Dest)
        {
            
            dteNgay_Sx.Text = Library.DateToStr(Convert.ToDateTime(drEditPh_Dest["Ngay_Sx"]));
            cboCa.Text = (string)drEditPh_Dest["Ca_Sx"];
           
            txtTen_Dt_CbNv_Vang.Text = (string)drEditPh_Dest["Ten_Dt_CbNv_Vang"];
            txtTinh_Trang_Giao_Ca.Text = (string)drEditPh_Dest["Tinh_Trang_Giao_Ca"];
            txtTinh_Trang_Nhan_Ca.Text = (string)drEditPh_Dest["Tinh_Trang_Nhan_Ca"];
            txtDanh_Gia_Ca.Text = (string)drEditPh_Dest["Danh_Gia_Ca"];
            txtMa_Vt_Sp_TNgan.Text = (string)drEditPh_Dest["Ma_Vt_Sp_TNgan"];

            numSo_Dien_Dau.Value = Convert.ToDouble(drEditPh_Dest["So_Dien_Dau"]);
            numSo_Dien_Cuoi.Value = Convert.ToDouble(drEditPh_Dest["So_Dien_Cuoi"]);
            numSo_Gas_Dau.Value = Convert.ToDouble(drEditPh_Dest["So_Gas_Dau"]);
            numSo_Gas_Cuoi.Value = Convert.ToDouble(drEditPh_Dest["So_Gas_Cuoi"]);

            numSl_Phoi_TLo_Nhan.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_TLo_Nhan"]);
            numSl_Phoi_San_Nhan.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_San_Nhan"]);
            numSl_Phoi_HLo_Nhan.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_HLo_Nhan"]);
            numSl_Phoi_Dai_Nhan.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_Dai_Nhan"]);
           

            numSl_Phoi_TLo_Giao.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_TLo_Giao"]);
            numSl_Phoi_San_Giao.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_San_Giao"]);
            numSl_Phoi_HLo_Giao.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_HLo_Giao"]);
            numSl_Phoi_Dai_Giao.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_Dai_Giao"]);
           
            numSl_Dau_Mau.Value = Convert.ToDouble(drEditPh_Dest["Sl_Dau_Mau"]);
            numSl_Thep_Ngan.Value = Convert.ToDouble(drEditPh_Dest["Sl_Thep_Ngan"]);

            numSl_Phoi_Xau.Value = Convert.ToDouble(drEditPh_Dest["Sl_Phoi_Xau"]);
            txtGhi_Chu.Text = (string)(drEditPh_Dest["Ghi_Chu"]);
        }

        void btTao_Ca_Click(object sender, EventArgs e)
        {
            enuNew_Edit_Voucher = enuEdit.New;
            Reset_Voucher_Edit();
            dteNgay_Sx.Focus();

            dteNgay_Sx.Text = Library.DateToStr(DateTime.Now);
            dteNgay_Sx.ReadOnly = false;

            txtTen_Dt_CbNv_Vang.ReadOnly = false;
            txtTinh_Trang_Nhan_Ca.ReadOnly = false;
            numSo_Gas_Dau.ReadOnly = false;
            numSo_Dien_Dau.ReadOnly = false;
            numSl_Phoi_TLo_Nhan.ReadOnly = false;
            numSl_Phoi_San_Nhan.ReadOnly = false;
            numSl_Phoi_HLo_Nhan.ReadOnly = false;
            numSl_Phoi_Dai_Nhan.ReadOnly = false;
            

            strStt = Common.GetNewStt("11", true);
            btSave.Enabled = true;
        }

        void btKet_Thuc_Ca_Click(object sender, EventArgs e)
        {
            enuNew_Edit_Voucher = enuEdit.Edit;
            dteNgay_Sx.ReadOnly = false;

            txtTen_Dt_CbNv_Vang.ReadOnly = false;
            txtTinh_Trang_Nhan_Ca.ReadOnly = false;
            numSo_Gas_Dau.ReadOnly = false;
            numSo_Dien_Dau.ReadOnly = false;
            numSl_Phoi_TLo_Nhan.ReadOnly = false;
            numSl_Phoi_San_Nhan.ReadOnly = false;
            numSl_Phoi_HLo_Nhan.ReadOnly = false;
            numSl_Phoi_Dai_Nhan.ReadOnly = false;
            

            txtMa_Vt_Sp_TNgan.ReadOnly = false;
            txtDanh_Gia_Ca.ReadOnly = false;
            txtTinh_Trang_Giao_Ca.ReadOnly = false;
            numSo_Gas_Cuoi.ReadOnly = false;
            numSo_Dien_Cuoi.ReadOnly = false;
            numSl_Phoi_TLo_Giao.ReadOnly = false;
            numSl_Phoi_San_Giao.ReadOnly = false;
            numSl_Phoi_HLo_Giao.ReadOnly = false;
            numSl_Phoi_Dai_Giao.ReadOnly = false;
           
            numSl_Phoi_Xau.ReadOnly = false;
            numSl_Dau_Mau.ReadOnly = false;
            numSl_Thep_Ngan.ReadOnly = false;
            txtGhi_Chu.ReadOnly = false;
            //Lấy dữ liệu phôi nhận
            DataTable dtPhoiNhan = SQLExec.ExecuteReturnDt("SELECT SUM(Tong_Phoi_Sd) AS Tong_Phoi_Sd, SUM(SL_Phoi_Hlo) AS Sl_Phoi_Hlo, SUM(SL_Phoi_San) AS Sl_Phoi_San,  SUM(SL_Phoi_Tlo) AS Sl_Phoi_Tlo, SUM(SL_Phoi_Xau) AS Sl_Phoi_Xau FROM R11DLSX_XPHOI WHERE Stt = '" + strStt + "'");
            DataTable dtPhoiGiao = SQLExec.ExecuteReturnDt("SELECT SUM(Tong_Phoi_Sd) AS Tong_Phoi_Sd, SUM(Sl_Phoi_Hlo) AS Sl_Phoi_Hlo , SUM(SL_Phoi_San) AS SL_Phoi_San , SUM(SL_Phoi_Tlo) AS SL_Phoi_Tlo, SUM(SL_Phoi_Xau) AS Sl_Phoi_Xau  FROM R11DLSX_PHOIGIAO WHERE Stt = '" + strStt + "'");

            numSl_Phoi_Dai_Giao.Value = Common.SumDCValue(dtPhoiNhan, "Tong_Phoi_Sd", "") + Common.SumDCValue(dtPhoiGiao, "Tong_Phoi_Sd", ""); // LẤY PHÔI GIAO ĐI CÁN VÀ PHÔI CÁN TRONG CA
            numSl_Phoi_HLo_Giao.Value = Common.SumDCValue(dtPhoiNhan, "SL_Phoi_Hlo", "");
            numSl_Phoi_San_Giao.Value = Common.SumDCValue(dtPhoiNhan, "SL_Phoi_San", "");
            numSl_Phoi_TLo_Giao.Value = Common.SumDCValue(dtPhoiNhan, "SL_Phoi_Tlo", "");
            numSl_Phoi_Xau.Value = Common.SumDCValue(dtPhoiNhan, "SL_Phoi_Xau", "") + Common.SumDCValue(dtPhoiGiao, "SL_Phoi_Xau", "");
            numSl_Phoi_TLo_Nhan.Value = Common.SumDCValue(dtPhoiGiao, "Sl_Phoi_TLo", "");
            numSl_Phoi_San_Nhan.Value = Common.SumDCValue(dtPhoiGiao, "Sl_Phoi_San", "");
            numSl_Phoi_HLo_Nhan.Value = Common.SumDCValue(dtPhoiGiao, "Sl_Phoi_HLo", "");
            btSave.Enabled = true;
            CalChenh_Phoi();
        }
        void btUpdateXuatPhoi_Click(object sender, EventArgs e)
        {
            //if (dtEditCt_DLSXPhoi == null || dtEditCt_DLSXPhoi.Rows.Count == 0)
            //{
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT", dteNgay_Sx.Text);
                ht.Add("CA_SX", cboCa.Text);
                ht.Add("STT", strStt);
                ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                ht.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
                dtEditCt_DLSXPhoi = SQLExec.ExecuteReturnDt("sp_GetDLSXPhoi", ht, CommandType.StoredProcedure);
                bdsEditCt_DLSXPhoi.DataSource = dtEditCt_DLSXPhoi;
                dgvXuatPhoi.DataSource = bdsEditCt_DLSXPhoi;

                numSl_Phoi_Dai_Nhan.Value = Common.SumDCValue(dtEditCt_DLSXPhoi, "So_Luong_Cay_Xuat", "");
                                
            //}
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
                if (cboCa.Text != "" && (DataTool.SQLCheckExist("R80PH_QLSX", new string[] { "Ngay_Sx", "Ca_Sx", "Loai_Sx" }, new object[] { dteNgay_Sx.Text, cboCa.Text, "CAN" })))
                {
                    Common.MsgCancel("Ca "+cboCa.Text+" ngày "+dteNgay_Sx.Text+" đã được tạo. Vui lòng chọn ca làm việc khác !!!");
                    return false;
                }
                if (numSo_Dien_Dau.Value == 0)
                {
                    Common.MsgCancel("Bạn phải nhập số điện đầu ca");
                    return false;
                }
                if (numSo_Gas_Dau.Value == 0)
                {
                    Common.MsgCancel("Bạn phải nhập số gas đầu ca");
                    return false;
                }
                
                if(strStt == string.Empty || strStt == "")
                    Common.GetNewStt("11", true);

                ht.Add("STT", strStt);
                ht.Add("LOAI_SX", "CAN");
                ht.Add("NGAY_SX", dteNgay_Sx.Text);
                ht.Add("CA_SX", cboCa.Text);
                
                ht.Add("TEN_DT_CBNV_VANG", txtTen_Dt_CbNv_Vang.Text);
                ht.Add("TINH_TRANG_NHAN_CA", txtTinh_Trang_Nhan_Ca.Text);
                ht.Add("SO_DIEN_DAU", numSo_Dien_Dau.Value);
                ht.Add("SO_GAS_DAU", numSo_Gas_Dau.Value);

                ht.Add("SL_PHOI_TLO_NHAN", numSl_Phoi_TLo_Nhan.Value);
                ht.Add("SL_PHOI_SAN_NHAN", numSl_Phoi_San_Nhan.Value);
                ht.Add("SL_PHOI_HLO_NHAN", numSl_Phoi_HLo_Nhan.Value);
                ht.Add("SL_PHOI_DAI_NHAN", numSl_Phoi_Dai_Nhan.Value);
               
                
                
                
                ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                ht.Add("MA_DVCS", Element.sysMa_DvCs);

                strSQLEXEC = "INSERT INTO R80PH_QLSX(Stt, Loai_Sx, Ngay_Sx, Ca_SX, Ten_Dt_CbNv_Vang, Tinh_Trang_Nhan_Ca, So_Dien_Dau, So_Gas_Dau, Sl_Phoi_TLo_Nhan, Sl_Phoi_San_Nhan, Sl_Phoi_HLo_Nhan, Sl_Phoi_Dai_Nhan, Create_Log, Ma_DvCs) " +
                                "VALUES (@Stt, @Loai_Sx, @Ngay_Sx, @Ca_SX, @Ten_Dt_CbNv_Vang, @Tinh_Trang_Nhan_Ca, @So_Dien_Dau, @So_Gas_Dau, @Sl_Phoi_TLo_Nhan, @Sl_Phoi_San_Nhan, @Sl_Phoi_HLo_Nhan, @Sl_Phoi_Dai_Nhan, @Create_Log, @Ma_DvCs)";
            }
            else
            {
                if (numSo_Dien_Cuoi.Value == 0)
                {
                    Common.MsgCancel("Bạn phải nhập số điện cuối ca");
                    return false;
                }
                if (numSo_Gas_Cuoi.Value == 0)
                {
                    Common.MsgCancel("Bạn phải nhập số gas cuối ca");
                    return false;
                }

                ht.Add("STT", strStt);
                ht.Add("NGAY_SX", dteNgay_Sx.Text);
                ht.Add("CA_SX", cboCa.Text);
          
                ht.Add("TEN_DT_CBNV_VANG", txtTen_Dt_CbNv_Vang.Text);
                ht.Add("TINH_TRANG_GIAO_CA", txtTinh_Trang_Giao_Ca.Text);
                ht.Add("TINH_TRANG_NHAN_CA", txtTinh_Trang_Nhan_Ca.Text);
                ht.Add("DANH_GIA_CA", txtDanh_Gia_Ca.Text);
                ht.Add("MA_VT_SP_TNGAN", txtMa_Vt_Sp_TNgan.Text);
              
                ht.Add("SO_DIEN_DAU", numSo_Dien_Dau.Value);
                ht.Add("SO_GAS_DAU", numSo_Gas_Dau.Value);
                ht.Add("SO_DIEN_CUOI", numSo_Dien_Cuoi.Value);
                ht.Add("SO_GAS_CUOI", numSo_Gas_Cuoi.Value);

                ht.Add("SL_PHOI_TLO_NHAN", numSl_Phoi_TLo_Nhan.Value);
                ht.Add("SL_PHOI_SAN_NHAN", numSl_Phoi_San_Nhan.Value);
                ht.Add("SL_PHOI_HLO_NHAN", numSl_Phoi_HLo_Nhan.Value);
                ht.Add("SL_PHOI_DAI_NHAN", numSl_Phoi_Dai_Nhan.Value);

                ht.Add("SL_PHOI_TLO_GIAO", numSl_Phoi_TLo_Giao.Value);
                ht.Add("SL_PHOI_SAN_GIAO", numSl_Phoi_San_Giao.Value);
                ht.Add("SL_PHOI_HLO_GIAO", numSl_Phoi_HLo_Giao.Value);
                ht.Add("SL_PHOI_DAI_GIAO", numSl_Phoi_Dai_Giao.Value);
                
                ht.Add("SL_PHOI_XAU", numSl_Phoi_Xau.Value);
                ht.Add("SL_DAU_MAU", numSl_Dau_Mau.Value);
                ht.Add("SL_THEP_NGAN", numSl_Thep_Ngan.Value);
                ht.Add("GHI_CHU", txtGhi_Chu.Text);

                ht.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
             
                
                strSQLEXEC = "UPDATE R80PH_QLSX SET Ngay_Sx = @Ngay_Sx, Ca_Sx = @Ca_Sx, Ten_Dt_CbNv_Vang = @Ten_Dt_CbNv_Vang, " +
                " Tinh_Trang_Nhan_Ca = @Tinh_Trang_Nhan_Ca, Tinh_Trang_Giao_Ca = @Tinh_Trang_Giao_Ca, Danh_Gia_Ca = @Danh_Gia_Ca, So_Dien_Dau = @So_Dien_Dau, So_Dien_Cuoi = @So_Dien_Cuoi, So_Gas_Dau = @So_Gas_Dau, So_Gas_Cuoi = @So_Gas_Cuoi, " +
                " Sl_Phoi_Tlo_Nhan = @Sl_Phoi_Tlo_Nhan, Sl_Phoi_San_Nhan = @Sl_Phoi_San_Nhan, Sl_Phoi_Hlo_Nhan = @Sl_Phoi_Hlo_Nhan, Sl_Phoi_Dai_Nhan = @Sl_Phoi_Dai_Nhan," +
                " Sl_Phoi_TLo_Giao = @Sl_Phoi_TLo_Giao, Sl_Phoi_San_Giao = @Sl_Phoi_San_Giao, Sl_Phoi_Hlo_Giao = @Sl_Phoi_Hlo_Giao, Sl_Phoi_Dai_Giao = @Sl_Phoi_Dai_Giao, Sl_Phoi_Xau = @Sl_Phoi_Xau, Sl_Dau_Mau = @Sl_Dau_Mau,Sl_Thep_Ngan = @Sl_Thep_Ngan, Ghi_Chu = @Ghi_Chu, " +
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
        void numSl_Phoi_Dai_Nhan_Validated(object sender, EventArgs e)
        {
            CalChenh_Phoi();
            if (numSl_Thep_Ngan.Value != 0)
            {
                txtMa_Vt_Sp_TNgan.Text = "BD00000000";
                lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp_TNgan.Text.Trim());
            }
            else
                txtMa_Vt_Sp_TNgan.Text = "";
        }
        void CalChenh_Phoi()
        {
            numChenh_Phoi.Value = numSl_Phoi_Dai_Nhan.Value + numSl_Phoi_HLo_Nhan.Value + numSl_Phoi_San_Nhan.Value + numSl_Phoi_TLo_Nhan.Value - (numSl_Phoi_Dai_Giao.Value + numSl_Phoi_HLo_Giao.Value + numSl_Phoi_San_Giao.Value + numSl_Phoi_TLo_Giao.Value + numSl_Phoi_Xau.Value);
        
        } 
        void dgvNhapThep_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNhapThep;
        }
        void dgvDLSX_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXuatPhoi;
        }

        void dgvSuCo_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvSuCo;
        }

        void dgvThietBi_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvThietBi;
        }
        void dgvTSQT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTSQT;
        }
       

       
        void dgvPhoiGiao_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvPhoiGiao;
        }

       
        void cboCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCa.Text != "")
            {

                DataTable dtDmCaSx = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R81DMCASX WHERE Ngay_Sx = '"+ dteNgay_Sx.Text +"' AND Ca = '"+ cboCa.Text +"'");
                DataTable dtDmCa = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R81DMCA WHERE Ngay_Sx = '" + dteNgay_Sx.Text + "' AND Ca = '" + cboCa.Text + "'");
                if (dtDmCaSx.Rows.Count == 0)
                {
                    Common.MsgOk("Ngày "+ dteNgay_Sx.Text +" không có ca " + cboCa.Text + ". Bạn vui lòng chọn ca khác!!!");
                    cboCa.Text = "";
                }
                else if (dtDmCaSx.Rows.Count != 0 && dtDmCa.Rows.Count == 0)
                {
                    DataRow drDmCa = dtDmCaSx.Rows[0];
                    lbtGio_Ra_Vao_Ca.Text = "Giờ vào " + drDmCa["Gio_Begin"].ToString() + " giờ ra " + drDmCa["Gio_End"];
                    lbtTen_TC.Text = lbtTen_KCS.Text = lbtTen_Vh.Text = string.Empty;
                }
                else if (dtDmCaSx.Rows.Count != 0 && dtDmCa.Rows.Count != 0)
                {
                    DataRow drDmCa = dtDmCa.Rows[0];
                    lbtGio_Ra_Vao_Ca.Text = "Giờ vào " + drDmCa["Gio_Begin"].ToString() + " giờ ra " + drDmCa["Gio_End"];
                    lbtTen_TC.Text = "Trưởng ca " + SQLExec.ExecuteReturnValue("SELECT Ten_Dt FROM R81DMDT WHERE Ma_Dt = '" + drDmCa["Ma_Dt_CbNv_TC"] + "'").ToString();
                    lbtTen_KCS.Text = "Nhân viên KCS " + SQLExec.ExecuteReturnValue("SELECT Ten_Dt FROM R81DMDT WHERE Ma_Dt = '" + drDmCa["Ma_Dt_CbNv_KCS"] + "'").ToString();
                    lbtTen_Vh.Text = "Nhân viên ca " + SQLExec.ExecuteReturnValue("SELECT Ten_Dt FROM R81DMDT WHERE Ma_Dt = '" + drDmCa["Ma_Dt_CbNv_Can"] + "'").ToString();
                }
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_SX", dteNgay_Sx.Text);
                ht.Add("CA", cboCa.Text);
                DataTable dtTruocCa = SQLExec.ExecuteReturnDt("sp_GetTruocCaCan", ht, CommandType.StoredProcedure);
                if (dtTruocCa.Rows.Count == 1)
                {
                    DataRow drTruocCa = dtTruocCa.Rows[0];
                    numSo_Dien_Dau.Value = Convert.ToDouble(drTruocCa["So_Dien_Cuoi"]);
                    numSo_Gas_Dau.Value = Convert.ToDouble(drTruocCa["So_Gas_Cuoi"]);
                    
                }
                
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
            if (this.objActive == dgvThietBi)
                this.Edit_ThietBi(enuNew_Edit);
            else if (this.objActive == dgvSuCo)
                this.Edit_SuCo(enuNew_Edit);
            else if (this.objActive == dgvXuatPhoi)
                this.Edit_DLSXPhoi(enuNew_Edit);
            else if (this.objActive == dgvNhapThep)
                this.Edit_DLSXThep(enuNew_Edit);
            else if (this.objActive == dgvTSQT)
                this.Edit_TSQTCan(enuNew_Edit);
            else if (this.objActive == dgvPhoiGiao)
                this.Edit_PhoiGiao(enuNew_Edit);
        
            
            
          
        }
        public override void Delete()
        {
            if (this.objActive == dgvThietBi)
                this.Delete_ThietBi();
            else if (this.objActive == dgvSuCo)
                this.Delete_SuCo();
            else if (this.objActive == dgvXuatPhoi)
                this.Delete_DLSXPhoi();
            else if (this.objActive == dgvNhapThep)
                this.Delete_DLSXThep();
            else if (this.objActive == dgvTSQT)
                this.Delete_TSQTCan();
            else if (this.objActive == dgvPhoiGiao)
                this.Delete_PhoiGiao();
          
          

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


        private void Edit_ThietBi(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_ThietBi.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_ThietBi.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_ThietBi.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_ThietBi.NewRow();

            frmThietBiCan_Edit frmEdit = new frmThietBiCan_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmNhTb = DataTool.SQLGetDataRowByID("R06DMNHTB", "Ma_Nh_Tb", drCurrent["Ma_Nh_Tb"].ToString());
                drCurrent["Ten_Nh_Tb"] = drDmNhTb["Ten_Nh_Tb"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_ThietBi.Position >= 0)
                        dtEditCt_ThietBi.ImportRow(drCurrent);
                    else
                        dtEditCt_ThietBi.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_ThietBi.Current).Row);
                }
                

                bdsEditCt_ThietBi.Position = bdsEditCt_ThietBi.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_ThietBi.AcceptChanges();
            }
            else
                dtEditCt_ThietBi.RejectChanges();
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

            frmSuCoCan_Edit frmEdit = new frmSuCoCan_Edit();
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
        private void Edit_DLSXPhoi(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_DLSXPhoi.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_DLSXPhoi.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_DLSXPhoi.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_DLSXPhoi.NewRow();

            //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            //{
            //    if (bdsEditCt_DLSX.Position < 0)
            //        Common.CopyDataRow(drEditCt_DLSX, drCurrent);

            //    drCurrent["Stt"] = drEditPh["Stt"];

            //}

            frmDLSXPhoi_Edit frmEdit = new frmDLSXPhoi_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, Convert.ToDateTime(dteNgay_Sx.Text));

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drCurrent["Ma_Vt"].ToString());
                drCurrent["Ten_Vt"] = drDmVt["Ten_Vt"];
                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_DLSXPhoi.Position >= 0)
                        dtEditCt_DLSXPhoi.ImportRow(drCurrent);
                    else
                        dtEditCt_DLSXPhoi.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_DLSXPhoi.Current).Row);
                }
              

                bdsEditCt_DLSXPhoi.Position = bdsEditCt_DLSXPhoi.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_DLSXPhoi.AcceptChanges();
            }
            else
                dtEditCt_DLSXPhoi.RejectChanges();
        }
        private void Edit_DLSXThep(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_DLSXThep.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_DLSXThep.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_DLSXThep.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_DLSXThep.NewRow();

            frmDLSXThep_Edit frmEdit = new frmDLSXThep_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, Convert.ToDateTime(dteNgay_Sx.Text), cboCa.Text);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drCurrent["Ma_Vt_Sp"].ToString());
                drCurrent["Ten_Vt_Sp"] = drDmVt["Ten_Vt"];

                DataRow drDmLoaiCan = DataTool.SQLGetDataRowByID("R81DMTYPE", "Type_ID", drCurrent["Loai_Can"].ToString());
                drCurrent["Ten_Can"] = drDmLoaiCan["Type_Name"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_DLSXThep.Position >= 0)
                        dtEditCt_DLSXThep.ImportRow(drCurrent);
                    else
                        dtEditCt_DLSXThep.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_DLSXThep.Current).Row);
                }
               
                bdsEditCt_DLSXThep.Position = bdsEditCt_DLSXThep.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_DLSXThep.AcceptChanges();
            }
            else
                dtEditCt_DLSXThep.RejectChanges();
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

            frmTSQTCan_Edit frmEdit = new frmTSQTCan_Edit();
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
        private void Edit_PhoiGiao(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_PhoiGiao.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_PhoiGiao.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_PhoiGiao.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_PhoiGiao.NewRow();

            frmDLSXPhoiGiao_Edit frmEdit = new frmDLSXPhoiGiao_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, Convert.ToDateTime(dteNgay_Sx.Text));

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_PhoiGiao.Position >= 0)
                        dtEditCt_PhoiGiao.ImportRow(drCurrent);
                    else
                        dtEditCt_PhoiGiao.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_PhoiGiao.Current).Row);
                }
                bdsEditCt_PhoiGiao.Position = bdsEditCt_PhoiGiao.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_PhoiGiao.AcceptChanges();
            }
            else
                dtEditCt_PhoiGiao.RejectChanges();
        }
       
       
        private void Delete_ThietBi()
        {
            if (bdsEditCt_ThietBi.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_ThietBi.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11THIETBI", drCurrent))
            {
                bdsEditCt_ThietBi.RemoveAt(bdsEditCt_ThietBi.Position);
                dtEditCt_ThietBi.AcceptChanges();
            }
        }
        private void Delete_SuCo()
        {
            if (bdsEditCt_SuCo.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_SuCo.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11SUCO", drCurrent))
            {
                bdsEditCt_SuCo.RemoveAt(bdsEditCt_SuCo.Position);
                dtEditCt_SuCo.AcceptChanges();
            }
        }
        private void Delete_DLSXPhoi()
        {
            if (bdsEditCt_DLSXPhoi.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_DLSXPhoi.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11DLSX_XPHOI", drCurrent))
            {
                bdsEditCt_DLSXPhoi.RemoveAt(bdsEditCt_DLSXPhoi.Position);
                dtEditCt_DLSXPhoi.AcceptChanges();
            }
        }
        private void Delete_DLSXThep()
        {
            if (bdsEditCt_DLSXThep.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_DLSXThep.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11DLSX_NTHEP", drCurrent))
            {
                bdsEditCt_DLSXThep.RemoveAt(bdsEditCt_DLSXThep.Position);
                dtEditCt_DLSXThep.AcceptChanges();
            }
        }
        private void Delete_TSQTCan()
        {
            if (bdsEditCt_TSQT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_TSQT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11TSQTCAN", drCurrent))
            {
                bdsEditCt_TSQT.RemoveAt(bdsEditCt_TSQT.Position);
                dtEditCt_TSQT.AcceptChanges();
            }
        }
        private void Delete_PhoiGiao()
        {
            if (bdsEditCt_PhoiGiao.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_PhoiGiao.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R11DLSX_PHOIGIAO", drCurrent))
            {
                bdsEditCt_PhoiGiao.RemoveAt(bdsEditCt_PhoiGiao.Position);
                dtEditCt_PhoiGiao.AcceptChanges();
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
            ht.Add("LOAI_SX", "CAN");
        
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLSXCAN", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }

            LoadCombo();
		}

		void btPrevious_Click(object sender, EventArgs e)
		{
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MovePrevious();
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCa_Sx.SelectedValue != null)
                this.cboCa_Sx.SelectedValue = this.strStt;
		}

		void btLast_Click(object sender, EventArgs e)
		{
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MoveLast();
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCa_Sx.SelectedValue != null)
                this.cboCa_Sx.SelectedValue = this.strStt;
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
                    this.cboCa_Sx.SelectedValue = this.strStt;
            }
		}

        void btFirst_Click(object sender, EventArgs e)
        {
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MoveFirst();

            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCa_Sx.SelectedValue != null)
                this.cboCa_Sx.SelectedValue = this.strStt;

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
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        //private void lbtTen_KCS_Click(object sender, EventArgs e)
        //{

        //}

	}
}
