using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosyList;
using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Control;

namespace RosyModule
{
	public partial class frmDanhSo_Ct : RosySystem.Customize.frmEdit
	{
		#region Contructor

		public frmDanhSo_Ct()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}		

		#endregion		

		#region phuong thuc

		public void Load()
		{
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;

			if (txtSo_Ct_Format.Text == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("SO_CT_FORMAT") + " " + Languages.GetLanguage("NOTEMPTY"));
				return false;
			}

			return bvalid;
		}

		#endregion

		#region Event

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				if (Common.MsgYes_No("Bạn có chắc chắn đánh lại số chứng từ hay không?", "Y"))
				{
					this.isAccept = true;
					this.Close();
				}
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		#endregion

	}
}
