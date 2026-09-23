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
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmKhoKG_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

        public frmDmKhoKG_Edit()
		{
			InitializeComponent();

			txtMa_Kho.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			
            //txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
            if (enuNew_Edit == enuEdit.Edit)
                numHan_HD.Value = Convert.ToDouble(drEdit["Han_HD"]);
            //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            //{
            //    numStt.Value = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Stt), 0) + 1 FROM R81DmKho"));
            //}

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            //txtMa_Dt.bUseAutoDropDown = true;

            //if (txtMa_Dt.Text.Trim() != string.Empty)
            //{
            //    lblTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            //}
            //else
            //    lblTen_Dt.Text = string.Empty;

            //if (txtTk_Vtu.Text.Trim() != string.Empty)
            //{
            //    lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_Vtu.Text.Trim());
            //}
            //else
            //    lbtTen_Tk.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Kho.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Kho") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }

            //if (numSl_Dm_Kg.Value == 0)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Sl_Dm_Kg") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMKHOKG", ref drEdit))
				return false;

			//Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("MA_KHO", drEdit);

			return true;
		}

        #endregion

        #region Su kien
        //void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtMa_Dt.Text.Trim();
        //    bool bRequire = false;

        //    DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, null, "");

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //    {
        //        txtMa_Dt.Text = string.Empty;
        //        lblTen_Dt.Text = string.Empty;
        //    }
        //    else
        //    {
        //        txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
        //        lblTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
        //    }
        //}
		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMKHOKG"))
				e.Cancel = true;
		}


        #endregion

        //private void rsTextBox1_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}