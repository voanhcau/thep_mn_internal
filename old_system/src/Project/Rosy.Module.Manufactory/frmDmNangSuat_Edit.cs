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
	public partial class frmDmNangSuat_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

		public frmDmNangSuat_Edit()
		{
			InitializeComponent();

			txtMa_Size.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
            txtGrade_ID.Validating += new CancelEventHandler(txtGrade_ID_Validating);
            txtMa_Size.Validating += new CancelEventHandler(txtMa_Size_Validating);
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
            //Ma_Vt_Gt
            if (txtGrade_ID.Text.Trim() != string.Empty)
            {
                lblGrade_Name.Text = DataTool.SQLGetNameByCode("R81DMMACTHEP", "Grade_ID", "Grade_Name", txtGrade_ID.Text.Trim());
            }
            else
                lblGrade_Name.Text = string.Empty;

		}
        void txtMa_Size_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Size.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Size", strValue, bRequire, string.Empty);
            if (drLookup == null && bRequire)
                e.Cancel = true;

            if (drLookup == null)
                txtMa_Size.Text = string.Empty;
            else
                txtMa_Size.Text = (string)drLookup["Ma_Size"];
        }

        void txtGrade_ID_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtGrade_ID.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Grade_ID", strValue, bRequire, string.Empty);
            if (drLookup == null && bRequire)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtGrade_ID.Text = string.Empty;
                lblGrade_Name.Text = string.Empty;
            }
            else
            {
                txtGrade_ID.Text = (string)drLookup["Grade_ID"];
                lblGrade_Name.Text = (string)drLookup["Grade_Name"];
            }
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
            if (txtGrade_ID.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Grade_ID") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }	
            if(DataTool.SQLCheckExist("R13NANGSUATSP", new string[] {"Ma_Size","Grade_ID","Ngay_Ap"}, new object[] {txtMa_Size.Text, txtGrade_ID.Text, dteNgay_Ap.Text}))
            {
                Common.MsgOk("Tồn tại mã Size và mác thép cùng 1 ngày áp. Không cho phép lưu!!!");
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
            if (!DataTool.SQLUpdate(enuNew_Edit, "R13NANGSUATSP", ref drEdit))
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
	}
}