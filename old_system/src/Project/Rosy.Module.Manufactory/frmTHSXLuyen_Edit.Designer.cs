namespace RosyModule.Manufactory
{
    partial class frmTHSXLuyen_Edit
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
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtNoi_Dung = new RosySystem.Control.rsTextBox();
            this.dteNgay_Cham_Cong = new RosySystem.Control.rsDateTime();
            this.rsTextBoxNumber2 = new RosySystem.Control.rsTextBoxNumber();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(400, 132);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(184, 47);
            this.btgAccept.TabIndex = 4;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(6, 22);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(50, 13);
            this.rsLabel2.TabIndex = 22;
            this.rsLabel2.Text = "Nội dung";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoi_Dung
            // 
            this.txtNoi_Dung.AutoDropDown = null;
            this.txtNoi_Dung.Location = new System.Drawing.Point(62, 9);
            this.txtNoi_Dung.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtNoi_Dung.Multiline = true;
            this.txtNoi_Dung.Name = "txtNoi_Dung";
            this.txtNoi_Dung.Size = new System.Drawing.Size(522, 60);
            this.txtNoi_Dung.TabIndex = 3;
            this.txtNoi_Dung.Tag = "";
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
            // frmTBCNLuyen_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 188);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtNoi_Dung);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmTBCNLuyen_Edit";
            this.Tag = "frmSuCoLuyen_Edit, ESC";
            this.Text = "frmSuCoLuyen_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtNoi_Dung;
        private RosySystem.Control.rsDateTime dteNgay_Cham_Cong;
        private RosySystem.Control.rsTextBoxNumber rsTextBoxNumber2;
	}
}