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
	public partial class frmIn_Ct_DNX : RosySystem.Customize.frmEdit
	{
        public frmIn_Ct_DNX()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load(DataRow drViewPh)
		{
			this.drEdit = drViewPh;

			Common.ScaterMemvar(this, ref drViewPh);
			
			BindingLanguage();
			LoadDicName();

            rdbPX_Barcode.Visible = false;
            rdbPhieu_Xuat.Checked = true;
			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}

        public void Load()
        {
            rdbPX_Barcode.Checked = true;
            rdbPx_BBM.Visible = false;
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
