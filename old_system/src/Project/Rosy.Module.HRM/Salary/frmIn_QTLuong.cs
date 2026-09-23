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

namespace RosyModule.Salary
{
    public partial class frmIn_QTLuong : RosySystem.Customize.frmEdit
	{
        public frmIn_QTLuong()
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

			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}

        private bool Save()
        {
            //Common.GatherMemvar(this, ref drEdit);
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

        //private void frmIn_Ct_NMPT_Load(object sender, EventArgs e)
        //{

        //}
      
	}
}
