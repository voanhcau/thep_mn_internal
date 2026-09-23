namespace RosyModule
{
	partial class frmIn_Ct_PxPt
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
			this.rdbA4 = new RosySystem.Control.rsRadioButton();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.gbIn_Tien = new System.Windows.Forms.GroupBox();
			this.rdbLetter = new RosySystem.Control.rsRadioButton();
			this.rdbA5 = new RosySystem.Control.rsRadioButton();
			this.gbIn_Tien.SuspendLayout();
			this.SuspendLayout();
			// 
			// rdbA4
			// 
			this.rdbA4.AutoSize = true;
			this.rdbA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdbA4.Location = new System.Drawing.Point(70, 54);
			this.rdbA4.Name = "rdbA4";
			this.rdbA4.Size = new System.Drawing.Size(37, 17);
			this.rdbA4.TabIndex = 0;
			this.rdbA4.Tag = "";
			this.rdbA4.Text = "A4";
			this.rdbA4.UnChecked = true;
			this.rdbA4.UseVisualStyleBackColor = true;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(109, 147);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 45);
			this.btgAccept.TabIndex = 10;
			// 
			// gbIn_Tien
			// 
			this.gbIn_Tien.Controls.Add(this.rdbLetter);
			this.gbIn_Tien.Controls.Add(this.rdbA5);
			this.gbIn_Tien.Controls.Add(this.rdbA4);
			this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
			this.gbIn_Tien.Name = "gbIn_Tien";
			this.gbIn_Tien.Size = new System.Drawing.Size(259, 122);
			this.gbIn_Tien.TabIndex = 0;
			this.gbIn_Tien.TabStop = false;
			this.gbIn_Tien.Tag = "";
			this.gbIn_Tien.Text = "Chọn mẫu in";
			// 
			// rdbLetter
			// 
			this.rdbLetter.AutoSize = true;
			this.rdbLetter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdbLetter.Location = new System.Drawing.Point(70, 87);
			this.rdbLetter.Name = "rdbLetter";
			this.rdbLetter.Size = new System.Drawing.Size(51, 17);
			this.rdbLetter.TabIndex = 2;
			this.rdbLetter.Tag = "";
			this.rdbLetter.Text = "Letter";
			this.rdbLetter.UnChecked = true;
			this.rdbLetter.UseVisualStyleBackColor = true;
			// 
			// rdbA5
			// 
			this.rdbA5.AutoSize = true;
			this.rdbA5.Checked = true;
			this.rdbA5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdbA5.Location = new System.Drawing.Point(70, 19);
			this.rdbA5.Name = "rdbA5";
			this.rdbA5.Size = new System.Drawing.Size(37, 17);
			this.rdbA5.TabIndex = 2;
			this.rdbA5.TabStop = true;
			this.rdbA5.Tag = "";
			this.rdbA5.Text = "A5";
			this.rdbA5.UnChecked = false;
			this.rdbA5.UseVisualStyleBackColor = true;
			// 
			// frmIn_Ct_PxPt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(302, 204);
			this.Controls.Add(this.gbIn_Tien);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmIn_Ct_PxPt";
			this.Tag = "";
			this.Text = "Chọn phiếu";
			this.gbIn_Tien.ResumeLayout(false);
			this.gbIn_Tien.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsRadioButton rdbA4;
        public System.Windows.Forms.GroupBox gbIn_Tien;
		public RosySystem.Control.rsRadioButton rdbA5;
		public RosySystem.Control.rsRadioButton rdbLetter;
	}
}