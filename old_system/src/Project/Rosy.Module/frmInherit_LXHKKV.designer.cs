namespace RosyModule
{
    partial class frmInherit_LXHKKV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInherit_LXH));
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.lbtTen_Vt_Sp = new RosySystem.Control.rsLabel();
            this.txtSo_Ct = new System.Windows.Forms.TextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Vt_Sp = new System.Windows.Forms.TextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dgvInheritVoucher = new RosySystem.Control.rsDataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.chkInheritedExcept = new System.Windows.Forms.CheckBox();
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
            this.rsTabControl1.Location = new System.Drawing.Point(4, 4);
            this.rsTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(1171, 630);
            this.rsTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkInheritedExcept);
            this.tabPage1.Controls.Add(this.rsLabel6);
            this.tabPage1.Controls.Add(this.lblNgay_Ct);
            this.tabPage1.Controls.Add(this.dteNgay_Ct2);
            this.tabPage1.Controls.Add(this.dteNgay_Ct1);
            this.tabPage1.Controls.Add(this.lbtTen_Vt_Sp);
            this.tabPage1.Controls.Add(this.txtSo_Ct);
            this.tabPage1.Controls.Add(this.rsLabel1);
            this.tabPage1.Controls.Add(this.txtMa_Vt_Sp);
            this.tabPage1.Controls.Add(this.rsLabel5);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Controls.Add(this.dgvInheritVoucher);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1163, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chọn dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(190, 10);
            this.rsLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(69, 17);
            this.rsLabel6.TabIndex = 1023;
            this.rsLabel6.Tag = "Ngay_Ct2";
            this.rsLabel6.Text = "Đến ngày";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(8, 10);
            this.lblNgay_Ct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(60, 17);
            this.lblNgay_Ct.TabIndex = 1024;
            this.lblNgay_Ct.Tag = "Ngay_Ct1";
            this.lblNgay_Ct.Text = "Từ ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(267, 6);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Ct2.TabIndex = 1022;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(95, 6);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Ct1.TabIndex = 1021;
            // 
            // lbtTen_Vt_Sp
            // 
            this.lbtTen_Vt_Sp.AutoEllipsis = true;
            this.lbtTen_Vt_Sp.AutoSize = true;
            this.lbtTen_Vt_Sp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Sp.Location = new System.Drawing.Point(277, 43);
            this.lbtTen_Vt_Sp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_Vt_Sp.Name = "lbtTen_Vt_Sp";
            this.lbtTen_Vt_Sp.Size = new System.Drawing.Size(97, 17);
            this.lbtTen_Vt_Sp.TabIndex = 1020;
            this.lbtTen_Vt_Sp.Text = "Tên hàng hóa";
            this.lbtTen_Vt_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSo_Ct.Location = new System.Drawing.Point(417, 4);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(4);
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.Size = new System.Drawing.Size(194, 23);
            this.txtSo_Ct.TabIndex = 1018;
            this.txtSo_Ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(367, 10);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(42, 17);
            this.rsLabel1.TabIndex = 1017;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Số Ct";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt_Sp
            // 
            this.txtMa_Vt_Sp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt_Sp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMa_Vt_Sp.Location = new System.Drawing.Point(95, 36);
            this.txtMa_Vt_Sp.Margin = new System.Windows.Forms.Padding(4);
            this.txtMa_Vt_Sp.Name = "txtMa_Vt_Sp";
            this.txtMa_Vt_Sp.Size = new System.Drawing.Size(175, 23);
            this.txtMa_Vt_Sp.TabIndex = 1018;
            this.txtMa_Vt_Sp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(0, 40);
            this.rsLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(93, 17);
            this.rsLabel5.TabIndex = 1017;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Mã sản phẩm";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(1032, 4);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(123, 55);
            this.btRefresh.TabIndex = 10;
            this.btRefresh.Text = "F5 - Refresh\r\n";
            this.btRefresh.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInheritVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInheritVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInheritVoucher.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInheritVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInheritVoucher.Location = new System.Drawing.Point(4, 117);
            this.dgvInheritVoucher.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInheritVoucher.MultiSelect = false;
            this.dgvInheritVoucher.Name = "dgvInheritVoucher";
            this.dgvInheritVoucher.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInheritVoucher.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInheritVoucher.Size = new System.Drawing.Size(1152, 478);
            this.dgvInheritVoucher.strZone = "";
            this.dgvInheritVoucher.TabIndex = 11;
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
            this.btgAccept.Location = new System.Drawing.Point(928, 638);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(241, 52);
            this.btgAccept.TabIndex = 2;
            // 
            // chkInheritedExcept
            // 
            this.chkInheritedExcept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkInheritedExcept.AutoSize = true;
            this.chkInheritedExcept.Checked = true;
            this.chkInheritedExcept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInheritedExcept.Location = new System.Drawing.Point(11, 77);
            this.chkInheritedExcept.Margin = new System.Windows.Forms.Padding(4);
            this.chkInheritedExcept.Name = "chkInheritedExcept";
            this.chkInheritedExcept.Size = new System.Drawing.Size(210, 21);
            this.chkInheritedExcept.TabIndex = 1025;
            this.chkInheritedExcept.TabStop = false;
            this.chkInheritedExcept.Text = "Không lấy dữ liệu đã kế thừa";
            this.chkInheritedExcept.UseVisualStyleBackColor = true;
            // 
            // frmInherit_LXH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 697);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmInherit_LXH";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Kế thừa dữ liệu";
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl rsTabControl1;
		private RosySystem.Control.rsDataGridView dgvInheritVoucher;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsButton btRefresh;
        private System.Windows.Forms.ImageList imageList1;
        public RosySystem.Control.rsLabel lbtTen_Vt_Sp;
		public System.Windows.Forms.TextBox txtMa_Vt_Sp;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        public System.Windows.Forms.TextBox txtSo_Ct;
        private RosySystem.Control.rsLabel rsLabel1;
        private System.Windows.Forms.CheckBox chkInheritedExcept;
	}
}

