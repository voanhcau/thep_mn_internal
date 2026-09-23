namespace RosyModule
{
	partial class frmCt_YeuCau
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
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(313, 217);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 45);
			this.btgAccept.TabIndex = 6;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rsLabel6.Location = new System.Drawing.Point(12, 9);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(80, 13);
			this.rsLabel6.TabIndex = 21;
			this.rsLabel6.Tag = "";
			this.rsLabel6.Text = "Chi tiết yêu cầu";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtGhi_Chu
			// 
			this.txtGhi_Chu.AutoDropDown = null;
			this.txtGhi_Chu.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtGhi_Chu.Location = new System.Drawing.Point(97, 9);
			this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtGhi_Chu.MaxLength = 200;
			this.txtGhi_Chu.Multiline = true;
			this.txtGhi_Chu.Name = "txtGhi_Chu";
			this.txtGhi_Chu.Size = new System.Drawing.Size(397, 200);
			this.txtGhi_Chu.TabIndex = 5;
			// 
			// frmCt_YeuCau
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 274);
			this.Controls.Add(this.txtGhi_Chu);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmCt_YeuCau";
			this.Tag = "";
			this.Text = "Chọn phiếu";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsTextBox txtGhi_Chu;
	}
}