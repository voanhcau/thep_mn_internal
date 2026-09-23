using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
    public partial class frmDmSoXe_Edit : RosyList.frmEdit
    {

        #region Phuong thuc

        public frmDmSoXe_Edit()
		{
			InitializeComponent();

           
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
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
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Vt_Sp.bUseAutoDropDown = true;

			//txtMa_Vt
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lblTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lblTen_Dt.Text = string.Empty;

            //txtMa_Vt
            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
            {
                lblTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            }
            else
                lblTen_Vt_Sp.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtSo_Xe.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Xe") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;

            }
            
			if (txtTen_Dt_Vc.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Xe") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMSOXE", ref drEdit))
				return false;

		

			return true;
		}

		#endregion

        #region Su kien

        //void txtCheckDuplicate(object sender, CancelEventArgs e)
        //{
        //    if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMCUMTB"))
        //        e.Cancel = true;
        //}
        void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Sp.Text;
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

            if (drLookup == null)
            {
                txtMa_Vt_Sp.Text = string.Empty;
                lblTen_Vt_Sp.Text = string.Empty;
            }
            else
            {
                txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
                lblTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();
            }
        }
		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text;
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lblTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lblTen_Dt.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		
        #endregion

      
    }
}