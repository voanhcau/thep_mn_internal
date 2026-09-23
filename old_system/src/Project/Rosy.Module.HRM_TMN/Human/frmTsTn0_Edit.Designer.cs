namespace RosyModule.HRM
{
	partial class frmTsTn0_Edit
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
			this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
			this.lblDien_Giai = new RosySystem.Control.rsLabel();
			this.txtMa_Tn = new RosySystem.Control.rsTextBox();
			this.lblTk = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.lbtTen_Tn = new RosySystem.Control.rsLabelName();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.lbtDvt = new System.Windows.Forms.Label();
			this.txtValue = new RosySystem.Control.rsTextBox();
			this.chkIs_UuTien = new RosySystem.Control.rsCheckbox();
			this.SuspendLayout();
			// 
			// dteNgay_Ap
			// 
			this.dteNgay_Ap.bAllowEmpty = true;
			this.dteNgay_Ap.bSelectOnFocus = false;
			this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ap.Location = new System.Drawing.Point(127, 46);
			this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ap.Mask = "00/00/0000";
			this.dteNgay_Ap.Name = "dteNgay_Ap";
			this.dteNgay_Ap.Size = new System.Drawing.Size(96, 20);
			this.dteNgay_Ap.TabIndex = 1;
			// 
			// lblDien_Giai
			// 
			this.lblDien_Giai.AutoEllipsis = true;
			this.lblDien_Giai.AutoSize = true;
			this.lblDien_Giai.Location = new System.Drawing.Point(25, 49);
			this.lblDien_Giai.Name = "lblDien_Giai";
			this.lblDien_Giai.Size = new System.Drawing.Size(47, 13);
			this.lblDien_Giai.TabIndex = 73;
			this.lblDien_Giai.Tag = "Ngay_Ap";
			this.lblDien_Giai.Text = "Ngày áp";
			this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Tn
			// 
			this.txtMa_Tn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Tn.Location = new System.Drawing.Point(127, 24);
			this.txtMa_Tn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Tn.MaxLength = 20;
			this.txtMa_Tn.Name = "txtMa_Tn";
			this.txtMa_Tn.Size = new System.Drawing.Size(96, 20);
			this.txtMa_Tn.TabIndex = 0;
			// 
			// lblTk
			// 
			this.lblTk.AutoEllipsis = true;
			this.lblTk.AutoSize = true;
			this.lblTk.Location = new System.Drawing.Point(25, 27);
			this.lblTk.Name = "lblTk";
			this.lblTk.Size = new System.Drawing.Size(67, 13);
			this.lblTk.TabIndex = 70;
			this.lblTk.Tag = "Ma_Tn";
			this.lblTk.Text = "Mã thu nhập";
			this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(356, 134);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(179, 42);
			this.btgAccept.TabIndex = 5;
			// 
			// lbtTen_Tn
			// 
			this.lbtTen_Tn.AutoSize = true;
			this.lbtTen_Tn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtTen_Tn.Location = new System.Drawing.Point(228, 24);
			this.lbtTen_Tn.Name = "lbtTen_Tn";
			this.lbtTen_Tn.Size = new System.Drawing.Size(66, 23);
			this.lbtTen_Tn.TabIndex = 1;
			this.lbtTen_Tn.Tag = "";
			this.lbtTen_Tn.Text = "txtTen_Tn";
			this.lbtTen_Tn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(25, 71);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(49, 13);
			this.rsLabel1.TabIndex = 70;
			this.rsLabel1.Tag = "Gia_Tri_Ap";
			this.rsLabel1.Text = "Giá trị áp";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtDvt
			// 
			this.lbtDvt.AutoSize = true;
			this.lbtDvt.Location = new System.Drawing.Point(271, 71);
			this.lbtDvt.Name = "lbtDvt";
			this.lbtDvt.Size = new System.Drawing.Size(24, 13);
			this.lbtDvt.TabIndex = 4;
			this.lbtDvt.Text = "Dvt";
			// 
			// txtValue
			// 
			this.txtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtValue.Location = new System.Drawing.Point(127, 68);
			this.txtValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtValue.MaxLength = 20;
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(139, 20);
			this.txtValue.TabIndex = 2;
			this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chkIs_UuTien
			// 
			this.chkIs_UuTien.AutoSize = true;
			this.chkIs_UuTien.ForeColor = System.Drawing.Color.Red;
			this.chkIs_UuTien.Location = new System.Drawing.Point(127, 93);
			this.chkIs_UuTien.Name = "chkIs_UuTien";
			this.chkIs_UuTien.Size = new System.Drawing.Size(227, 17);
			this.chkIs_UuTien.TabIndex = 3;
			this.chkIs_UuTien.Text = "Ưu tiên lấy tham số thu nhập từ chi tiết này";
			this.chkIs_UuTien.UseVisualStyleBackColor = true;
			// 
			// frmTsTn0_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 183);
			this.Controls.Add(this.chkIs_UuTien);
			this.Controls.Add(this.lbtDvt);
			this.Controls.Add(this.dteNgay_Ap);
			this.Controls.Add(this.lblDien_Giai);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.txtMa_Tn);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.lbtTen_Tn);
			this.Controls.Add(this.lblTk);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmTsTn0_Edit";
			this.Text = "frmDmTn_Edit";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_Ap;
		private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Tn;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabelName lbtTen_Tn;
		private RosySystem.Control.rsLabel rsLabel1;
		private System.Windows.Forms.Label lbtDvt;
		private RosySystem.Control.rsTextBox txtValue;
		private RosySystem.Control.rsCheckbox chkIs_UuTien;
	}
}