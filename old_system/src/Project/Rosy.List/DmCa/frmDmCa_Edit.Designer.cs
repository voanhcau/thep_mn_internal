namespace RosyList
{
	partial class frmDmCa_Edit
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
            this.cboCa = new RosySystem.Control.rsComboBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Sx = new RosySystem.Control.rsDateTime();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv_TC = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtGio_Begin = new RosySystem.Control.rsComboBox();
            this.lblTC = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv_KCS = new RosySystem.Control.rsTextBox();
            this.lblNVCan = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv_Can = new RosySystem.Control.rsTextBox();
            this.lbtTen_CbNv_TC = new RosySystem.Control.rsLabelName();
            this.lbtTen_CbNv_KCS = new RosySystem.Control.rsLabelName();
            this.lbtTen_CbNv_Can = new RosySystem.Control.rsLabelName();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtGio_End = new RosySystem.Control.rsComboBox();
            this.txtMa_Ca = new RosySystem.Control.rsTextBox();
            this.numSo_Ca = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.txtKip = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabelName1 = new RosySystem.Control.rsLabelName();
            this.txtXuong = new RosySystem.Control.rsTextBoxNumber();
            this.lblXuong = new RosySystem.Control.rsLabel();
            this.lblXuong1 = new RosySystem.Control.rsLabelName();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(397, 275);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(567, 262);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtKip);
            this.Page1.Controls.Add(this.lblXuong);
            this.Page1.Controls.Add(this.rsLabel8);
            this.Page1.Controls.Add(this.txtXuong);
            this.Page1.Controls.Add(this.numSo_Ca);
            this.Page1.Controls.Add(this.txtMa_Ca);
            this.Page1.Controls.Add(this.txtGio_End);
            this.Page1.Controls.Add(this.rsLabel7);
            this.Page1.Controls.Add(this.lblXuong1);
            this.Page1.Controls.Add(this.lbtTen_CbNv_Can);
            this.Page1.Controls.Add(this.lbtTen_CbNv_KCS);
            this.Page1.Controls.Add(this.rsLabelName1);
            this.Page1.Controls.Add(this.lbtTen_CbNv_TC);
            this.Page1.Controls.Add(this.lblNVCan);
            this.Page1.Controls.Add(this.txtMa_Dt_CbNv_Can);
            this.Page1.Controls.Add(this.rsLabel5);
            this.Page1.Controls.Add(this.txtMa_Dt_CbNv_KCS);
            this.Page1.Controls.Add(this.lblTC);
            this.Page1.Controls.Add(this.txtGio_Begin);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.txtMa_Dt_CbNv_TC);
            this.Page1.Controls.Add(this.rsLabel3);
            this.Page1.Controls.Add(this.dteNgay_Sx);
            this.Page1.Controls.Add(this.rsLabel9);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.cboCa);
            this.Page1.Size = new System.Drawing.Size(559, 236);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(559, 236);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 283);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 292);
            this.lblLog.Text = "";
            // 
            // cboCa
            // 
            this.cboCa.FormattingEnabled = true;
            this.cboCa.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cboCa.Location = new System.Drawing.Point(116, 74);
            this.cboCa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboCa.Name = "cboCa";
            this.cboCa.Size = new System.Drawing.Size(66, 21);
            this.cboCa.TabIndex = 2;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(19, 77);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(20, 13);
            this.rsLabel2.TabIndex = 24;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Ca";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Sx
            // 
            this.dteNgay_Sx.bAllowEmpty = false;
            this.dteNgay_Sx.bSelectOnFocus = false;
            this.dteNgay_Sx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Sx.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Sx.Location = new System.Drawing.Point(116, 52);
            this.dteNgay_Sx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Sx.Mask = "00/00/0000";
            this.dteNgay_Sx.Name = "dteNgay_Sx";
            this.dteNgay_Sx.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Sx.TabIndex = 1;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(19, 55);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(75, 13);
            this.rsLabel3.TabIndex = 26;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Ngày sản xuất";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv_TC
            // 
            this.txtMa_Dt_CbNv_TC.AutoDropDown = null;
            this.txtMa_Dt_CbNv_TC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv_TC.Location = new System.Drawing.Point(116, 141);
            this.txtMa_Dt_CbNv_TC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv_TC.Name = "txtMa_Dt_CbNv_TC";
            this.txtMa_Dt_CbNv_TC.Size = new System.Drawing.Size(143, 20);
            this.txtMa_Dt_CbNv_TC.TabIndex = 7;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(19, 121);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(63, 13);
            this.rsLabel1.TabIndex = 28;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Giờ bắt đầu";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGio_Begin
            // 
            this.txtGio_Begin.FormattingEnabled = true;
            this.txtGio_Begin.Items.AddRange(new object[] {
            "07:30",
            "19:30"});
            this.txtGio_Begin.Location = new System.Drawing.Point(116, 118);
            this.txtGio_Begin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGio_Begin.Name = "txtGio_Begin";
            this.txtGio_Begin.Size = new System.Drawing.Size(66, 21);
            this.txtGio_Begin.TabIndex = 5;
            // 
            // lblTC
            // 
            this.lblTC.AutoEllipsis = true;
            this.lblTC.AutoSize = true;
            this.lblTC.Location = new System.Drawing.Point(19, 144);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(56, 13);
            this.lblTC.TabIndex = 30;
            this.lblTC.Tag = "";
            this.lblTC.Text = "Trưởng ca";
            this.lblTC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(19, 166);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(80, 13);
            this.rsLabel5.TabIndex = 32;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Nhân viên KCS";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv_KCS
            // 
            this.txtMa_Dt_CbNv_KCS.AutoDropDown = null;
            this.txtMa_Dt_CbNv_KCS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv_KCS.Location = new System.Drawing.Point(116, 163);
            this.txtMa_Dt_CbNv_KCS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv_KCS.Name = "txtMa_Dt_CbNv_KCS";
            this.txtMa_Dt_CbNv_KCS.Size = new System.Drawing.Size(143, 20);
            this.txtMa_Dt_CbNv_KCS.TabIndex = 8;
            // 
            // lblNVCan
            // 
            this.lblNVCan.AutoEllipsis = true;
            this.lblNVCan.AutoSize = true;
            this.lblNVCan.Location = new System.Drawing.Point(19, 188);
            this.lblNVCan.Name = "lblNVCan";
            this.lblNVCan.Size = new System.Drawing.Size(77, 13);
            this.lblNVCan.TabIndex = 34;
            this.lblNVCan.Tag = "";
            this.lblNVCan.Text = "Nhân viên cân";
            this.lblNVCan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv_Can
            // 
            this.txtMa_Dt_CbNv_Can.AutoDropDown = null;
            this.txtMa_Dt_CbNv_Can.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv_Can.Location = new System.Drawing.Point(116, 185);
            this.txtMa_Dt_CbNv_Can.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv_Can.Name = "txtMa_Dt_CbNv_Can";
            this.txtMa_Dt_CbNv_Can.Size = new System.Drawing.Size(143, 20);
            this.txtMa_Dt_CbNv_Can.TabIndex = 9;
            // 
            // lbtTen_CbNv_TC
            // 
            this.lbtTen_CbNv_TC.AutoSize = true;
            this.lbtTen_CbNv_TC.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_CbNv_TC.Location = new System.Drawing.Point(264, 144);
            this.lbtTen_CbNv_TC.Name = "lbtTen_CbNv_TC";
            this.lbtTen_CbNv_TC.Size = new System.Drawing.Size(74, 13);
            this.lbtTen_CbNv_TC.TabIndex = 35;
            this.lbtTen_CbNv_TC.Text = "Tên trưởng ca";
            this.lbtTen_CbNv_TC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_CbNv_KCS
            // 
            this.lbtTen_CbNv_KCS.AutoSize = true;
            this.lbtTen_CbNv_KCS.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_CbNv_KCS.Location = new System.Drawing.Point(264, 166);
            this.lbtTen_CbNv_KCS.Name = "lbtTen_CbNv_KCS";
            this.lbtTen_CbNv_KCS.Size = new System.Drawing.Size(100, 13);
            this.lbtTen_CbNv_KCS.TabIndex = 36;
            this.lbtTen_CbNv_KCS.Text = "Tên nhân viên KCS";
            this.lbtTen_CbNv_KCS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_CbNv_Can
            // 
            this.lbtTen_CbNv_Can.AutoSize = true;
            this.lbtTen_CbNv_Can.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_CbNv_Can.Location = new System.Drawing.Point(264, 188);
            this.lbtTen_CbNv_Can.Name = "lbtTen_CbNv_Can";
            this.lbtTen_CbNv_Can.Size = new System.Drawing.Size(97, 13);
            this.lbtTen_CbNv_Can.TabIndex = 37;
            this.lbtTen_CbNv_Can.Text = "Tên nhân viên cân";
            this.lbtTen_CbNv_Can.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(19, 33);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(37, 13);
            this.rsLabel7.TabIndex = 39;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Mã ca";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGio_End
            // 
            this.txtGio_End.FormattingEnabled = true;
            this.txtGio_End.Items.AddRange(new object[] {
            "19:30",
            "07:30"});
            this.txtGio_End.Location = new System.Drawing.Point(186, 118);
            this.txtGio_End.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGio_End.Name = "txtGio_End";
            this.txtGio_End.Size = new System.Drawing.Size(73, 21);
            this.txtGio_End.TabIndex = 6;
            // 
            // txtMa_Ca
            // 
            this.txtMa_Ca.AutoDropDown = null;
            this.txtMa_Ca.Location = new System.Drawing.Point(116, 30);
            this.txtMa_Ca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ca.Name = "txtMa_Ca";
            this.txtMa_Ca.Size = new System.Drawing.Size(143, 20);
            this.txtMa_Ca.TabIndex = 0;
            // 
            // numSo_Ca
            // 
            this.numSo_Ca.AutoDropDown = null;
            this.numSo_Ca.bFormat = true;
            this.numSo_Ca.Enabled = false;
            this.numSo_Ca.Location = new System.Drawing.Point(226, 74);
            this.numSo_Ca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Ca.Name = "numSo_Ca";
            this.numSo_Ca.Scale = 0;
            this.numSo_Ca.Size = new System.Drawing.Size(33, 20);
            this.numSo_Ca.TabIndex = 3;
            this.numSo_Ca.Text = "0";
            this.numSo_Ca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Ca.Value = 0D;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(186, 77);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(35, 13);
            this.rsLabel8.TabIndex = 41;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Số ca";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(19, 99);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(24, 13);
            this.rsLabel9.TabIndex = 24;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Kíp";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKip
            // 
            this.txtKip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKip.AutoDropDown = null;
            this.txtKip.InputMask = "1,2";
            this.txtKip.Location = new System.Drawing.Point(116, 97);
            this.txtKip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtKip.Name = "txtKip";
            this.txtKip.Size = new System.Drawing.Size(29, 20);
            this.txtKip.TabIndex = 4;
            // 
            // rsLabelName1
            // 
            this.rsLabelName1.AutoSize = true;
            this.rsLabelName1.ForeColor = System.Drawing.Color.Blue;
            this.rsLabelName1.Location = new System.Drawing.Point(150, 100);
            this.rsLabelName1.Name = "rsLabelName1";
            this.rsLabelName1.Size = new System.Drawing.Size(78, 13);
            this.rsLabelName1.TabIndex = 35;
            this.rsLabelName1.Text = "1-Ngày, 2 Đêm";
            this.rsLabelName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtXuong
            // 
            this.txtXuong.AutoDropDown = null;
            this.txtXuong.bFormat = true;
            this.txtXuong.Location = new System.Drawing.Point(116, 207);
            this.txtXuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtXuong.Name = "txtXuong";
            this.txtXuong.Scale = 0;
            this.txtXuong.Size = new System.Drawing.Size(33, 20);
            this.txtXuong.TabIndex = 3;
            this.txtXuong.Text = "0";
            this.txtXuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtXuong.Value = 0D;
            // 
            // lblXuong
            // 
            this.lblXuong.AutoEllipsis = true;
            this.lblXuong.AutoSize = true;
            this.lblXuong.Location = new System.Drawing.Point(19, 210);
            this.lblXuong.Name = "lblXuong";
            this.lblXuong.Size = new System.Drawing.Size(81, 13);
            this.lblXuong.TabIndex = 41;
            this.lblXuong.Tag = "";
            this.lblXuong.Text = "Xưởng sản xuất";
            this.lblXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblXuong1
            // 
            this.lblXuong1.AutoSize = true;
            this.lblXuong1.ForeColor = System.Drawing.Color.Blue;
            this.lblXuong1.Location = new System.Drawing.Point(154, 211);
            this.lblXuong1.Name = "lblXuong1";
            this.lblXuong1.Size = new System.Drawing.Size(286, 13);
            this.lblXuong1.TabIndex = 37;
            this.lblXuong1.Text = "Nếu sản xuất tại xưởng hiện tại thì số 0, xưởng thứ 2 là số 1";
            this.lblXuong1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmCa_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 324);
            this.Name = "frmDmCa_Edit";
            this.Object_ID = "DMCA";
            this.Tag = "frmDmCa, ESC";
            this.Text = "frmDmCa";
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

		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsComboBox cboCa;
		private RosySystem.Control.rsComboBox txtGio_Begin;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv_TC;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsDateTime dteNgay_Sx;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsLabelName lbtTen_CbNv_KCS;
		private RosySystem.Control.rsLabelName lbtTen_CbNv_TC;
		private RosySystem.Control.rsLabel lblNVCan;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv_Can;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv_KCS;
		private RosySystem.Control.rsLabel lblTC;
		private RosySystem.Control.rsComboBox txtGio_End;
		private RosySystem.Control.rsTextBox txtMa_Ca;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsTextBoxNumber numSo_Ca;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsTextBoxEnum txtKip;
        private RosySystem.Control.rsLabelName rsLabelName1;
        private RosySystem.Control.rsLabelName lbtTen_CbNv_Can;
        private RosySystem.Control.rsLabel lblXuong;
        private RosySystem.Control.rsTextBoxNumber txtXuong;
        private RosySystem.Control.rsLabelName lblXuong1;
    }
}