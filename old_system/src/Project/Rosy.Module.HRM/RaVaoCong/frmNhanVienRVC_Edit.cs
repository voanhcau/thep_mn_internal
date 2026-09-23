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

namespace RosyModule.HRM
{
	public partial class frmNhanVienRVC_Edit : frmEdit
	{
		#region Phuong thuc
        string strStt = string.Empty;
        string strLoaiRVC = string.Empty;
        public frmNhanVienRVC_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Dt_CbNv_QL.Validating += new CancelEventHandler(txtMa_Dt_CbNv_QL_Validating);
		}

      

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strStt, string strLoaiRVC)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strStt = strStt;
            this.strLoaiRVC = strLoaiRVC;
			
            if (enuNew_Edit == enuEdit.New)
            {
                if (strLoaiRVC == "BINHTHUONG")
                {
                    dteGio_Ra.Text = Voucher.GetDateServer().ToString("hh:mm:ss");
                    
                    dteGio_Vao.Enabled = false;
                }
                else
                {
                    dteGio_Vao.Text = Voucher.GetDateServer().ToString("hh:mm:ss");
                   
                    dteGio_Ra.Enabled = false;
                }
            }
            else if (enuNew_Edit == enuEdit.Edit)
            {
                Common.ScaterMemvar(this, ref drEdit);
                if (strLoaiRVC == "BINHTHUONG")
                {
                    DateTime dtGio_Ra = Convert.ToDateTime(drEdit["Gio_Ra"]);
                    dteGio_Vao.Enabled = true;
                    dteGio_Ra.Text = dtGio_Ra.ToString("hh:mm:ss");
                    dteGio_Vao.Text = Voucher.GetDateServer().ToString("hh:mm:ss");
                }
                else
                {
                    DateTime dtGio_Vao = Convert.ToDateTime(drEdit["Gio_Vao"]);
                    dteGio_Ra.Enabled = true;
                    dteGio_Vao.Text = dtGio_Vao.ToString("hh:mm:ss");
                    dteGio_Ra.Text = Voucher.GetDateServer().ToString("hh:mm:ss");
                }
            }
            BindingLanguage();
            LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Nh_Dt = 'NV'";
            txtMa_Dt_CbNv_QL.bUseAutoDropDown = true;
            txtMa_Dt_CbNv_QL.strLookupKeyFilter = "Ma_Nh_Dt = 'NV'";
			//txtMa_Dt
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

            if (txtMa_Dt_CbNv_QL.Text.Trim() != string.Empty)
                lbtTen_Dt_CbNv_QL.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_QL.Text.Trim());
            else
                lbtTen_Dt_CbNv_QL.Text = string.Empty;
		}

        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, strFilter);

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
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                DataRow drDmBp = DataTool.SQLGetDataRowByID("R81DMBP", "Ma_Bp", txtMa_Bp.Text);
                lbtTen_Bp.Text = drDmBp["Ten_Bp"].ToString();
            }
        }
        void txtMa_Dt_CbNv_QL_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv_QL.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv_QL.Text = string.Empty;
                lbtTen_Dt_CbNv_QL.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv_QL.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv_QL.Text = drLookup["Ten_Dt"].ToString();
            }
        }
		public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Dt_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (strLoaiRVC == "BINHTHUONG")
            {
                if (txtMa_Dt_CbNv_QL.Text.Trim() == string.Empty)
                {
                    Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv") + " " +
                                  Languages.GetLanguage("Not_Null"));
                    return false;
                }
                if (dteGio_Ra.Text.Trim() == string.Empty)
                {
                    Common.MsgOk(Languages.GetLanguage("Gio_Ra") + " " +
                                  Languages.GetLanguage("Not_Null"));
                    return false;
                }
                if (enuNew_Edit == enuEdit.Edit)
                    if (dteGio_Vao.Text.Trim() == string.Empty)
                    {
                        Common.MsgOk(Languages.GetLanguage("Gio_Vao") + " " +
                                      Languages.GetLanguage("Not_Null"));
                        return false;
                    }
            }
            else
            {
                if (dteGio_Vao.Text.Trim() == string.Empty)
                {
                    Common.MsgOk(Languages.GetLanguage("Gio_Vao") + " " +
                                  Languages.GetLanguage("Not_Null"));
                    return false;
                }
                if (enuNew_Edit == enuEdit.Edit)
                    if (dteGio_Ra.Text.Trim() == string.Empty)
                    {
                        Common.MsgOk(Languages.GetLanguage("Gio_Ra") + " " +
                                      Languages.GetLanguage("Not_Null"));
                        return false;
                    }
            }
			return bvalid;
		}

		public bool Save()
		{
            if (strLoaiRVC == "BINHTHUONG")
            {
                if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                    drEdit["Gio_Ra"] = dteGio_Ra.Text;
                else
                    drEdit["Gio_Vao"] = dteGio_Vao.Text;
            }
            else
            {
                if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                    drEdit["Gio_Vao"] = dteGio_Vao.Text;
                else
                    drEdit["Gio_Ra"] = dteGio_Ra.Text;
            }
            Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;



            if (enuNew_Edit == enuEdit.New)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["Stt"] = strStt;

                if (strLoaiRVC == "BINHTHUONG")
                    drEdit["Loai_RVC"] = "1";
                else
                    drEdit["Loai_RVC"] = "6";
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
