namespace RosyModule
{
	partial class frmKQCalLaiGop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQCalLaiGop));
            this.TabPhanHoi = new RosySystem.Control.rsTabControl();
            this.pagePhanHoiKHVT = new System.Windows.Forms.TabPage();
            this.dgvKQLaiGop = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.TabPhanHoi.SuspendLayout();
            this.pagePhanHoiKHVT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQLaiGop)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPhanHoi
            // 
            this.TabPhanHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPhanHoi.Controls.Add(this.pagePhanHoiKHVT);
            this.TabPhanHoi.Location = new System.Drawing.Point(3, 6);
            this.TabPhanHoi.Name = "TabPhanHoi";
            this.TabPhanHoi.SelectedIndex = 0;
            this.TabPhanHoi.Size = new System.Drawing.Size(1213, 652);
            this.TabPhanHoi.TabIndex = 0;
            // 
            // pagePhanHoiKHVT
            // 
            this.pagePhanHoiKHVT.Controls.Add(this.dgvKQLaiGop);
            this.pagePhanHoiKHVT.Location = new System.Drawing.Point(4, 22);
            this.pagePhanHoiKHVT.Name = "pagePhanHoiKHVT";
            this.pagePhanHoiKHVT.Padding = new System.Windows.Forms.Padding(3);
            this.pagePhanHoiKHVT.Size = new System.Drawing.Size(1205, 626);
            this.pagePhanHoiKHVT.TabIndex = 0;
            this.pagePhanHoiKHVT.Text = "Lãi gộp theo ngày";
            this.pagePhanHoiKHVT.UseVisualStyleBackColor = true;
            // 
            // dgvKQLaiGop
            // 
            this.dgvKQLaiGop.AllowUserToAddRows = false;
            this.dgvKQLaiGop.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKQLaiGop.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKQLaiGop.BackgroundColor = System.Drawing.Color.White;
            this.dgvKQLaiGop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKQLaiGop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQLaiGop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKQLaiGop.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKQLaiGop.Location = new System.Drawing.Point(3, 3);
            this.dgvKQLaiGop.MultiSelect = false;
            this.dgvKQLaiGop.Name = "dgvKQLaiGop";
            this.dgvKQLaiGop.Size = new System.Drawing.Size(1199, 620);
            this.dgvKQLaiGop.strZone = "";
            this.dgvKQLaiGop.TabIndex = 2;
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
            this.btgAccept.Location = new System.Drawing.Point(1031, 610);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // frmKQCalLaiGop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 658);
            this.Controls.Add(this.TabPhanHoi);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmKQCalLaiGop";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Kết quả lãi gộp";
            this.TabPhanHoi.ResumeLayout(false);
            this.pagePhanHoiKHVT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQLaiGop)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage pagePhanHoiKHVT;
		private RosySystem.Control.rsTabControl TabPhanHoi;
		private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.dgvVoucher dgvKQLaiGop;
    }
}

