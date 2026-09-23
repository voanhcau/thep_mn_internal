namespace RosyModule.HRM
{
    partial class frmDinhMucMonAn_Edit
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
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.lblTen_Bp = new RosySystem.Control.rsLabel();
            this.lblMa_MAn = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabel();
            this.numDinh_Muc = new RosySystem.Control.rsTextBoxNumber();
            this.lbtDvt = new RosySystem.Control.rsLabel();
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(378, 240);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabEdit.Size = new System.Drawing.Size(547, 227);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.dteNgay_Ap);
            this.Page1.Controls.Add(this.rsLabel6);
            this.Page1.Controls.Add(this.numDinh_Muc);
            this.Page1.Controls.Add(this.txtMa_Vt);
            this.Page1.Controls.Add(this.lbtDvt);
            this.Page1.Controls.Add(this.lbtTen_Vt);
            this.Page1.Controls.Add(this.lblTen_Bp);
            this.Page1.Controls.Add(this.lblMa_MAn);
            this.Page1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Page1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Page1.Size = new System.Drawing.Size(539, 201);
            // 
            // Page2
            // 
            this.Page2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Page2.Size = new System.Drawing.Size(539, 201);
            // 
            // dteNgay_End
            // 
            this.dteNgay_End.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // dteNgay_Begin
            // 
            this.dteNgay_Begin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 272);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 281);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Size = new System.Drawing.Size(519, 34);
            this.lblLog.Text = "";
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(116, 26);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(137, 20);
            this.txtMa_Vt.TabIndex = 0;
            // 
            // lblTen_Bp
            // 
            this.lblTen_Bp.AutoEllipsis = true;
            this.lblTen_Bp.AutoSize = true;
            this.lblTen_Bp.Location = new System.Drawing.Point(28, 52);
            this.lblTen_Bp.Name = "lblTen_Bp";
            this.lblTen_Bp.Size = new System.Drawing.Size(68, 13);
            this.lblTen_Bp.TabIndex = 59;
            this.lblTen_Bp.Tag = "Dinh_Muc";
            this.lblTen_Bp.Text = "Tên bộ phận";
            this.lblTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_MAn
            // 
            this.lblMa_MAn.AutoEllipsis = true;
            this.lblMa_MAn.AutoSize = true;
            this.lblMa_MAn.Location = new System.Drawing.Point(28, 26);
            this.lblMa_MAn.Name = "lblMa_MAn";
            this.lblMa_MAn.Size = new System.Drawing.Size(64, 13);
            this.lblMa_MAn.TabIndex = 60;
            this.lblMa_MAn.Tag = "Ma_Vt";
            this.lblMa_MAn.Text = "Mã bộ phận";
            this.lblMa_MAn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(257, 28);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Vt.TabIndex = 61;
            this.lbtTen_Vt.Text = "Tên vật tư";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numDinh_Muc
            // 
            this.numDinh_Muc.AutoDropDown = null;
            this.numDinh_Muc.bFormat = true;
            this.numDinh_Muc.Location = new System.Drawing.Point(116, 48);
            this.numDinh_Muc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numDinh_Muc.Name = "numDinh_Muc";
            this.numDinh_Muc.Scale = 4;
            this.numDinh_Muc.Size = new System.Drawing.Size(127, 20);
            this.numDinh_Muc.TabIndex = 62;
            this.numDinh_Muc.Tag = "";
            this.numDinh_Muc.Text = "0.0000";
            this.numDinh_Muc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDinh_Muc.Value = 0D;
            // 
            // lbtDvt
            // 
            this.lbtDvt.AutoEllipsis = true;
            this.lbtDvt.AutoSize = true;
            this.lbtDvt.ForeColor = System.Drawing.Color.Blue;
            this.lbtDvt.Location = new System.Drawing.Point(247, 50);
            this.lbtDvt.Name = "lbtDvt";
            this.lbtDvt.Size = new System.Drawing.Size(56, 13);
            this.lbtDvt.TabIndex = 61;
            this.lbtDvt.Text = "Tên vật tư";
            this.lbtDvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(116, 71);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ap.TabIndex = 65;
            this.dteNgay_Ap.Tag = "Ngay_Ap";
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(28, 74);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(47, 13);
            this.rsLabel6.TabIndex = 66;
            this.rsLabel6.Tag = "Ngay_Ap";
            this.rsLabel6.Text = "Ngày áp";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDinhMucMonAn_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 313);
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.Name = "frmDinhMucMonAn_Edit";
            this.Object_ID = "DMMONAN";
            this.Tag = "frmDinhMucMonAn, ESC";
            this.Text = "frmDinhMucMonAn";
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

        private RosySystem.Control.rsTextBox txtMa_Vt;
		private RosySystem.Control.rsLabel lblTen_Bp;
        private RosySystem.Control.rsLabel lblMa_MAn;
        private RosySystem.Control.rsLabel lbtTen_Vt;
        private RosySystem.Control.rsTextBoxNumber numDinh_Muc;
        private RosySystem.Control.rsLabel lbtDvt;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsLabel rsLabel6;
	}
}