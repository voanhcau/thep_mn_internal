namespace RosyModule.Machinery
{
    partial class frmTHBTDK
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
            this.dgvKHBTDK = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.lbtTen_Phan_Loai_Cv = new RosySystem.Control.rsLabel();
            this.lbtTen_Tb = new RosySystem.Control.rsLabel();
            this.txtPhan_Loai_Cv = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtNgay_Color = new RosySystem.Control.rsTextBox();
            this.txtMa_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.lbtTen_DotBT = new RosySystem.Control.rsLabel();
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabel();
            this.txtMa_Nh_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.cboDot_BT = new RosySystem.Control.rsComboBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.chkIs_Kt = new RosySystem.Control.rsCheckbox();
            this.btSave = new RosySystem.Customize.btNew();
            this.btExit = new RosySystem.Customize.btExit();
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
            this.rsSplitContainer1.Panel2.Controls.Add(this.chkIs_Kt);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btSave);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btExit);
            this.rsSplitContainer1.Size = new System.Drawing.Size(962, 562);
            this.rsSplitContainer1.SplitterDistance = 479;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // rsPanel2
            // 
            this.rsPanel2.Controls.Add(this.dgvKHBTDK);
            this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsPanel2.Location = new System.Drawing.Point(3, 65);
            this.rsPanel2.Name = "rsPanel2";
            this.rsPanel2.Size = new System.Drawing.Size(956, 411);
            this.rsPanel2.TabIndex = 2;
            // 
            // dgvKHBTDK
            // 
            this.dgvKHBTDK.AllowUserToAddRows = false;
            this.dgvKHBTDK.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKHBTDK.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKHBTDK.BackgroundColor = System.Drawing.Color.White;
            this.dgvKHBTDK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKHBTDK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKHBTDK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKHBTDK.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKHBTDK.Location = new System.Drawing.Point(0, 0);
            this.dgvKHBTDK.MultiSelect = false;
            this.dgvKHBTDK.Name = "dgvKHBTDK";
            this.dgvKHBTDK.ReadOnly = true;
            this.dgvKHBTDK.Size = new System.Drawing.Size(956, 411);
            this.dgvKHBTDK.strZone = "";
            this.dgvKHBTDK.TabIndex = 0;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.lbtTen_Phan_Loai_Cv);
            this.rsPanel1.Controls.Add(this.lbtTen_Tb);
            this.rsPanel1.Controls.Add(this.txtPhan_Loai_Cv);
            this.rsPanel1.Controls.Add(this.rsLabel2);
            this.rsPanel1.Controls.Add(this.txtNgay_Color);
            this.rsPanel1.Controls.Add(this.txtMa_Tb);
            this.rsPanel1.Controls.Add(this.rsLabel3);
            this.rsPanel1.Controls.Add(this.rsLabel5);
            this.rsPanel1.Controls.Add(this.lbtTen_DotBT);
            this.rsPanel1.Controls.Add(this.lbtTen_Nh_Tb);
            this.rsPanel1.Controls.Add(this.txtMa_Nh_Tb);
            this.rsPanel1.Controls.Add(this.rsLabel4);
            this.rsPanel1.Controls.Add(this.cboDot_BT);
            this.rsPanel1.Controls.Add(this.rsLabel1);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rsPanel1.Location = new System.Drawing.Point(3, 3);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(956, 62);
            this.rsPanel1.TabIndex = 0;
            // 
            // lbtTen_Phan_Loai_Cv
            // 
            this.lbtTen_Phan_Loai_Cv.AutoEllipsis = true;
            this.lbtTen_Phan_Loai_Cv.AutoSize = true;
            this.lbtTen_Phan_Loai_Cv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Phan_Loai_Cv.Location = new System.Drawing.Point(639, 37);
            this.lbtTen_Phan_Loai_Cv.Name = "lbtTen_Phan_Loai_Cv";
            this.lbtTen_Phan_Loai_Cv.Size = new System.Drawing.Size(64, 17);
            this.lbtTen_Phan_Loai_Cv.TabIndex = 160;
            this.lbtTen_Phan_Loai_Cv.Tag = "";
            this.lbtTen_Phan_Loai_Cv.Text = "Loại CV";
            this.lbtTen_Phan_Loai_Cv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbtTen_Tb
            // 
            this.lbtTen_Tb.AutoEllipsis = true;
            this.lbtTen_Tb.AutoSize = true;
            this.lbtTen_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Tb.Location = new System.Drawing.Point(639, 9);
            this.lbtTen_Tb.Name = "lbtTen_Tb";
            this.lbtTen_Tb.Size = new System.Drawing.Size(63, 17);
            this.lbtTen_Tb.TabIndex = 160;
            this.lbtTen_Tb.Tag = "";
            this.lbtTen_Tb.Text = "Thiết bị";
            this.lbtTen_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhan_Loai_Cv
            // 
            this.txtPhan_Loai_Cv.AutoDropDown = null;
            this.txtPhan_Loai_Cv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhan_Loai_Cv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhan_Loai_Cv.Location = new System.Drawing.Point(548, 33);
            this.txtPhan_Loai_Cv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPhan_Loai_Cv.MaxLength = 20;
            this.txtPhan_Loai_Cv.Name = "txtPhan_Loai_Cv";
            this.txtPhan_Loai_Cv.Size = new System.Drawing.Size(87, 23);
            this.txtPhan_Loai_Cv.TabIndex = 158;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(441, 37);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(101, 17);
            this.rsLabel2.TabIndex = 159;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Phân loại CV";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgay_Color
            // 
            this.txtNgay_Color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgay_Color.AutoDropDown = null;
            this.txtNgay_Color.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNgay_Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgay_Color.Location = new System.Drawing.Point(807, 8);
            this.txtNgay_Color.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Color.MaxLength = 20;
            this.txtNgay_Color.Name = "txtNgay_Color";
            this.txtNgay_Color.Size = new System.Drawing.Size(141, 23);
            this.txtNgay_Color.TabIndex = 158;
            this.txtNgay_Color.Text = "1,2,5,6";
            // 
            // txtMa_Tb
            // 
            this.txtMa_Tb.AutoDropDown = null;
            this.txtMa_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Tb.Location = new System.Drawing.Point(548, 5);
            this.txtMa_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb.MaxLength = 20;
            this.txtMa_Tb.Name = "txtMa_Tb";
            this.txtMa_Tb.Size = new System.Drawing.Size(87, 23);
            this.txtMa_Tb.TabIndex = 158;
            // 
            // rsLabel3
            // 
            this.rsLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(703, 10);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(99, 17);
            this.rsLabel3.TabIndex = 159;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Ngày tô màu";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel5.Location = new System.Drawing.Point(441, 9);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(63, 17);
            this.rsLabel5.TabIndex = 159;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Thiết bị";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbtTen_DotBT
            // 
            this.lbtTen_DotBT.AutoEllipsis = true;
            this.lbtTen_DotBT.AutoSize = true;
            this.lbtTen_DotBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_DotBT.Location = new System.Drawing.Point(241, 8);
            this.lbtTen_DotBT.Name = "lbtTen_DotBT";
            this.lbtTen_DotBT.Size = new System.Drawing.Size(58, 17);
            this.lbtTen_DotBT.TabIndex = 157;
            this.lbtTen_DotBT.Tag = "";
            this.lbtTen_DotBT.Text = "Đợt BT";
            this.lbtTen_DotBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Nh_Tb
            // 
            this.lbtTen_Nh_Tb.AutoEllipsis = true;
            this.lbtTen_Nh_Tb.AutoSize = true;
            this.lbtTen_Nh_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Nh_Tb.Location = new System.Drawing.Point(205, 37);
            this.lbtTen_Nh_Tb.Name = "lbtTen_Nh_Tb";
            this.lbtTen_Nh_Tb.Size = new System.Drawing.Size(94, 17);
            this.lbtTen_Nh_Tb.TabIndex = 157;
            this.lbtTen_Nh_Tb.Tag = "";
            this.lbtTen_Nh_Tb.Text = "Cụm thiết bị";
            this.lbtTen_Nh_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Nh_Tb
            // 
            this.txtMa_Nh_Tb.AutoDropDown = null;
            this.txtMa_Nh_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Nh_Tb.Location = new System.Drawing.Point(113, 33);
            this.txtMa_Nh_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Tb.MaxLength = 20;
            this.txtMa_Nh_Tb.Name = "txtMa_Nh_Tb";
            this.txtMa_Nh_Tb.Size = new System.Drawing.Size(87, 23);
            this.txtMa_Nh_Tb.TabIndex = 155;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.Location = new System.Drawing.Point(6, 37);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(94, 17);
            this.rsLabel4.TabIndex = 156;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Cụm thiết bị";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDot_BT
            // 
            this.cboDot_BT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDot_BT.DropDownHeight = 147;
            this.cboDot_BT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDot_BT.FormattingEnabled = true;
            this.cboDot_BT.IntegralHeight = false;
            this.cboDot_BT.Location = new System.Drawing.Point(113, 5);
            this.cboDot_BT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboDot_BT.Name = "cboDot_BT";
            this.cboDot_BT.Size = new System.Drawing.Size(123, 25);
            this.cboDot_BT.TabIndex = 10;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(7, 7);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(109, 17);
            this.rsLabel1.TabIndex = 7;
            this.rsLabel1.Text = "Mã đợt bảo trì";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIs_Kt
            // 
            this.chkIs_Kt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIs_Kt.AutoSize = true;
            this.chkIs_Kt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Kt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkIs_Kt.Location = new System.Drawing.Point(298, 14);
            this.chkIs_Kt.Name = "chkIs_Kt";
            this.chkIs_Kt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIs_Kt.Size = new System.Drawing.Size(205, 28);
            this.chkIs_Kt.TabIndex = 71;
            this.chkIs_Kt.TabStop = false;
            this.chkIs_Kt.Text = "Kết thúc đợt bảo trì";
            this.chkIs_Kt.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageKey = "(none)";
            this.btSave.Location = new System.Drawing.Point(3, 4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(93, 50);
            this.btSave.TabIndex = 5;
            this.btSave.Tag = "";
            this.btSave.Text = "&Lưu dữ liệu kết thúc bảo trì";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(102, 6);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(93, 50);
            this.btExit.TabIndex = 2;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Th&oát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // frmTHBTDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 562);
            this.Controls.Add(this.rsSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmTHBTDK";
            this.Object_ID = "THBTDK";
            this.Text = "frmTHBTDK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            this.rsSplitContainer1.Panel2.PerformLayout();
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
        private RosySystem.Control.rsComboBox cboDot_BT;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Customize.btNew btSave;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        private RosySystem.Control.rsTextBox txtMa_Nh_Tb;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel lbtTen_Phan_Loai_Cv;
        private RosySystem.Control.rsLabel lbtTen_Tb;
        private RosySystem.Control.rsTextBox txtPhan_Loai_Cv;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtMa_Tb;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsLabel lbtTen_DotBT;
        private RosySystem.Control.rsCheckbox chkIs_Kt;
        private RosySystem.Control.rsTextBox txtNgay_Color;
        private RosySystem.Control.rsLabel rsLabel3;
    }
}