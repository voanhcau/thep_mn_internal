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

namespace RosyModule.Salary
{
	public partial class frmHieuQua_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmHieuQua_Edit()
		{
			InitializeComponent();

			this.txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			this.txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);

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
			if (txtMa_Bp.Text.Trim() != string.Empty)
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			else
				lbtTen_Bp.Text = string.Empty;

			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;
		}

		public bool FormCheckValid()
		{
			//if (txtTk.Text.Trim() == string.Empty)
			//{
			//    Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
			//    return false;
			//}

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

			if (drEdit.Table.Columns.Contains("Ten_Dt_CbNv"))
				drEdit["Ten_Dt_CbNv"] = lbtTen_Dt_CbNv.Text;

			if (drEdit.Table.Columns.Contains("Thang"))
				drEdit["Thang"] = ((DateTime)drEdit["Ngay_Ct"]).Month;

			if (!DataTool.SQLUpdate(this.enuNew_Edit, "R10HieuQua", ref drEdit))
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
