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
	public partial class frmDuyet_PKTTC : RosySystem.Customize.frmView
	{
		public DataTable dtDuyet_Ct;
		BindingSource bdsDuyet = new BindingSource();

		DataRow drEdit;

		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		DataRow drCurrent, drDmCt_Current;

		public frmDuyet_PKTTC()
		{
			InitializeComponent();

			this.rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);

			this.chkDuyet_PKTTC.CheckedChanged += new EventHandler(chkDuyet_PKTTC_CheckedChanged);

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			string strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();

			Build();

            // Load check Cong No
            //if (!(bool)drEdit["Duyet"])
            //    FillData();
			BindingLanguage();

			Common.ScaterMemvar(this, ref drEdit);
			chkDuyet_PKTTC.Checked = (bool)drEdit["Duyet"];

			//chkDuyet_PKTTC.Enabled = !chkDuyet_PKTTC.Checked;
			
			if ((bool)drEdit["Duyet_Huy"])
			{
				chkDuyet_PKTTC.Enabled = !(bool)drEdit["Duyet_Huy"];
				btSave.Enabled = false;
			}
			else if (!(bool)drEdit["Duyet_PKD"] && Common.Inlist(strMa_Ct, "SO,SOCP"))// drEdit["Ma_Ct"].ToString() == "SO")
				Common.MsgOk("PKD chưa duyệt Đơn hàng, Vui lòng liên hệ PKD");

			else
				this.ShowDialog();
		}


		private void Build()
		{
		
			//dgvViewPh 
			dgvDuyet.ReadOnly = true;
			dgvDuyet.strZone = "CHECK_CONG_NO";

			dgvDuyet.BuildGridView(false);

		
			//Position
			//this.Controls.Add(dgvDuyet);
		
			//dgvDuyet.TabIndex = 0;
			
		
		}

		void FillData()
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT2", drEdit["Ngay_Ct"]);
			htPara.Add("MA_DT", (string)drEdit["Ma_Dt"]);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_CheckCongNo", htPara, CommandType.StoredProcedure);

			
			dtDuyet_Ct = dsVoucher.Tables[0];
			bdsDuyet.DataSource = dtDuyet_Ct;
			dgvDuyet.DataSource = bdsDuyet;

		}


		private bool FormCheckValid()
		{
			//if (dteNgay_Ct.IsNull)
			//{
			//    Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
			//    return false;
			//}

			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;
			Hashtable htPara;

			//Lưu phần Checked vào R80Ph
			if (chkDuyet_PKTTC.Enabled)
			{
				string strStt = ((string)drEdit["Stt"]).Trim();
				string strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
				DataRow dr = DataTool.SQLGetDataRowByID("R80PH", "STT", strStt);

				if (!(bool)dr["Duyet_PKD"] && Common.Inlist(strMa_Ct,"SO,SOCP"))
				{
					Common.MsgOk("PKD chưa duyệt,vui lòng liên hệ PKD");
					return false;
				}
				else
				{
					htPara = new Hashtable();
					htPara.Add("DUYET", chkDuyet_PKTTC.Checked);
					htPara.Add("DUYET_LOG", Common.GetCurrent_Log());
					htPara.Add("GHI_CHU_PKTTC", txtGhi_Chu_PKTTC.Text);
					htPara.Add("STT", drEdit["Stt"]);

					strSQLExec = "UPDATE R80Ph SET Duyet = @Duyet, Duyet_Log = @Duyet_Log, GHI_CHU_PKTTC = @GHI_CHU_PKTTC WHERE Stt = @Stt";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{
						drEdit["Duyet"] = chkDuyet_PKTTC.Checked;
						drEdit["Duyet_Log"] = Common.GetCurrent_Log();
						drEdit["GHI_CHU_PKD"] = txtGhi_Chu_PKTTC.Text;
					}
				}
			}

			return true;
		}

		void chkDuyet_PKTTC_CheckedChanged(object sender, EventArgs e)
		{
				this.txtDuyet_Log.Text = Common.GetCurrent_Log();
				this.txtGhi_Chu_PKTTC.Text = string.Empty;

			this.btSave.Enabled = true;
		}

		void rsTabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Common.ScaterMemvar(this, ref drEdit);
			chkDuyet_PKTTC.Checked = (bool)drEdit["Duyet"];

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
