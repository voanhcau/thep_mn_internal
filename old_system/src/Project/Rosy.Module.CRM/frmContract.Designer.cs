namespace RosyModule.CRM
{
	partial class frmContract
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.cboKieu_Nhom = new System.Windows.Forms.ComboBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btFilter = new RosySystem.Customize.btFilter();
			this.tabContract = new System.Windows.Forms.TabControl();
			this.pageContract = new System.Windows.Forms.TabPage();
			this.btEdit = new RosySystem.Customize.btEdit();
			this.btNew = new RosySystem.Customize.btNew();
			this.btDelete = new RosySystem.Customize.btDelete();
			this.btTaskDelete = new RosySystem.Customize.btDelete();
			this.txtNote = new System.Windows.Forms.RichTextBox();
			this.btTaskEdit = new RosySystem.Customize.btEdit();
			this.btTaskNew = new RosySystem.Customize.btNew();
			this.dteNgay_Ky = new RosySystem.Control.rsDateTime();
			this.lbNgay_Ky = new RosySystem.Control.rsLabel();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.rsLabel15 = new RosySystem.Control.rsLabel();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.txtTen_Dt = new RosySystem.Control.rsTextBox();
			this.txtMa_Hd = new RosySystem.Control.rsTextBox();
			this.tabDetail = new System.Windows.Forms.TabControl();
			this.pageTask = new System.Windows.Forms.TabPage();
			this.dgvTask = new RosySystem.Control.rsDataGridView();
			this.pagePlan = new System.Windows.Forms.TabPage();
			this.dgvPlan = new RosySystem.Control.rsDataGridView();
			this.pageContact = new System.Windows.Forms.TabPage();
			this.dgvContact = new RosySystem.Control.rsDataGridView();
			this.pagePayment = new System.Windows.Forms.TabPage();
			this.dgvPayment = new RosySystem.Control.rsDataGridView();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabContract.SuspendLayout();
			this.tabDetail.SuspendLayout();
			this.pageTask.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
			this.pagePlan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
			this.pageContact.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
			this.pagePayment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
			this.SuspendLayout();
			// 
			// cboKieu_Nhom
			// 
			this.cboKieu_Nhom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cboKieu_Nhom.FormattingEnabled = true;
			this.cboKieu_Nhom.Items.AddRange(new object[] {
            "1-Theo ngành nghề",
            "2-Phiên bản",
            "3-Tình trạng",
            "4-NV kinh doanh",
            "5-Theo NV triển khai",
            "6-Theo NV cutomize"});
			this.cboKieu_Nhom.Location = new System.Drawing.Point(289, 505);
			this.cboKieu_Nhom.Name = "cboKieu_Nhom";
			this.cboKieu_Nhom.Size = new System.Drawing.Size(126, 21);
			this.cboKieu_Nhom.TabIndex = 10;
			this.cboKieu_Nhom.Text = "3-Tình trạng";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btFilter);
			this.splitContainer1.Panel1.Controls.Add(this.tabContract);
			this.splitContainer1.Panel1.Controls.Add(this.btEdit);
			this.splitContainer1.Panel1.Controls.Add(this.btNew);
			this.splitContainer1.Panel1.Controls.Add(this.cboKieu_Nhom);
			this.splitContainer1.Panel1.Controls.Add(this.btDelete);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btTaskDelete);
			this.splitContainer1.Panel2.Controls.Add(this.txtNote);
			this.splitContainer1.Panel2.Controls.Add(this.btTaskEdit);
			this.splitContainer1.Panel2.Controls.Add(this.btTaskNew);
			this.splitContainer1.Panel2.Controls.Add(this.dteNgay_Ky);
			this.splitContainer1.Panel2.Controls.Add(this.lbNgay_Ky);
			this.splitContainer1.Panel2.Controls.Add(this.rsLabel6);
			this.splitContainer1.Panel2.Controls.Add(this.rsLabel15);
			this.splitContainer1.Panel2.Controls.Add(this.rsLabel5);
			this.splitContainer1.Panel2.Controls.Add(this.txtTen_Dt);
			this.splitContainer1.Panel2.Controls.Add(this.txtMa_Hd);
			this.splitContainer1.Panel2.Controls.Add(this.tabDetail);
			this.splitContainer1.Size = new System.Drawing.Size(893, 544);
			this.splitContainer1.SplitterDistance = 417;
			this.splitContainer1.TabIndex = 60;
			// 
			// btFilter
			// 
			this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btFilter.ImageKey = "Filter.png";
			this.btFilter.Location = new System.Drawing.Point(234, 492);
			this.btFilter.Name = "btFilter";
			this.btFilter.Size = new System.Drawing.Size(66, 46);
			this.btFilter.TabIndex = 75;
			this.btFilter.Tag = "Filter";
			this.btFilter.Text = "&Lọc";
			this.btFilter.UseVisualStyleBackColor = true;
			// 
			// tabContract
			// 
			this.tabContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabContract.Controls.Add(this.pageContract);
			this.tabContract.Location = new System.Drawing.Point(0, 0);
			this.tabContract.Name = "tabContract";
			this.tabContract.SelectedIndex = 0;
			this.tabContract.Size = new System.Drawing.Size(414, 487);
			this.tabContract.TabIndex = 3;
			// 
			// pageContract
			// 
			this.pageContract.Location = new System.Drawing.Point(4, 22);
			this.pageContract.Name = "pageContract";
			this.pageContract.Padding = new System.Windows.Forms.Padding(3);
			this.pageContract.Size = new System.Drawing.Size(406, 461);
			this.pageContract.TabIndex = 0;
			this.pageContract.Text = "Hợp đồng";
			this.pageContract.UseVisualStyleBackColor = true;
			// 
			// btEdit
			// 
			this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit.ImageKey = "Edit.png";
			this.btEdit.Location = new System.Drawing.Point(82, 492);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(66, 46);
			this.btEdit.TabIndex = 73;
			this.btEdit.Tag = "Edit";
			this.btEdit.Text = "&Sửa";
			this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btEdit.UseVisualStyleBackColor = true;
			// 
			// btNew
			// 
			this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew.ImageKey = "New.png";
			this.btNew.Location = new System.Drawing.Point(6, 492);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(66, 46);
			this.btNew.TabIndex = 72;
			this.btNew.Tag = "New";
			this.btNew.Text = "&Thêm";
			this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// btDelete
			// 
			this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDelete.ImageKey = "Delete.png";
			this.btDelete.Location = new System.Drawing.Point(158, 492);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(66, 46);
			this.btDelete.TabIndex = 74;
			this.btDelete.Tag = "Delete";
			this.btDelete.Text = "&Xóa";
			this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btDelete.UseVisualStyleBackColor = true;
			// 
			// btTaskDelete
			// 
			this.btTaskDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btTaskDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btTaskDelete.ImageKey = "Delete.png";
			this.btTaskDelete.Location = new System.Drawing.Point(160, 491);
			this.btTaskDelete.Name = "btTaskDelete";
			this.btTaskDelete.Size = new System.Drawing.Size(66, 47);
			this.btTaskDelete.TabIndex = 67;
			this.btTaskDelete.Tag = "Delete";
			this.btTaskDelete.Text = "&Xóa";
			this.btTaskDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btTaskDelete.UseVisualStyleBackColor = true;
			// 
			// txtNote
			// 
			this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNote.Location = new System.Drawing.Point(104, 82);
			this.txtNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNote.Name = "txtNote";
			this.txtNote.ReadOnly = true;
			this.txtNote.Size = new System.Drawing.Size(364, 125);
			this.txtNote.TabIndex = 77;
			this.txtNote.Text = "";
			// 
			// btTaskEdit
			// 
			this.btTaskEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btTaskEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btTaskEdit.ImageKey = "Edit.png";
			this.btTaskEdit.Location = new System.Drawing.Point(84, 491);
			this.btTaskEdit.Name = "btTaskEdit";
			this.btTaskEdit.Size = new System.Drawing.Size(66, 47);
			this.btTaskEdit.TabIndex = 66;
			this.btTaskEdit.Tag = "Edit";
			this.btTaskEdit.Text = "&Sửa";
			this.btTaskEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btTaskEdit.UseVisualStyleBackColor = true;
			// 
			// btTaskNew
			// 
			this.btTaskNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btTaskNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btTaskNew.ImageKey = "New.png";
			this.btTaskNew.Location = new System.Drawing.Point(8, 491);
			this.btTaskNew.Name = "btTaskNew";
			this.btTaskNew.Size = new System.Drawing.Size(66, 47);
			this.btTaskNew.TabIndex = 65;
			this.btTaskNew.Tag = "New";
			this.btTaskNew.Text = "&Thêm";
			this.btTaskNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btTaskNew.UseVisualStyleBackColor = true;
			// 
			// dteNgay_Ky
			// 
			this.dteNgay_Ky.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dteNgay_Ky.bAllowEmpty = true;
			this.dteNgay_Ky.bSelectOnFocus = false;
			this.dteNgay_Ky.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ky.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ky.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ky.Location = new System.Drawing.Point(400, 60);
			this.dteNgay_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ky.Mask = "00/00/0000";
			this.dteNgay_Ky.Name = "dteNgay_Ky";
			this.dteNgay_Ky.ReadOnly = true;
			this.dteNgay_Ky.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ky.TabIndex = 72;
			// 
			// lbNgay_Ky
			// 
			this.lbNgay_Ky.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbNgay_Ky.AutoEllipsis = true;
			this.lbNgay_Ky.AutoSize = true;
			this.lbNgay_Ky.Location = new System.Drawing.Point(320, 63);
			this.lbNgay_Ky.Name = "lbNgay_Ky";
			this.lbNgay_Ky.Size = new System.Drawing.Size(46, 13);
			this.lbNgay_Ky.TabIndex = 76;
			this.lbNgay_Ky.Tag = "Ngay_Ky";
			this.lbNgay_Ky.Text = "Ngày ký";
			this.lbNgay_Ky.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(15, 22);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(65, 13);
			this.rsLabel6.TabIndex = 74;
			this.rsLabel6.Text = "Khách hàng";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel15
			// 
			this.rsLabel15.AutoEllipsis = true;
			this.rsLabel15.AutoSize = true;
			this.rsLabel15.Location = new System.Drawing.Point(15, 98);
			this.rsLabel15.Name = "rsLabel15";
			this.rsLabel15.Size = new System.Drawing.Size(44, 13);
			this.rsLabel15.TabIndex = 73;
			this.rsLabel15.Text = "Ghi chú";
			this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(15, 63);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(71, 13);
			this.rsLabel5.TabIndex = 75;
			this.rsLabel5.Tag = "Ma_Hd";
			this.rsLabel5.Text = "Mã hợp đồng";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTen_Dt
			// 
			this.txtTen_Dt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTen_Dt.Location = new System.Drawing.Point(104, 9);
			this.txtTen_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Dt.Multiline = true;
			this.txtTen_Dt.Name = "txtTen_Dt";
			this.txtTen_Dt.ReadOnly = true;
			this.txtTen_Dt.Size = new System.Drawing.Size(363, 49);
			this.txtTen_Dt.TabIndex = 70;
			// 
			// txtMa_Hd
			// 
			this.txtMa_Hd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMa_Hd.Location = new System.Drawing.Point(104, 60);
			this.txtMa_Hd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Hd.Name = "txtMa_Hd";
			this.txtMa_Hd.ReadOnly = true;
			this.txtMa_Hd.Size = new System.Drawing.Size(122, 20);
			this.txtMa_Hd.TabIndex = 71;
			// 
			// tabDetail
			// 
			this.tabDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabDetail.Controls.Add(this.pageTask);
			this.tabDetail.Controls.Add(this.pagePlan);
			this.tabDetail.Controls.Add(this.pageContact);
			this.tabDetail.Controls.Add(this.pagePayment);
			this.tabDetail.Location = new System.Drawing.Point(0, 216);
			this.tabDetail.Name = "tabDetail";
			this.tabDetail.SelectedIndex = 0;
			this.tabDetail.Size = new System.Drawing.Size(472, 271);
			this.tabDetail.TabIndex = 5;
			// 
			// pageTask
			// 
			this.pageTask.Controls.Add(this.dgvTask);
			this.pageTask.Location = new System.Drawing.Point(4, 22);
			this.pageTask.Name = "pageTask";
			this.pageTask.Padding = new System.Windows.Forms.Padding(3);
			this.pageTask.Size = new System.Drawing.Size(464, 245);
			this.pageTask.TabIndex = 0;
			this.pageTask.Text = "Giao dịch";
			this.pageTask.UseVisualStyleBackColor = true;
			// 
			// dgvTask
			// 
			this.dgvTask.AllowUserToAddRows = false;
			this.dgvTask.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvTask.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvTask.BackgroundColor = System.Drawing.Color.White;
			this.dgvTask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTask.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTask.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvTask.Location = new System.Drawing.Point(3, 3);
			this.dgvTask.Margin = new System.Windows.Forms.Padding(1);
			this.dgvTask.MultiSelect = false;
			this.dgvTask.Name = "dgvTask";
			this.dgvTask.ReadOnly = true;
			this.dgvTask.Size = new System.Drawing.Size(458, 239);
			this.dgvTask.strZone = "";
			this.dgvTask.TabIndex = 1;
			// 
			// pagePlan
			// 
			this.pagePlan.Controls.Add(this.dgvPlan);
			this.pagePlan.Location = new System.Drawing.Point(4, 22);
			this.pagePlan.Name = "pagePlan";
			this.pagePlan.Padding = new System.Windows.Forms.Padding(3);
			this.pagePlan.Size = new System.Drawing.Size(464, 245);
			this.pagePlan.TabIndex = 3;
			this.pagePlan.Text = "Kế hoạch";
			this.pagePlan.UseVisualStyleBackColor = true;
			// 
			// dgvPlan
			// 
			this.dgvPlan.AllowUserToAddRows = false;
			this.dgvPlan.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvPlan.BackgroundColor = System.Drawing.Color.White;
			this.dgvPlan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPlan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPlan.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvPlan.Location = new System.Drawing.Point(3, 3);
			this.dgvPlan.Margin = new System.Windows.Forms.Padding(1);
			this.dgvPlan.MultiSelect = false;
			this.dgvPlan.Name = "dgvPlan";
			this.dgvPlan.ReadOnly = true;
			this.dgvPlan.Size = new System.Drawing.Size(447, 245);
			this.dgvPlan.strZone = "";
			this.dgvPlan.TabIndex = 4;
			// 
			// pageContact
			// 
			this.pageContact.Controls.Add(this.dgvContact);
			this.pageContact.Location = new System.Drawing.Point(4, 22);
			this.pageContact.Name = "pageContact";
			this.pageContact.Padding = new System.Windows.Forms.Padding(3);
			this.pageContact.Size = new System.Drawing.Size(464, 245);
			this.pageContact.TabIndex = 1;
			this.pageContact.Text = "Liên hệ";
			this.pageContact.UseVisualStyleBackColor = true;
			// 
			// dgvContact
			// 
			this.dgvContact.AllowUserToAddRows = false;
			this.dgvContact.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvContact.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvContact.BackgroundColor = System.Drawing.Color.White;
			this.dgvContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvContact.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvContact.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvContact.Location = new System.Drawing.Point(3, 3);
			this.dgvContact.Margin = new System.Windows.Forms.Padding(1);
			this.dgvContact.MultiSelect = false;
			this.dgvContact.Name = "dgvContact";
			this.dgvContact.ReadOnly = true;
			this.dgvContact.Size = new System.Drawing.Size(458, 239);
			this.dgvContact.strZone = "";
			this.dgvContact.TabIndex = 2;
			// 
			// pagePayment
			// 
			this.pagePayment.Controls.Add(this.dgvPayment);
			this.pagePayment.Location = new System.Drawing.Point(4, 22);
			this.pagePayment.Name = "pagePayment";
			this.pagePayment.Size = new System.Drawing.Size(464, 245);
			this.pagePayment.TabIndex = 4;
			this.pagePayment.Text = "Thanh toán";
			this.pagePayment.UseVisualStyleBackColor = true;
			// 
			// dgvPayment
			// 
			this.dgvPayment.AllowUserToAddRows = false;
			this.dgvPayment.AllowUserToDeleteRows = false;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvPayment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvPayment.BackgroundColor = System.Drawing.Color.White;
			this.dgvPayment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPayment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPayment.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvPayment.Location = new System.Drawing.Point(0, 0);
			this.dgvPayment.Margin = new System.Windows.Forms.Padding(1);
			this.dgvPayment.MultiSelect = false;
			this.dgvPayment.Name = "dgvPayment";
			this.dgvPayment.ReadOnly = true;
			this.dgvPayment.Size = new System.Drawing.Size(464, 245);
			this.dgvPayment.strZone = "";
			this.dgvPayment.TabIndex = 5;
			// 
			// frmContract
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(893, 544);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmContract";
			this.Text = "frmContract";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.tabContract.ResumeLayout(false);
			this.tabDetail.ResumeLayout(false);
			this.pageTask.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
			this.pagePlan.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
			this.pageContact.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
			this.pagePayment.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboKieu_Nhom;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl tabContract;
		private System.Windows.Forms.TabPage pageContract;
		private System.Windows.Forms.TabControl tabDetail;
		private System.Windows.Forms.TabPage pageTask;
		private RosySystem.Control.rsDataGridView dgvTask;
		private System.Windows.Forms.TabPage pageContact;
		private RosySystem.Control.rsDataGridView dgvContact;
		private System.Windows.Forms.TabPage pagePlan;
		private RosySystem.Control.rsDataGridView dgvPlan;
		private System.Windows.Forms.TabPage pagePayment;
		private RosySystem.Control.rsDataGridView dgvPayment;
		private RosySystem.Customize.btDelete btTaskDelete;
		private RosySystem.Customize.btEdit btTaskEdit;
		private RosySystem.Customize.btNew btTaskNew;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Customize.btDelete btDelete;
		private System.Windows.Forms.RichTextBox txtNote;
		private RosySystem.Control.rsDateTime dteNgay_Ky;
		private RosySystem.Control.rsLabel lbNgay_Ky;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel rsLabel15;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsTextBox txtTen_Dt;
		private RosySystem.Control.rsTextBox txtMa_Hd;
	}
}