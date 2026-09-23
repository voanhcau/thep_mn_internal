namespace RosyModule.Inventory
{
	partial class frmKiemKe_Filter 
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
			this.txtMa_Kho = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.lbtTen_Kho = new RosySystem.Control.rsLabelName();
			this.lbtTen_Vt = new RosySystem.Control.rsLabelName();
			this.lblMa_Vt = new RosySystem.Control.rsLabel();
			this.txtMa_Vt = new RosySystem.Control.rsTextBox();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.numThang = new RosySystem.Control.rsTextBoxNumber();
			this.chkCapNhatTonKho = new RosySystem.Control.rsCheckbox();
			this.chkCapNhatKiemKe = new RosySystem.Control.rsCheckbox();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.SuspendLayout();
			// 
			// txtMa_Kho
			// 
			this.txtMa_Kho.Location = new System.Drawing.Point(115, 49);
			this.txtMa_Kho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Kho.Name = "txtMa_Kho";
			this.txtMa_Kho.Size = new System.Drawing.Size(100, 20);
			this.txtMa_Kho.TabIndex = 1;
			this.txtMa_Kho.Tag = "Ma_Kho";
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(24, 51);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(43, 13);
			this.rsLabel1.TabIndex = 2;
			this.rsLabel1.Tag = "Ma_Kho";
			this.rsLabel1.Text = "Mã kho";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Kho
			// 
			this.lbtTen_Kho.AutoSize = true;
			this.lbtTen_Kho.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Kho.Location = new System.Drawing.Point(221, 52);
			this.lbtTen_Kho.Name = "lbtTen_Kho";
			this.lbtTen_Kho.Size = new System.Drawing.Size(51, 13);
			this.lbtTen_Kho.TabIndex = 3;
			this.lbtTen_Kho.Tag = "Ten_Kho";
			this.lbtTen_Kho.Text = "Ten_Kho";
			this.lbtTen_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Vt
			// 
			this.lbtTen_Vt.AutoSize = true;
			this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Vt.Location = new System.Drawing.Point(221, 74);
			this.lbtTen_Vt.Name = "lbtTen_Vt";
			this.lbtTen_Vt.Size = new System.Drawing.Size(42, 13);
			this.lbtTen_Vt.TabIndex = 3;
			this.lbtTen_Vt.Tag = "Ten_Vt";
			this.lbtTen_Vt.Text = "Ten_Vt";
			this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMa_Vt
			// 
			this.lblMa_Vt.AutoEllipsis = true;
			this.lblMa_Vt.AutoSize = true;
			this.lblMa_Vt.Location = new System.Drawing.Point(24, 73);
			this.lblMa_Vt.Name = "lblMa_Vt";
			this.lblMa_Vt.Size = new System.Drawing.Size(52, 13);
			this.lblMa_Vt.TabIndex = 2;
			this.lblMa_Vt.Tag = "Ma_Vt";
			this.lblMa_Vt.Text = "Mã vật tư";
			this.lblMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Vt
			// 
			this.txtMa_Vt.Location = new System.Drawing.Point(115, 71);
			this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt.Name = "txtMa_Vt";
			this.txtMa_Vt.Size = new System.Drawing.Size(100, 20);
			this.txtMa_Vt.TabIndex = 2;
			this.txtMa_Vt.Tag = "Ma_Vt";
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(24, 29);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(38, 13);
			this.rsLabel6.TabIndex = 2;
			this.rsLabel6.Tag = "Thang";
			this.rsLabel6.Text = "Tháng";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numThang
			// 
			this.numThang.bFormat = true;
			this.numThang.Location = new System.Drawing.Point(115, 27);
			this.numThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numThang.Name = "numThang";
			this.numThang.Scale = 0;
			this.numThang.Size = new System.Drawing.Size(37, 20);
			this.numThang.TabIndex = 0;
			this.numThang.Tag = "";
			this.numThang.Text = "0";
			this.numThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numThang.Value = 0D;
			// 
			// chkCapNhatTonKho
			// 
			this.chkCapNhatTonKho.AutoSize = true;
			this.chkCapNhatTonKho.Location = new System.Drawing.Point(115, 96);
			this.chkCapNhatTonKho.Name = "chkCapNhatTonKho";
			this.chkCapNhatTonKho.Size = new System.Drawing.Size(154, 17);
			this.chkCapNhatTonKho.TabIndex = 3;
			this.chkCapNhatTonKho.Text = "Cập nhật lại số liệu tồn kho";
			this.chkCapNhatTonKho.UseVisualStyleBackColor = true;
			// 
			// chkCapNhatKiemKe
			// 
			this.chkCapNhatKiemKe.AutoSize = true;
			this.chkCapNhatKiemKe.Location = new System.Drawing.Point(115, 119);
			this.chkCapNhatKiemKe.Name = "chkCapNhatKiemKe";
			this.chkCapNhatKiemKe.Size = new System.Drawing.Size(209, 17);
			this.chkCapNhatKiemKe.TabIndex = 4;
			this.chkCapNhatKiemKe.Text = "Tự động lấy số tồn kho làm số kiểm kê";
			this.chkCapNhatKiemKe.UseVisualStyleBackColor = true;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(241, 146);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 44);
			this.btgAccept.TabIndex = 5;
			// 
			// frmKiemKe_Filter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 200);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.txtMa_Kho);
			this.Controls.Add(this.chkCapNhatTonKho);
			this.Controls.Add(this.chkCapNhatKiemKe);
			this.Controls.Add(this.numThang);
			this.Controls.Add(this.txtMa_Vt);
			this.Controls.Add(this.lblMa_Vt);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.lbtTen_Vt);
			this.Controls.Add(this.lbtTen_Kho);
			this.Name = "frmKiemKe_Filter";
			this.Text = "frmEditDKV";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabelName lbtTen_Kho;
		private RosySystem.Control.rsLabelName lbtTen_Vt;
        private RosySystem.Control.rsLabel lblMa_Vt;
        private RosySystem.Control.rsLabel rsLabel6;
        public RosySystem.Control.rsTextBox txtMa_Kho;
        public RosySystem.Control.rsTextBox txtMa_Vt;
        public RosySystem.Control.rsTextBoxNumber numThang;
        public RosySystem.Control.rsCheckbox chkCapNhatTonKho;
        public RosySystem.Control.rsCheckbox chkCapNhatKiemKe;
        private RosySystem.Customize.btgAccept btgAccept;
	}
}