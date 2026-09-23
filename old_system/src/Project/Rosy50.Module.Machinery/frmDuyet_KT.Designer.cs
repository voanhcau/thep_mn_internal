namespace RosyModule.Machinery
{
    partial class frmDuyet_KT
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
			this.btExit = new RosySystem.Control.rsButton();
			this.btSave = new RosySystem.Control.rsButton();
			this.dteNgay_Duyet = new RosySystem.Control.rsDateTime();
			this.lbMa_Vt = new RosySystem.Control.rsLabel();
			this.chkDuyet = new RosySystem.Control.rsCheckbox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtKy_Hieu = new RosySystem.Control.rsTextBoxEnum();
			this.rsLabel8 = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btExit.Location = new System.Drawing.Point(343, 185);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(75, 25);
			this.btExit.TabIndex = 3;
			this.btExit.Tag = "Exit";
			this.btExit.Text = "&Quay ra";
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// btSave
			// 
			this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btSave.Enabled = false;
			this.btSave.Location = new System.Drawing.Point(262, 185);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(75, 25);
			this.btSave.TabIndex = 2;
			this.btSave.Tag = "Save";
			this.btSave.Text = "&Lưu";
			this.btSave.UseVisualStyleBackColor = true;
			// 
			// dteNgay_Duyet
			// 
			this.dteNgay_Duyet.bAllowEmpty = true;
			this.dteNgay_Duyet.bSelectOnFocus = false;
			this.dteNgay_Duyet.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Duyet.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Duyet.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Duyet.Location = new System.Drawing.Point(113, 45);
			this.dteNgay_Duyet.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.dteNgay_Duyet.Mask = "00/00/0000";
			this.dteNgay_Duyet.Name = "dteNgay_Duyet";
			this.dteNgay_Duyet.Size = new System.Drawing.Size(74, 20);
			this.dteNgay_Duyet.TabIndex = 148;
			// 
			// lbMa_Vt
			// 
			this.lbMa_Vt.AutoEllipsis = true;
			this.lbMa_Vt.AutoSize = true;
			this.lbMa_Vt.Location = new System.Drawing.Point(35, 48);
			this.lbMa_Vt.Name = "lbMa_Vt";
			this.lbMa_Vt.Size = new System.Drawing.Size(72, 14);
			this.lbMa_Vt.TabIndex = 149;
			this.lbMa_Vt.Tag = "";
			this.lbMa_Vt.Text = "Ngày kiểm tra";
			this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkDuyet
			// 
			this.chkDuyet.AutoSize = true;
			this.chkDuyet.Location = new System.Drawing.Point(113, 155);
			this.chkDuyet.Name = "chkDuyet";
			this.chkDuyet.Size = new System.Drawing.Size(54, 18);
			this.chkDuyet.TabIndex = 150;
			this.chkDuyet.Text = "Duyệt";
			this.chkDuyet.UseVisualStyleBackColor = true;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(35, 72);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(44, 14);
			this.rsLabel1.TabIndex = 278;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Kết quả";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtKy_Hieu
			// 
			this.txtKy_Hieu.InputMask = "N,A,R,D,E,C,L";
			this.txtKy_Hieu.Location = new System.Drawing.Point(113, 66);
			this.txtKy_Hieu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtKy_Hieu.Name = "txtKy_Hieu";
			this.txtKy_Hieu.Size = new System.Drawing.Size(26, 20);
			this.txtKy_Hieu.TabIndex = 276;
			// 
			// rsLabel8
			// 
			this.rsLabel8.AutoEllipsis = true;
			this.rsLabel8.AutoSize = true;
			this.rsLabel8.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel8.Location = new System.Drawing.Point(158, 72);
			this.rsLabel8.Name = "rsLabel8";
			this.rsLabel8.Size = new System.Drawing.Size(78, 14);
			this.rsLabel8.TabIndex = 277;
			this.rsLabel8.Text = "N: bình thường";
			this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel2.Location = new System.Drawing.Point(158, 94);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(70, 14);
			this.rsLabel2.TabIndex = 279;
			this.rsLabel2.Text = "A: điều chỉnh";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel3.Location = new System.Drawing.Point(158, 116);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(67, 14);
			this.rsLabel3.TabIndex = 280;
			this.rsLabel3.Text = "R: sửa chữa";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel4.Location = new System.Drawing.Point(159, 138);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(57, 14);
			this.rsLabel4.TabIndex = 281;
			this.rsLabel4.Text = "D: tháo rời";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel5.Location = new System.Drawing.Point(263, 72);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(58, 14);
			this.rsLabel5.TabIndex = 282;
			this.rsLabel5.Text = "E: thay thế";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel6.Location = new System.Drawing.Point(263, 116);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(100, 14);
			this.rsLabel6.TabIndex = 283;
			this.rsLabel6.Text = "L: bơm mỡ/cấp dầu";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel7.Location = new System.Drawing.Point(263, 94);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(57, 14);
			this.rsLabel7.TabIndex = 284;
			this.rsLabel7.Text = "C: Vệ sinh";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDuyet_KT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(430, 222);
			this.Controls.Add(this.rsLabel7);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.txtKy_Hieu);
			this.Controls.Add(this.rsLabel8);
			this.Controls.Add(this.chkDuyet);
			this.Controls.Add(this.dteNgay_Duyet);
			this.Controls.Add(this.lbMa_Vt);
			this.Controls.Add(this.btExit);
			this.Controls.Add(this.btSave);
			this.Name = "frmDuyet_KT";
			this.Text = "Kiểm tra định kỳ";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsButton btSave;
        private RosySystem.Control.rsDateTime dteNgay_Duyet;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsCheckbox chkDuyet;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxEnum txtKy_Hieu;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel rsLabel7;
    }
}