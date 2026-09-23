namespace RosyModule.Inventory
{
	partial class frmGiaVon
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
            this.btOk = new RosySystem.Control.rsButton();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.label1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Vt = new RosySystem.Control.rsLabelName();
            this.txtMa_Kho = new RosySystem.Control.rsTextBox();
            this.lblMa_Kho = new RosySystem.Control.rsLabel();
            this.lbtTen_Kho = new RosySystem.Control.rsLabelName();
            this.btCancel = new RosySystem.Control.rsButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbGiaNTXT = new System.Windows.Forms.RadioButton();
            this.rdbGiaBQTT = new System.Windows.Forms.RadioButton();
            this.rdbGiaBQTH = new System.Windows.Forms.RadioButton();
            this.txtNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.txtNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.txtMa_Kho_List = new RosySystem.Control.rsTextBox();
            this.btMa_Kho = new RosySystem.Control.rsButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(277, 268);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 23);
            this.btOk.TabIndex = 5;
            this.btOk.Tag = "Ok";
            this.btOk.Text = "&Thực hiện";
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.Location = new System.Drawing.Point(122, 75);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(100, 20);
            this.txtMa_Vt.TabIndex = 2;
            this.txtMa_Vt.Tag = "Ma_Vt";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Tag = "Ma_Vt";
            this.label1.Text = "Mã vật tư";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Vt.Location = new System.Drawing.Point(227, 78);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(38, 13);
            this.lbtTen_Vt.TabIndex = 2;
            this.lbtTen_Vt.Tag = "Ten_Vt";
            this.lbtTen_Vt.Text = "Tên vt";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Kho
            // 
            this.txtMa_Kho.AutoDropDown = null;
            this.txtMa_Kho.Location = new System.Drawing.Point(122, 97);
            this.txtMa_Kho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho.Name = "txtMa_Kho";
            this.txtMa_Kho.Size = new System.Drawing.Size(100, 20);
            this.txtMa_Kho.TabIndex = 3;
            this.txtMa_Kho.Tag = "Ma_Kho";
            this.txtMa_Kho.Visible = false;
            // 
            // lblMa_Kho
            // 
            this.lblMa_Kho.AutoEllipsis = true;
            this.lblMa_Kho.AutoSize = true;
            this.lblMa_Kho.Location = new System.Drawing.Point(37, 100);
            this.lblMa_Kho.Name = "lblMa_Kho";
            this.lblMa_Kho.Size = new System.Drawing.Size(43, 13);
            this.lblMa_Kho.TabIndex = 2;
            this.lblMa_Kho.Tag = "Ma_Kho";
            this.lblMa_Kho.Text = "Mã kho";
            this.lblMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMa_Kho.Visible = false;
            // 
            // lbtTen_Kho
            // 
            this.lbtTen_Kho.AutoSize = true;
            this.lbtTen_Kho.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Kho.Location = new System.Drawing.Point(227, 100);
            this.lbtTen_Kho.Name = "lbtTen_Kho";
            this.lbtTen_Kho.Size = new System.Drawing.Size(48, 13);
            this.lbtTen_Kho.TabIndex = 2;
            this.lbtTen_Kho.Tag = "Ten_Kho";
            this.lbtTen_Kho.Text = "Tên Kho";
            this.lbtTen_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbtTen_Kho.Visible = false;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(370, 268);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 23);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbGiaNTXT);
            this.groupBox1.Controls.Add(this.rdbGiaBQTT);
            this.groupBox1.Controls.Add(this.rdbGiaBQTH);
            this.groupBox1.Location = new System.Drawing.Point(122, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "Method";
            this.groupBox1.Text = "Phương pháp tính";
            // 
            // rdbGiaNTXT
            // 
            this.rdbGiaNTXT.AutoSize = true;
            this.rdbGiaNTXT.Enabled = false;
            this.rdbGiaNTXT.Location = new System.Drawing.Point(27, 65);
            this.rdbGiaNTXT.Name = "rdbGiaNTXT";
            this.rdbGiaNTXT.Size = new System.Drawing.Size(140, 17);
            this.rdbGiaNTXT.TabIndex = 2;
            this.rdbGiaNTXT.TabStop = true;
            this.rdbGiaNTXT.Tag = "LIFO";
            this.rdbGiaNTXT.Text = "3. Nhập trước xuất trước";
            this.rdbGiaNTXT.UseVisualStyleBackColor = true;
            // 
            // rdbGiaBQTT
            // 
            this.rdbGiaBQTT.AutoSize = true;
            this.rdbGiaBQTT.Enabled = false;
            this.rdbGiaBQTT.Location = new System.Drawing.Point(27, 42);
            this.rdbGiaBQTT.Name = "rdbGiaBQTT";
            this.rdbGiaBQTT.Size = new System.Drawing.Size(123, 17);
            this.rdbGiaBQTT.TabIndex = 1;
            this.rdbGiaBQTT.TabStop = true;
            this.rdbGiaBQTT.Tag = "BQTUCTHOI";
            this.rdbGiaBQTT.Text = "2. Bình quân tức thời";
            this.rdbGiaBQTT.UseVisualStyleBackColor = true;
            // 
            // rdbGiaBQTH
            // 
            this.rdbGiaBQTH.AutoSize = true;
            this.rdbGiaBQTH.Enabled = false;
            this.rdbGiaBQTH.Location = new System.Drawing.Point(27, 19);
            this.rdbGiaBQTH.Name = "rdbGiaBQTH";
            this.rdbGiaBQTH.Size = new System.Drawing.Size(115, 17);
            this.rdbGiaBQTH.TabIndex = 0;
            this.rdbGiaBQTH.TabStop = true;
            this.rdbGiaBQTH.Tag = "BQTHANG";
            this.rdbGiaBQTH.Text = "1. Bình quân tháng";
            this.rdbGiaBQTH.UseVisualStyleBackColor = true;
            // 
            // txtNgay_Ct2
            // 
            this.txtNgay_Ct2.bAllowEmpty = true;
            this.txtNgay_Ct2.bSelectOnFocus = true;
            this.txtNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct2.Location = new System.Drawing.Point(122, 53);
            this.txtNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct2.Mask = "00/00/0000";
            this.txtNgay_Ct2.Name = "txtNgay_Ct2";
            this.txtNgay_Ct2.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct2.TabIndex = 1;
            this.txtNgay_Ct2.Tag = "Ngay_Ct2";
            // 
            // txtNgay_Ct1
            // 
            this.txtNgay_Ct1.bAllowEmpty = true;
            this.txtNgay_Ct1.bSelectOnFocus = true;
            this.txtNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct1.Location = new System.Drawing.Point(122, 31);
            this.txtNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct1.Mask = "00/00/0000";
            this.txtNgay_Ct1.Name = "txtNgay_Ct1";
            this.txtNgay_Ct1.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct1.TabIndex = 0;
            this.txtNgay_Ct1.Tag = "Ngay_Ct1";
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(37, 34);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(46, 13);
            this.rsLabel1.TabIndex = 2;
            this.rsLabel1.Tag = "Ngay_Ct1";
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(37, 56);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(53, 13);
            this.rsLabel2.TabIndex = 2;
            this.rsLabel2.Tag = "Den_Ngay";
            this.rsLabel2.Text = "Đến ngày";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(37, 122);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(58, 13);
            this.rsLabel3.TabIndex = 7;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Mã kho list";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Kho_List
            // 
            this.txtMa_Kho_List.AutoDropDown = null;
            this.txtMa_Kho_List.Location = new System.Drawing.Point(122, 119);
            this.txtMa_Kho_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho_List.Multiline = true;
            this.txtMa_Kho_List.Name = "txtMa_Kho_List";
            this.txtMa_Kho_List.Size = new System.Drawing.Size(335, 47);
            this.txtMa_Kho_List.TabIndex = 8;
            this.txtMa_Kho_List.Tag = "Ma_Kho";
            // 
            // btMa_Kho
            // 
            this.btMa_Kho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btMa_Kho.Location = new System.Drawing.Point(460, 118);
            this.btMa_Kho.Margin = new System.Windows.Forms.Padding(0);
            this.btMa_Kho.Name = "btMa_Kho";
            this.btMa_Kho.Size = new System.Drawing.Size(23, 22);
            this.btMa_Kho.TabIndex = 54;
            this.btMa_Kho.TabStop = false;
            this.btMa_Kho.Text = "...";
            this.btMa_Kho.UseVisualStyleBackColor = true;
            // 
            // frmGiaVon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(502, 303);
            this.Controls.Add(this.btMa_Kho);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtMa_Kho_List);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbtTen_Kho);
            this.Controls.Add(this.lblMa_Kho);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.txtMa_Kho);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNgay_Ct1);
            this.Controls.Add(this.txtNgay_Ct2);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmGiaVon";
            this.Text = "frmGiaVon";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsButton btOk;
		private RosySystem.Control.rsTextBox txtMa_Vt;
		private RosySystem.Control.rsLabel label1;
		private RosySystem.Control.rsLabelName lbtTen_Vt;
		private RosySystem.Control.rsTextBox txtMa_Kho;
		private RosySystem.Control.rsLabel lblMa_Kho;
		private RosySystem.Control.rsLabelName lbtTen_Kho;
		private RosySystem.Control.rsButton btCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbGiaBQTT;
		private System.Windows.Forms.RadioButton rdbGiaBQTH;
		private System.Windows.Forms.RadioButton rdbGiaNTXT;
		private RosySystem.Control.rsDateTime txtNgay_Ct2;
		private RosySystem.Control.rsDateTime txtNgay_Ct1;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBox txtMa_Kho_List;
		private RosySystem.Control.rsButton btMa_Kho;
	}
}