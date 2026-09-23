namespace RosyModule.Salary
{
    partial class frmDGBPCT_Edit
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
            this.numGia = new RosySystem.Control.rsTextBoxNumber();
            this.lbtDvt = new System.Windows.Forms.Label();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.numSL_NV = new RosySystem.Control.rsTextBoxNumber();
            this.SuspendLayout();
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(127, 46);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(96, 20);
            this.dteNgay_Ap.TabIndex = 1;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(25, 49);
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
            this.txtMa_Bp_Ct.Location = new System.Drawing.Point(127, 24);
            this.txtMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp_Ct.MaxLength = 20;
            this.txtMa_Bp_Ct.Name = "txtMa_Bp_Ct";
            this.txtMa_Bp_Ct.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Bp_Ct.TabIndex = 0;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Location = new System.Drawing.Point(25, 27);
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
            this.btgAccept.Location = new System.Drawing.Point(356, 111);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 43);
            this.btgAccept.TabIndex = 5;
            // 
            // lbtTen_Bp_Ct
            // 
            this.lbtTen_Bp_Ct.AutoSize = true;
            this.lbtTen_Bp_Ct.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp_Ct.Location = new System.Drawing.Point(228, 27);
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
            this.rsLabel1.Location = new System.Drawing.Point(25, 96);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(44, 13);
            this.rsLabel1.TabIndex = 70;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Đơn giá";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGia
            // 
            this.numGia.AutoDropDown = null;
            this.numGia.bFormat = true;
            this.numGia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numGia.Location = new System.Drawing.Point(127, 93);
            this.numGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numGia.MaxLength = 20;
            this.numGia.Name = "numGia";
            this.numGia.Scale = 0;
            this.numGia.Size = new System.Drawing.Size(123, 20);
            this.numGia.TabIndex = 4;
            this.numGia.Text = "0";
            this.numGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia.Value = 0D;
            // 
            // lbtDvt
            // 
            this.lbtDvt.AutoSize = true;
            this.lbtDvt.Location = new System.Drawing.Point(254, 95);
            this.lbtDvt.Name = "lbtDvt";
            this.lbtDvt.Size = new System.Drawing.Size(32, 13);
            this.lbtDvt.TabIndex = 74;
            this.lbtDvt.Text = "đồng";
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(25, 73);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(70, 13);
            this.rsLabel2.TabIndex = 70;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Số nhân viên";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSL_NV
            // 
            this.numSL_NV.AutoDropDown = null;
            this.numSL_NV.bFormat = true;
            this.numSL_NV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numSL_NV.Location = new System.Drawing.Point(127, 70);
            this.numSL_NV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSL_NV.MaxLength = 20;
            this.numSL_NV.Name = "numSL_NV";
            this.numSL_NV.Scale = 0;
            this.numSL_NV.Size = new System.Drawing.Size(96, 20);
            this.numSL_NV.TabIndex = 3;
            this.numSL_NV.Text = "0";
            this.numSL_NV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSL_NV.Value = 0D;
            // 
            // frmDGBPCT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 161);
            this.Controls.Add(this.lbtDvt);
            this.Controls.Add(this.dteNgay_Ap);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.numSL_NV);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtMa_Bp_Ct);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Bp_Ct);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmDGBPCT_Edit";
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
		private RosySystem.Control.rsTextBoxNumber numGia;
		private System.Windows.Forms.Label lbtDvt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numSL_NV;
	}
}