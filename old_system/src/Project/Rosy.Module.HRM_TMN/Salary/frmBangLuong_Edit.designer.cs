namespace RosyModule.Salary
{
	partial class frmBangLuong_Edit
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
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.dgvSalary_Edit = new RosySystem.Control.rsDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvSalary_Edit)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(242, 316);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 1;
			// 
			// dgvSalary_Edit
			// 
			this.dgvSalary_Edit.AllowUserToAddRows = false;
			this.dgvSalary_Edit.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvSalary_Edit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvSalary_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvSalary_Edit.BackgroundColor = System.Drawing.Color.White;
			this.dgvSalary_Edit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvSalary_Edit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSalary_Edit.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvSalary_Edit.Location = new System.Drawing.Point(2, 1);
			this.dgvSalary_Edit.MultiSelect = false;
			this.dgvSalary_Edit.Name = "dgvSalary_Edit";
			this.dgvSalary_Edit.ReadOnly = true;
			this.dgvSalary_Edit.Size = new System.Drawing.Size(421, 309);
			this.dgvSalary_Edit.strZone = "";
			this.dgvSalary_Edit.TabIndex = 0;
			// 
			// frmBangLuong_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 366);
			this.Controls.Add(this.dgvSalary_Edit);
			this.Controls.Add(this.btgAccept);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBangLuong_Edit";
			this.Text = "frmSalary";
			((System.ComponentModel.ISupportInitialize)(this.dgvSalary_Edit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsDataGridView dgvSalary_Edit;

	}
}