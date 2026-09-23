namespace RosyModule
{
    partial class frmCtXBarcodePT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCtXBarcodePT));
            this.txtTime_Clock = new System.Windows.Forms.Timer(this.components);
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.rsLabel26 = new RosySystem.Control.rsLabel();
            this.dgvEditCt = new RosySystem.Customize.dgvVoucher();
            this.txtDien_Giai = new RosySystem.Control.rsTextBox();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.lblOng_Ba = new RosySystem.Control.rsLabel();
            this.txtOng_Ba = new RosySystem.Control.rsTextBox();
            this.lblMa_Dt = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.txtSo_Ct = new RosySystem.Control.rsTextBox();
            this.lblSo_Ct = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.rsGroupBox1 = new RosySystem.Control.rsGroupBox();
            this.btSave_Voucher = new RosySystem.Customize.btFilter();
            this.btPrint = new RosySystem.Customize.btPrint();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt)).BeginInit();
            this.rsGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTime_Clock
            // 
            this.txtTime_Clock.Enabled = true;
            this.txtTime_Clock.Interval = 1000;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBarcode.Location = new System.Drawing.Point(110, 124);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(327, 60);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel26
            // 
            this.rsLabel26.AutoEllipsis = true;
            this.rsLabel26.AutoSize = true;
            this.rsLabel26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel26.Location = new System.Drawing.Point(19, 143);
            this.rsLabel26.Name = "rsLabel26";
            this.rsLabel26.Size = new System.Drawing.Size(88, 24);
            this.rsLabel26.TabIndex = 246;
            this.rsLabel26.Tag = "";
            this.rsLabel26.Text = "Mã vạch";
            this.rsLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvEditCt
            // 
            this.dgvEditCt.AllowUserToAddRows = false;
            this.dgvEditCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEditCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEditCt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEditCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvEditCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEditCt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEditCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEditCt.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvEditCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEditCt.Location = new System.Drawing.Point(12, 190);
            this.dgvEditCt.MultiSelect = false;
            this.dgvEditCt.Name = "dgvEditCt";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEditCt.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEditCt.Size = new System.Drawing.Size(1166, 324);
            this.dgvEditCt.strZone = "";
            this.dgvEditCt.TabIndex = 3;
            // 
            // txtDien_Giai
            // 
            this.txtDien_Giai.AutoDropDown = null;
            this.txtDien_Giai.BackColor = System.Drawing.SystemColors.Info;
            this.txtDien_Giai.Location = new System.Drawing.Point(109, 84);
            this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDien_Giai.MaxLength = 200;
            this.txtDien_Giai.Name = "txtDien_Giai";
            this.txtDien_Giai.Size = new System.Drawing.Size(500, 21);
            this.txtDien_Giai.TabIndex = 9;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(14, 87);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(65, 15);
            this.lblDien_Giai.TabIndex = 208;
            this.lblDien_Giai.Tag = "Dien_Giai";
            this.lblDien_Giai.Text = "Diễn giải";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOng_Ba
            // 
            this.lblOng_Ba.AutoEllipsis = true;
            this.lblOng_Ba.AutoSize = true;
            this.lblOng_Ba.Location = new System.Drawing.Point(14, 64);
            this.lblOng_Ba.Name = "lblOng_Ba";
            this.lblOng_Ba.Size = new System.Drawing.Size(53, 15);
            this.lblOng_Ba.TabIndex = 206;
            this.lblOng_Ba.Tag = "Ong_Ba";
            this.lblOng_Ba.Text = "Ông bà";
            this.lblOng_Ba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOng_Ba
            // 
            this.txtOng_Ba.AutoDropDown = null;
            this.txtOng_Ba.BackColor = System.Drawing.SystemColors.Info;
            this.txtOng_Ba.Location = new System.Drawing.Point(109, 61);
            this.txtOng_Ba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtOng_Ba.MaxLength = 100;
            this.txtOng_Ba.Name = "txtOng_Ba";
            this.txtOng_Ba.Size = new System.Drawing.Size(229, 21);
            this.txtOng_Ba.TabIndex = 6;
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.Location = new System.Drawing.Point(14, 42);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(69, 15);
            this.lblMa_Dt.TabIndex = 205;
            this.lblMa_Dt.Tag = "Ma_Dt";
            this.lblMa_Dt.Text = "Đối tượng";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.BackColor = System.Drawing.SystemColors.Info;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(109, 39);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(82, 21);
            this.txtMa_Dt.TabIndex = 5;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(198, 42);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(95, 15);
            this.lbtTen_Dt.TabIndex = 204;
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.AutoDropDown = null;
            this.txtSo_Ct.BackColor = System.Drawing.SystemColors.Info;
            this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct.Location = new System.Drawing.Point(283, 16);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct.MaxLength = 20;
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.ReadOnly = true;
            this.txtSo_Ct.Size = new System.Drawing.Size(93, 21);
            this.txtSo_Ct.TabIndex = 2;
            // 
            // lblSo_Ct
            // 
            this.lblSo_Ct.AutoEllipsis = true;
            this.lblSo_Ct.AutoSize = true;
            this.lblSo_Ct.Location = new System.Drawing.Point(218, 19);
            this.lblSo_Ct.Name = "lblSo_Ct";
            this.lblSo_Ct.Size = new System.Drawing.Size(64, 15);
            this.lblSo_Ct.TabIndex = 55;
            this.lblSo_Ct.Tag = "";
            this.lblSo_Ct.Text = "Số phiếu";
            this.lblSo_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(14, 20);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(56, 15);
            this.lblNgay_Ct.TabIndex = 52;
            this.lblNgay_Ct.Tag = "Ngay_Ct";
            this.lblNgay_Ct.Text = "Ngày Ct";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.BackColor = System.Drawing.SystemColors.Info;
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(109, 16);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.ReadOnly = true;
            this.dteNgay_Ct.Size = new System.Drawing.Size(82, 21);
            this.dteNgay_Ct.TabIndex = 1;
            // 
            // rsGroupBox1
            // 
            this.rsGroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.rsGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.rsGroupBox1.Controls.Add(this.dteNgay_Ct);
            this.rsGroupBox1.Controls.Add(this.lblNgay_Ct);
            this.rsGroupBox1.Controls.Add(this.lblSo_Ct);
            this.rsGroupBox1.Controls.Add(this.txtSo_Ct);
            this.rsGroupBox1.Controls.Add(this.lbtTen_Dt);
            this.rsGroupBox1.Controls.Add(this.txtMa_Dt);
            this.rsGroupBox1.Controls.Add(this.lblMa_Dt);
            this.rsGroupBox1.Controls.Add(this.txtOng_Ba);
            this.rsGroupBox1.Controls.Add(this.lblOng_Ba);
            this.rsGroupBox1.Controls.Add(this.lblDien_Giai);
            this.rsGroupBox1.Controls.Add(this.txtDien_Giai);
            this.rsGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsGroupBox1.Location = new System.Drawing.Point(1, 0);
            this.rsGroupBox1.Name = "rsGroupBox1";
            this.rsGroupBox1.Size = new System.Drawing.Size(1174, 118);
            this.rsGroupBox1.TabIndex = 2;
            this.rsGroupBox1.TabStop = false;
            this.rsGroupBox1.Text = "Thông tin chung";
            // 
            // btSave_Voucher
            // 
            this.btSave_Voucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave_Voucher.Enabled = false;
            this.btSave_Voucher.Image = ((System.Drawing.Image)(resources.GetObject("btSave_Voucher.Image")));
            this.btSave_Voucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave_Voucher.ImageKey = "Filter.png";
            this.btSave_Voucher.Location = new System.Drawing.Point(996, 520);
            this.btSave_Voucher.Name = "btSave_Voucher";
            this.btSave_Voucher.Size = new System.Drawing.Size(88, 40);
            this.btSave_Voucher.TabIndex = 4;
            this.btSave_Voucher.Tag = "";
            this.btSave_Voucher.Text = "  Lưu";
            this.btSave_Voucher.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "Print.png";
            this.btPrint.Location = new System.Drawing.Point(1090, 520);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(88, 40);
            this.btPrint.TabIndex = 5;
            this.btPrint.Tag = "Print";
            this.btPrint.Text = "&In phiếu";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // frmCtXBarcodePT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 562);
            this.ControlBox = false;
            this.Controls.Add(this.btSave_Voucher);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.rsGroupBox1);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.rsLabel26);
            this.Controls.Add(this.dgvEditCt);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCtXBarcodePT";
            this.Object_ID = "CTX_BARCODE_PT";
            this.ShowInTaskbar = true;
            this.Text = "frmCTXBarcodePT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt)).EndInit();
            this.rsGroupBox1.ResumeLayout(false);
            this.rsGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Timer txtTime_Clock;
		private RosySystem.Customize.btFilter btSave_Voucher;
        private System.Windows.Forms.TextBox txtBarcode;
		private RosySystem.Customize.btPrint btPrint;
		private RosySystem.Control.rsLabel rsLabel26;
        private RosySystem.Customize.dgvVoucher dgvEditCt;
        private RosySystem.Control.rsTextBox txtDien_Giai;
        private RosySystem.Control.rsLabel lblDien_Giai;
        private RosySystem.Control.rsLabel lblOng_Ba;
        private RosySystem.Control.rsTextBox txtOng_Ba;
        private RosySystem.Control.rsLabel lblMa_Dt;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Control.rsLabel lbtTen_Dt;
        private RosySystem.Control.rsTextBox txtSo_Ct;
        private RosySystem.Control.rsLabel lblSo_Ct;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsGroupBox rsGroupBox1;


	}
}