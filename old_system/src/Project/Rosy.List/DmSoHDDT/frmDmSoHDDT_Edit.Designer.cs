namespace RosyList
{
    partial class frmDmSoHDDT_Edit
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
            this.txtSo_Ct = new RosySystem.Control.rsTextBox();
            this.lbTen_Kv = new RosySystem.Control.rsLabel();
            this.lbMa_Kv = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(395, 190);
            this.btgAccept.Size = new System.Drawing.Size(181, 44);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(564, 178);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.dteNgay_Ct);
            this.Page1.Controls.Add(this.txtSo_Ct);
            this.Page1.Controls.Add(this.lbTen_Kv);
            this.Page1.Controls.Add(this.lbMa_Kv);
            this.Page1.Size = new System.Drawing.Size(556, 152);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(556, 152);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 202);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 211);
            this.lblLog.Text = "";
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.AutoDropDown = null;
            this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct.Location = new System.Drawing.Point(132, 75);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct.MaxLength = 20;
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Ct.TabIndex = 1;
            // 
            // lbTen_Kv
            // 
            this.lbTen_Kv.AutoEllipsis = true;
            this.lbTen_Kv.AutoSize = true;
            this.lbTen_Kv.Location = new System.Drawing.Point(64, 78);
            this.lbTen_Kv.Name = "lbTen_Kv";
            this.lbTen_Kv.Size = new System.Drawing.Size(65, 13);
            this.lbTen_Kv.TabIndex = 19;
            this.lbTen_Kv.Tag = "So_Ct";
            this.lbTen_Kv.Text = "Số chứng từ";
            this.lbTen_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Kv
            // 
            this.lbMa_Kv.AutoEllipsis = true;
            this.lbMa_Kv.AutoSize = true;
            this.lbMa_Kv.Location = new System.Drawing.Point(64, 55);
            this.lbMa_Kv.Name = "lbMa_Kv";
            this.lbMa_Kv.Size = new System.Drawing.Size(45, 13);
            this.lbMa_Kv.TabIndex = 20;
            this.lbMa_Kv.Tag = "Ngay_Ct";
            this.lbMa_Kv.Text = "Ngày Ct";
            this.lbMa_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = true;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(132, 52);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct.TabIndex = 0;
            // 
            // frmDmSoHDDT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 242);
            this.Name = "frmDmSoHDDT_Edit";
            this.Object_ID = "DMSOHDDT";
            this.Tag = "frmDmSoHDDT, F2, F3, F8, ESC";
            this.Text = "frmDmSoHDDT";
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

        private RosySystem.Control.rsTextBox txtSo_Ct;
		private RosySystem.Control.rsLabel lbTen_Kv;
		private RosySystem.Control.rsLabel lbMa_Kv;
        private RosySystem.Control.rsDateTime dteNgay_Ct;

	}
}