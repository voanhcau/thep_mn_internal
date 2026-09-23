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
	public partial class frmQTCT_Edit : frmEdit
	{
		#region Phuong thuc

		public frmQTCT_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt_CbNv_QlGt.Validating += new CancelEventHandler(txtMa_Dt_CbNv_QlGt_Validating);
            txtMa_Dt_CbNv_QlTt.Validating += new CancelEventHandler(txtMa_Dt_CbNv_QlTt_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);
		}

       

       

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;	

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//txtMa_Dt
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;
		}

		public bool FormCheckValid()
		{
			bool bvalid = true;
			//if (txtHo_Ten.Text.Trim() == string.Empty)
			//{
			//    Common.MsgOk(Languages.GetLanguage("Ho_Ten") + " " +
			//                  Languages.GetLanguage("Not_Null"));
			//    return false;
			//}

			return bvalid;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R09QTCT", ref drEdit))
                return false;
            else
            {
 
            }

			return true;
		}
		#endregion

		#region Su kien
        void txtMa_Dt_CbNv_QlTt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv_QlTt.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv_QlTt.Text = string.Empty;
                lbtTen_Dt_CbNv_QlTt.Text = string.Empty;

            }
            else
            {
                txtMa_Dt_CbNv_QlTt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv_QlTt.Text = drLookup["Ten_Dt"].ToString();
               
            }
        }
        void txtMa_Bp_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequi = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequi, "(Ma_Bp = '" + txtMa_Bp.Text + "' AND Nh_Cuoi = 1) OR Ma_Bp_Ct IN ('TRUONGDV','PHODVI')");

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp_Ct.Text = string.Empty;
                lbtTen_Bp_Ct.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct.Text = (string)drLookup["Ma_Bp_Ct"];
                lbtTen_Bp_Ct.Text = (string)drLookup["Ten_Bp_Ct"];
            }
        }

        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequi = false;

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Ma_Bp", strValue, bRequi, string.Empty);

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = (string)drLookup["Ma_Bp"];
                lbtTen_Bp.Text = (string)drLookup["Ten_Bp"];
            }
        }
        void txtMa_Dt_CbNv_QlGt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv_QlGt.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv_QlGt.Text = string.Empty;
                lbtTen_Dt_CbNv_QlGt.Text = string.Empty;

            }
            else
            {
                txtMa_Dt_CbNv_QlGt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv_QlGt.Text = drLookup["Ten_Dt"].ToString();

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
			isAccept = false;
			this.Close();
		}
		#endregion
	}
}
