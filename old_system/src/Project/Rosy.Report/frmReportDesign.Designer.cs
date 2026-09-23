using System.Windows.Forms;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Design.Toolbox;

namespace RosyReport
{
	partial class frmReportDesign
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
			this.pnlToolbox = new RosySystem.Control.rsPanel();
			this.arToolbox = new DataDynamics.ActiveReports.Design.Toolbox.Toolbox();
			this.arDesigner = new DataDynamics.ActiveReports.Design.Designer();
			this.arPropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.arReportExplorer = new DataDynamics.ActiveReports.Design.ReportExplorer();
			this.arStatus = new System.Windows.Forms.StatusBar();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tpToolBox = new System.Windows.Forms.TabPage();
			this.tpProperty = new System.Windows.Forms.TabPage();
			this.tpSetting = new System.Windows.Forms.TabPage();
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.pnlToolbox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.arToolbox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tpToolBox.SuspendLayout();
			this.tpProperty.SuspendLayout();
			this.tpSetting.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlToolbox
			// 
			this.pnlToolbox.Controls.Add(this.arToolbox);
			this.pnlToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlToolbox.Location = new System.Drawing.Point(3, 3);
			this.pnlToolbox.Name = "pnlToolbox";
			this.pnlToolbox.Size = new System.Drawing.Size(216, 414);
			this.pnlToolbox.TabIndex = 0;
			// 
			// arToolbox
			// 
			this.arToolbox.AllowDrop = true;
			this.arToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.arToolbox.Location = new System.Drawing.Point(0, 0);
			this.arToolbox.Name = "arToolbox";
			this.arToolbox.Size = new System.Drawing.Size(216, 414);
			this.arToolbox.TabIndex = 4;
			// 
			// arDesigner
			// 
			this.arDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
			this.arDesigner.IsDirty = false;
			this.arDesigner.Location = new System.Drawing.Point(0, 0);
			this.arDesigner.LockControls = false;
			this.arDesigner.Name = "arDesigner";
			this.arDesigner.PropertyGrid = this.arPropertyGrid;
			this.arDesigner.ReportTabsVisible = true;
			this.arDesigner.ShowDataSourceIcon = true;
			this.arDesigner.Size = new System.Drawing.Size(611, 446);
			this.arDesigner.TabIndex = 2;
			this.arDesigner.Toolbox = null;
			this.arDesigner.ToolBoxItem = null;
			// 
			// arPropertyGrid
			// 
			this.arPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.arPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.arPropertyGrid.Location = new System.Drawing.Point(3, 3);
			this.arPropertyGrid.Name = "arPropertyGrid";
			this.arPropertyGrid.Size = new System.Drawing.Size(186, 414);
			this.arPropertyGrid.TabIndex = 2;
			// 
			// arReportExplorer
			// 
			this.arReportExplorer.AutoScroll = true;
			this.arReportExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.arReportExplorer.Location = new System.Drawing.Point(0, 0);
			this.arReportExplorer.Name = "arReportExplorer";
			this.arReportExplorer.ReportDesigner = null;
			this.arReportExplorer.Size = new System.Drawing.Size(192, 420);
			this.arReportExplorer.TabIndex = 0;
			// 
			// arStatus
			// 
			this.arStatus.Location = new System.Drawing.Point(0, 544);
			this.arStatus.Name = "arStatus";
			this.arStatus.Size = new System.Drawing.Size(845, 22);
			this.arStatus.TabIndex = 5;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(0, 98);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.tabControl);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.arDesigner);
			this.splitContainer.Size = new System.Drawing.Size(845, 446);
			this.splitContainer.SplitterDistance = 230;
			this.splitContainer.TabIndex = 7;
			// 
			// tabControl
			// 
			this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabControl.Controls.Add(this.tpToolBox);
			this.tabControl.Controls.Add(this.tpProperty);
			this.tabControl.Controls.Add(this.tpSetting);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Multiline = true;
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(230, 446);
			this.tabControl.TabIndex = 0;
			// 
			// tpToolBox
			// 
			this.tpToolBox.Controls.Add(this.pnlToolbox);
			this.tpToolBox.Location = new System.Drawing.Point(4, 4);
			this.tpToolBox.Name = "tpToolBox";
			this.tpToolBox.Padding = new System.Windows.Forms.Padding(3);
			this.tpToolBox.Size = new System.Drawing.Size(222, 420);
			this.tpToolBox.TabIndex = 0;
			this.tpToolBox.Text = "ToolBox";
			this.tpToolBox.UseVisualStyleBackColor = true;
			// 
			// tpProperty
			// 
			this.tpProperty.Controls.Add(this.arPropertyGrid);
			this.tpProperty.Location = new System.Drawing.Point(4, 4);
			this.tpProperty.Name = "tpProperty";
			this.tpProperty.Padding = new System.Windows.Forms.Padding(3);
			this.tpProperty.Size = new System.Drawing.Size(192, 420);
			this.tpProperty.TabIndex = 1;
			this.tpProperty.Text = "Property";
			this.tpProperty.UseVisualStyleBackColor = true;
			// 
			// tpSetting
			// 
			this.tpSetting.Controls.Add(this.arReportExplorer);
			this.tpSetting.Location = new System.Drawing.Point(4, 4);
			this.tpSetting.Name = "tpSetting";
			this.tpSetting.Size = new System.Drawing.Size(192, 420);
			this.tpSetting.TabIndex = 2;
			this.tpSetting.Text = "Setting";
			this.tpSetting.UseVisualStyleBackColor = true;
			// 
			// toolStripContainer
			// 
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(845, 73);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Top;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(845, 98);
			this.toolStripContainer.TabIndex = 8;
			this.toolStripContainer.Text = "toolStripContainer1";
			// 
			// frmReportDesign
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(845, 566);
			this.Controls.Add(this.toolStripContainer);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.arStatus);
			this.Name = "frmReportDesign";
			this.Tag = "frmReportDesign";
			this.Text = "frmReportDesign";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.pnlToolbox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.arToolbox)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tpToolBox.ResumeLayout(false);
			this.tpProperty.ResumeLayout(false);
			this.tpSetting.ResumeLayout(false);
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Designer arDesigner;
		private System.Windows.Forms.PropertyGrid arPropertyGrid;
		private ReportExplorer arReportExplorer;
		private StatusBar arStatus;
		private RosySystem.Control.rsPanel pnlToolbox;
		private SplitContainer splitContainer;
		private TabControl tabControl;
		private TabPage tpToolBox;
		private TabPage tpProperty;
		private TabPage tpSetting;
		private Toolbox arToolbox;
		private ToolStripContainer toolStripContainer;		

	}

}