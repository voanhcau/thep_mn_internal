namespace RosyModule.HRM
{
    partial class frmQTCT_Edit
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
            this.dteNgay_Bd = new RosySystem.Control.rsDateTime();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.txtMa_Bp = new RosySystem.Control.rsTextBox();
            this.txtTen_Bp = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.txtSo_QD = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // dteNgay_Bd
            // 
            this.dteNgay_Bd.bAllowEmpty = false;
            this.dteNgay_Bd.bSelectOnFocus = false;
            this.dteNgay_Bd.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Bd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Bd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Bd.Location = new System.Drawing.Point(130, 111);
            this.dteNgay_Bd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Bd.Mask = "00/00/0000";
            this.dteNgay_Bd.Name = "dteNgay_Bd";
            this.dteNgay_Bd.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Bd.TabIndex = 123;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(21, 144);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(44, 13);
            this.rsLabel5.TabIndex = 134;
            this.rsLabel5.Tag = "Ghi_Chu";
            this.rsLabel5.Text = "Ghi chú";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(21, 114);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(72, 13);
            this.rsLabel4.TabIndex = 135;
            this.rsLabel4.Tag = "Ngay_BD";
            this.rsLabel4.Text = "Ngày bắt đầu";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(130, 134);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(450, 40);
            this.txtGhi_Chu.TabIndex = 125;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(255, 22);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(59, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 133;
            this.lbtTen_Dt_CbNv.Text = "Ten_CbNv";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(402, 185);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 43);
            this.btgAccept.TabIndex = 126;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(21, 70);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(64, 13);
            this.rsLabel3.TabIndex = 131;
            this.rsLabel3.Tag = "Ma_Bp";
            this.rsLabel3.Text = "Mã bộ phận";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(21, 92);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(92, 13);
            this.rsLabel9.TabIndex = 132;
            this.rsLabel9.Tag = "Bo_Phan_Cong_Tac";
            this.rsLabel9.Text = "Bộ phận công tác";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.AutoDropDown = null;
            this.txtMa_Bp.Location = new System.Drawing.Point(130, 66);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Bp.TabIndex = 122;
            // 
            // txtTen_Bp
            // 
            this.txtTen_Bp.AutoDropDown = null;
            this.txtTen_Bp.Location = new System.Drawing.Point(130, 89);
            this.txtTen_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Bp.Name = "txtTen_Bp";
            this.txtTen_Bp.Size = new System.Drawing.Size(120, 20);
            this.txtTen_Bp.TabIndex = 119;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(21, 21);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(72, 13);
            this.rsLabel1.TabIndex = 127;
            this.rsLabel1.Tag = "Ma_Dt_CbNv";
            this.rsLabel1.Text = "Mã nhân viên";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(130, 18);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt_CbNv.TabIndex = 117;
            // 
            // txtSo_QD
            // 
            this.txtSo_QD.AutoDropDown = null;
            this.txtSo_QD.Location = new System.Drawing.Point(130, 41);
            this.txtSo_QD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_QD.Name = "txtSo_QD";
            this.txtSo_QD.Size = new System.Drawing.Size(196, 20);
            this.txtSo_QD.TabIndex = 118;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(21, 44);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(73, 13);
            this.rsLabel2.TabIndex = 129;
            this.rsLabel2.Tag = "So_Qd";
            this.rsLabel2.Text = "Số quyết định";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmQTCT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 234);
            this.Controls.Add(this.dteNgay_Bd);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtMa_Bp);
            this.Controls.Add(this.txtTen_Bp);
            this.Controls.Add(this.txtSo_QD);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Name = "frmQTCT_Edit";
            this.Text = "frmQTCT_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsDateTime dteNgay_Bd;
        private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBox txtGhi_Chu;
		private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
        public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel9;
		private RosySystem.Control.rsTextBox txtMa_Bp;
        private RosySystem.Control.rsTextBox txtTen_Bp;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsTextBox txtSo_QD;
        private RosySystem.Control.rsLabel rsLabel2;

	}
}