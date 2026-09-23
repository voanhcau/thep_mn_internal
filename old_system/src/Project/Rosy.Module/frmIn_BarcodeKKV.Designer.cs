namespace RosyModule
{
    partial class frmIn_BarcodeKKV
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
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.gbIn_Tien = new System.Windows.Forms.GroupBox();
            this.btPrint = new RosySystem.Customize.btPrint();
            this.rsLabel28 = new RosySystem.Control.rsLabel();
            this.cboFiles = new RosySystem.Control.rsComboBox();
            this.rdbInCNXX = new RosySystem.Control.rsRadioButton();
            this.rdbPXKKV = new RosySystem.Control.rsRadioButton();
            this.rdbIn_LXH = new RosySystem.Control.rsRadioButton();
            this.rdbPX_Barcode = new RosySystem.Control.rsRadioButton();
            this.btOpen = new RosySystem.Customize.btPrint();
            this.gbIn_Tien.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(569, 190);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 45);
            this.btgAccept.TabIndex = 10;
            // 
            // gbIn_Tien
            // 
            this.gbIn_Tien.Controls.Add(this.btOpen);
            this.gbIn_Tien.Controls.Add(this.btPrint);
            this.gbIn_Tien.Controls.Add(this.rsLabel28);
            this.gbIn_Tien.Controls.Add(this.cboFiles);
            this.gbIn_Tien.Controls.Add(this.rdbInCNXX);
            this.gbIn_Tien.Controls.Add(this.rdbPXKKV);
            this.gbIn_Tien.Controls.Add(this.rdbIn_LXH);
            this.gbIn_Tien.Controls.Add(this.rdbPX_Barcode);
            this.gbIn_Tien.Location = new System.Drawing.Point(21, 12);
            this.gbIn_Tien.Name = "gbIn_Tien";
            this.gbIn_Tien.Size = new System.Drawing.Size(729, 175);
            this.gbIn_Tien.TabIndex = 0;
            this.gbIn_Tien.TabStop = false;
            this.gbIn_Tien.Tag = "";
            this.gbIn_Tien.Text = "Chọn phiếu";
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "(none)";
            this.btPrint.Location = new System.Drawing.Point(589, 131);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(60, 28);
            this.btPrint.TabIndex = 259;
            this.btPrint.Tag = "Print";
            this.btPrint.Text = "&In CNXX";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // rsLabel28
            // 
            this.rsLabel28.AutoEllipsis = true;
            this.rsLabel28.AutoSize = true;
            this.rsLabel28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel28.Location = new System.Drawing.Point(20, 116);
            this.rsLabel28.Name = "rsLabel28";
            this.rsLabel28.Size = new System.Drawing.Size(184, 16);
            this.rsLabel28.TabIndex = 258;
            this.rsLabel28.Text = "Danh sách file CNXX đã ký số";
            this.rsLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFiles
            // 
            this.cboFiles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFiles.DropDownHeight = 147;
            this.cboFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFiles.FormattingEnabled = true;
            this.cboFiles.IntegralHeight = false;
            this.cboFiles.Location = new System.Drawing.Point(16, 137);
            this.cboFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboFiles.Name = "cboFiles";
            this.cboFiles.Size = new System.Drawing.Size(570, 20);
            this.cboFiles.TabIndex = 5;
            // 
            // rdbInCNXX
            // 
            this.rdbInCNXX.AutoSize = true;
            this.rdbInCNXX.Checked = true;
            this.rdbInCNXX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbInCNXX.Location = new System.Drawing.Point(16, 91);
            this.rdbInCNXX.Name = "rdbInCNXX";
            this.rdbInCNXX.Size = new System.Drawing.Size(65, 17);
            this.rdbInCNXX.TabIndex = 4;
            this.rdbInCNXX.TabStop = true;
            this.rdbInCNXX.Tag = "";
            this.rdbInCNXX.Text = "In CNXX";
            this.rdbInCNXX.UnChecked = false;
            this.rdbInCNXX.UseVisualStyleBackColor = true;
            // 
            // rdbPXKKV
            // 
            this.rdbPXKKV.AutoSize = true;
            this.rdbPXKKV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPXKKV.Location = new System.Drawing.Point(16, 68);
            this.rdbPXKKV.Name = "rdbPXKKV";
            this.rdbPXKKV.Size = new System.Drawing.Size(165, 17);
            this.rdbPXKKV.TabIndex = 4;
            this.rdbPXKKV.Tag = "";
            this.rdbPXKKV.Text = "In phiếu xuất kho TP khu vực";
            this.rdbPXKKV.UnChecked = true;
            this.rdbPXKKV.UseVisualStyleBackColor = true;
            // 
            // rdbIn_LXH
            // 
            this.rdbIn_LXH.AutoSize = true;
            this.rdbIn_LXH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbIn_LXH.Location = new System.Drawing.Point(16, 22);
            this.rdbIn_LXH.Name = "rdbIn_LXH";
            this.rdbIn_LXH.Size = new System.Drawing.Size(106, 17);
            this.rdbIn_LXH.TabIndex = 2;
            this.rdbIn_LXH.Tag = "";
            this.rdbIn_LXH.Text = "In lệnh xuất hàng";
            this.rdbIn_LXH.UnChecked = true;
            this.rdbIn_LXH.UseVisualStyleBackColor = true;
            // 
            // rdbPX_Barcode
            // 
            this.rdbPX_Barcode.AutoSize = true;
            this.rdbPX_Barcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPX_Barcode.Location = new System.Drawing.Point(16, 45);
            this.rdbPX_Barcode.Name = "rdbPX_Barcode";
            this.rdbPX_Barcode.Size = new System.Drawing.Size(127, 17);
            this.rdbPX_Barcode.TabIndex = 0;
            this.rdbPX_Barcode.Tag = "";
            this.rdbPX_Barcode.Text = "In phiếu xuất barcode";
            this.rdbPX_Barcode.UnChecked = true;
            this.rdbPX_Barcode.UseVisualStyleBackColor = true;
            // 
            // btOpen
            // 
            this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpen.ImageKey = "(none)";
            this.btOpen.Location = new System.Drawing.Point(649, 131);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(74, 28);
            this.btOpen.TabIndex = 259;
            this.btOpen.Tag = "";
            this.btOpen.Text = "&Open CNXX";
            this.btOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOpen.UseVisualStyleBackColor = true;
            // 
            // frmIn_BarcodeKKV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 247);
            this.Controls.Add(this.gbIn_Tien);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmIn_BarcodeKKV";
            this.Tag = "";
            this.Text = "Chọn phiếu";
            this.gbIn_Tien.ResumeLayout(false);
            this.gbIn_Tien.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btgAccept btgAccept;
        public System.Windows.Forms.GroupBox gbIn_Tien;
        public RosySystem.Control.rsRadioButton rdbIn_LXH;
        public RosySystem.Control.rsRadioButton rdbPX_Barcode;
        public RosySystem.Control.rsRadioButton rdbPXKKV;
        public RosySystem.Control.rsRadioButton rdbInCNXX;
        private RosySystem.Control.rsComboBox cboFiles;
        private RosySystem.Control.rsLabel rsLabel28;
        private RosySystem.Customize.btPrint btPrint;
        private RosySystem.Customize.btPrint btOpen;
    }
}