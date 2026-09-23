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
	public partial class frmDmBarems_Edit : RosyList.frmEdit
	{
        #region Phuong thuc

        public frmDmBarems_Edit()
		{
			InitializeComponent();

			txtMa_Size.Validating += new CancelEventHandler(txtMa_Size_Validating);
			txtGrade_ID.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtGrade_ID.Validating += new CancelEventHandler(txtGrade_ID_Validating);
		}

		void txtMa_Size_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Size.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Size", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Size.Text = string.Empty;
				lbtTen_Size.Text = string.Empty;
			}
			else
			{
				txtMa_Size.Text = ((string)drLookup["Ma_Size"]).Trim();
				lbtTen_Size.Text = ((string)drLookup["Ten_Size"]).Trim();
			}
		}

        void txtGrade_ID_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtGrade_ID.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Grade_ID", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtGrade_ID.Text = string.Empty;
                lbGrade_Name.Text = string.Empty;
            }
            else
            {
				txtGrade_ID.Text = ((string)drLookup["Grade_ID"]).Trim();
				lbGrade_Name.Text = (string)drLookup["Grade_Name"];
            }
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
            if (txtGrade_ID.Text.Trim() != string.Empty)
            {
                lbGrade_Name.Text = DataTool.SQLGetNameByCode("R81DmStandard", "Standard_ID", "Standard_Name", txtGrade_ID.Text.Trim());
            }
            else
                lbGrade_Name.Text = string.Empty;
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMBAREMS", ref drEdit))
				return false;

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmBarems"))
				e.Cancel = true;
		}

        #endregion
	}
}