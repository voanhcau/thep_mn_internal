namespace RosyModule.Manufactory
{
    partial class frmLenhSanXuat_Edit
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
            this.tabControl1 = new RosySystem.Control.rsTabControl();
            this.tpCan = new System.Windows.Forms.TabPage();
            this.dgvCan = new RosySystem.Customize.dgvVoucher();
            this.dgvEditCt1 = new RosySystem.Customize.dgvVoucher();
            this.tpLuyen = new System.Windows.Forms.TabPage();
            this.dgvLuyen = new RosySystem.Customize.dgvVoucher();
            this.txtLy_Do = new RosySystem.Control.rsTextBox();
            this.lblTinh_Trang_Giao_Ca = new RosySystem.Control.rsLabel();
            this.btSave = new RosySystem.Customize.btEdit();
            this.btExit = new RosySystem.Customize.btEdit();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.numHieu_Suat = new RosySystem.Control.rsTextBoxNumber();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.numLan_Tt = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtDanh_Gia = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.btImport = new RosySystem.Customize.btEdit();
            this.tabControl1.SuspendLayout();
            this.tpCan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt1)).BeginInit();
            this.tpLuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpCan);
            this.tabControl1.Controls.Add(this.tpLuyen);
            this.tabControl1.Location = new System.Drawing.Point(-1, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(947, 256);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabStop = false;
            // 
            // tpCan
            // 
            this.tpCan.Controls.Add(this.dgvCan);
            this.tpCan.Controls.Add(this.dgvEditCt1);
            this.tpCan.Location = new System.Drawing.Point(4, 22);
            this.tpCan.Name = "tpCan";
            this.tpCan.Padding = new System.Windows.Forms.Padding(3);
            this.tpCan.Size = new System.Drawing.Size(939, 230);
            this.tpCan.TabIndex = 0;
            this.tpCan.Text = "Sản xuất cán";
            this.tpCan.UseVisualStyleBackColor = true;
            // 
            // dgvCan
            // 
            this.dgvCan.AllowUserToAddRows = false;
            this.dgvCan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCan.BackgroundColor = System.Drawing.Color.White;
            this.dgvCan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCan.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCan.Location = new System.Drawing.Point(3, 3);
            this.dgvCan.MultiSelect = false;
            this.dgvCan.Name = "dgvCan";
            this.dgvCan.Size = new System.Drawing.Size(933, 224);
            this.dgvCan.strZone = "";
            this.dgvCan.TabIndex = 12;
            // 
            // dgvEditCt1
            // 
            this.dgvEditCt1.AllowUserToAddRows = false;
            this.dgvEditCt1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEditCt1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEditCt1.BackgroundColor = System.Drawing.Color.White;
            this.dgvEditCt1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEditCt1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditCt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEditCt1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEditCt1.Location = new System.Drawing.Point(3, 3);
            this.dgvEditCt1.MultiSelect = false;
            this.dgvEditCt1.Name = "dgvEditCt1";
            this.dgvEditCt1.Size = new System.Drawing.Size(933, 224);
            this.dgvEditCt1.strZone = "";
            this.dgvEditCt1.TabIndex = 11;
            // 
            // tpLuyen
            // 
            this.tpLuyen.Controls.Add(this.dgvLuyen);
            this.tpLuyen.Location = new System.Drawing.Point(4, 22);
            this.tpLuyen.Name = "tpLuyen";
            this.tpLuyen.Size = new System.Drawing.Size(1170, 432);
            this.tpLuyen.TabIndex = 1;
            this.tpLuyen.Text = "Sản xuất luyện";
            this.tpLuyen.UseVisualStyleBackColor = true;
            // 
            // dgvLuyen
            // 
            this.dgvLuyen.AllowUserToAddRows = false;
            this.dgvLuyen.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLuyen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvLuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLuyen.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvLuyen.Location = new System.Drawing.Point(0, 0);
            this.dgvLuyen.MultiSelect = false;
            this.dgvLuyen.Name = "dgvLuyen";
            this.dgvLuyen.Size = new System.Drawing.Size(1170, 432);
            this.dgvLuyen.strZone = "";
            this.dgvLuyen.TabIndex = 13;
            // 
            // txtLy_Do
            // 
            this.txtLy_Do.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLy_Do.AutoDropDown = null;
            this.txtLy_Do.BackColor = System.Drawing.SystemColors.Window;
            this.txtLy_Do.Location = new System.Drawing.Point(287, 6);
            this.txtLy_Do.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLy_Do.MaxLength = 1000;
            this.txtLy_Do.Multiline = true;
            this.txtLy_Do.Name = "txtLy_Do";
            this.txtLy_Do.Size = new System.Drawing.Size(655, 46);
            this.txtLy_Do.TabIndex = 1;
            // 
            // lblTinh_Trang_Giao_Ca
            // 
            this.lblTinh_Trang_Giao_Ca.AutoEllipsis = true;
            this.lblTinh_Trang_Giao_Ca.AutoSize = true;
            this.lblTinh_Trang_Giao_Ca.Location = new System.Drawing.Point(189, 10);
            this.lblTinh_Trang_Giao_Ca.Name = "lblTinh_Trang_Giao_Ca";
            this.lblTinh_Trang_Giao_Ca.Size = new System.Drawing.Size(93, 13);
            this.lblTinh_Trang_Giao_Ca.TabIndex = 257;
            this.lblTinh_Trang_Giao_Ca.Tag = "";
            this.lblTinh_Trang_Giao_Ca.Text = "Lý do thay đổi lịch";
            this.lblTinh_Trang_Giao_Ca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageKey = "(none)";
            this.btSave.Location = new System.Drawing.Point(764, 85);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(88, 28);
            this.btSave.TabIndex = 4;
            this.btSave.Tag = "";
            this.btSave.Text = "Lưu";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "(none)";
            this.btExit.Location = new System.Drawing.Point(854, 85);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(88, 28);
            this.btExit.TabIndex = 5;
            this.btExit.Tag = "";
            this.btExit.Text = "Thoát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(12, 33);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(52, 13);
            this.rsLabel1.TabIndex = 258;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Hiệu suất";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numHieu_Suat
            // 
            this.numHieu_Suat.AutoDropDown = null;
            this.numHieu_Suat.BackColor = System.Drawing.SystemColors.Window;
            this.numHieu_Suat.bFormat = true;
            this.numHieu_Suat.Location = new System.Drawing.Point(102, 29);
            this.numHieu_Suat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numHieu_Suat.Name = "numHieu_Suat";
            this.numHieu_Suat.Scale = 2;
            this.numHieu_Suat.Size = new System.Drawing.Size(55, 20);
            this.numHieu_Suat.TabIndex = 2;
            this.numHieu_Suat.Tag = "";
            this.numHieu_Suat.Text = "0.85";
            this.numHieu_Suat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHieu_Suat.Value = 0.85D;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(102, 7);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(82, 20);
            this.dteNgay_Ct.TabIndex = 0;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(10, 9);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(69, 13);
            this.lblNgay_Ct.TabIndex = 266;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Ngày đổi lịch";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLan_Tt
            // 
            this.numLan_Tt.AutoDropDown = null;
            this.numLan_Tt.BackColor = System.Drawing.SystemColors.Window;
            this.numLan_Tt.bFormat = true;
            this.numLan_Tt.Location = new System.Drawing.Point(102, 52);
            this.numLan_Tt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numLan_Tt.Name = "numLan_Tt";
            this.numLan_Tt.Scale = 0;
            this.numLan_Tt.Size = new System.Drawing.Size(68, 20);
            this.numLan_Tt.TabIndex = 267;
            this.numLan_Tt.Tag = "";
            this.numLan_Tt.Text = "0";
            this.numLan_Tt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLan_Tt.Value = 0D;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(12, 55);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(69, 13);
            this.rsLabel2.TabIndex = 268;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Thay đổi  lần";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel3.Location = new System.Drawing.Point(12, 85);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(42, 13);
            this.rsLabel3.TabIndex = 257;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Lưu ý:";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel4.Location = new System.Drawing.Point(60, 85);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(577, 13);
            this.rsLabel4.TabIndex = 257;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Nhấn F6 để thêm dòng trong ngày và ca SX, F8 xóa dòng sau đó nhấn lưu ngay để cập" +
                " nhật dữ liệu";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDanh_Gia
            // 
            this.txtDanh_Gia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDanh_Gia.AutoDropDown = null;
            this.txtDanh_Gia.BackColor = System.Drawing.SystemColors.Window;
            this.txtDanh_Gia.Location = new System.Drawing.Point(287, 54);
            this.txtDanh_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDanh_Gia.MaxLength = 1000;
            this.txtDanh_Gia.Multiline = true;
            this.txtDanh_Gia.Name = "txtDanh_Gia";
            this.txtDanh_Gia.Size = new System.Drawing.Size(655, 28);
            this.txtDanh_Gia.TabIndex = 269;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(189, 58);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(73, 13);
            this.rsLabel5.TabIndex = 270;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Đánh giá LSX";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.ImageKey = "(none)";
            this.btImport.Location = new System.Drawing.Point(673, 86);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(88, 28);
            this.btImport.TabIndex = 271;
            this.btImport.Tag = "";
            this.btImport.Text = "Import Excel";
            this.btImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // frmLenhSanXuat_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 366);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.txtDanh_Gia);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.numLan_Tt);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.dteNgay_Ct);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.numHieu_Suat);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtLy_Do);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.lblTinh_Trang_Giao_Ca);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmLenhSanXuat_Edit";
            this.Tag = "frmLenhSanXuatCan_Edit, ESC";
            this.Text = "frmLenhSanXuatCan_Edit";
            this.tabControl1.ResumeLayout(false);
            this.tpCan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditCt1)).EndInit();
            this.tpLuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Control.rsTabControl tabControl1;
        private System.Windows.Forms.TabPage tpCan;
        private RosySystem.Customize.dgvVoucher dgvEditCt1;
        private RosySystem.Control.rsTextBox txtLy_Do;
        private RosySystem.Control.rsLabel lblTinh_Trang_Giao_Ca;
        private System.Windows.Forms.TabPage tpLuyen;
        private RosySystem.Customize.dgvVoucher dgvCan;
        private RosySystem.Customize.btEdit btSave;
        private RosySystem.Customize.btEdit btExit;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBoxNumber numHieu_Suat;
        private RosySystem.Customize.dgvVoucher dgvLuyen;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsTextBoxNumber numLan_Tt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBox txtDanh_Gia;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Customize.btEdit btImport;
	}
}