using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Control;

namespace RosyModule.Payable
{
	public partial class frmPhanBoThueNk : RosySystem.Customize.frmEdit
	{
		public frmPhanBoThueNk()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			isAccept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
	}
}