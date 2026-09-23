namespace RosyModule.ScaleBarcode
{
	partial class frmDmBarcode_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmBarcode_Edit));
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.numLength = new RosySystem.Control.rsNumericUpdown();
            this.numNum_Bars = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel15 = new RosySystem.Control.rsLabel();
            this.rsLabel14 = new RosySystem.Control.rsLabel();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.cboLot_ID = new RosySystem.Control.rsComboBox();
            this.rsLabel12 = new RosySystem.Control.rsLabel();
            this.cboMa_CL = new RosySystem.Control.rsComboBox();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.cboGrade_ID = new RosySystem.Control.rsComboBox();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.cboStandard_ID = new RosySystem.Control.rsComboBox();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.cboMa_Size = new RosySystem.Control.rsComboBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtBarcode = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btSaveAndPrint = new RosySystem.Control.rsButton();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtLy_Do = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.numSo_Luong = new RosySystem.Control.rsNumericUpdown();
            this.numSo_Luong_Barem = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtNo_Melt = new RosySystem.Control.rsTextBox();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.txtMa_Ca = new RosySystem.Control.rsTextBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.lbtCa = new RosySystem.Control.rsLabelName();
            this.lbtTen_Vt_Sp = new RosySystem.Control.rsLabelName();
            this.txtMa_Vt_Sp = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.txtNum_Lot_Concat1 = new RosySystem.Control.rsTextBox();
            this.numNum_Lot_Concat2 = new RosySystem.Control.rsNumericUpdown();
            this.txtNum_Lot = new RosySystem.Control.rsTextBox();
            this.enuIs_Barem = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabel16 = new RosySystem.Control.rsLabel();
            this.rsLabelName1 = new RosySystem.Control.rsLabelName();
            this.numNum_Last = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel26 = new RosySystem.Control.rsLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNum_Bars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSo_Luong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSo_Luong_Barem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNum_Lot_Concat2)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(276, 331);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 45);
            this.btgAccept.TabIndex = 19;
            // 
            // numLength
            // 
            this.numLength.DecimalPlaces = 3;
            this.numLength.Enabled = false;
            this.numLength.Location = new System.Drawing.Point(328, 230);
            this.numLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(93, 20);
            this.numLength.TabIndex = 13;
            this.numLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numNum_Bars
            // 
            this.numNum_Bars.Enabled = false;
            this.numNum_Bars.Location = new System.Drawing.Point(149, 230);
            this.numNum_Bars.Margin = new System.Windows.Forms.Padding(2);
            this.numNum_Bars.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNum_Bars.Name = "numNum_Bars";
            this.numNum_Bars.Size = new System.Drawing.Size(93, 20);
            this.numNum_Bars.TabIndex = 12;
            this.numNum_Bars.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel15
            // 
            this.rsLabel15.AutoEllipsis = true;
            this.rsLabel15.AutoSize = true;
            this.rsLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel15.Location = new System.Drawing.Point(247, 232);
            this.rsLabel15.Name = "rsLabel15";
            this.rsLabel15.Size = new System.Drawing.Size(76, 17);
            this.rsLabel15.TabIndex = 40;
            this.rsLabel15.Text = "Chiều dài";
            this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel14
            // 
            this.rsLabel14.AutoEllipsis = true;
            this.rsLabel14.AutoSize = true;
            this.rsLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel14.Location = new System.Drawing.Point(30, 231);
            this.rsLabel14.Name = "rsLabel14";
            this.rsLabel14.Size = new System.Drawing.Size(73, 17);
            this.rsLabel14.TabIndex = 39;
            this.rsLabel14.Text = "Số thanh";
            this.rsLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel13.Location = new System.Drawing.Point(30, 209);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(101, 17);
            this.rsLabel13.TabIndex = 38;
            this.rsLabel13.Text = "Lô sản phẩm";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLot_ID
            // 
            this.cboLot_ID.DropDownHeight = 95;
            this.cboLot_ID.FormattingEnabled = true;
            this.cboLot_ID.IntegralHeight = false;
            this.cboLot_ID.Location = new System.Drawing.Point(149, 185);
            this.cboLot_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboLot_ID.Name = "cboLot_ID";
            this.cboLot_ID.Size = new System.Drawing.Size(272, 21);
            this.cboLot_ID.TabIndex = 8;
            // 
            // rsLabel12
            // 
            this.rsLabel12.AutoEllipsis = true;
            this.rsLabel12.AutoSize = true;
            this.rsLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel12.Location = new System.Drawing.Point(30, 185);
            this.rsLabel12.Name = "rsLabel12";
            this.rsLabel12.Size = new System.Drawing.Size(62, 17);
            this.rsLabel12.TabIndex = 36;
            this.rsLabel12.Text = "Lô phôi";
            this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_CL
            // 
            this.cboMa_CL.DropDownHeight = 95;
            this.cboMa_CL.FormattingEnabled = true;
            this.cboMa_CL.IntegralHeight = false;
            this.cboMa_CL.Location = new System.Drawing.Point(149, 162);
            this.cboMa_CL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_CL.Name = "cboMa_CL";
            this.cboMa_CL.Size = new System.Drawing.Size(76, 21);
            this.cboMa_CL.TabIndex = 6;
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel10.Location = new System.Drawing.Point(30, 162);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(86, 17);
            this.rsLabel10.TabIndex = 33;
            this.rsLabel10.Text = "Chất lượng";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboGrade_ID
            // 
            this.cboGrade_ID.DropDownHeight = 95;
            this.cboGrade_ID.Enabled = false;
            this.cboGrade_ID.FormattingEnabled = true;
            this.cboGrade_ID.IntegralHeight = false;
            this.cboGrade_ID.Location = new System.Drawing.Point(149, 139);
            this.cboGrade_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboGrade_ID.Name = "cboGrade_ID";
            this.cboGrade_ID.Size = new System.Drawing.Size(272, 21);
            this.cboGrade_ID.TabIndex = 5;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel9.Location = new System.Drawing.Point(30, 139);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(74, 17);
            this.rsLabel9.TabIndex = 31;
            this.rsLabel9.Text = "Mác thép";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboStandard_ID
            // 
            this.cboStandard_ID.DropDownHeight = 95;
            this.cboStandard_ID.Enabled = false;
            this.cboStandard_ID.FormattingEnabled = true;
            this.cboStandard_ID.IntegralHeight = false;
            this.cboStandard_ID.Location = new System.Drawing.Point(149, 116);
            this.cboStandard_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboStandard_ID.Name = "cboStandard_ID";
            this.cboStandard_ID.Size = new System.Drawing.Size(272, 21);
            this.cboStandard_ID.TabIndex = 4;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel8.Location = new System.Drawing.Point(30, 116);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(89, 17);
            this.rsLabel8.TabIndex = 29;
            this.rsLabel8.Text = "Tiêu chuẩn";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_Size
            // 
            this.cboMa_Size.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Size.DropDownHeight = 95;
            this.cboMa_Size.Enabled = false;
            this.cboMa_Size.FormattingEnabled = true;
            this.cboMa_Size.IntegralHeight = false;
            this.cboMa_Size.Location = new System.Drawing.Point(149, 93);
            this.cboMa_Size.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Size.Name = "cboMa_Size";
            this.cboMa_Size.Size = new System.Drawing.Size(272, 21);
            this.cboMa_Size.TabIndex = 3;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel7.Location = new System.Drawing.Point(30, 93);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(84, 17);
            this.rsLabel7.TabIndex = 27;
            this.rsLabel7.Text = "Kích thước";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoDropDown = null;
            this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(149, 17);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(272, 30);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(30, 23);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(68, 17);
            this.rsLabel1.TabIndex = 45;
            this.rsLabel1.Text = "Barcode";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSaveAndPrint
            // 
            this.btSaveAndPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveAndPrint.Image = ((System.Drawing.Image)(resources.GetObject("btSaveAndPrint.Image")));
            this.btSaveAndPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveAndPrint.Location = new System.Drawing.Point(184, 331);
            this.btSaveAndPrint.Name = "btSaveAndPrint";
            this.btSaveAndPrint.Size = new System.Drawing.Size(86, 43);
            this.btSaveAndPrint.TabIndex = 18;
            this.btSaveAndPrint.Text = "Lưu && In";
            this.btSaveAndPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSaveAndPrint.UseVisualStyleBackColor = true;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(31, 275);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(79, 17);
            this.rsLabel2.TabIndex = 46;
            this.rsLabel2.Text = "Lý do sửa";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLy_Do
            // 
            this.txtLy_Do.AutoDropDown = null;
            this.txtLy_Do.Location = new System.Drawing.Point(149, 274);
            this.txtLy_Do.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLy_Do.Name = "txtLy_Do";
            this.txtLy_Do.Size = new System.Drawing.Size(272, 20);
            this.txtLy_Do.TabIndex = 16;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(30, 252);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(85, 17);
            this.rsLabel3.TabIndex = 47;
            this.rsLabel3.Text = "Khối lượng";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.Location = new System.Drawing.Point(149, 252);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2);
            this.numSo_Luong.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Size = new System.Drawing.Size(93, 20);
            this.numSo_Luong.TabIndex = 14;
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numSo_Luong_Barem
            // 
            this.numSo_Luong_Barem.Enabled = false;
            this.numSo_Luong_Barem.Location = new System.Drawing.Point(328, 252);
            this.numSo_Luong_Barem.Margin = new System.Windows.Forms.Padding(2);
            this.numSo_Luong_Barem.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSo_Luong_Barem.Name = "numSo_Luong_Barem";
            this.numSo_Luong_Barem.Size = new System.Drawing.Size(93, 20);
            this.numSo_Luong_Barem.TabIndex = 15;
            this.numSo_Luong_Barem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.Location = new System.Drawing.Point(247, 252);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(78, 17);
            this.rsLabel4.TabIndex = 49;
            this.rsLabel4.Text = "KL Barem";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNo_Melt
            // 
            this.txtNo_Melt.AutoDropDown = null;
            this.txtNo_Melt.Location = new System.Drawing.Point(308, 163);
            this.txtNo_Melt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNo_Melt.Name = "txtNo_Melt";
            this.txtNo_Melt.Size = new System.Drawing.Size(113, 20);
            this.txtNo_Melt.TabIndex = 7;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel11.Location = new System.Drawing.Point(230, 164);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(73, 17);
            this.rsLabel11.TabIndex = 51;
            this.rsLabel11.Text = "Mẻ luyện";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ca
            // 
            this.txtMa_Ca.AutoDropDown = null;
            this.txtMa_Ca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ca.Enabled = false;
            this.txtMa_Ca.Location = new System.Drawing.Point(149, 49);
            this.txtMa_Ca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ca.Name = "txtMa_Ca";
            this.txtMa_Ca.Size = new System.Drawing.Size(103, 20);
            this.txtMa_Ca.TabIndex = 1;
            this.txtMa_Ca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel5.Location = new System.Drawing.Point(30, 49);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(51, 17);
            this.rsLabel5.TabIndex = 62;
            this.rsLabel5.Text = "Mã ca";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtCa
            // 
            this.lbtCa.AutoSize = true;
            this.lbtCa.ForeColor = System.Drawing.Color.Blue;
            this.lbtCa.Location = new System.Drawing.Point(257, 53);
            this.lbtCa.Name = "lbtCa";
            this.lbtCa.Size = new System.Drawing.Size(20, 13);
            this.lbtCa.TabIndex = 63;
            this.lbtCa.Text = "Ca";
            this.lbtCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt_Sp
            // 
            this.lbtTen_Vt_Sp.AutoSize = true;
            this.lbtTen_Vt_Sp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Sp.Location = new System.Drawing.Point(257, 75);
            this.lbtTen_Vt_Sp.Name = "lbtTen_Vt_Sp";
            this.lbtTen_Vt_Sp.Size = new System.Drawing.Size(75, 13);
            this.lbtTen_Vt_Sp.TabIndex = 66;
            this.lbtTen_Vt_Sp.Text = "Tên sản phẩm";
            this.lbtTen_Vt_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt_Sp
            // 
            this.txtMa_Vt_Sp.AutoDropDown = null;
            this.txtMa_Vt_Sp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt_Sp.Location = new System.Drawing.Point(149, 71);
            this.txtMa_Vt_Sp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt_Sp.Name = "txtMa_Vt_Sp";
            this.txtMa_Vt_Sp.Size = new System.Drawing.Size(103, 20);
            this.txtMa_Vt_Sp.TabIndex = 2;
            this.txtMa_Vt_Sp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel6.Location = new System.Drawing.Point(30, 71);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(104, 17);
            this.rsLabel6.TabIndex = 65;
            this.rsLabel6.Text = "Mã sản phẩm";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNum_Lot_Concat1
            // 
            this.txtNum_Lot_Concat1.AutoDropDown = null;
            this.txtNum_Lot_Concat1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNum_Lot_Concat1.Enabled = false;
            this.txtNum_Lot_Concat1.Location = new System.Drawing.Point(149, 208);
            this.txtNum_Lot_Concat1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNum_Lot_Concat1.Name = "txtNum_Lot_Concat1";
            this.txtNum_Lot_Concat1.Size = new System.Drawing.Size(93, 20);
            this.txtNum_Lot_Concat1.TabIndex = 9;
            this.txtNum_Lot_Concat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum_Lot_Concat1.Visible = false;
            // 
            // numNum_Lot_Concat2
            // 
            this.numNum_Lot_Concat2.Location = new System.Drawing.Point(242, 208);
            this.numNum_Lot_Concat2.Margin = new System.Windows.Forms.Padding(2);
            this.numNum_Lot_Concat2.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numNum_Lot_Concat2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNum_Lot_Concat2.Name = "numNum_Lot_Concat2";
            this.numNum_Lot_Concat2.Size = new System.Drawing.Size(63, 20);
            this.numNum_Lot_Concat2.TabIndex = 10;
            this.numNum_Lot_Concat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNum_Lot_Concat2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNum_Lot_Concat2.Visible = false;
            // 
            // txtNum_Lot
            // 
            this.txtNum_Lot.AutoDropDown = null;
            this.txtNum_Lot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNum_Lot.Enabled = false;
            this.txtNum_Lot.Location = new System.Drawing.Point(149, 208);
            this.txtNum_Lot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNum_Lot.Name = "txtNum_Lot";
            this.txtNum_Lot.Size = new System.Drawing.Size(272, 20);
            this.txtNum_Lot.TabIndex = 11;
            // 
            // enuIs_Barem
            // 
            this.enuIs_Barem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.enuIs_Barem.AutoDropDown = null;
            this.enuIs_Barem.InputMask = "0,1";
            this.enuIs_Barem.Location = new System.Drawing.Point(149, 296);
            this.enuIs_Barem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.enuIs_Barem.Name = "enuIs_Barem";
            this.enuIs_Barem.Size = new System.Drawing.Size(29, 20);
            this.enuIs_Barem.TabIndex = 17;
            this.enuIs_Barem.Text = "0";
            // 
            // rsLabel16
            // 
            this.rsLabel16.AutoEllipsis = true;
            this.rsLabel16.AutoSize = true;
            this.rsLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel16.Location = new System.Drawing.Point(30, 297);
            this.rsLabel16.Name = "rsLabel16";
            this.rsLabel16.Size = new System.Drawing.Size(57, 17);
            this.rsLabel16.TabIndex = 71;
            this.rsLabel16.Text = "Loại in";
            this.rsLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabelName1
            // 
            this.rsLabelName1.AutoSize = true;
            this.rsLabelName1.ForeColor = System.Drawing.Color.Blue;
            this.rsLabelName1.Location = new System.Drawing.Point(183, 299);
            this.rsLabelName1.Name = "rsLabelName1";
            this.rsLabelName1.Size = new System.Drawing.Size(260, 13);
            this.rsLabelName1.TabIndex = 72;
            this.rsLabelName1.Text = "0- In theo khối lượng cân, 1- In theo khối lượng barem";
            this.rsLabelName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNum_Last
            // 
            this.numNum_Last.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numNum_Last.AutoDropDown = null;
            this.numNum_Last.bFormat = true;
            this.numNum_Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNum_Last.Location = new System.Drawing.Point(369, 49);
            this.numNum_Last.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNum_Last.Name = "numNum_Last";
            this.numNum_Last.Scale = 0;
            this.numNum_Last.Size = new System.Drawing.Size(52, 23);
            this.numNum_Last.TabIndex = 74;
            this.numNum_Last.Text = "0";
            this.numNum_Last.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNum_Last.Value = 0D;
            // 
            // rsLabel26
            // 
            this.rsLabel26.AutoEllipsis = true;
            this.rsLabel26.AutoSize = true;
            this.rsLabel26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel26.Location = new System.Drawing.Point(318, 50);
            this.rsLabel26.Name = "rsLabel26";
            this.rsLabel26.Size = new System.Drawing.Size(46, 17);
            this.rsLabel26.TabIndex = 73;
            this.rsLabel26.Text = "Stt lô";
            this.rsLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmBarcode_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 388);
            this.Controls.Add(this.numNum_Last);
            this.Controls.Add(this.rsLabel26);
            this.Controls.Add(this.rsLabelName1);
            this.Controls.Add(this.rsLabel16);
            this.Controls.Add(this.enuIs_Barem);
            this.Controls.Add(this.txtNum_Lot_Concat1);
            this.Controls.Add(this.numNum_Lot_Concat2);
            this.Controls.Add(this.txtNum_Lot);
            this.Controls.Add(this.lbtTen_Vt_Sp);
            this.Controls.Add(this.txtMa_Vt_Sp);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.lbtCa);
            this.Controls.Add(this.txtMa_Ca);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.txtNo_Melt);
            this.Controls.Add(this.rsLabel11);
            this.Controls.Add(this.numSo_Luong_Barem);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.numSo_Luong);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtLy_Do);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.btSaveAndPrint);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.numLength);
            this.Controls.Add(this.numNum_Bars);
            this.Controls.Add(this.rsLabel15);
            this.Controls.Add(this.rsLabel14);
            this.Controls.Add(this.rsLabel13);
            this.Controls.Add(this.cboLot_ID);
            this.Controls.Add(this.rsLabel12);
            this.Controls.Add(this.cboMa_CL);
            this.Controls.Add(this.rsLabel10);
            this.Controls.Add(this.cboGrade_ID);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.cboStandard_ID);
            this.Controls.Add(this.rsLabel8);
            this.Controls.Add(this.cboMa_Size);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.btgAccept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDmBarcode_Edit";
            this.Tag = "frmDmBarcode,ESC";
            this.Text = "frmDmBarcode_Edit";
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNum_Bars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSo_Luong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSo_Luong_Barem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNum_Lot_Concat2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsNumericUpdown numLength;
		private RosySystem.Control.rsNumericUpdown numNum_Bars;
		private RosySystem.Control.rsLabel rsLabel15;
		private RosySystem.Control.rsLabel rsLabel14;
		private RosySystem.Control.rsLabel rsLabel13;
		private RosySystem.Control.rsComboBox cboLot_ID;
		private RosySystem.Control.rsLabel rsLabel12;
		private RosySystem.Control.rsComboBox cboMa_CL;
		private RosySystem.Control.rsLabel rsLabel10;
		private RosySystem.Control.rsComboBox cboGrade_ID;
		private RosySystem.Control.rsLabel rsLabel9;
		private RosySystem.Control.rsComboBox cboStandard_ID;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsComboBox cboMa_Size;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsTextBox txtBarcode;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsButton btSaveAndPrint;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBox txtLy_Do;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsNumericUpdown numSo_Luong;
		private RosySystem.Control.rsNumericUpdown numSo_Luong_Barem;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBox txtNo_Melt;
		private RosySystem.Control.rsLabel rsLabel11;
		private RosySystem.Control.rsTextBox txtMa_Ca;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabelName lbtCa;
		private RosySystem.Control.rsLabelName lbtTen_Vt_Sp;
		private RosySystem.Control.rsTextBox txtMa_Vt_Sp;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsTextBox txtNum_Lot_Concat1;
		private RosySystem.Control.rsNumericUpdown numNum_Lot_Concat2;
		private RosySystem.Control.rsTextBox txtNum_Lot;
		private RosySystem.Control.rsTextBoxEnum enuIs_Barem;
		private RosySystem.Control.rsLabel rsLabel16;
		private RosySystem.Control.rsLabelName rsLabelName1;
        private RosySystem.Control.rsTextBoxNumber numNum_Last;
        private RosySystem.Control.rsLabel rsLabel26;
    }
}