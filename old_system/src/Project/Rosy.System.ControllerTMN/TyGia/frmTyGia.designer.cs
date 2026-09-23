namespace RosyControllerTMN
{
	partial class frmTyGia
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
			this.dgvDmTte = new RosySystem.Control.rsDataGridView();
			this.dgvTyGia = new RosySystem.Control.rsDataGridView();

			((System.ComponentModel.ISupportInitialize)(this.dgvDmTte)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTyGia)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvDmTte
			// 
			this.dgvDmTte.AllowUserToAddRows = false;
			this.dgvDmTte.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvDmTte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDmTte.BackgroundColor = System.Drawing.Color.White;
			this.dgvDmTte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvDmTte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDmTte.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDmTte.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvDmTte.Location = new System.Drawing.Point(3, 3);
			this.dgvDmTte.MultiSelect = false;
			this.dgvDmTte.Name = "dgvDmTte";
			this.dgvDmTte.ReadOnly = true;
			this.dgvDmTte.Size = new System.Drawing.Size(786, 560);
			this.dgvDmTte.strZone = "";
			this.dgvDmTte.TabIndex = 0;
			// 
			// dgvTyGia
			// 
			this.dgvTyGia.AllowUserToAddRows = false;
			this.dgvTyGia.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvTyGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvTyGia.BackgroundColor = System.Drawing.Color.White;
			this.dgvTyGia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvTyGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTyGia.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvTyGia.Location = new System.Drawing.Point(21, 56);
			this.dgvTyGia.MultiSelect = false;
			this.dgvTyGia.Name = "dgvTyGia";
			this.dgvTyGia.ReadOnly = true;
			this.dgvTyGia.Size = new System.Drawing.Size(224, 187);
			this.dgvTyGia.strZone = "";
			this.dgvTyGia.TabIndex = 1;
			this.dgvTyGia.Visible = false;
			// 
			// frmTyGia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.dgvTyGia);
			this.Controls.Add(this.dgvDmTte);
			this.Name = "frmTyGia";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Tag = "frmChangeID,F2,F3,F8,ESC";
			this.Text = "frmChangeID";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

			((System.ComponentModel.ISupportInitialize)(this.dgvDmTte)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTyGia)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvDmTte;
		private RosySystem.Control.rsDataGridView dgvTyGia;
	}
}