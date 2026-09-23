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
	public partial class frmDuyet : RosySystem.Customize.frmEdit
	{
        string strMa_Ct = string.Empty;
        string strStt = string.Empty;
		public frmDuyet()
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

            if (!Common.Inlist(strMa_Ct, "PX,NM"))
            {
                if (strMa_Ct == "LXH" && Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT Print_Count FROM R80PH WHERE Stt = '" + strStt + "'")) == 0)
                {
                    chkDuyet.Enabled = true;
                    btSave.Enabled = true;
                }
                else
                {
                    chkDuyet.Enabled = !chkDuyet.Checked;
                    btSave.Enabled = false;
                }
            }
            else
            {
                chkDuyet.Enabled = true;
                btSave.Enabled = true;
            }

            if (Common.InlistLike(strMa_Ct, "SO,LXH"))
            {
                rsTabControl1.TabPages.Remove(tabPage1);
                DataRow dr = DataTool.SQLGetDataRowByID("R80PH", "STT", strStt);
                if (drEdit["So_Xa_Lan_Tau"].ToString() != "")
                {
                    numTai_Trong_SaLan.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT Tai_Trong*1000000 FROM R09XALAN WHERE CAST(Gio_Di AS TIME) = '00:00:00' AND So_Xa_Lan_Tau = '" + drEdit["So_Xa_Lan_Tau"] + "'"));
                    numTTSo_Luong.Value = SQLExec.ExecuteReturnValue("SELECT SUM(So_Luong) FROM R04CTSO WHERE Ngay_Ct BETWEEN DATEADD(day,-7,GETDATE()) AND GETDATE()  AND Ma_Ct = '" + strMa_Ct + "' AND So_Xa_Lan_Tau = '" + drEdit["So_Xa_Lan_Tau"] + "'") == DBNull.Value ? 0 :
                        Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(So_Luong) FROM R04CTSO WHERE Ngay_Ct BETWEEN DATEADD(day,-7,GETDATE()) AND GETDATE()  AND Ma_Ct = '" + strMa_Ct + "' AND So_Xa_Lan_Tau = '" + drEdit["So_Xa_Lan_Tau"] + "'"));
                }
                else if (drEdit["So_Xa_Lan_Tau"].ToString() == "" && drEdit["So_Xe"].ToString() != "")
                {
                    numTai_Trong_Xe.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT Tai_Trong FROM R09CT_RVC WHERE CAST(Gio_Ra AS TIME) = '00:00:00' AND So_Xe = '" + drEdit["So_Xe"] + "'"));
                    numTTSo_Luong.Value = Convert.ToDouble(dr["TSo_Luong"]);
                }
            }
            else
            {
                numTai_Trong_SaLan.Visible = false;
                numTai_Trong_Xe.Visible = false;
                numTTSo_Luong.Visible = false;
                lblLXH.Visible = false;
                lblxalan.Visible = false;
                lblXe.Visible = false;
            }

            if (!(bool)drEdit["Duyet_PKD"] && Common.Inlist(strMa_Ct, "SO,SOCP"))// drEdit["Ma_Ct"].ToString() == "SO")
				Common.MsgOk("PKD chưa duyệt Đơn hàng, Vui lòng liên hệ PKD");
			else
				this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			//kiểm tra trùng số khi duyệt
			Hashtable ht = new Hashtable();
			ht.Add("MA_CT", strMa_Ct);
			ht.Add("NGAY_CT", drEdit["Ngay_Ct"]);
			ht.Add("SO_CT", drEdit["So_Ct"]);
			if(SQLExec.ExecuteReturnDt("SELECT So_Ct FROM R80PH WHERE Ma_Ct = @Ma_Ct AND Ngay_Ct = @Ngay_Ct AND So_Ct = @So_Ct", ht, CommandType.Text).Rows.Count > 1)
            {
				Common.MsgCancel("Số chứng từ "+ drEdit["So_Ct"].ToString() + " đã tồn tại, để tiếp bạn hãy sửa số chứng từ để duyệt lệnh!!!");
				return false;
			}
			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
				return false;
			}
            // kiểm tra tải trọng
            if ((numTai_Trong_Xe.Value != 0 || numTai_Trong_SaLan.Value != 0) && numTTSo_Luong.Value != 0)
            {
                if ((numTTSo_Luong.Value > numTai_Trong_Xe.Value && numTai_Trong_Xe.Value > 0))// || (numTTSo_Luong.Value > numTai_Trong_SaLan.Value))
                    if (!Common.MsgYes_No("Đơn hàng vượt tải trọng xe. Bạn có muốn duyệt lệnh không ???", "Y"))
                        return false;
            }
			return true;
		}

		private bool Save()
		{
            if (!FormCheckValid())
                return false;

			string strSQLExec = string.Empty;
			Hashtable htPara;

			//Lưu phần Checked vào R80Ph
			if (chkDuyet.Enabled)
			{
				htPara = new Hashtable();
				htPara.Add("DUYET", chkDuyet.Checked);
				htPara.Add("DUYET_LOG", txtDuyet_Log.Text);
				htPara.Add("STT", drEdit["Stt"]);

				strSQLExec = "UPDATE R80Ph SET Duyet = @Duyet, Duyet_Log = @Duyet_Log WHERE Stt = @Stt";

				if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
				{
					drEdit["Duyet"] = chkDuyet.Checked;
					drEdit["Duyet_Log"] = txtDuyet_Log.Text;
				}
			}

			return true;
		}

		void chkDuyet_CheckedChanged(object sender, EventArgs e)
		{
            //if (chkDuyet.Checked)
            this.txtDuyet_Log.Text = Common.GetCurrent_Log();
            //else
                //this.txtDuyet_Log.Text = string.Empty;

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

			if (!Element.sysIs_Admin)
			{

				if (!Common.CheckPermission("DUYET", RosySystem.enuPermission_Type.Allow_Access))
				{
					if(!Common.Inlist((string)drEdit["Ma_Ct"],"LXH"))
						rsTabControl1.TabPages.Remove(tabPage3);
				}
			}
		}
	}
}
