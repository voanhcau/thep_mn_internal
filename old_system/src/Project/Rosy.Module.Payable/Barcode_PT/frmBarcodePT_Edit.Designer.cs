namespace RosyModule.Payable
{
    partial class frmBarcodePT_Edit
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
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabelName();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtBarcode = new RosySystem.Control.rsTextBox();
            this.numSo_Lan_In = new RosySystem.Control.rsTextBoxNumber();
            this.numSo_Luong = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.lbtTen_VTri = new RosySystem.Control.rsLabelName();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_VTri = new RosySystem.Control.rsTextBox();
            this.lbtTen_Kho = new RosySystem.Control.rsLabelName();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtMa_Kho = new RosySystem.Control.rsTextBox();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Nhap = new RosySystem.Control.rsDateTime();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(427, 268);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(245, 58);
            this.btgAccept.TabIndex = 7;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.Location = new System.Drawing.Point(227, 44);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(132, 22);
            this.txtMa_Vt.TabIndex = 1;
            this.txtMa_Vt.Tag = "Ma_Vt";
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Location = new System.Drawing.Point(47, 48);
            this.rsLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(66, 17);
            this.rsLabel13.TabIndex = 22;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "Mã vật tư";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(373, 48);
            this.lbtTen_Vt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(54, 17);
            this.lbtTen_Vt.TabIndex = 7;
            this.lbtTen_Vt.Tag = "Ten_Vt";
            this.lbtTen_Vt.Text = "Ten_Vt";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(47, 21);
            this.rsLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(61, 17);
            this.rsLabel5.TabIndex = 20;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Barcode";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoDropDown = null;
            this.txtBarcode.Location = new System.Drawing.Point(227, 16);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(209, 22);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.Tag = "";
            // 
            // numSo_Lan_In
            // 
            this.numSo_Lan_In.AutoDropDown = null;
            this.numSo_Lan_In.bFormat = true;
            this.numSo_Lan_In.Location = new System.Drawing.Point(227, 180);
            this.numSo_Lan_In.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.numSo_Lan_In.Name = "numSo_Lan_In";
            this.numSo_Lan_In.Scale = 2;
            this.numSo_Lan_In.Size = new System.Drawing.Size(93, 22);
            this.numSo_Lan_In.TabIndex = 6;
            this.numSo_Lan_In.Tag = "Gia";
            this.numSo_Lan_In.Text = "0.00";
            this.numSo_Lan_In.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Lan_In.Value = 0D;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.AutoDropDown = null;
            this.numSo_Luong.bFormat = true;
            this.numSo_Luong.Location = new System.Drawing.Point(227, 156);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Scale = 2;
            this.numSo_Luong.Size = new System.Drawing.Size(93, 22);
            this.numSo_Luong.TabIndex = 5;
            this.numSo_Luong.Tag = "Gia";
            this.numSo_Luong.Text = "0.00";
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong.Value = 0D;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(47, 183);
            this.rsLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(123, 17);
            this.rsLabel4.TabIndex = 23;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Số tem in barcode";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(47, 160);
            this.rsLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(64, 17);
            this.rsLabel3.TabIndex = 24;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Số lượng";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_VTri
            // 
            this.lbtTen_VTri.AutoSize = true;
            this.lbtTen_VTri.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_VTri.Location = new System.Drawing.Point(373, 76);
            this.lbtTen_VTri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_VTri.Name = "lbtTen_VTri";
            this.lbtTen_VTri.Size = new System.Drawing.Size(67, 17);
            this.lbtTen_VTri.TabIndex = 7;
            this.lbtTen_VTri.Tag = "";
            this.lbtTen_VTri.Text = "Ten_VTri";
            this.lbtTen_VTri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(47, 76);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(57, 17);
            this.rsLabel1.TabIndex = 22;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mã vị trí";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_VTri
            // 
            this.txtMa_VTri.AutoDropDown = null;
            this.txtMa_VTri.Location = new System.Drawing.Point(227, 73);
            this.txtMa_VTri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.txtMa_VTri.Name = "txtMa_VTri";
            this.txtMa_VTri.Size = new System.Drawing.Size(132, 22);
            this.txtMa_VTri.TabIndex = 2;
            this.txtMa_VTri.Tag = "Ma_Vt";
            // 
            // lbtTen_Kho
            // 
            this.lbtTen_Kho.AutoSize = true;
            this.lbtTen_Kho.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Kho.Location = new System.Drawing.Point(373, 105);
            this.lbtTen_Kho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_Kho.Name = "lbtTen_Kho";
            this.lbtTen_Kho.Size = new System.Drawing.Size(66, 17);
            this.lbtTen_Kho.TabIndex = 7;
            this.lbtTen_Kho.Tag = "";
            this.lbtTen_Kho.Text = "Ten_Kho";
            this.lbtTen_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(47, 105);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(54, 17);
            this.rsLabel2.TabIndex = 22;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Mã kho";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Kho
            // 
            this.txtMa_Kho.AutoDropDown = null;
            this.txtMa_Kho.Location = new System.Drawing.Point(227, 101);
            this.txtMa_Kho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.txtMa_Kho.Name = "txtMa_Kho";
            this.txtMa_Kho.Size = new System.Drawing.Size(132, 22);
            this.txtMa_Kho.TabIndex = 3;
            this.txtMa_Kho.Tag = "Ma_Vt";
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(47, 133);
            this.lblNgay_Ct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(77, 17);
            this.lblNgay_Ct.TabIndex = 25;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Ngày nhập";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Nhap
            // 
            this.dteNgay_Nhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteNgay_Nhap.bAllowEmpty = false;
            this.dteNgay_Nhap.bSelectOnFocus = false;
            this.dteNgay_Nhap.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Nhap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Nhap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Nhap.Location = new System.Drawing.Point(227, 129);
            this.dteNgay_Nhap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Nhap.Mask = "00/00/0000";
            this.dteNgay_Nhap.Name = "dteNgay_Nhap";
            this.dteNgay_Nhap.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Nhap.TabIndex = 4;
            // 
            // frmBarcodePT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 336);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.dteNgay_Nhap);
            this.Controls.Add(this.numSo_Lan_In);
            this.Controls.Add(this.numSo_Luong);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtMa_Kho);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtMa_VTri);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.rsLabel13);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lbtTen_Kho);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.lbtTen_VTri);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lbtTen_Vt);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmBarcodePT_Edit";
            this.Tag = "frmBarcodePT_Edit, ESC";
            this.Text = "frmBarcodePT_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtMa_Vt;
        private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsLabelName lbtTen_Vt;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBox txtBarcode;
        private RosySystem.Control.rsTextBoxNumber numSo_Lan_In;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabelName lbtTen_VTri;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtMa_VTri;
        private RosySystem.Control.rsLabelName lbtTen_Kho;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtMa_Kho;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Nhap;
	}
}