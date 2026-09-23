namespace RosyList
{
    partial class frmDmDotBT_Edit
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
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.lbtNgay_QD = new RosySystem.Control.rsLabel();
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_DotBT = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(708, 193);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btgAccept.Size = new System.Drawing.Size(239, 52);
            // 
            // tabEdit
            // 
            this.tabEdit.Margin = new System.Windows.Forms.Padding(5);
            this.tabEdit.Size = new System.Drawing.Size(934, 177);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtMa_DotBT);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.txtGhi_Chu);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.lbtNgay_QD);
            this.Page1.Controls.Add(this.dteNgay_Ct1);
            this.Page1.Controls.Add(this.dteNgay_Ct2);
            this.Page1.Location = new System.Drawing.Point(4, 25);
            this.Page1.Margin = new System.Windows.Forms.Padding(5);
            this.Page1.Padding = new System.Windows.Forms.Padding(5);
            this.Page1.Size = new System.Drawing.Size(926, 148);
            // 
            // Page2
            // 
            this.Page2.Location = new System.Drawing.Point(4, 25);
            this.Page2.Margin = new System.Windows.Forms.Padding(5);
            this.Page2.Size = new System.Drawing.Size(926, 148);
            // 
            // dteNgay_End
            // 
            this.dteNgay_End.Margin = new System.Windows.Forms.Padding(4, 0, 4, 2);
            // 
            // dteNgay_Begin
            // 
            this.dteNgay_Begin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 2);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 203);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(64, 214);
            this.lblLog.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLog.Size = new System.Drawing.Size(615, 33);
            this.lblLog.Text = "";
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(153, 74);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Ct2.TabIndex = 2;
            // 
            // lbtNgay_QD
            // 
            this.lbtNgay_QD.AutoEllipsis = true;
            this.lbtNgay_QD.AutoSize = true;
            this.lbtNgay_QD.Location = new System.Drawing.Point(11, 78);
            this.lbtNgay_QD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtNgay_QD.Name = "lbtNgay_QD";
            this.lbtNgay_QD.Size = new System.Drawing.Size(62, 17);
            this.lbtNgay_QD.TabIndex = 28;
            this.lbtNgay_QD.Tag = "Ngay_Ct2";
            this.lbtNgay_QD.Text = "Ngày Áp";
            this.lbtNgay_QD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(11, 105);
            this.lbMa_Kho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(57, 17);
            this.lbMa_Kho.TabIndex = 30;
            this.lbMa_Kho.Tag = "Ghi_Chu";
            this.lbMa_Kho.Text = "Ghi chú";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(153, 101);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtGhi_Chu.MaxLength = 200;
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(765, 30);
            this.txtGhi_Chu.TabIndex = 3;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(153, 47);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Ct1.TabIndex = 1;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(11, 51);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(62, 17);
            this.rsLabel1.TabIndex = 28;
            this.rsLabel1.Tag = "Ngay_Ct1";
            this.rsLabel1.Text = "Ngày Áp";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_DotBT
            // 
            this.txtMa_DotBT.AutoDropDown = null;
            this.txtMa_DotBT.Location = new System.Drawing.Point(153, 15);
            this.txtMa_DotBT.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtMa_DotBT.MaxLength = 200;
            this.txtMa_DotBT.Name = "txtMa_DotBT";
            this.txtMa_DotBT.Size = new System.Drawing.Size(118, 22);
            this.txtMa_DotBT.TabIndex = 0;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(11, 19);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(73, 17);
            this.rsLabel2.TabIndex = 32;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Mã đợt BT";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmDotBT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 254);
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "frmDmDotBT_Edit";
            this.Object_ID = "DMDOTBT";
            this.Tag = "frmDmCK, ESC";
            this.Text = " ";
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

        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsLabel lbtNgay_QD;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel lbMa_Kho;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsTextBox txtMa_DotBT;
        private RosySystem.Control.rsLabel rsLabel2;


	}
}