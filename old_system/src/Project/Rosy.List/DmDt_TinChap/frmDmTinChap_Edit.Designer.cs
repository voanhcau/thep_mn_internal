namespace RosyList
{
	partial class frmDmTinChap_Edit
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
			this.lbTen_Dt = new RosySystem.Control.rsLabel();
			this.lbTien = new RosySystem.Control.rsLabel();
			this.numTien_Tin_Chap = new RosySystem.Control.rsTextBoxNumber();
			this.txtMa_Dt = new RosySystem.Control.rsTextBox();
			this.lbMa_Dt = new RosySystem.Control.rsLabel();
			this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
			this.lbNgay_Ct = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblLog = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lbTen_Dt
			// 
			this.lbTen_Dt.AutoEllipsis = true;
			this.lbTen_Dt.AutoSize = true;
			this.lbTen_Dt.ForeColor = System.Drawing.Color.Blue;
			this.lbTen_Dt.Location = new System.Drawing.Point(269, 30);
			this.lbTen_Dt.Name = "lbTen_Dt";
			this.lbTen_Dt.Size = new System.Drawing.Size(74, 13);
			this.lbTen_Dt.TabIndex = 1;
			this.lbTen_Dt.Text = "Tên đối tượng";
			this.lbTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbTien
			// 
			this.lbTien.AutoEllipsis = true;
			this.lbTien.AutoSize = true;
			this.lbTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTien.Location = new System.Drawing.Point(27, 76);
			this.lbTien.Name = "lbTien";
			this.lbTien.Size = new System.Drawing.Size(84, 13);
			this.lbTien.TabIndex = 56;
			this.lbTien.Tag = "Tien_Tin_Chap";
			this.lbTien.Text = "Tiền tín chấp";
			this.lbTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTien_Tin_Chap
			// 
			this.numTien_Tin_Chap.AutoDropDown = null;
			this.numTien_Tin_Chap.bFormat = true;
			this.numTien_Tin_Chap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTien_Tin_Chap.Location = new System.Drawing.Point(143, 70);
			this.numTien_Tin_Chap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTien_Tin_Chap.Name = "numTien_Tin_Chap";
			this.numTien_Tin_Chap.Scale = 0;
			this.numTien_Tin_Chap.Size = new System.Drawing.Size(120, 20);
			this.numTien_Tin_Chap.TabIndex = 3;
			this.numTien_Tin_Chap.Text = "0";
			this.numTien_Tin_Chap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTien_Tin_Chap.Value = 0D;
			// 
			// txtMa_Dt
			// 
			this.txtMa_Dt.AutoDropDown = null;
			this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Dt.Location = new System.Drawing.Point(143, 26);
			this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Dt.MaxLength = 20;
			this.txtMa_Dt.Name = "txtMa_Dt";
			this.txtMa_Dt.ReadOnly = true;
			this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Dt.TabIndex = 0;
			// 
			// lbMa_Dt
			// 
			this.lbMa_Dt.AutoEllipsis = true;
			this.lbMa_Dt.AutoSize = true;
			this.lbMa_Dt.Location = new System.Drawing.Point(27, 30);
			this.lbMa_Dt.Name = "lbMa_Dt";
			this.lbMa_Dt.Size = new System.Drawing.Size(70, 13);
			this.lbMa_Dt.TabIndex = 53;
			this.lbMa_Dt.Tag = "Ma_Dt";
			this.lbMa_Dt.Text = "Mã đối tượng";
			this.lbMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Ap
			// 
			this.dteNgay_Ap.bAllowEmpty = true;
			this.dteNgay_Ap.bSelectOnFocus = false;
			this.dteNgay_Ap.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ap.Location = new System.Drawing.Point(143, 48);
			this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ap.Mask = "00/00/0000";
			this.dteNgay_Ap.Name = "dteNgay_Ap";
			this.dteNgay_Ap.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ap.TabIndex = 2;
			// 
			// lbNgay_Ct
			// 
			this.lbNgay_Ct.AutoEllipsis = true;
			this.lbNgay_Ct.AutoSize = true;
			this.lbNgay_Ct.Location = new System.Drawing.Point(27, 51);
			this.lbNgay_Ct.Name = "lbNgay_Ct";
			this.lbNgay_Ct.Size = new System.Drawing.Size(47, 13);
			this.lbNgay_Ct.TabIndex = 52;
			this.lbNgay_Ct.Tag = "Ngay_Ap";
			this.lbNgay_Ct.Text = "Ngày áp";
			this.lbNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(358, 115);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(184, 43);
			this.btgAccept.TabIndex = 10;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::RosyList.Properties.Resources.Log;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(25, 123);
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
			this.lblLog.Location = new System.Drawing.Point(61, 132);
			this.lblLog.Name = "lblLog";
			this.lblLog.Size = new System.Drawing.Size(290, 22);
			this.lblLog.TabIndex = 59;
			this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
			this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmTinChap_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 166);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblLog);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.lbTen_Dt);
			this.Controls.Add(this.lbTien);
			this.Controls.Add(this.numTien_Tin_Chap);
			this.Controls.Add(this.txtMa_Dt);
			this.Controls.Add(this.lbMa_Dt);
			this.Controls.Add(this.dteNgay_Ap);
			this.Controls.Add(this.lbNgay_Ct);
			this.Name = "frmDmTinChap_Edit";
			this.Object_ID = "DMTINCHAP";
			this.Tag = "frmDmPLHd, ESC";
			this.Text = "frmDmTinChap";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsLabel lbTen_Dt;
		private RosySystem.Control.rsLabel lbTien;
		private RosySystem.Control.rsTextBoxNumber numTien_Tin_Chap;
		private RosySystem.Control.rsTextBox txtMa_Dt;
		private RosySystem.Control.rsLabel lbMa_Dt;
		private RosySystem.Control.rsDateTime dteNgay_Ap;
		private RosySystem.Control.rsLabel lbNgay_Ct;
		private RosySystem.Customize.btgAccept btgAccept;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblLog;


	}
}