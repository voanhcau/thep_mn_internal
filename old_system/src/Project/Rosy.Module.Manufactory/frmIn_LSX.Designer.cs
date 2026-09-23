namespace RosyModule.Manufactory
{
    partial class frmIn_LSX
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
            this.rdbChiTiet = new RosySystem.Control.rsRadioButton();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbTong_Hop = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbChiTiet
            // 
            this.rdbChiTiet.AutoSize = true;
            this.rdbChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbChiTiet.Location = new System.Drawing.Point(70, 54);
            this.rdbChiTiet.Name = "rdbChiTiet";
            this.rdbChiTiet.Size = new System.Drawing.Size(94, 17);
            this.rdbChiTiet.TabIndex = 0;
            this.rdbChiTiet.Tag = "";
            this.rdbChiTiet.Text = "In Lệnh chi tiết";
            this.rdbChiTiet.UnChecked = true;
            this.rdbChiTiet.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(154, 119);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.rdbTong_Hop);
            this.gbIn_Tien.Controls.Add(this.rdbChiTiet);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 21);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(259, 80);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // rdbTong_Hop
            // 
            this.rdbTong_Hop.AutoSize = true;
            this.rdbTong_Hop.Checked = true;
            this.rdbTong_Hop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbTong_Hop.Location = new System.Drawing.Point(70, 19);
            this.rdbTong_Hop.Name = "rdbTong_Hop";
            this.rdbTong_Hop.Size = new System.Drawing.Size(105, 17);
            this.rdbTong_Hop.TabIndex = 2;
            this.rdbTong_Hop.TabStop = true;
            this.rdbTong_Hop.Tag = "";
            this.rdbTong_Hop.Text = "In Lệnh tổng hợp";
            this.rdbTong_Hop.UnChecked = false;
            this.rdbTong_Hop.UseVisualStyleBackColor = true;
            // 
            // frmIn_LSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 176);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_LSX";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsRadioButton rdbChiTiet;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbTong_Hop;
	}
}