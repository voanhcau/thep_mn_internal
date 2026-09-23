namespace RosyModule
{
	partial class frmPhan_Hoi_KHVT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhan_Hoi_KHVT));
            this.TabPhanHoi = new RosySystem.Control.rsTabControl();
            this.pagePhanHoiKHVT = new System.Windows.Forms.TabPage();
            this.dgvPhanHoiKHVT = new RosySystem.Customize.dgvVoucher();
            this.pagePhanHoiKTCDAT = new System.Windows.Forms.TabPage();
            this.dgvPhanHoiKTCDAT = new RosySystem.Customize.dgvVoucher();
            this.pagePKD = new System.Windows.Forms.TabPage();
            this.dgvPhanHoiPKD = new RosySystem.Customize.dgvVoucher();
            this.pageDNXNL = new System.Windows.Forms.TabPage();
            this.dgvDNXNL = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_DkGH = new RosySystem.Control.rsDateTime();
            this.pnlTien = new System.Windows.Forms.Panel();
            this.lblTTien = new RosySystem.Control.rsLabel();
            this.lblTTien3 = new RosySystem.Control.rsLabel();
            this.lblTTien0 = new RosySystem.Control.rsLabel();
            this.numTTien_Nt = new RosySystem.Control.rsTextBoxNumber();
            this.numTTien_Nt3 = new RosySystem.Control.rsTextBoxNumber();
            this.numTTien_Nt0 = new RosySystem.Control.rsTextBoxNumber();
            this.TabPhanHoi.SuspendLayout();
            this.pagePhanHoiKHVT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoiKHVT)).BeginInit();
            this.pagePhanHoiKTCDAT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoiKTCDAT)).BeginInit();
            this.pagePKD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoiPKD)).BeginInit();
            this.pageDNXNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDNXNL)).BeginInit();
            this.pnlTien.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPhanHoi
            // 
            this.TabPhanHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPhanHoi.Controls.Add(this.pagePhanHoiKHVT);
            this.TabPhanHoi.Controls.Add(this.pagePhanHoiKTCDAT);
            this.TabPhanHoi.Controls.Add(this.pagePKD);
            this.TabPhanHoi.Controls.Add(this.pageDNXNL);
            this.TabPhanHoi.Location = new System.Drawing.Point(3, 6);
            this.TabPhanHoi.Name = "TabPhanHoi";
            this.TabPhanHoi.SelectedIndex = 0;
            this.TabPhanHoi.Size = new System.Drawing.Size(1213, 388);
            this.TabPhanHoi.TabIndex = 0;
            // 
            // pagePhanHoiKHVT
            // 
            this.pagePhanHoiKHVT.Controls.Add(this.dgvPhanHoiKHVT);
            this.pagePhanHoiKHVT.Location = new System.Drawing.Point(4, 22);
            this.pagePhanHoiKHVT.Name = "pagePhanHoiKHVT";
            this.pagePhanHoiKHVT.Padding = new System.Windows.Forms.Padding(3);
            this.pagePhanHoiKHVT.Size = new System.Drawing.Size(1205, 362);
            this.pagePhanHoiKHVT.TabIndex = 0;
            this.pagePhanHoiKHVT.Text = "Chi tiết phản hồi PKHVT";
            this.pagePhanHoiKHVT.UseVisualStyleBackColor = true;
            // 
            // dgvPhanHoiKHVT
            // 
            this.dgvPhanHoiKHVT.AllowUserToAddRows = false;
            this.dgvPhanHoiKHVT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhanHoiKHVT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhanHoiKHVT.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanHoiKHVT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhanHoiKHVT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanHoiKHVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanHoiKHVT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPhanHoiKHVT.Location = new System.Drawing.Point(3, 3);
            this.dgvPhanHoiKHVT.MultiSelect = false;
            this.dgvPhanHoiKHVT.Name = "dgvPhanHoiKHVT";
            this.dgvPhanHoiKHVT.Size = new System.Drawing.Size(1199, 356);
            this.dgvPhanHoiKHVT.strZone = "";
            this.dgvPhanHoiKHVT.TabIndex = 2;
            // 
            // pagePhanHoiKTCDAT
            // 
            this.pagePhanHoiKTCDAT.Controls.Add(this.dgvPhanHoiKTCDAT);
            this.pagePhanHoiKTCDAT.Location = new System.Drawing.Point(4, 22);
            this.pagePhanHoiKTCDAT.Name = "pagePhanHoiKTCDAT";
            this.pagePhanHoiKTCDAT.Size = new System.Drawing.Size(1205, 372);
            this.pagePhanHoiKTCDAT.TabIndex = 1;
            this.pagePhanHoiKTCDAT.Text = "Chi tiết phản hồi PX - PKTCDAT";
            this.pagePhanHoiKTCDAT.UseVisualStyleBackColor = true;
            // 
            // dgvPhanHoiKTCDAT
            // 
            this.dgvPhanHoiKTCDAT.AllowUserToAddRows = false;
            this.dgvPhanHoiKTCDAT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhanHoiKTCDAT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhanHoiKTCDAT.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanHoiKTCDAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhanHoiKTCDAT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanHoiKTCDAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanHoiKTCDAT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPhanHoiKTCDAT.Location = new System.Drawing.Point(0, 0);
            this.dgvPhanHoiKTCDAT.MultiSelect = false;
            this.dgvPhanHoiKTCDAT.Name = "dgvPhanHoiKTCDAT";
            this.dgvPhanHoiKTCDAT.Size = new System.Drawing.Size(1205, 372);
            this.dgvPhanHoiKTCDAT.strZone = "";
            this.dgvPhanHoiKTCDAT.TabIndex = 2;
            // 
            // pagePKD
            // 
            this.pagePKD.Controls.Add(this.dgvPhanHoiPKD);
            this.pagePKD.Location = new System.Drawing.Point(4, 22);
            this.pagePKD.Name = "pagePKD";
            this.pagePKD.Size = new System.Drawing.Size(1205, 372);
            this.pagePKD.TabIndex = 2;
            this.pagePKD.Text = "Chi tiết sửa thông tin PKD";
            this.pagePKD.UseVisualStyleBackColor = true;
            // 
            // dgvPhanHoiPKD
            // 
            this.dgvPhanHoiPKD.AllowUserToAddRows = false;
            this.dgvPhanHoiPKD.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhanHoiPKD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhanHoiPKD.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanHoiPKD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhanHoiPKD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanHoiPKD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanHoiPKD.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPhanHoiPKD.Location = new System.Drawing.Point(0, 0);
            this.dgvPhanHoiPKD.MultiSelect = false;
            this.dgvPhanHoiPKD.Name = "dgvPhanHoiPKD";
            this.dgvPhanHoiPKD.Size = new System.Drawing.Size(1205, 372);
            this.dgvPhanHoiPKD.strZone = "";
            this.dgvPhanHoiPKD.TabIndex = 3;
            // 
            // pageDNXNL
            // 
            this.pageDNXNL.Controls.Add(this.dgvDNXNL);
            this.pageDNXNL.Location = new System.Drawing.Point(4, 22);
            this.pageDNXNL.Name = "pageDNXNL";
            this.pageDNXNL.Size = new System.Drawing.Size(1205, 372);
            this.pageDNXNL.TabIndex = 3;
            this.pageDNXNL.Text = "Chi tiết hóa đơn nhiên liệu";
            this.pageDNXNL.UseVisualStyleBackColor = true;
            // 
            // dgvDNXNL
            // 
            this.dgvDNXNL.AllowUserToAddRows = false;
            this.dgvDNXNL.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDNXNL.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDNXNL.BackgroundColor = System.Drawing.Color.White;
            this.dgvDNXNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDNXNL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDNXNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDNXNL.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDNXNL.Location = new System.Drawing.Point(0, 0);
            this.dgvDNXNL.MultiSelect = false;
            this.dgvDNXNL.Name = "dgvDNXNL";
            this.dgvDNXNL.Size = new System.Drawing.Size(1205, 372);
            this.dgvDNXNL.strZone = "";
            this.dgvDNXNL.TabIndex = 4;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(1031, 415);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(14, 424);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(78, 13);
            this.lblNgay_Ct.TabIndex = 56;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Ngày đặt hàng";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_DkGH
            // 
            this.dteNgay_DkGH.bAllowEmpty = true;
            this.dteNgay_DkGH.bSelectOnFocus = false;
            this.dteNgay_DkGH.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_DkGH.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_DkGH.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_DkGH.Location = new System.Drawing.Point(95, 420);
            this.dteNgay_DkGH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.dteNgay_DkGH.Mask = "00/00/0000";
            this.dteNgay_DkGH.Name = "dteNgay_DkGH";
            this.dteNgay_DkGH.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_DkGH.TabIndex = 55;
            // 
            // pnlTien
            // 
            this.pnlTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTien.Controls.Add(this.lblTTien);
            this.pnlTien.Controls.Add(this.lblTTien3);
            this.pnlTien.Controls.Add(this.lblTTien0);
            this.pnlTien.Controls.Add(this.numTTien_Nt);
            this.pnlTien.Controls.Add(this.numTTien_Nt3);
            this.pnlTien.Controls.Add(this.numTTien_Nt0);
            this.pnlTien.Location = new System.Drawing.Point(815, 394);
            this.pnlTien.Name = "pnlTien";
            this.pnlTien.Size = new System.Drawing.Size(209, 69);
            this.pnlTien.TabIndex = 119;
            // 
            // lblTTien
            // 
            this.lblTTien.AutoEllipsis = true;
            this.lblTTien.AutoSize = true;
            this.lblTTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTien.ForeColor = System.Drawing.Color.Blue;
            this.lblTTien.Location = new System.Drawing.Point(4, 48);
            this.lblTTien.Name = "lblTTien";
            this.lblTTien.Size = new System.Drawing.Size(61, 13);
            this.lblTTien.TabIndex = 124;
            this.lblTTien.Tag = "TTien";
            this.lblTTien.Text = "Tổng tiền";
            this.lblTTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTTien3
            // 
            this.lblTTien3.AutoEllipsis = true;
            this.lblTTien3.AutoSize = true;
            this.lblTTien3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTien3.ForeColor = System.Drawing.Color.Blue;
            this.lblTTien3.Location = new System.Drawing.Point(4, 26);
            this.lblTTien3.Name = "lblTTien3";
            this.lblTTien3.Size = new System.Drawing.Size(60, 13);
            this.lblTTien3.TabIndex = 123;
            this.lblTTien3.Tag = "TTien3";
            this.lblTTien3.Text = "Tiền VAT";
            this.lblTTien3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTTien0
            // 
            this.lblTTien0.AutoEllipsis = true;
            this.lblTTien0.AutoSize = true;
            this.lblTTien0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTien0.ForeColor = System.Drawing.Color.Blue;
            this.lblTTien0.Location = new System.Drawing.Point(4, 4);
            this.lblTTien0.Name = "lblTTien0";
            this.lblTTien0.Size = new System.Drawing.Size(64, 13);
            this.lblTTien0.TabIndex = 119;
            this.lblTTien0.Tag = "TTien0";
            this.lblTTien0.Text = "Tiền hàng";
            this.lblTTien0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTTien_Nt
            // 
            this.numTTien_Nt.AutoDropDown = null;
            this.numTTien_Nt.bFormat = true;
            this.numTTien_Nt.Enabled = false;
            this.numTTien_Nt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Nt.ForeColor = System.Drawing.Color.Blue;
            this.numTTien_Nt.Location = new System.Drawing.Point(89, 44);
            this.numTTien_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Nt.Name = "numTTien_Nt";
            this.numTTien_Nt.Scale = 2;
            this.numTTien_Nt.Size = new System.Drawing.Size(111, 20);
            this.numTTien_Nt.TabIndex = 122;
            this.numTTien_Nt.TabStop = false;
            this.numTTien_Nt.Text = "0.00";
            this.numTTien_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Nt.Value = 0D;
            // 
            // numTTien_Nt3
            // 
            this.numTTien_Nt3.AutoDropDown = null;
            this.numTTien_Nt3.bFormat = true;
            this.numTTien_Nt3.Enabled = false;
            this.numTTien_Nt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Nt3.ForeColor = System.Drawing.Color.Blue;
            this.numTTien_Nt3.Location = new System.Drawing.Point(89, 22);
            this.numTTien_Nt3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Nt3.Name = "numTTien_Nt3";
            this.numTTien_Nt3.Scale = 2;
            this.numTTien_Nt3.Size = new System.Drawing.Size(111, 20);
            this.numTTien_Nt3.TabIndex = 121;
            this.numTTien_Nt3.TabStop = false;
            this.numTTien_Nt3.Text = "0.00";
            this.numTTien_Nt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Nt3.Value = 0D;
            // 
            // numTTien_Nt0
            // 
            this.numTTien_Nt0.AutoDropDown = null;
            this.numTTien_Nt0.bFormat = true;
            this.numTTien_Nt0.Enabled = false;
            this.numTTien_Nt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Nt0.ForeColor = System.Drawing.Color.Blue;
            this.numTTien_Nt0.Location = new System.Drawing.Point(89, 0);
            this.numTTien_Nt0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Nt0.Name = "numTTien_Nt0";
            this.numTTien_Nt0.Scale = 2;
            this.numTTien_Nt0.Size = new System.Drawing.Size(111, 20);
            this.numTTien_Nt0.TabIndex = 120;
            this.numTTien_Nt0.TabStop = false;
            this.numTTien_Nt0.Text = "0.00";
            this.numTTien_Nt0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Nt0.Value = 0D;
            // 
            // frmPhan_Hoi_KHVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 463);
            this.Controls.Add(this.pnlTien);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.dteNgay_DkGH);
            this.Controls.Add(this.TabPhanHoi);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmPhan_Hoi_KHVT";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Chi tiết phản hồi - Sửa thông tin PKD";
            this.TabPhanHoi.ResumeLayout(false);
            this.pagePhanHoiKHVT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoiKHVT)).EndInit();
            this.pagePhanHoiKTCDAT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoiKTCDAT)).EndInit();
            this.pagePKD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoiPKD)).EndInit();
            this.pageDNXNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDNXNL)).EndInit();
            this.pnlTien.ResumeLayout(false);
            this.pnlTien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage pagePhanHoiKHVT;
		private RosySystem.Control.rsTabControl TabPhanHoi;
		private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage pagePhanHoiKTCDAT;
        private RosySystem.Customize.dgvVoucher dgvPhanHoiKTCDAT;
        private RosySystem.Customize.dgvVoucher dgvPhanHoiKHVT;
        private System.Windows.Forms.TabPage pagePKD;
        private RosySystem.Customize.dgvVoucher dgvPhanHoiPKD;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_DkGH;
        private System.Windows.Forms.TabPage pageDNXNL;
        private RosySystem.Customize.dgvVoucher dgvDNXNL;
        private System.Windows.Forms.Panel pnlTien;
        private RosySystem.Control.rsLabel lblTTien;
        private RosySystem.Control.rsLabel lblTTien3;
        private RosySystem.Control.rsLabel lblTTien0;
        private RosySystem.Control.rsTextBoxNumber numTTien_Nt;
        private RosySystem.Control.rsTextBoxNumber numTTien_Nt3;
        private RosySystem.Control.rsTextBoxNumber numTTien_Nt0;
    }
}

