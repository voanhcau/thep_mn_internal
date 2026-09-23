namespace RosyModule
{
    partial class frmAttachFile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttachFile));
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvInheritVoucher = new RosySystem.Control.rsDataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btDelete = new RosySystem.Customize.btFilter();
            this.btAttach = new RosySystem.Customize.btFilter();
            this.btOpen = new RosySystem.Customize.btFilter();
            this.btCancel = new RosySystem.Customize.btFilter();
            this.btAccept = new RosySystem.Customize.btFilter();
            this.btAddFile = new RosySystem.Customize.btFilter();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Location = new System.Drawing.Point(3, 3);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(878, 512);
            this.rsTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvInheritVoucher);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách file";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvInheritVoucher
            // 
            this.dgvInheritVoucher.AllowUserToAddRows = false;
            this.dgvInheritVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInheritVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInheritVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInheritVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvInheritVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInheritVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInheritVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInheritVoucher.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInheritVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInheritVoucher.Location = new System.Drawing.Point(3, 0);
            this.dgvInheritVoucher.MultiSelect = false;
            this.dgvInheritVoucher.Name = "dgvInheritVoucher";
            this.dgvInheritVoucher.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInheritVoucher.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInheritVoucher.Size = new System.Drawing.Size(864, 483);
            this.dgvInheritVoucher.strZone = "";
            this.dgvInheritVoucher.TabIndex = 13;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "(none)";
            this.btDelete.Location = new System.Drawing.Point(575, 518);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(66, 42);
            this.btDelete.TabIndex = 121;
            this.btDelete.Tag = "";
            this.btDelete.Text = "&Xóa file";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btAttach
            // 
            this.btAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAttach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAttach.ImageKey = "(none)";
            this.btAttach.Location = new System.Drawing.Point(506, 518);
            this.btAttach.Name = "btAttach";
            this.btAttach.Size = new System.Drawing.Size(66, 42);
            this.btAttach.TabIndex = 121;
            this.btAttach.Tag = "";
            this.btAttach.Text = "&Thêm file";
            this.btAttach.UseVisualStyleBackColor = true;
            // 
            // btOpen
            // 
            this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpen.ImageKey = "(none)";
            this.btOpen.Location = new System.Drawing.Point(644, 518);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(66, 42);
            this.btOpen.TabIndex = 121;
            this.btOpen.Tag = "";
            this.btOpen.Text = "&Mở file";
            this.btOpen.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.ImageKey = "(none)";
            this.btCancel.Location = new System.Drawing.Point(781, 518);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(93, 42);
            this.btCancel.TabIndex = 121;
            this.btCancel.Tag = "";
            this.btCancel.Text = "&Thoát - không lưu";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btAccept
            // 
            this.btAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAccept.ImageKey = "(none)";
            this.btAccept.Location = new System.Drawing.Point(713, 518);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(66, 42);
            this.btAccept.TabIndex = 121;
            this.btAccept.Tag = "";
            this.btAccept.Text = "&Đồng ý - lưu";
            this.btAccept.UseVisualStyleBackColor = true;
            // 
            // btAddFile
            // 
            this.btAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddFile.ImageKey = "(none)";
            this.btAddFile.Location = new System.Drawing.Point(10, 521);
            this.btAddFile.Name = "btAddFile";
            this.btAddFile.Size = new System.Drawing.Size(66, 42);
            this.btAddFile.TabIndex = 121;
            this.btAddFile.Tag = "";
            this.btAddFile.Text = "&Add file";
            this.btAddFile.UseVisualStyleBackColor = true;
            this.btAddFile.Visible = false;
            // 
            // frmAttachFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 566);
            this.Controls.Add(this.btAddFile);
            this.Controls.Add(this.btAttach);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.rsTabControl1);
            this.Name = "frmAttachFile";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Attach File";
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInheritVoucher)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private RosySystem.Control.rsTabControl rsTabControl1;
        private RosySystem.Control.rsDataGridView dgvInheritVoucher;
		private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Customize.btFilter btDelete;
        private RosySystem.Customize.btFilter btAttach;
        private RosySystem.Customize.btFilter btOpen;
        private RosySystem.Customize.btFilter btCancel;
        private RosySystem.Customize.btFilter btAccept;
        private RosySystem.Customize.btFilter btAddFile;
	}
}

