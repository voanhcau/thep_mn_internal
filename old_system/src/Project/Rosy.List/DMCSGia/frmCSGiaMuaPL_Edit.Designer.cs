namespace RosyList
{
	partial class frmCSGiaMuaPL_Edit
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
            this.lbtTen_Vt = new RosySystem.Control.rsLabel();
            this.lbGia = new RosySystem.Control.rsLabel();
            this.numGia = new RosySystem.Control.rsTextBoxNumber();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.lbMa_Vt = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.lbSo_QD = new RosySystem.Control.rsLabel();
            this.txtSo_Qd = new RosySystem.Control.rsTextBox();
            this.SuspendLayout();
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(255, 34);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Vt.TabIndex = 68;
            this.lbtTen_Vt.Text = "Tên vật tư";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGia
            // 
            this.lbGia.AutoEllipsis = true;
            this.lbGia.AutoSize = true;
            this.lbGia.Location = new System.Drawing.Point(9, 56);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(46, 13);
            this.lbGia.TabIndex = 67;
            this.lbGia.Tag = "";
            this.lbGia.Text = "Giá mua";
            this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGia
            // 
            this.numGia.AutoDropDown = null;
            this.numGia.bFormat = true;
            this.numGia.Location = new System.Drawing.Point(128, 53);
            this.numGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numGia.Name = "numGia";
            this.numGia.Scale = 2;
            this.numGia.Size = new System.Drawing.Size(120, 20);
            this.numGia.TabIndex = 5;
            this.numGia.Text = "0.00";
            this.numGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia.Value = 0D;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(128, 31);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 0;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(9, 34);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(52, 13);
            this.lbMa_Vt.TabIndex = 65;
            this.lbMa_Vt.Tag = "Ma_Vt";
            this.lbMa_Vt.Text = "Mã vật tư";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(352, 226);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 15;
            // 
            // lbSo_QD
            // 
            this.lbSo_QD.AutoEllipsis = true;
            this.lbSo_QD.AutoSize = true;
            this.lbSo_QD.Location = new System.Drawing.Point(9, 12);
            this.lbSo_QD.Name = "lbSo_QD";
            this.lbSo_QD.Size = new System.Drawing.Size(73, 13);
            this.lbSo_QD.TabIndex = 65;
            this.lbSo_QD.Tag = "So_Qd";
            this.lbSo_QD.Text = "Số quyết định";
            this.lbSo_QD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Qd
            // 
            this.txtSo_Qd.AutoDropDown = null;
            this.txtSo_Qd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Qd.Enabled = false;
            this.txtSo_Qd.Location = new System.Drawing.Point(128, 9);
            this.txtSo_Qd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Qd.MaxLength = 20;
            this.txtSo_Qd.Name = "txtSo_Qd";
            this.txtSo_Qd.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Qd.TabIndex = 3;
            // 
            // frmCSGiaMuaPL_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 281);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.txtSo_Qd);
            this.Controls.Add(this.lbSo_QD);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.lbMa_Vt);
            this.Name = "frmCSGiaMuaPL_Edit";
            this.Tag = "frmDmGiaMua";
            this.Text = "frmDmGiaMua";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsLabel lbtTen_Vt;
		private RosySystem.Control.rsLabel lbGia;
		private RosySystem.Control.rsTextBoxNumber numGia;
		private RosySystem.Control.rsTextBox txtMa_Vt;
		private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lbSo_QD;
        private RosySystem.Control.rsTextBox txtSo_Qd;
	}
}