namespace RosyModule.Machinery
{
    partial class frmCreateBTTBDK
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
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.numNam = new RosySystem.Control.rsTextBoxNumber();
            this.txtMa_DotBT = new RosySystem.Control.rsTextBox();
            this.lbtTen_DotBT = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Location = new System.Drawing.Point(457, 211);
            this.btExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(100, 29);
            this.btExit.TabIndex = 5;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(349, 211);
            this.btSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(100, 29);
            this.btSave.TabIndex = 4;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(52, 38);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(95, 17);
            this.rsLabel1.TabIndex = 278;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mã đợt bảo trì";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(52, 62);
            this.rsLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(96, 17);
            this.rsLabel3.TabIndex = 278;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Năm chứng từ";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNam
            // 
            this.numNam.AutoDropDown = null;
            this.numNam.bFormat = true;
            this.numNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNam.Location = new System.Drawing.Point(156, 58);
            this.numNam.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.numNam.Name = "numNam";
            this.numNam.Scale = 0;
            this.numNam.Size = new System.Drawing.Size(136, 23);
            this.numNam.TabIndex = 3;
            this.numNam.Text = "0";
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam.Value = 0D;
            // 
            // txtMa_DotBT
            // 
            this.txtMa_DotBT.AutoDropDown = null;
            this.txtMa_DotBT.BackColor = System.Drawing.SystemColors.Window;
            this.txtMa_DotBT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_DotBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_DotBT.Location = new System.Drawing.Point(156, 30);
            this.txtMa_DotBT.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtMa_DotBT.MaxLength = 20;
            this.txtMa_DotBT.Name = "txtMa_DotBT";
            this.txtMa_DotBT.Size = new System.Drawing.Size(136, 27);
            this.txtMa_DotBT.TabIndex = 2;
            // 
            // lbtTen_DotBT
            // 
            this.lbtTen_DotBT.AutoEllipsis = true;
            this.lbtTen_DotBT.AutoSize = true;
            this.lbtTen_DotBT.Location = new System.Drawing.Point(299, 36);
            this.lbtTen_DotBT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtTen_DotBT.Name = "lbtTen_DotBT";
            this.lbtTen_DotBT.Size = new System.Drawing.Size(95, 17);
            this.lbtTen_DotBT.TabIndex = 278;
            this.lbtTen_DotBT.Tag = "";
            this.lbtTen_DotBT.Text = "Mã đợt bảo trì";
            this.lbtTen_DotBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCreateBTTBDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 254);
            this.Controls.Add(this.txtMa_DotBT);
            this.Controls.Add(this.numNam);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.lbtTen_DotBT);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmCreateBTTBDK";
            this.Text = "Tạo BTTB định kỳ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsButton btSave;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBoxNumber numNam;
        private RosySystem.Control.rsTextBox txtMa_DotBT;
        private RosySystem.Control.rsLabel lbtTen_DotBT;
    }
}