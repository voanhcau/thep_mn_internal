namespace RosyModule.Salary
{
    partial class frmNVKChamCong_Edit
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
            this.dteTu_Ngay = new RosySystem.Control.rsDateTime();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabelName();
            this.txtTinh_Trang_Cong = new RosySystem.Control.rsTextBox();
            this.lbtTinh_Trang_Cong = new RosySystem.Control.rsLabelName();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteDen_Ngay = new RosySystem.Control.rsDateTime();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.lbtTen_TNLD = new RosySystem.Control.rsLabelName();
            this.txtMa_TNLD = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtDia_Diem_Cong = new RosySystem.Control.rsTextBox();
            this.chkCoT7 = new RosySystem.Control.rsCheckbox();
            this.SuspendLayout();
            // 
            // dteTu_Ngay
            // 
            this.dteTu_Ngay.bAllowEmpty = true;
            this.dteTu_Ngay.bSelectOnFocus = false;
            this.dteTu_Ngay.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteTu_Ngay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteTu_Ngay.Location = new System.Drawing.Point(153, 50);
            this.dteTu_Ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteTu_Ngay.Mask = "00/00/0000";
            this.dteTu_Ngay.Name = "dteTu_Ngay";
            this.dteTu_Ngay.Size = new System.Drawing.Size(67, 20);
            this.dteTu_Ngay.TabIndex = 1;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(25, 53);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(46, 13);
            this.lblDien_Giai.TabIndex = 73;
            this.lblDien_Giai.Tag = "";
            this.lblDien_Giai.Text = "Từ ngày";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(153, 24);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.MaxLength = 20;
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Location = new System.Drawing.Point(25, 27);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(72, 13);
            this.lblTk.TabIndex = 70;
            this.lblTk.Tag = "Ma_Dt_CbNv";
            this.lblTk.Text = "Mã nhân viên";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(498, 226);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 43);
            this.btgAccept.TabIndex = 7;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(254, 27);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(87, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 6;
            this.lbtTen_Dt_CbNv.Tag = "";
            this.lbtTen_Dt_CbNv.Text = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTinh_Trang_Cong
            // 
            this.txtTinh_Trang_Cong.AutoDropDown = null;
            this.txtTinh_Trang_Cong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTinh_Trang_Cong.Location = new System.Drawing.Point(153, 77);
            this.txtTinh_Trang_Cong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTinh_Trang_Cong.MaxLength = 20;
            this.txtTinh_Trang_Cong.Name = "txtTinh_Trang_Cong";
            this.txtTinh_Trang_Cong.Size = new System.Drawing.Size(96, 20);
            this.txtTinh_Trang_Cong.TabIndex = 3;
            // 
            // lbtTinh_Trang_Cong
            // 
            this.lbtTinh_Trang_Cong.AutoSize = true;
            this.lbtTinh_Trang_Cong.ForeColor = System.Drawing.Color.Blue;
            this.lbtTinh_Trang_Cong.Location = new System.Drawing.Point(260, 80);
            this.lbtTinh_Trang_Cong.Name = "lbtTinh_Trang_Cong";
            this.lbtTinh_Trang_Cong.Size = new System.Drawing.Size(56, 13);
            this.lbtTinh_Trang_Cong.TabIndex = 75;
            this.lbtTinh_Trang_Cong.Tag = "";
            this.lbtTinh_Trang_Cong.Text = "txtTen_Tn";
            this.lbtTinh_Trang_Cong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(25, 80);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(82, 13);
            this.rsLabel1.TabIndex = 76;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Tình trạng công";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(224, 56);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(53, 13);
            this.rsLabel2.TabIndex = 73;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Đến ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteDen_Ngay
            // 
            this.dteDen_Ngay.bAllowEmpty = true;
            this.dteDen_Ngay.bSelectOnFocus = false;
            this.dteDen_Ngay.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteDen_Ngay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteDen_Ngay.Location = new System.Drawing.Point(284, 53);
            this.dteDen_Ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteDen_Ngay.Mask = "00/00/0000";
            this.dteDen_Ngay.Name = "dteDen_Ngay";
            this.dteDen_Ngay.Size = new System.Drawing.Size(67, 20);
            this.dteDen_Ngay.TabIndex = 2;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(25, 179);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(44, 13);
            this.rsLabel3.TabIndex = 77;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Ghi chú";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(153, 177);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.MaxLength = 200;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(526, 20);
            this.txtGhi_Chu.TabIndex = 5;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(25, 203);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(54, 13);
            this.rsLabel4.TabIndex = 70;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Mã TNLD";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_TNLD
            // 
            this.lbtTen_TNLD.AutoSize = true;
            this.lbtTen_TNLD.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_TNLD.Location = new System.Drawing.Point(254, 203);
            this.lbtTen_TNLD.Name = "lbtTen_TNLD";
            this.lbtTen_TNLD.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_TNLD.TabIndex = 6;
            this.lbtTen_TNLD.Tag = "";
            this.lbtTen_TNLD.Text = "txtTen_Tn";
            this.lbtTen_TNLD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_TNLD
            // 
            this.txtMa_TNLD.AutoDropDown = null;
            this.txtMa_TNLD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_TNLD.Location = new System.Drawing.Point(153, 200);
            this.txtMa_TNLD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_TNLD.MaxLength = 20;
            this.txtMa_TNLD.Name = "txtMa_TNLD";
            this.txtMa_TNLD.Size = new System.Drawing.Size(96, 20);
            this.txtMa_TNLD.TabIndex = 6;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(24, 125);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(128, 13);
            this.rsLabel5.TabIndex = 77;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Nơi nghỉ phép/ Công Tác";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDia_Diem_Cong
            // 
            this.txtDia_Diem_Cong.AutoDropDown = null;
            this.txtDia_Diem_Cong.Location = new System.Drawing.Point(152, 123);
            this.txtDia_Diem_Cong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDia_Diem_Cong.MaxLength = 200;
            this.txtDia_Diem_Cong.Multiline = true;
            this.txtDia_Diem_Cong.Name = "txtDia_Diem_Cong";
            this.txtDia_Diem_Cong.Size = new System.Drawing.Size(526, 52);
            this.txtDia_Diem_Cong.TabIndex = 4;
            // 
            // chkCoT7
            // 
            this.chkCoT7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCoT7.AutoSize = true;
            this.chkCoT7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCoT7.ForeColor = System.Drawing.Color.Red;
            this.chkCoT7.Location = new System.Drawing.Point(153, 100);
            this.chkCoT7.Name = "chkCoT7";
            this.chkCoT7.Size = new System.Drawing.Size(107, 19);
            this.chkCoT7.TabIndex = 121;
            this.chkCoT7.Text = "Có tính thứ 7";
            this.chkCoT7.UseVisualStyleBackColor = true;
            // 
            // frmNVKChamCong_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 276);
            this.Controls.Add(this.chkCoT7);
            this.Controls.Add(this.txtDia_Diem_Cong);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtTinh_Trang_Cong);
            this.Controls.Add(this.lbtTinh_Trang_Cong);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.dteDen_Ngay);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.dteTu_Ngay);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.txtMa_TNLD);
            this.Controls.Add(this.lbtTen_TNLD);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmNVKChamCong_Edit";
            this.Text = "frmNVKChamCong_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteTu_Ngay;
		private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabelName lbtTen_Dt_CbNv;
        private RosySystem.Control.rsTextBox txtTinh_Trang_Cong;
        private RosySystem.Control.rsLabelName lbtTinh_Trang_Cong;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsDateTime dteDen_Ngay;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabelName lbtTen_TNLD;
        private RosySystem.Control.rsTextBox txtMa_TNLD;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBox txtDia_Diem_Cong;
        public RosySystem.Control.rsCheckbox chkCoT7;
	}
}