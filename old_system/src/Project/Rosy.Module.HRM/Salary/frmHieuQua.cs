using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosyList;
using RosySystem.Public;
using RosySystem.Common;
using RosySystem.Customize;

namespace RosyModule.Salary
{
	public partial class frmHieuQua : RosySystem.Customize.frmView
	{
		DataTable dtHieuQua;
		BindingSource bdsHieuQua = new BindingSource();

		DataRow drCurrent;

		public frmHieuQua()
		{
			InitializeComponent();

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		void Build()
		{
			dgvHieuQua.strZone = "HIEUQUA";
			dgvHieuQua.BuildGridView();
		}

		void FillData()
		{
			//dtHieuQua = DataTool.SQLGetDataTable("R10HieuQua", "", "Nam = " + Element.sysWorkingYear.ToString(), "Nam, Ma_Dt_CbNv");
			string strSQL = @"SELECT T1.*, T2.Ten_Dt AS Ten_Dt_CbNv 
									FROM R10HieuQua T1 LEFT JOIN R81DmDt T2 ON T1.Ma_Dt_CbNv = T2.Ma_Dt AND T1.Nam = " + Element.sysWorkingYear.ToString() + @"
									ORDER BY T1.Nam, T1.Ma_Dt_CbNv";

			dtHieuQua = SQLExec.ExecuteReturnDt(strSQL, CommandType.Text);

			DataColumn dcNew;

			dcNew = new DataColumn("TTIEN_DS", typeof(double));
			dcNew.Expression = "Tien_DS01+Tien_DS02+Tien_DS03+Tien_DS04+Tien_DS05+Tien_DS06+Tien_DS07+Tien_DS08+Tien_DS09+Tien_DS10+Tien_DS11+Tien_DS12";
			dtHieuQua.Columns.Add(dcNew);

			dcNew = new DataColumn("TTIEN_LUONG", typeof(double));
			dcNew.Expression = "Tien_Luong01+Tien_Luong02+Tien_Luong03+Tien_Luong04+Tien_Luong05+Tien_Luong06+Tien_Luong07+Tien_Luong08+Tien_Luong09+Tien_Luong10+Tien_Luong11+Tien_Luong12";
			dtHieuQua.Columns.Add(dcNew);

			dcNew = new DataColumn("TTIEN_GIAMTRU", typeof(double));
			dcNew.Expression = "Tien_GiamTru01+Tien_GiamTru02+Tien_GiamTru03+Tien_GiamTru04+Tien_GiamTru05+Tien_GiamTru06+Tien_GiamTru07+Tien_GiamTru08+Tien_GiamTru09+Tien_GiamTru10+Tien_GiamTru11+Tien_GiamTru12";
			dtHieuQua.Columns.Add(dcNew);

			bdsHieuQua.DataSource = dtHieuQua;
			dgvHieuQua.DataSource = bdsHieuQua;

			//bdsHieuQua.Sort = "Bold, TK, MA_KM";

			bdsSearch = bdsHieuQua;
			ExportControl = dgvHieuQua;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsHieuQua.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			//if (bdsBudget.Position >= 0)
			if (enuNew_Edit == enuEdit.Edit)
				Common.CopyDataRow(((DataRowView)bdsHieuQua.Current).Row, ref drCurrent);
			else
				drCurrent = dtHieuQua.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				drCurrent["Nam"] = Element.sysWorkingYear;
			}

			frmHieuQua_Edit frmEdit = new frmHieuQua_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					//if (bdsBudget.Position >= 0)
					if (enuNew_Edit == enuEdit.Edit)
						dtHieuQua.ImportRow(drCurrent);
					else
						dtHieuQua.Rows.Add(drCurrent);

					bdsHieuQua.Position = bdsHieuQua.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsHieuQua.Current).Row);

				dtHieuQua.AcceptChanges();
			}
		}

		public override void Delete()
		{
			if (bdsHieuQua.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsHieuQua.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R10HieuQua", drCurrent))
			{
				bdsHieuQua.RemoveAt(bdsHieuQua.Position);
				dtHieuQua.AcceptChanges();
			}
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			this.Delete();
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btChart_Click(object sender, EventArgs e)
		{
			//string strColX = "Ma_Dt_CbNv";
			//string strColY = "Tien_DS";
			//string strChartType = drReport["ChartType"].ToString();
			//string strChart_Filter = drReport["Chart_Filter"].ToString();
			////string strTitle = drReport["Title"].ToString().ToUpper();
			//string strTitle = Element.sysLanguage == enuLanguageType.Vietnamese ? (string)drReport["Title"] : (Element.sysLanguage == enuLanguageType.English ? (string)drReport["TitleE"] : (string)drReport["TitleO"]);
			//string strSubTitle = "";

			//if (drReport.Table.Columns.Contains("SubTitle1") && ((string)drReport["SubTitle1"]) != string.Empty)
			//    strSubTitle += (string)drReport["SubTitle1"] + "|";

			//if (drReport.Table.Columns.Contains("SubTitle2") && ((string)drReport["SubTitle2"]) != string.Empty)
			//    strSubTitle += (string)drReport["SubTitle2"] + "|";

			//DataTable dtChart = new DataTable();

			//if (strChart_Filter == "")
			//{
			//    dtChart = dtDetail.Copy();
			//}
			//else
			//{
			//    dtChart = dtDetail.Clone();

			//    foreach (DataRow dr in dtDetail.Select(strChart_Filter))
			//    {
			//        DataRow drNew = dtChart.NewRow();
			//        Common.CopyDataRow(dr, drNew);

			//        dtChart.Rows.Add(drNew);
			//    }
			//}

			//chart1.Load(strColX, strColY, dtChart, strTitle, strSubTitle, strChartType);

			//this.BindingLanguage();
		}
	}
}
