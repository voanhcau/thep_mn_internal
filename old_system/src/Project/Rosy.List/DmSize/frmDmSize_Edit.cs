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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmSize_Edit : RosyList.frmEdit
	{

        #region Phuong thuc

		public frmDmSize_Edit()
		{
			InitializeComponent();

            txtMa_Size.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
		}

        public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();

			this.ShowDialog();
		}

		public override bool FormCheckValid()
        {
			bool bvalid = true ;

			if (txtMa_Size.Text.Trim() == string.Empty)
			{
                Common.MsgOk(Languages.GetLanguage("Ma_Size") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTen_Size.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Size") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMSIZE", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_SIZE", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMSIZE"))
				e.Cancel = true;
		}

        #endregion 

	}
}