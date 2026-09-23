namespace RosyModule.Machinery
{
	partial class frmBBNT_Edit
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBBNT_Edit));
			this.numTy_Gia = new RosySystem.Control.rsTextBoxNumber();
			this.txtMa_Tte = new RosySystem.Control.rsTextBoxEnum();
			this.lblMa_Tte = new RosySystem.Control.rsLabel();
			this.txtSo_Hd = new RosySystem.Control.rsTextBox();
			this.lblSo_Ct = new RosySystem.Control.rsLabel();
			this.lblNgay_Ct = new RosySystem.Control.rsLabel();
			this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
			this.dgvEditCt1 = new RosySystem.Customize.dgvVoucher();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtDe_Xuat = new RosySystem.Control.rsTextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.txtMa_Ct = new RosySystem.Control.rsTextBox();
			this.lblMa_Nvu = new RosySystem.Control.rsLabel();
			this.txtMa_Nvu = new RosySystem.Control.rsTextBox();
			this.lbtTen_Nvu = new RosySystem.Control.rsLabel();
			this.lblDien_Giai = new RosySystem.Control.rsLabel();
			this.txtDien_Giai = new RosySystem.Control.rsTextBox();
			this.txtDia_ChiA = new RosySystem.Control.rsTextBox();
			this.lblDia_Chi = new RosySystem.Control.rsLabel();
			this.txtOng_BaA = new RosySystem.Control.rsTextBox();
			this.lblOng_Ba = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.txtTen_DtA = new RosySystem.Control.rsTextBox();
			this.txtTen_DtB = new RosySystem.Control.rsTextBox();
			this.txtDia_ChiB = new RosySystem.Control.rsTextBox();
			this.txtChuc_VuA = new RosySystem.Control.rsTextBox();
			this.rsLabel4 = new RosySystem.Control.rsLabel();
			this.txtMSTA = new RosySystem.Control.rsTextBox();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.txtMSTB = new RosySystem.Control.rsTextBox();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.txtChuc_VuB = new RosySystem.Control.rsTextBox();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.txtOng_BaB = new RosySystem.Control.rsTextBox();
			this.rsLabel8 = new RosySystem.Control.rsLabel();
			this.rsLabel9 = new RosySystem.Control.rsLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsEditCt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvEditCt1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 540);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 550);
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(643, 524);
			this.btgAccept.TabIndex = 17;
			// 
			// cboSaveOption
			// 
			this.cboSaveOption.Location = new System.Drawing.Point(492, 540);
			// 
			// numTy_Gia
			// 
			this.numTy_Gia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numTy_Gia.AutoDropDown = null;
			this.numTy_Gia.bFormat = true;
			this.numTy_Gia.Location = new System.Drawing.Point(736, 13);
			this.numTy_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTy_Gia.Name = "numTy_Gia";
			this.numTy_Gia.Scale = 2;
			this.numTy_Gia.Size = new System.Drawing.Size(80, 20);
			this.numTy_Gia.TabIndex = 1;
			this.numTy_Gia.Text = "0.00";
			this.numTy_Gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTy_Gia.Value = 0D;
			this.numTy_Gia.Visible = false;
			// 
			// txtMa_Tte
			// 
			this.txtMa_Tte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMa_Tte.AutoDropDown = null;
			this.txtMa_Tte.InputMask = "VND,USD,EUR";
			this.txtMa_Tte.Location = new System.Drawing.Point(706, 13);
			this.txtMa_Tte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Tte.Name = "txtMa_Tte";
			this.txtMa_Tte.Size = new System.Drawing.Size(29, 20);
			this.txtMa_Tte.TabIndex = 4;
			this.txtMa_Tte.Visible = false;
			// 
			// lblMa_Tte
			// 
			this.lblMa_Tte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMa_Tte.AutoEllipsis = true;
			this.lblMa_Tte.AutoSize = true;
			this.lblMa_Tte.Location = new System.Drawing.Point(664, 16);
			this.lblMa_Tte.Name = "lblMa_Tte";
			this.lblMa_Tte.Size = new System.Drawing.Size(36, 14);
			this.lblMa_Tte.TabIndex = 53;
			this.lblMa_Tte.Tag = "Ma_Tte";
			this.lblMa_Tte.Text = "Mã ttệ";
			this.lblMa_Tte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMa_Tte.Visible = false;
			// 
			// txtSo_Hd
			// 
			this.txtSo_Hd.AutoDropDown = null;
			this.txtSo_Hd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSo_Hd.Location = new System.Drawing.Point(121, 50);
			this.txtSo_Hd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_Hd.MaxLength = 20;
			this.txtSo_Hd.Name = "txtSo_Hd";
			this.txtSo_Hd.Size = new System.Drawing.Size(120, 20);
			this.txtSo_Hd.TabIndex = 2;
			// 
			// lblSo_Ct
			// 
			this.lblSo_Ct.AutoEllipsis = true;
			this.lblSo_Ct.AutoSize = true;
			this.lblSo_Ct.Location = new System.Drawing.Point(14, 53);
			this.lblSo_Ct.Name = "lblSo_Ct";
			this.lblSo_Ct.Size = new System.Drawing.Size(69, 14);
			this.lblSo_Ct.TabIndex = 51;
			this.lblSo_Ct.Tag = "";
			this.lblSo_Ct.Text = "Số hợp đồng";
			this.lblSo_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblNgay_Ct
			// 
			this.lblNgay_Ct.AutoEllipsis = true;
			this.lblNgay_Ct.AutoSize = true;
			this.lblNgay_Ct.Location = new System.Drawing.Point(14, 75);
			this.lblNgay_Ct.Name = "lblNgay_Ct";
			this.lblNgay_Ct.Size = new System.Drawing.Size(46, 14);
			this.lblNgay_Ct.TabIndex = 0;
			this.lblNgay_Ct.Tag = "";
			this.lblNgay_Ct.Text = "Ngày ký";
			this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Ct
			// 
			this.dteNgay_Ct.bAllowEmpty = false;
			this.dteNgay_Ct.bSelectOnFocus = false;
			this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
			this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct.Location = new System.Drawing.Point(121, 72);
			this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct.Mask = "00/00/0000";
			this.dteNgay_Ct.Name = "dteNgay_Ct";
			this.dteNgay_Ct.Size = new System.Drawing.Size(66, 20);
			this.dteNgay_Ct.TabIndex = 3;
			// 
			// dgvEditCt1
			// 
			this.dgvEditCt1.AllowUserToAddRows = false;
			this.dgvEditCt1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvEditCt1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvEditCt1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEditCt1.BackgroundColor = System.Drawing.Color.White;
			this.dgvEditCt1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvEditCt1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvEditCt1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvEditCt1.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvEditCt1.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvEditCt1.Location = new System.Drawing.Point(2, 306);
			this.dgvEditCt1.MultiSelect = false;
			this.dgvEditCt1.Name = "dgvEditCt1";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvEditCt1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvEditCt1.Size = new System.Drawing.Size(828, 124);
			this.dgvEditCt1.strZone = "";
			this.dgvEditCt1.TabIndex = 15;
			// 
			// rsLabel1
			// 
			this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(10, 435);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(104, 14);
			this.rsLabel1.TabIndex = 64;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Những đề xuất khác";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDe_Xuat
			// 
			this.txtDe_Xuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtDe_Xuat.AutoDropDown = null;
			this.txtDe_Xuat.Location = new System.Drawing.Point(121, 433);
			this.txtDe_Xuat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDe_Xuat.MaxLength = 200;
			this.txtDe_Xuat.Multiline = true;
			this.txtDe_Xuat.Name = "txtDe_Xuat";
			this.txtDe_Xuat.Size = new System.Drawing.Size(695, 72);
			this.txtDe_Xuat.TabIndex = 16;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "excel");
			// 
			// txtMa_Ct
			// 
			this.txtMa_Ct.AutoDropDown = null;
			this.txtMa_Ct.BackColor = System.Drawing.SystemColors.Control;
			this.txtMa_Ct.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtMa_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Ct.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMa_Ct.ForeColor = System.Drawing.Color.Red;
			this.txtMa_Ct.Location = new System.Drawing.Point(89, 16);
			this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Ct.MaxLength = 20;
			this.txtMa_Ct.Name = "txtMa_Ct";
			this.txtMa_Ct.Size = new System.Drawing.Size(25, 13);
			this.txtMa_Ct.TabIndex = 0;
			this.txtMa_Ct.TabStop = false;
			this.txtMa_Ct.Text = "CT";
			// 
			// lblMa_Nvu
			// 
			this.lblMa_Nvu.AutoEllipsis = true;
			this.lblMa_Nvu.AutoSize = true;
			this.lblMa_Nvu.Location = new System.Drawing.Point(14, 17);
			this.lblMa_Nvu.Name = "lblMa_Nvu";
			this.lblMa_Nvu.Size = new System.Drawing.Size(71, 14);
			this.lblMa_Nvu.TabIndex = 1007;
			this.lblMa_Nvu.Tag = "Ma_Nvu";
			this.lblMa_Nvu.Text = "Mã nghiệp vụ";
			this.lblMa_Nvu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Nvu
			// 
			this.txtMa_Nvu.AutoDropDown = null;
			this.txtMa_Nvu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Nvu.Location = new System.Drawing.Point(121, 13);
			this.txtMa_Nvu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Nvu.MaxLength = 20;
			this.txtMa_Nvu.Name = "txtMa_Nvu";
			this.txtMa_Nvu.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Nvu.TabIndex = 0;
			// 
			// lbtTen_Nvu
			// 
			this.lbtTen_Nvu.AutoEllipsis = true;
			this.lbtTen_Nvu.AutoSize = true;
			this.lbtTen_Nvu.ForeColor = System.Drawing.Color.Blue;
			this.lbtTen_Nvu.Location = new System.Drawing.Point(246, 17);
			this.lbtTen_Nvu.Name = "lbtTen_Nvu";
			this.lbtTen_Nvu.Size = new System.Drawing.Size(75, 14);
			this.lbtTen_Nvu.TabIndex = 1008;
			this.lbtTen_Nvu.Text = "Tên nghiệp vụ";
			this.lbtTen_Nvu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDien_Giai
			// 
			this.lblDien_Giai.AutoEllipsis = true;
			this.lblDien_Giai.AutoSize = true;
			this.lblDien_Giai.Location = new System.Drawing.Point(14, 97);
			this.lblDien_Giai.Name = "lblDien_Giai";
			this.lblDien_Giai.Size = new System.Drawing.Size(49, 14);
			this.lblDien_Giai.TabIndex = 64;
			this.lblDien_Giai.Tag = "";
			this.lblDien_Giai.Text = "Nội dung";
			this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDien_Giai
			// 
			this.txtDien_Giai.AutoDropDown = null;
			this.txtDien_Giai.Location = new System.Drawing.Point(121, 94);
			this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDien_Giai.MaxLength = 200;
			this.txtDien_Giai.Name = "txtDien_Giai";
			this.txtDien_Giai.Size = new System.Drawing.Size(695, 20);
			this.txtDien_Giai.TabIndex = 4;
			// 
			// txtDia_ChiA
			// 
			this.txtDia_ChiA.AutoDropDown = null;
			this.txtDia_ChiA.Location = new System.Drawing.Point(121, 144);
			this.txtDia_ChiA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDia_ChiA.MaxLength = 200;
			this.txtDia_ChiA.Name = "txtDia_ChiA";
			this.txtDia_ChiA.Size = new System.Drawing.Size(695, 20);
			this.txtDia_ChiA.TabIndex = 6;
			// 
			// lblDia_Chi
			// 
			this.lblDia_Chi.AutoEllipsis = true;
			this.lblDia_Chi.AutoSize = true;
			this.lblDia_Chi.Location = new System.Drawing.Point(54, 147);
			this.lblDia_Chi.Name = "lblDia_Chi";
			this.lblDia_Chi.Size = new System.Drawing.Size(40, 14);
			this.lblDia_Chi.TabIndex = 1016;
			this.lblDia_Chi.Tag = "Dia_Chi";
			this.lblDia_Chi.Text = "Địa chỉ";
			this.lblDia_Chi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtOng_BaA
			// 
			this.txtOng_BaA.AutoDropDown = null;
			this.txtOng_BaA.Location = new System.Drawing.Point(121, 187);
			this.txtOng_BaA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtOng_BaA.MaxLength = 100;
			this.txtOng_BaA.Name = "txtOng_BaA";
			this.txtOng_BaA.Size = new System.Drawing.Size(200, 20);
			this.txtOng_BaA.TabIndex = 8;
			// 
			// lblOng_Ba
			// 
			this.lblOng_Ba.AutoEllipsis = true;
			this.lblOng_Ba.AutoSize = true;
			this.lblOng_Ba.Location = new System.Drawing.Point(54, 190);
			this.lblOng_Ba.Name = "lblOng_Ba";
			this.lblOng_Ba.Size = new System.Drawing.Size(42, 14);
			this.lblOng_Ba.TabIndex = 1015;
			this.lblOng_Ba.Tag = "Ong_Ba";
			this.lblOng_Ba.Text = "Ông bà";
			this.lblOng_Ba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(14, 125);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(36, 14);
			this.rsLabel2.TabIndex = 1017;
			this.rsLabel2.Tag = "";
			this.rsLabel2.Text = "Bên A";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(14, 222);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(36, 14);
			this.rsLabel3.TabIndex = 1018;
			this.rsLabel3.Tag = "";
			this.rsLabel3.Text = "Bên B";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTen_DtA
			// 
			this.txtTen_DtA.AutoDropDown = null;
			this.txtTen_DtA.Location = new System.Drawing.Point(121, 122);
			this.txtTen_DtA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_DtA.MaxLength = 200;
			this.txtTen_DtA.Name = "txtTen_DtA";
			this.txtTen_DtA.Size = new System.Drawing.Size(695, 20);
			this.txtTen_DtA.TabIndex = 5;
			// 
			// txtTen_DtB
			// 
			this.txtTen_DtB.AutoDropDown = null;
			this.txtTen_DtB.Location = new System.Drawing.Point(121, 216);
			this.txtTen_DtB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_DtB.MaxLength = 200;
			this.txtTen_DtB.Name = "txtTen_DtB";
			this.txtTen_DtB.Size = new System.Drawing.Size(695, 20);
			this.txtTen_DtB.TabIndex = 10;
			// 
			// txtDia_ChiB
			// 
			this.txtDia_ChiB.AutoDropDown = null;
			this.txtDia_ChiB.Location = new System.Drawing.Point(121, 238);
			this.txtDia_ChiB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDia_ChiB.MaxLength = 200;
			this.txtDia_ChiB.Name = "txtDia_ChiB";
			this.txtDia_ChiB.Size = new System.Drawing.Size(695, 20);
			this.txtDia_ChiB.TabIndex = 11;
			// 
			// txtChuc_VuA
			// 
			this.txtChuc_VuA.AutoDropDown = null;
			this.txtChuc_VuA.Location = new System.Drawing.Point(469, 187);
			this.txtChuc_VuA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtChuc_VuA.MaxLength = 100;
			this.txtChuc_VuA.Name = "txtChuc_VuA";
			this.txtChuc_VuA.Size = new System.Drawing.Size(202, 20);
			this.txtChuc_VuA.TabIndex = 9;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Location = new System.Drawing.Point(402, 190);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(48, 14);
			this.rsLabel4.TabIndex = 1024;
			this.rsLabel4.Tag = "";
			this.rsLabel4.Text = "Chức vụ";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMSTA
			// 
			this.txtMSTA.AutoDropDown = null;
			this.txtMSTA.Location = new System.Drawing.Point(121, 165);
			this.txtMSTA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMSTA.MaxLength = 100;
			this.txtMSTA.Name = "txtMSTA";
			this.txtMSTA.Size = new System.Drawing.Size(200, 20);
			this.txtMSTA.TabIndex = 7;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Location = new System.Drawing.Point(54, 168);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(28, 14);
			this.rsLabel5.TabIndex = 1026;
			this.rsLabel5.Tag = "";
			this.rsLabel5.Text = "MST";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMSTB
			// 
			this.txtMSTB.AutoDropDown = null;
			this.txtMSTB.Location = new System.Drawing.Point(121, 259);
			this.txtMSTB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMSTB.MaxLength = 100;
			this.txtMSTB.Name = "txtMSTB";
			this.txtMSTB.Size = new System.Drawing.Size(200, 20);
			this.txtMSTB.TabIndex = 12;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(54, 262);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(28, 14);
			this.rsLabel6.TabIndex = 1032;
			this.rsLabel6.Tag = "";
			this.rsLabel6.Text = "MST";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtChuc_VuB
			// 
			this.txtChuc_VuB.AutoDropDown = null;
			this.txtChuc_VuB.Location = new System.Drawing.Point(469, 281);
			this.txtChuc_VuB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtChuc_VuB.MaxLength = 100;
			this.txtChuc_VuB.Name = "txtChuc_VuB";
			this.txtChuc_VuB.Size = new System.Drawing.Size(202, 20);
			this.txtChuc_VuB.TabIndex = 14;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Location = new System.Drawing.Point(402, 284);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(48, 14);
			this.rsLabel7.TabIndex = 1030;
			this.rsLabel7.Tag = "";
			this.rsLabel7.Text = "Chức vụ";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtOng_BaB
			// 
			this.txtOng_BaB.AutoDropDown = null;
			this.txtOng_BaB.Location = new System.Drawing.Point(121, 281);
			this.txtOng_BaB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtOng_BaB.MaxLength = 100;
			this.txtOng_BaB.Name = "txtOng_BaB";
			this.txtOng_BaB.Size = new System.Drawing.Size(200, 20);
			this.txtOng_BaB.TabIndex = 13;
			// 
			// rsLabel8
			// 
			this.rsLabel8.AutoEllipsis = true;
			this.rsLabel8.AutoSize = true;
			this.rsLabel8.Location = new System.Drawing.Point(54, 284);
			this.rsLabel8.Name = "rsLabel8";
			this.rsLabel8.Size = new System.Drawing.Size(42, 14);
			this.rsLabel8.TabIndex = 1028;
			this.rsLabel8.Tag = "Ong_Ba";
			this.rsLabel8.Text = "Ông bà";
			this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel9
			// 
			this.rsLabel9.AutoEllipsis = true;
			this.rsLabel9.AutoSize = true;
			this.rsLabel9.Location = new System.Drawing.Point(54, 241);
			this.rsLabel9.Name = "rsLabel9";
			this.rsLabel9.Size = new System.Drawing.Size(40, 14);
			this.rsLabel9.TabIndex = 1033;
			this.rsLabel9.Tag = "Dia_Chi";
			this.rsLabel9.Text = "Địa chỉ";
			this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmBBNT_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(832, 578);
			this.Controls.Add(this.rsLabel9);
			this.Controls.Add(this.txtMSTB);
			this.Controls.Add(this.rsLabel6);
			this.Controls.Add(this.txtChuc_VuB);
			this.Controls.Add(this.rsLabel7);
			this.Controls.Add(this.txtOng_BaB);
			this.Controls.Add(this.rsLabel8);
			this.Controls.Add(this.txtMSTA);
			this.Controls.Add(this.rsLabel5);
			this.Controls.Add(this.txtChuc_VuA);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.txtTen_DtB);
			this.Controls.Add(this.txtDia_ChiB);
			this.Controls.Add(this.txtTen_DtA);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.txtDia_ChiA);
			this.Controls.Add(this.lblDia_Chi);
			this.Controls.Add(this.txtOng_BaA);
			this.Controls.Add(this.lblOng_Ba);
			this.Controls.Add(this.txtMa_Ct);
			this.Controls.Add(this.lblMa_Nvu);
			this.Controls.Add(this.txtMa_Nvu);
			this.Controls.Add(this.lbtTen_Nvu);
			this.Controls.Add(this.numTy_Gia);
			this.Controls.Add(this.dgvEditCt1);
			this.Controls.Add(this.txtMa_Tte);
			this.Controls.Add(this.txtDien_Giai);
			this.Controls.Add(this.txtDe_Xuat);
			this.Controls.Add(this.lblDien_Giai);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.lblMa_Tte);
			this.Controls.Add(this.txtSo_Hd);
			this.Controls.Add(this.lblSo_Ct);
			this.Controls.Add(this.lblNgay_Ct);
			this.Controls.Add(this.dteNgay_Ct);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Name = "frmBBNT_Edit";
			this.Object_ID = "BBNT";
			this.Tag = "frmCtSO, ESC";
			this.Text = "frmCtSO";
			this.Controls.SetChildIndex(this.btgAccept, 0);
			this.Controls.SetChildIndex(this.cboSaveOption, 0);
			this.Controls.SetChildIndex(this.dteNgay_Ct, 0);
			this.Controls.SetChildIndex(this.lblNgay_Ct, 0);
			this.Controls.SetChildIndex(this.lblSo_Ct, 0);
			this.Controls.SetChildIndex(this.txtSo_Hd, 0);
			this.Controls.SetChildIndex(this.lblMa_Tte, 0);
			this.Controls.SetChildIndex(this.rsLabel1, 0);
			this.Controls.SetChildIndex(this.lblDien_Giai, 0);
			this.Controls.SetChildIndex(this.txtDe_Xuat, 0);
			this.Controls.SetChildIndex(this.txtDien_Giai, 0);
			this.Controls.SetChildIndex(this.txtMa_Tte, 0);
			this.Controls.SetChildIndex(this.dgvEditCt1, 0);
			this.Controls.SetChildIndex(this.numTy_Gia, 0);
			this.Controls.SetChildIndex(this.lbtTen_Nvu, 0);
			this.Controls.SetChildIndex(this.txtMa_Nvu, 0);
			this.Controls.SetChildIndex(this.lblMa_Nvu, 0);
			this.Controls.SetChildIndex(this.txtMa_Ct, 0);
			this.Controls.SetChildIndex(this.lblLog, 0);
			this.Controls.SetChildIndex(this.pictureBox1, 0);
			this.Controls.SetChildIndex(this.lblOng_Ba, 0);
			this.Controls.SetChildIndex(this.txtOng_BaA, 0);
			this.Controls.SetChildIndex(this.lblDia_Chi, 0);
			this.Controls.SetChildIndex(this.txtDia_ChiA, 0);
			this.Controls.SetChildIndex(this.rsLabel2, 0);
			this.Controls.SetChildIndex(this.rsLabel3, 0);
			this.Controls.SetChildIndex(this.txtTen_DtA, 0);
			this.Controls.SetChildIndex(this.txtDia_ChiB, 0);
			this.Controls.SetChildIndex(this.txtTen_DtB, 0);
			this.Controls.SetChildIndex(this.rsLabel4, 0);
			this.Controls.SetChildIndex(this.txtChuc_VuA, 0);
			this.Controls.SetChildIndex(this.rsLabel5, 0);
			this.Controls.SetChildIndex(this.txtMSTA, 0);
			this.Controls.SetChildIndex(this.rsLabel8, 0);
			this.Controls.SetChildIndex(this.txtOng_BaB, 0);
			this.Controls.SetChildIndex(this.rsLabel7, 0);
			this.Controls.SetChildIndex(this.txtChuc_VuB, 0);
			this.Controls.SetChildIndex(this.rsLabel6, 0);
			this.Controls.SetChildIndex(this.txtMSTB, 0);
			this.Controls.SetChildIndex(this.rsLabel9, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsEditCt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvEditCt1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDateTime dteNgay_Ct;
		private RosySystem.Control.rsLabel lblNgay_Ct;
		private RosySystem.Control.rsTextBox txtSo_Hd;
		private RosySystem.Control.rsLabel lblSo_Ct;
        private RosySystem.Control.rsLabel lblMa_Tte;
		private RosySystem.Control.rsTextBoxEnum txtMa_Tte;
        private RosySystem.Control.rsTextBoxNumber numTy_Gia;
        private RosySystem.Customize.dgvVoucher dgvEditCt1;
		private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtDe_Xuat;
        private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Control.rsTextBox txtMa_Ct;
		private RosySystem.Control.rsLabel lblMa_Nvu;
		private RosySystem.Control.rsTextBox txtMa_Nvu;
		private RosySystem.Control.rsLabel lbtTen_Nvu;
		private RosySystem.Control.rsLabel lblDien_Giai;
        private RosySystem.Control.rsTextBox txtDien_Giai;
		private RosySystem.Control.rsTextBox txtDia_ChiA;
		private RosySystem.Control.rsLabel lblDia_Chi;
		private RosySystem.Control.rsTextBox txtOng_BaA;
        private RosySystem.Control.rsLabel lblOng_Ba;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtTen_DtA;
        private RosySystem.Control.rsTextBox txtTen_DtB;
        private RosySystem.Control.rsTextBox txtDia_ChiB;
        private RosySystem.Control.rsTextBox txtChuc_VuA;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBox txtMSTA;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBox txtMSTB;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBox txtChuc_VuB;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsTextBox txtOng_BaB;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsLabel rsLabel9;
	}
}