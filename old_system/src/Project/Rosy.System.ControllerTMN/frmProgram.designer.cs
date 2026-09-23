namespace RosyControllerTMN
{
	partial class frmProgram
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvProgram = new RosySystem.Control.rsDataGridView();
			this.btUpload = new System.Windows.Forms.Button();
			this.txtPath_Name = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvProgram
			// 
			this.dgvProgram.AllowUserToAddRows = false;
			this.dgvProgram.AllowUserToDeleteRows = false;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvProgram.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvProgram.BackgroundColor = System.Drawing.Color.White;
			this.dgvProgram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvProgram.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dgvProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvProgram.DefaultCellStyle = dataGridViewCellStyle7;
			this.dgvProgram.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvProgram.Location = new System.Drawing.Point(8, 2);
			this.dgvProgram.MultiSelect = false;
			this.dgvProgram.Name = "dgvProgram";
			this.dgvProgram.ReadOnly = true;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvProgram.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.dgvProgram.Size = new System.Drawing.Size(633, 555);
			this.dgvProgram.strZone = "";
			this.dgvProgram.TabIndex = 0;
			// 
			// btUpload
			// 
			this.btUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btUpload.Location = new System.Drawing.Point(647, 12);
			this.btUpload.Name = "btUpload";
			this.btUpload.Size = new System.Drawing.Size(69, 49);
			this.btUpload.TabIndex = 1;
			this.btUpload.Text = "Upload";
			this.btUpload.UseVisualStyleBackColor = true;
			// 
			// txtPath_Name
			// 
			this.txtPath_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath_Name.Location = new System.Drawing.Point(647, 67);
			this.txtPath_Name.Name = "txtPath_Name";
			this.txtPath_Name.Size = new System.Drawing.Size(133, 20);
			this.txtPath_Name.TabIndex = 2;
			// 
			// frmProgram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 569);
			this.Controls.Add(this.txtPath_Name);
			this.Controls.Add(this.btUpload);
			this.Controls.Add(this.dgvProgram);
			this.Name = "frmProgram";
			this.Tag = "frmProgram, F2, F3, F8, ESC";
			this.Text = "frmProgram";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsDataGridView dgvProgram;
		private System.Windows.Forms.Button btUpload;
		private System.Windows.Forms.TextBox txtPath_Name;

		

	}
}