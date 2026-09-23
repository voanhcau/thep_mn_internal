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
            this.txtTen_Bp_Ct = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtMa_Bp_Ct_Cha = new RosySystem.Control.rsTextBox();
            this.lbtTen_Bp_Ct_Cha = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabel();
            this.txtMa_Bp = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.numStt_Sx = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
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
            this.btgAccept.Location = new System.Drawing.Point(356, 165);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            this.btgAccept.TabIndex = 6;
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
            this.chkNh_Cuoi.Location = new System.Drawing.Point(127, 149);
            this.chkNh_Cuoi.Name = "chkNh_Cuoi";
            this.chkNh_Cuoi.Size = new System.Drawing.Size(77, 17);
            this.chkNh_Cuoi.TabIndex = 5;
            this.chkNh_Cuoi.Text = "Nhóm cuối";
            this.chkNh_Cuoi.UseVisualStyleBackColor = true;
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
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(25, 72);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(102, 13);
            this.rsLabel3.TabIndex = 72;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Mã bộ phận CT cha";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Bp_Ct_Cha
            // 
            this.txtMa_Bp_Ct_Cha.AutoDropDown = null;
            this.txtMa_Bp_Ct_Cha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp_Ct_Cha.Location = new System.Drawing.Point(127, 69);
            this.txtMa_Bp_Ct_Cha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp_Ct_Cha.MaxLength = 20;
            this.txtMa_Bp_Ct_Cha.Name = "txtMa_Bp_Ct_Cha";
            this.txtMa_Bp_Ct_Cha.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Bp_Ct_Cha.TabIndex = 2;
            // 
            // lbtTen_Bp_Ct_Cha
            // 
            this.lbtTen_Bp_Ct_Cha.AutoEllipsis = true;
            this.lbtTen_Bp_Ct_Cha.AutoSize = true;
            this.lbtTen_Bp_Ct_Cha.Location = new System.Drawing.Point(228, 72);
            this.lbtTen_Bp_Ct_Cha.Name = "lbtTen_Bp_Ct_Cha";
            this.lbtTen_Bp_Ct_Cha.Size = new System.Drawing.Size(102, 13);
            this.lbtTen_Bp_Ct_Cha.TabIndex = 75;
            this.lbtTen_Bp_Ct_Cha.Tag = "";
            this.lbtTen_Bp_Ct_Cha.Text = "Mã bộ phận CT cha";
            this.lbtTen_Bp_Ct_Cha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoEllipsis = true;
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.Location = new System.Drawing.Point(228, 127);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(102, 13);
            this.lbtTen_Bp.TabIndex = 78;
            this.lbtTen_Bp.Tag = "";
            this.lbtTen_Bp.Text = "Mã bộ phận CT cha";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.AutoDropDown = null;
            this.txtMa_Bp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp.Location = new System.Drawing.Point(127, 124);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.MaxLength = 20;
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(96, 20);
            this.txtMa_Bp.TabIndex = 4;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(25, 127);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(67, 13);
            this.rsLabel4.TabIndex = 77;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Mã bộ phận ";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numStt_Sx
            // 
            this.numStt_Sx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.numStt_Sx.AutoDropDown = null;
            this.numStt_Sx.bFormat = true;
            this.numStt_Sx.Location = new System.Drawing.Point(127, 92);
            this.numStt_Sx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt_Sx.Name = "numStt_Sx";
            this.numStt_Sx.Scale = 0;
            this.numStt_Sx.Size = new System.Drawing.Size(96, 20);
            this.numStt_Sx.TabIndex = 3;
            this.numStt_Sx.Text = "0";
            this.numStt_Sx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStt_Sx.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(20, 96);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(60, 13);
            this.rsLabel1.TabIndex = 80;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Stt sắp xếp";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmBpCt_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 214);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.numStt_Sx);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.txtMa_Bp);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.lbtTen_Bp_Ct_Cha);
            this.Controls.Add(this.txtTen_Bp_Ct);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtMa_Bp_Ct_Cha);
            this.Controls.Add(this.rsLabel3);
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
        private RosySystem.Control.rsTextBox txtTen_Bp_Ct;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtMa_Bp_Ct_Cha;
        private RosySystem.Control.rsLabel lbtTen_Bp_Ct_Cha;
        private RosySystem.Control.rsLabel lbtTen_Bp;
        private RosySystem.Control.rsTextBox txtMa_Bp;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBoxNumber numStt_Sx;
        private RosySystem.Control.rsLabel rsLabel1;
	}
}