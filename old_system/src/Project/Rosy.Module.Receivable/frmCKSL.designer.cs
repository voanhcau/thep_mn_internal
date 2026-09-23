namespace RosyModule.Receivable
{
	partial class frmCKSL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCKSL));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tpCtVtTsHM = new System.Windows.Forms.TabPage();
            this.dgvCKSLCT = new RosySystem.Control.rsDataGridView();
            this.rsPanel1 = new RosySystem.Control.rsPanel();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btDelete = new RosySystem.Customize.btDelete();
            this.btNew = new RosySystem.Customize.btNew();
            this.dgvCKSL = new RosySystem.Control.rsDataGridView();
            this.rsTabControl1.SuspendLayout();
            this.tpCtVtTsHM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCKSLCT)).BeginInit();
            this.rsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCKSL)).BeginInit();
            this.SuspendLayout();
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tpCtVtTsHM);
            this.rsTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsTabControl1.Location = new System.Drawing.Point(4, 251);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(804, 239);
            this.rsTabControl1.TabIndex = 1;
            // 
            // tpCtVtTsHM
            // 
            this.tpCtVtTsHM.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCtVtTsHM.Controls.Add(this.dgvCKSLCT);
            this.tpCtVtTsHM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtVtTsHM.Location = new System.Drawing.Point(4, 22);
            this.tpCtVtTsHM.Name = "tpCtVtTsHM";
            this.tpCtVtTsHM.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtVtTsHM.Size = new System.Drawing.Size(796, 213);
            this.tpCtVtTsHM.TabIndex = 1;
            this.tpCtVtTsHM.Tag = "";
            this.tpCtVtTsHM.Text = "Chi tiết chiết khấu";
            this.tpCtVtTsHM.UseVisualStyleBackColor = true;
            // 
            // dgvCKSLCT
            // 
            this.dgvCKSLCT.AllowUserToAddRows = false;
            this.dgvCKSLCT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCKSLCT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCKSLCT.BackgroundColor = System.Drawing.Color.White;
            this.dgvCKSLCT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCKSLCT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCKSLCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCKSLCT.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCKSLCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCKSLCT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCKSLCT.Location = new System.Drawing.Point(3, 3);
            this.dgvCKSLCT.MultiSelect = false;
            this.dgvCKSLCT.Name = "dgvCKSLCT";
            this.dgvCKSLCT.ReadOnly = true;
            this.dgvCKSLCT.Size = new System.Drawing.Size(790, 207);
            this.dgvCKSLCT.strZone = "";
            this.dgvCKSLCT.TabIndex = 0;
            // 
            // rsPanel1
            // 
            this.rsPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rsPanel1.Controls.Add(this.btEdit);
            this.rsPanel1.Controls.Add(this.btDelete);
            this.rsPanel1.Controls.Add(this.btNew);
            this.rsPanel1.Location = new System.Drawing.Point(4, 496);
            this.rsPanel1.Name = "rsPanel1";
            this.rsPanel1.Size = new System.Drawing.Size(791, 67);
            this.rsPanel1.TabIndex = 2;
            // 
            // btEdit
            // 
            this.btEdit.Image = ((System.Drawing.Image)(resources.GetObject("btEdit.Image")));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.ImageKey = "Edit.png";
            this.btEdit.Location = new System.Drawing.Point(108, 7);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(93, 54);
            this.btEdit.TabIndex = 1;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "&Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Image = ((System.Drawing.Image)(resources.GetObject("btDelete.Image")));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Delete.png";
            this.btDelete.Location = new System.Drawing.Point(207, 7);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(93, 54);
            this.btDelete.TabIndex = 2;
            this.btDelete.Tag = "Delete";
            this.btDelete.Text = "&Xóa";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Image = ((System.Drawing.Image)(resources.GetObject("btNew.Image")));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "New.png";
            this.btNew.Location = new System.Drawing.Point(8, 7);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(93, 54);
            this.btNew.TabIndex = 0;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // dgvCKSL
            // 
            this.dgvCKSL.AllowUserToAddRows = false;
            this.dgvCKSL.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCKSL.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCKSL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCKSL.BackgroundColor = System.Drawing.Color.White;
            this.dgvCKSL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCKSL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCKSL.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCKSL.Location = new System.Drawing.Point(4, 2);
            this.dgvCKSL.MultiSelect = false;
            this.dgvCKSL.Name = "dgvCKSL";
            this.dgvCKSL.ReadOnly = true;
            this.dgvCKSL.Size = new System.Drawing.Size(800, 243);
            this.dgvCKSL.strZone = "";
            this.dgvCKSL.TabIndex = 0;
            // 
            // frmCKSL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 569);
            this.Controls.Add(this.dgvCKSL);
            this.Controls.Add(this.rsPanel1);
            this.Controls.Add(this.rsTabControl1);
            this.Name = "frmCKSL";
            this.Object_ID = "DMCKSL";
            this.Tag = "frmCtTS, F2, F3, F8, ESC";
            this.Text = "Danh mục chiết khấu sản lượng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsTabControl1.ResumeLayout(false);
            this.tpCtVtTsHM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCKSLCT)).EndInit();
            this.rsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCKSL)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsTabControl rsTabControl1;
        private System.Windows.Forms.TabPage tpCtVtTsHM;
        private RosySystem.Control.rsDataGridView dgvCKSLCT;
		private RosySystem.Control.rsPanel rsPanel1;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btDelete btDelete;
        private RosySystem.Customize.btNew btNew;
        private RosySystem.Control.rsDataGridView dgvCKSL;


	}
}