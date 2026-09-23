using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyModule.General
{
	public partial class frmSDK_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmSDK_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			this.txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			this.txtTk.LostFocus += new EventHandler(txtTk_LostFocus);

			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			this.txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);

			numDu_No.Validating += new CancelEventHandler(numDu_No_Validating);
			numDu_Co.Validating += new CancelEventHandler(numDu_Co_Validating);
			numDu_No_Nt.Validating += new CancelEventHandler(numDu_No_Nt_Validating);
			numDu_Co_Nt.Validating += new CancelEventHandler(numDu_Co_Nt_Validating);	
		
		}

		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;
			string strKeyValid = "";

			DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", strKeyValid);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Hd.Text = string.Empty;
				lbtTen_Hd.Text = string.Empty;
			}
			else
			{
				txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
				lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();
			}
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			if (enuNew_Edit == enuEdit.New)
			{
				drEdit["Du_No"] = 0;
				drEdit["Du_Co"] = 0;
				drEdit["Du_No_Nt"] = 0;
				drEdit["Du_Co_Nt"] = 0;
				drEdit["Du_No0"] = 0;
				drEdit["Du_Co0"] = 0;
				drEdit["Du_No_Nt0"] = 0;
				drEdit["Du_Co_Nt0"] = 0;
				drEdit["Nam"] = Element.sysWorkingYear;
				drEdit["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, Element.sysTh_Bd_Ht, 1);
			}

			Common.ScaterMemvar(this, ref drEdit);

			this.txtTk.Focus();

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtTk.Text.Trim() != string.Empty)
			{
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk.Text.Trim());
			}
			else
				lbtTen_Tk.Text = string.Empty;

			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			//txtMa_Hd
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			}
			else
				lbtTen_Hd.Text = string.Empty;

			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
			{
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			}
			else
				lbtTen_Vt_Sp.Text = string.Empty;
		}

		public bool FormCheckValid()
		{
			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if ((bool)drEdit["Tk_Dt"] && (txtMa_Dt.Text.Trim() == string.Empty))
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if ((bool)drEdit["Tk_Sp"] && (txtMa_Vt_Sp.Text.Trim() == string.Empty))
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt_Sp") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			bool Is_Check = false;

			if (enuNew_Edit == enuEdit.Edit)
			{
				if ((string)drEdit["Tk"] == (string)drEdit["Tk", DataRowVersion.Original] &&
					(string)drEdit["Ma_Dt"] == (string)drEdit["Ma_Dt", DataRowVersion.Original] &&
					(string)drEdit["Ma_Vt_Sp"] == (string)drEdit["Ma_Vt_Sp", DataRowVersion.Original])
					Is_Check = false;
				else
					Is_Check = true;
			}

			if (enuNew_Edit == enuEdit.New || Is_Check)
			{
				if (DataTool.SQLCheckExist("R80SDK", new string[] { "Nam", "Tk", "Ma_Dt", "Ma_Vt_Sp", "Ma_DvCs" }, new object[] { Element.sysWorkingYear, txtTk.Text, txtMa_Dt.Text, txtMa_Vt_Sp.Text, Element.sysMa_DvCs }))
				{
					string strMsg = "Nam = {" + Element.sysWorkingYear + "}, Tk = {" + txtTk.Text + "}, Ma_Dt = {" + txtMa_Dt.Text + "}, Ma_Vt_Sp = {" + txtMa_Vt_Sp.Text + "}, Ma_DvCs = {" + Element.sysMa_DvCs + "}";
					strMsg += Element.sysLanguage == enuLanguageType.English ? " must be unique" : " phải duy nhất";

					Common.MsgCancel(strMsg);
					return false;
				}
			}

			this.Tk_Valid();

			return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Kiem tra cac du lieu can thiet
			if (!(bool)drEdit["Tk_Dt"])
				drEdit["Ma_Dt"] = string.Empty;

			if (!(bool)drEdit["Tk_Sp"])
				drEdit["Ma_Vt_Sp"] = string.Empty;

			if (drEdit.Table.Columns.Contains("Ten_Tk"))
				drEdit["Ten_Tk"] = lbtTen_Tk.Text;

			if (drEdit.Table.Columns.Contains("Ten_Dt"))
				drEdit["Ten_Dt"] = lbtTen_Dt.Text;

			if (drEdit.Table.Columns.Contains("Ten_Vt_Sp"))
				drEdit["Ten_Vt_Sp"] = lbtTen_Vt_Sp.Text;

			drEdit["Have_Child"] = 0;
			drEdit["Nam"] = Element.sysWorkingYear;
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Xac dinh Stt
			if (this.enuNew_Edit == enuEdit.New)
			{
				drEdit["Stt"] = Common.GetNewStt("08", true);
				while (DataTool.SQLCheckExist("R80SDK", "Stt", drEdit["Stt"]))
				{
					drEdit["Stt"] = Common.GetNewStt("08", true);
				}
			}				

			//Luu xuong CSDL
			return DataTool.SQLUpdate(enuNew_Edit, "R80SDK", ref drEdit);
		}

		private void Tk_Valid()
		{
			if (drEdit == null)
				return;

			if (drEdit["Tk_Dt"] != DBNull.Value)
			{
				txtMa_Dt.Enabled = (bool)drEdit["Tk_Dt"];
			}

			if (drEdit["Tk_Sp"] != DBNull.Value)
			{
				txtMa_Vt_Sp.Enabled = (bool)drEdit["Tk_Sp"];
			}
		}

		#endregion

		#region Events

		void txtTk_LostFocus(object sender, EventArgs e)
		{
			this.Tk_Valid();

			if (txtMa_Dt.Enabled)
				txtMa_Dt.Focus();

			else if (txtMa_Vt_Sp.Enabled)
				txtMa_Vt_Sp.Focus();
		}

		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, null, "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTen_Tk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = drLookup["Tk"].ToString();
				lbtTen_Tk.Text = drLookup["Ten_Tk"].ToString();

				drEdit["Tk_Dt"] = drLookup["Tk_Dt"];
				drEdit["Tk_Sp"] = drLookup["Tk_Sp"];
			}
			
			this.Tk_Valid();
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, null, null);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();
			}
		}

		void numDu_No_Validating(object sender, CancelEventArgs e)
		{
			if (numDu_No0.Value == 0)
				numDu_No0.Value = numDu_No.Value;
		}

		void numDu_Co_Validating(object sender, CancelEventArgs e)
		{
			if (numDu_Co0.Value == 0)
				numDu_Co0.Value = numDu_Co.Value;
		}

		void numDu_No_Nt_Validating(object sender, CancelEventArgs e)
		{
			if (numDu_No_Nt0.Value == 0)
				numDu_No_Nt0.Value = numDu_No_Nt.Value;
		}

		void numDu_Co_Nt_Validating(object sender, CancelEventArgs e)
		{
			if (numDu_Co_Nt0.Value == 0)
				numDu_Co_Nt0.Value = numDu_Co_Nt.Value;
		}


		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//Kiểm tra khóa số dư
			string strSQLExec =
				"SELECT TOP 1 Locked_Sdk FROM R00Nam " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				this.btgAccept.btAccept.Enabled = false;
			}
		}
	}
}
