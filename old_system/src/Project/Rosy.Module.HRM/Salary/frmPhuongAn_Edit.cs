using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Salary
{
	public partial class frmPhuongAn_Edit : RosySystem.Customize.frmEdit
	{
        public frmPhuongAn_Edit()
		{
			InitializeComponent();

			txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Tn_Validating);
            //numGia.Validated += new EventHandler(numGia_Validated);
            //numSL_NV.Validated += new EventHandler(numSL_NV_Validated);
            btMa_Bp_Luong.Click += new EventHandler(btMa_Bp_Luong_Click);
            btMa_Bp_Luong_Ca.Click += new EventHandler(btMa_Bp_Luong_Ca_Click);
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
			if (txtMa_Bp_Ct.Text != string.Empty)
			{
				DataRow drDmTn = DataTool.SQLGetDataRowByID("R81DmBpCt", "Ma_Bp_Ct", txtMa_Bp_Ct.Text);

				if (drDmTn != null)
				{
					lbtTen_Bp_Ct.Text = (string)drDmTn["Ten_Bp_Ct"];
					
				}
			}
			else
			{
				lbtTen_Bp_Ct.Text = string.Empty;
                //lbtDvt.Text = string.Empty;
			}
		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Bp_Ct.Text == string.Empty)
			{
                Common.MsgCancel(Languages.GetLanguage("Ma_Bp_Ct") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}
            //if (numGia.Value == 0)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("Gia") + " " + Languages.GetLanguage("Not_Empty"));
            //    return false;
            //}
			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			

			if (!this.CheckFormValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "R09BPCTLUONG", ref drEdit))
				return false;

			return true;
		}
        void btMa_Bp_Luong_Ca_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;
            //strFilter = "Ma_Vt LIKE 'C%' OR Ma_Vt LIKE 'D%' OR Ma_Vt LIKE 'E%' OR Ma_Vt LIKE 'F%' OR Ma_Vt LIKE 'G%' OR Ma_Vt LIKE 'H%' OR Ma_Vt LIKE 'I%' OR Ma_Vt LIKE 'K%'";

            frmQuickLookup_Customize frmLookup = new frmQuickLookup_Customize();
            //frmQuickLookup frmLookup = new frmQuickLookup();
            frmLookup.bMultiLookup = true;

            //Hien Form Lookup
            frmLookup.isLookup = true;
            frmLookup.strLookupColumn = "Ma_Bp_Ct";
            frmLookup.strLookupValue = txtMa_Bp_Luong_Ca.Text;
            frmLookup.strLookupKeyFilter = strFilter;
            frmLookup.strLookupKeyValid = "";

            frmLookup.LoadLookup();

            if (frmLookup.strColumnSelect == null)
            {
                txtMa_Bp_Luong_Ca.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Luong_Ca.Text = frmLookup.strColumnSelect;
            }
        }

        void btMa_Bp_Luong_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;
            //strFilter = "Ma_Vt LIKE 'C%' OR Ma_Vt LIKE 'D%' OR Ma_Vt LIKE 'E%' OR Ma_Vt LIKE 'F%' OR Ma_Vt LIKE 'G%' OR Ma_Vt LIKE 'H%' OR Ma_Vt LIKE 'I%' OR Ma_Vt LIKE 'K%'";

            frmQuickLookup_Customize frmLookup = new frmQuickLookup_Customize();
            //frmQuickLookup frmLookup = new frmQuickLookup();
            frmLookup.bMultiLookup = true;

            //Hien Form Lookup
            frmLookup.isLookup = true;
            frmLookup.strLookupColumn = "Ma_Bp_Ct";
            frmLookup.strLookupValue = txtMa_Bp_Luong.Text;
            frmLookup.strLookupKeyFilter = strFilter;
            frmLookup.strLookupKeyValid = "";

            frmLookup.LoadLookup();


            if (frmLookup.strColumnSelect == null)
            {
                txtMa_Bp_Luong.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Luong.Text = frmLookup.strColumnSelect;
            }
        }

		void txtMa_Tn_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Bp_Ct.bTextChange)
				return;

			string strValue = txtMa_Bp_Ct.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequire, "Nh_Cuoi = 1");

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
	}
}
