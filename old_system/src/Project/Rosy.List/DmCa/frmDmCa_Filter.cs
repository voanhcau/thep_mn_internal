using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Public;
using RosyList;

namespace RosyList
{
	public partial class frmDmCa_Filter : RosySystem.Customize.frmEdit
	{
		public frmDmCa_Filter()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public new void Load()
		{
			BindingLanguage();

			this.ShowDialog();
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			
			isAccept = true;
			this.Close();
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
	}
}
