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

namespace RosyModule.Inventory
{
	public partial class frmScale : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
		string strMa_Ct;
		DataRow drDmCt;
		DataRow drDmNvu;
		DataSet dsVoucher = new DataSet();
		DataTable dtEditPh;
		DataTable dtEditPh_Dest;
		DataTable dtEditCt;
		DataRow drEditPh;
		DataRow drEditCt;
		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
		string strStt = string.Empty;
		string strStt_Old = string.Empty;

		BindingSource bdsDmDt = new BindingSource();
		DataTable dtDmDt;

		BindingSource bdsTruck_In = new BindingSource();
		DataTable dtTruck_In;

		BindingSource bdsTruck_Out = new BindingSource();
		DataTable dtTruck_Out;

		BindingSource bdsDmVtSp = new BindingSource();
		DataTable dtDmVtSp;
		DataRow drCurrent;

		public enuEdit enuNew_Edit = enuEdit.New;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;
		string strScale_Name = "CANA";

		double dbNet_Weight_Min = 0;
		double dbOld_Weight;
		bool bStable = false;

		bool bEnable = true;
		bool isAccept = false;
		int iNum_Stabilize = 0;

		string strSo_Xe_Old = string.Empty;
		string strMa_Dt_Old = string.Empty;
		double dbSo_Luong_Ra_Old = 0;
		bool bTare = false;
		string strStt_Truck_In = string.Empty;
		string strStt_Truck_Out = string.Empty;

		#endregion

		public frmScale()
		{
			InitializeComponent();

			this.InitForm();

			this.txtTime_Clock.Tick += new EventHandler(txtTime_Clock_Tick);
			this.dgvDmVt.DoubleClick += new EventHandler(dgvDmVt_DoubleClick);
			this.dgvDmDt.DoubleClick += new EventHandler(dgvDmDt_DoubleClick);
			this.btScale_In.Click += new EventHandler(btScale_In_Click);
			this.btScale_Out.Click += new EventHandler(btScale_Out_Click);
			this.btConvert_Scale.Click += new EventHandler(btConvert_Scale_Click);
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
			this.btPrint_Out.Click += new EventHandler(btPrint_Out_Click);
			this.btPrint_In.Click += new EventHandler(btPrint_In_Click);
			this.btPrint.Click += new EventHandler(btPrint_Click);

			this.tcControl.SelectedIndexChanged += new EventHandler(tcControl_SelectedIndexChanged);
			this.cboSo_Xe_Ct.SelectedValueChanged += new EventHandler(cboSo_Xe_Ct_SelectedValueChanged);
			this.cboSo_Ct_Ct.SelectedValueChanged += new EventHandler(cboSo_Ct_Ct_SelectedValueChanged);
			this.rdbSo_Xe_Ct.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
			this.txtBarcode_Ct.KeyDown += new KeyEventHandler(txtBarcode_Ct_KeyDown);
			this.btSave_Voucher.Click += new EventHandler(btSave_Voucher_Click);
			this.txtBarcode_Ct.LostFocus += new EventHandler(txtBarcode_Ct_LostFocus);
			this.dgvEditCt.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);

			this.txtMa_Vt_Sp2.Validating += new CancelEventHandler(txtMa_Vt_Sp2_Validating);
			this.txtMa_Dt2.Validating += new CancelEventHandler(txtMa_Dt2_Validating);
			this.txtBarcode_Search.KeyDown += new KeyEventHandler(txtBarcode_Search_KeyDown);
			this.txtSo_Xe_Search.KeyDown += new KeyEventHandler(txtSo_Xe_Search_KeyDown);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);

			this.dgvEditCt.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);
		}

		new public void Load(string strMa_Ct)
		{
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
			string strSQLExec = "SELECT * FROM R81EQUIPMENTINFO WHERE Host_IP = '" + MachineInfo.GetHostIP() + "' AND Can = '" + strScale_Name + "'";
			DataTable dtEquipment = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
			if (dtEquipment.Rows.Count > 0)
			{
				DataRow drEquipment = dtEquipment.Rows[0];
				if (drEquipment != null)
				{

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

			dgvDmVt.strZone = "DMSP_SCALE";
			dgvDmVt.BuildGridView();

			dgvTruck_In.strZone = "PH_SCALE_TRUCK_IN";
			dgvTruck_In.Dock = DockStyle.Fill;
			dgvTruck_In.BuildGridView();

			dgvTruck_Out.strZone = "PH_SCALE_TRUCK_OUT";
			dgvTruck_Out.BuildGridView();

			dgvEditCt.bSortMode = false;
			dgvEditCt.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt.BuildGridView();

			this.DataGridView_Language();

			this.txtMa_Vt_Sp.bUseAutoDropDown = true;
			this.txtMa_Dt.bUseAutoDropDown = true;
		}

		private void DataGridView_Language()
		{
			dgvTruck_In.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTruck_In.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			dgvTruck_Out.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTruck_Out.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			dgvEditCt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEditCt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvEditCt.Columns.Contains("Ngay_Sx"))
				dgvEditCt.Columns["Ngay_Sx"].Frozen = true;

			if (dgvEditCt.Columns.Contains("So_Luong"))
				dgvEditCt.Columns["So_Luong"].HeaderText = "KL trên xe";

			if (dgvEditCt.Columns.Contains("Num_Bars"))
				dgvEditCt.Columns["Num_Bars"].HeaderText = "Số cây trên xe";

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

			//ReadOnly
			string strColumn_Name = "BARCODE,SO_LUONG,SO_LUONG_CURRENT,NUM_BARS_CURRENT,SO_LUONG_BARCODE,NUM_BARS_BARCODE,LENGTH,NGAY_SX,CANUM_LOT,TEN_VT,GRADE_NAME,STANDARD_NAME,TEN_CL,IS_OUTPUT";
			foreach (var strColumn in strColumn_Name.Split(','))
			{
				if (dgvEditCt.Columns.Contains(strColumn))
					dgvEditCt.Columns[strColumn].ReadOnly = true;
			}
		}

		private void FillData()
		{
			//Danh mục đối tượng
			dtDmDt = DataTool.SQLGetDataTable("R81DMDT", "*", "Ma_Nh_Dt NOT IN('NV','NB')", "MA_DT");
			bdsDmDt.DataSource = dtDmDt;
			dgvDmDt.DataSource = bdsDmDt;

			//Danh mục vật tư
			dtDmVtSp = DataTool.SQLGetDataTable("R81DMVT", "*", "", "MA_VT");
			bdsDmVtSp.DataSource = dtDmVtSp;
			dgvDmVt.DataSource = bdsDmVtSp;
		}

		private void Init_Ct()
		{
			dteNgay_Ct1.Text = dteNgay_Ct2.Text = Library.DateToStr(DateTime.Now);

			txtMa_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);

			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				txtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				txtTen_Dt_CbNv.Text = string.Empty;

			try
			{
				txtMa_Nvu.Text = DataTool.SQLGetNameByCode("R81DMNVU", "Ma_Ct", "Ma_NVu", strMa_Ct);
			}
			catch
			{
				txtMa_Nvu.Text = "PX30";
			}

			lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DMNVU", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			drDmNvu = DataTool.SQLGetDataRowByID("R81DMNVU", "Ma_NVu", txtMa_Nvu.Text.Trim());
		}

		private void FillData_Voucher()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CT", this.strMa_Ct);
			htPara.Add("NGAY_CT1", Voucher.GetDate_Server().AddDays(-2));
			htPara.Add("NGAY_CT2", Voucher.GetDate_Server());
			htPara.Add("DUYET", 1);

			dtEditPh = SQLExec.ExecuteReturnDt("sp_GetVoucher_Scale_PH", htPara, CommandType.StoredProcedure);
			bdsEditPh.DataSource = dtEditPh;

			if (dtEditPh.Rows.Count == 0)
			{
				DataRow drNew = dtEditPh.NewRow();
				Common.SetDefaultDataRow(ref drNew);
				dtEditPh.Rows.Add(drNew);
			}

			//Lấy Số xe trong ngày và Duyet = 1
			List<KeyValuePair<object, object>> lstSo_Xe = new List<KeyValuePair<object, object>>();
			List<KeyValuePair<object, object>> lstSo_Ct = new List<KeyValuePair<object, object>>();
			AutoCompleteStringCollection accSo_Xe = new AutoCompleteStringCollection();
			AutoCompleteStringCollection accSo_Ct = new AutoCompleteStringCollection();
			
			lstSo_Xe.Add(new KeyValuePair<object, object>("", ""));
			lstSo_Ct.Add(new KeyValuePair<object, object>("", ""));
			accSo_Xe.Add("");
			accSo_Ct.Add("");

			foreach (DataRow dr in dtEditPh.Rows)
			{
				lstSo_Xe.Add(new KeyValuePair<object, object>(dr["Stt"], dr["So_Xe"]));
				lstSo_Ct.Add(new KeyValuePair<object, object>(dr["Stt"], dr["So_Ct"]));
				accSo_Xe.Add(dr["So_Xe"].ToString());
				accSo_Ct.Add(dr["So_Ct"].ToString());
			}

			// Add data to the List
			cboSo_Xe_Ct.DataSource = null;
			cboSo_Xe_Ct.Items.Clear();
			cboSo_Xe_Ct.DataSource = new BindingSource(lstSo_Xe, null);
			cboSo_Xe_Ct.DisplayMember = "Value";
			cboSo_Xe_Ct.ValueMember = "Key";

			cboSo_Xe_Ct.AutoCompleteMode = AutoCompleteMode.Suggest;
			cboSo_Xe_Ct.AutoCompleteSource = AutoCompleteSource.CustomSource;
			cboSo_Xe_Ct.AutoCompleteCustomSource = accSo_Xe;


			cboSo_Ct_Ct.DataSource = null;
			cboSo_Ct_Ct.Items.Clear();
			cboSo_Ct_Ct.DataSource = new BindingSource(lstSo_Ct, null);
			cboSo_Ct_Ct.DisplayMember = "Value";
			cboSo_Ct_Ct.ValueMember = "Key";

			cboSo_Ct_Ct.AutoCompleteMode = AutoCompleteMode.Suggest;
			cboSo_Ct_Ct.AutoCompleteSource = AutoCompleteSource.CustomSource;
			cboSo_Ct_Ct.AutoCompleteCustomSource = accSo_Ct;

			this.ExportControl = dgvEditCt;
		}

		private void FillData_Voucher_Edit()
		{
			if (!string.IsNullOrEmpty(strStt))
			{
				dtEditPh.DefaultView.RowFilter = "Stt = '" + strStt + "'";
				dtEditPh_Dest = dtEditPh.DefaultView.ToTable();
				drEditPh = dtEditPh_Dest.Rows[0];
				this.ScaterMemvar_Voucher_Edit(drEditPh);

				this.FillData_Voucher_Ct();
			}
			else
				this.Reset_Voucher_Edit();
		}

		private void FillData_Voucher_Ct()
		{
			dtEditCt = SQLExec.ExecuteReturnDt("sp_GetVoucher_Scale_Ct", new string[] { "Ma_Ct", "Stt" }, new object[] { this.strMa_Ct, this.strStt }, CommandType.StoredProcedure);

			DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtEditCt.Columns.Add(dc);

			bdsEditCt.DataSource = dtEditCt;
			dgvEditCt.DataSource = bdsEditCt;
			dgvEditCt.ClearSelection();

			if(dtEditCt.Rows.Count == 0)
				enuNew_Edit_Voucher = enuEdit.New;
			else
				enuNew_Edit_Voucher = enuEdit.Edit;

			numTSL_Barcode.Value = Common.SumDCValue(dtEditCt, "So_Luong", "Deleted = 0");
			DataView dvEditCt = new DataView(dtEditCt);
			dvEditCt.RowFilter = "Deleted = 0";
			numTSo_Barcode.Value = dvEditCt.ToTable().Rows.Count;
		}

		private void Calc_So_Luong(bool bThep_Cay)
		{
			numTSL_Barcode.Value = Common.SumDCValue(dtEditCt, "So_Luong", "Deleted = 0");

			DataView dvEditCt = new DataView(dtEditCt);
			dvEditCt.RowFilter = "Deleted = 0";
			numTSo_Barcode.Value = dvEditCt.ToTable().Rows.Count;

			double dbMin_Conditon = 0;
			double dbMax_Condition = 0;
			string strFormular = string.Empty;
			string strFormular1 = string.Empty;
			double dbValue1 = 0;
			double dbValue2 = 0;
			bool bFlag = false;
			string[] arrSeparators = { "[", "]", "+", "-", "*", ":" };

			DataTable dtFormular = DataTool.SQLGetDataTable("R81FORMULAR_SCALE", "", "", "Formular_ID");
			foreach (DataRow drFormular in dtFormular.Rows)
			{
				if (bFlag)
					continue;

				strFormular = (string)drFormular["Formular"];
				string strCondition = (string)drFormular["Condition"];
				string[] arrCondition = strCondition.Split(arrSeparators, StringSplitOptions.RemoveEmptyEntries);

				if (arrCondition.Length == 2)
				{
					dbMin_Conditon = Convert.ToDouble(arrCondition[0]);
					dbMax_Condition = Convert.ToDouble(arrCondition[1]);

					if (numSL_Xe_Hang.Value > dbMin_Conditon && numSL_Xe_Hang.Value <= dbMax_Condition)
						bFlag = true;
				}
				else
				{
					dbMin_Conditon = 0;
					dbMax_Condition = 0;
				}
			}

			strFormular1 = strFormular;
			string[] arrWords = strFormular1.Split(arrSeparators, StringSplitOptions.RemoveEmptyEntries);
			if (arrWords.Length == 3)
			{
				dbValue1 = Convert.ToDouble(arrWords[0]);
				dbValue2 = Convert.ToDouble(arrWords[1]);
			}

			//So luong Quyet dinh
			numSL_QDinh.Value = dbValue1 + (dbValue2 * numTSo_Barcode.Value);

			//So luong chenh lech: Dang tinh thep cay.
			if (bThep_Cay)
				numSL_CL.Value = numSL_Xe_Hang.Value - numTSL_Barcode.Value;
			else
				numSL_CL.Value = numSL_Xe_Hang.Value - (4 * numTSo_Barcode.Value) - numTSL_Barcode.Value;

		}

		private void AddRowBarcode(DataTable dtBarcode, ref bool bThep_Cay)
		{
			DataRow drDmBarcode = dtBarcode.Rows[0];
			bool bRow_First = false;
			DataRow drNewRow = null;

			if (dtEditCt.Rows.Count == 0)
			{
				drNewRow = dtEditCt.NewRow();
				Common.SetDefaultDataRow(ref drNewRow);
				bRow_First = true;
			}

			if (!bRow_First)
			{
				drEditCt = ((DataRowView)bdsEditCt.Current).Row;
				drNewRow = dtEditCt.NewRow();
				Common.CopyDataRow(drEditCt, drNewRow);
				Common.SetDefaultDataRow(ref drNewRow);
			}

			int iStt0 = dtEditCt.Rows.Count + 1;

			drNewRow["Stt"] = strStt;
			drNewRow["Stt0"] = iStt0;
			drNewRow["Ma_Nvu"] = txtMa_Nvu.Text.Trim();
			drNewRow["Ma_Ct"] = this.strMa_Ct;
			drNewRow["So_Ct"] = txtSo_Ct_Ct.Text;
			drNewRow["Ngay_Ct"] = dteNgay_Ct_Ct.Text;
			drNewRow["Ma_Dt"] = txtMa_Dt_Ct.Text.Trim();
			drNewRow["Dien_Giai"] = txtDien_Giai_Ct.Text;
			drNewRow["Barcode"] = drDmBarcode["Barcode"];
			drNewRow["Ma_Vt_Sp"] = drDmBarcode["Ma_Vt_Sp"];

			drNewRow["Ma_Vt"] = drDmBarcode["Ma_Vt"];
			drNewRow["Ten_Vt"] = drDmBarcode["Ten_Vt"];
			drNewRow["So_Luong"] = drDmBarcode["So_Luong_Current"];
			drNewRow["Num_Bars"] = drDmBarcode["Num_Bars_Current"];

			drNewRow["So_Luong_Current"] = drDmBarcode["So_Luong_Current"];
			drNewRow["Num_Bars_Current"] = drDmBarcode["Num_Bars_Current"];

			drNewRow["So_Luong_Barcode"] = drDmBarcode["So_Luong"];
			drNewRow["Num_Bars_Barcode"] = drDmBarcode["Num_Bars"];
			
			drNewRow["Length"] = drDmBarcode["Length"];
			drNewRow["Ma_Ca"] = drDmBarcode["Ma_Ca"];
			drNewRow["Ngay_Sx"] = drDmBarcode["Ngay_Sx"];
			drNewRow["Ca"] = drDmBarcode["Ca"];
			drNewRow["Grade_ID"] = drDmBarcode["Grade_ID"];
			drNewRow["Grade_Name"] = drDmBarcode["Grade_Name"];
			drNewRow["Standard_ID"] = drDmBarcode["Standard_ID"];
			drNewRow["Standard_Name"] = drDmBarcode["Standard_Name"];
			drNewRow["Ma_CL"] = drDmBarcode["Ma_CL"];
			drNewRow["Ten_CL"] = drDmBarcode["Ten_CL"];
			drNewRow["Num_Lot"] = drDmBarcode["Num_Lot"];
			drNewRow["Is_OutPut"] = drDmBarcode["Is_OutPut"];

			if (Convert.ToDouble(drDmBarcode["Num_Bars"]) != 0)
				bThep_Cay = true;
			else
				bThep_Cay = false;

			dtEditCt.Rows.Add(drNewRow);
			dtEditCt.AcceptChanges();

		}

		private void Reset_Voucher_Edit()
		{
			dteNgay_Ct_Ct.Text = string.Empty;
			txtSo_Ct_Ct.Text = txtMa_Dt_Ct.Text = lbtTen_Dt_Ct.Text = txtOng_Ba_Ct.Text = txtDia_Chi_Ct.Text = txtMa_Vt_Sp_Ct.Text = lbtTen_Vt_Sp_Ct.Text = txtDien_Giai_Ct.Text = txtLy_Do_Ct.Text = txtSo_Xe_Ct.Text = txtTime_In_Ct.Text = txtTime_Out_Ct.Text = string.Empty;
			numSo_Luong_Vao_Ct.Value = numSo_Luong_Ra_Ct.Value = numSo_Luong_Ct.Value = 0;

			if (dtEditCt != null)
				dtEditCt.Rows.Clear();
		}

		private void ScaterMemvar_Voucher_Edit(DataRow drEditPh)
		{
			dteNgay_Ct_Ct.Text = Library.DateToStr(Convert.ToDateTime(drEditPh["Ngay_Ct"]));
			txtSo_Ct_Ct.Text = (string)drEditPh["So_Ct"];
			txtMa_Dt_Ct.Text = (string)drEditPh["Ma_Dt"];
			if (txtMa_Dt_Ct.Text.Trim() != string.Empty)
			{
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt_Ct.Text.Trim());
				lbtTen_Dt_Ct.Text = (string)drDmDt["Ten_Dt"];
				txtOng_Ba_Ct.Text = drDmDt["Ong_Ba"].ToString() == string.Empty ? lbtTen_Dt_Ct.Text : drDmDt["Ong_Ba"].ToString();
				txtDia_Chi_Ct.Text = drDmDt["Dia_Chi"].ToString();
			}
			else
			{
				lbtTen_Dt_Ct.Text = txtOng_Ba_Ct.Text = txtDia_Chi_Ct.Text = string.Empty;
			}

			txtMa_Vt_Sp_Ct.Text = (string)drEditPh["Ma_Vt_Sp"];
			if (txtMa_Vt_Sp_Ct.Text.Trim() != string.Empty)
				lbtTen_Vt_Sp_Ct.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp_Ct.Text.Trim());
			else
				lbtTen_Vt_Sp_Ct.Text = string.Empty;

			
			txtDien_Giai_Ct.Text = (string)drEditPh["Dien_Giai"];
			txtLy_Do_Ct.Text = (string)drEditPh["Ly_Do"];
			txtSo_Xe_Ct.Text = (string)drEditPh["So_Xe"];
			numSo_Luong_Vao_Ct.Value = drEditPh["So_Luong_Vao"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh["So_Luong_Vao"]);
			numSo_Luong_Ra_Ct.Value = drEditPh["So_Luong_Ra"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh["So_Luong_Ra"]);
			numSo_Luong_Ct.Value = drEditPh["So_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh["So_Luong"]);
			txtTime_In_Ct.Text = drEditPh["Time_In"] == DBNull.Value ? "00:00" : Convert.ToDateTime(drEditPh["Time_In"].ToString()).ToShortTimeString();
			txtTime_Out_Ct.Text = drEditPh["Time_Out"] == DBNull.Value ? "00:00" : Convert.ToDateTime(drEditPh["Time_Out"].ToString()).ToShortTimeString();

			double dbSl_Xe_Hang = drEditPh["SL_Xe_Hang"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh["SL_Xe_Hang"]);
			if (dbSl_Xe_Hang <= 0)
				numSL_Xe_Hang.Value = numSo_Luong_Ra_Ct.Value;
			else
				numSL_Xe_Hang.Value = dbSl_Xe_Hang;

			numTSL_Barcode.Value = drEditPh["TSL_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh["TSL_Barcode"]);
			numTSo_Barcode.Value = drEditPh["TSo_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh["TSo_Barcode"]);
			numSL_QDinh.Value = drEditPh["SL_QDinh"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh["SL_QDinh"]);
			numSL_CL.Value = drEditPh["SL_CL"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh["SL_CL"]);
			txtGhi_Chu_QDinh.Text = drEditPh["Ghi_Chu_QDinh"] == DBNull.Value ? string.Empty : (string)drEditPh["Ghi_Chu_QDinh"];
		}

		private void GatherMemvar_Voucher_Edit()
		{
			dtEditPh_Dest.Rows[0]["SL_Xe_Hang"] = numSL_Xe_Hang.Value;
			dtEditPh_Dest.Rows[0]["TSL_Barcode"] = numTSL_Barcode.Value;
			dtEditPh_Dest.Rows[0]["TSo_Barcode"] = numTSo_Barcode.Value;
			dtEditPh_Dest.Rows[0]["SL_QDinh"] = numSL_QDinh.Value;
			dtEditPh_Dest.Rows[0]["SL_CL"] = numSL_CL.Value;
			dtEditPh_Dest.Rows[0]["Ghi_Chu_QDinh"] = txtGhi_Chu_QDinh.Text;

			dtEditPh_Dest.AcceptChanges();
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
					htInsert.Add("SO_LUONG_VAO", numSo_Luong_Vao.Value);
					htInsert.Add("SO_LUONG_RA", numSo_Luong_Ra.Value);
					htInsert.Add("SO_LUONG", numSo_Luong.Value);
					htInsert.Add("CREATE_LOG", Common.GetCurrent_Log());
					htInsert.Add("MA_DVCS", Element.sysMa_DvCs);

					string strStt = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_PH_Scale", htInsert, CommandType.StoredProcedure));
					if (strStt != string.Empty)
					{
						this.bEnable = false;
						this.btScale.Enabled = false;
						this.btSave_Print.Enabled = false;
						this.txtSo_Xe.Enabled = true;
						if (this.chkPrint_In.Checked)
						{
							//Print Voucher
							this.Print(strStt, "IN", false);
						}
						this.ChangeMode(enuEdit.New);
					}
					break;
				case enuEdit.Edit:

					if (!this.bEnable)
						return;

					if (this.numSo_Luong_Ra.Value <= 0)
					{
						Common.MsgCancel("Khối lượng cân ra không phù hợp");
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
					htUpdate.Add("SO_LUONG_VAO", numSo_Luong_Vao.Value);
					htUpdate.Add("SO_LUONG_RA", numSo_Luong_Ra.Value);
					htUpdate.Add("SO_LUONG", numSo_Luong.Value);
					htUpdate.Add("DUYET", true);
					htUpdate.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
					htUpdate.Add("MA_DVCS", Element.sysMa_DvCs);

					if (SQLExec.Execute("sp_Update_PH_Scale", htUpdate, CommandType.StoredProcedure))
					{
						this.strSo_Xe_Old = txtSo_Xe.Text.Trim();
						this.strMa_Dt_Old = txtMa_Dt.Text.Trim();
						this.dbSo_Luong_Ra_Old = numSo_Luong_Ra.Value;
						
						if (Common.MsgYes_No("Xe có tiếp tục lấy hàng không?", "N"))
						{
							this.bEnable = true;
							this.ChangeMode(enuEdit.New);
							this.txtSo_Xe.Text = strSo_Xe_Old;
							this.txtMa_Dt.Text = strMa_Dt_Old;
							this.numSo_Luong_Vao.Value = dbSo_Luong_Ra_Old;
							this.txtSo_Xe.Enabled = false;
							this.txtMa_Vt_Sp.Focus();
							this.btScale.Enabled = true;
							this.btSave_Print.Enabled = true;
						}
						else
						{
							this.ChangeMode(enuEdit.Edit);
							this.bTare = false;
							this.btScale.Enabled = false;
							this.btSave_Print.Enabled = false;
						}

						if (this.chkPrint_Out.Checked)
						{
							this.Print(this.strStt_Truck_In, "OUT", true);
						}
					}
					break;
			}

			this.LoadTruck_In();
			this.LoadTruck_Out();
			txtSo_Xe.Focus();
		}

		private void Print(string strStt, string strTruck_In_Out, bool bPreview)
		{
			Voucher.PrintTruck_In_Out(strStt, strTruck_In_Out, strTruck_In_Out == "IN" ? "rptTruck_In" : "rptTruck_Out", bPreview, Variables.strPrint_Barcode);
		}

		//Xe mới cân vào, chưa cân ra --> Xe trong kho
		private void LoadTruck_In()
		{
			dtTruck_In = SQLExec.ExecuteReturnDt("sp_GetPH_Scale_Truck_In", "Ma_Ct", strMa_Ct, CommandType.StoredProcedure);
			bdsTruck_In.DataSource = dtTruck_In;
			dgvTruck_In.DataSource = bdsTruck_In;
			
			bdsTruck_In.Position = 0;

			if (dtTruck_In.Rows.Count == 0)
				btScale_Out.Enabled = btPrint_In.Enabled = btDelete_In.Enabled = false;
			else
				btScale_Out.Enabled = btPrint_In.Enabled = btDelete_In.Enabled = true;
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
				Common.MsgCancel(Languages.GetLanguageInfo("Ma_Dt") + " " + Languages.GetLanguageInfo("Not_Null"));
				return false;
			}

			if (txtMa_Vt_Sp.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguageInfo("Ma_Vt_Sp") + " " + Languages.GetLanguageInfo("Not_Null"));
				return false;
			}

			return true;
		}

		private void ChangeMode(enuEdit enuNew_Edit)
		{
			this.enuNew_Edit = enuNew_Edit;

			if (enuNew_Edit == enuEdit.New)
			{
				this.txtSo_Xe.Focus();
				this.btScale_In.ForeColor = Color.Red;
				this.btScale_Out.ForeColor = Color.FromArgb(16, 37, 127);
				this.btEdit_Voucher.ForeColor = Color.FromArgb(16, 37, 127);
				this.GetNewSo_Ct();

				this.tcCan_Xe.SelectedTab = tpCan_Xe;
				this.btSave_Print.Enabled = false;
				this.dgvDmDt.Visible = this.dgvDmVt.Visible = this.btNew_Dt.Visible = this.btNew_Vt.Visible = true;
				this.grbSearch.Visible = this.dgvTruck_In.Visible = btPrint_In.Visible = btDelete_In.Visible = false;

				txtMa_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);

				if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
					txtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
				else
					txtTen_Dt_CbNv.Text = string.Empty;
			}
			else if (enuNew_Edit == enuEdit.Edit)
			{
				this.txtBarcode_Search.Focus();
				this.btScale_In.ForeColor = Color.FromArgb(16, 37, 127);
				this.btEdit_Voucher.ForeColor = Color.FromArgb(16, 37, 127);
				this.btScale_Out.ForeColor = Color.Red;

				this.tcCan_Xe.SelectedTab = tpCan_Xe;
				this.btSave_Print.Enabled = false;
				this.dgvDmDt.Visible = this.dgvDmVt.Visible = this.btNew_Dt.Visible = this.btNew_Vt.Visible = false;
				this.grbSearch.Visible = this.dgvTruck_In.Visible = btPrint_In.Visible = btDelete_In.Visible = true;
				
				this.bdsTruck_In_PositionChanged(null, null);
			}
		}

		private void GetNewSo_Ct()
		{
			txtSo_Ct.Text = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Stt)) AS BIGINT)), 0) + 1 FROM R80PH_SCALE WHERE Ma_Ct = '" + strMa_Ct + "' AND YEAR(Ngay_Ct) = YEAR(GETDATE())"));
			txtSo_Xe.Text = this.txtDien_Giai.Text = string.Empty;

			txtMa_Dt.Text = string.Empty;
			numSo_Luong_Vao.Value = numSo_Luong_Ra.Value = numSo_Luong.Value = 0;
			txtSo_Xe.Focus();
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
			if (dbWeight > 100.0)
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
			txtSo_Ct.Text = (string)drCurrent["So_Ct"];
			txtSo_Xe.Text = (string)drCurrent["So_Xe"];
			txtMa_Dt.Text = (string)drCurrent["Ma_Dt"];
			lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "MA_DT", "Ten_DT", txtMa_Dt.Text.Trim());
			txtMa_Vt_Sp.Text = (string)drCurrent["Ma_Vt_Sp"];
			lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "MA_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			txtDien_Giai.Text = (string)drCurrent["Dien_Giai"];
			txtMa_Dt_CbNv.Text = (string)drCurrent["Ma_Dt_CbNv_Vao"];
			numSo_Luong_Vao.Value = Convert.ToDouble(drCurrent["So_Luong_Vao"]);
		}

		private void ScaterMemvar_Truck_Out()
		{
			drCurrent = ((DataRowView)bdsTruck_Out.Current).Row;

			strStt_Truck_Out = (string)drCurrent["Stt"];
			txtSo_Ct2.Text = (string)drCurrent["So_Ct"];
			txtSo_Xe2.Text = (string)drCurrent["So_Xe"];
			txtMa_Dt2.Text = (string)drCurrent["Ma_Dt"];
			lbtTen_Dt2.Text = DataTool.SQLGetNameByCode("R81DMDT", "MA_DT", "TEN_DT", txtMa_Dt2.Text.Trim());
			txtMa_Vt_Sp2.Text = (string)drCurrent["Ma_Vt_Sp"];
			lbtTen_Vt_Sp2.Text = DataTool.SQLGetNameByCode("R81DMVT", "MA_VT", "TEN_VT", txtMa_Vt_Sp2.Text.Trim());
			txtDien_Giai2.Text = (string)drCurrent["Dien_Giai"];
			txtLy_Do2.Text = (string)drCurrent["Ly_Do"];
			txtTime_In2.Text = drCurrent["Time_In"].ToString();
			txtTime_Out2.Text = drCurrent["Time_Out"].ToString();
			numSo_Luong_Vao2.Value = Convert.ToDouble(drCurrent["So_Luong_Vao"]);
			numSo_Luong_Ra2.Value = Convert.ToDouble(drCurrent["So_Luong_Ra"]);
			numSo_Luong2.Value = Convert.ToDouble(drCurrent["So_Luong"]);
		}

		private void Reset_Truck_Out()
		{
			strStt_Truck_Out = txtSo_Ct2.Text = txtSo_Xe2.Text = txtTime_In2.Text = txtTime_Out2.Text = txtDien_Giai2.Text = txtLy_Do2.Text = string.Empty;
			txtMa_Dt2.Text = txtMa_Vt_Sp2.Text = string.Empty;
			numSo_Luong_Vao2.Value = numSo_Luong_Ra2.Value = numSo_Luong2.Value = 0;
			btgAccept.Enabled = false;
		}

		void tcControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcControl.SelectedTab == tpVoucher)
			{
				this.FillData_Voucher();
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

			this.bdsTruck_Out_PositionChanged(null, null);
		}

		#region Event

		void HardwareInterfaceScale6080_DataReceive(double dbValue, string strType)
		{
			this.UpdateScaleInfo(dbValue);
		}

		void btSave_Print_Click(object sender, EventArgs e)
		{
			this.Save();
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

			btScale.Enabled = (bEnable && isAccept);
		}

		void dgvDmDt_DoubleClick(object sender, EventArgs e)
		{
			if (bdsDmDt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmDt.Current).Row;
			txtMa_Dt.Text = drCurrent["Ma_Dt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Dt"];
			lbtTen_Dt.Text = drCurrent["Ten_Dt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ten_Dt"];
		}

		void dgvDmVt_DoubleClick(object sender, EventArgs e)
		{
			if (bdsDmVtSp.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmVtSp.Current).Row;
			txtMa_Vt_Sp.Text = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];
			lbtTen_Vt_Sp.Text = drCurrent["Ten_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ten_Vt"];
		}

		void btScale_Out_Click(object sender, EventArgs e)
		{
			this.ChangeMode(enuEdit.Edit);
		}

		void btScale_In_Click(object sender, EventArgs e)
		{
			this.ChangeMode(enuEdit.New);
		}

		void btConvert_Scale_Click(object sender, EventArgs e)
		{
			if (this.strScale_Name == "CANA")
			{
				this.numWeight_Scale.Value = 0;
				this.strScale_Name = "CANB";
				this.lblScale_Name.Text = "CÂN B";
				this.lblScale_Name.ForeColor = (this.numWeight_Scale.LedOnColor = Color.Yellow);
				HardwareInterfaceScale6080.DataReceive -= new DataEventHandler(HardwareInterfaceScale6080_DataReceive);
				this.InitForm();
			}
			else
			{
				this.numWeight_Scale.Value = 0;
				this.strScale_Name = "CANA";
				this.lblScale_Name.Text = "CÂN A";
				this.lblScale_Name.ForeColor = (this.numWeight_Scale.LedOnColor = Color.Lime);
				HardwareInterfaceScale6080.DataReceive -= new DataEventHandler(HardwareInterfaceScale6080_DataReceive);
				this.InitForm();
			}
		}

		void frmScale_FormClosing(object sender, FormClosingEventArgs e)
		{
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
			}

			btSave_Print.Focus();
		}

		void bdsTruck_In_PositionChanged(object sender, EventArgs e)
		{
			if (bdsTruck_In.Position < 0)
				return;

			if (enuNew_Edit == enuEdit.Edit)
				this.ScaterMemvar_Truck_In();
		}

		void btPrint_Click(object sender, EventArgs e)
		{
			if (this.strStt != string.Empty)
				Voucher.PrintScale_Out(this.strStt, true, true);
		}

		void btPrint_In_Click(object sender, EventArgs e)
		{
			this.Print(this.strStt_Truck_In, "IN", false);
		}

		void btPrint_Out_Click(object sender, EventArgs e)
		{
			this.Print(this.strStt_Truck_Out, "OUT", true);
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (txtLy_Do2.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ly_Do") + " " +
										Languages.GetLanguage("Not_Null"));

				return;
			}

			Hashtable htUpdate = new Hashtable();
			htUpdate.Add("STT", this.strStt_Truck_Out);
			htUpdate.Add("SO_XE", txtSo_Xe2.Text.Trim());
			htUpdate.Add("MA_DT", txtMa_Dt2.Text.Trim());
			htUpdate.Add("MA_VT_SP", txtMa_Vt_Sp2.Text.Trim());
			htUpdate.Add("DIEN_GIAI", txtDien_Giai2.Text);
			htUpdate.Add("LY_DO", txtLy_Do2.Text);
			htUpdate.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
			htUpdate.Add("MA_DVCS", Element.sysMa_DvCs);

			if (SQLExec.Execute("sp_Update_PH_Scale", htUpdate, CommandType.StoredProcedure))
			{
				this.dgvTruck_Out.Enabled = this.txtSo_Ct2.Enabled = this.btEdit_Out.Enabled = true;
				this.btgAccept.Enabled = false;
				this.txtMa_Dt2.Enabled = this.txtMa_Vt_Sp2.Enabled = this.txtDien_Giai2.Enabled = txtLy_Do2.Enabled = false;
				this.btPrint_Out_Click(null, null);
				this.LoadTruck_Out();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.dgvTruck_Out.Enabled = this.txtSo_Ct2.Enabled = this.btEdit_Out.Enabled = true;
			this.btgAccept.Enabled = false;
			this.txtMa_Dt2.Enabled = this.txtMa_Vt_Sp2.Enabled = this.txtDien_Giai2.Enabled = txtLy_Do2.Enabled = false;
		}

		void btEdit_Out_Click(object sender, EventArgs e)
		{
			this.dgvTruck_Out.Enabled = this.txtSo_Ct2.Enabled = this.btEdit_Out.Enabled = false;
			this.btgAccept.Enabled = true;
			this.txtMa_Dt2.Enabled = this.txtMa_Vt_Sp2.Enabled = this.txtDien_Giai2.Enabled = txtLy_Do2.Enabled = true;

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

		void cboSo_Xe_Ct_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboSo_Xe_Ct.SelectedItem != null && cboSo_Xe_Ct.Enabled)
			{
				KeyValuePair<object, object> selectedPair = (KeyValuePair<object, object>)cboSo_Xe_Ct.SelectedItem;
				string strKey = selectedPair.Key.ToString();
				string strValue = selectedPair.Value.ToString();
				this.strStt = strKey;

				this.FillData_Voucher_Edit();
			}
		}

		void txtBarcode_Ct_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (string.IsNullOrEmpty(this.strStt))
				{
					Common.MsgCancel("Bạn phải chọn phiếu để xuất!");
					return;
				}

				this.txtBarcode_Ct.Focus();
				this.txtBarcode_Ct.Select(0, txtBarcode_Ct.Text.Length);
				string strBarcode = txtBarcode_Ct.Text.Trim();
				//Check exists Barcode
				if (!DataTool.SQLCheckExist("R81DMBARCODE", "Barcode", strBarcode))
				{
					Common.MsgCancel("Bạn nhập mã vạch {" + strBarcode + "} không tồn tại!");
					txtBarcode_Ct.BackColor = Color.Red;
					txtBarcode_Ct.Select(0, txtBarcode_Ct.Text.Length);
					txtBarcode_Ct.Focus();
				}
				else
				{
					string strSQLExec =
						@"SELECT T1.*,
									T1.So_Luong - T1.So_Luong_OutPut AS So_Luong_Current,
									T1.Num_Bars - T1.Num_Bars_OutPut AS Num_Bars_Current,
									CASE WHEN T2.Ngay_Sx IS NULL THEN T1.Ngay_Sx ELSE T2.Ngay_Sx END AS Ngay_Sx, CASE WHEN T2.Ca IS NULL THEN T1.Ma_Ca ELSE T2.Ca END AS Ca,
									T3.Ten_Vt, T4.Grade_Name, T5.Standard_Name, T6.Ten_CL
								FROM R81DMBARCODE T1 WITH(NOLOCK)
										LEFT JOIN R81DMCA T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca
										JOIN R81DMVT T3 WITH(NOLOCK) ON T1.Ma_Vt = T3.Ma_Vt
										JOIN R81DMMACTHEP T4 WITH(NOLOCK) ON T1.Grade_ID = T4.Grade_ID
										JOIN R81DMSTANDARD T5 WITH(NOLOCK) ON T1.Standard_ID = T5.Standard_ID
										JOIN R81DMCL T6 WITH(NOLOCK) ON T1.Ma_CL = T6.Ma_CL
								WHERE T1.Barcode = '" + strBarcode + "'";


					DataTable dtBarcode = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
					if (dtBarcode.Rows.Count == 0)
					{
						Common.MsgCancel("Bạn nhập bó thép {" + strBarcode + "} chưa đúng");
					}
					else
					{
						if (!Convert.ToBoolean(dtBarcode.Rows[0]["Is_OutPut"]))
						{
							Common.MsgCancel("Bó thép này chưa được phép xuất kho");
						}
						else
						{
							var vBacode = dtEditCt.Select("Barcode = '" + strBarcode + "'");
							if (vBacode.Length != 0)
							{
								txtBarcode_Ct.BackColor = Color.Red;
								txtBarcode_Ct.Text = string.Empty;
								txtBarcode_Ct.Focus();
							}
							else
							{
								bool bThep_Cay = true;
								this.AddRowBarcode(dtBarcode, ref bThep_Cay);
								this.Calc_So_Luong(bThep_Cay);
								this.txtBarcode_Ct.Focus();
								this.txtBarcode_Ct.Select(0, txtBarcode_Ct.Text.Length);
								this.txtBarcode_Ct.BackColor = SystemColors.Window;
								this.txtBarcode_Ct.Text = string.Empty;

							}
						}
					}
				}
			}
		}

		void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (!rdbSo_Ct_Ct.Checked)
				cboSo_Ct_Ct.SelectedValue = string.Empty;

			if (!rdbSo_Xe_Ct.Checked)
				cboSo_Xe_Ct.SelectedValue = string.Empty;

			cboSo_Ct_Ct.Enabled = rdbSo_Ct_Ct.Checked;
			cboSo_Xe_Ct.Enabled = rdbSo_Xe_Ct.Checked;

			this.cboSo_Ct_Ct_SelectedValueChanged(null, null);
			this.cboSo_Xe_Ct_SelectedValueChanged(null, null);
		}

		void txtBarcode_Ct_LostFocus(object sender, EventArgs e)
		{
			txtBarcode_Ct.BackColor = SystemColors.Window;
			txtBarcode_Ct.Text = string.Empty;

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

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "Ma_Nh_Sp = 'SPCAN'");

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

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();

			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "Ma_Nh_Vt = 'SPCAN'");

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

		void cboSo_Ct_Ct_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboSo_Ct_Ct.SelectedItem != null && cboSo_Ct_Ct.Enabled)
			{
				KeyValuePair<object, object> selectedPair = (KeyValuePair<object, object>)cboSo_Ct_Ct.SelectedItem;
				string strKey = selectedPair.Key.ToString();
				string strValue = selectedPair.Value.ToString();
				this.strStt = strKey;

				this.FillData_Voucher_Edit();
			}
		}

		void btSave_Voucher_Click(object sender, EventArgs e)
		{
			if (dtEditCt == null || dtEditCt.Rows.Count <= 0)
			{
				Common.MsgCancel("Không có dữ liệu chi tiết. Vui lòng quét mã vạch");
				return;
			}

			this.GatherMemvar_Voucher_Edit();

			SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
			SqlCommand sqlCom = sqlCon.CreateCommand();

			sqlCom.CommandText = "sp_Update_Ct";
			sqlCom.CommandType = CommandType.StoredProcedure;

			sqlCom.Parameters.Clear();
			sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)enuNew_Edit_Voucher);
			sqlCom.Parameters.AddWithValue("@Stt", this.strStt);
			sqlCom.Parameters.AddWithValue("@Ma_Ct", strMa_Ct);
			sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);


			//Tạo Table cho TVP_PH
			SqlParameter paraPH = new SqlParameter();
			paraPH.SqlDbType = SqlDbType.Structured;
			paraPH.ParameterName = "@PH";

			//Tạo Table cho TVP_PH
			SqlParameter paraCt = new SqlParameter();
			paraCt.SqlDbType = SqlDbType.Structured;
			paraCt.ParameterName = "@Ct";

			sqlCom.CommandText = "sp_Update_CtX_Barcode";


			//TVP_PH
			paraPH.TypeName = "TVP_PH_SCALE";
			paraPH.Value = Voucher.GetTVPValue("R80PH_SCALE", "TVP_PH_SCALE", dtEditPh_Dest);
			sqlCom.Parameters.Add(paraPH);

			//TVP_CT
			paraCt.TypeName = "TVP_CtX_BARCODE";
			paraCt.Value = Voucher.GetTVPValue("R05CTX_BARCODE", "TVP_CtX_BARCODE", this.dtEditCt);
			sqlCom.Parameters.Add(paraCt);

			try
			{
				sqlCom.ExecuteNonQuery();

				this.strStt_Old = this.strStt;
				//Update to PH
				this.FillData_Voucher();

				this.strStt = this.strStt_Old;

				if (rdbSo_Xe_Ct.Checked)
				{
					if (cboSo_Xe_Ct.SelectedValue != null)
						cboSo_Xe_Ct.SelectedValue = strStt;
				}
				else if (rdbSo_Ct_Ct.Checked)
				{
					if (cboSo_Ct_Ct.SelectedValue != null)
						cboSo_Ct_Ct.SelectedValue = strStt;
				}

				this.FillData_Voucher_Edit();
			}
			catch (Exception ex)
			{
				sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
				sqlCom.CommandType = CommandType.Text;
				sqlCom.Parameters.Clear();
				sqlCom.ExecuteNonQuery();

				MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
			}

			Common.MsgOk("Cập nhật thành công!");
		}

		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "NUM_BARS"))
			{
				if (Convert.ToDouble(drCurrent["Num_Bars"]) != Convert.ToDouble(drCurrent["Num_Bars", DataRowVersion.Original]))
				{
					double dbSo_Luong_Current = drCurrent["So_Luong_Current"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong_Current"]);
					double dbNum_Bars_Current = drCurrent["Num_Bars_Current"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars_Current"]);
					
					if (dbSo_Luong_Current + dbNum_Bars_Current > 0)
					{
						double dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);
						double dbSo_Luong_Avg = 0;
						double dbSo_Luong = 0;

						if (dbNum_Bars_Current != 0)
							dbSo_Luong_Avg = Math.Round(dbSo_Luong_Current / dbNum_Bars_Current, 2);

						dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
						drCurrent["So_Luong"] = dbSo_Luong;

						if (dbNum_Bars_Current != 0)
							this.Calc_So_Luong(true);
						else
							this.Calc_So_Luong(false);
					}
				}
			}

			bdsEditCt.EndEdit();//Cap nhat lai DataSource
		}

		void txtBarcode_Search_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (this.enuNew_Edit == enuEdit.Edit)
				{
					DataRow[] drSelect = dtTruck_In.Select("Stt = '" + txtBarcode_Search.Text.Trim() + "'");
					if (drSelect.Length > 0)
					{
						strStt_Truck_In = (string)drSelect[0]["Stt"];
						txtSo_Ct.Text = (string)drSelect[0]["So_Ct"];
						txtSo_Xe.Text = (string)drSelect[0]["So_Xe"];
						txtMa_Dt.Text = (string)drSelect[0]["Ma_Dt"];
						txtMa_Vt_Sp.Text = (string)drSelect[0]["Ma_Vt_Sp"];
						txtDien_Giai.Text = (string)drSelect[0]["Dien_Giai"];
						txtMa_Dt_CbNv.Text = (string)drSelect[0]["Ma_Dt_CbNv_Vao"];
						numSo_Luong_Vao.Value = Convert.ToDouble(drSelect[0]["So_Luong_Vao"]);
					}
				}
				if (this.txtBarcode_Search.Text != "")
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
						txtMa_Dt.Text = (string)drSelect[0]["Ma_Dt"];
						txtMa_Vt_Sp.Text = (string)drSelect[0]["Ma_Vt_Sp"];
						txtDien_Giai.Text = (string)drSelect[0]["Dien_Giai"];
						txtMa_Dt_CbNv.Text = (string)drSelect[0]["Ma_Dt_CbNv_Vao"];
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

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData_Voucher();
		}

		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{
				case Keys.D1:
					if (e.Modifiers == Keys.Control)
						this.tcControl.SelectedTab = tpScale;
					return;

				case Keys.D2:
					if (e.Modifiers == Keys.Control)
						this.tcControl.SelectedTab = tpVoucher;
					return;

				case Keys.F6:
					if (dtTruck_In.Rows.Count > 0)
						this.ChangeMode(enuEdit.Edit);
					return;

				case Keys.F5:
					this.ChangeMode(enuEdit.New);
					return;
					
				case Keys.F8:
					this.btEdit_Voucher_Click(null, null);
					return;

				case Keys.F9:
					btConvert_Scale_Click(null, null);
					return;

				case Keys.F7:
					if(e.Modifiers == Keys.Shift)
						this.Design();
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
			frmIn_Scale.Load();

			string strFile_Name = "rpt";

			strFile_Name += frmIn_Scale.rdbTruck_In.Checked ? frmIn_Scale.rdbTruck_In.Name.Substring(3, frmIn_Scale.rdbTruck_In.Name.Length - 3)
				: frmIn_Scale.rdbTruck_Out.Checked ? frmIn_Scale.rdbTruck_Out.Name.Substring(3, frmIn_Scale.rdbTruck_Out.Name.Length - 3)
				: frmIn_Scale.rdbScale_Out.Checked ? frmIn_Scale.rdbScale_Out.Name.Substring(3, frmIn_Scale.rdbScale_Out.Name.Length - 3)
				: frmIn_Scale.rdbCo_Tinh.Checked ? frmIn_Scale.rdbCo_Tinh.Name.Substring(3, frmIn_Scale.rdbCo_Tinh.Name.Length - 3)
				: frmIn_Scale.rdbTP_HH.Checked ? frmIn_Scale.rdbTP_HH.Name.Substring(3, frmIn_Scale.rdbTP_HH.Name.Length - 3) : "Truck_In";

			RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strFile_Name);
		}

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
			if (tcControl.SelectedTab == tpVoucher)
			{
				switch (e.KeyCode)
				{
					case Keys.F8:

						if (dgvEditCt.Focused == false)
							return;

						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["Deleted"] = !((bool)drCurrent["Deleted"]);

						if ((bool)drCurrent["Deleted"] == true)
						{
							Font font = new Font(dgvEditCt.Font.FontFamily, dgvEditCt.Font.Size, FontStyle.Strikeout);
							dgvEditCt.CurrentRow.DefaultCellStyle.Font = font;
						}
						else
						{
							dgvEditCt.CurrentRow.DefaultCellStyle.Font = dgvEditCt.Font;
						}
						break;
				}
			}
		}
	}
}
