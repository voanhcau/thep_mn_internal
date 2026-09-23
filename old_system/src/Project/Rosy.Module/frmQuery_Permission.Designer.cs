namespace RosyModule
{
    partial class frmQuery_Permission
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rsPanel2 = new RosySystem.Control.rsPanel();
            this.rsLabel5 = new RosySystem.Control.rsLabel();
            this.txtMa_Dt_CbNv = new RosySystem.Control.rsTextBox();
            this.lbtTen_Vt_Sp = new RosySystem.Control.rsLabelName();
            this.dgvViewCt = new RosySystem.Control.rsDataGridView();
            this.rsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewCt)).BeginInit();
            this.SuspendLayout();
            // 
            // rsPanel2
            // 
            this.rsPanel2.Controls.Add(this.rsLabel5);
            this.rsPanel2.Controls.Add(this.txtMa_Dt_CbNv);
            this.rsPanel2.Controls.Add(this.lbtTen_Vt_Sp);
            this.rsPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rsPanel2.Location = new System.Drawing.Point(3, 3);
            this.rsPanel2.Name = "rsPanel2";
            this.rsPanel2.Size = new System.Drawing.Size(992, 44);
            this.rsPanel2.TabIndex = 1;
            // 
            // rsLabel5
            // 
            this.rsLabel5.AutoEllipsis = true;
            this.rsLabel5.AutoSize = true;
            this.rsLabel5.Location = new System.Drawing.Point(15, 13);
            this.rsLabel5.Name = "rsLabel5";
            this.rsLabel5.Size = new System.Drawing.Size(72, 13);
            this.rsLabel5.TabIndex = 18;
            this.rsLabel5.Text = "Mã nhân viên";
            this.rsLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt_CbNv
            // 
            this.txtMa_Dt_CbNv.AutoDropDown = null;
            this.txtMa_Dt_CbNv.Location = new System.Drawing.Point(92, 9);
            this.txtMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_CbNv.Name = "txtMa_Dt_CbNv";
            this.txtMa_Dt_CbNv.Size = new System.Drawing.Size(89, 20);
            this.txtMa_Dt_CbNv.TabIndex = 7;
            // 
            // lbtTen_Vt_Sp
            // 
            this.lbtTen_Vt_Sp.AutoEllipsis = true;
            this.lbtTen_Vt_Sp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Sp.Location = new System.Drawing.Point(186, 10);
            this.lbtTen_Vt_Sp.Name = "lbtTen_Vt_Sp";
            this.lbtTen_Vt_Sp.Size = new System.Drawing.Size(161, 18);
            this.lbtTen_Vt_Sp.TabIndex = 17;
            this.lbtTen_Vt_Sp.Text = "Tên nhân viên";
            this.lbtTen_Vt_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvViewCt
            // 
            this.dgvViewCt.AllowUserToAddRows = false;
            this.dgvViewCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvViewCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvViewCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewCt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViewCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvViewCt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvViewCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvViewCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvViewCt.Location = new System.Drawing.Point(3, 47);
            this.dgvViewCt.MultiSelect = false;
            this.dgvViewCt.Name = "dgvViewCt";
            this.dgvViewCt.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewCt.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvViewCt.Size = new System.Drawing.Size(992, 512);
            this.dgvViewCt.strZone = "";
            this.dgvViewCt.TabIndex = 2;
            // 
            // frmQuery_Permission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 562);
            this.Controls.Add(this.dgvViewCt);
            this.Controls.Add(this.rsPanel2);
            this.Name = "frmQuery_Permission";
            this.Object_ID = "QUERYPERMISSION";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Tag = "";
            this.Text = "frmQuery_Permission";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.rsPanel2.ResumeLayout(false);
            this.rsPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewCt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Control.rsPanel rsPanel2;
        private RosySystem.Control.rsLabel rsLabel5;
        private RosySystem.Control.rsTextBox txtMa_Dt_CbNv;
        private RosySystem.Control.rsLabelName lbtTen_Vt_Sp;
        private RosySystem.Control.rsDataGridView dgvViewCt;

    }
}