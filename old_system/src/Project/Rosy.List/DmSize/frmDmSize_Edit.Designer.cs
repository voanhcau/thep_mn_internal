namespace RosyList
{
	partial class frmDmSize_Edit
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
			this.numMaxWeight = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel6 = new RosySystem.Control.rsLabel();
			this.numMinWeight = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel7 = new RosySystem.Control.rsLabel();
			this.numDMax = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel2 = new RosySystem.Control.rsLabel();
			this.numDMin = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel3 = new RosySystem.Control.rsLabel();
			this.numDiameter = new RosySystem.Control.rsTextBoxNumber();
			this.rsLabel1 = new RosySystem.Control.rsLabel();
			this.numLength = new RosySystem.Control.rsTextBoxNumber();
			this.lblSl_Ton_Min = new RosySystem.Control.rsLabel();
			this.txtTen_Size = new RosySystem.Control.rsTextBox();
			this.txtMa_Size = new RosySystem.Control.rsTextBox();
			this.lbTen_Sp = new RosySystem.Control.rsLabel();
			this.lbMa_Sp = new RosySystem.Control.rsLabel();
			this.tabEdit.SuspendLayout();
			this.Page1.SuspendLayout();
			this.Page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btgAccept
			// 
			this.btgAccept.Location = new System.Drawing.Point(395, 228);
			this.btgAccept.Size = new System.Drawing.Size(181, 42);
			this.btgAccept.TabIndex = 2;
			// 
			// tabEdit
			// 
			this.tabEdit.Size = new System.Drawing.Size(564, 216);
			this.tabEdit.TabIndex = 0;
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.numMaxWeight);
			this.Page1.Controls.Add(this.rsLabel6);
			this.Page1.Controls.Add(this.numMinWeight);
			this.Page1.Controls.Add(this.rsLabel7);
			this.Page1.Controls.Add(this.numDMax);
			this.Page1.Controls.Add(this.rsLabel2);
			this.Page1.Controls.Add(this.numDMin);
			this.Page1.Controls.Add(this.rsLabel3);
			this.Page1.Controls.Add(this.numDiameter);
			this.Page1.Controls.Add(this.rsLabel1);
			this.Page1.Controls.Add(this.numLength);
			this.Page1.Controls.Add(this.lblSl_Ton_Min);
			this.Page1.Controls.Add(this.txtTen_Size);
			this.Page1.Controls.Add(this.txtMa_Size);
			this.Page1.Controls.Add(this.lbTen_Sp);
			this.Page1.Controls.Add(this.lbMa_Sp);
			this.Page1.Size = new System.Drawing.Size(556, 190);
			// 
			// Page2
			// 
			this.Page2.Size = new System.Drawing.Size(556, 204);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 237);
			// 
			// lblLog
			// 
			this.lblLog.Location = new System.Drawing.Point(48, 246);
			this.lblLog.Text = "";
			// 
			// numMaxWeight
			// 
			this.numMaxWeight.AutoDropDown = null;
			this.numMaxWeight.bFormat = true;
			this.numMaxWeight.Location = new System.Drawing.Point(313, 129);
			this.numMaxWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numMaxWeight.Name = "numMaxWeight";
			this.numMaxWeight.Scale = 0;
			this.numMaxWeight.Size = new System.Drawing.Size(65, 20);
			this.numMaxWeight.TabIndex = 7;
			this.numMaxWeight.Text = "0";
			this.numMaxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMaxWeight.Value = 0D;
			// 
			// rsLabel6
			// 
			this.rsLabel6.AutoEllipsis = true;
			this.rsLabel6.AutoSize = true;
			this.rsLabel6.Location = new System.Drawing.Point(221, 132);
			this.rsLabel6.Name = "rsLabel6";
			this.rsLabel6.Size = new System.Drawing.Size(88, 13);
			this.rsLabel6.TabIndex = 145;
			this.rsLabel6.Tag = "MaxWeight";
			this.rsLabel6.Text = "Maximum Weight";
			this.rsLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numMinWeight
			// 
			this.numMinWeight.AutoDropDown = null;
			this.numMinWeight.bFormat = true;
			this.numMinWeight.Location = new System.Drawing.Point(134, 129);
			this.numMinWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numMinWeight.Name = "numMinWeight";
			this.numMinWeight.Scale = 0;
			this.numMinWeight.Size = new System.Drawing.Size(65, 20);
			this.numMinWeight.TabIndex = 6;
			this.numMinWeight.Text = "0";
			this.numMinWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMinWeight.Value = 0D;
			// 
			// rsLabel7
			// 
			this.rsLabel7.AutoEllipsis = true;
			this.rsLabel7.AutoSize = true;
			this.rsLabel7.Location = new System.Drawing.Point(47, 132);
			this.rsLabel7.Name = "rsLabel7";
			this.rsLabel7.Size = new System.Drawing.Size(85, 13);
			this.rsLabel7.TabIndex = 144;
			this.rsLabel7.Tag = "MinWeight";
			this.rsLabel7.Text = "Minimum Weight";
			this.rsLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numDMax
			// 
			this.numDMax.AutoDropDown = null;
			this.numDMax.bFormat = true;
			this.numDMax.Location = new System.Drawing.Point(313, 107);
			this.numDMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numDMax.Name = "numDMax";
			this.numDMax.Scale = 0;
			this.numDMax.Size = new System.Drawing.Size(65, 20);
			this.numDMax.TabIndex = 5;
			this.numDMax.Text = "0";
			this.numDMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numDMax.Value = 0D;
			// 
			// rsLabel2
			// 
			this.rsLabel2.AutoEllipsis = true;
			this.rsLabel2.AutoSize = true;
			this.rsLabel2.Location = new System.Drawing.Point(221, 110);
			this.rsLabel2.Name = "rsLabel2";
			this.rsLabel2.Size = new System.Drawing.Size(35, 13);
			this.rsLabel2.TabIndex = 142;
			this.rsLabel2.Tag = "DMax";
			this.rsLabel2.Text = "DMax";
			this.rsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numDMin
			// 
			this.numDMin.AutoDropDown = null;
			this.numDMin.bFormat = true;
			this.numDMin.Location = new System.Drawing.Point(134, 107);
			this.numDMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numDMin.Name = "numDMin";
			this.numDMin.Scale = 0;
			this.numDMin.Size = new System.Drawing.Size(65, 20);
			this.numDMin.TabIndex = 4;
			this.numDMin.Text = "0";
			this.numDMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numDMin.Value = 0D;
			// 
			// rsLabel3
			// 
			this.rsLabel3.AutoEllipsis = true;
			this.rsLabel3.AutoSize = true;
			this.rsLabel3.Location = new System.Drawing.Point(47, 108);
			this.rsLabel3.Name = "rsLabel3";
			this.rsLabel3.Size = new System.Drawing.Size(32, 13);
			this.rsLabel3.TabIndex = 141;
			this.rsLabel3.Tag = "DMin";
			this.rsLabel3.Text = "DMin";
			this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numDiameter
			// 
			this.numDiameter.AutoDropDown = null;
			this.numDiameter.bFormat = true;
			this.numDiameter.Location = new System.Drawing.Point(313, 85);
			this.numDiameter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numDiameter.Name = "numDiameter";
			this.numDiameter.Scale = 0;
			this.numDiameter.Size = new System.Drawing.Size(65, 20);
			this.numDiameter.TabIndex = 3;
			this.numDiameter.Text = "0";
			this.numDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numDiameter.Value = 0D;
			// 
			// rsLabel1
			// 
			this.rsLabel1.AutoEllipsis = true;
			this.rsLabel1.AutoSize = true;
			this.rsLabel1.Location = new System.Drawing.Point(221, 88);
			this.rsLabel1.Name = "rsLabel1";
			this.rsLabel1.Size = new System.Drawing.Size(58, 13);
			this.rsLabel1.TabIndex = 140;
			this.rsLabel1.Tag = "Diameter";
			this.rsLabel1.Text = "Chiều rộng";
			this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numLength
			// 
			this.numLength.AutoDropDown = null;
			this.numLength.bFormat = true;
			this.numLength.Location = new System.Drawing.Point(134, 85);
			this.numLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numLength.Name = "numLength";
			this.numLength.Scale = 1;
			this.numLength.Size = new System.Drawing.Size(65, 20);
			this.numLength.TabIndex = 2;
			this.numLength.Text = "0.0";
			this.numLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numLength.Value = 0D;
			// 
			// lblSl_Ton_Min
			// 
			this.lblSl_Ton_Min.AutoEllipsis = true;
			this.lblSl_Ton_Min.AutoSize = true;
			this.lblSl_Ton_Min.Location = new System.Drawing.Point(47, 88);
			this.lblSl_Ton_Min.Name = "lblSl_Ton_Min";
			this.lblSl_Ton_Min.Size = new System.Drawing.Size(51, 13);
			this.lblSl_Ton_Min.TabIndex = 139;
			this.lblSl_Ton_Min.Tag = "Length";
			this.lblSl_Ton_Min.Text = "Chiều dài";
			this.lblSl_Ton_Min.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTen_Size
			// 
			this.txtTen_Size.AutoDropDown = null;
			this.txtTen_Size.Location = new System.Drawing.Point(134, 63);
			this.txtTen_Size.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtTen_Size.MaxLength = 100;
			this.txtTen_Size.Name = "txtTen_Size";
			this.txtTen_Size.Size = new System.Drawing.Size(375, 20);
			this.txtTen_Size.TabIndex = 1;
			// 
			// txtMa_Size
			// 
			this.txtMa_Size.AutoDropDown = null;
			this.txtMa_Size.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMa_Size.Location = new System.Drawing.Point(134, 41);
			this.txtMa_Size.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtMa_Size.MaxLength = 20;
			this.txtMa_Size.Name = "txtMa_Size";
			this.txtMa_Size.Size = new System.Drawing.Size(120, 20);
			this.txtMa_Size.TabIndex = 0;
			// 
			// lbTen_Sp
			// 
			this.lbTen_Sp.AutoEllipsis = true;
			this.lbTen_Sp.AutoSize = true;
			this.lbTen_Sp.Location = new System.Drawing.Point(47, 66);
			this.lbTen_Sp.Name = "lbTen_Sp";
			this.lbTen_Sp.Size = new System.Drawing.Size(81, 13);
			this.lbTen_Sp.TabIndex = 137;
			this.lbTen_Sp.Tag = "";
			this.lbTen_Sp.Text = "Tên kích thước";
			this.lbTen_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMa_Sp
			// 
			this.lbMa_Sp.AutoEllipsis = true;
			this.lbMa_Sp.AutoSize = true;
			this.lbMa_Sp.Location = new System.Drawing.Point(47, 44);
			this.lbMa_Sp.Name = "lbMa_Sp";
			this.lbMa_Sp.Size = new System.Drawing.Size(77, 13);
			this.lbMa_Sp.TabIndex = 136;
			this.lbMa_Sp.Tag = "";
			this.lbMa_Sp.Text = "Mã kích thước";
			this.lbMa_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmDmSize_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 281);
			this.Name = "frmDmSize_Edit";
			this.Object_ID = "DMSIZE";
			this.Tag = "frmDmSize, ESC";
			this.Text = "frmDmSize";
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

		private RosySystem.Control.rsTextBoxNumber numMaxWeight;
		private RosySystem.Control.rsLabel rsLabel6;
		private RosySystem.Control.rsTextBoxNumber numMinWeight;
		private RosySystem.Control.rsLabel rsLabel7;
		private RosySystem.Control.rsTextBoxNumber numDMax;
		private RosySystem.Control.rsLabel rsLabel2;
		private RosySystem.Control.rsTextBoxNumber numDMin;
		private RosySystem.Control.rsLabel rsLabel3;
		private RosySystem.Control.rsTextBoxNumber numDiameter;
		private RosySystem.Control.rsLabel rsLabel1;
		private RosySystem.Control.rsTextBoxNumber numLength;
		private RosySystem.Control.rsLabel lblSl_Ton_Min;
		private RosySystem.Control.rsTextBox txtTen_Size;
		private RosySystem.Control.rsTextBox txtMa_Size;
		private RosySystem.Control.rsLabel lbTen_Sp;
		private RosySystem.Control.rsLabel lbMa_Sp;

	}
}