namespace RosyModule.HRM
{
	partial class frmQTKTKL_Edit
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
            this.dteNgay_HL = new RosySystem.Control.rsDateTime();
            this.dteNgay_QD = new RosySystem.Control.rsDateTime();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel12 = new RosySystem.Control.rsLabel();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtNguoi_Ky = new RosySystem.Control.rsTextBox();
            this.txtHinh_Thuc = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtNoi_Dung = new RosySystem.Control.rsTextBox();
            this.txtSo_QD = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.SuspendLayout();
            // 
            // dteNgay_HL
            // 
            this.dteNgay_HL.bAllowEmpty = false;
            this.dteNgay_HL.bSelectOnFocus = false;
            this.dteNgay_HL.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_HL.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_HL.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_HL.Location = new System.Drawing.Point(133, 130);
            this.dteNgay_HL.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_HL.Mask = "00/00/0000";
            this.dteNgay_HL.Name = "dteNgay_HL";
            this.dteNgay_HL.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_HL.TabIndex = 116;
            // 
            // dteNgay_QD
            // 
            this.dteNgay_QD.bAllowEmpty = false;
            this.dteNgay_QD.bSelectOnFocus = false;
            this.dteNgay_QD.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_QD.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_QD.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_QD.Location = new System.Drawing.Point(133, 107);
            this.dteNgay_QD.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_QD.Mask = "00/00/0000";
            this.dteNgay_QD.Name = "dteNgay_QD";
            this.dteNgay_QD.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_QD.TabIndex = 115;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(258, 22);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(59, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 128;
            this.lbtTen_Dt_CbNv.Text = "Ten_CbNv";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(419, 219);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(178, 43);
            this.btgAccept.TabIndex = 119;
            // 
            // rsLabel12
            // 
            this.rsLabel12.AutoEllipsis = true;
            this.rsLabel12.AutoSize = true;
            this.rsLabel12.Location = new System.Drawing.Point(24, 133);
            this.rsLabel12.Name = "rsLabel12";
            this.rsLabel12.Size = new System.Drawing.Size(72, 13);
            this.rsLabel12.TabIndex = 127;
            this.rsLabel12.Tag = "Ngay_Hieu_Luc";
            this.rsLabel12.Text = "Ngày hiệu lực";
            this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(24, 110);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(85, 13);
            this.rsLabel11.TabIndex = 125;
            this.rsLabel11.Tag = "Ngay_QD";
            this.rsLabel11.Text = "Ngày quyết định";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(329, 110);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(49, 13);
            this.rsLabel6.TabIndex = 124;
            this.rsLabel6.Tag = "Nguoi_Ky";
            this.rsLabel6.Text = "Người ký";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(24, 156);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(83, 13);
            this.rsLabel4.TabIndex = 126;
            this.rsLabel4.Tag = "Hinh_Thuc_KTKL";
            this.rsLabel4.Text = "Hình thức KTKL";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(24, 66);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(80, 13);
            this.rsLabel3.TabIndex = 122;
            this.rsLabel3.Tag = "Noi_Dung_KTKL";
            this.rsLabel3.Text = "Nội dung KTKL";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNguoi_Ky
            // 
            this.txtNguoi_Ky.AutoDropDown = null;
            this.txtNguoi_Ky.Location = new System.Drawing.Point(383, 107);
            this.txtNguoi_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNguoi_Ky.Name = "txtNguoi_Ky";
            this.txtNguoi_Ky.Size = new System.Drawing.Size(214, 20);
            this.txtNguoi_Ky.TabIndex = 118;
            // 
            // txtHinh_Thuc
            // 
            this.txtHinh_Thuc.AutoDropDown = null;
            this.txtHinh_Thuc.Location = new System.Drawing.Point(133, 153);
            this.txtHinh_Thuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtHinh_Thuc.Name = "txtHinh_Thuc";
            this.txtHinh_Thuc.Size = new System.Drawing.Size(464, 20);
            this.txtHinh_Thuc.TabIndex = 117;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(24, 44);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(73, 13);
            this.rsLabel2.TabIndex = 123;
            this.rsLabel2.Tag = "So_Quyet_Dinh";
            this.rsLabel2.Text = "Số quyết định";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoi_Dung
            // 
            this.txtNoi_Dung.AutoDropDown = null;
            this.txtNoi_Dung.Location = new System.Drawing.Point(133, 63);
            this.txtNoi_Dung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNoi_Dung.Multiline = true;
            this.txtNoi_Dung.Name = "txtNoi_Dung";
            this.txtNoi_Dung.Size = new System.Drawing.Size(464, 42);
            this.txtNoi_Dung.TabIndex = 114;
            // 
            // txtSo_QD
            // 
            this.txtSo_QD.AutoDropDown = null;
            this.txtSo_QD.Location = new System.Drawing.Point(133, 41);
            this.txtSo_QD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_QD.Name = "txtSo_QD";
            this.txtSo_QD.Size = new System.Drawing.Size(120, 20);
            this.txtSo_QD.TabIndex = 113;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(24, 22);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(72, 13);
            this.rsLabel1.TabIndex = 120;
            this.rsLabel1.Tag = "Ma_Dt_CbNv";
            this.rsLabel1.Text = "Mã nhân viên";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(133, 19);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt_CbNv.TabIndex = 111;
            // 
            // frmQTKTKL_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 273);
            this.Controls.Add(this.dteNgay_HL);
            this.Controls.Add(this.dteNgay_QD);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel12);
            this.Controls.Add(this.rsLabel11);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtNguoi_Ky);
            this.Controls.Add(this.txtHinh_Thuc);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtNoi_Dung);
            this.Controls.Add(this.txtSo_QD);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Name = "frmQTKTKL_Edit";
            this.Text = "frmQTKTKL_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_HL;
        private RosySystem.Control.rsDateTime dteNgay_QD;
		private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel12;
		private RosySystem.Control.rsLabel rsLabel11;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBox txtNguoi_Ky;
		private RosySystem.Control.rsTextBox txtHinh_Thuc;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBox txtNoi_Dung;
		private RosySystem.Control.rsTextBox txtSo_QD;
        private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;


	}
}