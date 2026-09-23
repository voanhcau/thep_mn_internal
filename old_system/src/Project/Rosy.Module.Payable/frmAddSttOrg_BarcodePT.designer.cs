namespace RosyModule.Payable
{
    partial class frmAddSttOrg_BarcodePT
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
            this.btRefresh = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.btAccept = new RosySystem.Control.rsButton();
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
            // frmAddSttOrg_BarcodePT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 697);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAddSttOrg_BarcodePT";
            this.Tag = "frmAddSttOrg_BarcodePT";
            this.Text = "frmAddSttOrg_BarcodePT";
            this.splitContainer1.Panel1.ResumeLayout(false);
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
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Customize.dgvVoucher dgvReplaceBarcodePT;

    }
}