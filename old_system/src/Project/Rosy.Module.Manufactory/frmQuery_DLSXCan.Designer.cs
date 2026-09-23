namespace RosyModule.Manufactory
{
    partial class frmQuery_DLSXCan
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
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.rsPanel2 = new RosySystem.Control.rsPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTHChung = new System.Windows.Forms.TabPage();
            this.dgvTHChung = new RosySystem.Control.rsDataGridView();
            this.tpSuCo = new System.Windows.Forms.TabPage();
            this.dgvSuCo = new RosySystem.Control.rsDataGridView();
            this.tpDLSX = new System.Windows.Forms.TabPage();
            this.dgvTSQT = new RosySystem.Control.rsDataGridView();
            this.tpNhapKho = new System.Windows.Forms.TabPage();
            this.dgvPhoiNhap = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.btFilter = new RosySystem.Customize.btFilter();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btExit = new RosySystem.Customize.btExit();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.rsPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpTHChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTHChung)).BeginInit();
            this.tpSuCo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuCo)).BeginInit();
            this.tpDLSX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTSQT)).BeginInit();
            this.tpNhapKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoiNhap)).BeginInit();
            this.rsPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsSplitContainer1
            // 
            this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.rsSplitContainer1.Name = "rsSplitContainer1";
            this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer1.Panel1
            // 
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel2);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel1);
            this.rsSplitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // rsSplitContainer1.Panel2
            // 
            this.rsSplitContainer1.Panel2.Controls.Add(this.btExit);
            this.rsSplitContainer1.Size = new System.Drawing.Size(784, 562);
            this.rsSplitContainer1.SplitterDistance = 503;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // rsPanel2
            // 
            this.rsPanel2.Controls.Add(this.tabControl1);
            this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsPanel2.Location = new System.Drawing.Point(3, 48);
            this.rsPanel2.Name = "rsPanel2";
            this.rsPanel2.Size = new System.Drawing.Size(778, 452);
            this.rsPanel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpTHChung);
            this.tabControl1.Controls.Add(this.tpSuCo);
            this.tabControl1.Controls.Add(this.tpDLSX);
            this.tabControl1.Controls.Add(this.tpNhapKho);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 452);
            this.tabControl1.TabIndex = 1;
            // 
            // tpTHChung
            // 
            this.tpTHChung.Controls.Add(this.dgvTHChung);
            this.tpTHChung.Location = new System.Drawing.Point(4, 22);
            this.tpTHChung.Margin = new System.Windows.Forms.Padding(2);
            this.tpTHChung.Name = "tpTHChung";
            this.tpTHChung.Padding = new System.Windows.Forms.Padding(2);
            this.tpTHChung.Size = new System.Drawing.Size(770, 426);
            this.tpTHChung.TabIndex = 0;
            this.tpTHChung.Text = "Tình hình chung";
            this.tpTHChung.UseVisualStyleBackColor = true;
            // 
            // dgvTHChung
            // 
            this.dgvTHChung.AllowUserToAddRows = false;
            this.dgvTHChung.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTHChung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTHChung.BackgroundColor = System.Drawing.Color.White;
            this.dgvTHChung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTHChung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTHChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTHChung.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTHChung.Location = new System.Drawing.Point(2, 2);
            this.dgvTHChung.MultiSelect = false;
            this.dgvTHChung.Name = "dgvTHChung";
            this.dgvTHChung.ReadOnly = true;
            this.dgvTHChung.Size = new System.Drawing.Size(766, 422);
            this.dgvTHChung.strZone = "";
            this.dgvTHChung.TabIndex = 0;
            // 
            // tpSuCo
            // 
            this.tpSuCo.Controls.Add(this.dgvSuCo);
            this.tpSuCo.Location = new System.Drawing.Point(4, 22);
            this.tpSuCo.Margin = new System.Windows.Forms.Padding(2);
            this.tpSuCo.Name = "tpSuCo";
            this.tpSuCo.Padding = new System.Windows.Forms.Padding(2);
            this.tpSuCo.Size = new System.Drawing.Size(770, 426);
            this.tpSuCo.TabIndex = 1;
            this.tpSuCo.Text = "Sự cố";
            this.tpSuCo.UseVisualStyleBackColor = true;
            // 
            // dgvSuCo
            // 
            this.dgvSuCo.AllowUserToAddRows = false;
            this.dgvSuCo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSuCo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSuCo.BackgroundColor = System.Drawing.Color.White;
            this.dgvSuCo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSuCo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuCo.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvSuCo.Location = new System.Drawing.Point(2, 2);
            this.dgvSuCo.MultiSelect = false;
            this.dgvSuCo.Name = "dgvSuCo";
            this.dgvSuCo.ReadOnly = true;
            this.dgvSuCo.Size = new System.Drawing.Size(766, 422);
            this.dgvSuCo.strZone = "";
            this.dgvSuCo.TabIndex = 1;
            // 
            // tpDLSX
            // 
            this.tpDLSX.Controls.Add(this.dgvTSQT);
            this.tpDLSX.Location = new System.Drawing.Point(4, 22);
            this.tpDLSX.Name = "tpDLSX";
            this.tpDLSX.Size = new System.Drawing.Size(770, 426);
            this.tpDLSX.TabIndex = 2;
            this.tpDLSX.Text = "Phôi sử dụng trong quá trình sản xuất";
            this.tpDLSX.UseVisualStyleBackColor = true;
            // 
            // dgvTSQT
            // 
            this.dgvTSQT.AllowUserToAddRows = false;
            this.dgvTSQT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTSQT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTSQT.BackgroundColor = System.Drawing.Color.White;
            this.dgvTSQT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTSQT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTSQT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTSQT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTSQT.Location = new System.Drawing.Point(0, 0);
            this.dgvTSQT.MultiSelect = false;
            this.dgvTSQT.Name = "dgvTSQT";
            this.dgvTSQT.ReadOnly = true;
            this.dgvTSQT.Size = new System.Drawing.Size(770, 426);
            this.dgvTSQT.strZone = "";
            this.dgvTSQT.TabIndex = 2;
            // 
            // tpNhapKho
            // 
            this.tpNhapKho.Controls.Add(this.dgvPhoiNhap);
            this.tpNhapKho.Location = new System.Drawing.Point(4, 22);
            this.tpNhapKho.Name = "tpNhapKho";
            this.tpNhapKho.Size = new System.Drawing.Size(770, 426);
            this.tpNhapKho.TabIndex = 3;
            this.tpNhapKho.Text = "Dữ liệu nhập kho KCS";
            this.tpNhapKho.UseVisualStyleBackColor = true;
            // 
            // dgvPhoiNhap
            // 
            this.dgvPhoiNhap.AllowUserToAddRows = false;
            this.dgvPhoiNhap.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhoiNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhoiNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhoiNhap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhoiNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhoiNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhoiNhap.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPhoiNhap.Location = new System.Drawing.Point(0, 0);
            this.dgvPhoiNhap.MultiSelect = false;
            this.dgvPhoiNhap.Name = "dgvPhoiNhap";
            this.dgvPhoiNhap.ReadOnly = true;
            this.dgvPhoiNhap.Size = new System.Drawing.Size(770, 426);
            this.dgvPhoiNhap.strZone = "";
            this.dgvPhoiNhap.TabIndex = 2;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.btFilter);
            this.rsPanel1.Controls.Add(this.dteNgay_Ct2);
            this.rsPanel1.Controls.Add(this.rsLabel2);
            this.rsPanel1.Controls.Add(this.dteNgay_Ct1);
            this.rsPanel1.Controls.Add(this.rsLabel1);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rsPanel1.Location = new System.Drawing.Point(3, 3);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(778, 45);
            this.rsPanel1.TabIndex = 0;
            // 
            // btFilter
            // 
            this.btFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFilter.ImageKey = "Filter.png";
            this.btFilter.Location = new System.Drawing.Point(526, 7);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(86, 33);
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
            this.dteNgay_Ct2.Location = new System.Drawing.Point(423, 10);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(98, 26);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // rsLabel2
            // 
            this.rsLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(341, 14);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(77, 17);
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
            this.dteNgay_Ct1.Location = new System.Drawing.Point(238, 10);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(98, 26);
            this.dteNgay_Ct1.TabIndex = 0;
            this.dteNgay_Ct1.Text = "00002019";
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(166, 14);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(67, 17);
            this.rsLabel1.TabIndex = 7;
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(4, 3);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(93, 50);
            this.btExit.TabIndex = 2;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Th&oát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // frmQuery_DLSXCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.rsSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmQuery_DLSXCan";
            this.Object_ID = "QUERY_DLSXCAN";
            this.Text = "frmQuery_DLSXCAN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.rsPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpTHChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTHChung)).EndInit();
            this.tpSuCo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuCo)).EndInit();
            this.tpDLSX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTSQT)).EndInit();
            this.tpNhapKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoiNhap)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            this.rsPanel1.PerformLayout();
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
        private RosySystem.Customize.btExit btExit;
		private RosySystem.Control.rsPanel rsPanel2;
		private RosySystem.Control.rsDataGridView dgvTHChung;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTHChung;
        private System.Windows.Forms.TabPage tpSuCo;
        private RosySystem.Control.rsDataGridView dgvSuCo;
        private System.Windows.Forms.TabPage tpDLSX;
        private System.Windows.Forms.TabPage tpNhapKho;
        private RosySystem.Control.rsDataGridView dgvTSQT;
        private RosySystem.Control.rsDataGridView dgvPhoiNhap;
	}
}