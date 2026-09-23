namespace RosyModule
{
    partial class frmInherit_LyLichTB
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
            this.txtMa_Nh_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabelName();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dgvDinhMuc = new RosySystem.Control.rsDataGridView();
            this.txtMa_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Tb = new RosySystem.Control.rsLabelName();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(889, 464);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 4;
            // 
            // txtMa_Nh_Tb
            // 
            this.txtMa_Nh_Tb.AutoDropDown = null;
            this.txtMa_Nh_Tb.Location = new System.Drawing.Point(105, 9);
            this.txtMa_Nh_Tb.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Nh_Tb.Name = "txtMa_Nh_Tb";
            this.txtMa_Nh_Tb.Size = new System.Drawing.Size(91, 20);
            this.txtMa_Nh_Tb.TabIndex = 0;
            this.txtMa_Nh_Tb.Tag = "Ma_Vt";
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Location = new System.Drawing.Point(23, 12);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(79, 13);
            this.rsLabel13.TabIndex = 68;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "Mã cụm thiết bị";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Nh_Tb
            // 
            this.lbtTen_Nh_Tb.AutoSize = true;
            this.lbtTen_Nh_Tb.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Nh_Tb.Location = new System.Drawing.Point(202, 12);
            this.lbtTen_Nh_Tb.Name = "lbtTen_Nh_Tb";
            this.lbtTen_Nh_Tb.Size = new System.Drawing.Size(65, 13);
            this.lbtTen_Nh_Tb.TabIndex = 66;
            this.lbtTen_Nh_Tb.Tag = "Ten_Nh_Tb";
            this.lbtTen_Nh_Tb.Text = "Ten_Nh_Tb";
            this.lbtTen_Nh_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(990, 22);
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
            this.dgvDinhMuc.Size = new System.Drawing.Size(1063, 399);
            this.dgvDinhMuc.strZone = "";
            this.dgvDinhMuc.TabIndex = 3;
            // 
            // txtMa_Tb
            // 
            this.txtMa_Tb.AutoDropDown = null;
            this.txtMa_Tb.Location = new System.Drawing.Point(105, 33);
            this.txtMa_Tb.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Tb.Name = "txtMa_Tb";
            this.txtMa_Tb.Size = new System.Drawing.Size(91, 20);
            this.txtMa_Tb.TabIndex = 1;
            this.txtMa_Tb.Tag = "Ma_Vt";
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(23, 36);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(56, 13);
            this.rsLabel1.TabIndex = 72;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mã thiết bị";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tb
            // 
            this.lbtTen_Tb.AutoSize = true;
            this.lbtTen_Tb.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tb.Location = new System.Drawing.Point(202, 36);
            this.lbtTen_Tb.Name = "lbtTen_Tb";
            this.lbtTen_Tb.Size = new System.Drawing.Size(45, 13);
            this.lbtTen_Tb.TabIndex = 71;
            this.lbtTen_Tb.Tag = "Ten_Tb";
            this.lbtTen_Tb.Text = "Ten_Tb";
            this.lbtTen_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmInherit_LyLichTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 517);
            this.Controls.Add(this.txtMa_Tb);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Tb);
            this.Controls.Add(this.dgvDinhMuc);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.txtMa_Nh_Tb);
            this.Controls.Add(this.rsLabel13);
            this.Controls.Add(this.lbtTen_Nh_Tb);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmInherit_LyLichTB";
            this.Tag = "frmInherit_LyLichTB";
            this.Text = "frmInherit_LyLichTB";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtMa_Nh_Tb;
        private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsLabelName lbtTen_Nh_Tb;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsDataGridView dgvDinhMuc;
        private RosySystem.Control.rsTextBox txtMa_Tb;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabelName lbtTen_Tb;
	}
}