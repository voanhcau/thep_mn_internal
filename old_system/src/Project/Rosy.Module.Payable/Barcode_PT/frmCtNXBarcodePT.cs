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

namespace RosyModule.Payable
{
	public partial class frmCtNXBarcodePT : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
		
		DataSet dsVoucher = new DataSet();
		DataTable dtEditPh;
		DataTable dtEditPh_Dest;
		DataTable dtEditCt;
        DataTable dtStt_Org = new DataTable();

		DataRow drEditCt;
		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
	
		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;

        string strStt_Org = string.Empty;
        string strStt = string.Empty;
        string strSo_Ct = string.Empty;
		#endregion

        public frmCtNXBarcodePT()
		{
			InitializeComponent();

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
			this.btSave_Voucher.Click += new EventHandler(btSave_Voucher_Click);
			
			this.txtBarcode.LostFocus += new EventHandler(txtBarcode_LostFocus);
			this.dgvEditCt.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.dgvEditCt.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);
            this.cboSo_Ct.SelectedValueChanged += new EventHandler(cboSo_Ct_SelectedValueChanged);
			
            this.btFirst.Click += new EventHandler(btFirst_Click);
			this.btNext.Click += new EventHandler(btNext_Click);
			this.btPrevious.Click += new EventHandler(btPrevious_Click);
			this.btLast.Click += new EventHandler(btLast_Click);

            btNhapBarcode.Click += new EventHandler(btNhapBarcode_Click);
            btAdd_DNX.Click += new EventHandler(btAdd_DNX_Click);
            btInherit.Click += new EventHandler(btInherit_Click);
            btReplace.Click += new EventHandler(btReplace_Click);

            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            btKiemKe.Click += new EventHandler(btKiemKe_Click);
           
            dgvEditCt.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
		}

        
		new public void Load()
		{
			this.dteNgay_Ct1.Text = this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());

			this.Build();
			this.FillData();
			this.Init_Ct();
            
			this.Show();
		}
        public void Load(string strStt)
        {
            this.dteNgay_Ct1.Text = this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());

            this.Build();
            // ngầm định thêm mới phiếu
            DataRow drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
            txtMa_Dt.Text = drPh["Ma_Dt"].ToString();
            txtDien_Giai.Text = drPh["Dien_Giai"].ToString() + " Số DNX: " + drPh["So_Ct"].ToString();
            strStt_Org = strStt;
            

            this.Init_Ct();

            this.ShowDialog();
        }
		private void Build()
		{
            dgvEditCt.bSortMode = false;
            dgvEditCt.strZone = "XUAT_BARCODEPT";
            dgvEditCt.BuildGridView();

			this.DataGridView_Language();
            
            foreach (DataGridViewColumn dgvc in dgvEditCt.Columns)
                dgvc.ReadOnly = true;

		}

		private void DataGridView_Language()
		{
		
			
		}

		private void Init_Ct()
		{

            btInherit.Enabled = false;
          
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
         
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
        
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dtEditPh = SQLExec.ExecuteReturnDt("sp_GetXuatBarcodePT_Ph", ht, CommandType.StoredProcedure);
           
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }

            cboSo_Ct.DataSource = dtEditPh;
            cboSo_Ct.ValueMember = "STT";
            cboSo_Ct.DisplayMember = "SO_CT";

         
            
            this.ExportControl = dgvEditCt;
		}
        private void FillData(string strSo_Ct)
        {
            Hashtable ht = new Hashtable();
           
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("SO_CT", strSo_Ct);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dtEditPh = SQLExec.ExecuteReturnDt("sp_GetXuatBarcodePT_Ph", ht, CommandType.StoredProcedure);

            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }
            cboSo_Ct.DataSource = dtEditPh;
            cboSo_Ct.ValueMember = "STT";
            cboSo_Ct.DisplayMember = "SO_CT";



            this.ExportControl = dgvEditCt;
        }
        private void FillData_Voucher_Ph()
        {
            if (!string.IsNullOrEmpty(strStt))
            {
                DataRow[] arrdrEditPh_Dest = dtEditPh.Select("Stt = '" + strStt + "'");
                if (arrdrEditPh_Dest.Length > 0 && arrdrEditPh_Dest.Length == 1)
                {
                    if (this.dtEditPh_Dest != null)
                        this.dtEditPh_Dest.Rows.Clear();

                    this.dtEditPh_Dest = dtEditPh.Clone();

                    foreach (DataRow dr in arrdrEditPh_Dest)
                        this.dtEditPh_Dest.ImportRow(dr);

                    this.bdsEditPh.Position = this.bdsEditPh.Count;
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
            Hashtable ht = new Hashtable();

            ht.Add("STT", this.strStt);
            dtEditCt = SQLExec.ExecuteReturnDt("sp_GetXuatBarcodePT_Ct", ht, CommandType.StoredProcedure);

            DataColumn dc = new DataColumn("Deleted", typeof(bool));
            dc.DefaultValue = false;
            dtEditCt.Columns.Add(dc);

            bdsEditCt.DataSource = dtEditCt;
            dgvEditCt.DataSource = bdsEditCt;
        }
        private void Reset_Voucher_Edit()
        {
            dteNgay_Ct.Text = string.Empty;
            txtSo_Ct.Text = txtMa_Dt.Text = lbtTen_Dt.Text = txtOng_Ba.Text = txtDien_Giai.Text = string.Empty;
           

            if (dtEditCt != null)
                dtEditCt.Rows.Clear();
        }

        void cboSo_Ct_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSo_Ct.SelectedValue != null)
            {
                if (cboSo_Ct.SelectedValue.ToString() != "System.Data.DataRowView" )
                {
                    this.strStt = cboSo_Ct.SelectedValue == null ? string.Empty : cboSo_Ct.SelectedValue.ToString();
                    this.FillData_Voucher_Ph();
                }
            }
        }

        void btInherit_Click(object sender, EventArgs e)
        {
            frmInheritDnTt frmInherit = new frmInheritDnTt();
            frmInherit.Load("DNX");

            if (frmInherit.Is_Accept == true)
            {
                if (frmInherit.dtInheritVoucher.Select("Chon = true").Length == 0)
                    return;

                if (frmInherit.dtInheritVoucher.Select("Chon = true").Length > 1)
                {
                    Common.MsgOk("Không chọn hơn 2 phiếu DNX!!!");
                    return;
                }

                txtMa_Dt.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Dt"].ToString();
                txtDien_Giai.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Dien_Giai"].ToString() + " Số DNX: " + frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Ct"].ToString();
                strStt_Org = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Stt"].ToString();
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text);

                txtInfoInherit.Text = "DNX:" + frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Ct"].ToString();
            }
        }
   

        void btAdd_DNX_Click(object sender, EventArgs e)
        {
            frmAddSttOrg_BarcodePT frm = new frmAddSttOrg_BarcodePT();
            frm.Load();
        }
        void btNhapBarcode_Click(object sender, EventArgs e)
        {
            frmNhapBarcodePT frm = new frmNhapBarcodePT();
            frm.Load();
        }
        bool Check_Barcode(string strMa_Vt)
        {
            if(strStt_Org != string.Empty)
            {
                string strSQL = "SELECT T1.*, (T1.So_Luong - ISNULL(T2.So_Luong,0)) AS So_Luong_Cl FROM R04CTPO T1 LEFT JOIN (SELECT Stt_Org, Ma_Vt, SUM(So_Luong) AS So_Luong FROM R05CTX_BARCODEPT WHERE Stt_Org <> '" + strStt_Org + "' GROUP BY Stt_Org, Ma_Vt) T2 ON T1.Stt = T2.Stt_Org AND T1.Ma_Vt = T2.Ma_Vt WHERE T1.Stt = '" + strStt_Org + "' AND T1.Ma_Vt = '" + strMa_Vt + "'";
                dtStt_Org = SQLExec.ExecuteReturnDt(strSQL);
                if (dtStt_Org.Rows.Count == 0)
                    return false;
            }
            return true;
        }
		private bool AddRowBarcode(DataTable dtBarcode)
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
            if (dtEditCt.Rows.Count > 0)
            {
                foreach (DataRow dr in dtEditCt.Rows)
                {
                    if (txtBarcode.Text == dr["Barcode"].ToString())
                    {
                        dr["So_Luong"] = Convert.ToDouble(dr["So_Luong"]) + 1;
                        dr["So_Luong_CL"] = Convert.ToDouble(dr["So_Luong"]) - Convert.ToDouble(dr["So_Luong_DNX"]);
                        return true;
                    }
                }
            }
                    //else
                    //{
                int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0") + 1);

                //Lấy STT_ORG
                double dbSo_Luong_DNX = 0;
                if (dtStt_Org.Rows.Count != 0)
                {
                    DataRow drStt_Org = dtStt_Org.Rows[0];
                    dbSo_Luong_DNX = Convert.ToDouble(drStt_Org["So_Luong_Cl"]);
                    drNewRow["So_Luong_CL"] = Convert.ToDouble(drNewRow["So_Luong"]) - dbSo_Luong_DNX;
                }

               

                drNewRow["Stt0"] = iStt0;
                drNewRow["So_Ct"] = txtSo_Ct.Text;
                drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;
                drNewRow["Ma_Dt"] = txtMa_Dt.Text.Trim();
                drNewRow["Dien_Giai"] = txtDien_Giai.Text;
                drNewRow["Barcode"] = drDmBarcode["Barcode"];
                drNewRow["Ma_Vt"] = drDmBarcode["Ma_Vt"];
                drNewRow["Ma_VTri"] = drDmBarcode["Ma_VTri"];
                drNewRow["Ma_Kho"] = drDmBarcode["Ma_Kho"];
                drNewRow["Ten_Vt"] = drDmBarcode["Ten_Vt"];
                drNewRow["Dvt"] = drDmBarcode["Dvt"];
                drNewRow["So_Luong_DNX"] = dbSo_Luong_DNX;
                drNewRow["So_Luong"] = 1;
                drNewRow["Stt_Org"] = strStt_Org;
                drNewRow["Stt"] = strStt;

                drNewRow["Deleted"] = false;

                dtEditCt.Rows.Add(drNewRow);
                dtEditCt.AcceptChanges();
                return true;

            //}
                //}
            //}
            //else
            //{
            //        int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0") + 1);

       



            //        drNewRow["Stt0"] = iStt0;
            //        drNewRow["So_Ct"] = txtSo_Ct.Text;
            //        drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;
            //        drNewRow["Ma_Dt"] = txtMa_Dt.Text.Trim();
            //        drNewRow["Dien_Giai"] = txtDien_Giai.Text;
            //        drNewRow["Barcode"] = drDmBarcode["Barcode"];
            //        drNewRow["Ma_Vt"] = drDmBarcode["Ma_Vt"];
            //        drNewRow["Ma_VTri"] = drDmBarcode["Ma_VTri"];
            //        drNewRow["Ma_Kho"] = drDmBarcode["Ma_Kho"];
            //        drNewRow["Ten_Vt"] = drDmBarcode["Ten_Vt"];
            //        drNewRow["Dvt"] = drDmBarcode["Dvt"];
            //        drNewRow["So_Luong_DNX"] = dbSo_Luong_DNX;
            //        drNewRow["So_Luong"] = 1;
            //        drNewRow["Stt_Org"] = strStt_Org;
            //        drNewRow["Stt"] = strStt;

            //        drNewRow["Deleted"] = false;

            //        dtEditCt.Rows.Add(drNewRow);
            //        dtEditCt.AcceptChanges();
            //        return true;
            //}


           

		}
        private void ScaterMemvar_Voucher_Edit(DataRow drEditPh_Dest)
        {
            dteNgay_Ct.Text = Library.DateToStr(Convert.ToDateTime(drEditPh_Dest["Ngay_Ct"]));
            txtSo_Ct.Text = (string)drEditPh_Dest["So_Ct"];
            txtMa_Dt.Text = (string)drEditPh_Dest["Ma_Dt"];
            txtOng_Ba.Text = (string)drEditPh_Dest["Ong_Ba"];
            txtDien_Giai.Text = (string)drEditPh_Dest["Dien_Giai"];

            this.txtInfoInherit.Text = GetInfoInherit(this.strStt);
        }
        private string GetInfoInherit(string strStt)
        {
            //Hiển thị chứng từ gốc kế thừa
            string strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = Ma_Ct + ':' + So_Ct
					FROM R80PH 
					WHERE Ma_Ct = 'DNX' AND Stt IN (SELECT MAX(Stt_Org) FROM R05CTX_BARCODEPT WHERE Stt = '" + strStt + @"')
				SELECT @_InheritList";

            return SQLExec.ExecuteReturnValue(strSQLExec).ToString();
        }
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;
			string strFilter = "";

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

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
	



		bool Save()
        {
            
            if (txtOng_Ba.Text == "")
            {
                Common.MsgCancel("Vui lòng nhập tên người nhận!!!");
                return false;
            }
            if (txtInfoInherit.Text == "")
            {
                Common.MsgCancel("Vui lòng kiểm tra thông tin kế thừa chưa có thông tin!!!");
                return false;
            }
            //Kiểm tra trùng Stt
            if (this.enuNew_Edit_Voucher == enuEdit.New || this.enuNew_Edit_Voucher == enuEdit.Copy)
            {
                strStt = Common.GetNewStt("09", true);

                while (DataTool.SQLCheckExist("R05CTX_BARCODEPT", "Stt", strStt))
                {
                    strStt = Common.GetNewStt("09", true);
                }

               
            }
            
            //Cập nhật phần sửa dữ liệu trên PH
            foreach (DataRow dr in dtEditCt.Rows)
            {
                if (enuNew_Edit_Voucher == enuEdit.New)
                    dr["Create_log"] = Common.GetCurrent_Log();
                else if (enuNew_Edit_Voucher == enuEdit.Edit)
                    dr["LastModify_log"] = Common.GetCurrent_Log();

                Hashtable ht = new Hashtable();
                ht.Add("BARCODE", dr["Barcode"]);
                DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarcodePT", ht, CommandType.StoredProcedure);

                if (Convert.ToDouble(dr["So_Luong"]) > Convert.ToDouble(dtBarcode.Rows[0]["So_Luong"]) && enuNew_Edit_Voucher == enuEdit.New)
                {
                    Common.MsgCancel("Tồn tại barcode " + dr["Barcode"] + " số lượng xuất lớn hơn số lượng tồn " + dtBarcode.Rows[0]["So_Luong"] + "");
                    dr["So_Luong"] = dtBarcode.Rows[0]["So_Luong"];
                    return false;
                }
                else if (strStt_Org != "")
                {
                    //Số lượng DNX trên phiếu
                    double dbSo_Luong_DNX = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(So_Luong) FROM R04CTPO WHERE Ma_Ct = 'DNX' AND Stt = '" + strStt_Org + "' AND Ma_Vt = '" + dr["Ma_Vt"].ToString() + "'"));
                    //Tổng số lượng barcode xuất
                    double dbSo_Luong_Barcode = Common.SumDCValue(dtEditCt, "So_Luong", "Ma_Vt = '" + dr["Ma_Vt"].ToString() + "'");
                    double dbSo_Luong_Barcode_Old = 0;

                    if (DataTool.SQLCheckExist("R05CTX_BARCODEPT", new string[] { "Stt_Org", "Ma_Vt" }, new object[] { strStt_Org, dr["Ma_Vt"].ToString() }))
                        dbSo_Luong_Barcode_Old = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(So_Luong) FROM R05CTX_BARCODEPT WHERE Ma_Vt = '" + dr["Ma_Vt"].ToString() + "' AND Stt_Org = '" + strStt_Org + "'"));


                    // kiểm tra nếu SL barcode > DNX thì cảnh báo ko lưu
                    if (dbSo_Luong_Barcode + dbSo_Luong_Barcode_Old > dbSo_Luong_DNX)
                    {
                        Common.MsgCancel("Tồn tại VTPT " + dr["Ma_Vt"] + " số lượng xuất khác hơn số lượng DNX");
                        return false;
                    }
                    else if (dbSo_Luong_Barcode + dbSo_Luong_Barcode_Old < dbSo_Luong_DNX)
                    {
                        string strMsg = "Tồn tại VTPT " + dr["Ma_Vt"] + " số lượng xuất khác hơn số lượng DNX. Bạn có tiếp tục không?";

                        if (!Common.MsgYes_No(strMsg, "N"))
                            return false;
                        else
                            continue;

                    }
                }


                dr["Ma_Dt"] = txtMa_Dt.Text;
                dr["Ong_Ba"] = txtOng_Ba.Text;
                dr["Dien_Giai"] = txtDien_Giai.Text;
                dr["So_Ct"] = txtSo_Ct.Text;
                dr["Ngay_Ct"] = dteNgay_Ct.Text;


            }
            if (dtEditCt == null || dtEditCt.Rows.Count == 0) // sử dụng quét máy PDA
            {
                DataRow drNewRow = dtEditCt.NewRow();
				Common.SetDefaultDataRow(ref drNewRow);
				
                //bRow_First = true;

                drNewRow["Stt"] = strStt;
                drNewRow["Ma_Dt"] = txtMa_Dt.Text;
                drNewRow["Ong_Ba"] = txtOng_Ba.Text;
                drNewRow["Dien_Giai"] = txtDien_Giai.Text;
                drNewRow["So_Ct"] = txtSo_Ct.Text;
                drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;
                drNewRow["Stt_Org"] = strStt_Org;
                drNewRow["Create_log"] = Common.GetCurrent_Log();

                dtEditCt.Rows.Add(drNewRow);
                dtEditCt.AcceptChanges();
                
            }
            //Kiểm tra xem barcode có được chuyển sang kho lẻ bó nào không.Tránh trường hợp bị sai khi ngồi đợi lâu quá.
            string strListBarcode = string.Empty;

            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)enuNew_Edit_Voucher);
            sqlCom.Parameters.AddWithValue("@Stt", strStt);
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_CtX_BarcodePT";


            //TVP_CT
            paraCt.TypeName = "TVP_BARCODEPT";
            paraCt.Value = Voucher.GetTVPValue("R05CTX_BARCODEPT", "TVP_BARCODEPT", this.dtEditCt);
            sqlCom.Parameters.Add(paraCt);

            try
            {
                sqlCom.ExecuteNonQuery();
                cboSo_Ct.Text = txtSo_Ct.Text;


                //Update to PH
                this.FillData(txtSo_Ct.Text);

                if (cboSo_Ct.SelectedValue != null)
                    cboSo_Ct.SelectedValue = strStt;
                this.FillData_Voucher_Ph();

               
            }
            catch (Exception ex)
            {
                sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.Clear();
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                return false;
            }

            Common.MsgOk("Cập nhật thành công!");
            return true;
        }
        void btKiemKe_Click(object sender, EventArgs e)
        {
            frmKiemKeBarcodePT frm = new frmKiemKeBarcodePT();
            frm.Load();
        }
        void btReplace_Click(object sender, EventArgs e)
        {
            frmReplace_BarcodePT frm = new frmReplace_BarcodePT();
            frm.Load();
        }   
        void btNew_Click(object sender, EventArgs e)
        {
            FillData_Voucher_Ct();
            
            if(dtEditCt.Rows.Count != 0)
                dtEditCt.Clear();
            
            this.dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
            txtBarcode.ReadOnly = false;
            txtBarcode.Enabled = true;
            btSave_Voucher.Enabled = true;
            btInherit.Enabled = true;
            strStt = Common.GetNewStt("09", true);
            txtSo_Ct.Text = GetNewSo_Ct();
            txtMa_Dt.Text = lbtTen_Dt.Text = txtOng_Ba.Text = txtDien_Giai.Text = string.Empty;
            txtMa_Dt.ReadOnly = txtOng_Ba.ReadOnly = txtDien_Giai.ReadOnly = false;

            if (dgvEditCt.Columns.Contains("SO_LUONG"))
                dgvEditCt.Columns["SO_LUONG"].ReadOnly = false;
        }
        void btEdit_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.Edit;
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];
            txtBarcode.ReadOnly = false;
            txtBarcode.Enabled = true;
            btSave_Voucher.Enabled = true;
            txtMa_Dt.ReadOnly = txtOng_Ba.ReadOnly = txtDien_Giai.ReadOnly = false;


            if (dgvEditCt.Columns.Contains("SO_LUONG"))
                dgvEditCt.Columns["SO_LUONG"].ReadOnly = false;

        }
        void btPrint_Click(object sender, EventArgs e)
        {
            if (this.strStt != string.Empty)
                Voucher.PrintCtXBarcodePT(this.strStt, true, true);
        }
        private void Design()
        {
            string strReport_File = "rptCT_XBarcodePT";
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReport_File);
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            this.strStt = drCurrent["Stt"].ToString();
            if (Common.CheckPermission("XOABARCODEPT", enuPermission_Type.Allow_Access))
            {
                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                SQLExec.Execute("DELETE FROM R05CTX_BARCODEPT WHERE Stt = '" + strStt + "'");
                SQLExec.Execute("DELETE FROM R80PH_BARCODEPT WHERE Stt = '" + strStt + "'");
                bdsEditPh.RemoveAt(bdsEditPh.Position);
                bdsEditCt.RemoveAt(bdsEditCt.Position);
                dtEditCt.AcceptChanges();

                FillData();
            }
            else
                Common.MsgOk("Bạn không có quyền xóa phiếu");

        }
        private string GetNewSo_Ct()
        {
            string strSQL = @"SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(So_Ct)) AS BIGINT)), 0) FROM R05CTX_BARCODEPT WHERE YEAR(Ngay_Ct) = YEAR(GETDATE())";
            long iStt = Convert.ToInt64(SQLExec.ExecuteReturnValue(strSQL)) + 1;
            string So_Ct = iStt.ToString().Trim().PadLeft(6, '0');
            return So_Ct;
        }

     
		

		#region Event
		

		void txtBarcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
              
				this.txtBarcode.Focus();
				this.txtBarcode.Select(0, txtBarcode.Text.Length);
				string strBarcode = txtBarcode.Text.Trim();
                
                if (strBarcode.Length > 10)
                    strBarcode = strBarcode.Substring(3,10);

				txtBarcode.Text = strBarcode;

				//Check exists Barcode
				if (!DataTool.SQLCheckExist("R81DMBARCODEPT", "Barcode", strBarcode))
				{
					Common.MsgCancel("Bạn nhập mã vạch {" + strBarcode + "} không tồn tại!");
					txtBarcode.BackColor = Color.Red;
					txtBarcode.Select(0, txtBarcode.Text.Length);
					txtBarcode.Focus();
				}
				else
				{
                    string strSQLExec = string.Empty;
                 
                    Hashtable ht = new Hashtable();
                    ht.Add("BARCODE", txtBarcode.Text);
                    DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarcodePT", ht, CommandType.StoredProcedure);
                    if (dtBarcode.Rows.Count == 0)
                        Common.MsgCancel("Vật tư của barcode {" + strBarcode + "} đã được xuất hết.");
                    else
                    {
                        DataRow drBarcode = dtBarcode.Rows[0];
                        if (!Check_Barcode(drBarcode["Ma_Vt"].ToString()))
                            Common.MsgCancel("Vật tư của barcode {" + strBarcode + "} không tồn tại trong đề nghị xuất.");
                      
                        else
                        {
                            if (AddRowBarcode(dtBarcode))
                            {
                                this.txtBarcode.Focus();
                                this.txtBarcode.Select(0, txtBarcode.Text.Length);
                                this.txtBarcode.BackColor = SystemColors.Window;
                                this.txtBarcode.Text = string.Empty;
                            }
                        }
                        
                    }
				}
			}
		}

		

		void txtBarcode_LostFocus(object sender, EventArgs e)
		{
			txtBarcode.BackColor = SystemColors.Window;
			txtBarcode.Text = string.Empty;

		}

		void btSave_Voucher_Click(object sender, EventArgs e)
		{
            if (Save())
            {
                this.txtBarcode.Text = string.Empty;
                this.btSave_Voucher.Enabled = false;
                this.btInherit.Enabled = false;
                this.txtBarcode.Enabled = false;
                this.txtBarcode.ReadOnly = true;
            }
            
		}
		
		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "SO_LUONG,SO_LUONG_DNX,SO_LUONG_CL"))
                drCurrent["So_Luong_CL"] = Convert.ToDouble(drCurrent["So_Luong_DNX"]) - Convert.ToDouble(drCurrent["So_Luong"]);
            if (Common.Inlist(strColumnName, "SO_LUONG"))
            {
                Hashtable ht = new Hashtable();
                ht.Add("BARCODE", drCurrent["Barcode"]);
                DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarcodePT", ht, CommandType.StoredProcedure);
               if(dtBarcode.Rows.Count > 0)
               {
                DataRow drBarcode = dtBarcode.Rows[0];
                if (Convert.ToDouble(drBarcode["So_Luong"]) <= 0)
                {
                    Common.MsgCancel("Vật tư của barcode {" + drCurrent["Barcode"] + "} đã được xuất hết.");
                   
                }
                else if (Convert.ToDouble(drBarcode["So_Luong"]) < Convert.ToDouble(drCurrent["So_Luong"]))
                {
                    Common.MsgCancel("Vật tư của barcode {" + drCurrent["Barcode"] + "} không được xuất quá số lượng tồn.");
                    drCurrent["So_Luong"] = drBarcode["So_Luong"];
                }
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

            if (cboSo_Ct.SelectedValue != null)
                this.cboSo_Ct.SelectedValue = this.strStt;
		}

		void btLast_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			this.bdsEditPh.MoveLast();
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboSo_Ct.SelectedValue != null)
                this.cboSo_Ct.SelectedValue = this.strStt;
		}

		void btNext_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			if (this.bdsEditPh.Position + 1 < this.bdsEditPh.Count)
			{
				this.bdsEditPh.MoveNext();
                this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

                if (cboSo_Ct.SelectedValue != null)
                    this.cboSo_Ct.SelectedValue = this.strStt;
			}
		}

        void btFirst_Click(object sender, EventArgs e)
        {
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MoveFirst();

            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboSo_Ct.SelectedValue != null)
                this.cboSo_Ct.SelectedValue = this.strStt;

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
        void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

           if (Common.Inlist(strColumnName, "SO_LUONG,SO_LUONG_DNX,SO_LUONG_CL"))
                drCurrent["So_Luong_CL"] = Convert.ToDouble(drCurrent["So_Luong_DNX"]) - Convert.ToDouble(drCurrent["So_Luong"]);
        }
        void dgvEditCt_Validated(object sender, EventArgs e)
        {
            
        }
	
		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{
				case Keys.F9:
					this.btRefresh_Click(null, null);
					return;

                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            Design();
                            break;
                    }
                    return;
				case Keys.F12:
					if (e.Modifiers == Keys.Control)
						base.OnKeyDown(e);
				
					return;

			    
			}

			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
                //if (!Common.CheckPermission("ACCESS_FILTER_DT_TCB", enuPermission_Type.Allow_Access))
                //    dteNgay_Ct1.Enabled = dteNgay_Ct2.Enabled = false;

                //this.btEdit.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
			}

		}

	}
}
