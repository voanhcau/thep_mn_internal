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

namespace RosyModule.Receivable
{
	public partial class frmDmCkCt_KQ : RosySystem.Customize.frmEdit
	{
        public DateTime dtNgay_Ct1;
        public DateTime dtNgay_Ct2;
        public DateTime dtNgay_Ct;
        public string strSo_Qd;

        public frmDmCkCt_KQ()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public new void Load(string strSo_Qd)
		{
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            txtSo_QD.Text = strSo_Qd;

            if (strSo_Qd != string.Empty)
            {
                rdbQuy.Visible = false;
                rdbThang.Visible = false;
            }
            
			BindingLanguage();

			this.ShowDialog();
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
            dtNgay_Ct1 = Library.StrToDate(dteNgay_Ct1.Text);
            dtNgay_Ct2 = Library.StrToDate(dteNgay_Ct2.Text);
            dtNgay_Ct = Library.StrToDate(dteNgay_Ct.Text);
            strSo_Qd = txtSo_QD.Text;

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
