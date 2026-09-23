namespace RosyModule.Payable
{
    partial class frmNhapBarcodePT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabel();
            this.btExit = new RosySystem.Control.rsButton();
            this.btNew = new RosySystem.Control.rsButton();
            this.btPrint = new RosySystem.Control.rsButton();
            this.btEdit = new RosySystem.Control.rsButton();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.dgvBarcodePT = new RosySystem.Control.rsDataGridView();
            this.btDelete = new RosySystem.Control.rsButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodePT)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtMa_Vt);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.lbtTen_Vt);
            this.splitContainer1.Panel1.Controls.Add(this.btExit);
            this.splitContainer1.Panel1.Controls.Add(this.btNew);
            this.splitContainer1.Panel1.Controls.Add(this.btPrint);
            this.splitContainer1.Panel1.Controls.Add(this.btDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btEdit);
            this.splitContainer1.Panel1.Controls.Add(this.btRefresh);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvBarcodePT);
            this.splitContainer1.Size = new System.Drawing.Size(1154, 697);
            this.splitContainer1.SplitterDistance = 61;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(85, 9);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 63;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(12, 12);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(52, 13);
            this.rsLabel2.TabIndex = 64;
            this.rsLabel2.Tag = "Ma_Vt";
            this.rsLabel2.Text = "Mã vật tư";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(210, 13);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(73, 13);
            this.lbtTen_Vt.TabIndex = 62;
            this.lbtTen_Vt.Text = "Tên mặt hàng";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Location = new System.Drawing.Point(1059, 3);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(92, 52);
            this.btExit.TabIndex = 11;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.Location = new System.Drawing.Point(780, 3);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(92, 52);
            this.btNew.TabIndex = 11;
            this.btNew.Text = "Thêm barcode";
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Location = new System.Drawing.Point(687, 3);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(92, 52);
            this.btPrint.TabIndex = 11;
            this.btPrint.Text = "In barcode";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Location = new System.Drawing.Point(874, 3);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(92, 52);
            this.btEdit.TabIndex = 11;
            this.btEdit.Text = "Sửa barcode\r\n";
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(593, 3);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(92, 52);
            this.btRefresh.TabIndex = 11;
            this.btRefresh.Text = "F5 - Refresh\r\n";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvBarcodePT
            // 
            this.dgvBarcodePT.AllowUserToAddRows = false;
            this.dgvBarcodePT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBarcodePT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBarcodePT.BackgroundColor = System.Drawing.Color.White;
            this.dgvBarcodePT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBarcodePT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBarcodePT.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBarcodePT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBarcodePT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBarcodePT.Location = new System.Drawing.Point(0, 0);
            this.dgvBarcodePT.MultiSelect = false;
            this.dgvBarcodePT.Name = "dgvBarcodePT";
            this.dgvBarcodePT.ReadOnly = true;
            this.dgvBarcodePT.Size = new System.Drawing.Size(1154, 632);
            this.dgvBarcodePT.strZone = "";
            this.dgvBarcodePT.TabIndex = 14;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(967, 3);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(92, 52);
            this.btDelete.TabIndex = 11;
            this.btDelete.Text = "Xóa barcode\r\n";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // frmNhapBarcodePT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 697);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmNhapBarcodePT";
            this.Tag = "frmNhapBarcodePT";
            this.Text = "frmNhapBarcodePT";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodePT)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Control.rsButton btNew;
        private RosySystem.Control.rsButton btPrint;
        private RosySystem.Control.rsButton btEdit;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsTextBox txtMa_Vt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel lbtTen_Vt;
        private RosySystem.Control.rsDataGridView dgvBarcodePT;
        private RosySystem.Control.rsButton btDelete;

    }
}