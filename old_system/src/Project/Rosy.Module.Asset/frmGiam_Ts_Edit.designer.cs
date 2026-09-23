namespace RosyModule.Asset
{
	partial class frmGiam_Ts_Edit
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
			this.lblNgay_Giam_Ts = new RosySystem.Control.rsLabel();
			this.dteNgay_Giam_Ts = new RosySystem.Control.rsDateTime();
			this.lbtTen_Nvu = new RosySystem.Control.rsLabel();
			this.txtMa_Nvu_Giam = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(338, 86);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 44);
			this.btgAccept.TabIndex = 2;
			// 
			// lblNgay_Giam_Ts
			// 
			this.lblNgay_Giam_Ts.AutoEllipsis = true;
			this.lblNgay_Giam_Ts.AutoSize = true;
			this.lblNgay_Giam_Ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNgay_Giam_Ts.Location = new System.Drawing.Point(34, 25);
			this.lblNgay_Giam_Ts.Name = "lblNgay_Giam_Ts";
			this.lblNgay_Giam_Ts.Size = new System.Drawing.Size(74, 13);
			this.lblNgay_Giam_Ts.TabIndex = 0;
			this.lblNgay_Giam_Ts.Tag = "";
			this.lblNgay_Giam_Ts.Text = "Ngày giảm TS";
			this.lblNgay_Giam_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Giam_Ts
			// 
			this.dteNgay_Giam_Ts.bAllowEmpty = true;
			this.dteNgay_Giam_Ts.bSelectOnFocus = false;
			this.dteNgay_Giam_Ts.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Giam_Ts.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Giam_Ts.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Giam_Ts.Location = new System.Drawing.Point(142, 22);
			this.dteNgay_Giam_Ts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Giam_Ts.Mask = "00/00/0000";
			this.dteNgay_Giam_Ts.Name = "dteNgay_Giam_Ts";
			this.dteNgay_Giam_Ts.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Giam_Ts.TabIndex = 0;
			// 
			// lbtTen_Nvu
			// 
			this.lbtTen_Nvu.AutoEllipsis = true;
			this.lbtTen_Nvu.AutoSize = true;
			this.lbtTen_Nvu.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Nvu.Location = new System.Drawing.Point(254, 47);
			this.lbtTen_Nvu.Name = "lbtTen_Nvu";
			this.lbtTen_Nvu.Size = new System.Drawing.Size(76, 13);
			this.lbtTen_Nvu.TabIndex = 10;
			this.lbtTen_Nvu.Tag = "";
			this.lbtTen_Nvu.Text = "Tên nghiệp vụ";
			this.lbtTen_Nvu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Nvu_Giam
			// 
			this.txtMa_Nvu_Giam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Nvu_Giam.Location = new System.Drawing.Point(142, 44);
			this.txtMa_Nvu_Giam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Nvu_Giam.MaxLength = 20;
			this.txtMa_Nvu_Giam.Name = "txtMa_Nvu_Giam";
			this.txtMa_Nvu_Giam.Size = new System.Drawing.Size(107, 20);
			this.txtMa_Nvu_Giam.TabIndex = 1;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(34, 51);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(72, 13);
			this.rsLabel2.TabIndex = 8;
			this.rsLabel2.Tag = "Ma_Nvu";
			this.rsLabel2.Text = "Mã nghiệp vụ";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmGiam_Ts_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(532, 137);
			this.Controls.Add(this.lbtTen_Nvu);
			this.Controls.Add(this.txtMa_Nvu_Giam);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.lblNgay_Giam_Ts);
			this.Controls.Add(this.dteNgay_Giam_Ts);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmGiam_Ts_Edit";
			this.Tag = "frmCtTsNGia";
			this.Text = "frmCtTsNGia";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lblNgay_Giam_Ts;
		private RosySystem.Control.rsDateTime dteNgay_Giam_Ts;
		private RosySystem.Control.rsLabel lbtTen_Nvu;
		private RosySystem.Control.rsTextBox txtMa_Nvu_Giam;
		private RosySystem.Control.rsLabel rsLabel2;
	}
}