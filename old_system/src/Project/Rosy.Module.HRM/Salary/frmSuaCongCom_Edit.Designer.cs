namespace RosyModule.Salary
{
    partial class frmSuaCongCom_Edit
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
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.cboLoai_CC = new RosySystem.Control.rsMultiComboBox();
            this.dteNgay_Cham_Cong = new RosySystem.Control.rsDateTime();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.numAn_Sang_Sau = new RosySystem.Control.rsTextBoxNumber();
            this.numAn_Khuya = new RosySystem.Control.rsTextBoxNumber();
            this.numAn_Chieu = new RosySystem.Control.rsTextBoxNumber();
            this.numAn_Trua = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.numAn_Sang = new RosySystem.Control.rsTextBoxNumber();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.numAn_Khuya_Sau = new RosySystem.Control.rsTextBoxNumber();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(343, 216);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 43);
            this.btgAccept.TabIndex = 9;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(10, 35);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(32, 13);
            this.lblDien_Giai.TabIndex = 64;
            this.lblDien_Giai.Tag = "";
            this.lblDien_Giai.Text = "Ngày";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv.Enabled = false;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(112, 10);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.MaxLength = 20;
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Location = new System.Drawing.Point(10, 13);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(72, 13);
            this.lblTk.TabIndex = 63;
            this.lblTk.Tag = "Ma_Dt_CbNv";
            this.lblTk.Text = "Mã nhân viên";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(10, 62);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(83, 13);
            this.rsLabel1.TabIndex = 65;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Loại chấm công";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLoai_CC
            // 
            this.cboLoai_CC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLoai_CC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboLoai_CC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLoai_CC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoai_CC.Location = new System.Drawing.Point(112, 59);
            this.cboLoai_CC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboLoai_CC.MaxLength = 20;
            this.cboLoai_CC.Name = "cboLoai_CC";
            this.cboLoai_CC.Size = new System.Drawing.Size(96, 21);
            this.cboLoai_CC.TabIndex = 2;
            this.cboLoai_CC.Text = "HC";
            // 
            // dteNgay_Cham_Cong
            // 
            this.dteNgay_Cham_Cong.bAllowEmpty = false;
            this.dteNgay_Cham_Cong.bSelectOnFocus = false;
            this.dteNgay_Cham_Cong.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Cham_Cong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Cham_Cong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Cham_Cong.Location = new System.Drawing.Point(112, 35);
            this.dteNgay_Cham_Cong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Cham_Cong.Mask = "00/00/0000";
            this.dteNgay_Cham_Cong.Name = "dteNgay_Cham_Cong";
            this.dteNgay_Cham_Cong.Size = new System.Drawing.Size(96, 22);
            this.dteNgay_Cham_Cong.TabIndex = 1;
            this.dteNgay_Cham_Cong.Text = "00002019";
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(10, 167);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(44, 13);
            this.rsLabel8.TabIndex = 191;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Ghi chú";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(112, 159);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(417, 40);
            this.txtGhi_Chu.TabIndex = 8;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel7.Location = new System.Drawing.Point(253, 130);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(85, 13);
            this.rsLabel7.TabIndex = 187;
            this.rsLabel7.Text = "Ăn sáng ca đêm";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel6.Location = new System.Drawing.Point(416, 95);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(52, 13);
            this.rsLabel6.TabIndex = 186;
            this.rsLabel6.Text = "Ăn khuya";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel5.Location = new System.Drawing.Point(296, 96);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(49, 13);
            this.rsLabel5.TabIndex = 189;
            this.rsLabel5.Text = "Ăn chiều";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.Location = new System.Drawing.Point(181, 96);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(41, 13);
            this.rsLabel4.TabIndex = 188;
            this.rsLabel4.Text = "Ăn trưa";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numAn_Sang_Sau
            // 
            this.numAn_Sang_Sau.AutoDropDown = null;
            this.numAn_Sang_Sau.bFormat = true;
            this.numAn_Sang_Sau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAn_Sang_Sau.Location = new System.Drawing.Point(355, 126);
            this.numAn_Sang_Sau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAn_Sang_Sau.Name = "numAn_Sang_Sau";
            this.numAn_Sang_Sau.Scale = 0;
            this.numAn_Sang_Sau.Size = new System.Drawing.Size(56, 22);
            this.numAn_Sang_Sau.TabIndex = 7;
            this.numAn_Sang_Sau.Text = "0";
            this.numAn_Sang_Sau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAn_Sang_Sau.Value = 0D;
            // 
            // numAn_Khuya
            // 
            this.numAn_Khuya.AutoDropDown = null;
            this.numAn_Khuya.bFormat = true;
            this.numAn_Khuya.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAn_Khuya.Location = new System.Drawing.Point(473, 91);
            this.numAn_Khuya.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAn_Khuya.Name = "numAn_Khuya";
            this.numAn_Khuya.Scale = 0;
            this.numAn_Khuya.Size = new System.Drawing.Size(56, 22);
            this.numAn_Khuya.TabIndex = 6;
            this.numAn_Khuya.Text = "0";
            this.numAn_Khuya.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAn_Khuya.Value = 0D;
            // 
            // numAn_Chieu
            // 
            this.numAn_Chieu.AutoDropDown = null;
            this.numAn_Chieu.bFormat = true;
            this.numAn_Chieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAn_Chieu.Location = new System.Drawing.Point(355, 92);
            this.numAn_Chieu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAn_Chieu.Name = "numAn_Chieu";
            this.numAn_Chieu.Scale = 0;
            this.numAn_Chieu.Size = new System.Drawing.Size(56, 22);
            this.numAn_Chieu.TabIndex = 5;
            this.numAn_Chieu.Text = "0";
            this.numAn_Chieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAn_Chieu.Value = 0D;
            // 
            // numAn_Trua
            // 
            this.numAn_Trua.AutoDropDown = null;
            this.numAn_Trua.bFormat = true;
            this.numAn_Trua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAn_Trua.Location = new System.Drawing.Point(229, 92);
            this.numAn_Trua.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAn_Trua.Name = "numAn_Trua";
            this.numAn_Trua.Scale = 0;
            this.numAn_Trua.Size = new System.Drawing.Size(56, 22);
            this.numAn_Trua.TabIndex = 4;
            this.numAn_Trua.Text = "0";
            this.numAn_Trua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAn_Trua.Value = 0D;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(10, 96);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(87, 13);
            this.rsLabel2.TabIndex = 181;
            this.rsLabel2.Text = "Ăn sáng ca ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numAn_Sang
            // 
            this.numAn_Sang.AutoDropDown = null;
            this.numAn_Sang.bFormat = true;
            this.numAn_Sang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAn_Sang.Location = new System.Drawing.Point(122, 92);
            this.numAn_Sang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAn_Sang.Name = "numAn_Sang";
            this.numAn_Sang.Scale = 0;
            this.numAn_Sang.Size = new System.Drawing.Size(56, 22);
            this.numAn_Sang.TabIndex = 3;
            this.numAn_Sang.Text = "0";
            this.numAn_Sang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAn_Sang.Value = 0D;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(213, 13);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(72, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 63;
            this.lbtTen_Dt_CbNv.Tag = "";
            this.lbtTen_Dt_CbNv.Text = "Mã nhân viên";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel9.Location = new System.Drawing.Point(10, 126);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(91, 13);
            this.rsLabel9.TabIndex = 193;
            this.rsLabel9.Text = "Ăn khuya ca đêm";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numAn_Khuya_Sau
            // 
            this.numAn_Khuya_Sau.AutoDropDown = null;
            this.numAn_Khuya_Sau.bFormat = true;
            this.numAn_Khuya_Sau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAn_Khuya_Sau.Location = new System.Drawing.Point(122, 122);
            this.numAn_Khuya_Sau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAn_Khuya_Sau.Name = "numAn_Khuya_Sau";
            this.numAn_Khuya_Sau.Scale = 0;
            this.numAn_Khuya_Sau.Size = new System.Drawing.Size(56, 22);
            this.numAn_Khuya_Sau.TabIndex = 192;
            this.numAn_Khuya_Sau.Text = "0";
            this.numAn_Khuya_Sau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAn_Khuya_Sau.Value = 0D;
            // 
            // frmSuaCongCom_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 268);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.numAn_Khuya_Sau);
            this.Controls.Add(this.rsLabel8);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.numAn_Sang_Sau);
            this.Controls.Add(this.numAn_Khuya);
            this.Controls.Add(this.numAn_Chieu);
            this.Controls.Add(this.numAn_Trua);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.numAn_Sang);
            this.Controls.Add(this.cboLoai_CC);
            this.Controls.Add(this.dteNgay_Cham_Cong);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmSuaCongCom_Edit";
            this.Text = "frmSuaCongCom_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabel lblTk;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsMultiComboBox cboLoai_CC;
        private RosySystem.Control.rsDateTime dteNgay_Cham_Cong;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBoxNumber numAn_Sang_Sau;
        private RosySystem.Control.rsTextBoxNumber numAn_Khuya;
        private RosySystem.Control.rsTextBoxNumber numAn_Chieu;
        private RosySystem.Control.rsTextBoxNumber numAn_Trua;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numAn_Sang;
        private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsTextBoxNumber numAn_Khuya_Sau;
	}
}