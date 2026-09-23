namespace RosyModule.Receivable
{
    partial class frmSendMailHDDT
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
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtAcc = new RosySystem.Control.rsTextBox();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtPassword = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtSub = new RosySystem.Control.rsTextBox();
            this.txtToCC = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtContent = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.btPath = new System.Windows.Forms.Button();
            this.txtPath = new RosySystem.Control.rsTextBox();
            this.SuspendLayout();
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(17, 13);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(60, 13);
            this.rsLabel2.TabIndex = 2;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Email Send";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAcc
            // 
            this.txtAcc.AutoDropDown = null;
            this.txtAcc.Location = new System.Drawing.Point(139, 6);
            this.txtAcc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(219, 20);
            this.txtAcc.TabIndex = 0;
            this.txtAcc.Tag = "";
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(383, 263);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(184, 47);
            this.btgAccept.TabIndex = 7;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(17, 33);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(56, 13);
            this.rsLabel3.TabIndex = 24;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Password ";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoDropDown = null;
            this.txtPassword.Location = new System.Drawing.Point(139, 29);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(219, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Tag = "";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(17, 102);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(43, 13);
            this.rsLabel1.TabIndex = 24;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Subject";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSub
            // 
            this.txtSub.AutoDropDown = null;
            this.txtSub.Location = new System.Drawing.Point(139, 98);
            this.txtSub.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(219, 20);
            this.txtSub.TabIndex = 5;
            this.txtSub.Tag = "";
            this.txtSub.Text = "Hoá đơn điện tử gởi từ SSCV";
            // 
            // txtToCC
            // 
            this.txtToCC.AutoDropDown = null;
            this.txtToCC.Location = new System.Drawing.Point(139, 75);
            this.txtToCC.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtToCC.Name = "txtToCC";
            this.txtToCC.ReadOnly = true;
            this.txtToCC.Size = new System.Drawing.Size(219, 20);
            this.txtToCC.TabIndex = 4;
            this.txtToCC.Tag = "";
            this.txtToCC.Text = "phongketoan@thepmiennam.com.vn";
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(17, 79);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(56, 13);
            this.rsLabel4.TabIndex = 26;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Email BCC";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(17, 125);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(31, 13);
            this.rsLabel5.TabIndex = 24;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Body";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContent
            // 
            this.txtContent.AutoDropDown = null;
            this.txtContent.Location = new System.Drawing.Point(139, 121);
            this.txtContent.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(450, 127);
            this.txtContent.TabIndex = 6;
            this.txtContent.Tag = "";
            this.txtContent.Text = "Kính gởi Quý Công ty,\r\n\r\nĐây là email tự động gởi hoá đơn điện tử. Khách hàng khô" +
    "ng cần trả lời email này.\r\nĐiện thoại hỗ trợ 0908727761 hoặc phản hồi lại email " +
    "này.\r\n\r\nTrân trọng.";
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(17, 55);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(113, 13);
            this.rsLabel6.TabIndex = 90;
            this.rsLabel6.Text = "Path HDDT (đã ký số)";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPath
            // 
            this.btPath.Location = new System.Drawing.Point(508, 51);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(81, 23);
            this.btPath.TabIndex = 3;
            this.btPath.Text = "Browse";
            this.btPath.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.AutoDropDown = null;
            this.txtPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPath.Location = new System.Drawing.Point(139, 52);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPath.MaxLength = 20;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(364, 20);
            this.txtPath.TabIndex = 2;
            // 
            // frmSendMailHDDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 318);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.btPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtToCC);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.rsLabel2);
            this.Name = "frmSendMailHDDT";
            this.Tag = "frmSendMail, ESC";
            this.Text = "frmSendMail";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Control.rsLabel rsLabel2;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel rsLabel5;
        public RosySystem.Control.rsTextBox txtAcc;
        public RosySystem.Control.rsTextBox txtPassword;
        public RosySystem.Control.rsTextBox txtSub;
        public RosySystem.Control.rsTextBox txtToCC;
        public RosySystem.Control.rsTextBox txtContent;
        private RosySystem.Control.rsLabel rsLabel6;
        private System.Windows.Forms.Button btPath;
        public RosySystem.Control.rsTextBox txtPath;
	}
}