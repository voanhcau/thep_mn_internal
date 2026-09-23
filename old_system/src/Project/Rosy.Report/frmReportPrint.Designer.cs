namespace RosyReport
{
	partial class frmReportPrint
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btExport = new RosySystem.Control.rsButton();
			this.viewReport = new DataDynamics.ActiveReports.Viewer.Viewer();
			this.SuspendLayout();
			// 
			// btExport
			// 
			this.btExport.Image = global::RosyReportTMN.Properties.Resources.Export;
			this.btExport.Location = new System.Drawing.Point(716, 0);
			this.btExport.Name = "btExport";
			this.btExport.Size = new System.Drawing.Size(24, 24);
			this.btExport.TabIndex = 6;
			this.btExport.UseVisualStyleBackColor = true;
			// 
			// viewReport
			// 
			this.viewReport.BackColor = System.Drawing.SystemColors.Control;
			this.viewReport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewReport.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
			this.viewReport.Location = new System.Drawing.Point(0, 0);
			this.viewReport.Name = "viewReport";
			this.viewReport.ReportViewer.CurrentPage = 0;
			this.viewReport.ReportViewer.MultiplePageCols = 3;
			this.viewReport.ReportViewer.MultiplePageRows = 2;
			this.viewReport.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
			this.viewReport.Size = new System.Drawing.Size(792, 566);
			this.viewReport.TabIndex = 7;
			this.viewReport.TableOfContents.Text = "Table Of Contents";
			this.viewReport.TableOfContents.Width = 200;
			this.viewReport.TabTitleLength = 35;
			this.viewReport.Toolbar.Font = new System.Drawing.Font("Segoe UI", 9F);
			// 
			// frmReportPrint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.btExport);
			this.Controls.Add(this.viewReport);
			this.Name = "frmReportPrint";
			this.Tag = "frmReportPrint";
			this.Text = "frmReportPrint";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsButton btExport;
		public DataDynamics.ActiveReports.Viewer.Viewer viewReport;
	}
}