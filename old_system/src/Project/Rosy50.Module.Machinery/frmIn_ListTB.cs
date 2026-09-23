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
	public partial class frmIn_ListTB : RosySystem.Customize.frmEdit
	{
        public frmIn_ListTB()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

        public void Load(DataRow drViewPh, string strMa_Bp)
        {
            this.drEdit = drViewPh;

            Common.ScaterMemvar(this, ref drViewPh);
            
            txtNam.Text = Element.sysWorkingYear.ToString();
            txtMa_Bp.Text = strMa_Bp;
            //string strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
            //txtMa_Bp.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt_CbNv + "'");

            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

		public void Load(DataRow drViewPh, bool bReview, string strMa_Bp)
		{
			this.drEdit = drViewPh;

			Common.ScaterMemvar(this, ref drViewPh);
            txtNam.Text = Element.sysWorkingYear.ToString();
            txtMa_Bp.Text = strMa_Bp;
            if (bReview)
            {
              
                rdbLyLich2.Visible = true;
              
            }
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
