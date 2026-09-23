namespace RosyList
{
	partial class frmDmThue_Edit
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
			this.lbtTen_Tk = new RosySystem.Control.rsLabel();
			this.txtTk = new RosySystem.Control.rsTextBox();
			this.lbTk = new RosySystem.Control.rsLabel();
			this.numThue_Suat = new RosySystem.Control.rsTextBoxNumber();
			this.lbThue_Suat = new RosySystem.Control.rsLabel();
			this.lbtLoai_Thue = new RosySystem.Control.rsLabel();
			this.txtLoai_Thue = new RosySystem.Control.rsTextBoxEnum();
			this.lbLoai_Thue = new RosySystem.Control.rsLabel();
			this.txtTen_Thue = new RosySystem.Control.rsTextBox();
			this.txtMa_Thue = new RosySystem.Control.rsTextBox();
			this.lbTen_Thue = new RosySystem.Control.rsLabel();
			this.lbMa_Thue = new RosySystem.Control.rsLabel();
			this.lbtTen_Phan_Loai_Thue = new RosySystem.Control.rsLabel();
			this.txtPhan_Loai_Thue = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(553, 309);
			this.btgAccept.TabIndex = 1;
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(726, 293);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.lbtTen_Phan_Loai_Thue);
			this.Page1.Controls.Add(this.txtPhan_Loai_Thue);
			this.Page1.Controls.Add(this.rsLabel2);
			this.Page1.Controls.Add(this.lbtTen_Tk);
			this.Page1.Controls.Add(this.txtTk);
			this.Page1.Controls.Add(this.lbTk);
			this.Page1.Controls.Add(this.numThue_Suat);
			this.Page1.Controls.Add(this.lbThue_Suat);
			this.Page1.Controls.Add(this.lbtLoai_Thue);
			this.Page1.Controls.Add(this.txtLoai_Thue);
			this.Page1.Controls.Add(this.lbLoai_Thue);
			this.Page1.Controls.Add(this.txtTen_Thue);
			this.Page1.Controls.Add(this.txtMa_Thue);
			this.Page1.Controls.Add(this.lbTen_Thue);
			this.Page1.Controls.Add(this.lbMa_Thue);
			this.Page1.Size = new System.Drawing.Size(718, 267);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(718, 279);
			// 
			// txtNgay_Begin
			// 
			this.dteNgay_Begin.Text = "12420007";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 318);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 327);
			this.lblLog.Text = "";
			// 
			// lbtTen_Tk
			// 
			this.lbtTen_Tk.AutoEllipsis = true;
			this.lbtTen_Tk.AutoSize = true;
			this.lbtTen_Tk.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Tk.Location = new System.Drawing.Point(197, 118);
			this.lbtTen_Tk.Name = "lbtTen_Tk";
			this.lbtTen_Tk.Size = new System.Drawing.Size(42, 13);
			this.lbtTen_Tk.TabIndex = 54;
			this.lbtTen_Tk.Text = "Tên Tk";
			this.lbtTen_Tk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk
			// 
			this.txtTk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTk.Location = new System.Drawing.Point(126, 114);
			this.txtTk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk.MaxLength = 20;
			this.txtTk.Name = "txtTk";
			this.txtTk.Size = new System.Drawing.Size(66, 20);
			this.txtTk.TabIndex = 7;
			// 
			// lbTk
			// 
			this.lbTk.AutoEllipsis = true;
			this.lbTk.AutoSize = true;
			this.lbTk.Location = new System.Drawing.Point(15, 115);
			this.lbTk.Name = "lbTk";
			this.lbTk.Size = new System.Drawing.Size(79, 13);
			this.lbTk.TabIndex = 53;
			this.lbTk.Tag = "Tk";
			this.lbTk.Text = "Tài khoản thuế";
			this.lbTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numThue_Suat
			// 
			this.numThue_Suat.bFormat = true;
			this.numThue_Suat.Location = new System.Drawing.Point(126, 92);
			this.numThue_Suat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numThue_Suat.Name = "numThue_Suat";
			this.numThue_Suat.Scale = 2;
			this.numThue_Suat.Size = new System.Drawing.Size(66, 20);
			this.numThue_Suat.TabIndex = 6;
			this.numThue_Suat.Text = "0.00";
			this.numThue_Suat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numThue_Suat.Value = 0D;
			// 
			// lbThue_Suat
			// 
			this.lbThue_Suat.AutoEllipsis = true;
			this.lbThue_Suat.AutoSize = true;
			this.lbThue_Suat.Location = new System.Drawing.Point(15, 95);
			this.lbThue_Suat.Name = "lbThue_Suat";
			this.lbThue_Suat.Size = new System.Drawing.Size(55, 13);
			this.lbThue_Suat.TabIndex = 50;
			this.lbThue_Suat.Tag = "Thue_Suat";
			this.lbThue_Suat.Text = "Thuế suất";
			this.lbThue_Suat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtLoai_Thue
			// 
			this.lbtLoai_Thue.AutoEllipsis = true;
			this.lbtLoai_Thue.AutoSize = true;
			this.lbtLoai_Thue.ForeColor = System.Drawing.Color.Blue;
			this.lbtLoai_Thue.Location = new System.Drawing.Point(157, 72);
			this.lbtLoai_Thue.Name = "lbtLoai_Thue";
			this.lbtLoai_Thue.Size = new System.Drawing.Size(227, 13);
			this.lbtLoai_Thue.TabIndex = 2;
			this.lbtLoai_Thue.Tag = "Loai_Thue_Option";
			this.lbtLoai_Thue.Text = "1- Thuế GTGT đầu vào, 2-Thuế GTGT đầu ra";
			this.lbtLoai_Thue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLoai_Thue
			// 
			this.txtLoai_Thue.InputMask = "1,2";
			this.txtLoai_Thue.Location = new System.Drawing.Point(126, 70);
			this.txtLoai_Thue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtLoai_Thue.MaxLength = 1;
			this.txtLoai_Thue.Name = "txtLoai_Thue";
			this.txtLoai_Thue.Size = new System.Drawing.Size(25, 20);
			this.txtLoai_Thue.TabIndex = 2;
			this.txtLoai_Thue.Text = "1";
			// 
			// lbLoai_Thue
			// 
			this.lbLoai_Thue.AutoEllipsis = true;
			this.lbLoai_Thue.AutoSize = true;
			this.lbLoai_Thue.Location = new System.Drawing.Point(15, 70);
			this.lbLoai_Thue.Name = "lbLoai_Thue";
			this.lbLoai_Thue.Size = new System.Drawing.Size(51, 13);
			this.lbLoai_Thue.TabIndex = 48;
			this.lbLoai_Thue.Tag = "Loai_Thue";
			this.lbLoai_Thue.Text = "Loại thuế";
			this.lbLoai_Thue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTen_Thue
			// 
			this.txtTen_Thue.Location = new System.Drawing.Point(126, 48);
			this.txtTen_Thue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Thue.MaxLength = 100;
			this.txtTen_Thue.Name = "txtTen_Thue";
			this.txtTen_Thue.Size = new System.Drawing.Size(335, 20);
			this.txtTen_Thue.TabIndex = 1;
			// 
			// txtMa_Thue
			// 
			this.txtMa_Thue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Thue.Location = new System.Drawing.Point(126, 26);
			this.txtMa_Thue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Thue.MaxLength = 20;
			this.txtMa_Thue.Name = "txtMa_Thue";
			this.txtMa_Thue.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Thue.TabIndex = 0;
			// 
			// lbTen_Thue
			// 
			this.lbTen_Thue.AutoEllipsis = true;
			this.lbTen_Thue.AutoSize = true;
			this.lbTen_Thue.Location = new System.Drawing.Point(15, 49);
			this.lbTen_Thue.Name = "lbTen_Thue";
			this.lbTen_Thue.Size = new System.Drawing.Size(50, 13);
			this.lbTen_Thue.TabIndex = 46;
			this.lbTen_Thue.Tag = "Ten_Thue";
			this.lbTen_Thue.Text = "Tên thuế";
			this.lbTen_Thue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Thue
			// 
			this.lbMa_Thue.AutoEllipsis = true;
			this.lbMa_Thue.AutoSize = true;
			this.lbMa_Thue.Location = new System.Drawing.Point(15, 26);
			this.lbMa_Thue.Name = "lbMa_Thue";
			this.lbMa_Thue.Size = new System.Drawing.Size(46, 13);
			this.lbMa_Thue.TabIndex = 47;
			this.lbMa_Thue.Tag = "Ma_Thue";
			this.lbMa_Thue.Text = "Mã thuế";
			this.lbMa_Thue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Phan_Loai_Thue
			// 
			this.lbtTen_Phan_Loai_Thue.AutoEllipsis = true;
			this.lbtTen_Phan_Loai_Thue.AutoSize = true;
			this.lbtTen_Phan_Loai_Thue.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Phan_Loai_Thue.Location = new System.Drawing.Point(251, 139);
			this.lbtTen_Phan_Loai_Thue.Name = "lbtTen_Phan_Loai_Thue";
			this.lbtTen_Phan_Loai_Thue.Size = new System.Drawing.Size(96, 13);
			this.lbtTen_Phan_Loai_Thue.TabIndex = 57;
			this.lbtTen_Phan_Loai_Thue.Text = "Tên phân loại thuế";
			this.lbtTen_Phan_Loai_Thue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPhan_Loai_Thue
			// 
			this.txtPhan_Loai_Thue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPhan_Loai_Thue.Location = new System.Drawing.Point(126, 136);
			this.txtPhan_Loai_Thue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtPhan_Loai_Thue.MaxLength = 20;
			this.txtPhan_Loai_Thue.Name = "txtPhan_Loai_Thue";
			this.txtPhan_Loai_Thue.Size = new System.Drawing.Size(120, 20);
			this.txtPhan_Loai_Thue.TabIndex = 8;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(15, 137);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(75, 13);
			this.rsLabel2.TabIndex = 56;
			this.rsLabel2.Tag = "Phan_Loai_Thue";
			this.rsLabel2.Text = "Phân loại thuế";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmThue_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(750, 363);
			this.Name = "frmDmThue_Edit";
			this.Object_ID = "DMTHUE";
			this.Tag = "frmDmThue, ESC";
			this.Text = "frmDmThue";
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

		private RosySystem.Control.rsLabel lbtTen_Tk;
		private RosySystem.Control.rsTextBox txtTk;
		private RosySystem.Control.rsLabel lbTk;
		private RosySystem.Control.rsTextBoxNumber numThue_Suat;
		private RosySystem.Control.rsLabel lbThue_Suat;
		private RosySystem.Control.rsLabel lbtLoai_Thue;
		private RosySystem.Control.rsTextBoxEnum txtLoai_Thue;
		private RosySystem.Control.rsLabel lbLoai_Thue;
		private RosySystem.Control.rsTextBox txtTen_Thue;
		private RosySystem.Control.rsTextBox txtMa_Thue;
		private RosySystem.Control.rsLabel lbTen_Thue;
		private RosySystem.Control.rsLabel lbMa_Thue;
		private RosySystem.Control.rsLabel lbtTen_Phan_Loai_Thue;
		private RosySystem.Control.rsTextBox txtPhan_Loai_Thue;
		private RosySystem.Control.rsLabel rsLabel2;

	}
}