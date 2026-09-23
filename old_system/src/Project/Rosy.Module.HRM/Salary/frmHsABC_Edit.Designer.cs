namespace RosyModule.Salary
{
    partial class frmHsABC_Edit
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
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabelName();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.numHe_So = new RosySystem.Control.rsTextBoxNumber();
            this.txtHs_ABC = new RosySystem.Control.rsTextBox();
            this.SuspendLayout();
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(127, 31);
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
            this.lblDien_Giai.Location = new System.Drawing.Point(25, 33);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(47, 13);
            this.lblDien_Giai.TabIndex = 73;
            this.lblDien_Giai.Tag = "Ngay_Ap";
            this.lblDien_Giai.Text = "Ngày áp";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(127, 9);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.MaxLength = 20;
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Location = new System.Drawing.Point(25, 11);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(72, 13);
            this.lblTk.TabIndex = 70;
            this.lblTk.Tag = "Ma_Dt_CbNv";
            this.lblTk.Text = "Mã nhân viên";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(381, 139);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            this.btgAccept.TabIndex = 5;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(228, 9);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 1;
            this.lbtTen_Dt_CbNv.Tag = "";
            this.lbtTen_Dt_CbNv.Text = "txtTen_Tn";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(25, 63);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(85, 13);
            this.rsLabel1.TabIndex = 70;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Hệ số tại BP/PX";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(127, 85);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.MaxLength = 200;
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(441, 53);
            this.txtGhi_Chu.TabIndex = 4;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(25, 83);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(33, 13);
            this.rsLabel9.TabIndex = 81;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Lý do";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numHe_So
            // 
            this.numHe_So.AutoDropDown = null;
            this.numHe_So.bFormat = true;
            this.numHe_So.Location = new System.Drawing.Point(185, 60);
            this.numHe_So.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numHe_So.Name = "numHe_So";
            this.numHe_So.ReadOnly = true;
            this.numHe_So.Scale = 2;
            this.numHe_So.Size = new System.Drawing.Size(35, 20);
            this.numHe_So.TabIndex = 3;
            this.numHe_So.Tag = "";
            this.numHe_So.Text = "1.00";
            this.numHe_So.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHe_So.Value = 1D;
            // 
            // txtHs_ABC
            // 
            this.txtHs_ABC.AutoDropDown = null;
            this.txtHs_ABC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHs_ABC.Location = new System.Drawing.Point(127, 60);
            this.txtHs_ABC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtHs_ABC.MaxLength = 20;
            this.txtHs_ABC.Name = "txtHs_ABC";
            this.txtHs_ABC.Size = new System.Drawing.Size(53, 20);
            this.txtHs_ABC.TabIndex = 2;
            // 
            // frmHsABC_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 188);
            this.Controls.Add(this.txtHs_ABC);
            this.Controls.Add(this.numHe_So);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.dteNgay_Ap);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmHsABC_Edit";
            this.Text = "frmHsABC_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_Ap;
		private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabelName lbtTen_Dt_CbNv;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel rsLabel9;
        public RosySystem.Control.rsTextBoxNumber numHe_So;
        private RosySystem.Control.rsTextBox txtHs_ABC;
	}
}