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
	public partial class frmNotVAT_NotUse : RosySystem.Customize.frmEdit
	{
        string strMa_Ct = string.Empty;
        string strStt = string.Empty;
        public frmNotVAT_NotUse()
		{
			InitializeComponent();

			this.rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);

			this.chkDuyet.CheckedChanged += new EventHandler(chkDuyet_CheckedChanged);

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
            this.strStt = ((string)drEdit["Stt"]).Trim();
			Common.ScaterMemvar(this, ref drEdit);

            this.chkDuyet.Enabled = true;

         
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
		
			return true;
		}

		private bool Save()
		{
            if (!FormCheckValid())
                return false;

			string strSQLExec = string.Empty;
			Hashtable htPara;
            string strTable_Ct = DataTool.SQLGetNameByCode("R00DMCT", "Ma_Ct", "Table_Ct", strMa_Ct);
			//Lưu phần Checked vào R80Ph
			
				htPara = new Hashtable();
				htPara.Add("ISNOTVAT", chkDuyet.Checked);
				htPara.Add("NOTVAT_LOG", txtDuyet_Log.Text);
				htPara.Add("STT", drEdit["Stt"]);

                strSQLExec = "UPDATE " + strTable_Ct + " SET IsNotVAT = @IsNotVAT, NotVAT_Log = @NotVAT_Log WHERE Stt = @Stt";

                return SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                //if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                //{
                //    drEdit["Duyet"] = chkDuyet.Checked;
                //    drEdit["Duyet_Log"] = txtDuyet_Log.Text;
                //}
			

            //return true;
		}

		void chkDuyet_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDuyet.Checked)
				this.txtDuyet_Log.Text = Common.GetCurrent_Log();
			else
				this.txtDuyet_Log.Text = string.Empty;

			this.btSave.Enabled = true;
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
