namespace RosyModule.CRM
{
    partial class frmToDoBH
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageTask = new System.Windows.Forms.TabPage();
            this.btDelete = new RosySystem.Customize.btDelete();
            this.btNew = new RosySystem.Customize.btNew();
            this.btFilter = new RosySystem.Customize.btFilter();
            this.btEdit = new RosySystem.Customize.btEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btNew);
            this.splitContainer1.Panel2.Controls.Add(this.btFilter);
            this.splitContainer1.Panel2.Controls.Add(this.btEdit);
            this.splitContainer1.Size = new System.Drawing.Size(925, 575);
            this.splitContainer1.SplitterDistance = 508;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageTask);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(919, 502);
            this.tabControl1.TabIndex = 0;
            // 
            // pageTask
            // 
            this.pageTask.Location = new System.Drawing.Point(4, 22);
            this.pageTask.Name = "pageTask";
            this.pageTask.Padding = new System.Windows.Forms.Padding(3);
            this.pageTask.Size = new System.Drawing.Size(911, 476);
            this.pageTask.TabIndex = 0;
            this.pageTask.Text = "Thông tin công việc";
            this.pageTask.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Delete.png";
            this.btDelete.Location = new System.Drawing.Point(163, 9);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(67, 42);
            this.btDelete.TabIndex = 2;
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
            this.btNew.Location = new System.Drawing.Point(15, 9);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(67, 42);
            this.btNew.TabIndex = 0;
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
            this.btFilter.Location = new System.Drawing.Point(237, 9);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(64, 42);
            this.btFilter.TabIndex = 3;
            this.btFilter.Tag = "Filter";
            this.btFilter.Text = "Lọc";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.ImageKey = "Edit.png";
            this.btEdit.Location = new System.Drawing.Point(90, 9);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(66, 42);
            this.btEdit.TabIndex = 1;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // frmToDoBH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 575);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmToDoBH";
            this.Text = "frmToDoBH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Customize.btFilter btFilter;
		private RosySystem.Customize.btEdit btEdit;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageTask;
	}
}