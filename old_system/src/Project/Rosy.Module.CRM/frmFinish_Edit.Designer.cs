namespace RosyModule.CRM
{
	partial class frmFinish
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
			this.numSo_Ngay_Ht = new RosySystem.Control.rsTextBoxNumber();
			this.numSo_Ngay_Dk_Ht = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.rsLabel8 = new RosySystem.Control.rsLabel();
			this.rsLabel15 = new RosySystem.Control.rsLabel();
			this.txtNgay_Ht = new RosySystem.Control.rsDateTime();
			this.txtNgay_Dk_Ht = new RosySystem.Control.rsDateTime();
			this.txtNgay_Gd = new RosySystem.Control.rsDateTime();
			this.txtNote = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(369, 239);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(180, 43);
			this.btgAccept.TabIndex = 6;
			// 
			// numSo_Ngay_Ht
			// 
			this.numSo_Ngay_Ht.bFormat = true;
			this.numSo_Ngay_Ht.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numSo_Ngay_Ht.Location = new System.Drawing.Point(121, 57);
			this.numSo_Ngay_Ht.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Ngay_Ht.Name = "numSo_Ngay_Ht";
			this.numSo_Ngay_Ht.Scale = 0;
			this.numSo_Ngay_Ht.Size = new System.Drawing.Size(28, 20);
			this.numSo_Ngay_Ht.TabIndex = 3;
			this.numSo_Ngay_Ht.Text = "0";
			this.numSo_Ngay_Ht.Value = 0D;
			// 
			// numSo_Ngay_Dk_Ht
			// 
			this.numSo_Ngay_Dk_Ht.bFormat = true;
			this.numSo_Ngay_Dk_Ht.Enabled = false;
			this.numSo_Ngay_Dk_Ht.Location = new System.Drawing.Point(121, 35);
			this.numSo_Ngay_Dk_Ht.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Ngay_Dk_Ht.Name = "numSo_Ngay_Dk_Ht";
			this.numSo_Ngay_Dk_Ht.Scale = 0;
			this.numSo_Ngay_Dk_Ht.Size = new System.Drawing.Size(28, 20);
			this.numSo_Ngay_Dk_Ht.TabIndex = 1;
			this.numSo_Ngay_Dk_Ht.Text = "0";
			this.numSo_Ngay_Dk_Ht.Value = 0D;
			// 
			// rsLabel5
			// 
			this.rsLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel5.ForeColor = System.Drawing.Color.Red;
			this.rsLabel5.Location = new System.Drawing.Point(17, 60);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(104, 13);
			this.rsLabel5.TabIndex = 19;
			this.rsLabel5.Text = "Ngày hoàn thành";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel7
			// 
			this.rsLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Location = new System.Drawing.Point(17, 38);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(89, 13);
			this.rsLabel7.TabIndex = 17;
			this.rsLabel7.Text = "Ngày DK h.thành";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel8
			// 
			this.rsLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel8.AutoEllipsis = true;
			this.rsLabel8.AutoSize = true;
			this.rsLabel8.Location = new System.Drawing.Point(17, 16);
			this.rsLabel8.Name = "rsLabel8";
			this.rsLabel8.Size = new System.Drawing.Size(78, 13);
			this.rsLabel8.TabIndex = 20;
			this.rsLabel8.Text = "Ngày giao dịch";
			this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel15
			// 
			this.rsLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel15.AutoEllipsis = true;
			this.rsLabel15.AutoSize = true;
			this.rsLabel15.Location = new System.Drawing.Point(17, 107);
			this.rsLabel15.Name = "rsLabel15";
			this.rsLabel15.Size = new System.Drawing.Size(44, 13);
			this.rsLabel15.TabIndex = 18;
			this.rsLabel15.Text = "Ghi chú";
			this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNgay_Ht
			// 
			this.txtNgay_Ht.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.txtNgay_Ht.bAllowEmpty = true;
			this.txtNgay_Ht.bSelectOnFocus = false;
			this.txtNgay_Ht.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.txtNgay_Ht.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNgay_Ht.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.txtNgay_Ht.Location = new System.Drawing.Point(151, 57);
			this.txtNgay_Ht.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNgay_Ht.Mask = "00/00/0000";
			this.txtNgay_Ht.Name = "txtNgay_Ht";
			this.txtNgay_Ht.Size = new System.Drawing.Size(75, 20);
			this.txtNgay_Ht.TabIndex = 4;
			// 
			// txtNgay_Dk_Ht
			// 
			this.txtNgay_Dk_Ht.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.txtNgay_Dk_Ht.bAllowEmpty = true;
			this.txtNgay_Dk_Ht.bSelectOnFocus = false;
			this.txtNgay_Dk_Ht.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.txtNgay_Dk_Ht.Enabled = false;
			this.txtNgay_Dk_Ht.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.txtNgay_Dk_Ht.Location = new System.Drawing.Point(151, 35);
			this.txtNgay_Dk_Ht.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNgay_Dk_Ht.Mask = "00/00/0000";
			this.txtNgay_Dk_Ht.Name = "txtNgay_Dk_Ht";
			this.txtNgay_Dk_Ht.Size = new System.Drawing.Size(75, 20);
			this.txtNgay_Dk_Ht.TabIndex = 2;
			// 
			// txtNgay_Gd
			// 
			this.txtNgay_Gd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.txtNgay_Gd.bAllowEmpty = true;
			this.txtNgay_Gd.bSelectOnFocus = false;
			this.txtNgay_Gd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.txtNgay_Gd.Enabled = false;
			this.txtNgay_Gd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.txtNgay_Gd.Location = new System.Drawing.Point(121, 13);
			this.txtNgay_Gd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNgay_Gd.Mask = "00/00/0000";
			this.txtNgay_Gd.Name = "txtNgay_Gd";
			this.txtNgay_Gd.Size = new System.Drawing.Size(75, 20);
			this.txtNgay_Gd.TabIndex = 0;
			// 
			// txtNote
			// 
			this.txtNote.Location = new System.Drawing.Point(121, 79);
			this.txtNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNote.Name = "txtNote";
			this.txtNote.Size = new System.Drawing.Size(428, 155);
			this.txtNote.TabIndex = 5;
			this.txtNote.Text = "";
			// 
			// frmFinish
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 290);
			this.Controls.Add(this.numSo_Ngay_Ht);
			this.Controls.Add(this.numSo_Ngay_Dk_Ht);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.rsLabel7);
			this.Controls.Add(this.rsLabel8);
			this.Controls.Add(this.rsLabel15);
			this.Controls.Add(this.txtNgay_Ht);
			this.Controls.Add(this.txtNgay_Dk_Ht);
			this.Controls.Add(this.txtNgay_Gd);
			this.Controls.Add(this.txtNote);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmFinish";
			this.Tag = "";
			this.Text = "frmFinish";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBoxNumber numSo_Ngay_Ht;
		private RosySystem.Control.rsTextBoxNumber numSo_Ngay_Dk_Ht;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsLabel rsLabel15;
		private RosySystem.Control.rsDateTime txtNgay_Ht;
		private RosySystem.Control.rsDateTime txtNgay_Dk_Ht;
		private RosySystem.Control.rsDateTime txtNgay_Gd;
		private System.Windows.Forms.RichTextBox txtNote;
	}
}