namespace RosyModule
{
	partial class frmExportExcel_
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
			this.chkOpenFile = new RosySystem.Control.rsCheckbox();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.btPath = new RosySystem.Control.rsButton();
			this.lblPath = new RosySystem.Control.rsLabel();
			this.txtPath = new RosySystem.Control.rsTextBox();
			this.SuspendLayout();
			// 
			// chkOpenFile
			// 
			this.chkOpenFile.AutoSize = true;
			this.chkOpenFile.Checked = true;
			this.chkOpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOpenFile.Location = new System.Drawing.Point(122, 58);
			this.chkOpenFile.Name = "chkOpenFile";
			this.chkOpenFile.Size = new System.Drawing.Size(135, 17);
			this.chkOpenFile.TabIndex = 15;
			this.chkOpenFile.Tag = "Open_File";
			this.chkOpenFile.Text = "Mở file sau khi kết xuất";
			this.chkOpenFile.UseVisualStyleBackColor = true;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(284, 99);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			this.btgAccept.TabIndex = 18;
			// 
			// btPath
			// 
			this.btPath.Location = new System.Drawing.Point(436, 32);
			this.btPath.Name = "btPath";
			this.btPath.Size = new System.Drawing.Size(29, 22);
			this.btPath.TabIndex = 11;
			this.btPath.TabStop = false;
			this.btPath.Text = "...";
			this.btPath.UseVisualStyleBackColor = true;
			// 
			// lblPath
			// 
			this.lblPath.AutoEllipsis = true;
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(19, 35);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(92, 13);
			this.lblPath.TabIndex = 13;
			this.lblPath.Tag = "Path";
			this.lblPath.Text = "Đường dẫn tập tin";
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(122, 33);
			this.txtPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(312, 20);
			this.txtPath.TabIndex = 9;
			// 
			// frmExportExcel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 161);
			this.Controls.Add(this.chkOpenFile);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.btPath);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.txtPath);
			this.Name = "frmExportExcel";
			this.Text = "frmExportExcel";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public RosySystem.Control.rsCheckbox chkOpenFile;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsButton btPath;
		private RosySystem.Control.rsLabel lblPath;
		private RosySystem.Control.rsTextBox txtPath;
	}
}