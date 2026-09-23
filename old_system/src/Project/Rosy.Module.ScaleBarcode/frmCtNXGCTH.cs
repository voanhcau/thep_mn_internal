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
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmCtNXGCTH : RosySystem.Customize.frmView
	{
		#region Variable
        object objActive = null;
		double dbMinWeight = 40;
		double dbMaxWeight = 4000;
		double oldWeight = 0;
		double dbSlopes_Up = 200;
		double dbSlopes_Down = 400;
		double dbNum_Stabilize = 0;
		double dbWeight;
		double dbBarem_Standard = 0;
		int iValue_Weight = 0;
		int iMax_Count = 0;

		bool isNotCurrent_Ca = false;

		bool isClose = false;
		bool isNewCoil = false;
		bool bCurrent_State = true;
		bool bEnable_Weighing = false;
		bool bShow_Err = false;
        bool bTestCan = false;
		string strNum_Lot = string.Empty;
		string strMa_Ca = string.Empty;
		string strChar_Year = string.Empty;
		public string strLoaiSx = string.Empty;
		string strMa_Vt_Sp = string.Empty;

		WEIGHING_STATUS myWeighingStatus = WEIGHING_STATUS.OUT_OF_SCALE_RANGE;
		Hashtable htWeights = new Hashtable();
		Hashtable htMaxWeights = new Hashtable();

		BindingSource bdsCtNx_Barcode = new BindingSource();
		DataTable dtCtNx_Barcode;
		DataRow drCurrent;


        BindingSource bdsTestCan = new BindingSource();
        DataTable dtTestCan;
        enuEdit enuNew_Edit_Voucher = enuEdit.New;
		#endregion

		#region Constructor

		public frmCtNXGCTH()
		{
			InitializeComponent();

			this.InitDevice();

			this.tmOverWeight.Tick += new EventHandler(tmOverWeight_Tick);
			this.chkEditInfo.CheckedChanged += new EventHandler(chkEditInfo_CheckedChanged);
			this.FormClosed += new FormClosedEventHandler(frmCtNXTT_FormClosed);
			this.btExit.Click += new EventHandler(btExit_Click);
			this.btNew.Click += new EventHandler(btNew_Click);
			this.numCode.Validated += new EventHandler(numCode_Validated);
            this.numNum_Last.Validated += NumNum_Last_Validated;
			this.numNum_Lot_Concat2.ValueChanged += new EventHandler(numNum_Lot_Concat2_ValueChanged);

			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			this.txtMa_Vt_Sp.Validated += new EventHandler(Update_Validated);
			this.cboMa_CL.Validated += new EventHandler(Update_Validated);
			this.cboLot_ID.Validated += new EventHandler(Update_Validated);
			this.txtNo_Melt.Validated+=new EventHandler(Update_Validated);
			this.txtNum_Lot.Validated += new EventHandler(Update_Validated);
			this.numLength.Validated += new EventHandler(Update_Validated);
            //this.numSo_Luong.Validated += NumSo_Luong_Validated;
			this.dgvCtNX_Barcode.CellDoubleClick += new DataGridViewCellEventHandler(dgvCtNX_Barcode_CellDoubleClick);
			this.dgvCtNX_Barcode.KeyDown += new KeyEventHandler(dgvCtNX_Barcode_KeyDown);
			this.btPrint.Click += new EventHandler(btPrint_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
            this.numSo_Luong.Validated += NumSo_Luong_Enter;

            this.btXuong.Click += BtXuong_Click;
		}

       

        private void BtXuong_Click(object sender, EventArgs e)
        {
			Load(cboCaSx.SelectedValue.ToString());
        }
		private void LoadCombo()
        {

			DataTable dtCaSx = SQLExec.ExecuteReturnDt("SELECT TOP 2 Ma_Ca, CONVERT(varchar(11),Ngay_Sx,103) + ' ' + Ca +' ' + Loai AS Ten_Ca FROM R81DMCA WHERE Loai LIKE 'CANGC%' AND YEAR(Ngay_Sx) = '"+ Voucher.GetDate_Server().Year + "' ORDER BY Ma_Ca DESC");
			DataRow drCaSx = dtCaSx.NewRow();
			drCaSx["Ten_Ca"] = drCaSx["Ma_Ca"] = string.Empty;
			dtCaSx.Rows.Add(drCaSx);
			dtCaSx.DefaultView.Sort = "Ma_Ca";
			cboCaSx.DataSource = dtCaSx;
			cboCaSx.DisplayMember = "Ten_Ca";
			cboCaSx.ValueMember = "Ma_Ca";
		}
        new public void Load()
		{
			
			this.Build();
			this.FillData();
			this.DisplaySummary();

			this.BindingLanguage();
			this.LoadDicName();
			
			strMa_Vt_Sp = txtMa_Vt_Sp.Text;
			
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

            DataTable dtEquipment = DataTool.SQLGetDataTable("R81EquipmentInfo", "*", "Host_IP = '" + MachineInfo.GetHostIP() + "'", "Host_IP");
           // DataTool.SQLGetDataRowByID("R81EquipmentInfo", "Host_IP", MachineInfo.GetHostIP());

			if (dtEquipment.Rows.Count == 1)
			{
                DataRow drEquipment = dtEquipment.Rows[0];
                lbtNote.Text = "Bạn đang sử đụng cân " + drEquipment["Equip_ID"].ToString() + " để cân thành phẩm " + drEquipment["Note"];
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

				HardwareInterface.DataReceive += new DataEventHandler(HardwareInterface_DataReceive);

				string strStatusInputType = (string)drEquipment["Status_Input_Type"];
				if (strStatusInputType != string.Empty)
				{
					if (strStatusInputType == "BANPHIM")
						lblStatus_Input_Type.Text = "Kiểu nhập: Từ bàn phím";
					else
						lblStatus_Input_Type.Text = "Kiểu nhập: Tự động từ cân điện tử";
				}
			}
            else
            {
				Variables.StatusInputType = StatusInputType.BANPHIM;
				string strStatusInputType = "BANPHIM";
				if (strStatusInputType != string.Empty)
				{
					if (strStatusInputType == "BANPHIM")
						lblStatus_Input_Type.Text = "Kiểu nhập: Từ bàn phím";
					else
						lblStatus_Input_Type.Text = "Kiểu nhập: Tự động từ cân điện tử";
				}
			}
                //lbtNote.Text = "Không tìm thấy thông tin cho đầu cân!!!. Vui lòng kiểm tra thông tin thiết bị!";
		}

		private void Build()
		{
			this.txtMa_Vt_Sp.bUseAutoDropDown = true;
			this.txtMa_Vt_Sp.strLookupKeyFilter = "Ma_Vt LIKE 'B%'";

			//DataGridView
			dgvCtNX_Barcode.strZone = "CTNX_BARCODE";
			dgvCtNX_Barcode.BuildGridView();

			//Danh mục sản phẩm
			DataTable dtDmSize = DataTool.SQLGetDataTable("R81DMSIZE", "", "", "Ma_Size");
			cboMa_Size.DataSource = dtDmSize;
			cboMa_Size.DisplayMember = "TEN_SIZE";
			cboMa_Size.ValueMember = "MA_SIZE";

			//Danh mục tiêu chuẩn
            DataTable dtDmStandard = DataTool.SQLGetDataTable("R81DMSTANDARD", "", "Used = 1", "Standard_ID");
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
				dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ma_Ca = '" + strMa_Ca + "' AND Loai LIKE 'CANGC%'", "");
			else
                dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ended = 0 AND Loai LIKE 'CANGC%'", "");

			//Lấy ca cuối cùng
			if (dtDmCa.Rows.Count == 0)
			{
                string strSQLExec = "SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Ma_Ca)) AS BIGINT)), 0) FROM R81DMCA WHERE YEAR(Ngay_Sx) = " + Voucher.GetDate_Server().Year + "" +
					" AND Ended = 1 AND Loai LIKE 'CANGC%'";
				string strMa_Ca_KT = Convert.ToString(SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text));
                dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ma_Ca = '" + strMa_Ca_KT + "' AND Loai LIKE 'CANGC%'", "");

				if (dtDmCa.Rows.Count == 0)
				{
					Common.MsgOk("Ca sản xuất chưa tồn tại. Vào tạo ca sản xuất");
				}
			}

			if (dtDmCa.Rows.Count > 0)
			{
				txtMa_Ca.Text = (string)dtDmCa.Rows[0]["Ma_Ca"];
				dteNgay_Sx.Text = Convert.ToString(dtDmCa.Rows[0]["Ngay_Sx"]);
				numSo_Ca.Value = Convert.ToDouble(dtDmCa.Rows[0]["So_Ca"]);
				txtCa.Text = (string)dtDmCa.Rows[0]["Ca"];
				numNum_Last.Value = Convert.ToDouble(dtDmCa.Rows[0]["Num_Last"]);
				txtXuong.Text = (string)dtDmCa.Rows[0]["Xuong"];
				txtTGian_Sx.Text = Convert.ToString(dtDmCa.Rows[0]["Gio_Begin"].ToString().Substring(0, 5)) + "-" + Convert.ToString(dtDmCa.Rows[0]["Gio_End"].ToString().Substring(0, 5));
				//txtTen_CbNv_TC.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_TC"]);
				txtTen_CbNv_KCS.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_KCS"]);
				txtTen_CbNv_Can.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_Can"]);

				//Build Ca Last Update
				txtMa_Vt_Sp.Text = (string)dtDmCa.Rows[0]["Ma_Vt_Sp_Last"];
				if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
					lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
				else
					lbtTen_Vt_Sp.Text = string.Empty;

				cboMa_Size.SelectedValue = (string)dtDmCa.Rows[0]["Ma_Size_Last"];
				cboGrade_ID.SelectedValue = (string)dtDmCa.Rows[0]["Grade_ID_Last"];
				cboMa_CL.SelectedValue = (string)dtDmCa.Rows[0]["Ma_CL_Last"];
				txtNo_Melt.Text = (string)dtDmCa.Rows[0]["No_Melt_Last"];
				cboLot_ID.SelectedValue = (string)dtDmCa.Rows[0]["Lot_ID_Last"];
				txtNum_Lot.Text = (string)dtDmCa.Rows[0]["Num_Lot_Last"];
				numLength.Value = Convert.ToDecimal(dtDmCa.Rows[0]["Length_Last"]);
				numNum_Bars.Value = Convert.ToDecimal(dtDmCa.Rows[0]["Num_Bars_Last"]);
                //BANG THEM
                numNum_Lot_Concat2.Value = Convert.ToInt16(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNumlotMax('"+txtMa_Ca.Text+"')"));

				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CA", txtMa_Ca.Text.Trim());

				dtCtNx_Barcode = SQLExec.ExecuteReturnDt("sp_GetDmBarcode", htPara, CommandType.StoredProcedure);
				bdsCtNx_Barcode.DataSource = dtCtNx_Barcode;
				dgvCtNX_Barcode.DataSource = bdsCtNx_Barcode;

				bdsCtNx_Barcode.Position = 0;

				//Get Row DmSize
				DataRow drDmSize = DataTool.SQLGetDataRowByID("R81DMSIZE", "Ma_Size", (string)dtDmCa.Rows[0]["Ma_Size_Last"]);
				if (drDmSize != null)
				{
					if(drDmSize["Ma_Size"].ToString().StartsWith("R"))
						dbMinWeight = 0;
					else
						dbMinWeight = drDmSize["MinWeight"] == DBNull.Value ? 40 : Convert.ToDouble(drDmSize["MinWeight"]);

					dbMaxWeight = drDmSize["MaxWeight"] == DBNull.Value ? 4000 : Convert.ToDouble(drDmSize["MaxWeight"]);
				}

				DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", (string)dtDmCa.Rows[0]["Ma_Vt_Sp_Last"]);
				if (drDmVt != null)
				{
					dbBarem_Standard = drDmVt["Barem_Standard"] == DBNull.Value ? 0 : Convert.ToDouble(drDmVt["Barem_Standard"]);
				}
				else
					dbBarem_Standard = 0;
               

                //Mặc định in eticket 
                string strGrade_ID_XK = Parameters.GetParaValue("MAC_THEP_XK_LIST").ToString();
                if ((Common.InlistLike(txtMa_Vt_Sp.Text.Trim(), "BR") || Common.Inlist(dtDmCa.Rows[0]["Grade_ID_Last"].ToString(),strGrade_ID_XK)))
                    cboLay_KL.SelectedIndex = 0;
                else
                    cboLay_KL.SelectedIndex = 1;
				
                //Get Row DmMacThep
                DataRow drDmMacThep = DataTool.SQLGetDataRowByID("vw_MacThepCt", "Grade_ID", (string)dtDmCa.Rows[0]["Grade_ID_Last"]);
				if (drDmMacThep != null)
				{
					cboStandard_ID.SelectedValue = drDmMacThep["Standard_ID"] == DBNull.Value ? string.Empty : drDmMacThep["Standard_ID"];
				}

				object objCode = this.GetNewCode();
				numCode.Value = Convert.ToInt32(objCode);

				object objNum_Lot = this.GetNewNum_Lot();
				txtNum_Lot.Text = objNum_Lot.ToString();

                
			}

			if (this.strMa_Ca != string.Empty)
			{
                string strSQLExec = "SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Ma_Ca)) AS BIGINT)), 0) FROM R81DMCA WHERE YEAR(Ngay_Sx) = " + Library.StrToDate(dteNgay_Sx.Text).Year + " AND Ended = 1 AND Loai LIKE 'CANGC%'";
				string strMa_Ca_KT = Convert.ToString(SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text));

				if (this.strMa_Ca != strMa_Ca_KT)
					isNotCurrent_Ca = true;
			}

			LoadCombo();
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
			txtMa_Vt_Sp.Enabled = cboMa_CL.Enabled = txtNo_Melt.Enabled = numNum_Last.Enabled =
			cboLot_ID.Enabled = numNum_Lot_Concat2.Enabled = chkEditInfo.Checked;

			//if (numLength.Value == 11.7M || numLength.Value == 12)
			//    numNum_Lot_Concat2.Enabled = false;
			//else
			//    numNum_Lot_Concat2.Enabled = chkEditInfo.Checked;
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
						this.Insert_Barcode();
						break;

					case WEIGHING_STATUS.OUT_OF_PRODUCT_RANGE:
						this.Count_Value();
						break;
				}
			}
		}

        private void Insert_Barcode()
		{
            
            string strBarcode = "";
            //object objNum_Lot = this.GetNewNum_Lot();
            //txtNum_Lot.Text = objNum_Lot.ToString();
            //KIEM TRA STANDAR_ID VÀ GRADE_ID
            string strGrade_Id = cboGrade_ID.SelectedValue.ToString();
            string strStandard_Id = cboStandard_ID.SelectedValue.ToString();
            string strStandard_Id_True = SQLExec.ExecuteReturnValue("SELECT MAX(Standard_ID) FROM vw_MacThepCt WHERE Grade_ID = '" + strGrade_Id + "'").ToString();
			//kiểm tra mã ca
			DateTime dteNgay_Sx = Convert.ToDateTime(DataTool.SQLGetNameByCode("R81DMCA","Ma_Ca", "Ngay_Sx", txtMa_Ca.Text));
			if (strStandard_Id != strStandard_Id_True)
            {
                Common.MsgCancel("Yêu cầu kiểm tra lại tiêu chuẩn của mác thép.");
                cboStandard_ID.Focus();
            }
            if (txtNum_Lot.Text.Length != 9 && dteNgay_Sx >= Library.StrToDate("01/01/2026"))
            {
                Common.MsgCancel("Lô sản phẩm phải chứa 9 ký tự");
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
                    Variables.iCode = Convert.ToInt32(objMax_Code) + 1;
                }

                double dbSo_Luong = 0.0;
                double dbSo_Luong_Barem = 0.0;
                bool bIs_Barem = false;

                if (cboLay_KL.SelectedIndex == 0)
                {
                    bIs_Barem = false;
                    dbSo_Luong = dbWeight;
                    //dbSo_Luong_Barem = Math.Round((double)((dbBarem_Standard * Convert.ToDouble(numLength.Value)) * Convert.ToDouble(numNum_Bars.Value)));
                    dbSo_Luong_Barem = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremBo('" + txtMa_Vt_Sp.Text + "',1,0)"));
                }
                else if (cboLay_KL.SelectedIndex == 1)
                {
                    bIs_Barem = true;
                    dbSo_Luong = dbWeight;
                    //dbSo_Luong_Barem = Math.Round((double)((dbBarem_Standard * Convert.ToDouble(numLength.Value)) * Convert.ToDouble(numNum_Bars.Value)));
                    dbSo_Luong_Barem = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremBo('" + txtMa_Vt_Sp.Text + "',1,0)"));
                }

                Hashtable htPara = new Hashtable();
                htPara.Add("STRNEW_EDIT", "N");
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
                htPara.Add("CODE", Variables.iCode);
                htPara.Add("SO_LUONG", dbSo_Luong);
                htPara.Add("SO_LUONG_BAREM", dbSo_Luong_Barem);
                htPara.Add("BEND_TEST", 1);
                htPara.Add("INPUT_TYPE", Variables.StatusInputType);
                htPara.Add("IS_BAREM", bIs_Barem);
                htPara.Add("IS_PRINT", true);
				htPara.Add("SO_CT_LXH", "GCPOM");
				htPara.Add("XUONG", txtXuong.Text.Trim());
				htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
                htPara.Add("MA_DATA", Element.sysMa_Data);

                strBarcode = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_DmBarcode", htPara, CommandType.StoredProcedure));

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
					
					numSo_Luong.Value = 0;// Convert.ToDouble(dbWeight);
					numSo_Luong_Barem.Value = 0;// Convert.ToDouble(dbSo_Luong_Barem);
                    lblBarcode.Text = strBarcode;

                    this.SetDataToDataGrid(strBarcode);
                    this.Print(strBarcode, bIs_Barem, true);
                    this.DisplaySummary();
                }
            }
			numSo_Luong.Focus();
            //numWeight_Scale.Focus();
            
           
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

			DataTable dtCurrent = SQLExec.ExecuteReturnDt("sp_GetDmBarcode", htPara, CommandType.StoredProcedure);
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
			Hashtable ht = new Hashtable();
			ht.Add("XUONG", txtXuong.Text);
			ht.Add("NAM", DateTime.Parse(dteNgay_Sx.Text).Year);
			string strSQLExec = @"SELECT Code FROM R81DMBARCODE T1 WITH(NOLOCK) JOIN (SELECT Ma_Ca FROM R81DMCA WITH(NOLOCK) " +
							" WHERE YEAR(Ngay_Sx) = @Nam AND Loai LIKE 'CANGC%' AND Xuong = @Xuong) T2 ON T1.Ma_Ca = T2.Ma_Ca" + @"
									WHERE T1.Code = " + iCode + " AND T1.SO_CT_LXH = 'GCPOM' AND T1.Barcode NOT LIKE 'L%'";

			object objCode = SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text);
			if (objCode == DBNull.Value || objCode == null)
				return false;

			return true;
		}

		private object GetNewCode()
		{
			Hashtable ht = new Hashtable();
			ht.Add("XUONG", txtXuong.Text);
			ht.Add("NAM", DateTime.Parse(dteNgay_Sx.Text).Year);

			string strSQLExec = @"SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Code)) AS BIGINT)), 0)
										FROM R81DMBARCODE T1 WITH(NOLOCK) JOIN (SELECT Ma_Ca FROM R81DMCA WITH(NOLOCK) WHERE YEAR(Ngay_Sx) = @Nam AND Xuong = @Xuong) T2 ON T1.Ma_Ca = T2.Ma_Ca " +
										"WHERE Barcode NOT LIKE 'L%' AND SO_CT_LXH = 'GCPOM'";

			object objCode = SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text);
			if (objCode == DBNull.Value || objCode == null)
				objCode = 0;

			if (Convert.ToInt32(objCode) > 10000000)
				objCode = 0;

			return objCode;
		}

		private object GetNewNum_Lot()
		{
			object strResult = string.Empty;
			string strSQLExec = string.Empty;
			int iCount_Barcode = 0;

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
				txtNum_Lot_Concat1.Text = dtNgay_Sx.Year.ToString().Substring(2, 2) + strNoi_Sx + objGrade_ID + numSo_Ca.Value.ToString().PadLeft(3, '0');
				strResult = dtNgay_Sx.Year.ToString().Substring(2, 2) + strNoi_Sx + objGrade_ID + numSo_Ca.Value.ToString().PadLeft(3, '0') + numNum_Lot_Concat2.Value.ToString().PadLeft(2, '0');
			}
			else
			{
				//Get Char Year Current
				if (string.IsNullOrEmpty(strChar_Year))
					strChar_Year = SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'NAM_SX' AND Type_ID = '" + dtNgay_Sx.Year + "'").ToString();
				txtNum_Lot_Concat1.Text = strChar_Year + objGrade_ID + numSo_Ca.Value.ToString().PadLeft(3, '0');
				strResult = strChar_Year + objGrade_ID + numSo_Ca.Value.ToString().PadLeft(3, '0') + numNum_Lot_Concat2.Value.ToString().PadLeft(2, '0');
			}



			//txtNum_Lot_Concat1.Text = strChar_Year + objGrade_ID + numSo_Ca.Value.ToString().PadLeft(3, '0');
			//strResult = strChar_Year + objGrade_ID + numSo_Ca.Value.ToString().PadLeft(3, '0') + numNum_Lot_Concat2.Value.ToString().PadLeft(2, '0');

			return strResult;
		}

		private decimal Calc_Num_Lot(int iCount_Barcode)
		{
			decimal dcValue = 0;

			if (iCount_Barcode <= 50)
				dcValue = 1;
			else if (iCount_Barcode <= 100)
				dcValue = 2;
			else if (iCount_Barcode <= 150)
				dcValue = 3;
			else if (iCount_Barcode <= 200)
				dcValue = 4;
			else if (iCount_Barcode <= 250)
				dcValue = 5;
			else if (iCount_Barcode <= 300)
				dcValue = 6;
			else if (iCount_Barcode <= 350)
				dcValue = 7;
			else if (iCount_Barcode <= 400)
				dcValue = 8;
			else if (iCount_Barcode <= 450)
				dcValue = 9;
			else if (iCount_Barcode <= 500)
				dcValue = 10;
			else if (iCount_Barcode <= 550)
				dcValue = 11;
			else if (iCount_Barcode <= 600)
				dcValue = 12;
			else if (iCount_Barcode <= 650)
				dcValue = 13;
			else if (iCount_Barcode <= 700)
				dcValue = 14;
			else if (iCount_Barcode <= 750)
				dcValue = 15;
			else if (iCount_Barcode <= 800)
				dcValue = 16;
			else if (iCount_Barcode <= 850)
				dcValue = 17;
			else if (iCount_Barcode <= 900)
				dcValue = 18;
			else if (iCount_Barcode <= 950)
				dcValue = 19;
			else if (iCount_Barcode <= 1000)
				dcValue = 20;

			return dcValue;
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
			if (enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtNx_Barcode.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtNx_Barcode.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtCtNx_Barcode.NewRow();
				drCurrent["MA_SIZE"] = cboMa_Size.SelectedValue;
				drCurrent["MA_VT_SP"] = txtMa_Vt_Sp.Text.Trim();
				drCurrent["MA_CA"] = txtMa_Ca.Text.Trim();
				drCurrent["STANDARD_ID"] = cboStandard_ID.SelectedValue;
				drCurrent["GRADE_ID"] = cboGrade_ID.SelectedValue;
				drCurrent["MA_CL"] = cboMa_CL.SelectedValue;
				drCurrent["NO_MELT"] = txtNo_Melt.Text.Trim();
				drCurrent["LOT_ID"] = cboLot_ID.SelectedValue;
				drCurrent["NUM_LOT"] = txtNum_Lot.Text.Trim();
				drCurrent["NUM_BARS"] = numNum_Bars.Value;
				drCurrent["LENGTH"] = numLength.Value;
			}

			//Check Permion
			if (!Element.sysIs_Admin)
			{
				if (enuNew_Edit != enuEdit.Edit && !Common.CheckPermission("ACCESS_NEW_BARCODE", enuPermission_Type.Allow_Access))
				{
					Common.MsgCancel("Bạn không có quyền thêm mới bó lẽ.");
					return;
				}
			}

			//Check Barcode Output?
			if (enuNew_Edit == enuEdit.Edit && DataTool.SQLCheckExist("R05CTX_BARCODE_KKV", "Barcode", drCurrent["Barcode"]))
			{
				Common.MsgYes_No("Mã vạch này được xuất rồi.Không sửa được.");
				return;
			}

			frmDmBarcode_Edit frm = new frmDmBarcode_Edit();
			frm.Load(enuNew_Edit, drCurrent);

			if (frm.isAccept)
			{
				if (frm.bPrint)
					Voucher.PrintBarcode(drCurrent["Barcode"].ToString(), Convert.ToBoolean(drCurrent["Is_Barem"]), false, Variables.strPrint_Barcode, true);

				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCtNx_Barcode.Position >= 0)
						dtCtNx_Barcode.ImportRow(drCurrent);
					else
						dtCtNx_Barcode.Rows.Add(drCurrent);

					bdsCtNx_Barcode.Position = bdsCtNx_Barcode.Find("BARCODE", drCurrent["BARCODE"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtNx_Barcode.Current).Row);

				dtCtNx_Barcode.AcceptChanges();

				this.DisplaySummary();
			}
		}

		public override void Delete()
		{
			if (isNotCurrent_Ca)
			{
				Common.MsgCancel("Bạn không xoá được dữ liệu trong ca sản xuất mà không phải là ca hiện tại");
				return;
			}

			//Check Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			if (bdsCtNx_Barcode.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCtNx_Barcode.Current).Row;

			string strBarcode = (string)drCurrent["Barcode"];


			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			//Check Barcode Output?
			if (DataTool.SQLCheckExist("R05CTX_BARCODE_KKV", "Barcode", strBarcode))
			{
				Common.MsgCancel("Mã vạch này được xuất rồi.Không xóa được");
				return;
			}

			//Checck Barcode have Try_ID?
			if (Convert.ToString(SQLExec.ExecuteReturnValue("SELECT TOP 1 Try_ID FROM R81DMBARCODE WITH(NOLOCK) WHERE Barcode = '" + strBarcode + "'")) != string.Empty)
			{
				Common.MsgCancel("Mã vạch này được cập nhật cơ tính rồi.Không xoá được");
				return;
			}
			
			if (SQLExec.Execute("sp_Delete_DmBarcode", drCurrent, CommandType.StoredProcedure))
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

				//object objNum_Lot = this.GetNewNum_Lot();
				//txtNum_Lot.Text = objNum_Lot.ToString();

				this.DisplaySummary();
			}
		}

		private void Print(string strBarcode, bool bIs_Barem, bool bPreview)
		{
			if(chkPrintTag.Checked)
				Voucher.PrintBarcode(strBarcode, bIs_Barem, false, Variables.strPrint_Barcode, true);
		}

		private void Design()
		{
            string strReport_File = "rptBarcode_TT";
            frmIn_Barcode frm1 = new frmIn_Barcode();
            frm1.Load();
            if (frm1.rdbND.Checked)
                strReport_File = strReport_File + "_ND";
            else if(frm1.rdbXK.Checked)
                strReport_File = strReport_File + "_XK";
            else if (frm1.rdbGC.Checked)
                strReport_File = strReport_File + "_GC";
			else if (frm1.rdbND_GC.Checked)
				strReport_File = strReport_File + "_ND_GC";
			else if (frm1.rdbXK_GC.Checked)
				strReport_File = strReport_File + "_XK_GC";


			RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strReport_File);
		}

		private void StringConvert(string strKeyCode, int iIndex)
		{
			string strText = "";
			strText = this.numWeight_Scale.AlphaText + strKeyCode.Substring(iIndex);

			//Nếu chuỗi lớn hơn 4 cho về 0
			if (strText.Length > 4)
				strText = strText.Substring(strText.Length - 4); 

			this.numWeight_Scale.Value = Convert.ToDouble(strText);
			this.dbWeight = Convert.ToDouble(this.numWeight_Scale.Value);
		}

		#endregion

		#region Event

		void HardwareInterface_DataReceive(double value, string type)
		{
			iValue_Weight = Convert.ToInt32(numWeight_Scale.Value);
			
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

		void chkEditInfo_CheckedChanged(object sender, EventArgs e)
		{
			this.LockEditInfo();
		}
		private void NumSo_Luong_Validated(object sender, EventArgs e)
		{
			Insert_Barcode();
			this.numSo_Luong.Value = 0;
		
		}
		void Update_Validated(object sender, EventArgs e)
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("MA_VT_SP_LAST", txtMa_Vt_Sp.Text.Trim());
			htPara.Add("MA_SIZE_LAST", cboMa_Size.SelectedValue == null ? string.Empty : cboMa_Size.SelectedValue);
			htPara.Add("GRADE_ID_LAST", cboGrade_ID.SelectedValue == null ? string.Empty : cboGrade_ID.SelectedValue);
			htPara.Add("MA_CL_LAST", cboMa_CL.SelectedValue == null ? string.Empty : cboMa_CL.SelectedValue);
			htPara.Add("NO_MELT_LAST", txtNo_Melt.Text.Trim());
			htPara.Add("LOT_ID_LAST", cboLot_ID.SelectedValue == null ? string.Empty : cboLot_ID.SelectedValue);
			htPara.Add("NUM_LOT_LAST", txtNum_Lot.Text.Trim());
			htPara.Add("LENGTH_LAST", numLength.Value);
			htPara.Add("NUM_BARS_LAST", numNum_Bars.Value);
			htPara.Add("MA_CA", txtMa_Ca.Text.Trim());
			htPara.Add("NUM_LAST", numNum_Last.Value);

			string strSQLExec = @"UPDATE R81DMCA SET Ma_Vt_Sp_Last = @Ma_Vt_Sp_Last, Ma_Size_Last = @Ma_Size_Last, Grade_ID_Last = @Grade_ID_Last, " +
						" Ma_Cl_Last = @Ma_Cl_Last, No_Melt_Last = @No_Melt_Last, Lot_ID_Last = @Lot_ID_Last, Num_Lot_Last = @Num_Lot_Last, Length_Last = @Length_Last, " +
						" Num_Bars_Last = @Num_Bars_Last, Num_Last = @Num_Last WHERE Ma_Ca = @Ma_Ca";
			
			SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
		}

		void numNum_Lot_Concat2_ValueChanged(object sender, EventArgs e)
		{
			object objNum_Lot = this.GetNewNum_Lot();
			txtNum_Lot.Text = objNum_Lot.ToString();

			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CA", txtMa_Ca.Text.Trim());
			htPara.Add("NUM_LAST", numNum_Last.Value);
			string strSQLExec = @"UPDATE R81DMCA SET Num_Last = @Num_Last WHERE Ma_Ca = @Ma_Ca";

			SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
		}
		private void NumNum_Last_Validated(object sender, EventArgs e)
		{
			object objNum_Lot = this.GetNewNum_Lot();
			txtNum_Lot.Text = objNum_Lot.ToString();

		}
		void numCode_Validated(object sender, EventArgs e)
		{
			//Bang kiểm tra code max
			int iCodeMax = 0;
			if ((SQLExec.ExecuteReturnValue("SELECT MAX(Code) FROM R81DMBARCODE T1 WITH(NOLOCK) JOIN (SELECT Ma_Ca FROM R81DMCA WITH(NOLOCK) " + @"
                      WHERE Loai = 'CANGC' AND YEAR(Ngay_Sx) = " + DateTime.Parse(dteNgay_Sx.Text).Year + ") T2 ON T1.Ma_Ca = T2.Ma_Ca WHERE Barcode NOT LIKE 'L%' AND So_Ct_LXH <> '' ")) != DBNull.Value)
				
				iCodeMax = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT MAX(Code) FROM R81DMBARCODE T1 WITH(NOLOCK) JOIN (SELECT Ma_Ca FROM R81DMCA WITH(NOLOCK) " + @"
                      WHERE Loai = 'CANGC' AND YEAR(Ngay_Sx) = " + DateTime.Parse(dteNgay_Sx.Text).Year + ") T2 ON T1.Ma_Ca = T2.Ma_Ca WHERE Barcode NOT LIKE 'L%' AND So_Ct_LXH <> '' "));
            
            int iCode = Convert.ToInt32(numCode.Value) + 1;
            int iValue = 500;
            if (iCode > iCodeMax + iValue)
            {
                if (!Common.MsgYes_No("Số bó {" + iCode + "} đã vượt " + iValue + " bó so với bó lớn nhất trong năm. Yêu cầu kiểm tra lại. Bạn muốn tiếp tục không", "N"))
                {
                    numCode.Value = iCodeMax;
                    iCode = Convert.ToInt32(numCode.Value) + 1;
                }
            }
            
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

		void btNew_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.New);
		}

		void btPrint_Click(object sender, EventArgs e)
		{
			if (bdsCtNx_Barcode.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCtNx_Barcode.Current).Row;

			this.Print(drCurrent["Barcode"].ToString(), Convert.ToBoolean(drCurrent["Is_Barem"]), false);
		}

		void frmCtNXTT_FormClosed(object sender, FormClosedEventArgs e)
		{
			HardwareInterface.DataReceive -= new DataEventHandler(this.HardwareInterface_DataReceive);
			this.Dispose();
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			this.Delete();
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "Ma_Vt LIKE 'B%'");

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
				{
					cboMa_Size.SelectedValue = drDmSize["Ma_Size"] == DBNull.Value ? string.Empty : drDmSize["Ma_Size"];
					dbMinWeight = drDmSize["MinWeight"] == DBNull.Value ? 40 : Convert.ToDouble(drDmSize["MinWeight"]);
					dbMaxWeight = drDmSize["MaxWeight"] == DBNull.Value ? 4000 : Convert.ToDouble(drDmSize["MaxWeight"]);
				}

				//Get Row DmMacThep
                DataRow drDmMacThep = DataTool.SQLGetDataRowByID("vw_MacThepCt", "Grade_ID", (string)drLookup["Grade_ID"]);
				if (drDmMacThep != null)
				{
					cboGrade_ID.SelectedValue = drDmMacThep["Grade_ID"] == DBNull.Value ? string.Empty : drDmMacThep["Grade_ID"];
					cboStandard_ID.SelectedValue = drDmMacThep["Standard_ID"] == DBNull.Value ? string.Empty : drDmMacThep["Standard_ID"];
				}
                



			}

			//if (numLength.Value == 11.7M || numLength.Value == 12)
			//    numNum_Lot_Concat2.Enabled = false;
			//else
			//    numNum_Lot_Concat2.Enabled = chkEditInfo.Checked;
			if (strMa_Vt_Sp != txtMa_Vt_Sp.Text)
			{
				DataRow drDmSpCu = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", strMa_Vt_Sp);
				DataRow drDmSpMoi = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", txtMa_Vt_Sp.Text);
				if (drDmSpCu["Ma_Size"].ToString() != drDmSpMoi["Ma_Size"].ToString() || drDmSpCu["Grade_ID"].ToString() != drDmSpMoi["Grade_ID"].ToString())
					numNum_Last.Value = numNum_Last.Value + 1;
			}

			object objNum_Lot = this.GetNewNum_Lot();
			txtNum_Lot.Text = objNum_Lot.ToString();
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
					this.Print(((DataRowView)bdsCtNx_Barcode.Current).Row["Barcode"].ToString(), Convert.ToBoolean(((DataRowView)bdsCtNx_Barcode.Current).Row["Is_Barem"]), false);
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
       

        void dgvCtNX_Barcode_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvCtNX_Barcode;
        }

		private void NumSo_Luong_Enter(object sender, EventArgs e)
		{
			if (Variables.StatusInputType == StatusInputType.BANPHIM && numSo_Luong.Value > 0 && numSo_Luong.Value < 4000)
			{
				this.dbWeight = this.numWeight_Scale.Value;
                //if (!Common.MsgYes_No("Bạn có muốn nhập bó thép này không?", "Y"))
                //    return;

                this.Set_Weighing_Status(this.dbWeight);
                switch (this.myWeighingStatus)
                {
                    case WEIGHING_STATUS.GOOD:
                        this.Insert_Barcode();
                        this.numWeight_Scale.Value = 0;
                        break;

                    case WEIGHING_STATUS.OUT_OF_PRODUCT_RANGE:
                        this.Count_Value();
                        this.numWeight_Scale.Value = 0;
                        break;
                }
            }
		}


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
                        //frm.Load("Scale6080");
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

				//case Keys.F9:
				//	switch (Variables.StatusInputType)
				//	{
				//		case StatusInputType.CANDTTUDONG:
				//			Variables.StatusInputType = StatusInputType.BANPHIM;
				//			this.lblStatus_Input_Type.Text = "Kiểu nhập: Từ bàn phím";
				//			break;

				//		case StatusInputType.BANPHIM:
				//			if (this.txtNum_Lot.Text != string.Empty)
				//			{
				//				this.ResetScale();
				//				this.bCurrent_State = false;
				//				Variables.StatusInputType = StatusInputType.CANDTTUDONG;
				//				this.lblStatus_Input_Type.Text = "Kiểu nhập: Tự động từ cân điện tử";
				//				break;
				//			}
				//			Common.MsgCancel("Bạn phải nhập lô sản phẩm mới chuyển được sang chế độ tự động");
				//			this.txtNum_Lot.Focus();
				//			return;
				//	}
				//	return;
					
				case Keys.F10:
					this.numWeight_Scale.Value = 0;
					this.numWeight_Scale.Focus();
					return;

				//case Keys.Enter:
				//	if (Variables.StatusInputType != StatusInputType.CANDTTUDONG)
				//	{
				//		this.dbWeight = this.numWeight_Scale.Value;
				//		if (!Common.MsgYes_No("Bạn có muốn nhập bó thép này không?","Y"))
				//			return;

				//		this.Set_Weighing_Status(this.dbWeight);
				//		switch (this.myWeighingStatus)
				//		{
				//			case WEIGHING_STATUS.GOOD:
				//				this.Insert_Barcode();
				//				this.numWeight_Scale.Value = 0;
				//				break;

				//			case WEIGHING_STATUS.OUT_OF_PRODUCT_RANGE:
				//				this.Count_Value();
				//				this.numWeight_Scale.Value = 0;
				//				break;
				//		}
				//	}
				//	return;
			}

            if (Variables.StatusInputType == StatusInputType.BANPHIM)
            {
				if(chkEditInfo.Checked == false)
				{ 
					if (((e.KeyCode >= Keys.D0) & (e.KeyCode <= Keys.D9)))
						this.StringConvert(e.KeyCode.ToString(), 1);

					if (((e.KeyCode >= Keys.NumPad0) & (e.KeyCode <= Keys.NumPad9)))
						this.StringConvert(e.KeyCode.ToString(), 6);
				}
			}

            base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
			LockEditInfo();
			lblBarcode.Text = "";
            //cboLay_K.SelectedIndex = 0;
		}

		private enum WEIGHING_STATUS
		{
			GOOD,
			OUT_OF_PRODUCT_RANGE,
			OUT_OF_SCALE_RANGE
		}

        //private void frmCtNXTH_Load(object sender, EventArgs e)
        //{

        //}

	}
}
