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
	public partial class frmXeKhachLH_Edit : frmEdit
	{
		#region Phuong thuc
        string strStt = string.Empty;
        public frmXeKhachLH_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);

		}

        

       

      

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strStt)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strStt = strStt;
			

			BindingLanguage();
			
            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_Vao.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                //dteGio_Vao.Text = "00:00:00";
                dteGio_Ra.Enabled = false;
            }
            else if (enuNew_Edit == enuEdit.Edit)
            {
                Common.ScaterMemvar(this, ref drEdit);
                DateTime dtGio_Vao = Convert.ToDateTime(drEdit["Gio_Vao"]);
                dteGio_Ra.Enabled = true;
                dteGio_Vao.Text = dtGio_Vao.ToString("HH:mm:ss");
                dteGio_Ra.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                
            }
            LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Nh_Dt LIKE 'NV'";
           
            
			//txtMa_Dt
            if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
                lbtTen_Dt_CbNv.Text = string.Empty;
            //txtMa_Bp
            if (txtMa_Bp.Text.Trim() != string.Empty)
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            else
                lbtTen_Bp.Text = string.Empty;

           
		}
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, strFilter);

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
      
		public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Dt_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (txtTen_Dt_Khach.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ten_Dt_Khach") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtTen_Cty_Khach.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ten_Cty_Khach") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtSo_Xe.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("So_Xe") + " " +
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
                drEdit["Gio_Vao"] = dteGio_Vao.Text;
            else
                drEdit["Gio_Ra"] = dteGio_Ra.Text;
			
            Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;



            if (enuNew_Edit == enuEdit.New)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["Loai_RVC"] = "5";
                drEdit["Stt"] = strStt;
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
