using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosyList;
using RosySystem.Element;
using RosySystem.Common;

namespace RosyModule.General
{
    public partial class frmKetChuyen_Run : RosySystem.Customize.frmEdit
	{		

        #region Phuong thuc

        public frmKetChuyen_Run()
		{
			InitializeComponent();            

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

		}

		public void Load()
        {
			BindingLanguage();			

			this.ShowDialog();
		}		

		public bool FormCheckValid()
        {
            if (numThang1.Value <= 0 || numThang1.Value > 12)
            {
                Common.MsgOk(Languages.GetLanguage("Thang1") + " " + Languages.GetLanguage("Invalid"));
                return false;
            }

            if (numThang2.Value <= 0 || numThang2.Value > 12)
            {
                Common.MsgOk(Languages.GetLanguage("Thang2") + " " + Languages.GetLanguage("Invalid"));
                return false;
            }

			return true;
		}
        #endregion

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