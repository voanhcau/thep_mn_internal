namespace RosyModule.Costing
{
	partial class frmZDauKy
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.rsTabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dgvZDauKyYt = new RosySystem.Control.rsDataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dgvZDauKySp = new RosySystem.Control.rsDataGridView();
			this.dgvZDauKySpSum = new RosySystem.Control.rsDataGridView();
			this.btExit = new RosySystem.Control.rsButton();

			this.rsTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvZDauKyYt)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvZDauKySp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvZDauKySpSum)).BeginInit();
			this.SuspendLayout();
			// 
			// rsTabControl1
			// 
			this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rsTabControl1.Controls.Add(this.tabPage1);
			this.rsTabControl1.Controls.Add(this.tabPage2);
			this.rsTabControl1.Location = new System.Drawing.Point(6, 6);
			this.rsTabControl1.Name = "rsTabControl1";
			this.rsTabControl1.SelectedIndex = 0;
			this.rsTabControl1.Size = new System.Drawing.Size(780, 525);
			this.rsTabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgvZDauKyYt);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(772, 499);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Dở dang yếu tố trên dây chuyền";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dgvZDauKyYt
			// 
			this.dgvZDauKyYt.AllowUserToAddRows = false;
			this.dgvZDauKyYt.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvZDauKyYt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvZDauKyYt.BackgroundColor = System.Drawing.Color.White;
			this.dgvZDauKyYt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvZDauKyYt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvZDauKyYt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvZDauKyYt.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvZDauKyYt.Location = new System.Drawing.Point(3, 3);
			this.dgvZDauKyYt.MultiSelect = false;
			this.dgvZDauKyYt.Name = "dgvZDauKyYt";
			this.dgvZDauKyYt.ReadOnly = true;
			this.dgvZDauKyYt.Size = new System.Drawing.Size(766, 493);
			this.dgvZDauKyYt.strZone = "";
			this.dgvZDauKyYt.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dgvZDauKySp);
			this.tabPage2.Controls.Add(this.dgvZDauKySpSum);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(772, 499);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Dở dang sản phẩm";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dgvZDauKySp
			// 
			this.dgvZDauKySp.AllowUserToAddRows = false;
			this.dgvZDauKySp.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvZDauKySp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvZDauKySp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvZDauKySp.BackgroundColor = System.Drawing.Color.White;
			this.dgvZDauKySp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvZDauKySp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvZDauKySp.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvZDauKySp.Location = new System.Drawing.Point(3, 257);
			this.dgvZDauKySp.MultiSelect = false;
			this.dgvZDauKySp.Name = "dgvZDauKySp";
			this.dgvZDauKySp.ReadOnly = true;
			this.dgvZDauKySp.Size = new System.Drawing.Size(766, 236);
			this.dgvZDauKySp.strZone = "";
			this.dgvZDauKySp.TabIndex = 1;
			// 
			// dgvZDauKySp0
			// 
			this.dgvZDauKySpSum.AllowUserToAddRows = false;
			this.dgvZDauKySpSum.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvZDauKySpSum.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvZDauKySpSum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvZDauKySpSum.BackgroundColor = System.Drawing.Color.White;
			this.dgvZDauKySpSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvZDauKySpSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvZDauKySpSum.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvZDauKySpSum.Location = new System.Drawing.Point(3, 3);
			this.dgvZDauKySpSum.MultiSelect = false;
			this.dgvZDauKySpSum.Name = "dgvZDauKySp0";
			this.dgvZDauKySpSum.ReadOnly = true;
			this.dgvZDauKySpSum.Size = new System.Drawing.Size(766, 248);
			this.dgvZDauKySpSum.strZone = "";
			this.dgvZDauKySpSum.TabIndex = 0;
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.Location = new System.Drawing.Point(668, 537);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(111, 23);
			this.btExit.TabIndex = 4;
			this.btExit.Text = "&Quay ra";
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// frmZDauKy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.btExit);
			this.Controls.Add(this.rsTabControl1);
			this.Name = "frmZDauKy";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Tag = "DmYt,F2,F3,F8,ESC";
			this.Text = "frmDmYt";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

			this.rsTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvZDauKyYt)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvZDauKySp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvZDauKySpSum)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl rsTabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private RosySystem.Control.rsButton btExit;
		private RosySystem.Control.rsDataGridView dgvZDauKyYt;
		private RosySystem.Control.rsDataGridView dgvZDauKySpSum;
		private RosySystem.Control.rsDataGridView dgvZDauKySp;

	}
}