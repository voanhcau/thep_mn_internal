namespace RosyModule.HRM
{
    partial class frmHDLD_Edit
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
            this.txtLy_Do = new RosySystem.Control.rsTextBox();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.txtNgay_Kt = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ky = new RosySystem.Control.rsDateTime();
            this.rsLabel16 = new RosySystem.Control.rsLabel();
            this.rsLabel18 = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.dteNgay_Bd = new RosySystem.Control.rsDateTime();
            this.rsLabel12 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtSo_Hd = new RosySystem.Control.rsTextBox();
            this.txtNguoi_Ky = new RosySystem.Control.rsTextBox();
            this.txtNoi_Dung = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.chkDa_Cham_Dut = new RosySystem.Control.rsCheckbox();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.txtThoi_Gian_Hd = new RosySystem.Control.rsTextBoxEnum();
            this.txtLoai_Hd = new RosySystem.Control.rsTextBoxEnum();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // txtLy_Do
            // 
            this.txtLy_Do.AutoDropDown = null;
            this.txtLy_Do.Location = new System.Drawing.Point(121, 288);
            this.txtLy_Do.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLy_Do.Multiline = true;
            this.txtLy_Do.Name = "txtLy_Do";
            this.txtLy_Do.Size = new System.Drawing.Size(507, 40);
            this.txtLy_Do.TabIndex = 12;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(121, 223);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(507, 40);
            this.txtGhi_Chu.TabIndex = 10;
            // 
            // txtNgay_Kt
            // 
            this.txtNgay_Kt.bAllowEmpty = false;
            this.txtNgay_Kt.bSelectOnFocus = false;
            this.txtNgay_Kt.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.txtNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Kt.Location = new System.Drawing.Point(121, 196);
            this.txtNgay_Kt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtNgay_Kt.Mask = "00/00/0000";
            this.txtNgay_Kt.Name = "txtNgay_Kt";
            this.txtNgay_Kt.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Kt.TabIndex = 8;
            // 
            // dteNgay_Ky
            // 
            this.dteNgay_Ky.bAllowEmpty = false;
            this.dteNgay_Ky.bSelectOnFocus = false;
            this.dteNgay_Ky.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ky.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ky.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ky.Location = new System.Drawing.Point(121, 126);
            this.dteNgay_Ky.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ky.Mask = "00/00/0000";
            this.dteNgay_Ky.Name = "dteNgay_Ky";
            this.dteNgay_Ky.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Ky.TabIndex = 4;
            // 
            // rsLabel16
            // 
            this.rsLabel16.AutoEllipsis = true;
            this.rsLabel16.AutoSize = true;
            this.rsLabel16.Location = new System.Drawing.Point(20, 231);
            this.rsLabel16.Name = "rsLabel16";
            this.rsLabel16.Size = new System.Drawing.Size(43, 13);
            this.rsLabel16.TabIndex = 25;
            this.rsLabel16.Tag = "Ghi_Chu";
            this.rsLabel16.Text = "Chi chú";
            this.rsLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel18
            // 
            this.rsLabel18.AutoEllipsis = true;
            this.rsLabel18.AutoSize = true;
            this.rsLabel18.Location = new System.Drawing.Point(20, 291);
            this.rsLabel18.Name = "rsLabel18";
            this.rsLabel18.Size = new System.Drawing.Size(33, 13);
            this.rsLabel18.TabIndex = 28;
            this.rsLabel18.Tag = "Ly_Do";
            this.rsLabel18.Text = "Lý do";
            this.rsLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(20, 199);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(74, 13);
            this.rsLabel6.TabIndex = 17;
            this.rsLabel6.Tag = "Ngay_KT";
            this.rsLabel6.Text = "Ngày kết thúc";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Bd
            // 
            this.dteNgay_Bd.bAllowEmpty = false;
            this.dteNgay_Bd.bSelectOnFocus = false;
            this.dteNgay_Bd.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Bd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Bd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Bd.Location = new System.Drawing.Point(121, 173);
            this.dteNgay_Bd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Bd.Mask = "00/00/0000";
            this.dteNgay_Bd.Name = "dteNgay_Bd";
            this.dteNgay_Bd.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Bd.TabIndex = 7;
            // 
            // rsLabel12
            // 
            this.rsLabel12.AutoEllipsis = true;
            this.rsLabel12.AutoSize = true;
            this.rsLabel12.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel12.Location = new System.Drawing.Point(162, 107);
            this.rsLabel12.Name = "rsLabel12";
            this.rsLabel12.Size = new System.Drawing.Size(443, 13);
            this.rsLabel12.TabIndex = 10;
            this.rsLabel12.Text = "0-Hợp đồng thử việc, 1-Hợp đồng lao động chính thức, 3-Hợp đồng thời vụ, 4-Bán th" +
    "ời gian";
            this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(20, 176);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(72, 13);
            this.rsLabel7.TabIndex = 15;
            this.rsLabel7.Tag = "Ngay_BD";
            this.rsLabel7.Text = "Ngày bắt đầu";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(450, 376);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(178, 43);
            this.btgAccept.TabIndex = 31;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(304, 129);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(49, 13);
            this.rsLabel4.TabIndex = 13;
            this.rsLabel4.Tag = "Nguoi_Ky";
            this.rsLabel4.Text = "Người ký";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(20, 107);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(76, 13);
            this.rsLabel3.TabIndex = 8;
            this.rsLabel3.Tag = "Loai_HD";
            this.rsLabel3.Text = "Loại hợp đồng";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(20, 129);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(46, 13);
            this.rsLabel11.TabIndex = 11;
            this.rsLabel11.Tag = "Ngay_Ky";
            this.rsLabel11.Text = "Ngày ký";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(20, 67);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(99, 13);
            this.rsLabel5.TabIndex = 5;
            this.rsLabel5.Tag = "Noi_Dung_HD";
            this.rsLabel5.Text = "Nội dung hợp đồng";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(20, 45);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(69, 13);
            this.rsLabel2.TabIndex = 0;
            this.rsLabel2.Tag = "So_HD";
            this.rsLabel2.Text = "Số hợp đồng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Hd
            // 
            this.txtSo_Hd.AutoDropDown = null;
            this.txtSo_Hd.Location = new System.Drawing.Point(121, 42);
            this.txtSo_Hd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Hd.Name = "txtSo_Hd";
            this.txtSo_Hd.Size = new System.Drawing.Size(164, 20);
            this.txtSo_Hd.TabIndex = 0;
            // 
            // txtNguoi_Ky
            // 
            this.txtNguoi_Ky.AutoDropDown = null;
            this.txtNguoi_Ky.Location = new System.Drawing.Point(358, 126);
            this.txtNguoi_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNguoi_Ky.Name = "txtNguoi_Ky";
            this.txtNguoi_Ky.Size = new System.Drawing.Size(270, 20);
            this.txtNguoi_Ky.TabIndex = 5;
            // 
            // txtNoi_Dung
            // 
            this.txtNoi_Dung.AutoDropDown = null;
            this.txtNoi_Dung.Location = new System.Drawing.Point(121, 64);
            this.txtNoi_Dung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNoi_Dung.Multiline = true;
            this.txtNoi_Dung.Name = "txtNoi_Dung";
            this.txtNoi_Dung.Size = new System.Drawing.Size(507, 38);
            this.txtNoi_Dung.TabIndex = 2;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(20, 23);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(72, 13);
            this.rsLabel1.TabIndex = 2;
            this.rsLabel1.Tag = "Ma_Dt_CbNv";
            this.rsLabel1.Text = "Mã nhân viên";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(121, 20);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt_CbNv.TabIndex = 1;
            // 
            // chkDa_Cham_Dut
            // 
            this.chkDa_Cham_Dut.AutoSize = true;
            this.chkDa_Cham_Dut.ForeColor = System.Drawing.Color.Red;
            this.chkDa_Cham_Dut.Location = new System.Drawing.Point(121, 268);
            this.chkDa_Cham_Dut.Name = "chkDa_Cham_Dut";
            this.chkDa_Cham_Dut.Size = new System.Drawing.Size(136, 17);
            this.chkDa_Cham_Dut.TabIndex = 11;
            this.chkDa_Cham_Dut.Tag = "Da_Cham_Dut";
            this.chkDa_Cham_Dut.Text = "Đã chấm dứt hợp đồng";
            this.chkDa_Cham_Dut.UseVisualStyleBackColor = true;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(20, 151);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(100, 13);
            this.rsLabel8.TabIndex = 8;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Thời gian hợp đồng";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel9.Location = new System.Drawing.Point(162, 151);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(244, 13);
            this.rsLabel9.TabIndex = 10;
            this.rsLabel9.Text = "1- 1 Tháng, 2- 2 Tháng, 3- 3 Tháng, 4-Vô thời hạn";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtThoi_Gian_Hd
            // 
            this.txtThoi_Gian_Hd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThoi_Gian_Hd.AutoDropDown = null;
            this.txtThoi_Gian_Hd.InputMask = "1,2,3,4";
            this.txtThoi_Gian_Hd.Location = new System.Drawing.Point(121, 149);
            this.txtThoi_Gian_Hd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtThoi_Gian_Hd.Name = "txtThoi_Gian_Hd";
            this.txtThoi_Gian_Hd.Size = new System.Drawing.Size(29, 20);
            this.txtThoi_Gian_Hd.TabIndex = 6;
            this.txtThoi_Gian_Hd.Text = "4";
            // 
            // txtLoai_Hd
            // 
            this.txtLoai_Hd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoai_Hd.AutoDropDown = null;
            this.txtLoai_Hd.InputMask = "0,1,2,3,4";
            this.txtLoai_Hd.Location = new System.Drawing.Point(121, 104);
            this.txtLoai_Hd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtLoai_Hd.Name = "txtLoai_Hd";
            this.txtLoai_Hd.Size = new System.Drawing.Size(29, 20);
            this.txtLoai_Hd.TabIndex = 3;
            this.txtLoai_Hd.Text = "1";
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(246, 23);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(76, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 10;
            this.lbtTen_Dt_CbNv.Text = "Tên nhân viên";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmHDLD_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 430);
            this.Controls.Add(this.txtLoai_Hd);
            this.Controls.Add(this.txtThoi_Gian_Hd);
            this.Controls.Add(this.chkDa_Cham_Dut);
            this.Controls.Add(this.txtLy_Do);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.txtNgay_Kt);
            this.Controls.Add(this.dteNgay_Ky);
            this.Controls.Add(this.rsLabel16);
            this.Controls.Add(this.rsLabel18);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.dteNgay_Bd);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.rsLabel12);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel8);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.rsLabel11);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtSo_Hd);
            this.Controls.Add(this.txtNguoi_Ky);
            this.Controls.Add(this.txtNoi_Dung);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Name = "frmHDLD_Edit";
            this.Text = "frmHDLD_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private RosySystem.Control.rsTextBox txtLy_Do;
		private RosySystem.Control.rsTextBox txtGhi_Chu;
		private RosySystem.Control.rsDateTime txtNgay_Kt;
		private RosySystem.Control.rsDateTime dteNgay_Ky;
        private RosySystem.Control.rsLabel rsLabel16;
        private RosySystem.Control.rsLabel rsLabel18;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsDateTime dteNgay_Bd;
		private RosySystem.Control.rsLabel rsLabel12;
		private RosySystem.Control.rsLabel rsLabel7;
		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel11;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtSo_Hd;
        private RosySystem.Control.rsTextBox txtNguoi_Ky;
		private RosySystem.Control.rsTextBox txtNoi_Dung;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsCheckbox chkDa_Cham_Dut;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsTextBoxEnum txtThoi_Gian_Hd;
        private RosySystem.Control.rsTextBoxEnum txtLoai_Hd;
        private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;

	}
}