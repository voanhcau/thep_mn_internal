using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyControllerTMN
{
	public partial class frmPermissionTk_Edit : RosySystem.Customize.frmEdit
    {
		public frmPermissionTk_Edit()
        {
            InitializeComponent();

			this.txtTk.Validating += new CancelEventHandler(txtTk_Validating); 

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
        }

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
        {
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.LoadDicName();

			this.ShowDialog();
		}

		void LoadDicName()
		{
			lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk.Text);
		}

		private bool FormCheckValid()
		{
			if (this.txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("CanNotEmpty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref this.drEdit);

			if (drEdit.Table.Columns.Contains("Ten_Tk"))
				drEdit["Ten_Tk"] = lbtTen_Tk.Text;

			if (!this.FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "R00PermissionTk", ref drEdit))
				return false;

			return true;
		}

		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = true;
			string strKey = "(1 = 1)";

			if (enuNew_Edit == enuEdit.New)
				strKey += " AND Tk NOT IN (SELECT Tk FROM R00PermissionTk " +
					" WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "') ";

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, strKey, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTen_Tk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
	}
}