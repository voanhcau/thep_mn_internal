namespace RosyModule
{
    partial class frmInherit_Nhap_Barcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInherit_Nhap_Barcode));
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvInheritVoucher = new RosySystem.Control.rsDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInheritVoucherDetail = new RosySystem.Control.rsDataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkExcept_Inherited = new System.Windows.Forms.CheckBox();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.txtMa_Nvu = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtMa_Ct = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.lbtTen_Nvu = new RosySystem.Control.rsLabel();
            this.lbtTen_Ct = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.chkIs_Hach_Toan = new RosySystem.Control.rsCheckbox();
            this.chkIs_CXL = new System.Windows.Forms.CheckBox();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucherDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Controls.Add(this.tabPage2);
            this.rsTabControl1.Location = new System.Drawing.Point(0, 93);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(786, 467);
            this.rsTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvInheritVoucher);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chọn dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvInheritVoucher
            // 
            this.dgvInheritVoucher.AllowUserToAddRows = false;
            this.dgvInheritVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInheritVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgvInheritVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInheritVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInheritVoucher.Location = new System.Drawing.Point(3, 3);
            this.dgvInheritVoucher.MultiSelect = false;
            this.dgvInheritVoucher.Name = "dgvInheritVoucher";
            this.dgvInheritVoucher.ReadOnly = true;
            this.dgvInheritVoucher.Size = new System.Drawing.Size(772, 435);
            this.dgvInheritVoucher.strZone = "";
            this.dgvInheritVoucher.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInheritVoucherDetail);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chi tiết";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInheritVoucherDetail
            // 
            this.dgvInheritVoucherDetail.AllowUserToAddRows = false;
            this.dgvInheritVoucherDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInheritVoucherDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInheritVoucherDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvInheritVoucherDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInheritVoucherDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInheritVoucherDetail.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInheritVoucherDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInheritVoucherDetail.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInheritVoucherDetail.Location = new System.Drawing.Point(3, 3);
            this.dgvInheritVoucherDetail.MultiSelect = false;
            this.dgvInheritVoucherDetail.Name = "dgvInheritVoucherDetail";
            this.dgvInheritVoucherDetail.ReadOnly = true;
            this.dgvInheritVoucherDetail.Size = new System.Drawing.Size(772, 435);
            this.dgvInheritVoucherDetail.strZone = "";
            this.dgvInheritVoucherDetail.TabIndex = 6;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // chkExcept_Inherited
            // 
            this.chkExcept_Inherited.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExcept_Inherited.AutoSize = true;
            this.chkExcept_Inherited.Checked = true;
            this.chkExcept_Inherited.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcept_Inherited.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcept_Inherited.ForeColor = System.Drawing.Color.Red;
            this.chkExcept_Inherited.Location = new System.Drawing.Point(506, 3);
            this.chkExcept_Inherited.Name = "chkExcept_Inherited";
            this.chkExcept_Inherited.Size = new System.Drawing.Size(250, 26);
            this.chkExcept_Inherited.TabIndex = 0;
            this.chkExcept_Inherited.TabStop = false;
            this.chkExcept_Inherited.Text = "Loại trừ Barcode đã kế thừa";
            this.chkExcept_Inherited.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(687, 57);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(92, 52);
            this.btRefresh.TabIndex = 69;
            this.btRefresh.Text = "Thực hiện";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // txtMa_Nvu
            // 
            this.txtMa_Nvu.AutoDropDown = null;
            this.txtMa_Nvu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nvu.Location = new System.Drawing.Point(88, 59);
            this.txtMa_Nvu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nvu.MaxLength = 20;
            this.txtMa_Nvu.Name = "txtMa_Nvu";
            this.txtMa_Nvu.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nvu.TabIndex = 68;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(13, 62);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(72, 13);
            this.rsLabel3.TabIndex = 72;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Mã nghiệp vụ";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ct
            // 
            this.txtMa_Ct.AutoDropDown = null;
            this.txtMa_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ct.Location = new System.Drawing.Point(88, 34);
            this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct.MaxLength = 20;
            this.txtMa_Ct.Name = "txtMa_Ct";
            this.txtMa_Ct.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Ct.TabIndex = 65;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(13, 37);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(50, 13);
            this.rsLabel2.TabIndex = 73;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Chứng từ";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Nvu
            // 
            this.lbtTen_Nvu.AutoEllipsis = true;
            this.lbtTen_Nvu.AutoSize = true;
            this.lbtTen_Nvu.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Nvu.Location = new System.Drawing.Point(213, 62);
            this.lbtTen_Nvu.Name = "lbtTen_Nvu";
            this.lbtTen_Nvu.Size = new System.Drawing.Size(76, 13);
            this.lbtTen_Nvu.TabIndex = 67;
            this.lbtTen_Nvu.Text = "Tên nghiệp vụ";
            this.lbtTen_Nvu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Ct
            // 
            this.lbtTen_Ct.AutoEllipsis = true;
            this.lbtTen_Ct.AutoSize = true;
            this.lbtTen_Ct.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Ct.Location = new System.Drawing.Point(213, 38);
            this.lbtTen_Ct.Name = "lbtTen_Ct";
            this.lbtTen_Ct.Size = new System.Drawing.Size(71, 13);
            this.lbtTen_Ct.TabIndex = 66;
            this.lbtTen_Ct.Text = "Tên chứng từ";
            this.lbtTen_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(13, 12);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(53, 13);
            this.rsLabel1.TabIndex = 70;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Đến ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(88, 9);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 64;
            // 
            // chkIs_Hach_Toan
            // 
            this.chkIs_Hach_Toan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIs_Hach_Toan.AutoSize = true;
            this.chkIs_Hach_Toan.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkIs_Hach_Toan.FlatAppearance.BorderSize = 10;
            this.chkIs_Hach_Toan.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.chkIs_Hach_Toan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Hach_Toan.ForeColor = System.Drawing.Color.Red;
            this.chkIs_Hach_Toan.Location = new System.Drawing.Point(506, 24);
            this.chkIs_Hach_Toan.Name = "chkIs_Hach_Toan";
            this.chkIs_Hach_Toan.Size = new System.Drawing.Size(194, 26);
            this.chkIs_Hach_Toan.TabIndex = 75;
            this.chkIs_Hach_Toan.Text = "Tạo phiếu hạch toán";
            this.chkIs_Hach_Toan.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chkIs_Hach_Toan.UseVisualStyleBackColor = true;
            // 
            // chkIs_CXL
            // 
            this.chkIs_CXL.AutoSize = true;
            this.chkIs_CXL.ForeColor = System.Drawing.Color.OrangeRed;
            this.chkIs_CXL.Location = new System.Drawing.Point(329, 12);
            this.chkIs_CXL.Name = "chkIs_CXL";
            this.chkIs_CXL.Size = new System.Drawing.Size(119, 17);
            this.chkIs_CXL.TabIndex = 74;
            this.chkIs_CXL.Text = "Lấy bó thép xử lý lại";
            this.chkIs_CXL.UseVisualStyleBackColor = true;
            // 
            // frmInherit_Nhap_Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.chkIs_Hach_Toan);
            this.Controls.Add(this.chkIs_CXL);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.txtMa_Nvu);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtMa_Ct);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.lbtTen_Nvu);
            this.Controls.Add(this.lbtTen_Ct);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.dteNgay_Ct2);
            this.Controls.Add(this.chkExcept_Inherited);
            this.Controls.Add(this.rsTabControl1);
            this.Name = "frmInherit_Nhap_Barcode";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Kế thừa dữ liệu Barcode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucherDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl rsTabControl1;
		private RosySystem.Control.rsDataGridView dgvInheritVoucher;
		private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkExcept_Inherited;
		private RosySystem.Control.rsButton btRefresh;
		private RosySystem.Control.rsTextBox txtMa_Nvu;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBox txtMa_Ct;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel lbtTen_Nvu;
		private RosySystem.Control.rsLabel lbtTen_Ct;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
		private System.Windows.Forms.TabPage tabPage2;
		private RosySystem.Control.rsDataGridView dgvInheritVoucherDetail;
		private RosySystem.Control.rsCheckbox chkIs_Hach_Toan;
        private System.Windows.Forms.CheckBox chkIs_CXL;
	}
}

