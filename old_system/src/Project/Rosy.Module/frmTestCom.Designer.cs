namespace RosyModule
{
	partial class frmTestCom
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
			this.numDelay = new RosySystem.Control.rsNumericUpdown();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.numInt = new RosySystem.Control.rsNumericUpdown();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.numValue = new RosySystem.Control.rsTextBoxNumber();
			this.btStop = new RosySystem.Control.rsButton();
			this.btShot = new RosySystem.Control.rsButton();
			this.btFix = new RosySystem.Control.rsButton();
			this.btDec = new RosySystem.Control.rsButton();
			this.btInc = new RosySystem.Control.rsButton();
			this.btCancel = new RosySystem.Control.rsButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numInt)).BeginInit();
			this.SuspendLayout();
			// 
			// numDelay
			// 
			this.numDelay.Location = new System.Drawing.Point(104, 79);
			this.numDelay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numDelay.Name = "numDelay";
			this.numDelay.Size = new System.Drawing.Size(100, 20);
			this.numDelay.TabIndex = 0;
			this.numDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numDelay.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(12, 81);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(88, 13);
			this.rsLabel1.TabIndex = 1;
			this.rsLabel1.Text = "Thời gian trễ (ms)";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(12, 103);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(63, 13);
			this.rsLabel2.TabIndex = 3;
			this.rsLabel2.Text = "Interval (kg)";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numInt
			// 
			this.numInt.Location = new System.Drawing.Point(104, 101);
			this.numInt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numInt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numInt.Name = "numInt";
			this.numInt.Size = new System.Drawing.Size(100, 20);
			this.numInt.TabIndex = 1;
			this.numInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numInt.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(12, 149);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(86, 13);
			this.rsLabel3.TabIndex = 4;
			this.rsLabel3.Text = "Giá trị khối lượng";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numValue
			// 
			this.numValue.bFormat = true;
			this.numValue.Location = new System.Drawing.Point(104, 146);
			this.numValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numValue.Name = "numValue";
			this.numValue.Scale = 0;
			this.numValue.Size = new System.Drawing.Size(100, 20);
			this.numValue.TabIndex = 2;
			this.numValue.Text = "0";
			this.numValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numValue.Value = 0D;
			// 
			// btStop
			// 
			this.btStop.Location = new System.Drawing.Point(238, 137);
			this.btStop.Name = "btStop";
			this.btStop.Size = new System.Drawing.Size(123, 23);
			this.btStop.TabIndex = 7;
			this.btStop.Text = "Dừng";
			this.btStop.UseVisualStyleBackColor = true;
			// 
			// btShot
			// 
			this.btShot.Location = new System.Drawing.Point(238, 108);
			this.btShot.Name = "btShot";
			this.btShot.Size = new System.Drawing.Size(123, 23);
			this.btShot.TabIndex = 6;
			this.btShot.Text = "Bắn liên tục";
			this.btShot.UseVisualStyleBackColor = true;
			// 
			// btFix
			// 
			this.btFix.Location = new System.Drawing.Point(238, 79);
			this.btFix.Name = "btFix";
			this.btFix.Size = new System.Drawing.Size(123, 23);
			this.btFix.TabIndex = 5;
			this.btFix.Text = "Giá trị cố định";
			this.btFix.UseVisualStyleBackColor = true;
			// 
			// btDec
			// 
			this.btDec.Location = new System.Drawing.Point(238, 50);
			this.btDec.Name = "btDec";
			this.btDec.Size = new System.Drawing.Size(123, 23);
			this.btDec.TabIndex = 4;
			this.btDec.Text = "Giảm tự động";
			this.btDec.UseVisualStyleBackColor = true;
			// 
			// btInc
			// 
			this.btInc.Location = new System.Drawing.Point(238, 21);
			this.btInc.Name = "btInc";
			this.btInc.Size = new System.Drawing.Size(123, 23);
			this.btInc.TabIndex = 3;
			this.btInc.Text = "Tăng tự động";
			this.btInc.UseVisualStyleBackColor = true;
			// 
			// btCancel
			// 
			this.btCancel.Location = new System.Drawing.Point(238, 194);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(123, 38);
			this.btCancel.TabIndex = 8;
			this.btCancel.Text = "Thoát";
			this.btCancel.UseVisualStyleBackColor = true;
			// 
			// frmTestCom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 244);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btInc);
			this.Controls.Add(this.btDec);
			this.Controls.Add(this.btFix);
			this.Controls.Add(this.btShot);
			this.Controls.Add(this.btStop);
			this.Controls.Add(this.numValue);
			this.Controls.Add(this.rsLabel3);
			this.Controls.Add(this.rsLabel2);
			this.Controls.Add(this.numInt);
			this.Controls.Add(this.rsLabel1);
			this.Controls.Add(this.numDelay);
			this.Name = "frmTestCom";
			this.Text = "frmTestCom";
			((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numInt)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsNumericUpdown numDelay;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsNumericUpdown numInt;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBoxNumber numValue;
		private RosySystem.Control.rsButton btStop;
		private RosySystem.Control.rsButton btShot;
		private RosySystem.Control.rsButton btFix;
		private RosySystem.Control.rsButton btDec;
		private RosySystem.Control.rsButton btInc;
		private RosySystem.Control.rsButton btCancel;
		private System.Windows.Forms.Timer timer1;
	}
}