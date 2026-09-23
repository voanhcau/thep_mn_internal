namespace RosyModule.HRM
{
    partial class frmIn_TuyenDung
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
            this.rdbDSUV = new RosySystem.Control.rsRadioButton();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbBang_NCLD = new RosySystem.Control.rsRadioButton();
            this.rdbDSNV = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbDSUV
            // 
            this.rdbDSUV.AutoSize = true;
            this.rdbDSUV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbDSUV.Location = new System.Drawing.Point(70, 54);
            this.rdbDSUV.Name = "rdbDSUV";
            this.rdbDSUV.Size = new System.Drawing.Size(164, 17);
            this.rdbDSUV.TabIndex = 0;
            this.rdbDSUV.Tag = "";
            this.rdbDSUV.Text = "Danh sách ứng viên dự tuyển";
            this.rdbDSUV.UnChecked = true;
            this.rdbDSUV.UseVisualStyleBackColor = true;
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
            this.gbIn_Tien.Controls.Add(this.rdbBang_NCLD);
            this.gbIn_Tien.Controls.Add(this.rdbDSNV);
            this.gbIn_Tien.Controls.Add(this.rdbDSUV);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(304, 128);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // rdbBang_NCLD
            // 
            this.rdbBang_NCLD.AutoSize = true;
            this.rdbBang_NCLD.Checked = true;
            this.rdbBang_NCLD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbBang_NCLD.Location = new System.Drawing.Point(70, 19);
            this.rdbBang_NCLD.Name = "rdbBang_NCLD";
            this.rdbBang_NCLD.Size = new System.Drawing.Size(136, 17);
            this.rdbBang_NCLD.TabIndex = 2;
            this.rdbBang_NCLD.TabStop = true;
            this.rdbBang_NCLD.Tag = "";
            this.rdbBang_NCLD.Text = "Bảng nhu cầu lao động";
            this.rdbBang_NCLD.UnChecked = false;
            this.rdbBang_NCLD.UseVisualStyleBackColor = true;
            // 
            // rdbDSNV
            // 
            this.rdbDSNV.AutoSize = true;
            this.rdbDSNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbDSNV.Location = new System.Drawing.Point(70, 89);
            this.rdbDSNV.Name = "rdbDSNV";
            this.rdbDSNV.Size = new System.Drawing.Size(176, 17);
            this.rdbDSNV.TabIndex = 0;
            this.rdbDSNV.Tag = "";
            this.rdbDSNV.Text = "Danh sách ứng viên tuyển dụng";
            this.rdbDSNV.UnChecked = true;
            this.rdbDSNV.UseVisualStyleBackColor = true;
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
		public RosySystem.Control.rsRadioButton rdbDSUV;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbBang_NCLD;
        public RosySystem.Control.rsRadioButton rdbDSNV;
	}
}