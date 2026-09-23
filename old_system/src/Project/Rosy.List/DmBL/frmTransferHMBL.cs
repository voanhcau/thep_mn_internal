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

namespace RosyList
{
	public partial class frmTransferHMBL : RosySystem.Customize.frmEdit
	{
        string strMa_Ct = string.Empty;

        DataTable dt = new DataTable();
        DataRow drDmCt;
        public frmTransferHMBL()
		{
			InitializeComponent();

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);

            numTien_BL1.Validated += new EventHandler(numTien_BL1_Validated);
            numTien_BL2.Validated += new EventHandler(numTien_BL2_Validated);
		}

     

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

            Hashtable htPara = new Hashtable();

            htPara.Add("SO_BL_GOC", drEdit["So_BL_Goc"].ToString());

            dt = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMBL WHERE So_Bl_Goc = @So_BL_Goc", htPara, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                txtSo_BL1.Text = dt.Rows[0]["So_BL"].ToString();
                txtMa_Dt1.Text = dt.Rows[0]["Ma_Dt"].ToString();
                numTien_Bao_Lanh1.Value = Convert.ToDouble(dt.Rows[0]["Tien_Bao_Lanh"]);
                numTien_BL1.Value = Convert.ToDouble(dt.Rows[0]["Tien_Bao_Lanh"]);
                txtNote.Text = dt.Rows[0]["Note"].ToString();
                if (dt.Rows.Count > 1)
                {
                    txtSo_BL2.Text = dt.Rows[1]["So_BL"].ToString();
                    txtMa_Dt2.Text = dt.Rows[1]["Ma_Dt"].ToString();
                    numTien_Bao_Lanh2.Value = Convert.ToDouble(dt.Rows[1]["Tien_Bao_Lanh"]);
                    numTien_BL2.Value = Convert.ToDouble(dt.Rows[1]["Tien_Bao_Lanh"]);
                }
            }
            
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			
			return true;
		}
        void CalTien()
        {
            numTien_BL2.Value = numTien_Bao_Lanh1.Value + numTien_Bao_Lanh2.Value - numTien_BL1.Value;
            numTien_BL1.Value = numTien_Bao_Lanh1.Value + numTien_Bao_Lanh2.Value - numTien_BL2.Value;
        }
        void numTien_BL2_Validated(object sender, EventArgs e)
        {
            CalTien();
        }

        void numTien_BL1_Validated(object sender, EventArgs e)
        {
            CalTien();
        }
		private bool Save()
		{
			string strSQLExec = string.Empty;
			Hashtable htPara = new Hashtable();
            if (numTien_BL1.Value != 0 && numTien_BL2.Value!= 0)
            {
                strSQLExec = "UPDATE R81DMBL SET Tien_Bao_Lanh = "+numTien_BL1.Value+" WHERE So_BL = '"+ txtSo_BL1.Text +"'";
                SQLExec.Execute(strSQLExec);

                strSQLExec = "UPDATE R81DMBL SET Tien_Bao_Lanh = " + numTien_BL2.Value + " WHERE So_BL = '" + txtSo_BL2.Text + "'";
                SQLExec.Execute(strSQLExec);

              
            }

            strSQLExec = "UPDATE R81DMBL SET Note = '" + txtNote.Text + "' WHERE So_BL = '" + txtSo_BL1.Text + "'";
            SQLExec.Execute(strSQLExec);
            ////Lưu phần Checked vào R80Ph
            //if (chkLock.Checked == false)
            //{
            //    htPara = new Hashtable();

            //    if (strTable_Name == "R81DMHD")
            //    {
            //        htPara_Ct.Add("MA_HD", drEdit["Ma_Hd"]);
            //        htPara_Ct.Add("LOCK", chkLock.Checked);
            //        htPara_Ct.Add("USER_LOCK", txtUser_Lock.Text);
            //        htPara_Ct.Add("GHI_CHU_LOCK", txtGhi_Chu_Lock.Text);

            //        strSQLExec = "UPDATE " + strTable_Name + " SET  Lock = @Lock, User_Lock = @User_Lock, Ghi_Chu_Lock = @Ghi_Chu_Lock WHERE Ma_Hd = @Ma_Hd";
            //    }
            //    else
            //    {
            //        htPara_Ct.Add("IDENT00", drEdit["Ident00"]);
            //        htPara_Ct.Add("LOCK", chkLock.Checked);
            //        htPara_Ct.Add("USER_LOCK", txtUser_Lock.Text);
            //        htPara_Ct.Add("GHI_CHU_LOCK", txtGhi_Chu_Lock.Text);

            //        strSQLExec = "UPDATE " + strTable_Name + " SET  Lock = @Lock, User_Lock = @User_Lock, Ghi_Chu_Lock = @Ghi_Chu_Lock WHERE Ident00 = @Ident00";
            //    }
            //    SQLExec.Execute(strSQLExec, htPara_Ct, CommandType.Text);
            //}
              
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
