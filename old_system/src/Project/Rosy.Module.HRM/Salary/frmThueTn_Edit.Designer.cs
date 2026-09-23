namespace RosyModule.Salary
{
	partial class frmThueTn_Edit
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
			this.txtBang_Thue = new RosySystem.Control.rsTextBox();
			this.lblTk = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numMuc_Tn1 = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.numMuc_Tn2 = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.numTy_Le = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// txtBang_Thue
			// 
			this.txtBang_Thue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBang_Thue.Location = new System.Drawing.Point(127, 24);
			this.txtBang_Thue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtBang_Thue.MaxLength = 20;
			this.txtBang_Thue.Name = "txtBang_Thue";
			this.txtBang_Thue.Size = new System.Drawing.Size(96, 20);
			this.txtBang_Thue.TabIndex = 0;
			// 
			// lblTk
			// 
			this.lblTk.AutoEllipsis = true;
			this.lblTk.AutoSize = true;
			this.lblTk.Location = new System.Drawing.Point(25, 27);
			this.lblTk.Name = "lblTk";
			this.lblTk.Size = new System.Drawing.Size(56, 13);
			this.lblTk.TabIndex = 70;
			this.lblTk.Tag = "Ma_Tn";
			this.lblTk.Text = "Bảng thuế";
			this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(356, 121);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(182, 44);
			this.btgAccept.TabIndex = 5;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(25, 49);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(43, 13);
			this.rsLabel1.TabIndex = 70;
			this.rsLabel1.Tag = "Tu_Muc";
			this.rsLabel1.Text = "Từ mức";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numMuc_Tn1
			// 
			this.numMuc_Tn1.bFormat = true;
			this.numMuc_Tn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numMuc_Tn1.Location = new System.Drawing.Point(127, 46);
			this.numMuc_Tn1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numMuc_Tn1.MaxLength = 20;
			this.numMuc_Tn1.Name = "numMuc_Tn1";
			this.numMuc_Tn1.Scale = 2;
			this.numMuc_Tn1.Size = new System.Drawing.Size(139, 20);
			this.numMuc_Tn1.TabIndex = 1;
			this.numMuc_Tn1.Text = "0.00";
			this.numMuc_Tn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMuc_Tn1.Value = 0D;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(25, 71);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(50, 13);
			this.rsLabel2.TabIndex = 70;
			this.rsLabel2.Tag = "Den_Muc";
			this.rsLabel2.Text = "Đến mức";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numMuc_Tn2
			// 
			this.numMuc_Tn2.bFormat = true;
			this.numMuc_Tn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numMuc_Tn2.Location = new System.Drawing.Point(127, 68);
			this.numMuc_Tn2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numMuc_Tn2.MaxLength = 20;
			this.numMuc_Tn2.Name = "numMuc_Tn2";
			this.numMuc_Tn2.Scale = 2;
			this.numMuc_Tn2.Size = new System.Drawing.Size(139, 20);
			this.numMuc_Tn2.TabIndex = 2;
			this.numMuc_Tn2.Text = "0.00";
			this.numMuc_Tn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMuc_Tn2.Value = 0D;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(25, 93);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(54, 13);
			this.rsLabel3.TabIndex = 70;
			this.rsLabel3.Tag = "Ty_Le_Thue";
			this.rsLabel3.Text = "Tỷ lệ thuế";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTy_Le
			// 
			this.numTy_Le.bFormat = true;
			this.numTy_Le.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numTy_Le.Location = new System.Drawing.Point(127, 90);
			this.numTy_Le.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTy_Le.MaxLength = 20;
			this.numTy_Le.Name = "numTy_Le";
			this.numTy_Le.Scale = 2;
			this.numTy_Le.Size = new System.Drawing.Size(96, 20);
			this.numTy_Le.TabIndex = 3;
			this.numTy_Le.Text = "0.00";
			this.numTy_Le.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTy_Le.Value = 0D;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(228, 93);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(21, 13);
			this.rsLabel4.TabIndex = 4;
			this.rsLabel4.Tag = "";
			this.rsLabel4.Text = "(%)";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmThueTn_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 171);
			this.Controls.Add(this.numTy_Le);
			this.Controls.Add(this.numMuc_Tn2);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.numMuc_Tn1);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.txtBang_Thue);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.lblTk);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmThueTn_Edit";
			this.Text = "frmDmTn_Edit";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtBang_Thue;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxNumber numMuc_Tn1;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBoxNumber numMuc_Tn2;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBoxNumber numTy_Le;
		private RosySystem.Control.rsLabel rsLabel4;
	}
}