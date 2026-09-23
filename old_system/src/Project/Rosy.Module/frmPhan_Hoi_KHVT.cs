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


namespace RosyModule
{
	public partial class frmPhan_Hoi_KHVT : RosySystem.Customize.frmView
	{
		#region Declare
        //private rsDataGridView dgvPhanHoiKHVT= new rsDataGridView();

		public DataTable dtEditCt;
		public DataTable dtEditPh;
		public DataTable dtPhanHoiKTCDAT;

		BindingSource bdsPhanHoiKTCDAT = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsDNXNL = new BindingSource();

        DataRow drDuyet;
        DataRow drCurrent;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
        string strLoai = string.Empty;
        string strMa_Vt = string.Empty;
        public bool Is_Accept = false;
		#endregion

		#region Contructor

		public frmPhan_Hoi_KHVT()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            dgvPhanHoiKHVT.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvPhanHoiKHVT_CellMouseClick);

            dgvPhanHoiKHVT.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
            dgvPhanHoiKTCDAT.CellValidating += new DataGridViewCellValidatingEventHandler(dgvPhanHoiKTCDAT_CellValidating);
            dgvPhanHoiPKD.CellValidating += new DataGridViewCellValidatingEventHandler(dgvPhanHoiPKD_CellValidating);
            dgvDNXNL.CellValidating += DgvDNXNL_CellValidating1;

          
            dgvDNXNL.CellValidating += DgvDNXNL_CellValidating;
            dgvDNXNL.CellValidated += DgvDNXNL_CellValidated;
		}

       



        #endregion

        #region Method

        public void Load(DataRow drDuyet, string strLoai)
		{
			this.drDuyet = drDuyet;

			this.strMa_Ct = (string)drDuyet["Ma_Ct"];
			this.strStt = (string)drDuyet["Stt"];
            this.strLoai = strLoai;

			Build();
			FillData();
			BindingLanguage();

			this.LoadDicName();
			this.ShowDialog();
		}
        public void Load(DataRow drDuyet, string strMa_Vt, string strLoai)
        {
            this.drDuyet = drDuyet;

            this.strMa_Ct = (string)drDuyet["Ma_Ct"];
            this.strStt = (string)drDuyet["Stt"];
            this.strLoai = strLoai;
            this.strMa_Vt = strMa_Vt;

            Build();
            FillData();
            BindingLanguage();

            this.LoadDicName();
            this.ShowDialog();
        }
        void LoadDicName()
		{
			
		}

		void Build()
		{
			dgvPhanHoiKHVT.strZone = "PHAN_HOI_KHVT";
            dgvPhanHoiKTCDAT.strZone = "PHAN_HOI_KTCDAT";
            dgvPhanHoiPKD.strZone = "PHAN_HOI_PKD";
            dgvDNXNL.strZone = "PHAN_HOI_DNXNL";

            dgvPhanHoiKHVT.BuildGridView();
			dgvPhanHoiKTCDAT.BuildGridView();
            dgvPhanHoiPKD.BuildGridView();
            dgvDNXNL.BuildGridView();

            pnlTien.Visible = false;
            if (strLoai == "PKHVT")
            {
                TabPhanHoi.TabPages.Remove(pagePKD);
                TabPhanHoi.TabPages.Remove(pagePhanHoiKTCDAT);
                TabPhanHoi.TabPages.Remove(pageDNXNL);
            }
            else if (strLoai == "PKD")
            {
                lblNgay_Ct.Visible = false;
                dteNgay_DkGH.Visible = false;
                TabPhanHoi.TabPages.Remove(pagePhanHoiKHVT);
                TabPhanHoi.TabPages.Remove(pagePhanHoiKTCDAT);
                TabPhanHoi.TabPages.Remove(pageDNXNL);
            }
            else if (strLoai == "DNXNL")
            {
                lblNgay_Ct.Visible = false;
                dteNgay_DkGH.Visible = false;
                TabPhanHoi.TabPages.Remove(pagePhanHoiKHVT);
                TabPhanHoi.TabPages.Remove(pagePhanHoiKTCDAT);
                TabPhanHoi.TabPages.Remove(pagePKD);
            }
            else
            {
                TabPhanHoi.TabPages.Remove(pagePhanHoiKHVT);
                TabPhanHoi.TabPages.Remove(pagePKD);
                TabPhanHoi.TabPages.Remove(pageDNXNL);
            }
			foreach (DataGridViewColumn dgvc in dgvPhanHoiKHVT.Columns)
				dgvc.ReadOnly = true;

            if (dgvPhanHoiKHVT.Columns.Contains("Phan_Hoi_KHVT"))
			    dgvPhanHoiKHVT.Columns["Phan_Hoi_KHVT"].ReadOnly = false;
            if (dgvPhanHoiKHVT.Columns.Contains("Ma_Dt_CbNv_Mh"))
                dgvPhanHoiKHVT.Columns["Ma_Dt_CbNv_Mh"].ReadOnly = false;
            if (dgvPhanHoiKHVT.Columns.Contains("Ma_Hd"))
                dgvPhanHoiKHVT.Columns["Ma_Hd"].ReadOnly = false;
            if (dgvPhanHoiKHVT.Columns.Contains("Is_Vt_Tt"))
                dgvPhanHoiKHVT.Columns["Is_Vt_Tt"].ReadOnly = false;
            if (dgvPhanHoiKHVT.Columns.Contains("IsStop"))
                dgvPhanHoiKHVT.Columns["IsStop"].ReadOnly = false;

            if (dgvPhanHoiKHVT.Columns.Contains("Ngay_Gh_Dc1"))
                dgvPhanHoiKHVT.Columns["Ngay_Gh_Dc1"].ReadOnly = false;
            if (dgvPhanHoiKHVT.Columns.Contains("Ngay_Gh_Dc2"))
                dgvPhanHoiKHVT.Columns["Ngay_Gh_Dc2"].ReadOnly = false;
            

            foreach (DataGridViewColumn dgvc in dgvPhanHoiKTCDAT.Columns)
                dgvc.ReadOnly = true;

            dgvPhanHoiKTCDAT.Columns["Phan_Hoi_KTCDAT"].ReadOnly = false;
            dgvPhanHoiKTCDAT.Columns["Ma_Vt_Tt"].ReadOnly = false;
            

            if (dgvPhanHoiKHVT.Columns.Contains("MA_DT_CBNV_MH"))
            { 
                ((dgvTextBoxColumn)dgvPhanHoiKHVT.Columns["Ma_Dt_CbNv_Mh"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvPhanHoiKHVT.Columns["Ma_Dt_CbNv_Mh"]).strLookupKeyFilter = "Ma_Dt LIKE 'M%'";
            }
            if (dgvPhanHoiKHVT.Columns.Contains("MA_HD"))
                ((dgvTextBoxColumn)dgvPhanHoiKHVT.Columns["MA_HD"]).bUseAutoDropDown = true;
               
            

            if (dgvPhanHoiKTCDAT.Columns.Contains("MA_VT_TT"))
                ((dgvTextBoxColumn)dgvPhanHoiKTCDAT.Columns["MA_VT_TT"]).bUseAutoDropDown = true;


            foreach (DataGridViewColumn dgvc in dgvDNXNL.Columns)
                dgvc.ReadOnly = true;

            if (dgvDNXNL.Columns.Contains("So_Ct0"))
                dgvDNXNL.Columns["So_Ct0"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("Ngay_Ct0"))
                dgvDNXNL.Columns["Ngay_Ct0"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("So_Seri0"))
                dgvDNXNL.Columns["So_Seri0"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("So_Luong9"))
                dgvDNXNL.Columns["So_Luong9"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("Gia_Nt9"))
                dgvDNXNL.Columns["Gia_Nt9"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("Tien_Nt9"))
                dgvDNXNL.Columns["Tien_Nt9"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("Ma_Thue"))
                dgvDNXNL.Columns["Ma_Thue"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("Tien3"))
                dgvDNXNL.Columns["Tien3"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("Ma_So_Thue"))
                dgvDNXNL.Columns["Ma_So_Thue"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("Ten_DtGtGt"))
                dgvDNXNL.Columns["Ten_DtGtGt"].ReadOnly = false;
            if (dgvDNXNL.Columns.Contains("Ma_Dt_CbNv_Mh") && strMa_Ct == "DNXNL")
            {
                pnlTien.Visible = true;
                dgvDNXNL.Columns["Ma_Dt_CbNv_Mh"].ReadOnly = false;
                dgvDNXNL.Columns["Gia_Nt9"].DefaultCellStyle.Format = "N4";
                
            }
           
            string strCreate_User = (string)drDuyet["Create_Log"];

			string strMa_Nh_User = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "'") + "";
			string strMa_Nh_Create = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + strCreate_User.Substring(14) + "'") + "";
		}
        private void Data_Language()
        {
            dgvDNXNL.Columns["Ma_Dt_CbNv_Mh"].HeaderText = "Mã NCC Xuất HĐon";
            
        }
		void FillData()
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", strStt);
           
            htPara.Add("USER_LOGIN", Element.sysUser_Id);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", htPara, CommandType.StoredProcedure);

			dtEditPh = dsVoucher.Tables[0];
            dtEditCt = dsVoucher.Tables[1];
            
            if(strMa_Vt != "")
            {
                //DataTable dtEditCt_0 = dsVoucher.Tables[1];
                DataRow drEditCtNew = dtEditCt.NewRow();
                foreach (DataRow drSelect in dtEditCt.Select("Ma_Vt = '"+ strMa_Vt + "'"))
                {
                    
                    Common.CopyDataRow(drSelect, drEditCtNew);
                    Common.SetDefaultDataRow(ref drEditCtNew);
                    dtEditCt.Rows.Clear();
                    dtEditCt.Rows.Add(drEditCtNew);
                    drEditCtNew.AcceptChanges();
                }
            }
                

            bdsEditPh.DataSource = dtEditPh;

			bdsEditCt.DataSource = dtEditCt;

			dgvPhanHoiKHVT.DataSource = bdsEditCt;

			dtPhanHoiKTCDAT = dtEditCt;
			bdsPhanHoiKTCDAT.DataSource = dtPhanHoiKTCDAT;
			dgvPhanHoiKTCDAT.DataSource = bdsPhanHoiKTCDAT;
           
            if (strLoai == "PKD")
            { dgvPhanHoiPKD.DataSource = bdsEditCt; }

            if (strLoai == "DNXNL")
            {
               
                dgvDNXNL.DataSource = bdsEditCt; 
            }

            if (drDmCt["Table_Ct"].ToString() == "R04CTPO")
            {
                if (Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_DkGH) FROM R04CTPO WHERE Stt = '" + strStt + "'")).ToShortDateString() != "01/01/1900")
                    dteNgay_DkGH.Text = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_DkGH) FROM R04CTPO WHERE Stt = '" + strStt + "'").ToString();
                else
                    dteNgay_DkGH.Text = Library.DateToStr(DateTime.Now);


                numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien0");
                numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien3");
                numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien");
            }
		}

		bool FormCheckValid()
		{
            if (strLoai == "PKHVT")
            {
                //foreach(DataRow dr in dtEditCt.Rows)
                //{ 
                //    if ((bool)dr["IsStop"] && dr["Phan_Hoi_KHVT"].ToString() == string.Empty)
                //    {
                //        Common.MsgOk("Anh (chị) cần bổ sung thông tin phản hồi nếu dừng không mua VTPT nữa!!!");
                //    }
                //    return false;
                //}
            }
			return true;
		}

		#endregion

		#region Event
        void dgvPhanHoiKHVT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (strColumnName == "ISSTOP")
            {
                drCurrent["Stop_Log"] = Common.GetCurrent_Log();
            }
        }
        void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            bool bLookup = true;
            if (strColumnName == "MA_DT_CBNV_MH")
                bLookup = dgvLookupMa_Dt_CbNv_Mh(ref dgvCell);
           else if (strColumnName == "MA_HD")
                bLookup = dgvLookupMa_Hd(ref dgvCell);
          


        }
        private void DgvDNXNL_CellValidating1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "SO_CT0"))
            {
                string strSo_Ct0 = dgvCell.FormattedValue.ToString().Trim();
                strSo_Ct0 = Voucher.GetSoCt0(strSo_Ct0);
                dgvDNXNL.CancelEdit();
                dgvCell.Value = strSo_Ct0;
            }
        }
        void dgvPhanHoiKTCDAT_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            bool bLookup = true;
           
            if (strColumnName == "MA_VT_TT")
                bLookup = dgvLookupMa_Vt_Tt(ref dgvCell);
        }
        void dgvPhanHoiPKD_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            bool bLookup = true;

            if (strColumnName == "SO_XE")
                bLookup = dgvLookupSo_Xe(ref dgvCell);
            else if (strColumnName == "MA_XE")
                bLookup = dgvLookupMa_Xe(ref dgvCell);
        }
        private void DgvDNXNL_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            //tÍNH Tiền
            if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
            {
                Cal_Tien(strColumnName, drCurrent);
                drCurrent.AcceptChanges();

                numTTien_Nt0.Value = Common.SumDCValue(dtEditCt, "Tien", "");
                numTTien_Nt3.Value = Common.SumDCValue(dtEditCt, "Tien3", "");
                numTTien_Nt.Value = Common.SumDCValue(dtEditCt, "Tien", "") + Common.SumDCValue(dtEditCt, "Tien3", "");
            }
        }
        private void Cal_Tien(string strColumnName, DataRow drDNXNL)
        {
            if(Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9"))
            { 
                drDNXNL["Gia_Nt"] = drDNXNL["Gia"] = drDNXNL["Gia_Nt9"];
                drDNXNL["Tien_Nt9"] = drDNXNL["Tien_Nt"] = drDNXNL["Tien"] = Math.Round(Convert.ToDouble(drDNXNL["So_Luong9"]) * Convert.ToDouble(drDNXNL["Gia_Nt9"]),0);
                drDNXNL["Tien_Nt3"] = drDNXNL["Tien3"] = Math.Round(Convert.ToDouble(drDNXNL["Tien_Nt9"]) * (Convert.ToDouble(drDNXNL["Thue_GtGt"]) / 100), 0);
            }
            else if (strColumnName == "TIEN_NT9" && Convert.ToDouble(drDNXNL["Gia_Nt9"]) == 0)
            {
                drDNXNL["Gia_Nt"] = drDNXNL["Gia"] = drDNXNL["Gia_Nt9"] = Math.Round(Convert.ToDouble(drDNXNL["Tien_Nt9"]) / Convert.ToDouble(drDNXNL["So_Luong9"]), 4);
                drDNXNL["Tien_Nt"] = drDNXNL["Tien"] = drDNXNL["Tien_Nt9"];

                drDNXNL["Tien_Nt3"] = drDNXNL["Tien3"] = Math.Round(Convert.ToDouble(drDNXNL["Tien_Nt9"]) * (Convert.ToDouble(drDNXNL["Thue_GtGt"]) / 100), 0);
            }
            double dbTien3_Calc = Math.Round(Math.Ceiling((Convert.ToDouble(drDNXNL["Tien_Nt9"]) * (Convert.ToDouble(drDNXNL["Thue_GtGt"]) / 100) * 100)) / 100, MidpointRounding.AwayFromZero);
            double dbTien3 = Convert.ToDouble(drDNXNL["Tien3"]);
            double dbTron_Vat = Convert.ToDouble(Parameters.GetParaValue("Tron_VAT"));
            
            if (Math.Abs(dbTien3_Calc - dbTien3) > dbTron_Vat)
                drDNXNL["Tien3"] = dbTien3_Calc;

            drDNXNL["Tien_Nt3"] = drDNXNL["Tien3"];
            
        }
        private void DgvDNXNL_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
    
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            bool bLookup = true;

            if (strColumnName == "MA_THUE")
                bLookup = dgvLookupMa_Thue(ref dgvCell);
            else if (strColumnName == "MA_DT_CBNV_MH")
                bLookup = dgvLookupMa_Dt(ref dgvCell);
            else if (strColumnName == "MA_SO_THUE")
                bLookup = dgvLookupMa_So_Thue(ref dgvCell);


        }
        
        private bool dgvLookupMa_Thue(ref DataGridViewCell dgvCell)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strMa_Thue_Old = drCurrent["Ma_Thue"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Thue"];

            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
                drCurrent["Thue_GtGt"] = 0;

                if (dgvDNXNL.Columns.Contains("Tien_Nt3"))
                    dgvDNXNL.CurrentRow.Cells["Tien_Nt3"].ReadOnly = false;

                if (dgvDNXNL.Columns.Contains("Tien3"))
                    dgvDNXNL.CurrentRow.Cells["Tien3"].ReadOnly = false;

               
            }
            else
            {
                //dgvDNXNL.CancelEdit();
                dgvCell.Value = drLookup["Ma_Thue"].ToString();
                dgvCell.Tag = drLookup["Ten_Thue"].ToString();
                drCurrent["Thue_GtGt"] = Convert.ToInt32(drLookup["Thue_Suat"]);

                if (dgvDNXNL.Columns.Contains("Tien_Nt3"))
                    dgvDNXNL.CurrentRow.Cells["Tien_Nt3"].ReadOnly = false;

                if (dgvDNXNL.Columns.Contains("Tien3"))
                    dgvDNXNL.CurrentRow.Cells["Tien3"].ReadOnly = false;

               
            }

            //this.Ma_Thue_Valid();

            return true;
        }
        private bool dgvLookupSo_Xe(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            if(strValue =="\\" || strValue == "//")
            { 
                DataRow drLookup = Lookup.ShowLookup("So_Xe_PKD", strValue, bRequire, "", "");

                if (bRequire && drLookup == null)
                    return false;

                if (drLookup == null)
                {
                    dgvCell.Value = string.Empty;
                    dgvCell.Tag = string.Empty;
                }
                else
                {
                    drCurrent = ((DataRowView)bdsPhanHoiKTCDAT.Current).Row;

                    dgvPhanHoiKHVT.CancelEdit();
                    dgvCell.Value = drLookup["So_Xe"].ToString();
                    dgvCell.Tag = drLookup["So_Xe"].ToString();

                    drCurrent["So_Xe"] = drLookup["So_Xe"].ToString();
                }
            }
            return true;
        }
        private bool dgvLookupMa_Xe(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Xe", strValue, bRequire, "Ma_Bp = 'PKD'");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsPhanHoiKTCDAT.Current).Row;

                dgvPhanHoiKHVT.CancelEdit();
                dgvCell.Value = drLookup["Ma_Xe"].ToString();
                dgvCell.Tag = drLookup["Ma_Xe"].ToString();

                drCurrent["Ma_Xe"] = drLookup["Ma_Xe"].ToString();
            }

            return true;
        }
        private bool dgvLookupMa_Vt_Tt(ref DataGridViewCell dgvCell)
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
                drCurrent = ((DataRowView)bdsPhanHoiKTCDAT.Current).Row;

                dgvPhanHoiKHVT.CancelEdit();
                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                drCurrent["Ten_Vt_Tt"] = drLookup["Ten_Vt"].ToString();
            }

            return true;
        }
        private bool dgvLookupMa_Dt(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                //dgvDNXNL.CancelEdit();
                dgvCell.Value = drLookup["Ma_Dt"].ToString();
                dgvCell.Tag = drLookup["Ten_Dt"].ToString();
                drCurrent["Ma_So_Thue"] = drLookup["Ma_So_Thue"].ToString();
                drCurrent["Ten_DtGtGt"] = drLookup["Ten_Dt"].ToString();
            }

            return true;
        }
        private bool dgvLookupMa_So_Thue(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            if (strValue == "/" || strValue == @"\")
            {
                DataRow drLookup = Lookup.ShowLookup("Ma_So_Thue", strValue, bRequire, "", "");

                if (bRequire && drLookup == null)
                    return false;

                if (drLookup == null)
                {
                    dgvCell.Value = string.Empty;
                    dgvCell.Tag = string.Empty;
                }
                else
                {
                    drCurrent = ((DataRowView)bdsEditCt.Current).Row;


                    dgvCell.Value = drLookup["Ma_So_Thue"].ToString();
                    dgvCell.Tag = drLookup["Ten_DtGtGt"].ToString();

                    drCurrent["Ma_So_Thue"] = dgvCell.Value;
                    drCurrent["Ten_DtGtGt"] = dgvCell.Tag;
                }
            }
            else if (DataTool.SQLCheckExist("R81DMDT", "Ma_So_Thue", drCurrent["Ma_So_Thue"].ToString()) || DataTool.SQLCheckExist("vw_Ma_So_Thue", "Ma_So_Thue", drCurrent["Ma_So_Thue"].ToString()))
            {
                DataRow drDmDt = DataTool.SQLGetDataRowByID("vw_Ma_So_Thue", "Ma_So_Thue", drCurrent["Ma_So_Thue"].ToString());
                drCurrent["Ten_DtGtGt"] = drDmDt["Ten_DtGtGt"];
            }
            return true;
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
                dgvPhanHoiKHVT.CancelEdit();
                dgvCell.Value = drLookup["Ma_Dt"].ToString();
                dgvCell.Tag = drLookup["Ten_Dt"].ToString();

            }
            return true;
        }
        private bool dgvLookupMa_Hd(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvPhanHoiKHVT.CancelEdit();
                dgvCell.Value = drLookup["Ma_Hd"].ToString();
                dgvCell.Tag = drLookup["Ten_Hd"].ToString();

            }
            return true;
        }
        #endregion

        #region Update
        bool Update_DieuChinh_Ct()
		{

			DataRow[] Result = dtPhanHoiKTCDAT.Select("CHON = 1");
			DataTable dtEdit_Ct = dtPhanHoiKTCDAT.Clone(); 
			
			string strMa_Ct_Tt = string.Empty;
			DataTable dtEdit_Ph = dtEditPh;
			DataRow drEdit_Ph = dtEdit_Ph.Rows[0];
			string strStt_Tt = "A0104" + (string)drEdit_Ph["So_Ct"];
			drEdit_Ph["Stt"] = strStt_Tt;
			
			foreach (DataRow drImport in Result)
			{
				dtEdit_Ct.ImportRow(drImport);	
			}
			foreach (DataRow dr in dtEdit_Ct.Rows)
			{
				dr["Stt"] = strStt_Tt;
			}
            if (dtEdit_Ct.Rows.Count == 0)
            {
                dtEdit_Ct = dtPhanHoiKTCDAT.Copy();
            }

                DataRow drEdit_Ct = dtEdit_Ct.Rows[0];
                strMa_Ct_Tt = (string)drEdit_Ct["Ma_Ct"];
                drEdit_Ph["Ma_Ct"] = drEdit_Ct["Ma_Ct"];

                SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
                SqlCommand sqlCom = sqlCon.CreateCommand();


                //#region Update chứng từ
                sqlCom.CommandText = "sp_Update_Ct";
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlCom.Parameters.Clear();
                sqlCom.Parameters.AddWithValue("@strNew_Edit", "N");
                sqlCom.Parameters.AddWithValue("@Stt", strStt_Tt);
                sqlCom.Parameters.AddWithValue("@Ma_Ct", strMa_Ct_Tt);
                sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

                //Tạo Table cho TVP_PH
                SqlParameter paraPH = new SqlParameter();
                paraPH.SqlDbType = SqlDbType.Structured;
                paraPH.ParameterName = "@PH";

                SqlParameter paraCt = new SqlParameter();
                paraCt.SqlDbType = SqlDbType.Structured;
                paraCt.ParameterName = "@Ct";

                sqlCom.CommandText = "sp_Update_CtPO";

                //TVP_PH
                paraPH.TypeName = "TVP_PHPO";
                paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHPO", dtEdit_Ph);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CtPO";
                paraCt.Value = Voucher.GetTVPValue("R04CtPO", "TVP_CtPO", dtEdit_Ct);
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
				return false;
			}
			
			return true;
		}

		bool Update_Ct()
		{
            //DataRow[] Result = dtEditCt.Select("Ma_Hd <> ''");
            //dtEditCt = dtEditCt.Clone(); 
            if (!Common.Inlist(strLoai, "PKD,DNXNL"))
            {
                foreach (DataRow dr in dtEditCt.Rows)
                {
                    dr["Ngay_DkGH"] = dteNgay_DkGH.Text;
                }

               
            }
            else if (strLoai == "DNXNL")// cập nhật tổng tiền
            {
                dtEditPh.Rows[0]["TTien_Nt0"] = Common.SumDCValue(dtEditCt, "Tien_Nt", "");
                dtEditPh.Rows[0]["TTien0"] = Common.SumDCValue(dtEditCt, "Tien", "");
                dtEditPh.Rows[0]["TTien_Nt3"] = Common.SumDCValue(dtEditCt, "Tien_Nt3", "");
                dtEditPh.Rows[0]["TTien3"] = Common.SumDCValue(dtEditCt, "Tien3", "");
            }
            else
            {
                foreach (DataRow dr in dtEditCt.Rows)
                {
                    dr["LastModify_Log"] = Common.GetCurrent_Log();
                }
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
            if (strLoai != "PKD")
            {
                sqlCom.CommandText = "sp_Update_CtPO";

                //TVP_PH
                paraPH.TypeName = "TVP_PHPO";
                paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHPO", dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CtPO";
                paraCt.Value = Voucher.GetTVPValue("R04CtPO", "TVP_CtPO", dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else
            {
                sqlCom.CommandText = "sp_Update_CtSO";

                //TVP_PH
                paraPH.TypeName = "TVP_PHSO";
                paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHSO", dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CtSO";
                paraCt.Value = Voucher.GetTVPValue("R04CtSO", "TVP_CtSO", dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }

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
				return false;
			}
			return true;
		}

		bool Save()
		{
            if (!FormCheckValid())
                return false;

            if (TabPhanHoi.TabIndex == 0)
			    Update_Ct();
			else 
                Update_DieuChinh_Ct();

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

		

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Data_Language();

            //if (!Element.sysIs_Admin)
            //{
            //    string strCreate_User = DataTool.SQLGetNameByCode("R80PH", "Stt", "Create_Log", strStt);

            //    if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
            //    {
            //        string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

            //        if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
            //        {
            //            if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
            //            {
            //                this.btgAccept.btAccept.Enabled = false;
            //                return;
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        
    }

}