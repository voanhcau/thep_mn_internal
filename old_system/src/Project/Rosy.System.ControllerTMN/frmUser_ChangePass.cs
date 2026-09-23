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
using System.Text.RegularExpressions;
using RosySystem.Element;

namespace RosyControllerTMN
{
	public partial class frmUser_ChangePass : RosySystem.Customize.frmEdit
	{
		public frmUser_ChangePass()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
		}

		public void Load(ref DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.Text = "Đổi mật khẩu: " + drEdit["Member_ID"].ToString() + " - " + drEdit["Member_Name"].ToString();

			txtPassword.Text = string.Empty;
			txtPassword_Re.Text = string.Empty;

			this.ShowDialog();
		}

		void LoadDicName()
		{

		}

		private bool FormCheckValid()
		{
            string strMgs;
            //if (!ValidatePassword(txtPassword.Text, out strMgs))
            //{
            //    MessageBox.Show(strMgs);
            //    return false;
            //}
            string strPasswordOil = SQLExec.ExecuteReturnValue("SELECT dbo.fn_Decrypt(CheckPass) FROM R00MEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'").ToString();
            if (txtPassword.Text == strPasswordOil)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ!!");
                return false;
            }
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Mật khẩu có chiều dài lớn hơn 8 ký tự và phải có ký tự đặc biệt");
                return false;
            }
            if (this.txtPassword.Text.Trim() != this.txtPassword_Re.Text.Trim())
            {
                MessageBox.Show("Xác nhận lại mật khẩu không đúng");
                return false;
            }
			return true;
		}
        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password không được rỗng");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            //var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password phải có chữ thường";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password phải có chữ hoa";
                return false;
            }
            //else if (!hasMiniMaxChars.IsMatch(input))
            //{
            //    ErrorMessage = "Password should not be less than or greater than 12 characters";
            //    return false;
            //}
            //else if (!hasNumber.IsMatch(input))
            //{
            //    ErrorMessage = "Password should contain At least one numeric value";
            //    return false;
            //}

            //else 
            if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password phải có ký tự đặc biệt";
                return false;
            }
            else
            {
                return true;
            }
        }
		private bool Save()
		{
			if (!this.FormCheckValid())
				return false;

			System.Collections.Hashtable ht = new System.Collections.Hashtable();
			ht.Add("PASSWORD", txtPassword.Text.Trim());

			string strSQLExec =
				"UPDATE R00Member SET " +
				"		CheckPass = dbo.fn_Encrypt(@Password)" +
				"	WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "'";

			if (!SQLExec.Execute(strSQLExec, ht, CommandType.Text))
				return false;

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