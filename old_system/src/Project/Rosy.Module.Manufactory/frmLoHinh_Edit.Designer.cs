namespace RosyModule.Manufactory
{
    partial class frmLoHinh_Edit
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
            this.lbtTen_Vt = new RosySystem.Control.rsLabelName();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.rsLabel12 = new RosySystem.Control.rsLabel();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.numLength_Phoi = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel15 = new RosySystem.Control.rsLabel();
            this.numSo_Cay_Phoi = new RosySystem.Control.rsTextBoxNumber();
            this.txtLoai_Phoi = new RosySystem.Control.rsTextBox();
            this.rsLabel16 = new RosySystem.Control.rsLabel();
            this.rsLabel14 = new RosySystem.Control.rsLabel();
            this.numSo_Luong_Phoi = new RosySystem.Control.rsTextBoxNumber();
            this.rsGroupBox4 = new RosySystem.Control.rsGroupBox();
            this.lbtLoai_Phoi = new RosySystem.Control.rsLabelName();
            this.rsGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(458, 166);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(184, 47);
            this.btgAccept.TabIndex = 7;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(180, 23);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(48, 13);
            this.lbtTen_Vt.TabIndex = 27;
            this.lbtTen_Vt.Tag = "";
            this.lbtTen_Vt.Text = "Ten_Vt";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.Location = new System.Drawing.Point(77, 20);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(100, 20);
            this.txtMa_Vt.TabIndex = 0;
            this.txtMa_Vt.Tag = "Ma_Vt";
            // 
            // rsLabel12
            // 
            this.rsLabel12.AutoEllipsis = true;
            this.rsLabel12.AutoSize = true;
            this.rsLabel12.Location = new System.Drawing.Point(3, 22);
            this.rsLabel12.Name = "rsLabel12";
            this.rsLabel12.Size = new System.Drawing.Size(69, 13);
            this.rsLabel12.TabIndex = 28;
            this.rsLabel12.Tag = "";
            this.rsLabel12.Text = "Mã Vt Phôi";
            this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel13.Location = new System.Drawing.Point(3, 44);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(51, 13);
            this.rsLabel13.TabIndex = 36;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "Chiều dài";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLength_Phoi
            // 
            this.numLength_Phoi.AutoDropDown = null;
            this.numLength_Phoi.bFormat = true;
            this.numLength_Phoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLength_Phoi.Location = new System.Drawing.Point(77, 41);
            this.numLength_Phoi.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numLength_Phoi.Name = "numLength_Phoi";
            this.numLength_Phoi.Scale = 2;
            this.numLength_Phoi.Size = new System.Drawing.Size(100, 19);
            this.numLength_Phoi.TabIndex = 1;
            this.numLength_Phoi.Tag = "";
            this.numLength_Phoi.Text = "0.00";
            this.numLength_Phoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLength_Phoi.Value = 0D;
            // 
            // rsLabel15
            // 
            this.rsLabel15.AutoEllipsis = true;
            this.rsLabel15.AutoSize = true;
            this.rsLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel15.Location = new System.Drawing.Point(3, 87);
            this.rsLabel15.Name = "rsLabel15";
            this.rsLabel15.Size = new System.Drawing.Size(40, 13);
            this.rsLabel15.TabIndex = 34;
            this.rsLabel15.Tag = "";
            this.rsLabel15.Text = "Số cây";
            this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Cay_Phoi
            // 
            this.numSo_Cay_Phoi.AutoDropDown = null;
            this.numSo_Cay_Phoi.bFormat = true;
            this.numSo_Cay_Phoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSo_Cay_Phoi.Location = new System.Drawing.Point(77, 84);
            this.numSo_Cay_Phoi.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numSo_Cay_Phoi.Name = "numSo_Cay_Phoi";
            this.numSo_Cay_Phoi.Scale = 0;
            this.numSo_Cay_Phoi.Size = new System.Drawing.Size(100, 19);
            this.numSo_Cay_Phoi.TabIndex = 3;
            this.numSo_Cay_Phoi.Tag = "";
            this.numSo_Cay_Phoi.Text = "0";
            this.numSo_Cay_Phoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Cay_Phoi.Value = 0D;
            // 
            // txtLoai_Phoi
            // 
            this.txtLoai_Phoi.AutoDropDown = null;
            this.txtLoai_Phoi.Location = new System.Drawing.Point(77, 63);
            this.txtLoai_Phoi.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtLoai_Phoi.Name = "txtLoai_Phoi";
            this.txtLoai_Phoi.Size = new System.Drawing.Size(100, 20);
            this.txtLoai_Phoi.TabIndex = 2;
            this.txtLoai_Phoi.Tag = "Ma_Vt";
            // 
            // rsLabel16
            // 
            this.rsLabel16.AutoEllipsis = true;
            this.rsLabel16.AutoSize = true;
            this.rsLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel16.Location = new System.Drawing.Point(3, 108);
            this.rsLabel16.Name = "rsLabel16";
            this.rsLabel16.Size = new System.Drawing.Size(57, 13);
            this.rsLabel16.TabIndex = 36;
            this.rsLabel16.Tag = "";
            this.rsLabel16.Text = "Khối lượng";
            this.rsLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel14
            // 
            this.rsLabel14.AutoEllipsis = true;
            this.rsLabel14.AutoSize = true;
            this.rsLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel14.Location = new System.Drawing.Point(3, 65);
            this.rsLabel14.Name = "rsLabel14";
            this.rsLabel14.Size = new System.Drawing.Size(51, 13);
            this.rsLabel14.TabIndex = 39;
            this.rsLabel14.Tag = "";
            this.rsLabel14.Text = "Loại Phôi";
            this.rsLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong_Phoi
            // 
            this.numSo_Luong_Phoi.AutoDropDown = null;
            this.numSo_Luong_Phoi.bFormat = true;
            this.numSo_Luong_Phoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSo_Luong_Phoi.Location = new System.Drawing.Point(77, 106);
            this.numSo_Luong_Phoi.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numSo_Luong_Phoi.Name = "numSo_Luong_Phoi";
            this.numSo_Luong_Phoi.Scale = 0;
            this.numSo_Luong_Phoi.Size = new System.Drawing.Size(100, 19);
            this.numSo_Luong_Phoi.TabIndex = 4;
            this.numSo_Luong_Phoi.Tag = "";
            this.numSo_Luong_Phoi.Text = "0";
            this.numSo_Luong_Phoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong_Phoi.Value = 0D;
            // 
            // rsGroupBox4
            // 
            this.rsGroupBox4.BorderColor = System.Drawing.Color.Black;
            this.rsGroupBox4.Controls.Add(this.lbtLoai_Phoi);
            this.rsGroupBox4.Controls.Add(this.numSo_Luong_Phoi);
            this.rsGroupBox4.Controls.Add(this.rsLabel14);
            this.rsGroupBox4.Controls.Add(this.rsLabel16);
            this.rsGroupBox4.Controls.Add(this.txtLoai_Phoi);
            this.rsGroupBox4.Controls.Add(this.numSo_Cay_Phoi);
            this.rsGroupBox4.Controls.Add(this.rsLabel15);
            this.rsGroupBox4.Controls.Add(this.numLength_Phoi);
            this.rsGroupBox4.Controls.Add(this.rsLabel13);
            this.rsGroupBox4.Controls.Add(this.rsLabel12);
            this.rsGroupBox4.Controls.Add(this.txtMa_Vt);
            this.rsGroupBox4.Controls.Add(this.lbtTen_Vt);
            this.rsGroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsGroupBox4.Location = new System.Drawing.Point(10, 6);
            this.rsGroupBox4.Name = "rsGroupBox4";
            this.rsGroupBox4.Size = new System.Drawing.Size(632, 151);
            this.rsGroupBox4.TabIndex = 3;
            this.rsGroupBox4.TabStop = false;
            this.rsGroupBox4.Text = "`Thông tin phôi đã cán";
            // 
            // lbtLoai_Phoi
            // 
            this.lbtLoai_Phoi.AutoSize = true;
            this.lbtLoai_Phoi.ForeColor = System.Drawing.Color.Blue;
            this.lbtLoai_Phoi.Location = new System.Drawing.Point(183, 66);
            this.lbtLoai_Phoi.Name = "lbtLoai_Phoi";
            this.lbtLoai_Phoi.Size = new System.Drawing.Size(59, 13);
            this.lbtLoai_Phoi.TabIndex = 40;
            this.lbtLoai_Phoi.Tag = "";
            this.lbtLoai_Phoi.Text = "Loại phôi";
            this.lbtLoai_Phoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDLSXPhoi_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 221);
            this.Controls.Add(this.rsGroupBox4);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDLSXPhoi_Edit";
            this.Tag = "frmDLSX_Edit, ESC";
            this.Text = "`frmDLSX_Edit";
            this.rsGroupBox4.ResumeLayout(false);
            this.rsGroupBox4.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabelName lbtTen_Vt;
        private RosySystem.Control.rsTextBox txtMa_Vt;
        private RosySystem.Control.rsLabel rsLabel12;
        private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsTextBoxNumber numLength_Phoi;
        private RosySystem.Control.rsLabel rsLabel15;
        private RosySystem.Control.rsTextBoxNumber numSo_Cay_Phoi;
        private RosySystem.Control.rsTextBox txtLoai_Phoi;
        private RosySystem.Control.rsLabel rsLabel16;
        private RosySystem.Control.rsLabel rsLabel14;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong_Phoi;
        private RosySystem.Control.rsGroupBox rsGroupBox4;
        private RosySystem.Control.rsLabelName lbtLoai_Phoi;
	}
}