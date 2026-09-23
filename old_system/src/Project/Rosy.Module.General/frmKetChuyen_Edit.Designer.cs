namespace RosyModule.General
{
    partial class frmKetChuyen_Edit
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
			this.numStt = new RosySystem.Control.rsTextBoxNumber();
			this.txtDien_Giai = new RosySystem.Control.rsTextBox();
			this.lbMa_Hd = new RosySystem.Control.rsLabel();
			this.lbtTen_Tk = new RosySystem.Control.rsLabel();
			this.txtTk = new RosySystem.Control.rsTextBox();
			this.lblTk = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtTk_Du_Den = new RosySystem.Control.rsTextBox();
			this.lbtTen_Tk_Du_Den = new RosySystem.Control.rsLabel();
			this.lbtLoai_Ct = new RosySystem.Control.rsLabel();
			this.txtNo_Co_Auto = new RosySystem.Control.rsTextBoxEnum();
			this.txtPs_Du = new RosySystem.Control.rsTextBoxEnum();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.lbtTen_Bp = new RosySystem.Control.rsLabel();
			this.txtMa_Bp = new RosySystem.Control.rsTextBox();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.lbtMa_Km = new RosySystem.Control.rsLabel();
			this.txtMa_Km = new RosySystem.Control.rsTextBox();
			this.rsLabel9 = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// numStt
			// 
			this.numStt.AutoDropDown = null;
			this.numStt.bFormat = true;
			this.numStt.Location = new System.Drawing.Point(150, 22);
			this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numStt.Name = "numStt";
			this.numStt.Scale = 0;
			this.numStt.Size = new System.Drawing.Size(39, 20);
			this.numStt.TabIndex = 0;
			this.numStt.Text = "0";
			this.numStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numStt.Value = 0D;
			// 
			// txtDien_Giai
			// 
			this.txtDien_Giai.AutoDropDown = null;
			this.txtDien_Giai.Location = new System.Drawing.Point(150, 44);
			this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDien_Giai.MaxLength = 200;
			this.txtDien_Giai.Name = "txtDien_Giai";
			this.txtDien_Giai.Size = new System.Drawing.Size(361, 20);
			this.txtDien_Giai.TabIndex = 1;
			// 
			// lbMa_Hd
			// 
			this.lbMa_Hd.AutoEllipsis = true;
			this.lbMa_Hd.AutoSize = true;
			this.lbMa_Hd.Location = new System.Drawing.Point(33, 46);
			this.lbMa_Hd.Name = "lbMa_Hd";
			this.lbMa_Hd.Size = new System.Drawing.Size(48, 13);
			this.lbMa_Hd.TabIndex = 34;
			this.lbMa_Hd.Tag = "Dien_Giai";
			this.lbMa_Hd.Text = "Diễn giải";
			this.lbMa_Hd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Tk
			// 
			this.lbtTen_Tk.AutoEllipsis = true;
			this.lbtTen_Tk.AutoSize = true;
			this.lbtTen_Tk.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Tk.Location = new System.Drawing.Point(209, 69);
			this.lbtTen_Tk.Name = "lbtTen_Tk";
			this.lbtTen_Tk.Size = new System.Drawing.Size(73, 13);
			this.lbtTen_Tk.TabIndex = 142;
			this.lbtTen_Tk.Text = "Tên tài khoản";
			this.lbtTen_Tk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk
			// 
			this.txtTk.AutoDropDown = null;
			this.txtTk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTk.Location = new System.Drawing.Point(150, 66);
			this.txtTk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk.MaxLength = 20;
			this.txtTk.Name = "txtTk";
			this.txtTk.Size = new System.Drawing.Size(54, 20);
			this.txtTk.TabIndex = 2;
			// 
			// lblTk
			// 
			this.lblTk.AutoEllipsis = true;
			this.lblTk.AutoSize = true;
			this.lblTk.Location = new System.Drawing.Point(33, 68);
			this.lblTk.Name = "lblTk";
			this.lblTk.Size = new System.Drawing.Size(67, 13);
			this.lblTk.TabIndex = 141;
			this.lblTk.Tag = "Tk_Di";
			this.lblTk.Text = "Tài khoản đi";
			this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(33, 91);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(77, 13);
			this.rsLabel1.TabIndex = 141;
			this.rsLabel1.Tag = "Tk_Den";
			this.rsLabel1.Text = "Tài khoản đến";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk_Du_Den
			// 
			this.txtTk_Du_Den.AutoDropDown = null;
			this.txtTk_Du_Den.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTk_Du_Den.Location = new System.Drawing.Point(150, 88);
			this.txtTk_Du_Den.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk_Du_Den.MaxLength = 20;
			this.txtTk_Du_Den.Name = "txtTk_Du_Den";
			this.txtTk_Du_Den.Size = new System.Drawing.Size(54, 20);
			this.txtTk_Du_Den.TabIndex = 3;
			// 
			// lbtTen_Tk_Du_Den
			// 
			this.lbtTen_Tk_Du_Den.AutoEllipsis = true;
			this.lbtTen_Tk_Du_Den.AutoSize = true;
			this.lbtTen_Tk_Du_Den.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Tk_Du_Den.Location = new System.Drawing.Point(209, 91);
			this.lbtTen_Tk_Du_Den.Name = "lbtTen_Tk_Du_Den";
			this.lbtTen_Tk_Du_Den.Size = new System.Drawing.Size(88, 13);
			this.lbtTen_Tk_Du_Den.TabIndex = 142;
			this.lbtTen_Tk_Du_Den.Text = "Tên Tk_Du_Den";
			this.lbtTen_Tk_Du_Den.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtLoai_Ct
			// 
			this.lbtLoai_Ct.AutoEllipsis = true;
			this.lbtLoai_Ct.AutoSize = true;
			this.lbtLoai_Ct.ForeColor = System.Drawing.Color.Blue;
			this.lbtLoai_Ct.Location = new System.Drawing.Point(176, 184);
			this.lbtLoai_Ct.Name = "lbtLoai_Ct";
			this.lbtLoai_Ct.Size = new System.Drawing.Size(360, 13);
			this.lbtLoai_Ct.TabIndex = 144;
			this.lbtLoai_Ct.Tag = "No_Co_Auto";
			this.lbtLoai_Ct.Text = "1-Nợ, 2-Có, 3-Tự động xác định, 4-Kết chuyển căn cứ vào tk có giá trị nhỏ";
			this.lbtLoai_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNo_Co_Auto
			// 
			this.txtNo_Co_Auto.AutoDropDown = null;
			this.txtNo_Co_Auto.InputMask = "1,2,3,4";
			this.txtNo_Co_Auto.Location = new System.Drawing.Point(150, 179);
			this.txtNo_Co_Auto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNo_Co_Auto.Name = "txtNo_Co_Auto";
			this.txtNo_Co_Auto.Size = new System.Drawing.Size(21, 20);
			this.txtNo_Co_Auto.TabIndex = 7;
			this.txtNo_Co_Auto.Text = "1";
			// 
			// txtPs_Du
			// 
			this.txtPs_Du.AutoDropDown = null;
			this.txtPs_Du.InputMask = "1,2";
			this.txtPs_Du.Location = new System.Drawing.Point(150, 157);
			this.txtPs_Du.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtPs_Du.Name = "txtPs_Du";
			this.txtPs_Du.Size = new System.Drawing.Size(21, 20);
			this.txtPs_Du.TabIndex = 6;
			this.txtPs_Du.Text = "1";
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel3.Location = new System.Drawing.Point(176, 162);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(121, 13);
			this.rsLabel3.TabIndex = 144;
			this.rsLabel3.Tag = "PS_DU";
			this.rsLabel3.Text = "1-Số phát sinh, 2- Số dư";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.Location = new System.Drawing.Point(33, 180);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(108, 30);
			this.rsLabel4.TabIndex = 141;
			this.rsLabel4.Tag = "";
			this.rsLabel4.Text = "Kết chuyển sang bên của Tk đi";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(33, 161);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(61, 13);
			this.rsLabel5.TabIndex = 141;
			this.rsLabel5.Tag = "";
			this.rsLabel5.Text = "Kết chuyển";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(364, 219);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(186, 44);
			this.btgAccept.TabIndex = 7;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(33, 24);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(50, 13);
			this.rsLabel6.TabIndex = 34;
			this.rsLabel6.Tag = "Stt";
			this.rsLabel6.Text = "Số thứ tự";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Bp
			// 
			this.lbtTen_Bp.AutoEllipsis = true;
			this.lbtTen_Bp.AutoSize = true;
			this.lbtTen_Bp.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Bp.Location = new System.Drawing.Point(209, 113);
			this.lbtTen_Bp.Name = "lbtTen_Bp";
			this.lbtTen_Bp.Size = new System.Drawing.Size(56, 13);
			this.lbtTen_Bp.TabIndex = 147;
			this.lbtTen_Bp.Text = "lbtTen_Bp";
			this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Bp
			// 
			this.txtMa_Bp.AutoDropDown = null;
			this.txtMa_Bp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Bp.Location = new System.Drawing.Point(150, 110);
			this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Bp.MaxLength = 20;
			this.txtMa_Bp.Name = "txtMa_Bp";
			this.txtMa_Bp.Size = new System.Drawing.Size(54, 20);
			this.txtMa_Bp.TabIndex = 4;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Location = new System.Drawing.Point(33, 113);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(38, 13);
			this.rsLabel7.TabIndex = 146;
			this.rsLabel7.Tag = "Ma_Bp";
			this.rsLabel7.Text = "Ma Bp";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtMa_Km
			// 
			this.lbtMa_Km.AutoEllipsis = true;
			this.lbtMa_Km.AutoSize = true;
			this.lbtMa_Km.ForeColor = System.Drawing.Color.Blue;
			this.lbtMa_Km.Location = new System.Drawing.Point(209, 135);
			this.lbtMa_Km.Name = "lbtMa_Km";
			this.lbtMa_Km.Size = new System.Drawing.Size(43, 13);
			this.lbtMa_Km.TabIndex = 150;
			this.lbtMa_Km.Text = "Tên km";
			this.lbtMa_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Km
			// 
			this.txtMa_Km.AutoDropDown = null;
			this.txtMa_Km.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Km.Location = new System.Drawing.Point(150, 132);
			this.txtMa_Km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Km.MaxLength = 20;
			this.txtMa_Km.Name = "txtMa_Km";
			this.txtMa_Km.Size = new System.Drawing.Size(54, 20);
			this.txtMa_Km.TabIndex = 5;
			// 
			// rsLabel9
			// 
			this.rsLabel9.AutoEllipsis = true;
			this.rsLabel9.AutoSize = true;
			this.rsLabel9.Location = new System.Drawing.Point(33, 135);
			this.rsLabel9.Name = "rsLabel9";
			this.rsLabel9.Size = new System.Drawing.Size(40, 13);
			this.rsLabel9.TabIndex = 149;
			this.rsLabel9.Tag = "Ma_Km";
			this.rsLabel9.Text = "Mã Km";
			this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmKetChuyen_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(571, 272);
			this.Controls.Add(this.lbtMa_Km);
			this.Controls.Add(this.txtMa_Km);
			this.Controls.Add(this.rsLabel9);
			this.Controls.Add(this.lbtTen_Bp);
			this.Controls.Add(this.txtMa_Bp);
			this.Controls.Add(this.rsLabel7);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.txtPs_Du);
			this.Controls.Add(this.lbtLoai_Ct);
			this.Controls.Add(this.txtNo_Co_Auto);
			this.Controls.Add(this.lbtTen_Tk_Du_Den);
			this.Controls.Add(this.txtTk_Du_Den);
			this.Controls.Add(this.lbtTen_Tk);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.txtTk);
			this.Controls.Add(this.lblTk);
			this.Controls.Add(this.txtDien_Giai);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.lbMa_Hd);
			this.Controls.Add(this.numStt);
			this.Name = "frmKetChuyen_Edit";
			this.Object_ID = "KETCHUYEN";
			this.Tag = "frmKetChuyen, ESC";
			this.Text = "frmKetChuyen";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBoxNumber numStt;
        private RosySystem.Control.rsTextBox txtDien_Giai;
        private RosySystem.Control.rsLabel lbMa_Hd;
        private RosySystem.Control.rsLabel lbtTen_Tk;
        private RosySystem.Control.rsTextBox txtTk;
        private RosySystem.Control.rsLabel lblTk;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtTk_Du_Den;
        private RosySystem.Control.rsLabel lbtTen_Tk_Du_Den;
        private RosySystem.Control.rsLabel lbtLoai_Ct;
        private RosySystem.Control.rsTextBoxEnum txtNo_Co_Auto;
        private RosySystem.Control.rsTextBoxEnum txtPs_Du;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel rsLabel5;
        public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel lbtTen_Bp;
		private RosySystem.Control.rsTextBox txtMa_Bp;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsLabel lbtMa_Km;
		private RosySystem.Control.rsTextBox txtMa_Km;
		private RosySystem.Control.rsLabel rsLabel9;

	}
}