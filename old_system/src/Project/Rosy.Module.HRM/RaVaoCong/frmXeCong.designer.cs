namespace RosyModule.HRM
{
    partial class frmXeCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXeCong));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSo_Xe_LXH = new RosySystem.Control.rsDataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSo_Xe_LayHang = new RosySystem.Control.rsDataGridView();
            this.rsDataGridView1 = new RosySystem.Control.rsDataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSo_Xe_LXH)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSo_Xe_LayHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1435, 839);
            this.splitContainer1.SplitterDistance = 734;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSo_Xe_LXH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(734, 839);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XE ĐÃ CÓ LỆNH CHƯA VÀO CỔNG";
            // 
            // dgvSo_Xe_LXH
            // 
            this.dgvSo_Xe_LXH.AllowUserToAddRows = false;
            this.dgvSo_Xe_LXH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSo_Xe_LXH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSo_Xe_LXH.BackgroundColor = System.Drawing.Color.White;
            this.dgvSo_Xe_LXH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSo_Xe_LXH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSo_Xe_LXH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSo_Xe_LXH.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvSo_Xe_LXH.Location = new System.Drawing.Point(4, 33);
            this.dgvSo_Xe_LXH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSo_Xe_LXH.MultiSelect = false;
            this.dgvSo_Xe_LXH.Name = "dgvSo_Xe_LXH";
            this.dgvSo_Xe_LXH.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.dgvSo_Xe_LXH.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSo_Xe_LXH.Size = new System.Drawing.Size(726, 801);
            this.dgvSo_Xe_LXH.strZone = "";
            this.dgvSo_Xe_LXH.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSo_Xe_LayHang);
            this.groupBox2.Controls.Add(this.rsDataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(695, 839);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XE ĐANG NHẬN HÀNG";
            // 
            // dgvSo_Xe_LayHang
            // 
            this.dgvSo_Xe_LayHang.AllowUserToAddRows = false;
            this.dgvSo_Xe_LayHang.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSo_Xe_LayHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSo_Xe_LayHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvSo_Xe_LayHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSo_Xe_LayHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSo_Xe_LayHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSo_Xe_LayHang.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvSo_Xe_LayHang.Location = new System.Drawing.Point(4, 33);
            this.dgvSo_Xe_LayHang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSo_Xe_LayHang.MultiSelect = false;
            this.dgvSo_Xe_LayHang.Name = "dgvSo_Xe_LayHang";
            this.dgvSo_Xe_LayHang.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.dgvSo_Xe_LayHang.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSo_Xe_LayHang.Size = new System.Drawing.Size(687, 801);
            this.dgvSo_Xe_LayHang.strZone = "";
            this.dgvSo_Xe_LayHang.TabIndex = 2;
            // 
            // rsDataGridView1
            // 
            this.rsDataGridView1.AllowUserToAddRows = false;
            this.rsDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rsDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.rsDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.rsDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rsDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rsDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsDataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.rsDataGridView1.Location = new System.Drawing.Point(4, 33);
            this.rsDataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rsDataGridView1.MultiSelect = false;
            this.rsDataGridView1.Name = "rsDataGridView1";
            this.rsDataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.rsDataGridView1.Size = new System.Drawing.Size(687, 801);
            this.rsDataGridView1.strZone = "";
            this.rsDataGridView1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            // 
            // frmXeCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 849);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmXeCong";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Text = "Xe vào cổng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSo_Xe_LXH)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSo_Xe_LayHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsDataGridView1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private RosySystem.Control.rsDataGridView dgvSo_Xe_LXH;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private RosySystem.Control.rsDataGridView dgvSo_Xe_LayHang;
        private RosySystem.Control.rsDataGridView rsDataGridView1;
	}
}

