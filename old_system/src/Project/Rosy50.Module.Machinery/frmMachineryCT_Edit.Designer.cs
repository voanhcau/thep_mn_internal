namespace RosyModule.Machinery
{
    partial class frmMachineryCT_Edit
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
            this.tabEdit = new RosySystem.Control.rsTabControl();
            this.Page1 = new System.Windows.Forms.TabPage();
            this.txtMa_Bp = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtNam_SX = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.dteNgay_Bd_Sd = new RosySystem.Control.rsDateTime();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtMo_Ta_Tb = new RosySystem.Control.rsTextBox();
            this.txtTinh_Trang = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtSo_QD_BG = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.txtNuoc_SX = new RosySystem.Control.rsTextBox();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabel();
            this.lbtNuoc_Sx = new RosySystem.Control.rsLabel();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.txtTen_Tb = new RosySystem.Control.rsTextBox();
            this.txtMa_Tb = new RosySystem.Control.rsTextBox();
            this.txtMa_Nh_Tb = new RosySystem.Control.rsTextBox();
            this.lbtTen_Nh_Tb = new RosySystem.Control.rsLabel();
            this.lbMa_Nh_Vt = new RosySystem.Control.rsLabel();
            this.lbTen_Vt = new RosySystem.Control.rsLabel();
            this.lbMa_Vt = new RosySystem.Control.rsLabel();
            this.Page2 = new System.Windows.Forms.TabPage();
            this.lblMa_Data = new RosySystem.Control.rsLabel();
            this.lblNgay_End = new RosySystem.Control.rsLabel();
            this.lblNgay_Begin = new RosySystem.Control.rsLabel();
            this.ucMa_Data = new RosySystem.Customize.ucMa_Data();
            this.txtNgay_End = new RosySystem.Customize.txtNgay_End();
            this.txtNgay_Begin = new RosySystem.Customize.txtNgay_Begin();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.dteNgay_Kt_Sd = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam_SX)).BeginInit();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEdit
            // 
            this.tabEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEdit.Controls.Add(this.Page1);
            this.tabEdit.Controls.Add(this.Page2);
            this.tabEdit.Location = new System.Drawing.Point(0, 1);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.SelectedIndex = 0;
            this.tabEdit.Size = new System.Drawing.Size(578, 513);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.dteNgay_Kt_Sd);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.txtMa_Bp);
            this.Page1.Controls.Add(this.rsLabel5);
            this.Page1.Controls.Add(this.txtNam_SX);
            this.Page1.Controls.Add(this.rsLabel8);
            this.Page1.Controls.Add(this.dteNgay_Bd_Sd);
            this.Page1.Controls.Add(this.rsLabel7);
            this.Page1.Controls.Add(this.txtMo_Ta_Tb);
            this.Page1.Controls.Add(this.txtTinh_Trang);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.txtSo_QD_BG);
            this.Page1.Controls.Add(this.rsLabel6);
            this.Page1.Controls.Add(this.txtNuoc_SX);
            this.Page1.Controls.Add(this.rsLabel9);
            this.Page1.Controls.Add(this.lbtTen_Bp);
            this.Page1.Controls.Add(this.lbtNuoc_Sx);
            this.Page1.Controls.Add(this.rsLabel11);
            this.Page1.Controls.Add(this.txtTen_Tb);
            this.Page1.Controls.Add(this.txtMa_Tb);
            this.Page1.Controls.Add(this.txtMa_Nh_Tb);
            this.Page1.Controls.Add(this.lbtTen_Nh_Tb);
            this.Page1.Controls.Add(this.lbMa_Nh_Vt);
            this.Page1.Controls.Add(this.lbTen_Vt);
            this.Page1.Controls.Add(this.lbMa_Vt);
            this.Page1.Location = new System.Drawing.Point(4, 22);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(3);
            this.Page1.Size = new System.Drawing.Size(570, 487);
            this.Page1.TabIndex = 0;
            this.Page1.Tag = "Detail_Info";
            this.Page1.Text = "Thông tin chi tiết";
            this.Page1.UseVisualStyleBackColor = true;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.AutoDropDown = null;
            this.txtMa_Bp.Location = new System.Drawing.Point(155, 228);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.MaxLength = 100;
            this.txtMa_Bp.Multiline = true;
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(75, 20);
            this.txtMa_Bp.TabIndex = 9;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(35, 228);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(84, 13);
            this.rsLabel5.TabIndex = 176;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Bộ phận quản lý";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNam_SX
            // 
            this.txtNam_SX.Location = new System.Drawing.Point(155, 134);
            this.txtNam_SX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNam_SX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNam_SX.Name = "txtNam_SX";
            this.txtNam_SX.Size = new System.Drawing.Size(71, 20);
            this.txtNam_SX.TabIndex = 5;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(35, 136);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(72, 13);
            this.rsLabel8.TabIndex = 175;
            this.rsLabel8.Tag = "Nam_SX";
            this.rsLabel8.Text = "Năm sản xuất";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Bd_Sd
            // 
            this.dteNgay_Bd_Sd.bAllowEmpty = true;
            this.dteNgay_Bd_Sd.bSelectOnFocus = false;
            this.dteNgay_Bd_Sd.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Bd_Sd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Bd_Sd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Bd_Sd.Location = new System.Drawing.Point(155, 181);
            this.dteNgay_Bd_Sd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Bd_Sd.Mask = "00/00/0000";
            this.dteNgay_Bd_Sd.Name = "dteNgay_Bd_Sd";
            this.dteNgay_Bd_Sd.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Bd_Sd.TabIndex = 7;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(33, 184);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(113, 13);
            this.rsLabel7.TabIndex = 174;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Ngày bắt đầu sử dụng";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMo_Ta_Tb
            // 
            this.txtMo_Ta_Tb.AutoDropDown = null;
            this.txtMo_Ta_Tb.Location = new System.Drawing.Point(155, 305);
            this.txtMo_Ta_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMo_Ta_Tb.MaxLength = 100;
            this.txtMo_Ta_Tb.Multiline = true;
            this.txtMo_Ta_Tb.Name = "txtMo_Ta_Tb";
            this.txtMo_Ta_Tb.Size = new System.Drawing.Size(375, 51);
            this.txtMo_Ta_Tb.TabIndex = 11;
            // 
            // txtTinh_Trang
            // 
            this.txtTinh_Trang.AutoDropDown = null;
            this.txtTinh_Trang.Location = new System.Drawing.Point(155, 252);
            this.txtTinh_Trang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTinh_Trang.MaxLength = 100;
            this.txtTinh_Trang.Multiline = true;
            this.txtTinh_Trang.Name = "txtTinh_Trang";
            this.txtTinh_Trang.Size = new System.Drawing.Size(375, 51);
            this.txtTinh_Trang.TabIndex = 10;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(35, 309);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(68, 13);
            this.rsLabel1.TabIndex = 171;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mô tả thiết bị";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_QD_BG
            // 
            this.txtSo_QD_BG.AutoDropDown = null;
            this.txtSo_QD_BG.Location = new System.Drawing.Point(155, 158);
            this.txtSo_QD_BG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_QD_BG.MaxLength = 100;
            this.txtSo_QD_BG.Multiline = true;
            this.txtSo_QD_BG.Name = "txtSo_QD_BG";
            this.txtSo_QD_BG.Size = new System.Drawing.Size(75, 20);
            this.txtSo_QD_BG.TabIndex = 6;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(35, 256);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(116, 13);
            this.rsLabel6.TabIndex = 171;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Tình trạng khi bàn giao";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNuoc_SX
            // 
            this.txtNuoc_SX.AutoDropDown = null;
            this.txtNuoc_SX.Location = new System.Drawing.Point(155, 112);
            this.txtNuoc_SX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNuoc_SX.MaxLength = 100;
            this.txtNuoc_SX.Multiline = true;
            this.txtNuoc_SX.Name = "txtNuoc_SX";
            this.txtNuoc_SX.Size = new System.Drawing.Size(75, 20);
            this.txtNuoc_SX.TabIndex = 4;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(35, 162);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(117, 13);
            this.rsLabel9.TabIndex = 170;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Số quyết định bàn giao";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoEllipsis = true;
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.Location = new System.Drawing.Point(234, 231);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(68, 13);
            this.lbtTen_Bp.TabIndex = 169;
            this.lbtTen_Bp.Tag = "";
            this.lbtTen_Bp.Text = "Tên bộ phận";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtNuoc_Sx
            // 
            this.lbtNuoc_Sx.AutoEllipsis = true;
            this.lbtNuoc_Sx.AutoSize = true;
            this.lbtNuoc_Sx.Location = new System.Drawing.Point(234, 116);
            this.lbtNuoc_Sx.Name = "lbtNuoc_Sx";
            this.lbtNuoc_Sx.Size = new System.Drawing.Size(76, 13);
            this.lbtNuoc_Sx.TabIndex = 173;
            this.lbtNuoc_Sx.Tag = "";
            this.lbtNuoc_Sx.Text = "Nước sản xuất";
            this.lbtNuoc_Sx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(36, 115);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(76, 13);
            this.rsLabel11.TabIndex = 172;
            this.rsLabel11.Tag = "Nuoc_SX";
            this.rsLabel11.Text = "Nước sản xuất";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Tb
            // 
            this.txtTen_Tb.AutoDropDown = null;
            this.txtTen_Tb.Location = new System.Drawing.Point(155, 41);
            this.txtTen_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Tb.MaxLength = 500;
            this.txtTen_Tb.Name = "txtTen_Tb";
            this.txtTen_Tb.Size = new System.Drawing.Size(375, 20);
            this.txtTen_Tb.TabIndex = 1;
            // 
            // txtMa_Tb
            // 
            this.txtMa_Tb.AutoDropDown = null;
            this.txtMa_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb.Location = new System.Drawing.Point(155, 19);
            this.txtMa_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb.MaxLength = 20;
            this.txtMa_Tb.Name = "txtMa_Tb";
            this.txtMa_Tb.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Tb.TabIndex = 0;
            // 
            // txtMa_Nh_Tb
            // 
            this.txtMa_Nh_Tb.AutoDropDown = null;
            this.txtMa_Nh_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_Tb.ForeColor = System.Drawing.Color.Red;
            this.txtMa_Nh_Tb.Location = new System.Drawing.Point(155, 65);
            this.txtMa_Nh_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Tb.Name = "txtMa_Nh_Tb";
            this.txtMa_Nh_Tb.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_Tb.TabIndex = 2;
            // 
            // lbtTen_Nh_Tb
            // 
            this.lbtTen_Nh_Tb.AutoEllipsis = true;
            this.lbtTen_Nh_Tb.AutoSize = true;
            this.lbtTen_Nh_Tb.ForeColor = System.Drawing.Color.Red;
            this.lbtTen_Nh_Tb.Location = new System.Drawing.Point(280, 68);
            this.lbtTen_Nh_Tb.Name = "lbtTen_Nh_Tb";
            this.lbtTen_Nh_Tb.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_Nh_Tb.TabIndex = 136;
            this.lbtTen_Nh_Tb.Text = "Tên nhóm ";
            this.lbtTen_Nh_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Nh_Vt
            // 
            this.lbMa_Nh_Vt.AutoEllipsis = true;
            this.lbMa_Nh_Vt.AutoSize = true;
            this.lbMa_Nh_Vt.ForeColor = System.Drawing.Color.Red;
            this.lbMa_Nh_Vt.Location = new System.Drawing.Point(35, 68);
            this.lbMa_Nh_Vt.Name = "lbMa_Nh_Vt";
            this.lbMa_Nh_Vt.Size = new System.Drawing.Size(69, 13);
            this.lbMa_Nh_Vt.TabIndex = 133;
            this.lbMa_Nh_Vt.Tag = "";
            this.lbMa_Nh_Vt.Text = "Nhóm thiết bị";
            this.lbMa_Nh_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTen_Vt
            // 
            this.lbTen_Vt.AutoEllipsis = true;
            this.lbTen_Vt.AutoSize = true;
            this.lbTen_Vt.Location = new System.Drawing.Point(35, 44);
            this.lbTen_Vt.Name = "lbTen_Vt";
            this.lbTen_Vt.Size = new System.Drawing.Size(60, 13);
            this.lbTen_Vt.TabIndex = 135;
            this.lbTen_Vt.Tag = "Ten_Tb";
            this.lbTen_Vt.Text = "Tên thiết bị";
            this.lbTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(35, 21);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbMa_Vt.TabIndex = 134;
            this.lbMa_Vt.Tag = "Ma_Tb";
            this.lbMa_Vt.Text = "Mã thiết bị";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Page2
            // 
            this.Page2.Controls.Add(this.lblMa_Data);
            this.Page2.Controls.Add(this.lblNgay_End);
            this.Page2.Controls.Add(this.lblNgay_Begin);
            this.Page2.Controls.Add(this.ucMa_Data);
            this.Page2.Controls.Add(this.txtNgay_End);
            this.Page2.Controls.Add(this.txtNgay_Begin);
            this.Page2.Location = new System.Drawing.Point(4, 22);
            this.Page2.Name = "Page2";
            this.Page2.Size = new System.Drawing.Size(570, 487);
            this.Page2.TabIndex = 5;
            this.Page2.Tag = "Extra_Detail_Info";
            this.Page2.Text = "Thông tin thêm";
            this.Page2.UseVisualStyleBackColor = true;
            // 
            // lblMa_Data
            // 
            this.lblMa_Data.AutoEllipsis = true;
            this.lblMa_Data.AutoSize = true;
            this.lblMa_Data.Location = new System.Drawing.Point(22, 71);
            this.lblMa_Data.Name = "lblMa_Data";
            this.lblMa_Data.Size = new System.Drawing.Size(56, 13);
            this.lblMa_Data.TabIndex = 3;
            this.lblMa_Data.Tag = "Ma_Data";
            this.lblMa_Data.Text = "Mã dữ liệu";
            this.lblMa_Data.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_End
            // 
            this.lblNgay_End.AutoEllipsis = true;
            this.lblNgay_End.AutoSize = true;
            this.lblNgay_End.Location = new System.Drawing.Point(22, 47);
            this.lblNgay_End.Name = "lblNgay_End";
            this.lblNgay_End.Size = new System.Drawing.Size(74, 13);
            this.lblNgay_End.TabIndex = 3;
            this.lblNgay_End.Tag = "Ngay_End";
            this.lblNgay_End.Text = "Ngày kết thúc";
            this.lblNgay_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Begin
            // 
            this.lblNgay_Begin.AutoEllipsis = true;
            this.lblNgay_Begin.AutoSize = true;
            this.lblNgay_Begin.Location = new System.Drawing.Point(22, 23);
            this.lblNgay_Begin.Name = "lblNgay_Begin";
            this.lblNgay_Begin.Size = new System.Drawing.Size(72, 13);
            this.lblNgay_Begin.TabIndex = 3;
            this.lblNgay_Begin.Tag = "Ngay_Begin";
            this.lblNgay_Begin.Text = "Ngày bắt đầu";
            this.lblNgay_Begin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucMa_Data
            // 
            this.ucMa_Data.Location = new System.Drawing.Point(116, 67);
            this.ucMa_Data.Name = "ucMa_Data";
            this.ucMa_Data.Size = new System.Drawing.Size(359, 24);
            this.ucMa_Data.TabIndex = 2;
            // 
            // txtNgay_End
            // 
            this.txtNgay_End.bAllowEmpty = true;
            this.txtNgay_End.bSelectOnFocus = false;
            this.txtNgay_End.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_End.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_End.Location = new System.Drawing.Point(116, 44);
            this.txtNgay_End.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_End.Mask = "00/00/0000";
            this.txtNgay_End.Name = "txtNgay_End";
            this.txtNgay_End.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_End.TabIndex = 1;
            // 
            // txtNgay_Begin
            // 
            this.txtNgay_Begin.bAllowEmpty = true;
            this.txtNgay_Begin.bSelectOnFocus = false;
            this.txtNgay_Begin.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Begin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Begin.Location = new System.Drawing.Point(116, 20);
            this.txtNgay_Begin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Begin.Mask = "00/00/0000";
            this.txtNgay_Begin.Name = "txtNgay_Begin";
            this.txtNgay_Begin.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Begin.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(7, 529);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lblLog
            // 
            this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLog.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.Blue;
            this.lblLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLog.Location = new System.Drawing.Point(43, 539);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(346, 22);
            this.lblLog.TabIndex = 11;
            this.lblLog.Text = "CreateLog:.....................; LastModifyLog:....................";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(384, 519);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 1;
            // 
            // dteNgay_Kt_Sd
            // 
            this.dteNgay_Kt_Sd.bAllowEmpty = true;
            this.dteNgay_Kt_Sd.bSelectOnFocus = false;
            this.dteNgay_Kt_Sd.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Kt_Sd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kt_Sd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kt_Sd.Location = new System.Drawing.Point(155, 203);
            this.dteNgay_Kt_Sd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Kt_Sd.Mask = "00/00/0000";
            this.dteNgay_Kt_Sd.Name = "dteNgay_Kt_Sd";
            this.dteNgay_Kt_Sd.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Kt_Sd.TabIndex = 8;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(33, 206);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(115, 13);
            this.rsLabel2.TabIndex = 178;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Ngày kết thúc sử dụng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMachineryCT_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 570);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.tabEdit);
            this.Name = "frmMachineryCT_Edit";
            this.Object_ID = "DMTB";
            this.Tag = "DmVtTb";
            this.Text = "frmMachineryCT_Edit";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam_SX)).EndInit();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RosySystem.Control.rsTabControl tabEdit;
        public System.Windows.Forms.TabPage Page1;
        public System.Windows.Forms.TabPage Page2;
        public RosySystem.Control.rsLabel lblMa_Data;
        public RosySystem.Control.rsLabel lblNgay_End;
        public RosySystem.Control.rsLabel lblNgay_Begin;
        public RosySystem.Customize.ucMa_Data ucMa_Data;
        public RosySystem.Customize.txtNgay_End txtNgay_End;
        public RosySystem.Customize.txtNgay_Begin txtNgay_Begin;
        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Label lblLog;
        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsTextBox txtTen_Tb;
        private RosySystem.Control.rsTextBox txtMa_Tb;
        private RosySystem.Control.rsTextBox txtMa_Nh_Tb;
        private RosySystem.Control.rsLabel lbtTen_Nh_Tb;
        private RosySystem.Control.rsLabel lbMa_Nh_Vt;
        private RosySystem.Control.rsLabel lbTen_Vt;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsTextBox txtMa_Bp;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsNumericUpdown txtNam_SX;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsDateTime dteNgay_Bd_Sd;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsTextBox txtTinh_Trang;
        private RosySystem.Control.rsTextBox txtSo_QD_BG;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBox txtNuoc_SX;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsLabel lbtTen_Bp;
        private RosySystem.Control.rsLabel lbtNuoc_Sx;
        private RosySystem.Control.rsLabel rsLabel11;
        private RosySystem.Control.rsTextBox txtMo_Ta_Tb;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Kt_Sd;
        private RosySystem.Control.rsLabel rsLabel2;

    }
}