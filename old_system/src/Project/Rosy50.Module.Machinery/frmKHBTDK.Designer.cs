namespace RosyModule.Machinery
{
	partial class frmKHBTDK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.rsPanel2 = new RosySystem.Control.rsPanel();
            this.dgvKHBTDK = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.numNam = new RosySystem.Control.rsTextBoxNumber();
            this.cboDot_BT = new RosySystem.Control.rsComboBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btPrint = new RosySystem.Customize.btNew();
            this.btDuyetGD = new RosySystem.Customize.btNew();
            this.btUpdate_KQ = new RosySystem.Customize.btNew();
            this.btDelete = new RosySystem.Customize.btNew();
            this.btSave = new RosySystem.Customize.btNew();
            this.btDuyetKTDT = new RosySystem.Customize.btNew();
            this.btCreate = new RosySystem.Customize.btNew();
            this.btExit = new RosySystem.Customize.btExit();
            this.lbtTen_DotBT = new RosySystem.Control.rsLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.rsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHBTDK)).BeginInit();
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
            this.rsSplitContainer1.Panel2.Controls.Add(this.btDuyetGD);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btUpdate_KQ);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btDelete);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btSave);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btDuyetKTDT);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btCreate);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btExit);
            this.rsSplitContainer1.Size = new System.Drawing.Size(962, 562);
            this.rsSplitContainer1.SplitterDistance = 479;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // rsPanel2
            // 
            this.rsPanel2.Controls.Add(this.dgvKHBTDK);
            this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsPanel2.Location = new System.Drawing.Point(3, 48);
            this.rsPanel2.Name = "rsPanel2";
            this.rsPanel2.Size = new System.Drawing.Size(956, 428);
            this.rsPanel2.TabIndex = 2;
            // 
            // dgvKHBTDK
            // 
            this.dgvKHBTDK.AllowUserToAddRows = false;
            this.dgvKHBTDK.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKHBTDK.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKHBTDK.BackgroundColor = System.Drawing.Color.White;
            this.dgvKHBTDK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKHBTDK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKHBTDK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKHBTDK.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKHBTDK.Location = new System.Drawing.Point(0, 0);
            this.dgvKHBTDK.MultiSelect = false;
            this.dgvKHBTDK.Name = "dgvKHBTDK";
            this.dgvKHBTDK.ReadOnly = true;
            this.dgvKHBTDK.Size = new System.Drawing.Size(956, 428);
            this.dgvKHBTDK.strZone = "";
            this.dgvKHBTDK.TabIndex = 0;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.lbtTen_DotBT);
            this.rsPanel1.Controls.Add(this.numNam);
            this.rsPanel1.Controls.Add(this.cboDot_BT);
            this.rsPanel1.Controls.Add(this.rsLabel2);
            this.rsPanel1.Controls.Add(this.rsLabel1);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rsPanel1.Location = new System.Drawing.Point(3, 3);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(956, 45);
            this.rsPanel1.TabIndex = 0;
            // 
            // numNam
            // 
            this.numNam.AutoDropDown = null;
            this.numNam.bFormat = true;
            this.numNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNam.Location = new System.Drawing.Point(112, 11);
            this.numNam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNam.Name = "numNam";
            this.numNam.Scale = 0;
            this.numNam.Size = new System.Drawing.Size(52, 23);
            this.numNam.TabIndex = 282;
            this.numNam.Text = "0";
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam.Value = 0D;
            // 
            // cboDot_BT
            // 
            this.cboDot_BT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDot_BT.DropDownHeight = 147;
            this.cboDot_BT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDot_BT.FormattingEnabled = true;
            this.cboDot_BT.IntegralHeight = false;
            this.cboDot_BT.Location = new System.Drawing.Point(295, 11);
            this.cboDot_BT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboDot_BT.Name = "cboDot_BT";
            this.cboDot_BT.Size = new System.Drawing.Size(123, 25);
            this.cboDot_BT.TabIndex = 10;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(16, 16);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(104, 17);
            this.rsLabel2.TabIndex = 7;
            this.rsLabel2.Text = "Năm làm việc";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(208, 13);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(85, 17);
            this.rsLabel1.TabIndex = 7;
            this.rsLabel1.Text = "Đợt bảo trì";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "(none)";
            this.btPrint.Location = new System.Drawing.Point(572, 2);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(93, 50);
            this.btPrint.TabIndex = 8;
            this.btPrint.Tag = "";
            this.btPrint.Text = "&In phiếu và báo cáo BTDK ";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btDuyetGD
            // 
            this.btDuyetGD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDuyetGD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDuyetGD.ImageKey = "(none)";
            this.btDuyetGD.Location = new System.Drawing.Point(478, 2);
            this.btDuyetGD.Name = "btDuyetGD";
            this.btDuyetGD.Size = new System.Drawing.Size(93, 50);
            this.btDuyetGD.TabIndex = 6;
            this.btDuyetGD.Tag = "";
            this.btDuyetGD.Text = "&Duyệt Tổng Giám Đốc";
            this.btDuyetGD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDuyetGD.UseVisualStyleBackColor = true;
            // 
            // btUpdate_KQ
            // 
            this.btUpdate_KQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btUpdate_KQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpdate_KQ.ImageKey = "(none)";
            this.btUpdate_KQ.Location = new System.Drawing.Point(289, 2);
            this.btUpdate_KQ.Name = "btUpdate_KQ";
            this.btUpdate_KQ.Size = new System.Drawing.Size(93, 50);
            this.btUpdate_KQ.TabIndex = 5;
            this.btUpdate_KQ.Tag = "";
            this.btUpdate_KQ.Text = "&Cập nhật kết quả";
            this.btUpdate_KQ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdate_KQ.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "(none)";
            this.btDelete.Location = new System.Drawing.Point(194, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(93, 50);
            this.btDelete.TabIndex = 5;
            this.btDelete.Tag = "";
            this.btDelete.Text = "&Xóa phiếu";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageKey = "(none)";
            this.btSave.Location = new System.Drawing.Point(98, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(93, 50);
            this.btSave.TabIndex = 5;
            this.btSave.Tag = "";
            this.btSave.Text = "&Lưu";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btDuyetKTDT
            // 
            this.btDuyetKTDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDuyetKTDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDuyetKTDT.ImageKey = "(none)";
            this.btDuyetKTDT.Location = new System.Drawing.Point(384, 2);
            this.btDuyetKTDT.Name = "btDuyetKTDT";
            this.btDuyetKTDT.Size = new System.Drawing.Size(93, 50);
            this.btDuyetKTDT.TabIndex = 5;
            this.btDuyetKTDT.Tag = "";
            this.btDuyetKTDT.Text = "&Duyệt PKTDT";
            this.btDuyetKTDT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDuyetKTDT.UseVisualStyleBackColor = true;
            // 
            // btCreate
            // 
            this.btCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCreate.ImageKey = "New.png";
            this.btCreate.Location = new System.Drawing.Point(4, 1);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(93, 50);
            this.btCreate.TabIndex = 4;
            this.btCreate.Tag = "";
            this.btCreate.Text = "&Tạo chứng từ";
            this.btCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCreate.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(668, 2);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(93, 50);
            this.btExit.TabIndex = 2;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Th&oát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // lbtTen_DotBT
            // 
            this.lbtTen_DotBT.AutoEllipsis = true;
            this.lbtTen_DotBT.AutoSize = true;
            this.lbtTen_DotBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_DotBT.Location = new System.Drawing.Point(423, 14);
            this.lbtTen_DotBT.Name = "lbtTen_DotBT";
            this.lbtTen_DotBT.Size = new System.Drawing.Size(58, 17);
            this.lbtTen_DotBT.TabIndex = 283;
            this.lbtTen_DotBT.Tag = "";
            this.lbtTen_DotBT.Text = "Đợt BT";
            this.lbtTen_DotBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmKHBTDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 562);
            this.Controls.Add(this.rsSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmKHBTDK";
            this.Object_ID = "KHBTDK";
            this.Text = "frmKHBTDK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.rsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHBTDK)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            this.rsPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
        private RosySystem.Control.rsPanel rsPanel1;
        private RosySystem.Customize.btExit btExit;
		private RosySystem.Control.rsPanel rsPanel2;
		private RosySystem.Control.rsDataGridView dgvKHBTDK;
        private RosySystem.Customize.btNew btPrint;
        private RosySystem.Customize.btNew btDuyetGD;
        private RosySystem.Customize.btNew btDuyetKTDT;
        private RosySystem.Customize.btNew btCreate;
        private RosySystem.Control.rsComboBox cboDot_BT;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numNam;
        private RosySystem.Customize.btNew btSave;
        private RosySystem.Customize.btNew btUpdate_KQ;
        private RosySystem.Customize.btNew btDelete;
        private RosySystem.Control.rsLabel lbtTen_DotBT;
	}
}