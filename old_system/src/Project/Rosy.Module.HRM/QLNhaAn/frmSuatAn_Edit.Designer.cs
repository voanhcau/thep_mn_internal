namespace RosyModule.HRM
{
    partial class frmSuatAn_Edit
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
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.numSo_Suat_An_S = new RosySystem.Control.rsTextBoxNumber();
            this.numSo_Suat_An_T = new RosySystem.Control.rsTextBoxNumber();
            this.numSo_Suat_An_C = new RosySystem.Control.rsTextBoxNumber();
            this.numSo_Suat_An_K = new RosySystem.Control.rsTextBoxNumber();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(216, 177);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(269, 68);
            this.btgAccept.TabIndex = 5;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(15, 84);
            this.rsLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(117, 20);
            this.rsLabel9.TabIndex = 121;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Số xuất ăn trưa";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(15, 54);
            this.rsLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(124, 20);
            this.rsLabel7.TabIndex = 121;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Số xuất ăn sáng";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.rsLabel2.Location = new System.Drawing.Point(15, 115);
            this.rsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(127, 20);
            this.rsLabel2.TabIndex = 124;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Số xuất ăn chiều";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(15, 144);
            this.rsLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(131, 20);
            this.rsLabel3.TabIndex = 125;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Số xuất ăn khuya";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Suat_An_S
            // 
            this.numSo_Suat_An_S.AutoDropDown = null;
            this.numSo_Suat_An_S.bFormat = true;
            this.numSo_Suat_An_S.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSo_Suat_An_S.Location = new System.Drawing.Point(161, 51);
            this.numSo_Suat_An_S.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.numSo_Suat_An_S.Name = "numSo_Suat_An_S";
            this.numSo_Suat_An_S.Scale = 0;
            this.numSo_Suat_An_S.Size = new System.Drawing.Size(121, 25);
            this.numSo_Suat_An_S.TabIndex = 1;
            this.numSo_Suat_An_S.Tag = "";
            this.numSo_Suat_An_S.Text = "0";
            this.numSo_Suat_An_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Suat_An_S.Value = 0D;
            // 
            // numSo_Suat_An_T
            // 
            this.numSo_Suat_An_T.AutoDropDown = null;
            this.numSo_Suat_An_T.bFormat = true;
            this.numSo_Suat_An_T.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSo_Suat_An_T.Location = new System.Drawing.Point(161, 81);
            this.numSo_Suat_An_T.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.numSo_Suat_An_T.Name = "numSo_Suat_An_T";
            this.numSo_Suat_An_T.Scale = 0;
            this.numSo_Suat_An_T.Size = new System.Drawing.Size(121, 25);
            this.numSo_Suat_An_T.TabIndex = 2;
            this.numSo_Suat_An_T.Tag = "";
            this.numSo_Suat_An_T.Text = "0";
            this.numSo_Suat_An_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Suat_An_T.Value = 0D;
            // 
            // numSo_Suat_An_C
            // 
            this.numSo_Suat_An_C.AutoDropDown = null;
            this.numSo_Suat_An_C.bFormat = true;
            this.numSo_Suat_An_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSo_Suat_An_C.Location = new System.Drawing.Point(161, 110);
            this.numSo_Suat_An_C.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.numSo_Suat_An_C.Name = "numSo_Suat_An_C";
            this.numSo_Suat_An_C.Scale = 0;
            this.numSo_Suat_An_C.Size = new System.Drawing.Size(121, 25);
            this.numSo_Suat_An_C.TabIndex = 3;
            this.numSo_Suat_An_C.Tag = "";
            this.numSo_Suat_An_C.Text = "0";
            this.numSo_Suat_An_C.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Suat_An_C.Value = 0D;
            // 
            // numSo_Suat_An_K
            // 
            this.numSo_Suat_An_K.AutoDropDown = null;
            this.numSo_Suat_An_K.bFormat = true;
            this.numSo_Suat_An_K.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSo_Suat_An_K.Location = new System.Drawing.Point(161, 140);
            this.numSo_Suat_An_K.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.numSo_Suat_An_K.Name = "numSo_Suat_An_K";
            this.numSo_Suat_An_K.Scale = 0;
            this.numSo_Suat_An_K.Size = new System.Drawing.Size(121, 25);
            this.numSo_Suat_An_K.TabIndex = 4;
            this.numSo_Suat_An_K.Tag = "";
            this.numSo_Suat_An_K.Text = "0";
            this.numSo_Suat_An_K.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Suat_An_K.Value = 0D;
            // 
            // frmSuatAn_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 251);
            this.Controls.Add(this.numSo_Suat_An_K);
            this.Controls.Add(this.numSo_Suat_An_C);
            this.Controls.Add(this.numSo_Suat_An_T);
            this.Controls.Add(this.numSo_Suat_An_S);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.dteNgay_Ct);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel9);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "frmSuatAn_Edit";
            this.Text = "frmXuatAn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsLabel rsLabel1;
        //private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBoxNumber numSo_Suat_An_S;
        private RosySystem.Control.rsTextBoxNumber numSo_Suat_An_T;
        private RosySystem.Control.rsTextBoxNumber numSo_Suat_An_C;
        private RosySystem.Control.rsTextBoxNumber numSo_Suat_An_K;

	}
}