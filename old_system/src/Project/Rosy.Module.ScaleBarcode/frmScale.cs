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
using RosySystem;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using RosySystem.Control;
using RosyModule;
using System.Data.SqlClient;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmScale : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
		string strMa_Ct;
		DataRow drDmCt;

		bool Allow_New = true;
		bool Allow_Edit = true;
        bool bInheritLC = false;
		string strStt = string.Empty;
		string strStt_Old = string.Empty;
		bool bHandle_SelectTab = false;
		BindingSource bdsDmDt = new BindingSource();
		DataTable dtDmDt;

		BindingSource bdsTruck_In = new BindingSource();
		DataTable dtTruck_In;

		BindingSource bdsTruck_Out = new BindingSource();
		DataTable dtTruck_Out;

		DataRow drCurrent;

		public enuEdit enuNew_Edit = enuEdit.New;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;
		string strScale_Name = "CANA";

		double dbNet_Weight_Min = 0; 
		double dbOld_Weight;
        double dbKhoi_Luong_Old;
		bool bStable = false;

		bool bEnable = true;
		bool isAccept = false;
        // Bằng thêm
        bool isSave = false;
        bool isNotLayHang = false;
        bool isLayHang = false;
        
		int iNum_Stabilize = 0;

		string strSo_Xe_Old = string.Empty;
		string strMa_Dt_Old = string.Empty;
		string strSo_Xa_Lan_Tau_Old = string.Empty;
		string strStt_Org_Old = string.Empty;
		string strInfoInherit_Old = string.Empty;
		string strMa_Vt_Sp_Old = string.Empty;
		string strDien_Giai_Old = string.Empty;
		double dbSo_Luong_Ra_Old = 0;

		string strStt_Truck_In = string.Empty;
		string strStt_Truck_Out = string.Empty;

		string strStt_Org = string.Empty;
		string strMa_Vt_Org = string.Empty;

		#endregion

		public frmScale()
		{
			InitializeComponent();

			this.InitForm();
           
			this.txtTime_Clock.Tick += new EventHandler(txtTime_Clock_Tick);
			this.dgvDmDt.DoubleClick += new EventHandler(dgvDmDt_DoubleClick);
			this.btScale_In.Click += new EventHandler(btScale_In_Click);
			this.btScale_Out.Click += new EventHandler(btScale_Out_Click);
            this.btRe_Scale.Click += new EventHandler(btRe_Scale_Click);
          
            //this.btConvert_Scale.Click += new EventHandler(btConvert_Scale_Click);
			this.btScale.Click += new EventHandler(btScale_Click);
			this.numSo_Luong_Vao.TextChanged += new EventHandler(numSo_Luong_Vao_TextChanged);
			this.numSo_Luong_Ra.TextChanged += new EventHandler(numSo_Luong_Ra_TextChanged);
			this.FormClosing += new FormClosingEventHandler(frmScale_FormClosing);

			this.btSave_Print.Click += new EventHandler(btSave_Print_Click);
			this.bdsTruck_In.PositionChanged += new EventHandler(bdsTruck_In_PositionChanged);
			this.btEdit_Voucher.Click += new EventHandler(btEdit_Voucher_Click);

			this.cboSelection.SelectedIndexChanged += new EventHandler(cboSelection_SelectedIndexChanged);
			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.bdsTruck_Out.PositionChanged += new EventHandler(bdsTruck_Out_PositionChanged);
			this.btEdit_Out.Click += new EventHandler(btEdit_Out_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btInherit_TTKH.Click += new EventHandler(btInherit_TTKH_Click);
			this.btPrint_In.Click += new EventHandler(btPrint_In_Click);
			this.btDelete_In.Click += new EventHandler(btDelete_In_Click);
			this.btRefresh_In.Click += new EventHandler(btRefresh_In_Click);

			this.tcCan_Xe.SelectedIndexChanged += new EventHandler(tcCan_Xe_SelectedIndexChanged);
			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);

			this.txtMa_Vt_Sp2.Validating += new CancelEventHandler(txtMa_Vt_Sp2_Validating);
			this.txtMa_Dt2.Validating += new CancelEventHandler(txtMa_Dt2_Validating);
			this.txtBarcode_Search.KeyDown += new KeyEventHandler(txtBarcode_Search_KeyDown);
			this.txtSo_Xe_Search.KeyDown += new KeyEventHandler(txtSo_Xe_Search_KeyDown);

			this.btSave_Handle.Click += new EventHandler(btSave_Handle_Click);
			this.btScale_Detail.Click += new EventHandler(btScale_Detail_Click);

            //this.dgvTruck_In.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvTruck_In_CellMouseClick);
            this.dgvTruck_In.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvTruck_In_CellMouseDoubleClick);
           
			
			this.numSo_Luong_Vao2.TextChanged += new EventHandler(numSo_Luong_Vao_Ra2_TextChanged);
			this.numSo_Luong_Ra2.TextChanged += new EventHandler(numSo_Luong_Vao_Ra2_TextChanged);

			this.txtSo_Ct2.TextChanged += new EventHandler(txtSo_Ct2_TextChanged);
			this.txtSo_Ct2.KeyPress += new KeyPressEventHandler(txtSo_Ct2_KeyPress);
			
			this.btInherit.Click += new EventHandler(btInherit_Click);
			this.btInherit2.Click += new EventHandler(btInherit2_Click);
            this.btInheritLC.Click += new EventHandler(btInheritLC_Click);
			this.txtStt_LXH.KeyDown += new KeyEventHandler(txtStt_LXH_KeyDown);
            this.txtSo_Xe.Validating += TxtSo_Xe_Validating;
		}

       

        new public void Load(string strMa_Ct)
		{
            //btConvert_Scale.Enabled = false;

			this.strMa_Ct = strMa_Ct;
			this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);

			this.ChangeMode(enuEdit.New);
			this.Build();
			this.FillData();
			this.Init_Ct();

			this.LoadTruck_In();
			this.LoadTruck_Out();

			this.Show();
		}

		private void InitForm()
		{
            string strSQLExec = "SELECT * FROM R81EQUIPMENTINFO WHERE Host_IP = '" + MachineInfo.GetHostIP() + "'"; 
			DataTable dtEquipment = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
			if (dtEquipment.Rows.Count > 0)
			{
				DataRow drEquipment = dtEquipment.Rows[0];
				if (drEquipment != null)
				{
                    //Bằng thêm
                    strScale_Name = (string)drEquipment["Can"];
                    Load_Scale_Name();
                    //
					Variables.strEquip_ID = (string)drEquipment["Equip_ID"];
					Variables.dbZero_Coefficient = Convert.ToDouble(drEquipment["Zero_Coefficient"]);
					Variables.dbSpan_Coefficient = Convert.ToDouble(drEquipment["Span_Coefficient"]);
					Variables.dbNet_Weight_Min = dbNet_Weight_Min = Convert.ToDouble(drEquipment["Net_Weight_Min"]);
					Variables.dbNet_Weight_Max = Convert.ToDouble(drEquipment["Net_Weight_Max"]);
					Variables.iStable_Count = Convert.ToInt32(drEquipment["Stable_Count"]);
					Variables.iNum_Ticket_Print = Convert.ToInt32(drEquipment["Num_Ticket_Print"]);
					Variables.strPrint_Report = (string)drEquipment["Print_Report"];
					Variables.strPrint_Barcode = (string)drEquipment["Print_Barcode"];
					Variables.strPrint_Eticket = (string)drEquipment["Print_Eticket"];

					Variables.iStable_Time = Convert.ToInt32(drEquipment["Stable_Time"]);
					Variables.iStable_Range = Convert.ToInt32(drEquipment["Stable_Range"]);

					Variables.bManual = false;
                    dbKhoi_Luong_Old = Convert.ToDouble(drEquipment["Khoi_Luong_Old"]); //Bằng thêm
				}
			}
			else
				Variables.iStable_Time = Variables.iStable_Range = 20;
           

			HardwareInterfaceScale6080.Start(this.strScale_Name);
			HardwareInterfaceScale6080.DataReceive += new DataEventHandler(HardwareInterfaceScale6080_DataReceive);

		}

		private void Build()
		{
			dgvDmDt.strZone = "DMDT_SCALE";
			dgvDmDt.BuildGridView();

			dgvTruck_In.strZone = "PH_SCALE_TRUCK_IN";
			dgvTruck_In.Dock = DockStyle.Fill;
			dgvTruck_In.BuildGridView();

			dgvTruck_Out.strZone = "PH_SCALE_TRUCK_OUT";
			dgvTruck_Out.BuildGridView();

			this.DataGridView_Language();

			foreach (DataGridViewColumn dgvCol in dgvTruck_Out.Columns)
			{
				if(dgvTruck_Out.Columns[dgvCol.DataPropertyName].Visible)
					((dgvAutoFilterColumnHeaderCell)dgvTruck_Out.Columns[dgvCol.DataPropertyName].HeaderCell).bFilteringEnabled = false;
			}
			
			this.txtMa_Vt_Sp.bUseAutoDropDown = true;
			this.txtMa_Dt.bUseAutoDropDown = true;
			this.txtMa_Vt_Sp2.bUseAutoDropDown = true;
			this.txtMa_Dt2.bUseAutoDropDown = true;
		}

		private void DataGridView_Language()
		{
			dgvTruck_In.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTruck_In.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			dgvTruck_Out.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTruck_Out.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvTruck_In.Columns.Contains("So_Ct"))
				dgvTruck_In.Columns["So_Ct"].HeaderText = "Số phiếu";

			if (dgvTruck_In.Columns.Contains("Ten_Dt"))
				dgvTruck_In.Columns["Ten_Dt"].HeaderText = "Khách hàng";

			if (dgvTruck_In.Columns.Contains("Ten_Vt"))
				dgvTruck_In.Columns["Ten_Vt"].HeaderText = "Hàng hóa";

			if (dgvTruck_In.Columns.Contains("Ten_Dt_CbNv_Vao"))
				dgvTruck_In.Columns["Ten_Dt_CbNv_Vao"].HeaderText = "NV cân vào";

			if (dgvTruck_In.Columns.Contains("Dien_Giai"))
				dgvTruck_In.Columns["Dien_Giai"].HeaderText = "Ghi chú";

			if (dgvTruck_Out.Columns.Contains("So_Ct"))
				dgvTruck_Out.Columns["So_Ct"].HeaderText = "Số phiếu";

			if (dgvTruck_Out.Columns.Contains("Ten_Dt"))
				dgvTruck_Out.Columns["Ten_Dt"].HeaderText = "Khách hàng";

			if (dgvTruck_Out.Columns.Contains("Ten_Vt"))
				dgvTruck_Out.Columns["Ten_Vt"].HeaderText = "Hàng hóa";

			if (dgvTruck_Out.Columns.Contains("Ten_Dt_CbNv_Vao"))
				dgvTruck_Out.Columns["Ten_Dt_CbNv_Vao"].HeaderText = "NV cân vào";

			if (dgvTruck_Out.Columns.Contains("Dien_Giai"))
				dgvTruck_Out.Columns["Dien_Giai"].HeaderText = "Ghi chú";
		}

		private void FillData()
		{
			//Danh mục đối tượng
			dtDmDt = DataTool.SQLGetDataTable("R81DMDT", "*", "Ma_Nh_Dt NOT IN('NV','NB')", "MA_DT");
			bdsDmDt.DataSource = dtDmDt;
			dgvDmDt.DataSource = bdsDmDt;
		}

		private void Init_Ct()
		{
			dteNgay_Ct1.Text = dteNgay_Ct2.Text = Library.DateToStr(DateTime.Now);

			txtMa_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);

			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				txtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				txtTen_Dt_CbNv.Text = string.Empty;
		}

		private void GetDateFilter(string strCondition)
		{
			switch (strCondition)
			{
				case "Hôm nay":
					dteNgay_Ct1.Text = dteNgay_Ct2.Text = DateTime.Now.ToShortDateString();
					break;
				case "Tuần này":
					{
						GregorianCalendar gregorianCalendar = new GregorianCalendar(GregorianCalendarTypes.Localized);
						switch (gregorianCalendar.GetDayOfWeek(DateTime.Today))
						{
							case DayOfWeek.Sunday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(6.0));
								break;
							case DayOfWeek.Monday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today);
								break;
							case DayOfWeek.Tuesday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(1.0));
								break;
							case DayOfWeek.Wednesday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(2.0));
								break;
							case DayOfWeek.Thursday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(3.0));
								break;
							case DayOfWeek.Friday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(4.0));
								break;
							case DayOfWeek.Saturday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(5.0));
								break;
						}
						dteNgay_Ct2.Text = Library.DateToStr(Library.StrToDate(dteNgay_Ct1.Text) + TimeSpan.FromDays(6.0));
						break;
					}
				case "Tháng này":
					dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)));
					dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));
					break;
				case "Quí này":
					if (DateTime.Today.Month < 4)
					{
						dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 1, 1));
						dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 3, DateTime.DaysInMonth(DateTime.Today.Year, 3)));
					}
					else
					{
						if (DateTime.Today.Month >= 4 && DateTime.Today.Month < 7)
						{
							dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 4, 1));
							dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 6, DateTime.DaysInMonth(DateTime.Today.Year, 6)));
						}
						else
						{
							if (DateTime.Today.Month >= 7 && DateTime.Today.Month < 9)
							{
								dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 7, 1));
								dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 9, DateTime.DaysInMonth(DateTime.Today.Year, 9)));
							}
							else
							{
								dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 10, 1));
								dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 12, DateTime.DaysInMonth(DateTime.Today.Year, 12)));
							}
						}
					}
					break;
				case "Năm nay":
					dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 12, DateTime.DaysInMonth(DateTime.Today.Year, 12)));
					dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 1, 1));
					break;
				case "Tuần trước":
					{
						GregorianCalendar gregorianCalendar2 = new GregorianCalendar(GregorianCalendarTypes.Localized);
						switch (gregorianCalendar2.GetDayOfWeek(DateTime.Today - TimeSpan.FromDays(7.0)))
						{
							case DayOfWeek.Sunday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(13.0));
								break;
							case DayOfWeek.Monday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(7.0));
								break;
							case DayOfWeek.Tuesday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(8.0));
								break;
							case DayOfWeek.Wednesday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(9.0));
								break;
							case DayOfWeek.Thursday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(10.0));
								break;
							case DayOfWeek.Friday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(11.0));
								break;
							case DayOfWeek.Saturday:
								dteNgay_Ct1.Text = Library.DateToStr(DateTime.Today - TimeSpan.FromDays(12.0));
								break;
						}
						dteNgay_Ct2.Text = Library.DateToStr(Library.StrToDate(dteNgay_Ct1.Text) + TimeSpan.FromDays(6.0));
						break;
					}
				case "Tháng trước":
					if (DateTime.Today.Month > 1)
					{
						dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month - 1)));
						dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 1));
					}
					else
					{
						dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year - 1, 12, DateTime.DaysInMonth(DateTime.Today.Year - 1, 12)));
						dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year - 1, 12, 1));
					}
					break;
				case "Quí trước":
					if (DateTime.Today.Month < 4)
					{
						dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year - 1, 10, 1));
						dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year - 1, 12, DateTime.DaysInMonth(DateTime.Today.Year - 1, 12)));
					}
					else
					{
						if (DateTime.Today.Year >= 4 && DateTime.Today.Year < 7)
						{
							dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 1, 1));
							dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 3, DateTime.DaysInMonth(DateTime.Today.Year, 3)));
						}
						else
						{
							if (DateTime.Today.Year >= 7 && DateTime.Today.Year < 9)
							{
								dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 4, 1));
								dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 6, DateTime.DaysInMonth(DateTime.Today.Year, 6)));
							}
							else
							{
								dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 7, 1));
								dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year, 9, DateTime.DaysInMonth(DateTime.Today.Year, 9)));
							}
						}
					}
					break;
				case "Năm trước":
					dteNgay_Ct2.Text = Library.DateToStr(new DateTime(DateTime.Today.Year - 1, 12, DateTime.DaysInMonth(DateTime.Today.Year - 1, 12)));
					dteNgay_Ct1.Text = Library.DateToStr(new DateTime(DateTime.Today.Year - 1, 1, 1));
					break;
				case "":
					dteNgay_Ct2.Text = dteNgay_Ct1.Text = Library.DateToStr(DateTime.Now);
					break;
			}
		}		

		private void Save()
		{
			if (!this.FormCheckValid())
				return;
            
			switch (this.enuNew_Edit)
			{
				case enuEdit.New:

					if (!this.bEnable)
						return;

					if (this.numSo_Luong_Vao.Value <= 0)
					{
						Common.MsgCancel("Khối lượng cân vào không phù hợp");
						return;
					}

					Hashtable htInsert = new Hashtable();
					htInsert.Add("STRNEW_EDIT", (char)enuNew_Edit);
					htInsert.Add("MA_CT", strMa_Ct);
					htInsert.Add("SO_CT", txtSo_Ct.Text);
					htInsert.Add("MA_DT", txtMa_Dt.Text.Trim());
					htInsert.Add("MA_DT_CBNV_VAO", txtMa_Dt_CbNv.Text.Trim());
					htInsert.Add("MA_VT_SP", txtMa_Vt_Sp.Text.Trim());
					htInsert.Add("DIEN_GIAI", txtDien_Giai.Text);
					htInsert.Add("SO_XE", txtSo_Xe.Text.Trim());
					htInsert.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text.Trim());
					htInsert.Add("CAN", this.strScale_Name);
					htInsert.Add("SO_LUONG_VAO", numSo_Luong_Vao.Value);
					htInsert.Add("SO_LUONG_RA", numSo_Luong_Ra.Value);
					htInsert.Add("SO_LUONG", numSo_Luong.Value);
                    htInsert.Add("SO_CAY", numSo_Cay.Value);
                    htInsert.Add("TAI_TRONG", numTai_Trong.Value);
					htInsert.Add("STT_ORG", this.strStt_Org);
					htInsert.Add("MA_VT_ORG", this.txtMa_Vt_Org.Text.Trim());
					htInsert.Add("CREATE_LOG", Common.GetCurrent_Log());
					htInsert.Add("MA_DVCS", Element.sysMa_DvCs);

					string strStt = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_PH_Scale", htInsert, CommandType.StoredProcedure));
					if (strStt != string.Empty)
					{
						this.bEnable = false;
                        this.btScale.Enabled = false; 
						this.btSave_Print.Enabled = false;
						this.txtSo_Xe.Enabled = this.txtSo_Xa_Lan_Tau.Enabled = true;
                        this.txtMa_Dt.Enabled = txtMa_Vt_Sp.Enabled = true;
						if (this.chkPrint_In.Checked)
						{
							//Print Voucher
							this.Print(strStt, "IN", false);
						}
						this.ChangeMode(enuEdit.New);
					}
                    isLayHang = false; // Bằng thêm đoạn này, gán cho phép sửa số lượng cân vào
					break;
				case enuEdit.Edit:

					if (!this.bEnable)
						return;

					if (this.numSo_Luong_Vao.Value <= 0)
					{
						Common.MsgCancel("Khối lượng cân vào không phù hợp");
						return;
					}

					if (this.numSo_Luong_Ra.Value <= 0)
					{
						Common.MsgCancel("Khối lượng cân ra không phù hợp");
						return;
					}

					if (this.numSo_Luong.Value <= 0)
					{
						Common.MsgCancel("Khối lượng hàng không phù hợp");
						return;
					}

					Hashtable htUpdate = new Hashtable();
					htUpdate.Add("STRNEW_EDIT", (char)enuNew_Edit);
					htUpdate.Add("STT", this.strStt_Truck_In);
					htUpdate.Add("MA_DT", txtMa_Dt.Text.Trim());
					htUpdate.Add("MA_DT_CBNV_RA", txtMa_Dt_CbNv.Text.Trim());
					htUpdate.Add("MA_VT_SP", txtMa_Vt_Sp.Text.Trim());
					htUpdate.Add("DIEN_GIAI", txtDien_Giai.Text);
					htUpdate.Add("SO_XE", txtSo_Xe.Text.Trim());
					htUpdate.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text.Trim());
                    htUpdate.Add("CAN_RA", this.strScale_Name);
					htUpdate.Add("SO_LUONG_VAO", numSo_Luong_Vao.Value);
					htUpdate.Add("SO_LUONG_RA", numSo_Luong_Ra.Value);
					htUpdate.Add("SO_LUONG", numSo_Luong.Value);
                    htUpdate.Add("SO_CAY", numSo_Cay.Value);
                    htUpdate.Add("TAI_TRONG", numTai_Trong.Value);
					htUpdate.Add("DUYET", true);
					htUpdate.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
					htUpdate.Add("MA_DVCS", Element.sysMa_DvCs);

					if (SQLExec.Execute("sp_Update_PH_Scale", htUpdate, CommandType.StoredProcedure))
					{
						this.strSo_Xe_Old = txtSo_Xe.Text.Trim();
						this.strSo_Xa_Lan_Tau_Old = txtSo_Xa_Lan_Tau.Text.Trim();
						this.strMa_Dt_Old = txtMa_Dt.Text.Trim();
						this.strMa_Vt_Sp_Old = txtMa_Vt_Sp.Text.Trim();
						this.strDien_Giai_Old = txtDien_Giai.Text;

						this.dbSo_Luong_Ra_Old = numSo_Luong_Ra.Value;
						this.strStt_Org_Old = this.strStt_Org;
						this.strInfoInherit_Old = txtInfoInherit.Text;
					

						if (Common.MsgYes_No("Xe có tiếp tục lấy hàng không?", "N"))
						{
							this.bEnable = true;
							this.ChangeMode(enuEdit.New);

							this.strStt_Org = strStt_Org_Old;
							this.txtInfoInherit.Text = strInfoInherit_Old;
							this.txtDien_Giai.Text = strDien_Giai_Old;
							this.txtSo_Xe.Text = strSo_Xe_Old;
							this.txtSo_Xa_Lan_Tau.Text = strSo_Xa_Lan_Tau_Old;
							this.txtMa_Dt.Text = strMa_Dt_Old;
							this.lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", this.txtMa_Dt.Text.Trim());

							this.txtMa_Vt_Sp.Text = strMa_Vt_Sp_Old;
							this.lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", this.txtMa_Vt_Sp.Text.Trim());

							this.numSo_Luong_Vao.Value = dbSo_Luong_Ra_Old;
							this.txtSo_Xe.Enabled = txtSo_Xa_Lan_Tau .Enabled = false;
                            
							this.txtTen_Dt_CbNv.Focus();
                            //this.btScale.Enabled = true; Bằng bỏ đoạn này
							this.btSave_Print.Enabled = true;

                            //Bằng xử lý đoạn này nếu cân tiếp tục vào
                            this.txtMa_Dt.Enabled = txtMa_Vt_Sp.Enabled = false;
                           
                            isLayHang = true;
						}
						else
						{
                            //Bằng xử lý đoạn này nếu cân tiếp tục vào
                            this.txtMa_Dt.Enabled = txtMa_Vt_Sp.Enabled = true;
                            isNotLayHang = true;
                            isSave = false;

							this.ChangeMode(enuEdit.Edit);
							this.btScale.Enabled = false;
							this.btSave_Print.Enabled = false;
                          
						}

						if (this.chkPrint_Out.Checked)
						{
							this.Print(this.strStt_Truck_In, "OUT", false);
						}
					}
					else
					{
						Common.MsgCancel("Vui lòng cân lại bì");
						return;
					}
					break;
			}

			this.LoadTruck_In();
			this.LoadTruck_Out();
			this.txtSo_Xe.Focus();
            dbKhoi_Luong_Old = 0; // Bẳng thêm gán giá trị khi cân xong

			//cập nhật giá trị HH
		}

		private void Print(string strStt, string strTruck_In_Out, bool bPreview)
		{
			string strPrint_Name = Variables.strPrint_Barcode;
			if(strTruck_In_Out == "IN")
				strPrint_Name = Variables.strPrint_Barcode;
			else
				strPrint_Name = Variables.strPrint_Eticket;

			Voucher.PrintTruck_In_Out(strStt, strTruck_In_Out, strTruck_In_Out == "IN" ? "rptTruck_In" : "rptTruck_Out", bPreview, strPrint_Name);
		}

		//Xe mới cân vào, chưa cân ra --> Xe trong kho
		private void LoadTruck_In()
		{
			dtTruck_In = SQLExec.ExecuteReturnDt("sp_GetPH_Scale_Truck_In", "Ma_Ct", strMa_Ct, CommandType.StoredProcedure);
			bdsTruck_In.DataSource = dtTruck_In;
			dgvTruck_In.DataSource = bdsTruck_In;
			
			bdsTruck_In.Position = 0;

			if (dtTruck_In.Rows.Count == 0)
				btScale_Out.Enabled = btPrint_In.Enabled = btRefresh_In.Enabled = btDelete_In.Enabled = false;
			else
				btScale_Out.Enabled = btPrint_In.Enabled = btRefresh_In.Enabled = btDelete_In.Enabled = true;
		}

		//Xe đã cân vào và cân ra Ok
		private void LoadTruck_Out()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CT", strMa_Ct);
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			htPara.Add("DUYET", true);

			dtTruck_Out = SQLExec.ExecuteReturnDt("sp_GetPH_Scale_Truck_Out", htPara, CommandType.StoredProcedure);
			bdsTruck_Out.DataSource = dtTruck_Out;
			dgvTruck_Out.DataSource = bdsTruck_Out;

			if (dtTruck_Out.Rows.Count > 0)
				this.bdsTruck_Out_PositionChanged(null, null);

		}	

		private bool FormCheckValid()
		{
			if (txtSo_Xe.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("So_Xe") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Vt_Sp.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt_Sp") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			return true;
		}

		private void ChangeMode(enuEdit enuNew_Edit)
		{
			this.enuNew_Edit = enuNew_Edit;

			if (enuNew_Edit == enuEdit.New)
			{
				this.bHandle_SelectTab = true;
				this.btScale_In.ForeColor = Color.Red;
				this.btScale_Out.ForeColor = Color.FromArgb(16, 37, 127);
				this.btEdit_Voucher.ForeColor = Color.FromArgb(16, 37, 127);

				this.btInherit.Enabled = true;
                this.btInheritLC.Enabled = true;
				this.txtStt_LXH.Enabled = true;
                
				this.GetNewStt_So_Ct();
				
				this.tcCan_Xe.SelectedTab = tpCan_Xe;
				this.btSave_Print.Enabled = false;
				this.dgvDmDt.Visible = this.btNew_Dt.Visible = true;
				this.grbSearch.Visible = this.dgvTruck_In.Visible = btRefresh_In.Visible = btPrint_In.Visible = btDelete_In.Visible = false;
				
				txtMa_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);

				if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
					txtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
				else
					txtTen_Dt_CbNv.Text = string.Empty;

                txtMa_Dt.Enabled = txtMa_Vt_Sp.Enabled = true;
                               
			}
			else if (enuNew_Edit == enuEdit.Edit)
			{
               
				this.bHandle_SelectTab = false;
				this.btScale_In.ForeColor = Color.FromArgb(16, 37, 127);
				this.btEdit_Voucher.ForeColor = Color.FromArgb(16, 37, 127);
				this.btScale_Out.ForeColor = Color.Red;

				this.tcCan_Xe.SelectedTab = tpCan_Xe;
				this.btSave_Print.Enabled = false;
				this.dgvDmDt.Visible = this.btNew_Dt.Visible = false;
				this.grbSearch.Visible = this.dgvTruck_In.Visible = btRefresh_In.Enabled = btPrint_In.Visible = btDelete_In.Visible = true;
				this.txtBarcode_Search.Focus();

                if (this.Allow_Edit)
                {
                    this.btInherit.Enabled = true;
                    this.btInheritLC.Enabled = false;
                }
                //this.txtStt_LXH.Enabled = false; // Bằng khóa chổ này

				this.strStt_Org = this.strMa_Vt_Org = string.Empty;

				this.txtStt_LXH.Text = this.txtInfoInherit.Text = txtMa_Vt_Org.Text = this.txtSo_Ct.Text = this.txtMa_Vt_Sp.Text = this.lbtTen_Vt_Sp.Text = this.txtMa_Dt.Text = this.lbtTen_Dt.Text = txtSo_Xe.Text = txtSo_Xa_Lan_Tau.Text = this.txtDien_Giai.Text = string.Empty;
				this.numSo_Luong_Vao.Value = this.numSo_Luong_Ra.Value = this.numSo_Luong.Value = 0;

             

				this.bdsTruck_In_PositionChanged(null, null);
			}
		}

		private void GetNewStt_So_Ct()
		{
			this.txtSo_Ct.Text = Voucher_Scale.GetNewSo_Ct();
			this.strStt_Org = this.strMa_Vt_Org = string.Empty;
			this.txtStt_LXH.Text = this.txtInfoInherit.Text = this.txtMa_Vt_Org.Text = this.txtMa_Vt_Sp.Text = this.lbtTen_Vt_Sp.Text = this.txtMa_Dt.Text = this.lbtTen_Dt.Text = txtSo_Xe.Text = txtSo_Xa_Lan_Tau.Text = this.txtDien_Giai.Text = string.Empty;
			this.numSo_Luong_Vao.Value = this.numSo_Luong_Ra.Value = this.numSo_Luong.Value = 0;
			this.txtStt_LXH.Focus();
		}

		private void UpdateScaleInfo(double dbWeight)
		{
			this.numWeight_Scale.Value = dbWeight;
			
			if (Variables.bManual)
			{
				this.bEnable = true;
			}
			else
			{
				if (numWeight_Scale.Value < this.dbNet_Weight_Min)
				{
					this.bEnable = true;
				}
			}
			if (dbWeight > 20.0)
			{
				if (Math.Abs(dbWeight - this.dbOld_Weight) > (double)Variables.iStable_Range)
				{
					this.bStable = false;
				}
				else
				{
					this.bStable = true;
				}

				this.dbOld_Weight = numWeight_Scale.Value;
			}
			else
			{
				this.bStable = false;
			}
		}

		private void ScaterMemvar_Truck_In()
		{
			drCurrent = ((DataRowView)bdsTruck_In.Current).Row;

			strStt_Truck_In = (string)drCurrent["Stt"];
			strStt_Org = (string)drCurrent["Stt_Org"];
			strMa_Vt_Org = drCurrent["Ma_Vt_Org"].ToString();

			txtStt_LXH.Text = (string)drCurrent["Stt_Org"];
			txtSo_Ct.Text = (string)drCurrent["So_Ct"];
			txtSo_Xe.Text = (string)drCurrent["So_Xe"];
			txtSo_Xa_Lan_Tau.Text = (string)drCurrent["So_Xa_Lan_Tau"];
			txtMa_Dt.Text = (string)drCurrent["Ma_Dt"];
			lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "MA_DT", "Ten_DT", txtMa_Dt.Text.Trim());
			txtMa_Vt_Sp.Text = (string)drCurrent["Ma_Vt_Sp"];
			lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "MA_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			txtDien_Giai.Text = (string)drCurrent["Dien_Giai"];
			numSo_Luong_Vao.Value = Convert.ToDouble(drCurrent["So_Luong_Vao"]);
			numSo_Luong_Ra.Value = Convert.ToDouble(drCurrent["So_Luong_Ra"]);
			numSo_Luong.Value = Convert.ToDouble(drCurrent["So_Luong"]);
            numSo_Cay.Value = Convert.ToDouble(drCurrent["So_Cay"]);
            numTai_Trong.Value = Convert.ToDouble(drCurrent["Tai_Trong"]);

			txtInfoInherit.Text = this.GetInfoInherit(this.strStt_Org);
			txtMa_Vt_Org.Text = strMa_Vt_Org;
			
		}

		private void ScaterMemvar_Truck_Out()
		{			
			drCurrent = ((DataRowView)bdsTruck_Out.Current).Row;
	
			strStt_Truck_Out = (string)drCurrent["Stt"];
			txtStt_LXH2.Text = (string)drCurrent["Stt_Org"];
			txtMa_Vt_Org2.Text = (string)drCurrent["Ma_Vt_Org"];
			txtSo_Ct2.Text = (string)drCurrent["So_Ct"];
			txtSo_Xe2.Text = (string)drCurrent["So_Xe"];
			txtSo_Xa_Lan_Tau2.Text = (string)drCurrent["So_Xa_Lan_Tau"];
			txtMa_Dt2.Text = (string)drCurrent["Ma_Dt"];
			lbtTen_Dt2.Text = DataTool.SQLGetNameByCode("R81DMDT", "MA_DT", "TEN_DT", txtMa_Dt2.Text.Trim());
			txtMa_Vt_Sp2.Text = (string)drCurrent["Ma_Vt_Sp"];
			lbtTen_Vt_Sp2.Text = DataTool.SQLGetNameByCode("R81DMVT", "MA_VT", "TEN_VT", txtMa_Vt_Sp2.Text.Trim());
			txtDien_Giai2.Text = (string)drCurrent["Dien_Giai"];
			txtTen_Cong_Trinh2.Text = (string)drCurrent["Ten_Cong_Trinh"];
			txtLy_Do2.Text = (string)drCurrent["Ly_Do"];
			txtTime_In2.Text = drCurrent["Time_In"].ToString();
			txtTime_Out2.Text = drCurrent["Time_Out"].ToString();
			numSo_Luong_Vao2.Value = Convert.ToDouble(drCurrent["So_Luong_Vao"]);
			numSo_Luong_Ra2.Value = Convert.ToDouble(drCurrent["So_Luong_Ra"]);
			numSo_Luong2.Value = Convert.ToDouble(drCurrent["So_Luong"]);
		}

		private void ScaterMemvar_Truck_Out(string strSo_Ct)
		{
			string strSQLExec = @"
				SELECT TOP 1 *
					FROM R80PH_SCALE
					WHERE Stt <> '' AND YEAR(Ngay_Ct) >= " + DateTime.Parse(dteNgay_Ct1.Text).Year + " AND YEAR(Ngay_Ct) <= " + DateTime.Parse(dteNgay_Ct2.Text).Year + " AND So_Ct = '" + strSo_Ct + @"'
					ORDER BY YEAR(Ngay_Ct) DESC";
			
			DataTable dtTruck_Out_Search = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
			if (dtTruck_Out_Search.Rows.Count == 0)
			{
				Common.MsgCancel("Không tồn tại phiếu này");
				txtSo_Ct2.SelectAll();
				strStt_Truck_Out = txtStt_LXH2.Text = txtMa_Vt_Org2.Text = txtSo_Xe2.Text = txtSo_Xa_Lan_Tau2.Text = txtTime_In2.Text = txtTime_Out2.Text =
				txtDien_Giai2.Text = txtTen_Cong_Trinh2.Text = txtLy_Do2.Text = txtMa_Dt2.Text = txtMa_Vt_Sp2.Text = string.Empty;
				numSo_Luong_Vao2.Value = numSo_Luong_Ra2.Value = numSo_Luong2.Value = 0;
				btInherit_TTKH.Enabled = btgAccept.Enabled = false;
			}
			else
			{
				strStt_Truck_Out = (string)dtTruck_Out_Search.Rows[0]["Stt"];
				txtStt_LXH2.Text = (string)dtTruck_Out_Search.Rows[0]["Stt_Org"];
				txtMa_Vt_Org2.Text = (string)dtTruck_Out_Search.Rows[0]["Ma_Vt_Org"];
				txtSo_Ct2.Text = (string)dtTruck_Out_Search.Rows[0]["So_Ct"];
				txtSo_Xe2.Text = (string)dtTruck_Out_Search.Rows[0]["So_Xe"];
				txtSo_Xa_Lan_Tau2.Text = (string)dtTruck_Out_Search.Rows[0]["So_Xa_Lan_Tau"];
				txtMa_Dt2.Text = (string)dtTruck_Out_Search.Rows[0]["Ma_Dt"];
				lbtTen_Dt2.Text = DataTool.SQLGetNameByCode("R81DMDT", "MA_DT", "TEN_DT", txtMa_Dt2.Text.Trim());
				txtMa_Vt_Sp2.Text = (string)dtTruck_Out_Search.Rows[0]["Ma_Vt_Sp"];
				lbtTen_Vt_Sp2.Text = DataTool.SQLGetNameByCode("R81DMVT", "MA_VT", "TEN_VT", txtMa_Vt_Sp2.Text.Trim());
				txtDien_Giai2.Text = (string)dtTruck_Out_Search.Rows[0]["Dien_Giai"];
				txtTen_Cong_Trinh2.Text = (string)dtTruck_Out_Search.Rows[0]["Ten_Cong_Trinh"];
				txtLy_Do2.Text = (string)dtTruck_Out_Search.Rows[0]["Ly_Do"];
				txtTime_In2.Text = dtTruck_Out_Search.Rows[0]["Time_In"].ToString();
				txtTime_Out2.Text = dtTruck_Out_Search.Rows[0]["Time_Out"].ToString();
				numSo_Luong_Vao2.Value = Convert.ToDouble(dtTruck_Out_Search.Rows[0]["So_Luong_Vao"]);
				numSo_Luong_Ra2.Value = Convert.ToDouble(dtTruck_Out_Search.Rows[0]["So_Luong_Ra"]);
				numSo_Luong2.Value = Convert.ToDouble(dtTruck_Out_Search.Rows[0]["So_Luong"]);	
			}
		}

		private void Reset_Truck_Out()
		{
			strStt_Truck_Out = txtStt_LXH2.Text = txtMa_Vt_Org2.Text = txtSo_Ct2.Text = txtSo_Xe2.Text = txtSo_Xa_Lan_Tau2.Text = txtTime_In2.Text = txtTime_Out2.Text = txtDien_Giai2.Text =
			txtTen_Cong_Trinh2.Text = txtLy_Do2.Text = txtMa_Dt2.Text = txtMa_Vt_Sp2.Text = string.Empty;
			numSo_Luong_Vao2.Value = numSo_Luong_Ra2.Value = numSo_Luong2.Value = 0;
			btInherit_TTKH.Enabled = btgAccept.Enabled = false;
		}

		private bool FormCheckValid_Edit()
		{
			if (txtSo_Xe2.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("So_Xe") + " " +
										Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (this.numSo_Luong_Vao2.Value <= 0)
			{
				Common.MsgCancel("Khối lượng cân vào không phù hợp");
				return false;
			}

			if (this.numSo_Luong_Ra2.Value <= 0)
			{
				Common.MsgCancel("Khối lượng cân ra không phù hợp");
				return false;
			}

			if (txtMa_Vt_Sp2.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt_Sp") + " " +
										Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (txtMa_Dt2.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " +
										Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (txtLy_Do2.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ly_Do") + " " +
										Languages.GetLanguage("Not_Null"));

				return false;
			}

			return true;
		}

		private string GetInfoInherit(string strStt_Org)
		{
			//Hiển thị chứng từ gốc kế thừa
			string strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = T2.Ma_Ct + ':' + T2.So_Ct
					FROM R80PH_SCALE T1 JOIN R04CTSO T2 ON T1.Stt_Org = T2.Stt
					WHERE T1.Stt_Org IN (SELECT Stt FROM R04CTSO WHERE Stt = '" + strStt_Org + @"')
				SELECT @_InheritList";

			return SQLExec.ExecuteReturnValue(strSQLExec).ToString();
		}

		#region Event

		void btScale_Detail_Click(object sender, EventArgs e)
		{
			Common.RunMethod("CT_PXTH_DETAIL");
			//frmScale_Detail frmEdit = new frmScale_Detail();
			//frmEdit.Load(this.strMa_Ct);
		}

		void btSave_Handle_Click(object sender, EventArgs e)
		{
			bEnable = true;
			btSave_Print_Click(null, null);
            if (bInheritLC)
            {
                txtSo_Xe.ReadOnly = false;
                txtMa_Dt.ReadOnly = false;
                txtMa_Vt_Sp.ReadOnly = false;
            }
            bInheritLC = false;
		}

		void HardwareInterfaceScale6080_DataReceive(double dbValue, string strType)
		{
			this.UpdateScaleInfo(dbValue);
		}

		void btSave_Print_Click(object sender, EventArgs e)
		{
			this.Save();
            if (bInheritLC)
            {
                txtSo_Xe.ReadOnly = false;
                txtMa_Dt.ReadOnly = false;
                txtMa_Vt_Sp.ReadOnly = false;
            }
            bInheritLC = false;

			//Bằng thêm để thêm số lượng tạm
			SQLExec.Execute("UPDATE R80PH_SCALE SET So_Luong_HH = " + Math.Abs(numSo_Luong_Vao.Value - numSo_Luong_Ra.Value) + "" +
				"WHERE Stt = '" + strStt_Truck_In + "' AND So_Xe = '" + txtSo_Xe.Text + "' AND So_Luong_HH = 0");
		}

		void txtTime_Clock_Tick(object sender, EventArgs e)
		{
			this.txtTime.Text = string.Format("{0:HH:mm:ss  -  dd/MM/yyyy}", DateTime.Now);

			if (this.bStable)
			{
				iNum_Stabilize++;
			}
			else
			{
				iNum_Stabilize = 0;
			}
			this.lblStatus.Text = string.Concat(new string[] { this.bEnable.ToString(), "-", iNum_Stabilize.ToString(), "-", this.isAccept.ToString() });

			if (iNum_Stabilize >= Variables.iStable_Time)
				this.isAccept = true;
			else
				this.isAccept = false;

            if (numWeight_Scale.Value <= 20.0)
            {
                
                isNotLayHang = false;
            }
           
            //Bằng thêm
            if (this.numWeight_Scale.Value == dbKhoi_Luong_Old && dbKhoi_Luong_Old != 0)
                this.bEnable = false;

            if (this.Allow_New)
            {
                if (isNotLayHang)
                {                    
                    btScale.Enabled = (bEnable && isAccept && isSave);
                }
                else
                    btScale.Enabled = (bEnable && isAccept);
              
            }

           
        }

		void dgvDmDt_DoubleClick(object sender, EventArgs e)
		{
			if (bdsDmDt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmDt.Current).Row;
			txtMa_Dt.Text = drCurrent["Ma_Dt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Dt"];
			lbtTen_Dt.Text = drCurrent["Ten_Dt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ten_Dt"];
		}
        
        void btRe_Scale_Click(object sender, EventArgs e)
        {
            string strStt_LXH_Tt = (string)SQLExec.ExecuteReturnValue("SELECT Stt FROM R04CTSO WHERE So_Ct = (SELECT So_LXH_Tt FROM R04CTSO WHERE Stt = '" + strStt_Org + "')");
            
            if (strStt_LXH_Tt == null)
                return;
            
            double dbSo_Luong_Vao = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT So_Luong_Vao FROM R80PH_SCALE WHERE Stt_Org = '"+ strStt_LXH_Tt +"'"));

            if (numWeight_Scale.Value == 0)
            {
                numSo_Luong_Vao.Value = dbSo_Luong_Vao;
            }
        }
		void btScale_Out_Click(object sender, EventArgs e)
		{
            // Bằng thêm
            if (isNotLayHang && numWeight_Scale.Value > Variables.dbNet_Weight_Min && isAccept && bStable)
                isSave = false;

			this.ChangeMode(enuEdit.Edit);
		}

		void btScale_In_Click(object sender, EventArgs e)
		{
            // Bằng thêm
            if (isNotLayHang && numWeight_Scale.Value > Variables.dbNet_Weight_Min && isAccept && bStable)
                isSave = false;
			this.ChangeMode(enuEdit.New);
		}

        //void btConvert_Scale_Click(object sender, EventArgs e)
        //{
        //    if (this.strScale_Name == "CANA")
        //    {
        //        this.numWeight_Scale.Value = 0;
        //        this.strScale_Name = "CANB";
        //        this.lblScale_Name.Text = "CÂN B";
        //        this.lblScale_Name.ForeColor = (this.numWeight_Scale.LedOnColor = Color.Yellow);
        //        HardwareInterfaceScale6080.DataReceive -= new DataEventHandler(HardwareInterfaceScale6080_DataReceive);
        //        this.InitForm();
        //    }
        //    else
        //    {
        //        this.numWeight_Scale.Value = 0;
        //        this.strScale_Name = "CANA";
        //        this.lblScale_Name.Text = "CÂN A";
        //        this.lblScale_Name.ForeColor = (this.numWeight_Scale.LedOnColor = Color.Lime);
        //        HardwareInterfaceScale6080.DataReceive -= new DataEventHandler(HardwareInterfaceScale6080_DataReceive);
        //        this.InitForm();
        //    }
        //}
        void Load_Scale_Name()
        {
            this.lblScale_Name.Text = "CÂN " + strScale_Name.Substring(3, 1);
        }
		void frmScale_FormClosing(object sender, FormClosingEventArgs e)
		{
            SQLExec.Execute("UPDATE R81EQUIPMENTINFO SET Khoi_Luong_Old = "+ numWeight_Scale.Value +" WHERE Host_IP = '" + MachineInfo.GetHostIP() +"'");
			HardwareInterfaceScale6080.DataReceive -= new DataEventHandler(HardwareInterfaceScale6080_DataReceive);
		}

		void numSo_Luong_Ra_TextChanged(object sender, EventArgs e)
		{
			if (numSo_Luong_Vao.Value > 0 & this.numSo_Luong_Ra.Value > 0)
			{
				this.numSo_Luong.Value = Math.Abs(numSo_Luong_Vao.Value - numSo_Luong_Ra.Value);
			}
			else
			{
				this.numSo_Luong.Value = 0;
			}
		}

		void numSo_Luong_Vao_TextChanged(object sender, EventArgs e)
		{
			if (numSo_Luong_Vao.Value > 0 & numSo_Luong_Ra.Value > 0)
			{
				numSo_Luong.Value = Math.Abs(numSo_Luong_Vao.Value - numSo_Luong_Ra.Value);
			}
			else
			{
				numSo_Luong.Value = 0;
			}
		}

		void btScale_Click(object sender, EventArgs e)
		{
			if (this.enuNew_Edit == enuEdit.New)
			{
                if (!isLayHang)
				    numSo_Luong_Vao.Value = Convert.ToInt32(numWeight_Scale.Value);
				
                if (numSo_Luong_Vao.Value > 0)
				{
					btSave_Print.Enabled = true;
				}
                
			}
			if (this.enuNew_Edit == enuEdit.Edit)
			{
				numSo_Luong_Ra.Value = Convert.ToInt32(numWeight_Scale.Value);
				if (this.numSo_Luong_Ra.Value > 0)
				{
					btSave_Print.Enabled = true;
				}

                //Bằng thêm để thêm số lượng tạm
                SQLExec.Execute("UPDATE R80PH_SCALE SET So_Luong_HH = " + Math.Abs(numSo_Luong_Vao.Value - numSo_Luong_Ra.Value) + "" +
                    "WHERE Stt = '" + strStt_Truck_In + "' AND So_Xe = '" + txtSo_Xe.Text + "'");
            }

			btSave_Print.Focus();
		}

		void bdsTruck_In_PositionChanged(object sender, EventArgs e)
		{
			//if (bdsTruck_In.Position < 0)
			//    return;

			//if (enuNew_Edit == enuEdit.Edit)
			//    this.ScaterMemvar_Truck_In();
		}

		void btPrint_Click(object sender, EventArgs e)
		{
			if (this.strStt != string.Empty)
                Voucher.PrintScale_Out(this.strStt, true, true, "R80PH_SCALE");
		}

		void btPrint_In_Click(object sender, EventArgs e)
		{
			this.Print(this.strStt_Truck_In, "IN", false);
		}

		void btRefresh_In_Click(object sender, EventArgs e)
		{
			this.LoadTruck_In();
		}

		private void Print_Out()
		{
			this.Print(this.strStt_Truck_Out, "OUT", false);
		}

		void btDelete_In_Click(object sender, EventArgs e)
		{
			if (bdsTruck_In.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsTruck_In.Current).Row;

			//Check permission Delete
			if (!Element.sysIs_Admin)
			{
				if (!Common.CheckPermission("DELETE_TRUCK_IN", enuPermission_Type.Allow_Delete))
				{
					Common.MsgCancel("Bạn không có quyền xóa phiếu");
					return;
				}
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			//Set Deleted = true. Khong xoa han di
			if (SQLExec.Execute("UPDATE R80PH_SCALE SET Deleted = 1 WHERE Stt = '" + drCurrent["Stt"].ToString() + "'"))
			{
				bdsTruck_In.RemoveAt(bdsTruck_In.Position);
				dtTruck_In.AcceptChanges();
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (!FormCheckValid_Edit())
				return;

			Hashtable htUpdate = new Hashtable();
			htUpdate.Add("STT", this.strStt_Truck_Out);
			htUpdate.Add("SO_XE", txtSo_Xe2.Text.Trim());
			htUpdate.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau2.Text.Trim());
			htUpdate.Add("MA_DT", txtMa_Dt2.Text.Trim());
			htUpdate.Add("MA_VT_SP", txtMa_Vt_Sp2.Text.Trim());
			htUpdate.Add("DIEN_GIAI", txtDien_Giai2.Text);
			htUpdate.Add("TEN_CONG_TRINH", txtTen_Cong_Trinh2.Text);
			htUpdate.Add("SO_LUONG_VAO", numSo_Luong_Vao2.Value);
			htUpdate.Add("SO_LUONG_RA", numSo_Luong_Ra2.Value);
			htUpdate.Add("SO_LUONG", numSo_Luong2.Value);
			htUpdate.Add("LY_DO", txtLy_Do2.Text);
			htUpdate.Add("LASTMODIFY_LOG2", Common.GetCurrent_Log());
			htUpdate.Add("MA_DVCS", Element.sysMa_DvCs);
           
			if (SQLExec.Execute("sp_Update_PH_Scale", htUpdate, CommandType.StoredProcedure))
			{
				this.dgvTruck_Out.Enabled = this.txtSo_Ct2.Enabled = this.btEdit_Out.Enabled = true;
				
				this.btInherit2.Enabled = this.txtStt_LXH2.Enabled = this.txtMa_Vt_Org2.Enabled = this.txtSo_Xe2.Enabled = this.txtSo_Xa_Lan_Tau2.Enabled = this.numSo_Luong_Vao2.Enabled = this.numSo_Luong_Ra2.Enabled =
				this.txtMa_Dt2.Enabled = this.txtMa_Vt_Sp2.Enabled = this.txtDien_Giai2.Enabled = this.txtTen_Cong_Trinh2.Enabled = txtLy_Do2.Enabled = this.btgAccept.Enabled = this.btInherit_TTKH.Enabled = false;

				this.Print_Out();
				this.LoadTruck_Out();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.dgvTruck_Out.Enabled = this.txtSo_Ct2.Enabled = this.btEdit_Out.Enabled = true;
			this.btInherit2.Enabled = this.txtStt_LXH2.Enabled = this.txtMa_Vt_Org2.Enabled = this.txtSo_Xe2.Enabled = this.txtSo_Xa_Lan_Tau2.Enabled = this.numSo_Luong_Vao2.Enabled = this.numSo_Luong_Ra2.Enabled = this.txtMa_Dt2.Enabled =
			this.txtMa_Vt_Sp2.Enabled = this.txtDien_Giai2.Enabled = this.txtTen_Cong_Trinh2.Enabled = txtLy_Do2.Enabled = this.btgAccept.Enabled = this.btInherit_TTKH.Enabled = false;

			this.bdsTruck_Out_PositionChanged(null, null);

		}

		void btEdit_Out_Click(object sender, EventArgs e)
		{
			this.dgvTruck_Out.Enabled = this.txtSo_Ct2.Enabled = this.btEdit_Out.Enabled = false;
			this.btInherit_TTKH.Enabled = this.btgAccept.Enabled = this.txtDien_Giai2.Enabled = this.txtTen_Cong_Trinh2.Enabled = txtLy_Do2.Enabled = true;

			//Check permision access control
			if (!Element.sysIs_Admin)
			{
				if (Common.CheckPermission("ACCESS_SO_XE2", enuPermission_Type.Allow_Access))
					txtSo_Xe2.Enabled = true;
				
				if (Common.CheckPermission("ACCESS_SO_XL_TAU2", enuPermission_Type.Allow_Access))
					txtSo_Xa_Lan_Tau2.Enabled = true;

				if (Common.CheckPermission("ACCESS_SL_VAO_RA2", enuPermission_Type.Allow_Access))
					numSo_Luong_Vao2.Enabled = numSo_Luong_Ra2.Enabled = true;

				if (Common.CheckPermission("ACCESS_MA_DT2", enuPermission_Type.Allow_Access))
					txtMa_Dt2.Enabled = true;

				if (Common.CheckPermission("ACCESS_MA_VT_SP2", enuPermission_Type.Allow_Access))
					txtMa_Vt_Sp2.Enabled = true;
			}
			else
			{
				btInherit2.Enabled = txtStt_LXH2.Enabled = txtSo_Xe2.Enabled = txtSo_Xa_Lan_Tau2.Enabled = numSo_Luong_Vao2.Enabled = numSo_Luong_Ra2.Enabled = txtMa_Dt2.Enabled = txtMa_Vt_Sp2.Enabled = true;
			}

			//Kiểm tra xem phiếu này đã xuất hàng chưa. Nếu chưa mới cho phép kế thừa lại
			if (txtStt_LXH2.Text.Trim() != string.Empty)
			{
				if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Stt", strStt_Truck_Out))
				{
					btInherit2.Enabled = txtStt_LXH2.Enabled = false;
				}
				else
				{
					if (!Element.sysIs_Admin)
					{
						if (!Common.CheckPermission("ACCESS_INHERIT2", enuPermission_Type.Allow_Access))
							btInherit2.Enabled = txtStt_LXH2.Enabled = false;
						else
							btInherit2.Enabled = txtStt_LXH2.Enabled = true;
					}
					else
						btInherit2.Enabled = txtStt_LXH2.Enabled = true;
				}
			}
			else
			{
				if (!Element.sysIs_Admin)
				{
					if (!Common.CheckPermission("ACCESS_INHERIT2", enuPermission_Type.Allow_Access))
						btInherit2.Enabled = txtStt_LXH2.Enabled = false;
					else
						btInherit2.Enabled = txtStt_LXH2.Enabled = true;
				}
				else
					btInherit2.Enabled = txtStt_LXH2.Enabled = true;
			}
		}

		void btInherit_TTKH_Click(object sender, EventArgs e)
		{
			string strStt_Org = txtStt_LXH2.Text.Trim();
			string strSo_Xe_TTKH = txtSo_Xe2.Text.Trim();
			string strSo_Xa_Lan_Tau_TTKH = txtSo_Xa_Lan_Tau2.Text.Trim();
			string strMa_Dt_TTKH = txtMa_Dt2.Text.Trim();
			string strMa_Vt_Sp_TTKH = txtMa_Vt_Sp2.Text.Trim();

			frmInherit_CtSO_Scale_TTKH frmInherit = new frmInherit_CtSO_Scale_TTKH();
			frmInherit.Load(strStt_Org, strSo_Xe_TTKH, strSo_Xa_Lan_Tau_TTKH, strMa_Dt_TTKH, strMa_Vt_Sp_TTKH);

			if (frmInherit.is_Accept)
			{
				txtSo_Xe2.Text = frmInherit.txtSo_Xe.Text.Trim();
				txtSo_Xa_Lan_Tau2.Text = frmInherit.txtSo_Xa_Lan_Tau.Text.Trim();
				txtMa_Dt2.Text = frmInherit.txtMa_Dt.Text.Trim();
				lbtTen_Dt2.Text = frmInherit.lbtTen_Dt.Text;
				txtMa_Vt_Sp2.Text = frmInherit.txtMa_Vt_Sp.Text.Trim();
				lbtTen_Vt_Sp2.Text = frmInherit.lbtTen_Vt_Sp.Text;
			}
		}

		void bdsTruck_Out_PositionChanged(object sender, EventArgs e)
		{
			if (bdsTruck_Out.Position < 0)
			{
				this.Reset_Truck_Out();
				return;
			}
			
			this.ScaterMemvar_Truck_Out();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.LoadTruck_Out();
		}

		void cboSelection_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.GetDateFilter(cboSelection.Text);
		}

		void txtMa_Dt2_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt2.Text.Trim();

			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt2.Text = string.Empty;
				lbtTen_Dt2.Text = string.Empty;
			}
			else
			{
				txtMa_Dt2.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt2.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_Vt_Sp2_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp2.Text.Trim();

			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp2.Text = string.Empty;
				lbtTen_Vt_Sp2.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp2.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt_Sp2.Text = drLookup["Ten_Vt"].ToString();
			}
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();

			bool bRequire = false;

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
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();
			}
		}
        
		void txtStt_LXH_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (!string.IsNullOrEmpty(txtStt_LXH.Text.Trim()))
				{
					string strValue = txtStt_LXH.Text.Trim();

					if (strValue.StartsWith("]C1"))
						strValue = strValue.Substring(3, strValue.Length - 3);

					txtStt_LXH.Text = strValue;
                    DataTable dtInherit;
                    if (Common.InlistLike(txtStt_LXH.Text.Trim(), "A01"))
                    {
                        Hashtable HT = new Hashtable();
                        HT.Add("STT", txtStt_LXH.Text.Trim());
                        dtInherit = SQLExec.ExecuteReturnDt("sp_GetCTSO",HT, CommandType.StoredProcedure);
                        //dtInherit = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R04CTSO WHERE Ma_Ct LIKE 'LXH%' AND Stt = '" + txtStt_LXH.Text.Trim() + "' AND (Ht_Gn LIKE 'GK%' OR Stt_Org NOT IN (SELECT Stt FROM R80PH WHERE Duyet_Huy = 1))");
                    }
                    else
                        dtInherit = SQLExec.ExecuteReturnDt("SELECT Stt_Can AS Stt, 'LC' AS Ma_Ct, '' AS So_Ct, So_Xe, So_Xa_Lan_Tau, Ma_Dt, Ma_Vt_Sp AS Ma_Vt FROM R09CT_RVC WHERE Stt_Can = '" + txtStt_LXH.Text.Trim() + "'");

					if (dtInherit.Rows.Count > 0)
					{
						DataRow drInherit = dtInherit.Rows[0];

						txtStt_LXH.Text = drInherit["Stt"].ToString();

						txtInfoInherit.Text = drInherit["Ma_Ct"].ToString() + ":" + drInherit["So_Ct"].ToString();
						strStt_Org = drInherit["Stt"].ToString();
						txtSo_Xe.Text = drInherit["So_Xe"].ToString();
						txtSo_Xa_Lan_Tau.Text = drInherit["So_Xa_Lan_Tau"].ToString();
						txtMa_Dt.Text = drInherit["Ma_Dt"].ToString();
						lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
                        numTai_Trong.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT Tai_Trong FROM R81DMSOXE WHERE So_Xe = '" + txtSo_Xe.Text + "'"));

                        //strMa_Vt_Org = string.Empty;
                        //foreach (DataRow drInherit in frmInherit.dtInheritVoucher.Select("Chon = true"))
                        //    strMa_Vt_Org = strMa_Vt_Org + drInherit["Ma_Vt"].ToString() + ",";

                        if (strMa_Vt_Org.EndsWith(","))
                            txtMa_Vt_Org.Text = strMa_Vt_Org.Substring(0, strMa_Vt_Org.Length - 1);


                        if (Common.InlistLike(txtStt_LXH.Text.Trim(), "A01") && drInherit["Ma_Vt"].ToString() != "BD00000000")
                        {
                            if (drInherit["Ma_Vt"].ToString().StartsWith("B") )
                            {
                                txtMa_Vt_Sp.Text = "CP";
                                lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
                                if (enuNew_Edit == enuEdit.New)
                                    isSave = true;

                            }
                            else
                            {
                                txtMa_Vt_Sp.Text = string.Empty;
                                lbtTen_Vt_Sp.Text = string.Empty;
                                isSave = false;
                            }
                        }
                        else
                        {
                            txtMa_Vt_Sp.Text = drInherit["Ma_Vt"].ToString();
                            lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
                            if (enuNew_Edit == enuEdit.New)
                                isSave = true;
                        }
                        //Bằng thêm khi kế thừa từ LXH thì không cho phép sửa khách hàng và sản phẩm
                        txtMa_Dt.Enabled = txtMa_Vt_Sp.Enabled = false;

						txtDien_Giai.Text = txtInfoInherit.Text;
                        
					}
					else
					{
                        DataTable dtSoHuy = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R04CTSO WHERE Ma_Ct LIKE 'LXH%' AND Stt = '" + txtStt_LXH.Text.Trim() + "' AND Stt_Org IN (SELECT Stt FROM R80PH WHERE Duyet_Huy = 1)");
                        if (dtSoHuy.Rows.Count > 0)
                        {
                            Common.MsgCancel("Số phiếu xác nhận đơn hàng { " + dtSoHuy.Rows[0]["So_Ct"].ToString().Substring(0, 13) + "} này đã bị đóng. Không cho phép cân hàng !!!");
                        }
                        else
                            Common.MsgCancel("Không tồn tại số phiếu { " + txtStt_LXH.Text.Trim() + "} này");

						txtStt_LXH.Text = txtInfoInherit.Text = this.txtMa_Vt_Org.Text = string.Empty;
                        isSave = false;
                        this.txtStt_LXH.Focus();
                        
					}
				}

				this.txtStt_LXH.Text = string.Empty;

				if (string.IsNullOrEmpty(txtSo_Xe.Text.Trim()))
					this.txtSo_Xe.Focus();
				else
					this.txtDien_Giai.Focus();
			}
		}

		void txtBarcode_Search_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				string strValue = txtBarcode_Search.Text.Trim();
				if (strValue.StartsWith("]C1"))
					strValue = strValue.Substring(3, strValue.Length - 3);
				if(strValue.StartsWith("]CA1"))
					strValue = "A" + strValue.Substring(4, strValue.Length - 4);

				txtBarcode_Search.Text = strValue;
                
				if (this.enuNew_Edit == enuEdit.Edit)
				{
                   
					DataRow[] drSelect = dtTruck_In.Select("Stt = '" + txtBarcode_Search.Text.Trim() + "'");
					if (drSelect.Length > 0)
					{
						this.strStt_Truck_In = (string)drSelect[0]["Stt"];
						this.strStt_Org = (string)drSelect[0]["Stt_Org"];
						this.strMa_Vt_Org = drSelect[0]["Ma_Vt_Org"].ToString();

						txtStt_LXH.Text = (string)drSelect[0]["Stt_Org"];
						txtMa_Vt_Org.Text = this.strMa_Vt_Org;
						txtSo_Ct.Text = (string)drSelect[0]["So_Ct"];
						
                        txtSo_Xe.Text = (string)drSelect[0]["So_Xe"];
						txtSo_Xa_Lan_Tau.Text = (string)drSelect[0]["So_Xa_Lan_Tau"];
						txtMa_Dt.Text = (string)drSelect[0]["Ma_Dt"];
						lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
						txtMa_Vt_Sp.Text = (string)drSelect[0]["Ma_Vt_Sp"];
						lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
						txtDien_Giai.Text = (string)drSelect[0]["Dien_Giai"];

						txtMa_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
						if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
							txtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
						else
							txtTen_Dt_CbNv.Text = string.Empty;

						numSo_Luong_Vao.Value = Convert.ToDouble(drSelect[0]["So_Luong_Vao"]);
                        numTai_Trong.Value = Convert.ToDouble(drSelect[0]["Tai_Trong"]);

                        //numTai_Trong.Value = Convert.ToDouble(SQLExec.Execute("SELECT Tai_Trong FROM R81DMSOXE WHERE So_Xe = '"+ txtSo_Xe.Text +"'"));
						txtInfoInherit.Text = this.GetInfoInherit(this.strStt_Org);

                        
					}
					else
					{
						Common.MsgCancel("Không tồn tại số phiếu { " + txtBarcode_Search.Text.Trim() + "} này");
						this.txtBarcode_Search.Text = "";
						this.txtBarcode_Search.Focus();
					}
				}

				if (this.txtBarcode_Search.Text.Trim() != "")
				{
					this.txtMa_Dt.Focus();
				}

				this.txtBarcode_Search.Text = "";
			}
		}

		void txtSo_Xe_Search_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (this.enuNew_Edit == enuEdit.Edit)
				{
					DataRow[] drSelect = dtTruck_In.Select("So_Xe = '" + txtSo_Xe_Search.Text.Trim() + "'");
					if (drSelect.Length > 0)
					{
						strStt_Truck_In = (string)drSelect[0]["Stt"];
						txtSo_Ct.Text = (string)drSelect[0]["So_Ct"];
						txtSo_Xe.Text = (string)drSelect[0]["So_Xe"];
						txtSo_Xa_Lan_Tau.Text = (string)drSelect[0]["So_Xa_Lan_Tau"];
						txtMa_Dt.Text = (string)drSelect[0]["Ma_Dt"];
						txtMa_Vt_Sp.Text = (string)drSelect[0]["Ma_Vt_Sp"];
						txtDien_Giai.Text = (string)drSelect[0]["Dien_Giai"];
						numSo_Luong_Vao.Value = Convert.ToDouble(drSelect[0]["So_Luong_Vao"]);
					}
				}
				if (this.txtSo_Xe_Search.Text != "")
				{
					this.txtMa_Dt.Focus();
				}
				this.txtSo_Xe_Search.Text = "";
			}
		}

		void tcCan_Xe_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(tcCan_Xe.SelectedTab == tpSua_Phieu)
				this.btEdit_Voucher_Click(null, null);
			else if(tcCan_Xe.SelectedTab == tpCan_Xe && !bHandle_SelectTab)
				this.ChangeMode(enuEdit.Edit);
			else if (tcCan_Xe.SelectedTab == tpCan_Xe && bHandle_SelectTab)
				this.ChangeMode(enuEdit.New);
		}

        

        void dgvTruck_In_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (bdsTruck_In.Position < 0)
                return;

            if (enuNew_Edit == enuEdit.Edit)
            {
                this.ScaterMemvar_Truck_In();
                
                
            }
        }
        
        //void dgvTruck_In_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (bdsTruck_In.Position < 0)
        //        return;

        //    //if (enuNew_Edit == enuEdit.Edit)
        //    //{
        //    //    this.ScaterMemvar_Truck_In();
        //    //    // Bằng thêm để khóa nút cân vào
        //    //    btScale_In.Enabled = false;
        //    //}
        //}

		void numSo_Luong_Vao_Ra2_TextChanged(object sender, EventArgs e)
		{
			if (numSo_Luong_Vao2.Value > 0 & numSo_Luong_Ra2.Value > 0)
			{
				numSo_Luong2.Value = Math.Abs(numSo_Luong_Vao2.Value - numSo_Luong_Ra2.Value);
			}
			else
			{
				numSo_Luong2.Value = 0;
			}
		}

		void txtSo_Ct2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)))
			{
				e.Handled = true;
				return;
			}

			//Phím backspace
			else if (e.KeyChar.ToString() == "\b")
			{
				e.Handled = false;
				return;
			}
		}

		void txtSo_Ct2_TextChanged(object sender, EventArgs e)
		{
			if (this.txtSo_Ct2.Text.Trim() != string.Empty)
			{
				//if (Convert.ToInt32(txtSo_Ct2.Text.Trim()) >= 116816)
				if (txtSo_Ct2.Text.Trim().Length >= 6)
					this.ScaterMemvar_Truck_Out(txtSo_Ct2.Text.Trim());
			}
		}

		void btEdit_Voucher_Click(object sender, EventArgs e)
		{
			this.tcCan_Xe.SelectedTab = tpSua_Phieu;
			this.dgvTruck_Out.Enabled = true;
			this.dgvTruck_Out.Focus();
			this.btEdit_Voucher.ForeColor = Color.Red;
			this.btScale_In.ForeColor = Color.FromArgb(16, 37, 127);
			this.btScale_Out.ForeColor = Color.FromArgb(16, 37, 127);
			this.numSo_Luong_Vao.Value = this.numSo_Luong_Ra.Value = this.numSo_Luong.Value = 0;
			this.bdsTruck_Out_PositionChanged(null, null);
		}
        void btInheritLC_Click(object sender, EventArgs e)
        {
            frmInherit_LenhCan frm = new frmInherit_LenhCan();
            frm.Load(false);

            if (frm.Is_Accept)
            {
                foreach (DataRow drInherit in frm.dtInherit.Select("Chon = true"))
                {
                    if (drInherit["Ma_Vt_Sp"].ToString() != "CP" || drInherit["Stt"].ToString().StartsWith("LC"))
                    {
                        txtSo_Xe.Text = drInherit["So_Xe"].ToString();
                        txtSo_Xa_Lan_Tau.Text = drInherit["So_Xa_Lan_Tau"].ToString();
                        txtMa_Dt.Text = drInherit["Ma_Dt"].ToString();
                        txtMa_Vt_Sp.Text = drInherit["Ma_Vt_Sp"].ToString();
                        txtStt_LXH.Text = drInherit["Stt"].ToString();
                        lbtTen_Dt.Text = drInherit["Ten_Dt"].ToString();
                        lbtTen_Vt_Sp.Text = drInherit["Ten_Vt"].ToString();
                        strStt_Org = drInherit["Stt"].ToString();
                        numTai_Trong.Value = Convert.ToDouble(drInherit["Tai_Trong"]);
                        txtDien_Giai.Text = drInherit["Ghi_Chu"].ToString();
                        txtSo_Xe.ReadOnly = true;
                        txtMa_Dt.ReadOnly = true;
                        txtMa_Vt_Sp.ReadOnly = true;

                        bInheritLC = true;
                    }
                    else
                    {
                        txtStt_LXH.Text = drInherit["Stt"].ToString();
                        AddLX(txtStt_LXH.Text);
                    }
                }
            }
        }
        void AddLX(string strStt_LXH)
        {
            
            DataTable dtInherit;

            Hashtable HT = new Hashtable();
            HT.Add("STT", strStt_LXH.Trim());
            dtInherit = SQLExec.ExecuteReturnDt("sp_GetCTSO", HT, CommandType.StoredProcedure);


            if (dtInherit.Rows.Count > 0)
            {
                DataRow drInherit = dtInherit.Rows[0];

                txtStt_LXH.Text = drInherit["Stt"].ToString();

                txtInfoInherit.Text = drInherit["Ma_Ct"].ToString() + ":" + drInherit["So_Ct"].ToString();
                strStt_Org = drInherit["Stt"].ToString();
                txtSo_Xe.Text = drInherit["So_Xe"].ToString();
                txtSo_Xa_Lan_Tau.Text = drInherit["So_Xa_Lan_Tau"].ToString();
                txtMa_Dt.Text = drInherit["Ma_Dt"].ToString();
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
                numTai_Trong.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT Tai_Trong FROM R81DMSOXE WHERE So_Xe = '" + txtSo_Xe.Text + "'"));

                //strMa_Vt_Org = string.Empty;
                //foreach (DataRow drInherit in frmInherit.dtInheritVoucher.Select("Chon = true"))
                //    strMa_Vt_Org = strMa_Vt_Org + drInherit["Ma_Vt"].ToString() + ",";

                if (strMa_Vt_Org.EndsWith(","))
                    txtMa_Vt_Org.Text = strMa_Vt_Org.Substring(0, strMa_Vt_Org.Length - 1);


                if (Common.InlistLike(txtStt_LXH.Text.Trim(), "A01") && drInherit["Ma_Vt"].ToString() != "BD00000000")
                {
                    if (drInherit["Ma_Vt"].ToString().StartsWith("B"))
                    {
                        txtMa_Vt_Sp.Text = "CP";
                        lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
                        if (enuNew_Edit == enuEdit.New)
                            isSave = true;

                    }
                    else
                    {
                        txtMa_Vt_Sp.Text = string.Empty;
                        lbtTen_Vt_Sp.Text = string.Empty;
                        isSave = false;
                    }
                }
                else
                {
                    txtMa_Vt_Sp.Text = drInherit["Ma_Vt"].ToString();
                    lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
                    if (enuNew_Edit == enuEdit.New)
                        isSave = true;
                }
                //Bằng thêm khi kế thừa từ LXH thì không cho phép sửa khách hàng và sản phẩm
                txtMa_Dt.Enabled = txtMa_Vt_Sp.Enabled = false;

                txtDien_Giai.Text = txtInfoInherit.Text;
            }
        }
		void btInherit_Click(object sender, EventArgs e)
		{

			frmInherit_LenhCan frm = new frmInherit_LenhCan();
			frm.Load(true);

			if (frm.Is_Accept)
			{
				foreach (DataRow drInherit in frm.dtInherit.Select("Chon = true"))
				{
					if (drInherit["Ma_Vt_Sp"].ToString() != "CP" || drInherit["Stt"].ToString().StartsWith("LC"))
					{
						txtSo_Xe.Text = drInherit["So_Xe"].ToString();
						txtSo_Xa_Lan_Tau.Text = drInherit["So_Xa_Lan_Tau"].ToString();
						txtMa_Dt.Text = drInherit["Ma_Dt"].ToString();
						txtMa_Vt_Sp.Text = drInherit["Ma_Vt_Sp"].ToString();
						txtStt_LXH.Text = drInherit["Stt"].ToString();
						lbtTen_Dt.Text = drInherit["Ten_Dt"].ToString();
						lbtTen_Vt_Sp.Text = drInherit["Ten_Vt"].ToString();
						strStt_Org = drInherit["Stt"].ToString();
						numTai_Trong.Value = Convert.ToDouble(drInherit["Tai_Trong"]);
						txtDien_Giai.Text = drInherit["Ghi_Chu"].ToString();
						txtSo_Xe.ReadOnly = true;
						txtMa_Dt.ReadOnly = true;
						txtMa_Vt_Sp.ReadOnly = true;

						bInheritLC = true;
					}
					else
					{
						txtStt_LXH.Text = drInherit["Stt"].ToString();
						AddLX(txtStt_LXH.Text);
					}
				}
			}
			// 25/11/2024 Bằng rào đoạn này do không dùng
			//if (!btInherit.Enabled)
			//	return;

			//frmInherit_CtSO_Scale frmInherit = new frmInherit_CtSO_Scale();
			//frmInherit.Load(this.strStt_Org, txtMa_Vt_Org.Text.Trim(), true);

			//if (frmInherit.is_Accept)
			//{
			//	if (frmInherit.bIsUpdateInfo)
			//	{
			//		if ((frmInherit.strSo_Xe_TTKH == txtSo_Xe.Text)
			//				&& (frmInherit.strSo_Xa_Lan_Tau_TTKH == txtSo_Xa_Lan_Tau.Text)
			//				&& (frmInherit.strMa_Dt_TTKH == txtMa_Dt.Text)
			//				&& (frmInherit.strMa_Vt_Sp_TTKH == txtMa_Vt_Sp.Text))
			//			return;
			//		else
			//		{

			//                     if (!Common.MsgYes_No("Thông tin khách hàng thay đổi so với phiếu cân vào.Bạn có muốn cập nhật lại không?", "Y"))
			//                         return;

			//                     if (SQLExec.Execute("UPDATE R80PH_SCALE SET So_Xe = '" + frmInherit.strSo_Xe_TTKH + "', So_Xa_Lan_Tau = '" + frmInherit.strSo_Xa_Lan_Tau_TTKH + "', Ma_Dt = '" + frmInherit.strMa_Dt_TTKH + "', Ma_Vt_Sp = '" + frmInherit.strMa_Vt_Sp_TTKH + "' WHERE Stt = '" + this.strStt_Truck_In + "'", CommandType.Text))
			//                     {
			//                         txtSo_Xe.Text = frmInherit.strSo_Xe_TTKH;
			//                         txtSo_Xa_Lan_Tau.Text = frmInherit.strSo_Xa_Lan_Tau_TTKH;
			//                         txtMa_Dt.Text = frmInherit.strMa_Dt_TTKH;
			//                         lbtTen_Dt.Text = frmInherit.strTen_Dt_TTKH;
			//                         txtMa_Vt_Sp.Text = frmInherit.strMa_Vt_Sp_TTKH;
			//                         lbtTen_Vt_Sp.Text = frmInherit.strTen_Vt_Sp_TTKH;
			//                     }
			//                     else
			//                         Common.MsgCancel("Có lỗi cập nhật khi kế thừa lại thông tin khách hàng");


			//		}
			//	}
			//	else
			//	{
			//		if (this.strStt_Org == string.Empty)
			//			this.strStt_Org = txtStt_LXH.Text = frmInherit.txtStt.Text.Trim();

			//		strMa_Vt_Org = string.Empty;
			//		foreach (DataRow drInherit in frmInherit.dtInheritVoucher.Select("Chon = true"))
			//			strMa_Vt_Org = strMa_Vt_Org + drInherit["Ma_Vt"].ToString() + ",";

			//		if (strMa_Vt_Org.EndsWith(","))
			//			txtMa_Vt_Org.Text = strMa_Vt_Org.Substring(0, strMa_Vt_Org.Length - 1);

			//		if ((frmInherit.strSo_Xe_TTKH == txtSo_Xe.Text)
			//				&& (frmInherit.strSo_Xa_Lan_Tau_TTKH == txtSo_Xa_Lan_Tau.Text)
			//				&& (frmInherit.strMa_Dt_TTKH == txtMa_Dt.Text)
			//				&& (frmInherit.strMa_Vt_Sp_TTKH == txtMa_Vt_Sp.Text))
			//		{
			//			if (!SQLExec.Execute("UPDATE R80PH_SCALE SET Stt_Org = '" + this.strStt_Org + "', Ma_Vt_Org = '" + txtMa_Vt_Org.Text.Trim() + "' WHERE Stt = '" + this.strStt_Truck_In + "'", CommandType.Text))
			//				Common.MsgCancel("Có lỗi cập nhật khi kế thừa");
			//		}
			//		else
			//		{
			//                     if (frmInherit.strMa_Nvu != "LXH02")
			//                     {
			//			    if (!Common.MsgYes_No("Thông tin khách hàng thay đổi so với phiếu cân vào.Bạn có muốn cập nhật lại không?", "Y"))
			//			    {
			//				    if (!SQLExec.Execute("UPDATE R80PH_SCALE SET Stt_Org = '" + this.strStt_Org + "', Ma_Vt_Org = '" + txtMa_Vt_Org.Text.Trim() + "' WHERE Stt = '" + this.strStt_Truck_In + "'", CommandType.Text))
			//					    Common.MsgCancel("Có lỗi cập nhật khi kế thừa");
			//			    }
			//			    else
			//			    {
			//				    if (SQLExec.Execute("UPDATE R80PH_SCALE SET So_Xe = '" + frmInherit.strSo_Xe_TTKH + "', So_Xa_Lan_Tau = '" + frmInherit.strSo_Xa_Lan_Tau_TTKH + "', Ma_Dt = '" + frmInherit.strMa_Dt_TTKH + "', Ma_Vt_Sp = '" + frmInherit.strMa_Vt_Sp_TTKH + "', Stt_Org = '" + this.strStt_Org + "', Ma_Vt_Org = '" + txtMa_Vt_Org.Text.Trim() + "' WHERE Stt = '" + this.strStt_Truck_In + "'", CommandType.Text))
			//				    {
			//					    txtSo_Xe.Text = frmInherit.strSo_Xe_TTKH;
			//					    txtSo_Xa_Lan_Tau.Text = frmInherit.strSo_Xa_Lan_Tau_TTKH;
			//					    txtMa_Dt.Text = frmInherit.strMa_Dt_TTKH;
			//					    lbtTen_Dt.Text = frmInherit.strTen_Dt_TTKH;
			//					    txtMa_Vt_Sp.Text = frmInherit.strMa_Vt_Sp_TTKH;
			//					    lbtTen_Vt_Sp.Text = frmInherit.strTen_Vt_Sp_TTKH;
			//				    }
			//				    else
			//					    Common.MsgCancel("Có lỗi cập nhật khi kế thừa");
			//                             }
			//                         }
			//                     else
			//                     {
			//                         txtSo_Xe.Text = frmInherit.strSo_Xe_TTKH;
			//                         txtSo_Xa_Lan_Tau.Text = frmInherit.strSo_Xa_Lan_Tau_TTKH;
			//                         txtMa_Dt.Text = frmInherit.strMa_Dt_TTKH;
			//                         lbtTen_Dt.Text = frmInherit.strTen_Dt_TTKH;
			//                         txtMa_Vt_Sp.Text = frmInherit.strMa_Vt_Sp_TTKH;
			//                         lbtTen_Vt_Sp.Text = frmInherit.strTen_Vt_Sp_TTKH;
			//                     }

			//		}
			//	}


			//}
			//else
			//{
			//	txtStt_LXH.Text = txtInfoInherit.Text = txtMa_Vt_Org.Text = strStt_Org = string.Empty;
			//}
		}

		void btInherit2_Click(object sender, EventArgs e)
		{
			if (!btInherit2.Enabled)
				return;

			frmInherit_CtSO_Scale frmInherit = new frmInherit_CtSO_Scale();
			frmInherit.Load(txtStt_LXH2.Text.Trim(), txtMa_Vt_Org2.Text.Trim(), false);

			if (frmInherit.is_Accept)
			{
				if (txtStt_LXH2.Text.Trim() == string.Empty)
					txtStt_LXH2.Text = frmInherit.txtStt.Text.Trim();

				string strMa_Vt_Org2 = string.Empty;
				foreach (DataRow drInherit in frmInherit.dtInheritVoucher.Select("Chon = true"))
					strMa_Vt_Org2 = strMa_Vt_Org2 + drInherit["Ma_Vt"].ToString() + ",";

				if (strMa_Vt_Org2.EndsWith(","))
					txtMa_Vt_Org2.Text = strMa_Vt_Org2.Substring(0, strMa_Vt_Org2.Length - 1);

				if (!SQLExec.Execute("UPDATE R80PH_SCALE SET Stt_Org = '" + txtStt_LXH2.Text.Trim() + "', Ma_Vt_Org = '" + txtMa_Vt_Org2.Text.Trim() + "' WHERE Stt = '" + this.strStt_Truck_Out + "'", CommandType.Text))
					Common.MsgCancel("Có lỗi cập nhật khi kế thừa");
				else
					Common.MsgCancel("Đã cập nhật lại dữ liệu kế thừa");
			}
		}

		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{
				case Keys.F6:
					if (dtTruck_In.Rows.Count > 0)
						this.ChangeMode(enuEdit.Edit);
					return;

				case Keys.F5:
					this.ChangeMode(enuEdit.New);
					return;
					
				case Keys.F11:
					this.btEdit_Voucher_Click(null, null);
					return;

                //case Keys.F9:
                //    btConvert_Scale_Click(null, null);
                //    return;

				case Keys.F7:
					if(e.Modifiers == Keys.Shift)
						this.Design();
					return;

				case Keys.F12:
					this.btScale_Detail_Click(null, null);
					return;

				case Keys.F10:
					if(tcCan_Xe.SelectedTab == tpSua_Phieu)
						this.btInherit2_Click(null, null);
					else
						this.btInherit_Click(null, null);
					return;

				case Keys.T:
					if (e.Modifiers == Keys.Control)
					{
						frmTestCom frm = new frmTestCom();
						frm.Load("Scale6080");
					}
					return;
			}

			base.OnKeyDown(e);
		}

		private void Design()
		{
			frmChon_In_Scale frmIn_Scale = new frmChon_In_Scale();
			frmIn_Scale.Load("");

			string strFile_Name = "rpt";

			strFile_Name += frmIn_Scale.rdbTruck_In.Checked ? frmIn_Scale.rdbTruck_In.Name.Substring(3, frmIn_Scale.rdbTruck_In.Name.Length - 3)
				: frmIn_Scale.rdbTruck_Out.Checked ? frmIn_Scale.rdbTruck_Out.Name.Substring(3, frmIn_Scale.rdbTruck_Out.Name.Length - 3)
				: frmIn_Scale.rdbScale_Out.Checked ? frmIn_Scale.rdbScale_Out.Name.Substring(3, frmIn_Scale.rdbScale_Out.Name.Length - 3)
                //: frmIn_Scale.rdbCo_Tinh.Checked ? frmIn_Scale.rdbCo_Tinh.Name.Substring(3, frmIn_Scale.rdbCo_Tinh.Name.Length - 3)
                //: frmIn_Scale.rdbGCN.Checked ? frmIn_Scale.rdbGCN.Name.Substring(3, frmIn_Scale.rdbGCN.Name.Length - 3)
                //: frmIn_Scale.rdbTP_HH.Checked ? frmIn_Scale.rdbTP_HH.Name.Substring(3, frmIn_Scale.rdbTP_HH.Name.Length - 3) 
                : "Truck_In";

			RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strFile_Name);
		}
		private void TxtSo_Xe_Validating(object sender, CancelEventArgs e)
		{
			if(txtStt_LXH.Text == "")
            {
				string strSo_Xe = Voucher.GetFormatSoXe(txtSo_Xe.Text.Trim());
				txtSo_Xe.Text = strSo_Xe;
			}
			
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if(!Element.sysIs_Admin)
			{
				if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
					this.Allow_New = this.btScale.Enabled = this.btSave_Print.Enabled = this.btInherit.Enabled = false;

				if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
					this.Allow_Edit = this.btEdit_Out.Enabled = this.btInherit_TTKH.Enabled = this.btgAccept.btAccept.Enabled = false;
			}

			if (Common.CheckPermission("ACCESS_SAVE_TC", enuPermission_Type.Allow_Access))
			{
				numSo_Luong_Vao.ReadOnly = numSo_Luong_Ra.ReadOnly = false;
				btSave_Handle.Visible = true;
			}

			this.txtStt_LXH.Focus();
		}

        private void frmScale_Load(object sender, EventArgs e)
        {

        }

	}
}
