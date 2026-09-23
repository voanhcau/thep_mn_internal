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
	public partial class frmUnLock_KT : RosySystem.Customize.frmEdit
	{
        string strMa_Ct = string.Empty;
        string strStt = string.Empty;
        DataRow drDmCt;
        public frmUnLock_KT()
		{
			InitializeComponent();

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			
			Common.ScaterMemvar(this, ref drEdit);
            strMa_Ct = drEdit["Ma_Ct"].ToString();
            strStt = drEdit["Stt"].ToString();
            drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
            txtUser_Huy.Enabled = false;
            txtUser_Huy.Text = Common.GetCurrent_Log();
            chkIs_Lock.Checked = (bool)SQLExec.ExecuteReturnValue("SELECT Is_Lock FROM " + drDmCt["Table_Ct"] + " WHERE Stt = '" + strStt + "'");
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			
			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;
			Hashtable htPara;
            Hashtable htPara_Ct = new Hashtable();
     
			//Lưu phần Checked vào R80Ph
			if (chkIs_Lock.Checked == false)
			{
                
                htPara = new Hashtable();                   
                htPara.Add("DUYET_HUY_LOG", Common.GetCurrent_Log());
                htPara.Add("GHI_CHU_HUY", txtGhi_Chu_Huy.Text);
                htPara.Add("STT", drEdit["Stt"]);
                strSQLExec = "UPDATE R80Ph SET  Duyet_Huy_Log = @Duyet_Huy_Log, Ghi_Chu_Huy = @Ghi_Chu_Huy WHERE Stt = @Stt";
                SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

                htPara_Ct.Add("STT", drEdit["Stt"]);
                htPara_Ct.Add("IS_LOCK", chkIs_Lock.Checked);
                strSQLExec = "UPDATE " + drDmCt["Table_Ct"] + " SET  Is_Lock = @Is_Lock WHERE Stt = @Stt";
                SQLExec.Execute(strSQLExec, htPara_Ct, CommandType.Text);
            }
            else if (chkIs_Lock.Checked == true)
            {
                htPara = new Hashtable();
                htPara.Add("DUYET_HUY_LOG", Common.GetCurrent_Log());
                htPara.Add("GHI_CHU_HUY", txtGhi_Chu_Huy.Text);
                htPara.Add("STT", drEdit["Stt"]);
                strSQLExec = "UPDATE R80Ph SET  Duyet_Huy_Log = @Duyet_Huy_Log, Ghi_Chu_Huy = @Ghi_Chu_Huy WHERE Stt = @Stt";
                SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

                htPara_Ct.Add("STT", drEdit["Stt"]);
                htPara_Ct.Add("IS_LOCK", chkIs_Lock.Checked);
                strSQLExec = "UPDATE " + drDmCt["Table_Ct"] + " SET  Is_Lock = @Is_Lock WHERE Stt = @Stt";
                SQLExec.Execute(strSQLExec, htPara_Ct, CommandType.Text);
            }
			return true;
		}

		

		

		void btSave_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				this.Save();
				this.Close();
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			
		}
	}
}
