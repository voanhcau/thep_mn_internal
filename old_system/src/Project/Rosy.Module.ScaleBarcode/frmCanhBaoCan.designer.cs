namespace RosyModule.ScaleBarcode
{
    partial class frmCanhBaoCan
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
            this.txtGhi_Chu_CBCan = new RosySystem.Control.rsTextBox();
            this.lbNum_Lot = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(436, 314);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(272, 69);
            this.btgAccept.TabIndex = 22;
            // 
            // txtGhi_Chu_CBCan
            // 
            this.txtGhi_Chu_CBCan.AutoDropDown = null;
            this.txtGhi_Chu_CBCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhi_Chu_CBCan.Location = new System.Drawing.Point(121, 9);
            this.txtGhi_Chu_CBCan.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtGhi_Chu_CBCan.MaxLength = 200;
            this.txtGhi_Chu_CBCan.Multiline = true;
            this.txtGhi_Chu_CBCan.Name = "txtGhi_Chu_CBCan";
            this.txtGhi_Chu_CBCan.Size = new System.Drawing.Size(587, 261);
            this.txtGhi_Chu_CBCan.TabIndex = 185;
            // 
            // lbNum_Lot
            // 
            this.lbNum_Lot.AutoEllipsis = true;
            this.lbNum_Lot.AutoSize = true;
            this.lbNum_Lot.Location = new System.Drawing.Point(13, 31);
            this.lbNum_Lot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNum_Lot.Name = "lbNum_Lot";
            this.lbNum_Lot.Size = new System.Drawing.Size(89, 20);
            this.lbNum_Lot.TabIndex = 180;
            this.lbNum_Lot.Tag = "";
            this.lbNum_Lot.Text = "Ghi chú lưu";
            this.lbNum_Lot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(13, 61);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(101, 20);
            this.rsLabel1.TabIndex = 186;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Người đồng ý";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCanhBaoCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 375);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtGhi_Chu_CBCan);
            this.Controls.Add(this.lbNum_Lot);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(739, 431);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(739, 431);
            this.Name = "frmCanhBaoCan";
            this.Text = "frmCanhBaoCan";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtGhi_Chu_CBCan;
        private RosySystem.Control.rsLabel lbNum_Lot;
        private RosySystem.Control.rsLabel rsLabel1;
	}
}