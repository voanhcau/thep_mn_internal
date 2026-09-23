namespace RosyModule.Receivable
{
    partial class frmBBDCHD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.btNew = new RosySystem.Control.rsButton();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.btEdit = new RosySystem.Control.rsButton();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.btSave = new RosySystem.Control.rsButton();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.lbtRecorde = new RosySystem.Control.rsLabelName();
            this.btLast = new RosySystem.Customize.btPrint();
            this.btNext = new RosySystem.Customize.btPrint();
            this.btPrevious = new RosySystem.Customize.btPrint();
            this.btFirst = new RosySystem.Customize.btPrint();
            this.dteNgay_Ct_Bb = new RosySystem.Control.rsDateTime();
            this.label1 = new RosySystem.Control.rsLabel();
            this.txtSo_Ct_Bb = new RosySystem.Control.rsTextBox();
            this.txtMa_Dt = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt = new RosySystem.Control.rsLabel();
            this.btLoc = new RosySystem.Control.rsButton();
            this.rsButton2 = new RosySystem.Control.rsButton();
            this.btPrint = new RosySystem.Control.rsButton();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.dgvDmDt = new RosySystem.Control.rsDataGridView();
            this.groupBox1.SuspendLayout();
            this.rsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmDt)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dteNgay_Ct2);
            this.groupBox1.Controls.Add(this.dteNgay_Ct1);
            this.groupBox1.Controls.Add(this.btNew);
            this.groupBox1.Controls.Add(this.rsLabel3);
            this.groupBox1.Controls.Add(this.btEdit);
            this.groupBox1.Controls.Add(this.rsLabel4);
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.rsPanel1);
            this.groupBox1.Controls.Add(this.dteNgay_Ct_Bb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSo_Ct_Bb);
            this.groupBox1.Controls.Add(this.txtMa_Dt);
            this.groupBox1.Controls.Add(this.lbtTen_Dt);
            this.groupBox1.Controls.Add(this.btLoc);
            this.groupBox1.Controls.Add(this.rsButton2);
            this.groupBox1.Controls.Add(this.btPrint);
            this.groupBox1.Controls.Add(this.rsLabel1);
            this.groupBox1.Controls.Add(this.rsLabel2);
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1168, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin biên bản";
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(198, 100);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 19;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(71, 100);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct1.TabIndex = 18;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btNew.Location = new System.Drawing.Point(283, 125);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(97, 23);
            this.btNew.TabIndex = 4;
            this.btNew.Tag = "New";
            this.btNew.Text = "Thêm";
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(140, 103);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(53, 13);
            this.rsLabel3.TabIndex = 16;
            this.rsLabel3.Tag = "Ngay_Ct2";
            this.rsLabel3.Text = "Đến ngày";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btEdit.Location = new System.Drawing.Point(386, 124);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(97, 23);
            this.btEdit.TabIndex = 4;
            this.btEdit.Tag = "";
            this.btEdit.Text = "Sửa";
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(20, 103);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(46, 13);
            this.rsLabel4.TabIndex = 17;
            this.rsLabel4.Tag = "Ngay_Ct1";
            this.rsLabel4.Text = "Từ ngày";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSave.Location = new System.Drawing.Point(489, 125);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(97, 23);
            this.btSave.TabIndex = 4;
            this.btSave.Tag = "";
            this.btSave.Text = "Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Controls.Add(this.lbtRecorde);
            this.rsPanel1.Controls.Add(this.btLast);
            this.rsPanel1.Controls.Add(this.btNext);
            this.rsPanel1.Controls.Add(this.btPrevious);
            this.rsPanel1.Controls.Add(this.btFirst);
            this.rsPanel1.Location = new System.Drawing.Point(17, 122);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(260, 29);
            this.rsPanel1.TabIndex = 15;
            // 
            // lbtRecorde
            // 
            this.lbtRecorde.AutoEllipsis = true;
            this.lbtRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtRecorde.ForeColor = System.Drawing.Color.Red;
            this.lbtRecorde.Location = new System.Drawing.Point(99, 4);
            this.lbtRecorde.Name = "lbtRecorde";
            this.lbtRecorde.Size = new System.Drawing.Size(60, 20);
            this.lbtRecorde.TabIndex = 2;
            this.lbtRecorde.Text = "0/0";
            this.lbtRecorde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btLast
            // 
            this.btLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLast.ImageKey = "(none)";
            this.btLast.Location = new System.Drawing.Point(212, 3);
            this.btLast.Name = "btLast";
            this.btLast.Size = new System.Drawing.Size(45, 23);
            this.btLast.TabIndex = 4;
            this.btLast.Tag = "";
            this.btLast.Text = ">>||";
            this.btLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLast.UseVisualStyleBackColor = true;
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNext.ImageKey = "(none)";
            this.btNext.Location = new System.Drawing.Point(161, 3);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(45, 23);
            this.btNext.TabIndex = 3;
            this.btNext.Tag = "";
            this.btNext.Text = ">>";
            this.btNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNext.UseVisualStyleBackColor = true;
            // 
            // btPrevious
            // 
            this.btPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrevious.ImageKey = "(none)";
            this.btPrevious.Location = new System.Drawing.Point(54, 3);
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.Size = new System.Drawing.Size(45, 23);
            this.btPrevious.TabIndex = 1;
            this.btPrevious.Tag = "";
            this.btPrevious.Text = "<<";
            this.btPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrevious.UseVisualStyleBackColor = true;
            // 
            // btFirst
            // 
            this.btFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.btFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFirst.ImageKey = "(none)";
            this.btFirst.Location = new System.Drawing.Point(3, 3);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(45, 23);
            this.btFirst.TabIndex = 0;
            this.btFirst.Tag = "";
            this.btFirst.Text = "||<<";
            this.btFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFirst.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Ct_Bb
            // 
            this.dteNgay_Ct_Bb.bAllowEmpty = true;
            this.dteNgay_Ct_Bb.bSelectOnFocus = false;
            this.dteNgay_Ct_Bb.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct_Bb.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct_Bb.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct_Bb.Location = new System.Drawing.Point(103, 60);
            this.dteNgay_Ct_Bb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct_Bb.Mask = "00/00/0000";
            this.dteNgay_Ct_Bb.Name = "dteNgay_Ct_Bb";
            this.dteNgay_Ct_Bb.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct_Bb.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 13;
            this.label1.Tag = "";
            this.label1.Text = "Ngày biên bản";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct_Bb
            // 
            this.txtSo_Ct_Bb.AutoDropDown = null;
            this.txtSo_Ct_Bb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct_Bb.Location = new System.Drawing.Point(103, 38);
            this.txtSo_Ct_Bb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct_Bb.MaxLength = 20;
            this.txtSo_Ct_Bb.Name = "txtSo_Ct_Bb";
            this.txtSo_Ct_Bb.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Ct_Bb.TabIndex = 8;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.AutoDropDown = null;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.Location = new System.Drawing.Point(103, 16);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.MaxLength = 20;
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 8;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(228, 20);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(74, 13);
            this.lbtTen_Dt.TabIndex = 7;
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btLoc
            // 
            this.btLoc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btLoc.Location = new System.Drawing.Point(269, 100);
            this.btLoc.Name = "btLoc";
            this.btLoc.Size = new System.Drawing.Size(67, 23);
            this.btLoc.TabIndex = 4;
            this.btLoc.Tag = "";
            this.btLoc.Text = "Lọc";
            this.btLoc.UseVisualStyleBackColor = true;
            // 
            // rsButton2
            // 
            this.rsButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rsButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rsButton2.Location = new System.Drawing.Point(962, 71);
            this.rsButton2.Name = "rsButton2";
            this.rsButton2.Size = new System.Drawing.Size(97, 42);
            this.rsButton2.TabIndex = 3;
            this.rsButton2.Tag = "";
            this.rsButton2.Text = "In biên bản xác nhận";
            this.rsButton2.UseVisualStyleBackColor = true;
            //this.rsButton2.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPrint.Location = new System.Drawing.Point(1065, 71);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(97, 42);
            this.btPrint.TabIndex = 3;
            this.btPrint.Tag = "";
            this.btPrint.Text = "In biên bản điều chỉnh";
            this.btPrint.UseVisualStyleBackColor = true;
            //this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(19, 41);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(64, 13);
            this.rsLabel1.TabIndex = 1;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Số biên bản";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(19, 19);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(82, 13);
            this.rsLabel2.TabIndex = 1;
            this.rsLabel2.Tag = "Ma_Dt";
            this.rsLabel2.Text = "Mã khách hàng";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDmDt
            // 
            this.dgvDmDt.AllowUserToAddRows = false;
            this.dgvDmDt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDmDt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDmDt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDmDt.BackgroundColor = System.Drawing.Color.White;
            this.dgvDmDt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDmDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDmDt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDmDt.Location = new System.Drawing.Point(9, 181);
            this.dgvDmDt.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDmDt.MultiSelect = false;
            this.dgvDmDt.Name = "dgvDmDt";
            this.dgvDmDt.ReadOnly = true;
            this.dgvDmDt.Size = new System.Drawing.Size(1168, 339);
            this.dgvDmDt.strZone = "";
            this.dgvDmDt.TabIndex = 1;
            // 
            // frmBBDCHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btPrint;
            this.ClientSize = new System.Drawing.Size(1186, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDmDt);
            this.Name = "frmBBDCHD";
            this.Text = "frmBBDCHD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.rsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmDt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvDmDt;
        private System.Windows.Forms.GroupBox groupBox1;
        private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsButton btPrint;
        private RosySystem.Control.rsButton btSave;
        private RosySystem.Control.rsTextBox txtMa_Dt;
        private RosySystem.Control.rsLabel lbtTen_Dt;
        private RosySystem.Control.rsButton btLoc;
        private RosySystem.Control.rsButton rsButton2;
        private RosySystem.Control.rsTextBox txtSo_Ct_Bb;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsDateTime dteNgay_Ct_Bb;
        private RosySystem.Control.rsLabel label1;
        private RosySystem.Control.rsButton btEdit;
        private RosySystem.Control.rsButton btNew;
        private RosySystem.Control.rsPanel rsPanel1;
        private RosySystem.Control.rsLabelName lbtRecorde;
        private RosySystem.Customize.btPrint btLast;
        private RosySystem.Customize.btPrint btNext;
        private RosySystem.Customize.btPrint btPrevious;
        private RosySystem.Customize.btPrint btFirst;
        private RosySystem.Control.rsDateTime dteNgay_Ct2;
        private RosySystem.Control.rsDateTime dteNgay_Ct1;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel4;
	}
}