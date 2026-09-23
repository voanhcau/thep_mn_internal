namespace RosyModule.Inventory
{
	partial class frmLocked_Phoi
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocked_Phoi));
			this.lvNam = new RosySystem.Control.rsListView();
			this.dgvLocked_Barcode = new RosySystem.Control.rsDataGridView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.dgvLocked_Barcode)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvNam
			// 
			this.lvNam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.lvNam.DataSource = null;
			this.lvNam.FullRowSelect = true;
			this.lvNam.HideSelection = false;
			this.lvNam.Location = new System.Drawing.Point(12, 12);
			this.lvNam.Name = "lvNam";
			this.lvNam.Size = new System.Drawing.Size(108, 374);
			this.lvNam.strZone = "";
			this.lvNam.TabIndex = 0;
			this.lvNam.UseCompatibleStateImageBehavior = false;
			this.lvNam.View = System.Windows.Forms.View.Details;
			// 
			// dgvLocked_Barcode
			// 
			this.dgvLocked_Barcode.AllowUserToAddRows = false;
			this.dgvLocked_Barcode.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvLocked_Barcode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvLocked_Barcode.BackgroundColor = System.Drawing.Color.White;
			this.dgvLocked_Barcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvLocked_Barcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLocked_Barcode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvLocked_Barcode.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvLocked_Barcode.Location = new System.Drawing.Point(3, 3);
			this.dgvLocked_Barcode.MultiSelect = false;
			this.dgvLocked_Barcode.Name = "dgvLocked_Barcode";
			this.dgvLocked_Barcode.ReadOnly = true;
			this.dgvLocked_Barcode.RowHeadersWidth = 20;
			this.dgvLocked_Barcode.Size = new System.Drawing.Size(344, 342);
			this.dgvLocked_Barcode.strZone = "";
			this.dgvLocked_Barcode.TabIndex = 2;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "calendar.png");
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(126, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(358, 374);
			this.tabControl1.TabIndex = 4;
			this.tabControl1.TabStop = false;
			this.tabControl1.Tag = "";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgvLocked_Barcode);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(350, 348);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Tag = "";
			this.tabPage1.Text = "Khóa dữ liệu phôi";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// frmLocked_Phoi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 398);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lvNam);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLocked_Phoi";
			this.Tag = "frmLocked_Phoi";
			this.Text = "frmLocked_Phoi";
			((System.ComponentModel.ISupportInitialize)(this.dgvLocked_Barcode)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsListView lvNam;
		private RosySystem.Control.rsDataGridView dgvLocked_Barcode;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;


	}
}