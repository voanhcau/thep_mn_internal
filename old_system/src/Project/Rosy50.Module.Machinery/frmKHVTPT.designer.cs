namespace RosyModule.Machinery
{
    partial class frmKHVTPT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKHVTPT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbChitiet = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDuyet = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlTTien_Nt = new RosySystem.Control.rsPanel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.numTSo_Luong = new RosySystem.Control.rsTextBoxNumber();
            this.btNew = new RosySystem.Control.rsButton();
            this.btEdit = new RosySystem.Control.rsButton();
            this.btDelete = new RosySystem.Control.rsButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvCtVt = new RosySystem.Customize.dgvVoucher();
            this.tbCtYeuCau = new RosySystem.Control.rsTabControl();
            this.btPrint = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.tbChitiet.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyet)).BeginInit();
            this.pnlTTien_Nt.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtVt)).BeginInit();
            this.tbCtYeuCau.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbChitiet
            // 
            this.tbChitiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChitiet.Controls.Add(this.tabPage1);
            this.tbChitiet.Location = new System.Drawing.Point(4, 7);
            this.tbChitiet.Margin = new System.Windows.Forms.Padding(4);
            this.tbChitiet.Name = "tbChitiet";
            this.tbChitiet.SelectedIndex = 0;
            this.tbChitiet.Size = new System.Drawing.Size(713, 732);
            this.tbChitiet.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDuyet);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(705, 703);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nội dung BTTB";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDuyet
            // 
            this.dgvDuyet.AllowUserToAddRows = false;
            this.dgvDuyet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDuyet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDuyet.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuyet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDuyet.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDuyet.Location = new System.Drawing.Point(4, 4);
            this.dgvDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDuyet.MultiSelect = false;
            this.dgvDuyet.Name = "dgvDuyet";
            this.dgvDuyet.Size = new System.Drawing.Size(697, 695);
            this.dgvDuyet.strZone = "";
            this.dgvDuyet.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // pnlTTien_Nt
            // 
            this.pnlTTien_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTTien_Nt.Controls.Add(this.rsLabel1);
            this.pnlTTien_Nt.Controls.Add(this.numTSo_Luong);
            this.pnlTTien_Nt.Location = new System.Drawing.Point(1228, 747);
            this.pnlTTien_Nt.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTTien_Nt.Name = "pnlTTien_Nt";
            this.pnlTTien_Nt.Size = new System.Drawing.Size(265, 49);
            this.pnlTTien_Nt.TabIndex = 112;
            this.pnlTTien_Nt.Visible = false;
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(11, 15);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(62, 17);
            this.rsLabel1.TabIndex = 113;
            this.rsLabel1.Tag = "TSo_Luong";
            this.rsLabel1.Text = "Tổng SL";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTSo_Luong
            // 
            this.numTSo_Luong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTSo_Luong.AutoDropDown = null;
            this.numTSo_Luong.bFormat = true;
            this.numTSo_Luong.Location = new System.Drawing.Point(119, 11);
            this.numTSo_Luong.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numTSo_Luong.Name = "numTSo_Luong";
            this.numTSo_Luong.Scale = 2;
            this.numTSo_Luong.Size = new System.Drawing.Size(131, 22);
            this.numTSo_Luong.TabIndex = 112;
            this.numTSo_Luong.TabStop = false;
            this.numTSo_Luong.Text = "0.00";
            this.numTSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTSo_Luong.Value = 0D;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.Location = new System.Drawing.Point(957, 804);
            this.btNew.Margin = new System.Windows.Forms.Padding(4);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(103, 48);
            this.btNew.TabIndex = 11;
            this.btNew.Text = "Thêm vật tư";
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Location = new System.Drawing.Point(1068, 804);
            this.btEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(103, 48);
            this.btEdit.TabIndex = 11;
            this.btEdit.Text = "Sửa vật tư";
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(1179, 804);
            this.btDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(103, 48);
            this.btDelete.TabIndex = 11;
            this.btDelete.Text = "Xóa vật tư";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvCtVt);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(783, 703);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Chi tiết vật tư phục vụ BTTB";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvCtVt
            // 
            this.dgvCtVt.AllowUserToAddRows = false;
            this.dgvCtVt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtVt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCtVt.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtVt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtVt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtVt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtVt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtVt.Location = new System.Drawing.Point(4, 4);
            this.dgvCtVt.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCtVt.MultiSelect = false;
            this.dgvCtVt.Name = "dgvCtVt";
            this.dgvCtVt.Size = new System.Drawing.Size(775, 695);
            this.dgvCtVt.strZone = "";
            this.dgvCtVt.TabIndex = 0;
            // 
            // tbCtYeuCau
            // 
            this.tbCtYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCtYeuCau.Controls.Add(this.tabPage4);
            this.tbCtYeuCau.Location = new System.Drawing.Point(721, 7);
            this.tbCtYeuCau.Margin = new System.Windows.Forms.Padding(4);
            this.tbCtYeuCau.Name = "tbCtYeuCau";
            this.tbCtYeuCau.SelectedIndex = 0;
            this.tbCtYeuCau.Size = new System.Drawing.Size(791, 732);
            this.tbCtYeuCau.TabIndex = 117;
            this.tbCtYeuCau.TabStop = false;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Location = new System.Drawing.Point(1290, 804);
            this.btPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(103, 48);
            this.btPrint.TabIndex = 11;
            this.btPrint.Text = "In";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Location = new System.Drawing.Point(1401, 804);
            this.btExit.Margin = new System.Windows.Forms.Padding(4);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(103, 48);
            this.btExit.TabIndex = 11;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // frmKHVTPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1516, 859);
            this.Controls.Add(this.tbCtYeuCau);
            this.Controls.Add(this.pnlTTien_Nt);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.tbChitiet);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmKHVTPT";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Duyệt chứng từ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbChitiet.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyet)).EndInit();
            this.pnlTTien_Nt.ResumeLayout(false);
            this.pnlTTien_Nt.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtVt)).EndInit();
            this.tbCtYeuCau.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
        private RosySystem.Control.rsTabControl tbChitiet;
		private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.dgvVoucher dgvDuyet;
        private RosySystem.Control.rsPanel pnlTTien_Nt;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBoxNumber numTSo_Luong;
        private RosySystem.Control.rsButton btNew;
        private RosySystem.Control.rsButton btEdit;
        private RosySystem.Control.rsButton btDelete;
        private System.Windows.Forms.TabPage tabPage4;
        private RosySystem.Customize.dgvVoucher dgvCtVt;
        private RosySystem.Control.rsTabControl tbCtYeuCau;
        private RosySystem.Control.rsButton btPrint;
        private RosySystem.Control.rsButton btExit;
	}
}

