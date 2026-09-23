namespace RosyList
{
	partial class frmDmType_Edit
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
			this.txtType_Name = new RosySystem.Control.rsTextBox();
			this.txtType_ID = new RosySystem.Control.rsTextBox();
			this.lbTen_Kho = new RosySystem.Control.rsLabel();
			this.lbMa_Kho = new RosySystem.Control.rsLabel();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.txtType = new RosySystem.Control.rsTextBox();
			this.numType_Value = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(377, 193);
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			this.btgAccept.TabIndex = 1;
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(547, 181);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.numType_Value);
			this.Page1.Controls.Add(this.txtType_Name);
			this.Page1.Controls.Add(this.txtType);
			this.Page1.Controls.Add(this.txtType_ID);
			this.Page1.Controls.Add(this.rsLabel2);
			this.Page1.Controls.Add(this.lbTen_Kho);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Controls.Add(this.lbMa_Kho);
			this.Page1.Size = new System.Drawing.Size(539, 155);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(539, 155);
			// 
			// lblLog
			// 
			this.lblLog.Text = "";
			// 
			// txtType_Name
			// 
			this.txtType_Name.AutoDropDown = null;
			this.txtType_Name.Location = new System.Drawing.Point(115, 76);
			this.txtType_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtType_Name.MaxLength = 100;
			this.txtType_Name.Name = "txtType_Name";
			this.txtType_Name.Size = new System.Drawing.Size(335, 20);
			this.txtType_Name.TabIndex = 2;
			// 
			// txtType_ID
			// 
			this.txtType_ID.AutoDropDown = null;
			this.txtType_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtType_ID.Location = new System.Drawing.Point(115, 54);
			this.txtType_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtType_ID.MaxLength = 20;
			this.txtType_ID.Name = "txtType_ID";
			this.txtType_ID.Size = new System.Drawing.Size(120, 20);
			this.txtType_ID.TabIndex = 1;
			// 
			// lbTen_Kho
			// 
			this.lbTen_Kho.AutoEllipsis = true;
			this.lbTen_Kho.AutoSize = true;
			this.lbTen_Kho.Location = new System.Drawing.Point(27, 77);
			this.lbTen_Kho.Name = "lbTen_Kho";
			this.lbTen_Kho.Size = new System.Drawing.Size(45, 13);
			this.lbTen_Kho.TabIndex = 19;
			this.lbTen_Kho.Tag = "Type_Name";
			this.lbTen_Kho.Text = "Tên loại";
			this.lbTen_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Kho
			// 
			this.lbMa_Kho.AutoEllipsis = true;
			this.lbMa_Kho.AutoSize = true;
			this.lbMa_Kho.Location = new System.Drawing.Point(27, 54);
			this.lbMa_Kho.Name = "lbMa_Kho";
			this.lbMa_Kho.Size = new System.Drawing.Size(41, 13);
			this.lbMa_Kho.TabIndex = 20;
			this.lbMa_Kho.Tag = "Type_ID";
			this.lbMa_Kho.Text = "Mã loại";
			this.lbMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(27, 32);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(68, 13);
			this.rsLabel1.TabIndex = 20;
			this.rsLabel1.Tag = "TYPE";
			this.rsLabel1.Text = "Mã phân loại";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtType
			// 
			this.txtType.AutoDropDown = null;
			this.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtType.Location = new System.Drawing.Point(115, 32);
			this.txtType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtType.MaxLength = 20;
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(120, 20);
			this.txtType.TabIndex = 0;
			// 
			// numType_Value
			// 
			this.numType_Value.AutoDropDown = null;
			this.numType_Value.bFormat = true;
			this.numType_Value.Location = new System.Drawing.Point(115, 98);
			this.numType_Value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numType_Value.Name = "numType_Value";
			this.numType_Value.Scale = 2;
			this.numType_Value.Size = new System.Drawing.Size(120, 20);
			this.numType_Value.TabIndex = 21;
			this.numType_Value.Text = "0";
			this.numType_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numType_Value.Value = 0D;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(27, 101);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(34, 13);
			this.rsLabel2.TabIndex = 19;
			this.rsLabel2.Tag = "Type_Value";
			this.rsLabel2.Text = "Giá trị";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmType_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(571, 242);
			this.Name = "frmDmType_Edit";
			this.Object_ID = "DMTYPE";
			this.Tag = "frmDmType, ESC";
			this.Text = "frmDmType";
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

		private RosySystem.Control.rsTextBox txtType_Name;
		private RosySystem.Control.rsTextBox txtType_ID;
		private RosySystem.Control.rsLabel lbTen_Kho;
		private RosySystem.Control.rsLabel lbMa_Kho;
		private RosySystem.Control.rsLabel rsLabel1;
		public RosySystem.Control.rsTextBox txtType;
		private RosySystem.Control.rsTextBoxNumber numType_Value;
		private RosySystem.Control.rsLabel rsLabel2;

	}
}