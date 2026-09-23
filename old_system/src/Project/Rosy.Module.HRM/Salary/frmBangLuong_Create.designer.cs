namespace RosyModule.Salary
{
	partial class frmBangLuong_Create
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
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.enuBangLuong_Option = new RosySystem.Control.rsTextBoxEnum();
			this.lbtLoai_Tn = new RosySystem.Control.rsLabelName();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numThang1 = new RosySystem.Control.rsTextBoxNumber();
			this.numNam1 = new RosySystem.Control.rsTextBoxNumber();
			this.lblThang0 = new System.Windows.Forms.Label();
			this.lblNam = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(355, 83);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(179, 43);
			this.btgAccept.TabIndex = 5;
			// 
			// enuBangLuong_Option
			// 
			this.enuBangLuong_Option.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.enuBangLuong_Option.InputMask = "1,2";
			this.enuBangLuong_Option.Location = new System.Drawing.Point(164, 45);
			this.enuBangLuong_Option.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.enuBangLuong_Option.MaxLength = 20;
			this.enuBangLuong_Option.Name = "enuBangLuong_Option";
			this.enuBangLuong_Option.Size = new System.Drawing.Size(35, 20);
			this.enuBangLuong_Option.TabIndex = 2;
			this.enuBangLuong_Option.Text = "1";
			// 
			// lbtLoai_Tn
			// 
			this.lbtLoai_Tn.AutoSize = true;
			this.lbtLoai_Tn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtLoai_Tn.Location = new System.Drawing.Point(204, 48);
			this.lbtLoai_Tn.Name = "lbtLoai_Tn";
			this.lbtLoai_Tn.Size = new System.Drawing.Size(319, 13);
			this.lbtLoai_Tn.TabIndex = 3;
			this.lbtLoai_Tn.Tag = "";
			this.lbtLoai_Tn.Text = "1-Lấy số liệu tháng hiện hành, 2-Lấy từ tham số bảng lương chuẩn";
			this.lbtLoai_Tn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(26, 48);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(113, 13);
			this.rsLabel1.TabIndex = 66;
			this.rsLabel1.Tag = "Nguon_Tao_Bang_Luong";
			this.rsLabel1.Text = "Nguồn tạo bảng lương";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numThang1
			// 
			this.numThang1.bFormat = true;
			this.numThang1.Location = new System.Drawing.Point(164, 23);
			this.numThang1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numThang1.Name = "numThang1";
			this.numThang1.Scale = 0;
			this.numThang1.Size = new System.Drawing.Size(35, 20);
			this.numThang1.TabIndex = 0;
			this.numThang1.Text = "0";
			this.numThang1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numThang1.Value = 0D;
			// 
			// numNam1
			// 
			this.numNam1.bFormat = true;
			this.numNam1.Location = new System.Drawing.Point(238, 23);
			this.numNam1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numNam1.Name = "numNam1";
			this.numNam1.Scale = 0;
			this.numNam1.Size = new System.Drawing.Size(42, 20);
			this.numNam1.TabIndex = 1;
			this.numNam1.Text = "0";
			this.numNam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numNam1.Value = 0D;
			// 
			// lblThang0
			// 
			this.lblThang0.AutoSize = true;
			this.lblThang0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblThang0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblThang0.Location = new System.Drawing.Point(26, 26);
			this.lblThang0.Name = "lblThang0";
			this.lblThang0.Size = new System.Drawing.Size(133, 13);
			this.lblThang0.TabIndex = 68;
			this.lblThang0.Tag = "Tao_Bang_Luong_Cho_Thang";
			this.lblThang0.Text = "Tạo bảng lương cho tháng";
			// 
			// lblNam
			// 
			this.lblNam.AutoSize = true;
			this.lblNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNam.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNam.Location = new System.Drawing.Point(204, 26);
			this.lblNam.Name = "lblNam";
			this.lblNam.Size = new System.Drawing.Size(29, 13);
			this.lblNam.TabIndex = 68;
			this.lblNam.Tag = "Nam";
			this.lblNam.Text = "Năm";
			// 
			// frmBangLuong_Create
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(549, 134);
			this.Controls.Add(this.lblNam);
			this.Controls.Add(this.lblThang0);
			this.Controls.Add(this.numNam1);
			this.Controls.Add(this.numThang1);
			this.Controls.Add(this.enuBangLuong_Option);
			this.Controls.Add(this.lbtLoai_Tn);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.btgAccept);
			this.Name = "frmBangLuong_Create";
			this.Text = "frmBangLuong_Create";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBoxEnum enuBangLuong_Option;
		private RosySystem.Control.rsLabelName lbtLoai_Tn;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxNumber numThang1;
		private RosySystem.Control.rsTextBoxNumber numNam1;
		private System.Windows.Forms.Label lblThang0;
		private System.Windows.Forms.Label lblNam;
	}
}