namespace RosyList
{
    partial class frmDmPLCTrinh_Edit
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
            this.txtTen_PLCTrinh = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.lbTen_CTrinh = new RosySystem.Control.rsLabel();
            this.txtMa_PLCTrinh = new RosySystem.Control.rsTextBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtMa_CTrinh = new RosySystem.Control.rsTextBox();
            this.lbMa_Hd = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTen_PLCTrinh
            // 
            this.txtTen_PLCTrinh.AutoDropDown = null;
            this.txtTen_PLCTrinh.Location = new System.Drawing.Point(143, 92);
            this.txtTen_PLCTrinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_PLCTrinh.MaxLength = 400;
            this.txtTen_PLCTrinh.Multiline = true;
            this.txtTen_PLCTrinh.Name = "txtTen_PLCTrinh";
            this.txtTen_PLCTrinh.Size = new System.Drawing.Size(416, 34);
            this.txtTen_PLCTrinh.TabIndex = 1;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(27, 95);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(114, 13);
            this.rsLabel2.TabIndex = 58;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Tên phụ lục công trình";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTen_CTrinh
            // 
            this.lbTen_CTrinh.AutoEllipsis = true;
            this.lbTen_CTrinh.AutoSize = true;
            this.lbTen_CTrinh.ForeColor = System.Drawing.Color.Blue;
            this.lbTen_CTrinh.Location = new System.Drawing.Point(269, 30);
            this.lbTen_CTrinh.Name = "lbTen_CTrinh";
            this.lbTen_CTrinh.Size = new System.Drawing.Size(76, 13);
            this.lbTen_CTrinh.TabIndex = 7;
            this.lbTen_CTrinh.Text = "Tên công trình";
            this.lbTen_CTrinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_PLCTrinh
            // 
            this.txtMa_PLCTrinh.AutoDropDown = null;
            this.txtMa_PLCTrinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_PLCTrinh.Location = new System.Drawing.Point(143, 70);
            this.txtMa_PLCTrinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_PLCTrinh.MaxLength = 20;
            this.txtMa_PLCTrinh.Name = "txtMa_PLCTrinh";
            this.txtMa_PLCTrinh.Size = new System.Drawing.Size(120, 20);
            this.txtMa_PLCTrinh.TabIndex = 0;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(27, 73);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(110, 13);
            this.rsLabel4.TabIndex = 54;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Mã phụ lục công trình";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_CTrinh
            // 
            this.txtMa_CTrinh.AutoDropDown = null;
            this.txtMa_CTrinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CTrinh.Location = new System.Drawing.Point(143, 26);
            this.txtMa_CTrinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CTrinh.MaxLength = 20;
            this.txtMa_CTrinh.Name = "txtMa_CTrinh";
            this.txtMa_CTrinh.ReadOnly = true;
            this.txtMa_CTrinh.Size = new System.Drawing.Size(120, 20);
            this.txtMa_CTrinh.TabIndex = 6;
            // 
            // lbMa_Hd
            // 
            this.lbMa_Hd.AutoEllipsis = true;
            this.lbMa_Hd.AutoSize = true;
            this.lbMa_Hd.Location = new System.Drawing.Point(27, 30);
            this.lbMa_Hd.Name = "lbMa_Hd";
            this.lbMa_Hd.Size = new System.Drawing.Size(71, 13);
            this.lbMa_Hd.TabIndex = 53;
            this.lbMa_Hd.Tag = "Ma_CTrinh";
            this.lbMa_Hd.Text = "Mã hợp đồng";
            this.lbMa_Hd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(360, 131);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(184, 43);
            this.btgAccept.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::RosyList.Properties.Resources.Log;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(25, 139);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // lblLog
            // 
            this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.Blue;
            this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLog.Location = new System.Drawing.Point(61, 148);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(290, 22);
            this.lblLog.TabIndex = 59;
            this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmPLCTrinh_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 182);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.txtTen_PLCTrinh);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.lbTen_CTrinh);
            this.Controls.Add(this.txtMa_PLCTrinh);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.txtMa_CTrinh);
            this.Controls.Add(this.lbMa_Hd);
            this.Name = "frmDmPLCTrinh_Edit";
            this.Object_ID = "DMPLCTRINH";
            this.Tag = "frmDmPLCTrinh, ESC";
            this.Text = "frmDmPLCTrinh";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtTen_PLCTrinh;
		private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel lbTen_CTrinh;
		private RosySystem.Control.rsTextBox txtMa_PLCTrinh;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBox txtMa_CTrinh;
        private RosySystem.Control.rsLabel lbMa_Hd;
		private RosySystem.Customize.btgAccept btgAccept;
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLog;


	}
}