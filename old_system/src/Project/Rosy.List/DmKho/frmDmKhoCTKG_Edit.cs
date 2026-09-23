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
	public partial class frmDmKhoCTKG_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

        public frmDmKhoCTKG_Edit()
		{
			InitializeComponent();

			txtMa_Nh_Kg.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Nh_Kg.Validating += TxtMa_Nh_Kg_Validating;
            btMa_Kho.Click += BtMa_Kho_Click;
        }

       

        public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

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
            txtMa_Dt.bUseAutoDropDown = true;

            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                lblTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            }
            else
                lblTen_Dt.Text = string.Empty;


            if (txtMa_Nh_Kg.Text.Trim() != string.Empty)
            {
                lblTen_Nh_Kg.Text = SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE TYPE = 'NHOM_KYGUI' AND Type_ID = '" + txtMa_Nh_Kg.Text + "'").ToString();
            }
            else
                lblTen_Nh_Kg.Text = string.Empty;
        }

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Dt.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Dt") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMKHOCT_KG", ref drEdit))
            {
               
                
              
                return false;
            }
            else
            {
                //Cập nhật danh mục kho
                if(txtMa_Kho_List.Text != "")
                    SQLExec.Execute("UPDATE R81DMKHO SET Ma_Nh_Kg = '" + txtMa_Nh_Kg.Text + "' WHERE Ma_Kho IN (SELECT String FROM dbo.fn_Split('" + txtMa_Kho_List.Text + "'))");
                //cập nhật ngày kết thúc là ngày áp hiện tại trừ đi 1 ngày
                
                //int iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT Ident00 FROM R81DMKHOCT_KG WHERE Ma_Dt = '"+ txtMa_Dt.Text + "' AND Ma_Nh_Kg = '"+ txtMa_Nh_Kg.Text +"' AND " +
                //                " MA_DT + Ma_Nh_Kg + CAST(NGAY_AP AS VARCHAR(11)) IN (SELECT MA_DT + Ma_Nh_Kg + CAST(MAX(NGAY_AP) AS VARCHAR(11)) " +
                //                " FROM R81DMKHOCT_KG WHERE Ngay_Ap < '"+ dteNgay_Ap.Text + "' GROUP BY Ma_Dt, Ma_Nh_Kg)"));
                //if (iIdent00 != null)
                //    SQLExec.Execute("UPDATE R81DMKHOCT_KG SET Ngay_Kt = '" + (Convert.ToDateTime(dteNgay_Ap.Text).AddDays(-1)).ToShortDateString() + "' WHERE Ident00 = "+ iIdent00 +""); 
            }

            //Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("MA_KHO", drEdit);

            return true;
		}

        #endregion

        #region Su kien
        private void BtMa_Kho_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;
            strFilter = " Ma_Kho LIKE '06%' AND Ma_Dt = '"+ txtMa_Dt.Text +"'";
            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (drLookup == null)
            {
                txtMa_Kho_List.Text = string.Empty;
            }
            else
            {
                txtMa_Kho_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }
        private void TxtMa_Nh_Kg_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Kg.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "NHOM_KYGUI");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'NHOM_KYGUI'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nh_Kg.Text = string.Empty;
                lblTen_Nh_Kg.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_Kg.Text = drLookup["Type_ID"].ToString();
                lblTen_Nh_Kg.Text = drLookup["Type_Name"].ToString();
            }
        }
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, null, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lblTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lblTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }
		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmKhoCT_KG"))
				e.Cancel = true;
		}


        #endregion

        //private void Page1_Click(object sender, EventArgs e)
        //{

        //}
    }
}