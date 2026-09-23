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
    public partial class frmDmVtPtCt_Edit : RosyList.frmEdit
    {

        #region Phuong thuc

        string strMa_Nhom = string.Empty;

		public frmDmVtPtCt_Edit()
		{
			InitializeComponent();

            txtMa_Nhom.Validating +=new CancelEventHandler(txtMa_Nhom_Validating);

            //txtMa_Dv_Sd.Validating += new CancelEventHandler(txtMa_Dv_Sd_Validating);
            //txtMa_Cum.Validating += new CancelEventHandler(txtMa_Cum_Validating);
			
			txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Nh_Vt_Validating);
			txtMa_Tb_Nhom.Validating += new CancelEventHandler(txtMa_Tb_Nhom_Validating);
				
		}
		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			txtThong_So_Kt.Text = "";
			txtMa_Tb_Nha_Sx.Text = "";
			txtTen_Nha_Sx.Text = "";
            //txtMa_Cum.Text = "";
			txtMa_Nhom.Text = "";
			txtMa_Tb_Nhom.Text = "";
            //txtMa_Dv_Sd.Text = "";
			txtTen_Vt_Chuan.Text = "";
			txtMa_Tb_Nhom.Text = "";

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Nhom.bUseAutoDropDown = true;
            txtMa_Nhom.strLookupKeyFilter = "TYPE = 'MA_NHOM'";

          
           
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            

  

            return bvalid;
        }

	

		public override bool Save()
		{
			//Common.GatherMemvar(this, ref drEdit);

			//Kiem tra valid tren form
			if (!FormCheckValid())
				return false;

		

			New_Ma_VTPT();

			return true;
		}

		#endregion

        #region Su kien

		void New_Ma_VTPT()
		{
            if (enuNew_Edit == enuEdit.New)
            {
                string Ma_Vt_Current = txtMa_Tb_Nhom.Text + "0001";
                System.Collections.Hashtable htPara = new System.Collections.Hashtable();
                htPara["TABLENAME"] = "R81DMVT";
                htPara["COLUMNNAME"] = "MA_VT";
                htPara["CURRENTID"] = Ma_Vt_Current;
                htPara["KEY"] = "Ma_Vt LIKE '" + txtMa_Tb_Nhom.Text + "%'";

                string strMa_Vt_Tang = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                drEdit["Ma_Vt"] = txtMa_Tb_Nhom.Text + strMa_Vt_Tang.Substring(5);

                drEdit["Vat_Tu_Old"] = "";
                drEdit["Is_Hide"] = 0;
                
            }
		}

		void txtMa_Tb_Nhom_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Tb_Nhom.Text.Trim();
			bool bRequire = true;
			string strKeyFilter = "Nhom  = '" + txtMa_Nhom.Text + "'";

			DataRow drLookup = Lookup.ShowLookup("Ma_Tb_Nhom", strValue, bRequire, strKeyFilter, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Tb_Nhom.Text = string.Empty;
				lbtTen_Tb.Text = string.Empty;
			}
			else
			{
				txtMa_Tb_Nhom.Text = ((string)drLookup["Ma_Tb_Nhom"]).Trim();
				txtTen_Vt_Chuan.Text = ((string)drLookup["Ten_Tb"]).Trim();
                lbtTen_Tb.Text = ((string)drLookup["Ten_Tb"]).Trim();

			}
		}

		void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();

			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "", "Nh_Cuoi = 1");

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
        

		void txtMa_Nhom_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nhom.Text.Trim();
			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "MA_NHOM");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'MA_NHOM'", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nhom.Text = string.Empty;
				lbtTen_Nhom.Text = string.Empty;
			}
			else
			{
				txtMa_Nhom.Text = drLookup["Type_ID"].ToString();
				lbtTen_Nhom.Text = drLookup["Type_Name"].ToString();
                strMa_Nhom = drLookup["Type_ID"].ToString();
                
                txtMa_Tb_Nhom.bUseAutoDropDown = true;
                txtMa_Tb_Nhom.strLookupKeyFilter = "NHOM = '" + strMa_Nhom + "'";
			}
		}
	
        #endregion

		protected override void OnShown(EventArgs e)
		{
			this.btgAccept.btAccept.Enabled = true;
		}
    }
}