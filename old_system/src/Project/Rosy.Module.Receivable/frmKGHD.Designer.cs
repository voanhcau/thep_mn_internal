namespace RosyModule.Receivable
{
    partial class frmKGHD
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbtSo_Qd = new RosySystem.Control.rsLabel();
            this.txtSo_Qd = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.btPrint = new RosySystem.Control.rsButton();
            this.lbtTen_Tk_Co = new RosySystem.Control.rsLabel();
            this.txtTk_Co = new RosySystem.Control.rsTextBox();
            this.lblTk_Co = new RosySystem.Control.rsLabel();
            this.lbtTen_Tk_No = new RosySystem.Control.rsLabel();
            this.txtTk_No = new RosySystem.Control.rsTextBox();
            this.lblTk_No = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.lblMa_Dt = new RosySystem.Control.rsLabel();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.txtMa_Ct = new RosySystem.Control.rsTextBox();
            this.lblMa_Ct = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dgvDmDt = new RosySystem.Customize.dgvVoucher();
            this.btExit = new RosySystem.Control.rsButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmDt)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btExit);
            this.groupBox1.Controls.Add(this.lbtSo_Qd);
            this.groupBox1.Controls.Add(this.txtSo_Qd);
            this.groupBox1.Controls.Add(this.rsLabel2);
            this.groupBox1.Controls.Add(this.btPrint);
            this.groupBox1.Controls.Add(this.lbtTen_Tk_Co);
            this.groupBox1.Controls.Add(this.txtTk_Co);
            this.groupBox1.Controls.Add(this.lblTk_Co);
            this.groupBox1.Controls.Add(this.lbtTen_Tk_No);
            this.groupBox1.Controls.Add(this.txtTk_No);
            this.groupBox1.Controls.Add(this.lblTk_No);
            this.groupBox1.Controls.Add(this.txtMa_Dt);
            this.groupBox1.Controls.Add(this.lblMa_Dt);
            this.groupBox1.Controls.Add(this.lbtTen_Dt);
            this.groupBox1.Controls.Add(this.txtMa_Ct);
            this.groupBox1.Controls.Add(this.lblMa_Ct);
            this.groupBox1.Controls.Add(this.rsLabel3);
            this.groupBox1.Controls.Add(this.lblNgay_Ct);
            this.groupBox1.Controls.Add(this.dteNgay_Ct2);
            this.groupBox1.Controls.Add(this.dteNgay_Ct1);
            this.groupBox1.Controls.Add(this.btRefresh);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Truy vấn thông tin xuất kho";
            // 
            // lbtSo_Qd
            // 
            this.lbtSo_Qd.AutoEllipsis = true;
            this.lbtSo_Qd.AutoSize = true;
            this.lbtSo_Qd.ForeColor = System.Drawing.Color.Blue;
            this.lbtSo_Qd.Location = new System.Drawing.Point(157, 107);
            this.lbtSo_Qd.Name = "lbtSo_Qd";
            this.lbtSo_Qd.Size = new System.Drawing.Size(88, 13);
            this.lbtSo_Qd.TabIndex = 84;
            this.lbtSo_Qd.Text = "Tên tài khoản có";
            this.lbtSo_Qd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Qd
            // 
            this.txtSo_Qd.AutoDropDown = null;
            this.txtSo_Qd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Qd.Location = new System.Drawing.Point(86, 104);
            this.txtSo_Qd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Qd.Name = "txtSo_Qd";
            this.txtSo_Qd.Size = new System.Drawing.Size(66, 20);
            this.txtSo_Qd.TabIndex = 83;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(13, 106);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(73, 13);
            this.rsLabel2.TabIndex = 85;
            this.rsLabel2.Tag = "So_Qd";
            this.rsLabel2.Text = "Số quyết định";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPrint.Location = new System.Drawing.Point(671, 35);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(97, 23);
            this.btPrint.TabIndex = 82;
            this.btPrint.Tag = "Print";
            this.btPrint.Text = "In biên bản";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // lbtTen_Tk_Co
            // 
            this.lbtTen_Tk_Co.AutoEllipsis = true;
            this.lbtTen_Tk_Co.AutoSize = true;
            this.lbtTen_Tk_Co.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk_Co.Location = new System.Drawing.Point(157, 85);
            this.lbtTen_Tk_Co.Name = "lbtTen_Tk_Co";
            this.lbtTen_Tk_Co.Size = new System.Drawing.Size(88, 13);
            this.lbtTen_Tk_Co.TabIndex = 79;
            this.lbtTen_Tk_Co.Text = "Tên tài khoản có";
            this.lbtTen_Tk_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTk_Co
            // 
            this.txtTk_Co.AutoDropDown = null;
            this.txtTk_Co.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk_Co.Location = new System.Drawing.Point(86, 82);
            this.txtTk_Co.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_Co.Name = "txtTk_Co";
            this.txtTk_Co.Size = new System.Drawing.Size(66, 20);
            this.txtTk_Co.TabIndex = 75;
            // 
            // lblTk_Co
            // 
            this.lblTk_Co.AutoEllipsis = true;
            this.lblTk_Co.AutoSize = true;
            this.lblTk_Co.Location = new System.Drawing.Point(13, 84);
            this.lblTk_Co.Name = "lblTk_Co";
            this.lblTk_Co.Size = new System.Drawing.Size(70, 13);
            this.lblTk_Co.TabIndex = 81;
            this.lblTk_Co.Tag = "Tk_Co";
            this.lblTk_Co.Text = "Tài khoản có";
            this.lblTk_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tk_No
            // 
            this.lbtTen_Tk_No.AutoEllipsis = true;
            this.lbtTen_Tk_No.AutoSize = true;
            this.lbtTen_Tk_No.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk_No.Location = new System.Drawing.Point(157, 63);
            this.lbtTen_Tk_No.Name = "lbtTen_Tk_No";
            this.lbtTen_Tk_No.Size = new System.Drawing.Size(88, 13);
            this.lbtTen_Tk_No.TabIndex = 78;
            this.lbtTen_Tk_No.Text = "Tên tài khoản nợ";
            this.lbtTen_Tk_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTk_No
            // 
            this.txtTk_No.AutoDropDown = null;
            this.txtTk_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk_No.Location = new System.Drawing.Point(86, 60);
            this.txtTk_No.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_No.Name = "txtTk_No";
            this.txtTk_No.Size = new System.Drawing.Size(66, 20);
            this.txtTk_No.TabIndex = 74;
            // 
            // lblTk_No
            // 
            this.lblTk_No.AutoEllipsis = true;
            this.lblTk_No.AutoSize = true;
            this.lblTk_No.Location = new System.Drawing.Point(13, 63);
            this.lblTk_No.Name = "lblTk_No";
            this.lblTk_No.Size = new System.Drawing.Size(70, 13);
            this.lblTk_No.TabIndex = 80;
            this.lblTk_No.Tag = "Tk_No";
            this.lblTk_No.Text = "Tài khoản nợ";
            this.lblTk_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(86, 38);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 72;
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.Location = new System.Drawing.Point(13, 41);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(53, 13);
            this.lblMa_Dt.TabIndex = 77;
            this.lblMa_Dt.Tag = "Ma_Dt";
            this.lblMa_Dt.Text = "Đối tượng";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(211, 42);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(74, 13);
            this.lbtTen_Dt.TabIndex = 71;
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ct
            // 
            this.txtMa_Ct.AutoDropDown = null;
            this.txtMa_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ct.Location = new System.Drawing.Point(41, 16);
            this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct.MaxLength = 20;
            this.txtMa_Ct.Name = "txtMa_Ct";
            this.txtMa_Ct.Size = new System.Drawing.Size(57, 20);
            this.txtMa_Ct.TabIndex = 64;
            // 
            // lblMa_Ct
            // 
            this.lblMa_Ct.AutoEllipsis = true;
            this.lblMa_Ct.AutoSize = true;
            this.lblMa_Ct.Location = new System.Drawing.Point(7, 19);
            this.lblMa_Ct.Name = "lblMa_Ct";
            this.lblMa_Ct.Size = new System.Drawing.Size(35, 13);
            this.lblMa_Ct.TabIndex = 69;
            this.lblMa_Ct.Tag = "Ma_Ct";
            this.lblMa_Ct.Text = "Mã Ct";
            this.lblMa_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(224, 19);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(53, 13);
            this.rsLabel3.TabIndex = 67;
            this.rsLabel3.Tag = "Ngay_Ct2";
            this.rsLabel3.Text = "Đến ngày";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(102, 19);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct.TabIndex = 68;
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
            this.dteNgay_Ct2.Location = new System.Drawing.Point(282, 16);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 66;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(153, 16);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct1.TabIndex = 65;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btRefresh.Location = new System.Drawing.Point(671, 11);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(97, 23);
            this.btRefresh.TabIndex = 3;
            this.btRefresh.Tag = "Refresh";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvDmDt
            // 
            this.dgvDmDt.AllowUserToAddRows = false;
            this.dgvDmDt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDmDt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDmDt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDmDt.BackgroundColor = System.Drawing.Color.White;
            this.dgvDmDt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDmDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDmDt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDmDt.Location = new System.Drawing.Point(8, 149);
            this.dgvDmDt.MultiSelect = false;
            this.dgvDmDt.Name = "dgvDmDt";
            this.dgvDmDt.Size = new System.Drawing.Size(775, 405);
            this.dgvDmDt.strZone = "";
            this.dgvDmDt.TabIndex = 2;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(671, 60);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(97, 23);
            this.btExit.TabIndex = 86;
            this.btExit.Tag = "";
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // frmKGHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btRefresh;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dgvDmDt);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmKGHD";
            this.Text = "frmKGHD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmDt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox1;
		private RosySystem.Control.rsButton btRefresh;
        public RosySystem.Control.rsTextBox txtMa_Ct;
        private RosySystem.Control.rsLabel lblMa_Ct;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel lbtTen_Tk_Co;
        private RosySystem.Control.rsTextBox txtTk_Co;
        private RosySystem.Control.rsLabel lblTk_Co;
        private RosySystem.Control.rsLabel lbtTen_Tk_No;
        private RosySystem.Control.rsTextBox txtTk_No;
        private RosySystem.Control.rsLabel lblTk_No;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Control.rsLabel lblMa_Dt;
        private RosySystem.Control.rsLabel lbtTen_Dt;
        private RosySystem.Control.rsLabel lbtSo_Qd;
        private RosySystem.Control.rsTextBox txtSo_Qd;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsButton btPrint;
        private RosySystem.Customize.dgvVoucher dgvDmDt;
        private RosySystem.Control.rsButton btExit;
	}
}