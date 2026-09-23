namespace RosyModule.Machinery
{
    partial class frmKHBTSC
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btPreview = new RosySystem.Customize.btPreview();
			this.btDelete = new RosySystem.Customize.btDelete();
			this.btEdit = new RosySystem.Customize.btEdit();
			this.btNew = new RosySystem.Customize.btNew();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btPreview);
			this.splitContainer1.Panel2.Controls.Add(this.btDelete);
			this.splitContainer1.Panel2.Controls.Add(this.btEdit);
			this.splitContainer1.Panel2.Controls.Add(this.btNew);
			this.splitContainer1.Size = new System.Drawing.Size(784, 605);
			this.splitContainer1.SplitterDistance = 534;
			this.splitContainer1.TabIndex = 0;
			// 
			// btPreview
			// 
			this.btPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btPreview.ImageKey = "Preview.png";
			this.btPreview.Location = new System.Drawing.Point(240, 16);
			this.btPreview.Name = "btPreview";
			this.btPreview.Size = new System.Drawing.Size(111, 39);
			this.btPreview.TabIndex = 27;
			this.btPreview.Tag = "";
			this.btPreview.Text = "Thiết bị đến hạn bảo trì";
			this.btPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btPreview.UseVisualStyleBackColor = true;
			// 
			// btDelete
			// 
			this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDelete.ImageKey = "Delete.png";
			this.btDelete.Location = new System.Drawing.Point(164, 16);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(70, 40);
			this.btDelete.TabIndex = 26;
			this.btDelete.Tag = "Delete";
			this.btDelete.Text = "&Xóa";
			this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btDelete.UseVisualStyleBackColor = true;
			// 
			// btEdit
			// 
			this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit.ImageKey = "Edit.png";
			this.btEdit.Location = new System.Drawing.Point(88, 16);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(70, 40);
			this.btEdit.TabIndex = 25;
			this.btEdit.Tag = "Edit";
			this.btEdit.Text = "&Sửa";
			this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btEdit.UseVisualStyleBackColor = true;
			// 
			// btNew
			// 
			this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew.ImageKey = "New.png";
			this.btNew.Location = new System.Drawing.Point(12, 16);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(70, 40);
			this.btNew.TabIndex = 24;
			this.btNew.Tag = "New";
			this.btNew.Text = "&Thêm";
			this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// frmKHBTSC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 605);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmKHBTSC";
			this.Text = "frmKHBTSC";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Customize.btDelete btDelete;
        private RosySystem.Customize.btEdit btEdit;
        private RosySystem.Customize.btNew btNew;
		private RosySystem.Customize.btPreview btPreview;
    }
}