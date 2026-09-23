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
using RosySystem.Element;

namespace RosyModule.Payable
{
	public partial class frmFilter_QLHD : RosySystem.Customize.frmEdit
	{
		public frmFilter_QLHD()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
		}

       

		public new void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

			Common.ScaterMemvar(this, ref drEdit);

            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			BindingLanguage();
			LoadDicName();
            txtMa_Hd.bUseAutoDropDown = true;
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			Common.GatherMemvar(this, ref drEdit);
			
			isAccept = true;
			this.Close();

		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
        void txtMa_Hd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Hd.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Hd.Text = string.Empty;
                lbtTen_Hd.Text = string.Empty;
            }
            else
            {
                txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
                lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();
            }
        }
		
	}
}
