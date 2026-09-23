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
	public partial class frmScale_Detail : RosySystem.Customize.frmView
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
		string strStt_Org = string.Empty;
        string strStt_LXH = string.Empty;
        string strDien_Giai = "LXH:";
        double dbTSo_Luong_Bo = 0;
        double dbTSo_Luong_Cay_Le = 0;
        double dbSo_Luong_Bo = 0;
        double dbSo_Luong_Cay_Le = 0;
		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;
        string strMa_Dt_Ct = string.Empty;

		#endregion

		public frmScale_Detail()
		{
			InitializeComponent();

			this.btPrint.Click += new EventHandler(btPrint_Click);

			this.txtSo_Xe_Filter.Validated += new EventHandler(txtSo_Xe_Filter_Validated);
			this.cboSo_Xe.SelectedValueChanged += new EventHandler(cboSo_Xe_SelectedValueChanged);

			this.cboSo_Ct.SelectedValueChanged += new EventHandler(cboSo_Ct_SelectedValueChanged);
			this.rdbSo_Xe_Ct.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
			this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
            this.txtStt_LXH.KeyDown += new KeyEventHandler(txtStt_LXH_KeyDown);

			this.btSave_Voucher.Click += new EventHandler(btSave_Voucher_Click);
			this.btCheckInventory.Click += new EventHandler(btCheckInventory_Click);
			this.txtBarcode.LostFocus += new EventHandler(txtBarcode_LostFocus);
			this.dgvEditCt.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.dgvEditCt.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);

			this.btFirst.Click += new EventHandler(btFirst_Click);
			this.btNext.Click += new EventHandler(btNext_Click);
			this.btPrevious.Click += new EventHandler(btPrevious_Click);
			this.btLast.Click += new EventHandler(btLast_Click);

            btUpdate_Can.Click += new EventHandler(btUpdate_Can_Click);
			this.btScale.Click += new EventHandler(btScale_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
            this.numSL_Xe_Hang.Validating += new CancelEventHandler(numSL_Xe_Hang_Validating);

            txtTime_Clock.Tick += TxtTime_Clock_Tick;
		}

        private void TxtTime_Clock_Tick(object sender, EventArgs e)
        {
			Hashtable ht = new Hashtable();
			ht.Add("NGAY_CT", dteNgay_Ct1.Text);
			lblCNXX_List.Text = SQLExec.ExecuteReturnValue("sp_GetListKhoCNXX", ht, CommandType.StoredProcedure).ToString();
        }

        new public void Load(string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;
			this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);
			this.dteNgay_Ct1.Text = this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());

			this.Build();
			this.FillData();
			this.Init_Ct();
			
			this.Show();
		}

		private void Build()
		{
			dgvEditCt.bSortMode = false;
			dgvEditCt.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt.BuildGridView();

			this.DataGridView_Language();

		}

		private void DataGridView_Language()
		{
		
			dgvEditCt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEditCt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvEditCt.Columns.Contains("Ngay_Nhap"))
				dgvEditCt.Columns["Ngay_Nhap"].Frozen = true;

			if (dgvEditCt.Columns.Contains("Ngay_Nhap"))
				dgvEditCt.Columns["Ngay_Nhap"].HeaderText = "Ngày sản xuất";

			if (dgvEditCt.Columns.Contains("So_Luong"))
				dgvEditCt.Columns["So_Luong"].HeaderText = "KL trên xe";

			if (dgvEditCt.Columns.Contains("Num_Bars"))
				dgvEditCt.Columns["Num_Bars"].HeaderText = "Số cây trên xe";

			//ReadOnly
			string strColumn_Name = "BARCODE,SO_LUONG,SO_LUONG_CURRENT,NUM_BARS_CURRENT,SO_LUONG_BARCODE,NUM_BARS_BARCODE,LENGTH,NGAY_NHAP,CA,NUM_LOT,TEN_SIZE,GRADE_NAME,STANDARD_NAME,TEN_CL,IS_OUTPUT,NUM_BARS";
			foreach (var strColumn in strColumn_Name.Split(','))
			{
				if (dgvEditCt.Columns.Contains(strColumn))
					dgvEditCt.Columns[strColumn].ReadOnly = true;
			}
		}

		private void Init_Ct()
		{
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

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CT", this.strMa_Ct);
			htPara.Add("SO_XE_FILTER", this.txtSo_Xe_Filter.Text);
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			//htPara.Add("DUYET", 1);

			dtEditPh = SQLExec.ExecuteReturnDt("sp_GetVoucher_Scale_PH", htPara, CommandType.StoredProcedure);
			bdsEditPh.DataSource = dtEditPh;

			if (dtEditPh.Rows.Count == 0)
			{
				DataRow drNew = dtEditPh.NewRow();
				Common.SetDefaultDataRow(ref drNew);
				dtEditPh.Rows.Add(drNew);
			}

			cboSo_Xe.DataSource = dtEditPh;
			cboSo_Xe.ValueMember = "STT";
			cboSo_Xe.DisplayMember = "SO_XE_SO_CT";

			cboSo_Ct.DataSource = dtEditPh;
			cboSo_Ct.ValueMember = "STT";
			cboSo_Ct.DisplayMember = "SO_CT";

            Ket_Luan();

			this.ExportControl = dgvEditCt;
		}

		private void FillData_Voucher_Ph()
		{
			if (!string.IsNullOrEmpty(strStt))
			{
				DataRow[] arrdrEditPh_Dest = dtEditPh.Select("Stt = '" + strStt + "'");
				if (arrdrEditPh_Dest.Length > 0 && arrdrEditPh_Dest.Length == 1)
				{
					if(this.dtEditPh_Dest != null)
						this.dtEditPh_Dest.Rows.Clear();

					this.dtEditPh_Dest = dtEditPh.Clone();
					
					foreach (DataRow dr in arrdrEditPh_Dest)
						this.dtEditPh_Dest.ImportRow(dr);

					this.bdsEditPh.Position = this.bdsEditPh.Find("STT", strStt);
					this.lbtRecorde.Text = this.bdsEditPh.Position + 1 + "/" + this.bdsEditPh.Count;

					this.ScaterMemvar_Voucher_Edit(this.dtEditPh_Dest.Rows[0]);
					this.FillData_Voucher_Ct();

                    Ket_Luan();
				}
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

			numTSL_Barcode.Value = Common.SumDCValue(dtEditCt, "So_Luong_Can", "Deleted = 0");
			DataView dvEditCt = new DataView(dtEditCt);
			dvEditCt.RowFilter = "Deleted = 0";
            
            numTSo_Barcode_Thanh.Value = dvEditCt.ToTable().Select("Ma_Vt_Sp LIKE 'BD%'").Count();
            numTSo_Barcode_Cuon.Value = dvEditCt.ToTable().Select("Ma_Vt_Sp LIKE 'BR%'").Count();//dvEditCt.ToTable().Rows.Count;
		}

		private void Calc_So_Luong(bool bThep_Cay)
		{
            numTSL_Barcode.Value = Common.SumDCValue(dtEditCt, "So_Luong_Can", "Deleted = 0");

			DataView dvEditCt = new DataView(dtEditCt);
			dvEditCt.RowFilter = "Deleted = 0";
            numTSo_Barcode_Thanh.Value = dvEditCt.ToTable().Select("Ma_Vt_Sp LIKE 'BD%'").Count();
            numTSo_Barcode_Cuon.Value = dvEditCt.ToTable().Select("Ma_Vt_Sp LIKE 'BR%'").Count();

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
            //numSL_QDinh.Value = dbValue1 + (dbValue2 * numTSo_Barcode_Thanh.Value); //cũ
            numSL_QDinh.Value = dbValue1 + (dbValue2 * (numTSo_Barcode_Thanh.Value + numTSo_Barcode_Cuon.Value));
			
            //So luong chenh lech: Dang tinh thep cay.
            if ((string)RosySystem.Library.Parameters.GetParaValue("CAN100TCHUNG") == "1") // từ sau này ko phân biệt CL cây hay cuộn
            {
			    if (bThep_Cay)
				    numSL_CL.Value = numSL_Xe_Hang.Value - numTSL_Barcode.Value;
			    else
				    numSL_CL.Value = numSL_Xe_Hang.Value - (3 * numTSo_Barcode_Cuon.Value) - numTSL_Barcode.Value;//bang sua 4 thanh 3 khi tinh chenh lech
            }
            else
                numSL_CL.Value = numSL_Xe_Hang.Value - (3 * numTSo_Barcode_Cuon.Value) - numTSL_Barcode.Value;

            Ket_Luan();
		}
        
        private void Ket_Luan()
        {
         //Bằng thêm sử lý hiển thị kết luận Đạt hay Không
            if (numSL_CL.Value <= numSL_QDinh.Value)
                txtKet_Luan.Text = "ĐẠT";
            else
                txtKet_Luan.Text = Convert.ToString(numSL_CL.Value - numSL_QDinh.Value);
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

			int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0") + 1);

			drNewRow["Stt"] = strStt;
			drNewRow["Stt0"] = iStt0;
			drNewRow["Ma_Nvu"] = txtMa_Nvu.Text.Trim();
			drNewRow["Ma_Ct"] = this.strMa_Ct;
			drNewRow["So_Ct"] = txtSo_Ct.Text;
			drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;

            drNewRow["Ma_Dt"] = strMa_Dt_Ct;// txtMa_Dt.Text.Trim();
            drNewRow["Dien_Giai_SO"] = txtDien_Giai_SO.Text;
            drNewRow["Dien_Giai"] = strDien_Giai;
            drNewRow["Stt_Org"] = strStt_LXH;

			drNewRow["Barcode"] = drDmBarcode["Barcode"];

            if(drDmBarcode["Barcode"].ToString().StartsWith("L"))
                dbSo_Luong_Cay_Le += Convert.ToDouble(drDmBarcode["Num_Bars_Current"]);
            else
                dbSo_Luong_Bo += 1;

			drNewRow["Ma_Vt_Sp"] = drDmBarcode["Ma_Vt_Sp"];


            drNewRow["Create_Log"] = Common.GetCurrent_Log();

			drNewRow["Ma_Size"] = drDmBarcode["Ma_Size"];
			drNewRow["Ten_Size"] = drDmBarcode["Ten_Size"];
			drNewRow["So_Luong"] = drDmBarcode["So_Luong_Current"];
			drNewRow["Num_Bars"] = drDmBarcode["Num_Bars_Current"];

			drNewRow["So_Luong_Current"] = drDmBarcode["So_Luong_Current"];
			drNewRow["Num_Bars_Current"] = drDmBarcode["Num_Bars_Current"];

			drNewRow["So_Luong_Barcode"] = drDmBarcode["So_Luong"];
			drNewRow["Num_Bars_Barcode"] = drDmBarcode["Num_Bars"];
            drNewRow["So_Luong_Can"] = drDmBarcode["So_Luong_Can"];
			
			drNewRow["Length"] = drDmBarcode["Length"];
			drNewRow["Ma_Ca"] = drDmBarcode["Ma_Ca"];
			drNewRow["Ngay_Nhap"] = drDmBarcode["Ngay_Nhap"];
			drNewRow["Ca"] = drDmBarcode["Ca"];
			drNewRow["Grade_ID"] = drDmBarcode["Grade_ID"];
			drNewRow["Grade_Name"] = drDmBarcode["Grade_Name"];
			drNewRow["Standard_ID"] = drDmBarcode["Standard_ID"];
			drNewRow["Standard_Name"] = drDmBarcode["Standard_Name"];
			drNewRow["Ma_CL"] = drDmBarcode["Ma_CL"];
			drNewRow["Ten_CL"] = drDmBarcode["Ten_CL"];
			drNewRow["Num_Lot"] = drDmBarcode["Num_Lot"];
			drNewRow["Is_OutPut"] = drDmBarcode["Is_OutPut"];
			drNewRow["Deleted"] = false;

			if (Convert.ToDouble(drDmBarcode["Num_Bars"]) != 0)
				bThep_Cay = true;
			else
				bThep_Cay = false;

			dtEditCt.Rows.Add(drNewRow);
			dtEditCt.AcceptChanges();

           
		}

		private void Reset_Voucher_Edit()
		{
			dteNgay_Ct.Text = string.Empty;
			txtInfoInherit.Text = txtSo_Ct.Text = txtMa_Dt.Text = lbtTen_Dt_Ct.Text = txtOng_Ba.Text = txtDia_Chi.Text = txtMa_Vt_Sp.Text = lbtTen_Vt_Sp_Ct.Text = txtDien_Giai.Text = txtLy_Do.Text = txtSo_Xe.Text = txtSo_Xa_Lan_Tau.Text = txtTime_In.Text = txtTime_Out.Text = string.Empty;
			numSo_Luong_Vao.Value = numSo_Luong_Ra.Value = numSo_Luong.Value = 0;

			if (dtEditCt != null)
				dtEditCt.Rows.Clear();
		}

		private void ScaterMemvar_Voucher_Edit(DataRow drEditPh_Dest)
		{
			dteNgay_Ct.Text = Library.DateToStr(Convert.ToDateTime(drEditPh_Dest["Ngay_Ct"]));
			txtSo_Ct.Text = (string)drEditPh_Dest["So_Ct"];
			txtMa_Dt.Text = (string)drEditPh_Dest["Ma_Dt"];
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text.Trim());
				lbtTen_Dt_Ct.Text = (string)drDmDt["Ten_Dt"];
				txtOng_Ba.Text = drDmDt["Ong_Ba"].ToString() == string.Empty ? lbtTen_Dt_Ct.Text : drDmDt["Ong_Ba"].ToString();
				txtDia_Chi.Text = drDmDt["Dia_Chi"].ToString();
			}
			else
			{
				lbtTen_Dt_Ct.Text = txtOng_Ba.Text = txtDia_Chi.Text = string.Empty;
			}

			txtMa_Vt_Sp.Text = (string)drEditPh_Dest["Ma_Vt_Sp"];
			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
				lbtTen_Vt_Sp_Ct.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			else
				lbtTen_Vt_Sp_Ct.Text = string.Empty;


			txtDien_Giai.Text = (string)drEditPh_Dest["Dien_Giai"];
			txtLy_Do.Text = (string)drEditPh_Dest["Ly_Do"];
			txtSo_Xe.Text = (string)drEditPh_Dest["So_Xe"];
			txtSo_Xa_Lan_Tau.Text = (string)drEditPh_Dest["So_Xa_Lan_Tau"];
			numSo_Luong_Vao.Value = drEditPh_Dest["So_Luong_Vao"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["So_Luong_Vao"]);
			numSo_Luong_Ra.Value = drEditPh_Dest["So_Luong_Ra"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["So_Luong_Ra"]);
			numSo_Luong.Value = drEditPh_Dest["So_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["So_Luong"]);
			txtTime_In.Text = drEditPh_Dest["Time_In"] == DBNull.Value ? "00:00" : Convert.ToDateTime(drEditPh_Dest["Time_In"].ToString()).ToShortTimeString();
			txtTime_Out.Text = drEditPh_Dest["Time_Out"] == DBNull.Value ? "00:00" : Convert.ToDateTime(drEditPh_Dest["Time_Out"].ToString()).ToShortTimeString();
            numSL_Xe_Hang.Value = drEditPh_Dest["SL_Xe_Hang"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["SL_Xe_Hang"]);
            //double dbSl_Xe_Hang = drEditPh_Dest["SL_Xe_Hang"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["SL_Xe_Hang"]);
            //if (dbSl_Xe_Hang <= 0)
            //    numSL_Xe_Hang.Value = numSo_Luong.Value;
            //else
            //    numSL_Xe_Hang.Value = dbSl_Xe_Hang;

			numTSL_Barcode.Value = drEditPh_Dest["TSL_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["TSL_Barcode"]);
			numTSo_Barcode_Thanh.Value = drEditPh_Dest["TSo_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["TSo_Barcode"]);
			numSL_QDinh.Value = drEditPh_Dest["SL_QDinh"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["SL_QDinh"]);
			numSL_CL.Value = drEditPh_Dest["SL_CL"] == DBNull.Value ? 0 : Convert.ToDouble(drEditPh_Dest["SL_CL"]);
			txtGhi_Chu_QDinh.Text = drEditPh_Dest["Ghi_Chu_QDinh"] == DBNull.Value ? string.Empty : (string)drEditPh_Dest["Ghi_Chu_QDinh"];

			this.strStt_Org = (string)drEditPh_Dest["Stt_Org"];
			this.txtMa_Vt_Org.Text = (string)drEditPh_Dest["Ma_Vt_Org"];

			this.txtInfoInherit.Text = GetInfoInherit(this.strStt_Org);
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

		private void GatherMemvar_Voucher_Edit()
		{
			dtEditPh_Dest.Rows[0]["SL_Xe_Hang"] = numSL_Xe_Hang.Value;
			dtEditPh_Dest.Rows[0]["TSL_Barcode"] = numTSL_Barcode.Value;
			dtEditPh_Dest.Rows[0]["TSo_Barcode"] = numTSo_Barcode_Thanh.Value;
			dtEditPh_Dest.Rows[0]["SL_QDinh"] = numSL_QDinh.Value;
			dtEditPh_Dest.Rows[0]["SL_CL"] = numSL_CL.Value;
			dtEditPh_Dest.Rows[0]["Ghi_Chu_QDinh"] = txtGhi_Chu_QDinh.Text;

			dtEditPh_Dest.AcceptChanges();
		}

		private void Save()
		{
			if (dtEditCt == null || dtEditCt.Rows.Count <= 0)
			{
				Common.MsgCancel("Không có dữ liệu chi tiết. Vui lòng quét mã vạch");
				return;
			}

			//Kiểm tra xem barcode có được chuyển sang kho lẻ bó nào không.Tránh trường hợp bị sai khi ngồi đợi lâu quá.
			string strListBarcode = string.Empty;
			if (!this.CheckBarcodeKhoLe(ref strListBarcode))
			{
				Common.MsgCancel("Mã vạch vừa chuyển sang kho lẻ: {" + strListBarcode + "}.Nằm trong danh sách này.");
				return;
			}
            //Bằng ktra kl qua cân trong phạm vi cho phép
            if (Parameters.GetParaValue("ON_OFF_CL_CAN").ToString() == "1" && txtMa_Vt_Sp.Text == "CP")
            {
                double dbChenh_Can = Convert.ToDouble(Parameters.GetParaValue("TY_LE_CHENH_CAN"));
                double dbTy_Le = ((numSL_CL.Value - numSL_QDinh.Value)/numSL_Xe_Hang.Value)*100;
                if(dbTy_Le > dbChenh_Can)
                {
                    if (Common.MsgYes_No("Tỷ lệ chênh lệch " + (numSL_CL.Value - numSL_QDinh.Value).ToString() + " so với cân " + numSL_Xe_Hang.Value.ToString() + " lớn hơn chênh lệch quy định " + dbChenh_Can.ToString() + ". Bạn có được lãnh đạo đồng ý lưu không", "Y"))
                    {
                        frmCanhBaoCan frm = new frmCanhBaoCan();
                        frm.Load(dtEditPh.Rows[0]);
                        if (!frm.isAccept)
                            return;
                    }
                    else
                        return;
                }
            }

			this.GatherMemvar_Voucher_Edit();
            //this.Update_Num_Bars();

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
				this.FillData();

				this.strStt = this.strStt_Old;

				if (rdbSo_Xe_Ct.Checked)
				{
					if (cboSo_Xe.SelectedValue != null)
						cboSo_Xe.SelectedValue = strStt;
				}
				else if (rdbSo_Ct_Ct.Checked)
				{
					if (cboSo_Ct.SelectedValue != null)
						cboSo_Ct.SelectedValue = strStt;
				}

				this.FillData_Voucher_Ph();
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

		private bool CheckBarcodeKhoLe(ref string strListBarcode)
		{
			bool bValid = true;
			foreach (DataRow drEdit in dtEditCt.Select("Barcode Not Like 'L%'"))
			{
				if (DataTool.SQLCheckExist("R81DMBARCODE", "Barcode_Org", drEdit["Barcode"]))
				{
					strListBarcode = strListBarcode == string.Empty ? drEdit["Barcode"].ToString() : strListBarcode + "," + drEdit["Barcode"].ToString();
					bValid = false;
				}
			}

			return bValid;
		}

		private void Update_Num_Bars()
		{
			foreach (DataRow drEdit in dtEditCt.Select("Num_Bars <> 0 AND Deleted = 0"))
			{
				double dbSo_Luong_Barcode = drEdit["So_Luong_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drEdit["So_Luong_Barcode"]);
				double dbNum_Bars_Barcode = drEdit["Num_Bars_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drEdit["Num_Bars_Barcode"]);
				double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(drEdit["Stt"].ToString(), drEdit["Barcode"].ToString());
				double dbNum_Bars_New = 0;
				double dbSo_Luong_CL = 0;
				double dbSo_Luong_Avg = 0;
				double dbSo_Luong = 0;

				if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
				{
					dbNum_Bars_New = drEdit["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drEdit["Num_Bars"]);

					if (dbNum_Bars_Barcode != 0)
						dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

					dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
					dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

					if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
						dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

					drEdit["So_Luong"] = dbSo_Luong;
				}
			}
		}

		private double GetTSo_Luong_OutPut(string strStt, string strBarcode)
		{
			string strSQLExec = @"
				SELECT CASE WHEN ISNULL(SUM(T2.So_Luong_TL), 0) <> 0 THEN ISNULL(SUM(T2.So_Luong_TL), 0) - ISNULL(SUM(T1.So_Luong), 0) ELSE ISNULL(SUM(T1.So_Luong), 0) END
					FROM R05CTX_BARCODE T1 WITH(NOLOCK) LEFT JOIN
							(SELECT T1a.Barcode, SUM(T1a.So_Luong) AS So_Luong_TL
									FROM R05CTN_BARCODE T1a WITH(NOLOCK) JOIN R81DMBARCODE T2a WITH(NOLOCK) ON T1a.Barcode = T2a.Barcode
									WHERE T1a.Barcode = '" + strBarcode + "' AND T2a.Is_OutPut = 1" + @"
									GROUP BY T1a.Barcode) T2 ON T1.Barcode = T2.Barcode" + @"
					WHERE T1.Stt <> '" + strStt + "' AND T1.Barcode = '" + strBarcode + "'";

			return Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQLExec));
		}

		private void Print(string strStt, string strTruck_In_Out, bool bPreview)
		{
			Voucher.PrintTruck_In_Out(strStt, strTruck_In_Out, strTruck_In_Out == "IN" ? "rptTruck_In" : "rptTruck_Out", bPreview, Variables.strPrint_Barcode);
		}

		private void Design()
		{
			frmChon_In_Scale frmIn_Scale = new frmChon_In_Scale();
			frmIn_Scale.Load(strStt);

			string strFile_Name = "rpt";

			strFile_Name += frmIn_Scale.rdbTruck_In.Checked ? frmIn_Scale.rdbTruck_In.Name.Substring(3, frmIn_Scale.rdbTruck_In.Name.Length - 3)
				: frmIn_Scale.rdbTruck_Out.Checked ? frmIn_Scale.rdbTruck_Out.Name.Substring(3, frmIn_Scale.rdbTruck_Out.Name.Length - 3)
				: frmIn_Scale.rdbScale_Out.Checked ? frmIn_Scale.rdbScale_Out.Name.Substring(3, frmIn_Scale.rdbScale_Out.Name.Length - 3)
                //: frmIn_Scale.rdbCo_Tinh.Checked ? frmIn_Scale.rdbCo_Tinh.Name.Substring(3, frmIn_Scale.rdbCo_Tinh.Name.Length - 3)
                //: frmIn_Scale.rdbGCN.Checked ? frmIn_Scale.rdbGCN.Name.Substring(3, frmIn_Scale.rdbGCN.Name.Length - 3)
                : frmIn_Scale.rdbKCS.Checked ? "KCS"
                 : frmIn_Scale.rdbCNXX.Checked ? "CT_CNXX"
                //: frmIn_Scale.rdbTP_HH.Checked ? frmIn_Scale.rdbTP_HH.Name.Substring(3, frmIn_Scale.rdbTP_HH.Name.Length - 3) 
                : "Truck_In";

			RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strFile_Name);
		}

		#region Event
		
		void btPrint_Click(object sender, EventArgs e)
		{
			txtTime_Clock.Enabled = false;

			if (this.strStt != string.Empty)
            {
                if(Library.StrToDate(dteNgay_Ct.Text) >=  Library.StrToDate("01/10/2023"))
                    Voucher.PrintScale_Out_ThanhCuon(this.strStt, true, true, "R80PH_SCALE");
                else
                    Voucher.PrintScale_Out(this.strStt, true, true, "R80PH_SCALE");
            }

			txtTime_Clock.Enabled = true;
		}

		void cboSo_Xe_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboSo_Xe.SelectedValue != null)
			{
				if (cboSo_Xe.SelectedValue.ToString() != "System.Data.DataRowView" && cboSo_Xe.Enabled)
				{
					this.strStt = cboSo_Xe.SelectedValue == null ? string.Empty : cboSo_Xe.SelectedValue.ToString();

					this.FillData_Voucher_Ph();
				}
			}
		}

		void cboSo_Ct_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboSo_Ct.SelectedValue != null)
			{
				if (cboSo_Ct.SelectedValue.ToString() != "System.Data.DataRowView" && cboSo_Ct.Enabled)
				{
					this.strStt = cboSo_Ct.SelectedValue == null ? string.Empty : cboSo_Ct.SelectedValue.ToString();
					this.FillData_Voucher_Ph();
				}
			}
		}
        void txtStt_LXH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (string.IsNullOrEmpty(this.strStt))
                {
                    Common.MsgCancel("Bạn phải chọn phiếu để xuất!");
                    return;
                }
                this.txtStt_LXH.Focus();
                this.txtStt_LXH.Select(0, txtStt_LXH.Text.Length);
                strStt_LXH = txtStt_LXH.Text.Trim();

                if (strStt_LXH.StartsWith("]C1"))
                    strStt_LXH = strStt_LXH.Substring(3, strStt_LXH.Length - 3);

                txtStt_LXH.Text = strStt_LXH;

                //Check exists Barcode
                if (!DataTool.SQLCheckExist("R04CTSO", new string[] { "Ma_Ct", "Stt" }, new object[] { "LXH", strStt_LXH.Trim()}))
                {
                    Common.MsgCancel("Chứng từ không tồn tại trong lệnh xuất hàng {" + txtStt_LXH + "} !");
                    txtStt_LXH.BackColor = Color.Red;
                    txtStt_LXH.Select(0, txtStt_LXH.Text.Length);
                    txtStt_LXH.Focus();
                }
              
                else
                {
                    string strQuery = @"
					SELECT T1.Ma_Vt, T1.So_Ct, T1.Ma_Dt, SUM(So_Luong_Bo) AS So_Luong_Bo, SUM(CASE WHEN Is_KhoLe = 0 THEN So_Luong_Cay_Le ELSE 0 END) AS So_Luong_Cay_Le, " +
						" MAX(Dien_Giai) AS Dien_Giai_SO FROM R04CTSO T1 " +
						" WHERE Stt = '" + strStt_LXH + "' GROUP BY Ma_Vt, So_Ct, Ma_Dt";


                    DataTable dtInheritVoucher = SQLExec.ExecuteReturnDt(strQuery);
                    if (dtInheritVoucher.Rows.Count > 0)
                    {
                        string strMa_Vt_Org = string.Empty;
                        foreach (DataRow drInherit in dtInheritVoucher.Rows)
                            strMa_Vt_Org = strMa_Vt_Org + drInherit["Ma_Vt"].ToString() + ",";

                        if (strMa_Vt_Org.EndsWith(","))
                            txtMa_Vt_Org.Text = strMa_Vt_Org.Substring(0, strMa_Vt_Org.Length - 1);

                        if (strMa_Vt_Org != "")
                            txtMa_Vt_Org.Text = strMa_Vt_Org;

                        lblStt_LXH.Text = "Anh (chị) đang quét mã vạch cho LXH: " + dtInheritVoucher.Rows[0]["So_Ct"];
                        strDien_Giai = "LXH:" + dtInheritVoucher.Rows[0]["So_Ct"];
                        txtDien_Giai_SO.Text = dtInheritVoucher.Rows[0]["Dien_Giai_SO"].ToString();
                        dbTSo_Luong_Bo = Common.SumDCValue(dtInheritVoucher, "So_Luong_Bo", "");
                        dbTSo_Luong_Cay_Le = Common.SumDCValue(dtInheritVoucher, "So_Luong_Cay_Le", ""); 
                        dbSo_Luong_Bo = 0;
                        dbSo_Luong_Cay_Le = 0;

                        strMa_Dt_Ct = dtInheritVoucher.Rows[0]["Ma_Dt"].ToString();

                        //if (txtMa_Dt.Text.Trim() != dtInheritVoucher.Rows[0]["Ma_Dt"].ToString())
                        //{
                        //    strMa_Dt_Ct = dtInheritVoucher.Rows[0]["Ma_Dt"].ToString();
                        //    //txtMa_Dt.Text = dtInheritVoucher.Rows[0]["Ma_Dt"].ToString();
                        //    //DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text.Trim());
                        //    //lbtTen_Dt_Ct.Text = (string)drDmDt["Ten_Dt"];
                        //    //txtOng_Ba.Text = drDmDt["Ong_Ba"].ToString() == string.Empty ? lbtTen_Dt_Ct.Text : drDmDt["Ong_Ba"].ToString();
                        //    //txtDia_Chi.Text = drDmDt["Dia_Chi"].ToString();
                        //}

                        txtBarcode.Focus();
                    }                 
                }

            }
        }

		void txtBarcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (string.IsNullOrEmpty(this.strStt))
				{
					Common.MsgCancel("Bạn phải chọn phiếu để xuất!");
					return;
				}

				this.txtBarcode.Focus();
				this.txtBarcode.Select(0, txtBarcode.Text.Length);
				string strBarcode = txtBarcode.Text.Trim();

				if (strBarcode.StartsWith("]C1"))
					strBarcode = strBarcode.Substring(3, strBarcode.Length - 3);

				txtBarcode.Text = strBarcode;

				//Check exists Barcode
				if (!DataTool.SQLCheckExist("R81DMBARCODE", "Barcode", strBarcode))
				{
					Common.MsgCancel("Bạn nhập mã vạch {" + strBarcode + "} không tồn tại!");
					txtBarcode.BackColor = Color.Red;
					txtBarcode.Select(0, txtBarcode.Text.Length);
					txtBarcode.Focus();
				}
				else
				{
                    Hashtable ht = new Hashtable();
                    ht.Add("BARCODE", strBarcode);
                    ht.Add("STT", strStt);

                    DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarcodePXTH", ht, CommandType.StoredProcedure);

					if (dtBarcode.Rows.Count == 0)
					{
						Common.MsgCancel("Bó thép {" + strBarcode + "} đã được xuất hết rồi.");
					}
					else
					{
						string strMa_Vt_Sp = dtBarcode.Rows[0]["Ma_Vt_Sp"].ToString();
                        string strMa_Vt_Org = txtMa_Vt_Org.Text;//SQLExec.ExecuteReturnValue("SELECT Ma_Vt_Org FROM R80PH_SCALE WITH(NOLOCK) WHERE Stt = '" + this.strStt + "'").ToString();

						//Kiem tra bo thep xuat co nam trong LXH khong
						if (!Common.Inlist(strMa_Vt_Sp, strMa_Vt_Org))
						{
							Common.MsgCancel("Bó thép này không nằm trong danh sách xuất của LXH");
							return;
						}
						
						if (!Convert.ToBoolean(dtBarcode.Rows[0]["Is_OutPut"]))
						{
							Common.MsgCancel("Bó thép này chưa được phép xuất kho");
							return;
						}
						if ((string)dtBarcode.Rows[0]["Try_ID"] == string.Empty)
						{
							Common.MsgCancel("Bó thép này chưa cập nhật cơ tính");
							return;
						}
						else
						{
							var vBacode = dtEditCt.Select("Deleted = 0 AND Barcode = '" + strBarcode + "'");
							if (vBacode.Length != 0)
							{
								txtBarcode.BackColor = Color.Red;
								txtBarcode.Text = string.Empty;
								txtBarcode.Focus();
							}
							else
							{
								bool bThep_Cay = true;
								this.AddRowBarcode(dtBarcode, ref bThep_Cay);
                                
								this.Calc_So_Luong(bThep_Cay);
								this.txtBarcode.Focus();
								this.txtBarcode.Select(0, txtBarcode.Text.Length);
								this.txtBarcode.BackColor = SystemColors.Window;
								this.txtBarcode.Text = string.Empty;

                                

                                if (dbTSo_Luong_Bo == dbSo_Luong_Bo && dbTSo_Luong_Cay_Le == dbSo_Luong_Cay_Le)
                                {
                                    Common.MsgOk("Bạn đã quét đủ bó cho " + strDien_Giai);
                                    txtStt_LXH.Focus();
                                }
							}
						}
					}
				}
			}
		}

		void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			cboSo_Ct.Enabled = rdbSo_Ct_Ct.Checked;
			cboSo_Xe.Enabled = rdbSo_Xe_Ct.Checked;

			this.cboSo_Ct_SelectedValueChanged(null, null);
			this.cboSo_Xe_SelectedValueChanged(null, null);
		}

		void txtBarcode_LostFocus(object sender, EventArgs e)
		{
			txtBarcode.BackColor = SystemColors.Window;
			txtBarcode.Text = string.Empty;

		}

		void btSave_Voucher_Click(object sender, EventArgs e)
		{
			txtTime_Clock.Enabled = false;
			this.Save();

			this.txtBarcode.Text = string.Empty;
			this.btEdit.Text = "Sửa";
			this.btSave_Voucher.Enabled = false;
			this.btCheckInventory.Enabled = false;
			this.txtBarcode.Enabled = false;
			this.txtBarcode.ReadOnly = true;

			txtTime_Clock.Enabled = true;
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
				if (Convert.ToDouble(drCurrent["Num_Bars"]) != 0 && !(bool)drCurrent["Deleted"])
				{
					if (Convert.ToDouble(drCurrent["Num_Bars"]) <= Convert.ToDouble(drCurrent["Num_Bars_Current"]))
					{
						double dbSo_Luong_Barcode = drCurrent["So_Luong_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong_Barcode"]);
						double dbNum_Bars_Barcode = drCurrent["Num_Bars_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars_Barcode"]);
						double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(drCurrent["Stt"].ToString(), drCurrent["Barcode"].ToString());
						double dbSo_Luong_CL = 0;
						double dbSo_Luong_Avg = 0;
						double dbSo_Luong = 0;
						double dbNum_Bars_New = 0;

						if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
						{
							dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);
							
							if (dbNum_Bars_Barcode != 0)
								dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 2);

                            dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0, MidpointRounding.AwayFromZero);
							dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

							if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
								dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

							drCurrent["So_Luong"] = dbSo_Luong;

							if (dbNum_Bars_Barcode != 0)
								this.Calc_So_Luong(true);
							else
								this.Calc_So_Luong(false);
						}
					}
					else
						drCurrent.RejectChanges();
				}
			}
			
			bdsEditCt.EndEdit();//Cap nhat lai DataSource
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btPrevious_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			this.bdsEditPh.MovePrevious();
			this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

			if (cboSo_Xe.SelectedValue != null)
				this.cboSo_Xe.SelectedValue = this.strStt;
		}

		void btLast_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			this.bdsEditPh.MoveLast();
			this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

			if (cboSo_Xe.SelectedValue != null)
				this.cboSo_Xe.SelectedValue = this.strStt;
		}

		void btNext_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			if (this.bdsEditPh.Position + 1 < this.bdsEditPh.Count)
			{
				this.bdsEditPh.MoveNext();
				this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

				if (cboSo_Xe.SelectedValue != null)
					this.cboSo_Xe.SelectedValue = this.strStt;
			}
		}

		void btFirst_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			this.bdsEditPh.MoveFirst();

			this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

			if (cboSo_Xe.SelectedValue != null)
				this.cboSo_Xe.SelectedValue = this.strStt;
		}

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:

					if (dgvEditCt.Focused == false)
						return;

					if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
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
        void btUpdate_Can_Click(object sender, EventArgs e)
        {
            //Bằng thêm
            numSL_Xe_Hang.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT So_Luong_HH FROM R80PH_SCALE WHERE Stt = '" + strStt + "'"));

            if (dtEditCt != null)
            {
                if (dtEditCt.Rows.Count > 0)
                {
                    double dbNum_Bars = dtEditCt.Rows[0]["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(dtEditCt.Rows[0]["Num_Bars"]);
                    if (dbNum_Bars > 0)
                        this.Calc_So_Luong(true);
                    else
                        this.Calc_So_Luong(false);
                }
            }

        }
		void btScale_Click(object sender, EventArgs e)
		{
			Common.RunMethod("CT_PXTH");
		}

		void btCheckInventory_Click(object sender, EventArgs e)
		{
            frmCheckInventory_Barcode frmCheckInventory = new frmCheckInventory_Barcode();
			frmCheckInventory.Load(this.strStt, this.strStt_Org);

			if (frmCheckInventory.is_Accept)
			{
				if (frmCheckInventory.dtInventory_Barcode_Detail.Select("Chon = true").Length == 0)
					return;

				string strSQLExec = string.Empty;

				foreach (DataRow drCheckInventory in frmCheckInventory.dtInventory_Barcode_Detail.Select("Chon = true"))
				{
					var vBacode = dtEditCt.Select("Deleted = 0 AND Barcode = '" + drCheckInventory["Barcode"].ToString() + "'");
					if (vBacode.Length != 0)
						continue;

					strSQLExec =
							@"SELECT T1.*,
									CASE WHEN T3.Ngay_Sx IS NULL THEN T1.Ngay_Nhap ELSE T3.Ngay_Sx END AS Ngay_Nhap, CASE WHEN T3.Ca IS NULL THEN T1.Ma_Ca ELSE T3.Ca END AS Ca,
									T4.Ten_Size, T5.Grade_Name, T6.Standard_Name, T7.Ten_CL
								FROM R81DMBARCODE T1 WITH(NOLOCK)
										LEFT JOIN R81DMCA T3 WITH(NOLOCK) ON T1.Ma_Ca = T3.Ma_Ca
										LEFT JOIN R81DMSIZE T4 WITH(NOLOCK) ON T1.Ma_Size = T4.Ma_Size
										LEFT JOIN R81DMMACTHEP T5 WITH(NOLOCK) ON T1.Grade_ID = T5.Grade_ID
										LEFT JOIN R81DMSTANDARD T6 WITH(NOLOCK) ON T1.Standard_ID = T6.Standard_ID
										LEFT JOIN R81DMCL T7 WITH(NOLOCK) ON T1.Ma_CL = T7.Ma_CL
								WHERE T1.Barcode = '" + drCheckInventory["Barcode"].ToString() + "'";

					DataTable dtBarcode_Inventory = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
					DataRow drDmBarcode = dtBarcode_Inventory.Rows[0];
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

					bool bThep_Cay = true;
					int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0") + 1);

					drNewRow["Stt"] = strStt;
					drNewRow["Stt0"] = iStt0;
					drNewRow["Ma_Nvu"] = txtMa_Nvu.Text.Trim();
					drNewRow["Ma_Ct"] = this.strMa_Ct;
					drNewRow["So_Ct"] = txtSo_Ct.Text;
					drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;
					drNewRow["Ma_Dt"] = txtMa_Dt.Text.Trim();
					drNewRow["Dien_Giai"] = txtDien_Giai.Text;
					drNewRow["Barcode"] = drDmBarcode["Barcode"];
					drNewRow["Ma_Vt_Sp"] = drDmBarcode["Ma_Vt_Sp"];

					drNewRow["Ma_Size"] = drDmBarcode["Ma_Size"];
					drNewRow["Ten_Size"] = drDmBarcode["Ten_Size"];
					drNewRow["So_Luong"] = drCheckInventory["Khoi_Luong"];
					drNewRow["Num_Bars"] = drCheckInventory["Num_Bars"];

					drNewRow["So_Luong_Current"] = drCheckInventory["Ton_Cuoi_Khoi_Luong"];
					drNewRow["Num_Bars_Current"] = drCheckInventory["Ton_Cuoi_Num_Bars"];

					drNewRow["So_Luong_Barcode"] = drCheckInventory["Ton_Cuoi_Khoi_Luong"];
					drNewRow["Num_Bars_Barcode"] = drCheckInventory["Ton_Cuoi_Num_Bars"];

					drNewRow["Length"] = drDmBarcode["Length"];

					drNewRow["Ma_Ca"] = drDmBarcode["Ma_Ca"];
					drNewRow["Ngay_Nhap"] = drDmBarcode["Ngay_Nhap"];
					drNewRow["Ca"] = drDmBarcode["Ca"];

					drNewRow["Grade_ID"] = drDmBarcode["Grade_ID"];
					drNewRow["Grade_Name"] = drDmBarcode["Grade_Name"];
					drNewRow["Standard_ID"] = drDmBarcode["Standard_ID"];
					drNewRow["Standard_Name"] = drDmBarcode["Standard_Name"];
					drNewRow["Ma_CL"] = drDmBarcode["Ma_CL"];
					drNewRow["Ten_CL"] = drDmBarcode["Ten_CL"];
					drNewRow["Num_Lot"] = drDmBarcode["Num_Lot"];
					drNewRow["Is_OutPut"] = drDmBarcode["Is_OutPut"];
					drNewRow["Deleted"] = false;

					drNewRow["Stt_Org"] = this.strStt_Org;
					drNewRow["Ma_Vt_Org"] = drDmBarcode["Ma_Vt_Sp"];

					if (Convert.ToDouble(drDmBarcode["Num_Bars"]) != 0)
						bThep_Cay = true;
					else
						bThep_Cay = false;

					dtEditCt.Rows.Add(drNewRow);
					dtEditCt.AcceptChanges();

					this.Calc_So_Luong(bThep_Cay);
				}
			}
		}
        
		void numSL_Xe_Hang_Validating(object sender, CancelEventArgs e)
		{
			if (dtEditCt != null)
			{
				if (dtEditCt.Rows.Count > 0)
				{
					double dbNum_Bars = dtEditCt.Rows[0]["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(dtEditCt.Rows[0]["Num_Bars"]);
					if (dbNum_Bars > 0)
						this.Calc_So_Luong(true);
					else
						this.Calc_So_Luong(false);
				}
			}
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			if (btEdit.Text == "Hủy")
			{
				this.btEdit.Text = "Sửa";

				this.txtBarcode.Text = string.Empty;
				this.btSave_Voucher.Enabled = false;
				this.btCheckInventory.Enabled = false;
				this.txtBarcode.Enabled = false;
				this.txtBarcode.ReadOnly = true;

                this.txtStt_LXH.Enabled = false;
                this.txtStt_LXH.ReadOnly = true;
			}
			else
			{
				//Kiểm tra xem phiếu này được in phiếu xuất chưa.Nếu in rồi không cho phép sửa.
				//var vCount = from p in dtEditPh.AsEnumerable()
				//             where p.Field<string>("Stt") == this.strStt
				//             select new { Printed_OutPut = p.Field<int>("Printed_OutPut") };


                txtDien_Giai_SO.Text = "";
				if (Convert.ToInt32(SQLExec.ExecuteReturnValue("sp_CheckCtNX_Inherited_Barcode", new string[] { "Stt" }, new object[] { this.strStt }, CommandType.StoredProcedure)) > 0)
				{
					this.txtBarcode.Text = string.Empty;
					this.btSave_Voucher.Enabled = false;
					this.btCheckInventory.Enabled = false;
					this.txtBarcode.Enabled = false;
					this.txtBarcode.ReadOnly = true;

                    this.txtStt_LXH.Enabled = false;
                    this.txtStt_LXH.ReadOnly = true;
				}
				else
				{
                    //Bằng thêm
                    numSL_Xe_Hang.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT So_Luong_HH FROM R80PH_SCALE WHERE Stt = '" + strStt + "'"));

					this.btEdit.Text = "Hủy";
					this.btSave_Voucher.Enabled = true;

					this.btCheckInventory.Enabled = true;
					
                    this.txtBarcode.Enabled = true;
					this.txtBarcode.ReadOnly = false;

                    this.txtStt_LXH.Enabled = true;
                    this.txtStt_LXH.ReadOnly = false;

                    this.txtStt_LXH.Focus();
				}
			}
		}

		void txtSo_Xe_Filter_Validated(object sender, EventArgs e)
		{
			this.FillData();
		}

		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{
				case Keys.F7:
					if(e.Modifiers == Keys.Shift)
						this.Design();
					return;

				case Keys.F9:
					this.btRefresh_Click(null, null);
					return;

				case Keys.F12:
					if (e.Modifiers == Keys.Control)
						base.OnKeyDown(e);
					else
						this.btScale.PerformClick();
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

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
				if (!Common.CheckPermission("ACCESS_FILTER_DT_TCB", enuPermission_Type.Allow_Access))
					dteNgay_Ct1.Enabled = dteNgay_Ct2.Enabled = false;

				this.btEdit.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
			}

		}

	}
}
