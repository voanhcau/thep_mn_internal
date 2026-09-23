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
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmCk_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

		public frmDmCk_Edit()
		{
			InitializeComponent();

			//txtMa_Kho.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			//txtTen_Kho.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			//txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			//txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Nh_Vt_Validating);
			//txtLoai_Dt.Validating += new CancelEventHandler(txtLoai_Dt_Validating);
			txtSo_QD.Validating += new CancelEventHandler(txtSo_QD_Validating);
           
		}

		
        //void txtLoai_Dt_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtLoai_Dt.Text.Trim();
        //    bool bRequire = true;

        //    DataRow drLookup = Lookup.ShowLookup("Loai_Dt", strValue, bRequire, "", "");

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
            
        //        txtLoai_Dt.Text = string.Empty;
        //    else
        //        txtLoai_Dt.Text = ((string)drLookup["Loai_Dt"]).Trim();
            
        //}

		//void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		//{
		//    string strValue = txtMa_Nh_Vt.Text.Trim();
		//    bool bRequire = true;

		//    DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "", "");

		//    if (bRequire && drLookup == null)
		//        e.Cancel = true;

		//    if (drLookup == null)
		//    {
		//        txtMa_Nh_Vt.Text = string.Empty;
		//        lbTen_Nh_Vt.Text = string.Empty;
		//    }
		//    else
		//    {
		//        txtMa_Nh_Vt.Text = ((string)drLookup["Ma_Nh_Vt"]).Trim();
		//        lbTen_Nh_Vt.Text = ((string)drLookup["Ten_Nh_Vt"]).Trim();
		//    }
		//}

		//void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		//{
		//    string strValue = txtMa_Kho.Text.Trim();
		//    bool bRequire = true;

		//    DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

		//    if (bRequire && drLookup == null)
		//        e.Cancel = true;

		//    if (drLookup == null)
		//    {
		//        txtMa_Kho.Text = string.Empty;
		//        lbTen_Kho.Text = string.Empty;
		//    }
		//    else
		//    {
		//        txtMa_Kho.Text = ((string)drLookup["Ma_Kho"]).Trim();
		//        lbTen_Kho.Text = ((string)drLookup["Ten_Kho"]).Trim();
		//    }
		//}

		void txtSo_QD_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtSo_QD.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("So_Qd", strValue, bRequire, "Loai_Qd = '1'", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtSo_QD.Text = string.Empty;
			}
			else
			{
				txtSo_QD.Text = ((string)drLookup["So_Qd"]).Trim();
				dteNgay_Ap.Text = ((string)drLookup["Ngay_Qd"]).Trim();

			}
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

            //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            //{
            //    numStt.Value = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Stt), 0) + 1 FROM R81DmCk"));
            //}

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
 
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtSo_QD.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Kho") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

            //if (txtTen_Kho.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ten_Kho") + " " +
            //                  Languages.GetLanguage("Not_Null"));
            //    return false;
            //}

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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMCK", ref drEdit))
				return false;

			//Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("MA_KHO", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMCK"))
				e.Cancel = true;
		}

        #endregion		

  

      
	}
}