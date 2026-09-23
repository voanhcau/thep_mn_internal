namespace RosyModule
{
    partial class frmSendMailCNXX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendMailCNXX));
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtSub = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtContent = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.btPath = new System.Windows.Forms.Button();
            this.txtPath = new RosySystem.Control.rsTextBox();
            this.rdbAuto = new RosySystem.Control.rsRadioButton();
            this.rdbNotAuto = new RosySystem.Control.rsRadioButton();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(370, 272);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(184, 47);
            this.btgAccept.TabIndex = 7;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(17, 54);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(44, 13);
            this.rsLabel1.TabIndex = 24;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Tiêu đề";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSub
            // 
            this.txtSub.AutoDropDown = null;
            this.txtSub.Location = new System.Drawing.Point(139, 50);
            this.txtSub.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(219, 20);
            this.txtSub.TabIndex = 5;
            this.txtSub.Tag = "";
            this.txtSub.Text = "Chứng nhận xuất xưởng gởi từ SSCV";
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(17, 77);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(50, 13);
            this.rsLabel5.TabIndex = 24;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Nội dung";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContent
            // 
            this.txtContent.AutoDropDown = null;
            this.txtContent.Location = new System.Drawing.Point(139, 73);
            this.txtContent.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(450, 140);
            this.txtContent.TabIndex = 6;
            this.txtContent.Tag = "";
            this.txtContent.Text = resources.GetString("txtContent.Text");
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(17, 19);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(111, 13);
            this.rsLabel6.TabIndex = 90;
            this.rsLabel6.Text = "Path CNXX (đã ký số)";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPath
            // 
            this.btPath.Location = new System.Drawing.Point(508, 15);
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
            this.txtPath.Location = new System.Drawing.Point(139, 16);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPath.MaxLength = 20;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(364, 20);
            this.txtPath.TabIndex = 2;
            this.txtPath.Text = "D:\\\\CNXX_DAKY";
            // 
            // rdbAuto
            // 
            this.rdbAuto.AutoSize = true;
            this.rdbAuto.Checked = true;
            this.rdbAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAuto.Location = new System.Drawing.Point(20, 221);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(102, 17);
            this.rdbAuto.TabIndex = 91;
            this.rdbAuto.TabStop = true;
            this.rdbAuto.Text = "Gửi mail tự động";
            this.rdbAuto.UnChecked = false;
            this.rdbAuto.UseVisualStyleBackColor = true;
            // 
            // rdbNotAuto
            // 
            this.rdbNotAuto.AutoSize = true;
            this.rdbNotAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNotAuto.Location = new System.Drawing.Point(20, 244);
            this.rdbNotAuto.Name = "rdbNotAuto";
            this.rdbNotAuto.Size = new System.Drawing.Size(128, 17);
            this.rdbNotAuto.TabIndex = 92;
            this.rdbNotAuto.Text = "Xem trước khi gửi mail";
            this.rdbNotAuto.UnChecked = true;
            this.rdbNotAuto.UseVisualStyleBackColor = true;
            // 
            // frmSendMailCNXX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 327);
            this.Controls.Add(this.rdbNotAuto);
            this.Controls.Add(this.rdbAuto);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.btPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmSendMailCNXX";
            this.Tag = "frmSendMail, ESC";
            this.Text = "frmSendMailCNXX";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel5;
        public RosySystem.Control.rsTextBox txtSub;
        public RosySystem.Control.rsTextBox txtContent;
        private RosySystem.Control.rsLabel rsLabel6;
        private System.Windows.Forms.Button btPath;
        public RosySystem.Control.rsTextBox txtPath;
        private RosySystem.Control.rsRadioButton rdbAuto;
        private RosySystem.Control.rsRadioButton rdbNotAuto;
	}
}