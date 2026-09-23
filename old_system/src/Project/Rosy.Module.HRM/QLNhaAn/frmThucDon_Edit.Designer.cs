namespace RosyModule.HRM
{
    partial class frmThucDon_Edit
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
            this.txtMa_MAn_List = new RosySystem.Control.rsTextBox();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.txtLoai = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtTen_MAn_List = new RosySystem.Control.rsTextBox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(737, 177);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(269, 68);
            this.btgAccept.TabIndex = 3;
            // 
            // txtMa_MAn_List
            // 
            this.txtMa_MAn_List.AutoDropDown = null;
            this.txtMa_MAn_List.Location = new System.Drawing.Point(191, 81);
            this.txtMa_MAn_List.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtMa_MAn_List.Multiline = true;
            this.txtMa_MAn_List.Name = "txtMa_MAn_List";
            this.txtMa_MAn_List.Size = new System.Drawing.Size(619, 30);
            this.txtMa_MAn_List.TabIndex = 2;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(15, 84);
            this.rsLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(169, 20);
            this.rsLabel9.TabIndex = 121;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Danh sách mã món ăn";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(15, 54);
            this.rsLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(139, 20);
            this.rsLabel7.TabIndex = 121;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Thực đơn cho buổi";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel8.Location = new System.Drawing.Point(210, 54);
            this.rsLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(269, 20);
            this.rsLabel8.TabIndex = 122;
            this.rsLabel8.Text = "S - sáng, T - trưa, C - chiều, K - khuya";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoai
            // 
            this.txtLoai.AutoDropDown = null;
            this.txtLoai.InputMask = "S,T,C,K";
            this.txtLoai.Location = new System.Drawing.Point(161, 49);
            this.txtLoai.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(41, 26);
            this.txtLoai.TabIndex = 1;
            this.txtLoai.Text = "S";
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(15, 21);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(45, 20);
            this.rsLabel1.TabIndex = 121;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.BackColor = System.Drawing.SystemColors.Window;
            this.dteNgay_Ct.bAllowEmpty = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(161, 18);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(121, 26);
            this.dteNgay_Ct.TabIndex = 0;
            this.dteNgay_Ct.Text = "00002021";
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(15, 116);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(170, 20);
            this.rsLabel2.TabIndex = 124;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Danh sách tên món ăn";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_MAn_List
            // 
            this.txtTen_MAn_List.AutoDropDown = null;
            this.txtTen_MAn_List.Location = new System.Drawing.Point(191, 113);
            this.txtTen_MAn_List.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtTen_MAn_List.Multiline = true;
            this.txtTen_MAn_List.Name = "txtTen_MAn_List";
            this.txtTen_MAn_List.Size = new System.Drawing.Size(833, 30);
            this.txtTen_MAn_List.TabIndex = 123;
            // 
            // frmThucDon_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 251);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtTen_MAn_List);
            this.Controls.Add(this.dteNgay_Ct);
            this.Controls.Add(this.txtLoai);
            this.Controls.Add(this.rsLabel8);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.txtMa_MAn_List);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "frmThucDon_Edit";
            this.Text = "frmThucDon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtMa_MAn_List;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsTextBoxEnum txtLoai;
        private RosySystem.Control.rsLabel rsLabel1;
        //private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtTen_MAn_List;

	}
}