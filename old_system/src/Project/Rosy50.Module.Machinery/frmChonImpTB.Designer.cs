namespace RosyModule.Machinery
{
    partial class frmChonImpTB
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
            this.rdbImpLyLich = new RosySystem.Control.rsRadioButton();
            this.rdbImpVTPT = new RosySystem.Control.rsRadioButton();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(159, 109);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
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
            // rdbImpLyLich
            // 
            this.rdbImpLyLich.AutoSize = true;
            this.rdbImpLyLich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbImpLyLich.Location = new System.Drawing.Point(54, 33);
            this.rdbImpLyLich.Name = "rdbImpLyLich";
            this.rdbImpLyLich.Size = new System.Drawing.Size(99, 17);
            this.rdbImpLyLich.TabIndex = 20;
            this.rdbImpLyLich.Tag = "";
            this.rdbImpLyLich.Text = "Import lý lịch TB";
            this.rdbImpLyLich.UnChecked = true;
            this.rdbImpLyLich.UseVisualStyleBackColor = true;
            // 
            // rdbImpVTPT
            // 
            this.rdbImpVTPT.AutoSize = true;
            this.rdbImpVTPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbImpVTPT.Location = new System.Drawing.Point(54, 65);
            this.rdbImpVTPT.Name = "rdbImpVTPT";
            this.rdbImpVTPT.Size = new System.Drawing.Size(86, 17);
            this.rdbImpVTPT.TabIndex = 22;
            this.rdbImpVTPT.Tag = "";
            this.rdbImpVTPT.Text = "VTPT thiết bị";
            this.rdbImpVTPT.UnChecked = true;
            this.rdbImpVTPT.UseVisualStyleBackColor = true;
            // 
            // frmChonImpTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 166);
            this.Controls.Add(this.rdbImpVTPT);
            this.Controls.Add(this.rdbImpLyLich);
            this.Controls.Add(this.lbtTen_Nh_Tb);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmChonImpTB";
            this.Tag = "";
            this.Text = "Chọn loại TB";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        public RosySystem.Control.rsRadioButton rdbImpLyLich;
        public RosySystem.Control.rsRadioButton rdbImpVTPT;
	}
}