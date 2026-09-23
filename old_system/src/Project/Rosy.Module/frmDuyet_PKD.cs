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
using System.Data.SqlClient;

namespace RosyModule
{
	public partial class frmDuyet_PKD : RosySystem.Customize.frmEdit
	{
        public DataTable dtDuyet_Ct;
        public DataTable dtDuyet_Ph;
        string strMa_Ct;
        string strStt;
        BindingSource bdsDuyet = new BindingSource();
        BindingSource bdsDuyet_Ph = new BindingSource();

		public frmDuyet_PKD()
		{
			InitializeComponent();
            
			this.rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);

			this.chkDuyet_PKD.CheckedChanged += new EventHandler(chkDuyet_PKD_CheckedChanged);

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

        public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

			strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
			strStt = ((string)drEdit["Stt"]).Trim();
         
			
			Common.ScaterMemvar(this, ref drEdit);
			
			DataRow dr = DataTool.SQLGetDataRowByID("R80PH", "STT", strStt);
            
          if (Common.InlistLike(strMa_Ct, "SO,LXH"))
            {

                if (drEdit["So_Xa_Lan_Tau"].ToString() != "")
                {
                    numTai_Trong_SaLan.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT Tai_Trong FROM R09XALAN WHERE CAST(Gio_Di AS TIME) = '00:00:00' AND So_Xa_Lan_Tau = '" + drEdit["So_Xa_Lan_Tau"] + "'"));
                    numTTSo_Luong.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(So_Luong) FROM R04CTSO WHERE Ngay_Ct BETWEEN DATEADD(day,-7,GETDATE()) AND GETDATE() AND Ma_Ct = '" + strMa_Ct + "' AND So_Xa_Lan_Tau = '" + drEdit["So_Xa_Lan_Tau"] + "'"));
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

            if (strMa_Ct != "SO")
                chkIs_Vt_Nhan.Visible = false;

            //if ((bool)dr["Duyet"] || (bool)dr["Duyet_Huy"])
            //    return ;

            //if (Convert.ToDouble(dr["Print_Count"]) != 0)
            //{
            //    chkDuyet_PKD.Enabled = false;
            //}

			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
            bool bDuyet = (bool)SQLExec.ExecuteReturnValue("SELECT Duyet FROM R80PH WHERE Stt = '" + strStt + "'");
            if (bDuyet)
            {
                Common.MsgOk("Chứng từ đã được PKT duyệt không được gỡ duyệt");
                return false;
            }

			if (chkDuyet_PKD.Checked)
			{
				if (dteNgay_Duyet_PKD.IsNull)
				{
					Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
					return false;
				}
				if ( string.IsNullOrEmpty(txtUser_Duyet_PKD.Text))
				{
					Common.MsgCancel(Languages.GetLanguage("User_Duyet_PKD,Not_Null"));
					return false;
				}
			}

            string strStt_LXH = "A0104" + drEdit["Create_Log"].ToString().Substring(0, 6) + "X" + drEdit["So_Ct"].ToString().Substring(1, 3);

            if (DataTool.SQLCheckExist("R80PH", "Stt", strStt_LXH) && strMa_Ct == "SO")
            {
                DataRow drPH = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt_LXH);
                if (Convert.ToDouble(drPH["Print_Count"]) > 0 || (bool)drPH["Duyet"])
                {
                    Common.MsgOk("Lệnh đã cân hàng không được gỡ duyệt !!!");
                    return false;
                }
               
            }
			return true;
		}
        
		private bool Save()
		{
			string strSQLExec = string.Empty;
			Hashtable htPara;

			//Lưu phần Checked vào R80Ph
            //if (chkDuyet_PKD.Enabled)
            //{
				string strStt = ((string)drEdit["Stt"]).Trim();
				DataRow dr = DataTool.SQLGetDataRowByID("R80PH", "STT", strStt);

				if ((bool)dr["Duyet_Huy"])
					return false;
				else
				{
					htPara = new Hashtable();
					htPara.Add("DUYET_PKD", chkDuyet_PKD.Checked);
					htPara.Add("NGAY_DUYET_PKD", dteNgay_Duyet_PKD.Text);
					htPara.Add("DUYET_LOG_PKD", Common.GetCurrent_Log());
					htPara.Add("USER_DUYET_PKD", txtUser_Duyet_PKD.Text);
					htPara.Add("GHI_CHU_PKD", txtGhi_Chu_PKD.Text);
                    htPara.Add("IS_VT_NHAN", chkIs_Vt_Nhan.Checked);
                   
					htPara.Add("STT", drEdit["Stt"]);


					strSQLExec = "UPDATE R80Ph SET DUYET_PKD = @DUYET_PKD, USER_DUYET_PKD = @USER_DUYET_PKD, NGAY_DUYET_PKD = @NGAY_DUYET_PKD,DUYET_LOG_PKD = @DUYET_LOG_PKD, GHI_CHU_PKD = @GHI_CHU_PKD, IS_VT_NHAN = @IS_VT_NHAN WHERE Stt = @Stt";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{

                        
                        //ngầm duyệt PKT
                        if (chkDuyet_PKD.Enabled)
                        {
                            if (Common.Inlist(strMa_Ct, "SO,SOCP") && chkDuyet_PKD.Checked == true)
                            {
                                DataRow drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
                                Hashtable ht = new Hashtable();
                                ht.Add("SO_LXH", drPh["So_Ct"].ToString());
                                ht.Add("MA_DT", drPh["Ma_Dt"].ToString());
                                ht.Add("NGAY_CT", drPh["Ngay_Ct"]);
                                ht.Add("DUYET_LOG", Common.GetCurrent_Log());
                                ht.Add("MA_DVCS", drPh["Ma_DvCs"].ToString());

                                SQLExec.Execute("sp_UpdateHanMucBH", ht, CommandType.StoredProcedure);

                                //cập nhật số lgh vào phần ra vào cổng
                                Hashtable ht1 = new Hashtable();
                                ht1.Add("IDENT00", drEdit["Ident_RVC"]);
                                ht1.Add("STT", strStt);
                                SQLExec.Execute("UPDATE R09CT_RVC SET Is_LXH = 1, Stt_LXH = @Stt WHERE Ident00 = @Ident00",ht1, CommandType.Text);
                            }
                        }

                        if (Voucher.Create_Auto_LXH(strMa_Ct,strStt))
                        {
                            drEdit["DUYET_PKD"] = chkDuyet_PKD.Checked;
                            drEdit["GHI_CHU_PKD"] = txtGhi_Chu_PKD.Text;
                            drEdit["USER_DUYET_PKD"] = txtUser_Duyet_PKD.Text;
                            drEdit["NGAY_DUYET_PKD"] = dteNgay_Duyet_PKD.Text;
                            drEdit["IS_VT_NHAN"] = chkIs_Vt_Nhan.Checked;
                        }
					}
				}
            

			return true;
		}

		void chkDuyet_PKD_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDuyet_PKD.Checked)
			{
				this.txtUser_Duyet_PKD.Text = Element.sysUser_Id.ToString();
				this.dteNgay_Duyet_PKD.Text = DateTime.Now.ToString();
			}
			else
			{
				this.txtGhi_Chu_PKD.Text = string.Empty;
				this.txtUser_Duyet_PKD.Text = string.Empty;
				
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
