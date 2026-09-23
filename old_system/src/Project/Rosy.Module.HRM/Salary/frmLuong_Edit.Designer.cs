namespace RosyModule.Salary
{
    partial class frmHSLuongDC_Edit
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
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.txtMa_Tn = new RosySystem.Control.rsTextBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbtTen_Tn = new RosySystem.Control.rsLabelName();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.numTien = new RosySystem.Control.rsTextBoxNumber();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabelName();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = true;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(127, 58);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(96, 20);
            this.dteNgay_Ct.TabIndex = 2;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(25, 61);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(83, 13);
            this.lblDien_Giai.TabIndex = 73;
            this.lblDien_Giai.Tag = "";
            this.lblDien_Giai.Text = "Ngày tính lương";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Tn
            // 
            this.txtMa_Tn.AutoDropDown = null;
            this.txtMa_Tn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tn.Location = new System.Drawing.Point(127, 37);
            this.txtMa_Tn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tn.MaxLength = 20;
            this.txtMa_Tn.Name = "txtMa_Tn";
            this.txtMa_Tn.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Tn.TabIndex = 1;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Location = new System.Drawing.Point(25, 39);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(67, 13);
            this.lblTk.TabIndex = 70;
            this.lblTk.Tag = "Ma_Tn";
            this.lblTk.Text = "Mã thu nhập";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(356, 128);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 43);
            this.btgAccept.TabIndex = 5;
            // 
            // lbtTen_Tn
            // 
            this.lbtTen_Tn.AutoSize = true;
            this.lbtTen_Tn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Tn.Location = new System.Drawing.Point(228, 39);
            this.lbtTen_Tn.Name = "lbtTen_Tn";
            this.lbtTen_Tn.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Tn.TabIndex = 1;
            this.lbtTen_Tn.Tag = "";
            this.lbtTen_Tn.Text = "txtTen_Tn";
            this.lbtTen_Tn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(25, 83);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(34, 13);
            this.rsLabel1.TabIndex = 70;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Giá trị";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTien
            // 
            this.numTien.AutoDropDown = null;
            this.numTien.bFormat = true;
            this.numTien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numTien.Location = new System.Drawing.Point(127, 80);
            this.numTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien.MaxLength = 20;
            this.numTien.Name = "numTien";
            this.numTien.Scale = 2;
            this.numTien.Size = new System.Drawing.Size(96, 20);
            this.numTien.TabIndex = 3;
            this.numTien.Text = "0.00";
            this.numTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien.Value = 0D;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(127, 100);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.MaxLength = 200;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(415, 20);
            this.txtGhi_Chu.TabIndex = 4;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(25, 102);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(86, 13);
            this.rsLabel3.TabIndex = 79;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Lý do điều chỉnh";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(127, 15);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.MaxLength = 20;
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(228, 18);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(93, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 81;
            this.lbtTen_Dt_CbNv.Tag = "";
            this.lbtTen_Dt_CbNv.Text = "txtTen_Dt_CbNnv";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(25, 18);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(72, 13);
            this.rsLabel2.TabIndex = 82;
            this.rsLabel2.Tag = "Ma_Dt_CbNv";
            this.rsLabel2.Text = "Mã nhân viên";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmHSLuongDC_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 178);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.dteNgay_Ct);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.numTien);
            this.Controls.Add(this.txtMa_Tn);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Tn);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmHSLuongDC_Edit";
            this.Text = "frmHSLuongDC_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_Ct;
		private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Tn;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabelName lbtTen_Tn;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabelName lbtTen_Dt_CbNv;
        private RosySystem.Control.rsLabel rsLabel2;
        public RosySystem.Control.rsTextBoxNumber numTien;
	}
}