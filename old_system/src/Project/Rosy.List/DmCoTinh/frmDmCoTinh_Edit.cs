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
	public partial class frmDmCoTinh_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

		public frmDmCoTinh_Edit()
		{
			InitializeComponent();

			txtMa_Co_Tinh.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtGrade_ID.Validating += new CancelEventHandler(txtGrade_ID_Validating);

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
			if (txtGrade_ID.Text.Trim() != string.Empty)
				lbtGrade_Name.Text = DataTool.SQLGetNameByCode("R81DMMACTHEP", "Grade_ID", "Grade_Name", txtGrade_ID.Text.Trim());
			else
				lbtGrade_Name.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Co_Tinh.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Co_Tinh") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtGrade_ID.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Grade_ID") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMCOTINH", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_CO_TINH", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		void txtGrade_ID_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtGrade_ID.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("GRADE_ID", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtGrade_ID.Text = string.Empty;
				lbtGrade_Name.Text = string.Empty;
			}
			else
			{
				txtGrade_ID.Text = (string)drLookup["Grade_ID"];
				lbtGrade_Name.Text = (string)drLookup["Grade_Name"];

				if (drEdit.Table.Columns.Contains("Grade_Name"))
					drEdit["Grade_Name"] = drLookup["Grade_Name"];
			}
		}

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMCOTINH"))
				e.Cancel = true;
		}

        #endregion		
	}
}