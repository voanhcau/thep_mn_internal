using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Control;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmReplace : RosySystem.Customize.frmEdit
	{
		public frmReplace()
		{
			InitializeComponent();
			txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Moi_Validating);

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load()
		{
			this.BindingLanguage();
			this.ShowDialog();
		}

		void txtMa_Moi_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();
			
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Vt.Text = string.Empty;
				lbtTen_Nh_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Vt.Text = ((string)drLookup["Ma_Nh_Vt"]).Trim();
				lbtTen_Nh_Vt.Text = ((string)drLookup["Ten_Nh_Vt"]).Trim();
			}
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
