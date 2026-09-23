namespace RosyList
{
    partial class frmDmStandard_Edit
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
            this.txtStandard_ID = new RosySystem.Control.rsTextBox();
            this.txtStandard_Name = new RosySystem.Control.rsTextBox();
            this.lbStandard_ID = new RosySystem.Control.rsLabel();
            this.lbStandard_Name = new RosySystem.Control.rsLabel();
            this.lbUsed = new RosySystem.Control.rsLabel();
            this.chkUsed = new RosySystem.Control.rsCheckbox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(347, 153);
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(516, 141);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chkUsed);
            this.Page1.Controls.Add(this.txtStandard_ID);
            this.Page1.Controls.Add(this.txtStandard_Name);
            this.Page1.Controls.Add(this.lbUsed);
            this.Page1.Controls.Add(this.lbStandard_ID);
            this.Page1.Controls.Add(this.lbStandard_Name);
            this.Page1.Size = new System.Drawing.Size(508, 115);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(508, 115);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 162);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 171);
            this.lblLog.Text = "";
            // 
            // txtStandard_ID
            // 
            this.txtStandard_ID.AutoDropDown = null;
            this.txtStandard_ID.Location = new System.Drawing.Point(118, 23);
            this.txtStandard_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtStandard_ID.MaxLength = 100;
            this.txtStandard_ID.Name = "txtStandard_ID";
            this.txtStandard_ID.Size = new System.Drawing.Size(159, 20);
            this.txtStandard_ID.TabIndex = 0;
            // 
            // txtStandard_Name
            // 
            this.txtStandard_Name.AutoDropDown = null;
            this.txtStandard_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStandard_Name.Location = new System.Drawing.Point(118, 47);
            this.txtStandard_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtStandard_Name.MaxLength = 20;
            this.txtStandard_Name.Name = "txtStandard_Name";
            this.txtStandard_Name.Size = new System.Drawing.Size(159, 20);
            this.txtStandard_Name.TabIndex = 1;
            // 
            // lbStandard_ID
            // 
            this.lbStandard_ID.AutoEllipsis = true;
            this.lbStandard_ID.AutoSize = true;
            this.lbStandard_ID.Location = new System.Drawing.Point(7, 25);
            this.lbStandard_ID.Name = "lbStandard_ID";
            this.lbStandard_ID.Size = new System.Drawing.Size(67, 13);
            this.lbStandard_ID.TabIndex = 19;
            this.lbStandard_ID.Tag = "Standard_ID";
            this.lbStandard_ID.Text = "Standard_ID";
            this.lbStandard_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStandard_Name
            // 
            this.lbStandard_Name.AutoEllipsis = true;
            this.lbStandard_Name.AutoSize = true;
            this.lbStandard_Name.Location = new System.Drawing.Point(7, 49);
            this.lbStandard_Name.Name = "lbStandard_Name";
            this.lbStandard_Name.Size = new System.Drawing.Size(84, 13);
            this.lbStandard_Name.TabIndex = 20;
            this.lbStandard_Name.Tag = "Standard_Name";
            this.lbStandard_Name.Text = "Standard_Name";
            this.lbStandard_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUsed
            // 
            this.lbUsed.AutoEllipsis = true;
            this.lbUsed.AutoSize = true;
            this.lbUsed.Location = new System.Drawing.Point(7, 74);
            this.lbUsed.Name = "lbUsed";
            this.lbUsed.Size = new System.Drawing.Size(32, 13);
            this.lbUsed.TabIndex = 19;
            this.lbUsed.Tag = "Used";
            this.lbUsed.Text = "Used";
            this.lbUsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkUsed
            // 
            this.chkUsed.AutoSize = true;
            this.chkUsed.Location = new System.Drawing.Point(118, 70);
            this.chkUsed.Name = "chkUsed";
            this.chkUsed.Size = new System.Drawing.Size(51, 17);
            this.chkUsed.TabIndex = 2;
            this.chkUsed.Text = "Used";
            this.chkUsed.UseVisualStyleBackColor = true;
            // 
            // frmDmStandard_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 206);
            this.Name = "frmDmStandard_Edit";
            this.Object_ID = "DMSTANDARD";
            this.Tag = "frmDmStandard, ESC";
            this.Text = "frmDmStandard";
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

		private RosySystem.Control.rsTextBox txtStandard_ID;
		private RosySystem.Control.rsTextBox txtStandard_Name;
		private RosySystem.Control.rsLabel lbStandard_ID;
        private RosySystem.Control.rsLabel lbStandard_Name;
        private RosySystem.Control.rsLabel lbUsed;
        private RosySystem.Control.rsCheckbox chkUsed;
	}
}