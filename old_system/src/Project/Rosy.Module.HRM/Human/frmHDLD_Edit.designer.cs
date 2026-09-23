namespace RosyModule.HRM
{
    partial class frmHDLD_Edit
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
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.dteNgay_Kt = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ky = new RosySystem.Control.rsDateTime();
            this.rsLabel16 = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.dteNgay_Bd = new RosySystem.Control.rsDateTime();
            this.rsLabel12 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtSo_Hd = new RosySystem.Control.rsTextBox();
            this.txtNguoi_Ky = new RosySystem.Control.rsTextBox();
            this.txtNoi_Dung = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.txtThoi_Gian_Hd = new RosySystem.Control.rsTextBoxEnum();
            this.txtLoai_Hd = new RosySystem.Control.rsTextBoxEnum();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.txtViTri = new RosySystem.Control.rsTextBox();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.txtChuc_DanhNK = new RosySystem.Control.rsTextBox();
            this.numLuongCB = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel69 = new RosySystem.Control.rsLabel();
            this.rsLabel15 = new RosySystem.Control.rsLabel();
            this.numLuongBH = new RosySystem.Control.rsTextBoxNumber();
            this.numTyLe = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel17 = new RosySystem.Control.rsLabel();
            this.rsLabel19 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.AutoDropDown = null;
            this.txtGhi_Chu.Location = new System.Drawing.Point(121, 275);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(517, 40);
            this.txtGhi_Chu.TabIndex = 15;
            // 
            // dteNgay_Kt
            // 
            this.dteNgay_Kt.bAllowEmpty = true;
            this.dteNgay_Kt.bSelectOnFocus = false;
            this.dteNgay_Kt.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kt.Location = new System.Drawing.Point(121, 222);
            this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Kt.Mask = "00/00/0000";
            this.dteNgay_Kt.Name = "dteNgay_Kt";
            this.dteNgay_Kt.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Kt.TabIndex = 11;
            // 
            // dteNgay_Ky
            // 
            this.dteNgay_Ky.bAllowEmpty = false;
            this.dteNgay_Ky.bSelectOnFocus = false;
            this.dteNgay_Ky.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ky.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ky.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ky.Location = new System.Drawing.Point(121, 150);
            this.dteNgay_Ky.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ky.Mask = "00/00/0000";
            this.dteNgay_Ky.Name = "dteNgay_Ky";
            this.dteNgay_Ky.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Ky.TabIndex = 6;
            // 
            // rsLabel16
            // 
            this.rsLabel16.AutoEllipsis = true;
            this.rsLabel16.AutoSize = true;
            this.rsLabel16.Location = new System.Drawing.Point(20, 283);
            this.rsLabel16.Name = "rsLabel16";
            this.rsLabel16.Size = new System.Drawing.Size(43, 13);
            this.rsLabel16.TabIndex = 25;
            this.rsLabel16.Tag = "Ghi_Chu";
            this.rsLabel16.Text = "Chi chú";
            this.rsLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(17, 225);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(74, 13);
            this.rsLabel6.TabIndex = 17;
            this.rsLabel6.Tag = "Ngay_KT";
            this.rsLabel6.Text = "Ngày kết thúc";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Bd
            // 
            this.dteNgay_Bd.bAllowEmpty = false;
            this.dteNgay_Bd.bSelectOnFocus = false;
            this.dteNgay_Bd.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Bd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Bd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Bd.Location = new System.Drawing.Point(121, 199);
            this.dteNgay_Bd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Bd.Mask = "00/00/0000";
            this.dteNgay_Bd.Name = "dteNgay_Bd";
            this.dteNgay_Bd.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Bd.TabIndex = 10;
            // 
            // rsLabel12
            // 
            this.rsLabel12.AutoEllipsis = true;
            this.rsLabel12.AutoSize = true;
            this.rsLabel12.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel12.Location = new System.Drawing.Point(162, 131);
            this.rsLabel12.Name = "rsLabel12";
            this.rsLabel12.Size = new System.Drawing.Size(587, 13);
            this.rsLabel12.TabIndex = 10;
            this.rsLabel12.Text = "0-Hợp đồng thử việc, 1-Hợp đồng LĐ chính thức có thời gian, 3-Hợp đồng thời vụ, 4" +
    "-Hợp đồng LĐ chính thức vô thời hạn";
            this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(17, 202);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(72, 13);
            this.rsLabel7.TabIndex = 15;
            this.rsLabel7.Tag = "Ngay_BD";
            this.rsLabel7.Text = "Ngày bắt đầu";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(538, 348);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(178, 43);
            this.btgAccept.TabIndex = 31;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(206, 153);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(49, 13);
            this.rsLabel4.TabIndex = 13;
            this.rsLabel4.Tag = "Nguoi_Ky";
            this.rsLabel4.Text = "Người ký";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(17, 131);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(76, 13);
            this.rsLabel3.TabIndex = 8;
            this.rsLabel3.Tag = "Loai_HD";
            this.rsLabel3.Text = "Loại hợp đồng";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(17, 154);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(46, 13);
            this.rsLabel11.TabIndex = 11;
            this.rsLabel11.Tag = "Ngay_Ky";
            this.rsLabel11.Text = "Ngày ký";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(17, 67);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(99, 13);
            this.rsLabel5.TabIndex = 5;
            this.rsLabel5.Tag = "Noi_Dung_HD";
            this.rsLabel5.Text = "Nội dung hợp đồng";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(17, 45);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(69, 13);
            this.rsLabel2.TabIndex = 0;
            this.rsLabel2.Tag = "So_HD";
            this.rsLabel2.Text = "Số hợp đồng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Hd
            // 
            this.txtSo_Hd.AutoDropDown = null;
            this.txtSo_Hd.Location = new System.Drawing.Point(121, 42);
            this.txtSo_Hd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Hd.Name = "txtSo_Hd";
            this.txtSo_Hd.Size = new System.Drawing.Size(164, 20);
            this.txtSo_Hd.TabIndex = 1;
            // 
            // txtNguoi_Ky
            // 
            this.txtNguoi_Ky.AutoDropDown = null;
            this.txtNguoi_Ky.Location = new System.Drawing.Point(260, 150);
            this.txtNguoi_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNguoi_Ky.Name = "txtNguoi_Ky";
            this.txtNguoi_Ky.Size = new System.Drawing.Size(222, 20);
            this.txtNguoi_Ky.TabIndex = 7;
            // 
            // txtNoi_Dung
            // 
            this.txtNoi_Dung.AutoDropDown = null;
            this.txtNoi_Dung.Location = new System.Drawing.Point(121, 64);
            this.txtNoi_Dung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNoi_Dung.Multiline = true;
            this.txtNoi_Dung.Name = "txtNoi_Dung";
            this.txtNoi_Dung.Size = new System.Drawing.Size(517, 38);
            this.txtNoi_Dung.TabIndex = 2;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(17, 23);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(72, 13);
            this.rsLabel1.TabIndex = 2;
            this.rsLabel1.Tag = "Ma_Dt_CbNv";
            this.rsLabel1.Text = "Mã nhân viên";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(121, 20);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt_CbNv.TabIndex = 0;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(17, 179);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(100, 13);
            this.rsLabel8.TabIndex = 8;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Thời gian hợp đồng";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rsLabel8.Visible = false;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel9.Location = new System.Drawing.Point(162, 179);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(290, 13);
            this.rsLabel9.TabIndex = 10;
            this.rsLabel9.Text = "1- 1 Tháng, 2- 2 Tháng, 3- 3 Tháng, 4-1 Năm, 5-Vô thời hạn";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rsLabel9.Visible = false;
            // 
            // txtThoi_Gian_Hd
            // 
            this.txtThoi_Gian_Hd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThoi_Gian_Hd.AutoDropDown = null;
            this.txtThoi_Gian_Hd.InputMask = "1,2,3,4,5";
            this.txtThoi_Gian_Hd.Location = new System.Drawing.Point(121, 176);
            this.txtThoi_Gian_Hd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtThoi_Gian_Hd.Name = "txtThoi_Gian_Hd";
            this.txtThoi_Gian_Hd.Size = new System.Drawing.Size(29, 20);
            this.txtThoi_Gian_Hd.TabIndex = 9;
            this.txtThoi_Gian_Hd.Text = "5";
            this.txtThoi_Gian_Hd.Visible = false;
            // 
            // txtLoai_Hd
            // 
            this.txtLoai_Hd.AutoDropDown = null;
            this.txtLoai_Hd.InputMask = "0,1,2,3,4";
            this.txtLoai_Hd.Location = new System.Drawing.Point(121, 128);
            this.txtLoai_Hd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtLoai_Hd.Name = "txtLoai_Hd";
            this.txtLoai_Hd.Size = new System.Drawing.Size(29, 20);
            this.txtLoai_Hd.TabIndex = 5;
            this.txtLoai_Hd.Text = "1";
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(246, 23);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(76, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 10;
            this.lbtTen_Dt_CbNv.Text = "Tên nhân viên";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtViTri
            // 
            this.txtViTri.AutoDropDown = null;
            this.txtViTri.Location = new System.Drawing.Point(121, 104);
            this.txtViTri.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtViTri.Multiline = true;
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(517, 22);
            this.txtViTri.TabIndex = 4;
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Location = new System.Drawing.Point(20, 110);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(71, 13);
            this.rsLabel10.TabIndex = 170;
            this.rsLabel10.Tag = "";
            this.rsLabel10.Text = "Vị trí làm việc";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Location = new System.Drawing.Point(488, 154);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(58, 13);
            this.rsLabel13.TabIndex = 172;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "chức danh";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChuc_DanhNK
            // 
            this.txtChuc_DanhNK.AutoDropDown = null;
            this.txtChuc_DanhNK.Location = new System.Drawing.Point(549, 151);
            this.txtChuc_DanhNK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtChuc_DanhNK.Name = "txtChuc_DanhNK";
            this.txtChuc_DanhNK.Size = new System.Drawing.Size(89, 20);
            this.txtChuc_DanhNK.TabIndex = 8;
            this.txtChuc_DanhNK.Text = "Tổng Giám Đốc";
            // 
            // numLuongCB
            // 
            this.numLuongCB.AutoDropDown = null;
            this.numLuongCB.bFormat = true;
            this.numLuongCB.Location = new System.Drawing.Point(121, 249);
            this.numLuongCB.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numLuongCB.Name = "numLuongCB";
            this.numLuongCB.Scale = 0;
            this.numLuongCB.Size = new System.Drawing.Size(120, 20);
            this.numLuongCB.TabIndex = 12;
            this.numLuongCB.Tag = "";
            this.numLuongCB.Text = "0";
            this.numLuongCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLuongCB.Value = 0D;
            // 
            // rsLabel69
            // 
            this.rsLabel69.AutoEllipsis = true;
            this.rsLabel69.AutoSize = true;
            this.rsLabel69.Location = new System.Drawing.Point(20, 253);
            this.rsLabel69.Name = "rsLabel69";
            this.rsLabel69.Size = new System.Drawing.Size(73, 13);
            this.rsLabel69.TabIndex = 174;
            this.rsLabel69.Tag = "";
            this.rsLabel69.Text = "Lương cơ bản";
            this.rsLabel69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel15
            // 
            this.rsLabel15.AutoEllipsis = true;
            this.rsLabel15.AutoSize = true;
            this.rsLabel15.Location = new System.Drawing.Point(272, 252);
            this.rsLabel15.Name = "rsLabel15";
            this.rsLabel15.Size = new System.Drawing.Size(83, 13);
            this.rsLabel15.TabIndex = 174;
            this.rsLabel15.Tag = "";
            this.rsLabel15.Text = "Lương bảo hiểm";
            this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLuongBH
            // 
            this.numLuongBH.AutoDropDown = null;
            this.numLuongBH.bFormat = true;
            this.numLuongBH.Location = new System.Drawing.Point(359, 249);
            this.numLuongBH.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numLuongBH.Name = "numLuongBH";
            this.numLuongBH.Scale = 0;
            this.numLuongBH.Size = new System.Drawing.Size(120, 20);
            this.numLuongBH.TabIndex = 13;
            this.numLuongBH.Tag = "";
            this.numLuongBH.Text = "0";
            this.numLuongBH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLuongBH.Value = 0D;
            // 
            // numTyLe
            // 
            this.numTyLe.AutoDropDown = null;
            this.numTyLe.bFormat = true;
            this.numTyLe.Location = new System.Drawing.Point(570, 249);
            this.numTyLe.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numTyLe.Name = "numTyLe";
            this.numTyLe.Scale = 0;
            this.numTyLe.Size = new System.Drawing.Size(35, 20);
            this.numTyLe.TabIndex = 14;
            this.numTyLe.Tag = "";
            this.numTyLe.Text = "100";
            this.numTyLe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTyLe.Value = 100D;
            // 
            // rsLabel17
            // 
            this.rsLabel17.AutoEllipsis = true;
            this.rsLabel17.AutoSize = true;
            this.rsLabel17.Location = new System.Drawing.Point(534, 252);
            this.rsLabel17.Name = "rsLabel17";
            this.rsLabel17.Size = new System.Drawing.Size(30, 13);
            this.rsLabel17.TabIndex = 176;
            this.rsLabel17.Tag = "";
            this.rsLabel17.Text = "Tỷ lệ";
            this.rsLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel19
            // 
            this.rsLabel19.AutoEllipsis = true;
            this.rsLabel19.AutoSize = true;
            this.rsLabel19.Location = new System.Drawing.Point(608, 253);
            this.rsLabel19.Name = "rsLabel19";
            this.rsLabel19.Size = new System.Drawing.Size(15, 13);
            this.rsLabel19.TabIndex = 176;
            this.rsLabel19.Tag = "";
            this.rsLabel19.Text = "%";
            this.rsLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmHDLD_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 402);
            this.Controls.Add(this.numTyLe);
            this.Controls.Add(this.rsLabel19);
            this.Controls.Add(this.rsLabel17);
            this.Controls.Add(this.numLuongBH);
            this.Controls.Add(this.rsLabel15);
            this.Controls.Add(this.numLuongCB);
            this.Controls.Add(this.rsLabel69);
            this.Controls.Add(this.rsLabel13);
            this.Controls.Add(this.txtChuc_DanhNK);
            this.Controls.Add(this.txtViTri);
            this.Controls.Add(this.rsLabel10);
            this.Controls.Add(this.txtLoai_Hd);
            this.Controls.Add(this.txtThoi_Gian_Hd);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.dteNgay_Kt);
            this.Controls.Add(this.dteNgay_Ky);
            this.Controls.Add(this.rsLabel16);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.dteNgay_Bd);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.rsLabel12);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel8);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.rsLabel11);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtSo_Hd);
            this.Controls.Add(this.txtNguoi_Ky);
            this.Controls.Add(this.txtNoi_Dung);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Name = "frmHDLD_Edit";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsTextBox txtGhi_Chu;
		private RosySystem.Control.rsDateTime dteNgay_Kt;
		private RosySystem.Control.rsDateTime dteNgay_Ky;
        private RosySystem.Control.rsLabel rsLabel16;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsDateTime dteNgay_Bd;
		private RosySystem.Control.rsLabel rsLabel12;
		private RosySystem.Control.rsLabel rsLabel7;
		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel11;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtSo_Hd;
        private RosySystem.Control.rsTextBox txtNguoi_Ky;
		private RosySystem.Control.rsTextBox txtNoi_Dung;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsTextBoxEnum txtThoi_Gian_Hd;
        private RosySystem.Control.rsTextBoxEnum txtLoai_Hd;
        private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
        private RosySystem.Control.rsTextBox txtViTri;
        private RosySystem.Control.rsLabel rsLabel10;
        private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsTextBox txtChuc_DanhNK;
        private RosySystem.Control.rsTextBoxNumber numLuongCB;
        private RosySystem.Control.rsLabel rsLabel69;
        private RosySystem.Control.rsLabel rsLabel15;
        private RosySystem.Control.rsTextBoxNumber numLuongBH;
        private RosySystem.Control.rsTextBoxNumber numTyLe;
        private RosySystem.Control.rsLabel rsLabel17;
        private RosySystem.Control.rsLabel rsLabel19;

	}
}