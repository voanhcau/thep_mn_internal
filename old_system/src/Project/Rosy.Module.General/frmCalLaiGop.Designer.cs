namespace RosyModule.General
{
    partial class frmCalLaiGop
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkSo_Thuc = new System.Windows.Forms.CheckBox();
            this.btExit = new RosySystem.Control.rsButton();
            this.numGia_Mt2 = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.numGia_Mt1 = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.numSl_Mt2 = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.numSl_Mt1 = new RosySystem.Control.rsTextBoxNumber();
            this.lblDu_No = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btKQLaiGop = new RosySystem.Control.rsButton();
            this.btImport = new RosySystem.Control.rsButton();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvHanTt = new RosySystem.Control.rsDataGridView();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkSo_Thuc);
            this.splitContainer1.Panel1.Controls.Add(this.btExit);
            this.splitContainer1.Panel1.Controls.Add(this.numGia_Mt2);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.numGia_Mt1);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.numSl_Mt2);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.numSl_Mt1);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel5);
            this.splitContainer1.Panel1.Controls.Add(this.lblDu_No);
            this.splitContainer1.Panel1.Controls.Add(this.dteNgay_Ct2);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.btKQLaiGop);
            this.splitContainer1.Panel1.Controls.Add(this.btImport);
            this.splitContainer1.Panel1.Controls.Add(this.btRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.dteNgay_Ct1);
            this.splitContainer1.Panel1.Controls.Add(this.lblNgay_Ct);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(893, 729);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 0;
            // 
            // chkSo_Thuc
            // 
            this.chkSo_Thuc.AutoSize = true;
            this.chkSo_Thuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSo_Thuc.ForeColor = System.Drawing.Color.Red;
            this.chkSo_Thuc.Location = new System.Drawing.Point(468, 50);
            this.chkSo_Thuc.Name = "chkSo_Thuc";
            this.chkSo_Thuc.Size = new System.Drawing.Size(70, 17);
            this.chkSo_Thuc.TabIndex = 302;
            this.chkSo_Thuc.Text = "Số thực";
            this.chkSo_Thuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSo_Thuc.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.Blue;
            this.btExit.Location = new System.Drawing.Point(811, 6);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(79, 35);
            this.btExit.TabIndex = 9;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // numGia_Mt2
            // 
            this.numGia_Mt2.AutoDropDown = null;
            this.numGia_Mt2.bFormat = true;
            this.numGia_Mt2.Location = new System.Drawing.Point(270, 71);
            this.numGia_Mt2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numGia_Mt2.Name = "numGia_Mt2";
            this.numGia_Mt2.Scale = 0;
            this.numGia_Mt2.Size = new System.Drawing.Size(100, 20);
            this.numGia_Mt2.TabIndex = 5;
            this.numGia_Mt2.Tag = "Du_No";
            this.numGia_Mt2.Text = "0";
            this.numGia_Mt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia_Mt2.Value = 0D;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(189, 74);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(75, 13);
            this.rsLabel4.TabIndex = 210;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Giá mục tiệu 2";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGia_Mt1
            // 
            this.numGia_Mt1.AutoDropDown = null;
            this.numGia_Mt1.bFormat = true;
            this.numGia_Mt1.Location = new System.Drawing.Point(270, 48);
            this.numGia_Mt1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numGia_Mt1.Name = "numGia_Mt1";
            this.numGia_Mt1.Scale = 0;
            this.numGia_Mt1.Size = new System.Drawing.Size(100, 20);
            this.numGia_Mt1.TabIndex = 3;
            this.numGia_Mt1.Tag = "Du_No";
            this.numGia_Mt1.Text = "0";
            this.numGia_Mt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia_Mt1.Value = 0D;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(189, 51);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(75, 13);
            this.rsLabel3.TabIndex = 206;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Giá mục tiệu 1";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSl_Mt2
            // 
            this.numSl_Mt2.AutoDropDown = null;
            this.numSl_Mt2.bFormat = true;
            this.numSl_Mt2.Location = new System.Drawing.Point(80, 71);
            this.numSl_Mt2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numSl_Mt2.Name = "numSl_Mt2";
            this.numSl_Mt2.Scale = 0;
            this.numSl_Mt2.Size = new System.Drawing.Size(100, 20);
            this.numSl_Mt2.TabIndex = 4;
            this.numSl_Mt2.Tag = "Du_No";
            this.numSl_Mt2.Text = "0";
            this.numSl_Mt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSl_Mt2.Value = 0D;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(5, 74);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(72, 13);
            this.rsLabel2.TabIndex = 201;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "SL mục tiệu 2";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSl_Mt1
            // 
            this.numSl_Mt1.AutoDropDown = null;
            this.numSl_Mt1.bFormat = true;
            this.numSl_Mt1.Location = new System.Drawing.Point(80, 48);
            this.numSl_Mt1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numSl_Mt1.Name = "numSl_Mt1";
            this.numSl_Mt1.Scale = 0;
            this.numSl_Mt1.Size = new System.Drawing.Size(100, 20);
            this.numSl_Mt1.TabIndex = 2;
            this.numSl_Mt1.Tag = "Du_No";
            this.numSl_Mt1.Text = "0";
            this.numSl_Mt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSl_Mt1.Value = 0D;
            // 
            // lblDu_No
            // 
            this.lblDu_No.AutoEllipsis = true;
            this.lblDu_No.AutoSize = true;
            this.lblDu_No.Location = new System.Drawing.Point(5, 51);
            this.lblDu_No.Name = "lblDu_No";
            this.lblDu_No.Size = new System.Drawing.Size(72, 13);
            this.lblDu_No.TabIndex = 200;
            this.lblDu_No.Tag = "";
            this.lblDu_No.Text = "SL mục tiệu 1";
            this.lblDu_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(62, 25);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(78, 20);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(5, 28);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(53, 13);
            this.rsLabel1.TabIndex = 199;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Đến ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btKQLaiGop
            // 
            this.btKQLaiGop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btKQLaiGop.ForeColor = System.Drawing.Color.Blue;
            this.btKQLaiGop.Location = new System.Drawing.Point(377, 6);
            this.btKQLaiGop.Name = "btKQLaiGop";
            this.btKQLaiGop.Size = new System.Drawing.Size(88, 30);
            this.btKQLaiGop.TabIndex = 197;
            this.btKQLaiGop.Tag = "";
            this.btKQLaiGop.Text = "Lãi gộp ngày";
            this.btKQLaiGop.UseVisualStyleBackColor = true;
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImport.ForeColor = System.Drawing.Color.Blue;
            this.btImport.Location = new System.Drawing.Point(811, 41);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(79, 42);
            this.btImport.TabIndex = 197;
            this.btImport.Tag = "";
            this.btImport.Text = "Import kế hoạch";
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ForeColor = System.Drawing.Color.Blue;
            this.btRefresh.Location = new System.Drawing.Point(376, 47);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(89, 23);
            this.btRefresh.TabIndex = 6;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "Update";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(62, 3);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(78, 20);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(5, 6);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct.TabIndex = 194;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Từ ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvHanTt);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(893, 629);
            this.groupBox4.TabIndex = 198;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kết quả tính lãi gộp";
            // 
            // dgvHanTt
            // 
            this.dgvHanTt.AllowUserToAddRows = false;
            this.dgvHanTt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHanTt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHanTt.BackgroundColor = System.Drawing.Color.White;
            this.dgvHanTt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHanTt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHanTt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHanTt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvHanTt.Location = new System.Drawing.Point(3, 18);
            this.dgvHanTt.MultiSelect = false;
            this.dgvHanTt.Name = "dgvHanTt";
            this.dgvHanTt.ReadOnly = true;
            this.dgvHanTt.Size = new System.Drawing.Size(887, 608);
            this.dgvHanTt.strZone = "";
            this.dgvHanTt.TabIndex = 0;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel5.ForeColor = System.Drawing.Color.Tomato;
            this.rsLabel5.Location = new System.Drawing.Point(376, 73);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(339, 13);
            this.rsLabel5.TabIndex = 200;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Số liệu ngày hôm qua được cập nhật sau 9h ngày hiện tại.";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCalLaiGop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 729);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCalLaiGop";
            this.Text = "frmTinhLaiGopKeHoach";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt)).EndInit();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Control.rsTextBoxNumber numGia_Mt2;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBoxNumber numGia_Mt1;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBoxNumber numSl_Mt2;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numSl_Mt1;
        private RosySystem.Control.rsLabel lblDu_No;
        public RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsButton btImport;
        private RosySystem.Control.rsButton btRefresh;
        public RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsButton btExit;
        private System.Windows.Forms.GroupBox groupBox4;
        private RosySystem.Control.rsDataGridView dgvHanTt;
        private RosySystem.Control.rsButton btKQLaiGop;
        private System.Windows.Forms.CheckBox chkSo_Thuc;
        private RosySystem.Control.rsLabel rsLabel5;
    }
}