namespace RosyModule
{
	partial class frmIn_Ct_SO
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
            this.rdbLXH = new RosySystem.Control.rsRadioButton();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbLXH_GH = new RosySystem.Control.rsRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbTien_Nt = new RosySystem.Control.rsRadioButton();
            this.rdbTien_VND = new RosySystem.Control.rsRadioButton();
            this.rsRadioButton1 = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbLXH
            // 
            this.rdbLXH.AutoSize = true;
            this.rdbLXH.Checked = true;
            this.rdbLXH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbLXH.Location = new System.Drawing.Point(148, 20);
            this.rdbLXH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbLXH.Name = "rdbLXH";
            this.rdbLXH.Size = new System.Drawing.Size(196, 21);
            this.rdbLXH.TabIndex = 0;
            this.rdbLXH.TabStop = true;
            this.rdbLXH.Tag = "";
            this.rdbLXH.Text = "In LXH ra hóa đơn / ký gửi ";
            this.rdbLXH.UnChecked = false;
            this.rdbLXH.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(423, 183);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(241, 55);
            this.btgAccept.TabIndex = 10;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.rsRadioButton1);
            this.gbIn_Tien.Controls.Add(this.rdbLXH_GH);
            this.gbIn_Tien.Controls.Add(this.rdbLXH);
            this.gbIn_Tien.Location = new System.Drawing.Point(28, 15);
            this.gbIn_Tien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbIn_Tien.Size = new System.Drawing.Size(636, 161);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // rdbLXH_GH
            // 
            this.rdbLXH_GH.AutoSize = true;
            this.rdbLXH_GH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbLXH_GH.Location = new System.Drawing.Point(148, 48);
            this.rdbLXH_GH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbLXH_GH.Name = "rdbLXH_GH";
            this.rdbLXH_GH.Size = new System.Drawing.Size(245, 21);
            this.rdbLXH_GH.TabIndex = 3;
            this.rdbLXH_GH.Tag = "";
            this.rdbLXH_GH.Text = "In LXH tại công ty CP, kho khu vực";
            this.rdbLXH_GH.UnChecked = true;
            this.rdbLXH_GH.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.rdbTien_Nt);
            this.groupBox2.Controls.Add(this.rdbTien_VND);
            this.groupBox2.Location = new System.Drawing.Point(31, 183);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(303, 53);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "In_Tien";
            this.groupBox2.Text = "Chọn loại tiền in";
            // 
            // rdbTien_Nt
            // 
            this.rdbTien_Nt.AutoSize = true;
            this.rdbTien_Nt.Location = new System.Drawing.Point(193, 23);
            this.rdbTien_Nt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbTien_Nt.Name = "rdbTien_Nt";
            this.rdbTien_Nt.Size = new System.Drawing.Size(75, 21);
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
            this.rdbTien_VND.Location = new System.Drawing.Point(69, 25);
            this.rdbTien_VND.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbTien_VND.Name = "rdbTien_VND";
            this.rdbTien_VND.Size = new System.Drawing.Size(90, 21);
            this.rdbTien_VND.TabIndex = 0;
            this.rdbTien_VND.TabStop = true;
            this.rdbTien_VND.Tag = "Tien_VND";
            this.rdbTien_VND.Text = "Tiền VND";
            this.rdbTien_VND.UnChecked = false;
            this.rdbTien_VND.UseVisualStyleBackColor = true;
            // 
            // rsRadioButton1
            // 
            this.rsRadioButton1.AutoSize = true;
            this.rsRadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rsRadioButton1.Location = new System.Drawing.Point(148, 77);
            this.rsRadioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.rsRadioButton1.Name = "rsRadioButton1";
            this.rsRadioButton1.Size = new System.Drawing.Size(318, 21);
            this.rsRadioButton1.TabIndex = 4;
            this.rsRadioButton1.Tag = "";
            this.rsRadioButton1.Text = "In LXH gửi kho của công ty CP tại kho khu vực";
            this.rsRadioButton1.UnChecked = true;
            this.rsRadioButton1.UseVisualStyleBackColor = true;
            // 
            // frmIn_Ct_SO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 254);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmIn_Ct_SO";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsRadioButton rdbLXH;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public System.Windows.Forms.GroupBox groupBox2;
        public RosySystem.Control.rsRadioButton rdbTien_Nt;
		public RosySystem.Control.rsRadioButton rdbTien_VND;
        public RosySystem.Control.rsRadioButton rdbLXH_GH;
        public RosySystem.Control.rsRadioButton rsRadioButton1;
	}
}