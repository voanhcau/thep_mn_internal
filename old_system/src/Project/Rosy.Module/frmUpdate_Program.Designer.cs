namespace RosyModule
{
    partial class frmUpdate_Program
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
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbPhieu_Xuat = new RosySystem.Control.rsRadioButton();
            this.dgvWS = new RosySystem.Customize.dgvVoucher();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.gbIn_Tien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWS)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(873, 659);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.rdbPhieu_Xuat);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(259, 71);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Cập nhật";
            // 
            // rdbPhieu_Xuat
            // 
            this.rdbPhieu_Xuat.AutoSize = true;
            this.rdbPhieu_Xuat.Checked = true;
            this.rdbPhieu_Xuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPhieu_Xuat.Location = new System.Drawing.Point(16, 29);
            this.rdbPhieu_Xuat.Name = "rdbPhieu_Xuat";
            this.rdbPhieu_Xuat.Size = new System.Drawing.Size(212, 17);
            this.rdbPhieu_Xuat.TabIndex = 2;
            this.rdbPhieu_Xuat.TabStop = true;
            this.rdbPhieu_Xuat.Tag = "";
            this.rdbPhieu_Xuat.Text = "Cập nhật các dll mới cho các máy client";
            this.rdbPhieu_Xuat.UnChecked = false;
            this.rdbPhieu_Xuat.UseVisualStyleBackColor = true;
            // 
            // dgvWS
            // 
            this.dgvWS.AllowUserToAddRows = false;
            this.dgvWS.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvWS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWS.BackgroundColor = System.Drawing.Color.White;
            this.dgvWS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvWS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWS.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvWS.Location = new System.Drawing.Point(21, 114);
            this.dgvWS.MultiSelect = false;
            this.dgvWS.Name = "dgvWS";
            this.dgvWS.Size = new System.Drawing.Size(1033, 539);
            this.dgvWS.strZone = "";
            this.dgvWS.TabIndex = 11;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(22, 89);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(101, 13);
            this.rsLabel11.TabIndex = 1005;
            this.rsLabel11.Tag = "";
            this.rsLabel11.Text = "Các máy tính online";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUpdate_Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 716);
            this.Controls.Add(this.rsLabel11);
            this.Controls.Add(this.dgvWS);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmUpdate_Program";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbPhieu_Xuat;
        private RosySystem.Customize.dgvVoucher dgvWS;
        private RosySystem.Control.rsLabel rsLabel11;
	}
}