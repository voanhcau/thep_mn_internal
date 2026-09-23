namespace RosyModule.Payable
{
    partial class frmKKBarcodePT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.btExit = new RosySystem.Control.rsButton();
            this.btDieu_Chinh = new RosySystem.Control.rsButton();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvBarcodePT = new RosySystem.Control.rsDataGridView();
            this.dgvBarcodeDC = new RosySystem.Control.rsDataGridView();
            this.chkIs_KK = new RosySystem.Control.rsCheckbox();
            this.chkIs_DC = new RosySystem.Control.rsCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodePT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodeDC)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkIs_DC);
            this.splitContainer1.Panel1.Controls.Add(this.chkIs_KK);
            this.splitContainer1.Panel1.Controls.Add(this.dteNgay_Ct);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.btExit);
            this.splitContainer1.Panel1.Controls.Add(this.btDieu_Chinh);
            this.splitContainer1.Panel1.Controls.Add(this.btRefresh);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1679, 847);
            this.splitContainer1.SplitterDistance = 74;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(119, 15);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(108, 22);
            this.dteNgay_Ct.TabIndex = 65;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(16, 19);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(93, 17);
            this.rsLabel2.TabIndex = 64;
            this.rsLabel2.Tag = "Ngay_KK";
            this.rsLabel2.Text = "Ngày kiểm kê";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(838, 6);
            this.btExit.Margin = new System.Windows.Forms.Padding(4);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(123, 56);
            this.btExit.TabIndex = 11;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btDieu_Chinh
            // 
            this.btDieu_Chinh.Location = new System.Drawing.Point(707, 6);
            this.btDieu_Chinh.Margin = new System.Windows.Forms.Padding(4);
            this.btDieu_Chinh.Name = "btDieu_Chinh";
            this.btDieu_Chinh.Size = new System.Drawing.Size(123, 56);
            this.btDieu_Chinh.TabIndex = 11;
            this.btDieu_Chinh.Text = "Điều chỉnh kho\n";
            this.btDieu_Chinh.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(577, 6);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(123, 56);
            this.btRefresh.TabIndex = 11;
            this.btRefresh.Text = "F5 - Refresh\r\n";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvBarcodePT);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvBarcodeDC);
            this.splitContainer2.Size = new System.Drawing.Size(1679, 768);
            this.splitContainer2.SplitterDistance = 352;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvBarcodePT
            // 
            this.dgvBarcodePT.AllowUserToAddRows = false;
            this.dgvBarcodePT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBarcodePT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBarcodePT.BackgroundColor = System.Drawing.Color.White;
            this.dgvBarcodePT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBarcodePT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcodePT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBarcodePT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBarcodePT.Location = new System.Drawing.Point(0, 0);
            this.dgvBarcodePT.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBarcodePT.MultiSelect = false;
            this.dgvBarcodePT.Name = "dgvBarcodePT";
            this.dgvBarcodePT.ReadOnly = true;
            this.dgvBarcodePT.Size = new System.Drawing.Size(1679, 352);
            this.dgvBarcodePT.strZone = "";
            this.dgvBarcodePT.TabIndex = 1;
            // 
            // dgvBarcodeDC
            // 
            this.dgvBarcodeDC.AllowUserToAddRows = false;
            this.dgvBarcodeDC.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBarcodeDC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBarcodeDC.BackgroundColor = System.Drawing.Color.White;
            this.dgvBarcodeDC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBarcodeDC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcodeDC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBarcodeDC.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBarcodeDC.Location = new System.Drawing.Point(0, 0);
            this.dgvBarcodeDC.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBarcodeDC.MultiSelect = false;
            this.dgvBarcodeDC.Name = "dgvBarcodeDC";
            this.dgvBarcodeDC.ReadOnly = true;
            this.dgvBarcodeDC.Size = new System.Drawing.Size(1679, 412);
            this.dgvBarcodeDC.strZone = "";
            this.dgvBarcodeDC.TabIndex = 1;
            // 
            // chkIs_KK
            // 
            this.chkIs_KK.AutoSize = true;
            this.chkIs_KK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_KK.ForeColor = System.Drawing.Color.Blue;
            this.chkIs_KK.Location = new System.Drawing.Point(250, 16);
            this.chkIs_KK.Margin = new System.Windows.Forms.Padding(4);
            this.chkIs_KK.Name = "chkIs_KK";
            this.chkIs_KK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIs_KK.Size = new System.Drawing.Size(309, 21);
            this.chkIs_KK.TabIndex = 1036;
            this.chkIs_KK.TabStop = false;
            this.chkIs_KK.Text = "&Lấy tất cả barcode kiểm kê trong ngày";
            this.chkIs_KK.UseVisualStyleBackColor = true;
            // 
            // chkIs_DC
            // 
            this.chkIs_DC.AutoSize = true;
            this.chkIs_DC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_DC.ForeColor = System.Drawing.Color.Blue;
            this.chkIs_DC.Location = new System.Drawing.Point(250, 41);
            this.chkIs_DC.Margin = new System.Windows.Forms.Padding(4);
            this.chkIs_DC.Name = "chkIs_DC";
            this.chkIs_DC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIs_DC.Size = new System.Drawing.Size(284, 21);
            this.chkIs_DC.TabIndex = 1036;
            this.chkIs_DC.TabStop = false;
            this.chkIs_DC.Text = "&Chỉ lấy các barcode cần điều chỉnh";
            this.chkIs_DC.UseVisualStyleBackColor = true;
            // 
            // frmKKBarcodePT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1679, 847);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmKKBarcodePT";
            this.Object_ID = "KIEMKE_BARCODE_PT";
            this.Tag = "frmKKBarcodePT";
            this.Text = "frmKKBarcodePT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodePT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodeDC)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsButton btDieu_Chinh;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private RosySystem.Control.rsDataGridView dgvBarcodePT;
        private RosySystem.Control.rsDataGridView dgvBarcodeDC;
        private RosySystem.Control.rsCheckbox chkIs_DC;
        private RosySystem.Control.rsCheckbox chkIs_KK;

    }
}