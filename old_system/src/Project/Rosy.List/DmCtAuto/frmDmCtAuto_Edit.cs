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
	public partial class frmDmCtAuto_Edit : RosyList.frmEdit
	{
        #region Phuong thuc

		public frmDmCtAuto_Edit()
		{
			InitializeComponent();

			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
		}

		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ct.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Ct.Text = string.Empty;
				lbtTen_Ct.Text = string.Empty;
			}
			else
			{
				txtMa_Ct.Text = ((string)drLookup["Ma_Ct"]).Trim();
				lbtTen_Ct.Text = ((string)drLookup["Ten_Ct"]).Trim();
			}

			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmCtAuto"))
				e.Cancel = true;
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = ((string)drLookup["Ma_Vt"]).Trim();
				lbtTen_Vt_Sp.Text = ((string)drLookup["Ten_Vt"]).Trim();
			}
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
			if (txtMa_Ct.Text.Trim() != string.Empty)
				lbtTen_Ct.Text = DataTool.SQLGetNameByCode("R00DMCT", "Ma_Ct", "Ten_Ct", txtMa_Ct.Text.Trim());
			else
				lbtTen_Ct.Text = string.Empty;

			if (txtMa_Dt.Text.Trim() != string.Empty)
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			else
				lbtTen_Dt.Text = string.Empty;

			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			else
				lbtTen_Vt_Sp.Text = string.Empty;

		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Ct.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Ct") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtDescription.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Description") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMCTAUTO", ref drEdit))
				return false;
			
			return true;
		}
        #endregion

        #region Su kien

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
				lbtTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
			}
		}


        #endregion 
	}
}