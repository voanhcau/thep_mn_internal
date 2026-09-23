namespace RosyModule.Costing
{
	partial class frmZPhanBo
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.rsTabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dgvZPhanBo1 = new RosySystem.Control.rsDataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTk_Den = new RosySystem.Control.rsTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtTk_Cp2 = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtTk_Cp4 = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.txtTk_Cp3 = new RosySystem.Control.rsTextBox();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.txtTk_Cp1 = new RosySystem.Control.rsTextBox();
			this.dgvZPhanBo2 = new RosySystem.Control.rsDataGridView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.dgvZPhanBo3 = new RosySystem.Control.rsDataGridView();
			this.btExit = new RosySystem.Control.rsButton();
			this.rsTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvZPhanBo1)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvZPhanBo2)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvZPhanBo3)).BeginInit();
			this.SuspendLayout();
			// 
			// rsTabControl1
			// 
			this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rsTabControl1.Controls.Add(this.tabPage1);
			this.rsTabControl1.Controls.Add(this.tabPage2);
			this.rsTabControl1.Controls.Add(this.tabPage3);
			this.rsTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsTabControl1.Location = new System.Drawing.Point(3, 3);
			this.rsTabControl1.Margin = new System.Windows.Forms.Padding(0);
			this.rsTabControl1.Name = "rsTabControl1";
			this.rsTabControl1.SelectedIndex = 0;
			this.rsTabControl1.Size = new System.Drawing.Size(786, 527);
			this.rsTabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgvZPhanBo1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(778, 501);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Tag = "PP_PhanBo1";
			this.tabPage1.Text = "Khai báo kết chuyển trực tiếp";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dgvZPhanBo1
			// 
			this.dgvZPhanBo1.AllowUserToAddRows = false;
			this.dgvZPhanBo1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvZPhanBo1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvZPhanBo1.BackgroundColor = System.Drawing.Color.White;
			this.dgvZPhanBo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvZPhanBo1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvZPhanBo1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvZPhanBo1.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvZPhanBo1.Location = new System.Drawing.Point(3, 3);
			this.dgvZPhanBo1.MultiSelect = false;
			this.dgvZPhanBo1.Name = "dgvZPhanBo1";
			this.dgvZPhanBo1.ReadOnly = true;
			this.dgvZPhanBo1.Size = new System.Drawing.Size(772, 495);
			this.dgvZPhanBo1.strZone = "";
			this.dgvZPhanBo1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.dgvZPhanBo2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(778, 501);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Tag = "PP_PhanBo2";
			this.tabPage2.Text = "Khai báo phân bổ theo PP tỷ lệ";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.txtTk_Den);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(215, 387);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(122, 111);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Tag = "TO_TK";
			this.groupBox2.Text = "Đến tài khoản";
			// 
			// txtTk_Den
			// 
			this.txtTk_Den.Location = new System.Drawing.Point(6, 21);
			this.txtTk_Den.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk_Den.Name = "txtTk_Den";
			this.txtTk_Den.ReadOnly = true;
			this.txtTk_Den.Size = new System.Drawing.Size(110, 20);
			this.txtTk_Den.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.txtTk_Cp2);
			this.groupBox1.Controls.Add(this.rsLabel1);
			this.groupBox1.Controls.Add(this.txtTk_Cp4);
			this.groupBox1.Controls.Add(this.rsLabel2);
			this.groupBox1.Controls.Add(this.txtTk_Cp3);
			this.groupBox1.Controls.Add(this.rsLabel3);
			this.groupBox1.Controls.Add(this.rsLabel4);
			this.groupBox1.Controls.Add(this.txtTk_Cp1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(6, 387);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(203, 111);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "FOLLOW_RATE_FROM_TK";
			this.groupBox1.Text = "Theo tỷ lệ từ tài khoản";
			// 
			// txtTk_Cp2
			// 
			this.txtTk_Cp2.Location = new System.Drawing.Point(84, 43);
			this.txtTk_Cp2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk_Cp2.Name = "txtTk_Cp2";
			this.txtTk_Cp2.ReadOnly = true;
			this.txtTk_Cp2.Size = new System.Drawing.Size(110, 20);
			this.txtTk_Cp2.TabIndex = 3;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel1.Location = new System.Drawing.Point(4, 24);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(75, 13);
			this.rsLabel1.TabIndex = 2;
			this.rsLabel1.Tag = "Tk1";
			this.rsLabel1.Text = "Tài khoản 1";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk_Cp4
			// 
			this.txtTk_Cp4.Location = new System.Drawing.Point(84, 87);
			this.txtTk_Cp4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk_Cp4.Name = "txtTk_Cp4";
			this.txtTk_Cp4.ReadOnly = true;
			this.txtTk_Cp4.Size = new System.Drawing.Size(110, 20);
			this.txtTk_Cp4.TabIndex = 3;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel2.Location = new System.Drawing.Point(4, 46);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(75, 13);
			this.rsLabel2.TabIndex = 2;
			this.rsLabel2.Tag = "Tk2";
			this.rsLabel2.Text = "Tài khoản 2";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk_Cp3
			// 
			this.txtTk_Cp3.Location = new System.Drawing.Point(84, 65);
			this.txtTk_Cp3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk_Cp3.Name = "txtTk_Cp3";
			this.txtTk_Cp3.ReadOnly = true;
			this.txtTk_Cp3.Size = new System.Drawing.Size(110, 20);
			this.txtTk_Cp3.TabIndex = 3;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel3.Location = new System.Drawing.Point(4, 68);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(75, 13);
			this.rsLabel3.TabIndex = 2;
			this.rsLabel3.Tag = "Tk3";
			this.rsLabel3.Text = "Tài khoản 3";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel4.Location = new System.Drawing.Point(4, 90);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(75, 13);
			this.rsLabel4.TabIndex = 2;
			this.rsLabel4.Tag = "Tk4";
			this.rsLabel4.Text = "Tài khoản 4";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTk_Cp1
			// 
			this.txtTk_Cp1.Location = new System.Drawing.Point(84, 21);
			this.txtTk_Cp1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTk_Cp1.Name = "txtTk_Cp1";
			this.txtTk_Cp1.ReadOnly = true;
			this.txtTk_Cp1.Size = new System.Drawing.Size(110, 20);
			this.txtTk_Cp1.TabIndex = 3;
			// 
			// dgvZPhanBo2
			// 
			this.dgvZPhanBo2.AllowUserToAddRows = false;
			this.dgvZPhanBo2.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvZPhanBo2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvZPhanBo2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvZPhanBo2.BackgroundColor = System.Drawing.Color.White;
			this.dgvZPhanBo2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvZPhanBo2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvZPhanBo2.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvZPhanBo2.Location = new System.Drawing.Point(3, 3);
			this.dgvZPhanBo2.MultiSelect = false;
			this.dgvZPhanBo2.Name = "dgvZPhanBo2";
			this.dgvZPhanBo2.ReadOnly = true;
			this.dgvZPhanBo2.Size = new System.Drawing.Size(772, 378);
			this.dgvZPhanBo2.strZone = "";
			this.dgvZPhanBo2.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.dgvZPhanBo3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(778, 501);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Tag = "PP_PhanBo3";
			this.tabPage3.Text = "Khai báo phân bổ theo PP định mức";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// dgvZPhanBo3
			// 
			this.dgvZPhanBo3.AllowUserToAddRows = false;
			this.dgvZPhanBo3.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvZPhanBo3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvZPhanBo3.BackgroundColor = System.Drawing.Color.White;
			this.dgvZPhanBo3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvZPhanBo3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvZPhanBo3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvZPhanBo3.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvZPhanBo3.Location = new System.Drawing.Point(3, 3);
			this.dgvZPhanBo3.MultiSelect = false;
			this.dgvZPhanBo3.Name = "dgvZPhanBo3";
			this.dgvZPhanBo3.ReadOnly = true;
			this.dgvZPhanBo3.Size = new System.Drawing.Size(772, 495);
			this.dgvZPhanBo3.strZone = "";
			this.dgvZPhanBo3.TabIndex = 1;
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.Location = new System.Drawing.Point(674, 537);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(111, 23);
			this.btExit.TabIndex = 1;
			this.btExit.Tag = "Exit";
			this.btExit.Text = "&Quay ra";
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// frmZPhanBo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btExit;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.btExit);
			this.Controls.Add(this.rsTabControl1);
			this.Name = "frmZPhanBo";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "frmCosting";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.rsTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvZPhanBo1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvZPhanBo2)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvZPhanBo3)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl rsTabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private RosySystem.Control.rsDataGridView dgvZPhanBo1;
		private RosySystem.Control.rsDataGridView dgvZPhanBo2;
		private RosySystem.Control.rsDataGridView dgvZPhanBo3;
		private RosySystem.Control.rsButton btExit;
		private RosySystem.Control.rsTextBox txtTk_Cp1;
		private RosySystem.Control.rsTextBox txtTk_Cp4;
		private RosySystem.Control.rsTextBox txtTk_Cp3;
		private RosySystem.Control.rsTextBox txtTk_Cp2;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private RosySystem.Control.rsTextBox txtTk_Den;
	}
}