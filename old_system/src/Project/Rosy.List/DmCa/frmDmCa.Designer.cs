namespace RosyList
{
	partial class frmDmCa
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
			this.btFilter = new System.Windows.Forms.Button();
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
			this.splitcContent.Panel2.Controls.Add(this.btFilter);
			this.splitcContent.Size = new System.Drawing.Size(795, 569);
			this.splitcContent.SplitterDistance = 505;
			// 
			// btImport
			// 
			this.btImport.Location = new System.Drawing.Point(340, 3);
			// 
			// btFilter
			// 
			this.btFilter.Location = new System.Drawing.Point(516, 4);
			this.btFilter.Name = "btFilter";
			this.btFilter.Size = new System.Drawing.Size(69, 49);
			this.btFilter.TabIndex = 7;
			this.btFilter.Text = "Lọc dữ liệu";
			this.btFilter.UseVisualStyleBackColor = true;
			// 
			// frmDmCa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(795, 569);
			this.Name = "frmDmCa";
			this.Object_ID = "DMCA";
			this.Tag = "frmDmCa";
			this.Text = "frmDmCa";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitcContent.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitcContent)).EndInit();
			this.splitcContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btFilter;

	}
}