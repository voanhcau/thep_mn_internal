using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.DataSources;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Document;
using DataDynamics.ActiveReports.Viewer;
//using Microsoft.Reporting.WinForms;
//using Microsoft.ReportingServices.ReportRendering;

namespace RosyReport
{
	public partial class frmDynamicReport : Form
	{
		// declare variables
		SqlDBDataSource myDataSource = new SqlDBDataSource();

		public frmDynamicReport()
		{
			InitializeComponent();

			// create connection
			myDataSource.ConnectionString = @"Data Source=NED-CREATIVE;initial catalog=C:\\SQL SERVER 2000 SAMPLE DATABASES\\NORTHWND.MDF;integrated security=SSPI;persist security info=False";
		}

		private void btnReport_Click(object sender, EventArgs e)
		{
			myDataSource.SQL = @"Select * from Employees";

			ActiveReport myActiveReport = new ActiveReport();

			// header section
			ReportHeader rHeader = new ReportHeader();
			rHeader.Name = "pageHeader";
			rHeader.BackColor = Color.Transparent;

			myActiveReport.Sections.Add(rHeader);

			// add controls to header section

			// Title
			DataDynamics.ActiveReports.Label label1 = new DataDynamics.ActiveReports.Label();
			label1.Text = "Employees Address Report";
			label1.Style = "font-weight: bold; font-size: 15.75pt;";
			label1.Location = new PointF(2.31f, 0.13f);
			rHeader.Controls.Add(label1);

			// Date/Time
			DataDynamics.ActiveReports.ReportInfo reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
			reportInfo1.FormatString = "{RunDateTime:M/d/yyy}";
			reportInfo1.Location = new PointF(0.06f, 0.19f);
			rHeader.Controls.Add(reportInfo1);

			// Page Number
			DataDynamics.ActiveReports.ReportInfo reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
			reportInfo2.FormatString = "Page {PageNumber} of {PageCount}";
			reportInfo2.Location = new PointF(6.38f, 0.19f);
			rHeader.Controls.Add(reportInfo2);

			// Detail section
			Detail myDetails = new Detail();
			myDetails.Name = "pageDetail";
			myActiveReport.Sections.Add(myDetails);

			// add controls to detail section

			// Last Name label
			DataDynamics.ActiveReports.Label label2 = new DataDynamics.ActiveReports.Label();
			label2.Text = "Last Name";
			label2.Location = new PointF(0.06f, 0.06f);
			myDetails.Controls.Add(label2);

			// First Name label
			DataDynamics.ActiveReports.Label label3 = new DataDynamics.ActiveReports.Label();
			label3.Text = "First Name";
			label3.Location = new PointF(1.13f, 0.06f);
			myDetails.Controls.Add(label3);

			// Address label
			DataDynamics.ActiveReports.Label label4 = new DataDynamics.ActiveReports.Label();
			label4.Text = "Address";
			label4.Location = new PointF(2.44f, 0.06f);
			myDetails.Controls.Add(label4);

			// City label
			DataDynamics.ActiveReports.Label label5 = new DataDynamics.ActiveReports.Label();
			label5.Text = "City";
			label5.Location = new PointF(4.56f, 0.06f);
			myDetails.Controls.Add(label5);

			// State label
			DataDynamics.ActiveReports.Label label6 = new DataDynamics.ActiveReports.Label();
			label6.Text = "State";
			label6.Location = new PointF(5.69f, 0.06f);
			myDetails.Controls.Add(label6);

			//Last Name textbox
			DataDynamics.ActiveReports.TextBox txtLastName1 = new DataDynamics.ActiveReports.TextBox();
			txtLastName1.DataField = "LastName";
			txtLastName1.Text = "txtLastName1";
			txtLastName1.Location = new PointF(0.06f, 0.31f);
			txtLastName1.Name = "txtLastName1";
			myDetails.Controls.Add(txtLastName1);

			DataDynamics.ActiveReports.TextBox txtFirstName1 = new DataDynamics.ActiveReports.TextBox();
			txtFirstName1.DataField = "FirstName";
			txtFirstName1.Text = "txtFirstName1";
			txtFirstName1.Location = new PointF(1.13f, 0.31f);
			txtFirstName1.Name = "txtFirstName1";
			myDetails.Controls.Add(txtFirstName1);

			DataDynamics.ActiveReports.TextBox txtAddress1 = new DataDynamics.ActiveReports.TextBox();
			txtAddress1.DataField = "Address";
			txtAddress1.Text = "txtAddress1";
			txtAddress1.Location = new PointF(2.44f, 0.31f);
			txtAddress1.Name = "txtAddress1";
			myDetails.Controls.Add(txtAddress1);

			DataDynamics.ActiveReports.TextBox txtCity1 = new DataDynamics.ActiveReports.TextBox();
			txtCity1.DataField = "City";
			txtCity1.Text = "txtCity1";
			txtCity1.Location = new PointF(4.56f, 0.31f);
			txtCity1.Name = "txtCity1";
			myDetails.Controls.Add(txtCity1);

			DataDynamics.ActiveReports.TextBox txtRegion1 = new DataDynamics.ActiveReports.TextBox();
			txtRegion1.DataField = "Region";
			txtRegion1.Text = "txtRegion1";
			txtRegion1.Location = new PointF(5.69f, 0.31f);
			txtRegion1.Name = "txtRegion1";
			myDetails.Controls.Add(txtRegion1);

			// corresponding footers.
			ReportFooter myFooter = new ReportFooter();
			myFooter.Name = "pageFooter";
			myActiveReport.Sections.Add(myFooter);

			// create DataTable with columns
			DataTable myDataTable = new DataTable();
			myDataTable.Columns.Add(new DataColumn("Last Name", typeof(String)));
			myDataTable.Columns.Add(new DataColumn("First Name", typeof(String)));
			myDataTable.Columns.Add(new DataColumn("Address", typeof(String)));
			myDataTable.Columns.Add(new DataColumn("City", typeof(String)));
			myDataTable.Columns.Add(new DataColumn("State", typeof(String)));

			myActiveReport.DataSource = myDataTable;
			myActiveReport.Run();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
