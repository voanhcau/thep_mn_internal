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
	public partial class frmProgramUp_Edit : RosySystem.Customize.frmEdit
    {
        public frmProgramUp_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
		}

		new public void Load()
        {
			this.drEdit = drEdit;

            //this.enuNew_Edit = enuNew_Edit;
            //this.Text = (enuNew_Edit == enuEdit.New) ? "Them moi nhom nguoi dung" : "Sua nhom nguoi dung";

            //Common.ScaterMemvar(this, ref drEdit);
            this.btgAccept.btCancel.Enabled = false;
			this.LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName() { }

		private bool FormCheckValid()
		{
			if (this.txtLy_Do.Text.Trim() == string.Empty)
			{
				Common.MsgCancel("Lý do không được rỗng");
				return false;
			}

			return true;
		}

		private bool Save()
		{
            //Common.GatherMemvar(this, ref this.drEdit);

            if (!this.FormCheckValid())
                return false;

            //if (!DataTool.SQLUpdate(enuNew_Edit, "R00PROUP", ref drEdit))
            //    return false;

			

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