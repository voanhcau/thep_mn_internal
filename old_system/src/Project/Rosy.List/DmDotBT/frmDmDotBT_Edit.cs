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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmDotBT_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

        public frmDmDotBT_Edit()
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
            if (dteNgay_Ct1.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ngay_Ct1") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (dteNgay_Ct2.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_Ct2") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }		
            //if (txtTen_Kho.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ten_Kho") + " " +
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
            if (!DataTool.SQLUpdate(enuNew_Edit, "R06DSBAOTRI", ref drEdit))
				return false;

		

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMNGAYLE"))
				e.Cancel = true;
		}

        #endregion		

  

      
	}
}