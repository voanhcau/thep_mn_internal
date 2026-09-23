namespace RosyList
{
    partial class frmDmMacThep_Edit
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
            this.txtGrade_Name = new RosySystem.Control.rsTextBox();
            this.lbGrade_Name = new RosySystem.Control.rsLabel();
            this.lbGrade_ID = new RosySystem.Control.rsLabel();
            this.txtGrade_ID = new RosySystem.Control.rsTextBox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(291, 125);
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(460, 113);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtGrade_ID);
            this.Page1.Controls.Add(this.lbGrade_ID);
            this.Page1.Controls.Add(this.txtGrade_Name);
            this.Page1.Controls.Add(this.lbGrade_Name);
            this.Page1.Size = new System.Drawing.Size(452, 87);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(557, 179);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 134);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 143);
            this.lblLog.Text = "";
            // 
            // txtGrade_Name
            // 
            this.txtGrade_Name.AutoDropDown = null;
            this.txtGrade_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrade_Name.Location = new System.Drawing.Point(118, 47);
            this.txtGrade_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGrade_Name.MaxLength = 20;
            this.txtGrade_Name.Name = "txtGrade_Name";
            this.txtGrade_Name.Size = new System.Drawing.Size(159, 20);
            this.txtGrade_Name.TabIndex = 1;
            // 
            // lbGrade_Name
            // 
            this.lbGrade_Name.AutoEllipsis = true;
            this.lbGrade_Name.AutoSize = true;
            this.lbGrade_Name.Location = new System.Drawing.Point(7, 49);
            this.lbGrade_Name.Name = "lbGrade_Name";
            this.lbGrade_Name.Size = new System.Drawing.Size(70, 13);
            this.lbGrade_Name.TabIndex = 20;
            this.lbGrade_Name.Tag = "Grade_Name";
            this.lbGrade_Name.Text = "Grade_Name";
            this.lbGrade_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGrade_ID
            // 
            this.lbGrade_ID.AutoEllipsis = true;
            this.lbGrade_ID.AutoSize = true;
            this.lbGrade_ID.Location = new System.Drawing.Point(7, 27);
            this.lbGrade_ID.Name = "lbGrade_ID";
            this.lbGrade_ID.Size = new System.Drawing.Size(53, 13);
            this.lbGrade_ID.TabIndex = 19;
            this.lbGrade_ID.Tag = "Grade_ID";
            this.lbGrade_ID.Text = "Grade_ID";
            this.lbGrade_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGrade_ID
            // 
            this.txtGrade_ID.AutoDropDown = null;
            this.txtGrade_ID.Location = new System.Drawing.Point(118, 25);
            this.txtGrade_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGrade_ID.MaxLength = 100;
            this.txtGrade_ID.Name = "txtGrade_ID";
            this.txtGrade_ID.Size = new System.Drawing.Size(159, 20);
            this.txtGrade_ID.TabIndex = 0;
            // 
            // frmDmMacThep_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 178);
            this.Name = "frmDmMacThep_Edit";
            this.Object_ID = "DMMACTHEP";
            this.Tag = "frmDmMacThep, ESC";
            this.Text = "frmDmMacThep";
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

        private RosySystem.Control.rsTextBox txtGrade_Name;
        private RosySystem.Control.rsLabel lbGrade_Name;
        private RosySystem.Control.rsTextBox txtGrade_ID;
        private RosySystem.Control.rsLabel lbGrade_ID;
	}
}