namespace RosyControllerTMN
{
	partial class frmReminder_Birthday
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
			this.dgvReminder_Birthday = new RosySystem.Control.rsDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvReminder_Birthday)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvReminder_Birthday
			// 
			this.dgvReminder_Birthday.AllowUserToAddRows = false;
			this.dgvReminder_Birthday.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvReminder_Birthday.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvReminder_Birthday.BackgroundColor = System.Drawing.Color.White;
			this.dgvReminder_Birthday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvReminder_Birthday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReminder_Birthday.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvReminder_Birthday.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvReminder_Birthday.Location = new System.Drawing.Point(0, 0);
			this.dgvReminder_Birthday.MultiSelect = false;
			this.dgvReminder_Birthday.Name = "dgvReminder_Birthday";
			this.dgvReminder_Birthday.ReadOnly = true;
			this.dgvReminder_Birthday.Size = new System.Drawing.Size(784, 562);
			this.dgvReminder_Birthday.strZone = "";
			this.dgvReminder_Birthday.TabIndex = 0;
			// 
			// frmReminder_Birthday
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.dgvReminder_Birthday);
			this.Name = "frmReminder_Birthday";
			this.Text = "frmReminder_Birthday";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvReminder_Birthday)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvReminder_Birthday;
	}
}