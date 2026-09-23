namespace RosyList
{
    partial class frmTransferHMBL
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
            this.btSave = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.numTien_Bao_Lanh1 = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt1 = new RosySystem.Control.rsTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numTien_BL1 = new RosySystem.Control.rsTextBoxNumber();
            this.lbtTen_Kh1 = new RosySystem.Control.rsLabel();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtSo_BL1 = new RosySystem.Control.rsTextBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numTien_BL2 = new RosySystem.Control.rsTextBoxNumber();
            this.lbtTen_Kh2 = new RosySystem.Control.rsLabel();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.txtSo_BL2 = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt2 = new RosySystem.Control.rsTextBox();
            this.numTien_Bao_Lanh2 = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.txtNote = new RosySystem.Control.rsTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(462, 226);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(543, 226);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // numTien_Bao_Lanh1
            // 
            this.numTien_Bao_Lanh1.AutoDropDown = null;
            this.numTien_Bao_Lanh1.bFormat = true;
            this.numTien_Bao_Lanh1.Location = new System.Drawing.Point(116, 87);
            this.numTien_Bao_Lanh1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_Bao_Lanh1.Name = "numTien_Bao_Lanh1";
            this.numTien_Bao_Lanh1.ReadOnly = true;
            this.numTien_Bao_Lanh1.Scale = 0;
            this.numTien_Bao_Lanh1.Size = new System.Drawing.Size(119, 20);
            this.numTien_Bao_Lanh1.TabIndex = 123;
            this.numTien_Bao_Lanh1.TabStop = false;
            this.numTien_Bao_Lanh1.Text = "0";
            this.numTien_Bao_Lanh1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_Bao_Lanh1.Value = 0D;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(1, 93);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(72, 13);
            this.rsLabel3.TabIndex = 121;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Tiền bảo lãnh";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(1, 68);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(70, 13);
            this.rsLabel1.TabIndex = 119;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Mã đối tượng";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt1
            // 
            this.txtMa_Dt1.AutoDropDown = null;
            this.txtMa_Dt1.Location = new System.Drawing.Point(116, 65);
            this.txtMa_Dt1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt1.MaxLength = 200;
            this.txtMa_Dt1.Name = "txtMa_Dt1";
            this.txtMa_Dt1.ReadOnly = true;
            this.txtMa_Dt1.Size = new System.Drawing.Size(72, 20);
            this.txtMa_Dt1.TabIndex = 118;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numTien_BL1);
            this.groupBox1.Controls.Add(this.lbtTen_Kh1);
            this.groupBox1.Controls.Add(this.rsLabel7);
            this.groupBox1.Controls.Add(this.txtSo_BL1);
            this.groupBox1.Controls.Add(this.rsLabel2);
            this.groupBox1.Controls.Add(this.txtMa_Dt1);
            this.groupBox1.Controls.Add(this.numTien_Bao_Lanh1);
            this.groupBox1.Controls.Add(this.rsLabel1);
            this.groupBox1.Controls.Add(this.rsLabel3);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 169);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảo lãnh 1";
            // 
            // numTien_BL1
            // 
            this.numTien_BL1.AutoDropDown = null;
            this.numTien_BL1.bFormat = true;
            this.numTien_BL1.Location = new System.Drawing.Point(117, 113);
            this.numTien_BL1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_BL1.Name = "numTien_BL1";
            this.numTien_BL1.Scale = 0;
            this.numTien_BL1.Size = new System.Drawing.Size(119, 20);
            this.numTien_BL1.TabIndex = 0;
            this.numTien_BL1.TabStop = false;
            this.numTien_BL1.Text = "0";
            this.numTien_BL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_BL1.Value = 0D;
            // 
            // lbtTen_Kh1
            // 
            this.lbtTen_Kh1.AutoEllipsis = true;
            this.lbtTen_Kh1.AutoSize = true;
            this.lbtTen_Kh1.Location = new System.Drawing.Point(6, 16);
            this.lbtTen_Kh1.Name = "lbtTen_Kh1";
            this.lbtTen_Kh1.Size = new System.Drawing.Size(86, 13);
            this.lbtTen_Kh1.TabIndex = 126;
            this.lbtTen_Kh1.Tag = "";
            this.lbtTen_Kh1.Text = "Tên khách hàng";
            this.lbtTen_Kh1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(2, 119);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(113, 13);
            this.rsLabel7.TabIndex = 126;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Tiền bảo lãnh thay đổi";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_BL1
            // 
            this.txtSo_BL1.AutoDropDown = null;
            this.txtSo_BL1.Location = new System.Drawing.Point(116, 42);
            this.txtSo_BL1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_BL1.MaxLength = 200;
            this.txtSo_BL1.Name = "txtSo_BL1";
            this.txtSo_BL1.ReadOnly = true;
            this.txtSo_BL1.Size = new System.Drawing.Size(175, 20);
            this.txtSo_BL1.TabIndex = 124;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(1, 45);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(73, 13);
            this.rsLabel2.TabIndex = 125;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Số bảo lãnh 1";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numTien_BL2);
            this.groupBox2.Controls.Add(this.lbtTen_Kh2);
            this.groupBox2.Controls.Add(this.rsLabel8);
            this.groupBox2.Controls.Add(this.txtSo_BL2);
            this.groupBox2.Controls.Add(this.rsLabel6);
            this.groupBox2.Controls.Add(this.txtMa_Dt2);
            this.groupBox2.Controls.Add(this.numTien_Bao_Lanh2);
            this.groupBox2.Controls.Add(this.rsLabel4);
            this.groupBox2.Controls.Add(this.rsLabel5);
            this.groupBox2.Location = new System.Drawing.Point(320, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 169);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảo lãnh 2";
            // 
            // numTien_BL2
            // 
            this.numTien_BL2.AutoDropDown = null;
            this.numTien_BL2.bFormat = true;
            this.numTien_BL2.Location = new System.Drawing.Point(117, 105);
            this.numTien_BL2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_BL2.Name = "numTien_BL2";
            this.numTien_BL2.Scale = 0;
            this.numTien_BL2.Size = new System.Drawing.Size(119, 20);
            this.numTien_BL2.TabIndex = 1;
            this.numTien_BL2.TabStop = false;
            this.numTien_BL2.Text = "0";
            this.numTien_BL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_BL2.Value = 0D;
            // 
            // lbtTen_Kh2
            // 
            this.lbtTen_Kh2.AutoEllipsis = true;
            this.lbtTen_Kh2.AutoSize = true;
            this.lbtTen_Kh2.Location = new System.Drawing.Point(6, 16);
            this.lbtTen_Kh2.Name = "lbtTen_Kh2";
            this.lbtTen_Kh2.Size = new System.Drawing.Size(86, 13);
            this.lbtTen_Kh2.TabIndex = 126;
            this.lbtTen_Kh2.Tag = "";
            this.lbtTen_Kh2.Text = "Tên khách hàng";
            this.lbtTen_Kh2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(2, 111);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(113, 13);
            this.rsLabel8.TabIndex = 126;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Tiền bảo lãnh thay đổi";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_BL2
            // 
            this.txtSo_BL2.AutoDropDown = null;
            this.txtSo_BL2.Location = new System.Drawing.Point(117, 39);
            this.txtSo_BL2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_BL2.MaxLength = 200;
            this.txtSo_BL2.Name = "txtSo_BL2";
            this.txtSo_BL2.ReadOnly = true;
            this.txtSo_BL2.Size = new System.Drawing.Size(175, 20);
            this.txtSo_BL2.TabIndex = 124;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(2, 42);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(73, 13);
            this.rsLabel6.TabIndex = 125;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "Số bảo lãnh 2";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt2
            // 
            this.txtMa_Dt2.AutoDropDown = null;
            this.txtMa_Dt2.Location = new System.Drawing.Point(117, 62);
            this.txtMa_Dt2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt2.MaxLength = 200;
            this.txtMa_Dt2.Name = "txtMa_Dt2";
            this.txtMa_Dt2.ReadOnly = true;
            this.txtMa_Dt2.Size = new System.Drawing.Size(73, 20);
            this.txtMa_Dt2.TabIndex = 118;
            // 
            // numTien_Bao_Lanh2
            // 
            this.numTien_Bao_Lanh2.AutoDropDown = null;
            this.numTien_Bao_Lanh2.bFormat = true;
            this.numTien_Bao_Lanh2.Location = new System.Drawing.Point(117, 83);
            this.numTien_Bao_Lanh2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_Bao_Lanh2.Name = "numTien_Bao_Lanh2";
            this.numTien_Bao_Lanh2.ReadOnly = true;
            this.numTien_Bao_Lanh2.Scale = 0;
            this.numTien_Bao_Lanh2.Size = new System.Drawing.Size(119, 20);
            this.numTien_Bao_Lanh2.TabIndex = 123;
            this.numTien_Bao_Lanh2.TabStop = false;
            this.numTien_Bao_Lanh2.Text = "0";
            this.numTien_Bao_Lanh2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_Bao_Lanh2.Value = 0D;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(2, 65);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(70, 13);
            this.rsLabel4.TabIndex = 119;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Mã đối tượng";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(2, 89);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(72, 13);
            this.rsLabel5.TabIndex = 121;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Tiền bảo lãnh";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(10, 207);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(44, 13);
            this.rsLabel9.TabIndex = 1102;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Ghi chú";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNote
            // 
            this.txtNote.AutoDropDown = null;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNote.Location = new System.Drawing.Point(59, 204);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNote.MaxLength = 200;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(559, 20);
            this.txtNote.TabIndex = 1101;
            // 
            // frmTransferHMBL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 261);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransferHMBL";
            this.Text = "Chuyển hạn mức bảo lãnh";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RosySystem.Control.rsButton btSave;
        private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsTextBoxNumber numTien_Bao_Lanh1;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel1;
        public RosySystem.Control.rsTextBox txtMa_Dt1;
        private System.Windows.Forms.GroupBox groupBox1;
        private RosySystem.Control.rsTextBoxNumber numTien_BL1;
        private RosySystem.Control.rsLabel lbtTen_Kh1;
        private RosySystem.Control.rsLabel rsLabel7;
        public RosySystem.Control.rsTextBox txtSo_BL1;
        private RosySystem.Control.rsLabel rsLabel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private RosySystem.Control.rsTextBoxNumber numTien_BL2;
        private RosySystem.Control.rsLabel lbtTen_Kh2;
        private RosySystem.Control.rsLabel rsLabel8;
        public RosySystem.Control.rsTextBox txtSo_BL2;
        private RosySystem.Control.rsLabel rsLabel6;
        public RosySystem.Control.rsTextBox txtMa_Dt2;
        private RosySystem.Control.rsTextBoxNumber numTien_Bao_Lanh2;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsTextBox txtNote;
	}
}