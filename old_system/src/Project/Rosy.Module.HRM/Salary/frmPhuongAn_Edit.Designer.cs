namespace RosyModule.Salary
{
    partial class frmPhuongAn_Edit
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
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.txtMa_Bp_Ct = new RosySystem.Control.rsTextBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbtTen_Bp_Ct = new RosySystem.Control.rsLabelName();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.chkIs_Ca = new RosySystem.Control.rsCheckbox();
            this.btMa_Bp_Luong = new RosySystem.Control.rsButton();
            this.txtMa_Bp_Luong = new RosySystem.Control.rsTextBox();
            this.btMa_Bp_Luong_Ca = new RosySystem.Control.rsButton();
            this.txtMa_Bp_Luong_Ca = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(146, 42);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(96, 20);
            this.dteNgay_Ap.TabIndex = 2;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(93, 45);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(47, 13);
            this.lblDien_Giai.TabIndex = 73;
            this.lblDien_Giai.Tag = "Ngay_Ap";
            this.lblDien_Giai.Text = "Ngày áp";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Bp_Ct
            // 
            this.txtMa_Bp_Ct.AutoDropDown = null;
            this.txtMa_Bp_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp_Ct.Location = new System.Drawing.Point(146, 20);
            this.txtMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp_Ct.MaxLength = 20;
            this.txtMa_Bp_Ct.Name = "txtMa_Bp_Ct";
            this.txtMa_Bp_Ct.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Bp_Ct.TabIndex = 1;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Location = new System.Drawing.Point(73, 23);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(67, 13);
            this.lblTk.TabIndex = 70;
            this.lblTk.Tag = "Ma_Bp_Ct";
            this.lblTk.Text = "Mã thu nhập";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(1281, 142);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 43);
            this.btgAccept.TabIndex = 5;
            // 
            // lbtTen_Bp_Ct
            // 
            this.lbtTen_Bp_Ct.AutoSize = true;
            this.lbtTen_Bp_Ct.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp_Ct.Location = new System.Drawing.Point(247, 23);
            this.lbtTen_Bp_Ct.Name = "lbtTen_Bp_Ct";
            this.lbtTen_Bp_Ct.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Bp_Ct.TabIndex = 1;
            this.lbtTen_Bp_Ct.Tag = "";
            this.lbtTen_Bp_Ct.Text = "txtTen_Tn";
            this.lbtTen_Bp_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(-1, 92);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(149, 13);
            this.rsLabel1.TabIndex = 70;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Danh sách bộ phận được PB ";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(-4, 69);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(144, 13);
            this.rsLabel2.TabIndex = 70;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Danh sách mã BP tính lương";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIs_Ca
            // 
            this.chkIs_Ca.AutoSize = true;
            this.chkIs_Ca.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIs_Ca.ForeColor = System.Drawing.Color.Red;
            this.chkIs_Ca.Location = new System.Drawing.Point(146, 131);
            this.chkIs_Ca.Name = "chkIs_Ca";
            this.chkIs_Ca.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIs_Ca.Size = new System.Drawing.Size(214, 17);
            this.chkIs_Ca.TabIndex = 5;
            this.chkIs_Ca.Text = "BP đi ca hưởng lương cùng hành chính";
            this.chkIs_Ca.UseVisualStyleBackColor = true;
            // 
            // btMa_Bp_Luong
            // 
            this.btMa_Bp_Luong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btMa_Bp_Luong.Location = new System.Drawing.Point(1443, 64);
            this.btMa_Bp_Luong.Margin = new System.Windows.Forms.Padding(0);
            this.btMa_Bp_Luong.Name = "btMa_Bp_Luong";
            this.btMa_Bp_Luong.Size = new System.Drawing.Size(23, 22);
            this.btMa_Bp_Luong.TabIndex = 77;
            this.btMa_Bp_Luong.TabStop = false;
            this.btMa_Bp_Luong.Text = "...";
            this.btMa_Bp_Luong.UseVisualStyleBackColor = true;
            // 
            // txtMa_Bp_Luong
            // 
            this.txtMa_Bp_Luong.AutoDropDown = null;
            this.txtMa_Bp_Luong.Location = new System.Drawing.Point(146, 66);
            this.txtMa_Bp_Luong.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Bp_Luong.Name = "txtMa_Bp_Luong";
            this.txtMa_Bp_Luong.Size = new System.Drawing.Size(1292, 20);
            this.txtMa_Bp_Luong.TabIndex = 3;
            this.txtMa_Bp_Luong.Tag = "Ma_Vt";
            // 
            // btMa_Bp_Luong_Ca
            // 
            this.btMa_Bp_Luong_Ca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btMa_Bp_Luong_Ca.Location = new System.Drawing.Point(1443, 87);
            this.btMa_Bp_Luong_Ca.Margin = new System.Windows.Forms.Padding(0);
            this.btMa_Bp_Luong_Ca.Name = "btMa_Bp_Luong_Ca";
            this.btMa_Bp_Luong_Ca.Size = new System.Drawing.Size(23, 22);
            this.btMa_Bp_Luong_Ca.TabIndex = 79;
            this.btMa_Bp_Luong_Ca.TabStop = false;
            this.btMa_Bp_Luong_Ca.Text = "...";
            this.btMa_Bp_Luong_Ca.UseVisualStyleBackColor = true;
            // 
            // txtMa_Bp_Luong_Ca
            // 
            this.txtMa_Bp_Luong_Ca.AutoDropDown = null;
            this.txtMa_Bp_Luong_Ca.Location = new System.Drawing.Point(146, 89);
            this.txtMa_Bp_Luong_Ca.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Bp_Luong_Ca.Name = "txtMa_Bp_Luong_Ca";
            this.txtMa_Bp_Luong_Ca.Size = new System.Drawing.Size(1292, 20);
            this.txtMa_Bp_Luong_Ca.TabIndex = 4;
            this.txtMa_Bp_Luong_Ca.Tag = "Ma_Vt";
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(-1, 107);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(141, 13);
            this.rsLabel3.TabIndex = 80;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "quỹ lương ca và hành chính";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPhuongAn_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 192);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.btMa_Bp_Luong_Ca);
            this.Controls.Add(this.txtMa_Bp_Luong_Ca);
            this.Controls.Add(this.btMa_Bp_Luong);
            this.Controls.Add(this.txtMa_Bp_Luong);
            this.Controls.Add(this.chkIs_Ca);
            this.Controls.Add(this.dteNgay_Ap);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtMa_Bp_Ct);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Bp_Ct);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmPhuongAn_Edit";
            this.Text = "frmDGBPCT_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_Ap;
		private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Bp_Ct;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabelName lbtTen_Bp_Ct;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsCheckbox chkIs_Ca;
        private RosySystem.Control.rsButton btMa_Bp_Luong;
        private RosySystem.Control.rsTextBox txtMa_Bp_Luong;
        private RosySystem.Control.rsButton btMa_Bp_Luong_Ca;
        private RosySystem.Control.rsTextBox txtMa_Bp_Luong_Ca;
        private RosySystem.Control.rsLabel rsLabel3;
	}
}