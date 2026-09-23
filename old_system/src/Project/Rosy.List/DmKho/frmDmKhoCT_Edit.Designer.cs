namespace RosyList
{
    partial class frmDmKhoCT_Edit
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
            this.txtMa_Kho = new RosySystem.Control.rsTextBox();
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.lblTen_Dt = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.numSl_Dm_Kg = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(460, 196);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(691, 180);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.dteNgay_Ap);
            this.Page1.Controls.Add(this.lblDien_Giai);
            this.Page1.Controls.Add(this.numSl_Dm_Kg);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.lblTen_Dt);
            this.Page1.Controls.Add(this.txtMa_Dt);
            this.Page1.Controls.Add(this.txtMa_Kho);
            this.Page1.Controls.Add(this.rsLabel5);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Size = new System.Drawing.Size(683, 154);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(683, 154);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 207);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(45, 216);
            this.lblLog.Text = "";
            // 
            // txtMa_Kho
            // 
            this.txtMa_Kho.AutoDropDown = null;
            this.txtMa_Kho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Kho.Location = new System.Drawing.Point(135, 22);
            this.txtMa_Kho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho.MaxLength = 20;
            this.txtMa_Kho.Name = "txtMa_Kho";
            this.txtMa_Kho.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Kho.TabIndex = 0;
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(6, 22);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(43, 13);
            this.lbMa_Kho.TabIndex = 20;
            this.lbMa_Kho.Tag = "Ma_Kho";
            this.lbMa_Kho.Text = "Mã kho";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_Dt
            // 
            this.lblTen_Dt.AutoEllipsis = true;
            this.lblTen_Dt.AutoSize = true;
            this.lblTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lblTen_Dt.Location = new System.Drawing.Point(260, 47);
            this.lblTen_Dt.Name = "lblTen_Dt";
            this.lblTen_Dt.Size = new System.Drawing.Size(74, 13);
            this.lblTen_Dt.TabIndex = 22;
            this.lblTen_Dt.Text = "Tên đối tượng";
            this.lblTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(6, 44);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(43, 13);
            this.rsLabel5.TabIndex = 20;
            this.rsLabel5.Tag = "Ma_Dt";
            this.rsLabel5.Text = "Mã kho";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(135, 44);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 1;
            // 
            // numSl_Dm_Kg
            // 
            this.numSl_Dm_Kg.AutoDropDown = null;
            this.numSl_Dm_Kg.bFormat = true;
            this.numSl_Dm_Kg.Location = new System.Drawing.Point(135, 93);
            this.numSl_Dm_Kg.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numSl_Dm_Kg.Name = "numSl_Dm_Kg";
            this.numSl_Dm_Kg.Scale = 2;
            this.numSl_Dm_Kg.Size = new System.Drawing.Size(120, 20);
            this.numSl_Dm_Kg.TabIndex = 3;
            this.numSl_Dm_Kg.Tag = "";
            this.numSl_Dm_Kg.Text = "0.00";
            this.numSl_Dm_Kg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSl_Dm_Kg.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(6, 96);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(127, 13);
            this.rsLabel1.TabIndex = 117;
            this.rsLabel1.Tag = "Sl_Dm_Kg";
            this.rsLabel1.Text = "Số lượng định mức ký gửi";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(135, 68);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(96, 20);
            this.dteNgay_Ap.TabIndex = 2;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(6, 71);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(47, 13);
            this.lblDien_Giai.TabIndex = 119;
            this.lblDien_Giai.Tag = "Ngay_Ap";
            this.lblDien_Giai.Text = "Ngày áp";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmKhoCT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(703, 257);
            this.Name = "frmDmKhoCT_Edit";
            this.Object_ID = "DMKHO";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Control.rsTextBox txtMa_Kho;
		private RosySystem.Control.rsLabel lbMa_Kho;
        private RosySystem.Control.rsLabel lblTen_Dt;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBoxNumber numSl_Dm_Kg;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsLabel lblDien_Giai;

	}
}