namespace RosyModule.ScaleBarcode
{
	partial class frmQuery_Barcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.btPrint = new RosySystem.Customize.btPrint();
            this.txtMa_Vt_Sp = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
            this.rsTextBox1 = new RosySystem.Control.rsTextBox();
            this.txtBarcode = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.btFilter = new RosySystem.Customize.btFilter();
            this.lbtTen_Vt_Sp = new RosySystem.Control.rsLabelName();
            this.dgvQueryBarcode = new RosySystem.Control.rsDataGridView();
            this.btPrint_Barcode = new RosySystem.Customize.btPrint();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel1.SuspendLayout();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // rsSplitContainer1
            // 
            this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.rsSplitContainer1.Name = "rsSplitContainer1";
            this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer1.Panel1
            // 
            this.rsSplitContainer1.Panel1.Controls.Add(this.btPrint_Barcode);
            this.rsSplitContainer1.Panel1.Controls.Add(this.btPrint);
            this.rsSplitContainer1.Panel1.Controls.Add(this.txtMa_Vt_Sp);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel1);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel4);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel6);
            this.rsSplitContainer1.Panel1.Controls.Add(this.dteNgay_Ct1);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsTextBox1);
            this.rsSplitContainer1.Panel1.Controls.Add(this.txtBarcode);
            this.rsSplitContainer1.Panel1.Controls.Add(this.rsLabel3);
            this.rsSplitContainer1.Panel1.Controls.Add(this.btFilter);
            this.rsSplitContainer1.Panel1.Controls.Add(this.lbtTen_Vt_Sp);
            // 
            // rsSplitContainer1.Panel2
            // 
            this.rsSplitContainer1.Panel2.Controls.Add(this.dgvQueryBarcode);
            this.rsSplitContainer1.Size = new System.Drawing.Size(778, 556);
            this.rsSplitContainer1.SplitterDistance = 84;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // btPrint
            // 
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "Print.png";
            this.btPrint.Location = new System.Drawing.Point(481, 28);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(80, 31);
            this.btPrint.TabIndex = 12;
            this.btPrint.Tag = "";
            this.btPrint.Text = "&In";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // txtMa_Vt_Sp
            // 
            this.txtMa_Vt_Sp.AutoDropDown = null;
            this.txtMa_Vt_Sp.Location = new System.Drawing.Point(280, 58);
            this.txtMa_Vt_Sp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt_Sp.Name = "txtMa_Vt_Sp";
            this.txtMa_Vt_Sp.Size = new System.Drawing.Size(108, 20);
            this.txtMa_Vt_Sp.TabIndex = 4;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(24, 11);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(46, 13);
            this.rsLabel1.TabIndex = 0;
            this.rsLabel1.Text = "Từ ngày";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(24, 61);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(58, 13);
            this.rsLabel4.TabIndex = 11;
            this.rsLabel4.Text = "Product ID";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel6.Location = new System.Drawing.Point(24, 38);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(54, 13);
            this.rsLabel6.TabIndex = 11;
            this.rsLabel6.Text = "Barcode";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(94, 8);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // rsTextBox1
            // 
            this.rsTextBox1.AutoDropDown = null;
            this.rsTextBox1.Location = new System.Drawing.Point(94, 58);
            this.rsTextBox1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.rsTextBox1.Name = "rsTextBox1";
            this.rsTextBox1.Size = new System.Drawing.Size(100, 20);
            this.rsTextBox1.TabIndex = 3;
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoDropDown = null;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(94, 30);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(294, 26);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(204, 62);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(71, 13);
            this.rsLabel3.TabIndex = 9;
            this.rsLabel3.Text = "Mã sản phẩm";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btFilter
            // 
            this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFilter.ImageKey = "Filter.png";
            this.btFilter.Location = new System.Drawing.Point(393, 28);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(86, 31);
            this.btFilter.TabIndex = 5;
            this.btFilter.Tag = "";
            this.btFilter.Text = "&Lọc";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // lbtTen_Vt_Sp
            // 
            this.lbtTen_Vt_Sp.AutoEllipsis = true;
            this.lbtTen_Vt_Sp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Sp.Location = new System.Drawing.Point(393, 59);
            this.lbtTen_Vt_Sp.Name = "lbtTen_Vt_Sp";
            this.lbtTen_Vt_Sp.Size = new System.Drawing.Size(164, 16);
            this.lbtTen_Vt_Sp.TabIndex = 7;
            this.lbtTen_Vt_Sp.Text = "Tên sản phẩm";
            this.lbtTen_Vt_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvQueryBarcode
            // 
            this.dgvQueryBarcode.AllowUserToAddRows = false;
            this.dgvQueryBarcode.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvQueryBarcode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQueryBarcode.BackgroundColor = System.Drawing.Color.White;
            this.dgvQueryBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQueryBarcode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQueryBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQueryBarcode.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQueryBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueryBarcode.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvQueryBarcode.Location = new System.Drawing.Point(0, 0);
            this.dgvQueryBarcode.MultiSelect = false;
            this.dgvQueryBarcode.Name = "dgvQueryBarcode";
            this.dgvQueryBarcode.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQueryBarcode.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvQueryBarcode.Size = new System.Drawing.Size(778, 468);
            this.dgvQueryBarcode.strZone = "";
            this.dgvQueryBarcode.TabIndex = 0;
            // 
            // btPrint_Barcode
            // 
            this.btPrint_Barcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint_Barcode.ImageKey = "Print.png";
            this.btPrint_Barcode.Location = new System.Drawing.Point(563, 29);
            this.btPrint_Barcode.Name = "btPrint_Barcode";
            this.btPrint_Barcode.Size = new System.Drawing.Size(80, 31);
            this.btPrint_Barcode.TabIndex = 12;
            this.btPrint_Barcode.Tag = "";
            this.btPrint_Barcode.Text = "&In Etiket";
            this.btPrint_Barcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint_Barcode.UseVisualStyleBackColor = true;
            // 
            // frmQuery_Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.rsSplitContainer1);
            this.Name = "frmQuery_Barcode";
            this.Object_ID = "QUERY_PH_SCALE";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Tag = "frmQuery_Barcode";
            this.Text = "frmQuery_Barcode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel1.ResumeLayout(false);
            this.rsSplitContainer1.Panel1.PerformLayout();
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryBarcode)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
		private RosySystem.Control.rsDateTime dteNgay_Ct1;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Control.rsTextBox txtMa_Vt_Sp;
		private RosySystem.Control.rsLabelName lbtTen_Vt_Sp;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsTextBox txtBarcode;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsDataGridView dgvQueryBarcode;
		private RosySystem.Control.rsLabel rsLabel4;
		private RosySystem.Control.rsTextBox rsTextBox1;
        private RosySystem.Customize.btPrint btPrint;
        private RosySystem.Customize.btPrint btPrint_Barcode;
    }
}