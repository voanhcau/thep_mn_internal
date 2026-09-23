namespace RosyList
{
    partial class frmDmCaSX_Edit
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
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtGio_Begin = new RosySystem.Control.rsComboBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtGio_End = new RosySystem.Control.rsComboBox();
            this.txtMa_Ca = new RosySystem.Control.rsTextBox();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.txtKip = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabelName1 = new RosySystem.Control.rsLabelName();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(397, 253);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(567, 240);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtKip);
            this.Page1.Controls.Add(this.txtMa_Ca);
            this.Page1.Controls.Add(this.txtGio_End);
            this.Page1.Controls.Add(this.rsLabel7);
            this.Page1.Controls.Add(this.rsLabelName1);
            this.Page1.Controls.Add(this.txtGio_Begin);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.rsLabel3);
            this.Page1.Controls.Add(this.dteNgay_Sx);
            this.Page1.Controls.Add(this.rsLabel9);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.cboCa);
            this.Page1.Size = new System.Drawing.Size(559, 214);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(559, 214);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 261);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 270);
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
            // frmDmCaSX_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 302);
            this.Name = "frmDmCaSX_Edit";
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
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsDateTime dteNgay_Sx;
        private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsComboBox txtGio_End;
        private RosySystem.Control.rsTextBox txtMa_Ca;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsTextBoxEnum txtKip;
        private RosySystem.Control.rsLabelName rsLabelName1;

	}
}