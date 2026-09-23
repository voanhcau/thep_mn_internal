namespace RosyModule.Receivable
{
    partial class frmPXDT_
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
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.txtMau_So = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtSo_Ct = new RosySystem.Control.rsTextBox();
            this.chkIsNot_TaoHDCD = new System.Windows.Forms.CheckBox();
            this.chkIsNot_TaoHD = new System.Windows.Forms.CheckBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.btPath = new System.Windows.Forms.Button();
            this.txtPath = new RosySystem.Control.rsTextBox();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.btFilter = new RosySystem.Customize.btFilter();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.numTSo_Ct0 = new RosySystem.Control.rsTextBoxNumber();
            this.btHDDTCD = new RosySystem.Customize.btFilter();
            this.btHD_Huy = new RosySystem.Customize.btFilter();
            this.btHDDT = new RosySystem.Customize.btFilter();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.rsPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsSplitContainer1
            // 
            this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer1.Location = new System.Drawing.Point(4, 4);
            this.rsSplitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.rsSplitContainer1.Name = "rsSplitContainer1";
            this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer1.Panel1
            // 
            this.rsSplitContainer1.Panel1.Controls.Add(this.txtMau_So);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel3);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel7);
            this.rsSplitContainer1.Panel1.Controls.Add(this.txtSo_Ct);
            this.rsSplitContainer1.Panel1.Controls.Add(this.chkIsNot_TaoHDCD);
            this.rsSplitContainer1.Panel1.Controls.Add(this.chkIsNot_TaoHD);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel4);
            this.rsSplitContainer1.Panel1.Controls.Add(this.btPath);
            this.rsSplitContainer1.Panel1.Controls.Add(this.txtPath);
            this.rsSplitContainer1.Panel1.Controls.Add(this.dteNgay_Ct2);
            this.rsSplitContainer1.Panel1.Controls.Add(this.dteNgay_Ct1);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel1);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel2);
            this.rsSplitContainer1.Panel1.Controls.Add(this.btFilter);
            // 
            // rsSplitContainer1.Panel2
            // 
            this.rsSplitContainer1.Panel2.Controls.Add(this.rsPanel1);
            this.rsSplitContainer1.Size = new System.Drawing.Size(1627, 659);
            this.rsSplitContainer1.SplitterDistance = 88;
            this.rsSplitContainer1.SplitterWidth = 5;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // txtMau_So
            // 
            this.txtMau_So.AutoDropDown = null;
            this.txtMau_So.InputMask = "";
            this.txtMau_So.Location = new System.Drawing.Point(359, 36);
            this.txtMau_So.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.txtMau_So.Name = "txtMau_So";
            this.txtMau_So.Size = new System.Drawing.Size(133, 22);
            this.txtMau_So.TabIndex = 159;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(281, 40);
            this.rsLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(54, 17);
            this.rsLabel3.TabIndex = 158;
            this.rsLabel3.Text = "Mẫu số";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(12, 41);
            this.rsLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(94, 17);
            this.rsLabel7.TabIndex = 156;
            this.rsLabel7.Text = "Số phiếu xuất";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.AutoDropDown = null;
            this.txtSo_Ct.Location = new System.Drawing.Point(118, 37);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.Size = new System.Drawing.Size(117, 22);
            this.txtSo_Ct.TabIndex = 155;
            // 
            // chkIsNot_TaoHDCD
            // 
            this.chkIsNot_TaoHDCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsNot_TaoHDCD.AutoSize = true;
            this.chkIsNot_TaoHDCD.Checked = true;
            this.chkIsNot_TaoHDCD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNot_TaoHDCD.ForeColor = System.Drawing.Color.OrangeRed;
            this.chkIsNot_TaoHDCD.Location = new System.Drawing.Point(512, 30);
            this.chkIsNot_TaoHDCD.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsNot_TaoHDCD.Name = "chkIsNot_TaoHDCD";
            this.chkIsNot_TaoHDCD.Size = new System.Drawing.Size(239, 21);
            this.chkIsNot_TaoHDCD.TabIndex = 154;
            this.chkIsNot_TaoHDCD.Text = "Chỉ lấy các PX chưa tạo PXDTCD";
            this.chkIsNot_TaoHDCD.UseVisualStyleBackColor = true;
            // 
            // chkIsNot_TaoHD
            // 
            this.chkIsNot_TaoHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsNot_TaoHD.AutoSize = true;
            this.chkIsNot_TaoHD.Checked = true;
            this.chkIsNot_TaoHD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNot_TaoHD.ForeColor = System.Drawing.Color.OrangeRed;
            this.chkIsNot_TaoHD.Location = new System.Drawing.Point(512, 8);
            this.chkIsNot_TaoHD.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsNot_TaoHD.Name = "chkIsNot_TaoHD";
            this.chkIsNot_TaoHD.Size = new System.Drawing.Size(220, 21);
            this.chkIsNot_TaoHD.TabIndex = 153;
            this.chkIsNot_TaoHD.Text = "Chỉ lấy các PX chưa tạo PXDT";
            this.chkIsNot_TaoHD.UseVisualStyleBackColor = true;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(12, 66);
            this.rsLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(78, 17);
            this.rsLabel4.TabIndex = 87;
            this.rsLabel4.Text = "Đường dẫn";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPath
            // 
            this.btPath.Location = new System.Drawing.Point(799, 56);
            this.btPath.Margin = new System.Windows.Forms.Padding(4);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(108, 28);
            this.btPath.TabIndex = 5;
            this.btPath.Text = "Browse";
            this.btPath.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.AutoDropDown = null;
            this.txtPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPath.Location = new System.Drawing.Point(118, 62);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtPath.MaxLength = 20;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(672, 22);
            this.txtPath.TabIndex = 4;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(359, 9);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(118, 9);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(12, 14);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(60, 17);
            this.rsLabel1.TabIndex = 0;
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(281, 12);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(69, 17);
            this.rsLabel2.TabIndex = 2;
            this.rsLabel2.Text = "Đến ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btFilter
            // 
            this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFilter.ImageKey = "Filter.png";
            this.btFilter.Location = new System.Drawing.Point(915, 31);
            this.btFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(115, 53);
            this.btFilter.TabIndex = 6;
            this.btFilter.Tag = "";
            this.btFilter.Text = "F9 - &Lọc";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.rsLabel10);
            this.rsPanel1.Controls.Add(this.numTSo_Ct0);
            this.rsPanel1.Controls.Add(this.btHDDTCD);
            this.rsPanel1.Controls.Add(this.btHD_Huy);
            this.rsPanel1.Controls.Add(this.btHDDT);
            this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rsPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsPanel1.ForeColor = System.Drawing.Color.Blue;
            this.rsPanel1.Location = new System.Drawing.Point(0, 509);
            this.rsPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(1627, 57);
            this.rsPanel1.TabIndex = 1;
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Location = new System.Drawing.Point(9, 11);
            this.rsLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(147, 17);
            this.rsLabel10.TabIndex = 7;
            this.rsLabel10.Tag = "";
            this.rsLabel10.Text = "Tổng số phiếu xuất";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTSo_Ct0
            // 
            this.numTSo_Ct0.AutoDropDown = null;
            this.numTSo_Ct0.bFormat = true;
            this.numTSo_Ct0.ForeColor = System.Drawing.Color.Blue;
            this.numTSo_Ct0.Location = new System.Drawing.Point(167, 7);
            this.numTSo_Ct0.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numTSo_Ct0.Name = "numTSo_Ct0";
            this.numTSo_Ct0.Scale = 0;
            this.numTSo_Ct0.Size = new System.Drawing.Size(103, 23);
            this.numTSo_Ct0.TabIndex = 8;
            this.numTSo_Ct0.TabStop = false;
            this.numTSo_Ct0.Text = "0";
            this.numTSo_Ct0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTSo_Ct0.Value = 0D;
            // 
            // btHDDTCD
            // 
            this.btHDDTCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHDDTCD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHDDTCD.ImageKey = "(none)";
            this.btHDDTCD.Location = new System.Drawing.Point(1453, 4);
            this.btHDDTCD.Margin = new System.Windows.Forms.Padding(4);
            this.btHDDTCD.Name = "btHDDTCD";
            this.btHDDTCD.Size = new System.Drawing.Size(162, 49);
            this.btHDDTCD.TabIndex = 5;
            this.btHDDTCD.Tag = "";
            this.btHDDTCD.Text = "Tạo phiếu xuất điện tử chuyển đổi";
            this.btHDDTCD.UseVisualStyleBackColor = true;
            // 
            // btHD_Huy
            // 
            this.btHD_Huy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btHD_Huy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHD_Huy.ImageKey = "(none)";
            this.btHD_Huy.Location = new System.Drawing.Point(281, 4);
            this.btHD_Huy.Margin = new System.Windows.Forms.Padding(4);
            this.btHD_Huy.Name = "btHD_Huy";
            this.btHD_Huy.Size = new System.Drawing.Size(115, 49);
            this.btHD_Huy.TabIndex = 5;
            this.btHD_Huy.Tag = "";
            this.btHD_Huy.Text = "Hủy phiếu xuất";
            this.btHD_Huy.UseVisualStyleBackColor = true;
            // 
            // btHDDT
            // 
            this.btHDDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHDDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHDDT.ImageKey = "(none)";
            this.btHDDT.Location = new System.Drawing.Point(1330, 4);
            this.btHDDT.Margin = new System.Windows.Forms.Padding(4);
            this.btHDDT.Name = "btHDDT";
            this.btHDDT.Size = new System.Drawing.Size(115, 49);
            this.btHDDT.TabIndex = 5;
            this.btHDDT.Tag = "";
            this.btHDDT.Text = "Tạo phiếu xuất điện tử";
            this.btHDDT.UseVisualStyleBackColor = true;
            // 
            // frmPXDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 667);
            this.Controls.Add(this.rsSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmPXDT";
            this.Object_ID = "PXDTU";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Tag = "frmPXDTU";
            this.Text = "frmPXDTU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel1.PerformLayout();
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.rsPanel1.ResumeLayout(false);
            this.rsPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Customize.btFilter btFilter;
        private RosySystem.Control.rsPanel rsPanel1;
		private RosySystem.Control.rsLabel rsLabel10;
        private RosySystem.Control.rsTextBoxNumber numTSo_Ct0;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel rsLabel4;
        private System.Windows.Forms.Button btPath;
        private RosySystem.Control.rsTextBox txtPath;
        private RosySystem.Customize.btFilter btHDDTCD;
        private System.Windows.Forms.CheckBox chkIsNot_TaoHD;
        private System.Windows.Forms.CheckBox chkIsNot_TaoHDCD;
        private RosySystem.Customize.btFilter btHD_Huy;
        private RosySystem.Customize.btFilter btHDDT;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsTextBox txtSo_Ct;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBoxEnum txtMau_So;
	}
}