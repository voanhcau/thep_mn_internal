namespace RosyModule
{
	partial class frmIn_Ct_HD
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
            this.rdbHd_Dat_In = new RosySystem.Control.rsRadioButton();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rdbHd_Tu_In = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbHd_DT_PDF = new RosySystem.Control.rsRadioButton();
            this.rdbInvoice = new RosySystem.Control.rsRadioButton();
            this.rdbPhieu_Xuat = new RosySystem.Control.rsRadioButton();
            this.rdbHd_Dt_Cd = new RosySystem.Control.rsRadioButton();
            this.rdbHd_DT = new RosySystem.Control.rsRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbTien_Nt = new RosySystem.Control.rsRadioButton();
            this.rdbTien_VND = new RosySystem.Control.rsRadioButton();
            this.txtTk_Nh_B = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtTen_DtGtGt = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtDia_Chi = new RosySystem.Control.rsTextBox();
            this.lblDia_Chi = new RosySystem.Control.rsLabel();
            this.txtOng_Ba = new RosySystem.Control.rsTextBox();
            this.lblOng_Ba = new RosySystem.Control.rsLabel();
            this.txtMa_So_Thue = new RosySystem.Control.rsTextBox();
            this.lblMa_So_Thue = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtTen_NH_B = new RosySystem.Control.rsTextBox();
            this.txtTen_Kt = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtTen_Kd = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.gbIn_Tien.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbHd_Dat_In
            // 
            this.rdbHd_Dat_In.AutoSize = true;
            this.rdbHd_Dat_In.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbHd_Dat_In.Location = new System.Drawing.Point(233, 33);
            this.rdbHd_Dat_In.Name = "rdbHd_Dat_In";
            this.rdbHd_Dat_In.Size = new System.Drawing.Size(106, 17);
            this.rdbHd_Dat_In.TabIndex = 1;
            this.rdbHd_Dat_In.Tag = "In_Hd_Dat_In";
            this.rdbHd_Dat_In.Text = "In hóa đơn đặt in";
            this.rdbHd_Dat_In.UnChecked = true;
            this.rdbHd_Dat_In.UseVisualStyleBackColor = true;
            this.rdbHd_Dat_In.Visible = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(313, 344);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 11;
            // 
            // rdbHd_Tu_In
            // 
            this.rdbHd_Tu_In.AutoSize = true;
            this.rdbHd_Tu_In.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbHd_Tu_In.Location = new System.Drawing.Point(111, 10);
            this.rdbHd_Tu_In.Name = "rdbHd_Tu_In";
            this.rdbHd_Tu_In.Size = new System.Drawing.Size(89, 17);
            this.rdbHd_Tu_In.TabIndex = 0;
            this.rdbHd_Tu_In.Tag = "Hd_Tu_In";
            this.rdbHd_Tu_In.Text = "Hóa đơn tự in";
            this.rdbHd_Tu_In.UnChecked = true;
            this.rdbHd_Tu_In.UseVisualStyleBackColor = true;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.rdbHd_DT_PDF);
            this.gbIn_Tien.Controls.Add(this.rdbInvoice);
            this.gbIn_Tien.Controls.Add(this.rdbPhieu_Xuat);
            this.gbIn_Tien.Controls.Add(this.rdbHd_Dt_Cd);
            this.gbIn_Tien.Controls.Add(this.rdbHd_DT);
            this.gbIn_Tien.Controls.Add(this.rdbHd_Tu_In);
            this.gbIn_Tien.Controls.Add(this.rdbHd_Dat_In);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(459, 107);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // rdbHd_DT_PDF
            // 
            this.rdbHd_DT_PDF.AutoSize = true;
            this.rdbHd_DT_PDF.Checked = true;
            this.rdbHd_DT_PDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbHd_DT_PDF.Location = new System.Drawing.Point(233, 53);
            this.rdbHd_DT_PDF.Name = "rdbHd_DT_PDF";
            this.rdbHd_DT_PDF.Size = new System.Drawing.Size(126, 17);
            this.rdbHd_DT_PDF.TabIndex = 4;
            this.rdbHd_DT_PDF.TabStop = true;
            this.rdbHd_DT_PDF.Tag = "";
            this.rdbHd_DT_PDF.Text = "Hóa đơn điện tử PDF";
            this.rdbHd_DT_PDF.UnChecked = false;
            this.rdbHd_DT_PDF.UseVisualStyleBackColor = true;
            // 
            // rdbInvoice
            // 
            this.rdbInvoice.AutoSize = true;
            this.rdbInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbInvoice.Location = new System.Drawing.Point(111, 54);
            this.rdbInvoice.Name = "rdbInvoice";
            this.rdbInvoice.Size = new System.Drawing.Size(116, 17);
            this.rdbInvoice.TabIndex = 3;
            this.rdbInvoice.Tag = "";
            this.rdbInvoice.Text = "Commercial Invoice";
            this.rdbInvoice.UnChecked = true;
            this.rdbInvoice.UseVisualStyleBackColor = true;
            // 
            // rdbPhieu_Xuat
            // 
            this.rdbPhieu_Xuat.AutoSize = true;
            this.rdbPhieu_Xuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPhieu_Xuat.Location = new System.Drawing.Point(111, 33);
            this.rdbPhieu_Xuat.Name = "rdbPhieu_Xuat";
            this.rdbPhieu_Xuat.Size = new System.Drawing.Size(85, 17);
            this.rdbPhieu_Xuat.TabIndex = 2;
            this.rdbPhieu_Xuat.Tag = "In_Phieu_Xuat";
            this.rdbPhieu_Xuat.Text = "In phiếu xuất";
            this.rdbPhieu_Xuat.UnChecked = true;
            this.rdbPhieu_Xuat.UseVisualStyleBackColor = true;
            // 
            // rdbHd_Dt_Cd
            // 
            this.rdbHd_Dt_Cd.AutoSize = true;
            this.rdbHd_Dt_Cd.Checked = true;
            this.rdbHd_Dt_Cd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbHd_Dt_Cd.Location = new System.Drawing.Point(233, 75);
            this.rdbHd_Dt_Cd.Name = "rdbHd_Dt_Cd";
            this.rdbHd_Dt_Cd.Size = new System.Drawing.Size(158, 17);
            this.rdbHd_Dt_Cd.TabIndex = 0;
            this.rdbHd_Dt_Cd.TabStop = true;
            this.rdbHd_Dt_Cd.Tag = "";
            this.rdbHd_Dt_Cd.Text = "Hóa đơn điện tử chuyển đổi";
            this.rdbHd_Dt_Cd.UnChecked = false;
            this.rdbHd_Dt_Cd.UseVisualStyleBackColor = true;
            // 
            // rdbHd_DT
            // 
            this.rdbHd_DT.AutoSize = true;
            this.rdbHd_DT.Checked = true;
            this.rdbHd_DT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbHd_DT.Location = new System.Drawing.Point(112, 75);
            this.rdbHd_DT.Name = "rdbHd_DT";
            this.rdbHd_DT.Size = new System.Drawing.Size(102, 17);
            this.rdbHd_DT.TabIndex = 0;
            this.rdbHd_DT.TabStop = true;
            this.rdbHd_DT.Tag = "";
            this.rdbHd_DT.Text = "Hóa đơn điện tử";
            this.rdbHd_DT.UnChecked = false;
            this.rdbHd_DT.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.rdbTien_Nt);
            this.groupBox2.Controls.Add(this.rdbTien_VND);
            this.groupBox2.Location = new System.Drawing.Point(21, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 43);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "In_Tien";
            this.groupBox2.Text = "Chọn loại tiền in";
            // 
            // rdbTien_Nt
            // 
            this.rdbTien_Nt.AutoSize = true;
            this.rdbTien_Nt.Location = new System.Drawing.Point(145, 19);
            this.rdbTien_Nt.Name = "rdbTien_Nt";
            this.rdbTien_Nt.Size = new System.Drawing.Size(60, 17);
            this.rdbTien_Nt.TabIndex = 1;
            this.rdbTien_Nt.Tag = "USD";
            this.rdbTien_Nt.Text = "Tiền Nt";
            this.rdbTien_Nt.UnChecked = true;
            this.rdbTien_Nt.UseVisualStyleBackColor = true;
            // 
            // rdbTien_VND
            // 
            this.rdbTien_VND.AutoSize = true;
            this.rdbTien_VND.Checked = true;
            this.rdbTien_VND.Location = new System.Drawing.Point(52, 20);
            this.rdbTien_VND.Name = "rdbTien_VND";
            this.rdbTien_VND.Size = new System.Drawing.Size(72, 17);
            this.rdbTien_VND.TabIndex = 0;
            this.rdbTien_VND.TabStop = true;
            this.rdbTien_VND.Tag = "Tien_VND";
            this.rdbTien_VND.Text = "Tiền VND";
            this.rdbTien_VND.UnChecked = false;
            this.rdbTien_VND.UseVisualStyleBackColor = true;
            // 
            // txtTk_Nh_B
            // 
            this.txtTk_Nh_B.AutoDropDown = null;
            this.txtTk_Nh_B.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTk_Nh_B.Location = new System.Drawing.Point(132, 211);
            this.txtTk_Nh_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_Nh_B.Name = "txtTk_Nh_B";
            this.txtTk_Nh_B.Size = new System.Drawing.Size(196, 20);
            this.txtTk_Nh_B.TabIndex = 6;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel5.Location = new System.Drawing.Point(41, 214);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(67, 13);
            this.rsLabel5.TabIndex = 17;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Số tài khoản";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_DtGtGt
            // 
            this.txtTen_DtGtGt.AutoDropDown = null;
            this.txtTen_DtGtGt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_DtGtGt.Location = new System.Drawing.Point(132, 145);
            this.txtTen_DtGtGt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_DtGtGt.Name = "txtTen_DtGtGt";
            this.txtTen_DtGtGt.ReadOnly = true;
            this.txtTen_DtGtGt.Size = new System.Drawing.Size(283, 20);
            this.txtTen_DtGtGt.TabIndex = 3;
            this.txtTen_DtGtGt.TabStop = false;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel1.Location = new System.Drawing.Point(41, 148);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(59, 13);
            this.rsLabel1.TabIndex = 19;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Tên đơn vị";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDia_Chi
            // 
            this.txtDia_Chi.AutoDropDown = null;
            this.txtDia_Chi.Location = new System.Drawing.Point(132, 167);
            this.txtDia_Chi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDia_Chi.MaxLength = 200;
            this.txtDia_Chi.Name = "txtDia_Chi";
            this.txtDia_Chi.ReadOnly = true;
            this.txtDia_Chi.Size = new System.Drawing.Size(283, 20);
            this.txtDia_Chi.TabIndex = 4;
            this.txtDia_Chi.TabStop = false;
            // 
            // lblDia_Chi
            // 
            this.lblDia_Chi.AutoEllipsis = true;
            this.lblDia_Chi.AutoSize = true;
            this.lblDia_Chi.Location = new System.Drawing.Point(41, 170);
            this.lblDia_Chi.Name = "lblDia_Chi";
            this.lblDia_Chi.Size = new System.Drawing.Size(40, 13);
            this.lblDia_Chi.TabIndex = 66;
            this.lblDia_Chi.Tag = "Dia_Chi";
            this.lblDia_Chi.Text = "Địa chỉ";
            this.lblDia_Chi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOng_Ba
            // 
            this.txtOng_Ba.AutoDropDown = null;
            this.txtOng_Ba.Location = new System.Drawing.Point(132, 123);
            this.txtOng_Ba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtOng_Ba.MaxLength = 100;
            this.txtOng_Ba.Name = "txtOng_Ba";
            this.txtOng_Ba.ReadOnly = true;
            this.txtOng_Ba.Size = new System.Drawing.Size(283, 20);
            this.txtOng_Ba.TabIndex = 2;
            this.txtOng_Ba.TabStop = false;
            // 
            // lblOng_Ba
            // 
            this.lblOng_Ba.AutoEllipsis = true;
            this.lblOng_Ba.AutoSize = true;
            this.lblOng_Ba.Location = new System.Drawing.Point(41, 126);
            this.lblOng_Ba.Name = "lblOng_Ba";
            this.lblOng_Ba.Size = new System.Drawing.Size(42, 13);
            this.lblOng_Ba.TabIndex = 65;
            this.lblOng_Ba.Tag = "Ong_Ba";
            this.lblOng_Ba.Text = "Ông bà";
            this.lblOng_Ba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_So_Thue
            // 
            this.txtMa_So_Thue.AutoDropDown = null;
            this.txtMa_So_Thue.Location = new System.Drawing.Point(132, 189);
            this.txtMa_So_Thue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_So_Thue.MaxLength = 20;
            this.txtMa_So_Thue.Name = "txtMa_So_Thue";
            this.txtMa_So_Thue.ReadOnly = true;
            this.txtMa_So_Thue.Size = new System.Drawing.Size(196, 20);
            this.txtMa_So_Thue.TabIndex = 5;
            this.txtMa_So_Thue.TabStop = false;
            // 
            // lblMa_So_Thue
            // 
            this.lblMa_So_Thue.AutoEllipsis = true;
            this.lblMa_So_Thue.AutoSize = true;
            this.lblMa_So_Thue.Location = new System.Drawing.Point(41, 192);
            this.lblMa_So_Thue.Name = "lblMa_So_Thue";
            this.lblMa_So_Thue.Size = new System.Drawing.Size(60, 13);
            this.lblMa_So_Thue.TabIndex = 128;
            this.lblMa_So_Thue.Tag = "Ma_So_Thue";
            this.lblMa_So_Thue.Text = "Mã số thuế";
            this.lblMa_So_Thue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel2.Location = new System.Drawing.Point(41, 236);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(60, 13);
            this.rsLabel2.TabIndex = 17;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Ngân hàng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_NH_B
            // 
            this.txtTen_NH_B.AutoDropDown = null;
            this.txtTen_NH_B.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_NH_B.Location = new System.Drawing.Point(132, 233);
            this.txtTen_NH_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_NH_B.Name = "txtTen_NH_B";
            this.txtTen_NH_B.Size = new System.Drawing.Size(325, 20);
            this.txtTen_NH_B.TabIndex = 7;
            // 
            // txtTen_Kt
            // 
            this.txtTen_Kt.AutoDropDown = null;
            this.txtTen_Kt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_Kt.Location = new System.Drawing.Point(132, 277);
            this.txtTen_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Kt.Name = "txtTen_Kt";
            this.txtTen_Kt.Size = new System.Drawing.Size(196, 20);
            this.txtTen_Kt.TabIndex = 9;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel3.Location = new System.Drawing.Point(41, 280);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(77, 13);
            this.rsLabel3.TabIndex = 132;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Phòng kế toán";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Kd
            // 
            this.txtTen_Kd.AutoDropDown = null;
            this.txtTen_Kd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_Kd.Location = new System.Drawing.Point(132, 255);
            this.txtTen_Kd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Kd.Name = "txtTen_Kd";
            this.txtTen_Kd.Size = new System.Drawing.Size(196, 20);
            this.txtTen_Kd.TabIndex = 8;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel4.Location = new System.Drawing.Point(41, 258);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(94, 13);
            this.rsLabel4.TabIndex = 131;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Phòng kinh doanh";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmIn_Ct_HD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 401);
            this.Controls.Add(this.txtTen_Kt);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtTen_Kd);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.txtMa_So_Thue);
            this.Controls.Add(this.lblMa_So_Thue);
            this.Controls.Add(this.txtDia_Chi);
            this.Controls.Add(this.lblDia_Chi);
            this.Controls.Add(this.txtOng_Ba);
            this.Controls.Add(this.lblOng_Ba);
            this.Controls.Add(this.txtTen_DtGtGt);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtTen_NH_B);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtTk_Nh_B);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_HD";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        public RosySystem.Control.rsRadioButton rdbHd_Tu_In;
		public RosySystem.Control.rsRadioButton rdbHd_Dat_In;
        public System.Windows.Forms.GroupBox gbIn_Tien;
		public RosySystem.Control.rsRadioButton rdbPhieu_Xuat;
        public System.Windows.Forms.GroupBox groupBox2;
        public RosySystem.Control.rsRadioButton rdbTien_Nt;
        public RosySystem.Control.rsRadioButton rdbTien_VND;
		private RosySystem.Control.rsTextBox txtTk_Nh_B;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsTextBox txtTen_DtGtGt;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtDia_Chi;
		private RosySystem.Control.rsLabel lblDia_Chi;
		private RosySystem.Control.rsTextBox txtOng_Ba;
		private RosySystem.Control.rsLabel lblOng_Ba;
		private RosySystem.Control.rsTextBox txtMa_So_Thue;
		private RosySystem.Control.rsLabel lblMa_So_Thue;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBox txtTen_NH_B;
        public RosySystem.Control.rsRadioButton rdbInvoice;
        private RosySystem.Control.rsTextBox txtTen_Kt;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtTen_Kd;
        private RosySystem.Control.rsLabel rsLabel4;
        public RosySystem.Control.rsRadioButton rdbHd_Dt_Cd;
        public RosySystem.Control.rsRadioButton rdbHd_DT;
        public RosySystem.Control.rsRadioButton rdbHd_DT_PDF;
	}
}