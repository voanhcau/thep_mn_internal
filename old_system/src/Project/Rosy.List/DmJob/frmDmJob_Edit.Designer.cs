namespace RosyList
{
	partial class frmDmJob_Edit
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
            this.txtTen_Job = new RosySystem.Control.rsTextBox();
            this.txtMa_Job = new RosySystem.Control.rsTextBox();
            this.lbTen_Job = new RosySystem.Control.rsLabel();
            this.lbMa_Job = new RosySystem.Control.rsLabel();
            this.chkNh_Cuoi = new RosySystem.Control.rsCheckbox();
            this.txtMa_Job_Parent = new RosySystem.Control.rsTextBox();
            this.lbtTen_Job_Cha = new RosySystem.Control.rsLabel();
            this.lblMa_Bp_Parent = new RosySystem.Control.rsLabel();
            this.txtMa_Xe = new RosySystem.Control.rsTextBox();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.lbtTen_Xe = new RosySystem.Control.rsLabel();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(375, 203);
            this.btgAccept.Size = new System.Drawing.Size(181, 42);
            // 
            // tabEdit
            // 
            this.tabEdit.Location = new System.Drawing.Point(12, 12);
            this.tabEdit.Size = new System.Drawing.Size(547, 185);
            this.tabEdit.TabIndex = 0;
            this.tabEdit.Tag = "Detail";
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtMa_Xe);
            this.Page1.Controls.Add(this.rsLabel1);
            this.Page1.Controls.Add(this.chkNh_Cuoi);
            this.Page1.Controls.Add(this.txtMa_Job_Parent);
            this.Page1.Controls.Add(this.lbtTen_Xe);
            this.Page1.Controls.Add(this.lbtTen_Job_Cha);
            this.Page1.Controls.Add(this.lblMa_Bp_Parent);
            this.Page1.Controls.Add(this.txtTen_Job);
            this.Page1.Controls.Add(this.txtMa_Job);
            this.Page1.Controls.Add(this.lbTen_Job);
            this.Page1.Controls.Add(this.lbMa_Job);
            this.Page1.Size = new System.Drawing.Size(539, 159);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(539, 159);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 214);
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(48, 223);
            this.lblLog.Text = "";
            // 
            // txtTen_Job
            // 
            this.txtTen_Job.AutoDropDown = null;
            this.txtTen_Job.Location = new System.Drawing.Point(126, 42);
            this.txtTen_Job.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Job.MaxLength = 100;
            this.txtTen_Job.Name = "txtTen_Job";
            this.txtTen_Job.Size = new System.Drawing.Size(335, 20);
            this.txtTen_Job.TabIndex = 1;
            // 
            // txtMa_Job
            // 
            this.txtMa_Job.AutoDropDown = null;
            this.txtMa_Job.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Job.Location = new System.Drawing.Point(126, 20);
            this.txtMa_Job.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Job.MaxLength = 20;
            this.txtMa_Job.Name = "txtMa_Job";
            this.txtMa_Job.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Job.TabIndex = 0;
            // 
            // lbTen_Job
            // 
            this.lbTen_Job.AutoEllipsis = true;
            this.lbTen_Job.AutoSize = true;
            this.lbTen_Job.Location = new System.Drawing.Point(15, 43);
            this.lbTen_Job.Name = "lbTen_Job";
            this.lbTen_Job.Size = new System.Drawing.Size(76, 13);
            this.lbTen_Job.TabIndex = 19;
            this.lbTen_Job.Tag = "Ten_Job";
            this.lbTen_Job.Text = "Tên công việc";
            this.lbTen_Job.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Job
            // 
            this.lbMa_Job.AutoEllipsis = true;
            this.lbMa_Job.AutoSize = true;
            this.lbMa_Job.Location = new System.Drawing.Point(15, 20);
            this.lbMa_Job.Name = "lbMa_Job";
            this.lbMa_Job.Size = new System.Drawing.Size(72, 13);
            this.lbMa_Job.TabIndex = 20;
            this.lbMa_Job.Tag = "Ma_Job";
            this.lbMa_Job.Text = "Mã công việc";
            this.lbMa_Job.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNh_Cuoi
            // 
            this.chkNh_Cuoi.AutoSize = true;
            this.chkNh_Cuoi.ForeColor = System.Drawing.Color.Red;
            this.chkNh_Cuoi.Location = new System.Drawing.Point(126, 117);
            this.chkNh_Cuoi.Name = "chkNh_Cuoi";
            this.chkNh_Cuoi.Size = new System.Drawing.Size(237, 17);
            this.chkNh_Cuoi.TabIndex = 4;
            this.chkNh_Cuoi.Text = "Là nhóm cuối (Là bộ phận chi tiết cuối cùng)";
            this.chkNh_Cuoi.UseVisualStyleBackColor = true;
            // 
            // txtMa_Job_Parent
            // 
            this.txtMa_Job_Parent.AutoDropDown = null;
            this.txtMa_Job_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Job_Parent.Location = new System.Drawing.Point(126, 64);
            this.txtMa_Job_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Job_Parent.Name = "txtMa_Job_Parent";
            this.txtMa_Job_Parent.Size = new System.Drawing.Size(137, 20);
            this.txtMa_Job_Parent.TabIndex = 2;
            // 
            // lbtTen_Job_Cha
            // 
            this.lbtTen_Job_Cha.AutoEllipsis = true;
            this.lbtTen_Job_Cha.AutoSize = true;
            this.lbtTen_Job_Cha.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Job_Cha.Location = new System.Drawing.Point(277, 65);
            this.lbtTen_Job_Cha.Name = "lbtTen_Job_Cha";
            this.lbtTen_Job_Cha.Size = new System.Drawing.Size(93, 13);
            this.lbtTen_Job_Cha.TabIndex = 65;
            this.lbtTen_Job_Cha.Text = "Tên công việc mẹ";
            this.lbtTen_Job_Cha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Bp_Parent
            // 
            this.lblMa_Bp_Parent.AutoEllipsis = true;
            this.lblMa_Bp_Parent.AutoSize = true;
            this.lblMa_Bp_Parent.Location = new System.Drawing.Point(15, 65);
            this.lblMa_Bp_Parent.Name = "lblMa_Bp_Parent";
            this.lblMa_Bp_Parent.Size = new System.Drawing.Size(76, 13);
            this.lblMa_Bp_Parent.TabIndex = 64;
            this.lblMa_Bp_Parent.Tag = "Ma_Job_Parent";
            this.lblMa_Bp_Parent.Text = "Công việc cha";
            this.lblMa_Bp_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMa_Bp_Parent.Click += new System.EventHandler(this.lblMa_Bp_Parent_Click);
            // 
            // txtMa_Xe
            // 
            this.txtMa_Xe.AutoDropDown = null;
            this.txtMa_Xe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Xe.Location = new System.Drawing.Point(126, 86);
            this.txtMa_Xe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Xe.Name = "txtMa_Xe";
            this.txtMa_Xe.Size = new System.Drawing.Size(137, 20);
            this.txtMa_Xe.TabIndex = 3;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(15, 87);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(36, 13);
            this.rsLabel1.TabIndex = 67;
            this.rsLabel1.Tag = "Ma_Xe";
            this.rsLabel1.Text = "Mã xe";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Xe
            // 
            this.lbtTen_Xe.AutoEllipsis = true;
            this.lbtTen_Xe.AutoSize = true;
            this.lbtTen_Xe.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Xe.Location = new System.Drawing.Point(277, 89);
            this.lbtTen_Xe.Name = "lbtTen_Xe";
            this.lbtTen_Xe.Size = new System.Drawing.Size(40, 13);
            this.lbtTen_Xe.TabIndex = 65;
            this.lbtTen_Xe.Text = "Tên xe";
            this.lbtTen_Xe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDmJob_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 253);
            this.Name = "frmDmJob_Edit";
            this.Object_ID = "DMJOB";
            this.Tag = "frmDmJob, ESC";
            this.Text = "frmDmJob";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RosySystem.Control.rsTextBox txtTen_Job;
		private RosySystem.Control.rsTextBox txtMa_Job;
		private RosySystem.Control.rsLabel lbTen_Job;
		private RosySystem.Control.rsLabel lbMa_Job;
		private RosySystem.Control.rsCheckbox chkNh_Cuoi;
		private RosySystem.Control.rsTextBox txtMa_Job_Parent;
		private RosySystem.Control.rsLabel lbtTen_Job_Cha;
		private RosySystem.Control.rsLabel lblMa_Bp_Parent;
        private RosySystem.Control.rsTextBox txtMa_Xe;
        private RosySystem.Control.rsLabel rsLabel1;
        private RosySystem.Control.rsLabel lbtTen_Xe;
    }
}