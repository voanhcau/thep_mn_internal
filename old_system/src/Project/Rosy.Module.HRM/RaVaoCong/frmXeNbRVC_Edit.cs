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
	public partial class frmXeNbRVC_Edit : frmEdit
	{
		#region Phuong thuc
        string strStt = string.Empty;
        public frmXeNbRVC_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Xe.Validating += new CancelEventHandler(txtMa_Xe_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
		}

       
       

      

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strStt)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strStt = strStt;
			
            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_Ra.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                //dteGio_Vao.Text = "00:00:00";
                dteGio_Vao.Enabled = false;
            }
            else if (enuNew_Edit == enuEdit.Edit)
            {
                Common.ScaterMemvar(this, ref drEdit);
                DateTime dtGio_Ra = Convert.ToDateTime(drEdit["Gio_Ra"]);
                dteGio_Vao.Enabled = true;
                dteGio_Ra.Text = dtGio_Ra.ToString("HH:mm:ss");
                dteGio_Vao.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                
            }
            BindingLanguage();
            LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Nh_Dt = 'NV'";
            txtMa_Xe.bUseAutoDropDown = true;
            txtMa_Xe.strLookupKeyFilter = "Ma_Bp = 'PTCHC' OR Ma_Bp = 'PKHVT' OR Ma_Bp = 'PKD'";
			//txtMa_Dt
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

            //txtMa_Dt
            if (txtMa_Xe.Text.Trim() != string.Empty)
                lbtTen_Xe.Text = DataTool.SQLGetNameByCode("R81DmXe", "Ma_Xe", "Ten_Xe", txtMa_Xe.Text.Trim());
            else
                lbtTen_Xe.Text = string.Empty;

            txtMa_Vt_Sp.bUseAutoDropDown = true;
            txtMa_Vt_Sp.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt.strLookupKeyFilter = "Ma_Nh_Dt LIKE '100' OR Ma_Nh_Dt LIKE '300' OR Ma_Nh_Dt LIKE 'NB'";

            //txtMa_Dt
            if (txtMa_Dt.Text.Trim() != string.Empty)
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            else
                lbtTen_Dt.Text = string.Empty;

            //txtMa_Vt_Sp
            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            else
                lbtTen_Vt.Text = string.Empty;
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
              
                
            }
        }
        void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Sp.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Sp.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;

            }
            else
            {
                txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();


            }
        }

        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Nh_Dt LIKE '100' OR Ma_Nh_Dt LIKE '300' OR Ma_Nh_Dt LIKE 'NB'";

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
		public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Dt_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (txtMa_Xe.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Xe") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtSo_Lenh.Text.Trim() == string.Empty)
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
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["Loai_RVC"] = "2";
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
