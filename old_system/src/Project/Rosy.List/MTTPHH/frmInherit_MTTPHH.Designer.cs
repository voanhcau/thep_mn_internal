namespace RosyList
{
    partial class frmInherit_MTTPHH
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
            this.tabControl1 = new RosySystem.Control.rsTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.txtPattern_Pos = new RosySystem.Control.rsTextBox();
            this.dgvInherit = new RosySystem.Control.rsDataGridView();
            this.numTT_Seq = new RosySystem.Control.rsTextBoxNumber();
            this.txtLoai_Phoi = new RosySystem.Control.rsTextBox();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel2 = new RosySystem.Control.rsLabel();
            this.txtCa_Sx = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.txtNo_Melt = new RosySystem.Control.rsTextBox();
            this.rsLabel6 = new RosySystem.Control.rsLabel();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.btRefresh = new RosySystem.Control.rsButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInherit)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 562);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rsLabel4);
            this.tabPage1.Controls.Add(this.txtPattern_Pos);
            this.tabPage1.Controls.Add(this.dgvInherit);
            this.tabPage1.Controls.Add(this.numTT_Seq);
            this.tabPage1.Controls.Add(this.txtLoai_Phoi);
            this.tabPage1.Controls.Add(this.rsLabel3);
            this.tabPage1.Controls.Add(this.rsLabel2);
            this.tabPage1.Controls.Add(this.txtCa_Sx);
            this.tabPage1.Controls.Add(this.rsLabel1);
            this.tabPage1.Controls.Add(this.txtNo_Melt);
            this.tabPage1.Controls.Add(this.rsLabel6);
            this.tabPage1.Controls.Add(this.btgAccept);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "Import";
            this.tabPage1.Text = "Kế thừa dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(178, 32);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(68, 13);
            this.rsLabel4.TabIndex = 25;
            this.rsLabel4.Text = "Vị trí lấy mẫu";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rsLabel4.Visible = false;
            // 
            // txtPattern_Pos
            // 
            this.txtPattern_Pos.AutoDropDown = null;
            this.txtPattern_Pos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPattern_Pos.Location = new System.Drawing.Point(251, 29);
            this.txtPattern_Pos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPattern_Pos.Name = "txtPattern_Pos";
            this.txtPattern_Pos.Size = new System.Drawing.Size(85, 20);
            this.txtPattern_Pos.TabIndex = 24;
            this.txtPattern_Pos.Visible = false;
            // 
            // dgvInherit
            // 
            this.dgvInherit.AllowUserToAddRows = false;
            this.dgvInherit.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInherit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInherit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInherit.BackgroundColor = System.Drawing.Color.White;
            this.dgvInherit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInherit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInherit.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInherit.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInherit.Location = new System.Drawing.Point(3, 68);
            this.dgvInherit.MultiSelect = false;
            this.dgvInherit.Name = "dgvInherit";
            this.dgvInherit.ReadOnly = true;
            this.dgvInherit.Size = new System.Drawing.Size(774, 332);
            this.dgvInherit.strZone = "";
            this.dgvInherit.TabIndex = 23;
            // 
            // numTT_Seq
            // 
            this.numTT_Seq.AutoDropDown = null;
            this.numTT_Seq.bFormat = true;
            this.numTT_Seq.Location = new System.Drawing.Point(84, 28);
            this.numTT_Seq.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numTT_Seq.Name = "numTT_Seq";
            this.numTT_Seq.Scale = 0;
            this.numTT_Seq.Size = new System.Drawing.Size(79, 20);
            this.numTT_Seq.TabIndex = 3;
            this.numTT_Seq.Tag = "";
            this.numTT_Seq.Text = "0";
            this.numTT_Seq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTT_Seq.Value = 0D;
            // 
            // txtLoai_Phoi
            // 
            this.txtLoai_Phoi.AutoDropDown = null;
            this.txtLoai_Phoi.Location = new System.Drawing.Point(381, 7);
            this.txtLoai_Phoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLoai_Phoi.Name = "txtLoai_Phoi";
            this.txtLoai_Phoi.Size = new System.Drawing.Size(85, 20);
            this.txtLoai_Phoi.TabIndex = 2;
            this.txtLoai_Phoi.Text = "150x150";
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(183, 10);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(20, 13);
            this.rsLabel3.TabIndex = 22;
            this.rsLabel3.Text = "Ca";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel2
            // 
            this.rsLabel2.AutoEllipsis = true;
            this.rsLabel2.AutoSize = true;
            this.rsLabel2.Location = new System.Drawing.Point(327, 10);
            this.rsLabel2.Name = "rsLabel2";
            this.rsLabel2.Size = new System.Drawing.Size(50, 13);
            this.rsLabel2.TabIndex = 22;
            this.rsLabel2.Text = "Loại phôi";
            this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCa_Sx
            // 
            this.txtCa_Sx.AutoDropDown = null;
            this.txtCa_Sx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCa_Sx.Location = new System.Drawing.Point(214, 7);
            this.txtCa_Sx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtCa_Sx.Name = "txtCa_Sx";
            this.txtCa_Sx.Size = new System.Drawing.Size(58, 20);
            this.txtCa_Sx.TabIndex = 1;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(29, 31);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(43, 13);
            this.rsLabel1.TabIndex = 22;
            this.rsLabel1.Text = "TT Seq";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNo_Melt
            // 
            this.txtNo_Melt.AutoDropDown = null;
            this.txtNo_Melt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNo_Melt.Location = new System.Drawing.Point(84, 7);
            this.txtNo_Melt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNo_Melt.Name = "txtNo_Melt";
            this.txtNo_Melt.Size = new System.Drawing.Size(79, 20);
            this.txtNo_Melt.TabIndex = 0;
            // 
            // rsLabel6
            // 
            this.rsLabel6.AutoEllipsis = true;
            this.rsLabel6.AutoSize = true;
            this.rsLabel6.Location = new System.Drawing.Point(12, 10);
            this.rsLabel6.Name = "rsLabel6";
            this.rsLabel6.Size = new System.Drawing.Size(50, 13);
            this.rsLabel6.TabIndex = 22;
            this.rsLabel6.Text = "Mẽ luyện";
            this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btgAccept.Location = new System.Drawing.Point(590, 488);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(182, 42);
            this.btgAccept.TabIndex = 5;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(653, 7);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(120, 38);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Tag = "Refresh";
            this.btRefresh.Text = "Refresh dữ liệu";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // frmInherit_MTTPHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmInherit_MTTPHH";
            this.Text = "frmInherit_MTTPHH";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInherit)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private RosySystem.Control.rsTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsButton btRefresh;
        private RosySystem.Control.rsTextBox txtNo_Melt;
        private RosySystem.Control.rsLabel rsLabel6;
        private RosySystem.Control.rsTextBox txtLoai_Phoi;
        private RosySystem.Control.rsLabel rsLabel2;
        private RosySystem.Control.rsTextBox txtCa_Sx;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsTextBoxNumber numTT_Seq;
        private RosySystem.Control.rsDataGridView dgvInherit;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsTextBox txtPattern_Pos;
        private RosySystem.Control.rsLabel rsLabel3;
	}
}