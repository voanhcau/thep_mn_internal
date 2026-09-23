namespace RosyModule.General
{
	partial class frmReadExcel_KT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadExcel_KT));
            this.tabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtObject = new RosySystem.Control.rsTextBoxEnum();
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
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.label1 = new RosySystem.Control.rsLabel();
            this.txtFilePath = new RosySystem.Control.txtTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cboObject = new RosySystem.Control.rsComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cboObject);
            this.tabPage1.Controls.Add(this.txtObject);
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
            this.tabPage1.Controls.Add(this.rsLabel4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtFilePath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "Import";
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtObject
            // 
            this.txtObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObject.AutoDropDown = null;
            this.txtObject.InputMask = "";
            this.txtObject.Location = new System.Drawing.Point(707, 17);
            this.txtObject.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtObject.Name = "txtObject";
            this.txtObject.Size = new System.Drawing.Size(53, 20);
            this.txtObject.TabIndex = 19;
            this.txtObject.Text = "MA_KM";
            this.txtObject.Visible = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btgAccept.Location = new System.Drawing.Point(590, 486);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(182, 42);
            this.btgAccept.TabIndex = 10;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(654, 86);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(120, 22);
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
            this.dgvImport.Location = new System.Drawing.Point(1, 112);
            this.dgvImport.MultiSelect = false;
            this.dgvImport.Name = "dgvImport";
            this.dgvImport.ReadOnly = true;
            this.dgvImport.Size = new System.Drawing.Size(772, 368);
            this.dgvImport.strZone = "";
            this.dgvImport.TabIndex = 8;
            // 
            // rsLabel3
            // 
            this.rsLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(141, 90);
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
            this.numColEnd.Location = new System.Drawing.Point(283, 87);
            this.numColEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numColEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numColEnd.Name = "numColEnd";
            this.numColEnd.Size = new System.Drawing.Size(38, 20);
            this.numColEnd.TabIndex = 7;
            // 
            // rsLabel2
            // 
            this.rsLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(132, 68);
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
            this.numRowEnd.Location = new System.Drawing.Point(283, 65);
            this.numRowEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numRowEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRowEnd.Name = "numRowEnd";
            this.numRowEnd.Size = new System.Drawing.Size(38, 20);
            this.numRowEnd.TabIndex = 6;
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(396, 46);
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
            this.numRowHeader.Location = new System.Drawing.Point(491, 43);
            this.numRowHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numRowHeader.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRowHeader.Name = "numRowHeader";
            this.numRowHeader.Size = new System.Drawing.Size(38, 20);
            this.numRowHeader.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 46);
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
            this.cboSheet.Location = new System.Drawing.Point(109, 43);
            this.cboSheet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(212, 21);
            this.cboSheet.TabIndex = 3;
            // 
            // btFilePath
            // 
            this.btFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btFilePath.Location = new System.Drawing.Point(533, 19);
            this.btFilePath.Name = "btFilePath";
            this.btFilePath.Size = new System.Drawing.Size(24, 22);
            this.btFilePath.TabIndex = 2;
            this.btFilePath.Text = "...";
            this.btFilePath.UseVisualStyleBackColor = true;
            // 
            // rsLabel4
            // 
            this.rsLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(563, 24);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(38, 13);
            this.rsLabel4.TabIndex = 0;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Object";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
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
            this.txtFilePath.Location = new System.Drawing.Point(109, 21);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(420, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "excel.png");
            this.imageList1.Images.SetKeyName(1, "excel8.png");
            // 
            // cboObject
            // 
            this.cboObject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboObject.DropDownHeight = 147;
            this.cboObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboObject.FormattingEnabled = true;
            this.cboObject.IntegralHeight = false;
            this.cboObject.Location = new System.Drawing.Point(606, 17);
            this.cboObject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboObject.Name = "cboObject";
            this.cboObject.Size = new System.Drawing.Size(118, 21);
            this.cboObject.TabIndex = 20;
            // 
            // frmReadExcel_KT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmReadExcel_KT";
            this.Object_ID = "IMPCTKT";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmImportExcel_KT";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowHeader)).EndInit();
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
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsNumericUpdown numRowEnd;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBoxEnum txtObject;
        private RosySystem.Control.rsComboBox cboObject;
    }
}