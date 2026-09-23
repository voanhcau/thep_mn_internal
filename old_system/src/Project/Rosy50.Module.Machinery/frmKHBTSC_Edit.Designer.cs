namespace RosyModule.Machinery
{
    partial class frmKHBTSC_Edit
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
			this.numDinh_Ky = new RosySystem.Control.rsNumericUpdown();
			this.lblNgay = new RosySystem.Control.rsLabel();
			this.lbtDaily = new RosySystem.Control.rsLabel();
			this.dteNgay_End = new RosySystem.Control.rsDateTime();
			this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
			this.lbtNgay_Ct1 = new RosySystem.Control.rsLabel();
			this.lbtNgay_Ct2 = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.txtMa_Vt_Tb = new RosySystem.Control.rsTextBox();
			this.lbMa_Vt = new RosySystem.Control.rsLabel();
			this.lbtTen_Vt_Tb = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.txtMa_Dt_Cbnv = new RosySystem.Control.rsTextBox();
			this.lbtTen_Dt_Cbnv = new RosySystem.Control.rsLabel();
			this.lbtTen_Bp = new RosySystem.Control.rsLabel();
			this.txtMa_Bp = new RosySystem.Control.rsTextBox();
			this.lblMa_Bp = new RosySystem.Control.rsLabel();
			this.lblLog = new System.Windows.Forms.Label();
			this.cboNoi_Dung = new RosySystem.Control.rsComboBox();
			this.numThoi_Luong = new RosySystem.Control.rsNumericUpdown();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.rsLabel31 = new RosySystem.Control.rsLabel();
			this.lbtTen_Vt_Tb_Kt = new RosySystem.Control.rsLabel();
			this.txtMa_Vt_Tb_Kt = new RosySystem.Control.rsTextBox();
			((System.ComponentModel.ISupportInitialize)(this.numDinh_Ky)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numThoi_Luong)).BeginInit();
			this.SuspendLayout();
			// 
			// numDinh_Ky
			// 
			this.numDinh_Ky.Location = new System.Drawing.Point(128, 107);
			this.numDinh_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numDinh_Ky.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numDinh_Ky.Name = "numDinh_Ky";
			this.numDinh_Ky.Size = new System.Drawing.Size(38, 20);
			this.numDinh_Ky.TabIndex = 3;
			// 
			// lblNgay
			// 
			this.lblNgay.AutoEllipsis = true;
			this.lblNgay.AutoSize = true;
			this.lblNgay.Location = new System.Drawing.Point(173, 109);
			this.lblNgay.Name = "lblNgay";
			this.lblNgay.Size = new System.Drawing.Size(177, 14);
			this.lblNgay.TabIndex = 180;
			this.lblNgay.Tag = "";
			this.lblNgay.Text = "ngày (bao nhiêu ngày sẽ bảo trì lại)";
			this.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtDaily
			// 
			this.lbtDaily.AutoEllipsis = true;
			this.lbtDaily.AutoSize = true;
			this.lbtDaily.Location = new System.Drawing.Point(32, 112);
			this.lbtDaily.Name = "lbtDaily";
			this.lbtDaily.Size = new System.Drawing.Size(46, 14);
			this.lbtDaily.TabIndex = 179;
			this.lbtDaily.Tag = "";
			this.lbtDaily.Text = "Định kỳ ";
			this.lbtDaily.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_End
			// 
			this.dteNgay_End.bAllowEmpty = true;
			this.dteNgay_End.bSelectOnFocus = false;
			this.dteNgay_End.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_End.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_End.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_End.Location = new System.Drawing.Point(128, 216);
			this.dteNgay_End.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_End.Mask = "00/00/0000";
			this.dteNgay_End.Name = "dteNgay_End";
			this.dteNgay_End.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_End.TabIndex = 8;
			// 
			// dteNgay_Ap
			// 
			this.dteNgay_Ap.bAllowEmpty = true;
			this.dteNgay_Ap.bSelectOnFocus = false;
			this.dteNgay_Ap.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ap.Location = new System.Drawing.Point(128, 194);
			this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ap.Mask = "00/00/0000";
			this.dteNgay_Ap.Name = "dteNgay_Ap";
			this.dteNgay_Ap.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ap.TabIndex = 7;
			// 
			// lbtNgay_Ct1
			// 
			this.lbtNgay_Ct1.AutoEllipsis = true;
			this.lbtNgay_Ct1.AutoSize = true;
			this.lbtNgay_Ct1.Location = new System.Drawing.Point(32, 196);
			this.lbtNgay_Ct1.Name = "lbtNgay_Ct1";
			this.lbtNgay_Ct1.Size = new System.Drawing.Size(88, 14);
			this.lbtNgay_Ct1.TabIndex = 205;
			this.lbtNgay_Ct1.Tag = "";
			this.lbtNgay_Ct1.Text = "Áp dụng từ ngày";
			this.lbtNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtNgay_Ct2
			// 
			this.lbtNgay_Ct2.AutoEllipsis = true;
			this.lbtNgay_Ct2.AutoSize = true;
			this.lbtNgay_Ct2.Location = new System.Drawing.Point(32, 219);
			this.lbtNgay_Ct2.Name = "lbtNgay_Ct2";
			this.lbtNgay_Ct2.Size = new System.Drawing.Size(54, 14);
			this.lbtNgay_Ct2.TabIndex = 203;
			this.lbtNgay_Ct2.Tag = "";
			this.lbtNgay_Ct2.Text = "Đến ngày";
			this.lbtNgay_Ct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(387, 255);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 46);
			this.btgAccept.TabIndex = 9;
			// 
			// txtMa_Vt_Tb
			// 
			this.txtMa_Vt_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Vt_Tb.Location = new System.Drawing.Point(128, 40);
			this.txtMa_Vt_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt_Tb.MaxLength = 20;
			this.txtMa_Vt_Tb.Name = "txtMa_Vt_Tb";
			this.txtMa_Vt_Tb.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Vt_Tb.TabIndex = 0;
			// 
			// lbMa_Vt
			// 
			this.lbMa_Vt.AutoEllipsis = true;
			this.lbMa_Vt.AutoSize = true;
			this.lbMa_Vt.Location = new System.Drawing.Point(32, 43);
			this.lbMa_Vt.Name = "lbMa_Vt";
			this.lbMa_Vt.Size = new System.Drawing.Size(55, 14);
			this.lbMa_Vt.TabIndex = 194;
			this.lbMa_Vt.Tag = "Ma_Vt_Tb";
			this.lbMa_Vt.Text = "Mã thiết bị";
			this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Vt_Tb
			// 
			this.lbtTen_Vt_Tb.AutoEllipsis = true;
			this.lbtTen_Vt_Tb.AutoSize = true;
			this.lbtTen_Vt_Tb.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Vt_Tb.Location = new System.Drawing.Point(259, 43);
			this.lbtTen_Vt_Tb.Name = "lbtTen_Vt_Tb";
			this.lbtTen_Vt_Tb.Size = new System.Drawing.Size(90, 14);
			this.lbtTen_Vt_Tb.TabIndex = 195;
			this.lbtTen_Vt_Tb.Text = "Tên vật tư thiết bị";
			this.lbtTen_Vt_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(32, 87);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(52, 14);
			this.rsLabel2.TabIndex = 197;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "Nội dung ";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(32, 153);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(88, 14);
			this.rsLabel5.TabIndex = 211;
			this.rsLabel5.Tag = "";
			this.rsLabel5.Text = "Nhân viên bảo trì";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Dt_Cbnv
			// 
			this.txtMa_Dt_Cbnv.Location = new System.Drawing.Point(128, 150);
			this.txtMa_Dt_Cbnv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Dt_Cbnv.MaxLength = 20;
			this.txtMa_Dt_Cbnv.Name = "txtMa_Dt_Cbnv";
			this.txtMa_Dt_Cbnv.Size = new System.Drawing.Size(100, 20);
			this.txtMa_Dt_Cbnv.TabIndex = 5;
			// 
			// lbtTen_Dt_Cbnv
			// 
			this.lbtTen_Dt_Cbnv.AutoEllipsis = true;
			this.lbtTen_Dt_Cbnv.AutoSize = true;
			this.lbtTen_Dt_Cbnv.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Dt_Cbnv.Location = new System.Drawing.Point(234, 153);
			this.lbtTen_Dt_Cbnv.Name = "lbtTen_Dt_Cbnv";
			this.lbtTen_Dt_Cbnv.Size = new System.Drawing.Size(75, 14);
			this.lbtTen_Dt_Cbnv.TabIndex = 212;
			this.lbtTen_Dt_Cbnv.Text = "Tên nhân viên";
			this.lbtTen_Dt_Cbnv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Bp
			// 
			this.lbtTen_Bp.AutoEllipsis = true;
			this.lbtTen_Bp.AutoSize = true;
			this.lbtTen_Bp.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Bp.Location = new System.Drawing.Point(234, 177);
			this.lbtTen_Bp.Name = "lbtTen_Bp";
			this.lbtTen_Bp.Size = new System.Drawing.Size(70, 14);
			this.lbtTen_Bp.TabIndex = 215;
			this.lbtTen_Bp.Text = "Tên  bộ phận";
			this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Bp
			// 
			this.txtMa_Bp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Bp.Location = new System.Drawing.Point(128, 172);
			this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Bp.MaxLength = 20;
			this.txtMa_Bp.Name = "txtMa_Bp";
			this.txtMa_Bp.Size = new System.Drawing.Size(101, 20);
			this.txtMa_Bp.TabIndex = 6;
			// 
			// lblMa_Bp
			// 
			this.lblMa_Bp.AutoEllipsis = true;
			this.lblMa_Bp.AutoSize = true;
			this.lblMa_Bp.Location = new System.Drawing.Point(32, 176);
			this.lblMa_Bp.Name = "lblMa_Bp";
			this.lblMa_Bp.Size = new System.Drawing.Size(47, 14);
			this.lblMa_Bp.TabIndex = 214;
			this.lblMa_Bp.Tag = "Ma_Bp";
			this.lblMa_Bp.Text = "Bộ phận";
			this.lblMa_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblLog
			// 
			this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblLog.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLog.ForeColor = System.Drawing.Color.Blue;
			this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblLog.Location = new System.Drawing.Point(33, 280);
			this.lblLog.Name = "lblLog";
			this.lblLog.Size = new System.Drawing.Size(346, 24);
			this.lblLog.TabIndex = 216;
			this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
			this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboNoi_Dung
			// 
			this.cboNoi_Dung.FormattingEnabled = true;
			this.cboNoi_Dung.Location = new System.Drawing.Point(128, 84);
			this.cboNoi_Dung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboNoi_Dung.Name = "cboNoi_Dung";
			this.cboNoi_Dung.Size = new System.Drawing.Size(440, 22);
			this.cboNoi_Dung.TabIndex = 2;
			// 
			// numThoi_Luong
			// 
			this.numThoi_Luong.Location = new System.Drawing.Point(128, 129);
			this.numThoi_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numThoi_Luong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numThoi_Luong.Name = "numThoi_Luong";
			this.numThoi_Luong.Size = new System.Drawing.Size(38, 20);
			this.numThoi_Luong.TabIndex = 4;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(173, 131);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(22, 14);
			this.rsLabel1.TabIndex = 219;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "giờ";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(32, 134);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(59, 14);
			this.rsLabel3.TabIndex = 218;
			this.rsLabel3.Tag = "";
			this.rsLabel3.Text = "Thời lượng";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel31
			// 
			this.rsLabel31.AutoEllipsis = true;
			this.rsLabel31.AutoSize = true;
			this.rsLabel31.Location = new System.Drawing.Point(32, 65);
			this.rsLabel31.Name = "rsLabel31";
			this.rsLabel31.Size = new System.Drawing.Size(66, 14);
			this.rsLabel31.TabIndex = 276;
			this.rsLabel31.Tag = "";
			this.rsLabel31.Text = "Mã phụ tùng";
			this.rsLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Vt_Tb_Kt
			// 
			this.lbtTen_Vt_Tb_Kt.AutoEllipsis = true;
			this.lbtTen_Vt_Tb_Kt.AutoSize = true;
			this.lbtTen_Vt_Tb_Kt.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Vt_Tb_Kt.Location = new System.Drawing.Point(259, 65);
			this.lbtTen_Vt_Tb_Kt.Name = "lbtTen_Vt_Tb_Kt";
			this.lbtTen_Vt_Tb_Kt.Size = new System.Drawing.Size(90, 14);
			this.lbtTen_Vt_Tb_Kt.TabIndex = 277;
			this.lbtTen_Vt_Tb_Kt.Text = "Tên vật tư thiết bị";
			this.lbtTen_Vt_Tb_Kt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Vt_Tb_Kt
			// 
			this.txtMa_Vt_Tb_Kt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Vt_Tb_Kt.Location = new System.Drawing.Point(128, 62);
			this.txtMa_Vt_Tb_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt_Tb_Kt.MaxLength = 20;
			this.txtMa_Vt_Tb_Kt.Name = "txtMa_Vt_Tb_Kt";
			this.txtMa_Vt_Tb_Kt.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Vt_Tb_Kt.TabIndex = 1;
			// 
			// frmKHBTSC_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(580, 313);
			this.Controls.Add(this.rsLabel31);
			this.Controls.Add(this.lbtTen_Vt_Tb_Kt);
			this.Controls.Add(this.txtMa_Vt_Tb_Kt);
			this.Controls.Add(this.numThoi_Luong);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.cboNoi_Dung);
			this.Controls.Add(this.numDinh_Ky);
			this.Controls.Add(this.lblNgay);
			this.Controls.Add(this.lblLog);
			this.Controls.Add(this.lbtDaily);
			this.Controls.Add(this.lbtTen_Bp);
			this.Controls.Add(this.txtMa_Bp);
			this.Controls.Add(this.lblMa_Bp);
			this.Controls.Add(this.lbtTen_Dt_Cbnv);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.dteNgay_End);
			this.Controls.Add(this.txtMa_Dt_Cbnv);
			this.Controls.Add(this.dteNgay_Ap);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.lbMa_Vt);
			this.Controls.Add(this.lbtNgay_Ct1);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.lbtNgay_Ct2);
			this.Controls.Add(this.lbtTen_Vt_Tb);
			this.Controls.Add(this.txtMa_Vt_Tb);
			this.Name = "frmKHBTSC_Edit";
			this.Object_ID = "KHBTSC";
			this.Tag = "KHBTSC";
			this.Text = "frmKHBTSC";
			((System.ComponentModel.ISupportInitialize)(this.numDinh_Ky)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numThoi_Luong)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private RosySystem.Control.rsLabel lblNgay;
		private RosySystem.Control.rsLabel lbtDaily;
		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsNumericUpdown numDinh_Ky;
        private RosySystem.Control.rsTextBox txtMa_Vt_Tb;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsLabel lbtTen_Vt_Tb;
        private RosySystem.Control.rsLabel lbtNgay_Ct1;
        private RosySystem.Control.rsLabel lbtNgay_Ct2;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsDateTime dteNgay_End;
		private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBox txtMa_Dt_Cbnv;
        private RosySystem.Control.rsLabel lbtTen_Dt_Cbnv;
        private RosySystem.Control.rsLabel lbtTen_Bp;
        private RosySystem.Control.rsTextBox txtMa_Bp;
        private RosySystem.Control.rsLabel lblMa_Bp;
		protected System.Windows.Forms.Label lblLog;
		private RosySystem.Control.rsComboBox cboNoi_Dung;
		private RosySystem.Control.rsNumericUpdown numThoi_Luong;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel31;
		private RosySystem.Control.rsLabel lbtTen_Vt_Tb_Kt;
		private RosySystem.Control.rsTextBox txtMa_Vt_Tb_Kt;
    }
}