namespace RosyModule
{
    partial class XulyTonKhoBarcode
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatVTriKho));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.rsTabControl1 = new RosySystem.Control.rsTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dgvInheritVoucher = new RosySystem.Control.rsDataGridView();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.rsTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).BeginInit();
			this.SuspendLayout();
			// 
			// rsTabControl1
			// 
			this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rsTabControl1.Controls.Add(this.tabPage1);
			this.rsTabControl1.Location = new System.Drawing.Point(3, 3);
			this.rsTabControl1.Name = "rsTabControl1";
			this.rsTabControl1.SelectedIndex = 0;
			this.rsTabControl1.Size = new System.Drawing.Size(878, 512);
			this.rsTabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgvInheritVoucher);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(870, 486);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Chọn dữ liệu";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "viewmag.png");
			// 
			// dgvInheritVoucher
			// 
			this.dgvInheritVoucher.AllowUserToAddRows = false;
			this.dgvInheritVoucher.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvInheritVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvInheritVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInheritVoucher.BackgroundColor = System.Drawing.Color.White;
			this.dgvInheritVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvInheritVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvInheritVoucher.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvInheritVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvInheritVoucher.Location = new System.Drawing.Point(3, 0);
			this.dgvInheritVoucher.MultiSelect = false;
			this.dgvInheritVoucher.Name = "dgvInheritVoucher";
			this.dgvInheritVoucher.ReadOnly = true;
			this.dgvInheritVoucher.Size = new System.Drawing.Size(864, 483);
			this.dgvInheritVoucher.strZone = "";
			this.dgvInheritVoucher.TabIndex = 13;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(696, 518);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			this.btgAccept.TabIndex = 2;
			// 
			// frmXuatVTriKho
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 566);
			this.Controls.Add(this.rsTabControl1);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmXuatVTriKho";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "Xuất vị trí kho";
			this.rsTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl rsTabControl1;
		private RosySystem.Control.rsDataGridView dgvInheritVoucher;
		private RosySystem.Customize.btgAccept btgAccept;
		private System.Windows.Forms.ImageList imageList1;
	}
}

