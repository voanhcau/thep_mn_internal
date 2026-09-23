namespace RosyModule.Machinery
{
    partial class frmTaiLieu_Edit
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbtTen_Tb = new RosySystem.Control.rsLabel();
            this.txtMa_Tb = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtFile_Path = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.btBrowser = new RosySystem.Customize.btDelete();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 175);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 143;
            this.pictureBox1.TabStop = false;
            // 
            // lblLog
            // 
            this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLog.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.Blue;
            this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLog.Location = new System.Drawing.Point(48, 184);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(346, 22);
            this.lblLog.TabIndex = 142;
            this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(405, 165);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 4;
            // 
            // lbtTen_Tb
            // 
            this.lbtTen_Tb.AutoEllipsis = true;
            this.lbtTen_Tb.AutoSize = true;
            this.lbtTen_Tb.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tb.Location = new System.Drawing.Point(259, 33);
            this.lbtTen_Tb.Name = "lbtTen_Tb";
            this.lbtTen_Tb.Size = new System.Drawing.Size(60, 13);
            this.lbtTen_Tb.TabIndex = 146;
            this.lbtTen_Tb.Text = "Tên thiết bị";
            this.lbtTen_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Tb
            // 
            this.txtMa_Tb.AutoDropDown = null;
            this.txtMa_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb.Location = new System.Drawing.Point(134, 31);
            this.txtMa_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb.MaxLength = 20;
            this.txtMa_Tb.Name = "txtMa_Tb";
            this.txtMa_Tb.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Tb.TabIndex = 0;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(43, 33);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(56, 13);
            this.rsLabel2.TabIndex = 145;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Mã thiết bị";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFile_Path
            // 
            this.txtFile_Path.AutoDropDown = null;
            this.txtFile_Path.Location = new System.Drawing.Point(134, 53);
            this.txtFile_Path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Path.MaxLength = 100;
            this.txtFile_Path.Multiline = true;
            this.txtFile_Path.Name = "txtFile_Path";
            this.txtFile_Path.Size = new System.Drawing.Size(375, 19);
            this.txtFile_Path.TabIndex = 3;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(43, 59);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(76, 13);
            this.rsLabel3.TabIndex = 150;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Đường dẫn file";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBrowser
            // 
            this.btBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBrowser.ImageKey = "(none)";
            this.btBrowser.Location = new System.Drawing.Point(514, 53);
            this.btBrowser.Name = "btBrowser";
            this.btBrowser.Size = new System.Drawing.Size(72, 19);
            this.btBrowser.TabIndex = 151;
            this.btBrowser.Tag = "";
            this.btBrowser.Text = "&Browser";
            this.btBrowser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBrowser.UseVisualStyleBackColor = true;
            // 
            // frmTaiLieu_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 220);
            this.Controls.Add(this.btBrowser);
            this.Controls.Add(this.txtFile_Path);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.lbtTen_Tb);
            this.Controls.Add(this.txtMa_Tb);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmTaiLieu_Edit";
            this.Tag = "TAILIEUTB";
            this.Text = "frmTaiLieuTB_Edit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Label lblLog;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lbtTen_Tb;
        private RosySystem.Control.rsTextBox txtMa_Tb;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtFile_Path;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Customize.btDelete btBrowser;
    }
}