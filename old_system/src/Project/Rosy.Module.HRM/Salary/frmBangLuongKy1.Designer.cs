namespace RosyModule.Salary
{
    partial class frmBangLuongKy1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangLuongKy1));
            this.btUpdate = new RosySystem.Control.rsButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCreateSalary = new RosySystem.Control.rsButton();
            this.cboMa_Bp = new RosySystem.Control.rsMultiComboBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
            this.cboThang = new RosySystem.Control.rsComboBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp_Ct = new RosySystem.Control.rsLabelName();
            this.cboMa_Bp_Ct = new RosySystem.Control.rsMultiComboBox();
            this.btPrint = new RosySystem.Control.rsButton();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.btXoa = new RosySystem.Control.rsButton();
            this.chkLuuCty = new RosySystem.Control.rsCheckbox();
            this.SuspendLayout();
            // 
            // btUpdate
            // 
            this.btUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpdate.ImageKey = "calc";
            this.btUpdate.ImageList = this.imageList1;
            this.btUpdate.Location = new System.Drawing.Point(198, 513);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(97, 47);
            this.btUpdate.TabIndex = 4;
            this.btUpdate.Tag = "";
            this.btUpdate.Text = "Xác nhận lương ứng";
            this.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "posted");
            this.imageList1.Images.SetKeyName(1, "delete");
            this.imageList1.Images.SetKeyName(2, "calc");
            this.imageList1.Images.SetKeyName(3, "add");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Tag = "Thang";
            this.label1.Text = "Tháng";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(3, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 408);
            this.panel1.TabIndex = 2;
            // 
            // btCreateSalary
            // 
            this.btCreateSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreateSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreateSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCreateSalary.ImageKey = "add";
            this.btCreateSalary.ImageList = this.imageList1;
            this.btCreateSalary.Location = new System.Drawing.Point(3, 513);
            this.btCreateSalary.Name = "btCreateSalary";
            this.btCreateSalary.Size = new System.Drawing.Size(97, 47);
            this.btCreateSalary.TabIndex = 3;
            this.btCreateSalary.Tag = "Tao_Bang_Luong";
            this.btCreateSalary.Text = "&Tạo bảng lương";
            this.btCreateSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCreateSalary.UseVisualStyleBackColor = true;
            // 
            // cboMa_Bp
            // 
            this.cboMa_Bp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp.Location = new System.Drawing.Point(103, 28);
            this.cboMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp.MaxLength = 20;
            this.cboMa_Bp.Name = "cboMa_Bp";
            this.cboMa_Bp.Size = new System.Drawing.Size(116, 21);
            this.cboMa_Bp.TabIndex = 1;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTk.Location = new System.Drawing.Point(5, 31);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(54, 13);
            this.lblTk.TabIndex = 65;
            this.lblTk.Tag = "Ma_Bp";
            this.lblTk.Text = "Bộ phận";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp.Location = new System.Drawing.Point(224, 33);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp.TabIndex = 65;
            this.lbtTen_Bp.Tag = "";
            this.lbtTen_Bp.Text = "Tên Bộ phận";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(103, 5);
            this.cboThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(51, 21);
            this.cboThang.TabIndex = 66;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(5, 54);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(97, 13);
            this.rsLabel1.TabIndex = 65;
            this.rsLabel1.Tag = "Ma_Bp_Ct";
            this.rsLabel1.Text = "Bộ phận chi tiết";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp_Ct
            // 
            this.lbtTen_Bp_Ct.AutoSize = true;
            this.lbtTen_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp_Ct.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp_Ct.Location = new System.Drawing.Point(224, 56);
            this.lbtTen_Bp_Ct.Name = "lbtTen_Bp_Ct";
            this.lbtTen_Bp_Ct.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp_Ct.TabIndex = 65;
            this.lbtTen_Bp_Ct.Tag = "";
            this.lbtTen_Bp_Ct.Text = "Tên Bộ phận";
            this.lbtTen_Bp_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_Bp_Ct
            // 
            this.cboMa_Bp_Ct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp_Ct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp_Ct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp_Ct.Location = new System.Drawing.Point(103, 51);
            this.cboMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp_Ct.MaxLength = 20;
            this.cboMa_Bp_Ct.Name = "cboMa_Bp_Ct";
            this.cboMa_Bp_Ct.Size = new System.Drawing.Size(116, 21);
            this.cboMa_Bp_Ct.TabIndex = 1;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "calc";
            this.btPrint.Location = new System.Drawing.Point(395, 513);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(97, 47);
            this.btPrint.TabIndex = 4;
            this.btPrint.Tag = "";
            this.btPrint.Text = "In";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "calc";
            this.btRefresh.Location = new System.Drawing.Point(100, 513);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(97, 47);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btXoa
            // 
            this.btXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXoa.ImageKey = "calc";
            this.btXoa.Location = new System.Drawing.Point(296, 513);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(97, 47);
            this.btXoa.TabIndex = 4;
            this.btXoa.Tag = "";
            this.btXoa.Text = "Xóa bảng lương";
            this.btXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btXoa.UseVisualStyleBackColor = true;
            // 
            // chkLuuCty
            // 
            this.chkLuuCty.AutoSize = true;
            this.chkLuuCty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLuuCty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkLuuCty.Location = new System.Drawing.Point(8, 75);
            this.chkLuuCty.Name = "chkLuuCty";
            this.chkLuuCty.Size = new System.Drawing.Size(104, 19);
            this.chkLuuCty.TabIndex = 122;
            this.chkLuuCty.Text = "Bảng lưu cty";
            this.chkLuuCty.UseVisualStyleBackColor = true;
            // 
            // frmBangLuongKy1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.chkLuuCty);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.cboMa_Bp_Ct);
            this.Controls.Add(this.lbtTen_Bp_Ct);
            this.Controls.Add(this.cboMa_Bp);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCreateSalary);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btUpdate);
            this.Name = "frmBangLuongKy1";
            this.Text = "frmBangLuongKy1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsButton btUpdate;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
		private RosySystem.Control.rsButton btCreateSalary;
		private RosySystem.Control.rsMultiComboBox cboMa_Bp;
		private RosySystem.Control.rsLabel lblTk;
        private RosySystem.Control.rsLabelName lbtTen_Bp;
		private RosySystem.Control.rsComboBox cboThang;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabelName lbtTen_Bp_Ct;
        private RosySystem.Control.rsMultiComboBox cboMa_Bp_Ct;
        private RosySystem.Control.rsButton btPrint;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsButton btXoa;
        public RosySystem.Control.rsCheckbox chkLuuCty;
	}
}