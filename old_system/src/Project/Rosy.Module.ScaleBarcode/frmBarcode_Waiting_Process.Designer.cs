namespace RosyModule.ScaleBarcode
{
	partial class frmBarcode_Waiting_Process
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
            this.txtRemark_KCS = new RosySystem.Control.rsTextBox();
            this.lbTen_Kv = new RosySystem.Control.rsLabel();
            this.txtBarcode = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rdbIs_Not_OutPut = new RosySystem.Control.rsRadioButton();
            this.rdbIs_OutPut = new RosySystem.Control.rsRadioButton();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.dteDate_Process = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dteNgay_XLNTL = new RosySystem.Control.rsDateTime();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(320, 161);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 43);
            this.btgAccept.TabIndex = 4;
            // 
            // txtRemark_KCS
            // 
            this.txtRemark_KCS.AutoDropDown = null;
            this.txtRemark_KCS.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemark_KCS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemark_KCS.Location = new System.Drawing.Point(116, 100);
            this.txtRemark_KCS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtRemark_KCS.MinimumSize = new System.Drawing.Size(87, 20);
            this.txtRemark_KCS.Name = "txtRemark_KCS";
            this.txtRemark_KCS.Size = new System.Drawing.Size(349, 20);
            this.txtRemark_KCS.TabIndex = 2;
            // 
            // lbTen_Kv
            // 
            this.lbTen_Kv.AutoEllipsis = true;
            this.lbTen_Kv.AutoSize = true;
            this.lbTen_Kv.Location = new System.Drawing.Point(24, 103);
            this.lbTen_Kv.Name = "lbTen_Kv";
            this.lbTen_Kv.Size = new System.Drawing.Size(44, 13);
            this.lbTen_Kv.TabIndex = 47;
            this.lbTen_Kv.Tag = "";
            this.lbTen_Kv.Text = "Ghi chú";
            this.lbTen_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoDropDown = null;
            this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Red;
            this.txtBarcode.Location = new System.Drawing.Point(116, 20);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(211, 32);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(24, 35);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(44, 13);
            this.rsLabel1.TabIndex = 50;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Bó thép";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbIs_Not_OutPut
            // 
            this.rdbIs_Not_OutPut.AutoSize = true;
            this.rdbIs_Not_OutPut.Checked = true;
            this.rdbIs_Not_OutPut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbIs_Not_OutPut.ForeColor = System.Drawing.Color.Red;
            this.rdbIs_Not_OutPut.Location = new System.Drawing.Point(116, 57);
            this.rdbIs_Not_OutPut.Name = "rdbIs_Not_OutPut";
            this.rdbIs_Not_OutPut.Size = new System.Drawing.Size(171, 17);
            this.rdbIs_Not_OutPut.TabIndex = 0;
            this.rdbIs_Not_OutPut.TabStop = true;
            this.rdbIs_Not_OutPut.Text = "Không cho phép xuất kho";
            this.rdbIs_Not_OutPut.UnChecked = false;
            this.rdbIs_Not_OutPut.UseVisualStyleBackColor = true;
            // 
            // rdbIs_OutPut
            // 
            this.rdbIs_OutPut.AutoSize = true;
            this.rdbIs_OutPut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbIs_OutPut.ForeColor = System.Drawing.Color.Blue;
            this.rdbIs_OutPut.Location = new System.Drawing.Point(116, 80);
            this.rdbIs_OutPut.Name = "rdbIs_OutPut";
            this.rdbIs_OutPut.Size = new System.Drawing.Size(132, 17);
            this.rdbIs_OutPut.TabIndex = 1;
            this.rdbIs_OutPut.Text = "Cho phép xuất kho";
            this.rdbIs_OutPut.UnChecked = true;
            this.rdbIs_OutPut.UseVisualStyleBackColor = true;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(24, 125);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(56, 13);
            this.lblNgay_Ct.TabIndex = 51;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Ngày xử lý";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteDate_Process
            // 
            this.dteDate_Process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteDate_Process.bAllowEmpty = false;
            this.dteDate_Process.bSelectOnFocus = false;
            this.dteDate_Process.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteDate_Process.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteDate_Process.Enabled = false;
            this.dteDate_Process.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteDate_Process.Location = new System.Drawing.Point(116, 122);
            this.dteDate_Process.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteDate_Process.Mask = "00/00/0000";
            this.dteDate_Process.Name = "dteDate_Process";
            this.dteDate_Process.Size = new System.Drawing.Size(66, 20);
            this.dteDate_Process.TabIndex = 3;
            // 
            // rsLabel2
            // 
            this.rsLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(24, 148);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(87, 13);
            this.rsLabel2.TabIndex = 53;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Ngày nhập trả lại";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_XLNTL
            // 
            this.dteNgay_XLNTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteNgay_XLNTL.bAllowEmpty = false;
            this.dteNgay_XLNTL.bSelectOnFocus = false;
            this.dteNgay_XLNTL.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_XLNTL.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_XLNTL.Enabled = false;
            this.dteNgay_XLNTL.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_XLNTL.Location = new System.Drawing.Point(116, 145);
            this.dteNgay_XLNTL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_XLNTL.Mask = "00/00/0000";
            this.dteNgay_XLNTL.Name = "dteNgay_XLNTL";
            this.dteNgay_XLNTL.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_XLNTL.TabIndex = 52;
            // 
            // frmBarcode_Waiting_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 216);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.dteNgay_XLNTL);
            this.Controls.Add(this.lblNgay_Ct);
            this.Controls.Add(this.dteDate_Process);
            this.Controls.Add(this.rdbIs_OutPut);
            this.Controls.Add(this.rdbIs_Not_OutPut);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.txtRemark_KCS);
            this.Controls.Add(this.lbTen_Kv);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmBarcode_Waiting_Process";
            this.Text = "frmBarcode_Waiting_Process";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtRemark_KCS;
		private RosySystem.Control.rsLabel lbTen_Kv;
		private RosySystem.Control.rsTextBox txtBarcode;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsRadioButton rdbIs_Not_OutPut;
		private RosySystem.Control.rsRadioButton rdbIs_OutPut;
		private RosySystem.Control.rsLabel lblNgay_Ct;
		private RosySystem.Control.rsDateTime dteDate_Process;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsDateTime dteNgay_XLNTL;
	}
}