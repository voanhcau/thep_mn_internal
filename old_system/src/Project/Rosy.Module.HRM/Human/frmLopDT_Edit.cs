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
	public partial class frmLopDT_Edit : frmEdit
	{
		#region Phuong thuc

        public frmLopDT_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Nh_LopDT.Validating += new CancelEventHandler(txtMa_Nh_LopDT_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
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
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt.strLookupKeyFilter = "Ma_Nh_Dt NOT LIKE 'NV'";


            //txtMa_Dt
            if (txtMa_Dt.Text.Trim() != string.Empty)
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            else
                lbtTen_Dt.Text = string.Empty;

            //txtMa_N
            if (txtMa_Nh_LopDT.Text.Trim() != string.Empty)
                lbtTen_Nh_LopDT.Text = DataTool.SQLGetNameByCode("R81DmNhLopDT", "Ma_Nh_LopDT", "Ten_Nh_LopDT", txtMa_Nh_LopDT.Text.Trim());
            else
                lbtTen_Nh_LopDT.Text = string.Empty;
		}

     
		public bool FormCheckValid()
		{
			bool bvalid = true;
			

            

			return bvalid;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMLOPDT", ref drEdit))
				return false;

			return true;
		}
		#endregion

		#region Su kien
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Nh_Dt NOT LIKE 'NV'";

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

        void txtMa_Nh_LopDT_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_LopDT.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_LopDT", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nh_LopDT.Text = string.Empty;
                lbtTen_Nh_LopDT.Text = string.Empty;

            }
            else
            {
                txtMa_Nh_LopDT.Text = drLookup["Ma_Nh_LopDT"].ToString();
                lbtTen_Nh_LopDT.Text = drLookup["Ten_Nh_LopDT"].ToString();


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
