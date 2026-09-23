namespace RosyModule.Payable
{
    partial class frmDnTu
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
            this.btDelete = new RosySystem.Customize.btDelete();
            this.btNew = new RosySystem.Customize.btNew();
            this.btFilter = new RosySystem.Customize.btFilter();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btPrint = new RosySystem.Customize.btFilter();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Delete.png";
            this.btDelete.Location = new System.Drawing.Point(149, 520);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(67, 42);
            this.btDelete.TabIndex = 16;
            this.btDelete.Tag = "Delete";
            this.btDelete.Text = "Xóa";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "New.png";
            this.btNew.Location = new System.Drawing.Point(9, 520);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(67, 42);
            this.btNew.TabIndex = 14;
            this.btNew.Tag = "New";
            this.btNew.Text = "Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btFilter
            // 
            this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFilter.ImageKey = "Filter.png";
            this.btFilter.Location = new System.Drawing.Point(219, 520);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(64, 42);
            this.btFilter.TabIndex = 17;
            this.btFilter.Tag = "Filter";
            this.btFilter.Text = "Lọc";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.ImageKey = "Edit.png";
            this.btEdit.Location = new System.Drawing.Point(79, 520);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(66, 42);
            this.btEdit.TabIndex = 15;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageKey = "(none)";
            this.btPrint.Location = new System.Drawing.Point(289, 520);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(64, 42);
            this.btPrint.TabIndex = 17;
            this.btPrint.Tag = "Print";
            this.btPrint.Text = "In";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(96, 100);
            this.splitContainer2.SplitterDistance = 59;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 7);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(780, 507);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 13;
            // 
            // frmDnTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btFilter);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDnTu";
            this.Text = "frmDNTU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Customize.btFilter btFilter;
        private RosySystem.Customize.btEdit btEdit;
        private RosySystem.Customize.btFilter btPrint;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}