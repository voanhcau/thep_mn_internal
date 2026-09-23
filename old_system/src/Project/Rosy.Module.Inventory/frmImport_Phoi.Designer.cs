namespace RosyModule.Inventory
{
	partial class frmImport_Phoi
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
            this.btOk = new RosySystem.Control.rsButton();
            this.btCancel = new RosySystem.Control.rsButton();
            this.txtNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.txtNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbPhoi_Ban = new System.Windows.Forms.RadioButton();
            this.rdbPhoi_Sx = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(133, 201);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 23);
            this.btOk.TabIndex = 5;
            this.btOk.Tag = "Ok";
            this.btOk.Text = "&Thực hiện";
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(226, 201);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 23);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // txtNgay_Ct2
            // 
            this.txtNgay_Ct2.bAllowEmpty = true;
            this.txtNgay_Ct2.bSelectOnFocus = true;
            this.txtNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct2.Location = new System.Drawing.Point(122, 53);
            this.txtNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct2.Mask = "00/00/0000";
            this.txtNgay_Ct2.Name = "txtNgay_Ct2";
            this.txtNgay_Ct2.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct2.TabIndex = 1;
            this.txtNgay_Ct2.Tag = "Ngay_Ct2";
            // 
            // txtNgay_Ct1
            // 
            this.txtNgay_Ct1.bAllowEmpty = true;
            this.txtNgay_Ct1.bSelectOnFocus = true;
            this.txtNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct1.Location = new System.Drawing.Point(122, 31);
            this.txtNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct1.Mask = "00/00/0000";
            this.txtNgay_Ct1.Name = "txtNgay_Ct1";
            this.txtNgay_Ct1.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct1.TabIndex = 0;
            this.txtNgay_Ct1.Tag = "Ngay_Ct1";
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(37, 34);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(46, 13);
            this.rsLabel1.TabIndex = 2;
            this.rsLabel1.Tag = "Ngay_Ct1";
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(37, 56);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(53, 13);
            this.rsLabel2.TabIndex = 2;
            this.rsLabel2.Tag = "Den_Ngay";
            this.rsLabel2.Text = "Đến ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbPhoi_Ban);
            this.groupBox1.Controls.Add(this.rdbPhoi_Sx);
            this.groupBox1.Location = new System.Drawing.Point(40, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 91);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Loại phôi";
            this.groupBox1.Visible = false;
            // 
            // rdbPhoi_Ban
            // 
            this.rdbPhoi_Ban.AutoSize = true;
            this.rdbPhoi_Ban.Location = new System.Drawing.Point(27, 42);
            this.rdbPhoi_Ban.Name = "rdbPhoi_Ban";
            this.rdbPhoi_Ban.Size = new System.Drawing.Size(102, 17);
            this.rdbPhoi_Ban.TabIndex = 1;
            this.rdbPhoi_Ban.Tag = "";
            this.rdbPhoi_Ban.Text = "2. Phôi xuất bán";
            this.rdbPhoi_Ban.UseVisualStyleBackColor = true;
            this.rdbPhoi_Ban.Visible = false;
            // 
            // rdbPhoi_Sx
            // 
            this.rdbPhoi_Sx.AutoSize = true;
            this.rdbPhoi_Sx.Checked = true;
            this.rdbPhoi_Sx.Location = new System.Drawing.Point(27, 19);
            this.rdbPhoi_Sx.Name = "rdbPhoi_Sx";
            this.rdbPhoi_Sx.Size = new System.Drawing.Size(124, 17);
            this.rdbPhoi_Sx.TabIndex = 0;
            this.rdbPhoi_Sx.TabStop = true;
            this.rdbPhoi_Sx.Tag = "";
            this.rdbPhoi_Sx.Text = "1. Phôi xuất sản xuất";
            this.rdbPhoi_Sx.UseVisualStyleBackColor = true;
            // 
            // frmImport_Phoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(358, 236);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtNgay_Ct1);
            this.Controls.Add(this.txtNgay_Ct2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmImport_Phoi";
            this.Text = "frmImportPhoi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsButton btOk;
		private RosySystem.Control.rsButton btCancel;
		private RosySystem.Control.rsDateTime txtNgay_Ct2;
		private RosySystem.Control.rsDateTime txtNgay_Ct1;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbPhoi_Ban;
		private System.Windows.Forms.RadioButton rdbPhoi_Sx;
	}
}