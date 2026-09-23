using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
	public partial class frmSDHanTt_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmSDHanTt_Edit()
		{
			InitializeComponent();

			txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_HD.Validating += new CancelEventHandler(txtMa_Hd_Validating);

			numTien_No_Nt0.Validating += new CancelEventHandler(numTien_No_Nt0_Validating);
			numTien_Tt_Nt0.Validating += new CancelEventHandler(numTien_Tt_Nt0_Validating);

			numTien_Tt0.Validating += new CancelEventHandler(numTien_Tt0_Validating);
			numTien_No0.Validating += new CancelEventHandler(numTien_No0_Validating);

			txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
			numTy_Gia.Validating += new CancelEventHandler(numTy_Gia_Validating);
			numHan_Tt.Validated += new EventHandler(numHan_Tt_Validated);

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
				this.drEdit["Tien_No0"] = this.drEdit["Tien_Tt0"] = this.drEdit["Tien_No"] = this.drEdit["Tien_Tt"] = 0;
				this.drEdit["Tien_No_Nt0"] = this.drEdit["Tien_Tt_Nt0"] = this.drEdit["Tien_No_Nt"] = this.drEdit["Tien_Tt_Nt"] = 0;
			}

			Common.ScaterMemvar(this, ref drEdit);

			txtMa_Tte.bTextChange = numTy_Gia.bTextChange = false;

			this.LoadDicName();
			this.Ma_Tte_Validating();
			this.Han_Tt_Valid();

			this.ShowDialog();
		}

		public void LoadDicName()
		{
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			if (txtMa_HD.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_HD.Text.Trim());
			}
			else
				lbtTen_Hd.Text = string.Empty;

			if (txtTk.Text.Trim() != string.Empty)
			{
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk.Text.Trim());
			}
			else
				lbtTen_Tk.Text = string.Empty;
		}

		private void Ma_Tte_Validating()
		{
			string strMa_Tte = txtMa_Tte.Text;

			if (strMa_Tte == Element.sysMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTy_Gia.ReadOnly = true;

				this.pnlTien_No_Nt.Visible = false;
				this.pnlTien_No.Visible = true;
				this.pnlTien_No.Left = this.pnlTien_No_Nt.Left;
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

				this.pnlTien_No_Nt.Visible = true;
				this.pnlTien_No.Visible = true;
				this.pnlTien_No.Left = this.pnlTien_No_Nt.Right;
			}
		}

		private void Tinh_Tien()
		{
			if (txtMa_Tte.Text == Element.sysMa_Tte)
			{
				numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
				numTien_No_Nt.Value = numTien_No_Nt0.Value - numTien_Tt_Nt0.Value;
			}
			else
			{
				double dbTron_Tien = Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia"));

				if (Math.Abs(numTy_Gia.Value * numTien_No_Nt0.Value - numTien_No0.Value) > dbTron_Tien)
					numTien_No0.Value = Math.Round(numTien_No_Nt0.Value * numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);

				if (Math.Abs(numTy_Gia.Value * numTien_Tt_Nt0.Value - numTien_Tt0.Value) > dbTron_Tien)
					numTien_Tt0.Value = Math.Round(numTien_Tt_Nt0.Value * numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);

				numTien_No_Nt.Value = numTien_No_Nt0.Value - numTien_Tt_Nt0.Value;
				numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
			}
		}

		public bool FormCheckValid()
		{
			if (txtMa_Ct.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Ct") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
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

            
            drEdit["Nam"] = Element.sysWorkingYear;
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			if (this.enuNew_Edit == enuEdit.New)
			{
				drEdit["Stt"] = Common.GetNewStt("08", true);
				while (DataTool.SQLCheckExist("R80SDHanTt", "Stt", drEdit["Stt"]))
				{
					drEdit["Stt"] = Common.GetNewStt("08", true);
				}
			}

			if (txtMa_Tte.Text == Element.sysMa_Tte)
			{
				drEdit["Ty_Gia"] = 1;
				drEdit["Tien_No_Nt0"] = 0;
				drEdit["Tien_Tt_Nt0"] = 0;
				drEdit["Tien_No_Nt"] = 0;
			}

			if (!DataTool.SQLUpdate(this.enuNew_Edit, "R80SdHanTt", ref drEdit))
				return false;

			return true;
		}

		void Han_Tt_Valid()
		{
			if (numHan_Tt.Value == 0) //Hạn thanh toán = 0, xem như là Ứng trước
			{
				numTien_No0.Enabled = false;
				numTien_No_Nt0.Enabled = false;
			}
			else
			{
				numTien_No0.Enabled = true;
				numTien_No_Nt0.Enabled = true;
			}
		}

		#endregion

		#region Events

		void txtMa_Tte_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Validating();
		}

		void numTy_Gia_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_No_Nt0_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_Tt_Nt0_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_Tt0_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_No0_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

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

		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_HD.Text.Trim();
			bool bRequire = false	;

			DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_HD.Text = string.Empty;
				lbtTen_Hd.Text = string.Empty;
			}
			else
			{
				txtMa_HD.Text = drLookup["Ma_Hd"].ToString();
				lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();
			}
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
			}
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

		void numHan_Tt_Validated(object sender, EventArgs e)
		{
			this.Han_Tt_Valid();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//Kiểm tra khóa số dư
			string strSQLExec =
				"SELECT TOP 1 Locked_SdHanTt FROM R00Nam " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				this.btgAccept.btAccept.Enabled = false;
			}
		}
	}
}
