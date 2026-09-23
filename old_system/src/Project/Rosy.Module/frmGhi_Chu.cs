using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;

namespace RosyModule
{
	public partial class frmGhi_Chu : RosySystem.Customize.frmEdit
	{
		public frmGhi_Chu()
		{
			InitializeComponent();

			this.rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			
			Common.ScaterMemvar(this, ref drEdit);
			//chkDuyet_Huy.Enabled = !chkDuyet_Huy.Checked;
			txtUser_Print.Text = Element.sysUser_Id.ToString();
			txtGhi_Chu_HD.Enabled = true;
			dteNgay_In.Text = Element.sysDateTime_Log.ToString();
			btSave.Enabled = true;
			this.ShowDialog();

		}

		private bool FormCheckValid()
		{
			if (dteNgay_In.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
				return false;
			}
			else if(string.IsNullOrEmpty(txtGhi_Chu_HD.Text) )
			{
				Common.MsgCancel(Languages.GetLanguage("Ghi_Chu_HD,Not_Null"));
				return false;
			}
			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;
			Hashtable htPara;

			//Lưu phần Checked vào R80Ph
	
					htPara = new Hashtable();
					htPara.Add("NGAY_IN", dteNgay_In.Text);
					htPara.Add("USER_PRINT", txtUser_Print.Text);
					htPara.Add("GHI_CHU_HD", txtGhi_Chu_HD.Text);
					htPara.Add("STT", drEdit["Stt"]);
			
				strSQLExec = "UPDATE R80Ph SET  USER_PRINT = @USER_PRINT, NGAY_IN = @NGAY_IN, GHI_CHU_HD = @GHI_CHU_HD WHERE Stt = @Stt";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{

						drEdit["GHI_CHU_HD"] = txtGhi_Chu_HD.Text;
						drEdit["USER_PRINT"] = txtUser_Print.Text;
						drEdit["NGAY_IN"] = dteNgay_In.Text;
					}
			
			return true;
		}

	

		void rsTabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Common.ScaterMemvar(this, ref drEdit);

			btSave.Enabled = false;
		}

		void btSave_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				isAccept = true;
				this.Save();
				this.Close();
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			
		}



	}
}
