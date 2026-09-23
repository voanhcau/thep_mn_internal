namespace RosyModule
{
	partial class frmCheck_Gia_Mua
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheck_Gia_Mua));
			this.rsTabControl1 = new RosySystem.Control.rsTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dgvCheck_Gia = new RosySystem.Customize.dgvVoucher();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.rsTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCheck_Gia)).BeginInit();
			this.SuspendLayout();
			// 
			// rsTabControl1
			// 
			this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rsTabControl1.Controls.Add(this.tabPage1);
			this.rsTabControl1.Location = new System.Drawing.Point(3, 6);
			this.rsTabControl1.Name = "rsTabControl1";
			this.rsTabControl1.SelectedIndex = 0;
			this.rsTabControl1.Size = new System.Drawing.Size(1131, 509);
			this.rsTabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgvCheck_Gia);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1123, 483);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Chi tiết duyệt đề nghị";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dgvCheck_Gia
			// 
			this.dgvCheck_Gia.AllowUserToAddRows = false;
			this.dgvCheck_Gia.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvCheck_Gia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvCheck_Gia.BackgroundColor = System.Drawing.Color.White;
			this.dgvCheck_Gia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvCheck_Gia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCheck_Gia.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCheck_Gia.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvCheck_Gia.Location = new System.Drawing.Point(3, 3);
			this.dgvCheck_Gia.MultiSelect = false;
			this.dgvCheck_Gia.Name = "dgvCheck_Gia";
			this.dgvCheck_Gia.Size = new System.Drawing.Size(1117, 477);
			this.dgvCheck_Gia.strZone = "";
			this.dgvCheck_Gia.TabIndex = 1;
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
			// frmCheck_Gia_Mua
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1137, 566);
			this.Controls.Add(this.rsTabControl1);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmCheck_Gia_Mua";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Chi tiết duyệt đề nghị";
			this.rsTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCheck_Gia)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl rsTabControl1;
		private RosySystem.Customize.btgAccept btgAccept;
		private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Customize.dgvVoucher dgvCheck_Gia;
	}
}

