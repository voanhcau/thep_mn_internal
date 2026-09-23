namespace RosyControllerTMN
{
	partial class frmGetUsers
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
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.dgvGetUsers = new RosySystem.Control.rsDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvGetUsers)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(450, 348);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 4;
			// 
			// dgvGetUsers
			// 
			this.dgvGetUsers.AllowUserToAddRows = false;
			this.dgvGetUsers.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvGetUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvGetUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGetUsers.BackgroundColor = System.Drawing.Color.White;
			this.dgvGetUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvGetUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGetUsers.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvGetUsers.Location = new System.Drawing.Point(3, 2);
			this.dgvGetUsers.MultiSelect = false;
			this.dgvGetUsers.Name = "dgvGetUsers";
			this.dgvGetUsers.ReadOnly = true;
			this.dgvGetUsers.Size = new System.Drawing.Size(632, 340);
			this.dgvGetUsers.strZone = "";
			this.dgvGetUsers.TabIndex = 5;
			// 
			// frmGetUsers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(637, 397);
			this.Controls.Add(this.dgvGetUsers);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmGetUsers";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "frmGetUsers";
			((System.ComponentModel.ISupportInitialize)(this.dgvGetUsers)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsDataGridView dgvGetUsers;
	}
}