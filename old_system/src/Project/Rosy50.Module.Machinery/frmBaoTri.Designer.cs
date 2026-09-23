namespace RosyModule.Machinery
{
	partial class frmBaoTri
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btInherit = new RosySystem.Customize.btDelete();
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
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btInherit);
            this.splitContainer1.Panel2.Controls.Add(this.btDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btNew);
            this.splitContainer1.Size = new System.Drawing.Size(859, 402);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 0;
            // 
            // btInherit
            // 
            this.btInherit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btInherit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInherit.ImageKey = "(none)";
            this.btInherit.Location = new System.Drawing.Point(234, 19);
            this.btInherit.Name = "btInherit";
            this.btInherit.Size = new System.Drawing.Size(70, 37);
            this.btInherit.TabIndex = 31;
            this.btInherit.Tag = "";
            this.btInherit.Text = "Kế thừa kế hoạch";
            this.btInherit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btInherit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Delete.png";
            this.btDelete.Location = new System.Drawing.Point(158, 19);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(70, 37);
            this.btDelete.TabIndex = 30;
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
            this.btEdit.Location = new System.Drawing.Point(82, 19);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(70, 37);
            this.btEdit.TabIndex = 29;
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
            this.btNew.Location = new System.Drawing.Point(6, 19);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(70, 37);
            this.btNew.TabIndex = 28;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // frmBaoTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 402);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmBaoTri";
            this.Object_ID = "BAOTRI";
            this.Text = "Bảo trì đột xuất";
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
		private RosySystem.Customize.btDelete btInherit;
	}
}