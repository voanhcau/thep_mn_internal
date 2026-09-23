namespace RosyList
{
	partial class frmDmLoai_Hang_Edit
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
			this.txtTen_Loai_Hang = new RosySystem.Control.rsTextBox();
			this.txtMa_Loai_Hang = new RosySystem.Control.rsTextBox();
			this.lbTen_Km = new RosySystem.Control.rsLabel();
			this.lbMa_Km = new RosySystem.Control.rsLabel();
			this.txtQuy_Cach = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numGiaH2_Nhat = new RosySystem.Control.rsTextBoxNumber();
			this.lbStt = new RosySystem.Control.rsLabel();
			this.numGiaH2_My = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.numGiaH2_NamPhi = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.numGiaH2_Uc = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.numGiaH2_Kored = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(347, 326);
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(516, 314);
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.numGiaH2_Kored);
			this.Page1.Controls.Add(this.rsLabel5);
			this.Page1.Controls.Add(this.numGiaH2_Uc);
			this.Page1.Controls.Add(this.rsLabel4);
			this.Page1.Controls.Add(this.numGiaH2_NamPhi);
			this.Page1.Controls.Add(this.rsLabel3);
			this.Page1.Controls.Add(this.numGiaH2_My);
			this.Page1.Controls.Add(this.rsLabel2);
			this.Page1.Controls.Add(this.numGiaH2_Nhat);
			this.Page1.Controls.Add(this.lbStt);
			this.Page1.Controls.Add(this.txtQuy_Cach);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Controls.Add(this.txtTen_Loai_Hang);
			this.Page1.Controls.Add(this.txtMa_Loai_Hang);
			this.Page1.Controls.Add(this.lbTen_Km);
			this.Page1.Controls.Add(this.lbMa_Km);
			this.Page1.Size = new System.Drawing.Size(508, 288);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(508, 248);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 335);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 344);
			this.lblLog.Size = new System.Drawing.Size(269, 22);
			this.lblLog.Text = "";
			// 
			// txtTen_Loai_Hang
			// 
			this.txtTen_Loai_Hang.AutoDropDown = null;
			this.txtTen_Loai_Hang.Location = new System.Drawing.Point(118, 48);
			this.txtTen_Loai_Hang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Loai_Hang.MaxLength = 300;
			this.txtTen_Loai_Hang.Multiline = true;
			this.txtTen_Loai_Hang.Name = "txtTen_Loai_Hang";
			this.txtTen_Loai_Hang.Size = new System.Drawing.Size(335, 81);
			this.txtTen_Loai_Hang.TabIndex = 2;
			// 
			// txtMa_Loai_Hang
			// 
			this.txtMa_Loai_Hang.AutoDropDown = null;
			this.txtMa_Loai_Hang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Loai_Hang.Location = new System.Drawing.Point(118, 26);
			this.txtMa_Loai_Hang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Loai_Hang.MaxLength = 20;
			this.txtMa_Loai_Hang.Name = "txtMa_Loai_Hang";
			this.txtMa_Loai_Hang.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Loai_Hang.TabIndex = 1;
			// 
			// lbTen_Km
			// 
			this.lbTen_Km.AutoEllipsis = true;
			this.lbTen_Km.AutoSize = true;
			this.lbTen_Km.Location = new System.Drawing.Point(7, 49);
			this.lbTen_Km.Name = "lbTen_Km";
			this.lbTen_Km.Size = new System.Drawing.Size(72, 13);
			this.lbTen_Km.TabIndex = 19;
			this.lbTen_Km.Tag = "";
			this.lbTen_Km.Text = "Tên loại hàng";
			this.lbTen_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbTen_Km.Click += new System.EventHandler(this.lbTen_Km_Click);
			// 
			// lbMa_Km
			// 
			this.lbMa_Km.AutoEllipsis = true;
			this.lbMa_Km.AutoSize = true;
			this.lbMa_Km.Location = new System.Drawing.Point(7, 26);
			this.lbMa_Km.Name = "lbMa_Km";
			this.lbMa_Km.Size = new System.Drawing.Size(68, 13);
			this.lbMa_Km.TabIndex = 20;
			this.lbMa_Km.Tag = "";
			this.lbMa_Km.Text = "Mã loại hàng";
			this.lbMa_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtQuy_Cach
			// 
			this.txtQuy_Cach.AutoDropDown = null;
			this.txtQuy_Cach.Location = new System.Drawing.Point(118, 131);
			this.txtQuy_Cach.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtQuy_Cach.MaxLength = 100;
			this.txtQuy_Cach.Name = "txtQuy_Cach";
			this.txtQuy_Cach.Size = new System.Drawing.Size(335, 20);
			this.txtQuy_Cach.TabIndex = 3;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(7, 132);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(53, 13);
			this.rsLabel1.TabIndex = 22;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Quy cách";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numGiaH2_Nhat
			// 
			this.numGiaH2_Nhat.AutoDropDown = null;
			this.numGiaH2_Nhat.bFormat = true;
			this.numGiaH2_Nhat.Location = new System.Drawing.Point(118, 153);
			this.numGiaH2_Nhat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numGiaH2_Nhat.Name = "numGiaH2_Nhat";
			this.numGiaH2_Nhat.Scale = 0;
			this.numGiaH2_Nhat.Size = new System.Drawing.Size(60, 20);
			this.numGiaH2_Nhat.TabIndex = 4;
			this.numGiaH2_Nhat.Text = "0";
			this.numGiaH2_Nhat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numGiaH2_Nhat.Value = 0D;
			// 
			// lbStt
			// 
			this.lbStt.AutoEllipsis = true;
			this.lbStt.AutoSize = true;
			this.lbStt.Location = new System.Drawing.Point(7, 156);
			this.lbStt.Name = "lbStt";
			this.lbStt.Size = new System.Drawing.Size(92, 13);
			this.lbStt.TabIndex = 24;
			this.lbStt.Text = "Quy đổi H2/ Nhật";
			this.lbStt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numGiaH2_My
			// 
			this.numGiaH2_My.AutoDropDown = null;
			this.numGiaH2_My.bFormat = true;
			this.numGiaH2_My.Location = new System.Drawing.Point(118, 175);
			this.numGiaH2_My.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numGiaH2_My.Name = "numGiaH2_My";
			this.numGiaH2_My.Scale = 0;
			this.numGiaH2_My.Size = new System.Drawing.Size(60, 20);
			this.numGiaH2_My.TabIndex = 5;
			this.numGiaH2_My.Text = "0";
			this.numGiaH2_My.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numGiaH2_My.Value = 0D;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(7, 178);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(83, 13);
			this.rsLabel2.TabIndex = 26;
			this.rsLabel2.Text = "Quy đổi H2/ Mỹ";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numGiaH2_NamPhi
			// 
			this.numGiaH2_NamPhi.AutoDropDown = null;
			this.numGiaH2_NamPhi.bFormat = true;
			this.numGiaH2_NamPhi.Location = new System.Drawing.Point(118, 197);
			this.numGiaH2_NamPhi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numGiaH2_NamPhi.Name = "numGiaH2_NamPhi";
			this.numGiaH2_NamPhi.Scale = 0;
			this.numGiaH2_NamPhi.Size = new System.Drawing.Size(60, 20);
			this.numGiaH2_NamPhi.TabIndex = 6;
			this.numGiaH2_NamPhi.Text = "0";
			this.numGiaH2_NamPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numGiaH2_NamPhi.Value = 0D;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(7, 200);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(109, 13);
			this.rsLabel3.TabIndex = 28;
			this.rsLabel3.Text = "Quy đổi H2/ Nam Phi";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numGiaH2_Uc
			// 
			this.numGiaH2_Uc.AutoDropDown = null;
			this.numGiaH2_Uc.bFormat = true;
			this.numGiaH2_Uc.Location = new System.Drawing.Point(118, 219);
			this.numGiaH2_Uc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numGiaH2_Uc.Name = "numGiaH2_Uc";
			this.numGiaH2_Uc.Scale = 0;
			this.numGiaH2_Uc.Size = new System.Drawing.Size(60, 20);
			this.numGiaH2_Uc.TabIndex = 7;
			this.numGiaH2_Uc.Text = "0";
			this.numGiaH2_Uc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numGiaH2_Uc.Value = 0D;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(7, 222);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(83, 13);
			this.rsLabel4.TabIndex = 30;
			this.rsLabel4.Text = "Quy đổi H2/ Úc";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numGiaH2_Kored
			// 
			this.numGiaH2_Kored.AutoDropDown = null;
			this.numGiaH2_Kored.bFormat = true;
			this.numGiaH2_Kored.Location = new System.Drawing.Point(118, 241);
			this.numGiaH2_Kored.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numGiaH2_Kored.Name = "numGiaH2_Kored";
			this.numGiaH2_Kored.Scale = 0;
			this.numGiaH2_Kored.Size = new System.Drawing.Size(60, 20);
			this.numGiaH2_Kored.TabIndex = 8;
			this.numGiaH2_Kored.Text = "0";
			this.numGiaH2_Kored.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numGiaH2_Kored.Value = 0D;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(7, 244);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(97, 13);
			this.rsLabel5.TabIndex = 32;
			this.rsLabel5.Text = "Quy đổi H2/ Korea";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmLoai_Hang_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(540, 379);
			this.Name = "frmDmLoai_Hang_Edit";
			this.Object_ID = "DMLOAIHANG";
			this.Tag = "frmDmKm, ESC";
			this.Text = "frmDmKm";
			this.tabEdit.ResumeLayout(false);
			this.Page1.ResumeLayout(false);
			this.Page1.PerformLayout();
			this.Page2.ResumeLayout(false);
			this.Page2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtTen_Loai_Hang;
		private RosySystem.Control.rsTextBox txtMa_Loai_Hang;
		private RosySystem.Control.rsLabel lbTen_Km;
		private RosySystem.Control.rsLabel lbMa_Km;
		private RosySystem.Control.rsTextBox txtQuy_Cach;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxNumber numGiaH2_Nhat;
		private RosySystem.Control.rsLabel lbStt;
		private RosySystem.Control.rsTextBoxNumber numGiaH2_Uc;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBoxNumber numGiaH2_NamPhi;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBoxNumber numGiaH2_My;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBoxNumber numGiaH2_Kored;
		private RosySystem.Control.rsLabel rsLabel5;

	}
}