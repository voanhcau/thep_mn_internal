namespace RosyPhuTung
{
	partial class frmFilterBarcodePt
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
            this.lblMa_Vt = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabelName();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct1 = new RosySystem.Control.rsLabel();
            this.lbStandard_ID = new RosySystem.Control.rsLabel();
            this.lbGrade_ID = new RosySystem.Control.rsLabel();
            this.lbMa_CL = new RosySystem.Control.rsLabel();
            this.txtNum_Lot = new RosySystem.Control.rsTextBox();
            this.cboLot_ID = new RosySystem.Control.rsComboBox();
            this.cboMa_CL = new RosySystem.Control.rsComboBox();
            this.cboGrade_ID = new RosySystem.Control.rsComboBox();
            this.cboStandard_ID = new RosySystem.Control.rsComboBox();
            this.lbLot_ID = new RosySystem.Control.rsLabel();
            this.lbNum_Lot = new RosySystem.Control.rsLabel();
            this.cboMa_Vt = new RosySystem.Control.rsComboBox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(291, 204);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 22;
            // 
            // lblMa_Vt
            // 
            this.lblMa_Vt.AutoEllipsis = true;
            this.lblMa_Vt.AutoSize = true;
            this.lblMa_Vt.Location = new System.Drawing.Point(43, 48);
            this.lblMa_Vt.Name = "lblMa_Vt";
            this.lblMa_Vt.Size = new System.Drawing.Size(49, 13);
            this.lblMa_Vt.TabIndex = 161;
            this.lblMa_Vt.Tag = "";
            this.lblMa_Vt.Text = "Mã hàng";
            this.lblMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(325, 48);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Vt.TabIndex = 160;
            this.lbtTen_Vt.Text = "Tên vật tư";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(328, 21);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // lblNgay_Ct2
            // 
            this.lblNgay_Ct2.AutoEllipsis = true;
            this.lblNgay_Ct2.AutoSize = true;
            this.lblNgay_Ct2.Location = new System.Drawing.Point(241, 24);
            this.lblNgay_Ct2.Name = "lblNgay_Ct2";
            this.lblNgay_Ct2.Size = new System.Drawing.Size(53, 13);
            this.lblNgay_Ct2.TabIndex = 159;
            this.lblNgay_Ct2.Tag = "Ngay_Ct2";
            this.lblNgay_Ct2.Text = "Đến ngày";
            this.lblNgay_Ct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(139, 21);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.Location = new System.Drawing.Point(43, 24);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct1.TabIndex = 158;
            this.lblNgay_Ct1.Tag = "Ngay_Ct1";
            this.lblNgay_Ct1.Text = "Từ ngày";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStandard_ID
            // 
            this.lbStandard_ID.AutoEllipsis = true;
            this.lbStandard_ID.AutoSize = true;
            this.lbStandard_ID.Location = new System.Drawing.Point(43, 72);
            this.lbStandard_ID.Name = "lbStandard_ID";
            this.lbStandard_ID.Size = new System.Drawing.Size(61, 13);
            this.lbStandard_ID.TabIndex = 174;
            this.lbStandard_ID.Tag = "Standard_ID";
            this.lbStandard_ID.Text = "Tiêu chuẩn";
            this.lbStandard_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGrade_ID
            // 
            this.lbGrade_ID.AutoEllipsis = true;
            this.lbGrade_ID.AutoSize = true;
            this.lbGrade_ID.Location = new System.Drawing.Point(43, 96);
            this.lbGrade_ID.Name = "lbGrade_ID";
            this.lbGrade_ID.Size = new System.Drawing.Size(52, 13);
            this.lbGrade_ID.TabIndex = 180;
            this.lbGrade_ID.Tag = "Grade_ID";
            this.lbGrade_ID.Text = "Mác thép";
            this.lbGrade_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_CL
            // 
            this.lbMa_CL.AutoEllipsis = true;
            this.lbMa_CL.AutoSize = true;
            this.lbMa_CL.Location = new System.Drawing.Point(43, 118);
            this.lbMa_CL.Name = "lbMa_CL";
            this.lbMa_CL.Size = new System.Drawing.Size(58, 13);
            this.lbMa_CL.TabIndex = 180;
            this.lbMa_CL.Tag = "Ma_CL";
            this.lbMa_CL.Text = "Chất lượng";
            this.lbMa_CL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNum_Lot
            // 
            this.txtNum_Lot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNum_Lot.Location = new System.Drawing.Point(139, 161);
            this.txtNum_Lot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNum_Lot.Name = "txtNum_Lot";
            this.txtNum_Lot.Size = new System.Drawing.Size(182, 20);
            this.txtNum_Lot.TabIndex = 185;
            this.txtNum_Lot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboLot_ID
            // 
            this.cboLot_ID.DropDownHeight = 95;
            this.cboLot_ID.FormattingEnabled = true;
            this.cboLot_ID.IntegralHeight = false;
            this.cboLot_ID.Location = new System.Drawing.Point(139, 138);
            this.cboLot_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboLot_ID.Name = "cboLot_ID";
            this.cboLot_ID.Size = new System.Drawing.Size(182, 21);
            this.cboLot_ID.TabIndex = 184;
            // 
            // cboMa_CL
            // 
            this.cboMa_CL.DropDownHeight = 95;
            this.cboMa_CL.FormattingEnabled = true;
            this.cboMa_CL.IntegralHeight = false;
            this.cboMa_CL.Location = new System.Drawing.Point(139, 115);
            this.cboMa_CL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_CL.Name = "cboMa_CL";
            this.cboMa_CL.Size = new System.Drawing.Size(182, 21);
            this.cboMa_CL.TabIndex = 183;
            // 
            // cboGrade_ID
            // 
            this.cboGrade_ID.DropDownHeight = 95;
            this.cboGrade_ID.FormattingEnabled = true;
            this.cboGrade_ID.IntegralHeight = false;
            this.cboGrade_ID.Location = new System.Drawing.Point(139, 92);
            this.cboGrade_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboGrade_ID.Name = "cboGrade_ID";
            this.cboGrade_ID.Size = new System.Drawing.Size(182, 21);
            this.cboGrade_ID.TabIndex = 182;
            // 
            // cboStandard_ID
            // 
            this.cboStandard_ID.DropDownHeight = 95;
            this.cboStandard_ID.FormattingEnabled = true;
            this.cboStandard_ID.IntegralHeight = false;
            this.cboStandard_ID.Location = new System.Drawing.Point(139, 69);
            this.cboStandard_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboStandard_ID.Name = "cboStandard_ID";
            this.cboStandard_ID.Size = new System.Drawing.Size(182, 21);
            this.cboStandard_ID.TabIndex = 181;
            // 
            // lbLot_ID
            // 
            this.lbLot_ID.AutoEllipsis = true;
            this.lbLot_ID.AutoSize = true;
            this.lbLot_ID.Location = new System.Drawing.Point(43, 141);
            this.lbLot_ID.Name = "lbLot_ID";
            this.lbLot_ID.Size = new System.Drawing.Size(42, 13);
            this.lbLot_ID.TabIndex = 180;
            this.lbLot_ID.Tag = "Lot_ID";
            this.lbLot_ID.Text = "Lô phôi";
            this.lbLot_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNum_Lot
            // 
            this.lbNum_Lot.AutoEllipsis = true;
            this.lbNum_Lot.AutoSize = true;
            this.lbNum_Lot.Location = new System.Drawing.Point(43, 164);
            this.lbNum_Lot.Name = "lbNum_Lot";
            this.lbNum_Lot.Size = new System.Drawing.Size(68, 13);
            this.lbNum_Lot.TabIndex = 180;
            this.lbNum_Lot.Tag = "Num_Lot";
            this.lbNum_Lot.Text = "Lô sản phẩm";
            this.lbNum_Lot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_Vt
            // 
            this.cboMa_Vt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Vt.DropDownHeight = 95;
            this.cboMa_Vt.FormattingEnabled = true;
            this.cboMa_Vt.IntegralHeight = false;
            this.cboMa_Vt.Location = new System.Drawing.Point(139, 45);
            this.cboMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Vt.Name = "cboMa_Vt";
            this.cboMa_Vt.Size = new System.Drawing.Size(182, 21);
            this.cboMa_Vt.TabIndex = 186;
            // 
            // frmFilterBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.cboMa_Vt);
            this.Controls.Add(this.txtNum_Lot);
            this.Controls.Add(this.cboLot_ID);
            this.Controls.Add(this.cboMa_CL);
            this.Controls.Add(this.cboGrade_ID);
            this.Controls.Add(this.cboStandard_ID);
            this.Controls.Add(this.lbNum_Lot);
            this.Controls.Add(this.lbLot_ID);
            this.Controls.Add(this.lbMa_CL);
            this.Controls.Add(this.lbGrade_ID);
            this.Controls.Add(this.lbStandard_ID);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblMa_Vt);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.dteNgay_Ct2);
            this.Controls.Add(this.lblNgay_Ct2);
            this.Controls.Add(this.dteNgay_Ct1);
            this.Controls.Add(this.lblNgay_Ct1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "frmFilterBarcode";
            this.Text = "frmFilterBarcode";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel lblMa_Vt;
		private RosySystem.Control.rsLabelName lbtTen_Vt;
		private RosySystem.Control.rsDateTime dteNgay_Ct2;
		private RosySystem.Control.rsLabel lblNgay_Ct2;
		private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel lblNgay_Ct1;
        private RosySystem.Control.rsLabel lbStandard_ID;
        private RosySystem.Control.rsLabel lbGrade_ID;
        private RosySystem.Control.rsLabel lbMa_CL;
        private RosySystem.Control.rsTextBox txtNum_Lot;
        private RosySystem.Control.rsComboBox cboLot_ID;
        private RosySystem.Control.rsComboBox cboMa_CL;
        private RosySystem.Control.rsComboBox cboGrade_ID;
        private RosySystem.Control.rsComboBox cboStandard_ID;
        private RosySystem.Control.rsLabel lbLot_ID;
        private RosySystem.Control.rsLabel lbNum_Lot;
        private RosySystem.Control.rsComboBox cboMa_Vt;
	}
}