namespace RosyModule
{
	partial class frmDuyet_Huy
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
			this.rsTabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtUser_Huy = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtGhi_Chu_Huy = new RosySystem.Control.rsTextBox();
			this.chkDuyet_Huy = new RosySystem.Control.rsCheckbox();
			this.dteNgay_Huy = new RosySystem.Control.rsDateTime();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.btSave = new RosySystem.Control.rsButton();
			this.btExit = new RosySystem.Control.rsButton();
			this.rsTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// rsTabControl1
			// 
			this.rsTabControl1.Controls.Add(this.tabPage1);
			this.rsTabControl1.Location = new System.Drawing.Point(12, 12);
			this.rsTabControl1.Name = "rsTabControl1";
			this.rsTabControl1.SelectedIndex = 0;
			this.rsTabControl1.Size = new System.Drawing.Size(400, 134);
			this.rsTabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtUser_Huy);
			this.tabPage1.Controls.Add(this.rsLabel2);
			this.tabPage1.Controls.Add(this.rsLabel1);
			this.tabPage1.Controls.Add(this.txtGhi_Chu_Huy);
			this.tabPage1.Controls.Add(this.chkDuyet_Huy);
			this.tabPage1.Controls.Add(this.dteNgay_Huy);
			this.tabPage1.Controls.Add(this.rsLabel3);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(392, 108);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Lập";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtUser_Huy
			// 
			this.txtUser_Huy.AutoDropDown = null;
			this.txtUser_Huy.Enabled = false;
			this.txtUser_Huy.Location = new System.Drawing.Point(118, 81);
			this.txtUser_Huy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtUser_Huy.MaxLength = 20;
			this.txtUser_Huy.Name = "txtUser_Huy";
			this.txtUser_Huy.Size = new System.Drawing.Size(119, 20);
			this.txtUser_Huy.TabIndex = 102;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(22, 84);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(49, 13);
			this.rsLabel2.TabIndex = 101;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "User hủy";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(22, 61);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(53, 13);
			this.rsLabel1.TabIndex = 100;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Lý do hủy";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtGhi_Chu_Huy
			// 
			this.txtGhi_Chu_Huy.AutoDropDown = null;
			this.txtGhi_Chu_Huy.Location = new System.Drawing.Point(118, 58);
			this.txtGhi_Chu_Huy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtGhi_Chu_Huy.MaxLength = 200;
			this.txtGhi_Chu_Huy.Name = "txtGhi_Chu_Huy";
			this.txtGhi_Chu_Huy.Size = new System.Drawing.Size(259, 20);
			this.txtGhi_Chu_Huy.TabIndex = 98;
			// 
			// chkDuyet_Huy
			// 
			this.chkDuyet_Huy.AutoSize = true;
			this.chkDuyet_Huy.Location = new System.Drawing.Point(118, 16);
			this.chkDuyet_Huy.Name = "chkDuyet_Huy";
			this.chkDuyet_Huy.Size = new System.Drawing.Size(94, 17);
			this.chkDuyet_Huy.TabIndex = 96;
			this.chkDuyet_Huy.Text = "Tình trang hủy";
			this.chkDuyet_Huy.UseVisualStyleBackColor = true;
			// 
			// dteNgay_Huy
			// 
			this.dteNgay_Huy.bAllowEmpty = true;
			this.dteNgay_Huy.bSelectOnFocus = false;
			this.dteNgay_Huy.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Huy.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Huy.Enabled = false;
			this.dteNgay_Huy.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Huy.Location = new System.Drawing.Point(118, 36);
			this.dteNgay_Huy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Huy.Mask = "00/00/0000";
			this.dteNgay_Huy.Name = "dteNgay_Huy";
			this.dteNgay_Huy.Size = new System.Drawing.Size(68, 20);
			this.dteNgay_Huy.TabIndex = 97;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(22, 36);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(45, 13);
			this.rsLabel3.TabIndex = 99;
			this.rsLabel3.Tag = "";
			this.rsLabel3.Text = "Ngày Ct";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btSave
			// 
			this.btSave.Enabled = false;
			this.btSave.Location = new System.Drawing.Point(256, 161);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(75, 23);
			this.btSave.TabIndex = 1;
			this.btSave.Tag = "Save";
			this.btSave.Text = "&Lưu";
			this.btSave.UseVisualStyleBackColor = true;
			// 
			// btExit
			// 
			this.btExit.Location = new System.Drawing.Point(337, 161);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(75, 23);
			this.btExit.TabIndex = 1;
			this.btExit.Tag = "Exit";
			this.btExit.Text = "&Quay ra";
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// frmDuyet_Huy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 193);
			this.Controls.Add(this.btExit);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.rsTabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDuyet_Huy";
			this.Text = "Duyệt chứng từ";
			this.rsTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl rsTabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsButton btSave;
		private RosySystem.Control.rsButton btExit;
		private RosySystem.Control.rsLabel rsLabel1;
		public RosySystem.Control.rsTextBox txtGhi_Chu_Huy;
		private RosySystem.Control.rsCheckbox chkDuyet_Huy;
		public RosySystem.Control.rsDateTime dteNgay_Huy;
		private RosySystem.Control.rsLabel rsLabel3;
		public RosySystem.Control.rsTextBox txtUser_Huy;
		private RosySystem.Control.rsLabel rsLabel2;
	}
}