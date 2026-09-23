namespace RosyModule.Salary
{
	partial class frmBangLuong
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangLuong));
			this.btCalcSalary = new RosySystem.Control.rsButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.btCreateSalary = new RosySystem.Control.rsButton();
			this.cboMa_Bp = new RosySystem.Control.rsMultiComboBox();
			this.lblTk = new RosySystem.Control.rsLabel();
			this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
			this.btPostedSalary = new RosySystem.Control.rsButton();
			this.btDeleteSalary = new RosySystem.Control.rsButton();
			this.cboThang = new RosySystem.Control.rsComboBox();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btCalcSalary
			// 
			this.btCalcSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btCalcSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCalcSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btCalcSalary.ImageKey = "calc";
			this.btCalcSalary.ImageList = this.imageList1;
			this.btCalcSalary.Location = new System.Drawing.Point(106, 513);
			this.btCalcSalary.Name = "btCalcSalary";
			this.btCalcSalary.Size = new System.Drawing.Size(97, 47);
			this.btCalcSalary.TabIndex = 4;
			this.btCalcSalary.Tag = "Tinh_Luong";
			this.btCalcSalary.Text = "Tính &lương";
			this.btCalcSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btCalcSalary.UseVisualStyleBackColor = true;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "posted");
			this.imageList1.Images.SetKeyName(1, "delete");
			this.imageList1.Images.SetKeyName(2, "calc");
			this.imageList1.Images.SetKeyName(3, "add");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 4;
			this.label1.Tag = "Thang";
			this.label1.Text = "Tháng";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Location = new System.Drawing.Point(3, 54);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(787, 453);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.radioButton3);
			this.panel2.Controls.Add(this.radioButton2);
			this.panel2.Controls.Add(this.radioButton1);
			this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel2.Location = new System.Drawing.Point(256, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(534, 24);
			this.panel2.TabIndex = 7;
			this.panel2.TabStop = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(384, 4);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(140, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Tag = "Thanh_Toan_Luong";
			this.radioButton3.Text = "&3. Thanh toán lương";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(212, 4);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(166, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Tag = "Giam_Luong";
			this.radioButton2.Text = "&2. Các khoản giảm lương";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(3, 4);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(207, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Tag = "Luong_Phu_Cap";
			this.radioButton1.Text = "&1. Lương và các khoản phụ cấp";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// btCreateSalary
			// 
			this.btCreateSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btCreateSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCreateSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btCreateSalary.ImageKey = "add";
			this.btCreateSalary.ImageList = this.imageList1;
			this.btCreateSalary.Location = new System.Drawing.Point(3, 513);
			this.btCreateSalary.Name = "btCreateSalary";
			this.btCreateSalary.Size = new System.Drawing.Size(97, 47);
			this.btCreateSalary.TabIndex = 3;
			this.btCreateSalary.Tag = "Tao_Bang_Luong";
			this.btCreateSalary.Text = "&Tạo bảng lương";
			this.btCreateSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btCreateSalary.UseVisualStyleBackColor = true;
			// 
			// cboMa_Bp
			// 
			this.cboMa_Bp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboMa_Bp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cboMa_Bp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cboMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboMa_Bp.Location = new System.Drawing.Point(80, 28);
			this.cboMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_Bp.MaxLength = 20;
			this.cboMa_Bp.Name = "cboMa_Bp";
			this.cboMa_Bp.Size = new System.Drawing.Size(116, 21);
			this.cboMa_Bp.TabIndex = 1;
			// 
			// lblTk
			// 
			this.lblTk.AutoEllipsis = true;
			this.lblTk.AutoSize = true;
			this.lblTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTk.Location = new System.Drawing.Point(10, 31);
			this.lblTk.Name = "lblTk";
			this.lblTk.Size = new System.Drawing.Size(54, 13);
			this.lblTk.TabIndex = 65;
			this.lblTk.Tag = "Ma_Bp";
			this.lblTk.Text = "Bộ phận";
			this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbtTen_Bp
			// 
			this.lbtTen_Bp.AutoSize = true;
			this.lbtTen_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbtTen_Bp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtTen_Bp.Location = new System.Drawing.Point(201, 33);
			this.lbtTen_Bp.Name = "lbtTen_Bp";
			this.lbtTen_Bp.Size = new System.Drawing.Size(80, 13);
			this.lbtTen_Bp.TabIndex = 65;
			this.lbtTen_Bp.Tag = "";
			this.lbtTen_Bp.Text = "Tên Bộ phận";
			this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btPostedSalary
			// 
			this.btPostedSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btPostedSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btPostedSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btPostedSalary.ImageKey = "posted";
			this.btPostedSalary.ImageList = this.imageList1;
			this.btPostedSalary.Location = new System.Drawing.Point(312, 513);
			this.btPostedSalary.Name = "btPostedSalary";
			this.btPostedSalary.Size = new System.Drawing.Size(97, 47);
			this.btPostedSalary.TabIndex = 4;
			this.btPostedSalary.Tag = "Hach_Toan_Luong";
			this.btPostedSalary.Text = "&Hạch toán lương";
			this.btPostedSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btPostedSalary.UseVisualStyleBackColor = true;
			// 
			// btDeleteSalary
			// 
			this.btDeleteSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDeleteSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btDeleteSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDeleteSalary.ImageKey = "delete";
			this.btDeleteSalary.ImageList = this.imageList1;
			this.btDeleteSalary.Location = new System.Drawing.Point(209, 513);
			this.btDeleteSalary.Name = "btDeleteSalary";
			this.btDeleteSalary.Size = new System.Drawing.Size(97, 47);
			this.btDeleteSalary.TabIndex = 4;
			this.btDeleteSalary.Tag = "Xoa_Bang_Luong";
			this.btDeleteSalary.Text = "&Xóa bảng lương";
			this.btDeleteSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btDeleteSalary.UseVisualStyleBackColor = true;
			// 
			// cboThang
			// 
			this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboThang.FormattingEnabled = true;
			this.cboThang.Location = new System.Drawing.Point(80, 5);
			this.cboThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboThang.Name = "cboThang";
			this.cboThang.Size = new System.Drawing.Size(51, 21);
			this.cboThang.TabIndex = 66;
			// 
			// frmBangLuong
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.cboThang);
			this.Controls.Add(this.cboMa_Bp);
			this.Controls.Add(this.lbtTen_Bp);
			this.Controls.Add(this.lblTk);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btCreateSalary);
			this.Controls.Add(this.btDeleteSalary);
			this.Controls.Add(this.btPostedSalary);
			this.Controls.Add(this.btCalcSalary);
			this.Name = "frmBangLuong";
			this.Text = "frmBangLuong";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsButton btCalcSalary;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private RosySystem.Control.rsButton btCreateSalary;
		private RosySystem.Control.rsMultiComboBox cboMa_Bp;
		private RosySystem.Control.rsLabel lblTk;
		private RosySystem.Control.rsLabelName lbtTen_Bp;
		private RosySystem.Control.rsButton btPostedSalary;
		private RosySystem.Control.rsButton btDeleteSalary;
		private RosySystem.Control.rsComboBox cboThang;
		private System.Windows.Forms.ImageList imageList1;
	}
}