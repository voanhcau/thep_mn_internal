namespace RosyModule.General
{
	partial class frmTinh_CLTG
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvKetQuaCLTG = new RosySystem.Control.rsDataGridView();
			this.btTinhCLTG = new RosySystem.Control.rsButton();
			this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
			this.lblNgay_Ct1 = new RosySystem.Control.rsLabel();
			this.chkIs_Hach_Toan = new RosySystem.Control.rsCheckbox();
			this.dgvCLTG = new RosySystem.Control.rsDataGridView();
			this.btTinhCLTG_HetSoDu = new RosySystem.Control.rsButton();
			((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaCLTG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCLTG)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvKetQuaCLTG
			// 
			this.dgvKetQuaCLTG.AllowUserToAddRows = false;
			this.dgvKetQuaCLTG.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvKetQuaCLTG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvKetQuaCLTG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvKetQuaCLTG.BackgroundColor = System.Drawing.Color.White;
			this.dgvKetQuaCLTG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvKetQuaCLTG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKetQuaCLTG.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvKetQuaCLTG.Location = new System.Drawing.Point(3, 354);
			this.dgvKetQuaCLTG.MultiSelect = false;
			this.dgvKetQuaCLTG.Name = "dgvKetQuaCLTG";
			this.dgvKetQuaCLTG.ReadOnly = true;
			this.dgvKetQuaCLTG.Size = new System.Drawing.Size(911, 214);
			this.dgvKetQuaCLTG.strZone = "";
			this.dgvKetQuaCLTG.TabIndex = 10;
			// 
			// btTinhCLTG
			// 
			this.btTinhCLTG.Location = new System.Drawing.Point(19, 58);
			this.btTinhCLTG.Name = "btTinhCLTG";
			this.btTinhCLTG.Size = new System.Drawing.Size(215, 23);
			this.btTinhCLTG.TabIndex = 8;
			this.btTinhCLTG.Tag = "";
			this.btTinhCLTG.Text = "&2. Tính CLTG";
			this.btTinhCLTG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btTinhCLTG.UseVisualStyleBackColor = true;
			// 
			// dteNgay_Ct
			// 
			this.dteNgay_Ct.bAllowEmpty = true;
			this.dteNgay_Ct.bSelectOnFocus = false;
			this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct.Location = new System.Drawing.Point(108, 7);
			this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct.Mask = "00/00/0000";
			this.dteNgay_Ct.Name = "dteNgay_Ct";
			this.dteNgay_Ct.Size = new System.Drawing.Size(68, 20);
			this.dteNgay_Ct.TabIndex = 0;
			// 
			// lblNgay_Ct1
			// 
			this.lblNgay_Ct1.AutoEllipsis = true;
			this.lblNgay_Ct1.AutoSize = true;
			this.lblNgay_Ct1.Location = new System.Drawing.Point(15, 11);
			this.lblNgay_Ct1.Name = "lblNgay_Ct1";
			this.lblNgay_Ct1.Size = new System.Drawing.Size(93, 13);
			this.lblNgay_Ct1.TabIndex = 89;
			this.lblNgay_Ct1.Tag = "";
			this.lblNgay_Ct1.Text = "Ngày đánh giá CL";
			this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkIs_Hach_Toan
			// 
			this.chkIs_Hach_Toan.AutoSize = true;
			this.chkIs_Hach_Toan.Location = new System.Drawing.Point(240, 62);
			this.chkIs_Hach_Toan.Name = "chkIs_Hach_Toan";
			this.chkIs_Hach_Toan.Size = new System.Drawing.Size(125, 17);
			this.chkIs_Hach_Toan.TabIndex = 9;
			this.chkIs_Hach_Toan.Text = "Tạo phiếu hạch toán";
			this.chkIs_Hach_Toan.UseVisualStyleBackColor = true;
			// 
			// dgvCLTG
			// 
			this.dgvCLTG.AllowUserToAddRows = false;
			this.dgvCLTG.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvCLTG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvCLTG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCLTG.BackgroundColor = System.Drawing.Color.White;
			this.dgvCLTG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvCLTG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCLTG.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvCLTG.Location = new System.Drawing.Point(3, 85);
			this.dgvCLTG.Margin = new System.Windows.Forms.Padding(1);
			this.dgvCLTG.MultiSelect = false;
			this.dgvCLTG.Name = "dgvCLTG";
			this.dgvCLTG.ReadOnly = true;
			this.dgvCLTG.Size = new System.Drawing.Size(910, 265);
			this.dgvCLTG.strZone = "";
			this.dgvCLTG.TabIndex = 10;
			// 
			// btTinhCLTG_HetSoDu
			// 
			this.btTinhCLTG_HetSoDu.Location = new System.Drawing.Point(19, 35);
			this.btTinhCLTG_HetSoDu.Name = "btTinhCLTG_HetSoDu";
			this.btTinhCLTG_HetSoDu.Size = new System.Drawing.Size(215, 23);
			this.btTinhCLTG_HetSoDu.TabIndex = 8;
			this.btTinhCLTG_HetSoDu.Tag = "";
			this.btTinhCLTG_HetSoDu.Text = "&1. Tính CLTG cho những tài khoản hết Nt";
			this.btTinhCLTG_HetSoDu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btTinhCLTG_HetSoDu.UseVisualStyleBackColor = true;
			// 
			// frmTinh_CLTG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(923, 569);
			this.Controls.Add(this.chkIs_Hach_Toan);
			this.Controls.Add(this.dteNgay_Ct);
			this.Controls.Add(this.lblNgay_Ct1);
			this.Controls.Add(this.btTinhCLTG_HetSoDu);
			this.Controls.Add(this.btTinhCLTG);
			this.Controls.Add(this.dgvCLTG);
			this.Controls.Add(this.dgvKetQuaCLTG);
			this.Name = "frmTinh_CLTG";
			this.Tag = "frmCtTS, F2, F3, F8, ESC";
			this.Text = "Phân bổ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaCLTG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCLTG)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvKetQuaCLTG;
		private RosySystem.Control.rsButton btTinhCLTG;
		private RosySystem.Control.rsDateTime dteNgay_Ct;
		private RosySystem.Control.rsLabel lblNgay_Ct1;
		private RosySystem.Control.rsCheckbox chkIs_Hach_Toan;
		private RosySystem.Control.rsDataGridView dgvCLTG;
		private RosySystem.Control.rsButton btTinhCLTG_HetSoDu;


	}
}