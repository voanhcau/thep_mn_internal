namespace RosyModule
{
	partial class frmChon_In_Scale
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
            this.rdbTruck_In = new RosySystem.Control.rsRadioButton();
            this.rdbTruck_Out = new RosySystem.Control.rsRadioButton();
            this.rdbScale_Out = new RosySystem.Control.rsRadioButton();
            this.txtMa_Vt_Sp_List = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtTen_Cong_Trinh = new RosySystem.Control.rsTextBox();
            this.txtTen_Dt = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtSo_Ct = new RosySystem.Control.rsTextBox();
            this.lblSo_Ct = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.rdbKCS = new RosySystem.Control.rsRadioButton();
            this.rdbCNXX = new RosySystem.Control.rsRadioButton();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.btPath = new System.Windows.Forms.Button();
            this.txtPath = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.cboSo_LXH = new RosySystem.Control.rsComboBox();
            this.btCreateCNXX = new System.Windows.Forms.Button();
            this.chkNum_Lot = new RosySystem.Control.rsCheckbox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(341, 329);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 11;
            // 
            // rdbTruck_In
            // 
            this.rdbTruck_In.AutoSize = true;
            this.rdbTruck_In.Location = new System.Drawing.Point(80, 14);
            this.rdbTruck_In.Name = "rdbTruck_In";
            this.rdbTruck_In.Size = new System.Drawing.Size(152, 17);
            this.rdbTruck_In.TabIndex = 0;
            this.rdbTruck_In.Tag = "";
            this.rdbTruck_In.Text = "&1. In phiếu cân xe vào kho";
            this.rdbTruck_In.UnChecked = true;
            this.rdbTruck_In.UseVisualStyleBackColor = true;
            // 
            // rdbTruck_Out
            // 
            this.rdbTruck_Out.AutoSize = true;
            this.rdbTruck_Out.Location = new System.Drawing.Point(80, 37);
            this.rdbTruck_Out.Name = "rdbTruck_Out";
            this.rdbTruck_Out.Size = new System.Drawing.Size(225, 17);
            this.rdbTruck_Out.TabIndex = 1;
            this.rdbTruck_Out.Tag = "";
            this.rdbTruck_Out.Text = "&2. In phiếu cân xe ra - WeighBridge Ticket";
            this.rdbTruck_Out.UnChecked = true;
            this.rdbTruck_Out.UseVisualStyleBackColor = true;
            // 
            // rdbScale_Out
            // 
            this.rdbScale_Out.AutoSize = true;
            this.rdbScale_Out.Location = new System.Drawing.Point(80, 60);
            this.rdbScale_Out.Name = "rdbScale_Out";
            this.rdbScale_Out.Size = new System.Drawing.Size(200, 17);
            this.rdbScale_Out.TabIndex = 2;
            this.rdbScale_Out.Tag = "";
            this.rdbScale_Out.Text = "&3. In phiếu xuất hàng / Delivery Note";
            this.rdbScale_Out.UnChecked = true;
            this.rdbScale_Out.UseVisualStyleBackColor = true;
            // 
            // txtMa_Vt_Sp_List
            // 
            this.txtMa_Vt_Sp_List.AutoDropDown = null;
            this.txtMa_Vt_Sp_List.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMa_Vt_Sp_List.Location = new System.Drawing.Point(129, 294);
            this.txtMa_Vt_Sp_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt_Sp_List.Name = "txtMa_Vt_Sp_List";
            this.txtMa_Vt_Sp_List.Size = new System.Drawing.Size(346, 20);
            this.txtMa_Vt_Sp_List.TabIndex = 10;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel3.Location = new System.Drawing.Point(7, 297);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(106, 13);
            this.rsLabel3.TabIndex = 5;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Danh sách mặt hàng";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel1.Location = new System.Drawing.Point(7, 275);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(76, 13);
            this.rsLabel1.TabIndex = 5;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Tên công trình";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Cong_Trinh
            // 
            this.txtTen_Cong_Trinh.AutoDropDown = null;
            this.txtTen_Cong_Trinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTen_Cong_Trinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_Cong_Trinh.Location = new System.Drawing.Point(129, 272);
            this.txtTen_Cong_Trinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Cong_Trinh.Name = "txtTen_Cong_Trinh";
            this.txtTen_Cong_Trinh.Size = new System.Drawing.Size(346, 20);
            this.txtTen_Cong_Trinh.TabIndex = 9;
            // 
            // txtTen_Dt
            // 
            this.txtTen_Dt.AutoDropDown = null;
            this.txtTen_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTen_Dt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_Dt.Location = new System.Drawing.Point(129, 250);
            this.txtTen_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Dt.Name = "txtTen_Dt";
            this.txtTen_Dt.Size = new System.Drawing.Size(346, 20);
            this.txtTen_Dt.TabIndex = 8;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel2.Location = new System.Drawing.Point(7, 253);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(86, 13);
            this.rsLabel2.TabIndex = 9;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Tên khách hàng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.AutoDropDown = null;
            this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSo_Ct.Location = new System.Drawing.Point(129, 189);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.Size = new System.Drawing.Size(192, 20);
            this.txtSo_Ct.TabIndex = 7;
            this.txtSo_Ct.Visible = false;
            // 
            // lblSo_Ct
            // 
            this.lblSo_Ct.AutoEllipsis = true;
            this.lblSo_Ct.AutoSize = true;
            this.lblSo_Ct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSo_Ct.Location = new System.Drawing.Point(7, 189);
            this.lblSo_Ct.Name = "lblSo_Ct";
            this.lblSo_Ct.Size = new System.Drawing.Size(49, 13);
            this.lblSo_Ct.TabIndex = 12;
            this.lblSo_Ct.Tag = "";
            this.lblSo_Ct.Text = "Số phiếu";
            this.lblSo_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSo_Ct.Visible = false;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNgay_Ct.Location = new System.Drawing.Point(326, 192);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(78, 13);
            this.lblNgay_Ct.TabIndex = 13;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Ngày lập phiếu";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNgay_Ct.Visible = false;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = true;
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(409, 189);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct.TabIndex = 14;
            this.dteNgay_Ct.Visible = false;
            // 
            // rdbKCS
            // 
            this.rdbKCS.AutoSize = true;
            this.rdbKCS.Location = new System.Drawing.Point(80, 83);
            this.rdbKCS.Name = "rdbKCS";
            this.rdbKCS.Size = new System.Drawing.Size(137, 17);
            this.rdbKCS.TabIndex = 15;
            this.rdbKCS.Tag = "";
            this.rdbKCS.Text = "&4. Phiếu KCS (bản giấy)";
            this.rdbKCS.UnChecked = true;
            this.rdbKCS.UseVisualStyleBackColor = true;
            // 
            // rdbCNXX
            // 
            this.rdbCNXX.AutoSize = true;
            this.rdbCNXX.Checked = true;
            this.rdbCNXX.Location = new System.Drawing.Point(80, 106);
            this.rdbCNXX.Name = "rdbCNXX";
            this.rdbCNXX.Size = new System.Drawing.Size(260, 17);
            this.rdbCNXX.TabIndex = 16;
            this.rdbCNXX.TabStop = true;
            this.rdbCNXX.Tag = "";
            this.rdbCNXX.Text = "&5. Giấy chứng nhận xuất xưởng và CLSP (điện tử)";
            this.rdbCNXX.UnChecked = false;
            this.rdbCNXX.UseVisualStyleBackColor = true;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(-94, 161);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(60, 13);
            this.rsLabel4.TabIndex = 90;
            this.rsLabel4.Text = "Đường dẫn";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPath
            // 
            this.btPath.Location = new System.Drawing.Point(465, 161);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(59, 23);
            this.btPath.TabIndex = 89;
            this.btPath.Text = "Browse";
            this.btPath.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.AutoDropDown = null;
            this.txtPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPath.Location = new System.Drawing.Point(129, 163);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPath.MaxLength = 20;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(335, 20);
            this.txtPath.TabIndex = 88;
            this.txtPath.Text = "D:\\CNXX";
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel5.Location = new System.Drawing.Point(7, 166);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(123, 13);
            this.rsLabel5.TabIndex = 12;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Đường dẫn xuất file PDF";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel7.Location = new System.Drawing.Point(7, 227);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(119, 13);
            this.rsLabel7.TabIndex = 12;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Chọn số lệnh xuất hàng";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSo_LXH
            // 
            this.cboSo_LXH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSo_LXH.DropDownHeight = 147;
            this.cboSo_LXH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSo_LXH.FormattingEnabled = true;
            this.cboSo_LXH.IntegralHeight = false;
            this.cboSo_LXH.Location = new System.Drawing.Point(129, 223);
            this.cboSo_LXH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboSo_LXH.Name = "cboSo_LXH";
            this.cboSo_LXH.Size = new System.Drawing.Size(192, 21);
            this.cboSo_LXH.TabIndex = 265;
            // 
            // btCreateCNXX
            // 
            this.btCreateCNXX.Location = new System.Drawing.Point(326, 223);
            this.btCreateCNXX.Name = "btCreateCNXX";
            this.btCreateCNXX.Size = new System.Drawing.Size(88, 23);
            this.btCreateCNXX.TabIndex = 89;
            this.btCreateCNXX.Text = "Kết xuất CNXX";
            this.btCreateCNXX.UseVisualStyleBackColor = true;
            // 
            // chkNum_Lot
            // 
            this.chkNum_Lot.AutoSize = true;
            this.chkNum_Lot.ForeColor = System.Drawing.Color.Red;
            this.chkNum_Lot.Location = new System.Drawing.Point(420, 225);
            this.chkNum_Lot.Name = "chkNum_Lot";
            this.chkNum_Lot.Size = new System.Drawing.Size(89, 17);
            this.chkNum_Lot.TabIndex = 266;
            this.chkNum_Lot.Text = "Nhóm theo lô";
            this.chkNum_Lot.UseVisualStyleBackColor = true;
            // 
            // frmChon_In_Scale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 379);
            this.Controls.Add(this.chkNum_Lot);
            this.Controls.Add(this.cboSo_LXH);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.btCreateCNXX);
            this.Controls.Add(this.btPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.rdbCNXX);
            this.Controls.Add(this.rdbKCS);
            this.Controls.Add(this.dteNgay_Ct);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.txtSo_Ct);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.lblSo_Ct);
            this.Controls.Add(this.txtTen_Dt);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtTen_Cong_Trinh);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Vt_Sp_List);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.rdbScale_Out);
            this.Controls.Add(this.rdbTruck_Out);
            this.Controls.Add(this.rdbTruck_In);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmChon_In_Scale";
            this.Text = "frmChon_In_Scale";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsRadioButton rdbTruck_In;
		public RosySystem.Control.rsRadioButton rdbTruck_Out;
        public RosySystem.Control.rsRadioButton rdbScale_Out;
		private RosySystem.Control.rsLabel rsLabel3;
		public RosySystem.Control.rsTextBox txtMa_Vt_Sp_List;
		private RosySystem.Control.rsLabel rsLabel1;
		public RosySystem.Control.rsTextBox txtTen_Cong_Trinh;
		public RosySystem.Control.rsTextBox txtTen_Dt;
        private RosySystem.Control.rsLabel rsLabel2;
		public RosySystem.Control.rsTextBox txtSo_Ct;
		private RosySystem.Control.rsLabel lblSo_Ct;
		private RosySystem.Control.rsLabel lblNgay_Ct;
		public RosySystem.Control.rsDateTime dteNgay_Ct;
        public RosySystem.Control.rsRadioButton rdbKCS;
        public RosySystem.Control.rsRadioButton rdbCNXX;
        private RosySystem.Control.rsLabel rsLabel4;
        private System.Windows.Forms.Button btPath;
        private RosySystem.Control.rsLabel rsLabel5;
        public RosySystem.Control.rsTextBox txtPath;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsComboBox cboSo_LXH;
        private System.Windows.Forms.Button btCreateCNXX;
        public RosySystem.Control.rsCheckbox chkNum_Lot;
    }
}