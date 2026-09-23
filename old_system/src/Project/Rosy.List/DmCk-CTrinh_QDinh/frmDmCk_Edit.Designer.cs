namespace RosyList
{
	partial class frmDmCk_Edit
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
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.lbSo_Luong = new RosySystem.Control.rsLabel();
			this.lbTien_CK = new RosySystem.Control.rsLabel();
			this.numTien_Ck = new RosySystem.Control.rsTextBoxNumber();
			this.numSo_Luong_Min = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.numSo_luong_Max = new RosySystem.Control.rsTextBoxNumber();
			this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
			this.lbtNgay_QD = new RosySystem.Control.rsLabel();
			this.txtSo_QD = new RosySystem.Control.rsTextBox();
			this.lbMa_Kho = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(377, 241);
			this.btgAccept.Size = new System.Drawing.Size(179, 42);
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(547, 228);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.txtSo_QD);
			this.Page1.Controls.Add(this.lbMa_Kho);
			this.Page1.Controls.Add(this.lbtNgay_QD);
			this.Page1.Controls.Add(this.dteNgay_Ap);
			this.Page1.Controls.Add(this.numSo_luong_Max);
			this.Page1.Controls.Add(this.numSo_Luong_Min);
			this.Page1.Controls.Add(this.numTien_Ck);
			this.Page1.Controls.Add(this.rsLabel2);
			this.Page1.Controls.Add(this.rsLabel4);
			this.Page1.Controls.Add(this.lbTien_CK);
			this.Page1.Controls.Add(this.lbSo_Luong);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Size = new System.Drawing.Size(539, 202);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(539, 202);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 249);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 258);
			this.lblLog.Text = "";
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel1.Location = new System.Drawing.Point(180, 140);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(0, 13);
			this.rsLabel1.TabIndex = 22;
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel2.Location = new System.Drawing.Point(296, 91);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(209, 13);
			this.rsLabel2.TabIndex = 26;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "(Số lượng tối thiếu được hưởng chiết khấu)";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbSo_Luong
			// 
			this.lbSo_Luong.AutoEllipsis = true;
			this.lbSo_Luong.AutoSize = true;
			this.lbSo_Luong.Location = new System.Drawing.Point(8, 91);
			this.lbSo_Luong.Name = "lbSo_Luong";
			this.lbSo_Luong.Size = new System.Drawing.Size(69, 13);
			this.lbSo_Luong.TabIndex = 25;
			this.lbSo_Luong.Text = "Số lượng Min";
			this.lbSo_Luong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbTien_CK
			// 
			this.lbTien_CK.AutoEllipsis = true;
			this.lbTien_CK.AutoSize = true;
			this.lbTien_CK.Location = new System.Drawing.Point(8, 137);
			this.lbTien_CK.Name = "lbTien_CK";
			this.lbTien_CK.Size = new System.Drawing.Size(81, 13);
			this.lbTien_CK.TabIndex = 25;
			this.lbTien_CK.Text = "Tiền chiết khấu";
			this.lbTien_CK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTien_Ck
			// 
			this.numTien_Ck.AutoDropDown = null;
			this.numTien_Ck.bFormat = true;
			this.numTien_Ck.Location = new System.Drawing.Point(115, 137);
			this.numTien_Ck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTien_Ck.Name = "numTien_Ck";
			this.numTien_Ck.Scale = 0;
			this.numTien_Ck.Size = new System.Drawing.Size(120, 20);
			this.numTien_Ck.TabIndex = 5;
			this.numTien_Ck.Tag = "Tien_Ck";
			this.numTien_Ck.Text = "0";
			this.numTien_Ck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTien_Ck.Value = 0D;
			// 
			// numSo_Luong_Min
			// 
			this.numSo_Luong_Min.AutoDropDown = null;
			this.numSo_Luong_Min.bFormat = true;
			this.numSo_Luong_Min.Location = new System.Drawing.Point(115, 91);
			this.numSo_Luong_Min.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Luong_Min.Name = "numSo_Luong_Min";
			this.numSo_Luong_Min.Scale = 0;
			this.numSo_Luong_Min.Size = new System.Drawing.Size(120, 20);
			this.numSo_Luong_Min.TabIndex = 4;
			this.numSo_Luong_Min.Tag = "So_Luong";
			this.numSo_Luong_Min.Text = "0";
			this.numSo_Luong_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSo_Luong_Min.Value = 0D;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(8, 113);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(72, 13);
			this.rsLabel4.TabIndex = 25;
			this.rsLabel4.Text = "Số lượng Max";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numSo_luong_Max
			// 
			this.numSo_luong_Max.AutoDropDown = null;
			this.numSo_luong_Max.bFormat = true;
			this.numSo_luong_Max.Location = new System.Drawing.Point(115, 113);
			this.numSo_luong_Max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_luong_Max.Name = "numSo_luong_Max";
			this.numSo_luong_Max.Scale = 0;
			this.numSo_luong_Max.Size = new System.Drawing.Size(120, 20);
			this.numSo_luong_Max.TabIndex = 4;
			this.numSo_luong_Max.Tag = "So_Luong";
			this.numSo_luong_Max.Text = "0";
			this.numSo_luong_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSo_luong_Max.Value = 0D;
			// 
			// dteNgay_Ap
			// 
			this.dteNgay_Ap.bAllowEmpty = true;
			this.dteNgay_Ap.bSelectOnFocus = false;
			this.dteNgay_Ap.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ap.Location = new System.Drawing.Point(115, 69);
			this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ap.Mask = "00/00/0000";
			this.dteNgay_Ap.Name = "dteNgay_Ap";
			this.dteNgay_Ap.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ap.TabIndex = 27;
			// 
			// lbtNgay_QD
			// 
			this.lbtNgay_QD.AutoEllipsis = true;
			this.lbtNgay_QD.AutoSize = true;
			this.lbtNgay_QD.Location = new System.Drawing.Point(8, 72);
			this.lbtNgay_QD.Name = "lbtNgay_QD";
			this.lbtNgay_QD.Size = new System.Drawing.Size(48, 13);
			this.lbtNgay_QD.TabIndex = 28;
			this.lbtNgay_QD.Text = "Ngày Áp";
			this.lbtNgay_QD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSo_QD
			// 
			this.txtSo_QD.AutoDropDown = null;
			this.txtSo_QD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSo_QD.Location = new System.Drawing.Point(115, 47);
			this.txtSo_QD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_QD.MaxLength = 20;
			this.txtSo_QD.Name = "txtSo_QD";
			this.txtSo_QD.Size = new System.Drawing.Size(120, 20);
			this.txtSo_QD.TabIndex = 29;
			// 
			// lbMa_Kho
			// 
			this.lbMa_Kho.AutoEllipsis = true;
			this.lbMa_Kho.AutoSize = true;
			this.lbMa_Kho.Location = new System.Drawing.Point(8, 50);
			this.lbMa_Kho.Name = "lbMa_Kho";
			this.lbMa_Kho.Size = new System.Drawing.Size(39, 13);
			this.lbMa_Kho.TabIndex = 30;
			this.lbMa_Kho.Tag = "So_QD";
			this.lbMa_Kho.Text = "Số QĐ";
			this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmCk_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(571, 290);
			this.Name = "frmDmCk_Edit";
			this.Object_ID = "DMCK";
			this.Tag = "frmDmCK, ESC";
			this.Text = " ";
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

		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong_Min;
        private RosySystem.Control.rsTextBoxNumber numTien_Ck;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel lbTien_CK;
		private RosySystem.Control.rsLabel lbSo_Luong;
        private RosySystem.Control.rsTextBoxNumber numSo_luong_Max;
        private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsDateTime dteNgay_Ap;
		private RosySystem.Control.rsLabel lbtNgay_QD;
		private RosySystem.Control.rsTextBox txtSo_QD;
		private RosySystem.Control.rsLabel lbMa_Kho;


	}
}