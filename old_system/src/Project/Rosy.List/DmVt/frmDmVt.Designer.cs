namespace RosyList
{
	partial class frmDmVt
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
			this.components = new System.ComponentModel.Container();
			this.btReplace = new RosySystem.Customize.btExit();
			((System.ComponentModel.ISupportInitialize)(this.splitcContent)).BeginInit();
			this.splitcContent.Panel2.SuspendLayout();
			this.splitcContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitcContent
			// 
			// 
			// splitcContent.Panel2
			// 
			this.splitcContent.Panel2.Controls.Add(this.btReplace);
			this.splitcContent.Size = new System.Drawing.Size(807, 569);
			this.splitcContent.SplitterDistance = 505;
			// 
			// btImport
			// 
			this.btImport.Location = new System.Drawing.Point(340, 6);
			// 
			// btReplace
			// 
			this.btReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btReplace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btReplace.ImageKey = "exit2.png";
			this.btReplace.Location = new System.Drawing.Point(504, 7);
			this.btReplace.Name = "btReplace";
			this.btReplace.Size = new System.Drawing.Size(76, 50);
			this.btReplace.TabIndex = 7;
			this.btReplace.Tag = "";
			this.btReplace.Text = "Chuyển mã nhóm";
			this.btReplace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btReplace.UseVisualStyleBackColor = true;
			// 
			// frmDmVt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(807, 569);
			this.Name = "frmDmVt";
			this.Object_ID = "DMVT";
			this.Tag = "frmDmVt";
			this.Text = "frmDmVt";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitcContent.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitcContent)).EndInit();
			this.splitcContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Customize.btExit btReplace;


	}
}