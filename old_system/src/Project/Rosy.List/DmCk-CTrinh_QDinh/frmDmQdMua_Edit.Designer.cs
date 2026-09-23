namespace RosyList
{
    partial class frmDmQdMua_Edit
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
            this.txtSo_QD = new RosySystem.Control.rsTextBox();
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.lbtNgay_QD = new RosySystem.Control.rsLabel();
            this.dteNgay_QD = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Het_Han = new RosySystem.Control.rsDateTime();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.txtSo_Qd_Modify = new RosySystem.Control.rsTextBox();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.dteNgay_Thay_The = new RosySystem.Control.rsDateTime();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(374, 210);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabEdit.Size = new System.Drawing.Size(544, 197);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtMa_Dt);
            this.Page1.Controls.Add(this.lbtTen_Dt);
            this.Page1.Controls.Add(this.rsLabel11);
            this.Page1.Controls.Add(this.dteNgay_Thay_The);
            this.Page1.Controls.Add(this.dteNgay_Het_Han);
            this.Page1.Controls.Add(this.dteNgay_QD);
            this.Page1.Controls.Add(this.rsLabel10);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.lbtNgay_QD);
            this.Page1.Controls.Add(this.txtSo_Qd_Modify);
            this.Page1.Controls.Add(this.rsLabel8);
            this.Page1.Controls.Add(this.txtSo_QD);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Page1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Page1.Size = new System.Drawing.Size(536, 171);
            // 
            // Page2
            // 
            this.Page2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Page2.Size = new System.Drawing.Size(536, 171);
            // 
            // dteNgay_End
            // 
            this.dteNgay_End.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // dteNgay_Begin
            // 
            this.dteNgay_Begin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 218);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 227);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Size = new System.Drawing.Size(323, 22);
            this.lblLog.Text = "";
            // 
            // txtSo_QD
            // 
            this.txtSo_QD.AutoDropDown = null;
            this.txtSo_QD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_QD.Location = new System.Drawing.Point(115, 22);
            this.txtSo_QD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_QD.MaxLength = 50;
            this.txtSo_QD.Name = "txtSo_QD";
            this.txtSo_QD.Size = new System.Drawing.Size(275, 20);
            this.txtSo_QD.TabIndex = 0;
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(8, 25);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(39, 13);
            this.lbMa_Kho.TabIndex = 20;
            this.lbMa_Kho.Tag = "So_QD";
            this.lbMa_Kho.Text = "Số QĐ";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtNgay_QD
            // 
            this.lbtNgay_QD.AutoEllipsis = true;
            this.lbtNgay_QD.AutoSize = true;
            this.lbtNgay_QD.Location = new System.Drawing.Point(8, 52);
            this.lbtNgay_QD.Name = "lbtNgay_QD";
            this.lbtNgay_QD.Size = new System.Drawing.Size(51, 13);
            this.lbtNgay_QD.TabIndex = 21;
            this.lbtNgay_QD.Text = "Ngày QĐ";
            this.lbtNgay_QD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_QD
            // 
            this.dteNgay_QD.bAllowEmpty = true;
            this.dteNgay_QD.bSelectOnFocus = false;
            this.dteNgay_QD.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_QD.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_QD.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_QD.Location = new System.Drawing.Point(115, 49);
            this.dteNgay_QD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_QD.Mask = "00/00/0000";
            this.dteNgay_QD.Name = "dteNgay_QD";
            this.dteNgay_QD.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_QD.TabIndex = 1;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(248, 55);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(71, 13);
            this.rsLabel2.TabIndex = 21;
            this.rsLabel2.Text = "Ngày hết hạn";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Het_Han
            // 
            this.dteNgay_Het_Han.bAllowEmpty = true;
            this.dteNgay_Het_Han.bSelectOnFocus = false;
            this.dteNgay_Het_Han.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Het_Han.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Het_Han.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Het_Han.Location = new System.Drawing.Point(324, 52);
            this.dteNgay_Het_Han.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Het_Han.Mask = "00/00/0000";
            this.dteNgay_Het_Han.Name = "dteNgay_Het_Han";
            this.dteNgay_Het_Han.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Het_Han.TabIndex = 2;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(7, 110);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(108, 13);
            this.rsLabel8.TabIndex = 20;
            this.rsLabel8.Tag = "So_QD_Modify";
            this.rsLabel8.Text = "Số QĐ được thay thế";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Qd_Modify
            // 
            this.txtSo_Qd_Modify.AutoDropDown = null;
            this.txtSo_Qd_Modify.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Qd_Modify.Location = new System.Drawing.Point(115, 107);
            this.txtSo_Qd_Modify.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Qd_Modify.MaxLength = 20;
            this.txtSo_Qd_Modify.Name = "txtSo_Qd_Modify";
            this.txtSo_Qd_Modify.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Qd_Modify.TabIndex = 4;
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Location = new System.Drawing.Point(306, 115);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(73, 13);
            this.rsLabel10.TabIndex = 21;
            this.rsLabel10.Tag = "Ngay_Thay_The";
            this.rsLabel10.Text = "Ngày thay thế";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Thay_The
            // 
            this.dteNgay_Thay_The.bAllowEmpty = true;
            this.dteNgay_Thay_The.bSelectOnFocus = false;
            this.dteNgay_Thay_The.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Thay_The.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Thay_The.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Thay_The.Location = new System.Drawing.Point(405, 110);
            this.dteNgay_Thay_The.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Thay_The.Mask = "00/00/0000";
            this.dteNgay_Thay_The.Name = "dteNgay_Thay_The";
            this.dteNgay_Thay_The.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Thay_The.TabIndex = 5;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(8, 81);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(70, 13);
            this.rsLabel11.TabIndex = 153;
            this.rsLabel11.Text = "Mã đối tượng";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(245, 81);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(74, 13);
            this.lbtTen_Dt.TabIndex = 154;
            this.lbtTen_Dt.Tag = "";
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(115, 78);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 3;
            this.txtMa_Dt.Tag = "Ma_Dt";
            // 
            // frmDmQdMua_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 259);
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.Name = "frmDmQdMua_Edit";
            this.Object_ID = "DMQDMUA";
            this.Tag = "frmDmQd, ESC";
            this.Text = " frmDMQDMUAPL";
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

        private RosySystem.Control.rsTextBox txtSo_QD;
        private RosySystem.Control.rsLabel lbMa_Kho;
		private RosySystem.Control.rsLabel lbtNgay_QD;
        private RosySystem.Control.rsDateTime dteNgay_QD;
		private RosySystem.Control.rsDateTime dteNgay_Het_Han;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsDateTime dteNgay_Thay_The;
		private RosySystem.Control.rsLabel rsLabel10;
		private RosySystem.Control.rsTextBox txtSo_Qd_Modify;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsTextBox txtMa_Dt;
		private RosySystem.Control.rsLabel lbtTen_Dt;
		private RosySystem.Control.rsLabel rsLabel11;


	}
}