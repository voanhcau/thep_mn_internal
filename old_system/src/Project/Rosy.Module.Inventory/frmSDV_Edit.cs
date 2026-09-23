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

namespace RosyModule.Inventory
{
	public partial class frmSDV_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmSDV_Edit()
		{
			InitializeComponent();

			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			txtMa_Kho.LostFocus += new EventHandler(txtMa_Kho_LostFocus);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

			numTon_Dau.Validating += new CancelEventHandler(numTon_Dau_Validating);

			numGia.Validating += new CancelEventHandler(numGia_Validating);
			numDu_Dau.Validating += new CancelEventHandler(numDu_Dau_Validating);

			numGia_Nt.Validating += new CancelEventHandler(numGia_Nt_Validating);
			numDu_Dau_Nt.Validating += new CancelEventHandler(numDu_Dau_Nt_Validating);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			if (enuNew_Edit == enuEdit.New)
			{
				drEdit["Ton_Dau"] = 0;
				drEdit["Du_Dau"] = 0;
				drEdit["Du_Dau_Nt"] = 0;
				drEdit["Nam"] = Element.sysWorkingYear;
				drEdit["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, Element.sysTh_Bd_Ht, 1);
			}

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Kho.Text.Trim() != string.Empty)
			{
				lbtTen_Kho.Text = DataTool.SQLGetNameByCode("R81DMKHO", "Ma_Kho", "Ten_Kho", txtMa_Kho.Text.Trim());
			}
			else
				lbtTen_Kho.Text = string.Empty;

			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
				DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", txtMa_Vt.Text.Trim());

				if (drDmVt != null)
				{
					lbtTen_Vt.Text = (string)drDmVt["Ten_Vt"];
					lbtDvt.Text = "/" + (string)drDmVt["Dvt"];
				}
			}
			else
			{
				lbtTen_Vt.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
		}

		public bool FormCheckValid()
		{
			if (txtMa_Kho.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Kho") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Date") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (enuNew_Edit == enuEdit.New)
			{
				if (DataTool.SQLCheckExist("R80SDV", new string[] { "Nam", "Ngay_Ct", "Ma_Kho", "Ma_Vt", "Ma_DvCs" }, new object[] { Element.sysWorkingYear, Library.StrToDate(dteNgay_Ct.Text), txtMa_Kho.Text, txtMa_Vt.Text, Element.sysMa_DvCs }))
				{
					string strMsg = "Ngay_Ct = {" + dteNgay_Ct.Text + "}, Ma_Kho = {" + txtMa_Kho.Text + "}, Ma_Vt = {" + txtMa_Vt.Text + "}, Ma_DvCs = {" + Element.sysMa_DvCs + "}";
					strMsg += Element.sysLanguage == enuLanguageType.English ? " already exist, do you want to add more?" : " đã tồn tại, Bạn có muốn thêm mới nữa không?";

					if (!Common.MsgYes_No(strMsg))
						return false;
				}
			}

			if (Library.StrToDate(dteNgay_Ct.Text) > Common.GetDate(Element.sysWorkingYear, 1, 1))
			{
				Common.MsgCancel("Ngày chứng từ phải nhỏ hơn [" + Common.GetDate(Element.sysWorkingYear, 1, 1).ToString() + "]");
				return false;
			}

			return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (drEdit.Table.Columns.Contains("Ten_Vt"))
				drEdit["Ten_Vt"] = lbtTen_Vt.Text;

			//Kiem tra cac du lieu can thiet
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Xac dinh Stt
			if (this.enuNew_Edit == enuEdit.New)
			{
				drEdit["Stt"] = Common.GetNewStt("08", true);
				while (DataTool.SQLCheckExist("R80SDV", "Stt", drEdit["Stt"]))
				{
					drEdit["Stt"] = Common.GetNewStt("08", true);
				}
			}

			//Luu xuong CSDL
			return DataTool.SQLUpdate(enuNew_Edit, "R80SDV", ref drEdit);
		}

		#endregion

		#region Events

		private void Ma_Kho_Valid()
		{
			if (drEdit == null)
				return;

			string strMa_Kho = txtMa_Kho.Text;

			if (strMa_Kho == string.Empty)
				return;

			DataRow drDmKho = DataTool.SQLGetDataRowByID("R81DMKHO", "Ma_Kho", strMa_Kho);

			if (drDmKho == null)
				return;
		}

		void txtMa_Kho_LostFocus(object sender, EventArgs e)
		{
			Ma_Kho_Valid();			
		}

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}
		}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
				lbtDvt.Text = "/" + drLookup["Dvt"].ToString();
			}
		}

		void numTon_Dau_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia = numGia.Value;
			double dbDu_Dau = numDu_Dau.Value;

			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (Math.Abs(dbTon_Dau * dbGia - dbDu_Dau) >= dbTronTien)
			{
				dbDu_Dau = Math.Round(dbTon_Dau * dbGia, 0, MidpointRounding.AwayFromZero);
				numDu_Dau.Value = dbDu_Dau;
			}

			if (dbTon_Dau == 0)
				numDu_Dau.Value = 0;
		}

		void numGia_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia = numGia.Value;
			double dbDu_Dau = numDu_Dau.Value;

			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (Math.Abs(dbTon_Dau * dbGia - dbDu_Dau) >= dbTronTien)
			{
				dbDu_Dau = Math.Round(dbTon_Dau * dbGia, 0, MidpointRounding.AwayFromZero);
				numDu_Dau.Value = dbDu_Dau;
			}

			if (dbTon_Dau == 0)
				numDu_Dau.Value = 0;
		}

		void numDu_Dau_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia = numGia.Value;
			double dbDu_Dau = numDu_Dau.Value;
			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (dbGia == 0 && dbTon_Dau == 0)
				return;

			if (dbGia == 0 && dbTon_Dau != 0)
				numGia.Value = Math.Round(dbDu_Dau / dbTon_Dau, 2, MidpointRounding.AwayFromZero);

			else if (Math.Abs(dbTon_Dau * dbGia - dbDu_Dau) >= dbTronTien)
				numDu_Dau.Value = Math.Round(dbTon_Dau * dbGia, 0, MidpointRounding.AwayFromZero);

		}

		void numGia_Nt_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia_Nt = numGia_Nt.Value;
			double dbDu_Dau_Nt = numDu_Dau_Nt.Value;

			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (Math.Abs(dbTon_Dau * dbGia_Nt - dbDu_Dau_Nt) >= dbTronTien)
			{
				dbDu_Dau_Nt = Math.Round(dbTon_Dau * dbGia_Nt, MidpointRounding.AwayFromZero);
				numDu_Dau_Nt.Value = dbDu_Dau_Nt;
			}

			if (dbTon_Dau == 0)
				numDu_Dau_Nt.Value = 0;
		}

		void numDu_Dau_Nt_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia_Nt = numGia_Nt.Value;
			double dbDu_Dau_Nt = numDu_Dau_Nt.Value;
			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (dbGia_Nt == 0 && dbTon_Dau == 0)
				return;

			if (dbGia_Nt == 0 && dbTon_Dau != 0)
				numGia_Nt.Value = Math.Round(dbDu_Dau_Nt / dbTon_Dau, 2, MidpointRounding.AwayFromZero);

			else if (Math.Abs(dbTon_Dau * dbGia_Nt - dbDu_Dau_Nt) >= dbTronTien)
				numDu_Dau_Nt.Value = Math.Round(dbTon_Dau * dbGia_Nt, 0, MidpointRounding.AwayFromZero);

		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
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
				"SELECT TOP 1 Locked_Sdv FROM R00Nam " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				Common.MsgCancel(Languages.GetLanguage("DATA_LOCKED"));
				this.btgAccept.btAccept.Enabled = false;
			}
		}
	}
}
