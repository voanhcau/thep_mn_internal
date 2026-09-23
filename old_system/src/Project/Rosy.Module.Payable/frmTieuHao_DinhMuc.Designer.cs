namespace RosyModule.Payable
{
	partial class frmTieuHao_DinhMuc
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
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.txtMa_Bp = new RosySystem.Control.rsTextBox();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dgvDinhMuc = new RosySystem.Control.rsDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(449, 368);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 3;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(43, 13);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(45, 13);
            this.rsLabel1.TabIndex = 62;
            this.rsLabel1.Tag = "Ngay_Ct";
            this.rsLabel1.Text = "Ngày Ct";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(93, 9);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct.TabIndex = 0;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.AutoDropDown = null;
            this.txtMa_Bp.Location = new System.Drawing.Point(93, 33);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(91, 20);
            this.txtMa_Bp.TabIndex = 1;
            this.txtMa_Bp.Tag = "Ma_Vt";
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Location = new System.Drawing.Point(24, 36);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(64, 13);
            this.rsLabel13.TabIndex = 68;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "Mã bộ phận";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Bp.Location = new System.Drawing.Point(190, 36);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(45, 13);
            this.lbtTen_Bp.TabIndex = 66;
            this.lbtTen_Bp.Tag = "Ten_Bp";
            this.lbtTen_Bp.Text = "Ten_Bp";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(550, 22);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(85, 29);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.TabStop = false;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvDinhMuc
            // 
            this.dgvDinhMuc.AllowUserToAddRows = false;
            this.dgvDinhMuc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDinhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDinhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDinhMuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDinhMuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDinhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDinhMuc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDinhMuc.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDinhMuc.Location = new System.Drawing.Point(12, 59);
            this.dgvDinhMuc.MultiSelect = false;
            this.dgvDinhMuc.Name = "dgvDinhMuc";
            this.dgvDinhMuc.ReadOnly = true;
            this.dgvDinhMuc.Size = new System.Drawing.Size(623, 303);
            this.dgvDinhMuc.strZone = "";
            this.dgvDinhMuc.TabIndex = 69;
            // 
            // frmTieuHao_DinhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 421);
            this.Controls.Add(this.dgvDinhMuc);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.txtMa_Bp);
            this.Controls.Add(this.rsLabel13);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.dteNgay_Ct);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmTieuHao_DinhMuc";
            this.Tag = "frmTieuHao_DinhMuc";
            this.Text = "frmTieuHao_DinhMuc";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsTextBox txtMa_Bp;
        private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsLabelName lbtTen_Bp;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsDataGridView dgvDinhMuc;
	}
}