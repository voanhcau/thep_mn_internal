namespace RosyModule.HRM
{
    partial class frmQLBDDH_Edit
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
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.dteNgay_Cap = new RosySystem.Control.rsDateTime();
            this.cboMuc_BDDH = new RosySystem.Control.rsComboBox();
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
            this.btgAccept.TabIndex = 4;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(18, 46);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(62, 13);
            this.rsLabel3.TabIndex = 119;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Mức BDDH";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(18, 68);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(47, 13);
            this.rsLabel7.TabIndex = 118;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Ngày áp";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Cap
            // 
            this.dteNgay_Cap.bAllowEmpty = true;
            this.dteNgay_Cap.bSelectOnFocus = false;
            this.dteNgay_Cap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Cap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Cap.Location = new System.Drawing.Point(127, 68);
            this.dteNgay_Cap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Cap.Mask = "00/00/0000";
            this.dteNgay_Cap.Name = "dteNgay_Cap";
            this.dteNgay_Cap.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Cap.TabIndex = 2;
            this.dteNgay_Cap.Tag = "Ngay_Ct";
            // 
            // cboMuc_BDDH
            // 
            this.cboMuc_BDDH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboMuc_BDDH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMuc_BDDH.FormattingEnabled = true;
            this.cboMuc_BDDH.Location = new System.Drawing.Point(127, 43);
            this.cboMuc_BDDH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMuc_BDDH.Name = "cboMuc_BDDH";
            this.cboMuc_BDDH.Size = new System.Drawing.Size(120, 21);
            this.cboMuc_BDDH.Sorted = true;
            this.cboMuc_BDDH.TabIndex = 123;
            // 
            // frmQLBDDH_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 213);
            this.Controls.Add(this.cboMuc_BDDH);
            this.Controls.Add(this.dteNgay_Cap);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Name = "frmQLBDDH_Edit";
            this.Text = "frmQLBDDH_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsDateTime dteNgay_Cap;
        private RosySystem.Control.rsComboBox cboMuc_BDDH;

	}
}