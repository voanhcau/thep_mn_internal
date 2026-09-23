using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Library;
using RosySystem.Element;
using RosySystem.Common;
using System.Collections;
using RosySystem.Data;
using RosySystem.Public;
using System.IO;
using RosySystem;
using Rosy.Module;
using System.Reflection;
using System.Globalization;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Core;

using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using RosySystem.Control;

using RosySystem.Customize;
using System.Threading;
using System.Net.Sockets;




namespace RosyModule.Receivable
{
	public partial class frmPXDT_ : RosySystem.Customize.frmView
	{
        DataSet dsViewPh;

		DataTable dtViewPh;
		BindingSource bdsViewPh = new BindingSource();
        rsDataGridView dgvViewPh = new rsDataGridView();

        DataTable dtExcel;
        BindingSource bdsExcel = new BindingSource();
        rsDataGridView dgvExcel = new rsDataGridView();

		DataRow drCurrent;
       
        DataTable dtHeader;
        DataTable dtDetail;
        string strPath = string.Empty;
        string strReport_File = string.Empty;
        bool bHDDT = false;
        bool bHDDTCD = false;
       
        bool bHDDTHuy = false;

        string strPathSendMail = string.Empty;
        string strAcc = string.Empty;
        string strPassword = string.Empty;
        string strSub = string.Empty;
        string strContent = string.Empty;
        string strToCC = string.Empty;
       


        public frmPXDT_()
		{
			InitializeComponent();

			this.btFilter.Click += new EventHandler(btFilter_Click);
			
            this.KeyDown += new KeyEventHandler(frmHDDT_KeyDown);
            
            btPath.Click += new EventHandler(btPath_Click);
            btHDDT.Click += new EventHandler(btHDDT_Click);
            btHDDTCD.Click += new EventHandler(btHDDTCD_Click);
            //btPXDTGN.Click += new EventHandler(btPXDTGN_Click);
            //btPXDTGNCD.Click += new EventHandler(btPXDTGNCD_Click);
            //btSendMail.Click += new EventHandler(btSendMail_Click);
            btHD_Huy.Click += new EventHandler(btHD_Huy_Click);
            

            dteNgay_Ct1.LostFocus += new EventHandler(dteNgay_Ct1_LostFocus);
            dteNgay_Ct2.LostFocus += new EventHandler(dteNgay_Ct2_LostFocus);
            dteNgay_Ct1.TextChanged += new EventHandler(dteNgay_Ct1_TextChanged);
		}

        void dteNgay_Ct1_TextChanged(object sender, EventArgs e)
        {
            
        }

           
        #region Buld, Filldata
        new public void Load()
		{
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            dteNgay_Ct1.Text = dteNgay_Ct1.Text = Element.sysNgay_Ct2.Subtract(new TimeSpan(2, 0, 0, 0)).ToString();
            //LƯU LẠI PATH TRƯỚC ĐÂY
            txtPath.Text = Common.GetBufferValue("PATH_PXDTU") == null ? "" : Common.GetBufferValue("PATH_PXDTU");
            //Add dữ liệu vào commbo
           txtMau_So.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("SELECT_PXDT");
           txtMau_So.Text = "03XKNB0/001";
			this.Build();
			this.BindingLanguage();
			this.Change_Language();

            dgvViewPh.Visible = true;
            dgvExcel.Visible = false;
			

			this.Show();
		}

		private void Change_Language()
		{
            //this.txtMa_Dt.bUseAutoDropDown = true;
		}

		private void Build()
		{
            dgvViewPh.Dock = DockStyle.Fill;
            dgvViewPh.strZone = "PXDT";
            dgvViewPh.BuildGridView();
            this.rsSplitContainer1.Panel2.Controls.Add(dgvViewPh);

            dgvExcel.Dock = DockStyle.Fill;
            dgvExcel.strZone = "PXDTEXCEL";
            dgvExcel.BuildGridView();
            this.rsSplitContainer1.Panel2.Controls.Add(dgvExcel);

            string strSQLExec = @"
				DECLARE @_ColumnList NVARCHAR(1000) 
				SET @_ColumnList = ''
				SELECT @_ColumnList = @_ColumnList + ',' + Column_ID FROM R00Column WHERE Zone = 'PXDT' AND Type <> 'K'
				SELECT CASE WHEN LEN(@_ColumnList) > 0 THEN RIGHT(@_ColumnList, LEN(@_ColumnList)-1) ELSE '' END ";
            string strColumnList = SQLExec.ExecuteReturnValue(strSQLExec).ToString();       
            //string strColumnList = "SO_CT0";
			foreach (string strColumn in strColumnList.Split(','))
            {
                if (dgvViewPh.Columns.Contains(strColumn))
                    ((dgvAutoFilterColumnHeaderCell)dgvViewPh.Columns[strColumn].HeaderCell).bFilteringEnabled = false;

            }
   
    } 

		private void FillData()
		{
            Hashtable ht = new Hashtable();

            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("SO_CT", txtSo_Ct.Text);
            ht.Add("MA_KY_HIEU_HDON", txtMau_So.Text);
            ht.Add("NOT_TAOHD", chkIsNot_TaoHD.Checked);
            ht.Add("NOT_TAOHDCD", chkIsNot_TaoHDCD.Checked);
			
            dsViewPh = SQLExec.ExecuteReturnDs("sp_GetPXDT", ht,  CommandType.StoredProcedure);
            
            dtViewPh = dsViewPh.Tables[0];
			bdsViewPh.DataSource = dtViewPh;
			dgvViewPh.DataSource = bdsViewPh;
			bdsViewPh.Position = 0;

            dtExcel = dsViewPh.Tables[1];
            bdsExcel.DataSource = dtExcel;
            dgvExcel.DataSource = bdsExcel;
            bdsExcel.Position = 0;


            this.bdsSearch = bdsExcel;
            this.ExportControl = dgvExcel;

            if (dtViewPh.Rows.Count > 0)
				numTSo_Ct0.Value = Convert.ToDouble(dtViewPh.Compute("Count(So_Ct)", ""));

           
		}
        #endregion
        #region Event
        
       
        void dteNgay_Ct2_LostFocus(object sender, EventArgs e)
        {
            FillData();
        }

        void dteNgay_Ct1_LostFocus(object sender, EventArgs e)
        {
            FillData();
        }
        void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}
       
		
        void btHD_Huy_Click(object sender, EventArgs e)
        {
            if (dtViewPh.Rows.Count > 1)
            {
                Common.MsgOk("Hủy PX chỉ cho 1 phiếu. Vui lòng chọn lại!");
                return;
            }
            bHDDTHuy = true;

            bHDDT = false;
            bHDDTCD = false;
           
            HDDT_Huy();
        }
        private bool HDDT_Huy()
        {
            if (!FormcheckValid())
                return false;

            drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            frmDuyet_Huy frm = new frmDuyet_Huy();
            frm.Load(drCurrent);
            return true;
        }
        void btPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;

            //folderBrowserDialog.
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;


            txtPath.Text = folderBrowserDialog.SelectedPath;

        }
        private bool Print(string strStt, string strMa_Ct, string strMa_Tte, string strReport_File)
        {
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            bool bIs_Vnd = true;

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("IS_VND", bIs_Vnd);
            ht.Add("HD_TU_IN", true);
            ht.Add("LOGIN_USER", Element.sysUser_Id);
            ht.Add("LANGUAGE_TYPE", "V");

            DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintVoucher", ht, CommandType.StoredProcedure);

            dtHeader = dsPrintVoucher.Tables[0];
            dtDetail = dsPrintVoucher.Tables[1];

            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("TITLE", typeof(string));
            dtHeader.Columns.Add("IS_VND", typeof(bool));
            dtHeader.Columns.Add("DOC_TIEN", typeof(string));
            dtHeader.Columns.Add("DOC_TIENE", typeof(string));
            dtHeader.Columns.Add("SUBTITLE2", typeof(string));

            DataRow drHeader = dtHeader.Rows[0];

            drHeader["Is_Vnd"] = bIs_Vnd;
            drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
            drHeader["Report_File"] = strReport_File;

            if (Element.sysLanguage == enuLanguageType.Vietnamese)
            {

                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoney(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
                //if (strMa_Ct == "HDXK" && strMa_Tte == "USD")
                //    dtHeader.Rows[0]["Doc_Tien"] = Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte);

            }
            else if (Element.sysLanguage == enuLanguageType.English)
                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
            else
                dtHeader.Rows[0]["Doc_Tien"] = Common.ReadNumberC(Convert.ToDouble(drHeader["TTien_Nt"]));

            if (Element.sysLanguage == enuLanguageType.Vietnamese && Common.Inlist(strMa_Ct, "HDXK"))
            {
                dtHeader.Rows[0]["Doc_TienE"] = Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) + ".";

            }

            return true;
        }
       
        
        private bool FormcheckValid()
        {
            if (bHDDTHuy || bHDDTCD)
            {
                if (dtViewPh.Rows.Count > 1)
                {
                    Common.MsgOk("Yêu cầu chỉ có 1 dòng dữ liệu!!!");
                    return false;
                }
            }
            if (txtPath.Text == "" && bHDDT)
            {
                Common.MsgOk("Yêu cầu chọn đường dẫn xuất phiếu xuất điện tử");
                return false;
            }
            foreach (DataRow dr in dtViewPh.Rows)
            {
                if (bHDDT)
                {
                    if (!Common.CheckDataLocked((DateTime)dr["Ngay_Ct"]))
                    {
                        Common.MsgOk("Ngày tạo PXDT đã khóa sổ không cho phép tạo PX.");
                        return false;
                    }
                    if ((bool)dr["HDDTDaTao"] == true)
                    {
                        Common.MsgOk("Yêu cầu kiểm tra số phiếu xuất "+dr["So_Ct"]+" đã được tạo PXDT. Không được tạo lần 2");
                        return false;
                    }
                }
                else if (bHDDTHuy)
                {
                    if ((bool)dr["HDDTDaTao"] == false)
                    {
                        Common.MsgOk("Yêu cầu kiểm tra số hóa đơn " + dr["So_Ct"] + " chưa được tạo PX điện tử. Không được hủy PX khi chưa tạo PX điện tử");
                        return false;
                    }
                }
                else if (bHDDTCD)
                {
                    if ((bool)dr["HDDTDaTao"] == false)
                    {
                        Common.MsgOk("Yêu cầu kiểm tra số phiếu xuất " + dr["So_Ct"] + " chưa được tạo PXDT. Phiếu phải được tạo PXDT");
                        return false;
                    }
                }
            }

           
            
            return true;
        }
        
        private bool Create_HDDT()
        {
            if (!FormcheckValid())
                return false;

             strPath = txtPath.Text;

             string strPath_Export_Temp = string.Empty;
             string strPath_Export = string.Empty;
             bool Allow_Backup = true;
             string strFileName = string.Empty;
             bool bPreview = false;
             bool bShowDialog = false;
             bool bPrint = false;
             string strSqlExec = string.Empty;
             if (bHDDT)
             {

                 if (!Directory.Exists(strPath))
                     System.IO.Directory.CreateDirectory(strPath);

                 if (!Directory.Exists(strPath))
                 {
                     try { Directory.CreateDirectory(strPath); }
                     catch { Common.MsgCancel("Đường dẫn này không tồn tại, Vui lòng kiểm tra lại trước khi xuất PX điện tử"); Allow_Backup = false; }
                 }
                 //Kiểm tra tra ngày tạo HDDT trong 2 ngày
                 //DateTime dtNgay_Ct1 = Convert.ToDateTime(dteNgay_Ct1.Text);
                 //DateTime dtNgay_Ct2 = Convert.ToDateTime(dteNgay_Ct2.Text);
                 //string dtNgay_Ct = dtNgay_Ct1.Subtract(new TimeSpan(-1, 0, 0, 0)).ToString();
                 //if (dtNgay_Ct2 > Convert.ToDateTime(dtNgay_Ct))
                 //{
                 //    Common.MsgCancel("Không tạo HDDT lớn hơn 2 ngày. Vui lòng chọn lại ngày tạo PXDT!!!");
                 //    return false;
                 //}
                 //Auto Create File PDF
                 if (Allow_Backup)
                 {

                     //Tạo từng HDDT
                     foreach (DataRow dr in dtViewPh.Rows)
                     {
                         if (dr["Ma_Ky_Hieu_HDon"].ToString() == "03XKNB0/001")
                             strReport_File = "rptCT_PX_DTGNPDF";
                         else if (dr["Ma_Ky_Hieu_HDon"].ToString() == "03XKNB0/002")
                             strReport_File = "rptCT_PX_DTPDF";

                         int iVersion = 0;
                         strFileName = dr["File_Name"].ToString();
                         strPath_Export_Temp = Path.Combine(strPath, strFileName + ".pdf");
                         if (!File.Exists(strPath_Export_Temp))
                         {
                             //iVersion += 1;
                             //strPath_Export_Temp = Path.Combine(strPath, strFileName + "_" + iVersion + ".pdf");
                             strPath_Export = strPath_Export_Temp;
                             Hashtable ht = new Hashtable();
                             

                            ht.Add("STT", dr["Stt"].ToString());
                            ht.Add("NGUOI_TAO", Element.sysUser_Id);
                            strSqlExec = "UPDATE R80PH SET HDDTDaTao = 1, HDDTNguoiTao = @Nguoi_Tao WHERE Stt = @Stt";

                            
                             SQLExec.Execute(strSqlExec, ht, CommandType.Text);

                             Print(dr["Stt"].ToString(), dr["Ma_Ct"].ToString(), dr["Ma_Tte"].ToString(), strReport_File);

                             RosyReportTMN.frmReportPrint frmPrint = new RosyReportTMN.frmReportPrint();
                             frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export, bPrint);

                             Common.ShowStatus(Languages.GetLanguage("In_Process") + " tạo PXDT số " + (string)dr["So_Ct"] + " của khách hàng " + (string)dr["Ten_Dt"]);
                         }

                         else
                             Common.ShowStatus("PXDT số " + (string)dr["So_Ct"] + " của khách hàng " + (string)dr["Ten_Dt"] + " đã tồn tại!!!");

                         Common.EndShowStatus();
                     }
                 }
             }
             else if (bHDDTCD)
             {

                 drCurrent = ((DataRowView)bdsViewPh.Current).Row;
                 
                 if (drCurrent["Ma_Ky_Hieu_HDon"].ToString() == "03XKNB0/001")
                     strReport_File = "rptCT_PX_DTGNCD";
                 else if (drCurrent["Ma_Ky_Hieu_HDon"].ToString() == "03XKNB0/002")
                     strReport_File = "rptCT_PX_DTCD";

                Hashtable ht = new Hashtable();
                ht.Add("STT", drCurrent["Stt"].ToString());
                ht.Add("NGUOI_CD", Element.sysUser_Id);
                strSqlExec = "UPDATE R80PH SET HDDTChuyenDoi = 1, HDDTNguoiCD = @Nguoi_CD WHERE Stt = @Stt";

                SQLExec.Execute(strSqlExec, ht, CommandType.Text);
                Print(drCurrent["Stt"].ToString(), drCurrent["Ma_Ct"].ToString(), drCurrent["Ma_Tte"].ToString(), strReport_File);
                bShowDialog = true;
                bPreview = true;
                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
                 
             }
            
            FillData();
            return true;
        }
        void btHDDT_Click(object sender, EventArgs e)
        {
            bHDDT = true;
            bHDDTCD = false;
          
            bHDDTHuy = false;
          
            if(Create_HDDT())
                Common.MsgOk("Đã tạo phiếu xuất điện tử theo đường dẫn " + strPath + ". Anh chị vui lòng kiểm tra lại.");
        }
        void btHDDTCD_Click(object sender, EventArgs e)
        {
            bHDDTCD = true;
            bHDDT = false;
            
            bHDDTHuy = false;

            if (Create_HDDT())
            {
            }

        }
       
        #endregion

        void frmHDDT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    this.FillData();
                    break;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    if (dgvViewPh.Visible == true)
                    {
                        dgvViewPh.Visible = false;
                        dgvExcel.Visible = true;
                    }
                    else
                    {
                        dgvViewPh.Visible = true;
                        dgvExcel.Visible = false;
                    }
                    return;
            }
        }

       

    }
}
