namespace RosyModule.ScaleBarcodeTMN
{
    partial class frmChuyenBarcodeLe
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rsLabel24 = new RosySystem.Control.rsLabel();
            this.txtMa_Vt_Sp = new RosySystem.Control.rsTextBox();
            this.lbtTen_Vt_Sp = new RosySystem.Control.rsLabel();
            this.btExit = new RosySystem.Control.rsButton();
            this.dgvReplaceBarcodePT = new RosySystem.Customize.dgvVoucher();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplaceBarcodePT)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel24);
            this.splitContainer1.Panel1.Controls.Add(this.txtMa_Vt_Sp);
            this.splitContainer1.Panel1.Controls.Add(this.lbtTen_Vt_Sp);
            this.splitContainer1.Panel1.Controls.Add(this.btExit);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvReplaceBarcodePT);
            this.splitContainer1.Size = new System.Drawing.Size(1199, 721);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // rsLabel24
            // 
            this.rsLabel24.AutoEllipsis = true;
            this.rsLabel24.AutoSize = true;
            this.rsLabel24.Location = new System.Drawing.Point(22, 14);
            this.rsLabel24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel24.Name = "rsLabel24";
            this.rsLabel24.Size = new System.Drawing.Size(93, 17);
            this.rsLabel24.TabIndex = 278;
            this.rsLabel24.Tag = "";
            this.rsLabel24.Text = "Mã sản phẩm";
            this.rsLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt_Sp
            // 
            this.txtMa_Vt_Sp.AutoDropDown = null;
            this.txtMa_Vt_Sp.BackColor = System.Drawing.SystemColors.Window;
            this.txtMa_Vt_Sp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt_Sp.Location = new System.Drawing.Point(116, 7);
            this.txtMa_Vt_Sp.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtMa_Vt_Sp.MaxLength = 20;
            this.txtMa_Vt_Sp.Multiline = true;
            this.txtMa_Vt_Sp.Name = "txtMa_Vt_Sp";
            this.txtMa_Vt_Sp.Size = new System.Drawing.Size(124, 28);
            this.txtMa_Vt_Sp.TabIndex = 276;
            // 
            // lbtTen_Vt_Sp
            // 
            this.lbtTen_Vt_Sp.AutoEllipsis = true;
            this.lbtTen_Vt_Sp.AutoSize = true;
            this.lbtTen_Vt_Sp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Sp.Location = new System.Drawing.Point(247, 14);
            this.lbtTen_Vt_Sp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_Vt_Sp.Name = "lbtTen_Vt_Sp";
            this.lbtTen_Vt_Sp.Size = new System.Drawing.Size(69, 17);
            this.lbtTen_Vt_Sp.TabIndex = 277;
            this.lbtTen_Vt_Sp.Text = "Tên hàng";
            this.lbtTen_Vt_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(1061, 4);
            this.btExit.Margin = new System.Windows.Forms.Padding(4);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(123, 39);
            this.btExit.TabIndex = 11;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // dgvReplaceBarcodePT
            // 
            this.dgvReplaceBarcodePT.AllowUserToAddRows = false;
            this.dgvReplaceBarcodePT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReplaceBarcodePT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReplaceBarcodePT.BackgroundColor = System.Drawing.Color.White;
            this.dgvReplaceBarcodePT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReplaceBarcodePT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReplaceBarcodePT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReplaceBarcodePT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReplaceBarcodePT.Location = new System.Drawing.Point(0, 0);
            this.dgvReplaceBarcodePT.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReplaceBarcodePT.MultiSelect = false;
            this.dgvReplaceBarcodePT.Name = "dgvReplaceBarcodePT";
            this.dgvReplaceBarcodePT.Size = new System.Drawing.Size(1199, 669);
            this.dgvReplaceBarcodePT.strZone = "";
            this.dgvReplaceBarcodePT.TabIndex = 2;
            // 
            // frmChuyenBarcodeLe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 721);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmChuyenBarcodeLe";
            this.Tag = "frmChuyenBarcodeLe";
            this.Text = "frmChuyenBarcodeLe";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplaceBarcodePT)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Control.rsButton btExit;
        private RosySystem.Customize.dgvVoucher dgvReplaceBarcodePT;
        private RosySystem.Control.rsLabel rsLabel24;
        private RosySystem.Control.rsTextBox txtMa_Vt_Sp;
        private RosySystem.Control.rsLabel lbtTen_Vt_Sp;

    }
}