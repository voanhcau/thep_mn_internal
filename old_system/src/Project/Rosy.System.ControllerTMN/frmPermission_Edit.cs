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
	public partial class frmPermission_Edit : RosySystem.Customize.frmEdit
    {
		public frmPermission_Edit()
        {
            InitializeComponent();

			this.txtObject_ID.Validating += new CancelEventHandler(txtObject_ID_Validating); 

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
			lbtObject_Name.Text = DataTool.SQLGetNameByCode("R00Object", "Object_ID", "Object_Name", txtObject_ID.Text);
		}

		private bool FormCheckValid()
		{
			if (this.txtObject_ID.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Object_ID") + " " + Languages.GetLanguage("CanNotEmpty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref this.drEdit);

			if (drEdit.Table.Columns.Contains("Object_Name"))
				drEdit["Object_Name"] = lbtObject_Name.Text;

			if (!this.FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "R00Permission", ref drEdit))
				return false;

			return true;
		}

		void txtObject_ID_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtObject_ID.Text.Trim();
			bool bRequire = true;
			string strKey = "(Object_Type = '" + (string)drEdit["Object_Type"] + "')";

			if (enuNew_Edit == enuEdit.New)
				strKey += " AND Object_ID NOT IN (SELECT Object_ID FROM R00Permission " +
					" WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "') ";

			DataRow drLookup = Lookup.ShowLookup("Object_ID", strValue, bRequire, strKey, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtObject_ID.Text = string.Empty;
				lbtObject_Name.Text = string.Empty;
			}
			else
			{
				txtObject_ID.Text = ((string)drLookup["Object_ID"]).Trim();
				lbtObject_Name.Text = ((string)drLookup["Object_Name"]).Trim();
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