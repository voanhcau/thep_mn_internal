namespace RosyModule.Machinery
{
	partial class frmKet_Qua_BTTB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKet_Qua_BTTB));
            this.TabPhanHoi = new RosySystem.Control.rsTabControl();
            this.pageKetQuaBTTB = new System.Windows.Forms.TabPage();
            this.dgvKet_Qua = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbtTen_Tb = new RosySystem.Control.rsLabel();
            this.btUpdateKQ = new RosySystem.Customize.btNew();
            this.TabPhanHoi.SuspendLayout();
            this.pageKetQuaBTTB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKet_Qua)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPhanHoi
            // 
            this.TabPhanHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPhanHoi.Controls.Add(this.pageKetQuaBTTB);
            this.TabPhanHoi.Location = new System.Drawing.Point(4, 7);
            this.TabPhanHoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TabPhanHoi.Name = "TabPhanHoi";
            this.TabPhanHoi.SelectedIndex = 0;
            this.TabPhanHoi.Size = new System.Drawing.Size(1067, 677);
            this.TabPhanHoi.TabIndex = 0;
            // 
            // pageKetQuaBTTB
            // 
            this.pageKetQuaBTTB.Controls.Add(this.dgvKet_Qua);
            this.pageKetQuaBTTB.Location = new System.Drawing.Point(4, 25);
            this.pageKetQuaBTTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageKetQuaBTTB.Name = "pageKetQuaBTTB";
            this.pageKetQuaBTTB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageKetQuaBTTB.Size = new System.Drawing.Size(1059, 648);
            this.pageKetQuaBTTB.TabIndex = 0;
            this.pageKetQuaBTTB.Text = "Kết quả bảo trì";
            this.pageKetQuaBTTB.UseVisualStyleBackColor = true;
            // 
            // dgvKet_Qua
            // 
            this.dgvKet_Qua.AllowUserToAddRows = false;
            this.dgvKet_Qua.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKet_Qua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKet_Qua.BackgroundColor = System.Drawing.Color.White;
            this.dgvKet_Qua.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKet_Qua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKet_Qua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKet_Qua.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKet_Qua.Location = new System.Drawing.Point(4, 4);
            this.dgvKet_Qua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvKet_Qua.MultiSelect = false;
            this.dgvKet_Qua.Name = "dgvKet_Qua";
            this.dgvKet_Qua.Size = new System.Drawing.Size(1051, 640);
            this.dgvKet_Qua.strZone = "";
            this.dgvKet_Qua.TabIndex = 2;
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
            this.btgAccept.Location = new System.Drawing.Point(824, 709);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(247, 52);
            this.btgAccept.TabIndex = 2;
            // 
            // lbtTen_Tb
            // 
            this.lbtTen_Tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbtTen_Tb.AutoEllipsis = true;
            this.lbtTen_Tb.AutoSize = true;
            this.lbtTen_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Tb.ForeColor = System.Drawing.Color.Red;
            this.lbtTen_Tb.Location = new System.Drawing.Point(9, 741);
            this.lbtTen_Tb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_Tb.Name = "lbtTen_Tb";
            this.lbtTen_Tb.Size = new System.Drawing.Size(998, 20);
            this.lbtTen_Tb.TabIndex = 140;
            this.lbtTen_Tb.Tag = "";
            this.lbtTen_Tb.Text = "Tình trạng kết quả sau bảo trì đánh X nếu Đạt, O nếu không đạt. Tick vào ô cập nh" +
    "ật lý lịch nếu đưa vào lý lịch thiết bị";
            this.lbtTen_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btUpdateKQ
            // 
            this.btUpdateKQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btUpdateKQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpdateKQ.ImageKey = "(none)";
            this.btUpdateKQ.Location = new System.Drawing.Point(13, 692);
            this.btUpdateKQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btUpdateKQ.Name = "btUpdateKQ";
            this.btUpdateKQ.Size = new System.Drawing.Size(117, 46);
            this.btUpdateKQ.TabIndex = 141;
            this.btUpdateKQ.Tag = " ";
            this.btUpdateKQ.Text = "&Cập nhật KQ từ phiếu BTTT";
            this.btUpdateKQ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdateKQ.UseVisualStyleBackColor = true;
            // 
            // frmKet_Qua_BTTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 768);
            this.Controls.Add(this.btUpdateKQ);
            this.Controls.Add(this.lbtTen_Tb);
            this.Controls.Add(this.TabPhanHoi);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmKet_Qua_BTTB";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Kết quả bảo trì thiết bị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TabPhanHoi.ResumeLayout(false);
            this.pageKetQuaBTTB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKet_Qua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage pageKetQuaBTTB;
		private RosySystem.Control.rsTabControl TabPhanHoi;
		private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.dgvVoucher dgvKet_Qua;
        private RosySystem.Control.rsLabel lbtTen_Tb;
        private RosySystem.Customize.btNew btUpdateKQ;
	}
}

