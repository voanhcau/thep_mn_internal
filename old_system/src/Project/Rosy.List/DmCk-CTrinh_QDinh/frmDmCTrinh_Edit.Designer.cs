namespace RosyList
{
    partial class frmDmCTrinh_Edit
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
			this.txtTen_CTrinh = new RosySystem.Control.rsTextBox();
			this.txtMa_CTrinh = new RosySystem.Control.rsTextBox();
			this.lbTen_CTrinh = new RosySystem.Control.rsLabel();
			this.lbMa_CTrinh = new RosySystem.Control.rsLabel();
			this.lbMa_Kv = new RosySystem.Control.rsLabel();
			this.txtMa_Kv = new RosySystem.Control.rsTextBox();
			this.lbtTen_Kv = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtMa_CTr_Dt = new RosySystem.Control.rsTextBox();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(347, 197);
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(516, 185);
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.lbtTen_Kv);
			this.Page1.Controls.Add(this.txtTen_CTrinh);
			this.Page1.Controls.Add(this.txtMa_Kv);
			this.Page1.Controls.Add(this.txtMa_CTr_Dt);
			this.Page1.Controls.Add(this.txtMa_CTrinh);
			this.Page1.Controls.Add(this.lbMa_Kv);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Controls.Add(this.lbTen_CTrinh);
			this.Page1.Controls.Add(this.lbMa_CTrinh);
			this.Page1.Size = new System.Drawing.Size(508, 159);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(508, 159);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 206);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 215);
			this.lblLog.Size = new System.Drawing.Size(293, 22);
			this.lblLog.Text = "";
			// 
			// txtTen_CTrinh
			// 
			this.txtTen_CTrinh.AutoDropDown = null;
			this.txtTen_CTrinh.Location = new System.Drawing.Point(118, 48);
			this.txtTen_CTrinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_CTrinh.MaxLength = 100;
			this.txtTen_CTrinh.Name = "txtTen_CTrinh";
			this.txtTen_CTrinh.Size = new System.Drawing.Size(335, 20);
			this.txtTen_CTrinh.TabIndex = 1;
			// 
			// txtMa_CTrinh
			// 
			this.txtMa_CTrinh.AutoDropDown = null;
			this.txtMa_CTrinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_CTrinh.Location = new System.Drawing.Point(118, 26);
			this.txtMa_CTrinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_CTrinh.MaxLength = 20;
			this.txtMa_CTrinh.Name = "txtMa_CTrinh";
			this.txtMa_CTrinh.Size = new System.Drawing.Size(120, 20);
			this.txtMa_CTrinh.TabIndex = 0;
			// 
			// lbTen_CTrinh
			// 
			this.lbTen_CTrinh.AutoEllipsis = true;
			this.lbTen_CTrinh.AutoSize = true;
			this.lbTen_CTrinh.Location = new System.Drawing.Point(7, 49);
			this.lbTen_CTrinh.Name = "lbTen_CTrinh";
			this.lbTen_CTrinh.Size = new System.Drawing.Size(76, 13);
			this.lbTen_CTrinh.TabIndex = 19;
			this.lbTen_CTrinh.Tag = "Ten_CTrinh";
			this.lbTen_CTrinh.Text = "Tên công trình";
			this.lbTen_CTrinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_CTrinh
			// 
			this.lbMa_CTrinh.AutoEllipsis = true;
			this.lbMa_CTrinh.AutoSize = true;
			this.lbMa_CTrinh.Location = new System.Drawing.Point(7, 26);
			this.lbMa_CTrinh.Name = "lbMa_CTrinh";
			this.lbMa_CTrinh.Size = new System.Drawing.Size(72, 13);
			this.lbMa_CTrinh.TabIndex = 20;
			this.lbMa_CTrinh.Tag = "Ma_CTrinh";
			this.lbMa_CTrinh.Text = "Mã công trình";
			this.lbMa_CTrinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Kv
			// 
			this.lbMa_Kv.AutoEllipsis = true;
			this.lbMa_Kv.AutoSize = true;
			this.lbMa_Kv.Location = new System.Drawing.Point(7, 70);
			this.lbMa_Kv.Name = "lbMa_Kv";
			this.lbMa_Kv.Size = new System.Drawing.Size(47, 13);
			this.lbMa_Kv.TabIndex = 20;
			this.lbMa_Kv.Tag = "Ma_Kv";
			this.lbMa_Kv.Text = "Khu vực";
			this.lbMa_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Kv
			// 
			this.txtMa_Kv.AutoDropDown = null;
			this.txtMa_Kv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Kv.Location = new System.Drawing.Point(118, 70);
			this.txtMa_Kv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Kv.MaxLength = 20;
			this.txtMa_Kv.Name = "txtMa_Kv";
			this.txtMa_Kv.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Kv.TabIndex = 2;
			// 
			// lbtTen_Kv
			// 
			this.lbtTen_Kv.AutoEllipsis = true;
			this.lbtTen_Kv.AutoSize = true;
			this.lbtTen_Kv.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Kv.Location = new System.Drawing.Point(268, 74);
			this.lbtTen_Kv.Name = "lbtTen_Kv";
			this.lbtTen_Kv.Size = new System.Drawing.Size(68, 13);
			this.lbtTen_Kv.TabIndex = 30;
			this.lbtTen_Kv.Tag = "";
			this.lbtTen_Kv.Text = "Tên khu vực";
			this.lbtTen_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(7, 92);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(100, 13);
			this.rsLabel1.TabIndex = 20;
			this.rsLabel1.Tag = "Ma_CTr_Dt";
			this.rsLabel1.Text = "Mã Ctrinh đối tượng";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.rsLabel1.Visible = false;
			// 
			// txtMa_CTr_Dt
			// 
			this.txtMa_CTr_Dt.AutoDropDown = null;
			this.txtMa_CTr_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_CTr_Dt.Location = new System.Drawing.Point(118, 92);
			this.txtMa_CTr_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_CTr_Dt.MaxLength = 20;
			this.txtMa_CTr_Dt.Name = "txtMa_CTr_Dt";
			this.txtMa_CTr_Dt.ReadOnly = true;
			this.txtMa_CTr_Dt.Size = new System.Drawing.Size(224, 20);
			this.txtMa_CTr_Dt.TabIndex = 0;
			this.txtMa_CTr_Dt.Visible = false;
			// 
			// frmDmCTrinh_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(540, 250);
			this.Name = "frmDmCTrinh_Edit";
			this.Object_ID = "DMCTRINH";
			this.Tag = "frmDmCTrinh, ESC";
			this.Text = "frmDmCTrinh";
			this.tabEdit.ResumeLayout(false);
			this.Page1.ResumeLayout(false);
			this.Page1.PerformLayout();
			this.Page2.ResumeLayout(false);
			this.Page2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtTen_CTrinh;
		private RosySystem.Control.rsTextBox txtMa_CTrinh;
		private RosySystem.Control.rsLabel lbTen_CTrinh;
		private RosySystem.Control.rsLabel lbMa_CTrinh;
        private RosySystem.Control.rsTextBox txtMa_Kv;
        private RosySystem.Control.rsLabel lbMa_Kv;
        private RosySystem.Control.rsLabel lbtTen_Kv;
		private RosySystem.Control.rsTextBox txtMa_CTr_Dt;
		private RosySystem.Control.rsLabel rsLabel1;

	}
}