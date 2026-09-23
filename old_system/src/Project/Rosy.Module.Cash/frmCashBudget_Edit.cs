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

namespace RosyModule.Cash
{
	public partial class frmCashBudget_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmCashBudget_Edit()
		{
			InitializeComponent();

			txtMa_Tte.Validated += new EventHandler(txtMa_Tte_Validated);

			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			this.txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			this.txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			this.txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			this.txtTk.Validating += new CancelEventHandler(txtTk_Validating);

			numTien_Thu_Kh.Validating += new CancelEventHandler(numTien_Thu_Kh_Validating);
			numTien_Chi_Kh.Validating += new CancelEventHandler(numTien_Chi_Kh_Validating);
			numTien_Thu_Kh_Nt.Validating += new CancelEventHandler(numTien_Thu_Kh_Nt_Validating);
			numTien_Chi_Kh_Nt.Validating += new CancelEventHandler(numTien_Chi_Kh_Nt_Validating);

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
				drEdit["Tien_Thu_Kh"] = 0;
				drEdit["Tien_Chi_Kh"] = 0;
				drEdit["Tien_Thu_Kh_Nt"] = 0;
				drEdit["Tien_Chi_Kh_Nt"] = 0;
			}

			Common.ScaterMemvar(this, ref drEdit);


			BindingLanguage();
			LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
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

			if (txtTk.Text.Trim() != string.Empty)
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk.Text.Trim());
			else
				lbtTen_Tk.Text = string.Empty;
		}

		public bool FormCheckValid()
		{
			//if ((bool)drEdit["Tk_DThu"] && (txtMa_Dt.Text.Trim() == string.Empty))
			//{
			//    Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " + Languages.GetLanguage("Cannot_Empty"));
			//    return false;
			//}

			//bool Is_Check = false;

			//if (enuNew_Edit == enuEdit.Edit)
			//{
			//    if ((string)drEdit["Tk"] == (string)drEdit["Tk", DataRowVersion.Original] &&
			//        (string)drEdit["Ma_Dt"] == (string)drEdit["Ma_Dt", DataRowVersion.Original] &&
			//        (string)drEdit["Ma_Sp"] == (string)drEdit["Ma_Sp", DataRowVersion.Original])
			//        Is_Check = false;
			//    else
			//        Is_Check = true;
			//}

			//if (enuNew_Edit == enuEdit.New || Is_Check)
			//{
			//    if (DataTool.SQLCheckExist("R80CDK", new string[] { "Nam", "Tk", "Ma_Dt", "Ma_Sp", "Ma_DvCs" }, new object[] { Element.sysWorkingYear, txtTk.Text, txtMa_Dt.Text, txtMa_Sp.Text, Element.sysMa_DvCs }))
			//    {
			//        string strMsg = "Nam = {" + Element.sysWorkingYear + "}, Tk = {" + txtTk.Text + "}, Ma_Dt = {" + txtMa_Dt.Text + "}, Ma_Sp = {" + txtMa_Sp.Text + "}, Ma_DvCs = {" + Element.sysMa_DvCs + "}";
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

			if (!DataTool.SQLUpdate(this.enuNew_Edit, "R01CashBudget", ref drEdit))
				return false;

			return true;
		}

		private void Ma_Tte_Validating()
		{
			string strMa_Tte = txtMa_Tte.Text;

			if (strMa_Tte == Element.sysMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTy_Gia.ReadOnly = true;

				//this.pnlTien_No_Nt.Visible = false;
				//this.pnlTien_No.Visible = true;
				//this.pnlTien_No.Left = this.pnlTien_No_Nt.Left;
			}
			else
			{
				numTy_Gia.ReadOnly = false;

				if (txtMa_Tte.bTextChange)
				{
					Hashtable ht = new Hashtable();
					ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
					ht.Add("MA_TTE", strMa_Tte);

					numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
				}

				//this.pnlTien_No_Nt.Visible = true;
				//this.pnlTien_No.Visible = true;
				//this.pnlTien_No.Left = this.pnlTien_No_Nt.Right;
			}
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

		void txtMa_Tte_Validated(object sender, EventArgs e)
		{
			this.Ma_Tte_Validating();
		}		

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

		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "");

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
			}
		}

		void numTien_Thu_Kh_Validating(object sender, CancelEventArgs e)
		{
		}

		void numTien_Chi_Kh_Validating(object sender, CancelEventArgs e)
		{
		}

		void numTien_Thu_Kh_Nt_Validating(object sender, CancelEventArgs e)
		{
		}

		void numTien_Chi_Kh_Nt_Validating(object sender, CancelEventArgs e)
		{
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

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
				{
					this.dteNgay_Ct.Enabled = false;
					this.btgAccept.btAccept.Enabled = false;
				}
			}
		}
	}
}
