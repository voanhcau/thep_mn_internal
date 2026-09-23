namespace RosyModule.Manufactory
{
    partial class frmSuCoLuyen_Edit
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
            this.txtMa_Su_Co = new RosySystem.Control.rsTextBox();
            this.lbtTen_Su_Co = new RosySystem.Control.rsLabelName();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtNguyen_Nhan = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.numSo_Phut_Ngung = new RosySystem.Control.rsTextBoxNumber();
            this.dteNgay_Cham_Cong = new RosySystem.Control.rsDateTime();
            this.rsTextBoxNumber2 = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtSo_Me = new RosySystem.Control.rsTextBox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(400, 132);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(184, 47);
            this.btgAccept.TabIndex = 4;
            // 
            // txtMa_Su_Co
            // 
            this.txtMa_Su_Co.AutoDropDown = null;
            this.txtMa_Su_Co.Location = new System.Drawing.Point(110, 31);
            this.txtMa_Su_Co.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Su_Co.Name = "txtMa_Su_Co";
            this.txtMa_Su_Co.Size = new System.Drawing.Size(100, 20);
            this.txtMa_Su_Co.TabIndex = 1;
            this.txtMa_Su_Co.Tag = "Ma_Vt";
            // 
            // lbtTen_Su_Co
            // 
            this.lbtTen_Su_Co.AutoSize = true;
            this.lbtTen_Su_Co.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Su_Co.Location = new System.Drawing.Point(213, 34);
            this.lbtTen_Su_Co.Name = "lbtTen_Su_Co";
            this.lbtTen_Su_Co.Size = new System.Drawing.Size(64, 13);
            this.lbtTen_Su_Co.TabIndex = 7;
            this.lbtTen_Su_Co.Text = "Ten_Su_Co";
            this.lbtTen_Su_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(8, 54);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(77, 13);
            this.rsLabel5.TabIndex = 20;
            this.rsLabel5.Text = "Số phút ngưng";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(8, 86);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(71, 13);
            this.rsLabel2.TabIndex = 22;
            this.rsLabel2.Text = "Nguyên nhân";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNguyen_Nhan
            // 
            this.txtNguyen_Nhan.AutoDropDown = null;
            this.txtNguyen_Nhan.Location = new System.Drawing.Point(110, 73);
            this.txtNguyen_Nhan.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtNguyen_Nhan.Multiline = true;
            this.txtNguyen_Nhan.Name = "txtNguyen_Nhan";
            this.txtNguyen_Nhan.Size = new System.Drawing.Size(476, 32);
            this.txtNguyen_Nhan.TabIndex = 3;
            this.txtNguyen_Nhan.Tag = "";
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(10, 34);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(56, 13);
            this.rsLabel6.TabIndex = 25;
            this.rsLabel6.Text = "Loại sự cố";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Phut_Ngung
            // 
            this.numSo_Phut_Ngung.AutoDropDown = null;
            this.numSo_Phut_Ngung.bFormat = true;
            this.numSo_Phut_Ngung.Location = new System.Drawing.Point(110, 52);
            this.numSo_Phut_Ngung.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numSo_Phut_Ngung.Name = "numSo_Phut_Ngung";
            this.numSo_Phut_Ngung.Scale = 0;
            this.numSo_Phut_Ngung.Size = new System.Drawing.Size(68, 20);
            this.numSo_Phut_Ngung.TabIndex = 2;
            this.numSo_Phut_Ngung.Tag = "Gia";
            this.numSo_Phut_Ngung.Text = "0";
            this.numSo_Phut_Ngung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Phut_Ngung.Value = 0D;
            // 
            // dteNgay_Cham_Cong
            // 
            this.dteNgay_Cham_Cong.bAllowEmpty = true;
            this.dteNgay_Cham_Cong.bSelectOnFocus = false;
            this.dteNgay_Cham_Cong.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Cham_Cong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Cham_Cong.Location = new System.Drawing.Point(147, 29);
            this.dteNgay_Cham_Cong.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Cham_Cong.Mask = "00:00:0000";
            this.dteNgay_Cham_Cong.Name = "dteNgay_Cham_Cong";
            this.dteNgay_Cham_Cong.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Cham_Cong.TabIndex = 28;
            // 
            // rsTextBoxNumber2
            // 
            this.rsTextBoxNumber2.AutoDropDown = null;
            this.rsTextBoxNumber2.bFormat = true;
            this.rsTextBoxNumber2.Location = new System.Drawing.Point(147, 53);
            this.rsTextBoxNumber2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.rsTextBoxNumber2.Name = "rsTextBoxNumber2";
            this.rsTextBoxNumber2.Scale = 0;
            this.rsTextBoxNumber2.Size = new System.Drawing.Size(89, 20);
            this.rsTextBoxNumber2.TabIndex = 26;
            this.rsTextBoxNumber2.Tag = "Gia";
            this.rsTextBoxNumber2.Text = "0";
            this.rsTextBoxNumber2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rsTextBoxNumber2.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(8, 12);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(37, 13);
            this.rsLabel1.TabIndex = 20;
            this.rsLabel1.Text = "Số mẻ";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Me
            // 
            this.txtSo_Me.AutoDropDown = null;
            this.txtSo_Me.Location = new System.Drawing.Point(110, 9);
            this.txtSo_Me.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtSo_Me.Name = "txtSo_Me";
            this.txtSo_Me.Size = new System.Drawing.Size(100, 20);
            this.txtSo_Me.TabIndex = 0;
            this.txtSo_Me.Tag = "Ma_Vt";
            // 
            // frmSuCoLuyen_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 188);
            this.Controls.Add(this.numSo_Phut_Ngung);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtSo_Me);
            this.Controls.Add(this.txtMa_Su_Co);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtNguyen_Nhan);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lbtTen_Su_Co);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmSuCoLuyen_Edit";
            this.Tag = "frmSuCoLuyen_Edit, ESC";
            this.Text = "frmSuCoLuyen_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtMa_Su_Co;
        private RosySystem.Control.rsLabelName lbtTen_Su_Co;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtNguyen_Nhan;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBoxNumber numSo_Phut_Ngung;
        private RosySystem.Control.rsDateTime dteNgay_Cham_Cong;
        private RosySystem.Control.rsTextBoxNumber rsTextBoxNumber2;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtSo_Me;
	}
}