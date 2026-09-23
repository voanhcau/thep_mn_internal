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
	public partial class frmIn_ChamCong : RosySystem.Customize.frmEdit
	{
        public frmIn_ChamCong()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

        public void Load(DataRow drViewPh)
        {
            this.drEdit = drViewPh;
            txtMa_Dt_CbNv.Text = drViewPh["Ma_Dt_CbNv"].ToString();
            Common.ScaterMemvar(this, ref drViewPh);

            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

		public void Load(DataRow drViewPh, bool bReview)
		{
			this.drEdit = drViewPh;

			Common.ScaterMemvar(this, ref drViewPh);

            if (bReview)
                rdbChamCong.Visible = true;
   
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

        //private void rdbList_TB_CheckedChanged(object sender, EventArgs e)
        //{

        //}
      
	}
}
