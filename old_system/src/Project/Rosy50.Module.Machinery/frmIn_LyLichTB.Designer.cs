namespace RosyModule.Machinery
{
    partial class frmIn_LyLichTB
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
            this.txtMa_Nh_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabel();
            this.rdbLyLich1 = new RosySystem.Control.rsRadioButton();
            this.rdbLyLich3 = new RosySystem.Control.rsRadioButton();
            this.rdbLyLich2 = new RosySystem.Control.rsRadioButton();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(159, 192);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // txtMa_Nh_Tb
            // 
            this.txtMa_Nh_Tb.AutoDropDown = null;
            this.txtMa_Nh_Tb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMa_Nh_Tb.Location = new System.Drawing.Point(130, 143);
            this.txtMa_Nh_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Tb.Name = "txtMa_Nh_Tb";
            this.txtMa_Nh_Tb.Size = new System.Drawing.Size(142, 20);
            this.txtMa_Nh_Tb.TabIndex = 18;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel5.Location = new System.Drawing.Point(40, 146);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(85, 13);
            this.rsLabel5.TabIndex = 19;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Mã nhóm thiết bị";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Nh_Tb
            // 
            this.lbtTen_Nh_Tb.AutoEllipsis = true;
            this.lbtTen_Nh_Tb.AutoSize = true;
            this.lbtTen_Nh_Tb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbtTen_Nh_Tb.Location = new System.Drawing.Point(1, 182);
            this.lbtTen_Nh_Tb.Name = "lbtTen_Nh_Tb";
            this.lbtTen_Nh_Tb.Size = new System.Drawing.Size(0, 13);
            this.lbtTen_Nh_Tb.TabIndex = 19;
            this.lbtTen_Nh_Tb.Tag = "";
            this.lbtTen_Nh_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbLyLich1
            // 
            this.rdbLyLich1.AutoSize = true;
            this.rdbLyLich1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbLyLich1.Location = new System.Drawing.Point(54, 33);
            this.rdbLyLich1.Name = "rdbLyLich1";
            this.rdbLyLich1.Size = new System.Drawing.Size(124, 17);
            this.rdbLyLich1.TabIndex = 20;
            this.rdbLyLich1.Tag = "";
            this.rdbLyLich1.Text = "Lý lịch thiết bị trang 1";
            this.rdbLyLich1.UnChecked = true;
            this.rdbLyLich1.UseVisualStyleBackColor = true;
            // 
            // rdbLyLich3
            // 
            this.rdbLyLich3.AutoSize = true;
            this.rdbLyLich3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbLyLich3.Location = new System.Drawing.Point(54, 98);
            this.rdbLyLich3.Name = "rdbLyLich3";
            this.rdbLyLich3.Size = new System.Drawing.Size(124, 17);
            this.rdbLyLich3.TabIndex = 21;
            this.rdbLyLich3.Tag = "";
            this.rdbLyLich3.Text = "Lý lịch thiết bị trang 3";
            this.rdbLyLich3.UnChecked = true;
            this.rdbLyLich3.UseVisualStyleBackColor = true;
            // 
            // rdbLyLich2
            // 
            this.rdbLyLich2.AutoSize = true;
            this.rdbLyLich2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbLyLich2.Location = new System.Drawing.Point(54, 65);
            this.rdbLyLich2.Name = "rdbLyLich2";
            this.rdbLyLich2.Size = new System.Drawing.Size(124, 17);
            this.rdbLyLich2.TabIndex = 22;
            this.rdbLyLich2.Tag = "";
            this.rdbLyLich2.Text = "Lý lịch thiết bị trang 2";
            this.rdbLyLich2.UnChecked = true;
            this.rdbLyLich2.UseVisualStyleBackColor = true;
            // 
            // frmIn_LyLichTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 249);
            this.Controls.Add(this.rdbLyLich2);
            this.Controls.Add(this.rdbLyLich3);
            this.Controls.Add(this.rdbLyLich1);
            this.Controls.Add(this.txtMa_Nh_Tb);
            this.Controls.Add(this.lbtTen_Nh_Tb);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_LyLichTB";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel5;
        public RosySystem.Control.rsTextBox txtMa_Nh_Tb;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        public RosySystem.Control.rsRadioButton rdbLyLich1;
        public RosySystem.Control.rsRadioButton rdbLyLich3;
        public RosySystem.Control.rsRadioButton rdbLyLich2;
	}
}