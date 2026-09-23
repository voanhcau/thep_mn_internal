namespace RosyModule.General
{
    partial class frmKetChuyen
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
			this.btKetChuyen = new RosySystem.Customize.btPreview();
			this.btDelete = new RosySystem.Customize.btDelete();
			this.rsSplitContainer2 = new RosySystem.Control.rsSplitContainer();
			this.btDeleteKc = new RosySystem.Customize.btEdit();
			this.btEdit = new RosySystem.Customize.btEdit();
			this.btNew = new RosySystem.Customize.btNew();
			((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer2)).BeginInit();
			this.rsSplitContainer2.Panel2.SuspendLayout();
			this.rsSplitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btKetChuyen
			// 
			this.btKetChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btKetChuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btKetChuyen.ImageKey = "Preview.png";
			this.btKetChuyen.Location = new System.Drawing.Point(251, 6);
			this.btKetChuyen.Name = "btKetChuyen";
			this.btKetChuyen.Size = new System.Drawing.Size(78, 49);
			this.btKetChuyen.TabIndex = 23;
			this.btKetChuyen.Tag = "";
			this.btKetChuyen.Text = "Kết chuyển";
			this.btKetChuyen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btKetChuyen.UseVisualStyleBackColor = true;
			// 
			// btDelete
			// 
			this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDelete.ImageKey = "Delete.png";
			this.btDelete.Location = new System.Drawing.Point(169, 6);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(74, 50);
			this.btDelete.TabIndex = 18;
			this.btDelete.Tag = "";
			this.btDelete.Text = "&Xóa";
			this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btDelete.UseVisualStyleBackColor = true;
			// 
			// rsSplitContainer2
			// 
			this.rsSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rsSplitContainer2.Location = new System.Drawing.Point(0, 0);
			this.rsSplitContainer2.Name = "rsSplitContainer2";
			this.rsSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// rsSplitContainer2.Panel2
			// 
			this.rsSplitContainer2.Panel2.Controls.Add(this.btDeleteKc);
			this.rsSplitContainer2.Panel2.Controls.Add(this.btKetChuyen);
			this.rsSplitContainer2.Panel2.Controls.Add(this.btDelete);
			this.rsSplitContainer2.Panel2.Controls.Add(this.btEdit);
			this.rsSplitContainer2.Panel2.Controls.Add(this.btNew);
			this.rsSplitContainer2.Size = new System.Drawing.Size(792, 569);
			this.rsSplitContainer2.SplitterDistance = 497;
			this.rsSplitContainer2.TabIndex = 2;
			// 
			// btDeleteKc
			// 
			this.btDeleteKc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDeleteKc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDeleteKc.ImageKey = "Edit.png";
			this.btDeleteKc.Location = new System.Drawing.Point(336, 8);
			this.btDeleteKc.Name = "btDeleteKc";
			this.btDeleteKc.Size = new System.Drawing.Size(77, 47);
			this.btDeleteKc.TabIndex = 25;
			this.btDeleteKc.Tag = "";
			this.btDeleteKc.Text = "Xóa KC";
			this.btDeleteKc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btDeleteKc.UseVisualStyleBackColor = true;
			// 
			// btEdit
			// 
			this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit.ImageKey = "Edit.png";
			this.btEdit.Location = new System.Drawing.Point(87, 6);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(74, 50);
			this.btEdit.TabIndex = 17;
			this.btEdit.Tag = "";
			this.btEdit.Text = "&Sửa";
			this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btEdit.UseVisualStyleBackColor = true;
			// 
			// btNew
			// 
			this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew.ImageKey = "New.png";
			this.btNew.Location = new System.Drawing.Point(3, 6);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(74, 50);
			this.btNew.TabIndex = 16;
			this.btNew.Tag = "";
			this.btNew.Text = "&Thêm";
			this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// frmKetChuyen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 569);
			this.Controls.Add(this.rsSplitContainer2);
			this.Name = "frmKetChuyen";
			this.Object_ID = "DMKHO";
			this.Tag = "F2, F3, F8, ESC,F10,CTRL_F10";
			this.Text = "frmDmKho";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.rsSplitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rsSplitContainer2)).EndInit();
			this.rsSplitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Customize.btPreview btKetChuyen;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Control.rsSplitContainer rsSplitContainer2;
		private RosySystem.Customize.btEdit btDeleteKc;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btNew btNew;

	}
}