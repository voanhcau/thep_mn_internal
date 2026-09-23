namespace RosyControllerTMN
{
	partial class frmPermission_Edit
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
			this.lbTen_Nh_Dt = new RosySystem.Control.rsLabel();
			this.lbDm_Nh_Dt = new RosySystem.Control.rsLabel();
			this.txtObject_ID = new RosySystem.Control.rsTextBox();
			this.label2 = new RosySystem.Control.rsLabel();
			this.btgAccept = new RosySystem.Customize.btgAccept();
			this.lbtObject_Name = new RosySystem.Control.rsLabelName();
			this.chkAllow_Access = new RosySystem.Control.rsCheckbox();
			this.chkAllow_New = new RosySystem.Control.rsCheckbox();
			this.chkAllow_Edit = new RosySystem.Control.rsCheckbox();
			this.chkAllow_Delete = new RosySystem.Control.rsCheckbox();
			this.chkAllow_View = new RosySystem.Control.rsCheckbox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbTen_Nh_Dt
			// 
			this.lbTen_Nh_Dt.AutoEllipsis = true;
			this.lbTen_Nh_Dt.AutoSize = true;
			this.lbTen_Nh_Dt.Location = new System.Drawing.Point(-97, 135);
			this.lbTen_Nh_Dt.Name = "lbTen_Nh_Dt";
			this.lbTen_Nh_Dt.Size = new System.Drawing.Size(55, 13);
			this.lbTen_Nh_Dt.TabIndex = 3;
			this.lbTen_Nh_Dt.Text = "Tên nhóm";
			this.lbTen_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbDm_Nh_Dt
			// 
			this.lbDm_Nh_Dt.AutoEllipsis = true;
			this.lbDm_Nh_Dt.AutoSize = true;
			this.lbDm_Nh_Dt.Location = new System.Drawing.Point(-97, 113);
			this.lbDm_Nh_Dt.Name = "lbDm_Nh_Dt";
			this.lbDm_Nh_Dt.Size = new System.Drawing.Size(51, 13);
			this.lbDm_Nh_Dt.TabIndex = 4;
			this.lbDm_Nh_Dt.Text = "Mã nhóm";
			this.lbDm_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtObject_ID
			// 
			this.txtObject_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtObject_ID.Location = new System.Drawing.Point(138, 23);
			this.txtObject_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtObject_ID.Name = "txtObject_ID";
			this.txtObject_ID.Size = new System.Drawing.Size(129, 20);
			this.txtObject_ID.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoEllipsis = true;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 13);
			this.label2.TabIndex = 0;
			this.label2.Tag = "Object_ID";
			this.label2.Text = "Đối tượng phân quyền";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.Location = new System.Drawing.Point(321, 219);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 47);
			this.btgAccept.TabIndex = 5;
			// 
			// lbtObject_Name
			// 
			this.lbtObject_Name.AutoEllipsis = true;
			this.lbtObject_Name.AutoSize = true;
			this.lbtObject_Name.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtObject_Name.Location = new System.Drawing.Point(272, 26);
			this.lbtObject_Name.Name = "lbtObject_Name";
			this.lbtObject_Name.Size = new System.Drawing.Size(133, 13);
			this.lbtObject_Name.TabIndex = 2;
			this.lbtObject_Name.Tag = "";
			this.lbtObject_Name.Text = "Tên đối tượng phân quyền";
			this.lbtObject_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkAllow_Access
			// 
			this.chkAllow_Access.AutoSize = true;
			this.chkAllow_Access.Checked = true;
			this.chkAllow_Access.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllow_Access.Location = new System.Drawing.Point(62, 26);
			this.chkAllow_Access.Name = "chkAllow_Access";
			this.chkAllow_Access.Size = new System.Drawing.Size(120, 17);
			this.chkAllow_Access.TabIndex = 0;
			this.chkAllow_Access.Tag = "Allow_Access";
			this.chkAllow_Access.Text = "Được phép truy cập";
			this.chkAllow_Access.UseVisualStyleBackColor = true;
			// 
			// chkAllow_New
			// 
			this.chkAllow_New.AutoSize = true;
			this.chkAllow_New.Checked = true;
			this.chkAllow_New.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllow_New.Location = new System.Drawing.Point(62, 49);
			this.chkAllow_New.Name = "chkAllow_New";
			this.chkAllow_New.Size = new System.Drawing.Size(124, 17);
			this.chkAllow_New.TabIndex = 1;
			this.chkAllow_New.Tag = "Allow_New";
			this.chkAllow_New.Text = "Được phép thêm mới";
			this.chkAllow_New.UseVisualStyleBackColor = true;
			// 
			// chkAllow_Edit
			// 
			this.chkAllow_Edit.AutoSize = true;
			this.chkAllow_Edit.Checked = true;
			this.chkAllow_Edit.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllow_Edit.Location = new System.Drawing.Point(62, 72);
			this.chkAllow_Edit.Name = "chkAllow_Edit";
			this.chkAllow_Edit.Size = new System.Drawing.Size(99, 17);
			this.chkAllow_Edit.TabIndex = 2;
			this.chkAllow_Edit.Tag = "Allow_Edit";
			this.chkAllow_Edit.Text = "Được phép sửa";
			this.chkAllow_Edit.UseVisualStyleBackColor = true;
			// 
			// chkAllow_Delete
			// 
			this.chkAllow_Delete.AutoSize = true;
			this.chkAllow_Delete.Checked = true;
			this.chkAllow_Delete.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllow_Delete.Location = new System.Drawing.Point(62, 95);
			this.chkAllow_Delete.Name = "chkAllow_Delete";
			this.chkAllow_Delete.Size = new System.Drawing.Size(99, 17);
			this.chkAllow_Delete.TabIndex = 3;
			this.chkAllow_Delete.Tag = "Allow_Delete";
			this.chkAllow_Delete.Text = "Được phép xóa";
			this.chkAllow_Delete.UseVisualStyleBackColor = true;
			// 
			// chkAllow_View
			// 
			this.chkAllow_View.AutoSize = true;
			this.chkAllow_View.Checked = true;
			this.chkAllow_View.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllow_View.Location = new System.Drawing.Point(62, 118);
			this.chkAllow_View.Name = "chkAllow_View";
			this.chkAllow_View.Size = new System.Drawing.Size(101, 17);
			this.chkAllow_View.TabIndex = 4;
			this.chkAllow_View.Tag = "Allow_View";
			this.chkAllow_View.Text = "Được phép xem";
			this.chkAllow_View.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkAllow_View);
			this.groupBox1.Controls.Add(this.chkAllow_Delete);
			this.groupBox1.Controls.Add(this.chkAllow_Edit);
			this.groupBox1.Controls.Add(this.chkAllow_New);
			this.groupBox1.Controls.Add(this.chkAllow_Access);
			this.groupBox1.Location = new System.Drawing.Point(76, 61);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(426, 148);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Phân quyền";
			// 
			// frmPermission_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 274);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.txtObject_ID);
			this.Controls.Add(this.lbtObject_Name);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbTen_Nh_Dt);
			this.Controls.Add(this.lbDm_Nh_Dt);
			this.Name = "frmPermission_Edit";
			this.Text = "frmPermission_Edit";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private RosySystem.Control.rsLabel lbTen_Nh_Dt;
		private RosySystem.Control.rsLabel lbDm_Nh_Dt;
		private RosySystem.Control.rsTextBox txtObject_ID;
		private RosySystem.Control.rsLabel label2;
		private RosySystem.Customize.btgAccept btgAccept;
		private RosySystem.Control.rsLabelName lbtObject_Name;
		public RosySystem.Control.rsCheckbox chkAllow_Access;
		public RosySystem.Control.rsCheckbox chkAllow_New;
		public RosySystem.Control.rsCheckbox chkAllow_Edit;
		public RosySystem.Control.rsCheckbox chkAllow_Delete;
		public RosySystem.Control.rsCheckbox chkAllow_View;
		private System.Windows.Forms.GroupBox groupBox1;
    }
}