namespace RosyModule.Salary
{
	partial class frmBangLuong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangLuong));
            this.btCalcSalary = new RosySystem.Control.rsButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cboMa_Bp = new RosySystem.Control.rsMultiComboBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
            this.btPostedSalary = new RosySystem.Control.rsButton();
            this.btDeleteSalary = new RosySystem.Control.rsButton();
            this.cboThang = new RosySystem.Control.rsComboBox();
            this.btImport = new RosySystem.Control.rsButton();
            this.btPrint = new RosySystem.Control.rsButton();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp_Ct = new RosySystem.Control.rsLabelName();
            this.cboMa_Bp_Ct = new RosySystem.Control.rsMultiComboBox();
            this.btPrintPhieuLuong = new RosySystem.Control.rsButton();
            this.btSendPhieuLuong = new RosySystem.Control.rsButton();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.rsLabel21 = new RosySystem.Control.rsLabel();
            this.numTTLuongDP = new RosySystem.Control.rsTextBoxNumber();
            this.lblNote = new RosySystem.Control.rsLabel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCalcSalary
            // 
            this.btCalcSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCalcSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalcSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCalcSalary.ImageKey = "calc";
            this.btCalcSalary.ImageList = this.imageList1;
            this.btCalcSalary.Location = new System.Drawing.Point(104, 513);
            this.btCalcSalary.Name = "btCalcSalary";
            this.btCalcSalary.Size = new System.Drawing.Size(97, 47);
            this.btCalcSalary.TabIndex = 4;
            this.btCalcSalary.Tag = "Tinh_Luong";
            this.btCalcSalary.Text = "Tính &lương";
            this.btCalcSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCalcSalary.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "posted");
            this.imageList1.Images.SetKeyName(1, "delete");
            this.imageList1.Images.SetKeyName(2, "calc");
            this.imageList1.Images.SetKeyName(3, "add");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Tag = "Thang";
            this.label1.Text = "Tháng";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(3, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 408);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(256, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 24);
            this.panel2.TabIndex = 7;
            this.panel2.TabStop = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(384, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(140, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "Thanh_Toan_Luong";
            this.radioButton3.Text = "&3. Thanh toán lương";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(212, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(166, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "Giam_Luong";
            this.radioButton2.Text = "&2. Các khoản giảm lương";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(5, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(207, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "Luong_Phu_Cap";
            this.radioButton1.Text = "&1. Lương và các khoản phụ cấp";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // cboMa_Bp
            // 
            this.cboMa_Bp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp.Location = new System.Drawing.Point(103, 28);
            this.cboMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp.MaxLength = 20;
            this.cboMa_Bp.Name = "cboMa_Bp";
            this.cboMa_Bp.Size = new System.Drawing.Size(116, 21);
            this.cboMa_Bp.TabIndex = 1;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTk.Location = new System.Drawing.Point(5, 31);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(54, 13);
            this.lblTk.TabIndex = 65;
            this.lblTk.Tag = "Ma_Bp";
            this.lblTk.Text = "Bộ phận";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp.Location = new System.Drawing.Point(224, 33);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp.TabIndex = 65;
            this.lbtTen_Bp.Tag = "";
            this.lbtTen_Bp.Text = "Tên Bộ phận";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPostedSalary
            // 
            this.btPostedSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPostedSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPostedSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPostedSalary.ImageKey = "posted";
            this.btPostedSalary.ImageList = this.imageList1;
            this.btPostedSalary.Location = new System.Drawing.Point(310, 513);
            this.btPostedSalary.Name = "btPostedSalary";
            this.btPostedSalary.Size = new System.Drawing.Size(97, 47);
            this.btPostedSalary.TabIndex = 4;
            this.btPostedSalary.Tag = "Hach_Toan_Luong";
            this.btPostedSalary.Text = "&Hạch toán lương";
            this.btPostedSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPostedSalary.UseVisualStyleBackColor = true;
            this.btPostedSalary.Visible = false;
            this.btPostedSalary.Click += new System.EventHandler(this.btPostedSalary_Click_1);
            // 
            // btDeleteSalary
            // 
            this.btDeleteSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeleteSalary.Enabled = false;
            this.btDeleteSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeleteSalary.ImageKey = "delete";
            this.btDeleteSalary.ImageList = this.imageList1;
            this.btDeleteSalary.Location = new System.Drawing.Point(207, 513);
            this.btDeleteSalary.Name = "btDeleteSalary";
            this.btDeleteSalary.Size = new System.Drawing.Size(97, 47);
            this.btDeleteSalary.TabIndex = 4;
            this.btDeleteSalary.Tag = "Xoa_Bang_Luong";
            this.btDeleteSalary.Text = "&Xóa bảng lương";
            this.btDeleteSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDeleteSalary.UseVisualStyleBackColor = true;
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(103, 5);
            this.cboThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(51, 21);
            this.cboThang.TabIndex = 66;
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.ImageKey = "add";
            this.btImport.ImageList = this.imageList1;
            this.btImport.Location = new System.Drawing.Point(7, 513);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(97, 47);
            this.btImport.TabIndex = 67;
            this.btImport.Tag = "";
            this.btImport.Text = "&Import excel DL Lương";
            this.btImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "posted";
            this.btPrint.Location = new System.Drawing.Point(410, 513);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(97, 47);
            this.btPrint.TabIndex = 4;
            this.btPrint.Tag = "In_Bang_Luong";
            this.btPrint.Text = "&In QT lương";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(5, 54);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(97, 13);
            this.rsLabel1.TabIndex = 65;
            this.rsLabel1.Tag = "Ma_Bp_Ct";
            this.rsLabel1.Text = "Bộ phận chi tiết";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp_Ct
            // 
            this.lbtTen_Bp_Ct.AutoSize = true;
            this.lbtTen_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp_Ct.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp_Ct.Location = new System.Drawing.Point(224, 56);
            this.lbtTen_Bp_Ct.Name = "lbtTen_Bp_Ct";
            this.lbtTen_Bp_Ct.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp_Ct.TabIndex = 65;
            this.lbtTen_Bp_Ct.Tag = "";
            this.lbtTen_Bp_Ct.Text = "Tên Bộ phận";
            this.lbtTen_Bp_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_Bp_Ct
            // 
            this.cboMa_Bp_Ct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp_Ct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp_Ct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp_Ct.Location = new System.Drawing.Point(103, 51);
            this.cboMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp_Ct.MaxLength = 20;
            this.cboMa_Bp_Ct.Name = "cboMa_Bp_Ct";
            this.cboMa_Bp_Ct.Size = new System.Drawing.Size(116, 21);
            this.cboMa_Bp_Ct.TabIndex = 1;
            // 
            // btPrintPhieuLuong
            // 
            this.btPrintPhieuLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrintPhieuLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrintPhieuLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrintPhieuLuong.ImageKey = "posted";
            this.btPrintPhieuLuong.Location = new System.Drawing.Point(508, 513);
            this.btPrintPhieuLuong.Name = "btPrintPhieuLuong";
            this.btPrintPhieuLuong.Size = new System.Drawing.Size(97, 47);
            this.btPrintPhieuLuong.TabIndex = 4;
            this.btPrintPhieuLuong.Tag = "";
            this.btPrintPhieuLuong.Text = "&In phiếu lương";
            this.btPrintPhieuLuong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrintPhieuLuong.UseVisualStyleBackColor = true;
            // 
            // btSendPhieuLuong
            // 
            this.btSendPhieuLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSendPhieuLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSendPhieuLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSendPhieuLuong.ImageKey = "posted";
            this.btSendPhieuLuong.Location = new System.Drawing.Point(607, 513);
            this.btSendPhieuLuong.Name = "btSendPhieuLuong";
            this.btSendPhieuLuong.Size = new System.Drawing.Size(97, 47);
            this.btSendPhieuLuong.TabIndex = 4;
            this.btSendPhieuLuong.Tag = "";
            this.btSendPhieuLuong.Text = "&Gửi phiếu lương";
            this.btSendPhieuLuong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSendPhieuLuong.UseVisualStyleBackColor = true;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(5, 76);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(97, 13);
            this.rsLabel2.TabIndex = 68;
            this.rsLabel2.Tag = "Ma_Dt_CbNv";
            this.rsLabel2.Text = "Bộ phận chi tiết";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(103, 74);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(116, 20);
            this.txtMa_Dt_CbNv.TabIndex = 69;
            this.txtMa_Dt_CbNv.Tag = "";
            // 
            // rsLabel21
            // 
            this.rsLabel21.AutoEllipsis = true;
            this.rsLabel21.AutoSize = true;
            this.rsLabel21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel21.Location = new System.Drawing.Point(305, 36);
            this.rsLabel21.Name = "rsLabel21";
            this.rsLabel21.Size = new System.Drawing.Size(198, 16);
            this.rsLabel21.TabIndex = 116;
            this.rsLabel21.Tag = "";
            this.rsLabel21.Text = "Trích từ quỹ lương dự phòng";
            this.rsLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTTLuongDP
            // 
            this.numTTLuongDP.AutoDropDown = null;
            this.numTTLuongDP.bFormat = true;
            this.numTTLuongDP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numTTLuongDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTLuongDP.Location = new System.Drawing.Point(508, 33);
            this.numTTLuongDP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTLuongDP.MaxLength = 20;
            this.numTTLuongDP.Name = "numTTLuongDP";
            this.numTTLuongDP.Scale = 0;
            this.numTTLuongDP.Size = new System.Drawing.Size(139, 22);
            this.numTTLuongDP.TabIndex = 115;
            this.numTTLuongDP.Text = "0";
            this.numTTLuongDP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTLuongDP.Value = 0D;
            // 
            // lblNote
            // 
            this.lblNote.AutoEllipsis = true;
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point(235, 77);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(33, 15);
            this.lblNote.TabIndex = 117;
            this.lblNote.Tag = "";
            this.lblNote.Text = "ABC";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBangLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.rsLabel21);
            this.Controls.Add(this.numTTLuongDP);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.cboMa_Bp_Ct);
            this.Controls.Add(this.lbtTen_Bp_Ct);
            this.Controls.Add(this.cboMa_Bp);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDeleteSalary);
            this.Controls.Add(this.btSendPhieuLuong);
            this.Controls.Add(this.btPrintPhieuLuong);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btPostedSalary);
            this.Controls.Add(this.btCalcSalary);
            this.Name = "frmBangLuong";
            this.Text = "frmBangLuong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsButton btCalcSalary;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
		private RosySystem.Control.rsMultiComboBox cboMa_Bp;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Control.rsLabelName lbtTen_Bp;
		private RosySystem.Control.rsButton btPostedSalary;
		private RosySystem.Control.rsButton btDeleteSalary;
		private RosySystem.Control.rsComboBox cboThang;
		private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Control.rsButton btImport;
        private RosySystem.Control.rsButton btPrint;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabelName lbtTen_Bp_Ct;
        private RosySystem.Control.rsMultiComboBox cboMa_Bp_Ct;
        private RosySystem.Control.rsButton btPrintPhieuLuong;
        private RosySystem.Control.rsButton btSendPhieuLuong;
        private RosySystem.Control.rsLabel rsLabel2;
        public RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabel rsLabel21;
        private RosySystem.Control.rsTextBoxNumber numTTLuongDP;
        private RosySystem.Control.rsLabel lblNote;
    }
}