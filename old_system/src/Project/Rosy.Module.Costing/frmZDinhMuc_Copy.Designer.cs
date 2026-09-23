namespace RosyModule.Costing
{
	partial class frmZDinhMuc_Copy
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
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtMa_Vt_Sp_Source = new RosySystem.Control.rsTextBox();
			this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.lbtTen_Vt_Sp_Source = new RosySystem.Control.rsLabel();
			this.txtMa_Vt_Sp_Dest = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.lbtTen_Vt_Sp_Dest = new RosySystem.Control.rsLabel();
			this.chkCopyDmVt = new System.Windows.Forms.CheckBox();
			this.chkCopyDmYt = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(335, 144);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(182, 44);
			this.btgAccept.TabIndex = 9;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(29, 26);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(104, 13);
			this.rsLabel1.TabIndex = 60;
			this.rsLabel1.Tag = "Ma_Vt_Sp_Source";
			this.rsLabel1.Text = "Mã sản phẩm nguồn";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Vt_Sp_Source
			// 
			this.txtMa_Vt_Sp_Source.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Vt_Sp_Source.Location = new System.Drawing.Point(138, 23);
			this.txtMa_Vt_Sp_Source.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt_Sp_Source.MaxLength = 20;
			this.txtMa_Vt_Sp_Source.Name = "txtMa_Vt_Sp_Source";
			this.txtMa_Vt_Sp_Source.Size = new System.Drawing.Size(96, 20);
			this.txtMa_Vt_Sp_Source.TabIndex = 0;
			// 
			// dteNgay_Ap
			// 
			this.dteNgay_Ap.bAllowEmpty = true;
			this.dteNgay_Ap.bSelectOnFocus = false;
			this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ap.Location = new System.Drawing.Point(138, 67);
			this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.dteNgay_Ap.Mask = "00/00/0000";
			this.dteNgay_Ap.Name = "dteNgay_Ap";
			this.dteNgay_Ap.Size = new System.Drawing.Size(68, 20);
			this.dteNgay_Ap.TabIndex = 4;
			this.dteNgay_Ap.Tag = "Ngay_Ct";
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(29, 70);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(47, 13);
			this.rsLabel6.TabIndex = 64;
			this.rsLabel6.Tag = "Ngay_Ap";
			this.rsLabel6.Text = "Ngày áp";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Vt_Sp_Source
			// 
			this.lbtTen_Vt_Sp_Source.AutoEllipsis = true;
			this.lbtTen_Vt_Sp_Source.AutoSize = true;
			this.lbtTen_Vt_Sp_Source.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtTen_Vt_Sp_Source.Location = new System.Drawing.Point(239, 26);
			this.lbtTen_Vt_Sp_Source.Name = "lbtTen_Vt_Sp_Source";
			this.lbtTen_Vt_Sp_Source.Size = new System.Drawing.Size(112, 13);
			this.lbtTen_Vt_Sp_Source.TabIndex = 1;
			this.lbtTen_Vt_Sp_Source.Tag = "";
			this.lbtTen_Vt_Sp_Source.Text = "lbtTen_Vt_Sp_Source";
			this.lbtTen_Vt_Sp_Source.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Vt_Sp_Dest
			// 
			this.txtMa_Vt_Sp_Dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Vt_Sp_Dest.Location = new System.Drawing.Point(138, 45);
			this.txtMa_Vt_Sp_Dest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt_Sp_Dest.MaxLength = 20;
			this.txtMa_Vt_Sp_Dest.Name = "txtMa_Vt_Sp_Dest";
			this.txtMa_Vt_Sp_Dest.Size = new System.Drawing.Size(96, 20);
			this.txtMa_Vt_Sp_Dest.TabIndex = 2;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(29, 48);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(97, 13);
			this.rsLabel2.TabIndex = 67;
			this.rsLabel2.Tag = "Ma_Vt_Sp_Dest";
			this.rsLabel2.Text = "Mã sản phẩm đích";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Vt_Sp_Dest
			// 
			this.lbtTen_Vt_Sp_Dest.AutoEllipsis = true;
			this.lbtTen_Vt_Sp_Dest.AutoSize = true;
			this.lbtTen_Vt_Sp_Dest.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtTen_Vt_Sp_Dest.Location = new System.Drawing.Point(239, 48);
			this.lbtTen_Vt_Sp_Dest.Name = "lbtTen_Vt_Sp_Dest";
			this.lbtTen_Vt_Sp_Dest.Size = new System.Drawing.Size(100, 13);
			this.lbtTen_Vt_Sp_Dest.TabIndex = 3;
			this.lbtTen_Vt_Sp_Dest.Tag = "";
			this.lbtTen_Vt_Sp_Dest.Text = "lbtTen_Vt_Sp_Dest";
			this.lbtTen_Vt_Sp_Dest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkCopyDmVt
			// 
			this.chkCopyDmVt.AutoSize = true;
			this.chkCopyDmVt.Checked = true;
			this.chkCopyDmVt.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCopyDmVt.Location = new System.Drawing.Point(138, 93);
			this.chkCopyDmVt.Name = "chkCopyDmVt";
			this.chkCopyDmVt.Size = new System.Drawing.Size(127, 17);
			this.chkCopyDmVt.TabIndex = 5;
			this.chkCopyDmVt.Text = "Copy định mức vật tư";
			this.chkCopyDmVt.UseVisualStyleBackColor = true;
			// 
			// chkCopyDmYt
			// 
			this.chkCopyDmYt.AutoSize = true;
			this.chkCopyDmYt.Location = new System.Drawing.Point(138, 116);
			this.chkCopyDmYt.Name = "chkCopyDmYt";
			this.chkCopyDmYt.Size = new System.Drawing.Size(129, 17);
			this.chkCopyDmYt.TabIndex = 6;
			this.chkCopyDmYt.Text = "Copy định mức yếu tố";
			this.chkCopyDmYt.UseVisualStyleBackColor = true;
			// 
			// frmZDinhMuc_Copy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(529, 200);
			this.Controls.Add(this.chkCopyDmYt);
			this.Controls.Add(this.chkCopyDmVt);
			this.Controls.Add(this.txtMa_Vt_Sp_Dest);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.lbtTen_Vt_Sp_Dest);
			this.Controls.Add(this.dteNgay_Ap);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.txtMa_Vt_Sp_Source);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.lbtTen_Vt_Sp_Source);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmZDinhMuc_Copy";
			this.Tag = "ZDinhMuc_Copy,ESC";
			this.Text = "frmZDinhMuc";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel lbtTen_Vt_Sp_Source;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel lbtTen_Vt_Sp_Dest;
		public RosySystem.Control.rsTextBox txtMa_Vt_Sp_Dest;
		public RosySystem.Control.rsTextBox txtMa_Vt_Sp_Source;
		public RosySystem.Control.rsDateTime dteNgay_Ap;
		public System.Windows.Forms.CheckBox chkCopyDmVt;
		public System.Windows.Forms.CheckBox chkCopyDmYt;
	}
}