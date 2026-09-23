namespace RosyList
{
    partial class frmDmBanVe_Edit
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
            this.txtMa_BanVe = new RosySystem.Control.rsTextBox();
            this.lbMa_Hd = new RosySystem.Control.rsLabel();
            this.enuType = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.rsLabel14 = new RosySystem.Control.rsLabel();
            this.btAttack = new System.Windows.Forms.Button();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.rsLabel22 = new RosySystem.Control.rsLabel();
            this.txtFile_Name = new RosySystem.Control.rsTextBox();
            this.lbTen_Hd = new RosySystem.Control.rsLabel();
            this.txtTen_BanVe = new RosySystem.Control.rsTextBox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(462, 150);
            this.btgAccept.Size = new System.Drawing.Size(181, 48);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(631, 138);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.btOpenFile);
            this.Page1.Controls.Add(this.btAttack);
            this.Page1.Controls.Add(this.txtFile_Name);
            this.Page1.Controls.Add(this.rsLabel22);
            this.Page1.Controls.Add(this.txtTen_BanVe);
            this.Page1.Controls.Add(this.txtMa_BanVe);
            this.Page1.Controls.Add(this.lbTen_Hd);
            this.Page1.Controls.Add(this.lbMa_Hd);
            this.Page1.Size = new System.Drawing.Size(623, 112);
            // 
            // Page2
            // 
            this.Page2.Controls.Add(this.enuType);
            this.Page2.Controls.Add(this.rsLabel13);
            this.Page2.Controls.Add(this.rsLabel14);
            this.Page2.Size = new System.Drawing.Size(623, 112);
            this.Page2.Controls.SetChildIndex(this.dteNgay_Begin, 0);
            this.Page2.Controls.SetChildIndex(this.dteNgay_End, 0);
            this.Page2.Controls.SetChildIndex(this.ucMa_Data, 0);
            this.Page2.Controls.SetChildIndex(this.lblNgay_Begin, 0);
            this.Page2.Controls.SetChildIndex(this.lblNgay_End, 0);
            this.Page2.Controls.SetChildIndex(this.lblMa_Data, 0);
            this.Page2.Controls.SetChildIndex(this.rsLabel14, 0);
            this.Page2.Controls.SetChildIndex(this.rsLabel13, 0);
            this.Page2.Controls.SetChildIndex(this.enuType, 0);
            // 
            // dteNgay_End
            // 
            this.dteNgay_End.Location = new System.Drawing.Point(115, 57);
            // 
            // dteNgay_Begin
            // 
            this.dteNgay_Begin.Location = new System.Drawing.Point(115, 33);
            // 
            // lblNgay_Begin
            // 
            this.lblNgay_Begin.Location = new System.Drawing.Point(21, 36);
            // 
            // ucMa_Data
            // 
            this.ucMa_Data.Location = new System.Drawing.Point(115, 80);
            // 
            // lblMa_Data
            // 
            this.lblMa_Data.Location = new System.Drawing.Point(21, 84);
            // 
            // lblNgay_End
            // 
            this.lblNgay_End.Location = new System.Drawing.Point(21, 60);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 156);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 165);
            this.lblLog.Text = "";
            // 
            // txtMa_BanVe
            // 
            this.txtMa_BanVe.AutoDropDown = null;
            this.txtMa_BanVe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_BanVe.Location = new System.Drawing.Point(123, 6);
            this.txtMa_BanVe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_BanVe.MaxLength = 50;
            this.txtMa_BanVe.Name = "txtMa_BanVe";
            this.txtMa_BanVe.Size = new System.Drawing.Size(161, 20);
            this.txtMa_BanVe.TabIndex = 0;
            // 
            // lbMa_Hd
            // 
            this.lbMa_Hd.AutoEllipsis = true;
            this.lbMa_Hd.AutoSize = true;
            this.lbMa_Hd.Location = new System.Drawing.Point(14, 9);
            this.lbMa_Hd.Name = "lbMa_Hd";
            this.lbMa_Hd.Size = new System.Drawing.Size(58, 13);
            this.lbMa_Hd.TabIndex = 44;
            this.lbMa_Hd.Tag = "Ma_BanVe";
            this.lbMa_Hd.Text = "Mã bản vẽ";
            this.lbMa_Hd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuType
            // 
            this.enuType.AutoDropDown = null;
            this.enuType.InputMask = "1,2,3,9";
            this.enuType.Location = new System.Drawing.Point(115, 107);
            this.enuType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.enuType.MaxLength = 1;
            this.enuType.Name = "enuType";
            this.enuType.Size = new System.Drawing.Size(25, 20);
            this.enuType.TabIndex = 3;
            this.enuType.Text = "1";
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel13.Location = new System.Drawing.Point(145, 110);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(227, 13);
            this.rsLabel13.TabIndex = 4;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "1-Hợp đồng, 3-Customer, 9-Dùng chung tất cả";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel14
            // 
            this.rsLabel14.AutoEllipsis = true;
            this.rsLabel14.AutoSize = true;
            this.rsLabel14.Location = new System.Drawing.Point(21, 110);
            this.rsLabel14.Name = "rsLabel14";
            this.rsLabel14.Size = new System.Drawing.Size(51, 13);
            this.rsLabel14.TabIndex = 66;
            this.rsLabel14.Tag = "Type";
            this.rsLabel14.Text = "Phân loại";
            this.rsLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btAttack
            // 
            this.btAttack.Enabled = false;
            this.btAttack.Location = new System.Drawing.Point(443, 51);
            this.btAttack.Name = "btAttack";
            this.btAttack.Size = new System.Drawing.Size(81, 23);
            this.btAttack.TabIndex = 84;
            this.btAttack.Text = "Browse";
            this.btAttack.UseVisualStyleBackColor = true;
            // 
            // btOpenFile
            // 
            this.btOpenFile.Enabled = false;
            this.btOpenFile.Location = new System.Drawing.Point(530, 51);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(81, 23);
            this.btOpenFile.TabIndex = 85;
            this.btOpenFile.Text = "Open";
            this.btOpenFile.UseVisualStyleBackColor = true;
            // 
            // rsLabel22
            // 
            this.rsLabel22.AutoEllipsis = true;
            this.rsLabel22.AutoSize = true;
            this.rsLabel22.Enabled = false;
            this.rsLabel22.Location = new System.Drawing.Point(14, 54);
            this.rsLabel22.Name = "rsLabel22";
            this.rsLabel22.Size = new System.Drawing.Size(78, 13);
            this.rsLabel22.TabIndex = 79;
            this.rsLabel22.Tag = "";
            this.rsLabel22.Text = "Tên file bản vẽ";
            this.rsLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFile_Name
            // 
            this.txtFile_Name.AutoDropDown = null;
            this.txtFile_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFile_Name.Enabled = false;
            this.txtFile_Name.Location = new System.Drawing.Point(123, 51);
            this.txtFile_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Name.MaxLength = 20;
            this.txtFile_Name.Name = "txtFile_Name";
            this.txtFile_Name.Size = new System.Drawing.Size(315, 20);
            this.txtFile_Name.TabIndex = 8;
            // 
            // lbTen_Hd
            // 
            this.lbTen_Hd.AutoEllipsis = true;
            this.lbTen_Hd.AutoSize = true;
            this.lbTen_Hd.Location = new System.Drawing.Point(14, 31);
            this.lbTen_Hd.Name = "lbTen_Hd";
            this.lbTen_Hd.Size = new System.Drawing.Size(62, 13);
            this.lbTen_Hd.TabIndex = 43;
            this.lbTen_Hd.Tag = "Ten_BanVe";
            this.lbTen_Hd.Text = "Tên bản vẽ";
            this.lbTen_Hd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_BanVe
            // 
            this.txtTen_BanVe.AutoDropDown = null;
            this.txtTen_BanVe.Location = new System.Drawing.Point(123, 28);
            this.txtTen_BanVe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_BanVe.MaxLength = 100;
            this.txtTen_BanVe.Name = "txtTen_BanVe";
            this.txtTen_BanVe.Size = new System.Drawing.Size(363, 20);
            this.txtTen_BanVe.TabIndex = 1;
            // 
            // frmDmBanVe_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 197);
            this.Name = "frmDmBanVe_Edit";
            this.Object_ID = "DMBANVE";
            this.Tag = "frmDmBanVe, ESC";
            this.Text = "frmDmBanVe";
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

		private RosySystem.Control.rsTextBox txtMa_BanVe;
        private RosySystem.Control.rsLabel lbMa_Hd;
		private RosySystem.Control.rsTextBoxEnum enuType;
		private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsLabel rsLabel14;
		private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.Button btAttack;
		private RosySystem.Control.rsTextBox txtFile_Name;
        private RosySystem.Control.rsLabel rsLabel22;
		private RosySystem.Control.rsTextBox txtTen_BanVe;
		private RosySystem.Control.rsLabel lbTen_Hd;

	}
}