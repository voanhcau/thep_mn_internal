namespace RosyModule.HRM
{
    partial class frmQuerySuatAn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTime_Clock = new System.Windows.Forms.Timer(this.components);
            this.tpNTThuongXuyen = new System.Windows.Forms.TabPage();
            this.dgvNTTX = new RosySystem.Control.rsDataGridView();
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tpNTVangLai = new System.Windows.Forms.TabPage();
            this.dgvNTVL = new RosySystem.Control.rsDataGridView();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.rsGroupBox1 = new RosySystem.Control.rsGroupBox();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btRefresh = new RosySystem.Customize.btEdit();
            this.btExit = new RosySystem.Customize.btEdit();
            this.btDelete = new RosySystem.Customize.btEdit();
            this.btPrint = new RosySystem.Customize.btEdit();
            this.btNew = new RosySystem.Customize.btEdit();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btSuatAn = new RosySystem.Customize.btEdit();
            this.btTinh = new RosySystem.Customize.btEdit();
            this.cboMa_Bp = new RosySystem.Control.rsMultiComboBox();
            this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.tpNTThuongXuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNTTX)).BeginInit();
            this.rsTabControl1.SuspendLayout();
            this.tpNTVangLai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNTVL)).BeginInit();
            this.rsGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTime_Clock
            // 
            this.txtTime_Clock.Enabled = true;
            this.txtTime_Clock.Interval = 1000;
            // 
            // tpNTThuongXuyen
            // 
            this.tpNTThuongXuyen.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpNTThuongXuyen.Controls.Add(this.dgvNTTX);
            this.tpNTThuongXuyen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpNTThuongXuyen.Location = new System.Drawing.Point(4, 22);
            this.tpNTThuongXuyen.Name = "tpNTThuongXuyen";
            this.tpNTThuongXuyen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpNTThuongXuyen.Size = new System.Drawing.Size(711, 260);
            this.tpNTThuongXuyen.TabIndex = 1;
            this.tpNTThuongXuyen.Tag = "";
            this.tpNTThuongXuyen.Text = "Đăng ký suất ăn nhà thầu thường xuyên";
            this.tpNTThuongXuyen.UseVisualStyleBackColor = true;
            // 
            // dgvNTTX
            // 
            this.dgvNTTX.AllowUserToAddRows = false;
            this.dgvNTTX.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvNTTX.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNTTX.BackgroundColor = System.Drawing.Color.White;
            this.dgvNTTX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNTTX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNTTX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNTTX.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNTTX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNTTX.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvNTTX.Location = new System.Drawing.Point(3, 3);
            this.dgvNTTX.MultiSelect = false;
            this.dgvNTTX.Name = "dgvNTTX";
            this.dgvNTTX.ReadOnly = true;
            this.dgvNTTX.Size = new System.Drawing.Size(705, 254);
            this.dgvNTTX.strZone = "";
            this.dgvNTTX.TabIndex = 4;
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tpNTVangLai);
            this.rsTabControl1.Controls.Add(this.tpNTThuongXuyen);
            this.rsTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsTabControl1.Location = new System.Drawing.Point(1, 66);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(719, 286);
            this.rsTabControl1.TabIndex = 3;
            // 
            // tpNTVangLai
            // 
            this.tpNTVangLai.Controls.Add(this.dgvNTVL);
            this.tpNTVangLai.Location = new System.Drawing.Point(4, 22);
            this.tpNTVangLai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpNTVangLai.Name = "tpNTVangLai";
            this.tpNTVangLai.Size = new System.Drawing.Size(711, 260);
            this.tpNTVangLai.TabIndex = 8;
            this.tpNTVangLai.Text = "Thống kê suất ăn nhà thầu vãng lai";
            this.tpNTVangLai.UseVisualStyleBackColor = true;
            // 
            // dgvNTVL
            // 
            this.dgvNTVL.AllowUserToAddRows = false;
            this.dgvNTVL.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvNTVL.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNTVL.BackgroundColor = System.Drawing.Color.White;
            this.dgvNTVL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNTVL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNTVL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNTVL.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNTVL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNTVL.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvNTVL.Location = new System.Drawing.Point(0, 0);
            this.dgvNTVL.MultiSelect = false;
            this.dgvNTVL.Name = "dgvNTVL";
            this.dgvNTVL.ReadOnly = true;
            this.dgvNTVL.Size = new System.Drawing.Size(711, 260);
            this.dgvNTVL.strZone = "";
            this.dgvNTVL.TabIndex = 5;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(15, 19);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(57, 15);
            this.lblNgay_Ct.TabIndex = 52;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Từ ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsGroupBox1
            // 
            this.rsGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsGroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.rsGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.rsGroupBox1.Controls.Add(this.cboMa_Bp);
            this.rsGroupBox1.Controls.Add(this.lbtTen_Bp);
            this.rsGroupBox1.Controls.Add(this.lblTk);
            this.rsGroupBox1.Controls.Add(this.dteNgay_Ct2);
            this.rsGroupBox1.Controls.Add(this.dteNgay_Ct1);
            this.rsGroupBox1.Controls.Add(this.rsLabel1);
            this.rsGroupBox1.Controls.Add(this.btRefresh);
            this.rsGroupBox1.Controls.Add(this.lblNgay_Ct);
            this.rsGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsGroupBox1.Location = new System.Drawing.Point(8, 10);
            this.rsGroupBox1.Name = "rsGroupBox1";
            this.rsGroupBox1.Size = new System.Drawing.Size(712, 50);
            this.rsGroupBox1.TabIndex = 0;
            this.rsGroupBox1.TabStop = false;
            this.rsGroupBox1.Text = "Thông tin chung";
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(250, 17);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(82, 21);
            this.dteNgay_Ct2.TabIndex = 254;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(77, 17);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(82, 21);
            this.dteNgay_Ct1.TabIndex = 254;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(180, 19);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(67, 15);
            this.rsLabel1.TabIndex = 52;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Đến ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(614, 13);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(88, 31);
            this.btRefresh.TabIndex = 253;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "Edit.png";
            this.btExit.Location = new System.Drawing.Point(629, 359);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(88, 40);
            this.btExit.TabIndex = 253;
            this.btExit.Tag = "";
            this.btExit.Text = "Thoát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Edit.png";
            this.btDelete.Location = new System.Drawing.Point(239, 359);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(88, 40);
            this.btDelete.TabIndex = 253;
            this.btDelete.Tag = "";
            this.btDelete.Text = "Xóa";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "Edit.png";
            this.btPrint.Location = new System.Drawing.Point(328, 359);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(98, 40);
            this.btPrint.TabIndex = 253;
            this.btPrint.Tag = "";
            this.btPrint.Text = "In";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "Edit.png";
            this.btNew.Location = new System.Drawing.Point(59, 359);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(88, 40);
            this.btNew.TabIndex = 253;
            this.btNew.Tag = "";
            this.btNew.Text = "Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.ImageKey = "Edit.png";
            this.btEdit.Location = new System.Drawing.Point(149, 359);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(88, 40);
            this.btEdit.TabIndex = 253;
            this.btEdit.Tag = "";
            this.btEdit.Text = "Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btSuatAn
            // 
            this.btSuatAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSuatAn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSuatAn.ImageKey = "Edit.png";
            this.btSuatAn.Location = new System.Drawing.Point(428, 359);
            this.btSuatAn.Name = "btSuatAn";
            this.btSuatAn.Size = new System.Drawing.Size(98, 40);
            this.btSuatAn.TabIndex = 253;
            this.btSuatAn.Tag = "";
            this.btSuatAn.Text = "Nhập số xuất ăn";
            this.btSuatAn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSuatAn.UseVisualStyleBackColor = true;
            // 
            // btTinh
            // 
            this.btTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTinh.ImageKey = "Edit.png";
            this.btTinh.Location = new System.Drawing.Point(529, 359);
            this.btTinh.Name = "btTinh";
            this.btTinh.Size = new System.Drawing.Size(98, 40);
            this.btTinh.TabIndex = 254;
            this.btTinh.Tag = "";
            this.btTinh.Text = "Lượng TP đầu vào";
            this.btTinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btTinh.UseVisualStyleBackColor = true;
            // 
            // cboMa_Bp
            // 
            this.cboMa_Bp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp.Location = new System.Drawing.Point(397, 18);
            this.cboMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp.MaxLength = 20;
            this.cboMa_Bp.Name = "cboMa_Bp";
            this.cboMa_Bp.Size = new System.Drawing.Size(116, 21);
            this.cboMa_Bp.TabIndex = 255;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp.Location = new System.Drawing.Point(518, 23);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp.TabIndex = 256;
            this.lbtTen_Bp.Tag = "";
            this.lbtTen_Bp.Text = "Tên Bộ phận";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTk.Location = new System.Drawing.Point(338, 21);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(54, 13);
            this.lblTk.TabIndex = 257;
            this.lblTk.Tag = "Ma_Bp";
            this.lblTk.Text = "Bộ phận";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmQuerySuatAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 413);
            this.ControlBox = false;
            this.Controls.Add(this.btTinh);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btSuatAn);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.rsGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmQuerySuatAn";
            this.Object_ID = "QUERYSUATAN";
            this.ShowInTaskbar = true;
            this.Text = "frmQuerySuatAn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tpNTThuongXuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNTTX)).EndInit();
            this.rsTabControl1.ResumeLayout(false);
            this.tpNTVangLai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNTVL)).EndInit();
            this.rsGroupBox1.ResumeLayout(false);
            this.rsGroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Timer txtTime_Clock;
        private System.Windows.Forms.TabPage tpNTThuongXuyen;
        private RosySystem.Control.rsDataGridView dgvNTTX;
        private RosySystem.Control.rsTabControl rsTabControl1;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsGroupBox rsGroupBox1;
        private RosySystem.Customize.btEdit btExit;
        private System.Windows.Forms.TabPage tpNTVangLai;
        private RosySystem.Control.rsDataGridView dgvNTVL;
        private RosySystem.Customize.btEdit btDelete;
        private RosySystem.Customize.btEdit btPrint;
        private RosySystem.Customize.btEdit btRefresh;
        private RosySystem.Customize.btEdit btNew;
        private RosySystem.Customize.btEdit btEdit;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Customize.btEdit btSuatAn;
        private RosySystem.Customize.btEdit btTinh;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsMultiComboBox cboMa_Bp;
        private RosySystem.Control.rsLabelName lbtTen_Bp;
        private RosySystem.Control.rsLabel lblTk;
    }
}