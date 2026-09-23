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
	public partial class frmIn_Cham_Cong : RosySystem.Customize.frmEdit
	{
        public frmIn_Cham_Cong()
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
            //rdbPhieu_Nhap.Checked = (strChon_Hoa_Don == "1");
            //rdbPx_BBXN.Checked = (strChon_Hoa_Don == "2");
			//rdbPx_Barcode.Checked = (strChon_Hoa_Don == "2");
			

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
