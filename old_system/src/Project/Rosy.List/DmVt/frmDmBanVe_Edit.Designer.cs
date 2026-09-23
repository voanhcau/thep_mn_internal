namespace RosyList
{
	partial class frmDmBanVe_Edit
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
			this.txtTen_Cum = new RosySystem.Control.rsTextBox();
			this.txtMa_Cum = new RosySystem.Control.rsTextBox();
			this.lbTen_Cum = new RosySystem.Control.rsLabel();
			this.lbMa_Nh_Vt = new RosySystem.Control.rsLabel();
			this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(514, 164);
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(687, 148);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.txtGhi_Chu);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Controls.Add(this.txtTen_Cum);
			this.Page1.Controls.Add(this.txtMa_Cum);
			this.Page1.Controls.Add(this.lbTen_Cum);
			this.Page1.Controls.Add(this.lbMa_Nh_Vt);
			this.Page1.Size = new System.Drawing.Size(679, 122);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(679, 214);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 176);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 185);
			this.lblLog.Text = "";
			// 
			// txtTen_Cum
			// 
			this.txtTen_Cum.AutoDropDown = null;
			this.txtTen_Cum.Location = new System.Drawing.Point(120, 43);
			this.txtTen_Cum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Cum.Name = "txtTen_Cum";
			this.txtTen_Cum.Size = new System.Drawing.Size(536, 20);
			this.txtTen_Cum.TabIndex = 1;
			// 
			// txtMa_Cum
			// 
			this.txtMa_Cum.AutoDropDown = null;
			this.txtMa_Cum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Cum.Location = new System.Drawing.Point(120, 21);
			this.txtMa_Cum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Cum.Name = "txtMa_Cum";
			this.txtMa_Cum.Size = new System.Drawing.Size(100, 20);
			this.txtMa_Cum.TabIndex = 0;
			// 
			// lbTen_Cum
			// 
			this.lbTen_Cum.AutoEllipsis = true;
			this.lbTen_Cum.AutoSize = true;
			this.lbTen_Cum.Location = new System.Drawing.Point(23, 43);
			this.lbTen_Cum.Name = "lbTen_Cum";
			this.lbTen_Cum.Size = new System.Drawing.Size(49, 13);
			this.lbTen_Cum.TabIndex = 13;
			this.lbTen_Cum.Tag = "";
			this.lbTen_Cum.Text = "Tên cụm";
			this.lbTen_Cum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Nh_Vt
			// 
			this.lbMa_Nh_Vt.AutoEllipsis = true;
			this.lbMa_Nh_Vt.AutoSize = true;
			this.lbMa_Nh_Vt.Location = new System.Drawing.Point(23, 21);
			this.lbMa_Nh_Vt.Name = "lbMa_Nh_Vt";
			this.lbMa_Nh_Vt.Size = new System.Drawing.Size(45, 13);
			this.lbMa_Nh_Vt.TabIndex = 12;
			this.lbMa_Nh_Vt.Tag = "";
			this.lbMa_Nh_Vt.Text = "Mã cụm";
			this.lbMa_Nh_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtGhi_Chu
			// 
			this.txtGhi_Chu.AutoDropDown = null;
			this.txtGhi_Chu.Location = new System.Drawing.Point(120, 65);
			this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtGhi_Chu.Name = "txtGhi_Chu";
			this.txtGhi_Chu.Size = new System.Drawing.Size(536, 20);
			this.txtGhi_Chu.TabIndex = 2;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(23, 65);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(44, 13);
			this.rsLabel1.TabIndex = 66;
			this.rsLabel1.Tag = "Ghi_Chu";
			this.rsLabel1.Text = "Ghi chú";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmCumTb_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 215);
			this.Name = "frmDmCumTb_Edit";
			this.Object_ID = "DMNHVT";
			this.Tag = "frmDmNhVt, ESC";
			this.Text = "frmDmNhVt";
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

		private RosySystem.Control.rsTextBox txtTen_Cum;
		private RosySystem.Control.rsTextBox txtMa_Cum;
		private RosySystem.Control.rsLabel lbTen_Cum;
		private RosySystem.Control.rsLabel lbMa_Nh_Vt;
		private RosySystem.Control.rsTextBox txtGhi_Chu;
		private RosySystem.Control.rsLabel rsLabel1;



	}
}