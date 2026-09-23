namespace RosyModule.ScaleBarcode
{
    partial class frmBarcodeLe_Edit
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
            this.numNum_Bars = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel14 = new RosySystem.Control.rsLabel();
            this.txtBarcode = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.numSo_Luong = new RosySystem.Control.rsNumericUpdown();
            this.txtSo_Ct_LXH = new RosySystem.Control.rsTextBox();
            this.btInherit = new RosySystem.Control.rsButton();
            ((System.ComponentModel.ISupportInitialize)(this.numNum_Bars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSo_Luong)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(368, 159);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(5);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(240, 55);
            this.btgAccept.TabIndex = 19;
            // 
            // numNum_Bars
            // 
            this.numNum_Bars.Location = new System.Drawing.Point(198, 98);
            this.numNum_Bars.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numNum_Bars.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNum_Bars.Name = "numNum_Bars";
            this.numNum_Bars.Size = new System.Drawing.Size(137, 22);
            this.numNum_Bars.TabIndex = 12;
            this.numNum_Bars.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel14
            // 
            this.rsLabel14.AutoEllipsis = true;
            this.rsLabel14.AutoSize = true;
            this.rsLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel14.Location = new System.Drawing.Point(39, 99);
            this.rsLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel14.Name = "rsLabel14";
            this.rsLabel14.Size = new System.Drawing.Size(83, 20);
            this.rsLabel14.TabIndex = 39;
            this.rsLabel14.Text = "Số thanh";
            this.rsLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoDropDown = null;
            this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(199, 21);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(361, 36);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(40, 28);
            this.rsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(79, 20);
            this.rsLabel1.TabIndex = 45;
            this.rsLabel1.Text = "Barcode";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(39, 125);
            this.rsLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(97, 20);
            this.rsLabel3.TabIndex = 47;
            this.rsLabel3.Text = "Khối lượng";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.Location = new System.Drawing.Point(198, 125);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numSo_Luong.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Size = new System.Drawing.Size(137, 22);
            this.numSo_Luong.TabIndex = 14;
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSo_Ct_LXH
            // 
            this.txtSo_Ct_LXH.AutoDropDown = null;
            this.txtSo_Ct_LXH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct_LXH.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo_Ct_LXH.Location = new System.Drawing.Point(199, 59);
            this.txtSo_Ct_LXH.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtSo_Ct_LXH.Name = "txtSo_Ct_LXH";
            this.txtSo_Ct_LXH.ReadOnly = true;
            this.txtSo_Ct_LXH.Size = new System.Drawing.Size(284, 36);
            this.txtSo_Ct_LXH.TabIndex = 0;
            this.txtSo_Ct_LXH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btInherit
            // 
            this.btInherit.Location = new System.Drawing.Point(490, 63);
            this.btInherit.Margin = new System.Windows.Forms.Padding(4);
            this.btInherit.Name = "btInherit";
            this.btInherit.Size = new System.Drawing.Size(100, 28);
            this.btInherit.TabIndex = 48;
            this.btInherit.Tag = "";
            this.btInherit.Text = "&Kế thừa LXH";
            this.btInherit.UseVisualStyleBackColor = true;
            // 
            // frmBarcodeLe_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 230);
            this.Controls.Add(this.btInherit);
            this.Controls.Add(this.numSo_Luong);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.txtSo_Ct_LXH);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.numNum_Bars);
            this.Controls.Add(this.rsLabel14);
            this.Controls.Add(this.btgAccept);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBarcodeLe_Edit";
            this.Tag = "frmDmBarcodeLe,ESC";
            this.Text = "frmDmBarcodeLe_Edit";
            ((System.ComponentModel.ISupportInitialize)(this.numNum_Bars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSo_Luong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsNumericUpdown numNum_Bars;
        private RosySystem.Control.rsLabel rsLabel14;
		private RosySystem.Control.rsTextBox txtBarcode;
        private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsNumericUpdown numSo_Luong;
        private RosySystem.Control.rsTextBox txtSo_Ct_LXH;
        private RosySystem.Control.rsButton btInherit;
	}
}