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
	public partial class frmDmCTrinh_Edit : RosyList.frmEdit
	{
        #region Phuong thuc

        public frmDmCTrinh_Edit()
		{
			InitializeComponent();

			txtMa_CTrinh.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_CTrinh.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtMa_CTrinh_Parent.Validating += new CancelEventHandler(txtMa_Bp_Parent_Validating);
            txtMa_Kv.Validating += new CancelEventHandler(txtMa_Kv_Validating);
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

			if (txtMa_CTrinh_Parent.Text.Trim() != string.Empty)
			{
				lbtTen_CTrinh_Cha.Text = DataTool.SQLGetNameByCode("R81DMCTRINH", "Ma_CTrinh", "Ten_CTrinh", txtMa_CTrinh_Parent.Text.Trim());
			}
			else
				lbtTen_CTrinh_Cha.Text = string.Empty;

            if (txtMa_Kv.Text.Trim() != string.Empty)
            {
                lbtTen_Kv.Text = DataTool.SQLGetNameByCode("R81DMKV", "Ma_Kv", "Ten_Kv", txtMa_Kv.Text.Trim());
            }
            else
                lbtTen_Kv.Text = string.Empty;

		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_CTrinh.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_CTrinh") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtTen_CTrinh.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_CTrinh") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

            if (txtMa_CTrinh.Text.Trim() == txtMa_CTrinh_Parent.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_CTrinh_Parent") + " " + Languages.GetLanguage("Invalid"));
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMCTRINH", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_CTRINH", drEdit);

			return true;
		}
        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMCTRINH"))
				e.Cancel = true;
		}
        void txtMa_Kv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kv.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Kv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_CTrinh_Parent.Text = string.Empty;
                lbtTen_Kv.Text = string.Empty;
            }
            else
            {
                txtMa_Kv.Text = ((string)drLookup["Ma_Kv"]).Trim();
                lbtTen_Kv.Text = ((string)drLookup["Ten_Kv"]).Trim();
            }
        }
		void txtMa_Bp_Parent_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_CTrinh_Parent.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_CTrinh", strValue, bRequire, "Nh_Cuoi = '0'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_CTrinh_Parent.Text = string.Empty;
				lbtTen_CTrinh_Cha.Text = string.Empty;
			}
			else
			{
				txtMa_CTrinh_Parent.Text = ((string)drLookup["Ma_CTrinh"]).Trim();
				lbtTen_CTrinh_Cha.Text = ((string)drLookup["Ten_CTrinh"]).Trim();
			}
		}

        #endregion 
	}
}