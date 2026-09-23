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
using RosySystem.Element;
using RosySystem;
using RosySystem.Common;

namespace RosyList
{
	public partial class frmDmLoai_Hang_Edit : RosyList.frmEdit
	{

        #region Phuong thuc

		public frmDmLoai_Hang_Edit()
		{
			InitializeComponent();

			txtMa_Loai_Hang.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Loai_Hang.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
			this.btgAccept.btAccept.Enabled = true;
		}

		private void LoadDicName()
		{
		}

		public override bool FormCheckValid()
        {
			bool bvalid = true ;
			//if (txtMa_Loai_Hang.Text.Trim() == string.Empty)
			//{
			//    Common.MsgOk(Languages.GetLanguage("Ma_Loai_Hang") + " " +
			//                  Languages.GetLanguage("Not_Null"));
			//    return false;
			//}			

			//if (txtTen_Loai_Hang.Text.Trim() == string.Empty)
			//{
			//    Common.MsgOk(Languages.GetLanguage("Ten_Loai_Hang") + " " +
			//                  Languages.GetLanguage("Not_Null"));
			//    return false;
			//}

            return bvalid;
        }

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMLOAIHANG", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_LOAI_HANG", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			//if (this.CheckDuplicate((TextBox)sender, drEdit, "MA_LOAI_HANG"))
			//    e.Cancel = true;
		}

        #endregion 

		private void lbTen_Km_Click(object sender, EventArgs e)
		{

		}

	}
}