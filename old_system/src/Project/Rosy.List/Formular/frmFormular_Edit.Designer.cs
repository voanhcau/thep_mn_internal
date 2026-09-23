namespace RosyList
{
	partial class frmFormular_Edit
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
			this.txtCondition = new RosySystem.Control.rsTextBox();
			this.txtDescription = new RosySystem.Control.rsTextBox();
			this.lbStandard_ID = new RosySystem.Control.rsLabel();
			this.lbGrade_Name = new RosySystem.Control.rsLabel();
			this.lbGrade_ID = new RosySystem.Control.rsLabel();
			this.txtFormular_ID = new RosySystem.Control.rsTextBox();
			this.txtFormular = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(398, 193);
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			this.btgAccept.TabIndex = 1;
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(567, 181);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.txtFormular);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Controls.Add(this.txtFormular_ID);
			this.Page1.Controls.Add(this.txtCondition);
			this.Page1.Controls.Add(this.lbGrade_ID);
			this.Page1.Controls.Add(this.txtDescription);
			this.Page1.Controls.Add(this.lbStandard_ID);
			this.Page1.Controls.Add(this.lbGrade_Name);
			this.Page1.Size = new System.Drawing.Size(559, 155);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(559, 155);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 202);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 211);
			this.lblLog.Text = "";
			// 
			// txtCondition
			// 
			this.txtCondition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCondition.Location = new System.Drawing.Point(99, 78);
			this.txtCondition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtCondition.MaxLength = 200;
			this.txtCondition.Name = "txtCondition";
			this.txtCondition.Size = new System.Drawing.Size(423, 20);
			this.txtCondition.TabIndex = 2;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(99, 56);
			this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDescription.MaxLength = 200;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(423, 20);
			this.txtDescription.TabIndex = 1;
			// 
			// lbStandard_ID
			// 
			this.lbStandard_ID.AutoEllipsis = true;
			this.lbStandard_ID.AutoSize = true;
			this.lbStandard_ID.Location = new System.Drawing.Point(32, 80);
			this.lbStandard_ID.Name = "lbStandard_ID";
			this.lbStandard_ID.Size = new System.Drawing.Size(51, 13);
			this.lbStandard_ID.TabIndex = 19;
			this.lbStandard_ID.Tag = "";
			this.lbStandard_ID.Text = "Condition";
			this.lbStandard_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbGrade_Name
			// 
			this.lbGrade_Name.AutoEllipsis = true;
			this.lbGrade_Name.AutoSize = true;
			this.lbGrade_Name.Location = new System.Drawing.Point(32, 58);
			this.lbGrade_Name.Name = "lbGrade_Name";
			this.lbGrade_Name.Size = new System.Drawing.Size(60, 13);
			this.lbGrade_Name.TabIndex = 20;
			this.lbGrade_Name.Tag = "";
			this.lbGrade_Name.Text = "Description";
			this.lbGrade_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbGrade_ID
			// 
			this.lbGrade_ID.AutoEllipsis = true;
			this.lbGrade_ID.AutoSize = true;
			this.lbGrade_ID.Location = new System.Drawing.Point(32, 36);
			this.lbGrade_ID.Name = "lbGrade_ID";
			this.lbGrade_ID.Size = new System.Drawing.Size(61, 13);
			this.lbGrade_ID.TabIndex = 19;
			this.lbGrade_ID.Tag = "";
			this.lbGrade_ID.Text = "Formular ID";
			this.lbGrade_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFormular_ID
			// 
			this.txtFormular_ID.Location = new System.Drawing.Point(99, 34);
			this.txtFormular_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtFormular_ID.MaxLength = 100;
			this.txtFormular_ID.Name = "txtFormular_ID";
			this.txtFormular_ID.Size = new System.Drawing.Size(159, 20);
			this.txtFormular_ID.TabIndex = 0;
			// 
			// txtFormular
			// 
			this.txtFormular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFormular.Location = new System.Drawing.Point(99, 100);
			this.txtFormular.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtFormular.MaxLength = 200;
			this.txtFormular.Name = "txtFormular";
			this.txtFormular.Size = new System.Drawing.Size(423, 20);
			this.txtFormular.TabIndex = 3;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(32, 102);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(47, 13);
			this.rsLabel1.TabIndex = 22;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Formular";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmFormular_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 246);
			this.Name = "frmFormular_Edit";
			this.Object_ID = "FORMULAR_SCALE";
			this.Tag = "frmFormular, ESC";
			this.Text = "frmFormular";
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

		private RosySystem.Control.rsTextBox txtCondition;
		private RosySystem.Control.rsTextBox txtDescription;
		private RosySystem.Control.rsLabel lbStandard_ID;
        private RosySystem.Control.rsLabel lbGrade_Name;
        private RosySystem.Control.rsTextBox txtFormular_ID;
		private RosySystem.Control.rsLabel lbGrade_ID;
		private RosySystem.Control.rsTextBox txtFormular;
		private RosySystem.Control.rsLabel rsLabel1;
	}
}