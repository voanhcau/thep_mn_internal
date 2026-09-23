namespace RosyModule.Salary
{
    partial class frmSuaDLChamCong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btExit = new RosySystem.Control.rsButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvChamCong = new RosySystem.Customize.dgvVoucher();
            this.dgvChamCongCt = new RosySystem.Customize.dgvVoucher();
            this.btEdit = new RosySystem.Control.rsButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCongCt)).BeginInit();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Location = new System.Drawing.Point(1170, 589);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(67, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvChamCong);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvChamCongCt);
            this.splitContainer1.Size = new System.Drawing.Size(1234, 571);
            this.splitContainer1.SplitterDistance = 625;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvChamCong
            // 
            this.dgvChamCong.AllowUserToAddRows = false;
            this.dgvChamCong.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvChamCong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChamCong.BackgroundColor = System.Drawing.Color.White;
            this.dgvChamCong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChamCong.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvChamCong.Location = new System.Drawing.Point(0, 0);
            this.dgvChamCong.MultiSelect = false;
            this.dgvChamCong.Name = "dgvChamCong";
            this.dgvChamCong.Size = new System.Drawing.Size(625, 571);
            this.dgvChamCong.strZone = "";
            this.dgvChamCong.TabIndex = 2;
            // 
            // dgvChamCongCt
            // 
            this.dgvChamCongCt.AllowUserToAddRows = false;
            this.dgvChamCongCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvChamCongCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChamCongCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvChamCongCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChamCongCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamCongCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChamCongCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvChamCongCt.Location = new System.Drawing.Point(0, 0);
            this.dgvChamCongCt.MultiSelect = false;
            this.dgvChamCongCt.Name = "dgvChamCongCt";
            this.dgvChamCongCt.Size = new System.Drawing.Size(605, 571);
            this.dgvChamCongCt.strZone = "";
            this.dgvChamCongCt.TabIndex = 2;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Location = new System.Drawing.Point(1097, 589);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(67, 23);
            this.btEdit.TabIndex = 1;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "&Sửa";
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // frmSuaDLChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 624);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuaDLChamCong";
            this.Text = "Sửa dữ liệu chấm công";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCongCt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Control.rsButton btExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Customize.dgvVoucher dgvChamCong;
        private RosySystem.Customize.dgvVoucher dgvChamCongCt;
        private RosySystem.Control.rsButton btEdit;
	}
}