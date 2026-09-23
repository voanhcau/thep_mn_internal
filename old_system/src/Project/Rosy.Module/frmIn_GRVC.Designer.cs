namespace RosyModule
{
    partial class frmIn_GRVC
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
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabel();
            this.dteNgay_Bg = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct1 = new RosySystem.Control.rsLabel();
            this.txtNoi_Bg = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtTen_Dt_Giao2 = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtTen_Dt_Giao1 = new RosySystem.Control.rsTextBox();
            this.txtChuc_Vu_Giao2 = new RosySystem.Control.rsTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtChuc_Vu_Giao1 = new RosySystem.Control.rsTextBox();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.chkIs_Tb = new RosySystem.Control.rsCheckbox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(526, 107);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // lbtTen_Nh_Tb
            // 
            this.lbtTen_Nh_Tb.AutoEllipsis = true;
            this.lbtTen_Nh_Tb.AutoSize = true;
            this.lbtTen_Nh_Tb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbtTen_Nh_Tb.Location = new System.Drawing.Point(1, 182);
            this.lbtTen_Nh_Tb.Name = "lbtTen_Nh_Tb";
            this.lbtTen_Nh_Tb.Size = new System.Drawing.Size(0, 13);
            this.lbtTen_Nh_Tb.TabIndex = 19;
            this.lbtTen_Nh_Tb.Tag = "";
            this.lbtTen_Nh_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Bg
            // 
            this.dteNgay_Bg.bAllowEmpty = true;
            this.dteNgay_Bg.bSelectOnFocus = false;
            this.dteNgay_Bg.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Bg.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Bg.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Bg.Location = new System.Drawing.Point(163, 105);
            this.dteNgay_Bg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Bg.Mask = "00/00/0000";
            this.dteNgay_Bg.Name = "dteNgay_Bg";
            this.dteNgay_Bg.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Bg.TabIndex = 0;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.Location = new System.Drawing.Point(13, 107);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(112, 13);
            this.lblNgay_Ct1.TabIndex = 93;
            this.lblNgay_Ct1.Tag = "";
            this.lblNgay_Ct1.Text = "Ngày dự kiến hàng về";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoi_Bg
            // 
            this.txtNoi_Bg.AutoDropDown = null;
            this.txtNoi_Bg.Location = new System.Drawing.Point(163, 81);
            this.txtNoi_Bg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNoi_Bg.MaxLength = 1000;
            this.txtNoi_Bg.Multiline = true;
            this.txtNoi_Bg.Name = "txtNoi_Bg";
            this.txtNoi_Bg.Size = new System.Drawing.Size(223, 23);
            this.txtNoi_Bg.TabIndex = 1;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(13, 83);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(34, 13);
            this.rsLabel1.TabIndex = 95;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Số xe";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(13, 60);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(96, 13);
            this.rsLabel3.TabIndex = 99;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Mã NV/ Số CMND";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Dt_Giao2
            // 
            this.txtTen_Dt_Giao2.AutoDropDown = null;
            this.txtTen_Dt_Giao2.Location = new System.Drawing.Point(163, 55);
            this.txtTen_Dt_Giao2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Dt_Giao2.MaxLength = 1000;
            this.txtTen_Dt_Giao2.Multiline = true;
            this.txtTen_Dt_Giao2.Name = "txtTen_Dt_Giao2";
            this.txtTen_Dt_Giao2.Size = new System.Drawing.Size(223, 23);
            this.txtTen_Dt_Giao2.TabIndex = 4;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(13, 35);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(150, 13);
            this.rsLabel4.TabIndex = 101;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Tên người mang hàng ra cổng";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Dt_Giao1
            // 
            this.txtTen_Dt_Giao1.AutoDropDown = null;
            this.txtTen_Dt_Giao1.Location = new System.Drawing.Point(163, 30);
            this.txtTen_Dt_Giao1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Dt_Giao1.MaxLength = 1000;
            this.txtTen_Dt_Giao1.Multiline = true;
            this.txtTen_Dt_Giao1.Name = "txtTen_Dt_Giao1";
            this.txtTen_Dt_Giao1.Size = new System.Drawing.Size(223, 23);
            this.txtTen_Dt_Giao1.TabIndex = 2;
            // 
            // txtChuc_Vu_Giao2
            // 
            this.txtChuc_Vu_Giao2.AutoDropDown = null;
            this.txtChuc_Vu_Giao2.Location = new System.Drawing.Point(452, 55);
            this.txtChuc_Vu_Giao2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtChuc_Vu_Giao2.MaxLength = 1000;
            this.txtChuc_Vu_Giao2.Multiline = true;
            this.txtChuc_Vu_Giao2.Name = "txtChuc_Vu_Giao2";
            this.txtChuc_Vu_Giao2.Size = new System.Drawing.Size(259, 23);
            this.txtChuc_Vu_Giao2.TabIndex = 5;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(400, 60);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(38, 13);
            this.rsLabel7.TabIndex = 99;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Đơn vị";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChuc_Vu_Giao1
            // 
            this.txtChuc_Vu_Giao1.AutoDropDown = null;
            this.txtChuc_Vu_Giao1.Location = new System.Drawing.Point(452, 30);
            this.txtChuc_Vu_Giao1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtChuc_Vu_Giao1.MaxLength = 1000;
            this.txtChuc_Vu_Giao1.Multiline = true;
            this.txtChuc_Vu_Giao1.Name = "txtChuc_Vu_Giao1";
            this.txtChuc_Vu_Giao1.Size = new System.Drawing.Size(259, 23);
            this.txtChuc_Vu_Giao1.TabIndex = 3;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(400, 35);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(47, 13);
            this.rsLabel8.TabIndex = 101;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Chức vụ";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIs_Tb
            // 
            this.chkIs_Tb.AutoSize = true;
            this.chkIs_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Tb.ForeColor = System.Drawing.Color.Red;
            this.chkIs_Tb.Location = new System.Drawing.Point(163, 9);
            this.chkIs_Tb.Name = "chkIs_Tb";
            this.chkIs_Tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIs_Tb.Size = new System.Drawing.Size(88, 17);
            this.chkIs_Tb.TabIndex = 1046;
            this.chkIs_Tb.TabStop = false;
            this.chkIs_Tb.Text = "&Giao VTPT";
            this.chkIs_Tb.UseVisualStyleBackColor = true;
            // 
            // frmIn_GRVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 164);
            this.Controls.Add(this.chkIs_Tb);
            this.Controls.Add(this.rsLabel8);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.txtChuc_Vu_Giao1);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.txtTen_Dt_Giao1);
            this.Controls.Add(this.txtChuc_Vu_Giao2);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtTen_Dt_Giao2);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtNoi_Bg);
            this.Controls.Add(this.dteNgay_Bg);
            this.Controls.Add(this.lblNgay_Ct1);
            this.Controls.Add(this.lbtTen_Nh_Tb);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmIn_GRVC";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        public RosySystem.Control.rsDateTime dteNgay_Bg;
        private RosySystem.Control.rsLabel lblNgay_Ct1;
        private RosySystem.Control.rsTextBox txtNoi_Bg;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtTen_Dt_Giao2;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBox txtTen_Dt_Giao1;
        private RosySystem.Control.rsTextBox txtChuc_Vu_Giao2;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsTextBox txtChuc_Vu_Giao1;
        private RosySystem.Control.rsLabel rsLabel8;
        public RosySystem.Control.rsCheckbox chkIs_Tb;
	}
}