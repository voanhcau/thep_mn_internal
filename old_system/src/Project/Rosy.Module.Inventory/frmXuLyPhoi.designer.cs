namespace RosyModule.Inventory
{
	partial class frmXuLyPhoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuLyPhoi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvEditCt = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.rsTabControl2 = new RosySystem.Control.rsTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvEdit_CtLr = new RosySystem.Customize.dgvVoucher();
            this.btThoat = new RosySystem.Control.rsButton();
            this.btDelete = new RosySystem.Control.rsButton();
            this.btEdit = new RosySystem.Control.rsButton();
            this.btNew = new RosySystem.Control.rsButton();
            this.chkIs_CXL = new RosySystem.Control.rsCheckbox();
            this.btUpdate = new RosySystem.Control.rsButton();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt)).BeginInit();
            this.rsTabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit_CtLr)).BeginInit();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Location = new System.Drawing.Point(3, 44);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(769, 270);
            this.rsTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvEditCt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(761, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chi tiết xuất kho";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvEditCt
            // 
            this.dgvEditCt.AllowUserToAddRows = false;
            this.dgvEditCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEditCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEditCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvEditCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEditCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEditCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEditCt.Location = new System.Drawing.Point(3, 3);
            this.dgvEditCt.MultiSelect = false;
            this.dgvEditCt.Name = "dgvEditCt";
            this.dgvEditCt.Size = new System.Drawing.Size(755, 238);
            this.dgvEditCt.strZone = "";
            this.dgvEditCt.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(175, 6);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(53, 13);
            this.rsLabel1.TabIndex = 67;
            this.rsLabel1.Tag = "Ngay_Ct2";
            this.rsLabel1.Text = "Đến ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(12, 6);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct.TabIndex = 68;
            this.lblNgay_Ct.Tag = "Ngay_Ct1";
            this.lblNgay_Ct.Text = "Từ ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(233, 3);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 66;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(63, 3);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct1.TabIndex = 65;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(582, -1);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(86, 24);
            this.btRefresh.TabIndex = 69;
            this.btRefresh.Text = "F5 - Refresh\r\n";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // rsTabControl2
            // 
            this.rsTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl2.Controls.Add(this.tabPage2);
            this.rsTabControl2.Location = new System.Drawing.Point(3, 336);
            this.rsTabControl2.Name = "rsTabControl2";
            this.rsTabControl2.SelectedIndex = 0;
            this.rsTabControl2.Size = new System.Drawing.Size(769, 176);
            this.rsTabControl2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvEdit_CtLr);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(761, 150);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Chi tiết xử lý";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvEdit_CtLr
            // 
            this.dgvEdit_CtLr.AllowUserToAddRows = false;
            this.dgvEdit_CtLr.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEdit_CtLr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEdit_CtLr.BackgroundColor = System.Drawing.Color.White;
            this.dgvEdit_CtLr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEdit_CtLr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEdit_CtLr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEdit_CtLr.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEdit_CtLr.Location = new System.Drawing.Point(3, 3);
            this.dgvEdit_CtLr.MultiSelect = false;
            this.dgvEdit_CtLr.Name = "dgvEdit_CtLr";
            this.dgvEdit_CtLr.Size = new System.Drawing.Size(755, 144);
            this.dgvEdit_CtLr.strZone = "";
            this.dgvEdit_CtLr.TabIndex = 1;
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Location = new System.Drawing.Point(703, 518);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(69, 42);
            this.btThoat.TabIndex = 69;
            this.btThoat.Tag = "Thoat";
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(628, 518);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(69, 42);
            this.btDelete.TabIndex = 69;
            this.btDelete.Tag = "Delete";
            this.btDelete.Text = "Xóa";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Location = new System.Drawing.Point(553, 518);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(69, 42);
            this.btEdit.TabIndex = 69;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "Sửa";
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.Location = new System.Drawing.Point(478, 518);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(69, 42);
            this.btNew.TabIndex = 69;
            this.btNew.Tag = "New";
            this.btNew.Text = "Thêm";
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // chkIs_CXL
            // 
            this.chkIs_CXL.AutoSize = true;
            this.chkIs_CXL.Checked = true;
            this.chkIs_CXL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIs_CXL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_CXL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkIs_CXL.Location = new System.Drawing.Point(383, 5);
            this.chkIs_CXL.Name = "chkIs_CXL";
            this.chkIs_CXL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIs_CXL.Size = new System.Drawing.Size(193, 17);
            this.chkIs_CXL.TabIndex = 70;
            this.chkIs_CXL.TabStop = false;
            this.chkIs_CXL.Text = "Chỉ lấy những phôi chưa xử lý";
            this.chkIs_CXL.UseVisualStyleBackColor = true;
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(583, 23);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(172, 24);
            this.btUpdate.TabIndex = 71;
            this.btUpdate.Text = "Cập nhật dữ liệu nghiệm thu phôi";
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // frmXuLyPhoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 566);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.chkIs_CXL);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.dteNgay_Ct2);
            this.Controls.Add(this.dteNgay_Ct1);
            this.Controls.Add(this.rsTabControl2);
            this.Controls.Add(this.rsTabControl1);
            this.Name = "frmXuLyPhoi";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Chi tiết xử lý";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt)).EndInit();
            this.rsTabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit_CtLr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl rsTabControl1;
		private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Customize.dgvVoucher dgvEditCt;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel lblNgay_Ct;
		private RosySystem.Control.rsDateTime dteNgay_Ct2;
		private RosySystem.Control.rsDateTime dteNgay_Ct1;
		private RosySystem.Control.rsButton btRefresh;
		private RosySystem.Control.rsTabControl rsTabControl2;
		private System.Windows.Forms.TabPage tabPage2;
		private RosySystem.Customize.dgvVoucher dgvEdit_CtLr;
		private RosySystem.Control.rsButton btThoat;
		private RosySystem.Control.rsButton btDelete;
		private RosySystem.Control.rsButton btEdit;
		private RosySystem.Control.rsButton btNew;
		private RosySystem.Control.rsCheckbox chkIs_CXL;
        private RosySystem.Control.rsButton btUpdate;
	}
}

