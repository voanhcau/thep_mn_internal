namespace RosyModule.Manufactory
{
	partial class frmDmNangSuat_Edit
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
            this.txtMa_Size = new RosySystem.Control.rsTextBox();
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.numNang_Suat = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.numHe_So = new RosySystem.Control.rsTextBoxNumber();
            this.txtGrade_ID = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.lblGrade_Name = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(408, 201);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(639, 185);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtGrade_ID);
            this.Page1.Controls.Add(this.lblGrade_Name);
            this.Page1.Controls.Add(this.rsLabel3);
            this.Page1.Controls.Add(this.dteNgay_Ap);
            this.Page1.Controls.Add(this.rsLabel6);
            this.Page1.Controls.Add(this.numHe_So);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.numNang_Suat);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.txtMa_Size);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Size = new System.Drawing.Size(631, 159);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(631, 159);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 212);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(45, 221);
            this.lblLog.Text = "";
            // 
            // txtMa_Size
            // 
            this.txtMa_Size.AutoDropDown = null;
            this.txtMa_Size.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Size.Location = new System.Drawing.Point(129, 22);
            this.txtMa_Size.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Size.MaxLength = 20;
            this.txtMa_Size.Name = "txtMa_Size";
            this.txtMa_Size.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Size.TabIndex = 0;
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(16, 22);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(43, 13);
            this.lbMa_Kho.TabIndex = 20;
            this.lbMa_Kho.Tag = "Ma_Size";
            this.lbMa_Kho.Text = "Mã size";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNang_Suat
            // 
            this.numNang_Suat.AutoDropDown = null;
            this.numNang_Suat.bFormat = true;
            this.numNang_Suat.Location = new System.Drawing.Point(129, 76);
            this.numNang_Suat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numNang_Suat.Name = "numNang_Suat";
            this.numNang_Suat.Scale = 2;
            this.numNang_Suat.Size = new System.Drawing.Size(120, 20);
            this.numNang_Suat.TabIndex = 2;
            this.numNang_Suat.Tag = "";
            this.numNang_Suat.Text = "0.00";
            this.numNang_Suat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNang_Suat.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(16, 79);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(56, 13);
            this.rsLabel1.TabIndex = 117;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Năng suất";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(16, 135);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(47, 13);
            this.rsLabel6.TabIndex = 119;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Ngày áp";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(129, 130);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ap.TabIndex = 4;
            this.dteNgay_Ap.Tag = "Ngay_Ct";
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(16, 101);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(35, 13);
            this.rsLabel2.TabIndex = 117;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Hệ số";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numHe_So
            // 
            this.numHe_So.AutoDropDown = null;
            this.numHe_So.bFormat = true;
            this.numHe_So.Location = new System.Drawing.Point(129, 98);
            this.numHe_So.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numHe_So.Name = "numHe_So";
            this.numHe_So.Scale = 2;
            this.numHe_So.Size = new System.Drawing.Size(120, 20);
            this.numHe_So.TabIndex = 3;
            this.numHe_So.Tag = "";
            this.numHe_So.Text = "0.00";
            this.numHe_So.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHe_So.Value = 0D;
            // 
            // txtGrade_ID
            // 
            this.txtGrade_ID.AutoDropDown = null;
            this.txtGrade_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrade_ID.Location = new System.Drawing.Point(129, 44);
            this.txtGrade_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGrade_ID.MaxLength = 20;
            this.txtGrade_ID.Name = "txtGrade_ID";
            this.txtGrade_ID.Size = new System.Drawing.Size(120, 20);
            this.txtGrade_ID.TabIndex = 1;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(16, 44);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(52, 13);
            this.rsLabel3.TabIndex = 122;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Mác thép";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGrade_Name
            // 
            this.lblGrade_Name.AutoEllipsis = true;
            this.lblGrade_Name.AutoSize = true;
            this.lblGrade_Name.ForeColor = System.Drawing.Color.Blue;
            this.lblGrade_Name.Location = new System.Drawing.Point(254, 47);
            this.lblGrade_Name.Name = "lblGrade_Name";
            this.lblGrade_Name.Size = new System.Drawing.Size(52, 13);
            this.lblGrade_Name.TabIndex = 122;
            this.lblGrade_Name.Tag = "";
            this.lblGrade_Name.Text = "Mác thép";
            this.lblGrade_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmNangSuat_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(651, 262);
            this.Name = "frmDmNangSuat_Edit";
            this.Object_ID = "LENHSANXUAT";
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

        private RosySystem.Control.rsTextBox txtMa_Size;
        private RosySystem.Control.rsLabel lbMa_Kho;
        private RosySystem.Control.rsTextBoxNumber numNang_Suat;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsTextBox txtGrade_ID;
        private RosySystem.Control.rsLabel lblGrade_Name;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBoxNumber numHe_So;
        private RosySystem.Control.rsLabel rsLabel2;

	}
}