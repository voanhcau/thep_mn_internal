using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;

namespace RosyModule
{
	public partial class frmIn_Ct_UNC_ChonMau : RosySystem.Customize.frmEdit
	{
		public frmIn_Ct_UNC_ChonMau()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load(DataRow drViewPh)
		{

			this.drEdit = drViewPh;
            txtReportTag.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("SELECT_UNC");
			Common.ScaterMemvar(this, ref drViewPh);

			this.ShowDialog();
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			return true;
		}

     
		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
                this.Close();	
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
      
	}
}
