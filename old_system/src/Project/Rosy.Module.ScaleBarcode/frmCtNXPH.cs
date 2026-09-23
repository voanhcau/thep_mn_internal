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
	public partial class frmCtNXPH : RosySystem.Customize.frmView
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
        
        bool bCan = false;
        string strMsg1 = "Bạn đang trong tình trạng chưa cân, nhấn F6 để cân";
        string strMsg2 = "Bạn đang trong tình trạng cân, nhấn F6 để dừng cân";
        string strMsg3 = "Bạn đang trong tình trạng TEST cân";
        string strMsg4 = "Bạn đang trong tình trạng nhập bằng tay";

        string strNum_Lot = string.Empty;
		string strMa_Ca = string.Empty;
		string strChar_Year = string.Empty;
        

		WEIGHING_STATUS myWeighingStatus = WEIGHING_STATUS.OUT_OF_SCALE_RANGE;
		Hashtable htWeights = new Hashtable();
		Hashtable htMaxWeights = new Hashtable();

		BindingSource bdsCtNx_Barcode = new BindingSource();
		DataTable dtCtNx_Barcode;
		DataRow drCurrent;


        BindingSource bdsTestCan = new BindingSource();
        DataTable dtTestCan;

        BindingSource bdsBarcodeTB = new BindingSource();
        DataTable dtBarcodeTB;

        enuEdit enuNew_Edit_Voucher = enuEdit.New;

		#endregion

		#region Constructor

        public frmCtNXPH()
		{
			InitializeComponent();

			this.InitDevice();

			this.tmOverWeight.Tick += new EventHandler(tmOverWeight_Tick);
			this.chkEditInfo.CheckedChanged += new EventHandler(chkEditInfo_CheckedChanged);
			this.FormClosed += new FormClosedEventHandler(frmCtNXTT_FormClosed);
			this.btExit.Click += new EventHandler(btExit_Click);
			
			this.numCode.Validated += new EventHandler(numCode_Validated);
			

			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
            this.txtMa_Vt_Sp.Validated += new EventHandler(Update_Validated);
           
            this.txtSo_Me.Validated+=new EventHandler(Update_Validated);
            this.numBQ_Phoi.Validated += new EventHandler(Update_Validated);     
			
			this.dgvCtNX_Barcode.CellDoubleClick += new DataGridViewCellEventHandler(dgvCtNX_Barcode_CellDoubleClick);
			this.dgvCtNX_Barcode.KeyDown += new KeyEventHandler(dgvCtNX_Barcode_KeyDown);
            //this.btPrint.Click += new EventHandler(btPrint_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);

            this.btTang.Click += new EventHandler(btTang_Click);
            this.btGiam.Click += new EventHandler(btGiam_Click);

            btNewTestCan.Click += new EventHandler(btNewTestCan_Click);
            btCbTest.Click += new EventHandler(btCbTest_Click);
		}

     

        
		new public void Load()
		{
			this.Build();
			this.FillData();
			this.DisplaySummary();

			this.BindingLanguage();
			this.LoadDicName();

            this.lblTrangThai.Text = strMsg1;
            ShowTrangThai();

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
		}

		private void Build()
		{
			this.txtMa_Vt_Sp.bUseAutoDropDown = true;

			//DataGridView
			dgvCtNX_Barcode.strZone = "CTNX_BARCODEPHOI";
			dgvCtNX_Barcode.BuildGridView();

            dgvTestCan.strZone = "TESTCAN";
            dgvTestCan.BuildGridView();

            dgvBarcodeTB.strZone = "CTNX_BARCODEPHOITB";
            dgvBarcodeTB.BuildGridView();

            if (dgvCtNX_Barcode.Columns.Contains("MA_VT_SP"))
                dgvCtNX_Barcode.Columns["MA_VT_SP"].Visible = false;

            if (dgvCtNX_Barcode.Columns.Contains("TEN_VT"))
                dgvCtNX_Barcode.Columns["TEN_VT"].Visible = false;

            if (dgvBarcodeTB.Columns.Contains("MA_VT_SP"))
                dgvBarcodeTB.Columns["MA_VT_SP"].Visible = false;
		}

		private void FillData()
		{
			//Danh mục ca
			DataTable dtDmCa = new DataTable();
			if (this.strMa_Ca != string.Empty)
				dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ma_Ca = '" + strMa_Ca + "' AND Loai = 'LUYEN'", "");
			else
                dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ended = 0 AND Loai = 'LUYEN'", "");

			//Lấy ca cuối cùng
			if (dtDmCa.Rows.Count == 0)
			{
                string strSQLExec = "SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Ma_Ca)) AS BIGINT)), 0) FROM R81DMCA WHERE YEAR(Ngay_Sx) = " + Voucher.GetDate_Server().Year + " AND Ended = 1 AND Loai = 'LUYEN'";
				string strMa_Ca_KT = Convert.ToString(SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text));
                dtDmCa = DataTool.SQLGetDataTable("R81DMCA", "", "Ma_Ca = '" + strMa_Ca_KT + "' AND Loai = 'LUYEN'", "");

				if (dtDmCa.Rows.Count == 0)
				{
					Common.MsgOk("Ca sản xuất chưa tồn tại. Vào tạo ca sản xuất");
				}
			}

			if (dtDmCa.Rows.Count > 0)
			{
				txtMa_Ca.Text = (string)dtDmCa.Rows[0]["Ma_Ca"];
				dteNgay_Sx.Text = Convert.ToString(dtDmCa.Rows[0]["Ngay_Sx"]);
                //numSo_Ca.Value = Convert.ToDouble(dtDmCa.Rows[0]["So_Ca"]);
				txtCa.Text = (string)dtDmCa.Rows[0]["Ca"];
				txtTGian_Sx.Text = Convert.ToString(dtDmCa.Rows[0]["Gio_Begin"].ToString().Substring(0, 5)) + "-" + Convert.ToString(dtDmCa.Rows[0]["Gio_End"].ToString().Substring(0, 5));
				txtTen_CbNv_TC.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_TC"]);
                txtTen_CbNv_KCS.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_KCS"]);
				txtTen_CbNv_Can.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", (string)dtDmCa.Rows[0]["Ma_Dt_CbNv_Can"]);

				//Build Ca Last Update
				txtMa_Vt_Sp.Text = (string)dtDmCa.Rows[0]["Ma_Vt_Sp_Last"];
				if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
					lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
				else
					lbtTen_Vt_Sp.Text = string.Empty;

               
				txtSo_Me.Text = (string)dtDmCa.Rows[0]["No_Melt_Last"];
                numBQ_Phoi.Value = Convert.ToDouble(dtDmCa.Rows[0]["Length_Last"]);

				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CA", txtMa_Ca.Text.Trim());

				dtCtNx_Barcode = SQLExec.ExecuteReturnDt("sp_GetDmBarcodePH", htPara, CommandType.StoredProcedure);
				bdsCtNx_Barcode.DataSource = dtCtNx_Barcode;
				dgvCtNX_Barcode.DataSource = bdsCtNx_Barcode;

				bdsCtNx_Barcode.Position = 0;

				DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", (string)dtDmCa.Rows[0]["Ma_Vt_Sp_Last"]);
				if (drDmVt != null)
				{
					dbBarem_Standard = drDmVt["Barem_Standard"] == DBNull.Value ? 0 : Convert.ToDouble(drDmVt["Barem_Standard"]);
				}
				else
					dbBarem_Standard = 0;
               

               

				object objCode = this.GetNewCode();
				numCode.Value = Convert.ToInt32(objCode);

            

                //DM TEST CAN
                Hashtable htPara1 = new Hashtable();
                htPara1.Add("MA_CA", txtMa_Ca.Text.Trim());

                dtTestCan = SQLExec.ExecuteReturnDt("sp_GetTestCan", htPara1, CommandType.StoredProcedure);
                bdsTestCan.DataSource = dtTestCan;
                dgvTestCan.DataSource = bdsTestCan;

                FillDataMe();
                //bdsTestCan.Position = 0;
                

			}
           
			if (this.strMa_Ca != string.Empty)
			{
                string strSQLExec = "SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Ma_Ca)) AS BIGINT)), 0) FROM R81DMCA WHERE YEAR(Ngay_Sx) = " + Library.StrToDate(dteNgay_Sx.Text).Year + " AND Ended = 1 AND Loai = 'LUYEN'";
				string strMa_Ca_KT = Convert.ToString(SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text));

				if (this.strMa_Ca != strMa_Ca_KT)
					isNotCurrent_Ca = true;
			}
		}
        private void FillDataMe()
        {
            //tổng hợp BARCODE
            Hashtable htPara2 = new Hashtable();
            htPara2.Add("MA_CA", txtMa_Ca.Text.Trim());
            htPara2.Add("SO_ME", txtSo_Me.Text.Trim());

            dtBarcodeTB = SQLExec.ExecuteReturnDt("sp_GetBarcodePHTB", htPara2, CommandType.StoredProcedure);
            bdsBarcodeTB.DataSource = dtBarcodeTB;
            dgvBarcodeTB.DataSource = bdsBarcodeTB;
        }
        private void AutoTangMe()
        {
            if (chkAuto_Me.Checked == true && numTCay_Me.Value > 0)
            {
                if (dtBarcodeTB.Select("So_Me =  '" + txtSo_Me.Text + "' AND So_Cay = " + numTCay_Me.Value + "").Length > 0)
                { TangGiamMe(true); numTCay_Me.Value = 0; }
            }
        }
		private void LoadDicName()
		{
			this.dgvCtNX_Barcode.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCtNX_Barcode.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvCtNX_Barcode.Columns.Contains("SO_LUONG"))
				dgvCtNX_Barcode.Columns["SO_LUONG"].HeaderText = "Khối lượng";

            if (dgvCtNX_Barcode.Columns.Contains("BQ_PHOI"))
                dgvCtNX_Barcode.Columns["BQ_PHOI"].HeaderText = "Loại phôi cắt";

            if (txtMa_Vt_Sp.Text != string.Empty)
            {
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", txtMa_Vt_Sp.Text);
                txtLoai_Phoi.Text = drDmVt["Loai_Phoi"].ToString();
                txtMac_Thep.Text = drDmVt["Mac_Thep"].ToString();
            }
		}
        private void ShowTrangThai()
        {
            if (lblTrangThai.Text == strMsg1)
            {
                this.lblTrangThai.BackColor = Color.Red;
                this.lblTrangThai.ForeColor = Color.White;
            }
            else if (lblTrangThai.Text == strMsg2)
            {
                this.lblTrangThai.BackColor = Color.Green;
                this.lblTrangThai.ForeColor = Color.Black;
                btCbTest.Text = "Chuẩn bị Test cân";
            }
            else if (lblTrangThai.Text == strMsg3)
            {
                this.lblTrangThai.BackColor = Color.Yellow;
                this.lblTrangThai.ForeColor = Color.DarkRed;
            }
            else if (lblTrangThai.Text == strMsg4)
            {
                lblTrangThai.ForeColor = Color.Green;
                lblTrangThai.BackColor = Color.Yellow;
            }
        }
		private void LockEditInfo(bool bCheck)
		{
            txtMa_Vt_Sp.Enabled = txtSo_Me.Enabled = bCheck;

            txtLoai_Phoi.Enabled = txtMac_Thep.Enabled = false;
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
            if (!bTestCan)
            {
                if (bCan)
                {
                    string strBarcode = "";
                   
                    Variables.iCode = (int)this.numCode.Value;
                    Variables.iCode++;
                    if (this.CheckExistsCode(Variables.iCode))
                    {
                        object objMax_Code = this.GetNewCode();
                        Common.MsgCancel("Đã có bó " + Variables.iCode + ", chương trình sẽ tự động nhập vào bó " + objMax_Code + 1);
                        Variables.iCode = Convert.ToInt32(objMax_Code) + 1;
                    }

                    double dbSo_Luong = dbWeight;


              

                    Hashtable htPara = new Hashtable();
                    htPara.Add("STRNEW_EDIT", "N");
                    
                    htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text.Trim());
                    htPara.Add("MA_CA", txtMa_Ca.Text.Trim());
                 
                    htPara.Add("SO_ME", txtSo_Me.Text.Trim());
                    
                    htPara.Add("CODE", Variables.iCode);
                    htPara.Add("SO_LUONG", dbSo_Luong);
                    htPara.Add("BQ_PHOI", numBQ_Phoi.Value);
                   
                    htPara.Add("INPUT_TYPE", (Variables.StatusInputType == StatusInputType.BANPHIM) ? 0 : 1);
                    htPara.Add("IS_NONG", chkIs_Nong.Checked);
                    
                    htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
                    htPara.Add("MA_DATA", Element.sysMa_Data);

                    strBarcode = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_DmBarcodePH", htPara, CommandType.StoredProcedure));

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
                        //numSo_Luong_Barem.Value = Convert.ToDouble(dbSo_Luong_Barem);
                        lblBarcode.Text = strBarcode;

                        this.SetDataToDataGrid(strBarcode);
                        
                        this.DisplaySummary();
                    }
                    //}

                    numWeight_Scale.Focus();
                }
            }
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

			DataTable dtCurrent = SQLExec.ExecuteReturnDt("sp_GetDmBarcodePH", htPara, CommandType.StoredProcedure);
			if (dtCurrent.Rows.Count > 0)
			{
				DataRow drAddCurrent = dtCurrent.Rows[0];

				DataRow drEditCtNew = dtCtNx_Barcode.NewRow();
				Common.CopyDataRow(drAddCurrent, drEditCtNew);
				Common.SetDefaultDataRow(ref drEditCtNew);

				dtCtNx_Barcode.Rows.Add(drEditCtNew);
				drEditCtNew.AcceptChanges();


                //DataRow drEditCtNew1 = new DataRow();
                //DataRow drBarcodeTB = new DataRow();
                ////tới xử lý dòng tổng
                //if (dtBarcodeTB.Rows.Count == 0 || dtBarcodeTB.Select("So_Me = '"+ txtSo_Me.Text +"'").Length == 0)
                //{
                //    drBarcodeTB = dtCurrent.Rows[0];
                //    drBarcodeTB["So_Cay"] = 1;
                //    drBarcodeTB["So_Luong_TB"] = drBarcodeTB["So_Luong"];
                   
                //    drEditCtNew1 = dtBarcodeTB.NewRow();
                //    Common.CopyDataRow(drBarcodeTB, drEditCtNew1);
                //    Common.SetDefaultDataRow(ref drEditCtNew1);

                //    dtBarcodeTB.Rows.Add(drEditCtNew1);
                //    drEditCtNew1.AcceptChanges();
                //}
                //else
                //{
                //    drEditCtNew1 = dtBarcodeTB.Select("So_Me = '"+ txtSo_Me.Text +"'");
                //}

			}

			bdsCtNx_Barcode.Sort = "BARCODE DESC";
			bdsCtNx_Barcode.Position = 0;

            FillDataMe();
            AutoTangMe();
		}

		private void DisplaySummary()
		{
            if (dtCtNx_Barcode.Rows.Count > 0)
            {
                numTSo_Luong.Value = Common.SumDCValue(dtCtNx_Barcode, "So_Luong", "");
                numCount_Coils.Value = dtCtNx_Barcode.Rows.Count;
            }
		}

		private bool CheckExistsCode(int iCode)
		{
			string strSQLExec = @"SELECT Code FROM R81DMBARCODEPH T1 WITH(NOLOCK) JOIN (SELECT Ma_Ca FROM R81DMCA WITH(NOLOCK) WHERE YEAR(Ngay_Sx) = " + DateTime.Parse(dteNgay_Sx.Text).Year + ") T2 ON T1.Ma_Ca = T2.Ma_Ca" + @"
									WHERE T1.Code = " + iCode + " ";

			object objCode = SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text);
			if (objCode == DBNull.Value || objCode == null)
				return false;

			return true;
		}

		private object GetNewCode()
		{
			string strSQLExec = @"SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Code)) AS BIGINT)), 0)
										FROM R81DMBARCODEPH T1 WITH(NOLOCK) JOIN (SELECT Ma_Ca FROM R81DMCA WITH(NOLOCK) WHERE YEAR(Ngay_Sx) = " + DateTime.Parse(dteNgay_Sx.Text).Year + ") T2 ON T1.Ma_Ca = T2.Ma_Ca";

			object objCode = SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text);
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

            //object objGrade_ID = cboGrade_ID.SelectedValue == null ? string.Empty : cboGrade_ID.SelectedValue;
			
			//Get Char Year Current
			if(string.IsNullOrEmpty(strChar_Year))
				strChar_Year = SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'NAM_SX' AND Type_ID = '" + Voucher.GetDate_Server().Year + "'").ToString();
			
			////Chua tim ra giai thuat de tu dong cong so lo vao
			//if (numLength.Value == 11.7M || numLength.Value == 12M)
			//{
			//    strSQLExec = @"SELECT ISNULL(COUNT(Barcode), 0) + 1 FROM R81DMBARCODEPH WITH(NOLOCK) WHERE Ma_Ca = '" + txtMa_Ca.Text.Trim() + "' AND Grade_ID = '" + objGrade_ID + "' AND Length = " + numLength.Value + "";

			//    object objValue = SQLExec.ExecuteReturnValue(strSQLExec);
			//    if (objValue == null && objValue.ToString() == string.Empty)
			//        iCount_Barcode = 1;
			//    else
			//        iCount_Barcode = Convert.ToInt32(objValue);

			//    numNum_Lot_Concat2.Value = this.Calc_Num_Lot(iCount_Barcode);
			//    txtNum_Lot_Concat1.Text = strChar_Year + objGrade_ID + numSo_Ca.Value;

			//    strResult = strChar_Year + objGrade_ID + numSo_Ca.Value + numNum_Lot_Concat2.Value.ToString().PadLeft(2, '0');
			//}
			//else
			//{
			//    txtNum_Lot_Concat1.Text = strChar_Year + objGrade_ID + numSo_Ca.Value;
			//    strResult = strChar_Year + objGrade_ID + numSo_Ca.Value + numNum_Lot_Concat2.Value.ToString().PadLeft(2, '0');
			//}

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
                
				drCurrent["MA_VT_SP"] = txtMa_Vt_Sp.Text.Trim();
				drCurrent["MA_CA"] = txtMa_Ca.Text.Trim();
               
               
				drCurrent["SO_ME"] = txtSo_Me.Text.Trim();
              
			}

			//Check Permion
            //if (!Element.sysIs_Admin)
            //{
            //    if (enuNew_Edit != enuEdit.Edit && !Common.CheckPermission("ACCESS_NEW_BARCODE", enuPermission_Type.Allow_Access))
            //    {
            //        Common.MsgCancel("Bạn không có quyền thêm mới bó lẽ.");
            //        return;
            //    }
            //}

			//Check Barcode Output?
            //if (enuNew_Edit == enuEdit.Edit && DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", drCurrent["Barcode"]))
            //{
            //    Common.MsgYes_No("Mã vạch này được xuất rồi.Không sửa được.");
            //    return;
            //}

			frmDmBarcodePH_Edit frm = new frmDmBarcodePH_Edit();
			frm.Load(enuNew_Edit, drCurrent);

			if (frm.isAccept)
			{
                //if (frm.bPrint)
                //    Voucher.PrintBarcode(drCurrent["Barcode"].ToString(), Convert.ToBoolean(drCurrent["Is_Barem"]), false, Variables.strPrint_Barcode);

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

            ////Check Barcode Output?
            //if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", strBarcode))
            //{
            //    Common.MsgCancel("Mã vạch này được xuất rồi.Không xóa được");
            //    return;
            //}

            ////Checck Barcode have Try_ID?
            //if (Convert.ToString(SQLExec.ExecuteReturnValue("SELECT TOP 1 Try_ID FROM R81DMBARCODEPH WITH(NOLOCK) WHERE Barcode = '" + strBarcode + "'")) != string.Empty)
            //{
            //    Common.MsgCancel("Mã vạch này được cập nhật cơ tính rồi.Không xoá được");
            //    return;
            //}
			
			if (SQLExec.Execute("sp_Delete_DmBarcodePH", drCurrent, CommandType.StoredProcedure))
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
            this.LockEditInfo(chkEditInfo.Checked);
		}

        void Update_Validated(object sender, EventArgs e)
        {
            UpdateDmCa();
        }

        void UpdateDmCa()
        {
            Hashtable htPara = new Hashtable();
            htPara.Add("MA_VT_SP_LAST", txtMa_Vt_Sp.Text.Trim());
            htPara.Add("NO_MELT_LAST", txtSo_Me.Text.Trim());
            htPara.Add("LENGTH_LAST", numBQ_Phoi.Value);
            htPara.Add("MA_CA", txtMa_Ca.Text.Trim());

            string strSQLExec = @"UPDATE R81DMCA SET Ma_Vt_Sp_Last = @Ma_Vt_Sp_Last, No_Melt_Last = @No_Melt_Last, Length_Last = @Length_Last WHERE Ma_Ca = @Ma_Ca";
            SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
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


        //void btPrint_Click(object sender, EventArgs e)
        //{
        //    if (bdsCtNx_Barcode.Position < 0)
        //        return;

        //    drCurrent = ((DataRowView)bdsCtNx_Barcode.Current).Row;

        //    this.Print(drCurrent["Barcode"].ToString(), Convert.ToBoolean(drCurrent["Is_Barem"]), false);
        //}

		void frmCtNXTT_FormClosed(object sender, FormClosedEventArgs e)
		{
			HardwareInterface.DataReceive -= new DataEventHandler(this.HardwareInterface_DataReceive);
			this.Dispose();
		}
        void btGiam_Click(object sender, EventArgs e)
        {
            TangGiamMe(false);
        }

        void btTang_Click(object sender, EventArgs e)
        {
            TangGiamMe(true);
        }
        void TangGiamMe(bool bTang)
        {
            if (txtSo_Me.Text != string.Empty)
            {
                int iSoMe = Convert.ToInt16(txtSo_Me.Text.Substring(2, txtSo_Me.Text.Length - 2));
                if (bTang)
                    iSoMe++;
                else
                    iSoMe--;

				if (iSoMe < 10)
					txtSo_Me.Text = txtSo_Me.Text.Substring(0, 2) + "0000" + iSoMe.ToString();
				else if (iSoMe < 100)
                    txtSo_Me.Text = txtSo_Me.Text.Substring(0, 2)+ "000" + iSoMe.ToString();
                else if(iSoMe < 1000)
                    txtSo_Me.Text = txtSo_Me.Text.Substring(0, 2) +"00" + iSoMe.ToString();
				else if (iSoMe < 10000)
					txtSo_Me.Text = txtSo_Me.Text.Substring(0, 2) + "0" + iSoMe.ToString();
				else
                    txtSo_Me.Text = txtSo_Me.Text.Substring(0, 2) + iSoMe.ToString();
                
                UpdateDmCa();
            }
        }
		void btDelete_Click(object sender, EventArgs e)
		{
			this.Delete();
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "Ma_Nh_Vt = 'PHOI'");

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
                txtLoai_Phoi.Text = drLookup["Loai_Phoi"].ToString();
                txtMac_Thep.Text =  drLookup["Mac_Thep"].ToString();

               
			}

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
                    //this.Print(((DataRowView)bdsCtNx_Barcode.Current).Row["Barcode"].ToString(), Convert.ToBoolean(((DataRowView)bdsCtNx_Barcode.Current).Row["Is_Barem"]), false);
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
        void dgvTestCan_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTestCan;
        }

        void dgvCtNX_Barcode_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvCtNX_Barcode;
        }
        void btNewTestCan_Click(object sender, EventArgs e)
        {
            Edit_TestCan(enuEdit.New);
        }
        void btCbTest_Click(object sender, EventArgs e)
        {
            if (btCbTest.Text == "Chuẩn bị Test cân")
            {
                bTestCan = true;
                bCan = false;
                btCbTest.Text = "Thoát Test cân";
                this.lblTrangThai.Text = strMsg3;
                ShowTrangThai();
               
            }
            else if (btCbTest.Text == "Thoát Test cân")
            {
                bTestCan = false;
                bCan = false;
                btCbTest.Text = "Chuẩn bị Test cân";
                this.lblTrangThai.Text = strMsg1;

                this.lblTrangThai.BackColor = Color.Red;
                this.lblTrangThai.ForeColor = Color.White;
            }
        }
        void Edit_TestCan(enuEdit enuNew_Edit)
        {
            if (bdsTestCan.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            
            //Copy hang hien tai            
            if (bdsTestCan.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTestCan.Current).Row, ref drCurrent);
            else
                drCurrent = dtTestCan.NewRow();
            
            drCurrent["Ma_Ca"] = txtMa_Ca.Text;
            drCurrent["Ngay_Can"] = dteNgay_Sx.Text;
            drCurrent["So_Luong_Can"] = Convert.ToDouble(this.numWeight_Scale.Value) - Variables.dbZero_Coefficient;
            
            frmTestCan_Edit frmEdit = new frmTestCan_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);//, txtMa_Ca.Text);//, Convert.ToDateTime(dteNgay_Sx.Text));
            if (frmEdit.isAccept)
            {
                drCurrent["Ca"] = txtCa.Text;
                if (enuNew_Edit == enuEdit.New)
                    if (bdsTestCan.Position >= 0)
                        dtTestCan.ImportRow(drCurrent);
                    else
                        dtTestCan.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTestCan.Current).Row);
                }

                bdsTestCan.Sort = "Ident00 DESC";
                bdsTestCan.Position = 0;
                //bdsTestCan.Position = bdsTestCan.Find("IDENT00", drCurrent["IDENT00"]);
                dtTestCan.AcceptChanges();

               
            }
            else
                dtTestCan.RejectChanges();
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
					}
					return;
                
                case Keys.F6:
                    if (!bCan)
                    {
                        bTestCan = false;
                        bCan = true;
                        this.lblTrangThai.Text = strMsg2;
                        ShowTrangThai();
                        
                    }
                    else
                    {
                        bTestCan = false;
                        bCan = false;
                        this.lblTrangThai.Text = strMsg1;

                        this.lblTrangThai.BackColor = Color.Red;
                        this.lblTrangThai.ForeColor = Color.White;
                    }
                    return;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Shift:
                            //Design();
							break;
					}
					return;

				case Keys.F9:
					switch (Variables.StatusInputType)
					{
						case StatusInputType.CANDTTUDONG:
							Variables.StatusInputType = StatusInputType.BANPHIM;
							this.lblStatus_Input_Type.Text = "Kiểu nhập: Từ bàn phím";
                            bCan = true;

                            if (lblTrangThai.Text == strMsg2 || lblTrangThai.Text == strMsg1)
                                lblTrangThai.Text = strMsg4;
                            
                                ShowTrangThai();
							break;

						case StatusInputType.BANPHIM:
							if (this.txtSo_Me.Text != string.Empty)
							{
                                bCan = true;
								this.ResetScale();
								this.bCurrent_State = false;
								Variables.StatusInputType = StatusInputType.CANDTTUDONG;
								this.lblStatus_Input_Type.Text = "Kiểu nhập: Tự động từ cân điện tử";
                                
                                if (lblTrangThai.Text == strMsg4)
                                    lblTrangThai.Text = strMsg2;
                                
                                ShowTrangThai();
								break;
							}
							Common.MsgCancel("Bạn phải nhập lô sản phẩm mới chuyển được sang chế độ tự động");
							this.txtMa_Vt_Sp.Focus();
							return;
					}
					return;
					
				case Keys.F10:
					this.numWeight_Scale.Value = 0;
					this.numWeight_Scale.Focus();
					return;

				case Keys.Enter:
					if (Variables.StatusInputType != StatusInputType.CANDTTUDONG)
					{
						this.dbWeight = this.numWeight_Scale.Value;
						if (!Common.MsgYes_No("Bạn có muốn nhập bó thép này không?","Y"))
							return;

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
					return;
			}

			if (Variables.StatusInputType == StatusInputType.BANPHIM)
			{
				if (((e.KeyCode >= Keys.D0) & (e.KeyCode <= Keys.D9)))
					this.StringConvert(e.KeyCode.ToString(), 1);

				if (((e.KeyCode >= Keys.NumPad0) & (e.KeyCode <= Keys.NumPad9)))
					this.StringConvert(e.KeyCode.ToString(), 6);
			}
			
			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
			LockEditInfo(false);
			lblBarcode.Text = "";
            //cboLay_K.SelectedIndex = 0;
		}

		private enum WEIGHING_STATUS
		{
			GOOD,
			OUT_OF_PRODUCT_RANGE,
			OUT_OF_SCALE_RANGE
		}

        //private void rsLabel9_Click(object sender, EventArgs e)
        //{

        //}

        //private void frmCtNXTH_Load(object sender, EventArgs e)
        //{

        //}

	}
}
