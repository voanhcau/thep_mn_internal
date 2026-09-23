namespace RosyModule
{
	partial class frmGhi_Chu
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
			this.dteNgay_In = new RosySystem.Control.rsDateTime();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.txtUser_Print = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtGhi_Chu_HD = new RosySystem.Control.rsTextBox();
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
			this.tabPage1.Controls.Add(this.dteNgay_In);
			this.tabPage1.Controls.Add(this.rsLabel3);
			this.tabPage1.Controls.Add(this.txtUser_Print);
			this.tabPage1.Controls.Add(this.rsLabel2);
			this.tabPage1.Controls.Add(this.rsLabel1);
			this.tabPage1.Controls.Add(this.txtGhi_Chu_HD);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(392, 108);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Lập";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dteNgay_In
			// 
			this.dteNgay_In.bAllowEmpty = true;
			this.dteNgay_In.bSelectOnFocus = false;
			this.dteNgay_In.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_In.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_In.Enabled = false;
			this.dteNgay_In.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_In.Location = new System.Drawing.Point(120, 18);
			this.dteNgay_In.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_In.Mask = "00/00/0000";
			this.dteNgay_In.Name = "dteNgay_In";
			this.dteNgay_In.Size = new System.Drawing.Size(68, 20);
			this.dteNgay_In.TabIndex = 103;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(24, 18);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(43, 13);
			this.rsLabel3.TabIndex = 104;
			this.rsLabel3.Tag = "";
			this.rsLabel3.Text = "Ngày in";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUser_Print
			// 
			this.txtUser_Print.AutoDropDown = null;
			this.txtUser_Print.Enabled = false;
			this.txtUser_Print.Location = new System.Drawing.Point(120, 63);
			this.txtUser_Print.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtUser_Print.MaxLength = 20;
			this.txtUser_Print.Name = "txtUser_Print";
			this.txtUser_Print.Size = new System.Drawing.Size(119, 20);
			this.txtUser_Print.TabIndex = 102;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(24, 66);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(40, 13);
			this.rsLabel2.TabIndex = 101;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "User in";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(24, 43);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(70, 13);
			this.rsLabel1.TabIndex = 100;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Lý do in thêm";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtGhi_Chu_HD
			// 
			this.txtGhi_Chu_HD.AutoDropDown = null;
			this.txtGhi_Chu_HD.Location = new System.Drawing.Point(120, 40);
			this.txtGhi_Chu_HD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtGhi_Chu_HD.MaxLength = 20;
			this.txtGhi_Chu_HD.Name = "txtGhi_Chu_HD";
			this.txtGhi_Chu_HD.Size = new System.Drawing.Size(259, 20);
			this.txtGhi_Chu_HD.TabIndex = 98;
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
			// frmGhi_Chu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 193);
			this.Controls.Add(this.btExit);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.rsTabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmGhi_Chu";
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
		public RosySystem.Control.rsTextBox txtGhi_Chu_HD;
		public RosySystem.Control.rsTextBox txtUser_Print;
		private RosySystem.Control.rsLabel rsLabel2;
		public RosySystem.Control.rsDateTime dteNgay_In;
		private RosySystem.Control.rsLabel rsLabel3;
	}
}