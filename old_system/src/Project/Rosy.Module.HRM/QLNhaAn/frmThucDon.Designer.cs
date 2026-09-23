namespace RosyModule.HRM
{
    partial class frmThucDon
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
            this.txtTime_Clock = new System.Windows.Forms.Timer(this.components);
            this.tpSoXuatAn = new System.Windows.Forms.TabPage();
            this.dgvThucDonNV = new RosySystem.Control.rsDataGridView();
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tpThucDon = new System.Windows.Forms.TabPage();
            this.dgvThucDon = new RosySystem.Control.rsDataGridView();
            this.tpThucPham = new System.Windows.Forms.TabPage();
            this.dgvThucPham = new RosySystem.Control.rsDataGridView();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.rsGroupBox1 = new RosySystem.Control.rsGroupBox();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.btRefresh = new RosySystem.Customize.btEdit();
            this.btExit = new RosySystem.Customize.btEdit();
            this.btDelete = new RosySystem.Customize.btEdit();
            this.btPrint = new RosySystem.Customize.btEdit();
            this.btNew = new RosySystem.Customize.btEdit();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btSuatAn = new RosySystem.Customize.btEdit();
            this.btTinh = new RosySystem.Customize.btEdit();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.tpSoXuatAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDonNV)).BeginInit();
            this.rsTabControl1.SuspendLayout();
            this.tpThucDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
            this.tpThucPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucPham)).BeginInit();
            this.rsGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTime_Clock
            // 
            this.txtTime_Clock.Enabled = true;
            this.txtTime_Clock.Interval = 1000;
            // 
            // tpSoXuatAn
            // 
            this.tpSoXuatAn.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpSoXuatAn.Controls.Add(this.dgvThucDonNV);
            this.tpSoXuatAn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpSoXuatAn.Location = new System.Drawing.Point(4, 29);
            this.tpSoXuatAn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpSoXuatAn.Name = "tpSoXuatAn";
            this.tpSoXuatAn.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpSoXuatAn.Size = new System.Drawing.Size(1070, 407);
            this.tpSoXuatAn.TabIndex = 1;
            this.tpSoXuatAn.Tag = "";
            this.tpSoXuatAn.Text = "Số xuất ăn";
            this.tpSoXuatAn.UseVisualStyleBackColor = true;
            // 
            // dgvThucDonNV
            // 
            this.dgvThucDonNV.AllowUserToAddRows = false;
            this.dgvThucDonNV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvThucDonNV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThucDonNV.BackgroundColor = System.Drawing.Color.White;
            this.dgvThucDonNV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvThucDonNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucDonNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucDonNV.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvThucDonNV.Location = new System.Drawing.Point(4, 5);
            this.dgvThucDonNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvThucDonNV.MultiSelect = false;
            this.dgvThucDonNV.Name = "dgvThucDonNV";
            this.dgvThucDonNV.ReadOnly = true;
            this.dgvThucDonNV.Size = new System.Drawing.Size(1062, 397);
            this.dgvThucDonNV.strZone = "";
            this.dgvThucDonNV.TabIndex = 4;
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tpThucDon);
            this.rsTabControl1.Controls.Add(this.tpSoXuatAn);
            this.rsTabControl1.Controls.Add(this.tpThucPham);
            this.rsTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsTabControl1.Location = new System.Drawing.Point(2, 102);
            this.rsTabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(1078, 440);
            this.rsTabControl1.TabIndex = 3;
            // 
            // tpThucDon
            // 
            this.tpThucDon.Controls.Add(this.dgvThucDon);
            this.tpThucDon.Location = new System.Drawing.Point(4, 29);
            this.tpThucDon.Name = "tpThucDon";
            this.tpThucDon.Size = new System.Drawing.Size(1070, 407);
            this.tpThucDon.TabIndex = 8;
            this.tpThucDon.Text = "Thực đơn";
            this.tpThucDon.UseVisualStyleBackColor = true;
            // 
            // dgvThucDon
            // 
            this.dgvThucDon.AllowUserToAddRows = false;
            this.dgvThucDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvThucDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThucDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvThucDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucDon.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvThucDon.Location = new System.Drawing.Point(0, 0);
            this.dgvThucDon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvThucDon.MultiSelect = false;
            this.dgvThucDon.Name = "dgvThucDon";
            this.dgvThucDon.ReadOnly = true;
            this.dgvThucDon.Size = new System.Drawing.Size(1070, 407);
            this.dgvThucDon.strZone = "";
            this.dgvThucDon.TabIndex = 5;
            // 
            // tpThucPham
            // 
            this.tpThucPham.Controls.Add(this.dgvThucPham);
            this.tpThucPham.Location = new System.Drawing.Point(4, 29);
            this.tpThucPham.Name = "tpThucPham";
            this.tpThucPham.Size = new System.Drawing.Size(1070, 407);
            this.tpThucPham.TabIndex = 9;
            this.tpThucPham.Text = "Tổng hợp thực phẩm";
            this.tpThucPham.UseVisualStyleBackColor = true;
            // 
            // dgvThucPham
            // 
            this.dgvThucPham.AllowUserToAddRows = false;
            this.dgvThucPham.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvThucPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThucPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvThucPham.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvThucPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucPham.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvThucPham.Location = new System.Drawing.Point(0, 0);
            this.dgvThucPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvThucPham.MultiSelect = false;
            this.dgvThucPham.Name = "dgvThucPham";
            this.dgvThucPham.ReadOnly = true;
            this.dgvThucPham.Size = new System.Drawing.Size(1070, 407);
            this.dgvThucPham.strZone = "";
            this.dgvThucPham.TabIndex = 5;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(22, 29);
            this.lblNgay_Ct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(83, 22);
            this.lblNgay_Ct.TabIndex = 52;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Từ ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsGroupBox1
            // 
            this.rsGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsGroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.rsGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.rsGroupBox1.Controls.Add(this.dteNgay_Ct2);
            this.rsGroupBox1.Controls.Add(this.dteNgay_Ct1);
            this.rsGroupBox1.Controls.Add(this.rsLabel1);
            this.rsGroupBox1.Controls.Add(this.btRefresh);
            this.rsGroupBox1.Controls.Add(this.lblNgay_Ct);
            this.rsGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsGroupBox1.Location = new System.Drawing.Point(12, 15);
            this.rsGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rsGroupBox1.Name = "rsGroupBox1";
            this.rsGroupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rsGroupBox1.Size = new System.Drawing.Size(1068, 77);
            this.rsGroupBox1.TabIndex = 0;
            this.rsGroupBox1.TabStop = false;
            this.rsGroupBox1.Text = "Thông tin chung";
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(115, 26);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(121, 28);
            this.dteNgay_Ct1.TabIndex = 254;
            // 
            // btRefresh
            // 
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(613, 20);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(132, 47);
            this.btRefresh.TabIndex = 253;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "Edit.png";
            this.btExit.Location = new System.Drawing.Point(943, 552);
            this.btExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(132, 62);
            this.btExit.TabIndex = 253;
            this.btExit.Tag = "";
            this.btExit.Text = "Thoát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Edit.png";
            this.btDelete.Location = new System.Drawing.Point(358, 552);
            this.btDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(132, 62);
            this.btDelete.TabIndex = 253;
            this.btDelete.Tag = "";
            this.btDelete.Text = "Xóa";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "Edit.png";
            this.btPrint.Location = new System.Drawing.Point(492, 552);
            this.btPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(147, 62);
            this.btPrint.TabIndex = 253;
            this.btPrint.Tag = "";
            this.btPrint.Text = "In";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "Edit.png";
            this.btNew.Location = new System.Drawing.Point(88, 552);
            this.btNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(132, 62);
            this.btNew.TabIndex = 253;
            this.btNew.Tag = "";
            this.btNew.Text = "Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.ImageKey = "Edit.png";
            this.btEdit.Location = new System.Drawing.Point(223, 552);
            this.btEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(132, 62);
            this.btEdit.TabIndex = 253;
            this.btEdit.Tag = "";
            this.btEdit.Text = "Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btSuatAn
            // 
            this.btSuatAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSuatAn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSuatAn.ImageKey = "Edit.png";
            this.btSuatAn.Location = new System.Drawing.Point(642, 552);
            this.btSuatAn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSuatAn.Name = "btSuatAn";
            this.btSuatAn.Size = new System.Drawing.Size(147, 62);
            this.btSuatAn.TabIndex = 253;
            this.btSuatAn.Tag = "";
            this.btSuatAn.Text = "Nhập số xuất ăn";
            this.btSuatAn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSuatAn.UseVisualStyleBackColor = true;
            // 
            // btTinh
            // 
            this.btTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTinh.ImageKey = "Edit.png";
            this.btTinh.Location = new System.Drawing.Point(793, 552);
            this.btTinh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btTinh.Name = "btTinh";
            this.btTinh.Size = new System.Drawing.Size(147, 62);
            this.btTinh.TabIndex = 254;
            this.btTinh.Tag = "";
            this.btTinh.Text = "Lượng TP đầu vào";
            this.btTinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btTinh.UseVisualStyleBackColor = true;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(282, 29);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(95, 22);
            this.rsLabel1.TabIndex = 52;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Đến ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(375, 26);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(121, 28);
            this.dteNgay_Ct2.TabIndex = 254;
            // 
            // frmThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 636);
            this.ControlBox = false;
            this.Controls.Add(this.btTinh);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btSuatAn);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.rsGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "frmThucDon";
            this.Object_ID = "THUCDON";
            this.ShowInTaskbar = true;
            this.Text = "frmThucDon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tpSoXuatAn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDonNV)).EndInit();
            this.rsTabControl1.ResumeLayout(false);
            this.tpThucDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).EndInit();
            this.tpThucPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucPham)).EndInit();
            this.rsGroupBox1.ResumeLayout(false);
            this.rsGroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Timer txtTime_Clock;
        private System.Windows.Forms.TabPage tpSoXuatAn;
        private RosySystem.Control.rsDataGridView dgvThucDonNV;
        private RosySystem.Control.rsTabControl rsTabControl1;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsGroupBox rsGroupBox1;
        private RosySystem.Customize.btEdit btExit;
        private System.Windows.Forms.TabPage tpThucDon;
        private RosySystem.Control.rsDataGridView dgvThucDon;
        private RosySystem.Customize.btEdit btDelete;
        private RosySystem.Customize.btEdit btPrint;
        private RosySystem.Customize.btEdit btRefresh;
        private RosySystem.Customize.btEdit btNew;
        private RosySystem.Customize.btEdit btEdit;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Customize.btEdit btSuatAn;
        private RosySystem.Customize.btEdit btTinh;
        private System.Windows.Forms.TabPage tpThucPham;
        private RosySystem.Control.rsDataGridView dgvThucPham;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsLabel rsLabel1;


	}
}