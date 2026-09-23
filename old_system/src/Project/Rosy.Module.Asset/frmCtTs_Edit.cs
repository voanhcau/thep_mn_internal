using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;
using RosyList;
using RosyModule;

namespace RosyModule.Asset
{
	public partial class frmCtTs_Edit : RosySystem.Customize.frmEdit
	{
		#region Contructor

		DataRow drDmNvu;
		string strMa_Nvu = "";

		public frmCtTs_Edit()
		{
			InitializeComponent();

			txtMa_Tte.TextChanged += new EventHandler(txtMa_Tte_TextChanged);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Nvon.Validating += new CancelEventHandler(txtMa_Nv_Validating);
			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtTk_No.Validating += new CancelEventHandler(txtTk_No_Validating);
			txtTk_Co.Validating += new CancelEventHandler(txtTk_Co_Validating);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			txtMa_Vt_Ts.Validating += new CancelEventHandler(txtMa_Vt_Ts_Validating);
			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			txtTrang_Thai_Ts.Validating += new CancelEventHandler(txtTrang_Thai_Ts_Validating);

			chkTinh_Kh.CheckedChanged += new EventHandler(chkTinh_Kh_CheckedChanged);

			numTien_NG_Nt.Validating += new CancelEventHandler(numTien_NG_Nt_Validating);
			numTien_HM_Nt.Validating += new CancelEventHandler(numTien_Hao_Mon_Validating);
			numTien_CL_Nt.Validating += new CancelEventHandler(numTien_Con_Lai_Validating);

			btInherit.Click += new EventHandler(btInherit_Click);
		}

		

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;

			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.Init();
			this.LoadDicName();
			this.BindingLanguage();

			this.ShowDialog();
		}

		#endregion

		#region Phuong thuc

		private void Init()
		{
			this.Ma_Tte_Show();

			if (enuNew_Edit == enuEdit.Edit && drEdit["Stt_Org"].ToString() != "")
				this.txtInherit.Text = SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Ct) + ':' + MAX(So_Ct) FROM R80PH WHERE Stt = '" + drEdit["Stt_Org"].ToString() + "'").ToString();
			//khoa tk_No tk_co khi sua the TS
			if (enuNew_Edit == enuEdit.Edit)
			{
				txtTk_No.Enabled = false;
                //txtTk_Co.Enabled = false;
			}
		}

		private void Ma_Tte_Show()
		{
			if (this.txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
			{
				this.numTien_HM.Visible = false;
				this.numTien_NG.Visible = false;

				this.numTien_CL.Visible = false;
			}
			else
			{
				this.numTien_HM.Visible = true;
				this.numTien_NG.Visible = true;
				this.numTien_CL.Visible = true;
			}
		}

		private void LoadDicName()
		{
			lbtTen_Nvu.Text = (txtMa_Nvu.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim()));

			lbtTen_NVon.Text = (txtMa_Nvon.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmType", "Type_ID", "Type_Name", txtMa_Nvon.Text.Trim(), "TYPE = 'MA_NVON'"));

			lbtTrang_Thai_Ts.Text = (txtTrang_Thai_Ts.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmType", "Type_ID", "Type_Name", txtTrang_Thai_Ts.Text.Trim(), "TYPE = 'TRANG_THAI_TS'"));

			lbtTen_Vt_Ts.Text = (txtMa_Vt_Ts.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Ts.Text.Trim()));

			lbtTen_Vt.Text = (txtMa_Vt_Px.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Px.Text.Trim()));

			lbtTen_Vt_Sp.Text = (txtMa_Vt_Sp.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim()));

			lbtTen_Bp.Text = (txtMa_Bp.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim()));

			lbtTen_Km.Text = (txtMa_Km.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmKm", "Ma_Km", "Ten_Km", txtMa_Km.Text.Trim()));

			lbtTen_Tk_No.Text = (txtTk_No.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_No.Text.Trim()));

			lbtTen_Tk_Co.Text = (txtTk_Co.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_Co.Text.Trim()));
		}

		private void Tinh_Tien()
		{
			if (numTy_Gia.Value == 0)
				numTy_Gia.Value = 1;

			this.numTien_NG.Value = Math.Round(this.numTien_NG_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
			this.numTien_HM.Value = Math.Round(this.numTien_HM_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
			this.numTien_CL.Value = Math.Round(this.numTien_CL_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
		}

		private bool FormCheckValid()
		{
			if (dteNgay_Ct.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Ct") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Nvu.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Nvu") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Vt_Ts.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Vt_Ts") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (chkTinh_Kh.Checked)
			{
				if (dteNgay_Bd_Kh.IsNull)
				{
					Common.MsgOk(Languages.GetLanguage("Ngay_Bd_Kh") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}

				//if (numSo_Thang_Kh.Value == 0)
				//{
				//    Common.MsgOk(Languages.GetLanguage("So_Thang_Kh") + " " + Languages.GetLanguage("Cannot_Empty"));
				//    return false;
				//}

				if (txtTk_No.Text == string.Empty)
				{
					Common.MsgOk(Languages.GetLanguage("Tk_No") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}
				if (txtTk_Co.Text == string.Empty)
				{
					Common.MsgOk(Languages.GetLanguage("Tk_Co") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}
			}

			if (txtDien_Giai.Text == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Dien_Giai") + " " + Languages.GetLanguage("Cannot_Empty"));

				return false;
			}
			if (Convert.ToDouble(numTien_NG_Nt.Value) - Convert.ToDouble(numTien_HM_Nt.Value) != Convert.ToDouble(numTien_CL_Nt.Value))
			{
				Common.MsgOk("Tiền nguyên giá trừ hao mòn khác tiền còn lại. Không cho phép lưu!!!");

				return false;
			}
			return true;
		}

		private bool Save()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct.Text)))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return false;
			}   

			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			////Xac dinh Stt
			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
			{
				string strStt = Common.GetNewStt("06", true);

				while (DataTool.SQLCheckExist("R06CtTs", "Stt", strStt))
				{
					strStt = Common.GetNewStt("06", true);
				}

				drEdit["Stt"] = strStt;
			}

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R06CtTs", ref drEdit))
				return false;

			//Doi Ma_Vt_Ts
			if (this.enuNew_Edit == enuEdit.Edit && drEdit.HasVersion(DataRowVersion.Original) && drEdit["Ma_Vt_Ts"] != drEdit["Ma_Vt_Ts", DataRowVersion.Original])
			{
				string strSQL = @"
							UPDATE R06CtTsHM SET Ma_Vt_Ts = '" + drEdit["Ma_Vt_Ts"].ToString() + @"' WHERE Stt = '" + drEdit["Stt"].ToString() + @"' 
							UPDATE R06CtTsTT SET Ma_Vt_Ts = '" + drEdit["Ma_Vt_Ts"].ToString() + @"' WHERE Stt = '" + drEdit["Stt"].ToString() + @"' 
							UPDATE R06CtTsDC SET Ma_Vt_Ts = '" + drEdit["Ma_Vt_Ts"].ToString() + @"' WHERE Stt = '" + drEdit["Stt"].ToString() + @"'";

				SQLExec.Execute(strSQL);
			}

			return true;
		}

		private void InheritAsset_SetData(frmInheritVoucher frmInherit)
		{
			dteNgay_Ct.Text = Library.DateToStr((DateTime)frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ngay_Ct"]);
			txtSo_Ct.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Ct"].ToString();
			//txtLoai_Nhom.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Hd"].ToString();
			//txtMa_Dt.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Dt"].ToString();
			//txtOng_Ba.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ong_Ba"].ToString();
			//txtDia_Chi.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Dia_Chi"].ToString();
			//txtDien_Giai.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Dien_Giai"].ToString();
			if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Vt"))
				txtDien_Giai.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Vt"].ToString());
			else
				txtDien_Giai.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Dien_Giai"].ToString();

			if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Vt"))
				txtMa_Vt_Ts.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Vt"].ToString();

			if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Vt"))
				txtMa_Vt_Px.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Vt"].ToString();

			if (frmInherit.dtInheritVoucher.Columns.Contains("So_Luong"))
				numSo_Luong.Value = Common.SumDCValue(frmInherit.dtInheritVoucher, "So_Luong", "Chon = true");

			if (frmInherit.dtInheritVoucher.Columns.Contains("Tien_Nt"))
				numTien_NG_Nt.Value = Common.SumDCValue(frmInherit.dtInheritVoucher, "Tien_Nt", "Chon = true");

			if (frmInherit.dtInheritVoucher.Columns.Contains("Tien"))
				numTien_NG.Value = Common.SumDCValue(frmInherit.dtInheritVoucher, "Tien", "Chon = true");

			if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Bp"))
				txtMa_Bp.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Bp"].ToString();

            if (frmInherit.dtInheritVoucher.Columns.Contains("Dien_Giai"))
                txtDien_Giai.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Dien_Giai"].ToString();

			//if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Km") )
			//    txtMa_Km.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Km"].ToString();

			if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Vt_Sp"))
				txtMa_Vt_Sp.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Vt_Sp"].ToString();

			//Ma_TTe, Ty_Gia
			if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Tte"))
				txtMa_Tte.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Tte"].ToString();

            if (frmInherit.dtInheritVoucher.Columns.Contains("Tk_No"))
                txtTk_Co.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Tk_No"].ToString();

			if (txtMa_Tte.Text == Element.sysMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTien_NG_Nt.Value = numTien_NG.Value;
			}
			else
			{
				numTy_Gia.Value = (numTien_NG.Value / numTien_NG_Nt.Value);
			}

			//Tien_HM
			numTien_HM.Value = numTien_HM_Nt.Value = 0;

			//Tien_CL
			numTien_CL.Value = numTien_NG.Value;
			numTien_CL_Nt.Value = numTien_NG_Nt.Value;

			txtInherit.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Ct"].ToString() + ":" + frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Ct"].ToString();
			drEdit["Stt_Org"] = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Stt"];

			this.LoadDicName();
		}

		#endregion

		#region Su kien

		void txtMa_Tte_TextChanged(object sender, EventArgs e)
		{
			this.Ma_Tte_Show();
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
			isAccept = false;
			this.Close();
		}

		void txtMa_Nv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvon.Text.Trim();
			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "MA_NVON");
			DataRow drLookup = Lookup.ShowLookup("Ma_NVon", strValue, bRequire, "TYPE = 'MA_NVON'", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nvon.Text = string.Empty;
				lbtTen_NVon.Text = string.Empty;
			}
			else
			{
				txtMa_Nvon.Text = ((string)drLookup["Type_ID"]).Trim();
				lbtTen_NVon.Text = ((string)drLookup["Type_Name"]).Trim();
			}
		}

		void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvu.Text.Trim();
			bool bRequire = true;
			string strFilter = "(CHARINDEX('" + txtMa_Ct.Text + "', Ma_Ct, 0) > 0 OR Ma_Ct = '*')";
			string strValid = "Ma_Ct <> ''";

			DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter, strValid);

			if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
			{
				e.Cancel = true;
				return;
			}

			drDmNvu = drLookup;

			txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
			lbtTen_Nvu.Text = drLookup["Ten_Nvu"].ToString();

			this.drDmNvu = drLookup;
		}

		void txtMa_Vt_Ts_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Ts.Text.Trim();
			bool bRequire = true;

			DataRow drLookup;

			System.Collections.Hashtable htPara = new System.Collections.Hashtable();
			if (drEdit["Ma_Ct"].ToString() == "TS")
				htPara.Add("strLoai_Nh_Vt", "TS");
			else
				htPara.Add("strLoai_Nh_Vt", "CC");

			drLookup = Lookup.ShowLookup("Ma_Vt_TS", strValue, bRequire, "", "", htPara);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Ts.Text = string.Empty;
				lbtTen_Vt_Ts.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Ts.Text = ((string)drLookup["Ma_Vt"]).Trim();
				lbtTen_Vt_Ts.Text = ((string)drLookup["Ten_Vt"]).Trim();
			}
		}

		//void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		//{
		//    string strValue = txtMa_Dt.Text.Trim();
		//    bool bRequire = false;
		//    string strFilter = "";

		//    DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

		//    if (bRequire && drLookup == null)
		//        e.Cancel = true;

		//    if (drLookup == null)
		//    {
		//        txtMa_Dt.Text = string.Empty;
		//        lbtTen_Dt.Text = string.Empty;
		//    }
		//    else
		//    {
		//        txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
		//        lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();

		//        if (txtMa_Dt.bTextChange)
		//        {
		//            txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
		//            txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();
		//        }
		//    }
		//}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTen_Bp.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}
		}

		void txtTk_No_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_No.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_No.Text = string.Empty;
				lbtTen_Tk_No.Text = string.Empty;
			}
			else
			{
				txtTk_No.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_No.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}

		void txtTk_Co_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Co.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Co.Text = string.Empty;
				lbtTen_Tk_Co.Text = string.Empty;
			}
			else
			{
				txtTk_Co.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Co.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}

		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Km.Text = string.Empty;
				lbtTen_Km.Text = string.Empty;
			}
			else
			{
				txtMa_Km.Text = ((string)drLookup["Ma_Km"]).Trim();
				lbtTen_Km.Text = ((string)drLookup["Ten_Km"]).Trim();
			}
		}

		void txtTrang_Thai_Ts_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTrang_Thai_Ts.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "TRANG_THAI_TS");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'TRANG_THAI_TS'", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTrang_Thai_Ts.Text = string.Empty;
				lbtTrang_Thai_Ts.Text = string.Empty;
			}
			else
			{
				txtTrang_Thai_Ts.Text = drLookup["Type_ID"].ToString();
				lbtTrang_Thai_Ts.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = ((string)drLookup["Ma_Vt"]).Trim();
				lbtTen_Vt_Sp.Text = ((string)drLookup["Ten_Vt"]).Trim();
			}
		}

		void chkTinh_Kh_CheckedChanged(object sender, EventArgs e)
		{
			grbTinh_Kh.Enabled = chkTinh_Kh.Checked;
		}

		void numTien_NG_Nt_Validating(object sender, CancelEventArgs e)
		{
			numTien_CL_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;

			this.Tinh_Tien();
		}

		void numTien_Con_Lai_Validating(object sender, CancelEventArgs e)
		{
			if (numTien_NG_Nt.Value < numTien_CL_Nt.Value)
			{
				Common.MsgCancel("Tiền nguyên giá nhỏ hơn tiền còn lại");
				e.Cancel = true;
				return;
			}
			else
			{
				numTien_HM_Nt.Value = numTien_NG_Nt.Value - numTien_CL_Nt.Value;
			}

			this.Tinh_Tien();
		}

		void numTien_Hao_Mon_Validating(object sender, CancelEventArgs e)
		{
			if (numTien_NG_Nt.Value < numTien_HM_Nt.Value)
			{
				Common.MsgCancel("Tiền nguyên giá nhỏ hơn tiền còn lại");
				e.Cancel = true;
				return;
			}
			else
			{
				numTien_CL_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;
			}

			this.Tinh_Tien();
		}

		void btInherit_Click(object sender, EventArgs e)
		{
			frmInheritVoucher frm = new frmInheritVoucher();
			frm.Load(this.drEdit);

			if (frm.Is_Accept)
			{
				this.InheritAsset_SetData(frm);
			}
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

					return;
				}
			}
		}
	}
}