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
using RosySystem;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmDt_Chung_Edit : RosyList.frmEdit
	{
		DataRow drCurrent;

		#region Phuong thuc

		public frmDmDt_Chung_Edit()
		{
			InitializeComponent();

			txtMa_Dt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Dt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			btMa_Dt.Click += new EventHandler(btMa_Dt_Click);
			txtMa_Nh_Dt.Validating += new CancelEventHandler(txtMa_Nh_Dt_Validating);
		
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drCurrent)
		{
			this.drCurrent = drCurrent;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
			

			//Hải xử lý: Khi Edit, lấy dữ liệu từ SQL ra (không lấy từ C# giống trước kia)
			if (enuNew_Edit == enuEdit.Edit)
				this.drEdit = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
			else
			{
				this.drEdit = DataTool.SQLGetDataTable("R81DmDt", null, "0 = 1", "Ma_Dt").NewRow();
				Common.CopyDataRow(drCurrent, drEdit);
			}


			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

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
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
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

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMDT", ref drEdit))
				return false;

			Common.CopyDataRow(drEdit, drCurrent);

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_DT", drEdit);

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
			}
		}

		void btMa_Dt_Click(object sender, EventArgs e)
		{
			bool bRequire = true;
			string strFilter = string.Empty;
            strFilter = " Ma_Nh_Dt LIKE  '100' OR Ma_Nh_Dt LIKE  '110' OR Ma_Nh_Dt LIKE  '300' OR Ma_Nh_Dt LIKE  'NV' ";
			DataRow drLookup = Lookup.ShowMultiLookup("Ma_Dt", txtMa_Dt_Chung.Text, bRequire, strFilter, "");

			if (drLookup == null)
			{
				txtMa_Dt_Chung.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_Chung.Text = drLookup["MultiSelectValue"].ToString();
			}
		}

		#endregion
	}
}