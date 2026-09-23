namespace RosyModule.General
{
	partial class frmBudget
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvBudget = new RosySystem.Control.rsDataGridView();
			this.btNew = new RosySystem.Customize.btNew();
			this.btEdit = new RosySystem.Customize.btEdit();
			this.btDelete = new RosySystem.Customize.btDelete();
			this.btExit = new RosySystem.Customize.btExit();
			((System.ComponentModel.ISupportInitialize)(this.dgvBudget)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvBudget
			// 
			this.dgvBudget.AllowUserToAddRows = false;
			this.dgvBudget.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvBudget.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvBudget.BackgroundColor = System.Drawing.Color.White;
			this.dgvBudget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvBudget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBudget.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvBudget.Location = new System.Drawing.Point(6, 9);
			this.dgvBudget.MultiSelect = false;
			this.dgvBudget.Name = "dgvBudget";
			this.dgvBudget.ReadOnly = true;
			this.dgvBudget.Size = new System.Drawing.Size(781, 513);
			this.dgvBudget.strZone = "";
			this.dgvBudget.TabIndex = 0;
			// 
			// btNew
			// 
			this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew.Location = new System.Drawing.Point(6, 531);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(67, 23);
			this.btNew.TabIndex = 20;
			this.btNew.Tag = "New";
			this.btNew.Text = "&Thêm";
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// btEdit
			// 
			this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit.Location = new System.Drawing.Point(77, 531);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(67, 23);
			this.btEdit.TabIndex = 21;
			this.btEdit.Tag = "Edit";
			this.btEdit.Text = "&Sửa";
			this.btEdit.UseVisualStyleBackColor = true;
			// 
			// btDelete
			// 
			this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDelete.Location = new System.Drawing.Point(148, 531);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(67, 23);
			this.btDelete.TabIndex = 22;
			this.btDelete.Tag = "Delete";
			this.btDelete.Text = "&Xóa";
			this.btDelete.UseVisualStyleBackColor = true;
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btExit.Location = new System.Drawing.Point(221, 531);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(67, 23);
			this.btExit.TabIndex = 23;
			this.btExit.Tag = "Exit";
			this.btExit.Text = "Th&oát";
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// frmBudget
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.dgvBudget);
			this.Controls.Add(this.btNew);
			this.Controls.Add(this.btEdit);
			this.Controls.Add(this.btDelete);
			this.Controls.Add(this.btExit);
			this.Name = "frmBudget";
			this.Text = "CashBudget";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvBudget)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvBudget;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btExit btExit;


	}
}