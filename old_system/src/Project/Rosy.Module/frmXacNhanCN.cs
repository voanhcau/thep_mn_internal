using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using RosySystem;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Common;


namespace RosyModule
{
	public partial class frmXacNhanCN : RosySystem.Customize.frmView
	{
		DataTable dtThanhToan;
		DataTable dtHanTt;
       
		BindingSource bdsThanhToan = new BindingSource();
		BindingSource bdsHanTt = new BindingSource();

        BindingSource bdsExportExcel = new BindingSource();
        //RosySystem.Control.rsDataGridView dgvExportExcel = new RosySystem.Control.rsDataGridView();

		public frmVoucher_Edit frmEditCt;
		public string strStt = string.Empty;
        string strReportFile = string.Empty;
        string strTk_List = "";

        DataRow drCurent;
		#region Contructor

        public frmXacNhanCN()
		{
			InitializeComponent();
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);

            dteNgay_Ct.LostFocus += new EventHandler(dteNgay_Ct_LostFocus);


            dgvHanTt.GotFocus+=new EventHandler(dgvHanTt_GotFocus);
            dgvHanTt.KeyDown += new KeyEventHandler(dgvHanTt_KeyDown);
            dgvHanTt.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvHanTt_CellMouseClick);

            this.rdbMau1.CheckedChanged += new EventHandler(rdbMau1_CheckedChanged);
            this.rdbMau2.CheckedChanged += new EventHandler(rdbMau1_CheckedChanged);
            this.rdbMau3.CheckedChanged += new EventHandler(rdbMau1_CheckedChanged);

            this.btPrint.Click += new EventHandler(btPrint_Click);
            this.btPreview.Click += new EventHandler(btPreview_Click);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);
            this.btSendMail.Click += new EventHandler(btSendMail_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
            btBrower.Click += new EventHandler(btBrower_Click);
		}

		new public void Load()
		{
            dteNgay_Ct.Text = Library.DateToStr(Element.sysNgay_Ct2);

            txtTen_Kt.Text = Parameters.GetParaValue("KTOANTRUONG").ToString();
            txtTen_Gd.Text = Parameters.GetParaValue("TGDOC").ToString();

            XuLyNgay();
            LoadCombo();
			Build();

            FillThanhToanFromCongNo();

			BindingLanguage();

            dteNgay_Ct.Focus();

		
			this.Show();
			
		}
        private void XuLyNgay()
        {
            dteNgay_Gui.Text = Library.DateToStr(Library.StrToDate(dteNgay_Ct.Text).AddDays(3));
            dteNgay_Ph.Text = Library.DateToStr(Library.StrToDate(dteNgay_Gui.Text).AddDays(7));
        }
        

		public void Load(frmVoucher_Edit frmEditCt)
		{
			this.frmEditCt = frmEditCt;

			this.Load();
		}

		#endregion

		#region Method

		private void Build()
		{
			
			dgvHanTt.ReadOnly = false;
			dgvHanTt.strZone = "SODUCN";
			dgvHanTt.BuildGridView();


            dgvExportExcel_1.strZone = "SODUCNCT1";
            dgvExportExcel_1.BuildGridView();

            dgvExportExcel_2.strZone = "SODUCNCT2";
            dgvExportExcel_2.BuildGridView();

            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt.strLookupKeyFilter = "Ngay_End = '19000101'";
		}

		private void FillThanhToanFromCongNo()
		{
			if (dteNgay_Ct.IsNull )
				return;

			
			Hashtable htParameter = new Hashtable();

			htParameter.Add("NGAY_CT2", Library.StrToDate(this.dteNgay_Ct.Text));
            htParameter.Add("TK_LIST", strTk_List);
            htParameter.Add("MA_DT", "");
            htParameter.Add("MEMBER_ID", cboMember_ID.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

            dtHanTt = SQLExec.ExecuteReturnDt("sp_GetXacNhanCN", htParameter, CommandType.StoredProcedure);

            if (txtMa_Dt.Text != "" && dtHanTt.Select("Ma_Dt = '" + txtMa_Dt.Text + "'").Length == 0)
            {
                if (dtHanTt.Rows.Count == 0)
                {
                    Hashtable htParameter1 = new Hashtable();

                    htParameter1.Add("NGAY_CT2", Library.StrToDate(this.dteNgay_Ct.Text));
                    htParameter1.Add("TK_LIST", "244");
                    htParameter1.Add("MA_DT", txtMa_Dt.Text);
                    htParameter1.Add("MA_DVCS", Element.sysMa_DvCs);

                    dtHanTt = SQLExec.ExecuteReturnDt("sp_GetXacNhanCN", htParameter1, CommandType.StoredProcedure);
                }
                DataRow drEditCtNew = dtHanTt.NewRow();
                //Common.CopyDataRow(dtHanTt.Rows[0], drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);

                drEditCtNew["Ma_Dt"] = txtMa_Dt.Text;
                drEditCtNew["Tk_List"] = "131,138,331,338,344,244";
                drEditCtNew["Ten_Dt"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text);
                dtHanTt.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();

                //bdsHanTt.DataSource = dtHanTt;
            }
           
            bdsHanTt.DataSource = dtHanTt;
            dgvHanTt.DataSource = bdsHanTt;
			
		}
        private void LoadCombo()
        {
            DataTable dt = SQLExec.ExecuteReturnDt("SELECT  '' AS MEMBER_ID UNION ALL SELECT MEMBER_ID FROM R81DMDT_XNCN GROUP BY MEMBER_ID");
            Voucher.LoadCombo(cboMember_ID, dt, "Member_ID");
        }
        void dteNgay_Ct_LostFocus(object sender, EventArgs e)
        {
            XuLyNgay();
        }

        void btSendMail_Click(object sender, EventArgs e)
        {
            
            // bước 1: tạo file PDF, excel
            
            //bước 2 : send email
            string strFilePath = string.Empty;
            if (rdbMau1.Checked == true)
            {
                
                strFilePath = Path.Combine(txtPath.Text, "MAU_1");
              

            }
            else if (rdbMau2.Checked == true)
            {

                strFilePath = Path.Combine(txtPath.Text, "MAU_2");
              
            }


            frmSendMailXNCN frm = new frmSendMailXNCN();
            frm.Load(strFilePath);
        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillThanhToanFromCongNo();
        }

        void btPreview_Click(object sender, EventArgs e)
        {
            this.print(true);
        }

        void btPrint_Click(object sender, EventArgs e)
        {
           
            this.print(false);
        }

        void btBrower_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;

            //folderBrowserDialog.
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;


            txtPath.Text = folderBrowserDialog.SelectedPath;
        }
		#endregion

		#region Event



        ////Gắn đối tượng tìm kiếm
        void dgvHanTt_GotFocus(object sender, EventArgs e)
        {
            //this.ExportControl = dgvExportExcel;
            this.bdsSearch = bdsThanhToan;
        }

        private void Design()
        {
         
            if (rdbMau1.Checked == true)
                strReportFile = "rptXNCNMau1";
            else if (rdbMau2.Checked == true)
                strReportFile = "rptXNCNMau2";
            else if (rdbMau3.Checked == true)
                strReportFile = "rptXNCNMau3";
          
            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }
        private bool print(bool bPreview)
        {
            if (bdsHanTt.Position < 0 && txtMa_Dt.Text == "")
                return false;

            if (rdbMau1.Checked == true)
            {
                strReportFile = "rptXNCNMau1";
               
            }
            else if (rdbMau2.Checked == true)
            {
                strReportFile = "rptXNCNMau2";
               

            }
            else if (rdbMau3.Checked == true)
                strReportFile = "rptXNCNMau3";

            string strFileName = string.Empty;
            string strFileNamePDF = string.Empty;
            string strFilePath = string.Empty;
            string strTitle = "Bảng chi tiết công nợ";
            string strSubTitle = "Đối tượng: ";

          

            if (!bPreview)
            {
                
                foreach (DataRow dr in dtHanTt.Select("Chon = 1"))
                {
                    Hashtable ht = new Hashtable();

                    ht.Add("NGAY_CT", dteNgay_Ct.Text);
                    ht.Add("TK_LIST", dr["Tk_List"].ToString());
                    ht.Add("MA_DT", dr["Ma_Dt"].ToString());
                    ht.Add("DU_NO", dr["Du_No"]);
                    ht.Add("DU_CO", dr["Du_Co"]);
                    ht.Add("NGAY_PH", dteNgay_Ph.Text);
                    ht.Add("NGAY_GUI", dteNgay_Gui.Text);
                    DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintXacNhanCN", ht, CommandType.StoredProcedure);
                    DataTable dtHeader = ds.Tables[0];
                    DataTable dtDetail = ds.Tables[1];


                    if (!dtHeader.Columns.Contains("REPORT_FILE"))
                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                    if (!dtHeader.Columns.Contains("NGAY_CT"))
                        dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));
                    if (!dtHeader.Columns.Contains("NGAY_PH"))
                        dtHeader.Columns.Add("NGAY_PH", typeof(DateTime));
                    if (!dtHeader.Columns.Contains("NGUOI_NHAN"))
                        dtHeader.Columns.Add("NGUOI_NHAN", typeof(string));
                    if (!dtHeader.Columns.Contains("EMAIL"))
                        dtHeader.Columns.Add("EMAIL", typeof(string));
                    if (!dtHeader.Columns.Contains("TEN_GD"))
                        dtHeader.Columns.Add("TEN_GD", typeof(string));
                    if (!dtHeader.Columns.Contains("TEN_KT"))
                        dtHeader.Columns.Add("TEN_KT", typeof(string));
                    if (!dtHeader.Columns.Contains("DOC_TIEN"))
                        dtHeader.Columns.Add("DOC_TIEN", typeof(string));
                    if (!dtHeader.Columns.Contains("CHUC_VU_TGD"))
                        dtHeader.Columns.Add("CHUC_VU_TGD", typeof(string));
                    if (!dtHeader.Columns.Contains("CHUC_VU_KT"))
                        dtHeader.Columns.Add("CHUC_VU_KT", typeof(string));

                    dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
                    dtHeader.Rows[0]["NGAY_CT"] = dteNgay_Ct.Text;
                    dtHeader.Rows[0]["NGAY_PH"] = dteNgay_Ph.Text;
                    dtHeader.Rows[0]["NGUOI_NHAN"] = txtNguoi_Nhan.Text;
                    dtHeader.Rows[0]["TEN_KT"] = txtTen_Kt.Text;
                    dtHeader.Rows[0]["TEN_GD"] = txtTen_Gd.Text;
                    dtHeader.Rows[0]["EMAIL"] = txtEmail.Text;
                    dtHeader.Rows[0]["CHUC_VU_TGD"] = txtChuc_Vu_TGD.Text;
                    dtHeader.Rows[0]["CHUC_VU_KT"] = txtChuc_Vu_Kt.Text;
                    dtHeader.Rows[0]["Doc_Tien"] = "(Bằng chữ: " + Common.ReadMoney(Convert.ToDouble(dtHeader.Rows[0]["TTien_No"]), "VND") + " )";

                    if (txtPath.Text != "")
                    {
                        bdsExportExcel.DataSource = dtDetail;
                        dgvExportExcel_1.DataSource = bdsExportExcel;
                        dgvExportExcel_2.DataSource = bdsExportExcel;

                        strFileName = dtHeader.Rows[0]["File_Name"].ToString();
                        strFileNamePDF = strFileName;
                       
                        strSubTitle += " " + dr["Ten_Dt"].ToString();
                        strSubTitle += "|" + "Tại ngày: " + dteNgay_Ct.Text;


                        if (rdbMau1.Checked == true)
                        {
                            this.ExportControl = dgvExportExcel_1;
                            strFilePath = Path.Combine(txtPath.Text, "MAU_1");
                            strFileName = Path.Combine(strFilePath, strFileName);

                        }
                        else if (rdbMau2.Checked == true)
                        {
                            this.ExportControl = dgvExportExcel_2;
                            strFilePath = Path.Combine(txtPath.Text, "MAU_2");
                            strFileName = Path.Combine(strFilePath, strFileName);
                        }

                        if (!Directory.Exists(strFilePath))
                            System.IO.Directory.CreateDirectory(strFilePath);
                        if (rdbMau3.Checked == false)
                        {
                           

                            //export Excel
                            RosyCommonTMN.ExportExcel.ExportExcelTMN(this.ExportControl, strTitle, strSubTitle, strFileName + ".xls", "U");
                            //export Pdf
                            Voucher.CreateFilePDF(txtPath.Text, strFileName, dtHeader, dtDetail, strFileNamePDF, "","");
                        }
                    }


                    RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                    frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);

                }
            }
            else
            {
                drCurent = ((DataRowView)bdsHanTt.Current).Row;
                Hashtable ht = new Hashtable();

                ht.Add("NGAY_CT", dteNgay_Ct.Text);
                ht.Add("TK_LIST", drCurent["Tk_List"].ToString());
                ht.Add("MA_DT", drCurent["Ma_Dt"].ToString());
                ht.Add("DU_NO", drCurent["Du_No"]);
                ht.Add("DU_CO", drCurent["Du_Co"]);
                ht.Add("NGAY_PH", dteNgay_Ph.Text);
                ht.Add("NGAY_GUI", dteNgay_Gui.Text);
                DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintXacNhanCN", ht, CommandType.StoredProcedure);
                DataTable dtHeader = ds.Tables[0];
                DataTable dtDetail = ds.Tables[1];


                if (!dtHeader.Columns.Contains("REPORT_FILE"))
                    dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                if (!dtHeader.Columns.Contains("NGAY_CT"))
                    dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));
                if (!dtHeader.Columns.Contains("NGAY_PH"))
                    dtHeader.Columns.Add("NGAY_PH", typeof(DateTime));
                if (!dtHeader.Columns.Contains("NGUOI_NHAN"))
                    dtHeader.Columns.Add("NGUOI_NHAN", typeof(string));
                if (!dtHeader.Columns.Contains("EMAIL"))
                    dtHeader.Columns.Add("EMAIL", typeof(string));
                if (!dtHeader.Columns.Contains("TEN_GD"))
                    dtHeader.Columns.Add("TEN_GD", typeof(string));
                if (!dtHeader.Columns.Contains("TEN_KT"))
                    dtHeader.Columns.Add("TEN_KT", typeof(string));
                if (!dtHeader.Columns.Contains("DOC_TIEN"))
                    dtHeader.Columns.Add("DOC_TIEN", typeof(string));
                if (!dtHeader.Columns.Contains("CHUC_VU_TGD"))
                    dtHeader.Columns.Add("CHUC_VU_TGD", typeof(string));
                if (!dtHeader.Columns.Contains("CHUC_VU_KT"))
                    dtHeader.Columns.Add("CHUC_VU_KT", typeof(string));

                dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
                dtHeader.Rows[0]["NGAY_CT"] = dteNgay_Ct.Text;
                dtHeader.Rows[0]["NGAY_PH"] = dteNgay_Ph.Text;
                dtHeader.Rows[0]["NGUOI_NHAN"] = txtNguoi_Nhan.Text;
                dtHeader.Rows[0]["TEN_KT"] = txtTen_Kt.Text;
                dtHeader.Rows[0]["TEN_GD"] = txtTen_Gd.Text;
                dtHeader.Rows[0]["EMAIL"] = txtEmail.Text;
                dtHeader.Rows[0]["CHUC_VU_TGD"] = txtChuc_Vu_TGD.Text;
                dtHeader.Rows[0]["CHUC_VU_KT"] = txtChuc_Vu_Kt.Text;
                dtHeader.Rows[0]["Doc_Tien"] = "(Bằng chữ: " + Common.ReadMoney(Convert.ToDouble(dtHeader.Rows[0]["TTien_No"]), "VND") +" )";
                if (txtPath.Text != "")
                {
                    bdsExportExcel.DataSource = dtDetail;
                    dgvExportExcel_1.DataSource = bdsExportExcel;
                    dgvExportExcel_2.DataSource = bdsExportExcel;

                    strFileName = dtHeader.Rows[0]["File_Name"].ToString();
                    strFileNamePDF = strFileName;
                    //strFileName = Path.Combine(txtPath.Text, strFileName);
                    strSubTitle += " " + drCurent["Ten_Dt"].ToString();
                    strSubTitle += "|" + "Tại ngày: " + dteNgay_Ct.Text;


                    if (rdbMau1.Checked == true)
                    {
                        this.ExportControl = dgvExportExcel_1;
                        strFilePath = Path.Combine(txtPath.Text, "MAU_1");
                        strFileName = Path.Combine(strFilePath, strFileName);
                        
                    }
                    else if (rdbMau2.Checked == true)
                    {
                        this.ExportControl = dgvExportExcel_2;
                        strFilePath = Path.Combine(txtPath.Text, "MAU_2");
                        strFileName = Path.Combine(strFilePath, strFileName);
                    }
                    
                    if (!Directory.Exists(strFilePath))
                        System.IO.Directory.CreateDirectory(strFilePath);

                    if (rdbMau3.Checked == false)
                    {
                       //export Excel
                        RosyCommonTMN.ExportExcel.ExportExcelTMN(this.ExportControl, strTitle, strSubTitle, strFileName + ".xls", "U");
                        //export Pdf
                        Voucher.CreateFilePDF(strFilePath, strFileName, dtHeader, dtDetail, strFileNamePDF, "", "");
                    }
                }

                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);
            }
            return true;
        }
		

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        void rdbMau1_CheckedChanged(object sender, EventArgs e)
        {
            dtHanTt.Clear();

            if (rdbMau1.Checked == true)
                strTk_List = "1";
            else if (rdbMau2.Checked == true)
                strTk_List = "2";
            else if (rdbMau3.Checked == true)
                strTk_List = "3";
            else
                strTk_List = "";
        }
     

        
		#endregion
        void dgvHanTt_KeyDown(object sender, KeyEventArgs e)
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
        void dgvHanTt_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (bdsHanTt == null || bdsHanTt.Position < 0)
                return;

            DataRow dr = ((DataRowView)bdsHanTt.Current).Row;
            DataGridViewCell dgvCell = dgvHanTt.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            enuEdit enuNew_Edit;
            if (strColumnName == "EDIT")
            {
                if (DataTool.SQLCheckExist("R81DMDT_XNCN", "Ma_Dt", dr["Ma_Dt"]))
                {
                    enuNew_Edit = enuEdit.Edit;
                    DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMDT_XNCN WHERE Ident00 = " + dr["Iden_XNCN"] + "");
                    drCurent = dt.Rows[0];
                }
                else
                {
                    enuNew_Edit = enuEdit.New;
                    DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMDT_XNCN WHERE 0 = 1");
                    DataRow drNew = dt.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);
                    drNew["Ma_Dt"] = dr["Ma_Dt"];
                    drNew["Member_ID"] = Element.sysUser_Id;
                    drNew["Ngay_Ap"] = DateTime.Now.ToShortDateString();
                    dt.Rows.Add(drNew);
                    
                    
                    drCurent = dt.Rows[0];
                }

                
                RosyList.frmDmDtXNCN_Edit frmEdit = new RosyList.frmDmDtXNCN_Edit();
                frmEdit.Load(enuNew_Edit, drCurent);
                if (frmEdit.isAccept)
                { dr["Email"] = frmEdit.txtEmail.Text; dtHanTt.AcceptChanges(); }
            }
        }
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

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

		protected override void OnShown(EventArgs e)
		{
            //if (dgvHanTt.Columns.Contains("NGAY_CT_TT"))
            //{
            //    foreach (DataGridViewRow dgvr in dgvHanTt.Rows)
            //    {
            //        if (dgvr.Cells["Ngay_Ct_Tt"].Value.GetType() == typeof(DateTime))
            //        {
            //            if (!Common.CheckDataLocked((DateTime)(dgvr.Cells["Ngay_Ct_Tt"].Value)))
            //            {
            //                dgvr.ReadOnly = true;
            //                dgvr.DefaultCellStyle.ForeColor = Color.Gray;
            //            }
            //        }
            //    }
            //}

			base.OnShown(e);
		}

        
      
	}
}
