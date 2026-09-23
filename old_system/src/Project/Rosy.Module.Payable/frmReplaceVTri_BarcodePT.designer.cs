namespace RosyModule.Payable
{
    partial class frmReplace_BarcodePT
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
            this.btExit = new RosySystem.Control.rsButton();
            this.btAccept = new RosySystem.Control.rsButton();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabel();
            this.btRefresh = new RosySystem.Control.rsButton();
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
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtMa_Vt);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.lbtTen_Vt);
            this.splitContainer1.Panel1.Controls.Add(this.btRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.btExit);
            this.splitContainer1.Panel1.Controls.Add(this.btAccept);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvReplaceBarcodePT);
            this.splitContainer1.Size = new System.Drawing.Size(1154, 697);
            this.splitContainer1.SplitterDistance = 61;
            this.splitContainer1.TabIndex = 0;
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
            // btAccept
            // 
            this.btAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAccept.Location = new System.Drawing.Point(967, 3);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(92, 52);
            this.btAccept.TabIndex = 11;
            this.btAccept.Text = "Lưu";
            this.btAccept.UseVisualStyleBackColor = true;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(91, 19);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 67;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(18, 22);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(52, 13);
            this.rsLabel2.TabIndex = 68;
            this.rsLabel2.Tag = "Ma_Vt";
            this.rsLabel2.Text = "Mã vật tư";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(216, 23);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(73, 13);
            this.lbtTen_Vt.TabIndex = 66;
            this.lbtTen_Vt.Text = "Tên mặt hàng";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(875, 2);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(92, 52);
            this.btRefresh.TabIndex = 65;
            this.btRefresh.Text = "F5 - Refresh\r\n";
            this.btRefresh.UseVisualStyleBackColor = true;
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
            this.dgvReplaceBarcodePT.MultiSelect = false;
            this.dgvReplaceBarcodePT.Name = "dgvReplaceBarcodePT";
            this.dgvReplaceBarcodePT.Size = new System.Drawing.Size(1154, 632);
            this.dgvReplaceBarcodePT.strZone = "";
            this.dgvReplaceBarcodePT.TabIndex = 2;
            // 
            // frmReplace_BarcodePT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 697);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmReplace_BarcodePT";
            this.Tag = "frmReplace_BarcodePT";
            this.Text = "frmReplace_BarcodePT";
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
        private RosySystem.Control.rsButton btAccept;
        private RosySystem.Control.rsTextBox txtMa_Vt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel lbtTen_Vt;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Customize.dgvVoucher dgvReplaceBarcodePT;

    }
}