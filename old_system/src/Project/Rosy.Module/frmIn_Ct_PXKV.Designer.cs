namespace RosyModule
{
	partial class frmIn_Ct_PxKv
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
            this.txtLien = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rdbPhieu_Xuat = new RosySystem.Control.rsRadioButton();
            this.rdbPx_BBXN2 = new RosySystem.Control.rsRadioButton();
            this.rdbPx_BBXN3 = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(159, 199);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.txtLien);
            this.gbIn_Tien.Controls.Add(this.rsLabel5);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 111);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(189, 61);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn liên in";
            // 
            // txtLien
            // 
            this.txtLien.AutoDropDown = null;
            this.txtLien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLien.Location = new System.Drawing.Point(90, 25);
            this.txtLien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLien.Name = "txtLien";
            this.txtLien.Size = new System.Drawing.Size(78, 20);
            this.txtLien.TabIndex = 18;
            this.txtLien.Text = "1,2,3";
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel5.Location = new System.Drawing.Point(35, 28);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(50, 13);
            this.rsLabel5.TabIndex = 19;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Số liên in";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbPhieu_Xuat
            // 
            this.rdbPhieu_Xuat.AutoSize = true;
            this.rdbPhieu_Xuat.Checked = true;
            this.rdbPhieu_Xuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPhieu_Xuat.Location = new System.Drawing.Point(21, 26);
            this.rdbPhieu_Xuat.Name = "rdbPhieu_Xuat";
            this.rdbPhieu_Xuat.Size = new System.Drawing.Size(106, 17);
            this.rdbPhieu_Xuat.TabIndex = 12;
            this.rdbPhieu_Xuat.TabStop = true;
            this.rdbPhieu_Xuat.Tag = "";
            this.rdbPhieu_Xuat.Text = "In phiếu xuất kho";
            this.rdbPhieu_Xuat.UnChecked = false;
            this.rdbPhieu_Xuat.UseVisualStyleBackColor = true;
            // 
            // rdbPx_BBXN2
            // 
            this.rdbPx_BBXN2.AutoSize = true;
            this.rdbPx_BBXN2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPx_BBXN2.Location = new System.Drawing.Point(21, 54);
            this.rdbPx_BBXN2.Name = "rdbPx_BBXN2";
            this.rdbPx_BBXN2.Size = new System.Drawing.Size(157, 17);
            this.rdbPx_BBXN2.TabIndex = 11;
            this.rdbPx_BBXN2.Tag = "";
            this.rdbPx_BBXN2.Text = "In biên bản giao nhận 2 bên";
            this.rdbPx_BBXN2.UnChecked = true;
            this.rdbPx_BBXN2.UseVisualStyleBackColor = true;
            // 
            // rdbPx_BBXN3
            // 
            this.rdbPx_BBXN3.AutoSize = true;
            this.rdbPx_BBXN3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPx_BBXN3.Location = new System.Drawing.Point(21, 82);
            this.rdbPx_BBXN3.Name = "rdbPx_BBXN3";
            this.rdbPx_BBXN3.Size = new System.Drawing.Size(157, 17);
            this.rdbPx_BBXN3.TabIndex = 13;
            this.rdbPx_BBXN3.Tag = "";
            this.rdbPx_BBXN3.Text = "In biên bản giao nhận 3 bên";
            this.rdbPx_BBXN3.UnChecked = true;
            this.rdbPx_BBXN3.UseVisualStyleBackColor = true;
            // 
            // frmIn_Ct_PxKv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 256);
            this.Controls.Add(this.rdbPx_BBXN3);
            this.Controls.Add(this.rdbPhieu_Xuat);
            this.Controls.Add(this.rdbPx_BBXN2);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_PxKv";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        private RosySystem.Control.rsLabel rsLabel5;
        public RosySystem.Control.rsTextBox txtLien;
        public RosySystem.Control.rsRadioButton rdbPhieu_Xuat;
        public RosySystem.Control.rsRadioButton rdbPx_BBXN2;
        public RosySystem.Control.rsRadioButton rdbPx_BBXN3;
    }
}