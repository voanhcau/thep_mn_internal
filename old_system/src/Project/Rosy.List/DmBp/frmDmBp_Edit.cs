using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmMAn_Edit : RosyList.frmEdit
	{
        #region Phuong thuc

		public frmDmMAn_Edit()
		{
			InitializeComponent();

			txtMa_Bp.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Bp.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtMa_Bp_Parent.Validating += new CancelEventHandler(txtMa_Bp_Parent_Validating);
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

			if (txtMa_Bp_Parent.Text.Trim() != string.Empty)
			{
				lbtTen_Bp_Cha.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp_Parent.Text.Trim());
			}
			else
				lbtTen_Bp_Cha.Text = string.Empty;

		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Bp.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Bp") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtTen_Bp.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Bp") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

            if (txtMa_Bp.Text.Trim() == txtMa_Bp_Parent.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Bp_Parent") + " " + Languages.GetLanguage("Invalid"));
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMBP", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_BP", drEdit);

			return true;
		}
        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmBp"))
				e.Cancel = true;
		}

		void txtMa_Bp_Parent_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp_Parent.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "Nh_Cuoi = '0'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp_Parent.Text = string.Empty;
				lbtTen_Bp_Cha.Text = string.Empty;
			}
			else
			{
				txtMa_Bp_Parent.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTen_Bp_Cha.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}
		}

        #endregion 
	}
}