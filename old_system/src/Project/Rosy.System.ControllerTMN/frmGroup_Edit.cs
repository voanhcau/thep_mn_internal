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

namespace RosyControllerTMN
{
	public partial class frmGroup_Edit : RosySystem.Customize.frmEdit
    {
		public frmGroup_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
        {
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			this.Text = (enuNew_Edit == enuEdit.New) ? "Them moi nhom nguoi dung" : "Sua nhom nguoi dung";

			Common.ScaterMemvar(this, ref drEdit);

			this.LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName() { }

		private bool FormCheckValid()
		{
			if (this.txtMember_Name.Text.Trim() == string.Empty)
			{
				Common.MsgCancel("Tên nhóm không được rỗng");
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref this.drEdit);

			if (!this.FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(base.enuNew_Edit, "R00Member", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MEMBER_ID", drEdit);

			return true; 
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