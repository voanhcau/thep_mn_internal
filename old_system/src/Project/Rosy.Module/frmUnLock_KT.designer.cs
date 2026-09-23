namespace RosyModule
{
    partial class frmUnLock_KT
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
            this.chkIs_Lock = new RosySystem.Control.rsCheckbox();
            this.btSave = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Location = new System.Drawing.Point(16, 15);
            this.rsTabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(533, 143);
            this.rsTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtUser_Huy);
            this.tabPage1.Controls.Add(this.rsLabel2);
            this.tabPage1.Controls.Add(this.rsLabel1);
            this.tabPage1.Controls.Add(this.txtGhi_Chu_Huy);
            this.tabPage1.Controls.Add(this.chkIs_Lock);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(525, 114);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Lập";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtUser_Huy
            // 
            this.txtUser_Huy.AutoDropDown = null;
            this.txtUser_Huy.Enabled = false;
            this.txtUser_Huy.Location = new System.Drawing.Point(157, 76);
            this.txtUser_Huy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtUser_Huy.MaxLength = 20;
            this.txtUser_Huy.Name = "txtUser_Huy";
            this.txtUser_Huy.Size = new System.Drawing.Size(157, 22);
            this.txtUser_Huy.TabIndex = 102;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(29, 80);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(96, 17);
            this.rsLabel2.TabIndex = 101;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "User mở khóa";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(29, 52);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(101, 17);
            this.rsLabel1.TabIndex = 100;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Lý do mở khóa";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu_Huy
            // 
            this.txtGhi_Chu_Huy.AutoDropDown = null;
            this.txtGhi_Chu_Huy.Location = new System.Drawing.Point(157, 48);
            this.txtGhi_Chu_Huy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtGhi_Chu_Huy.MaxLength = 200;
            this.txtGhi_Chu_Huy.Name = "txtGhi_Chu_Huy";
            this.txtGhi_Chu_Huy.Size = new System.Drawing.Size(344, 22);
            this.txtGhi_Chu_Huy.TabIndex = 98;
            // 
            // chkIs_Lock
            // 
            this.chkIs_Lock.AutoSize = true;
            this.chkIs_Lock.Location = new System.Drawing.Point(157, 20);
            this.chkIs_Lock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIs_Lock.Name = "chkIs_Lock";
            this.chkIs_Lock.Size = new System.Drawing.Size(130, 21);
            this.chkIs_Lock.TabIndex = 96;
            this.chkIs_Lock.Text = "Tình trạng khóa";
            this.chkIs_Lock.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(341, 164);
            this.btSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(100, 28);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(449, 164);
            this.btExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(100, 28);
            this.btExit.TabIndex = 1;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // frmUnLock_KT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 209);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.rsTabControl1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUnLock_KT";
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
		public RosySystem.Control.rsTextBox txtUser_Huy;
		private RosySystem.Control.rsLabel rsLabel2;
        public RosySystem.Control.rsCheckbox chkIs_Lock;
	}
}