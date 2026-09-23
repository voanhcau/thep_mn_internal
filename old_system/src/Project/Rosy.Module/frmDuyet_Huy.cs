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
	public partial class frmDuyet_Huy : RosySystem.Customize.frmEdit
	{
		public frmDuyet_Huy()
		{
			InitializeComponent();

			this.rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);

			this.chkDuyet_Huy.CheckedChanged += new EventHandler(chkDuyet_Huy_CheckedChanged);

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			
			Common.ScaterMemvar(this, ref drEdit);
			if ((string)drEdit["Ma_Ct"] == "SO")
			{
				if ((bool)drEdit["Duyet_Huy"])
				{
					//đã kế thừa thì không được bỏ hủy
					string sqlKT = "";
					sqlKT = "SELECT Stt FROM R04CTSO  WHERE Stt_Org = " + "'" + drEdit["Stt"] + "'";// +" IN (SELECT DISTINCT Stt_Org FROM R04CTSO)";
					if (!String.IsNullOrEmpty((string)SQLExec.ExecuteReturnValue(sqlKT)))// && strUser_Admin == ",")
						return;
				}
			}

			if (Common.InlistLike((string)drEdit["Ma_Ct"], "SO"))
			{
				rsLabel1.Text = "Lý do đóng";
				rsLabel2.Text = "User đóng";
				chkDuyet_Huy.Text = "Tình trạng đóng";
 
			}
			//chkDuyet_Huy.Enabled = !chkDuyet_Huy.Checked;
            if (txtUser_Huy.Text != string.Empty && txtUser_Huy.Text != Element.sysUser_Id.ToString())
			{
				btSave.Enabled = false;
			}
            //Nếu Hủy mà đã check thanh toán thì yêu cầu gỡ thanh toán    
            if (Common.InlistLike(drEdit["Ma_Ct"].ToString(), "HD") && SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Stt_TT),'') FROM R80CTHANTT WHERE Stt_HD = '" + drEdit["Stt"].ToString() + "' OR Stt_PT = '" + drEdit["Stt"].ToString() + "'") != "") 
            {
                Common.MsgOk("Chứng từ đã được thanh toán. Yêu cầu xóa thanh toán trước khi hủy !!!");
                chkDuyet_Huy.Enabled = false;
            }
             


			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			if (dteNgay_Huy.IsNull && chkDuyet_Huy.Checked == true)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
				return false;
			}
			else if(string.IsNullOrEmpty(txtGhi_Chu_Huy.Text) && chkDuyet_Huy.Checked)
			{
				Common.MsgCancel(Languages.GetLanguage("Ghi_Chu_Huy,Not_Null"));
				return false;
			}
			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;
			Hashtable htPara;

			//Lưu phần Checked vào R80Ph
			if (chkDuyet_Huy.Enabled)
			{
                if (Common.InlistLike(drEdit["Ma_Ct"].ToString(), "SO,SOCP,LXH"))
                {
                    htPara = new Hashtable();
                    htPara.Add("DUYET_HUY", chkDuyet_Huy.Checked);
                    htPara.Add("NGAY_HUY", Library.StrToDate(dteNgay_Huy.Text));
                    htPara.Add("DUYET_HUY_LOG", Common.GetCurrent_Log());
                    htPara.Add("GHI_CHU_HUY", txtGhi_Chu_Huy.Text);
                    htPara.Add("STT", drEdit["Stt"]);


                    strSQLExec = "UPDATE R80Ph SET Duyet_Huy = @Duyet_Huy, Duyet_Huy_Log = @Duyet_Huy_Log, Ngay_Huy = @Ngay_Huy, Ghi_Chu_Huy = @Ghi_Chu_Huy WHERE Stt = @Stt";

                    if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                    {
                        drEdit["Duyet_Huy"] = chkDuyet_Huy.Checked;
                        drEdit["Ghi_Chu_Huy"] = txtGhi_Chu_Huy.Text;
                        drEdit["USER_HUY"] = Common.GetCurrent_Log();//txtUser_Huy.Text;
                        drEdit["Ngay_Huy"] = Library.StrToDate(dteNgay_Huy.Text);
                    }
                }
                else
                {
                    htPara = new Hashtable();
                    htPara.Add("DUYET_HUY", chkDuyet_Huy.Checked);
                    htPara.Add("NGAY_HUY", Library.StrToDate(dteNgay_Huy.Text));
                    htPara.Add("DUYET_HUY_LOG", Common.GetCurrent_Log());
                    htPara.Add("GHI_CHU_HUY", txtGhi_Chu_Huy.Text);
                    htPara.Add("STT", drEdit["Stt"]);


                    strSQLExec = "UPDATE R80Ph SET Duyet = 0, Duyet_Huy = @Duyet_Huy, Duyet_Huy_Log = @Duyet_Huy_Log, Ngay_Huy = @Ngay_Huy, Ghi_Chu_Huy = @Ghi_Chu_Huy WHERE Stt = @Stt";
                   
                    //Xử lí Hủy HD                   
                    Hashtable htDel = new Hashtable();
                    htDel.Add("STT", drEdit["Stt"]);
                    htDel.Add("MA_CT", drEdit["Ma_Ct"]);
                    htDel.Add("DUYET_HUY", true);
                    SQLExec.Execute("sp_UpdateDaXuatHD", htDel, CommandType.StoredProcedure);
                   
                    //HẾT
                    if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                    {
                        drEdit["Duyet_Huy"] = chkDuyet_Huy.Checked;
                        drEdit["Ghi_Chu_Huy"] = txtGhi_Chu_Huy.Text;
                        drEdit["USER_HUY"] = Common.GetCurrent_Log();//txtUser_Huy.Text;
                        drEdit["Ngay_Huy"] = Library.StrToDate(dteNgay_Huy.Text);
                    }
                    DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", drEdit["Ma_Ct"].ToString());
                    Hashtable htPara1 = new Hashtable();
                    htPara1.Add("STT", drEdit["Stt"]);
                    strSQLExec = "UPDATE " + drDmCt["Table_Ct"] + " SET Stt_Org = '' WHERE Stt = @Stt";
                    SQLExec.Execute(strSQLExec, htPara1, CommandType.Text);

                    

                    if (Common.Inlist(drEdit["Ma_Ct"].ToString(), "PXBR,PXDC,PXGK"))
                    {
                        Hashtable htPara2 = new Hashtable();
                        htPara2.Add("STT", drEdit["Stt"]);
                        strSQLExec = "DELETE R05CTNX WHERE Stt_Org = @Stt AND Ma_Ct = 'TP'";
                        SQLExec.Execute(strSQLExec, htPara2, CommandType.Text);
                    }
                }
                
                
			}

			return true;
		}

		void chkDuyet_Huy_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDuyet_Huy.Checked)
			{
				this.txtUser_Huy.Text = Element.sysUser_Id.ToString();
				this.dteNgay_Huy.Text = DateTime.Now.ToString();
			}
			else
			{
				this.txtUser_Huy.Text = string.Empty;
				this.txtGhi_Chu_Huy.Text = string.Empty;
			}
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
