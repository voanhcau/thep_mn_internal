namespace RosyModule.Machinery
{
    partial class frmBTSC
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
            this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
            this.btDelete = new RosySystem.Customize.btDelete();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btNew = new RosySystem.Customize.btNew();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).BeginInit();
            this.rsSplitContainer1.Panel2.SuspendLayout();
            this.rsSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsSplitContainer1
            // 
            this.rsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.rsSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.rsSplitContainer1.Name = "rsSplitContainer1";
            this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer1.Panel2
            // 
            this.rsSplitContainer1.Panel2.Controls.Add(this.btDelete);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btEdit);
            this.rsSplitContainer1.Panel2.Controls.Add(this.btNew);
            this.rsSplitContainer1.Size = new System.Drawing.Size(784, 605);
            this.rsSplitContainer1.SplitterDistance = 537;
            this.rsSplitContainer1.TabIndex = 0;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Delete.png";
            this.btDelete.Location = new System.Drawing.Point(163, 10);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(70, 45);
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
            this.btEdit.Location = new System.Drawing.Point(87, 10);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(70, 45);
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
            this.btNew.Location = new System.Drawing.Point(11, 10);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(70, 45);
            this.btNew.TabIndex = 24;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // frmBTSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 605);
            this.Controls.Add(this.rsSplitContainer1);
            this.Name = "frmBTSC";
            this.Text = "frmKHBTSC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
            this.rsSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RosySystem.Control.rsSplitContainer rsSplitContainer1;
        private RosySystem.Customize.btDelete btDelete;
        private RosySystem.Customize.btEdit btEdit;
        private RosySystem.Customize.btNew btNew;
    }
}