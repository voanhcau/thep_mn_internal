namespace RosyModule
{
	partial class frmIn_Ct_PNPT
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
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbIn_Phieu = new RosySystem.Control.rsRadioButton();
            this.rdbIn_Barcode = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(313, 84);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 7;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.rdbIn_Phieu);
            this.gbIn_Tien.Controls.Add(this.rdbIn_Barcode);
            this.gbIn_Tien.Location = new System.Drawing.Point(27, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(458, 58);
            this.gbIn_Tien.TabIndex = 24;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // rdbIn_Phieu
            // 
            this.rdbIn_Phieu.AutoSize = true;
            this.rdbIn_Phieu.Checked = true;
            this.rdbIn_Phieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbIn_Phieu.Location = new System.Drawing.Point(111, 10);
            this.rdbIn_Phieu.Name = "rdbIn_Phieu";
            this.rdbIn_Phieu.Size = new System.Drawing.Size(89, 17);
            this.rdbIn_Phieu.TabIndex = 0;
            this.rdbIn_Phieu.TabStop = true;
            this.rdbIn_Phieu.Tag = "";
            this.rdbIn_Phieu.Text = "In phiếu nhập";
            this.rdbIn_Phieu.UnChecked = false;
            this.rdbIn_Phieu.UseVisualStyleBackColor = true;
            // 
            // rdbIn_Barcode
            // 
            this.rdbIn_Barcode.AutoSize = true;
            this.rdbIn_Barcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbIn_Barcode.Location = new System.Drawing.Point(111, 33);
            this.rdbIn_Barcode.Name = "rdbIn_Barcode";
            this.rdbIn_Barcode.Size = new System.Drawing.Size(75, 17);
            this.rdbIn_Barcode.TabIndex = 1;
            this.rdbIn_Barcode.Tag = "";
            this.rdbIn_Barcode.Text = "In barcode";
            this.rdbIn_Barcode.UnChecked = true;
            this.rdbIn_Barcode.UseVisualStyleBackColor = true;
            // 
            // frmIn_Ct_PNPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 131);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_PNPT";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbIn_Phieu;
        public RosySystem.Control.rsRadioButton rdbIn_Barcode;
	}
}