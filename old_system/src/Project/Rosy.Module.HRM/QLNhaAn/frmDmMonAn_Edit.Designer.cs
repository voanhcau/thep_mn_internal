namespace RosyModule.HRM
{
    partial class frmDmMonAn_Edit
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
            this.txtMa_MAn = new RosySystem.Control.rsTextBox();
            this.txtTen_MAn = new RosySystem.Control.rsTextBox();
            this.txtMa_MAn_Parent = new RosySystem.Control.rsTextBox();
            this.lbtTen_Bp_Cha = new RosySystem.Control.rsLabel();
            this.lblMa_Bp_Parent = new RosySystem.Control.rsLabel();
            this.lblTen_Bp = new RosySystem.Control.rsLabel();
            this.lblMa_MAn = new RosySystem.Control.rsLabel();
            this.chkNh_Cuoi = new RosySystem.Control.rsCheckbox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(567, 382);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.btgAccept.Size = new System.Drawing.Size(272, 65);
            // 
            // tabEdit
            // 
            this.tabEdit.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tabEdit.Size = new System.Drawing.Size(820, 363);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chkNh_Cuoi);
            this.Page1.Controls.Add(this.txtMa_MAn);
            this.Page1.Controls.Add(this.txtTen_MAn);
            this.Page1.Controls.Add(this.txtMa_MAn_Parent);
            this.Page1.Controls.Add(this.lbtTen_Bp_Cha);
            this.Page1.Controls.Add(this.lblMa_Bp_Parent);
            this.Page1.Controls.Add(this.lblTen_Bp);
            this.Page1.Controls.Add(this.lblMa_MAn);
            this.Page1.Location = new System.Drawing.Point(4, 29);
            this.Page1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Page1.Padding = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Page1.Size = new System.Drawing.Size(812, 330);
            // 
            // Page2
            // 
            this.Page2.Location = new System.Drawing.Point(4, 29);
            this.Page2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Page2.Size = new System.Drawing.Size(812, 330);
            // 
            // dteNgay_End
            // 
            this.dteNgay_End.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            // 
            // dteNgay_Begin
            // 
            this.dteNgay_Begin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            // 
            // lblLog
            // 
            this.lblLog.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLog.Size = new System.Drawing.Size(778, 52);
            this.lblLog.Text = "";
            // 
            // txtMa_MAn
            // 
            this.txtMa_MAn.AutoDropDown = null;
            this.txtMa_MAn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_MAn.Location = new System.Drawing.Point(174, 40);
            this.txtMa_MAn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_MAn.Name = "txtMa_MAn";
            this.txtMa_MAn.Size = new System.Drawing.Size(204, 26);
            this.txtMa_MAn.TabIndex = 0;
            // 
            // txtTen_MAn
            // 
            this.txtTen_MAn.AutoDropDown = null;
            this.txtTen_MAn.Location = new System.Drawing.Point(174, 74);
            this.txtTen_MAn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtTen_MAn.Name = "txtTen_MAn";
            this.txtTen_MAn.Size = new System.Drawing.Size(500, 26);
            this.txtTen_MAn.TabIndex = 1;
            // 
            // txtMa_MAn_Parent
            // 
            this.txtMa_MAn_Parent.AutoDropDown = null;
            this.txtMa_MAn_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_MAn_Parent.Location = new System.Drawing.Point(174, 108);
            this.txtMa_MAn_Parent.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMa_MAn_Parent.Name = "txtMa_MAn_Parent";
            this.txtMa_MAn_Parent.Size = new System.Drawing.Size(204, 26);
            this.txtMa_MAn_Parent.TabIndex = 2;
            // 
            // lbtTen_Bp_Cha
            // 
            this.lbtTen_Bp_Cha.AutoEllipsis = true;
            this.lbtTen_Bp_Cha.AutoSize = true;
            this.lbtTen_Bp_Cha.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Bp_Cha.Location = new System.Drawing.Point(400, 109);
            this.lbtTen_Bp_Cha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_Bp_Cha.Name = "lbtTen_Bp_Cha";
            this.lbtTen_Bp_Cha.Size = new System.Drawing.Size(124, 20);
            this.lbtTen_Bp_Cha.TabIndex = 61;
            this.lbtTen_Bp_Cha.Text = "Tên bộ phận mẹ";
            this.lbtTen_Bp_Cha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Bp_Parent
            // 
            this.lblMa_Bp_Parent.AutoEllipsis = true;
            this.lblMa_Bp_Parent.AutoSize = true;
            this.lblMa_Bp_Parent.Location = new System.Drawing.Point(26, 108);
            this.lblMa_Bp_Parent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMa_Bp_Parent.Name = "lblMa_Bp_Parent";
            this.lblMa_Bp_Parent.Size = new System.Drawing.Size(99, 20);
            this.lblMa_Bp_Parent.TabIndex = 58;
            this.lblMa_Bp_Parent.Tag = "Ma_MAn_Parent";
            this.lblMa_Bp_Parent.Text = "Bộ phận cha";
            this.lblMa_Bp_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_Bp
            // 
            this.lblTen_Bp.AutoEllipsis = true;
            this.lblTen_Bp.AutoSize = true;
            this.lblTen_Bp.Location = new System.Drawing.Point(26, 75);
            this.lblTen_Bp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTen_Bp.Name = "lblTen_Bp";
            this.lblTen_Bp.Size = new System.Drawing.Size(98, 20);
            this.lblTen_Bp.TabIndex = 59;
            this.lblTen_Bp.Tag = "Ten_MAn";
            this.lblTen_Bp.Text = "Tên bộ phận";
            this.lblTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_MAn
            // 
            this.lblMa_MAn.AutoEllipsis = true;
            this.lblMa_MAn.AutoSize = true;
            this.lblMa_MAn.Location = new System.Drawing.Point(26, 40);
            this.lblMa_MAn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMa_MAn.Name = "lblMa_MAn";
            this.lblMa_MAn.Size = new System.Drawing.Size(93, 20);
            this.lblMa_MAn.TabIndex = 60;
            this.lblMa_MAn.Tag = "Ma_MAn";
            this.lblMa_MAn.Text = "Mã bộ phận";
            this.lblMa_MAn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNh_Cuoi
            // 
            this.chkNh_Cuoi.AutoSize = true;
            this.chkNh_Cuoi.ForeColor = System.Drawing.Color.Red;
            this.chkNh_Cuoi.Location = new System.Drawing.Point(174, 146);
            this.chkNh_Cuoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkNh_Cuoi.Name = "chkNh_Cuoi";
            this.chkNh_Cuoi.Size = new System.Drawing.Size(346, 24);
            this.chkNh_Cuoi.TabIndex = 3;
            this.chkNh_Cuoi.Text = "Là nhóm cuối (Là bộ phận chi tiết cuối cùng)";
            this.chkNh_Cuoi.UseVisualStyleBackColor = true;
            // 
            // frmDmMonAn_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 457);
            this.Margin = new System.Windows.Forms.Padding(14, 18, 14, 18);
            this.Name = "frmDmMonAn_Edit";
            this.Object_ID = "DMMONAN";
            this.Tag = "frmDmMAn, ESC";
            this.Text = "frmDmMAn";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtMa_MAn;
		private RosySystem.Control.rsTextBox txtTen_MAn;
		private RosySystem.Control.rsTextBox txtMa_MAn_Parent;
		private RosySystem.Control.rsLabel lbtTen_Bp_Cha;
		private RosySystem.Control.rsLabel lblMa_Bp_Parent;
		private RosySystem.Control.rsLabel lblTen_Bp;
		private RosySystem.Control.rsLabel lblMa_MAn;
		private RosySystem.Control.rsCheckbox chkNh_Cuoi;
	}
}