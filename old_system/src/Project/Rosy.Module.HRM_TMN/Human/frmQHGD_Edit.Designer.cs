namespace RosyModule.HRM
{
    partial class frmQHGD_Edit
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
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtNam_Sinh = new RosySystem.Control.rsNumericUpdown();
            this.txtLoai_QHGD = new RosySystem.Control.rsComboBox();
            this.txtHo_Ten = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam_Sinh)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(252, 23);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(59, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 122;
            this.lbtTen_Dt_CbNv.Text = "Ten_CbNv";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(427, 165);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 44);
            this.btgAccept.TabIndex = 116;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(18, 114);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(44, 13);
            this.rsLabel5.TabIndex = 118;
            this.rsLabel5.Tag = "Ghi_Chu";
            this.rsLabel5.Text = "Ghi chú";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(18, 91);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(51, 13);
            this.rsLabel4.TabIndex = 121;
            this.rsLabel4.Tag = "Nam_Sinh";
            this.rsLabel4.Text = "Năm sinh";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(18, 68);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(69, 13);
            this.rsLabel3.TabIndex = 119;
            this.rsLabel3.Tag = "Loai_Quan_He";
            this.rsLabel3.Text = "Loại quan hệ";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(127, 110);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(479, 40);
            this.txtGhi_Chu.TabIndex = 115;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(18, 45);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(39, 13);
            this.rsLabel2.TabIndex = 120;
            this.rsLabel2.Tag = "Ho_Ten";
            this.rsLabel2.Text = "Họ tên";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNam_Sinh
            // 
            this.txtNam_Sinh.Location = new System.Drawing.Point(127, 88);
            this.txtNam_Sinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNam_Sinh.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNam_Sinh.Name = "txtNam_Sinh";
            this.txtNam_Sinh.Size = new System.Drawing.Size(71, 20);
            this.txtNam_Sinh.TabIndex = 114;
            // 
            // txtLoai_QHGD
            // 
            this.txtLoai_QHGD.Items.AddRange(new object[] {
            "Ông",
            "Bà",
            "Cha",
            "Mẹ",
            "Anh",
            "Chị",
            "Con",
            "Cháu"});
            this.txtLoai_QHGD.Location = new System.Drawing.Point(127, 65);
            this.txtLoai_QHGD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLoai_QHGD.Name = "txtLoai_QHGD";
            this.txtLoai_QHGD.Size = new System.Drawing.Size(140, 21);
            this.txtLoai_QHGD.TabIndex = 113;
            // 
            // txtHo_Ten
            // 
            this.txtHo_Ten.AutoDropDown = null;
            this.txtHo_Ten.Location = new System.Drawing.Point(127, 42);
            this.txtHo_Ten.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtHo_Ten.Name = "txtHo_Ten";
            this.txtHo_Ten.Size = new System.Drawing.Size(479, 20);
            this.txtHo_Ten.TabIndex = 112;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(18, 22);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(72, 13);
            this.rsLabel1.TabIndex = 117;
            this.rsLabel1.Tag = "Ma_Dt_CbNv";
            this.rsLabel1.Text = "Mã nhân viên";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(127, 19);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt_CbNv.TabIndex = 111;
            // 
            // frmQHGD_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 213);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtNam_Sinh);
            this.Controls.Add(this.txtLoai_QHGD);
            this.Controls.Add(this.txtHo_Ten);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Name = "frmQHGD_Edit";
            this.Text = "frmQHGD_Edit";
            ((System.ComponentModel.ISupportInitialize)(this.txtNam_Sinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBox txtGhi_Chu;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsNumericUpdown txtNam_Sinh;
		private RosySystem.Control.rsComboBox txtLoai_QHGD;
		private RosySystem.Control.rsTextBox txtHo_Ten;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;

	}
}