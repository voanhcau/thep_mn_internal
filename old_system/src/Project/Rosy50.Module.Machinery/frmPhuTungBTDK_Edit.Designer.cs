namespace RosyModule.Machinery
{
    partial class frmPhuTungBTDK_Edit
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
            this.numSo_Luong_Max = new RosySystem.Control.rsTextBoxNumber();
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
            this.lblLog.Location = new System.Drawing.Point(12, 124);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(369, 22);
            this.lblLog.TabIndex = 14;
            this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(398, 105);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 8;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(91, 9);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(169, 20);
            this.txtMa_Vt.TabIndex = 1;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(36, 11);
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
            this.lbtTen_Vt_Tb_Kt.Location = new System.Drawing.Point(265, 11);
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
            this.rsLabel2.Location = new System.Drawing.Point(36, 54);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(90, 13);
            this.rsLabel2.TabIndex = 138;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Số lượng sử dụng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.AutoDropDown = null;
            this.numSo_Luong.bFormat = true;
            this.numSo_Luong.Location = new System.Drawing.Point(165, 51);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Scale = 2;
            this.numSo_Luong.Size = new System.Drawing.Size(74, 20);
            this.numSo_Luong.TabIndex = 2;
            this.numSo_Luong.Text = "0.00";
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong.Value = 0D;
            // 
            // numSo_Luong_Max
            // 
            this.numSo_Luong_Max.AutoDropDown = null;
            this.numSo_Luong_Max.bFormat = true;
            this.numSo_Luong_Max.Location = new System.Drawing.Point(165, 73);
            this.numSo_Luong_Max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Luong_Max.Name = "numSo_Luong_Max";
            this.numSo_Luong_Max.Scale = 2;
            this.numSo_Luong_Max.Size = new System.Drawing.Size(74, 20);
            this.numSo_Luong_Max.TabIndex = 3;
            this.numSo_Luong_Max.Text = "0.00";
            this.numSo_Luong_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong_Max.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(36, 76);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(127, 13);
            this.rsLabel1.TabIndex = 140;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Số lượng tối đa cần dùng";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPhuTungBTDK_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 160);
            this.Controls.Add(this.numSo_Luong_Max);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.numSo_Luong);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.lbtTen_Vt_Tb_Kt);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.lbMa_Vt);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmPhuTungBTDK_Edit";
            this.Tag = "PHUTUNGBTDK";
            this.Text = "frmPhuTungBTDK_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblLog;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsLabel lbtTen_Vt_Tb_Kt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong;
        private RosySystem.Control.rsTextBoxNumber numSo_Luong_Max;
        private RosySystem.Control.rsLabel rsLabel1;
        public RosySystem.Control.rsTextBox txtMa_Vt;
    }
}