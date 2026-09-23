namespace RosyReport
{
	partial class frmReportResult
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpReport_Result = new System.Windows.Forms.TabPage();
			this.tpChart = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpReport_Result);
			this.tabControl1.Controls.Add(this.tpChart);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(784, 562);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabStop = false;
			// 
			// tpReport_Result
			// 
			this.tpReport_Result.Location = new System.Drawing.Point(4, 22);
			this.tpReport_Result.Name = "tpReport_Result";
			this.tpReport_Result.Padding = new System.Windows.Forms.Padding(3);
			this.tpReport_Result.Size = new System.Drawing.Size(776, 536);
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
			this.tpChart.Size = new System.Drawing.Size(776, 536);
			this.tpChart.TabIndex = 1;
			this.tpChart.Tag = "Chart";
			this.tpChart.Text = "Biểu đồ";
			this.tpChart.UseVisualStyleBackColor = true;
			// 
			// frmReportResult
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmReportResult";
			this.Text = "frmResult";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpReport_Result;
		private System.Windows.Forms.TabPage tpChart;



	}
}