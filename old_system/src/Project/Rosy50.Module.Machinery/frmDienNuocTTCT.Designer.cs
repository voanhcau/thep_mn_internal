namespace RosyModule.Machinery
{
    partial class frmDienNuocTTCT
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
            this.dgvDienNuoc = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.txtMa_Bp_Ct = new RosySystem.Control.rsTextBox();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.rdbNuoc = new RosySystem.Control.rsRadioButton();
            this.rdbAll = new RosySystem.Control.rsRadioButton();
            this.rdbDien = new RosySystem.Control.rsRadioButton();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.btRefresh = new RosySystem.Customize.btNew();
            this.btNew = new RosySystem.Customize.btNew();
            this.btDelete = new RosySystem.Customize.btNew();
            this.btExit = new RosySystem.Customize.btExit();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.rsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDienNuoc)).BeginInit();
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
            this.rsSplitContainer1.Panel2.Controls.Add(this.btNew);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btDelete);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btExit);
            this.rsSplitContainer1.Size = new System.Drawing.Size(962, 562);
            this.rsSplitContainer1.SplitterDistance = 479;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // rsPanel2
            // 
            this.rsPanel2.Controls.Add(this.dgvDienNuoc);
            this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsPanel2.Location = new System.Drawing.Point(3, 48);
            this.rsPanel2.Name = "rsPanel2";
            this.rsPanel2.Size = new System.Drawing.Size(956, 428);
            this.rsPanel2.TabIndex = 2;
            // 
            // dgvDienNuoc
            // 
            this.dgvDienNuoc.AllowUserToAddRows = false;
            this.dgvDienNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDienNuoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDienNuoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDienNuoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDienNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDienNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDienNuoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDienNuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDienNuoc.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDienNuoc.Location = new System.Drawing.Point(0, 0);
            this.dgvDienNuoc.MultiSelect = false;
            this.dgvDienNuoc.Name = "dgvDienNuoc";
            this.dgvDienNuoc.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDienNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDienNuoc.Size = new System.Drawing.Size(956, 428);
            this.dgvDienNuoc.strZone = "";
            this.dgvDienNuoc.TabIndex = 1;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.txtMa_Bp_Ct);
            this.rsPanel1.Controls.Add(this.dteNgay_Ct);
            this.rsPanel1.Controls.Add(this.rdbNuoc);
            this.rsPanel1.Controls.Add(this.rdbAll);
            this.rsPanel1.Controls.Add(this.rdbDien);
            this.rsPanel1.Controls.Add(this.rsLabel1);
            this.rsPanel1.Controls.Add(this.rsLabel2);
            this.rsPanel1.Controls.Add(this.btRefresh);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rsPanel1.Location = new System.Drawing.Point(3, 3);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(956, 45);
            this.rsPanel1.TabIndex = 0;
            // 
            // txtMa_Bp_Ct
            // 
            this.txtMa_Bp_Ct.AutoDropDown = null;
            this.txtMa_Bp_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp_Ct.Location = new System.Drawing.Point(215, 12);
            this.txtMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp_Ct.MaxLength = 20;
            this.txtMa_Bp_Ct.Name = "txtMa_Bp_Ct";
            this.txtMa_Bp_Ct.Size = new System.Drawing.Size(91, 20);
            this.txtMa_Bp_Ct.TabIndex = 285;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(65, 13);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct.TabIndex = 284;
            // 
            // rdbNuoc
            // 
            this.rdbNuoc.AutoSize = true;
            this.rdbNuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbNuoc.Location = new System.Drawing.Point(480, 14);
            this.rdbNuoc.Name = "rdbNuoc";
            this.rdbNuoc.Size = new System.Drawing.Size(50, 17);
            this.rdbNuoc.TabIndex = 283;
            this.rdbNuoc.Tag = "";
            this.rdbNuoc.Text = "Nước";
            this.rdbNuoc.UnChecked = true;
            this.rdbNuoc.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbAll.Location = new System.Drawing.Point(338, 13);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(55, 17);
            this.rdbAll.TabIndex = 283;
            this.rdbAll.TabStop = true;
            this.rdbAll.Tag = "";
            this.rdbAll.Text = "Tất cả";
            this.rdbAll.UnChecked = false;
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbDien
            // 
            this.rdbDien.AutoSize = true;
            this.rdbDien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbDien.Location = new System.Drawing.Point(411, 14);
            this.rdbDien.Name = "rdbDien";
            this.rdbDien.Size = new System.Drawing.Size(46, 17);
            this.rdbDien.TabIndex = 283;
            this.rdbDien.Tag = "";
            this.rdbDien.Text = "Điện";
            this.rdbDien.UnChecked = true;
            this.rdbDien.UseVisualStyleBackColor = true;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(156, 15);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(54, 17);
            this.rsLabel1.TabIndex = 7;
            this.rsLabel1.Text = "Đơn vị";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(19, 15);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(50, 17);
            this.rsLabel2.TabIndex = 7;
            this.rsLabel2.Text = "Ngày ";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(567, 4);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(70, 34);
            this.btRefresh.TabIndex = 5;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "&Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "(none)";
            this.btNew.Location = new System.Drawing.Point(6, 17);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(93, 50);
            this.btNew.TabIndex = 5;
            this.btNew.Tag = "";
            this.btNew.Text = "&Thêm đồng hồ/ vị trí";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "(none)";
            this.btDelete.Location = new System.Drawing.Point(104, 17);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(93, 50);
            this.btDelete.TabIndex = 5;
            this.btDelete.Tag = "";
            this.btDelete.Text = "&Xóa dữ liệu";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(200, 17);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(93, 50);
            this.btExit.TabIndex = 2;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Th&oát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // frmDienNuocTTCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 562);
            this.Controls.Add(this.rsSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDienNuocTTCT";
            this.Object_ID = "DIENNUOCTTCT";
            this.Text = "frmDIENNUOCTT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.rsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDienNuoc)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            this.rsPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
        private RosySystem.Control.rsPanel rsPanel1;
        private RosySystem.Customize.btExit btExit;
        private RosySystem.Control.rsPanel rsPanel2;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Customize.btNew btDelete;
        public RosySystem.Control.rsRadioButton rdbNuoc;
        private RosySystem.Control.rsRadioButton rdbDien;
        private RosySystem.Customize.btNew btRefresh;
        private RosySystem.Control.rsDataGridView dgvDienNuoc;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtMa_Bp_Ct;
        private RosySystem.Customize.btNew btNew;
        private RosySystem.Control.rsRadioButton rdbAll;
	}
}