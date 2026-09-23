namespace RosyList
{
    partial class frmEquipmentCt_Edit
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
            this.txtHost_IP = new RosySystem.Control.rsIPAddress();
            this.lbMa_Kv = new RosySystem.Control.rsLabel();
            this.txtEquip_ID = new RosySystem.Control.rsTextBox();
            this.rsLabel8 = new RosySystem.Control.rsLabel();
            this.txtValue_Len = new RosySystem.Control.rsTextBox();
            this.rsLabel22 = new RosySystem.Control.rsLabel();
            this.txtETX = new RosySystem.Control.rsTextBox();
            this.rsLabel21 = new RosySystem.Control.rsLabel();
            this.txtSTX = new RosySystem.Control.rsTextBox();
            this.rsLabel20 = new RosySystem.Control.rsLabel();
            this.chkUsed = new RosySystem.Control.rsCheckbox();
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
            this.Page1.Controls.Add(this.chkUsed);
            this.Page1.Controls.Add(this.txtValue_Len);
            this.Page1.Controls.Add(this.rsLabel22);
            this.Page1.Controls.Add(this.txtETX);
            this.Page1.Controls.Add(this.rsLabel21);
            this.Page1.Controls.Add(this.txtSTX);
            this.Page1.Controls.Add(this.rsLabel20);
            this.Page1.Controls.Add(this.txtEquip_ID);
            this.Page1.Controls.Add(this.rsLabel8);
            this.Page1.Controls.Add(this.txtHost_IP);
            this.Page1.Controls.Add(this.lbMa_Kv);
            this.Page1.Size = new System.Drawing.Size(582, 133);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(582, 133);
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
            // txtHost_IP
            // 
            this.txtHost_IP.AllowInternalTab = false;
            this.txtHost_IP.AutoHeight = true;
            this.txtHost_IP.BackColor = System.Drawing.SystemColors.Window;
            this.txtHost_IP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHost_IP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHost_IP.Location = new System.Drawing.Point(102, 12);
            this.txtHost_IP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtHost_IP.MinimumSize = new System.Drawing.Size(87, 20);
            this.txtHost_IP.Name = "txtHost_IP";
            this.txtHost_IP.ReadOnly = false;
            this.txtHost_IP.Size = new System.Drawing.Size(87, 20);
            this.txtHost_IP.TabIndex = 0;
            this.txtHost_IP.Text = "...";
            // 
            // lbMa_Kv
            // 
            this.lbMa_Kv.AutoEllipsis = true;
            this.lbMa_Kv.AutoSize = true;
            this.lbMa_Kv.Location = new System.Drawing.Point(14, 12);
            this.lbMa_Kv.Name = "lbMa_Kv";
            this.lbMa_Kv.Size = new System.Drawing.Size(42, 13);
            this.lbMa_Kv.TabIndex = 20;
            this.lbMa_Kv.Tag = "";
            this.lbMa_Kv.Text = "Host IP";
            this.lbMa_Kv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEquip_ID
            // 
            this.txtEquip_ID.AutoDropDown = null;
            this.txtEquip_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEquip_ID.Location = new System.Drawing.Point(102, 34);
            this.txtEquip_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtEquip_ID.Name = "txtEquip_ID";
            this.txtEquip_ID.Size = new System.Drawing.Size(170, 20);
            this.txtEquip_ID.TabIndex = 1;
            // 
            // rsLabel8
            // 
            this.rsLabel8.AutoEllipsis = true;
            this.rsLabel8.AutoSize = true;
            this.rsLabel8.Location = new System.Drawing.Point(14, 37);
            this.rsLabel8.Name = "rsLabel8";
            this.rsLabel8.Size = new System.Drawing.Size(48, 13);
            this.rsLabel8.TabIndex = 46;
            this.rsLabel8.Tag = "";
            this.rsLabel8.Text = "Equip ID";
            this.rsLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValue_Len
            // 
            this.txtValue_Len.AutoDropDown = null;
            this.txtValue_Len.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValue_Len.Location = new System.Drawing.Point(374, 56);
            this.txtValue_Len.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtValue_Len.Name = "txtValue_Len";
            this.txtValue_Len.Size = new System.Drawing.Size(87, 20);
            this.txtValue_Len.TabIndex = 4;
            // 
            // rsLabel22
            // 
            this.rsLabel22.AutoEllipsis = true;
            this.rsLabel22.AutoSize = true;
            this.rsLabel22.Location = new System.Drawing.Point(317, 59);
            this.rsLabel22.Name = "rsLabel22";
            this.rsLabel22.Size = new System.Drawing.Size(55, 13);
            this.rsLabel22.TabIndex = 77;
            this.rsLabel22.Tag = "";
            this.rsLabel22.Text = "Value Len";
            this.rsLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtETX
            // 
            this.txtETX.AutoDropDown = null;
            this.txtETX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtETX.Location = new System.Drawing.Point(239, 56);
            this.txtETX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtETX.Name = "txtETX";
            this.txtETX.Size = new System.Drawing.Size(73, 20);
            this.txtETX.TabIndex = 3;
            // 
            // rsLabel21
            // 
            this.rsLabel21.AutoEllipsis = true;
            this.rsLabel21.AutoSize = true;
            this.rsLabel21.Location = new System.Drawing.Point(206, 59);
            this.rsLabel21.Name = "rsLabel21";
            this.rsLabel21.Size = new System.Drawing.Size(28, 13);
            this.rsLabel21.TabIndex = 76;
            this.rsLabel21.Tag = "";
            this.rsLabel21.Text = "ETX";
            this.rsLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSTX
            // 
            this.txtSTX.AutoDropDown = null;
            this.txtSTX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSTX.Location = new System.Drawing.Point(102, 56);
            this.txtSTX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSTX.Name = "txtSTX";
            this.txtSTX.Size = new System.Drawing.Size(87, 20);
            this.txtSTX.TabIndex = 2;
            // 
            // rsLabel20
            // 
            this.rsLabel20.AutoEllipsis = true;
            this.rsLabel20.AutoSize = true;
            this.rsLabel20.Location = new System.Drawing.Point(14, 63);
            this.rsLabel20.Name = "rsLabel20";
            this.rsLabel20.Size = new System.Drawing.Size(28, 13);
            this.rsLabel20.TabIndex = 75;
            this.rsLabel20.Tag = "";
            this.rsLabel20.Text = "STX";
            this.rsLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkUsed
            // 
            this.chkUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUsed.AutoSize = true;
            this.chkUsed.Checked = true;
            this.chkUsed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsed.ForeColor = System.Drawing.Color.Red;
            this.chkUsed.Location = new System.Drawing.Point(102, 92);
            this.chkUsed.Name = "chkUsed";
            this.chkUsed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUsed.Size = new System.Drawing.Size(87, 17);
            this.chkUsed.TabIndex = 78;
            this.chkUsed.TabStop = false;
            this.chkUsed.Text = "&Sử dụng cân";
            this.chkUsed.UseVisualStyleBackColor = true;
            // 
            // frmEquipmentCt_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 223);
            this.Name = "frmEquipmentCt_Edit";
            this.Object_ID = "EQUIPMENT";
            this.Tag = "frmEquipment, F2, F3, F8, ESC";
            this.Text = "frmEquipmentCt";
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

        private RosySystem.Control.rsIPAddress txtHost_IP;
		private RosySystem.Control.rsLabel lbMa_Kv;
        private RosySystem.Control.rsTextBox txtEquip_ID;
        private RosySystem.Control.rsLabel rsLabel8;
        private RosySystem.Control.rsTextBox txtValue_Len;
        private RosySystem.Control.rsLabel rsLabel22;
        private RosySystem.Control.rsTextBox txtETX;
        private RosySystem.Control.rsLabel rsLabel21;
        private RosySystem.Control.rsTextBox txtSTX;
        private RosySystem.Control.rsLabel rsLabel20;
        private RosySystem.Control.rsCheckbox chkUsed;

	}
}