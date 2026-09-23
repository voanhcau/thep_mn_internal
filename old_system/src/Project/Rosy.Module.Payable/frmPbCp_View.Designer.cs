namespace RosyModule.Payable
{
	partial class frmPbCp_View
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
            this.dgvViewPn = new RosySystem.Control.rsDataGridView();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvViewPn
            // 
            this.dgvViewPn.AllowUserToAddRows = false;
            this.dgvViewPn.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvViewPn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewPn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViewPn.BackgroundColor = System.Drawing.Color.White;
            this.dgvViewPn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvViewPn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewPn.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvViewPn.Location = new System.Drawing.Point(2, 1);
            this.dgvViewPn.Margin = new System.Windows.Forms.Padding(1);
            this.dgvViewPn.MultiSelect = false;
            this.dgvViewPn.Name = "dgvViewPn";
            this.dgvViewPn.ReadOnly = true;
            this.dgvViewPn.Size = new System.Drawing.Size(788, 519);
            this.dgvViewPn.strZone = "";
            this.dgvViewPn.TabIndex = 0;
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(594, 524);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(182, 43);
            this.btgAccept.TabIndex = 1;
            this.btgAccept.TabStop = false;
            // 
            // frmPbCp_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.dgvViewPn);
            this.Name = "frmPbCp_View";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Tag = "frmCtNM,ESC";
            this.Text = "frmCtNM";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPn)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvViewPn;
		private RosySystem.Customize.btgAccept btgAccept;

	}
}