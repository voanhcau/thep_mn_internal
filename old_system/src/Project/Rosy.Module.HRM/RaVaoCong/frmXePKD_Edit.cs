using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.HRM
{
	public partial class frmXePKD_Edit : frmEdit
	{
		#region Phuong thuc
        string strStt = string.Empty;
        string strStt_Org = string.Empty;
        DateTime dteNgay_Ct;
        public frmXePKD_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Xe.Validating += new CancelEventHandler(txtMa_Xe_Validating);

            cboSo_Xe.SelectedValueChanged += new EventHandler(cboSo_Xe_SelectedValueChanged);
		}

        
    

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strStt, DateTime dteNgay_Ct)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strStt = strStt;
            this.dteNgay_Ct = dteNgay_Ct;

			BindingLanguage();
			
            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_Ra.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                //dteGio_Vao.Text = "00:00:00";
                dteGio_Vao.Enabled = false;
                txtLoai_Sp.Text = "T";
            }
            else if (enuNew_Edit == enuEdit.Edit)
            {
                Common.ScaterMemvar(this, ref drEdit);
                DateTime dtGio_Ra = Convert.ToDateTime(drEdit["Gio_Ra"]);
                dteGio_Vao.Enabled = true;
              
                dteGio_Ra.Text = dtGio_Ra.ToString("HH:mm:ss");
                dteGio_Vao.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                
            }
            LoadCombo();
            LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt.strLookupKeyFilter = "Ma_Nh_Dt LIKE '100' OR Ma_Nh_Dt LIKE '110' OR Ma_Nh_Dt LIKE '300'";

            txtMa_Xe.bUseAutoDropDown = true;
            txtMa_Xe.strLookupKeyFilter = "Ma_Bp = 'PKD'";

            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Nh_Dt LIKE 'NV' AND Ma_Bp = 'PKD' AND Ma_Bp_Ct LIKE 'KD3%'";
           
            
			//txtMa_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			else
				lbtTen_Dt.Text = string.Empty;

            //txtMa_Vt_Sp
            if (txtMa_Xe.Text.Trim() != string.Empty)
                lbtTen_Xe.Text = DataTool.SQLGetNameByCode("R81DmXe", "Ma_Xe", "Ten_Xe", txtMa_Xe.Text.Trim());
            else
                lbtTen_Xe.Text = string.Empty;

            //txtMa_Vt_Sp
            if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
            else
                lbtTen_Dt_CbNv.Text = string.Empty;
		}
        private void LoadCombo()
        {
            DataTable dtScalle;
            DataRow dr_rvc = DataTool.SQLGetDataRowByID("R09PH_RVC", "Stt", strStt);
            if (enuNew_Edit == enuEdit.New)
            {
               
                    Hashtable ht1 = new Hashtable();
                    ht1.Add("NGAY_CT", dteNgay_Ct);
                    ht1.Add("CONG", dr_rvc["Cong"]);
                    //dtScalle = SQLExec.ExecuteReturnDt("SELECT Stt, So_Xe + ' - ' + So_Ct AS So_Xe_So_Ct FROM R80PH_SCALE T1 WITH(NOLOCK)  WHERE Ngay_Ct BETWEEN DATEADD(DAY,-4,@Ngay_Ct1) AND @Ngay_Ct AND So_Xa_Lan_Tau <> '' AND So_Xe LIKE '57K%' AND Stt NOT IN (SELECT Stt_Org FROM R09CT_RVC) AND So_Luong_HH <> 0", ht1, CommandType.Text);

                    dtScalle = SQLExec.ExecuteReturnDt("sp_GetComboCong", ht1, CommandType.StoredProcedure);
                
                cboSo_Xe.DataSource = dtScalle;
                cboSo_Xe.ValueMember = "Stt";
                cboSo_Xe.DisplayMember = "So_Xe_So_Ct";

            }
        }
        void cboSo_Xe_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dtScale = new DataTable();
            DataRow drScale;
            if (cboSo_Xe.SelectedValue != null)
            {
                if (cboSo_Xe.SelectedValue.ToString() != "System.Data.DataRowView" && cboSo_Xe.Enabled)
                {
                    string strStt_Scale = cboSo_Xe.SelectedValue == null ? string.Empty : cboSo_Xe.SelectedValue.ToString();
                    
                    if(DataTool.SQLCheckExist("R80PH_SCALE","Stt", strStt_Scale))
                        dtScale = SQLExec.ExecuteReturnDt("SELECT T1.Stt, 'C' + So_Ct AS So_Ct, So_Xe, So_Xa_Lan_Tau, T2.So_Luong, T2.So_Luong AS So_Luong_HH, Ma_Dt, CAST('' AS NVARCHAR(100)) AS Ghi_Chu FROM R80PH_SCALE T1 JOIN (SELECT Stt, SUM(So_Luong) AS So_Luong FROM R05CTX_BARCODE WHERE Stt = '" + strStt_Scale + "' GROUP BY Stt) T2 ON T1.Stt = T2.Stt WHERE T1.Stt = '" + strStt_Scale + "'");
                    else if (SQLExec.ExecuteReturnDt("SELECT * FROM R05CTX_BARCODE_KKV WHERE Stt = '"+ strStt_Scale + "' AND Ma_Kho LIKE 'GK%'").Rows.Count == 0)
                        dtScale = SQLExec.ExecuteReturnDt("SELECT T1.Stt, 'X'+T3.So_Ct AS So_Ct, So_Xe, So_Xa_Lan_Tau, T2.So_Luong, T2.So_Luong AS So_Luong_HH, Ma_Dt, CAST(N'Thép bẻ' AS NVARCHAR(100)) AS Ghi_Chu FROM R80PH_BARCODE_KKV T1 JOIN (SELECT Stt, SUM(So_Luong) AS So_Luong FROM R05CTX_BARCODE_KKV WHERE Stt = '" + strStt_Scale + "' GROUP BY Stt) T2 ON T1.Stt = T2.Stt " +
                                " JOIN (SELECT So_LXH, So_Ct FROM R05CTNX GROUP BY So_LXH, So_Ct) T3 ON T1.SO_CT = T3.SO_LXH WHERE T1.Stt = '" + strStt_Scale + "'");
                    else 
                        dtScale = SQLExec.ExecuteReturnDt("SELECT T1.Stt, 'X'+T3.So_Ct AS So_Ct, So_Xe, So_Xa_Lan_Tau, T2.So_Luong, T2.So_Luong AS So_Luong_HH, Ma_Dt, CAST(N'Thép bẻ' AS NVARCHAR(100)) AS Ghi_Chu FROM R80PH_BARCODE_KKV T1 JOIN (SELECT Stt, SUM(So_Luong) AS So_Luong FROM R05CTX_BARCODE_KKV WHERE Stt = '" + strStt_Scale + "' GROUP BY Stt) T2 ON T1.Stt = T2.Stt " +
                                " JOIN (SELECT So_LXH, So_Ct FROM R05CTNX_CP GROUP BY So_LXH, So_Ct) T3 ON T1.SO_CT = T3.SO_LXH WHERE T1.Stt = '" + strStt_Scale + "'");
                    if (dtScale.Rows.Count>0)
                    { 
                        drScale = dtScale.Rows[0];

                        txtMa_Xe.Text = LoadMaXe(drScale["So_Xe"].ToString());
                        txtSo_Xa_Lan_Tau.Text = drScale["So_Xa_Lan_Tau"].ToString();
                        txtMa_Dt.Text = drScale["Ma_Dt"].ToString();
                        strStt_Org = drScale["Stt"].ToString();
                        numSo_Luong.Value = Convert.ToDouble(drScale["So_Luong_HH"]);
                        txtGiay_To_Di_Kem.Text =  drScale["So_Ct"].ToString();
                        txtGhi_Chu.Text = drScale["Ghi_Chu"].ToString();
                        LoadDicName();
                    }
                }
            }
        }

        private string LoadMaXe(string strSo_Xe)
        {
            string strMa_Xe = string.Empty;

            if (strSo_Xe == "57K-9085")
                strMa_Xe = "F001010";
            else if (strSo_Xe == "57K-9086")
                strMa_Xe = "F001011";
            else if (strSo_Xe == "57K-9087")
                strMa_Xe = "F001012";
            else if (strSo_Xe == "57K-9187")
                strMa_Xe = "F001013";
            else if (strSo_Xe == "57K-9188")
                strMa_Xe = "F001014";
            else if (strSo_Xe == "72C-179.12")
                strMa_Xe = "F001015";

            if (strMa_Xe == "")
                txtSo_Xe.Text = strSo_Xe;

            return strMa_Xe;
        }
        void txtMa_Xe_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Xe.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Xe", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Xe.Text = string.Empty;
                lbtTen_Xe.Text = string.Empty;

            }
            else
            {
                txtMa_Xe.Text = drLookup["Ma_Xe"].ToString();
                lbtTen_Xe.Text = drLookup["Ten_Xe"].ToString();


            }
        }
        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Nh_Dt LIKE 'NV' AND Ma_Bp = 'PKD' AND Ma_Bp_Ct LIKE 'KD3%'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

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
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Nh_Dt LIKE '100' OR Ma_Nh_Dt LIKE '110' OR Ma_Nh_Dt LIKE '300' OR Ma_Nh_Dt LIKE 'NB'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
                
            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
              
                
            }
        }
      
		public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (txtMa_Xe.Text.Trim() == string.Empty && txtSo_Xe.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Xe") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
           
            if (dteGio_Ra.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Gio_Ra") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if(enuNew_Edit == enuEdit.Edit)
                if (dteGio_Vao.Text.Trim() == string.Empty)
                {
                    Common.MsgOk(Languages.GetLanguage("Gio_Vao") + " " +
                                  Languages.GetLanguage("Not_Null"));
                    return false;
                }
			return bvalid;
		}

		public bool Save()
		{
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                drEdit["Gio_Ra"] = dteGio_Ra.Text;
            else
                drEdit["Gio_Vao"] = dteGio_Vao.Text;
			
            Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;



            if (enuNew_Edit == enuEdit.New)
            {
                drEdit["Loai_RVC"] = "4";
                drEdit["Stt"] = strStt;
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["Stt_Org"] = strStt_Org;
            }
            else if (enuNew_Edit == enuEdit.Edit)
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R09CT_RVC", ref drEdit))
				return false;

			return true;
		}
		#endregion

		#region Su kien
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
		#endregion
	}
}
