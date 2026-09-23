namespace RosyList
{
    partial class frmDLSXKT_Edit
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
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtMa_So = new RosySystem.Control.rsTextBox();
            this.lbtTen_Ma_So = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.numSo_Luong = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(395, 158);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(565, 145);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.numSo_Luong);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.dteNgay_Ct);
            this.Page1.Controls.Add(this.lbtTen_Ma_So);
            this.Page1.Controls.Add(this.rsLabel7);
            this.Page1.Controls.Add(this.txtMa_So);
            this.Page1.Size = new System.Drawing.Size(557, 119);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(557, 119);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 166);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 175);
            this.lblLog.Text = "";
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(19, 18);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(36, 13);
            this.rsLabel7.TabIndex = 39;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Mã số";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_So
            // 
            this.txtMa_So.AutoDropDown = null;
            this.txtMa_So.Location = new System.Drawing.Point(79, 15);
            this.txtMa_So.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_So.Name = "txtMa_So";
            this.txtMa_So.Size = new System.Drawing.Size(97, 20);
            this.txtMa_So.TabIndex = 0;
            // 
            // lbtTen_Ma_So
            // 
            this.lbtTen_Ma_So.AutoEllipsis = true;
            this.lbtTen_Ma_So.AutoSize = true;
            this.lbtTen_Ma_So.Location = new System.Drawing.Point(181, 18);
            this.lbtTen_Ma_So.Name = "lbtTen_Ma_So";
            this.lbtTen_Ma_So.Size = new System.Drawing.Size(57, 13);
            this.lbtTen_Ma_So.TabIndex = 40;
            this.lbtTen_Ma_So.Tag = "";
            this.lbtTen_Ma_So.Text = "Tên mã số";
            this.lbtTen_Ma_So.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(79, 37);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct.TabIndex = 1;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(19, 42);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(45, 13);
            this.rsLabel1.TabIndex = 42;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Ngày Ct";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.AutoDropDown = null;
            this.numSo_Luong.bFormat = true;
            this.numSo_Luong.Location = new System.Drawing.Point(79, 59);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Scale = 2;
            this.numSo_Luong.Size = new System.Drawing.Size(97, 20);
            this.numSo_Luong.TabIndex = 2;
            this.numSo_Luong.Text = "0.00";
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong.Value = 0D;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(19, 66);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(39, 13);
            this.rsLabel2.TabIndex = 44;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Số liệu";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDLSXKT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 207);
            this.Name = "frmDLSXKT_Edit";
            this.Object_ID = "DLSXKT";
            this.Tag = "frmDLSXKT, ESC";
            this.Text = "frmDLSXKT";
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

        private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsTextBox txtMa_CL;
        private RosySystem.Control.rsTextBox txtMa_So;
        private RosySystem.Control.rsLabel lbtTen_Ma_So;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong;

	}
}