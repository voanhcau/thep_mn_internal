namespace RosyList
{
    partial class frmDmCTrinh_Edit
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
            this.txtMa_CTrinh = new RosySystem.Control.rsTextBox();
            this.txtTen_CTrinh = new RosySystem.Control.rsTextBox();
            this.txtMa_CTrinh_Parent = new RosySystem.Control.rsTextBox();
            this.lbtTen_CTrinh_Cha = new RosySystem.Control.rsLabel();
            this.lblMa_CTrinh_Parent = new RosySystem.Control.rsLabel();
            this.lblTen_CTrinh = new RosySystem.Control.rsLabel();
            this.lblMa_Bp = new RosySystem.Control.rsLabel();
            this.chkNh_Cuoi = new RosySystem.Control.rsCheckbox();
            this.txtMa_Kv = new RosySystem.Control.rsTextBox();
            this.lbtTen_Kv = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
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
            this.Page1.Controls.Add(this.txtMa_Kv);
            this.Page1.Controls.Add(this.lbtTen_Kv);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.chkNh_Cuoi);
            this.Page1.Controls.Add(this.txtMa_CTrinh);
            this.Page1.Controls.Add(this.txtTen_CTrinh);
            this.Page1.Controls.Add(this.txtMa_CTrinh_Parent);
            this.Page1.Controls.Add(this.lbtTen_CTrinh_Cha);
            this.Page1.Controls.Add(this.lblMa_CTrinh_Parent);
            this.Page1.Controls.Add(this.lblTen_CTrinh);
            this.Page1.Controls.Add(this.lblMa_Bp);
            this.Page1.Size = new System.Drawing.Size(539, 210);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(539, 210);
            // 
            // lblLog
            // 
            this.lblLog.Text = "";
            // 
            // txtMa_CTrinh
            // 
            this.txtMa_CTrinh.AutoDropDown = null;
            this.txtMa_CTrinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CTrinh.Location = new System.Drawing.Point(116, 26);
            this.txtMa_CTrinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CTrinh.Name = "txtMa_CTrinh";
            this.txtMa_CTrinh.Size = new System.Drawing.Size(137, 20);
            this.txtMa_CTrinh.TabIndex = 0;
            // 
            // txtTen_CTrinh
            // 
            this.txtTen_CTrinh.AutoDropDown = null;
            this.txtTen_CTrinh.Location = new System.Drawing.Point(116, 48);
            this.txtTen_CTrinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_CTrinh.Name = "txtTen_CTrinh";
            this.txtTen_CTrinh.Size = new System.Drawing.Size(335, 20);
            this.txtTen_CTrinh.TabIndex = 1;
            // 
            // txtMa_CTrinh_Parent
            // 
            this.txtMa_CTrinh_Parent.AutoDropDown = null;
            this.txtMa_CTrinh_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CTrinh_Parent.Location = new System.Drawing.Point(116, 70);
            this.txtMa_CTrinh_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CTrinh_Parent.Name = "txtMa_CTrinh_Parent";
            this.txtMa_CTrinh_Parent.Size = new System.Drawing.Size(137, 20);
            this.txtMa_CTrinh_Parent.TabIndex = 2;
            // 
            // lbtTen_CTrinh_Cha
            // 
            this.lbtTen_CTrinh_Cha.AutoEllipsis = true;
            this.lbtTen_CTrinh_Cha.AutoSize = true;
            this.lbtTen_CTrinh_Cha.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_CTrinh_Cha.Location = new System.Drawing.Point(267, 71);
            this.lbtTen_CTrinh_Cha.Name = "lbtTen_CTrinh_Cha";
            this.lbtTen_CTrinh_Cha.Size = new System.Drawing.Size(97, 13);
            this.lbtTen_CTrinh_Cha.TabIndex = 61;
            this.lbtTen_CTrinh_Cha.Text = "Tên công trình cha";
            this.lbtTen_CTrinh_Cha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_CTrinh_Parent
            // 
            this.lblMa_CTrinh_Parent.AutoEllipsis = true;
            this.lblMa_CTrinh_Parent.AutoSize = true;
            this.lblMa_CTrinh_Parent.Location = new System.Drawing.Point(17, 70);
            this.lblMa_CTrinh_Parent.Name = "lblMa_CTrinh_Parent";
            this.lblMa_CTrinh_Parent.Size = new System.Drawing.Size(76, 13);
            this.lblMa_CTrinh_Parent.TabIndex = 58;
            this.lblMa_CTrinh_Parent.Tag = "Ma_Bp_Parent";
            this.lblMa_CTrinh_Parent.Text = "Công trình cha";
            this.lblMa_CTrinh_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_CTrinh
            // 
            this.lblTen_CTrinh.AutoEllipsis = true;
            this.lblTen_CTrinh.AutoSize = true;
            this.lblTen_CTrinh.Location = new System.Drawing.Point(17, 49);
            this.lblTen_CTrinh.Name = "lblTen_CTrinh";
            this.lblTen_CTrinh.Size = new System.Drawing.Size(76, 13);
            this.lblTen_CTrinh.TabIndex = 59;
            this.lblTen_CTrinh.Tag = "Ten_CTrinh";
            this.lblTen_CTrinh.Text = "Tên công trình";
            this.lblTen_CTrinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Bp
            // 
            this.lblMa_Bp.AutoEllipsis = true;
            this.lblMa_Bp.AutoSize = true;
            this.lblMa_Bp.Location = new System.Drawing.Point(17, 26);
            this.lblMa_Bp.Name = "lblMa_Bp";
            this.lblMa_Bp.Size = new System.Drawing.Size(72, 13);
            this.lblMa_Bp.TabIndex = 60;
            this.lblMa_Bp.Tag = "Ma_CTrinh";
            this.lblMa_Bp.Text = "Mã công trình";
            this.lblMa_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNh_Cuoi
            // 
            this.chkNh_Cuoi.AutoSize = true;
            this.chkNh_Cuoi.ForeColor = System.Drawing.Color.Red;
            this.chkNh_Cuoi.Location = new System.Drawing.Point(116, 129);
            this.chkNh_Cuoi.Name = "chkNh_Cuoi";
            this.chkNh_Cuoi.Size = new System.Drawing.Size(237, 17);
            this.chkNh_Cuoi.TabIndex = 3;
            this.chkNh_Cuoi.Text = "Là nhóm cuối (Là bộ phận chi tiết cuối cùng)";
            this.chkNh_Cuoi.UseVisualStyleBackColor = true;
            // 
            // txtMa_Kv
            // 
            this.txtMa_Kv.AutoDropDown = null;
            this.txtMa_Kv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Kv.Location = new System.Drawing.Point(116, 92);
            this.txtMa_Kv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kv.Name = "txtMa_Kv";
            this.txtMa_Kv.Size = new System.Drawing.Size(137, 20);
            this.txtMa_Kv.TabIndex = 62;
            // 
            // lbtTen_Kv
            // 
            this.lbtTen_Kv.AutoEllipsis = true;
            this.lbtTen_Kv.AutoSize = true;
            this.lbtTen_Kv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Kv.Location = new System.Drawing.Point(267, 93);
            this.lbtTen_Kv.Name = "lbtTen_Kv";
            this.lbtTen_Kv.Size = new System.Drawing.Size(68, 13);
            this.lbtTen_Kv.TabIndex = 64;
            this.lbtTen_Kv.Text = "Tên khu vực";
            this.lbtTen_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(17, 92);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(64, 13);
            this.rsLabel2.TabIndex = 63;
            this.rsLabel2.Tag = "Ma_Kv";
            this.rsLabel2.Text = "Mã khu vực";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmCTrinh_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 297);
            this.Name = "frmDmCTrinh_Edit";
            this.Object_ID = "DMCTRINH";
            this.Tag = "frmDmCTrinh, ESC";
            this.Text = "frmDmCTrinh";
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

		private RosySystem.Control.rsTextBox txtMa_CTrinh;
		private RosySystem.Control.rsTextBox txtTen_CTrinh;
		private RosySystem.Control.rsTextBox txtMa_CTrinh_Parent;
		private RosySystem.Control.rsLabel lbtTen_CTrinh_Cha;
		private RosySystem.Control.rsLabel lblMa_CTrinh_Parent;
		private RosySystem.Control.rsLabel lblTen_CTrinh;
		private RosySystem.Control.rsLabel lblMa_Bp;
		private RosySystem.Control.rsCheckbox chkNh_Cuoi;
        private RosySystem.Control.rsTextBox txtMa_Kv;
        private RosySystem.Control.rsLabel lbtTen_Kv;
        private RosySystem.Control.rsLabel rsLabel2;
	}
}