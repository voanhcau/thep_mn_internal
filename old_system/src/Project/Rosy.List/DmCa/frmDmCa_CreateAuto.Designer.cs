namespace RosyList
{
    partial class frmDmCa_CreateAuto
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
            this.btExec = new System.Windows.Forms.Button();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.cboCa = new RosySystem.Control.rsComboBox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(12, 121);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 25;
            this.btgAccept.Visible = false;
            // 
            // btExec
            // 
            this.btExec.Location = new System.Drawing.Point(315, 121);
            this.btExec.Name = "btExec";
            this.btExec.Size = new System.Drawing.Size(105, 45);
            this.btExec.TabIndex = 26;
            this.btExec.Text = "Thực hiện";
            this.btExec.UseVisualStyleBackColor = true;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(10, 11);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(46, 13);
            this.rsLabel3.TabIndex = 28;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Từ ngày";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(159, 8);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct1.TabIndex = 27;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(303, 8);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 27;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(245, 11);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(53, 13);
            this.rsLabel1.TabIndex = 28;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Đến ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(10, 40);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(147, 13);
            this.rsLabel7.TabIndex = 41;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Ca bắt đầu của ngày bắt đầu";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.ForeColor = System.Drawing.Color.Red;
            this.rsLabel2.Location = new System.Drawing.Point(12, 69);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(181, 13);
            this.rsLabel2.TabIndex = 42;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Lưu ý ca bắt đầu luôn ở kíp 1.";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCa
            // 
            this.cboCa.FormattingEnabled = true;
            this.cboCa.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cboCa.Location = new System.Drawing.Point(159, 32);
            this.cboCa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboCa.Name = "cboCa";
            this.cboCa.Size = new System.Drawing.Size(66, 21);
            this.cboCa.TabIndex = 43;
            // 
            // frmDmCa_CreateAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 178);
            this.Controls.Add(this.cboCa);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.dteNgay_Ct2);
            this.Controls.Add(this.dteNgay_Ct1);
            this.Controls.Add(this.btExec);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmDmCa_CreateAuto";
            this.Text = "frmCreateCaAuto";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.Button btExec;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsComboBox cboCa;
        public RosySystem.Control.rsDateTime dteNgay_Ct1;
        public RosySystem.Control.rsDateTime dteNgay_Ct2;
	}
}