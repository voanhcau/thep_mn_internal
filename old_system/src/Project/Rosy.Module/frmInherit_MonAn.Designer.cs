namespace RosyModule
{
    partial class frmInherit_MonAn
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
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dgvDinhMuc = new RosySystem.Control.rsDataGridView();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(674, 566);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(272, 69);
            this.btgAccept.TabIndex = 4;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(825, 34);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(128, 45);
            this.btRefresh.TabIndex = 3;
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
            this.dgvDinhMuc.Location = new System.Drawing.Point(18, 89);
            this.dgvDinhMuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDinhMuc.MultiSelect = false;
            this.dgvDinhMuc.Name = "dgvDinhMuc";
            this.dgvDinhMuc.ReadOnly = true;
            this.dgvDinhMuc.Size = new System.Drawing.Size(934, 468);
            this.dgvDinhMuc.strZone = "";
            this.dgvDinhMuc.TabIndex = 69;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(130, 19);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(121, 26);
            this.dteNgay_Ct.TabIndex = 258;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(37, 22);
            this.lblNgay_Ct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(67, 20);
            this.lblNgay_Ct.TabIndex = 257;
            this.lblNgay_Ct.Tag = "Ngay_Ct";
            this.lblNgay_Ct.Text = "Từ Ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmInherit_MonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 648);
            this.Controls.Add(this.dteNgay_Ct);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.dgvDinhMuc);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.Name = "frmInherit_MonAn";
            this.Tag = "frmInherit_MonAn";
            this.Text = "frmInherit_MonAn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsDataGridView dgvDinhMuc;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsLabel lblNgay_Ct;
	}
}