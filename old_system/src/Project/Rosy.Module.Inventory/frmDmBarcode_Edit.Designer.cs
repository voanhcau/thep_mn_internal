namespace RosyModule
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
			this.txtNum_Lot = new RosySystem.Control.rsTextBox();
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
			this.cboMa_Vt = new RosySystem.Control.rsComboBox();
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
			((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numNum_Bars)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSo_Luong)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSo_Luong_Barem)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(259, 282);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(180, 45);
			this.btgAccept.TabIndex = 14;
			// 
			// txtNum_Lot
			// 
			this.txtNum_Lot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNum_Lot.Enabled = false;
			this.txtNum_Lot.Location = new System.Drawing.Point(149, 177);
			this.txtNum_Lot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtNum_Lot.Name = "txtNum_Lot";
			this.txtNum_Lot.Size = new System.Drawing.Size(272, 20);
			this.txtNum_Lot.TabIndex = 7;
			this.txtNum_Lot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// numLength
			// 
			this.numLength.DecimalPlaces = 3;
			this.numLength.Location = new System.Drawing.Point(328, 199);
			this.numLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numLength.Name = "numLength";
			this.numLength.Size = new System.Drawing.Size(93, 20);
			this.numLength.TabIndex = 9;
			this.numLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// numNum_Bars
			// 
			this.numNum_Bars.Location = new System.Drawing.Point(149, 199);
			this.numNum_Bars.Margin = new System.Windows.Forms.Padding(2);
			this.numNum_Bars.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numNum_Bars.Name = "numNum_Bars";
			this.numNum_Bars.Size = new System.Drawing.Size(93, 20);
			this.numNum_Bars.TabIndex = 8;
			this.numNum_Bars.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// rsLabel15
			// 
			this.rsLabel15.AutoEllipsis = true;
			this.rsLabel15.AutoSize = true;
			this.rsLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel15.Location = new System.Drawing.Point(247, 201);
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
			this.rsLabel14.Location = new System.Drawing.Point(30, 200);
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
			this.rsLabel13.Location = new System.Drawing.Point(30, 178);
			this.rsLabel13.Name = "rsLabel13";
			this.rsLabel13.Size = new System.Drawing.Size(101, 17);
			this.rsLabel13.TabIndex = 38;
			this.rsLabel13.Text = "Lô sản phẩm";
			this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboLot_ID
			// 
			this.cboLot_ID.DropDownHeight = 95;
			this.cboLot_ID.Enabled = false;
			this.cboLot_ID.FormattingEnabled = true;
			this.cboLot_ID.IntegralHeight = false;
			this.cboLot_ID.Location = new System.Drawing.Point(149, 154);
			this.cboLot_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboLot_ID.Name = "cboLot_ID";
			this.cboLot_ID.Size = new System.Drawing.Size(272, 21);
			this.cboLot_ID.TabIndex = 6;
			// 
			// rsLabel12
			// 
			this.rsLabel12.AutoEllipsis = true;
			this.rsLabel12.AutoSize = true;
			this.rsLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel12.Location = new System.Drawing.Point(30, 154);
			this.rsLabel12.Name = "rsLabel12";
			this.rsLabel12.Size = new System.Drawing.Size(62, 17);
			this.rsLabel12.TabIndex = 36;
			this.rsLabel12.Text = "Lô phôi";
			this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboMa_CL
			// 
			this.cboMa_CL.DropDownHeight = 95;
			this.cboMa_CL.Enabled = false;
			this.cboMa_CL.FormattingEnabled = true;
			this.cboMa_CL.IntegralHeight = false;
			this.cboMa_CL.Location = new System.Drawing.Point(149, 131);
			this.cboMa_CL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_CL.Name = "cboMa_CL";
			this.cboMa_CL.Size = new System.Drawing.Size(272, 21);
			this.cboMa_CL.TabIndex = 4;
			// 
			// rsLabel10
			// 
			this.rsLabel10.AutoEllipsis = true;
			this.rsLabel10.AutoSize = true;
			this.rsLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel10.Location = new System.Drawing.Point(30, 131);
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
			this.cboGrade_ID.Location = new System.Drawing.Point(149, 108);
			this.cboGrade_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboGrade_ID.Name = "cboGrade_ID";
			this.cboGrade_ID.Size = new System.Drawing.Size(272, 21);
			this.cboGrade_ID.TabIndex = 3;
			// 
			// rsLabel9
			// 
			this.rsLabel9.AutoEllipsis = true;
			this.rsLabel9.AutoSize = true;
			this.rsLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel9.Location = new System.Drawing.Point(30, 108);
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
			this.cboStandard_ID.Location = new System.Drawing.Point(149, 85);
			this.cboStandard_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboStandard_ID.Name = "cboStandard_ID";
			this.cboStandard_ID.Size = new System.Drawing.Size(272, 21);
			this.cboStandard_ID.TabIndex = 2;
			// 
			// rsLabel8
			// 
			this.rsLabel8.AutoEllipsis = true;
			this.rsLabel8.AutoSize = true;
			this.rsLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel8.Location = new System.Drawing.Point(30, 85);
			this.rsLabel8.Name = "rsLabel8";
			this.rsLabel8.Size = new System.Drawing.Size(89, 17);
			this.rsLabel8.TabIndex = 29;
			this.rsLabel8.Text = "Tiêu chuẩn";
			this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboMa_Vt
			// 
			this.cboMa_Vt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboMa_Vt.DropDownHeight = 95;
			this.cboMa_Vt.Enabled = false;
			this.cboMa_Vt.FormattingEnabled = true;
			this.cboMa_Vt.IntegralHeight = false;
			this.cboMa_Vt.Location = new System.Drawing.Point(149, 62);
			this.cboMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_Vt.Name = "cboMa_Vt";
			this.cboMa_Vt.Size = new System.Drawing.Size(272, 21);
			this.cboMa_Vt.TabIndex = 1;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel7.Location = new System.Drawing.Point(30, 62);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(84, 17);
			this.rsLabel7.TabIndex = 27;
			this.rsLabel7.Text = "Kích thước";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBarcode
			// 
			this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBarcode.Enabled = false;
			this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBarcode.Location = new System.Drawing.Point(149, 30);
			this.txtBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(154, 30);
			this.txtBarcode.TabIndex = 0;
			this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel1.Location = new System.Drawing.Point(30, 36);
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
			this.btSaveAndPrint.Location = new System.Drawing.Point(167, 282);
			this.btSaveAndPrint.Name = "btSaveAndPrint";
			this.btSaveAndPrint.Size = new System.Drawing.Size(86, 43);
			this.btSaveAndPrint.TabIndex = 13;
			this.btSaveAndPrint.Text = "Lưu && In";
			this.btSaveAndPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btSaveAndPrint.UseVisualStyleBackColor = true;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel2.Location = new System.Drawing.Point(31, 244);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(79, 17);
			this.rsLabel2.TabIndex = 46;
			this.rsLabel2.Text = "Lý do sửa";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLy_Do
			// 
			this.txtLy_Do.Location = new System.Drawing.Point(149, 243);
			this.txtLy_Do.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtLy_Do.Name = "txtLy_Do";
			this.txtLy_Do.Size = new System.Drawing.Size(272, 20);
			this.txtLy_Do.TabIndex = 12;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel3.Location = new System.Drawing.Point(30, 221);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(85, 17);
			this.rsLabel3.TabIndex = 47;
			this.rsLabel3.Text = "Khối lượng";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numSo_Luong
			// 
			this.numSo_Luong.Location = new System.Drawing.Point(149, 221);
			this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2);
			this.numSo_Luong.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numSo_Luong.Name = "numSo_Luong";
			this.numSo_Luong.Size = new System.Drawing.Size(93, 20);
			this.numSo_Luong.TabIndex = 10;
			this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// numSo_Luong_Barem
			// 
			this.numSo_Luong_Barem.Location = new System.Drawing.Point(328, 221);
			this.numSo_Luong_Barem.Margin = new System.Windows.Forms.Padding(2);
			this.numSo_Luong_Barem.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numSo_Luong_Barem.Name = "numSo_Luong_Barem";
			this.numSo_Luong_Barem.Size = new System.Drawing.Size(93, 20);
			this.numSo_Luong_Barem.TabIndex = 11;
			this.numSo_Luong_Barem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// rsLabel4
			// 
			this.rsLabel4.AutoEllipsis = true;
			this.rsLabel4.AutoSize = true;
			this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel4.Location = new System.Drawing.Point(247, 221);
			this.rsLabel4.Name = "rsLabel4";
			this.rsLabel4.Size = new System.Drawing.Size(78, 17);
			this.rsLabel4.TabIndex = 49;
			this.rsLabel4.Text = "KL Barem";
			this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmBarcode_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(451, 339);
			this.Controls.Add(this.numSo_Luong_Barem);
			this.Controls.Add(this.rsLabel4);
			this.Controls.Add(this.numSo_Luong);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.txtLy_Do);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.btSaveAndPrint);
			this.Controls.Add(this.txtBarcode);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.txtNum_Lot);
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
			this.Controls.Add(this.cboMa_Vt);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtNum_Lot;
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
		private RosySystem.Control.rsComboBox cboMa_Vt;
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
	}
}