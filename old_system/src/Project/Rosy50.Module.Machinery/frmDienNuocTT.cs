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
using RosyList;
using RosySystem;
using RosySystem.Library;
using RosySystem.Element;
using System.Collections;
using System.Data.SqlClient;

namespace RosyModule.Machinery
{
	public partial class frmDienNuocTT : RosySystem.Customize.frmView
	{
        DataSet dsDienNuocTT;
		DataTable dtDien;
		BindingSource bdsDien = new BindingSource();

        DataTable dtNuoc;
        BindingSource bdsNuoc = new BindingSource();


        DataTable dtMaSoCon;
        BindingSource bdsMaSoCon = new BindingSource();

        DataTable dtCtPB;
        BindingSource bdsCtPB = new BindingSource();

        DateTime dteNgay_Ct1; //THÁNG NÀY
        DateTime dteNgay_Ct2; //THÁNG sau
		DataRow drCurrent;
        string strLoai_Ct;
        string strReportFile = "rptCT_BTKH";
        bool bNew;

        object objActive = null;

        public frmDienNuocTT()
		{
			InitializeComponent();
		
			this.btExit.Click += new EventHandler(btExit_Click);
            //this.btCopy.Click += new EventHandler(btCopy_Click);
            //this.btPrint.Click += new EventHandler(btPrint_Click);
            //this.btSave.Click += new EventHandler(btSave_Click);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btNewGia.Click += new EventHandler(btNewGia_Click);
           

            dgvDien.KeyDown += new KeyEventHandler(dgvKHVTPKTDT_KeyDown);
            
            //numThang.TextChanged += new EventHandler(numNam_LostFocus);
            dgvDien.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDien_CellValidating);
            dgvNuoc.CellValidating += new DataGridViewCellValidatingEventHandler(dgvNuoc_CellValidating);
            dgvMaSoCon.CellValidating += new DataGridViewCellValidatingEventHandler(dgvMaSoCon_CellValidating);
            chkDuyet_KTDT.CheckedChanged += new EventHandler(chkDuyet_KTDT_CheckedChanged);

            dgvDien.Enter += new EventHandler(dgvDien_Enter);
            dgvNuoc.Enter += new EventHandler(dgvNuoc_Enter);
		}

       
     

		new public void Load()
		{
            //int iThang = Convert.ToInt16(SQLExec.ExecuteReturnValue("SELECT ISNULL(MONTH(MAX(Ngay_Ct)),1) FROM R11DIENNUOCTT WHERE YEAR(Ngay_Ct) = " + Element.sysWorkingYear + ""));
             
            //numThang.Value = iThang;

            //dteNgay_Ct1 = Common.GetDate(Element.sysWorkingYear, Convert.ToInt16(this.numThang.Value), 1).AddMonths(1).AddDays(-1);
            if (rdbDien.Checked == true)
                strLoai_Ct = "DIEN";
            else
                strLoai_Ct = "NUOC";
            string strNgay =  SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM R11DIENNUOCTT WHERE YEAR(Ngay_Ct) <= " + Element.sysWorkingYear + "").ToString();
            
            if(strNgay == null || strNgay == "")
                dteNgay_Ct1 = Convert.ToDateTime("31/01/+" + Element.sysWorkingYear + "");
            else
                dteNgay_Ct1 = Convert.ToDateTime(strNgay);
           dteNgay_Ct.Text = dteNgay_Ct1.ToString();


            this.Build();
            FillData(dteNgay_Ct1);
			this.BindingLanguage();
            chkDuyet_KTDT.Checked = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_PKTCDAT FROM R11DIENNUOCTT WHERE NGAY_CT = '"+ Library.DateToStr(dteNgay_Ct1) +"'"));
            //PHÂN QUYỀN
            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
            {
                //btCopy.Enabled = false;
                btDelete.Enabled = false;
                chkDuyet_KTDT.Enabled = false;

            }
            else
            { bNew = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New); chkDuyet_KTDT.Enabled = true; }

            ShowData();
			this.Show();
		}

		private void Build()
		{
            
			dgvDien.strZone = "DIENTIEUTHU";
			dgvDien.BuildGridView();

            dgvNuoc.strZone = "NUOCTIEUTHU";
            dgvNuoc.BuildGridView();

            dgvMaSoCon.strZone = "DIENNUOCMS";
            dgvMaSoCon.BuildGridView();

            dgvCtPB.strZone = "DIENNUOCCTBP";
            dgvCtPB.BuildGridView();

            dgvDien.ReadOnly = false;
            dgvMaSoCon.ReadOnly = false;
            dgvNuoc.ReadOnly = false;
            if (!Element.sysIs_Admin)
            {
                dgvNuoc.Columns["Ma_So"].ReadOnly = false;
                dgvDien.Columns["Ma_So"].ReadOnly = false;
                dgvNuoc.Columns["Tieu_Thu_CL"].ReadOnly = false;
            }
            //foreach (DataGridViewColumn dgvc in dgvDien.Columns)
            //    dgvc.ReadOnly = true;
           
           
           
		}
        private void ShowData()
        {
            if (rdbDien.Checked == true)
            {
                rdbNuoc.Checked = false;
                dgvNuoc.Visible = false;
                dgvDien.Visible = true;
            }
            else if (rdbNuoc.Checked == true)
            {
                rdbDien.Checked = false;
                dgvDien.Visible = false;
                dgvNuoc.Visible = true;
            }

            dgvDien.Columns["Chi_Tieu"].HeaderText = "Vị trí đo điếm";
            dgvDien.Columns["Tieu_Thu"].HeaderText = "Tiêu thụ trong kỳ (Kwh)";
            dgvDien.Columns["Tieu_Thu_QD"].HeaderText = "Tiêu thụ quy đổi theo công tơ điện lực (Kwh)";
            dgvDien.Columns["So_Dau"].HeaderText = "Chỉ số đầu kỳ";
            dgvDien.Columns["So_Cuoi"].HeaderText = "Chỉ số cuối kỳ";
            dgvDien.Columns["So_Luong"].HeaderText = "Sản lượng sản xuất";


            dgvNuoc.Columns["Chi_Tieu"].HeaderText = "Vị trí đo điếm";
            dgvNuoc.Columns["Tieu_Thu"].HeaderText = "Tiêu thụ (m3)";
            dgvNuoc.Columns["Tieu_Thu_QD"].HeaderText = "Tiêu thụ quy đổi (m3)";
            dgvNuoc.Columns["So_Dau"].HeaderText = "Chỉ số đầu kỳ";
            dgvNuoc.Columns["So_Cuoi"].HeaderText = "Chỉ số cuối kỳ";
            dgvNuoc.Columns["So_Seri"].HeaderText = "Loại công tơ - danh số/Số Seri";
            dgvNuoc.Columns["So_Luong"].HeaderText = "Sản lượng sản xuất";

            if(dgvCtPB.Columns.Contains("TTieu_Thu_QD"))
                dgvCtPB.Columns["TTieu_Thu_QD"].HeaderText = "Kết quả phân bổ";
            if (dgvCtPB.Columns.Contains("Cong_Thuc_KV"))
                dgvCtPB.Columns["Cong_Thuc_KV"].HeaderText = "Khu Vực";
            if (dgvCtPB.Columns.Contains("Tieu_Thu_QD"))
                dgvCtPB.Columns["Tieu_Thu_QD"].HeaderText = "Tiêu thụ";
        }

		private void FillData(DateTime dtNgay)
		{

            DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM R11DIENNUOCTT WHERE Ngay_Ct = '" + Library.DateToStr(dtNgay) + "'");
            if (dt.Rows.Count == 0)
            {
                if (Common.MsgYes_No("Dữ liệu tại ngày " + Library.DateToStr(dtNgay) + " không tồn tại. Bạn có muốn copy dữ liệu không?", "Y"))
                {
                    //LẤY NGÀY CUỐI THÁNG
                    DateTime dteNgay_Ct2 = Library.StrToDate(dteNgay_Ct.Text);//Voucher.GetLastDayOfMonth(Element.sysWorkingYear, Convert.ToInt16(this.numThang.Value));
                    ////THÁNG NÀY
                    //DateTime dteNgay_Ct1 = Voucher.GetLastDayOfMonthBefore(Element.sysWorkingYear, Convert.ToInt16(this.numThang.Value));
                    string strExec = "SELECT MAX(Ngay_Ct) FROM R11DIENNUOCTT WHERE Ngay_Ct <=  '" + dteNgay_Ct2.ToShortDateString() + "'";
                    DateTime dteNgay_Ct1 = Convert.ToDateTime(SQLExec.ExecuteReturnValue(strExec));
                    Copy(dteNgay_Ct1, dteNgay_Ct2);

                    //dtNgay = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM R11DIENNUOCTT WHERE YEAR(Ngay_Ct) = " + Element.sysWorkingYear + ""));
                    //numThang.Value = dtNgay.Month;
                }
                //else//NẾU KO COPY THÌ ĐỂ TRỐNG
                //{
                   
                //    dtNgay = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM R11DIENNUOCTT WHERE YEAR(Ngay_Ct) = " + Element.sysWorkingYear + " - 1"));
                //    //numThang.Value = dtNgay.Month;
                //}
                
            }
            
            dtNgay = Library.StrToDate(dteNgay_Ct.Text);
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT", dtNgay.ToShortDateString());
            dsDienNuocTT = SQLExec.ExecuteReturnDs("sp_GetDienNuocTT", ht, CommandType.StoredProcedure);
            
            dtDien = dsDienNuocTT.Tables[0];
            bdsDien.DataSource = dtDien;
            dgvDien.DataSource = bdsDien;
            
            dtNuoc = dsDienNuocTT.Tables[1];
            bdsNuoc.DataSource = dtNuoc;
            dgvNuoc.DataSource = bdsNuoc;

            dtMaSoCon = dsDienNuocTT.Tables[2];
            bdsMaSoCon.DataSource = dtMaSoCon;
            dgvMaSoCon.DataSource = bdsMaSoCon;

            dtCtPB = dsDienNuocTT.Tables[3];
            bdsCtPB.DataSource = dtCtPB;
            dgvCtPB.DataSource = bdsCtPB;

            bdsSearch = bdsDien;
            ExportControl = dgvDien;

            ShowData();
		}


        private void Copy(DateTime dteNgay_Ct1, DateTime dteNgay_Ct2)
        {            
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1);
            ht.Add("NGAY_CT2", dteNgay_Ct2);
            ht.Add("CREATE_LOG", DataTool.GetCurrent_Log());
            if (SQLExec.Execute("sp_CopyDienNuocTT", ht, CommandType.StoredProcedure))
            {

                //this.numThang.Value = dteNgay_Ct2.Month;

                Common.MsgOk("Dữ liệu tại ngày " + Library.DateToStr(dteNgay_Ct2) + " đã được tạo.");
                FillData(dteNgay_Ct2);       
            }
        }

        private bool printDetail_Tb(bool bPreview)
        {
            //if (bdsDien.Position < 0)
            //    return false;
            
            //frmIn_KHTBDK frm = new frmIn_KHTBDK();
            //frm.Load();

            //if (frm.rdbKHBTTB.Checked == true)
            //    strReportFile = "rptCT_BTKH";
            //else
            //    strReportFile = "rptCT_KQBTKH";

            //DataRow drKHVTPKTDT = ((DataRowView)bdsDien.Current).Row;
          
            //DataTable dtHeader = new DataTable();
            //DataTable dtDetail = new DataTable();

            //Hashtable ht = new Hashtable();
            //ht.Add("SO_CT", cboDot_BT.Text);
            //ht.Add("NAM", numThang.Value);
            //ht.Add("USER_PRINT", Element.sysUser_Id);

            //DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintKHBTDK", ht, CommandType.StoredProcedure);
            //dtHeader = ds.Tables[0];
            //dtDetail = ds.Tables[1];

            //if (!dtDien.Columns.Contains("NGAY_CT"))
            //    dtDien.Columns.Add("NGAY_CT", typeof(DateTime));

            //if (!dtDien.Columns.Contains("REPORT_FILE"))
            //    dtDien.Columns.Add("REPORT_FILE", typeof(string));

            //drKHVTPKTDT["REPORT_FILE"] = strReportFile;
            //drKHVTPKTDT["NGAY_CT"] = Element.sysNgay_Ct1;
           
            //RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            //return frmPrint.Load(drKHVTPKTDT, dtDetail, bPreview, true);
            return true;          
        }
        private void Design()
        {
            //frmIn_KHTBDK frm = new frmIn_KHTBDK();
            //frm.Load();

            //if(frm.rdbKHBTTB.Checked ==  true)
            //    strReportFile = "rptCT_BTKH";
            //else
            //    strReportFile = "rptCT_KQBTKH";
            //RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            //frmDesign.Load(strReportFile);
        }
      
        void dgvKHVTPKTDT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            this.Design();
                            break;
                    }
                    break;
              }
        }
        void dgvMaSoCon_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex < 0)
                return;

            drCurrent = ((DataRowView)bdsMaSoCon.Current).Row;
            string strColName = dgvMaSoCon.Columns[e.ColumnIndex].Name;
            
            string strLastModify_Log = Common.GetCurrent_Log();
            if (dgvMaSoCon.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode) //!dgvBarcode.Columns[strColName].ReadOnly && Common.Inlist(strColName, "SO_LUONG,NUM_BARS"))
            {
               
                string strSQL = "UPDATE R11DIENNUOCTT SET " + strColName + " = @Value, LastModify_Log = @LastModify_Log WHERE Ident00 = @Ident00";
                Hashtable htPara = new Hashtable();
                htPara["IDENT00"] = drCurrent["Ident00"];
                htPara["VALUE"] = (Object)Voucher.GetTypeOfTable("R11DIENNUOCTT", strColName, e.FormattedValue.ToString());
                htPara["LASTMODIFY_LOG"] = strLastModify_Log;
                    
                if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
                {
                    drCurrent["LastModify_Log"] = strLastModify_Log;
                    drCurrent[strColName] = e.FormattedValue;

                }
                
            }

        }

        void dgvNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex < 0)
                return;

            if (!bNew)
                return;

            drCurrent = ((DataRowView)bdsNuoc.Current).Row;
            string strColName = dgvNuoc.Columns[e.ColumnIndex].Name;
            if (dgvNuoc.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode) //!dgvBarcode.Columns[strColName].ReadOnly && Common.Inlist(strColName, "SO_LUONG,NUM_BARS"))
            {
                if (drCurrent.Table.Columns.Contains("Duyet_PKTCDAT"))
                {
                    if (Convert.ToBoolean(drCurrent["Duyet_PKTCDAT"]))
                    {
                        Common.MsgCancel("Dữ liệu đã được PKTDT duyệt không cho phép sửa!!!");
                        e.Cancel = true;
                        return;
                    }
                }
                string strLastModify_Log = Common.GetCurrent_Log();
                drCurrent[strColName] = e.FormattedValue;
               
                
                string strSQL = "UPDATE R11DIENNUOCTT SET " + strColName + " = @Value, LastModify_Log = @LastModify_Log WHERE Ident00 = @Ident00";
                Hashtable htPara = new Hashtable();
                htPara["IDENT00"] = drCurrent["Ident00"];
                htPara["VALUE"] = (Object)Voucher.GetTypeOfTable("R11DIENNUOCTT", strColName, e.FormattedValue.ToString());
                htPara["LASTMODIFY_LOG"] = strLastModify_Log;
                if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
                {
                    drCurrent["LastModify_Log"] = strLastModify_Log;
                    CalTien(dtNuoc, drCurrent);
                }
               

            }

        }
        void dgvDien_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex < 0)
                return;

            if (!bNew)
                return;

            drCurrent = ((DataRowView)bdsDien.Current).Row;

            string strColName = dgvDien.Columns[e.ColumnIndex].Name;
            if (dgvDien.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode) //!dgvBarcode.Columns[strColName].ReadOnly && Common.Inlist(strColName, "SO_LUONG,NUM_BARS"))
            {
                if (drCurrent.Table.Columns.Contains("Duyet_PKTCDAT"))
                {
                    if (Convert.ToBoolean(drCurrent["Duyet_PKTCDAT"]))
                    {
                        Common.MsgCancel("Dữ liệu đã được PKTDT duyệt không cho phép sửa!!!");
                        e.Cancel = true;
                        return;
                    }
                }
                string strLastModify_Log = Common.GetCurrent_Log();
                drCurrent[strColName] = e.FormattedValue;
                //drCurrent["Tieu_Thu"] = (Convert.ToDouble(drCurrent["So_Cuoi"]) - Convert.ToDouble(drCurrent["So_Dau"])) * Convert.ToDouble(drCurrent["HSN"]);

                string strSQL = "UPDATE R11DIENNUOCTT SET " + strColName + " = @Value, LastModify_Log = @LastModify_Log WHERE Ident00 = @Ident00";
                Hashtable htPara = new Hashtable();
                htPara["IDENT00"] = drCurrent["Ident00"];
                htPara["VALUE"] = (Object)Voucher.GetTypeOfTable("R11DIENNUOCTT", strColName, e.FormattedValue.ToString());
                htPara["LASTMODIFY_LOG"] = strLastModify_Log;
                if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
                {
                    drCurrent["LastModify_Log"] = strLastModify_Log;
                    CalTien(dtDien, drCurrent);
                }
                
                
               
            }

        }
        private void CalTien(DataTable dtCal, DataRow drCal)
        {
            // GIÁ TRỊ NÀY KO LƯU MÀ CHỈ TÍNH TOÁN
            drCal["Tieu_Thu_QD"] = (Convert.ToDouble(drCal["Tieu_Thu"]) * Convert.ToDouble(drCal["HSQD"])) + Convert.ToDouble(drCal["Tieu_Thu_CL"]);
            drCal["Tien"] = Convert.ToDouble(drCal["Tieu_Thu_QD"]) * Convert.ToDouble(drCal["Gia"]);
           

        }
        void btPrint_Click(object sender, EventArgs e)
        {
            //this.printDetail_Tb(true);
        }
        //void btSave_Click(object sender, EventArgs e)
        //{
        //    dteNgay_Ct1 = Common.GetDate(Element.sysWorkingYear, Convert.ToInt16(this.numThang.Value), 1).AddMonths(1).AddDays(-1);
        //    Hashtable ht = new Hashtable();

        //    ht.Add("NGAY_CT", dteNgay_Ct1);
        //    ht.Add("LOAI_CT", rdbDien.Checked ? "DIEN":"NUOC");
        //    SQLExec.Execute("sp_UpdateTongDienNuoc",ht,CommandType.StoredProcedure);
        //    FillData(dteNgay_Ct1);
        //}
        void btDelete_Click(object sender, EventArgs e)
        {
            dteNgay_Ct1 = Library.StrToDate(dteNgay_Ct.Text);// Common.GetDate(Element.sysWorkingYear, Convert.ToInt16(this.numThang.Value), 1).AddMonths(1).AddDays(-1);
             
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT", dteNgay_Ct1);
            DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM R11DIENNUOCTT WHERE Duyet_PKTCDAT = 1 AND Ngay_Ct = @Ngay_Ct", ht, CommandType.Text);
            if (dt.Rows.Count > 0)
                Common.MsgOk("Dữ liệu đã được PKTDT duyệt không được xóa!!!");
            else
            {
                if(SQLExec.Execute("DELETE FROM R11DIENNUOCTT WHERE Ngay_Ct = @Ngay_Ct", ht, CommandType.Text))
                    Common.MsgOk("Bạn đã xóa dữ liệu tại ngày '" + Library.DateToStr(dteNgay_Ct1) + "'");
            }
        }
        void btUpdate_KQ_Click(object sender, EventArgs e)
        {
            //bool bDuyet_GD = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select Duyet_GiamDoc FROM R06KHBTDK WHERE So_Ct = '" + cboDot_BT.Text + "' GROUP BY Duyet_GiamDoc"));
            //if (bDuyet_GD)
            //{
            //    string strUpdate = "UPDATE R06KHBTDK SET Is_Ht = 1 FROM R06KHBTDK T1 JOIN (SELECT Stt, Stt0 FROM R06CT_BTTB WHERE Ma_Ct = 'BTTT' AND Tinh_Trang <> '') T2 ON T1.Stt_Org = T2.Stt AND T1.Stt0_Org = T2.Stt0 WHERE T1.So_Ct = '" + cboDot_BT.Text +"'";
            //    SQLExec.Execute(strUpdate);

            //    if (dgvDien.Columns.Contains("GHI_CHU_KQ"))
            //        dgvDien.Columns["GHI_CHU_KQ"].ReadOnly = false;
            //    bUpdateKQ = true;
            //    FillData();
            //}
            //else
            //    Common.MsgOk("Phiếu chưa được giám đốc duyệt");

        }
        void dgvNuoc_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNuoc;
        }

        void dgvDien_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvDien;
        }

        void chkDuyet_KTDT_CheckedChanged(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_PKTCDAT FROM R11DIENNUOCTT WHERE Ngay_Ct = '" + Library.DateToStr(dteNgay_Ct1) + "'")) == false && chkDuyet_KTDT.Checked == true)
            {
                if (Common.MsgYes_No("Bạn có muốn khóa dữ liệu ngày " + Library.DateToStr(dteNgay_Ct1) + " không???", "Y"))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("NGAY_CT", dteNgay_Ct1);
                    SQLExec.Execute("UPDATE R11DIENNUOCTT SET Duyet_PKTCDAT = 1, Duyet_PKTCDAT_Log = '" + Common.GetCurrent_Log() + "' WHERE Ngay_Ct = @Ngay_Ct", ht,CommandType.Text);
                    Hashtable ht1 = new Hashtable();
                    ht1.Add("NGAY_CT", dteNgay_Ct1.AddDays(1));
                    SQLExec.Execute("UPDATE R11DIENNUOCTTCT SET Lock = 1 WHERE Ngay_Ct <= @Ngay_Ct ",ht1, CommandType.Text);
                }
            }
            else
            {
                if (Common.MsgYes_No("Bạn có muốn mở khóa dữ liệu ngày " + Library.DateToStr(dteNgay_Ct1) + " không???", "Y"))
                {
                    SQLExec.Execute("UPDATE R11DIENNUOCTT SET Duyet_PKTCDAT = 0, Duyet_PKTCDAT_Log = '" + Common.GetCurrent_Log() + "' WHERE Ngay_Ct = '" + Library.DateToStr(dteNgay_Ct1) + "' ");
                    SQLExec.Execute("UPDATE R11DIENNUOCTTCT SET Lock = 0 WHERE Ngay_Ct <= '" + Library.DateToStr(dteNgay_Ct1.AddDays(1)) + "' ");
                }
            }
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            dteNgay_Ct1 = Library.StrToDate(dteNgay_Ct.Text); //Common.GetDate(Element.sysWorkingYear, Convert.ToInt16(this.numThang.Value), 1).AddMonths(1).AddDays(-1);
            FillData(dteNgay_Ct1);
        }

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
        void btNewGia_Click(object sender, EventArgs e)
        {
            RosyList.frmDmType frm = new RosyList.frmDmType();
            frm.Load("DIENNUOC");
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    if (dgvCtPB.Visible == false)
                    {
                        dgvCtPB.Visible = true;
                        dgvDien.Visible = false;
                        dgvNuoc.Visible = false;
                    }
                    else
                    {
                        dgvCtPB.Visible = false;

                        if (rdbDien.Checked)
                        {
                            dgvDien.Visible = true;
                            dgvNuoc.Visible = false;
                        }
                        else if (rdbNuoc.Checked)
                        {
                            dgvDien.Visible = false;
                            dgvNuoc.Visible = true;
                        }
                    }
                    break;  
                case Keys.F4:
                    if (dgvMaSoCon.Visible == false)
                    {
                        dgvMaSoCon.Visible = true;
                        dgvDien.Visible = false;
                        dgvNuoc.Visible = false;
                    }
                    else
                    {
                        dgvMaSoCon.Visible = false;

                        if (rdbDien.Checked)
                        {
                            dgvDien.Visible = true;
                            dgvNuoc.Visible = false;
                        }
                        else if (rdbNuoc.Checked)
                        {
                            dgvDien.Visible = false;
                            dgvNuoc.Visible = true;
                        }
                    }
                    return;
            }
        }
        
	}
}
