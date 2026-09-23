namespace RosyModule.Machinery
{
    partial class frmCopyCVBT_Nam
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
            this.btRefresh = new RosySystem.Customize.btNew();
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMa_Tb_Copy = new RosySystem.Control.rsTextBox();
            this.lbtTen_Tb_Copy = new RosySystem.Control.rsLabel();
            this.txtMa_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Tb = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.numNam = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.numNam_Copy = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.chkCopy_Vt = new RosySystem.Control.rsCheckbox();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(967, 6);
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
            this.rsTabControl1.Location = new System.Drawing.Point(9, 12);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(1069, 113);
            this.rsTabControl1.TabIndex = 137;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkCopy_Vt);
            this.tabPage1.Controls.Add(this.numNam_Copy);
            this.tabPage1.Controls.Add(this.rsLabel4);
            this.tabPage1.Controls.Add(this.numNam);
            this.tabPage1.Controls.Add(this.rsLabel3);
            this.tabPage1.Controls.Add(this.txtMa_Tb_Copy);
            this.tabPage1.Controls.Add(this.lbtTen_Tb_Copy);
            this.tabPage1.Controls.Add(this.txtMa_Tb);
            this.tabPage1.Controls.Add(this.rsLabel1);
            this.tabPage1.Controls.Add(this.lbtTen_Tb);
            this.tabPage1.Controls.Add(this.rsLabel2);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1061, 87);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chọn dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMa_Tb_Copy
            // 
            this.txtMa_Tb_Copy.AutoDropDown = null;
            this.txtMa_Tb_Copy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb_Copy.Location = new System.Drawing.Point(311, 37);
            this.txtMa_Tb_Copy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb_Copy.MaxLength = 20;
            this.txtMa_Tb_Copy.Name = "txtMa_Tb_Copy";
            this.txtMa_Tb_Copy.Size = new System.Drawing.Size(155, 20);
            this.txtMa_Tb_Copy.TabIndex = 1;
            // 
            // lbtTen_Tb_Copy
            // 
            this.lbtTen_Tb_Copy.AutoEllipsis = true;
            this.lbtTen_Tb_Copy.AutoSize = true;
            this.lbtTen_Tb_Copy.Location = new System.Drawing.Point(471, 40);
            this.lbtTen_Tb_Copy.Name = "lbtTen_Tb_Copy";
            this.lbtTen_Tb_Copy.Size = new System.Drawing.Size(89, 13);
            this.lbtTen_Tb_Copy.TabIndex = 139;
            this.lbtTen_Tb_Copy.Tag = "";
            this.lbtTen_Tb_Copy.Text = "Tên nhóm thiết bị";
            this.lbtTen_Tb_Copy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Tb
            // 
            this.txtMa_Tb.AutoDropDown = null;
            this.txtMa_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb.Location = new System.Drawing.Point(311, 10);
            this.txtMa_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb.MaxLength = 20;
            this.txtMa_Tb.Name = "txtMa_Tb";
            this.txtMa_Tb.Size = new System.Drawing.Size(155, 20);
            this.txtMa_Tb.TabIndex = 0;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(200, 40);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(110, 13);
            this.rsLabel1.TabIndex = 138;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mã thiết bị được copy";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tb
            // 
            this.lbtTen_Tb.AutoEllipsis = true;
            this.lbtTen_Tb.AutoSize = true;
            this.lbtTen_Tb.Location = new System.Drawing.Point(471, 13);
            this.lbtTen_Tb.Name = "lbtTen_Tb";
            this.lbtTen_Tb.Size = new System.Drawing.Size(89, 13);
            this.lbtTen_Tb.TabIndex = 139;
            this.lbtTen_Tb.Tag = "";
            this.lbtTen_Tb.Text = "Tên nhóm thiết bị";
            this.lbtTen_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(200, 13);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(89, 13);
            this.rsLabel2.TabIndex = 138;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Mã thiết bị nguồn";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 131);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(1063, 457);
            this.splitContainer1.SplitterDistance = 393;
            this.splitContainer1.SplitterWidth = 100;
            this.splitContainer1.TabIndex = 138;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(893, 594);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            this.btgAccept.TabIndex = 139;
            // 
            // numNam
            // 
            this.numNam.AutoDropDown = null;
            this.numNam.bFormat = true;
            this.numNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNam.Location = new System.Drawing.Point(102, 8);
            this.numNam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNam.Name = "numNam";
            this.numNam.Scale = 0;
            this.numNam.Size = new System.Drawing.Size(88, 20);
            this.numNam.TabIndex = 284;
            this.numNam.Text = "0";
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam.Value = 0D;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(6, 13);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(77, 16);
            this.rsLabel3.TabIndex = 283;
            this.rsLabel3.Text = "Năm nguồn";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNam_Copy
            // 
            this.numNam_Copy.AutoDropDown = null;
            this.numNam_Copy.bFormat = true;
            this.numNam_Copy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNam_Copy.Location = new System.Drawing.Point(102, 37);
            this.numNam_Copy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNam_Copy.Name = "numNam_Copy";
            this.numNam_Copy.Scale = 0;
            this.numNam_Copy.Size = new System.Drawing.Size(88, 20);
            this.numNam_Copy.TabIndex = 286;
            this.numNam_Copy.Text = "0";
            this.numNam_Copy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam_Copy.Value = 0D;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.Location = new System.Drawing.Point(6, 42);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(96, 16);
            this.rsLabel4.TabIndex = 285;
            this.rsLabel4.Text = "Năm sao chép";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkCopy_Vt
            // 
            this.chkCopy_Vt.AutoSize = true;
            this.chkCopy_Vt.Enabled = false;
            this.chkCopy_Vt.Location = new System.Drawing.Point(102, 64);
            this.chkCopy_Vt.Name = "chkCopy_Vt";
            this.chkCopy_Vt.Size = new System.Drawing.Size(95, 17);
            this.chkCopy_Vt.TabIndex = 287;
            this.chkCopy_Vt.Text = "Có copy vật tư";
            this.chkCopy_Vt.UseVisualStyleBackColor = true;
            // 
            // frmCopyCVBT_Nam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 643);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCopyCVBT_Nam";
            this.Text = "Copy công việc bảo trì";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btNew btRefresh;
        private RosySystem.Control.rsTabControl rsTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtMa_Tb;
        private RosySystem.Control.rsLabel lbtTen_Tb;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtMa_Tb_Copy;
        private RosySystem.Control.rsLabel lbtTen_Tb_Copy;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBoxNumber numNam_Copy;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBoxNumber numNam;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsCheckbox chkCopy_Vt;
    }
}