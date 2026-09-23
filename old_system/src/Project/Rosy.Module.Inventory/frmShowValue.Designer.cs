namespace RosyModule
{
	partial class frmShowValue
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
			this.numWeight = new RosySystem.Control.rsTextBoxNumberLed();
			this.SuspendLayout();
			// 
			// numWeight
			// 
			this.numWeight.AdjustMode = 1;
			this.numWeight.AlphaText = "0";
			this.numWeight.BackColor = System.Drawing.SystemColors.Control;
			this.numWeight.BackFillEndColor = System.Drawing.Color.Black;
			this.numWeight.BackFillStartColor = System.Drawing.Color.Black;
			this.numWeight.BackGradientMode = 4;
			this.numWeight.BackPicture = null;
			this.numWeight.BorderColor = System.Drawing.Color.Black;
			this.numWeight.BorderGradientMode = 4;
			this.numWeight.BorderLight = System.Drawing.Color.Black;
			this.numWeight.BorderShadow = System.Drawing.Color.Black;
			this.numWeight.BorderShape = 0;
			this.numWeight.BorderWidth = 0;
			this.numWeight.LeadingZeros = false;
			this.numWeight.LedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.numWeight.LedOnColor = System.Drawing.Color.Lime;
			this.numWeight.Location = new System.Drawing.Point(177, 136);
			this.numWeight.Name = "numWeight";
			this.numWeight.Size = new System.Drawing.Size(405, 116);
			this.numWeight.TabIndex = 0;
			this.numWeight.Value = 0D;
			// 
			// frmShowValue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 445);
			this.Controls.Add(this.numWeight);
			this.Name = "frmShowValue";
			this.Text = "frmShowValue";
			this.ResumeLayout(false);

		}

		#endregion

		private RosySystem.Control.rsTextBoxNumberLed numWeight;


	}
}