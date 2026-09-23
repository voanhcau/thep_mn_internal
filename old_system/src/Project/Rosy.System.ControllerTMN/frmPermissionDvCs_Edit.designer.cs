namespace RosyControllerTMN
{
	partial class frmPermissionDvCs_Edit
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
			this.lbTen_Nh_Dt = new RosySystem.Control.rsLabel();
			this.lbDm_Nh_Dt = new RosySystem.Control.rsLabel();
			this.txtMa_DvCs = new RosySystem.Control.rsTextBox();
			this.label2 = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.lbtTen_DvCs = new RosySystem.Control.rsLabelName();
			this.chkAllow_Access = new RosySystem.Control.rsCheckbox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbTen_Nh_Dt
			// 
			this.lbTen_Nh_Dt.AutoEllipsis = true;
			this.lbTen_Nh_Dt.AutoSize = true;
			this.lbTen_Nh_Dt.Location = new System.Drawing.Point(-97, 135);
			this.lbTen_Nh_Dt.Name = "lbTen_Nh_Dt";
			this.lbTen_Nh_Dt.Size = new System.Drawing.Size(55, 13);
			this.lbTen_Nh_Dt.TabIndex = 3;
			this.lbTen_Nh_Dt.Text = "Tên nhóm";
			this.lbTen_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbDm_Nh_Dt
			// 
			this.lbDm_Nh_Dt.AutoEllipsis = true;
			this.lbDm_Nh_Dt.AutoSize = true;
			this.lbDm_Nh_Dt.Location = new System.Drawing.Point(-97, 113);
			this.lbDm_Nh_Dt.Name = "lbDm_Nh_Dt";
			this.lbDm_Nh_Dt.Size = new System.Drawing.Size(51, 13);
			this.lbDm_Nh_Dt.TabIndex = 4;
			this.lbDm_Nh_Dt.Text = "Mã nhóm";
			this.lbDm_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_DvCs
			// 
			this.txtMa_DvCs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_DvCs.Location = new System.Drawing.Point(100, 23);
			this.txtMa_DvCs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_DvCs.Name = "txtMa_DvCs";
			this.txtMa_DvCs.Size = new System.Drawing.Size(129, 20);
			this.txtMa_DvCs.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoEllipsis = true;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 0;
			this.label2.Tag = "Tk";
			this.label2.Text = "Mã đơn vị Cs";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(321, 156);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 44);
			this.btgAccept.TabIndex = 5;
			// 
			// lbtTen_DvCs
			// 
			this.lbtTen_DvCs.AutoEllipsis = true;
			this.lbtTen_DvCs.AutoSize = true;
			this.lbtTen_DvCs.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtTen_DvCs.Location = new System.Drawing.Point(235, 26);
			this.lbtTen_DvCs.Name = "lbtTen_DvCs";
			this.lbtTen_DvCs.Size = new System.Drawing.Size(133, 13);
			this.lbtTen_DvCs.TabIndex = 2;
			this.lbtTen_DvCs.Tag = "";
			this.lbtTen_DvCs.Text = "Tên đối tượng phân quyền";
			this.lbtTen_DvCs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkAllow_Access
			// 
			this.chkAllow_Access.AutoSize = true;
			this.chkAllow_Access.Checked = true;
			this.chkAllow_Access.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllow_Access.Location = new System.Drawing.Point(62, 37);
			this.chkAllow_Access.Name = "chkAllow_Access";
			this.chkAllow_Access.Size = new System.Drawing.Size(142, 17);
			this.chkAllow_Access.TabIndex = 4;
			this.chkAllow_Access.Tag = "Allow_Access";
			this.chkAllow_Access.Text = "Được phép xem truy cập";
			this.chkAllow_Access.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkAllow_Access);
			this.groupBox1.Location = new System.Drawing.Point(76, 61);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(426, 66);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Phân quyền";
			// 
			// frmPermissionDvCs_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 212);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.txtMa_DvCs);
			this.Controls.Add(this.lbtTen_DvCs);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbTen_Nh_Dt);
			this.Controls.Add(this.lbDm_Nh_Dt);
			this.Name = "frmPermissionDvCs_Edit";
			this.Text = "frmPermission_Edit";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsLabel lbTen_Nh_Dt;
		private RosySystem.Control.rsLabel lbDm_Nh_Dt;
		private RosySystem.Control.rsTextBox txtMa_DvCs;
		private RosySystem.Control.rsLabel label2;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabelName lbtTen_DvCs;
		public RosySystem.Control.rsCheckbox chkAllow_Access;
		private System.Windows.Forms.GroupBox groupBox1;
    }
}