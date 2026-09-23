namespace RosyModule.Machinery
{
    partial class frmDmNhCCKQKD_Edit
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
            this.tabEdit = new RosySystem.Control.rsTabControl();
            this.Page1 = new System.Windows.Forms.TabPage();
            this.chkNh_Cuoi = new RosySystem.Control.rsCheckbox();
            this.txtTen_Nh_CC = new RosySystem.Control.rsTextBox();
            this.txtMa_Nh_CC = new RosySystem.Control.rsTextBox();
            this.txtMa_Nh_CC_Parent = new RosySystem.Control.rsTextBox();
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabel();
            this.lbMa_Nh_Vt = new RosySystem.Control.rsLabel();
            this.lbTen_Vt = new RosySystem.Control.rsLabel();
            this.lbMa_Vt = new RosySystem.Control.rsLabel();
            this.Page2 = new System.Windows.Forms.TabPage();
            this.lblMa_Data = new RosySystem.Control.rsLabel();
            this.lblNgay_End = new RosySystem.Control.rsLabel();
            this.lblNgay_Begin = new RosySystem.Control.rsLabel();
            this.ucMa_Data = new RosySystem.Customize.ucMa_Data();
            this.txtNgay_End = new RosySystem.Customize.txtNgay_End();
            this.txtNgay_Begin = new RosySystem.Customize.txtNgay_Begin();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEdit
            // 
            this.tabEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEdit.Controls.Add(this.Page1);
            this.tabEdit.Controls.Add(this.Page2);
            this.tabEdit.Location = new System.Drawing.Point(0, 1);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.SelectedIndex = 0;
            this.tabEdit.Size = new System.Drawing.Size(578, 160);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chkNh_Cuoi);
            this.Page1.Controls.Add(this.txtTen_Nh_CC);
            this.Page1.Controls.Add(this.txtMa_Nh_CC);
            this.Page1.Controls.Add(this.txtMa_Nh_CC_Parent);
            this.Page1.Controls.Add(this.lbtTen_Nh_Tb);
            this.Page1.Controls.Add(this.lbMa_Nh_Vt);
            this.Page1.Controls.Add(this.lbTen_Vt);
            this.Page1.Controls.Add(this.lbMa_Vt);
            this.Page1.Location = new System.Drawing.Point(4, 22);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(3);
            this.Page1.Size = new System.Drawing.Size(570, 134);
            this.Page1.TabIndex = 0;
            this.Page1.Tag = "Detail_Info";
            this.Page1.Text = "Thông tin chi tiết";
            this.Page1.UseVisualStyleBackColor = true;
            // 
            // chkNh_Cuoi
            // 
            this.chkNh_Cuoi.AutoSize = true;
            this.chkNh_Cuoi.ForeColor = System.Drawing.Color.Red;
            this.chkNh_Cuoi.Location = new System.Drawing.Point(154, 92);
            this.chkNh_Cuoi.Name = "chkNh_Cuoi";
            this.chkNh_Cuoi.Size = new System.Drawing.Size(90, 17);
            this.chkNh_Cuoi.TabIndex = 4;
            this.chkNh_Cuoi.Text = "Là nhóm cuối";
            this.chkNh_Cuoi.UseVisualStyleBackColor = true;
            // 
            // txtTen_Nh_CC
            // 
            this.txtTen_Nh_CC.AutoDropDown = null;
            this.txtTen_Nh_CC.Location = new System.Drawing.Point(154, 41);
            this.txtTen_Nh_CC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Nh_CC.MaxLength = 100;
            this.txtTen_Nh_CC.Name = "txtTen_Nh_CC";
            this.txtTen_Nh_CC.Size = new System.Drawing.Size(375, 20);
            this.txtTen_Nh_CC.TabIndex = 1;
            // 
            // txtMa_Nh_CC
            // 
            this.txtMa_Nh_CC.AutoDropDown = null;
            this.txtMa_Nh_CC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_CC.Location = new System.Drawing.Point(154, 19);
            this.txtMa_Nh_CC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_CC.MaxLength = 20;
            this.txtMa_Nh_CC.Name = "txtMa_Nh_CC";
            this.txtMa_Nh_CC.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_CC.TabIndex = 0;
            // 
            // txtMa_Nh_CC_Parent
            // 
            this.txtMa_Nh_CC_Parent.AutoDropDown = null;
            this.txtMa_Nh_CC_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_CC_Parent.ForeColor = System.Drawing.Color.Red;
            this.txtMa_Nh_CC_Parent.Location = new System.Drawing.Point(154, 64);
            this.txtMa_Nh_CC_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_CC_Parent.Name = "txtMa_Nh_CC_Parent";
            this.txtMa_Nh_CC_Parent.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_CC_Parent.TabIndex = 2;
            // 
            // lbtTen_Nh_Tb
            // 
            this.lbtTen_Nh_Tb.AutoEllipsis = true;
            this.lbtTen_Nh_Tb.AutoSize = true;
            this.lbtTen_Nh_Tb.ForeColor = System.Drawing.Color.Red;
            this.lbtTen_Nh_Tb.Location = new System.Drawing.Point(280, 67);
            this.lbtTen_Nh_Tb.Name = "lbtTen_Nh_Tb";
            this.lbtTen_Nh_Tb.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_Nh_Tb.TabIndex = 136;
            this.lbtTen_Nh_Tb.Text = "Tên nhóm ";
            this.lbtTen_Nh_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Nh_Vt
            // 
            this.lbMa_Nh_Vt.AutoEllipsis = true;
            this.lbMa_Nh_Vt.AutoSize = true;
            this.lbMa_Nh_Vt.ForeColor = System.Drawing.Color.Red;
            this.lbMa_Nh_Vt.Location = new System.Drawing.Point(35, 67);
            this.lbMa_Nh_Vt.Name = "lbMa_Nh_Vt";
            this.lbMa_Nh_Vt.Size = new System.Drawing.Size(106, 13);
            this.lbMa_Nh_Vt.TabIndex = 133;
            this.lbMa_Nh_Vt.Tag = "";
            this.lbMa_Nh_Vt.Text = "Nhóm CC-KQKD cha";
            this.lbMa_Nh_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTen_Vt
            // 
            this.lbTen_Vt.AutoEllipsis = true;
            this.lbTen_Vt.AutoSize = true;
            this.lbTen_Vt.Location = new System.Drawing.Point(35, 44);
            this.lbTen_Vt.Name = "lbTen_Vt";
            this.lbTen_Vt.Size = new System.Drawing.Size(105, 13);
            this.lbTen_Vt.TabIndex = 135;
            this.lbTen_Vt.Tag = "";
            this.lbTen_Vt.Text = "Tên nhóm CC-KQKD";
            this.lbTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(35, 21);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(101, 13);
            this.lbMa_Vt.TabIndex = 134;
            this.lbMa_Vt.Tag = "";
            this.lbMa_Vt.Text = "Mã nhóm CC-KQKD";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Page2
            // 
            this.Page2.Controls.Add(this.lblMa_Data);
            this.Page2.Controls.Add(this.lblNgay_End);
            this.Page2.Controls.Add(this.lblNgay_Begin);
            this.Page2.Controls.Add(this.ucMa_Data);
            this.Page2.Controls.Add(this.txtNgay_End);
            this.Page2.Controls.Add(this.txtNgay_Begin);
            this.Page2.Location = new System.Drawing.Point(4, 22);
            this.Page2.Name = "Page2";
            this.Page2.Size = new System.Drawing.Size(570, 487);
            this.Page2.TabIndex = 5;
            this.Page2.Tag = "Extra_Detail_Info";
            this.Page2.Text = "Thông tin thêm";
            this.Page2.UseVisualStyleBackColor = true;
            // 
            // lblMa_Data
            // 
            this.lblMa_Data.AutoEllipsis = true;
            this.lblMa_Data.AutoSize = true;
            this.lblMa_Data.Location = new System.Drawing.Point(22, 71);
            this.lblMa_Data.Name = "lblMa_Data";
            this.lblMa_Data.Size = new System.Drawing.Size(56, 13);
            this.lblMa_Data.TabIndex = 3;
            this.lblMa_Data.Tag = "Ma_Data";
            this.lblMa_Data.Text = "Mã dữ liệu";
            this.lblMa_Data.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_End
            // 
            this.lblNgay_End.AutoEllipsis = true;
            this.lblNgay_End.AutoSize = true;
            this.lblNgay_End.Location = new System.Drawing.Point(22, 47);
            this.lblNgay_End.Name = "lblNgay_End";
            this.lblNgay_End.Size = new System.Drawing.Size(74, 13);
            this.lblNgay_End.TabIndex = 3;
            this.lblNgay_End.Tag = "Ngay_End";
            this.lblNgay_End.Text = "Ngày kết thúc";
            this.lblNgay_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Begin
            // 
            this.lblNgay_Begin.AutoEllipsis = true;
            this.lblNgay_Begin.AutoSize = true;
            this.lblNgay_Begin.Location = new System.Drawing.Point(22, 23);
            this.lblNgay_Begin.Name = "lblNgay_Begin";
            this.lblNgay_Begin.Size = new System.Drawing.Size(72, 13);
            this.lblNgay_Begin.TabIndex = 3;
            this.lblNgay_Begin.Tag = "Ngay_Begin";
            this.lblNgay_Begin.Text = "Ngày bắt đầu";
            this.lblNgay_Begin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucMa_Data
            // 
            this.ucMa_Data.Location = new System.Drawing.Point(116, 67);
            this.ucMa_Data.Name = "ucMa_Data";
            this.ucMa_Data.Size = new System.Drawing.Size(359, 24);
            this.ucMa_Data.TabIndex = 2;
            // 
            // txtNgay_End
            // 
            this.txtNgay_End.bAllowEmpty = true;
            this.txtNgay_End.bSelectOnFocus = false;
            this.txtNgay_End.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_End.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_End.Location = new System.Drawing.Point(116, 44);
            this.txtNgay_End.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_End.Mask = "00/00/0000";
            this.txtNgay_End.Name = "txtNgay_End";
            this.txtNgay_End.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_End.TabIndex = 1;
            // 
            // txtNgay_Begin
            // 
            this.txtNgay_Begin.bAllowEmpty = true;
            this.txtNgay_Begin.bSelectOnFocus = false;
            this.txtNgay_Begin.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Begin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Begin.Location = new System.Drawing.Point(116, 20);
            this.txtNgay_Begin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Begin.Mask = "00/00/0000";
            this.txtNgay_Begin.Name = "txtNgay_Begin";
            this.txtNgay_Begin.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Begin.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(7, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lblLog
            // 
            this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLog.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.Blue;
            this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLog.Location = new System.Drawing.Point(43, 186);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(346, 22);
            this.lblLog.TabIndex = 11;
            this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(384, 166);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 1;
            // 
            // frmDmNhCCKQKD_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 217);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.tabEdit);
            this.Name = "frmDmNhCCKQKD_Edit";
            this.Object_ID = "DMNHCCKQKD";
            this.Tag = "";
            this.Text = "frmDmNhCCKQKD_Edit";
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

        public RosySystem.Control.rsTabControl tabEdit;
        public System.Windows.Forms.TabPage Page1;
        public System.Windows.Forms.TabPage Page2;
        public RosySystem.Control.rsLabel lblMa_Data;
        public RosySystem.Control.rsLabel lblNgay_End;
        public RosySystem.Control.rsLabel lblNgay_Begin;
        public RosySystem.Customize.ucMa_Data ucMa_Data;
        public RosySystem.Customize.txtNgay_End txtNgay_End;
        public RosySystem.Customize.txtNgay_Begin txtNgay_Begin;
        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Label lblLog;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtTen_Nh_CC;
        private RosySystem.Control.rsTextBox txtMa_Nh_CC;
        private RosySystem.Control.rsTextBox txtMa_Nh_CC_Parent;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        private RosySystem.Control.rsLabel lbMa_Nh_Vt;
        private RosySystem.Control.rsLabel lbTen_Vt;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsCheckbox chkNh_Cuoi;

    }
}