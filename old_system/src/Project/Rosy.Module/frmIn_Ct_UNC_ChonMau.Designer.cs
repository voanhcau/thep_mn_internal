namespace RosyModule
{
	partial class frmIn_Ct_UNC_ChonMau
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbUSD = new RosySystem.Control.rsRadioButton();
            this.rdbVND = new RosySystem.Control.rsRadioButton();
            this.txtReportTag = new RosySystem.Control.rsTextBoxEnum();
            this.groupBox1.SuspendLayout();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(131, 231);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            this.btgAccept.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReportTag);
            this.groupBox1.Controls.Add(this.rsLabel1);
            this.groupBox1.Controls.Add(this.rsLabel9);
            this.groupBox1.Controls.Add(this.rsLabel10);
            this.groupBox1.Controls.Add(this.rsLabel8);
            this.groupBox1.Controls.Add(this.rsLabel7);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Chọn mẫu in";
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel1.Location = new System.Drawing.Point(6, 127);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(246, 13);
            this.rsLabel1.TabIndex = 18;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "AGR - Ngân hàng NN và PT Nông Thôn Việt Nam";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel9.Location = new System.Drawing.Point(6, 105);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(295, 13);
            this.rsLabel9.TabIndex = 16;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "VTB-Ngân hàng TMCP Công Thương Việt Nam Thịnh Vượng";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel10.Location = new System.Drawing.Point(6, 83);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(194, 13);
            this.rsLabel10.TabIndex = 15;
            this.rsLabel10.Tag = "";
            this.rsLabel10.Text = "VPB-Ngân hàng Việt Nam Thịnh Vượng";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel8.Location = new System.Drawing.Point(83, 42);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(131, 26);
            this.rsLabel8.TabIndex = 14;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "BIDV - Ngân hàng đầu tư \r\nvà phát triển";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel7.Location = new System.Drawing.Point(83, 22);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(110, 13);
            this.rsLabel7.TabIndex = 13;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "UNC - In ủy nhiệm chi";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.rdbUSD);
            this.gbIn_Tien.Controls.Add(this.rdbVND);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 167);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(227, 43);
            this.gbIn_Tien.TabIndex = 2;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "In_Tien";
            this.gbIn_Tien.Text = "Chọn loại tiền in";
            // 
            // rdbUSD
            // 
            this.rdbUSD.AutoSize = true;
            this.rdbUSD.Location = new System.Drawing.Point(145, 19);
            this.rdbUSD.Name = "rdbUSD";
            this.rdbUSD.Size = new System.Drawing.Size(48, 17);
            this.rdbUSD.TabIndex = 0;
            this.rdbUSD.Tag = "";
            this.rdbUSD.Text = "USD";
            this.rdbUSD.UnChecked = true;
            this.rdbUSD.UseVisualStyleBackColor = true;
            // 
            // rdbVND
            // 
            this.rdbVND.AutoSize = true;
            this.rdbVND.Checked = true;
            this.rdbVND.Location = new System.Drawing.Point(52, 20);
            this.rdbVND.Name = "rdbVND";
            this.rdbVND.Size = new System.Drawing.Size(48, 17);
            this.rdbVND.TabIndex = 0;
            this.rdbVND.TabStop = true;
            this.rdbVND.Tag = "";
            this.rdbVND.Text = "VND";
            this.rdbVND.UnChecked = false;
            this.rdbVND.UseVisualStyleBackColor = true;
            // 
            // txtReportTag
            // 
            this.txtReportTag.AutoDropDown = null;
            this.txtReportTag.InputMask = "UNC,BIDV,VPB,VTB,VCB,AGR";
            this.txtReportTag.Location = new System.Drawing.Point(9, 22);
            this.txtReportTag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtReportTag.Name = "txtReportTag";
            this.txtReportTag.Size = new System.Drawing.Size(59, 20);
            this.txtReportTag.TabIndex = 19;
            this.txtReportTag.Text = "UNC";
            // 
            // frmIn_Ct_UNC_ChonMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 278);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_UNC_ChonMau";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		public System.Windows.Forms.GroupBox groupBox1;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsLabel rsLabel9;
		private RosySystem.Control.rsLabel rsLabel10;
		public System.Windows.Forms.GroupBox gbIn_Tien;
		public RosySystem.Control.rsRadioButton rdbUSD;
        public RosySystem.Control.rsRadioButton rdbVND;
		private RosySystem.Control.rsLabel rsLabel1;
        public RosySystem.Control.rsTextBoxEnum txtReportTag;
	}
}