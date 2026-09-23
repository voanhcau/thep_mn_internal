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

namespace RosyModule.HRM
{
	public partial class frmDmBpCt_Edit : RosySystem.Customize.frmEdit
	{
        public frmDmBpCt_Edit()
		{
			InitializeComponent();

			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);

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
			
		}

		private bool CheckFormValid()
		{
            //if (this.txtMa_Bp.Text == string.Empty)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("Ma_Bp") + " " + Languages.GetLanguage("Not_Empty"));
            //    return false;
            //}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.CheckFormValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMBPCT", ref drEdit))
				return false;

			return true;
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

			//Salary.frmDmTn frmLookup = new Salary.frmDmTn();
			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
			
			}
			else
			{
				txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
				
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
