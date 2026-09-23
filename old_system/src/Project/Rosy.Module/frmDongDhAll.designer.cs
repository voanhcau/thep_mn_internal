namespace RosyModule
{
    partial class frmDongDhAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDongDhAll));
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtGhi_Chu_Huy = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtMa_Kho = new RosySystem.Control.rsTextBox();
            this.rsLabel22 = new RosySystem.Control.rsLabel();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbAll = new RosySystem.Control.rsRadioButton();
            this.rdbXe = new RosySystem.Control.rsRadioButton();
            this.rdbTau = new RosySystem.Control.rsRadioButton();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.dgvInheritVoucher = new RosySystem.Control.rsDataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.chkIs_NotGK = new System.Windows.Forms.CheckBox();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbIn_Tien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Location = new System.Drawing.Point(3, 3);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(878, 512);
            this.rsTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkIs_NotGK);
            this.tabPage1.Controls.Add(this.txtGhi_Chu_Huy);
            this.tabPage1.Controls.Add(this.rsLabel2);
            this.tabPage1.Controls.Add(this.txtMa_Kho);
            this.tabPage1.Controls.Add(this.rsLabel22);
            this.tabPage1.Controls.Add(this.gbIn_Tien);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Controls.Add(this.rsLabel1);
            this.tabPage1.Controls.Add(this.lblNgay_Ct);
            this.tabPage1.Controls.Add(this.dteNgay_Ct2);
            this.tabPage1.Controls.Add(this.dteNgay_Ct1);
            this.tabPage1.Controls.Add(this.dgvInheritVoucher);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chọn dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtGhi_Chu_Huy
            // 
            this.txtGhi_Chu_Huy.AutoDropDown = null;
            this.txtGhi_Chu_Huy.Location = new System.Drawing.Point(364, 16);
            this.txtGhi_Chu_Huy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu_Huy.MaxLength = 20;
            this.txtGhi_Chu_Huy.Name = "txtGhi_Chu_Huy";
            this.txtGhi_Chu_Huy.Size = new System.Drawing.Size(501, 20);
            this.txtGhi_Chu_Huy.TabIndex = 3;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(279, 19);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(80, 13);
            this.rsLabel2.TabIndex = 151;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Lý do đóng ĐH";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Kho
            // 
            this.txtMa_Kho.AutoDropDown = null;
            this.txtMa_Kho.Location = new System.Drawing.Point(71, 38);
            this.txtMa_Kho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho.MaxLength = 20;
            this.txtMa_Kho.Name = "txtMa_Kho";
            this.txtMa_Kho.Size = new System.Drawing.Size(118, 20);
            this.txtMa_Kho.TabIndex = 4;
            // 
            // rsLabel22
            // 
            this.rsLabel22.AutoEllipsis = true;
            this.rsLabel22.AutoSize = true;
            this.rsLabel22.Location = new System.Drawing.Point(14, 41);
            this.rsLabel22.Name = "rsLabel22";
            this.rsLabel22.Size = new System.Drawing.Size(43, 13);
            this.rsLabel22.TabIndex = 149;
            this.rsLabel22.Tag = "Ma_Kho";
            this.rsLabel22.Text = "Mã kho";
            this.rsLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.rdbAll);
            this.gbIn_Tien.Controls.Add(this.rdbXe);
            this.gbIn_Tien.Controls.Add(this.rdbTau);
            this.gbIn_Tien.Location = new System.Drawing.Point(23, 63);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(367, 42);
            this.gbIn_Tien.TabIndex = 5;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn hình thức giao";
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbAll.Location = new System.Drawing.Point(282, 18);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(55, 17);
            this.rdbAll.TabIndex = 2;
            this.rdbAll.Tag = "";
            this.rdbAll.Text = "Tất cả";
            this.rdbAll.UnChecked = true;
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbXe
            // 
            this.rdbXe.AutoSize = true;
            this.rdbXe.Checked = true;
            this.rdbXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbXe.Location = new System.Drawing.Point(6, 18);
            this.rdbXe.Name = "rdbXe";
            this.rdbXe.Size = new System.Drawing.Size(64, 17);
            this.rdbXe.TabIndex = 2;
            this.rdbXe.TabStop = true;
            this.rdbXe.Tag = "";
            this.rdbXe.Text = "Hàng xe";
            this.rdbXe.UnChecked = false;
            this.rdbXe.UseVisualStyleBackColor = true;
            // 
            // rdbTau
            // 
            this.rdbTau.AutoSize = true;
            this.rdbTau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbTau.Location = new System.Drawing.Point(127, 18);
            this.rdbTau.Name = "rdbTau";
            this.rdbTau.Size = new System.Drawing.Size(68, 17);
            this.rdbTau.TabIndex = 0;
            this.rdbTau.Tag = "";
            this.rdbTau.Text = "Hàng tàu";
            this.rdbTau.UnChecked = true;
            this.rdbTau.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(396, 53);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(92, 52);
            this.btRefresh.TabIndex = 10;
            this.btRefresh.Text = "F5 - Refresh\r\n";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(142, 16);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(53, 13);
            this.rsLabel1.TabIndex = 54;
            this.rsLabel1.Tag = "Ngay_Ct2";
            this.rsLabel1.Text = "Đến ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(20, 16);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct.TabIndex = 54;
            this.lblNgay_Ct.Tag = "Ngay_Ct1";
            this.lblNgay_Ct.Text = "Từ ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(200, 13);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 2;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(71, 13);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct1.TabIndex = 1;
            // 
            // dgvInheritVoucher
            // 
            this.dgvInheritVoucher.AllowUserToAddRows = false;
            this.dgvInheritVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInheritVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInheritVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInheritVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvInheritVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInheritVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInheritVoucher.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInheritVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInheritVoucher.Location = new System.Drawing.Point(3, 111);
            this.dgvInheritVoucher.MultiSelect = false;
            this.dgvInheritVoucher.Name = "dgvInheritVoucher";
            this.dgvInheritVoucher.ReadOnly = true;
            this.dgvInheritVoucher.Size = new System.Drawing.Size(864, 372);
            this.dgvInheritVoucher.strZone = "";
            this.dgvInheritVoucher.TabIndex = 13;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(696, 518);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // chkIs_NotGK
            // 
            this.chkIs_NotGK.AutoSize = true;
            this.chkIs_NotGK.Checked = true;
            this.chkIs_NotGK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIs_NotGK.ForeColor = System.Drawing.Color.OrangeRed;
            this.chkIs_NotGK.Location = new System.Drawing.Point(194, 41);
            this.chkIs_NotGK.Name = "chkIs_NotGK";
            this.chkIs_NotGK.Size = new System.Drawing.Size(198, 17);
            this.chkIs_NotGK.TabIndex = 152;
            this.chkIs_NotGK.Text = "Chỉ lấy các đơn hàng không gửi kho";
            this.chkIs_NotGK.UseVisualStyleBackColor = true;
            // 
            // frmDongDhAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 566);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmDongDhAll";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Kế thừa dữ liệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl rsTabControl1;
		private RosySystem.Control.rsDataGridView dgvInheritVoucher;
        private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsButton btRefresh;
        private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbAll;
        public RosySystem.Control.rsRadioButton rdbXe;
        public RosySystem.Control.rsRadioButton rdbTau;
        private RosySystem.Control.rsTextBox txtMa_Kho;
        private RosySystem.Control.rsLabel rsLabel22;
        private RosySystem.Control.rsTextBox txtGhi_Chu_Huy;
        private RosySystem.Control.rsLabel rsLabel2;
        private System.Windows.Forms.CheckBox chkIs_NotGK;
	}
}

