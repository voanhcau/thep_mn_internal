namespace RosyList
{
	partial class frmDmKm_Edit
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
            this.txtTen_Km = new RosySystem.Control.rsTextBox();
            this.txtMa_Km = new RosySystem.Control.rsTextBox();
            this.lbTen_Km = new RosySystem.Control.rsLabel();
            this.lbMa_Km = new RosySystem.Control.rsLabel();
            this.chkNh_Cuoi = new RosySystem.Control.rsCheckbox();
            this.txtMa_Km_Parent = new RosySystem.Control.rsTextBox();
            this.lbtTen_Km_Cha = new RosySystem.Control.rsLabel();
            this.lblMa_Bp_Parent = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtNote = new RosySystem.Control.rsTextBox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(419, 243);
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(588, 231);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chkNh_Cuoi);
            this.Page1.Controls.Add(this.txtMa_Km_Parent);
            this.Page1.Controls.Add(this.lbtTen_Km_Cha);
            this.Page1.Controls.Add(this.lblMa_Bp_Parent);
            this.Page1.Controls.Add(this.txtNote);
            this.Page1.Controls.Add(this.txtTen_Km);
            this.Page1.Controls.Add(this.txtMa_Km);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.lbTen_Km);
            this.Page1.Controls.Add(this.lbMa_Km);
            this.Page1.Size = new System.Drawing.Size(580, 205);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(580, 205);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 252);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 261);
            this.lblLog.Size = new System.Drawing.Size(365, 22);
            this.lblLog.Text = "";
            // 
            // txtTen_Km
            // 
            this.txtTen_Km.AutoDropDown = null;
            this.txtTen_Km.Location = new System.Drawing.Point(118, 48);
            this.txtTen_Km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Km.MaxLength = 100;
            this.txtTen_Km.Name = "txtTen_Km";
            this.txtTen_Km.Size = new System.Drawing.Size(335, 20);
            this.txtTen_Km.TabIndex = 1;
            // 
            // txtMa_Km
            // 
            this.txtMa_Km.AutoDropDown = null;
            this.txtMa_Km.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Km.Location = new System.Drawing.Point(118, 26);
            this.txtMa_Km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Km.MaxLength = 20;
            this.txtMa_Km.Name = "txtMa_Km";
            this.txtMa_Km.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Km.TabIndex = 0;
            // 
            // lbTen_Km
            // 
            this.lbTen_Km.AutoEllipsis = true;
            this.lbTen_Km.AutoSize = true;
            this.lbTen_Km.Location = new System.Drawing.Point(7, 49);
            this.lbTen_Km.Name = "lbTen_Km";
            this.lbTen_Km.Size = new System.Drawing.Size(82, 13);
            this.lbTen_Km.TabIndex = 19;
            this.lbTen_Km.Tag = "Ten_Km";
            this.lbTen_Km.Text = "Tên khoản mục";
            this.lbTen_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Km
            // 
            this.lbMa_Km.AutoEllipsis = true;
            this.lbMa_Km.AutoSize = true;
            this.lbMa_Km.Location = new System.Drawing.Point(7, 26);
            this.lbMa_Km.Name = "lbMa_Km";
            this.lbMa_Km.Size = new System.Drawing.Size(78, 13);
            this.lbMa_Km.TabIndex = 20;
            this.lbMa_Km.Tag = "Ma_Km";
            this.lbMa_Km.Text = "Mã khoản mục";
            this.lbMa_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNh_Cuoi
            // 
            this.chkNh_Cuoi.AutoSize = true;
            this.chkNh_Cuoi.ForeColor = System.Drawing.Color.Red;
            this.chkNh_Cuoi.Location = new System.Drawing.Point(118, 172);
            this.chkNh_Cuoi.Name = "chkNh_Cuoi";
            this.chkNh_Cuoi.Size = new System.Drawing.Size(237, 17);
            this.chkNh_Cuoi.TabIndex = 4;
            this.chkNh_Cuoi.Text = "Là nhóm cuối (Là bộ phận chi tiết cuối cùng)";
            this.chkNh_Cuoi.UseVisualStyleBackColor = true;
            // 
            // txtMa_Km_Parent
            // 
            this.txtMa_Km_Parent.AutoDropDown = null;
            this.txtMa_Km_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Km_Parent.Location = new System.Drawing.Point(118, 70);
            this.txtMa_Km_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Km_Parent.Name = "txtMa_Km_Parent";
            this.txtMa_Km_Parent.Size = new System.Drawing.Size(137, 20);
            this.txtMa_Km_Parent.TabIndex = 2;
            // 
            // lbtTen_Km_Cha
            // 
            this.lbtTen_Km_Cha.AutoEllipsis = true;
            this.lbtTen_Km_Cha.AutoSize = true;
            this.lbtTen_Km_Cha.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Km_Cha.Location = new System.Drawing.Point(269, 71);
            this.lbtTen_Km_Cha.Name = "lbtTen_Km_Cha";
            this.lbtTen_Km_Cha.Size = new System.Drawing.Size(99, 13);
            this.lbtTen_Km_Cha.TabIndex = 65;
            this.lbtTen_Km_Cha.Text = "Tên khoản mục mẹ";
            this.lbtTen_Km_Cha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Bp_Parent
            // 
            this.lblMa_Bp_Parent.AutoEllipsis = true;
            this.lblMa_Bp_Parent.AutoSize = true;
            this.lblMa_Bp_Parent.Location = new System.Drawing.Point(7, 70);
            this.lblMa_Bp_Parent.Name = "lblMa_Bp_Parent";
            this.lblMa_Bp_Parent.Size = new System.Drawing.Size(82, 13);
            this.lblMa_Bp_Parent.TabIndex = 64;
            this.lblMa_Bp_Parent.Tag = "Ma_Km_Parent";
            this.lblMa_Bp_Parent.Text = "Khoản mục cha";
            this.lblMa_Bp_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMa_Bp_Parent.Click += new System.EventHandler(this.lblMa_Bp_Parent_Click);
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(7, 97);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(45, 13);
            this.rsLabel1.TabIndex = 19;
            this.rsLabel1.Tag = "Note";
            this.rsLabel1.Text = "Ghi Chú";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNote
            // 
            this.txtNote.AutoDropDown = null;
            this.txtNote.Location = new System.Drawing.Point(118, 94);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNote.MaxLength = 1000;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(457, 73);
            this.txtNote.TabIndex = 3;
            // 
            // frmDmKm_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 296);
            this.Name = "frmDmKm_Edit";
            this.Object_ID = "DMKM";
            this.Tag = "frmDmKm, ESC";
            this.Text = "frmDmKm";
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

		private RosySystem.Control.rsTextBox txtTen_Km;
		private RosySystem.Control.rsTextBox txtMa_Km;
		private RosySystem.Control.rsLabel lbTen_Km;
		private RosySystem.Control.rsLabel lbMa_Km;
		private RosySystem.Control.rsCheckbox chkNh_Cuoi;
		private RosySystem.Control.rsTextBox txtMa_Km_Parent;
		private RosySystem.Control.rsLabel lbtTen_Km_Cha;
		private RosySystem.Control.rsLabel lblMa_Bp_Parent;
        private RosySystem.Control.rsTextBox txtNote;
        private RosySystem.Control.rsLabel rsLabel1;
    }
}