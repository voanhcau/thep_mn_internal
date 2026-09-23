namespace RosyList
{
	partial class frmDmQDCan_Edit
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
			this.txtDuong_Kinh = new RosySystem.Control.rsTextBox();
			this.txtLoai_Thep = new RosySystem.Control.rsTextBox();
			this.lbTen_Kho = new RosySystem.Control.rsLabel();
			this.lbMa_Kho = new RosySystem.Control.rsLabel();
			this.numTieu_Hao_Gas = new RosySystem.Control.rsTextBoxNumber();
			this.lbStt = new RosySystem.Control.rsLabel();
			this.numTieu_Hao_Dien = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numTieu_Hao_Phoi = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(377, 193);
			this.btgAccept.Size = new System.Drawing.Size(179, 42);
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(547, 180);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.numTieu_Hao_Phoi);
			this.Page1.Controls.Add(this.rsLabel2);
			this.Page1.Controls.Add(this.numTieu_Hao_Dien);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Controls.Add(this.numTieu_Hao_Gas);
			this.Page1.Controls.Add(this.lbStt);
			this.Page1.Controls.Add(this.txtDuong_Kinh);
			this.Page1.Controls.Add(this.txtLoai_Thep);
			this.Page1.Controls.Add(this.lbTen_Kho);
			this.Page1.Controls.Add(this.lbMa_Kho);
			this.Page1.Size = new System.Drawing.Size(539, 154);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(539, 154);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 201);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 210);
			this.lblLog.Size = new System.Drawing.Size(285, 22);
			this.lblLog.Text = "";
			// 
			// txtDuong_Kinh
			// 
			this.txtDuong_Kinh.AutoDropDown = null;
			this.txtDuong_Kinh.Location = new System.Drawing.Point(115, 44);
			this.txtDuong_Kinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDuong_Kinh.MaxLength = 100;
			this.txtDuong_Kinh.Name = "txtDuong_Kinh";
			this.txtDuong_Kinh.Size = new System.Drawing.Size(120, 20);
			this.txtDuong_Kinh.TabIndex = 1;
			// 
			// txtLoai_Thep
			// 
			this.txtLoai_Thep.AutoDropDown = null;
			this.txtLoai_Thep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLoai_Thep.Location = new System.Drawing.Point(115, 22);
			this.txtLoai_Thep.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtLoai_Thep.MaxLength = 20;
			this.txtLoai_Thep.Name = "txtLoai_Thep";
			this.txtLoai_Thep.Size = new System.Drawing.Size(120, 20);
			this.txtLoai_Thep.TabIndex = 0;
			// 
			// lbTen_Kho
			// 
			this.lbTen_Kho.AutoEllipsis = true;
			this.lbTen_Kho.AutoSize = true;
			this.lbTen_Kho.Location = new System.Drawing.Point(8, 45);
			this.lbTen_Kho.Name = "lbTen_Kho";
			this.lbTen_Kho.Size = new System.Drawing.Size(62, 13);
			this.lbTen_Kho.TabIndex = 19;
			this.lbTen_Kho.Tag = "";
			this.lbTen_Kho.Text = "Đường kinh";
			this.lbTen_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Kho
			// 
			this.lbMa_Kho.AutoEllipsis = true;
			this.lbMa_Kho.AutoSize = true;
			this.lbMa_Kho.Location = new System.Drawing.Point(8, 22);
			this.lbMa_Kho.Name = "lbMa_Kho";
			this.lbMa_Kho.Size = new System.Drawing.Size(51, 13);
			this.lbMa_Kho.TabIndex = 20;
			this.lbMa_Kho.Tag = "";
			this.lbMa_Kho.Text = "Loại thép";
			this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTieu_Hao_Gas
			// 
			this.numTieu_Hao_Gas.AutoDropDown = null;
			this.numTieu_Hao_Gas.bFormat = true;
			this.numTieu_Hao_Gas.Location = new System.Drawing.Point(115, 66);
			this.numTieu_Hao_Gas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTieu_Hao_Gas.Name = "numTieu_Hao_Gas";
			this.numTieu_Hao_Gas.Scale = 2;
			this.numTieu_Hao_Gas.Size = new System.Drawing.Size(60, 20);
			this.numTieu_Hao_Gas.TabIndex = 2;
			this.numTieu_Hao_Gas.Text = "0.00";
			this.numTieu_Hao_Gas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTieu_Hao_Gas.Value = 0D;
			// 
			// lbStt
			// 
			this.lbStt.AutoEllipsis = true;
			this.lbStt.AutoSize = true;
			this.lbStt.Location = new System.Drawing.Point(8, 69);
			this.lbStt.Name = "lbStt";
			this.lbStt.Size = new System.Drawing.Size(71, 13);
			this.lbStt.TabIndex = 21;
			this.lbStt.Text = "Tiêu hao Gas";
			this.lbStt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTieu_Hao_Dien
			// 
			this.numTieu_Hao_Dien.AutoDropDown = null;
			this.numTieu_Hao_Dien.bFormat = true;
			this.numTieu_Hao_Dien.Location = new System.Drawing.Point(115, 88);
			this.numTieu_Hao_Dien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTieu_Hao_Dien.Name = "numTieu_Hao_Dien";
			this.numTieu_Hao_Dien.Scale = 0;
			this.numTieu_Hao_Dien.Size = new System.Drawing.Size(60, 20);
			this.numTieu_Hao_Dien.TabIndex = 5;
			this.numTieu_Hao_Dien.Text = "0";
			this.numTieu_Hao_Dien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTieu_Hao_Dien.Value = 0D;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(8, 91);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(74, 13);
			this.rsLabel1.TabIndex = 98;
			this.rsLabel1.Text = "Tiêu hao Điện";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTieu_Hao_Phoi
			// 
			this.numTieu_Hao_Phoi.AutoDropDown = null;
			this.numTieu_Hao_Phoi.bFormat = true;
			this.numTieu_Hao_Phoi.Location = new System.Drawing.Point(115, 110);
			this.numTieu_Hao_Phoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTieu_Hao_Phoi.Name = "numTieu_Hao_Phoi";
			this.numTieu_Hao_Phoi.Scale = 0;
			this.numTieu_Hao_Phoi.Size = new System.Drawing.Size(60, 20);
			this.numTieu_Hao_Phoi.TabIndex = 6;
			this.numTieu_Hao_Phoi.Text = "0";
			this.numTieu_Hao_Phoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTieu_Hao_Phoi.Value = 0D;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(8, 113);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(73, 13);
			this.rsLabel2.TabIndex = 100;
			this.rsLabel2.Text = "Tiêu hao Phôi";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmQDCan_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(571, 242);
			this.Name = "frmDmQDCan_Edit";
			this.Object_ID = "DMQDCAN";
			this.Tag = "frmDmKho, ESC";
			this.Text = "frmDmQDCan";
			this.tabEdit.ResumeLayout(false);
			this.Page1.ResumeLayout(false);
			this.Page1.PerformLayout();
			this.Page2.ResumeLayout(false);
			this.Page2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtDuong_Kinh;
		private RosySystem.Control.rsTextBox txtLoai_Thep;
		private RosySystem.Control.rsLabel lbTen_Kho;
		private RosySystem.Control.rsLabel lbMa_Kho;
		private RosySystem.Control.rsTextBoxNumber numTieu_Hao_Gas;
		private RosySystem.Control.rsLabel lbStt;
		private RosySystem.Control.rsTextBoxNumber numTieu_Hao_Phoi;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBoxNumber numTieu_Hao_Dien;
		private RosySystem.Control.rsLabel rsLabel1;

	}
}