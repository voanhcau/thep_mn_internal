namespace RosyModule
{
    partial class frmReadExcel_ToFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadExcel_ToFrom));
            this.tabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.numFromRow = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.numToRow = new RosySystem.Control.rsNumericUpdown();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dgvImport = new RosySystem.Control.rsDataGridView();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.numColEnd = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.numRowHeader = new RosySystem.Control.rsNumericUpdown();
            this.label2 = new RosySystem.Control.rsLabel();
            this.cboSheet = new RosySystem.Control.rsComboBox();
            this.btFilePath = new RosySystem.Control.rsButton();
            this.label1 = new RosySystem.Control.rsLabel();
            this.txtFilePath = new RosySystem.Control.txtTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.btDownload = new System.Windows.Forms.Button();
            this.cboFile_Name = new RosySystem.Control.rsComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFromRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowHeader)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1048, 689);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rsLabel6);
            this.tabPage1.Controls.Add(this.numFromRow);
            this.tabPage1.Controls.Add(this.rsLabel5);
            this.tabPage1.Controls.Add(this.numToRow);
            this.tabPage1.Controls.Add(this.btgAccept);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Controls.Add(this.dgvImport);
            this.tabPage1.Controls.Add(this.rsLabel3);
            this.tabPage1.Controls.Add(this.numColEnd);
            this.tabPage1.Controls.Add(this.rsLabel1);
            this.tabPage1.Controls.Add(this.numRowHeader);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboSheet);
            this.tabPage1.Controls.Add(this.btFilePath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtFilePath);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1040, 660);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "Import";
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rsLabel6
            // 
            this.rsLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(537, 57);
            this.rsLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(119, 17);
            this.rsLabel6.TabIndex = 22;
            this.rsLabel6.Tag = "Header_Position";
            this.rsLabel6.Text = "Vị trí dòng tiêu đề";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numFromRow
            // 
            this.numFromRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numFromRow.Location = new System.Drawing.Point(660, 84);
            this.numFromRow.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numFromRow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numFromRow.Name = "numFromRow";
            this.numFromRow.Size = new System.Drawing.Size(51, 22);
            this.numFromRow.TabIndex = 21;
            // 
            // rsLabel5
            // 
            this.rsLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(586, 111);
            this.rsLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(70, 17);
            this.rsLabel5.TabIndex = 19;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Đến dòng";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numToRow
            // 
            this.numToRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numToRow.Location = new System.Drawing.Point(660, 109);
            this.numToRow.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numToRow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numToRow.Name = "numToRow";
            this.numToRow.Size = new System.Drawing.Size(51, 22);
            this.numToRow.TabIndex = 20;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btgAccept.Location = new System.Drawing.Point(787, 598);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(243, 52);
            this.btgAccept.TabIndex = 10;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(872, 106);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(160, 27);
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
            this.dgvImport.BackgroundColor = System.Drawing.Color.White;
            this.dgvImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImport.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvImport.Location = new System.Drawing.Point(1, 138);
            this.dgvImport.Margin = new System.Windows.Forms.Padding(4);
            this.dgvImport.MultiSelect = false;
            this.dgvImport.Name = "dgvImport";
            this.dgvImport.ReadOnly = true;
            this.dgvImport.Size = new System.Drawing.Size(1029, 453);
            this.dgvImport.strZone = "";
            this.dgvImport.TabIndex = 8;
            // 
            // rsLabel3
            // 
            this.rsLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(188, 84);
            this.rsLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(181, 17);
            this.rsLabel3.TabIndex = 18;
            this.rsLabel3.Tag = "Col_Import_Range";
            this.rsLabel3.Text = "Vị trí giới hạn cột lấy dữ liệu";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numColEnd
            // 
            this.numColEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numColEnd.Location = new System.Drawing.Point(377, 80);
            this.numColEnd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numColEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numColEnd.Name = "numColEnd";
            this.numColEnd.Size = new System.Drawing.Size(51, 22);
            this.numColEnd.TabIndex = 7;
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(595, 85);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(61, 17);
            this.rsLabel1.TabIndex = 4;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Từ dòng";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numRowHeader
            // 
            this.numRowHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numRowHeader.Location = new System.Drawing.Point(660, 53);
            this.numRowHeader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numRowHeader.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRowHeader.Name = "numRowHeader";
            this.numRowHeader.Size = new System.Drawing.Size(51, 22);
            this.numRowHeader.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sheet";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSheet
            // 
            this.cboSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSheet.Enabled = false;
            this.cboSheet.Location = new System.Drawing.Point(145, 53);
            this.cboSheet.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(281, 24);
            this.cboSheet.TabIndex = 3;
            // 
            // btFilePath
            // 
            this.btFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btFilePath.Location = new System.Drawing.Point(711, 23);
            this.btFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.btFilePath.Name = "btFilePath";
            this.btFilePath.Size = new System.Drawing.Size(32, 27);
            this.btFilePath.TabIndex = 2;
            this.btFilePath.Text = "...";
            this.btFilePath.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
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
            this.txtFilePath.Location = new System.Drawing.Point(145, 26);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(559, 22);
            this.txtFilePath.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rsLabel4);
            this.tabPage2.Controls.Add(this.btDownload);
            this.tabPage2.Controls.Add(this.cboFile_Name);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1040, 660);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "Download_File_Templ";
            this.tabPage2.Text = "Download file mẫu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(36, 25);
            this.rsLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(86, 17);
            this.rsLabel4.TabIndex = 0;
            this.rsLabel4.Tag = "File_Name";
            this.rsLabel4.Text = "Tên file mẫu";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btDownload
            // 
            this.btDownload.Image = ((System.Drawing.Image)(resources.GetObject("btDownload.Image")));
            this.btDownload.Location = new System.Drawing.Point(337, 21);
            this.btDownload.Margin = new System.Windows.Forms.Padding(4);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(96, 60);
            this.btDownload.TabIndex = 2;
            this.btDownload.Text = "Download";
            this.btDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDownload.UseVisualStyleBackColor = true;
            // 
            // cboFile_Name
            // 
            this.cboFile_Name.Location = new System.Drawing.Point(129, 21);
            this.cboFile_Name.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.cboFile_Name.Name = "cboFile_Name";
            this.cboFile_Name.Size = new System.Drawing.Size(200, 24);
            this.cboFile_Name.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "excel.png");
            this.imageList1.Images.SetKeyName(1, "excel8.png");
            // 
            // frmReadExcel_ToFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 697);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmReadExcel_ToFrom";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "frmImportExcel";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFromRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowHeader)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsTabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsButton btFilePath;
		private RosySystem.Control.rsLabel label1;
		private RosySystem.Control.txtTextBox txtFilePath;
		private RosySystem.Control.rsLabel label2;
        private RosySystem.Control.rsComboBox cboSheet;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsNumericUpdown numRowHeader;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsNumericUpdown numColEnd;
		private RosySystem.Control.rsDataGridView dgvImport;
		private RosySystem.Control.rsButton btRefresh;
		private RosySystem.Customize.btgAccept btgAccept;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabPage tabPage2;
		private RosySystem.Control.rsComboBox cboFile_Name;
		private RosySystem.Control.rsLabel rsLabel4;
		private System.Windows.Forms.Button btDownload;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsNumericUpdown numToRow;
        private RosySystem.Control.rsNumericUpdown numFromRow;
        private RosySystem.Control.rsLabel rsLabel6;
	}
}