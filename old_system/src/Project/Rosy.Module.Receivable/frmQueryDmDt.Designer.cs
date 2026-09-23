namespace RosyModule.Receivable
{
	partial class frmQueryDmDt
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btExit = new RosySystem.Control.rsButton();
			this.cboMa_Nh_Dt = new RosySystem.Control.rsMultiComboBox();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.cboMa_Kv = new RosySystem.Control.rsMultiComboBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.cboMa_Dt_CbNv = new RosySystem.Control.rsMultiComboBox();
			this.label1 = new RosySystem.Control.rsLabel();
			this.dgvDmDt = new RosySystem.Control.rsDataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDmDt)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btExit);
			this.groupBox1.Controls.Add(this.cboMa_Nh_Dt);
			this.groupBox1.Controls.Add(this.rsLabel2);
			this.groupBox1.Controls.Add(this.cboMa_Kv);
			this.groupBox1.Controls.Add(this.rsLabel1);
			this.groupBox1.Controls.Add(this.cboMa_Dt_CbNv);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(9, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(774, 104);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Truy vấn danh mục đối tượng";
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.Location = new System.Drawing.Point(671, 19);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(97, 23);
			this.btExit.TabIndex = 3;
			this.btExit.Tag = "Exit";
			this.btExit.Text = "Quay ra";
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// cboMa_Nh_Dt
			// 
			this.cboMa_Nh_Dt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboMa_Nh_Dt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cboMa_Nh_Dt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cboMa_Nh_Dt.FormattingEnabled = true;
			this.cboMa_Nh_Dt.Location = new System.Drawing.Point(137, 76);
			this.cboMa_Nh_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_Nh_Dt.Name = "cboMa_Nh_Dt";
			this.cboMa_Nh_Dt.Size = new System.Drawing.Size(125, 21);
			this.cboMa_Nh_Dt.TabIndex = 2;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(28, 79);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(51, 13);
			this.rsLabel2.TabIndex = 1;
			this.rsLabel2.Tag = "Ma_Nhom";
			this.rsLabel2.Text = "Mã nhóm";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboMa_Kv
			// 
			this.cboMa_Kv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboMa_Kv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cboMa_Kv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cboMa_Kv.FormattingEnabled = true;
			this.cboMa_Kv.Location = new System.Drawing.Point(137, 53);
			this.cboMa_Kv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_Kv.Name = "cboMa_Kv";
			this.cboMa_Kv.Size = new System.Drawing.Size(125, 21);
			this.cboMa_Kv.TabIndex = 1;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(28, 56);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(47, 13);
			this.rsLabel1.TabIndex = 1;
			this.rsLabel1.Tag = "Ma_Kv";
			this.rsLabel1.Text = "Khu vực";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboMa_Dt_CbNv
			// 
			this.cboMa_Dt_CbNv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboMa_Dt_CbNv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cboMa_Dt_CbNv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cboMa_Dt_CbNv.FormattingEnabled = true;
			this.cboMa_Dt_CbNv.Location = new System.Drawing.Point(137, 30);
			this.cboMa_Dt_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboMa_Dt_CbNv.Name = "cboMa_Dt_CbNv";
			this.cboMa_Dt_CbNv.Size = new System.Drawing.Size(125, 21);
			this.cboMa_Dt_CbNv.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoEllipsis = true;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 1;
			this.label1.Tag = "Ma_Dt_CbNv";
			this.label1.Text = "Nhân viên phụ trách";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgvDmDt
			// 
			this.dgvDmDt.AllowUserToAddRows = false;
			this.dgvDmDt.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvDmDt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDmDt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDmDt.BackgroundColor = System.Drawing.Color.White;
			this.dgvDmDt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvDmDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDmDt.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvDmDt.Location = new System.Drawing.Point(9, 118);
			this.dgvDmDt.Margin = new System.Windows.Forms.Padding(0);
			this.dgvDmDt.MultiSelect = false;
			this.dgvDmDt.Name = "dgvDmDt";
			this.dgvDmDt.ReadOnly = true;
			this.dgvDmDt.Size = new System.Drawing.Size(774, 438);
			this.dgvDmDt.strZone = "";
			this.dgvDmDt.TabIndex = 1;
			// 
			// frmQueryDmDt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btExit;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dgvDmDt);
			this.Name = "frmQueryDmDt";
			this.Text = "frmQueryDmDt";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDmDt)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvDmDt;
		private System.Windows.Forms.GroupBox groupBox1;
		private RosySystem.Control.rsLabel label1;
		private RosySystem.Control.rsMultiComboBox cboMa_Dt_CbNv;
		private RosySystem.Control.rsMultiComboBox cboMa_Nh_Dt;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsMultiComboBox cboMa_Kv;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsButton btExit;
	}
}