namespace RosyModule.Inventory
{
	partial class frmKCS_View
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
			this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.txtBarcode1 = new RosySystem.Control.rsTextBox();
			this.txtBarcode2 = new RosySystem.Control.rsTextBox();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.txtNum_Lot = new RosySystem.Control.rsTextBox();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.cboGrade_ID = new RosySystem.Control.rsComboBox();
			this.cboMa_Vt = new RosySystem.Control.rsComboBox();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.cboMa_CL = new RosySystem.Control.rsComboBox();
			this.rsLabel8 = new RosySystem.Control.rsLabel();
			this.cboCa = new RosySystem.Control.rsComboBox();
			this.rsLabel9 = new RosySystem.Control.rsLabel();
			this.dgvKCS = new RosySystem.Control.rsDataGridView();
			this.btEdit_CoTinh = new RosySystem.Customize.btEdit();
			this.btFilter = new RosySystem.Customize.btFilter();
			this.rsGroupBox1 = new RosySystem.Control.rsGroupBox();
			this.rdbFilter_Edit3 = new RosySystem.Control.rsRadioButton();
			this.rdbFilter_Edit2 = new RosySystem.Control.rsRadioButton();
			this.rdbFilter_Edit1 = new RosySystem.Control.rsRadioButton();
			((System.ComponentModel.ISupportInitialize)(this.dgvKCS)).BeginInit();
			this.rsGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dteNgay_Ct1
			// 
			this.dteNgay_Ct1.bAllowEmpty = false;
			this.dteNgay_Ct1.bSelectOnFocus = false;
			this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct1.Location = new System.Drawing.Point(86, 32);
			this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct1.Mask = "00/00/0000";
			this.dteNgay_Ct1.Name = "dteNgay_Ct1";
			this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ct1.TabIndex = 1;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(15, 36);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(46, 13);
			this.rsLabel1.TabIndex = 1;
			this.rsLabel1.Text = "Từ ngày";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(262, 37);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(53, 13);
			this.rsLabel2.TabIndex = 3;
			this.rsLabel2.Text = "Đến ngày";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Ct2
			// 
			this.dteNgay_Ct2.bAllowEmpty = false;
			this.dteNgay_Ct2.bSelectOnFocus = false;
			this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct2.Location = new System.Drawing.Point(335, 34);
			this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct2.Mask = "00/00/0000";
			this.dteNgay_Ct2.Name = "dteNgay_Ct2";
			this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ct2.TabIndex = 2;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(15, 58);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(64, 13);
			this.rsLabel3.TabIndex = 4;
			this.rsLabel3.Text = "Từ mã vạch";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBarcode1
			// 
			this.txtBarcode1.Location = new System.Drawing.Point(86, 54);
			this.txtBarcode1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtBarcode1.Name = "txtBarcode1";
			this.txtBarcode1.Size = new System.Drawing.Size(160, 20);
			this.txtBarcode1.TabIndex = 3;
			// 
			// txtBarcode2
			// 
			this.txtBarcode2.Location = new System.Drawing.Point(335, 56);
			this.txtBarcode2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtBarcode2.Name = "txtBarcode2";
			this.txtBarcode2.Size = new System.Drawing.Size(160, 20);
			this.txtBarcode2.TabIndex = 4;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(262, 59);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(71, 13);
			this.rsLabel4.TabIndex = 6;
			this.rsLabel4.Text = "Đến mã vạch";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNum_Lot
			// 
			this.txtNum_Lot.Location = new System.Drawing.Point(335, 101);
			this.txtNum_Lot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNum_Lot.Name = "txtNum_Lot";
			this.txtNum_Lot.Size = new System.Drawing.Size(160, 20);
			this.txtNum_Lot.TabIndex = 8;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(262, 82);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(52, 13);
			this.rsLabel5.TabIndex = 8;
			this.rsLabel5.Text = "Mác thép";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboGrade_ID
			// 
			this.cboGrade_ID.DropDownHeight = 95;
			this.cboGrade_ID.FormattingEnabled = true;
			this.cboGrade_ID.IntegralHeight = false;
			this.cboGrade_ID.Location = new System.Drawing.Point(335, 78);
			this.cboGrade_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboGrade_ID.Name = "cboGrade_ID";
			this.cboGrade_ID.Size = new System.Drawing.Size(160, 21);
			this.cboGrade_ID.TabIndex = 6;
			// 
			// cboMa_Vt
			// 
			this.cboMa_Vt.DropDownHeight = 95;
			this.cboMa_Vt.FormattingEnabled = true;
			this.cboMa_Vt.IntegralHeight = false;
			this.cboMa_Vt.Location = new System.Drawing.Point(86, 76);
			this.cboMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_Vt.Name = "cboMa_Vt";
			this.cboMa_Vt.Size = new System.Drawing.Size(160, 21);
			this.cboMa_Vt.TabIndex = 5;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(14, 80);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(55, 13);
			this.rsLabel6.TabIndex = 11;
			this.rsLabel6.Text = "Sản phẩm";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Location = new System.Drawing.Point(262, 104);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(68, 13);
			this.rsLabel7.TabIndex = 13;
			this.rsLabel7.Text = "Lô sản phẩm";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboMa_CL
			// 
			this.cboMa_CL.DropDownHeight = 95;
			this.cboMa_CL.FormattingEnabled = true;
			this.cboMa_CL.IntegralHeight = false;
			this.cboMa_CL.Location = new System.Drawing.Point(86, 99);
			this.cboMa_CL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_CL.Name = "cboMa_CL";
			this.cboMa_CL.Size = new System.Drawing.Size(160, 21);
			this.cboMa_CL.TabIndex = 7;
			// 
			// rsLabel8
			// 
			this.rsLabel8.AutoEllipsis = true;
			this.rsLabel8.AutoSize = true;
			this.rsLabel8.Location = new System.Drawing.Point(15, 103);
			this.rsLabel8.Name = "rsLabel8";
			this.rsLabel8.Size = new System.Drawing.Size(58, 13);
			this.rsLabel8.TabIndex = 14;
			this.rsLabel8.Text = "Chất lượng";
			this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboCa
			// 
			this.cboCa.DropDownHeight = 95;
			this.cboCa.FormattingEnabled = true;
			this.cboCa.IntegralHeight = false;
			this.cboCa.Items.AddRange(new object[] {
            "",
            "A",
            "B"});
			this.cboCa.Location = new System.Drawing.Point(86, 9);
			this.cboCa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboCa.Name = "cboCa";
			this.cboCa.Size = new System.Drawing.Size(66, 21);
			this.cboCa.TabIndex = 0;
			// 
			// rsLabel9
			// 
			this.rsLabel9.AutoEllipsis = true;
			this.rsLabel9.AutoSize = true;
			this.rsLabel9.Location = new System.Drawing.Point(15, 13);
			this.rsLabel9.Name = "rsLabel9";
			this.rsLabel9.Size = new System.Drawing.Size(63, 13);
			this.rsLabel9.TabIndex = 16;
			this.rsLabel9.Text = "Ca sản xuất";
			this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgvKCS
			// 
			this.dgvKCS.AllowUserToAddRows = false;
			this.dgvKCS.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvKCS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvKCS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvKCS.BackgroundColor = System.Drawing.Color.White;
			this.dgvKCS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvKCS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKCS.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvKCS.Location = new System.Drawing.Point(3, 127);
			this.dgvKCS.MultiSelect = false;
			this.dgvKCS.Name = "dgvKCS";
			this.dgvKCS.ReadOnly = true;
			this.dgvKCS.Size = new System.Drawing.Size(971, 347);
			this.dgvKCS.strZone = "";
			this.dgvKCS.TabIndex = 9;
			// 
			// btEdit_CoTinh
			// 
			this.btEdit_CoTinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit_CoTinh.ImageKey = "Edit.png";
			this.btEdit_CoTinh.Location = new System.Drawing.Point(799, 78);
			this.btEdit_CoTinh.Name = "btEdit_CoTinh";
			this.btEdit_CoTinh.Size = new System.Drawing.Size(106, 41);
			this.btEdit_CoTinh.TabIndex = 21;
			this.btEdit_CoTinh.Tag = "";
			this.btEdit_CoTinh.Text = "Cập nhật thông tin cơ lý";
			this.btEdit_CoTinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btEdit_CoTinh.UseVisualStyleBackColor = true;
			// 
			// btFilter
			// 
			this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btFilter.ImageKey = "Filter.png";
			this.btFilter.Location = new System.Drawing.Point(690, 78);
			this.btFilter.Name = "btFilter";
			this.btFilter.Size = new System.Drawing.Size(103, 41);
			this.btFilter.TabIndex = 19;
			this.btFilter.Tag = "Filter";
			this.btFilter.Text = "&Lọc";
			this.btFilter.UseVisualStyleBackColor = true;
			// 
			// rsGroupBox1
			// 
			this.rsGroupBox1.BorderColor = System.Drawing.Color.Black;
			this.rsGroupBox1.Controls.Add(this.rdbFilter_Edit3);
			this.rsGroupBox1.Controls.Add(this.rdbFilter_Edit2);
			this.rsGroupBox1.Controls.Add(this.rdbFilter_Edit1);
			this.rsGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsGroupBox1.Location = new System.Drawing.Point(500, 34);
			this.rsGroupBox1.Name = "rsGroupBox1";
			this.rsGroupBox1.Size = new System.Drawing.Size(184, 86);
			this.rsGroupBox1.TabIndex = 22;
			this.rsGroupBox1.TabStop = false;
			this.rsGroupBox1.Text = "Điều kiện";
			// 
			// rdbFilter_Edit3
			// 
			this.rdbFilter_Edit3.AutoSize = true;
			this.rdbFilter_Edit3.Location = new System.Drawing.Point(11, 63);
			this.rdbFilter_Edit3.Name = "rdbFilter_Edit3";
			this.rdbFilter_Edit3.Size = new System.Drawing.Size(83, 17);
			this.rdbFilter_Edit3.TabIndex = 2;
			this.rdbFilter_Edit3.Text = "Lọc tất cả";
			this.rdbFilter_Edit3.UnChecked = true;
			this.rdbFilter_Edit3.UseVisualStyleBackColor = true;
			// 
			// rdbFilter_Edit2
			// 
			this.rdbFilter_Edit2.AutoSize = true;
			this.rdbFilter_Edit2.Location = new System.Drawing.Point(11, 42);
			this.rdbFilter_Edit2.Name = "rdbFilter_Edit2";
			this.rdbFilter_Edit2.Size = new System.Drawing.Size(155, 17);
			this.rdbFilter_Edit2.TabIndex = 1;
			this.rdbFilter_Edit2.Text = "Lọc sửa thông tin cơ lý";
			this.rdbFilter_Edit2.UnChecked = true;
			this.rdbFilter_Edit2.UseVisualStyleBackColor = true;
			// 
			// rdbFilter_Edit1
			// 
			this.rdbFilter_Edit1.AutoSize = true;
			this.rdbFilter_Edit1.Checked = true;
			this.rdbFilter_Edit1.Location = new System.Drawing.Point(11, 21);
			this.rdbFilter_Edit1.Name = "rdbFilter_Edit1";
			this.rdbFilter_Edit1.Size = new System.Drawing.Size(163, 17);
			this.rdbFilter_Edit1.TabIndex = 0;
			this.rdbFilter_Edit1.TabStop = true;
			this.rdbFilter_Edit1.Text = "Lọc nhập thông tin cơ lý";
			this.rdbFilter_Edit1.UnChecked = false;
			this.rdbFilter_Edit1.UseVisualStyleBackColor = true;
			// 
			// frmKCS_View
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(977, 477);
			this.Controls.Add(this.rsGroupBox1);
			this.Controls.Add(this.btEdit_CoTinh);
			this.Controls.Add(this.btFilter);
			this.Controls.Add(this.dgvKCS);
			this.Controls.Add(this.cboCa);
			this.Controls.Add(this.rsLabel9);
			this.Controls.Add(this.cboMa_CL);
			this.Controls.Add(this.rsLabel8);
			this.Controls.Add(this.rsLabel7);
			this.Controls.Add(this.cboMa_Vt);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.cboGrade_ID);
			this.Controls.Add(this.txtNum_Lot);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.txtBarcode2);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.txtBarcode1);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.dteNgay_Ct2);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.dteNgay_Ct1);
			this.Name = "frmKCS_View";
			this.Object_ID = "KCS";
			this.Text = "frmKCS";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvKCS)).EndInit();
			this.rsGroupBox1.ResumeLayout(false);
			this.rsGroupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_Ct1;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsDateTime dteNgay_Ct2;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBox txtBarcode1;
		private RosySystem.Control.rsTextBox txtBarcode2;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBox txtNum_Lot;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsComboBox cboGrade_ID;
		private RosySystem.Control.rsComboBox cboMa_Vt;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsComboBox cboMa_CL;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsComboBox cboCa;
		private RosySystem.Control.rsLabel rsLabel9;
		private RosySystem.Control.rsDataGridView dgvKCS;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Customize.btEdit btEdit_CoTinh;
		private RosySystem.Control.rsGroupBox rsGroupBox1;
		private RosySystem.Control.rsRadioButton rdbFilter_Edit2;
		private RosySystem.Control.rsRadioButton rdbFilter_Edit1;
		private RosySystem.Control.rsRadioButton rdbFilter_Edit3;
	}
}