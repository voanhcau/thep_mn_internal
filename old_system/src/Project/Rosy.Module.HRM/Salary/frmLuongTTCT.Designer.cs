namespace RosyModule.Salary
{
    partial class frmLuongTTCT
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
            this.dgvDGBPCT = new RosySystem.Control.rsDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDGBPCT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDGBPCT
            // 
            this.dgvDGBPCT.AllowUserToAddRows = false;
            this.dgvDGBPCT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDGBPCT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDGBPCT.BackgroundColor = System.Drawing.Color.White;
            this.dgvDGBPCT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDGBPCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDGBPCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDGBPCT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDGBPCT.Location = new System.Drawing.Point(0, 0);
            this.dgvDGBPCT.MultiSelect = false;
            this.dgvDGBPCT.Name = "dgvDGBPCT";
            this.dgvDGBPCT.ReadOnly = true;
            this.dgvDGBPCT.Size = new System.Drawing.Size(1344, 450);
            this.dgvDGBPCT.strZone = "";
            this.dgvDGBPCT.TabIndex = 1;
            // 
            // frmLuongTTCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 450);
            this.Controls.Add(this.dgvDGBPCT);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmLuongTTCT";
            this.Text = "frmLuongTTCT";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDGBPCT)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Control.rsDataGridView dgvDGBPCT;

    }
}