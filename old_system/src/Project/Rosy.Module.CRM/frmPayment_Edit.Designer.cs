namespace RosyModule.CRM
{
	partial class frmPayment_Edit
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
			this.label1 = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.txtTen_Dt = new RosySystem.Control.rsTextBox();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.numTien_Thu = new RosySystem.Control.rsTextBoxNumber();
			this.dteNgay_Thu = new RosySystem.Control.rsDateTime();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.txtDieu_Khoan_Tt = new RosySystem.Control.rsTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoEllipsis = true;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 137);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Điều khoản Ttoán";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(353, 182);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 4;
			// 
			// txtTen_Dt
			// 
			this.txtTen_Dt.Location = new System.Drawing.Point(112, 17);
			this.txtTen_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Dt.Multiline = true;
			this.txtTen_Dt.Name = "txtTen_Dt";
			this.txtTen_Dt.ReadOnly = true;
			this.txtTen_Dt.Size = new System.Drawing.Size(393, 46);
			this.txtTen_Dt.TabIndex = 0;
			// 
			// rsLabel6
			// 
			this.rsLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(16, 29);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(86, 13);
			this.rsLabel6.TabIndex = 2;
			this.rsLabel6.Text = "Tên khách hàng";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTien_Thu
			// 
			this.numTien_Thu.bFormat = true;
			this.numTien_Thu.ForeColor = System.Drawing.SystemColors.ControlText;
			this.numTien_Thu.Location = new System.Drawing.Point(112, 103);
			this.numTien_Thu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTien_Thu.Name = "numTien_Thu";
			this.numTien_Thu.Scale = 2;
			this.numTien_Thu.Size = new System.Drawing.Size(120, 20);
			this.numTien_Thu.TabIndex = 2;
			this.numTien_Thu.Tag = "Tien_Hd";
			this.numTien_Thu.Text = "0.00";
			this.numTien_Thu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTien_Thu.Value = 0D;
			// 
			// dteNgay_Thu
			// 
			this.dteNgay_Thu.bAllowEmpty = true;
			this.dteNgay_Thu.bSelectOnFocus = false;
			this.dteNgay_Thu.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Thu.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Thu.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Thu.Location = new System.Drawing.Point(112, 79);
			this.dteNgay_Thu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Thu.Mask = "00/00/0000";
			this.dteNgay_Thu.Name = "dteNgay_Thu";
			this.dteNgay_Thu.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Thu.TabIndex = 1;
			// 
			// rsLabel1
			// 
			this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(16, 82);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(70, 13);
			this.rsLabel1.TabIndex = 2;
			this.rsLabel1.Text = "Ngày thu tiền";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(16, 106);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(46, 13);
			this.rsLabel2.TabIndex = 2;
			this.rsLabel2.Text = "Tiền thu";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDieu_Khoan_Tt
			// 
			this.txtDieu_Khoan_Tt.Location = new System.Drawing.Point(112, 128);
			this.txtDieu_Khoan_Tt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDieu_Khoan_Tt.Multiline = true;
			this.txtDieu_Khoan_Tt.Name = "txtDieu_Khoan_Tt";
			this.txtDieu_Khoan_Tt.Size = new System.Drawing.Size(393, 46);
			this.txtDieu_Khoan_Tt.TabIndex = 3;
			// 
			// frmPayment_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(551, 232);
			this.Controls.Add(this.dteNgay_Thu);
			this.Controls.Add(this.numTien_Thu);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDieu_Khoan_Tt);
			this.Controls.Add(this.txtTen_Dt);
			this.Name = "frmPayment_Edit";
			this.Tag = "frmPayment";
			this.Text = "frmPayment";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsLabel label1;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtTen_Dt;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsTextBoxNumber numTien_Thu;
		private RosySystem.Control.rsDateTime dteNgay_Thu;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBox txtDieu_Khoan_Tt;
	}
}