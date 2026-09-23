using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Customize;

namespace RosyReportTMN
{
	public partial class frmChart : RosySystem.Customize.frmView
	{
		DataTable dtChartSource;
		rsDataGridView dgvChartSource;

		DataRow drReport;
		DataRow drFilter;

		rptChart rpt = new rptChart();
		public DataDynamics.ActiveReports.Viewer.Viewer viewReport =new DataDynamics.ActiveReports.Viewer.Viewer();

		public frmChart()
		{
			InitializeComponent();
		}		

		public void Load(DataRow drReport, DataRow drFilter, DataTable dtChartSource, rsDataGridView dgvChartSource)
		{
			this.drReport = drReport;
			this.drFilter = drFilter;
			this.dtChartSource = dtChartSource;
			this.dgvChartSource = dgvChartSource;

			LoadChart();

			this.Show();
		}

		void LoadChart()
		{
			viewReport.Dock = DockStyle.Fill;
			this.Controls.Add(viewReport);

			rpt.lblTitle.Text = Report.GetTitle(drFilter).ToUpper();
			rpt.lblSubTitle1.Text = Report.GetSubTitle1(drReport, drFilter);
			rpt.lblSubTitle2.Text = Report.GetSubTitle2(drReport, drFilter);

			//Bi loi khi bop bop cai report
			viewReport.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.ContinuousScroll;

			rpt.Load(drReport, drFilter, dtChartSource, dgvChartSource);
			viewReport.Document = rpt.Document;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F4)
			{
				frmChartOption frm = new frmChartOption();
				frm.cboChartType.Items.Add("1-Hình cột (column)");
				frm.cboChartType.Items.Add("2-Hình đường thẳng (line)");
				frm.cboChartType.Items.Add("3-Hình khu vực (area)");
				frm.cboChartType.Items.Add("4-Hình bánh (pie)");
				frm.cboChartType.Items.Add("5-Hình bánh có lổ (doughnut)");
				frm.cboChartType.SelectedIndex = 0;

				frm.txtColY_Title.Text = rpt.chartControl1.Series[0].AxisY.Title;
				frm.txtColX_Title.Text = rpt.chartControl1.Series[0].AxisX.Title;

				frm.Load();

				if (frm.isAccept)
				{
					//ChartType
					switch (frm.cboChartType.Text.Substring(0, 1))
					{
						case "1": //Hình cột
							rpt.ChartType = frm.chk3D.Checked ? DataDynamics.ActiveReports.Chart.ChartType.Bar3D : DataDynamics.ActiveReports.Chart.ChartType.Bar2D;
							break;
						case "2": //Hình đường thẳng
							rpt.ChartType = frm.chk3D.Checked ? DataDynamics.ActiveReports.Chart.ChartType.Line3D : DataDynamics.ActiveReports.Chart.ChartType.Line;
							break;
						case "3": //Hình khu vực
							rpt.ChartType = frm.chk3D.Checked ? DataDynamics.ActiveReports.Chart.ChartType.Area3D : DataDynamics.ActiveReports.Chart.ChartType.Area;
							break;
						case "4": //Hình bánh (Pie)
							rpt.ChartType = frm.chk3D.Checked ? DataDynamics.ActiveReports.Chart.ChartType.Doughnut3D : DataDynamics.ActiveReports.Chart.ChartType.Doughnut;
							break;
						case "5": //Hình bánh có lổ (Doughnut)
							rpt.ChartType = frm.chk3D.Checked ? DataDynamics.ActiveReports.Chart.ChartType.Doughnut3D : DataDynamics.ActiveReports.Chart.ChartType.Doughnut;
							break;
						default:
							break;
					}

					//Title
					for (int i = 0; i < rpt.chartControl1.Series.Count; i++)
					{
						rpt.chartControl1.Series[i].AxisY.Title = frm.txtColY_Title.Text;
						rpt.chartControl1.Series[i].AxisX.Title = frm.txtColX_Title.Text;
					}

					rpt.Refresh();
					viewReport.Refresh();
				}
			}
			
			base.OnKeyDown(e);
		}
	}
}
