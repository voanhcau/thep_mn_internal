namespace RosyModule
{
    partial class frmUpdate_ThongTin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdate_ThongTin));
            this.TabPhanHoi = new RosySystem.Control.rsTabControl();
            this.pageUpdate_ThongTin = new System.Windows.Forms.TabPage();
            this.dgvUpdate_ThongTin = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.TabPhanHoi.SuspendLayout();
            this.pageUpdate_ThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdate_ThongTin)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPhanHoi
            // 
            this.TabPhanHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPhanHoi.Controls.Add(this.pageUpdate_ThongTin);
            this.TabPhanHoi.Location = new System.Drawing.Point(3, 6);
            this.TabPhanHoi.Name = "TabPhanHoi";
            this.TabPhanHoi.SelectedIndex = 0;
            this.TabPhanHoi.Size = new System.Drawing.Size(1131, 509);
            this.TabPhanHoi.TabIndex = 0;
            // 
            // pageUpdate_ThongTin
            // 
            this.pageUpdate_ThongTin.Controls.Add(this.dgvUpdate_ThongTin);
            this.pageUpdate_ThongTin.Location = new System.Drawing.Point(4, 22);
            this.pageUpdate_ThongTin.Name = "pageUpdate_ThongTin";
            this.pageUpdate_ThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.pageUpdate_ThongTin.Size = new System.Drawing.Size(1123, 483);
            this.pageUpdate_ThongTin.TabIndex = 0;
            this.pageUpdate_ThongTin.Text = "Chi tiết cập nhật thông tin";
            this.pageUpdate_ThongTin.UseVisualStyleBackColor = true;
            // 
            // dgvUpdate_ThongTin
            // 
            this.dgvUpdate_ThongTin.AllowUserToAddRows = false;
            this.dgvUpdate_ThongTin.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUpdate_ThongTin.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUpdate_ThongTin.BackgroundColor = System.Drawing.Color.White;
            this.dgvUpdate_ThongTin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUpdate_ThongTin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdate_ThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpdate_ThongTin.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvUpdate_ThongTin.Location = new System.Drawing.Point(3, 3);
            this.dgvUpdate_ThongTin.MultiSelect = false;
            this.dgvUpdate_ThongTin.Name = "dgvUpdate_ThongTin";
            this.dgvUpdate_ThongTin.Size = new System.Drawing.Size(1117, 477);
            this.dgvUpdate_ThongTin.strZone = "";
            this.dgvUpdate_ThongTin.TabIndex = 2;
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
            this.btgAccept.Location = new System.Drawing.Point(949, 518);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // frmUpdate_ThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 566);
            this.Controls.Add(this.TabPhanHoi);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmUpdate_ThongTin";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Chi tiết phản hồi";
            this.TabPhanHoi.ResumeLayout(false);
            this.pageUpdate_ThongTin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdate_ThongTin)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage pageUpdate_ThongTin;
		private RosySystem.Control.rsTabControl TabPhanHoi;
		private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.dgvVoucher dgvUpdate_ThongTin;
	}
}

