namespace RosyModule.ScaleBarcode
{
	partial class frmRestore_Scale
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
			this.rdbIs_Restore = new RosySystem.Control.rsRadioButton();
			this.rdbIs_Delete = new RosySystem.Control.rsRadioButton();
			this.txtSo_Ct = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(320, 161);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 3;
			// 
			// rdbIs_Restore
			// 
			this.rdbIs_Restore.AutoSize = true;
			this.rdbIs_Restore.Checked = true;
			this.rdbIs_Restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbIs_Restore.ForeColor = System.Drawing.Color.Blue;
			this.rdbIs_Restore.Location = new System.Drawing.Point(116, 84);
			this.rdbIs_Restore.Name = "rdbIs_Restore";
			this.rdbIs_Restore.Size = new System.Drawing.Size(135, 17);
			this.rdbIs_Restore.TabIndex = 1;
			this.rdbIs_Restore.TabStop = true;
			this.rdbIs_Restore.Text = "Phục hồi phiếu cân";
			this.rdbIs_Restore.UnChecked = false;
			this.rdbIs_Restore.UseVisualStyleBackColor = true;
			// 
			// rdbIs_Delete
			// 
			this.rdbIs_Delete.AutoSize = true;
			this.rdbIs_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbIs_Delete.ForeColor = System.Drawing.Color.Red;
			this.rdbIs_Delete.Location = new System.Drawing.Point(116, 107);
			this.rdbIs_Delete.Name = "rdbIs_Delete";
			this.rdbIs_Delete.Size = new System.Drawing.Size(189, 17);
			this.rdbIs_Delete.TabIndex = 2;
			this.rdbIs_Delete.Text = "Xóa phiếu cân khỏi hệ thống";
			this.rdbIs_Delete.UnChecked = true;
			this.rdbIs_Delete.UseVisualStyleBackColor = true;
			// 
			// txtSo_Ct
			// 
			this.txtSo_Ct.AutoDropDown = null;
			this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSo_Ct.Enabled = false;
			this.txtSo_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSo_Ct.ForeColor = System.Drawing.Color.Red;
			this.txtSo_Ct.Location = new System.Drawing.Point(116, 47);
			this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_Ct.Name = "txtSo_Ct";
			this.txtSo_Ct.Size = new System.Drawing.Size(132, 26);
			this.txtSo_Ct.TabIndex = 0;
			this.txtSo_Ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(47, 55);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(49, 13);
			this.rsLabel1.TabIndex = 50;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Số phiếu";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmRestore_Scale
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(513, 216);
			this.Controls.Add(this.rdbIs_Delete);
			this.Controls.Add(this.rdbIs_Restore);
			this.Controls.Add(this.txtSo_Ct);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmRestore_Scale";
			this.Text = "Restore Scale";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtSo_Ct;
		private RosySystem.Control.rsLabel rsLabel1;
		public RosySystem.Control.rsRadioButton rdbIs_Restore;
		public RosySystem.Control.rsRadioButton rdbIs_Delete;
	}
}