namespace RosyModule.Machinery
{
    partial class frmDuyetKHBT
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
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.rsPanel2 = new RosySystem.Control.rsPanel();
            this.dgvKHVTPKTDT = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.chkNotDuyet = new RosySystem.Control.rsCheckbox();
            this.btRefresh = new RosySystem.Customize.btNew();
            this.txtThang_Th = new RosySystem.Control.rsTextBox();
            this.lbtTen_Tb = new RosySystem.Control.rsLabel();
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabel();
            this.txtMa_Bp = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.txtMa_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.lbtThang_Th = new RosySystem.Control.rsLabel();
            this.txtMa_Nh_Tb = new RosySystem.Control.rsTextBox();
            this.txtPt_Bt = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.lbtPt_Bt = new RosySystem.Control.rsLabel();
            this.numNam = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.btPrint = new RosySystem.Customize.btNew();
            this.btSave = new RosySystem.Customize.btNew();
            this.btExit = new RosySystem.Customize.btNew();
            this.chkDuyet = new RosySystem.Control.rsCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.rsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHVTPKTDT)).BeginInit();
            this.rsPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsSplitContainer1
            // 
            this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.rsSplitContainer1.Name = "rsSplitContainer1";
            this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer1.Panel1
            // 
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel2);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel1);
            this.rsSplitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // rsSplitContainer1.Panel2
            // 
            this.rsSplitContainer1.Panel2.Controls.Add(this.btPrint);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btSave);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btExit);
            this.rsSplitContainer1.Panel2.Controls.Add(this.chkDuyet);
            this.rsSplitContainer1.Size = new System.Drawing.Size(933, 562);
            this.rsSplitContainer1.SplitterDistance = 508;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // rsPanel2
            // 
            this.rsPanel2.Controls.Add(this.dgvKHVTPKTDT);
            this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsPanel2.Location = new System.Drawing.Point(3, 83);
            this.rsPanel2.Name = "rsPanel2";
            this.rsPanel2.Size = new System.Drawing.Size(927, 422);
            this.rsPanel2.TabIndex = 2;
            // 
            // dgvKHVTPKTDT
            // 
            this.dgvKHVTPKTDT.AllowUserToAddRows = false;
            this.dgvKHVTPKTDT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKHVTPKTDT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKHVTPKTDT.BackgroundColor = System.Drawing.Color.White;
            this.dgvKHVTPKTDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKHVTPKTDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKHVTPKTDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKHVTPKTDT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKHVTPKTDT.Location = new System.Drawing.Point(0, 0);
            this.dgvKHVTPKTDT.MultiSelect = false;
            this.dgvKHVTPKTDT.Name = "dgvKHVTPKTDT";
            this.dgvKHVTPKTDT.Size = new System.Drawing.Size(927, 422);
            this.dgvKHVTPKTDT.strZone = "";
            this.dgvKHVTPKTDT.TabIndex = 0;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.chkNotDuyet);
            this.rsPanel1.Controls.Add(this.btRefresh);
            this.rsPanel1.Controls.Add(this.txtThang_Th);
            this.rsPanel1.Controls.Add(this.lbtTen_Tb);
            this.rsPanel1.Controls.Add(this.lbtTen_Nh_Tb);
            this.rsPanel1.Controls.Add(this.txtMa_Bp);
            this.rsPanel1.Controls.Add(this.rsLabel6);
            this.rsPanel1.Controls.Add(this.txtMa_Tb);
            this.rsPanel1.Controls.Add(this.rsLabel5);
            this.rsPanel1.Controls.Add(this.lbtThang_Th);
            this.rsPanel1.Controls.Add(this.txtMa_Nh_Tb);
            this.rsPanel1.Controls.Add(this.txtPt_Bt);
            this.rsPanel1.Controls.Add(this.rsLabel4);
            this.rsPanel1.Controls.Add(this.lbtPt_Bt);
            this.rsPanel1.Controls.Add(this.numNam);
            this.rsPanel1.Controls.Add(this.rsLabel3);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rsPanel1.Location = new System.Drawing.Point(3, 3);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(927, 80);
            this.rsPanel1.TabIndex = 0;
            // 
            // chkNotDuyet
            // 
            this.chkNotDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNotDuyet.AutoSize = true;
            this.chkNotDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotDuyet.ForeColor = System.Drawing.Color.Red;
            this.chkNotDuyet.Location = new System.Drawing.Point(610, 9);
            this.chkNotDuyet.Name = "chkNotDuyet";
            this.chkNotDuyet.Size = new System.Drawing.Size(209, 19);
            this.chkNotDuyet.TabIndex = 159;
            this.chkNotDuyet.Text = "Chỉ thấy chứng từ chưa duyệt";
            this.chkNotDuyet.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(825, 7);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(80, 50);
            this.btRefresh.TabIndex = 157;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "&Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // txtThang_Th
            // 
            this.txtThang_Th.AutoDropDown = null;
            this.txtThang_Th.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtThang_Th.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang_Th.Location = new System.Drawing.Point(392, 35);
            this.txtThang_Th.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtThang_Th.MaxLength = 20;
            this.txtThang_Th.Name = "txtThang_Th";
            this.txtThang_Th.Size = new System.Drawing.Size(62, 23);
            this.txtThang_Th.TabIndex = 156;
            // 
            // lbtTen_Tb
            // 
            this.lbtTen_Tb.AutoEllipsis = true;
            this.lbtTen_Tb.AutoSize = true;
            this.lbtTen_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Tb.Location = new System.Drawing.Point(672, 38);
            this.lbtTen_Tb.Name = "lbtTen_Tb";
            this.lbtTen_Tb.Size = new System.Drawing.Size(63, 17);
            this.lbtTen_Tb.TabIndex = 155;
            this.lbtTen_Tb.Tag = "";
            this.lbtTen_Tb.Text = "Thiết bị";
            this.lbtTen_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbtTen_Nh_Tb
            // 
            this.lbtTen_Nh_Tb.AutoEllipsis = true;
            this.lbtTen_Nh_Tb.AutoSize = true;
            this.lbtTen_Nh_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Nh_Tb.Location = new System.Drawing.Point(672, 10);
            this.lbtTen_Nh_Tb.Name = "lbtTen_Nh_Tb";
            this.lbtTen_Nh_Tb.Size = new System.Drawing.Size(94, 17);
            this.lbtTen_Nh_Tb.TabIndex = 154;
            this.lbtTen_Nh_Tb.Tag = "";
            this.lbtTen_Nh_Tb.Text = "Cụm thiết bị";
            this.lbtTen_Nh_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.AutoDropDown = null;
            this.txtMa_Bp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Bp.Location = new System.Drawing.Point(138, 38);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.MaxLength = 20;
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(62, 23);
            this.txtMa_Bp.TabIndex = 152;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel6.Location = new System.Drawing.Point(72, 41);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(68, 17);
            this.rsLabel6.TabIndex = 153;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Bộ phận";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMa_Tb
            // 
            this.txtMa_Tb.AutoDropDown = null;
            this.txtMa_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Tb.Location = new System.Drawing.Point(580, 34);
            this.txtMa_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb.MaxLength = 20;
            this.txtMa_Tb.Name = "txtMa_Tb";
            this.txtMa_Tb.Size = new System.Drawing.Size(87, 23);
            this.txtMa_Tb.TabIndex = 152;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel5.Location = new System.Drawing.Point(473, 38);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(63, 17);
            this.rsLabel5.TabIndex = 153;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Thiết bị";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbtThang_Th
            // 
            this.lbtThang_Th.AutoEllipsis = true;
            this.lbtThang_Th.AutoSize = true;
            this.lbtThang_Th.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtThang_Th.Location = new System.Drawing.Point(230, 37);
            this.lbtThang_Th.Name = "lbtThang_Th";
            this.lbtThang_Th.Size = new System.Drawing.Size(126, 17);
            this.lbtThang_Th.TabIndex = 150;
            this.lbtThang_Th.Text = "Tháng thực hiện";
            this.lbtThang_Th.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Nh_Tb
            // 
            this.txtMa_Nh_Tb.AutoDropDown = null;
            this.txtMa_Nh_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Nh_Tb.Location = new System.Drawing.Point(580, 6);
            this.txtMa_Nh_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Tb.MaxLength = 20;
            this.txtMa_Nh_Tb.Name = "txtMa_Nh_Tb";
            this.txtMa_Nh_Tb.Size = new System.Drawing.Size(87, 23);
            this.txtMa_Nh_Tb.TabIndex = 148;
            // 
            // txtPt_Bt
            // 
            this.txtPt_Bt.AutoDropDown = null;
            this.txtPt_Bt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPt_Bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPt_Bt.Location = new System.Drawing.Point(392, 7);
            this.txtPt_Bt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPt_Bt.MaxLength = 20;
            this.txtPt_Bt.Name = "txtPt_Bt";
            this.txtPt_Bt.Size = new System.Drawing.Size(62, 23);
            this.txtPt_Bt.TabIndex = 148;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.Location = new System.Drawing.Point(473, 10);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(94, 17);
            this.rsLabel4.TabIndex = 149;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Cụm thiết bị";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtPt_Bt
            // 
            this.lbtPt_Bt.AutoEllipsis = true;
            this.lbtPt_Bt.AutoSize = true;
            this.lbtPt_Bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtPt_Bt.Location = new System.Drawing.Point(218, 11);
            this.lbtPt_Bt.Name = "lbtPt_Bt";
            this.lbtPt_Bt.Size = new System.Drawing.Size(151, 17);
            this.lbtPt_Bt.TabIndex = 149;
            this.lbtPt_Bt.Tag = "";
            this.lbtPt_Bt.Text = "Phương thức bảo trì";
            this.lbtPt_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNam
            // 
            this.numNam.AcceptsTab = true;
            this.numNam.AutoDropDown = null;
            this.numNam.bFormat = true;
            this.numNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNam.Location = new System.Drawing.Point(138, 7);
            this.numNam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNam.Multiline = true;
            this.numNam.Name = "numNam";
            this.numNam.Scale = 0;
            this.numNam.Size = new System.Drawing.Size(62, 25);
            this.numNam.TabIndex = 23;
            this.numNam.Text = "0";
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam.Value = 0D;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(26, 11);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(113, 17);
            this.rsLabel3.TabIndex = 22;
            this.rsLabel3.Text = "Năm lập KHBT";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "(none)";
            this.btPrint.Location = new System.Drawing.Point(154, 5);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(80, 39);
            this.btPrint.TabIndex = 158;
            this.btPrint.Tag = "";
            this.btPrint.Text = "&In";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageKey = "(none)";
            this.btSave.Location = new System.Drawing.Point(240, 4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(80, 39);
            this.btSave.TabIndex = 158;
            this.btSave.Tag = "";
            this.btSave.Text = "&Đồng ý";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "(none)";
            this.btExit.Location = new System.Drawing.Point(326, 5);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(80, 39);
            this.btExit.TabIndex = 158;
            this.btExit.Tag = "";
            this.btExit.Text = "&Thoát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // chkDuyet
            // 
            this.chkDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDuyet.ForeColor = System.Drawing.Color.Red;
            this.chkDuyet.Location = new System.Drawing.Point(4, 4);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(121, 19);
            this.chkDuyet.TabIndex = 67;
            this.chkDuyet.Text = "Duyệt chứng từ";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // frmDuyetKHBT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.rsSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDuyetKHBT";
            this.Text = "frmDuyetKHBT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.rsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHVTPKTDT)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            this.rsPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
        private RosySystem.Control.rsPanel rsPanel1;
		private RosySystem.Control.rsPanel rsPanel2;
        private RosySystem.Control.rsDataGridView dgvKHVTPKTDT;
        private RosySystem.Control.rsTextBoxNumber numNam;
        private RosySystem.Control.rsLabel rsLabel3;
        public RosySystem.Control.rsCheckbox chkDuyet;
        private RosySystem.Control.rsLabel lbtTen_Tb;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        private RosySystem.Control.rsTextBox txtMa_Tb;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsLabel lbtThang_Th;
        private RosySystem.Control.rsTextBox txtMa_Nh_Tb;
        private RosySystem.Control.rsTextBox txtPt_Bt;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel lbtPt_Bt;
        private RosySystem.Control.rsTextBox txtThang_Th;
        private RosySystem.Customize.btNew btRefresh;
        private RosySystem.Customize.btNew btPrint;
        private RosySystem.Customize.btNew btSave;
        private RosySystem.Customize.btNew btExit;
        private RosySystem.Control.rsTextBox txtMa_Bp;
        private RosySystem.Control.rsLabel rsLabel6;
        public RosySystem.Control.rsCheckbox chkNotDuyet;
	}
}