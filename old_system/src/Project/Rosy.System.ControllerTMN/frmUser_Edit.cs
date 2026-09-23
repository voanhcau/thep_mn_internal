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
	public partial class frmUser_Edit : RosySystem.Customize.frmEdit
	{
		public frmUser_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
		{
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			this.Text = (enuNew_Edit == enuEdit.New) ? "Them moi nguoi dung" : "Sua nguoi dung";

			Common.ScaterMemvar(this, ref drEdit);

			if (enuNew_Edit == enuEdit.New)
			{
				txtPassword.Text = string.Empty;
				txtPassword_Re.Text = string.Empty;

				txtPassword.ReadOnly = false;
				txtPassword_Re.ReadOnly = false;

				enuIs_Admin.Text = "0";
				chkWeb_Login.Checked = false;
				txtMa_Dt_CbNv.Text = "";
				txtMa_DvCs_Default.Text = "";
			}
			else
			{
				txtPassword.ReadOnly = true;
				txtPassword_Re.ReadOnly = true;

				enuIs_Admin.Enabled = RosySystem.Element.Element.sysIs_Admin;
				txtMember_ID_Allow.Enabled = RosySystem.Element.Element.sysIs_Admin;
				txtMa_Dt_CbNv.Enabled = RosySystem.Element.Element.sysIs_Admin;
			}

			BindingLanguage();
			this.LoadDicName();

			this.ShowDialog();
		}

		void LoadDicName()
		{
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

			if (txtMa_DvCs_Default.Text.Trim() != string.Empty)
			{
				lbtTen_Dvcs_Default.Text = DataTool.SQLGetNameByCode("R00DmDvCs", "Ma_DvCs", "Ten_DvCs", txtMa_DvCs_Default.Text.Trim());
			}
			else
				lbtTen_Dvcs_Default.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
			if (this.txtMember_ID.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Mã người dùng không được rỗng");
				return false;
			}
			if (this.txtMember_Name.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Tên người dùng không được rỗng");
				return false;
			}
			if (enuNew_Edit == enuEdit.New)
				if (this.txtPassword.Text.Trim() != this.txtPassword_Re.Text.Trim())
				{
					MessageBox.Show("Xác nhận lại mật khẩu không đúng");
					return false;
				}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref this.drEdit);

			if (!this.FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			if (enuNew_Edit == enuEdit.New)
				drEdit["Locked"] = false;

			//System.Collections.Hashtable ht = new System.Collections.Hashtable();
			//ht.Add("MEMBER_ID", drEdit["Member_ID"]);
			//ht.Add("MEMBER_NAME", drEdit["Member_Name"]);
			//ht.Add("MEMBER_TYPE", drEdit["Member_Type"]);
			//ht.Add("IS_ADMIN", drEdit["Is_Admin"]);
			//ht.Add("LOCKED", drEdit["Locked"]);
			//ht.Add("MEMBER_ID_ALLOW", drEdit["Member_ID_Allow"]);
			//ht.Add("PASSWORD", ((string)drEdit["Password"]).Trim());

			//string strSQLExec = string.Empty;

			//if (enuNew_Edit == enuEdit.New)
			//{
			//    strSQLExec =
			//        "INSERT INTO R00Member (Member_ID, Member_Name, Member_Type, Is_Admin, Locked, Member_ID_Allow, CheckPass) " +
			//        "	VALUES (@Member_ID, @Member_Name, @Member_Type, @Is_Admin, @Locked, @Member_ID_Allow, dbo.fn_Encrypt(@Password))";
			//}
			//else
			//{
			//    strSQLExec =
			//        "UPDATE R00Member SET " +
			//        "		Member_ID = @Member_ID, Member_Name = @Member_Name, Member_Type = @Member_Type, Is_Admin = @Is_Admin, " +
			//        "		Locked = @Locked, Member_ID_Allow = @Member_ID_Allow " +
			//        "	WHERE Member_ID = '" + (string)drEdit["Member_ID", DataRowVersion.Original] + "'";
			//}

			//if (!SQLExec.Execute(strSQLExec, ht, CommandType.Text))
			//    return false;

			////Hải thêm cột Ma_Dt_CbNv phục vụ cho CRM
			//if (drEdit.Table.Columns.Contains("Ma_Dt_CbNv"))
			//{
			//    strSQLExec = "UPDATE R00Member SET Ma_Dt_CbNv = '" + (string)drEdit["Ma_Dt_CbNv"] + "' WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "'";

			//    SQLExec.Execute(strSQLExec);
			//}

			//Luu vao CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R00Member", ref drEdit))
				return false;

			if (enuNew_Edit == enuEdit.New)
			{
				string strSQLExec=
					"UPDATE R00Member SET " +
					"		CheckPass = dbo.fn_Encrypt(@Password) " +
					"	WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "'";

				SQLExec.Execute(strSQLExec, new string[] { "PASSWORD" }, new object[] { drEdit["Password"] }, CommandType.Text);
			}

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MEMBER_ID", drEdit);

			return true;
		}

		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
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

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (enuNew_Edit == enuEdit.Edit)
				lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + Environment.NewLine + "LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
			else
				lblLog.Text = "";
		}
	}
}