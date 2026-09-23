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

namespace RosyModule.Machinery
{
	public partial class frmChonImpTB : RosySystem.Customize.frmEdit
	{
        public frmChonImpTB()
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

            this.ShowDialog();
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
