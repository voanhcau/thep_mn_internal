namespace RosyControllerTMN
{
	partial class frmPermission
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btExit = new RosySystem.Control.rsButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPermissionData = new System.Windows.Forms.TabPage();
            this.dgvPermissionCt = new RosySystem.Control.rsDataGridView();
            this.dgvPermissionModule = new RosySystem.Control.rsDataGridView();
            this.tpPermissionTk = new System.Windows.Forms.TabPage();
            this.dgvPermissionTk = new RosySystem.Control.rsDataGridView();
            this.tpPermissionDvCs = new System.Windows.Forms.TabPage();
            this.dgvPermissionDvCs = new RosySystem.Control.rsDataGridView();
            this.tpPermissionReport = new System.Windows.Forms.TabPage();
            this.dgvPermissionReportCt = new RosySystem.Control.rsDataGridView();
            this.dgvPermissionReport = new RosySystem.Control.rsDataGridView();
            this.tabControl1.SuspendLayout();
            this.tpPermissionData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionCt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionModule)).BeginInit();
            this.tpPermissionTk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionTk)).BeginInit();
            this.tpPermissionDvCs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionDvCs)).BeginInit();
            this.tpPermissionReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionReportCt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(993, 537);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(111, 23);
            this.btExit.TabIndex = 0;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpPermissionData);
            this.tabControl1.Controls.Add(this.tpPermissionTk);
            this.tabControl1.Controls.Add(this.tpPermissionDvCs);
            this.tabControl1.Controls.Add(this.tpPermissionReport);
            this.tabControl1.Location = new System.Drawing.Point(6, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1108, 519);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabStop = false;
            // 
            // tpPermissionData
            // 
            this.tpPermissionData.Controls.Add(this.dgvPermissionCt);
            this.tpPermissionData.Controls.Add(this.dgvPermissionModule);
            this.tpPermissionData.Location = new System.Drawing.Point(4, 22);
            this.tpPermissionData.Name = "tpPermissionData";
            this.tpPermissionData.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermissionData.Size = new System.Drawing.Size(1100, 493);
            this.tpPermissionData.TabIndex = 0;
            this.tpPermissionData.Text = "Truy cập dữ liệu";
            this.tpPermissionData.UseVisualStyleBackColor = true;
            // 
            // dgvPermissionCt
            // 
            this.dgvPermissionCt.AllowUserToAddRows = false;
            this.dgvPermissionCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPermissionCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPermissionCt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermissionCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissionCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPermissionCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissionCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPermissionCt.Location = new System.Drawing.Point(3, 291);
            this.dgvPermissionCt.MultiSelect = false;
            this.dgvPermissionCt.Name = "dgvPermissionCt";
            this.dgvPermissionCt.ReadOnly = true;
            this.dgvPermissionCt.Size = new System.Drawing.Size(1093, 199);
            this.dgvPermissionCt.strZone = "";
            this.dgvPermissionCt.TabIndex = 1;
            // 
            // dgvPermissionModule
            // 
            this.dgvPermissionModule.AllowUserToAddRows = false;
            this.dgvPermissionModule.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPermissionModule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPermissionModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermissionModule.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissionModule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPermissionModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissionModule.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPermissionModule.Location = new System.Drawing.Point(3, 3);
            this.dgvPermissionModule.MultiSelect = false;
            this.dgvPermissionModule.Name = "dgvPermissionModule";
            this.dgvPermissionModule.ReadOnly = true;
            this.dgvPermissionModule.Size = new System.Drawing.Size(1093, 282);
            this.dgvPermissionModule.strZone = "";
            this.dgvPermissionModule.TabIndex = 0;
            // 
            // tpPermissionTk
            // 
            this.tpPermissionTk.Controls.Add(this.dgvPermissionTk);
            this.tpPermissionTk.Location = new System.Drawing.Point(4, 22);
            this.tpPermissionTk.Name = "tpPermissionTk";
            this.tpPermissionTk.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermissionTk.Size = new System.Drawing.Size(1100, 493);
            this.tpPermissionTk.TabIndex = 1;
            this.tpPermissionTk.Text = "Truy cập tài khoản";
            this.tpPermissionTk.UseVisualStyleBackColor = true;
            // 
            // dgvPermissionTk
            // 
            this.dgvPermissionTk.AllowUserToAddRows = false;
            this.dgvPermissionTk.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPermissionTk.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPermissionTk.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissionTk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPermissionTk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissionTk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPermissionTk.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPermissionTk.Location = new System.Drawing.Point(3, 3);
            this.dgvPermissionTk.MultiSelect = false;
            this.dgvPermissionTk.Name = "dgvPermissionTk";
            this.dgvPermissionTk.ReadOnly = true;
            this.dgvPermissionTk.Size = new System.Drawing.Size(1094, 487);
            this.dgvPermissionTk.strZone = "";
            this.dgvPermissionTk.TabIndex = 1;
            // 
            // tpPermissionDvCs
            // 
            this.tpPermissionDvCs.Controls.Add(this.dgvPermissionDvCs);
            this.tpPermissionDvCs.Location = new System.Drawing.Point(4, 22);
            this.tpPermissionDvCs.Name = "tpPermissionDvCs";
            this.tpPermissionDvCs.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermissionDvCs.Size = new System.Drawing.Size(1100, 493);
            this.tpPermissionDvCs.TabIndex = 2;
            this.tpPermissionDvCs.Text = "Truy cập đơn vị cơ sở";
            this.tpPermissionDvCs.UseVisualStyleBackColor = true;
            // 
            // dgvPermissionDvCs
            // 
            this.dgvPermissionDvCs.AllowUserToAddRows = false;
            this.dgvPermissionDvCs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPermissionDvCs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPermissionDvCs.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissionDvCs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPermissionDvCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissionDvCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPermissionDvCs.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPermissionDvCs.Location = new System.Drawing.Point(3, 3);
            this.dgvPermissionDvCs.MultiSelect = false;
            this.dgvPermissionDvCs.Name = "dgvPermissionDvCs";
            this.dgvPermissionDvCs.ReadOnly = true;
            this.dgvPermissionDvCs.Size = new System.Drawing.Size(1094, 487);
            this.dgvPermissionDvCs.strZone = "";
            this.dgvPermissionDvCs.TabIndex = 1;
            // 
            // tpPermissionReport
            // 
            this.tpPermissionReport.Controls.Add(this.dgvPermissionReportCt);
            this.tpPermissionReport.Controls.Add(this.dgvPermissionReport);
            this.tpPermissionReport.Location = new System.Drawing.Point(4, 22);
            this.tpPermissionReport.Name = "tpPermissionReport";
            this.tpPermissionReport.Size = new System.Drawing.Size(1100, 493);
            this.tpPermissionReport.TabIndex = 3;
            this.tpPermissionReport.Text = "Truy cập báo cáo";
            this.tpPermissionReport.UseVisualStyleBackColor = true;
            // 
            // dgvPermissionReportCt
            // 
            this.dgvPermissionReportCt.AllowUserToAddRows = false;
            this.dgvPermissionReportCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPermissionReportCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPermissionReportCt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermissionReportCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissionReportCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPermissionReportCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissionReportCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPermissionReportCt.Location = new System.Drawing.Point(4, 291);
            this.dgvPermissionReportCt.MultiSelect = false;
            this.dgvPermissionReportCt.Name = "dgvPermissionReportCt";
            this.dgvPermissionReportCt.ReadOnly = true;
            this.dgvPermissionReportCt.Size = new System.Drawing.Size(1093, 199);
            this.dgvPermissionReportCt.strZone = "";
            this.dgvPermissionReportCt.TabIndex = 3;
            // 
            // dgvPermissionReport
            // 
            this.dgvPermissionReport.AllowUserToAddRows = false;
            this.dgvPermissionReport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPermissionReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPermissionReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermissionReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissionReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPermissionReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissionReport.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPermissionReport.Location = new System.Drawing.Point(4, 3);
            this.dgvPermissionReport.MultiSelect = false;
            this.dgvPermissionReport.Name = "dgvPermissionReport";
            this.dgvPermissionReport.ReadOnly = true;
            this.dgvPermissionReport.Size = new System.Drawing.Size(1093, 282);
            this.dgvPermissionReport.strZone = "";
            this.dgvPermissionReport.TabIndex = 2;
            // 
            // frmPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(1118, 566);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPermission";
            this.Tag = "frmPermission";
            this.Text = "frmPermission";
            this.tabControl1.ResumeLayout(false);
            this.tpPermissionData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionCt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionModule)).EndInit();
            this.tpPermissionTk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionTk)).EndInit();
            this.tpPermissionDvCs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionDvCs)).EndInit();
            this.tpPermissionReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionReportCt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissionReport)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsButton btExit;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpPermissionData;
		private System.Windows.Forms.TabPage tpPermissionTk;
		private System.Windows.Forms.TabPage tpPermissionDvCs;
		private RosySystem.Control.rsDataGridView dgvPermissionModule;
		private RosySystem.Control.rsDataGridView dgvPermissionCt;
		private RosySystem.Control.rsDataGridView dgvPermissionTk;
		private RosySystem.Control.rsDataGridView dgvPermissionDvCs;
        private System.Windows.Forms.TabPage tpPermissionReport;
        private RosySystem.Control.rsDataGridView dgvPermissionReportCt;
        private RosySystem.Control.rsDataGridView dgvPermissionReport;
	}
}