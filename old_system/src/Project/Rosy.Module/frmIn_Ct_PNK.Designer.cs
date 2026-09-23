namespace RosyModule
{
	partial class frmIn_Ct_PNK
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbTien_Nt = new RosySystem.Control.rsRadioButton();
            this.rdbTien_VND = new RosySystem.Control.rsRadioButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(59, 68);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbTien_Nt);
            this.groupBox2.Controls.Add(this.rdbTien_VND);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 43);
            this.groupBox2.TabIndex = 9;
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
            // frmIn_Ct_POCG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 125);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_POCG";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        public System.Windows.Forms.GroupBox groupBox2;
        public RosySystem.Control.rsRadioButton rdbTien_Nt;
		public RosySystem.Control.rsRadioButton rdbTien_VND;
	}
}