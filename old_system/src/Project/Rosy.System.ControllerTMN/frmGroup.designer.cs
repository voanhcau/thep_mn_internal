namespace RosyControllerTMN
{
    partial class frmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroup));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer = new RosySystem.Control.rsSplitContainer();
            this.lvUser = new RosySystem.Control.rsListView();
            this.tvGroup = new System.Windows.Forms.TreeView();
            this.btGet_User = new RosySystem.Customize.btExit();
            this.btExit = new RosySystem.Customize.btExit();
            this.btDelete = new RosySystem.Customize.btDelete();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btNew = new RosySystem.Customize.btNew();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Group");
            this.imageList1.Images.SetKeyName(1, "User");
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvUser);
            this.splitContainer.Panel1.Controls.Add(this.tvGroup);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btGet_User);
            this.splitContainer.Panel2.Controls.Add(this.btExit);
            this.splitContainer.Panel2.Controls.Add(this.btDelete);
            this.splitContainer.Panel2.Controls.Add(this.btEdit);
            this.splitContainer.Panel2.Controls.Add(this.btNew);
            this.splitContainer.Size = new System.Drawing.Size(792, 590);
            this.splitContainer.SplitterDistance = 534;
            this.splitContainer.TabIndex = 0;
            // 
            // lvUser
            // 
            this.lvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUser.DataSource = null;
            this.lvUser.FullRowSelect = true;
            this.lvUser.GridLines = true;
            this.lvUser.HideSelection = false;
            this.lvUser.Location = new System.Drawing.Point(232, 3);
            this.lvUser.MultiSelect = false;
            this.lvUser.Name = "lvUser";
            this.lvUser.Size = new System.Drawing.Size(557, 528);
            this.lvUser.SmallImageList = this.imageList1;
            this.lvUser.strZone = "";
            this.lvUser.TabIndex = 1;
            this.lvUser.UseCompatibleStateImageBehavior = false;
            this.lvUser.View = System.Windows.Forms.View.Details;
            // 
            // tvGroup
            // 
            this.tvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvGroup.FullRowSelect = true;
            this.tvGroup.HideSelection = false;
            this.tvGroup.ImageIndex = 0;
            this.tvGroup.ImageList = this.imageList1;
            this.tvGroup.Location = new System.Drawing.Point(3, 3);
            this.tvGroup.Name = "tvGroup";
            this.tvGroup.SelectedImageIndex = 0;
            this.tvGroup.Size = new System.Drawing.Size(226, 528);
            this.tvGroup.TabIndex = 0;
            // 
            // btGet_User
            // 
            this.btGet_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGet_User.Image = ((System.Drawing.Image)(resources.GetObject("btGet_User.Image")));
            this.btGet_User.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGet_User.ImageKey = "exit2.png";
            this.btGet_User.Location = new System.Drawing.Point(240, 1);
            this.btGet_User.Name = "btGet_User";
            this.btGet_User.Size = new System.Drawing.Size(70, 50);
            this.btGet_User.TabIndex = 3;
            this.btGet_User.Tag = "Exit";
            this.btGet_User.Text = "Get Users";
            this.btGet_User.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGet_User.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(316, 1);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(70, 50);
            this.btExit.TabIndex = 4;
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
            this.btDelete.Location = new System.Drawing.Point(164, 1);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(70, 50);
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
            this.btEdit.Location = new System.Drawing.Point(88, 1);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(70, 50);
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
            this.btNew.Location = new System.Drawing.Point(12, 1);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(70, 50);
            this.btNew.TabIndex = 0;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // frmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 591);
            this.Controls.Add(this.splitContainer);
            this.Name = "frmGroup";
            this.Object_ID = "USER";
            this.Text = "frmGroup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ImageList imageList1;
		private RosySystem.Control.rsSplitContainer splitContainer;
		private RosySystem.Control.rsListView lvUser;
		private System.Windows.Forms.TreeView tvGroup;
		private RosySystem.Customize.btExit btExit;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btNew btNew;
        private RosySystem.Customize.btExit btGet_User;
    }
}