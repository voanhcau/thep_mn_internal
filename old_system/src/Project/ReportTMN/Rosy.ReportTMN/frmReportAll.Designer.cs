namespace RosyReportTMN
{
	partial class frmReportAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAll));
            this.imglTree = new System.Windows.Forms.ImageList(this.components);
            this.btRun = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.btFormula = new RosySystem.Control.rsButton();
            this.pnlRunReport = new RosySystem.Control.rsPanel();
            this.grbPrint_Sign = new RosySystem.Control.rsGroupBox();
            this.txtName3 = new RosySystem.Control.rsTextBox();
            this.txtName2 = new RosySystem.Control.rsTextBox();
            this.txtName1 = new RosySystem.Control.rsTextBox();
            this.txtSign3 = new RosySystem.Control.rsTextBox();
            this.txtSign2 = new RosySystem.Control.rsTextBox();
            this.txtSign1 = new RosySystem.Control.rsTextBox();
            this.chkPrint_Sign = new RosySystem.Control.rsCheckbox();
            this.grbLoai_Tien = new RosySystem.Control.rsGroupBox();
            this.rdbIs_Vnd_Nt = new RosySystem.Control.rsRadioButton();
            this.rdbIs_Nt = new RosySystem.Control.rsRadioButton();
            this.rdbIs_Vnd = new RosySystem.Control.rsRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabReport = new System.Windows.Forms.TabControl();
            this.pageReport = new System.Windows.Forms.TabPage();
            this.chkIs_Ky = new RosySystem.Control.rsCheckbox();
            this.pnlRunReport.SuspendLayout();
            this.grbPrint_Sign.SuspendLayout();
            this.grbLoai_Tien.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // imglTree
            // 
            this.imglTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglTree.ImageStream")));
            this.imglTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imglTree.Images.SetKeyName(0, "Node.png");
            this.imglTree.Images.SetKeyName(1, "NodeSelect.png");
            this.imglTree.Images.SetKeyName(2, "NodeExpand.png");
            this.imglTree.Images.SetKeyName(3, "NodeExpandSelect.png");
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(3, 3);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(115, 23);
            this.btRun.TabIndex = 0;
            this.btRun.Tag = "Thuc_hien";
            this.btRun.Text = "Thực hiện";
            this.btRun.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(3, 28);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(115, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btFormula
            // 
            this.btFormula.Location = new System.Drawing.Point(3, 53);
            this.btFormula.Name = "btFormula";
            this.btFormula.Size = new System.Drawing.Size(115, 23);
            this.btFormula.TabIndex = 2;
            this.btFormula.Tag = "Formula";
            this.btFormula.Text = "&Khai báo công thức";
            this.btFormula.UseVisualStyleBackColor = true;
            // 
            // pnlRunReport
            // 
            this.pnlRunReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRunReport.Controls.Add(this.btFormula);
            this.pnlRunReport.Controls.Add(this.btExit);
            this.pnlRunReport.Controls.Add(this.btRun);
            this.pnlRunReport.Location = new System.Drawing.Point(659, 3);
            this.pnlRunReport.Name = "pnlRunReport";
            this.pnlRunReport.Size = new System.Drawing.Size(127, 81);
            this.pnlRunReport.TabIndex = 1;
            this.pnlRunReport.TabStop = true;
            // 
            // grbPrint_Sign
            // 
            this.grbPrint_Sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPrint_Sign.BorderColor = System.Drawing.Color.Black;
            this.grbPrint_Sign.Controls.Add(this.txtName3);
            this.grbPrint_Sign.Controls.Add(this.txtName2);
            this.grbPrint_Sign.Controls.Add(this.txtName1);
            this.grbPrint_Sign.Controls.Add(this.txtSign3);
            this.grbPrint_Sign.Controls.Add(this.txtSign2);
            this.grbPrint_Sign.Controls.Add(this.txtSign1);
            this.grbPrint_Sign.Location = new System.Drawing.Point(648, 390);
            this.grbPrint_Sign.Name = "grbPrint_Sign";
            this.grbPrint_Sign.Size = new System.Drawing.Size(138, 158);
            this.grbPrint_Sign.TabIndex = 3;
            this.grbPrint_Sign.TabStop = false;
            // 
            // txtName3
            // 
            this.txtName3.AutoDropDown = null;
            this.txtName3.Location = new System.Drawing.Point(5, 132);
            this.txtName3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtName3.Name = "txtName3";
            this.txtName3.Size = new System.Drawing.Size(128, 20);
            this.txtName3.TabIndex = 5;
            this.txtName3.TabStop = false;
            // 
            // txtName2
            // 
            this.txtName2.AutoDropDown = null;
            this.txtName2.Location = new System.Drawing.Point(5, 84);
            this.txtName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(128, 20);
            this.txtName2.TabIndex = 3;
            this.txtName2.TabStop = false;
            // 
            // txtName1
            // 
            this.txtName1.AutoDropDown = null;
            this.txtName1.Location = new System.Drawing.Point(5, 36);
            this.txtName1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(128, 20);
            this.txtName1.TabIndex = 1;
            this.txtName1.TabStop = false;
            // 
            // txtSign3
            // 
            this.txtSign3.AutoDropDown = null;
            this.txtSign3.Location = new System.Drawing.Point(5, 110);
            this.txtSign3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSign3.Name = "txtSign3";
            this.txtSign3.Size = new System.Drawing.Size(128, 20);
            this.txtSign3.TabIndex = 4;
            this.txtSign3.TabStop = false;
            // 
            // txtSign2
            // 
            this.txtSign2.AutoDropDown = null;
            this.txtSign2.Location = new System.Drawing.Point(5, 62);
            this.txtSign2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSign2.Name = "txtSign2";
            this.txtSign2.Size = new System.Drawing.Size(128, 20);
            this.txtSign2.TabIndex = 2;
            this.txtSign2.TabStop = false;
            // 
            // txtSign1
            // 
            this.txtSign1.AutoDropDown = null;
            this.txtSign1.Location = new System.Drawing.Point(5, 14);
            this.txtSign1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSign1.Name = "txtSign1";
            this.txtSign1.Size = new System.Drawing.Size(128, 20);
            this.txtSign1.TabIndex = 0;
            this.txtSign1.TabStop = false;
            // 
            // chkPrint_Sign
            // 
            this.chkPrint_Sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrint_Sign.AutoSize = true;
            this.chkPrint_Sign.Checked = true;
            this.chkPrint_Sign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint_Sign.Location = new System.Drawing.Point(658, 386);
            this.chkPrint_Sign.Name = "chkPrint_Sign";
            this.chkPrint_Sign.Size = new System.Drawing.Size(70, 17);
            this.chkPrint_Sign.TabIndex = 0;
            this.chkPrint_Sign.TabStop = false;
            this.chkPrint_Sign.Tag = "Print_Sign";
            this.chkPrint_Sign.Text = "&In chữ ký";
            this.chkPrint_Sign.UseVisualStyleBackColor = true;
            // 
            // grbLoai_Tien
            // 
            this.grbLoai_Tien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLoai_Tien.BorderColor = System.Drawing.Color.Black;
            this.grbLoai_Tien.Controls.Add(this.chkIs_Ky);
            this.grbLoai_Tien.Controls.Add(this.rdbIs_Vnd_Nt);
            this.grbLoai_Tien.Controls.Add(this.rdbIs_Nt);
            this.grbLoai_Tien.Controls.Add(this.rdbIs_Vnd);
            this.grbLoai_Tien.Location = new System.Drawing.Point(648, 247);
            this.grbLoai_Tien.Name = "grbLoai_Tien";
            this.grbLoai_Tien.Size = new System.Drawing.Size(138, 128);
            this.grbLoai_Tien.TabIndex = 2;
            this.grbLoai_Tien.TabStop = false;
            this.grbLoai_Tien.Tag = "Currency";
            this.grbLoai_Tien.Text = "Loại tiền";
            // 
            // rdbIs_Vnd_Nt
            // 
            this.rdbIs_Vnd_Nt.AutoSize = true;
            this.rdbIs_Vnd_Nt.Location = new System.Drawing.Point(15, 69);
            this.rdbIs_Vnd_Nt.Name = "rdbIs_Vnd_Nt";
            this.rdbIs_Vnd_Nt.Size = new System.Drawing.Size(103, 17);
            this.rdbIs_Vnd_Nt.TabIndex = 1;
            this.rdbIs_Vnd_Nt.Tag = "SSong_Tien";
            this.rdbIs_Vnd_Nt.Text = "Cả &hai đồng tiền";
            this.rdbIs_Vnd_Nt.UnChecked = true;
            this.rdbIs_Vnd_Nt.UseVisualStyleBackColor = true;
            // 
            // rdbIs_Nt
            // 
            this.rdbIs_Nt.AutoSize = true;
            this.rdbIs_Nt.Location = new System.Drawing.Point(15, 46);
            this.rdbIs_Nt.Name = "rdbIs_Nt";
            this.rdbIs_Nt.Size = new System.Drawing.Size(87, 17);
            this.rdbIs_Nt.TabIndex = 0;
            this.rdbIs_Nt.Tag = "Ngoai_Te";
            this.rdbIs_Nt.Text = "Tiền n&goại tệ";
            this.rdbIs_Nt.UnChecked = true;
            this.rdbIs_Nt.UseVisualStyleBackColor = true;
            // 
            // rdbIs_Vnd
            // 
            this.rdbIs_Vnd.AutoSize = true;
            this.rdbIs_Vnd.Checked = true;
            this.rdbIs_Vnd.Location = new System.Drawing.Point(14, 23);
            this.rdbIs_Vnd.Name = "rdbIs_Vnd";
            this.rdbIs_Vnd.Size = new System.Drawing.Size(72, 17);
            this.rdbIs_Vnd.TabIndex = 0;
            this.rdbIs_Vnd.TabStop = true;
            this.rdbIs_Vnd.Tag = "Tien_Current";
            this.rdbIs_Vnd.Text = "Tiền &VND";
            this.rdbIs_Vnd.UnChecked = false;
            this.rdbIs_Vnd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(650, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "F3 - Change report info";
            // 
            // tabReport
            // 
            this.tabReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabReport.Controls.Add(this.pageReport);
            this.tabReport.Location = new System.Drawing.Point(8, 8);
            this.tabReport.Name = "tabReport";
            this.tabReport.SelectedIndex = 0;
            this.tabReport.Size = new System.Drawing.Size(634, 548);
            this.tabReport.TabIndex = 5;
            // 
            // pageReport
            // 
            this.pageReport.Location = new System.Drawing.Point(4, 22);
            this.pageReport.Name = "pageReport";
            this.pageReport.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pageReport.Size = new System.Drawing.Size(626, 522);
            this.pageReport.TabIndex = 0;
            this.pageReport.Tag = "";
            this.pageReport.Text = "Danh sách báo cáo";
            this.pageReport.UseVisualStyleBackColor = true;
            // 
            // chkIs_Ky
            // 
            this.chkIs_Ky.AutoSize = true;
            this.chkIs_Ky.Checked = true;
            this.chkIs_Ky.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIs_Ky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Ky.ForeColor = System.Drawing.Color.Blue;
            this.chkIs_Ky.Location = new System.Drawing.Point(15, 98);
            this.chkIs_Ky.Name = "chkIs_Ky";
            this.chkIs_Ky.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIs_Ky.Size = new System.Drawing.Size(59, 17);
            this.chkIs_Ky.TabIndex = 1037;
            this.chkIs_Ky.TabStop = false;
            this.chkIs_Ky.Text = "&Đã ký";
            this.chkIs_Ky.UseVisualStyleBackColor = true;
            // 
            // frmReportAll
            // 
            this.AcceptButton = this.btRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.tabReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPrint_Sign);
            this.Controls.Add(this.grbPrint_Sign);
            this.Controls.Add(this.grbLoai_Tien);
            this.Controls.Add(this.pnlRunReport);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReportAll";
            this.Object_ID = "REP_ALL";
            this.Tag = "frmReport";
            this.Text = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlRunReport.ResumeLayout(false);
            this.grbPrint_Sign.ResumeLayout(false);
            this.grbPrint_Sign.PerformLayout();
            this.grbLoai_Tien.ResumeLayout(false);
            this.grbLoai_Tien.PerformLayout();
            this.tabReport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ImageList imglTree;
        private RosySystem.Control.rsButton btRun;
		private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsButton btFormula;
		private RosySystem.Control.rsCheckbox chkPrint_Sign;
		private RosySystem.Control.rsPanel pnlRunReport;
		private RosySystem.Control.rsGroupBox grbPrint_Sign;
		private RosySystem.Control.rsGroupBox grbLoai_Tien;
		private RosySystem.Control.rsRadioButton rdbIs_Nt;
		private RosySystem.Control.rsRadioButton rdbIs_Vnd;
		private RosySystem.Control.rsTextBox txtName3;
		private RosySystem.Control.rsTextBox txtName2;
		private RosySystem.Control.rsTextBox txtName1;
		private RosySystem.Control.rsTextBox txtSign3;
		private RosySystem.Control.rsTextBox txtSign2;
		private RosySystem.Control.rsTextBox txtSign1;
		private RosySystem.Control.rsRadioButton rdbIs_Vnd_Nt;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabReport;
        private System.Windows.Forms.TabPage pageReport;
        private RosySystem.Control.rsCheckbox chkIs_Ky;
    }
}