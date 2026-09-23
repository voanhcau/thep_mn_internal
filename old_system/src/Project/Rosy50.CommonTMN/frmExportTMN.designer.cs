namespace RosyCommonTMN
{
    partial class frmExportTMN
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
            this.label1 = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.txtPath = new RosySystem.Control.rsTextBox();
            this.label2 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.chkOpenFile = new RosySystem.Control.rsCheckbox();
            this.chkExport_Formular = new RosySystem.Control.rsCheckbox();
            this.btPath = new System.Windows.Forms.Button();
            this.enuFormatFont = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.cboExportType_Bk = new RosySystem.Control.rsMultiComboBox();
            this.cboExportType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 15;
            this.label1.Tag = "";
            this.label1.Text = "Định dạng font chữ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(270, 137);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 16;
            // 
            // txtPath
            // 
            this.txtPath.AutoDropDown = null;
            this.txtPath.Location = new System.Drawing.Point(129, 41);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(313, 20);
            this.txtPath.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 20;
            this.label2.Tag = "";
            this.label2.Text = "Đường dẫn tập tin";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(12, 21);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(97, 13);
            this.rsLabel1.TabIndex = 20;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Định dạng kết xuất";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkOpenFile
            // 
            this.chkOpenFile.AutoSize = true;
            this.chkOpenFile.Checked = true;
            this.chkOpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenFile.Location = new System.Drawing.Point(129, 88);
            this.chkOpenFile.Name = "chkOpenFile";
            this.chkOpenFile.Size = new System.Drawing.Size(135, 17);
            this.chkOpenFile.TabIndex = 21;
            this.chkOpenFile.Tag = "";
            this.chkOpenFile.Text = "Mở file sau khi kết xuất";
            this.chkOpenFile.UseVisualStyleBackColor = true;
            // 
            // chkExport_Formular
            // 
            this.chkExport_Formular.AutoSize = true;
            this.chkExport_Formular.Location = new System.Drawing.Point(129, 111);
            this.chkExport_Formular.Name = "chkExport_Formular";
            this.chkExport_Formular.Size = new System.Drawing.Size(140, 17);
            this.chkExport_Formular.TabIndex = 22;
            this.chkExport_Formular.Tag = "";
            this.chkExport_Formular.Text = "Kết xuất theo công thức";
            this.chkExport_Formular.UseVisualStyleBackColor = true;
            // 
            // btPath
            // 
            this.btPath.Location = new System.Drawing.Point(447, 41);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(41, 22);
            this.btPath.TabIndex = 23;
            this.btPath.Text = "...";
            this.btPath.UseVisualStyleBackColor = true;
            // 
            // enuFormatFont
            // 
            this.enuFormatFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.enuFormatFont.AutoDropDown = null;
            this.enuFormatFont.InputMask = "U,V,T";
            this.enuFormatFont.Location = new System.Drawing.Point(129, 63);
            this.enuFormatFont.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.enuFormatFont.Name = "enuFormatFont";
            this.enuFormatFont.Size = new System.Drawing.Size(29, 20);
            this.enuFormatFont.TabIndex = 24;
            this.enuFormatFont.Text = "U";
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(166, 66);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(152, 13);
            this.rsLabel2.TabIndex = 15;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "U - Unicode, V - Vni, T - TCVN";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboExportType_Bk
            // 
            this.cboExportType_Bk.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboExportType_Bk.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboExportType_Bk.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboExportType_Bk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboExportType_Bk.Location = new System.Drawing.Point(279, 107);
            this.cboExportType_Bk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboExportType_Bk.MaxLength = 20;
            this.cboExportType_Bk.Name = "cboExportType_Bk";
            this.cboExportType_Bk.Size = new System.Drawing.Size(206, 21);
            this.cboExportType_Bk.TabIndex = 25;
            this.cboExportType_Bk.Visible = false;
            // 
            // cboExportType
            // 
            this.cboExportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboExportType.FormattingEnabled = true;
            this.cboExportType.Location = new System.Drawing.Point(129, 17);
            this.cboExportType.Name = "cboExportType";
            this.cboExportType.Size = new System.Drawing.Size(226, 21);
            this.cboExportType.TabIndex = 26;
            // 
            // frmExportTMN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 190);
            this.Controls.Add(this.cboExportType);
            this.Controls.Add(this.cboExportType_Bk);
            this.Controls.Add(this.enuFormatFont);
            this.Controls.Add(this.btPath);
            this.Controls.Add(this.chkExport_Formular);
            this.Controls.Add(this.chkOpenFile);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.label1);
            this.Name = "frmExportTMN";
            this.Text = "frmExportTMN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsLabel label1;
        private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel label2;
        private RosySystem.Control.rsLabel rsLabel1;
        public RosySystem.Control.rsCheckbox chkOpenFile;
        public RosySystem.Control.rsCheckbox chkExport_Formular;
        private System.Windows.Forms.Button btPath;
        private RosySystem.Control.rsLabel rsLabel2;
        public RosySystem.Control.rsTextBox txtPath;
        public RosySystem.Control.rsMultiComboBox cboExportType_Bk;
        public RosySystem.Control.rsTextBoxEnum enuFormatFont;
        public System.Windows.Forms.ComboBox cboExportType;
    }
}