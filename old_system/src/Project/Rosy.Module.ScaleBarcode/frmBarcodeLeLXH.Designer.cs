namespace RosyModule.ScaleBarcode
{
    partial class frmBarcodeLeLXH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBarcode = new RosySystem.Control.rsDataGridView();
            this.dgvBarcode_Detail = new RosySystem.Control.rsDataGridView();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel24 = new RosySystem.Control.rsLabel();
            this.txtMa_Vt_Sp = new RosySystem.Control.rsTextBox();
            this.lbtTen_Vt_Sp = new RosySystem.Control.rsLabel();
            this.btNew = new RosySystem.Control.rsButton();
            this.btDelete = new RosySystem.Control.rsButton();
            this.btPrint = new RosySystem.Control.rsButton();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpBarcode_Detail = new System.Windows.Forms.TabPage();
            this.tpBarcode_KCS = new System.Windows.Forms.TabPage();
            this.dgvBarcode_Detail_KCS = new RosySystem.Control.rsDataGridView();
            this.chkIs_TL = new RosySystem.Control.rsCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode_Detail)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpBarcode_Detail.SuspendLayout();
            this.tpBarcode_KCS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode_Detail_KCS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBarcode
            // 
            this.dgvBarcode.AllowUserToAddRows = false;
            this.dgvBarcode.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBarcode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBarcode.BackgroundColor = System.Drawing.Color.White;
            this.dgvBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarcode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBarcode.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvBarcode.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBarcode.Location = new System.Drawing.Point(3, 72);
            this.dgvBarcode.MultiSelect = false;
            this.dgvBarcode.Name = "dgvBarcode";
            this.dgvBarcode.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarcode.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvBarcode.Size = new System.Drawing.Size(1055, 307);
            this.dgvBarcode.strZone = "";
            this.dgvBarcode.TabIndex = 9;
            // 
            // dgvBarcode_Detail
            // 
            this.dgvBarcode_Detail.AllowUserToAddRows = false;
            this.dgvBarcode_Detail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBarcode_Detail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBarcode_Detail.BackgroundColor = System.Drawing.Color.White;
            this.dgvBarcode_Detail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarcode_Detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBarcode_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBarcode_Detail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBarcode_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBarcode_Detail.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBarcode_Detail.Location = new System.Drawing.Point(3, 3);
            this.dgvBarcode_Detail.MultiSelect = false;
            this.dgvBarcode_Detail.Name = "dgvBarcode_Detail";
            this.dgvBarcode_Detail.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarcode_Detail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBarcode_Detail.Size = new System.Drawing.Size(1041, 90);
            this.dgvBarcode_Detail.strZone = "";
            this.dgvBarcode_Detail.TabIndex = 7;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(59, 28);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(76, 20);
            this.dteNgay_Ct2.TabIndex = 263;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(8, 30);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(53, 13);
            this.rsLabel2.TabIndex = 265;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Đến ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(59, 5);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(76, 20);
            this.dteNgay_Ct1.TabIndex = 262;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(8, 9);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(46, 13);
            this.rsLabel1.TabIndex = 264;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel24
            // 
            this.rsLabel24.AutoEllipsis = true;
            this.rsLabel24.AutoSize = true;
            this.rsLabel24.Location = new System.Drawing.Point(8, 53);
            this.rsLabel24.Name = "rsLabel24";
            this.rsLabel24.Size = new System.Drawing.Size(49, 13);
            this.rsLabel24.TabIndex = 268;
            this.rsLabel24.Tag = "";
            this.rsLabel24.Text = "Mã hàng";
            this.rsLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt_Sp
            // 
            this.txtMa_Vt_Sp.AutoDropDown = null;
            this.txtMa_Vt_Sp.BackColor = System.Drawing.SystemColors.Window;
            this.txtMa_Vt_Sp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt_Sp.Location = new System.Drawing.Point(59, 50);
            this.txtMa_Vt_Sp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt_Sp.MaxLength = 20;
            this.txtMa_Vt_Sp.Name = "txtMa_Vt_Sp";
            this.txtMa_Vt_Sp.Size = new System.Drawing.Size(82, 20);
            this.txtMa_Vt_Sp.TabIndex = 266;
            // 
            // lbtTen_Vt_Sp
            // 
            this.lbtTen_Vt_Sp.AutoEllipsis = true;
            this.lbtTen_Vt_Sp.AutoSize = true;
            this.lbtTen_Vt_Sp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Sp.Location = new System.Drawing.Point(146, 51);
            this.lbtTen_Vt_Sp.Name = "lbtTen_Vt_Sp";
            this.lbtTen_Vt_Sp.Size = new System.Drawing.Size(53, 13);
            this.lbtTen_Vt_Sp.TabIndex = 267;
            this.lbtTen_Vt_Sp.Text = "Tên hàng";
            this.lbtTen_Vt_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.Location = new System.Drawing.Point(5, 513);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(74, 43);
            this.btNew.TabIndex = 269;
            this.btNew.Text = "Thêm";
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.Location = new System.Drawing.Point(80, 513);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(74, 43);
            this.btDelete.TabIndex = 269;
            this.btDelete.Text = "Xóa";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrint.Location = new System.Drawing.Point(156, 513);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(74, 43);
            this.btPrint.TabIndex = 270;
            this.btPrint.Text = "In";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(415, 5);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(74, 43);
            this.btRefresh.TabIndex = 270;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpBarcode_Detail);
            this.tabControl1.Controls.Add(this.tpBarcode_KCS);
            this.tabControl1.Location = new System.Drawing.Point(3, 385);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1055, 122);
            this.tabControl1.TabIndex = 271;
            // 
            // tpBarcode_Detail
            // 
            this.tpBarcode_Detail.Controls.Add(this.dgvBarcode_Detail);
            this.tpBarcode_Detail.Location = new System.Drawing.Point(4, 22);
            this.tpBarcode_Detail.Name = "tpBarcode_Detail";
            this.tpBarcode_Detail.Padding = new System.Windows.Forms.Padding(3);
            this.tpBarcode_Detail.Size = new System.Drawing.Size(1047, 96);
            this.tpBarcode_Detail.TabIndex = 0;
            this.tpBarcode_Detail.Text = "Chi tiết barcode";
            this.tpBarcode_Detail.UseVisualStyleBackColor = true;
            // 
            // tpBarcode_KCS
            // 
            this.tpBarcode_KCS.Controls.Add(this.dgvBarcode_Detail_KCS);
            this.tpBarcode_KCS.Location = new System.Drawing.Point(4, 22);
            this.tpBarcode_KCS.Name = "tpBarcode_KCS";
            this.tpBarcode_KCS.Padding = new System.Windows.Forms.Padding(3);
            this.tpBarcode_KCS.Size = new System.Drawing.Size(1047, 96);
            this.tpBarcode_KCS.TabIndex = 1;
            this.tpBarcode_KCS.Text = "Chi tiết KCS";
            this.tpBarcode_KCS.UseVisualStyleBackColor = true;
            // 
            // dgvBarcode_Detail_KCS
            // 
            this.dgvBarcode_Detail_KCS.AllowUserToAddRows = false;
            this.dgvBarcode_Detail_KCS.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBarcode_Detail_KCS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBarcode_Detail_KCS.BackgroundColor = System.Drawing.Color.White;
            this.dgvBarcode_Detail_KCS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarcode_Detail_KCS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBarcode_Detail_KCS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBarcode_Detail_KCS.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBarcode_Detail_KCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBarcode_Detail_KCS.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBarcode_Detail_KCS.Location = new System.Drawing.Point(3, 3);
            this.dgvBarcode_Detail_KCS.MultiSelect = false;
            this.dgvBarcode_Detail_KCS.Name = "dgvBarcode_Detail_KCS";
            this.dgvBarcode_Detail_KCS.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarcode_Detail_KCS.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBarcode_Detail_KCS.Size = new System.Drawing.Size(1041, 90);
            this.dgvBarcode_Detail_KCS.strZone = "";
            this.dgvBarcode_Detail_KCS.TabIndex = 8;
            // 
            // chkIs_TL
            // 
            this.chkIs_TL.AutoSize = true;
            this.chkIs_TL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_TL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkIs_TL.Location = new System.Drawing.Point(216, 19);
            this.chkIs_TL.Name = "chkIs_TL";
            this.chkIs_TL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIs_TL.Size = new System.Drawing.Size(189, 17);
            this.chkIs_TL.TabIndex = 272;
            this.chkIs_TL.TabStop = false;
            this.chkIs_TL.Text = "Chỉ lấy những barcode trả lại";
            this.chkIs_TL.UseVisualStyleBackColor = true;
            // 
            // frmBarcodeLeLXH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 562);
            this.Controls.Add(this.chkIs_TL);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.rsLabel24);
            this.Controls.Add(this.txtMa_Vt_Sp);
            this.Controls.Add(this.lbtTen_Vt_Sp);
            this.Controls.Add(this.dteNgay_Ct2);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.dteNgay_Ct1);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.dgvBarcode);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmBarcodeLeLXH";
            this.Object_ID = "TAOBARCODELE";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "frmCreateBarcodeLe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode_Detail)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpBarcode_Detail.ResumeLayout(false);
            this.tpBarcode_KCS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode_Detail_KCS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvBarcode;
        private RosySystem.Control.rsDataGridView dgvBarcode_Detail;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel24;
        private RosySystem.Control.rsTextBox txtMa_Vt_Sp;
        private RosySystem.Control.rsLabel lbtTen_Vt_Sp;
        private RosySystem.Control.rsButton btNew;
        private RosySystem.Control.rsButton btDelete;
        private RosySystem.Control.rsButton btPrint;
        private RosySystem.Control.rsButton btRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpBarcode_Detail;
        private System.Windows.Forms.TabPage tpBarcode_KCS;
        private RosySystem.Control.rsDataGridView dgvBarcode_Detail_KCS;
        private RosySystem.Control.rsCheckbox chkIs_TL;






	}
}