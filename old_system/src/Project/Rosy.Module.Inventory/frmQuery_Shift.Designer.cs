namespace RosyModule.Inventory
{
	partial class frmQuery_Shift
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuery_Shift));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
			this.rsPanel1 = new RosySystem.Control.rsPanel();
			this.btFilter = new RosySystem.Customize.btFilter();
			this.dteNgay_Ct2 = new RosySystem.Control.rsDateTime();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.dteNgay_Ct1 = new RosySystem.Control.rsDateTime();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.btExit = new RosySystem.Customize.btExit();
			this.btNew = new RosySystem.Customize.btNew();
			this.btContinues = new RosySystem.Customize.btExit();
			this.rsPanel2 = new RosySystem.Control.rsPanel();
			this.dgvDmCa = new RosySystem.Control.rsDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
			this.rsSplitContainer1.Panel1.SuspendLayout();
			this.rsSplitContainer1.Panel2.SuspendLayout();
			this.rsSplitContainer1.SuspendLayout();
			this.rsPanel1.SuspendLayout();
			this.rsPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDmCa)).BeginInit();
			this.SuspendLayout();
			// 
			// rsSplitContainer1
			// 
			this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rsSplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.rsSplitContainer1.Name = "rsSplitContainer1";
			this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// rsSplitContainer1.Panel1
			// 
			this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel2);
			this.rsSplitContainer1.Panel1.Controls.Add(this.rsPanel1);
			this.rsSplitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
			// 
			// rsSplitContainer1.Panel2
			// 
			this.rsSplitContainer1.Panel2.Controls.Add(this.btContinues);
			this.rsSplitContainer1.Panel2.Controls.Add(this.btExit);
			this.rsSplitContainer1.Panel2.Controls.Add(this.btNew);
			this.rsSplitContainer1.Size = new System.Drawing.Size(784, 562);
			this.rsSplitContainer1.SplitterDistance = 504;
			this.rsSplitContainer1.TabIndex = 0;
			// 
			// rsPanel1
			// 
			this.rsPanel1.Controls.Add(this.btFilter);
			this.rsPanel1.Controls.Add(this.dteNgay_Ct2);
			this.rsPanel1.Controls.Add(this.rsLabel2);
			this.rsPanel1.Controls.Add(this.dteNgay_Ct1);
			this.rsPanel1.Controls.Add(this.rsLabel1);
			this.rsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.rsPanel1.Location = new System.Drawing.Point(3, 3);
			this.rsPanel1.Name = "rsPanel1";
			this.rsPanel1.Size = new System.Drawing.Size(778, 45);
			this.rsPanel1.TabIndex = 0;
			// 
			// btFilter
			// 
			this.btFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btFilter.ImageKey = "Filter.png";
			this.btFilter.Location = new System.Drawing.Point(526, 7);
			this.btFilter.Name = "btFilter";
			this.btFilter.Size = new System.Drawing.Size(86, 33);
			this.btFilter.TabIndex = 2;
			this.btFilter.Tag = "";
			this.btFilter.Text = "&Lọc";
			this.btFilter.UseVisualStyleBackColor = true;
			// 
			// dteNgay_Ct2
			// 
			this.dteNgay_Ct2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dteNgay_Ct2.bAllowEmpty = false;
			this.dteNgay_Ct2.bSelectOnFocus = false;
			this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct2.Location = new System.Drawing.Point(423, 10);
			this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct2.Mask = "00/00/0000";
			this.dteNgay_Ct2.Name = "dteNgay_Ct2";
			this.dteNgay_Ct2.Size = new System.Drawing.Size(98, 26);
			this.dteNgay_Ct2.TabIndex = 1;
			// 
			// rsLabel2
			// 
			this.rsLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel2.Location = new System.Drawing.Point(341, 14);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(77, 17);
			this.rsLabel2.TabIndex = 9;
			this.rsLabel2.Text = "Đến ngày";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dteNgay_Ct1
			// 
			this.dteNgay_Ct1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dteNgay_Ct1.bAllowEmpty = false;
			this.dteNgay_Ct1.bSelectOnFocus = false;
			this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dteNgay_Ct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dteNgay_Ct1.Location = new System.Drawing.Point(238, 10);
			this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.dteNgay_Ct1.Mask = "00/00/0000";
			this.dteNgay_Ct1.Name = "dteNgay_Ct1";
			this.dteNgay_Ct1.Size = new System.Drawing.Size(98, 26);
			this.dteNgay_Ct1.TabIndex = 0;
			// 
			// rsLabel1
			// 
			this.rsLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel1.Location = new System.Drawing.Point(166, 14);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(67, 17);
			this.rsLabel1.TabIndex = 7;
			this.rsLabel1.Text = "Từ ngày";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btExit.ImageKey = "exit2.png";
			this.btExit.Location = new System.Drawing.Point(210, 2);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(93, 50);
			this.btExit.TabIndex = 2;
			this.btExit.Tag = "Exit";
			this.btExit.Text = "Th&oát";
			this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// btNew
			// 
			this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew.ImageKey = "New.png";
			this.btNew.Location = new System.Drawing.Point(111, 2);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(93, 50);
			this.btNew.TabIndex = 1;
			this.btNew.Tag = "New";
			this.btNew.Text = "&Thêm";
			this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// btContinues
			// 
			this.btContinues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btContinues.Image = ((System.Drawing.Image)(resources.GetObject("btContinues.Image")));
			this.btContinues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btContinues.ImageKey = "exit2.png";
			this.btContinues.Location = new System.Drawing.Point(12, 2);
			this.btContinues.Name = "btContinues";
			this.btContinues.Size = new System.Drawing.Size(93, 50);
			this.btContinues.TabIndex = 0;
			this.btContinues.Tag = "";
			this.btContinues.Text = "Tiếp tục";
			this.btContinues.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btContinues.UseVisualStyleBackColor = true;
			// 
			// rsPanel2
			// 
			this.rsPanel2.Controls.Add(this.dgvDmCa);
			this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rsPanel2.Location = new System.Drawing.Point(3, 48);
			this.rsPanel2.Name = "rsPanel2";
			this.rsPanel2.Size = new System.Drawing.Size(778, 453);
			this.rsPanel2.TabIndex = 2;
			// 
			// dgvDmCa
			// 
			this.dgvDmCa.AllowUserToAddRows = false;
			this.dgvDmCa.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvDmCa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvDmCa.BackgroundColor = System.Drawing.Color.White;
			this.dgvDmCa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvDmCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDmCa.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDmCa.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvDmCa.Location = new System.Drawing.Point(0, 0);
			this.dgvDmCa.MultiSelect = false;
			this.dgvDmCa.Name = "dgvDmCa";
			this.dgvDmCa.ReadOnly = true;
			this.dgvDmCa.Size = new System.Drawing.Size(778, 453);
			this.dgvDmCa.strZone = "";
			this.dgvDmCa.TabIndex = 0;
			// 
			// frmQuery_Shift
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.rsSplitContainer1);
			this.Name = "frmQuery_Shift";
			this.Object_ID = "QUERY_SHIFT";
			this.Text = "frmQuery_Shift";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.rsSplitContainer1.Panel1.ResumeLayout(false);
			this.rsSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
			this.rsSplitContainer1.ResumeLayout(false);
			this.rsPanel1.ResumeLayout(false);
			this.rsPanel1.PerformLayout();
			this.rsPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDmCa)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
		private RosySystem.Control.rsPanel rsPanel1;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Control.rsDateTime dteNgay_Ct2;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsDateTime dteNgay_Ct1;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Customize.btExit btContinues;
		private RosySystem.Customize.btExit btExit;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Control.rsPanel rsPanel2;
		private RosySystem.Control.rsDataGridView dgvDmCa;
	}
}