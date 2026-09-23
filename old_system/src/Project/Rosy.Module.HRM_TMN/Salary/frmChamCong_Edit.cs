using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
	public partial class frmChamCong_Edit : RosySystem.Customize.frmEdit
	{
		public frmChamCong_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.BindingLanguage();
			this.LoadDicName();
            dteGio_Cham_Cong.Text = drEdit["Gio_Cham_Cong"].ToString();
			txtPhu_Troi.Text = drEdit["Phu_Troi"].ToString();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			
		}

		private bool FormCheckValid()
		{
			bool bValid = true;
			if (txtMa_So.Text.Trim() == string.Empty)
				bValid = false;

			return bValid;
		}

		public bool Save()
		{
            drEdit["Gio_Cham_Cong"] = dteGio_Cham_Cong.Text;
			Common.GatherMemvar(this, ref drEdit);

			//Kiểm tra trên form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Lưu xuống cơ sở dữ liệu
			if (!DataTool.SQLUpdate(enuNew_Edit, "R10CHAMCONG", ref drEdit))
				return false;

		//	SQLExec.Execute("UPDATE R10CHAMCONG SET Ngay_Cham_Cong = Gio_Cham_Cong WHERE IDENT00 = " + drEdit["IDENT00"].ToString());

			return true;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (enuNew_Edit == enuEdit.Edit)
				lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
			else
				lblLog.Text = "";
		}
	}
}
