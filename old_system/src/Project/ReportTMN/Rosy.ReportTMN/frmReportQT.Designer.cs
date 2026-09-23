namespace RosyReportTMN
{
	partial class frmReportQT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportQT));
            this.imglTree = new System.Windows.Forms.ImageList();
            this.btRun = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.pnlRunReport = new RosySystem.Control.rsPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpReport_Result = new System.Windows.Forms.TabPage();
            this.tpChart = new System.Windows.Forms.TabPage();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.cboSo_Xe = new RosySystem.Control.rsComboBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsComboBox1 = new RosySystem.Control.rsComboBox();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.pnlRunReport.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.rsPanel1.SuspendLayout();
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
            // pnlRunReport
            // 
            this.pnlRunReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRunReport.Controls.Add(this.btExit);
            this.pnlRunReport.Controls.Add(this.btRun);
            this.pnlRunReport.Location = new System.Drawing.Point(659, 3);
            this.pnlRunReport.Name = "pnlRunReport";
            this.pnlRunReport.Size = new System.Drawing.Size(127, 57);
            this.pnlRunReport.TabIndex = 1;
            this.pnlRunReport.TabStop = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpReport_Result);
            this.tabControl1.Controls.Add(this.tpChart);
            this.tabControl1.Location = new System.Drawing.Point(8, 156);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 414);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabStop = false;
            // 
            // tpReport_Result
            // 
            this.tpReport_Result.Location = new System.Drawing.Point(4, 22);
            this.tpReport_Result.Name = "tpReport_Result";
            this.tpReport_Result.Padding = new System.Windows.Forms.Padding(3);
            this.tpReport_Result.Size = new System.Drawing.Size(776, 388);
            this.tpReport_Result.TabIndex = 0;
            this.tpReport_Result.Tag = "Report_Result";
            this.tpReport_Result.Text = "Kết quả báo cáo";
            this.tpReport_Result.UseVisualStyleBackColor = true;
            // 
            // tpChart
            // 
            this.tpChart.Location = new System.Drawing.Point(4, 22);
            this.tpChart.Name = "tpChart";
            this.tpChart.Padding = new System.Windows.Forms.Padding(3);
            this.tpChart.Size = new System.Drawing.Size(776, 439);
            this.tpChart.TabIndex = 1;
            this.tpChart.Tag = "Chart";
            this.tpChart.Text = "Biểu đồ";
            this.tpChart.UseVisualStyleBackColor = true;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rsPanel1.Controls.Add(this.rsLabel4);
            this.rsPanel1.Controls.Add(this.rsLabel2);
            this.rsPanel1.Controls.Add(this.rsLabel1);
            this.rsPanel1.Controls.Add(this.rsLabel3);
            this.rsPanel1.Controls.Add(this.rsComboBox1);
            this.rsPanel1.Controls.Add(this.cboSo_Xe);
            this.rsPanel1.Location = new System.Drawing.Point(12, 6);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(644, 144);
            this.rsPanel1.TabIndex = 2;
            this.rsPanel1.TabStop = true;
            // 
            // cboSo_Xe
            // 
            this.cboSo_Xe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSo_Xe.DropDownHeight = 147;
            this.cboSo_Xe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSo_Xe.FormattingEnabled = true;
            this.cboSo_Xe.IntegralHeight = false;
            this.cboSo_Xe.Location = new System.Drawing.Point(120, 3);
            this.cboSo_Xe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboSo_Xe.Name = "cboSo_Xe";
            this.cboSo_Xe.Size = new System.Drawing.Size(213, 24);
            this.cboSo_Xe.TabIndex = 4;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(13, 9);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(102, 17);
            this.rsLabel3.TabIndex = 214;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Loại báo cáo";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(13, 33);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(76, 17);
            this.rsLabel1.TabIndex = 215;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Thời gian";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsComboBox1
            // 
            this.rsComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.rsComboBox1.DropDownHeight = 147;
            this.rsComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsComboBox1.FormattingEnabled = true;
            this.rsComboBox1.IntegralHeight = false;
            this.rsComboBox1.Location = new System.Drawing.Point(120, 30);
            this.rsComboBox1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.rsComboBox1.Name = "rsComboBox1";
            this.rsComboBox1.Size = new System.Drawing.Size(118, 24);
            this.rsComboBox1.TabIndex = 4;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(13, 62);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(141, 17);
            this.rsLabel2.TabIndex = 215;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Khách hàng - NCC";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.Location = new System.Drawing.Point(13, 88);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(36, 17);
            this.rsLabel4.TabIndex = 215;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "Kho";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReportQT
            // 
            this.AcceptButton = this.btRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.rsPanel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlRunReport);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReportQT";
            this.Object_ID = "REP_ALL";
            this.Tag = "frmReport";
            this.Text = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlRunReport.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.rsPanel1.ResumeLayout(false);
            this.rsPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ImageList imglTree;
        private RosySystem.Control.rsButton btRun;
		private RosySystem.Control.rsButton btExit;
		private RosySystem.Control.rsPanel pnlRunReport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpReport_Result;
        private System.Windows.Forms.TabPage tpChart;
        private RosySystem.Control.rsPanel rsPanel1;
        private RosySystem.Control.rsComboBox cboSo_Xe;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsComboBox rsComboBox1;
    }
}