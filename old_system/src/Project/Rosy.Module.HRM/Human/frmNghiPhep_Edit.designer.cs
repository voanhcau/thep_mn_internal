namespace RosyModule.HRM
{
    partial class frmNghiPhep_Edit
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
			this.numSo_Ngay_Nghi = new RosySystem.Control.rsNumericUpdown();
			this.cboLoai_Phep = new RosySystem.Control.rsComboBox();
			this.chkCo_Tinh_Luong = new RosySystem.Control.rsCheckbox();
			this.chkCo_Phep = new RosySystem.Control.rsCheckbox();
			this.dteNgay_Ky = new RosySystem.Control.rsDateTime();
			this.dteNgay_Kt = new RosySystem.Control.rsDateTime();
			this.dteNgay_Bd = new RosySystem.Control.rsDateTime();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.rsLabel8 = new RosySystem.Control.rsLabel();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.txtNoi_Dung = new RosySystem.Control.rsTextBox();
			this.txtNguoi_Duyet = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
			this.rsLabel9 = new RosySystem.Control.rsLabel();
			this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
			this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
			this.rsLabel10 = new RosySystem.Control.rsLabel();
			((System.ComponentModel.ISupportInitialize)(this.numSo_Ngay_Nghi)).BeginInit();
			this.SuspendLayout();
			// 
			// numSo_Ngay_Nghi
			// 
			this.numSo_Ngay_Nghi.Location = new System.Drawing.Point(131, 175);
			this.numSo_Ngay_Nghi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Ngay_Nghi.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.numSo_Ngay_Nghi.Name = "numSo_Ngay_Nghi";
			this.numSo_Ngay_Nghi.Size = new System.Drawing.Size(72, 20);
			this.numSo_Ngay_Nghi.TabIndex = 8;
			// 
			// cboLoai_Phep
			// 
			this.cboLoai_Phep.Items.AddRange(new object[] {
            "",
            "Nghỉ khám thai ",
            "Nghỉ tang",
            "Nghỉ sinh con ",
            "Nghỉ khác"});
			this.cboLoai_Phep.Location = new System.Drawing.Point(131, 64);
			this.cboLoai_Phep.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboLoai_Phep.Name = "cboLoai_Phep";
			this.cboLoai_Phep.Size = new System.Drawing.Size(47, 21);
			this.cboLoai_Phep.TabIndex = 2;
			// 
			// chkCo_Tinh_Luong
			// 
			this.chkCo_Tinh_Luong.AutoSize = true;
			this.chkCo_Tinh_Luong.Location = new System.Drawing.Point(131, 222);
			this.chkCo_Tinh_Luong.Name = "chkCo_Tinh_Luong";
			this.chkCo_Tinh_Luong.Size = new System.Drawing.Size(90, 17);
			this.chkCo_Tinh_Luong.TabIndex = 10;
			this.chkCo_Tinh_Luong.Tag = "Co_Tinh_Luong";
			this.chkCo_Tinh_Luong.Text = "Có tính lương";
			this.chkCo_Tinh_Luong.UseVisualStyleBackColor = true;
			// 
			// chkCo_Phep
			// 
			this.chkCo_Phep.AutoSize = true;
			this.chkCo_Phep.Location = new System.Drawing.Point(131, 201);
			this.chkCo_Phep.Name = "chkCo_Phep";
			this.chkCo_Phep.Size = new System.Drawing.Size(90, 17);
			this.chkCo_Phep.TabIndex = 9;
			this.chkCo_Phep.Tag = "Nghi_Co_Phep";
			this.chkCo_Phep.Text = "Nghỉ có phép";
			this.chkCo_Phep.UseVisualStyleBackColor = true;
			// 
			// dteNgay_Ky
			// 
			this.dteNgay_Ky.bAllowEmpty = false;
			this.dteNgay_Ky.bSelectOnFocus = false;
			this.dteNgay_Ky.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ky.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ky.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ky.Location = new System.Drawing.Point(131, 106);
			this.dteNgay_Ky.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.dteNgay_Ky.Mask = "00/00/0000";
			this.dteNgay_Ky.Name = "dteNgay_Ky";
			this.dteNgay_Ky.Size = new System.Drawing.Size(72, 20);
			this.dteNgay_Ky.TabIndex = 4;
			// 
			// dteNgay_Kt
			// 
			this.dteNgay_Kt.bAllowEmpty = false;
			this.dteNgay_Kt.bSelectOnFocus = false;
			this.dteNgay_Kt.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Kt.Location = new System.Drawing.Point(131, 152);
			this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.dteNgay_Kt.Mask = "00/00/0000";
			this.dteNgay_Kt.Name = "dteNgay_Kt";
			this.dteNgay_Kt.Size = new System.Drawing.Size(72, 20);
			this.dteNgay_Kt.TabIndex = 7;
			// 
			// dteNgay_Bd
			// 
			this.dteNgay_Bd.bAllowEmpty = false;
			this.dteNgay_Bd.bSelectOnFocus = false;
			this.dteNgay_Bd.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Bd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Bd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Bd.Location = new System.Drawing.Point(131, 129);
			this.dteNgay_Bd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.dteNgay_Bd.Mask = "00/00/0000";
			this.dteNgay_Bd.Name = "dteNgay_Bd";
			this.dteNgay_Bd.Size = new System.Drawing.Size(72, 20);
			this.dteNgay_Bd.TabIndex = 6;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(339, 295);
			this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(177, 44);
			this.btgAccept.TabIndex = 12;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(26, 109);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(61, 13);
			this.rsLabel4.TabIndex = 128;
			this.rsLabel4.Tag = "Ngay_Duyet";
			this.rsLabel4.Text = "Ngày duyệt";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(26, 45);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(50, 13);
			this.rsLabel5.TabIndex = 125;
			this.rsLabel5.Tag = "Noi_Dung";
			this.rsLabel5.Text = "Nội dung";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel8
			// 
			this.rsLabel8.AutoEllipsis = true;
			this.rsLabel8.AutoSize = true;
			this.rsLabel8.Location = new System.Drawing.Point(26, 155);
			this.rsLabel8.Name = "rsLabel8";
			this.rsLabel8.Size = new System.Drawing.Size(74, 13);
			this.rsLabel8.TabIndex = 127;
			this.rsLabel8.Tag = "Ngay_KT";
			this.rsLabel8.Text = "Ngày kết thúc";
			this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Location = new System.Drawing.Point(26, 132);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(72, 13);
			this.rsLabel7.TabIndex = 129;
			this.rsLabel7.Tag = "Ngay_BD";
			this.rsLabel7.Text = "Ngày bắt đầu";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(245, 109);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(64, 13);
			this.rsLabel6.TabIndex = 126;
			this.rsLabel6.Tag = "Nguoi_Duyet";
			this.rsLabel6.Text = "Người duyệt";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(26, 176);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(69, 13);
			this.rsLabel3.TabIndex = 123;
			this.rsLabel3.Tag = "So_Ngay_Nghi";
			this.rsLabel3.Text = "Số ngày nghỉ";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNoi_Dung
			// 
			this.txtNoi_Dung.Location = new System.Drawing.Point(131, 42);
			this.txtNoi_Dung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNoi_Dung.Name = "txtNoi_Dung";
			this.txtNoi_Dung.Size = new System.Drawing.Size(385, 20);
			this.txtNoi_Dung.TabIndex = 1;
			// 
			// txtNguoi_Duyet
			// 
			this.txtNguoi_Duyet.Location = new System.Drawing.Point(314, 106);
			this.txtNguoi_Duyet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNguoi_Duyet.Name = "txtNguoi_Duyet";
			this.txtNguoi_Duyet.Size = new System.Drawing.Size(202, 20);
			this.txtNguoi_Duyet.TabIndex = 5;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(26, 67);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(77, 13);
			this.rsLabel2.TabIndex = 124;
			this.rsLabel2.Tag = "Loai_Nghi_Phep";
			this.rsLabel2.Text = "Loại nghỉ phép";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(26, 23);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(72, 13);
			this.rsLabel1.TabIndex = 122;
			this.rsLabel1.Tag = "Ma_Dt_CbNv";
			this.rsLabel1.Text = "Mã nhân viên";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Dt_CbNv
			// 
			this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(131, 20);
			this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
			this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Dt_CbNv.TabIndex = 0;
			// 
			// rsLabel9
			// 
			this.rsLabel9.AutoEllipsis = true;
			this.rsLabel9.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel9.Location = new System.Drawing.Point(183, 67);
			this.rsLabel9.Name = "rsLabel9";
			this.rsLabel9.Size = new System.Drawing.Size(372, 31);
			this.rsLabel9.TabIndex = 3;
			this.rsLabel9.Text = "1-Nghỉ ốm, 2-Nghỉ sanh, 3-Nghỉ sảy thai, 4-Nghỉ kết hôn, 5-Nghỉ con kết hôn, 6-Ng" +
				"hỉ chăm sóc con ốm, 7-Nghỉ tang, 8-Nghỉ khác, 9-Nghỉ không phép";
			this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Dt_CbNv
			// 
			this.lbtTen_Dt_CbNv.AutoEllipsis = true;
			this.lbtTen_Dt_CbNv.AutoSize = true;
			this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(256, 24);
			this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
			this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(59, 13);
			this.lbtTen_Dt_CbNv.TabIndex = 130;
			this.lbtTen_Dt_CbNv.Text = "Ten_CbNv";
			this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtGhi_Chu
			// 
			this.txtGhi_Chu.Location = new System.Drawing.Point(131, 242);
			this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtGhi_Chu.Multiline = true;
			this.txtGhi_Chu.Name = "txtGhi_Chu";
			this.txtGhi_Chu.Size = new System.Drawing.Size(385, 39);
			this.txtGhi_Chu.TabIndex = 11;
			// 
			// rsLabel10
			// 
			this.rsLabel10.AutoEllipsis = true;
			this.rsLabel10.AutoSize = true;
			this.rsLabel10.Location = new System.Drawing.Point(26, 245);
			this.rsLabel10.Name = "rsLabel10";
			this.rsLabel10.Size = new System.Drawing.Size(44, 13);
			this.rsLabel10.TabIndex = 125;
			this.rsLabel10.Tag = "Ghi_Chu";
			this.rsLabel10.Text = "Ghi chú";
			this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmNghiPhep_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(566, 347);
			this.Controls.Add(this.numSo_Ngay_Nghi);
			this.Controls.Add(this.cboLoai_Phep);
			this.Controls.Add(this.chkCo_Tinh_Luong);
			this.Controls.Add(this.chkCo_Phep);
			this.Controls.Add(this.dteNgay_Ky);
			this.Controls.Add(this.dteNgay_Kt);
			this.Controls.Add(this.dteNgay_Bd);
			this.Controls.Add(this.rsLabel9);
			this.Controls.Add(this.lbtTen_Dt_CbNv);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.rsLabel10);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.rsLabel8);
			this.Controls.Add(this.rsLabel7);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.txtGhi_Chu);
			this.Controls.Add(this.txtNoi_Dung);
			this.Controls.Add(this.txtNguoi_Duyet);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.txtMa_Dt_CbNv);
			this.Name = "frmNghiPhep_Edit";
			this.Text = "frmNGHIPHEP_Edit";
			((System.ComponentModel.ISupportInitialize)(this.numSo_Ngay_Nghi)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private RosySystem.Control.rsNumericUpdown numSo_Ngay_Nghi;
		private RosySystem.Control.rsComboBox cboLoai_Phep;
		private RosySystem.Control.rsCheckbox chkCo_Tinh_Luong;
		private RosySystem.Control.rsCheckbox chkCo_Phep;
		private RosySystem.Control.rsDateTime dteNgay_Ky;
		private RosySystem.Control.rsDateTime dteNgay_Kt;
		private RosySystem.Control.rsDateTime dteNgay_Bd;
		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBox txtNoi_Dung;
		private RosySystem.Control.rsTextBox txtNguoi_Duyet;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
		private RosySystem.Control.rsLabel rsLabel9;
		private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
		private RosySystem.Control.rsTextBox txtGhi_Chu;
		private RosySystem.Control.rsLabel rsLabel10;

	}
}