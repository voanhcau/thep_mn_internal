namespace RosyModule.Salary
{
    partial class frmBangLuongSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangLuongSP));
            this.btCalcSalary = new RosySystem.Control.rsButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboMa_Bp = new RosySystem.Control.rsMultiComboBox();
            this.lblTk = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp = new RosySystem.Control.rsLabelName();
            this.cboThang = new RosySystem.Control.rsComboBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Bp_Ct = new RosySystem.Control.rsLabelName();
            this.cboMa_Bp_Ct = new RosySystem.Control.rsMultiComboBox();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.numKD = new RosySystem.Control.rsTextBoxNumber();
            this.numLKipB = new RosySystem.Control.rsTextBoxNumber();
            this.numLKipA = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel14 = new RosySystem.Control.rsLabel();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.btExit = new RosySystem.Control.rsButton();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.numLKipC = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.numCKipC = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.rsLabel12 = new RosySystem.Control.rsLabel();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.numCKipB = new RosySystem.Control.rsTextBoxNumber();
            this.numCKipA = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabel15 = new RosySystem.Control.rsLabel();
            this.lblNote = new RosySystem.Control.rsLabel();
            this.SuspendLayout();
            // 
            // btCalcSalary
            // 
            this.btCalcSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCalcSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalcSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCalcSalary.ImageKey = "calc";
            this.btCalcSalary.ImageList = this.imageList1;
            this.btCalcSalary.Location = new System.Drawing.Point(8, 513);
            this.btCalcSalary.Name = "btCalcSalary";
            this.btCalcSalary.Size = new System.Drawing.Size(97, 47);
            this.btCalcSalary.TabIndex = 4;
            this.btCalcSalary.Tag = "";
            this.btCalcSalary.Text = "&Tính &lương SP";
            this.btCalcSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCalcSalary.UseVisualStyleBackColor = true;
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
            this.panel1.Size = new System.Drawing.Size(942, 408);
            this.panel1.TabIndex = 2;
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
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel5.ForeColor = System.Drawing.Color.Black;
            this.rsLabel5.Location = new System.Drawing.Point(567, 59);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(26, 13);
            this.rsLabel5.TabIndex = 193;
            this.rsLabel5.Text = "Tấn";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel4.ForeColor = System.Drawing.Color.Black;
            this.rsLabel4.Location = new System.Drawing.Point(565, 7);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(26, 13);
            this.rsLabel4.TabIndex = 192;
            this.rsLabel4.Text = "Tấn";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel3.ForeColor = System.Drawing.Color.Black;
            this.rsLabel3.Location = new System.Drawing.Point(567, 36);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(26, 13);
            this.rsLabel3.TabIndex = 190;
            this.rsLabel3.Text = "Tấn";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel2.Location = new System.Drawing.Point(320, 57);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(154, 13);
            this.rsLabel2.TabIndex = 191;
            this.rsLabel2.Text = "Sản lượng thép thỏi Kíp B";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel6.Location = new System.Drawing.Point(318, 7);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(162, 13);
            this.rsLabel6.TabIndex = 189;
            this.rsLabel6.Text = "Sản lượng tính lương tháng";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numKD
            // 
            this.numKD.AutoDropDown = null;
            this.numKD.bFormat = true;
            this.numKD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numKD.Location = new System.Drawing.Point(481, 3);
            this.numKD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numKD.Name = "numKD";
            this.numKD.Scale = 0;
            this.numKD.Size = new System.Drawing.Size(77, 20);
            this.numKD.TabIndex = 188;
            this.numKD.Text = "0";
            this.numKD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numKD.Value = 0D;
            // 
            // numLKipB
            // 
            this.numLKipB.AutoDropDown = null;
            this.numLKipB.bFormat = true;
            this.numLKipB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLKipB.Location = new System.Drawing.Point(481, 54);
            this.numLKipB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numLKipB.Name = "numLKipB";
            this.numLKipB.Scale = 0;
            this.numLKipB.Size = new System.Drawing.Size(76, 20);
            this.numLKipB.TabIndex = 187;
            this.numLKipB.Text = "0";
            this.numLKipB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLKipB.Value = 0D;
            // 
            // numLKipA
            // 
            this.numLKipA.AutoDropDown = null;
            this.numLKipA.bFormat = true;
            this.numLKipA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLKipA.Location = new System.Drawing.Point(481, 32);
            this.numLKipA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numLKipA.Name = "numLKipA";
            this.numLKipA.Scale = 0;
            this.numLKipA.Size = new System.Drawing.Size(76, 20);
            this.numLKipA.TabIndex = 186;
            this.numLKipA.Text = "0";
            this.numLKipA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLKipA.Value = 0D;
            // 
            // rsLabel14
            // 
            this.rsLabel14.AutoEllipsis = true;
            this.rsLabel14.AutoSize = true;
            this.rsLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel14.Location = new System.Drawing.Point(320, 34);
            this.rsLabel14.Name = "rsLabel14";
            this.rsLabel14.Size = new System.Drawing.Size(154, 13);
            this.rsLabel14.TabIndex = 185;
            this.rsLabel14.Text = "Sản lượng thép thỏi Kíp A";
            this.rsLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "calc";
            this.btRefresh.Location = new System.Drawing.Point(108, 513);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(97, 47);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "&Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "calc";
            this.btExit.Location = new System.Drawing.Point(207, 513);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(97, 47);
            this.btExit.TabIndex = 4;
            this.btExit.Tag = "";
            this.btExit.Text = "&Thoát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel7.ForeColor = System.Drawing.Color.Black;
            this.rsLabel7.Location = new System.Drawing.Point(567, 81);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(26, 13);
            this.rsLabel7.TabIndex = 196;
            this.rsLabel7.Text = "Tấn";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel8.Location = new System.Drawing.Point(320, 79);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(154, 13);
            this.rsLabel8.TabIndex = 195;
            this.rsLabel8.Text = "Sản lượng thép thỏi Kíp C";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLKipC
            // 
            this.numLKipC.AutoDropDown = null;
            this.numLKipC.bFormat = true;
            this.numLKipC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLKipC.Location = new System.Drawing.Point(481, 76);
            this.numLKipC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numLKipC.Name = "numLKipC";
            this.numLKipC.Scale = 0;
            this.numLKipC.Size = new System.Drawing.Size(76, 20);
            this.numLKipC.TabIndex = 194;
            this.numLKipC.Text = "0";
            this.numLKipC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLKipC.Value = 0D;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel9.ForeColor = System.Drawing.Color.Black;
            this.rsLabel9.Location = new System.Drawing.Point(891, 78);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(26, 13);
            this.rsLabel9.TabIndex = 205;
            this.rsLabel9.Text = "Tấn";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel10.Location = new System.Drawing.Point(644, 76);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(154, 13);
            this.rsLabel10.TabIndex = 204;
            this.rsLabel10.Text = "Sản lượng thép cán Kíp C";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numCKipC
            // 
            this.numCKipC.AutoDropDown = null;
            this.numCKipC.bFormat = true;
            this.numCKipC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCKipC.Location = new System.Drawing.Point(805, 73);
            this.numCKipC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numCKipC.Name = "numCKipC";
            this.numCKipC.Scale = 0;
            this.numCKipC.Size = new System.Drawing.Size(76, 20);
            this.numCKipC.TabIndex = 203;
            this.numCKipC.Text = "0";
            this.numCKipC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCKipC.Value = 0D;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel11.ForeColor = System.Drawing.Color.Black;
            this.rsLabel11.Location = new System.Drawing.Point(891, 56);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(26, 13);
            this.rsLabel11.TabIndex = 202;
            this.rsLabel11.Text = "Tấn";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel12
            // 
            this.rsLabel12.AutoEllipsis = true;
            this.rsLabel12.AutoSize = true;
            this.rsLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel12.ForeColor = System.Drawing.Color.Black;
            this.rsLabel12.Location = new System.Drawing.Point(891, 33);
            this.rsLabel12.Name = "rsLabel12";
            this.rsLabel12.Size = new System.Drawing.Size(26, 13);
            this.rsLabel12.TabIndex = 200;
            this.rsLabel12.Text = "Tấn";
            this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel13.Location = new System.Drawing.Point(644, 54);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(154, 13);
            this.rsLabel13.TabIndex = 201;
            this.rsLabel13.Text = "Sản lượng thép cán Kíp B";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numCKipB
            // 
            this.numCKipB.AutoDropDown = null;
            this.numCKipB.bFormat = true;
            this.numCKipB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCKipB.Location = new System.Drawing.Point(805, 51);
            this.numCKipB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numCKipB.Name = "numCKipB";
            this.numCKipB.Scale = 0;
            this.numCKipB.Size = new System.Drawing.Size(76, 20);
            this.numCKipB.TabIndex = 199;
            this.numCKipB.Text = "0";
            this.numCKipB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCKipB.Value = 0D;
            // 
            // numCKipA
            // 
            this.numCKipA.AutoDropDown = null;
            this.numCKipA.bFormat = true;
            this.numCKipA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCKipA.Location = new System.Drawing.Point(805, 29);
            this.numCKipA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numCKipA.Name = "numCKipA";
            this.numCKipA.Scale = 0;
            this.numCKipA.Size = new System.Drawing.Size(76, 20);
            this.numCKipA.TabIndex = 198;
            this.numCKipA.Text = "0";
            this.numCKipA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCKipA.Value = 0D;
            // 
            // rsLabel15
            // 
            this.rsLabel15.AutoEllipsis = true;
            this.rsLabel15.AutoSize = true;
            this.rsLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rsLabel15.Location = new System.Drawing.Point(644, 31);
            this.rsLabel15.Name = "rsLabel15";
            this.rsLabel15.Size = new System.Drawing.Size(154, 13);
            this.rsLabel15.TabIndex = 197;
            this.rsLabel15.Text = "Sản lượng thép cán Kíp A";
            this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNote.AutoEllipsis = true;
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNote.Location = new System.Drawing.Point(320, 530);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(162, 13);
            this.lblNote.TabIndex = 206;
            this.lblNote.Text = "Sản lượng tính lương tháng";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBangLuongSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 566);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.rsLabel9);
            this.Controls.Add(this.rsLabel10);
            this.Controls.Add(this.numCKipC);
            this.Controls.Add(this.rsLabel11);
            this.Controls.Add(this.rsLabel12);
            this.Controls.Add(this.rsLabel13);
            this.Controls.Add(this.numCKipB);
            this.Controls.Add(this.numCKipA);
            this.Controls.Add(this.rsLabel15);
            this.Controls.Add(this.rsLabel7);
            this.Controls.Add(this.rsLabel8);
            this.Controls.Add(this.numLKipC);
            this.Controls.Add(this.rsLabel5);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.rsLabel2);
            this.Controls.Add(this.rsLabel6);
            this.Controls.Add(this.numKD);
            this.Controls.Add(this.numLKipB);
            this.Controls.Add(this.numLKipA);
            this.Controls.Add(this.rsLabel14);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.cboMa_Bp_Ct);
            this.Controls.Add(this.lbtTen_Bp_Ct);
            this.Controls.Add(this.cboMa_Bp);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btCalcSalary);
            this.Name = "frmBangLuongSP";
            this.Text = "frmBangLuongSP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsButton btCalcSalary;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
		private RosySystem.Control.rsMultiComboBox cboMa_Bp;
		private RosySystem.Control.rsLabel lblTk;
        private RosySystem.Control.rsLabelName lbtTen_Bp;
		private RosySystem.Control.rsComboBox cboThang;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabelName lbtTen_Bp_Ct;
        private RosySystem.Control.rsMultiComboBox cboMa_Bp_Ct;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBoxNumber numKD;
        private RosySystem.Control.rsTextBoxNumber numLKipB;
        private RosySystem.Control.rsTextBoxNumber numLKipA;
        private RosySystem.Control.rsLabel rsLabel14;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsButton btExit;
        private RosySystem.Control.rsLabel rsLabel7;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsTextBoxNumber numLKipC;
        private RosySystem.Control.rsLabel rsLabel9;
        private RosySystem.Control.rsLabel rsLabel10;
        private RosySystem.Control.rsTextBoxNumber numCKipC;
        private RosySystem.Control.rsLabel rsLabel11;
        private RosySystem.Control.rsLabel rsLabel12;
        private RosySystem.Control.rsLabel rsLabel13;
        private RosySystem.Control.rsTextBoxNumber numCKipB;
        private RosySystem.Control.rsTextBoxNumber numCKipA;
        private RosySystem.Control.rsLabel rsLabel15;
        private RosySystem.Control.rsLabel lblNote;
	}
}