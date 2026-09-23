namespace RosyList
{
    partial class frmDmKhoKG_Edit
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
            this.txtMa_Kho = new RosySystem.Control.rsTextBox();
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.numHan_HD = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtPt_Vc = new RosySystem.Control.rsTextBoxEnum();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(459, 195);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(690, 179);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtPt_Vc);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.numHan_HD);
            this.Page1.Controls.Add(this.rsLabel7);
            this.Page1.Controls.Add(this.dteNgay_Ap);
            this.Page1.Controls.Add(this.lblDien_Giai);
            this.Page1.Controls.Add(this.txtMa_Kho);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Size = new System.Drawing.Size(682, 153);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(682, 153);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 206);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(45, 215);
            this.lblLog.Text = "";
            // 
            // txtMa_Kho
            // 
            this.txtMa_Kho.AutoDropDown = null;
            this.txtMa_Kho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Kho.Location = new System.Drawing.Point(135, 22);
            this.txtMa_Kho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho.MaxLength = 20;
            this.txtMa_Kho.Name = "txtMa_Kho";
            this.txtMa_Kho.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Kho.TabIndex = 0;
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(6, 22);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(43, 13);
            this.lbMa_Kho.TabIndex = 20;
            this.lbMa_Kho.Tag = "Ma_Kho";
            this.lbMa_Kho.Text = "Mã kho";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(135, 46);
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
            this.lblDien_Giai.Location = new System.Drawing.Point(6, 49);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(47, 13);
            this.lblDien_Giai.TabIndex = 119;
            this.lblDien_Giai.Tag = "Ngay_Ap";
            this.lblDien_Giai.Text = "Ngày áp";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numHan_HD
            // 
            this.numHan_HD.AutoDropDown = null;
            this.numHan_HD.bFormat = true;
            this.numHan_HD.Location = new System.Drawing.Point(135, 94);
            this.numHan_HD.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numHan_HD.Name = "numHan_HD";
            this.numHan_HD.Scale = 0;
            this.numHan_HD.Size = new System.Drawing.Size(120, 20);
            this.numHan_HD.TabIndex = 4;
            this.numHan_HD.Tag = "";
            this.numHan_HD.Text = "0";
            this.numHan_HD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHan_HD.Value = 0D;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(8, 97);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(88, 13);
            this.rsLabel7.TabIndex = 121;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Số ngày xuất HD";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(8, 74);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(85, 13);
            this.rsLabel1.TabIndex = 121;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Phương thức VC";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel2.Location = new System.Drawing.Point(220, 74);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(61, 13);
            this.rsLabel2.TabIndex = 122;
            this.rsLabel2.Text = "XE/XALAN";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPt_Vc
            // 
            this.txtPt_Vc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPt_Vc.AutoDropDown = null;
            this.txtPt_Vc.InputMask = "XE,XALAN";
            this.txtPt_Vc.Location = new System.Drawing.Point(134, 71);
            this.txtPt_Vc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPt_Vc.Name = "txtPt_Vc";
            this.txtPt_Vc.Size = new System.Drawing.Size(70, 20);
            this.txtPt_Vc.TabIndex = 3;
            this.txtPt_Vc.Text = "XE";
            // 
            // frmDmKhoKG_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(702, 256);
            this.Name = "frmDmKhoKG_Edit";
            this.Object_ID = "DMKHOKG";
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

        private RosySystem.Control.rsTextBox txtMa_Kho;
		private RosySystem.Control.rsLabel lbMa_Kho;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsLabel lblDien_Giai;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBoxNumber numHan_HD;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxEnum txtPt_Vc;
    }
}