namespace RosyModule.HRM
{
    partial class frmXaLan_Edit
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
            this.components = new System.ComponentModel.Container();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.dteGio_Den = new RosyModule.txtTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteGio_Di = new RosyModule.txtTime();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.txtSo_DkCv = new RosySystem.Control.rsTextBox();
            this.txtSo_Xa_Lan_Tau = new RosySystem.Control.rsTextBox();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.numSo_Nguoi = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel12 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.dteNgay_Den = new RosySystem.Control.rsDateTime();
            this.dteNgay_Di = new RosySystem.Control.rsDateTime();
            this.numTai_Trong = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtMa_Vt_Sp = new RosySystem.Control.rsTextBox();
            this.txtID_BL = new RosySystem.Control.rsTextBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtNoi_Den = new RosySystem.Control.rsTextBox();
            this.txtSo_Phone = new RosySystem.Control.rsTextBox();
            this.txtID_CMND = new RosySystem.Control.rsTextBox();
            this.numTai_Trong_Xe = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.rsLabel17 = new RosySystem.Control.rsLabel();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.rsLabel16 = new RosySystem.Control.rsLabel();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.txtTen_Lx_Khach = new RosySystem.Control.rsTextBox();
            this.rsLabel18 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.btInherit = new RosySystem.Customize.btFilter();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(520, 280);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 44);
            this.btgAccept.TabIndex = 17;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(73, 38);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(45, 13);
            this.rsLabel3.TabIndex = 119;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Giờ đến";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteGio_Den
            // 
            this.dteGio_Den.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dteGio_Den.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteGio_Den.Location = new System.Drawing.Point(123, 34);
            this.dteGio_Den.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteGio_Den.Mask = "00:00:00";
            this.dteGio_Den.Name = "dteGio_Den";
            this.dteGio_Den.SelectOnFocus = false;
            this.dteGio_Den.Size = new System.Drawing.Size(55, 20);
            this.dteGio_Den.TabIndex = 1;
            this.dteGio_Den.Tag = "";
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(83, 61);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(35, 13);
            this.rsLabel2.TabIndex = 127;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Giờ đi";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteGio_Di
            // 
            this.dteGio_Di.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dteGio_Di.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteGio_Di.Location = new System.Drawing.Point(123, 57);
            this.dteGio_Di.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteGio_Di.Mask = "00:00:00";
            this.dteGio_Di.Name = "dteGio_Di";
            this.dteGio_Di.SelectOnFocus = false;
            this.dteGio_Di.Size = new System.Drawing.Size(55, 20);
            this.dteGio_Di.TabIndex = 3;
            this.dteGio_Di.Tag = "";
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Location = new System.Drawing.Point(6, 108);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(112, 13);
            this.rsLabel10.TabIndex = 131;
            this.rsLabel10.Tag = "";
            this.rsLabel10.Text = "Giấy đăng ký cảng vụ";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_DkCv
            // 
            this.txtSo_DkCv.AutoDropDown = null;
            this.txtSo_DkCv.Location = new System.Drawing.Point(123, 102);
            this.txtSo_DkCv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_DkCv.Multiline = true;
            this.txtSo_DkCv.Name = "txtSo_DkCv";
            this.txtSo_DkCv.Size = new System.Drawing.Size(279, 21);
            this.txtSo_DkCv.TabIndex = 6;
            // 
            // txtSo_Xa_Lan_Tau
            // 
            this.txtSo_Xa_Lan_Tau.AutoDropDown = null;
            this.txtSo_Xa_Lan_Tau.Location = new System.Drawing.Point(123, 9);
            this.txtSo_Xa_Lan_Tau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Xa_Lan_Tau.Multiline = true;
            this.txtSo_Xa_Lan_Tau.Name = "txtSo_Xa_Lan_Tau";
            this.txtSo_Xa_Lan_Tau.Size = new System.Drawing.Size(279, 21);
            this.txtSo_Xa_Lan_Tau.TabIndex = 0;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(56, 12);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(62, 13);
            this.rsLabel9.TabIndex = 121;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Xà Lan, tàu";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Nguoi
            // 
            this.numSo_Nguoi.AutoDropDown = null;
            this.numSo_Nguoi.bFormat = true;
            this.numSo_Nguoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSo_Nguoi.Location = new System.Drawing.Point(123, 80);
            this.numSo_Nguoi.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numSo_Nguoi.Name = "numSo_Nguoi";
            this.numSo_Nguoi.Scale = 0;
            this.numSo_Nguoi.Size = new System.Drawing.Size(55, 19);
            this.numSo_Nguoi.TabIndex = 5;
            this.numSo_Nguoi.Tag = "";
            this.numSo_Nguoi.Text = "0";
            this.numSo_Nguoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Nguoi.Value = 0D;
            // 
            // rsLabel12
            // 
            this.rsLabel12.AutoEllipsis = true;
            this.rsLabel12.AutoSize = true;
            this.rsLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel12.Location = new System.Drawing.Point(30, 83);
            this.rsLabel12.Name = "rsLabel12";
            this.rsLabel12.Size = new System.Drawing.Size(88, 13);
            this.rsLabel12.TabIndex = 139;
            this.rsLabel12.Tag = "";
            this.rsLabel12.Text = "Số người đi cùng";
            this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(178, 38);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(54, 13);
            this.rsLabel1.TabIndex = 119;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Ngày đến";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(188, 61);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(44, 13);
            this.rsLabel4.TabIndex = 127;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Ngày đi";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Den
            // 
            this.dteNgay_Den.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteNgay_Den.bAllowEmpty = false;
            this.dteNgay_Den.bSelectOnFocus = false;
            this.dteNgay_Den.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Den.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Den.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Den.Location = new System.Drawing.Point(233, 34);
            this.dteNgay_Den.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Den.Mask = "00/00/0000";
            this.dteNgay_Den.Name = "dteNgay_Den";
            this.dteNgay_Den.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Den.TabIndex = 140;
            // 
            // dteNgay_Di
            // 
            this.dteNgay_Di.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteNgay_Di.bAllowEmpty = false;
            this.dteNgay_Di.bSelectOnFocus = false;
            this.dteNgay_Di.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Di.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Di.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Di.Location = new System.Drawing.Point(233, 56);
            this.dteNgay_Di.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Di.Mask = "00/00/0000";
            this.dteNgay_Di.Name = "dteNgay_Di";
            this.dteNgay_Di.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Di.TabIndex = 140;
            // 
            // numTai_Trong
            // 
            this.numTai_Trong.AutoDropDown = null;
            this.numTai_Trong.bFormat = true;
            this.numTai_Trong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTai_Trong.Location = new System.Drawing.Point(360, 194);
            this.numTai_Trong.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numTai_Trong.Name = "numTai_Trong";
            this.numTai_Trong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numTai_Trong.Scale = 0;
            this.numTai_Trong.Size = new System.Drawing.Size(120, 19);
            this.numTai_Trong.TabIndex = 13;
            this.numTai_Trong.Tag = "";
            this.numTai_Trong.Text = "0";
            this.numTai_Trong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTai_Trong.Value = 0D;
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel13.Location = new System.Drawing.Point(242, 197);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(118, 13);
            this.rsLabel13.TabIndex = 1047;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "Tải trọng cho phép (kg)";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(246, 240);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(42, 13);
            this.lbtTen_Vt.TabIndex = 1045;
            this.lbtTen_Vt.Text = "Ten_Vt";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(68, 241);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(54, 13);
            this.rsLabel5.TabIndex = 1044;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Hàng hóa";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt_Sp
            // 
            this.txtMa_Vt_Sp.AutoDropDown = null;
            this.txtMa_Vt_Sp.Location = new System.Drawing.Point(123, 236);
            this.txtMa_Vt_Sp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt_Sp.Name = "txtMa_Vt_Sp";
            this.txtMa_Vt_Sp.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt_Sp.TabIndex = 16;
            // 
            // txtID_BL
            // 
            this.txtID_BL.AutoDropDown = null;
            this.txtID_BL.Location = new System.Drawing.Point(123, 171);
            this.txtID_BL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtID_BL.Multiline = true;
            this.txtID_BL.Name = "txtID_BL";
            this.txtID_BL.Size = new System.Drawing.Size(182, 21);
            this.txtID_BL.TabIndex = 10;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(62, 177);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(60, 13);
            this.rsLabel7.TabIndex = 1043;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Số bằng lái";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoi_Den
            // 
            this.txtNoi_Den.AutoDropDown = null;
            this.txtNoi_Den.Location = new System.Drawing.Point(360, 171);
            this.txtNoi_Den.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNoi_Den.Multiline = true;
            this.txtNoi_Den.Name = "txtNoi_Den";
            this.txtNoi_Den.Size = new System.Drawing.Size(319, 21);
            this.txtNoi_Den.TabIndex = 11;
            // 
            // txtSo_Phone
            // 
            this.txtSo_Phone.AutoDropDown = null;
            this.txtSo_Phone.Location = new System.Drawing.Point(360, 148);
            this.txtSo_Phone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Phone.MaxLength = 20;
            this.txtSo_Phone.Multiline = true;
            this.txtSo_Phone.Name = "txtSo_Phone";
            this.txtSo_Phone.Size = new System.Drawing.Size(220, 21);
            this.txtSo_Phone.TabIndex = 9;
            // 
            // txtID_CMND
            // 
            this.txtID_CMND.AutoDropDown = null;
            this.txtID_CMND.Location = new System.Drawing.Point(123, 148);
            this.txtID_CMND.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtID_CMND.Multiline = true;
            this.txtID_CMND.Name = "txtID_CMND";
            this.txtID_CMND.Size = new System.Drawing.Size(182, 21);
            this.txtID_CMND.TabIndex = 8;
            // 
            // numTai_Trong_Xe
            // 
            this.numTai_Trong_Xe.AutoDropDown = null;
            this.numTai_Trong_Xe.bFormat = true;
            this.numTai_Trong_Xe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTai_Trong_Xe.Location = new System.Drawing.Point(123, 194);
            this.numTai_Trong_Xe.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numTai_Trong_Xe.Name = "numTai_Trong_Xe";
            this.numTai_Trong_Xe.Scale = 0;
            this.numTai_Trong_Xe.Size = new System.Drawing.Size(120, 19);
            this.numTai_Trong_Xe.TabIndex = 12;
            this.numTai_Trong_Xe.Tag = "";
            this.numTai_Trong_Xe.Text = "0";
            this.numTai_Trong_Xe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTai_Trong_Xe.Value = 0D;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel6.Location = new System.Drawing.Point(36, 199);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(84, 13);
            this.rsLabel6.TabIndex = 1041;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Tải trọng xe (kg)";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel17
            // 
            this.rsLabel17.AutoEllipsis = true;
            this.rsLabel17.AutoSize = true;
            this.rsLabel17.Location = new System.Drawing.Point(310, 175);
            this.rsLabel17.Name = "rsLabel17";
            this.rsLabel17.Size = new System.Drawing.Size(45, 13);
            this.rsLabel17.TabIndex = 1038;
            this.rsLabel17.Tag = "";
            this.rsLabel17.Text = "Nơi đến";
            this.rsLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(246, 218);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(59, 13);
            this.lbtTen_Dt.TabIndex = 1040;
            this.lbtTen_Dt.Text = "Ten_CbNv";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel16
            // 
            this.rsLabel16.AutoEllipsis = true;
            this.rsLabel16.AutoSize = true;
            this.rsLabel16.Location = new System.Drawing.Point(310, 152);
            this.rsLabel16.Name = "rsLabel16";
            this.rsLabel16.Size = new System.Drawing.Size(38, 13);
            this.rsLabel16.TabIndex = 1036;
            this.rsLabel16.Tag = "";
            this.rsLabel16.Text = "Số ĐT";
            this.rsLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(67, 154);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(55, 13);
            this.rsLabel8.TabIndex = 1037;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Số CMND";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(68, 130);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(54, 13);
            this.rsLabel11.TabIndex = 1039;
            this.rsLabel11.Tag = "";
            this.rsLabel11.Text = "Tên tài xế";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Lx_Khach
            // 
            this.txtTen_Lx_Khach.AutoDropDown = null;
            this.txtTen_Lx_Khach.Location = new System.Drawing.Point(123, 125);
            this.txtTen_Lx_Khach.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Lx_Khach.Multiline = true;
            this.txtTen_Lx_Khach.Name = "txtTen_Lx_Khach";
            this.txtTen_Lx_Khach.Size = new System.Drawing.Size(279, 21);
            this.txtTen_Lx_Khach.TabIndex = 7;
            // 
            // rsLabel18
            // 
            this.rsLabel18.AutoEllipsis = true;
            this.rsLabel18.AutoSize = true;
            this.rsLabel18.Location = new System.Drawing.Point(40, 219);
            this.rsLabel18.Name = "rsLabel18";
            this.rsLabel18.Size = new System.Drawing.Size(82, 13);
            this.rsLabel18.TabIndex = 1035;
            this.rsLabel18.Tag = "";
            this.rsLabel18.Text = "Mã khách hàng";
            this.rsLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.Location = new System.Drawing.Point(123, 214);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 15;
            // 
            // btInherit
            // 
            this.btInherit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInherit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInherit.ImageKey = "(none)";
            this.btInherit.Location = new System.Drawing.Point(407, 9);
            this.btInherit.Name = "btInherit";
            this.btInherit.Size = new System.Drawing.Size(86, 32);
            this.btInherit.TabIndex = 1048;
            this.btInherit.Tag = "Inherit";
            this.btInherit.Text = "&Kế thừa dữ liệu";
            this.btInherit.UseVisualStyleBackColor = true;
            // 
            // frmXaLan_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 328);
            this.Controls.Add(this.btInherit);
            this.Controls.Add(this.numTai_Trong);
            this.Controls.Add(this.rsLabel13);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.txtMa_Vt_Sp);
            this.Controls.Add(this.txtID_BL);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.txtNoi_Den);
            this.Controls.Add(this.txtSo_Phone);
            this.Controls.Add(this.txtID_CMND);
            this.Controls.Add(this.numTai_Trong_Xe);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.rsLabel17);
            this.Controls.Add(this.lbtTen_Dt);
            this.Controls.Add(this.rsLabel16);
            this.Controls.Add(this.rsLabel8);
            this.Controls.Add(this.rsLabel11);
            this.Controls.Add(this.txtTen_Lx_Khach);
            this.Controls.Add(this.rsLabel18);
            this.Controls.Add(this.txtMa_Dt);
            this.Controls.Add(this.dteNgay_Di);
            this.Controls.Add(this.dteNgay_Den);
            this.Controls.Add(this.numSo_Nguoi);
            this.Controls.Add(this.rsLabel12);
            this.Controls.Add(this.txtSo_DkCv);
            this.Controls.Add(this.rsLabel10);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.dteGio_Di);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.dteGio_Den);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtSo_Xa_Lan_Tau);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmXaLan_Edit";
            this.Text = "frmXaLan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel rsLabel3;
        private txtTime dteGio_Den;
        private RosySystem.Control.rsLabel rsLabel2;
        private txtTime dteGio_Di;
        private RosySystem.Control.rsLabel rsLabel10;
        private RosySystem.Control.rsTextBox txtSo_DkCv;
        private RosySystem.Control.rsTextBox txtSo_Xa_Lan_Tau;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsTextBoxNumber numSo_Nguoi;
        private RosySystem.Control.rsLabel rsLabel12;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsDateTime dteNgay_Den;
        private RosySystem.Control.rsDateTime dteNgay_Di;
        private RosySystem.Control.rsTextBoxNumber numTai_Trong;
        private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsLabel lbtTen_Vt;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBox txtMa_Vt_Sp;
        private RosySystem.Control.rsTextBox txtID_BL;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsTextBox txtNoi_Den;
        private RosySystem.Control.rsTextBox txtSo_Phone;
        private RosySystem.Control.rsTextBox txtID_CMND;
        private RosySystem.Control.rsTextBoxNumber numTai_Trong_Xe;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsLabel rsLabel17;
        private RosySystem.Control.rsLabel lbtTen_Dt;
        private RosySystem.Control.rsLabel rsLabel16;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsLabel rsLabel11;
        private RosySystem.Control.rsTextBox txtTen_Lx_Khach;
        private RosySystem.Control.rsLabel rsLabel18;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Customize.btFilter btInherit;

	}
}