namespace RosyList
{
	partial class frmEquipment_Edit
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
			this.txtHost_Name = new RosySystem.Control.rsTextBox();
			this.txtHost_IP = new RosySystem.Control.rsIPAddress();
			this.lbTen_Kv = new RosySystem.Control.rsLabel();
			this.lbMa_Kv = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(421, 171);
			this.btgAccept.Size = new System.Drawing.Size(181, 44);
			this.btgAccept.TabIndex = 1;
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(590, 159);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.txtHost_Name);
			this.Page1.Controls.Add(this.txtHost_IP);
			this.Page1.Controls.Add(this.lbTen_Kv);
			this.Page1.Controls.Add(this.lbMa_Kv);
			this.Page1.Size = new System.Drawing.Size(582, 133);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(582, 119);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 183);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 192);
			this.lblLog.Text = "";
			// 
			// txtHost_Name
			// 
			this.txtHost_Name.BackColor = System.Drawing.SystemColors.Window;
			this.txtHost_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtHost_Name.Location = new System.Drawing.Point(122, 67);
			this.txtHost_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtHost_Name.MinimumSize = new System.Drawing.Size(87, 20);
			this.txtHost_Name.Name = "txtHost_Name";
			this.txtHost_Name.Size = new System.Drawing.Size(335, 20);
			this.txtHost_Name.TabIndex = 1;
			// 
			// txtHost_IP
			// 
			this.txtHost_IP.AllowInternalTab = false;
			this.txtHost_IP.AutoHeight = true;
			this.txtHost_IP.BackColor = System.Drawing.SystemColors.Window;
			this.txtHost_IP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtHost_IP.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtHost_IP.Location = new System.Drawing.Point(122, 45);
			this.txtHost_IP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtHost_IP.MinimumSize = new System.Drawing.Size(87, 20);
			this.txtHost_IP.Name = "txtHost_IP";
			this.txtHost_IP.ReadOnly = false;
			this.txtHost_IP.Size = new System.Drawing.Size(87, 20);
			this.txtHost_IP.TabIndex = 0;
			this.txtHost_IP.Text = "...";
			// 
			// lbTen_Kv
			// 
			this.lbTen_Kv.AutoEllipsis = true;
			this.lbTen_Kv.AutoSize = true;
			this.lbTen_Kv.Location = new System.Drawing.Point(32, 68);
			this.lbTen_Kv.Name = "lbTen_Kv";
			this.lbTen_Kv.Size = new System.Drawing.Size(58, 13);
			this.lbTen_Kv.TabIndex = 19;
			this.lbTen_Kv.Tag = "Host_Name";
			this.lbTen_Kv.Text = "Host name";
			this.lbTen_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Kv
			// 
			this.lbMa_Kv.AutoEllipsis = true;
			this.lbMa_Kv.AutoSize = true;
			this.lbMa_Kv.Location = new System.Drawing.Point(32, 45);
			this.lbMa_Kv.Name = "lbMa_Kv";
			this.lbMa_Kv.Size = new System.Drawing.Size(42, 13);
			this.lbMa_Kv.TabIndex = 20;
			this.lbMa_Kv.Tag = "";
			this.lbMa_Kv.Text = "Host IP";
			this.lbMa_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmEquipment_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 223);
			this.Name = "frmEquipment_Edit";
			this.Object_ID = "EQUIPMENT";
			this.Tag = "frmEquipment, F2, F3, F8, ESC";
			this.Text = "frmEquipment";
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

		private RosySystem.Control.rsTextBox txtHost_Name;
		private RosySystem.Control.rsIPAddress txtHost_IP;
		private RosySystem.Control.rsLabel lbTen_Kv;
		private RosySystem.Control.rsLabel lbMa_Kv;

	}
}