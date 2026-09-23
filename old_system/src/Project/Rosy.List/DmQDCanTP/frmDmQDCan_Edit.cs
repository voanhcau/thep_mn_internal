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
using RosySystem.Public;
using RosySystem.Element;
using RosySystem.Common;

namespace RosyList
{
	public partial class frmDmQDCan_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

		public frmDmQDCan_Edit()
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
            bool bvalid = true ;
            if (txtLoai_Thep.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Vt") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMQDCAN", ref drEdit))
				return false;

			////Doi ma
			//if (this.enuNew_Edit == enuEdit.Edit)
			//    DataTool.SQLChangeID("MA_KHO", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		
        #endregion		
	}
}