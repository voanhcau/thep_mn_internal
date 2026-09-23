namespace RosyModule.HRM
{
    partial class frmQuery_Employee
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLopDT = new RosySystem.Control.rsDataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvQLDT = new RosySystem.Control.rsDataGridView();
            this.btDetailDelete = new RosySystem.Customize.btDelete();
            this.btDetailEdit = new RosySystem.Customize.btEdit();
            this.btDetailNew = new RosySystem.Customize.btNew();
            this.btNewList = new RosySystem.Customize.btNew();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopDT)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLDT)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 7);
            this.splitContainer1.Name = "splitContainer1";
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
            this.splitContainer2.Size = new System.Drawing.Size(542, 507);
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
            this.splitContainer3.Size = new System.Drawing.Size(542, 507);
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
            this.tabControl1.Size = new System.Drawing.Size(542, 180);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLopDT);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(534, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh mục lớp đào tạo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLopDT
            // 
            this.dgvLopDT.AllowUserToAddRows = false;
            this.dgvLopDT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLopDT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLopDT.BackgroundColor = System.Drawing.Color.White;
            this.dgvLopDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLopDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLopDT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvLopDT.Location = new System.Drawing.Point(0, 0);
            this.dgvLopDT.MultiSelect = false;
            this.dgvLopDT.Name = "dgvLopDT";
            this.dgvLopDT.ReadOnly = true;
            this.dgvLopDT.Size = new System.Drawing.Size(534, 154);
            this.dgvLopDT.strZone = "";
            this.dgvLopDT.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(542, 323);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvQLDT);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(534, 297);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Danh sách nhân viên tham gia đào tạo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvQLDT
            // 
            this.dgvQLDT.AllowUserToAddRows = false;
            this.dgvQLDT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvQLDT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQLDT.BackgroundColor = System.Drawing.Color.White;
            this.dgvQLDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvQLDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQLDT.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvQLDT.Location = new System.Drawing.Point(0, 0);
            this.dgvQLDT.MultiSelect = false;
            this.dgvQLDT.Name = "dgvQLDT";
            this.dgvQLDT.ReadOnly = true;
            this.dgvQLDT.Size = new System.Drawing.Size(534, 297);
            this.dgvQLDT.strZone = "";
            this.dgvQLDT.TabIndex = 3;
            // 
            // btDetailDelete
            // 
            this.btDetailDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetailDelete.ImageKey = "Delete.png";
            this.btDetailDelete.Location = new System.Drawing.Point(714, 520);
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
            this.btDetailEdit.Location = new System.Drawing.Point(644, 520);
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
            this.btDetailNew.Location = new System.Drawing.Point(574, 520);
            this.btDetailNew.Name = "btDetailNew";
            this.btDetailNew.Size = new System.Drawing.Size(67, 42);
            this.btDetailNew.TabIndex = 18;
            this.btDetailNew.Tag = "New";
            this.btDetailNew.Text = "Thêm";
            this.btDetailNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDetailNew.UseVisualStyleBackColor = true;
            // 
            // btNewList
            // 
            this.btNewList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNewList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNewList.ImageKey = "New.png";
            this.btNewList.Location = new System.Drawing.Point(482, 520);
            this.btNewList.Name = "btNewList";
            this.btNewList.Size = new System.Drawing.Size(94, 43);
            this.btNewList.TabIndex = 18;
            this.btNewList.Tag = "";
            this.btNewList.Text = "Thêm Danh sách nhân viên";
            this.btNewList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNewList.UseVisualStyleBackColor = true;
            // 
            // frmQuery_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.btDetailDelete);
            this.Controls.Add(this.btDetailEdit);
            this.Controls.Add(this.btNewList);
            this.Controls.Add(this.btDetailNew);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmQuery_Employee";
            this.Text = "frmQuery_Employee";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopDT)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLDT)).EndInit();
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
        private RosySystem.Control.rsDataGridView dgvLopDT;
        private System.Windows.Forms.TabPage tabPage2;
        private RosySystem.Control.rsDataGridView dgvQLDT;
        private RosySystem.Customize.btNew btNewList;
    }
}