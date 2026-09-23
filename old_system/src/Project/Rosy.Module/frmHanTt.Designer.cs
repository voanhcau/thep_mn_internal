namespace RosyModule
{
	partial class frmHanTt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvHanTt = new RosySystem.Control.rsDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.numTTien_CLTG = new RosySystem.Control.rsTextBoxNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.numTTien_Tt_Nt = new RosySystem.Control.rsTextBoxNumber();
            this.numTTien_Tt = new RosySystem.Control.rsTextBoxNumber();
            this.btSave = new RosySystem.Control.rsButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUpdate_Ngay_Ct = new RosySystem.Control.rsCheckbox();
            this.chkDu_Cuoi_Only = new RosySystem.Control.rsCheckbox();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.numTy_Gia = new RosySystem.Control.rsTextBoxNumber();
            this.dgvThanhToan = new RosySystem.Control.rsDataGridView();
            this.txtMa_Tte = new RosySystem.Control.rsTextBoxEnum();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.lblMa_Tte = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.txtTk = new RosySystem.Control.txtTextBox();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.lblControl1 = new RosySystem.Control.rsLabel();
            this.lblMa_Dt = new RosySystem.Control.rsLabel();
            this.lbtTen_Tk = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.txtTextBox();
            this.btExit = new RosySystem.Control.rsButton();
            this.chk02D = new RosySystem.Control.rsCheckbox();
            this.chk07D = new RosySystem.Control.rsCheckbox();
            this.chk39D = new RosySystem.Control.rsCheckbox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvHanTt);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 220);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn";
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
            this.dgvHanTt.Location = new System.Drawing.Point(3, 16);
            this.dgvHanTt.MultiSelect = false;
            this.dgvHanTt.Name = "dgvHanTt";
            this.dgvHanTt.ReadOnly = true;
            this.dgvHanTt.Size = new System.Drawing.Size(775, 201);
            this.dgvHanTt.strZone = "";
            this.dgvHanTt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(589, 543);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Tag = "";
            this.label2.Text = "Tiền CLTG";
            // 
            // numTTien_CLTG
            // 
            this.numTTien_CLTG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_CLTG.AutoDropDown = null;
            this.numTTien_CLTG.bFormat = true;
            this.numTTien_CLTG.Enabled = false;
            this.numTTien_CLTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_CLTG.Location = new System.Drawing.Point(662, 540);
            this.numTTien_CLTG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_CLTG.Name = "numTTien_CLTG";
            this.numTTien_CLTG.Scale = 0;
            this.numTTien_CLTG.Size = new System.Drawing.Size(121, 20);
            this.numTTien_CLTG.TabIndex = 11;
            this.numTTien_CLTG.Text = "0";
            this.numTTien_CLTG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_CLTG.Value = 0D;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(464, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 9;
            this.label1.Tag = "Tong_Cong";
            this.label1.Text = "Tổng cộng";
            // 
            // numTTien_Tt_Nt
            // 
            this.numTTien_Tt_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Tt_Nt.AutoDropDown = null;
            this.numTTien_Tt_Nt.bFormat = true;
            this.numTTien_Tt_Nt.Enabled = false;
            this.numTTien_Tt_Nt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Tt_Nt.Location = new System.Drawing.Point(537, 518);
            this.numTTien_Tt_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Tt_Nt.Name = "numTTien_Tt_Nt";
            this.numTTien_Tt_Nt.Scale = 2;
            this.numTTien_Tt_Nt.Size = new System.Drawing.Size(121, 20);
            this.numTTien_Tt_Nt.TabIndex = 9;
            this.numTTien_Tt_Nt.Text = "0.00";
            this.numTTien_Tt_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Tt_Nt.Value = 0D;
            // 
            // numTTien_Tt
            // 
            this.numTTien_Tt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Tt.AutoDropDown = null;
            this.numTTien_Tt.bFormat = true;
            this.numTTien_Tt.Enabled = false;
            this.numTTien_Tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Tt.Location = new System.Drawing.Point(662, 518);
            this.numTTien_Tt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Tt.Name = "numTTien_Tt";
            this.numTTien_Tt.Scale = 0;
            this.numTTien_Tt.Size = new System.Drawing.Size(121, 20);
            this.numTTien_Tt.TabIndex = 10;
            this.numTTien_Tt.Text = "0";
            this.numTTien_Tt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Tt.Value = 0D;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.Enabled = false;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.Blue;
            this.btSave.Location = new System.Drawing.Point(7, 521);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(84, 42);
            this.btSave.TabIndex = 7;
            this.btSave.Tag = "Save";
            this.btSave.Text = "Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chk39D);
            this.groupBox1.Controls.Add(this.chk07D);
            this.groupBox1.Controls.Add(this.chk02D);
            this.groupBox1.Controls.Add(this.chkUpdate_Ngay_Ct);
            this.groupBox1.Controls.Add(this.chkDu_Cuoi_Only);
            this.groupBox1.Controls.Add(this.btRefresh);
            this.groupBox1.Controls.Add(this.numTy_Gia);
            this.groupBox1.Controls.Add(this.dgvThanhToan);
            this.groupBox1.Controls.Add(this.txtMa_Tte);
            this.groupBox1.Controls.Add(this.dteNgay_Ct);
            this.groupBox1.Controls.Add(this.lblMa_Tte);
            this.groupBox1.Controls.Add(this.lblNgay_Ct);
            this.groupBox1.Controls.Add(this.txtTk);
            this.groupBox1.Controls.Add(this.lbtTen_Dt);
            this.groupBox1.Controls.Add(this.lblControl1);
            this.groupBox1.Controls.Add(this.lblMa_Dt);
            this.groupBox1.Controls.Add(this.lbtTen_Tk);
            this.groupBox1.Controls.Add(this.txtMa_Dt);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 277);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thanh toán";
            // 
            // chkUpdate_Ngay_Ct
            // 
            this.chkUpdate_Ngay_Ct.AutoSize = true;
            this.chkUpdate_Ngay_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdate_Ngay_Ct.ForeColor = System.Drawing.Color.Blue;
            this.chkUpdate_Ngay_Ct.Location = new System.Drawing.Point(189, 18);
            this.chkUpdate_Ngay_Ct.Name = "chkUpdate_Ngay_Ct";
            this.chkUpdate_Ngay_Ct.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkUpdate_Ngay_Ct.Size = new System.Drawing.Size(163, 17);
            this.chkUpdate_Ngay_Ct.TabIndex = 23;
            this.chkUpdate_Ngay_Ct.TabStop = false;
            this.chkUpdate_Ngay_Ct.Text = "Update ngày thanh toán";
            this.chkUpdate_Ngay_Ct.UseVisualStyleBackColor = true;
            // 
            // chkDu_Cuoi_Only
            // 
            this.chkDu_Cuoi_Only.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDu_Cuoi_Only.AutoSize = true;
            this.chkDu_Cuoi_Only.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDu_Cuoi_Only.Location = new System.Drawing.Point(433, 29);
            this.chkDu_Cuoi_Only.Name = "chkDu_Cuoi_Only";
            this.chkDu_Cuoi_Only.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDu_Cuoi_Only.Size = new System.Drawing.Size(254, 17);
            this.chkDu_Cuoi_Only.TabIndex = 22;
            this.chkDu_Cuoi_Only.Text = "Chỉ lấy những chứng từ chưa thanh toán";
            this.chkDu_Cuoi_Only.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Enabled = false;
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ForeColor = System.Drawing.Color.Blue;
            this.btRefresh.Location = new System.Drawing.Point(691, 30);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(80, 42);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Tag = "Refresh";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // numTy_Gia
            // 
            this.numTy_Gia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTy_Gia.AutoDropDown = null;
            this.numTy_Gia.bFormat = true;
            this.numTy_Gia.Enabled = false;
            this.numTy_Gia.Location = new System.Drawing.Point(691, 7);
            this.numTy_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTy_Gia.Name = "numTy_Gia";
            this.numTy_Gia.Scale = 2;
            this.numTy_Gia.Size = new System.Drawing.Size(80, 20);
            this.numTy_Gia.TabIndex = 3;
            this.numTy_Gia.Text = "0.00";
            this.numTy_Gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTy_Gia.Value = 0D;
            // 
            // dgvThanhToan
            // 
            this.dgvThanhToan.AllowUserToAddRows = false;
            this.dgvThanhToan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvThanhToan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThanhToan.BackgroundColor = System.Drawing.Color.White;
            this.dgvThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanhToan.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvThanhToan.Location = new System.Drawing.Point(3, 108);
            this.dgvThanhToan.MultiSelect = false;
            this.dgvThanhToan.Name = "dgvThanhToan";
            this.dgvThanhToan.ReadOnly = true;
            this.dgvThanhToan.Size = new System.Drawing.Size(768, 163);
            this.dgvThanhToan.strZone = "";
            this.dgvThanhToan.TabIndex = 5;
            // 
            // txtMa_Tte
            // 
            this.txtMa_Tte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa_Tte.AutoDropDown = null;
            this.txtMa_Tte.Enabled = false;
            this.txtMa_Tte.InputMask = "VND,USD,EUR";
            this.txtMa_Tte.Location = new System.Drawing.Point(654, 7);
            this.txtMa_Tte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tte.Name = "txtMa_Tte";
            this.txtMa_Tte.Size = new System.Drawing.Size(33, 20);
            this.txtMa_Tte.TabIndex = 2;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = true;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(106, 16);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(78, 20);
            this.dteNgay_Ct.TabIndex = 0;
            // 
            // lblMa_Tte
            // 
            this.lblMa_Tte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMa_Tte.AutoEllipsis = true;
            this.lblMa_Tte.AutoSize = true;
            this.lblMa_Tte.Location = new System.Drawing.Point(606, 10);
            this.lblMa_Tte.Name = "lblMa_Tte";
            this.lblMa_Tte.Size = new System.Drawing.Size(43, 13);
            this.lblMa_Tte.TabIndex = 1;
            this.lblMa_Tte.Tag = "Ma_Tte";
            this.lblMa_Tte.Text = "Mã ttệ";
            this.lblMa_Tte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(24, 19);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(52, 13);
            this.lblNgay_Ct.TabIndex = 0;
            this.lblNgay_Ct.Tag = "Ngay_Ct";
            this.lblNgay_Ct.Text = "Ngày Ct";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTk
            // 
            this.txtTk.bEnabled = true;
            this.txtTk.bReadOnly = false;
            this.txtTk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk.Enabled = false;
            this.txtTk.Location = new System.Drawing.Point(106, 39);
            this.txtTk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk.MaxLength = 20;
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(120, 20);
            this.txtTk.TabIndex = 1;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(231, 64);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(87, 13);
            this.lbtTen_Dt.TabIndex = 20;
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.Location = new System.Drawing.Point(24, 43);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(64, 13);
            this.lblControl1.TabIndex = 2;
            this.lblControl1.Tag = "Tk";
            this.lblControl1.Text = "Tài khoản";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.Location = new System.Drawing.Point(24, 65);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(62, 13);
            this.lblMa_Dt.TabIndex = 5;
            this.lblMa_Dt.Tag = "Ma_Dt";
            this.lblMa_Dt.Text = "Đối tượng";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tk
            // 
            this.lbtTen_Tk.AutoEllipsis = true;
            this.lbtTen_Tk.AutoSize = true;
            this.lbtTen_Tk.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk.Location = new System.Drawing.Point(231, 42);
            this.lbtTen_Tk.Name = "lbtTen_Tk";
            this.lbtTen_Tk.Size = new System.Drawing.Size(86, 13);
            this.lbtTen_Tk.TabIndex = 4;
            this.lbtTen_Tk.Text = "Tên tài khoản";
            this.lbtTen_Tk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.bEnabled = true;
            this.txtMa_Dt.bReadOnly = false;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Enabled = false;
            this.txtMa_Dt.Location = new System.Drawing.Point(106, 61);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 2;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.Blue;
            this.btExit.Location = new System.Drawing.Point(97, 521);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(79, 42);
            this.btExit.TabIndex = 8;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // chk02D
            // 
            this.chk02D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk02D.AutoSize = true;
            this.chk02D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk02D.ForeColor = System.Drawing.Color.Blue;
            this.chk02D.Location = new System.Drawing.Point(482, 46);
            this.chk02D.Name = "chk02D";
            this.chk02D.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk02D.Size = new System.Drawing.Size(205, 17);
            this.chk02D.TabIndex = 24;
            this.chk02D.Text = "Check cho HĐ 2 ngày gần nhất";
            this.chk02D.UseVisualStyleBackColor = true;
            // 
            // chk07D
            // 
            this.chk07D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk07D.AutoSize = true;
            this.chk07D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk07D.ForeColor = System.Drawing.Color.Blue;
            this.chk07D.Location = new System.Drawing.Point(422, 62);
            this.chk07D.Name = "chk07D";
            this.chk07D.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk07D.Size = new System.Drawing.Size(265, 17);
            this.chk07D.TabIndex = 25;
            this.chk07D.Text = "Check cho HĐ 2 ngày gần nhất và 7 ngày";
            this.chk07D.UseVisualStyleBackColor = true;
            // 
            // chk39D
            // 
            this.chk39D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk39D.AutoSize = true;
            this.chk39D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk39D.ForeColor = System.Drawing.Color.Blue;
            this.chk39D.Location = new System.Drawing.Point(352, 79);
            this.chk39D.Name = "chk39D";
            this.chk39D.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk39D.Size = new System.Drawing.Size(335, 17);
            this.chk39D.TabIndex = 25;
            this.chk39D.Text = "Check tuần tự HĐ 2 ngày, 7 ngày và ngày HĐ trễ nhất";
            this.chk39D.UseVisualStyleBackColor = true;
            // 
            // frmHanTt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numTTien_CLTG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numTTien_Tt_Nt);
            this.Controls.Add(this.numTTien_Tt);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btExit);
            this.Name = "frmHanTt";
            this.Text = "frmHanTt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsButton btExit;
		private RosySystem.Control.rsDataGridView dgvThanhToan;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private RosySystem.Control.rsTextBoxNumber numTTien_CLTG;
		private System.Windows.Forms.Label label1;
		private RosySystem.Control.rsButton btSave;
		private System.Windows.Forms.GroupBox groupBox2;
		private RosySystem.Control.rsDataGridView dgvHanTt;
		private RosySystem.Control.rsLabel lblNgay_Ct;
		private RosySystem.Control.rsLabel lblMa_Dt;
		private RosySystem.Control.rsLabel lbtTen_Dt;
		private RosySystem.Control.rsLabel lblControl1;
		private RosySystem.Control.rsLabel lbtTen_Tk;
		private RosySystem.Control.rsLabel lblMa_Tte;
		public RosySystem.Control.rsDateTime dteNgay_Ct;
		public RosySystem.Control.txtTextBox txtMa_Dt;
		public RosySystem.Control.txtTextBox txtTk;
		public RosySystem.Control.rsTextBoxNumber numTy_Gia;
		public RosySystem.Control.rsTextBoxEnum txtMa_Tte;
		private RosySystem.Control.rsButton btRefresh;
		public RosySystem.Control.rsTextBoxNumber numTTien_Tt_Nt;
		public RosySystem.Control.rsTextBoxNumber numTTien_Tt;
		private RosySystem.Control.rsCheckbox chkDu_Cuoi_Only;
		private RosySystem.Control.rsCheckbox chkUpdate_Ngay_Ct;
        private RosySystem.Control.rsCheckbox chk07D;
        private RosySystem.Control.rsCheckbox chk02D;
        private RosySystem.Control.rsCheckbox chk39D;
	}
}