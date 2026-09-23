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

namespace RosyModule.Salary
{
	public partial class frmDmNgayLeCty_Edit : RosyList.frmEdit
	{

        #region Phuong thuc
        DateTime dtGio;
        public frmDmNgayLeCty_Edit()
		{
			InitializeComponent();

            txtLoai.Validating += new CancelEventHandler(txtMa_Dt_Validating);
           
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
            dtGio = Convert.ToDateTime(drEdit["Tu_Ngay"]);
            dteGio_Vao.Text = dtGio.ToString("HH:mm:ss");


            BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            if (txtLoai.Text != string.Empty)
            {

                lblTen_Loai.Text = SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE TYPE = 'TRANG_THAI_CONG' AND Type_ID = '" + txtLoai.Text + "'").ToString();
            }
            else
            {
                lblTen_Loai.Text = string.Empty;

            }
        }

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (dteTu_Ngay.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ngay_Ct1") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (dteDen_Ngay.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_Ct2") + " " +
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

            if (dteGio_Vao.Text != "00:00:00")
                drEdit["Tu_Ngay"] = Convert.ToDateTime(dteTu_Ngay.Text+ " " +dteGio_Vao.Text);
            else
                drEdit["Tu_Ngay"] = Library.StrToDate(dteTu_Ngay.Text);

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81NGAYLECTY", ref drEdit))
				return false;

		

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81NGAYLECTY"))
				e.Cancel = true;
		}
        
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtLoai.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "TRANG_THAI_CONG");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'TRANG_THAI_CONG'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtLoai.Text = string.Empty;
                lblTen_Loai.Text = string.Empty;
            }
            else
            {
               
                txtLoai.Text = ((string)drLookup["Type_ID"]).Trim();
                lblTen_Loai.Text = ((string)drLookup["Type_Name"]).Trim();
            }
        }
        #endregion		

  

      
	}
}