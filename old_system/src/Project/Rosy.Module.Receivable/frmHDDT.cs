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
	public partial class frmHDDT : RosySystem.Customize.frmView
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
        string strListKhachHang = "Danh sách khách hàng đã gửi HDDT ";


		public frmHDDT()
		{
			InitializeComponent();

			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            this.KeyDown += new KeyEventHandler(frmHDDT_KeyDown);
            
            btPath.Click += new EventHandler(btPath_Click);
            btHDDT.Click += new EventHandler(btHDDT_Click);
            btHDDTCD.Click += new EventHandler(btHDDTCD_Click);
            btSendMail.Click += new EventHandler(btSendMail_Click);
            btHD_Huy.Click += new EventHandler(btHD_Huy_Click);
            

            dteNgay_Ct1.LostFocus += new EventHandler(dteNgay_Ct1_LostFocus);
            dteNgay_Ct2.LostFocus += new EventHandler(dteNgay_Ct2_LostFocus);
            
		}        
        #region Buld, Filldata
        new public void Load()
		{
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            dteNgay_Ct1.Text = dteNgay_Ct1.Text = Element.sysNgay_Ct2.Subtract(new TimeSpan(2, 0, 0, 0)).ToString();
            //LƯU LẠI PATH TRƯỚC ĐÂY
            txtPath.Text = Common.GetBufferValue("PATH_HDDTU") == null ? "" : Common.GetBufferValue("PATH_HDDTU");

            dgvViewPh.Visible = true;
            dgvExcel.Visible = false;

			this.Build();
			this.BindingLanguage();
			this.Change_Language();
			
			

			this.Show();
		}

		private void Change_Language()
		{
			this.txtMa_Dt.bUseAutoDropDown = true;
		}

		private void Build()
		{
            dgvViewPh.Dock = DockStyle.Fill;
            dgvViewPh.strZone = "HDDT";
            dgvViewPh.BuildGridView();
            this.rsSplitContainer1.Panel2.Controls.Add(dgvViewPh);


            dgvExcel.Dock = DockStyle.Fill;
            dgvExcel.strZone = "HDDTEXCEL";
            dgvExcel.BuildGridView();
            this.rsSplitContainer1.Panel2.Controls.Add(dgvExcel);

            string strSQLExec = @"
				DECLARE @_ColumnList NVARCHAR(1000) 
				SET @_ColumnList = ''
				SELECT @_ColumnList = @_ColumnList + ',' + Column_ID FROM R00Column WHERE Zone = 'HDDT' AND Type <> 'K'
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
            ht.Add("MA_DT", txtMa_Dt.Text);
            ht.Add("SO_CT0", txtSo_Ct0.Text);
            ht.Add("NOT_TAOHD", chkIsNot_TaoHD.Checked);
            ht.Add("NOT_TAOHDCD", chkIsNot_TaoHDCD.Checked);

            dsViewPh = SQLExec.ExecuteReturnDs("sp_GetHDDT", ht, CommandType.StoredProcedure);
            
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
				numTSo_Ct0.Value = Convert.ToDouble(dtViewPh.Compute("Count(So_Ct0)", ""));

           
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
        void btSendMail_Click(object sender, EventArgs e)
        {
            
            //Send Mail
            SendMail();
        }
		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("MA_DT", strValue, bRequire, "");

			if (drLookup == null && bRequire)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = (string)drLookup["Ma_Dt"];
				lbtTen_Dt.Text = (string)drLookup["Ten_Dt"];
                FillData();
			}
		}
        void btHD_Huy_Click(object sender, EventArgs e)
        {
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
            ht.Add("HD_TU_IN", 1);
            ht.Add("IS_VND", bIs_Vnd);
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
                if (strMa_Ct == "HDXK" && strMa_Tte == "USD")
                    dtHeader.Rows[0]["Doc_Tien"] = Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte);

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
       
        void btHDDTCD_Click(object sender, EventArgs e)
        {
            bHDDTCD = true;

            bHDDT = false;
            bHDDTHuy = false;

            strReport_File = "rptCT_HDDTCD";
            if (Create_HDDT())
            {
               
            }
            //Common.MsgOk("Đã tạo hóa đơn điện tử chuyển đổi theo đường dẫn " + strPath + ". Anh chị vui lòng kiểm tra lại.");
        }
        private bool FormcheckValid()
        {
            if (bHDDTHuy)
            {
                if (dtViewPh.Rows.Count > 1)
                {
                    Common.MsgOk("Yêu cầu chỉ hủy 1 hóa đơn đã tạo HDDT");
                    return false;
                }
            }
            if (bHDDTCD)
            {
                //kiểm tra HDDTCD cho 1 đối tượng/ 1 ngày
                if (txtMa_Dt.Text == "" && dteNgay_Ct1.Text != dteNgay_Ct2.Text)
                {
                    Common.MsgOk("HDDT chuyển đổi chỉ cho phép chọn 1 khách hàng trong cùng 1 ngày. Vui lòng kiểm tra lại thông tin!!!");
                    return false;
                }
            }
            foreach (DataRow dr in dtViewPh.Rows)
            {
                if (bHDDT)
                {
                    if (!Common.CheckDataLocked((DateTime)dr["Ngay_Ct0"]))
                    {
                        Common.MsgOk("Ngày tạo HDDT đã khóa sổ không cho phép tạo HD.");
                        return false;
                    }
                    if ((bool)dr["HDDTDaTao"] == true)
                    {
                        Common.MsgOk("Yêu cầu kiểm tra số hóa đơn "+dr["So_Ct0"]+" đã được tạo HDDT. Không được tạo lần 2");
                        return false;
                    }
                }
                //else if (bHDDTCD)
                //{
                //    if ((bool)dr["HDDTDaTao"] == false)
                //    {
                //        Common.MsgOk("Yêu cầu kiểm tra số hóa đơn " + dr["So_Ct0"] + " chưa được tạo HD điện tử. Không được tạo HD chuyển đổi khi chưa tạo HD điện tử");
                //        return false;
                //    }
                //    if ((bool)dr["HDDTChuyenDoi"] == true)
                //    {
                //        Common.MsgOk("Yêu cầu kiểm tra số hóa đơn " + dr["So_Ct0"] + " đã được tạo HDDT chuyển đổi. Không được tạo lần 2");
                //        return false;
                //    }
                //}
                else if (bHDDTHuy)
                {
                    if ((bool)dr["HDDTDaTao"] == false)
                    {
                        Common.MsgOk("Yêu cầu kiểm tra số hóa đơn " + dr["So_Ct0"] + " chưa được tạo HD điện tử. Không được hủy HD khi chưa tạo HD điện tử");
                        return false;
                    }
                }
            }

            if (txtPath.Text == "" && (bHDDT))
            {
                Common.MsgOk("Yêu cầu chọn đường dẫn xuất hóa đơn điện tử");
                return false;
            }
            return true;
        }
       
        private bool Create_HDDT()
        {
            DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text);

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
                     catch { Common.MsgCancel("Đường dẫn này không tồn tại, Vui lòng kiểm tra lại trước khi xuất HD điện tử"); Allow_Backup = false; }
                 }
                 //Kiểm tra tra ngày tạo HDDT trong 2 ngày
                 DateTime dtNgay_Ct1 = Convert.ToDateTime(dteNgay_Ct1.Text);
                 DateTime dtNgay_Ct2 = Convert.ToDateTime(dteNgay_Ct2.Text);
                 string dtNgay_Ct = dtNgay_Ct1.Subtract(new TimeSpan(-1, 0, 0, 0)).ToString();
                 if (dtNgay_Ct2 > Convert.ToDateTime(dtNgay_Ct))
                 {
                     Common.MsgCancel("Không tạo HDDT lớn hơn 2 ngày. Vui lòng chọn lại ngày tạo HDDT!!!");
                     return false;
                 }
                 //Auto Create File PDF
                 if (Allow_Backup)
                 {

                     //Tạo từng HDDT
                     foreach (DataRow dr in dtViewPh.Rows)
                     {
                         int iVersion = 0;
                         strFileName = dr["File_Name"].ToString();
                         strPath_Export_Temp = Path.Combine(strPath, strFileName + ".pdf");
                         if (!File.Exists(strPath_Export_Temp))
                         {
                             //iVersion += 1;
                             //strPath_Export_Temp = Path.Combine(strPath, strFileName + "_" + iVersion + ".pdf");
                             strPath_Export = strPath_Export_Temp;
                             Hashtable ht = new Hashtable();
                             //if (strReport_File == "rptCT_HDDT_PDF")
                             //{

                                 ht.Add("STT", dr["Stt"].ToString());
                                 ht.Add("NGUOI_TAO", Element.sysUser_Id);
                                 strSqlExec = "UPDATE R80PH SET HDDTDaTao = 1, HDDTNguoiTao = @Nguoi_Tao WHERE Stt = @Stt";

                             //}
                             //else
                             //{

                             //    ht.Add("STT", dr["Stt"].ToString());
                             //    ht.Add("NGUOI_CD", Element.sysUser_Id);
                             //    strSqlExec = "UPDATE R80PH SET HDDTChuyenDoi = 1, HDDTNguoiCD = @Nguoi_CD WHERE Stt = @Stt";
                             //}
                             SQLExec.Execute(strSqlExec, ht, CommandType.Text);
                             //Bằng cập nhật lại HDDTDaTao
                             Hashtable ht1 = new Hashtable();
                             ht1.Add("STT", dr["Stt"].ToString());
                             ht1.Add("MA_CT", dr["Ma_Ct"].ToString());
                             ht1.Add("DUYET_HUY", false);
                             SQLExec.Execute("sp_UpdateDaXuatHD", ht1, CommandType.StoredProcedure);
                             // xong

                             Print(dr["Stt"].ToString(), dr["Ma_Ct"].ToString(), dr["Ma_Tte"].ToString(), strReport_File);

                             RosyReportTMN.frmReportPrint frmPrint = new RosyReportTMN.frmReportPrint();
                             frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export, bPrint);

                             Common.ShowStatus(Languages.GetLanguage("In_Process") + " tạo HDDT số " + (string)dr["So_Ct0"] + " của khách hàng " + (string)dr["Ten_Dt"]);
                         }

                         else
                             Common.ShowStatus("HDDT số " + (string)dr["So_Ct0"] + " của khách hàng " + (string)dr["Ten_Dt"] + " đã tồn tại!!!");

                         Common.EndShowStatus();
                     }
                 }
             }
             else if (bHDDTCD)
             {
                 drCurrent = ((DataRowView)bdsViewPh.Current).Row;
                 //Kiểm tra đã tạo HDDT chưa
                 if (!(bool)drCurrent["HDDTDaTao"])
                 {
                     Common.MsgOk("Số HD " + drCurrent["So_Ct0"] + " chưa được tạo HDDT.Yêu cầu tạo HDDT trước khi chuyển đổi!!!");
                    return false;
                 }
                 if ((bool)drCurrent["HDDTChuyenDoi"])
                 {
                     Common.MsgOk("Yêu cầu kiểm tra số hóa đơn " + drCurrent["So_Ct0"] + " đã được tạo HDDT chuyển đổi. Không được tạo lần 2");
                     return false;
                 }
                 //foreach (DataRow dr in dtViewPh.Rows)
                 //{
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
                 //}
             }
            
            FillData();
            return true;
        }
        void btHDDT_Click(object sender, EventArgs e)
        {
           
            bHDDT = true;
            bHDDTCD = false;
            bHDDTHuy = false;

            strReport_File = "rptCT_HDDT_PDF";

            if (Create_HDDT())
            {
               
                  Common.MsgOk("Đã tạo hóa đơn điện tử theo đường dẫn " + strPath + ". Anh chị vui lòng kiểm tra lại.");
            }
        }

        private void SendMail()
        {
            try
            {
                //Hiện form Send mail lấy đường dẫn
                frmSendMailHDDT frm = new frmSendMailHDDT();
                frm.Load();
                if (frm.isAccept)
                {
                    //Lấy các file trong đường dẫn truyền vào             
                    string[] fileList = Directory.GetFiles(frm.txtPath.Text, "*.pdf");

                    foreach (string fileName in fileList)
                    {
                        string strFileName = "";
                        string strMST_Customer = "";
                        string strNgay_HD = "";
                        strFileName = Path.GetFileName(fileName).Trim();
                        //lấy chiều dài MST khách hàng
                        int iMST = strFileName.IndexOf(".pdf");
                        strMST_Customer = strFileName.ToString().Substring(15, iMST - 15);
                        strNgay_HD = strFileName.ToString().Substring(0, 6);
                        //tạo thư muc chứa MST khách hàng
                        //nếu chưa có thư mục MST khách hàng thì tạo
                        if (!Directory.Exists(Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD)))
                            Directory.CreateDirectory(Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD));

                        string[] files = Directory.GetFiles(frm.txtPath.Text, strNgay_HD + "*" + strMST_Customer + "*");
                        //Copy các file có mst khách hàng vào thư mục                   
                        foreach (var item in files)
                        {
                            //nếu ko tồn tại thì ko copy
                            if (!File.Exists(Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD) + "\\" + Path.GetFileName(item)))
                                File.Copy(item, Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD) + "\\" + Path.GetFileName(item));
                        }

                        //Nén file 
                        string folderName = Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD);
                        string strOutZip = Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD + ".zip");
                        if (!File.Exists(Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD) + ".zip"))
                            Voucher.CreateFileZip(strOutZip, folderName);
                        //Xóa thư mục con sau khi tạo file nén
                        if (Directory.Exists(Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD)))
                        {
                            //nếu có file thì phải xóa file đi
                            string[] strfile_Del = Directory.GetFiles(Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD));
                            foreach (string file_Del in strfile_Del)
                                File.Delete(Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD) + "\\" + Path.GetFileName(file_Del));

                            Directory.Delete(Path.Combine(frm.txtPath.Text, strMST_Customer + "-" + strNgay_HD));
                        }
                    }
                    
                    strAcc = frm.txtAcc.Text;
                    strPassword = frm.txtPassword.Text;
                    strSub = frm.txtSub.Text;
                    strContent = frm.txtContent.Text;
                    strPathSendMail = frm.txtPath.Text;
                    strToCC = frm.txtToCC.Text;
                    
                   
                    if (!SendMailToKh())
                        Common.MsgOk("Gửi mail không thành công đến khách hàng");
                    else
                    {
                        //xóa file zip
                        //Del_fiezip();
                      
                    }

                }
                Common.MsgOk(strListKhachHang);

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.ToString());
               
            }
           
        
        }
       
       

        private void Del_fiezip(string strMST)
        {
            string[] filezip_Del = Directory.GetFiles(strPathSendMail, strMST + "*.zip");
            foreach (string fileName in filezip_Del)
            {
                if (File.Exists(strPathSendMail + "\\" + Path.GetFileName(fileName)))
                    File.Delete(strPathSendMail + "\\" + Path.GetFileName(fileName));

            }
        }
        private void Del_fiezip()
        {
            string[] filezip_Del = Directory.GetFiles(strPathSendMail,   "*.zip");
            foreach (string fileName in filezip_Del)
            {
                if (File.Exists(strPathSendMail + "\\" + Path.GetFileName(fileName)))
                    File.Delete(strPathSendMail + "\\" + Path.GetFileName(fileName));

            }
        }
       
        private bool SendMailToKh()
        {
            //Gửi mail khách hàng theo từng file zip
            string[] filezip = Directory.GetFiles(strPathSendMail, "*.zip");


            foreach (string fileName in filezip)
            {
                //Lấy MST khách hàng
                int iMST = fileName.IndexOf(".zip");
                string strMST = Path.GetFileName(fileName).Trim().Substring(0, iMST - strPathSendMail.Length - 8);
                DataRow drDmDtMST = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_So_Thue", strMST);
                //Kiểm tra email khách hàng có hay không
                if (drDmDtMST["Email"] == string.Empty || drDmDtMST["Email"] == "")
                {
                    //Common.MsgOk("Khách hàng " + drDmDtMST["Ten_Dt"] + " chưa được cập nhật thông tin email nhận hóa đơn điện tử. Vui lòng bổ sung thông tin trước khi gửi mail");
                    //return false;
                    //Chưa có mail thì copy các file pdf sang thư mục NotSend
                    string strPathNotSend = strPathSendMail + "\\NotSend";
                    if (!Directory.Exists(strPathNotSend))
                        System.IO.Directory.CreateDirectory(strPathNotSend);
                    //Copy các file của khách hàng chưa có mail
                    string[] fileList = Directory.GetFiles(strPathSendMail, "*" + strMST + ".pdf");
                    foreach (var item in fileList)
                    {
                        if(!File.Exists(Path.Combine(strPathNotSend, Path.GetFileName(item))))
                            File.Copy(item, Path.Combine(strPathNotSend, Path.GetFileName(item)));
                    }
                }
                else
                {
                    if (!File.Exists(strPathSendMail + "\\" + Path.GetFileName(fileName)))
                    { continue; }
                    else
                    {
                        SmtpClient SmtpServer = new SmtpClient();
                        NetworkCredential loginInfo = new NetworkCredential(strAcc, strPassword);
                        MailMessage mail = new MailMessage();

                        mail.From = new MailAddress(strAcc);
                        if (strAcc.Contains("thepmiennam.com.vn"))
                        {
                            SmtpServer = new SmtpClient("mail.thepmiennam.com.vn");
                            SmtpServer.Port = 25;
                        }
                        else if (strAcc.Contains("gmail.com"))
                        {
                            SmtpServer = new SmtpClient("smtp.gmail.com");
                            SmtpServer.Port = 587;
                           
                        }

                        if (drDmDtMST["Email"].ToString().Contains(";"))
                        {
                            int iEmail = drDmDtMST["Email"].ToString().IndexOf(";");
                            //lấy vị trí đầu đến dấu chấm phẩy
                            mail.To.Add(drDmDtMST["Email"].ToString().Substring(0, iEmail));
                            mail.To.Add(drDmDtMST["Email"].ToString().Substring(iEmail + 1, drDmDtMST["Email"].ToString().Length - iEmail - 1));
                        }
                        else
                            mail.To.Add(drDmDtMST["Email"].ToString());
                        
                        mail.Bcc.Add(strToCC);
                        mail.Subject = strSub; ;
                        mail.Body = strContent;


                        string[] filezipKh = Directory.GetFiles(strPathSendMail, strMST + "*.zip");

                        foreach (string fileNameKh in filezipKh)
                        {
                            if (Directory.Exists(strPathSendMail + "\\" + Path.GetFileName(fileNameKh)))
                                mail.Dispose();
                            else
                            {
                                mail.Attachments.Add(new Attachment(strPathSendMail + "\\" + Path.GetFileName(fileNameKh), MediaTypeNames.Application.Octet));
                            }
                        }

                        SmtpServer.EnableSsl = true;
                        SmtpServer.UseDefaultCredentials = false;

                        SmtpServer.Credentials = loginInfo;
                        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                        try
                        {
                            Common.ShowStatus("Đang gửi HDDT đến khách hàng " + (string)drDmDtMST["Ten_Dt"]);
                            SmtpServer.Send(mail);

                            strListKhachHang = strListKhachHang + " " + (string)drDmDtMST["Ten_Dt"];
                            mail.Dispose();
                            Del_fiezip(strMST);
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("Mailbox unavailable. The server response was: 5.7.1 Unable to relay"))
                                Common.MsgOk("Bạn đã nhập sai password");

                            if (ex.ToString().Contains("The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.7.0 Authentication Required. Learn more at"))
                                Common.MsgOk("Bạn vào link dưới đây bật ON : https://myaccount.google.com/lesssecureapps");

                            mail.Dispose();

                            Common.MsgOk("Không gửi được HDDT đến khách hàng" + (string)drDmDtMST["Ten_Dt"]);
                            return false;
                        }
                    }
                    Common.EndShowStatus();
                }

            }
            return true;
        }
        
        public void ExtractZipFile(string archiveFilenameIn, string password, string outFolder) // giải nén
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;
                    }
                    String entryFileName = zipEntry.Name;

                    byte[] buffer = new byte[4096];
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    if (System.IO.File.Exists(fullZipToPath) != true)
                    {
                        using (FileStream streamWriter = File.Create(fullZipToPath))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }
                    }
                    else
                    {
                        using (FileStream streamWriter = new FileStream(fullZipToPath, FileMode.Append))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true;
                    zf.Close();
                }
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
        //private void lbtTen_Dt_Click(object sender, EventArgs e)
        //{

        //}

       

    }
}
