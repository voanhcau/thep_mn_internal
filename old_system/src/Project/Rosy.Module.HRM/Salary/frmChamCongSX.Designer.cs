namespace RosyModule.Salary
{
    partial class frmChamCongSX
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboLoai_CC = new RosySystem.Control.rsMultiComboBox();
            this.lblGiam_Doc_Duyet = new RosySystem.Control.rsLabel();
            this.panel_Lich = new System.Windows.Forms.Panel();
            this.dteNgay_Ap = new RosySystem.Control.rsDateTime();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.cboMa_Bp_Ct = new RosySystem.Control.rsMultiComboBox();
            this.lbtTen_Bp_Ct = new RosySystem.Control.rsLabelName();
            this.cboMa_Bp = new RosySystem.Control.rsMultiComboBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.btThoat = new RosySystem.Control.rsButton();
            this.btSave = new RosySystem.Control.rsButton();
            this.btRe = new RosySystem.Control.rsButton();
            this.btAdd = new RosySystem.Control.rsButton();
            this.panel_ADD = new System.Windows.Forms.Panel();
            this.panel_REC = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboLoai_CC);
            this.splitContainer1.Panel1.Controls.Add(this.lblGiam_Doc_Duyet);
            this.splitContainer1.Panel1.Controls.Add(this.panel_Lich);
            this.splitContainer1.Panel1.Controls.Add(this.dteNgay_Ap);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.cboMa_Bp_Ct);
            this.splitContainer1.Panel1.Controls.Add(this.lbtTen_Bp_Ct);
            this.splitContainer1.Panel1.Controls.Add(this.cboMa_Bp);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.lbtTen_Bp);
            this.splitContainer1.Panel1.Controls.Add(this.lblTk);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btThoat);
            this.splitContainer1.Panel2.Controls.Add(this.btSave);
            this.splitContainer1.Panel2.Controls.Add(this.btRe);
            this.splitContainer1.Panel2.Controls.Add(this.btAdd);
            this.splitContainer1.Panel2.Controls.Add(this.panel_ADD);
            this.splitContainer1.Panel2.Controls.Add(this.panel_REC);
            this.splitContainer1.Size = new System.Drawing.Size(1243, 683);
            this.splitContainer1.SplitterDistance = 136;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // cboLoai_CC
            // 
            this.cboLoai_CC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLoai_CC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboLoai_CC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLoai_CC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoai_CC.Location = new System.Drawing.Point(110, 77);
            this.cboLoai_CC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboLoai_CC.MaxLength = 20;
            this.cboLoai_CC.Name = "cboLoai_CC";
            this.cboLoai_CC.Size = new System.Drawing.Size(87, 21);
            this.cboLoai_CC.TabIndex = 79;
            this.cboLoai_CC.Text = "HC";
            // 
            // lblGiam_Doc_Duyet
            // 
            this.lblGiam_Doc_Duyet.AutoEllipsis = true;
            this.lblGiam_Doc_Duyet.AutoSize = true;
            this.lblGiam_Doc_Duyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiam_Doc_Duyet.Location = new System.Drawing.Point(12, 77);
            this.lblGiam_Doc_Duyet.Name = "lblGiam_Doc_Duyet";
            this.lblGiam_Doc_Duyet.Size = new System.Drawing.Size(97, 13);
            this.lblGiam_Doc_Duyet.TabIndex = 77;
            this.lblGiam_Doc_Duyet.Text = "Loại chấm công";
            this.lblGiam_Doc_Duyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_Lich
            // 
            this.panel_Lich.Location = new System.Drawing.Point(202, 3);
            this.panel_Lich.Name = "panel_Lich";
            this.panel_Lich.Size = new System.Drawing.Size(1038, 130);
            this.panel_Lich.TabIndex = 78;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = false;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(110, 53);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(87, 22);
            this.dteNgay_Ap.TabIndex = 72;
            this.dteNgay_Ap.Text = "00002019";
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.Location = new System.Drawing.Point(12, 56);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(54, 13);
            this.rsLabel3.TabIndex = 74;
            this.rsLabel3.Text = "Ngày áp";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_Bp_Ct
            // 
            this.cboMa_Bp_Ct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp_Ct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp_Ct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp_Ct.Location = new System.Drawing.Point(110, 30);
            this.cboMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp_Ct.MaxLength = 20;
            this.cboMa_Bp_Ct.Name = "cboMa_Bp_Ct";
            this.cboMa_Bp_Ct.Size = new System.Drawing.Size(87, 21);
            this.cboMa_Bp_Ct.TabIndex = 67;
            // 
            // lbtTen_Bp_Ct
            // 
            this.lbtTen_Bp_Ct.AutoSize = true;
            this.lbtTen_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp_Ct.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp_Ct.Location = new System.Drawing.Point(212, 37);
            this.lbtTen_Bp_Ct.Name = "lbtTen_Bp_Ct";
            this.lbtTen_Bp_Ct.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp_Ct.TabIndex = 70;
            this.lbtTen_Bp_Ct.Tag = "";
            this.lbtTen_Bp_Ct.Text = "Tên Bộ phận";
            this.lbtTen_Bp_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_Bp
            // 
            this.cboMa_Bp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp.Location = new System.Drawing.Point(110, 7);
            this.cboMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp.MaxLength = 20;
            this.cboMa_Bp.Name = "cboMa_Bp";
            this.cboMa_Bp.Size = new System.Drawing.Size(87, 21);
            this.cboMa_Bp.TabIndex = 66;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(12, 33);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(97, 13);
            this.rsLabel1.TabIndex = 71;
            this.rsLabel1.Tag = "Ma_Bp_Ct";
            this.rsLabel1.Text = "Bộ phận chi tiết";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp.Location = new System.Drawing.Point(212, 14);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp.TabIndex = 68;
            this.lbtTen_Bp.Tag = "";
            this.lbtTen_Bp.Text = "Tên Bộ phận";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTk.Location = new System.Drawing.Point(12, 10);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(54, 13);
            this.lblTk.TabIndex = 69;
            this.lblTk.Tag = "Ma_Bp";
            this.lblTk.Text = "Bộ phận";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThoat.ImageKey = "add";
            this.btThoat.Location = new System.Drawing.Point(575, 236);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(83, 53);
            this.btThoat.TabIndex = 69;
            this.btThoat.Tag = "";
            this.btThoat.Text = "&Thoát";
            this.btThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btThoat.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageKey = "add";
            this.btSave.Location = new System.Drawing.Point(575, 187);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(83, 47);
            this.btSave.TabIndex = 69;
            this.btSave.Tag = "";
            this.btSave.Text = "&Lưu";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btRe
            // 
            this.btRe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btRe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRe.ImageKey = "add";
            this.btRe.Location = new System.Drawing.Point(575, 136);
            this.btRe.Name = "btRe";
            this.btRe.Size = new System.Drawing.Size(83, 49);
            this.btRe.TabIndex = 68;
            this.btRe.Tag = "";
            this.btRe.Text = "<<";
            this.btRe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRe.UseVisualStyleBackColor = true;
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAdd.ImageKey = "add";
            this.btAdd.Location = new System.Drawing.Point(575, 86);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(83, 48);
            this.btAdd.TabIndex = 68;
            this.btAdd.Tag = "";
            this.btAdd.Text = ">>";
            this.btAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // panel_ADD
            // 
            this.panel_ADD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_ADD.Location = new System.Drawing.Point(3, 3);
            this.panel_ADD.Name = "panel_ADD";
            this.panel_ADD.Size = new System.Drawing.Size(566, 542);
            this.panel_ADD.TabIndex = 0;
            // 
            // panel_REC
            // 
            this.panel_REC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_REC.Location = new System.Drawing.Point(664, 3);
            this.panel_REC.Name = "panel_REC";
            this.panel_REC.Size = new System.Drawing.Size(576, 542);
            this.panel_REC.TabIndex = 0;
            // 
            // frmChamCongSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1243, 683);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmChamCongSX";
            this.Text = "frmChamCongSX";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel_ADD;
        private System.Windows.Forms.Panel panel_REC;
        private RosySystem.Control.rsMultiComboBox cboMa_Bp_Ct;
        private RosySystem.Control.rsLabelName lbtTen_Bp_Ct;
        private RosySystem.Control.rsMultiComboBox cboMa_Bp;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabelName lbtTen_Bp;
        private RosySystem.Control.rsLabel lblTk;
        private RosySystem.Control.rsButton btThoat;
        private RosySystem.Control.rsButton btSave;
        private RosySystem.Control.rsButton btRe;
        private RosySystem.Control.rsButton btAdd;
        private RosySystem.Control.rsDateTime dteNgay_Ap;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel lblGiam_Doc_Duyet;
        private System.Windows.Forms.Panel panel_Lich;
        private RosySystem.Control.rsMultiComboBox cboLoai_CC;
	}
}