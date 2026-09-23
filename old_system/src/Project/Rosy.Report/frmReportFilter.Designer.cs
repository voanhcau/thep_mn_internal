namespace RosyReport
{
	partial class frmReportFilter
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
			this.txtTitle = new RosySystem.Control.rsTextBox();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.lblTitle = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// txtTitle
			// 
			this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTitle.Location = new System.Drawing.Point(104, 214);
			this.txtTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(434, 20);
			this.txtTitle.TabIndex = 100;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(357, 242);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 101;
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTitle.AutoEllipsis = true;
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(27, 217);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(44, 13);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Tag = "Title";
			this.lblTitle.Text = "Tiêu đề";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmReportFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 294);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.txtTitle);
			this.Name = "frmReportFilter";
			this.Tag = "frmReportFilter";
			this.Text = "frmReportFilter";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private RosySystem.Control.rsTextBox txtTitle;
		private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lblTitle;

	}
}