using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RosyModule
{
	public partial class frmTestCom : RosySystem.Customize.frmView
	{
		private int Mode = 0;
		private string strScale6080 = string.Empty;

		public frmTestCom()
		{
			InitializeComponent();
			this.timer1.Tick += new EventHandler(timer1_Tick);
			this.btInc.Click += new EventHandler(btInc_Click);
			this.btShot.Click += new EventHandler(btShot_Click);
			this.btDec.Click += new EventHandler(btDec_Click);
			this.btFix.Click += new EventHandler(btFix_Click);
			this.btStop.Click += new EventHandler(btStop_Click);
			this.btCancel.Click += new EventHandler(btCancel_Click);
			this.numDelay.Validated += new EventHandler(numDelay_Validated);
		}

		public override void Load()
		{
			this.Show();
		}

		new public void Load(string strScale6080)
		{
			this.strScale6080 = strScale6080;
			this.Show();
		}

		void numDelay_Validated(object sender, EventArgs e)
		{
			if (numDelay.Value <= 0)
				return;

			timer1.Interval = Convert.ToInt32(numDelay.Value);
		}

		void btDec_Click(object sender, EventArgs e)
		{
			this.Mode = 2;
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void btFix_Click(object sender, EventArgs e)
		{
			this.Mode = 0;
		}

		void btShot_Click(object sender, EventArgs e)
		{
			this.btShot.Enabled = false;
			this.btStop.Enabled = true;
			this.timer1.Enabled = true;
		}

		void btStop_Click(object sender, EventArgs e)
		{
			btShot.Enabled = true;
			btStop.Enabled = false;
			timer1.Enabled = false;
			Mode = 0;
		}

		void btInc_Click(object sender, EventArgs e)
		{
			this.Mode = 1;
		}

		void timer1_Tick(object sender, EventArgs e)
		{
			if (this.Mode != 0)
			{
				try
				{
					int num = Convert.ToInt32(numValue.Value);
					switch (this.Mode)
					{
						case 1:
							num += Convert.ToInt32(numInt.Value);
							if (num > 999999)
							{
								num = 999999;
							}
							numValue.Value = num;
							break;
						case 2:
							num -= Convert.ToInt32(this.numInt.Value);
							if (num < 0)
							{
								num = 0;
							}
							this.numValue.Value = num;
							break;
					}
				}
				catch
				{
				}
			}
			if (this.numValue.Text.Length > 0)
			{
				if(strScale6080 != string.Empty)
					HardwareInterfaceScale6080.Write(numValue.Value.ToString());
				else
					HardwareInterface.Write(numValue.Value.ToString());
			}
		}

	}
}
