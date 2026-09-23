using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;

namespace RosyList
{
	public partial class frmEdit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmEdit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public virtual void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			
		}

		public virtual bool FormCheckValid()
		{
			return true;
		}

		public virtual bool Save()
		{
			return true;
		}

		/// <summary>
		/// Kiểm tra dữ liệu đã tồn tại: true - Đã tồn tại, False - Chưa tồn tại
		/// </summary>
		/// <param name="txtCheck">TextBox để Kiểm tra</param>
		/// <param name="drCheck">Dòng dữ liệu hiện hành để kiểm tra</param>
		/// <param name="strTableName">Tên bảng dữ liệu kiểm tra</param>
		/// <returns></returns>
		public bool CheckDuplicate(TextBox txtCheck, DataRow drCheck, string strTableName)
		{
			string strColName = txtCheck.Name.Substring(3);
			string strColValue = txtCheck.Text;

			string strSQLExec = "SELECT COUNT(*) FROM " + strTableName + " WHERE " + strColName + " <> @Value_Old AND " + strColName + " = @Value AND " + strColName + " <> ''";
			string[] strParaName = new string[] { "VALUE_OLD", "VALUE" };
			string[] strParaValue = new string[] { enuNew_Edit == enuEdit.Edit ? drEdit[strColName, DataRowVersion.Original].ToString() : "", strColValue };

			if (Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, strParaName, strParaValue)) > 0)
			{
                if (!Common.MsgYes_No("[" + Languages.GetLanguage(strColName) + "] đã tồn tại, Bạn có nhập tiếp hay không?", "YES"))
                    return true;
                else
                    return false;
                
			}

			return false;
		}
     
		#endregion

		#region Events

		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//Kiem tra Permission
			switch (this.enuNew_Edit)
			{
				case enuEdit.New:
					this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New);
					break;
				case enuEdit.Edit:
					this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
					break;
				default:
					break;
			}

			if (enuNew_Edit == enuEdit.Edit)
				lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
			else
				lblLog.Text = "";
		}

		#endregion
	}
}
