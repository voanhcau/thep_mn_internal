namespace RosyModule.Salary
{
    partial class frmIn_ChamCong
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
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabel();
            this.rdbChamCong = new RosySystem.Control.rsRadioButton();
            this.rdbBDDH = new RosySystem.Control.rsRadioButton();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(159, 135);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(103, 93);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(87, 20);
            this.txtMa_Dt_CbNv.TabIndex = 18;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel5.Location = new System.Drawing.Point(26, 96);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(72, 13);
            this.rsLabel5.TabIndex = 19;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Mã nhân viên";
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
            // rdbChamCong
            // 
            this.rdbChamCong.AutoSize = true;
            this.rdbChamCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbChamCong.Location = new System.Drawing.Point(43, 27);
            this.rdbChamCong.Name = "rdbChamCong";
            this.rdbChamCong.Size = new System.Drawing.Size(116, 17);
            this.rdbChamCong.TabIndex = 20;
            this.rdbChamCong.Tag = "";
            this.rdbChamCong.Text = "In bảng chấm công";
            this.rdbChamCong.UnChecked = true;
            this.rdbChamCong.UseVisualStyleBackColor = true;
            // 
            // rdbBDDH
            // 
            this.rdbBDDH.AutoSize = true;
            this.rdbBDDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbBDDH.Location = new System.Drawing.Point(43, 59);
            this.rdbBDDH.Name = "rdbBDDH";
            this.rdbBDDH.Size = new System.Drawing.Size(116, 17);
            this.rdbBDDH.TabIndex = 22;
            this.rdbBDDH.Tag = "";
            this.rdbBDDH.Text = "In phiếu sữa BDDH";
            this.rdbBDDH.UnChecked = true;
            this.rdbBDDH.UseVisualStyleBackColor = true;
            // 
            // frmIn_ChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 192);
            this.Controls.Add(this.rdbBDDH);
            this.Controls.Add(this.rdbChamCong);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.lbtTen_Nh_Tb);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_ChamCong";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel5;
        public RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        public RosySystem.Control.rsRadioButton rdbChamCong;
        public RosySystem.Control.rsRadioButton rdbBDDH;
	}
}