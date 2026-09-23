namespace RosyModule.Manufactory
{
    partial class frmLichDungSX_Edit
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
            this.lbMa_Kho = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtLoai_SX = new RosySystem.Control.rsTextBoxEnum();
            this.txtCa_BD = new RosySystem.Control.rsTextBoxEnum();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtLy_Do = new RosySystem.Control.rsTextBox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(408, 201);
            this.btgAccept.Size = new System.Drawing.Size(179, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(639, 185);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtLy_Do);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.dteNgay_Ct2);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.txtCa_BD);
            this.Page1.Controls.Add(this.rsLabel5);
            this.Page1.Controls.Add(this.txtLoai_SX);
            this.Page1.Controls.Add(this.rsLabel4);
            this.Page1.Controls.Add(this.rsLabel3);
            this.Page1.Controls.Add(this.dteNgay_Ct1);
            this.Page1.Controls.Add(this.rsLabel6);
            this.Page1.Controls.Add(this.lbMa_Kho);
            this.Page1.Size = new System.Drawing.Size(631, 159);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(631, 159);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 212);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(45, 221);
            this.lblLog.Text = "";
            // 
            // lbMa_Kho
            // 
            this.lbMa_Kho.AutoEllipsis = true;
            this.lbMa_Kho.AutoSize = true;
            this.lbMa_Kho.Location = new System.Drawing.Point(16, 22);
            this.lbMa_Kho.Name = "lbMa_Kho";
            this.lbMa_Kho.Size = new System.Drawing.Size(66, 13);
            this.lbMa_Kho.TabIndex = 20;
            this.lbMa_Kho.Tag = "";
            this.lbMa_Kho.Text = "Phân loại Sx";
            this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(16, 69);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(47, 13);
            this.rsLabel6.TabIndex = 119;
            this.rsLabel6.Tag = "Ngay_Ct1";
            this.rsLabel6.Text = "Ngày áp";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(129, 64);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ct1.TabIndex = 2;
            this.dteNgay_Ct1.Tag = "Ngay_Ct";
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(16, 44);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(104, 13);
            this.rsLabel3.TabIndex = 122;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Ca bắt đầu dừng SX";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel4.Location = new System.Drawing.Point(202, 21);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(132, 13);
            this.rsLabel4.TabIndex = 122;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "CAN - cán, LUYEN - luyện";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoai_SX
            // 
            this.txtLoai_SX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoai_SX.AutoDropDown = null;
            this.txtLoai_SX.InputMask = "CAN,LUYEN";
            this.txtLoai_SX.Location = new System.Drawing.Point(129, 19);
            this.txtLoai_SX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLoai_SX.Name = "txtLoai_SX";
            this.txtLoai_SX.Size = new System.Drawing.Size(68, 20);
            this.txtLoai_SX.TabIndex = 0;
            this.txtLoai_SX.Text = "CAN";
            // 
            // txtCa_BD
            // 
            this.txtCa_BD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCa_BD.AutoDropDown = null;
            this.txtCa_BD.InputMask = "I,II";
            this.txtCa_BD.Location = new System.Drawing.Point(129, 41);
            this.txtCa_BD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtCa_BD.Name = "txtCa_BD";
            this.txtCa_BD.Size = new System.Drawing.Size(68, 20);
            this.txtCa_BD.TabIndex = 1;
            this.txtCa_BD.Text = "I";
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.ForeColor = System.Drawing.Color.Blue;
            this.rsLabel5.Location = new System.Drawing.Point(202, 43);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(82, 13);
            this.rsLabel5.TabIndex = 124;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "I - ca 1, II - ca 2";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(129, 87);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ct2.TabIndex = 3;
            this.dteNgay_Ct2.Tag = "Ngay_Ct";
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(16, 92);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(47, 13);
            this.rsLabel1.TabIndex = 127;
            this.rsLabel1.Tag = "Ngay_Ct2";
            this.rsLabel1.Text = "Ngày áp";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(16, 118);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(33, 13);
            this.rsLabel2.TabIndex = 128;
            this.rsLabel2.Tag = "Ly_Do";
            this.rsLabel2.Text = "Lý do";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLy_Do
            // 
            this.txtLy_Do.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLy_Do.AutoDropDown = null;
            this.txtLy_Do.Location = new System.Drawing.Point(129, 111);
            this.txtLy_Do.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLy_Do.MaxLength = 200;
            this.txtLy_Do.Name = "txtLy_Do";
            this.txtLy_Do.Size = new System.Drawing.Size(497, 20);
            this.txtLy_Do.TabIndex = 4;
            // 
            // frmLichDungSX_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(651, 262);
            this.Name = "frmLichDungSX_Edit";
            this.Object_ID = "LENHSANXUAT";
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

        private RosySystem.Control.rsLabel lbMa_Kho;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBoxEnum txtLoai_SX;
        private RosySystem.Control.rsTextBoxEnum txtCa_BD;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtLy_Do;

	}
}