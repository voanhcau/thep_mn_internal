namespace RosyModule
{
    partial class frmIn_Ct_DNX
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
            this.rdbPx_BBM = new RosySystem.Control.rsRadioButton();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbPhieu_Xuat = new RosySystem.Control.rsRadioButton();
            this.rdbPX_Barcode = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbPx_BBM
            // 
            this.rdbPx_BBM.AutoSize = true;
            this.rdbPx_BBM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPx_BBM.Location = new System.Drawing.Point(70, 54);
            this.rdbPx_BBM.Name = "rdbPx_BBM";
            this.rdbPx_BBM.Size = new System.Drawing.Size(115, 17);
            this.rdbPx_BBM.TabIndex = 0;
            this.rdbPx_BBM.Tag = "";
            this.rdbPx_BBM.Text = "In giấy mượn VTPT";
            this.rdbPx_BBM.UnChecked = true;
            this.rdbPx_BBM.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(154, 146);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.rdbPhieu_Xuat);
            this.gbIn_Tien.Controls.Add(this.rdbPX_Barcode);
            this.gbIn_Tien.Controls.Add(this.rdbPx_BBM);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(304, 128);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // rdbPhieu_Xuat
            // 
            this.rdbPhieu_Xuat.AutoSize = true;
            this.rdbPhieu_Xuat.Checked = true;
            this.rdbPhieu_Xuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPhieu_Xuat.Location = new System.Drawing.Point(70, 19);
            this.rdbPhieu_Xuat.Name = "rdbPhieu_Xuat";
            this.rdbPhieu_Xuat.Size = new System.Drawing.Size(127, 17);
            this.rdbPhieu_Xuat.TabIndex = 2;
            this.rdbPhieu_Xuat.TabStop = true;
            this.rdbPhieu_Xuat.Tag = "";
            this.rdbPhieu_Xuat.Text = "In phiếu đề nghị xuất ";
            this.rdbPhieu_Xuat.UnChecked = false;
            this.rdbPhieu_Xuat.UseVisualStyleBackColor = true;
            // 
            // rdbPX_Barcode
            // 
            this.rdbPX_Barcode.AutoSize = true;
            this.rdbPX_Barcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPX_Barcode.Location = new System.Drawing.Point(70, 89);
            this.rdbPX_Barcode.Name = "rdbPX_Barcode";
            this.rdbPX_Barcode.Size = new System.Drawing.Size(127, 17);
            this.rdbPX_Barcode.TabIndex = 0;
            this.rdbPX_Barcode.Tag = "";
            this.rdbPX_Barcode.Text = "In phiếu xuất barcode";
            this.rdbPX_Barcode.UnChecked = true;
            this.rdbPX_Barcode.UseVisualStyleBackColor = true;
            // 
            // frmIn_Ct_DNX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 203);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_DNX";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsRadioButton rdbPx_BBM;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbPhieu_Xuat;
        public RosySystem.Control.rsRadioButton rdbPX_Barcode;
	}
}