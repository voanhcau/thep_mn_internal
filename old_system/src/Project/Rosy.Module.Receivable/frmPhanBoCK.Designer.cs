namespace RosyModule.Receivable
{
    partial class frmPhanBoCK
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
            base.Dispose(disposing) ;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLoai_Pb = new RosySystem.Control.rsLabel();
            this.txtLoai_Pb = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.numTTien4 = new RosySystem.Control.rsTextBoxNumber();
            this.lblTTien4 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // lblLoai_Pb
            // 
            this.lblLoai_Pb.AutoEllipsis = true;
            this.lblLoai_Pb.AutoSize = true;
            this.lblLoai_Pb.Location = new System.Drawing.Point(21, 53);
            this.lblLoai_Pb.Name = "lblLoai_Pb";
            this.lblLoai_Pb.Size = new System.Drawing.Size(96, 13);
            this.lblLoai_Pb.TabIndex = 2;
            this.lblLoai_Pb.Text = "Phân bổ TNK theo";
            this.lblLoai_Pb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoai_Pb
            // 
            this.txtLoai_Pb.AutoDropDown = null;
            this.txtLoai_Pb.InputMask = "1,2";
            this.txtLoai_Pb.Location = new System.Drawing.Point(115, 50);
            this.txtLoai_Pb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLoai_Pb.Name = "txtLoai_Pb";
            this.txtLoai_Pb.Size = new System.Drawing.Size(27, 20);
            this.txtLoai_Pb.TabIndex = 1;
            this.txtLoai_Pb.Text = "1";
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel1.Location = new System.Drawing.Point(151, 53);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(100, 13);
            this.rsLabel1.TabIndex = 4;
            this.rsLabel1.Text = "1-Giá trị, 2-Số lượng";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(164, 93);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 2;
            // 
            // numTTien4
            // 
            this.numTTien4.AutoDropDown = null;
            this.numTTien4.bFormat = true;
            this.numTTien4.Location = new System.Drawing.Point(115, 28);
            this.numTTien4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien4.Name = "numTTien4";
            this.numTTien4.Scale = 2;
            this.numTTien4.Size = new System.Drawing.Size(118, 20);
            this.numTTien4.TabIndex = 5;
            this.numTTien4.Text = "0";
            this.numTTien4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien4.Value = 0D;
            // 
            // lblTTien4
            // 
            this.lblTTien4.AutoEllipsis = true;
            this.lblTTien4.AutoSize = true;
            this.lblTTien4.Location = new System.Drawing.Point(21, 31);
            this.lblTTien4.Name = "lblTTien4";
            this.lblTTien4.Size = new System.Drawing.Size(70, 13);
            this.lblTTien4.TabIndex = 6;
            this.lblTTien4.Text = "Tiền phân bổ";
            this.lblTTien4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPhanBoCK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 143);
            this.Controls.Add(this.numTTien4);
            this.Controls.Add(this.lblTTien4);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtLoai_Pb);
            this.Controls.Add(this.lblLoai_Pb);
            this.Name = "frmPhanBoCK";
            this.Text = "frmPhanBoCK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private RosySystem.Control.rsLabel lblLoai_Pb;
        private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Customize.btgAccept btgAccept;
        public RosySystem.Control.rsTextBoxEnum txtLoai_Pb;
        public RosySystem.Control.rsTextBoxNumber numTTien4;
        private RosySystem.Control.rsLabel lblTTien4;
    }
}