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
    public partial class frmDmVtPt_Edit : RosyList.frmEdit
    {

        #region Phuong thuc

		public frmDmVtPt_Edit()
		{
			InitializeComponent();

            txtMa_Nhom.Validating +=new CancelEventHandler(txtMa_Nhom_Validating);

			txtMa_Dv_Sd.Validating += new CancelEventHandler(txtMa_Dv_Sd_Validating);
			txtMa_Cum.Validating += new CancelEventHandler(txtMa_Cum_Validating);
			
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
			txtMa_Cum.Text = "";
			txtMa_Nhom.Text = "";
			txtMa_Tb_Nhom.Text = "";
			txtMa_Dv_Sd.Text = "";
			txtTen_Vt_Chuan.Text = "";
			txtMa_Tb.Text = "";

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Nhom.bUseAutoDropDown = true;
            txtMa_Nhom.strLookupKeyFilter = "TYPE = 'MA_NHOM'";

            txtMa_Dv_Sd.bUseAutoDropDown = true;
            txtMa_Dv_Sd.strLookupKeyFilter = "TYPE = 'MA_DV_SD'";

			

            
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Cum.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Cum") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;

            }
			if (txtThong_So_Kt.Text.Trim() == string.Empty)
			{
				Common.MsgOk("Yêu cầu nhập thông số kĩ thuật" + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

  

            return bvalid;
        }

	

		public override bool Save()
		{
			//Common.GatherMemvar(this, ref drEdit);

			//Kiem tra valid tren form
			if (!FormCheckValid())
				return false;

			//if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
			//    drEdit["Create_Log"] = Common.GetCurrent_Log();
			//else
			//    drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			////Luu xuong CSDL
			//if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMCUMTB", ref drEdit))
			//    return false;

			New_Ma_VTPT();

			return true;
		}

		#endregion

        #region Su kien

		void New_Ma_VTPT()
		{
			if (enuNew_Edit == enuEdit.New)
			{
				string Ma_Vt_Current = txtMa_Nhom.Text + txtMa_Dv_Sd.Text + txtMa_Cum.Text + txtMa_Tb.Text + "001";
				System.Collections.Hashtable htPara = new System.Collections.Hashtable();
				htPara["TABLENAME"] = "R81DMVT";
				htPara["COLUMNNAME"] = "MA_VT";
				htPara["CURRENTID"] = Ma_Vt_Current;
				htPara["KEY"] = "Ma_Vt LIKE '" + txtMa_Nhom.Text + txtMa_Dv_Sd.Text + txtMa_Cum.Text + txtMa_Tb.Text + "%'";

				string strMa_Vt_Tang = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
				drEdit["Ma_Vt"] = txtMa_Nhom.Text + txtMa_Dv_Sd.Text + txtMa_Cum.Text + txtMa_Tb.Text + strMa_Vt_Tang.Substring(8);
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
				txtMa_Tb.Text = string.Empty;
				lbtTen_Tb.Text = string.Empty;
			}
			else
			{
				txtMa_Tb_Nhom.Text = ((string)drLookup["Ma_Tb_Nhom"]).Trim();
				txtMa_Tb.Text = ((string)drLookup["Ma_Tb"]).Trim();
				txtTen_Vt_Chuan.Text = ((string)drLookup["Ten_Tb"]).Trim();
				//txtTen_Vt.Text = ((string)drLookup["Ten_Tb"]).Trim();
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
		void txtMa_Cum_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Cum.Text.Trim();
			bool bRequire = true;
			string strKeyFilter = "Nhom  = '" + txtMa_Dv_Sd.Text + "' OR Nhom = ''";
			DataRow drLookup = Lookup.ShowLookup("Ma_Cum", strValue, bRequire, strKeyFilter, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Cum.Text = string.Empty;
				lbtTen_Cum_Tb.Text = string.Empty;
			}
			else
			{
				txtMa_Cum.Text = ((string)drLookup["Ma_Cum"]).Trim();
				lbtTen_Cum_Tb.Text = ((string)drLookup["Ten_Cum"]).Trim();
			}

			//txtMa_Tb_Nhom.bUseAutoDropDown = true;
			////txtMa_Tb_Nhom.strLookupKeyFilter = "NHOM  = '" + txtMa_Nhom.Text + "'";
		}

		void txtMa_Dv_Sd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dv_Sd.Text.Trim();
			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "MA_DV_SD");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'MA_DV_SD'", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dv_Sd.Text = string.Empty;
				lbtTen_Dv_Sd.Text = string.Empty;
			}
			else
			{
				txtMa_Dv_Sd.Text = drLookup["Type_ID"].ToString();
				lbtTen_Dv_Sd.Text = drLookup["Type_Name"].ToString();
			}

			txtMa_Cum.bUseAutoDropDown = true;
			txtMa_Cum.strLookupKeyFilter = "NHOM = '" + txtMa_Dv_Sd.Text + "' OR NHOM = ''";
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
			}
		}
	
        #endregion

		protected override void OnShown(EventArgs e)
		{
			this.btgAccept.btAccept.Enabled = true;
		}
    }
}