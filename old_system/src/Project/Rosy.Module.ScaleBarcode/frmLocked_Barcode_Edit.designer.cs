namespace RosyModule.ScaleBarcode
{
	partial class frmLocked_Barcode_Edit
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
			this.txtNgay_Locked1 = new RosySystem.Control.rsDateTime();
			this.lblControl1 = new RosySystem.Control.rsLabel();
			this.txtNgay_Locked2 = new RosySystem.Control.rsDateTime();
			this.lblControl2 = new RosySystem.Control.rsLabel();
			this.lblControl3 = new RosySystem.Control.rsLabel();
			this.lbtControl1 = new RosySystem.Control.rsLabelName();
			this.enuLocked_Type = new RosySystem.Control.rsTextBoxEnum();
			this.txtNam = new RosySystem.Control.rsTextBox();
			this.lblControl4 = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(131, 108);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 4;
			// 
			// txtNgay_Locked1
			// 
			this.txtNgay_Locked1.bAllowEmpty = true;
			this.txtNgay_Locked1.bSelectOnFocus = true;
			this.txtNgay_Locked1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.txtNgay_Locked1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.txtNgay_Locked1.Location = new System.Drawing.Point(131, 31);
			this.txtNgay_Locked1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNgay_Locked1.Mask = "00/00/0000";
			this.txtNgay_Locked1.Name = "txtNgay_Locked1";
			this.txtNgay_Locked1.Size = new System.Drawing.Size(78, 20);
			this.txtNgay_Locked1.TabIndex = 1;
			// 
			// lblControl1
			// 
			this.lblControl1.AutoEllipsis = true;
			this.lblControl1.AutoSize = true;
			this.lblControl1.Location = new System.Drawing.Point(24, 34);
			this.lblControl1.Name = "lblControl1";
			this.lblControl1.Size = new System.Drawing.Size(70, 13);
			this.lblControl1.TabIndex = 9;
			this.lblControl1.Tag = "Ngay_Locked1";
			this.lblControl1.Text = "Khóa từ ngày";
			this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNgay_Locked2
			// 
			this.txtNgay_Locked2.bAllowEmpty = true;
			this.txtNgay_Locked2.bSelectOnFocus = true;
			this.txtNgay_Locked2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.txtNgay_Locked2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.txtNgay_Locked2.Location = new System.Drawing.Point(131, 53);
			this.txtNgay_Locked2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNgay_Locked2.Mask = "00/00/0000";
			this.txtNgay_Locked2.Name = "txtNgay_Locked2";
			this.txtNgay_Locked2.Size = new System.Drawing.Size(78, 20);
			this.txtNgay_Locked2.TabIndex = 2;
			// 
			// lblControl2
			// 
			this.lblControl2.AutoEllipsis = true;
			this.lblControl2.AutoSize = true;
			this.lblControl2.Location = new System.Drawing.Point(24, 56);
			this.lblControl2.Name = "lblControl2";
			this.lblControl2.Size = new System.Drawing.Size(80, 13);
			this.lblControl2.TabIndex = 9;
			this.lblControl2.Tag = "Ngay_Locked2";
			this.lblControl2.Text = "Khóa đến ngày";
			this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblControl3
			// 
			this.lblControl3.AutoEllipsis = true;
			this.lblControl3.AutoSize = true;
			this.lblControl3.Location = new System.Drawing.Point(24, 78);
			this.lblControl3.Name = "lblControl3";
			this.lblControl3.Size = new System.Drawing.Size(55, 13);
			this.lblControl3.TabIndex = 9;
			this.lblControl3.Tag = "Lock_Type";
			this.lblControl3.Text = "Kiểu khóa";
			this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtControl1
			// 
			this.lbtControl1.AutoSize = true;
			this.lbtControl1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtControl1.Location = new System.Drawing.Point(159, 79);
			this.lbtControl1.Name = "lbtControl1";
			this.lbtControl1.Size = new System.Drawing.Size(75, 13);
			this.lbtControl1.TabIndex = 11;
			this.lbtControl1.Text = "* - Khóa tất cả";
			this.lbtControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// enuLocked_Type
			// 
			this.enuLocked_Type.AutoDropDown = null;
			this.enuLocked_Type.InputMask = "*";
			this.enuLocked_Type.Location = new System.Drawing.Point(131, 75);
			this.enuLocked_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.enuLocked_Type.Name = "enuLocked_Type";
			this.enuLocked_Type.Size = new System.Drawing.Size(23, 20);
			this.enuLocked_Type.TabIndex = 3;
			this.enuLocked_Type.Text = "*";
			// 
			// txtNam
			// 
			this.txtNam.AutoDropDown = null;
			this.txtNam.Enabled = false;
			this.txtNam.Location = new System.Drawing.Point(131, 9);
			this.txtNam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNam.Name = "txtNam";
			this.txtNam.Size = new System.Drawing.Size(42, 20);
			this.txtNam.TabIndex = 0;
			// 
			// lblControl4
			// 
			this.lblControl4.AutoEllipsis = true;
			this.lblControl4.AutoSize = true;
			this.lblControl4.Enabled = false;
			this.lblControl4.Location = new System.Drawing.Point(24, 12);
			this.lblControl4.Name = "lblControl4";
			this.lblControl4.Size = new System.Drawing.Size(55, 13);
			this.lblControl4.TabIndex = 9;
			this.lblControl4.Tag = "Nam";
			this.lblControl4.Text = "Khóa năm";
			this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmLocked_Barcode_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 157);
			this.Controls.Add(this.txtNam);
			this.Controls.Add(this.enuLocked_Type);
			this.Controls.Add(this.lbtControl1);
			this.Controls.Add(this.lblControl3);
			this.Controls.Add(this.lblControl2);
			this.Controls.Add(this.lblControl4);
			this.Controls.Add(this.lblControl1);
			this.Controls.Add(this.txtNgay_Locked2);
			this.Controls.Add(this.txtNgay_Locked1);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmLocked_Barcode_Edit";
			this.Tag = "frmLocked_Barcode, ESC";
			this.Text = "frmLocked_Barcode";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsDateTime txtNgay_Locked1;
		private RosySystem.Control.rsLabel lblControl1;
		private RosySystem.Control.rsDateTime txtNgay_Locked2;
		private RosySystem.Control.rsLabel lblControl2;
		private RosySystem.Control.rsLabel lblControl3;
		private RosySystem.Control.rsLabelName lbtControl1;
		private RosySystem.Control.rsTextBoxEnum enuLocked_Type;
		private RosySystem.Control.rsTextBox txtNam;
		private RosySystem.Control.rsLabel lblControl4;
	}
}