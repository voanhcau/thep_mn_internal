namespace RosyModule.Receivable
{
    partial class frmDmCkCt
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
            this.dgvQDCK = new RosySystem.Control.rsDataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpQuyetDinh = new System.Windows.Forms.TabPage();
            this.dgvQDCKCT = new RosySystem.Control.rsDataGridView();
            this.btDetailDelete = new RosySystem.Customize.btDelete();
            this.btDetailEdit = new RosySystem.Customize.btEdit();
            this.btDetailNew = new RosySystem.Customize.btNew();
            this.btKetQua = new RosySystem.Customize.btFilter();
            this.tpKetQua = new System.Windows.Forms.TabPage();
            this.dgvKetQua = new RosySystem.Control.rsDataGridView();
            this.btSave = new RosySystem.Customize.btFilter();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvQDCK)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tpQuyetDinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQDCKCT)).BeginInit();
            this.tpKetQua.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.dgvQDCK);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(772, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh mục quyết định chiết khấu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvQDCK
            // 
            this.dgvQDCK.AllowUserToAddRows = false;
            this.dgvQDCK.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvQDCK.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQDCK.BackgroundColor = System.Drawing.Color.White;
            this.dgvQDCK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvQDCK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQDCK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQDCK.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvQDCK.Location = new System.Drawing.Point(0, 0);
            this.dgvQDCK.MultiSelect = false;
            this.dgvQDCK.Name = "dgvQDCK";
            this.dgvQDCK.ReadOnly = true;
            this.dgvQDCK.Size = new System.Drawing.Size(772, 154);
            this.dgvQDCK.strZone = "";
            this.dgvQDCK.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpQuyetDinh);
            this.tabControl2.Controls.Add(this.tpKetQua);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(780, 323);
            this.tabControl2.TabIndex = 3;
            // 
            // tpQuyetDinh
            // 
            this.tpQuyetDinh.Controls.Add(this.dgvQDCKCT);
            this.tpQuyetDinh.Location = new System.Drawing.Point(4, 22);
            this.tpQuyetDinh.Name = "tpQuyetDinh";
            this.tpQuyetDinh.Size = new System.Drawing.Size(772, 297);
            this.tpQuyetDinh.TabIndex = 0;
            this.tpQuyetDinh.Text = "Chi tiết chiết khấu";
            this.tpQuyetDinh.UseVisualStyleBackColor = true;
            // 
            // dgvQDCKCT
            // 
            this.dgvQDCKCT.AllowUserToAddRows = false;
            this.dgvQDCKCT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvQDCKCT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQDCKCT.BackgroundColor = System.Drawing.Color.White;
            this.dgvQDCKCT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvQDCKCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQDCKCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQDCKCT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvQDCKCT.Location = new System.Drawing.Point(0, 0);
            this.dgvQDCKCT.MultiSelect = false;
            this.dgvQDCKCT.Name = "dgvQDCKCT";
            this.dgvQDCKCT.ReadOnly = true;
            this.dgvQDCKCT.Size = new System.Drawing.Size(772, 297);
            this.dgvQDCKCT.strZone = "";
            this.dgvQDCKCT.TabIndex = 3;
            // 
            // btDetailDelete
            // 
            this.btDetailDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetailDelete.ImageKey = "Delete.png";
            this.btDetailDelete.Location = new System.Drawing.Point(505, 520);
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
            this.btDetailEdit.Location = new System.Drawing.Point(435, 520);
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
            this.btDetailNew.Location = new System.Drawing.Point(365, 520);
            this.btDetailNew.Name = "btDetailNew";
            this.btDetailNew.Size = new System.Drawing.Size(67, 42);
            this.btDetailNew.TabIndex = 18;
            this.btDetailNew.Tag = "New";
            this.btDetailNew.Text = "Thêm";
            this.btDetailNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDetailNew.UseVisualStyleBackColor = true;
            // 
            // btKetQua
            // 
            this.btKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btKetQua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btKetQua.ImageKey = "(none)";
            this.btKetQua.Location = new System.Drawing.Point(575, 520);
            this.btKetQua.Name = "btKetQua";
            this.btKetQua.Size = new System.Drawing.Size(67, 42);
            this.btKetQua.TabIndex = 21;
            this.btKetQua.Tag = "";
            this.btKetQua.Text = "Kết quả";
            this.btKetQua.UseVisualStyleBackColor = true;
            // 
            // tpKetQua
            // 
            this.tpKetQua.Controls.Add(this.dgvKetQua);
            this.tpKetQua.Location = new System.Drawing.Point(4, 22);
            this.tpKetQua.Name = "tpKetQua";
            this.tpKetQua.Size = new System.Drawing.Size(772, 297);
            this.tpKetQua.TabIndex = 1;
            this.tpKetQua.Text = "Kết quả";
            this.tpKetQua.UseVisualStyleBackColor = true;
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
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageKey = "(none)";
            this.btSave.Location = new System.Drawing.Point(644, 520);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(67, 42);
            this.btSave.TabIndex = 21;
            this.btSave.Tag = "";
            this.btSave.Text = "Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "(none)";
            this.btPrint.Location = new System.Drawing.Point(713, 520);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(67, 42);
            this.btPrint.TabIndex = 21;
            this.btPrint.Tag = "";
            this.btPrint.Text = "In";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // frmDmCkCt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btKetQua);
            this.Controls.Add(this.btDetailDelete);
            this.Controls.Add(this.btDetailEdit);
            this.Controls.Add(this.btDetailNew);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDmCkCt";
            this.Text = "frmQDChietKhau";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvQDCK)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tpQuyetDinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQDCKCT)).EndInit();
            this.tpKetQua.ResumeLayout(false);
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
        private RosySystem.Control.rsDataGridView dgvQDCK;
        private System.Windows.Forms.TabPage tpQuyetDinh;
        private RosySystem.Control.rsDataGridView dgvQDCKCT;
        private RosySystem.Customize.btFilter btKetQua;
        private System.Windows.Forms.TabPage tpKetQua;
        private RosySystem.Control.rsDataGridView dgvKetQua;
        private RosySystem.Customize.btFilter btSave;
        private RosySystem.Customize.btFilter btPrint;
    }
}