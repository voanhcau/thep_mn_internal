namespace RosyModule.Salary
{
	partial class frmDmTn_Edit
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
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.txtTen_Tn = new RosySystem.Control.rsTextBox();
			this.lblDien_Giai = new RosySystem.Control.rsLabel();
			this.txtMa_Tn = new RosySystem.Control.rsTextBox();
			this.lblTk = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.enuLoai_Tn = new RosySystem.Control.rsTextBoxEnum();
			this.lbtLoai_Tn = new RosySystem.Control.rsLabelName();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.txtCong_Thuc = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.numStt = new RosySystem.Control.rsTextBoxNumber();
			this.chkIs_Display1 = new RosySystem.Control.rsCheckbox();
			this.chkIs_Display2 = new RosySystem.Control.rsCheckbox();
			this.chkIs_Display3 = new RosySystem.Control.rsCheckbox();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.txtDvt = new RosySystem.Control.rsTextBox();
			this.chkIs_Input = new RosySystem.Control.rsCheckbox();
			this.chkIs_Active = new RosySystem.Control.rsCheckbox();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.enuColor = new RosySystem.Control.rsTextBoxEnum();
			this.chkBold = new RosySystem.Control.rsCheckbox();
			this.lbtTen_Tk_Co = new RosySystem.Control.rsLabel();
			this.txtTk_Co = new RosySystem.Control.rsTextBox();
			this.lblTk_Co = new RosySystem.Control.rsLabel();
			this.lbtTen_Tk_No = new RosySystem.Control.rsLabel();
			this.txtTk_No = new RosySystem.Control.rsTextBox();
			this.lblTk_No = new RosySystem.Control.rsLabel();
			this.lbtTen_Km = new RosySystem.Control.rsLabel();
			this.txtMa_Km = new RosySystem.Control.rsTextBox();
			this.lbMa_Bp = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(455, 281);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(179, 43);
			this.btgAccept.TabIndex = 20;
			// 
			// txtTen_Tn
			// 
			this.txtTen_Tn.Location = new System.Drawing.Point(127, 46);
			this.txtTen_Tn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Tn.MaxLength = 200;
			this.txtTen_Tn.Name = "txtTen_Tn";
			this.txtTen_Tn.Size = new System.Drawing.Size(491, 20);
			this.txtTen_Tn.TabIndex = 2;
			// 
			// lblDien_Giai
			// 
			this.lblDien_Giai.AutoEllipsis = true;
			this.lblDien_Giai.AutoSize = true;
			this.lblDien_Giai.Location = new System.Drawing.Point(25, 49);
			this.lblDien_Giai.Name = "lblDien_Giai";
			this.lblDien_Giai.Size = new System.Drawing.Size(71, 13);
			this.lblDien_Giai.TabIndex = 64;
			this.lblDien_Giai.Tag = "Ten_Tn";
			this.lblDien_Giai.Text = "Tên thu nhập";
			this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Tn
			// 
			this.txtMa_Tn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Tn.Location = new System.Drawing.Point(127, 24);
			this.txtMa_Tn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Tn.MaxLength = 20;
			this.txtMa_Tn.Name = "txtMa_Tn";
			this.txtMa_Tn.Size = new System.Drawing.Size(96, 20);
			this.txtMa_Tn.TabIndex = 0;
			// 
			// lblTk
			// 
			this.lblTk.AutoEllipsis = true;
			this.lblTk.AutoSize = true;
			this.lblTk.Location = new System.Drawing.Point(25, 27);
			this.lblTk.Name = "lblTk";
			this.lblTk.Size = new System.Drawing.Size(67, 13);
			this.lblTk.TabIndex = 63;
			this.lblTk.Tag = "Ma_Tn";
			this.lblTk.Text = "Mã thu nhập";
			this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(25, 115);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(72, 13);
			this.rsLabel1.TabIndex = 63;
			this.rsLabel1.Tag = "Loai_Tn";
			this.rsLabel1.Text = "Loại thu nhập";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// enuLoai_Tn
			// 
			this.enuLoai_Tn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.enuLoai_Tn.InputMask = "1,2,3";
			this.enuLoai_Tn.Location = new System.Drawing.Point(127, 112);
			this.enuLoai_Tn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.enuLoai_Tn.MaxLength = 20;
			this.enuLoai_Tn.Name = "enuLoai_Tn";
			this.enuLoai_Tn.Size = new System.Drawing.Size(27, 20);
			this.enuLoai_Tn.TabIndex = 7;
			this.enuLoai_Tn.Text = "1";
			// 
			// lbtLoai_Tn
			// 
			this.lbtLoai_Tn.AutoSize = true;
			this.lbtLoai_Tn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtLoai_Tn.Location = new System.Drawing.Point(159, 115);
			this.lbtLoai_Tn.Name = "lbtLoai_Tn";
			this.lbtLoai_Tn.Size = new System.Drawing.Size(283, 13);
			this.lbtLoai_Tn.TabIndex = 4;
			this.lbtLoai_Tn.Tag = "";
			this.lbtLoai_Tn.Text = "1-Tăng thu nhập, 2-Giảm thu nhập, 3-Không tăng giảm TN";
			this.lbtLoai_Tn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(25, 137);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(56, 13);
			this.rsLabel3.TabIndex = 64;
			this.rsLabel3.Tag = "Cong_Thuc";
			this.rsLabel3.Text = "Công thức";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCong_Thuc
			// 
			this.txtCong_Thuc.Location = new System.Drawing.Point(127, 134);
			this.txtCong_Thuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtCong_Thuc.MaxLength = 200;
			this.txtCong_Thuc.Name = "txtCong_Thuc";
			this.txtCong_Thuc.Size = new System.Drawing.Size(491, 20);
			this.txtCong_Thuc.TabIndex = 8;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(25, 159);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(44, 13);
			this.rsLabel2.TabIndex = 64;
			this.rsLabel2.Tag = "Ghi_Chu";
			this.rsLabel2.Text = "Ghi chú";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtGhi_Chu
			// 
			this.txtGhi_Chu.Location = new System.Drawing.Point(127, 156);
			this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtGhi_Chu.MaxLength = 200;
			this.txtGhi_Chu.Name = "txtGhi_Chu";
			this.txtGhi_Chu.Size = new System.Drawing.Size(491, 20);
			this.txtGhi_Chu.TabIndex = 9;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(543, 27);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(20, 13);
			this.rsLabel4.TabIndex = 63;
			this.rsLabel4.Tag = "Stt";
			this.rsLabel4.Text = "Stt";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numStt
			// 
			this.numStt.bFormat = true;
			this.numStt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numStt.Location = new System.Drawing.Point(568, 24);
			this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numStt.MaxLength = 20;
			this.numStt.Name = "numStt";
			this.numStt.Scale = 0;
			this.numStt.Size = new System.Drawing.Size(50, 20);
			this.numStt.TabIndex = 1;
			this.numStt.Text = "0";
			this.numStt.Value = 0D;
			// 
			// chkIs_Display1
			// 
			this.chkIs_Display1.AutoSize = true;
			this.chkIs_Display1.Location = new System.Drawing.Point(127, 249);
			this.chkIs_Display1.Name = "chkIs_Display1";
			this.chkIs_Display1.Size = new System.Drawing.Size(107, 17);
			this.chkIs_Display1.TabIndex = 17;
			this.chkIs_Display1.Tag = "Show_Page1";
			this.chkIs_Display1.Text = "Hiển thị ở trang 1";
			this.chkIs_Display1.UseVisualStyleBackColor = true;
			// 
			// chkIs_Display2
			// 
			this.chkIs_Display2.AutoSize = true;
			this.chkIs_Display2.Location = new System.Drawing.Point(127, 272);
			this.chkIs_Display2.Name = "chkIs_Display2";
			this.chkIs_Display2.Size = new System.Drawing.Size(107, 17);
			this.chkIs_Display2.TabIndex = 18;
			this.chkIs_Display2.Tag = "Show_Page2";
			this.chkIs_Display2.Text = "Hiển thị ở trang 2";
			this.chkIs_Display2.UseVisualStyleBackColor = true;
			// 
			// chkIs_Display3
			// 
			this.chkIs_Display3.AutoSize = true;
			this.chkIs_Display3.Location = new System.Drawing.Point(127, 295);
			this.chkIs_Display3.Name = "chkIs_Display3";
			this.chkIs_Display3.Size = new System.Drawing.Size(107, 17);
			this.chkIs_Display3.TabIndex = 19;
			this.chkIs_Display3.Tag = "Show_Page3";
			this.chkIs_Display3.Text = "Hiển thị ở trang 3";
			this.chkIs_Display3.UseVisualStyleBackColor = true;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(25, 71);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(24, 13);
			this.rsLabel5.TabIndex = 64;
			this.rsLabel5.Tag = "Dvt";
			this.rsLabel5.Text = "Đvt";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDvt
			// 
			this.txtDvt.Location = new System.Drawing.Point(127, 68);
			this.txtDvt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDvt.MaxLength = 200;
			this.txtDvt.Name = "txtDvt";
			this.txtDvt.Size = new System.Drawing.Size(53, 20);
			this.txtDvt.TabIndex = 3;
			// 
			// chkIs_Input
			// 
			this.chkIs_Input.AutoSize = true;
			this.chkIs_Input.ForeColor = System.Drawing.Color.Red;
			this.chkIs_Input.Location = new System.Drawing.Point(498, 68);
			this.chkIs_Input.Name = "chkIs_Input";
			this.chkIs_Input.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkIs_Input.Size = new System.Drawing.Size(120, 17);
			this.chkIs_Input.TabIndex = 4;
			this.chkIs_Input.Text = "Là dữ liệu nhập vào";
			this.chkIs_Input.UseVisualStyleBackColor = true;
			// 
			// chkIs_Active
			// 
			this.chkIs_Active.AutoSize = true;
			this.chkIs_Active.ForeColor = System.Drawing.Color.Red;
			this.chkIs_Active.Location = new System.Drawing.Point(562, 181);
			this.chkIs_Active.Name = "chkIs_Active";
			this.chkIs_Active.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkIs_Active.Size = new System.Drawing.Size(56, 17);
			this.chkIs_Active.TabIndex = 10;
			this.chkIs_Active.Text = "Active";
			this.chkIs_Active.UseVisualStyleBackColor = true;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(25, 93);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(28, 13);
			this.rsLabel6.TabIndex = 63;
			this.rsLabel6.Tag = "Color";
			this.rsLabel6.Text = "Màu";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// enuColor
			// 
			this.enuColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.enuColor.InputMask = ",RED,GREEN,BLUE,YELLOW";
			this.enuColor.Location = new System.Drawing.Point(127, 90);
			this.enuColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.enuColor.MaxLength = 20;
			this.enuColor.Name = "enuColor";
			this.enuColor.Size = new System.Drawing.Size(53, 20);
			this.enuColor.TabIndex = 5;
			// 
			// chkBold
			// 
			this.chkBold.AutoSize = true;
			this.chkBold.Location = new System.Drawing.Point(185, 92);
			this.chkBold.Name = "chkBold";
			this.chkBold.Size = new System.Drawing.Size(47, 17);
			this.chkBold.TabIndex = 6;
			this.chkBold.Tag = "Bold";
			this.chkBold.Text = "Bold";
			this.chkBold.UseVisualStyleBackColor = true;
			// 
			// lbtTen_Tk_Co
			// 
			this.lbtTen_Tk_Co.AutoEllipsis = true;
			this.lbtTen_Tk_Co.AutoSize = true;
			this.lbtTen_Tk_Co.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Tk_Co.Location = new System.Drawing.Point(198, 204);
			this.lbtTen_Tk_Co.Name = "lbtTen_Tk_Co";
			this.lbtTen_Tk_Co.Size = new System.Drawing.Size(88, 13);
			this.lbtTen_Tk_Co.TabIndex = 15;
			this.lbtTen_Tk_Co.Text = "Tên tài khoản có";
			this.lbtTen_Tk_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk_Co
			// 
			this.txtTk_Co.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTk_Co.Location = new System.Drawing.Point(127, 200);
			this.txtTk_Co.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk_Co.Name = "txtTk_Co";
			this.txtTk_Co.Size = new System.Drawing.Size(66, 20);
			this.txtTk_Co.TabIndex = 14;
			// 
			// lblTk_Co
			// 
			this.lblTk_Co.AutoEllipsis = true;
			this.lblTk_Co.AutoSize = true;
			this.lblTk_Co.Location = new System.Drawing.Point(25, 203);
			this.lblTk_Co.Name = "lblTk_Co";
			this.lblTk_Co.Size = new System.Drawing.Size(70, 13);
			this.lblTk_Co.TabIndex = 69;
			this.lblTk_Co.Tag = "Tk_Co";
			this.lblTk_Co.Text = "Tài khoản có";
			this.lblTk_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Tk_No
			// 
			this.lbtTen_Tk_No.AutoEllipsis = true;
			this.lbtTen_Tk_No.AutoSize = true;
			this.lbtTen_Tk_No.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Tk_No.Location = new System.Drawing.Point(198, 181);
			this.lbtTen_Tk_No.Name = "lbtTen_Tk_No";
			this.lbtTen_Tk_No.Size = new System.Drawing.Size(88, 13);
			this.lbtTen_Tk_No.TabIndex = 13;
			this.lbtTen_Tk_No.Text = "Tên tài khoản nợ";
			this.lbtTen_Tk_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk_No
			// 
			this.txtTk_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTk_No.Location = new System.Drawing.Point(127, 178);
			this.txtTk_No.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk_No.Name = "txtTk_No";
			this.txtTk_No.Size = new System.Drawing.Size(66, 20);
			this.txtTk_No.TabIndex = 12;
			// 
			// lblTk_No
			// 
			this.lblTk_No.AutoEllipsis = true;
			this.lblTk_No.AutoSize = true;
			this.lblTk_No.Location = new System.Drawing.Point(25, 181);
			this.lblTk_No.Name = "lblTk_No";
			this.lblTk_No.Size = new System.Drawing.Size(70, 13);
			this.lblTk_No.TabIndex = 67;
			this.lblTk_No.Tag = "Tk_No";
			this.lblTk_No.Text = "Tài khoản nợ";
			this.lblTk_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Km
			// 
			this.lbtTen_Km.AutoEllipsis = true;
			this.lbtTen_Km.AutoSize = true;
			this.lbtTen_Km.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Km.Location = new System.Drawing.Point(253, 227);
			this.lbtTen_Km.Name = "lbtTen_Km";
			this.lbtTen_Km.Size = new System.Drawing.Size(71, 13);
			this.lbtTen_Km.TabIndex = 72;
			this.lbtTen_Km.Text = "Tên bộ phận ";
			this.lbtTen_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Km
			// 
			this.txtMa_Km.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Km.Location = new System.Drawing.Point(127, 222);
			this.txtMa_Km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Km.Name = "txtMa_Km";
			this.txtMa_Km.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Km.TabIndex = 16;
			// 
			// lbMa_Bp
			// 
			this.lbMa_Bp.AutoEllipsis = true;
			this.lbMa_Bp.AutoSize = true;
			this.lbMa_Bp.Location = new System.Drawing.Point(25, 225);
			this.lbMa_Bp.Name = "lbMa_Bp";
			this.lbMa_Bp.Size = new System.Drawing.Size(61, 13);
			this.lbMa_Bp.TabIndex = 71;
			this.lbMa_Bp.Tag = "Ma_Km";
			this.lbMa_Bp.Text = "Khoản mục";
			this.lbMa_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmTn_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 333);
			this.Controls.Add(this.lbtTen_Km);
			this.Controls.Add(this.txtMa_Km);
			this.Controls.Add(this.lbMa_Bp);
			this.Controls.Add(this.lbtTen_Tk_Co);
			this.Controls.Add(this.txtTk_Co);
			this.Controls.Add(this.lblTk_Co);
			this.Controls.Add(this.lbtTen_Tk_No);
			this.Controls.Add(this.txtTk_No);
			this.Controls.Add(this.lblTk_No);
			this.Controls.Add(this.chkIs_Active);
			this.Controls.Add(this.chkIs_Input);
			this.Controls.Add(this.chkBold);
			this.Controls.Add(this.chkIs_Display3);
			this.Controls.Add(this.chkIs_Display2);
			this.Controls.Add(this.chkIs_Display1);
			this.Controls.Add(this.txtGhi_Chu);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.txtCong_Thuc);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.txtDvt);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.txtTen_Tn);
			this.Controls.Add(this.lblDien_Giai);
			this.Controls.Add(this.enuColor);
			this.Controls.Add(this.enuLoai_Tn);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.lbtLoai_Tn);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.numStt);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.txtMa_Tn);
			this.Controls.Add(this.lblTk);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmDmTn_Edit";
			this.Text = "frmDmTn_Edit";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtTen_Tn;
		private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Tn;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxEnum enuLoai_Tn;
		private RosySystem.Control.rsLabelName lbtLoai_Tn;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBox txtCong_Thuc;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBox txtGhi_Chu;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBoxNumber numStt;
		private RosySystem.Control.rsCheckbox chkIs_Display1;
		private RosySystem.Control.rsCheckbox chkIs_Display2;
		private RosySystem.Control.rsCheckbox chkIs_Display3;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsTextBox txtDvt;
		private RosySystem.Control.rsCheckbox chkIs_Input;
		private RosySystem.Control.rsCheckbox chkIs_Active;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsTextBoxEnum enuColor;
		private RosySystem.Control.rsCheckbox chkBold;
		private RosySystem.Control.rsLabel lbtTen_Tk_Co;
		private RosySystem.Control.rsTextBox txtTk_Co;
		private RosySystem.Control.rsLabel lblTk_Co;
		private RosySystem.Control.rsLabel lbtTen_Tk_No;
		private RosySystem.Control.rsTextBox txtTk_No;
		private RosySystem.Control.rsLabel lblTk_No;
		private RosySystem.Control.rsLabel lbtTen_Km;
		private RosySystem.Control.rsTextBox txtMa_Km;
		private RosySystem.Control.rsLabel lbMa_Bp;
	}
}