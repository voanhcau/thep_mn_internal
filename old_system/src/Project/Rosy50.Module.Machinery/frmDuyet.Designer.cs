namespace RosyModule.Machinery
{
    partial class frmDuyet
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
            this.btExit = new RosySystem.Control.rsButton();
            this.btSave = new RosySystem.Control.rsButton();
            this.dteNgay_Duyet = new RosySystem.Control.rsDateTime();
            this.lbMa_Vt = new RosySystem.Control.rsLabel();
            this.chkDuyet = new RosySystem.Control.rsCheckbox();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Location = new System.Drawing.Point(259, 133);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 25);
            this.btExit.TabIndex = 3;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Enabled = false;
            this.btSave.Location = new System.Drawing.Point(178, 133);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 25);
            this.btSave.TabIndex = 2;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Duyet
            // 
            this.dteNgay_Duyet.bAllowEmpty = true;
            this.dteNgay_Duyet.bSelectOnFocus = false;
            this.dteNgay_Duyet.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Duyet.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Duyet.Enabled = false;
            this.dteNgay_Duyet.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Duyet.Location = new System.Drawing.Point(104, 45);
            this.dteNgay_Duyet.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Duyet.Mask = "00/00/0000";
            this.dteNgay_Duyet.Name = "dteNgay_Duyet";
            this.dteNgay_Duyet.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Duyet.TabIndex = 148;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(35, 48);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(62, 14);
            this.lbMa_Vt.TabIndex = 149;
            this.lbMa_Vt.Tag = "";
            this.lbMa_Vt.Text = "Ngày duyệt";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDuyet
            // 
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Location = new System.Drawing.Point(104, 72);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(54, 18);
            this.chkDuyet.TabIndex = 150;
            this.chkDuyet.Text = "Duyệt";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // frmDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 170);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.dteNgay_Duyet);
            this.Controls.Add(this.lbMa_Vt);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Name = "frmDuyet";
            this.Text = "frmDuyet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsButton btSave;
        private RosySystem.Control.rsDateTime dteNgay_Duyet;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsCheckbox chkDuyet;
    }
}