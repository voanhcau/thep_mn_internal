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
	public partial class frmDmMacThepCt_Edit : RosyList.frmEdit
	{

        #region Phuong thuc

        public frmDmMacThepCt_Edit()
		{
			InitializeComponent();
            txtGrade_ID.Validating += new CancelEventHandler(txtCheckDuplicate);//Kiểm tra dữ liệu đã tồn tại
			txtStandard_ID.Validating += new CancelEventHandler(txtStandard_ID_Validating);
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
		}

        private void LoadDicName()
        {
            //Ma_Nh_Vt
            if (txtStandard_ID.Text.Trim() != string.Empty)
            {
                lbtStandard_Name.Text = DataTool.SQLGetNameByCode("R81DmStandard", "Standard_ID", "Standard_Name", txtStandard_ID.Text.Trim());
            }
            else
                lbtStandard_Name.Text = string.Empty;
        }

		public override bool FormCheckValid()
        {
			bool bvalid = true ;

			if (txtStandard_ID.Text.Trim() == string.Empty)
			{
                Common.MsgOk(Languages.GetLanguage("Standard_ID") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMMACTHEPCT", ref drEdit))
				return false;

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("GRADE_ID", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		void txtStandard_ID_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtStandard_ID.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("STANDARD_ID", strValue, bRequire, "");

			if (drLookup == null && bRequire)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtStandard_ID.Text = lbtStandard_Name.Text = string.Empty;
			}
			else
			{
				txtStandard_ID.Text = (string)drLookup["Standard_ID"];
				lbtStandard_Name.Text = (string)drLookup["Standard_Name"];
			}
		}

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMMACTHEPCT"))
				e.Cancel = true;
		}

        #endregion 

	}
}