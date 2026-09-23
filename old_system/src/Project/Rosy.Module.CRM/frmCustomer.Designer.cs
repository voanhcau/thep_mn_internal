namespace RosyModule.CRM
{
	partial class frmCustomer
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
			this.btNew = new RosySystem.Customize.btNew();
			this.btEdit = new RosySystem.Customize.btEdit();
			this.btDelete = new RosySystem.Customize.btDelete();
			this.btFilter = new RosySystem.Customize.btFilter();
			this.btTaskNew = new RosySystem.Customize.btNew();
			this.btTaskEdit = new RosySystem.Customize.btEdit();
			this.btTaskDelete = new RosySystem.Customize.btDelete();
			this.cboMa_Dt_CbNv = new System.Windows.Forms.ComboBox();
			this.cboKieu_Nhom = new System.Windows.Forms.ComboBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabCustomer = new System.Windows.Forms.TabControl();
			this.pageCustomer = new System.Windows.Forms.TabPage();
			this.txtTen_Dt_Info = new RosySystem.Control.rsTextBox();
			this.txtNote = new System.Windows.Forms.RichTextBox();
			this.rsLabel15 = new RosySystem.Control.rsLabel();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.label1 = new RosySystem.Control.rsLabel();
			this.txtMa_Dt = new RosySystem.Control.rsTextBox();
			this.tabDetail = new System.Windows.Forms.TabControl();
			this.pageTask = new System.Windows.Forms.TabPage();
			this.dgvTask = new RosySystem.Control.rsDataGridView();
			this.pagePlan = new System.Windows.Forms.TabPage();
			this.dgvPlan = new RosySystem.Control.rsDataGridView();
			this.pageContact = new System.Windows.Forms.TabPage();
			this.dgvContact = new RosySystem.Control.rsDataGridView();
			this.pageContract = new System.Windows.Forms.TabPage();
			this.dgvContract = new RosySystem.Control.rsDataGridView();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabCustomer.SuspendLayout();
			this.tabDetail.SuspendLayout();
			this.pageTask.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
			this.pagePlan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
			this.pageContact.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
			this.pageContract.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvContract)).BeginInit();
			this.SuspendLayout();
			// 
			// btNew
			// 
			this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew.ImageKey = "New.png";
			this.btNew.Location = new System.Drawing.Point(6, 517);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(67, 42);
			this.btNew.TabIndex = 0;
			this.btNew.Tag = "New";
			this.btNew.Text = "Thêm";
			this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// btEdit
			// 
			this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit.ImageKey = "Edit.png";
			this.btEdit.Location = new System.Drawing.Point(76, 517);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(66, 42);
			this.btEdit.TabIndex = 1;
			this.btEdit.Tag = "Edit";
			this.btEdit.Text = "Sửa";
			this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btEdit.UseVisualStyleBackColor = true;
			// 
			// btDelete
			// 
			this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDelete.ImageKey = "Delete.png";
			this.btDelete.Location = new System.Drawing.Point(146, 517);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(67, 42);
			this.btDelete.TabIndex = 2;
			this.btDelete.Tag = "Delete";
			this.btDelete.Text = "Xóa";
			this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btDelete.UseVisualStyleBackColor = true;
			// 
			// btFilter
			// 
			this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btFilter.ImageKey = "Filter.png";
			this.btFilter.Location = new System.Drawing.Point(216, 517);
			this.btFilter.Name = "btFilter";
			this.btFilter.Size = new System.Drawing.Size(64, 42);
			this.btFilter.TabIndex = 3;
			this.btFilter.Tag = "Filter";
			this.btFilter.Text = "Lọc";
			this.btFilter.UseVisualStyleBackColor = true;
			// 
			// btTaskNew
			// 
			this.btTaskNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btTaskNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btTaskNew.ImageKey = "New.png";
			this.btTaskNew.Location = new System.Drawing.Point(7, 517);
			this.btTaskNew.Name = "btTaskNew";
			this.btTaskNew.Size = new System.Drawing.Size(67, 42);
			this.btTaskNew.TabIndex = 4;
			this.btTaskNew.Tag = "New";
			this.btTaskNew.Text = "Thêm";
			this.btTaskNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btTaskNew.UseVisualStyleBackColor = true;
			// 
			// btTaskEdit
			// 
			this.btTaskEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btTaskEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btTaskEdit.ImageKey = "Edit.png";
			this.btTaskEdit.Location = new System.Drawing.Point(77, 517);
			this.btTaskEdit.Name = "btTaskEdit";
			this.btTaskEdit.Size = new System.Drawing.Size(67, 42);
			this.btTaskEdit.TabIndex = 5;
			this.btTaskEdit.Tag = "Edit";
			this.btTaskEdit.Text = "Sửa";
			this.btTaskEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btTaskEdit.UseVisualStyleBackColor = true;
			// 
			// btTaskDelete
			// 
			this.btTaskDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btTaskDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btTaskDelete.ImageKey = "Delete.png";
			this.btTaskDelete.Location = new System.Drawing.Point(147, 517);
			this.btTaskDelete.Name = "btTaskDelete";
			this.btTaskDelete.Size = new System.Drawing.Size(67, 42);
			this.btTaskDelete.TabIndex = 6;
			this.btTaskDelete.Tag = "Delete";
			this.btTaskDelete.Text = "Xóa";
			this.btTaskDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btTaskDelete.UseVisualStyleBackColor = true;
			// 
			// cboMa_Dt_CbNv
			// 
			this.cboMa_Dt_CbNv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cboMa_Dt_CbNv.FormattingEnabled = true;
			this.cboMa_Dt_CbNv.Location = new System.Drawing.Point(242, 533);
			this.cboMa_Dt_CbNv.Name = "cboMa_Dt_CbNv";
			this.cboMa_Dt_CbNv.Size = new System.Drawing.Size(78, 21);
			this.cboMa_Dt_CbNv.TabIndex = 4;
			// 
			// cboKieu_Nhom
			// 
			this.cboKieu_Nhom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cboKieu_Nhom.FormattingEnabled = true;
			this.cboKieu_Nhom.Items.AddRange(new object[] {
            "0-Không nhóm",
            "1-Theo ngành nghề",
            "2-Theo quy mô",
            "3-Theo tình trạng",
            "4-Theo khu vực",
            "5-Theo vốn CSH",
            "6-Theo sản phẩm"});
			this.cboKieu_Nhom.Location = new System.Drawing.Point(326, 533);
			this.cboKieu_Nhom.Name = "cboKieu_Nhom";
			this.cboKieu_Nhom.Size = new System.Drawing.Size(117, 21);
			this.cboKieu_Nhom.TabIndex = 5;
			this.cboKieu_Nhom.Text = "0-Không nhóm";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.cboMa_Dt_CbNv);
			this.splitContainer1.Panel1.Controls.Add(this.tabCustomer);
			this.splitContainer1.Panel1.Controls.Add(this.cboKieu_Nhom);
			this.splitContainer1.Panel1.Controls.Add(this.btDelete);
			this.splitContainer1.Panel1.Controls.Add(this.btNew);
			this.splitContainer1.Panel1.Controls.Add(this.btFilter);
			this.splitContainer1.Panel1.Controls.Add(this.btEdit);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtTen_Dt_Info);
			this.splitContainer1.Panel2.Controls.Add(this.btTaskDelete);
			this.splitContainer1.Panel2.Controls.Add(this.txtNote);
			this.splitContainer1.Panel2.Controls.Add(this.btTaskEdit);
			this.splitContainer1.Panel2.Controls.Add(this.btTaskNew);
			this.splitContainer1.Panel2.Controls.Add(this.rsLabel15);
			this.splitContainer1.Panel2.Controls.Add(this.rsLabel5);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.txtMa_Dt);
			this.splitContainer1.Panel2.Controls.Add(this.tabDetail);
			this.splitContainer1.Size = new System.Drawing.Size(927, 566);
			this.splitContainer1.SplitterDistance = 447;
			this.splitContainer1.TabIndex = 0;
			// 
			// tabCustomer
			// 
			this.tabCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabCustomer.Controls.Add(this.pageCustomer);
			this.tabCustomer.Location = new System.Drawing.Point(5, 3);
			this.tabCustomer.Name = "tabCustomer";
			this.tabCustomer.SelectedIndex = 0;
			this.tabCustomer.Size = new System.Drawing.Size(438, 512);
			this.tabCustomer.TabIndex = 1;
			// 
			// pageCustomer
			// 
			this.pageCustomer.Location = new System.Drawing.Point(4, 22);
			this.pageCustomer.Name = "pageCustomer";
			this.pageCustomer.Padding = new System.Windows.Forms.Padding(3);
			this.pageCustomer.Size = new System.Drawing.Size(430, 486);
			this.pageCustomer.TabIndex = 0;
			this.pageCustomer.Text = "Khách hàng";
			this.pageCustomer.UseVisualStyleBackColor = true;
			// 
			// txtTen_Dt_Info
			// 
			this.txtTen_Dt_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTen_Dt_Info.Location = new System.Drawing.Point(92, 35);
			this.txtTen_Dt_Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Dt_Info.Multiline = true;
			this.txtTen_Dt_Info.Name = "txtTen_Dt_Info";
			this.txtTen_Dt_Info.ReadOnly = true;
			this.txtTen_Dt_Info.Size = new System.Drawing.Size(373, 46);
			this.txtTen_Dt_Info.TabIndex = 1;
			// 
			// txtNote
			// 
			this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNote.Location = new System.Drawing.Point(92, 83);
			this.txtNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNote.Name = "txtNote";
			this.txtNote.ReadOnly = true;
			this.txtNote.Size = new System.Drawing.Size(373, 72);
			this.txtNote.TabIndex = 2;
			this.txtNote.Text = "";
			// 
			// rsLabel15
			// 
			this.rsLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel15.AutoEllipsis = true;
			this.rsLabel15.AutoSize = true;
			this.rsLabel15.Location = new System.Drawing.Point(16, 94);
			this.rsLabel15.Name = "rsLabel15";
			this.rsLabel15.Size = new System.Drawing.Size(44, 13);
			this.rsLabel15.TabIndex = 73;
			this.rsLabel15.Text = "Ghi chú";
			this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel5
			// 
			this.rsLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(16, 16);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(70, 13);
			this.rsLabel5.TabIndex = 74;
			this.rsLabel5.Text = "Mã đối tượng";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoEllipsis = true;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 75;
			this.label1.Text = "Tên đối tượng";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Dt
			// 
			this.txtMa_Dt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMa_Dt.Location = new System.Drawing.Point(92, 13);
			this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Dt.Name = "txtMa_Dt";
			this.txtMa_Dt.ReadOnly = true;
			this.txtMa_Dt.Size = new System.Drawing.Size(147, 20);
			this.txtMa_Dt.TabIndex = 0;
			// 
			// tabDetail
			// 
			this.tabDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabDetail.Controls.Add(this.pageTask);
			this.tabDetail.Controls.Add(this.pagePlan);
			this.tabDetail.Controls.Add(this.pageContact);
			this.tabDetail.Controls.Add(this.pageContract);
			this.tabDetail.Location = new System.Drawing.Point(3, 160);
			this.tabDetail.Name = "tabDetail";
			this.tabDetail.SelectedIndex = 0;
			this.tabDetail.Size = new System.Drawing.Size(470, 355);
			this.tabDetail.TabIndex = 3;
			// 
			// pageTask
			// 
			this.pageTask.Controls.Add(this.dgvTask);
			this.pageTask.Location = new System.Drawing.Point(4, 22);
			this.pageTask.Name = "pageTask";
			this.pageTask.Padding = new System.Windows.Forms.Padding(3);
			this.pageTask.Size = new System.Drawing.Size(462, 329);
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
			this.dgvTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvTask.BackgroundColor = System.Drawing.Color.White;
			this.dgvTask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTask.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvTask.Location = new System.Drawing.Point(4, 4);
			this.dgvTask.Margin = new System.Windows.Forms.Padding(1);
			this.dgvTask.MultiSelect = false;
			this.dgvTask.Name = "dgvTask";
			this.dgvTask.ReadOnly = true;
			this.dgvTask.Size = new System.Drawing.Size(454, 321);
			this.dgvTask.strZone = "";
			this.dgvTask.TabIndex = 1;
			// 
			// pagePlan
			// 
			this.pagePlan.Controls.Add(this.dgvPlan);
			this.pagePlan.Location = new System.Drawing.Point(4, 22);
			this.pagePlan.Name = "pagePlan";
			this.pagePlan.Padding = new System.Windows.Forms.Padding(3);
			this.pagePlan.Size = new System.Drawing.Size(462, 329);
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
			this.dgvPlan.Size = new System.Drawing.Size(590, 265);
			this.dgvPlan.strZone = "";
			this.dgvPlan.TabIndex = 4;
			// 
			// pageContact
			// 
			this.pageContact.Controls.Add(this.dgvContact);
			this.pageContact.Location = new System.Drawing.Point(4, 22);
			this.pageContact.Name = "pageContact";
			this.pageContact.Padding = new System.Windows.Forms.Padding(3);
			this.pageContact.Size = new System.Drawing.Size(462, 329);
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
			this.dgvContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvContact.BackgroundColor = System.Drawing.Color.White;
			this.dgvContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvContact.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvContact.Location = new System.Drawing.Point(4, 4);
			this.dgvContact.Margin = new System.Windows.Forms.Padding(1);
			this.dgvContact.MultiSelect = false;
			this.dgvContact.Name = "dgvContact";
			this.dgvContact.ReadOnly = true;
			this.dgvContact.Size = new System.Drawing.Size(586, 294);
			this.dgvContact.strZone = "";
			this.dgvContact.TabIndex = 2;
			// 
			// pageContract
			// 
			this.pageContract.Controls.Add(this.dgvContract);
			this.pageContract.Location = new System.Drawing.Point(4, 22);
			this.pageContract.Name = "pageContract";
			this.pageContract.Size = new System.Drawing.Size(462, 329);
			this.pageContract.TabIndex = 2;
			this.pageContract.Text = "Hợp đồng";
			this.pageContract.UseVisualStyleBackColor = true;
			// 
			// dgvContract
			// 
			this.dgvContract.AllowUserToAddRows = false;
			this.dgvContract.AllowUserToDeleteRows = false;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvContract.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvContract.BackgroundColor = System.Drawing.Color.White;
			this.dgvContract.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvContract.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvContract.Location = new System.Drawing.Point(5, 4);
			this.dgvContract.Margin = new System.Windows.Forms.Padding(1);
			this.dgvContract.MultiSelect = false;
			this.dgvContract.Name = "dgvContract";
			this.dgvContract.ReadOnly = true;
			this.dgvContract.Size = new System.Drawing.Size(586, 294);
			this.dgvContract.strZone = "";
			this.dgvContract.TabIndex = 3;
			// 
			// frmCustomer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(927, 566);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmCustomer";
			this.Tag = "frmCustomer";
			this.Text = "frmCustomer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.tabCustomer.ResumeLayout(false);
			this.tabDetail.ResumeLayout(false);
			this.pageTask.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
			this.pagePlan.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
			this.pageContact.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
			this.pageContract.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvContract)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Customize.btNew btNew;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Customize.btNew btTaskNew;
		private RosySystem.Customize.btEdit btTaskEdit;
		private RosySystem.Customize.btDelete btTaskDelete;
		private System.Windows.Forms.ComboBox cboMa_Dt_CbNv;
		private System.Windows.Forms.ComboBox cboKieu_Nhom;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl tabCustomer;
		private System.Windows.Forms.TabPage pageCustomer;
		private RosySystem.Control.rsTextBox txtTen_Dt_Info;
		private System.Windows.Forms.RichTextBox txtNote;
		private RosySystem.Control.rsLabel rsLabel15;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel label1;
		private RosySystem.Control.rsTextBox txtMa_Dt;
		private System.Windows.Forms.TabControl tabDetail;
		private System.Windows.Forms.TabPage pageTask;
		private RosySystem.Control.rsDataGridView dgvTask;
		private System.Windows.Forms.TabPage pagePlan;
		private RosySystem.Control.rsDataGridView dgvPlan;
		private System.Windows.Forms.TabPage pageContact;
		private RosySystem.Control.rsDataGridView dgvContact;
		private System.Windows.Forms.TabPage pageContract;
		private RosySystem.Control.rsDataGridView dgvContract;
	}
}