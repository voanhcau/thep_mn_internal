namespace RosyModule.Machinery
{
	partial class frmQuery_KHVT
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
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.rsPanel2 = new RosySystem.Control.rsPanel();
            this.dgvKHVTPKTDT = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btPrint = new RosySystem.Customize.btNew();
            this.btDuyetKHVT = new RosySystem.Customize.btNew();
            this.btDuyetGD = new RosySystem.Customize.btNew();
            this.btDuyetKTDT = new RosySystem.Customize.btNew();
            this.btFilter = new RosySystem.Customize.btNew();
            this.btExit = new RosySystem.Customize.btExit();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.numNam = new RosySystem.Control.rsTextBoxNumber();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.rsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHVTPKTDT)).BeginInit();
            this.rsPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsSplitContainer1
            // 
            this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.rsSplitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.rsSplitContainer1.Name = "rsSplitContainer1";
            this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer1.Panel1
            // 
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel2);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel1);
            this.rsSplitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // rsSplitContainer1.Panel2
            // 
            this.rsSplitContainer1.Panel2.Controls.Add(this.btPrint);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btDuyetKHVT);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btDuyetGD);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btDuyetKTDT);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btFilter);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btExit);
            this.rsSplitContainer1.Size = new System.Drawing.Size(1045, 692);
            this.rsSplitContainer1.SplitterDistance = 590;
            this.rsSplitContainer1.SplitterWidth = 5;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // rsPanel2
            // 
            this.rsPanel2.Controls.Add(this.dgvKHVTPKTDT);
            this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsPanel2.Location = new System.Drawing.Point(4, 59);
            this.rsPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.rsPanel2.Name = "rsPanel2";
            this.rsPanel2.Size = new System.Drawing.Size(1037, 527);
            this.rsPanel2.TabIndex = 2;
            // 
            // dgvKHVTPKTDT
            // 
            this.dgvKHVTPKTDT.AllowUserToAddRows = false;
            this.dgvKHVTPKTDT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKHVTPKTDT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKHVTPKTDT.BackgroundColor = System.Drawing.Color.White;
            this.dgvKHVTPKTDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKHVTPKTDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKHVTPKTDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKHVTPKTDT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKHVTPKTDT.Location = new System.Drawing.Point(0, 0);
            this.dgvKHVTPKTDT.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKHVTPKTDT.MultiSelect = false;
            this.dgvKHVTPKTDT.Name = "dgvKHVTPKTDT";
            this.dgvKHVTPKTDT.ReadOnly = true;
            this.dgvKHVTPKTDT.Size = new System.Drawing.Size(1037, 527);
            this.dgvKHVTPKTDT.strZone = "";
            this.dgvKHVTPKTDT.TabIndex = 0;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.numNam);
            this.rsPanel1.Controls.Add(this.dteNgay_Ct2);
            this.rsPanel1.Controls.Add(this.rsLabel2);
            this.rsPanel1.Controls.Add(this.dteNgay_Ct1);
            this.rsPanel1.Controls.Add(this.rsLabel3);
            this.rsPanel1.Controls.Add(this.rsLabel1);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rsPanel1.Location = new System.Drawing.Point(4, 4);
            this.rsPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(1037, 55);
            this.rsPanel1.TabIndex = 0;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(597, 12);
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
            this.rsLabel2.Location = new System.Drawing.Point(488, 17);
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
            this.dteNgay_Ct1.Location = new System.Drawing.Point(350, 12);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(129, 30);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(254, 17);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(75, 20);
            this.rsLabel1.TabIndex = 7;
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "(none)";
            this.btPrint.Location = new System.Drawing.Point(510, 6);
            this.btPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(124, 62);
            this.btPrint.TabIndex = 8;
            this.btPrint.Tag = "";
            this.btPrint.Text = "&In phiếu";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btDuyetKHVT
            // 
            this.btDuyetKHVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDuyetKHVT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDuyetKHVT.ImageKey = "(none)";
            this.btDuyetKHVT.Location = new System.Drawing.Point(258, 6);
            this.btDuyetKHVT.Margin = new System.Windows.Forms.Padding(4);
            this.btDuyetKHVT.Name = "btDuyetKHVT";
            this.btDuyetKHVT.Size = new System.Drawing.Size(124, 62);
            this.btDuyetKHVT.TabIndex = 7;
            this.btDuyetKHVT.Tag = "";
            this.btDuyetKHVT.Text = "&Duyệt PKHVT";
            this.btDuyetKHVT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDuyetKHVT.UseVisualStyleBackColor = true;
            // 
            // btDuyetGD
            // 
            this.btDuyetGD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDuyetGD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDuyetGD.ImageKey = "(none)";
            this.btDuyetGD.Location = new System.Drawing.Point(385, 6);
            this.btDuyetGD.Margin = new System.Windows.Forms.Padding(4);
            this.btDuyetGD.Name = "btDuyetGD";
            this.btDuyetGD.Size = new System.Drawing.Size(124, 62);
            this.btDuyetGD.TabIndex = 6;
            this.btDuyetGD.Tag = "";
            this.btDuyetGD.Text = "&Duyệt Tổng Giám Đốc";
            this.btDuyetGD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDuyetGD.UseVisualStyleBackColor = true;
            // 
            // btDuyetKTDT
            // 
            this.btDuyetKTDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDuyetKTDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDuyetKTDT.ImageKey = "(none)";
            this.btDuyetKTDT.Location = new System.Drawing.Point(131, 6);
            this.btDuyetKTDT.Margin = new System.Windows.Forms.Padding(4);
            this.btDuyetKTDT.Name = "btDuyetKTDT";
            this.btDuyetKTDT.Size = new System.Drawing.Size(124, 62);
            this.btDuyetKTDT.TabIndex = 5;
            this.btDuyetKTDT.Tag = "";
            this.btDuyetKTDT.Text = "&Duyệt PKTDT";
            this.btDuyetKTDT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDuyetKTDT.UseVisualStyleBackColor = true;
            // 
            // btFilter
            // 
            this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFilter.ImageKey = "New.png";
            this.btFilter.Location = new System.Drawing.Point(5, 6);
            this.btFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(124, 62);
            this.btFilter.TabIndex = 4;
            this.btFilter.Tag = "";
            this.btFilter.Text = "&Tập hợp dữ liệu";
            this.btFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(637, 6);
            this.btExit.Margin = new System.Windows.Forms.Padding(4);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(124, 62);
            this.btExit.TabIndex = 2;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Th&oát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // rsLabel3
            // 
            this.rsLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(9, 17);
            this.rsLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(133, 20);
            this.rsLabel3.TabIndex = 7;
            this.rsLabel3.Text = "Năm lập KHVT";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNam
            // 
            this.numNam.AcceptsTab = true;
            this.numNam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numNam.AutoDropDown = null;
            this.numNam.bFormat = true;
            this.numNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNam.Location = new System.Drawing.Point(172, 12);
            this.numNam.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numNam.Multiline = true;
            this.numNam.Name = "numNam";
            this.numNam.Scale = 0;
            this.numNam.Size = new System.Drawing.Size(81, 30);
            this.numNam.TabIndex = 21;
            this.numNam.Text = "0";
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam.Value = 0D;
            // 
            // frmQuery_KHVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 692);
            this.Controls.Add(this.rsSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmQuery_KHVT";
            this.Object_ID = "KHVTKTDT";
            this.Text = "frmQuery_KHVT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.rsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHVTPKTDT)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            this.rsPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
        private RosySystem.Control.rsPanel rsPanel1;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Customize.btExit btExit;
		private RosySystem.Control.rsPanel rsPanel2;
		private RosySystem.Control.rsDataGridView dgvKHVTPKTDT;
        private RosySystem.Customize.btNew btPrint;
        private RosySystem.Customize.btNew btDuyetKHVT;
        private RosySystem.Customize.btNew btDuyetGD;
        private RosySystem.Customize.btNew btDuyetKTDT;
        private RosySystem.Customize.btNew btFilter;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBoxNumber numNam;
	}
}