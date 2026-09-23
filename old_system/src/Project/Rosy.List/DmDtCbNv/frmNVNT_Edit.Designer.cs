namespace RosyList
{
    partial class frmNVNT_Edit
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
            this.lbNgay_Sinh = new RosySystem.Control.rsLabel();
            this.txtTen_Nv_Nt = new RosySystem.Control.rsTextBox();
            this.txtMa_Nv_Nt = new RosySystem.Control.rsTextBox();
            this.lbTen_CbNv = new RosySystem.Control.rsLabel();
            this.lbMa_CbNv = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.lbMa_Nh_Dt = new RosySystem.Control.rsLabel();
            this.numNam_Sinh = new RosySystem.Control.rsTextBoxNumber();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(398, 185);
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(570, 169);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.numNam_Sinh);
            this.Page1.Controls.Add(this.txtMa_Dt);
            this.Page1.Controls.Add(this.lbtTen_Dt);
            this.Page1.Controls.Add(this.lbMa_Nh_Dt);
            this.Page1.Controls.Add(this.lbNgay_Sinh);
            this.Page1.Controls.Add(this.txtTen_Nv_Nt);
            this.Page1.Controls.Add(this.txtMa_Nv_Nt);
            this.Page1.Controls.Add(this.lbTen_CbNv);
            this.Page1.Controls.Add(this.lbMa_CbNv);
            this.Page1.Size = new System.Drawing.Size(562, 143);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(562, 143);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 190);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 199);
            this.lblLog.Text = "";
            // 
            // lbNgay_Sinh
            // 
            this.lbNgay_Sinh.AutoEllipsis = true;
            this.lbNgay_Sinh.AutoSize = true;
            this.lbNgay_Sinh.Location = new System.Drawing.Point(14, 61);
            this.lbNgay_Sinh.Name = "lbNgay_Sinh";
            this.lbNgay_Sinh.Size = new System.Drawing.Size(51, 13);
            this.lbNgay_Sinh.TabIndex = 103;
            this.lbNgay_Sinh.Tag = "";
            this.lbNgay_Sinh.Text = "Năm sinh";
            this.lbNgay_Sinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Nv_Nt
            // 
            this.txtTen_Nv_Nt.AutoDropDown = null;
            this.txtTen_Nv_Nt.Location = new System.Drawing.Point(125, 40);
            this.txtTen_Nv_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Nv_Nt.MaxLength = 100;
            this.txtTen_Nv_Nt.Name = "txtTen_Nv_Nt";
            this.txtTen_Nv_Nt.Size = new System.Drawing.Size(375, 20);
            this.txtTen_Nv_Nt.TabIndex = 1;
            // 
            // txtMa_Nv_Nt
            // 
            this.txtMa_Nv_Nt.AutoDropDown = null;
            this.txtMa_Nv_Nt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nv_Nt.Location = new System.Drawing.Point(125, 19);
            this.txtMa_Nv_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nv_Nt.MaxLength = 20;
            this.txtMa_Nv_Nt.Name = "txtMa_Nv_Nt";
            this.txtMa_Nv_Nt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nv_Nt.TabIndex = 0;
            // 
            // lbTen_CbNv
            // 
            this.lbTen_CbNv.AutoEllipsis = true;
            this.lbTen_CbNv.AutoSize = true;
            this.lbTen_CbNv.Location = new System.Drawing.Point(14, 40);
            this.lbTen_CbNv.Name = "lbTen_CbNv";
            this.lbTen_CbNv.Size = new System.Drawing.Size(39, 13);
            this.lbTen_CbNv.TabIndex = 97;
            this.lbTen_CbNv.Tag = "";
            this.lbTen_CbNv.Text = "Họ tên";
            this.lbTen_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_CbNv
            // 
            this.lbMa_CbNv.AutoEllipsis = true;
            this.lbMa_CbNv.AutoSize = true;
            this.lbMa_CbNv.Location = new System.Drawing.Point(14, 19);
            this.lbMa_CbNv.Name = "lbMa_CbNv";
            this.lbMa_CbNv.Size = new System.Drawing.Size(89, 13);
            this.lbMa_CbNv.TabIndex = 96;
            this.lbMa_CbNv.Tag = "";
            this.lbMa_CbNv.Text = "Số  CMT / CCCD";
            this.lbMa_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(125, 83);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 3;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(250, 86);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_Dt.TabIndex = 107;
            this.lbtTen_Dt.Text = "Tên nhóm ";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Nh_Dt
            // 
            this.lbMa_Nh_Dt.AutoEllipsis = true;
            this.lbMa_Nh_Dt.AutoSize = true;
            this.lbMa_Nh_Dt.Location = new System.Drawing.Point(14, 86);
            this.lbMa_Nh_Dt.Name = "lbMa_Nh_Dt";
            this.lbMa_Nh_Dt.Size = new System.Drawing.Size(67, 13);
            this.lbMa_Nh_Dt.TabIndex = 106;
            this.lbMa_Nh_Dt.Tag = "";
            this.lbMa_Nh_Dt.Text = "Mã nhà thầu";
            this.lbMa_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNam_Sinh
            // 
            this.numNam_Sinh.AutoDropDown = null;
            this.numNam_Sinh.bFormat = true;
            this.numNam_Sinh.Location = new System.Drawing.Point(125, 61);
            this.numNam_Sinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNam_Sinh.Name = "numNam_Sinh";
            this.numNam_Sinh.Scale = 0;
            this.numNam_Sinh.Size = new System.Drawing.Size(120, 20);
            this.numNam_Sinh.TabIndex = 2;
            this.numNam_Sinh.Tag = "Tien_Ck";
            this.numNam_Sinh.Text = "0";
            this.numNam_Sinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam_Sinh.Value = 0D;
            // 
            // frmNVNT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 232);
            this.Name = "frmNVNT_Edit";
            this.Object_ID = "DMNVNT";
            this.Tag = "frmDmCbNv, ESC";
            this.Text = "frmDmCbNv";
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

        private RosySystem.Control.rsLabel lbNgay_Sinh;
		private RosySystem.Control.rsTextBox txtTen_Nv_Nt;
        private RosySystem.Control.rsTextBox txtMa_Nv_Nt;
		private RosySystem.Control.rsLabel lbTen_CbNv;
		private RosySystem.Control.rsLabel lbMa_CbNv;
		private RosySystem.Control.rsTextBox txtMa_Dt;
		private RosySystem.Control.rsLabel lbtTen_Dt;
		private RosySystem.Control.rsLabel lbMa_Nh_Dt;
        private RosySystem.Control.rsTextBoxNumber numNam_Sinh;
	}
}