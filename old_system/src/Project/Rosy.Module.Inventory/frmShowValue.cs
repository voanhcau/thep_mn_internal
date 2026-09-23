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
	public partial class frmShowValue : RosySystem.Customize.frmView
	{
		public frmShowValue()
		{
			InitializeComponent();
		}

		public override void Load()
		{
			numWeight.Value = Values.dbValues_Weight;
			this.Show();
		}
	}
}
