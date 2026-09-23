namespace RosyModule.General
{
    partial class frmKetChuyen_Run
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
			this.numThang1 = new RosySystem.Control.rsTextBoxNumber();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.numThang2 = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// numThang1
			// 
			this.numThang1.bFormat = true;
			this.numThang1.Location = new System.Drawing.Point(90, 26);
			this.numThang1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numThang1.Name = "numThang1";
			this.numThang1.Scale = 0;
			this.numThang1.Size = new System.Drawing.Size(39, 20);
			this.numThang1.TabIndex = 0;
			this.numThang1.Text = "0";
			this.numThang1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numThang1.Value = 0D;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(210, 77);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(186, 42);
			this.btgAccept.TabIndex = 2;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(27, 26);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(50, 13);
			this.rsLabel6.TabIndex = 34;
			this.rsLabel6.Tag = "Thang1";
			this.rsLabel6.Text = "Từ tháng";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numThang2
			// 
			this.numThang2.bFormat = true;
			this.numThang2.Location = new System.Drawing.Point(90, 55);
			this.numThang2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numThang2.Name = "numThang2";
			this.numThang2.Scale = 0;
			this.numThang2.Size = new System.Drawing.Size(39, 20);
			this.numThang2.TabIndex = 1;
			this.numThang2.Text = "0";
			this.numThang2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numThang2.Value = 0D;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(27, 57);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(57, 13);
			this.rsLabel1.TabIndex = 34;
			this.rsLabel1.Tag = "Thang2";
			this.rsLabel1.Text = "Đến tháng";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmKetChuyen_Run
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 126);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.numThang2);
			this.Controls.Add(this.numThang1);
			this.Name = "frmKetChuyen_Run";
			this.Tag = "frmKetChuyen, ESC";
			this.Text = "frmKetChuyen";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsLabel rsLabel1;
        public RosySystem.Control.rsTextBoxNumber numThang2;
        public RosySystem.Control.rsTextBoxNumber numThang1;

	}
}