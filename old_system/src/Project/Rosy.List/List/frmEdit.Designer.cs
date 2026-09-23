namespace RosyList
{
	partial class frmEdit
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
			this.tabEdit = new RosySystem.Control.rsTabControl();
			this.Page1 = new System.Windows.Forms.TabPage();
			this.Page2 = new System.Windows.Forms.TabPage();
			this.lblMa_Data = new RosySystem.Control.rsLabel();
			this.lblNgay_End = new RosySystem.Control.rsLabel();
			this.lblNgay_Begin = new RosySystem.Control.rsLabel();
			this.ucMa_Data = new RosySystem.Customize.ucMa_Data();
			this.dteNgay_End = new RosySystem.Customize.txtNgay_End();
			this.dteNgay_Begin = new RosySystem.Customize.txtNgay_Begin();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblLog = new System.Windows.Forms.Label();
			this.tabEdit.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(454, 246);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 3;
			// 
			// tabEdit
			// 
			this.tabEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabEdit.Controls.Add(this.Page1);
			this.tabEdit.Controls.Add(this.Page2);
			this.tabEdit.Location = new System.Drawing.Point(12, 10);
			this.tabEdit.Name = "tabEdit";
			this.tabEdit.SelectedIndex = 0;
			this.tabEdit.Size = new System.Drawing.Size(627, 232);
			this.tabEdit.TabIndex = 2;
			// 
			// Page1
			// 
			this.Page1.Location = new System.Drawing.Point(4, 22);
			this.Page1.Name = "Page1";
			this.Page1.Padding = new System.Windows.Forms.Padding(3);
			this.Page1.Size = new System.Drawing.Size(619, 206);
			this.Page1.TabIndex = 0;
			this.Page1.Tag = "Detail_Info";
			this.Page1.Text = "Thông tin chi tiết";
			this.Page1.UseVisualStyleBackColor = true;
			// 
			// Page2
			// 
			this.Page2.Controls.Add(this.lblMa_Data);
			this.Page2.Controls.Add(this.lblNgay_End);
			this.Page2.Controls.Add(this.lblNgay_Begin);
			this.Page2.Controls.Add(this.ucMa_Data);
			this.Page2.Controls.Add(this.dteNgay_End);
			this.Page2.Controls.Add(this.dteNgay_Begin);
			this.Page2.Location = new System.Drawing.Point(4, 22);
			this.Page2.Name = "Page2";
			this.Page2.Size = new System.Drawing.Size(619, 206);
			this.Page2.TabIndex = 5;
			this.Page2.Tag = "Extra_Detail_Info";
			this.Page2.Text = "Thông tin thêm";
			this.Page2.UseVisualStyleBackColor = true;
			// 
			// lblMa_Data
			// 
			this.lblMa_Data.AutoEllipsis = true;
			this.lblMa_Data.AutoSize = true;
			this.lblMa_Data.Location = new System.Drawing.Point(22, 71);
			this.lblMa_Data.Name = "lblMa_Data";
			this.lblMa_Data.Size = new System.Drawing.Size(56, 13);
			this.lblMa_Data.TabIndex = 3;
			this.lblMa_Data.Tag = "Ma_Data";
			this.lblMa_Data.Text = "Mã dữ liệu";
			this.lblMa_Data.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblNgay_End
			// 
			this.lblNgay_End.AutoEllipsis = true;
			this.lblNgay_End.AutoSize = true;
			this.lblNgay_End.Location = new System.Drawing.Point(22, 47);
			this.lblNgay_End.Name = "lblNgay_End";
			this.lblNgay_End.Size = new System.Drawing.Size(74, 13);
			this.lblNgay_End.TabIndex = 3;
			this.lblNgay_End.Tag = "Ngay_End";
			this.lblNgay_End.Text = "Ngày kết thúc";
			this.lblNgay_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblNgay_Begin
			// 
			this.lblNgay_Begin.AutoEllipsis = true;
			this.lblNgay_Begin.AutoSize = true;
			this.lblNgay_Begin.Location = new System.Drawing.Point(22, 23);
			this.lblNgay_Begin.Name = "lblNgay_Begin";
			this.lblNgay_Begin.Size = new System.Drawing.Size(72, 13);
			this.lblNgay_Begin.TabIndex = 3;
			this.lblNgay_Begin.Tag = "Ngay_Begin";
			this.lblNgay_Begin.Text = "Ngày bắt đầu";
			this.lblNgay_Begin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ucMa_Data
			// 
			this.ucMa_Data.Location = new System.Drawing.Point(116, 67);
			this.ucMa_Data.Name = "ucMa_Data";
			this.ucMa_Data.Size = new System.Drawing.Size(359, 24);
			this.ucMa_Data.TabIndex = 2;
			// 
			// dteNgay_End
			// 
			this.dteNgay_End.bAllowEmpty = true;
			this.dteNgay_End.bSelectOnFocus = false;
			this.dteNgay_End.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_End.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_End.Location = new System.Drawing.Point(116, 44);
			this.dteNgay_End.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_End.Mask = "00/00/0000";
			this.dteNgay_End.Name = "dteNgay_End";
			this.dteNgay_End.Size = new System.Drawing.Size(74, 20);
			this.dteNgay_End.TabIndex = 1;
			// 
			// dteNgay_Begin
			// 
			this.dteNgay_Begin.bAllowEmpty = true;
			this.dteNgay_Begin.bSelectOnFocus = false;
			this.dteNgay_Begin.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Begin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Begin.Location = new System.Drawing.Point(116, 20);
			this.dteNgay_Begin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Begin.Mask = "00/00/0000";
			this.dteNgay_Begin.Name = "dteNgay_Begin";
			this.dteNgay_Begin.Size = new System.Drawing.Size(74, 20);
			this.dteNgay_Begin.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::RosyList.Properties.Resources.Log;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(12, 256);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// lblLog
			// 
			this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLog.ForeColor = System.Drawing.Color.Blue;
			this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblLog.Location = new System.Drawing.Point(48, 265);
			this.lblLog.Name = "lblLog";
			this.lblLog.Size = new System.Drawing.Size(346, 22);
			this.lblLog.TabIndex = 8;
			this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
			this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(651, 296);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblLog);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.tabEdit);
			this.Name = "frmEdit";
			this.tabEdit.ResumeLayout(false);
			this.Page2.ResumeLayout(false);
			this.Page2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsTabControl tabEdit;
		public System.Windows.Forms.TabPage Page1;
		public System.Windows.Forms.TabPage Page2;
		public RosySystem.Customize.txtNgay_End dteNgay_End;
		public RosySystem.Customize.txtNgay_Begin dteNgay_Begin;
		public RosySystem.Control.rsLabel lblNgay_Begin;
		public RosySystem.Customize.ucMa_Data ucMa_Data;
		public RosySystem.Control.rsLabel lblMa_Data;
		public RosySystem.Control.rsLabel lblNgay_End;
		protected System.Windows.Forms.PictureBox pictureBox1;
		protected System.Windows.Forms.Label lblLog;
	}
}