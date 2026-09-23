namespace RosyModule
{
    partial class frmIn_Ct_NM
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
            this.rdbPx_BBXN = new RosySystem.Control.rsRadioButton();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.rdbPhieu_Nhap = new RosySystem.Control.rsRadioButton();
            this.txtLien = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbPx_BBXN
            // 
            this.rdbPx_BBXN.AutoSize = true;
            this.rdbPx_BBXN.Checked = true;
            this.rdbPx_BBXN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPx_BBXN.Location = new System.Drawing.Point(70, 54);
            this.rdbPx_BBXN.Name = "rdbPx_BBXN";
            this.rdbPx_BBXN.Size = new System.Drawing.Size(127, 17);
            this.rdbPx_BBXN.TabIndex = 0;
            this.rdbPx_BBXN.TabStop = true;
            this.rdbPx_BBXN.Tag = "";
            this.rdbPx_BBXN.Text = "In biên bản giao nhận";
            this.rdbPx_BBXN.UnChecked = false;
            this.rdbPx_BBXN.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(125, 167);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.txtLien);
            this.gbIn_Tien.Controls.Add(this.rsLabel5);
            this.gbIn_Tien.Controls.Add(this.rdbPhieu_Nhap);
            this.gbIn_Tien.Controls.Add(this.rdbPx_BBXN);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(259, 122);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // rdbPhieu_Nhap
            // 
            this.rdbPhieu_Nhap.AutoSize = true;
            this.rdbPhieu_Nhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPhieu_Nhap.Location = new System.Drawing.Point(70, 19);
            this.rdbPhieu_Nhap.Name = "rdbPhieu_Nhap";
            this.rdbPhieu_Nhap.Size = new System.Drawing.Size(110, 17);
            this.rdbPhieu_Nhap.TabIndex = 2;
            this.rdbPhieu_Nhap.Tag = "";
            this.rdbPhieu_Nhap.Text = "In phiếu nhập kho";
            this.rdbPhieu_Nhap.UnChecked = true;
            this.rdbPhieu_Nhap.UseVisualStyleBackColor = true;
            // 
            // txtLien
            // 
            this.txtLien.AutoDropDown = null;
            this.txtLien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLien.Location = new System.Drawing.Point(119, 74);
            this.txtLien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLien.Name = "txtLien";
            this.txtLien.Size = new System.Drawing.Size(78, 20);
            this.txtLien.TabIndex = 22;
            this.txtLien.Text = "1,2";
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rsLabel5.Location = new System.Drawing.Point(64, 77);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(50, 13);
            this.rsLabel5.TabIndex = 23;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Số liên in";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmIn_Ct_NM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 224);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_Ct_NM";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
		public RosySystem.Control.rsRadioButton rdbPx_BBXN;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbPhieu_Nhap;
        public RosySystem.Control.rsTextBox txtLien;
        private RosySystem.Control.rsLabel rsLabel5;
	}
}