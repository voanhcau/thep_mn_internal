namespace RosyModule.Manufactory
{
    partial class frmLenhSanXuat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTime_Clock = new System.Windows.Forms.Timer(this.components);
            this.btNew = new RosySystem.Customize.btEdit();
            this.btDelete = new RosySystem.Customize.btEdit();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.tpLuyen = new System.Windows.Forms.TabPage();
            this.dgvLuyen = new RosySystem.Control.rsDataGridView();
            this.tpCan = new System.Windows.Forms.TabPage();
            this.dgvCan = new RosySystem.Control.rsDataGridView();
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.lblTinh_Trang_Giao_Ca = new RosySystem.Control.rsLabel();
            this.txtLy_Do = new RosySystem.Control.rsTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.numThang = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.numNam = new RosySystem.Control.rsTextBoxNumber();
            this.rsGroupBox4 = new RosySystem.Control.rsGroupBox();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.numLan_Tt = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtDanh_Gia = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.btExit = new RosySystem.Customize.btEdit();
            this.btNew_Thang = new RosySystem.Customize.btEdit();
            this.btNang_Suat = new RosySystem.Customize.btEdit();
            this.btDmTimeChange = new RosySystem.Customize.btEdit();
            this.btDungSX = new RosySystem.Customize.btEdit();
            this.btPrintLSX = new RosySystem.Customize.btEdit();
            this.numTSLLuyen = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.numTSLCan = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.tpLuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuyen)).BeginInit();
            this.tpCan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCan)).BeginInit();
            this.rsTabControl1.SuspendLayout();
            this.rsGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTime_Clock
            // 
            this.txtTime_Clock.Enabled = true;
            this.txtTime_Clock.Interval = 1000;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "Edit.png";
            this.btNew.Location = new System.Drawing.Point(844, 320);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(108, 49);
            this.btNew.TabIndex = 253;
            this.btNew.Tag = "";
            this.btNew.Text = "Thay đổi lịch sản xuất trong tháng";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Edit.png";
            this.btDelete.Location = new System.Drawing.Point(1023, 320);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(69, 49);
            this.btDelete.TabIndex = 253;
            this.btDelete.Tag = "";
            this.btDelete.Text = "Xóa";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.ImageKey = "Edit.png";
            this.btEdit.Location = new System.Drawing.Point(953, 320);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(69, 49);
            this.btEdit.TabIndex = 253;
            this.btEdit.Tag = "";
            this.btEdit.Text = "Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // tpLuyen
            // 
            this.tpLuyen.Controls.Add(this.dgvLuyen);
            this.tpLuyen.Location = new System.Drawing.Point(4, 22);
            this.tpLuyen.Name = "tpLuyen";
            this.tpLuyen.Size = new System.Drawing.Size(1153, 184);
            this.tpLuyen.TabIndex = 2;
            this.tpLuyen.Text = "Sản xuất luyện";
            this.tpLuyen.UseVisualStyleBackColor = true;
            // 
            // dgvLuyen
            // 
            this.dgvLuyen.AllowUserToAddRows = false;
            this.dgvLuyen.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLuyen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvLuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLuyen.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLuyen.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvLuyen.Location = new System.Drawing.Point(0, 0);
            this.dgvLuyen.MultiSelect = false;
            this.dgvLuyen.Name = "dgvLuyen";
            this.dgvLuyen.ReadOnly = true;
            this.dgvLuyen.Size = new System.Drawing.Size(1153, 184);
            this.dgvLuyen.strZone = "";
            this.dgvLuyen.TabIndex = 1;
            // 
            // tpCan
            // 
            this.tpCan.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCan.Controls.Add(this.dgvCan);
            this.tpCan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCan.Location = new System.Drawing.Point(4, 22);
            this.tpCan.Name = "tpCan";
            this.tpCan.Padding = new System.Windows.Forms.Padding(3);
            this.tpCan.Size = new System.Drawing.Size(1153, 184);
            this.tpCan.TabIndex = 1;
            this.tpCan.Tag = "";
            this.tpCan.Text = "Sản xuất cán";
            this.tpCan.UseVisualStyleBackColor = true;
            // 
            // dgvCan
            // 
            this.dgvCan.AllowUserToAddRows = false;
            this.dgvCan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCan.BackgroundColor = System.Drawing.Color.White;
            this.dgvCan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCan.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCan.Location = new System.Drawing.Point(3, 3);
            this.dgvCan.MultiSelect = false;
            this.dgvCan.Name = "dgvCan";
            this.dgvCan.ReadOnly = true;
            this.dgvCan.Size = new System.Drawing.Size(1147, 178);
            this.dgvCan.strZone = "";
            this.dgvCan.TabIndex = 4;
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tpCan);
            this.rsTabControl1.Controls.Add(this.tpLuyen);
            this.rsTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsTabControl1.Location = new System.Drawing.Point(1, 102);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(1161, 210);
            this.rsTabControl1.TabIndex = 3;
            // 
            // lblTinh_Trang_Giao_Ca
            // 
            this.lblTinh_Trang_Giao_Ca.AutoEllipsis = true;
            this.lblTinh_Trang_Giao_Ca.AutoSize = true;
            this.lblTinh_Trang_Giao_Ca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinh_Trang_Giao_Ca.Location = new System.Drawing.Point(11, 45);
            this.lblTinh_Trang_Giao_Ca.Name = "lblTinh_Trang_Giao_Ca";
            this.lblTinh_Trang_Giao_Ca.Size = new System.Drawing.Size(95, 15);
            this.lblTinh_Trang_Giao_Ca.TabIndex = 208;
            this.lblTinh_Trang_Giao_Ca.Tag = "";
            this.lblTinh_Trang_Giao_Ca.Text = "Lý do thay đổi";
            this.lblTinh_Trang_Giao_Ca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLy_Do
            // 
            this.txtLy_Do.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLy_Do.AutoDropDown = null;
            this.txtLy_Do.BackColor = System.Drawing.SystemColors.Window;
            this.txtLy_Do.Location = new System.Drawing.Point(124, 38);
            this.txtLy_Do.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLy_Do.MaxLength = 1000;
            this.txtLy_Do.Multiline = true;
            this.txtLy_Do.Name = "txtLy_Do";
            this.txtLy_Do.ReadOnly = true;
            this.txtLy_Do.Size = new System.Drawing.Size(1033, 26);
            this.txtLy_Do.TabIndex = 4;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel7.Location = new System.Drawing.Point(217, 20);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(43, 13);
            this.rsLabel7.TabIndex = 260;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Tháng";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numThang
            // 
            this.numThang.AutoDropDown = null;
            this.numThang.BackColor = System.Drawing.SystemColors.Window;
            this.numThang.bFormat = true;
            this.numThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numThang.Location = new System.Drawing.Point(266, 14);
            this.numThang.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numThang.Name = "numThang";
            this.numThang.Scale = 0;
            this.numThang.Size = new System.Drawing.Size(55, 21);
            this.numThang.TabIndex = 1;
            this.numThang.Tag = "";
            this.numThang.Text = "0";
            this.numThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThang.Value = 0D;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel6.Location = new System.Drawing.Point(9, 20);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(32, 13);
            this.rsLabel6.TabIndex = 256;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Năm";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNam
            // 
            this.numNam.AutoDropDown = null;
            this.numNam.BackColor = System.Drawing.SystemColors.Window;
            this.numNam.bFormat = true;
            this.numNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNam.Location = new System.Drawing.Point(124, 14);
            this.numNam.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numNam.Name = "numNam";
            this.numNam.Scale = 0;
            this.numNam.Size = new System.Drawing.Size(68, 21);
            this.numNam.TabIndex = 0;
            this.numNam.Tag = "";
            this.numNam.Text = "0";
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam.Value = 0D;
            // 
            // rsGroupBox4
            // 
            this.rsGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsGroupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.rsGroupBox4.BorderColor = System.Drawing.Color.Black;
            this.rsGroupBox4.Controls.Add(this.dteNgay_Ct);
            this.rsGroupBox4.Controls.Add(this.lblNgay_Ct);
            this.rsGroupBox4.Controls.Add(this.numLan_Tt);
            this.rsGroupBox4.Controls.Add(this.rsLabel1);
            this.rsGroupBox4.Controls.Add(this.numNam);
            this.rsGroupBox4.Controls.Add(this.rsLabel6);
            this.rsGroupBox4.Controls.Add(this.numThang);
            this.rsGroupBox4.Controls.Add(this.rsLabel7);
            this.rsGroupBox4.Controls.Add(this.txtDanh_Gia);
            this.rsGroupBox4.Controls.Add(this.rsLabel4);
            this.rsGroupBox4.Controls.Add(this.txtLy_Do);
            this.rsGroupBox4.Controls.Add(this.lblTinh_Trang_Giao_Ca);
            this.rsGroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsGroupBox4.Location = new System.Drawing.Point(1, 2);
            this.rsGroupBox4.Name = "rsGroupBox4";
            this.rsGroupBox4.Size = new System.Drawing.Size(1161, 94);
            this.rsGroupBox4.TabIndex = 0;
            this.rsGroupBox4.TabStop = false;
            this.rsGroupBox4.Text = "Thông tin sản xuất trong tháng";
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(652, 14);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.ReadOnly = true;
            this.dteNgay_Ct.Size = new System.Drawing.Size(82, 21);
            this.dteNgay_Ct.TabIndex = 3;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay_Ct.Location = new System.Drawing.Point(560, 20);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(90, 15);
            this.lblNgay_Ct.TabIndex = 264;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Ngày đổi lịch";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLan_Tt
            // 
            this.numLan_Tt.AutoDropDown = null;
            this.numLan_Tt.BackColor = System.Drawing.SystemColors.Window;
            this.numLan_Tt.bFormat = true;
            this.numLan_Tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLan_Tt.Location = new System.Drawing.Point(465, 14);
            this.numLan_Tt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numLan_Tt.Name = "numLan_Tt";
            this.numLan_Tt.Scale = 0;
            this.numLan_Tt.Size = new System.Drawing.Size(68, 21);
            this.numLan_Tt.TabIndex = 2;
            this.numLan_Tt.Tag = "";
            this.numLan_Tt.Text = "0";
            this.numLan_Tt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLan_Tt.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(350, 20);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(106, 13);
            this.rsLabel1.TabIndex = 262;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Thay đổi lệnh lần";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDanh_Gia
            // 
            this.txtDanh_Gia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDanh_Gia.AutoDropDown = null;
            this.txtDanh_Gia.BackColor = System.Drawing.SystemColors.Window;
            this.txtDanh_Gia.Location = new System.Drawing.Point(124, 66);
            this.txtDanh_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDanh_Gia.MaxLength = 1000;
            this.txtDanh_Gia.Multiline = true;
            this.txtDanh_Gia.Name = "txtDanh_Gia";
            this.txtDanh_Gia.ReadOnly = true;
            this.txtDanh_Gia.Size = new System.Drawing.Size(1033, 23);
            this.txtDanh_Gia.TabIndex = 5;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.Location = new System.Drawing.Point(11, 67);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(95, 15);
            this.rsLabel4.TabIndex = 208;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Đánh giá LSX";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "Edit.png";
            this.btExit.Location = new System.Drawing.Point(1093, 320);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(69, 49);
            this.btExit.TabIndex = 253;
            this.btExit.Tag = "";
            this.btExit.Text = "Thoát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btNew_Thang
            // 
            this.btNew_Thang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew_Thang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew_Thang.ImageKey = "Edit.png";
            this.btNew_Thang.Location = new System.Drawing.Point(725, 320);
            this.btNew_Thang.Name = "btNew_Thang";
            this.btNew_Thang.Size = new System.Drawing.Size(118, 49);
            this.btNew_Thang.TabIndex = 253;
            this.btNew_Thang.Tag = "";
            this.btNew_Thang.Text = "Thêm lệnh cho tháng mới";
            this.btNew_Thang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew_Thang.UseVisualStyleBackColor = true;
            // 
            // btNang_Suat
            // 
            this.btNang_Suat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNang_Suat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNang_Suat.ImageKey = "Edit.png";
            this.btNang_Suat.Location = new System.Drawing.Point(0, 323);
            this.btNang_Suat.Name = "btNang_Suat";
            this.btNang_Suat.Size = new System.Drawing.Size(96, 49);
            this.btNang_Suat.TabIndex = 253;
            this.btNang_Suat.Tag = "";
            this.btNang_Suat.Text = "Danh sách năng suất SX";
            this.btNang_Suat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNang_Suat.UseVisualStyleBackColor = true;
            // 
            // btDmTimeChange
            // 
            this.btDmTimeChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDmTimeChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDmTimeChange.ImageKey = "Edit.png";
            this.btDmTimeChange.Location = new System.Drawing.Point(97, 324);
            this.btDmTimeChange.Name = "btDmTimeChange";
            this.btDmTimeChange.Size = new System.Drawing.Size(96, 49);
            this.btDmTimeChange.TabIndex = 253;
            this.btDmTimeChange.Tag = "";
            this.btDmTimeChange.Text = "Danh sách Time đổi SP";
            this.btDmTimeChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDmTimeChange.UseVisualStyleBackColor = true;
            // 
            // btDungSX
            // 
            this.btDungSX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDungSX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDungSX.ImageKey = "Edit.png";
            this.btDungSX.Location = new System.Drawing.Point(195, 324);
            this.btDungSX.Name = "btDungSX";
            this.btDungSX.Size = new System.Drawing.Size(96, 49);
            this.btDungSX.TabIndex = 253;
            this.btDungSX.Tag = "";
            this.btDungSX.Text = "Lịch dừng SX trong tháng";
            this.btDungSX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDungSX.UseVisualStyleBackColor = true;
            // 
            // btPrintLSX
            // 
            this.btPrintLSX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrintLSX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrintLSX.ImageKey = "Edit.png";
            this.btPrintLSX.Location = new System.Drawing.Point(293, 324);
            this.btPrintLSX.Name = "btPrintLSX";
            this.btPrintLSX.Size = new System.Drawing.Size(97, 49);
            this.btPrintLSX.TabIndex = 253;
            this.btPrintLSX.Tag = "";
            this.btPrintLSX.Text = "In lệnh sản xuất";
            this.btPrintLSX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrintLSX.UseVisualStyleBackColor = true;
            // 
            // numTSLLuyen
            // 
            this.numTSLLuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numTSLLuyen.AutoDropDown = null;
            this.numTSLLuyen.BackColor = System.Drawing.SystemColors.Window;
            this.numTSLLuyen.bFormat = true;
            this.numTSLLuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTSLLuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.numTSLLuyen.Location = new System.Drawing.Point(576, 328);
            this.numTSLLuyen.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numTSLLuyen.Name = "numTSLLuyen";
            this.numTSLLuyen.Scale = 0;
            this.numTSLLuyen.Size = new System.Drawing.Size(68, 20);
            this.numTSLLuyen.TabIndex = 263;
            this.numTSLLuyen.Tag = "";
            this.numTSLLuyen.Text = "0";
            this.numTSLLuyen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTSLLuyen.Value = 0D;
            // 
            // rsLabel2
            // 
            this.rsLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(392, 331);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(179, 13);
            this.rsLabel2.TabIndex = 264;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Tổng sản lượng SX luyện (tấn)";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTSLCan
            // 
            this.numTSLCan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numTSLCan.AutoDropDown = null;
            this.numTSLCan.BackColor = System.Drawing.SystemColors.Window;
            this.numTSLCan.bFormat = true;
            this.numTSLCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTSLCan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.numTSLCan.Location = new System.Drawing.Point(576, 349);
            this.numTSLCan.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numTSLCan.Name = "numTSLCan";
            this.numTSLCan.Scale = 0;
            this.numTSLCan.Size = new System.Drawing.Size(68, 20);
            this.numTSLCan.TabIndex = 265;
            this.numTSLCan.Tag = "";
            this.numTSLCan.Text = "0";
            this.numTSLCan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTSLCan.Value = 0D;
            // 
            // rsLabel3
            // 
            this.rsLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(392, 352);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(170, 13);
            this.rsLabel3.TabIndex = 266;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Tổng sản lượng SX cán (tấn)";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmLenhSanXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 375);
            this.ControlBox = false;
            this.Controls.Add(this.numTSLCan);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.numTSLLuyen);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsGroupBox4);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btPrintLSX);
            this.Controls.Add(this.btDungSX);
            this.Controls.Add(this.btDmTimeChange);
            this.Controls.Add(this.btNang_Suat);
            this.Controls.Add(this.btNew_Thang);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btEdit);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmLenhSanXuat";
            this.Object_ID = "LENHSANXUAT";
            this.ShowInTaskbar = true;
            this.Text = "frmLenhSanXuat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tpLuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuyen)).EndInit();
            this.tpCan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCan)).EndInit();
            this.rsTabControl1.ResumeLayout(false);
            this.rsGroupBox4.ResumeLayout(false);
            this.rsGroupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Timer txtTime_Clock;
        private RosySystem.Customize.btEdit btEdit;
        private RosySystem.Customize.btEdit btNew;
        private RosySystem.Customize.btEdit btDelete;
        private System.Windows.Forms.TabPage tpLuyen;
        private RosySystem.Control.rsDataGridView dgvLuyen;
        private System.Windows.Forms.TabPage tpCan;
        private RosySystem.Control.rsDataGridView dgvCan;
        private RosySystem.Control.rsTabControl rsTabControl1;
        private RosySystem.Control.rsLabel lblTinh_Trang_Giao_Ca;
        private RosySystem.Control.rsTextBox txtLy_Do;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsTextBoxNumber numThang;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBoxNumber numNam;
        private RosySystem.Control.rsGroupBox rsGroupBox4;
        private RosySystem.Customize.btEdit btExit;
        private RosySystem.Control.rsTextBoxNumber numLan_Tt;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Customize.btEdit btNew_Thang;
        private RosySystem.Customize.btEdit btNang_Suat;
        private RosySystem.Customize.btEdit btDmTimeChange;
        private RosySystem.Customize.btEdit btDungSX;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Customize.btEdit btPrintLSX;
        private RosySystem.Control.rsTextBoxNumber numTSLLuyen;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numTSLCan;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtDanh_Gia;
        private RosySystem.Control.rsLabel rsLabel4;


	}
}