namespace RosyModule.Salary
{
    partial class frmHsABC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHieuQua = new RosySystem.Control.rsDataGridView();
            this.btNew = new RosySystem.Customize.btNew();
            this.btEdit = new RosySystem.Customize.btEdit();
            this.btDelete = new RosySystem.Customize.btDelete();
            this.btExit = new RosySystem.Customize.btExit();
            this.btChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHieuQua)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHieuQua
            // 
            this.dgvHieuQua.AllowUserToAddRows = false;
            this.dgvHieuQua.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHieuQua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHieuQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHieuQua.BackgroundColor = System.Drawing.Color.White;
            this.dgvHieuQua.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHieuQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHieuQua.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvHieuQua.Location = new System.Drawing.Point(6, 9);
            this.dgvHieuQua.MultiSelect = false;
            this.dgvHieuQua.Name = "dgvHieuQua";
            this.dgvHieuQua.ReadOnly = true;
            this.dgvHieuQua.Size = new System.Drawing.Size(781, 490);
            this.dgvHieuQua.strZone = "";
            this.dgvHieuQua.TabIndex = 0;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.ImageKey = "New.png";
            this.btNew.Location = new System.Drawing.Point(12, 505);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(67, 49);
            this.btNew.TabIndex = 20;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.ImageKey = "Edit.png";
            this.btEdit.Location = new System.Drawing.Point(83, 505);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(67, 49);
            this.btEdit.TabIndex = 21;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "&Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageKey = "Delete.png";
            this.btDelete.Location = new System.Drawing.Point(154, 505);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(67, 49);
            this.btDelete.TabIndex = 22;
            this.btDelete.Tag = "Delete";
            this.btDelete.Text = "&Xóa";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageKey = "exit2.png";
            this.btExit.Location = new System.Drawing.Point(227, 505);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(67, 49);
            this.btExit.TabIndex = 23;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "Th&oát";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btChart
            // 
            this.btChart.Location = new System.Drawing.Point(712, 508);
            this.btChart.Name = "btChart";
            this.btChart.Size = new System.Drawing.Size(68, 46);
            this.btChart.TabIndex = 24;
            this.btChart.Text = "Biểu đồ";
            this.btChart.UseVisualStyleBackColor = true;
            this.btChart.Visible = false;
            this.btChart.Click += new System.EventHandler(this.btChart_Click);
            // 
            // frmHsABC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btChart);
            this.Controls.Add(this.dgvHieuQua);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btExit);
            this.Name = "frmHsABC";
            this.Text = "Hiệu quả";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvHieuQua)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvHieuQua;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btExit btExit;
		private System.Windows.Forms.Button btChart;


	}
}