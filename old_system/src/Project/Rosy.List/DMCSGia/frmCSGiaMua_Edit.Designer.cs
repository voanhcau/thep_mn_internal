namespace RosyList
{
	partial class frmCSGiaMua_Edit
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
			this.lbtTen_Vt = new RosySystem.Control.rsLabel();
			this.lbGia = new RosySystem.Control.rsLabel();
			this.numGia = new RosySystem.Control.rsTextBoxNumber();
			this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
			this.lbNgay_Ap = new RosySystem.Control.rsLabel();
			this.txtMa_Vt = new RosySystem.Control.rsTextBox();
			this.lbMa_Vt = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.lbSo_QD = new RosySystem.Control.rsLabel();
			this.txtMa_Dt = new RosySystem.Control.rsTextBox();
			this.lbNgay_End = new RosySystem.Control.rsLabel();
			this.dteNgay_Kthuc = new RosySystem.Control.rsDateTime();
			this.lbtTen_Dt = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// lbtTen_Vt
			// 
			this.lbtTen_Vt.AutoEllipsis = true;
			this.lbtTen_Vt.AutoSize = true;
			this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Vt.Location = new System.Drawing.Point(281, 22);
			this.lbtTen_Vt.Name = "lbtTen_Vt";
			this.lbtTen_Vt.Size = new System.Drawing.Size(56, 13);
			this.lbtTen_Vt.TabIndex = 68;
			this.lbtTen_Vt.Text = "Tên vật tư";
			this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbGia
			// 
			this.lbGia.AutoEllipsis = true;
			this.lbGia.AutoSize = true;
			this.lbGia.Location = new System.Drawing.Point(35, 66);
			this.lbGia.Name = "lbGia";
			this.lbGia.Size = new System.Drawing.Size(46, 13);
			this.lbGia.TabIndex = 67;
			this.lbGia.Tag = "";
			this.lbGia.Text = "Giá mua";
			this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numGia
			// 
			this.numGia.AutoDropDown = null;
			this.numGia.bFormat = true;
			this.numGia.Location = new System.Drawing.Point(154, 63);
			this.numGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numGia.Name = "numGia";
			this.numGia.Scale = 2;
			this.numGia.Size = new System.Drawing.Size(120, 20);
			this.numGia.TabIndex = 5;
			this.numGia.Text = "0.00";
			this.numGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numGia.Value = 0D;
			// 
			// dteNgay_Ap
			// 
			this.dteNgay_Ap.bAllowEmpty = true;
			this.dteNgay_Ap.bSelectOnFocus = false;
			this.dteNgay_Ap.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ap.Location = new System.Drawing.Point(154, 85);
			this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ap.Mask = "00/00/0000";
			this.dteNgay_Ap.Name = "dteNgay_Ap";
			this.dteNgay_Ap.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ap.TabIndex = 13;
			// 
			// lbNgay_Ap
			// 
			this.lbNgay_Ap.AutoEllipsis = true;
			this.lbNgay_Ap.AutoSize = true;
			this.lbNgay_Ap.Location = new System.Drawing.Point(35, 87);
			this.lbNgay_Ap.Name = "lbNgay_Ap";
			this.lbNgay_Ap.Size = new System.Drawing.Size(47, 13);
			this.lbNgay_Ap.TabIndex = 66;
			this.lbNgay_Ap.Tag = "Ngay_Ap";
			this.lbNgay_Ap.Text = "Ngày áp";
			this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Vt
			// 
			this.txtMa_Vt.AutoDropDown = null;
			this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Vt.Location = new System.Drawing.Point(154, 19);
			this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt.MaxLength = 20;
			this.txtMa_Vt.Name = "txtMa_Vt";
			this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Vt.TabIndex = 0;
			// 
			// lbMa_Vt
			// 
			this.lbMa_Vt.AutoEllipsis = true;
			this.lbMa_Vt.AutoSize = true;
			this.lbMa_Vt.Location = new System.Drawing.Point(35, 22);
			this.lbMa_Vt.Name = "lbMa_Vt";
			this.lbMa_Vt.Size = new System.Drawing.Size(52, 13);
			this.lbMa_Vt.TabIndex = 65;
			this.lbMa_Vt.Tag = "Ma_Vt";
			this.lbMa_Vt.Text = "Mã vật tư";
			this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(352, 162);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 15;
			// 
			// lbSo_QD
			// 
			this.lbSo_QD.AutoEllipsis = true;
			this.lbSo_QD.AutoSize = true;
			this.lbSo_QD.Location = new System.Drawing.Point(35, 44);
			this.lbSo_QD.Name = "lbSo_QD";
			this.lbSo_QD.Size = new System.Drawing.Size(53, 13);
			this.lbSo_QD.TabIndex = 65;
			this.lbSo_QD.Tag = "Ma_Dt";
			this.lbSo_QD.Text = "Đối tượng";
			this.lbSo_QD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Dt
			// 
			this.txtMa_Dt.AutoDropDown = null;
			this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Dt.Location = new System.Drawing.Point(154, 41);
			this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Dt.MaxLength = 20;
			this.txtMa_Dt.Name = "txtMa_Dt";
			this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Dt.TabIndex = 3;
			// 
			// lbNgay_End
			// 
			this.lbNgay_End.AutoEllipsis = true;
			this.lbNgay_End.AutoSize = true;
			this.lbNgay_End.Location = new System.Drawing.Point(35, 109);
			this.lbNgay_End.Name = "lbNgay_End";
			this.lbNgay_End.Size = new System.Drawing.Size(74, 13);
			this.lbNgay_End.TabIndex = 66;
			this.lbNgay_End.Tag = "Ngay_End";
			this.lbNgay_End.Text = "Ngày kết thúc";
			this.lbNgay_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Kthuc
			// 
			this.dteNgay_Kthuc.bAllowEmpty = true;
			this.dteNgay_Kthuc.bSelectOnFocus = false;
			this.dteNgay_Kthuc.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Kthuc.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Kthuc.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Kthuc.Location = new System.Drawing.Point(154, 107);
			this.dteNgay_Kthuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Kthuc.Mask = "00/00/0000";
			this.dteNgay_Kthuc.Name = "dteNgay_Kthuc";
			this.dteNgay_Kthuc.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Kthuc.TabIndex = 14;
			// 
			// lbtTen_Dt
			// 
			this.lbtTen_Dt.AutoEllipsis = true;
			this.lbtTen_Dt.AutoSize = true;
			this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Dt.Location = new System.Drawing.Point(281, 44);
			this.lbtTen_Dt.Name = "lbtTen_Dt";
			this.lbtTen_Dt.Size = new System.Drawing.Size(74, 13);
			this.lbtTen_Dt.TabIndex = 68;
			this.lbtTen_Dt.Text = "Tên đối tượng";
			this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmCSGiaMua_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 217);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.lbtTen_Dt);
			this.Controls.Add(this.lbtTen_Vt);
			this.Controls.Add(this.lbGia);
			this.Controls.Add(this.numGia);
			this.Controls.Add(this.dteNgay_Kthuc);
			this.Controls.Add(this.lbNgay_End);
			this.Controls.Add(this.dteNgay_Ap);
			this.Controls.Add(this.lbNgay_Ap);
			this.Controls.Add(this.txtMa_Dt);
			this.Controls.Add(this.lbSo_QD);
			this.Controls.Add(this.txtMa_Vt);
			this.Controls.Add(this.lbMa_Vt);
			this.Name = "frmCSGiaMua_Edit";
			this.Tag = "frmDmGiaMua";
			this.Text = "frmDmGiaMua";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsLabel lbtTen_Vt;
		private RosySystem.Control.rsLabel lbGia;
		private RosySystem.Control.rsTextBoxNumber numGia;
		private RosySystem.Control.rsDateTime dteNgay_Ap;
		private RosySystem.Control.rsLabel lbNgay_Ap;
		private RosySystem.Control.rsTextBox txtMa_Vt;
		private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lbSo_QD;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Control.rsLabel lbNgay_End;
		private RosySystem.Control.rsDateTime dteNgay_Kthuc;
		private RosySystem.Control.rsLabel lbtTen_Dt;
	}
}