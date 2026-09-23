namespace RosyModule.General
{
    partial class frmTinh_CLTG_Edit
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
			this.txtTk = new RosySystem.Control.rsTextBox();
			this.lblDia_Chi = new RosySystem.Control.rsLabel();
			this.numSTt = new RosySystem.Control.rsTextBoxNumber();
			this.lblHan_Tt = new RosySystem.Control.rsLabel();
			this.txtDien_Giai = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.txtTk_Lai = new RosySystem.Control.rsTextBox();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.txtTk_Lo = new RosySystem.Control.rsTextBox();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.txtLoai_CLTG = new RosySystem.Control.rsTextBoxEnum();
			this.lbtTen_Tk_Lo = new RosySystem.Control.rsLabelName();
			this.lbtTen_Tk_Lai = new RosySystem.Control.rsLabelName();
			this.lbtTen_Tk = new RosySystem.Control.rsLabelName();
			this.lbtLoai_CLTG = new RosySystem.Control.rsLabelName();
			this.numTy_Gia = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel9 = new RosySystem.Control.rsLabel();
			this.txtMa_Ct = new RosySystem.Control.rsTextBox();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.txtSo_Ct = new RosySystem.Control.rsTextBox();
			this.lblSo_Ct = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// txtTk
			// 
			this.txtTk.AutoDropDown = null;
			this.txtTk.Location = new System.Drawing.Point(125, 43);
			this.txtTk.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.txtTk.MaxLength = 200;
			this.txtTk.Name = "txtTk";
			this.txtTk.Size = new System.Drawing.Size(104, 20);
			this.txtTk.TabIndex = 1;
			// 
			// lblDia_Chi
			// 
			this.lblDia_Chi.AutoEllipsis = true;
			this.lblDia_Chi.AutoSize = true;
			this.lblDia_Chi.Location = new System.Drawing.Point(23, 46);
			this.lblDia_Chi.Name = "lblDia_Chi";
			this.lblDia_Chi.Size = new System.Drawing.Size(55, 13);
			this.lblDia_Chi.TabIndex = 64;
			this.lblDia_Chi.Tag = "TK";
			this.lblDia_Chi.Text = "Tài khoản";
			this.lblDia_Chi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numSTt
			// 
			this.numSTt.AutoDropDown = null;
			this.numSTt.bFormat = true;
			this.numSTt.Location = new System.Drawing.Point(125, 21);
			this.numSTt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSTt.Name = "numSTt";
			this.numSTt.Scale = 0;
			this.numSTt.Size = new System.Drawing.Size(47, 20);
			this.numSTt.TabIndex = 0;
			this.numSTt.Text = "0";
			this.numSTt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSTt.Value = 0D;
			// 
			// lblHan_Tt
			// 
			this.lblHan_Tt.AutoEllipsis = true;
			this.lblHan_Tt.AutoSize = true;
			this.lblHan_Tt.Location = new System.Drawing.Point(23, 24);
			this.lblHan_Tt.Name = "lblHan_Tt";
			this.lblHan_Tt.Size = new System.Drawing.Size(50, 13);
			this.lblHan_Tt.TabIndex = 115;
			this.lblHan_Tt.Tag = "Han_Tt";
			this.lblHan_Tt.Text = "Số thứ tự";
			this.lblHan_Tt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDien_Giai
			// 
			this.txtDien_Giai.AutoDropDown = null;
			this.txtDien_Giai.Location = new System.Drawing.Point(125, 205);
			this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.txtDien_Giai.MaxLength = 200;
			this.txtDien_Giai.Name = "txtDien_Giai";
			this.txtDien_Giai.Size = new System.Drawing.Size(489, 20);
			this.txtDien_Giai.TabIndex = 7;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(23, 208);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(48, 13);
			this.rsLabel1.TabIndex = 117;
			this.rsLabel1.Tag = "DIEN_GIAI";
			this.rsLabel1.Text = "Diễn giải";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(23, 232);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(103, 13);
			this.rsLabel2.TabIndex = 119;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "Loại đánh giá CLTG";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk_Lai
			// 
			this.txtTk_Lai.AutoDropDown = null;
			this.txtTk_Lai.Location = new System.Drawing.Point(125, 66);
			this.txtTk_Lai.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.txtTk_Lai.MaxLength = 200;
			this.txtTk_Lai.Name = "txtTk_Lai";
			this.txtTk_Lai.Size = new System.Drawing.Size(104, 20);
			this.txtTk_Lai.TabIndex = 2;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(23, 69);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(68, 13);
			this.rsLabel3.TabIndex = 121;
			this.rsLabel3.Tag = "TK_Lai";
			this.rsLabel3.Text = "Tài khoản lãi";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk_Lo
			// 
			this.txtTk_Lo.AutoDropDown = null;
			this.txtTk_Lo.Location = new System.Drawing.Point(125, 89);
			this.txtTk_Lo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.txtTk_Lo.MaxLength = 200;
			this.txtTk_Lo.Name = "txtTk_Lo";
			this.txtTk_Lo.Size = new System.Drawing.Size(104, 20);
			this.txtTk_Lo.TabIndex = 3;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(23, 92);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(66, 13);
			this.rsLabel4.TabIndex = 123;
			this.rsLabel4.Tag = "TK_LO";
			this.rsLabel4.Text = "Tài khoản lỗ";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(451, 260);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(184, 45);
			this.btgAccept.TabIndex = 10;
			// 
			// txtLoai_CLTG
			// 
			this.txtLoai_CLTG.AutoDropDown = null;
			this.txtLoai_CLTG.InputMask = "1-TK,2-HOADON,3-HOPDONG";
			this.txtLoai_CLTG.Location = new System.Drawing.Point(125, 228);
			this.txtLoai_CLTG.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.txtLoai_CLTG.Name = "txtLoai_CLTG";
			this.txtLoai_CLTG.Size = new System.Drawing.Size(86, 20);
			this.txtLoai_CLTG.TabIndex = 8;
			this.txtLoai_CLTG.Text = "1-TK";
			// 
			// lbtTen_Tk_Lo
			// 
			this.lbtTen_Tk_Lo.AutoSize = true;
			this.lbtTen_Tk_Lo.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Tk_Lo.Location = new System.Drawing.Point(235, 90);
			this.lbtTen_Tk_Lo.Name = "lbtTen_Tk_Lo";
			this.lbtTen_Tk_Lo.Size = new System.Drawing.Size(63, 13);
			this.lbtTen_Tk_Lo.TabIndex = 125;
			this.lbtTen_Tk_Lo.Tag = "";
			this.lbtTen_Tk_Lo.Text = "Ten_Tk_Lo";
			this.lbtTen_Tk_Lo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Tk_Lai
			// 
			this.lbtTen_Tk_Lai.AutoSize = true;
			this.lbtTen_Tk_Lai.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Tk_Lai.Location = new System.Drawing.Point(235, 68);
			this.lbtTen_Tk_Lai.Name = "lbtTen_Tk_Lai";
			this.lbtTen_Tk_Lai.Size = new System.Drawing.Size(65, 13);
			this.lbtTen_Tk_Lai.TabIndex = 124;
			this.lbtTen_Tk_Lai.Tag = "";
			this.lbtTen_Tk_Lai.Text = "Ten_Tk_Lai";
			this.lbtTen_Tk_Lai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Tk
			// 
			this.lbtTen_Tk.AutoSize = true;
			this.lbtTen_Tk.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Tk.Location = new System.Drawing.Point(235, 45);
			this.lbtTen_Tk.Name = "lbtTen_Tk";
			this.lbtTen_Tk.Size = new System.Drawing.Size(45, 13);
			this.lbtTen_Tk.TabIndex = 124;
			this.lbtTen_Tk.Tag = "";
			this.lbtTen_Tk.Text = "Ten_Tk";
			this.lbtTen_Tk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtLoai_CLTG
			// 
			this.lbtLoai_CLTG.ForeColor = System.Drawing.Color.Blue;
			this.lbtLoai_CLTG.Location = new System.Drawing.Point(217, 225);
			this.lbtLoai_CLTG.Name = "lbtLoai_CLTG";
			this.lbtLoai_CLTG.Size = new System.Drawing.Size(322, 26);
			this.lbtLoai_CLTG.TabIndex = 9;
			this.lbtLoai_CLTG.Tag = "";
			this.lbtLoai_CLTG.Text = "1- CLTG theo Tk, 2- CLTG theo hóa đơn, 3 - CLTG theo hợp đồng";
			this.lbtLoai_CLTG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTy_Gia
			// 
			this.numTy_Gia.AutoDropDown = null;
			this.numTy_Gia.bFormat = true;
			this.numTy_Gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTy_Gia.Location = new System.Drawing.Point(125, 183);
			this.numTy_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTy_Gia.Name = "numTy_Gia";
			this.numTy_Gia.Scale = 2;
			this.numTy_Gia.Size = new System.Drawing.Size(104, 20);
			this.numTy_Gia.TabIndex = 6;
			this.numTy_Gia.Text = "0.00";
			this.numTy_Gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTy_Gia.Value = 0D;
			// 
			// rsLabel9
			// 
			this.rsLabel9.AutoEllipsis = true;
			this.rsLabel9.AutoSize = true;
			this.rsLabel9.Location = new System.Drawing.Point(23, 186);
			this.rsLabel9.Name = "rsLabel9";
			this.rsLabel9.Size = new System.Drawing.Size(36, 13);
			this.rsLabel9.TabIndex = 131;
			this.rsLabel9.Tag = "";
			this.rsLabel9.Text = "Tỷ giá";
			this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Ct
			// 
			this.txtMa_Ct.AutoDropDown = null;
			this.txtMa_Ct.Location = new System.Drawing.Point(125, 139);
			this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Ct.Name = "txtMa_Ct";
			this.txtMa_Ct.Size = new System.Drawing.Size(47, 20);
			this.txtMa_Ct.TabIndex = 4;
			this.txtMa_Ct.Text = "TD";
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(23, 142);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(35, 13);
			this.rsLabel5.TabIndex = 130;
			this.rsLabel5.Tag = "";
			this.rsLabel5.Text = "Mã Ct";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSo_Ct
			// 
			this.txtSo_Ct.AutoDropDown = null;
			this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSo_Ct.Location = new System.Drawing.Point(125, 161);
			this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_Ct.MaxLength = 20;
			this.txtSo_Ct.Name = "txtSo_Ct";
			this.txtSo_Ct.Size = new System.Drawing.Size(104, 20);
			this.txtSo_Ct.TabIndex = 5;
			this.txtSo_Ct.Text = "CLTG";
			// 
			// lblSo_Ct
			// 
			this.lblSo_Ct.AutoEllipsis = true;
			this.lblSo_Ct.AutoSize = true;
			this.lblSo_Ct.Location = new System.Drawing.Point(23, 164);
			this.lblSo_Ct.Name = "lblSo_Ct";
			this.lblSo_Ct.Size = new System.Drawing.Size(33, 13);
			this.lblSo_Ct.TabIndex = 129;
			this.lblSo_Ct.Tag = "So_Ct";
			this.lblSo_Ct.Text = "Số Ct";
			this.lblSo_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmTinh_CLTG_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(656, 316);
			this.Controls.Add(this.numTy_Gia);
			this.Controls.Add(this.rsLabel9);
			this.Controls.Add(this.txtMa_Ct);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.txtSo_Ct);
			this.Controls.Add(this.lblSo_Ct);
			this.Controls.Add(this.lbtLoai_CLTG);
			this.Controls.Add(this.lbtTen_Tk_Lo);
			this.Controls.Add(this.lbtTen_Tk);
			this.Controls.Add(this.lbtTen_Tk_Lai);
			this.Controls.Add(this.txtLoai_CLTG);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.txtTk_Lo);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.txtTk_Lai);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.txtDien_Giai);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.numSTt);
			this.Controls.Add(this.lblHan_Tt);
			this.Controls.Add(this.txtTk);
			this.Controls.Add(this.lblDia_Chi);
			this.Name = "frmTinh_CLTG_Edit";
			this.Text = "frmTinh_CLTG_Edit";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsTextBox txtTk;
        private RosySystem.Control.rsLabel lblDia_Chi;
        private RosySystem.Control.rsTextBoxNumber numSTt;
        private RosySystem.Control.rsLabel lblHan_Tt;
        private RosySystem.Control.rsTextBox txtDien_Giai;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtTk_Lai;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtTk_Lo;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBoxEnum txtLoai_CLTG;
		private RosySystem.Control.rsLabelName lbtTen_Tk_Lo;
		private RosySystem.Control.rsLabelName lbtTen_Tk_Lai;
		private RosySystem.Control.rsLabelName lbtTen_Tk;
		private RosySystem.Control.rsLabelName lbtLoai_CLTG;
		private RosySystem.Control.rsTextBoxNumber numTy_Gia;
		private RosySystem.Control.rsLabel rsLabel9;
		private RosySystem.Control.rsTextBox txtMa_Ct;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsTextBox txtSo_Ct;
		private RosySystem.Control.rsLabel lblSo_Ct;

    }
}