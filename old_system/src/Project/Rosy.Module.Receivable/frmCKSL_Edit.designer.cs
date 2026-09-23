namespace RosyModule.Receivable
{
	partial class frmCKSL_Edit
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
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteNgay_Begin = new RosySystem.Control.rsDateTime();
            this.txtDien_Giai = new RosySystem.Control.rsTextBox();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_List = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.dteNgay_End = new RosySystem.Control.rsDateTime();
            this.lblLoai_Nhom = new RosySystem.Control.rsLabel();
            this.txtSo_Qd_Ck = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.txtMa_Kho_List = new RosySystem.Control.rsTextBox();
            this.btMa_Dt = new RosySystem.Control.rsButton();
            this.btMa_Kho = new RosySystem.Control.rsButton();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(543, 154);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 44);
            this.btgAccept.TabIndex = 6;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay_Ct.Location = new System.Drawing.Point(28, 36);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(45, 13);
            this.lblNgay_Ct.TabIndex = 4;
            this.lblNgay_Ct.Tag = "Ngay_HL";
            this.lblNgay_Ct.Text = "Ngày Ct";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Begin
            // 
            this.dteNgay_Begin.bAllowEmpty = true;
            this.dteNgay_Begin.bSelectOnFocus = true;
            this.dteNgay_Begin.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Begin.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Begin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Begin.Location = new System.Drawing.Point(120, 36);
            this.dteNgay_Begin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Begin.Mask = "00/00/0000";
            this.dteNgay_Begin.Name = "dteNgay_Begin";
            this.dteNgay_Begin.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Begin.TabIndex = 1;
            // 
            // txtDien_Giai
            // 
            this.txtDien_Giai.AutoDropDown = null;
            this.txtDien_Giai.Location = new System.Drawing.Point(120, 61);
            this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDien_Giai.MaxLength = 200;
            this.txtDien_Giai.Name = "txtDien_Giai";
            this.txtDien_Giai.Size = new System.Drawing.Size(612, 20);
            this.txtDien_Giai.TabIndex = 3;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(24, 61);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(48, 13);
            this.lblDien_Giai.TabIndex = 66;
            this.lblDien_Giai.Tag = "Dien_Giai";
            this.lblDien_Giai.Text = "Diễn giải";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_List
            // 
            this.txtMa_Dt_List.AutoDropDown = null;
            this.txtMa_Dt_List.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_List.Location = new System.Drawing.Point(120, 83);
            this.txtMa_Dt_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_List.MaxLength = 1000;
            this.txtMa_Dt_List.Name = "txtMa_Dt_List";
            this.txtMa_Dt_List.Size = new System.Drawing.Size(567, 20);
            this.txtMa_Dt_List.TabIndex = 4;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel2.Location = new System.Drawing.Point(24, 83);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(99, 13);
            this.rsLabel2.TabIndex = 140;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Khách hàng List";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(200, 42);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(90, 13);
            this.rsLabel3.TabIndex = 56;
            this.rsLabel3.Tag = "Ngay_KThuc";
            this.rsLabel3.Text = "Ngày bắt đầu KH";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_End
            // 
            this.dteNgay_End.bAllowEmpty = true;
            this.dteNgay_End.bSelectOnFocus = true;
            this.dteNgay_End.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_End.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_End.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_End.Location = new System.Drawing.Point(311, 39);
            this.dteNgay_End.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_End.Mask = "00/00/0000";
            this.dteNgay_End.Name = "dteNgay_End";
            this.dteNgay_End.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_End.TabIndex = 2;
            // 
            // lblLoai_Nhom
            // 
            this.lblLoai_Nhom.AutoEllipsis = true;
            this.lblLoai_Nhom.AutoSize = true;
            this.lblLoai_Nhom.Location = new System.Drawing.Point(24, 15);
            this.lblLoai_Nhom.Name = "lblLoai_Nhom";
            this.lblLoai_Nhom.Size = new System.Drawing.Size(92, 13);
            this.lblLoai_Nhom.TabIndex = 202;
            this.lblLoai_Nhom.Tag = "";
            this.lblLoai_Nhom.Text = "Số QĐ chiết khấu";
            this.lblLoai_Nhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Qd_Ck
            // 
            this.txtSo_Qd_Ck.AutoDropDown = null;
            this.txtSo_Qd_Ck.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Qd_Ck.Location = new System.Drawing.Point(120, 14);
            this.txtSo_Qd_Ck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Qd_Ck.MaxLength = 20;
            this.txtSo_Qd_Ck.Name = "txtSo_Qd_Ck";
            this.txtSo_Qd_Ck.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Qd_Ck.TabIndex = 0;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel6.Location = new System.Drawing.Point(24, 105);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(53, 13);
            this.rsLabel6.TabIndex = 140;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Kho List";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Kho_List
            // 
            this.txtMa_Kho_List.AutoDropDown = null;
            this.txtMa_Kho_List.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Kho_List.Location = new System.Drawing.Point(120, 105);
            this.txtMa_Kho_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho_List.MaxLength = 200;
            this.txtMa_Kho_List.Name = "txtMa_Kho_List";
            this.txtMa_Kho_List.Size = new System.Drawing.Size(567, 20);
            this.txtMa_Kho_List.TabIndex = 5;
            // 
            // btMa_Dt
            // 
            this.btMa_Dt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btMa_Dt.Location = new System.Drawing.Point(689, 83);
            this.btMa_Dt.Margin = new System.Windows.Forms.Padding(0);
            this.btMa_Dt.Name = "btMa_Dt";
            this.btMa_Dt.Size = new System.Drawing.Size(23, 22);
            this.btMa_Dt.TabIndex = 203;
            this.btMa_Dt.Text = "...";
            this.btMa_Dt.UseVisualStyleBackColor = true;
            // 
            // btMa_Kho
            // 
            this.btMa_Kho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btMa_Kho.Location = new System.Drawing.Point(689, 105);
            this.btMa_Kho.Margin = new System.Windows.Forms.Padding(0);
            this.btMa_Kho.Name = "btMa_Kho";
            this.btMa_Kho.Size = new System.Drawing.Size(23, 22);
            this.btMa_Kho.TabIndex = 204;
            this.btMa_Kho.Text = "...";
            this.btMa_Kho.UseVisualStyleBackColor = true;
            // 
            // frmCKSL_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 205);
            this.Controls.Add(this.btMa_Kho);
            this.Controls.Add(this.btMa_Dt);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.dteNgay_End);
            this.Controls.Add(this.lblLoai_Nhom);
            this.Controls.Add(this.txtSo_Qd_Ck);
            this.Controls.Add(this.txtMa_Kho_List);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.txtMa_Dt_List);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtDien_Giai);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.dteNgay_Begin);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmCKSL_Edit";
            this.Tag = "frmCtTsNGia";
            this.Text = "frmCtTsNGia";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private RosySystem.Control.rsDateTime dteNgay_Begin;
		private RosySystem.Control.rsTextBox txtDien_Giai;
        private RosySystem.Control.rsLabel lblDien_Giai;
		private RosySystem.Control.rsTextBox txtMa_Dt_List;
        private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsDateTime dteNgay_End;
		private RosySystem.Control.rsLabel lblLoai_Nhom;
        private RosySystem.Control.rsTextBox txtSo_Qd_Ck;
		private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBox txtMa_Kho_List;
        private RosySystem.Control.rsButton btMa_Dt;
        private RosySystem.Control.rsButton btMa_Kho;
	}
}