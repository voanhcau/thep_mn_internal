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

namespace RosyList
{
	public partial class frmDmCa_CreateAuto : RosySystem.Customize.frmEdit
	{
        public frmDmCa_CreateAuto()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            this.btExec.Click += new EventHandler(btExec_Click);
		}

       

		public new void Load()
		{
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
			BindingLanguage();

			this.ShowDialog();
		}
        void btExec_Click(object sender, EventArgs e)
        {
            if (cboCa.Text == "")
                Common.MsgOk("Ca bắt đầu không được rỗng. Bạn phải chọn ca sản xuất bắt đầu");

            if (cboCa.Text != "")
            {
                System.Collections.Hashtable htPara = new System.Collections.Hashtable();
                htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
                htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
                htPara.Add("CA", cboCa.Text);

                SQLExec.Execute("sp_CreateCasxAuto", htPara, CommandType.StoredProcedure);

                isAccept = true;
                this.Close();
            }
            else
            {
                isAccept = false;
                this.Close();
            }
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
