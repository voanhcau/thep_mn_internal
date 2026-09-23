using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Design.Toolbox;
using RosySystem.Common;
using RosySystem.Library;

namespace RosyReportTMN
{
	public partial class frmReportDesign : RosySystem.Control.frmBase
	{
		private DataRow drReport;
		private DataTable dtResult;
		private string strReportFile = string.Empty;

		public frmReportDesign()
		{
			InitializeComponent();

			arDesigner.SelectionChanged += new SelectionChangedEventHandler(arDesigner_SelectionChanged);
			arDesigner.LayoutChanged += new LayoutChangedEventHandler(arDesigner_LayoutChanged);

			this.KeyDown += new KeyEventHandler(frmReportDesign_KeyDown);


			//arDesigner.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
			InitDesignReport();
		}

		new public void Load(DataRow drReport, DataTable dtResult)
		{
			this.drReport = drReport;
			this.dtResult = dtResult;

			string strFileName = (string)drReport["Vnd_Nt"] == "2" ? (string)drReport["REPORT_FILE"] + "_NT" : (string)drReport["REPORT_FILE"];
			this.LoadReport(strFileName);

			this.Show();
		}

		public void Load(string strFileName)
		{
			this.LoadReport(strFileName);

			Show();
		}

		void InitDesignReport()
		{
			this.arDesigner.Toolbox = this.arToolbox;
			this.arReportExplorer.Report = arDesigner.Report;

			//Add Menu and CommandBar to Form
			this.AddCommandBar();

			//Fill Toolbox
			LoadTools(this.arToolbox);
			// Activate default group on the toolbox
			this.arToolbox.SelectedCategory = "ActiveReports 6.0";

			//Setup Status Bar
			this.arStatus.Panels.Add(new StatusBarPanel());
			this.arStatus.Panels.Add(new StatusBarPanel());
			this.arStatus.Panels[0].AutoSize = StatusBarPanelAutoSize.Spring;
			this.arStatus.Panels[1].AutoSize = StatusBarPanelAutoSize.Spring;
			this.arStatus.ShowPanels = true;
		}

		public void LoadReport(string strFileName)
		{
			strFileName += ".rpx";
			strReportFile = Application.StartupPath + @"\Report\" + strFileName;

			if (strFileName == string.Empty || !File.Exists(strReportFile))
			{
				Common.MsgOk("Không có tập tin report: " + strFileName);
				return;
			}

			arDesigner.LoadReport(strReportFile);
			this.Text = this.Text + " - " + strFileName;
		}

		private void AddCommandBar()
		{
			// Add Menu and CommandBar to Form
			ToolStrip menuStrip = this.arDesigner.CreateToolStrips(DataDynamics.ActiveReports.Design.DesignerToolStrips.Menu)[0];
			ToolStrip editStrip = this.arDesigner.CreateToolStrips(DataDynamics.ActiveReports.Design.DesignerToolStrips.Edit)[0];
			ToolStrip formatStrip = this.arDesigner.CreateToolStrips(DataDynamics.ActiveReports.Design.DesignerToolStrips.Format)[0];
			ToolStrip layoutStrip = this.arDesigner.CreateToolStrips(DataDynamics.ActiveReports.Design.DesignerToolStrips.Layout)[0];
			ToolStrip reportStrip = this.arDesigner.CreateToolStrips(DataDynamics.ActiveReports.Design.DesignerToolStrips.Report)[0];
			ToolStrip undoStrip = this.arDesigner.CreateToolStrips(DataDynamics.ActiveReports.Design.DesignerToolStrips.Undo)[0];
			ToolStrip zoomStrip = this.arDesigner.CreateToolStrips(DataDynamics.ActiveReports.Design.DesignerToolStrips.Zoom)[0];

			ToolStripDropDownItem fileMenu = (ToolStripDropDownItem)menuStrip.Items[0];

			this.toolStripContainer.TopToolStripPanel.Join(menuStrip, 0);
			this.toolStripContainer.TopToolStripPanel.Join(zoomStrip, 1);
			this.toolStripContainer.TopToolStripPanel.Join(undoStrip, 1);
			this.toolStripContainer.TopToolStripPanel.Join(editStrip, 1);
			this.toolStripContainer.TopToolStripPanel.Join(reportStrip, 1);
			this.toolStripContainer.TopToolStripPanel.Join(formatStrip, 2);
			this.toolStripContainer.TopToolStripPanel.Join(layoutStrip, 3);

			fileMenu.DropDownItems[2].Text = "Save &As";

			fileMenu.DropDownItems.Insert(3, new ToolStripMenuItem("Save", DataDynamics.ActiveReports.Design.Images.Save, Save_Click));

			// Add an Exit command to the File menu
			fileMenu.DropDownItems.Add(new ToolStripSeparator());
			fileMenu.DropDownItems.Add(new ToolStripMenuItem("Exit", DataDynamics.ActiveReports.Design.Images.Delete, OnExit));

			//View Toolbar
			menuStrip.Items.Add("View");
			ToolStripDropDownItem fileMenu1 = (ToolStripDropDownItem)menuStrip.Items[2];
			fileMenu1.DropDownItems.Add(new ToolStripMenuItem("Toolbox", DataDynamics.ActiveReports.Design.Images.Control, Toolbox_OnClick));

			editStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
			formatStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
			layoutStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
			reportStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
			undoStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
			zoomStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
		}

		private void LoadTools(DataDynamics.ActiveReports.Design.Toolbox.Toolbox toolbox)
		{
			//Add Data Providers
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.DataSet)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.DataView)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.OleDb.OleDbConnection)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.OleDb.OleDbDataAdapter)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.Odbc.OdbcConnection)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.Odbc.OdbcDataAdapter)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.SqlClient.SqlConnection)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.SqlClient.SqlDataAdapter)), "Data");
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			//if (this.arDesigner.CommandBarManager.PreProcessMessage(ref msg))
			//    return true;

			return base.ProcessCmdKey(ref msg, keyData);
		}

		#region Event

		private void arDesigner_LayoutChanged(object sender, DataDynamics.ActiveReports.Design.LayoutChangedArgs e)
		{
			switch (e.Type)
			{
				case LayoutChangeType.ReportLoad:
				case LayoutChangeType.ReportClear:
					this.arReportExplorer.Report = this.arDesigner.Report;
					break;
				default:
					break;
			}
		}

		private void arDesigner_SelectionChanged()
		{
			string curSelection = "";
			IEnumerator selectionEnum = null;
			if (arDesigner.Selection != null)
				selectionEnum = arDesigner.Selection.GetEnumerator();
			while (selectionEnum != null && selectionEnum.MoveNext())
			{
				if (selectionEnum.Current is Section)
					curSelection = curSelection + (selectionEnum.Current as Section).Name + ", ";
				if (selectionEnum.Current is ARControl)
					curSelection = curSelection + (selectionEnum.Current as ARControl).Name + ", ";
				if (selectionEnum.Current is Field)
					curSelection = curSelection + (selectionEnum.Current as Field).Name + ", ";
				if (selectionEnum.Current is Parameter)
					curSelection = curSelection + (selectionEnum.Current as Parameter).Key + ", ";
				if (selectionEnum.Current is ActiveReport)
					curSelection = curSelection + (selectionEnum.Current as ActiveReport).Document.Name + ", ";
			}
			if (this.arStatus.Created && this.arStatus.Panels[1] != null)
			{
				if (curSelection != "")
					this.arStatus.Panels[1].Text = "Current Selection: " + curSelection.Substring(0, curSelection.Length - 2);
				else
					this.arStatus.Panels[1].Text = "No Selection";
			}
		}

		void Save_Click(object sender, EventArgs e)
		{
			//arDesigner.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
			arDesigner.SaveReport(strReportFile);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			if (!strReportFile.EndsWith(@"\.rpx"))
				if (Common.MsgYes_No(Languages.GetLanguage("Doyouwant") + " " + Languages.GetLanguage("Save") + " " + strReportFile))
				{
					//arDesigner.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
					arDesigner.SaveReport(strReportFile);
				}

			if (RosySystem.Element.Element.frmMain != null)
			{
				RosySystem.Element.Element.frmMain.Activate();
			}

			toolStripContainer.TopToolStripPanel.Controls.Clear();
		}

		private void OnExit(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Toolbox_OnClick(object sender, EventArgs e)
		{
			splitContainer.Panel1Collapsed = !splitContainer.Panel1Collapsed;
		}
		void frmReportDesign_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F4:
					splitContainer.Panel1Collapsed = !splitContainer.Panel1Collapsed;
					break;
				default:
					break;
			}
		}

		#endregion
		
	}
}