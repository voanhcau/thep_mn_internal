using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyModule.General
{
	public partial class frmBudgetDThu_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmBudgetDThu_Edit()
		{
			InitializeComponent();

			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			this.txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			this.txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			this.txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			this.txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);

			this.numSo_Luong_Kh01.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh02.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh03.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh04.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh05.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh06.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh07.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh08.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh09.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh10.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh11.Validated += new EventHandler(numSo_Luong_Kh_Validated);
			this.numSo_Luong_Kh12.Validated += new EventHandler(numSo_Luong_Kh_Validated);

			this.numGia_Kh01.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh01.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh02.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh03.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh04.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh05.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh06.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh07.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh08.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh09.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh10.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh11.Validated += new EventHandler(numGia_Kh_Validated);
			this.numGia_Kh12.Validated += new EventHandler(numGia_Kh_Validated);

			this.numTien_Kh01.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh02.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh03.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh04.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh05.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh06.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh07.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh08.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh09.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh10.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh11.Validated += new EventHandler(numTien_Kh_Validated);
			this.numTien_Kh12.Validated += new EventHandler(numTien_Kh_Validated);

			this.numGia2_Kh01.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh02.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh03.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh04.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh05.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh06.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh07.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh08.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh09.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh10.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh11.Validated += new EventHandler(numGia2_Kh_Validated);
			this.numGia2_Kh12.Validated += new EventHandler(numGia2_Kh_Validated);

			this.numTien2_Kh01.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh02.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh03.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh04.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh05.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh06.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh07.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh08.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh09.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh10.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh11.Validated += new EventHandler(numTien2_Kh_Validated);
			this.numTien2_Kh12.Validated += new EventHandler(numTien2_Kh_Validated);

			this.btDT_KH01.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH02.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH03.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH04.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH05.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH06.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH07.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH08.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH09.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH10.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH11.Click += new EventHandler(btDT_KH_Click);
			this.btDT_KH12.Click += new EventHandler(btDT_KH_Click);

			this.btGV_KH01.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH02.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH03.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH04.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH05.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH06.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH07.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH08.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH09.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH10.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH11.Click += new EventHandler(btGV_KH_Click);
			this.btGV_KH12.Click += new EventHandler(btGV_KH_Click);

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
				//drEdit["Tien_Kh"] = 0;
				//drEdit["Tien_Kh_Nt"] = 0;
			}

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtTk.Text.Trim() != string.Empty)
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk.Text.Trim());
			else
				lbtTen_Tk.Text = string.Empty;

			if (txtMa_Dt.Text.Trim() != string.Empty)
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			else
				lbtTen_Dt.Text = string.Empty;

			if (txtMa_Hd.Text.Trim() != string.Empty)
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			else
				lbtTen_Hd.Text = string.Empty;

			if (txtMa_Km.Text.Trim() != string.Empty)
				lbtTen_Km.Text = DataTool.SQLGetNameByCode("R81DmKm", "Ma_Km", "Ten_Km", txtMa_Km.Text.Trim());
			else
				lbtTen_Km.Text = string.Empty;

			if (txtMa_Bp.Text.Trim() != string.Empty)
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			else
				lbtTen_Bp.Text = string.Empty;

			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

			if (txtMa_Vt.Text.Trim() != string.Empty)
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
			else
				lbtTen_Vt.Text = string.Empty;
		}

		public bool FormCheckValid()
		{
			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			//bool Is_Check = false;

			//if (enuNew_Edit == enuEdit.Edit)
			//{
			//    if ((string)drEdit["Tk"] == (string)drEdit["Tk", DataRowVersion.Original] &&
			//        (string)drEdit["Ma_Dt"] == (string)drEdit["Ma_Dt", DataRowVersion.Original] &&
			//        (string)drEdit["Ma_Vt_Sp"] == (string)drEdit["Ma_Vt_Sp", DataRowVersion.Original])
			//        Is_Check = false;
			//    else
			//        Is_Check = true;
			//}

			//if (enuNew_Edit == enuEdit.New || Is_Check)
			//{
			//    if (DataTool.SQLCheckExist("R80SDK", new string[] { "Nam", "Tk", "Ma_Dt", "Ma_Vt_Sp", "Ma_DvCs" }, new object[] { Element.sysWorkingYear, txtTk.Text, txtMa_Dt.Text, txtMa_Vt_Sp.Text, Element.sysMa_DvCs }))
			//    {
			//        string strMsg = "Nam = {" + Element.sysWorkingYear + "}, Tk = {" + txtTk.Text + "}, Ma_Dt = {" + txtMa_Dt.Text + "}, Ma_Vt_Sp = {" + txtMa_Vt_Sp.Text + "}, Ma_DvCs = {" + Element.sysMa_DvCs + "}";
			//        strMsg += Element.sysLanguage == enuLanguageType.English ? " must be unique" : " phải duy nhất";

			//        Common.MsgCancel(strMsg);
			//        return false;
			//    }
			//}

			return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (drEdit.Table.Columns.Contains("Ten_Dt"))
				drEdit["Ten_Dt"] = lbtTen_Dt.Text;

			if (drEdit.Table.Columns.Contains("Thang"))
				drEdit["Thang"] = ((DateTime)drEdit["Ngay_Ct"]).Month;

			if (!DataTool.SQLUpdate(this.enuNew_Edit, "R80Budget", ref drEdit))
				return false;

			return true;
		}

		//private void Tinh_Tien()
		//{
		//    if (txtMa_Tte.Text == Element.sysMa_Tte)
		//    {
		//        numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
		//    }
		//    else
		//    {
		//        double dbTron_Tien = Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia"));

		//        if (Math.Abs(numTy_Gia.Value * numTien_No_Nt0.Value - numTien_No0.Value) > dbTron_Tien)
		//            numTien_No0.Value = Math.Round(numTien_No_Nt0.Value * numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);

		//        if (Math.Abs(numTy_Gia.Value * numTien_Tt_Nt0.Value - numTien_Tt0.Value) > dbTron_Tien)
		//            numTien_Tt0.Value = Math.Round(numTien_Tt_Nt0.Value * numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);

		//        numTien_No_Nt.Value = numTien_No_Nt0.Value - numTien_Tt_Nt0.Value;
		//        numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
		//    }
		//}

		#endregion

		#region Events

		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", "");

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

				if (txtMa_Hd.bTextChange)
				{
					txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
					lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text);
				}
			}
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

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

		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Km.Text = string.Empty;
				lbtTen_Km.Text = string.Empty;
			}
			else
			{
				txtMa_Km.Text = drLookup["Ma_Km"].ToString();
				lbtTen_Km.Text = drLookup["Ten_Km"].ToString();
			}
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
				lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
			}
		}

		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

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
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
			}
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "", "");

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

		//Nhập liệu So_Luong_Kh => Tính ra Doanh thu, Giá vốn kế hoạch
		void numSo_Luong_Kh_Validated(object sender, EventArgs e)
		{
			if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH01")
			{
				numTien_Kh01.Value = Math.Round(numSo_Luong_Kh01.Value * numGia_Kh01.Value, 2);
				numTien2_Kh01.Value = Math.Round(numSo_Luong_Kh01.Value * numGia2_Kh01.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH02")
			{
				numTien_Kh02.Value = Math.Round(numSo_Luong_Kh02.Value * numGia_Kh02.Value, 2);
				numTien2_Kh02.Value = Math.Round(numSo_Luong_Kh02.Value * numGia2_Kh02.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH03")
			{
				numTien_Kh03.Value = Math.Round(numSo_Luong_Kh03.Value * numGia_Kh03.Value, 2);
				numTien2_Kh03.Value = Math.Round(numSo_Luong_Kh03.Value * numGia2_Kh03.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH04")
			{
				numTien_Kh04.Value = Math.Round(numSo_Luong_Kh04.Value * numGia_Kh04.Value, 2);
				numTien2_Kh04.Value = Math.Round(numSo_Luong_Kh04.Value * numGia2_Kh04.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH05")
			{
				numTien_Kh05.Value = Math.Round(numSo_Luong_Kh05.Value * numGia_Kh05.Value, 2);
				numTien2_Kh05.Value = Math.Round(numSo_Luong_Kh05.Value * numGia2_Kh05.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH06")
			{
				numTien_Kh06.Value = Math.Round(numSo_Luong_Kh06.Value * numGia_Kh06.Value, 2);
				numTien2_Kh06.Value = Math.Round(numSo_Luong_Kh06.Value * numGia2_Kh06.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH07")
			{
				numTien_Kh07.Value = Math.Round(numSo_Luong_Kh07.Value * numGia_Kh07.Value, 2);
				numTien2_Kh07.Value = Math.Round(numSo_Luong_Kh07.Value * numGia2_Kh07.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH08")
			{
				numTien_Kh08.Value = Math.Round(numSo_Luong_Kh08.Value * numGia_Kh08.Value, 2);
				numTien2_Kh08.Value = Math.Round(numSo_Luong_Kh08.Value * numGia2_Kh08.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH09")
			{
				numTien_Kh09.Value = Math.Round(numSo_Luong_Kh09.Value * numGia_Kh09.Value, 2);
				numTien2_Kh09.Value = Math.Round(numSo_Luong_Kh09.Value * numGia2_Kh09.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH10")
			{
				numTien_Kh10.Value = Math.Round(numSo_Luong_Kh10.Value * numGia_Kh10.Value, 2);
				numTien2_Kh10.Value = Math.Round(numSo_Luong_Kh10.Value * numGia2_Kh10.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH11")
			{
				numTien_Kh11.Value = Math.Round(numSo_Luong_Kh11.Value * numGia_Kh11.Value, 2);
				numTien2_Kh11.Value = Math.Round(numSo_Luong_Kh11.Value * numGia2_Kh11.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "SO_LUONG_KH12")
			{
				numTien_Kh12.Value = Math.Round(numSo_Luong_Kh12.Value * numGia_Kh12.Value, 2);
				numTien2_Kh12.Value = Math.Round(numSo_Luong_Kh12.Value * numGia2_Kh12.Value, 2);
			}
		}

		//Nhập liệu Gia_Kh => Tính ra Giá vốn kế hoạch
		void numGia_Kh_Validated(object sender, EventArgs e)
		{
			if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH01")
			{
				numTien_Kh01.Value = Math.Round(numSo_Luong_Kh01.Value * numGia_Kh01.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH02")
			{
				numTien_Kh02.Value = Math.Round(numSo_Luong_Kh02.Value * numGia_Kh02.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH03")
			{
				numTien_Kh03.Value = Math.Round(numSo_Luong_Kh03.Value * numGia_Kh03.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH04")
			{
				numTien_Kh04.Value = Math.Round(numSo_Luong_Kh04.Value * numGia_Kh04.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH05")
			{
				numTien_Kh05.Value = Math.Round(numSo_Luong_Kh05.Value * numGia_Kh05.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH06")
			{
				numTien_Kh06.Value = Math.Round(numSo_Luong_Kh06.Value * numGia_Kh06.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH07")
			{
				numTien_Kh07.Value = Math.Round(numSo_Luong_Kh07.Value * numGia_Kh07.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH08")
			{
				numTien_Kh08.Value = Math.Round(numSo_Luong_Kh08.Value * numGia_Kh08.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH09")
			{
				numTien_Kh09.Value = Math.Round(numSo_Luong_Kh09.Value * numGia_Kh09.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH10")
			{
				numTien_Kh10.Value = Math.Round(numSo_Luong_Kh10.Value * numGia_Kh10.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH11")
			{
				numTien_Kh11.Value = Math.Round(numSo_Luong_Kh11.Value * numGia_Kh11.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA_KH12")
			{
				numTien_Kh12.Value = Math.Round(numSo_Luong_Kh12.Value * numGia_Kh12.Value, 2);
			}
		}

		//Nhập liệu tiền vốn kế hoạch => Tính ra đơn giá vốn kế hoạch
		void numTien_Kh_Validated(object sender, EventArgs e)
		{
			if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH01" && numSo_Luong_Kh01.Value != 0)
			{
				numGia_Kh01.Value = Math.Round(numTien_Kh01.Value / numSo_Luong_Kh01.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH02" && numSo_Luong_Kh02.Value != 0)
			{
				numGia_Kh02.Value = Math.Round(numTien_Kh02.Value / numSo_Luong_Kh02.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH03" && numSo_Luong_Kh03.Value != 0)
			{
				numGia_Kh03.Value = Math.Round(numTien_Kh03.Value / numSo_Luong_Kh03.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH04" && numSo_Luong_Kh04.Value != 0)
			{
				numGia_Kh04.Value = Math.Round(numTien_Kh04.Value / numSo_Luong_Kh04.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH05" && numSo_Luong_Kh05.Value != 0)
			{
				numGia_Kh05.Value = Math.Round(numTien_Kh05.Value / numSo_Luong_Kh05.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH06" && numSo_Luong_Kh06.Value != 0)
			{
				numGia_Kh06.Value = Math.Round(numTien_Kh06.Value / numSo_Luong_Kh06.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH07" && numSo_Luong_Kh07.Value != 0)
			{
				numGia_Kh07.Value = Math.Round(numTien_Kh07.Value / numSo_Luong_Kh07.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH08" && numSo_Luong_Kh08.Value != 0)
			{
				numGia_Kh08.Value = Math.Round(numTien_Kh08.Value / numSo_Luong_Kh08.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH09" && numSo_Luong_Kh09.Value != 0)
			{
				numGia_Kh09.Value = Math.Round(numTien_Kh09.Value / numSo_Luong_Kh09.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH10" && numSo_Luong_Kh10.Value != 0)
			{
				numGia_Kh10.Value = Math.Round(numTien_Kh10.Value / numSo_Luong_Kh10.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH11" && numSo_Luong_Kh11.Value != 0)
			{
				numGia_Kh11.Value = Math.Round(numTien_Kh11.Value / numSo_Luong_Kh11.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN_KH12" && numSo_Luong_Kh12.Value != 0)
			{
				numGia_Kh12.Value = Math.Round(numTien_Kh12.Value / numSo_Luong_Kh12.Value, 2);
			}
		}

		//Nhập liệu Gia2_Kh => Tính ra Doanh thu kế hoạch
		void numGia2_Kh_Validated(object sender, EventArgs e)
		{
			if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH01")
			{
				numTien2_Kh01.Value = Math.Round(numSo_Luong_Kh01.Value * numGia2_Kh01.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH02")
			{
				numTien2_Kh02.Value = Math.Round(numSo_Luong_Kh02.Value * numGia2_Kh02.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH03")
			{
				numTien2_Kh03.Value = Math.Round(numSo_Luong_Kh03.Value * numGia2_Kh03.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH04")
			{
				numTien2_Kh04.Value = Math.Round(numSo_Luong_Kh04.Value * numGia2_Kh04.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH05")
			{
				numTien2_Kh05.Value = Math.Round(numSo_Luong_Kh05.Value * numGia2_Kh05.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH06")
			{
				numTien2_Kh06.Value = Math.Round(numSo_Luong_Kh06.Value * numGia2_Kh06.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH07")
			{
				numTien2_Kh07.Value = Math.Round(numSo_Luong_Kh07.Value * numGia2_Kh07.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH08")
			{
				numTien2_Kh08.Value = Math.Round(numSo_Luong_Kh08.Value * numGia2_Kh08.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH09")
			{
				numTien2_Kh09.Value = Math.Round(numSo_Luong_Kh09.Value * numGia2_Kh09.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH10")
			{
				numTien2_Kh10.Value = Math.Round(numSo_Luong_Kh10.Value * numGia2_Kh10.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH11")
			{
				numTien2_Kh11.Value = Math.Round(numSo_Luong_Kh11.Value * numGia2_Kh11.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "GIA2_KH12")
			{
				numTien2_Kh12.Value = Math.Round(numSo_Luong_Kh12.Value * numGia2_Kh12.Value, 2);
			}
		}

		//Nhập liệu Tien2_Kh => Tính ra giá bán kế hoạch
		void numTien2_Kh_Validated(object sender, EventArgs e)
		{
			if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH01" && numSo_Luong_Kh01.Value != 0)
			{
				numGia2_Kh01.Value = Math.Round(numTien2_Kh01.Value / numSo_Luong_Kh01.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH02" && numSo_Luong_Kh02.Value != 0)
			{
				numGia2_Kh02.Value = Math.Round(numTien2_Kh02.Value / numSo_Luong_Kh02.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH03" && numSo_Luong_Kh03.Value != 0)
			{
				numGia2_Kh03.Value = Math.Round(numTien2_Kh03.Value / numSo_Luong_Kh03.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH04" && numSo_Luong_Kh04.Value != 0)
			{
				numGia2_Kh04.Value = Math.Round(numTien2_Kh04.Value / numSo_Luong_Kh04.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH05" && numSo_Luong_Kh05.Value != 0)
			{
				numGia2_Kh05.Value = Math.Round(numTien2_Kh05.Value / numSo_Luong_Kh05.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH06" && numSo_Luong_Kh06.Value != 0)
			{
				numGia2_Kh06.Value = Math.Round(numTien2_Kh06.Value / numSo_Luong_Kh06.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH07" && numSo_Luong_Kh07.Value != 0)
			{
				numGia2_Kh07.Value = Math.Round(numTien2_Kh07.Value / numSo_Luong_Kh07.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH08" && numSo_Luong_Kh08.Value != 0)
			{
				numGia2_Kh08.Value = Math.Round(numTien2_Kh08.Value / numSo_Luong_Kh08.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH09" && numSo_Luong_Kh09.Value != 0)
			{
				numGia2_Kh09.Value = Math.Round(numTien2_Kh09.Value / numSo_Luong_Kh09.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH10" && numSo_Luong_Kh10.Value != 0)
			{
				numGia2_Kh10.Value = Math.Round(numTien2_Kh10.Value / numSo_Luong_Kh10.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH11" && numSo_Luong_Kh11.Value != 0)
			{
				numGia2_Kh11.Value = Math.Round(numTien2_Kh11.Value / numSo_Luong_Kh11.Value, 2);
			}
			else if (((rsTextBoxNumber)sender).Name.Substring(3).ToUpper() == "TIEN2_KH12" && numSo_Luong_Kh12.Value != 0)
			{
				numGia2_Kh12.Value = Math.Round(numTien2_Kh12.Value / numSo_Luong_Kh12.Value, 2);
			}
		}

		void btDT_KH_Click(object sender, EventArgs e)
		{
			if (((Button)sender).Name.Substring(2) == "DT_KH01")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value = numSo_Luong_Kh08.Value = numSo_Luong_Kh07.Value = numSo_Luong_Kh06.Value = numSo_Luong_Kh05.Value = numSo_Luong_Kh04.Value = numSo_Luong_Kh03.Value = numSo_Luong_Kh02.Value = numSo_Luong_Kh01.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value = numGia2_Kh08.Value = numGia2_Kh07.Value = numGia2_Kh06.Value = numGia2_Kh05.Value = numGia2_Kh04.Value = numGia2_Kh03.Value = numGia2_Kh02.Value = numGia2_Kh01.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value = numTien2_Kh08.Value = numTien2_Kh07.Value = numTien2_Kh06.Value = numTien2_Kh05.Value = numTien2_Kh04.Value = numTien2_Kh03.Value = numTien2_Kh02.Value = numTien2_Kh01.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH02")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value = numSo_Luong_Kh08.Value = numSo_Luong_Kh07.Value = numSo_Luong_Kh06.Value = numSo_Luong_Kh05.Value = numSo_Luong_Kh04.Value = numSo_Luong_Kh03.Value = numSo_Luong_Kh02.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value = numGia2_Kh08.Value = numGia2_Kh07.Value = numGia2_Kh06.Value = numGia2_Kh05.Value = numGia2_Kh04.Value = numGia2_Kh03.Value = numGia2_Kh02.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value = numTien2_Kh08.Value = numTien2_Kh07.Value = numTien2_Kh06.Value = numTien2_Kh05.Value = numTien2_Kh04.Value = numTien2_Kh03.Value = numTien2_Kh02.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH03")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value = numSo_Luong_Kh08.Value = numSo_Luong_Kh07.Value = numSo_Luong_Kh06.Value = numSo_Luong_Kh05.Value = numSo_Luong_Kh04.Value = numSo_Luong_Kh03.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value = numGia2_Kh08.Value = numGia2_Kh07.Value = numGia2_Kh06.Value = numGia2_Kh05.Value = numGia2_Kh04.Value = numGia2_Kh03.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value = numTien2_Kh08.Value = numTien2_Kh07.Value = numTien2_Kh06.Value = numTien2_Kh05.Value = numTien2_Kh04.Value = numTien2_Kh03.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH04")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value = numSo_Luong_Kh08.Value = numSo_Luong_Kh07.Value = numSo_Luong_Kh06.Value = numSo_Luong_Kh05.Value = numSo_Luong_Kh04.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value = numGia2_Kh08.Value = numGia2_Kh07.Value = numGia2_Kh06.Value = numGia2_Kh05.Value = numGia2_Kh04.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value = numTien2_Kh08.Value = numTien2_Kh07.Value = numTien2_Kh06.Value = numTien2_Kh05.Value = numTien2_Kh04.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH05")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value = numSo_Luong_Kh08.Value = numSo_Luong_Kh07.Value = numSo_Luong_Kh06.Value = numSo_Luong_Kh05.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value = numGia2_Kh08.Value = numGia2_Kh07.Value = numGia2_Kh06.Value = numGia2_Kh05.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value = numTien2_Kh08.Value = numTien2_Kh07.Value = numTien2_Kh06.Value = numTien2_Kh05.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH06")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value = numSo_Luong_Kh08.Value = numSo_Luong_Kh07.Value = numSo_Luong_Kh06.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value = numGia2_Kh08.Value = numGia2_Kh07.Value = numGia2_Kh06.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value = numTien2_Kh08.Value = numTien2_Kh07.Value = numTien2_Kh06.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH07")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value = numSo_Luong_Kh08.Value = numSo_Luong_Kh07.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value = numGia2_Kh08.Value = numGia2_Kh07.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value = numTien2_Kh08.Value = numTien2_Kh07.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH08")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value = numSo_Luong_Kh08.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value = numGia2_Kh08.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value = numTien2_Kh08.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH09")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value = numSo_Luong_Kh09.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value = numGia2_Kh09.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value = numTien2_Kh09.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH10")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value = numSo_Luong_Kh10.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value = numGia2_Kh10.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value = numTien2_Kh10.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "DT_KH11")
			{
				numSo_Luong_Kh12.Value = numSo_Luong_Kh11.Value;
				numGia2_Kh12.Value = numGia2_Kh11.Value;
				numTien2_Kh12.Value = numTien2_Kh11.Value;
			}
		}

		void btGV_KH_Click(object sender, EventArgs e)
		{
			if (((Button)sender).Name.Substring(2) == "GV_KH01")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value = numGia_Kh08.Value = numGia_Kh07.Value = numGia_Kh06.Value = numGia_Kh05.Value = numGia_Kh04.Value = numGia_Kh03.Value = numGia_Kh02.Value = numGia_Kh01.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value = numTien_Kh04.Value = numTien_Kh03.Value = numTien_Kh02.Value = numTien_Kh01.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH02")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value = numGia_Kh08.Value = numGia_Kh07.Value = numGia_Kh06.Value = numGia_Kh05.Value = numGia_Kh04.Value = numGia_Kh03.Value = numGia_Kh02.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value = numTien_Kh04.Value = numTien_Kh03.Value = numTien_Kh02.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH03")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value = numGia_Kh08.Value = numGia_Kh07.Value = numGia_Kh06.Value = numGia_Kh05.Value = numGia_Kh04.Value = numGia_Kh03.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value = numTien_Kh04.Value = numTien_Kh03.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH04")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value = numGia_Kh08.Value = numGia_Kh07.Value = numGia_Kh06.Value = numGia_Kh05.Value = numGia_Kh04.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value = numTien_Kh04.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH05")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value = numGia_Kh08.Value = numGia_Kh07.Value = numGia_Kh06.Value = numGia_Kh05.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH06")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value = numGia_Kh08.Value = numGia_Kh07.Value = numGia_Kh06.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH07")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value = numGia_Kh08.Value = numGia_Kh07.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH08")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value = numGia_Kh08.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH09")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value = numGia_Kh09.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH10")
			{
				numGia_Kh12.Value = numGia_Kh11.Value = numGia_Kh10.Value;
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value;
			}
			else if (((Button)sender).Name.Substring(2) == "GV_KH11")
			{
				numGia_Kh12.Value = numGia_Kh11.Value;
				numTien_Kh12.Value = numTien_Kh11.Value;
			}
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//if (this.enuNew_Edit == enuEdit.Edit)
			//{
			//    if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
			//    {
			//        this.dteNgay_Ct.Enabled = false;
			//        this.btgAccept.btAccept.Enabled = false;
			//    }
			//}
		}
	}
}
