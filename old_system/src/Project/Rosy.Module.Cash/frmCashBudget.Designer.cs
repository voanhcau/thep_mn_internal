namespace RosyModule.Cash
{
	partial class frmCashBudget
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashBudget));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgvCashBudget = new RosySystem.Control.rsDataGridView();
			this.dgvCashBudgetCt = new RosySystem.Control.rsDataGridView();
			this.lblTTien0 = new RosySystem.Control.rsLabel();
			this.btNew = new RosySystem.Customize.btNew();
			this.numTTien_Chi_Nt = new RosySystem.Control.rsTextBoxNumber();
			this.btEdit = new RosySystem.Customize.btEdit();
			this.numTTien_Chi = new RosySystem.Control.rsTextBoxNumber();
			this.btDelete = new RosySystem.Customize.btDelete();
			this.btExit = new RosySystem.Customize.btExit();
			this.numTTien_Thu = new RosySystem.Control.rsTextBoxNumber();
			this.numTTien_Thu_Nt = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCashBudget)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCashBudgetCt)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dgvCashBudget);
			this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(3);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvCashBudgetCt);
			this.splitContainer1.Panel2.Controls.Add(this.rsLabel1);
			this.splitContainer1.Panel2.Controls.Add(this.lblTTien0);
			this.splitContainer1.Panel2.Controls.Add(this.btNew);
			this.splitContainer1.Panel2.Controls.Add(this.numTTien_Thu_Nt);
			this.splitContainer1.Panel2.Controls.Add(this.numTTien_Chi_Nt);
			this.splitContainer1.Panel2.Controls.Add(this.numTTien_Thu);
			this.splitContainer1.Panel2.Controls.Add(this.btEdit);
			this.splitContainer1.Panel2.Controls.Add(this.numTTien_Chi);
			this.splitContainer1.Panel2.Controls.Add(this.btDelete);
			this.splitContainer1.Panel2.Controls.Add(this.btExit);
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new System.Drawing.Size(792, 566);
			this.splitContainer1.SplitterDistance = 283;
			this.splitContainer1.TabIndex = 1;
			// 
			// dgvCashBudget
			// 
			this.dgvCashBudget.AllowUserToAddRows = false;
			this.dgvCashBudget.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvCashBudget.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvCashBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCashBudget.BackgroundColor = System.Drawing.Color.White;
			this.dgvCashBudget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvCashBudget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCashBudget.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvCashBudget.Location = new System.Drawing.Point(6, 6);
			this.dgvCashBudget.MultiSelect = false;
			this.dgvCashBudget.Name = "dgvCashBudget";
			this.dgvCashBudget.ReadOnly = true;
			this.dgvCashBudget.Size = new System.Drawing.Size(781, 271);
			this.dgvCashBudget.strZone = "";
			this.dgvCashBudget.TabIndex = 19;
			// 
			// dgvCashBudgetCt
			// 
			this.dgvCashBudgetCt.AllowUserToAddRows = false;
			this.dgvCashBudgetCt.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvCashBudgetCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvCashBudgetCt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCashBudgetCt.BackgroundColor = System.Drawing.Color.White;
			this.dgvCashBudgetCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvCashBudgetCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCashBudgetCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvCashBudgetCt.Location = new System.Drawing.Point(6, 5);
			this.dgvCashBudgetCt.MultiSelect = false;
			this.dgvCashBudgetCt.Name = "dgvCashBudgetCt";
			this.dgvCashBudgetCt.ReadOnly = true;
			this.dgvCashBudgetCt.Size = new System.Drawing.Size(781, 225);
			this.dgvCashBudgetCt.strZone = "";
			this.dgvCashBudgetCt.TabIndex = 19;
			// 
			// lblTTien0
			// 
			this.lblTTien0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTTien0.AutoEllipsis = true;
			this.lblTTien0.AutoSize = true;
			this.lblTTien0.Enabled = false;
			this.lblTTien0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTTien0.Location = new System.Drawing.Point(501, 258);
			this.lblTTien0.Name = "lblTTien0";
			this.lblTTien0.Size = new System.Drawing.Size(53, 13);
			this.lblTTien0.TabIndex = 113;
			this.lblTTien0.Tag = "TTIEN_CHI";
			this.lblTTien0.Text = "Tiền chi";
			this.lblTTien0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btNew
			// 
			this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btNew.Image = ((System.Drawing.Image)(resources.GetObject("btNew.Image")));
			this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btNew.Location = new System.Drawing.Point(9, 248);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(67, 23);
			this.btNew.TabIndex = 13;
			this.btNew.Tag = "New";
			this.btNew.Text = "&Thêm";
			this.btNew.UseVisualStyleBackColor = true;
			// 
			// numTTien_Chi_Nt
			// 
			this.numTTien_Chi_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numTTien_Chi_Nt.bFormat = true;
			this.numTTien_Chi_Nt.Enabled = false;
			this.numTTien_Chi_Nt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTTien_Chi_Nt.Location = new System.Drawing.Point(688, 255);
			this.numTTien_Chi_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTTien_Chi_Nt.Name = "numTTien_Chi_Nt";
			this.numTTien_Chi_Nt.Scale = 2;
			this.numTTien_Chi_Nt.Size = new System.Drawing.Size(99, 20);
			this.numTTien_Chi_Nt.TabIndex = 111;
			this.numTTien_Chi_Nt.TabStop = false;
			this.numTTien_Chi_Nt.Text = "0.00";
			this.numTTien_Chi_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTTien_Chi_Nt.Value = 0;
			// 
			// btEdit
			// 
			this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btEdit.Image = ((System.Drawing.Image)(resources.GetObject("btEdit.Image")));
			this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEdit.Location = new System.Drawing.Point(80, 248);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(67, 23);
			this.btEdit.TabIndex = 14;
			this.btEdit.Tag = "Edit";
			this.btEdit.Text = "&Sửa";
			this.btEdit.UseVisualStyleBackColor = true;
			// 
			// numTTien_Chi
			// 
			this.numTTien_Chi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numTTien_Chi.bFormat = true;
			this.numTTien_Chi.Enabled = false;
			this.numTTien_Chi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTTien_Chi.Location = new System.Drawing.Point(585, 255);
			this.numTTien_Chi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTTien_Chi.Name = "numTTien_Chi";
			this.numTTien_Chi.Scale = 0;
			this.numTTien_Chi.Size = new System.Drawing.Size(99, 20);
			this.numTTien_Chi.TabIndex = 112;
			this.numTTien_Chi.TabStop = false;
			this.numTTien_Chi.Text = "0";
			this.numTTien_Chi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTTien_Chi.Value = 0;
			// 
			// btDelete
			// 
			this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDelete.Image = ((System.Drawing.Image)(resources.GetObject("btDelete.Image")));
			this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDelete.Location = new System.Drawing.Point(151, 248);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(67, 23);
			this.btDelete.TabIndex = 15;
			this.btDelete.Tag = "Delete";
			this.btDelete.Text = "&Xóa";
			this.btDelete.UseVisualStyleBackColor = true;
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExit.Image = ((System.Drawing.Image)(resources.GetObject("btExit.Image")));
			this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btExit.Location = new System.Drawing.Point(222, 248);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(67, 23);
			this.btExit.TabIndex = 16;
			this.btExit.Tag = "Exit";
			this.btExit.Text = "Th&oát";
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// numTTien_Thu
			// 
			this.numTTien_Thu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numTTien_Thu.bFormat = true;
			this.numTTien_Thu.Enabled = false;
			this.numTTien_Thu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTTien_Thu.Location = new System.Drawing.Point(585, 233);
			this.numTTien_Thu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTTien_Thu.Name = "numTTien_Thu";
			this.numTTien_Thu.Scale = 0;
			this.numTTien_Thu.Size = new System.Drawing.Size(99, 20);
			this.numTTien_Thu.TabIndex = 112;
			this.numTTien_Thu.TabStop = false;
			this.numTTien_Thu.Text = "0";
			this.numTTien_Thu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTTien_Thu.Value = 0;
			// 
			// numTTien_Thu_Nt
			// 
			this.numTTien_Thu_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numTTien_Thu_Nt.bFormat = true;
			this.numTTien_Thu_Nt.Enabled = false;
			this.numTTien_Thu_Nt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTTien_Thu_Nt.Location = new System.Drawing.Point(688, 233);
			this.numTTien_Thu_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numTTien_Thu_Nt.Name = "numTTien_Thu_Nt";
			this.numTTien_Thu_Nt.Scale = 2;
			this.numTTien_Thu_Nt.Size = new System.Drawing.Size(99, 20);
			this.numTTien_Thu_Nt.TabIndex = 111;
			this.numTTien_Thu_Nt.TabStop = false;
			this.numTTien_Thu_Nt.Text = "0.00";
			this.numTTien_Thu_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTTien_Thu_Nt.Value = 0;
			// 
			// rsLabel1
			// 
			this.rsLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Enabled = false;
			this.rsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rsLabel1.Location = new System.Drawing.Point(501, 236);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(54, 13);
			this.rsLabel1.TabIndex = 113;
			this.rsLabel1.Tag = "TTIEN_THU";
			this.rsLabel1.Text = "Tiền thu";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmCashBudget
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmCashBudget";
			this.Text = "CashBudget";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCashBudget)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCashBudgetCt)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private RosySystem.Control.rsDataGridView dgvCashBudget;
		private RosySystem.Control.rsDataGridView dgvCashBudgetCt;
		private RosySystem.Control.rsLabel lblTTien0;
		private RosySystem.Customize.btNew btNew;
		private RosySystem.Control.rsTextBoxNumber numTTien_Chi_Nt;
		private RosySystem.Customize.btEdit btEdit;
		private RosySystem.Control.rsTextBoxNumber numTTien_Chi;
		private RosySystem.Customize.btDelete btDelete;
		private RosySystem.Customize.btExit btExit;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxNumber numTTien_Thu_Nt;
		private RosySystem.Control.rsTextBoxNumber numTTien_Thu;

	}
}