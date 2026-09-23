namespace RosyModule
{
	partial class frmDuyet
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
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct1 = new RosySystem.Control.rsLabel();
            this.rsTabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtCreate_Log = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtSo_Ct_Lap = new RosySystem.Control.rsTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.numTTSo_Luong = new RosySystem.Control.rsTextBoxNumber();
            this.numTai_Trong_SaLan = new RosySystem.Control.rsTextBoxNumber();
            this.numTai_Trong_Xe = new RosySystem.Control.rsTextBoxNumber();
            this.lblxalan = new RosySystem.Control.rsLabel();
            this.lblLXH = new RosySystem.Control.rsLabel();
            this.lblXe = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtDuyet_Log = new RosySystem.Control.rsTextBox();
            this.chkDuyet = new RosySystem.Control.rsCheckbox();
            this.btSave = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = true;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.Enabled = false;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(108, 40);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ct.TabIndex = 1;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.Location = new System.Drawing.Point(12, 40);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(45, 13);
            this.lblNgay_Ct1.TabIndex = 91;
            this.lblNgay_Ct1.Tag = "";
            this.lblNgay_Ct1.Text = "Ngày Ct";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Controls.Add(this.tabPage3);
            this.rsTabControl1.Location = new System.Drawing.Point(12, 12);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(420, 184);
            this.rsTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rsLabel3);
            this.tabPage1.Controls.Add(this.txtCreate_Log);
            this.tabPage1.Controls.Add(this.rsLabel4);
            this.tabPage1.Controls.Add(this.txtSo_Ct_Lap);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(412, 158);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Lập";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(18, 36);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(61, 13);
            this.rsLabel3.TabIndex = 101;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Nhật ký lập";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreate_Log
            // 
            this.txtCreate_Log.AutoDropDown = null;
            this.txtCreate_Log.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreate_Log.Enabled = false;
            this.txtCreate_Log.Location = new System.Drawing.Point(114, 33);
            this.txtCreate_Log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtCreate_Log.MaxLength = 20;
            this.txtCreate_Log.Name = "txtCreate_Log";
            this.txtCreate_Log.Size = new System.Drawing.Size(136, 20);
            this.txtCreate_Log.TabIndex = 2;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(18, 11);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(50, 13);
            this.rsLabel4.TabIndex = 98;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Số Ct lập";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct_Lap
            // 
            this.txtSo_Ct_Lap.AutoDropDown = null;
            this.txtSo_Ct_Lap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct_Lap.Location = new System.Drawing.Point(114, 11);
            this.txtSo_Ct_Lap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct_Lap.MaxLength = 20;
            this.txtSo_Ct_Lap.Name = "txtSo_Ct_Lap";
            this.txtSo_Ct_Lap.Size = new System.Drawing.Size(68, 20);
            this.txtSo_Ct_Lap.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.numTTSo_Luong);
            this.tabPage3.Controls.Add(this.numTai_Trong_SaLan);
            this.tabPage3.Controls.Add(this.numTai_Trong_Xe);
            this.tabPage3.Controls.Add(this.lblxalan);
            this.tabPage3.Controls.Add(this.lblLXH);
            this.tabPage3.Controls.Add(this.lblXe);
            this.tabPage3.Controls.Add(this.rsLabel2);
            this.tabPage3.Controls.Add(this.txtDuyet_Log);
            this.tabPage3.Controls.Add(this.chkDuyet);
            this.tabPage3.Controls.Add(this.dteNgay_Ct);
            this.tabPage3.Controls.Add(this.lblNgay_Ct1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(412, 158);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Duyệt";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // numTTSo_Luong
            // 
            this.numTTSo_Luong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTSo_Luong.AutoDropDown = null;
            this.numTTSo_Luong.bFormat = true;
            this.numTTSo_Luong.Location = new System.Drawing.Point(108, 108);
            this.numTTSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTSo_Luong.Name = "numTTSo_Luong";
            this.numTTSo_Luong.Scale = 0;
            this.numTTSo_Luong.Size = new System.Drawing.Size(99, 20);
            this.numTTSo_Luong.TabIndex = 120;
            this.numTTSo_Luong.TabStop = false;
            this.numTTSo_Luong.Text = "0";
            this.numTTSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTSo_Luong.Value = 0D;
            // 
            // numTai_Trong_SaLan
            // 
            this.numTai_Trong_SaLan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTai_Trong_SaLan.AutoDropDown = null;
            this.numTai_Trong_SaLan.bFormat = true;
            this.numTai_Trong_SaLan.Location = new System.Drawing.Point(292, 86);
            this.numTai_Trong_SaLan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTai_Trong_SaLan.Name = "numTai_Trong_SaLan";
            this.numTai_Trong_SaLan.Scale = 0;
            this.numTai_Trong_SaLan.Size = new System.Drawing.Size(99, 20);
            this.numTai_Trong_SaLan.TabIndex = 121;
            this.numTai_Trong_SaLan.TabStop = false;
            this.numTai_Trong_SaLan.Text = "0";
            this.numTai_Trong_SaLan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTai_Trong_SaLan.Value = 0D;
            // 
            // numTai_Trong_Xe
            // 
            this.numTai_Trong_Xe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTai_Trong_Xe.AutoDropDown = null;
            this.numTai_Trong_Xe.bFormat = true;
            this.numTai_Trong_Xe.Location = new System.Drawing.Point(108, 86);
            this.numTai_Trong_Xe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTai_Trong_Xe.Name = "numTai_Trong_Xe";
            this.numTai_Trong_Xe.Scale = 0;
            this.numTai_Trong_Xe.Size = new System.Drawing.Size(99, 20);
            this.numTai_Trong_Xe.TabIndex = 122;
            this.numTai_Trong_Xe.TabStop = false;
            this.numTai_Trong_Xe.Text = "0";
            this.numTai_Trong_Xe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTai_Trong_Xe.Value = 0D;
            // 
            // lblxalan
            // 
            this.lblxalan.AutoEllipsis = true;
            this.lblxalan.AutoSize = true;
            this.lblxalan.Location = new System.Drawing.Point(208, 89);
            this.lblxalan.Name = "lblxalan";
            this.lblxalan.Size = new System.Drawing.Size(80, 13);
            this.lblxalan.TabIndex = 118;
            this.lblxalan.Tag = "";
            this.lblxalan.Text = "Tải trọng sà lan";
            this.lblxalan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLXH
            // 
            this.lblLXH.AutoEllipsis = true;
            this.lblLXH.AutoSize = true;
            this.lblLXH.Location = new System.Drawing.Point(6, 111);
            this.lblLXH.Name = "lblLXH";
            this.lblLXH.Size = new System.Drawing.Size(93, 13);
            this.lblLXH.TabIndex = 117;
            this.lblLXH.Tag = "";
            this.lblLXH.Text = "Tổng SL của LXH";
            this.lblLXH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblXe
            // 
            this.lblXe.AutoEllipsis = true;
            this.lblXe.AutoSize = true;
            this.lblXe.Location = new System.Drawing.Point(6, 89);
            this.lblXe.Name = "lblXe";
            this.lblXe.Size = new System.Drawing.Size(63, 13);
            this.lblXe.TabIndex = 119;
            this.lblXe.Tag = "";
            this.lblXe.Text = "Tải trọng xe";
            this.lblXe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(12, 65);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(73, 13);
            this.rsLabel2.TabIndex = 95;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Nhật ký duyệt";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDuyet_Log
            // 
            this.txtDuyet_Log.AutoDropDown = null;
            this.txtDuyet_Log.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDuyet_Log.Enabled = false;
            this.txtDuyet_Log.Location = new System.Drawing.Point(108, 62);
            this.txtDuyet_Log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDuyet_Log.MaxLength = 20;
            this.txtDuyet_Log.Name = "txtDuyet_Log";
            this.txtDuyet_Log.Size = new System.Drawing.Size(136, 20);
            this.txtDuyet_Log.TabIndex = 3;
            // 
            // chkDuyet
            // 
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Enabled = false;
            this.chkDuyet.Location = new System.Drawing.Point(108, 20);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(142, 17);
            this.chkDuyet.TabIndex = 0;
            this.chkDuyet.Text = "Chứng từ đã được duyệt";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Location = new System.Drawing.Point(256, 212);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(337, 212);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // frmDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 247);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.rsTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuyet";
            this.Text = "Duyệt chứng từ";
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public RosySystem.Control.rsDateTime dteNgay_Ct;
		private RosySystem.Control.rsLabel lblNgay_Ct1;
		private System.Windows.Forms.TabControl rsTabControl1;
		private System.Windows.Forms.TabPage tabPage3;
		private RosySystem.Control.rsLabel rsLabel2;
		public RosySystem.Control.rsTextBox txtDuyet_Log;
		private RosySystem.Control.rsCheckbox chkDuyet;
		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsLabel rsLabel3;
		public RosySystem.Control.rsTextBox txtCreate_Log;
		private RosySystem.Control.rsLabel rsLabel4;
		public RosySystem.Control.rsTextBox txtSo_Ct_Lap;
		private RosySystem.Control.rsButton btSave;
		private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsTextBoxNumber numTTSo_Luong;
        private RosySystem.Control.rsTextBoxNumber numTai_Trong_SaLan;
        private RosySystem.Control.rsTextBoxNumber numTai_Trong_Xe;
        private RosySystem.Control.rsLabel lblxalan;
        private RosySystem.Control.rsLabel lblLXH;
        private RosySystem.Control.rsLabel lblXe;
	}
}