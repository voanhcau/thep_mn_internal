namespace RosyModule.Salary
{
	partial class frmDuyet_PTCHC
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
            this.rsTabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtDuyet_Log = new RosySystem.Control.rsTextBox();
            this.chkDuyet_PTCHC = new RosySystem.Control.rsCheckbox();
            this.btSave = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.rsTabControl2 = new RosySystem.Control.rsTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDuyet = new RosySystem.Customize.dgvVoucher();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.rsTabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyet)).BeginInit();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Location = new System.Drawing.Point(12, 352);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(1216, 86);
            this.rsTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rsLabel2);
            this.tabPage1.Controls.Add(this.txtDuyet_Log);
            this.tabPage1.Controls.Add(this.chkDuyet_PTCHC);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1208, 60);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Lập";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(21, 36);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(73, 13);
            this.rsLabel2.TabIndex = 103;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Nhật ký duyệt";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDuyet_Log
            // 
            this.txtDuyet_Log.AutoDropDown = null;
            this.txtDuyet_Log.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDuyet_Log.Enabled = false;
            this.txtDuyet_Log.Location = new System.Drawing.Point(117, 33);
            this.txtDuyet_Log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDuyet_Log.MaxLength = 20;
            this.txtDuyet_Log.Name = "txtDuyet_Log";
            this.txtDuyet_Log.Size = new System.Drawing.Size(136, 20);
            this.txtDuyet_Log.TabIndex = 101;
            // 
            // chkDuyet_PTCHC
            // 
            this.chkDuyet_PTCHC.AutoSize = true;
            this.chkDuyet_PTCHC.Location = new System.Drawing.Point(117, 11);
            this.chkDuyet_PTCHC.Name = "chkDuyet_PTCHC";
            this.chkDuyet_PTCHC.Size = new System.Drawing.Size(93, 17);
            this.chkDuyet_PTCHC.TabIndex = 96;
            this.chkDuyet_PTCHC.Text = "Duyệt PTCHC";
            this.chkDuyet_PTCHC.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Location = new System.Drawing.Point(1045, 444);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(1126, 444);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // rsTabControl2
            // 
            this.rsTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl2.Controls.Add(this.tabPage2);
            this.rsTabControl2.Location = new System.Drawing.Point(12, 12);
            this.rsTabControl2.Name = "rsTabControl2";
            this.rsTabControl2.SelectedIndex = 0;
            this.rsTabControl2.Size = new System.Drawing.Size(1220, 334);
            this.rsTabControl2.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDuyet);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1212, 308);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Danh sách nhân viên";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDuyet
            // 
            this.dgvDuyet.AllowUserToAddRows = false;
            this.dgvDuyet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDuyet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDuyet.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuyet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDuyet.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDuyet.Location = new System.Drawing.Point(3, 3);
            this.dgvDuyet.MultiSelect = false;
            this.dgvDuyet.Name = "dgvDuyet";
            this.dgvDuyet.Size = new System.Drawing.Size(1206, 302);
            this.dgvDuyet.strZone = "";
            this.dgvDuyet.TabIndex = 1;
            // 
            // frmDuyet_PTCHC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 479);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.rsTabControl2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuyet_PTCHC";
            this.Text = "Duyệt lương vị trí";
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.rsTabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyet)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl rsTabControl1;
		private RosySystem.Control.rsButton btSave;
		private RosySystem.Control.rsButton btExit;
		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsLabel rsLabel2;
		public RosySystem.Control.rsTextBox txtDuyet_Log;
        private RosySystem.Control.rsCheckbox chkDuyet_PTCHC;
		private RosySystem.Control.rsTabControl rsTabControl2;
		private System.Windows.Forms.TabPage tabPage2;
		private RosySystem.Customize.dgvVoucher dgvDuyet;
	}
}