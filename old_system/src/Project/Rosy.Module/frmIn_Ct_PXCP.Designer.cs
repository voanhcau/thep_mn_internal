namespace RosyModule
{
    partial class frmIn_Ct_PXCP
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
            this.rdbBBXN_CP_TMN = new RosySystem.Control.rsRadioButton();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.txtLien = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rdbBBXN_TMN_KH = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbBBXN_CP_TMN
            // 
            this.rdbBBXN_CP_TMN.AutoSize = true;
            this.rdbBBXN_CP_TMN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbBBXN_CP_TMN.Location = new System.Drawing.Point(35, 63);
            this.rdbBBXN_CP_TMN.Name = "rdbBBXN_CP_TMN";
            this.rdbBBXN_CP_TMN.Size = new System.Drawing.Size(167, 17);
            this.rdbBBXN_CP_TMN.TabIndex = 0;
            this.rdbBBXN_CP_TMN.Tag = "";
            this.rdbBBXN_CP_TMN.Text = "Bảng kê tiêu thụ hàng gửi kho";
            this.rdbBBXN_CP_TMN.UnChecked = true;
            this.rdbBBXN_CP_TMN.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(125, 167);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.txtLien);
            this.gbIn_Tien.Controls.Add(this.rsLabel5);
            this.gbIn_Tien.Controls.Add(this.rdbBBXN_TMN_KH);
            this.gbIn_Tien.Controls.Add(this.rdbBBXN_CP_TMN);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(259, 136);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // txtLien
            // 
            this.txtLien.AutoDropDown = null;
            this.txtLien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLien.Location = new System.Drawing.Point(94, 98);
            this.txtLien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLien.Name = "txtLien";
            this.txtLien.Size = new System.Drawing.Size(78, 20);
            this.txtLien.TabIndex = 20;
            this.txtLien.Text = "1,2";
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel5.Location = new System.Drawing.Point(39, 101);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(50, 13);
            this.rsLabel5.TabIndex = 21;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Số liên in";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbBBXN_TMN_KH
            // 
            this.rdbBBXN_TMN_KH.AutoSize = true;
            this.rdbBBXN_TMN_KH.Checked = true;
            this.rdbBBXN_TMN_KH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbBBXN_TMN_KH.Location = new System.Drawing.Point(35, 28);
            this.rdbBBXN_TMN_KH.Name = "rdbBBXN_TMN_KH";
            this.rdbBBXN_TMN_KH.Size = new System.Drawing.Size(175, 17);
            this.rdbBBXN_TMN_KH.TabIndex = 2;
            this.rdbBBXN_TMN_KH.TabStop = true;
            this.rdbBBXN_TMN_KH.Tag = "";
            this.rdbBBXN_TMN_KH.Text = "In biên bản giao nhận TMN -KH";
            this.rdbBBXN_TMN_KH.UnChecked = false;
            this.rdbBBXN_TMN_KH.UseVisualStyleBackColor = true;
            // 
            // frmIn_Ct_PXCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 224);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_PXCP";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsRadioButton rdbBBXN_CP_TMN;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbBBXN_TMN_KH;
        public RosySystem.Control.rsTextBox txtLien;
        private RosySystem.Control.rsLabel rsLabel5;
	}
}