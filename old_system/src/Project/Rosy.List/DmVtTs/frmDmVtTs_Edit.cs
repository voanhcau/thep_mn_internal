using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmVtTs_Edit : RosyList.frmEdit
	{		
		#region Phuong thuc
		string Ma_Nh_Dt = "";
		string strLoai_Nh_Vt = "";

		public frmDmVtTs_Edit()
		{
			InitializeComponent();

			txtMa_Vt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Vt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Nh_Vt_Validating);
			txtTk_Vtu.Validating += new CancelEventHandler(txtTk_Vtu_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
			this.Ma_Nh_Dt = drEdit["Ma_Nh_Vt"].ToString();

			strLoai_Nh_Vt = DataTool.SQLGetNameByCode("R81DmNhVt", "Ma_Nh_Vt", "Loai_Nh_Vt", Ma_Nh_Dt);

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Nh_Vt.Text.Trim() != string.Empty)
				lbtTen_Nh_Vt.Text = DataTool.SQLGetNameByCode("R81DmNhVt", "Ma_Nh_Vt", "Ten_Nh_Vt", txtMa_Nh_Vt.Text.Trim());
			else
				lbtTen_Nh_Vt.Text = string.Empty;

			
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Sp") + " " +
								Languages.GetLanguage("Not_Null"));

				return false;
			}			

			if (txtTen_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Sp") + " " +
							Languages.GetLanguage("Not_Null"));

				return false;
			}

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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmVt", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_VT", drEdit);

			return true;
		}
		#endregion 

		#region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmVt"))
				e.Cancel = true;
		}

		private void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();
			bool bRequire = true;
			Ma_Nh_Dt = Ma_Nh_Dt.Substring(0, 2);

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("bIs_Vt_Sp", false);

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "Loai_Nh_Vt IN ('" + strLoai_Nh_Vt + "')", "Nh_Cuoi = 1", htField);
		//	DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "Loai_Nh_Vt IN ('TS')", "Nh_Cuoi = 1", htField);

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

		void txtTk_Vtu_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Vtu.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, null, "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Vtu.Text = string.Empty;
				lbtTen_Tk_Vtu.Text = string.Empty;
			}
			else
			{
				txtTk_Vtu.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Vtu.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}

		#endregion
	
	}
}