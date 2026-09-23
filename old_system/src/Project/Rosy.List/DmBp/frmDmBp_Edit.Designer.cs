namespace RosyList
{
	partial class frmDmMAn_Edit
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
			this.txtMa_Bp = new RosySystem.Control.rsTextBox();
			this.txtTen_Bp = new RosySystem.Control.rsTextBox();
			this.txtMa_Bp_Parent = new RosySystem.Control.rsTextBox();
			this.lbtTen_Bp_Cha = new RosySystem.Control.rsLabel();
			this.lblMa_Bp_Parent = new RosySystem.Control.rsLabel();
			this.lblTen_Bp = new RosySystem.Control.rsLabel();
			this.lblMa_Bp = new RosySystem.Control.rsLabel();
			this.chkNh_Cuoi = new RosySystem.Control.rsCheckbox();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(378, 248);
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(547, 236);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.chkNh_Cuoi);
			this.Page1.Controls.Add(this.txtMa_Bp);
			this.Page1.Controls.Add(this.txtTen_Bp);
			this.Page1.Controls.Add(this.txtMa_Bp_Parent);
			this.Page1.Controls.Add(this.lbtTen_Bp_Cha);
			this.Page1.Controls.Add(this.lblMa_Bp_Parent);
			this.Page1.Controls.Add(this.lblTen_Bp);
			this.Page1.Controls.Add(this.lblMa_Bp);
			this.Page1.Size = new System.Drawing.Size(539, 210);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(539, 217);
			// 
			// lblLog
			// 
			this.lblLog.Text = "";
			// 
			// txtMa_Bp
			// 
			this.txtMa_Bp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Bp.Location = new System.Drawing.Point(116, 26);
			this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Bp.Name = "txtMa_Bp";
			this.txtMa_Bp.Size = new System.Drawing.Size(137, 20);
			this.txtMa_Bp.TabIndex = 0;
			// 
			// txtTen_Bp
			// 
			this.txtTen_Bp.Location = new System.Drawing.Point(116, 48);
			this.txtTen_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Bp.Name = "txtTen_Bp";
			this.txtTen_Bp.Size = new System.Drawing.Size(335, 20);
			this.txtTen_Bp.TabIndex = 1;
			// 
			// txtMa_Bp_Parent
			// 
			this.txtMa_Bp_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Bp_Parent.Location = new System.Drawing.Point(116, 70);
			this.txtMa_Bp_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Bp_Parent.Name = "txtMa_Bp_Parent";
			this.txtMa_Bp_Parent.Size = new System.Drawing.Size(137, 20);
			this.txtMa_Bp_Parent.TabIndex = 2;
			// 
			// lbtTen_Bp_Cha
			// 
			this.lbtTen_Bp_Cha.AutoEllipsis = true;
			this.lbtTen_Bp_Cha.AutoSize = true;
			this.lbtTen_Bp_Cha.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Bp_Cha.Location = new System.Drawing.Point(267, 71);
			this.lbtTen_Bp_Cha.Name = "lbtTen_Bp_Cha";
			this.lbtTen_Bp_Cha.Size = new System.Drawing.Size(85, 13);
			this.lbtTen_Bp_Cha.TabIndex = 61;
			this.lbtTen_Bp_Cha.Text = "Tên bộ phận mẹ";
			this.lbtTen_Bp_Cha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMa_Bp_Parent
			// 
			this.lblMa_Bp_Parent.AutoEllipsis = true;
			this.lblMa_Bp_Parent.AutoSize = true;
			this.lblMa_Bp_Parent.Location = new System.Drawing.Point(17, 70);
			this.lblMa_Bp_Parent.Name = "lblMa_Bp_Parent";
			this.lblMa_Bp_Parent.Size = new System.Drawing.Size(68, 13);
			this.lblMa_Bp_Parent.TabIndex = 58;
			this.lblMa_Bp_Parent.Tag = "Ma_Bp_Parent";
			this.lblMa_Bp_Parent.Text = "Bộ phận cha";
			this.lblMa_Bp_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTen_Bp
			// 
			this.lblTen_Bp.AutoEllipsis = true;
			this.lblTen_Bp.AutoSize = true;
			this.lblTen_Bp.Location = new System.Drawing.Point(17, 49);
			this.lblTen_Bp.Name = "lblTen_Bp";
			this.lblTen_Bp.Size = new System.Drawing.Size(68, 13);
			this.lblTen_Bp.TabIndex = 59;
			this.lblTen_Bp.Tag = "Ten_Bp";
			this.lblTen_Bp.Text = "Tên bộ phận";
			this.lblTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMa_Bp
			// 
			this.lblMa_Bp.AutoEllipsis = true;
			this.lblMa_Bp.AutoSize = true;
			this.lblMa_Bp.Location = new System.Drawing.Point(17, 26);
			this.lblMa_Bp.Name = "lblMa_Bp";
			this.lblMa_Bp.Size = new System.Drawing.Size(64, 13);
			this.lblMa_Bp.TabIndex = 60;
			this.lblMa_Bp.Tag = "Ma_Bp";
			this.lblMa_Bp.Text = "Mã bộ phận";
			this.lblMa_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkNh_Cuoi
			// 
			this.chkNh_Cuoi.AutoSize = true;
			this.chkNh_Cuoi.ForeColor = System.Drawing.Color.Red;
			this.chkNh_Cuoi.Location = new System.Drawing.Point(116, 95);
			this.chkNh_Cuoi.Name = "chkNh_Cuoi";
			this.chkNh_Cuoi.Size = new System.Drawing.Size(237, 17);
			this.chkNh_Cuoi.TabIndex = 3;
			this.chkNh_Cuoi.Text = "Là nhóm cuối (Là bộ phận chi tiết cuối cùng)";
			this.chkNh_Cuoi.UseVisualStyleBackColor = true;
			// 
			// frmDmBp_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(571, 297);
			this.Name = "frmDmBp_Edit";
			this.Object_ID = "DMBP";
			this.Tag = "frmDmBp, ESC";
			this.Text = "frmDmBp";
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

		private RosySystem.Control.rsTextBox txtMa_Bp;
		private RosySystem.Control.rsTextBox txtTen_Bp;
		private RosySystem.Control.rsTextBox txtMa_Bp_Parent;
		private RosySystem.Control.rsLabel lbtTen_Bp_Cha;
		private RosySystem.Control.rsLabel lblMa_Bp_Parent;
		private RosySystem.Control.rsLabel lblTen_Bp;
		private RosySystem.Control.rsLabel lblMa_Bp;
		private RosySystem.Control.rsCheckbox chkNh_Cuoi;
	}
}