namespace RosyList
{
	partial class frmEquipmentInfo_Edit
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
            this.lbTen_Kv = new RosySystem.Control.rsLabel();
            this.lbMa_Kv = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.cboPort_Name = new RosySystem.Control.rsComboBox();
            this.txtBaudRate = new RosySystem.Control.rsComboBox();
            this.cboParity = new RosySystem.Control.rsComboBox();
            this.cboDataBits = new RosySystem.Control.rsComboBox();
            this.cboHandshake = new RosySystem.Control.rsComboBox();
            this.cboStopBits = new RosySystem.Control.rsComboBox();
            this.rsLabel7 = new RosySystem.Control.rsLabel();
            this.txtHost_IP = new RosySystem.Control.rsIPAddress();
            this.cboPrint_Barcode = new RosySystem.Control.rsComboBox();
            this.txtDescription = new RosySystem.Control.rsTextBox();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.rsLabel9 = new RosySystem.Control.rsLabel();
            this.rsLabel10 = new RosySystem.Control.rsLabel();
            this.numZero_Coefficient = new RosySystem.Control.rsNumericUpdown();
            this.numSpan_Coefficient = new RosySystem.Control.rsNumericUpdown();
            this.numNet_Weight_Min = new RosySystem.Control.rsNumericUpdown();
            this.numStable_Count = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel11 = new RosySystem.Control.rsLabel();
            this.rsLabel12 = new RosySystem.Control.rsLabel();
            this.numNet_Weight_Max = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel13 = new RosySystem.Control.rsLabel();
            this.numSlopes_Down = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel14 = new RosySystem.Control.rsLabel();
            this.numSlopes_Up = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel15 = new RosySystem.Control.rsLabel();
            this.numNum_Ticket_Print = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel16 = new RosySystem.Control.rsLabel();
            this.cboPrint_Report = new RosySystem.Control.rsComboBox();
            this.rsLabel17 = new RosySystem.Control.rsLabel();
            this.cboPrint_Eticket = new RosySystem.Control.rsComboBox();
            this.rsLabel18 = new RosySystem.Control.rsLabel();
            this.txtEquip_ID = new RosySystem.Control.rsTextBox();
            this.cboStatus_Input_Type = new RosySystem.Control.rsComboBox();
            this.rsLabel19 = new RosySystem.Control.rsLabel();
            this.txtSTX = new RosySystem.Control.rsTextBox();
            this.rsLabel20 = new RosySystem.Control.rsLabel();
            this.txtETX = new RosySystem.Control.rsTextBox();
            this.rsLabel21 = new RosySystem.Control.rsLabel();
            this.txtValue_Len = new RosySystem.Control.rsTextBox();
            this.rsLabel22 = new RosySystem.Control.rsLabel();
            this.cboPLC_Port_Name = new RosySystem.Control.rsComboBox();
            this.rsLabel23 = new RosySystem.Control.rsLabel();
            this.numStable_Time = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel24 = new RosySystem.Control.rsLabel();
            this.numStable_Range = new RosySystem.Control.rsNumericUpdown();
            this.rsLabel25 = new RosySystem.Control.rsLabel();
            this.txtCan = new RosySystem.Control.rsTextBoxEnum();
            this.txtNote = new RosySystem.Control.rsTextBox();
            this.rsLabel26 = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZero_Coefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpan_Coefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNet_Weight_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStable_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNet_Weight_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlopes_Down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlopes_Up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNum_Ticket_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStable_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStable_Range)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(393, 510);
            this.btgAccept.Size = new System.Drawing.Size(181, 44);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(565, 498);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtNote);
            this.Page1.Controls.Add(this.rsLabel26);
            this.Page1.Controls.Add(this.txtCan);
            this.Page1.Controls.Add(this.numStable_Range);
            this.Page1.Controls.Add(this.rsLabel25);
            this.Page1.Controls.Add(this.numStable_Time);
            this.Page1.Controls.Add(this.rsLabel24);
            this.Page1.Controls.Add(this.cboPLC_Port_Name);
            this.Page1.Controls.Add(this.rsLabel23);
            this.Page1.Controls.Add(this.txtValue_Len);
            this.Page1.Controls.Add(this.rsLabel22);
            this.Page1.Controls.Add(this.txtETX);
            this.Page1.Controls.Add(this.rsLabel21);
            this.Page1.Controls.Add(this.txtSTX);
            this.Page1.Controls.Add(this.rsLabel20);
            this.Page1.Controls.Add(this.cboStatus_Input_Type);
            this.Page1.Controls.Add(this.rsLabel19);
            this.Page1.Controls.Add(this.txtEquip_ID);
            this.Page1.Controls.Add(this.cboPrint_Eticket);
            this.Page1.Controls.Add(this.rsLabel18);
            this.Page1.Controls.Add(this.cboPrint_Report);
            this.Page1.Controls.Add(this.rsLabel17);
            this.Page1.Controls.Add(this.numNum_Ticket_Print);
            this.Page1.Controls.Add(this.rsLabel16);
            this.Page1.Controls.Add(this.numSlopes_Down);
            this.Page1.Controls.Add(this.rsLabel14);
            this.Page1.Controls.Add(this.numSlopes_Up);
            this.Page1.Controls.Add(this.rsLabel15);
            this.Page1.Controls.Add(this.numNet_Weight_Max);
            this.Page1.Controls.Add(this.rsLabel13);
            this.Page1.Controls.Add(this.numNet_Weight_Min);
            this.Page1.Controls.Add(this.numStable_Count);
            this.Page1.Controls.Add(this.rsLabel11);
            this.Page1.Controls.Add(this.rsLabel12);
            this.Page1.Controls.Add(this.numSpan_Coefficient);
            this.Page1.Controls.Add(this.numZero_Coefficient);
            this.Page1.Controls.Add(this.rsLabel10);
            this.Page1.Controls.Add(this.rsLabel9);
            this.Page1.Controls.Add(this.rsLabel8);
            this.Page1.Controls.Add(this.cboPrint_Barcode);
            this.Page1.Controls.Add(this.txtHost_IP);
            this.Page1.Controls.Add(this.rsLabel7);
            this.Page1.Controls.Add(this.cboStopBits);
            this.Page1.Controls.Add(this.cboHandshake);
            this.Page1.Controls.Add(this.cboDataBits);
            this.Page1.Controls.Add(this.cboParity);
            this.Page1.Controls.Add(this.txtBaudRate);
            this.Page1.Controls.Add(this.cboPort_Name);
            this.Page1.Controls.Add(this.rsLabel6);
            this.Page1.Controls.Add(this.rsLabel5);
            this.Page1.Controls.Add(this.rsLabel4);
            this.Page1.Controls.Add(this.rsLabel3);
            this.Page1.Controls.Add(this.rsLabel2);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.txtDescription);
            this.Page1.Controls.Add(this.lbTen_Kv);
            this.Page1.Controls.Add(this.lbMa_Kv);
            this.Page1.Size = new System.Drawing.Size(557, 472);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(557, 472);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 522);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 531);
            this.lblLog.Text = "";
            // 
            // lbTen_Kv
            // 
            this.lbTen_Kv.AutoEllipsis = true;
            this.lbTen_Kv.AutoSize = true;
            this.lbTen_Kv.Location = new System.Drawing.Point(43, 62);
            this.lbTen_Kv.Name = "lbTen_Kv";
            this.lbTen_Kv.Size = new System.Drawing.Size(60, 13);
            this.lbTen_Kv.TabIndex = 19;
            this.lbTen_Kv.Tag = "";
            this.lbTen_Kv.Text = "Description";
            this.lbTen_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Kv
            // 
            this.lbMa_Kv.AutoEllipsis = true;
            this.lbMa_Kv.AutoSize = true;
            this.lbMa_Kv.Location = new System.Drawing.Point(43, 19);
            this.lbMa_Kv.Name = "lbMa_Kv";
            this.lbMa_Kv.Size = new System.Drawing.Size(42, 13);
            this.lbMa_Kv.TabIndex = 20;
            this.lbMa_Kv.Tag = "";
            this.lbMa_Kv.Text = "Host IP";
            this.lbMa_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(43, 87);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(55, 13);
            this.rsLabel1.TabIndex = 22;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Port name";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(43, 109);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(55, 13);
            this.rsLabel2.TabIndex = 24;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "BaudRate";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(43, 132);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(33, 13);
            this.rsLabel3.TabIndex = 26;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Parity";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(275, 87);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(47, 13);
            this.rsLabel4.TabIndex = 28;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "DataBits";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(275, 133);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(62, 13);
            this.rsLabel5.TabIndex = 30;
            this.rsLabel5.Tag = "";
            this.rsLabel5.Text = "Handshake";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(275, 110);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(46, 13);
            this.rsLabel6.TabIndex = 32;
            this.rsLabel6.Tag = "";
            this.rsLabel6.Text = "StopBits";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPort_Name
            // 
            this.cboPort_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort_Name.FormattingEnabled = true;
            this.cboPort_Name.Location = new System.Drawing.Point(164, 83);
            this.cboPort_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboPort_Name.Name = "cboPort_Name";
            this.cboPort_Name.Size = new System.Drawing.Size(87, 21);
            this.cboPort_Name.TabIndex = 4;
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBaudRate.FormattingEnabled = true;
            this.txtBaudRate.Location = new System.Drawing.Point(164, 106);
            this.txtBaudRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(87, 21);
            this.txtBaudRate.TabIndex = 5;
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(164, 129);
            this.cboParity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(87, 21);
            this.cboParity.TabIndex = 6;
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(426, 83);
            this.cboDataBits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(87, 21);
            this.cboDataBits.TabIndex = 7;
            // 
            // cboHandshake
            // 
            this.cboHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHandshake.FormattingEnabled = true;
            this.cboHandshake.Location = new System.Drawing.Point(426, 129);
            this.cboHandshake.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboHandshake.Name = "cboHandshake";
            this.cboHandshake.Size = new System.Drawing.Size(87, 21);
            this.cboHandshake.TabIndex = 9;
            // 
            // cboStopBits
            // 
            this.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(426, 106);
            this.cboStopBits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(87, 21);
            this.cboStopBits.TabIndex = 8;
            // 
            // rsLabel7
            // 
            this.rsLabel7.AutoEllipsis = true;
            this.rsLabel7.AutoSize = true;
            this.rsLabel7.Location = new System.Drawing.Point(43, 332);
            this.rsLabel7.Name = "rsLabel7";
            this.rsLabel7.Size = new System.Drawing.Size(70, 13);
            this.rsLabel7.TabIndex = 42;
            this.rsLabel7.Tag = "";
            this.rsLabel7.Text = "Print barcode";
            this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHost_IP
            // 
            this.txtHost_IP.AllowInternalTab = false;
            this.txtHost_IP.AutoHeight = true;
            this.txtHost_IP.BackColor = System.Drawing.SystemColors.Window;
            this.txtHost_IP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHost_IP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHost_IP.Location = new System.Drawing.Point(164, 15);
            this.txtHost_IP.MinimumSize = new System.Drawing.Size(87, 20);
            this.txtHost_IP.Name = "txtHost_IP";
            this.txtHost_IP.ReadOnly = false;
            this.txtHost_IP.Size = new System.Drawing.Size(87, 20);
            this.txtHost_IP.TabIndex = 0;
            this.txtHost_IP.Text = "...";
            // 
            // cboPrint_Barcode
            // 
            this.cboPrint_Barcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrint_Barcode.FormattingEnabled = true;
            this.cboPrint_Barcode.Location = new System.Drawing.Point(164, 329);
            this.cboPrint_Barcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboPrint_Barcode.Name = "cboPrint_Barcode";
            this.cboPrint_Barcode.Size = new System.Drawing.Size(349, 21);
            this.cboPrint_Barcode.TabIndex = 26;
            // 
            // txtDescription
            // 
            this.txtDescription.AutoDropDown = null;
            this.txtDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.Location = new System.Drawing.Point(164, 61);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDescription.MinimumSize = new System.Drawing.Size(87, 20);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(349, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(43, 41);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(48, 13);
            this.rsLabel8.TabIndex = 44;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Equip ID";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel9
            // 
            this.rsLabel9.AutoEllipsis = true;
            this.rsLabel9.AutoSize = true;
            this.rsLabel9.Location = new System.Drawing.Point(43, 187);
            this.rsLabel9.Name = "rsLabel9";
            this.rsLabel9.Size = new System.Drawing.Size(105, 13);
            this.rsLabel9.TabIndex = 45;
            this.rsLabel9.Tag = "";
            this.rsLabel9.Text = "Hệ số bù cộng(Zero)";
            this.rsLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel10
            // 
            this.rsLabel10.AutoEllipsis = true;
            this.rsLabel10.AutoSize = true;
            this.rsLabel10.Location = new System.Drawing.Point(275, 188);
            this.rsLabel10.Name = "rsLabel10";
            this.rsLabel10.Size = new System.Drawing.Size(108, 13);
            this.rsLabel10.TabIndex = 46;
            this.rsLabel10.Tag = "";
            this.rsLabel10.Text = "Hệ số bù nhân(Span)";
            this.rsLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numZero_Coefficient
            // 
            this.numZero_Coefficient.Location = new System.Drawing.Point(164, 185);
            this.numZero_Coefficient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numZero_Coefficient.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numZero_Coefficient.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numZero_Coefficient.Name = "numZero_Coefficient";
            this.numZero_Coefficient.Size = new System.Drawing.Size(87, 20);
            this.numZero_Coefficient.TabIndex = 11;
            this.numZero_Coefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numSpan_Coefficient
            // 
            this.numSpan_Coefficient.DecimalPlaces = 4;
            this.numSpan_Coefficient.Location = new System.Drawing.Point(426, 185);
            this.numSpan_Coefficient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSpan_Coefficient.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSpan_Coefficient.Name = "numSpan_Coefficient";
            this.numSpan_Coefficient.Size = new System.Drawing.Size(87, 20);
            this.numSpan_Coefficient.TabIndex = 12;
            this.numSpan_Coefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numNet_Weight_Min
            // 
            this.numNet_Weight_Min.Location = new System.Drawing.Point(164, 207);
            this.numNet_Weight_Min.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNet_Weight_Min.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNet_Weight_Min.Name = "numNet_Weight_Min";
            this.numNet_Weight_Min.Size = new System.Drawing.Size(87, 20);
            this.numNet_Weight_Min.TabIndex = 13;
            this.numNet_Weight_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numStable_Count
            // 
            this.numStable_Count.Location = new System.Drawing.Point(164, 251);
            this.numStable_Count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStable_Count.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStable_Count.Name = "numStable_Count";
            this.numStable_Count.Size = new System.Drawing.Size(87, 20);
            this.numStable_Count.TabIndex = 17;
            this.numStable_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel11
            // 
            this.rsLabel11.AutoEllipsis = true;
            this.rsLabel11.AutoSize = true;
            this.rsLabel11.Location = new System.Drawing.Point(43, 209);
            this.rsLabel11.Name = "rsLabel11";
            this.rsLabel11.Size = new System.Drawing.Size(111, 13);
            this.rsLabel11.TabIndex = 50;
            this.rsLabel11.Tag = "";
            this.rsLabel11.Text = "KL Sản phẩm tối thiểu";
            this.rsLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel12
            // 
            this.rsLabel12.AutoEllipsis = true;
            this.rsLabel12.AutoSize = true;
            this.rsLabel12.Location = new System.Drawing.Point(43, 253);
            this.rsLabel12.Name = "rsLabel12";
            this.rsLabel12.Size = new System.Drawing.Size(97, 13);
            this.rsLabel12.TabIndex = 49;
            this.rsLabel12.Tag = "";
            this.rsLabel12.Text = "Số lần cân ổn định";
            this.rsLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNet_Weight_Max
            // 
            this.numNet_Weight_Max.Location = new System.Drawing.Point(426, 207);
            this.numNet_Weight_Max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNet_Weight_Max.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNet_Weight_Max.Name = "numNet_Weight_Max";
            this.numNet_Weight_Max.Size = new System.Drawing.Size(87, 20);
            this.numNet_Weight_Max.TabIndex = 14;
            this.numNet_Weight_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel13
            // 
            this.rsLabel13.AutoEllipsis = true;
            this.rsLabel13.AutoSize = true;
            this.rsLabel13.Location = new System.Drawing.Point(275, 210);
            this.rsLabel13.Name = "rsLabel13";
            this.rsLabel13.Size = new System.Drawing.Size(101, 13);
            this.rsLabel13.TabIndex = 53;
            this.rsLabel13.Tag = "";
            this.rsLabel13.Text = "KL Sản phẩm tối đa";
            this.rsLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSlopes_Down
            // 
            this.numSlopes_Down.Location = new System.Drawing.Point(426, 229);
            this.numSlopes_Down.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSlopes_Down.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSlopes_Down.Name = "numSlopes_Down";
            this.numSlopes_Down.Size = new System.Drawing.Size(87, 20);
            this.numSlopes_Down.TabIndex = 16;
            this.numSlopes_Down.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel14
            // 
            this.rsLabel14.AutoEllipsis = true;
            this.rsLabel14.AutoSize = true;
            this.rsLabel14.Location = new System.Drawing.Point(275, 232);
            this.rsLabel14.Name = "rsLabel14";
            this.rsLabel14.Size = new System.Drawing.Size(134, 13);
            this.rsLabel14.TabIndex = 57;
            this.rsLabel14.Tag = "";
            this.rsLabel14.Text = "Sườn xuống lấy số liệu cân";
            this.rsLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSlopes_Up
            // 
            this.numSlopes_Up.Location = new System.Drawing.Point(164, 229);
            this.numSlopes_Up.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSlopes_Up.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSlopes_Up.Name = "numSlopes_Up";
            this.numSlopes_Up.Size = new System.Drawing.Size(87, 20);
            this.numSlopes_Up.TabIndex = 15;
            this.numSlopes_Up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel15
            // 
            this.rsLabel15.AutoEllipsis = true;
            this.rsLabel15.AutoSize = true;
            this.rsLabel15.Location = new System.Drawing.Point(43, 231);
            this.rsLabel15.Name = "rsLabel15";
            this.rsLabel15.Size = new System.Drawing.Size(119, 13);
            this.rsLabel15.TabIndex = 55;
            this.rsLabel15.Tag = "";
            this.rsLabel15.Text = "Sườn lên lấy số liệu cân";
            this.rsLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNum_Ticket_Print
            // 
            this.numNum_Ticket_Print.Location = new System.Drawing.Point(164, 273);
            this.numNum_Ticket_Print.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numNum_Ticket_Print.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNum_Ticket_Print.Name = "numNum_Ticket_Print";
            this.numNum_Ticket_Print.Size = new System.Drawing.Size(87, 20);
            this.numNum_Ticket_Print.TabIndex = 20;
            this.numNum_Ticket_Print.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel16
            // 
            this.rsLabel16.AutoEllipsis = true;
            this.rsLabel16.AutoSize = true;
            this.rsLabel16.Location = new System.Drawing.Point(43, 277);
            this.rsLabel16.Name = "rsLabel16";
            this.rsLabel16.Size = new System.Drawing.Size(77, 13);
            this.rsLabel16.TabIndex = 59;
            this.rsLabel16.Tag = "";
            this.rsLabel16.Text = "Số lần in ticket";
            this.rsLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPrint_Report
            // 
            this.cboPrint_Report.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrint_Report.FormattingEnabled = true;
            this.cboPrint_Report.Location = new System.Drawing.Point(164, 352);
            this.cboPrint_Report.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboPrint_Report.Name = "cboPrint_Report";
            this.cboPrint_Report.Size = new System.Drawing.Size(349, 21);
            this.cboPrint_Report.TabIndex = 27;
            // 
            // rsLabel17
            // 
            this.rsLabel17.AutoEllipsis = true;
            this.rsLabel17.AutoSize = true;
            this.rsLabel17.Location = new System.Drawing.Point(43, 355);
            this.rsLabel17.Name = "rsLabel17";
            this.rsLabel17.Size = new System.Drawing.Size(58, 13);
            this.rsLabel17.TabIndex = 61;
            this.rsLabel17.Tag = "";
            this.rsLabel17.Text = "Print report";
            this.rsLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPrint_Eticket
            // 
            this.cboPrint_Eticket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrint_Eticket.FormattingEnabled = true;
            this.cboPrint_Eticket.Location = new System.Drawing.Point(164, 375);
            this.cboPrint_Eticket.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboPrint_Eticket.Name = "cboPrint_Eticket";
            this.cboPrint_Eticket.Size = new System.Drawing.Size(349, 21);
            this.cboPrint_Eticket.TabIndex = 28;
            // 
            // rsLabel18
            // 
            this.rsLabel18.AutoEllipsis = true;
            this.rsLabel18.AutoSize = true;
            this.rsLabel18.Location = new System.Drawing.Point(43, 378);
            this.rsLabel18.Name = "rsLabel18";
            this.rsLabel18.Size = new System.Drawing.Size(64, 13);
            this.rsLabel18.TabIndex = 63;
            this.rsLabel18.Tag = "";
            this.rsLabel18.Text = "Print Eticket";
            this.rsLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEquip_ID
            // 
            this.txtEquip_ID.AutoDropDown = null;
            this.txtEquip_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEquip_ID.Location = new System.Drawing.Point(164, 38);
            this.txtEquip_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtEquip_ID.Name = "txtEquip_ID";
            this.txtEquip_ID.Size = new System.Drawing.Size(170, 20);
            this.txtEquip_ID.TabIndex = 1;
            // 
            // cboStatus_Input_Type
            // 
            this.cboStatus_Input_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus_Input_Type.FormattingEnabled = true;
            this.cboStatus_Input_Type.Items.AddRange(new object[] {
            "",
            "BANPHIM",
            "CANDTTUDONG"});
            this.cboStatus_Input_Type.Location = new System.Drawing.Point(164, 398);
            this.cboStatus_Input_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboStatus_Input_Type.Name = "cboStatus_Input_Type";
            this.cboStatus_Input_Type.Size = new System.Drawing.Size(349, 21);
            this.cboStatus_Input_Type.TabIndex = 29;
            // 
            // rsLabel19
            // 
            this.rsLabel19.AutoEllipsis = true;
            this.rsLabel19.AutoSize = true;
            this.rsLabel19.Location = new System.Drawing.Point(43, 401);
            this.rsLabel19.Name = "rsLabel19";
            this.rsLabel19.Size = new System.Drawing.Size(55, 13);
            this.rsLabel19.TabIndex = 65;
            this.rsLabel19.Tag = "";
            this.rsLabel19.Text = "Kiểu nhập";
            this.rsLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSTX
            // 
            this.txtSTX.AutoDropDown = null;
            this.txtSTX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSTX.Location = new System.Drawing.Point(164, 301);
            this.txtSTX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSTX.Name = "txtSTX";
            this.txtSTX.Size = new System.Drawing.Size(87, 20);
            this.txtSTX.TabIndex = 23;
            // 
            // rsLabel20
            // 
            this.rsLabel20.AutoEllipsis = true;
            this.rsLabel20.AutoSize = true;
            this.rsLabel20.Location = new System.Drawing.Point(45, 304);
            this.rsLabel20.Name = "rsLabel20";
            this.rsLabel20.Size = new System.Drawing.Size(28, 13);
            this.rsLabel20.TabIndex = 67;
            this.rsLabel20.Tag = "";
            this.rsLabel20.Text = "STX";
            this.rsLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtETX
            // 
            this.txtETX.AutoDropDown = null;
            this.txtETX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtETX.Location = new System.Drawing.Point(291, 301);
            this.txtETX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtETX.Name = "txtETX";
            this.txtETX.Size = new System.Drawing.Size(73, 20);
            this.txtETX.TabIndex = 24;
            // 
            // rsLabel21
            // 
            this.rsLabel21.AutoEllipsis = true;
            this.rsLabel21.AutoSize = true;
            this.rsLabel21.Location = new System.Drawing.Point(258, 304);
            this.rsLabel21.Name = "rsLabel21";
            this.rsLabel21.Size = new System.Drawing.Size(28, 13);
            this.rsLabel21.TabIndex = 69;
            this.rsLabel21.Tag = "";
            this.rsLabel21.Text = "ETX";
            this.rsLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValue_Len
            // 
            this.txtValue_Len.AutoDropDown = null;
            this.txtValue_Len.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValue_Len.Location = new System.Drawing.Point(426, 301);
            this.txtValue_Len.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtValue_Len.Name = "txtValue_Len";
            this.txtValue_Len.Size = new System.Drawing.Size(87, 20);
            this.txtValue_Len.TabIndex = 25;
            // 
            // rsLabel22
            // 
            this.rsLabel22.AutoEllipsis = true;
            this.rsLabel22.AutoSize = true;
            this.rsLabel22.Location = new System.Drawing.Point(369, 304);
            this.rsLabel22.Name = "rsLabel22";
            this.rsLabel22.Size = new System.Drawing.Size(55, 13);
            this.rsLabel22.TabIndex = 71;
            this.rsLabel22.Tag = "";
            this.rsLabel22.Text = "Value Len";
            this.rsLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPLC_Port_Name
            // 
            this.cboPLC_Port_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPLC_Port_Name.FormattingEnabled = true;
            this.cboPLC_Port_Name.Location = new System.Drawing.Point(164, 157);
            this.cboPLC_Port_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboPLC_Port_Name.Name = "cboPLC_Port_Name";
            this.cboPLC_Port_Name.Size = new System.Drawing.Size(87, 21);
            this.cboPLC_Port_Name.TabIndex = 10;
            this.cboPLC_Port_Name.Visible = false;
            // 
            // rsLabel23
            // 
            this.rsLabel23.AutoEllipsis = true;
            this.rsLabel23.AutoSize = true;
            this.rsLabel23.Location = new System.Drawing.Point(43, 161);
            this.rsLabel23.Name = "rsLabel23";
            this.rsLabel23.Size = new System.Drawing.Size(76, 13);
            this.rsLabel23.TabIndex = 73;
            this.rsLabel23.Tag = "";
            this.rsLabel23.Text = "PLC COM Port";
            this.rsLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rsLabel23.Visible = false;
            // 
            // numStable_Time
            // 
            this.numStable_Time.Location = new System.Drawing.Point(426, 251);
            this.numStable_Time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStable_Time.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStable_Time.Name = "numStable_Time";
            this.numStable_Time.Size = new System.Drawing.Size(87, 20);
            this.numStable_Time.TabIndex = 18;
            this.numStable_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel24
            // 
            this.rsLabel24.AutoEllipsis = true;
            this.rsLabel24.AutoSize = true;
            this.rsLabel24.ForeColor = System.Drawing.Color.Red;
            this.rsLabel24.Location = new System.Drawing.Point(275, 255);
            this.rsLabel24.Name = "rsLabel24";
            this.rsLabel24.Size = new System.Drawing.Size(147, 13);
            this.rsLabel24.TabIndex = 75;
            this.rsLabel24.Tag = "";
            this.rsLabel24.Text = "Thời gian ổn đinh (s) - 60-80T";
            this.rsLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numStable_Range
            // 
            this.numStable_Range.Location = new System.Drawing.Point(426, 273);
            this.numStable_Range.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStable_Range.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStable_Range.Name = "numStable_Range";
            this.numStable_Range.Size = new System.Drawing.Size(87, 20);
            this.numStable_Range.TabIndex = 22;
            this.numStable_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rsLabel25
            // 
            this.rsLabel25.AutoEllipsis = true;
            this.rsLabel25.AutoSize = true;
            this.rsLabel25.ForeColor = System.Drawing.Color.Red;
            this.rsLabel25.Location = new System.Drawing.Point(275, 277);
            this.rsLabel25.Name = "rsLabel25";
            this.rsLabel25.Size = new System.Drawing.Size(147, 13);
            this.rsLabel25.TabIndex = 77;
            this.rsLabel25.Tag = "";
            this.rsLabel25.Text = "Biên độ ổn định (kg) - 60-80T";
            this.rsLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCan
            // 
            this.txtCan.AutoDropDown = null;
            this.txtCan.InputMask = ",CANA,CANB";
            this.txtCan.Location = new System.Drawing.Point(333, 38);
            this.txtCan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtCan.Name = "txtCan";
            this.txtCan.Size = new System.Drawing.Size(45, 20);
            this.txtCan.TabIndex = 2;
            // 
            // txtNote
            // 
            this.txtNote.AutoDropDown = null;
            this.txtNote.BackColor = System.Drawing.SystemColors.Window;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.Location = new System.Drawing.Point(164, 421);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNote.MinimumSize = new System.Drawing.Size(87, 20);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(349, 20);
            this.txtNote.TabIndex = 78;
            // 
            // rsLabel26
            // 
            this.rsLabel26.AutoEllipsis = true;
            this.rsLabel26.AutoSize = true;
            this.rsLabel26.Location = new System.Drawing.Point(43, 422);
            this.rsLabel26.Name = "rsLabel26";
            this.rsLabel26.Size = new System.Drawing.Size(44, 13);
            this.rsLabel26.TabIndex = 79;
            this.rsLabel26.Tag = "";
            this.rsLabel26.Text = "Ghi chú";
            this.rsLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEquipmentInfo_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 562);
            this.Name = "frmEquipmentInfo_Edit";
            this.Object_ID = "EQUIPMENT";
            this.Tag = "frmEquipment, F2, F3, F8, ESC";
            this.Text = "frmEquipment Info";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZero_Coefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpan_Coefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNet_Weight_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStable_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNet_Weight_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlopes_Down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlopes_Up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNum_Ticket_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStable_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStable_Range)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsLabel lbTen_Kv;
		private RosySystem.Control.rsLabel lbMa_Kv;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsLabel rsLabel5;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsComboBox cboStopBits;
		private RosySystem.Control.rsComboBox cboHandshake;
		private RosySystem.Control.rsComboBox cboDataBits;
		private RosySystem.Control.rsComboBox cboParity;
		private RosySystem.Control.rsComboBox txtBaudRate;
		private RosySystem.Control.rsComboBox cboPort_Name;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsIPAddress txtHost_IP;
		private RosySystem.Control.rsComboBox cboPrint_Barcode;
		private RosySystem.Control.rsLabel rsLabel8;
		private RosySystem.Control.rsTextBox txtDescription;
		private RosySystem.Control.rsNumericUpdown numSpan_Coefficient;
		private RosySystem.Control.rsNumericUpdown numZero_Coefficient;
		private RosySystem.Control.rsLabel rsLabel10;
		private RosySystem.Control.rsLabel rsLabel9;
		private RosySystem.Control.rsNumericUpdown numSlopes_Down;
		private RosySystem.Control.rsLabel rsLabel14;
		private RosySystem.Control.rsNumericUpdown numSlopes_Up;
		private RosySystem.Control.rsLabel rsLabel15;
		private RosySystem.Control.rsNumericUpdown numNet_Weight_Max;
		private RosySystem.Control.rsLabel rsLabel13;
		private RosySystem.Control.rsNumericUpdown numNet_Weight_Min;
		private RosySystem.Control.rsNumericUpdown numStable_Count;
		private RosySystem.Control.rsLabel rsLabel11;
		private RosySystem.Control.rsLabel rsLabel12;
		private RosySystem.Control.rsNumericUpdown numNum_Ticket_Print;
		private RosySystem.Control.rsLabel rsLabel16;
		private RosySystem.Control.rsComboBox cboPrint_Eticket;
		private RosySystem.Control.rsLabel rsLabel18;
		private RosySystem.Control.rsComboBox cboPrint_Report;
		private RosySystem.Control.rsLabel rsLabel17;
		private RosySystem.Control.rsTextBox txtEquip_ID;
		private RosySystem.Control.rsComboBox cboStatus_Input_Type;
		private RosySystem.Control.rsLabel rsLabel19;
		private RosySystem.Control.rsTextBox txtETX;
		private RosySystem.Control.rsLabel rsLabel21;
		private RosySystem.Control.rsTextBox txtSTX;
		private RosySystem.Control.rsLabel rsLabel20;
		private RosySystem.Control.rsTextBox txtValue_Len;
		private RosySystem.Control.rsLabel rsLabel22;
		private RosySystem.Control.rsComboBox cboPLC_Port_Name;
		private RosySystem.Control.rsLabel rsLabel23;
		private RosySystem.Control.rsNumericUpdown numStable_Range;
		private RosySystem.Control.rsLabel rsLabel25;
		private RosySystem.Control.rsNumericUpdown numStable_Time;
		private RosySystem.Control.rsLabel rsLabel24;
		private RosySystem.Control.rsTextBoxEnum txtCan;
        private RosySystem.Control.rsTextBox txtNote;
        private RosySystem.Control.rsLabel rsLabel26;

	}
}