namespace RosyList
{
	partial class frmDmNL_Edit
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
            this.txtMac_Thep = new RosySystem.Control.rsTextBox();
            this.txtMa_Nh_Vt = new RosySystem.Control.rsTextBox();
            this.lbTen_Kho = new RosySystem.Control.rsLabel();
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.numDinh_Muc = new RosySystem.Control.rsTextBoxNumber();
            this.lbStt = new RosySystem.Control.rsLabel();
            this.lbtTen_Nh_Vt = new RosySystem.Control.rsLabel();
            this.txtGrade_ID = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtGrade_Name = new RosySystem.Control.rsLabel();
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(377, 193);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(547, 180);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.dteNgay_Ap);
            this.Page1.Controls.Add(this.rsLabel6);
            this.Page1.Controls.Add(this.lbtGrade_Name);
            this.Page1.Controls.Add(this.txtGrade_ID);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.lbtTen_Nh_Vt);
            this.Page1.Controls.Add(this.numDinh_Muc);
            this.Page1.Controls.Add(this.lbStt);
            this.Page1.Controls.Add(this.txtMac_Thep);
            this.Page1.Controls.Add(this.txtMa_Nh_Vt);
            this.Page1.Controls.Add(this.lbTen_Kho);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Size = new System.Drawing.Size(539, 154);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(539, 154);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 201);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 210);
            this.lblLog.Size = new System.Drawing.Size(285, 22);
            this.lblLog.Text = "";
            // 
            // txtMac_Thep
            // 
            this.txtMac_Thep.AutoDropDown = null;
            this.txtMac_Thep.Location = new System.Drawing.Point(115, 67);
            this.txtMac_Thep.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMac_Thep.MaxLength = 100;
            this.txtMac_Thep.Name = "txtMac_Thep";
            this.txtMac_Thep.Size = new System.Drawing.Size(120, 20);
            this.txtMac_Thep.TabIndex = 2;
            // 
            // txtMa_Nh_Vt
            // 
            this.txtMa_Nh_Vt.AutoDropDown = null;
            this.txtMa_Nh_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_Vt.Location = new System.Drawing.Point(115, 22);
            this.txtMa_Nh_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Vt.MaxLength = 20;
            this.txtMa_Nh_Vt.Name = "txtMa_Nh_Vt";
            this.txtMa_Nh_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_Vt.TabIndex = 0;
            // 
            // lbTen_Kho
            // 
            this.lbTen_Kho.AutoEllipsis = true;
            this.lbTen_Kho.AutoSize = true;
            this.lbTen_Kho.Location = new System.Drawing.Point(9, 68);
            this.lbTen_Kho.Name = "lbTen_Kho";
            this.lbTen_Kho.Size = new System.Drawing.Size(56, 13);
            this.lbTen_Kho.TabIndex = 19;
            this.lbTen_Kho.Tag = "";
            this.lbTen_Kho.Text = "Mác Thép";
            this.lbTen_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(9, 22);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(64, 13);
            this.lbMa_Kho.TabIndex = 20;
            this.lbMa_Kho.Tag = "";
            this.lbMa_Kho.Text = "Mã nhóm Vt";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numDinh_Muc
            // 
            this.numDinh_Muc.AutoDropDown = null;
            this.numDinh_Muc.bFormat = true;
            this.numDinh_Muc.Location = new System.Drawing.Point(115, 89);
            this.numDinh_Muc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numDinh_Muc.Name = "numDinh_Muc";
            this.numDinh_Muc.Scale = 4;
            this.numDinh_Muc.Size = new System.Drawing.Size(60, 20);
            this.numDinh_Muc.TabIndex = 3;
            this.numDinh_Muc.Text = "0,0000";
            this.numDinh_Muc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDinh_Muc.Value = 0D;
            // 
            // lbStt
            // 
            this.lbStt.AutoEllipsis = true;
            this.lbStt.AutoSize = true;
            this.lbStt.Location = new System.Drawing.Point(9, 92);
            this.lbStt.Name = "lbStt";
            this.lbStt.Size = new System.Drawing.Size(52, 13);
            this.lbStt.TabIndex = 21;
            this.lbStt.Text = "Định mức";
            this.lbStt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Nh_Vt
            // 
            this.lbtTen_Nh_Vt.AutoEllipsis = true;
            this.lbtTen_Nh_Vt.AutoSize = true;
            this.lbtTen_Nh_Vt.ForeColor = System.Drawing.Color.Red;
            this.lbtTen_Nh_Vt.Location = new System.Drawing.Point(240, 25);
            this.lbtTen_Nh_Vt.Name = "lbtTen_Nh_Vt";
            this.lbtTen_Nh_Vt.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_Nh_Vt.TabIndex = 96;
            this.lbtTen_Nh_Vt.Text = "Tên nhóm ";
            this.lbtTen_Nh_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGrade_ID
            // 
            this.txtGrade_ID.AutoDropDown = null;
            this.txtGrade_ID.Location = new System.Drawing.Point(115, 45);
            this.txtGrade_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGrade_ID.MaxLength = 100;
            this.txtGrade_ID.Name = "txtGrade_ID";
            this.txtGrade_ID.Size = new System.Drawing.Size(120, 20);
            this.txtGrade_ID.TabIndex = 1;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(9, 46);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(56, 13);
            this.rsLabel1.TabIndex = 98;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mác Thép";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtGrade_Name
            // 
            this.lbtGrade_Name.AutoEllipsis = true;
            this.lbtGrade_Name.AutoSize = true;
            this.lbtGrade_Name.Location = new System.Drawing.Point(242, 52);
            this.lbtGrade_Name.Name = "lbtGrade_Name";
            this.lbtGrade_Name.Size = new System.Drawing.Size(56, 13);
            this.lbtGrade_Name.TabIndex = 99;
            this.lbtGrade_Name.Tag = "";
            this.lbtGrade_Name.Text = "Mác Thép";
            this.lbtGrade_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(115, 111);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ap.TabIndex = 5;
            this.dteNgay_Ap.Tag = "Ngay_Ct";
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(9, 114);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(47, 13);
            this.rsLabel6.TabIndex = 101;
            this.rsLabel6.Tag = "Ngay_Ap";
            this.rsLabel6.Text = "Ngày áp";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmNL_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 242);
            this.Name = "frmDmNL_Edit";
            this.Object_ID = "DMDMNL";
            this.Tag = "frmDmDINHMUCNL, ESC";
            this.Text = "frmDmDinhMucNL";
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

		private RosySystem.Control.rsTextBox txtMac_Thep;
		private RosySystem.Control.rsTextBox txtMa_Nh_Vt;
		private RosySystem.Control.rsLabel lbTen_Kho;
		private RosySystem.Control.rsLabel lbMa_Kho;
		private RosySystem.Control.rsTextBoxNumber numDinh_Muc;
		private RosySystem.Control.rsLabel lbStt;
		private RosySystem.Control.rsLabel lbtTen_Nh_Vt;
        private RosySystem.Control.rsLabel lbtGrade_Name;
        private RosySystem.Control.rsTextBox txtGrade_ID;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsLabel rsLabel6;

	}
}