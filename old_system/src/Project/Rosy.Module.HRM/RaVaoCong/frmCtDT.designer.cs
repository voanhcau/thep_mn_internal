namespace RosyModule.HRM
{
    partial class frmCtDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCtDT));
            this.TabPhanHoi = new RosySystem.Control.rsTabControl();
            this.pageCTVTPT = new System.Windows.Forms.TabPage();
            this.dgvPhanHoiKHVT = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.TabPhanHoi.SuspendLayout();
            this.pageCTVTPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoiKHVT)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPhanHoi
            // 
            this.TabPhanHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPhanHoi.Controls.Add(this.pageCTVTPT);
            this.TabPhanHoi.Location = new System.Drawing.Point(3, 6);
            this.TabPhanHoi.Name = "TabPhanHoi";
            this.TabPhanHoi.SelectedIndex = 0;
            this.TabPhanHoi.Size = new System.Drawing.Size(935, 369);
            this.TabPhanHoi.TabIndex = 0;
            // 
            // pageCTVTPT
            // 
            this.pageCTVTPT.Controls.Add(this.dgvPhanHoiKHVT);
            this.pageCTVTPT.Location = new System.Drawing.Point(4, 22);
            this.pageCTVTPT.Name = "pageCTVTPT";
            this.pageCTVTPT.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pageCTVTPT.Size = new System.Drawing.Size(927, 343);
            this.pageCTVTPT.TabIndex = 0;
            this.pageCTVTPT.Text = "Chi tiết VTPT Vào - Ra cổng";
            this.pageCTVTPT.UseVisualStyleBackColor = true;
            // 
            // dgvPhanHoiKHVT
            // 
            this.dgvPhanHoiKHVT.AllowUserToAddRows = false;
            this.dgvPhanHoiKHVT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhanHoiKHVT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhanHoiKHVT.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanHoiKHVT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhanHoiKHVT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanHoiKHVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanHoiKHVT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPhanHoiKHVT.Location = new System.Drawing.Point(3, 3);
            this.dgvPhanHoiKHVT.MultiSelect = false;
            this.dgvPhanHoiKHVT.Name = "dgvPhanHoiKHVT";
            this.dgvPhanHoiKHVT.Size = new System.Drawing.Size(921, 337);
            this.dgvPhanHoiKHVT.strZone = "";
            this.dgvPhanHoiKHVT.TabIndex = 2;
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
            this.btgAccept.Location = new System.Drawing.Point(753, 378);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // frmCtDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 426);
            this.Controls.Add(this.TabPhanHoi);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmCtDT";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Chi tiết VTPT Vào - Ra cổng";
            this.TabPhanHoi.ResumeLayout(false);
            this.pageCTVTPT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoiKHVT)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage pageCTVTPT;
		private RosySystem.Control.rsTabControl TabPhanHoi;
		private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.dgvVoucher dgvPhanHoiKHVT;
	}
}

