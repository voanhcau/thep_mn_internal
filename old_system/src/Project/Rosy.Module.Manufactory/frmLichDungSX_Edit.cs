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
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyModule.Manufactory
{
	public partial class frmLichDungSX_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

        public frmLichDungSX_Edit()
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

            if (DataTool.SQLCheckExist("R13LICHDUNGSX", new string[] { "Loai_Sx","Ca_BD", "Ngay_Ct1", "Ngay_Ct2" }, new object[] { txtLoai_SX.Text, txtCa_BD.Text, dteNgay_Ct1.Text, dteNgay_Ct2.Text }))
            {
                Common.MsgOk("Dữ liệu đã tồn tại. Không cho phép lưu!!!");
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
            
            drEdit["Ma_DvCs"] = Element.sysMa_DvCs;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R13LICHDUNGSX", ref drEdit))
				return false;

			//Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("MA_KHO", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
            //if (this.CheckDuplicate((TextBox)sender, drEdit, "R13NANGSUATSP"))
            //    e.Cancel = true;
		}


        #endregion		

        //private void rsLabel1_Click(object sender, EventArgs e)
        //{

        //}
	}
}