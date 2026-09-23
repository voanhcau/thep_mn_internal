namespace RosyModule.Salary
{
    partial class frmChamCongCheck
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btThoat = new RosySystem.Control.rsButton();
            this.lbtKip2 = new RosySystem.Control.rsLabel();
            this.dteNgay_Cham_Cong = new RosySystem.Control.rsDateTime();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.lbtKip1 = new RosySystem.Control.rsLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.timer_Check = new System.Windows.Forms.Timer(this.components);
            this.rdbRef = new System.Windows.Forms.RadioButton();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.btThucHien = new RosySystem.Control.rsButton();
            this.rdbNotRef = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdbNotRef);
            this.splitContainer1.Panel1.Controls.Add(this.rdbRef);
            this.splitContainer1.Panel1.Controls.Add(this.btThucHien);
            this.splitContainer1.Panel1.Controls.Add(this.btRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.btThoat);
            this.splitContainer1.Panel1.Controls.Add(this.lbtKip2);
            this.splitContainer1.Panel1.Controls.Add(this.dteNgay_Cham_Cong);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.lbtKip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1122, 683);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThoat.ImageKey = "add";
            this.btThoat.Location = new System.Drawing.Point(1027, 2);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(83, 51);
            this.btThoat.TabIndex = 77;
            this.btThoat.Tag = "";
            this.btThoat.Text = "&Thoát";
            this.btThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btThoat.UseVisualStyleBackColor = true;
            // 
            // lbtKip2
            // 
            this.lbtKip2.AutoEllipsis = true;
            this.lbtKip2.AutoSize = true;
            this.lbtKip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtKip2.ForeColor = System.Drawing.Color.Red;
            this.lbtKip2.Location = new System.Drawing.Point(213, 32);
            this.lbtKip2.Name = "lbtKip2";
            this.lbtKip2.Size = new System.Drawing.Size(38, 13);
            this.lbtKip2.TabIndex = 76;
            this.lbtKip2.Tag = "";
            this.lbtKip2.Text = "Kíp 1";
            this.lbtKip2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Cham_Cong
            // 
            this.dteNgay_Cham_Cong.bAllowEmpty = false;
            this.dteNgay_Cham_Cong.bSelectOnFocus = false;
            this.dteNgay_Cham_Cong.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Cham_Cong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Cham_Cong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Cham_Cong.Location = new System.Drawing.Point(114, 14);
            this.dteNgay_Cham_Cong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Cham_Cong.Mask = "00/00/0000";
            this.dteNgay_Cham_Cong.Name = "dteNgay_Cham_Cong";
            this.dteNgay_Cham_Cong.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Cham_Cong.TabIndex = 72;
            this.dteNgay_Cham_Cong.Text = "00002019";
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(12, 17);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(102, 13);
            this.rsLabel3.TabIndex = 74;
            this.rsLabel3.Text = "Ngày chấm công";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtKip1
            // 
            this.lbtKip1.AutoEllipsis = true;
            this.lbtKip1.AutoSize = true;
            this.lbtKip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtKip1.ForeColor = System.Drawing.Color.Red;
            this.lbtKip1.Location = new System.Drawing.Point(213, 12);
            this.lbtKip1.Name = "lbtKip1";
            this.lbtKip1.Size = new System.Drawing.Size(38, 13);
            this.lbtKip1.TabIndex = 71;
            this.lbtKip1.Tag = "";
            this.lbtKip1.Text = "Kíp 1";
            this.lbtKip1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer2.Size = new System.Drawing.Size(1122, 625);
            this.splitContainer2.SplitterDistance = 653;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 625);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(645, 599);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách CBNV đi ca";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(645, 518);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Danh sách CBNV đi hành chính";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(465, 625);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(457, 599);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Danh sách CBNV đi sai ca";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // timer_Check
            // 
            this.timer_Check.Interval = 10000;
            // 
            // rdbRef
            // 
            this.rdbRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbRef.AutoSize = true;
            this.rdbRef.Location = new System.Drawing.Point(689, 7);
            this.rdbRef.Name = "rdbRef";
            this.rdbRef.Size = new System.Drawing.Size(159, 17);
            this.rdbRef.TabIndex = 78;
            this.rdbRef.TabStop = true;
            this.rdbRef.Text = "Refresh liên tục trong 1 phút";
            this.rdbRef.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "add";
            this.btRefresh.Location = new System.Drawing.Point(940, 2);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(83, 51);
            this.btRefresh.TabIndex = 77;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "&Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btThucHien
            // 
            this.btThucHien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btThucHien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThucHien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThucHien.ImageKey = "add";
            this.btThucHien.Location = new System.Drawing.Point(853, 2);
            this.btThucHien.Name = "btThucHien";
            this.btThucHien.Size = new System.Drawing.Size(83, 51);
            this.btThucHien.TabIndex = 77;
            this.btThucHien.Tag = "";
            this.btThucHien.Text = "&Thực hiện";
            this.btThucHien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btThucHien.UseVisualStyleBackColor = true;
            // 
            // rdbNotRef
            // 
            this.rdbNotRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbNotRef.AutoSize = true;
            this.rdbNotRef.Location = new System.Drawing.Point(689, 28);
            this.rdbNotRef.Name = "rdbNotRef";
            this.rdbNotRef.Size = new System.Drawing.Size(118, 17);
            this.rdbNotRef.TabIndex = 79;
            this.rdbNotRef.TabStop = true;
            this.rdbNotRef.Text = "Bỏ Refresh tự động";
            this.rdbNotRef.UseVisualStyleBackColor = true;
            // 
            // frmChamCongCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 683);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmChamCongCheck";
            this.Text = "frmChamCongCheck";
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
            this.tabControl1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Control.rsDateTime dteNgay_Cham_Cong;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel lbtKip2;
        private RosySystem.Control.rsLabel lbtKip1;
        private RosySystem.Control.rsButton btThoat;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton rdbRef;
        private RosySystem.Control.rsButton btThucHien;
        private RosySystem.Control.rsButton btRefresh;
        private System.Windows.Forms.Timer timer_Check;
        private System.Windows.Forms.RadioButton rdbNotRef;
	}
}