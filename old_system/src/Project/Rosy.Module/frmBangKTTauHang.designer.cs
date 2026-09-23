namespace RosyModule
{
	partial class frmBangKTTauHang
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtMa_Dt = new RosySystem.Control.rsTextBox();
			this.lbtTen_Hd = new RosySystem.Control.rsLabel();
			this.lblMa_Hd = new RosySystem.Control.rsLabel();
			this.lblMa_Dt = new RosySystem.Control.rsLabel();
			this.txtMa_Hd = new RosySystem.Control.rsTextBox();
			this.lbtTen_Dt = new RosySystem.Control.rsLabel();
			this.dgvKQKN = new RosySystem.Customize.dgvVoucher();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.numHMS3 = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.numHMS2 = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numHMS1 = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel85 = new RosySystem.Control.rsLabel();
			this.numSo_Luong = new RosySystem.Control.rsTextBoxNumber();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvKQKN)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.rsLabel3);
			this.splitContainer.Panel2.Controls.Add(this.numHMS3);
			this.splitContainer.Panel2.Controls.Add(this.rsLabel2);
			this.splitContainer.Panel2.Controls.Add(this.numHMS2);
			this.splitContainer.Panel2.Controls.Add(this.rsLabel1);
			this.splitContainer.Panel2.Controls.Add(this.numHMS1);
			this.splitContainer.Panel2.Controls.Add(this.rsLabel85);
			this.splitContainer.Panel2.Controls.Add(this.numSo_Luong);
			this.splitContainer.Panel2.Controls.Add(this.btgAccept);
			this.splitContainer.Size = new System.Drawing.Size(1022, 475);
			this.splitContainer.SplitterDistance = 364;
			this.splitContainer.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txtMa_Dt);
			this.splitContainer1.Panel1.Controls.Add(this.lbtTen_Hd);
			this.splitContainer1.Panel1.Controls.Add(this.lblMa_Hd);
			this.splitContainer1.Panel1.Controls.Add(this.lblMa_Dt);
			this.splitContainer1.Panel1.Controls.Add(this.txtMa_Hd);
			this.splitContainer1.Panel1.Controls.Add(this.lbtTen_Dt);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvKQKN);
			this.splitContainer1.Size = new System.Drawing.Size(1022, 364);
			this.splitContainer1.SplitterDistance = 80;
			this.splitContainer1.TabIndex = 0;
			// 
			// txtMa_Dt
			// 
			this.txtMa_Dt.BackColor = System.Drawing.SystemColors.Window;
			this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Dt.Location = new System.Drawing.Point(167, 42);
			this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Dt.MaxLength = 20;
			this.txtMa_Dt.Name = "txtMa_Dt";
			this.txtMa_Dt.ReadOnly = true;
			this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Dt.TabIndex = 60;
			// 
			// lbtTen_Hd
			// 
			this.lbtTen_Hd.AutoEllipsis = true;
			this.lbtTen_Hd.AutoSize = true;
			this.lbtTen_Hd.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Hd.Location = new System.Drawing.Point(292, 24);
			this.lbtTen_Hd.Name = "lbtTen_Hd";
			this.lbtTen_Hd.Size = new System.Drawing.Size(75, 13);
			this.lbtTen_Hd.TabIndex = 61;
			this.lbtTen_Hd.Text = "Tên hợp đồng";
			this.lbtTen_Hd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMa_Hd
			// 
			this.lblMa_Hd.AutoEllipsis = true;
			this.lblMa_Hd.AutoSize = true;
			this.lblMa_Hd.Location = new System.Drawing.Point(64, 23);
			this.lblMa_Hd.Name = "lblMa_Hd";
			this.lblMa_Hd.Size = new System.Drawing.Size(55, 13);
			this.lblMa_Hd.TabIndex = 62;
			this.lblMa_Hd.Tag = "Ma_Hd";
			this.lblMa_Hd.Text = "Hợp đồng";
			this.lblMa_Hd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMa_Dt
			// 
			this.lblMa_Dt.AutoEllipsis = true;
			this.lblMa_Dt.AutoSize = true;
			this.lblMa_Dt.Location = new System.Drawing.Point(64, 45);
			this.lblMa_Dt.Name = "lblMa_Dt";
			this.lblMa_Dt.Size = new System.Drawing.Size(53, 13);
			this.lblMa_Dt.TabIndex = 64;
			this.lblMa_Dt.Tag = "Ma_Dt";
			this.lblMa_Dt.Text = "Đối tượng";
			this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Hd
			// 
			this.txtMa_Hd.BackColor = System.Drawing.SystemColors.Window;
			this.txtMa_Hd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Hd.Location = new System.Drawing.Point(167, 20);
			this.txtMa_Hd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Hd.MaxLength = 20;
			this.txtMa_Hd.Name = "txtMa_Hd";
			this.txtMa_Hd.ReadOnly = true;
			this.txtMa_Hd.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Hd.TabIndex = 59;
			// 
			// lbtTen_Dt
			// 
			this.lbtTen_Dt.AutoEllipsis = true;
			this.lbtTen_Dt.AutoSize = true;
			this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Dt.Location = new System.Drawing.Point(292, 46);
			this.lbtTen_Dt.Name = "lbtTen_Dt";
			this.lbtTen_Dt.Size = new System.Drawing.Size(74, 13);
			this.lbtTen_Dt.TabIndex = 63;
			this.lbtTen_Dt.Text = "Tên đối tượng";
			this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgvKQKN
			// 
			this.dgvKQKN.AllowUserToAddRows = false;
			this.dgvKQKN.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvKQKN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvKQKN.BackgroundColor = System.Drawing.Color.White;
			this.dgvKQKN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvKQKN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKQKN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvKQKN.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvKQKN.Location = new System.Drawing.Point(0, 0);
			this.dgvKQKN.MultiSelect = false;
			this.dgvKQKN.Name = "dgvKQKN";
			this.dgvKQKN.Size = new System.Drawing.Size(1022, 280);
			this.dgvKQKN.strZone = "";
			this.dgvKQKN.TabIndex = 1;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rsLabel3.Location = new System.Drawing.Point(345, 66);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(65, 13);
			this.rsLabel3.TabIndex = 289;
			this.rsLabel3.Text = "Tổng HMS3";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numHMS3
			// 
			this.numHMS3.BackColor = System.Drawing.SystemColors.Window;
			this.numHMS3.bFormat = true;
			this.numHMS3.Location = new System.Drawing.Point(434, 63);
			this.numHMS3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numHMS3.Name = "numHMS3";
			this.numHMS3.ReadOnly = true;
			this.numHMS3.Scale = 2;
			this.numHMS3.Size = new System.Drawing.Size(120, 20);
			this.numHMS3.TabIndex = 288;
			this.numHMS3.Tag = "Tien_No0";
			this.numHMS3.Text = "0.00";
			this.numHMS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numHMS3.Value = 0D;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rsLabel2.Location = new System.Drawing.Point(345, 44);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(65, 13);
			this.rsLabel2.TabIndex = 287;
			this.rsLabel2.Text = "Tổng HMS2";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numHMS2
			// 
			this.numHMS2.BackColor = System.Drawing.SystemColors.Window;
			this.numHMS2.bFormat = true;
			this.numHMS2.Location = new System.Drawing.Point(434, 41);
			this.numHMS2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numHMS2.Name = "numHMS2";
			this.numHMS2.ReadOnly = true;
			this.numHMS2.Scale = 2;
			this.numHMS2.Size = new System.Drawing.Size(120, 20);
			this.numHMS2.TabIndex = 286;
			this.numHMS2.Tag = "Tien_No0";
			this.numHMS2.Text = "0.00";
			this.numHMS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numHMS2.Value = 0D;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rsLabel1.Location = new System.Drawing.Point(345, 22);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(65, 13);
			this.rsLabel1.TabIndex = 285;
			this.rsLabel1.Text = "Tổng HMS1";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numHMS1
			// 
			this.numHMS1.BackColor = System.Drawing.SystemColors.Window;
			this.numHMS1.bFormat = true;
			this.numHMS1.Location = new System.Drawing.Point(434, 19);
			this.numHMS1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numHMS1.Name = "numHMS1";
			this.numHMS1.ReadOnly = true;
			this.numHMS1.Scale = 2;
			this.numHMS1.Size = new System.Drawing.Size(120, 20);
			this.numHMS1.TabIndex = 284;
			this.numHMS1.Tag = "Tien_No0";
			this.numHMS1.Text = "0.00";
			this.numHMS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numHMS1.Value = 0D;
			// 
			// rsLabel85
			// 
			this.rsLabel85.AutoEllipsis = true;
			this.rsLabel85.AutoSize = true;
			this.rsLabel85.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rsLabel85.Location = new System.Drawing.Point(64, 22);
			this.rsLabel85.Name = "rsLabel85";
			this.rsLabel85.Size = new System.Drawing.Size(146, 13);
			this.rsLabel85.TabIndex = 283;
			this.rsLabel85.Text = "Tổng khối lượng kiểm nghiệm";
			this.rsLabel85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numSo_Luong
			// 
			this.numSo_Luong.BackColor = System.Drawing.SystemColors.Window;
			this.numSo_Luong.bFormat = true;
			this.numSo_Luong.Location = new System.Drawing.Point(217, 19);
			this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Luong.Name = "numSo_Luong";
			this.numSo_Luong.ReadOnly = true;
			this.numSo_Luong.Scale = 2;
			this.numSo_Luong.Size = new System.Drawing.Size(120, 20);
			this.numSo_Luong.TabIndex = 282;
			this.numSo_Luong.Tag = "Tien_No0";
			this.numSo_Luong.Text = "0.00";
			this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSo_Luong.Value = 0D;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(829, 50);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 45);
			this.btgAccept.TabIndex = 27;
			// 
			// frmBangKTTauHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1022, 475);
			this.Controls.Add(this.splitContainer);
			this.Name = "frmBangKTTauHang";
			this.Text = "frmBangKQKiemTra";
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvKQKN)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBoxNumber numSo_Luong;
		private RosySystem.Control.rsLabel rsLabel85;
		private RosySystem.Customize.dgvVoucher dgvKQKN;
		private RosySystem.Control.rsTextBox txtMa_Dt;
		private RosySystem.Control.rsLabel lblMa_Dt;
		private RosySystem.Control.rsLabel lbtTen_Dt;
		private RosySystem.Control.rsTextBox txtMa_Hd;
		private RosySystem.Control.rsLabel lblMa_Hd;
		private RosySystem.Control.rsLabel lbtTen_Hd;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBoxNumber numHMS3;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBoxNumber numHMS2;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxNumber numHMS1;
    }
}