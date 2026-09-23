namespace RosyModule.Machinery
{
	partial class frmInherit
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.dgvKHBTSC = new RosySystem.Control.rsDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvKHBTSC)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(591, 548);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 45);
			this.btgAccept.TabIndex = 3;
			// 
			// dgvKHBTSC
			// 
			this.dgvKHBTSC.AllowUserToAddRows = false;
			this.dgvKHBTSC.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvKHBTSC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvKHBTSC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvKHBTSC.BackgroundColor = System.Drawing.Color.White;
			this.dgvKHBTSC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvKHBTSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKHBTSC.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvKHBTSC.Location = new System.Drawing.Point(0, 0);
			this.dgvKHBTSC.MultiSelect = false;
			this.dgvKHBTSC.Name = "dgvKHBTSC";
			this.dgvKHBTSC.ReadOnly = true;
			this.dgvKHBTSC.Size = new System.Drawing.Size(784, 526);
			this.dgvKHBTSC.strZone = "";
			this.dgvKHBTSC.TabIndex = 4;
			// 
			// frmInherit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 605);
			this.Controls.Add(this.dgvKHBTSC);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmInherit";
			this.Text = "Kế thừa kế hoạch";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvKHBTSC)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsDataGridView dgvKHBTSC;
	}
}