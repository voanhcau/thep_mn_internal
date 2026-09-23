using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataDynamics.ActiveReports;
using DataDynamics;
using DataDynamics.ActiveReports.Export;
using System.Reflection;
using System.Globalization;

using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;

namespace RosyReport
{
	public partial class frmReportPrint : RosySystem.Control.frmBase
	{
		private rptFileReport repFile = new rptFileReport();
		public DataRow drPrintColumnsList;
		public DataRow drReport;
		public DataRow drFilter;
		public DataSet dsResult;
		public DataTable dtDetail;
		public Dictionary<string, ColumnInfo> columnInfos;
		public Dictionary<string, object> dicHeader = new Dictionary<string, object>();

		public bool bPrintSuccess = false;

		//public Assembly asmSystem;
		//public Assembly asmElement;
		//public Assembly asmLibrary;
		//public Assembly asmCommon;
		//public Assembly asmData;
		//public Assembly asmPublic;		

		#region Method

		public frmReportPrint()
		{
			InitializeComponent();

			this.InitReport();

			this.KeyDown += new KeyEventHandler(frmReportPrint_KeyDown);

			//Bi loi khi bop bop cai report
			this.viewReport.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.ContinuousScroll;

			btExport.Click += new EventHandler(btExport_Click);
		}		

		new public bool Load(DataRow drReport, DataRow drFilter, DataSet dsResult, bool bPreview)
		{
			return Load(drReport, drFilter, dsResult, bPreview, true);
		}

		new public bool Load(DataRow drReport, DataRow drFilter, DataSet dsResult, bool bPreview, DataRow drPrintColumnsList)
		{
			this.drPrintColumnsList = drPrintColumnsList;
			return Load(drReport, drFilter, dsResult, bPreview, true);
		}

		new public bool Load(DataRow drReport, DataRow drFilter, DataSet dsResult, bool bPreview, bool bShowDialog)
		{
			this.drReport = drReport;
			this.drFilter = drFilter;
			this.dsResult = dsResult;
			this.dtDetail = dsResult.Tables[0];

			//Tu Filter
			foreach (DataColumn dc in drFilter.Table.Columns)
			{
				if (!dicHeader.ContainsKey(dc.ColumnName.ToUpper()))
					dicHeader[dc.ColumnName.ToUpper()] = drFilter[dc.ColumnName];
			}

			//Tu Report
			foreach (DataColumn dc in drReport.Table.Columns)
			{
				if (!dicHeader.ContainsKey(dc.ColumnName.ToUpper()))
					dicHeader[dc.ColumnName.ToUpper()] = drReport[dc.ColumnName];
			}
			
			//Tu Header (dsResult.Tables[1])
			if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
			{
				DataRow drHeader = dsResult.Tables[1].Rows[0];

				foreach (DataColumn dc in drHeader.Table.Columns)
				{
					dicHeader[dc.ColumnName.ToUpper()] = drHeader[dc.ColumnName];

					if (dc.ColumnName.ToUpper().StartsWith("DOC_TIEN"))
					{
						if (Element.sysLanguage == enuLanguageType.Vietnamese)
							dicHeader[dc.ColumnName.ToUpper()] = Common.ReadMoney(Convert.ToDouble(drHeader[dc.ColumnName]), Element.sysMa_Tte.ToString());
						else
							dicHeader[dc.ColumnName.ToUpper()] = Common.ReadMoneyE(Convert.ToDouble(drHeader[dc.ColumnName]), Element.sysMa_Tte.ToString());
					}
				}
			}

			return Load(dicHeader, dtDetail, bPreview, bShowDialog);
		}

		new public bool Load(DataRow drHeader, DataTable dtDetail, bool bPreview)
		{
			return Load(drHeader, dtDetail, bPreview, true);
		}

		//Load Print cho chứng từ
		new public bool Load(DataRow drHeader, DataTable dtDetail, bool bPreview, bool bShowDialog)
		{
			//Hải kiểm tra tồn tại trường
			if (!drHeader.Table.Columns.Contains("Vnd_Nt"))
			{
				drHeader.Table.Columns.Add(new DataColumn("Vnd_Nt", typeof(string)));

				if (drHeader.Table.Columns.Contains("Is_Vnd"))
					drHeader["Vnd_Nt"] = (bool)drHeader["Is_Vnd"] ? "0" : "1";
				else
					drHeader["Vnd_Nt"] = "0";
			}

			Dictionary<string, object> dicHeader0 = new Dictionary<string, object>();
			dicHeader0["SUBTITLE1"] = Common.ReadDate((DateTime)drHeader["NGAY_CT"], (DateTime)drHeader["NGAY_CT"], Element.sysLanguage);

			foreach (DataColumn dc in drHeader.Table.Columns)
			{
				string strColumnName = dc.ColumnName.ToUpper();
				string strValue = string.Empty;

				dicHeader0.Add(strColumnName, drHeader[strColumnName]);
			}

			return this.Load(dicHeader0, dtDetail, bPreview, bShowDialog);
		}

		new public bool Load(Dictionary<string, object> dicHeader, DataTable dtDetail, bool bPreview)
		{
			return this.Load(dicHeader, dtDetail, bPreview, true);
		}

		new public bool Load(Dictionary<string, object> dicHeader, DataTable dtDetail, bool bPreview, bool bShowDialog)
		{
			this.dicHeader = dicHeader;
			this.dtDetail = dtDetail;

			SetDefault();
			Print();

			if (bPreview)
			{
				if (Form.ActiveForm != null && Form.ActiveForm.Modal)
				{
					this.ShowDialog();
				}
				else
				{
					this.MdiParent = Element.frmMain;
					this.Show();
				}
			}
			else
			{
				if (bShowDialog)
				{
					return viewReport.Document.Print(true, true);
				}
				else
				{
					return viewReport.Document.Print(false, true);
				}
			}

			return true;
		}

		private void SetDefault()
		{
			dicHeader["TEN_DV_CQ"] = (string)Parameters.GetParaValue("TEN_DV_CQ");
			//dicHeader["TEN_DV"] = RosySystem.Element.Element.sysTen_Dvi.ToUpper();
            dicHeader["TEN_DV"] = DataTool.SQLGetNameByCode("R00DMDVCS", "Ma_Dvcs", "Ten_Dvcs", Element.sysMa_DvCs);//MungLV
			//dicHeader["DIA_CHI_DV"] = (string)Parameters.GetParaValue("DIA_CHI");
			dicHeader["DIA_CHI_DV"] = Element.sysDia_Chi_Dv; //Hải chuyển lưu Địa chỉ vào R00DmDvCs
			//dicHeader["MAU_SO"] = "Mẫu số: 01-TT";
            if (dicHeader.ContainsKey("NGAY_CT") && Convert.ToDateTime(this.dicHeader["NGAY_CT"]) >= Library.StrToDate("01/01/2015"))
            {
                this.dicHeader["QUYET_DINH"] = "(Ban h\x00e0nh theo theo th\x00f4ng tư số 200/2014/TT-BTC\n Ng\x00e0y 22/12/2014 của Bộ T\x00e0i Ch\x00ednh)";
            }
            else
            {
                this.dicHeader["QUYET_DINH"] = "(Ban h\x00e0nh theo QĐ số: 15/2006/QĐ-BTC\n Ng\x00e0y 20 th\x00e1ng 03 năm 2006\n của Bộ trưởng BTC)";
            }

			//Hải thêm khai báo Ten_DV_CQ trong Danh mục Dơn vị cơ sở
			if (DataTool.SQLCheckExist("INFORMATION_SCHEMA.COLUMNS", new string[] { "Table_Name", "Column_Name" }, new string[] { "R00DmDvCs", "Ten_Dv_CQ" }))
				dicHeader["TEN_DV_CQ"] = SQLExec.ExecuteReturnValue("SELECT Ten_Dv_CQ FROM R00DmDvCs WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "'").ToString();
		}

		private void Print()
		{
			//Hải kiểm tra tồn tại trường
			if (drReport != null && !drReport.Table.Columns.Contains("Vnd_Nt"))
			{
				drReport.Table.Columns.Add(new DataColumn("Vnd_Nt", typeof(string)));

				if (drReport.Table.Columns.Contains("Is_Vnd"))
					drReport["Vnd_Nt"] = (bool)drReport["Is_Vnd"] ? "0" : "1";
				else
					drReport["Vnd_Nt"] = "0";
			}

			string strRepFile = string.Empty;

			if (drReport != null)
			{
				if ((string)drReport["Vnd_Nt"] == "2")
					strRepFile = (string)dicHeader["REPORT_FILE"] + "_NT";
				else
					strRepFile = (string)dicHeader["REPORT_FILE"];
			}
			else
				strRepFile = (string)dicHeader["REPORT_FILE"];

			strRepFile += ".rpx";

			string strFileName = Application.StartupPath + @"\Report\" + strRepFile;
			if (!System.IO.File.Exists(strFileName))
			{
				Common.MsgCancel("File :{" + strFileName + "} " + Languages.GetLanguage("NOT_FOUND"));
				return;
			}

			//Hải đặt Culture
			CultureInfo cti_current = Application.CurrentCulture;
			CultureInfo cti = new CultureInfo("vi-VN");

			if (drReport != null && drReport["Report_ID"].ToString().StartsWith("TX")) //Hải sửa riêng cho VNS: Không đặt Culture đối với báo cáo Taxi
				Application.CurrentCulture = Application.CurrentCulture;
			else
				Application.CurrentCulture = cti;
			//

			repFile.LoadLayout(strFileName);

			repFile.PageSettings.Margins.Left = 0F;
			repFile.PageSettings.Margins.Bottom = 0F;
			repFile.PageSettings.Margins.Left = 0F;
			repFile.PageSettings.Margins.Right = 0F;

			if (dtDetail.DefaultView != null)
				repFile.DataSource = dtDetail.DefaultView;
			else
				repFile.DataSource = dtDetail;

			FillHeaderAndFooterInfo();

			repFile.Run();
			viewReport.Document = repFile.Document;

			Application.CurrentCulture = cti_current; //Trả về Culture cũ

			this.Text = this.Text + " - " + strRepFile;
		}

		void InitReport()
		{
			//repFile.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");

			repFile.AddAssembly(Assembly.Load("Rosy.System"));
			repFile.AddAssembly(Assembly.Load("Rosy.System.Element"));
			repFile.AddAssembly(Assembly.Load("Rosy.System.Library"));
			repFile.AddAssembly(Assembly.Load("Rosy.System.Common"));
			repFile.AddAssembly(Assembly.Load("Rosy.System.Data"));
			repFile.AddAssembly(Assembly.Load("Rosy.System.Public"));
		}

		//Điền dữ liệu vào Header & Footer
		private void FillHeaderAndFooterInfo()
		{
			//Điền dữ liệu vào ReportHeader
			foreach (ARControl arCtrl in repFile.reportHeader.Controls)
			{
				if (arCtrl.GetType().Name == "Label") //Label
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();
					//if (dicHeader.ContainsKey(strDataField) && dicHeader[strDataField] != string.Empty)
					if (dicHeader.ContainsKey(strDataField))
						((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField].ToString();
					else
						((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
				}
				else if (arCtrl.GetType().Name == "TextBox") //TextBox
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();

					((DataDynamics.ActiveReports.TextBox)arCtrl).Value = dicHeader[strDataField];
				}
			} 

			//Điền dữ liệu vào PageHeader
			foreach (ARControl arCtrl in repFile.pageHeader.Controls)
			{
				if (arCtrl.GetType().Name == "Label") //Label
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();
					if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
						((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField].ToString();
					else
					{
						// Khiem them dieu kien hien thi ngon ngu Other
						if (Element.sysLanguage == enuLanguageType.Other)
							((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField,enuLanguageType.Other);
						else
							((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
					}
				}
				else if (arCtrl.GetType().Name == "TextBox") //TextBox
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();

					((DataDynamics.ActiveReports.TextBox)arCtrl).Value = dicHeader[strDataField];
				}
			}

			//Điền dữ liệu vào ReportFooter
			foreach (ARControl arCtrl in repFile.reportFooter.Controls)
			{
				if (arCtrl.GetType().Name == "Label") //Label
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();
					if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
					{
						if (strDataField.Contains("SIGN1") && Element.sysLanguage == enuLanguageType.English)
							((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE1"].ToString();
						else if (strDataField.Contains("SIGN1") && Element.sysLanguage == enuLanguageType.Other)//Sing1 tieng Other
							((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNO1"].ToString();
						else if (strDataField.Contains("SIGN2") && Element.sysLanguage == enuLanguageType.English)
							((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE2"].ToString();
						else if (strDataField.Contains("SIGN2") && Element.sysLanguage == enuLanguageType.Other)//Sing2 tieng Other
							((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNO2"].ToString();
						else if (strDataField.Contains("SIGN3") && Element.sysLanguage == enuLanguageType.English)
							((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE3"].ToString();
						else if (strDataField.Contains("SIGN3") && Element.sysLanguage == enuLanguageType.Other)//Sing3 tieng Other
							((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNO3"].ToString();
						else
							((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField].ToString();
					}
					else
						((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
				}
				else if (arCtrl.GetType().Name == "TextBox") //TextBox
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();

					((DataDynamics.ActiveReports.TextBox)arCtrl).Value = dicHeader[strDataField];
				}
				else if (arCtrl.GetType().Name == "Picture") //PictureBox
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();

					if (dicHeader[strDataField] != DBNull.Value)
						((DataDynamics.ActiveReports.Picture)arCtrl).Image = new Bitmap(System.Drawing.Image.FromStream(new MemoryStream((Byte[])dicHeader[strDataField])));
				}
			}

			//Điền dữ liệu vào PageFooter
			foreach (ARControl arCtrl in repFile.pageFooter.Controls)
			{
				if (arCtrl.GetType().Name == "Label")
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();
					if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
						((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField].ToString();
					else
						((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
				}
				else if (arCtrl.GetType().Name == "TextBox") //TextBox
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();

					((DataDynamics.ActiveReports.TextBox)arCtrl).Value = dicHeader[strDataField];
				}
			}

			//Điền dữ liệu vào GroupHeader
			foreach (ARControl arCtrl in repFile.groupHeader1.Controls)
			{
				if (arCtrl.GetType().Name == "Label")
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();
					if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
						((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField].ToString();
					else
						((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
				}
				else if (arCtrl.GetType().Name == "TextBox") //TextBox
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();

					((DataDynamics.ActiveReports.TextBox)arCtrl).Value = dicHeader[strDataField];
				}
			}

			//Điền dữ liệu vào GroupFooter
			foreach (ARControl arCtrl in repFile.groupFooter1.Controls)
			{
				if (arCtrl.GetType().Name == "Label")
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();
					if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
						((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField].ToString();
					else
						((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
				}
				else if (arCtrl.GetType().Name == "TextBox") //TextBox
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();

					((DataDynamics.ActiveReports.TextBox)arCtrl).Value = dicHeader[strDataField];
				}
			}

			foreach (ARControl arCtrl in repFile.detail.Controls)
			{
				if (arCtrl.GetType().Name == "TextBox")
				{
					if (arCtrl.DataField == null || (string)arCtrl.DataField == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.DataField).ToUpper();

					if (strDataField.ToUpper() == "CHI_TIEU" && Element.sysLanguage == enuLanguageType.English && dtDetail.Columns.Contains("CHI_TIEUE"))
						arCtrl.DataField = "CHI_TIEUE";

					if (strDataField.ToUpper() == "CHI_TIEU" && Element.sysLanguage == enuLanguageType.Other && dtDetail.Columns.Contains("CHI_TIEUO"))
						arCtrl.DataField = "CHI_TIEUO";

					else if (strDataField.ToUpper() == "TEN_TK" && Element.sysLanguage == enuLanguageType.English && dtDetail.Columns.Contains("TEN_TKE"))
						arCtrl.DataField = "TEN_TKE";

					else if (strDataField.ToUpper() == "TEN_TK" && Element.sysLanguage == enuLanguageType.Other && dtDetail.Columns.Contains("TEN_TKC"))
						arCtrl.DataField = "TEN_TKC";
				}
			}

			// Xu ly trong truong hop in nhieu lan
			#region
			if (drPrintColumnsList != null)
			{
				string[] strArrColumnPrintList = ((string)drPrintColumnsList["ColumnPrintList"]).Replace(" ", "").Split(',');
				string[] strArrColumnDetailList = ((string)drPrintColumnsList["ColumnDetailList"]).Replace(" ", "").Split(',');

				Dictionary<string, string> dic = new Dictionary<string, string>();

				for (int i = 0; i <= strArrColumnDetailList.Length - 1; i++)
				{
					dic[strArrColumnDetailList[i].ToUpper()] = strArrColumnPrintList[i].ToUpper();
				}

				foreach (ARControl arCtrl in repFile.detail.Controls)
				{
					if (arCtrl.GetType().Name == "TextBox")
					{
						if (arCtrl.DataField == null || (string)arCtrl.DataField == string.Empty)
							continue;

						if (dic.ContainsKey(arCtrl.Name.Substring(3).ToUpper()))
							arCtrl.DataField = dic[arCtrl.Name.Substring(3).ToUpper()];
						else
							((DataDynamics.ActiveReports.TextBox)arCtrl).Text = string.Empty;
					}
				}

				foreach (ARControl arCtrl in repFile.pageHeader.Controls)
				{
					if (arCtrl.GetType().Name == "Label")
					{
						if (dic.ContainsKey(arCtrl.Name.Substring(3).ToUpper()))
							((DataDynamics.ActiveReports.Label)arCtrl).Text = RosySystem.Library.Languages.GetLanguage(dic[arCtrl.Name.Substring(3).ToUpper()]);
						else if (arCtrl.Name.ToUpper().StartsWith("LBL"))
							((DataDynamics.ActiveReports.Label)arCtrl).Text = string.Empty;
					}
				}
			}

			#endregion

			#region Đổi trường ngoại tệ
			if (drReport != null && (string)drReport["Vnd_Nt"] == "1")
			{
				//Label
				foreach (ARControl arCtrl in repFile.pageHeader.Controls)
				{
					if (arCtrl.GetType().Name == "Label")
					{
						if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
							continue;

						string strDataField = ((string)arCtrl.Tag).ToUpper();
						if (strDataField.Contains("TIEN") || strDataField.Contains("PS_") || strDataField.Contains("DU_") || strDataField.Contains("GIA"))
							strDataField = strDataField + "_NT";

						//if (dicHeader.ContainsKey(strDataField) && dicHeader[strDataField] != string.Empty)
						if (dicHeader.ContainsKey(strDataField))
							((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField].ToString();
						else
							((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
					}
				}

				//TextBox
				foreach (ARControl arCtrl in repFile.detail.Controls)
				{
					if (arCtrl.GetType().Name == "TextBox")
					{
						if (arCtrl.Tag != null && arCtrl.Tag.ToString() != string.Empty)
							arCtrl.DataField = arCtrl.Tag.ToString();

						string strkey = (string)drReport["Report_ID"] + "." + arCtrl.DataField.ToUpper();
						if (columnInfos != null && columnInfos.ContainsKey(strkey) && columnInfos[strkey].Type == enuColumnType.Numeric)
						{
							ColumnInfo columnInfo = columnInfos[strkey];
							if (columnInfo.Scale == 0)
								((DataDynamics.ActiveReports.TextBox)arCtrl).OutputFormat = "#,##0";
							else
								((DataDynamics.ActiveReports.TextBox)arCtrl).OutputFormat = "#,##0." + "0".PadLeft(columnInfo.Scale, '0');
						}
					}
				}
			}
			#endregion
		}

		public void Export()
		{
			string strTitle = this.Text;
			frmExport frm = new frmExport();

			//frm.chkKetXuatDinhDang.Visible = false;
			frm.chkOpenFile.Visible = false;

			frm.Load(strTitle);

			if (!frm.isAccept)
				return;

			string strPath = frm.strPath;
			string strExportType = frm.cboExportType.Text;

			switch (strExportType.Substring(0, 1))
			{
				case "1": //enuExportType.Excel:
					DataDynamics.ActiveReports.Export.Xls.XlsExport xlsExport = new DataDynamics.ActiveReports.Export.Xls.XlsExport();
					//xlsExport.MinRowHeight = 1;
					//xlsExport.MultiSheet = true;
					//xlsExport.RemoveVerticalSpace = true;
					xlsExport.UseCellMerging = false;
					xlsExport.MinColumnWidth = 0.25f;
					xlsExport.FileFormat = DataDynamics.ActiveReports.Export.Xls.FileFormat.Xls97Plus;
					xlsExport.AutoRowHeight = true;
					xlsExport.DisplayGridLines = true;
					repFile.pageHeader.Visible = true;

					repFile.PageEnd += new EventHandler(repFile_PageEnd);
					repFile.pageFooter.Visible = false;

					repFile.DataSource = dtDetail.DefaultView;
					repFile.Run();
					viewReport.Document = repFile.Document;

					xlsExport.Export(repFile.Document, strPath);

					repFile.pageFooter.Visible = true;
					repFile.pageFooter.Visible = true;

					break;
				case "2": //enuExportType.Word:
					DataDynamics.ActiveReports.Export.Rtf.RtfExport rftExport = new DataDynamics.ActiveReports.Export.Rtf.RtfExport();
					rftExport.Export(repFile.Document, strPath);
					break;

				case "3":	//enuExportType.PDF:

					DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
					pdfExport.Export(repFile.Document, strPath);
					break;

				case "4": //enuExportType.Html:
					DataDynamics.ActiveReports.Export.Html.HtmlExport htmlExport = new DataDynamics.ActiveReports.Export.Html.HtmlExport();
					htmlExport.Export(repFile.Document, strPath);
					break;

			}

			if (File.Exists(strPath) && frm.chkOpenFile.Checked)
				Process.Start(strPath);
		}

		void repFile_PageEnd(object sender, EventArgs e)
		{
			repFile.pageHeader.Visible = false;
			repFile.PageEnd -= new EventHandler(repFile_PageEnd);
		}		

		#endregion

		#region Events

		void frmReportPrint_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					return;

				case Keys.F3:
					return;

				default:
					break;
			}

			if (e.Control && e.KeyCode == Keys.E)
				Export();
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);

			this.viewReport.Focus();
		}

		void btExport_Click(object sender, EventArgs e)
		{
			Export();
		}

		#endregion		

		public class rsReportViewer : DataDynamics.ActiveReports.Viewer.Viewer
		{
			public rsReportViewer()
			{
				
			}

			protected override void OnPrint(PaintEventArgs e)
			{
				try
				{
					base.OnPrint(e);

					if (this.ParentForm != null && this.ParentForm.Name == "frmReportPrint")
					{
						((frmReportPrint)this.ParentForm).bPrintSuccess = true;
					}
				}
				catch (Exception)
				{
					if (this.ParentForm != null && this.ParentForm.Name == "frmReportPrint")
					{
						((frmReportPrint)this.ParentForm).bPrintSuccess = false;
					}

					throw;
				}
			}
		}
	}
}