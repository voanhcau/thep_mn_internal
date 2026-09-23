namespace RosyList
{
	partial class frmReplace
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
			this.txtMa_Nh_Vt = new RosySystem.Control.rsTextBox();
			this.lblMa_Moi = new RosySystem.Control.rsLabel();
			this.lbtTen_Nh_Vt = new RosySystem.Control.rsLabelName();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(270, 96);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 43);
			this.btgAccept.TabIndex = 2;
			// 
			// txtMa_Nh_Vt
			// 
			this.txtMa_Nh_Vt.Location = new System.Drawing.Point(119, 57);
			this.txtMa_Nh_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Nh_Vt.Name = "txtMa_Nh_Vt";
			this.txtMa_Nh_Vt.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Nh_Vt.TabIndex = 1;
			// 
			// lblMa_Moi
			// 
			this.lblMa_Moi.AutoEllipsis = true;
			this.lblMa_Moi.AutoSize = true;
			this.lblMa_Moi.Location = new System.Drawing.Point(17, 61);
			this.lblMa_Moi.Name = "lblMa_Moi";
			this.lblMa_Moi.Size = new System.Drawing.Size(41, 13);
			this.lblMa_Moi.TabIndex = 1;
			this.lblMa_Moi.Tag = "Ma_Nh_Vt";
			this.lblMa_Moi.Text = "Mã mới";
			this.lblMa_Moi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Nh_Vt
			// 
			this.lbtTen_Nh_Vt.AutoSize = true;
			this.lbtTen_Nh_Vt.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Nh_Vt.Location = new System.Drawing.Point(254, 61);
			this.lbtTen_Nh_Vt.Name = "lbtTen_Nh_Vt";
			this.lbtTen_Nh_Vt.Size = new System.Drawing.Size(62, 13);
			this.lbtTen_Nh_Vt.TabIndex = 1;
			this.lbtTen_Nh_Vt.Tag = "";
			this.lbtTen_Nh_Vt.Text = "Tên mã mới";
			this.lbtTen_Nh_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmReplace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 151);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.lbtTen_Nh_Vt);
			this.Controls.Add(this.lblMa_Moi);
			this.Controls.Add(this.txtMa_Nh_Vt);
			this.Name = "frmReplace";
			this.Tag = "MergeID";
			this.Text = "Gộp mã";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsTextBox txtMa_Nh_Vt;
		private RosySystem.Control.rsLabel lblMa_Moi;
		private RosySystem.Control.rsLabelName lbtTen_Nh_Vt;
	}
}