namespace RosyList
{
    partial class frmDmCaSX
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
            this.btCreateCa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitcContent)).BeginInit();
            this.splitcContent.Panel2.SuspendLayout();
            this.splitcContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitcContent
            // 
            this.splitcContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // splitcContent.Panel2
            // 
            this.splitcContent.Panel2.Controls.Add(this.btCreateCa);
            this.splitcContent.Panel2.Controls.Add(this.btFilter);
            this.splitcContent.Size = new System.Drawing.Size(795, 569);
            this.splitcContent.SplitterDistance = 497;
            this.splitcContent.SplitterWidth = 6;
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(340, 16);
            this.btImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // btFilter
            // 
            this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btFilter.Location = new System.Drawing.Point(502, 17);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(69, 41);
            this.btFilter.TabIndex = 7;
            this.btFilter.Text = "Lọc dữ liệu";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // btCreateCa
            // 
            this.btCreateCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreateCa.Location = new System.Drawing.Point(575, 17);
            this.btCreateCa.Name = "btCreateCa";
            this.btCreateCa.Size = new System.Drawing.Size(69, 41);
            this.btCreateCa.TabIndex = 7;
            this.btCreateCa.Text = "Tạo ca tự động";
            this.btCreateCa.UseVisualStyleBackColor = true;
            // 
            // frmDmCaSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 569);
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.Name = "frmDmCaSX";
            this.Object_ID = "DMCASX";
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
        private System.Windows.Forms.Button btCreateCa;

	}
}