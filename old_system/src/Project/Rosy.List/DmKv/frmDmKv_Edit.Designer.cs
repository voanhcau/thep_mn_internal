namespace RosyList
{
	partial class frmDmKv_Edit
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
			this.txtTen_Kv = new RosySystem.Control.rsTextBox();
			this.txtMa_Kv = new RosySystem.Control.rsTextBox();
			this.lbTen_Kv = new RosySystem.Control.rsLabel();
			this.lbMa_Kv = new RosySystem.Control.rsLabel();
			this.txtMa_Kv_Parent = new RosySystem.Control.rsTextBox();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(343, 190);
			this.btgAccept.Size = new System.Drawing.Size(181, 44);
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(512, 178);
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.txtMa_Kv_Parent);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Controls.Add(this.txtTen_Kv);
			this.Page1.Controls.Add(this.txtMa_Kv);
			this.Page1.Controls.Add(this.lbTen_Kv);
			this.Page1.Controls.Add(this.lbMa_Kv);
			this.Page1.Size = new System.Drawing.Size(504, 152);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(504, 152);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 202);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 211);
			this.lblLog.Size = new System.Drawing.Size(289, 22);
			this.lblLog.Text = "";
			// 
			// txtTen_Kv
			// 
			this.txtTen_Kv.Location = new System.Drawing.Point(122, 50);
			this.txtTen_Kv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Kv.MaxLength = 100;
			this.txtTen_Kv.Name = "txtTen_Kv";
			this.txtTen_Kv.Size = new System.Drawing.Size(335, 20);
			this.txtTen_Kv.TabIndex = 2;
			// 
			// txtMa_Kv
			// 
			this.txtMa_Kv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Kv.Location = new System.Drawing.Point(122, 28);
			this.txtMa_Kv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Kv.MaxLength = 20;
			this.txtMa_Kv.Name = "txtMa_Kv";
			this.txtMa_Kv.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Kv.TabIndex = 1;
			// 
			// lbTen_Kv
			// 
			this.lbTen_Kv.AutoEllipsis = true;
			this.lbTen_Kv.AutoSize = true;
			this.lbTen_Kv.Location = new System.Drawing.Point(11, 51);
			this.lbTen_Kv.Name = "lbTen_Kv";
			this.lbTen_Kv.Size = new System.Drawing.Size(68, 13);
			this.lbTen_Kv.TabIndex = 19;
			this.lbTen_Kv.Tag = "Ten_Kv";
			this.lbTen_Kv.Text = "Tên khu vực";
			this.lbTen_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Kv
			// 
			this.lbMa_Kv.AutoEllipsis = true;
			this.lbMa_Kv.AutoSize = true;
			this.lbMa_Kv.Location = new System.Drawing.Point(11, 28);
			this.lbMa_Kv.Name = "lbMa_Kv";
			this.lbMa_Kv.Size = new System.Drawing.Size(64, 13);
			this.lbMa_Kv.TabIndex = 20;
			this.lbMa_Kv.Tag = "Ma_Kv";
			this.lbMa_Kv.Text = "Mã khu vực";
			this.lbMa_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMa_Kv_Parent
			// 
			this.txtMa_Kv_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Kv_Parent.Location = new System.Drawing.Point(122, 72);
			this.txtMa_Kv_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Kv_Parent.MaxLength = 20;
			this.txtMa_Kv_Parent.Name = "txtMa_Kv_Parent";
			this.txtMa_Kv_Parent.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Kv_Parent.TabIndex = 3;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(11, 72);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(86, 13);
			this.rsLabel1.TabIndex = 22;
			this.rsLabel1.Tag = "";
			this.rsLabel1.Text = "Mã khu vực Cha";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmKv_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(539, 242);
			this.Name = "frmDmKv_Edit";
			this.Object_ID = "DMKV";
			this.Tag = "frmDmKv, F2, F3, F8, ESC";
			this.Text = "frmDmKv";
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

		private RosySystem.Control.rsTextBox txtTen_Kv;
		private RosySystem.Control.rsTextBox txtMa_Kv;
		private RosySystem.Control.rsLabel lbTen_Kv;
		private RosySystem.Control.rsLabel lbMa_Kv;
		private RosySystem.Control.rsTextBox txtMa_Kv_Parent;
		private RosySystem.Control.rsLabel rsLabel1;

	}
}