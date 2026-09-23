namespace RosyModule.Salary
{
    partial class frmDmNgayLeCty_Edit
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
            this.dteDen_Ngay = new RosySystem.Control.rsDateTime();
            this.lbtNgay_QD = new RosySystem.Control.rsLabel();
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.dteTu_Ngay = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtLoai = new RosySystem.Control.rsTextBox();
            this.lbMa_CC = new RosySystem.Control.rsLabel();
            this.lblTen_Loai = new RosySystem.Control.rsLabel();
            this.dteGio_Vao = new RosyModule.txtTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(377, 174);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Margin = new System.Windows.Forms.Padding(4);
            this.tabEdit.Size = new System.Drawing.Size(547, 161);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.dteGio_Vao);
            this.Page1.Controls.Add(this.txtLoai);
            this.Page1.Controls.Add(this.lblTen_Loai);
            this.Page1.Controls.Add(this.lbMa_CC);
            this.Page1.Controls.Add(this.txtGhi_Chu);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.lbtNgay_QD);
            this.Page1.Controls.Add(this.dteTu_Ngay);
            this.Page1.Controls.Add(this.dteDen_Ngay);
            this.Page1.Margin = new System.Windows.Forms.Padding(4);
            this.Page1.Padding = new System.Windows.Forms.Padding(4);
            this.Page1.Size = new System.Drawing.Size(539, 135);
            // 
            // Page2
            // 
            this.Page2.Margin = new System.Windows.Forms.Padding(4);
            this.Page2.Size = new System.Drawing.Size(539, 135);
            // 
            // dteNgay_End
            // 
            this.dteNgay_End.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            // 
            // dteNgay_Begin
            // 
            this.dteNgay_Begin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 182);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 191);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Size = new System.Drawing.Size(330, 27);
            this.lblLog.Text = "";
            // 
            // dteDen_Ngay
            // 
            this.dteDen_Ngay.bAllowEmpty = true;
            this.dteDen_Ngay.bSelectOnFocus = false;
            this.dteDen_Ngay.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteDen_Ngay.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteDen_Ngay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteDen_Ngay.Location = new System.Drawing.Point(115, 35);
            this.dteDen_Ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteDen_Ngay.Mask = "00/00/0000";
            this.dteDen_Ngay.Name = "dteDen_Ngay";
            this.dteDen_Ngay.Size = new System.Drawing.Size(66, 20);
            this.dteDen_Ngay.TabIndex = 1;
            // 
            // lbtNgay_QD
            // 
            this.lbtNgay_QD.AutoEllipsis = true;
            this.lbtNgay_QD.AutoSize = true;
            this.lbtNgay_QD.Location = new System.Drawing.Point(8, 38);
            this.lbtNgay_QD.Name = "lbtNgay_QD";
            this.lbtNgay_QD.Size = new System.Drawing.Size(48, 13);
            this.lbtNgay_QD.TabIndex = 28;
            this.lbtNgay_QD.Tag = "Ngay_Ct2";
            this.lbtNgay_QD.Text = "Ngày Áp";
            this.lbtNgay_QD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(8, 61);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(44, 13);
            this.lbMa_Kho.TabIndex = 30;
            this.lbMa_Kho.Tag = "Ghi_Chu";
            this.lbMa_Kho.Text = "Ghi chú";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(115, 58);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.MaxLength = 200;
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(405, 25);
            this.txtGhi_Chu.TabIndex = 2;
            // 
            // dteTu_Ngay
            // 
            this.dteTu_Ngay.bAllowEmpty = true;
            this.dteTu_Ngay.bSelectOnFocus = false;
            this.dteTu_Ngay.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteTu_Ngay.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteTu_Ngay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteTu_Ngay.Location = new System.Drawing.Point(115, 13);
            this.dteTu_Ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteTu_Ngay.Mask = "00/00/0000";
            this.dteTu_Ngay.Name = "dteTu_Ngay";
            this.dteTu_Ngay.Size = new System.Drawing.Size(66, 20);
            this.dteTu_Ngay.TabIndex = 0;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(8, 16);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(48, 13);
            this.rsLabel1.TabIndex = 28;
            this.rsLabel1.Tag = "Ngay_Ct1";
            this.rsLabel1.Text = "Ngày Áp";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoai
            // 
            this.txtLoai.AutoDropDown = null;
            this.txtLoai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLoai.Location = new System.Drawing.Point(115, 85);
            this.txtLoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLoai.MaxLength = 20;
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(120, 20);
            this.txtLoai.TabIndex = 3;
            // 
            // lbMa_CC
            // 
            this.lbMa_CC.AutoEllipsis = true;
            this.lbMa_CC.AutoSize = true;
            this.lbMa_CC.Location = new System.Drawing.Point(4, 85);
            this.lbMa_CC.Name = "lbMa_CC";
            this.lbMa_CC.Size = new System.Drawing.Size(78, 13);
            this.lbMa_CC.TabIndex = 98;
            this.lbMa_CC.Tag = "";
            this.lbMa_CC.Text = "Mã chấm công";
            this.lbMa_CC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_Loai
            // 
            this.lblTen_Loai.AutoEllipsis = true;
            this.lblTen_Loai.AutoSize = true;
            this.lblTen_Loai.Location = new System.Drawing.Point(239, 89);
            this.lblTen_Loai.Name = "lblTen_Loai";
            this.lblTen_Loai.Size = new System.Drawing.Size(29, 13);
            this.lblTen_Loai.TabIndex = 98;
            this.lblTen_Loai.Tag = "";
            this.lblTen_Loai.Text = "Tên ";
            this.lblTen_Loai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteGio_Vao
            // 
            this.dteGio_Vao.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dteGio_Vao.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteGio_Vao.Location = new System.Drawing.Point(255, 13);
            this.dteGio_Vao.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteGio_Vao.Mask = "00:00:00";
            this.dteGio_Vao.Name = "dteGio_Vao";
            this.dteGio_Vao.SelectOnFocus = false;
            this.dteGio_Vao.Size = new System.Drawing.Size(52, 20);
            this.dteGio_Vao.TabIndex = 99;
            this.dteGio_Vao.Tag = "";
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(213, 16);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(37, 13);
            this.rsLabel2.TabIndex = 28;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Từ giờ";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmNgayLeCty_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 223);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmDmNgayLeCty_Edit";
            this.Object_ID = "DMNGHILE";
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

        private RosySystem.Control.rsDateTime dteDen_Ngay;
        private RosySystem.Control.rsLabel lbtNgay_QD;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel lbMa_Kho;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteTu_Ngay;
        private RosySystem.Control.rsTextBox txtLoai;
        private RosySystem.Control.rsLabel lbMa_CC;
        private RosySystem.Control.rsLabel lblTen_Loai;
        private txtTime dteGio_Vao;
        private RosySystem.Control.rsLabel rsLabel2;
    }
}