namespace RosyModule
{
    partial class frmDuyetCongTangCa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetCongTangCa));
            this.TabPhanHoi = new RosySystem.Control.rsTabControl();
            this.tpCongTangCa = new System.Windows.Forms.TabPage();
            this.dgvDuyetTangCa = new RosySystem.Customize.dgvVoucher();
            this.tpChamCong = new System.Windows.Forms.TabPage();
            this.dgvDuyetBangCong = new RosySystem.Customize.dgvVoucher();
            this.dgvVoucher1 = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.chkDuyet_Huy = new RosySystem.Control.rsCheckbox();
            this.chkDuyet = new RosySystem.Control.rsCheckbox();
            this.chkAll = new RosySystem.Control.rsCheckbox();
            this.lbtGhi_Chu = new RosySystem.Control.rsLabelName();
            this.lblDuyet_Log = new RosySystem.Control.rsLabelName();
            this.TabPhanHoi.SuspendLayout();
            this.tpCongTangCa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyetTangCa)).BeginInit();
            this.tpChamCong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyetBangCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPhanHoi
            // 
            this.TabPhanHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPhanHoi.Controls.Add(this.tpCongTangCa);
            this.TabPhanHoi.Controls.Add(this.tpChamCong);
            this.TabPhanHoi.Location = new System.Drawing.Point(3, 6);
            this.TabPhanHoi.Name = "TabPhanHoi";
            this.TabPhanHoi.SelectedIndex = 0;
            this.TabPhanHoi.Size = new System.Drawing.Size(1796, 509);
            this.TabPhanHoi.TabIndex = 0;
            // 
            // tpCongTangCa
            // 
            this.tpCongTangCa.Controls.Add(this.dgvDuyetTangCa);
            this.tpCongTangCa.Location = new System.Drawing.Point(4, 22);
            this.tpCongTangCa.Name = "tpCongTangCa";
            this.tpCongTangCa.Padding = new System.Windows.Forms.Padding(3);
            this.tpCongTangCa.Size = new System.Drawing.Size(1788, 483);
            this.tpCongTangCa.TabIndex = 0;
            this.tpCongTangCa.Text = "Thông tin tăng ca";
            this.tpCongTangCa.UseVisualStyleBackColor = true;
            // 
            // dgvDuyetTangCa
            // 
            this.dgvDuyetTangCa.AllowUserToAddRows = false;
            this.dgvDuyetTangCa.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDuyetTangCa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDuyetTangCa.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuyetTangCa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDuyetTangCa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDuyetTangCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDuyetTangCa.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDuyetTangCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDuyetTangCa.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDuyetTangCa.Location = new System.Drawing.Point(3, 3);
            this.dgvDuyetTangCa.MultiSelect = false;
            this.dgvDuyetTangCa.Name = "dgvDuyetTangCa";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDuyetTangCa.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDuyetTangCa.Size = new System.Drawing.Size(1782, 477);
            this.dgvDuyetTangCa.strZone = "";
            this.dgvDuyetTangCa.TabIndex = 2;
            // 
            // tpChamCong
            // 
            this.tpChamCong.Controls.Add(this.dgvDuyetBangCong);
            this.tpChamCong.Controls.Add(this.dgvVoucher1);
            this.tpChamCong.Location = new System.Drawing.Point(4, 22);
            this.tpChamCong.Name = "tpChamCong";
            this.tpChamCong.Size = new System.Drawing.Size(1788, 483);
            this.tpChamCong.TabIndex = 1;
            this.tpChamCong.Text = "Bảng chấm công";
            this.tpChamCong.UseVisualStyleBackColor = true;
            // 
            // dgvDuyetBangCong
            // 
            this.dgvDuyetBangCong.AllowUserToAddRows = false;
            this.dgvDuyetBangCong.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDuyetBangCong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDuyetBangCong.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuyetBangCong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDuyetBangCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDuyetBangCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDuyetBangCong.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDuyetBangCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDuyetBangCong.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDuyetBangCong.Location = new System.Drawing.Point(0, 0);
            this.dgvDuyetBangCong.MultiSelect = false;
            this.dgvDuyetBangCong.Name = "dgvDuyetBangCong";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDuyetBangCong.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDuyetBangCong.Size = new System.Drawing.Size(1788, 483);
            this.dgvDuyetBangCong.strZone = "";
            this.dgvDuyetBangCong.TabIndex = 4;
            // 
            // dgvVoucher1
            // 
            this.dgvVoucher1.AllowUserToAddRows = false;
            this.dgvVoucher1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvVoucher1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvVoucher1.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoucher1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoucher1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvVoucher1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVoucher1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvVoucher1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVoucher1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvVoucher1.Location = new System.Drawing.Point(0, 0);
            this.dgvVoucher1.MultiSelect = false;
            this.dgvVoucher1.Name = "dgvVoucher1";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoucher1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvVoucher1.Size = new System.Drawing.Size(1788, 483);
            this.dgvVoucher1.strZone = "";
            this.dgvVoucher1.TabIndex = 3;
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
            this.btgAccept.Location = new System.Drawing.Point(1614, 518);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // chkDuyet_Huy
            // 
            this.chkDuyet_Huy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDuyet_Huy.AutoSize = true;
            this.chkDuyet_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDuyet_Huy.ForeColor = System.Drawing.Color.Red;
            this.chkDuyet_Huy.Location = new System.Drawing.Point(10, 541);
            this.chkDuyet_Huy.Name = "chkDuyet_Huy";
            this.chkDuyet_Huy.Size = new System.Drawing.Size(159, 19);
            this.chkDuyet_Huy.TabIndex = 121;
            this.chkDuyet_Huy.Text = "Hủy duyệt bảng công";
            this.chkDuyet_Huy.UseVisualStyleBackColor = true;
            // 
            // chkDuyet
            // 
            this.chkDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDuyet.ForeColor = System.Drawing.Color.Red;
            this.chkDuyet.Location = new System.Drawing.Point(10, 521);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(133, 19);
            this.chkDuyet.TabIndex = 120;
            this.chkDuyet.Text = "Duyệt bảng công";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.ForeColor = System.Drawing.Color.Red;
            this.chkAll.Location = new System.Drawing.Point(163, 521);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(142, 19);
            this.chkAll.TabIndex = 120;
            this.chkAll.Text = "Xem tất cả dữ liệu";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // lbtGhi_Chu
            // 
            this.lbtGhi_Chu.AutoSize = true;
            this.lbtGhi_Chu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtGhi_Chu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtGhi_Chu.Location = new System.Drawing.Point(160, 524);
            this.lbtGhi_Chu.Name = "lbtGhi_Chu";
            this.lbtGhi_Chu.Size = new System.Drawing.Size(268, 13);
            this.lbtGhi_Chu.TabIndex = 122;
            this.lbtGhi_Chu.Tag = "";
            this.lbtGhi_Chu.Text = "Trưởng đơn vị lưu ý do nếu hệ số ABC khác A";
            this.lbtGhi_Chu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuyet_Log
            // 
            this.lblDuyet_Log.AutoSize = true;
            this.lblDuyet_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuyet_Log.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDuyet_Log.Location = new System.Drawing.Point(160, 543);
            this.lblDuyet_Log.Name = "lblDuyet_Log";
            this.lblDuyet_Log.Size = new System.Drawing.Size(131, 13);
            this.lblDuyet_Log.TabIndex = 123;
            this.lblDuyet_Log.Tag = "";
            this.lblDuyet_Log.Text = "Thông tin người duyệt";
            this.lblDuyet_Log.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDuyetCongTangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 566);
            this.Controls.Add(this.lblDuyet_Log);
            this.Controls.Add(this.lbtGhi_Chu);
            this.Controls.Add(this.chkDuyet_Huy);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.TabPhanHoi);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDuyetCongTangCa";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Duyệt công tăng ca";
            this.TabPhanHoi.ResumeLayout(false);
            this.tpCongTangCa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyetTangCa)).EndInit();
            this.tpChamCong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyetBangCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tpCongTangCa;
		private RosySystem.Control.rsTabControl TabPhanHoi;
		private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.dgvVoucher dgvDuyetTangCa;
        private System.Windows.Forms.TabPage tpChamCong;
        private RosySystem.Customize.dgvVoucher dgvDuyetBangCong;
        private RosySystem.Customize.dgvVoucher dgvVoucher1;
        public RosySystem.Control.rsCheckbox chkDuyet_Huy;
        public RosySystem.Control.rsCheckbox chkDuyet;
        public RosySystem.Control.rsCheckbox chkAll;
        private RosySystem.Control.rsLabelName lbtGhi_Chu;
        private RosySystem.Control.rsLabelName lblDuyet_Log;
	}
}

