namespace RosyList
{
	partial class frmView
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
            this.splitcContent = new System.Windows.Forms.SplitContainer();
            this.btImport = new RosySystem.Customize.btImport();
            this.btMerge = new RosySystem.Customize.btMerge();
            this.btExit = new RosySystem.Customize.btExit();
            this.btDelete = new RosySystem.Customize.btDelete();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btNew = new RosySystem.Customize.btNew();
            ((System.ComponentModel.ISupportInitialize)(this.splitcContent)).BeginInit();
            this.splitcContent.Panel2.SuspendLayout();
            this.splitcContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitcContent
            // 
            this.splitcContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitcContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitcContent.IsSplitterFixed = true;
            this.splitcContent.Location = new System.Drawing.Point(0, 0);
            this.splitcContent.Name = "splitcContent";
            this.splitcContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitcContent.Panel1MinSize = 0;
            // 
            // splitcContent.Panel2
            // 
            this.splitcContent.Panel2.Controls.Add(this.btImport);
            this.splitcContent.Panel2.Controls.Add(this.btMerge);
            this.splitcContent.Panel2.Controls.Add(this.btExit);
            this.splitcContent.Panel2.Controls.Add(this.btDelete);
            this.splitcContent.Panel2.Controls.Add(this.btEdit);
            this.splitcContent.Panel2.Controls.Add(this.btNew);
            this.splitcContent.Panel2MinSize = 0;
            this.splitcContent.Size = new System.Drawing.Size(792, 566);
            this.splitcContent.SplitterDistance = 504;
            this.splitcContent.TabIndex = 1;
            this.splitcContent.TabStop = false;
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.ImageKey = "import.png";
            this.btImport.Location = new System.Drawing.Point(340, 4);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(76, 50);
            this.btImport.TabIndex = 5;
            this.btImport.Tag = "Import";
            this.btImport.Text = "Import";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btMerge
            // 
            this.btMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMerge.ImageKey = "Merge.png";
            this.btMerge.Location = new System.Drawing.Point(258, 4);
            this.btMerge.Name = "btMerge";
            this.btMerge.Size = new System.Drawing.Size(76, 50);
            this.btMerge.TabIndex = 3;
            this.btMerge.Tag = "MergeID";
            this.btMerge.Text = "Gộp mã";
            this.btMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btMerge.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(422, 4);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(76, 50);
            this.btExit.TabIndex = 6;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Th&oát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Delete.png";
            this.btDelete.Location = new System.Drawing.Point(176, 4);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(76, 50);
            this.btDelete.TabIndex = 2;
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
            this.btEdit.Location = new System.Drawing.Point(94, 4);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(76, 50);
            this.btEdit.TabIndex = 1;
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
            this.btNew.Location = new System.Drawing.Point(12, 4);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(76, 50);
            this.btNew.TabIndex = 0;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.splitcContent);
            this.Name = "frmView";
            this.splitcContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcContent)).EndInit();
            this.splitcContent.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.SplitContainer splitcContent;
		private RosySystem.Customize.btMerge btMerge;
		private RosySystem.Customize.btExit btExit;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btNew btNew;
		public RosySystem.Customize.btImport btImport;





	}
}