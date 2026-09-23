namespace RosyModule.Machinery
{
    partial class frmPTKT_BBHH
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
            this.lbtTen_Vt_Tb_Kt = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.numSo_Luong = new RosySystem.Control.rsTextBoxNumber();
            this.lbtTen_Vt_Tb = new RosySystem.Control.rsLabel();
            this.txtMa_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // lblLog
            // 
            this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLog.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.Blue;
            this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLog.Location = new System.Drawing.Point(12, 194);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(369, 22);
            this.lblLog.TabIndex = 14;
            this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(388, 175);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 8;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(138, 44);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 1;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(34, 46);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(50, 13);
            this.lbMa_Vt.TabIndex = 136;
            this.lbMa_Vt.Tag = "";
            this.lbMa_Vt.Text = "Phụ tùng";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt_Tb_Kt
            // 
            this.lbtTen_Vt_Tb_Kt.AutoEllipsis = true;
            this.lbtTen_Vt_Tb_Kt.AutoSize = true;
            this.lbtTen_Vt_Tb_Kt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Tb_Kt.Location = new System.Drawing.Point(263, 46);
            this.lbtTen_Vt_Tb_Kt.Name = "lbtTen_Vt_Tb_Kt";
            this.lbtTen_Vt_Tb_Kt.Size = new System.Drawing.Size(71, 13);
            this.lbtTen_Vt_Tb_Kt.TabIndex = 137;
            this.lbtTen_Vt_Tb_Kt.Text = "Tên phụ tùng";
            this.lbtTen_Vt_Tb_Kt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(34, 111);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(49, 13);
            this.rsLabel2.TabIndex = 138;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Số lượng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.AutoDropDown = null;
            this.numSo_Luong.bFormat = true;
            this.numSo_Luong.Location = new System.Drawing.Point(138, 108);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Scale = 2;
            this.numSo_Luong.Size = new System.Drawing.Size(74, 20);
            this.numSo_Luong.TabIndex = 2;
            this.numSo_Luong.Text = "0.00";
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong.Value = 0D;
            // 
            // lbtTen_Vt_Tb
            // 
            this.lbtTen_Vt_Tb.AutoEllipsis = true;
            this.lbtTen_Vt_Tb.AutoSize = true;
            this.lbtTen_Vt_Tb.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Tb.Location = new System.Drawing.Point(263, 24);
            this.lbtTen_Vt_Tb.Name = "lbtTen_Vt_Tb";
            this.lbtTen_Vt_Tb.Size = new System.Drawing.Size(60, 13);
            this.lbtTen_Vt_Tb.TabIndex = 141;
            this.lbtTen_Vt_Tb.Text = "Tên thiết bị";
            this.lbtTen_Vt_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Tb
            // 
            this.txtMa_Tb.AutoDropDown = null;
            this.txtMa_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb.Enabled = false;
            this.txtMa_Tb.Location = new System.Drawing.Point(138, 20);
            this.txtMa_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb.MaxLength = 20;
            this.txtMa_Tb.Name = "txtMa_Tb";
            this.txtMa_Tb.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Tb.TabIndex = 0;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(34, 24);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(56, 13);
            this.rsLabel3.TabIndex = 140;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Mã thiết bị";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(138, 130);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.MaxLength = 200;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(383, 20);
            this.txtGhi_Chu.TabIndex = 3;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(34, 134);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(44, 13);
            this.rsLabel1.TabIndex = 143;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Ghi chú";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPTKT_BBHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 230);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Vt_Tb);
            this.Controls.Add(this.txtMa_Tb);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.numSo_Luong);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.lbtTen_Vt_Tb_Kt);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.lbMa_Vt);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmPTKT_BBHH";
            this.Tag = "";
            this.Text = "frmVTVT_BBHH_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblLog;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtMa_Vt;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsLabel lbtTen_Vt_Tb_Kt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong;
        private RosySystem.Control.rsLabel lbtTen_Vt_Tb;
        private RosySystem.Control.rsTextBox txtMa_Tb;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel rsLabel1;
    }
}