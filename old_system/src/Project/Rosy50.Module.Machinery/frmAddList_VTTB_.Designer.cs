namespace RosyModule.Machinery
{
    partial class frmAddList_VTTB_
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
            this.btCancel = new RosySystem.Customize.btDelete();
            this.btAdd = new RosySystem.Customize.btDelete();
            this.btSave = new RosySystem.Customize.btNew();
            this.btRemove = new RosySystem.Customize.btDelete();
            this.txtMa_Cum = new RosySystem.Control.rsTextBox();
            this.lbMa_Vt = new RosySystem.Control.rsLabel();
            this.btRefresh = new RosySystem.Customize.btNew();
            this.rsTabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btDelete = new RosySystem.Customize.btNew();
            this.lbtTen_Cum_Tb = new RosySystem.Control.rsLabel();
            this.rsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.ImageKey = "(none)";
            this.btCancel.Location = new System.Drawing.Point(1278, 736);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(89, 37);
            this.btCancel.TabIndex = 31;
            this.btCancel.Tag = "";
            this.btCancel.Text = "Hủy bỏ";
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btAdd
            // 
            this.btAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAdd.ImageKey = "(none)";
            this.btAdd.Location = new System.Drawing.Point(636, 329);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(79, 35);
            this.btAdd.TabIndex = 30;
            this.btAdd.Tag = "";
            this.btAdd.Text = ">>";
            this.btAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageKey = "(none)";
            this.btSave.Location = new System.Drawing.Point(1090, 736);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(88, 37);
            this.btSave.TabIndex = 28;
            this.btSave.Tag = "";
            this.btSave.Text = "&Lưu";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btRemove
            // 
            this.btRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRemove.ImageKey = "(none)";
            this.btRemove.Location = new System.Drawing.Point(636, 372);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(79, 35);
            this.btRemove.TabIndex = 32;
            this.btRemove.Tag = "";
            this.btRemove.Text = "<<";
            this.btRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRemove.UseVisualStyleBackColor = true;
            // 
            // txtMa_Cum
            // 
            this.txtMa_Cum.AutoDropDown = null;
            this.txtMa_Cum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Cum.Location = new System.Drawing.Point(74, 12);
            this.txtMa_Cum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Cum.MaxLength = 20;
            this.txtMa_Cum.Name = "txtMa_Cum";
            this.txtMa_Cum.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Cum.TabIndex = 135;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.Location = new System.Drawing.Point(7, 15);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(62, 13);
            this.lbMa_Vt.TabIndex = 136;
            this.lbMa_Vt.Tag = "Ma_Cum";
            this.lbMa_Vt.Text = "Cụm thiết bị";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.ImageKey = "(none)";
            this.btRefresh.Location = new System.Drawing.Point(1262, 6);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(88, 37);
            this.btRefresh.TabIndex = 28;
            this.btRefresh.Tag = "Refresh";
            this.btRefresh.Text = "&Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // rsTabControl1
            // 
            this.rsTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsTabControl1.Controls.Add(this.tabPage1);
            this.rsTabControl1.Location = new System.Drawing.Point(5, 0);
            this.rsTabControl1.Name = "rsTabControl1";
            this.rsTabControl1.SelectedIndex = 0;
            this.rsTabControl1.Size = new System.Drawing.Size(1364, 82);
            this.rsTabControl1.TabIndex = 137;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMa_Cum);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Controls.Add(this.lbtTen_Cum_Tb);
            this.tabPage1.Controls.Add(this.lbMa_Vt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1356, 56);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chọn dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 88);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(1358, 642);
            this.splitContainer1.SplitterDistance = 619;
            this.splitContainer1.SplitterWidth = 100;
            this.splitContainer1.TabIndex = 138;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "(none)";
            this.btDelete.Location = new System.Drawing.Point(1184, 736);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(88, 37);
            this.btDelete.TabIndex = 28;
            this.btDelete.Tag = "";
            this.btDelete.Text = "&Xóa";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // lbtTen_Cum_Tb
            // 
            this.lbtTen_Cum_Tb.AutoEllipsis = true;
            this.lbtTen_Cum_Tb.AutoSize = true;
            this.lbtTen_Cum_Tb.Location = new System.Drawing.Point(199, 15);
            this.lbtTen_Cum_Tb.Name = "lbtTen_Cum_Tb";
            this.lbtTen_Cum_Tb.Size = new System.Drawing.Size(62, 13);
            this.lbtTen_Cum_Tb.TabIndex = 136;
            this.lbtTen_Cum_Tb.Tag = "Ma_Cum";
            this.lbtTen_Cum_Tb.Text = "Cụm thiết bị";
            this.lbtTen_Cum_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAddList_VTTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 785);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.rsTabControl1);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAddList_VTTB";
            this.Text = "AddList vật tư thiết bị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Customize.btDelete btAdd;
		private RosySystem.Customize.btNew btSave;
		private RosySystem.Customize.btDelete btCancel;
        private RosySystem.Customize.btDelete btRemove;
        private RosySystem.Control.rsTextBox txtMa_Cum;
        private RosySystem.Control.rsLabel lbMa_Vt;
        private RosySystem.Customize.btNew btRefresh;
        private RosySystem.Control.rsTabControl rsTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private RosySystem.Customize.btNew btDelete;
        private RosySystem.Control.rsLabel lbtTen_Cum_Tb;
	}
}