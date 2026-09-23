namespace RosyModule.Payable
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
            this.txtSo_QD = new RosySystem.Control.rsTextBox();
            this.SuspendLayout();
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(255, 22);
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
            this.lbGia.Location = new System.Drawing.Point(35, 69);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(46, 13);
            this.lbGia.TabIndex = 67;
            this.lbGia.Tag = "Gia";
            this.lbGia.Text = "Giá mua";
            this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGia
            // 
            this.numGia.AutoDropDown = null;
            this.numGia.bFormat = true;
            this.numGia.Location = new System.Drawing.Point(128, 66);
            this.numGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numGia.Name = "numGia";
            this.numGia.Scale = 2;
            this.numGia.Size = new System.Drawing.Size(120, 20);
            this.numGia.TabIndex = 6;
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
            this.dteNgay_Ap.Location = new System.Drawing.Point(128, 44);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ap.TabIndex = 4;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.Location = new System.Drawing.Point(35, 46);
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
            this.txtMa_Vt.Location = new System.Drawing.Point(128, 19);
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
            this.btgAccept.Location = new System.Drawing.Point(286, 117);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 8;
            // 
            // lbSo_QD
            // 
            this.lbSo_QD.AutoEllipsis = true;
            this.lbSo_QD.AutoSize = true;
            this.lbSo_QD.Location = new System.Drawing.Point(35, 91);
            this.lbSo_QD.Name = "lbSo_QD";
            this.lbSo_QD.Size = new System.Drawing.Size(58, 13);
            this.lbSo_QD.TabIndex = 65;
            this.lbSo_QD.Tag = "";
            this.lbSo_QD.Text = "Số báo giá";
            this.lbSo_QD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbSo_QD.Click += new System.EventHandler(this.lbSo_QD_Click);
            // 
            // txtSo_QD
            // 
            this.txtSo_QD.AutoDropDown = null;
            this.txtSo_QD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_QD.Location = new System.Drawing.Point(128, 88);
            this.txtSo_QD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_QD.MaxLength = 20;
            this.txtSo_QD.Name = "txtSo_QD";
            this.txtSo_QD.Size = new System.Drawing.Size(120, 20);
            this.txtSo_QD.TabIndex = 2;
            // 
            // frmCSGiaMua_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 169);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.dteNgay_Ap);
            this.Controls.Add(this.lbNgay_Ap);
            this.Controls.Add(this.txtSo_QD);
            this.Controls.Add(this.lbSo_QD);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.lbMa_Vt);
            this.Name = "frmCSGiaMua_Edit";
            this.Tag = "frmDmGia";
            this.Text = "frmDmGia";
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
        private RosySystem.Control.rsTextBox txtSo_QD;
	}
}