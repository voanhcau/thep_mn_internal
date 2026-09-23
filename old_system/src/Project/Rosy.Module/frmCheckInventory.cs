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

namespace RosyModule
{
	public partial class frmCheckInventory : RosySystem.Customize.frmView
	{
		public frmVoucher_Edit frmEdit;

		public toolStripView tsView = new toolStripView();

		string strMa_Ct = string.Empty;
		string strMa_Vt = "";
		string strMa_Kho = "";
		DateTime dteNgay_Ct = DateTime.Now;

		DataTable dtCheckInventory0;
		DataTable dtCheckInventory;
	
		BindingSource bdsCheckInventory = new BindingSource();
		DataRow drCurrent;
		enuEdit enumNew_Edit;
		public double iSo_Luong_SO = 0;
		public double iSl_Con_Lai = 0;
		
		public frmCheckInventory()
		{
			InitializeComponent();
						
			dgvCheckInventory.KeyDown += new KeyEventHandler(dgvCheckInventory_KeyDown);
			//dgvCheckInventory.CellDoubleClick += new DataGridViewCellEventHandler(dgvCheckInventory_CellDoubleClick);

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
		}

		public void Load2(DataRow drEdit)
		{
			this.FillData(drEdit);
		}

        public void Load3(DataTable dtCheckInventory)
        {
            Build();
            this.FillData(dtCheckInventory);
            this.ShowDialog();
        }

		public void LoadToolStrip()
		{
			this.splitContainer1.Panel1Collapsed = false;
			this.splitContainer1.Panel1.Controls.Add(tsView);
		}

		public void Build()
		{
			dgvCheckInventory.strZone = "CHECKINVENTORY_KD";
			dgvCheckInventory.BuildGridView();

			bdsSearch = bdsCheckInventory;
			ExportControl = dgvCheckInventory;
		}
        public void FillData(DataTable dtCheckInventory)
        {
            bdsCheckInventory.DataSource = dtCheckInventory;
            dgvCheckInventory.DataSource = bdsCheckInventory;

            dgvCheckInventory.ResizeGridView();

            bdsSearch = bdsCheckInventory;
            ExportControl = dgvCheckInventory;
        }
		public void FillData(DataRow drEdit)
		{
			strMa_Ct = drEdit["Ma_Ct"].ToString();
			string strStt = drEdit["Stt"].ToString();
			//string strMa_Nh_Vt = drEdit["Ma_Nh_Vt"].ToString();
			//if (strMa_Ct == "HD")
			//    strMa_Nh_Vt = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(Ma_Nh_Vt,'') FROM R00DMCT WHERE Ma_Ct = '" + strMa_Ct  + "'", CommandType.Text);

			string strStt_Org = string.Empty;
			if (drEdit.Table.Columns.Contains("Stt_Org")) 
				strStt_Org = drEdit["Stt_Org"] == DBNull.Value ? "" : (string)drEdit["Stt_Org"];

			DateTime dteNgay_Ct2 = (DateTime)drEdit["Ngay_Ct"];
			string strMa_Vt2 = drEdit["Ma_Vt"].ToString();
			double numSL_SO =0;
			if (frmEdit.enuNew_Edit == enuEdit.New || frmEdit.enuNew_Edit == enuEdit.Copy)
				numSL_SO = Convert.ToDouble(drEdit["So_Luong9"].ToString());
			string strMa_Kho2 = drEdit["Ma_Kho"].ToString();
			
			if (strMa_Vt2 != "" || strMa_Kho2 != "" ) 
			{
				this.FillData(strStt, strStt_Org, dteNgay_Ct2, strMa_Vt2, numSL_SO, strMa_Kho2);
			}
		}

		public void FillData(string strStt, string strStt_Org, DateTime dteNgay_Ct2, string strMa_Vt2, double numSL_SO, string strMa_Kho2)
		{
			strMa_Vt = strMa_Vt2;
			strMa_Kho = strMa_Kho2;
			dteNgay_Ct = dteNgay_Ct2;


			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT", dteNgay_Ct);
			htPara.Add("MA_VT", strMa_Vt);
			htPara.Add("SL_SO", numSL_SO);
			//htPara.Add("MA_NH_VT", strMa_Nh_Vt);
			htPara.Add("MA_KHO", strMa_Kho);
			htPara.Add("STT", strStt);
			htPara.Add("STT_ORG", strStt_Org);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtCheckInventory0 = SQLExec.ExecuteReturnDt("sp_CheckInventory_KD", htPara, CommandType.StoredProcedure);

			if (dtCheckInventory0 == null)
				return;

			dtCheckInventory = dtCheckInventory0.Copy();
			//#region Edit
			//if (frmEdit.enuNew_Edit == enuEdit.Edit)
			//{
			//    if (strMa_Ct == "SO")
			//    {
			//        DataTable dtR04CTSO = SQLExec.ExecuteReturnDt("SELECT Stt, Ma_Kho, Ma_Vt, So_Luong FROM R04CTSO WHERE Stt = '" + strStt + "'", CommandType.Text);
			//        foreach (DataRow dr in dtR04CTSO.Rows)
			//        {
			//            if (strMa_Vt2 != "" && dr["Ma_Vt"].ToString() != strMa_Vt2)
			//                continue;

			//            string strMa_Kho0 = dr["Ma_Kho"].ToString();
			//            string strMa_Vt0 = dr["Ma_Vt"].ToString();
			//            double dbSo_Luong0 = Convert.ToDouble(dr["So_Luong"]) * (frmEdit.drDmCt["Nh_Ct"].ToString() == "1" ? -1 : 1);

			//            string strKey = "Ma_Kho = '" + strMa_Kho0 + "' AND Ma_Vt = '" + strMa_Vt0 + "'";

			//            if (dtCheckInventory.Select(strKey).Length > 0)
			//            {
			//                dtCheckInventory.Select(strKey)[0]["So_Luong_SO"] = Convert.ToDouble(dtCheckInventory.Select(strKey)[0]["So_Luong_SO"]) - dbSo_Luong0;
			//            }
			//        }
			//    }
			//    if (strMa_Ct == "HD")
			//    {
			//        DataTable dtR04CTHD = SQLExec.ExecuteReturnDt("SELECT Stt, Ma_Kho, Ma_Vt, So_Luong,Stt_Org FROM R04CTHD WHERE Stt = '" + strStt + "'", CommandType.Text);
			//        foreach (DataRow dr in dtR04CTHD.Rows)
			//        {
			//            if (strMa_Vt2 != "" && dr["Ma_Vt"].ToString() != strMa_Vt2)
			//                continue;

			//            string strMa_KhoHD = dr["Ma_Kho"].ToString();
			//            string strMa_VtHD = dr["Ma_Vt"].ToString();
			//            double dbSo_LuongHD = Convert.ToDouble(dr["So_Luong"]) * (frmEdit.drDmCt["Nh_Ct"].ToString() == "1" ? -1 : 1);

			//            string strKey = "Ma_Kho = '" + strMa_KhoHD + "' AND Ma_Vt = '" + strMa_VtHD + "'";

			//            if (dtCheckInventory.Select(strKey).Length > 0)
			//            {
			//                if ((string)dr["Stt_Org"] != string.Empty)
			//                    dtCheckInventory.Select(strKey)[0]["So_Luong_SO"] = Convert.ToDouble(dtCheckInventory.Select(strKey)[0]["So_Luong_SO"]) + dbSo_LuongHD;
			//                else
			//                    dtCheckInventory.Select(strKey)[0]["Ton_Cuoi_CL"] = Convert.ToDouble(dtCheckInventory.Select(strKey)[0]["Ton_Cuoi_CL"]) + dbSo_LuongHD;
			//            }
			//        }
			//    }
			//}
			//#endregion
			//if (strMa_Ct == "SO")
			//{
			//    foreach (DataRow dr in frmEdit.dtEditCt.Select("Deleted = false"))
			//    {
			//        if (dr.RowState == DataRowState.Deleted)
			//            continue;

			//        if ((bool)dr["Deleted"])
			//            continue;

			//        if (strMa_Vt2 != "" && dr["Ma_Vt"].ToString() != strMa_Vt2)
			//            continue;

			//        string strMa_Kho1 = dr["Ma_Kho"].ToString();
			//        string strMa_Vt1 = dr["Ma_Vt"].ToString();
			//        double dbSo_Luong = Convert.ToDouble(dr["So_Luong"]) * (frmEdit.drDmCt["Nh_Ct"].ToString() == "1" ? -1 : 1);

			//        //string strKey = "Ma_Kho = '" + strMa_Kho1 + "' AND Ma_Vt = '" + strMa_Vt1 + "'";
			//        string strKey = " Ma_Vt = '" + strMa_Vt1 + "'";

			//        if (dtCheckInventory.Select(strKey).Length > 0)
			//        {
			//            if (strMa_Ct == "SO")
			//                dtCheckInventory.Select(strKey)[0]["So_Luong_SO"] = Convert.ToDouble(dtCheckInventory.Select(strKey)[0]["So_Luong_SO"]) + dbSo_Luong;
			//            else if (strMa_Ct == "HD" && (string)dr["Stt_Org"] != "")
			//            {
			//                dtCheckInventory.Select(strKey)[0]["So_Luong_SO"] = Convert.ToDouble(dtCheckInventory.Select(strKey)[0]["So_Luong_SO"]) - dbSo_Luong;
			//                dtCheckInventory.Select(strKey)[0]["Ton_Cuoi_CL"] = Convert.ToDouble(dtCheckInventory.Select(strKey)[0]["Ton_Cuoi_CL"]) - dbSo_Luong;
			//            }
			//            else
			//                dtCheckInventory.Select(strKey)[0]["Ton_Cuoi_CL"] = Convert.ToDouble(dtCheckInventory.Select(strKey)[0]["Ton_Cuoi_CL"]) - dbSo_Luong;
			//        }
			//    }
			//}
			//if (dtCheckInventory.Rows.Count == 0 && strMa_Ct == "SO" && frmEdit.dtEditCt.Rows.Count == 1)
			//{
			//    DataRow drNew = dtCheckInventory.NewRow();
			//    drNew["Ma_Kho"] = frmEdit.drCurrent["Ma_Kho"];
			//    drNew["Ma_Vt"] = frmEdit.drCurrent["Ma_Vt"];
			//    string strMa_Vt_Add = drNew["Ma_Vt"].ToString().Trim();
			//    if (strMa_Vt_Add != string.Empty)
			//    {
			//        DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strMa_Vt_Add, true, "");
			//        if (drLookup != null)
			//        {
			//            drNew["Ten_Vt"] = drLookup["Ten_Vt"];
			//            drNew["Dvt"] = drLookup["Dvt"];
			//        }

			//    }

			//    drNew["So_Luong_SO"] = frmEdit.drCurrent["So_Luong_Dat"];

			//    dtCheckInventory.Rows.Add(drNew);
			//}

			//DataColumn dc = new DataColumn("SL_CON_LAI");
			//dc.DataType = typeof(double);
			//dc.Expression = "Ton_Cuoi_CL - So_Luong_SO + So_Luong_LXH";
			//dtCheckInventory.Columns.Add(dc);

			//if (dtCheckInventory.Rows.Count == 1)
			//{
			//    iSo_Luong_SO = Convert.ToDouble(dtCheckInventory.Rows[0]["So_Luong_SO"]);
			//    iSl_Con_Lai = Convert.ToDouble(dtCheckInventory.Rows[0]["SL_CON_LAI"]);
			//}

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
				this.FillData(frmEdit.strStt,"", dteNgay_Ct,"",0 , dtCheckInventory.Rows[0]["Ma_Kho"].ToString());
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

		//void dgvCheckInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		//{
		//    DataRow drCurrent = ((DataRowView)bdsCheckInventory.Current).Row;
		////	frmCheckInventory_Detail frmDetail = new frmCheckInventory_Detail();
		//    frmDetail.Top = this.Top;
		//    frmDetail.Left = this.Left;
		//    frmDetail.Load(frmEdit,drCurrent);
		//}

		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}
	}
}
