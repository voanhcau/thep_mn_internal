namespace RosyModule.Salary
{
    partial class frmInBangLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInBangLuong));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cboMa_Bp = new RosySystem.Control.rsMultiComboBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
            this.cboThang = new RosySystem.Control.rsComboBox();
            this.btPrint = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.lbtTen_Dt_CbNv = new RosySystem.Control.rsLabel();
            this.cboMa_Bp_Ct = new RosySystem.Control.rsMultiComboBox();
            this.lbtTen_Bp_Ct = new RosySystem.Control.rsLabelName();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
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
            // btPrint
            // 
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "(none)";
            this.btPrint.ImageList = this.imageList1;
            this.btPrint.Location = new System.Drawing.Point(19, 114);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(97, 47);
            this.btPrint.TabIndex = 67;
            this.btPrint.Tag = "";
            this.btPrint.Text = "Xem";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "add";
            this.btExit.Location = new System.Drawing.Point(122, 114);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(97, 47);
            this.btExit.TabIndex = 67;
            this.btExit.Tag = "";
            this.btExit.Text = "&Thoát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel1.Location = new System.Drawing.Point(5, 85);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(54, 13);
            this.rsLabel1.TabIndex = 65;
            this.rsLabel1.Tag = "Ma_Dt_CbNv";
            this.rsLabel1.Text = "Bộ phận";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(103, 78);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.MaxLength = 20;
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(116, 20);
            this.txtMa_Dt_CbNv.TabIndex = 68;
            // 
            // lbtTen_Dt_CbNv
            // 
            this.lbtTen_Dt_CbNv.AutoEllipsis = true;
            this.lbtTen_Dt_CbNv.AutoSize = true;
            this.lbtTen_Dt_CbNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Dt_CbNv.Location = new System.Drawing.Point(224, 85);
            this.lbtTen_Dt_CbNv.Name = "lbtTen_Dt_CbNv";
            this.lbtTen_Dt_CbNv.Size = new System.Drawing.Size(54, 13);
            this.lbtTen_Dt_CbNv.TabIndex = 65;
            this.lbtTen_Dt_CbNv.Tag = "Ma_Bp";
            this.lbtTen_Dt_CbNv.Text = "Bộ phận";
            this.lbtTen_Dt_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_Bp_Ct
            // 
            this.cboMa_Bp_Ct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Bp_Ct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Bp_Ct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Bp_Ct.Location = new System.Drawing.Point(103, 53);
            this.cboMa_Bp_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Bp_Ct.MaxLength = 20;
            this.cboMa_Bp_Ct.Name = "cboMa_Bp_Ct";
            this.cboMa_Bp_Ct.Size = new System.Drawing.Size(116, 21);
            this.cboMa_Bp_Ct.TabIndex = 69;
            // 
            // lbtTen_Bp_Ct
            // 
            this.lbtTen_Bp_Ct.AutoSize = true;
            this.lbtTen_Bp_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp_Ct.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp_Ct.Location = new System.Drawing.Point(224, 58);
            this.lbtTen_Bp_Ct.Name = "lbtTen_Bp_Ct";
            this.lbtTen_Bp_Ct.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp_Ct.TabIndex = 71;
            this.lbtTen_Bp_Ct.Tag = "";
            this.lbtTen_Bp_Ct.Text = "Tên Bộ phận";
            this.lbtTen_Bp_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.Location = new System.Drawing.Point(5, 56);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(54, 13);
            this.rsLabel2.TabIndex = 70;
            this.rsLabel2.Tag = "Ma_Bp_Ct";
            this.rsLabel2.Text = "Bộ phận";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmInBangLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.cboMa_Bp_Ct);
            this.Controls.Add(this.lbtTen_Bp_Ct);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.txtMa_Dt_CbNv);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.cboMa_Bp);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.lbtTen_Dt_CbNv);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.label1);
            this.Name = "frmInBangLuong";
            this.Text = "frmInBangLuong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label label1;
		private RosySystem.Control.rsMultiComboBox cboMa_Bp;
		private RosySystem.Control.rsLabel lblTk;
        private RosySystem.Control.rsLabelName lbtTen_Bp;
		private RosySystem.Control.rsComboBox cboThang;
		private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Control.rsButton btPrint;
        private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabel lbtTen_Dt_CbNv;
        private RosySystem.Control.rsMultiComboBox cboMa_Bp_Ct;
        private RosySystem.Control.rsLabelName lbtTen_Bp_Ct;
        private RosySystem.Control.rsLabel rsLabel2;
	}
}