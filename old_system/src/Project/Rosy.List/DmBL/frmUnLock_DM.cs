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
	public partial class frmUnLock_DM : RosySystem.Customize.frmEdit
	{
        string strColumnName = string.Empty;
        string strTable_Name = string.Empty;
        DataRow drDmCt;
        public frmUnLock_DM()
		{
			InitializeComponent();

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load(DataRow drEdit, string strTable_Name, string strColumnName)
		{
			this.drEdit = drEdit;
            this.strTable_Name = strTable_Name;
			this.strColumnName = strColumnName;

			Common.ScaterMemvar(this, ref drEdit);

			txtUser_Lock.Enabled = false;
            txtUser_Lock.Text = Common.GetCurrent_Log();
            chkLock.Checked = (bool)SQLExec.ExecuteReturnValue("SELECT Lock FROM " + strTable_Name + " WHERE Ma_Hd = '"+ drEdit["Ma_Hd"] +"'");
			lblLog.Text = "Nhật ký sửa: " + (string)SQLExec.ExecuteReturnValue("SELECT Last_Tien_Log FROM " + strTable_Name + " WHERE Ma_Hd = '" + drEdit["Ma_Hd"] + "'");


			txtUser_Nhan.Enabled = false;
			txtUser_Nhan.Text = Common.GetCurrent_Log();
			chkIs_Nhan.Checked = (bool)SQLExec.ExecuteReturnValue("SELECT Is_Nhan FROM " + strTable_Name + " WHERE Ma_Hd = '" + drEdit["Ma_Hd"] + "'");

			if (strTable_Name == "R81DMHD" && strColumnName == "EDIT")
			{ 
				rsTabControl1.TabPages.Remove(tpLock);
				rsTabControl1.TabPages.Remove(tpHSPKT);
				lblLog.Visible = true; 
			}
			else if (strTable_Name == "R81DMHD" && strColumnName == "IS_NHAN")
			{
				rsTabControl1.TabPages.Remove(tpLock);
				rsTabControl1.TabPages.Remove(tpTinChap);
				lblLog.Visible = true;
			}
			else
            {
				rsTabControl1.TabPages.Remove(tpLock);
				rsTabControl1.TabPages.Remove(tpHSPKT);
				lblLog.Visible = false;
			}
				




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
			if (chkLock.Checked == false)
			{
                htPara = new Hashtable();

                if (strTable_Name == "R81DMHD" && strColumnName == "LOCK")
                {
                    htPara_Ct.Add("MA_HD", drEdit["Ma_Hd"]);
                    htPara_Ct.Add("LOCK", chkLock.Checked);
                    htPara_Ct.Add("USER_LOCK", txtUser_Lock.Text);
                    htPara_Ct.Add("GHI_CHU_LOCK", txtGhi_Chu_Lock.Text);
					
					
					strSQLExec = "UPDATE " + strTable_Name + " SET  Lock = @Lock, User_Lock = @User_Lock, Ghi_Chu_Lock = @Ghi_Chu_Lock WHERE Ma_Hd = @Ma_Hd";
                }
				else if (strTable_Name == "R81DMHD" && strColumnName == "IS_NHAN")
				{
					htPara_Ct.Add("MA_HD", drEdit["Ma_Hd"]);
					htPara_Ct.Add("IS_NHAN", chkIs_Nhan.Checked);
					htPara_Ct.Add("USER_NHAN", txtUser_Lock.Text);
					htPara_Ct.Add("GHI_CHU_LOCK", txtGhi_Chu_Lock.Text);


					strSQLExec = "UPDATE " + strTable_Name + " SET  Is_Nhan = @Is_Nhan, User_Nhan = @User_Nhan WHERE Ma_Hd = @Ma_Hd";
				}
				else if (strTable_Name == "R81DMHD" && strColumnName == "EDIT")
				{
					htPara_Ct.Add("MA_HD", drEdit["Ma_Hd"]);
					htPara_Ct.Add("LAST_TIEN_LOG", Common.GetCurrent_Log());

					htPara_Ct.Add("TIEN_TIN_CHAP", numTien_Tin_Chap.Value);
					htPara_Ct.Add("TIEN_TIN_CHAP_NT", numTien_Tin_Chap_Nt.Value);
					htPara_Ct.Add("TIEN_CAM_CO", numTien_Cam_Co.Value);
					htPara_Ct.Add("TIEN_CAM_CO_NT", numTien_Cam_Co_Nt.Value);
					htPara_Ct.Add("NOTE_TIEN", txtNote_Tien.Text);
					htPara_Ct.Add("NGAY_HD_BD", dteNgay_Hd_Bd.Text);
					htPara_Ct.Add("NGAY_HD_KT", dteNgay_Hd_Kt.Text);
					strSQLExec = "UPDATE " + strTable_Name + " SET Note_Tien = @Note_Tien, Last_Tien_Log = @Last_Tien_Log, " +
							" Tien_Tin_Chap = @Tien_Tin_Chap, Tien_Tin_Chap_Nt = @Tien_Tin_Chap_Nt, Tien_Cam_Co = @Tien_Cam_Co, " +
							" Tien_Cam_Co_Nt = @Tien_Cam_Co_Nt, Ngay_Hd_Bd =@Ngay_Hd_Bd, Ngay_Hd_Kt = @Ngay_Hd_Kt WHERE Ma_Hd = @Ma_Hd";
				}
				else
                {
                    htPara_Ct.Add("IDENT00", drEdit["Ident00"]);
                    htPara_Ct.Add("LOCK", chkLock.Checked);
                    htPara_Ct.Add("USER_LOCK", txtUser_Lock.Text);
                    htPara_Ct.Add("GHI_CHU_LOCK", txtGhi_Chu_Lock.Text);

                    strSQLExec = "UPDATE " + strTable_Name + " SET  Lock = @Lock, User_Lock = @User_Lock, Ghi_Chu_Lock = @Ghi_Chu_Lock WHERE Ident00 = @Ident00";
                }
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
