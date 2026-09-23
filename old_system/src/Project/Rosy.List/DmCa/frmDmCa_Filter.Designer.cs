namespace RosyList
{
	partial class frmDmCa_Filter
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
			this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
			this.lblNgay_Ct2 = new RosySystem.Control.rsLabel();
			this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
			this.lblNgay_Ct1 = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.SuspendLayout();
			// 
			// dteNgay_Ct2
			// 
			this.dteNgay_Ct2.bAllowEmpty = true;
			this.dteNgay_Ct2.bSelectOnFocus = false;
			this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct2.Location = new System.Drawing.Point(303, 25);
			this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct2.Mask = "00/00/0000";
			this.dteNgay_Ct2.Name = "dteNgay_Ct2";
			this.dteNgay_Ct2.Size = new System.Drawing.Size(68, 20);
			this.dteNgay_Ct2.TabIndex = 1;
			// 
			// lblNgay_Ct2
			// 
			this.lblNgay_Ct2.AutoEllipsis = true;
			this.lblNgay_Ct2.AutoSize = true;
			this.lblNgay_Ct2.Location = new System.Drawing.Point(239, 27);
			this.lblNgay_Ct2.Name = "lblNgay_Ct2";
			this.lblNgay_Ct2.Size = new System.Drawing.Size(53, 13);
			this.lblNgay_Ct2.TabIndex = 88;
			this.lblNgay_Ct2.Tag = "Ngay_Ct2";
			this.lblNgay_Ct2.Text = "Đến ngày";
			this.lblNgay_Ct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Ct1
			// 
			this.dteNgay_Ct1.bAllowEmpty = true;
			this.dteNgay_Ct1.bSelectOnFocus = false;
			this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct1.Location = new System.Drawing.Point(137, 23);
			this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct1.Mask = "00/00/0000";
			this.dteNgay_Ct1.Name = "dteNgay_Ct1";
			this.dteNgay_Ct1.Size = new System.Drawing.Size(68, 20);
			this.dteNgay_Ct1.TabIndex = 0;
			// 
			// lblNgay_Ct1
			// 
			this.lblNgay_Ct1.AutoEllipsis = true;
			this.lblNgay_Ct1.AutoSize = true;
			this.lblNgay_Ct1.Location = new System.Drawing.Point(41, 23);
			this.lblNgay_Ct1.Name = "lblNgay_Ct1";
			this.lblNgay_Ct1.Size = new System.Drawing.Size(46, 13);
			this.lblNgay_Ct1.TabIndex = 87;
			this.lblNgay_Ct1.Tag = "Ngay_Ct1";
			this.lblNgay_Ct1.Text = "Từ ngày";
			this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(239, 121);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 45);
			this.btgAccept.TabIndex = 25;
			// 
			// frmDmCa_Filter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 178);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.dteNgay_Ct2);
			this.Controls.Add(this.lblNgay_Ct2);
			this.Controls.Add(this.dteNgay_Ct1);
			this.Controls.Add(this.lblNgay_Ct1);
			this.Name = "frmDmCa_Filter";
			this.Text = "frmFilter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsLabel lblNgay_Ct2;
		private RosySystem.Control.rsLabel lblNgay_Ct1;
		private RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsDateTime dteNgay_Ct2;
		public RosySystem.Control.rsDateTime dteNgay_Ct1;
	}
}