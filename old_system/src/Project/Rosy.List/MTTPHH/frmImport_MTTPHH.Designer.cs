namespace RosyList
{
	partial class frmImport_MTTPHH
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport_MTTPHH));
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.rdbImport_All = new RosySystem.Control.rsRadioButton();
			this.rdbImport_Not_All_Melt = new RosySystem.Control.rsRadioButton();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.btRefresh = new RosySystem.Control.rsButton();
			this.dgvImport = new RosySystem.Control.rsDataGridView();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.numColEnd = new RosySystem.Control.rsNumericUpdown();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.numRowEnd = new RosySystem.Control.rsNumericUpdown();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numRowHeader = new RosySystem.Control.rsNumericUpdown();
			this.label2 = new RosySystem.Control.rsLabel();
			this.cboSheet = new RosySystem.Control.rsComboBox();
			this.btFilePath = new RosySystem.Control.rsButton();
			this.label1 = new RosySystem.Control.rsLabel();
			this.txtFilePath = new RosySystem.Control.txtTextBox();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.cboFile_Name = new RosySystem.Control.rsComboBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btDownload = new System.Windows.Forms.Button();
			this.tabControl1 = new RosySystem.Control.rsTabControl();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numColEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRowEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRowHeader)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.rdbImport_All);
			this.tabPage1.Controls.Add(this.rdbImport_Not_All_Melt);
			this.tabPage1.Controls.Add(this.btgAccept);
			this.tabPage1.Controls.Add(this.btRefresh);
			this.tabPage1.Controls.Add(this.dgvImport);
			this.tabPage1.Controls.Add(this.rsLabel3);
			this.tabPage1.Controls.Add(this.numColEnd);
			this.tabPage1.Controls.Add(this.rsLabel2);
			this.tabPage1.Controls.Add(this.numRowEnd);
			this.tabPage1.Controls.Add(this.rsLabel1);
			this.tabPage1.Controls.Add(this.numRowHeader);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.cboSheet);
			this.tabPage1.Controls.Add(this.btFilePath);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtFilePath);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(776, 536);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Tag = "Import";
			this.tabPage1.Text = "Import";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// rdbImport_All
			// 
			this.rdbImport_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rdbImport_All.AutoSize = true;
			this.rdbImport_All.Checked = true;
			this.rdbImport_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbImport_All.ForeColor = System.Drawing.Color.Blue;
			this.rdbImport_All.Location = new System.Drawing.Point(8, 488);
			this.rdbImport_All.Name = "rdbImport_All";
			this.rdbImport_All.Size = new System.Drawing.Size(142, 17);
			this.rdbImport_All.TabIndex = 21;
			this.rdbImport_All.TabStop = true;
			this.rdbImport_All.Text = "Import tất cả các mẽ";
			this.rdbImport_All.UnChecked = false;
			this.rdbImport_All.UseVisualStyleBackColor = true;
			// 
			// rdbImport_Not_All_Melt
			// 
			this.rdbImport_Not_All_Melt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rdbImport_Not_All_Melt.AutoSize = true;
			this.rdbImport_Not_All_Melt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbImport_Not_All_Melt.ForeColor = System.Drawing.Color.Blue;
			this.rdbImport_Not_All_Melt.Location = new System.Drawing.Point(8, 511);
			this.rdbImport_Not_All_Melt.Name = "rdbImport_Not_All_Melt";
			this.rdbImport_Not_All_Melt.Size = new System.Drawing.Size(230, 17);
			this.rdbImport_Not_All_Melt.TabIndex = 20;
			this.rdbImport_Not_All_Melt.Text = "Import các mẽ chưa có trong dữ liệu";
			this.rdbImport_Not_All_Melt.UnChecked = true;
			this.rdbImport_Not_All_Melt.UseVisualStyleBackColor = true;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btgAccept.Location = new System.Drawing.Point(590, 488);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(182, 42);
			this.btgAccept.TabIndex = 10;
			// 
			// btRefresh
			// 
			this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btRefresh.Location = new System.Drawing.Point(652, 70);
			this.btRefresh.Name = "btRefresh";
			this.btRefresh.Size = new System.Drawing.Size(120, 38);
			this.btRefresh.TabIndex = 9;
			this.btRefresh.Tag = "Refresh";
			this.btRefresh.Text = "Refresh dữ liệu";
			this.btRefresh.UseVisualStyleBackColor = true;
			// 
			// dgvImport
			// 
			this.dgvImport.AllowUserToAddRows = false;
			this.dgvImport.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvImport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvImport.BackgroundColor = System.Drawing.Color.White;
			this.dgvImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvImport.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvImport.Location = new System.Drawing.Point(1, 112);
			this.dgvImport.MultiSelect = false;
			this.dgvImport.Name = "dgvImport";
			this.dgvImport.ReadOnly = true;
			this.dgvImport.Size = new System.Drawing.Size(772, 370);
			this.dgvImport.strZone = "";
			this.dgvImport.TabIndex = 8;
			// 
			// rsLabel3
			// 
			this.rsLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(115, 92);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(137, 13);
			this.rsLabel3.TabIndex = 18;
			this.rsLabel3.Tag = "Col_Import_Range";
			this.rsLabel3.Text = "Vị trí giới hạn cột lấy dữ liệu";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numColEnd
			// 
			this.numColEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.numColEnd.Location = new System.Drawing.Point(257, 89);
			this.numColEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numColEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numColEnd.Name = "numColEnd";
			this.numColEnd.Size = new System.Drawing.Size(64, 20);
			this.numColEnd.TabIndex = 7;
			// 
			// rsLabel2
			// 
			this.rsLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(106, 70);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(146, 13);
			this.rsLabel2.TabIndex = 16;
			this.rsLabel2.Tag = "Row_Import_Range";
			this.rsLabel2.Text = "Vị trí giới hạn dòng lấy dữ liệu";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numRowEnd
			// 
			this.numRowEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.numRowEnd.Location = new System.Drawing.Point(257, 67);
			this.numRowEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numRowEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numRowEnd.Name = "numRowEnd";
			this.numRowEnd.Size = new System.Drawing.Size(64, 20);
			this.numRowEnd.TabIndex = 6;
			// 
			// rsLabel1
			// 
			this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(384, 48);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(92, 13);
			this.rsLabel1.TabIndex = 4;
			this.rsLabel1.Tag = "Header_Position";
			this.rsLabel1.Text = "Vị trí dòng tiêu đề";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numRowHeader
			// 
			this.numRowHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.numRowHeader.Location = new System.Drawing.Point(481, 45);
			this.numRowHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numRowHeader.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numRowHeader.Name = "numRowHeader";
			this.numRowHeader.Size = new System.Drawing.Size(48, 20);
			this.numRowHeader.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoEllipsis = true;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Sheet";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboSheet
			// 
			this.cboSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSheet.Enabled = false;
			this.cboSheet.Location = new System.Drawing.Point(109, 45);
			this.cboSheet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboSheet.Name = "cboSheet";
			this.cboSheet.Size = new System.Drawing.Size(212, 21);
			this.cboSheet.TabIndex = 3;
			// 
			// btFilePath
			// 
			this.btFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btFilePath.Location = new System.Drawing.Point(533, 22);
			this.btFilePath.Name = "btFilePath";
			this.btFilePath.Size = new System.Drawing.Size(24, 21);
			this.btFilePath.TabIndex = 2;
			this.btFilePath.Text = "...";
			this.btFilePath.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoEllipsis = true;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 0;
			this.label1.Tag = "File_Path";
			this.label1.Text = "Đường dẫn file";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFilePath
			// 
			this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtFilePath.bEnabled = true;
			this.txtFilePath.bReadOnly = false;
			this.txtFilePath.Location = new System.Drawing.Point(109, 23);
			this.txtFilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtFilePath.Name = "txtFilePath";
			this.txtFilePath.Size = new System.Drawing.Size(420, 20);
			this.txtFilePath.TabIndex = 1;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(27, 20);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(65, 13);
			this.rsLabel4.TabIndex = 0;
			this.rsLabel4.Tag = "File_Name";
			this.rsLabel4.Text = "Tên file mẫu";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboFile_Name
			// 
			this.cboFile_Name.Location = new System.Drawing.Point(97, 17);
			this.cboFile_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboFile_Name.Name = "cboFile_Name";
			this.cboFile_Name.Size = new System.Drawing.Size(151, 21);
			this.cboFile_Name.TabIndex = 1;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.rsLabel4);
			this.tabPage2.Controls.Add(this.cboFile_Name);
			this.tabPage2.Controls.Add(this.btDownload);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(776, 536);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Tag = "Download_File_Templ";
			this.tabPage2.Text = "Download file mẫu";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btDownload
			// 
			this.btDownload.Image = ((System.Drawing.Image)(resources.GetObject("btDownload.Image")));
			this.btDownload.Location = new System.Drawing.Point(253, 17);
			this.btDownload.Name = "btDownload";
			this.btDownload.Size = new System.Drawing.Size(72, 49);
			this.btDownload.TabIndex = 2;
			this.btDownload.Text = "Download";
			this.btDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btDownload.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(784, 562);
			this.tabControl1.TabIndex = 1;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "excel.png");
			this.imageList1.Images.SetKeyName(1, "excel8.png");
			// 
			// frmImport_MTTPHH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmImport_MTTPHH";
			this.Text = "frmImport_MTTPHH";
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numColEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRowEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRowHeader)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsButton btRefresh;
		private RosySystem.Control.rsDataGridView dgvImport;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsNumericUpdown numColEnd;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsNumericUpdown numRowEnd;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsNumericUpdown numRowHeader;
		private RosySystem.Control.rsLabel label2;
		private RosySystem.Control.rsComboBox cboSheet;
		private RosySystem.Control.rsButton btFilePath;
		private RosySystem.Control.rsLabel label1;
		private RosySystem.Control.txtTextBox txtFilePath;
		private RosySystem.Control.rsLabel rsLabel4;
		private System.Windows.Forms.Button btDownload;
		private RosySystem.Control.rsComboBox cboFile_Name;
		private System.Windows.Forms.TabPage tabPage2;
		private RosySystem.Control.rsTabControl tabControl1;
		private System.Windows.Forms.ImageList imageList1;
		public RosySystem.Control.rsRadioButton rdbImport_All;
		public RosySystem.Control.rsRadioButton rdbImport_Not_All_Melt;
	}
}