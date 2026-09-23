using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Customize;
using RosySystem.Public;
using RosyList;
using RosySystem;

namespace RosyModule.Payable
{
	public partial class frmCheckInventory : RosySystem.Customize.frmView
	{
		public frmVoucher_Edit frmEdit;

		public toolStripView tsView = new toolStripView();

		string strMa_Ct = string.Empty;
		string strMa_Vt = "";
		string strMa_Kho = "";
		string strMa_Dt = "";
		DateTime dteNgay_Ct = DateTime.Now;

		DataTable dtCheckInventory0;
		DataTable dtCheckInventory;
	
		BindingSource bdsCheckInventory = new BindingSource();
		DataRow drCurrent;
		enuEdit enumNew_Edit;
		public double iSl_Giu = 0;
		public double iSl_Con_Lai = 0;
		
		public frmCheckInventory()
		{
			InitializeComponent();
						
			dgvCheckInventory.KeyDown += new KeyEventHandler(dgvCheckInventory_KeyDown);
			dgvCheckInventory.CellDoubleClick += new DataGridViewCellEventHandler(dgvCheckInventory_CellDoubleClick);

			this.KeyDown += new KeyEventHandler(frmCheckInventory_KeyDown);
		}

		new public void Load(enuEdit enumNew_Edit, DataRow drEdit)
		{
			this.enumNew_Edit = enumNew_Edit;
			this.LoadToolStrip();
			this.Build();
			this.FillData(drEdit);

			this.BindingLanguage();
			this.Text = String.Format(this.Text, dteNgay_Ct.ToShortDateString());

			ShowDialog();
		}

		public void Load2(DataRow drEdit)
		{
			this.FillData(drEdit);
		}

		public void LoadToolStrip()
		{
			this.splitContainer1.Panel1Collapsed = false;
			this.splitContainer1.Panel1.Controls.Add(tsView);
		}

		public void Build()
		{
			dgvCheckInventory.strZone = "CHECKINVENTORY";
			dgvCheckInventory.BuildGridView();

			bdsSearch = bdsCheckInventory;
			ExportControl = dgvCheckInventory;
		}

		public void FillData(DataRow drEdit)
		{
			strMa_Ct = drEdit["Ma_Ct"].ToString();
			string strStt = drEdit["Stt"].ToString();
			string strMa_Nh_Vt = string.Empty;
			//if (strMa_Ct == "HD")
			//    strMa_Nh_Vt = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(Ma_Nh_Vt,'') FROM R00DMCT WHERE Ma_Ct = '" + strMa_Ct  + "'", CommandType.Text);

			string strStt_Org = string.Empty;
			if (drEdit.Table.Columns.Contains("Stt_Org")) 
				strStt_Org = drEdit["Stt_Org"] == DBNull.Value ? "" : (string)drEdit["Stt_Org"];

			DateTime dteNgay_Ct2 = (DateTime)drEdit["Ngay_Ct"];
			string strMa_Vt2 = drEdit["Ma_Vt"].ToString();
			string strMa_Kho2 = drEdit["Ma_Kho"].ToString();
			
			if (strMa_Vt2 != "" || strMa_Kho2 != "") 
			{
				this.FillData(strStt,strStt_Org, dteNgay_Ct2, strMa_Vt2, strMa_Kho2, strMa_Nh_Vt);
			}
		}

		public void FillData(string strStt, string strStt_Org, DateTime dteNgay_Ct2, string strMa_Vt2, string strMa_Kho2, string strMa_Nh_Vt)
		{
			strMa_Vt = strMa_Vt2;
			strMa_Kho = strMa_Kho2;
			strMa_Dt = strMa_Dt;
			dteNgay_Ct = dteNgay_Ct2;

			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT", dteNgay_Ct);
			htPara.Add("MA_VT", strMa_Vt);
			htPara.Add("MA_NH_VT", strMa_Nh_Vt);
			htPara.Add("MA_KHO", strMa_Kho);
			htPara.Add("MA_DT", strMa_Dt);
			htPara.Add("STT", strStt);
			htPara.Add("STT_ORG", strStt_Org);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtCheckInventory0 = SQLExec.ExecuteReturnDt("sp_CheckInventory", htPara, CommandType.StoredProcedure);

			if (dtCheckInventory0 == null)
				return;

			dtCheckInventory = dtCheckInventory0.Copy();
			
			bdsCheckInventory.DataSource = dtCheckInventory;
			dgvCheckInventory.DataSource = bdsCheckInventory;

			dgvCheckInventory.ResizeGridView();

			bdsSearch = bdsCheckInventory;
			ExportControl = dgvCheckInventory;
		}

		void dgvCheckInventory_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F12 && !e.Control && !e.Alt && !e.Shift)
			{	
				string strMa_Nh_Vt =  (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(Ma_Nh_Vt,'') FROM R00DMCT WHERE Ma_Ct = '" + frmEdit.strMa_Ct + "'", CommandType.Text);
				this.FillData(frmEdit.strStt,"", dteNgay_Ct, "", dtCheckInventory.Rows[0]["Ma_Kho"].ToString(), strMa_Nh_Vt);
			}
			else if (e.KeyCode == Keys.F4 && !e.Control && !e.Shift && !e.Alt)
			{
				if (tsView.Visible)
				{
					if (!tsView.txtFilter.Focused)
						tsView.txtFilter.Focus();
					else
						this.SelectNextControl(tsView, true, true, true, true);
				}
				else
					base.OnKeyDown(e);
			}
			else
			{
				base.OnKeyDown(e);
			}

		}

		void frmCheckInventory_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F9)
				frmEdit.Focus();
		}

		void dgvCheckInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//DataRow drCurrent = ((DataRowView)bdsCheckInventory.Current).Row;
			//frmCheckInventory_Detail frmDetail = new frmCheckInventory_Detail();
			//frmDetail.Top = this.Top;
			//frmDetail.Left = this.Left;
			//frmDetail.Load(frmEdit,drCurrent);
		}

		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}
	}
}
