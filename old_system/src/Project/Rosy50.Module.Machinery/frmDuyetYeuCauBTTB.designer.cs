namespace RosyModule.Machinery
{
	partial class frmDuyetYeuCauBTTB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetYeuCauBTTB));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbChitiet = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDuyet = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.txtGD_Duyet = new RosySystem.Control.rsTextBox();
            this.lblGiam_Doc_Duyet = new RosySystem.Control.rsLabel();
            this.lbtTen_Gd_Duyet = new RosySystem.Control.rsLabel();
            this.chkDuyet = new RosySystem.Control.rsCheckbox();
            this.pnlTTien_Nt = new RosySystem.Control.rsPanel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.numTSo_Luong = new RosySystem.Control.rsTextBoxNumber();
            this.btNew = new RosySystem.Control.rsButton();
            this.btEdit = new RosySystem.Control.rsButton();
            this.btDelete = new RosySystem.Control.rsButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvCtVt = new RosySystem.Customize.dgvVoucher();
            this.tbCtYeuCau = new RosySystem.Control.rsTabControl();
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
            this.tbChitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChitiet.Controls.Add(this.tabPage1);
            this.tbChitiet.Location = new System.Drawing.Point(3, 6);
            this.tbChitiet.Name = "tbChitiet";
            this.tbChitiet.SelectedIndex = 0;
            this.tbChitiet.Size = new System.Drawing.Size(1131, 421);
            this.tbChitiet.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDuyet);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1123, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chi tiết duyệt phiếu";
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
            this.dgvDuyet.Location = new System.Drawing.Point(3, 3);
            this.dgvDuyet.MultiSelect = false;
            this.dgvDuyet.Name = "dgvDuyet";
            this.dgvDuyet.Size = new System.Drawing.Size(1117, 389);
            this.dgvDuyet.strZone = "";
            this.dgvDuyet.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(949, 650);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // txtGD_Duyet
            // 
            this.txtGD_Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGD_Duyet.AutoDropDown = null;
            this.txtGD_Duyet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGD_Duyet.Location = new System.Drawing.Point(97, 675);
            this.txtGD_Duyet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGD_Duyet.MaxLength = 20;
            this.txtGD_Duyet.Name = "txtGD_Duyet";
            this.txtGD_Duyet.Size = new System.Drawing.Size(117, 20);
            this.txtGD_Duyet.TabIndex = 64;
            // 
            // lblGiam_Doc_Duyet
            // 
            this.lblGiam_Doc_Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGiam_Doc_Duyet.AutoEllipsis = true;
            this.lblGiam_Doc_Duyet.AutoSize = true;
            this.lblGiam_Doc_Duyet.Location = new System.Drawing.Point(10, 678);
            this.lblGiam_Doc_Duyet.Name = "lblGiam_Doc_Duyet";
            this.lblGiam_Doc_Duyet.Size = new System.Drawing.Size(82, 13);
            this.lblGiam_Doc_Duyet.TabIndex = 65;
            this.lblGiam_Doc_Duyet.Tag = "";
            this.lblGiam_Doc_Duyet.Text = "Giám đốc duyệt";
            this.lblGiam_Doc_Duyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Gd_Duyet
            // 
            this.lbtTen_Gd_Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbtTen_Gd_Duyet.AutoEllipsis = true;
            this.lbtTen_Gd_Duyet.AutoSize = true;
            this.lbtTen_Gd_Duyet.Location = new System.Drawing.Point(219, 678);
            this.lbtTen_Gd_Duyet.Name = "lbtTen_Gd_Duyet";
            this.lbtTen_Gd_Duyet.Size = new System.Drawing.Size(102, 13);
            this.lbtTen_Gd_Duyet.TabIndex = 65;
            this.lbtTen_Gd_Duyet.Tag = "";
            this.lbtTen_Gd_Duyet.Text = "Tên giám đốc duyệt";
            this.lbtTen_Gd_Duyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDuyet
            // 
            this.chkDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDuyet.ForeColor = System.Drawing.Color.Red;
            this.chkDuyet.Location = new System.Drawing.Point(3, 651);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(121, 19);
            this.chkDuyet.TabIndex = 66;
            this.chkDuyet.Text = "Duyệt chứng từ";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // pnlTTien_Nt
            // 
            this.pnlTTien_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTTien_Nt.Controls.Add(this.rsLabel1);
            this.pnlTTien_Nt.Controls.Add(this.numTSo_Luong);
            this.pnlTTien_Nt.Location = new System.Drawing.Point(921, 598);
            this.pnlTTien_Nt.Name = "pnlTTien_Nt";
            this.pnlTTien_Nt.Size = new System.Drawing.Size(199, 40);
            this.pnlTTien_Nt.TabIndex = 112;
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(8, 12);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(48, 13);
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
            this.numTSo_Luong.Location = new System.Drawing.Point(89, 9);
            this.numTSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTSo_Luong.Name = "numTSo_Luong";
            this.numTSo_Luong.Scale = 2;
            this.numTSo_Luong.Size = new System.Drawing.Size(99, 20);
            this.numTSo_Luong.TabIndex = 112;
            this.numTSo_Luong.TabStop = false;
            this.numTSo_Luong.Text = "0.00";
            this.numTSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTSo_Luong.Value = 0D;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.Location = new System.Drawing.Point(6, 588);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(103, 39);
            this.btNew.TabIndex = 11;
            this.btNew.Text = "Thêm vật tư";
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEdit.Location = new System.Drawing.Point(111, 588);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(103, 39);
            this.btEdit.TabIndex = 11;
            this.btEdit.Text = "Sửa vật tư";
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.Location = new System.Drawing.Point(220, 588);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(103, 39);
            this.btDelete.TabIndex = 11;
            this.btDelete.Text = "Xóa vật tư";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvCtVt);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1116, 124);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Chi tiết yêu cầu";
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
            this.dgvCtVt.Location = new System.Drawing.Point(3, 3);
            this.dgvCtVt.MultiSelect = false;
            this.dgvCtVt.Name = "dgvCtVt";
            this.dgvCtVt.Size = new System.Drawing.Size(1110, 118);
            this.dgvCtVt.strZone = "";
            this.dgvCtVt.TabIndex = 0;
            // 
            // tbCtYeuCau
            // 
            this.tbCtYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCtYeuCau.Controls.Add(this.tabPage4);
            this.tbCtYeuCau.Location = new System.Drawing.Point(6, 433);
            this.tbCtYeuCau.Name = "tbCtYeuCau";
            this.tbCtYeuCau.SelectedIndex = 0;
            this.tbCtYeuCau.Size = new System.Drawing.Size(1124, 150);
            this.tbCtYeuCau.TabIndex = 117;
            this.tbCtYeuCau.TabStop = false;
            // 
            // frmDuyetYeuCauBTTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 698);
            this.Controls.Add(this.tbCtYeuCau);
            this.Controls.Add(this.pnlTTien_Nt);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.txtGD_Duyet);
            this.Controls.Add(this.lbtTen_Gd_Duyet);
            this.Controls.Add(this.lblGiam_Doc_Duyet);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.tbChitiet);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmDuyetYeuCauBTTB";
            this.Padding = new System.Windows.Forms.Padding(3);
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
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl tbChitiet;
		private RosySystem.Customize.btgAccept btgAccept;
		private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.dgvVoucher dgvDuyet;
		private RosySystem.Control.rsTextBox txtGD_Duyet;
		private RosySystem.Control.rsLabel lblGiam_Doc_Duyet;
        private RosySystem.Control.rsLabel lbtTen_Gd_Duyet;
        public RosySystem.Control.rsCheckbox chkDuyet;
        private RosySystem.Control.rsPanel pnlTTien_Nt;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBoxNumber numTSo_Luong;
        private RosySystem.Control.rsButton btNew;
        private RosySystem.Control.rsButton btEdit;
        private RosySystem.Control.rsButton btDelete;
        private System.Windows.Forms.TabPage tabPage4;
        private RosySystem.Customize.dgvVoucher dgvCtVt;
        private RosySystem.Control.rsTabControl tbCtYeuCau;
	}
}

