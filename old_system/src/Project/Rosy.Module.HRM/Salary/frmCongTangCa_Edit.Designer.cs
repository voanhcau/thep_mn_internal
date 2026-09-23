namespace RosyModule.Salary
{
    partial class frmCongTangCa_Edit
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
            this.dteNgay_Cham_Cong = new RosySystem.Control.rsDateTime();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabelName();
            this.numSo_Gio = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lblGiam_Doc_Duyet = new RosySystem.Control.rsLabel();
            this.cboTrang_Thai = new RosySystem.Control.rsMultiComboBox();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // dteNgay_Cham_Cong
            // 
            this.dteNgay_Cham_Cong.bAllowEmpty = true;
            this.dteNgay_Cham_Cong.bSelectOnFocus = false;
            this.dteNgay_Cham_Cong.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Cham_Cong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Cham_Cong.Location = new System.Drawing.Point(127, 36);
            this.dteNgay_Cham_Cong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Cham_Cong.Mask = "00/00/0000";
            this.dteNgay_Cham_Cong.Name = "dteNgay_Cham_Cong";
            this.dteNgay_Cham_Cong.Size = new System.Drawing.Size(67, 20);
            this.dteNgay_Cham_Cong.TabIndex = 1;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(29, 38);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(71, 13);
            this.lblDien_Giai.TabIndex = 73;
            this.lblDien_Giai.Tag = "";
            this.lblDien_Giai.Text = "Ngày tăng ca";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(127, 13);
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
            this.lblTk.Location = new System.Drawing.Point(29, 16);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(72, 13);
            this.lblTk.TabIndex = 70;
            this.lblTk.Tag = "Ma_Dt_CbNv";
            this.lblTk.Text = "Mã nhân viên";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(264, 159);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 43);
            this.btgAccept.TabIndex = 5;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(228, 16);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 4;
            this.lbtTen_Dt_CbNv.Tag = "";
            this.lbtTen_Dt_CbNv.Text = "txtTen_Tn";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Gio
            // 
            this.numSo_Gio.AutoDropDown = null;
            this.numSo_Gio.bFormat = true;
            this.numSo_Gio.Location = new System.Drawing.Point(127, 85);
            this.numSo_Gio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Gio.Name = "numSo_Gio";
            this.numSo_Gio.Scale = 0;
            this.numSo_Gio.Size = new System.Drawing.Size(38, 20);
            this.numSo_Gio.TabIndex = 3;
            this.numSo_Gio.Text = "0";
            this.numSo_Gio.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(29, 91);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(76, 13);
            this.rsLabel1.TabIndex = 75;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Số giờ tăng ca";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiam_Doc_Duyet
            // 
            this.lblGiam_Doc_Duyet.AutoEllipsis = true;
            this.lblGiam_Doc_Duyet.AutoSize = true;
            this.lblGiam_Doc_Duyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiam_Doc_Duyet.Location = new System.Drawing.Point(29, 63);
            this.lblGiam_Doc_Duyet.Name = "lblGiam_Doc_Duyet";
            this.lblGiam_Doc_Duyet.Size = new System.Drawing.Size(98, 13);
            this.lblGiam_Doc_Duyet.TabIndex = 79;
            this.lblGiam_Doc_Duyet.Text = "Ký hiệu chấm công";
            this.lblGiam_Doc_Duyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTrang_Thai
            // 
            this.cboTrang_Thai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTrang_Thai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboTrang_Thai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboTrang_Thai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrang_Thai.Location = new System.Drawing.Point(127, 61);
            this.cboTrang_Thai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboTrang_Thai.MaxLength = 20;
            this.cboTrang_Thai.Name = "cboTrang_Thai";
            this.cboTrang_Thai.Size = new System.Drawing.Size(87, 21);
            this.cboTrang_Thai.TabIndex = 2;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(127, 109);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.MaxLength = 200;
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(327, 39);
            this.txtGhi_Chu.TabIndex = 4;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(29, 112);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(44, 13);
            this.rsLabel2.TabIndex = 75;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Ghi chú";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCongTangCa_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 209);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.lblGiam_Doc_Duyet);
            this.Controls.Add(this.cboTrang_Thai);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.numSo_Gio);
            this.Controls.Add(this.dteNgay_Cham_Cong);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCongTangCa_Edit";
            this.Text = "frmCongTangCa_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_Cham_Cong;
		private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabelName lbtTen_Dt_CbNv;
        private RosySystem.Control.rsTextBoxNumber numSo_Gio;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel lblGiam_Doc_Duyet;
        private RosySystem.Control.rsMultiComboBox cboTrang_Thai;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel rsLabel2;
	}
}