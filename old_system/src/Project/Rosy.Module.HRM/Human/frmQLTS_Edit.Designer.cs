namespace RosyModule.HRM
{
    partial class frmQLTS_Edit
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
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtLy_Do = new RosySystem.Control.rsTextBox();
            this.dteNgay_Cap = new RosySystem.Control.rsDateTime();
            this.lbtTen_Vt = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.cboTinh_Trang = new RosySystem.Control.rsComboBox();
            this.rsLabel38 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(214, 23);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(59, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 122;
            this.lbtTen_Dt_CbNv.Text = "Ten_CbNv";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(383, 157);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 44);
            this.btgAccept.TabIndex = 5;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(14, 97);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(54, 13);
            this.rsLabel4.TabIndex = 121;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Lý do cấp";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(14, 22);
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
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(89, 19);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(14, 73);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(53, 13);
            this.rsLabel7.TabIndex = 118;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Ngày cấp";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLy_Do
            // 
            this.txtLy_Do.AutoDropDown = null;
            this.txtLy_Do.Location = new System.Drawing.Point(89, 94);
            this.txtLy_Do.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLy_Do.Name = "txtLy_Do";
            this.txtLy_Do.Size = new System.Drawing.Size(489, 20);
            this.txtLy_Do.TabIndex = 3;
            // 
            // dteNgay_Cap
            // 
            this.dteNgay_Cap.bAllowEmpty = true;
            this.dteNgay_Cap.bSelectOnFocus = false;
            this.dteNgay_Cap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Cap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Cap.Location = new System.Drawing.Point(89, 70);
            this.dteNgay_Cap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Cap.Mask = "00/00/0000";
            this.dteNgay_Cap.Name = "dteNgay_Cap";
            this.dteNgay_Cap.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Cap.TabIndex = 2;
            this.dteNgay_Cap.Tag = "Ngay_Ct";
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(214, 50);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(42, 13);
            this.lbtTen_Vt.TabIndex = 125;
            this.lbtTen_Vt.Text = "Ten_Vt";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(14, 50);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(52, 13);
            this.rsLabel5.TabIndex = 124;
            this.rsLabel5.Tag = "Ma_Vt";
            this.rsLabel5.Text = "Mã vật tư";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.Location = new System.Drawing.Point(89, 46);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 1;
            // 
            // cboTinh_Trang
            // 
            this.cboTinh_Trang.FormattingEnabled = true;
            this.cboTinh_Trang.Items.AddRange(new object[] {
            "Đang sử dụng",
            "Đã thu hồi"});
            this.cboTinh_Trang.Location = new System.Drawing.Point(89, 119);
            this.cboTinh_Trang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboTinh_Trang.Name = "cboTinh_Trang";
            this.cboTinh_Trang.Size = new System.Drawing.Size(220, 21);
            this.cboTinh_Trang.TabIndex = 4;
            this.cboTinh_Trang.Text = "Đang sử dụng";
            // 
            // rsLabel38
            // 
            this.rsLabel38.AutoEllipsis = true;
            this.rsLabel38.AutoSize = true;
            this.rsLabel38.Location = new System.Drawing.Point(14, 121);
            this.rsLabel38.Name = "rsLabel38";
            this.rsLabel38.Size = new System.Drawing.Size(55, 13);
            this.rsLabel38.TabIndex = 172;
            this.rsLabel38.Tag = "";
            this.rsLabel38.Text = "Tình trạng";
            this.rsLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmQLTS_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 205);
            this.Controls.Add(this.cboTinh_Trang);
            this.Controls.Add(this.rsLabel38);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.dteNgay_Cap);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.txtLy_Do);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmQLTS_Edit";
            this.Text = "frmQLTS_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsTextBox txtLy_Do;
        private RosySystem.Control.rsDateTime dteNgay_Cap;
        private RosySystem.Control.rsLabel lbtTen_Vt;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBox txtMa_Vt;
        private RosySystem.Control.rsComboBox cboTinh_Trang;
        private RosySystem.Control.rsLabel rsLabel38;

	}
}