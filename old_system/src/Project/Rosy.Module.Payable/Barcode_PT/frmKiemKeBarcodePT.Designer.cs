namespace RosyModule.Payable
{
    partial class frmKiemKeBarcodePT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKiemKeBarcodePT));
            this.txtTime_Clock = new System.Windows.Forms.Timer(this.components);
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.rsLabel26 = new RosySystem.Control.rsLabel();
            this.dgvEditCt = new RosySystem.Customize.dgvVoucher();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.btRefresh = new RosySystem.Customize.btPrint();
            this.rsGroupBox2 = new RosySystem.Control.rsGroupBox();
            this.btThem = new RosySystem.Customize.btFilter();
            this.btExit = new RosySystem.Customize.btFilter();
            this.btSave = new RosySystem.Customize.btFilter();
            this.dteNgay_Kk = new RosySystem.Control.rsDateTime();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.btSua = new RosySystem.Customize.btFilter();
            this.btXoa = new RosySystem.Customize.btFilter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt)).BeginInit();
            this.rsGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTime_Clock
            // 
            this.txtTime_Clock.Enabled = true;
            this.txtTime_Clock.Interval = 1000;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBarcode.Location = new System.Drawing.Point(289, 18);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(327, 60);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel26
            // 
            this.rsLabel26.AutoEllipsis = true;
            this.rsLabel26.AutoSize = true;
            this.rsLabel26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel26.Location = new System.Drawing.Point(197, 37);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEditCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEditCt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEditCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvEditCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEditCt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEditCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEditCt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEditCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEditCt.Location = new System.Drawing.Point(12, 107);
            this.dgvEditCt.MultiSelect = false;
            this.dgvEditCt.Name = "dgvEditCt";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEditCt.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEditCt.Size = new System.Drawing.Size(1131, 454);
            this.dgvEditCt.strZone = "";
            this.dgvEditCt.TabIndex = 3;
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(852, 12);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(53, 13);
            this.rsLabel1.TabIndex = 226;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteNgay_Ct1.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(938, 8);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(76, 20);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(1018, 12);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(109, 26);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "F9 - Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // rsGroupBox2
            // 
            this.rsGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.rsGroupBox2.Controls.Add(this.btXoa);
            this.rsGroupBox2.Controls.Add(this.btSua);
            this.rsGroupBox2.Controls.Add(this.btThem);
            this.rsGroupBox2.Controls.Add(this.btExit);
            this.rsGroupBox2.Controls.Add(this.btSave);
            this.rsGroupBox2.Controls.Add(this.dteNgay_Kk);
            this.rsGroupBox2.Controls.Add(this.rsLabel3);
            this.rsGroupBox2.Controls.Add(this.dteNgay_Ct2);
            this.rsGroupBox2.Controls.Add(this.rsLabel2);
            this.rsGroupBox2.Controls.Add(this.btRefresh);
            this.rsGroupBox2.Controls.Add(this.dteNgay_Ct1);
            this.rsGroupBox2.Controls.Add(this.txtBarcode);
            this.rsGroupBox2.Controls.Add(this.rsLabel1);
            this.rsGroupBox2.Controls.Add(this.rsLabel26);
            this.rsGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsGroupBox2.Location = new System.Drawing.Point(10, 1);
            this.rsGroupBox2.Name = "rsGroupBox2";
            this.rsGroupBox2.Size = new System.Drawing.Size(1133, 100);
            this.rsGroupBox2.TabIndex = 0;
            this.rsGroupBox2.TabStop = false;
            this.rsGroupBox2.Text = "Điều kiện lọc";
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThem.ImageKey = "(none)";
            this.btThem.Location = new System.Drawing.Point(684, 54);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(88, 40);
            this.btThem.TabIndex = 249;
            this.btThem.Tag = "";
            this.btThem.Text = " Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "(none)";
            this.btExit.Location = new System.Drawing.Point(1039, 54);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(88, 40);
            this.btExit.TabIndex = 249;
            this.btExit.Tag = "";
            this.btExit.Text = " Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageKey = "Filter.png";
            this.btSave.Location = new System.Drawing.Point(950, 54);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(88, 40);
            this.btSave.TabIndex = 249;
            this.btSave.Tag = "";
            this.btSave.Text = "  Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Kk
            // 
            this.dteNgay_Kk.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Kk.bAllowEmpty = false;
            this.dteNgay_Kk.bSelectOnFocus = false;
            this.dteNgay_Kk.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Kk.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kk.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kk.Location = new System.Drawing.Point(95, 37);
            this.dteNgay_Kk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Kk.Mask = "00/00/0000";
            this.dteNgay_Kk.Name = "dteNgay_Kk";
            this.dteNgay_Kk.Size = new System.Drawing.Size(76, 20);
            this.dteNgay_Kk.TabIndex = 247;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(9, 41);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(84, 13);
            this.rsLabel3.TabIndex = 248;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Ngày kiểm kê";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteNgay_Ct2.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(938, 28);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(76, 20);
            this.dteNgay_Ct2.TabIndex = 227;
            // 
            // rsLabel2
            // 
            this.rsLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(852, 32);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(61, 13);
            this.rsLabel2.TabIndex = 228;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Đến ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSua.ImageKey = "(none)";
            this.btSua.Location = new System.Drawing.Point(773, 54);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(88, 40);
            this.btSua.TabIndex = 249;
            this.btSua.Tag = "";
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            // 
            // btXoa
            // 
            this.btXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXoa.ImageKey = "(none)";
            this.btXoa.Location = new System.Drawing.Point(861, 54);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(88, 40);
            this.btXoa.TabIndex = 249;
            this.btXoa.Tag = "";
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            // 
            // frmKiemKeBarcodePT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 562);
            this.ControlBox = false;
            this.Controls.Add(this.rsGroupBox2);
            this.Controls.Add(this.dgvEditCt);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmKiemKeBarcodePT";
            this.ShowInTaskbar = true;
            this.Text = "frmKiemKeBarcodePT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt)).EndInit();
            this.rsGroupBox2.ResumeLayout(false);
            this.rsGroupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Timer txtTime_Clock;
        private System.Windows.Forms.TextBox txtBarcode;
		private RosySystem.Control.rsLabel rsLabel26;
        private RosySystem.Customize.dgvVoucher dgvEditCt;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Customize.btPrint btRefresh;
        private RosySystem.Control.rsGroupBox rsGroupBox2;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsDateTime dteNgay_Kk;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Customize.btFilter btSave;
        private RosySystem.Customize.btFilter btExit;
        private RosySystem.Customize.btFilter btThem;
        private RosySystem.Customize.btFilter btXoa;
        private RosySystem.Customize.btFilter btSua;


	}
}