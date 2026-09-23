namespace RosyModule
{
	partial class frmDuyetYeuCau
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetYeuCau));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbChitiet = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDuyet = new RosySystem.Customize.dgvVoucher();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.btUpdate_Tk = new RosySystem.Control.rsButton();
            this.txtGD_Duyet = new RosySystem.Control.rsTextBox();
            this.lblGiam_Doc_Duyet = new RosySystem.Control.rsLabel();
            this.lbtTen_Gd_Duyet = new RosySystem.Control.rsLabel();
            this.btCheck_Yeu_Cau = new RosySystem.Control.rsButton();
            this.btCheck_Gia = new RosySystem.Control.rsButton();
            this.chkDuyet = new RosySystem.Control.rsCheckbox();
            this.btOpen_Bg = new RosySystem.Control.rsButton();
            this.tbAttach = new RosySystem.Control.rsTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvResource = new RosySystem.Customize.dgvVoucher();
            this.btNew = new RosySystem.Control.rsButton();
            this.btEdit = new RosySystem.Control.rsButton();
            this.btDelete = new RosySystem.Control.rsButton();
            this.btCheck_Dt = new RosySystem.Control.rsButton();
            this.pnlTTien = new RosySystem.Control.rsPanel();
            this.numTTien3 = new RosySystem.Control.rsTextBoxNumber();
            this.numTTien0 = new RosySystem.Control.rsTextBoxNumber();
            this.pnlTTien_Nt = new RosySystem.Control.rsPanel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lblTTien3 = new RosySystem.Control.rsLabel();
            this.lblTTien0 = new RosySystem.Control.rsLabel();
            this.numTTien_Nt3 = new RosySystem.Control.rsTextBoxNumber();
            this.numTTien_Nt0 = new RosySystem.Control.rsTextBoxNumber();
            this.numTSo_Luong = new RosySystem.Control.rsTextBoxNumber();
            this.lblGhi_Chu_PKTTC = new RosySystem.Control.rsLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvHistory = new RosySystem.Customize.dgvVoucher();
            this.tbHistory = new RosySystem.Control.rsTabControl();
            this.tbCtYeuCau = new RosySystem.Control.rsTabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvCtYeuCau = new RosySystem.Customize.dgvVoucher();
            this.txtGhi_Chu_PKTTC = new RosySystem.Control.rsTextBox();
            this.txtLyDo_Cham_KHVT = new RosySystem.Control.rsTextBox();
            this.chkDuyet_Huy = new RosySystem.Control.rsCheckbox();
            this.btCheckVTPTTD = new RosySystem.Control.rsButton();
            this.tbChitiet.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyet)).BeginInit();
            this.tbAttach.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResource)).BeginInit();
            this.pnlTTien.SuspendLayout();
            this.pnlTTien_Nt.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.tbHistory.SuspendLayout();
            this.tbCtYeuCau.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtYeuCau)).BeginInit();
            this.SuspendLayout();
            // 
            // tbChitiet
            // 
            this.tbChitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChitiet.Controls.Add(this.tabPage1);
            this.tbChitiet.Location = new System.Drawing.Point(3, 6);
            this.tbChitiet.Name = "tbChitiet";
            this.tbChitiet.SelectedIndex = 0;
            this.tbChitiet.Size = new System.Drawing.Size(938, 285);
            this.tbChitiet.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDuyet);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(930, 259);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chi tiết duyệt đề nghị";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDuyet
            // 
            this.dgvDuyet.AllowUserToAddRows = false;
            this.dgvDuyet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDuyet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDuyet.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuyet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDuyet.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDuyet.Location = new System.Drawing.Point(3, 3);
            this.dgvDuyet.MultiSelect = false;
            this.dgvDuyet.Name = "dgvDuyet";
            this.dgvDuyet.Size = new System.Drawing.Size(924, 253);
            this.dgvDuyet.strZone = "";
            this.dgvDuyet.TabIndex = 1;
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
            this.btgAccept.Location = new System.Drawing.Point(756, 650);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 42);
            this.btgAccept.TabIndex = 2;
            // 
            // btUpdate_Tk
            // 
            this.btUpdate_Tk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate_Tk.Location = new System.Drawing.Point(680, 652);
            this.btUpdate_Tk.Name = "btUpdate_Tk";
            this.btUpdate_Tk.Size = new System.Drawing.Size(73, 41);
            this.btUpdate_Tk.TabIndex = 11;
            this.btUpdate_Tk.Text = "Cập nhật tồn kho";
            this.btUpdate_Tk.UseVisualStyleBackColor = true;
            // 
            // txtGD_Duyet
            // 
            this.txtGD_Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGD_Duyet.AutoDropDown = null;
            this.txtGD_Duyet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGD_Duyet.Location = new System.Drawing.Point(97, 675);
            this.txtGD_Duyet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
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
            this.lblGiam_Doc_Duyet.Location = new System.Drawing.Point(10, 678);
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
            this.lbtTen_Gd_Duyet.Location = new System.Drawing.Point(219, 678);
            this.lbtTen_Gd_Duyet.Name = "lbtTen_Gd_Duyet";
            this.lbtTen_Gd_Duyet.Size = new System.Drawing.Size(102, 13);
            this.lbtTen_Gd_Duyet.TabIndex = 65;
            this.lbtTen_Gd_Duyet.Tag = "";
            this.lbtTen_Gd_Duyet.Text = "Tên giám đốc duyệt";
            this.lbtTen_Gd_Duyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btCheck_Yeu_Cau
            // 
            this.btCheck_Yeu_Cau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCheck_Yeu_Cau.Location = new System.Drawing.Point(592, 652);
            this.btCheck_Yeu_Cau.Name = "btCheck_Yeu_Cau";
            this.btCheck_Yeu_Cau.Size = new System.Drawing.Size(86, 41);
            this.btCheck_Yeu_Cau.TabIndex = 11;
            this.btCheck_Yeu_Cau.Text = "Kiểm tra đề nghị mua hàng";
            this.btCheck_Yeu_Cau.UseVisualStyleBackColor = true;
            // 
            // btCheck_Gia
            // 
            this.btCheck_Gia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCheck_Gia.Location = new System.Drawing.Point(415, 652);
            this.btCheck_Gia.Name = "btCheck_Gia";
            this.btCheck_Gia.Size = new System.Drawing.Size(99, 41);
            this.btCheck_Gia.TabIndex = 11;
            this.btCheck_Gia.Text = "Kiểm tra đề nghị giá mua gần nhất";
            this.btCheck_Gia.UseVisualStyleBackColor = true;
            // 
            // chkDuyet
            // 
            this.chkDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDuyet.ForeColor = System.Drawing.Color.Red;
            this.chkDuyet.Location = new System.Drawing.Point(3, 655);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(121, 19);
            this.chkDuyet.TabIndex = 66;
            this.chkDuyet.Text = "Duyệt chứng từ";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // btOpen_Bg
            // 
            this.btOpen_Bg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpen_Bg.Location = new System.Drawing.Point(342, 652);
            this.btOpen_Bg.Name = "btOpen_Bg";
            this.btOpen_Bg.Size = new System.Drawing.Size(73, 41);
            this.btOpen_Bg.TabIndex = 11;
            this.btOpen_Bg.Text = "Xem file attach";
            this.btOpen_Bg.UseVisualStyleBackColor = true;
            // 
            // tbAttach
            // 
            this.tbAttach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAttach.Controls.Add(this.tabPage2);
            this.tbAttach.Location = new System.Drawing.Point(2, 294);
            this.tbAttach.Name = "tbAttach";
            this.tbAttach.SelectedIndex = 0;
            this.tbAttach.Size = new System.Drawing.Size(645, 102);
            this.tbAttach.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvResource);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(637, 76);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Chi tiết file attach file";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvResource
            // 
            this.dgvResource.AllowUserToAddRows = false;
            this.dgvResource.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvResource.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResource.BackgroundColor = System.Drawing.Color.White;
            this.dgvResource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResource.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvResource.Location = new System.Drawing.Point(3, 3);
            this.dgvResource.MultiSelect = false;
            this.dgvResource.Name = "dgvResource";
            this.dgvResource.Size = new System.Drawing.Size(631, 70);
            this.dgvResource.strZone = "";
            this.dgvResource.TabIndex = 1;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.Location = new System.Drawing.Point(6, 611);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(68, 39);
            this.btNew.TabIndex = 11;
            this.btNew.Text = "Thêm yêu cầu";
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEdit.Location = new System.Drawing.Point(76, 611);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(68, 39);
            this.btEdit.TabIndex = 11;
            this.btEdit.Text = "Sửa yêu cầu";
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.Location = new System.Drawing.Point(146, 611);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(68, 39);
            this.btDelete.TabIndex = 11;
            this.btDelete.Text = "Xóa yêu cầu";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btCheck_Dt
            // 
            this.btCheck_Dt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCheck_Dt.Location = new System.Drawing.Point(514, 652);
            this.btCheck_Dt.Name = "btCheck_Dt";
            this.btCheck_Dt.Size = new System.Drawing.Size(77, 41);
            this.btCheck_Dt.TabIndex = 11;
            this.btCheck_Dt.Text = "Kiểm tra dự trù";
            this.btCheck_Dt.UseVisualStyleBackColor = true;
            // 
            // pnlTTien
            // 
            this.pnlTTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTTien.Controls.Add(this.numTTien3);
            this.pnlTTien.Controls.Add(this.numTTien0);
            this.pnlTTien.Location = new System.Drawing.Point(854, 320);
            this.pnlTTien.Name = "pnlTTien";
            this.pnlTTien.Size = new System.Drawing.Size(80, 76);
            this.pnlTTien.TabIndex = 113;
            // 
            // numTTien3
            // 
            this.numTTien3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien3.AutoDropDown = null;
            this.numTTien3.bFormat = true;
            this.numTTien3.Location = new System.Drawing.Point(3, 25);
            this.numTTien3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien3.Name = "numTTien3";
            this.numTTien3.Scale = 0;
            this.numTTien3.Size = new System.Drawing.Size(75, 20);
            this.numTTien3.TabIndex = 87;
            this.numTTien3.TabStop = false;
            this.numTTien3.Text = "0";
            this.numTTien3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien3.Value = 0D;
            // 
            // numTTien0
            // 
            this.numTTien0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien0.AutoDropDown = null;
            this.numTTien0.bFormat = true;
            this.numTTien0.Location = new System.Drawing.Point(3, 3);
            this.numTTien0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien0.Name = "numTTien0";
            this.numTTien0.Scale = 0;
            this.numTTien0.Size = new System.Drawing.Size(75, 20);
            this.numTTien0.TabIndex = 84;
            this.numTTien0.TabStop = false;
            this.numTTien0.Text = "0";
            this.numTTien0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien0.Value = 0D;
            // 
            // pnlTTien_Nt
            // 
            this.pnlTTien_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTTien_Nt.Controls.Add(this.rsLabel1);
            this.pnlTTien_Nt.Controls.Add(this.lblTTien3);
            this.pnlTTien_Nt.Controls.Add(this.lblTTien0);
            this.pnlTTien_Nt.Controls.Add(this.numTTien_Nt3);
            this.pnlTTien_Nt.Controls.Add(this.numTTien_Nt0);
            this.pnlTTien_Nt.Controls.Add(this.numTSo_Luong);
            this.pnlTTien_Nt.Location = new System.Drawing.Point(653, 320);
            this.pnlTTien_Nt.Name = "pnlTTien_Nt";
            this.pnlTTien_Nt.Size = new System.Drawing.Size(199, 76);
            this.pnlTTien_Nt.TabIndex = 112;
            // 
            // rsLabel1
            // 
            this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(17, 50);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(48, 13);
            this.rsLabel1.TabIndex = 113;
            this.rsLabel1.Tag = "TSo_Luong";
            this.rsLabel1.Text = "Tổng SL";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTTien3
            // 
            this.lblTTien3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTTien3.AutoEllipsis = true;
            this.lblTTien3.AutoSize = true;
            this.lblTTien3.Location = new System.Drawing.Point(17, 29);
            this.lblTTien3.Name = "lblTTien3";
            this.lblTTien3.Size = new System.Drawing.Size(52, 13);
            this.lblTTien3.TabIndex = 111;
            this.lblTTien3.Tag = "TTIEN3";
            this.lblTTien3.Text = "Tiền VAT";
            this.lblTTien3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTTien0
            // 
            this.lblTTien0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTTien0.AutoEllipsis = true;
            this.lblTTien0.AutoSize = true;
            this.lblTTien0.Location = new System.Drawing.Point(17, 6);
            this.lblTTien0.Name = "lblTTien0";
            this.lblTTien0.Size = new System.Drawing.Size(55, 13);
            this.lblTTien0.TabIndex = 110;
            this.lblTTien0.Tag = "TTIEN0";
            this.lblTTien0.Text = "Tiền hàng";
            this.lblTTien0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTTien_Nt3
            // 
            this.numTTien_Nt3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Nt3.AutoDropDown = null;
            this.numTTien_Nt3.bFormat = true;
            this.numTTien_Nt3.Location = new System.Drawing.Point(98, 25);
            this.numTTien_Nt3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Nt3.Name = "numTTien_Nt3";
            this.numTTien_Nt3.Scale = 2;
            this.numTTien_Nt3.Size = new System.Drawing.Size(99, 20);
            this.numTTien_Nt3.TabIndex = 86;
            this.numTTien_Nt3.TabStop = false;
            this.numTTien_Nt3.Text = "0.00";
            this.numTTien_Nt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Nt3.Value = 0D;
            // 
            // numTTien_Nt0
            // 
            this.numTTien_Nt0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Nt0.AutoDropDown = null;
            this.numTTien_Nt0.bFormat = true;
            this.numTTien_Nt0.Location = new System.Drawing.Point(98, 3);
            this.numTTien_Nt0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Nt0.Name = "numTTien_Nt0";
            this.numTTien_Nt0.Scale = 2;
            this.numTTien_Nt0.Size = new System.Drawing.Size(99, 20);
            this.numTTien_Nt0.TabIndex = 83;
            this.numTTien_Nt0.TabStop = false;
            this.numTTien_Nt0.Text = "0.00";
            this.numTTien_Nt0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Nt0.Value = 0D;
            // 
            // numTSo_Luong
            // 
            this.numTSo_Luong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTSo_Luong.AutoDropDown = null;
            this.numTSo_Luong.bFormat = true;
            this.numTSo_Luong.Location = new System.Drawing.Point(98, 47);
            this.numTSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTSo_Luong.Name = "numTSo_Luong";
            this.numTSo_Luong.Scale = 2;
            this.numTSo_Luong.Size = new System.Drawing.Size(99, 20);
            this.numTSo_Luong.TabIndex = 112;
            this.numTSo_Luong.TabStop = false;
            this.numTSo_Luong.Text = "0.00";
            this.numTSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTSo_Luong.Value = 0D;
            // 
            // lblGhi_Chu_PKTTC
            // 
            this.lblGhi_Chu_PKTTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGhi_Chu_PKTTC.AutoEllipsis = true;
            this.lblGhi_Chu_PKTTC.AutoSize = true;
            this.lblGhi_Chu_PKTTC.Location = new System.Drawing.Point(226, 629);
            this.lblGhi_Chu_PKTTC.Name = "lblGhi_Chu_PKTTC";
            this.lblGhi_Chu_PKTTC.Size = new System.Drawing.Size(111, 13);
            this.lblGhi_Chu_PKTTC.TabIndex = 116;
            this.lblGhi_Chu_PKTTC.Tag = "";
            this.lblGhi_Chu_PKTTC.Text = "Ghi chú duyệt PKTTC";
            this.lblGhi_Chu_PKTTC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGhi_Chu_PKTTC.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvHistory);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(927, 99);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Chi tiết lịch sử vật tư";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvHistory.Location = new System.Drawing.Point(3, 3);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.Size = new System.Drawing.Size(921, 93);
            this.dgvHistory.strZone = "";
            this.dgvHistory.TabIndex = 1;
            // 
            // tbHistory
            // 
            this.tbHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHistory.Controls.Add(this.tabPage3);
            this.tbHistory.Location = new System.Drawing.Point(3, 399);
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.SelectedIndex = 0;
            this.tbHistory.Size = new System.Drawing.Size(935, 125);
            this.tbHistory.TabIndex = 0;
            // 
            // tbCtYeuCau
            // 
            this.tbCtYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCtYeuCau.Controls.Add(this.tabPage4);
            this.tbCtYeuCau.Location = new System.Drawing.Point(6, 521);
            this.tbCtYeuCau.Name = "tbCtYeuCau";
            this.tbCtYeuCau.SelectedIndex = 0;
            this.tbCtYeuCau.Size = new System.Drawing.Size(931, 88);
            this.tbCtYeuCau.TabIndex = 117;
            this.tbCtYeuCau.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvCtYeuCau);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(923, 62);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Chi tiết yêu cầu";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvCtYeuCau
            // 
            this.dgvCtYeuCau.AllowUserToAddRows = false;
            this.dgvCtYeuCau.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtYeuCau.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCtYeuCau.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtYeuCau.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtYeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtYeuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtYeuCau.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtYeuCau.Location = new System.Drawing.Point(3, 3);
            this.dgvCtYeuCau.MultiSelect = false;
            this.dgvCtYeuCau.Name = "dgvCtYeuCau";
            this.dgvCtYeuCau.Size = new System.Drawing.Size(917, 56);
            this.dgvCtYeuCau.strZone = "";
            this.dgvCtYeuCau.TabIndex = 0;
            // 
            // txtGhi_Chu_PKTTC
            // 
            this.txtGhi_Chu_PKTTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhi_Chu_PKTTC.AutoDropDown = null;
            this.txtGhi_Chu_PKTTC.Location = new System.Drawing.Point(415, 626);
            this.txtGhi_Chu_PKTTC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu_PKTTC.MaxLength = 100;
            this.txtGhi_Chu_PKTTC.Name = "txtGhi_Chu_PKTTC";
            this.txtGhi_Chu_PKTTC.Size = new System.Drawing.Size(519, 20);
            this.txtGhi_Chu_PKTTC.TabIndex = 115;
            this.txtGhi_Chu_PKTTC.Visible = false;
            // 
            // txtLyDo_Cham_KHVT
            // 
            this.txtLyDo_Cham_KHVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLyDo_Cham_KHVT.AutoDropDown = null;
            this.txtLyDo_Cham_KHVT.Location = new System.Drawing.Point(326, 626);
            this.txtLyDo_Cham_KHVT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLyDo_Cham_KHVT.MaxLength = 100;
            this.txtLyDo_Cham_KHVT.Name = "txtLyDo_Cham_KHVT";
            this.txtLyDo_Cham_KHVT.Size = new System.Drawing.Size(608, 20);
            this.txtLyDo_Cham_KHVT.TabIndex = 118;
            this.txtLyDo_Cham_KHVT.Visible = false;
            // 
            // chkDuyet_Huy
            // 
            this.chkDuyet_Huy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDuyet_Huy.AutoSize = true;
            this.chkDuyet_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDuyet_Huy.ForeColor = System.Drawing.Color.Red;
            this.chkDuyet_Huy.Location = new System.Drawing.Point(130, 654);
            this.chkDuyet_Huy.Name = "chkDuyet_Huy";
            this.chkDuyet_Huy.Size = new System.Drawing.Size(90, 19);
            this.chkDuyet_Huy.TabIndex = 119;
            this.chkDuyet_Huy.Text = "Hủy phiếu";
            this.chkDuyet_Huy.UseVisualStyleBackColor = true;
            // 
            // btCheckVTPTTD
            // 
            this.btCheckVTPTTD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCheckVTPTTD.Location = new System.Drawing.Point(215, 611);
            this.btCheckVTPTTD.Name = "btCheckVTPTTD";
            this.btCheckVTPTTD.Size = new System.Drawing.Size(106, 39);
            this.btCheckVTPTTD.TabIndex = 11;
            this.btCheckVTPTTD.Text = "Kiểm tra tồn VTPT tương đương";
            this.btCheckVTPTTD.UseVisualStyleBackColor = true;
            // 
            // frmDuyetYeuCau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(944, 698);
            this.Controls.Add(this.chkDuyet_Huy);
            this.Controls.Add(this.txtLyDo_Cham_KHVT);
            this.Controls.Add(this.tbCtYeuCau);
            this.Controls.Add(this.lblGhi_Chu_PKTTC);
            this.Controls.Add(this.txtGhi_Chu_PKTTC);
            this.Controls.Add(this.pnlTTien);
            this.Controls.Add(this.pnlTTien_Nt);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.txtGD_Duyet);
            this.Controls.Add(this.lbtTen_Gd_Duyet);
            this.Controls.Add(this.lblGiam_Doc_Duyet);
            this.Controls.Add(this.btCheck_Gia);
            this.Controls.Add(this.btCheck_Dt);
            this.Controls.Add(this.btCheck_Yeu_Cau);
            this.Controls.Add(this.btCheckVTPTTD);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btOpen_Bg);
            this.Controls.Add(this.btUpdate_Tk);
            this.Controls.Add(this.tbHistory);
            this.Controls.Add(this.tbAttach);
            this.Controls.Add(this.tbChitiet);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmDuyetYeuCau";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Duyệt chứng từ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbChitiet.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyet)).EndInit();
            this.tbAttach.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResource)).EndInit();
            this.pnlTTien.ResumeLayout(false);
            this.pnlTTien.PerformLayout();
            this.pnlTTien_Nt.ResumeLayout(false);
            this.pnlTTien_Nt.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.tbHistory.ResumeLayout(false);
            this.tbCtYeuCau.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtYeuCau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl tbChitiet;
		private RosySystem.Customize.btgAccept btgAccept;
		private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Customize.dgvVoucher dgvDuyet;
		private RosySystem.Control.rsButton btUpdate_Tk;
		private RosySystem.Control.rsTextBox txtGD_Duyet;
		private RosySystem.Control.rsLabel lblGiam_Doc_Duyet;
		private RosySystem.Control.rsLabel lbtTen_Gd_Duyet;
		private RosySystem.Control.rsButton btCheck_Yeu_Cau;
		private RosySystem.Control.rsButton btCheck_Gia;
		public RosySystem.Control.rsCheckbox chkDuyet;
		private RosySystem.Control.rsButton btOpen_Bg;
		private RosySystem.Control.rsTabControl tbAttach;
		private System.Windows.Forms.TabPage tabPage2;
        private RosySystem.Customize.dgvVoucher dgvResource;
		private RosySystem.Control.rsButton btNew;
		private RosySystem.Control.rsButton btEdit;
		private RosySystem.Control.rsButton btDelete;
		private RosySystem.Control.rsButton btCheck_Dt;
        private RosySystem.Control.rsPanel pnlTTien;
        private RosySystem.Control.rsTextBoxNumber numTTien3;
        private RosySystem.Control.rsTextBoxNumber numTTien0;
        private RosySystem.Control.rsPanel pnlTTien_Nt;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel lblTTien3;
        private RosySystem.Control.rsLabel lblTTien0;
        private RosySystem.Control.rsTextBoxNumber numTTien_Nt3;
        private RosySystem.Control.rsTextBoxNumber numTTien_Nt0;
        private RosySystem.Control.rsTextBoxNumber numTSo_Luong;
        private RosySystem.Control.rsLabel lblGhi_Chu_PKTTC;
        private System.Windows.Forms.TabPage tabPage3;
        private RosySystem.Customize.dgvVoucher dgvHistory;
        private RosySystem.Control.rsTabControl tbHistory;
        private RosySystem.Control.rsTabControl tbCtYeuCau;
        private System.Windows.Forms.TabPage tabPage4;
        private RosySystem.Customize.dgvVoucher dgvCtYeuCau;
        public RosySystem.Control.rsTextBox txtGhi_Chu_PKTTC;
        public RosySystem.Control.rsTextBox txtLyDo_Cham_KHVT;
        public RosySystem.Control.rsCheckbox chkDuyet_Huy;
        private RosySystem.Control.rsButton btCheckVTPTTD;
	}
}

