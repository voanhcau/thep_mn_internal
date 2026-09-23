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
using System.Net;


namespace RosyModule
{
	public partial class frmDuyetYeuCau : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtDuyet_Ct;
		public DataTable dtDuyet_Ph;
        public DataTable dtDuyet_Ct_SO;
        public DataTable dtDuyet_Ph_SO;
		public DataTable dtResource;
		public DataTable dtHistory;
        public DataTable dtCtYeuCau;

		BindingSource bdsDuyet = new BindingSource();
		BindingSource bdsDuyet_Ph = new BindingSource();
		BindingSource bdsResource = new BindingSource();
		BindingSource bdsHistory = new BindingSource();
        BindingSource bdsCtYeuCau = new BindingSource();

		DataRow drDuyet;
		string strMa_Ct = string.Empty;
        string strMa_Tte = string.Empty;
		string strStt = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;

		bool bDuyet_Tp = false;
		bool bDuyet_PxCd = false;
		bool bDuyet_KtCdAt = false;
		bool bDuyet_KhVt = false;
        bool bDuyet_TcHc = false;
		bool bDuyet_KtTc = false;
		bool bDuyet_Gd = false;

		bool bDuyet_Tp_Ph = false;
		bool bDuyet_PxCd_Ph = false;
		bool bDuyet_KtCdAt_Ph = false;
		bool bDuyet_KtTc_Ph = false;
		bool bDuyet_KhVt_Ph = false;
        bool bDuyet_TcHc_Ph = false;
		bool bDuyet_Gd_Ph = false;
        bool bDuyet_Huy = false;
        bool bDuyet_Dnx = false;
        string strColumnName = string.Empty;
		#endregion

		#region Contructor

		public frmDuyetYeuCau()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			btUpdate_Tk.Click += new EventHandler(btUpdate_Tk_Click);
			btCheck_Yeu_Cau.Click += new EventHandler(btCheck_Yeu_Cau_Click);
			btCheck_Dt.Click += new EventHandler(btCheck_Dt_Click);
			btCheck_Gia.Click+=new EventHandler(btCheck_Gia_Click);
			
            btOpen_Bg.Click += new EventHandler(btOpen_Bg_Click);
			
            btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
            btCheckVTPTTD.Click += new EventHandler(btCheckVTPTTD_Click);

			txtGD_Duyet.Validating += new CancelEventHandler(txtGD_Duyet_Validating);
			dgvDuyet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
            dgvDuyet.CellValidated += new DataGridViewCellEventHandler(dgvDuyet_CellValidated);
            bdsDuyet.PositionChanged += new EventHandler(bdsDuyet_PositionChanged);
			
		}

        

		#endregion

		#region Method

		public void Load(DataRow drDuyet, bool Is_Duyet, string strColumnName)
		{
			this.drDuyet = drDuyet;

			this.strMa_Ct = (string)drDuyet["Ma_Ct"];
			this.strStt = (string)drDuyet["Stt"];
            this.strColumnName = strColumnName;
           
            
            chkDuyet.Checked = Is_Duyet;
            chkDuyet_Huy.Checked = (bool)drDuyet["Duyet_Huy"];
            drDmCt_Current = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
            Build();
			FillData();
			BindingLanguage();
            DataGridView_Language();
            
            if (strColumnName == "DUYET_GIAMDOC")
                chkDuyet_Huy.Visible = true;
            else
                chkDuyet_Huy.Visible = false;

			if (!Common.InlistLike(strMa_Ct, "DT,DTCP,DTNA,PYC,PO"))
			{
				tbHistory.Visible = false;
                tbCtYeuCau.Visible = false;
                tbAttach.Visible = false;
                btNew.Visible = false;
                btEdit.Visible = false;
                btDelete.Visible = false;
                btCheck_Dt.Visible = false;
                btCheck_Yeu_Cau.Visible = false;
                btOpen_Bg.Visible = false;
                btUpdate_Tk.Visible = false;
                btCheck_Gia.Visible = false;
                txtGD_Duyet.Visible = false;
                lbtTen_Gd_Duyet.Visible = false;
                lblGiam_Doc_Duyet.Visible = false;

                if (Common.InlistLike(strMa_Ct, "PYC"))
                {
                    btNew.Visible = true;
                    btEdit.Visible = true;
                    btDelete.Visible = true;
                }
              
                if (Common.Inlist(strMa_Ct, "SO,SOCP") && strColumnName == "DUYET")
                {
                    lblGhi_Chu_PKTTC.Visible = true;
                    txtGhi_Chu_PKTTC.Visible = true;
                    

                    if (bDuyet_Huy)
                        chkDuyet.Enabled = false;
                }
                
			}
			else
			{
                if (Common.Inlist(strMa_Ct, "DT") && strColumnName == "DUYET_KHVT")
                {
                    lblGhi_Chu_PKTTC.Visible = true;
                    lblGhi_Chu_PKTTC.Text = "Lý do PKHVT duyệt chậm";
                    txtLyDo_Cham_KHVT.Visible = true;
                }
                else if (Common.Inlist(strMa_Ct, "DTNA"))
                {
                    lblGhi_Chu_PKTTC.Visible = true;
                    lblGhi_Chu_PKTTC.Text = "Diễn giải";
                    txtLyDo_Cham_KHVT.Visible = true;
                }
				tbHistory.Visible = true;
				btNew.Visible = true;
				btEdit.Visible = true;
				btDelete.Visible = true;
			}

            BindingTong_Tien();
			this.LoadDicName();
			this.ShowDialog();
		}
        private void BindingTong_Tien()
        {
            numTTien0.DataBindings.Add("Value", bdsDuyet_Ph, "TTien0");
            numTTien_Nt0.DataBindings.Add("Value", bdsDuyet_Ph, "TTien_Nt0");

            numTTien3.DataBindings.Add("Value", bdsDuyet_Ph, "TTien3");
            numTTien_Nt3.DataBindings.Add("Value", bdsDuyet_Ph, "TTien_Nt3");

            numTSo_Luong.DataBindings.Add("Value", bdsDuyet_Ph, "TSo_Luong");

        }
        void DataGridView_Language()
        {
            if (Common.InlistLike(strMa_Ct, "PYC,DT,PO"))
            {
                if (dgvDuyet.Columns.Contains("So_Luong9"))
                    dgvDuyet.Columns["So_Luong9"].HeaderText = "Số lượng duyệt TGD";
            }

            if (Common.InlistLike(strMa_Ct, "DTNA"))
            {
                if (dgvDuyet.Columns.Contains("Chenh_Lech"))
                    dgvDuyet.Columns["Chenh_Lech"].HeaderText = "Chênh lệch so với kì trước";
                if (dgvDuyet.Columns.Contains("Ngay_Ap"))
                    dgvDuyet.Columns["Ngay_Ap"].HeaderText = "Kỳ trước";
            }
            if (Common.InlistLike(strMa_Ct, "POCG"))
            {
              
                dgvDuyet.Columns["Ten_NCC1"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvDuyet.Columns["Ten_NCC2"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvDuyet.Columns["Ten_NCC3"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvDuyet.Columns["Ten_NCC_Chon"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            Voucher.FormatTien_Nt(dgvDuyet, strMa_Tte);
        }
		void LoadDicName()
		{
            if (dgvDuyet.Columns.Contains("MA_DT_CBNV_MH"))
                ((dgvTextBoxColumn)dgvDuyet.Columns["Ma_Dt_CbNv_Mh"]).bUseAutoDropDown = true;

			//txtMa_Nvu
			if (txtGD_Duyet.Text.Trim() != string.Empty)
				lbtTen_Gd_Duyet.Text = DataTool.SQLGetNameByCode("R00Member", "Member_ID", "Member_Name", txtGD_Duyet.Text.Trim());
			else
				lbtTen_Gd_Duyet.Text = string.Empty;
		}

		void Build()
		{
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

            //if (strMa_Ct == "POCG")
            //    dgvDuyet.strZone = "POCG_EDITCT3";
            ////else if (strMa_Ct == "POXL")
            ////    dgvDuyet.strZone = "POXL_EDITCT3";
            //else
		    dgvDuyet.strZone =drDmCt["Zone_EditCt4"].ToString();

			dgvResource.strZone = "RESOURCE_SO";
			
            if(Common.InlistLike(strMa_Ct, "PYC"))
                dgvHistory.strZone = "PYC_DT_BB";
            else
                dgvHistory.strZone = "CHECK_GIA_MUA";

            dgvCtYeuCau.strZone = "CTYEUCAU";

			dgvDuyet.BuildGridView();
			dgvResource.BuildGridView();
			dgvHistory.BuildGridView();
            dgvCtYeuCau.BuildGridView();

			foreach (DataGridViewColumn dgvc in dgvDuyet.Columns)
				dgvc.ReadOnly = true;

            

			string strCreate_User = (string)drDuyet["Create_Log"];

			string strMa_Nh_User = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + Element.sysUser_Id + "')") + "";
            //string strMa_Nh_Create = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + strCreate_User.Substring(14) + "'") + "";
            string strMa_Nh_Create = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + strCreate_User.Substring(14) + "')");
             chkDuyet.Enabled = false;
            this.btgAccept.btAccept.Enabled = false;

            DataRow drPh = DataTool.SQLGetDataRowByID(drDmCt["Table_Ph"].ToString(), "Stt", strStt);
            bDuyet_Tp_Ph = (bool)drPh["Duyet_Tp"];
            bDuyet_PxCd_Ph = (bool)drPh["Duyet_PxCd"];
            bDuyet_KtCdAt_Ph = (bool)drPh["Duyet_KtCdAt"];
            bDuyet_KhVt_Ph = (bool)drPh["Duyet_KhVt"];
            bDuyet_TcHc_Ph = (bool)drPh["Duyet_TcHc"];
            bDuyet_KtTc_Ph = (bool)drPh["Duyet_KtTc"];
            bDuyet_Gd_Ph = (bool)drPh["Duyet_GiamDoc"];
            bDuyet_Huy = (bool)drPh["Duyet_Huy"];

            if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,PYCTH"))
            {
                bDuyet_Tp = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
            }
            else
            {
                bDuyet_Tp = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
                if (!bDuyet_Tp)
                    bDuyet_Tp = Common.CheckPermission("IS_PTP", enuPermission_Type.Allow_Access);
            }
			bDuyet_PxCd = Common.CheckPermission("IS_TP_PXCD", enuPermission_Type.Allow_Access);
			bDuyet_KtCdAt = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
			bDuyet_KhVt = Common.CheckPermission("IS_TP_KHVT", enuPermission_Type.Allow_Access);
            bDuyet_TcHc = Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access);
			bDuyet_KtTc = Common.CheckPermission("IS_TP_KTTC", enuPermission_Type.Allow_Access);
			bDuyet_Gd = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);
            bDuyet_Dnx = Common.CheckPermission("IS_DUYET_DNX", enuPermission_Type.Allow_Access);
			//}

			if (bDuyet_KhVt == true && strMa_Ct != "DTCP")
			{
                if (strMa_Ct == "PYCCK" && !bDuyet_KtCdAt_Ph)
					txtGD_Duyet.Enabled = true;
				else
					txtGD_Duyet.Enabled = true;
			}
            else if (bDuyet_KtCdAt && strMa_Ct == "DTCP")
                txtGD_Duyet.Enabled = true;
			else
				txtGD_Duyet.Enabled = false;

            if (Common.Inlist(strMa_Ct, "DTNA,DTXE"))
            {
                if (bDuyet_KtTc && strColumnName == "DUYET_KTTC")
                {
                    if (bDuyet_Gd_Ph)
                        chkDuyet.Enabled = false;
                    else if (!bDuyet_Tp_Ph)
                        chkDuyet.Enabled = false;
                    else
                    {
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;

                        if (dgvDuyet.Columns.Contains("So_Luong_KTTC"))
                            dgvDuyet.Columns["So_Luong_KTTC"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KTTC"))
                            dgvDuyet.Columns["Ghi_Chu_KTTC"].ReadOnly = false;
                    }

                }
				if (bDuyet_Gd)
				{
                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

					if (dgvDuyet.Columns.Contains("So_Luong9"))
						dgvDuyet.Columns["So_Luong9"].ReadOnly = false;

					if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
						dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;

                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;
				}
			
            }
            if (Common.Inlist(strMa_Ct, "DTCP"))
            {
                if (bDuyet_KtTc && strColumnName == "DUYET_KTTC")
                {
                    if (bDuyet_Gd_Ph)
                        chkDuyet.Enabled = false;
                    else if (!bDuyet_KtCdAt_Ph)
                        chkDuyet.Enabled = false;
                    else
                    {
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;

                        if (dgvDuyet.Columns.Contains("So_Luong_KTTC"))
                            dgvDuyet.Columns["So_Luong_KTTC"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KTTC"))
                            dgvDuyet.Columns["Ghi_Chu_KTTC"].ReadOnly = false;
                    }

                }
                if (bDuyet_Gd)
                {
                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

                    if (dgvDuyet.Columns.Contains("So_Luong9"))
                        dgvDuyet.Columns["So_Luong9"].ReadOnly = false;

                    if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
                        dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;

                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;
                }

            }
            if (Common.Inlist(strMa_Ct , "DT"))
			{
                if (bDuyet_KhVt && strColumnName == "DUYET_KHVT")
				{
					
                    if (bDuyet_KtTc_Ph)
                        chkDuyet.Enabled = false;
                    else
                    {
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;

                        if (dgvDuyet.Columns.Contains("So_Luong_KHVT"))
                            dgvDuyet.Columns["So_Luong_KHVT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KHVT"))
                            dgvDuyet.Columns["Ghi_Chu_KHVT"].ReadOnly = false;

                    }

				}
                
				
                if (bDuyet_KtTc && strColumnName == "DUYET_KTTC")
                {
                    if (bDuyet_Gd_Ph)
                        chkDuyet.Enabled = false;
                    else if (!bDuyet_KhVt_Ph)
                        chkDuyet.Enabled = false;
                    else
                    {
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;

                        if (dgvDuyet.Columns.Contains("So_Luong_KTTC"))
                            dgvDuyet.Columns["So_Luong_KTTC"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KTTC"))
                            dgvDuyet.Columns["Ghi_Chu_KTTC"].ReadOnly = false;
                    }

                }
				if (bDuyet_Gd)
				{
                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

					if (dgvDuyet.Columns.Contains("So_Luong9"))
						dgvDuyet.Columns["So_Luong9"].ReadOnly = false;

					if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
						dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;

                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;
				}
			}
			else if (strMa_Ct == "POCG")
			{
				if (bDuyet_KhVt && !bDuyet_KtTc_Ph)
				{
                    this.chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

					if (dgvDuyet.Columns.Contains("So_Luong_KHVT"))
						dgvDuyet.Columns["So_Luong_KHVT"].ReadOnly = false;

					if (dgvDuyet.Columns.Contains("Ghi_Chu_KHVT"))
						dgvDuyet.Columns["Ghi_Chu_KHVT"].ReadOnly = false;
				}

				if (bDuyet_KtCdAt && !bDuyet_KtCdAt && bDuyet_KtTc_Ph)
				{
                    this.chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

					if (dgvDuyet.Columns.Contains("So_Luong_KTCDAT"))
						dgvDuyet.Columns["So_Luong_KTCDAT"].ReadOnly = false;

					if (dgvDuyet.Columns.Contains("Ghi_Chu_KTCDAT"))
						dgvDuyet.Columns["Ghi_Chu_KTCDAT"].ReadOnly = false;
				}

				if (bDuyet_KtTc && !bDuyet_Gd_Ph)
				{
                    this.chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

					if (dgvDuyet.Columns.Contains("So_Luong_KTTC"))
						dgvDuyet.Columns["So_Luong_KTTC"].ReadOnly = false;

					if (dgvDuyet.Columns.Contains("Ghi_Chu_KTTC"))
						dgvDuyet.Columns["Ghi_Chu_KTTC"].ReadOnly = false;
				}
				if (bDuyet_Gd)
				{
                    this.chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

					if (dgvDuyet.Columns.Contains("So_Luong9"))
						dgvDuyet.Columns["So_Luong9"].ReadOnly = false;


					if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
						dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;
				}
			}
			else if (strMa_Ct == "PYCCK")
			{
                if (bDuyet_Tp && Common.Inlist(strMa_Nh_Create, strMa_Nh_User) && strColumnName == "DUYET_TP")
                {
                    if (dgvDuyet.Columns.Contains("So_Luong_TP"))
                        dgvDuyet.Columns["So_Luong_TP"].ReadOnly = false;

                    if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                        dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = false;
                    
                    this.chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

                    if (bDuyet_KtCdAt_Ph)
                    {
                        if (dgvDuyet.Columns.Contains("So_Luong_TP"))
                            dgvDuyet.Columns["So_Luong_TP"].ReadOnly = true;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                            dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = true;

                        chkDuyet.Enabled = false;
                    }
                }
				
				if (bDuyet_KtCdAt && strColumnName == "DUYET_KTCDAT")
				{
                    if (bDuyet_KhVt_Ph)
                        chkDuyet.Enabled = false;
                    else
                    {
                        if (dgvDuyet.Columns.Contains("So_Luong_KTCDAT"))
                            dgvDuyet.Columns["So_Luong_KTCDAT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KTCDAT"))
                            dgvDuyet.Columns["Ghi_Chu_KTCDAT"].ReadOnly = false;
                        
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;
                    }
				}
				if (bDuyet_KhVt && strColumnName == "DUYET_KHVT")
				{
                    if (bDuyet_Gd_Ph)
                        chkDuyet.Enabled = false;
                    else
                    {
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;
                        if (dgvDuyet.Columns.Contains("So_Luong_KHVT"))
                            dgvDuyet.Columns["So_Luong_KHVT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KHVT"))
                            dgvDuyet.Columns["Ghi_Chu_KHVT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ma_Dt_CbNv_Mh"))
                            dgvDuyet.Columns["Ma_Dt_CbNv_Mh"].ReadOnly = false;
                    }
				}
				if (bDuyet_PxCd && strColumnName == "DUYET_PXCD")
				{
                    if (bDuyet_KtCdAt_Ph)
                        chkDuyet.Enabled = false;
                    else
                    {
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;
                        if (dgvDuyet.Columns.Contains("So_Luong_PXCD"))
                            dgvDuyet.Columns["So_Luong_PXCD"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_PXCD"))
                            dgvDuyet.Columns["Ghi_Chu_PXCD"].ReadOnly = false;
                    }
				}
				if (bDuyet_Gd)
				{
                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;
					if (dgvDuyet.Columns.Contains("So_Luong9"))
						dgvDuyet.Columns["So_Luong9"].ReadOnly = false;

					if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
						dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;
				}
			
			}
            else if (strMa_Ct == "DNX")
            {
                if (strMa_Nh_Create == "41PXCAN,41PXLUY")
                    strMa_Nh_Create = "41PXLUY";
                //41PXCAN,41PXLUY,   41PXCAN,41PXLUY
                if (bDuyet_Tp && Common.Inlist(strMa_Nh_Create, strMa_Nh_User) && strColumnName == "DUYET_TP")
                {
                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

                    if (dgvDuyet.Columns.Contains("So_Luong_TP"))
                        dgvDuyet.Columns["So_Luong_TP"].ReadOnly = false;

                    if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                        dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = false;

                    if (bDuyet_KtCdAt_Ph)
                    {
                        if (dgvDuyet.Columns.Contains("So_Luong_TP"))
                            dgvDuyet.Columns["So_Luong_TP"].ReadOnly = true;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                            dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = true;

                        chkDuyet.Enabled = false;
                    }
                }
                
                if (bDuyet_KtCdAt && !Element.sysIs_Admin)
                    Common.MsgOk("Vui lòng chọn xuất theo vị trí kho");

                if (bDuyet_Dnx && strColumnName == "DUYET_KHVT")
                {

                    if (dgvDuyet.Columns.Contains("So_Luong_KHVT"))
                        dgvDuyet.Columns["So_Luong_KHVT"].ReadOnly = false;

                    if (dgvDuyet.Columns.Contains("Ghi_Chu_KHVT"))
                        dgvDuyet.Columns["Ghi_Chu_KHVT"].ReadOnly = false;

                    if (dgvDuyet.Columns.Contains("Ma_Dt_CbNv_Mh"))
                        dgvDuyet.Columns["Ma_Dt_CbNv_Mh"].ReadOnly = false;

                   chkDuyet.Enabled = true;
                   this.btgAccept.btAccept.Enabled = true;
                }
            }
            else if (strMa_Ct == "DNXNL")
            {
                if (bDuyet_Tp && Common.Inlist(strMa_Nh_Create, strMa_Nh_User) && strColumnName == "DUYET_TP")
                {
                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

                    if (dgvDuyet.Columns.Contains("So_Luong_TP"))
                        dgvDuyet.Columns["So_Luong_TP"].ReadOnly = false;

                    if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                        dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = false;
                   

                    if (bDuyet_KhVt_Ph)
                    {
                        if (dgvDuyet.Columns.Contains("So_Luong_TP"))
                            dgvDuyet.Columns["So_Luong_TP"].ReadOnly = true;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                            dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = true;

                        chkDuyet.Enabled = false;
                        
                    }
                }

                if (bDuyet_KhVt && strColumnName == "DUYET_KHVT")
                {
                    if (bDuyet_Gd_Ph)
                    {
                        chkDuyet.Enabled = false;
                    }
                    else
                    {
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;
                        if (dgvDuyet.Columns.Contains("So_Luong_KHVT"))
                            dgvDuyet.Columns["So_Luong_KHVT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KHVT"))
                            dgvDuyet.Columns["Ghi_Chu_KHVT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ma_Dt_CbNv_Mh"))
                            dgvDuyet.Columns["Ma_Dt_CbNv_Mh"].ReadOnly = false;
                    }
                }

                if (bDuyet_Gd)
                {
                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

                    if (dgvDuyet.Columns.Contains("So_Luong9"))
                        dgvDuyet.Columns["So_Luong9"].ReadOnly = false;

                    if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
                        dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;
                }

               
            }
            else if (Common.InlistLike(strMa_Ct, "SO"))
            {
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;
            } 
            else
            {
                if (bDuyet_Tp && Common.Inlist(strMa_Nh_Create,strMa_Nh_User) && strColumnName == "DUYET_TP")
                {
                    if (bDuyet_KtCdAt_Ph)
                    {
                        chkDuyet.Enabled = false;
                    }
                    else
                    {
                        if (dgvDuyet.Columns.Contains("So_Luong_TP"))
                            dgvDuyet.Columns["So_Luong_TP"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                            dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = false;

                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;
                    }
                }
                

              

                if ((bDuyet_KtCdAt || bDuyet_TcHc) && strColumnName == "DUYET_KTCDAT")
                {
                    if (bDuyet_KhVt_Ph)
                    {
                        chkDuyet.Enabled = false;
                        this.btgAccept.btAccept.Enabled = false;
                    }
                    else
                    {
                        
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;

                        if (dgvDuyet.Columns.Contains("So_Luong_KTCDAT"))
                            dgvDuyet.Columns["So_Luong_KTCDAT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KTCDAT"))
                            dgvDuyet.Columns["Ghi_Chu_KTCDAT"].ReadOnly = false;
                    }
                }

                if (bDuyet_KhVt && strColumnName == "DUYET_KHVT")
                {
                    if (bDuyet_Gd_Ph)
                    {
                        chkDuyet.Enabled = false;
                    }
                    else
                    {
                        chkDuyet.Enabled = true;
                        this.btgAccept.btAccept.Enabled = true;
                        if (dgvDuyet.Columns.Contains("So_Luong_KHVT"))
                            dgvDuyet.Columns["So_Luong_KHVT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ghi_Chu_KHVT"))
                            dgvDuyet.Columns["Ghi_Chu_KHVT"].ReadOnly = false;

                        if (dgvDuyet.Columns.Contains("Ma_Dt_CbNv_Mh"))
                            dgvDuyet.Columns["Ma_Dt_CbNv_Mh"].ReadOnly = false;
                    }
                }

                if (bDuyet_Gd)
                {
                    chkDuyet.Enabled = true;
                    this.btgAccept.btAccept.Enabled = true;

                    if (dgvDuyet.Columns.Contains("So_Luong9"))
                        dgvDuyet.Columns["So_Luong9"].ReadOnly = false;

                    if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
                        dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;
                }
               
              
            }
            
		}

		void FillData()
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", strStt);
            htPara.Add("MA_CT_LIST", strMa_Ct);
            htPara.Add("USER_LOGIN", Element.sysUser_Id);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", htPara, CommandType.StoredProcedure);

			dtDuyet_Ph = dsVoucher.Tables[0];
			dtDuyet_Ct = dsVoucher.Tables[1];
            strMa_Tte = dtDuyet_Ct.Rows[0]["Ma_TTe"].ToString();
            if (dsVoucher.Tables.Count >= 3)
            {
                dtResource = dsVoucher.Tables[2];
                dtCtYeuCau = dsVoucher.Tables[3];
            }
            //Xem chi tiết lịch sử
            if (Common.InlistLike(strMa_Ct, "PYC"))
            {
                Hashtable htPara1 = new Hashtable();
                htPara1.Add("STT", strStt);
                htPara1.Add("MA_CT", strMa_Ct);
                dtHistory = SQLExec.ExecuteReturnDt("dbo.sp_GetPYC_DT_BB", htPara1, CommandType.StoredProcedure);
            }
            else if (Common.InlistLike(strMa_Ct, "DT"))
            {
                Hashtable htPara2 = new Hashtable();
                htPara2.Add("STT", strStt);

                dtHistory = SQLExec.ExecuteReturnDt("dbo.sp_CheckGia", htPara2, CommandType.StoredProcedure);
            }
            
            bdsDuyet_Ph.DataSource = dtDuyet_Ph;
			bdsDuyet.DataSource = dtDuyet_Ct;

            //if (strMa_Ct.StartsWith("DT"))
            //{
            //    bdsDuyet.Filter = "Tien <> 0";
            //}

			bdsResource.DataSource = dtResource;
            bdsHistory.DataSource = dtHistory;

			dgvDuyet.DataSource = bdsDuyet;
			dgvResource.DataSource = bdsResource;
			dgvHistory.DataSource = bdsHistory;

            
            bdsCtYeuCau.DataSource = dtCtYeuCau;
            dgvCtYeuCau.DataSource = bdsCtYeuCau;
            
			string strGd_Duyet = "SELECT Gd_Duyet FROM R80PH WHERE Stt = '" + strStt + "'";
			txtGD_Duyet.Text = SQLExec.ExecuteReturnValue(strGd_Duyet).ToString();
            //LyDo_Cham_KHVT
            string strLyDo_Cham_KHVT = "SELECT LyDo_Cham_KHVT FROM R80PH WHERE Stt = '" + strStt + "'";
            txtLyDo_Cham_KHVT.Text = SQLExec.ExecuteReturnValue(strLyDo_Cham_KHVT).ToString();

            if (Common.Inlist(strMa_Ct, "DTNA"))
                txtLyDo_Cham_KHVT.Text = dtDuyet_Ph.Rows[0]["Dien_Giai"].ToString();

        }

		bool FormCheckValid()
		{
            //KIỂM TRA NẾU LÀ DT thì cảnh báo nếu đã lập BBNT
            if(bDuyet_KhVt && Common.InlistLike(strMa_Ct,"PYC,DT,PO"))
            {
                if(txtGD_Duyet.Text == "") { Common.MsgOk("Phiếu chưa được nhập tên giám đốc duyệt phiếu."); }
                if(txtGD_Duyet.Text != "" && SQLExec.ExecuteReturnDt("SELECT * FROM R00MEMBER WHERE Member_ID = '"+ txtGD_Duyet.Text +" ' AND Member_ID IN (select Member_ID from R00MEMBERGROUP where Member_Group_ID = ''NQL'')").Rows.Count == 0) { Common.MsgOk("Tên giám đốc duyệt không phù hợp, anh (chị) cần sửa lại thông tin giám đốc duyệt."); }    
                return false;
            }
           
            return true;
		}

		#endregion

		//#region Event
		void txtGD_Duyet_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtGD_Duyet.Text.Trim();
			bool bRequire = false;
            string strKey = " Member_ID IN (select Member_ID from R00MEMBERGROUP where Member_Group_ID = 'NQL')";


			DataRow drLookup = Lookup.ShowLookup("Member_ID", strValue, bRequire, strKey);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtGD_Duyet.Text = string.Empty;
				lbtTen_Gd_Duyet.Text = string.Empty;
			}
			else
			{
				txtGD_Duyet.Text = drLookup["Member_ID"].ToString();
				lbtTen_Gd_Duyet.Text = drLookup["Member_Name"].ToString();

			}
		}

		void btOpen_Bg_Click(object sender, EventArgs e)
		{
			if (bdsResource.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsResource.Current).Row;
        
			string strFileName = (string)drCurrent["File_Name"] + '.' + drCurrent["Tag"];// +".pdf";
            object objFile = (object)drCurrent["File_Path"];
            string strPath = (string)drCurrent["File_Path"];
            strPath = "\\\\" + Tool.GetIPServer() + strPath;
            try
            {
                if (objFile != null && objFile != DBNull.Value)// && ((Byte[])objFile).Length > 0)
                {
                    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                    fileStream.Close();
                    System.Diagnostics.Process.Start(strPath);
                }
                else
                    Common.MsgOk("Không có file attach");
            }
            catch (Exception ex)
            {
                if (Common.InlistLike(ex.Message, "Could not find a part of the path"))
                {

                    NetworkCredential myCred = new NetworkCredential(
                                   "thepmiennam\bangvtk", "bang160619", Tool.GetIPServer());

                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(new Uri(Tool.GetIPServer()), "Basic", myCred);
                    WebRequest wr = WebRequest.Create(Tool.GetIPServer());
                    wr.Credentials = myCache;
                }
                else if (Common.InlistLike(ex.Message, "The user name or password is incorrect."))
                {
                    Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\" + Tool.GetIPServer() + " để mở file");
                    System.Diagnostics.Process.Start("explorer.exe", @"\\" + Tool.GetIPServer() + "");

                }

            }
           
		}

		void btCheck_Dt_Click(object sender, EventArgs e)
		{
			if (bdsDuyet_Ph.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDuyet.Current).Row;
			bool bInVisibleNextPrint = false;
			
			Voucher.Print(drCurrent["Stt"].ToString(), true, true, ref bInVisibleNextPrint);
		}

		void btCheck_Yeu_Cau_Click(object sender, EventArgs e)
		{
			if (bdsDuyet_Ph.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDuyet.Current).Row;
			bool bInVisibleNextPrint = false;

			if(Common.InlistLike(strMa_Ct,"DT,DTVPP"))
				Voucher.Print(drCurrent["Stt_Org"].ToString(), true, true, ref bInVisibleNextPrint);
			else
				Voucher.Print(drCurrent["Stt"].ToString(), true, true, ref bInVisibleNextPrint);
		}
		void btCheck_Gia_Click(object sender, EventArgs e)
		{
			if (bdsDuyet_Ph.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDuyet.Current).Row;
			frmCheck_Gia_Mua frm = new frmCheck_Gia_Mua();
			frm.Load(drCurrent);
		}
		void btUpdate_Tk_Click(object sender, EventArgs e)
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT", DateTime.Now);
			htPara.Add("STT", strStt);
			htPara.Add("MA_CT", strMa_Ct);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);
			SQLExec.ExecuteReturnDt("Sp_UpdateTonCuoi_KKho", htPara, CommandType.StoredProcedure);
			
			FillData();
		}

		void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			drCurrent = ((DataRowView)bdsDuyet.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
			bool bLookup = true;

			//Xu ly Lookup
			if (this.ActiveControl == null)
				return;

			if (Common.Inlist(strColumnName, "MA_VT"))
			{
				bLookup = dgvLookupMa_Vt(ref dgvCell);
			}
            else if (strColumnName == "MA_DT_CBNV_MH")
                bLookup = dgvLookupMa_Dt_CbNv_Mh(ref dgvCell);
			
            if (Common.Inlist(strMa_Ct,"DT,DTCP,POCG"))
			{
                if (Common.Inlist(strColumnName, "SO_LUONG_TP") && !dgvCell.DataGridView.Columns["SO_LUONG_TP"].ReadOnly && strMa_Ct == "DTCP")
                {
                    //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_Tp"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của TP đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
                           
                            drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_Tp"];
                            drCurrent["So_Luong_KtTc"] = drCurrent["So_Luong_Tp"];
                            drCurrent["So_Luong9"] = drCurrent["So_Luong_Tp"];
                            drCurrent["So_Luong"] = drCurrent["So_Luong_Tp"];
                        }
                        else
                            drCurrent["So_Luong_Tp"] = drCurrent["So_Luong"];
                    }
                    else
                    {
                        drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_Tp"];
                        drCurrent["So_Luong_Kttc"] = drCurrent["So_Luong_Tp"];
                        drCurrent["So_Luong9"] = drCurrent["So_Luong_Tp"];
                        drCurrent["So_Luong"] = drCurrent["So_Luong_Tp"];
                    }
                }

                if (Common.Inlist(strColumnName, "SO_LUONG_KTCDAT") && !dgvCell.DataGridView.Columns["SO_LUONG_KTCDAT"].ReadOnly && strMa_Ct == "DTCP")
                {
                    //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_KtCdAt"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của PKTDT đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {

                        
                            drCurrent["So_Luong_KtTc"] = drCurrent["So_Luong_KtCdAt"];
                            drCurrent["So_Luong9"] = drCurrent["So_Luong_KtCdAt"];
                            drCurrent["So_Luong"] = drCurrent["So_Luong_KtCdAt"];
                        }
                        else
                            drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong"];
                    }
                    else
                    {

                        drCurrent["So_Luong_Kttc"] = drCurrent["So_Luong_KtCdAt"];
                        drCurrent["So_Luong9"] = drCurrent["So_Luong_KtCdAt"];
                        drCurrent["So_Luong"] = drCurrent["So_Luong_KtCdAt"];
                    }
                }
				if (Common.Inlist(strColumnName, "SO_LUONG_KHVT") && !dgvCell.DataGridView.Columns["SO_LUONG_KHVT"].ReadOnly && Common.Inlist(strMa_Ct, "DT,POCG"))
				{
                    //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_KhVt"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của PKHVT đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
                            drCurrent["So_Luong_Kttc"] = drCurrent["So_Luong_KhVt"];
                            drCurrent["So_Luong9"] = drCurrent["So_Luong_KhVt"];
                            drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        }
                        else
                            drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong"];
                    }
                    else
                    {
                        drCurrent["So_Luong_Kttc"] = drCurrent["So_Luong_KhVt"];
                        drCurrent["So_Luong9"] = drCurrent["So_Luong_KhVt"];
                        drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    }
				}

                
				if (Common.Inlist(strColumnName, "SO_LUONG_KTTC") && !dgvCell.DataGridView.Columns["SO_LUONG_KTTC"].ReadOnly)
				{
                    //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_Kttc"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của PKTTC đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
                            drCurrent["So_Luong9"] = drCurrent["So_Luong_Kttc"];
                            drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        }
                        else
                            drCurrent["So_Luong_Kttc"] = drCurrent["So_Luong"];
                    }
                    else
                    {
                        drCurrent["So_Luong9"] = drCurrent["So_Luong_Kttc"];
                        drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    }

					
				}
				if (Common.Inlist(strColumnName, "SO_LUONG9") && !dgvCell.DataGridView.Columns["SO_LUONG9"].ReadOnly)
				{
                    //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_Kttc"]) > Convert.ToDouble(drCurrent["So_Luong"]) && Common.InlistLike(strMa_Ct,"DT,POCG"))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của PTGD đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
                            drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        }
                        else
                            drCurrent["So_Luong_Kttc"] = drCurrent["So_Luong"];
                    }
                    else if (Convert.ToDouble(drCurrent["So_Luong_Ktcdat"]) > Convert.ToDouble(drCurrent["So_Luong"]) && Common.InlistLike(strMa_Ct, "PYC,PONL"))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của PTGD đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
                            drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        }
                        else
                            drCurrent["So_Luong_Kttc"] = drCurrent["So_Luong"];
                    }
                    else
                    {
                        drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    }
					
				}
                
				drCurrent["Tien_Nt9"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia_Nt9"]);
                
                drCurrent["Tien_Nt"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia_Nt"]);
                drCurrent["Tien"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia"]);
				drCurrent["Tien_Nt3"] = Convert.ToDouble(drCurrent["Tien_Nt9"]) * (Convert.ToDouble(drCurrent["Thue_GtGt"])/100);
				drCurrent["Tien3"] = drCurrent["Tien_Nt3"];
			}
			else
			{
				if (Common.Inlist(strColumnName, "SO_LUONG_TP") && !dgvCell.DataGridView.Columns["SO_LUONG_TP"].ReadOnly)
				{
                     //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_Tp"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của TP đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
                            drCurrent["So_Luong9"] = drCurrent["So_Luong_Tp"];
                            drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_Tp"];
                            drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_Tp"];
                            drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        }
                        else
                            drCurrent["So_Luong_Tp"] = drCurrent["So_Luong9"];
                    }
                    else
                    {
                        drCurrent["So_Luong9"] = drCurrent["So_Luong_Tp"];
                        drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_Tp"];
                        drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_Tp"];
                        drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    }
					if (Common.Inlist(strMa_Ct, "PYCCK"))
						drCurrent["So_Luong_PXCD"] = drCurrent["So_Luong_Tp"];
				}

				if (Common.Inlist(strMa_Ct, "PYCCK") && Common.Inlist(strColumnName, "SO_LUONG_PXCD") && !dgvCell.DataGridView.Columns["SO_LUONG_PXCD"].ReadOnly)
				{
                    //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_PXCD"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của PXCD đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
					        drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_PxCd"];
					        drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_PxCd"];
					        drCurrent["So_Luong9"] = drCurrent["So_Luong_PxCd"];
					        drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        }
                        else
                            drCurrent["So_Luong_PXCD"] = drCurrent["So_Luong9"];
                        }
                    else
                    {
                        drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_PxCd"];
					    drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_PxCd"];
					    drCurrent["So_Luong9"] = drCurrent["So_Luong_PxCd"];
					    drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    }

				}

				if (Common.Inlist(strColumnName, "SO_LUONG_KTCDAT") && !dgvCell.DataGridView.Columns["SO_LUONG_KTCDAT"].ReadOnly)
				{
                     //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_KtCdAt"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của PKTDT đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
                            drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_KtCdAt"];
                            drCurrent["So_Luong9"] = drCurrent["So_Luong_KtCdAt"];
                            drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        }
                        else
                            drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong9"];
                    }
                    else
                    {
                        drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_KtCdAt"];
                        drCurrent["So_Luong9"] = drCurrent["So_Luong_KtCdAt"];
                        drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    }
				}

				if (Common.Inlist(strColumnName, "SO_LUONG_KHVT") && !dgvCell.DataGridView.Columns["SO_LUONG_KHVT"].ReadOnly)
				{
                     //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong_KhVt"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                        if (Common.MsgYes_No("Số lượng duyệt của PKHVT đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                        {
                            drCurrent["So_Luong9"] = drCurrent["So_Luong_KhVt"];
                            drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        }
                        else
                            drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong9"];
                    }
                    else
                    {
                        drCurrent["So_Luong9"] = drCurrent["So_Luong_KhVt"];
                        drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    }
					drCurrent["Tien_Nt9"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia_Nt9"]);
					drCurrent["Tien_Nt"] = drCurrent["Tien_Nt9"];
					drCurrent["Tien"] = drCurrent["Tien_Nt9"];
				}

				if (Common.Inlist(strColumnName, "SO_LUONG9") && !dgvCell.DataGridView.Columns["SO_LUONG9"].ReadOnly)
				{
                     //Kiểm tra xem có duyệt nhầm không
                    if (Convert.ToDouble(drCurrent["So_Luong9"]) > Convert.ToDouble(drCurrent["So_Luong"]))
                    {
                         if (Common.MsgYes_No("Số lượng duyệt của PTGD đang lớn hơn số lượng đề nghị. Bạn có tiếp tục không?", "Y"))
                            drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                        //}
                        //else
                        //    drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    }
                    else
                        drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    //drCurrent["So_Luong"] = drCurrent["So_Luong9"];
                    drCurrent["Tien_Nt9"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia_Nt9"]);
					drCurrent["Tien_Nt"] = drCurrent["Tien_Nt9"];
					drCurrent["Tien"] = drCurrent["Tien_Nt9"];
				}
			}
            
            numTSo_Luong.Value = Common.SumDCValue(dtDuyet_Ct, "So_Luong9", "");
            numTTien_Nt0.Value = Common.SumDCValue(dtDuyet_Ct, "Tien_Nt", "");
            numTTien_Nt3.Value = Common.SumDCValue(dtDuyet_Ct, "Tien_Nt3", "");

			drCurrent.AcceptChanges();
		}

        void bdsDuyet_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDuyet.Position < 0)
                return;
            if (Common.InlistLike(strMa_Ct, "PYC,DT"))
            {
                drCurrent = ((DataRowView)bdsDuyet.Current).Row;
                string strMa_Vt = (string)drCurrent["Ma_Vt"];
                bdsHistory.Filter = "(Ma_Vt = '" + strMa_Vt + "')";
            }
        }
        void dgvDuyet_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            drCurrent = ((DataRowView)bdsDuyet.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (strMa_Ct == "DT")
            {
                if (strColumnName == "SO_LUONG_KHVT" && Convert.ToDouble(drCurrent["SO_LUONG_KHVT"]) > Convert.ToDouble(drCurrent["SO_LUONG0"]))
                {
                    drCurrent["SO_LUONG_KHVT"] = drCurrent["SO_LUONG_KTTC"] = drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG0"];
                    Common.MsgOk("Số lượng duyệt PKHVT không được vượt quá số lượng yêu cầu");
                }
                else if (strColumnName == "SO_LUONG_KHVT" && Convert.ToDouble(drCurrent["SO_LUONG_KHVT"]) == 0)
                {   drCurrent["SO_LUONG_KTTC"] = drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG_KHVT"];}
                if (strColumnName == "SO_LUONG_KTTC" && Convert.ToDouble(drCurrent["SO_LUONG_KTTC"]) > Convert.ToDouble(drCurrent["SO_LUONG_KHVT"]))
                {
                    drCurrent["SO_LUONG_KTTC"]= drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG_KHVT"];
                    Common.MsgOk("Số lượng duyệt PKTTC không được vượt quá số lượng duyệt PKHVT");
                }
                else if (strColumnName == "SO_LUONG_KTTC" && Convert.ToDouble(drCurrent["SO_LUONG_KTTC"]) == 0)
                { drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG_KHVT"] = drCurrent["SO_LUONG_KTTC"]; }

                if (strColumnName == "SO_LUONG9" && Convert.ToDouble(drCurrent["SO_LUONG9"]) > Convert.ToDouble(drCurrent["SO_LUONG_KTTC"]))
                {
                    drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG_KTTC"];
                    Common.MsgOk("Số lượng duyệt tổng giám đốc không được vượt quá số lượng duyệt PKTTC");
                }
                else if (strColumnName == "SO_LUONG9" && Convert.ToDouble(drCurrent["SO_LUONG9"]) == 0)
                { drCurrent["SO_LUONG"] = drCurrent["SO_LUONG9"]; }
            }
            else if (strMa_Ct == "DTCP")
            {
                if (strColumnName == "SO_LUONG_TP" && Convert.ToDouble(drCurrent["SO_LUONG_TP"]) > Convert.ToDouble(drCurrent["SO_LUONG0"]))
                {
                    drCurrent["SO_LUONG_TP"] = drCurrent["SO_LUONG_KTCDAT"] = drCurrent["SO_LUONG_KTTC"] = drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG0"];
                    Common.MsgOk("Số lượng duyệt TP không được vượt quá số lượng yêu cầu");
                }
                if (strColumnName == "SO_LUONG_KTCDAT" && Convert.ToDouble(drCurrent["SO_LUONG_KTCDAT"]) > Convert.ToDouble(drCurrent["SO_LUONG_TP"]))
                {
                    drCurrent["SO_LUONG_KTCDAT"] = drCurrent["SO_LUONG_KTTC"] = drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG0"];
                    Common.MsgOk("Số lượng duyệt TP không được vượt quá số lượng duyệt của TP");
                }
                if (strColumnName == "SO_LUONG_KTTC" && Convert.ToDouble(drCurrent["SO_LUONG_KTTC"]) > Convert.ToDouble(drCurrent["SO_LUONG_KTCDAT"]))
                {
                    drCurrent["SO_LUONG_KTTC"] = drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG_KHVT"];
                    Common.MsgOk("Số lượng duyệt PKTTC không được vượt quá số lượng duyệt PKTDT");
                }
                if (strColumnName == "SO_LUONG9" && Convert.ToDouble(drCurrent["SO_LUONG9"]) > Convert.ToDouble(drCurrent["SO_LUONG_KTTC"]))
                {
                    drCurrent["SO_LUONG9"] = drCurrent["SO_LUONG"] = drCurrent["SO_LUONG_KTTC"];
                    Common.MsgOk("Số lượng duyệt tổng giám đốc không được vượt quá số lượng duyệt PKTTC");
                }
            }
        }
        
        bool Save()
		{
            string strSo_Ct_LXH= string.Empty;
            DataRow drDuyet_Ph = ((DataRowView)bdsDuyet_Ph.Current).Row;
			if (bDuyet_KhVt && txtGD_Duyet.Text == "" && !Element.sysIs_Admin && !Common.InlistLike(strMa_Ct,"DNX,DTCP"))
			{
				Common.MsgOk("Cần bổ sung tên giám đốc duyệt yêu cầu");
				return false;
			}
            if (bDuyet_KtCdAt && txtGD_Duyet.Text == "" && !Element.sysIs_Admin && Common.InlistLike(strMa_Ct, "DTCP"))
            {
                Common.MsgOk("Cần bổ sung tên giám đốc duyệt yêu cầu");
                return false;
            }         

			if (bDuyet_PxCd && strColumnName == "DUYET_PXCD" && strMa_Ct == "PYCCK")
			{
				foreach (DataRow dr in dtDuyet_Ct.Rows)
				{
					if (dr["Ghi_Chu_PXCD"].ToString() == "" || dr["Ghi_Chu_PXCD"].ToString() == string.Empty)
					{
						Common.MsgOk("Yêu cầu PXCD cho ý kiến gia công cơ khí cho mặt hàng '"+ dr["Ten_Vt"] +"'");
						return false;
					}
				}
			}
            double dbTSo_Luong = 0;
            dbTSo_Luong = Common.SumDCValue(dtDuyet_Ct, "So_Luong", "");
            drDuyet_Ph["TSo_Luong"] = dbTSo_Luong;

			if (Common.InlistLike(strMa_Ct,"DT,PO"))
			{
				double dbTTien0 = 0;
				double dbTTien3 = 0;
                double dbTTien_Nt0 = 0;
                double dbTTien_Nt3 = 0;
               

				dbTTien_Nt0 = Common.SumDCValue(dtDuyet_Ct, "Tien_Nt", "");
                dbTTien_Nt3 = Common.SumDCValue(dtDuyet_Ct, "Tien_Nt3", "");
                dbTTien0 = Common.SumDCValue(dtDuyet_Ct, "Tien", "");
                dbTTien3 = Common.SumDCValue(dtDuyet_Ct, "Tien3", "");
                
				
				drDuyet_Ph["TTien0"] = dbTTien0;
				drDuyet_Ph["TTien3"] = dbTTien3;
				drDuyet_Ph["TTien_Nt0"] = dbTTien_Nt0;
				drDuyet_Ph["TTien_Nt3"] = dbTTien_Nt3;
               
                
			}
            
            // Xu ly khi duyệt SO tự động tạo LXH
            string strStt_LXH = string.Empty;
            bool bDuyet_Tp = (bool)drDuyet_Ph["Duyet_TP"];
            bool bDuyet_KTTC = chkDuyet.Checked;
            if (strMa_Ct == "SO" && bDuyet_Tp && bDuyet_KTTC)
            {
                string strCreate_User = (string)drDuyet_Ph["Create_Log"];
                strStt_LXH = "A0104" + drDuyet_Ph["Create_Log"].ToString().Substring(0, 6) + "X" + drDuyet_Ph["So_Ct"].ToString().Substring(1, 3);
                strSo_Ct_LXH = (string)drDuyet_Ph["So_Ct"] + "_001";
                //nếu đã tạo thì không tạo phiếu
                if (!DataTool.SQLCheckExist("R80PH", "Stt", strStt_LXH))
                {


                    //Xử lý người tạo và time tạo LXH tự động
                    string strCreate_Log = Common.GetCurrent_Log();
                    string strUser = drDuyet_Ph["Create_Log"].ToString().Substring(14, drDuyet_Ph["Create_Log"].ToString().Length - 14);
                    //lấy tên người tạo phiếu 110820:085438:YENNTN
                    strCreate_Log = Common.GetCurrent_Log().Substring(0, 14) + strUser;



                    drDuyet_Ph["Stt"] = strStt_LXH;
                    drDuyet_Ph["So_Ct"] = strSo_Ct_LXH;
                    drDuyet_Ph["Ma_Ct"] = "LXH";
                    drDuyet_Ph["Duyet"] = false;
                    drDuyet_Ph["Duyet_Log"] = "";
                    drDuyet_Ph["Duyet_PKD"] = false;
                    drDuyet_Ph["Duyet_Log_PKD"] = "";
                    drDuyet_Ph["Duyet_TP"] = false;
                    drDuyet_Ph["Print_Count"] = 0;
                    drDuyet_Ph["Create_Log"] = strCreate_Log;
                    drDuyet_Ph["LastModify_Log"] = "";
                    drDuyet_Ph["USER_PRINT"] = "";
                    //drDuyet_Ph["USER_VT"] = "";
                    //Common.CopyDataColumn(dtDuyet_Ph, dtDuyet_Ph_SO, "");
                    //Common.CopyDataColumn(dtDuyet_Ct, dtDuyet_Ct_SO, "");

                    foreach (DataRow drCt in dtDuyet_Ct.Rows)
                    {
                        if (drCt.RowState == DataRowState.Deleted)
                            continue;

                        drCt["Stt_Org"] = drCt["Stt"];
                        drCt["Stt0_Org"] = drCt["Stt0"];
                        drCt["Stt"] = strStt_LXH;
                        drCt["So_Ct"] = strSo_Ct_LXH;
                        drCt["Ma_Ct"] = "LXH";
                        drCt["Ma_NVu"] = "LXH01";


                    }

                    dtDuyet_Ph.AcceptChanges();
                    dtDuyet_Ct.AcceptChanges();
                }
            }
                SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
                SqlCommand sqlCom = sqlCon.CreateCommand();


                //#region Update chứng từ
                sqlCom.CommandText = "sp_Update_Ct";
                sqlCom.CommandType = CommandType.StoredProcedure;
                bool bBocHang = (bool)SQLExec.ExecuteReturnValue("Select Is_Vt_Nhan FROM R80PH WHERE Stt = '" + strStt + "'");
                if (strMa_Ct == "SO" && bDuyet_Tp && bDuyet_KTTC)
                {
                    if (!bBocHang)
                    {
                        sqlCom.Parameters.Clear();
                        if (!DataTool.SQLCheckExist("R80PH", "Stt", strStt_LXH))
                            sqlCom.Parameters.AddWithValue("@strNew_Edit", "N");
                        else
                            sqlCom.Parameters.AddWithValue("@strNew_Edit", "E");

                        sqlCom.Parameters.AddWithValue("@Stt", strStt_LXH);
                        sqlCom.Parameters.AddWithValue("@Ma_Ct", "LXH");
                        sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
                    }
                    else
                    {
                        return true;

                    }

                }
                else
                {
                    sqlCom.Parameters.Clear();
                    sqlCom.Parameters.AddWithValue("@strNew_Edit", "E");
                    sqlCom.Parameters.AddWithValue("@Stt", strStt);
                    sqlCom.Parameters.AddWithValue("@Ma_Ct", strMa_Ct);
                    sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
                }
                //Tạo Table cho TVP_PH
                SqlParameter paraPH = new SqlParameter();
                paraPH.SqlDbType = SqlDbType.Structured;
                paraPH.ParameterName = "@PH";

                SqlParameter paraCt = new SqlParameter();
                paraCt.SqlDbType = SqlDbType.Structured;
                paraCt.ParameterName = "@Ct";

                if (drDmCt_Current["Table_Ct"].ToString() == "R04CTPO")
                {
                    sqlCom.CommandText = "sp_Update_CtPO";

                    //TVP_PH
                    paraPH.TypeName = "TVP_PHPO";
                    paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHPO", dtDuyet_Ph);
                    sqlCom.Parameters.Add(paraPH);

                    //Tạo Table cho TVP_CtSO
                    paraCt.TypeName = "TVP_CtPO";
                    paraCt.Value = Voucher.GetTVPValue("R04CtPO", "TVP_CtPO", dtDuyet_Ct);
                    sqlCom.Parameters.Add(paraCt);
                }
                else if (drDmCt_Current["Table_Ct"].ToString() == "R04CTPONL")
                {
                    sqlCom.CommandText = "Sp_Update_CtPONL";

                    //TVP_PH
                    paraPH.TypeName = "TVP_PHPONL";
                    paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHPONL", dtDuyet_Ph);
                    sqlCom.Parameters.Add(paraPH);

                    //Tạo Table cho TVP_CtSO
                    paraCt.TypeName = "TVP_CtPONL";
                    paraCt.Value = Voucher.GetTVPValue("R04CtPONL", "TVP_CtPONL", dtDuyet_Ct);
                    sqlCom.Parameters.Add(paraCt);
                }
                else if (drDmCt_Current["Table_Ct"].ToString() == "R04CTSO")
                {
                    sqlCom.CommandText = "sp_Update_CtSO";

                    //TVP_PH
                    paraPH.TypeName = "TVP_PHSO";
                    paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHSO", dtDuyet_Ph);
                    sqlCom.Parameters.Add(paraPH);

                    //Tạo Table cho TVP_CtSO
                    paraCt.TypeName = "TVP_CtSO";
                    paraCt.Value = Voucher.GetTVPValue("R04CtSO", "TVP_CtSO", dtDuyet_Ct);
                    sqlCom.Parameters.Add(paraCt);
                }

                try
                {
                    sqlCom.ExecuteNonQuery();
                    //sqlCom1.ExecuteNonQuery();
                    SQLExec.Execute("UPDATE R80PH SET Gd_Duyet = '" + txtGD_Duyet.Text + "', LyDo_Cham_KHVT = N'" + txtLyDo_Cham_KHVT.Text + "'  WHERE Stt = '" + strStt + "' ");
                }
                catch (Exception ex)
                {
                    sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                    sqlCom.CommandType = CommandType.Text;
                    sqlCom.Parameters.Clear();
                    sqlCom.ExecuteNonQuery();

                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    return false;
                }

                return true;
            //}
            //return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
            if (Common.Inlist(drDmCt_Current["Table_Ct"].ToString(), "R04CTSO,R04CTPO,R04CTPONL"))
            {
                if (this.Save())
                {
                    this.Is_Accept = true;
                    this.Close();
                }
            }
            else
            {
                this.Is_Accept = true;
                this.Close();
            }
		}
        private bool dgvLookupMa_Dt_CbNv_Mh(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvDuyet.CancelEdit();
                dgvCell.Value = drLookup["Ma_Dt"].ToString();
                dgvCell.Tag = drLookup["Ten_Dt"].ToString();

            }
            return true;
        }
		private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
		{

			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				if (strValue == "/" || strValue == @"\")
				{
					drCurrent["Ten_Vt"] = drLookup["Ten_Vt_Chuan"] == null || drLookup["Ten_Vt_Chuan"] == "" ? drLookup["Ten_Vt"] : drLookup["Ten_Vt_Chuan"];
					drCurrent["Dvt"] = drLookup["Dvt"];

					string strMo_Ta_Kt = string.Empty;
					if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] == "")
						strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ".";
					else if (drLookup["Thong_So_Kt"] == "" && drLookup["Ma_Tb_Nha_Sx"] != "")
						strMo_Ta_Kt = "(" + drLookup["Ma_Tb_Nha_Sx"] + ")";
					else if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] != "")
						strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + "(" + drLookup["Ma_Tb_Nha_Sx"] + ")";
					else
						strMo_Ta_Kt = "";

					drCurrent["Mo_Ta_Kt"] = strMo_Ta_Kt;
					
				}
			}
			return true;
		}
		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCtYeuCau.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
            if (bdsCtYeuCau.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCtYeuCau.Current).Row, ref drCurrent);
			else
                drCurrent = dtCtYeuCau.NewRow();
			
			drCurrent["Stt"] = strStt;

			frmCt_YeuCau frmEdit = new frmCt_YeuCau();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
                    if (bdsCtYeuCau.Position >= 0)
                        dtCtYeuCau.ImportRow(drCurrent);
					else
                        dtCtYeuCau.Rows.Add(drCurrent);

                    bdsCtYeuCau.Position = bdsHistory.Find("STT", drCurrent["STT"]);
				}
				else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtYeuCau.Current).Row);

				dtHistory.AcceptChanges();
			}
		}
		public override void Delete()
		{
            if (bdsCtYeuCau.Position < 0)
				return;

            DataRow drCurrent = ((DataRowView)bdsCtYeuCau.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R04CTPO_PHANHOI", drCurrent))
			{
                bdsHistory.RemoveAt(bdsCtYeuCau.Position);
				dtHistory.AcceptChanges();
			}
		}
		void btEdit_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.Edit);
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.New);
		}
		void btDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}
        void btCheckVTPTTD_Click(object sender, EventArgs e)
        {
            DataTable dtCheckVTPTTD = new DataTable();
            Voucher.CheckVTPTTD(dtDuyet_Ct, ref dtCheckVTPTTD);
            
            frmCheck_Gia_Mua frm = new frmCheck_Gia_Mua();
            frm.Load2(dtCheckVTPTTD);
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

	}

}