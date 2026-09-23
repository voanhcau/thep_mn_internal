namespace RosyModule
{
    partial class frmXacNhanCN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvHanTt = new RosySystem.Control.rsDataGridView();
            this.btPrint = new RosySystem.Control.rsButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.txtChuc_Vu_Kt = new RosySystem.Control.txtTextBox();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.txtChuc_Vu_TGD = new RosySystem.Control.txtTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtTen_Gd = new RosySystem.Control.txtTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.txtTen_Kt = new RosySystem.Control.txtTextBox();
            this.btBrower = new RosySystem.Control.rsButton();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtPath = new RosySystem.Control.txtTextBox();
            this.cboMember_ID = new RosySystem.Control.rsMultiComboBox();
            this.rdbMau3 = new System.Windows.Forms.RadioButton();
            this.rdbMau2 = new System.Windows.Forms.RadioButton();
            this.rdbMau1 = new System.Windows.Forms.RadioButton();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Gui = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ph = new RosySystem.Control.rsDateTime();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.txtEmail = new RosySystem.Control.txtTextBox();
            this.lblControl1 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lblMa_Dt = new RosySystem.Control.rsLabel();
            this.txtNguoi_Nhan = new RosySystem.Control.txtTextBox();
            this.btExit = new RosySystem.Control.rsButton();
            this.btSendMail = new RosySystem.Control.rsButton();
            this.btPreview = new RosySystem.Control.rsButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvExportExcel_2 = new RosySystem.Control.rsDataGridView();
            this.dgvExportExcel_1 = new RosySystem.Control.rsDataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportExcel_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportExcel_1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvHanTt);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 280);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin công nợ";
            // 
            // dgvHanTt
            // 
            this.dgvHanTt.AllowUserToAddRows = false;
            this.dgvHanTt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHanTt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHanTt.BackgroundColor = System.Drawing.Color.White;
            this.dgvHanTt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHanTt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHanTt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHanTt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvHanTt.Location = new System.Drawing.Point(3, 18);
            this.dgvHanTt.MultiSelect = false;
            this.dgvHanTt.Name = "dgvHanTt";
            this.dgvHanTt.ReadOnly = true;
            this.dgvHanTt.Size = new System.Drawing.Size(775, 259);
            this.dgvHanTt.strZone = "";
            this.dgvHanTt.TabIndex = 0;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.ForeColor = System.Drawing.Color.Blue;
            this.btPrint.Location = new System.Drawing.Point(7, 521);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(84, 42);
            this.btPrint.TabIndex = 7;
            this.btPrint.Tag = "Print";
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rsLabel10);
            this.groupBox1.Controls.Add(this.txtChuc_Vu_Kt);
            this.groupBox1.Controls.Add(this.txtMa_Dt);
            this.groupBox1.Controls.Add(this.lbtTen_Dt);
            this.groupBox1.Controls.Add(this.rsLabel9);
            this.groupBox1.Controls.Add(this.rsLabel8);
            this.groupBox1.Controls.Add(this.txtChuc_Vu_TGD);
            this.groupBox1.Controls.Add(this.rsLabel7);
            this.groupBox1.Controls.Add(this.txtTen_Gd);
            this.groupBox1.Controls.Add(this.rsLabel6);
            this.groupBox1.Controls.Add(this.txtTen_Kt);
            this.groupBox1.Controls.Add(this.btBrower);
            this.groupBox1.Controls.Add(this.rsLabel5);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.cboMember_ID);
            this.groupBox1.Controls.Add(this.rdbMau3);
            this.groupBox1.Controls.Add(this.rdbMau2);
            this.groupBox1.Controls.Add(this.rdbMau1);
            this.groupBox1.Controls.Add(this.rsLabel4);
            this.groupBox1.Controls.Add(this.rsLabel3);
            this.groupBox1.Controls.Add(this.rsLabel2);
            this.groupBox1.Controls.Add(this.dteNgay_Gui);
            this.groupBox1.Controls.Add(this.dteNgay_Ph);
            this.groupBox1.Controls.Add(this.btRefresh);
            this.groupBox1.Controls.Add(this.dteNgay_Ct);
            this.groupBox1.Controls.Add(this.lblNgay_Ct);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.lblControl1);
            this.groupBox1.Controls.Add(this.rsLabel1);
            this.groupBox1.Controls.Add(this.lblMa_Dt);
            this.groupBox1.Controls.Add(this.txtNguoi_Nhan);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 224);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin lọc công nợ";
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Location = new System.Drawing.Point(409, 36);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(86, 13);
            this.rsLabel10.TabIndex = 196;
            this.rsLabel10.Tag = "";
            this.rsLabel10.Text = "Chức vụ kế toán";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChuc_Vu_Kt
            // 
            this.txtChuc_Vu_Kt.bEnabled = true;
            this.txtChuc_Vu_Kt.bReadOnly = false;
            this.txtChuc_Vu_Kt.Location = new System.Drawing.Point(509, 32);
            this.txtChuc_Vu_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtChuc_Vu_Kt.MaxLength = 200;
            this.txtChuc_Vu_Kt.Name = "txtChuc_Vu_Kt";
            this.txtChuc_Vu_Kt.Size = new System.Drawing.Size(181, 20);
            this.txtChuc_Vu_Kt.TabIndex = 195;
            this.txtChuc_Vu_Kt.Text = "Kế toán trưởng";
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(254, 189);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 193;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(377, 192);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(75, 13);
            this.lbtTen_Dt.TabIndex = 194;
            this.lbtTen_Dt.Text = "Tên KH - NCC";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(13, 193);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(238, 13);
            this.rsLabel9.TabIndex = 192;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Mã đối tượng KH - NCC không có số dư công nợ";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(409, 79);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(94, 13);
            this.rsLabel8.TabIndex = 191;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Chức vụ giám đốc";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChuc_Vu_TGD
            // 
            this.txtChuc_Vu_TGD.bEnabled = true;
            this.txtChuc_Vu_TGD.bReadOnly = false;
            this.txtChuc_Vu_TGD.Location = new System.Drawing.Point(509, 75);
            this.txtChuc_Vu_TGD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtChuc_Vu_TGD.MaxLength = 200;
            this.txtChuc_Vu_TGD.Name = "txtChuc_Vu_TGD";
            this.txtChuc_Vu_TGD.Size = new System.Drawing.Size(181, 20);
            this.txtChuc_Vu_TGD.TabIndex = 190;
            this.txtChuc_Vu_TGD.Text = "Tổng Giám Đốc";
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(409, 98);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(73, 13);
            this.rsLabel7.TabIndex = 189;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Tên giám đốc";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Gd
            // 
            this.txtTen_Gd.bEnabled = true;
            this.txtTen_Gd.bReadOnly = false;
            this.txtTen_Gd.Location = new System.Drawing.Point(509, 97);
            this.txtTen_Gd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Gd.MaxLength = 200;
            this.txtTen_Gd.Name = "txtTen_Gd";
            this.txtTen_Gd.Size = new System.Drawing.Size(181, 20);
            this.txtTen_Gd.TabIndex = 188;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(409, 58);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(98, 13);
            this.rsLabel6.TabIndex = 187;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Tên kế toán trưởng";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Kt
            // 
            this.txtTen_Kt.bEnabled = true;
            this.txtTen_Kt.bReadOnly = false;
            this.txtTen_Kt.Location = new System.Drawing.Point(509, 54);
            this.txtTen_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Kt.MaxLength = 200;
            this.txtTen_Kt.Name = "txtTen_Kt";
            this.txtTen_Kt.Size = new System.Drawing.Size(181, 20);
            this.txtTen_Kt.TabIndex = 186;
            // 
            // btBrower
            // 
            this.btBrower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBrower.ForeColor = System.Drawing.Color.Blue;
            this.btBrower.Location = new System.Drawing.Point(717, 159);
            this.btBrower.Name = "btBrower";
            this.btBrower.Size = new System.Drawing.Size(58, 24);
            this.btBrower.TabIndex = 185;
            this.btBrower.Tag = "";
            this.btBrower.Text = "....";
            this.btBrower.UseVisualStyleBackColor = true;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(16, 168);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(60, 13);
            this.rsLabel5.TabIndex = 184;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Đường dẫn";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPath
            // 
            this.txtPath.bEnabled = true;
            this.txtPath.bReadOnly = false;
            this.txtPath.Location = new System.Drawing.Point(109, 162);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPath.MaxLength = 200;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(603, 20);
            this.txtPath.TabIndex = 183;
            this.txtPath.Text = "D:\\BBXNCN_ROSY";
            // 
            // cboMember_ID
            // 
            this.cboMember_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMember_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMember_ID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMember_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMember_ID.Location = new System.Drawing.Point(509, 9);
            this.cboMember_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMember_ID.MaxLength = 20;
            this.cboMember_ID.Name = "cboMember_ID";
            this.cboMember_ID.Size = new System.Drawing.Size(102, 21);
            this.cboMember_ID.TabIndex = 182;
            // 
            // rdbMau3
            // 
            this.rdbMau3.AutoSize = true;
            this.rdbMau3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMau3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rdbMau3.Location = new System.Drawing.Point(108, 92);
            this.rdbMau3.Name = "rdbMau3";
            this.rdbMau3.Size = new System.Drawing.Size(158, 17);
            this.rdbMau3.TabIndex = 30;
            this.rdbMau3.TabStop = true;
            this.rdbMau3.Text = "3.Xác nhận nợ ngoại tệ";
            this.rdbMau3.UseVisualStyleBackColor = true;
            // 
            // rdbMau2
            // 
            this.rdbMau2.AutoSize = true;
            this.rdbMau2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMau2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rdbMau2.Location = new System.Drawing.Point(108, 75);
            this.rdbMau2.Name = "rdbMau2";
            this.rdbMau2.Size = new System.Drawing.Size(119, 17);
            this.rdbMau2.TabIndex = 29;
            this.rdbMau2.TabStop = true;
            this.rdbMau2.Text = "2. Xác nhận 131";
            this.rdbMau2.UseVisualStyleBackColor = true;
            // 
            // rdbMau1
            // 
            this.rdbMau1.AutoSize = true;
            this.rdbMau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMau1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rdbMau1.Location = new System.Drawing.Point(108, 58);
            this.rdbMau1.Name = "rdbMau1";
            this.rdbMau1.Size = new System.Drawing.Size(148, 17);
            this.rdbMau1.TabIndex = 28;
            this.rdbMau1.TabStop = true;
            this.rdbMau1.Text = "1. Xác nhận tổng hợp";
            this.rdbMau1.UseVisualStyleBackColor = true;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(15, 76);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(68, 13);
            this.rsLabel4.TabIndex = 26;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Xác nhận nợ";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(15, 121);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(62, 13);
            this.rsLabel3.TabIndex = 25;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Người nhận";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(15, 145);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(32, 13);
            this.rsLabel2.TabIndex = 24;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Email";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Gui
            // 
            this.dteNgay_Gui.bAllowEmpty = true;
            this.dteNgay_Gui.bSelectOnFocus = false;
            this.dteNgay_Gui.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Gui.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Gui.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Gui.Location = new System.Drawing.Point(317, 12);
            this.dteNgay_Gui.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Gui.Mask = "00/00/0000";
            this.dteNgay_Gui.Name = "dteNgay_Gui";
            this.dteNgay_Gui.Size = new System.Drawing.Size(78, 20);
            this.dteNgay_Gui.TabIndex = 22;
            // 
            // dteNgay_Ph
            // 
            this.dteNgay_Ph.bAllowEmpty = true;
            this.dteNgay_Ph.bSelectOnFocus = false;
            this.dteNgay_Ph.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ph.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ph.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ph.Location = new System.Drawing.Point(317, 34);
            this.dteNgay_Ph.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ph.Mask = "00/00/0000";
            this.dteNgay_Ph.Name = "dteNgay_Ph";
            this.dteNgay_Ph.Size = new System.Drawing.Size(78, 20);
            this.dteNgay_Ph.TabIndex = 21;
            // 
            // btRefresh
            // 
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ForeColor = System.Drawing.Color.Blue;
            this.btRefresh.Location = new System.Drawing.Point(695, 14);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(80, 42);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Tag = "Refresh";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = true;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(108, 16);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(78, 20);
            this.dteNgay_Ct.TabIndex = 0;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(14, 19);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(94, 13);
            this.lblNgay_Ct.TabIndex = 0;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Ngày xác nhận nợ";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.bEnabled = true;
            this.txtEmail.bReadOnly = false;
            this.txtEmail.Location = new System.Drawing.Point(108, 138);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(634, 20);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "phongketoan@thepmiennam.com.vn";
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.Location = new System.Drawing.Point(190, 17);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(116, 13);
            this.lblControl1.TabIndex = 2;
            this.lblControl1.Tag = "";
            this.lblControl1.Text = "Ngày xác gởi xác nhận";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(409, 12);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(95, 13);
            this.rsLabel1.TabIndex = 5;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Nhân viên kế toán";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.Location = new System.Drawing.Point(190, 39);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(93, 13);
            this.lblMa_Dt.TabIndex = 5;
            this.lblMa_Dt.Tag = "";
            this.lblMa_Dt.Text = "Thời hạn phản hồi";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNguoi_Nhan
            // 
            this.txtNguoi_Nhan.bEnabled = true;
            this.txtNguoi_Nhan.bReadOnly = false;
            this.txtNguoi_Nhan.Location = new System.Drawing.Point(108, 114);
            this.txtNguoi_Nhan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNguoi_Nhan.MaxLength = 200;
            this.txtNguoi_Nhan.Name = "txtNguoi_Nhan";
            this.txtNguoi_Nhan.Size = new System.Drawing.Size(399, 20);
            this.txtNguoi_Nhan.TabIndex = 2;
            this.txtNguoi_Nhan.Text = "Phòng Kế toán tài chính";
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.Blue;
            this.btExit.Location = new System.Drawing.Point(258, 521);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(79, 42);
            this.btExit.TabIndex = 8;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btSendMail
            // 
            this.btSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSendMail.ForeColor = System.Drawing.Color.Blue;
            this.btSendMail.Location = new System.Drawing.Point(178, 521);
            this.btSendMail.Name = "btSendMail";
            this.btSendMail.Size = new System.Drawing.Size(79, 42);
            this.btSendMail.TabIndex = 8;
            this.btSendMail.Tag = "";
            this.btSendMail.Text = "Gửi email";
            this.btSendMail.UseVisualStyleBackColor = true;
            // 
            // btPreview
            // 
            this.btPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreview.ForeColor = System.Drawing.Color.Blue;
            this.btPreview.Location = new System.Drawing.Point(93, 521);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(84, 42);
            this.btPreview.TabIndex = 9;
            this.btPreview.Tag = "";
            this.btPreview.Text = "Preview";
            this.btPreview.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvExportExcel_2);
            this.groupBox3.Controls.Add(this.dgvExportExcel_1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 370);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(781, 145);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin công nợ";
            this.groupBox3.Visible = false;
            // 
            // dgvExportExcel_2
            // 
            this.dgvExportExcel_2.AllowUserToAddRows = false;
            this.dgvExportExcel_2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvExportExcel_2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExportExcel_2.BackgroundColor = System.Drawing.Color.White;
            this.dgvExportExcel_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExportExcel_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportExcel_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExportExcel_2.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvExportExcel_2.Location = new System.Drawing.Point(3, 18);
            this.dgvExportExcel_2.MultiSelect = false;
            this.dgvExportExcel_2.Name = "dgvExportExcel_2";
            this.dgvExportExcel_2.ReadOnly = true;
            this.dgvExportExcel_2.Size = new System.Drawing.Size(775, 124);
            this.dgvExportExcel_2.strZone = "";
            this.dgvExportExcel_2.TabIndex = 1;
            // 
            // dgvExportExcel_1
            // 
            this.dgvExportExcel_1.AllowUserToAddRows = false;
            this.dgvExportExcel_1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvExportExcel_1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExportExcel_1.BackgroundColor = System.Drawing.Color.White;
            this.dgvExportExcel_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExportExcel_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportExcel_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExportExcel_1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvExportExcel_1.Location = new System.Drawing.Point(3, 18);
            this.dgvExportExcel_1.MultiSelect = false;
            this.dgvExportExcel_1.Name = "dgvExportExcel_1";
            this.dgvExportExcel_1.ReadOnly = true;
            this.dgvExportExcel_1.Size = new System.Drawing.Size(775, 124);
            this.dgvExportExcel_1.strZone = "";
            this.dgvExportExcel_1.TabIndex = 0;
            // 
            // frmXacNhanCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btPreview);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btSendMail);
            this.Controls.Add(this.btExit);
            this.Name = "frmXacNhanCN";
            this.Text = "frmXacNhanCN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportExcel_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportExcel_1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Control.rsButton btExit;
        private System.Windows.Forms.GroupBox groupBox1;
		private RosySystem.Control.rsButton btPrint;
		private System.Windows.Forms.GroupBox groupBox2;
		private RosySystem.Control.rsDataGridView dgvHanTt;
		private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsLabel lblMa_Dt;
        private RosySystem.Control.rsLabel lblControl1;
        public RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel2;
        public RosySystem.Control.rsDateTime dteNgay_Gui;
        public RosySystem.Control.rsDateTime dteNgay_Ph;
        private RosySystem.Control.rsButton btSendMail;
        private RosySystem.Control.txtTextBox txtNguoi_Nhan;
        private RosySystem.Control.txtTextBox txtEmail;
        private RosySystem.Control.rsButton btPreview;
        private System.Windows.Forms.RadioButton rdbMau3;
        private System.Windows.Forms.RadioButton rdbMau2;
        private System.Windows.Forms.RadioButton rdbMau1;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsMultiComboBox cboMember_ID;
        private System.Windows.Forms.GroupBox groupBox3;
        private RosySystem.Control.rsDataGridView dgvExportExcel_1;
        private RosySystem.Control.rsButton btBrower;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.txtTextBox txtPath;
        private RosySystem.Control.rsDataGridView dgvExportExcel_2;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.txtTextBox txtTen_Gd;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.txtTextBox txtTen_Kt;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.txtTextBox txtChuc_Vu_TGD;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Control.rsLabel lbtTen_Dt;
        private RosySystem.Control.rsLabel rsLabel10;
        private RosySystem.Control.txtTextBox txtChuc_Vu_Kt;
    }
}