namespace RosyModule.Receivable
{
	partial class frmCKSLCT_Edit
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
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.lbMa_Vt = new RosySystem.Control.rsLabel();
            this.numGia = new RosySystem.Control.rsTextBoxNumber();
            this.lblGia = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabel();
            this.lblLoai_Nhom = new RosySystem.Control.rsLabel();
            this.txtSo_Qd_Ck = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.dteDen_Ngay = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteTu_Ngay = new RosySystem.Control.rsDateTime();
            this.numTu_Sl = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.numDen_Sl = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(299, 160);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 16;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(137, 49);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 1;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(23, 49);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbMa_Vt.TabIndex = 45;
            this.lbMa_Vt.Tag = "Ma_Vt";
            this.lbMa_Vt.Text = "Mã tài sản";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGia
            // 
            this.numGia.AutoDropDown = null;
            this.numGia.bFormat = true;
            this.numGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGia.Location = new System.Drawing.Point(137, 126);
            this.numGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numGia.Name = "numGia";
            this.numGia.Scale = 0;
            this.numGia.Size = new System.Drawing.Size(120, 20);
            this.numGia.TabIndex = 6;
            this.numGia.Text = "0";
            this.numGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia.Value = 0D;
            // 
            // lblGia
            // 
            this.lblGia.AutoEllipsis = true;
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.Location = new System.Drawing.Point(23, 133);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(90, 13);
            this.lblGia.TabIndex = 52;
            this.lblGia.Tag = "";
            this.lblGia.Text = "Giá chiết khấu";
            this.lblGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.Enabled = false;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(265, 52);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(75, 13);
            this.lbtTen_Vt.TabIndex = 2;
            this.lbtTen_Vt.Text = "Tên sản phẩm";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoai_Nhom
            // 
            this.lblLoai_Nhom.AutoEllipsis = true;
            this.lblLoai_Nhom.AutoSize = true;
            this.lblLoai_Nhom.Location = new System.Drawing.Point(23, 24);
            this.lblLoai_Nhom.Name = "lblLoai_Nhom";
            this.lblLoai_Nhom.Size = new System.Drawing.Size(92, 13);
            this.lblLoai_Nhom.TabIndex = 204;
            this.lblLoai_Nhom.Tag = "";
            this.lblLoai_Nhom.Text = "Số QĐ chiết khấu";
            this.lblLoai_Nhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Qd_Ck
            // 
            this.txtSo_Qd_Ck.AutoDropDown = null;
            this.txtSo_Qd_Ck.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Qd_Ck.Location = new System.Drawing.Point(137, 25);
            this.txtSo_Qd_Ck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Qd_Ck.MaxLength = 20;
            this.txtSo_Qd_Ck.Name = "txtSo_Qd_Ck";
            this.txtSo_Qd_Ck.ReadOnly = true;
            this.txtSo_Qd_Ck.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Qd_Ck.TabIndex = 203;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(270, 72);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(53, 13);
            this.rsLabel3.TabIndex = 208;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Đến ngày";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteDen_Ngay
            // 
            this.dteDen_Ngay.bAllowEmpty = true;
            this.dteDen_Ngay.bSelectOnFocus = true;
            this.dteDen_Ngay.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteDen_Ngay.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteDen_Ngay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteDen_Ngay.Location = new System.Drawing.Point(359, 72);
            this.dteDen_Ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteDen_Ngay.Mask = "00/00/0000";
            this.dteDen_Ngay.Name = "dteDen_Ngay";
            this.dteDen_Ngay.Size = new System.Drawing.Size(66, 20);
            this.dteDen_Ngay.TabIndex = 3;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay_Ct.Location = new System.Drawing.Point(23, 72);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct.TabIndex = 207;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Từ ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteTu_Ngay
            // 
            this.dteTu_Ngay.bAllowEmpty = true;
            this.dteTu_Ngay.bSelectOnFocus = true;
            this.dteTu_Ngay.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteTu_Ngay.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteTu_Ngay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteTu_Ngay.Location = new System.Drawing.Point(137, 72);
            this.dteTu_Ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteTu_Ngay.Mask = "00/00/0000";
            this.dteTu_Ngay.Name = "dteTu_Ngay";
            this.dteTu_Ngay.Size = new System.Drawing.Size(66, 20);
            this.dteTu_Ngay.TabIndex = 2;
            // 
            // numTu_Sl
            // 
            this.numTu_Sl.AutoDropDown = null;
            this.numTu_Sl.bFormat = true;
            this.numTu_Sl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTu_Sl.Location = new System.Drawing.Point(137, 95);
            this.numTu_Sl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTu_Sl.Name = "numTu_Sl";
            this.numTu_Sl.Scale = 0;
            this.numTu_Sl.Size = new System.Drawing.Size(120, 20);
            this.numTu_Sl.TabIndex = 4;
            this.numTu_Sl.Text = "0";
            this.numTu_Sl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTu_Sl.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(23, 101);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(81, 13);
            this.rsLabel1.TabIndex = 52;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Từ sản lượng";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numDen_Sl
            // 
            this.numDen_Sl.AutoDropDown = null;
            this.numDen_Sl.bFormat = true;
            this.numDen_Sl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDen_Sl.Location = new System.Drawing.Point(359, 95);
            this.numDen_Sl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numDen_Sl.Name = "numDen_Sl";
            this.numDen_Sl.Scale = 0;
            this.numDen_Sl.Size = new System.Drawing.Size(98, 20);
            this.numDen_Sl.TabIndex = 5;
            this.numDen_Sl.Text = "0";
            this.numDen_Sl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDen_Sl.Value = 0D;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(265, 102);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(89, 13);
            this.rsLabel2.TabIndex = 52;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Đến sản lượng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCKSLCT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 214);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.dteDen_Ngay);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.dteTu_Ngay);
            this.Controls.Add(this.lblLoai_Nhom);
            this.Controls.Add(this.txtSo_Qd_Ck);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.numDen_Sl);
            this.Controls.Add(this.numTu_Sl);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.lbMa_Vt);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmCKSLCT_Edit";
            this.Tag = "frmCtCkSl";
            this.Text = "Chi tiết chiết khấu";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtMa_Vt;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsTextBoxNumber numGia;
        private RosySystem.Control.rsLabel lblGia;
        private RosySystem.Control.rsLabel lbtTen_Vt;
        private RosySystem.Control.rsLabel lblLoai_Nhom;
        private RosySystem.Control.rsTextBox txtSo_Qd_Ck;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsDateTime dteDen_Ngay;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteTu_Ngay;
        private RosySystem.Control.rsTextBoxNumber numTu_Sl;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBoxNumber numDen_Sl;
        private RosySystem.Control.rsLabel rsLabel2;
	}
}