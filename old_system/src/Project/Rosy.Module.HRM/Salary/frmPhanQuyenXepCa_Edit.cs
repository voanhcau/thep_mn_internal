using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Salary
{
	public partial class frmPhanQuyenXepCa_Edit : RosySystem.Customize.frmEdit
	{
        public frmPhanQuyenXepCa_Edit()
		{
			InitializeComponent();

            this.btMa_Bp_Ct.Click += new EventHandler(btMa_Bp_Ct_Click);
            btMa_Bp_View.Click += new EventHandler(btMa_Bp_View_Click);
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

        
		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
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
            txtMa_Dt_CbNv.bUseAutoDropDown = true;

			if (txtMa_Dt_CbNv.Text != string.Empty)
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text);
			else
                lbtTen_Dt_CbNv.Text = string.Empty;

			
		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Dt_CbNv.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.CheckFormValid())
				return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R10PERMISSCC", ref drEdit))
				return false;

			
			return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
        void btMa_Bp_View_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;
            strFilter = "";

            frmQuickLookup_Customize frmLookup = new frmQuickLookup_Customize();
            //frmQuickLookup frmLookup = new frmQuickLookup();
            frmLookup.bMultiLookup = true;

            //Hien Form Lookup
            frmLookup.isLookup = true;
            frmLookup.strLookupColumn = "Ma_Bp_Ct";
            frmLookup.strLookupValue = txtMa_Bp_Ct_View.Text;
            frmLookup.strLookupKeyFilter = strFilter;
            frmLookup.strLookupKeyValid = "";

            frmLookup.LoadLookup();




            //DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (frmLookup.strColumnSelect == null)
            {
                txtMa_Bp_Ct_View.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct_View.Text = frmLookup.strColumnSelect;
            }
        }

        void btMa_Bp_Ct_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;
            strFilter = "Nh_Cuoi = 1";

            frmQuickLookup_Customize frmLookup = new frmQuickLookup_Customize();
            //frmQuickLookup frmLookup = new frmQuickLookup();
            frmLookup.bMultiLookup = true;

            //Hien Form Lookup
            frmLookup.isLookup = true;
            frmLookup.strLookupColumn = "Ma_Bp_Ct";
            frmLookup.strLookupValue = txtMa_Bp_Ct_List.Text;
            frmLookup.strLookupKeyFilter = strFilter;
            frmLookup.strLookupKeyValid = "";

            frmLookup.LoadLookup();




            //DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (frmLookup.strColumnSelect == null)
            {
                txtMa_Bp_Ct_List.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct_List.Text = frmLookup.strColumnSelect;
            }
        }
        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "Ma_Nh_Dt = 'NV' AND NGAY_NGHI_LAM = '19000101'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt_CbNv.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }
	}
}
