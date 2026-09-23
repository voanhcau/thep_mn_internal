using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.HRM
{
	public partial class frmThongTinCan_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods
        string strMa_Hd;
        public frmThongTinCan_Edit()
		{
			InitializeComponent();

            txtSo_Xe.Validating += new CancelEventHandler(txtSo_Xe_Validating);
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Hd_Validating);
           
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            this.KeyDown += new KeyEventHandler(frmDnTu_Edit_KeyDown);
		}

       

       

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strMa_Hd)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strMa_Hd = strMa_Hd;

            Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                //txtMa_Dt_CbNv.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
                //string strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "' ");
                //string strTen_Dt_Vc = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Dt_Vc FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt + "' ");
                //string strSo_Ct_Curent = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(So_Ct),'') FROM R09CANHANG WHERE LEFT(So_Ct,4) = '" + strTen_Dt_Vc + "'");
                //string strMa_Bp = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_Id = '" + Element.sysUser_Id + "'");
              
                //Hashtable htPara = new Hashtable();
                //htPara.Add("TABLENAME", "R09CANHANG");
                //htPara.Add("COLUMNNAME", "SO_CT");
                //htPara.Add("CURRENTID", strSo_Ct_Curent);
                //htPara.Add("KEY", " 0 = 0 AND Ma_Bp = '" + strMa_Bp + "'");
                //htPara.Add("PREFIXLEN", 4);
                //htPara.Add("SUFFIXLEN", 3);


                //if (strSo_Ct_Curent == "")
                //    txtSo_Ct.Text = strTen_Dt_Vc + "001/" + DateTime.Now.Month.ToString();
                //else
                //    txtSo_Ct.Text = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);

                dteNgay_Ct.Text = dteNgay_Ct1.Text = dteNgay_Ct2.Text = DateTime.Now.ToString();
                txtMa_Bp.Text = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_Id = '" + Element.sysUser_Id + "'");
                txtMa_Dt_CbNv.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
                numSo_Luong.Value = 0;
               
                txtLoai_Ct.Text = "N";
            }

            txtSo_Xe.bUseAutoDropDown = true;
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Bp.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Vt_Sp.bUseAutoDropDown = true;
            //txtMa_Vt_Sp.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";
            
            
            BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
                lbtTen_Bp.Text = string.Empty;

			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
			{
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
			{
				lbtTen_Dt_CbNv.Text = string.Empty;
			}

            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            }
            else
            {
                lbtTen_Dt.Text = string.Empty;
            }
            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            }
            else
            {
                lbtTen_Vt_Sp.Text = string.Empty;
            }
            //Log
            string strLog = string.Empty;
            if (enuNew_Edit == enuEdit.Edit)
            {
                string strCreate_Log = Common.Show_Log((string)drEdit["Create_Log"]);
                string strLastModify_Log = Common.Show_Log((string)drEdit["LastModify_Log"]);
                
                strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
                strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";
            }
            this.lblLog.Text = strLog;
		}

		public bool FormCheckValid()
		{
			if (txtMa_Bp.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Bp") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Dt_CbNv.Text.Trim() == string.Empty)
			{
                Common.MsgCancel(Languages.GetLanguage("Ma_Dt_CbNv") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Date") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}
            if (txtSo_Xe.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("So_Xe") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }
            if (txtID_CMND.Text.Length < 9 || (txtID_CMND.Text.Length > 9 && txtID_CMND.Text.Length <12) || txtID_CMND.Text.Length > 13)
            {
                Common.MsgCancel(Languages.GetLanguage("ID_CMND") + " chiều dài bằng 9 hoặc bằng 12 ký tự !!! ");
                txtID_CMND.Focus();
                return false;
            }
            // kiểm tra đã tồn tại chưa
            if (enuNew_Edit != enuEdit.Edit && DataTool.SQLCheckExist("R09CANHANG", new string[] { "So_Xe", "So_Xa_Lan_Tau", "Ma_Dt", "Ma_Vt_Sp", "Ngay_Ct1", "Ngay_Ct2", "Ten_LX_Khach", "ID_BL", "ID_CMND" }, 
                    new object[] { txtSo_Xe.Text, txtSo_Xa_Lan_Tau.Text, txtMa_Dt.Text, txtMa_Vt_Sp.Text, dteNgay_Ct1.Text, dteNgay_Ct2.Text, txtTen_Lx_Khach.Text, txtID_BL.Text, txtID_CMND.Text }))
            {
                Common.MsgOk("Đã tồn tại thông tin cân hàng bạn vừa nhập trên hệ thống bạn vui lòng không nhập trùng!!!");
                return false;
            }
            if (txtSo_Xa_Lan_Tau.Text.Trim() != string.Empty && (txtTen_Lx_Xalan.Text == "" || txtID_Lx_Xalan.Text == "" || txtSo_Phone_Lx_Xalan.Text == ""))
            {
                Common.MsgCancel("Thông tin tài công chưa hợp lệ, yêu cầu nhập đầy đủ thông tin tên tài công, CCCD, Số điện thoại!!! ");
                return false;
            }
            if (txtSo_Xe.Text.Trim() != string.Empty && txtSo_Xa_Lan_Tau.Text.Trim() == string.Empty)
            {
                if ((txtTen_Lx_Khach.Text == "" || txtID_BL.Text == "" || txtID_CMND.Text == "" || txtSo_Phone.Text == ""))
                { 
                    Common.MsgCancel("Thông tin tài xế chưa hợp lệ, yêu cầu nhập đầy đủ thông tin tên tài xế, CCCD, BL, Số điện thoại!!! ");
                    return false;
                }
                else  //kiểm tra chiều dài
                    if (txtID_BL.Text.Length != 12 )
                {
                    Common.MsgCancel("Thông tin bằng lái phải 12 ký tự mới cho phép lưu ");
                    return false;
                }
                else  //kiểm tra chiều dài
                    if (txtID_CMND.Text.Length != 12)
                {
                    Common.MsgCancel("Thông tin CCCD phải 12 ký tự mới cho phép lưu ");
                    return false;
                }
                else  //kiểm tra chiều dài
                    if (txtSo_Phone.Text.Length != 10 )
                {
                    Common.MsgCancel("Thông tin số phone phải 10 ký tự mới cho phép lưu ");
                    return false;
                }
            }
           
            //if (numSo_Luong.Value == 0)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("So_Luong") + " không được bằng 0 ");
            //    return false;
            //}

            return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Stt"] = Common.GetNewStt("13", true);
                while (DataTool.SQLCheckExist("R09CANHANG", "Stt", drEdit["Stt"]))
                {
                    drEdit["Stt"] = Common.GetNewStt("13", true);
                }
            }
			//Kiem tra cac du lieu can thiet
                  
			drEdit["Ma_Data"] = Element.sysMa_DvCs;
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["LastModify_Log"] = string.Empty;
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            //Luu xuong CSDL
            //cập nhật ID
            if (!DataTool.SQLCheckExist("R81DMIDCMND", "ID_CMND",txtID_CMND.Text))
            {
                string strSQL = "INSERT INTO R81DMIDCMND (ID_CMND, Ten_Lx_Khach, So_Phone, Create_Log, LastModify_Log, Ma_Data)" +
                    "VALUES(@ID_CMND, @Ten_Lx_Khach, @So_Phone, @Create_Log, '', '"+ Element.sysMa_Data +"')";
                Hashtable ht = new Hashtable();
                ht.Add("ID_CMND", txtID_CMND.Text);
                ht.Add("TEN_LX_KHACH", txtTen_Lx_Khach.Text);
                ht.Add("SO_PHONE", txtSo_Phone.Text);
                ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                
                SQLExec.Execute(strSQL, ht, CommandType.Text);
            }
            
            return DataTool.SQLUpdate(enuNew_Edit, "R09CANHANG", ref drEdit);
		}

		#endregion

		#region Events
        void txtMa_Hd_Validating(object sender, CancelEventArgs e)
        {
           string strValue = txtMa_Vt_Sp.Text.Trim();
            bool bRequire = false;
           // string strFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Sp.Text = string.Empty;
                lbtTen_Vt_Sp.Text = string.Empty;

            }
            else
            {
                txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();

            }
            
        }   
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
            }
        }
        void txtSo_Xe_Validating(object sender, CancelEventArgs e)
        {
            if(!txtSo_Xe.Text.Contains("BAO") && !txtSo_Xe.Text.Contains("BTC"))
            { 
                string strSo_Xe = Voucher.GetFormatSoXe(txtSo_Xe.Text.Trim());
                txtSo_Xe.Text = strSo_Xe;
            }
            if (enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                string strValue = txtSo_Xe.Text.Trim();
                bool bRequire = false;
                string strFilter = "";

                if (!DataTool.SQLCheckExist("R81DMSOXE", "So_Xe", txtSo_Xe.Text.Trim()) && (txtSo_Xe.Text != "/"))
                {

                }
                else
                {
                    DataRow drLookup = Lookup.ShowLookup("So_Xe", strValue, bRequire, strFilter);

                    if (bRequire && drLookup == null)
                        e.Cancel = true;

                    if (drLookup == null)
                    {
                        txtSo_Xe.Text = string.Empty;

                    }
                    else
                    {

                        txtSo_Xe.Text = drLookup["So_Xe"].ToString();
                        txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                        txtMa_Vt_Sp.Text = drLookup["Ma_Vt_Sp"].ToString();


                        LoadDicName();
                    }
                }
            }
        }
        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

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
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

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
			this.isAccept = false;
			this.Close();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

            if (!Element.sysIs_Admin)
            {
                if (enuNew_Edit == enuEdit.Edit)
                {
                    string strCreate_User = (string)drEdit["Create_Log"];

                    if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                    {

                        this.btgAccept.Enabled = false;
                     
                    }
                }
            }
		}

      

        void frmDnTu_Edit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
               
            }
        }

        //private void frmThongTinCan_Edit_Load(object sender, EventArgs e)
        //{

        //}
	}
}
