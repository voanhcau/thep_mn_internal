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

namespace RosyModule.HRM
{
	public partial class frmDinhMucMonAn_Edit : RosyList.frmEdit
	{
        #region Phuong thuc

		public frmDinhMucMonAn_Edit()
		{
			InitializeComponent();

            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
			
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
            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Vt LIKE 'VTNA%'";

            if (txtMa_Vt.Text.Trim() != string.Empty)
            {
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
                lbtDvt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Dvt", txtMa_Vt.Text.Trim());
            }
            else
            {
                lbtTen_Vt.Text = string.Empty;
                lbtDvt.Text = string.Empty;
            }
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Vt.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_MAn") + " " +
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
            if (!DataTool.SQLUpdate(enuNew_Edit, "R09DMMONAN", ref drEdit))
				return false;

			
			return true;
		}
        #endregion

        #region Su kien

        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "Ma_Vt LIKE 'VTNA%'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;
                lbtDvt.Text = string.Empty;
            }
            else
            {
                txtMa_Vt.Text = ((string)drLookup["Ma_Vt"]).Trim();
                lbtTen_Vt.Text = ((string)drLookup["Ten_Vt"]).Trim();
                lbtDvt.Text = ((string)drLookup["Dvt"]).Trim();
            }
        }

		

        #endregion 
	}
}