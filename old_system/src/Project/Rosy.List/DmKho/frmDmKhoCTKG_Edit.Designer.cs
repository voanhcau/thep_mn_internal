namespace RosyList
{
    partial class frmDmKhoCTKG_Edit
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
            this.txtMa_Nh_Kg = new RosySystem.Control.rsTextBox();
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.lblTen_Dt = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.numSl_Dm_Kg = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.dteNgay_Kt = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.lblTen_Nh_Kg = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.btMa_Kho = new RosySystem.Control.rsButton();
            this.txtMa_Kho_List = new RosySystem.Control.rsTextBox();
            this.txtSo_Qd = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(466, 308);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(697, 292);
            this.tabEdit.TabIndex = 1;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtGhi_Chu);
            this.Page1.Controls.Add(this.rsLabel7);
            this.Page1.Controls.Add(this.txtSo_Qd);
            this.Page1.Controls.Add(this.rsLabel6);
            this.Page1.Controls.Add(this.btMa_Kho);
            this.Page1.Controls.Add(this.txtMa_Kho_List);
            this.Page1.Controls.Add(this.dteNgay_Kt);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.dteNgay_Ap);
            this.Page1.Controls.Add(this.lblDien_Giai);
            this.Page1.Controls.Add(this.numSl_Dm_Kg);
            this.Page1.Controls.Add(this.rsLabel4);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.lblTen_Nh_Kg);
            this.Page1.Controls.Add(this.rsLabel3);
            this.Page1.Controls.Add(this.lblTen_Dt);
            this.Page1.Controls.Add(this.txtMa_Dt);
            this.Page1.Controls.Add(this.txtMa_Nh_Kg);
            this.Page1.Controls.Add(this.rsLabel5);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Size = new System.Drawing.Size(689, 266);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(689, 266);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 319);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(45, 328);
            this.lblLog.Text = "";
            // 
            // txtMa_Nh_Kg
            // 
            this.txtMa_Nh_Kg.AutoDropDown = null;
            this.txtMa_Nh_Kg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_Kg.Location = new System.Drawing.Point(135, 40);
            this.txtMa_Nh_Kg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Kg.MaxLength = 20;
            this.txtMa_Nh_Kg.Name = "txtMa_Nh_Kg";
            this.txtMa_Nh_Kg.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_Kg.TabIndex = 1;
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(6, 40);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(69, 13);
            this.lbMa_Kho.TabIndex = 20;
            this.lbMa_Kho.Tag = "";
            this.lbMa_Kho.Text = "Mã nhóm KG";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_Dt
            // 
            this.lblTen_Dt.AutoEllipsis = true;
            this.lblTen_Dt.AutoSize = true;
            this.lblTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lblTen_Dt.Location = new System.Drawing.Point(264, 17);
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
            this.rsLabel5.Location = new System.Drawing.Point(10, 14);
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
            this.txtMa_Dt.Location = new System.Drawing.Point(135, 14);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 0;
            // 
            // numSl_Dm_Kg
            // 
            this.numSl_Dm_Kg.AutoDropDown = null;
            this.numSl_Dm_Kg.bFormat = true;
            this.numSl_Dm_Kg.Location = new System.Drawing.Point(135, 213);
            this.numSl_Dm_Kg.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numSl_Dm_Kg.Name = "numSl_Dm_Kg";
            this.numSl_Dm_Kg.Scale = 2;
            this.numSl_Dm_Kg.Size = new System.Drawing.Size(120, 20);
            this.numSl_Dm_Kg.TabIndex = 6;
            this.numSl_Dm_Kg.Tag = "";
            this.numSl_Dm_Kg.Text = "0.00";
            this.numSl_Dm_Kg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSl_Dm_Kg.Value = 0D;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(6, 216);
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
            this.dteNgay_Ap.Location = new System.Drawing.Point(135, 92);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(96, 20);
            this.dteNgay_Ap.TabIndex = 3;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(6, 95);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(47, 13);
            this.lblDien_Giai.TabIndex = 119;
            this.lblDien_Giai.Tag = "Ngay_Ap";
            this.lblDien_Giai.Text = "Ngày áp";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Kt
            // 
            this.dteNgay_Kt.bAllowEmpty = true;
            this.dteNgay_Kt.bSelectOnFocus = false;
            this.dteNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kt.Location = new System.Drawing.Point(330, 92);
            this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Kt.Mask = "00/00/0000";
            this.dteNgay_Kt.Name = "dteNgay_Kt";
            this.dteNgay_Kt.Size = new System.Drawing.Size(96, 20);
            this.dteNgay_Kt.TabIndex = 120;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(260, 98);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(47, 13);
            this.rsLabel2.TabIndex = 121;
            this.rsLabel2.Tag = "Ngay_Kt";
            this.rsLabel2.Text = "Ngày áp";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_Nh_Kg
            // 
            this.lblTen_Nh_Kg.AutoEllipsis = true;
            this.lblTen_Nh_Kg.AutoSize = true;
            this.lblTen_Nh_Kg.ForeColor = System.Drawing.Color.Blue;
            this.lblTen_Nh_Kg.Location = new System.Drawing.Point(260, 43);
            this.lblTen_Nh_Kg.Name = "lblTen_Nh_Kg";
            this.lblTen_Nh_Kg.Size = new System.Drawing.Size(86, 13);
            this.lblTen_Nh_Kg.TabIndex = 22;
            this.lblTen_Nh_Kg.Text = "Tên nhóm ký gửi";
            this.lblTen_Nh_Kg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel3.Location = new System.Drawing.Point(261, 216);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(20, 13);
            this.rsLabel3.TabIndex = 22;
            this.rsLabel3.Text = "Kg";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(10, 169);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(80, 13);
            this.rsLabel4.TabIndex = 117;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Danh sách kho";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btMa_Kho
            // 
            this.btMa_Kho.Location = new System.Drawing.Point(473, 161);
            this.btMa_Kho.Margin = new System.Windows.Forms.Padding(0);
            this.btMa_Kho.Name = "btMa_Kho";
            this.btMa_Kho.Size = new System.Drawing.Size(23, 22);
            this.btMa_Kho.TabIndex = 3;
            this.btMa_Kho.TabStop = false;
            this.btMa_Kho.Text = "...";
            this.btMa_Kho.UseVisualStyleBackColor = true;
            // 
            // txtMa_Kho_List
            // 
            this.txtMa_Kho_List.AutoDropDown = null;
            this.txtMa_Kho_List.Location = new System.Drawing.Point(135, 162);
            this.txtMa_Kho_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho_List.MaxLength = 1000;
            this.txtMa_Kho_List.Multiline = true;
            this.txtMa_Kho_List.Name = "txtMa_Kho_List";
            this.txtMa_Kho_List.Size = new System.Drawing.Size(333, 43);
            this.txtMa_Kho_List.TabIndex = 5;
            // 
            // txtSo_Qd
            // 
            this.txtSo_Qd.AutoDropDown = null;
            this.txtSo_Qd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Qd.Location = new System.Drawing.Point(135, 65);
            this.txtSo_Qd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Qd.MaxLength = 20;
            this.txtSo_Qd.Name = "txtSo_Qd";
            this.txtSo_Qd.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Qd.TabIndex = 2;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(6, 65);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(73, 13);
            this.rsLabel6.TabIndex = 123;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Số quyết định";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(135, 117);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.MaxLength = 1000;
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(333, 31);
            this.txtGhi_Chu.TabIndex = 4;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(10, 124);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(50, 13);
            this.rsLabel7.TabIndex = 125;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Diễn Giải";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmKhoCTKG_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(709, 369);
            this.Name = "frmDmKhoCTKG_Edit";
            this.Object_ID = "DMKHOCTKG";
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

        private RosySystem.Control.rsTextBox txtMa_Nh_Kg;
		private RosySystem.Control.rsLabel lbMa_Kho;
        private RosySystem.Control.rsLabel lblTen_Dt;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBoxNumber numSl_Dm_Kg;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsLabel lblDien_Giai;
        private RosySystem.Control.rsDateTime dteNgay_Kt;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel lblTen_Nh_Kg;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsButton btMa_Kho;
        private RosySystem.Control.rsTextBox txtMa_Kho_List;
        private RosySystem.Control.rsTextBox txtSo_Qd;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel rsLabel7;
    }
}