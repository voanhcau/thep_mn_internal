namespace RosyModule.Salary
{
	partial class frmChamCong_Edit
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
			this.lblMa_Dt_Cbnv = new RosySystem.Control.rsLabel();
			this.txtMa_So = new RosySystem.Control.rsTextBox();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.lblNgay_Gio = new RosySystem.Control.rsLabel();
			this.lblTimeType = new RosySystem.Control.rsLabel();
			this.txtMa_Data = new RosySystem.Control.rsTextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblLog = new System.Windows.Forms.Label();
			this.dteNgay_Cham_Cong = new RosySystem.Control.rsDateTime();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtPhu_Troi = new RosySystem.Control.rsTextBoxEnum();
			this.lblMa_Tte = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.dteGio_Cham_Cong = new RosyModule.txtTime();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblMa_Dt_Cbnv
			// 
			this.lblMa_Dt_Cbnv.AutoEllipsis = true;
			this.lblMa_Dt_Cbnv.AutoSize = true;
			this.lblMa_Dt_Cbnv.Location = new System.Drawing.Point(43, 45);
			this.lblMa_Dt_Cbnv.Name = "lblMa_Dt_Cbnv";
			this.lblMa_Dt_Cbnv.Size = new System.Drawing.Size(78, 13);
			this.lblMa_Dt_Cbnv.TabIndex = 130;
			this.lblMa_Dt_Cbnv.Text = "Mã chấm công";
			this.lblMa_Dt_Cbnv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_So
			// 
			this.txtMa_So.Location = new System.Drawing.Point(150, 38);
			this.txtMa_So.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_So.Name = "txtMa_So";
			this.txtMa_So.Size = new System.Drawing.Size(68, 20);
			this.txtMa_So.TabIndex = 2;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(346, 119);
			this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(180, 43);
			this.btgAccept.TabIndex = 6;
			// 
			// lblNgay_Gio
			// 
			this.lblNgay_Gio.AutoEllipsis = true;
			this.lblNgay_Gio.AutoSize = true;
			this.lblNgay_Gio.Location = new System.Drawing.Point(44, 24);
			this.lblNgay_Gio.Name = "lblNgay_Gio";
			this.lblNgay_Gio.Size = new System.Drawing.Size(49, 13);
			this.lblNgay_Gio.TabIndex = 138;
			this.lblNgay_Gio.Tag = "Ngay_Gio";
			this.lblNgay_Gio.Text = "Ngày giờ";
			this.lblNgay_Gio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTimeType
			// 
			this.lblTimeType.AutoEllipsis = true;
			this.lblTimeType.AutoSize = true;
			this.lblTimeType.Location = new System.Drawing.Point(45, 65);
			this.lblTimeType.Name = "lblTimeType";
			this.lblTimeType.Size = new System.Drawing.Size(79, 13);
			this.lblTimeType.TabIndex = 141;
			this.lblTimeType.Tag = "";
			this.lblTimeType.Text = "Giờ chấm công";
			this.lblTimeType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Data
			// 
			this.txtMa_Data.Location = new System.Drawing.Point(150, 83);
			this.txtMa_Data.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Data.Name = "txtMa_Data";
			this.txtMa_Data.ReadOnly = true;
			this.txtMa_Data.Size = new System.Drawing.Size(68, 20);
			this.txtMa_Data.TabIndex = 4;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(12, 132);
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
			this.lblLog.Location = new System.Drawing.Point(48, 132);
			this.lblLog.Name = "lblLog";
			this.lblLog.Size = new System.Drawing.Size(290, 30);
			this.lblLog.TabIndex = 142;
			this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
			this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Cham_Cong
			// 
			this.dteNgay_Cham_Cong.bAllowEmpty = true;
			this.dteNgay_Cham_Cong.bSelectOnFocus = false;
			this.dteNgay_Cham_Cong.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Cham_Cong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Cham_Cong.Location = new System.Drawing.Point(150, 17);
			this.dteNgay_Cham_Cong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Cham_Cong.Mask = "00/00/0000";
			this.dteNgay_Cham_Cong.Name = "dteNgay_Cham_Cong";
			this.dteNgay_Cham_Cong.Size = new System.Drawing.Size(68, 20);
			this.dteNgay_Cham_Cong.TabIndex = 1;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(44, 87);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(60, 13);
			this.rsLabel1.TabIndex = 146;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Mã công ty";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPhu_Troi
			// 
			this.txtPhu_Troi.InputMask = "0,1";
			this.txtPhu_Troi.Location = new System.Drawing.Point(150, 105);
			this.txtPhu_Troi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtPhu_Troi.Name = "txtPhu_Troi";
			this.txtPhu_Troi.Size = new System.Drawing.Size(29, 20);
			this.txtPhu_Troi.TabIndex = 148;
			this.txtPhu_Troi.Text = "0";
			// 
			// lblMa_Tte
			// 
			this.lblMa_Tte.AutoEllipsis = true;
			this.lblMa_Tte.AutoSize = true;
			this.lblMa_Tte.Location = new System.Drawing.Point(43, 106);
			this.lblMa_Tte.Name = "lblMa_Tte";
			this.lblMa_Tte.Size = new System.Drawing.Size(107, 13);
			this.lblMa_Tte.TabIndex = 147;
			this.lblMa_Tte.Tag = "";
			this.lblMa_Tte.Text = "Có tính công phụ trội";
			this.lblMa_Tte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.ForeColor = System.Drawing.Color.Blue;
			this.rsLabel2.Location = new System.Drawing.Point(184, 108);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(184, 13);
			this.rsLabel2.TabIndex = 149;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "0 - Không tính, 1 - Tính công phụ trội";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteGio_Cham_Cong
			// 
			this.dteGio_Cham_Cong.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
			this.dteGio_Cham_Cong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteGio_Cham_Cong.Location = new System.Drawing.Point(150, 61);
			this.dteGio_Cham_Cong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteGio_Cham_Cong.Mask = "00:00:00";
			this.dteGio_Cham_Cong.Name = "dteGio_Cham_Cong";
			this.dteGio_Cham_Cong.SelectOnFocus = false;
			this.dteGio_Cham_Cong.Size = new System.Drawing.Size(52, 20);
			this.dteGio_Cham_Cong.TabIndex = 3;
			// 
			// frmChamCong_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 173);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.txtPhu_Troi);
			this.Controls.Add(this.lblMa_Tte);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.dteNgay_Cham_Cong);
			this.Controls.Add(this.dteGio_Cham_Cong);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblLog);
			this.Controls.Add(this.lblTimeType);
			this.Controls.Add(this.txtMa_Data);
			this.Controls.Add(this.lblNgay_Gio);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.lblMa_Dt_Cbnv);
			this.Controls.Add(this.txtMa_So);
			this.Name = "frmChamCong_Edit";
			this.Text = "ChamCong_Edit";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsLabel lblMa_Dt_Cbnv;
		private RosySystem.Control.rsTextBox txtMa_So;
		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel lblNgay_Gio;
		private RosySystem.Control.rsLabel lblTimeType;
		private RosySystem.Control.rsTextBox txtMa_Data;
		protected System.Windows.Forms.PictureBox pictureBox1;
		protected System.Windows.Forms.Label lblLog;
		private txtTime dteGio_Cham_Cong;
		private RosySystem.Control.rsDateTime dteNgay_Cham_Cong;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxEnum txtPhu_Troi;
		private RosySystem.Control.rsLabel lblMa_Tte;
		private RosySystem.Control.rsLabel rsLabel2;
	}
}