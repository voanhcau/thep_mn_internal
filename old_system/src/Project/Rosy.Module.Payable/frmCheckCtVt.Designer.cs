namespace RosyModule.Payable
{
	partial class frmCheckCtVt
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckCtVt));
			this.rsTabControl1 = new RosySystem.Control.rsTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btRefresh = new RosySystem.Control.rsButton();
			this.txtMa_Vt = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.lbtTen_Vt = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.lblNgay_Ct = new RosySystem.Control.rsLabel();
			this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
			this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
			this.dgvInheritVoucher = new RosySystem.Control.rsDataGridView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.lbtNotice = new RosySystem.Control.rsLabel();
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
			this.rsTabControl1.Size = new System.Drawing.Size(878, 512);
			this.rsTabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btRefresh);
			this.tabPage1.Controls.Add(this.txtMa_Vt);
			this.tabPage1.Controls.Add(this.rsLabel2);
			this.tabPage1.Controls.Add(this.lbtNotice);
			this.tabPage1.Controls.Add(this.lbtTen_Vt);
			this.tabPage1.Controls.Add(this.rsLabel1);
			this.tabPage1.Controls.Add(this.lblNgay_Ct);
			this.tabPage1.Controls.Add(this.dteNgay_Ct2);
			this.tabPage1.Controls.Add(this.dteNgay_Ct1);
			this.tabPage1.Controls.Add(this.dgvInheritVoucher);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(870, 486);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Chọn dữ liệu";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btRefresh
			// 
			this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btRefresh.Location = new System.Drawing.Point(772, 6);
			this.btRefresh.Name = "btRefresh";
			this.btRefresh.Size = new System.Drawing.Size(92, 52);
			this.btRefresh.TabIndex = 3;
			this.btRefresh.Text = "F5 - Refresh\r\n";
			this.btRefresh.UseVisualStyleBackColor = true;
			// 
			// txtMa_Vt
			// 
			this.txtMa_Vt.AutoDropDown = null;
			this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Vt.Location = new System.Drawing.Point(97, 38);
			this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt.MaxLength = 20;
			this.txtMa_Vt.Name = "txtMa_Vt";
			this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Vt.TabIndex = 2;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(24, 41);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(52, 13);
			this.rsLabel2.TabIndex = 61;
			this.rsLabel2.Tag = "Ma_Vt";
			this.rsLabel2.Text = "Mặt hàng";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Vt
			// 
			this.lbtTen_Vt.AutoEllipsis = true;
			this.lbtTen_Vt.AutoSize = true;
			this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Vt.Location = new System.Drawing.Point(222, 42);
			this.lbtTen_Vt.Name = "lbtTen_Vt";
			this.lbtTen_Vt.Size = new System.Drawing.Size(73, 13);
			this.lbtTen_Vt.TabIndex = 3;
			this.lbtTen_Vt.Text = "Tên mặt hàng";
			this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(141, 8);
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
			this.lblNgay_Ct.Location = new System.Drawing.Point(19, 8);
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
			this.dteNgay_Ct2.Location = new System.Drawing.Point(199, 8);
			this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct2.Mask = "00/00/0000";
			this.dteNgay_Ct2.Name = "dteNgay_Ct2";
			this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ct2.TabIndex = 1;
			// 
			// dteNgay_Ct1
			// 
			this.dteNgay_Ct1.bAllowEmpty = true;
			this.dteNgay_Ct1.bSelectOnFocus = false;
			this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct1.Location = new System.Drawing.Point(71, 8);
			this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct1.Mask = "00/00/0000";
			this.dteNgay_Ct1.Name = "dteNgay_Ct1";
			this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ct1.TabIndex = 0;
			// 
			// dgvInheritVoucher
			// 
			this.dgvInheritVoucher.AllowUserToAddRows = false;
			this.dgvInheritVoucher.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvInheritVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvInheritVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInheritVoucher.BackgroundColor = System.Drawing.Color.White;
			this.dgvInheritVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvInheritVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvInheritVoucher.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvInheritVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvInheritVoucher.Location = new System.Drawing.Point(3, 64);
			this.dgvInheritVoucher.MultiSelect = false;
			this.dgvInheritVoucher.Name = "dgvInheritVoucher";
			this.dgvInheritVoucher.ReadOnly = true;
			this.dgvInheritVoucher.Size = new System.Drawing.Size(864, 419);
			this.dgvInheritVoucher.strZone = "";
			this.dgvInheritVoucher.TabIndex = 13;
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
			this.btgAccept.Location = new System.Drawing.Point(696, 518);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			this.btgAccept.TabIndex = 2;
			// 
			// lbtNotice
			// 
			this.lbtNotice.AutoEllipsis = true;
			this.lbtNotice.AutoSize = true;
			this.lbtNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbtNotice.ForeColor = System.Drawing.Color.Purple;
			this.lbtNotice.Location = new System.Drawing.Point(281, 9);
			this.lbtNotice.Name = "lbtNotice";
			this.lbtNotice.Size = new System.Drawing.Size(95, 15);
			this.lbtNotice.TabIndex = 3;
			this.lbtNotice.Text = "Tên mặt hàng";
			this.lbtNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmCheckCtVt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 566);
			this.Controls.Add(this.rsTabControl1);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmCheckCtVt";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "Check Chi tiết vật tư";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
		private RosySystem.Control.rsButton btRefresh;
		private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Control.rsTextBox txtMa_Vt;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel lbtTen_Vt;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsDateTime dteNgay_Ct2;
		private RosySystem.Control.rsLabel lbtNotice;
	}
}

