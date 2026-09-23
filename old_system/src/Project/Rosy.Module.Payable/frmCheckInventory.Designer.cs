namespace RosyModule.Payable
{
	partial class frmCheckInventory
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		//protected override void Dispose(bool disposing)
		//{
		//    if (disposing && (components != null))
		//    {
		//        components.Dispose();
		//    }
		//    base.Dispose(disposing);
		//}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgvCheckInventory = new RosySystem.Control.rsDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCheckInventory)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvCheckInventory);
			this.splitContainer1.Size = new System.Drawing.Size(784, 172);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.TabIndex = 6;
			// 
			// dgvCheckInventory
			// 
			this.dgvCheckInventory.AllowUserToAddRows = false;
			this.dgvCheckInventory.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvCheckInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvCheckInventory.BackgroundColor = System.Drawing.Color.White;
			this.dgvCheckInventory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvCheckInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCheckInventory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCheckInventory.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvCheckInventory.Location = new System.Drawing.Point(0, 0);
			this.dgvCheckInventory.MultiSelect = false;
			this.dgvCheckInventory.Name = "dgvCheckInventory";
			this.dgvCheckInventory.ReadOnly = true;
			this.dgvCheckInventory.Size = new System.Drawing.Size(784, 143);
			this.dgvCheckInventory.strZone = "";
			this.dgvCheckInventory.TabIndex = 6;
			// 
			// frmCheckInventory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 172);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmCheckInventory";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "";
			this.Text = "Kiểm tra tồn kho [{0}]; F9-Chuyển con trỏ; F4 Tìm kiếm; F12: Xem toàn bộ";
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCheckInventory)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private RosySystem.Control.rsDataGridView dgvCheckInventory;

	}
}