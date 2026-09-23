namespace RosyModule
{
    partial class frmImportAccess
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportAccess));
			this.rsTabControl1 = new RosySystem.Control.rsTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.chkPhoi_Nguoi = new RosySystem.Control.rsCheckbox();
			this.chkPhoi_TG = new RosySystem.Control.rsCheckbox();
			this.chkPhoi_Nong = new RosySystem.Control.rsCheckbox();
			this.cbxTable_Name = new RosySystem.Control.rsComboBox();
			this.lbtNgay_Ct2 = new RosySystem.Control.rsLabel();
			this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
			this.btConnect = new RosySystem.Control.rsButton();
			this.btOpenDialog = new RosySystem.Control.rsButton();
			this.btRefresh = new RosySystem.Control.rsButton();
			this.txtMe2 = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtMe1 = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.txtCa2 = new RosySystem.Control.rsTextBox();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.txtCa1 = new RosySystem.Control.rsTextBox();
			this.lblMa_Dt = new RosySystem.Control.rsLabel();
			this.lblNgay_Ct1 = new RosySystem.Control.rsLabel();
			this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
			this.lbtTable_Name = new RosySystem.Control.rsLabel();
			this.txtFile_Path = new RosySystem.Control.rsTextBox();
			this.lbtFile_Path = new RosySystem.Control.rsLabel();
			this.dgvImportAccess = new RosySystem.Control.rsDataGridView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.chkInheritedExcept = new System.Windows.Forms.CheckBox();
			this.chkInheritOverwrite = new System.Windows.Forms.CheckBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.rsTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImportAccess)).BeginInit();
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
			this.rsTabControl1.Size = new System.Drawing.Size(786, 512);
			this.rsTabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.chkPhoi_Nguoi);
			this.tabPage1.Controls.Add(this.chkPhoi_TG);
			this.tabPage1.Controls.Add(this.chkPhoi_Nong);
			this.tabPage1.Controls.Add(this.cbxTable_Name);
			this.tabPage1.Controls.Add(this.lbtNgay_Ct2);
			this.tabPage1.Controls.Add(this.dteNgay_Ct2);
			this.tabPage1.Controls.Add(this.btConnect);
			this.tabPage1.Controls.Add(this.btOpenDialog);
			this.tabPage1.Controls.Add(this.btRefresh);
			this.tabPage1.Controls.Add(this.txtMe2);
			this.tabPage1.Controls.Add(this.rsLabel1);
			this.tabPage1.Controls.Add(this.txtMe1);
			this.tabPage1.Controls.Add(this.rsLabel2);
			this.tabPage1.Controls.Add(this.txtCa2);
			this.tabPage1.Controls.Add(this.rsLabel3);
			this.tabPage1.Controls.Add(this.txtCa1);
			this.tabPage1.Controls.Add(this.lblMa_Dt);
			this.tabPage1.Controls.Add(this.lblNgay_Ct1);
			this.tabPage1.Controls.Add(this.dteNgay_Ct1);
			this.tabPage1.Controls.Add(this.lbtTable_Name);
			this.tabPage1.Controls.Add(this.txtFile_Path);
			this.tabPage1.Controls.Add(this.lbtFile_Path);
			this.tabPage1.Controls.Add(this.dgvImportAccess);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(778, 486);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Chọn dữ liệu";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// chkPhoi_Nguoi
			// 
			this.chkPhoi_Nguoi.AutoSize = true;
			this.chkPhoi_Nguoi.Location = new System.Drawing.Point(458, 131);
			this.chkPhoi_Nguoi.Name = "chkPhoi_Nguoi";
			this.chkPhoi_Nguoi.Size = new System.Drawing.Size(76, 17);
			this.chkPhoi_Nguoi.TabIndex = 64;
			this.chkPhoi_Nguoi.Text = "Phôi ra bãi";
			this.chkPhoi_Nguoi.UseVisualStyleBackColor = true;
			// 
			// chkPhoi_TG
			// 
			this.chkPhoi_TG.AutoSize = true;
			this.chkPhoi_TG.Location = new System.Drawing.Point(251, 131);
			this.chkPhoi_TG.Name = "chkPhoi_TG";
			this.chkPhoi_TG.Size = new System.Drawing.Size(118, 17);
			this.chkPhoi_TG.TabIndex = 64;
			this.chkPhoi_TG.Text = "Phôi nạp trung gian";
			this.chkPhoi_TG.UseVisualStyleBackColor = true;
			// 
			// chkPhoi_Nong
			// 
			this.chkPhoi_Nong.AutoSize = true;
			this.chkPhoi_Nong.Location = new System.Drawing.Point(25, 131);
			this.chkPhoi_Nong.Name = "chkPhoi_Nong";
			this.chkPhoi_Nong.Size = new System.Drawing.Size(95, 17);
			this.chkPhoi_Nong.TabIndex = 64;
			this.chkPhoi_Nong.Text = "Phôi nạp nóng";
			this.chkPhoi_Nong.UseVisualStyleBackColor = true;
			// 
			// cbxTable_Name
			// 
			this.cbxTable_Name.FormattingEnabled = true;
			this.cbxTable_Name.Location = new System.Drawing.Point(114, 35);
			this.cbxTable_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cbxTable_Name.Name = "cbxTable_Name";
			this.cbxTable_Name.Size = new System.Drawing.Size(462, 21);
			this.cbxTable_Name.TabIndex = 3;
			// 
			// lbtNgay_Ct2
			// 
			this.lbtNgay_Ct2.AutoEllipsis = true;
			this.lbtNgay_Ct2.AutoSize = true;
			this.lbtNgay_Ct2.Location = new System.Drawing.Point(248, 63);
			this.lbtNgay_Ct2.Name = "lbtNgay_Ct2";
			this.lbtNgay_Ct2.Size = new System.Drawing.Size(53, 13);
			this.lbtNgay_Ct2.TabIndex = 63;
			this.lbtNgay_Ct2.Tag = "Ngay_Ct2";
			this.lbtNgay_Ct2.Text = "Đến ngày";
			this.lbtNgay_Ct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Ct2
			// 
			this.dteNgay_Ct2.bAllowEmpty = true;
			this.dteNgay_Ct2.bSelectOnFocus = false;
			this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct2.Location = new System.Drawing.Point(338, 60);
			this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct2.Mask = "00/00/0000";
			this.dteNgay_Ct2.Name = "dteNgay_Ct2";
			this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ct2.TabIndex = 6;
			// 
			// btConnect
			// 
			this.btConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btConnect.ImageKey = "viewmag.png";
			this.btConnect.Location = new System.Drawing.Point(584, 29);
			this.btConnect.Name = "btConnect";
			this.btConnect.Size = new System.Drawing.Size(75, 30);
			this.btConnect.TabIndex = 4;
			this.btConnect.TabStop = false;
			this.btConnect.Text = "Connect";
			this.btConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btConnect.UseVisualStyleBackColor = true;
			// 
			// btOpenDialog
			// 
			this.btOpenDialog.ImageKey = "viewmag.png";
			this.btOpenDialog.Location = new System.Drawing.Point(584, 5);
			this.btOpenDialog.Name = "btOpenDialog";
			this.btOpenDialog.Size = new System.Drawing.Size(27, 23);
			this.btOpenDialog.TabIndex = 2;
			this.btOpenDialog.TabStop = false;
			this.btOpenDialog.Text = "...";
			this.btOpenDialog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btOpenDialog.UseVisualStyleBackColor = true;
			// 
			// btRefresh
			// 
			this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btRefresh.Location = new System.Drawing.Point(698, 6);
			this.btRefresh.Name = "btRefresh";
			this.btRefresh.Size = new System.Drawing.Size(74, 52);
			this.btRefresh.TabIndex = 11;
			this.btRefresh.Text = "Refresh\r\nF5";
			this.btRefresh.UseVisualStyleBackColor = true;
			// 
			// txtMe2
			// 
			this.txtMe2.AutoDropDown = null;
			this.txtMe2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMe2.Location = new System.Drawing.Point(338, 105);
			this.txtMe2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMe2.MaxLength = 20;
			this.txtMe2.Name = "txtMe2";
			this.txtMe2.Size = new System.Drawing.Size(66, 20);
			this.txtMe2.TabIndex = 10;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(248, 108);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(44, 13);
			this.rsLabel1.TabIndex = 61;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Đến mẻ";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMe1
			// 
			this.txtMe1.AutoDropDown = null;
			this.txtMe1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMe1.Location = new System.Drawing.Point(114, 105);
			this.txtMe1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMe1.MaxLength = 20;
			this.txtMe1.Name = "txtMe1";
			this.txtMe1.Size = new System.Drawing.Size(66, 20);
			this.txtMe1.TabIndex = 9;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(22, 108);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(37, 13);
			this.rsLabel2.TabIndex = 61;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "Từ mẻ";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCa2
			// 
			this.txtCa2.AutoDropDown = null;
			this.txtCa2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCa2.Location = new System.Drawing.Point(338, 83);
			this.txtCa2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtCa2.MaxLength = 20;
			this.txtCa2.Name = "txtCa2";
			this.txtCa2.Size = new System.Drawing.Size(66, 20);
			this.txtCa2.TabIndex = 8;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(248, 86);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(42, 13);
			this.rsLabel3.TabIndex = 61;
			this.rsLabel3.Tag = "";
			this.rsLabel3.Text = "Đến ca";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCa1
			// 
			this.txtCa1.AutoDropDown = null;
			this.txtCa1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCa1.Location = new System.Drawing.Point(114, 83);
			this.txtCa1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtCa1.MaxLength = 20;
			this.txtCa1.Name = "txtCa1";
			this.txtCa1.Size = new System.Drawing.Size(66, 20);
			this.txtCa1.TabIndex = 7;
			// 
			// lblMa_Dt
			// 
			this.lblMa_Dt.AutoEllipsis = true;
			this.lblMa_Dt.AutoSize = true;
			this.lblMa_Dt.Location = new System.Drawing.Point(22, 86);
			this.lblMa_Dt.Name = "lblMa_Dt";
			this.lblMa_Dt.Size = new System.Drawing.Size(35, 13);
			this.lblMa_Dt.TabIndex = 61;
			this.lblMa_Dt.Tag = "";
			this.lblMa_Dt.Text = "Từ ca";
			this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblNgay_Ct1
			// 
			this.lblNgay_Ct1.AutoEllipsis = true;
			this.lblNgay_Ct1.AutoSize = true;
			this.lblNgay_Ct1.Location = new System.Drawing.Point(22, 63);
			this.lblNgay_Ct1.Name = "lblNgay_Ct1";
			this.lblNgay_Ct1.Size = new System.Drawing.Size(46, 13);
			this.lblNgay_Ct1.TabIndex = 54;
			this.lblNgay_Ct1.Tag = "Ngay_Ct1";
			this.lblNgay_Ct1.Text = "Từ ngày";
			this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Ct1
			// 
			this.dteNgay_Ct1.bAllowEmpty = true;
			this.dteNgay_Ct1.bSelectOnFocus = false;
			this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct1.Location = new System.Drawing.Point(114, 60);
			this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct1.Mask = "00/00/0000";
			this.dteNgay_Ct1.Name = "dteNgay_Ct1";
			this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ct1.TabIndex = 5;
			// 
			// lbtTable_Name
			// 
			this.lbtTable_Name.AutoEllipsis = true;
			this.lbtTable_Name.AutoSize = true;
			this.lbtTable_Name.Location = new System.Drawing.Point(22, 38);
			this.lbtTable_Name.Name = "lbtTable_Name";
			this.lbtTable_Name.Size = new System.Drawing.Size(87, 13);
			this.lbtTable_Name.TabIndex = 53;
			this.lbtTable_Name.Tag = "";
			this.lbtTable_Name.Text = "Tên bảng dữ liệu";
			this.lbtTable_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFile_Path
			// 
			this.txtFile_Path.AutoDropDown = null;
			this.txtFile_Path.Location = new System.Drawing.Point(114, 6);
			this.txtFile_Path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtFile_Path.MaxLength = 20;
			this.txtFile_Path.Name = "txtFile_Path";
			this.txtFile_Path.Size = new System.Drawing.Size(462, 20);
			this.txtFile_Path.TabIndex = 1;
			// 
			// lbtFile_Path
			// 
			this.lbtFile_Path.AutoEllipsis = true;
			this.lbtFile_Path.AutoSize = true;
			this.lbtFile_Path.Location = new System.Drawing.Point(22, 10);
			this.lbtFile_Path.Name = "lbtFile_Path";
			this.lbtFile_Path.Size = new System.Drawing.Size(76, 13);
			this.lbtFile_Path.TabIndex = 53;
			this.lbtFile_Path.Tag = "";
			this.lbtFile_Path.Text = "Đường dẫn file";
			this.lbtFile_Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgvImportAccess
			// 
			this.dgvImportAccess.AllowUserToAddRows = false;
			this.dgvImportAccess.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvImportAccess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvImportAccess.BackgroundColor = System.Drawing.Color.White;
			this.dgvImportAccess.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvImportAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvImportAccess.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvImportAccess.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvImportAccess.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvImportAccess.Location = new System.Drawing.Point(3, 154);
			this.dgvImportAccess.MultiSelect = false;
			this.dgvImportAccess.Name = "dgvImportAccess";
			this.dgvImportAccess.ReadOnly = true;
			this.dgvImportAccess.Size = new System.Drawing.Size(772, 329);
			this.dgvImportAccess.strZone = "";
			this.dgvImportAccess.TabIndex = 8;
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
			this.btgAccept.Location = new System.Drawing.Point(604, 518);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			this.btgAccept.TabIndex = 2;
			// 
			// chkInheritedExcept
			// 
			this.chkInheritedExcept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkInheritedExcept.AutoSize = true;
			this.chkInheritedExcept.Checked = true;
			this.chkInheritedExcept.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkInheritedExcept.Location = new System.Drawing.Point(10, 521);
			this.chkInheritedExcept.Name = "chkInheritedExcept";
			this.chkInheritedExcept.Size = new System.Drawing.Size(162, 17);
			this.chkInheritedExcept.TabIndex = 0;
			this.chkInheritedExcept.TabStop = false;
			this.chkInheritedExcept.Text = "Không lấy dữ liệu đã kế thừa";
			this.chkInheritedExcept.UseVisualStyleBackColor = true;
			// 
			// chkInheritOverwrite
			// 
			this.chkInheritOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkInheritOverwrite.AutoSize = true;
			this.chkInheritOverwrite.Location = new System.Drawing.Point(10, 543);
			this.chkInheritOverwrite.Name = "chkInheritOverwrite";
			this.chkInheritOverwrite.Size = new System.Drawing.Size(152, 17);
			this.chkInheritOverwrite.TabIndex = 1;
			this.chkInheritOverwrite.TabStop = false;
			this.chkInheritOverwrite.Text = "Ghi đè dữ liệu kế thừa vào";
			this.chkInheritOverwrite.UseVisualStyleBackColor = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// frmImportAccess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.chkInheritOverwrite);
			this.Controls.Add(this.chkInheritedExcept);
			this.Controls.Add(this.rsTabControl1);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmImportAccess";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "ImportAccess";
			this.rsTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImportAccess)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl rsTabControl1;
		private RosySystem.Control.rsDataGridView dgvImportAccess;
        private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel lblNgay_Ct1;
		private RosySystem.Control.rsDateTime dteNgay_Ct1;
		private RosySystem.Control.rsTextBox txtCa1;
        private RosySystem.Control.rsLabel lblMa_Dt;
        private RosySystem.Control.rsButton btRefresh;
		public System.Windows.Forms.CheckBox chkInheritOverwrite;
        private System.Windows.Forms.CheckBox chkInheritedExcept;
		private RosySystem.Control.rsTextBox txtMe1;
        private RosySystem.Control.rsLabel rsLabel2;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Control.rsTextBox txtFile_Path;
        private RosySystem.Control.rsLabel lbtFile_Path;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private RosySystem.Control.rsButton btOpenDialog;
        private RosySystem.Control.rsLabel lbtTable_Name;
        private RosySystem.Control.rsLabel lbtNgay_Ct2;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsTextBox txtMe2;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtCa2;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsButton btConnect;
        private RosySystem.Control.rsComboBox cbxTable_Name;
        public RosySystem.Control.rsCheckbox chkPhoi_TG;
        public RosySystem.Control.rsCheckbox chkPhoi_Nong;
        public RosySystem.Control.rsCheckbox chkPhoi_Nguoi;
	}
}

