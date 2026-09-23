namespace RosyModule.ScaleBarcode
{
	partial class frmVoucher_Scale_Edit
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
			this.lblLog = new System.Windows.Forms.Label();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.cboSaveOption = new RosySystem.Control.rsComboBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblLog
			// 
			this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblLog.AutoSize = true;
			this.lblLog.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLog.ForeColor = System.Drawing.Color.Blue;
			this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblLog.Location = new System.Drawing.Point(48, 540);
			this.lblLog.Name = "lblLog";
			this.lblLog.Size = new System.Drawing.Size(260, 13);
			this.lblLog.TabIndex = 108;
			this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
			this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(603, 516);
			this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(178, 42);
			this.btgAccept.TabIndex = 999;
			// 
			// cboSaveOption
			// 
			this.cboSaveOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cboSaveOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSaveOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboSaveOption.ForeColor = System.Drawing.Color.Blue;
			this.cboSaveOption.FormattingEnabled = true;
			this.cboSaveOption.Location = new System.Drawing.Point(452, 531);
			this.cboSaveOption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboSaveOption.Name = "cboSaveOption";
			this.cboSaveOption.Size = new System.Drawing.Size(147, 21);
			this.cboSaveOption.TabIndex = 998;
			this.cboSaveOption.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.ErrorImage = null;
			this.pictureBox1.Image = global::RosyModule.Properties.Resources.Log;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(12, 531);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 109;
			this.pictureBox1.TabStop = false;
			// 
			// frmVoucher_Scale_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 569);
			this.Controls.Add(this.cboSaveOption);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblLog);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmVoucher_Scale_Edit";
			this.Text = "frmVoucher_Scale";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label lblLog;
		protected RosySystem.Customize.btgAccept btgAccept;
		protected RosySystem.Control.rsComboBox cboSaveOption;
		public System.Windows.Forms.PictureBox pictureBox1;
	}
}