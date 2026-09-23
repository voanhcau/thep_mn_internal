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

namespace RosyModule.Receivable
{
    public partial class frmIn_Ct_QDGia : RosySystem.Customize.frmEdit
	{
        string strTable_Ph = string.Empty;
        string strTable_Ct = string.Empty;

		public frmIn_Ct_QDGia()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);
            
		}

		public void Load()
		{
			
			
			BindingLanguage();
			LoadDicName();
           
			

           

			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}

        private bool Save()
        {
           

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
