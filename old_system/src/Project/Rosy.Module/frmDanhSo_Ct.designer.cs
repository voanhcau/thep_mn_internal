namespace RosyModule
{
    partial class frmDanhSo_Ct
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
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numSo_Ct = new RosySystem.Control.rsTextBoxNumber();
			this.txtSo_Ct_Format = new RosySystem.Control.rsTextBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(313, 104);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(184, 42);
			this.btgAccept.TabIndex = 5;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(36, 25);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(105, 13);
			this.rsLabel1.TabIndex = 75;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Số chứng từ bắt đầu";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numSo_Ct
			// 
			this.numSo_Ct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numSo_Ct.bFormat = true;
			this.numSo_Ct.Location = new System.Drawing.Point(156, 22);
			this.numSo_Ct.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.numSo_Ct.Name = "numSo_Ct";
			this.numSo_Ct.Scale = 0;
			this.numSo_Ct.Size = new System.Drawing.Size(49, 20);
			this.numSo_Ct.TabIndex = 0;
			this.numSo_Ct.Text = "1";
			this.numSo_Ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSo_Ct.Value = 1D;
			// 
			// txtSo_Ct_Format
			// 
			this.txtSo_Ct_Format.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSo_Ct_Format.Location = new System.Drawing.Point(156, 45);
			this.txtSo_Ct_Format.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_Ct_Format.MaxLength = 20;
			this.txtSo_Ct_Format.Name = "txtSo_Ct_Format";
			this.txtSo_Ct_Format.Size = new System.Drawing.Size(129, 20);
			this.txtSo_Ct_Format.TabIndex = 1;
			this.txtSo_Ct_Format.Text = "###";
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(36, 48);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(115, 13);
			this.rsLabel2.TabIndex = 75;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "Định dạng số chứng từ";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.ForeColor = System.Drawing.Color.Red;
			this.rsLabel3.Location = new System.Drawing.Point(153, 67);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(327, 13);
			this.rsLabel3.TabIndex = 2;
			this.rsLabel3.Tag = "";
			this.rsLabel3.Text = "(Ví dụ: PC###/2012: Ký tự ### để đại diện cho phần số tăng dần)";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDanhSo_Ct
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 154);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.numSo_Ct);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.txtSo_Ct_Format);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmDanhSo_Ct";
			this.Text = "frmDanhSo_Ct";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel1;
		public RosySystem.Control.rsTextBoxNumber numSo_Ct;
		public RosySystem.Control.rsTextBox txtSo_Ct_Format;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel3;
    }
}