namespace RosyList
{
    partial class frmUnLock_DM
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
            this.rsTabControl1 = new System.Windows.Forms.TabControl();
            this.tpLock = new System.Windows.Forms.TabPage();
            this.txtUser_Lock = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu_Lock = new RosySystem.Control.rsTextBox();
            this.chkLock = new RosySystem.Control.rsCheckbox();
            this.tpHSPKT = new System.Windows.Forms.TabPage();
            this.txtUser_Nhan = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.chkIs_Nhan = new RosySystem.Control.rsCheckbox();
            this.tpTinChap = new System.Windows.Forms.TabPage();
            this.dteNgay_Hd_Kt = new RosySystem.Control.rsDateTime();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.dteNgay_Hd_Bd = new RosySystem.Control.rsDateTime();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtNote_Tien = new RosySystem.Control.rsTextBox();
            this.txtMa_Hd = new RosySystem.Control.rsTextBox();
            this.lbMa_Hd = new RosySystem.Control.rsLabel();
            this.numTien_Tin_Chap_Nt = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel36 = new RosySystem.Control.rsLabel();
            this.numTien_Cam_Co_Nt = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel37 = new RosySystem.Control.rsLabel();
            this.numTien_Tin_Chap = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel28 = new RosySystem.Control.rsLabel();
            this.numTien_Cam_Co = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel25 = new RosySystem.Control.rsLabel();
            this.btSave = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.lblLog = new RosySystem.Control.rsLabel();
            this.rsTabControl1.SuspendLayout();
            this.tpLock.SuspendLayout();
            this.tpHSPKT.SuspendLayout();
            this.tpTinChap.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Controls.Add(this.tpLock);
            this.rsTabControl1.Controls.Add(this.tpHSPKT);
            this.rsTabControl1.Controls.Add(this.tpTinChap);
            this.rsTabControl1.Location = new System.Drawing.Point(12, 12);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(492, 170);
            this.rsTabControl1.TabIndex = 0;
            // 
            // tpLock
            // 
            this.tpLock.Controls.Add(this.txtUser_Lock);
            this.tpLock.Controls.Add(this.rsLabel2);
            this.tpLock.Controls.Add(this.rsLabel1);
            this.tpLock.Controls.Add(this.txtGhi_Chu_Lock);
            this.tpLock.Controls.Add(this.chkLock);
            this.tpLock.Location = new System.Drawing.Point(4, 22);
            this.tpLock.Name = "tpLock";
            this.tpLock.Size = new System.Drawing.Size(484, 144);
            this.tpLock.TabIndex = 2;
            this.tpLock.Text = "Lập";
            this.tpLock.UseVisualStyleBackColor = true;
            // 
            // txtUser_Lock
            // 
            this.txtUser_Lock.AutoDropDown = null;
            this.txtUser_Lock.Enabled = false;
            this.txtUser_Lock.Location = new System.Drawing.Point(118, 62);
            this.txtUser_Lock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtUser_Lock.MaxLength = 20;
            this.txtUser_Lock.Name = "txtUser_Lock";
            this.txtUser_Lock.Size = new System.Drawing.Size(119, 20);
            this.txtUser_Lock.TabIndex = 102;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(22, 65);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(73, 13);
            this.rsLabel2.TabIndex = 101;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "User mở khóa";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(22, 42);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(77, 13);
            this.rsLabel1.TabIndex = 100;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Lý do mở khóa";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu_Lock
            // 
            this.txtGhi_Chu_Lock.AutoDropDown = null;
            this.txtGhi_Chu_Lock.Location = new System.Drawing.Point(118, 39);
            this.txtGhi_Chu_Lock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu_Lock.MaxLength = 200;
            this.txtGhi_Chu_Lock.Name = "txtGhi_Chu_Lock";
            this.txtGhi_Chu_Lock.Size = new System.Drawing.Size(259, 20);
            this.txtGhi_Chu_Lock.TabIndex = 98;
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Location = new System.Drawing.Point(118, 16);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(101, 17);
            this.chkLock.TabIndex = 96;
            this.chkLock.Text = "Tình trạng khóa";
            this.chkLock.UseVisualStyleBackColor = true;
            // 
            // tpHSPKT
            // 
            this.tpHSPKT.Controls.Add(this.txtUser_Nhan);
            this.tpHSPKT.Controls.Add(this.rsLabel4);
            this.tpHSPKT.Controls.Add(this.chkIs_Nhan);
            this.tpHSPKT.Location = new System.Drawing.Point(4, 22);
            this.tpHSPKT.Name = "tpHSPKT";
            this.tpHSPKT.Size = new System.Drawing.Size(484, 144);
            this.tpHSPKT.TabIndex = 4;
            this.tpHSPKT.Text = "Nhận HS PKTTC";
            this.tpHSPKT.UseVisualStyleBackColor = true;
            // 
            // txtUser_Nhan
            // 
            this.txtUser_Nhan.AutoDropDown = null;
            this.txtUser_Nhan.Enabled = false;
            this.txtUser_Nhan.Location = new System.Drawing.Point(103, 42);
            this.txtUser_Nhan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtUser_Nhan.MaxLength = 20;
            this.txtUser_Nhan.Name = "txtUser_Nhan";
            this.txtUser_Nhan.Size = new System.Drawing.Size(119, 20);
            this.txtUser_Nhan.TabIndex = 107;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(7, 45);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(74, 13);
            this.rsLabel4.TabIndex = 106;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "User nhận HS";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIs_Nhan
            // 
            this.chkIs_Nhan.AutoSize = true;
            this.chkIs_Nhan.Location = new System.Drawing.Point(103, 22);
            this.chkIs_Nhan.Name = "chkIs_Nhan";
            this.chkIs_Nhan.Size = new System.Drawing.Size(81, 17);
            this.chkIs_Nhan.TabIndex = 103;
            this.chkIs_Nhan.Text = "Nhận hồ sơ";
            this.chkIs_Nhan.UseVisualStyleBackColor = true;
            // 
            // tpTinChap
            // 
            this.tpTinChap.Controls.Add(this.dteNgay_Hd_Kt);
            this.tpTinChap.Controls.Add(this.rsLabel9);
            this.tpTinChap.Controls.Add(this.dteNgay_Hd_Bd);
            this.tpTinChap.Controls.Add(this.rsLabel6);
            this.tpTinChap.Controls.Add(this.rsLabel3);
            this.tpTinChap.Controls.Add(this.txtNote_Tien);
            this.tpTinChap.Controls.Add(this.txtMa_Hd);
            this.tpTinChap.Controls.Add(this.lbMa_Hd);
            this.tpTinChap.Controls.Add(this.numTien_Tin_Chap_Nt);
            this.tpTinChap.Controls.Add(this.rsLabel36);
            this.tpTinChap.Controls.Add(this.numTien_Cam_Co_Nt);
            this.tpTinChap.Controls.Add(this.rsLabel37);
            this.tpTinChap.Controls.Add(this.numTien_Tin_Chap);
            this.tpTinChap.Controls.Add(this.rsLabel28);
            this.tpTinChap.Controls.Add(this.numTien_Cam_Co);
            this.tpTinChap.Controls.Add(this.rsLabel25);
            this.tpTinChap.Location = new System.Drawing.Point(4, 22);
            this.tpTinChap.Name = "tpTinChap";
            this.tpTinChap.Size = new System.Drawing.Size(484, 144);
            this.tpTinChap.TabIndex = 3;
            this.tpTinChap.Text = "Sửa thông tin tiền tín chấp";
            this.tpTinChap.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Hd_Kt
            // 
            this.dteNgay_Hd_Kt.bAllowEmpty = true;
            this.dteNgay_Hd_Kt.bSelectOnFocus = false;
            this.dteNgay_Hd_Kt.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Hd_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Hd_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Hd_Kt.Location = new System.Drawing.Point(356, 84);
            this.dteNgay_Hd_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Hd_Kt.Mask = "00/00/0000";
            this.dteNgay_Hd_Kt.Name = "dteNgay_Hd_Kt";
            this.dteNgay_Hd_Kt.Size = new System.Drawing.Size(83, 20);
            this.dteNgay_Hd_Kt.TabIndex = 6;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(267, 87);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(71, 13);
            this.rsLabel9.TabIndex = 112;
            this.rsLabel9.Tag = "Ngay_Hd_Kt";
            this.rsLabel9.Text = "Ngày hết hạn";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Hd_Bd
            // 
            this.dteNgay_Hd_Bd.bAllowEmpty = true;
            this.dteNgay_Hd_Bd.bSelectOnFocus = false;
            this.dteNgay_Hd_Bd.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Hd_Bd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Hd_Bd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Hd_Bd.Location = new System.Drawing.Point(132, 82);
            this.dteNgay_Hd_Bd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Hd_Bd.Mask = "00/00/0000";
            this.dteNgay_Hd_Bd.Name = "dteNgay_Hd_Bd";
            this.dteNgay_Hd_Bd.Size = new System.Drawing.Size(83, 20);
            this.dteNgay_Hd_Bd.TabIndex = 5;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(8, 84);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(97, 13);
            this.rsLabel6.TabIndex = 113;
            this.rsLabel6.Tag = "Ngay_Hd_Bd";
            this.rsLabel6.Text = "Ngày BĐ thực hiện";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(8, 109);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(44, 13);
            this.rsLabel3.TabIndex = 109;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Ghi chú";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNote_Tien
            // 
            this.txtNote_Tien.AutoDropDown = null;
            this.txtNote_Tien.Location = new System.Drawing.Point(103, 106);
            this.txtNote_Tien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNote_Tien.MaxLength = 200;
            this.txtNote_Tien.Multiline = true;
            this.txtNote_Tien.Name = "txtNote_Tien";
            this.txtNote_Tien.Size = new System.Drawing.Size(373, 36);
            this.txtNote_Tien.TabIndex = 7;
            // 
            // txtMa_Hd
            // 
            this.txtMa_Hd.AutoDropDown = null;
            this.txtMa_Hd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Hd.Location = new System.Drawing.Point(113, 10);
            this.txtMa_Hd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Hd.MaxLength = 50;
            this.txtMa_Hd.Name = "txtMa_Hd";
            this.txtMa_Hd.ReadOnly = true;
            this.txtMa_Hd.Size = new System.Drawing.Size(363, 20);
            this.txtMa_Hd.TabIndex = 0;
            // 
            // lbMa_Hd
            // 
            this.lbMa_Hd.AutoEllipsis = true;
            this.lbMa_Hd.AutoSize = true;
            this.lbMa_Hd.Location = new System.Drawing.Point(8, 13);
            this.lbMa_Hd.Name = "lbMa_Hd";
            this.lbMa_Hd.Size = new System.Drawing.Size(71, 13);
            this.lbMa_Hd.TabIndex = 107;
            this.lbMa_Hd.Tag = "Ma_Hd";
            this.lbMa_Hd.Text = "Mã hợp đồng";
            this.lbMa_Hd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTien_Tin_Chap_Nt
            // 
            this.numTien_Tin_Chap_Nt.AutoDropDown = null;
            this.numTien_Tin_Chap_Nt.bFormat = true;
            this.numTien_Tin_Chap_Nt.Location = new System.Drawing.Point(356, 60);
            this.numTien_Tin_Chap_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_Tin_Chap_Nt.Name = "numTien_Tin_Chap_Nt";
            this.numTien_Tin_Chap_Nt.Scale = 2;
            this.numTien_Tin_Chap_Nt.Size = new System.Drawing.Size(120, 20);
            this.numTien_Tin_Chap_Nt.TabIndex = 4;
            this.numTien_Tin_Chap_Nt.Tag = "";
            this.numTien_Tin_Chap_Nt.Text = "0.00";
            this.numTien_Tin_Chap_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_Tin_Chap_Nt.Value = 0D;
            // 
            // rsLabel36
            // 
            this.rsLabel36.AutoEllipsis = true;
            this.rsLabel36.AutoSize = true;
            this.rsLabel36.Location = new System.Drawing.Point(267, 63);
            this.rsLabel36.Name = "rsLabel36";
            this.rsLabel36.Size = new System.Drawing.Size(85, 13);
            this.rsLabel36.TabIndex = 105;
            this.rsLabel36.Tag = "";
            this.rsLabel36.Text = "Tiền tín chấp Nt";
            this.rsLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTien_Cam_Co_Nt
            // 
            this.numTien_Cam_Co_Nt.AutoDropDown = null;
            this.numTien_Cam_Co_Nt.bFormat = true;
            this.numTien_Cam_Co_Nt.Location = new System.Drawing.Point(131, 60);
            this.numTien_Cam_Co_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_Cam_Co_Nt.Name = "numTien_Cam_Co_Nt";
            this.numTien_Cam_Co_Nt.Scale = 2;
            this.numTien_Cam_Co_Nt.Size = new System.Drawing.Size(120, 20);
            this.numTien_Cam_Co_Nt.TabIndex = 2;
            this.numTien_Cam_Co_Nt.Tag = "";
            this.numTien_Cam_Co_Nt.Text = "0.00";
            this.numTien_Cam_Co_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_Cam_Co_Nt.Value = 0D;
            // 
            // rsLabel37
            // 
            this.rsLabel37.AutoEllipsis = true;
            this.rsLabel37.AutoSize = true;
            this.rsLabel37.Location = new System.Drawing.Point(8, 63);
            this.rsLabel37.Name = "rsLabel37";
            this.rsLabel37.Size = new System.Drawing.Size(120, 13);
            this.rsLabel37.TabIndex = 104;
            this.rsLabel37.Tag = "";
            this.rsLabel37.Text = "Tiền ký quỹ/ Cầm cố Nt";
            this.rsLabel37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTien_Tin_Chap
            // 
            this.numTien_Tin_Chap.AutoDropDown = null;
            this.numTien_Tin_Chap.bFormat = true;
            this.numTien_Tin_Chap.Location = new System.Drawing.Point(356, 35);
            this.numTien_Tin_Chap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_Tin_Chap.Name = "numTien_Tin_Chap";
            this.numTien_Tin_Chap.Scale = 0;
            this.numTien_Tin_Chap.Size = new System.Drawing.Size(120, 20);
            this.numTien_Tin_Chap.TabIndex = 3;
            this.numTien_Tin_Chap.Tag = "";
            this.numTien_Tin_Chap.Text = "0";
            this.numTien_Tin_Chap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_Tin_Chap.Value = 0D;
            // 
            // rsLabel28
            // 
            this.rsLabel28.AutoEllipsis = true;
            this.rsLabel28.AutoSize = true;
            this.rsLabel28.Location = new System.Drawing.Point(267, 38);
            this.rsLabel28.Name = "rsLabel28";
            this.rsLabel28.Size = new System.Drawing.Size(71, 13);
            this.rsLabel28.TabIndex = 103;
            this.rsLabel28.Tag = "";
            this.rsLabel28.Text = "Tiền tín chấp";
            this.rsLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTien_Cam_Co
            // 
            this.numTien_Cam_Co.AutoDropDown = null;
            this.numTien_Cam_Co.bFormat = true;
            this.numTien_Cam_Co.Location = new System.Drawing.Point(131, 35);
            this.numTien_Cam_Co.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_Cam_Co.Name = "numTien_Cam_Co";
            this.numTien_Cam_Co.Scale = 0;
            this.numTien_Cam_Co.Size = new System.Drawing.Size(120, 20);
            this.numTien_Cam_Co.TabIndex = 1;
            this.numTien_Cam_Co.Tag = "";
            this.numTien_Cam_Co.Text = "0";
            this.numTien_Cam_Co.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_Cam_Co.Value = 0D;
            // 
            // rsLabel25
            // 
            this.rsLabel25.AutoEllipsis = true;
            this.rsLabel25.AutoSize = true;
            this.rsLabel25.Location = new System.Drawing.Point(8, 38);
            this.rsLabel25.Name = "rsLabel25";
            this.rsLabel25.Size = new System.Drawing.Size(106, 13);
            this.rsLabel25.TabIndex = 102;
            this.rsLabel25.Tag = "";
            this.rsLabel25.Text = "Tiền ký quỹ/ Cầm cố";
            this.rsLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(344, 182);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(425, 182);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // lblLog
            // 
            this.lblLog.AutoEllipsis = true;
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(13, 187);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(25, 13);
            this.lblLog.TabIndex = 108;
            this.lblLog.Tag = "";
            this.lblLog.Text = "Log";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUnLock_DM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 209);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.rsTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUnLock_DM";
            this.Text = "Duyệt chứng từ";
            this.rsTabControl1.ResumeLayout(false);
            this.tpLock.ResumeLayout(false);
            this.tpLock.PerformLayout();
            this.tpHSPKT.ResumeLayout(false);
            this.tpHSPKT.PerformLayout();
            this.tpTinChap.ResumeLayout(false);
            this.tpTinChap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl rsTabControl1;
		private System.Windows.Forms.TabPage tpLock;
		private RosySystem.Control.rsButton btSave;
		private RosySystem.Control.rsButton btExit;
		private RosySystem.Control.rsLabel rsLabel1;
		public RosySystem.Control.rsTextBox txtGhi_Chu_Lock;
        private RosySystem.Control.rsCheckbox chkLock;
		public RosySystem.Control.rsTextBox txtUser_Lock;
		private RosySystem.Control.rsLabel rsLabel2;
        private System.Windows.Forms.TabPage tpTinChap;
        private RosySystem.Control.rsLabel rsLabel36;
        private RosySystem.Control.rsLabel rsLabel37;
        private RosySystem.Control.rsLabel rsLabel28;
        private RosySystem.Control.rsLabel rsLabel25;
        private RosySystem.Control.rsTextBox txtMa_Hd;
        private RosySystem.Control.rsLabel lbMa_Hd;
        private RosySystem.Control.rsLabel lblLog;
        private RosySystem.Control.rsLabel rsLabel3;
        public RosySystem.Control.rsTextBox txtNote_Tien;
        public RosySystem.Control.rsTextBoxNumber numTien_Cam_Co;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsLabel rsLabel6;
        public RosySystem.Control.rsTextBoxNumber numTien_Tin_Chap_Nt;
        public RosySystem.Control.rsTextBoxNumber numTien_Cam_Co_Nt;
        public RosySystem.Control.rsTextBoxNumber numTien_Tin_Chap;
        public RosySystem.Control.rsDateTime dteNgay_Hd_Kt;
        public RosySystem.Control.rsDateTime dteNgay_Hd_Bd;
        private System.Windows.Forms.TabPage tpHSPKT;
        public RosySystem.Control.rsTextBox txtUser_Nhan;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsCheckbox chkIs_Nhan;
    }
}