namespace RosyList
{
	partial class frmDmNvu
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
            this.cboKieu_Nhom = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitcContent)).BeginInit();
            this.splitcContent.Panel2.SuspendLayout();
            this.splitcContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitcContent
            // 
            this.splitcContent.SplitterDistance = 505;
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(340, 3);
            // 
            // cboKieu_Nhom
            // 
            this.cboKieu_Nhom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKieu_Nhom.FormattingEnabled = true;
            this.cboKieu_Nhom.Items.AddRange(new object[] {
            "0-Không nhóm",
            "1-Theo chứng từ",
            "2-Theo tk nợ",
            "3-Theo tk có",
            "4-Theo mã đối tượng",
            "5-Theo mã bộ phận",
            "6-Theo mã khoản mục",
            "7-Theo sản phẩm",
            "8-Theo hợp đồng",
            "9-Theo mã thuế",
            "a-Theo mã kho",
            "b-Theo mã Cb nhân viên"});
            this.cboKieu_Nhom.Location = new System.Drawing.Point(654, 10);
            this.cboKieu_Nhom.Name = "cboKieu_Nhom";
            this.cboKieu_Nhom.Size = new System.Drawing.Size(126, 21);
            this.cboKieu_Nhom.TabIndex = 11;
            this.cboKieu_Nhom.Text = "1-Theo chứng từ";
            // 
            // frmDmNvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "frmDmNvu";
            this.Object_ID = "DMNVU";
            this.Tag = "frmDmNvu";
            this.Text = "frmDmNvu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitcContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcContent)).EndInit();
            this.splitcContent.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboKieu_Nhom;
	}
}