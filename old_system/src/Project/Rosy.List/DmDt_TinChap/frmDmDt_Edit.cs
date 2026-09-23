using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Element;
using RosySystem;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;

namespace RosyList
{
	public partial class frmDmDt_Edit : RosyList.frmEdit
	{
		DataRow drCurrent;
		string strMa_Dt = string.Empty;
		#region Phuong thuc

		public frmDmDt_Edit()
		{
			InitializeComponent();

			txtMa_Dt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Dt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtMa_So_Thue.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtMa_Nh_Dt.Validating += new CancelEventHandler(txtMa_Nh_Dt_Validating);
			//txtMa_Kv.Validating += new CancelEventHandler(txtMa_Kv_Validating);
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			//txtMa_Dt_Gia.Validating += new CancelEventHandler(txtMa_Dt_Gia_Validating);
            txtTk_Cn.Validating += new CancelEventHandler(txtTk_Cn_Validating);
            txtChi_Nhanh_Nh.Validating += new CancelEventHandler(txtChi_Nhanh_Nh_Validating);
            txtQuoc_Gia.Validating += TxtQuoc_Gia_Validating;
		}

        

        public override void Load(enuEdit enuNew_Edit, DataRow drCurrent)
		{
			this.drCurrent = drCurrent;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
			

			//Hải xử lý: Khi Edit, lấy dữ liệu từ SQL ra (không lấy từ C# giống trước kia)
			if (enuNew_Edit == enuEdit.Edit)
			{
				strMa_Dt = drCurrent["Ma_Dt"].ToString();
				this.drEdit = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
				//KIỂM TRA MÃ DT CÓ PS CHƯA
				if(!Common.CheckPermission("IS_TP_KTTC", enuPermission_Type.Allow_Access))
                {
					//check đã phát sinh dữ liệu thì không xóa
					Hashtable ht = new Hashtable();
					ht.Add("OBJECT", "Ma_Dt");
					ht.Add("MA", drCurrent["Ma_Dt"].ToString());
					if (SQLExec.ExecuteReturnDt("sp_CheckExistsMa", ht, CommandType.StoredProcedure).Rows.Count > 0)
					{
						txtMa_Dt.Enabled = false; txtTen_Dt.Enabled = false;
					}
				}
				
			}
			else
			{
				this.drEdit = DataTool.SQLGetDataTable("R81DmDt", null, "0 = 1", "Ma_Dt").NewRow();
				drEdit["Ma_Nh_Dt"] = drCurrent["Ma_Nh_Dt"];
				//Common.CopyDataRow(drCurrent, drEdit);
			}

			//if (enuNew_Edit == enuEdit.New && drEdit.Table.Columns.Contains("Tien_No_Max"))
			//	drEdit["Tien_No_Max"] = 0;

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (Common.InlistLike(drEdit["Ma_Nh_Dt"].ToString(), "100,110,300"))
				{
					System.Collections.Hashtable htPara = new System.Collections.Hashtable();
					htPara["MA_DT"] = Parameters.GetParaValue("MA_DT_TANG").ToString();
					drEdit["Ma_Dt"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewDmDtMin", htPara, CommandType.StoredProcedure);
				}
				else
                {
					System.Collections.Hashtable htPara = new System.Collections.Hashtable();
					htPara["TABLENAME"] = "R81DMDT";
					htPara["COLUMNNAME"] = "MA_DT";
					htPara["CURRENTID"] = drEdit["Ma_Dt"].ToString();

					if (Common.InlistLike(drEdit["Ma_Nh_Dt"].ToString(), "100,110,300"))
						htPara["KEY"] = "Ma_Dt LIKE '" + drEdit["Ma_Dt"].ToString().Substring(0, 2) + "%'";
					else
						htPara["KEY"] = "Ma_Nh_Dt LIKE '" + drEdit["Ma_Nh_Dt"].ToString() + "%'";

					drEdit["Ma_Dt"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
				}
				
                drEdit["Ma_Tap_Doan"] = string.Empty;
				drEdit["Ma_Nh_Dt"] = string.Empty;

				//if (drEdit["Ma_Nh_Dt"].ToString() == "300")
				//{ 
				//	drEdit["Ma_So_Thue"] = SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetMSTNN()").ToString();
				//	txtMa_So_Thue.ReadOnly = true;
				//}
				//else
				//	drEdit["Ma_So_Thue"] = "";
			}

            if (Common.CheckPermission("IS_EDIT_HD", enuPermission_Type.Allow_New))
                chkLocked.Visible = true;
            else
                chkLocked.Visible = false;


			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
			txtTen_Dt.Focus();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Nh_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Dt.Text = DataTool.SQLGetNameByCode("R81DMNHDT", "Ma_Nh_Dt", "Ten_Nh_Dt", txtMa_Nh_Dt.Text.Trim());
			}
			else
				lbtTen_Nh_Dt.Text = string.Empty;

			//if (txtMa_Kv.Text.Trim() != string.Empty)
			//{
			//	lbtTen_Kv.Text = DataTool.SQLGetNameByCode("R81DMKV", "Ma_Kv", "Ten_Kv", txtMa_Kv.Text.Trim());
			//}
			//else
			//	lbtTen_Dt_CbNv.Text = string.Empty;

			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

			//if (txtMa_Dt_Gia.Text.Trim() != string.Empty)
			//{
			//	lbtTen_Dt_Gia.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_Gia.Text.Trim());
			//}
			//else
			//	lbtTen_Dt_Gia.Text = string.Empty;

            if (txtTk_Cn.Text.Trim() != string.Empty)
            {
                lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_Cn.Text.Trim());
            }
            else
                lbtTen_Tk.Text = string.Empty;
            if (txtChi_Nhanh_Nh.Text.Trim() != string.Empty)
            {
                DataTable dtChi_Nhanh_Nh = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMTYPE WHERE TYPE = 'NGAN_HANG' AND Type_ID = '" + txtChi_Nhanh_Nh.Text.Trim() + "'");
                if(dtChi_Nhanh_Nh.Rows.Count>0)
                    lblChi_Nhanh_Nh.Text = dtChi_Nhanh_Nh.Rows[0]["Type_Name"].ToString();
            }
            else
                lblChi_Nhanh_Nh.Text = string.Empty;
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Nh_Dt.Text == "NV")
				return true;

			if (txtMa_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}			

			if (txtTen_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ten_Dt") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Nh_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Nh_Dt") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (txtDia_Chi.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Dia_Chi") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtMa_Dt_CbNv.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_Dt_CbNv") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtMa_So_Thue.Text.Trim() == string.Empty && Common.Inlist(txtMa_Nh_Dt.Text, (string)RosySystem.Library.Parameters.GetParaValue("NOTNULL_MST_DMDT")))
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_So_Thue") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
			if (txtMa_Dt.Text.Trim() != string.Empty && txtMa_Dt.Text.Length != 7)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " chiều dài mã đối tượng phải bằng 7 ký tự");
				return false;
			}
			//kiểm tra trùng mã số thuế
			if (//enuNew_Edit != enuEdit.Edit && 
				(int)SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R81DMDT WHERE Ma_Dt <> '"+txtMa_Dt.Text+"' AND Ma_So_Thue = '" + txtMa_So_Thue.Text + "' AND Ma_So_Thue <> ''") > 0 
					&& Common.Inlist(txtMa_Nh_Dt.Text, (string)RosySystem.Library.Parameters.GetParaValue("NOTNULL_MST_DMDT")))
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_So_Thue") + " đã tồn tại. Vui lòng kiểm tra lại");
                return false;
            }
			if (//enuNew_Edit != enuEdit.Edit && 
				(int)SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R81DMDT WHERE Ma_Dt <> '" + txtMa_Dt.Text + "' AND Ten_Dt = N'" + txtTen_Dt.Text.Trim() + "' AND Ten_Dt <> ''") > 0
					&& Common.Inlist(txtMa_Nh_Dt.Text, (string)RosySystem.Library.Parameters.GetParaValue("NOTNULL_MST_DMDT")))
			{
				Common.MsgCancel(Languages.GetLanguage("Ten_Dt") + " đã tồn tại. Vui lòng kiểm tra lại");
				return false;
			}
			//kiễm tra quy tắc của MST
			if (enuNew_Edit == enuEdit.Edit || enuNew_Edit != enuEdit.Copy)
            {
				if(txtMa_Nh_Dt.Text == "100" && (txtMa_So_Thue.Text != string.Empty && (txtMa_So_Thue.Text.Length != 10 && txtMa_So_Thue.Text.Length != 12 && txtMa_So_Thue.Text.Length != 14)))
                {
					Common.MsgOk("Mã số thuế chưa hợp lệ!!!");
					return false;
                }

            }
			return bvalid;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (drEdit["Ma_Nh_Dt"].ToString() == "300" && drEdit["Ma_So_Thue"].ToString() == "")
			{
				drEdit["Ma_So_Thue"] = SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetMSTNN()").ToString();
			}
		

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
			{ 
				drEdit["Create_Log"] = Common.GetCurrent_Log();
				drEdit["LastModify_Log"] = string.Empty;
			}
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMDT", ref drEdit))
				return false;

			Common.CopyDataRow(drEdit, drCurrent);

			//Doi ma
			if(strMa_Dt != txtMa_Dt.Text && this.enuNew_Edit == enuEdit.Edit)
            {
				if ((Element.sysIs_Admin || Element.sysUser_Id == "BANGNH"))
					DataTool.SQLChangeID("MA_DT", drEdit);
			}
			

			return true;
		}

		#endregion 

		#region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmDt"))
				e.Cancel = true;
		}

		void txtMa_Nh_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Dt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Dt", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Dt.Text = string.Empty;
				lbtTen_Nh_Dt.Text = string.Empty;
			}
			else
			{

				txtMa_Nh_Dt.Text = ((string)drLookup["Ma_Nh_Dt"]).Trim();
				lbtTen_Nh_Dt.Text = ((string)drLookup["Ten_Nh_Dt"]).Trim();

				if (txtMa_Nh_Dt.Text == "300")
				{
					drEdit["Ma_So_Thue"] = SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetMSTNN()").ToString();
					txtMa_So_Thue.Visible = false;
				}
			}
		}

		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = ((string)drLookup["Ma_Dt"]).Trim();
				lbtTen_Dt_CbNv.Text = ((string)drLookup["Ten_Dt"]).Trim();
			}
		}

		//void txtMa_Kv_Validating(object sender, CancelEventArgs e)
		//{
		//	string strValue = txtMa_Kv.Text.Trim();
		//	bool bRequire = false;

		//	DataRow drLookup = Lookup.ShowLookup("Ma_Kv", strValue, bRequire, "", "");
		//	//Rosy.Lists.frmDmKv frmLookup = new Rosy.Lists.frmDmKv();
		//	//DataRow drLookup = Lookup.ShowLookup1(frmLookup, "R81DmKv", "Ma_Kv", strValue, bRequire, "", "");

		//	if (bRequire && drLookup == null)
		//		e.Cancel = true;

		//	if (drLookup == null)
		//	{
		//		txtMa_Kv.Text = string.Empty;
		//		lbtTen_Kv.Text = string.Empty;
		//	}
		//	else
		//	{
		//		txtMa_Kv.Text = ((string)drLookup["Ma_Kv"]).Trim();
		//		lbtTen_Kv.Text = ((string)drLookup["Ten_Kv"]).Trim();
		//	}
		//}
        void txtTk_Cn_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Cn.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, null, "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_Cn.Text = string.Empty;
                lbtTen_Tk.Text = string.Empty;
            }
            else
            {
                txtTk_Cn.Text = ((string)drLookup["Tk"]).Trim();
                lbtTen_Tk.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }
        }
        void txtChi_Nhanh_Nh_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtChi_Nhanh_Nh.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "HT_GN");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'NGAN_HANG'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtChi_Nhanh_Nh.Text = string.Empty;
                lblChi_Nhanh_Nh.Text = string.Empty;
            }
            else
            {
                txtChi_Nhanh_Nh.Text = drLookup["Type_ID"].ToString();
                lblChi_Nhanh_Nh.Text = drLookup["Type_Name"].ToString();
            }
        }
        private void TxtQuoc_Gia_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtQuoc_Gia.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Quoc_Gia", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtQuoc_Gia.Text = string.Empty;


            }
            else
            {
                txtQuoc_Gia.Text = drLookup["Quoc_Gia"].ToString();


            }
        }
        //void txtMa_Dt_Gia_Validating(object sender, CancelEventArgs e)
        //{
        //	string strValue = txtMa_Dt_Gia.Text.Trim();
        //	bool bRequire = false;

        //	DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

        //	if (bRequire && drLookup == null)
        //		e.Cancel = true;

        //	if (drLookup == null)
        //	{
        //		txtMa_Dt_Gia.Text = string.Empty;
        //		lbtTen_Dt_Gia.Text = string.Empty;
        //	}
        //	else
        //	{
        //		txtMa_Dt_Gia.Text = ((string)drLookup["Ma_Dt"]).Trim();
        //		lbtTen_Dt_Gia.Text = ((string)drLookup["Ten_Dt"]).Trim();
        //	}
        //}

        #endregion
    }
}