namespace RosyList
{
	partial class frmDmCL_Edit
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
			this.txtTen_CL = new RosySystem.Control.rsTextBox();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.txtMa_CL = new RosySystem.Control.rsTextBox();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(395, 158);
			this.btgAccept.Size = new System.Drawing.Size(179, 42);
			this.btgAccept.TabIndex = 1;
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(565, 145);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.txtMa_CL);
			this.Page1.Controls.Add(this.rsLabel7);
			this.Page1.Controls.Add(this.rsLabel4);
			this.Page1.Controls.Add(this.txtTen_CL);
			this.Page1.Size = new System.Drawing.Size(557, 119);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(557, 119);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 166);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 175);
			this.lblLog.Text = "";
			// 
			// txtTen_CL
			// 
			this.txtTen_CL.Location = new System.Drawing.Point(116, 60);
			this.txtTen_CL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_CL.Name = "txtTen_CL";
			this.txtTen_CL.Size = new System.Drawing.Size(363, 20);
			this.txtTen_CL.TabIndex = 1;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(19, 63);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(79, 13);
			this.rsLabel4.TabIndex = 30;
			this.rsLabel4.Tag = "Ten_CL";
			this.rsLabel4.Text = "Tên chất lượng";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Location = new System.Drawing.Point(19, 41);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(75, 13);
			this.rsLabel7.TabIndex = 39;
			this.rsLabel7.Tag = "Ma_CL";
			this.rsLabel7.Text = "Mã chất lượng";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_CL
			// 
			this.txtMa_CL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_CL.Location = new System.Drawing.Point(116, 38);
			this.txtMa_CL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_CL.Name = "txtMa_CL";
			this.txtMa_CL.Size = new System.Drawing.Size(136, 20);
			this.txtMa_CL.TabIndex = 0;
			// 
			// frmDmCL_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(589, 207);
			this.Name = "frmDmCL_Edit";
			this.Object_ID = "DMCL";
			this.Tag = "frmDmCL, ESC";
			this.Text = "frmDmCL";
			this.tabEdit.ResumeLayout(false);
			this.Page1.ResumeLayout(false);
			this.Page1.PerformLayout();
			this.Page2.ResumeLayout(false);
			this.Page2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtTen_CL;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBox txtMa_CL;

	}
}