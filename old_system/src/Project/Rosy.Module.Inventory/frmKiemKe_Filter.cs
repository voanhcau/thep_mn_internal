using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyModule.Inventory
{
    public partial class frmKiemKe_Filter : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmKiemKe_Filter()
		{
			InitializeComponent();
		
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);			
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}        

		public void Load()
		{
			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Events		

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, null, null);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}
		}		

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, null, null);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
			}
		}

        void btCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            isAccept = true;
            this.Close();
        }

		#endregion		
        
	}
}
