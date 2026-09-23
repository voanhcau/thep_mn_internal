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
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;

namespace RosyModule.HRM
{
	public partial class frmQTKTKL_Edit : frmEdit
	{
		#region Phuong thuc
        
        string strLoai_KTKL;

		public frmQTKTKL_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strLoai_KTKL)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strLoai_KTKL = strLoai_KTKL;

			Common.ScaterMemvar(this, ref drEdit);
            
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//txtMa_Dt
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;
		}

		public bool FormCheckValid()
		{
			bool bvalid = true;
			//if (txtHo_Ten.Text.Trim() == string.Empty)
			//{
			//    Common.MsgOk(Languages.GetLanguage("Ho_Ten") + " " +
			//                  Languages.GetLanguage("Not_Null"));
			//    return false;
			//}

			return bvalid;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;
            drEdit["Loai_KTKL"] = strLoai_KTKL;
			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R09QTKTKL", ref drEdit))
				return false;

			return true;
		}
		#endregion

		#region Su kien
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
		#endregion
	}
}
