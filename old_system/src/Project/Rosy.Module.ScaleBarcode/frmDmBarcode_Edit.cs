using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmDmBarcode_Edit : RosySystem.Customize.frmEdit
	{
		public bool bPrint = false;
		private DateTime dteNgay_Nhap;
		private double dbSo_Ca = 0;
		private double dbBarem_Standard = 0;
		private string strLoai = string.Empty;
		private string strXuong = string.Empty;
		public frmDmBarcode_Edit()
		{
			InitializeComponent();
			this.InitDevice();

			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			numNum_Lot_Concat2.ValueChanged+=new EventHandler(numNum_Lot_Concat2_ValueChanged);
			numNum_Bars.Validating += new CancelEventHandler(numNum_Bars_Validating);
			txtMa_Ca.Validating += new CancelEventHandler(txtMa_Ca_Validating);
			btSaveAndPrint.Click += new EventHandler(btSaveAndPrint_Click);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		private void InitDevice()
		{
			DataRow drEquipment = DataTool.SQLGetDataRowByID("R81EquipmentInfo", "Host_IP", MachineInfo.GetHostIP());
			if (drEquipment != null)
			{
				Variables.strPrint_Barcode = (string)drEquipment["Print_Barcode"];
				Variables.strPrint_Report = (string)drEquipment["Print_Report"];
				Variables.strPrint_Eticket = (string)drEquipment["Print_Eticket"];
			}
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			this.FillData();
			numNum_Last.Value = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMCA","Ma_Ca","Num_Last",drEdit["Ma_Ca"].ToString()));
			Common.ScaterMemvar(this, ref drEdit);

			//Get New Barcode theo bo le
			if (enuNew_Edit == enuEdit.New)
			{
				DataRow drDmCa = DataTool.SQLGetDataRowByID("R81DMCA", "Ma_Ca", drEdit["Ma_Ca"].ToString());
				dteNgay_Nhap = Library.StrToDate(drDmCa["Ngay_Sx"].ToString());
				dbSo_Ca = Convert.ToDouble(drDmCa["So_Ca"]);
				strLoai = Convert.ToString(drDmCa["Loai"]);
				strXuong = Convert.ToString(drDmCa["Xuong"]);
				if (Common.InlistLike(strLoai,"CANGC"))
					txtBarcode.Text = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNewBarcode('L', '" + dteNgay_Nhap.ToShortDateString() + "', 7, 0, 'GCPOM', '" + strXuong +"')"));
				else
					txtBarcode.Text = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNewBarcode('L', '" + dteNgay_Nhap.ToShortDateString() + "', 7, 0, '', '" + strXuong + "')"));
			}

			BindingLanguage();
			LoadDicName();

            object objNum_Lot = this.GetNewNum_Lot();
            txtNum_Lot.Text = objNum_Lot.ToString();

			this.ShowDialog();
		}

		private void FillData()
		{
			//Danh mục sản phẩm
			DataTable dtDmSize = DataTool.SQLGetDataTable("R81DMSIZE", "", "", "Ma_Size");
			cboMa_Size.DataSource = dtDmSize;
			cboMa_Size.DisplayMember = "TEN_SIZE";
			cboMa_Size.ValueMember = "MA_SIZE";
			cboMa_Size.SelectedValue = drEdit["Ma_Size"] == DBNull.Value ? string.Empty : (string)drEdit["Ma_Size"];

			//Danh mục tiêu chuẩn
			DataTable dtDmStandard = DataTool.SQLGetDataTable("R81DMSTANDARD", "", "", "Standard_ID");
			cboStandard_ID.DataSource = dtDmStandard;
			cboStandard_ID.DisplayMember = "STANDARD_NAME";
			cboStandard_ID.ValueMember = "STANDARD_ID";
			cboStandard_ID.SelectedValue = drEdit["Standard_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Standard_ID"];

			//Danh mục mác thép
			DataTable dtDmMacThep = DataTool.SQLGetDataTable("R81DMMACTHEP", "", "", "Grade_ID");
			cboGrade_ID.DataSource = dtDmMacThep;
			cboGrade_ID.DisplayMember = "Grade_Name";
			cboGrade_ID.ValueMember = "Grade_ID";
			cboGrade_ID.SelectedValue = drEdit["Grade_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Grade_ID"];

			//Danh mục Lots
			DataTable dtDmLots = DataTool.SQLGetDataTable("R81DMLOTS", "", "", "Lot_ID");
			cboLot_ID.DataSource = dtDmLots;
			cboLot_ID.DisplayMember = "Lot_Name";
			cboLot_ID.ValueMember = "Lot_ID";
			cboLot_ID.SelectedValue = drEdit["Lot_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Lot_ID"];

			//Chất lượng
			DataTable dtDmCL = DataTool.SQLGetDataTable("R81DMCL", "", "", "Ma_CL");
			cboMa_CL.DataSource = dtDmCL;
			cboMa_CL.DisplayMember = "Ten_CL";
			cboMa_CL.ValueMember = "Ma_CL";
			cboMa_CL.SelectedValue = drEdit["Ma_CL"] == DBNull.Value ? string.Empty : (string)drEdit["Ma_CL"];
		}

		private void LoadDicName()
		{
			txtMa_Vt_Sp.bUseAutoDropDown = true;

			if (txtMa_Ca.Text.Trim() != string.Empty)
				lbtCa.Text = DataTool.SQLGetNameByCode("R81DMCA", "Ma_Ca", "Ca", txtMa_Ca.Text.Trim());
			else
				lbtCa.Text = string.Empty;

			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			else
				lbtTen_Vt_Sp.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
			if (enuNew_Edit == enuEdit.Edit && txtLy_Do.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ly_Do") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (cboMa_Size.SelectedValue == null || cboMa_Size.SelectedValue.ToString() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ten_Size") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (cboGrade_ID.SelectedValue.ToString() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Grade_ID") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (cboMa_CL.SelectedValue.ToString() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_CL") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}
			
			if (cboLot_ID.SelectedValue.ToString() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Lot_ID") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (numSo_Luong.Value <= 0)
			{
				Common.MsgCancel("Khối lượng không hợp lệ");
				return false;
			}

			return true;
		}

		private object GetNewNum_Lot()
		{
			object strResult = string.Empty;
			string strSQLExec = string.Empty;
			string strChar_Year = string.Empty;
			
			object objGrade_ID = cboGrade_ID.SelectedValue == null ? string.Empty : cboGrade_ID.SelectedValue;

			//lấy ngày sản xuất của ca hiện tại
			DataRow drDmCa = DataTool.SQLGetDataRowByID("R81DMCA", "Ma_Ca", txtMa_Ca.Text);
			DateTime dtNgay_Sx = Convert.ToDateTime(drDmCa["Ngay_Sx"]);
			//lấy vị trí sản xuất
			string strNoi_Sx = "1";
			if (Common.InlistLike(drDmCa["Loai"].ToString(), "CANGC"))
				strNoi_Sx = "2";

			if (numNum_Last.Value != 0)
			{
				txtNum_Lot_Concat1.Text = dtNgay_Sx.Year.ToString().Substring(2, 2) + strNoi_Sx + objGrade_ID;// + numNum_Last.Value.ToString().PadLeft(3, '0');
				strResult = dtNgay_Sx.Year.ToString().Substring(2, 2) + strNoi_Sx + objGrade_ID + numNum_Last.Value.ToString().PadLeft(3, '0');
			}
			else if (dtNgay_Sx >= Library.StrToDate("01/01/2026") && numNum_Last.Value == 0)
			{
				txtNum_Lot_Concat1.Text = dtNgay_Sx.Year.ToString().Substring(2, 2) + strNoi_Sx + objGrade_ID + dbSo_Ca.ToString().PadLeft(3, '0');
				strResult = dtNgay_Sx.Year.ToString().Substring(2, 2) + strNoi_Sx + objGrade_ID + dbSo_Ca.ToString().PadLeft(3, '0') + numNum_Lot_Concat2.Value.ToString().PadLeft(2, '0');
			}
			else
			{
				//Get Char Year Current
				if (string.IsNullOrEmpty(strChar_Year))
					strChar_Year = SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'NAM_SX' AND Type_ID = '" + dtNgay_Sx.Year + "'").ToString();
				txtNum_Lot_Concat1.Text = strChar_Year + objGrade_ID + dbSo_Ca.ToString().PadLeft(3, '0');
				strResult = strChar_Year + objGrade_ID + dbSo_Ca.ToString().PadLeft(3, '0') + numNum_Lot_Concat2.Value.ToString().PadLeft(2, '0');
			}
			////Get Char Year Current
			//strChar_Year = SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'NAM_SX' AND Type_ID = '" + Voucher.GetDate_Server().Year + "'").ToString();

			//txtNum_Lot_Concat1.Text = strChar_Year + objGrade_ID + dbSo_Ca;
			//strResult = strChar_Year + objGrade_ID + dbSo_Ca.ToString().PadLeft(3,'0') + numNum_Lot_Concat2.Value.ToString().PadLeft(2, '0');

			return strResult;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (drEdit.Table.Columns.Contains("Ma_Size"))
				drEdit["Ma_Size"] = cboMa_Size.Text;

			if (drEdit.Table.Columns.Contains("Standard_Name"))
				drEdit["Standard_Name"] = cboStandard_ID.Text;

			if (drEdit.Table.Columns.Contains("Grade_Name"))
				drEdit["Grade_Name"] = cboGrade_ID.Text;

			if (drEdit.Table.Columns.Contains("Lot_Name"))
				drEdit["Lot_Name"] = cboLot_ID.Text;

			if (drEdit.Table.Columns.Contains("Ten_CL"))
				drEdit["Ten_CL"] = cboMa_CL.Text;

			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL R81DMBARCODE
			if (enuNew_Edit == enuEdit.New)
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("STRNEW_EDIT", (char)enuNew_Edit == 'N' ? 'L' : 'E');
				htPara.Add("MA_SIZE", cboMa_Size.SelectedValue);
				htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text.Trim());
				htPara.Add("MA_CA", txtMa_Ca.Text.Trim());
				htPara.Add("STANDARD_ID", cboStandard_ID.SelectedValue);
				htPara.Add("GRADE_ID", cboGrade_ID.SelectedValue);
				htPara.Add("MA_CL", cboMa_CL.SelectedValue);
				htPara.Add("NO_MELT", txtNo_Melt.Text.Trim());
				htPara.Add("LOT_ID", cboLot_ID.SelectedValue);
				htPara.Add("NUM_LOT", txtNum_Lot.Text.Trim());
				htPara.Add("NUM_BARS", numNum_Bars.Value);
				htPara.Add("LENGTH", numLength.Value);

				htPara.Add("SO_LUONG", numSo_Luong.Value);
				htPara.Add("SO_LUONG_BAREM", numSo_Luong_Barem.Value);

				htPara.Add("BEND_TEST", 1);
				htPara.Add("INPUT_TYPE", 0);
				htPara.Add("IS_BAREM", enuIs_Barem.Text);
				htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
				htPara.Add("MA_DATA", Element.sysMa_Data);
				htPara.Add("SO_CT_LXH", Common.InlistLike(strLoai,"CANGC")? "GCPOM": "");
				htPara.Add("BARCODE", txtBarcode.Text.Trim());
                htPara.Add("IS_PRINT", bPrint);
				htPara.Add("IS_OUTPUT", 0);
				
				return SQLExec.Execute("sp_Update_DmBarcode", htPara, CommandType.StoredProcedure);
			}
			else
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("STRNEW_EDIT", (char)enuNew_Edit);
				htPara.Add("BARCODE", txtBarcode.Text.Trim());
				htPara.Add("MA_CA", txtMa_Ca.Text.Trim());
				htPara.Add("MA_SIZE", cboMa_Size.SelectedValue);
				htPara.Add("STANDARD_ID", cboStandard_ID.SelectedValue);
				htPara.Add("GRADE_ID", cboGrade_ID.SelectedValue);
				htPara.Add("MA_CL", cboMa_CL.SelectedValue);
				htPara.Add("LOT_ID", cboLot_ID.SelectedValue);
				htPara.Add("NUM_LOT", txtNum_Lot.Text.Trim());
				htPara.Add("NUM_BARS", numNum_Bars.Value);
				htPara.Add("LENGTH", numLength.Value);
				htPara.Add("SO_LUONG", numSo_Luong.Value);
				htPara.Add("SO_LUONG_BAREM", numSo_Luong_Barem.Value);
				htPara.Add("LY_DO", txtLy_Do.Text);
				htPara.Add("NO_MELT", txtNo_Melt.Text.Trim());
				htPara.Add("BEND_TEST", 1);
				htPara.Add("IS_BAREM", enuIs_Barem.Text);
				htPara.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
                htPara.Add("IS_PRINT", bPrint);
				htPara.Add("MA_DATA", Element.sysMa_Data);

				return SQLExec.Execute("sp_Update_DmBarcode", htPara, CommandType.StoredProcedure);
			}

		}

		void numNum_Lot_Concat2_ValueChanged(object sender, EventArgs e)
		{
			object objNum_Lot = this.GetNewNum_Lot();
			txtNum_Lot.Text = objNum_Lot.ToString();
		}

		void txtMa_Ca_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ca.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Ca", strValue, bRequire, "LOAI = 'CAN'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Ca.Text = string.Empty;
				lbtCa.Text = string.Empty;
			}
			else
			{
				txtMa_Ca.Text = drLookup["Ma_Ca"].ToString();
				lbtCa.Text = drLookup["Ca"].ToString();
			}
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = true;

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
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();
				numLength.Value = drLookup["Length"] == DBNull.Value ? 0 : Convert.ToDecimal(drLookup["Length"]);
				numNum_Bars.Value = drLookup["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDecimal(drLookup["Num_Bars"]);

				if (numNum_Bars.Value <= 0)
					numLength.Value = 0;

				dbBarem_Standard = drLookup["Barem_Standard"] == DBNull.Value ? 0 : Convert.ToDouble(drLookup["Barem_Standard"]);

				//Phân tích mã theo các tiêu chí
				//Get Row DmSize
				DataRow drDmSize = DataTool.SQLGetDataRowByID("R81DMSIZE", "Ma_Size", (string)drLookup["Ma_Size"]);
				if (drDmSize != null)
					cboMa_Size.SelectedValue = drDmSize["Ma_Size"] == DBNull.Value ? string.Empty : drDmSize["Ma_Size"];

				//Get Row DmMacThep
                //DataRow drDmMacThep = DataTool.SQLGetDataRowByID("R81DMMACTHEP", "Grade_ID", (string)drLookup["Grade_ID"]);
                DataRow drDmMacThep = DataTool.SQLGetDataRowByID("vw_MacThepCt", "Grade_ID", (string)drLookup["Grade_ID"]);
				if (drDmMacThep != null)
				{
					cboGrade_ID.SelectedValue = drDmMacThep["Grade_ID"] == DBNull.Value ? string.Empty : drDmMacThep["Grade_ID"];
					cboStandard_ID.SelectedValue = drDmMacThep["Standard_ID"] == DBNull.Value ? string.Empty : drDmMacThep["Standard_ID"];
				}
			}

			//Calc So luong barem
            //numSo_Luong_Barem.Value = Math.Round((decimal)((dbBarem_Standard * Convert.ToDouble(numLength.Value)) * Convert.ToDouble(numNum_Bars.Value)));
            //numSo_Luong_Barem.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBarem('BD10081170')"));// *Convert.ToDouble(numNum_Bars.Value);

			object objNum_Lot = this.GetNewNum_Lot();
			txtNum_Lot.Text = objNum_Lot.ToString();
		}

		void numNum_Bars_Validating(object sender, CancelEventArgs e)
		{
			if (numNum_Bars.Value <= 0)
				numLength.Value = 0;
			Hashtable ht = new Hashtable();
			ht.Add("MA_VT", txtMa_Vt_Sp.Text);
			ht.Add("SO_BO", 0);
			ht.Add("SO_CAY_LE", numNum_Bars.Value);
			
			numSo_Luong_Barem.Value = numSo_Luong.Value = Convert.ToDecimal(SQLExec.ExecuteReturnValue("select [dbo].[fn_CalBaremBo](@Ma_Vt,@So_Bo,@So_Cay_Le)", ht, CommandType.Text));
			//numSo_Luong_Barem.Value = Math.Round((decimal)((dbBarem_Standard * Convert.ToDouble(numLength.Value)) * Convert.ToDouble(numNum_Bars.Value)));
		}

		void btSaveAndPrint_Click(object sender, EventArgs e)
		{
			bPrint = true;
			if (this.Save())
			{
				bPrint = true;
				isAccept = true;
				this.Close();
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				bPrint = false;
				isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			bPrint = false;
			this.isAccept = false;
			this.Close();
		}
		
		private void LockEditInfo(bool bLocked)
		{
			cboMa_CL.Enabled = txtNo_Melt.Enabled = cboLot_ID.Enabled = numSo_Luong.Enabled = bLocked;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (enuNew_Edit == enuEdit.New && txtBarcode.Text.Trim().StartsWith("L"))
			{
				LockEditInfo(true);
				btSaveAndPrint.Enabled = false;
				numNum_Bars.Enabled = true;
			}

			if (enuNew_Edit == enuEdit.Edit)
			{
				LockEditInfo(false);

				if (Common.CheckPermission("ACCESS_SO_LUONG", enuPermission_Type.Allow_Access))
					numSo_Luong.Enabled = numSo_Luong_Barem.Enabled = true;
				else
					numSo_Luong.Enabled = numSo_Luong_Barem.Enabled = false;
			}
		}
	}
}
