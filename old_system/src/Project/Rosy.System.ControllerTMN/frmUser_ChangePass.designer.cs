namespace RosyControllerTMN
{
	partial class frmUser_ChangePass
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
            this.lbTen_Nh_Dt = new RosySystem.Control.rsLabel();
            this.lbDm_Nh_Dt = new RosySystem.Control.rsLabel();
            this.txtPassword = new RosySystem.Control.rsTextBox();
            this.label3 = new RosySystem.Control.rsLabel();
            this.label4 = new RosySystem.Control.rsLabel();
            this.txtPassword_Re = new RosySystem.Control.rsTextBox();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // lbTen_Nh_Dt
            // 
            this.lbTen_Nh_Dt.AutoEllipsis = true;
            this.lbTen_Nh_Dt.AutoSize = true;
            this.lbTen_Nh_Dt.Location = new System.Drawing.Point(-97, 135);
            this.lbTen_Nh_Dt.Name = "lbTen_Nh_Dt";
            this.lbTen_Nh_Dt.Size = new System.Drawing.Size(55, 13);
            this.lbTen_Nh_Dt.TabIndex = 3;
            this.lbTen_Nh_Dt.Text = "Tên nhóm";
            this.lbTen_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDm_Nh_Dt
            // 
            this.lbDm_Nh_Dt.AutoEllipsis = true;
            this.lbDm_Nh_Dt.AutoSize = true;
            this.lbDm_Nh_Dt.Location = new System.Drawing.Point(-97, 113);
            this.lbDm_Nh_Dt.Name = "lbDm_Nh_Dt";
            this.lbDm_Nh_Dt.Size = new System.Drawing.Size(51, 13);
            this.lbDm_Nh_Dt.TabIndex = 4;
            this.lbDm_Nh_Dt.Text = "Mã nhóm";
            this.lbDm_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoDropDown = null;
            this.txtPassword.Location = new System.Drawing.Point(137, 27);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(138, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 13;
            this.label3.Tag = "Password";
            this.label3.Text = "Mật khẩu mới";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 13;
            this.label4.Tag = "Confirm_Password";
            this.label4.Text = "Nhập lại mật khẩu mới";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword_Re
            // 
            this.txtPassword_Re.AutoDropDown = null;
            this.txtPassword_Re.Location = new System.Drawing.Point(137, 49);
            this.txtPassword_Re.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPassword_Re.MaxLength = 20;
            this.txtPassword_Re.Name = "txtPassword_Re";
            this.txtPassword_Re.PasswordChar = '*';
            this.txtPassword_Re.Size = new System.Drawing.Size(138, 20);
            this.txtPassword_Re.TabIndex = 3;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(206, 158);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 7;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.ForeColor = System.Drawing.Color.Red;
            this.rsLabel1.Location = new System.Drawing.Point(12, 84);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(308, 13);
            this.rsLabel1.TabIndex = 13;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Lưu ý: Mật khẩu thay đổi bắt buộc thỏa mãn các điều kiện sau:";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(12, 107);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(172, 13);
            this.rsLabel2.TabIndex = 13;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "1. Mật khẩu mới khác mật khẩu cũ";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(12, 131);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(377, 13);
            this.rsLabel3.TabIndex = 14;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "2. Mật khẩu phải dài ít nhất 8 ký tự trong đó phải có Số, chữ và ký tự đặc biệt";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUser_ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 209);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword_Re);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTen_Nh_Dt);
            this.Controls.Add(this.lbDm_Nh_Dt);
            this.Name = "frmUser_ChangePass";
            this.Text = "frmUser_ChangePass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsLabel lbTen_Nh_Dt;
		private RosySystem.Control.rsLabel lbDm_Nh_Dt;
        private RosySystem.Control.rsTextBox txtPassword;
        private RosySystem.Control.rsLabel label3;
        private RosySystem.Control.rsLabel label4;
        private RosySystem.Control.rsTextBox txtPassword_Re;
		private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel3;
    }
}