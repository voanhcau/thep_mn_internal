namespace RosyModule.Machinery
{
    partial class frmIn_KHTBDK
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
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabel();
            this.rdbKHBTTB = new RosySystem.Control.rsRadioButton();
            this.rdbKQBTTB = new RosySystem.Control.rsRadioButton();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(132, 160);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(241, 55);
            this.btgAccept.TabIndex = 10;
            // 
            // lbtTen_Nh_Tb
            // 
            this.lbtTen_Nh_Tb.AutoEllipsis = true;
            this.lbtTen_Nh_Tb.AutoSize = true;
            this.lbtTen_Nh_Tb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbtTen_Nh_Tb.Location = new System.Drawing.Point(1, 224);
            this.lbtTen_Nh_Tb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_Nh_Tb.Name = "lbtTen_Nh_Tb";
            this.lbtTen_Nh_Tb.Size = new System.Drawing.Size(0, 17);
            this.lbtTen_Nh_Tb.TabIndex = 19;
            this.lbtTen_Nh_Tb.Tag = "";
            this.lbtTen_Nh_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbKHBTTB
            // 
            this.rdbKHBTTB.AutoSize = true;
            this.rdbKHBTTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbKHBTTB.Location = new System.Drawing.Point(72, 41);
            this.rdbKHBTTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbKHBTTB.Name = "rdbKHBTTB";
            this.rdbKHBTTB.Size = new System.Drawing.Size(128, 21);
            this.rdbKHBTTB.TabIndex = 20;
            this.rdbKHBTTB.Tag = "";
            this.rdbKHBTTB.Text = "Kế hoạch BTTB";
            this.rdbKHBTTB.UnChecked = true;
            this.rdbKHBTTB.UseVisualStyleBackColor = true;
            // 
            // rdbKQBTTB
            // 
            this.rdbKQBTTB.AutoSize = true;
            this.rdbKQBTTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbKQBTTB.Location = new System.Drawing.Point(72, 80);
            this.rdbKQBTTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbKQBTTB.Name = "rdbKQBTTB";
            this.rdbKQBTTB.Size = new System.Drawing.Size(117, 21);
            this.rdbKQBTTB.TabIndex = 22;
            this.rdbKQBTTB.Tag = "";
            this.rdbKQBTTB.Text = "Kết quả BTTB";
            this.rdbKQBTTB.UnChecked = true;
            this.rdbKQBTTB.UseVisualStyleBackColor = true;
            // 
            // frmIn_KHTBDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 230);
            this.Controls.Add(this.rdbKQBTTB);
            this.Controls.Add(this.rdbKHBTTB);
            this.Controls.Add(this.lbtTen_Nh_Tb);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmIn_KHTBDK";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        public RosySystem.Control.rsRadioButton rdbKHBTTB;
        public RosySystem.Control.rsRadioButton rdbKQBTTB;
	}
}