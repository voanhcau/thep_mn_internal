namespace RosyModule.Machinery
{
    partial class frmDmCCKQKD
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabHeader = new RosySystem.Control.rsTabControl();
            this.tabDmNhCCKQKD = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabDetail = new System.Windows.Forms.TabControl();
            this.pageCCKQKD = new System.Windows.Forms.TabPage();
            this.dgvDmCCKQKD = new RosySystem.Control.rsDataGridView();
            this.btDetailDelete = new RosySystem.Customize.btDelete();
            this.btDetailEdit = new RosySystem.Customize.btEdit();
            this.btDetailNew = new RosySystem.Customize.btNew();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.pageCCKQKD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmCCKQKD)).BeginInit();
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
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(780, 507);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 13;
            // 
            // tabHeader
            // 
            this.tabHeader.Controls.Add(this.tabDmNhCCKQKD);
            this.tabHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHeader.Location = new System.Drawing.Point(0, 0);
            this.tabHeader.Name = "tabHeader";
            this.tabHeader.SelectedIndex = 0;
            this.tabHeader.Size = new System.Drawing.Size(234, 507);
            this.tabHeader.TabIndex = 1;
            // 
            // tabDmNhCCKQKD
            // 
            this.tabDmNhCCKQKD.Location = new System.Drawing.Point(4, 22);
            this.tabDmNhCCKQKD.Name = "tabDmNhCCKQKD";
            this.tabDmNhCCKQKD.Padding = new System.Windows.Forms.Padding(3);
            this.tabDmNhCCKQKD.Size = new System.Drawing.Size(226, 481);
            this.tabDmNhCCKQKD.TabIndex = 1;
            this.tabDmNhCCKQKD.Text = "Danh sách nhóm CC - KQKD";
            this.tabDmNhCCKQKD.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabDetail);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(542, 507);
            this.splitContainer2.SplitterDistance = 278;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.pageCCKQKD);
            this.tabDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetail.Location = new System.Drawing.Point(0, 0);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.SelectedIndex = 0;
            this.tabDetail.Size = new System.Drawing.Size(542, 507);
            this.tabDetail.TabIndex = 4;
            // 
            // pageCCKQKD
            // 
            this.pageCCKQKD.Controls.Add(this.dgvDmCCKQKD);
            this.pageCCKQKD.Location = new System.Drawing.Point(4, 22);
            this.pageCCKQKD.Name = "pageCCKQKD";
            this.pageCCKQKD.Padding = new System.Windows.Forms.Padding(3);
            this.pageCCKQKD.Size = new System.Drawing.Size(534, 481);
            this.pageCCKQKD.TabIndex = 0;
            this.pageCCKQKD.Tag = "";
            this.pageCCKQKD.Text = "Danh sách chứng chỉ - kết quả kiểm định";
            this.pageCCKQKD.UseVisualStyleBackColor = true;
            // 
            // dgvDmCCKQKD
            // 
            this.dgvDmCCKQKD.AllowUserToAddRows = false;
            this.dgvDmCCKQKD.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDmCCKQKD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDmCCKQKD.BackgroundColor = System.Drawing.Color.White;
            this.dgvDmCCKQKD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDmCCKQKD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDmCCKQKD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDmCCKQKD.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDmCCKQKD.Location = new System.Drawing.Point(3, 3);
            this.dgvDmCCKQKD.MultiSelect = false;
            this.dgvDmCCKQKD.Name = "dgvDmCCKQKD";
            this.dgvDmCCKQKD.ReadOnly = true;
            this.dgvDmCCKQKD.Size = new System.Drawing.Size(528, 475);
            this.dgvDmCCKQKD.strZone = "";
            this.dgvDmCCKQKD.TabIndex = 0;
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
            // frmDmCCKQKD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.btDetailDelete);
            this.Controls.Add(this.btDetailEdit);
            this.Controls.Add(this.btDetailNew);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDmCCKQKD";
            this.Object_ID = "DMCCKQKD";
            this.Text = "frmDmCCKQKD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabHeader.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabDetail.ResumeLayout(false);
            this.pageCCKQKD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmCCKQKD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
		private RosySystem.Customize.btDelete btDetailDelete;
		private RosySystem.Customize.btEdit btDetailEdit;
		private RosySystem.Customize.btNew btDetailNew;
        private System.Windows.Forms.TabControl tabDetail;
        private System.Windows.Forms.TabPage pageCCKQKD;
        private RosySystem.Control.rsDataGridView dgvDmCCKQKD;
        private RosySystem.Control.rsTabControl tabHeader;
        private System.Windows.Forms.TabPage tabDmNhCCKQKD;
    }
}