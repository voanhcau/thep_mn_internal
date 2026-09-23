namespace RosyModule.Machinery
{
	partial class frmKHBTSCTT
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
			this.rsSplitContainer1 = new RosySystem.Control.rsSplitContainer();
			this.btPreview = new RosySystem.Customize.btPreview();
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
			this.rsSplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.rsSplitContainer1.Name = "rsSplitContainer1";
			this.rsSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// rsSplitContainer1.Panel2
			// 
			this.rsSplitContainer1.Panel2.Controls.Add(this.btPreview);
			this.rsSplitContainer1.Panel2.Controls.Add(this.btDelete);
			this.rsSplitContainer1.Panel2.Controls.Add(this.btEdit);
			this.rsSplitContainer1.Panel2.Controls.Add(this.btNew);
			this.rsSplitContainer1.Size = new System.Drawing.Size(784, 605);
			this.rsSplitContainer1.SplitterDistance = 545;
			this.rsSplitContainer1.TabIndex = 0;
			// 
			// btPreview
			// 
			this.btPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btPreview.ImageKey = "Preview.png";
			this.btPreview.Location = new System.Drawing.Point(234, 5);
			this.btPreview.Name = "btPreview";
			this.btPreview.Size = new System.Drawing.Size(111, 39);
			this.btPreview.TabIndex = 31;
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
			this.btDelete.Location = new System.Drawing.Point(158, 5);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(70, 40);
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
			this.btEdit.Location = new System.Drawing.Point(82, 5);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(70, 40);
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
			this.btNew.Location = new System.Drawing.Point(6, 5);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(70, 40);
			this.btNew.TabIndex = 28;
			this.btNew.Tag = "New";
			this.btNew.Text = "&Thêm";
			this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// frmKHBTSCTT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 605);
			this.Controls.Add(this.rsSplitContainer1);
			this.Name = "frmKHBTSCTT";
			this.Text = "frmKHBTSCTT";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.rsSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer1)).EndInit();
			this.rsSplitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsSplitContainer rsSplitContainer1;
		private RosySystem.Customize.btPreview btPreview;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btNew btNew;
	}
}