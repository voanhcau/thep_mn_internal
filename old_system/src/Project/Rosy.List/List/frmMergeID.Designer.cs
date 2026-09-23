namespace RosyList
{
	partial class frmMergeID
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
			this.txtMa_Cu = new RosySystem.Control.rsTextBox();
			this.lblMa_Cu = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.lbtTen_Ma_Cu = new RosySystem.Control.rsLabelName();
			this.txtMa_Moi = new RosySystem.Control.rsTextBox();
			this.lblMa_Moi = new RosySystem.Control.rsLabel();
			this.lbtTen_Ma_Moi = new RosySystem.Control.rsLabelName();
			this.SuspendLayout();
			// 
			// txtMa_Cu
			// 
			this.txtMa_Cu.Location = new System.Drawing.Point(119, 31);
			this.txtMa_Cu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Cu.Name = "txtMa_Cu";
			this.txtMa_Cu.ReadOnly = true;
			this.txtMa_Cu.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Cu.TabIndex = 0;
			// 
			// lblMa_Cu
			// 
			this.lblMa_Cu.AutoEllipsis = true;
			this.lblMa_Cu.AutoSize = true;
			this.lblMa_Cu.Location = new System.Drawing.Point(51, 35);
			this.lblMa_Cu.Name = "lblMa_Cu";
			this.lblMa_Cu.Size = new System.Drawing.Size(37, 13);
			this.lblMa_Cu.TabIndex = 1;
			this.lblMa_Cu.Tag = "Ma_Cu";
			this.lblMa_Cu.Text = "Mã cũ";
			this.lblMa_Cu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(270, 96);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 2;
			// 
			// lbtTen_Ma_Cu
			// 
			this.lbtTen_Ma_Cu.AutoSize = true;
			this.lbtTen_Ma_Cu.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Ma_Cu.Location = new System.Drawing.Point(254, 35);
			this.lbtTen_Ma_Cu.Name = "lbtTen_Ma_Cu";
			this.lbtTen_Ma_Cu.Size = new System.Drawing.Size(58, 13);
			this.lbtTen_Ma_Cu.TabIndex = 1;
			this.lbtTen_Ma_Cu.Tag = "";
			this.lbtTen_Ma_Cu.Text = "Tên mã cũ";
			this.lbtTen_Ma_Cu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Moi
			// 
			this.txtMa_Moi.Location = new System.Drawing.Point(119, 57);
			this.txtMa_Moi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Moi.Name = "txtMa_Moi";
			this.txtMa_Moi.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Moi.TabIndex = 1;
			// 
			// lblMa_Moi
			// 
			this.lblMa_Moi.AutoEllipsis = true;
			this.lblMa_Moi.AutoSize = true;
			this.lblMa_Moi.Location = new System.Drawing.Point(51, 61);
			this.lblMa_Moi.Name = "lblMa_Moi";
			this.lblMa_Moi.Size = new System.Drawing.Size(41, 13);
			this.lblMa_Moi.TabIndex = 1;
			this.lblMa_Moi.Tag = "Ma_Moi";
			this.lblMa_Moi.Text = "Mã mới";
			this.lblMa_Moi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Ma_Moi
			// 
			this.lbtTen_Ma_Moi.AutoSize = true;
			this.lbtTen_Ma_Moi.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Ma_Moi.Location = new System.Drawing.Point(254, 61);
			this.lbtTen_Ma_Moi.Name = "lbtTen_Ma_Moi";
			this.lbtTen_Ma_Moi.Size = new System.Drawing.Size(62, 13);
			this.lbtTen_Ma_Moi.TabIndex = 1;
			this.lbtTen_Ma_Moi.Tag = "";
			this.lbtTen_Ma_Moi.Text = "Tên mã mới";
			this.lbtTen_Ma_Moi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmMergeID
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 151);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.lbtTen_Ma_Moi);
			this.Controls.Add(this.lbtTen_Ma_Cu);
			this.Controls.Add(this.lblMa_Moi);
			this.Controls.Add(this.lblMa_Cu);
			this.Controls.Add(this.txtMa_Moi);
			this.Controls.Add(this.txtMa_Cu);
			this.Name = "frmMergeID";
			this.Tag = "MergeID";
			this.Text = "Gộp mã";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtMa_Cu;
		private RosySystem.Control.rsLabel lblMa_Cu;
		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtMa_Moi;
		private RosySystem.Control.rsLabel lblMa_Moi;
		private RosySystem.Control.rsLabelName lbtTen_Ma_Moi;
		private RosySystem.Control.rsLabelName lbtTen_Ma_Cu;
	}
}