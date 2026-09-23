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
	public partial class frmDuyetQLMMTB : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtDuyet_Ct;
		public DataTable dtDuyet_Ph;
		public DataTable dtResource;
		public DataTable dtHistory;
        public DataTable dtCtYeuCau;
        public rsDataGridView dgvDuyet = new rsDataGridView();

		BindingSource bdsDuyet = new BindingSource();
		BindingSource bdsDuyet_Ph = new BindingSource();
		BindingSource bdsResource = new BindingSource();
		BindingSource bdsHistory = new BindingSource();
        BindingSource bdsCtYeuCau = new BindingSource();

        
		DataRow drDuyet;
		string strMa_Ct = string.Empty;
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

        public frmDuyetQLMMTB()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			btOpen_Bg.Click += new EventHandler(btOpen_Bg_Click);
            btPrint.Click += new EventHandler(btPrint_Click);

			txtGD_Duyet.Validating += new CancelEventHandler(txtGD_Duyet_Validating);
            //txtMa_Bp_Th.Validating += new CancelEventHandler(txtMa_Bp_Th_Validating);
			dgvDuyet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
            dgvDuyet.CellValidated += new DataGridViewCellEventHandler(dgvDuyet_CellValidated);
            bdsDuyet.PositionChanged += new EventHandler(bdsDuyet_PositionChanged);
			
		}

        

        void btPrint_Click(object sender, EventArgs e)
        {
            if (bdsDuyet_Ph.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsDuyet.Current).Row;
            bool bInVisibleNextPrint = false;
           
            Voucher.Print_BTTB(drCurrent["Stt"].ToString(), true, true, ref bInVisibleNextPrint);
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
            drDmCt_Current = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
            
            //Trình độ đào tạo
            DataTable dtTrinh_Do_DT = SQLExec.ExecuteReturnDt("SELECT '' AS Ma_Bp,'' AS Ten_Bp "+
                                                                " UNION ALL "+
                                                                " SELECT Ma_Bp, Ten_Bp FROM R81DMBP WHERE Ma_Bp NOT IN ('THEPNB','BQLDA','PTGD','PXO','TDIEN')");
            cboMa_Bp_Th.DataSource = dtTrinh_Do_DT;
            cboMa_Bp_Th.DisplayMember = "Ma_Bp";
            cboMa_Bp_Th.ValueMember = "Ten_Bp";

            Build();
			FillData();
			BindingLanguage();
            

           

            if (!Common.Inlist(strMa_Ct, "BBHH") || !bDuyet_Gd)
            {
                chkIs_Kh.Visible = false;
                chkLock.Visible = false;
               
            }
            else
            {
                chkLock.Visible = true;
                chkIs_Kh.Visible = true;
                lbtBoPhan.Visible = true;
                cboMa_Bp_Th.Visible = true;


            }
            DataGridView_Language();
			this.LoadDicName();
			this.ShowDialog();
		}
        private void BindingTong_Tien()
        {
            

        }
        void DataGridView_Language()
        {
            if (dgvDuyet.Columns.Contains("Ten_Vt_HH") && strMa_Ct == "BBHH")
                dgvDuyet.Columns["Ten_Vt_HH"].HeaderText = "Mức độ hư hỏng";

            if (strMa_Ct == "GRVC")
            {
                dgvDuyet.Columns["So_Luong0"].HeaderText = "Số lượng nhập lại";
                dgvDuyet.Columns["Is_KH"].HeaderText = "Có nhập lại";
            }

            if (dgvDuyet.Columns.Contains("Noi_Dung") && strMa_Ct == "GDKC")
                dgvDuyet.Columns["Noi_Dung"].HeaderText = "Tên vật tư - phương tiện";

            if (dgvDuyet.Columns.Contains("Ghi_Chu") && strMa_Ct == "GDKC")
                dgvDuyet.Columns["Ghi_Chu"].HeaderText = "Ghi chú - Tên lái xe";

            if (dgvDuyet.Columns.Contains("Ten_Vt") && strMa_Ct == "GDKC")
                dgvDuyet.Columns["Ten_Vt"].HeaderText = "Mã số";

            if (dgvDuyet.Columns.Contains("HBUI") && strMa_Ct == "GCTC")
                dgvDuyet.Columns["HBui"].HeaderText = "Rắn";

            if (dgvDuyet.Columns.Contains("Lo") && strMa_Ct == "GCTC")
                dgvDuyet.Columns["Lo"].HeaderText = "Lỏng";

            if (dgvDuyet.Columns.Contains("Duc") && strMa_Ct == "GCTC")
                dgvDuyet.Columns["Duc"].HeaderText = "Khí";

            if (dgvDuyet.Columns.Contains("Noi_Dung") && strMa_Ct == "GCTC")
                dgvDuyet.Columns["Noi_Dung"].HeaderText = "Số xe";

            if (strMa_Ct == "GNTC")
            {
                if (dgvDuyet.Columns.Contains("Noi_Dung"))
                    dgvDuyet.Columns["Noi_Dung"].HeaderText = "Họ và tên";
                if (dgvDuyet.Columns.Contains("Ten_Vt"))
                    dgvDuyet.Columns["Ten_Vt"].HeaderText = "Năm sinh";
                if (dgvDuyet.Columns.Contains("Phuong_An"))
                    dgvDuyet.Columns["Phuong_An"].HeaderText = "Số CMND";
            }
        }
		void LoadDicName()
		{
            //if (txtMa_Bp_Th.Text.Trim() != string.Empty)
            //    lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp_Th.Text.Trim());
            //else
            //    lbtTen_Bp.Text = string.Empty;
			//txtMa_Nvu
			if (txtGD_Duyet.Text.Trim() != string.Empty)
				lbtTen_Gd_Duyet.Text = DataTool.SQLGetNameByCode("R00Member", "Member_ID", "Member_Name", txtGD_Duyet.Text.Trim());
			else
				lbtTen_Gd_Duyet.Text = string.Empty;
		}

        void Build()
        {
          
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

            if (strMa_Ct == "POCG")
                dgvDuyet.strZone = "POCG_EDITCT3";
            else if (strMa_Ct == "POXL")
                dgvDuyet.strZone = "POXL_EDITCT3";
            else
                dgvDuyet.strZone = drDmCt["Zone_EditCt4"].ToString();

            dgvResource.strZone = "RESOURCE_SO";
            //gbGioVaoRa.Visible = false;
            if (!Common.Inlist(strMa_Ct, "BBHH"))
            {
                txtNguyen_Nhan.Visible = false;
                txtTinh_Trang_Tb.Visible = false;
                txtNoi_Dung.Visible = false;
                txtPhuong_An.Visible = false;

                lbtPhuong_An1.Visible = false;
                lbtPhuong_An2.Visible = false;
                lbtNguyen_Nhan.Visible = false;
                lbtTinh_Trang_Tb.Visible = false;
                lbtNoi_Dung.Visible = false;
            }
            if (strMa_Ct == "GRVC")
            {
                lbtTinh_Trang_Th.Visible = false;
                txtTinh_Trang_Th.Visible = false;
                tbAttach.Visible = false;
                btOpen_Bg.Visible = false;
            }
           
            dgvDuyet.BuildGridView();
            dgvResource.BuildGridView();

            dgvDuyet.Dock = DockStyle.Fill;
            dgvDuyet.BuildGridView(false);
            dgvDuyet.ReadOnly = false;
            this.tabPage1.Controls.Add(dgvDuyet);

            foreach (DataGridViewColumn dgvc in dgvDuyet.Columns)
                dgvc.ReadOnly = true;

            string strCreate_User = (string)drDuyet["Create_Log"];

            string strMa_Nh_User = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + Element.sysUser_Id + "')") + "";
            string strMa_Nh_Create = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + strCreate_User.Substring(14) + "'") + "";

            //chkDuyet.Enabled = false;
            //this.btgAccept.btAccept.Enabled = false;

            DataRow drPh = DataTool.SQLGetDataRowByID(drDmCt["Table_Ph"].ToString(), "Stt", strStt);
            bDuyet_Tp_Ph = (bool)drPh["Duyet_Tp"];
            bDuyet_PxCd_Ph = (bool)drPh["Duyet_PxCd"];
            bDuyet_KtCdAt_Ph = (bool)drPh["Duyet_KtCdAt"];

            bDuyet_Gd_Ph = (bool)drPh["Duyet_GiamDoc"];
            bDuyet_Huy = (bool)drPh["Duyet_Huy"];

            bDuyet_Tp = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
            bDuyet_PxCd = Common.CheckPermission("IS_TP_PXCD", enuPermission_Type.Allow_Access);
            bDuyet_KtCdAt = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
            bDuyet_Gd = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);

            if (bDuyet_Tp)
            {
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;

                if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                    dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = false;

                
            }
            if (bDuyet_PxCd)
            {
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;

                if (dgvDuyet.Columns.Contains("Ghi_Chu_PXCD"))
                    dgvDuyet.Columns["Ghi_Chu_PXCD"].ReadOnly = false;

            
            }
            if (bDuyet_KtCdAt)
            {
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;

                if (dgvDuyet.Columns.Contains("Ghi_Chu_KTCD"))
                    dgvDuyet.Columns["Ghi_Chu_KTCD"].ReadOnly = false;


            }
            if (bDuyet_Gd)
            {
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;

                if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
                    dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;

                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;
            }

            if (dgvDuyet.Columns.Contains("Noi_Dung"))
            {
                dgvDuyet.Columns["Noi_Dung"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            if (dgvDuyet.Columns.Contains("Ghi_Chu"))
            {
                dgvDuyet.Columns["Ghi_Chu"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvDuyet.Columns.Contains("Nguyen_Nhan"))
            {
                dgvDuyet.Columns["Nguyen_Nhan"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvDuyet.Columns.Contains("Phuong_An"))
            {
                dgvDuyet.Columns["Phuong_An"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvDuyet.Columns.Contains("Ten_Vt_HH"))
            {
                dgvDuyet.Columns["Ten_Vt_HH"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvDuyet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

           

            lblTen_Dt.Visible = false;
            txtTen_Dt.Visible = false;
            lblDien_Giai.Visible = false;
            txtDien_Giai.Visible = false;
            lblPhuong_An1.Visible = false;
            txtPhuong_An1.Visible = false;
            if (Common.Inlist(strMa_Ct, "GDKC,GVTC,GCTC,GNTC"))
            {
                lbtTinh_Trang_Th.Visible = false;
                txtTinh_Trang_Th.Visible = false;

                lblTen_Dt.Visible = true;
                txtTen_Dt.Visible = true;
                lblDien_Giai.Visible = true;
                txtDien_Giai.Visible = true;
                //gbGioVaoRa.Visible = true;
                if (strMa_Ct == "GNTC")
                {
                    lbtTen_Gd_Duyet.Visible = false;
                    txtGD_Duyet.Visible = false;
                }
                if (strMa_Ct == "GVTC")
                {
                    lblPhuong_An1.Visible = true;
                    txtPhuong_An1.Visible = true;
                }

            
                
            }
            DataGridView_Language();
        }
       
		void FillData()
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", strStt);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_BTTB", htPara, CommandType.StoredProcedure);

			dtDuyet_Ph = dsVoucher.Tables[0];
			dtDuyet_Ct = dsVoucher.Tables[1];
            
            if (dsVoucher.Tables.Count >= 3)
                dtResource = dsVoucher.Tables[4];
               
            
         
            
            bdsDuyet_Ph.DataSource = dtDuyet_Ph;
			bdsDuyet.DataSource = dtDuyet_Ct;

          

			bdsResource.DataSource = dtResource;
			bdsHistory.DataSource = dtHistory;

			dgvDuyet.DataSource = bdsDuyet;
			dgvResource.DataSource = bdsResource;
		

            
            bdsCtYeuCau.DataSource = dtCtYeuCau;
          
            
			string strGd_Duyet = "SELECT Gd_Duyet FROM R06PH_BTTB WHERE Stt = '" + strStt + "'";
			txtGD_Duyet.Text = SQLExec.ExecuteReturnValue(strGd_Duyet).ToString();
            if (strMa_Ct == "BBHH")
            {
                DataTable dtBBHH = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R06CT_BTTB WHERE Stt = '" + strStt + "'");
                DataRow drBBHH = dtBBHH.Rows[0];

                txtNguyen_Nhan.Text = drBBHH["Nguyen_Nhan"].ToString();
                txtNoi_Dung.Text = drBBHH["Noi_Dung"].ToString();
                txtTinh_Trang_Tb.Text = drBBHH["Tinh_Trang_Tb"].ToString();
                txtPhuong_An.Text = drBBHH["Phuong_An"].ToString();
                txtTinh_Trang_Th.Text = drBBHH["Tinh_Trang_Th"].ToString();
                cboMa_Bp_Th.Text = drBBHH["Ma_Bp_Th"].ToString();
                chkIs_Kh.Checked = Convert.ToBoolean(drBBHH["Is_Kh"]);
                chkLock.Checked = Convert.ToBoolean(drBBHH["Lock"]);
                
            }
            if (Common.Inlist(strMa_Ct, "GDKC,GVTC,GCTC,GNTC"))
            {
                DataTable dtBBHH = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R06CT_BTTB WHERE Stt = '" + strStt + "'");
                DataRow drBBHH = dtBBHH.Rows[0];
                txtDien_Giai.Text = drBBHH["Dien_Giai"].ToString();
                txtPhuong_An1.Text = drBBHH["Phuong_An"].ToString();
                txtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT","Ma_Dt","Ten_Dt",drBBHH["Ma_Dt"].ToString());


                //DateTime dtGio_Vao = Convert.ToDateTime(drBBHH["Ngay_BD"]);
                //DateTime dtGio_Ra = Convert.ToDateTime(drBBHH["Ngay_KT"]);

                //dteGio_Vao.Text = dtGio_Vao.ToString("HH:mm:ss");
                //dteGio_Ra.Text = dtGio_Ra.ToString("HH:mm:ss");
                //dteNgay_BD.Text = Library.DateToStr(dtGio_Vao);
                //dteNgay_KT.Text = Library.DateToStr(dtGio_Ra);
            }

		}
        
		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		//#region Event
        void txtMa_Bp_Th_Validating(object sender, CancelEventArgs e)
        {
            //string strValue = txtMa_Bp_Th.Text.Trim();
            //bool bRequire = true;
            //string strKey = string.Empty;


            //DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, strKey);

            //if (bRequire && drLookup == null)
            //    e.Cancel = true;

            //if (drLookup == null)
            //{
            //    txtMa_Bp_Th.Text = string.Empty;
            //    lbtTen_Bp.Text = string.Empty;
            //}
            //else
            //{
            //    txtMa_Bp_Th.Text = drLookup["Ma_Bp"].ToString();
            //    lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();

            //}
        }
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
                                   "thepmiennam\bangvtk", "bang160619", "192.168.1.18");

                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(new Uri("192.168.1.18"), "Basic", myCred);
                    WebRequest wr = WebRequest.Create("192.168.1.18");
                    wr.Credentials = myCache;
                }
                else if (Common.InlistLike(ex.Message, "The user name or password is incorrect."))
                {
                    Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\192.168.1.18 để mở file");
                    System.Diagnostics.Process.Start("explorer.exe", @"\\192.168.1.18");

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

	

		void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
            //dgvVoucher dgvEditCt = (dgvVoucher)sender;

            //drCurrent = ((DataRowView)bdsDuyet.Current).Row;
            //DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            //string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            //bool bLookup = true;

            ////Xu ly Lookup
            //if (this.ActiveControl == null)
            //    return;

		

            //drCurrent.AcceptChanges();
		}

        void bdsDuyet_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDuyet.Position < 0)
                return;
        
        }
        void dgvDuyet_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //dgvVoucher dgvEditCt = (dgvVoucher)sender;

            //drCurrent = ((DataRowView)bdsDuyet.Current).Row;
            //DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            //string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
           
        }
        
        bool Save()
		{
            DataRow drDuyet_Ph = ((DataRowView)bdsDuyet_Ph.Current).Row;
            if (bDuyet_KtCdAt && txtGD_Duyet.Text == "" && !Element.sysIs_Admin && Common.InlistLike(strMa_Ct, "BBHH,BTKH,BTBN,BTNT"))
			{
				Common.MsgOk("Cần bổ sung tên giám đốc duyệt yêu cầu");
				return false;
			}
            if (bDuyet_KtCdAt && Common.InlistLike(strMa_Ct, "BBHH,BTKH,BTBN,BTNT") &&  SQLExec.ExecuteReturnDt("SELECT * FROM R00MEMBER WHERE Member_ID = '" + txtGD_Duyet.Text + "' AND Member_ID IN (select Member_ID from R00MEMBERGROUP where Member_Group_ID = 'NQL')").Rows.Count == 0) 
                { Common.MsgOk("Tên giám đốc duyệt không phù hợp, anh (chị) cần sửa lại thông tin giám đốc duyệt."); return false; }
            
            if (strMa_Ct == "BBHH")
            {
                //if (txtMa_Bp_Th.Text == "" && bDuyet_Gd)
                //{
                //    Common.MsgOk("Giám đốc chưa phân công đơn vị phụ trách.");
                //    return false;
                //}
                //else
                //{
                foreach (DataRow dr in dtDuyet_Ct.Rows)
                {
                    dr["Is_Kh"] = chkIs_Kh.Checked;
                    dr["Lock"] = chkLock.Checked;
                    dr["Ma_Bp_Th"] = cboMa_Bp_Th.Text;
                }
                //}
            }
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();


            //#region Update chứng từ
            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

         
            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@strNew_Edit", "E");
            sqlCom.Parameters.AddWithValue("@Stt", strStt);
            sqlCom.Parameters.AddWithValue("@Ma_Ct", strMa_Ct);
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
            
            //Tạo Table cho TVP_PH
            SqlParameter paraPH = new SqlParameter();
            paraPH.SqlDbType = SqlDbType.Structured;
            paraPH.ParameterName = "@PH";

            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@Ct";

            if (drDmCt_Current["Table_Ct"].ToString() == "R06CT_BTTB")
            {
                sqlCom.CommandText = "Sp_Update_BTTB";

                //TVP_PH
                paraPH.TypeName = "TVP_PHBTTB";
                paraPH.Value = Voucher.GetTVPValue("R06PH_BTTB", "TVP_PHBTTB", dtDuyet_Ph);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CTBTTB";
                paraCt.Value = Voucher.GetTVPValue("R06CT_BTTB", "TVP_CTBTTB", dtDuyet_Ct);
                sqlCom.Parameters.Add(paraCt);
            }
           
            try
            {
                sqlCom.ExecuteNonQuery();
                //sqlCom1.ExecuteNonQuery();
                //SQLExec.Execute("UPDATE R80PH SET Gd_Duyet = '" + txtGD_Duyet.Text + "' WHERE Stt = '" + strStt + "' ");
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
		}

		void btAccept_Click(object sender, EventArgs e)
		{           
            if (this.Save())
            {
                this.Is_Accept = true;
                this.Close();
            }
           
		}
        private bool dgvLookupMa_Dt_CbNv_Mh(ref DataGridViewCell dgvCell)
        {
            //string strValue = string.Empty;

            //if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
            //    strValue = this.ActiveControl.Text;
            //else
            //    strValue = dgvCell.FormattedValue.ToString().Trim();

            //bool bRequire = false;
            //DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

            //if (bRequire && drLookup == null)
            //    return false;

            //if (drLookup == null)
            //{
            //    dgvCell.Value = string.Empty;
            //    dgvCell.Tag = string.Empty;
            //}
            //else
            //{
            //    dgvDuyet.CancelEdit();
            //    dgvCell.Value = drLookup["Ma_Dt"].ToString();
            //    dgvCell.Tag = drLookup["Ten_Dt"].ToString();

            //}
            return true;
        }
		private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
		{

            //string strValue = string.Empty;

            //if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
            //    strValue = this.ActiveControl.Text;
            //else
            //    strValue = dgvCell.FormattedValue.ToString().Trim();

            //bool bRequire = false;

            //DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

            //if (bRequire && drLookup == null)
            //    return false;

            //if (drLookup == null)
            //{
            //    dgvCell.Value = string.Empty;
            //    dgvCell.Tag = string.Empty;
            //}
            //else
            //{
            //    dgvCell.Value = drLookup["Ma_Vt"].ToString();
            //    dgvCell.Tag = drLookup["Ten_Vt"].ToString();

            //    if (strValue == "/" || strValue == @"\")
            //    {
            //        drCurrent["Ten_Vt"] = drLookup["Ten_Vt_Chuan"] == null || drLookup["Ten_Vt_Chuan"] == "" ? drLookup["Ten_Vt"] : drLookup["Ten_Vt_Chuan"];
            //        drCurrent["Dvt"] = drLookup["Dvt"];

            //        string strMo_Ta_Kt = string.Empty;
            //        if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] == "")
            //            strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ".";
            //        else if (drLookup["Thong_So_Kt"] == "" && drLookup["Ma_Tb_Nha_Sx"] != "")
            //            strMo_Ta_Kt = "(" + drLookup["Ma_Tb_Nha_Sx"] + ")";
            //        else if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] != "")
            //            strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + "(" + drLookup["Ma_Tb_Nha_Sx"] + ")";
            //        else
            //            strMo_Ta_Kt = "";

            //        drCurrent["Mo_Ta_Kt"] = strMo_Ta_Kt;
					
            //    }
            //}
			return true;
		}
		public override void Edit(enuEdit enuNew_Edit)
		{
            //if (bdsCtYeuCau.Position < 0 && enuNew_Edit == enuEdit.Edit)
            //    return;

            ////Copy hang hien tai            
            //if (bdsCtYeuCau.Position >= 0)
            //    Common.CopyDataRow(((DataRowView)bdsCtYeuCau.Current).Row, ref drCurrent);
            //else
            //    drCurrent = dtCtYeuCau.NewRow();
			
            //drCurrent["Stt"] = strStt;

            //frmCt_YeuCau frmEdit = new frmCt_YeuCau();
            //frmEdit.Load(enuNew_Edit, drCurrent);

            //// người dùng chọn chấp nhận
            //if (frmEdit.isAccept)
            //{
            //    if (enuNew_Edit == enuEdit.New)
            //    {
            //        if (bdsCtYeuCau.Position >= 0)
            //            dtCtYeuCau.ImportRow(drCurrent);
            //        else
            //            dtCtYeuCau.Rows.Add(drCurrent);

            //        bdsCtYeuCau.Position = bdsHistory.Find("STT", drCurrent["STT"]);
            //    }
            //    else
            //        Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtYeuCau.Current).Row);

            //    dtHistory.AcceptChanges();
            //}
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