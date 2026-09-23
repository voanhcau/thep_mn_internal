namespace RosyModule.Inventory
{
	partial class frmScale_60T
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tcControl = new RosySystem.Control.rsTabControl();
			this.tpScale = new System.Windows.Forms.TabPage();
			this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
			this.dgvCtNX_Barcode = new RosySystem.Control.rsDataGridView();
			this.dgvDmDt = new RosySystem.Control.rsDataGridView();
			this.dgvDmVt = new RosySystem.Control.rsDataGridView();
			this.txtTen_Dt_CbNv = new RosySystem.Control.rsTextBox();
			this.grbSearch = new RosySystem.Control.rsGroupBox();
			this.txtBarcode_Search = new RosySystem.Control.rsTextBox();
			this.rsLabel12 = new RosySystem.Control.rsLabel();
			this.txtSo_Xe_Search = new RosySystem.Control.rsTextBox();
			this.rsLabel11 = new RosySystem.Control.rsLabel();
			this.btSave_Print = new RosySystem.Control.rsButton();
			this.btScale = new RosySystem.Control.rsButton();
			this.chkPrint_Out = new RosySystem.Control.rsCheckbox();
			this.chkPrint_In = new RosySystem.Control.rsCheckbox();
			this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
			this.txtDien_Giai = new RosySystem.Control.rsTextBox();
			this.cboTen_Vt = new RosySystem.Control.rsComboBox();
			this.cboTen_Dt = new RosySystem.Control.rsComboBox();
			this.cboMa_Vt = new RosySystem.Control.rsComboBox();
			this.cboMa_Dt = new RosySystem.Control.rsComboBox();
			this.rsLabel10 = new RosySystem.Control.rsLabel();
			this.rsLabel9 = new RosySystem.Control.rsLabel();
			this.rsLabel8 = new RosySystem.Control.rsLabel();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.txtSo_Ct = new RosySystem.Control.rsTextBox();
			this.txtSo_Xe = new RosySystem.Control.rsTextBox();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.rsLabel5 = new RosySystem.Control.rsLabel();
			this.rsPanel2 = new RosySystem.Control.rsPanel();
			this.btScale_Out = new RosySystem.Control.rsButton();
			this.lblScale_Name = new RosySystem.Control.rsLabel();
			this.btScale_In = new RosySystem.Control.rsButton();
			this.btEdit = new RosySystem.Control.rsButton();
			this.btConvert_Scale = new RosySystem.Control.rsButton();
			this.rsPanel1 = new RosySystem.Control.rsPanel();
			this.lblStatus = new RosySystem.Control.rsLabel();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numSo_Luong = new RosySystem.Control.rsTextBoxNumber();
			this.numSo_Luong_Ra = new RosySystem.Control.rsTextBoxNumber();
			this.numSo_Luong_Vao = new RosySystem.Control.rsTextBoxNumber();
			this.txtTime = new RosySystem.Control.rsTextBox();
			this.numWeight_Scale = new RosySystem.Control.rsTextBoxNumberLed();
			this.tpVoucher = new System.Windows.Forms.TabPage();
			this.txtTime_Clock = new System.Windows.Forms.Timer(this.components);
			this.tcControl.SuspendLayout();
			this.tpScale.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
			this.rsSplitContainer1.Panel1.SuspendLayout();
			this.rsSplitContainer1.Panel2.SuspendLayout();
			this.rsSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCtNX_Barcode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDmDt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDmVt)).BeginInit();
			this.grbSearch.SuspendLayout();
			this.rsPanel2.SuspendLayout();
			this.rsPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcControl
			// 
			this.tcControl.Controls.Add(this.tpScale);
			this.tcControl.Controls.Add(this.tpVoucher);
			this.tcControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcControl.Location = new System.Drawing.Point(0, 0);
			this.tcControl.Name = "tcControl";
			this.tcControl.SelectedIndex = 0;
			this.tcControl.Size = new System.Drawing.Size(1058, 562);
			this.tcControl.TabIndex = 0;
			// 
			// tpScale
			// 
			this.tpScale.Controls.Add(this.rsSplitContainer1);
			this.tpScale.Controls.Add(this.rsPanel2);
			this.tpScale.Controls.Add(this.rsPanel1);
			this.tpScale.Location = new System.Drawing.Point(4, 22);
			this.tpScale.Name = "tpScale";
			this.tpScale.Padding = new System.Windows.Forms.Padding(3);
			this.tpScale.Size = new System.Drawing.Size(1050, 536);
			this.tpScale.TabIndex = 0;
			this.tpScale.Text = "Thông tin cân xe";
			this.tpScale.UseVisualStyleBackColor = true;
			// 
			// rsSplitContainer1
			// 
			this.rsSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rsSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.rsSplitContainer1.IsSplitterFixed = true;
			this.rsSplitContainer1.Location = new System.Drawing.Point(3, 174);
			this.rsSplitContainer1.Name = "rsSplitContainer1";
			// 
			// rsSplitContainer1.Panel1
			// 
			this.rsSplitContainer1.Panel1.Controls.Add(this.dgvCtNX_Barcode);
			this.rsSplitContainer1.Panel1.Controls.Add(this.dgvDmDt);
			this.rsSplitContainer1.Panel1.Controls.Add(this.dgvDmVt);
			// 
			// rsSplitContainer1.Panel2
			// 
			this.rsSplitContainer1.Panel2.Controls.Add(this.txtTen_Dt_CbNv);
			this.rsSplitContainer1.Panel2.Controls.Add(this.grbSearch);
			this.rsSplitContainer1.Panel2.Controls.Add(this.btSave_Print);
			this.rsSplitContainer1.Panel2.Controls.Add(this.btScale);
			this.rsSplitContainer1.Panel2.Controls.Add(this.chkPrint_Out);
			this.rsSplitContainer1.Panel2.Controls.Add(this.chkPrint_In);
			this.rsSplitContainer1.Panel2.Controls.Add(this.txtMa_Dt_CbNv);
			this.rsSplitContainer1.Panel2.Controls.Add(this.txtDien_Giai);
			this.rsSplitContainer1.Panel2.Controls.Add(this.cboTen_Vt);
			this.rsSplitContainer1.Panel2.Controls.Add(this.cboTen_Dt);
			this.rsSplitContainer1.Panel2.Controls.Add(this.cboMa_Vt);
			this.rsSplitContainer1.Panel2.Controls.Add(this.cboMa_Dt);
			this.rsSplitContainer1.Panel2.Controls.Add(this.rsLabel10);
			this.rsSplitContainer1.Panel2.Controls.Add(this.rsLabel9);
			this.rsSplitContainer1.Panel2.Controls.Add(this.rsLabel8);
			this.rsSplitContainer1.Panel2.Controls.Add(this.rsLabel7);
			this.rsSplitContainer1.Panel2.Controls.Add(this.txtSo_Ct);
			this.rsSplitContainer1.Panel2.Controls.Add(this.txtSo_Xe);
			this.rsSplitContainer1.Panel2.Controls.Add(this.rsLabel6);
			this.rsSplitContainer1.Panel2.Controls.Add(this.rsLabel5);
			this.rsSplitContainer1.Size = new System.Drawing.Size(1044, 359);
			this.rsSplitContainer1.SplitterDistance = 403;
			this.rsSplitContainer1.TabIndex = 20;
			// 
			// dgvCtNX_Barcode
			// 
			this.dgvCtNX_Barcode.AllowUserToAddRows = false;
			this.dgvCtNX_Barcode.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvCtNX_Barcode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvCtNX_Barcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCtNX_Barcode.BackgroundColor = System.Drawing.Color.White;
			this.dgvCtNX_Barcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvCtNX_Barcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCtNX_Barcode.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvCtNX_Barcode.Location = new System.Drawing.Point(15, 33);
			this.dgvCtNX_Barcode.MultiSelect = false;
			this.dgvCtNX_Barcode.Name = "dgvCtNX_Barcode";
			this.dgvCtNX_Barcode.ReadOnly = true;
			this.dgvCtNX_Barcode.Size = new System.Drawing.Size(219, 103);
			this.dgvCtNX_Barcode.strZone = "";
			this.dgvCtNX_Barcode.TabIndex = 2;
			this.dgvCtNX_Barcode.Visible = false;
			// 
			// dgvDmDt
			// 
			this.dgvDmDt.AllowUserToAddRows = false;
			this.dgvDmDt.AllowUserToDeleteRows = false;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvDmDt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvDmDt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDmDt.BackgroundColor = System.Drawing.Color.White;
			this.dgvDmDt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvDmDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDmDt.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvDmDt.Location = new System.Drawing.Point(4, 180);
			this.dgvDmDt.MultiSelect = false;
			this.dgvDmDt.Name = "dgvDmDt";
			this.dgvDmDt.ReadOnly = true;
			this.dgvDmDt.Size = new System.Drawing.Size(394, 172);
			this.dgvDmDt.strZone = "";
			this.dgvDmDt.TabIndex = 1;
			// 
			// dgvDmVt
			// 
			this.dgvDmVt.AllowUserToAddRows = false;
			this.dgvDmVt.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvDmVt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDmVt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDmVt.BackgroundColor = System.Drawing.Color.White;
			this.dgvDmVt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvDmVt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDmVt.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvDmVt.Location = new System.Drawing.Point(4, 4);
			this.dgvDmVt.MultiSelect = false;
			this.dgvDmVt.Name = "dgvDmVt";
			this.dgvDmVt.ReadOnly = true;
			this.dgvDmVt.Size = new System.Drawing.Size(394, 174);
			this.dgvDmVt.strZone = "";
			this.dgvDmVt.TabIndex = 0;
			// 
			// txtTen_Dt_CbNv
			// 
			this.txtTen_Dt_CbNv.BackColor = System.Drawing.SystemColors.Window;
			this.txtTen_Dt_CbNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTen_Dt_CbNv.Location = new System.Drawing.Point(223, 242);
			this.txtTen_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Dt_CbNv.Name = "txtTen_Dt_CbNv";
			this.txtTen_Dt_CbNv.ReadOnly = true;
			this.txtTen_Dt_CbNv.Size = new System.Drawing.Size(401, 23);
			this.txtTen_Dt_CbNv.TabIndex = 9;
			this.txtTen_Dt_CbNv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// grbSearch
			// 
			this.grbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbSearch.BorderColor = System.Drawing.Color.Black;
			this.grbSearch.Controls.Add(this.txtBarcode_Search);
			this.grbSearch.Controls.Add(this.rsLabel12);
			this.grbSearch.Controls.Add(this.txtSo_Xe_Search);
			this.grbSearch.Controls.Add(this.rsLabel11);
			this.grbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grbSearch.Location = new System.Drawing.Point(9, 7);
			this.grbSearch.Name = "grbSearch";
			this.grbSearch.Size = new System.Drawing.Size(621, 91);
			this.grbSearch.TabIndex = 0;
			this.grbSearch.TabStop = false;
			this.grbSearch.Text = "Lấy thông tin phiếu cân";
			this.grbSearch.Visible = false;
			// 
			// txtBarcode_Search
			// 
			this.txtBarcode_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBarcode_Search.Location = new System.Drawing.Point(100, 26);
			this.txtBarcode_Search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtBarcode_Search.Name = "txtBarcode_Search";
			this.txtBarcode_Search.Size = new System.Drawing.Size(225, 38);
			this.txtBarcode_Search.TabIndex = 0;
			this.txtBarcode_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// rsLabel12
			// 
			this.rsLabel12.AutoEllipsis = true;
			this.rsLabel12.AutoSize = true;
			this.rsLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel12.Location = new System.Drawing.Point(6, 39);
			this.rsLabel12.Name = "rsLabel12";
			this.rsLabel12.Size = new System.Drawing.Size(75, 20);
			this.rsLabel12.TabIndex = 31;
			this.rsLabel12.Text = "Mã vạch";
			this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSo_Xe_Search
			// 
			this.txtSo_Xe_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSo_Xe_Search.Location = new System.Drawing.Point(418, 26);
			this.txtSo_Xe_Search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_Xe_Search.Name = "txtSo_Xe_Search";
			this.txtSo_Xe_Search.Size = new System.Drawing.Size(197, 38);
			this.txtSo_Xe_Search.TabIndex = 1;
			this.txtSo_Xe_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// rsLabel11
			// 
			this.rsLabel11.AutoEllipsis = true;
			this.rsLabel11.AutoSize = true;
			this.rsLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel11.Location = new System.Drawing.Point(330, 39);
			this.rsLabel11.Name = "rsLabel11";
			this.rsLabel11.Size = new System.Drawing.Size(54, 20);
			this.rsLabel11.TabIndex = 29;
			this.rsLabel11.Text = "Số xe";
			this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btSave_Print
			// 
			this.btSave_Print.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSave_Print.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
			this.btSave_Print.Location = new System.Drawing.Point(230, 284);
			this.btSave_Print.Name = "btSave_Print";
			this.btSave_Print.Size = new System.Drawing.Size(119, 40);
			this.btSave_Print.TabIndex = 11;
			this.btSave_Print.Text = "F3-Lưu và in";
			this.btSave_Print.UseVisualStyleBackColor = true;
			// 
			// btScale
			// 
			this.btScale.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
			this.btScale.Location = new System.Drawing.Point(109, 283);
			this.btScale.Name = "btScale";
			this.btScale.Size = new System.Drawing.Size(119, 40);
			this.btScale.TabIndex = 10;
			this.btScale.Text = "F2- Cân xe";
			this.btScale.UseVisualStyleBackColor = true;
			// 
			// chkPrint_Out
			// 
			this.chkPrint_Out.AutoSize = true;
			this.chkPrint_Out.Checked = true;
			this.chkPrint_Out.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPrint_Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkPrint_Out.Location = new System.Drawing.Point(474, 308);
			this.chkPrint_Out.Name = "chkPrint_Out";
			this.chkPrint_Out.Size = new System.Drawing.Size(136, 21);
			this.chkPrint_Out.TabIndex = 13;
			this.chkPrint_Out.Text = "In phiếu cân ra";
			this.chkPrint_Out.UseVisualStyleBackColor = true;
			// 
			// chkPrint_In
			// 
			this.chkPrint_In.AutoSize = true;
			this.chkPrint_In.Checked = true;
			this.chkPrint_In.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPrint_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkPrint_In.Location = new System.Drawing.Point(474, 281);
			this.chkPrint_In.Name = "chkPrint_In";
			this.chkPrint_In.Size = new System.Drawing.Size(147, 21);
			this.chkPrint_In.TabIndex = 12;
			this.chkPrint_In.Text = "In phiếu cân vào";
			this.chkPrint_In.UseVisualStyleBackColor = true;
			// 
			// txtMa_Dt_CbNv
			// 
			this.txtMa_Dt_CbNv.BackColor = System.Drawing.SystemColors.Window;
			this.txtMa_Dt_CbNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(109, 242);
			this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
			this.txtMa_Dt_CbNv.ReadOnly = true;
			this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(111, 23);
			this.txtMa_Dt_CbNv.TabIndex = 8;
			this.txtMa_Dt_CbNv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtDien_Giai
			// 
			this.txtDien_Giai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDien_Giai.Location = new System.Drawing.Point(109, 214);
			this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtDien_Giai.Name = "txtDien_Giai";
			this.txtDien_Giai.Size = new System.Drawing.Size(515, 23);
			this.txtDien_Giai.TabIndex = 7;
			this.txtDien_Giai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cboTen_Vt
			// 
			this.cboTen_Vt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboTen_Vt.DropDownHeight = 147;
			this.cboTen_Vt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboTen_Vt.FormattingEnabled = true;
			this.cboTen_Vt.IntegralHeight = false;
			this.cboTen_Vt.Location = new System.Drawing.Point(224, 188);
			this.cboTen_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboTen_Vt.Name = "cboTen_Vt";
			this.cboTen_Vt.Size = new System.Drawing.Size(400, 24);
			this.cboTen_Vt.TabIndex = 6;
			// 
			// cboTen_Dt
			// 
			this.cboTen_Dt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboTen_Dt.DropDownHeight = 147;
			this.cboTen_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboTen_Dt.FormattingEnabled = true;
			this.cboTen_Dt.IntegralHeight = false;
			this.cboTen_Dt.Location = new System.Drawing.Point(224, 162);
			this.cboTen_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboTen_Dt.Name = "cboTen_Dt";
			this.cboTen_Dt.Size = new System.Drawing.Size(400, 24);
			this.cboTen_Dt.TabIndex = 4;
			// 
			// cboMa_Vt
			// 
			this.cboMa_Vt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboMa_Vt.DropDownHeight = 147;
			this.cboMa_Vt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboMa_Vt.FormattingEnabled = true;
			this.cboMa_Vt.IntegralHeight = false;
			this.cboMa_Vt.Location = new System.Drawing.Point(109, 188);
			this.cboMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_Vt.Name = "cboMa_Vt";
			this.cboMa_Vt.Size = new System.Drawing.Size(111, 24);
			this.cboMa_Vt.TabIndex = 5;
			// 
			// cboMa_Dt
			// 
			this.cboMa_Dt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboMa_Dt.DropDownHeight = 147;
			this.cboMa_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboMa_Dt.FormattingEnabled = true;
			this.cboMa_Dt.IntegralHeight = false;
			this.cboMa_Dt.Location = new System.Drawing.Point(109, 162);
			this.cboMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_Dt.MaxDropDownItems = 9;
			this.cboMa_Dt.Name = "cboMa_Dt";
			this.cboMa_Dt.Size = new System.Drawing.Size(111, 24);
			this.cboMa_Dt.TabIndex = 3;
			// 
			// rsLabel10
			// 
			this.rsLabel10.AutoEllipsis = true;
			this.rsLabel10.AutoSize = true;
			this.rsLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel10.Location = new System.Drawing.Point(12, 245);
			this.rsLabel10.Name = "rsLabel10";
			this.rsLabel10.Size = new System.Drawing.Size(62, 17);
			this.rsLabel10.TabIndex = 7;
			this.rsLabel10.Text = "NV Cân";
			this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel9
			// 
			this.rsLabel9.AutoEllipsis = true;
			this.rsLabel9.AutoSize = true;
			this.rsLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel9.Location = new System.Drawing.Point(12, 217);
			this.rsLabel9.Name = "rsLabel9";
			this.rsLabel9.Size = new System.Drawing.Size(64, 17);
			this.rsLabel9.TabIndex = 6;
			this.rsLabel9.Text = "Ghi chú";
			this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel8
			// 
			this.rsLabel8.AutoEllipsis = true;
			this.rsLabel8.AutoSize = true;
			this.rsLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel8.Location = new System.Drawing.Point(12, 191);
			this.rsLabel8.Name = "rsLabel8";
			this.rsLabel8.Size = new System.Drawing.Size(78, 17);
			this.rsLabel8.TabIndex = 5;
			this.rsLabel8.Text = "Hàng hóa";
			this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel7.Location = new System.Drawing.Point(12, 165);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(94, 17);
			this.rsLabel7.TabIndex = 4;
			this.rsLabel7.Text = "Khách hàng";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSo_Ct
			// 
			this.txtSo_Ct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.txtSo_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSo_Ct.Location = new System.Drawing.Point(427, 116);
			this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_Ct.Name = "txtSo_Ct";
			this.txtSo_Ct.ReadOnly = true;
			this.txtSo_Ct.Size = new System.Drawing.Size(197, 38);
			this.txtSo_Ct.TabIndex = 2;
			this.txtSo_Ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSo_Xe
			// 
			this.txtSo_Xe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSo_Xe.Location = new System.Drawing.Point(109, 116);
			this.txtSo_Xe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtSo_Xe.Name = "txtSo_Xe";
			this.txtSo_Xe.Size = new System.Drawing.Size(225, 38);
			this.txtSo_Xe.TabIndex = 1;
			this.txtSo_Xe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel6.Location = new System.Drawing.Point(339, 124);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(80, 20);
			this.rsLabel6.TabIndex = 1;
			this.rsLabel6.Text = "Số phiếu";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel5
			// 
			this.rsLabel5.AutoEllipsis = true;
			this.rsLabel5.AutoSize = true;
			this.rsLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel5.Location = new System.Drawing.Point(11, 129);
			this.rsLabel5.Name = "rsLabel5";
			this.rsLabel5.Size = new System.Drawing.Size(54, 20);
			this.rsLabel5.TabIndex = 0;
			this.rsLabel5.Text = "Số xe";
			this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsPanel2
			// 
			this.rsPanel2.Controls.Add(this.btScale_Out);
			this.rsPanel2.Controls.Add(this.lblScale_Name);
			this.rsPanel2.Controls.Add(this.btScale_In);
			this.rsPanel2.Controls.Add(this.btEdit);
			this.rsPanel2.Controls.Add(this.btConvert_Scale);
			this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.rsPanel2.Location = new System.Drawing.Point(3, 127);
			this.rsPanel2.Name = "rsPanel2";
			this.rsPanel2.Size = new System.Drawing.Size(1044, 47);
			this.rsPanel2.TabIndex = 19;
			// 
			// btScale_Out
			// 
			this.btScale_Out.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btScale_Out.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
			this.btScale_Out.Location = new System.Drawing.Point(389, 3);
			this.btScale_Out.Name = "btScale_Out";
			this.btScale_Out.Size = new System.Drawing.Size(186, 41);
			this.btScale_Out.TabIndex = 22;
			this.btScale_Out.Text = "F6- CÂN XE RA";
			this.btScale_Out.UseVisualStyleBackColor = true;
			// 
			// lblScale_Name
			// 
			this.lblScale_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblScale_Name.AutoEllipsis = true;
			this.lblScale_Name.BackColor = System.Drawing.Color.Black;
			this.lblScale_Name.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblScale_Name.ForeColor = System.Drawing.Color.Lime;
			this.lblScale_Name.Location = new System.Drawing.Point(966, 3);
			this.lblScale_Name.Name = "lblScale_Name";
			this.lblScale_Name.Size = new System.Drawing.Size(74, 41);
			this.lblScale_Name.TabIndex = 25;
			this.lblScale_Name.Text = "CÂN A";
			this.lblScale_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btScale_In
			// 
			this.btScale_In.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btScale_In.ForeColor = System.Drawing.Color.Red;
			this.btScale_In.Location = new System.Drawing.Point(197, 3);
			this.btScale_In.Name = "btScale_In";
			this.btScale_In.Size = new System.Drawing.Size(186, 41);
			this.btScale_In.TabIndex = 20;
			this.btScale_In.Text = "F5- CÂN XE VÀO";
			this.btScale_In.UseVisualStyleBackColor = true;
			// 
			// btEdit
			// 
			this.btEdit.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
			this.btEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
			this.btEdit.Location = new System.Drawing.Point(5, 3);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(186, 41);
			this.btEdit.TabIndex = 21;
			this.btEdit.Text = "F8- SỬA PHIẾU";
			this.btEdit.UseVisualStyleBackColor = true;
			// 
			// btConvert_Scale
			// 
			this.btConvert_Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btConvert_Scale.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConvert_Scale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
			this.btConvert_Scale.Location = new System.Drawing.Point(774, 3);
			this.btConvert_Scale.Name = "btConvert_Scale";
			this.btConvert_Scale.Size = new System.Drawing.Size(186, 41);
			this.btConvert_Scale.TabIndex = 23;
			this.btConvert_Scale.Text = "F9- CHUYỂN CÂN";
			this.btConvert_Scale.UseVisualStyleBackColor = true;
			// 
			// rsPanel1
			// 
			this.rsPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rsPanel1.Controls.Add(this.lblStatus);
			this.rsPanel1.Controls.Add(this.rsLabel3);
			this.rsPanel1.Controls.Add(this.rsLabel2);
			this.rsPanel1.Controls.Add(this.rsLabel1);
			this.rsPanel1.Controls.Add(this.numSo_Luong);
			this.rsPanel1.Controls.Add(this.numSo_Luong_Ra);
			this.rsPanel1.Controls.Add(this.numSo_Luong_Vao);
			this.rsPanel1.Controls.Add(this.txtTime);
			this.rsPanel1.Controls.Add(this.numWeight_Scale);
			this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.rsPanel1.Location = new System.Drawing.Point(3, 3);
			this.rsPanel1.Name = "rsPanel1";
			this.rsPanel1.Size = new System.Drawing.Size(1044, 124);
			this.rsPanel1.TabIndex = 0;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoEllipsis = true;
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(4, 4);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(37, 13);
			this.lblStatus.TabIndex = 25;
			this.lblStatus.Text = "Status";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStatus.Visible = false;
			// 
			// rsLabel3
			// 
			this.rsLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel3.Location = new System.Drawing.Point(890, 41);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(135, 25);
			this.rsLabel3.TabIndex = 24;
			this.rsLabel3.Text = "KL hàng hóa";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel2
			// 
			this.rsLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel2.Location = new System.Drawing.Point(739, 41);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(93, 25);
			this.rsLabel2.TabIndex = 23;
			this.rsLabel2.Text = "KL xe ra";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel1.Location = new System.Drawing.Point(557, 41);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(109, 25);
			this.rsLabel1.TabIndex = 22;
			this.rsLabel1.Text = "KL xe vào";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numSo_Luong
			// 
			this.numSo_Luong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numSo_Luong.BackColor = System.Drawing.Color.Black;
			this.numSo_Luong.bFormat = true;
			this.numSo_Luong.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numSo_Luong.ForeColor = System.Drawing.Color.Red;
			this.numSo_Luong.Location = new System.Drawing.Point(878, 70);
			this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Luong.Name = "numSo_Luong";
			this.numSo_Luong.Scale = 0;
			this.numSo_Luong.Size = new System.Drawing.Size(160, 45);
			this.numSo_Luong.TabIndex = 4;
			this.numSo_Luong.Text = "0";
			this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSo_Luong.Value = 0D;
			// 
			// numSo_Luong_Ra
			// 
			this.numSo_Luong_Ra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numSo_Luong_Ra.BackColor = System.Drawing.Color.Black;
			this.numSo_Luong_Ra.bFormat = true;
			this.numSo_Luong_Ra.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numSo_Luong_Ra.ForeColor = System.Drawing.Color.Yellow;
			this.numSo_Luong_Ra.Location = new System.Drawing.Point(704, 70);
			this.numSo_Luong_Ra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Luong_Ra.Name = "numSo_Luong_Ra";
			this.numSo_Luong_Ra.Scale = 0;
			this.numSo_Luong_Ra.Size = new System.Drawing.Size(160, 45);
			this.numSo_Luong_Ra.TabIndex = 3;
			this.numSo_Luong_Ra.Text = "0";
			this.numSo_Luong_Ra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSo_Luong_Ra.Value = 0D;
			// 
			// numSo_Luong_Vao
			// 
			this.numSo_Luong_Vao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numSo_Luong_Vao.BackColor = System.Drawing.Color.Black;
			this.numSo_Luong_Vao.bFormat = true;
			this.numSo_Luong_Vao.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numSo_Luong_Vao.ForeColor = System.Drawing.Color.Lime;
			this.numSo_Luong_Vao.Location = new System.Drawing.Point(530, 70);
			this.numSo_Luong_Vao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numSo_Luong_Vao.Name = "numSo_Luong_Vao";
			this.numSo_Luong_Vao.Scale = 0;
			this.numSo_Luong_Vao.Size = new System.Drawing.Size(160, 45);
			this.numSo_Luong_Vao.TabIndex = 2;
			this.numSo_Luong_Vao.Text = "0";
			this.numSo_Luong_Vao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSo_Luong_Vao.Value = 0D;
			// 
			// txtTime
			// 
			this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTime.BackColor = System.Drawing.Color.Black;
			this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTime.ForeColor = System.Drawing.Color.Yellow;
			this.txtTime.Location = new System.Drawing.Point(530, 3);
			this.txtTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTime.Name = "txtTime";
			this.txtTime.Size = new System.Drawing.Size(508, 35);
			this.txtTime.TabIndex = 1;
			this.txtTime.Text = "00:00";
			this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// numWeight_Scale
			// 
			this.numWeight_Scale.AdjustMode = 1;
			this.numWeight_Scale.AlphaText = "0";
			this.numWeight_Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numWeight_Scale.BackColor = System.Drawing.SystemColors.Control;
			this.numWeight_Scale.BackFillEndColor = System.Drawing.Color.Black;
			this.numWeight_Scale.BackFillStartColor = System.Drawing.Color.Black;
			this.numWeight_Scale.BackGradientMode = 4;
			this.numWeight_Scale.BackPicture = null;
			this.numWeight_Scale.BorderColor = System.Drawing.Color.Black;
			this.numWeight_Scale.BorderGradientMode = 4;
			this.numWeight_Scale.BorderLight = System.Drawing.Color.Black;
			this.numWeight_Scale.BorderShadow = System.Drawing.Color.Black;
			this.numWeight_Scale.BorderShape = 0;
			this.numWeight_Scale.BorderWidth = 0;
			this.numWeight_Scale.DecimalSize = 3;
			this.numWeight_Scale.GraphicSmooth = 1;
			this.numWeight_Scale.LeadingZeros = false;
			this.numWeight_Scale.LedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.numWeight_Scale.LedOnColor = System.Drawing.Color.Lime;
			this.numWeight_Scale.LedWidth = 50;
			this.numWeight_Scale.Location = new System.Drawing.Point(92, 4);
			this.numWeight_Scale.Name = "numWeight_Scale";
			this.numWeight_Scale.Size = new System.Drawing.Size(411, 115);
			this.numWeight_Scale.TabIndex = 0;
			this.numWeight_Scale.Value = 0D;
			// 
			// tpVoucher
			// 
			this.tpVoucher.Location = new System.Drawing.Point(4, 22);
			this.tpVoucher.Name = "tpVoucher";
			this.tpVoucher.Padding = new System.Windows.Forms.Padding(3);
			this.tpVoucher.Size = new System.Drawing.Size(1050, 536);
			this.tpVoucher.TabIndex = 1;
			this.tpVoucher.Text = "Thông tin phiếu cân";
			this.tpVoucher.UseVisualStyleBackColor = true;
			// 
			// txtTime_Clock
			// 
			this.txtTime_Clock.Enabled = true;
			this.txtTime_Clock.Interval = 1000;
			// 
			// frmScale
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1058, 562);
			this.ControlBox = false;
			this.Controls.Add(this.tcControl);
			this.Name = "frmScale";
			this.Object_ID = "CT_PNTT";
			this.Text = "frmScale";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tcControl.ResumeLayout(false);
			this.tpScale.ResumeLayout(false);
			this.rsSplitContainer1.Panel1.ResumeLayout(false);
			this.rsSplitContainer1.Panel2.ResumeLayout(false);
			this.rsSplitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
			this.rsSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCtNX_Barcode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDmDt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDmVt)).EndInit();
			this.grbSearch.ResumeLayout(false);
			this.grbSearch.PerformLayout();
			this.rsPanel2.ResumeLayout(false);
			this.rsPanel1.ResumeLayout(false);
			this.rsPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsTabControl tcControl;
		private System.Windows.Forms.TabPage tpScale;
		private System.Windows.Forms.TabPage tpVoucher;
		private RosySystem.Control.rsTextBoxNumberLed numWeight_Scale;
		private RosySystem.Control.rsPanel rsPanel1;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxNumber numSo_Luong;
		private RosySystem.Control.rsTextBoxNumber numSo_Luong_Ra;
		private RosySystem.Control.rsTextBoxNumber numSo_Luong_Vao;
		private RosySystem.Control.rsTextBox txtTime;
		private RosySystem.Control.rsButton btConvert_Scale;
		private RosySystem.Control.rsButton btScale_Out;
		private RosySystem.Control.rsButton btEdit;
		private RosySystem.Control.rsButton btScale_In;
		private RosySystem.Control.rsPanel rsPanel2;
		private RosySystem.Control.rsLabel lblScale_Name;
		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
		private RosySystem.Control.rsDataGridView dgvDmDt;
		private RosySystem.Control.rsDataGridView dgvDmVt;
		private RosySystem.Control.rsTextBox txtSo_Xe;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsTextBox txtSo_Ct;
		private RosySystem.Control.rsLabel rsLabel10;
		private RosySystem.Control.rsLabel rsLabel9;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsComboBox cboMa_Vt;
		private RosySystem.Control.rsComboBox cboMa_Dt;
		private RosySystem.Control.rsComboBox cboTen_Vt;
		private RosySystem.Control.rsComboBox cboTen_Dt;
		private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
		private RosySystem.Control.rsTextBox txtDien_Giai;
		private RosySystem.Control.rsCheckbox chkPrint_Out;
		private RosySystem.Control.rsCheckbox chkPrint_In;
		private RosySystem.Control.rsButton btSave_Print;
		private RosySystem.Control.rsButton btScale;
		private RosySystem.Control.rsGroupBox grbSearch;
		private RosySystem.Control.rsTextBox txtBarcode_Search;
		private RosySystem.Control.rsLabel rsLabel12;
		private RosySystem.Control.rsTextBox txtSo_Xe_Search;
		private RosySystem.Control.rsLabel rsLabel11;
		private RosySystem.Control.rsTextBox txtTen_Dt_CbNv;
		private System.Windows.Forms.Timer txtTime_Clock;
		private RosySystem.Control.rsDataGridView dgvCtNX_Barcode;
		private RosySystem.Control.rsLabel lblStatus;


	}
}