namespace RosyModule.Salary
{
    partial class frmLuongTT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLuongTT));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboMa_Bp = new RosySystem.Control.rsMultiComboBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
            this.btSua = new RosySystem.Control.rsButton();
            this.btThem = new RosySystem.Control.rsButton();
            this.btSL_NV = new RosySystem.Control.rsButton();
            this.btDuyet = new RosySystem.Control.rsButton();
            this.cboMa_Bp_Ct = new RosySystem.Control.rsMultiComboBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(3, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 446);
            this.panel1.TabIndex = 2;
            // 
            // cboMa_Bp
            // 
            this.cboMa_Bp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp.Location = new System.Drawing.Point(79, 6);
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
            this.lblTk.Location = new System.Drawing.Point(9, 9);
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
            this.lbtTen_Bp.Location = new System.Drawing.Point(201, 8);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp.TabIndex = 65;
            this.lbtTen_Bp.Tag = "";
            this.lbtTen_Bp.Text = "Tên Bộ phận";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSua.ImageKey = "add";
            this.btSua.Location = new System.Drawing.Point(103, 514);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(97, 47);
            this.btSua.TabIndex = 3;
            this.btSua.Tag = "";
            this.btSua.Text = "&Sửa thông tin";
            this.btSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSua.UseVisualStyleBackColor = true;
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThem.ImageKey = "add";
            this.btThem.ImageList = this.imageList1;
            this.btThem.Location = new System.Drawing.Point(3, 513);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(97, 47);
            this.btThem.TabIndex = 3;
            this.btThem.Tag = "";
            this.btThem.Text = "Chuyển vị trí";
            this.btThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btThem.UseVisualStyleBackColor = true;
            // 
            // btSL_NV
            // 
            this.btSL_NV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSL_NV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSL_NV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSL_NV.ImageKey = "add";
            this.btSL_NV.Location = new System.Drawing.Point(301, 514);
            this.btSL_NV.Name = "btSL_NV";
            this.btSL_NV.Size = new System.Drawing.Size(97, 47);
            this.btSL_NV.TabIndex = 3;
            this.btSL_NV.Tag = "";
            this.btSL_NV.Text = "&Xem định biên LĐ";
            this.btSL_NV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSL_NV.UseVisualStyleBackColor = true;
            // 
            // btDuyet
            // 
            this.btDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDuyet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDuyet.ImageKey = "add";
            this.btDuyet.Location = new System.Drawing.Point(202, 514);
            this.btDuyet.Name = "btDuyet";
            this.btDuyet.Size = new System.Drawing.Size(97, 47);
            this.btDuyet.TabIndex = 3;
            this.btDuyet.Tag = "";
            this.btDuyet.Text = "&Duyệt lương vị trí";
            this.btDuyet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDuyet.UseVisualStyleBackColor = true;
            // 
            // cboMa_Bp_Ct
            // 
            this.cboMa_Bp_Ct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp_Ct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp_Ct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp_Ct.Location = new System.Drawing.Point(79, 29);
            this.cboMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp_Ct.MaxLength = 20;
            this.cboMa_Bp_Ct.Name = "cboMa_Bp_Ct";
            this.cboMa_Bp_Ct.Size = new System.Drawing.Size(116, 21);
            this.cboMa_Bp_Ct.TabIndex = 66;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(9, 32);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(54, 13);
            this.rsLabel1.TabIndex = 67;
            this.rsLabel1.Tag = "Ma_Bp_Ct";
            this.rsLabel1.Text = "Bộ phận";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmLuongTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.cboMa_Bp_Ct);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.cboMa_Bp);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btDuyet);
            this.Controls.Add(this.btSL_NV);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThem);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmLuongTT";
            this.Object_ID = "LUONGTT";
            this.Text = "frmLuongTT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Panel panel1;
		private RosySystem.Control.rsMultiComboBox cboMa_Bp;
		private RosySystem.Control.rsLabel lblTk;
        private RosySystem.Control.rsLabelName lbtTen_Bp;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Control.rsButton btSua;
        private RosySystem.Control.rsButton btThem;
        private RosySystem.Control.rsButton btSL_NV;
        private RosySystem.Control.rsButton btDuyet;
        private RosySystem.Control.rsMultiComboBox cboMa_Bp_Ct;
        private RosySystem.Control.rsLabel rsLabel1;
	}
}