namespace RosyModule.Receivable
{
	partial class frmIn_Ct_QDGia
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
            this.rdbCCK = new RosySystem.Control.rsRadioButton();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbKCK = new RosySystem.Control.rsRadioButton();
            this.txtSo_CTrinh = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(178, 101);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 11;
            // 
            // rdbCCK
            // 
            this.rdbCCK.AutoSize = true;
            this.rdbCCK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbCCK.Location = new System.Drawing.Point(23, 19);
            this.rdbCCK.Name = "rdbCCK";
            this.rdbCCK.Size = new System.Drawing.Size(90, 17);
            this.rdbCCK.TabIndex = 0;
            this.rdbCCK.Tag = "";
            this.rdbCCK.Text = "Có chiết khấu";
            this.rdbCCK.UnChecked = true;
            this.rdbCCK.UseVisualStyleBackColor = true;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.txtSo_CTrinh);
            this.gbIn_Tien.Controls.Add(this.rsLabel3);
            this.gbIn_Tien.Controls.Add(this.rdbKCK);
            this.gbIn_Tien.Controls.Add(this.rdbCCK);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(337, 84);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // rdbKCK
            // 
            this.rdbKCK.AutoSize = true;
            this.rdbKCK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbKCK.Location = new System.Drawing.Point(209, 19);
            this.rdbKCK.Name = "rdbKCK";
            this.rdbKCK.Size = new System.Drawing.Size(108, 17);
            this.rdbKCK.TabIndex = 2;
            this.rdbKCK.Tag = "";
            this.rdbKCK.Text = "Không chiết khấu";
            this.rdbKCK.UnChecked = true;
            this.rdbKCK.UseVisualStyleBackColor = true;
            // 
            // txtSo_CTrinh
            // 
            this.txtSo_CTrinh.AutoDropDown = null;
            this.txtSo_CTrinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSo_CTrinh.Location = new System.Drawing.Point(125, 45);
            this.txtSo_CTrinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_CTrinh.Name = "txtSo_CTrinh";
            this.txtSo_CTrinh.Size = new System.Drawing.Size(56, 20);
            this.txtSo_CTrinh.TabIndex = 133;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel3.Location = new System.Drawing.Point(23, 48);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(97, 13);
            this.rsLabel3.TabIndex = 134;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Số dòng công trình";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmIn_Ct_QDGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 158);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_QDGia";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        public RosySystem.Control.rsRadioButton rdbCCK;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbKCK;
        private RosySystem.Control.rsLabel rsLabel3;
        public RosySystem.Control.rsTextBox txtSo_CTrinh;
	}
}