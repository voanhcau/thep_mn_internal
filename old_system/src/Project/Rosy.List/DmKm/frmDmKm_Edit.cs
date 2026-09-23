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
	public partial class frmDmKm_Edit : RosyList.frmEdit
	{

        #region Phuong thuc

		public frmDmKm_Edit()
		{
			InitializeComponent();

			txtMa_Km.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Km.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtMa_Km_Parent.Validating += new CancelEventHandler(txtMa_Km_Parent_Validating);
		}

		void txtMa_Km_Parent_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km_Parent.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "Nh_Cuoi = '0'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Km_Parent.Text = string.Empty;
				lbtTen_Km_Cha.Text = string.Empty;
			}
			else
			{
				txtMa_Km_Parent.Text = ((string)drLookup["Ma_Km"]).Trim();
				lbtTen_Km_Cha.Text = ((string)drLookup["Ten_Km"]).Trim();
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
			if (txtMa_Km_Parent.Text.Trim() != string.Empty)
			{
				lbtTen_Km_Cha.Text = DataTool.SQLGetNameByCode("R81DMKM", "Ma_Km", "Ten_Km", txtMa_Km_Parent.Text.Trim());
			}
			else
				lbtTen_Km_Cha.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
			bool bvalid = true ;
			if (txtMa_Km.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Km") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtTen_Km.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Km") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMKM", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_KM", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmKm"))
				e.Cancel = true;
		}

        #endregion 

		private void lblMa_Bp_Parent_Click(object sender, EventArgs e)
		{

		}

	}
}