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

namespace RosyModule.Manufactory
{
	public partial class frmIn_LSX : RosySystem.Customize.frmEdit
	{
        public frmIn_LSX()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load()
		{
            //this.drEdit = drViewPh;

            //Common.ScaterMemvar(this, ref drViewPh);
			
			BindingLanguage();
			LoadDicName();


            //string strChon_Hoa_Don = Common.GetBufferValue("CHON_HOA_DON_IN") == null ? "1" : Common.GetBufferValue("CHON_HOA_DON_IN");
            //rdbPhieu_Xuat.Checked = (strChon_Hoa_Don == "1");
            //rdbPx_BBM.Checked = (strChon_Hoa_Don == "2");
			//rdbPx_Barcode.Checked = (strChon_Hoa_Don == "2");

            rdbTong_Hop.Checked = true;
			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
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
