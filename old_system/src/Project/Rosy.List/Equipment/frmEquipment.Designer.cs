namespace RosyList
{
	partial class frmEquipment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcEquipment = new System.Windows.Forms.TabControl();
            this.tpEquipment = new System.Windows.Forms.TabPage();
            this.dgvEquipment = new RosySystem.Control.rsDataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpEquipmentInfo = new System.Windows.Forms.TabPage();
            this.dgvEquipmentInfo = new RosySystem.Control.rsDataGridView();
            this.tpEquipCt = new System.Windows.Forms.TabPage();
            this.dgvEquipCt = new RosySystem.Control.rsDataGridView();
            this.tcEquipment.SuspendLayout();
            this.tpEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpEquipmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentInfo)).BeginInit();
            this.tpEquipCt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipCt)).BeginInit();
            this.SuspendLayout();
            // 
            // tcEquipment
            // 
            this.tcEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcEquipment.Controls.Add(this.tpEquipment);
            this.tcEquipment.Location = new System.Drawing.Point(4, 5);
            this.tcEquipment.Name = "tcEquipment";
            this.tcEquipment.SelectedIndex = 0;
            this.tcEquipment.Size = new System.Drawing.Size(814, 278);
            this.tcEquipment.TabIndex = 1;
            this.tcEquipment.TabStop = false;
            // 
            // tpEquipment
            // 
            this.tpEquipment.Controls.Add(this.dgvEquipment);
            this.tpEquipment.Location = new System.Drawing.Point(4, 22);
            this.tpEquipment.Name = "tpEquipment";
            this.tpEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tpEquipment.Size = new System.Drawing.Size(806, 252);
            this.tpEquipment.TabIndex = 0;
            this.tpEquipment.Text = "Equipment";
            this.tpEquipment.UseVisualStyleBackColor = true;
            // 
            // dgvEquipment
            // 
            this.dgvEquipment.AllowUserToAddRows = false;
            this.dgvEquipment.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquipment.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipment.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEquipment.Location = new System.Drawing.Point(3, 3);
            this.dgvEquipment.MultiSelect = false;
            this.dgvEquipment.Name = "dgvEquipment";
            this.dgvEquipment.ReadOnly = true;
            this.dgvEquipment.Size = new System.Drawing.Size(800, 246);
            this.dgvEquipment.strZone = "";
            this.dgvEquipment.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpEquipmentInfo);
            this.tabControl.Controls.Add(this.tpEquipCt);
            this.tabControl.Location = new System.Drawing.Point(4, 285);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(814, 282);
            this.tabControl.TabIndex = 2;
            this.tabControl.TabStop = false;
            // 
            // tpEquipmentInfo
            // 
            this.tpEquipmentInfo.Controls.Add(this.dgvEquipmentInfo);
            this.tpEquipmentInfo.Location = new System.Drawing.Point(4, 22);
            this.tpEquipmentInfo.Name = "tpEquipmentInfo";
            this.tpEquipmentInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpEquipmentInfo.Size = new System.Drawing.Size(806, 256);
            this.tpEquipmentInfo.TabIndex = 0;
            this.tpEquipmentInfo.Text = "Equipment Info";
            this.tpEquipmentInfo.UseVisualStyleBackColor = true;
            // 
            // dgvEquipmentInfo
            // 
            this.dgvEquipmentInfo.AllowUserToAddRows = false;
            this.dgvEquipmentInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipmentInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquipmentInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipmentInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEquipmentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipmentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipmentInfo.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEquipmentInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvEquipmentInfo.MultiSelect = false;
            this.dgvEquipmentInfo.Name = "dgvEquipmentInfo";
            this.dgvEquipmentInfo.ReadOnly = true;
            this.dgvEquipmentInfo.Size = new System.Drawing.Size(800, 250);
            this.dgvEquipmentInfo.strZone = "";
            this.dgvEquipmentInfo.TabIndex = 1;
            // 
            // tpEquipCt
            // 
            this.tpEquipCt.Controls.Add(this.dgvEquipCt);
            this.tpEquipCt.Location = new System.Drawing.Point(4, 22);
            this.tpEquipCt.Name = "tpEquipCt";
            this.tpEquipCt.Size = new System.Drawing.Size(806, 256);
            this.tpEquipCt.TabIndex = 1;
            this.tpEquipCt.Text = "Equipment Info chi tiết";
            this.tpEquipCt.UseVisualStyleBackColor = true;
            // 
            // dgvEquipCt
            // 
            this.dgvEquipCt.AllowUserToAddRows = false;
            this.dgvEquipCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEquipCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEquipCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEquipCt.Location = new System.Drawing.Point(0, 0);
            this.dgvEquipCt.MultiSelect = false;
            this.dgvEquipCt.Name = "dgvEquipCt";
            this.dgvEquipCt.ReadOnly = true;
            this.dgvEquipCt.Size = new System.Drawing.Size(806, 256);
            this.dgvEquipCt.strZone = "";
            this.dgvEquipCt.TabIndex = 2;
            // 
            // frmEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 569);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tcEquipment);
            this.Name = "frmEquipment";
            this.Object_ID = "EQUIPMENT";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Tag = "frmEquipment";
            this.Text = "frmEquipment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tcEquipment.ResumeLayout(false);
            this.tpEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tpEquipmentInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentInfo)).EndInit();
            this.tpEquipCt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipCt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tcEquipment;
		private System.Windows.Forms.TabPage tpEquipment;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tpEquipmentInfo;
		private RosySystem.Control.rsDataGridView dgvEquipmentInfo;
		private RosySystem.Control.rsDataGridView dgvEquipment;
        private System.Windows.Forms.TabPage tpEquipCt;
        private RosySystem.Control.rsDataGridView dgvEquipCt;

	}
}