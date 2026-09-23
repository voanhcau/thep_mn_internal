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
using RosySystem;
using RosySystem.Public;
using RosySystem.Element;
using RosySystem.Common;

namespace RosyList
{
	public partial class frmDmNL_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

		public frmDmNL_Edit()
		{
			InitializeComponent();

			txtMa_Nh_Vt.Validating +=new CancelEventHandler(txtMa_Nh_Vt_Validating);
            txtGrade_ID.Validating += new CancelEventHandler(txtGrade_ID_Validating);
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
			if (txtMa_Nh_Vt.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Vt.Text = DataTool.SQLGetNameByCode("R81DmNhVt", "Ma_Nh_Vt", "Ten_Nh_Vt", txtMa_Nh_Vt.Text.Trim());
			}
			else
				lbtTen_Nh_Vt.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Nh_Vt.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Vt") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMDINHMUCNL", ref drEdit))
				return false;

			////Doi ma
			//if (this.enuNew_Edit == enuEdit.Edit)
			//    DataTool.SQLChangeID("MA_KHO", drEdit);

			return true;
		}

        #endregion

        #region Su kien
        void txtGrade_ID_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtGrade_ID.Text.Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Grade_ID", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtGrade_ID.Text = string.Empty;
                lbtGrade_Name.Text = string.Empty;
            }
            else
            {
                txtGrade_ID.Text = ((string)drLookup["Grade_ID"]).Trim();
                lbtGrade_Name.Text = ((string)drLookup["Grade_Name"]).Trim();

            }
        }
        

		private void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();

			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Vt.Text = string.Empty;
				lbtTen_Nh_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Vt.Text = ((string)drLookup["Ma_Nh_Vt"]).Trim();
				lbtTen_Nh_Vt.Text = ((string)drLookup["Ten_Nh_Vt"]).Trim();

			}
		}

        #endregion		
	}
}