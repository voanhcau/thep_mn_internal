namespace RosyModule.HRM
{
    partial class frmVTPTVao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVTPTVao));
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvInheritVoucher = new RosySystem.Customize.dgvVoucher();
            this.txtTen_Dt = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.dteNgay_Ct = new RosySystem.Control.rsDateTime();
            this.lblNgay_Ct = new RosySystem.Control.rsLabel();
            this.txtSo_Ct = new RosySystem.Control.rsTextBox();
            this.lblSo_Ct = new RosySystem.Control.rsLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dteNgay_Ra = new RosySystem.Control.rsDateTime();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtSo_Ct_Filter = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.btRe = new RosySystem.Control.rsButton();
            this.btAdd = new RosySystem.Control.rsButton();
            this.panel_REC = new System.Windows.Forms.Panel();
            this.panel_ADD = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Controls.Add(this.tabPage2);
            this.rsTabControl1.Location = new System.Drawing.Point(3, 3);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(1107, 512);
            this.rsTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvInheritVoucher);
            this.tabPage1.Controls.Add(this.txtTen_Dt);
            this.tabPage1.Controls.Add(this.rsLabel1);
            this.tabPage1.Controls.Add(this.dteNgay_Ct);
            this.tabPage1.Controls.Add(this.lblNgay_Ct);
            this.tabPage1.Controls.Add(this.txtSo_Ct);
            this.tabPage1.Controls.Add(this.lblSo_Ct);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1099, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vào cổng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvInheritVoucher
            // 
            this.dgvInheritVoucher.AllowUserToAddRows = false;
            this.dgvInheritVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInheritVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInheritVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvInheritVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvInheritVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInheritVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInheritVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInheritVoucher.Location = new System.Drawing.Point(3, 50);
            this.dgvInheritVoucher.MultiSelect = false;
            this.dgvInheritVoucher.Name = "dgvInheritVoucher";
            this.dgvInheritVoucher.Size = new System.Drawing.Size(1093, 433);
            this.dgvInheritVoucher.strZone = "";
            this.dgvInheritVoucher.TabIndex = 2;
            // 
            // txtTen_Dt
            // 
            this.txtTen_Dt.AutoDropDown = null;
            this.txtTen_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTen_Dt.Location = new System.Drawing.Point(391, 14);
            this.txtTen_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Dt.MaxLength = 20;
            this.txtTen_Dt.Name = "txtTen_Dt";
            this.txtTen_Dt.Size = new System.Drawing.Size(264, 20);
            this.txtTen_Dt.TabIndex = 1;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(271, 17);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(115, 13);
            this.rsLabel1.TabIndex = 57;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Tên đơn vị mang hàng";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = true;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(67, 14);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct.TabIndex = 0;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.Location = new System.Drawing.Point(7, 17);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(54, 13);
            this.lblNgay_Ct.TabIndex = 54;
            this.lblNgay_Ct.Tag = "";
            this.lblNgay_Ct.Text = "Ngày Vào";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.AutoDropDown = null;
            this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct.Location = new System.Drawing.Point(168, 14);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct.MaxLength = 20;
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.Size = new System.Drawing.Size(101, 20);
            this.txtSo_Ct.TabIndex = 0;
            // 
            // lblSo_Ct
            // 
            this.lblSo_Ct.AutoEllipsis = true;
            this.lblSo_Ct.AutoSize = true;
            this.lblSo_Ct.Location = new System.Drawing.Point(140, 17);
            this.lblSo_Ct.Name = "lblSo_Ct";
            this.lblSo_Ct.Size = new System.Drawing.Size(23, 13);
            this.lblSo_Ct.TabIndex = 53;
            this.lblSo_Ct.Tag = "";
            this.lblSo_Ct.Text = "Số ";
            this.lblSo_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1099, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ra cổng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dteNgay_Ra);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.txtSo_Ct_Filter);
            this.splitContainer1.Panel1.Controls.Add(this.rsLabel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btRe);
            this.splitContainer1.Panel2.Controls.Add(this.btAdd);
            this.splitContainer1.Panel2.Controls.Add(this.panel_REC);
            this.splitContainer1.Panel2.Controls.Add(this.panel_ADD);
            this.splitContainer1.Size = new System.Drawing.Size(1099, 486);
            this.splitContainer1.SplitterDistance = 44;
            this.splitContainer1.TabIndex = 0;
            // 
            // dteNgay_Ra
            // 
            this.dteNgay_Ra.bAllowEmpty = true;
            this.dteNgay_Ra.bSelectOnFocus = false;
            this.dteNgay_Ra.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ra.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ra.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ra.Location = new System.Drawing.Point(73, 10);
            this.dteNgay_Ra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ra.Mask = "00/00/0000";
            this.dteNgay_Ra.Name = "dteNgay_Ra";
            this.dteNgay_Ra.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ra.TabIndex = 56;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(13, 13);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(49, 13);
            this.rsLabel2.TabIndex = 58;
            this.rsLabel2.Tag = "";
            this.rsLabel2.Text = "Ngày Ra";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct_Filter
            // 
            this.txtSo_Ct_Filter.AutoDropDown = null;
            this.txtSo_Ct_Filter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct_Filter.Location = new System.Drawing.Point(174, 10);
            this.txtSo_Ct_Filter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct_Filter.MaxLength = 20;
            this.txtSo_Ct_Filter.Name = "txtSo_Ct_Filter";
            this.txtSo_Ct_Filter.Size = new System.Drawing.Size(101, 20);
            this.txtSo_Ct_Filter.TabIndex = 55;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(146, 13);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(23, 13);
            this.rsLabel3.TabIndex = 57;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "Số ";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRe
            // 
            this.btRe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btRe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRe.ImageKey = "add";
            this.btRe.Location = new System.Drawing.Point(551, 178);
            this.btRe.Name = "btRe";
            this.btRe.Size = new System.Drawing.Size(67, 47);
            this.btRe.TabIndex = 70;
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
            this.btAdd.Location = new System.Drawing.Point(551, 128);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(67, 46);
            this.btAdd.TabIndex = 69;
            this.btAdd.Tag = "";
            this.btAdd.Text = ">>";
            this.btAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // panel_REC
            // 
            this.panel_REC.Location = new System.Drawing.Point(621, 3);
            this.panel_REC.Name = "panel_REC";
            this.panel_REC.Size = new System.Drawing.Size(474, 432);
            this.panel_REC.TabIndex = 0;
            // 
            // panel_ADD
            // 
            this.panel_ADD.Location = new System.Drawing.Point(3, 3);
            this.panel_ADD.Name = "panel_ADD";
            this.panel_ADD.Size = new System.Drawing.Size(547, 432);
            this.panel_ADD.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(925, 518);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            this.btgAccept.TabIndex = 1;
            // 
            // frmVTPTVao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 566);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmVTPTVao";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "VTPT ra vào cổng";
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
        private RosySystem.Control.rsTabControl rsTabControl1;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsTextBox txtSo_Ct;
		private RosySystem.Control.rsLabel lblSo_Ct;
        private RosySystem.Control.rsLabel lblNgay_Ct;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Control.rsDateTime dteNgay_Ct;
        private System.Windows.Forms.TabPage tabPage2;
        private RosySystem.Control.rsTextBox txtTen_Dt;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Customize.dgvVoucher dgvInheritVoucher;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Control.rsDateTime dteNgay_Ra;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtSo_Ct_Filter;
        private RosySystem.Control.rsLabel rsLabel3;
        private System.Windows.Forms.Panel panel_REC;
        private System.Windows.Forms.Panel panel_ADD;
        private RosySystem.Control.rsButton btRe;
        private RosySystem.Control.rsButton btAdd;
	}
}

