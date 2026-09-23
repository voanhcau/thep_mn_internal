namespace RosyModule.Payable
{
	partial class frmAdd_HD_DT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdd_HD_DT));
            this.TabPhanHoi = new RosySystem.Control.rsTabControl();
            this.pgCtDT = new System.Windows.Forms.TabPage();
            this.dgvCtDt = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.TabPhanHoi.SuspendLayout();
            this.pgCtDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtDt)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPhanHoi
            // 
            this.TabPhanHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPhanHoi.Controls.Add(this.pgCtDT);
            this.TabPhanHoi.Location = new System.Drawing.Point(3, 6);
            this.TabPhanHoi.Name = "TabPhanHoi";
            this.TabPhanHoi.SelectedIndex = 0;
            this.TabPhanHoi.Size = new System.Drawing.Size(1131, 509);
            this.TabPhanHoi.TabIndex = 0;
            // 
            // pgCtDT
            // 
            this.pgCtDT.Controls.Add(this.dgvCtDt);
            this.pgCtDT.Location = new System.Drawing.Point(4, 22);
            this.pgCtDT.Name = "pgCtDT";
            this.pgCtDT.Padding = new System.Windows.Forms.Padding(3);
            this.pgCtDT.Size = new System.Drawing.Size(1123, 483);
            this.pgCtDT.TabIndex = 0;
            this.pgCtDT.Text = "Chi tiết dự trù";
            this.pgCtDT.UseVisualStyleBackColor = true;
            // 
            // dgvCtDt
            // 
            this.dgvCtDt.AllowUserToAddRows = false;
            this.dgvCtDt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtDt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCtDt.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtDt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtDt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtDt.Location = new System.Drawing.Point(3, 3);
            this.dgvCtDt.MultiSelect = false;
            this.dgvCtDt.Name = "dgvCtDt";
            this.dgvCtDt.Size = new System.Drawing.Size(1117, 477);
            this.dgvCtDt.strZone = "";
            this.dgvCtDt.TabIndex = 2;
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
            // frmAdd_HD_DT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 566);
            this.Controls.Add(this.TabPhanHoi);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmAdd_HD_DT";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Chi tiết dự trù";
            this.TabPhanHoi.ResumeLayout(false);
            this.pgCtDT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtDt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage pgCtDT;
		private RosySystem.Control.rsTabControl TabPhanHoi;
		private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.dgvVoucher dgvCtDt;
	}
}

