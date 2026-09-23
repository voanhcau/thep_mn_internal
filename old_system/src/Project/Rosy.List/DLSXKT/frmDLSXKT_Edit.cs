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
	public partial class frmDLSXKT_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

        public frmDLSXKT_Edit()
		{
			InitializeComponent();

            //txtMa_So.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
            txtMa_So.Validating += new CancelEventHandler(txtMa_So_Validating);
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
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            //if (txtMa_So.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ma_Su_Co") + " " +
            //                  Languages.GetLanguage("Not_Null"));
            //    return false;
            //}

			
            return bvalid;
        }
        void txtMa_So_Validating(object sender, CancelEventArgs e)
        {
            bool bRequire = true;
            string strFilter = "Type='DLSXKT'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "DLSXKT");
            DataRow drLookup = Lookup.ShowLookup("PT_VC", txtMa_So.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtMa_So.Text = string.Empty;
                lbtTen_Ma_So.Text = string.Empty;
            }
            else
            {
                txtMa_So.Text = drLookup["Type_ID"].ToString();
            }

           
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
            if (!DataTool.SQLUpdate(enuNew_Edit, "R11DLSXPKT", ref drEdit))
				return false;

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
            if (this.CheckDuplicate((TextBox)sender, drEdit, "R11DLSXPKT"))
				e.Cancel = true;
		}

        #endregion		

        //private void rsLabel1_Click(object sender, EventArgs e)
        //{

        //}
	}
}