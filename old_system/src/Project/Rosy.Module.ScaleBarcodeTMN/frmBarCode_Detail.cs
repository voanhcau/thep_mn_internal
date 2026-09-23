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

namespace RosyModule.ScaleBarcodeTMN
{
	public partial class frmBarCode_Detail : RosySystem.Customize.frmView
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
        string strStt_Scale = string.Empty;
        string strStt_SO = string.Empty;
        string strMa_Vt_Org = string.Empty;
		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;
        private string strModule = "15";
        string strNE = string.Empty;
        private string strKV = "KH"; // nếu ko phải thủ kho mà là khác
        private BackgroundWorker _bw;
        private List<string> _scannedFiles = new List<string>();
        private class ScanArgs
        {
            public string Token;
            public DateTime DocDate;
        }

        DataTable dtSO;
		#endregion

		public frmBarCode_Detail()
		{
			InitializeComponent();

            _bw = new BackgroundWorker();
            _bw.DoWork += bw_DoWork;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            this.btPrint.Click += new EventHandler(btPrint_Click);

			this.txtSo_Xe_Filter.Validated += new EventHandler(txtSo_Xe_Filter_Validated);
			this.cboSo_Xe.SelectedValueChanged += new EventHandler(cboSo_Xe_SelectedValueChanged);
            txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			this.cboSo_Ct.SelectedValueChanged += new EventHandler(cboSo_Ct_SelectedValueChanged);
			this.rdbSo_Xe_Ct.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
			this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
			this.btSave_Voucher.Click += new EventHandler(btSave_Voucher_Click);
            //this.btCheckInventory.Click += new EventHandler(btCheckInventory_Click);
			this.txtBarcode.LostFocus += new EventHandler(txtBarcode_LostFocus);
			this.dgvEditCt.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.dgvEditCt.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);
            txtSo_Ct_SO.Validating += new CancelEventHandler(txtSo_Ct_SO_Validating);

			this.btFirst.Click += new EventHandler(btFirst_Click);
			this.btNext.Click += new EventHandler(btNext_Click);
			this.btPrevious.Click += new EventHandler(btPrevious_Click);
			this.btLast.Click += new EventHandler(btLast_Click);

			
			this.btEdit.Click += new EventHandler(btEdit_Click);
            this.btNew.Click += new EventHandler(btNew_Click);
            this.btInherit.Click += new EventHandler(btInherit_Click);
            this.btImport.Click += new EventHandler(btImport_Click);

            this.btPhieuXuat.Click += new EventHandler(btPhieuXuat_Click);
            this.btDieuChinh.Click += new EventHandler(btDieuChinh_Click);
         
		}

        
		new public void Load(string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;
			this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);
			this.dteNgay_Ct1.Text = this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());
           
            if (Common.InlistLike(strMa_Ct, "PN"))
                btPhieuXuat.Visible = false;

            //lấy danh sách các kho
            if (SQLExec.ExecuteReturnDt("SELECT Ma_Kho FROM R00USER_KHO WHERE Member_ID = '" + Element.sysUser_Id + "'").Rows.Count > 0)
            {
                txtMa_Kho_Filter.Text = DataTool.SQLGetNameByCode("R00USER_KHO", "Member_ID", "Ma_Kho", Element.sysUser_Id);
                strKV = DataTool.SQLGetNameByCode("R00USER_KHO", "Member_ID", "Ky_Hieu", Element.sysUser_Id);
            }
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

            //if (dgvEditCt.Columns.Contains("Ngay_Nhap"))
            //    dgvEditCt.Columns["Ngay_Nhap"].HeaderText = "Ngày sản xuất";

			if (dgvEditCt.Columns.Contains("So_Luong"))
				dgvEditCt.Columns["So_Luong"].HeaderText = "Khối lượng";

			if (dgvEditCt.Columns.Contains("Num_Bars"))
				dgvEditCt.Columns["Num_Bars"].HeaderText = "Số cây";

			//ReadOnly
            string strColumn_Name = string.Empty;
            if(Common.InlistLike(strMa_Ct, "PN"))
			    strColumn_Name = "BARCODE,SO_LUONG,SO_LUONG_CURRENT,NUM_BARS_CURRENT,SO_LUONG_BARCODE,NUM_BARS_BARCODE,LENGTH,NGAY_NHAP,CA,NUM_LOT,TEN_SIZE,GRADE_NAME,STANDARD_NAME,TEN_CL,IS_OUTPUT,NUM_BARS";
            else
                strColumn_Name = "BARCODE,SO_LUONG_CURRENT,NUM_BARS_CURRENT,SO_LUONG_BARCODE,NUM_BARS_BARCODE,LENGTH,NGAY_NHAP,CA,NUM_LOT,TEN_SIZE,GRADE_NAME,STANDARD_NAME,TEN_CL,IS_OUTPUT";
			foreach (var strColumn in strColumn_Name.Split(','))
			{
				if (dgvEditCt.Columns.Contains(strColumn))
					dgvEditCt.Columns[strColumn].ReadOnly = true;
			}
		}

		private void Init_Ct()
		{
            //txtMa_Nvu.Text = "BKV";
            dteNgay_Ct.Text = DateTime.Now.ToString();

            //lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DMNVU", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			drDmNvu = DataTool.SQLGetDataRowByID("R81DMNVU", "Ma_NVu", txtMa_Nvu.Text.Trim());
            txtSo_Ct_SO.Enabled = false;
            btInherit.Enabled = false;

		}

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CT", this.strMa_Ct);
			htPara.Add("SO_XE_FILTER", this.txtSo_Xe_Filter.Text);
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
            htPara.Add("MA_KHO", txtMa_Kho_Filter.Text);
            //htPara.Add("DUYET", 1);

            dtEditPh = SQLExec.ExecuteReturnDt("sp_GetVoucher_BarCodeKV_PH", htPara, CommandType.StoredProcedure);
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

            

            //this.ExportControl = dgvExport;
            this.ExportControl = dgvEditCt;

            //kiểm tra xem có CNXX ứng với số lệnh này chưa
            CheckCNXX();

        }
        private const string BASE_ROOT = @"\\192.168.1.18\scale_print\GCNXX_DT";
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (ScanArgs)e.Argument;
            if (txtMa_Kho.Text.StartsWith("551"))
                return;

            // Quét tối ưu
            List<string> files = Voucher_ScaleTMN.SearchPdfOptimized(BASE_ROOT, args.Token, Library.StrToDate(dteNgay_Ct.Text));//args.DocDate);

            e.Result = files;
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //btnQuet.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show("Lỗi khi quét: " + e.Error.Message);
                return;
            }

            var files = (List<string>)e.Result;

            if (files != null && files.Count > 0)
                lblCanhBao.Text = "Đã có file CNXX";
            else if(txtMa_Kho.Text.StartsWith("551"))
                lblCanhBao.Text = "Lệnh không có CNXX";
            else
                lblCanhBao.Text = "Chưa có file CNXX";

            _scannedFiles = files;
           
        }
        private void CheckCNXX()
        {
            lblCanhBao.Text = "";

            if (strNE == "N" || !Common.InlistLike(strMa_Ct,"PX"))
                return;

            string soChungTu = txtSo_Ct.Text == null ? "" : txtSo_Ct.Text.Trim();
           
            if (soChungTu.Length < 12)
                return;

            DateTime docDate;
            if (!Voucher_ScaleTMN.TryExtractDocDate(soChungTu, out docDate))
            {
                lblCanhBao.Text = "Chưa có file CNXX";
                return;
            }

            string token = Voucher_ScaleTMN.NormalizeSoChungTu(soChungTu);

            if (_bw.IsBusy)
            {
                MessageBox.Show("Đang quét, vui lòng chờ...");
                return;
            }
            _bw.RunWorkerAsync(new ScanArgs { Token = token, DocDate = docDate });
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
				}
			}
			else
				this.Reset_Voucher_Edit();
		}

		private void FillData_Voucher_Ct()
		{
            dtEditCt = SQLExec.ExecuteReturnDt("sp_GetVoucher_BarCodeKV_Ct", new string[] { "Ma_Ct", "Stt" }, new object[] { this.strMa_Ct, this.strStt }, CommandType.StoredProcedure);

			DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtEditCt.Columns.Add(dc);

			bdsEditCt.DataSource = dtEditCt;
			dgvEditCt.DataSource = bdsEditCt;
			dgvEditCt.ClearSelection();

            if (dtEditCt.Rows.Count == 0)
                enuNew_Edit_Voucher = enuEdit.New;
            else
            {
                enuNew_Edit_Voucher = enuEdit.Edit;
                txtMa_Kho.Text = (string)dtEditCt.Rows[0]["Ma_Kho"];
                //txtMa_Nvu.Text = (string)dtEditCt.Rows[0]["Ma_Nvu"];
                strStt_Scale = (string)dtEditCt.Rows[0]["Stt_Org"];
            }

            LoadSoLuong();
        }

        private void AddRowBarcode(DataRow drDmBarcode)
        {
          
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
            //drNewRow["Ma_Nvu"] = txtMa_Nvu.Text.Trim();
            drNewRow["Ma_Ct"] = this.strMa_Ct;
            drNewRow["So_Ct"] = txtSo_Ct.Text;
            drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;
            drNewRow["Ma_Dt"] = txtMa_Dt.Text.Trim();
            //drNewRow["Dien_Giai"] = txtDien_Giai.Text;
            drNewRow["Ma_Kho"] = txtMa_Kho.Text;
            drNewRow["Barcode"] = drDmBarcode["Barcode"];
            drNewRow["Ma_Vt_Sp"] = drDmBarcode["Ma_Vt_Sp"];

            drNewRow["Ma_Size"] = drDmBarcode["Ma_Size"];
            drNewRow["Ten_Size"] = drDmBarcode["Ten_Size"];
            drNewRow["So_Luong"] = drDmBarcode["So_Luong_Current"];
            drNewRow["Num_Bars"] = drDmBarcode["Num_Bars_Current"];

            drNewRow["So_Luong_Current"] = drDmBarcode["So_Luong_Current"];
            drNewRow["Num_Bars_Current"] = drDmBarcode["Num_Bars_Current"];

           

            drNewRow["Length"] = drDmBarcode["Length"];
            //drNewRow["Ngay_Nhap"] = drDmBarcode["Ngay_Nhap"];

            //drNewRow["Num_Lot"] = drDmBarcode["Num_Lot"];


            drNewRow["Grade_ID"] = drDmBarcode["Grade_ID"];
            drNewRow["Grade_Name"] = drDmBarcode["Grade_Name"];
            drNewRow["Standard_ID"] = drDmBarcode["Standard_ID"];
            drNewRow["Standard_Name"] = drDmBarcode["Standard_Name"];
            drNewRow["Ma_CL"] = drDmBarcode["Ma_CL"];
            drNewRow["Ten_CL"] = drDmBarcode["Ten_CL"];
            drNewRow["Stt_Org"] = strStt_Org;

            drNewRow["Deleted"] = false;

            //if (Convert.ToDouble(drDmBarcode["Num_Bars"]) != 0)
            //    bThep_Cay = true;
            //else
            //    bThep_Cay = false;

            if (enuNew_Edit_Voucher == enuEdit.New)
                drNewRow["Create_Log"] = Common.GetCurrent_Log();
            else
                drNewRow["LastModify_Log"] = Common.GetCurrent_Log();
            dtEditCt.Rows.Add(drNewRow);
            dtEditCt.AcceptChanges();
            LoadSoLuong();
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
            //drNewRow["Ma_Nvu"] = txtMa_Nvu.Text.Trim();
			drNewRow["Ma_Ct"] = this.strMa_Ct;
			drNewRow["So_Ct"] = txtSo_Ct.Text;
			drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;
			drNewRow["Ma_Dt"] = txtMa_Dt.Text.Trim();
            //drNewRow["Dien_Giai"] = txtDien_Giai.Text;
            drNewRow["Ma_Kho"] = txtMa_Kho.Text;
			drNewRow["Barcode"] = drDmBarcode["Barcode"];
			drNewRow["Ma_Vt_Sp"] = drDmBarcode["Ma_Vt_Sp"];

			drNewRow["Ma_Size"] = drDmBarcode["Ma_Size"];
			drNewRow["Ten_Size"] = drDmBarcode["Ten_Size"];
			drNewRow["So_Luong"] = drDmBarcode["So_Luong_Current"];
			drNewRow["Num_Bars"] = drDmBarcode["Num_Bars_Current"];

            drNewRow["So_Luong_Current"] = drDmBarcode["So_Luong_Current"];
            drNewRow["Num_Bars_Current"] = drDmBarcode["Num_Bars_Current"];

            drNewRow["So_Luong_Barcode"] = drDmBarcode["So_Luong_Barcode"];
            drNewRow["Num_Bars_Barcode"] = drDmBarcode["Num_Bars_Barcode"];
			
			drNewRow["Length"] = drDmBarcode["Length"];
            //drNewRow["Ngay_Nhap"] = drDmBarcode["Ngay_Nhap"];
           
            //drNewRow["Num_Lot"] = drDmBarcode["Num_Lot"];
         

            drNewRow["Grade_ID"] = drDmBarcode["Grade_ID"];
            drNewRow["Grade_Name"] = drDmBarcode["Grade_Name"];
            drNewRow["Standard_ID"] = drDmBarcode["Standard_ID"];
            drNewRow["Standard_Name"] = drDmBarcode["Standard_Name"];
            drNewRow["Ma_CL"] = drDmBarcode["Ma_CL"];
            drNewRow["Ten_CL"] = drDmBarcode["Ten_CL"];
            
            if(dtBarcode.Columns.Contains("Bar_Be"))
                drNewRow["BAR_BE"] = drDmBarcode["BAR_BE"];
            
            drNewRow["Stt_Org"] = strStt_Org;
           
			drNewRow["Deleted"] = false;

			if (Convert.ToDouble(drDmBarcode["Num_Bars"]) != 0)
				bThep_Cay = true;
			else
				bThep_Cay = false;

            if(enuNew_Edit_Voucher == enuEdit.New)
                drNewRow["Create_Log"] = Common.GetCurrent_Log();
            else
                drNewRow["LastModify_Log"] = Common.GetCurrent_Log();

			dtEditCt.Rows.Add(drNewRow);
			dtEditCt.AcceptChanges();
            LoadSoLuong();
        }

		private void Reset_Voucher_Edit()
		{
            

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
                //txtDia_Chi.Text = drDmDt["Dia_Chi"].ToString();
			}
			else
			{
				lbtTen_Dt_Ct.Text = txtOng_Ba.Text = string.Empty;
			}

		
            //if (txtMa_Kho.Text.Trim() != string.Empty)
            //    lbtTen_Vt_Sp_Ct.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Kho.Text.Trim());
            //else
            //    lbtTen_Vt_Sp_Ct.Text = string.Empty;


            //txtDien_Giai.Text = (string)drEditPh_Dest["Dien_Giai"];
			
			txtSo_Xe.Text = (string)drEditPh_Dest["So_Xe"];
			txtSo_Xa_Lan_Tau.Text = (string)drEditPh_Dest["So_Xa_Lan_Tau"];
			

		

			this.strStt_Org = (string)drEditPh_Dest["Stt_Org"];
            //this.txtMa_Vt_Org.Text = (string)drEditPh_Dest["Ma_Vt_Org"];
            this.strStt_Scale = (string)SQLExec.ExecuteReturnValue("SELECT Stt_Org FROM R05CTN_BARCODE_KKV WHERE Stt = '"+ strStt +"'");
            //this.txtInfoInherit.Text = GetInfoInherit(this.strStt_Org);
            //this.txtSo_Px.Text = GetInfoInherit_PX(this.strStt_Scale);
		}

		private string GetInfoInherit(string strStt_Org)
		{
			//Hiển thị chứng từ gốc kế thừa
			string strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = T2.Ma_Ct + ':' + T2.So_Ct
					FROM R80PH_BARCODE_KKV T1 JOIN R04CTSO T2 ON T1.Stt_Org = T2.Stt
					WHERE T1.Stt_Org IN (SELECT Stt FROM R04CTSO WHERE Stt = '" + strStt_Org + @"')
				SELECT @_InheritList";

			return SQLExec.ExecuteReturnValue(strSQLExec).ToString();
		}
        private string GetInfoInherit_PX(string strStt_Scale)
        {
            //Hiển thị chứng từ gốc kế thừa
            string strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = T2.Ma_Ct + ':' + T2.So_Ct
                    FROM (select Stt from R05CTX_BARCODE_KKV WHERE Stt = '" + strStt_Scale + "') T1 JOIN (SELECT Stt_Org, So_Ct, Ma_Ct FROM R05CTNX WHERE Stt_Org <> '''' GROUP BY Stt_Org, So_Ct, Ma_Ct) T2 ON T1.Stt = T2.Stt_Org" + @"
				SELECT @_InheritList";

            return SQLExec.ExecuteReturnValue(strSQLExec).ToString();
        }
		private void GatherMemvar_Voucher_Edit()
		{
            dtEditPh_Dest = dtEditPh.Clone();        
            drEditPh = dtEditPh.Rows[0];
            DataRow drDest = dtEditPh_Dest.NewRow();
            Common.SetDefaultDataRow(ref drDest);
            Common.CopyDataRow(drEditPh, drDest);

            drDest["Stt"] = strStt;
            drDest["Stt_Org"] = strStt_Org;
            drDest["Ma_Ct"] = strMa_Ct;
            drDest["So_Ct"] = txtSo_Ct.Text;
            drDest["Ma_Dt"] = txtMa_Dt.Text;
            drDest["So_Xe"] = txtSo_Xe.Text;
            drDest["Ly_Do"] = txtLy_Do.Text;
            drDest["So_Xa_Lan_Tau"] = txtSo_Xa_Lan_Tau.Text;
            drDest["Ngay_Ct"] = dteNgay_Ct.Text;
            drDest["Ma_Vt_Org"] = strMa_Vt_Org;
            
            if (enuNew_Edit_Voucher.ToString().StartsWith("N"))
                drDest["Create_Log"] =DataTool.GetCurrent_Log();
            else
                drDest["LastModify_Log"] = DataTool.GetCurrent_Log();

            if(Common.InlistLike(strMa_Ct, "PN"))
                drDest["Loai_Ct"] = "1";
            else
                drDest["Loai_Ct"] = "2";

            if (Common.InlistLike(strMa_Ct, "PX") && enuNew_Edit_Voucher == enuEdit.New)
                drDest["CNXXNguoiTao"] = "";

            dtEditPh_Dest.Rows.Add(drDest);
            dtEditPh_Dest.AcceptChanges();

           
            dtEditCt.AcceptChanges();
		}

		private void Save()
		{
            this.GatherMemvar_Voucher_Edit();
            //this.Update_Num_Bars();
            
            if (this.btEdit.Text == "Hủy")
                strNE = "E";
            else
                strNE = "N";

            if ((this.strStt == "" || this.strStt == string.Empty) && strNE=="N")
           {
                if(DataTool.SQLCheckExist("R80PH_BARCODE_KKV","Stt", this.strStt))
                    this.strStt = Voucher_ScaleTMN.GetNewStt_KKV("15", true, strKV);
               
            }
            

            if (dtEditCt.Rows.Count <= 0 && strMa_Ct == "PNBKV")
            {
                Common.MsgCancel("Không có dữ liệu chi tiết. Vui lòng quét mã vạch");
                return;
            }
            if (strMa_Ct == "PXBKV" && DataTool.SQLCheckExist("R80PH_BARCODE_KKV", "So_Ct", txtSo_Ct.Text) && this.btEdit.Text != "Hủy")
            {
                 Common.MsgCancel("Lệnh xuất hàng "+txtSo_Ct.Text+" đã được tạo. Vui lòng nhấn sửa để cập nhật thêm barcode!!! ");
                return;
            }
            //Kiểm tra user và kho
            string strKho_List = string.Empty;

            if (!Element.sysIs_Admin && DataTool.SQLCheckExist("R00USER_KHO", "Member_ID", Element.sysUser_Id))
                strKho_List = SQLExec.ExecuteReturnValue("select Ma_Kho from R00USER_KHO WHERE Member_ID = '" + Element.sysUser_Id + "'").ToString();
            else
                Common.MsgOk("Mã nhân viên " + Element.sysUser_Id + " chưa được phân quyền nhập xuất barcode!!!");
            
            if (!Element.sysIs_Admin && !Common.InlistLike(txtMa_Kho.Text, strKho_List))
            {
                Common.MsgCancel("Bạn chỉ được phép nhập xuất kho được phân quyền " + strKho_List + ". Vui lòng sửa mã kho cho phù hợp!!!");
                return;
            }

            if (dtEditPh_Dest.Rows[0]["CNXXNguoiTao"].ToString() != "" && strNE == "N")
                foreach (DataRow dr in dtEditPh_Dest.Rows)
                {
                    dr["CNXXNguoiTao"] = "";
                }


            foreach (DataRow dr in dtEditCt.Rows)
            {
                dr["Ma_Kho"] = txtMa_Kho.Text;
            }
			SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
			SqlCommand sqlCom = sqlCon.CreateCommand();
            //sqlCom.CommandTimeout = 600;

			sqlCom.CommandText = "sp_Update_Ct";
			sqlCom.CommandType = CommandType.StoredProcedure;
            
			sqlCom.Parameters.Clear();
            

			sqlCom.Parameters.AddWithValue("@strNew_Edit", strNE);
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

           
           
            if (Common.InlistLike(strMa_Ct, "PN"))
            {
                sqlCom.CommandText = "sp_Update_CtN_Barcode_KKV";


                //TVP_PH
                paraPH.TypeName = "TVP_PH_NBARCODE_KKV";
                paraPH.Value = Voucher.GetTVPValue("R80PH_BARCODE_KKV", "TVP_PH_NBARCODE_KKV", dtEditPh_Dest);
                sqlCom.Parameters.Add(paraPH);

                //TVP_CT
                paraCt.TypeName = "TVP_CT_NBARCODE_KKV";
                paraCt.Value = Voucher.GetTVPValue("R05CTN_BARCODE_KKV", "TVP_CT_NBARCODE_KKV", dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else
            {
                sqlCom.CommandText = "sp_Update_CtX_Barcode_KKV";


                //TVP_PH
                paraPH.TypeName = "TVP_PH_XBARCODE_KKV";
                paraPH.Value = Voucher.GetTVPValue("R80PH_BARCODE_KKV", "TVP_PH_XBARCODE_KKV", dtEditPh_Dest);
                sqlCom.Parameters.Add(paraPH);

                //TVP_CT
                paraCt.TypeName = "TVP_CT_XBARCODE_KKV";
                paraCt.Value = Voucher.GetTVPValue("R05CTX_BARCODE_KKV", "TVP_CT_XBARCODE_KKV", dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
			try
			{
				sqlCom.ExecuteNonQuery();

				this.strStt_Old = this.strStt;
				//Update to PH
				//this.FillData();

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
					FROM R05CTX_BARCODE_KKV T1 WITH(NOLOCK) LEFT JOIN
							(SELECT T1a.Barcode, SUM(T1a.So_Luong) AS So_Luong_TL
									FROM R05CTN_BARCODE_KKV T1a WITH(NOLOCK) JOIN R81DMBARCODE T2a WITH(NOLOCK) ON T1a.Barcode = T2a.Barcode
									WHERE T1a.Barcode = '" + strBarcode + "' AND T2a.Is_OutPut = 1" + @"
									GROUP BY T1a.Barcode) T2 ON T1.Barcode = T2.Barcode" + @"
					WHERE T1.Stt <> '" + strStt + "' AND T1.Barcode = '" + strBarcode + "'";

			return Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQLExec));
		}

        //private void Print(string strStt, string strTruck_In_Out, bool bPreview)
        //{
        //    Voucher.PrintTruck_In_Out(strStt, strTruck_In_Out, strTruck_In_Out == "IN" ? "rptTruck_In" : "rptTruck_Out", bPreview, Variables.strPrint_Barcode);
        //}

		private void Design()
		{
            string strFile_Name = string.Empty;
            frmIn_BarcodeKKV frm1 = new frmIn_BarcodeKKV();
            frm1.Load(drCurrent);
            if (frm1.isAccept)
            {
                if(frm1.rdbIn_LXH.Checked ==true)
                    strFile_Name = "rptCT_LXHCP_QR";
                else
                    strFile_Name = "rptScale_Out_KKV";

                RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
                frm.Load(strFile_Name);
            }
			
		}

		#region Event
		
		void btPrint_Click(object sender, EventArgs e)
		{
			if (this.strStt != string.Empty)
                Voucher.PrintBarcode_KKV(this.strStt, true, true, _scannedFiles);
		}

		void cboSo_Xe_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboSo_Xe.SelectedValue != null)
			{
				if (cboSo_Xe.SelectedValue.ToString() != "System.Data.DataRowView" && cboSo_Xe.Enabled)
				{
					this.strStt = cboSo_Xe.SelectedValue == null ? string.Empty : cboSo_Xe.SelectedValue.ToString();

					this.FillData_Voucher_Ph();
                    CheckCNXX();
                }
			}
		}

        void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nvu.Text.Trim();
            bool bRequire = true;
            string strFilter = "(CHARINDEX('" + strMa_Ct + "', Ma_Ct, 0) > 0 OR Ma_Ct = '*')";
            string strValid = "Ma_Ct <> ''";

            DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter, strValid);

            if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
            {
                e.Cancel = true;
                return;
            }

            this.drDmNvu = drLookup;

            txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
            //txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();

        }

		void cboSo_Ct_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboSo_Ct.SelectedValue != null)
			{
				if (cboSo_Ct.SelectedValue.ToString() != "System.Data.DataRowView" && cboSo_Ct.Enabled)
				{
					this.strStt = cboSo_Ct.SelectedValue == null ? string.Empty : cboSo_Ct.SelectedValue.ToString();
					this.FillData_Voucher_Ph();
                    CheckCNXX();
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
                //if (string.IsNullOrEmpty(txtMa_Nvu.Text))
                //{
                //    Common.MsgCancel("Bạn phải chọn nghiệp vụ trước khi thực hiện!");
                //    return;
                //}
                if (string.IsNullOrEmpty(txtMa_Kho.Text))
                {
                    Common.MsgCancel("Bạn phải chọn mã kho trước khi thực hiện!");
                    return;
                }
				this.txtBarcode.Focus();
				this.txtBarcode.Select(0, txtBarcode.Text.Length);
				string strBarcode = txtBarcode.Text.Trim();
                string strBarCode_SO = string.Empty;

                
                Hashtable ht = new Hashtable();
                ht.Add("BARCODE", txtBarcode.Text);
                ht.Add("STT_ORG", strStt_Org);
                ht.Add("MA_CT", strMa_Ct);
                strBarCode_SO = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_CheckBarCodeKKV(@BarCode,@Stt_Org,@Ma_Ct)", ht, CommandType.Text);

                if (strBarcode.StartsWith("]C1"))
                    strBarcode = strBarcode.Substring(3, strBarcode.Length - 3);

                txtBarcode.Text = strBarcode;

				//Check exists Barcode
				if ((!Common.InlistLike(txtMa_Kho.Text, "055") && !DataTool.SQLCheckExist("R05CTN_BARCODE_KKV", "Barcode", strBarcode)) ||
                        Common.InlistLike(txtMa_Kho.Text, "055") && !DataTool.SQLCheckExist("R81DMBARCODE", "Barcode", strBarcode)) 
				{
					Common.MsgCancel("Bạn nhập mã vạch {" + strBarcode + "} không tồn tại!");
					txtBarcode.BackColor = Color.Red;
					txtBarcode.Select(0, txtBarcode.Text.Length);
					txtBarcode.Focus();
				}
                else if ((strBarCode_SO == null || strBarCode_SO == "" || strBarCode_SO == string.Empty) && (!txtSo_Ct.Text.StartsWith("DC")))
                {
                    if (Common.InlistLike(strMa_Ct, "PN"))
                        Common.MsgCancel("Bạn nhập mã vạch {" + strBarcode + "} sản phẩm không tồn tại trên lệnh xuất hàng");
                    else
                        Common.MsgCancel("Vui lòng kiểm tra sản phẩm không tồn tại trên lệnh xuất hàng");
                    txtBarcode.BackColor = Color.Red;
                    txtBarcode.Select(0, txtBarcode.Text.Length);
                    txtBarcode.Focus();
                }
                else if (dtEditCt.Select("Barcode = '" + strBarcode + "'").Length >= 1)
                {
                    Common.MsgCancel("Vui lòng kiểm tra barcode " + strBarcode + " đã quét rồi");
					txtBarcode.BackColor = Color.Red;
					txtBarcode.Select(0, txtBarcode.Text.Length);
					txtBarcode.Focus();
                }
               
                else
                {
                    DataTable dtBarcode;
                    Hashtable htBarCode = new Hashtable();
                    htBarCode.Add("BARCODE", strBarcode);
                    htBarCode.Add("MA_KHO", txtMa_Kho.Text);

                    if (Common.InlistLike(strMa_Ct, "PN"))
                        dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarCode_NKKV", htBarCode, CommandType.StoredProcedure);
                    else
                    {
                        
                        htBarCode.Add("STT_ORG", strStt_Org);
                        dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarCode_XKKV", htBarCode, CommandType.StoredProcedure);
                    }

                    if (dtBarcode.Rows.Count == 0)
                    {
                        Common.MsgCancel("Bó thép {" + strBarcode + "} đã được xuất hết hoặc chưa cập nhật cơ tính. Vui lòng kiểm tra lại.");
                    }
                    //else if (!Convert.ToBoolean(dtBarcode.Rows[0]["Is_OutPut"]))
                    //{
                    //    Common.MsgCancel("Bó thép này chưa được phép xuất kho");
                    //    return;
                    //}
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
                               
                            this.txtBarcode.Focus();
                            this.txtBarcode.Select(0, txtBarcode.Text.Length);
                            this.txtBarcode.BackColor = SystemColors.Window;
                            this.txtBarcode.Text = string.Empty;

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
			this.Save();

            txtSo_Ct_SO.Text = "";
            txtSo_Ct_SO.Enabled = false;
            btInherit.Enabled = false;
			
            this.txtBarcode.Text = string.Empty;
			this.btEdit.Text = "Sửa";
			this.btSave_Voucher.Enabled = false;
			
			this.txtBarcode.Enabled = false;
			this.txtBarcode.ReadOnly = true;
            this.btEdit.Enabled = true;
            this.btNew.Enabled = true;
            this.btSave_Voucher.Enabled = false;
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
								dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

							dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
							dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

							if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
								dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

							drCurrent["So_Luong"] = dbSo_Luong;

							
						}
					}
					else
						drCurrent.RejectChanges();
				}
			}
            else if (Common.Inlist(strColumnName, "IS_BE"))
            {
                if ((bool)drCurrent["Is_Be"])
                {
                    drCurrent["Ngay_Be"] = Voucher.GetDate_Server();
                    drCurrent["Bar_Be"] = "BE";
                }
                else
                {
                    drCurrent["Ngay_Be"] = Convert.ToDateTime("01/01/1900");
                    drCurrent["Bar_Be"] = "THANG";
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
            //if (bdsEditPh.Position < 0)
            //    return;

            //if (this.bdsEditPh.Position + 1 < this.bdsEditPh.Count)
            //{
            //    this.bdsEditPh.MoveNext();
            //    this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            //    if (cboSo_Xe.SelectedValue != null)
            //        this.cboSo_Xe.SelectedValue = this.strStt;
            //}

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

		
        void txtSo_Ct_SO_Validating(object sender, CancelEventArgs e)
        {
            if (!Common.InlistLike(txtMa_Kho.Text, "551") && this.strMa_Ct == "PNBKV")
            {
                bool bRequire = true;
                string strMa_Ct = string.Empty;
                string strKey = "0 = 0";
                DateTime dtNgay_Ct2 = DateTime.Now;
                DateTime dtNgay_Ct1 = dtNgay_Ct2.Subtract(new TimeSpan(15, 0, 0, 0));
                //txtMa_Kho.Text = dtSO.Rows[0]["Ma_Kho"].ToString();
                if (this.strMa_Ct == "PXBKV")
                {
                    if (txtMa_Kho.Text.StartsWith("GK"))
                    {
                        strKey += " AND Stt IN (SELECT Stt FROM R04CTSO WHERE Ma_KhoN = '" + txtMa_Kho.Text + "')";
                        strKey += " AND Duyet = 1";
                        strKey += " AND Ma_Ct = 'LXH'";
                    }
                    //else if (txtMa_Kho.Text.StartsWith("551"))
                    //{
                    //    strKey += " AND Stt IN (SELECT Stt FROM R04CTSO WHERE Ma_KhoN = '" + txtMa_Kho.Text + "')";
                    //    strKey += " AND Duyet = 1";
                    //    strKey += " AND Ma_Ct = 'LXH'";
                    //}
                    else
                    {
                        strKey += " AND Stt IN (SELECT Stt FROM R04CTSO WHERE Ma_Kho = '" + txtMa_Kho.Text + "')";
                        strKey += " AND Duyet = 1";
                        strKey += " AND Ma_Ct = 'SOCP'";
                    }
                }
                else
                {

                    strKey += " AND Duyet = 1";
                }
                strKey += " AND Ngay_Ct >= '" + dtNgay_Ct1.ToShortDateString() + "' AND Ngay_Ct <='" + dtNgay_Ct2.ToShortDateString() + "'";

                if (txtSo_Ct_SO.Text != "/")
                    strKey += " AND So_Ct LIKE '" + txtSo_Ct_SO.Text + "%'";

                if (!txtMa_Kho.Text.StartsWith("GK"))
                    strKey += " AND Stt NOT IN (SELECT Stt_Org FROM R80PH_BARCODE_KKV WHERE Stt_Org <> '')";

                strKey += " AND Stt IN (SELECT Stt FROM R80PH WHERE Duyet_Huy = 0 AND Duyet = 1)";

                DataRow drLookup = Tool.ShowLookup("Stt", "", bRequire, strKey, null);

                if (drLookup != null)
                {
                    txtSo_Ct_SO.Text = (string)drLookup["So_Ct"];
                    strStt_SO = (string)drLookup["Stt"];
                    SetDataInherit(strStt_SO);
                }
            }

        }
        private void LoadSoLuong()
        {
            numTSo_Luong.Value = Common.SumDCValue(dtEditCt, "So_Luong", "");
            //điếm số bó
            DataRow[] So_Bo = dtEditCt.Select("Barcode NOT LIKE 'L%'");
            numTSo_Bo.Value = So_Bo.Length;
            numTNum_Bars.Value = Common.SumDCValue(dtEditCt, "Num_Bars", "Barcode LIKE 'L%'"); //dtEditCt.Select("Barcode LIKE 'L%'");
            
        }

        private void SetDataInherit(string strStt_SO)
        {
            string strSQL = string.Empty;

            if (strStt_SO != "")
                strSQL = "SELECT * FROM R04CTSO WHERE Stt = '" + strStt_SO + "' AND Stt IN (SELECT Stt FROM R80PH WHERE Duyet = 1 AND Duyet_Huy = 0)";
            else
            {
                if (Common.InlistLike(strMa_Ct, "PN"))
                    strSQL = "SELECT * FROM R04CTSO WHERE So_Ct = '" + txtSo_Ct_SO.Text + "' AND Stt IN (SELECT Stt FROM R80PH WHERE Duyet = 1)";
                else
                {
                    strSQL = "SELECT * FROM R04CTSO WHERE So_Ct = '" + txtSo_Ct_SO.Text + "' AND Stt IN (SELECT Stt FROM R80PH WHERE Duyet = 1 AND Duyet_Huy = 0 )"; //AND Print_Count = 1
                    if (SQLExec.ExecuteReturnDt(strSQL).Rows.Count == 0)
                    {
                        Common.MsgOk("Lệnh xuất hàng phải có số lần in lớn hơn 0, các anh chị phải in lệnh mới cho phép xuất!!!");
                    }
                }
                    
            }
            dtSO = SQLExec.ExecuteReturnDt(strSQL);

            if (dtSO.Rows.Count > 0)
            {
                DataRow drSO = dtSO.Rows[0];
                if (drSO["Ma_Kho"].ToString().StartsWith("GK"))
                {
                    //string strSo_Ct_Max = SQLExec.ExecuteReturnValue("SELECT MAX(So_Ct) FROM R80PH_BARCODE_KKV WHERE Ma_Ct = '"+strMa_Ct+"' AND So_Ct = '" + drSO["So_Ct"].ToString() + "'").ToString();
                    //int i = 0;
                    //if (strSo_Ct_Max == null)
                    //    i = 1;
                    //else
                    //    i = Convert.ToInt16(strSo_Ct_Max.Substring(15));
                    

                    if (strMa_Ct == "PNBKV")
                        txtSo_Ct.Text = drSO["So_Ct"].ToString() + "NGK" ;
                    else
                        txtSo_Ct.Text = drSO["So_Ct"].ToString() + "XGK";
                }
                else
                    txtSo_Ct.Text = drSO["So_Ct"].ToString();
                //txtDien_Giai.Text = drSO["Dien_Giai"].ToString();
                txtMa_Dt.Text = drSO["Ma_Dt"].ToString();
                txtSo_Xe.Text = drSO["So_Xe"].ToString();
                txtSo_Xa_Lan_Tau.Text = drSO["So_Xa_Lan_Tau"].ToString();
                txtOng_Ba.Text = drSO["Ong_Ba"].ToString();
                txtLy_Do.Text = Convert.ToDouble(drSO["So_Luong_CNXX"]) != 0 ? "Số CNXX bản giấy: " + Convert.ToInt16(drSO["So_Luong_CNXX"]).ToString() : "";
                lbtTen_Dt_Ct.Text = drSO["Ong_Ba"].ToString();
                strStt_Org = drSO["Stt"].ToString();
             
                

                if (Common.InlistLike(strMa_Ct, "PX"))
                {
                    if (drSO["Ma_Kho"].ToString().StartsWith("GK") && !drSO["Ma_Kho"].ToString().StartsWith("GK_051") && !(bool)drSO["Is_KhoLe"])
                        txtMa_Kho.Text = drSO["Ma_KhoN"].ToString();
                    else if (drSO["Ma_Kho"].ToString().Contains("04TP") && (bool)drSO["Is_KhoLe"])
                        txtMa_Kho.Text = "052TMN";
                    else
                        txtMa_Kho.Text = drSO["Ma_Kho"].ToString();
                    
                    foreach (DataRow dr in dtSO.Rows)
                        strMa_Vt_Org = strMa_Vt_Org + ","+ dr["Ma_Vt"].ToString();
                }
                else
                {
                    txtMa_Kho.Text = drSO["Ma_KhoN"].ToString();
                }
            }
           else if(strMa_Ct == "PNBKV" && txtSo_Ct_SO.Text.StartsWith("DD"))
            {
                txtMa_Dt.Text = "1000043";
                txtOng_Ba.Text = "Công ty TNHH Một Thành Viên Thép Miền Nam - VNSTEEL";
                txtSo_Xe.Text = "";
                txtSo_Xa_Lan_Tau.Text = "";
                txtSo_Ct.Text = txtSo_Ct_SO.Text;
            }
            else
            {
                Common.MsgOk("Vui lòng chọn phiếu xác nhận đơn hàng");
                txtSo_Ct_SO.Focus();
            }
        }
        void btDieuChinh_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            
            ht.Add("MA_KHO", txtMa_Kho.Text);

            DataTable dtImport = SQLExec.ExecuteReturnDt("sp_DieuChinhBarcodeKKV", ht, CommandType.StoredProcedure);
            bool bThep_Cay = true;

            foreach (DataRow dr in dtImport.Rows)
            {

                if (dtImport.Rows.Count>0)
                    AddRowBarcode(dr);
            }
        }
        void btPhieuXuat_Click(object sender, EventArgs e)
        {
            DataTable dtCtNX;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strStt_Org = drCurrent["Stt_Org"].ToString();
            string strStt_Current = drCurrent["Stt"].ToString();
            string strMa_Kho = drCurrent["Ma_Kho"].ToString();
            string strHt_Gn = DataTool.SQLGetNameByCode("R04CTSO", "Stt", "Ht_Gn", drCurrent["Stt_Org"].ToString());

            string strMa_Ct = string.Empty;
            string strMa_Nvu = string.Empty;
            string strTable_Name = string.Empty;

           
            if (strMa_Kho.StartsWith("051") && !strHt_Gn.StartsWith("GK"))
            {
                if (Common.InlistLike(strHt_Gn, "HD"))
                { 
                    strMa_Ct = "PXKV";
                    strTable_Name = "R05CTNX";
                    if (strMa_Kho == "051P2")
                        strMa_Nvu = "PX55";
                    else if (strMa_Kho == "051CT")
                        strMa_Nvu = "PX61";
                    else if (strMa_Kho == "051D2")
                        strMa_Nvu = "PX53";
                }
                else
                {
                    strMa_Ct = "PXDC";
                    strTable_Name = "R05CTNX";
                    if (strMa_Kho == "051CT")
                        strMa_Nvu = "AP61";
                    else if (strMa_Kho == "051D2")
                        strMa_Nvu = "AP71";
                }
            }
            else if (Common.InlistLike(strMa_Kho,"551"))
            {
                strMa_Ct = "PXCP";
               

            }
            else if (Common.InlistLike(strMa_Kho, "GK") || (strHt_Gn.StartsWith("GK") && strMa_Kho.StartsWith("051")))
            {
                strMa_Ct = "PXGK";
                
            }
            else if (Common.InlistLike(strMa_Kho,"052,058"))
            {
                if (Common.InlistLike(strHt_Gn, "HD"))
                { strMa_Ct = "PXKV"; strMa_Nvu = "PX56"; }
                else if (Common.InlistLike(strHt_Gn, "DD"))
                { strMa_Ct = "PXDC"; strMa_Nvu = "AP22"; }
                else if (Common.InlistLike(strHt_Gn, "GK"))
                { strMa_Ct = "PXGK"; strMa_Nvu = "PXGK02"; }
                else
                    strMa_Ct = "PXDC";

               
            }
            else if (strMa_Kho.StartsWith("055"))
            {
                if (Common.InlistLike(strHt_Gn, "HD"))
                { strMa_Ct = "PXKV"; strMa_Nvu = "PX25"; }
                else if (Common.InlistLike(strHt_Gn, "DD,KG"))
                { strMa_Ct = "PXDC"; strMa_Nvu = "AP22";  }
                else if (Common.InlistLike(strHt_Gn, "GK"))
                { strMa_Ct = "PXGK"; strMa_Nvu = "PXGK05"; }
                else
                { strMa_Ct = "PXDC";  }
                
               
            }
            strTable_Name = DataTool.SQLGetNameByCode("R00DMCT", "Ma_Ct", "Table_Ct", strMa_Ct);

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt_Current);
            ht.Add("MA_NVU", strMa_Nvu);
            DataTable dtDuyetDNX = SQLExec.ExecuteReturnDt("sp_GetInheritPXBKV", ht, CommandType.StoredProcedure);    
            if (dtDuyetDNX.Rows.Count > 0)
            {
                //lấy phiếu gần nhất để tính số ct
                if(strMa_Nvu == "" && strHt_Gn.StartsWith("HD"))
                    strHt_Gn = "SELECT TOP 1 * FROM R80PH WHERE Duyet = 1 AND Duyet_Huy = 0 AND Ma_Ct = '" + strMa_Ct + "' AND Stt IN (SELECT Stt FROM " + strTable_Name + " " +
                                        " WHERE Ht_Gn like '" + strHt_Gn.Substring(0, 2) + "%' AND Ma_Kho = '"+txtMa_Kho.Text+"'" +
                                          " AND Ngay_Ct IN (SELECT MAX(Ngay_Ct) FROM " + strTable_Name + " WHERE Ht_Gn like '" + strHt_Gn.Substring(0, 2) + "%' AND Ma_Kho = '" + txtMa_Kho.Text + "' AND Ma_Ct = '" + strMa_Ct + "'))";
                else if (strMa_Nvu == "" && strHt_Gn.StartsWith("GK"))
                    strHt_Gn = "SELECT TOP 1 * FROM R80PH WHERE Duyet = 1 AND Duyet_Huy = 0 AND Ma_Ct = '" + strMa_Ct + "' AND Stt IN (SELECT Stt FROM " + strTable_Name + " " +
                                        " WHERE Ma_Kho = 'GK_" + txtMa_Kho.Text + "'" +
                                          " AND Ngay_Ct IN (SELECT MAX(Ngay_Ct) FROM " + strTable_Name + " WHERE Ma_Kho = 'GK_" + txtMa_Kho.Text + "' AND Ma_Ct = '" + strMa_Ct + "'))";
                else
                    strHt_Gn = "SELECT TOP 1 * FROM R80PH WHERE Duyet = 1 AND Duyet_Huy = 0 AND Ma_Ct = '" + strMa_Ct + "' AND Stt IN (SELECT Stt FROM " + strTable_Name + " " +
                                        "  WHERE Ht_Gn like '" + strHt_Gn.Substring(0, 2) + "%' AND Ma_NVu = '"+ strMa_Nvu +"' " +
                                          " AND Ngay_Ct IN (SELECT MAX(Ngay_Ct) FROM " + strTable_Name + " WHERE Ht_Gn like '" + strHt_Gn.Substring(0, 2) + "%' AND Ma_NVu = '" + strMa_Nvu + "' AND Ma_Ct = '" + strMa_Ct + "'))";
              
                if(txtMa_Kho.Text.StartsWith("551"))
                    strHt_Gn = "SELECT TOP 1 * FROM R80PH WHERE Duyet = 1 AND Duyet_Huy = 0 AND Ma_Ct = '" + strMa_Ct + "' AND Stt IN (SELECT Stt FROM " + strTable_Name + " " +
                                        " WHERE  Ma_Kho like '" + txtMa_Kho.Text.Substring(0, 6) + "%'" +
                                          " AND Ngay_Ct IN (SELECT MAX(Ngay_Ct) FROM " + strTable_Name + " WHERE  Ma_Kho like '" + txtMa_Kho.Text.Substring(0, 6) + "%' AND Ma_Ct = '" + strMa_Ct + "'))";

                dtCtNX = SQLExec.ExecuteReturnDt(strHt_Gn);
                if (dtCtNX.Rows.Count == 0)
                {
                    if(strMa_Ct.StartsWith("GK"))
                        dtCtNX = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R80PH WHERE Duyet = 1 AND Duyet_Huy = 0 AND Ma_Ct = '" + strMa_Ct + "' AND Stt IN (SELECT Stt FROM " + strTable_Name + " WHERE  " +
                                          " Ngay_Ct IN (SELECT MAX(Ngay_Ct) FROM " + strTable_Name + " WHERE Ma_Ct = '" + strMa_Ct + "'))");
                    else
                        dtCtNX = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R80PH WHERE Duyet = 1 AND Duyet_Huy = 0 AND Ma_Ct = '" + strMa_Ct + "' AND Stt IN (SELECT Stt FROM " + strTable_Name + " WHERE Ma_Kho like '" + strMa_Kho.Substring(0, 2) + "%' " +
                                          " AND Ngay_Ct IN (SELECT MAX(Ngay_Ct) FROM " + strTable_Name + " WHERE Ma_Kho like '" + strMa_Kho.Substring(0, 2) + "%' AND Ma_Ct = '" + strMa_Ct + "'))");


                }

                frmCtNXNX_Edit frm = new frmCtNXNX_Edit();
                frm.Load(enuEdit.New, dtCtNX.Rows[0], dtDuyetDNX, strMa_Ct);

            }
            else
                Common.MsgOk("Phiếu đã ra xong PXK hay tồn kho kế toán không có. Vui lòng kiểm tra lại. Chưa tạo phiếu được!!!");
        }
        void btImport_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("STT_ORG", strStt_SO);
            ht.Add("MA_KHO", txtMa_Kho.Text);
            ht.Add("SO_LXH", txtSo_Ct_SO.Text);
            DataTable dtImport = SQLExec.ExecuteReturnDt("sp_ImportBarcodeKKV", ht, CommandType.StoredProcedure);
            bool bThep_Cay = true;
            
            foreach (DataRow dr in dtImport.Rows)
            {
                DataTable dtBarcode;
                Hashtable htBarCode = new Hashtable();
                htBarCode.Add("BARCODE", dr["Barcode"]);
                htBarCode.Add("BAR_BE", dr["Bar_Be"]);
                dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarCode_NKKV", htBarCode, CommandType.StoredProcedure);
                
                if(dtBarcode != null)
                    AddRowBarcode(dtBarcode, ref bThep_Cay);
            }
        }

        void btInherit_Click(object sender, EventArgs e)
        {
            SetDataInherit(strStt_SO);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            this.strStt = Voucher_ScaleTMN.GetNewStt_KKV("15", true, strKV); //Common.GetNewStt("15", true); //
           
            txtMa_Nvu.ReadOnly = false;
            txtMa_Kho.ReadOnly = false;
            dteNgay_Ct.ReadOnly = false;
            txtSo_Ct.ReadOnly = false;
            txtSo_Xe.ReadOnly = false;
            txtSo_Xa_Lan_Tau.ReadOnly = false;
            txtMa_Dt.ReadOnly = false;
            txtOng_Ba.ReadOnly = false;
            txtLy_Do.ReadOnly = false;
            txtBarcode.Enabled = true;
            btSave_Voucher.Enabled = true;
            this.txtBarcode.ReadOnly = false;
            txtSo_Ct_SO.Enabled = true;
            btInherit.Enabled = true;

            if (this.strMa_Ct == "PNBKV" || (this.strMa_Ct == "PXBKV" && txtMa_Kho.Text.StartsWith("GK")))
                btImport.Visible = true;
            else 
                btDieuChinh.Visible = true;

            if (enuNew_Edit_Voucher == enuEdit.New)
            {
                string strMember = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_Id = '" + Element.sysUser_Id + "'");

                if (strMember != string.Empty || strMember != null || strMember != "")
                {
                    if (Common.InlistLike(strMember, "NT"))
                    {
                        //txtMa_Nvu.Text = "BKVNT";
                        txtMa_Kho.Text = "051NT";
                    }
                    else if (Common.InlistLike(strMember, "DT"))
                    {
                        //txtMa_Nvu.Text = "BKVDN";
                        txtMa_Kho.Text = "051DN";
                    }
                    else if (Common.InlistLike(strMember, "CT"))
                    {
                        //txtMa_Nvu.Text = "BKVDN";
                        txtMa_Kho.Text = "051CT";
                    }
                    else if (Common.InlistLike(strMember, "PQ"))
                    {
                        //txtMa_Nvu.Text = "BKVDN";
                        txtMa_Kho.Text = "051P2";
                    }

                    else if (Common.InlistLike(strMember, "TMN"))
                    {
                        //txtMa_Nvu.Text = "BKVDN";
                        txtMa_Kho.Text = "052TMN";
                    }
                    }
                //txtSo_Ct.Text = Voucher_ScaleTMN.GetNewSo_Ct();
            }
            FillData_Voucher_Ph();
            FillData_Voucher_Ct();
            
            btEdit.Enabled = false;
            btSave_Voucher.Enabled = true;
        }
		void btEdit_Click(object sender, EventArgs e)
		{
            drCurrent = ((DataRowView)bdsEditPh.Current).Row;

            bool bCheck = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CheckPXBARCODEKKV ('" + drCurrent["Stt"].ToString() + "')"));

            if (txtSo_Ct.Text.StartsWith("DC"))
                bCheck = false;
            if (strMa_Ct.StartsWith("PN"))
                bCheck = false;

            if (bCheck)
            {
                MessageBox.Show("Phiếu đã kế thừa ra PXK không được sửa !!! Phải xóa PXK mới được phép sửa");
                return;
            }
            else
            {
                if (btEdit.Text == "Hủy")
                {
                    this.btEdit.Text = "Sửa";

                    this.txtBarcode.Text = string.Empty;
                    this.btSave_Voucher.Enabled = false;
                    //this.btCheckInventory.Enabled = false;
                    this.txtBarcode.Enabled = false;
                    this.txtBarcode.ReadOnly = true;
                }
                else
                {

                    if (Convert.ToInt32(SQLExec.ExecuteReturnValue("sp_CheckCtNX_Inherited_Barcode_KKV", new string[] { "Stt" }, new object[] { this.strStt }, CommandType.StoredProcedure)) > 0)
                    {
                        this.txtBarcode.Text = string.Empty;
                        this.btSave_Voucher.Enabled = false;
                        //this.btCheckInventory.Enabled = false;
                        this.txtBarcode.Enabled = false;
                        this.txtBarcode.ReadOnly = true;
                    }
                    else
                    {
                        this.btEdit.Text = "Hủy";
                        this.btSave_Voucher.Enabled = true;

                        //this.btCheckInventory.Enabled = true;
                        this.txtBarcode.Enabled = true;

                        this.txtBarcode.ReadOnly = false;
                        txtMa_Kho.ReadOnly = false;
                        this.txtBarcode.Focus();
                        FillData_Voucher_Ph();
                        //dtEditCt = SQLExec.ExecuteReturnDt("sp_GetVoucher_BarCodeKV_Ct", new string[] { "Ma_Ct", "Stt" }, new object[] { this.strMa_Ct, this.strStt }, CommandType.StoredProcedure);
                    }
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
					return;

                //case Keys.T:
                //    if (e.Modifiers == Keys.Control)
                //    {
                //        frmTestCom frm = new frmTestCom();
                //        frm.Load("Scale6080");
                //    }
                //    return;
			}

			base.OnKeyDown(e);
		}
       
     
		protected override void OnShown(EventArgs e)
        {
			base.OnShown(e);

            //if (!Element.sysIs_Admin)
            //{
                //if (!Common.CheckPermission("ACCESS_FILTER_DT_TCB", enuPermission_Type.Allow_Access))
                //    dteNgay_Ct1.Enabled = dteNgay_Ct2.Enabled = false;

                //this.btEdit.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
            //}

		}

     

	}
}
