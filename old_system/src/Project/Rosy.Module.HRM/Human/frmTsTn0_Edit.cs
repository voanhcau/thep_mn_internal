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
	public partial class frmTsTn0_Edit : RosySystem.Customize.frmEdit
	{
		public frmTsTn0_Edit()
		{
			InitializeComponent();

			txtMa_Tn.Validating += new CancelEventHandler(txtMa_Tn_Validating);

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
			if (txtMa_Tn.Text != string.Empty)
			{
				DataRow drDmTn = DataTool.SQLGetDataRowByID("R10DmTn", "Ma_Tn", txtMa_Tn.Text);

				if (drDmTn != null)
				{
					lbtTen_Tn.Text = (string)drDmTn["Ten_Tn"];
					lbtDvt.Text = (string)drDmTn["Dvt"];
				}
			}
			else
			{
				lbtTen_Tn.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Tn.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Tn") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

            drEdit["Dvt"] = lbtDvt.Text;
			drEdit["Ten_Tn"] = lbtTen_Tn.Text;



			if (!this.CheckFormValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			if (!DataTool.SQLUpdate(enuNew_Edit, "R10TsTn0", ref drEdit))
				return false;

			return true;
		}

		void txtMa_Tn_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Tn.bTextChange)
				return;

			string strValue = txtMa_Tn.Text.Trim();
			bool bRequire = false;

			//Salary.frmDmTn frmLookup = new Salary.frmDmTn();
			DataRow drLookup = Lookup.ShowLookup("Ma_Tn", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Tn.Text = string.Empty;
				lbtTen_Tn.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
			else
			{
				txtMa_Tn.Text = drLookup["Ma_Tn"].ToString();
				lbtTen_Tn.Text = drLookup["Ten_Tn"].ToString();
				lbtDvt.Text = drLookup["Dvt"].ToString();
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
