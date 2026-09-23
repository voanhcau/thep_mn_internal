namespace RosyModule.ScaleBarcode
{
	partial class frmQuery_Shift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuery_Shift));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.rsPanel2 = new RosySystem.Control.rsPanel();
            this.dgvDmCa = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.btFilter = new RosySystem.Customize.btFilter();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btContinues = new RosySystem.Customize.btExit();
            this.btExit = new RosySystem.Customize.btExit();
            this.btNew = new RosySystem.Customize.btNew();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCaSX = new System.Windows.Forms.TabPage();
            this.tpTestCan = new System.Windows.Forms.TabPage();
            this.dgvTestCan = new RosySystem.Control.rsDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.rsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmCa)).BeginInit();
            this.rsPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpCaSX.SuspendLayout();
            this.tpTestCan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestCan)).BeginInit();
            this.SuspendLayout();
            // 
            // rsSplitContainer1
            // 
            this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.rsSplitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rsSplitContainer1.Name = "rsSplitContainer1";
            this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer1.Panel1
            // 
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel2);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel1);
            this.rsSplitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // rsSplitContainer1.Panel2
            // 
            this.rsSplitContainer1.Panel2.Controls.Add(this.btContinues);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btExit);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btNew);
            this.rsSplitContainer1.Size = new System.Drawing.Size(1045, 692);
            this.rsSplitContainer1.SplitterDistance = 620;
            this.rsSplitContainer1.SplitterWidth = 5;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // rsPanel2
            // 
            this.rsPanel2.Controls.Add(this.tabControl1);
            this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsPanel2.Location = new System.Drawing.Point(4, 59);
            this.rsPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rsPanel2.Name = "rsPanel2";
            this.rsPanel2.Size = new System.Drawing.Size(1037, 557);
            this.rsPanel2.TabIndex = 2;
            // 
            // dgvDmCa
            // 
            this.dgvDmCa.AllowUserToAddRows = false;
            this.dgvDmCa.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDmCa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDmCa.BackgroundColor = System.Drawing.Color.White;
            this.dgvDmCa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDmCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDmCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDmCa.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDmCa.Location = new System.Drawing.Point(3, 3);
            this.dgvDmCa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDmCa.MultiSelect = false;
            this.dgvDmCa.Name = "dgvDmCa";
            this.dgvDmCa.ReadOnly = true;
            this.dgvDmCa.Size = new System.Drawing.Size(1023, 522);
            this.dgvDmCa.strZone = "";
            this.dgvDmCa.TabIndex = 0;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.btFilter);
            this.rsPanel1.Controls.Add(this.dteNgay_Ct2);
            this.rsPanel1.Controls.Add(this.rsLabel2);
            this.rsPanel1.Controls.Add(this.dteNgay_Ct1);
            this.rsPanel1.Controls.Add(this.rsLabel1);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rsPanel1.Location = new System.Drawing.Point(4, 4);
            this.rsPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(1037, 55);
            this.rsPanel1.TabIndex = 0;
            // 
            // btFilter
            // 
            this.btFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFilter.ImageKey = "Filter.png";
            this.btFilter.Location = new System.Drawing.Point(701, 9);
            this.btFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(115, 41);
            this.btFilter.TabIndex = 2;
            this.btFilter.Tag = "";
            this.btFilter.Text = "&Lọc";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(564, 12);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(129, 30);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // rsLabel2
            // 
            this.rsLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(455, 17);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(87, 20);
            this.rsLabel2.TabIndex = 9;
            this.rsLabel2.Text = "Đến ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(317, 12);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(129, 30);
            this.dteNgay_Ct1.TabIndex = 0;
            this.dteNgay_Ct1.Text = "00002019";
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(221, 17);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(75, 20);
            this.rsLabel1.TabIndex = 7;
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btContinues
            // 
            this.btContinues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btContinues.Image = ((System.Drawing.Image)(resources.GetObject("btContinues.Image")));
            this.btContinues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btContinues.ImageKey = "exit2.png";
            this.btContinues.Location = new System.Drawing.Point(16, 3);
            this.btContinues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btContinues.Name = "btContinues";
            this.btContinues.Size = new System.Drawing.Size(124, 62);
            this.btContinues.TabIndex = 0;
            this.btContinues.Tag = "";
            this.btContinues.Text = "Tiếp tục ca SX";
            this.btContinues.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btContinues.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(280, 3);
            this.btExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(124, 62);
            this.btExit.TabIndex = 2;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Th&oát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "New.png";
            this.btNew.Location = new System.Drawing.Point(148, 3);
            this.btNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(124, 62);
            this.btNew.TabIndex = 1;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCaSX);
            this.tabControl1.Controls.Add(this.tpTestCan);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1037, 557);
            this.tabControl1.TabIndex = 1;
            // 
            // tpCaSX
            // 
            this.tpCaSX.Controls.Add(this.dgvDmCa);
            this.tpCaSX.Location = new System.Drawing.Point(4, 25);
            this.tpCaSX.Name = "tpCaSX";
            this.tpCaSX.Padding = new System.Windows.Forms.Padding(3);
            this.tpCaSX.Size = new System.Drawing.Size(1029, 528);
            this.tpCaSX.TabIndex = 0;
            this.tpCaSX.Text = "Ca sản xuất";
            this.tpCaSX.UseVisualStyleBackColor = true;
            // 
            // tpTestCan
            // 
            this.tpTestCan.Controls.Add(this.dgvTestCan);
            this.tpTestCan.Location = new System.Drawing.Point(4, 25);
            this.tpTestCan.Name = "tpTestCan";
            this.tpTestCan.Padding = new System.Windows.Forms.Padding(3);
            this.tpTestCan.Size = new System.Drawing.Size(1029, 528);
            this.tpTestCan.TabIndex = 1;
            this.tpTestCan.Text = "Test Cân";
            this.tpTestCan.UseVisualStyleBackColor = true;
            // 
            // dgvTestCan
            // 
            this.dgvTestCan.AllowUserToAddRows = false;
            this.dgvTestCan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTestCan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTestCan.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestCan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTestCan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestCan.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTestCan.Location = new System.Drawing.Point(3, 3);
            this.dgvTestCan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTestCan.MultiSelect = false;
            this.dgvTestCan.Name = "dgvTestCan";
            this.dgvTestCan.ReadOnly = true;
            this.dgvTestCan.Size = new System.Drawing.Size(1023, 522);
            this.dgvTestCan.strZone = "";
            this.dgvTestCan.TabIndex = 1;
            // 
            // frmQuery_Shift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 692);
            this.Controls.Add(this.rsSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmQuery_Shift";
            this.Object_ID = "QUERY_SHIFT";
            this.Text = "frmQuery_Shift";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.rsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmCa)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            this.rsPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpCaSX.ResumeLayout(false);
            this.tpTestCan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestCan)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
		private RosySystem.Control.rsPanel rsPanel1;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Control.rsDateTime dteNgay_Ct2;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsDateTime dteNgay_Ct1;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Customize.btExit btContinues;
		private RosySystem.Customize.btExit btExit;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Control.rsPanel rsPanel2;
		private RosySystem.Control.rsDataGridView dgvDmCa;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCaSX;
        private System.Windows.Forms.TabPage tpTestCan;
        private RosySystem.Control.rsDataGridView dgvTestCan;
	}
}