namespace RosyModule.HRM
{
    partial class frmDmBpCt_Edit
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
            this.txtMa_Bp_Ct = new RosySystem.Control.rsTextBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbtTen_Tn = new RosySystem.Control.rsLabelName();
            this.chkNh_Cuoi = new RosySystem.Control.rsCheckbox();
            this.txtMa_Bp = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtTen_Bp_Ct = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // txtMa_Bp_Ct
            // 
            this.txtMa_Bp_Ct.AutoDropDown = null;
            this.txtMa_Bp_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp_Ct.Location = new System.Drawing.Point(127, 24);
            this.txtMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp_Ct.MaxLength = 20;
            this.txtMa_Bp_Ct.Name = "txtMa_Bp_Ct";
            this.txtMa_Bp_Ct.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Bp_Ct.TabIndex = 0;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Location = new System.Drawing.Point(25, 27);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(98, 13);
            this.lblTk.TabIndex = 70;
            this.lblTk.Tag = "Ma_Bp_Ct";
            this.lblTk.Text = "Mã bộ phận chi tiết";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(356, 134);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            this.btgAccept.TabIndex = 5;
            // 
            // lbtTen_Tn
            // 
            this.lbtTen_Tn.AutoSize = true;
            this.lbtTen_Tn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Tn.Location = new System.Drawing.Point(228, 24);
            this.lbtTen_Tn.Name = "lbtTen_Tn";
            this.lbtTen_Tn.Size = new System.Drawing.Size(0, 13);
            this.lbtTen_Tn.TabIndex = 1;
            this.lbtTen_Tn.Tag = "";
            this.lbtTen_Tn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNh_Cuoi
            // 
            this.chkNh_Cuoi.AutoSize = true;
            this.chkNh_Cuoi.ForeColor = System.Drawing.Color.Red;
            this.chkNh_Cuoi.Location = new System.Drawing.Point(127, 93);
            this.chkNh_Cuoi.Name = "chkNh_Cuoi";
            this.chkNh_Cuoi.Size = new System.Drawing.Size(77, 17);
            this.chkNh_Cuoi.TabIndex = 3;
            this.chkNh_Cuoi.Text = "Nhóm cuối";
            this.chkNh_Cuoi.UseVisualStyleBackColor = true;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.AutoDropDown = null;
            this.txtMa_Bp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp.Location = new System.Drawing.Point(127, 68);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.MaxLength = 20;
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Bp.TabIndex = 2;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(25, 71);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(64, 13);
            this.rsLabel1.TabIndex = 72;
            this.rsLabel1.Tag = "Ma_Bp";
            this.rsLabel1.Text = "Mã bộ phận";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Bp_Ct
            // 
            this.txtTen_Bp_Ct.AutoDropDown = null;
            this.txtTen_Bp_Ct.Location = new System.Drawing.Point(127, 46);
            this.txtTen_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Bp_Ct.MaxLength = 100;
            this.txtTen_Bp_Ct.Name = "txtTen_Bp_Ct";
            this.txtTen_Bp_Ct.Size = new System.Drawing.Size(408, 20);
            this.txtTen_Bp_Ct.TabIndex = 1;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(25, 49);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(87, 13);
            this.rsLabel2.TabIndex = 74;
            this.rsLabel2.Tag = "Ten_Bp_Ct";
            this.rsLabel2.Text = "Tên phận chi tiết";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmBpCt_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 183);
            this.Controls.Add(this.txtTen_Bp_Ct);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtMa_Bp);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.chkNh_Cuoi);
            this.Controls.Add(this.txtMa_Bp_Ct);
            this.Controls.Add(this.lbtTen_Tn);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmDmBpCt_Edit";
            this.Text = "frmDmBpCt_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Control.rsTextBox txtMa_Bp_Ct;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabelName lbtTen_Tn;
        private RosySystem.Control.rsCheckbox chkNh_Cuoi;
        private RosySystem.Control.rsTextBox txtMa_Bp;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtTen_Bp_Ct;
        private RosySystem.Control.rsLabel rsLabel2;
	}
}