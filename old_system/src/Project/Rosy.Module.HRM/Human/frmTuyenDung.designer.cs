namespace RosyModule.HRM
{
    partial class frmTuyenDung
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvTuyenDung = new RosySystem.Control.rsDataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDsUv = new RosySystem.Control.rsDataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvKetQua = new RosySystem.Control.rsDataGridView();
            this.btDetailDelete = new RosySystem.Customize.btDelete();
            this.btDetailEdit = new RosySystem.Customize.btEdit();
            this.btDetailNew = new RosySystem.Customize.btNew();
            this.btPrint = new RosySystem.Customize.btFilter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyenDung)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsUv)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 7);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(780, 507);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 13;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(780, 507);
            this.splitContainer2.SplitterDistance = 278;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer3.Size = new System.Drawing.Size(780, 507);
            this.splitContainer3.SplitterDistance = 180;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 180);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvTuyenDung);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(772, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh mục tuyển dụng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvTuyenDung
            // 
            this.dgvTuyenDung.AllowUserToAddRows = false;
            this.dgvTuyenDung.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTuyenDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTuyenDung.BackgroundColor = System.Drawing.Color.White;
            this.dgvTuyenDung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTuyenDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTuyenDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTuyenDung.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTuyenDung.Location = new System.Drawing.Point(0, 0);
            this.dgvTuyenDung.MultiSelect = false;
            this.dgvTuyenDung.Name = "dgvTuyenDung";
            this.dgvTuyenDung.ReadOnly = true;
            this.dgvTuyenDung.Size = new System.Drawing.Size(772, 154);
            this.dgvTuyenDung.strZone = "";
            this.dgvTuyenDung.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(780, 323);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDsUv);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(772, 297);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Danh sách ứng viên";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDsUv
            // 
            this.dgvDsUv.AllowUserToAddRows = false;
            this.dgvDsUv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDsUv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDsUv.BackgroundColor = System.Drawing.Color.White;
            this.dgvDsUv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDsUv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsUv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDsUv.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDsUv.Location = new System.Drawing.Point(0, 0);
            this.dgvDsUv.MultiSelect = false;
            this.dgvDsUv.Name = "dgvDsUv";
            this.dgvDsUv.ReadOnly = true;
            this.dgvDsUv.Size = new System.Drawing.Size(772, 297);
            this.dgvDsUv.strZone = "";
            this.dgvDsUv.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvKetQua);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(772, 297);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Kết quả phỏng vấn";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKetQua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKetQua.BackgroundColor = System.Drawing.Color.White;
            this.dgvKetQua.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKetQua.Location = new System.Drawing.Point(0, 0);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.Size = new System.Drawing.Size(772, 297);
            this.dgvKetQua.strZone = "";
            this.dgvKetQua.TabIndex = 4;
            // 
            // btDetailDelete
            // 
            this.btDetailDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetailDelete.ImageKey = "Delete.png";
            this.btDetailDelete.Location = new System.Drawing.Point(622, 520);
            this.btDetailDelete.Name = "btDetailDelete";
            this.btDetailDelete.Size = new System.Drawing.Size(67, 42);
            this.btDetailDelete.TabIndex = 20;
            this.btDetailDelete.Tag = "Delete";
            this.btDetailDelete.Text = "Xóa";
            this.btDetailDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDetailDelete.UseVisualStyleBackColor = true;
            // 
            // btDetailEdit
            // 
            this.btDetailEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDetailEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetailEdit.ImageKey = "Edit.png";
            this.btDetailEdit.Location = new System.Drawing.Point(552, 520);
            this.btDetailEdit.Name = "btDetailEdit";
            this.btDetailEdit.Size = new System.Drawing.Size(67, 42);
            this.btDetailEdit.TabIndex = 19;
            this.btDetailEdit.Tag = "Edit";
            this.btDetailEdit.Text = "Sửa";
            this.btDetailEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDetailEdit.UseVisualStyleBackColor = true;
            // 
            // btDetailNew
            // 
            this.btDetailNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDetailNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetailNew.ImageKey = "New.png";
            this.btDetailNew.Location = new System.Drawing.Point(482, 520);
            this.btDetailNew.Name = "btDetailNew";
            this.btDetailNew.Size = new System.Drawing.Size(67, 42);
            this.btDetailNew.TabIndex = 18;
            this.btDetailNew.Tag = "New";
            this.btDetailNew.Text = "Thêm";
            this.btDetailNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDetailNew.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "(none)";
            this.btPrint.Location = new System.Drawing.Point(692, 520);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(82, 42);
            this.btPrint.TabIndex = 21;
            this.btPrint.Tag = "";
            this.btPrint.Text = "In ";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // frmTuyenDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btDetailDelete);
            this.Controls.Add(this.btDetailEdit);
            this.Controls.Add(this.btDetailNew);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmTuyenDung";
            this.Text = "frmTuyenDung";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyenDung)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsUv)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
		private RosySystem.Customize.btDelete btDetailDelete;
		private RosySystem.Customize.btEdit btDetailEdit;
        private RosySystem.Customize.btNew btDetailNew;
        private RosySystem.Control.rsDataGridView dgvObject;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private RosySystem.Control.rsDataGridView dgvTuyenDung;
        private System.Windows.Forms.TabPage tabPage2;
        private RosySystem.Control.rsDataGridView dgvDsUv;
        private RosySystem.Customize.btFilter btPrint;
        private System.Windows.Forms.TabPage tabPage3;
        private RosySystem.Control.rsDataGridView dgvKetQua;
    }
}