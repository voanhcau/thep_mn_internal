namespace RosyPhuTung
{
    partial class frmDmBarcodePt_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmBarcodePt_Edit));
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.txtBarcode = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btSaveAndPrint = new RosySystem.Control.rsButton();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabelName();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct_Xuat = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct_Nhap = new RosySystem.Control.rsDateTime();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(276, 167);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 45);
            this.btgAccept.TabIndex = 19;
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoDropDown = null;
            this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(97, 20);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(272, 30);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(12, 23);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(68, 17);
            this.rsLabel1.TabIndex = 45;
            this.rsLabel1.Text = "Barcode";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSaveAndPrint
            // 
            this.btSaveAndPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveAndPrint.Image = ((System.Drawing.Image)(resources.GetObject("btSaveAndPrint.Image")));
            this.btSaveAndPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveAndPrint.Location = new System.Drawing.Point(184, 167);
            this.btSaveAndPrint.Name = "btSaveAndPrint";
            this.btSaveAndPrint.Size = new System.Drawing.Size(86, 43);
            this.btSaveAndPrint.TabIndex = 18;
            this.btSaveAndPrint.Text = "Lưu && In";
            this.btSaveAndPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSaveAndPrint.UseVisualStyleBackColor = true;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Enabled = false;
            this.txtMa_Vt.Location = new System.Drawing.Point(97, 53);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(124, 20);
            this.txtMa_Vt.TabIndex = 1;
            this.txtMa_Vt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel5.Location = new System.Drawing.Point(12, 50);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(75, 17);
            this.rsLabel5.TabIndex = 62;
            this.rsLabel5.Text = "Mã vật tư";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(226, 56);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(20, 13);
            this.lbtTen_Vt.TabIndex = 63;
            this.lbtTen_Vt.Text = "Ca";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(12, 108);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(80, 17);
            this.rsLabel2.TabIndex = 65;
            this.rsLabel2.Text = "Ngày xuất";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(12, 82);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(86, 17);
            this.rsLabel3.TabIndex = 64;
            this.rsLabel3.Text = "Ngày nhập";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct_Xuat
            // 
            this.dteNgay_Ct_Xuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteNgay_Ct_Xuat.bAllowEmpty = false;
            this.dteNgay_Ct_Xuat.bSelectOnFocus = false;
            this.dteNgay_Ct_Xuat.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct_Xuat.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct_Xuat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct_Xuat.Location = new System.Drawing.Point(97, 107);
            this.dteNgay_Ct_Xuat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct_Xuat.Mask = "00/00/0000";
            this.dteNgay_Ct_Xuat.Name = "dteNgay_Ct_Xuat";
            this.dteNgay_Ct_Xuat.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct_Xuat.TabIndex = 67;
            // 
            // dteNgay_Ct_Nhap
            // 
            this.dteNgay_Ct_Nhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteNgay_Ct_Nhap.bAllowEmpty = false;
            this.dteNgay_Ct_Nhap.bSelectOnFocus = false;
            this.dteNgay_Ct_Nhap.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct_Nhap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct_Nhap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct_Nhap.Location = new System.Drawing.Point(97, 79);
            this.dteNgay_Ct_Nhap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct_Nhap.Mask = "00/00/0000";
            this.dteNgay_Ct_Nhap.Name = "dteNgay_Ct_Nhap";
            this.dteNgay_Ct_Nhap.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct_Nhap.TabIndex = 68;
            // 
            // frmDmBarcodePt_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 224);
            this.Controls.Add(this.dteNgay_Ct_Nhap);
            this.Controls.Add(this.dteNgay_Ct_Xuat);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.btSaveAndPrint);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.btgAccept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDmBarcodePt_Edit";
            this.Tag = "frmDmBarcodePt,ESC";
            this.Text = "frmDmBarcodePt_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtBarcode;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsButton btSaveAndPrint;
		private RosySystem.Control.rsTextBox txtMa_Vt;
		private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsLabelName lbtTen_Vt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsDateTime dteNgay_Ct_Xuat;
        private RosySystem.Control.rsDateTime dteNgay_Ct_Nhap;
	}
}