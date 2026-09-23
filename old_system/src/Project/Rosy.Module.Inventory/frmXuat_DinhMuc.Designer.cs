namespace RosyModule.Inventory
{
	partial class frmXuat_DinhMuc
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
			this.numSo_Luong = new RosySystem.Control.rsTextBoxNumber();
			this.lblSo_Luong = new RosySystem.Control.rsLabel();
			this.txtMa_Vt_Sp = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.lbtTen_Vt_Sp = new RosySystem.Control.rsLabelName();
			this.dgvDinhMuc = new RosySystem.Control.rsDataGridView();
			this.btRefresh = new RosySystem.Control.rsButton();
			((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(449, 368);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 45);
			this.btgAccept.TabIndex = 2;
			// 
			// numSo_Luong
			// 
			this.numSo_Luong.bFormat = true;
			this.numSo_Luong.Location = new System.Drawing.Point(103, 51);
			this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Luong.Name = "numSo_Luong";
			this.numSo_Luong.Scale = 2;
			this.numSo_Luong.Size = new System.Drawing.Size(98, 20);
			this.numSo_Luong.TabIndex = 1;
			this.numSo_Luong.Text = "0.00";
			this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSo_Luong.Value = 0D;
			// 
			// lblSo_Luong
			// 
			this.lblSo_Luong.AutoEllipsis = true;
			this.lblSo_Luong.AutoSize = true;
			this.lblSo_Luong.Location = new System.Drawing.Point(24, 55);
			this.lblSo_Luong.Name = "lblSo_Luong";
			this.lblSo_Luong.Size = new System.Drawing.Size(49, 13);
			this.lblSo_Luong.TabIndex = 4;
			this.lblSo_Luong.Tag = "So_Luong";
			this.lblSo_Luong.Text = "Số lượng";
			this.lblSo_Luong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Vt_Sp
			// 
			this.txtMa_Vt_Sp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Vt_Sp.Location = new System.Drawing.Point(103, 24);
			this.txtMa_Vt_Sp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Vt_Sp.MaxLength = 20;
			this.txtMa_Vt_Sp.Name = "txtMa_Vt_Sp";
			this.txtMa_Vt_Sp.Size = new System.Drawing.Size(98, 20);
			this.txtMa_Vt_Sp.TabIndex = 0;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(24, 27);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(71, 13);
			this.rsLabel1.TabIndex = 62;
			this.rsLabel1.Tag = "Ma_Vt_Sp";
			this.rsLabel1.Text = "Mã sản phẩm";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Vt_Sp
			// 
			this.lbtTen_Vt_Sp.AutoEllipsis = true;
			this.lbtTen_Vt_Sp.AutoSize = true;
			this.lbtTen_Vt_Sp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtTen_Vt_Sp.Location = new System.Drawing.Point(206, 28);
			this.lbtTen_Vt_Sp.Name = "lbtTen_Vt_Sp";
			this.lbtTen_Vt_Sp.Size = new System.Drawing.Size(56, 13);
			this.lbtTen_Vt_Sp.TabIndex = 63;
			this.lbtTen_Vt_Sp.Tag = "";
			this.lbtTen_Vt_Sp.Text = "lbtTen_Sp";
			this.lbtTen_Vt_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgvDinhMuc
			// 
			this.dgvDinhMuc.AllowUserToAddRows = false;
			this.dgvDinhMuc.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvDinhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDinhMuc.BackgroundColor = System.Drawing.Color.White;
			this.dgvDinhMuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvDinhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDinhMuc.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvDinhMuc.Location = new System.Drawing.Point(3, 77);
			this.dgvDinhMuc.MultiSelect = false;
			this.dgvDinhMuc.Name = "dgvDinhMuc";
			this.dgvDinhMuc.ReadOnly = true;
			this.dgvDinhMuc.Size = new System.Drawing.Size(632, 281);
			this.dgvDinhMuc.strZone = "";
			this.dgvDinhMuc.TabIndex = 64;
			// 
			// btRefresh
			// 
			this.btRefresh.Location = new System.Drawing.Point(228, 48);
			this.btRefresh.Name = "btRefresh";
			this.btRefresh.Size = new System.Drawing.Size(75, 23);
			this.btRefresh.TabIndex = 65;
			this.btRefresh.Tag = "Refresh";
			this.btRefresh.Text = "&Refresh";
			this.btRefresh.UseVisualStyleBackColor = true;
			// 
			// frmXuat_DinhMuc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 421);
			this.Controls.Add(this.btRefresh);
			this.Controls.Add(this.dgvDinhMuc);
			this.Controls.Add(this.lbtTen_Vt_Sp);
			this.Controls.Add(this.txtMa_Vt_Sp);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.numSo_Luong);
			this.Controls.Add(this.lblSo_Luong);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmXuat_DinhMuc";
			this.Tag = "frmCtSoSize";
			this.Text = "frmCtSoSize";
			((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBoxNumber numSo_Luong;
		private RosySystem.Control.rsLabel lblSo_Luong;
		private RosySystem.Control.rsTextBox txtMa_Vt_Sp;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabelName lbtTen_Vt_Sp;
		private RosySystem.Control.rsDataGridView dgvDinhMuc;
		private RosySystem.Control.rsButton btRefresh;
	}
}