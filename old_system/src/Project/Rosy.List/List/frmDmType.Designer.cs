namespace RosyList
{
	partial class frmDmType
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
			this.cboType = new RosySystem.Control.rsComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.splitcContent.Panel2.SuspendLayout();
			this.splitcContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitcContent
			// 
			// 
			// splitcContent.Panel2
			// 
			this.splitcContent.Panel2.Controls.Add(this.label1);
			this.splitcContent.Panel2.Controls.Add(this.cboType);
			this.splitcContent.Size = new System.Drawing.Size(792, 569);
			this.splitcContent.SplitterDistance = 505;
			// 
			// cboType
			// 
			this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cboType.FormattingEnabled = true;
			this.cboType.Location = new System.Drawing.Point(645, 17);
			this.cboType.Name = "cboType";
			this.cboType.Size = new System.Drawing.Size(135, 21);
			this.cboType.TabIndex = 7;
			this.cboType.TabStop = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(597, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Type";
			// 
			// frmDmType
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 569);
			this.Name = "frmDmType";
			this.Object_ID = "DMTYPE";
			this.Tag = "frmDmType, F2, F3, F6, F8, ESC";
			this.Text = "frmDmType";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitcContent.Panel2.ResumeLayout(false);
			this.splitcContent.Panel2.PerformLayout();
			this.splitcContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsComboBox cboType;
		private System.Windows.Forms.Label label1;


	}
}