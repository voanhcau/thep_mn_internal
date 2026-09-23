using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
    public partial class frmDmNhDtCbNv_Edit : RosyList.frmEdit
    {
        #region Phuong thuc

		public frmDmNhDtCbNv_Edit()
		{
			InitializeComponent();

			txtMa_Nh_Dt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Nh_Dt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtMa_Nh_Dt_Parent.Validating += new CancelEventHandler(txtMa_Nh_Dt_Parent_Validating);
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
			if (txtMa_Nh_Dt_Parent.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Dt_Parent.Text = DataTool.SQLGetNameByCode("R81DMNHDT", "Ma_Nh_Dt", "Ten_Nh_Dt", txtMa_Nh_Dt_Parent.Text.Trim());
			}
			else
				lbtTen_Nh_Dt_Parent.Text = string.Empty;
		}
        
		public override bool FormCheckValid()
        {
            bool bvalid = true ;

            if (txtMa_Nh_Dt.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Dt") + " " +
								Languages.GetLanguage("Not_Null"));
				return false;
            }

			if (txtTen_Nh_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Nh_Dt") + " " +
								Languages.GetLanguage("Not_Null"));
				return false;
			}

            if (txtMa_Nh_Dt.Text.Trim() == txtMa_Nh_Dt_Parent.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Dt_Parent") + " " +
								Languages.GetLanguage("Invalid"));
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

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMNHDT", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_NH_DT", drEdit);

			return true;
		}
        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmNhDt"))
				e.Cancel = true;
		}

		void txtMa_Nh_Dt_Parent_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Dt_Parent.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Dt", strValue, bRequire, "Nh_Cuoi = '0'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Dt_Parent.Text = string.Empty;
				lbtTen_Nh_Dt_Parent.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Dt_Parent.Text = ((string)drLookup["Ma_Nh_Dt"]).Trim();
				lbtTen_Nh_Dt_Parent.Text = ((string)drLookup["Ten_Nh_Dt"]).Trim();
			}

        }

        #endregion 
    }
}