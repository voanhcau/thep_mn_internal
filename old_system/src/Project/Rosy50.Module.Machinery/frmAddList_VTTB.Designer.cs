namespace RosyModule.Machinery
{
    partial class frmAddList_VTTB
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
            this.txtMa_Tb_Nhom = new RosySystem.Control.rsTextBox();
            this.lbMa_Tb_Nh = new RosySystem.Control.rsLabel();
            this.btRefresh = new RosySystem.Customize.btNew();
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbtTen_Tb_Nhom = new RosySystem.Control.rsLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMa_Tb_Nhom
            // 
            this.txtMa_Tb_Nhom.AutoDropDown = null;
            this.txtMa_Tb_Nhom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb_Nhom.Location = new System.Drawing.Point(74, 12);
            this.txtMa_Tb_Nhom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb_Nhom.MaxLength = 20;
            this.txtMa_Tb_Nhom.Name = "txtMa_Tb_Nhom";
            this.txtMa_Tb_Nhom.Size = new System.Drawing.Size(291, 20);
            this.txtMa_Tb_Nhom.TabIndex = 135;
            // 
            // lbMa_Tb_Nh
            // 
            this.lbMa_Tb_Nh.AutoEllipsis = true;
            this.lbMa_Tb_Nh.AutoSize = true;
            this.lbMa_Tb_Nh.Location = new System.Drawing.Point(7, 15);
            this.lbMa_Tb_Nh.Name = "lbMa_Tb_Nh";
            this.lbMa_Tb_Nh.Size = new System.Drawing.Size(62, 13);
            this.lbMa_Tb_Nh.TabIndex = 136;
            this.lbMa_Tb_Nh.Tag = "Ma_Cum";
            this.lbMa_Tb_Nh.Text = "Cụm thiết bị";
            this.lbMa_Tb_Nh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(1262, 6);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(88, 37);
            this.btRefresh.TabIndex = 28;
            this.btRefresh.Tag = "Refresh ";
            this.btRefresh.Text = "&Refresh (F5)";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Location = new System.Drawing.Point(5, 0);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(1364, 82);
            this.rsTabControl1.TabIndex = 137;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMa_Tb_Nhom);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Controls.Add(this.lbtTen_Tb_Nhom);
            this.tabPage1.Controls.Add(this.lbMa_Tb_Nh);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1356, 56);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chọn dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbtTen_Tb_Nhom
            // 
            this.lbtTen_Tb_Nhom.AutoEllipsis = true;
            this.lbtTen_Tb_Nhom.AutoSize = true;
            this.lbtTen_Tb_Nhom.Location = new System.Drawing.Point(370, 15);
            this.lbtTen_Tb_Nhom.Name = "lbtTen_Tb_Nhom";
            this.lbtTen_Tb_Nhom.Size = new System.Drawing.Size(62, 13);
            this.lbtTen_Tb_Nhom.TabIndex = 136;
            this.lbtTen_Tb_Nhom.Tag = "Ma_Cum";
            this.lbtTen_Tb_Nhom.Text = "Cụm thiết bị";
            this.lbtTen_Tb_Nhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 88);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(1358, 642);
            this.splitContainer1.SplitterDistance = 517;
            this.splitContainer1.SplitterWidth = 100;
            this.splitContainer1.TabIndex = 138;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(1188, 736);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            this.btgAccept.TabIndex = 139;
            // 
            // frmAddList_VTTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 785);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAddList_VTTB";
            this.Text = "AddList vật tư thiết bị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Control.rsTextBox txtMa_Tb_Nhom;
        private RosySystem.Control.rsLabel lbMa_Tb_Nh;
        private RosySystem.Customize.btNew btRefresh;
        private RosySystem.Control.rsTabControl rsTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Control.rsLabel lbtTen_Tb_Nhom;
        private RosySystem.Customize.btgAccept btgAccept;
	}
}