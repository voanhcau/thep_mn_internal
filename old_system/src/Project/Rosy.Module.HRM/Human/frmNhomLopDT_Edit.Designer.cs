namespace RosyModule.HRM
{
    partial class frmNhomLopDT_Edit
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
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Nh_LopDT = new RosySystem.Control.rsTextBox();
            this.txtTen_Nh_LopDT = new RosySystem.Control.rsTextBox();
            this.txtMa_Nh_LopDT_Parent = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.chkNh_Cuoi = new RosySystem.Control.rsCheckbox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(427, 84);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 44);
            this.btgAccept.TabIndex = 4;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(13, 44);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(50, 13);
            this.rsLabel3.TabIndex = 119;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Nội dung";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(13, 22);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(68, 13);
            this.rsLabel1.TabIndex = 117;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mã nhóm lớp";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Nh_LopDT
            // 
            this.txtMa_Nh_LopDT.AutoDropDown = null;
            this.txtMa_Nh_LopDT.Location = new System.Drawing.Point(127, 19);
            this.txtMa_Nh_LopDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_LopDT.Name = "txtMa_Nh_LopDT";
            this.txtMa_Nh_LopDT.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_LopDT.TabIndex = 0;
            // 
            // txtTen_Nh_LopDT
            // 
            this.txtTen_Nh_LopDT.AutoDropDown = null;
            this.txtTen_Nh_LopDT.Location = new System.Drawing.Point(127, 41);
            this.txtTen_Nh_LopDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Nh_LopDT.Name = "txtTen_Nh_LopDT";
            this.txtTen_Nh_LopDT.Size = new System.Drawing.Size(451, 20);
            this.txtTen_Nh_LopDT.TabIndex = 1;
            // 
            // txtMa_Nh_LopDT_Parent
            // 
            this.txtMa_Nh_LopDT_Parent.AutoDropDown = null;
            this.txtMa_Nh_LopDT_Parent.Location = new System.Drawing.Point(127, 63);
            this.txtMa_Nh_LopDT_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_LopDT_Parent.Name = "txtMa_Nh_LopDT_Parent";
            this.txtMa_Nh_LopDT_Parent.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_LopDT_Parent.TabIndex = 2;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(13, 66);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(68, 13);
            this.rsLabel2.TabIndex = 117;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Mã nhóm lớp";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNh_Cuoi
            // 
            this.chkNh_Cuoi.AutoSize = true;
            this.chkNh_Cuoi.ForeColor = System.Drawing.Color.Red;
            this.chkNh_Cuoi.Location = new System.Drawing.Point(127, 88);
            this.chkNh_Cuoi.Name = "chkNh_Cuoi";
            this.chkNh_Cuoi.Size = new System.Drawing.Size(90, 17);
            this.chkNh_Cuoi.TabIndex = 3;
            this.chkNh_Cuoi.Text = "Là nhóm cuối";
            this.chkNh_Cuoi.UseVisualStyleBackColor = true;
            // 
            // frmNhomLopDT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 132);
            this.Controls.Add(this.chkNh_Cuoi);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtTen_Nh_LopDT);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Nh_LopDT_Parent);
            this.Controls.Add(this.txtMa_Nh_LopDT);
            this.Name = "frmNhomLopDT_Edit";
            this.Text = "frmNhLopDT_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtMa_Nh_LopDT;
        private RosySystem.Control.rsTextBox txtTen_Nh_LopDT;
        private RosySystem.Control.rsTextBox txtMa_Nh_LopDT_Parent;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsCheckbox chkNh_Cuoi;

	}
}