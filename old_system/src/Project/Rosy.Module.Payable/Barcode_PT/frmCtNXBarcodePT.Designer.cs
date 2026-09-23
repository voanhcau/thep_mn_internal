namespace RosyModule.Payable
{
    partial class frmCtNXBarcodePT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCtNXBarcodePT));
            this.txtTime_Clock = new System.Windows.Forms.Timer(this.components);
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.rsLabel26 = new RosySystem.Control.rsLabel();
            this.dgvEditCt = new RosySystem.Customize.dgvVoucher();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.btRefresh = new RosySystem.Customize.btPrint();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.lbtRecorde = new RosySystem.Control.rsLabelName();
            this.btLast = new RosySystem.Customize.btPrint();
            this.btNext = new RosySystem.Customize.btPrint();
            this.btPrevious = new RosySystem.Customize.btPrint();
            this.btFirst = new RosySystem.Customize.btPrint();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsGroupBox2 = new RosySystem.Control.rsGroupBox();
            this.txtInfoInherit = new RosySystem.Control.rsTextBox();
            this.cboSo_Ct = new RosySystem.Control.rsComboBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel28 = new RosySystem.Control.rsLabel();
            this.txtDien_Giai = new RosySystem.Control.rsTextBox();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.lblOng_Ba = new RosySystem.Control.rsLabel();
            this.txtOng_Ba = new RosySystem.Control.rsTextBox();
            this.lblMa_Dt = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.txtSo_Ct = new RosySystem.Control.rsTextBox();
            this.lblSo_Ct = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.rsGroupBox1 = new RosySystem.Control.rsGroupBox();
            this.btKiemKe = new RosySystem.Control.rsButton();
            this.btReplace = new RosySystem.Control.rsButton();
            this.btAdd_DNX = new RosySystem.Control.rsButton();
            this.btNhapBarcode = new RosySystem.Control.rsButton();
            this.btInherit = new RosySystem.Control.rsButton();
            this.btNew = new RosySystem.Customize.btEdit();
            this.btDelete = new RosySystem.Customize.btEdit();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btSave_Voucher = new RosySystem.Customize.btFilter();
            this.btPrint = new RosySystem.Customize.btPrint();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt)).BeginInit();
            this.rsPanel1.SuspendLayout();
            this.rsGroupBox2.SuspendLayout();
            this.rsGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTime_Clock
            // 
            this.txtTime_Clock.Enabled = true;
            this.txtTime_Clock.Interval = 1000;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBarcode.Location = new System.Drawing.Point(698, 120);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(327, 60);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel26
            // 
            this.rsLabel26.AutoEllipsis = true;
            this.rsLabel26.AutoSize = true;
            this.rsLabel26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel26.Location = new System.Drawing.Point(607, 139);
            this.rsLabel26.Name = "rsLabel26";
            this.rsLabel26.Size = new System.Drawing.Size(88, 24);
            this.rsLabel26.TabIndex = 246;
            this.rsLabel26.Tag = "";
            this.rsLabel26.Text = "Mã vạch";
            this.rsLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvEditCt
            // 
            this.dgvEditCt.AllowUserToAddRows = false;
            this.dgvEditCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEditCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEditCt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEditCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvEditCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEditCt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEditCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEditCt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEditCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEditCt.Location = new System.Drawing.Point(12, 228);
            this.dgvEditCt.MultiSelect = false;
            this.dgvEditCt.Name = "dgvEditCt";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEditCt.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEditCt.Size = new System.Drawing.Size(1166, 286);
            this.dgvEditCt.strZone = "";
            this.dgvEditCt.TabIndex = 3;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(6, 22);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(53, 13);
            this.rsLabel1.TabIndex = 226;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(72, 18);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(76, 20);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(6, 43);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(61, 13);
            this.rsLabel2.TabIndex = 261;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Đến ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(272, 67);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(109, 26);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "F9 - Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.lbtRecorde);
            this.rsPanel1.Controls.Add(this.btLast);
            this.rsPanel1.Controls.Add(this.btNext);
            this.rsPanel1.Controls.Add(this.btPrevious);
            this.rsPanel1.Controls.Add(this.btFirst);
            this.rsPanel1.Location = new System.Drawing.Point(9, 63);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(260, 29);
            this.rsPanel1.TabIndex = 5;
            // 
            // lbtRecorde
            // 
            this.lbtRecorde.AutoEllipsis = true;
            this.lbtRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtRecorde.ForeColor = System.Drawing.Color.Red;
            this.lbtRecorde.Location = new System.Drawing.Point(99, 4);
            this.lbtRecorde.Name = "lbtRecorde";
            this.lbtRecorde.Size = new System.Drawing.Size(60, 20);
            this.lbtRecorde.TabIndex = 2;
            this.lbtRecorde.Text = "0/0";
            this.lbtRecorde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btLast
            // 
            this.btLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLast.ImageKey = "(none)";
            this.btLast.Location = new System.Drawing.Point(212, 3);
            this.btLast.Name = "btLast";
            this.btLast.Size = new System.Drawing.Size(45, 23);
            this.btLast.TabIndex = 4;
            this.btLast.Tag = "";
            this.btLast.Text = ">>||";
            this.btLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLast.UseVisualStyleBackColor = true;
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNext.ImageKey = "(none)";
            this.btNext.Location = new System.Drawing.Point(161, 3);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(45, 23);
            this.btNext.TabIndex = 3;
            this.btNext.Tag = "";
            this.btNext.Text = ">>";
            this.btNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNext.UseVisualStyleBackColor = true;
            // 
            // btPrevious
            // 
            this.btPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrevious.ImageKey = "(none)";
            this.btPrevious.Location = new System.Drawing.Point(54, 3);
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.Size = new System.Drawing.Size(45, 23);
            this.btPrevious.TabIndex = 1;
            this.btPrevious.Tag = "";
            this.btPrevious.Text = "<<";
            this.btPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrevious.UseVisualStyleBackColor = true;
            // 
            // btFirst
            // 
            this.btFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFirst.ImageKey = "(none)";
            this.btFirst.Location = new System.Drawing.Point(3, 3);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(45, 23);
            this.btFirst.TabIndex = 0;
            this.btFirst.Tag = "";
            this.btFirst.Text = "||<<";
            this.btFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFirst.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(72, 41);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(76, 20);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // rsGroupBox2
            // 
            this.rsGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.rsGroupBox2.Controls.Add(this.txtInfoInherit);
            this.rsGroupBox2.Controls.Add(this.cboSo_Ct);
            this.rsGroupBox2.Controls.Add(this.rsLabel3);
            this.rsGroupBox2.Controls.Add(this.rsLabel28);
            this.rsGroupBox2.Controls.Add(this.dteNgay_Ct2);
            this.rsGroupBox2.Controls.Add(this.rsPanel1);
            this.rsGroupBox2.Controls.Add(this.btRefresh);
            this.rsGroupBox2.Controls.Add(this.rsLabel2);
            this.rsGroupBox2.Controls.Add(this.dteNgay_Ct1);
            this.rsGroupBox2.Controls.Add(this.rsLabel1);
            this.rsGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsGroupBox2.Location = new System.Drawing.Point(12, 122);
            this.rsGroupBox2.Name = "rsGroupBox2";
            this.rsGroupBox2.Size = new System.Drawing.Size(585, 100);
            this.rsGroupBox2.TabIndex = 0;
            this.rsGroupBox2.TabStop = false;
            this.rsGroupBox2.Text = "Điều kiện lọc";
            // 
            // txtInfoInherit
            // 
            this.txtInfoInherit.AutoDropDown = null;
            this.txtInfoInherit.BackColor = System.Drawing.SystemColors.Window;
            this.txtInfoInherit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInfoInherit.Enabled = false;
            this.txtInfoInherit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoInherit.Location = new System.Drawing.Point(370, 43);
            this.txtInfoInherit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtInfoInherit.MaxLength = 200;
            this.txtInfoInherit.Multiline = true;
            this.txtInfoInherit.Name = "txtInfoInherit";
            this.txtInfoInherit.ReadOnly = true;
            this.txtInfoInherit.Size = new System.Drawing.Size(209, 19);
            this.txtInfoInherit.TabIndex = 264;
            // 
            // cboSo_Ct
            // 
            this.cboSo_Ct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSo_Ct.DropDownHeight = 147;
            this.cboSo_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSo_Ct.FormattingEnabled = true;
            this.cboSo_Ct.IntegralHeight = false;
            this.cboSo_Ct.Location = new System.Drawing.Point(370, 12);
            this.cboSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboSo_Ct.Name = "cboSo_Ct";
            this.cboSo_Ct.Size = new System.Drawing.Size(209, 28);
            this.cboSo_Ct.TabIndex = 262;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(301, 43);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(64, 17);
            this.rsLabel3.TabIndex = 263;
            this.rsLabel3.Text = "Kế thừa";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel28
            // 
            this.rsLabel28.AutoEllipsis = true;
            this.rsLabel28.AutoSize = true;
            this.rsLabel28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel28.Location = new System.Drawing.Point(293, 17);
            this.rsLabel28.Name = "rsLabel28";
            this.rsLabel28.Size = new System.Drawing.Size(72, 17);
            this.rsLabel28.TabIndex = 263;
            this.rsLabel28.Text = "Số phiếu";
            this.rsLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDien_Giai
            // 
            this.txtDien_Giai.AutoDropDown = null;
            this.txtDien_Giai.BackColor = System.Drawing.SystemColors.Info;
            this.txtDien_Giai.Location = new System.Drawing.Point(109, 84);
            this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDien_Giai.MaxLength = 200;
            this.txtDien_Giai.Name = "txtDien_Giai";
            this.txtDien_Giai.ReadOnly = true;
            this.txtDien_Giai.Size = new System.Drawing.Size(500, 21);
            this.txtDien_Giai.TabIndex = 9;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(14, 87);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(65, 15);
            this.lblDien_Giai.TabIndex = 208;
            this.lblDien_Giai.Tag = "Dien_Giai";
            this.lblDien_Giai.Text = "Diễn giải";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOng_Ba
            // 
            this.lblOng_Ba.AutoEllipsis = true;
            this.lblOng_Ba.AutoSize = true;
            this.lblOng_Ba.Location = new System.Drawing.Point(14, 64);
            this.lblOng_Ba.Name = "lblOng_Ba";
            this.lblOng_Ba.Size = new System.Drawing.Size(53, 15);
            this.lblOng_Ba.TabIndex = 206;
            this.lblOng_Ba.Tag = "Ong_Ba";
            this.lblOng_Ba.Text = "Ông bà";
            this.lblOng_Ba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOng_Ba
            // 
            this.txtOng_Ba.AutoDropDown = null;
            this.txtOng_Ba.BackColor = System.Drawing.SystemColors.Info;
            this.txtOng_Ba.Location = new System.Drawing.Point(109, 61);
            this.txtOng_Ba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtOng_Ba.MaxLength = 100;
            this.txtOng_Ba.Name = "txtOng_Ba";
            this.txtOng_Ba.ReadOnly = true;
            this.txtOng_Ba.Size = new System.Drawing.Size(229, 21);
            this.txtOng_Ba.TabIndex = 6;
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.Location = new System.Drawing.Point(14, 42);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(69, 15);
            this.lblMa_Dt.TabIndex = 205;
            this.lblMa_Dt.Tag = "Ma_Dt";
            this.lblMa_Dt.Text = "Đối tượng";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.BackColor = System.Drawing.SystemColors.Info;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(109, 39);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.ReadOnly = true;
            this.txtMa_Dt.Size = new System.Drawing.Size(82, 21);
            this.txtMa_Dt.TabIndex = 5;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(198, 42);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(95, 15);
            this.lbtTen_Dt.TabIndex = 204;
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.AutoDropDown = null;
            this.txtSo_Ct.BackColor = System.Drawing.SystemColors.Info;
            this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct.Location = new System.Drawing.Point(283, 16);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct.MaxLength = 20;
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.ReadOnly = true;
            this.txtSo_Ct.Size = new System.Drawing.Size(93, 21);
            this.txtSo_Ct.TabIndex = 2;
            // 
            // lblSo_Ct
            // 
            this.lblSo_Ct.AutoEllipsis = true;
            this.lblSo_Ct.AutoSize = true;
            this.lblSo_Ct.Location = new System.Drawing.Point(218, 19);
            this.lblSo_Ct.Name = "lblSo_Ct";
            this.lblSo_Ct.Size = new System.Drawing.Size(64, 15);
            this.lblSo_Ct.TabIndex = 55;
            this.lblSo_Ct.Tag = "";
            this.lblSo_Ct.Text = "Số phiếu";
            this.lblSo_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(14, 20);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(56, 15);
            this.lblNgay_Ct.TabIndex = 52;
            this.lblNgay_Ct.Tag = "Ngay_Ct";
            this.lblNgay_Ct.Text = "Ngày Ct";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.BackColor = System.Drawing.SystemColors.Info;
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(109, 16);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.ReadOnly = true;
            this.dteNgay_Ct.Size = new System.Drawing.Size(82, 21);
            this.dteNgay_Ct.TabIndex = 1;
            // 
            // rsGroupBox1
            // 
            this.rsGroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.rsGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.rsGroupBox1.Controls.Add(this.btKiemKe);
            this.rsGroupBox1.Controls.Add(this.btReplace);
            this.rsGroupBox1.Controls.Add(this.btAdd_DNX);
            this.rsGroupBox1.Controls.Add(this.btNhapBarcode);
            this.rsGroupBox1.Controls.Add(this.btInherit);
            this.rsGroupBox1.Controls.Add(this.dteNgay_Ct);
            this.rsGroupBox1.Controls.Add(this.lblNgay_Ct);
            this.rsGroupBox1.Controls.Add(this.lblSo_Ct);
            this.rsGroupBox1.Controls.Add(this.txtSo_Ct);
            this.rsGroupBox1.Controls.Add(this.lbtTen_Dt);
            this.rsGroupBox1.Controls.Add(this.txtMa_Dt);
            this.rsGroupBox1.Controls.Add(this.lblMa_Dt);
            this.rsGroupBox1.Controls.Add(this.txtOng_Ba);
            this.rsGroupBox1.Controls.Add(this.lblOng_Ba);
            this.rsGroupBox1.Controls.Add(this.lblDien_Giai);
            this.rsGroupBox1.Controls.Add(this.txtDien_Giai);
            this.rsGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsGroupBox1.Location = new System.Drawing.Point(1, 0);
            this.rsGroupBox1.Name = "rsGroupBox1";
            this.rsGroupBox1.Size = new System.Drawing.Size(1174, 118);
            this.rsGroupBox1.TabIndex = 2;
            this.rsGroupBox1.TabStop = false;
            this.rsGroupBox1.Text = "Thông tin chung";
            // 
            // btKiemKe
            // 
            this.btKiemKe.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btKiemKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btKiemKe.Location = new System.Drawing.Point(388, 39);
            this.btKiemKe.Name = "btKiemKe";
            this.btKiemKe.Size = new System.Drawing.Size(120, 30);
            this.btKiemKe.TabIndex = 252;
            this.btKiemKe.TabStop = false;
            this.btKiemKe.Text = "Kiểm kê";
            this.btKiemKe.UseVisualStyleBackColor = true;
            // 
            // btReplace
            // 
            this.btReplace.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btReplace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btReplace.Location = new System.Drawing.Point(752, 9);
            this.btReplace.Name = "btReplace";
            this.btReplace.Size = new System.Drawing.Size(120, 30);
            this.btReplace.TabIndex = 252;
            this.btReplace.TabStop = false;
            this.btReplace.Text = "Chuyển vị trí";
            this.btReplace.UseVisualStyleBackColor = true;
            this.btReplace.Visible = false;
            // 
            // btAdd_DNX
            // 
            this.btAdd_DNX.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btAdd_DNX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btAdd_DNX.Location = new System.Drawing.Point(630, 9);
            this.btAdd_DNX.Name = "btAdd_DNX";
            this.btAdd_DNX.Size = new System.Drawing.Size(120, 30);
            this.btAdd_DNX.TabIndex = 252;
            this.btAdd_DNX.TabStop = false;
            this.btAdd_DNX.Text = "Bổ sung DNX";
            this.btAdd_DNX.UseVisualStyleBackColor = true;
            // 
            // btNhapBarcode
            // 
            this.btNhapBarcode.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btNhapBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btNhapBarcode.Location = new System.Drawing.Point(509, 9);
            this.btNhapBarcode.Name = "btNhapBarcode";
            this.btNhapBarcode.Size = new System.Drawing.Size(120, 30);
            this.btNhapBarcode.TabIndex = 252;
            this.btNhapBarcode.TabStop = false;
            this.btNhapBarcode.Text = "Nhập barcode";
            this.btNhapBarcode.UseVisualStyleBackColor = true;
            // 
            // btInherit
            // 
            this.btInherit.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btInherit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btInherit.Location = new System.Drawing.Point(388, 9);
            this.btInherit.Name = "btInherit";
            this.btInherit.Size = new System.Drawing.Size(120, 30);
            this.btInherit.TabIndex = 252;
            this.btInherit.TabStop = false;
            this.btInherit.Text = "Kế thừa DNX";
            this.btInherit.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "Edit.png";
            this.btNew.Location = new System.Drawing.Point(723, 519);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(88, 40);
            this.btNew.TabIndex = 253;
            this.btNew.Tag = "";
            this.btNew.Text = "Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Edit.png";
            this.btDelete.Location = new System.Drawing.Point(902, 520);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(88, 40);
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
            this.btEdit.Location = new System.Drawing.Point(813, 519);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(88, 40);
            this.btEdit.TabIndex = 253;
            this.btEdit.Tag = "";
            this.btEdit.Text = "Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btSave_Voucher
            // 
            this.btSave_Voucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave_Voucher.Enabled = false;
            this.btSave_Voucher.Image = ((System.Drawing.Image)(resources.GetObject("btSave_Voucher.Image")));
            this.btSave_Voucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave_Voucher.ImageKey = "Filter.png";
            this.btSave_Voucher.Location = new System.Drawing.Point(996, 520);
            this.btSave_Voucher.Name = "btSave_Voucher";
            this.btSave_Voucher.Size = new System.Drawing.Size(88, 40);
            this.btSave_Voucher.TabIndex = 4;
            this.btSave_Voucher.Tag = "";
            this.btSave_Voucher.Text = "  Lưu";
            this.btSave_Voucher.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "Print.png";
            this.btPrint.Location = new System.Drawing.Point(1090, 520);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(88, 40);
            this.btPrint.TabIndex = 5;
            this.btPrint.Tag = "Print";
            this.btPrint.Text = "&In phiếu";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // frmCtNXBarcodePT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 562);
            this.ControlBox = false;
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btSave_Voucher);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.rsGroupBox1);
            this.Controls.Add(this.rsGroupBox2);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.rsLabel26);
            this.Controls.Add(this.dgvEditCt);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCtNXBarcodePT";
            this.Object_ID = "CTX_BARCODE_PT";
            this.ShowInTaskbar = true;
            this.Text = "frmCTXBarcodePT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            this.rsGroupBox2.ResumeLayout(false);
            this.rsGroupBox2.PerformLayout();
            this.rsGroupBox1.ResumeLayout(false);
            this.rsGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Timer txtTime_Clock;
		private RosySystem.Customize.btFilter btSave_Voucher;
        private System.Windows.Forms.TextBox txtBarcode;
		private RosySystem.Customize.btPrint btPrint;
		private RosySystem.Control.rsLabel rsLabel26;
        private RosySystem.Customize.dgvVoucher dgvEditCt;
        private RosySystem.Customize.btEdit btEdit;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Customize.btPrint btRefresh;
        private RosySystem.Control.rsPanel rsPanel1;
        private RosySystem.Control.rsLabelName lbtRecorde;
        private RosySystem.Customize.btPrint btLast;
        private RosySystem.Customize.btPrint btNext;
        private RosySystem.Customize.btPrint btPrevious;
        private RosySystem.Customize.btPrint btFirst;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsGroupBox rsGroupBox2;
        private RosySystem.Control.rsTextBox txtDien_Giai;
        private RosySystem.Control.rsLabel lblDien_Giai;
        private RosySystem.Control.rsLabel lblOng_Ba;
        private RosySystem.Control.rsTextBox txtOng_Ba;
        private RosySystem.Control.rsLabel lblMa_Dt;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Control.rsLabel lbtTen_Dt;
        private RosySystem.Control.rsTextBox txtSo_Ct;
        private RosySystem.Control.rsLabel lblSo_Ct;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsGroupBox rsGroupBox1;
        private RosySystem.Control.rsButton btInherit;
        private RosySystem.Customize.btEdit btNew;
        private RosySystem.Customize.btEdit btDelete;
        private RosySystem.Control.rsButton btNhapBarcode;
        private RosySystem.Control.rsComboBox cboSo_Ct;
        private RosySystem.Control.rsLabel rsLabel28;
        private RosySystem.Control.rsButton btAdd_DNX;
        private RosySystem.Control.rsTextBox txtInfoInherit;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsButton btReplace;
        private RosySystem.Control.rsButton btKiemKe;


	}
}