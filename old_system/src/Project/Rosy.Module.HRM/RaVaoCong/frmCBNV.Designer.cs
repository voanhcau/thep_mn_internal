namespace RosyModule.HRM
{
    partial class frmCBNV
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
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.dgvDinhMuc = new RosySystem.Control.rsDataGridView();
            this.dteGio_Vao = new RosyModule.txtTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
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
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(241, 5);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(91, 20);
            this.txtMa_Dt_CbNv.TabIndex = 1;
            this.txtMa_Dt_CbNv.Tag = "";
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Location = new System.Drawing.Point(152, 9);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(86, 13);
            this.rsLabel13.TabIndex = 68;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "Mã số nhân viên";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dgvDinhMuc.Location = new System.Drawing.Point(12, 32);
            this.dgvDinhMuc.MultiSelect = false;
            this.dgvDinhMuc.Name = "dgvDinhMuc";
            this.dgvDinhMuc.ReadOnly = true;
            this.dgvDinhMuc.Size = new System.Drawing.Size(623, 330);
            this.dgvDinhMuc.strZone = "";
            this.dgvDinhMuc.TabIndex = 69;
            // 
            // dteGio_Vao
            // 
            this.dteGio_Vao.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dteGio_Vao.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteGio_Vao.Location = new System.Drawing.Point(80, 6);
            this.dteGio_Vao.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteGio_Vao.Mask = "00:00:00";
            this.dteGio_Vao.Name = "dteGio_Vao";
            this.dteGio_Vao.SelectOnFocus = false;
            this.dteGio_Vao.Size = new System.Drawing.Size(55, 20);
            this.dteGio_Vao.TabIndex = 0;
            this.dteGio_Vao.Tag = "";
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(34, 9);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(44, 13);
            this.rsLabel2.TabIndex = 131;
            this.rsLabel2.Tag = "Gio_Vao";
            this.rsLabel2.Text = "Giờ vào";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCBNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 421);
            this.Controls.Add(this.dteGio_Vao);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.dgvDinhMuc);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.rsLabel13);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmCBNV";
            this.Tag = "frmCBNVRVC";
            this.Text = "frmCBNVRVC";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsDataGridView dgvDinhMuc;
        private txtTime dteGio_Vao;
        private RosySystem.Control.rsLabel rsLabel2;
	}
}