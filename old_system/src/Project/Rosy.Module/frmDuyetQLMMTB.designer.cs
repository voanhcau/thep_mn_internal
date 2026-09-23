namespace RosyModule
{
    partial class frmDuyetQLMMTB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetQLMMTB));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbChitiet = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.txtGD_Duyet = new RosySystem.Control.rsTextBox();
            this.lblGiam_Doc_Duyet = new RosySystem.Control.rsLabel();
            this.lbtTen_Gd_Duyet = new RosySystem.Control.rsLabel();
            this.chkDuyet = new RosySystem.Control.rsCheckbox();
            this.btOpen_Bg = new RosySystem.Control.rsButton();
            this.tbAttach = new RosySystem.Control.rsTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvResource = new RosySystem.Customize.dgvVoucher();
            this.btPrint = new RosySystem.Control.rsButton();
            this.txtNguyen_Nhan = new RosySystem.Control.rsTextBox();
            this.lbtNguyen_Nhan = new RosySystem.Control.rsLabel();
            this.txtTinh_Trang_Tb = new RosySystem.Control.rsTextBox();
            this.lbtTinh_Trang_Tb = new RosySystem.Control.rsLabel();
            this.txtPhuong_An = new RosySystem.Control.rsTextBox();
            this.lbtPhuong_An2 = new RosySystem.Control.rsLabel();
            this.lbtPhuong_An1 = new RosySystem.Control.rsLabel();
            this.txtNoi_Dung = new RosySystem.Control.rsTextBox();
            this.lbtNoi_Dung = new RosySystem.Control.rsLabel();
            this.lbtBoPhan = new RosySystem.Control.rsLabel();
            this.chkIs_Kh = new RosySystem.Control.rsCheckbox();
            this.cboMa_Bp_Th = new RosySystem.Control.rsComboBox();
            this.lbtTinh_Trang_Th = new RosySystem.Control.rsLabel();
            this.txtTinh_Trang_Th = new RosySystem.Control.rsTextBox();
            this.txtTen_Dt = new RosySystem.Control.rsTextBox();
            this.lblTen_Dt = new RosySystem.Control.rsLabel();
            this.lblDien_Giai = new RosySystem.Control.rsLabel();
            this.txtDien_Giai = new RosySystem.Control.rsTextBox();
            this.txtPhuong_An1 = new RosySystem.Control.rsTextBox();
            this.lblPhuong_An1 = new RosySystem.Control.rsLabel();
            this.chkLock = new RosySystem.Control.rsCheckbox();
            this.tbChitiet.SuspendLayout();
            this.tbAttach.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbChitiet
            // 
            this.tbChitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChitiet.Controls.Add(this.tabPage1);
            this.tbChitiet.Location = new System.Drawing.Point(3, 113);
            this.tbChitiet.Name = "tbChitiet";
            this.tbChitiet.SelectedIndex = 0;
            this.tbChitiet.Size = new System.Drawing.Size(1131, 358);
            this.tbChitiet.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1123, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chi tiết duyệt đề nghị";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(949, 697);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // txtGD_Duyet
            // 
            this.txtGD_Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGD_Duyet.AutoDropDown = null;
            this.txtGD_Duyet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGD_Duyet.Location = new System.Drawing.Point(97, 721);
            this.txtGD_Duyet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtGD_Duyet.MaxLength = 20;
            this.txtGD_Duyet.Name = "txtGD_Duyet";
            this.txtGD_Duyet.Size = new System.Drawing.Size(117, 20);
            this.txtGD_Duyet.TabIndex = 64;
            // 
            // lblGiam_Doc_Duyet
            // 
            this.lblGiam_Doc_Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGiam_Doc_Duyet.AutoEllipsis = true;
            this.lblGiam_Doc_Duyet.AutoSize = true;
            this.lblGiam_Doc_Duyet.Location = new System.Drawing.Point(10, 723);
            this.lblGiam_Doc_Duyet.Name = "lblGiam_Doc_Duyet";
            this.lblGiam_Doc_Duyet.Size = new System.Drawing.Size(82, 13);
            this.lblGiam_Doc_Duyet.TabIndex = 65;
            this.lblGiam_Doc_Duyet.Tag = "";
            this.lblGiam_Doc_Duyet.Text = "Giám đốc duyệt";
            this.lblGiam_Doc_Duyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Gd_Duyet
            // 
            this.lbtTen_Gd_Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbtTen_Gd_Duyet.AutoEllipsis = true;
            this.lbtTen_Gd_Duyet.AutoSize = true;
            this.lbtTen_Gd_Duyet.Location = new System.Drawing.Point(219, 723);
            this.lbtTen_Gd_Duyet.Name = "lbtTen_Gd_Duyet";
            this.lbtTen_Gd_Duyet.Size = new System.Drawing.Size(102, 13);
            this.lbtTen_Gd_Duyet.TabIndex = 65;
            this.lbtTen_Gd_Duyet.Tag = "";
            this.lbtTen_Gd_Duyet.Text = "Tên giám đốc duyệt";
            this.lbtTen_Gd_Duyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDuyet
            // 
            this.chkDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDuyet.ForeColor = System.Drawing.Color.Red;
            this.chkDuyet.Location = new System.Drawing.Point(7, 642);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(121, 19);
            this.chkDuyet.TabIndex = 66;
            this.chkDuyet.Text = "Duyệt chứng từ";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // btOpen_Bg
            // 
            this.btOpen_Bg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpen_Bg.Location = new System.Drawing.Point(794, 698);
            this.btOpen_Bg.Name = "btOpen_Bg";
            this.btOpen_Bg.Size = new System.Drawing.Size(73, 40);
            this.btOpen_Bg.TabIndex = 11;
            this.btOpen_Bg.Text = "Xem file attach";
            this.btOpen_Bg.UseVisualStyleBackColor = true;
            // 
            // tbAttach
            // 
            this.tbAttach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAttach.Controls.Add(this.tabPage2);
            this.tbAttach.Location = new System.Drawing.Point(2, 472);
            this.tbAttach.Name = "tbAttach";
            this.tbAttach.SelectedIndex = 0;
            this.tbAttach.Size = new System.Drawing.Size(1125, 164);
            this.tbAttach.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvResource);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1117, 138);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Chi tiết file attach file";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvResource
            // 
            this.dgvResource.AllowUserToAddRows = false;
            this.dgvResource.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvResource.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResource.BackgroundColor = System.Drawing.Color.White;
            this.dgvResource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResource.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvResource.Location = new System.Drawing.Point(3, 3);
            this.dgvResource.MultiSelect = false;
            this.dgvResource.Name = "dgvResource";
            this.dgvResource.Size = new System.Drawing.Size(1111, 132);
            this.dgvResource.strZone = "";
            this.dgvResource.TabIndex = 1;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Location = new System.Drawing.Point(870, 698);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(73, 40);
            this.btPrint.TabIndex = 11;
            this.btPrint.Text = "Xem phiếu";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // txtNguyen_Nhan
            // 
            this.txtNguyen_Nhan.AutoDropDown = null;
            this.txtNguyen_Nhan.Location = new System.Drawing.Point(95, 30);
            this.txtNguyen_Nhan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtNguyen_Nhan.MaxLength = 4000;
            this.txtNguyen_Nhan.Multiline = true;
            this.txtNguyen_Nhan.Name = "txtNguyen_Nhan";
            this.txtNguyen_Nhan.Size = new System.Drawing.Size(387, 53);
            this.txtNguyen_Nhan.TabIndex = 1056;
            // 
            // lbtNguyen_Nhan
            // 
            this.lbtNguyen_Nhan.AutoEllipsis = true;
            this.lbtNguyen_Nhan.AutoSize = true;
            this.lbtNguyen_Nhan.Location = new System.Drawing.Point(19, 45);
            this.lbtNguyen_Nhan.Name = "lbtNguyen_Nhan";
            this.lbtNguyen_Nhan.Size = new System.Drawing.Size(71, 13);
            this.lbtNguyen_Nhan.TabIndex = 1058;
            this.lbtNguyen_Nhan.Tag = "";
            this.lbtNguyen_Nhan.Text = "Nguyên nhân";
            this.lbtNguyen_Nhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTinh_Trang_Tb
            // 
            this.txtTinh_Trang_Tb.AutoDropDown = null;
            this.txtTinh_Trang_Tb.Location = new System.Drawing.Point(95, 6);
            this.txtTinh_Trang_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtTinh_Trang_Tb.MaxLength = 1000;
            this.txtTinh_Trang_Tb.Multiline = true;
            this.txtTinh_Trang_Tb.Name = "txtTinh_Trang_Tb";
            this.txtTinh_Trang_Tb.Size = new System.Drawing.Size(387, 23);
            this.txtTinh_Trang_Tb.TabIndex = 1055;
            // 
            // lbtTinh_Trang_Tb
            // 
            this.lbtTinh_Trang_Tb.AutoEllipsis = true;
            this.lbtTinh_Trang_Tb.AutoSize = true;
            this.lbtTinh_Trang_Tb.Location = new System.Drawing.Point(0, 18);
            this.lbtTinh_Trang_Tb.Name = "lbtTinh_Trang_Tb";
            this.lbtTinh_Trang_Tb.Size = new System.Drawing.Size(89, 13);
            this.lbtTinh_Trang_Tb.TabIndex = 1057;
            this.lbtTinh_Trang_Tb.Tag = "";
            this.lbtTinh_Trang_Tb.Text = "Tình trạng thiết bị";
            this.lbtTinh_Trang_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhuong_An
            // 
            this.txtPhuong_An.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhuong_An.AutoDropDown = null;
            this.txtPhuong_An.Location = new System.Drawing.Point(539, 44);
            this.txtPhuong_An.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtPhuong_An.MaxLength = 4000;
            this.txtPhuong_An.Multiline = true;
            this.txtPhuong_An.Name = "txtPhuong_An";
            this.txtPhuong_An.Size = new System.Drawing.Size(597, 40);
            this.txtPhuong_An.TabIndex = 1051;
            // 
            // lbtPhuong_An2
            // 
            this.lbtPhuong_An2.AutoEllipsis = true;
            this.lbtPhuong_An2.AutoSize = true;
            this.lbtPhuong_An2.Location = new System.Drawing.Point(487, 62);
            this.lbtPhuong_An2.Name = "lbtPhuong_An2";
            this.lbtPhuong_An2.Size = new System.Drawing.Size(51, 13);
            this.lbtPhuong_An2.TabIndex = 1053;
            this.lbtPhuong_An2.Tag = "";
            this.lbtPhuong_An2.Text = "sửa chữa";
            this.lbtPhuong_An2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtPhuong_An1
            // 
            this.lbtPhuong_An1.AutoEllipsis = true;
            this.lbtPhuong_An1.AutoSize = true;
            this.lbtPhuong_An1.Location = new System.Drawing.Point(483, 46);
            this.lbtPhuong_An1.Name = "lbtPhuong_An1";
            this.lbtPhuong_An1.Size = new System.Drawing.Size(55, 13);
            this.lbtPhuong_An1.TabIndex = 1054;
            this.lbtPhuong_An1.Tag = "";
            this.lbtPhuong_An1.Text = "Biện pháp";
            this.lbtPhuong_An1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoi_Dung
            // 
            this.txtNoi_Dung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoi_Dung.AutoDropDown = null;
            this.txtNoi_Dung.Location = new System.Drawing.Point(539, 3);
            this.txtNoi_Dung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtNoi_Dung.MaxLength = 4000;
            this.txtNoi_Dung.Multiline = true;
            this.txtNoi_Dung.Name = "txtNoi_Dung";
            this.txtNoi_Dung.Size = new System.Drawing.Size(597, 40);
            this.txtNoi_Dung.TabIndex = 1050;
            // 
            // lbtNoi_Dung
            // 
            this.lbtNoi_Dung.AutoEllipsis = true;
            this.lbtNoi_Dung.AutoSize = true;
            this.lbtNoi_Dung.Location = new System.Drawing.Point(486, 6);
            this.lbtNoi_Dung.Name = "lbtNoi_Dung";
            this.lbtNoi_Dung.Size = new System.Drawing.Size(52, 13);
            this.lbtNoi_Dung.TabIndex = 1052;
            this.lbtNoi_Dung.Tag = "";
            this.lbtNoi_Dung.Text = "Diễn biến";
            this.lbtNoi_Dung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtBoPhan
            // 
            this.lbtBoPhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbtBoPhan.AutoEllipsis = true;
            this.lbtBoPhan.AutoSize = true;
            this.lbtBoPhan.Location = new System.Drawing.Point(166, 668);
            this.lbtBoPhan.Name = "lbtBoPhan";
            this.lbtBoPhan.Size = new System.Drawing.Size(139, 13);
            this.lbtBoPhan.TabIndex = 65;
            this.lbtBoPhan.Tag = "";
            this.lbtBoPhan.Text = "Giao cho bộ phận thực hiện";
            this.lbtBoPhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbtBoPhan.Visible = false;
            // 
            // chkIs_Kh
            // 
            this.chkIs_Kh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIs_Kh.AutoSize = true;
            this.chkIs_Kh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Kh.ForeColor = System.Drawing.Color.Red;
            this.chkIs_Kh.Location = new System.Drawing.Point(7, 665);
            this.chkIs_Kh.Name = "chkIs_Kh";
            this.chkIs_Kh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIs_Kh.Size = new System.Drawing.Size(157, 17);
            this.chkIs_Kh.TabIndex = 1059;
            this.chkIs_Kh.TabStop = false;
            this.chkIs_Kh.Text = "&Đồng ý sửa chữa ngoài";
            this.chkIs_Kh.UseVisualStyleBackColor = true;
            // 
            // cboMa_Bp_Th
            // 
            this.cboMa_Bp_Th.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboMa_Bp_Th.FormattingEnabled = true;
            this.cboMa_Bp_Th.Items.AddRange(new object[] {
            "Đã kết hôn",
            "Độc thân"});
            this.cboMa_Bp_Th.Location = new System.Drawing.Point(307, 664);
            this.cboMa_Bp_Th.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp_Th.Name = "cboMa_Bp_Th";
            this.cboMa_Bp_Th.Size = new System.Drawing.Size(196, 21);
            this.cboMa_Bp_Th.TabIndex = 1060;
            this.cboMa_Bp_Th.Visible = false;
            // 
            // lbtTinh_Trang_Th
            // 
            this.lbtTinh_Trang_Th.AutoEllipsis = true;
            this.lbtTinh_Trang_Th.AutoSize = true;
            this.lbtTinh_Trang_Th.Location = new System.Drawing.Point(6, 96);
            this.lbtTinh_Trang_Th.Name = "lbtTinh_Trang_Th";
            this.lbtTinh_Trang_Th.Size = new System.Drawing.Size(90, 13);
            this.lbtTinh_Trang_Th.TabIndex = 1053;
            this.lbtTinh_Trang_Th.Tag = "";
            this.lbtTinh_Trang_Th.Text = "Đề nghị SC ngoài";
            this.lbtTinh_Trang_Th.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTinh_Trang_Th
            // 
            this.txtTinh_Trang_Th.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTinh_Trang_Th.AutoDropDown = null;
            this.txtTinh_Trang_Th.Location = new System.Drawing.Point(95, 84);
            this.txtTinh_Trang_Th.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtTinh_Trang_Th.MaxLength = 4000;
            this.txtTinh_Trang_Th.Multiline = true;
            this.txtTinh_Trang_Th.Name = "txtTinh_Trang_Th";
            this.txtTinh_Trang_Th.Size = new System.Drawing.Size(1041, 26);
            this.txtTinh_Trang_Th.TabIndex = 1051;
            // 
            // txtTen_Dt
            // 
            this.txtTen_Dt.AutoDropDown = null;
            this.txtTen_Dt.Location = new System.Drawing.Point(95, 6);
            this.txtTen_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtTen_Dt.MaxLength = 1000;
            this.txtTen_Dt.Multiline = true;
            this.txtTen_Dt.Name = "txtTen_Dt";
            this.txtTen_Dt.Size = new System.Drawing.Size(1039, 24);
            this.txtTen_Dt.TabIndex = 1061;
            // 
            // lblTen_Dt
            // 
            this.lblTen_Dt.AutoEllipsis = true;
            this.lblTen_Dt.AutoSize = true;
            this.lblTen_Dt.Location = new System.Drawing.Point(0, 11);
            this.lblTen_Dt.Name = "lblTen_Dt";
            this.lblTen_Dt.Size = new System.Drawing.Size(59, 13);
            this.lblTen_Dt.TabIndex = 1062;
            this.lblTen_Dt.Tag = "";
            this.lblTen_Dt.Text = "Tên đơn vị";
            this.lblTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.Location = new System.Drawing.Point(0, 36);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(50, 13);
            this.lblDien_Giai.TabIndex = 1062;
            this.lblDien_Giai.Tag = "";
            this.lblDien_Giai.Text = "Nội dung";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDien_Giai
            // 
            this.txtDien_Giai.AutoDropDown = null;
            this.txtDien_Giai.Location = new System.Drawing.Point(95, 31);
            this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtDien_Giai.MaxLength = 1000;
            this.txtDien_Giai.Multiline = true;
            this.txtDien_Giai.Name = "txtDien_Giai";
            this.txtDien_Giai.Size = new System.Drawing.Size(1039, 24);
            this.txtDien_Giai.TabIndex = 1061;
            // 
            // txtPhuong_An1
            // 
            this.txtPhuong_An1.AutoDropDown = null;
            this.txtPhuong_An1.Location = new System.Drawing.Point(95, 56);
            this.txtPhuong_An1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 1);
            this.txtPhuong_An1.MaxLength = 1000;
            this.txtPhuong_An1.Multiline = true;
            this.txtPhuong_An1.Name = "txtPhuong_An1";
            this.txtPhuong_An1.Size = new System.Drawing.Size(1039, 54);
            this.txtPhuong_An1.TabIndex = 1063;
            // 
            // lblPhuong_An1
            // 
            this.lblPhuong_An1.AutoEllipsis = true;
            this.lblPhuong_An1.AutoSize = true;
            this.lblPhuong_An1.Location = new System.Drawing.Point(6, 62);
            this.lblPhuong_An1.Name = "lblPhuong_An1";
            this.lblPhuong_An1.Size = new System.Drawing.Size(59, 13);
            this.lblPhuong_An1.TabIndex = 1064;
            this.lblPhuong_An1.Tag = "";
            this.lblPhuong_An1.Text = "Phương án";
            this.lblPhuong_An1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkLock
            // 
            this.chkLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLock.AutoSize = true;
            this.chkLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock.ForeColor = System.Drawing.Color.Red;
            this.chkLock.Location = new System.Drawing.Point(7, 688);
            this.chkLock.Name = "chkLock";
            this.chkLock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkLock.Size = new System.Drawing.Size(115, 17);
            this.chkLock.TabIndex = 1065;
            this.chkLock.TabStop = false;
            this.chkLock.Text = "&Đồng ý thanh lý";
            this.chkLock.UseVisualStyleBackColor = true;
            this.chkLock.Visible = false;
            // 
            // frmDuyetQLMMTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 745);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.txtPhuong_An1);
            this.Controls.Add(this.lblPhuong_An1);
            this.Controls.Add(this.txtDien_Giai);
            this.Controls.Add(this.cboMa_Bp_Th);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.chkIs_Kh);
            this.Controls.Add(this.txtTen_Dt);
            this.Controls.Add(this.lblTen_Dt);
            this.Controls.Add(this.txtNguyen_Nhan);
            this.Controls.Add(this.lbtNguyen_Nhan);
            this.Controls.Add(this.txtTinh_Trang_Tb);
            this.Controls.Add(this.lbtTinh_Trang_Tb);
            this.Controls.Add(this.txtTinh_Trang_Th);
            this.Controls.Add(this.lbtTinh_Trang_Th);
            this.Controls.Add(this.txtPhuong_An);
            this.Controls.Add(this.lbtPhuong_An2);
            this.Controls.Add(this.lbtPhuong_An1);
            this.Controls.Add(this.txtNoi_Dung);
            this.Controls.Add(this.lbtNoi_Dung);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.txtGD_Duyet);
            this.Controls.Add(this.lbtBoPhan);
            this.Controls.Add(this.lbtTen_Gd_Duyet);
            this.Controls.Add(this.lblGiam_Doc_Duyet);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btOpen_Bg);
            this.Controls.Add(this.tbAttach);
            this.Controls.Add(this.tbChitiet);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDuyetQLMMTB";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Duyệt QLMMTB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbChitiet.ResumeLayout(false);
            this.tbAttach.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl tbChitiet;
		private RosySystem.Customize.btgAccept btgAccept;
        private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Control.rsTextBox txtGD_Duyet;
		private RosySystem.Control.rsLabel lblGiam_Doc_Duyet;
        private RosySystem.Control.rsLabel lbtTen_Gd_Duyet;
		public RosySystem.Control.rsCheckbox chkDuyet;
		private RosySystem.Control.rsButton btOpen_Bg;
		private RosySystem.Control.rsTabControl tbAttach;
		private System.Windows.Forms.TabPage tabPage2;
        private RosySystem.Customize.dgvVoucher dgvResource;
        private RosySystem.Control.rsButton btPrint;
        private RosySystem.Control.rsTextBox txtNguyen_Nhan;
        private RosySystem.Control.rsLabel lbtNguyen_Nhan;
        private RosySystem.Control.rsTextBox txtTinh_Trang_Tb;
        private RosySystem.Control.rsLabel lbtTinh_Trang_Tb;
        private RosySystem.Control.rsTextBox txtPhuong_An;
        private RosySystem.Control.rsLabel lbtPhuong_An2;
        private RosySystem.Control.rsLabel lbtPhuong_An1;
        private RosySystem.Control.rsTextBox txtNoi_Dung;
        private RosySystem.Control.rsLabel lbtNoi_Dung;
        private RosySystem.Control.rsLabel lbtBoPhan;
        private RosySystem.Control.rsCheckbox chkIs_Kh;
        private RosySystem.Control.rsComboBox cboMa_Bp_Th;
        private RosySystem.Control.rsLabel lbtTinh_Trang_Th;
        private RosySystem.Control.rsTextBox txtTinh_Trang_Th;
        private RosySystem.Control.rsTextBox txtTen_Dt;
        private RosySystem.Control.rsLabel lblTen_Dt;
        private RosySystem.Control.rsLabel lblDien_Giai;
        private RosySystem.Control.rsTextBox txtDien_Giai;
        private RosySystem.Control.rsTextBox txtPhuong_An1;
        private RosySystem.Control.rsLabel lblPhuong_An1;
        private RosySystem.Control.rsCheckbox chkLock;
	}
}

