namespace RosyModule.CRM
{
	partial class frmToDo
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
			this.cboKieu_Nhom = new System.Windows.Forms.ComboBox();
			this.cboMa_Dt_CbNv = new System.Windows.Forms.ComboBox();
			this.rsLabel18 = new RosySystem.Control.rsLabel();
			this.chkProcessing_Only = new System.Windows.Forms.CheckBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.cboMa_Dt_CbNv_Th = new System.Windows.Forms.ComboBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btDelete = new RosySystem.Customize.btDelete();
			this.btNew = new RosySystem.Customize.btNew();
			this.btFilter = new RosySystem.Customize.btFilter();
			this.btEdit = new RosySystem.Customize.btEdit();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.pageTask = new System.Windows.Forms.TabPage();
			this.pageCustomer = new System.Windows.Forms.TabPage();
			this.btEdit_Customer = new System.Windows.Forms.Button();
			this.tabDetail = new System.Windows.Forms.TabControl();
			this.pageContact = new System.Windows.Forms.TabPage();
			this.dgvContact = new RosySystem.Control.rsDataGridView();
			this.txtNote = new System.Windows.Forms.RichTextBox();
			this.rsLabel15 = new RosySystem.Control.rsLabel();
			this.rsLabel13 = new RosySystem.Control.rsLabel();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.txtMa_Dt_Kh = new RosySystem.Control.rsTextBox();
			this.txtTen_Dt_Info = new RosySystem.Control.rsTextBox();
			this.btDelete_Contact = new RosySystem.Customize.btDelete();
			this.btNew_Contact = new RosySystem.Customize.btNew();
			this.btEdit_Contact = new RosySystem.Customize.btEdit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.pageCustomer.SuspendLayout();
			this.tabDetail.SuspendLayout();
			this.pageContact.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
			this.SuspendLayout();
			// 
			// cboKieu_Nhom
			// 
			this.cboKieu_Nhom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cboKieu_Nhom.FormattingEnabled = true;
			this.cboKieu_Nhom.Items.AddRange(new object[] {
            "0-Không nhóm",
            "1-Theo khách hàng",
            "2-Theo hợp đồng",
            "3-Theo tình trạng",
            "4-Theo Chủ đề",
            "5-Theo người giao dịch",
            "6-Theo người thực hiện"});
			this.cboKieu_Nhom.Location = new System.Drawing.Point(761, 30);
			this.cboKieu_Nhom.Name = "cboKieu_Nhom";
			this.cboKieu_Nhom.Size = new System.Drawing.Size(152, 21);
			this.cboKieu_Nhom.TabIndex = 8;
			this.cboKieu_Nhom.Text = "0-Không nhóm";
			// 
			// cboMa_Dt_CbNv
			// 
			this.cboMa_Dt_CbNv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cboMa_Dt_CbNv.FormattingEnabled = true;
			this.cboMa_Dt_CbNv.Location = new System.Drawing.Point(429, 30);
			this.cboMa_Dt_CbNv.Name = "cboMa_Dt_CbNv";
			this.cboMa_Dt_CbNv.Size = new System.Drawing.Size(128, 21);
			this.cboMa_Dt_CbNv.TabIndex = 5;
			// 
			// rsLabel18
			// 
			this.rsLabel18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel18.AutoEllipsis = true;
			this.rsLabel18.AutoSize = true;
			this.rsLabel18.Location = new System.Drawing.Point(342, 35);
			this.rsLabel18.Name = "rsLabel18";
			this.rsLabel18.Size = new System.Drawing.Size(81, 13);
			this.rsLabel18.TabIndex = 4;
			this.rsLabel18.Text = "Người giao dịch";
			this.rsLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkProcessing_Only
			// 
			this.chkProcessing_Only.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkProcessing_Only.AutoSize = true;
			this.chkProcessing_Only.Checked = true;
			this.chkProcessing_Only.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkProcessing_Only.Location = new System.Drawing.Point(716, 7);
			this.chkProcessing_Only.Name = "chkProcessing_Only";
			this.chkProcessing_Only.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkProcessing_Only.Size = new System.Drawing.Size(197, 17);
			this.chkProcessing_Only.TabIndex = 9;
			this.chkProcessing_Only.Text = "Chỉ hiển thị công việc chưa hoàn tất";
			this.chkProcessing_Only.UseVisualStyleBackColor = true;
			// 
			// rsLabel1
			// 
			this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(563, 33);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(55, 13);
			this.rsLabel1.TabIndex = 6;
			this.rsLabel1.Text = "Thực hiện";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboMa_Dt_CbNv_Th
			// 
			this.cboMa_Dt_CbNv_Th.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cboMa_Dt_CbNv_Th.FormattingEnabled = true;
			this.cboMa_Dt_CbNv_Th.Location = new System.Drawing.Point(627, 30);
			this.cboMa_Dt_CbNv_Th.Name = "cboMa_Dt_CbNv_Th";
			this.cboMa_Dt_CbNv_Th.Size = new System.Drawing.Size(128, 21);
			this.cboMa_Dt_CbNv_Th.TabIndex = 7;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btDelete);
			this.splitContainer1.Panel2.Controls.Add(this.btNew);
			this.splitContainer1.Panel2.Controls.Add(this.btFilter);
			this.splitContainer1.Panel2.Controls.Add(this.btEdit);
			this.splitContainer1.Panel2.Controls.Add(this.chkProcessing_Only);
			this.splitContainer1.Panel2.Controls.Add(this.cboMa_Dt_CbNv_Th);
			this.splitContainer1.Panel2.Controls.Add(this.cboKieu_Nhom);
			this.splitContainer1.Panel2.Controls.Add(this.rsLabel1);
			this.splitContainer1.Panel2.Controls.Add(this.rsLabel18);
			this.splitContainer1.Panel2.Controls.Add(this.cboMa_Dt_CbNv);
			this.splitContainer1.Size = new System.Drawing.Size(925, 575);
			this.splitContainer1.SplitterDistance = 508;
			this.splitContainer1.TabIndex = 0;
			// 
			// btDelete
			// 
			this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDelete.ImageKey = "Delete.png";
			this.btDelete.Location = new System.Drawing.Point(163, 9);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(67, 42);
			this.btDelete.TabIndex = 2;
			this.btDelete.Tag = "Delete";
			this.btDelete.Text = "Xóa";
			this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btDelete.UseVisualStyleBackColor = true;
			// 
			// btNew
			// 
			this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew.ImageKey = "New.png";
			this.btNew.Location = new System.Drawing.Point(15, 9);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(67, 42);
			this.btNew.TabIndex = 0;
			this.btNew.Tag = "New";
			this.btNew.Text = "Thêm";
			this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// btFilter
			// 
			this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btFilter.ImageKey = "Filter.png";
			this.btFilter.Location = new System.Drawing.Point(237, 9);
			this.btFilter.Name = "btFilter";
			this.btFilter.Size = new System.Drawing.Size(64, 42);
			this.btFilter.TabIndex = 3;
			this.btFilter.Tag = "Filter";
			this.btFilter.Text = "Lọc";
			this.btFilter.UseVisualStyleBackColor = true;
			// 
			// btEdit
			// 
			this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit.ImageKey = "Edit.png";
			this.btEdit.Location = new System.Drawing.Point(90, 9);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(66, 42);
			this.btEdit.TabIndex = 1;
			this.btEdit.Tag = "Edit";
			this.btEdit.Text = "Sửa";
			this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btEdit.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.pageTask);
			this.tabControl1.Controls.Add(this.pageCustomer);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(919, 502);
			this.tabControl1.TabIndex = 0;
			// 
			// pageTask
			// 
			this.pageTask.Location = new System.Drawing.Point(4, 22);
			this.pageTask.Name = "pageTask";
			this.pageTask.Padding = new System.Windows.Forms.Padding(3);
			this.pageTask.Size = new System.Drawing.Size(911, 476);
			this.pageTask.TabIndex = 0;
			this.pageTask.Text = "Thông tin giao dịch";
			this.pageTask.UseVisualStyleBackColor = true;
			// 
			// pageCustomer
			// 
			this.pageCustomer.Controls.Add(this.btDelete_Contact);
			this.pageCustomer.Controls.Add(this.btNew_Contact);
			this.pageCustomer.Controls.Add(this.btEdit_Contact);
			this.pageCustomer.Controls.Add(this.btEdit_Customer);
			this.pageCustomer.Controls.Add(this.tabDetail);
			this.pageCustomer.Controls.Add(this.txtNote);
			this.pageCustomer.Controls.Add(this.rsLabel15);
			this.pageCustomer.Controls.Add(this.rsLabel13);
			this.pageCustomer.Controls.Add(this.rsLabel6);
			this.pageCustomer.Controls.Add(this.txtMa_Dt_Kh);
			this.pageCustomer.Controls.Add(this.txtTen_Dt_Info);
			this.pageCustomer.Location = new System.Drawing.Point(4, 22);
			this.pageCustomer.Name = "pageCustomer";
			this.pageCustomer.Padding = new System.Windows.Forms.Padding(3);
			this.pageCustomer.Size = new System.Drawing.Size(911, 476);
			this.pageCustomer.TabIndex = 1;
			this.pageCustomer.Text = "Thông tin khách hàng";
			this.pageCustomer.UseVisualStyleBackColor = true;
			// 
			// btEdit_Customer
			// 
			this.btEdit_Customer.Location = new System.Drawing.Point(297, 25);
			this.btEdit_Customer.Name = "btEdit_Customer";
			this.btEdit_Customer.Size = new System.Drawing.Size(43, 24);
			this.btEdit_Customer.TabIndex = 33;
			this.btEdit_Customer.Text = "Edit";
			this.btEdit_Customer.UseVisualStyleBackColor = true;
			// 
			// tabDetail
			// 
			this.tabDetail.Controls.Add(this.pageContact);
			this.tabDetail.Location = new System.Drawing.Point(125, 198);
			this.tabDetail.Name = "tabDetail";
			this.tabDetail.SelectedIndex = 0;
			this.tabDetail.Size = new System.Drawing.Size(599, 221);
			this.tabDetail.TabIndex = 29;
			// 
			// pageContact
			// 
			this.pageContact.Controls.Add(this.dgvContact);
			this.pageContact.Location = new System.Drawing.Point(4, 22);
			this.pageContact.Name = "pageContact";
			this.pageContact.Padding = new System.Windows.Forms.Padding(3);
			this.pageContact.Size = new System.Drawing.Size(591, 195);
			this.pageContact.TabIndex = 1;
			this.pageContact.Text = "Thông tin Liên hệ";
			this.pageContact.UseVisualStyleBackColor = true;
			// 
			// dgvContact
			// 
			this.dgvContact.AllowUserToAddRows = false;
			this.dgvContact.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvContact.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
			this.dgvContact.Size = new System.Drawing.Size(585, 189);
			this.dgvContact.strZone = "";
			this.dgvContact.TabIndex = 0;
			// 
			// txtNote
			// 
			this.txtNote.Location = new System.Drawing.Point(125, 97);
			this.txtNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNote.Name = "txtNote";
			this.txtNote.ReadOnly = true;
			this.txtNote.Size = new System.Drawing.Size(495, 96);
			this.txtNote.TabIndex = 28;
			this.txtNote.Text = "";
			// 
			// rsLabel15
			// 
			this.rsLabel15.AutoEllipsis = true;
			this.rsLabel15.AutoSize = true;
			this.rsLabel15.Location = new System.Drawing.Point(21, 100);
			this.rsLabel15.Name = "rsLabel15";
			this.rsLabel15.Size = new System.Drawing.Size(44, 13);
			this.rsLabel15.TabIndex = 32;
			this.rsLabel15.Text = "Ghi chú";
			this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel13
			// 
			this.rsLabel13.AutoEllipsis = true;
			this.rsLabel13.AutoSize = true;
			this.rsLabel13.Location = new System.Drawing.Point(21, 30);
			this.rsLabel13.Name = "rsLabel13";
			this.rsLabel13.Size = new System.Drawing.Size(82, 13);
			this.rsLabel13.TabIndex = 31;
			this.rsLabel13.Tag = "Ma_Dt";
			this.rsLabel13.Text = "Mã khách hàng";
			this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(21, 59);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(86, 13);
			this.rsLabel6.TabIndex = 30;
			this.rsLabel6.Tag = "Ten_Dt";
			this.rsLabel6.Text = "Tên khách hàng";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Dt_Kh
			// 
			this.txtMa_Dt_Kh.Location = new System.Drawing.Point(125, 27);
			this.txtMa_Dt_Kh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Dt_Kh.Name = "txtMa_Dt_Kh";
			this.txtMa_Dt_Kh.ReadOnly = true;
			this.txtMa_Dt_Kh.Size = new System.Drawing.Size(169, 20);
			this.txtMa_Dt_Kh.TabIndex = 26;
			// 
			// txtTen_Dt_Info
			// 
			this.txtTen_Dt_Info.Location = new System.Drawing.Point(125, 49);
			this.txtTen_Dt_Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Dt_Info.Multiline = true;
			this.txtTen_Dt_Info.Name = "txtTen_Dt_Info";
			this.txtTen_Dt_Info.ReadOnly = true;
			this.txtTen_Dt_Info.Size = new System.Drawing.Size(495, 46);
			this.txtTen_Dt_Info.TabIndex = 27;
			this.txtTen_Dt_Info.TabStop = false;
			// 
			// btDelete_Contact
			// 
			this.btDelete_Contact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDelete_Contact.ImageKey = "Delete.png";
			this.btDelete_Contact.Location = new System.Drawing.Point(273, 421);
			this.btDelete_Contact.Name = "btDelete_Contact";
			this.btDelete_Contact.Size = new System.Drawing.Size(67, 42);
			this.btDelete_Contact.TabIndex = 36;
			this.btDelete_Contact.Tag = "Delete";
			this.btDelete_Contact.Text = "Xóa";
			this.btDelete_Contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btDelete_Contact.UseVisualStyleBackColor = true;
			// 
			// btNew_Contact
			// 
			this.btNew_Contact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew_Contact.ImageKey = "New.png";
			this.btNew_Contact.Location = new System.Drawing.Point(125, 421);
			this.btNew_Contact.Name = "btNew_Contact";
			this.btNew_Contact.Size = new System.Drawing.Size(67, 42);
			this.btNew_Contact.TabIndex = 34;
			this.btNew_Contact.Tag = "New";
			this.btNew_Contact.Text = "Thêm";
			this.btNew_Contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btNew_Contact.UseVisualStyleBackColor = true;
			// 
			// btEdit_Contact
			// 
			this.btEdit_Contact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit_Contact.ImageKey = "Edit.png";
			this.btEdit_Contact.Location = new System.Drawing.Point(200, 421);
			this.btEdit_Contact.Name = "btEdit_Contact";
			this.btEdit_Contact.Size = new System.Drawing.Size(66, 42);
			this.btEdit_Contact.TabIndex = 35;
			this.btEdit_Contact.Tag = "Edit";
			this.btEdit_Contact.Text = "Sửa";
			this.btEdit_Contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btEdit_Contact.UseVisualStyleBackColor = true;
			// 
			// frmToDo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 575);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmToDo";
			this.Text = "frmToDo";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.pageCustomer.ResumeLayout(false);
			this.pageCustomer.PerformLayout();
			this.tabDetail.ResumeLayout(false);
			this.pageContact.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboKieu_Nhom;
		private System.Windows.Forms.ComboBox cboMa_Dt_CbNv;
		private RosySystem.Control.rsLabel rsLabel18;
		private System.Windows.Forms.CheckBox chkProcessing_Only;
		private RosySystem.Control.rsLabel rsLabel1;
		private System.Windows.Forms.ComboBox cboMa_Dt_CbNv_Th;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Customize.btEdit btEdit;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage pageTask;
		private System.Windows.Forms.TabPage pageCustomer;
		private System.Windows.Forms.Button btEdit_Customer;
		private System.Windows.Forms.TabControl tabDetail;
		private System.Windows.Forms.TabPage pageContact;
		private RosySystem.Control.rsDataGridView dgvContact;
		private System.Windows.Forms.RichTextBox txtNote;
		private RosySystem.Control.rsLabel rsLabel15;
		private RosySystem.Control.rsLabel rsLabel13;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsTextBox txtMa_Dt_Kh;
		private RosySystem.Control.rsTextBox txtTen_Dt_Info;
		private RosySystem.Customize.btDelete btDelete_Contact;
		private RosySystem.Customize.btNew btNew_Contact;
		private RosySystem.Customize.btEdit btEdit_Contact;
	}
}