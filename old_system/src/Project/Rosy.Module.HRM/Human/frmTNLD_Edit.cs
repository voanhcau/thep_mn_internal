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
	public partial class frmTNLD_Edit : frmEdit
	{
		#region Phuong thuc

        public frmTNLD_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
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

            dteGio_BD.Text = drEdit["Gio_BD"].ToString();
            dteGio_KT.Text = drEdit["Gio_KT"].ToString();
            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_BD.Text = "00:00:00";
                dteGio_KT.Text = "00:00:00";
            }
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt_CbNv.bUseAutoDropDown = true;

			//txtMa_Dt
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

            //txtMa_Dt
            if (txtMa_Bp_Ct.Text.Trim() != string.Empty)
                lbtTen_Bp_Ct.Text = DataTool.SQLGetNameByCode("R81DmBpCt", "Ma_Bp_Ct", "Ten_Bp_Ct", txtMa_Bp_Ct.Text.Trim());
            else
                lbtTen_Bp_Ct.Text = string.Empty;
           
		}
        void txtMa_Bp_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp_Ct.Text = string.Empty;
                lbtTen_Bp_Ct.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct.Text = drLookup["Ma_Bp_Ct"].ToString();
                lbtTen_Bp_Ct.Text = drLookup["Ten_Bp_Ct"].ToString();
            }
        }
        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

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
       
		public bool FormCheckValid()
		{
			bool bvalid = true;


            if (dteNgay_TNLD.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_TNLD") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (dteGio_BD.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Gio_BD") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (dteGio_KT.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Gio_KT") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
			return bvalid;
		}

		public bool Save()
		{
            drEdit["Gio_BD"] = dteGio_BD.Text;
            drEdit["Gio_KT"] = dteGio_KT.Text;

			Common.GatherMemvar(this, ref drEdit);


			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Ma_TNLD"] = drEdit["Ma_Dt_CbNv"] + Convert.ToDateTime(dteNgay_TNLD.Text).ToString("ddMMyy");
               
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();
            
            drEdit["Ten_TNLD"] = "Tai nạn lao động ngày "+ Convert.ToDateTime(dteNgay_TNLD.Text).ToString("dd/MM/yyyy");
			//Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R09TNLD", ref drEdit))
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
