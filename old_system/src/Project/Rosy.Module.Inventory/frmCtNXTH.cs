using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem;

namespace RosyModule.Inventory
{
	public partial class frmCtNXTH : RosySystem.Customize.frmView
	{
		#region Variable

		double dbMinWeight = 50;
		double dbMaxWeight = 5000;
		double oldWeight = 0;
		double dbSlopes_Up = 200;
		double dbSlopes_Down = 400;
		double dbNum_Stabilize = 0;
		double dbWeight;
		double dbBar_Weight = 0;
		int iValue_Weight = 0;
		int iMax_Count = 0;

		bool isClose = false;
		bool isNewCoil = false;
		bool bCurrent_State = true;
		bool bEnable_Weighing = false;
		bool bShow_Err = false;
		string strNum_Lot = string.Empty;
		string strMa_Ca = string.Empty;

		WEIGHING_STATUS myWeighingStatus = WEIGHING_STATUS.OUT_OF_SCALE_RANGE;
		Hashtable htWeights = new Hashtable();
		Hashtable htMaxWeights = new Hashtable();

		BindingSource bdsCtNx_Barcode = new BindingSource();
		DataTable dtCtNx_Barcode;
		DataRow drCurrent;
		
		#endregion

		#region Constructor

		public frmCtNXTH()
		{
			InitializeComponent();

			this.InitDevice();

			this.tmOverWeight.Tick += new EventHandler(tmOverWeight_Tick);
			this.chkEditInfo.CheckedChanged += new EventHandler(chkEditInfo_CheckedChanged);
			this.cboMa_Vt.SelectedValueChanged += new EventHandler(cboSelectedValueChanged);
			this.cboGrade_ID.SelectedValueChanged += new EventHandler(cboSelectedValueChanged);
			this.FormClosed += new FormClosedEventHandler(frmCtNXTT_FormClosed);
			this.btExit.Click += new EventHandler(btExit_Click);

			this.numCode.Validated += new EventHandler(numCode_Validated);

			this.cboMa_Vt.Validated += new EventHandler(Update_Validated);
			this.cboGrade_ID.Validated += new EventHandler(Update_Validated);
			this.cboMa_CL.Validated += new EventHandler(Update_Validated);
			this.cboLot_ID.Validated += new EventHandler(Update_Validated);
			this.txtNo_Melt.Validated+=new EventHandler(Update_Validated);
			this.txtNum_Lot.Validated += new EventHandler(Update_Validated);
			this.numLength.Validated += new EventHandler(Update_Validated);
			this.numNum_Bars_Embryos.Validated += new EventHandler(Update_Validated);

			this.numLength.ValueChanged += new EventHandler(Barem_ValueChanged);
			this.numNum_Bars.ValueChanged += new EventHandler(Barem_ValueChanged);
			
			this.dgvCtNX_Barcode.CellDoubleClick += new DataGridViewCellEventHandler(dgvCtNX_Barcode_CellDoubleClick);
			this.dgvCtNX_Barcode.KeyDown += new KeyEventHandler(dgvCtNX_Barcode_KeyDown);
			this.btPrint.Click += new EventHandler(btPrint_Click);
		}

		new public void Load()
		{
			this.Build();
			this.FillData();
			this.DisplaySummary();

			this.BindingLanguage();
			this.LoadDicName();

			if (!isClose)
				this.Show();
			else
				this.Close();
		}

		new public void Load(string strMa_Ca)
		{
			this.strMa_Ca = strMa_Ca;
			this.Load();
		}

		#endregion

		#region Method

		private void InitDevice()
		{
			DataRow drEquipment = DataTool.SQLGetDataRowByID("R81EquipmentInfo", "Host_IP", MachineInfo.GetHostIP());
			if (drEquipment != null)
			{
				Level2Emu.strPortName = (string)drEquipment["PLC_Port_Name"];

				Variables.strEquip_ID = (string)drEquipment["Equip_ID"];

				try { Variables.StatusInputType = (StatusInputType)Enum.Parse(typeof(StatusInputType), (string)drEquipment["Status_Input_Type"]); }
				catch { Variables.StatusInputType = StatusInputType.CANDTTUDONG; }
				
				Variables.dbZero_Coefficient = Convert.ToDouble(drEquipment["Zero_Coefficient"]);
				Variables.dbSpan_Coefficient = Convert.ToDouble(drEquipment["Span_Coefficient"]);
				Variables.dbNet_Weight_Min = Convert.ToDouble(drEquipment["Net_Weight_Min"]);
				Variables.dbNet_Weight_Max = Convert.ToDouble(drEquipment["Net_Weight_Max"]);
				Variables.iStable_Count = Convert.ToInt32(drEquipment["Stable_Count"]);
				Variables.iNum_Ticket_Print = Convert.ToInt32(drEquipment["Num_Ticket_Print"]);
				Variables.strPrint_Barcode = (string)drEquipment["Print_Barcode"];
				Variables.strPrint_Report = (string)drEquipment["Print_Report"];
				Variables.strPrint_Eticket = (string)drEquipment["Print_Eticket"];

				this.dbSlopes_Up = Variables.dbSlopes_Up = Convert.ToDouble(drEquipment["Slopes_Up"]);
				this.dbSlopes_Down = Variables.dbSlopes_Down = Convert.ToDouble(drEquipment["Slopes_Down"]);

				HardwareInterface.Start();

				//Level2Emu.Init();
				//Led5Digit.Init();
				HardwareInterface.DataReceive += new DataEventHandler(HardwareInterface_DataReceive);

				string strStatusInputType = (string)drEquipment["Status_Input_Type"];
				if (strStatusInputType != string.Empty)
				{
					if (strStatusInputType == "CANDTCOXACNHAN")
						lblStatus_Input_Type.Text = "Kiểu nhập: Từ cân điện tử có xác nhận";
					else if (strStatusInputType == "BANPHIM")
						lblStatus_Input_Type.Text = "Kiểu nhập: Từ bàn phím";
					else
						lblStatus_Input_Type.Text = "Kiểu nhập: Tự động từ cân điện tử";
				}
			}
		}

		private void Build()
		{
			//DataGridView
			dgvCtNX_Barcode.strZone = "CTNX_BARCODE";
			dgvCtNX_Barcode.BuildGridView();
			
			//Danh mục sản phẩm
			DataTable dtDmVtSp = DataTool.SQLGetDataTable("R81DMVT", "", "Ma_Nh_Vt = 'THEPCAY'", "Ma_Vt");
			cboMa_Vt.DataSource = dtDmVtSp;
			cboMa_Vt.DisplayMember = "TEN_VT";
			cboMa_Vt.ValueMember = "MA_VT";

			//Danh mục tiêu chuẩn
			DataTable dtDmStandard = DataTool.SQLGetDataTable("R81DMSTANDARD", "", "", "Standard_ID");
			cboStandard_ID.DataSource = dtDmStandard;
			cboStandard_ID.DisplayMember = "STANDARD_NAME";
			cboStandard_ID.ValueMember = "STANDARD_ID";

			//Danh mục mác thép
			DataTable dtDmMacThep = DataTool.SQLGetDataTable("R81DMMACTHEP", "", "", "Grade_ID");
			cboGrade_ID.DataSource = dtDmMacThep;
			cboGrade_ID.DisplayMember = "Grade_Name";
			cboGrade_ID.ValueMember = "Grade_ID";

			//Danh mục Lots
			DataTable dtDmLots = DataTool.SQLGetDataTable("R81DMLOTS", "", "", "Lot_ID");
			cboLot_ID.DataSource = dtDmLots;
			cboLot_ID.DisplayMember = "Lot_Name";
			cboLot_ID.ValueMember = "Lot_ID";

			//Chất lượng
			DataTable dtDmCL = DataTool.SQLGetDataTable("R81DMCL", "", "", "Ma_CL");
			cboMa_CL.DataSource = dtDmCL;
			cboMa_CL.DisplayMember = "Ten_CL";
			cboMa_CL.ValueMember = "Ma_CL";
		}

		private void FillData()
		{
			//Danh mục ca
			DataTable dtDmCa = new DataTable();
			if (this.strMa_Ca != string.Empty)
				dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ma_Ca = '" + strMa_Ca + "'", "");
			else
				dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ended = 0", "");

			//Lấy ca cuối cùng
			if (dtDmCa.Rows.Count == 0)
			{
				string strSQLExec = "SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Ma_Ca)) AS BIGINT)), 0) FROM R81DMCA WHERE Ended = 1";
				string strMa_Ca_KT = Convert.ToString(SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text));
				dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ma_Ca = '" + strMa_Ca_KT + "'", "");

				if (dtDmCa.Rows.Count == 0)
				{
					Common.MsgOk("Ca sản xuất chưa tồn tại. Vào tạo ca sản xuất");
				}
			}

			if (dtDmCa.Rows.Count > 0)
			{
				txtMa_Ca.Text = (string)dtDmCa.Rows[0]["Ma_Ca"];
				dteNgay_Sx.Text = Convert.ToString(dtDmCa.Rows[0]["Ngay_Sx"]);
				txtCa.Text = (string)dtDmCa.Rows[0]["Ca"];
				txtTGian_Sx.Text = Convert.ToString(dtDmCa.Rows[0]["Gio_Begin"].ToString().Substring(0, 5)) + "-" + Convert.ToString(dtDmCa.Rows[0]["Gio_End"].ToString().Substring(0, 5));
				txtTen_CbNv_TC.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_TC"]);
				txtTen_CbNv_KCS.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_KCS"]);
				txtTen_CbNv_Can.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_Can"]);

				//Build Ca Last Update
				cboMa_Vt.SelectedValue = (string)dtDmCa.Rows[0]["Ma_Vt_Last"];
				cboGrade_ID.SelectedValue = (string)dtDmCa.Rows[0]["Grade_ID_Last"];
				cboMa_CL.SelectedValue = (string)dtDmCa.Rows[0]["Ma_CL_Last"];
				txtNo_Melt.Text = (string)dtDmCa.Rows[0]["No_Melt_Last"];
				cboLot_ID.SelectedValue = (string)dtDmCa.Rows[0]["Lot_ID_Last"];
				txtNum_Lot.Text = (string)dtDmCa.Rows[0]["Num_Lot_Last"];
				numLength.Value = Convert.ToDecimal(dtDmCa.Rows[0]["Length_Last"]);

				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CA", txtMa_Ca.Text.Trim());

				dtCtNx_Barcode = SQLExec.ExecuteReturnDt("sp_GetCtN_Barcode", htPara, CommandType.StoredProcedure);
				bdsCtNx_Barcode.DataSource = dtCtNx_Barcode;
				dgvCtNX_Barcode.DataSource = bdsCtNx_Barcode;

				bdsCtNx_Barcode.Position = 0;

				object objBar_Weight = SQLExec.ExecuteReturnValue("SELECT Bar_Weight FROM R81DMBAREMS WHERE Product_ID = '" + cboMa_Vt.SelectedValue + "' AND Standard_ID = '" + cboStandard_ID.SelectedValue + "'");
				if (objBar_Weight == DBNull.Value || objBar_Weight == null)
					dbBar_Weight = 0.0;
				else
					dbBar_Weight = Convert.ToDouble(objBar_Weight);

				this.Get_Ma_Vt_Sp();
				object objCode = this.GetNewCode();
				numCode.Value = Convert.ToInt32(objCode);
			}
		}

		private void LoadDicName()
		{
			this.dgvCtNX_Barcode.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCtNX_Barcode.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvCtNX_Barcode.Columns.Contains("SO_LUONG"))
				dgvCtNX_Barcode.Columns["SO_LUONG"].HeaderText = "Khối lượng";
		}

		private void LockEditInfo()
		{
			cboMa_Vt.Enabled = cboGrade_ID.Enabled = cboMa_CL.Enabled = txtNo_Melt.Enabled =
			cboLot_ID.Enabled = numNum_Bars.Enabled = numLength.Enabled = numNum_Bars_Embryos.Enabled = chkEditInfo.Checked;
		}

		private void AddWeight(double dbValue)
		{
			if (this.htWeights.ContainsKey(dbValue))
			{
				int iNum = Convert.ToInt32(this.htWeights[dbValue]) + 1;
				this.htWeights[dbValue] = iNum;
				
				if (this.iMax_Count < iNum)
				{
					//Xac dinh gia tri cuoi cung. Dang bi sai 10 lan.
					this.iMax_Count = iNum;
					this.dbNum_Stabilize = dbValue;
					////Lay chinh xac bang cach nay
					//if (htMaxWeights.Count > 0)
					//    this.dbNum_Stabilize = Convert.ToDouble(htMaxWeights[htMaxWeights.Count]);
					//else
					//    this.dbNum_Stabilize = 0;
				}
			}
			else
			{
				this.htWeights.Add(dbValue, 1);

				if(htMaxWeights.Count == 0)
					this.htMaxWeights.Add(1, dbValue);
				else
					this.htMaxWeights.Add(htMaxWeights.Count + 1, dbValue);
			}
		}

		private bool IsWeighingValid(double dbValue, double dbMin, double dbMax)
		{
			if (dbMin > dbMax)
				return false;

			return (((dbMin == 0.0) & (dbMax == 0.0)) || ((dbValue <= dbMax) & (dbValue >= dbMin)));
		}

		private void ChangeWeighingState(bool state)
		{
			if (state != this.bCurrent_State)
			{
				if (state)
				{
					this.ResetScale();
					this.bEnable_Weighing = true;
				}
				if (!state)
				{
					if (this.bEnable_Weighing)
					{
						this.DataReceived();
					}
					this.bEnable_Weighing = false;
				}
				this.bCurrent_State = state;
			}
		}

		private void ResetScale()
		{
			htWeights.Clear();
			htMaxWeights.Clear();
			dbNum_Stabilize = 0.0;
			iMax_Count = 0;
		}

		private void DataReceived()
		{
			if ((Variables.StatusInputType == StatusInputType.CANDTTUDONG) && isNewCoil)
			{
				this.dbWeight = dbNum_Stabilize;
				this.Set_Weighing_Status(this.dbWeight);
				switch (this.myWeighingStatus)
				{
					case WEIGHING_STATUS.GOOD:
						this.Insert_Barcode_CtNx();
						break;

					case WEIGHING_STATUS.OUT_OF_PRODUCT_RANGE:
						this.Count_Value();
						break;
				}
			}
		}

		private void Insert_Barcode_CtNx()
		{
			string strBarcode = "";
			strNum_Lot = txtNum_Lot.Text.Replace(" ", "");
			if ((this.txtNum_Lot.Text == "") && (Variables.StatusInputType != StatusInputType.CANDTTUDONG))
			{
				Common.MsgCancel("Phải chọn lô sản phẩm trước");
				txtNum_Lot.Focus();
			}
			else
			{
				Variables.iCode = (int)this.numCode.Value;
				Variables.iCode++;
				if (this.CheckExistsCode(Variables.iCode))
				{
					object objMax_Code = this.GetNewCode();
					Common.MsgCancel("Đã có bó " + Variables.iCode + ", chương trình sẽ tự động nhập vào bó " + objMax_Code + 1);
					Variables.iCode = ((int)objMax_Code) + 1;
				}
				
				double dbSo_Luong = 0.0;
				double dbSo_Luong_Barem = 0.0;
				if (cboLay_KL.SelectedIndex == 0)
				{
					dbSo_Luong = dbWeight;
					dbSo_Luong_Barem = Convert.ToInt32(numSo_Luong_Barem.Value);
				}
				else if (cboLay_KL.SelectedIndex == 1)
				{
					dbSo_Luong = Convert.ToInt32(numSo_Luong_Barem.Value);
					dbSo_Luong_Barem = dbWeight;
				}
				else if (dbWeight < Convert.ToInt32(numSo_Luong_Barem.Value))
				{
					dbSo_Luong_Barem = Convert.ToInt32(numSo_Luong_Barem.Value);
					dbSo_Luong = dbWeight;
				}
				else
				{
					dbSo_Luong = Convert.ToInt32(numSo_Luong_Barem.Value);
					dbSo_Luong_Barem = dbWeight;
				}

				Hashtable htPara = new Hashtable();
				htPara.Add("STRNEW_EDIT", "N");
				htPara.Add("MA_VT", cboMa_Vt.SelectedValue);
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
				htPara.Add("CODE", Variables.iCode);
				htPara.Add("SO_LUONG", dbSo_Luong);
				htPara.Add("SO_LUONG_BAREM", dbSo_Luong_Barem);
				htPara.Add("BEND_TEST", 1);
				htPara.Add("NUM_BARS_EMBRYOS", numNum_Bars_Embryos.Value);
				htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
				htPara.Add("MA_DATA", Element.sysMa_Data);

				strBarcode = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_DmBarcode_CtN_Barcode", htPara, CommandType.StoredProcedure));

				if (strBarcode == string.Empty)
					bShow_Err = false;

				if (this.bShow_Err)
				{
					Common.MsgCancel("Không thêm được bó thép này");
					Variables.iCode--;
					this.isNewCoil = true;
				}
				else
				{
					this.isNewCoil = false;
					Variables.strBarcode = strBarcode;
					numCode.Value = Variables.iCode;
					numSo_Luong.Value = Convert.ToDouble(dbWeight);
					lblBarcode.Text = strBarcode;
					if ((numNum_Bars.Value != 0M) && (numLength.Value != 0M))
					{
						numSo_Luong_Barem.Value = Convert.ToDouble((numSo_Luong.Value / Convert.ToDouble((numLength.Value * numNum_Bars.Value))));
					}
					else
					{
						this.numSo_Luong_Barem.Value = 0;
					}

					this.SetDataToDataGrid(strBarcode);
					this.Print(strBarcode, true);
					this.DisplaySummary();
				}
			}

			numWeight_Scale.Focus();
		}

		private void Count_Value()
		{
			Variables.iCode = (int)numCode.Value;
			Variables.iCode++;
			if (this.bShow_Err)
			{
				Common.MsgCancel("Không thêm được bó thép này");
			}
			else
			{
				isNewCoil = false;
				Variables.strBarcode = string.Empty;
				numCode.Value = Variables.iCode;
				numSo_Luong.Value = Convert.ToDouble(dbWeight);
			}
		}

		private void SetDataToDataGrid(string strBarcode)
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CA", txtMa_Ca.Text.Trim());
			htPara.Add("BARCODE", strBarcode);

			DataTable dtCurrent = SQLExec.ExecuteReturnDt("sp_GetCtN_Barcode", htPara, CommandType.StoredProcedure);
			if (dtCurrent.Rows.Count > 0)
			{
				DataRow drAddCurrent = dtCurrent.Rows[0];

				DataRow drEditCtNew = dtCtNx_Barcode.NewRow();
				Common.CopyDataRow(drAddCurrent, drEditCtNew);
				Common.SetDefaultDataRow(ref drEditCtNew);

				dtCtNx_Barcode.Rows.Add(drEditCtNew);
				drEditCtNew.AcceptChanges();
			}

			bdsCtNx_Barcode.Sort = "BARCODE DESC";
			bdsCtNx_Barcode.Position = 0;
		}

		private void DisplaySummary()
		{
			numTSo_Luong.Value = Common.SumDCValue(dtCtNx_Barcode, "So_Luong", "");
			numCount_Coils.Value = dtCtNx_Barcode.Rows.Count;
		}

		private bool CheckExistsCode(int iCode)
		{
			string strSQLExec = @"SELECT Code FROM R81DMBARCODE T1 WITH(NOLOCK) JOIN (SELECT Ma_Ca FROM R81DMCA WITH(NOLOCK) WHERE YEAR(Ngay_Sx) = " + DateTime.Parse(dteNgay_Sx.Text).Year + ") T2 ON T1.Ma_Ca = T2.Ma_Ca" + @"
										JOIN R81DMVT T3 WITH(NOLOCK) ON T1.Ma_Vt = T3.Ma_Vt
									WHERE T1.Code = " + iCode + "";

			object objCode = SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text);
			if (objCode != DBNull.Value || objCode != null)
				return false;

			return true;
		}

		private object GetNewCode()
		{
			string strSQLExec = @"SELECT MAX(Code)
										FROM R81DMBARCODE T1 WITH(NOLOCK) JOIN (SELECT Ma_Ca FROM R81DMCA WITH(NOLOCK) WHERE YEAR(Ngay_Sx) = " + DateTime.Parse(dteNgay_Sx.Text).Year + ") T2 ON T1.Ma_Ca = T2.Ma_Ca";

			object objCode = SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text);
			if (objCode == DBNull.Value || objCode == null)
				objCode = 0;

			return objCode;
		}

		private void Set_Weighing_Status(double dbWeight)
		{
			if (IsWeighingValid(dbWeight, Variables.dbNet_Weight_Min, Variables.dbNet_Weight_Max))
			{
				if (IsWeighingValid(dbWeight, dbMinWeight, dbMaxWeight))
				{
					myWeighingStatus = WEIGHING_STATUS.GOOD;
					lblWeightOver.Text = "";
					tmOverWeight.Stop();
				}
				else
				{
					myWeighingStatus = WEIGHING_STATUS.OUT_OF_PRODUCT_RANGE;
					lblBarcode.Text = "";
					tmOverWeight.Start();
				}
			}
			else
			{
				myWeighingStatus = WEIGHING_STATUS.OUT_OF_SCALE_RANGE;
				lblBarcode.Text = "";
				numSo_Luong.Value = 0;
				tmOverWeight.Start();
			}
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCtNx_Barcode.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCtNx_Barcode.Current).Row;

			//Check Barcode Output?
			if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", drCurrent["Barcode"]))
			{
				Common.MsgYes_No("Mã vạch này được xuất rồi.Không sửa được");
				return;
			}

			frmDmBarcode_Edit frm = new frmDmBarcode_Edit();
			frm.Load(enuEdit.Edit, drCurrent);

			if (frm.isAccept)
			{
				if (frm.bPrint)
					Voucher.PrintBarcode(drCurrent["Barcode"].ToString(), false, Variables.strPrint_Barcode);

				Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtNx_Barcode.Current).Row);
				dtCtNx_Barcode.AcceptChanges();

				this.DisplaySummary();
			}
		}

		public override void Delete()
		{
			if (bdsCtNx_Barcode.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCtNx_Barcode.Current).Row;

			string strBarcode = (string)drCurrent["Barcode"];

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			//Check Barcode Output?
			if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", drCurrent["Barcode"]))
			{
				Common.MsgYes_No("Mã vạch này được xuất rồi.Không xóa được");
				return;
			}

			if (SQLExec.Execute("sp_Delete_DmBarcode_CtN_Barcode", drCurrent, CommandType.StoredProcedure))
			{
				bdsCtNx_Barcode.RemoveAt(bdsCtNx_Barcode.Position);
				dtCtNx_Barcode.AcceptChanges();

				if (strBarcode == Variables.strBarcode)
				{
					Variables.iCode--;
					numCode.Value = Variables.iCode;
				}

				if (bdsCtNx_Barcode.Position >= 0)
				{
					DataRow drCurrent_After = ((DataRowView)bdsCtNx_Barcode.Current).Row;
					numSo_Luong.Value = drCurrent_After["So_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent_After["So_Luong"]);
					lblBarcode.Text = drCurrent_After["Barcode"] == DBNull.Value ? string.Empty : (string)drCurrent_After["Barcode"];
					numCode.Value = drCurrent_After["Code"] == DBNull.Value ? 0 : Convert.ToInt32(drCurrent_After["Code"]);
				}
				else
				{
					numSo_Luong.Value = 0;
					lblBarcode.Text = string.Empty;
					numCode.Value = 0;
				}
				
				this.DisplaySummary();
			}
		}

		private void Print(string strBarcode, bool bPreview)
		{
			Voucher.PrintBarcode(strBarcode, false, Variables.strPrint_Barcode);
		}

		private void Design()
		{
			string strReport_File = "rptBarcode_TT";
			RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strReport_File);
		}

		#endregion

		#region Event

		void HardwareInterface_DataReceive(double value, string type)
		{
			iValue_Weight = Convert.ToInt32(numWeight_Scale.Value);
			//Led5Digit.Value = Convert.ToInt32(numWeight_Scale.Value);
			//Level2Emu.Weight = value;

			if (Variables.StatusInputType != StatusInputType.BANPHIM)
			{
				double dbValue = (value * Variables.dbSpan_Coefficient) + Variables.dbZero_Coefficient;
				this.numWeight_Scale.Value = dbValue;

				if ((this.oldWeight <= this.dbSlopes_Up) & (dbValue >= this.dbSlopes_Up))
				{
					isNewCoil = true;
				}
				this.oldWeight = dbValue;
				if (Variables.StatusInputType == StatusInputType.CANDTTUDONG)
				{
					//Suon xuong 200
					if (dbValue >= dbSlopes_Down)
					{
						ChangeWeighingState(true);
					}
					//Suon len 500
					if (dbValue <= dbSlopes_Up)
					{
						ChangeWeighingState(false);
					}
					if (bEnable_Weighing && IsWeighingValid(dbValue, Variables.dbNet_Weight_Min, Variables.dbNet_Weight_Max))
					{
						AddWeight(dbValue);
					}
				}
			}
		}

		void tmOverWeight_Tick(object sender, EventArgs e)
		{
			if (this.lblWeightOver.ForeColor == Color.LawnGreen)
			{
				this.lblWeightOver.ForeColor = Color.Red;
			}
			else
			{
				this.lblWeightOver.ForeColor = Color.LawnGreen;
			}
		}

		void cboSelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cboControl = (ComboBox)sender;
			string strControl_Name = cboControl.Name;
			if (strControl_Name == "cboMa_Vt")
			{
				string strMa_Vt = cboMa_Vt.SelectedValue == null ? string.Empty : Convert.ToString(cboMa_Vt.SelectedValue);
				DataRow drDmVtSp = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", strMa_Vt);
				if (drDmVtSp != null)
				{
					numNum_Bars.Value = Convert.ToInt32(drDmVtSp["Num_Bars"]);
					dbMinWeight = 40;
					dbMaxWeight = 4000;

					if (numNum_Bars.Value <= 0)
						numLength.Value = 0;
				}
				else
				{
					dbMinWeight = 40;
					dbMinWeight = 4000;
				}
			}
			else if (strControl_Name == "cboGrade_ID")
			{
				string strGradeID = cboGrade_ID.SelectedValue == null ? string.Empty : cboGrade_ID.SelectedValue.ToString();
				object objStandardID = SQLExec.ExecuteReturnValue("SELECT Standard_ID FROM R81DMMACTHEP WHERE Grade_ID = '" + strGradeID + "'");
				if (objStandardID != null && objStandardID != DBNull.Value)
					cboStandard_ID.SelectedValue = objStandardID;
			}
		}

		void chkEditInfo_CheckedChanged(object sender, EventArgs e)
		{
			this.LockEditInfo();
		}

		void Barem_ValueChanged(object sender, EventArgs e)
		{
			numSo_Luong_Barem.Value = Math.Round((double)((dbBar_Weight * Convert.ToDouble(numLength.Value)) * Convert.ToDouble(numNum_Bars.Value)));
		}

		void Update_Validated(object sender, EventArgs e)
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("MA_VT_LAST", cboMa_Vt.SelectedValue == null ? string.Empty : cboMa_Vt.SelectedValue);
			htPara.Add("GRADE_ID_LAST", cboGrade_ID.SelectedValue == null ? string.Empty : cboGrade_ID.SelectedValue);
			htPara.Add("MA_CL_LAST", cboMa_CL.SelectedValue == null ? string.Empty : cboMa_CL.SelectedValue);
			htPara.Add("NO_MELT_LAST", txtNo_Melt.Text.Trim());
			htPara.Add("LOT_ID_LAST", cboLot_ID.SelectedValue == null ? string.Empty : cboLot_ID.SelectedValue);
			htPara.Add("NUM_LOT_LAST", txtNum_Lot.Text.Trim());
			htPara.Add("LENGTH_LAST", numLength.Value);
			htPara.Add("NUM_BARS_EMBRYOS_LAST", numNum_Bars_Embryos.Value);
			htPara.Add("MA_CA", txtMa_Ca.Text.Trim());

			string strSQLExec = @"UPDATE R81DMCA SET Ma_Vt_Last = @Ma_Vt_Last, Grade_ID_Last = @Grade_ID_Last, Ma_Cl_Last = @Ma_Cl_Last, No_Melt_Last = @No_Melt_Last, Lot_ID_Last = @Lot_ID_Last, Num_Lot_Last = @Num_Lot_Last, Length_Last = @Length_Last, Num_Bars_Embryos_Last = @Num_Bars_Embryos_Last WHERE Ma_Ca = @Ma_Ca";
			SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

			this.Get_Ma_Vt_Sp();

		}

		private void Get_Ma_Vt_Sp()
		{
			string strMa_Vt_Sp = "B";
			string strMa_Vt = cboMa_Vt.Text.ToUpper().Trim();
			
			if (strMa_Vt == string.Empty)
				return;

			//Loai thep
			if (strMa_Vt.StartsWith("Φ"))
				strMa_Vt_Sp += "1";
			else if (strMa_Vt.StartsWith("D"))
				strMa_Vt_Sp += "3";

			//Mac thep
			string strGrade_Name = cboGrade_ID.Text.ToUpper().Trim();
			switch (strGrade_Name)
			{
				case "SD295A":
					if (strMa_Vt.StartsWith("D"))
						strMa_Vt_Sp += "52";
					else if (strMa_Vt.StartsWith("Φ"))
						strMa_Vt_Sp += "32";
					break;

				case "CB240-T":
					if (strMa_Vt.StartsWith("Φ"))
						strMa_Vt_Sp += "32";
					break;

				case "SD490":
					if (strMa_Vt.StartsWith("D"))
						strMa_Vt_Sp += "65";
					break;

				case "SD390":
					if (strMa_Vt.StartsWith("D"))
						strMa_Vt_Sp += "61";
					break;

				case "CB300-V":
					if (strMa_Vt.StartsWith("D"))
						strMa_Vt_Sp += "53";
					break;

				case "CB400-V":
					if (strMa_Vt.StartsWith("D"))
						strMa_Vt_Sp += "54";
					break;

				case "CB500-V":
					if (strMa_Vt.StartsWith("D"))
						strMa_Vt_Sp += "55";
					break;
			}

			double dbLength = Convert.ToDouble(numLength.Value);

			if (dbLength == 11.7 && strMa_Vt.StartsWith("D"))
				strMa_Vt_Sp += "1";
			else if (dbLength == 12 && strMa_Vt.StartsWith("D"))
				strMa_Vt_Sp += "2";
			else if (dbLength != 0 && strMa_Vt.StartsWith("D"))
				strMa_Vt_Sp += "5";
			else if (dbLength == 0 && strMa_Vt.StartsWith("D"))
				strMa_Vt_Sp += "7";
			else if (dbLength == 0 && strMa_Vt.StartsWith("Φ"))
				strMa_Vt_Sp += "0";

			//4 Ky tu cuoi
			strMa_Vt_Sp += strMa_Vt.Substring(1, strMa_Vt.Length - 1).PadLeft(3, '0') + "0";

			txtMa_Vt_Sp.Text = strMa_Vt_Sp;
		}

		void numCode_Validated(object sender, EventArgs e)
		{
			int iCode = Convert.ToInt32(numCode.Value) + 1;
			if (this.CheckExistsCode(iCode))
			{
				Common.MsgCancel("Số bó {" + iCode + "} đã tồn tại, hãy nhập số khác");
				object maxCode = this.GetNewCode();
				if (maxCode != DBNull.Value || maxCode != null)
				{
					numCode.Value = Convert.ToInt32(maxCode);
				}
			}
			else
			{
				Variables.iCode = Convert.ToInt32(numCode.Value);
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			if (!Common.MsgYes_No("Bạn có chắc chắn muốn kết thúc ca hiện tại không?", "N"))
				return;
			else
			{
				SQLExec.Execute("UPDATE R81DMCA SET Ended = 1 WHERE Ma_Ca = '" + txtMa_Ca.Text.Trim() + "'");
				this.Close();
			}

		}

		void btPrint_Click(object sender, EventArgs e)
		{
			if (bdsCtNx_Barcode.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCtNx_Barcode.Current).Row;
			this.Print(drCurrent["Barcode"].ToString(), false);
		}

		void frmCtNXTT_FormClosed(object sender, FormClosedEventArgs e)
		{
			HardwareInterface.DataReceive -= new DataEventHandler(this.HardwareInterface_DataReceive);
			this.Dispose();
		}

		#region DataGridView

		void dgvCtNX_Barcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (dgvCtNX_Barcode.CurrentRow == null)
				return;

			if (bdsCtNx_Barcode.Position < 0)
				return;

			switch (e.KeyCode)
			{
				case Keys.F8:
					this.Delete();
					return;
				case Keys.F7:
					this.Print(((DataRowView)bdsCtNx_Barcode.Current).Row["Barcode"].ToString(), false);
					break;
			}
		}

		void dgvCtNX_Barcode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			this.Edit(enuEdit.Edit);
		}
			
		#endregion

		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					return;
				case Keys.F8:
					return;
				case Keys.T:
					if (e.Modifiers == Keys.Control)
					{
						frmTestCom frm = new frmTestCom();
						frm.Load();
					}
					return;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Shift:
							Design();
							break;
					}
					return;
			}

			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
			LockEditInfo();
			lblBarcode.Text = "";
			cboLay_KL.SelectedIndex = 0;
		}

		private enum WEIGHING_STATUS
		{
			GOOD,
			OUT_OF_PRODUCT_RANGE,
			OUT_OF_SCALE_RANGE
		}

	}
}
