namespace RosyList
{
	partial class frmDmLots_Edit
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
			this.txtLot_Name = new RosySystem.Control.rsTextBox();
			this.txtLot_ID = new RosySystem.Control.rsTextBox();
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
			this.btgAccept.Location = new System.Drawing.Point(395, 190);
			this.btgAccept.Size = new System.Drawing.Size(181, 44);
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(564, 178);
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.txtLot_Name);
			this.Page1.Controls.Add(this.txtLot_ID);
			this.Page1.Controls.Add(this.lbTen_Kv);
			this.Page1.Controls.Add(this.lbMa_Kv);
			this.Page1.Size = new System.Drawing.Size(556, 152);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(556, 152);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 202);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 211);
			this.lblLog.Text = "";
			// 
			// txtLot_Name
			// 
			this.txtLot_Name.Location = new System.Drawing.Point(106, 77);
			this.txtLot_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtLot_Name.MaxLength = 100;
			this.txtLot_Name.Name = "txtLot_Name";
			this.txtLot_Name.Size = new System.Drawing.Size(335, 20);
			this.txtLot_Name.TabIndex = 18;
			// 
			// txtLot_ID
			// 
			this.txtLot_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLot_ID.Location = new System.Drawing.Point(106, 55);
			this.txtLot_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtLot_ID.MaxLength = 20;
			this.txtLot_ID.Name = "txtLot_ID";
			this.txtLot_ID.Size = new System.Drawing.Size(120, 20);
			this.txtLot_ID.TabIndex = 17;
			// 
			// lbTen_Kv
			// 
			this.lbTen_Kv.AutoEllipsis = true;
			this.lbTen_Kv.AutoSize = true;
			this.lbTen_Kv.Location = new System.Drawing.Point(64, 78);
			this.lbTen_Kv.Name = "lbTen_Kv";
			this.lbTen_Kv.Size = new System.Drawing.Size(37, 13);
			this.lbTen_Kv.TabIndex = 19;
			this.lbTen_Kv.Tag = "";
			this.lbTen_Kv.Text = "Tên lô";
			this.lbTen_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Kv
			// 
			this.lbMa_Kv.AutoEllipsis = true;
			this.lbMa_Kv.AutoSize = true;
			this.lbMa_Kv.Location = new System.Drawing.Point(64, 55);
			this.lbMa_Kv.Name = "lbMa_Kv";
			this.lbMa_Kv.Size = new System.Drawing.Size(33, 13);
			this.lbMa_Kv.TabIndex = 20;
			this.lbMa_Kv.Tag = "";
			this.lbMa_Kv.Text = "Mã lô";
			this.lbMa_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmLots_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 242);
			this.Name = "frmDmLots_Edit";
			this.Object_ID = "DMLOTS";
			this.Tag = "frmDmLots, F2, F3, F8, ESC";
			this.Text = "frmDmLots";
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

		private RosySystem.Control.rsTextBox txtLot_Name;
		private RosySystem.Control.rsTextBox txtLot_ID;
		private RosySystem.Control.rsLabel lbTen_Kv;
		private RosySystem.Control.rsLabel lbMa_Kv;

	}
}