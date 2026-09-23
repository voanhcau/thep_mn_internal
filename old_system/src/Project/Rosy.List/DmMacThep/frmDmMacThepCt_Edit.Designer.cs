namespace RosyList
{
    partial class frmDmMacThepCt_Edit
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
            this.txtGrade_Name = new RosySystem.Control.rsTextBox();
            this.lbStandard_ID = new RosySystem.Control.rsLabel();
            this.lbGrade_Name = new RosySystem.Control.rsLabel();
            this.lbGrade_ID = new RosySystem.Control.rsLabel();
            this.txtGrade_ID = new RosySystem.Control.rsTextBox();
            this.lbtStandard_Name = new RosySystem.Control.rsLabel();
            this.txtBend_Standard = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtChemis_Standard = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtPull_Standard = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(396, 244);
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(565, 232);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.dteNgay_Ap);
            this.Page1.Controls.Add(this.rsLabel7);
            this.Page1.Controls.Add(this.txtPull_Standard);
            this.Page1.Controls.Add(this.rsLabel6);
            this.Page1.Controls.Add(this.txtChemis_Standard);
            this.Page1.Controls.Add(this.rsLabel4);
            this.Page1.Controls.Add(this.txtBend_Standard);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.txtGrade_ID);
            this.Page1.Controls.Add(this.txtStandard_ID);
            this.Page1.Controls.Add(this.lbGrade_ID);
            this.Page1.Controls.Add(this.txtGrade_Name);
            this.Page1.Controls.Add(this.lbtStandard_Name);
            this.Page1.Controls.Add(this.lbStandard_ID);
            this.Page1.Controls.Add(this.lbGrade_Name);
            this.Page1.Size = new System.Drawing.Size(557, 206);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(557, 206);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 253);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 262);
            this.lblLog.Text = "";
            // 
            // txtStandard_ID
            // 
            this.txtStandard_ID.AutoDropDown = null;
            this.txtStandard_ID.Location = new System.Drawing.Point(118, 69);
            this.txtStandard_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtStandard_ID.MaxLength = 100;
            this.txtStandard_ID.Name = "txtStandard_ID";
            this.txtStandard_ID.Size = new System.Drawing.Size(159, 20);
            this.txtStandard_ID.TabIndex = 2;
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
            // lbStandard_ID
            // 
            this.lbStandard_ID.AutoEllipsis = true;
            this.lbStandard_ID.AutoSize = true;
            this.lbStandard_ID.Location = new System.Drawing.Point(19, 71);
            this.lbStandard_ID.Name = "lbStandard_ID";
            this.lbStandard_ID.Size = new System.Drawing.Size(67, 13);
            this.lbStandard_ID.TabIndex = 19;
            this.lbStandard_ID.Tag = "Standard_ID";
            this.lbStandard_ID.Text = "Standard_ID";
            this.lbStandard_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGrade_Name
            // 
            this.lbGrade_Name.AutoEllipsis = true;
            this.lbGrade_Name.AutoSize = true;
            this.lbGrade_Name.Location = new System.Drawing.Point(19, 49);
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
            this.lbGrade_ID.Location = new System.Drawing.Point(19, 27);
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
            // lbtStandard_Name
            // 
            this.lbtStandard_Name.AutoEllipsis = true;
            this.lbtStandard_Name.AutoSize = true;
            this.lbtStandard_Name.ForeColor = System.Drawing.Color.Blue;
            this.lbtStandard_Name.Location = new System.Drawing.Point(282, 71);
            this.lbtStandard_Name.Name = "lbtStandard_Name";
            this.lbtStandard_Name.Size = new System.Drawing.Size(84, 13);
            this.lbtStandard_Name.TabIndex = 19;
            this.lbtStandard_Name.Tag = "Standard_Name";
            this.lbtStandard_Name.Text = "Standard_Name";
            this.lbtStandard_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBend_Standard
            // 
            this.txtBend_Standard.AutoDropDown = null;
            this.txtBend_Standard.Location = new System.Drawing.Point(118, 116);
            this.txtBend_Standard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtBend_Standard.MaxLength = 100;
            this.txtBend_Standard.Name = "txtBend_Standard";
            this.txtBend_Standard.Size = new System.Drawing.Size(159, 20);
            this.txtBend_Standard.TabIndex = 4;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(19, 118);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(78, 13);
            this.rsLabel2.TabIndex = 22;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Bend Standard";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChemis_Standard
            // 
            this.txtChemis_Standard.AutoDropDown = null;
            this.txtChemis_Standard.Location = new System.Drawing.Point(118, 138);
            this.txtChemis_Standard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtChemis_Standard.MaxLength = 100;
            this.txtChemis_Standard.Name = "txtChemis_Standard";
            this.txtChemis_Standard.Size = new System.Drawing.Size(159, 20);
            this.txtChemis_Standard.TabIndex = 5;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(19, 140);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(87, 13);
            this.rsLabel4.TabIndex = 25;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Chemis Standard";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPull_Standard
            // 
            this.txtPull_Standard.AutoDropDown = null;
            this.txtPull_Standard.Location = new System.Drawing.Point(118, 160);
            this.txtPull_Standard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPull_Standard.MaxLength = 100;
            this.txtPull_Standard.Name = "txtPull_Standard";
            this.txtPull_Standard.Size = new System.Drawing.Size(159, 20);
            this.txtPull_Standard.TabIndex = 6;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(19, 162);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(70, 13);
            this.rsLabel6.TabIndex = 28;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Pull Standard";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(118, 93);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Ap.TabIndex = 3;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(19, 97);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(47, 13);
            this.rsLabel7.TabIndex = 178;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Ngày áp";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmMacThepCt_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 297);
            this.Name = "frmDmMacThepCt_Edit";
            this.Object_ID = "DMMACTHEPCT";
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

		private RosySystem.Control.rsTextBox txtStandard_ID;
		private RosySystem.Control.rsTextBox txtGrade_Name;
		private RosySystem.Control.rsLabel lbStandard_ID;
        private RosySystem.Control.rsLabel lbGrade_Name;
        private RosySystem.Control.rsTextBox txtGrade_ID;
        private RosySystem.Control.rsLabel lbGrade_ID;
        private RosySystem.Control.rsLabel lbtStandard_Name;
		private RosySystem.Control.rsTextBox txtPull_Standard;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsTextBox txtChemis_Standard;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBox txtBend_Standard;
		private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsLabel rsLabel7;
	}
}