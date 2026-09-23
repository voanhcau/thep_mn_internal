using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmNvu_Edit : RosyList.frmEdit
	{
		#region Phuong thuc

		public frmDmNvu_Edit()
		{
			InitializeComponent();

			btMa_Ct.Click += new EventHandler(Button_Click);
			btTk_No.Click += new EventHandler(Button_Click);
			btTk_Co.Click += new EventHandler(Button_Click);
			btTk_No2.Click += new EventHandler(Button_Click);
			btTk_Co2.Click += new EventHandler(Button_Click);
			btMa_Dt.Click += new EventHandler(Button_Click);
			btMa_Bp.Click += new EventHandler(Button_Click);
			btMa_Km.Click += new EventHandler(Button_Click);
			btMa_Vt_Sp.Click += new EventHandler(Button_Click);
			btMa_Hd.Click += new EventHandler(Button_Click);
			btMa_Thue.Click += new EventHandler(Button_Click);
			btMa_Kho.Click += new EventHandler(Button_Click);
			btMa_Dt_CbNv.Click += new EventHandler(Button_Click);

            txtMa_Nvu_HD.Validating += new CancelEventHandler(txtMa_Nvu_HD_Validating);
            txtMa_NVu_PX.Validating += new CancelEventHandler(txtMa_NVu_PX_Validating);
			txtMa_Nvu.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Nvu.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
		}

       

		string TableName (string strColName)
		{
			switch (strColName.ToUpper())
			{
				case "MA_CT":
					return "R00DmCt";
				case "TK_NO":
					return "R81DmTk";
				case "TK_CO":
					return "R81DmTk";
				case "MA_DT":
					return "R81DmDt";
				case "MA_BP":
					return "R81DmBp";
				case "MA_KM":
					return "R81DmKm";
				case "MA_VT_SP":
					return "R81DmVt";
				case "MA_HD":
					return "R81DmHd";
				case "MA_THUE":
					return "R81DmThue";
				case "MA_KHO":
					return "R81DmKho";
				case "MA_DT_CBNV":
					return "R81DmDt";
			}

			return "";
		}

		string AliasName(string strColName)
		{
			switch (strColName.ToUpper())
			{
				case "MA_CT":
					return "DMCT";
				case "TK_NO":
					return "DMTK";
				case "TK_CO":
					return "DMTK";
				case "MA_DT":
					return "DMDT";
				case "MA_BP":
					return "DMBP";
				case "MA_KM":
					return "DMKM";
				case "MA_VT_SP":
					return "DMVTSP";
				case "MA_HD":
					return "DMHD";
				case "MA_THUE":
					return "DMTHUE";
				case "MA_KHO":
					return "DMKHO";
				case "MA_DT_CBNV":
					return "DMDT";
			}

			return "";
		}

		string ColLookup(string strColName)
		{
			switch (strColName.ToUpper())
			{
				case "MA_CT":
					return "MA_CT";
				case "TK_NO":
					return "TK";
				case "TK_CO":
					return "TK";
				case "MA_DT":
					return "MA_DT";
				case "MA_BP":
					return "MA_BP";
				case "MA_KM":
					return "MA_KM";
				case "MA_VT_SP":
					return "MA_VT";
				case "MA_HD":
					return "MA_HD";
				case "MA_THUE":
					return "MA_THUE";
				case "MA_KHO":
					return "MA_KHO";
				case "MA_DT_CBNV":
					return "MA_DT";
			}

			return "";
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.BindingLanguage();
			this.LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//Ma_Ct
			if (txtMa_Ct.Text != string.Empty)
				lbtTen_Ct.Text = DataTool.SQLGetNameByCode("R00DmCt", "Ma_Ct", "Ten_Ct", txtMa_Ct.Text);
			else
				lbtTen_Ct.Text = string.Empty;

			//Tk_No
			if (txtTk_No.Text != string.Empty)
				lbtTen_Tk_No.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_No.Text);
			else
				lbtTen_Tk_No.Text = string.Empty;

			//Tk_Co
			if (txtTk_Co.Text != string.Empty)
				lbtTen_Tk_Co.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_Co.Text);
			else
				lbtTen_Tk_Co.Text = string.Empty;

			//Tk_No2
			if (txtTk_No2.Text != string.Empty)
				lbtTen_Tk_No2.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_No2.Text);
			else
				lbtTen_Tk_No2.Text = string.Empty;

			//Tk_Co
			if (txtTk_Co2.Text != string.Empty)
				lbtTen_Tk_Co2.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_Co2.Text);
			else
				lbtTen_Tk_Co2.Text = string.Empty;

			//Ma_Dt
			if (txtMa_Dt.Text != string.Empty)
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text);
			else
				lbtTen_Dt.Text = string.Empty;

			//Ma_Bp
			if (txtMa_Bp.Text != string.Empty)
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text);
			else
				lbtTen_Bp.Text = string.Empty;

			//Ma_Km
			if (txtMa_Km.Text != string.Empty)
				lbtTen_Km.Text = DataTool.SQLGetNameByCode("R81DmKm", "Ma_Km", "Ten_Km", txtMa_Km.Text);
			else
				lbtTen_Km.Text = string.Empty;

			//Ma_Sp
			if (txtMa_Vt_Sp.Text != string.Empty)
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text);
			else
				lbtTen_Vt_Sp.Text = string.Empty;

			//Ma_Hd
			if (txtMa_Hd.Text != string.Empty)
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text);
			else
				lbtTen_Hd.Text = string.Empty;

			//Ma_Thue
			if (txtMa_Thue.Text != string.Empty)
				lbtTen_Thue.Text = DataTool.SQLGetNameByCode("R81DmThue", "Ma_Thue", "Ten_Thue", txtMa_Thue.Text);
			else
				lbtTen_Thue.Text = string.Empty;

			//Ma_Kho
			if (txtMa_Kho.Text != string.Empty)
				lbtTen_Kho.Text = DataTool.SQLGetNameByCode("R81DmKho", "Ma_Kho", "Ten_Kho", txtMa_Kho.Text);
			else
				lbtTen_Kho.Text = string.Empty;

			//Ma_Dt_CbNv
			if (txtMa_Dt_CbNv.Text != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text);
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

            //Ma_nvu_PX
            if (txtMa_NVu_PX.Text != string.Empty)
                lblTen_NVu_PX.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_NVu_PX.Text);
            else
                lblTen_NVu_PX.Text = string.Empty;

            //Ma_nvu_PX
            if (txtMa_Nvu_HD.Text != string.Empty)
                lblTen_NVu_HD.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu_HD.Text);
            else
                lblTen_NVu_HD.Text = string.Empty;
			
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;

			if (txtMa_Nvu.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Nvu") + " " + Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (txtTen_Nvu.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Nvu") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Ct.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Ct") + " " + Languages.GetLanguage("Not_Null"));

				return false;
			}

			return bvalid;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmNvu", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Ma_Nvu", drEdit);

			return true;
		}

		#endregion

		#region Su kien

		void Button_Click(object sender, EventArgs e)
		{
			TextBox txtCurrent = null;
			string strTextBoxName = "txt" + ((Button)sender).Name.Substring(2);
			string strColName = ((Button)sender).Name.Substring(2);

			//Kiểm tra tồn tại Control
			if ((((Button)sender).Parent).Controls.ContainsKey(strTextBoxName))
				txtCurrent = ((TextBox)(((Button)sender).Parent).Controls[strTextBoxName]);

			if (txtCurrent == null)
				return;

			string strTable = TableName(strColName);
			string strAlias = AliasName(strColName);
			bool bRequire = true;
			string strFilter = string.Empty;

			if (strColName.ToUpper() == "MA_DT_CBNV")
				strFilter = "Ma_Nh_Dt IN (SELECT Ma_Nh_Dt FROM R81DmNhDt WHERE Loai_Nh_Dt IN ('NV'))";
			else if (strColName.ToUpper() == "MA_VT_SP")
				strFilter = "Ma_Nh_Vt IN (SELECT Ma_Nh_Vt FROM R81DmNhVt WHERE Loai_Nh_Vt IN ('SP'))";

			DataRow drLookup = Lookup.ShowMultiLookup(ColLookup(strColName), txtCurrent.Text, bRequire, strFilter, "");

			//if (!frmLookup.bIsEnter) //Hải chưa xử lý
			//    return;

			if (drLookup == null)
			{
				txtCurrent.Text = string.Empty;
			}
			else
			{
				txtCurrent.Text = drLookup["MultiSelectValue"].ToString();
			}
		}
        void txtMa_NVu_PX_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_NVu_PX.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, "", "");

            if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
            {
                txtMa_NVu_PX.Text = string.Empty;
                lblTen_NVu_PX.Text = string.Empty;
            }
            else
            {
                txtMa_NVu_PX.Text = drLookup["Ma_Nvu"].ToString();
                lblTen_NVu_PX.Text = drLookup["Ten_Nvu"].ToString();
            }
        }

        void txtMa_Nvu_HD_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nvu_HD.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, "", "");

            if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
            {
                txtMa_Nvu_HD.Text = string.Empty;
                lblTen_NVu_HD.Text = string.Empty;
            }
            else
            {
                txtMa_Nvu_HD.Text = drLookup["Ma_Nvu"].ToString();
                lblTen_NVu_HD.Text = drLookup["Ten_Nvu"].ToString();
            }
        }
		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmNvu"))
				e.Cancel = true;
		}

		#endregion
	}
}