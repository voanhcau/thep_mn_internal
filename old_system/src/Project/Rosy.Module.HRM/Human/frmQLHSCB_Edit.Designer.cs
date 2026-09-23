namespace RosyModule.HRM
{
    partial class frmQLHSCB_Edit
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
            this.components = new System.ComponentModel.Container();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.txtFile_Path = new RosySystem.Control.rsTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.dteNgay_Qd = new RosySystem.Control.rsDateTime();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.txtMa_Chuc_Danh = new RosySystem.Control.rsTextBox();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.txtSo_Qd = new RosySystem.Control.rsTextBox();
            this.lbtTen_Chuc_Danh = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtMa_Bp = new RosySystem.Control.rsTextBox();
            this.lbtTen_Bp = new RosySystem.Control.rsLabel();
            this.btUpload = new RosySystem.Customize.btDelete();
            this.SuspendLayout();
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(232, 23);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(59, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 122;
            this.lbtTen_Dt_CbNv.Text = "Ten_CbNv";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(435, 178);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 44);
            this.btgAccept.TabIndex = 7;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(8, 147);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(23, 13);
            this.rsLabel3.TabIndex = 119;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "File";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(8, 22);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(72, 13);
            this.rsLabel1.TabIndex = 117;
            this.rsLabel1.Tag = "Ma_Dt_CbNv";
            this.rsLabel1.Text = "Mã nhân viên";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(110, 19);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // txtFile_Path
            // 
            this.txtFile_Path.AutoDropDown = null;
            this.txtFile_Path.Location = new System.Drawing.Point(110, 144);
            this.txtFile_Path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Path.Name = "txtFile_Path";
            this.txtFile_Path.Size = new System.Drawing.Size(410, 20);
            this.txtFile_Path.TabIndex = 5;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(8, 81);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(85, 13);
            this.rsLabel7.TabIndex = 118;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Ngày quyết định";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Qd
            // 
            this.dteNgay_Qd.bAllowEmpty = true;
            this.dteNgay_Qd.bSelectOnFocus = false;
            this.dteNgay_Qd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Qd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Qd.Location = new System.Drawing.Point(110, 78);
            this.dteNgay_Qd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Qd.Mask = "00/00/0000";
            this.dteNgay_Qd.Name = "dteNgay_Qd";
            this.dteNgay_Qd.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Qd.TabIndex = 2;
            this.dteNgay_Qd.Tag = "Ngay_Ct";
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Location = new System.Drawing.Point(8, 103);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(59, 13);
            this.rsLabel10.TabIndex = 127;
            this.rsLabel10.Tag = "";
            this.rsLabel10.Text = "Chức danh";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Chuc_Danh
            // 
            this.txtMa_Chuc_Danh.AutoDropDown = null;
            this.txtMa_Chuc_Danh.Location = new System.Drawing.Point(110, 100);
            this.txtMa_Chuc_Danh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Chuc_Danh.Name = "txtMa_Chuc_Danh";
            this.txtMa_Chuc_Danh.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Chuc_Danh.TabIndex = 3;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(8, 59);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(73, 13);
            this.rsLabel11.TabIndex = 129;
            this.rsLabel11.Tag = "";
            this.rsLabel11.Text = "Số quyết định";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Qd
            // 
            this.txtSo_Qd.AutoDropDown = null;
            this.txtSo_Qd.Location = new System.Drawing.Point(110, 56);
            this.txtSo_Qd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Qd.Name = "txtSo_Qd";
            this.txtSo_Qd.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Qd.TabIndex = 1;
            // 
            // lbtTen_Chuc_Danh
            // 
            this.lbtTen_Chuc_Danh.AutoEllipsis = true;
            this.lbtTen_Chuc_Danh.AutoSize = true;
            this.lbtTen_Chuc_Danh.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Chuc_Danh.Location = new System.Drawing.Point(232, 103);
            this.lbtTen_Chuc_Danh.Name = "lbtTen_Chuc_Danh";
            this.lbtTen_Chuc_Danh.Size = new System.Drawing.Size(89, 13);
            this.lbtTen_Chuc_Danh.TabIndex = 122;
            this.lbtTen_Chuc_Danh.Text = "Ten_Chuc_Danh";
            this.lbtTen_Chuc_Danh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(8, 125);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(93, 13);
            this.rsLabel2.TabIndex = 132;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Bộ phận bổ nhiệm";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.AutoDropDown = null;
            this.txtMa_Bp.Location = new System.Drawing.Point(110, 122);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Bp.TabIndex = 4;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoEllipsis = true;
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Bp.Location = new System.Drawing.Point(232, 125);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(45, 13);
            this.lbtTen_Bp.TabIndex = 131;
            this.lbtTen_Bp.Text = "Ten_Bp";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btUpload
            // 
            this.btUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpload.ImageKey = "(none)";
            this.btUpload.Location = new System.Drawing.Point(525, 143);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(73, 21);
            this.btUpload.TabIndex = 6;
            this.btUpload.Tag = "";
            this.btUpload.Text = "Browse";
            this.btUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpload.UseVisualStyleBackColor = true;
            // 
            // frmQLHSCB_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 226);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtMa_Bp);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.rsLabel11);
            this.Controls.Add(this.txtSo_Qd);
            this.Controls.Add(this.rsLabel10);
            this.Controls.Add(this.txtMa_Chuc_Danh);
            this.Controls.Add(this.dteNgay_Qd);
            this.Controls.Add(this.lbtTen_Chuc_Danh);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtFile_Path);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Name = "frmQLHSCB_Edit";
            this.Text = "frmQLHSCB_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsTextBox txtFile_Path;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsDateTime dteNgay_Qd;
        private RosySystem.Control.rsLabel rsLabel10;
        private RosySystem.Control.rsTextBox txtMa_Chuc_Danh;
        private RosySystem.Control.rsLabel rsLabel11;
        private RosySystem.Control.rsTextBox txtSo_Qd;
        private RosySystem.Control.rsLabel lbtTen_Chuc_Danh;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtMa_Bp;
        private RosySystem.Control.rsLabel lbtTen_Bp;
        private RosySystem.Customize.btDelete btUpload;

	}
}