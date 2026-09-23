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
    public partial class frmDmDtXNCN_Edit : RosyList.frmEdit
    {
        #region Phuong thuc

        public frmDmDtXNCN_Edit()
		{
			InitializeComponent();

			txtMa_Dt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtEmail.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtMa_Dt.Validating+=new CancelEventHandler(txtMa_Dt_Validating);
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
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;
		}
        
		public override bool FormCheckValid()
        {
            bool bvalid = true ;

            if (txtMa_Dt.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Dt") + " " +
								Languages.GetLanguage("Not_Null"));
				return false;

            }			

			if (txtEmail.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Email") + " " +
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

			//Kiem tra Valid CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMDT_XNCN", ref drEdit))
				return false;

			//Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("MA_NH_DT", drEdit);

			return true;
		}

		#endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
            //if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmDt"))
            //    e.Cancel = true;
		}

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