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

namespace RosyList
{
	public partial class frmDmType_Edit : RosyList.frmEdit
	{
		#region Phuong thuc

		public frmDmType_Edit()
		{
			InitializeComponent();

		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{

		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtType.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Type") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtType_ID.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Kho") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtType_Name.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Kho") + " " +
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

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmType", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Type_ID", drEdit);

			return true;
		}
		#endregion

		#region Su kien


		#endregion
	}
}