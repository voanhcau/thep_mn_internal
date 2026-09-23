namespace RosyModule.Asset
{
	partial class frmKhauHao
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
			this.numThang = new RosySystem.Control.rsTextBoxNumber();
			this.label1 = new RosySystem.Control.rsLabel();
			this.lbtTen_Nh_Vt_Ts = new RosySystem.Control.rsLabel();
			this.txtMa_Nh_Vt_Ts = new RosySystem.Control.rsTextBox();
			this.lblMa_Nh_Ts = new RosySystem.Control.rsLabel();
			this.txtMa_Vt_Ts = new RosySystem.Control.rsTextBox();
			this.lbMa_Ts = new RosySystem.Control.rsLabel();
			this.lblTen_Vt_Ts = new RosySystem.Control.rsLabel();
			this.btThuc_Hien = new RosySystem.Control.rsButton();
			this.btQuay_Ra = new RosySystem.Control.rsButton();
			this.btPosted = new RosySystem.Control.rsButton();
			this.dgvKhauHao = new RosySystem.Control.rsDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvKhauHao)).BeginInit();
			this.SuspendLayout();
			// 
			// numThang
			// 
			this.numThang.bFormat = true;
			this.numThang.Location = new System.Drawing.Point(107, 12);
			this.numThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numThang.Name = "numThang";
			this.numThang.Scale = 0;
			this.numThang.Size = new System.Drawing.Size(33, 20);
			this.numThang.TabIndex = 0;
			this.numThang.Text = "0";
			this.numThang.Value = 0D;
			// 
			// label1
			// 
			this.label1.AutoEllipsis = true;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 14;
			this.label1.Tag = "Month";
			this.label1.Text = "Tháng";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Nh_Vt_Ts
			// 
			this.lbtTen_Nh_Vt_Ts.AutoEllipsis = true;
			this.lbtTen_Nh_Vt_Ts.AutoSize = true;
			this.lbtTen_Nh_Vt_Ts.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Nh_Vt_Ts.Location = new System.Drawing.Point(236, 59);
			this.lbtTen_Nh_Vt_Ts.Name = "lbtTen_Nh_Vt_Ts";
			this.lbtTen_Nh_Vt_Ts.Size = new System.Drawing.Size(55, 13);
			this.lbtTen_Nh_Vt_Ts.TabIndex = 61;
			this.lbtTen_Nh_Vt_Ts.Tag = "Ten_Nh_Ts";
			this.lbtTen_Nh_Vt_Ts.Text = "Tên nhóm";
			this.lbtTen_Nh_Vt_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Nh_Vt_Ts
			// 
			this.txtMa_Nh_Vt_Ts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Nh_Vt_Ts.Location = new System.Drawing.Point(107, 56);
			this.txtMa_Nh_Vt_Ts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Nh_Vt_Ts.MaxLength = 20;
			this.txtMa_Nh_Vt_Ts.Name = "txtMa_Nh_Vt_Ts";
			this.txtMa_Nh_Vt_Ts.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Nh_Vt_Ts.TabIndex = 2;
			// 
			// lblMa_Nh_Ts
			// 
			this.lblMa_Nh_Ts.AutoEllipsis = true;
			this.lblMa_Nh_Ts.AutoSize = true;
			this.lblMa_Nh_Ts.Location = new System.Drawing.Point(23, 59);
			this.lblMa_Nh_Ts.Name = "lblMa_Nh_Ts";
			this.lblMa_Nh_Ts.Size = new System.Drawing.Size(51, 13);
			this.lblMa_Nh_Ts.TabIndex = 60;
			this.lblMa_Nh_Ts.Tag = "Ma_Nh_Vt_Ts";
			this.lblMa_Nh_Ts.Text = "Mã nhóm";
			this.lblMa_Nh_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Vt_Ts
			// 
			this.txtMa_Vt_Ts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Vt_Ts.Location = new System.Drawing.Point(107, 34);
			this.txtMa_Vt_Ts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt_Ts.MaxLength = 20;
			this.txtMa_Vt_Ts.Name = "txtMa_Vt_Ts";
			this.txtMa_Vt_Ts.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Vt_Ts.TabIndex = 1;
			// 
			// lbMa_Ts
			// 
			this.lbMa_Ts.AutoEllipsis = true;
			this.lbMa_Ts.AutoSize = true;
			this.lbMa_Ts.Location = new System.Drawing.Point(23, 37);
			this.lbMa_Ts.Name = "lbMa_Ts";
			this.lbMa_Ts.Size = new System.Drawing.Size(56, 13);
			this.lbMa_Ts.TabIndex = 59;
			this.lbMa_Ts.Tag = "Ma_Vt_Ts";
			this.lbMa_Ts.Text = "Mã tài sản";
			this.lbMa_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTen_Vt_Ts
			// 
			this.lblTen_Vt_Ts.AutoEllipsis = true;
			this.lblTen_Vt_Ts.AutoSize = true;
			this.lblTen_Vt_Ts.ForeColor = System.Drawing.Color.Blue;
			this.lblTen_Vt_Ts.Location = new System.Drawing.Point(236, 37);
			this.lblTen_Vt_Ts.Name = "lblTen_Vt_Ts";
			this.lblTen_Vt_Ts.Size = new System.Drawing.Size(60, 13);
			this.lblTen_Vt_Ts.TabIndex = 61;
			this.lblTen_Vt_Ts.Tag = "Ten_Vt_Ts";
			this.lblTen_Vt_Ts.Text = "Tên tài sản";
			this.lblTen_Vt_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btThuc_Hien
			// 
			this.btThuc_Hien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btThuc_Hien.Location = new System.Drawing.Point(4, 531);
			this.btThuc_Hien.Name = "btThuc_Hien";
			this.btThuc_Hien.Size = new System.Drawing.Size(130, 23);
			this.btThuc_Hien.TabIndex = 64;
			this.btThuc_Hien.Text = "&Tính khấu hao";
			this.btThuc_Hien.UseVisualStyleBackColor = true;
			// 
			// btQuay_Ra
			// 
			this.btQuay_Ra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btQuay_Ra.Location = new System.Drawing.Point(691, 531);
			this.btQuay_Ra.Name = "btQuay_Ra";
			this.btQuay_Ra.Size = new System.Drawing.Size(89, 23);
			this.btQuay_Ra.TabIndex = 64;
			this.btQuay_Ra.Text = "&Quay ra";
			this.btQuay_Ra.UseVisualStyleBackColor = true;
			// 
			// btPosted
			// 
			this.btPosted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btPosted.Location = new System.Drawing.Point(140, 531);
			this.btPosted.Name = "btPosted";
			this.btPosted.Size = new System.Drawing.Size(120, 23);
			this.btPosted.TabIndex = 64;
			this.btPosted.Text = "Tạo &phiếu hạch toán";
			this.btPosted.UseVisualStyleBackColor = true;
			// 
			// dgvKhauHao
			// 
			this.dgvKhauHao.AllowUserToAddRows = false;
			this.dgvKhauHao.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvKhauHao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvKhauHao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvKhauHao.BackgroundColor = System.Drawing.Color.White;
			this.dgvKhauHao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvKhauHao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKhauHao.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvKhauHao.Location = new System.Drawing.Point(4, 81);
			this.dgvKhauHao.MultiSelect = false;
			this.dgvKhauHao.Name = "dgvKhauHao";
			this.dgvKhauHao.ReadOnly = true;
			this.dgvKhauHao.Size = new System.Drawing.Size(786, 444);
			this.dgvKhauHao.strZone = "";
			this.dgvKhauHao.TabIndex = 3;
			// 
			// frmKhauHao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.btQuay_Ra);
			this.Controls.Add(this.btPosted);
			this.Controls.Add(this.btThuc_Hien);
			this.Controls.Add(this.lblTen_Vt_Ts);
			this.Controls.Add(this.lbtTen_Nh_Vt_Ts);
			this.Controls.Add(this.txtMa_Nh_Vt_Ts);
			this.Controls.Add(this.lblMa_Nh_Ts);
			this.Controls.Add(this.txtMa_Vt_Ts);
			this.Controls.Add(this.lbMa_Ts);
			this.Controls.Add(this.dgvKhauHao);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numThang);
			this.Name = "frmKhauHao";
			this.Text = "frmKhauHao";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvKhauHao)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBoxNumber numThang;
		private RosySystem.Control.rsLabel label1;
		private RosySystem.Control.rsLabel lbtTen_Nh_Vt_Ts;
		private RosySystem.Control.rsTextBox txtMa_Nh_Vt_Ts;
		private RosySystem.Control.rsLabel lblMa_Nh_Ts;
		private RosySystem.Control.rsTextBox txtMa_Vt_Ts;
		private RosySystem.Control.rsLabel lbMa_Ts;
		private RosySystem.Control.rsLabel lblTen_Vt_Ts;
		private RosySystem.Control.rsButton btThuc_Hien;
		private RosySystem.Control.rsButton btQuay_Ra;
		private RosySystem.Control.rsButton btPosted;
		private RosySystem.Control.rsDataGridView dgvKhauHao;
	}
}