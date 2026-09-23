using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using DataDynamics.ActiveReports;

using RosySystem;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Customize;
using RosySystem.Element;

namespace RosyReport
{
	public partial class frmReportResult : RosySystem.Control.frmBase
	{
		#region Variable
		private int iPrintTime = 0;
		private DataTable dtDetail;
		private DataTable dtHeader;
		private DataSet dsResult;

		private BindingSource bdsResult = new BindingSource();
		private dgvReport dgvResult;
		private rsTreeListReport tlResult;

		//Các thuộc tính tìm kiếm
		public frmSearch frmsearch = new frmSearch();

		private DataRow drReport;
		private DataRow drFilter;

		string strVnd_Nt = "0";

		ucChart chart1 = new ucChart();

		#endregion

		#region Method

		public frmReportResult()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmResult_KeyDown);
			this.KeyPreview = true;

			this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
		}

		public void Load(DataRow drReport, DataRow drFilter)
		{
			this.drReport = drReport;
			this.drFilter = drFilter;
			this.strVnd_Nt = (string)drReport["Vnd_Nt"];

			if (drReport.Table.Columns.Contains("Title"))
				this.Text = (string)drReport["Title"];

			//Hải thêm phục vụ cho in tk trên form View
			if (drFilter.Table.Columns.Contains("Tk") && drFilter["Tk"].ToString() != "")
				this.Text = this.Text + " - " + drFilter["Tk"].ToString();
            
            //Bằng thêm phân quyền báo cáo xem theo kho
            if (!drFilter.Table.Columns.Contains("USER_LOGIN"))
            {
                drFilter.Table.Columns.Add("USER_LOGIN");
                drFilter["USER_LOGIN"] = Element.sysUser_Id;
            }
            this.Text = this.Text + " (" + Languages.GetLanguage("F7") + ", " + Languages.GetLanguage("F12") + ", " + Languages.GetLanguage("ESC") + ")";

			this.Build();
			this.FillData();

			//Hải Build lưới cho trường hợp Auto_Build
			if ((bool)drReport["Auto_Build"])
			{
				System.Collections.Hashtable htParameter = new System.Collections.Hashtable();
				htParameter.Add("REPORT_ID", (string)drReport["Report_ID"]);
				htParameter.Add("REPORT_ID_INFO", (string)drReport["Report_ID_Info"]);

				DataTable dtReportInfo = SQLExec.ExecuteReturnDt("sp_GetReportInfo", htParameter, CommandType.StoredProcedure);

				foreach (DataGridViewColumn dgvc in dgvResult.Columns)
				{
					if (dtDetail.Columns.Contains(dgvc.DataPropertyName) && (dtDetail.Columns[dgvc.DataPropertyName].DataType == typeof(double) || dtDetail.Columns[dgvc.DataPropertyName].DataType == typeof(decimal) || dtDetail.Columns[dgvc.DataPropertyName].DataType == typeof(int)))
					{
						dgvc.DefaultCellStyle.Format = dgvc.DataPropertyName.EndsWith("_NT") ? "N2" : "N0";
						dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					}

					DataRow[] drArrdtReportInfo = dtReportInfo.Select("Column_ID = '" + dgvc.DataPropertyName + "'");
					if (drArrdtReportInfo.Length == 1)
					{
						dgvc.Width = Convert.ToInt32(drArrdtReportInfo[0]["Width"]);
					}
				}
			}

			this.Show();
		}

		void Build()
		{
			if ((string)drReport["Report_Control"] == "G")
			{
				dgvResult = new dgvReport();
				dgvResult.ReadOnly = true;
				dgvResult.Dock = DockStyle.Fill;
				dgvResult.drReport = drReport;
				dgvResult.bVnd_Nt = strVnd_Nt == "0"? true: false;
				dgvResult.strVnd_Nt = (string)drReport["Vnd_Nt"];
				dgvResult.Parent = this;

				if (!(bool)drReport["Auto_Build"])
				{
					dgvResult.strZone = (string)drReport["Report_ID"];
					dgvResult.BuildGridViewReport();
				}
				else
				{
					dgvResult.AutoGenerateColumns = true;
					dgvResult.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
				}

				dgvResult.MouseDoubleClick += new MouseEventHandler(dgvResult_MouseDoubleClick);

				this.tpReport_Result.Controls.Add(dgvResult);
			}
			else
			{
				tlResult = new rsTreeListReport();
				tlResult.Dock = DockStyle.Fill;
				tlResult.drReport = drReport;
				tlResult.bVnd_Nt = strVnd_Nt == "0" ? true : false;
				tlResult.strZone = (string)drReport["Report_ID"];
				tlResult.BuildTreeListReport();
				tlResult.Parent = this;

				tlResult.MouseDoubleClick += new MouseEventHandler(tlResult_MouseDoubleClick);

				this.tpReport_Result.Controls.Add(tlResult);
			}

			//Chart
			chart1.Dock = DockStyle.Fill;
			this.tpChart.Controls.Add(chart1);
		}

		private void FillData()
		{
			string strSQLProc = (string)drReport["SQLProc"];

			dsResult = SQLExec.ExecuteReturnDs(strSQLProc, drFilter, CommandType.StoredProcedure);

			dtDetail = dsResult.Tables[0];
			dtHeader = dsResult.Tables.Count > 1 ? dsResult.Tables[1] : null;

			//Hải kiểm tra phân quyền truy cập giá ACCESS_GIA
			if (DataTool.SQLCheckExist("R00Object", "Object_ID", "ACCESS_PRICE") && !Common.CheckPermission("ACCESS_PRICE", enuPermission_Type.Allow_Access))
			{
				foreach (DataColumn dc in dtDetail.Columns)
				{
					if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TIEN") || dc.ColumnName.StartsWith("PS_NO") || dc.ColumnName.StartsWith("PS_CO") || dc.ColumnName.StartsWith("PS_TANG") || dc.ColumnName.StartsWith("PS_GIAM") || dc.ColumnName.StartsWith("DU_DAU") || dc.ColumnName.StartsWith("DU_CUOI") || dc.ColumnName.StartsWith("DU_NO") || dc.ColumnName.StartsWith("DU_CO"))
					{
						if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
						{
							//Gán cột dữ liệu về 0
							foreach (DataRow dr in dtDetail.Rows)
							{
								dr[dc] = 0;
							}

							//Ẩn cột dữ liệu
							if (dgvResult.Columns.Contains(dc.ColumnName))
								dgvResult.Columns[dc.ColumnName].Visible = false;
						}
					}
				}
			}

			//Hải: xuất hiện thông điệp lỗi
			if (dtHeader != null) 
			{
				if (dtHeader.Rows.Count == 1 && dtHeader.Columns.Contains("Error_Msg"))
				{
					string strError_Msg = (string)dtHeader.Rows[0]["Error_Msg"];

					if (strError_Msg != string.Empty)
						Common.MsgCancel(strError_Msg);
				}
			}

			bdsResult.DataSource = dtDetail;

			foreach (DataGridViewColumn dgvc in dgvResult.Columns)
				if (!dtDetail.Columns.Contains(dgvc.DataPropertyName))
				{
					dgvc.Width = 0;
					dgvc.Visible = false;

				}

			if (dgvResult.Columns.Contains("CHI_TIEU") && Element.sysLanguage == enuLanguageType.English && dtDetail.Columns.Contains("CHI_TIEUE"))
				dgvResult.Columns["CHI_TIEU"].DataPropertyName = "CHI_TIEUE";

			if (dgvResult.Columns.Contains("CHI_TIEU") && Element.sysLanguage == enuLanguageType.Other && dtDetail.Columns.Contains("CHI_TIEUO"))
				dgvResult.Columns["CHI_TIEU"].DataPropertyName = "CHI_TIEUO";
			else if (dgvResult.Columns.Contains("CHI_TIEU") && Element.sysLanguage == enuLanguageType.Other && dtDetail.Columns.Contains("CHI_TIEUC"))
				dgvResult.Columns["CHI_TIEU"].DataPropertyName = "CHI_TIEUC";

			if (dgvResult.Columns.Contains("TEN_TK") && Element.sysLanguage == enuLanguageType.English && dtDetail.Columns.Contains("TEN_TKE"))
				dgvResult.Columns["TEN_TK"].DataPropertyName = "TEN_TKE";

			if (dgvResult.Columns.Contains("TEN_TK") && Element.sysLanguage == enuLanguageType.Other && dtDetail.Columns.Contains("TEN_TKO"))
				dgvResult.Columns["TEN_TK"].DataPropertyName = "TEN_TKO";

			if ((string)drReport["Report_Control"] == "G")
			{
				dgvResult.DataSource = bdsResult;
				ExportControl = dgvResult;
			}
			else
			{
				tlResult.DataSource = bdsResult;
				ExportControl = tlResult;
			}

			frmsearch.bdsSearch = bdsResult;

			if ((bool)drReport["Auto_Build"])
			{
				this.BindingLanguage();

				foreach (DataGridViewColumn dgvc in dgvResult.Columns)
				{
					if (dgvc.DataPropertyName == "BOLD" || dgvc.DataPropertyName == "STATUS")
					{
						dgvResult.Columns[dgvc.DataPropertyName].Visible = false;

					}
					else if (dgvc.DataPropertyName == "DIEN_GIAI")
						dgvc.Width = 300;
					else if (dgvc.DataPropertyName == "CHI_TIEU")
						dgvc.Width = 300;
					else if (dgvc.DataPropertyName == "CHI_TIEUE")
						dgvc.Width = 300;
					else if (dgvc.DataPropertyName == "CHI_TIEUO")
						dgvc.Width = 300;

					else if (Common.Inlist(dtDetail.Columns[dgvc.DataPropertyName].DataType.ToString(), "System.Boolean,System.Byte,System.Int16,System.Int32,System.Int64,System.Decimal,System.Double"))
						dgvc.DefaultCellStyle.Format = "N2";
				}
			}

			//Hải: Gán caption cho những cột
			if (dtHeader != null)
			{
				foreach (DataColumn dc in dtHeader.Columns)
				{
					if (dc.ColumnName.StartsWith("LABEL_"))
					{
						string strColumnName = dc.ColumnName.Substring(6);

						if (dgvResult.Columns.Contains(strColumnName))
						{
							dgvResult.Columns[strColumnName].HeaderText = dtHeader.Rows[0][dc].ToString();
						}
					}
				}
			}

			if ((bool)drReport["Auto_Build"])
				dgvResult.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
		}

		public void PreviewReport()
		{
			frmReportPrint frmPrint = new frmReportPrint();
			frmPrint.MdiParent = this.MdiParent;
			frmPrint.columnInfos = dgvResult.ColumnInfos;

			if (dsResult.Tables.Count >= 3 && dsResult.Tables[2].Rows.Count > 0)
			{
				if (iPrintTime <= dsResult.Tables[2].Rows.Count - 1)
				{
					frmPrint.Load(drReport, drFilter, dsResult, true, dsResult.Tables[2].Rows[iPrintTime]);
					frmPrint.FormClosed += new FormClosedEventHandler(frmPreview_FormClosed);
				}
				else
				{
					frmPrint.FormClosed -= new FormClosedEventHandler(frmPreview_FormClosed);
					iPrintTime = 0;
				}
			}
			else
				frmPrint.Load(drReport, drFilter, dsResult, true);
		}

		public void PrintReport()
		{
			frmReportPrint frmPrint = new frmReportPrint();
			frmPrint.MdiParent = this.MdiParent;
			frmPrint.columnInfos = dgvResult.ColumnInfos;

			if (dsResult.Tables.Count >= 3 && dsResult.Tables[2].Rows.Count > 0)
			{
				if (iPrintTime <= dsResult.Tables[2].Rows.Count - 1)
				{
					frmPrint.Load(drReport, drFilter, dsResult, false, dsResult.Tables[2].Rows[iPrintTime]);
					frmPrint.FormClosed += new FormClosedEventHandler(frmPrint_FormClosed);
				}
				else
				{
					frmPrint.FormClosed -= new FormClosedEventHandler(frmPrint_FormClosed);
					iPrintTime = 0;
				}
			}
			else
				frmPrint.Load(drReport, drFilter, dsResult, false);
		}

		void frmPrint_FormClosed(object sender, FormClosedEventArgs e)
		{
			iPrintTime++;
			PrintReport();
		}

		void frmPreview_FormClosed(object sender, FormClosedEventArgs e)
		{
			iPrintTime++;
			PreviewReport();
		}

		public void DesignReport()
		{
			frmReportDesign frmDesign = new frmReportDesign();
			frmDesign.MdiParent = this.MdiParent;
			frmDesign.Load(drReport, dtDetail);
		}

		public void RunChart()
		{
			if ((bool)drReport["Have_Chart"])
			{
				frmChart frm = new frmChart();
				frm.MdiParent = this.MdiParent;
				frm.Load(drReport, drFilter, dtDetail, dgvResult);
			}
		}

		public void RunRefresh()
		{
			this.FillData();
		}

		private void ViewDetail()
		{
			if (bdsResult.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsResult.Current).Row;
			string strReport_ID = (string)drReport["Report_ID"];

			DataTable dtReportDetail = DataTool.SQLGetDataTable("R00REPORTDETAIL", "Report_Detail_ID, Condition", "Report_ID = '" + strReport_ID + "'", "");

			if (dtReportDetail.Rows.Count == 0 && (string)drReport["Report_ID_Detail"] != string.Empty)
			{
				strReport_ID = (string)drReport["Report_ID_Detail"];
				dtReportDetail = DataTool.SQLGetDataTable("R00REPORTDETAIL", "Report_Detail_ID, Condition", "Report_ID = '" + strReport_ID + "'", "");
			}

			//Nếu không vào chi tiết thì F3 chứng từ gốc
			if (dtReportDetail.Rows.Count == 0)
			{
				this.Edit();
				return;
			}

			string strCondition = string.Empty;
			string strReport_Detail_ID = string.Empty;
			foreach (DataRow dr in dtReportDetail.Rows)
			{
				strCondition = (string)dr["CONDITION"];

				DataTable dtTemp = dtDetail.Clone();
				dtTemp.ImportRow(drCurrent);

				if ((dtTemp.Select(strCondition)).Length == 1)
				{
					strReport_Detail_ID = (string)dr["Report_Detail_ID"];
					DataRow drReportDetail = DataTool.SQLGetDataRowByID("R00REPORT", "Report_ID", strReport_Detail_ID);
					drReportDetail["Vnd_Nt"] = drReport["Vnd_Nt"];

					DataRow drReportDetail0 = DataTool.SQLGetDataRowByID("R00ReportDetail", "Report_ID", strReport_Detail_ID);
					DataRow drFilterDetail = drFilter.Table.NewRow();
					DataTool.CopyDataRow(drFilter, drFilterDetail);

					Common.SetDefaultDataRow(ref drReportDetail);
					Common.SetDefaultDataRow(ref drFilterDetail);

					//Đưa dữ liệu trên dòng hiện hành vào Filter
					foreach (DataColumn dc in drFilterDetail.Table.Columns)
					{
						if (dc.DataType == typeof(string) && drCurrent.Table.Columns.Contains(dc.ColumnName))
							if (drCurrent.Table.Columns[dc.ColumnName].DataType == typeof(string))
								drFilterDetail[dc.ColumnName] = (string)drCurrent[dc.ColumnName];
					}

					drFilterDetail["Title"] = Report.GetTitle(drReportDetail);
					drFilterDetail["SubTitle1"] = Report.GetSubTitle1(drReportDetail, drFilterDetail);
					drFilterDetail["SubTitle2"] = Report.GetSubTitle2(drReportDetail, drFilterDetail);
                    //drFilterDetail["SubTitle3"] = Report.GetSubTitle3(drReportDetail, drFilterDetail);

					Report.ViewDetail(drReportDetail, drFilterDetail, drCurrent, this.MdiParent);
				}
			}
		}

		public void Edit()
		{
			if (bdsResult.Position < 0)
				return;

			if (!dtDetail.Columns.Contains("Stt") || !dtDetail.Columns.Contains("Ma_Ct"))
				return;

			DataRow drCurrent = ((DataRowView)bdsResult.Current).Row;

			if (((string)drCurrent["Stt"]).Trim() == string.Empty || ((string)drCurrent["Ma_Ct"]).Trim() == string.Empty)
				return;

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);

			string strMethodName = (string)drDmCt["Edit_Voucher_Method"];

			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				Common.MsgCancel("Định dạng MethodName = " + strMethodName + " không đúng");
				return;
			}

			string strAssembly = arrStr[0];
			string strType = arrStr[1];

			Assembly asl = Assembly.Load(strAssembly);
			Type type = asl.GetType(strType);

			Form frm = (Form)Activator.CreateInstance(type);

			object[] objPara = new object[] { enuEdit.Edit, drCurrent, null };

			type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, objPara);
		}

		public void EditHanTt()
		{
			if (bdsResult.Count <= 0)
				return;

			string strStt = string.Empty;
			string strTk = string.Empty;
			string strMa_Dt = string.Empty;
			DateTime dtNgay_Ct = DateTime.MinValue;

			DataRow drCurrent = ((DataRowView)bdsResult.Current).Row;

			if (!dtDetail.Columns.Contains("Stt") || (string)drCurrent["Stt"] == string.Empty)
				return;

			strStt = (string)drCurrent["Stt"];

			if (!dtDetail.Columns.Contains("Tk") || (string)drCurrent["Tk"] == string.Empty)
				return;

			strTk = (string)drCurrent["Tk"];
			string strTkHanTtList = (string)Parameters.GetParaValue("TK_HANTT_LIST");

			if (!Common.InlistLike(strTk, strTkHanTtList))
				return;

			if (dtDetail.Columns.Contains("Ma_Dt"))
				strMa_Dt = (string)drCurrent["Ma_Dt"];

			if (dtDetail.Columns.Contains("Ngay_Ct"))
				dtNgay_Ct = (DateTime)drCurrent["Ngay_Ct"];

			string strAssembly = "Rosy.Module";
			string strType = "RosyModule.frmHanTt_View";

			Assembly asl = Assembly.Load(strAssembly);
			Type type = asl.GetType(strType);

			Form frm = (Form)Activator.CreateInstance(type);
			frm.MdiParent = this.MdiParent;

			object[] objPara = new object[] { dtNgay_Ct, strTk, strMa_Dt, strStt, "" };

			type.InvokeMember("Load", BindingFlags.InvokeMethod, null, frm, objPara);
		}

		public void Export() //Phục vụ cho việc gọi Assemply từ ToolStrip
		{
			if (ExportControl == null)
				return;

			string strSubtitle = string.Empty;

			if (drFilter.Table.Columns.Contains("SubTitle1") && ((string)drFilter["SubTitle1"]) != string.Empty)
				strSubtitle += (string)drFilter["SubTitle1"] + "|";

			if (drFilter.Table.Columns.Contains("SubTitle2") && ((string)drFilter["SubTitle2"]) != string.Empty)
				strSubtitle += (string)drFilter["SubTitle2"] + "|";

            //if (drFilter.Table.Columns.Contains("SubTitle3") && ((string)drFilter["SubTitle3"]) != string.Empty)
            //    strSubtitle += (string)drFilter["SubTitle3"] + "|";

			string strTitle = Element.sysLanguage == enuLanguageType.Vietnamese ? (string)drReport["Title"] : (string)drReport["TitleE"];
			Common.Export(ExportControl, strTitle, strSubtitle);
		}

		#endregion

		#region Event

		void frmResult_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					Edit();
					break;

                case Keys.F9:
                    RunRefresh();
                    break;
				
                case Keys.F10:
					RunChart();
					break;

				case Keys.F11:
					if (Assembly.Load("Rosy.Module").GetType("RosyModule.Voucher").GetMethod("HanTt1") != null)
					{
						Assembly asl = Assembly.Load("Rosy.Module");
						Type type = asl.GetType("RosyModule.Voucher");
						MethodInfo methodInfo = type.GetMethod("HanTt1");

						object[] parametersArray = new object[] { ((DataRowView)bdsResult.Current).Row };

						methodInfo.Invoke(methodInfo, parametersArray);
					}
					else
						EditHanTt();

					break;

				case Keys.F12:
					if (e.Control)
					{
						//frmView frm = new frmView();
						//frm.WindowState = FormWindowState.Maximized;
						//frm.MdiParent = this.MdiParent;

						//DataGridView dgvShowAll = new DataGridView();
						//dgvShowAll.Dock = DockStyle.Fill;
						//frm.Controls.Add(dgvShowAll);

						//dgvShowAll.DataSource = dtDetail;

						//foreach (DataGridViewColumn dgvc in dgvShowAll.Columns)
						//{
						//    if (dgvc.ValueType == typeof(System.Byte[]))
						//        dgvc.Visible = false;
						//}

						//frm.Show();
					}
					else //Vào chi tiết
					{
						ViewDetail();
					}

					break;

				case Keys.Escape:
					this.Close();
					break;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Shift:
							DesignReport();
							break;

						case Keys.Control:
							PreviewReport();
							break;

						case Keys.None:
							PrintReport();
							break;
					}

					break;

				case Keys.F:
					if (e.Control)
					{
						frmsearch.iCurrentPotition = frmsearch.bdsSearch.Position;
						frmsearch.Show(this);
					}
					break;

				case Keys.G:
					if (e.Control)
					{
						frmsearch.GoNext();
					}
					break;
			}
		}

		void dgvResult_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ViewDetail();
		}

		void tlResult_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ViewDetail();
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);

			if (this.MdiParent != null)
			{
				if (this.MdiParent.GetType().Name == "frmMain")
				{
					frmMain frmParent = (frmMain)this.MdiParent;

					frmParent.tsReport.Visible = true;
					frmParent.tsView.Visible = true;
				}
			}
		}

		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);

			if (this.MdiParent != null)
			{
				if (this.MdiParent.GetType().Name == "frmMain")
				{
					frmMain frmParent = (frmMain)this.MdiParent;

					frmParent.tsReport.Visible = false;
					frmParent.tsView.Visible = false;
				}
			}
		}

		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == tpChart)
			{
				string strColX = drReport["ColX"].ToString();
				string strColY = drReport["ColY"].ToString();
				string strChartType = drReport["ChartType"].ToString();
				string strChart_Filter = drReport["Chart_Filter"].ToString();
				//string strTitle = drReport["Title"].ToString().ToUpper();
				string strTitle = Element.sysLanguage == enuLanguageType.Vietnamese ? (string)drReport["Title"] : (Element.sysLanguage == enuLanguageType.English ? (string)drReport["TitleE"] : (string)drReport["TitleO"]);
				string strSubTitle = "";

				if (drFilter.Table.Columns.Contains("SubTitle1") && ((string)drFilter["SubTitle1"]) != string.Empty)
					strSubTitle += (string)drFilter["SubTitle1"] + "|";

				if (drFilter.Table.Columns.Contains("SubTitle2") && ((string)drFilter["SubTitle2"]) != string.Empty)
					strSubTitle += (string)drFilter["SubTitle2"] + "|";

				DataTable dtChart = new DataTable();

				if (strChart_Filter == "")
				{
					dtChart = dtDetail.Copy();
				}
				else
				{
					dtChart = dtDetail.Clone();

					foreach (DataRow dr in dtDetail.Select(strChart_Filter))
					{
						DataRow drNew = dtChart.NewRow();
						Common.CopyDataRow(dr, drNew);

						dtChart.Rows.Add(drNew);
					}
				}

				chart1.Load(strColX, strColY, dtChart, strTitle, strSubTitle, strChartType);

				this.BindingLanguage();
			}
		}

		#endregion
	}
}