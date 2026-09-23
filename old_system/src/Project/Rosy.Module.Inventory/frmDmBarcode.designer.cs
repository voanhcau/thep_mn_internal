namespace RosyModule.Inventory
{
    partial class frmDmBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmBarcode));
            this.rsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.numTBarcode = new RosySystem.Control.rsTextBoxNumber();
            this.rsLabelName3 = new RosySystem.Control.rsLabelName();
            this.btImport = new RosySystem.Customize.btImport();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.btFilter = new RosySystem.Customize.btFilter();
            this.btExit = new RosySystem.Customize.btExit();
            this.btDelete = new RosySystem.Customize.btDelete();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btNew = new RosySystem.Customize.btNew();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer)).BeginInit();
            this.rsSplitContainer.Panel2.SuspendLayout();
            this.rsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // rsSplitContainer
            // 
            this.rsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.rsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.rsSplitContainer.Name = "rsSplitContainer";
            this.rsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rsSplitContainer.Panel2
            // 
            this.rsSplitContainer.Panel2.Controls.Add(this.numTBarcode);
            this.rsSplitContainer.Panel2.Controls.Add(this.rsLabelName3);
            this.rsSplitContainer.Panel2.Controls.Add(this.btImport);
            this.rsSplitContainer.Panel2.Controls.Add(this.btRefresh);
            this.rsSplitContainer.Panel2.Controls.Add(this.btFilter);
            this.rsSplitContainer.Panel2.Controls.Add(this.btExit);
            this.rsSplitContainer.Panel2.Controls.Add(this.btDelete);
            this.rsSplitContainer.Panel2.Controls.Add(this.btEdit);
            this.rsSplitContainer.Panel2.Controls.Add(this.btNew);
            this.rsSplitContainer.Size = new System.Drawing.Size(911, 411);
            this.rsSplitContainer.SplitterDistance = 337;
            this.rsSplitContainer.TabIndex = 36;
            // 
            // numTBarcode
            // 
            this.numTBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTBarcode.bFormat = true;
            this.numTBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTBarcode.ForeColor = System.Drawing.Color.Blue;
            this.numTBarcode.Location = new System.Drawing.Point(787, 25);
            this.numTBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTBarcode.Name = "numTBarcode";
            this.numTBarcode.ReadOnly = true;
            this.numTBarcode.Scale = 0;
            this.numTBarcode.Size = new System.Drawing.Size(85, 20);
            this.numTBarcode.TabIndex = 50;
            this.numTBarcode.Text = "0";
            this.numTBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTBarcode.Value = 0D;
            // 
            // rsLabelName3
            // 
            this.rsLabelName3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rsLabelName3.AutoSize = true;
            this.rsLabelName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabelName3.ForeColor = System.Drawing.Color.Blue;
            this.rsLabelName3.Location = new System.Drawing.Point(700, 29);
            this.rsLabelName3.Name = "rsLabelName3";
            this.rsLabelName3.Size = new System.Drawing.Size(62, 13);
            this.rsLabelName3.TabIndex = 49;
            this.rsLabelName3.Text = "TBarcode";
            this.rsLabelName3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.ImageKey = "import.png";
            this.btImport.Location = new System.Drawing.Point(348, 19);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(70, 39);
            this.btImport.TabIndex = 42;
            this.btImport.Tag = "Import";
            this.btImport.Text = "Import";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.Location = new System.Drawing.Point(500, 19);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(93, 39);
            this.btRefresh.TabIndex = 44;
            this.btRefresh.Text = "Ctrl + F5 Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btFilter
            // 
            this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFilter.ImageKey = "Filter.png";
            this.btFilter.Location = new System.Drawing.Point(273, 19);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(70, 39);
            this.btFilter.TabIndex = 40;
            this.btFilter.Tag = "Filter";
            this.btFilter.Text = "&Lọc";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(424, 19);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(70, 39);
            this.btExit.TabIndex = 43;
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
            this.btDelete.Location = new System.Drawing.Point(197, 19);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(70, 39);
            this.btDelete.TabIndex = 38;
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
            this.btEdit.Location = new System.Drawing.Point(121, 19);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(70, 39);
            this.btEdit.TabIndex = 37;
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
            this.btNew.Location = new System.Drawing.Point(45, 19);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(70, 39);
            this.btNew.TabIndex = 36;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // frmDmBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 411);
            this.Controls.Add(this.rsSplitContainer);
            this.Name = "frmDmBarcode";
            this.Object_ID = "DmBarcode";
            this.Tag = "frmDmBarcode";
            this.Text = "frmDmBarcode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsSplitContainer.Panel2.ResumeLayout(false);
            this.rsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer)).EndInit();
            this.rsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer rsSplitContainer;
        private RosySystem.Control.rsTextBoxNumber numTBarcode;
        private RosySystem.Control.rsLabelName rsLabelName3;
        public RosySystem.Customize.btImport btImport;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Customize.btFilter btFilter;
        private RosySystem.Customize.btExit btExit;
        private RosySystem.Customize.btDelete btDelete;
        private RosySystem.Customize.btEdit btEdit;
        private RosySystem.Customize.btNew btNew;


	}
}