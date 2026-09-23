using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Win32;

using RosySystem;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Element;
using RosySystem.Common;
using Microsoft.Office.Core;

using Word = Microsoft.Office.Interop.Word;

namespace RosyReport
{
	public class Report
	{
		public static DataRow drFilterOrther;
		public static void RunReport(frmReport frmReport)
		{
			if (frmReport.bdsReport.Current == null || frmReport.bdsReport.Position < 0)
				return;

			DataRow drReport = ((DataRowView)frmReport.bdsReport.Current).Row;
			DataRow drFilter;

			string strReport_ID = ((string)drReport["Report_ID"]).Trim();

			//if (!Common.CheckPermission(strReport_ID, "REPORT", enuPermission_Type.Allow_Access))
			//{
			//    Common.MsgCancel(Languages.GetLanguage("No_Permission"));
			//    return;
			//}

			//Tao tham so bao cao
			drFilter = GetdrFilter(frmReport, drReport);

			//Copy để ngầm định dữ liệu đã Filter trước đó
			if (drFilterOrther != null)
			{
				if (drFilter["Report_ID"].ToString() == drFilterOrther["Report_ID"].ToString()
					&& drFilter["Ma_DvCs"].ToString() == drFilterOrther["Ma_DvCs"].ToString()
						&& drFilter["Language_Type"].ToString() == drFilterOrther["Language_Type"].ToString())
				{
					Common.CopyDataRow(drFilterOrther, drFilter);
				}
			}

			//Tao form Filter
			frmReportFilter frmFilter = new frmReportFilter();
			frmFilter.Load(drReport, drFilter);

			if (!frmFilter.isAccept)
				return;

			drFilterOrther = drFilter;

			//Tạo các tham số
			if (!drFilter.Table.Columns.Contains("Title"))
				drFilter.Table.Columns.Add(new DataColumn("Title", typeof(string)));

			if (!drFilter.Table.Columns.Contains("SubTitle1"))
				drFilter.Table.Columns.Add(new DataColumn("SubTitle1", typeof(string)));

			if (!drFilter.Table.Columns.Contains("SubTitle2"))
				drFilter.Table.Columns.Add(new DataColumn("SubTitle2", typeof(string)));

            //if (!drFilter.Table.Columns.Contains("SubTitle3"))
            //    drFilter.Table.Columns.Add(new DataColumn("SubTitle3", typeof(string)));

			drFilter["Title"] = GetTitle(drFilter);

			drFilter["SubTitle1"] = GetSubTitle1(drReport, drFilter);

			drFilter["SubTitle2"] = GetSubTitle2(drReport, drFilter);

			//drFilter["SubTitle3"] = GetSubTitle3(drReport, drFilter);
			//In ra word
			if ((string)drReport["Report_ID"] == "QTTC04")
			{
				string strSQLProc = (string)drReport["SQLProc"];
				DataTable dtResult = SQLExec.ExecuteReturnDt(strSQLProc, drFilter, CommandType.StoredProcedure);
				WriteToWordQTTC04(dtResult, drFilter, drReport, Application.StartupPath + @"\Template\QD15-2006-QTTC04.doc");
			}
			else//In ra Datagrid, ActiveReport
			{
				frmReportResult frmResult = new frmReportResult();
				frmResult.MdiParent = frmReport.MdiParent;
				frmResult.Load(drReport, drFilter);
			}
		}

		private static DataRow GetdrFilter(frmReport frmReport, DataRow drReport)
		{//Tra ve DataRow chua cac tham so cua Report

			string strReport_ID = (string)drReport["Report_ID"];
			string strReport_ID_Filter = (string)drReport["Report_ID_Filter"]; //Kế thừa ReportFilter của 1 report khác

			System.Collections.Hashtable htParameter = new System.Collections.Hashtable();
			htParameter.Add("REPORT_ID", strReport_ID);
			htParameter.Add("REPORT_ID_FILTER", strReport_ID_Filter);

			DataTable dtFilter = SQLExec.ExecuteReturnDt("sp_GetReportFilter", htParameter, CommandType.StoredProcedure);

			DataTable dtTemp = new DataTable();
			DataColumn dcFilter;
			DataRow drFilter;

			foreach (DataRow dr in dtFilter.Rows)
			{
				string strFilter_ID = (string)dr["Filter_ID"];

				switch (Columns.GetColumnType((string)dr["Type"]))
				{
					case enuColumnType.CheckBox:
						dcFilter = new DataColumn(strFilter_ID, typeof(bool));
						break;
					case enuColumnType.Numeric:
						dcFilter = new DataColumn(strFilter_ID, typeof(double));
						break;
					case enuColumnType.DateTime:
						dcFilter = new DataColumn(strFilter_ID, typeof(DateTime));
						break;
					default:
						dcFilter = new DataColumn(strFilter_ID, typeof(string));
						break;
				}

				dtTemp.Columns.Add(dcFilter);
			}

			//Set Dafault value
			dcFilter = new DataColumn("Title", typeof(string));
			dtTemp.Columns.Add(dcFilter);
            if (!dtTemp.Columns.Contains("Ma_DvCs"))
            {
                dcFilter = new DataColumn("Ma_DvCs", typeof(string));
                dtTemp.Columns.Add(dcFilter);
            }
			dcFilter = new DataColumn("Is_Vnd", typeof(bool));
			dtTemp.Columns.Add(dcFilter);

			dcFilter = new DataColumn("Language_Type", typeof(string));
			dtTemp.Columns.Add(dcFilter);

			dcFilter = new DataColumn("Table_Formula", typeof(string));
			dtTemp.Columns.Add(dcFilter);

			dcFilter = new DataColumn("Login_User", typeof(string));
			dtTemp.Columns.Add(dcFilter);

			dcFilter = new DataColumn("Report_ID", typeof(string));
			dtTemp.Columns.Add(dcFilter);

			drFilter = dtTemp.NewRow();

			drFilter["Title"] = Element.sysLanguage == enuLanguageType.Vietnamese ? drReport["Title"] : Element.sysLanguage == enuLanguageType.English ? drReport["TitleE"] : drReport["TitleO"];
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;
			drFilter["Is_Vnd"] = frmReport.strVnd_Nt == "0" ? true : false;
			drFilter["Language_Type"] = (char)Element.sysLanguage;
			drFilter["Table_Formula"] = drReport["Table_Formula"];
			drFilter["Login_User"] = Element.sysUser_Id;
			drFilter["Report_ID"] = strReport_ID; //Hải thêm Report_ID phục vụ cho việc Ngầm định Filter của báo cáo cuối cùng vừa chạy

			if (dtTemp.Columns.Contains("Ngay_Ct0"))
				drFilter["Ngay_Ct0"] = Element.sysNgay_Ct1;

			if (dtTemp.Columns.Contains("Ngay_Ct"))
				drFilter["Ngay_Ct"] = Element.sysNgay_Ct1;

			if (dtTemp.Columns.Contains("Ngay_Ct1"))
				drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;

			if (dtTemp.Columns.Contains("Ngay_Ct2"))
				drFilter["Ngay_Ct2"] = Element.sysNgay_Ct2;

			return drFilter;
		}

		public static void ViewDetail(DataRow drReport, DataRow drFilter, DataRow drCurrent, Form frmParent)
		{
			DataRow drFilterDetail = drFilter.Table.NewRow();

			//Them vao drFilterDetail nhung truong ma drCurrent co nhung drFilter khong co
			SqlCommand sqlCom = SQLExec.GetSQLCommand();
			SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCom);

			string strSqlProc = (string)drReport["SqlProc"];
			sqlCom.CommandText = strSqlProc;
			sqlCom.CommandType = CommandType.StoredProcedure;

			string strKey = "Object_id = Object_id('" + strSqlProc + "')";
			DataTable dtSqlProcPara = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

			//Add Parameter Into sqlProc
			foreach (DataRow dr in dtSqlProcPara.Rows)
			{
				string strColumnName = ((string)dr["Name"]).Replace("@", "");

				if (!drFilterDetail.Table.Columns.Contains(strColumnName))
				{
					if (drCurrent.Table.Columns.Contains(strColumnName))
						drFilterDetail.Table.Columns.Add(strColumnName, drCurrent.Table.Columns[strColumnName].DataType);
					else
						drFilterDetail.Table.Columns.Add(strColumnName, typeof(string));
				}
			}

			Common.CopyDataRow(drFilter, drFilterDetail);

			for (int i = 0; i <= drCurrent.Table.Columns.Count - 1; i++)
			{
				string strColumn = drCurrent.Table.Columns[i].ColumnName;

				if (drFilterDetail.Table.Columns.Contains(strColumn))
				{
					//if ((drFilterDetail.Table.Columns[strColumn].DataType.Name == "DateTime" && ((DateTime)drFilterDetail[strColumn]).ToString("dd/MM/yyyy") == "01/01/1900") ||
					//    drCurrent[strColumn].ToString() != string.Empty)
					drFilterDetail[strColumn] = drCurrent[strColumn];
				}
			}

			//Common.CopyDataRow(drCurrent, drFilterDetail);

			//// Mot so trường hop dac biệt
			//if (drCurrent.Table.Columns.Contains("Bold") && (bool)drCurrent["Bold"] == true)
			//{
			//    if (drFilterDetail.Table.Columns.Contains("Ma_Dt") && drFilterDetail.Table.Columns.Contains("Ma_Nh_Dt"))
			//    {
			//        drFilterDetail["Ma_Nh_Dt"] = drFilterDetail["Ma_Dt"];
			//        drFilterDetail["Ma_Dt"] = "";
			//    }
			//    if (drFilterDetail.Table.Columns.Contains("Ma_Vt") && drFilterDetail.Table.Columns.Contains("Ma_Nh_Vt"))
			//    {
			//        drFilterDetail["Ma_Nh_Vt"] = drFilterDetail["Ma_Vt"];
			//        drFilterDetail["Ma_Vt"] = "";
			//    }
			//}

			frmReportResult frm = new frmReportResult();
			frm.MdiParent = frmParent;
			frm.Load(drReport, drFilterDetail);
		}

		public static void WriteToWordQTTC04(DataTable dtResult, DataRow drFilter, DataRow drReport, string strFileTemplate)
		{
			string strSaveFile = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Local Settings", @"C:\") + @"\Temp\" + (string)drReport["Report_ID"] + ".doc";
			System.IO.File.Copy(strFileTemplate, strSaveFile, true);

			object missing = System.Reflection.Missing.Value;
			object newTemplate = false;
			object docType = 0;
			object confirm = false;
			object myTrue = false; // mở file word với readonly = false

			Word.ApplicationClass wrdApp = new Word.ApplicationClass();
			wrdApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
			wrdApp.UserName = Environment.UserName;

			object fileName = strSaveFile;
			Word.Document docOpen = wrdApp.Documents.Open(ref fileName, ref confirm, ref myTrue, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

			wrdApp.Selection.Find.ClearFormatting();
			wrdApp.Selection.Find.Replacement.ClearFormatting();

			//CultureInfo cti = new CultureInfo("en-GB");
			//cti.NumberFormat.NumberGroupSeparator = ",";
			//cti.NumberFormat.NumberGroupSizes = new int[] { 3, 3, 3, 3, 3 };
			//cti.NumberFormat.NumberDecimalSeparator = ".";

			//cti.NumberFormat.CurrencyGroupSeparator = ",";
			//cti.NumberFormat.CurrencyGroupSizes = new int[] { 3, 3, 3, 3, 3 };
			//cti.NumberFormat.CurrencyDecimalSeparator = ".";

			CultureInfo cti = new CultureInfo("vi-VN");

			object replaceAll = Word.WdReplace.wdReplaceAll;

			//Replace Header
			wrdApp.Selection.Find.Text = "[TEN_DV]";
			wrdApp.Selection.Find.Replacement.Text = Element.sysTen_Dvi.ToUpper();
			wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

			wrdApp.Selection.Find.Text = "[DIA_CHI_DV]";
			//wrdApp.Selection.Find.Replacement.Text = (string)Parameters.GetParaValue("DIA_CHI");
			wrdApp.Selection.Find.Replacement.Text = Element.sysDia_Chi_Dv;
			wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

			wrdApp.Selection.Find.Text = "[SUBTITLE1]";
			wrdApp.Selection.Find.Replacement.Text = ((DateTime)drFilter["Ngay_Ct2"]).Year.ToString();
			wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

			//Replace Detail
			foreach (DataRow dr in dtResult.Rows)
			{
				string strMa_So = (string)dr["Ma_So"];
				string strDu_Dau;

				if ((string)drReport["Vnd_Nt"] == "1")
					strDu_Dau = Convert.ToDouble(dr["Du_Dau_Nt"]).ToString("N2", cti);
				else
					strDu_Dau = Convert.ToDouble(dr["Du_Dau"]).ToString("N0", cti);

				if (strDu_Dau == "0")
					strDu_Dau = string.Empty;

				string strDu_Cuoi;

				if ((string)drReport["Vnd_Nt"] == "1")
					strDu_Cuoi = Convert.ToDouble(dr["Du_Cuoi_Nt"]).ToString("N2", cti);
				else
					strDu_Cuoi = Convert.ToDouble(dr["Du_Cuoi"]).ToString("N0", cti);

				if (strDu_Cuoi == "0")
					strDu_Cuoi = string.Empty;

				wrdApp.Selection.Find.Text = "[" + strMa_So + "_Du_Dau]";
				wrdApp.Selection.Find.Replacement.Text = strDu_Dau;
				wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

				wrdApp.Selection.Find.Text = "[" + strMa_So + "_Du_Cuoi]";
				wrdApp.Selection.Find.Replacement.Text = strDu_Cuoi;
				wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
			}
			///////Write phan tai san co dinh Huu hinh-----------------------------------
			System.Collections.Hashtable htParameter = new System.Collections.Hashtable();
			htParameter.Add("NGAY_CT1", drFilterOrther["Ngay_Ct1"]);
			htParameter.Add("NGAY_CT2", drFilterOrther["Ngay_Ct2"]);
			htParameter.Add("TABLE_FORMULA", "");
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);


			DataTable dtTsHH = new DataTable();
			htParameter["TABLE_FORMULA"] = "R82TST10A";
			dtTsHH = SQLExec.ExecuteReturnDt("sp_rptTST10A", htParameter, CommandType.StoredProcedure);
			string strColumnList = "TIEN_TSA1,TIEN_TSA2,TIEN_TSA3,TIEN_TSA4,TIEN_TSA5,TIEN_TSA8,TONG_CONG";
			int i = 1;
			foreach (DataRow dr in dtTsHH.Rows)
			{

				for (int j = 0; j < dr.Table.Columns.Count; j++)
				{

					string strColumnName = dr.Table.Columns[j].ColumnName;
					if (Common.Inlist(strColumnName, strColumnList))
					{
						string strMsTs;
						string strTien_Ts;

						strMsTs = "A" + dr["Ma_So"].ToString() + "_" + strColumnName;
						strTien_Ts = Convert.ToDouble(dr[strColumnName]).ToString("N0", cti);

						if (strTien_Ts == "0")
							strTien_Ts = string.Empty;

						wrdApp.Selection.Find.Text = "[" + strMsTs + "]";
						wrdApp.Selection.Find.Replacement.Text = strTien_Ts;
						wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

					}

				}
				i++;

			}

			///////Write phan tai san co dinh Huu hinh thue tai chinh-----------------------------------

			dtTsHH = new DataTable();
			htParameter["TABLE_FORMULA"] = "R82TST10B";
			dtTsHH = SQLExec.ExecuteReturnDt("sp_rptTST10B", htParameter, CommandType.StoredProcedure);
			strColumnList = "TIEN_TSB1,TIEN_TSB2,TIEN_TSB3,TIEN_TSB4,TIEN_TSB5,TIEN_TSB8,TONG_CONG";
			i = 1;
			foreach (DataRow dr in dtTsHH.Rows)
			{

				for (int j = 0; j < dr.Table.Columns.Count; j++)
				{

					string strColumnName = dr.Table.Columns[j].ColumnName;
					if (Common.Inlist(strColumnName, strColumnList))
					{
						string strMsTs;
						string strTien_Ts;

						strMsTs = "B" + dr["Ma_So"].ToString() + "_" + strColumnName;
						strTien_Ts = Convert.ToDouble(dr[strColumnName]).ToString("N0", cti);
						if (strTien_Ts == "0")
							strTien_Ts = string.Empty;

						wrdApp.Selection.Find.Text = "[" + strMsTs + "]";
						wrdApp.Selection.Find.Replacement.Text = strTien_Ts;
						wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

					}

				}
				i++;

			}

			////// Write phan ts Vo Hinh
			DataTable dtTsVH = new DataTable();
			htParameter["TABLE_FORMULA"] = "R82TST10C";
			dtTsVH = SQLExec.ExecuteReturnDt("sp_rptTST10C", htParameter, CommandType.StoredProcedure);
			strColumnList = "TIEN_TSC1,TIEN_TSC2,TIEN_TSC3,TIEN_TSC4,TIEN_TSC5,TIEN_TSC6,TIEN_TSC8,TONG_CONG";
			i = 1;
			foreach (DataRow dr in dtTsVH.Rows)
			{

				for (int j = 0; j < dr.Table.Columns.Count; j++)
				{

					string strColumnName = dr.Table.Columns[j].ColumnName;
					if (Common.Inlist(strColumnName, strColumnList))
					{
						string strMsTs;
						string strTien_Ts;

						strMsTs = "C" + dr["Ma_So"].ToString() + "_" + strColumnName;
						strTien_Ts = Convert.ToDouble(dr[strColumnName]).ToString("N0", cti);
						if (strTien_Ts == "0")
							strTien_Ts = string.Empty;

						wrdApp.Selection.Find.Text = "[" + strMsTs + "]";
						wrdApp.Selection.Find.Replacement.Text = strTien_Ts;
						wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

					}

				}
				i++;

			}
			//////////////////////////////////////////////////////
			object saveChanges = Word.WdSaveOptions.wdSaveChanges;
			object originalFormat = Word.WdOriginalFormat.wdWordDocument;
			object routeDocument = true;

			docOpen.Save();
			wrdApp.Visible = true;
			wrdApp.ShowMe();
		}

		public static string GetTitle(DataRow drFilter)
		{
			return drFilter["Title"].ToString().ToUpper();
		}

		public static string GetSubTitle1(DataRow drReport, DataRow drFilter)
		{
			string strDay1 = string.Empty, strDay2 = string.Empty;
			string strMonth1 = string.Empty, strMonth2 = string.Empty;
			string strYear1 = string.Empty, strYear2 = string.Empty;
			string strDate1 = string.Empty, strDate2 = string.Empty;
			if ((string)drReport["SubTitle1"] != string.Empty)
			{
				string strSubTitle1 = (string)drReport["SubTitle1"];

				if (drFilter.Table.Columns.Contains("NGAY_CT1"))
				{
					DateTime dteNgay_Ct1 = (DateTime)drFilter["NGAY_CT1"];

					strDay1 = dteNgay_Ct1.Day.ToString();
					strMonth1 = dteNgay_Ct1.Month.ToString();
					strYear1 = dteNgay_Ct1.Year.ToString();
					strDate1 = dteNgay_Ct1.ToString("dd/MM/yyyy");

					if (strSubTitle1.Contains("DAY(NGAY_CT1)") && strDay1 != string.Empty)
						strSubTitle1 = strSubTitle1.Replace("DAY(NGAY_CT1)", strDay1);

					if (strSubTitle1.Contains("MONTH(NGAY_CT1)") && strMonth1 != string.Empty)
						strSubTitle1 = strSubTitle1.Replace("MONTH(NGAY_CT1)", strMonth1);

					if (strSubTitle1.Contains("YEAR(NGAY_CT1)") && strYear1 != string.Empty)
						strSubTitle1 = strSubTitle1.Replace("YEAR(NGAY_CT1)", strYear1);

					if (strSubTitle1.Contains("DATE(NGAY_CT1)") && strDate1 != string.Empty)
						strSubTitle1 = strSubTitle1.Replace("DATE(NGAY_CT1)", strDate1);
				}

				if (drFilter.Table.Columns.Contains("NGAY_CT2"))
				{
					DateTime dteNgay_Ct2 = (DateTime)drFilter["NGAY_CT2"];

					strDay2 = dteNgay_Ct2.Day.ToString();
					strMonth2 = dteNgay_Ct2.Month.ToString();
					strYear2 = dteNgay_Ct2.Year.ToString();
					strDate2 = dteNgay_Ct2.ToString("dd/MM/yyyy");

					if (strSubTitle1.Contains("DAY(NGAY_CT2)") && strDay2 != string.Empty)
						strSubTitle1 = strSubTitle1.Replace("DAY(NGAY_CT2)", strDay2);

					if (strSubTitle1.Contains("MONTH(NGAY_CT2)") && strMonth2 != string.Empty)
						strSubTitle1 = strSubTitle1.Replace("MONTH(NGAY_CT2)", strMonth2);

					if (strSubTitle1.Contains("YEAR(NGAY_CT2)") && strYear2 != string.Empty)
						strSubTitle1 = strSubTitle1.Replace("YEAR(NGAY_CT2)", strYear2);

					if (strSubTitle1.Contains("DATE(NGAY_CT2)") && strDate2 != string.Empty)
						strSubTitle1 = strSubTitle1.Replace("DATE(NGAY_CT2)", strDate2);
				}

				return strSubTitle1;

			}
			else if (drFilter.Table.Columns.Contains("NGAY_CT1") && drFilter.Table.Columns.Contains("NGAY_CT2"))
			{
				DateTime dteNgay_Ct1 = (DateTime)drFilter["NGAY_CT1"];
				DateTime dteNgay_Ct2 = (DateTime)drFilter["NGAY_CT2"];
				strDay1 = dteNgay_Ct1.Day.ToString();
				strMonth1 = dteNgay_Ct1.Month.ToString();
				strYear1 = dteNgay_Ct1.Year.ToString();
				strDay2 = dteNgay_Ct2.Day.ToString();
				strMonth2 = dteNgay_Ct2.Month.ToString();
				strYear2 = dteNgay_Ct2.Year.ToString();
				if (strDay1 == "1" && strYear1 == strYear2)
				{
					if (strMonth1 == "1" && strMonth2 == "3" && strDay2 == "31")
						return "Quý I Năm " + strYear2;
					else if (strMonth1 == "4" && strMonth2 == "6" && strDay2 == "30")
						return "Quý II Năm " + strYear2;
					else if (strMonth1 == "7" && strMonth2 == "9" && strDay2 == "30")
						return "Quý III Năm " + strYear2;
					else if (strMonth1 == "10" && strMonth2 == "12" && strDay2 == "31")
						return "Quý IV Năm " + strYear2;
					else if (strMonth1 == "1" && strMonth2 == "12" && strDay2 == "31")
						return "Năm " + strYear2;
					else
						return Common.ReadDate((DateTime)drFilter["NGAY_CT1"], (DateTime)drFilter["NGAY_CT2"], Element.sysLanguage);
				}
				return Common.ReadDate((DateTime)drFilter["NGAY_CT1"], (DateTime)drFilter["NGAY_CT2"], Element.sysLanguage);
			}
			else if (drFilter.Table.Columns.Contains("NGAY_CT"))
			{
				return Common.ReadDate((DateTime)drFilter["NGAY_CT"], (DateTime)drFilter["NGAY_CT"], Element.sysLanguage);
			}

			return string.Empty;
		}

		public static string GetSubTitle2(DataRow drReport, DataRow drFilter)
		{
			string strSubTitle = string.Empty;
			string strSubTileList = (string)drReport["SubTitle_List"];

			strSubTileList = strSubTileList.Replace(" ", "");
			if (strSubTileList == string.Empty)
				return string.Empty;

			string[] strArrSubTile = strSubTileList.Split(',');

			Hashtable htFilterInfo = new Hashtable();
			htFilterInfo.Add("REPORT_ID", drReport["Report_ID"]);
			htFilterInfo.Add("REPORT_ID_FILTER", drReport["Report_ID_Filter"]);

			DataTable dtFilterInfo = SQLExec.ExecuteReturnDt("sp_GetReportFilterInfo", htFilterInfo, CommandType.StoredProcedure);

			foreach (string strFilter_ID in strArrSubTile)
			{
				if (!drFilter.Table.Columns.Contains(strFilter_ID) || (string)drFilter[strFilter_ID] == string.Empty)
					continue;

				DataRow[] drArr = dtFilterInfo.Select("Filter_ID = '" + strFilter_ID + "'");
				if (drArr.Length <= 0)
				{
					//15/11/2011: Hải viết tạm cho NBC
					if (strFilter_ID == "ART" || strFilter_ID == "MAU" || strFilter_ID == "SO_TKHAI" || strFilter_ID == "ORDERID") 
					{
						if (strSubTitle == string.Empty)
							strSubTitle = strFilter_ID + ": " + (string)drFilter[strFilter_ID];
						else
							strSubTitle = strSubTitle + "\n" + strFilter_ID + ": " + (string)drFilter[strFilter_ID];
					}

					continue;
				}

				DataRow drFilterInfo = drArr[0];

				string strFilter_ID_Value = (string)drFilter[strFilter_ID];
				string strFilter_Name = (string)drFilterInfo["Filter_Name"];

				//HuanDS Filter_Label lấy từ ngôn ngữ ra
				string strLabel = string.Empty;
				string strLabel0 = RosySystem.Library.Languages.GetLanguage(strFilter_ID);

				if (strLabel0 != strFilter_ID)
					strLabel = strLabel0;
				else
					strLabel = (string)drFilterInfo["Filter_Label"];

				string strTable_Lookup = (string)drFilterInfo["Table_Lookup"];

				DataTable dtLooup = SQLExec.ExecuteReturnDt("SELECT ColumnID_Lookup, ColumnName_Lookup FROM R00LOOKUP WHERE ColumnID = '" + strFilter_ID + "'");
				string strFilter_ID_Lookup = string.Empty;
				string strFilter_Name_Lookup = string.Empty;

				if (dtLooup.Rows.Count >= 1)
				{
					strFilter_ID_Lookup = dtLooup.Rows[0]["ColumnID_Lookup"].ToString();
					strFilter_Name_Lookup = dtLooup.Rows[0]["ColumnName_Lookup"].ToString();
				}
				else
				{
					strFilter_ID_Lookup = strFilter_ID;
					strFilter_Name_Lookup = strFilter_Name;
				}

				DataRow dr = DataTool.SQLGetDataRowByID(strTable_Lookup, strFilter_ID_Lookup, strFilter_ID_Value);

				if (dr == null)
					return string.Empty;

				string strFilter_Name_Value = string.Empty;
				if (Element.sysLanguage == enuLanguageType.English && dr.Table.Columns.Contains(strFilter_Name_Lookup + "E"))
					strFilter_Name_Value = (string)dr[strFilter_Name_Lookup + "E"];
				else
					strFilter_Name_Value = (string)dr[strFilter_Name_Lookup];

				if (strSubTitle == string.Empty)
					strSubTitle = strLabel + ": " + strFilter_ID_Value + " - " + strFilter_Name_Value;
				else
					strSubTitle = strSubTitle + "\n" + strLabel + ": " + strFilter_ID_Value + " - " + strFilter_Name_Value;
			}

			return strSubTitle;
		}

	}
}
