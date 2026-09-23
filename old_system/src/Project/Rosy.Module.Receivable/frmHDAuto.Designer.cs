namespace RosyModule.Receivable
{
    partial class frmHDAuto
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
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.chkIsNot_TaoHD = new System.Windows.Forms.CheckBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtMa_Ct = new RosySystem.Control.rsTextBox();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.txtSo_Ct = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.btFilter = new RosySystem.Customize.btFilter();
            this.lbtTen_Dt = new RosySystem.Control.rsLabelName();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpChungTu = new System.Windows.Forms.TabPage();
            this.dgvChungtu = new RosySystem.Control.rsDataGridView();
            this.tpKetQua = new System.Windows.Forms.TabPage();
            this.dgvKetQua = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.btThoat = new RosySystem.Customize.btFilter();
            this.btAllPXDC = new RosySystem.Customize.btFilter();
            this.btCheckTimeHD = new RosySystem.Customize.btFilter();
            this.btDelete = new RosySystem.Customize.btFilter();
            this.btCreateCt = new RosySystem.Customize.btFilter();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpChungTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChungtu)).BeginInit();
            this.tpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.rsPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsSplitContainer1
            // 
            this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.rsSplitContainer1.Name = "rsSplitContainer1";
            this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer1.Panel1
            // 
            this.rsSplitContainer1.Panel1.Controls.Add(this.chkIsNot_TaoHD);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel4);
            this.rsSplitContainer1.Panel1.Controls.Add(this.txtMa_Ct);
            this.rsSplitContainer1.Panel1.Controls.Add(this.dteNgay_Ct2);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel7);
            this.rsSplitContainer1.Panel1.Controls.Add(this.txtMa_Dt);
            this.rsSplitContainer1.Panel1.Controls.Add(this.txtSo_Ct);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel2);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel3);
            this.rsSplitContainer1.Panel1.Controls.Add(this.btFilter);
            this.rsSplitContainer1.Panel1.Controls.Add(this.lbtTen_Dt);
            // 
            // rsSplitContainer1.Panel2
            // 
            this.rsSplitContainer1.Panel2.Controls.Add(this.tabControl);
            this.rsSplitContainer1.Panel2.Controls.Add(this.rsPanel1);
            this.rsSplitContainer1.Size = new System.Drawing.Size(1321, 766);
            this.rsSplitContainer1.SplitterDistance = 103;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // chkIsNot_TaoHD
            // 
            this.chkIsNot_TaoHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsNot_TaoHD.AutoSize = true;
            this.chkIsNot_TaoHD.Checked = true;
            this.chkIsNot_TaoHD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNot_TaoHD.ForeColor = System.Drawing.Color.OrangeRed;
            this.chkIsNot_TaoHD.Location = new System.Drawing.Point(150, 11);
            this.chkIsNot_TaoHD.Name = "chkIsNot_TaoHD";
            this.chkIsNot_TaoHD.Size = new System.Drawing.Size(236, 17);
            this.chkIsNot_TaoHD.TabIndex = 153;
            this.chkIsNot_TaoHD.Text = "Chỉ lấy các chứng từ chưa được tạo tự động";
            this.chkIsNot_TaoHD.UseVisualStyleBackColor = true;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(11, 34);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(67, 13);
            this.rsLabel4.TabIndex = 87;
            this.rsLabel4.Text = "Mã chứng từ";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ct
            // 
            this.txtMa_Ct.AutoDropDown = null;
            this.txtMa_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ct.Location = new System.Drawing.Point(81, 31);
            this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct.MaxLength = 20;
            this.txtMa_Ct.Name = "txtMa_Ct";
            this.txtMa_Ct.Size = new System.Drawing.Size(107, 20);
            this.txtMa_Ct.TabIndex = 2;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(79, 9);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(11, 78);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(65, 13);
            this.rsLabel7.TabIndex = 13;
            this.rsLabel7.Text = "Số chứng từ";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.Location = new System.Drawing.Point(81, 53);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(107, 20);
            this.txtMa_Dt.TabIndex = 3;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.AutoDropDown = null;
            this.txtSo_Ct.Location = new System.Drawing.Point(81, 75);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.Size = new System.Drawing.Size(107, 20);
            this.txtSo_Ct.TabIndex = 4;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(11, 12);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(48, 13);
            this.rsLabel2.TabIndex = 2;
            this.rsLabel2.Text = "Tại ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(11, 57);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(65, 13);
            this.rsLabel3.TabIndex = 9;
            this.rsLabel3.Text = "Khách hàng";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btFilter
            // 
            this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFilter.ImageKey = "Filter.png";
            this.btFilter.Location = new System.Drawing.Point(401, 3);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(86, 43);
            this.btFilter.TabIndex = 6;
            this.btFilter.Tag = "";
            this.btFilter.Text = "F9 - &Lọc";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(197, 56);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(86, 13);
            this.lbtTen_Dt.TabIndex = 7;
            this.lbtTen_Dt.Text = "Tên khách hàng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpChungTu);
            this.tabControl.Controls.Add(this.tpKetQua);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1321, 613);
            this.tabControl.TabIndex = 2;
            // 
            // tpChungTu
            // 
            this.tpChungTu.Controls.Add(this.dgvChungtu);
            this.tpChungTu.Location = new System.Drawing.Point(4, 22);
            this.tpChungTu.Name = "tpChungTu";
            this.tpChungTu.Padding = new System.Windows.Forms.Padding(3);
            this.tpChungTu.Size = new System.Drawing.Size(1313, 587);
            this.tpChungTu.TabIndex = 0;
            this.tpChungTu.Text = "Danh sách chứng từ";
            this.tpChungTu.UseVisualStyleBackColor = true;
            // 
            // dgvChungtu
            // 
            this.dgvChungtu.AllowUserToAddRows = false;
            this.dgvChungtu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvChungtu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChungtu.BackgroundColor = System.Drawing.Color.White;
            this.dgvChungtu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChungtu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChungtu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChungtu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChungtu.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvChungtu.Location = new System.Drawing.Point(3, 3);
            this.dgvChungtu.MultiSelect = false;
            this.dgvChungtu.Name = "dgvChungtu";
            this.dgvChungtu.ReadOnly = true;
            this.dgvChungtu.Size = new System.Drawing.Size(1307, 581);
            this.dgvChungtu.strZone = "";
            this.dgvChungtu.TabIndex = 16;
            // 
            // tpKetQua
            // 
            this.tpKetQua.Controls.Add(this.dgvKetQua);
            this.tpKetQua.Location = new System.Drawing.Point(4, 22);
            this.tpKetQua.Name = "tpKetQua";
            this.tpKetQua.Padding = new System.Windows.Forms.Padding(3);
            this.tpKetQua.Size = new System.Drawing.Size(1313, 587);
            this.tpKetQua.TabIndex = 1;
            this.tpKetQua.Text = "Kết quả";
            this.tpKetQua.UseVisualStyleBackColor = true;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKetQua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKetQua.BackgroundColor = System.Drawing.Color.White;
            this.dgvKetQua.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKetQua.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKetQua.Location = new System.Drawing.Point(3, 3);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.Size = new System.Drawing.Size(1307, 581);
            this.dgvKetQua.strZone = "";
            this.dgvKetQua.TabIndex = 15;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.btThoat);
            this.rsPanel1.Controls.Add(this.btAllPXDC);
            this.rsPanel1.Controls.Add(this.btCheckTimeHD);
            this.rsPanel1.Controls.Add(this.btDelete);
            this.rsPanel1.Controls.Add(this.btCreateCt);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rsPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsPanel1.ForeColor = System.Drawing.Color.Blue;
            this.rsPanel1.Location = new System.Drawing.Point(0, 613);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(1321, 46);
            this.rsPanel1.TabIndex = 1;
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThoat.ImageKey = "(none)";
            this.btThoat.Location = new System.Drawing.Point(1232, 3);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(86, 40);
            this.btThoat.TabIndex = 5;
            this.btThoat.Tag = "";
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            // 
            // btAllPXDC
            // 
            this.btAllPXDC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAllPXDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAllPXDC.ImageKey = "(none)";
            this.btAllPXDC.Location = new System.Drawing.Point(829, 3);
            this.btAllPXDC.Name = "btAllPXDC";
            this.btAllPXDC.Size = new System.Drawing.Size(113, 40);
            this.btAllPXDC.TabIndex = 5;
            this.btAllPXDC.Tag = "";
            this.btAllPXDC.Text = "Tất cả PXDC chưa ra HD";
            this.btAllPXDC.UseVisualStyleBackColor = true;
            // 
            // btCheckTimeHD
            // 
            this.btCheckTimeHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCheckTimeHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCheckTimeHD.ImageKey = "(none)";
            this.btCheckTimeHD.Location = new System.Drawing.Point(943, 3);
            this.btCheckTimeHD.Name = "btCheckTimeHD";
            this.btCheckTimeHD.Size = new System.Drawing.Size(113, 40);
            this.btCheckTimeHD.TabIndex = 5;
            this.btCheckTimeHD.Tag = "";
            this.btCheckTimeHD.Text = "Kiểm tra thời hạn ra HD ký gửi";
            this.btCheckTimeHD.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "(none)";
            this.btDelete.Location = new System.Drawing.Point(1146, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(86, 40);
            this.btDelete.TabIndex = 5;
            this.btDelete.Tag = "";
            this.btDelete.Text = "Xóa chứng từ";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btCreateCt
            // 
            this.btCreateCt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateCt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCreateCt.ImageKey = "(none)";
            this.btCreateCt.Location = new System.Drawing.Point(1056, 3);
            this.btCreateCt.Name = "btCreateCt";
            this.btCreateCt.Size = new System.Drawing.Size(86, 40);
            this.btCreateCt.TabIndex = 5;
            this.btCreateCt.Tag = "";
            this.btCreateCt.Text = "Tạo chứng từ";
            this.btCreateCt.UseVisualStyleBackColor = true;
            // 
            // frmHDAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 772);
            this.Controls.Add(this.rsSplitContainer1);
            this.Name = "frmHDAuto";
            this.Object_ID = "HDDTU";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Tag = "frmHDAUTO";
            this.Text = "frmHDAUTO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel1.PerformLayout();
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpChungTu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChungtu)).EndInit();
            this.tpKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
        private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Control.rsTextBox txtMa_Dt;
		private RosySystem.Control.rsLabelName lbtTen_Dt;
		private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsTextBox txtSo_Ct;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsPanel rsPanel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Customize.btFilter btThoat;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBox txtMa_Ct;
        private System.Windows.Forms.CheckBox chkIsNot_TaoHD;
        private RosySystem.Customize.btFilter btCreateCt;
        private RosySystem.Customize.btFilter btCheckTimeHD;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpChungTu;
        private System.Windows.Forms.TabPage tpKetQua;
        //private RosySystem.Control.rsDataGridView dgvKetQua;
        private RosySystem.Customize.btFilter btDelete;
        private RosySystem.Control.rsDataGridView dgvChungtu;
        private RosySystem.Control.rsDataGridView dgvKetQua;
        private RosySystem.Customize.btFilter btAllPXDC;
	}
}