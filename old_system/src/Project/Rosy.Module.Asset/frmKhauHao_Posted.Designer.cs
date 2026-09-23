namespace RosyModule.Asset
{
	partial class frmKhauHao_Posted
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
			this.txtDien_Giai = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.txtSo_Ct = new RosySystem.Control.rsTextBox();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.txtMa_Ct = new RosySystem.Control.rsTextBox();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.numThang = new RosySystem.Control.rsTextBoxNumber();
			this.SuspendLayout();
			// 
			// txtDien_Giai
			// 
			this.txtDien_Giai.Location = new System.Drawing.Point(111, 83);
			this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDien_Giai.Name = "txtDien_Giai";
			this.txtDien_Giai.Size = new System.Drawing.Size(421, 20);
			this.txtDien_Giai.TabIndex = 3;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(19, 86);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(48, 13);
			this.rsLabel1.TabIndex = 2;
			this.rsLabel1.Tag = "Dien_Giai";
			this.rsLabel1.Text = "Diễn giải";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(19, 64);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(65, 13);
			this.rsLabel2.TabIndex = 1;
			this.rsLabel2.Tag = "So_Ct";
			this.rsLabel2.Text = "Số chứng từ";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSo_Ct
			// 
			this.txtSo_Ct.Location = new System.Drawing.Point(111, 61);
			this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_Ct.Name = "txtSo_Ct";
			this.txtSo_Ct.Size = new System.Drawing.Size(110, 20);
			this.txtSo_Ct.TabIndex = 2;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(19, 42);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(67, 13);
			this.rsLabel3.TabIndex = 0;
			this.rsLabel3.Tag = "Ma_Ct";
			this.rsLabel3.Text = "Mã chứng từ";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Ct
			// 
			this.txtMa_Ct.Location = new System.Drawing.Point(111, 39);
			this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Ct.Name = "txtMa_Ct";
			this.txtMa_Ct.Size = new System.Drawing.Size(31, 20);
			this.txtMa_Ct.TabIndex = 1;
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(350, 110);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(182, 43);
			this.btgAccept.TabIndex = 4;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(19, 20);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(38, 13);
			this.rsLabel4.TabIndex = 0;
			this.rsLabel4.Tag = "Thang";
			this.rsLabel4.Text = "Tháng";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numThang
			// 
			this.numThang.bFormat = true;
			this.numThang.Location = new System.Drawing.Point(111, 17);
			this.numThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numThang.Name = "numThang";
			this.numThang.Scale = 0;
			this.numThang.Size = new System.Drawing.Size(31, 20);
			this.numThang.TabIndex = 0;
			this.numThang.Text = "0";
			this.numThang.Value = 0D;
			// 
			// frmKhauHao_Posted
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 160);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.numThang);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.txtMa_Ct);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.txtSo_Ct);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.txtDien_Giai);
			this.Controls.Add(this.rsLabel1);
			this.Name = "frmKhauHao_Posted";
			this.Text = "frmKhauHao_Posted";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel4;
		public RosySystem.Control.rsTextBox txtDien_Giai;
		public RosySystem.Control.rsTextBox txtSo_Ct;
		public RosySystem.Control.rsTextBox txtMa_Ct;
		public RosySystem.Control.rsTextBoxNumber numThang;
	}
}