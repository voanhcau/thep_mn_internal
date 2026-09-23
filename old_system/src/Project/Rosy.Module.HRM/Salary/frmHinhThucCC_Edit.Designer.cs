namespace RosyModule.Salary
{
    partial class frmHinhThucCC_Edit
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
            this.lblTk = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp_Ct = new System.Windows.Forms.Label();
            this.txtMa_Bp_Ct = new RosySystem.Control.rsTextBox();
            this.lbtTen_Muc_BDDH = new System.Windows.Forms.Label();
            this.txtMuc_BDDH = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.lbtGhi_Chu = new System.Windows.Forms.Label();
            this.txtHT_CC = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt_CbNv = new System.Windows.Forms.Label();
            this.cboLoai_CC = new RosySystem.Control.rsMultiComboBox();
            this.SuspendLayout();
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(138, 58);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Ap.TabIndex = 2;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(25, 60);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(47, 13);
            this.lblDien_Giai.TabIndex = 73;
            this.lblDien_Giai.Tag = "Ngay_Ap";
            this.lblDien_Giai.Text = "Ngày áp";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Location = new System.Drawing.Point(25, 36);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(109, 13);
            this.lblTk.TabIndex = 70;
            this.lblTk.Tag = "";
            this.lblTk.Text = "Hình thức chấm công";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(196, 143);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 43);
            this.btgAccept.TabIndex = 6;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(25, 82);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(98, 13);
            this.rsLabel1.TabIndex = 70;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mã bộ phận chi tiết";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp_Ct
            // 
            this.lbtTen_Bp_Ct.AutoSize = true;
            this.lbtTen_Bp_Ct.Location = new System.Drawing.Point(243, 84);
            this.lbtTen_Bp_Ct.Name = "lbtTen_Bp_Ct";
            this.lbtTen_Bp_Ct.Size = new System.Drawing.Size(45, 13);
            this.lbtTen_Bp_Ct.TabIndex = 74;
            this.lbtTen_Bp_Ct.Text = "Ten_Bp";
            // 
            // txtMa_Bp_Ct
            // 
            this.txtMa_Bp_Ct.AutoDropDown = null;
            this.txtMa_Bp_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp_Ct.Location = new System.Drawing.Point(138, 80);
            this.txtMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp_Ct.MaxLength = 20;
            this.txtMa_Bp_Ct.Name = "txtMa_Bp_Ct";
            this.txtMa_Bp_Ct.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Bp_Ct.TabIndex = 3;
            // 
            // lbtTen_Muc_BDDH
            // 
            this.lbtTen_Muc_BDDH.AutoSize = true;
            this.lbtTen_Muc_BDDH.Location = new System.Drawing.Point(243, 103);
            this.lbtTen_Muc_BDDH.Name = "lbtTen_Muc_BDDH";
            this.lbtTen_Muc_BDDH.Size = new System.Drawing.Size(45, 13);
            this.lbtTen_Muc_BDDH.TabIndex = 77;
            this.lbtTen_Muc_BDDH.Text = "Ten_Bp";
            // 
            // txtMuc_BDDH
            // 
            this.txtMuc_BDDH.AutoDropDown = null;
            this.txtMuc_BDDH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMuc_BDDH.Location = new System.Drawing.Point(138, 100);
            this.txtMuc_BDDH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMuc_BDDH.MaxLength = 20;
            this.txtMuc_BDDH.Name = "txtMuc_BDDH";
            this.txtMuc_BDDH.Size = new System.Drawing.Size(96, 20);
            this.txtMuc_BDDH.TabIndex = 4;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(25, 102);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(62, 13);
            this.rsLabel2.TabIndex = 76;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Mức BDDH";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtGhi_Chu
            // 
            this.lbtGhi_Chu.AutoSize = true;
            this.lbtGhi_Chu.Location = new System.Drawing.Point(243, 123);
            this.lbtGhi_Chu.Name = "lbtGhi_Chu";
            this.lbtGhi_Chu.Size = new System.Drawing.Size(45, 13);
            this.lbtGhi_Chu.TabIndex = 80;
            this.lbtGhi_Chu.Text = "Ten_Bp";
            // 
            // txtHT_CC
            // 
            this.txtHT_CC.AutoDropDown = null;
            this.txtHT_CC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHT_CC.Location = new System.Drawing.Point(138, 120);
            this.txtHT_CC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtHT_CC.MaxLength = 20;
            this.txtHT_CC.Name = "txtHT_CC";
            this.txtHT_CC.Size = new System.Drawing.Size(96, 20);
            this.txtHT_CC.TabIndex = 5;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(25, 123);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(100, 13);
            this.rsLabel3.TabIndex = 79;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Ghi chú chấm công";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(25, 14);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(72, 13);
            this.rsLabel4.TabIndex = 70;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Mã nhân viên";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(138, 11);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.MaxLength = 20;
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(243, 15);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(76, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 74;
            this.lbtTen_Dt_CbNv.Text = "Ten_Dt_CbNv";
            // 
            // cboLoai_CC
            // 
            this.cboLoai_CC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLoai_CC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboLoai_CC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLoai_CC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoai_CC.Location = new System.Drawing.Point(138, 33);
            this.cboLoai_CC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboLoai_CC.MaxLength = 20;
            this.cboLoai_CC.Name = "cboLoai_CC";
            this.cboLoai_CC.Size = new System.Drawing.Size(96, 21);
            this.cboLoai_CC.TabIndex = 1;
            // 
            // frmHinhThucCC_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 193);
            this.Controls.Add(this.cboLoai_CC);
            this.Controls.Add(this.lbtGhi_Chu);
            this.Controls.Add(this.txtHT_CC);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.lbtTen_Muc_BDDH);
            this.Controls.Add(this.txtMuc_BDDH);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.lbtTen_Bp_Ct);
            this.Controls.Add(this.dteNgay_Ap);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.txtMa_Bp_Ct);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmHinhThucCC_Edit";
            this.Text = "frmHinhThucCC_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsLabel lblTk;
        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel1;
		private System.Windows.Forms.Label lbtTen_Bp_Ct;
        private RosySystem.Control.rsTextBox txtMa_Bp_Ct;
        private System.Windows.Forms.Label lbtTen_Muc_BDDH;
        private RosySystem.Control.rsTextBox txtMuc_BDDH;
        private RosySystem.Control.rsLabel rsLabel2;
        private System.Windows.Forms.Label lbtGhi_Chu;
        private RosySystem.Control.rsTextBox txtHT_CC;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private System.Windows.Forms.Label lbtTen_Dt_CbNv;
        private RosySystem.Control.rsMultiComboBox cboLoai_CC;
	}
}