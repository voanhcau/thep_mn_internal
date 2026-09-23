namespace RosyModule.Machinery
{
    partial class frmPTBTTB_Edit
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
            this.lblLog = new System.Windows.Forms.Label();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.lbMa_Vt = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.numSo_Luong = new RosySystem.Control.rsTextBoxNumber();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.numSo_Luong_Dn = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.numSo_Luong_Ld = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.numSo_Luong_TonKho = new RosySystem.Control.rsTextBoxNumber();
            this.SuspendLayout();
            // 
            // lblLog
            // 
            this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLog.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.Blue;
            this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLog.Location = new System.Drawing.Point(16, 305);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(492, 27);
            this.lblLog.TabIndex = 14;
            this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(720, 281);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(241, 53);
            this.btgAccept.TabIndex = 8;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(184, 13);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(159, 22);
            this.txtMa_Vt.TabIndex = 1;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(45, 16);
            this.lbMa_Vt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(65, 17);
            this.lbMa_Vt.TabIndex = 136;
            this.lbMa_Vt.Tag = "";
            this.lbMa_Vt.Text = "Phụ tùng";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(45, 43);
            this.lbtTen_Vt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(93, 17);
            this.lbtTen_Vt.TabIndex = 137;
            this.lbtTen_Vt.Text = "Tên phụ tùng";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(45, 211);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(122, 17);
            this.rsLabel2.TabIndex = 138;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Số lượng cần mua";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.AutoDropDown = null;
            this.numSo_Luong.bFormat = true;
            this.numSo_Luong.Location = new System.Drawing.Point(184, 207);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Scale = 2;
            this.numSo_Luong.Size = new System.Drawing.Size(97, 22);
            this.numSo_Luong.TabIndex = 5;
            this.numSo_Luong.Text = "0.00";
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong.Value = 0D;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(184, 234);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtGhi_Chu.MaxLength = 200;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(509, 22);
            this.txtGhi_Chu.TabIndex = 6;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(45, 237);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(57, 17);
            this.rsLabel1.TabIndex = 143;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Ghi chú";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(45, 187);
            this.rsLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(135, 17);
            this.rsLabel4.TabIndex = 138;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Số lượng đã đề nghị";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong_Dn
            // 
            this.numSo_Luong_Dn.AutoDropDown = null;
            this.numSo_Luong_Dn.bFormat = true;
            this.numSo_Luong_Dn.Location = new System.Drawing.Point(184, 183);
            this.numSo_Luong_Dn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numSo_Luong_Dn.Name = "numSo_Luong_Dn";
            this.numSo_Luong_Dn.Scale = 2;
            this.numSo_Luong_Dn.Size = new System.Drawing.Size(97, 22);
            this.numSo_Luong_Dn.TabIndex = 4;
            this.numSo_Luong_Dn.Text = "0.00";
            this.numSo_Luong_Dn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong_Dn.Value = 0D;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(45, 139);
            this.rsLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(111, 17);
            this.rsLabel5.TabIndex = 138;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Số lượng lắp đặt";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong_Ld
            // 
            this.numSo_Luong_Ld.AutoDropDown = null;
            this.numSo_Luong_Ld.bFormat = true;
            this.numSo_Luong_Ld.Location = new System.Drawing.Point(184, 135);
            this.numSo_Luong_Ld.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numSo_Luong_Ld.Name = "numSo_Luong_Ld";
            this.numSo_Luong_Ld.Scale = 2;
            this.numSo_Luong_Ld.Size = new System.Drawing.Size(97, 22);
            this.numSo_Luong_Ld.TabIndex = 2;
            this.numSo_Luong_Ld.Text = "0.00";
            this.numSo_Luong_Ld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong_Ld.Value = 0D;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(45, 163);
            this.rsLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(115, 17);
            this.rsLabel6.TabIndex = 138;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Số lượng tồn kho";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong_TonKho
            // 
            this.numSo_Luong_TonKho.AutoDropDown = null;
            this.numSo_Luong_TonKho.bFormat = true;
            this.numSo_Luong_TonKho.Location = new System.Drawing.Point(184, 159);
            this.numSo_Luong_TonKho.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numSo_Luong_TonKho.Name = "numSo_Luong_TonKho";
            this.numSo_Luong_TonKho.Scale = 2;
            this.numSo_Luong_TonKho.Size = new System.Drawing.Size(97, 22);
            this.numSo_Luong_TonKho.TabIndex = 3;
            this.numSo_Luong_TonKho.Text = "0.00";
            this.numSo_Luong_TonKho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong_TonKho.Value = 0D;
            // 
            // frmPTBTTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 349);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.numSo_Luong_TonKho);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.numSo_Luong_Ld);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.numSo_Luong_Dn);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.numSo_Luong);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.lbMa_Vt);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmPTBTTB";
            this.Tag = "";
            this.Text = "frmPTBTTB_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblLog;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtMa_Vt;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsLabel lbtTen_Vt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong_Dn;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong_Ld;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong_TonKho;
    }
}