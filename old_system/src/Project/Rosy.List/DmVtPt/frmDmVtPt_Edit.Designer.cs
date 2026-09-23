namespace RosyList
{
    partial class frmDmVtPt_Edit
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
            this.numSl_Ton_Min = new RosySystem.Control.rsTextBoxNumber();
            this.numSl_Ton_Max = new RosySystem.Control.rsTextBoxNumber();
            this.lblSl_Ton_Max = new RosySystem.Control.rsLabel();
            this.lblSl_Ton_Min = new RosySystem.Control.rsLabel();
            this.txtDvt = new RosySystem.Control.rsTextBox();
            this.lbDvt = new RosySystem.Control.rsLabel();
            this.txtTen_Vt = new RosySystem.Control.rsTextBox();
            this.txtMa_Vt = new RosySystem.Control.rsTextBox();
            this.txtMa_Nh_Vt = new RosySystem.Control.rsTextBox();
            this.lbtTen_Nh_Vt = new RosySystem.Control.rsLabel();
            this.lbMa_Nh_Vt = new RosySystem.Control.rsLabel();
            this.lbTen_Vt = new RosySystem.Control.rsLabel();
            this.lbMa_Vt = new RosySystem.Control.rsLabel();
            this.txtMa_Vt_Ap = new RosySystem.Control.rsTextBox();
            this.txtThong_So_Kt = new RosySystem.Control.rsTextBox();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.Page3 = new System.Windows.Forms.TabPage();
            this.txtTen_Vt_Chuan = new RosySystem.Control.rsTextBox();
            this.rsLabel21 = new RosySystem.Control.rsLabel();
            this.txtMa_Tb_Nhom = new RosySystem.Control.rsTextBox();
            this.rsLabel20 = new RosySystem.Control.rsLabel();
            this.txtTen_Nha_Sx = new RosySystem.Control.rsTextBox();
            this.rsLabel19 = new RosySystem.Control.rsLabel();
            this.lbtTen_Tb = new RosySystem.Control.rsLabel();
            this.lbtTen_Nhom = new RosySystem.Control.rsLabel();
            this.txtMa_Tb_Nha_Sx = new RosySystem.Control.rsTextBox();
            this.rsLabel23 = new RosySystem.Control.rsLabel();
            this.txtMa_Nhom = new RosySystem.Control.rsTextBox();
            this.rsLabel15 = new RosySystem.Control.rsLabel();
            this.chkIs_Hide = new RosySystem.Control.rsCheckbox();
            this.chkIs_TieuHao = new RosySystem.Control.rsCheckbox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.lblTen_Vt_Ap = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtLy_Do = new RosySystem.Control.rsTextBox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Page3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(574, 455);
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.Page3);
            this.tabEdit.Size = new System.Drawing.Size(747, 439);
            this.tabEdit.TabIndex = 0;
            this.tabEdit.Controls.SetChildIndex(this.Page2, 0);
            this.tabEdit.Controls.SetChildIndex(this.Page3, 0);
            this.tabEdit.Controls.SetChildIndex(this.Page1, 0);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chkIs_TieuHao);
            this.Page1.Controls.Add(this.chkIs_Hide);
            this.Page1.Controls.Add(this.txtLy_Do);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.txtThong_So_Kt);
            this.Page1.Controls.Add(this.rsLabel10);
            this.Page1.Controls.Add(this.txtMa_Vt_Ap);
            this.Page1.Controls.Add(this.lblTen_Vt_Ap);
            this.Page1.Controls.Add(this.rsLabel3);
            this.Page1.Controls.Add(this.numSl_Ton_Min);
            this.Page1.Controls.Add(this.numSl_Ton_Max);
            this.Page1.Controls.Add(this.lblSl_Ton_Max);
            this.Page1.Controls.Add(this.lblSl_Ton_Min);
            this.Page1.Controls.Add(this.txtDvt);
            this.Page1.Controls.Add(this.lbDvt);
            this.Page1.Controls.Add(this.txtTen_Vt);
            this.Page1.Controls.Add(this.txtMa_Vt);
            this.Page1.Controls.Add(this.txtMa_Nh_Vt);
            this.Page1.Controls.Add(this.lbtTen_Nh_Vt);
            this.Page1.Controls.Add(this.lbMa_Nh_Vt);
            this.Page1.Controls.Add(this.lbTen_Vt);
            this.Page1.Controls.Add(this.lbMa_Vt);
            this.Page1.Size = new System.Drawing.Size(739, 413);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(739, 413);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 464);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(50, 474);
            this.lblLog.Size = new System.Drawing.Size(334, 22);
            this.lblLog.Text = "";
            // 
            // numSl_Ton_Min
            // 
            this.numSl_Ton_Min.AutoDropDown = null;
            this.numSl_Ton_Min.bFormat = true;
            this.numSl_Ton_Min.Location = new System.Drawing.Point(126, 280);
            this.numSl_Ton_Min.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSl_Ton_Min.Name = "numSl_Ton_Min";
            this.numSl_Ton_Min.Scale = 4;
            this.numSl_Ton_Min.Size = new System.Drawing.Size(120, 20);
            this.numSl_Ton_Min.TabIndex = 5;
            this.numSl_Ton_Min.Text = "0.0000";
            this.numSl_Ton_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSl_Ton_Min.Value = 0D;
            // 
            // numSl_Ton_Max
            // 
            this.numSl_Ton_Max.AutoDropDown = null;
            this.numSl_Ton_Max.bFormat = true;
            this.numSl_Ton_Max.Location = new System.Drawing.Point(427, 280);
            this.numSl_Ton_Max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSl_Ton_Max.Name = "numSl_Ton_Max";
            this.numSl_Ton_Max.Scale = 4;
            this.numSl_Ton_Max.Size = new System.Drawing.Size(118, 20);
            this.numSl_Ton_Max.TabIndex = 6;
            this.numSl_Ton_Max.Text = "0.0000";
            this.numSl_Ton_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSl_Ton_Max.Value = 0D;
            // 
            // lblSl_Ton_Max
            // 
            this.lblSl_Ton_Max.AutoEllipsis = true;
            this.lblSl_Ton_Max.AutoSize = true;
            this.lblSl_Ton_Max.Location = new System.Drawing.Point(324, 283);
            this.lblSl_Ton_Max.Name = "lblSl_Ton_Max";
            this.lblSl_Ton_Max.Size = new System.Drawing.Size(72, 13);
            this.lblSl_Ton_Max.TabIndex = 106;
            this.lblSl_Ton_Max.Tag = "Sl_Ton_Max";
            this.lblSl_Ton_Max.Text = "SL Tồn tối đa";
            this.lblSl_Ton_Max.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSl_Ton_Min
            // 
            this.lblSl_Ton_Min.AutoEllipsis = true;
            this.lblSl_Ton_Min.AutoSize = true;
            this.lblSl_Ton_Min.Location = new System.Drawing.Point(12, 280);
            this.lblSl_Ton_Min.Name = "lblSl_Ton_Min";
            this.lblSl_Ton_Min.Size = new System.Drawing.Size(107, 13);
            this.lblSl_Ton_Min.TabIndex = 105;
            this.lblSl_Ton_Min.Tag = "Sl_Ton_Min";
            this.lblSl_Ton_Min.Text = "Số lượng tồn tối thiểu";
            this.lblSl_Ton_Min.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDvt
            // 
            this.txtDvt.AutoDropDown = null;
            this.txtDvt.Location = new System.Drawing.Point(126, 236);
            this.txtDvt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDvt.MaxLength = 20;
            this.txtDvt.Name = "txtDvt";
            this.txtDvt.Size = new System.Drawing.Size(120, 20);
            this.txtDvt.TabIndex = 3;
            // 
            // lbDvt
            // 
            this.lbDvt.AutoEllipsis = true;
            this.lbDvt.AutoSize = true;
            this.lbDvt.Location = new System.Drawing.Point(12, 236);
            this.lbDvt.Name = "lbDvt";
            this.lbDvt.Size = new System.Drawing.Size(60, 13);
            this.lbDvt.TabIndex = 96;
            this.lbDvt.Tag = "Dvt";
            this.lbDvt.Text = "Đơn vị tính";
            this.lbDvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Vt
            // 
            this.txtTen_Vt.AutoDropDown = null;
            this.txtTen_Vt.Location = new System.Drawing.Point(126, 43);
            this.txtTen_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Vt.MaxLength = 500;
            this.txtTen_Vt.Multiline = true;
            this.txtTen_Vt.Name = "txtTen_Vt";
            this.txtTen_Vt.Size = new System.Drawing.Size(451, 95);
            this.txtTen_Vt.TabIndex = 1;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.AutoDropDown = null;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.Location = new System.Drawing.Point(126, 20);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 0;
            // 
            // txtMa_Nh_Vt
            // 
            this.txtMa_Nh_Vt.AutoDropDown = null;
            this.txtMa_Nh_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_Vt.ForeColor = System.Drawing.Color.Red;
            this.txtMa_Nh_Vt.Location = new System.Drawing.Point(126, 258);
            this.txtMa_Nh_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Vt.Name = "txtMa_Nh_Vt";
            this.txtMa_Nh_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_Vt.TabIndex = 4;
            // 
            // lbtTen_Nh_Vt
            // 
            this.lbtTen_Nh_Vt.AutoEllipsis = true;
            this.lbtTen_Nh_Vt.AutoSize = true;
            this.lbtTen_Nh_Vt.ForeColor = System.Drawing.Color.Red;
            this.lbtTen_Nh_Vt.Location = new System.Drawing.Point(251, 261);
            this.lbtTen_Nh_Vt.Name = "lbtTen_Nh_Vt";
            this.lbtTen_Nh_Vt.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_Nh_Vt.TabIndex = 95;
            this.lbtTen_Nh_Vt.Text = "Tên nhóm ";
            this.lbtTen_Nh_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Nh_Vt
            // 
            this.lbMa_Nh_Vt.AutoEllipsis = true;
            this.lbMa_Nh_Vt.AutoSize = true;
            this.lbMa_Nh_Vt.ForeColor = System.Drawing.Color.Red;
            this.lbMa_Nh_Vt.Location = new System.Drawing.Point(12, 258);
            this.lbMa_Nh_Vt.Name = "lbMa_Nh_Vt";
            this.lbMa_Nh_Vt.Size = new System.Drawing.Size(65, 13);
            this.lbMa_Nh_Vt.TabIndex = 86;
            this.lbMa_Nh_Vt.Tag = "Ma_Nh_Vt";
            this.lbMa_Nh_Vt.Text = "Nhóm vật tư";
            this.lbMa_Nh_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTen_Vt
            // 
            this.lbTen_Vt.AutoEllipsis = true;
            this.lbTen_Vt.AutoSize = true;
            this.lbTen_Vt.Location = new System.Drawing.Point(12, 43);
            this.lbTen_Vt.Name = "lbTen_Vt";
            this.lbTen_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbTen_Vt.TabIndex = 92;
            this.lbTen_Vt.Tag = "Ten_Vt";
            this.lbTen_Vt.Text = "Tên vật tư";
            this.lbTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(12, 20);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(52, 13);
            this.lbMa_Vt.TabIndex = 90;
            this.lbMa_Vt.Tag = "Ma_Vt";
            this.lbMa_Vt.Text = "Mã vật tư";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt_Ap
            // 
            this.txtMa_Vt_Ap.AutoDropDown = null;
            this.txtMa_Vt_Ap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt_Ap.Location = new System.Drawing.Point(126, 302);
            this.txtMa_Vt_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt_Ap.MaxLength = 20;
            this.txtMa_Vt_Ap.Name = "txtMa_Vt_Ap";
            this.txtMa_Vt_Ap.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt_Ap.TabIndex = 7;
            this.txtMa_Vt_Ap.TabStop = false;
            // 
            // txtThong_So_Kt
            // 
            this.txtThong_So_Kt.AutoDropDown = null;
            this.txtThong_So_Kt.Location = new System.Drawing.Point(126, 140);
            this.txtThong_So_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtThong_So_Kt.MaxLength = 500;
            this.txtThong_So_Kt.Multiline = true;
            this.txtThong_So_Kt.Name = "txtThong_So_Kt";
            this.txtThong_So_Kt.Size = new System.Drawing.Size(451, 94);
            this.txtThong_So_Kt.TabIndex = 2;
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Location = new System.Drawing.Point(12, 141);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(93, 13);
            this.rsLabel10.TabIndex = 130;
            this.rsLabel10.Text = "Thông số kỹ thuật";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Page3
            // 
            this.Page3.Controls.Add(this.txtTen_Vt_Chuan);
            this.Page3.Controls.Add(this.rsLabel21);
            this.Page3.Controls.Add(this.txtMa_Tb_Nhom);
            this.Page3.Controls.Add(this.rsLabel20);
            this.Page3.Controls.Add(this.txtTen_Nha_Sx);
            this.Page3.Controls.Add(this.rsLabel19);
            this.Page3.Controls.Add(this.lbtTen_Tb);
            this.Page3.Controls.Add(this.lbtTen_Nhom);
            this.Page3.Controls.Add(this.txtMa_Tb_Nha_Sx);
            this.Page3.Controls.Add(this.rsLabel23);
            this.Page3.Controls.Add(this.txtMa_Nhom);
            this.Page3.Controls.Add(this.rsLabel15);
            this.Page3.Location = new System.Drawing.Point(4, 22);
            this.Page3.Name = "Page3";
            this.Page3.Size = new System.Drawing.Size(739, 413);
            this.Page3.TabIndex = 6;
            this.Page3.Text = "Thông tin vật tư phụ tùng";
            this.Page3.UseVisualStyleBackColor = true;
            // 
            // txtTen_Vt_Chuan
            // 
            this.txtTen_Vt_Chuan.AutoDropDown = null;
            this.txtTen_Vt_Chuan.Enabled = false;
            this.txtTen_Vt_Chuan.Location = new System.Drawing.Point(132, 61);
            this.txtTen_Vt_Chuan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Vt_Chuan.MaxLength = 200;
            this.txtTen_Vt_Chuan.Name = "txtTen_Vt_Chuan";
            this.txtTen_Vt_Chuan.Size = new System.Drawing.Size(451, 20);
            this.txtTen_Vt_Chuan.TabIndex = 159;
            // 
            // rsLabel21
            // 
            this.rsLabel21.AutoEllipsis = true;
            this.rsLabel21.AutoSize = true;
            this.rsLabel21.Location = new System.Drawing.Point(12, 61);
            this.rsLabel21.Name = "rsLabel21";
            this.rsLabel21.Size = new System.Drawing.Size(79, 13);
            this.rsLabel21.TabIndex = 160;
            this.rsLabel21.Tag = "Ten_Vt_Chuan";
            this.rsLabel21.Text = "Ten_Vt_Chuan";
            this.rsLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Tb_Nhom
            // 
            this.txtMa_Tb_Nhom.AutoDropDown = null;
            this.txtMa_Tb_Nhom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tb_Nhom.Enabled = false;
            this.txtMa_Tb_Nhom.Location = new System.Drawing.Point(132, 35);
            this.txtMa_Tb_Nhom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb_Nhom.MaxLength = 20;
            this.txtMa_Tb_Nhom.Name = "txtMa_Tb_Nhom";
            this.txtMa_Tb_Nhom.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Tb_Nhom.TabIndex = 157;
            // 
            // rsLabel20
            // 
            this.rsLabel20.AutoEllipsis = true;
            this.rsLabel20.AutoSize = true;
            this.rsLabel20.Location = new System.Drawing.Point(14, 37);
            this.rsLabel20.Name = "rsLabel20";
            this.rsLabel20.Size = new System.Drawing.Size(118, 13);
            this.rsLabel20.TabIndex = 158;
            this.rsLabel20.Tag = "";
            this.rsLabel20.Text = "Mã nhóm tên thiết bị (II)";
            this.rsLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Nha_Sx
            // 
            this.txtTen_Nha_Sx.AutoDropDown = null;
            this.txtTen_Nha_Sx.Enabled = false;
            this.txtTen_Nha_Sx.Location = new System.Drawing.Point(132, 107);
            this.txtTen_Nha_Sx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Nha_Sx.MaxLength = 200;
            this.txtTen_Nha_Sx.Name = "txtTen_Nha_Sx";
            this.txtTen_Nha_Sx.Size = new System.Drawing.Size(451, 20);
            this.txtTen_Nha_Sx.TabIndex = 155;
            // 
            // rsLabel19
            // 
            this.rsLabel19.AutoEllipsis = true;
            this.rsLabel19.AutoSize = true;
            this.rsLabel19.Location = new System.Drawing.Point(12, 107);
            this.rsLabel19.Name = "rsLabel19";
            this.rsLabel19.Size = new System.Drawing.Size(70, 13);
            this.rsLabel19.TabIndex = 156;
            this.rsLabel19.Tag = "";
            this.rsLabel19.Text = "Nhà sản xuất";
            this.rsLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tb
            // 
            this.lbtTen_Tb.AutoEllipsis = true;
            this.lbtTen_Tb.AutoSize = true;
            this.lbtTen_Tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtTen_Tb.Location = new System.Drawing.Point(261, 38);
            this.lbtTen_Tb.Name = "lbtTen_Tb";
            this.lbtTen_Tb.Size = new System.Drawing.Size(63, 13);
            this.lbtTen_Tb.TabIndex = 154;
            this.lbtTen_Tb.Tag = "";
            this.lbtTen_Tb.Text = "Tên thiết bị ";
            this.lbtTen_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Nhom
            // 
            this.lbtTen_Nhom.AutoEllipsis = true;
            this.lbtTen_Nhom.AutoSize = true;
            this.lbtTen_Nhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtTen_Nhom.Location = new System.Drawing.Point(261, 16);
            this.lbtTen_Nhom.Name = "lbtTen_Nhom";
            this.lbtTen_Nhom.Size = new System.Drawing.Size(67, 13);
            this.lbtTen_Nhom.TabIndex = 153;
            this.lbtTen_Nhom.Tag = "";
            this.lbtTen_Nhom.Text = "Tên nhóm (I)";
            this.lbtTen_Nhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Tb_Nha_Sx
            // 
            this.txtMa_Tb_Nha_Sx.AutoDropDown = null;
            this.txtMa_Tb_Nha_Sx.Enabled = false;
            this.txtMa_Tb_Nha_Sx.Location = new System.Drawing.Point(132, 85);
            this.txtMa_Tb_Nha_Sx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tb_Nha_Sx.MaxLength = 200;
            this.txtMa_Tb_Nha_Sx.Name = "txtMa_Tb_Nha_Sx";
            this.txtMa_Tb_Nha_Sx.Size = new System.Drawing.Size(451, 20);
            this.txtMa_Tb_Nha_Sx.TabIndex = 150;
            // 
            // rsLabel23
            // 
            this.rsLabel23.AutoEllipsis = true;
            this.rsLabel23.AutoSize = true;
            this.rsLabel23.Location = new System.Drawing.Point(12, 85);
            this.rsLabel23.Name = "rsLabel23";
            this.rsLabel23.Size = new System.Drawing.Size(74, 13);
            this.rsLabel23.TabIndex = 152;
            this.rsLabel23.Tag = "";
            this.rsLabel23.Text = "Mã số nhà SX";
            this.rsLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Nhom
            // 
            this.txtMa_Nhom.AutoDropDown = null;
            this.txtMa_Nhom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nhom.Enabled = false;
            this.txtMa_Nhom.Location = new System.Drawing.Point(132, 13);
            this.txtMa_Nhom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nhom.MaxLength = 20;
            this.txtMa_Nhom.Name = "txtMa_Nhom";
            this.txtMa_Nhom.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nhom.TabIndex = 149;
            // 
            // rsLabel15
            // 
            this.rsLabel15.AutoEllipsis = true;
            this.rsLabel15.AutoSize = true;
            this.rsLabel15.Location = new System.Drawing.Point(14, 16);
            this.rsLabel15.Name = "rsLabel15";
            this.rsLabel15.Size = new System.Drawing.Size(63, 13);
            this.rsLabel15.TabIndex = 151;
            this.rsLabel15.Tag = "";
            this.rsLabel15.Text = "Mã nhóm (I)";
            this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIs_Hide
            // 
            this.chkIs_Hide.AutoSize = true;
            this.chkIs_Hide.ForeColor = System.Drawing.Color.Red;
            this.chkIs_Hide.Location = new System.Drawing.Point(126, 327);
            this.chkIs_Hide.Name = "chkIs_Hide";
            this.chkIs_Hide.Size = new System.Drawing.Size(86, 17);
            this.chkIs_Hide.TabIndex = 8;
            this.chkIs_Hide.Text = "Ẩn mã vật tư";
            this.chkIs_Hide.UseVisualStyleBackColor = true;
            // 
            // chkIs_TieuHao
            // 
            this.chkIs_TieuHao.AutoSize = true;
            this.chkIs_TieuHao.ForeColor = System.Drawing.Color.Red;
            this.chkIs_TieuHao.Location = new System.Drawing.Point(126, 350);
            this.chkIs_TieuHao.Name = "chkIs_TieuHao";
            this.chkIs_TieuHao.Size = new System.Drawing.Size(109, 17);
            this.chkIs_TieuHao.TabIndex = 9;
            this.chkIs_TieuHao.Text = "Là vật tư tiêu hao";
            this.chkIs_TieuHao.UseVisualStyleBackColor = true;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(12, 305);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(93, 13);
            this.rsLabel3.TabIndex = 115;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Mã vật tư thay thế";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_Vt_Ap
            // 
            this.lblTen_Vt_Ap.AutoEllipsis = true;
            this.lblTen_Vt_Ap.AutoSize = true;
            this.lblTen_Vt_Ap.ForeColor = System.Drawing.Color.Blue;
            this.lblTen_Vt_Ap.Location = new System.Drawing.Point(255, 305);
            this.lblTen_Vt_Ap.Name = "lblTen_Vt_Ap";
            this.lblTen_Vt_Ap.Size = new System.Drawing.Size(75, 13);
            this.lblTen_Vt_Ap.TabIndex = 117;
            this.lblTen_Vt_Ap.Text = "Tên sản phẩm";
            this.lblTen_Vt_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(12, 367);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(88, 13);
            this.rsLabel1.TabIndex = 130;
            this.rsLabel1.Text = "Lý do ẩn mã VtPt";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLy_Do
            // 
            this.txtLy_Do.AutoDropDown = null;
            this.txtLy_Do.Location = new System.Drawing.Point(126, 367);
            this.txtLy_Do.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLy_Do.MaxLength = 500;
            this.txtLy_Do.Multiline = true;
            this.txtLy_Do.Name = "txtLy_Do";
            this.txtLy_Do.Size = new System.Drawing.Size(451, 41);
            this.txtLy_Do.TabIndex = 10;
            // 
            // frmDmVtPt_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 505);
            this.Name = "frmDmVtPt_Edit";
            this.Object_ID = "DMVT";
            this.Tag = "frmDmVt, ESC";
            this.Text = "frmDmVt";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Page3.ResumeLayout(false);
            this.Page3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Control.rsTextBoxNumber numSl_Ton_Min;
		private RosySystem.Control.rsTextBoxNumber numSl_Ton_Max;
		private RosySystem.Control.rsLabel lblSl_Ton_Max;
        private RosySystem.Control.rsLabel lblSl_Ton_Min;
		private RosySystem.Control.rsTextBox txtDvt;
		private RosySystem.Control.rsLabel lbDvt;
		private RosySystem.Control.rsTextBox txtTen_Vt;
		private RosySystem.Control.rsTextBox txtMa_Vt;
		private RosySystem.Control.rsTextBox txtMa_Nh_Vt;
		private RosySystem.Control.rsLabel lbtTen_Nh_Vt;
		private RosySystem.Control.rsLabel lbMa_Nh_Vt;
		private RosySystem.Control.rsLabel lbTen_Vt;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Control.rsTextBox txtMa_Vt_Ap;
		private RosySystem.Control.rsTextBox txtThong_So_Kt;
        private RosySystem.Control.rsLabel rsLabel10;
        private System.Windows.Forms.TabPage Page3;
        private RosySystem.Control.rsTextBox txtTen_Vt_Chuan;
        private RosySystem.Control.rsLabel rsLabel21;
        private RosySystem.Control.rsTextBox txtMa_Tb_Nhom;
        private RosySystem.Control.rsLabel rsLabel20;
        private RosySystem.Control.rsTextBox txtTen_Nha_Sx;
        private RosySystem.Control.rsLabel rsLabel19;
        private RosySystem.Control.rsLabel lbtTen_Tb;
        private RosySystem.Control.rsLabel lbtTen_Nhom;
        private RosySystem.Control.rsTextBox txtMa_Tb_Nha_Sx;
        private RosySystem.Control.rsLabel rsLabel23;
        private RosySystem.Control.rsTextBox txtMa_Nhom;
        private RosySystem.Control.rsLabel rsLabel15;
        private RosySystem.Control.rsCheckbox chkIs_Hide;
        private RosySystem.Control.rsCheckbox chkIs_TieuHao;
        private RosySystem.Control.rsLabel lblTen_Vt_Ap;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsTextBox txtLy_Do;
        private RosySystem.Control.rsLabel rsLabel1;
    }
}