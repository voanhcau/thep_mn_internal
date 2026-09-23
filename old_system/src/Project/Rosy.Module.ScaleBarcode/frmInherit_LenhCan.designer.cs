namespace RosyModule.ScaleBarcode
{
    partial class frmInherit_LenhCan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInherit_LenhCan));
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkInherit_TTCH = new RosySystem.Control.rsCheckbox();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.lblMa_Dt = new RosySystem.Control.rsLabel();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.dgvInheritVoucher = new RosySystem.Control.rsDataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.rsTabControl1.Size = new System.Drawing.Size(908, 512);
            this.rsTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkInherit_TTCH);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Controls.Add(this.txtMa_Dt);
            this.tabPage1.Controls.Add(this.lblMa_Dt);
            this.tabPage1.Controls.Add(this.lbtTen_Dt);
            this.tabPage1.Controls.Add(this.rsLabel1);
            this.tabPage1.Controls.Add(this.lblNgay_Ct);
            this.tabPage1.Controls.Add(this.dteNgay_Ct2);
            this.tabPage1.Controls.Add(this.dteNgay_Ct1);
            this.tabPage1.Controls.Add(this.dgvInheritVoucher);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(900, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chọn dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkInherit_TTCH
            // 
            this.chkInherit_TTCH.AutoSize = true;
            this.chkInherit_TTCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInherit_TTCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkInherit_TTCH.Location = new System.Drawing.Point(277, 4);
            this.chkInherit_TTCH.Name = "chkInherit_TTCH";
            this.chkInherit_TTCH.Size = new System.Drawing.Size(207, 20);
            this.chkInherit_TTCH.TabIndex = 62;
            this.chkInherit_TTCH.Text = "Kế thừa thông tin cân hàng";
            this.chkInherit_TTCH.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(277, 23);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(92, 31);
            this.btRefresh.TabIndex = 7;
            this.btRefresh.Text = "F5 - Refresh\r\n";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(68, 33);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 4;
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.Location = new System.Drawing.Point(11, 36);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(53, 13);
            this.lblMa_Dt.TabIndex = 61;
            this.lblMa_Dt.Tag = "Ma_Dt";
            this.lblMa_Dt.Text = "Đối tượng";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(193, 37);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(74, 13);
            this.lbtTen_Dt.TabIndex = 3;
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(138, 10);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(53, 13);
            this.rsLabel1.TabIndex = 54;
            this.rsLabel1.Tag = "Ngay_Ct2";
            this.rsLabel1.Text = "Đến ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(11, 10);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct.TabIndex = 54;
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
            this.dteNgay_Ct2.Location = new System.Drawing.Point(196, 7);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 2;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(67, 7);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct1.TabIndex = 1;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInheritVoucher.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInheritVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInheritVoucher.Location = new System.Drawing.Point(3, 60);
            this.dgvInheritVoucher.MultiSelect = false;
            this.dgvInheritVoucher.Name = "dgvInheritVoucher";
            this.dgvInheritVoucher.ReadOnly = true;
            this.dgvInheritVoucher.Size = new System.Drawing.Size(894, 423);
            this.dgvInheritVoucher.strZone = "";
            this.dgvInheritVoucher.TabIndex = 8;
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
            this.btgAccept.Location = new System.Drawing.Point(726, 518);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // frmInherit_LenhCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 566);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmInherit_LenhCan";
            this.Padding = new System.Windows.Forms.Padding(3);
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
		private RosySystem.Control.rsLabel lblNgay_Ct;
		private RosySystem.Control.rsDateTime dteNgay_Ct1;
		private RosySystem.Control.rsTextBox txtMa_Dt;
		private RosySystem.Control.rsLabel lblMa_Dt;
        private RosySystem.Control.rsLabel lbtTen_Dt;
        private RosySystem.Control.rsButton btRefresh;
        private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsCheckbox chkInherit_TTCH;
    }
}

