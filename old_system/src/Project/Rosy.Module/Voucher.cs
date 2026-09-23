using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;
using System.IO;
using System.Data.OleDb;

using RosySystem;
using RosySystem.Data;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Element;

using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading;
using System.Net.Sockets;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Core;


namespace RosyModule
{
    public static class Voucher
    {
        public static bool Print(string strStt, bool bPreview, bool bShowDialog, ref bool bInVisibleNextPrint)
        {
            DataRow drPH = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();

            if (drPH == null)
            {
                Common.MsgCancel("Phiếu không tồn tại, không in được");
                return false;
            }

            string strMa_Ct = (string)drPH["Ma_Ct"];
            //string strMa_Tte = "VND";
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            bool bIs_Vnd = true;
            bool bIs_Vnd_ = true;
            bool bHd_Tu_In = false;
            bool bLoai_Tte = true;

            bool bIs_Print_Barem = false;
            string strReport_File = string.Empty;
            bool bSOCP_GH = false;
            string strSo_Ct = "";
            string strLien = "1,2,3";



            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            DataTable dtHeader;
            DataTable dtDetail;



            strTable_Ph = (string)drDmCt["Table_Ph"];
            strTable_Ct = (string)drDmCt["Table_Ct"];
            strReport_File = (string)drDmCt["Report_File"];

            DataRow drPHCt = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
            string strMa_Tte = (string)drPHCt["Ma_Tte"];

            DataRow drCT = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
            if ((string)drCT["Ma_Tte"] == Element.sysMa_Tte)
                bIs_Vnd_ = true;
            else
                bIs_Vnd_ = false;

            if ((string)drCT["Ma_Tte"] == Element.sysMa_Tte && Common.Inlist(strMa_Ct, "PT,PC"))
                bIs_Vnd = true;
            else
                bIs_Vnd = false;

            if (strMa_Ct.StartsWith("BN") && !bInVisibleNextPrint)
            {
                DataRow drCtTien = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);

                if (!drPH.Table.Columns.Contains("TK_NH"))
                    drPH.Table.Columns.Add("TK_NH", typeof(string));

                drPH["Tk_Nh"] = (string)drCtTien["Tk_Co"];

                frmIn_CT_UNC frm = new frmIn_CT_UNC();

                if (strMa_Tte != Element.sysMa_Tte)
                    frm.rdbTien_Nt.Checked = true;

                frm.Load(drPH);

                strReportTag = "_" + frm.txtReportTag.Text;
                strReport_File = strReport_File + frm.txtReportTag.Text;

                if (!frm.isAccept)
                    return false;

                bInVisibleNextPrint = frm.chkInVisibleNextPrint.Checked;

                bIs_Vnd = frm.rdbTien_VND.Checked;

                strSo_Ct = frm.txtSo_Ct.Text;

                if (bIs_Vnd == false)
                    strReportTag = strReportTag + "_Nt";
            }

            if (Common.InlistLike(strMa_Ct, "HD") && !Common.InlistLike(strMa_Ct, "HDTL")) //&& !Common.Inlist(strMa_Ct, "HDXK")
            {
                DataRow drCtHd = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
                frmIn_Ct_HD frm = new frmIn_Ct_HD();
                strReport_File = "";
                strReportTag = "HDTI";
                frm.Load(drPH, true);

                if (frm.isAccept)
                {
                    if (frm.rdbHd_Tu_In.Checked == true)
                    {
                        if (strMa_Tte == "USD")
                            frm.rdbTien_Nt.Checked = true;

                        strReportTag = "HDTI";
                        bHd_Tu_In = frm.rdbHd_Tu_In.Checked;
                        bIs_Vnd = frm.rdbTien_VND.Checked;
                    }
                    if (frm.rdbHd_Dat_In.Checked == true)
                    {
                        if (strMa_Tte == "USD")
                            frm.rdbTien_Nt.Checked = true;
                        if (strMa_Ct == "HDXK")
                            strReportTag = "HDXK";
                        else
                            strReportTag = "HDDI";

                    }
                    if (frm.rdbPhieu_Xuat.Checked == true)
                    {
                        if (strMa_Tte == "USD")
                            frm.rdbTien_Nt.Checked = true;

                        strReportTag = "PX";
                        bIs_Vnd = frm.rdbTien_VND.Checked;
                    }
                    if (frm.rdbInvoice.Checked == true)
                    {
                        bIs_Print_Barem = true;
                        if (strMa_Tte == "USD")
                            frm.rdbTien_Nt.Checked = true;

                        if (drCtHd["Ma_Nvu"].ToString() == "HDXK11")
                            strReportTag = "INVOICEPHOI";
                        else
                            strReportTag = "INVOICE";
                        bIs_Vnd = frm.rdbTien_VND.Checked;

                    }
                    if (frm.rdbHd_DT.Checked == true)
                    {
                        if (strMa_Tte == "USD")
                            frm.rdbTien_Nt.Checked = true;

                        strReportTag = "HDDT";
                        bHd_Tu_In = true;
                        bIs_Vnd = frm.rdbTien_VND.Checked;
                    }
                    if (frm.rdbHd_Dt_Cd.Checked == true)
                    {
                        if (strMa_Tte == "USD")
                            frm.rdbTien_Nt.Checked = true;

                        strReportTag = "HDDTCD";
                        bHd_Tu_In = true;
                        bIs_Vnd = frm.rdbTien_VND.Checked;
                    }
                }

                else
                    return false;
            }

            else if (Common.Inlist(strMa_Ct, "HDXK"))
            {

                strMa_Tte = "USD";
                bIs_Vnd = false;// frm.rdbTien_VND.Checked;
                strReportTag = "HDXK";

            }
            else if (strMa_Ct == "BBTH")
            {
                DataRow drCtHd = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
                if (drCtHd["Ma_Nvu"].ToString() == "XHTT")
                 strReportTag = "_XHTT"; 
            }
            else if (strMa_Ct == "BBNL")
            {
                DataRow drCtHd = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
                if (drCtHd["Ma_Nvu"].ToString() == "BBVOTH")
                    strReportTag = "_VOI";
            }
            else if (Common.Inlist(strMa_Ct, "PXBR,PXDC,PXDCA"))
            {
                frmIn_Ct_Px frm = new frmIn_Ct_Px();
                strReportTag = "";
                frm.Load(drPH, true);

                if (!frm.isAccept)
                    return false;

                if (frm.rdbPx_BBXN.Checked == true)
                {
                    if (strMa_Ct == "PXDC" && Common.Inlist(drCT["Ht_Gn"].ToString(), "DD,HD-TMNVC,KG-TMNVC"))
                        strReportTag = "DC_BBXNDD";
                    else if (drCT["Ht_Gn"].ToString().Length < 7)
                        strReportTag = "_BBXN";
                    else
                    {
                        if (Common.Inlist(drCT["Ht_Gn"].ToString().Substring(2, 4), "_GT_"))
                            strReportTag = "_BBXNGT";
                        else
                            strReportTag = "_BBXN";
                    }
                }
                else if (frm.rdbPhieu_Xuat_DT.Checked == true)
                {
                    bHd_Tu_In = true;
                    if (drCT["Ma_Ky_Hieu_HDon"].ToString() == "03XKNB0/001")
                        strReportTag = "_DTGN";
                    else if (drCT["Ma_Ky_Hieu_HDon"].ToString() == "03XKNB0/002")
                        strReportTag = "_DT";
                }
                else if (frm.rdbPXDTGN.Checked == true)
                {
                    bHd_Tu_In = true;
                    strReportTag = "_DTGN";
                }
                else if (frm.rdbPX_DTGN_PDF.Checked == true)
                {
                    bHd_Tu_In = true;
                    strReportTag = "_DTGNPDF";
                }
                else if (frm.rdbPX_DTGN_CD.Checked == true)
                {
                    bHd_Tu_In = true;
                    strReportTag = "_DTGNCD";
                }
                else if (frm.rdbPXDT.Checked == true)
                {
                    bHd_Tu_In = true;
                    strReportTag = "_DT";
                }
                else if (frm.rdbPX_DT_PDF.Checked == true)
                {
                    bHd_Tu_In = true;
                    strReportTag = "_DTPDF";
                }
                else if (frm.rdbPX_DT_CD.Checked == true)
                {
                    bHd_Tu_In = true;
                    strReportTag = "_DTCD";
                }
            }



            else if (Common.Inlist(strMa_Ct, "SOCP"))
            {
                DataRow drCtPx = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
                frmIn_Ct_SO frm = new frmIn_Ct_SO();
                frm.Load(drPH);
                strReport_File = "";
                strReportTag = "LXHCP";

                //if ((bool)drPH["Duyet"] && !(bool)drPH["Duyet_Huy"])
                //    frm.Load(drPH);

                //else
                //{
                //    Common.MsgOk("Chứng từ chưa được duyệt bởi PTCKT hoặc lệnh đã được đóng. Không cho phép in  !!!");
                //}

                if (frm.isAccept)
                {
                    if (frm.rdbLXH.Checked == true)
                    {
                        if (strMa_Tte == "USD")
                        {
                            frm.rdbTien_Nt.Checked = true;
                            strReportTag = "LXHCP_NT";
                        }
                        else
                            strReportTag = "LXHCP";
                        bIs_Print_Barem = frm.rdbLXH.Checked;

                        bHd_Tu_In = frm.rdbLXH.Checked;
                        bIs_Vnd = frm.rdbTien_VND.Checked;
                    }

                    if (frm.rdbLXH_GH.Checked == true)
                    {
                        strReportTag = "LXHCP_GH";
                        bSOCP_GH = true;

                    }

                }
                else
                    return false;
            }
            else if (Common.Inlist(strMa_Ct, "LXH"))
            {
                DataRow drCtPx = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
                string strSQL = " SELECT * FROM R04CTSO WHERE Ma_Ct = 'LXH' AND Stt = '" + strStt + "' AND Ht_Gn NOT LIKE 'GK%' AND Stt_Org IN (SELECT Stt FROM R80PH WHERE Duyet_Huy = 1)";
                DataTable dtSOHuy = SQLExec.ExecuteReturnDt(strSQL);
                if (dtSOHuy.Rows.Count > 0)
                {
                    DataRow drSoHuy = dtSOHuy.Rows[0];
                    Common.MsgOk("Phiếu xác nhận đơn hàng " + drSoHuy["So_Ct"].ToString().Substring(0, 13) + " đã bị đóng. Không cho phép in");
                    return false;
                }
                strReport_File = "rptCT_";
                strReportTag = "LGH";
               
            }
            else if (strMa_Ct == "NM")
            {
                DataTable dtTable_Ct = DataTool.SQLGetDataTable(strTable_Ct, "*", "Stt = '" + strStt + "'", "");
                string strTen_Vt = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", dtTable_Ct.Rows[0]["Ma_Vt"].ToString());
                if (dtTable_Ct.Rows.Count < 4 && strTen_Vt.Length < 100 && dtTable_Ct.Rows[0]["Ma_Nvu"].ToString() != "MH06")
                    strReportTag = "_2D";
                else if (dtTable_Ct.Rows.Count < 2 && strTen_Vt.Length < 100 && dtTable_Ct.Rows[0]["Ma_Nvu"].ToString() == "MH06")
                    strReportTag = "_2D";
            }
            else if (strMa_Ct == "NK")
            {                                  
                //frmIn_Ct_PNK frm1 = new frmIn_Ct_PNK();
                //frm1.Load();

                //if (frm1.rdbTien_Nt.Checked == true)
                //    strReportTag = "_NT";
               
            }
            else if (strMa_Ct == "PXKV")
            {
                frmIn_Ct_PxKv frm = new frmIn_Ct_PxKv();
                frm.Load(drPH);

                if (frm.isAccept)
                {
                    if (frm.rdbPhieu_Xuat.Checked == true)
                        strReportTag = "PXKV";
                    else if (frm.rdbPx_BBXN2.Checked == true)
                        strReportTag = "BBNM";
                    else if (frm.rdbPx_BBXN3.Checked == true)
                        strReportTag = "BBNM3";


                    strLien = frm.txtLien.Text;
                }
                else
                    return false;
            }
            else if (Common.Inlist(strMa_Ct, "BBPT,BBTH"))
            {
                frmIn_Ct_BB frm = new frmIn_Ct_BB();
                frm.Load(drPH);
                if (frm.isAccept)
                {
                    if (frm.rdbIn_Barcode.Checked == true)
                    {
                        ProcessBarcodePT(strStt, "", bPreview);
                        return false;
                    }
                }
                if (!frm.isAccept)
                    return false;
            }
            else if (strMa_Ct == "PNPT")
            {
                frmIn_Ct_PNPT frm = new frmIn_Ct_PNPT();
                frm.Load(drPH);

                if (frm.isAccept)
                {
                    if (frm.rdbIn_Barcode.Checked == true)
                    {
                        ProcessBarcodePT(strStt, "", bPreview);
                        return false;
                    }
                    if (!frm.isAccept)
                        return false;
                }
            }
            else if (Common.Inlist(strMa_Ct, "DNX"))
            {
                frmIn_Ct_DNX frm = new frmIn_Ct_DNX();
                frm.Load(drPH);
                if (frm.isAccept)
                {
                    if (frm.rdbPhieu_Xuat.Checked)
                        strReportTag = "DNX";
                    else
                    {
                        strReportTag = "BBM";
                        bIs_Print_Barem = true;
                    }
                }
            }
            else if (Common.Inlist(strMa_Ct, "DT") && !Common.Inlist(strMa_Ct, "DTCP,DTNA"))
            {
                frmIn_Ct_DT frm = new frmIn_Ct_DT();
                frm.Load(drPH);

                if (frm.isAccept)
                {
                    if (frm.rdbCt_Dt.Checked == true && frm.rdbTien_VND.Checked == true)
                        strReportTag = "DT";
                    else if (frm.rdbCt_Dt.Checked == true && frm.rdbTien_Nt.Checked == true)
                        strReportTag = "DT_NT";
                    else if (frm.rdbCt_Po.Checked == true && frm.rdbTien_VND.Checked == true)
                        strReportTag = "POPT";
                    else if (frm.rdbCt_Po.Checked == true && frm.rdbTien_Nt.Checked == true)
                        strReportTag = "POPT_NT";


                }
                else
                    return false;

            }

            else if (Common.Inlist(strMa_Ct, "NMHH,NMGK"))
            {
                frmIn_Ct_NM frm = new frmIn_Ct_NM();
                frm.Load();
                if (frm.isAccept)
                {
                    if (frm.rdbPx_BBXN.Checked == true)
                    {
                        strReportTag = "_BBNM";
                        strLien = frm.txtLien.Text;
                    }
                    else
                        strReportTag = "_MH";
                }
                else
                    return false;
            }
            else if (Common.Inlist(strMa_Ct, "PXCP"))
            {
                frmIn_Ct_PXCP frm = new frmIn_Ct_PXCP();
                frm.Load();
                if (frm.isAccept)
                {
                    strLien = frm.txtLien.Text;
                    if (frm.rdbBBXN_CP_TMN.Checked == true)
                    {
                        strReportTag = "BBXN_CP_TMN";
                    }
                    else
                        strReportTag = "BBXN_TMN_KH";
                }
                else
                    return false;
            }
            //else if (strMa_Ct == "DTNA" && !bPreview)
            //    strReportTag = "Print";

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("HD_TU_IN", bHd_Tu_In ? 1 : 0);
            ht.Add("IS_PRINT_BAREM", bIs_Print_Barem ? 1 : 0);
            ht.Add("IS_VND", bIs_Vnd ? 1 : 0);
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
            drHeader["Report_File"] = drDmCt["Report_File"] + strReportTag;

            if (Element.sysLanguage == enuLanguageType.Vietnamese)
            {

                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoney(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
                if ((strMa_Ct == "HDXK" || strMa_Ct == "HD") && strMa_Tte == "USD")
                    dtHeader.Rows[0]["Doc_Tien"] = Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte);

            }
            else if (Element.sysLanguage == enuLanguageType.English)
                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte).Replace("Fourty", "Forty") : Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
            else
                dtHeader.Rows[0]["Doc_Tien"] = Common.ReadNumberC(Convert.ToDouble(drHeader["TTien_Nt"]));

            if (Element.sysLanguage == enuLanguageType.Vietnamese && Common.Inlist(strMa_Ct, "DT"))
            {
                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd_ ? Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte).Replace("Fourty", "Forty") : Common.ReadMoney(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());

                //dtHeader.Rows[0]["Doc_TienK"] = !bIs_Vnd ? Common.ReadMoney(Math.Abs(Convert.ToDouble(drHeader["TTien_Nt"])), strMa_Tte) : Common.ReadMoney(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
            }
            else if (Element.sysLanguage == enuLanguageType.Vietnamese && Common.Inlist(strMa_Ct, "HDXK,HD") && strMa_Tte != Element.sysMa_Tte.ToString())
            {
                dtHeader.Rows[0]["Doc_TienE"] = Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte).Replace("Fourty", "Forty") + ".";

            }

            if (strMa_Ct.StartsWith("BN"))
            {
                if (strSo_Ct == string.Empty)
                {
                    dtHeader.Rows[0]["So_Ct"] = "";
                    dtHeader.Rows[0]["Ngay_Ct_In"] = string.Empty;
                }


            }

            //Số liên
            string[] Lien = strLien.Trim().Split(',');
            if (Lien.Length >= 0)
            {
                string strL = Lien[0];
                dtHeader.Rows[0]["SubTitle2"] = strL == "1" ? "Liên 1: Lưu " : strL == "2" ? "Liên 2: Giao cho người mua" : "Liên 3: Nội bộ";
                dtHeader.AcceptChanges();
            }

            string strColPrint = "Print_Count";
            int iSolanPrint = Convert.ToInt16(drPH[strColPrint]);
            string strCurent_Log = Common.GetCurrent_Log();
            string Print_Log = strCurent_Log.Substring(0, 11) + strCurent_Log.Substring(13);
            string strPrint_Name = string.Empty;

            //Nếu xem dự trù đơn hàng mà chưa in thi enable nút in
            if (strMa_Ct == "DT" && bPreview && Common.InlistLike(strReportTag, "POPT"))
                frmPrint.viewReport.Toolbar.Tools[2].Id = 1000; //Enable Button Print 
            else if (strMa_Ct == "DT" && !bPreview && Common.InlistLike(strReportTag, "POPT")) // ngược lại thì cập nhật print cout
            {
                string sqlstr = "UPDATE R80PH SET " + strColPrint + " = " + iSolanPrint + " + 1 , USER_PRINT = '" + Print_Log + "', Is_Vt_Nhan = 1  WHERE Stt = '" + strStt + "'";
                if (SQLExec.Execute(sqlstr))
                {
                    drPH["Is_Vt_Nhan"] = true;
                    drPH["Print_Count"] = Convert.ToDouble(drPH["Print_Count"]) + 1;
                    drPH["User_Print"] = Print_Log;
                }
                ////Tự động lấy ngày in PO thành ngày đặt hàng tạm bỏ đi ngày 29/3/2021
                //Hashtable ht1 = new Hashtable();
                //ht1.Add("NGAY_DKGH", DateTime.Now);
                //sqlstr = "UPDATE R04CTPO SET Ngay_DkGH = @Ngay_DkGh WHERE Stt = '" + strStt + "'";
                //SQLExec.Execute(sqlstr,ht1,CommandType.Text);
            }
            if (Common.Inlist(strMa_Ct, "PXBR,PXDC"))//,PX
            {
                if (bPreview && !Common.InlistLike(strReportTag, "_BB"))
                    frmPrint.viewReport.Toolbar.Tools[2].Id = 1000; //Enable Button Print 
                else if (!bPreview && !Common.InlistLike(strReportTag, "_BB"))
                {
                    string sqlstr = "UPDATE R80PH SET " + strColPrint + " = " + iSolanPrint + " + 1 , USER_PRINT = '" + Print_Log + "' WHERE Stt = '" + strStt + "'";
                    if (SQLExec.Execute(sqlstr))
                    {

                        drPH["Print_Count"] = Convert.ToDouble(drPH["Print_Count"]) + 1;
                        drPH["User_Print"] = Print_Log;
                    }
                }
            }
            if (Common.Inlist(strMa_Ct, "LXH,SO,SOCP"))//,PX
            {

                //string strColPrint = "Print_Count";
                // Gán giá trị tiền = 0 khi in phiếu đối tượng không thấy giá phiếu xuất
                if (strMa_Ct == "SOCP" && DataTool.SQLCheckExist("R00Object", "Object_ID", "ACCESS_PRICE_PX") && !Common.CheckPermission("ACCESS_PRICE_PX", enuPermission_Type.Allow_Access))
                {
                    foreach (DataColumn dc in dtDetail.Columns)
                    {
                        if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TIEN"))
                        {
                            if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
                            {
                                //Gán cột dữ liệu về 0
                                foreach (DataRow dr in dtDetail.Rows)
                                {
                                    dr[dc] = 0;
                                }
                            }
                        }
                    }
                    foreach (DataColumn dc in dtHeader.Columns)
                    {
                        dtHeader.Rows[0]["Doc_Tien"] = string.Empty;
                        if (dc.ColumnName.StartsWith("TTIEN"))
                        {
                            if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
                            {
                                //Gán cột dữ liệu về 0
                                foreach (DataRow dr in dtHeader.Rows)
                                {
                                    dr[dc] = 0;
                                }
                            }
                        }
                    }
                }

                //

                //Neu xem thi Remove btPrint di.Nguoc lai thi cap nhat Print_Count
                if (bPreview)
                    frmPrint.viewReport.Toolbar.Tools[2].Id = 1000; //Enable Button Print 
                else
                {
                    if (Common.Inlist(strMa_Ct, "LXH") && Convert.ToInt16(drPH[strColPrint]) > 0)
                    {
                        if (!Common.CheckPermission("IS_PRINT_LXH", enuPermission_Type.Allow_Access))
                        {
                            bPreview = true;
                            frmPrint.viewReport.Toolbar.Tools[2].Id = 1000; //Enable Button Print 
                        }
                        else
                        {
                            frmGhi_Chu frmGhi_Chu_Print = new frmGhi_Chu();
                            frmGhi_Chu_Print.Load(drPH);
                            if (!frmGhi_Chu_Print.isAccept)
                                return false;
                        }
                    }
                }

                if (dtHeader.Columns.Contains(strColPrint) && !bPreview)
                {


                    //if (!bSOCP_GH) //!(bool)dtHeader.Rows[0]["Duyet"] &&
                    //{
                    //    bPreview = true;
                    //    frmPrint.viewReport.Toolbar.Tools[2].Id = 1000; //Enable Button Print 
                    //}

                    //else
                    //{
                    if (bSOCP_GH == false)
                    {

                        string sqlstr = string.Empty;
                        if (strMa_Ct == "SOCP" && !Common.CheckPermission("PRINT_COUNT_SO", enuPermission_Type.Allow_Access))
                        {
                            sqlstr = string.Empty;
                        }
                        else
                        {
                            sqlstr = "UPDATE R80PH SET " + strColPrint + " = " + iSolanPrint + " + 1 , USER_PRINT = '" + Print_Log + "'  WHERE Stt = '" + strStt + "'";
                            if (SQLExec.Execute(sqlstr))
                            {
                                drPH["Print_Count"] = Convert.ToDouble(drPH["Print_Count"]) + 1;
                                drPH["User_Print"] = Print_Log;
                            }
                        }

                        System.Threading.Thread.Sleep(1000);
                    }

                    //}

                }

            }


            if (Common.Inlist(strMa_Ct, "PXKV,NMHH,PXCP") || (strMa_Ct == "HD" && bHd_Tu_In == true))
            {


                if (bPreview)
                {
                    frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);

                }
                else
                {

                    foreach (string strLienCount in Lien)
                    {

                        if (Common.Inlist(strMa_Ct, "PXKV,PXCP"))
                            dtHeader.Rows[0]["SubTitle2"] = strLienCount == "1" ? "Liên 1 : Lưu" : strLienCount == "2" ? "Liên 2 : Chuyển phòng kế toán" : "Liên 3 : Giao khách hàng";
                        else if (Common.Inlist(strMa_Ct, "NMHH"))
                            dtHeader.Rows[0]["SubTitle2"] = strLienCount == "1" ? "Liên 1 : Lưu" : strLienCount == "2" ? "Liên 2 : Giao người mua" : "Liên 3 : Giao khách hàng";
                        else if (Common.Inlist(strMa_Ct, "BN") && strReportTag == "_VTB")
                            dtHeader.Rows[0]["SubTitle2"] = strLienCount == "1" ? "Liên 1, Lưu Copy 1, Bank's copy" : "Liên 2, Giao khách hàng Copy 2, Customer's copy";
                        else
                            dtHeader.Rows[0]["SubTitle2"] = strLienCount == "1" ? "Liên 1 : Lưu" : strLienCount == "2" ? "Liên 2 : Giao người mua" : "Liên 3 : Nội bộ";

                        dtHeader.AcceptChanges();

                        if (frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, string.Empty))
                        {
                            SQLExec.Execute("UPDATE R80PH SET " + strColPrint + " = " + iSolanPrint + " + 1 , USER_PRINT = '" + Print_Log + "'  WHERE Stt = '" + strStt + "'");

                            System.Threading.Thread.Sleep(1000);
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                }

                return true;
            }
            if (Common.Inlist(strMa_Ct, "PX"))
            {
                if (bPreview)
                    frmPrint.viewReport.Toolbar.Tools[2].Id = 1000; //Enable Button Print 

                SQLExec.Execute("UPDATE R80PH SET " + strColPrint + " = " + iSolanPrint + " + 1 , USER_PRINT = '" + Print_Log + "'  WHERE Stt = '" + strStt + "'");
            }
            //Xử lý in LXH thêm xà lan tại đây 8/4/2026 BỎ CÁI NÀY ĐI && drCT["So_Xa_Lan_Tau"].ToString().
            if (strMa_Ct == "LXH" && drCT["So_Xa_Lan_Tau"].ToString() != "" && !bPreview && drCT["Ma_Kho"].ToString() != "GK_055POM1")
            {
                strLien = "1,2";
                string[] LienLXH = strLien.Trim().Split(',');
                foreach (string strLienCount in LienLXH)
                {
                    if (strLienCount == "1")
                    {
                        dtHeader.Rows[0]["Report_File"] = drDmCt["Report_File"] + strReportTag;
                        frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
                        System.Threading.Thread.Sleep(1000);
                    }
                        
                    else
                    {
                        dtHeader.Rows[0]["Report_File"] = drDmCt["Report_File"] + strReportTag + "_TAU";
                        frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
                        System.Threading.Thread.Sleep(1000);
                    }
                        

                    //dtHeader.AcceptChanges();
                    //frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
                    //System.Threading.Thread.Sleep(1000);

                }

                return true;
            }
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
        }
        public static bool Print_Option(string strStt, bool bPreview, bool bShowDialog, ref bool bInVisibleNextPrint)
        {
            DataRow drPH = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();

            if (drPH == null)
            {
                Common.MsgCancel("Phiếu không tồn tại, không in được");
                return false;
            }

            string strMa_Ct = (string)drPH["Ma_Ct"];
            //string strMa_Tte = "VND";
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            bool bIs_Vnd = true;

            bool bHd_Tu_In = false;
            bool bLoai_Tte = true;
            bool bIs_Print_Barem = false;
            string strReport_File = string.Empty;


            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            DataTable dtHeader;
            DataTable dtDetail;


            strTable_Ph = (string)drDmCt["Table_Ph"];
            strTable_Ct = (string)drDmCt["Table_Ct"];
            strReport_File = (string)drDmCt["Report_File"];

            DataRow drPHCt = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
            string strMa_Tte = (string)drPHCt["Ma_Tte"];

            DataRow drCT = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
            if ((string)drCT["Ma_Tte"] == Element.sysMa_Tte)
                bIs_Vnd = true;
            else
                bIs_Vnd = false;

            string strColPrint = "Print_Count";
            int iSolanPrint = Convert.ToInt16(drPH[strColPrint]);
            string strCurent_Log = Common.GetCurrent_Log();
            string Print_Log = strCurent_Log.Substring(0, 11) + strCurent_Log.Substring(13);

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("HD_TU_IN", bHd_Tu_In ? 1 : 0);
            ht.Add("IS_PRINT_BAREM", bIs_Print_Barem ? 1 : 0);
            ht.Add("IS_VND", bIs_Vnd ? 1 : 0);
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
            drHeader["Report_File"] = drDmCt["Report_File"] + strReportTag;

            SQLExec.Execute("UPDATE R80PH SET " + strColPrint + " = " + iSolanPrint + " + 1 , USER_PRINT = '" + Print_Log + "'  WHERE Stt = '" + strStt + "'");


            return frmPrint.Load(dtHeader.Rows[0], dtDetail, true, true);

            //return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
        }
        public static bool Print_BTTB(string strStt, bool bPreview, bool bShowDialog, ref bool bInVisibleNextPrint)
        {
            DataRow drPH = DataTool.SQLGetDataRowByID("R06PH_BTTB", "Stt", strStt);
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();

            if (drPH == null)
            {
                Common.MsgCancel("Phiếu không tồn tại, không in được");
                return false;
            }

            string strMa_Ct = (string)drPH["Ma_Ct"];
            //string strMa_Tte = "VND";
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            bool bIs_Vnd = true;
            bool bIs_Vnd_ = true;
            bool bIs_Tb = false;
            bool bLoai_Tte = true;
            bool bIs_Print_Barem = false;
            string strReport_File = string.Empty;

            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            DataTable dtHeader;
            DataTable dtDetail;


            strTable_Ph = (string)drDmCt["Table_Ph"];
            strTable_Ct = (string)drDmCt["Table_Ct"];
            strReport_File = (string)drDmCt["Report_File"];


            DataRow drPHCt = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
            string strMa_Tte = (string)drPHCt["Ma_Tte"];

            DataRow drCT = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
            if ((string)drCT["Ma_Tte"] == Element.sysMa_Tte)
                bIs_Vnd_ = true;
            else
                bIs_Vnd_ = false;


            // XỬ LÝ BTNB
            if (strMa_Ct == "BTNB" && (string)drPHCt["Ma_Dt"] == "PCNTT")
                strReportTag = "_CNTT";

            if (strMa_Ct == "BBBG")
            {
                frmIn_BBBG frm = new frmIn_BBBG();
                frm.Load(drPH, false);
                bIs_Tb = frm.chkIs_Tb.Checked;
            }
            if (strMa_Ct == "GRVC")
            {
                frmIn_GRVC frm = new frmIn_GRVC();
                frm.Load(drPH, false);
                bIs_Tb = frm.chkIs_Tb.Checked;
            }
            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("IS_TB", bIs_Tb);
            //ht.Add("IS_PRINT_BAREM", bIs_Print_Barem ? 1 : 0);
            ht.Add("IS_VND", bIs_Vnd ? 1 : 0);
            ht.Add("LOGIN_USER", Element.sysUser_Id);
            ht.Add("LANGUAGE_TYPE", "V");


            DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintVoucher_BTTB", ht, CommandType.StoredProcedure);

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
            drHeader["Report_File"] = drDmCt["Report_File"] + strReportTag;

            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
        }
        public static bool Print_CTSC(string strStt, int iStt0, bool bPreview, bool bShowDialog, ref bool bInVisibleNextPrint)
        {
            DataRow drPH = DataTool.SQLGetDataRowByID("R06PH_BTTB", "Stt", strStt);
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();

            if (drPH == null)
            {
                Common.MsgCancel("Phiếu không tồn tại, không in được");
                return false;
            }

            string strMa_Ct = (string)drPH["Ma_Ct"];
            //string strMa_Tte = "VND";
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            bool bIs_Vnd = true;

            bool bHd_Tu_In = false;

            bool bIs_Print_Barem = false;
            string strReport_File = string.Empty;

            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            DataTable dtHeader;
            DataTable dtDetail;


            strTable_Ph = (string)drDmCt["Table_Ph"];
            strTable_Ct = (string)drDmCt["Table_Ct"];
            strReport_File = (string)drDmCt["Report_File"];


            DataRow drPHCt = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
            string strMa_Tte = (string)drPHCt["Ma_Tte"];

            DataRow drCT = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("STT0", iStt0);
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("IS_PRINT_BAREM", bIs_Print_Barem ? 1 : 0);
            ht.Add("IS_VND", bIs_Vnd ? 1 : 0);
            ht.Add("LOGIN_USER", Element.sysUser_Id);
            ht.Add("LANGUAGE_TYPE", "V");


            DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintVoucher_CTSC", ht, CommandType.StoredProcedure);

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
            drHeader["Report_File"] = drDmCt["Report_File"] + strReportTag;

            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
        }
        public static bool PrintHDDT(string strStt, string strMa_Ct, string strMa_Tte, string strReport_File)
        {
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            bool bIs_Vnd = true;
            DataTable dtHeader;
            DataTable dtDetail;

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();

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

            return frmPrint.Load(dtHeader.Rows[0], dtDetail, true, true);
        }
        public static bool PrintBarcode(string strBarcode, bool bIs_Barem, bool bPreview, string strPrint_Name, bool bGC)
        {
            Hashtable ht = new Hashtable();
            ht.Add("BARCODE", strBarcode);
            ht.Add("IS_BAREM", bIs_Barem);
            ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

            DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_PrintBarcode", ht, CommandType.StoredProcedure);

            dtBarcode.Columns.Add("REPORT_FILE", typeof(string));

            DataRow drHeader = dtBarcode.Rows[0];

            string strGrade_ID_XK = Parameters.GetParaValue("MAC_THEP_XK_LIST").ToString();

            if ((bool)dtBarcode.Rows[0]["Is_New"] && Common.Inlist(dtBarcode.Rows[0]["Grade_ID"].ToString(), "G30,G31"))
                drHeader["Report_File"] = "rptBarcode_TT_GC";
            else if ((bool)dtBarcode.Rows[0]["Is_New"] && !Common.Inlist(dtBarcode.Rows[0]["Grade_ID"].ToString(), strGrade_ID_XK) && !bGC)
                drHeader["Report_File"] = "rptBarcode_TT_ND";
            else if ((bool)dtBarcode.Rows[0]["Is_New"] && Common.Inlist(dtBarcode.Rows[0]["Grade_ID"].ToString(), strGrade_ID_XK) && !bGC)
                drHeader["Report_File"] = "rptBarcode_TT_XK";
            else if ((bool)dtBarcode.Rows[0]["Is_New"] && !Common.Inlist(dtBarcode.Rows[0]["Grade_ID"].ToString(), strGrade_ID_XK) && bGC)
                drHeader["Report_File"] = "rptBarcode_TT_ND_GC";
            else if ((bool)dtBarcode.Rows[0]["Is_New"] && Common.Inlist(dtBarcode.Rows[0]["Grade_ID"].ToString(), strGrade_ID_XK) && bGC)
                drHeader["Report_File"] = "rptBarcode_TT_XK_GC";
            else
                drHeader["Report_File"] = "rptBarcode_TT";

            // Bằng thêm để tính số lần in
            SQLExec.Execute("UPDATE R81DMBARCODE SET Print_Count = Print_Count + 1 WHERE Barcode = '" + strBarcode + "'");

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drHeader, dtBarcode, bPreview, strPrint_Name);
        }
        public static bool PrintBarcodePT(string strBarcode1, string strBarcode2, bool bPreview, string strPrint_Name)
        {
            Hashtable ht = new Hashtable();
            ht.Add("BARCODE1", strBarcode1);
            ht.Add("BARCODE2", strBarcode2);

            ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

            DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_PrintBarcodePT", ht, CommandType.StoredProcedure);

            dtBarcode.Columns.Add("REPORT_FILE", typeof(string));

            DataRow drHeader = dtBarcode.Rows[0];

            drHeader["Report_File"] = "rptBarcode_PT";
            //Lưu lại user print
            if (!bPreview)
                SQLExec.Execute("UPDATE R81DMBARCODEPT SET User_Print = '" + Common.GetCurrent_Log() + "' WHERE Barcode = '" + strBarcode1 + "' OR Barcode = '" + strBarcode2 + "'");

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drHeader, dtBarcode, bPreview, strPrint_Name);
        }
        public static bool Print_LenhSanXuat(string strStt, bool bPreview, bool bShowDialog, ref bool bInVisibleNextPrint, string strReport_File)
        {
            bool bCT = false;

            if (strReport_File == "rptLenhSanXuatCt")
                bCT = true;


            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();


            bool bIs_Vnd = true;


            DataTable dtHeader;
            DataTable dtDetail;

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("IS_CT", bCT);

            DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintLenhSX", ht, CommandType.StoredProcedure);

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
            drHeader["Title"] = "Lệnh Sản xuất";
            drHeader["Report_File"] = strReport_File;

            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
        }
        public static bool Print2C(string strMa_Dt_CbNv, bool bPreview, bool bShow, string strReportFile)
        {
            Hashtable ht = new Hashtable();
            ht.Add("MA_DT_CBNV", strMa_Dt_CbNv);

            DataSet dsHSNV = SQLExec.ExecuteReturnDs("sp_PrintThongTinCNNV", ht, CommandType.StoredProcedure);

            DataTable dtHeader = dsHSNV.Tables[0];
            DataTable dtDetail = dsHSNV.Tables[1];


            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

            dtHeader.Rows[0]["Report_File"] = strReportFile;
            dtHeader.Rows[0]["Ngay_Ct"] = DateTime.Now;

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShow);
        }
        public static bool PrintPhieuLuong(int iThang, int iNam, bool bPreview, string strMa_Dt_CbNv)
        {
            string strReportFile = "rptPhieuLuong";

            Hashtable ht = new Hashtable();

            ht.Add("THANG", iThang);
            ht.Add("NAM", iNam);
            ht.Add("MA_DT_CBNV", strMa_Dt_CbNv);

            DataSet ds = SQLExec.ExecuteReturnDs("Sp_HRM_PrintPhieuLuong", ht, CommandType.StoredProcedure);
            DataTable dtHeader = ds.Tables[0];
            DataTable dtDetail = ds.Tables[1];


            if (!dtHeader.Columns.Contains("REPORT_FILE"))
                dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            if (!dtHeader.Columns.Contains("NGAY_CT"))
                dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

            dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
            dtHeader.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);

        }
        public static void Update_Info(DataRow drViewPh, string strStt, string strMa_Ct)
        {
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
            string strMa_Dt = string.Empty;
            string strMa_Dt_CbNv = string.Empty;
            if (drDmCt["Table_Ct"].ToString() == "R05CTNX")
            {
                strMa_Dt = SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Dt) FROM " + drDmCt["Table_Ct"].ToString() + " WHERE Stt = '" + strStt + "'").ToString();
                drViewPh["Ten_Dt"] = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", strMa_Dt);
            }
        }
        public static bool ProcessBarcodePT(string strStt, string strBarcode, bool bPreview)
        {

            Hashtable ht_BarPT = new Hashtable();
            ht_BarPT.Add("STT", strStt);
            ht_BarPT.Add("BARCODE", strBarcode);
            DataTable dt = SQLExec.ExecuteReturnDt("sp_BarcodePT_List", ht_BarPT, CommandType.StoredProcedure);
            if (dt.Rows.Count == 0)
            {
                Common.MsgOk("Phiếu chưa được tạo barcode phụ tùng!!! ");
                return true;
            }
            else
            {

                int iStt0_Max = dt.Rows.Count;
                int i = 0;
                int j = 0;
                string strBarcode1 = string.Empty;
                string strBarcode2 = string.Empty;


                for (i = j; j < dt.Rows.Count; i = +j)
                {
                    if (iStt0_Max > 0)
                    {
                        strBarcode1 = Convert.ToString(dt.Rows[i]["Barcode"]);
                        iStt0_Max = iStt0_Max - 1;

                        if (iStt0_Max == 0)
                            strBarcode2 = string.Empty;
                    }
                    else
                        strBarcode1 = string.Empty;

                    if (iStt0_Max > 0)
                    {
                        strBarcode2 = Convert.ToString(dt.Rows[i + 1]["Barcode"]);
                        iStt0_Max = iStt0_Max - 1;
                    }
                    else
                        strBarcode2 = string.Empty;

                    string strSQLExec = "SELECT * FROM R81EQUIPMENTINFO WHERE Host_IP = '" + MachineInfo.GetHostIP() + "'";
                    DataTable dtEquipment = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
                    if (dtEquipment.Rows.Count > 0)
                    {
                        DataRow drEquipment = dtEquipment.Rows[0];
                        if (drEquipment != null)
                            Variables.strPrint_Barcode = (string)drEquipment["Print_Barcode"];
                    }
                    if (PrintBarcodePT(strBarcode1, strBarcode2, bPreview, Variables.strPrint_Barcode))
                        j = j + 2;



                }
                return true;
            }
        }
        public static bool PrintTruck_In_Out(string strStt, string strTruck_In_Out, string strReport_File, bool bPreview, string strPrint_Name)
        {
            Hashtable ht = new Hashtable();
            ht.Add("TRUCK_IN_OUT", strTruck_In_Out);
            ht.Add("STT", strStt);
            ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

            DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_PrintTruck_In_Out", ht, CommandType.StoredProcedure);
            if (dtBarcode.Rows.Count == 0)
            {
                Common.MsgCancel("Phiếu cân này đã hoàn tất cân vào và cân ra.Không in được. F12 để in lại phiếu");
                return false;
            }

            dtBarcode.Columns.Add("REPORT_FILE", typeof(string));
            DataRow drHeader = dtBarcode.Rows[0];

            drHeader["Report_File"] = strReport_File;

            if (drHeader.Table.Columns.Contains("Printed_In"))
            {
                if (Convert.ToInt32(drHeader["Printed_In"]) == 0)
                    drHeader["Printed_In"] = 1;
                else
                    drHeader["Printed_In"] = Convert.ToInt32(drHeader["Printed_In"]) + 1;
            }

            if (drHeader.Table.Columns.Contains("Printed_Out"))
            {
                if (Convert.ToInt32(drHeader["Printed_Out"]) == 0)
                    drHeader["Printed_Out"] = 1;
                else
                    drHeader["Printed_Out"] = Convert.ToInt32(drHeader["Printed_Out"]) + 1;
            }

            //Dem so lan in
            string strTable_Name = "R80PH_SCALE";
            string strColumnKey = "Stt";
            string strValueKey = drHeader["Stt"].ToString();
            string strColumnUpdate = strTruck_In_Out == "IN" ? "Printed_In" : "Printed_Out";

            if (bPreview)
            {
                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                return frmPrint.Load(drHeader, dtBarcode, bPreview, strPrint_Name, strTable_Name, strColumnKey, strValueKey, strColumnUpdate, true);
            }
            else
            {
                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                if (!frmPrint.Load(drHeader, dtBarcode, bPreview, strPrint_Name))
                    return false;

                Hashtable htPara = new Hashtable();
                htPara.Add("TABLENAME", strTable_Name);
                htPara.Add("COLUMNKEY", strColumnKey);
                htPara.Add("VALUEKEY", strValueKey);
                htPara.Add("COLUMNUPDATE", strColumnUpdate);

                return SQLExec.Execute("sp_UpdatePrinted", htPara, CommandType.StoredProcedure);
            }
        }
        public static bool PrintCtXBarcodePT(string strStt, bool bPreview, bool bShowDialog)
        {
            DataTable dtHeader;
            DataTable dtDetail;
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();

            frmIn_Ct_DNX frm = new frmIn_Ct_DNX();
            frm.Load();
            if (frm.isAccept)
            {

                if (frm.rdbPX_Barcode.Checked == true)
                {
                    DataRow drPH = DataTool.SQLGetDataRowByID("R05CTX_BARCODEPT", "Stt", strStt);

                    if (drPH == null)
                    {
                        Common.MsgCancel("Phiếu không tồn tại, không in được");
                        return false;
                    }



                    Hashtable ht = new Hashtable();
                    ht.Add("STT", strStt);
                    ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                    DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintXuatBarcodePT", ht, CommandType.StoredProcedure);

                    dtHeader = dsPrintVoucher.Tables[0];
                    dtDetail = dsPrintVoucher.Tables[1];

                    if (dtDetail.Rows.Count == 0)
                    {
                        Common.MsgCancel("Phiếu này không có chi tiết.Không in được");
                        return false;
                    }

                    dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                    dtHeader.Columns.Add("TITLE", typeof(string));

                    DataRow drHeader = dtHeader.Rows[0];


                    drHeader["Report_File"] = "rptCT_XBarcodePT";


                    frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);
                }

                else if (frm.rdbPhieu_Xuat.Checked == true)
                {
                    string strStt_Org = SQLExec.ExecuteReturnValue("SELECT Stt_Org FROM R80PH_BARCODEPT WHERE Stt = '" + strStt + "'").ToString();
                    Hashtable ht = new Hashtable();
                    ht.Add("STT", strStt_Org);
                    ht.Add("MA_CT", "DNX");
                    ht.Add("HD_TU_IN", 0);
                    ht.Add("IS_PRINT_BAREM", 0);
                    ht.Add("IS_VND", 1);
                    ht.Add("LOGIN_USER", Element.sysUser_Id);
                    ht.Add("LANGUAGE_TYPE", "V");

                    DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintVoucher", ht, CommandType.StoredProcedure);

                    dtHeader = dsPrintVoucher.Tables[0];
                    dtDetail = dsPrintVoucher.Tables[1];

                    dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                    dtHeader.Columns.Add("TITLE", typeof(string));


                    DataRow drHeader = dtHeader.Rows[0];


                    drHeader["Report_File"] = "rptCT_DNX_QR";


                    return frmPrint.Load(drHeader, dtDetail, true, true);
                }
            }
            return true;
        }
        public static bool PrintScale_Out_ThanhCuon(string strStt, bool bPreview, bool bShowDialog, string strTable_Name)
        {
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            string strReport_File = string.Empty;
            string strTen_Dt = string.Empty;
            string strTen_Cong_Trinh = string.Empty;
            string strMa_Dt_CbNv = string.Empty;
            string strStt_LXH = string.Empty;
            string strSQLExec_Name = string.Empty;
            bool bIs_Co_Tinh = false;
            //bool bIs_TPHH = false;
            string strTruck_In_Out = string.Empty;

            DataRow drPH = DataTool.SQLGetDataRowByID(strTable_Name, "Stt", strStt);

            if (drPH == null)
            {
                Common.MsgCancel("Phiếu không tồn tại, không in được");
                return false;
            }

            string strMa_Ct = (string)drPH["Ma_Ct"];

            //string strMa_Vt_Sp = string.Empty;

            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            DataTable dtHeader;
            DataTable dtDetail;

            strTable_Ph = (string)drDmCt["Table_Ph"];
            strTable_Ct = (string)drDmCt["Table_Ct"];

            DataTable dtCt = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM " + strTable_Ct);
            string strMa_Vt_Sp_List = "";

            frmChon_In_Scale frmIn_Scale = new frmChon_In_Scale();
            frmIn_Scale.Load(strStt);

            if (!frmIn_Scale.isAccept)
                return false;
            else
            {



                if (strTable_Name == "R80PH_SCALE")
                    strReportTag += frmIn_Scale.rdbTruck_In.Checked ? frmIn_Scale.rdbTruck_In.Name.Substring(3, frmIn_Scale.rdbTruck_In.Name.Length - 3)
                        : frmIn_Scale.rdbTruck_Out.Checked ? frmIn_Scale.rdbTruck_Out.Name.Substring(3, frmIn_Scale.rdbTruck_Out.Name.Length - 3)
                        : frmIn_Scale.rdbScale_Out.Checked ? frmIn_Scale.rdbScale_Out.Name.Substring(3, frmIn_Scale.rdbScale_Out.Name.Length - 3)
                        : frmIn_Scale.rdbKCS.Checked ? "KCS"
                        : frmIn_Scale.rdbCNXX.Checked ? "CT_CNXX"
                        : "Truck_In";
                else
                    strReportTag = "CT_CNXX";

                if (strTable_Name == "R80PH_SCALE")
                {
                    string strSQLExec = "SELECT * FROM R81EQUIPMENTINFO WHERE Host_IP = '" + MachineInfo.GetHostIP() + "'";
                    DataTable dtEquipment = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
                    if (dtEquipment.Rows.Count > 0)
                    {
                        Variables.strPrint_Report = (string)dtEquipment.Rows[0]["Print_Report"];
                        Variables.strPrint_Barcode = (string)dtEquipment.Rows[0]["Print_Barcode"];
                        Variables.strPrint_Eticket = (string)dtEquipment.Rows[0]["Print_Eticket"];
                    }

                }

                //1.TRUCK_IN, 2.TRUCK_OUT
                if (frmIn_Scale.rdbTruck_In.Checked || frmIn_Scale.rdbTruck_Out.Checked)
                {
                    if (frmIn_Scale.rdbTruck_In.Checked)
                        strTruck_In_Out = "IN";
                    else
                        strTruck_In_Out = "OUT";

                    return PrintTruck_In_Out(strStt, strTruck_In_Out, "rpt" + strReportTag, true, Variables.strPrint_Barcode);
                }
                //3.SCALE_OUT
                else if (frmIn_Scale.rdbScale_Out.Checked)
                {
                    DataTable dtCtLXH = SQLExec.ExecuteReturnDt("SELECT Stt_Org FROM R05CTX_BARCODE WHERE Stt = '" + strStt + "' GROUP BY Stt_Org");
                    foreach (DataRow dr in dtCtLXH.Rows)
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("IS_CO_TINH", bIs_Co_Tinh);
                        ht.Add("STT", strStt);
                        ht.Add("STT_ORG", dr["Stt_Org"].ToString());
                        ht.Add("MA_CT", strMa_Ct);
                        ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                        DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintScale_Out", ht, CommandType.StoredProcedure);

                        dtHeader = dsPrintVoucher.Tables[0];
                        dtDetail = dsPrintVoucher.Tables[1];

                        if (dtDetail.Rows.Count == 0)
                        {
                            Common.MsgCancel("Phiếu này không có chi tiết.Không in được");
                            return false;
                        }

                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        dtHeader.Columns.Add("TITLE", typeof(string));

                        DataRow drHeader = dtHeader.Rows[0];

                        drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
                        drHeader["Report_File"] = "rpt" + strReportTag;

                        RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                        frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, Variables.strPrint_Eticket, "R80PH_SCALE", "Stt", drHeader["Stt"].ToString(), "Printed_OutPut", true);
                    }
                }
                //4-KCS, 5-CNXXDT
                else if (frmIn_Scale.rdbKCS.Checked || frmIn_Scale.rdbCNXX.Checked)
                {
                    //KHÔNG LÀM GÌ VÌ ĐÃ XỬ LÝ Ở FORM IN
                    //strTen_Dt = frmIn_Scale.txtTen_Dt.Text;
                    //strTen_Cong_Trinh = frmIn_Scale.txtTen_Cong_Trinh.Text;
                    //strStt_LXH = frmIn_Scale.CBO
                    //XỬ Lý cho hiện từng LXH có nhóm theo công trình

                }
            }

            return true;
        }
        public static bool PrintScale_Out(string strStt, bool bPreview, bool bShowDialog, string strTable_Name)
        {
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            string strReport_File = string.Empty;
            string strTen_Dt = string.Empty;
            string strTen_Cong_Trinh = string.Empty;
            string strMa_Dt_CbNv = string.Empty;
            string strSQLExec_Name = string.Empty;
            bool bIs_Co_Tinh = false;
            //bool bIs_TPHH = false;
            string strTruck_In_Out = string.Empty;

            DataRow drPH = DataTool.SQLGetDataRowByID(strTable_Name, "Stt", strStt);

            if (drPH == null)
            {
                Common.MsgCancel("Phiếu không tồn tại, không in được");
                return false;
            }

            string strMa_Ct = (string)drPH["Ma_Ct"];

            //string strMa_Vt_Sp = string.Empty;

            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            DataTable dtHeader;
            DataTable dtDetail;

            strTable_Ph = (string)drDmCt["Table_Ph"];
            strTable_Ct = (string)drDmCt["Table_Ct"];

            DataTable dtCt = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM " + strTable_Ct);
            string strMa_Vt_Sp_List = "";


            if (dtCt.Columns.Contains("Ma_Vt_Sp") && dtCt.Columns.Contains("Stt"))
            {
                object objValue = SQLExec.ExecuteReturnValue("SELECT DISTINCT Ma_Vt_Sp + ',' FROM " + strTable_Ct + " WHERE Ma_Vt_Sp <> '' AND Stt = '" + strStt + "' FOR XML PATH('')");

                if (objValue != null && objValue.ToString() != string.Empty)
                    strMa_Vt_Sp_List = objValue.ToString();
                else
                    strMa_Vt_Sp_List = string.Empty;

                if (strMa_Vt_Sp_List.EndsWith(","))
                    strMa_Vt_Sp_List = strMa_Vt_Sp_List.Substring(0, strMa_Vt_Sp_List.Length - 1);
            }
            //xử lý tên Ctrinh nếu PKD có cần cnxx
            if (DataTool.SQLCheckExist("R04CTSO", new string[] { "Stt", "Is_CNXX" }, new object[] { drPH["Stt_Org"].ToString(), true }))
            {
                string strMa_PLCtrinh = SQLExec.ExecuteReturnValue("SELECT Ma_PLCTrinh FROM R04CTSO WHERE Stt = '" + drPH["Stt_Org"].ToString() + "'").ToString();

                if (drPH["Ten_Cong_Trinh"].ToString() == "" && drPH["Stt_Org"].ToString() != "" && strMa_PLCtrinh != "")
                {
                    if (!DataTool.SQLCheckExist("R81DMPLCTRINH", "Ma_PLCtrinh", strMa_PLCtrinh))
                    { Common.MsgOk("Mã phụ lục công trình trên phiếu xác nhận đơn hàng không tồn tại trong danh mục phụ lục công trình. Liên hệ phòng kinh doanh kiểm tra lại mã phụ lục công trình này: " + strMa_PLCtrinh + ""); return false; }
                    else
                        drPH["Ten_Cong_Trinh"] = SQLExec.ExecuteReturnValue("SELECT UPPER(Ten_PLCTrinh) FROM R81DMPLCTRINH WHERE Ma_PLCTrinh IN (SELECT Ma_PLCTrinh FROM R04CTSO WHERE Stt = '" + drPH["Stt_Org"].ToString() + "')").ToString();
                }
                if (drPH["Ten_Cong_Trinh"].ToString() == "" && drPH["Stt_Org"].ToString() != "" && SQLExec.ExecuteReturnValue("SELECT Ht_Gn FROM R04CTSO WHERE Stt = '" + drPH["Stt_Org"].ToString() + "'") == "GK")
                    drPH["Ten_Cong_Trinh"] = SQLExec.ExecuteReturnValue("SELECT UPPER(Dien_Giai) FROM R04CTSO WHERE Stt = '" + drPH["Stt_Org"].ToString() + "' GROUP BY Dien_Giai");
            }

            frmChon_In_Scale frmIn_Scale = new frmChon_In_Scale();


            frmIn_Scale.txtMa_Vt_Sp_List.Text = strMa_Vt_Sp_List;
            frmIn_Scale.txtTen_Cong_Trinh.Text = drPH["Ten_Cong_Trinh"].ToString();
            frmIn_Scale.Load("");



            if (!frmIn_Scale.isAccept)
                return false;


            strTen_Dt = frmIn_Scale.txtTen_Dt.Text;
            strTen_Cong_Trinh = frmIn_Scale.txtTen_Cong_Trinh.Text;


            //Cập nhật thêm thông tin: Ten_Cong_Trinh
            if (frmIn_Scale.isAccept)
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("STT", strStt);
                htPara.Add("TEN_CONG_TRINH", strTen_Cong_Trinh);

                string strSQL = "UPDATE " + strTable_Name + " SET Ten_Cong_Trinh = @Ten_Cong_Trinh WHERE Stt = @Stt";
                SQLExec.Execute(strSQL, htPara, CommandType.Text);
            }

            if (strTable_Name == "R80PH_SCALE")
                strReportTag += frmIn_Scale.rdbTruck_In.Checked ? frmIn_Scale.rdbTruck_In.Name.Substring(3, frmIn_Scale.rdbTruck_In.Name.Length - 3)
                    : frmIn_Scale.rdbTruck_Out.Checked ? frmIn_Scale.rdbTruck_Out.Name.Substring(3, frmIn_Scale.rdbTruck_Out.Name.Length - 3)
                    : frmIn_Scale.rdbScale_Out.Checked ? frmIn_Scale.rdbScale_Out.Name.Substring(3, frmIn_Scale.rdbScale_Out.Name.Length - 3)
                    : frmIn_Scale.rdbKCS.Checked ? "KCS"
                    : frmIn_Scale.rdbCNXX.Checked ? "CT_CNXX"
                    : "Truck_In";
            else
                strReportTag = "CT_CNXX";

            if (strTable_Name == "R80PH_SCALE")
            {
                string strSQLExec = "SELECT * FROM R81EQUIPMENTINFO WHERE Host_IP = '" + MachineInfo.GetHostIP() + "'";
                DataTable dtEquipment = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
                if (dtEquipment.Rows.Count > 0)
                {
                    Variables.strPrint_Report = (string)dtEquipment.Rows[0]["Print_Report"];
                    Variables.strPrint_Barcode = (string)dtEquipment.Rows[0]["Print_Barcode"];
                    Variables.strPrint_Eticket = (string)dtEquipment.Rows[0]["Print_Eticket"];
                }

            }




            Hashtable ht1 = new Hashtable();
            ht1.Add("STT", strStt);
            DataTable dtStandardList = SQLExec.ExecuteReturnDt("sp_GetListStandard", ht1, CommandType.StoredProcedure);
            //3.Co_Tinh, 4.TP_HH

            if (frmIn_Scale.rdbKCS.Checked || frmIn_Scale.rdbCNXX.Checked)
            {
                bIs_Co_Tinh = frmIn_Scale.rdbKCS.Checked;

                bool bCNXX = false;
                if (frmIn_Scale.rdbCNXX.Checked)
                    bCNXX = true;

                DataSet dsPrintVoucher;
                if (dtStandardList.Rows.Count > 1)
                {
                    foreach (DataRow drStandard in dtStandardList.Rows)
                    {
                        string strMa_Vt_Sp = drStandard["Ma_Vt_Sp"].ToString();

                        Hashtable ht = new Hashtable();

                        ht.Add("STT", strStt);
                        ht.Add("STANDARD_ID", drStandard["Standard_ID"]);
                        ht.Add("MA_VT_SP", strMa_Vt_Sp);
                        ht.Add("MA_CT", strMa_Ct);
                        ht.Add("IS_CNXXDT", bCNXX);
                        ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);


                        dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintKCS", ht, CommandType.StoredProcedure);

                        dtHeader = dsPrintVoucher.Tables[0];
                        dtDetail = dsPrintVoucher.Tables[1];

                        if (dtHeader.Columns.Contains("Ten_Dt") || dtHeader.Columns.Contains("Ten_Cong_Trinh"))
                        {
                            foreach (DataRow dr in dtHeader.Rows)
                            {
                                if (dr.Table.Columns.Contains("Ten_Dt"))
                                    dr["Ten_Dt"] = strTen_Dt;

                                if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                    dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                            }
                        }

                        if (dtDetail.Columns.Contains("Ten_Dt") || dtDetail.Columns.Contains("Ten_Cong_Trinh"))
                        {
                            foreach (DataRow dr in dtDetail.Columns)
                            {
                                if (dr.Table.Columns.Contains("Ten_Dt"))
                                    dr["Ten_Dt"] = strTen_Dt;

                                if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                    dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                            }
                        }

                        if (!dtHeader.Columns.Contains("TEN_DT_CBNV"))
                            dtHeader.Columns.Add("TEN_DT_CBNV", typeof(string));

                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        dtHeader.Columns.Add("TITLE", typeof(string));

                        DataRow drHeader = dtHeader.Rows[0];

                        drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
                        drHeader["Report_File"] = "rpt" + strReportTag;

                        strMa_Dt_CbNv = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                        drHeader["Ten_Dt_CbNv"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);


                        //Backup File Report
                        string strPath = Parameters.GetParaValue("BACKUP_PATH_SCALE").ToString();

                        string strPath_KCS = Path.Combine(strPath, "KCS");
                        string strPath_KCS_End = Path.Combine(strPath_KCS, (string)dtHeader.Rows[0]["So_Ct"]);

                        string strPath_Export_Temp = string.Empty;
                        string strPath_Export = string.Empty;
                        bool Allow_Backup = true;


                        if (frmIn_Scale.rdbCNXX.Checked)
                        {
                            strPath = frmIn_Scale.txtPath.Text;
                            string strFileName = drHeader["File_Name"].ToString();
                            CreateFilePDF(strPath, strFileName, dtHeader, dtDetail, drHeader["Report_File"].ToString(), strTable_Name, strStt);
                        }
                        else
                        {
                            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                            frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export);
                        }

                    }
                }
                else
                {
                    foreach (string strMa_Vt_Sp in frmIn_Scale.txtMa_Vt_Sp_List.Text.Split(','))
                    {
                        //strMa_Vt_Sp = drStandard["Ma_Vt_Sp"].ToString();
                        Hashtable ht = new Hashtable();
                        ht.Add("IS_CO_TINH", bIs_Co_Tinh);
                        ht.Add("STT", strStt);
                        ht.Add("MA_VT_SP", strMa_Vt_Sp);
                        ht.Add("MA_CT", strMa_Ct);

                        ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                        if (!frmIn_Scale.rdbKCS.Checked && !frmIn_Scale.rdbCNXX.Checked) //BANG BSUNG 19/10/2022
                        {
                            //    ht.Add("IS_CO_TINH", bIs_Co_Tinh);
                            dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintTP_CT", ht, CommandType.StoredProcedure);
                        }
                        else
                        {
                            ht.Add("IS_CNXXDT", bCNXX);
                            dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintKCS", ht, CommandType.StoredProcedure);
                        }
                        dtHeader = dsPrintVoucher.Tables[0];
                        dtDetail = dsPrintVoucher.Tables[1];

                        if (dtHeader.Columns.Contains("Ten_Dt") || dtHeader.Columns.Contains("Ten_Cong_Trinh"))
                        {
                            foreach (DataRow dr in dtHeader.Rows)
                            {
                                if (dr.Table.Columns.Contains("Ten_Dt"))
                                    dr["Ten_Dt"] = strTen_Dt;

                                if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                    dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                            }
                        }

                        if (dtDetail.Columns.Contains("Ten_Dt") || dtDetail.Columns.Contains("Ten_Cong_Trinh"))
                        {
                            foreach (DataRow dr in dtDetail.Columns)
                            {
                                if (dr.Table.Columns.Contains("Ten_Dt"))
                                    dr["Ten_Dt"] = strTen_Dt;

                                if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                    dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                            }
                        }

                        if (!dtHeader.Columns.Contains("TEN_DT_CBNV"))
                            dtHeader.Columns.Add("TEN_DT_CBNV", typeof(string));

                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        dtHeader.Columns.Add("TITLE", typeof(string));

                        DataRow drHeader = dtHeader.Rows[0];

                        drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
                        drHeader["Report_File"] = "rpt" + strReportTag;

                        strMa_Dt_CbNv = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                        drHeader["Ten_Dt_CbNv"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);


                        //Backup File Report
                        string strPath = Parameters.GetParaValue("BACKUP_PATH_SCALE").ToString();

                        //string strPath_CT = Path.Combine(strPath, "COTINH");
                        //string strPath_CT_End = Path.Combine(strPath_CT, (string)dtHeader.Rows[0]["So_Ct"]);

                        //string strPath_TPHH = Path.Combine(strPath, "TPHH");
                        //string strPath_TPHH_End = Path.Combine(strPath_TPHH, (string)dtHeader.Rows[0]["So_Ct"]);

                        string strPath_Export_Temp = string.Empty;
                        string strPath_Export = string.Empty;
                        bool Allow_Backup = true;


                        if (frmIn_Scale.rdbCNXX.Checked)
                        {
                            strPath = frmIn_Scale.txtPath.Text;
                            string strFileName = drHeader["File_Name"].ToString();
                            CreateFilePDF(strPath, strFileName, dtHeader, dtDetail, drHeader["Report_File"].ToString(), "R80PH_SCALE", strStt);
                        }
                        else
                        {
                            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                            frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export);
                        }
                    }
                }
                return true;

            }//1.TRUCK_IN, 2.TRUCK_OUT
            else if (frmIn_Scale.rdbTruck_In.Checked || frmIn_Scale.rdbTruck_Out.Checked)
            {
                if (frmIn_Scale.rdbTruck_In.Checked)
                    strTruck_In_Out = "IN";
                else
                    strTruck_In_Out = "OUT";

                return PrintTruck_In_Out(strStt, strTruck_In_Out, "rpt" + strReportTag, true, Variables.strPrint_Barcode);

                //}//PRINT GCN
                //else if (frmIn_Scale.rdbGCN.Checked)
                //{
                //    Hashtable ht = new Hashtable();
                //    ht.Add("STT", strStt);
                //    ht.Add("MA_CT", strMa_Ct);
                //    ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                //    DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_Print_GCN", ht, CommandType.StoredProcedure);
                //    dtHeader = dsPrintVoucher.Tables[0];
                //    dtDetail = dsPrintVoucher.Tables[1];

                if (dtDetail.Columns.Contains("Ten_Dt") || dtDetail.Columns.Contains("Ten_Cong_Trinh"))
                {
                    foreach (DataRow dr in dtDetail.Columns)
                    {
                        if (dr.Table.Columns.Contains("Ten_Dt"))
                            dr["Ten_Dt"] = strTen_Dt;

                        if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                            dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                    }
                }

                dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                dtHeader.Columns.Add("TITLE", typeof(string));

                if (!dtHeader.Columns.Contains("TEN_DT_CBNV"))
                    dtHeader.Columns.Add("TEN_DT_CBNV", typeof(string));

                DataRow drHeader = dtHeader.Rows[0];

                drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
                drHeader["Report_File"] = "rpt" + strReportTag;

                strMa_Dt_CbNv = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                drHeader["Ten_Dt_CbNv"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);

                //Backup File Report
                string strPath = Parameters.GetParaValue("BACKUP_PATH_SCALE").ToString();
                string strPath_GCN_End = Path.Combine(strPath, "GCN");

                string strPath_Export_Temp = string.Empty;
                string strPath_Export = string.Empty;
                bool Allow_Backup = true;

                if (!Directory.Exists(strPath_GCN_End))
                {
                    try { Directory.CreateDirectory(strPath_GCN_End); }
                    catch { Common.MsgCancel("Bạn không có quyền tạo thư mục lưu file Backup.Liên hệ với bộ phận IT"); Allow_Backup = false; }
                }

                //Auto Create File PDF
                if (Allow_Backup)
                {
                    int iVersion = 0;
                    strPath_Export_Temp = Path.Combine(strPath_GCN_End, (string)dtHeader.Rows[0]["So_Ct"] + "_V" + iVersion + ".pdf");

                    while (File.Exists(strPath_Export_Temp))
                    {
                        iVersion += 1;
                        strPath_Export_Temp = Path.Combine(strPath_GCN_End, (string)dtHeader.Rows[0]["So_Ct"] + "_V" + iVersion + ".pdf");
                    }

                    strPath_Export = strPath_Export_Temp;
                }

                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export);

            }//3.SCALE_OUT
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("IS_CO_TINH", bIs_Co_Tinh);
                ht.Add("STT", strStt);
                ht.Add("MA_CT", strMa_Ct);
                ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintScale_Out", ht, CommandType.StoredProcedure);

                dtHeader = dsPrintVoucher.Tables[0];
                dtDetail = dsPrintVoucher.Tables[1];

                if (dtDetail.Rows.Count == 0)
                {
                    Common.MsgCancel("Phiếu này không có chi tiết.Không in được");
                    return false;
                }

                dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                dtHeader.Columns.Add("TITLE", typeof(string));

                DataRow drHeader = dtHeader.Rows[0];

                drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
                drHeader["Report_File"] = "rpt" + strReportTag;

                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, Variables.strPrint_Eticket, "R80PH_SCALE", "Stt", drHeader["Stt"].ToString(), "Printed_OutPut", true);
            }

            return true;
        }
        public static bool PrintBarcode_KKV(string strStt, bool bPreview, bool bShowDialog, List<string> files)
        {
            DataTable dtHeader;
            DataTable dtDetail;
            List<string> _files;

            _files = files;
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();

            frmIn_BarcodeKKV frm = new frmIn_BarcodeKKV();
            frm.Load(_files);

            if (frm.isAccept)
            {
                if (frm.rdbIn_LXH.Checked == true)
                {
                    string strStt_Org = SQLExec.ExecuteReturnValue("SELECT Stt_Org FROM R80PH_BARCODE_KKV WHERE Stt = '" + strStt + "' AND Loai_Ct = '2'").ToString();
                    Hashtable ht = new Hashtable();
                    ht.Add("STT", strStt_Org);
                    ht.Add("STT_PH", strStt);
                    ht.Add("MA_CT", "SOCP");
                    ht.Add("HD_TU_IN", 0);
                    ht.Add("IS_PRINT_BAREM", 0);
                    ht.Add("IS_VND", 1);
                    ht.Add("LOGIN_USER", Element.sysUser_Id);
                    ht.Add("LANGUAGE_TYPE", "V");

                    DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintVoucher_PDA", ht, CommandType.StoredProcedure);

                    dtHeader = dsPrintVoucher.Tables[0];
                    dtDetail = dsPrintVoucher.Tables[1];

                    dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                    dtHeader.Columns.Add("TITLE", typeof(string));


                    DataRow drHeader = dtHeader.Rows[0];


                    drHeader["Report_File"] = "rptCT_LXHCP_QR";


                    return frmPrint.Load(drHeader, dtDetail, true, true);
                }
                else if (frm.rdbPX_Barcode.Checked == true)
                {
                    Hashtable ht = new Hashtable();

                    ht.Add("STT", strStt);

                    ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                    DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintScale_Out_KKV", ht, CommandType.StoredProcedure);

                    dtHeader = dsPrintVoucher.Tables[0];
                    dtDetail = dsPrintVoucher.Tables[1];

                    if (dtDetail.Rows.Count == 0)
                    {
                        Common.MsgCancel("Phiếu này không có chi tiết.Không in được");
                        return false;
                    }

                    dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                    dtHeader.Columns.Add("TITLE", typeof(string));

                    DataRow drHeader = dtHeader.Rows[0];

                    drHeader["Title"] = string.Empty;// ((string)drDmCt["Title"]).ToUpper();
                    drHeader["Report_File"] = "rptScale_Out_KKV";

                    frmPrint.Load(drHeader, dtDetail, true, true);
                    //frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, Variables.strPrint_Eticket, "R80PH_SCALE", "Stt", drHeader["Stt"].ToString(), "Printed_OutPut", true);
                }
                else if (frm.rdbPXKKV.Checked == true) //in pxk
                {
                    DataTable dtPXK = SQLExec.ExecuteReturnDt(" SELECT MAX(Ma_Ct) AS Ma_Ct, MAX(Stt) AS Stt FROM R05CTNX WHERE Stt_Org IN (SELECT MAX(Stt_org) FROM R05CTX_BARCODE_KKV WHERE Stt = '" + strStt + "')");

                    if (dtPXK.Rows.Count == 0)
                    {
                        Common.MsgCancel("Phiếu này chưa tạo PXK TP .Không in được");
                        return false;
                    }
                    DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", dtPXK.Rows[0]["Ma_Ct"].ToString());


                    Hashtable ht = new Hashtable();

                    ht.Add("STT", dtPXK.Rows[0]["Stt"].ToString());
                    ht.Add("MA_CT", dtPXK.Rows[0]["Ma_Ct"].ToString());
                    ht.Add("LOGIN_USER", Common.GetCurrent_Log());
                    ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

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

                    drHeader["Is_Vnd"] = true;
                    drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
                    drHeader["Report_File"] = "rptCT_PXKV";

                    frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);

                }

            }
            return true;
        }

        public static bool PrintScale_Out_Boat(string strStt_List, bool bPreview, bool bShowDialog, string strTable_Name, string strMa_Kho)
        {
            string strMa_Ct = string.Empty;
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            string strReport_File = string.Empty;
            string strSo_Ct = string.Empty;
            DateTime dteNgay_Ct = DateTime.Now;
            string strTen_Dt = string.Empty;
            string strTen_Cong_Trinh = string.Empty;
            string strMa_Dt_CbNv = string.Empty;
            string strSQLExec_Name = string.Empty;
            bool bIs_Co_Tinh = false;
            string strTruck_In_Out = string.Empty;

            if (strTable_Name == "R80PH_SCALE")
                strMa_Ct = "PXTH";
            else if (strTable_Name == "R80PH_BARCODE_KKV")
                strMa_Ct = "PXBKV";


            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            DataTable dtHeader;
            DataTable dtDetail;


            strTable_Ph = (string)drDmCt["Table_Ph"];
            strTable_Ct = (string)drDmCt["Table_Ct"];

            DataTable dtCt = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM " + strTable_Ct);

            string strMa_Vt_Sp_List = "";
            if (dtCt.Columns.Contains("Ma_Vt_Sp") && dtCt.Columns.Contains("Stt"))
            {
                object objValue = SQLExec.ExecuteReturnValue("SELECT DISTINCT Ma_Vt_Sp + ',' FROM " + strTable_Ct + " WHERE Ma_Vt_Sp <> '' AND Stt IN ('" + strStt_List.Replace(",", "','") + "') FOR XML PATH('')");

                if (objValue != null && objValue.ToString() != string.Empty)
                    strMa_Vt_Sp_List = objValue.ToString();
                else
                    strMa_Vt_Sp_List = string.Empty;

                if (strMa_Vt_Sp_List.EndsWith(","))
                    strMa_Vt_Sp_List = strMa_Vt_Sp_List.Substring(0, strMa_Vt_Sp_List.Length - 1);
            }

            frmChon_In_Scale frmIn_Scale = new frmChon_In_Scale();
            frmIn_Scale.txtMa_Vt_Sp_List.Text = strMa_Vt_Sp_List;

            if (strStt_List.Length > 20)
                frmIn_Scale.txtTen_Cong_Trinh.Text = string.Empty;
            else
            {
                DataRow drPH = DataTool.SQLGetDataRowByID(strTable_Name, "Stt", strStt_List);
                if (DataTool.SQLCheckExist("R04CTSO", new string[] { "Stt", "Is_CNXX" }, new object[] { drPH["Stt_Org"].ToString(), true }))
                {

                    string strMa_PLCtrinh = SQLExec.ExecuteReturnValue("SELECT Ma_PLCTrinh FROM R04CTSO WHERE Stt = '" + drPH["Stt_Org"].ToString() + "'").ToString();

                    if (drPH["Ten_Cong_Trinh"].ToString() == "" && drPH["Stt_Org"].ToString() != "" && strMa_PLCtrinh != "")
                    {
                        if (!DataTool.SQLCheckExist("R81DMPLCTRINH", "Ma_PLCtrinh", strMa_PLCtrinh))
                        { Common.MsgOk("Mã phụ lục công trình trên phiếu xác nhận đơn hàng không tồn tại trong danh mục phụ lục công trình. Liên hệ phòng kinh doanh kiểm tra lại mã phụ lục công trình này: " + strMa_PLCtrinh + ""); return false; }
                        else
                            drPH["Ten_Cong_Trinh"] = SQLExec.ExecuteReturnValue("SELECT UPPER(Ten_PLCTrinh) FROM R81DMPLCTRINH WHERE Ma_PLCTrinh IN (SELECT Ma_PLCTrinh FROM R04CTSO WHERE Stt = '" + drPH["Stt_Org"].ToString() + "')").ToString();
                    }
                    if (drPH["Ten_Cong_Trinh"].ToString() == "" && drPH["Stt_Org"].ToString() != "" && SQLExec.ExecuteReturnValue("SELECT Ht_Gn FROM R04CTSO WHERE Stt = '" + drPH["Stt_Org"].ToString() + "'") == "GK")
                        drPH["Ten_Cong_Trinh"] = SQLExec.ExecuteReturnValue("SELECT UPPER(Dien_Giai) FROM R04CTSO WHERE Stt = '" + drPH["Stt_Org"].ToString() + "' GROUP BY Dien_Giai");

                    frmIn_Scale.txtTen_Cong_Trinh.Text = drPH["Ten_Cong_Trinh"].ToString();
                }
            }



            frmIn_Scale.Load(true, true);

            if (!frmIn_Scale.isAccept)
                return false;

            strTen_Dt = frmIn_Scale.txtTen_Dt.Text;
            strTen_Cong_Trinh = frmIn_Scale.txtTen_Cong_Trinh.Text;
            strSo_Ct = frmIn_Scale.txtSo_Ct.Text;
            dteNgay_Ct = Convert.ToDateTime(frmIn_Scale.dteNgay_Ct.Text);

            strReportTag += frmIn_Scale.rdbTruck_In.Checked ? frmIn_Scale.rdbTruck_In.Name.Substring(3, frmIn_Scale.rdbTruck_In.Name.Length - 3)
                : frmIn_Scale.rdbTruck_Out.Checked ? frmIn_Scale.rdbTruck_Out.Name.Substring(3, frmIn_Scale.rdbTruck_Out.Name.Length - 3)
                : frmIn_Scale.rdbScale_Out.Checked ? frmIn_Scale.rdbScale_Out.Name.Substring(3, frmIn_Scale.rdbScale_Out.Name.Length - 3)
                //: frmIn_Scale.rdbCo_Tinh.Checked ? frmIn_Scale.rdbCo_Tinh.Name.Substring(3, frmIn_Scale.rdbCo_Tinh.Name.Length - 3)
                //: frmIn_Scale.rdbGCN.Checked ? frmIn_Scale.rdbGCN.Name.Substring(3, frmIn_Scale.rdbGCN.Name.Length - 3)
                : frmIn_Scale.rdbKCS.Checked ? "KCS"
                : frmIn_Scale.rdbCNXX.Checked ? "CT_CNXX"
                //: frmIn_Scale.rdbTP_HH.Checked ? frmIn_Scale.rdbTP_HH.Name.Substring(3, frmIn_Scale.rdbTP_HH.Name.Length - 3) 
                : "Truck_In";

            string strSQLExec = "SELECT * FROM R81EQUIPMENTINFO WHERE Host_IP = '" + MachineInfo.GetHostIP() + "'";
            DataTable dtEquipment = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
            if (dtEquipment.Rows.Count > 0)
            {
                Variables.strPrint_Report = (string)dtEquipment.Rows[0]["Print_Report"];
                Variables.strPrint_Barcode = (string)dtEquipment.Rows[0]["Print_Barcode"];
                Variables.strPrint_Eticket = (string)dtEquipment.Rows[0]["Print_Eticket"];
            }

            //3.Co_Tinh, 4.TP_HH
            if (frmIn_Scale.rdbKCS.Checked || frmIn_Scale.rdbCNXX.Checked)
            {
                bool bCNXX = false; bool bNum_Lot = false;
                if (frmIn_Scale.rdbCNXX.Checked)
                    bCNXX = true;
                if (frmIn_Scale.chkNum_Lot.Checked)
                    bNum_Lot = true;

                //bIs_Co_Tinh = frmIn_Scale.rdbCo_Tinh.Checked;
                DataSet dsPrintVoucher;
                //neu check là tách theo lô thì thêm dk lô vào
                if(frmIn_Scale.chkNum_Lot.Checked == true)
                {
                    //0. Tạo biến 
                    string strPath = string.Empty;
                    string strFileName = string.Empty;
                    string strMa_Vt_Sp = string.Empty;
                    string strNum_Lot = string.Empty;
                    //1. tạo danh sách sản phẩm kèm lô theo danh sách stt_list
                    Hashtable htNum = new Hashtable();
                    htNum.Add("STT_LIST", strStt_List);
                    htNum.Add("MA_KHO", strMa_Kho);
                    DataTable dtSpNumLot = SQLExec.ExecuteReturnDt("sp_GetListStandarNumLot", htNum, CommandType.StoredProcedure);
                    //2. duyệt từng dòng để in CNXX
                    foreach(DataRow drNumLot in dtSpNumLot.Rows)
                    {
                        strMa_Vt_Sp = drNumLot["Ma_Vt_Sp"].ToString();
                        strNum_Lot = drNumLot["Num_Lot"].ToString();

                        Hashtable ht = new Hashtable();
                        ht.Add("IS_BOAT", true);
                        ht.Add("IS_CO_TINH", bIs_Co_Tinh);
                        ht.Add("STT_LIST", strStt_List);
                        ht.Add("MA_VT_SP", strMa_Vt_Sp);
                        ht.Add("MA_CT", strMa_Ct);
                        ht.Add("NUM_LOT", strNum_Lot);
                        ht.Add("IS_CNXXDT", bCNXX);
                        ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                        dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintKCS", ht, CommandType.StoredProcedure);

                        //3. Export PDF
                        dtHeader = dsPrintVoucher.Tables[0];
                        dtDetail = dsPrintVoucher.Tables[1];

                        foreach (DataRow dr in dtHeader.Rows)
                        {
                            if (dr.Table.Columns.Contains("Ngay_Ct"))
                                dr["Ngay_Ct"] = dteNgay_Ct;

                            if (dr.Table.Columns.Contains("Ngay_Xuat"))
                                dr["Ngay_Xuat"] = dteNgay_Ct;

                            //if (dr.Table.Columns.Contains("So_Ct"))
                            //    dr["So_Ct"] = strSo_Ct;

                            if (dr.Table.Columns.Contains("Ten_Dt"))
                                dr["Ten_Dt"] = strTen_Dt;

                            if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                        }

                        foreach (DataRow dr in dtDetail.Rows)
                        {
                            if (dr.Table.Columns.Contains("Ngay_Ct"))
                                dr["Ngay_Ct"] = dteNgay_Ct;

                            if (dr.Table.Columns.Contains("Ngay_Xuat"))
                                dr["Ngay_Xuat"] = dteNgay_Ct;

                            if (dr.Table.Columns.Contains("So_Ct") && strSo_Ct != "")
                                dr["So_Ct"] = strSo_Ct;

                            if (dr.Table.Columns.Contains("Ten_Dt"))
                                dr["Ten_Dt"] = strTen_Dt;

                            if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                        }

                        if (!dtHeader.Columns.Contains("TEN_DT_CBNV"))
                            dtHeader.Columns.Add("TEN_DT_CBNV", typeof(string));

                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        dtHeader.Columns.Add("TITLE", typeof(string));

                        DataRow drHeader = dtHeader.Rows[0];

                        drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
                        drHeader["Report_File"] = "rpt" + strReportTag;

                        strMa_Dt_CbNv = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                        drHeader["Ten_Dt_CbNv"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);

                        if (frmIn_Scale.rdbCNXX.Checked)
                        {
                            strPath = frmIn_Scale.txtPath.Text;
                            strFileName = drHeader["File_Name"].ToString();

                            CreateFilePDF(strPath, strFileName, dtHeader, dtDetail, drHeader["Report_File"].ToString(), strTable_Name, strStt_List);
                        }
                    }
                    
                }
                else
                { 
                    foreach (string strMa_Vt_Sp in frmIn_Scale.txtMa_Vt_Sp_List.Text.Split(','))
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("IS_BOAT", true);
                        ht.Add("IS_CO_TINH", bIs_Co_Tinh);
                        ht.Add("STT_LIST", strStt_List);
                        ht.Add("MA_VT_SP", strMa_Vt_Sp);
                        ht.Add("MA_CT", strMa_Ct);
                        ht.Add("IS_CNXXDT", bCNXX);
                        ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                        dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintKCS", ht, CommandType.StoredProcedure);
                        //else
                        //    dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintTP_CT", ht, CommandType.StoredProcedure);

                        dtHeader = dsPrintVoucher.Tables[0];
                        dtDetail = dsPrintVoucher.Tables[1];

                        foreach (DataRow dr in dtHeader.Rows)
                        {
                            if (dr.Table.Columns.Contains("Ngay_Ct"))
                                dr["Ngay_Ct"] = dteNgay_Ct;

                            if (dr.Table.Columns.Contains("Ngay_Xuat"))
                                dr["Ngay_Xuat"] = dteNgay_Ct;

                            if (dr.Table.Columns.Contains("So_Ct") && strSo_Ct != "")
                                dr["So_Ct"] = strSo_Ct;

                            if (dr.Table.Columns.Contains("Ten_Dt"))
                                dr["Ten_Dt"] = strTen_Dt;

                            if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                        }

                        foreach (DataRow dr in dtDetail.Rows)
                        {
                            if (dr.Table.Columns.Contains("Ngay_Ct"))
                                dr["Ngay_Ct"] = dteNgay_Ct;

                            if (dr.Table.Columns.Contains("Ngay_Xuat"))
                                dr["Ngay_Xuat"] = dteNgay_Ct;

                            if (dr.Table.Columns.Contains("So_Ct") && strSo_Ct != "")
                                dr["So_Ct"] = strSo_Ct;

                            if (dr.Table.Columns.Contains("Ten_Dt"))
                                dr["Ten_Dt"] = strTen_Dt;

                            if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                        }

                        if (!dtHeader.Columns.Contains("TEN_DT_CBNV"))
                            dtHeader.Columns.Add("TEN_DT_CBNV", typeof(string));

                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        dtHeader.Columns.Add("TITLE", typeof(string));

                        DataRow drHeader = dtHeader.Rows[0];

                        drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
                        drHeader["Report_File"] = "rpt" + strReportTag;

                        strMa_Dt_CbNv = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                        drHeader["Ten_Dt_CbNv"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);


                        //Backup File Report
                        string strPath = Parameters.GetParaValue("BACKUP_PATH_SCALE").ToString();
                        string strPath_KCS = Path.Combine(strPath, "BOAT");
                        string strPath_KCS_CT_End = Path.Combine(strPath_KCS, "COTINH");
                        string strPath_KCS_TPHH_End = Path.Combine(strPath_KCS, "TPHH");

                        string strPath_Export_Temp = string.Empty;
                        string strPath_Export = string.Empty;
                        string strFileName = (string)dtHeader.Rows[0]["So_Ct"] == "" ? "ROSYEXPORT" : (string)dtHeader.Rows[0]["So_Ct"];

                        bool Allow_Backup = true;

                    
                        if (frmIn_Scale.rdbCNXX.Checked)
                        {
                            strPath = frmIn_Scale.txtPath.Text;
                            strFileName = drHeader["File_Name"].ToString();

                            CreateFilePDF(strPath, strFileName, dtHeader, dtDetail, drHeader["Report_File"].ToString(), strTable_Name, strStt_List);
                        }
                        else
                        {
                            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                            frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export);
                        }
                    }
                }
                return true;

            }



            return true;
        }
        public static bool PrintKCS(bool bPreview, bool bShowDialog)
        {


            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            string strReport_File = string.Empty;
            string strMa_Dt_CbNv = string.Empty;
            string strSQLExec_Name = string.Empty;


            string strTruck_In_Out = string.Empty;

            DataTable dtHeader;
            DataTable dtDetail;

            frmChon_In_KCS frmIn_KCS = new frmChon_In_KCS();
            frmIn_KCS.Load();

            if (!frmIn_KCS.isAccept)
                return false;

            string strBarcode1_1 = frmIn_KCS.txtBarcode1_1.Text.Trim();
            string strBarcode1_2 = frmIn_KCS.txtBarcode1_2.Text.Trim();
            string strBarcode2_1 = frmIn_KCS.txtBarcode2_1.Text.Trim();
            string strBarcode2_2 = frmIn_KCS.txtBarcode2_2.Text.Trim();
            string strBarcode3_1 = frmIn_KCS.txtBarcode3_1.Text.Trim();
            string strBarcode3_2 = frmIn_KCS.txtBarcode3_2.Text.Trim();
            string strNum_Lot_List = frmIn_KCS.txtNum_Lot_List.Text.Trim();

            bool Allow_Backup = true;

            bool Is_CNXXDT = false;
            if (frmIn_KCS.rdbCNXXDT.Checked)
                Is_CNXXDT = true;

            string strPath_Export_Temp = string.Empty;
            string strPath_Export = string.Empty;


            string strPath = Parameters.GetParaValue("BACKUP_PATH_SCALE").ToString();

            string strMa_Vt_Sp_List = "";

            string strSQLExec = @"SELECT DISTINCT Ma_Vt_Sp + ','
											FROM R81DMBARCODE WITH(NOLOCK)
											WHERE Ma_Vt_Sp <> '' AND (Barcode >= '" + strBarcode1_1 + "' AND Barcode <= '" + strBarcode1_2 + "')" + @"
													OR (Barcode >= '" + strBarcode2_1 + "' AND Barcode <= '" + strBarcode2_2 + "')" + @"
													OR (Barcode >= '" + strBarcode3_1 + "' AND Barcode <= '" + strBarcode3_2 + "')" + @"
                                                    OR (Num_Lot = '" + strNum_Lot_List.Replace(",", "' OR Num_Lot = '") + "')" + @"
											FOR XML PATH('')";

            strMa_Vt_Sp_List = SQLExec.ExecuteReturnValue(strSQLExec).ToString();

            if (strMa_Vt_Sp_List.EndsWith(","))
                strMa_Vt_Sp_List = strMa_Vt_Sp_List.Substring(0, strMa_Vt_Sp_List.Length - 1);

            foreach (string strMa_Vt_Sp in strMa_Vt_Sp_List.Split(','))
            {
                //lấy thông tin standard_ID List
                Hashtable ht1 = new Hashtable();
                ht1.Add("MA_VT_SP", strMa_Vt_Sp);
                ht1.Add("STT", "");
                ht1.Add("STT_LXH", "");
                ht1.Add("BARCODE1_1", strBarcode1_1);
                ht1.Add("BARCODE1_2", strBarcode1_2);
                ht1.Add("BARCODE2_1", strBarcode2_1);
                ht1.Add("BARCODE2_2", strBarcode2_2);
                ht1.Add("BARCODE3_1", strBarcode3_1);
                ht1.Add("BARCODE3_2", strBarcode3_2);
                ht1.Add("NUM_LOT_LIST", strNum_Lot_List);
                DataTable dtStandardList = SQLExec.ExecuteReturnDt("sp_GetListStandard", ht1, CommandType.StoredProcedure);
                if (dtStandardList.Rows.Count >= 1)
                {
                    foreach (DataRow drStandard in dtStandardList.Rows)
                    {
                        Hashtable ht = new Hashtable();

                        ht.Add("BARCODE1_1", strBarcode1_1);
                        ht.Add("BARCODE1_2", strBarcode1_2);
                        ht.Add("BARCODE2_1", strBarcode2_1);
                        ht.Add("BARCODE2_2", strBarcode2_2);
                        ht.Add("BARCODE3_1", strBarcode3_1);
                        ht.Add("BARCODE3_2", strBarcode3_2);
                        ht.Add("NUM_LOT_LIST", strNum_Lot_List);
                        ht.Add("IS_CNXXDT", Is_CNXXDT);
                        ht.Add("NGAY_CT", frmIn_KCS.dteNgay_Ct.Text);
                        ht.Add("SO_CT", frmIn_KCS.txtSo_Ct.Text.Trim());
                        ht.Add("TEN_DT", frmIn_KCS.txtTen_Dt.Text);
                        ht.Add("TEN_CONG_TRINH", frmIn_KCS.txtTen_Cong_Trinh.Text);
                        ht.Add("MA_VT_SP", strMa_Vt_Sp);
                        ht.Add("STANDARD_ID", drStandard["Standard_ID"]);
                        ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);
                        DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_Print_KCS", ht, CommandType.StoredProcedure);

                        dtHeader = dsPrintVoucher.Tables[0];
                        dtDetail = dsPrintVoucher.Tables[1];

                        if (!dtHeader.Columns.Contains("TEN_DT_CBNV"))
                            dtHeader.Columns.Add("TEN_DT_CBNV", typeof(string));

                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        dtHeader.Columns.Add("TITLE", typeof(string));

                        DataRow drHeader = dtHeader.Rows[0];

                        drHeader["Title"] = "ROSY JSC";
                        drHeader["Report_File"] = "rptCT_CNXX";// "rptKCS";

                        strMa_Dt_CbNv = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                        drHeader["Ten_Dt_CbNv"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);

                        //Backup File Report

                        if (frmIn_KCS.rdbCNXXDT.Checked)
                        {//KET XUAT FILE PDF

                            string strPath1 = frmIn_KCS.txtPath.Text;
                            drHeader["Report_File"] = "rptCT_CNXX";
                            string strFileName = drHeader["File_Name"].ToString();
                            CreateFilePDF(strPath1, strFileName, dtHeader, dtDetail, drHeader["Report_File"].ToString(), "R80PH_SCALE","");
                        }
                        else
                        {
                            string strPath_KCS = Path.Combine(strPath, "KCS");

                            string strFileName = (string)dtHeader.Rows[0]["So_Ct"] == "" ? "ROSYEXPORT" : (string)dtHeader.Rows[0]["So_Ct"];

                            //Auto Create File PDF
                            if (Allow_Backup)
                            {
                                int iVersion = 0;
                                

                                strPath_Export = strPath_Export_Temp;
                            }
                            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                            frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export);
                        }
                    }
                }


            }
            return true;
        }
        public static bool Print_DnTu(string strStt, bool bPreview, string strReportFile)
        {
            strReportFile = "rptCT_DNTU";
            DataTable dtDetail = new DataTable();
            dtDetail = DataTool.SQLGetDataTable("R04CTDNTU", string.Empty, "Stt = '" + strStt + "'", "");

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);

            DataTable dtPrintWorkerList = new DataTable();
            dtPrintWorkerList = SQLExec.ExecuteReturnDt("Sp_PrintDnTu", ht, CommandType.StoredProcedure);

            if (dtPrintWorkerList.Rows.Count == 0)
                return false;

            if (!dtPrintWorkerList.Columns.Contains("REPORT_FILE"))
                dtPrintWorkerList.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtPrintWorkerList.Columns.Contains("NGAY_CT"))
                dtPrintWorkerList.Columns.Add("NGAY_CT", typeof(DateTime));

            if (!dtPrintWorkerList.Columns.Contains("DOC_TIEN"))
                dtPrintWorkerList.Columns.Add("DOC_TIEN", typeof(string));

            dtPrintWorkerList.Rows[0]["REPORT_FILE"] = strReportFile;
            dtPrintWorkerList.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

            dtPrintWorkerList.Rows[0]["Doc_Tien"] = Common.ReadMoney(Convert.ToDouble(dtPrintWorkerList.Rows[0]["Tien"]), dtPrintWorkerList.Rows[0]["Ma_TTe"].ToString());

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(dtPrintWorkerList.Rows[0], dtDetail, bPreview);
        }
        //SQLUpdateCt
        public static bool SQLUpdateCt(frmVoucher_Edit frmEditCt)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            #region Update chứng từ
            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)frmEditCt.enuNew_Edit);
            sqlCom.Parameters.AddWithValue("@Stt", frmEditCt.strStt);
            sqlCom.Parameters.AddWithValue("@Ma_Ct", frmEditCt.drDmCt["Ma_Ct"].ToString());
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraPH = new SqlParameter();
            paraPH.SqlDbType = SqlDbType.Structured;
            paraPH.ParameterName = "@PH";

            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@Ct";

            if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R01CTTIEN")
            {
                sqlCom.CommandText = "sp_Update_CtTien";

                //TVP_PH
                paraPH.TypeName = "TVP_PHTien";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHTien", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtTien
                paraCt.TypeName = "TVP_CtTien";
                paraCt.Value = GetTVPValue("R01CtTien", "TVP_CtTien", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);

            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R02CTNM")
            {
                sqlCom.CommandText = "sp_Update_CtNM";

                //TVP_PH
                paraPH.TypeName = "TVP_PHNM";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHNM", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtNM
                paraCt.TypeName = "TVP_CtNM";
                paraCt.Value = GetTVPValue("R02CtNM", "TVP_CtNM", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);

            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R03CTBREM")
            {
                sqlCom.CommandText = "sp_Update_CtBRem";

                //TVP_PH
                paraPH.TypeName = "TVP_PHBREM";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHBREM", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtNM
                paraCt.TypeName = "TVP_CtBREM";
                paraCt.Value = GetTVPValue("R03CtBREM", "TVP_CtBREM", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);

            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R04CTHD")
            {
                sqlCom.CommandText = "sp_Update_CtHD";

                //TVP_PH
                paraPH.TypeName = "TVP_PHHD";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHHD", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtHD
                paraCt.TypeName = "TVP_CtHD";
                paraCt.Value = GetTVPValue("R04CtHD", "TVP_CtHD", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);

            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R04CTSO")
            {
                sqlCom.CommandText = "sp_Update_CtSO";

                //TVP_PH
                paraPH.TypeName = "TVP_PHSO";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHSO", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CtSO";
                paraCt.Value = GetTVPValue("R04CtSO", "TVP_CtSO", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R04CTPO")
            {
                sqlCom.CommandText = "sp_Update_CtPO";

                //TVP_PH
                paraPH.TypeName = "TVP_PHPO";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHPO", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CtPO";
                paraCt.Value = GetTVPValue("R04CtPO", "TVP_CtPO", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R04CTPONL")
            {
                sqlCom.CommandText = "sp_Update_CtPONL";

                //TVP_PH
                paraPH.TypeName = "TVP_PHPONL";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHPONL", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CtPONL";
                paraCt.Value = GetTVPValue("R04CTPONL", "TVP_CtPONL", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R05CTNX")
            {
                sqlCom.CommandText = "sp_Update_CtNX";

                //TVP_PH
                paraPH.TypeName = "TVP_PHNX";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHNX", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtNX
                paraCt.TypeName = "TVP_CtNX";
                paraCt.Value = GetTVPValue("R05CtNX", "TVP_CtNX", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R05CTNXPT")
            {
                sqlCom.CommandText = "sp_Update_CtNXPT";

                //TVP_PH
                paraPH.TypeName = "TVP_PHNXPT";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHNXPT", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtNX
                paraCt.TypeName = "TVP_CtNXPT";
                paraCt.Value = GetTVPValue("R05CtNXPT", "TVP_CtNXPT", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R05CTNX_CP")
            {
                sqlCom.CommandText = "sp_Update_CtNX_CP";

                //TVP_PH
                paraPH.TypeName = "TVP_PHNX_CP";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHNX_CP", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtNX
                paraCt.TypeName = "TVP_CtNX_CP";
                paraCt.Value = GetTVPValue("R05CtNX_CP", "TVP_CtNX_CP", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R05CTNXPHOI")
            {
                sqlCom.CommandText = "sp_Update_CtNXPHOI";

                //TVP_PH
                paraPH.TypeName = "TVP_PHNXPHOI";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHNXPHOI", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtNX
                paraCt.TypeName = "TVP_CtNXPHOI";
                paraCt.Value = GetTVPValue("R05CtNXPHOI", "TVP_CtNXPHOI", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }

            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R80CTKT")
            {
                sqlCom.CommandText = "sp_Update_CtKT";

                //TVP_PH
                paraPH.TypeName = "TVP_PHKT";
                paraPH.Value = GetTVPValue("R80PH", "TVP_PHKT", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtKT
                paraCt.TypeName = "TVP_CtKT";
                paraCt.Value = GetTVPValue("R80CtKT", "TVP_CtKT", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            else if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R06CT_BTTB")
            {
                sqlCom.CommandText = "Sp_Update_BTTB";

                //TVP_PH
                paraPH.TypeName = "TVP_PHBTTB";
                paraPH.Value = GetTVPValue("R06PH_BTTB", "TVP_PHBTTB", frmEditCt.dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CTBTTB";
                paraCt.Value = GetTVPValue("R06CT_BTTB", "TVP_CTBTTB", frmEditCt.dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            try
            {
                sqlCom.ExecuteNonQuery();

                Voucher.Update_dsVoucher(frmEditCt);
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
            #endregion

            #region Update CtNXLR
            if (frmEditCt.dtEditCt_LR != null)
            {
                sqlCom.CommandText = "Sp_Update_CtNXLR";
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlCom.Parameters.Clear();
                sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)frmEditCt.enuNew_Edit);
                sqlCom.Parameters.AddWithValue("@Stt", frmEditCt.strStt);
                sqlCom.Parameters.AddWithValue("@Ma_Ct", frmEditCt.drDmCt["Ma_Ct"].ToString());
                sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

                SqlParameter paraNXLR = new SqlParameter();
                paraNXLR.SqlDbType = SqlDbType.Structured;
                paraNXLR.ParameterName = "@CtNXLR";

                //Tạo Table cho TVP_CtNXLR
                paraNXLR.TypeName = "TVP_CtNXLR";
                paraNXLR.Value = GetTVPValue("R05CtNXLR", "TVP_CtNXLR", frmEditCt.dtEditCt_LR);
                sqlCom.Parameters.Add(paraNXLR);

                try
                {
                    sqlCom.ExecuteNonQuery();
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
            }
            #endregion

            #region Update Hạn thanh toán
            if (frmEditCt.dtHanTt0 != null)
            {
                sqlCom.CommandText = "sp_Update_CtHanTt";
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlCom.Parameters.Clear();
                sqlCom.Parameters.AddWithValue("@Stt", frmEditCt.strStt);
                sqlCom.Parameters.AddWithValue("@Ma_Ct", frmEditCt.drDmCt["Ma_Ct"].ToString());
                sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

                SqlParameter paraHanTt0 = new SqlParameter();
                paraHanTt0.SqlDbType = SqlDbType.Structured;
                paraHanTt0.ParameterName = "@CtHanTt";

                //Tạo dtCtHanTt từ dtHanTt0
                DataTable dtCtHanTt = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Thanh_Toan FROM R80CtHanTt WHERE 0 = 1");

                if (frmEditCt.dtHanTt0 != null)
                {
                    foreach (DataRow drHanTt0 in frmEditCt.dtHanTt0.Select())
                    {
                        DataRow drNew = dtCtHanTt.NewRow();
                        Common.CopyDataRow(drHanTt0, drNew);

                        drNew["Ma_Ct_TT"] = frmEditCt.drEditPh["Ma_Ct"];
                        drNew["Ngay_Ct_TT"] = drHanTt0["Ngay_Ct_TT"];
                        drNew["So_Ct_TT"] = frmEditCt.drEditPh["So_Ct"];
                        drNew["Dien_Giai_TT"] = frmEditCt.drEditPh["Dien_Giai"];
                        drNew["Tk"] = drHanTt0["Tk"];
                        drNew["Ma_Dt"] = drHanTt0["Ma_Dt"];
                        drNew["Stt_PT"] = (frmEditCt.enuNew_Edit == enuEdit.Edit ? drHanTt0["Stt_PT"] : frmEditCt.strStt);

                        drNew["Stt_HD"] = drHanTt0["Stt_HD"];
                        drNew["Tien_Tt"] = drHanTt0["Tien_Tt1"];
                        drNew["Tien_Tt_Nt"] = drHanTt0["Tien_Tt_Nt1"];
                        drNew["Tien_CLTG"] = drHanTt0["Tien_CLTG"];
                        drNew["LastModify_Log"] = drHanTt0["LastModify_Log"];

                        dtCtHanTt.Rows.Add(drNew);
                    }
                }

                //Tạo Table cho TVP_HanTt0
                paraHanTt0.TypeName = "TVP_CtHanTt";
                paraHanTt0.Value = GetTVPValue("R80CtHanTt", "TVP_CtHanTt", dtCtHanTt);
                sqlCom.Parameters.Add(paraHanTt0);

                try
                {
                    sqlCom.ExecuteNonQuery();
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
            }
            #endregion

            return true;
        }

        //SQLUpdateTr
        public static bool SQLUpdateCtTr(frmVoucher_Edit frmEditCt, DataTable dtEditCt_LR)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)frmEditCt.enuNew_Edit);
            sqlCom.Parameters.AddWithValue("@Stt", frmEditCt.strStt);
            sqlCom.Parameters.AddWithValue("@Ma_Ct", frmEditCt.drDmCt["Ma_Ct"].ToString());
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraPH = new SqlParameter();
            paraPH.SqlDbType = SqlDbType.Structured;
            paraPH.ParameterName = "@PH";

            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@Ct";

            SqlParameter paraCt_NxLr = new SqlParameter();
            paraCt_NxLr.SqlDbType = SqlDbType.Structured;
            paraCt_NxLr.ParameterName = "@Ct_NxLr";

            sqlCom.CommandText = "sp_Update_CtTr";

            //TVP_PHLSX
            paraPH.TypeName = "TVP_PH";
            paraPH.Value = GetTVPValue("R80PH", "TVP_PH", frmEditCt.dtEditPh);
            sqlCom.Parameters.Add(paraPH);

            paraCt.TypeName = "TVP_CTNX";
            paraCt.Value = GetTVPValue("R05CTNX", "TVP_CTNX", frmEditCt.dtEditCt);
            sqlCom.Parameters.Add(paraCt);

            paraCt_NxLr.TypeName = "TVP_CTNXLR";
            paraCt_NxLr.Value = GetTVPValue("R05CTNXLR", "TVP_CTNXLR", dtEditCt_LR);
            sqlCom.Parameters.Add(paraCt_NxLr);

            try
            {
                sqlCom.ExecuteNonQuery();

                Voucher.Update_dsVoucher(frmEditCt);
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

            return true;
        }
        //SQLDeleteCt: Cho phép Delete ở bất cứ đâu
        public static bool SQLDeleteCt(string strStt, string strMa_Ct)
        {
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

            if (drDmCt == null)
                return false;

            //Kiem tra Permission
            if (!Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_Delete))
            {
                Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
                return false;
            }

            if (!Element.sysIs_Admin)
            {
                string strCreate_User = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Create_Log), '') FROM R80Ph WHERE Stt = '" + strStt + "'");

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
                    {
                        if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                        {
                            Common.MsgCancel("Không xóa được chứng từ do " + strCreate_User + " lập, liên hệ với Admin!");
                            return false;
                        }
                    }
                }
            }

            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.Parameters.Clear();
            sqlCom.CommandText = "sp_Delete_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.Parameters.AddWithValue("@Stt", strStt);
            sqlCom.Parameters.AddWithValue("@Ma_Ct", strMa_Ct);
            sqlCom.Parameters.AddWithValue("@LastModify_Log", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            try
            {
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                return false;
            }

            return true;
        }

        public static DataTable GetTVPValue(string strTableName, string strTableTypeName, DataTable dtTableSource)
        {
            //Tạo cấu trúc bảng 
            string strSQLExec = @"
					DECLARE @_ColList VARCHAR(MAX)
					SELECT @_ColList =  CASE WHEN @_ColList IS NULL THEN '' ELSE @_ColList + ',' END + Name 
							FROM sys.columns 
							WHERE object_id IN (SELECT Type_Table_object_id FROM sys.table_types where name = '" + strTableTypeName + @"') 
							ORDER BY column_id
					SELECT @_ColList";

            string strColList = (string)SQLExec.ExecuteReturnValue(strSQLExec);
            DataTable dtTVPStructure = DataTool.SQLGetDataTable(strTableName, strColList, "0=1", ""); //Lấy cấu trúc bảng từ Bàng nguồn theo cấu trúc TableType

            //Copy dữ liệu vào bảng tham số
            if (dtTableSource != null)
            {
                foreach (DataRow drSource in dtTableSource.Rows)
                {
                    if (drSource.RowState == DataRowState.Deleted)
                        continue;

                    if (drSource.Table.Columns.Contains("Deleted") && (bool)drSource["Deleted"])
                        continue;

                    DataRow drNew = dtTVPStructure.NewRow();
                    DataTool.SetDefaultDataRow(ref drNew);

                    Common.CopyDataRow(drSource, drNew);
                    dtTVPStructure.Rows.Add(drNew);
                }
            }

            return dtTVPStructure;
        }

        //Update_Header, Update_Detail
        public static void Update_Header(frmVoucher_Edit frmEditCt)
        {//Tao cau truc column cho dtEditPh va Copy row du lieu dau tien tu dtEditCt -> drEditPh

            Common.CopyDataColumn(frmEditCt.dtEditCt, frmEditCt.drEditPh.Table, (string)frmEditCt.drDmCt["Update_Header"]);

            if (frmEditCt.enuNew_Edit == enuEdit.Edit || frmEditCt.enuNew_Edit == enuEdit.Copy)
                Common.CopyDataRow(frmEditCt.dtEditCt.Rows[0], frmEditCt.drEditPh, (string)frmEditCt.drDmCt["Update_Header"]);
            else
            {
                Common.CopyDataRow(frmEditCt.dtEditCt.Rows[0], frmEditCt.drEditPh, (string)frmEditCt.drDmCt["Update_Header"]); //Hải thêm
                Common.CopyDataRow(frmEditCt.drEdit, frmEditCt.drEditPh, (string)frmEditCt.drDmCt["Carry_Header"]);

                if (frmEditCt.dtEditPh.Columns.Contains("Ma_Dt") && frmEditCt.dtEditCt.Columns.Contains("Ma_Dt"))
                    frmEditCt.dtEditCt.Rows[0]["Ma_Dt"] = frmEditCt.dtEditPh.Rows[0]["Ma_Dt"];

                if (frmEditCt.dtEditPh.Columns.Contains("Dien_Giai") && frmEditCt.dtEditCt.Columns.Contains("Dien_Giai"))
                    frmEditCt.dtEditCt.Rows[0]["Dien_Giai"] = frmEditCt.dtEditPh.Rows[0]["Dien_Giai"];
            }
        }

        public static void Update_Detail(frmVoucher_Edit frmEditCt)
        {// Update du lieu tu drPh xuong dtCt

            string strColumnList = ((string)frmEditCt.drDmCt["Update_Detail"]);

            Update_Detail(frmEditCt, strColumnList);
        }

        public static void Update_Detail(frmVoucher_Edit frmEditCt, string strColumnList)
        {// Update du lieu tu drPh xuong dtCt theo danh sach strColumnList

            strColumnList = strColumnList.Replace(" ", "");
            Common.GatherMemvar(frmEditCt, ref frmEditCt.drEditPh);

            foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                    continue;

                Common.CopyDataRow(frmEditCt.drEditPh, dr, strColumnList);
            }
        }

        public static bool AddRow(frmVoucher_Edit frmEditCt)
        {
            DataRow drCurrent = ((DataRowView)frmEditCt.bdsEditCt.Current).Row;
            DataTable dtEditCt = (DataTable)frmEditCt.bdsEditCt.DataSource;

            double dbTien = drCurrent["Tien"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Tien"]);
            double dbTien9 = drCurrent["Tien_Nt9"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Tien_Nt9"]);
            double dbTien3 = dtEditCt.Columns.Contains("Tien3") ? (drCurrent["Tien3"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Tien3"])) : 0;
            double dbSo_Luong9 = dtEditCt.Columns.Contains("So_Luong9") ? (drCurrent["So_Luong9"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong9"])) : 0;

            bool bNewRow;

            if (dbTien + dbTien3 + dbTien9 + dbSo_Luong9 == 0)
                bNewRow = false;
            else
                bNewRow = true;

            if (bNewRow)
            {
                DataRow drNew = dtEditCt.NewRow();

                Common.SetDefaultDataRow(ref drNew);
                Common.CopyDataRow(drCurrent, drNew, ((string)frmEditCt.drDmCt["Carry_Detail"]));

                drNew["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;
                drNew["Deleted"] = false;

                if (drNew.Table.Columns.Contains("Auto_Cost"))
                {
                    if ((string)frmEditCt.drDmCt["Nh_Ct"] == "2")
                        drNew["Auto_Cost"] = true;
                    else
                        drNew["Auto_Cost"] = false;
                }

                if (frmEditCt.dtEditPh.Columns.Contains("Ma_Dt") && frmEditCt.dtEditPh.Rows[0]["Ma_Dt"].ToString() != "" && frmEditCt.dtEditCt.Columns.Contains("Ma_Dt"))
                    drNew["Ma_Dt"] = frmEditCt.dtEditPh.Rows[0]["Ma_Dt"];

                if (frmEditCt.dtEditPh.Columns.Contains("Dien_Giai") && frmEditCt.dtEditPh.Rows[0]["Dien_Giai"].ToString() != "" && frmEditCt.dtEditCt.Columns.Contains("Dien_Giai"))
                    drNew["Dien_Giai"] = frmEditCt.dtEditPh.Rows[0]["Dien_Giai"];

                dtEditCt.Rows.Add(drNew);

                drNew.AcceptChanges();
                //dtEditCt.AcceptChanges();

                //Hủy bỏ Di chuyển xuống dòng cuối cùng khi AddRow
                //frmEditCt.bdsEditCt.MoveLast();
            }

            return bNewRow;
        }

        public static void CopyNewRow(frmVoucher_Edit frmEditCt)
        {
            rsDataGridView dgvEdit = (frmEditCt.ActiveControl.GetType() == typeof(dgvVoucher) ? (rsDataGridView)frmEditCt.ActiveControl : null);
            int iCol = (dgvEdit != null ? dgvEdit.CurrentCell.ColumnIndex : 0);

            DataRow drCurrent = ((DataRowView)frmEditCt.bdsEditCt.Current).Row;
            DataTable dtEditCt = (DataTable)frmEditCt.bdsEditCt.DataSource;

            DataRow drNew = dtEditCt.NewRow();

            Common.SetDefaultDataRow(ref drNew);
            Common.CopyDataRow(drCurrent, drNew);

            drNew["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;
            drNew["Deleted"] = false;

            if (drNew.Table.Columns.Contains("So_Luong")) drNew["So_Luong"] = 0;
            if (drNew.Table.Columns.Contains("So_Luong9")) drNew["So_Luong9"] = 0;
            if (drNew.Table.Columns.Contains("Gia")) drNew["Gia"] = 0;
            if (drNew.Table.Columns.Contains("Gia_Nt")) drNew["Gia_Nt"] = 0;
            if (drNew.Table.Columns.Contains("Gia_Nt9")) drNew["Gia_Nt9"] = 0;
            if (drNew.Table.Columns.Contains("Tien")) drNew["Tien"] = 0;
            if (drNew.Table.Columns.Contains("Tien_Nt")) drNew["Tien_Nt"] = 0;
            if (drNew.Table.Columns.Contains("Tien_Nt9")) drNew["Tien_Nt9"] = 0;

            dtEditCt.Rows.Add(drNew);

            drNew.AcceptChanges();
            //dtEditCt.AcceptChanges();

            frmEditCt.bdsEditCt.MoveLast();

            if (dgvEdit != null)
                dgvEdit.CurrentRow.Cells[iCol].Selected = true;
        }

        public static bool AddRowMiddle(frmVoucher_Edit frmEditCt)
        {
            DataRow drCurrent = ((DataRowView)frmEditCt.bdsEditCt.Current).Row;
            DataTable dtEditCt = (DataTable)frmEditCt.bdsEditCt.DataSource;

            double dbTien = drCurrent["Tien"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Tien"]);
            double dbTien9 = drCurrent["Tien_Nt9"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Tien_Nt9"]);
            double dbTien3 = dtEditCt.Columns.Contains("Tien3") ? (drCurrent["Tien3"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Tien3"])) : 0;
            double dbSo_Luong9 = dtEditCt.Columns.Contains("So_Luong9") ? (drCurrent["So_Luong9"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong9"])) : 0;



            bool bNewRow;
            string strMa_Ct = frmEditCt.strMa_Ct;

            switch (strMa_Ct)
            {
                default:
                    if (dbTien + dbTien3 + dbTien9 + dbSo_Luong9 == 0)
                        bNewRow = false;
                    else
                        bNewRow = true;
                    break;
            }

            if (bNewRow)
            {
                DataRow drNew = dtEditCt.NewRow();

                Common.SetDefaultDataRow(ref drNew);
                Common.CopyDataRow(drCurrent, drNew, ((string)frmEditCt.drDmCt["Carry_Detail"]));

                //drNew["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;
                foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
                {
                    if (Convert.ToDouble(dr["Stt0"]) > Convert.ToDouble(drCurrent["Stt0"]))
                        dr["Stt0"] = Convert.ToDouble(dr["Stt0"]) + 1;
                }

                drNew["Stt0"] = Convert.ToDouble(drCurrent["Stt0"]) + 1;
                drNew["Deleted"] = false;



                //if (frmEditCt.dtEditPh.Columns.Contains("Ma_Dt") && frmEditCt.dtEditPh.Rows[0]["Ma_Dt"].ToString() != "" && frmEditCt.dtEditCt.Columns.Contains("Ma_Dt"))
                //    drNew["Ma_Dt"] = frmEditCt.dtEditPh.Rows[0]["Ma_Dt"];

                //if (frmEditCt.dtEditPh.Columns.Contains("Dien_Giai") && frmEditCt.dtEditPh.Rows[0]["Dien_Giai"].ToString() != "" && frmEditCt.dtEditCt.Columns.Contains("Dien_Giai"))
                //    drNew["Dien_Giai"] = frmEditCt.dtEditPh.Rows[0]["Dien_Giai"];

                //dtEditCt.Rows.Add(drNew);

                dtEditCt.Rows.InsertAt(drNew, frmEditCt.bdsEditCt.Position + 1);

                drNew.AcceptChanges();
            }

            return bNewRow;
        }
        public static bool AddRowMiddle(frmVoucher_Edit frmEditCt, string strColumnName)
        {

            DataRow drCurrent = ((DataRowView)frmEditCt.bdsEditCt.Current).Row;
            DataTable dtEditCt = (DataTable)frmEditCt.bdsEditCt.DataSource;

            double dbSo_Luong9 = dtEditCt.Columns.Contains("So_Luong9") ? (drCurrent["So_Luong9"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong9"])) : 0;
            bool bNewRow;
            string strMa_Ct = frmEditCt.strMa_Ct;

            switch (strMa_Ct)
            {
                default:
                    if (dbSo_Luong9 == 0)
                        bNewRow = false;
                    else
                        bNewRow = true;
                    break;
            }

            if (bNewRow)
            {
                DataRow drNew = dtEditCt.NewRow();

                Common.SetDefaultDataRow(ref drNew);
                Common.CopyDataRow(drCurrent, drNew, strColumnName);


                foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
                {
                    if (Convert.ToDouble(dr["Stt0"]) > Convert.ToDouble(drCurrent["Stt0"]))
                        dr["Stt0"] = Convert.ToDouble(dr["Stt0"]) + 1;
                }

                drNew["Stt0"] = Convert.ToDouble(drCurrent["Stt0"]) + 1;
                drNew["Deleted"] = false;

                //tạo cuối table
                //dtEditCt.Rows.Add(drNew);
                //Tạo đầu table
                //dtEditCt.Rows.InsertAt(drNew, frmEditCt.bdsEditCt.Position);
                //Tạo giữa table
                dtEditCt.Rows.InsertAt(drNew, frmEditCt.bdsEditCt.Position + 1);

                drNew.AcceptChanges();
            }

            return bNewRow;
        }
        public static bool AddRowMiddle_VTri(frmVoucher_Edit frmEditCt, BindingSource bdsEditVtri, DataTable dtEditVTri)
        {
            double dbSo_LuongOld;
            DataRow drCurrent = ((DataRowView)bdsEditVtri.Current).Row;
            DataTable dtEditCt = (DataTable)bdsEditVtri.DataSource;

            DataRow[] drViTriOld = dtEditVTri.Select("Stt_Org = '" + drCurrent["Stt_Org"].ToString() + "' AND Stt0_Org = " + drCurrent["Stt0_Org"] + "");

            dbSo_LuongOld = Convert.ToDouble(drViTriOld[0]["So_Luong"]);
            double dbSo_Luong9 = dtEditCt.Columns.Contains("So_Luong") ? (drCurrent["So_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong"])) : 0;



            bool bNewRow;
            string strMa_Ct = frmEditCt.strMa_Ct;

            switch (strMa_Ct)
            {
                default:
                    if (dbSo_Luong9 == 0)
                        bNewRow = false;
                    else
                        bNewRow = true;
                    break;
            }

            if (bNewRow)
            {
                DataRow drNew = dtEditCt.NewRow();

                Common.SetDefaultDataRow(ref drNew);
                Common.CopyDataRow(drCurrent, drNew, "Ma_Vt,Ten_Vt,Dvt,He_So9,Mo_Ta_KT,Ngay_GH,Xuat_Xu,Stt_Org,Stt0_Org,So_Ct_Org,Stt_PYC,Stt0_PYC");

                //drNew["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;
                foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
                {
                    if (Convert.ToDouble(dr["Stt0"]) > Convert.ToDouble(drCurrent["Stt0"]))
                        dr["Stt0"] = Convert.ToDouble(dr["Stt0"]) + 1;
                }
                drNew["So_Luong9"] = dbSo_LuongOld - dbSo_Luong9;
                drNew["So_Luong0"] = dbSo_LuongOld - dbSo_Luong9;
                drNew["So_Luong"] = drNew["So_Luong9"];
                drNew["Stt0"] = Convert.ToDouble(drCurrent["Stt0"]) + 1;
                drNew["Deleted"] = false;

                //tạo cuối table
                dtEditCt.Rows.Add(drNew);
                //Tạo đầu table
                //dtEditCt.Rows.InsertAt(drNew, frmEditCt.bdsEditCt.Position);
                //Tạo giữa table
                //dtEditCt.Rows.InsertAt(drNew, frmEditCt.bdsEditCt.Position +1);

                drNew.AcceptChanges();
            }

            return bNewRow;
        }
        public static void DeleteRow(frmVoucher_Edit frmEditCt, dgvVoucher dgvEditCt)
        {
            if (dgvEditCt.Focused == false)
                return;

            frmEditCt.drCurrent = ((DataRowView)frmEditCt.bdsEditCt.Current).Row;
            frmEditCt.drCurrent["Deleted"] = !((bool)frmEditCt.drCurrent["Deleted"]);

            if ((bool)frmEditCt.drCurrent["Deleted"] == true)
            {
                Font font = new Font(dgvEditCt.Font.FontFamily, dgvEditCt.Font.Size, FontStyle.Strikeout);
                dgvEditCt.CurrentRow.DefaultCellStyle.Font = font;
            }
            else
            {
                dgvEditCt.CurrentRow.DefaultCellStyle.Font = dgvEditCt.Font;
            }

            Update_TTien(frmEditCt);
        }

        //So_Luong
        public static void Calc_So_Luong(DataRow drEditCt, frmVoucher_Edit frmEditCt)
        {
            if (drEditCt["He_So9"] == DBNull.Value || Convert.ToDouble(drEditCt["He_So9"]) == 0)
                drEditCt["He_So9"] = 1;

            double dHe_So9 = Convert.ToDouble(drEditCt["He_So9"]);
            double dbSo_Luong9 = (drEditCt["So_Luong9"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["So_Luong9"]);
            double dbGia_Nt9 = (drEditCt["Gia_Nt9"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Gia_Nt9"]);
            double dbTien_Nt9 = (drEditCt["Tien_Nt9"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien_Nt9"]);
            double dbTy_Gia = Convert.ToDouble(drEditCt["Ty_Gia"]);

            //if (dbGia_Nt9 == 0 && dbSo_Luong9 != 0 && dbTien_Nt9 != 0)
            //    dbGia_Nt9 = dbTien_Nt9 / dbSo_Luong9;

            //Kiểm tra tròn tiền Tien_Nt9 = So_Luong9 * Gia_Nt9
            double dbChenh_Lech = (dbTien_Nt9 - dbSo_Luong9 * dbGia_Nt9) * dbTy_Gia;
            dbChenh_Lech = Math.Round(dbChenh_Lech, MidpointRounding.AwayFromZero);

            if (Math.Abs(dbChenh_Lech) > Convert.ToDouble(Parameters.GetParaValue("TRON_THANH_TIEN")))
            {
                if (dbTien_Nt9 == 0)
                    dbTien_Nt9 = Math.Round(dbSo_Luong9 * dbGia_Nt9, 3, MidpointRounding.AwayFromZero);
                else if (dbGia_Nt9 == 0 && dbSo_Luong9 != 0)
                    dbGia_Nt9 = dbTien_Nt9 / dbSo_Luong9;
                //Khi người dùng sửa lại So_Luong, Gia => Chương trình tính lại Tiền
                else if (Convert.ToDouble(drEditCt["So_Luong9"]) != Convert.ToDouble(drEditCt["So_Luong9", DataRowVersion.Original]) || Convert.ToDouble(drEditCt["Gia_Nt9"]) != Convert.ToDouble(drEditCt["Gia_Nt9", DataRowVersion.Original]))
                {
                    dbTien_Nt9 = Math.Round(dbSo_Luong9 * dbGia_Nt9, 3, MidpointRounding.AwayFromZero);
                }
                //Khi người dùng sửa lại Tiền => Chương trình tính lại Giá
                else if (dbSo_Luong9 != 0 && Convert.ToDouble(drEditCt["Tien_Nt9"]) != Convert.ToDouble(drEditCt["Tien_Nt9", DataRowVersion.Original]))
                {
                    dbGia_Nt9 = dbTien_Nt9 / dbSo_Luong9;
                }
                else if (((bool)frmEditCt.drDmCt["Is_Hd"] || (string)frmEditCt.strMa_Ct == "SO") && dbSo_Luong9 != 0)
                {
                    dbTien_Nt9 = Math.Round(dbSo_Luong9 * dbGia_Nt9, 3, MidpointRounding.AwayFromZero);
                }
            }

            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                dbTien_Nt9 = Math.Round(dbTien_Nt9, MidpointRounding.AwayFromZero);

            //Cap nhat So_Luong, Gia_Nt, Gia
            double dbSo_Luong = Math.Round(dbSo_Luong9 * dHe_So9, 3, MidpointRounding.AwayFromZero);
            double dbGia_Nt = Math.Round(dbGia_Nt9 / dHe_So9, 4, MidpointRounding.AwayFromZero);

            double dbGia = Math.Round(dbGia_Nt * dbTy_Gia, 3, MidpointRounding.AwayFromZero);

            drEditCt["Tien_Nt9"] = dbTien_Nt9;
            drEditCt["Gia_Nt9"] = dbGia_Nt9;
            drEditCt["So_Luong"] = dbSo_Luong;

            if ((bool)frmEditCt.drDmCt["Is_Hd"])// Hóa đơn bán hàng, hàng bán trả lại
            {
                if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                    drEditCt["Gia_Nt2"] = dbGia;
                else
                    drEditCt["Gia_Nt2"] = dbGia_Nt;

                drEditCt["Gia2"] = dbGia;

                Calc_Tien(drEditCt, frmEditCt);
            }
            else
            {
                if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                    drEditCt["Gia_Nt"] = dbGia;
                else
                    drEditCt["Gia_Nt"] = dbGia_Nt;

                drEditCt["Gia"] = dbGia;

                Calc_Tien(drEditCt, frmEditCt);
            }
        }

        public static void Calc_So_Luong_All(frmVoucher_Edit frmEditCt)
        {
            DataTable dtEditCt = frmEditCt.dtEditCt;

            for (int i = 0; i <= dtEditCt.Rows.Count - 1; i++)
            {
                DataRow drEditCt = dtEditCt.Rows[i];

                if (drEditCt.RowState == DataRowState.Deleted)
                    continue;

                if (dtEditCt.Columns.Contains("DELETED") && (bool)drEditCt["DELETED"] == true)
                    continue;

                Voucher.Calc_So_Luong(drEditCt, frmEditCt);
            }
        }

        //Tien
        public static void Calc_Tien(DataRow drEditCt, frmVoucher_Edit frmEditCt)
        {
            bool bGia_PP = drEditCt.Table.Columns.Contains("Gia_PP") ? (bool)(drEditCt["Gia_PP"]) : false;
            bool bGia_Thue = drEditCt.Table.Columns.Contains("Gia_Thue") ? (bool)(drEditCt["Gia_Thue"]) : false;

            double dbTy_Gia = Convert.ToDouble(drEditCt["Ty_Gia"]);
            double dbTien_Nt9 = drEditCt["Tien_Nt9"] == DBNull.Value ? 0 : Convert.ToDouble(drEditCt["Tien_Nt9"]);
            double dbTien_Nt = dbTien_Nt9;
            double dbTien = 0;

            if ((bool)frmEditCt.drDmCt["Is_Hd"])
                dbTien = (drEditCt["Tien2"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien2"]);
            else
                dbTien = (drEditCt["Tien"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien"]);

            //Cho phep dieu chinh trong gioi han dbTron_Tien
            if ((string)drEditCt["Ma_Tte"] != Element.sysMa_Tte)
            {
                double dbTron_Tien = Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia"));

                if (dbTien_Nt != 0)
                    if (Math.Abs(Math.Round(dbTien_Nt * dbTy_Gia - dbTien, 0, MidpointRounding.AwayFromZero)) > dbTron_Tien || dbTien == 0)
                    {
                        if ((bool)frmEditCt.drDmCt["Is_Hd"])
                        {
                            drEditCt["Tien2"] = Math.Round(Math.Round(dbTien_Nt * dbTy_Gia, 3, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);
                            drEditCt["Tien_Nt2"] = dbTien_Nt;
                        }
                        else
                        {
                            drEditCt["Tien"] = Math.Round(Math.Round(dbTien_Nt * dbTy_Gia, 3, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);
                            drEditCt["Tien_Nt"] = dbTien_Nt;

                        }



                        if (bGia_Thue && (string)frmEditCt.drDmCt["Vt_Kt"] == "V")
                            drEditCt["Tien_Nt3"] = drEditCt["Tien3"] = 0;
                    }
                if (drEditCt.Table.Columns.Contains("Tien_Tu"))
                {
                    double dbTien_Tu = Convert.ToDouble(drEditCt["Tien_Tu_Nt"]);
                    drEditCt["Tien_Tu"] = Math.Round(Math.Round(dbTien_Tu * dbTy_Gia, 3, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);

                }
            }
            else //VND
            {
                if ((bool)frmEditCt.drDmCt["Is_Hd"])
                {
                    drEditCt["Tien_Nt2"] = Math.Round(dbTien_Nt, MidpointRounding.AwayFromZero);
                    drEditCt["Tien2"] = Math.Round(dbTien_Nt, MidpointRounding.AwayFromZero);
                }
                else
                {
                    drEditCt["Tien_Nt"] = Math.Round(dbTien_Nt, MidpointRounding.AwayFromZero);
                    drEditCt["Tien"] = Math.Round(dbTien_Nt, MidpointRounding.AwayFromZero);
                }

                if (bGia_Thue && (string)frmEditCt.drDmCt["Vt_Kt"] == "V")
                    drEditCt["Tien_Nt3"] = drEditCt["Tien3"] = 0;

                if (drEditCt.Table.Columns.Contains("Tien_Tu"))
                    drEditCt["Tien_Tu"] = drEditCt["Tien_Tu_Nt"];
            }

            if ((bool)frmEditCt.drDmCt["Is_Hd"])
            {
                Voucher.Calc_Chiet_Khau(drEditCt);
                if (drEditCt.Table.Columns.Contains("Ma_Thue"))
                    Voucher.Calc_Thue_Vat(drEditCt, frmEditCt);
                return;
            }

            drEditCt.AcceptChanges();

            if (drEditCt.Table.Columns.Contains("Ma_Thue"))
                Voucher.Calc_Thue_Vat(drEditCt, frmEditCt);
        }

        public static void Calc_Tien_All(frmVoucher_Edit frmEditCt)
        {
            DataTable dtEditCt = frmEditCt.dtEditCt;

            for (int i = 0; i <= dtEditCt.Rows.Count - 1; i++)
            {
                DataRow drEditCt = dtEditCt.Rows[i];

                if (drEditCt.RowState == DataRowState.Deleted)
                    continue;

                if (dtEditCt.Columns.Contains("DELETED") && (bool)drEditCt["DELETED"] == true)
                    continue;

                Voucher.Calc_Tien(drEditCt, frmEditCt);
            }

            Voucher.Adjust_TTien(frmEditCt);

            if ((bool)frmEditCt.drDmCt["Is_Hd"])
                Voucher.Adjust_Chiet_Khau(frmEditCt);

            Voucher.Adjust_TThue_Vat(frmEditCt);

            Voucher.Update_TTien(frmEditCt);
        }

        public static void Adjust_TTien(frmVoucher_Edit frmEditCt)
        {//Tinh lai tien theo tong tien va ty gia, dieu chinh vao dong lon nhat

            string strKeyFilter = "Deleted <> true";
            Voucher.Update_TTien(frmEditCt);

            DataTable dtEditCt = frmEditCt.dtEditCt;
            DataRow drEditPh = frmEditCt.drEditPh;

            double dbTy_Gia = Convert.ToDouble(drEditPh["Ty_Gia"]);
            double dbTTien = Convert.ToDouble(drEditPh["TTien0"]);
            double dbTTien_Nt = Convert.ToDouble(drEditPh["TTien_Nt0"]);

            if (Convert.ToBoolean(frmEditCt.drDmCt["Adjust_TTien_By_Exchange"]) == true)
            {
                double dbChenh_Lech = dbTTien - Math.Round(dbTTien_Nt * dbTy_Gia, MidpointRounding.AwayFromZero);

                if ((bool)frmEditCt.drDmCt["Is_Hd"])
                {
                    if (Math.Abs(dbChenh_Lech) >= Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia")))
                    {
                        int iMaxRow = Common.MaxDCPosition(dtEditCt, "Tien2", strKeyFilter);

                        DataRow drMax = dtEditCt.Rows[iMaxRow];
                        drMax["Tien2"] = Convert.ToDouble(drMax["Tien2"]) - Math.Round(dbChenh_Lech, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    if (Math.Abs(dbChenh_Lech) >= Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia")))
                    {
                        int iMaxRow = Common.MaxDCPosition(dtEditCt, "Tien", strKeyFilter);

                        DataRow drMax = dtEditCt.Rows[iMaxRow];
                        drMax["Tien"] = Convert.ToDouble(drMax["Tien"]) - Math.Round(dbChenh_Lech, MidpointRounding.AwayFromZero);
                    }
                }
            }
        }

        public static void Calc_Tien_Von(DataRow drEditCt) //Tính giá vốn trên trường số lượng (không tính trên Quy đổi)
        {
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", (string)drEditCt["Ma_Ct"]);

            double dbSo_Luong = (drEditCt["So_Luong"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["So_Luong"]);
            double dbGia_Nt = (drEditCt["Gia_Nt"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Gia_Nt"]);
            double dbGia = (drEditCt["Gia"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Gia"]);
            double dbTien_Nt = (drEditCt["Tien_Nt"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien_Nt"]);
            double dbTien = (drEditCt["Tien"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien"]);
            double dbTy_Gia = Convert.ToDouble(drEditCt["Ty_Gia"]);

            //if (dbGia_Nt == 0 && dbSo_Luong != 0 && dbTien_Nt != 0)
            //    dbGia_Nt = dbTien_Nt / dbSo_Luong;

            //Kiểm tra tròn tiền Tien_Nt = So_Luong * Gia_Nt
            double dbChenh_Lech = (dbTien_Nt - dbSo_Luong * dbGia_Nt) * dbTy_Gia;
            dbChenh_Lech = Math.Round(dbChenh_Lech, MidpointRounding.AwayFromZero);

            if (Math.Abs(dbChenh_Lech) > Convert.ToDouble(Parameters.GetParaValue("TRON_THANH_TIEN")))
            {
                if (dbTien_Nt == 0)
                    dbTien_Nt = Math.Round(dbSo_Luong * dbGia_Nt, 2, MidpointRounding.AwayFromZero);
                else if (dbGia_Nt == 0 && dbSo_Luong != 0)
                    dbGia_Nt = dbTien_Nt / dbSo_Luong;

                //Khi người dùng sửa lại So_Luong, Gia => Chương trình tính lại Tiền
                else if (Convert.ToDouble(drEditCt["So_Luong"]) != Convert.ToDouble(drEditCt["So_Luong", DataRowVersion.Original]) || Convert.ToDouble(drEditCt["Gia_Nt"]) != Convert.ToDouble(drEditCt["Gia_Nt", DataRowVersion.Original]))
                {
                    dbTien_Nt = Math.Round(dbSo_Luong * dbGia_Nt, 2, MidpointRounding.AwayFromZero);
                }
                //Khi người dùng sửa lại Tiền => Chương trình tính lại Giá
                else if (dbSo_Luong != 0 && Convert.ToDouble(drEditCt["Tien_Nt"]) != Convert.ToDouble(drEditCt["Tien_Nt", DataRowVersion.Original]))
                {
                    dbGia_Nt = dbTien_Nt / dbSo_Luong;
                }
            }

            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                dbTien_Nt = Math.Round(dbTien_Nt, MidpointRounding.AwayFromZero);

            //Cap nhat So_Luong, Gia_Nt, Gia
            dbGia = Math.Round(dbGia_Nt * dbTy_Gia, 2, MidpointRounding.AwayFromZero);

            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                dbGia_Nt = dbGia;

            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                dbTien = Math.Round(dbTien_Nt, MidpointRounding.AwayFromZero);
            else
                dbTien = Math.Round(Math.Round(dbTien_Nt * dbTy_Gia, 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);

            drEditCt["Tien_Nt"] = dbTien_Nt;
            drEditCt["Tien"] = dbTien;
            drEditCt["Gia_Nt"] = dbGia_Nt;
            drEditCt["Gia"] = dbGia;

            //drEditCt.AcceptChanges();
        }

        public static void Calc_Tien_Von_All(frmVoucher_Edit frmEditCt)
        {
            DataTable dtEditCt = frmEditCt.dtEditCt;

            for (int i = 0; i <= dtEditCt.Rows.Count - 1; i++)
            {
                DataRow drEditCt = dtEditCt.Rows[i];

                if (drEditCt.RowState == DataRowState.Deleted)
                    continue;

                if (dtEditCt.Columns.Contains("DELETED") && (bool)drEditCt["DELETED"] == true)
                    continue;

                if (dtEditCt.Columns.Contains("AUTO_COST") && (bool)drEditCt["AUTO_COST"] == true)
                    continue;

                Calc_Tien_Von(drEditCt);
            }
        }
        //Tiền CK
        public static void Calc_ChietKhau(DataRow drEditCt, frmVoucher_Edit frmEditCt)
        {
            double dbTien_Nt4 = 0, dbTien4 = 0;
            if (drEditCt.Table.Columns.Contains("Tien_Nt4"))
            {
                dbTien_Nt4 = drEditCt["Tien_Nt4"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien_Nt4"]) : 0;
                dbTien4 = drEditCt["Tien4"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien4"]) : 0;
            }
            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                drEditCt["Tien4"] = drEditCt["Tien_Nt4"];
        }
        //Thue_VAT
        public static void Calc_Thue_Vat(DataRow drEditCt, frmVoucher_Edit frmEditCt)
        {
            if (drEditCt["Ma_Thue"].ToString() == string.Empty)
            {
                drEditCt["Tien_Nt3"] = 0;
                drEditCt["Tien3"] = 0;

                drEditCt.AcceptChanges();
                return;
            }

            DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DMTHUE", "Ma_Thue", (string)drEditCt["Ma_Thue"]);

            if (drDmThue == null || frmEditCt.drDmCt == null)
                return;

            double dbTy_Gia = Convert.ToDouble(drEditCt["Ty_Gia"]);
            double dbThue_Gtgt = Convert.ToDouble(drEditCt["Thue_Gtgt"]);
            bool bGia_PP = drEditCt.Table.Columns.Contains("Gia_PP") ? (bool)(drEditCt["Gia_PP"]) : false;
            bool bGia_Thue = drEditCt.Table.Columns.Contains("Gia_Thue") ? (bool)(drEditCt["Gia_Thue"]) : false;

            double dbTien_Nt9 = Convert.ToDouble(drEditCt["Tien_Nt9"]);
            double dbTien9 = Math.Round(Math.Round(dbTien_Nt9 * dbTy_Gia, 3, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);
            double dbTien_Nt4 = 0, dbTien4 = 0;
            double dbTien_Nt5 = 0, dbTien5 = 0;
            double dbTien_Nt6 = 0, dbTien6 = 0;
            double dbTien_Nt7 = 0, dbTien7 = 0;

            double dbTien_Nt = 0, dbTien = 0;

            //Gia co phu phi
            if (bGia_PP)
            {
                double dbTien_Nt3_ = drEditCt["Tien_Nt3"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien_Nt3"]) : 0;
                double dbTien3_ = drEditCt["Tien3"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien3"]) : 0;

                //Người dùng gõ tay vào trường Tien3 -> Tính lại Tien_Nt3
                double dbChenh_Lech_Ty_Gia = dbTien3_ - dbTien_Nt3_ * dbTy_Gia;
                if (Math.Abs(dbChenh_Lech_Ty_Gia) > Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia")))
                    drEditCt["Tien_Nt3"] = Math.Round(dbTien3_ / dbTy_Gia, 3, MidpointRounding.AwayFromZero);

                if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte && Element.sysMa_Tte == "VND")
                    drEditCt["Tien_Nt3"] = drEditCt["Tien3"] = Math.Round(dbTien3_, 0, MidpointRounding.AwayFromZero);
                //ƯU TIÊN TIỀN NT3
                if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte && Element.sysMa_Tte == "VND" && (string)drEditCt["Ma_Ct"] == "DNTT")
                    drEditCt["Tien_Nt3"] = drEditCt["Tien3"] = Math.Round(dbTien_Nt3_, 0, MidpointRounding.AwayFromZero);

                return;
            }

            dbTien_Nt = (bool)frmEditCt.drDmCt["Is_Hd"] ? Convert.ToDouble(drEditCt["Tien_Nt2"]) : Convert.ToDouble(drEditCt["Tien_Nt"]);
            dbTien = (bool)frmEditCt.drDmCt["Is_Hd"] ? Convert.ToDouble(drEditCt["Tien2"]) : Convert.ToDouble(drEditCt["Tien"]);

            // Tru Tien Chiet khau
            if (drEditCt.Table.Columns.Contains("Tien_Nt4"))
            {
                dbTien_Nt4 = drEditCt["Tien_Nt4"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien_Nt4"]) : 0;
                dbTien4 = drEditCt["Tien4"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien4"]) : 0;
            }

            // Cong thue nhap khau vao
            if (drEditCt.Table.Columns.Contains("Tien_Nt5"))
            {
                dbTien_Nt5 = drEditCt["Tien_Nt5"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien_Nt5"]) : 0;
                dbTien5 = drEditCt["Tien5"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien5"]) : 0;
            }

            // Cong thue tieu thu dac biet vao
            if (drEditCt.Table.Columns.Contains("Tien6"))
            {
                dbTien_Nt6 = drEditCt["Tien_Nt6"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien_Nt6"]) : 0;
                dbTien6 = drEditCt["Tien6"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien6"]) : 0;
            }

            // Cong thue BVMT
            if (drEditCt.Table.Columns.Contains("Tien7"))
            {
                dbTien_Nt7 = drEditCt["Tien_Nt7"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien_Nt7"]) : 0;
                dbTien7 = drEditCt["Tien7"] != DBNull.Value ? Convert.ToDouble(drEditCt["Tien7"]) : 0;
            }

            double dbTien_Nt3 = drEditCt["Tien_Nt3"] == DBNull.Value ? 0 : Convert.ToDouble(drEditCt["Tien_Nt3"]);
            double dbTien3 = drEditCt["Tien3"] == DBNull.Value ? 0 : Convert.ToDouble(drEditCt["Tien3"]);

            double dbTien_Nt3_Calc = 0;
            double dbTien3_Calc = 0;

            if (drDmThue == null)
                return;

            //Gia da bao gom VAT
            if (bGia_Thue)
            {
                double dbThue_Suat = Convert.ToDouble(dbThue_Gtgt) / 100;
                dbTien_Nt3_Calc = Math.Round(Math.Ceiling(((dbTien_Nt9 + dbTien_Nt5 + dbTien_Nt6 + dbTien_Nt7 - dbTien_Nt4) * dbThue_Suat / (1 + dbThue_Suat)) * 100) / 100, 2, MidpointRounding.AwayFromZero);
                dbTien3_Calc = Math.Round(Math.Ceiling(((dbTien9 + dbTien5 + dbTien6 + dbTien7 - dbTien4) * dbThue_Suat / (1 + dbThue_Suat)) * 100) / 100, MidpointRounding.AwayFromZero);

                if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                    dbTien_Nt3_Calc = Math.Round(dbTien_Nt3_Calc, MidpointRounding.AwayFromZero);
            }
            else
            {
                dbTien_Nt3_Calc = Math.Round(Math.Ceiling(((dbTien_Nt9 + dbTien_Nt5 + dbTien_Nt6 + dbTien_Nt7 - dbTien_Nt4) * dbThue_Gtgt) * 100) / 100 / 100, 2, MidpointRounding.AwayFromZero);
                dbTien3_Calc = Math.Round(Math.Ceiling(((dbTien9 + dbTien5 + dbTien6 + dbTien7 - dbTien4) * dbThue_Gtgt / 100) * 100) / 100, MidpointRounding.AwayFromZero);

                if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                    dbTien_Nt3_Calc = Math.Round(dbTien_Nt3_Calc, MidpointRounding.AwayFromZero);
            }

            //Cho phep dieu chinh trong gioi han dbTron_Vat
            double dbTron_Vat = Convert.ToDouble(Parameters.GetParaValue("Tron_VAT"));

            if (Math.Abs(dbTien3_Calc - dbTien3) > dbTron_Vat || Math.Abs(dbTien_Nt3_Calc - dbTien_Nt3) * dbTy_Gia > dbTron_Vat || dbTien3 == 0)
            {
                drEditCt["Tien3"] = dbTien3_Calc;
                drEditCt["Tien_Nt3"] = dbTien_Nt3_Calc;
            }

            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                drEditCt["Tien3"] = drEditCt["Tien_Nt3"];

            if (bGia_Thue) //Chỉ cập nhật lại Tiền khi Giá đã bao gồm thuế VAT
            {
                if ((bool)frmEditCt.drDmCt["Is_Hd"]) // Hóa đơn bán hàng
                {
                    drEditCt["Tien_Nt2"] = (dbTien_Nt9 + dbTien_Nt5 + dbTien_Nt6 + dbTien_Nt7 - dbTien_Nt4) - dbTien_Nt3_Calc;
                    drEditCt["Tien2"] = (dbTien9 + dbTien5 + dbTien6 + dbTien7 - dbTien4) - dbTien3_Calc;
                }
                else
                {
                    drEditCt["Tien_Nt"] = (dbTien_Nt9 + dbTien_Nt5 + dbTien_Nt6 + dbTien_Nt7 - dbTien_Nt4) - dbTien_Nt3_Calc;
                    drEditCt["Tien"] = (dbTien9 + dbTien5 + dbTien6 + dbTien7 - dbTien4) - dbTien3_Calc;
                }
            }

            drEditCt.AcceptChanges();
        }

        public static void Calc_Thue_Vat_All(frmVoucher_Edit frmEditCt)
        {
            DataTable dtEditCt = frmEditCt.dtEditCt;

            for (int i = 0; i <= frmEditCt.dtEditCt.Rows.Count - 1; i++)
            {
                DataRow drEditCt = frmEditCt.dtEditCt.Rows[i];

                if (drEditCt.RowState == DataRowState.Deleted)
                    continue;

                if (dtEditCt.Columns.Contains("DELETED") && (bool)drEditCt["DELETED"] == true)
                    continue;

                Voucher.Calc_Thue_Vat(drEditCt, frmEditCt);
            }

            Voucher.Update_TTien(frmEditCt);

            Voucher.Adjust_TThue_Vat(frmEditCt);
        }

        public static void Adjust_TThue_Vat(frmVoucher_Edit frmEditCt)
        {
            Adjust_TThue_Vat(frmEditCt, false);
        }

        public static void Adjust_TThue_Vat(frmVoucher_Edit frmEditCt, bool bTinhLaiThue)
        {//Tinh lai tien thue theo tong tien va thue suat, dieu chinh vao dong lon nhat

            if (frmEditCt.drDmCt.Table.Columns.Contains("Adjust_TTien_By_VatRate") && !Convert.ToBoolean(frmEditCt.drDmCt["Adjust_TTien_By_VatRate"]) == true)
                return;

            if (!frmEditCt.dtEditCt.Columns.Contains("Tien3"))
                return;

            string strMa_Thue = (string)frmEditCt.dtEditCt.Rows[0]["Ma_Thue"];
            string strMa_Tte = (string)frmEditCt.dtEditCt.Rows[0]["Ma_Tte"];

            int iRound_Nt = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

            DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DmThue", "Ma_Thue", strMa_Thue);
            if (drDmThue == null)
            {
                foreach (DataRow drEditCt in frmEditCt.dtEditCt.Rows)
                {
                    if (drEditCt.RowState == DataRowState.Deleted)
                        continue;

                    drEditCt["Thue_GtGt"] = 0;
                    drEditCt["Tien_Nt3"] = 0;
                    drEditCt["Tien3"] = 0;
                }

                Update_TTien(frmEditCt);
                return;
            }

            string strKeyFilter = "Deleted <> true";
            double dbTy_Gia = Convert.ToDouble(frmEditCt.drEditPh["Ty_Gia"]);
            double dbThue_GtGt = Convert.ToDouble(drDmThue["Thue_Suat"]);
            bool bGia_PP = frmEditCt.dtEditCt.Columns.Contains("Gia_PP") ? (bool)(frmEditCt.dtEditCt.Rows[0]["Gia_PP"]) : false;
            bool bGia_Thue = frmEditCt.dtEditCt.Columns.Contains("Gia_Thue") ? (bool)(frmEditCt.dtEditCt.Rows[0]["Gia_Thue"]) : false;

            double dbTTien3 = Convert.ToDouble(frmEditCt.drEditPh["TTien3"]);
            double dbTTien_Nt3 = Convert.ToDouble(frmEditCt.drEditPh["TTien_Nt3"]);

            double dbTTien = Common.SumDCValue(frmEditCt.dtEditCt, (bool)frmEditCt.drDmCt["Is_Hd"] ? "Tien2" : "Tien", strKeyFilter);
            double dbTTien_Nt = Common.SumDCValue(frmEditCt.dtEditCt, (bool)frmEditCt.drDmCt["Is_Hd"] ? "Tien_Nt2" : "Tien_Nt", strKeyFilter);

            double dbTtien_Nt4 = 0, dbTtien4 = 0;

            double dbTien_Nt4 = 0, dbTien4 = 0;

            // Tru Tien Chiet khau
            if (frmEditCt.dtEditPh.Columns.Contains("Ttien_Nt4"))
            {
                dbTtien_Nt4 = frmEditCt.drEditPh["Ttien_Nt4"] != DBNull.Value ? Convert.ToDouble(frmEditCt.drEditPh["Ttien_Nt4"]) : 0;
                dbTtien4 = frmEditCt.drEditPh["Ttien4"] != DBNull.Value ? Convert.ToDouble(frmEditCt.drEditPh["Ttien4"]) : 0;
            }

            if (strMa_Tte == Element.sysMa_Tte)
            {
                dbTTien = dbTTien_Nt;
                dbTTien3 = dbTTien_Nt3;
            }

            if (!bGia_PP)// Giá không có phụ phí
            {
                if (!bTinhLaiThue)
                {
                    double dbCheck_Chenh_Lech3 = dbTTien3 - (dbTTien * dbThue_GtGt / 100);
                    double dbCheck_Chenh_Lech_Nt3 = dbTTien_Nt3 - (dbTTien_Nt * dbThue_GtGt / 100);

                    dbCheck_Chenh_Lech3 = Math.Round(dbCheck_Chenh_Lech3, MidpointRounding.AwayFromZero);
                    dbCheck_Chenh_Lech_Nt3 = Math.Round(dbCheck_Chenh_Lech_Nt3, iRound_Nt, MidpointRounding.AwayFromZero);

                    if (Math.Abs(dbCheck_Chenh_Lech3) > Convert.ToDouble(Parameters.GetParaValue("Tron_Vat")) ||
                        Math.Abs(dbCheck_Chenh_Lech_Nt3) * dbTy_Gia > Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia")))
                    {//Reset tro ve so ban dau

                        Voucher.Update_TTien(frmEditCt);
                        return;
                    }
                }
                else
                {
                    dbTTien_Nt3 = Math.Round(Math.Ceiling((((dbTTien_Nt - dbTtien_Nt4) * dbThue_GtGt) / 100) * 100) / 100, iRound_Nt, MidpointRounding.AwayFromZero);
                    dbTTien3 = Math.Round(Math.Ceiling((((dbTTien - dbTtien4) * dbThue_GtGt) / 100) * 100) / 100, MidpointRounding.AwayFromZero);
                }
            }

            if (bGia_PP && strMa_Tte != Element.sysMa_Tte)
            {
                if (dbTTien3 - Math.Round(dbTTien_Nt3 * dbTy_Gia, MidpointRounding.AwayFromZero) > Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia")))
                {
                    Voucher.Update_TTien(frmEditCt);
                    return;
                }
            }

            if (dbTTien == 0)
                dbThue_GtGt = 0;
            else
                dbThue_GtGt = dbTTien3 / (dbTTien - dbTtien4);

            if (bGia_Thue)
            {//Giá có thuế
                double dbTien_Nt = 0, dbTien = 0;
                double dbTien_Nt3 = 0, dbTien3 = 0;

                foreach (DataRow dr in frmEditCt.dtEditCt.Select(strKeyFilter))
                {
                    if (dr.RowState == DataRowState.Deleted)
                        continue;

                    dbTien_Nt = Convert.ToDouble(dr[(bool)frmEditCt.drDmCt["Is_Hd"] ? "Tien_Nt2" : "Tien_Nt"]);
                    dbTien = Convert.ToDouble(dr[(bool)frmEditCt.drDmCt["Is_Hd"] ? "Tien2" : "Tien"]);

                    dbTien_Nt3 = Convert.ToDouble(dr["Tien_Nt3"]);
                    dbTien3 = Convert.ToDouble(dr["Tien3"]);

                    dbTien_Nt += dbTien_Nt3;
                    dbTien += dbTien3;

                    dr["Tien_Nt3"] = dbTien_Nt3 = Math.Round(dbTien_Nt * dbThue_GtGt / (1 + dbThue_GtGt), 2, MidpointRounding.AwayFromZero);
                    dr["Tien3"] = dbTien3 = Math.Round(Math.Round(dbTien * dbThue_GtGt / (1 + dbThue_GtGt), 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);

                    dr[(bool)frmEditCt.drDmCt["Is_Hd"] ? "Tien_Nt2" : "Tien_Nt"] = dbTien_Nt - dbTien_Nt3;
                    dr[(bool)frmEditCt.drDmCt["Is_Hd"] ? "Tien2" : "Tien"] = dbTien - dbTien3;
                }
            }
            else
            {//Giá không thuế

                foreach (DataRow dr in frmEditCt.dtEditCt.Select(strKeyFilter))
                {
                    if (dr.RowState == DataRowState.Deleted)
                        continue;

                    // Tru Tien Chiet khau
                    if (frmEditCt.dtEditCt.Columns.Contains("Tien_Nt4"))
                    {
                        dbTien_Nt4 = dr["Tien_Nt4"] != DBNull.Value ? Convert.ToDouble(dr["Tien_Nt4"]) : 0;
                        dbTien4 = dr["Tien4"] != DBNull.Value ? Convert.ToDouble(dr["Tien4"]) : 0;
                    }

                    dr["Tien_Nt3"] = Math.Round((Convert.ToDouble(dr[(bool)frmEditCt.drDmCt["Is_Hd"] ? "Tien_Nt2" : "Tien_Nt"]) - dbTien_Nt4) * dbThue_GtGt, iRound_Nt, MidpointRounding.AwayFromZero);
                    dr["Tien3"] = Math.Round(Math.Round((Convert.ToDouble(dr[(bool)frmEditCt.drDmCt["Is_Hd"] ? "Tien2" : "Tien"]) - dbTien4) * dbThue_GtGt, 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);
                }

                double dbTTien3_ = Math.Round(Common.SumDCValue(frmEditCt.dtEditCt, "Tien3", strKeyFilter), MidpointRounding.AwayFromZero);
                double dbTTien_Nt3_ = Math.Round(Common.SumDCValue(frmEditCt.dtEditCt, "Tien_Nt3", strKeyFilter), iRound_Nt, MidpointRounding.AwayFromZero);

                int iMaxRow_ = Common.MaxDCPosition(frmEditCt.dtEditCt, "Tien3", strKeyFilter);
                DataRow drMax_ = frmEditCt.dtEditCt.Rows[iMaxRow_];

                if (dbTTien3 != dbTTien3_ && dbTTien3 != 0)
                    drMax_["Tien3"] = Convert.ToDouble(drMax_["Tien3"]) + (dbTTien3 - dbTTien3_);

                if (dbTTien_Nt3 != dbTTien_Nt3_ && dbTTien_Nt3 != 0)
                    drMax_["Tien_Nt3"] = Convert.ToDouble(drMax_["Tien_Nt3"]) + (dbTTien_Nt3 - dbTTien_Nt3_);
            }

            Voucher.Update_TTien(frmEditCt);
        }

        //Chiet_Khau
        public static void Calc_Chiet_Khau(DataRow drEditCt)
        {
            string strMa_Tte = (string)drEditCt["Ma_Tte"];

            double dbTien_Nt9 = (drEditCt["Tien_Nt9"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien_Nt9"]);
            double dbTien_Nt4 = (drEditCt["Tien_Nt4"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien_Nt4"]);
            double dbTien4 = (drEditCt["Tien4"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien4"]);
            double dbChiet_Khau = Convert.ToDouble(drEditCt["Chiet_Khau"]);
            double dbTien_Nt4_Calc = 0;
            double dbTien4_Calc = 0;
            double dbTy_Gia = Convert.ToDouble(drEditCt["Ty_Gia"]);
            if (dbChiet_Khau != 0)
            {
                dbTien_Nt4_Calc = Math.Round(dbTien_Nt9 * dbChiet_Khau / 100, 2, MidpointRounding.AwayFromZero);
                dbTien4_Calc = Math.Round(Math.Round(dbTien_Nt9 * dbTy_Gia * dbChiet_Khau / 100, 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);
            }
            else
            {
                dbTien_Nt4_Calc = dbTien_Nt4;
                dbTien4_Calc = dbTien4;
            }

            if (strMa_Tte == Element.sysMa_Tte)
            {
                dbTien_Nt4_Calc = dbTien4_Calc;
            }

            if (dbChiet_Khau == 0 && drEditCt.HasVersion(DataRowVersion.Original) && drEditCt["Chiet_Khau"] == drEditCt["Chiet_Khau", DataRowVersion.Original])
                return;

            //Cho phep dieu chinh trong gioi han dbTron_Vat
            double dbTron_Chiet_Khau = Convert.ToDouble(Parameters.GetParaValue("Tron_Chiet_Khau"));

            if (Math.Abs(dbTien4_Calc - dbTien4) > dbTron_Chiet_Khau || Math.Abs(dbTien_Nt4_Calc - dbTien_Nt4) * dbTy_Gia > dbTron_Chiet_Khau || dbTien4 == 0)
            {
                drEditCt["Tien_Nt4"] = dbTien_Nt4_Calc;
                drEditCt["Tien4"] = dbTien4_Calc;
            }


            if ((string)drEditCt["Tk_No4"] == string.Empty)
            {
                drEditCt["Tien_Nt2"] = dbTien_Nt9 - dbTien_Nt4_Calc;
                drEditCt["Tien2"] = Math.Round(Math.Round(dbTien_Nt9 * dbTy_Gia, 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero) - dbTien4_Calc;
            }

            if (Convert.ToDouble(drEditCt["So_Luong9"]) != 0)
            {
                drEditCt["Gia_Nt2"] = Convert.ToDouble(drEditCt["Tien_Nt2"]) / Convert.ToDouble(drEditCt["So_Luong9"]);
                drEditCt["Gia2"] = Convert.ToDouble(drEditCt["Tien2"]) / Convert.ToDouble(drEditCt["So_Luong9"]);
            }

            drEditCt.AcceptChanges();
        }

        public static void Calc_Chiet_Khau_All(frmVoucher_Edit frmEditCt)
        {
            DataTable dtEditCt = frmEditCt.dtEditCt;

            foreach (DataRow drEditCt in dtEditCt.Rows)
            {
                if (drEditCt.RowState == DataRowState.Deleted)
                    continue;

                if (dtEditCt.Columns.Contains("Deleted") && (bool)drEditCt["Deleted"] == true)
                    continue;

                Calc_Chiet_Khau(drEditCt);
                Calc_Thue_Vat(drEditCt, frmEditCt);
            }

            Update_TTien(frmEditCt);
        }

        public static void Adjust_Chiet_Khau(frmVoucher_Edit frmEditCt)
        {
            DataTable dtEditCt = frmEditCt.dtEditCt;
            DataRow drEditPh = frmEditCt.drEditPh;

            string strMa_Tte = drEditPh["Ma_Tte"].ToString();
            double dbTy_Gia = Convert.ToDouble(drEditPh["Ty_Gia"]);
            double dbChiet_Khau = Convert.ToDouble(drEditPh["Chiet_Khau"]);

            double dbTTien_Nt9 = Common.SumDCValue(frmEditCt.dtEditCt, "Tien_Nt9", "Deleted <> true");
            double dbTTien4 = Convert.ToDouble(frmEditCt.drEditPh["TTien4"]);
            double dbTTien_Nt4 = Convert.ToDouble(frmEditCt.drEditPh["TTien_Nt4"]);

            double dbTTien_Nt4_Calc = Math.Round(dbTTien_Nt9 * dbChiet_Khau / 100, 2, MidpointRounding.AwayFromZero);
            double dbTTien4_Calc = Math.Round(Math.Round(dbTTien_Nt4_Calc * dbTy_Gia, 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero);

            if (Element.sysMa_Tte == strMa_Tte)
                dbTTien_Nt4_Calc = dbTTien4_Calc;

            double dbChenh_Lech = dbTTien4 - dbTTien4_Calc;
            double dbChenh_Lech_Nt = dbTTien_Nt4 - dbTTien_Nt4_Calc;

            if (Math.Abs(dbChenh_Lech) > Convert.ToDouble(Parameters.GetParaValue("Tron_Chiet_Khau")) || Math.Abs(dbChenh_Lech_Nt) * dbTy_Gia > Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia")))
            {//Reset tro ve so ban dau

                Voucher.Update_TTien(frmEditCt);
                return;
            }

            double dbTTien4_Current = Common.SumDCValue(frmEditCt.dtEditCt, "Tien4", "Deleted <> true");
            double dbTTien_Nt4_Current = Common.SumDCValue(frmEditCt.dtEditCt, "Tien_Nt4", "Deleted <> true");

            int iMax = Common.MaxDCPosition(dtEditCt, "Tien4", "Deleted <> true");
            DataRow drEditCt = dtEditCt.Rows[iMax];

            if (dbTTien4 != dbTTien4_Current)
            {
                drEditCt["Tien4"] = Convert.ToDouble(drEditCt["Tien4"]) + (dbTTien4 - dbTTien4_Current);
            }

            if (dbTTien_Nt4 != dbTTien_Nt4_Current)
            {
                drEditCt["Tien_Nt4"] = Convert.ToDouble(drEditCt["Tien_Nt4"]) + (dbTTien_Nt4 - dbTTien_Nt4_Current);
            }

            Voucher.Update_TTien(frmEditCt);
        }

        //Thue_Nk
        public static void Calc_Thue_Nk(DataRow drEditCt, frmVoucher_Edit frmEditCt)
        {
            double dbThue_Nk = (drEditCt["Thue_Nk"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Thue_Nk"]);
            double dbThue_Nk_Org = (drEditCt["Thue_Nk", DataRowVersion.Original] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Thue_Nk", DataRowVersion.Original]);

            if (dbThue_Nk == 0 && dbThue_Nk_Org != 0) //Xóa bỏ thuế suất NK
            {
                drEditCt["Thue_Nk"] = 0;
                drEditCt["Tien5"] = 0;
                drEditCt["Tien_Nt5"] = 0;

                drEditCt["Tk_No5"] = string.Empty;
                drEditCt["Tk_Co5"] = string.Empty;

                drEditCt.AcceptChanges();

                Calc_Thue_Vat(drEditCt, frmEditCt);
                return;
            }

            double dbTien = (drEditCt["Tien"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien"]);
            double dbTien_Nt5 = (drEditCt["Tien_Nt5"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien_Nt5"]);
            double dbTien5 = (drEditCt["Tien5"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien5"]);
            double dbTien5_Cal = 0;
            double dbTy_Gia = Convert.ToDouble(drEditCt["Ty_Gia"]);

            if (dbThue_Nk != 0) //Tính Thuế NK theo thuế suất
            {
                dbTien5_Cal = Math.Round(dbTien * dbThue_Nk / 100, 0, MidpointRounding.AwayFromZero);
            }
            else //Người dùng gõ tay thuế NK
            {
                dbTien5_Cal = Math.Round(dbTien5, 0, MidpointRounding.AwayFromZero);
            }

            //Điều chỉnh tiền
            if (Math.Abs(Math.Round(dbTien5_Cal - dbTien_Nt5 * dbTy_Gia, 0, MidpointRounding.AwayFromZero)) > Convert.ToDouble(Parameters.GetParaValue("TRON_VAT")))
            {
                dbTien_Nt5 = Math.Round(dbTien5_Cal / dbTy_Gia, 2, MidpointRounding.AwayFromZero);
            }

            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                dbTien_Nt5 = dbTien5_Cal;

            drEditCt["Tien5"] = dbTien5_Cal;
            drEditCt["Tien_Nt5"] = dbTien_Nt5;

            if (dbTien5_Cal == 0)
            {
                drEditCt["Tk_No5"] = string.Empty;
                drEditCt["Tk_Co5"] = string.Empty;
            }
            else
            {
                if (drEditCt["Tk_No5"] == DBNull.Value || (string)drEditCt["Tk_No5"] == string.Empty)
                    drEditCt["Tk_No5"] = drEditCt["Tk_No"];

                if (drEditCt["Tk_Co5"] == DBNull.Value || (string)drEditCt["Tk_Co5"] == string.Empty)
                    drEditCt["Tk_Co5"] = Parameters.GetParaValue("TK_THUE_NK");//Lay trong Syspara                        
            }

            drEditCt.AcceptChanges();

            Calc_Thue_Vat(drEditCt, frmEditCt);
        }

        public static void Phan_Bo_Thue_Nk(frmVoucher_Edit frmEditCt, double dbTTien5, string strLoai_Pb)
        {
            string strKeyFilter = "Deleted <> true";

            double dbTSo_Luong = Common.SumDCValue(frmEditCt.dtEditCt, "So_Luong", strKeyFilter);
            double dbTTien = Common.SumDCValue(frmEditCt.dtEditCt, "Tien", strKeyFilter);

            DataRow drEditCt = frmEditCt.dtEditCt.Rows[0];
            double dbTy_Gia = Convert.ToDouble(frmEditCt.drEditPh["Ty_Gia"]);

            DataTable dtEditCt = frmEditCt.dtEditCt;
            for (int i = 0; i <= dtEditCt.Rows.Count - 1; i++)
            {
                double dbTien5 = 0;
                drEditCt = dtEditCt.Rows[i];

                if (drEditCt.RowState == DataRowState.Deleted)
                    continue;

                if (dtEditCt.Columns.Contains("Deleted") && (bool)drEditCt["Deleted"] == true)
                    continue;

                if (strLoai_Pb == "1") //Theo gia tri
                {
                    if (dbTTien != 0)
                    {
                        double dbTien = (drEditCt["Tien"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien"]);
                        dbTien5 = Math.Round((dbTien * dbTTien5) / dbTTien, MidpointRounding.AwayFromZero);
                    }
                }
                else // Theo So luong
                {
                    if (dbTSo_Luong != 0)
                    {
                        double dbSo_Luong = (drEditCt["So_Luong"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["So_Luong"]);
                        dbTien5 = Math.Round((dbSo_Luong * dbTTien5) / dbTSo_Luong, MidpointRounding.AwayFromZero);
                    }
                }

                double dbTien_Nt5 = Math.Round(dbTien5 / dbTy_Gia, 2, MidpointRounding.AwayFromZero);

                if ((string)frmEditCt.drEditPh["Ma_Tte"] == Element.sysMa_Tte)
                    dbTien_Nt5 = dbTien5;

                drEditCt["Thue_Nk"] = 0;
                drEditCt["Tien_Nt5"] = dbTien_Nt5;
                drEditCt["Tien5"] = dbTien5;

                if (dbTien5 == 0)
                {
                    drEditCt["Tk_No5"] = string.Empty;
                    drEditCt["Tk_Co5"] = string.Empty;
                }
                else
                {
                    if (drEditCt["Tk_No5"] == DBNull.Value || (string)drEditCt["Tk_No5"] == string.Empty)
                        drEditCt["Tk_No5"] = drEditCt["Tk_No"];

                    if (drEditCt["Tk_Co5"] == DBNull.Value || (string)drEditCt["Tk_Co5"] == string.Empty)
                        drEditCt["Tk_Co5"] = Parameters.GetParaValue("TK_THUE_NK");//Lay trong Syspara
                }

                drEditCt.AcceptChanges();
            }

            //Kiểm tra chênh lệch
            double dbTTien5_ = Common.SumDCValue(dtEditCt, "Tien5", strKeyFilter);

            if (dbTTien5_ != dbTTien5)
            {
                int iMax = Common.MaxDCPosition(dtEditCt, "Tien5", strKeyFilter);
                drEditCt = dtEditCt.Rows[iMax];

                double dbTien5 = Convert.ToDouble(drEditCt["Tien5"]);
                dbTien5 = dbTien5 + (dbTTien5 - dbTTien5_);

                drEditCt["Tien5"] = dbTien5;

                if ((string)frmEditCt.drEditPh["Ma_Tte"] == Element.sysMa_Tte)
                    drEditCt["Tien_Nt5"] = dbTien5;
                else
                    drEditCt["Tien_Nt5"] = Math.Round(dbTien5 / dbTy_Gia, 2, MidpointRounding.AwayFromZero);

                drEditCt.AcceptChanges();
            }

            Calc_Thue_Vat_All(frmEditCt);
        }

        public static void Phan_Bo_Ck(frmVoucher_Edit frmEditCt, double dbTTien4, string strLoai_Pb)
        {
            string strKeyFilter = "Deleted <> true";

            double dbTSo_Luong = Common.SumDCValue(frmEditCt.dtEditCt, "So_Luong9", strKeyFilter);
            double dbTTien = Common.SumDCValue(frmEditCt.dtEditCt, "Tien_Nt9", strKeyFilter);

            DataRow drEditCt = frmEditCt.dtEditCt.Rows[0];
            double dbTy_Gia = Convert.ToDouble(frmEditCt.drEditPh["Ty_Gia"]);

            DataTable dtEditCt = frmEditCt.dtEditCt;
            for (int i = 0; i <= dtEditCt.Rows.Count - 1; i++)
            {
                double dbTien4 = 0;

                drEditCt = dtEditCt.Rows[i];

                if (drEditCt.RowState == DataRowState.Deleted)
                    continue;

                if (dtEditCt.Columns.Contains("Deleted") && (bool)drEditCt["Deleted"] == true)
                    continue;

                if (strLoai_Pb == "1") //Theo gia tri
                {
                    if (dbTTien != 0)
                    {
                        double dbTien = (drEditCt["Tien_Nt9"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien_Nt9"]);
                        dbTien4 = Math.Round((dbTien * dbTTien4) / dbTTien, 0, MidpointRounding.AwayFromZero);
                    }
                }
                else // Theo So luong
                {
                    if (dbTSo_Luong != 0)
                    {
                        double dbSo_Luong = (drEditCt["So_Luong"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["So_Luong"]);
                        dbTien4 = Math.Round((dbSo_Luong * dbTTien4) / dbTSo_Luong, 0, MidpointRounding.AwayFromZero);
                    }
                }

                double dbTien_Nt4 = Math.Round(dbTien4 / dbTy_Gia, 2, MidpointRounding.AwayFromZero);

                if ((string)frmEditCt.drEditPh["Ma_Tte"] == Element.sysMa_Tte)
                    dbTien_Nt4 = dbTien4;


                drEditCt["Tien_Nt4"] = dbTien_Nt4;
                drEditCt["Tien4"] = dbTien4;

                if (dbTien4 == 0)
                {
                    drEditCt["Tk_No4"] = string.Empty;
                    drEditCt["Tk_Co4"] = string.Empty;
                }
                else
                {
                    if (drEditCt["Tk_No4"] == DBNull.Value || (string)drEditCt["Tk_No4"] == string.Empty)
                        drEditCt["Tk_No4"] = Parameters.GetParaValue("TK_NO_CK");

                    if (drEditCt["Tk_Co4"] == DBNull.Value || (string)drEditCt["Tk_Co4"] == string.Empty)
                        drEditCt["Tk_Co4"] = Parameters.GetParaValue("TK_CO_CK");//Lay trong Syspara
                }

                drEditCt.AcceptChanges();

                Calc_Thue_Vat(drEditCt, frmEditCt);
            }

            //Kiểm tra chênh lệch
            double dbTTien4_ = Common.SumDCValue(dtEditCt, "Tien4", strKeyFilter);

            if (dbTTien4_ != dbTTien4)
            {
                int iMax = Common.MaxDCPosition(dtEditCt, "Tien4", strKeyFilter);
                drEditCt = dtEditCt.Rows[iMax];

                double dbTien4 = Convert.ToDouble(drEditCt["Tien4"]);
                dbTien4 = dbTien4 + (dbTTien4 - dbTTien4_);

                drEditCt["Tien4"] = dbTien4;

                if ((string)frmEditCt.drEditPh["Ma_Tte"] == Element.sysMa_Tte)
                    drEditCt["Tien_Nt4"] = dbTien4;
                else
                    drEditCt["Tien_Nt4"] = Math.Round(dbTien4 / dbTy_Gia, 2, MidpointRounding.AwayFromZero);

                drEditCt.AcceptChanges();
            }

            Voucher.Update_TTien(frmEditCt);
        }

        //Thue_TTDB
        public static void Calc_Thue_TTDB(DataRow drEditCt, frmVoucher_Edit frmEditCt)
        {
            double dbThue_TtDb = (drEditCt["Thue_Ttdb"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Thue_Ttdb"]);
            double dbThue_TtDb_Org = (drEditCt["Thue_Ttdb", DataRowVersion.Original] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Thue_Ttdb", DataRowVersion.Original]);

            if (dbThue_TtDb == 0 && dbThue_TtDb_Org != 0) //Xóa bỏ thuế suất TTDB
            {
                drEditCt["Thue_Ttdb"] = 0;
                drEditCt["Tien6"] = 0;
                drEditCt["Tien_Nt6"] = 0;

                drEditCt["Tk_No6"] = string.Empty;
                drEditCt["Tk_Co6"] = string.Empty;

                drEditCt.AcceptChanges();

                Calc_Thue_Vat(drEditCt, frmEditCt);
                return;
            }
            double dbTien5 = (drEditCt["Tien5"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien5"]);
            double dbTien = (drEditCt["Tien"] == DBNull.Value) ? 0 : (Convert.ToDouble(drEditCt["Tien"]) + dbTien5);
            dbTien += dbTien5;

            double dbTien_Nt6 = (drEditCt["Tien_Nt6"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien_Nt6"]);
            double dbTien6 = (drEditCt["Tien6"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien6"]);
            double dbTien6_Cal = 0;
            double dbTy_Gia = Convert.ToDouble(drEditCt["Ty_Gia"]);

            if (dbThue_TtDb != 0) //Tính Thuế TTDB theo thuế suất
            {
                dbTien6_Cal = Math.Round(dbTien * dbThue_TtDb / 100);
            }
            else //Người dùng gõ tay thuế TTDB
            {
                dbTien6_Cal = dbTien6;
            }

            //Điều chỉnh tiền
            if (Math.Abs(Math.Round(dbTien6_Cal - dbTien_Nt6 * dbTy_Gia, 0, MidpointRounding.AwayFromZero)) > Convert.ToDouble(Parameters.GetParaValue("TRON_VAT")))
            {
                dbTien_Nt6 = Math.Round(dbTien6_Cal / dbTy_Gia, 2, MidpointRounding.AwayFromZero);
            }

            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                dbTien_Nt6 = dbTien6_Cal;

            drEditCt["Tien6"] = dbTien6_Cal;
            drEditCt["Tien_Nt6"] = dbTien_Nt6;

            if (dbTien6_Cal == 0)
            {
                drEditCt["Tk_No6"] = string.Empty;
                drEditCt["Tk_Co6"] = string.Empty;
            }
            else
            {
                if (drEditCt["Tk_No6"] == DBNull.Value || (string)drEditCt["Tk_No6"] == string.Empty)
                    drEditCt["Tk_No6"] = drEditCt["Tk_No"];

                if (drEditCt["Tk_Co6"] == DBNull.Value || (string)drEditCt["Tk_Co6"] == string.Empty)
                    drEditCt["Tk_Co6"] = Parameters.GetParaValue("TK_THUE_TTDB");//Lay trong Syspara
            }

            drEditCt.AcceptChanges();

            Calc_Thue_Vat(drEditCt, frmEditCt);
        }

        //Thue_BVMT
        public static void Calc_Thue_BVMT(DataRow drEditCt, frmVoucher_Edit frmEditCt)
        {
            //double dbThue_TtDb = (drEditCt["Thue_BVMT"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Thue_BVMT"]);
            //double dbThue_TtDb_Org = (drEditCt["Thue_BVMT", DataRowVersion.Original] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Thue_BVMT", DataRowVersion.Original]);

            //if (dbThue_TtDb == 0 && dbThue_TtDb_Org != 0) //Xóa bỏ thuế suất TTDB
            //{
            //    drEditCt["Thue_BVMT"] = 0;
            //    drEditCt["Tien7"] = 0;
            //    drEditCt["Tien_Nt7"] = 0;

            //    drEditCt["Tk_No7"] = string.Empty;
            //    drEditCt["Tk_Co7"] = string.Empty;

            //    drEditCt.AcceptChanges();

            //    Calc_Thue_Vat(drEditCt, frmEditCt);
            //    return;
            //}

            double dbTien = (drEditCt["Tien"] == DBNull.Value) ? 0 : (Convert.ToDouble(drEditCt["Tien"]));



            double dbTien_Nt7 = (drEditCt["Tien_Nt7"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien_Nt7"]);
            double dbTien7 = (drEditCt["Tien7"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditCt["Tien7"]);
            double dbTien7_Cal = 0;
            double dbTy_Gia = Convert.ToDouble(drEditCt["Ty_Gia"]);

            //if (dbThue_TtDb != 0) //Tính Thuế TTDB theo thuế suất
            //{
            //    dbTien7_Cal = Math.Round(dbTien * dbThue_TtDb / 100);
            //}
            //else //Người dùng gõ tay thuế TTDB
            //{
            dbTien7_Cal = dbTien7;
            //}

            //Điều chỉnh tiền
            if (Math.Abs(Math.Round(dbTien7_Cal - dbTien_Nt7 * dbTy_Gia, 0, MidpointRounding.AwayFromZero)) > Convert.ToDouble(Parameters.GetParaValue("TRON_VAT")))
            {
                dbTien_Nt7 = Math.Round(dbTien7_Cal / dbTy_Gia, 2, MidpointRounding.AwayFromZero);
            }

            if ((string)drEditCt["Ma_Tte"] == Element.sysMa_Tte)
                dbTien_Nt7 = dbTien7_Cal;

            drEditCt["Tien7"] = dbTien7_Cal;
            drEditCt["Tien_Nt7"] = dbTien_Nt7;

            if (dbTien7_Cal == 0)
            {
                drEditCt["Tk_No7"] = string.Empty;
                drEditCt["Tk_Co7"] = string.Empty;
            }
            else
            {
                if (drEditCt["Tk_No7"] == DBNull.Value || (string)drEditCt["Tk_No7"] == string.Empty)
                    drEditCt["Tk_No7"] = drEditCt["Tk_No"];

                if (drEditCt["Tk_Co7"] == DBNull.Value || (string)drEditCt["Tk_Co7"] == string.Empty)
                    drEditCt["Tk_Co7"] = Parameters.GetParaValue("TK_THUE_TTDB");//Lay trong Syspara
            }

            drEditCt.AcceptChanges();

            Calc_Thue_Vat(drEditCt, frmEditCt);
        }
        //Tong_Tien
        public static void Update_TTien(frmVoucher_Edit frmEditCt)
        {

            string strKeyFilter = "Deleted <> true";
            DataRow drEditPh = frmEditCt.drEditPh;
            DataTable dtEditCt = frmEditCt.dtEditCt;

            if ((bool)frmEditCt.drDmCt["Is_Hd"])
            {
                drEditPh["TTien_Nt0"] = Common.SumDCValue(dtEditCt, "Tien_Nt2", strKeyFilter);
                drEditPh["TTien0"] = Common.SumDCValue(dtEditCt, "Tien2", strKeyFilter);
            }
            else
            {
               
                drEditPh["TTien_Nt0"] = Common.SumDCValue(dtEditCt, "Tien_Nt", strKeyFilter);
                drEditPh["TTien0"] = Common.SumDCValue(dtEditCt, "Tien", strKeyFilter);
             
            }

            drEditPh["TTien_Nt"] = drEditPh["TTien_Nt0"];
            drEditPh["TTien"] = drEditPh["TTien0"];

            if (drEditPh.Table.Columns.Contains("TTien_Nt3") && dtEditCt.Columns.Contains("Tien_Nt3"))
            {
                drEditPh["TTien_Nt3"] = Common.SumDCValue(dtEditCt, "Tien_Nt3", strKeyFilter);
                drEditPh["TTien3"] = Common.SumDCValue(dtEditCt, "Tien3", strKeyFilter);

                drEditPh["TTien_Nt"] = Convert.ToDouble(drEditPh["TTien_Nt"]) + Convert.ToDouble(drEditPh["TTien_Nt3"]);
                drEditPh["TTien"] = Convert.ToDouble(drEditPh["TTien"]) + Convert.ToDouble(drEditPh["TTien3"]);
            }

            if (drEditPh.Table.Columns.Contains("TTien_Nt4") && dtEditCt.Columns.Contains("Tien_Nt4"))
            {
                double dbTTien_Nt4 = Common.SumDCValue(dtEditCt, "Tien_Nt4", strKeyFilter);
                double dbTTien4 = Common.SumDCValue(dtEditCt, "Tien4", strKeyFilter);

                drEditPh["TTien_Nt4"] = dbTTien_Nt4;
                drEditPh["TTien4"] = dbTTien4;

                if ((bool)frmEditCt.drDmCt["Is_Hd"])
                {
                    drEditPh["TTien_Nt"] = Convert.ToDouble(drEditPh["TTien_Nt"]) - dbTTien_Nt4;
                    drEditPh["TTien"] = Convert.ToDouble(drEditPh["TTien"]) - dbTTien4;

                   
                }
                else
                {
                    drEditPh["TTien_Nt"] = Convert.ToDouble(drEditPh["TTien_Nt"]);
                    drEditPh["TTien"] = Convert.ToDouble(drEditPh["TTien"]);
                }

            }

            if (drEditPh.Table.Columns.Contains("TTien_Nt5") && dtEditCt.Columns.Contains("Tien_Nt5"))
            {
                double dbTTien_Nt5 = Common.SumDCValue(dtEditCt, "Tien_Nt5", strKeyFilter);
                double dbTTien5 = Common.SumDCValue(dtEditCt, "Tien5", strKeyFilter);

                drEditPh["TTien_Nt5"] = dbTTien_Nt5;
                drEditPh["TTien5"] = dbTTien5;

                drEditPh["TTien_Nt"] = Convert.ToDouble(drEditPh["TTien_Nt"]) + dbTTien_Nt5;
                drEditPh["TTien"] = Convert.ToDouble(drEditPh["TTien"]) + dbTTien5;
            }

            if (drEditPh.Table.Columns.Contains("TTien_Nt6") && dtEditCt.Columns.Contains("Tien_Nt6"))
            {
                double dbTTien_Nt6 = Common.SumDCValue(dtEditCt, "Tien_Nt6", strKeyFilter);
                double dbTTien6 = Common.SumDCValue(dtEditCt, "Tien6", strKeyFilter);

                drEditPh["TTien_Nt6"] = dbTTien_Nt6;
                drEditPh["TTien6"] = dbTTien6;

                drEditPh["TTien_Nt"] = Convert.ToDouble(drEditPh["TTien_Nt"]) + dbTTien_Nt6;
                drEditPh["TTien"] = Convert.ToDouble(drEditPh["TTien"]) + dbTTien6;
            }

            if (drEditPh.Table.Columns.Contains("TTien_Nt7") && dtEditCt.Columns.Contains("Tien_Nt7"))
            {
                double dbTTien_Nt7 = Common.SumDCValue(dtEditCt, "Tien_Nt7", strKeyFilter);
                double dbTTien7 = Common.SumDCValue(dtEditCt, "Tien7", strKeyFilter);

                drEditPh["TTien_Nt7"] = dbTTien_Nt7;
                drEditPh["TTien7"] = dbTTien7;

                drEditPh["TTien_Nt"] = Convert.ToDouble(drEditPh["TTien_Nt"]) + dbTTien_Nt7;
                drEditPh["TTien"] = Convert.ToDouble(drEditPh["TTien"]) + dbTTien7;
            }
            if(dtEditCt.Columns.Contains("Tien_Tu"))
            {
                double dbTTien_Tu_Nt = Common.SumDCValue(dtEditCt, "Tien_Tu_Nt", strKeyFilter);
                double dbTTien_Tu = Common.SumDCValue(dtEditCt, "Tien_Tu", strKeyFilter);

                drEditPh["TTien_Nt"] = Convert.ToDouble(drEditPh["TTien_Nt"]) - dbTTien_Tu_Nt;
                drEditPh["TTien"] = Convert.ToDouble(drEditPh["TTien"]) - dbTTien_Tu;

            }
            if (drEditPh.Table.Columns.Contains("TSo_Luong") && dtEditCt.Columns.Contains("So_Luong"))
            {
                drEditPh["TSo_Luong"] = Common.SumDCValue(dtEditCt, "So_Luong", strKeyFilter);
                drEditPh["TSo_Luong"] = Common.SumDCValue(dtEditCt, "So_Luong", strKeyFilter);
            }

            frmEditCt.drEditPh.EndEdit();
        }

        //Stt, Gia_Vt, dsVoucher
        public static void Update_Stt(frmVoucher_Edit frmEditCt, string strModule)
        {//Kiem tra frmEditCt.strStt co bi trung khong, roi update cho cac table lien quan

            string strTable_Ph = (string)frmEditCt.drDmCt["Table_Ph"];

            if (frmEditCt.enuNew_Edit == enuEdit.New || frmEditCt.enuNew_Edit == enuEdit.Copy)
            {
                while (DataTool.SQLCheckExist(strTable_Ph, "Stt", frmEditCt.strStt))
                {
                    frmEditCt.strStt = Common.GetNewStt(strModule, true);
                }

                frmEditCt.drEditPh["Stt"] = frmEditCt.strStt;

                foreach (DataRow drCt in frmEditCt.dtEditCt.Rows)
                {
                    if (drCt.RowState == DataRowState.Deleted)
                        continue;

                    drCt["Stt"] = frmEditCt.strStt;
                }

                frmEditCt.drEditPh.Table.AcceptChanges();
                frmEditCt.dtEditCt.AcceptChanges();
            }

            //Cap nhat Stt Thanh toan chung tu
        }

        public static void Update_dsVoucher(frmVoucher_Edit frmEditCt)
        {
            if (frmEditCt.dsVoucher == null)
                return;

            string strTable_Ph = (string)frmEditCt.drDmCt["Table_Ph"];
            string strTable_Ct = (string)frmEditCt.drDmCt["Table_Ct"];

            DataTable dtEditCt = frmEditCt.dtEditCt;
            DataRow drEditPh = frmEditCt.drEditPh;

            if (!frmEditCt.dsVoucher.Tables.Contains(strTable_Ph) || !frmEditCt.dsVoucher.Tables.Contains(strTable_Ct))
                return;

            DataTable dtViewPh = frmEditCt.dsVoucher.Tables[strTable_Ph];
            DataTable dtViewCt = frmEditCt.dsVoucher.Tables[strTable_Ct];

            if (frmEditCt.enuNew_Edit == enuEdit.New || frmEditCt.enuNew_Edit == enuEdit.Copy)
            {
                //Ph
                DataRow drViewPh_New = dtViewPh.NewRow();

                Common.CopyDataRow(drEditPh, drViewPh_New);

                dtViewPh.Rows.Add(drViewPh_New);
                dtViewPh.AcceptChanges();

                //Ct
                foreach (DataRow drCt in dtEditCt.Rows)
                {
                    if (drCt.RowState == DataRowState.Deleted)
                        continue;

                    if (dtEditCt.Columns.Contains("Deleted") && (bool)drCt["Deleted"] == true)
                        continue;

                    DataRow drViewCt_New = dtViewCt.NewRow();

                    Common.CopyDataRow(drCt, drViewCt_New);

                    dtViewCt.Rows.Add(drViewCt_New);
                }

                dtViewCt.AcceptChanges();
            }
            else
            {
                //Ph: drEdit
                Common.CopyDataRow(drEditPh, frmEditCt.drEdit);
                dtViewPh.AcceptChanges();

                //Ct: Remove những hàng cũ trong dtViewCt
                DataRow[] drArr = dtViewCt.Select("Stt = '" + frmEditCt.strStt + "'");

                foreach (DataRow dr in drArr)
                    dr.Delete();

                foreach (DataRow drCt in dtEditCt.Rows)
                {
                    if (drCt.RowState == DataRowState.Deleted)
                        continue;

                    if (dtEditCt.Columns.Contains("Deleted") && (bool)drCt["Deleted"] == true)
                        continue;

                    DataRow drViewCt_New = dtViewCt.NewRow();

                    Common.CopyDataRow(drCt, drViewCt_New);

                    dtViewCt.Rows.Add(drViewCt_New);
                }

                dtViewCt.AcceptChanges();
            }
        }

        public static void FormatTien_Nt(rsDataGridView dgv, string strMa_Tte)
        {
            string strTien_Nt = string.Empty;
            for (int i = 0; i <= 9; i++)
            {
                strTien_Nt = i == 0 ? "Tien_Nt" : "Tien_Nt" + i;

                if (dgv.Columns.Contains(strTien_Nt))
                    dgv.Columns[strTien_Nt].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N0" : "N2";
            }

            if (dgv.Columns.Contains("Gia_Nt9"))
                dgv.Columns["Gia_Nt9"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N3";

            if (dgv.Columns.Contains("Gia_Nt"))
                dgv.Columns["Gia_Nt"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N3";

            if (dgv.Columns.Contains("Gia_Nt2"))
                dgv.Columns["Gia_Nt"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N3";

            if (dgv.Columns.Contains("So_Luong9"))
                dgv.Columns["So_Luong9"].DefaultCellStyle.Format = "N3";

            if (dgv.Columns.Contains("So_Luong"))
                dgv.Columns["So_Luong"].DefaultCellStyle.Format = "N3";
        }

        public static void FormatTien_Nt_SO(rsDataGridView dgv, string strMa_Tte)
        {
            string strTien_Nt = string.Empty;
            for (int i = 0; i <= 9; i++)
            {
                strTien_Nt = i == 0 ? "Tien_Nt" : "Tien_Nt" + i;

                if (dgv.Columns.Contains(strTien_Nt))
                    dgv.Columns[strTien_Nt].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N0" : "N2";
            }

            if (dgv.Columns.Contains("Gia_Nt9"))
                dgv.Columns["Gia_Nt9"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N3";

            if (dgv.Columns.Contains("Gia_Nt"))
                dgv.Columns["Gia_Nt"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N3";

            if (dgv.Columns.Contains("So_Luong9"))
                dgv.Columns["So_Luong9"].DefaultCellStyle.Format = "N2";

            if (dgv.Columns.Contains("So_Luong"))
                dgv.Columns["So_Luong"].DefaultCellStyle.Format = "N2";
        }

        public static void FormatTien_Nt_POCG(rsDataGridView dgv, string strMa_Tte)
        {
            string strTien_Nt = string.Empty;
            for (int i = 0; i <= 9; i++)
            {
                strTien_Nt = i == 0 ? "Tien_Nt" : "Tien_Nt" + i;

                if (dgv.Columns.Contains(strTien_Nt))
                    dgv.Columns[strTien_Nt].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N0" : "N2";
            }

            if (dgv.Columns.Contains("Gia_Nt9"))
                dgv.Columns["Gia_Nt9"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N4";

            if (dgv.Columns.Contains("Gia_Nt"))
                dgv.Columns["Gia_Nt"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N4";

            if (dgv.Columns.Contains("So_Luong9"))
                dgv.Columns["So_Luong9"].DefaultCellStyle.Format = "N0";

            if (dgv.Columns.Contains("So_Luong"))
                dgv.Columns["So_Luong"].DefaultCellStyle.Format = "N0";

            if (dgv.Columns.Contains("Gia_NCC1"))
                dgv.Columns["Gia_NCC1"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N4";

            if (dgv.Columns.Contains("Gia_NCC2"))
                dgv.Columns["Gia_NCC2"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N4";

            if (dgv.Columns.Contains("Gia_NCC3"))
                dgv.Columns["Gia_NCC3"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N4";


            if (dgv.Columns.Contains("Gia_NCC4"))
                dgv.Columns["Gia_NCC4"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N4";


            if (dgv.Columns.Contains("Gia_NCC5"))
                dgv.Columns["Gia_NCC5"].DefaultCellStyle.Format = strMa_Tte == Element.sysMa_Tte ? "N2" : "N4";
        }
        public static string GetGia_NCC(DataRow drEditCt)
        {
            double dbTonCuoi = 0;
            return GetGia_NCC(drEditCt, ref dbTonCuoi);
        }

        public static string GetGia_NCC(DataRow drEditCt, ref double dbTonCuoi)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];
            ht["STT"] = drEditCt["Stt"];

            DataTable dt = SQLExec.ExecuteReturnDt("Sp_GetGia_NCC", ht, CommandType.StoredProcedure);
            DataRow dr;
            if (dt != null)
            {
                dr = dt.Rows[0];
                dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"].ToString());
                return (string)dr["Dien_Giai"] + ": " + Convert.ToDouble(dr["Ton_Cuoi"]).ToString("N2");
            }
            else
                return "Chưa có thông tin";
        }
        public static string GetTonCuoi_KKho(DataRow drEditCt)
        {
            double dbTonCuoi = 0;
            string strMa_Kho = string.Empty;
            return GetTonCuoi_KKho(drEditCt, ref dbTonCuoi);
        }

        public static string GetTonCuoi_KKho(DataRow drEditCt, ref double dbTonCuoi)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["MA_CT"] = drEditCt["Ma_Ct"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];
            ht["STT"] = drEditCt["Stt"];

            DataTable dt = SQLExec.ExecuteReturnDt("Sp_GetTonCuoi_KKho", ht, CommandType.StoredProcedure);

            DataRow dr = dt.Rows[0];

            dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"]);


            return (string)dr["Dien_Giai"] + ": " + Convert.ToDouble(dr["Ton_Cuoi"]).ToString("N2") + " " + (string)dr["Dvt"];
        }

        public static string GetTonCuoi(DataRow drEditCt)
        {
            double dbTonCuoi = 0;
            return GetTonCuoi(drEditCt, ref dbTonCuoi);
        }

        public static string GetTonCuoi(DataRow drEditCt, ref double dbTonCuoi)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["MA_KHO"] = drEditCt["Ma_Kho"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];
            ht["STT"] = drEditCt["Stt"];
            //khóa đoạn này
            DataTable dt = SQLExec.ExecuteReturnDt("Sp_GetTonCuoi", drEditCt, CommandType.StoredProcedure);
           // DataTable dt = SQLExec.ExecuteReturnDt("Sp_GetTonCuoi", ht, CommandType.StoredProcedure);
            DataRow dr = dt.Rows[0];

            dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"]);

            return (string)dr["Dien_Giai"] + ": " + Convert.ToDouble(dr["Ton_Cuoi"]).ToString("N2") + " " + (string)dr["Dvt"];
        }
        
        public static string GetTonCuoi_KKV(DataRow drEditCt, ref double dbTonCuoi, ref DataTable dtCheckInventory)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = Convert.ToDateTime(drEditCt["Ngay_Ct"]);
            ht["MA_KHO"] = drEditCt["Ma_Kho"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["STT"] = drEditCt["Stt"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];

            DataSet ds = SQLExec.ExecuteReturnDs("Sp_GetTonCuoi_KKV", ht, CommandType.StoredProcedure);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"]);
                dtCheckInventory = ds.Tables[1];
                return Convert.ToDouble(dr["Ton_Cuoi"]).ToString("N2");
            }
            else
                return Convert.ToDouble(dbTonCuoi).ToString("N2");
        }
        public static string GetTonCuoi_KhoLe(DataRow drEditCt, ref double dbTonCuoi, ref DataTable dtCheckInventory)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = Convert.ToDateTime(drEditCt["Ngay_Ct"]);
            ht["MA_KHO"] = "052TMN";
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["STT"] = drEditCt["Stt"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];

            DataSet ds = SQLExec.ExecuteReturnDs("Sp_GetTonCuoi_KKV", ht, CommandType.StoredProcedure);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dbTonCuoi = Convert.ToDouble(dr["So_Luong_Cay_Le"]);
                //dtCheckInventory = ds.Tables[1];
                return Convert.ToDouble(dbTonCuoi).ToString("N2");
            }
            else
                return Convert.ToDouble(dbTonCuoi).ToString("N2");
        }
        public static string GetLenhGKCL(DataRow drEditCt, ref double dbSo_Luong_Cay_CL, ref double dbSo_Luong_CL, ref double dbTon_Cuoi_Gk_Cuon, ref string strMa_Kho)
        {
            Hashtable ht = new Hashtable();

            ht["STT"] = drEditCt["Stt"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["SO_LXH"] = drEditCt["So_LXH"];            

            DataSet ds = SQLExec.ExecuteReturnDs("sp_GetTonGKLXH", ht, CommandType.StoredProcedure);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dbSo_Luong_Cay_CL = Convert.ToDouble(dr["Tong_So_Cay_Clech"]);
                dbSo_Luong_CL = Convert.ToDouble(dr["So_Luong_CL"]);
                dbTon_Cuoi_Gk_Cuon = Convert.ToDouble(dr["So_Luong_CL_Cuon"]);
                strMa_Kho = dr["Ma_Kho"].ToString();

                return Convert.ToDouble(dbSo_Luong_CL).ToString("N2");
            }
            else
                return Convert.ToDouble(dbSo_Luong_CL).ToString("N2");
        }
        public static string GetTonCuoi_KGCP(DataRow drEditCt, ref double dbTonCuoi, ref DataTable dtCheckInventory)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = Convert.ToDateTime(drEditCt["Ngay_Ct"]);
            ht["MA_KHO"] = drEditCt["Ma_Kho"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["STT"] = drEditCt["Stt"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];

            DataSet ds = SQLExec.ExecuteReturnDs("Sp_GetTonCuoi_KGCP", ht, CommandType.StoredProcedure);
            DataRow dr;
            if (ds.Tables[0].Rows.Count != 0)
            {
                dr = ds.Tables[0].Rows[0];
                dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"]);
                dtCheckInventory = ds.Tables[1];
            }

            return dbTonCuoi.ToString("N2");
        }
        public static string GetTonCuoi_Phoi(DataRow drEditCt)
        {
            double dbTonCuoi = 0;
            return GetTonCuoi_Phoi(drEditCt, ref dbTonCuoi);
        }
        public static string GetTonCuoi_Phoi(DataRow drEditCt, ref double dbTonCuoi)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["SO_ME"] = drEditCt["So_Me"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["PHAN_LOAI_PHOI"] = drEditCt["Phan_Loai_Phoi"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];
            ht["STT"] = drEditCt["Stt"];

            DataTable dt = SQLExec.ExecuteReturnDt("Sp_GetTonCuoi_Phoi", drEditCt, CommandType.StoredProcedure);
            DataRow dr = dt.Rows[0];

            dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"]);

            return (string)dr["Dien_Giai"] + ": " + Convert.ToDouble(dr["Ton_Cuoi"]).ToString("N2") + " " + (string)dr["Dvt"];
        }

        public static string GetTonCuoi_CP(DataRow drEditCt, ref double dbTonCuoi, ref DataTable dtCheckInventory)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["MA_KHO"] = drEditCt["Ma_Kho"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];
            ht["STT"] = drEditCt["Stt"];

            DataSet ds = SQLExec.ExecuteReturnDs("Sp_GetTonCuoi_CP", ht, CommandType.StoredProcedure);
            DataRow dr = ds.Tables[0].Rows[0];
            dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"]);
            dtCheckInventory = ds.Tables[1];

            return (string)dr["Dien_Giai"] + ": " + Convert.ToDouble(dr["Ton_Cuoi"]).ToString("N2") + " " + (string)dr["Dvt"];
        }
        public static string GetTonCuoi_GK_KKV(DataRow drEditCt, ref double dbTonCuoi, ref DataTable dtCheckInventory)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["MA_KHO"] = drEditCt["Ma_Kho"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["MA_DT"] = drEditCt["Ma_Dt"];
          
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];
            ht["STT"] = drEditCt["Stt"];
            
            DataSet ds = SQLExec.ExecuteReturnDs("Sp_GetTonCuoi_GK_KKV", ht, CommandType.StoredProcedure);
            //if (ds is null)
            //{ 
            //if(ds.Tables[0].Rows.Count == 0)
            //    common
            DataRow dr = ds.Tables[0].Rows[0];
            dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"]);
            dtCheckInventory = ds.Tables[1];

            return (string)dr["Dien_Giai"] + ": " + Convert.ToDouble(dr["Ton_Cuoi"]).ToString("N2") + " " + (string)dr["Dvt"];
            //}
        }
        public static string GetTonCuoi_GK04TP(DataRow drEditCt, ref double dbTonCuoi, ref double dbTonCuoiCay, ref DataTable dtCheckInventory)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["MA_KHO"] = drEditCt["Ma_Kho"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["MA_DT"] = drEditCt["Ma_Dt"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];
            ht["STT"] = drEditCt["Stt"];

            DataSet ds = SQLExec.ExecuteReturnDs("Sp_GetTonCuoi_GK04TP", ht, CommandType.StoredProcedure);
            DataRow dr = ds.Tables[0].Rows[0];
            dbTonCuoi = Convert.ToDouble(dr["Ton_Cuoi"]);
            dbTonCuoiCay = Convert.ToDouble(dr["Ton_Cuoi_Cay"]);
            dtCheckInventory = ds.Tables[1];

            return (string)dr["Dien_Giai"] + ": " + Convert.ToDouble(dr["Ton_Cuoi"]).ToString("N2") + " " + (string)dr["Dvt"];
        }
        public static string GetTonCuoi_LXH(DataRow drEditCt, ref double dbTonCuoi, ref double dbTonCuoi_Bo, ref double dbTonCuoi_Cay_Le, ref double dbTonCuoi_Cay)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["MA_KHO"] = drEditCt["Ma_Kho"];
            ht["STT"] = drEditCt["Stt"];
            ht["MA_VT"] = drEditCt["Ma_Vt"];
            ht["MA_DT"] = drEditCt["Ma_Dt"];
            ht["SO_LXH"] = drEditCt["So_Ct"].ToString().Substring(0, 13);
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];

            DataTable dt = SQLExec.ExecuteReturnDt("Sp_CheckInventory_LXH", ht, CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                dbTonCuoi = Convert.ToDouble(dt.Rows[0]["Ton_Cuoi"]);
                dbTonCuoi_Bo = Convert.ToDouble(dt.Rows[0]["Ton_Cuoi_Bo"]);
                dbTonCuoi_Cay_Le = Convert.ToDouble(dt.Rows[0]["Ton_Cuoi_Cay_Le"]);
                dbTonCuoi_Cay = Convert.ToDouble(dt.Rows[0]["Tong_So_Cay"]);
                return (string)dt.Rows[0]["Ten_VT"] + ": " + Convert.ToDouble(dt.Rows[0]["Ton_Cuoi"]).ToString("N2") + " " + (string)dt.Rows[0]["Dvt"];
            }
            else
            {
                dbTonCuoi = 0;
                return string.Empty;
            }
        }
        public static string GetDuCuoi(DataRow drEditCt, string strTk)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = drEditCt["Ngay_Ct"];
            ht["MA_DVCS"] = drEditCt["Ma_DvCs"];
            ht["STT"] = drEditCt["Stt"];
            ht["TK"] = strTk;
            ht["MA_DT"] = drEditCt.Table.Columns.Contains("Ma_Dt") ? drEditCt["Ma_Dt"] : string.Empty;
            ht["MA_VT_SP"] = drEditCt.Table.Columns.Contains("Ma_Vt_Sp") ? drEditCt["Ma_Vt_Sp"] : string.Empty;

            DataTable dt = SQLExec.ExecuteReturnDt("Sp_GetDuCuoi", ht, CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
                return (string)dt.Rows[0]["Dien_Giai"];
            else
                return "";
        }

        public static void UpdateSo_Ct(frmVoucher_Edit frmEditCt)
        {
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", frmEditCt.drEditPh["Ma_Ct"].ToString());

            if (frmEditCt.enuNew_Edit == enuEdit.New || frmEditCt.enuNew_Edit == enuEdit.Copy)
            {
                string strTablePh = (string)frmEditCt.drDmCt["Table_Ph"];
                string strTableCt = (string)frmEditCt.drDmCt["Table_Ct"];
                string strMa_Ct = (string)frmEditCt.drEditPh["Ma_Ct"];
                string strSo_Ct = (string)frmEditCt.drEditPh["So_Ct"];
                string strSQLExec = string.Empty;
                DateTime dteNgay_Ct1 = Library.StrToDate("1/1/" + ((DateTime)frmEditCt.drEditPh["Ngay_Ct"]).Year.ToString()); //+ DateTime.Today.Month.ToString() + "/" 
                DateTime dteNgay_Ct2 = dteNgay_Ct1.AddYears(1).AddDays(-1); //Khoảng cách trong năm
                Hashtable ht = new Hashtable();
                if (strTableCt == "R05CTNX")
                {
                    strSQLExec = "SELECT COUNT(Stt) FROM " + strTableCt + " WHERE Stt <> @Stt AND So_Ct = @So_Ct AND (Ngay_Ct BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) AND Ma_Ct = @Ma_Ct AND Ma_DvCs = @Ma_DvCs AND So_Seri0 = @So_Seri0";
                    ht.Add("MA_CT", strMa_Ct);
                    ht.Add("SO_CT", strSo_Ct);
                    ht.Add("NGAY_CT1", dteNgay_Ct1);
                    ht.Add("NGAY_CT2", dteNgay_Ct2);
                    ht.Add("STT", frmEditCt.drEditPh["Stt"]);
                    ht.Add("SO_SERI0", frmEditCt.drEditPh["So_Seri0"]);
                    ht.Add("MA_DVCS", frmEditCt.drEditPh["Ma_DvCs"]);
                }
                else
                {
                    strSQLExec = "SELECT COUNT(Stt) FROM " + strTablePh + " WHERE Stt <> @Stt AND So_Ct = @So_Ct AND (Ngay_Ct BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) AND Ma_Ct = @Ma_Ct AND Ma_DvCs = @Ma_DvCs";
                    ht.Add("MA_CT", strMa_Ct);
                    ht.Add("SO_CT", strSo_Ct);
                    ht.Add("NGAY_CT1", dteNgay_Ct1);
                    ht.Add("NGAY_CT2", dteNgay_Ct2);
                    ht.Add("STT", frmEditCt.drEditPh["Stt"]);
                    ht.Add("MA_DVCS", frmEditCt.drEditPh["Ma_DvCs"]);
                }



                if (Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text)) > 0)
                {
                    if(Common.Inlist(drDmCt["Table_Ct"].ToString(), "R04CTSO"))
                    {
                        frmEditCt.drEditPh["So_Ct"] = Voucher.Cong_So_Ct_SO(frmEditCt);

                        foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
                        {
                            if (dr.RowState == DataRowState.Deleted)
                                continue;

                            dr["So_Ct"] = frmEditCt.drEditPh["So_Ct"];
                        }
                    }

                    else if (Common.MsgYes_No("Chứng từ số: " + strSo_Ct + " đã tồn tại.\n Bạn có muốn tự tăng số kô?"))
                    {
                        if (Common.Inlist(drDmCt["Table_Ct"].ToString(), "R04CTPO,R06CT_BTTB"))
                            frmEditCt.drEditPh["So_Ct"] = Voucher.Cong_So_Ct_PYC(frmEditCt);
                        else
                            frmEditCt.drEditPh["So_Ct"] = Voucher.Cong_So_Ct(frmEditCt);

                        foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
                        {
                            if (dr.RowState == DataRowState.Deleted)
                                continue;

                            dr["So_Ct"] = frmEditCt.drEditPh["So_Ct"];
                        }
                    }
                }
            }
        }

        public static bool CheckDuplicateInvoice(frmVoucher_Edit frm)
        {
            bool bReturn = true;

            if (!frm.dtEditCt.Columns.Contains("So_Ct0") || !frm.dtEditCt.Columns.Contains("So_Seri0"))
                return true;

            DataTable dtCheck = frm.dtEditCt.DefaultView.ToTable(true, new string[] { "Stt", "So_Ct0", "So_Seri0", "Ma_Ky_Hieu_HDon", "Tk_No3", "Tk_Co3" });

            foreach (DataRow dr in dtCheck.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                    continue;

                if ((string)dr["So_Ct0"] == string.Empty || (string)dr["So_Seri0"] == string.Empty)
                    continue;

                string strQuery = "SELECT COUNT(So_Ct0) FROM vw_ThueVat WHERE So_Ct0 = '" + (string)dr["So_Ct0"] + "' AND So_Seri0 = '" + (string)dr["So_Seri0"] + "' AND Ma_Ky_Hieu_HDon = '" + (string)dr["Ma_Ky_Hieu_HDon"] + "' AND (Tk = '" + (string)dr["Tk_No3"] + "' OR Tk = '" + (string)dr["Tk_Co3"] + "') AND Stt <> '" + (string)dr["Stt"] + "'";

                int obj = (int)SQLExec.ExecuteReturnValue(strQuery);
                if (obj >= 1)
                {
                    string strMsg = "Số hóa đơn  = {" + (string)dr["So_Ct0"] + "} và số Seri = {" + (string)dr["So_Seri0"] + "} đã tồn tại, bạn có muốn lưu không?";

                    if (Common.MsgYes_No(strMsg, "Y"))
                        continue;
                    else
                        return false;
                }
            }

            return bReturn;
        }

        public static string GetInheritVoucher(frmVoucher_Edit frmEditCt)
        {
            string strSQLExec = string.Empty;
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", frmEditCt.strMa_Ct);
            //Hiển thị chứng từ gốc kế thừa
            if (Common.Inlist(frmEditCt.strMa_Ct, "PXDC,PXBR,PXGK"))
                strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = @_InheritList + Ma_Ct + ':' + So_Ct + ','
					FROM R80PH_SCALE 
					WHERE Stt IN (SELECT Stt_Org FROM " + (string)frmEditCt.drDmCt["Table_Ct"] + @" WHERE Stt = '" + frmEditCt.strStt + @"')
				SELECT @_InheritList";
            else if (Common.Inlist(frmEditCt.strMa_Ct, "PXKV")) //R80PH_BARCODE_KKV
                strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = @_InheritList + Ma_Ct + ':' + So_Ct + ','
					FROM R80PH_BARCODE_KKV 
					WHERE Stt IN (SELECT Stt_Org FROM " + (string)frmEditCt.drDmCt["Table_Ct"] + @" WHERE Stt = '" + frmEditCt.strStt + @"')
				SELECT @_InheritList = @_InheritList + Ma_Ct + ':' + So_Ct + ','
					FROM R80PH
					WHERE Stt IN (SELECT Stt_Org FROM " + (string)frmEditCt.drDmCt["Table_Ct"] + @" WHERE Stt = '" + frmEditCt.strStt + @"')
				SELECT @_InheritList";
            else if (((drDmCt["Table_Ct"].ToString() == "R06CT_BTTB") && !Common.Inlist(frmEditCt.strMa_Ct, "BBBN,BBXE")) || Common.Inlist(frmEditCt.strMa_Ct, "DTCP"))
            {
                strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = @_InheritList + Ma_Ct + ':' + So_Ct + ','
					FROM R06PH_BTTB 
					WHERE Stt IN (SELECT Stt_Org FROM " + (string)frmEditCt.drDmCt["Table_Ct"] + @" WHERE Stt = '" + frmEditCt.strStt + @"')
				SELECT @_InheritList";
            }
            else if ((drDmCt["Table_Ct"].ToString() == "R06CT_BTTB" && Common.Inlist(frmEditCt.strMa_Ct, "BBBN,BBXE")))
            {
                strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = @_InheritList + Ma_Ct + ':' + So_Ct + ','
					FROM R80PH 
					WHERE Stt IN (SELECT Stt_Org FROM " + (string)frmEditCt.drDmCt["Table_Ct"] + @" WHERE Stt = '" + frmEditCt.strStt + @"')
				SELECT @_InheritList";
            }
            else
                strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = @_InheritList + Ma_Ct + ':' + So_Ct + ','
					FROM R80PH 
					WHERE Stt IN (SELECT Stt_Org FROM " + (string)frmEditCt.drDmCt["Table_Ct"] + @" WHERE Stt = '" + frmEditCt.strStt + @"')
				SELECT @_InheritList";

            return SQLExec.ExecuteReturnValue(strSQLExec).ToString();
        }

        public static string GetInheritScaleBarcode(frmVoucher_Edit frmEditCt)
        {
            //Hiển thị chứng từ gốc kế thừa
            string strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = @_InheritList + Ma_Ct + ':' + So_Ct + ','
					FROM R80PH_SCALE
					WHERE Stt IN (SELECT Stt_Org FROM " + (string)frmEditCt.drDmCt["Table_Ct"] + @" WHERE Stt = '" + frmEditCt.strStt + @"')

				SELECT @_InheritList";

            return SQLExec.ExecuteReturnValue(strSQLExec).ToString();
        }
        public static void ImportExcelPhoiMua(frmVoucher_Edit frmEditCt)
        {
            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                int iStt0 = 0;

                if (frmEditCt.dtEditCt.Rows.Count > 0 && frmEditCt.dtEditCt.Rows.Count == 1)// && Convert.ToDouble(frmEditCt.dtEditCt.Rows[0]["So_Luong"]) + Convert.ToDouble(dtEditCt.Rows[0]["Tien_Nt"]) + Convert.ToDouble(dtEditCt.Rows[0]["Tien"]) == 0)
                    frmEditCt.dtEditCt.Rows.Clear();

                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    if (drImport.RowState == DataRowState.Deleted)
                        continue;

                    if ((drImport.Table.Columns.Contains("Tien") && Convert.ToInt32(drImport["Tien"]) == 0) &&
                        (drImport.Table.Columns.Contains("Tien2") && Convert.ToInt32(drImport["Tien2"]) == 0) &&
                            (drImport.Table.Columns.Contains("Tien3") && Convert.ToInt32(drImport["Tien3"]) == 0) &&
                                (drImport.Table.Columns.Contains("So_Luong") && Convert.ToInt32(drImport["So_Luong"]) == 0))
                    {
                        continue;
                    }

                    iStt0++;

                    DataRow drNew = frmEditCt.dtEditCt.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);

                    drNew["Stt"] = frmEditCt.strStt;
                    drNew["Stt0"] = iStt0;
                    drNew["Ma_Vt"] = drImport["Ma_Vt"];
                    drNew["So_Luong9"] = drImport["So_Luong"];
                   

                    if (drNew.Table.Columns.Contains("So_Me") && drImport.Table.Columns.Contains("So_Me"))
                        drNew["So_Me"] = drImport["So_Me"];

                    drNew["He_So9"] = 1;
                    drNew["So_Luong"] = drImport["So_Luong"];
                    

                    if (drImport.Table.Columns.Contains("Ma_Kho"))
                        drNew["Ma_Kho"] = drImport["Ma_Kho"];
                    
                    if (drImport.Table.Columns.Contains("DDai_Phoi"))
                        drNew["DDai_Phoi"] = drImport["DDai_Phoi"];

                    if (drImport.Table.Columns.Contains("So_Luong_Cay"))
                        drNew["So_Luong_Cay"] = drImport["So_Luong_Cay"];

                    if (drImport.Table.Columns.Contains("So_Luong_TB_Nguoi"))
                        drNew["So_Luong_TB_Nguoi"] = drImport["So_Luong_TB_Nguoi"];

                    if (drImport.Table.Columns.Contains("Phan_Loai_Phoi"))
                        drNew["Phan_Loai_Phoi"] = drImport["Phan_Loai_Phoi"];

                    DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", drImport["Ma_Vt"].ToString());

                    if (drDmVt != null)
                    {
                        drNew["Ten_Vt"] = drDmVt["Ten_Vt"];
                        drNew["Dvt"] = drDmVt["Dvt"];
                        drNew["Loai_Phoi"] = drDmVt["Loai_Phoi"];
                        drNew["Mac_Thep"] = drDmVt["Mac_Thep"];
                    }

                    frmEditCt.dtEditCt.Rows.Add(drNew);
                    drNew.AcceptChanges();
                }

                Voucher.Update_Detail(frmEditCt);
                Voucher.Calc_So_Luong_All(frmEditCt);
                Voucher.Update_TTien(frmEditCt);
            }
        }
        public static void ImportExcelCtVT(frmVoucher_Edit frmEditCt)
        {
            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                int iStt0 = 0;

                if (frmEditCt.dtEditCt.Rows.Count > 0 && frmEditCt.dtEditCt.Rows.Count == 1)// && Convert.ToDouble(frmEditCt.dtEditCt.Rows[0]["So_Luong"]) + Convert.ToDouble(dtEditCt.Rows[0]["Tien_Nt"]) + Convert.ToDouble(dtEditCt.Rows[0]["Tien"]) == 0)
                    frmEditCt.dtEditCt.Rows.Clear();

                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    if (drImport.RowState == DataRowState.Deleted)
                        continue;

                    if ((drImport.Table.Columns.Contains("Tien") && Convert.ToInt32(drImport["Tien"]) == 0) &&
                        (drImport.Table.Columns.Contains("Tien2") && Convert.ToInt32(drImport["Tien2"]) == 0) &&
                            (drImport.Table.Columns.Contains("Tien3") && Convert.ToInt32(drImport["Tien3"]) == 0) &&
                                (drImport.Table.Columns.Contains("So_Luong") && Convert.ToInt32(drImport["So_Luong"]) == 0))
                    {
                        continue;
                    }

                    iStt0++;

                    DataRow drNew = frmEditCt.dtEditCt.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);

                    drNew["Stt"] = frmEditCt.strStt;
                    drNew["Stt0"] = iStt0;
                    drNew["Ma_Vt"] = drImport["Ma_Vt"];
                    drNew["So_Luong9"] = drImport["So_Luong"];
                    drNew["Gia_Nt9"] = drImport["Gia"];
                    drNew["Tien_Nt9"] = drImport["Tien"];

                    if (drNew.Table.Columns.Contains("So_Me") && drImport.Table.Columns.Contains("So_Me"))
                        drNew["So_Me"] = drImport["So_Me"];

                    drNew["He_So9"] = 1;
                    drNew["So_Luong"] = drImport["So_Luong"];
                    drNew["Gia"] = drImport["Gia"];
                    drNew["Tien"] = drImport["TIen"];

                    if (drImport.Table.Columns.Contains("Ma_Kho"))
                        drNew["Ma_Kho"] = drImport["Ma_Kho"];

                    if (drImport.Table.Columns.Contains("Ten_Vt"))
                        drNew["Ten_Vt"] = drImport["Ten_Vt"];

                    DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", drImport["Ma_Vt"].ToString());

                    if (drDmVt != null)
                    {
                        drNew["Ten_Vt"] = drImport["Ten_Vt"];
                        drNew["Dvt"] = drDmVt["Dvt"];

                        //Xác định Tk_No, Tk_Co
                        if ((bool)frmEditCt.drDmCt["Is_Hd"])
                        {
                            if ((string)frmEditCt.drDmCt["Nh_Ct"] == "1") //HBTL
                            {
                                drNew["Tk_No2"] = drDmVt["Tk_HBTL"];
                                drNew["Tk_No"] = drDmVt["Tk_Vtu"];
                                drNew["Tk_Co"] = drDmVt["Tk_Gvon"];
                            }
                            else
                            {
                                drNew["Tk_Co2"] = drDmVt["Tk_Dthu"];
                                drNew["Tk_No"] = drDmVt["Tk_Gvon"];
                                drNew["Tk_Co"] = drDmVt["Tk_Vtu"];
                            }

                        }
                        else
                        {
                            if ((string)frmEditCt.drDmCt["Nh_Ct"] == "1")
                                drNew["Tk_No"] = drDmVt["Tk_Vtu"];
                            else
                                drNew["Tk_Co"] = drDmVt["Tk_Vtu"];
                        }
                    }

                    frmEditCt.dtEditCt.Rows.Add(drNew);
                    drNew.AcceptChanges();
                }

                Voucher.Update_Detail(frmEditCt);
                Voucher.Calc_So_Luong_All(frmEditCt);
                Voucher.Update_TTien(frmEditCt);
            }
        }
        public static void ImportExcel_DMDTCBNV(string strTableName, DataTable dtImportDest)
        {
            if (!RosySystem.Common.Common.CheckPermission("IMPORT_" + strTableName, enuPermission_Type.Allow_Access))
            {
                string str = (RosySystem.Element.Element.sysLanguage == enuLanguageType.English) ? "You have no permission to Import " : ("Bạn kh\x00f4ng đc cấp quyền Import " + Languages.GetLanguage(strTableName) + "!");
                RosySystem.Common.Common.MsgCancel(str);
            }
            else
            {
                frmReadExcel excel = new frmReadExcel();
                excel.Load();
                if (excel.isAccept && (excel.dtImport != null))
                {
                    DataRow row = DataTool.SQLGetDataRowByID("R00DmTable", "Table_Name", strTableName);
                    if (row == null)
                    {
                        RosySystem.Common.Common.MsgCancel("Chưa khai b\x00e1o bảng [" + strTableName + "]");
                    }
                    else
                    {
                        DataTable table = SQLExec.ExecuteReturnDt("SELECT Index_Id, COL_NAME(Object_id, Column_Id) AS Column_Name\r\n\t\t\t\t\t\t\t\t\tFROM sys.index_Columns \r\n\t\t\t\t\t\t\t\t\tWHERE Object_id = Object_id('" + row["Table_Name0"].ToString() + "') AND \r\n\t\t\t\t\t\t\t\t\t\tIndex_Id IN (\r\n\t\t\t\t\t\t\t\t\t\t\t\t\tSELECT Index_Id \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tFROM sys.indexes\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tWHERE object_id = object_id('" + row["Table_Name0"].ToString() + "') AND  IS_UNIQUE = 1) AND\r\n\t\t\t\t\t\t\t\t\t\tColumn_Id NOT IN (\r\n\t\t\t\t\t\t\t\t\t\t\t\t\tSELECT Column_Id \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tFROM Sys.Columns \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tWHERE Object_Id = Object_Id('" + row["Table_Name0"].ToString() + "') AND Is_Identity = 1)");
                        foreach (DataRow row2 in table.Rows)
                        {
                            if (!excel.dtImport.Columns.Contains(row2["Column_Name"].ToString()))
                            {
                                RosySystem.Common.Common.MsgCancel("Import dữ liệu bảng [" + strTableName + "] thiếu trường [" + row2["Column_Name"].ToString() + "], kh\x00f4ng thể import!");
                                return;
                            }
                        }


                        DataColumn dc = new DataColumn("Ma_Nh_Dt", typeof(string));
                        dc.DefaultValue = "";
                        excel.dtImport.Columns.Add(dc);

                        DataColumn dc1 = new DataColumn("Auto_Number", typeof(int));
                        dc.DefaultValue = 0;
                        excel.dtImport.Columns.Add(dc1);

                        foreach (DataRow row3 in excel.dtImport.Rows)
                        {
                            if (row3.RowState != DataRowState.Deleted)
                            {
                                DataRow dr = dtImportDest.NewRow();
                                DataTool.SetDefaultDataRow(ref dr);
                                Common.CopyDataRow(row3, ref dr);



                                string strMa_Dt = dr["Ma_Dt"].ToString();
                                if (dr.Table.Columns.Contains("Ma_DvCs") && (dr["Ma_DvCs"].ToString() == ""))
                                {
                                    dr["Ma_DvCs"] = RosySystem.Element.Element.sysMa_DvCs;
                                }
                                if (dr.Table.Columns.Contains("Ma_Data") && (dr["Ma_Data"].ToString() == ""))
                                {
                                    dr["Ma_Data"] = RosySystem.Element.Element.sysMa_Data;
                                }
                                if (dr.Table.Columns.Contains("Create_Log"))
                                {
                                    dr["Create_Log"] = RosySystem.Common.Common.GetCurrent_Log();
                                }

                                dr["Ma_Nh_Dt"] = "NV";
                                dr["Auto_Number"] = Convert.ToDouble(strMa_Dt.Substring(1));

                                if (dr.Table.Columns.Contains("Ngay_Sinh"))
                                {
                                    DateTime dteNgay_Sinh;
                                    if (dr["Ngay_Sinh"].ToString() != "")
                                        dteNgay_Sinh = Convert.ToDateTime(dr["Ngay_Sinh"]);
                                    else
                                        dteNgay_Sinh = Convert.ToDateTime("01/01/1900");
                                    dr["Ngay_Sinh"] = Library.DateToStr(dteNgay_Sinh);
                                }

                                if (dr.Table.Columns.Contains("Cap_Ngay"))
                                {
                                    DateTime dteCap_Ngay;
                                    if (dr["Cap_Ngay"].ToString() != "")
                                        dteCap_Ngay = Convert.ToDateTime(dr["Cap_Ngay"]);
                                    else
                                        dteCap_Ngay = Convert.ToDateTime("01/01/1900");

                                    dr["Cap_Ngay"] = Library.DateToStr(dteCap_Ngay);
                                }
                                dr.AcceptChanges();
                                SQLExec.Execute("ALTER TABLE R81DMDT DISABLE TRIGGER ALL");
                                if (Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R81DMDT WHERE Ma_Dt = '" + dr["Ma_Dt"] + "'")) == 1)
                                {
                                    DataTool.SQLUpdate(enuEdit.Edit, row["Table_Name0"].ToString(), ref dr);
                                }
                                else
                                    DataTool.SQLUpdate(enuEdit.New, row["Table_Name0"].ToString(), ref dr);


                            }
                        }
                    }
                    SQLExec.Execute("ALTER TABLE R81DMDT ENABLE TRIGGER ALL");
                    Common.MsgOk("Đã hoàn thành");
                }
            }
        }
        public static void ImportExcelCtKT(frmVoucher_Edit frmEditCt)
        {
            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                frmEditCt.dtEditCt.Clear();

                int iStt0 = 0;

                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    if (drImport.RowState == DataRowState.Deleted)
                        continue;

                    if ((drImport.Table.Columns.Contains("Tien") && Convert.ToInt32(drImport["Tien"]) == 0) && (drImport.Table.Columns.Contains("Tien3") && Convert.ToInt32(drImport["Tien3"]) == 0))
                        continue;

                    iStt0++;

                    DataRow drNew = frmEditCt.dtEditCt.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);

                    drNew["Stt"] = frmEditCt.strStt;
                    drNew["Stt0"] = iStt0;
                    drNew["Tk_No"] = drImport["Tk_No"];
                    drNew["Tk_Co"] = drImport["Tk_Co"];
                    drNew["Tien_Nt9"] = drImport["Tien"];
                    drNew["Tien"] = drImport["Tien"];
                    drNew["Tien_Nt"] = drImport.Table.Columns.Contains("Tien_Nt") ? drImport["Tien_Nt"] : drImport["Tien"];
                    drNew["Ma_Dt"] = drImport.Table.Columns.Contains("Ma_Dt") ? drImport["Ma_Dt"].ToString().ToUpper() : "";
                    drNew["Ma_Bp"] = drImport.Table.Columns.Contains("Ma_Bp") ? drImport["Ma_Bp"].ToString().ToUpper() : "";
                    drNew["Ma_Km"] = drImport.Table.Columns.Contains("Ma_Km") ? drImport["Ma_Km"].ToString().ToUpper() : "";
                    drNew["Ma_Vt_Sp"] = drImport.Table.Columns.Contains("Ma_Vt_Sp") ? drImport["Ma_Vt_Sp"].ToString().ToUpper() : "";
                    drNew["Ma_Dt_CbNv"] = drImport.Table.Columns.Contains("Ma_Dt_CbNv") ? drImport["Ma_Dt_CbNv"].ToString().ToUpper() : "";
                    drNew["Ma_Hd"] = drImport.Table.Columns.Contains("Ma_Hd") ? drImport["Ma_Hd"].ToString().ToUpper() : "";
                    drNew["Dien_Giai"] = drImport.Table.Columns.Contains("Dien_Giai") ? drImport["Dien_Giai"] : "";

                    if (drNew.Table.Columns.Contains("Ma_Job") && drImport.Table.Columns.Contains("Ma_Job"))
                        drNew["Ma_Job"] = drImport["Ma_Job"].ToString().ToUpper();

                    if (drNew.Table.Columns.Contains("Ma_Dt_Co") && drImport.Table.Columns.Contains("Ma_Dt_Co"))
                        drNew["Ma_Dt_Co"] = drImport["Ma_Dt_Co"].ToString().ToUpper();

                    if (drNew.Table.Columns.Contains("Ma_Bp_Co") && drImport.Table.Columns.Contains("Ma_Bp_Co"))
                        drNew["Ma_Bp_Co"] = drImport["Ma_Bp_Co"].ToString().ToUpper();

                    if (drNew.Table.Columns.Contains("Ma_Job_Co") && drImport.Table.Columns.Contains("Ma_Job_Co"))
                        drNew["Ma_Job_Co"] = drImport["Ma_Job_Co"].ToString().ToUpper();

                    //ThueVAT
                    if (drImport.Table.Columns.Contains("Ma_Thue") && drImport["Ma_Thue"].ToString() != "")
                    {
                        string strMa_Thue = drImport["Ma_Thue"].ToString().ToUpper();

                        DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DmThue", "Ma_Thue", strMa_Thue);

                        if (drDmThue != null)
                        {
                            drNew["Ma_Thue"] = strMa_Thue;
                            drNew["Thue_GTGT"] = drDmThue["Thue_Suat"];
                            drNew["Tk_No3"] = (drDmThue["Loai_Thue"].ToString() == "1" ? drDmThue["Tk"].ToString() : drImport["Tk_No"]);
                            drNew["Tk_Co3"] = (drDmThue["Loai_Thue"].ToString() == "2" ? drDmThue["Tk"].ToString() : drImport["Tk_Co"]);
                        }
                    }
                    else
                    {
                        drNew["Ma_Thue"] = drImport.Table.Columns.Contains("Ma_Thue") ? drImport["Ma_Thue"] : "";
                        drNew["Thue_GTGT"] = drImport.Table.Columns.Contains("Thue_GTGT") ? drImport["Thue_GTGT"] : 0;
                        drNew["Tk_No3"] = drImport.Table.Columns.Contains("Tk_No3") ? drImport["Tk_No3"] : "";
                        drNew["Tk_Co3"] = drImport.Table.Columns.Contains("Tk_Co3") ? drImport["Tk_Co3"] : "";
                    }

                    drNew["Tien3"] = drImport.Table.Columns.Contains("Tien3") ? drImport["Tien3"] : 0;
                    drNew["Tien_Nt3"] = drImport.Table.Columns.Contains("Tien_Nt3") ? drImport["Tien_Nt3"] : 0;

                    if (drImport.Table.Columns.Contains("So_Ct0")) drNew["So_Ct0"] = drImport["So_Ct0"];
                    if (drImport.Table.Columns.Contains("Ngay_Ct0")) drNew["Ngay_Ct0"] = drImport["Ngay_Ct0"];
                    if (drImport.Table.Columns.Contains("So_Seri0")) drNew["So_Seri0"] = drImport["So_Seri0"];
                    if (drImport.Table.Columns.Contains("Ten_DtGtGt")) drNew["Ten_DtGtGt"] = drImport["Ten_DtGtGt"];
                    if (drImport.Table.Columns.Contains("Ma_So_Thue")) drNew["Ma_So_Thue"] = drImport["Ma_So_Thue"];
                    if (drImport.Table.Columns.Contains("Ten_Vt")) drNew["Ten_Vt"] = drImport["Ten_Vt"];

                    frmEditCt.dtEditCt.Rows.Add(drNew);
                    drNew.AcceptChanges();

                    if (drImport["Ma_Thue"].ToString() != "")
                        Voucher.Calc_Thue_Vat(drNew, frmEditCt);
                }

                //Lấy Mã đối tượng ở dòng đầu làm Ma_Dt cho Header
                frmEditCt.drEditPh["Ma_Dt"] = frmEditCt.dtEditCt.Rows[0]["Ma_Dt"];

                Voucher.Update_Detail(frmEditCt);
                Voucher.Calc_Tien_All(frmEditCt);
                Voucher.Update_TTien(frmEditCt);
            }
        }
        public static string Cong_So_Ct_PYC_ThangTruoc(frmVoucher_Edit frmEdit, string strNgay_Ct)
        {

            string strSo_Ct = string.Empty;
            string strMa_Ct = frmEdit.drEdit["Ma_Ct"].ToString();
            string strSo_Ct_Curent = string.Empty;
            //string strMa_Dt = frmEdit.drEdit["Ma_Dt"].ToString() == null || frmEdit.drEdit["Ma_Dt"].ToString() == "" ? "PKHVT" : frmEdit.drEdit["Ma_Dt"].ToString();
            string strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "' AND Member_Group_ID IN (SELECT MA_BP FROM R81DMBP) ");
            //strMa_Dt = strMa_Dt == null ? strMa_Dt : "PKHVT";
            string strTen_Dt_Vc = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Dt_Vc FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt + "' ");

            Hashtable ht = new Hashtable();
            ht.Add("MA_DT", strMa_Dt);
            ht.Add("MA_CT", frmEdit.drEdit["Ma_Ct"]);
            ht.Add("NGAY_CT", strNgay_Ct);

            strSo_Ct = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSo_Ct(@Ma_Ct, @Ma_Dt, @Ngay_Ct)", ht, CommandType.Text);

            if (strSo_Ct == string.Empty)
            //if (Common.InlistLike(strSo_Ct, "001"));
            {

                DateTime dteNgay_Ct1 = Library.StrToDate("1/" + ((DateTime)frmEdit.drEditPh["Ngay_Ct"]).Month.ToString() + '/' + ((DateTime)frmEdit.drEditPh["Ngay_Ct"]).Year.ToString()); //+ DateTime.Today.Month.ToString() + "/" 
                DateTime dteNgay_Ct2 = dteNgay_Ct1.AddYears(1).AddDays(-1); //Khoảng cách trong năm
                string strSQL = "SELECT MAX(So_Ct) FROM " + frmEdit.drDmCt["Table_Ph"].ToString() + " WHERE Ma_Dt = '" + strMa_Dt + "' AND Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "'";
                if (Common.InlistLike(strMa_Ct, "DT,DTVPP,BBNA,BBPT,BBTH,DNXNL,PYCPT,DNTT,PONL,POCG"))
                    strSo_Ct_Curent = (string)SQLExec.ExecuteReturnValue("SELECT MAX(So_Ct) FROM " + frmEdit.drDmCt["Table_Ph"].ToString() + " WHERE Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "' AND LEFT(So_Ct,4) = '" + strTen_Dt_Vc + "'");
                else
                    strSo_Ct_Curent = (string)SQLExec.ExecuteReturnValue(strSQL);

                //string strSo_Ct_Current = 
                Hashtable htPara = new Hashtable();
                htPara.Add("TABLENAME", frmEdit.drDmCt["Table_Ph"].ToString());
                htPara.Add("COLUMNNAME", "So_Ct");
                htPara.Add("CURRENTID", strSo_Ct_Curent);
                htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "'");
                htPara.Add("PREFIXLEN", Convert.ToInt32(frmEdit.drDmCt["PrefixLen"]));
                htPara.Add("SUFFIXLEN", Convert.ToInt32(frmEdit.drDmCt["SuffixLen"]));

                strSo_Ct = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
            }

            if (GetDate_Server() >= Convert.ToDateTime("2020-01-01T00:00:00"))
            {
                strSo_Ct_Curent = string.Empty;

                strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "' AND Member_Group_ID IN (SELECT MA_BP FROM R81DMBP) ");

                strTen_Dt_Vc = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Dt_Vc FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt + "' ");

                Hashtable ht1 = new Hashtable();
                ht1.Add("MA_DT", strMa_Dt);
                ht1.Add("MA_CT", frmEdit.drEdit["Ma_Ct"]);
                ht1.Add("NGAY_CT", strNgay_Ct);

                strSo_Ct = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSo_Ct_PO(@Ma_Ct, @Ma_Dt, @Ngay_Ct)", ht1, CommandType.Text);
            }

            return strSo_Ct;
        }
        public static string Cong_So_Ct_PYC(frmVoucher_Edit frmEdit)
        {

            string strSo_Ct = string.Empty;
            string strMa_Ct = frmEdit.drEdit["Ma_Ct"].ToString();
            string strSo_Ct_Curent = string.Empty;
            //string strMa_Dt = frmEdit.drEdit["Ma_Dt"].ToString() == null || frmEdit.drEdit["Ma_Dt"].ToString() == "" ? "PKHVT" : frmEdit.drEdit["Ma_Dt"].ToString();
            string strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "' AND Member_Group_ID IN (SELECT MA_BP FROM R81DMBP) ");
            if(strMa_Dt == null)
            {
                strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT MAX(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "'");
                if (strMa_Dt == "KCSLIEU")
                    strMa_Dt = "PQLCL";
            }
            string strTen_Dt_Vc = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Dt_Vc FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt + "' ");

            Hashtable ht = new Hashtable();
            ht.Add("MA_DT", strMa_Dt);
            ht.Add("MA_CT", frmEdit.drEdit["Ma_Ct"]);
            ht.Add("NGAY_CT", GetDate_Server());

            strSo_Ct = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSo_Ct(@Ma_Ct, @Ma_Dt, @Ngay_Ct)", ht, CommandType.Text);

            if (strSo_Ct == string.Empty)
            //if (Common.InlistLike(strSo_Ct, "001"));
            {

                DateTime dteNgay_Ct1 = Library.StrToDate("1/" + ((DateTime)frmEdit.drEditPh["Ngay_Ct"]).Month.ToString() + '/' + ((DateTime)frmEdit.drEditPh["Ngay_Ct"]).Year.ToString()); //+ DateTime.Today.Month.ToString() + "/" 
                DateTime dteNgay_Ct2 = dteNgay_Ct1.AddYears(1).AddDays(-1); //Khoảng cách trong năm
                string strSQL = "SELECT MAX(So_Ct) FROM " + frmEdit.drDmCt["Table_Ph"].ToString() + " WHERE Ma_Dt = '" + strMa_Dt + "' AND Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "'";
                if (Common.InlistLike(strMa_Ct, "DT,DTVPP,BBNA,BBPT,BBTH,DNXNL,PYCPT,DNTT,PONL,POCG"))
                    strSo_Ct_Curent = (string)SQLExec.ExecuteReturnValue("SELECT MAX(So_Ct) FROM " + frmEdit.drDmCt["Table_Ph"].ToString() + " WHERE Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "' AND LEFT(So_Ct,4) = '" + strTen_Dt_Vc + "'");
                else
                    strSo_Ct_Curent = (string)SQLExec.ExecuteReturnValue(strSQL);

                //string strSo_Ct_Current = 
                Hashtable htPara = new Hashtable();
                htPara.Add("TABLENAME", frmEdit.drDmCt["Table_Ph"].ToString());
                htPara.Add("COLUMNNAME", "So_Ct");
                htPara.Add("CURRENTID", strSo_Ct_Curent);
                htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "'");
                htPara.Add("PREFIXLEN", Convert.ToInt32(frmEdit.drDmCt["PrefixLen"]));
                htPara.Add("SUFFIXLEN", Convert.ToInt32(frmEdit.drDmCt["SuffixLen"]));

                strSo_Ct = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
            }

            if (GetDate_Server() >= Convert.ToDateTime("2020-01-01T00:00:00"))
            {
                strSo_Ct_Curent = string.Empty;

                strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "' AND Member_Group_ID IN (SELECT MA_BP FROM R81DMBP) ");
                if (strMa_Dt == null)
                {
                    strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT MAX(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "'");
                    if (strMa_Dt == "KCSLIEU")
                        strMa_Dt = "PQLCL";
                }
                strTen_Dt_Vc = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Dt_Vc FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt + "' ");

                Hashtable ht1 = new Hashtable();
                ht1.Add("MA_DT", strMa_Dt);
                ht1.Add("MA_CT", frmEdit.drEdit["Ma_Ct"]);
                ht1.Add("NGAY_CT", GetDate_Server());

                strSo_Ct = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSo_Ct_PO(@Ma_Ct, @Ma_Dt, @Ngay_Ct)", ht1, CommandType.Text);
            }

            return strSo_Ct;
        }
        public static string Cong_So_Ct_BTTB(frmVoucher_Edit frmEdit)
        {
            string strSo_Ct = string.Empty;
            string strMa_Ct = frmEdit.drEdit["Ma_Ct"].ToString();
            string strSo_Ct_Curent = string.Empty;
            //string strMa_Dt = frmEdit.drEdit["Ma_Dt"].ToString() == null || frmEdit.drEdit["Ma_Dt"].ToString() == "" ? "PKHVT" : frmEdit.drEdit["Ma_Dt"].ToString();
            string strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "' AND Member_Group_ID IN (SELECT MA_BP FROM R81DMBP) ");
            //strMa_Dt = strMa_Dt == null ? strMa_Dt : "PKHVT";
            string strTen_Dt_Vc = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Dt_Vc FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt + "' ");

            Hashtable ht = new Hashtable();
            ht.Add("MA_DT", strMa_Dt);
            ht.Add("MA_CT", frmEdit.drEdit["Ma_Ct"]);
            ht.Add("NGAY_CT", GetDate_Server());

            strSo_Ct = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSo_Ct_BTTB(@Ma_Ct, @Ma_Dt, @Ngay_Ct)", ht, CommandType.Text);

            return strSo_Ct;
        }
        public static string Cong_So_Ct_SO(frmVoucher_Edit frmEdit)
        {
            string strSo_Ct = string.Empty;
            string strMa_Ct = frmEdit.drEdit["Ma_Ct"].ToString();
            string strSo_Ct_Curent = string.Empty;

            Hashtable ht = new Hashtable();
            ht.Add("MA_CT", frmEdit.drEdit["Ma_Ct"]);
            ht.Add("NGAY_CT", GetDate_Server());

            strSo_Ct = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSo_Ct_SO(@Ma_Ct, @Ngay_Ct)", ht, CommandType.Text);

            if (Common.InlistLike(strMa_Ct, "SO,SOCP"))
            {
                DateTime dteNgay_Ct1 = GetDate_Server();

                strSo_Ct_Curent = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(So_Ct),'') FROM R80PH WHERE Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct >= '" + Library.DateToStr(dteNgay_Ct1) + "'");

                if (strSo_Ct != string.Empty && !string.IsNullOrEmpty(strSo_Ct_Curent))
                {
                    Hashtable htPara = new Hashtable();
                    htPara.Add("TABLENAME", frmEdit.drDmCt["Table_Ph"].ToString());
                    htPara.Add("COLUMNNAME", "So_Ct");
                    htPara.Add("CURRENTID", strSo_Ct_Curent);
                    htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct = '" + Library.DateToStr(dteNgay_Ct1) + "'");
                    htPara.Add("PREFIXLEN", Convert.ToInt32(frmEdit.drDmCt["PrefixLen"]));
                    htPara.Add("SUFFIXLEN", Convert.ToInt32(frmEdit.drDmCt["SuffixLen"]));

                    strSo_Ct = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                }
            }
            else  if(strMa_Ct == "LXH")
            {

                DateTime dteNgay_Ct1 = GetDate_Server();
                strSo_Ct_Curent = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(So_Ct),'') FROM R80PH WHERE Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct >= '" + Library.DateToStr(dteNgay_Ct1) + "'");
                Hashtable htPara = new Hashtable();
                htPara.Add("TABLENAME", frmEdit.drDmCt["Table_Ph"].ToString());
                htPara.Add("COLUMNNAME", "So_Ct");
                htPara.Add("CURRENTID", strSo_Ct_Curent);
                htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + strMa_Ct + "'");
                htPara.Add("PREFIXLEN", 1);
                htPara.Add("SUFFIXLEN", 9);
                strSo_Ct = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
            }

            return strSo_Ct;
        }
        public static string Cong_So_Ct(frmVoucher_Edit frmEdit)
        {
            DateTime dteNgay_Ct1 = Library.StrToDate("1/1/" + ((DateTime)frmEdit.drEditPh["Ngay_Ct"]).Year.ToString()); //+ DateTime.Today.Month.ToString() + "/" 
            DateTime dteNgay_Ct2 = dteNgay_Ct1.AddYears(1).AddDays(-1); //Khoảng cách trong năm

            Hashtable htPara = new Hashtable();
            htPara.Add("TABLENAME", frmEdit.drDmCt["Table_Ph"].ToString());
            htPara.Add("COLUMNNAME", "So_Ct");
            htPara.Add("CURRENTID", frmEdit.drEdit["So_Ct"].ToString());
            htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + frmEdit.strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "'");


            if ((bool)frmEdit.drDmCt["Is_HD"] || Common.Inlist(frmEdit.strMa_Ct, "PXDC,PXBR,NMHH,NMKG")) //Hóa đơn hay PX TP dat in tăng theo Số_Seri
            {
                string strSo_Seri0 = frmEdit.dtEditCt.Rows[0]["So_Seri0"].ToString();
                string strMa_Ky_Hieu_HDon = frmEdit.dtEditCt.Rows[0]["Ma_Ky_Hieu_HDon"].ToString();

                if (strSo_Seri0 != "")
                {
                    htPara.Add("PREFIXLEN", Convert.ToInt32(frmEdit.drDmCt["PrefixLen"]));
                    htPara.Add("SUFFIXLEN", Convert.ToInt32(frmEdit.drDmCt["SuffixLen"]));

                    htPara["TABLENAME"] = frmEdit.drDmCt["Table_Ct"].ToString();
                    htPara["COLUMNNAME"] = "So_Ct";
                    htPara["KEY"] = "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + frmEdit.strMa_Ct + "' AND So_Seri0 = '" + strSo_Seri0 + "' AND Ma_Ky_Hieu_HDon = '" + strMa_Ky_Hieu_HDon + "'";
                }
                else if (frmEdit.strMa_Ct == "PXDC" && strSo_Seri0 == "")
                {
                    htPara.Add("PREFIXLEN", 9);
                    htPara.Add("SUFFIXLEN", 0);
                }
            }
            else
            {
                htPara.Add("PREFIXLEN", Convert.ToInt32(frmEdit.drDmCt["PrefixLen"]));
                htPara.Add("SUFFIXLEN", Convert.ToInt32(frmEdit.drDmCt["SuffixLen"]));
            }

            return (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
        }

        public static void Update_CSGia(DataRow drEditCt)
        {
            //Chi cap nhật gia vat tu khi co mã vật tư
            if (drEditCt["Ma_Vt"] == DBNull.Value || (string)drEditCt["Ma_Vt"] == string.Empty)
                return;

            if (drEditCt["Ma_Dt"] == DBNull.Value || (string)drEditCt["Ma_Dt"] == string.Empty)
                return;


            Hashtable htParameter = new Hashtable();

            htParameter.Add("SO_QD", (string)drEditCt["So_QD"]);
            htParameter.Add("MA_KHO", (string)drEditCt["Ma_Kho"]);
            htParameter.Add("MA_VT", (string)drEditCt["Ma_Vt"]);
            htParameter.Add("HT_TT", (string)drEditCt["HT_TT"]);
            htParameter.Add("PT_VC", (string)drEditCt["PT_VC"]);
            htParameter.Add("NGAY_CT", drEditCt["Ngay_Ct"]);

            drEditCt["Gia_Nt9"] = SQLExec.ExecuteReturnValue("sp_GetCSGia", htParameter, CommandType.StoredProcedure);
            drEditCt.AcceptChanges();
        }


        public static void Update_DmNvu(frmVoucher_Edit frmEditCt)
        {
            string strDefaultColumnList = "Tk_No,Tk_Co,Tk_No2,Tk_Co2,Ma_Bp,Ma_Km,Ma_Kho"; //Ma_Vt_Sp,Ma_Hd,Ma_Job,Ma_Dt_CbNv,Ma_Thue,
            bool bCheckExist_DefaultValue = DataTool.SQLCheckExist("sys.procedures", "Name", "sp_GetDmNvu_DefaultValue");

            if (frmEditCt.enuNew_Edit == enuEdit.Edit && !(frmEditCt.Controls["txtMa_Nvu"].Focused && ((rsTextBox)frmEditCt.Controls["txtMa_Nvu"]).bTextChange))
                return;

            #region Cập nhật trên Form
            if (frmEditCt.drDmNvu["Tk_No"].ToString() != "" && !frmEditCt.drDmNvu["Tk_No"].ToString().Contains(",")) //Tk_No
            {

            }
            if (frmEditCt.drDmNvu["Tk_Co"].ToString() != "" && !frmEditCt.drDmNvu["Tk_Co"].ToString().Contains(",")) //Tk_Co
            {

            }
            if (frmEditCt.drDmNvu["Ma_Dt"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
            {

            }
            if (frmEditCt.drDmNvu["Ma_Bp"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Bp"].ToString().Contains(",")) //Ma_Bp
            {

            }
            if (frmEditCt.drDmNvu["Ma_Km"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Km"].ToString().Contains(",")) //Ma_Km
            {

            }
            //if (frmEditCt.drDmNvu["Ma_Vt_Sp"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Vt_Sp"].ToString().Contains(",")) //Ma_Vt_Sp
            //{

            //}
            //if (frmEditCt.drDmNvu["Ma_Hd"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Hd"].ToString().Contains(",")) //Ma_Hd
            //{

            //}
            //if (frmEditCt.drDmNvu["Ma_Job"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Job"].ToString().Contains(",")) //Ma_Job
            //{

            //}
            //if (frmEditCt.drDmNvu["Ma_Dt_CbNv"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Dt_CbNv"].ToString().Contains(",")) //Ma_Dt_CbNv
            //{

            //}
            //if (frmEditCt.drDmNvu["Ma_Thue"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Thue"].ToString().Contains(",")) //Ma_Thue
            //{

            //}
            if (frmEditCt.drDmNvu["Ma_Kho"].ToString() != "" && !frmEditCt.drDmNvu["Ma_Kho"].ToString().Contains(",")) //Ma_Kho
            {

            }
            #endregion

            #region Cập nhật trên lưới
            foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                    continue;

                if ((bool)dr["Deleted"])
                    continue;

                foreach (string strDefaultColumn in strDefaultColumnList.Split(','))
                {
                    string strDefaultValue = frmEditCt.drDmNvu[strDefaultColumn].ToString();
                    string dbRule = "0";
                    dbRule = frmEditCt.drDmNvu[strDefaultColumn + "_RULE"] != null ? frmEditCt.drDmNvu[strDefaultColumn + "_RULE"].ToString() : dbRule;
                    // Bang rao doan nay if (strDefaultValue != "" && frmEditCt.dtEditCt.Columns.Contains(strDefaultColumn))
                    if (frmEditCt.dtEditCt.Columns.Contains(strDefaultColumn) && dbRule != "4")
                    {
                        if (bCheckExist_DefaultValue)
                        {
                            //Tìm giá trị ngầm định trên phiếu trước đó
                            Hashtable htPara = new Hashtable();
                            htPara.Add("MA_NVU", frmEditCt.drDmNvu["Ma_Nvu"].ToString());
                            htPara.Add("TABLE_CT", frmEditCt.drDmCt["Table_Ct"].ToString());
                            htPara.Add("NGAY_CT", frmEditCt.drEditPh["Ngay_Ct"]);
                            htPara.Add("DEFAULTCOLUMN", strDefaultColumn);
                            htPara.Add("DEFAULTVALUELIST", strDefaultValue);
                            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                            string strValue = SQLExec.ExecuteReturnValue("sp_GetDmNvu_DefaultValue", htPara, CommandType.StoredProcedure).ToString();

                            if (strValue != "")
                                dr[strDefaultColumn] = strValue;
                            else
                                dr[strDefaultColumn] = strDefaultValue.Split(',')[0];
                        }
                        else
                        {
                            if (!strDefaultValue.Contains(",") && !dr[strDefaultColumn].ToString().StartsWith(strDefaultValue))
                                dr[strDefaultColumn] = strDefaultValue;
                        }
                    }
                }
            }
            #endregion
        }

        public static void HanTt(frmVoucher_Edit frmEditCt)
        {
            frmHanTt frmHanTt = new frmHanTt();
            frmHanTt.Load(frmEditCt);

            Voucher.HanTt_LockCt(frmEditCt);
        }

        public static void HanTt1(DataRow drCurrent)
        {
            if (!drCurrent.Table.Columns.Contains("Stt"))
                return;

            string strStt = drCurrent["Stt"].ToString();
            string strTk = drCurrent.Table.Columns.Contains("Tk") ? drCurrent["Tk"].ToString() : "";
            string strMa_Dt = drCurrent.Table.Columns.Contains("Ma_Dt") ? drCurrent["Ma_Dt"].ToString() : "";

            frmHanTt frmHanTt = new frmHanTt();
            frmHanTt.Load(strStt, strTk, strMa_Dt);
        }

        //Bang them de lock nhung phoi CXL da xu ly
        public static void Phoi_LockCt(frmVoucher_Edit frmEditCt)
        {
            bool bLock = false;
            DataTable dtCheck;
            DataGridView dgvEditCt1 = null, dgvEditCt2 = null;

            object[] objEditCt1 = frmEditCt.Controls.Find("dgvEditCt1", true);
            object[] objEditCt2 = frmEditCt.Controls.Find("dgvEditCt2", true);

            if (objEditCt1.Length > 0)
                dgvEditCt1 = (DataGridView)objEditCt1[0];

            if (objEditCt2.Length > 0)
                dgvEditCt2 = (DataGridView)objEditCt2[0];

            dtCheck = SQLExec.ExecuteReturnDt("SELECT Stt, Stt0, So_Me, Ma_Vt, DDai_Phoi, So_Luong_Cay FROM R05CTNXLRPHOI WHERE Stt = '" + frmEditCt.strStt + "'");
            #region Lock Grid, không cho người dùng sửa
            foreach (DataGridViewRow dgvr in dgvEditCt1.Rows)
            {
                DataRow drCurrent = ((DataRowView)dgvr.DataBoundItem).Row;

                string strStt = drCurrent["Stt"].ToString();
                string strStt0 = drCurrent["Stt0"].ToString();


                if (dtCheck.Select("Stt = '" + strStt + "' AND Stt0 = " + strStt0 + "").Length > 0)
                    bLock = true;
                else
                    bLock = false;

                if (bLock)
                {
                    dgvr.Cells["Ma_Vt"].ReadOnly = bLock;
                    dgvr.Cells["Ma_Vt"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["Phan_Loai_Phoi"].ReadOnly = bLock;
                    dgvr.Cells["Phan_Loai_Phoi"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["Sl_Phoi_Nong"].ReadOnly = bLock;
                    dgvr.Cells["Sl_Phoi_Nong"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["Sl_Phoi_TG"].ReadOnly = bLock;
                    dgvr.Cells["Sl_Phoi_TG"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["Sl_Phoi_Nguoi"].ReadOnly = bLock;
                    dgvr.Cells["Sl_Phoi_Nguoi"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["So_Luong_Cay"].ReadOnly = bLock;
                    dgvr.Cells["So_Luong_Cay"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["So_Luong9"].ReadOnly = bLock;
                    dgvr.Cells["So_Luong9"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;
                }
            }

            DataTable dtCheck1 = SQLExec.ExecuteReturnDt("SELECT Stt FROM R05CTNXPHOI WHERE Stt = '" + frmEditCt.strStt + "' AND Stt_Inherit_Nhap_Tp IN (SELECT Stt FROM R05CTNX)");

            foreach (DataGridViewRow dgvr in dgvEditCt1.Rows)
            {
                DataRow drCurrent = ((DataRowView)dgvr.DataBoundItem).Row;

                string strStt = drCurrent["Stt"].ToString();
                string strStt0 = drCurrent["Stt0"].ToString();


                if (dtCheck1.Select("Stt = '" + strStt + "'").Length > 0)
                    bLock = true;
                else
                    bLock = false;

                if (bLock)
                {
                    dgvr.Cells["Ma_Vt"].ReadOnly = bLock;
                    dgvr.Cells["Ma_Vt"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    if (frmEditCt.strMa_Ct == "PNSB")
                    {
                        dgvr.Cells["Phan_Loai_Phoi"].ReadOnly = bLock;
                        dgvr.Cells["Phan_Loai_Phoi"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;
                    }
                    dgvr.Cells["Sl_Phoi_Nong"].ReadOnly = bLock;
                    dgvr.Cells["Sl_Phoi_Nong"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["Sl_Phoi_TG"].ReadOnly = bLock;
                    dgvr.Cells["Sl_Phoi_TG"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["Sl_Phoi_Nguoi"].ReadOnly = bLock;
                    dgvr.Cells["Sl_Phoi_Nguoi"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["So_Luong_Cay"].ReadOnly = bLock;
                    dgvr.Cells["So_Luong_Cay"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;

                    dgvr.Cells["So_Luong9"].ReadOnly = bLock;
                    dgvr.Cells["So_Luong9"].Style.ForeColor = bLock ? SystemColors.GrayText : SystemColors.ControlText;
                }
            }

            #endregion
        }

        public static void HanTt_LockCt(frmVoucher_Edit frmEditCt)
        {
            bool bLock_No = false, bLock_Co = false, bLock = false;
            DataTable dtCheck_HanTt_No, dtCheck_HanTt_Co;
            DataGridView dgvEditCt1 = null, dgvEditCt2 = null;

            object[] objEditCt1 = frmEditCt.Controls.Find("dgvEditCt1", true);
            object[] objEditCt2 = frmEditCt.Controls.Find("dgvEditCt2", true);

            if (objEditCt1.Length > 0)
                dgvEditCt1 = (DataGridView)objEditCt1[0];

            if (objEditCt2.Length > 0)
                dgvEditCt2 = (DataGridView)objEditCt2[0];

            #region Lock Grid, không cho người dùng sửa
            foreach (DataGridViewRow dgvr in dgvEditCt1.Rows)
            {
                DataRow drCurrent = ((DataRowView)dgvr.DataBoundItem).Row;
                bLock_No = bLock_Co = false;

                string strTk_No = (bool)frmEditCt.drDmCt["Is_HD"] ? drCurrent["Tk_No2"].ToString() : drCurrent["Tk_No"].ToString();
                string strTk_Co = (bool)frmEditCt.drDmCt["Is_HD"] ? drCurrent["Tk_Co2"].ToString() : drCurrent["Tk_Co"].ToString();
                string strMa_Dt = drCurrent["Ma_Dt"].ToString();
                string strMa_Dt_Co = drCurrent.Table.Columns.Contains("Ma_Dt_Co") && drCurrent["Ma_Dt_Co"].ToString() != "" ? drCurrent["Ma_Dt_Co"].ToString() : strMa_Dt;

                //Kiem tra No
                if (frmEditCt.dtHanTt0 != null && frmEditCt.dtHanTt0.Select("Tk = '" + strTk_No + "' AND Ma_Dt = '" + strMa_Dt + "'").Length > 0)
                    dtCheck_HanTt_No = frmEditCt.dtHanTt0;
                else
                    dtCheck_HanTt_No = SQLExec.ExecuteReturnDt("SELECT Tk, Ma_Dt, ISNULL(SUM(Tien_Tt), 0) AS Tien_Tt1, ISNULL(SUM(Tien_Tt_Nt), 0) AS Tien_Tt_Nt1 FROM R80CtHanTt WHERE (Stt_PT = '" + frmEditCt.strStt + "' OR Stt_HD = '" + frmEditCt.strStt + "') AND (Tk = '" + strTk_No + "') AND (Ma_Dt = '" + strMa_Dt + "') GROUP BY Tk, Ma_Dt");

                if (dtCheck_HanTt_No.Select("(Tien_Tt1 + Tien_Tt_Nt1 <> 0) AND (Tk = '" + strTk_No + "') AND (Ma_Dt = '" + strMa_Dt + "')").Length > 0)
                    bLock_No = true;

                //Kiem tra Co
                if (frmEditCt.dtHanTt0 != null && frmEditCt.dtHanTt0.Select("Tk = '" + strTk_Co + "' AND Ma_Dt = '" + strMa_Dt_Co + "'").Length > 0)
                    dtCheck_HanTt_Co = frmEditCt.dtHanTt0;
                else
                    dtCheck_HanTt_Co = SQLExec.ExecuteReturnDt("SELECT Tk, Ma_Dt, ISNULL(SUM(Tien_Tt), 0) AS Tien_Tt1, ISNULL(SUM(Tien_Tt_Nt), 0) AS Tien_Tt_Nt1 FROM R80CtHanTt WHERE (Stt_PT = '" + frmEditCt.strStt + "' OR Stt_HD = '" + frmEditCt.strStt + "') AND (Tk = '" + strTk_Co + "') AND (Ma_Dt = '" + strMa_Dt_Co + "') GROUP BY Tk, Ma_Dt");

                if (dtCheck_HanTt_Co.Select("(Tien_Tt1 + Tien_Tt_Nt1 <> 0) AND (Tk = '" + strTk_Co + "') AND (Ma_Dt = '" + strMa_Dt_Co + "')").Length > 0)
                    bLock_Co = true;

                //Lock Header
                if (bLock_No || bLock_Co)
                    bLock = true;

                //Thực hiện lock Nợ
                if ((bool)frmEditCt.drDmCt["Is_HD"])
                {
                    if (dgvr.DataGridView.Columns.Contains("Tk_No2"))
                    {
                        dgvr.Cells["Tk_No2"].ReadOnly = bLock_No;
                        dgvr.Cells["Tk_No2"].Style.ForeColor = (bLock_No ? SystemColors.GrayText : SystemColors.ControlText);
                    }
                }
                else
                {
                    if (dgvr.DataGridView.Columns.Contains("Tk_No"))
                    {
                        dgvr.Cells["Tk_No"].ReadOnly = bLock_No;
                        dgvr.Cells["Tk_No"].Style.ForeColor = (bLock_No ? SystemColors.GrayText : SystemColors.ControlText);
                    }
                }

                //Thực hiện Lock Có
                if ((bool)frmEditCt.drDmCt["Is_HD"])
                {
                    if (dgvr.DataGridView.Columns.Contains("Tk_Co2"))
                    {
                        dgvr.Cells["Tk_Co2"].ReadOnly = bLock_Co;
                        dgvr.Cells["Tk_Co2"].Style.ForeColor = (bLock_Co ? SystemColors.GrayText : SystemColors.ControlText);
                    }
                }
                else
                {
                    if (dgvr.DataGridView.Columns.Contains("Tk_Co"))
                    {
                        dgvr.Cells["Tk_Co"].ReadOnly = bLock_Co;
                        dgvr.Cells["Tk_Co"].Style.ForeColor = (bLock_Co ? SystemColors.GrayText : SystemColors.ControlText);
                    }
                }

                if (dgvr.DataGridView.Columns.Contains("Ma_Dt_Co"))
                {
                    dgvr.Cells["Ma_Dt_Co"].ReadOnly = bLock_Co;
                    dgvr.Cells["Ma_Dt_Co"].Style.ForeColor = (bLock_Co ? SystemColors.GrayText : SystemColors.ControlText);
                }

                //Thực hiện Lock các trường còn lại trên lưới
                if (dgvr.DataGridView.Columns.Contains("Ma_Dt"))
                {
                    dgvr.Cells["Ma_Dt"].ReadOnly = (bLock_No || bLock_Co);
                    dgvr.Cells["Ma_Dt"].Style.ForeColor = ((bLock_No || bLock_Co) ? SystemColors.GrayText : SystemColors.ControlText);
                }
                if ((bool)frmEditCt.drDmCt["Is_HD"])
                {
                    if (dgvr.DataGridView.Columns.Contains("Tien2"))
                    {
                        dgvr.Cells["Tien2"].ReadOnly = (bLock_No || bLock_Co);
                        dgvr.Cells["Tien2"].Style.ForeColor = ((bLock_No || bLock_Co) ? SystemColors.GrayText : SystemColors.ControlText);
                    }
                    if (dgvr.DataGridView.Columns.Contains("Tien_Nt2"))
                    {
                        dgvr.Cells["Tien_Nt2"].ReadOnly = (bLock_No || bLock_Co);
                        dgvr.Cells["Tien_Nt2"].Style.ForeColor = ((bLock_No || bLock_Co) ? SystemColors.GrayText : SystemColors.ControlText);
                    }
                }
                else
                {
                    if (dgvr.DataGridView.Columns.Contains("Tien"))
                    {
                        dgvr.Cells["Tien"].ReadOnly = (bLock_No || bLock_Co);
                        dgvr.Cells["Tien"].Style.ForeColor = ((bLock_No || bLock_Co) ? SystemColors.GrayText : SystemColors.ControlText);
                    }
                    if (dgvr.DataGridView.Columns.Contains("Tien_Nt"))
                    {
                        dgvr.Cells["Tien_Nt"].ReadOnly = (bLock_No || bLock_Co);
                        dgvr.Cells["Tien_Nt"].Style.ForeColor = ((bLock_No || bLock_Co) ? SystemColors.GrayText : SystemColors.ControlText);
                    }
                }
                if (dgvr.DataGridView.Columns.Contains("So_Luong9"))
                {
                    dgvr.Cells["So_Luong9"].ReadOnly = (bLock_No || bLock_Co);
                    dgvr.Cells["So_Luong9"].Style.ForeColor = ((bLock_No || bLock_Co) ? SystemColors.GrayText : SystemColors.ControlText);
                }
                if (dgvr.DataGridView.Columns.Contains("Gia_Nt9"))
                {
                    dgvr.Cells["Gia_Nt9"].ReadOnly = (bLock_No || bLock_Co);
                    dgvr.Cells["Gia_Nt9"].Style.ForeColor = ((bLock_No || bLock_Co) ? SystemColors.GrayText : SystemColors.ControlText);
                }
                if (dgvr.DataGridView.Columns.Contains("Tien_Nt9"))
                {
                    dgvr.Cells["Tien_Nt9"].ReadOnly = (bLock_No || bLock_Co);
                    dgvr.Cells["Tien_Nt9"].Style.ForeColor = ((bLock_No || bLock_Co) ? SystemColors.GrayText : SystemColors.ControlText);
                }
            }
            #endregion

            if (frmEditCt.Controls.ContainsKey("dteNgay_Ct"))
                frmEditCt.Controls["dteNgay_Ct"].Enabled = !bLock;

            if (frmEditCt.Controls.ContainsKey("txtMa_Tte"))
                frmEditCt.Controls["txtMa_Tte"].Enabled = !bLock;

            if (frmEditCt.Controls.ContainsKey("numTy_Gia"))
                frmEditCt.Controls["numTy_Gia"].Enabled = !bLock;

            if (frmEditCt.Controls.ContainsKey("txtMa_Dt"))
                frmEditCt.Controls["txtMa_Dt"].Enabled = !bLock;

            //if (frmEditCt.Controls.ContainsKey("numHan_Tt"))
            //    frmEditCt.Controls["numHan_Tt"].Enabled = false;

            if (frmEditCt.Controls.ContainsKey("btHanTt"))
                frmEditCt.Controls["btHanTt"].ForeColor = (bLock ? Color.Red : Color.Blue);
        }

        public static void ImportExcel_SDV(string strTableName, DataTable dtImportDest)
        {
            if (!Common.CheckPermission("IMPORT_" + strTableName, enuPermission_Type.Allow_Access))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to Import " : "Bạn không đc cấp quyền Import " + Languages.GetLanguage(strTableName) + "!";
                Common.MsgCancel(strMsg);
                return;
            }

            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                if (!frmImport.dtImport.Columns.Contains("Nam") || !frmImport.dtImport.Columns.Contains("Ma_Kho") || !frmImport.dtImport.Columns.Contains("Ma_Vt"))
                {
                    Common.MsgCancel("Thiếu một trong các trường dữ liệu [Nam, Ma_Kho, Ma_Vt]");
                    return;
                }

                string strSttPrefix = Element.sysMa_Data + "SDV" + Element.sysWorkingYear.ToString().Trim();
                int iStt = (int)SQLExec.ExecuteReturnValue("SELECT CAST(ISNULL(MAX(SUBSTRING(Stt, 11, 5)), 0) AS INT) FROM R80SDV WHERE Stt LIKE '" + strSttPrefix + "%'");

                //Thực hiện Import
                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    if (drImport.RowState == DataRowState.Deleted)
                        continue;

                    if (Convert.ToInt32(drImport["Nam"]) != Element.sysWorkingYear)
                    {
                        Common.MsgCancel("Không đúng năm làm việc");
                        continue;
                    }

                    iStt++;

                    DataRow drNew = dtImportDest.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);

                    Common.CopyDataRow(drImport, drNew);

                    drNew["Stt"] = strSttPrefix + iStt.ToString().Trim().PadLeft(5, '0');
                    drNew["Nam"] = Element.sysWorkingYear;

                    if (drNew["Ngay_Ct"] == DBNull.Value || drNew["Ngay_Ct"].ToString() == "")
                        drNew["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, 1, 1);

                    if (drNew.Table.Columns.Contains("Ma_DvCs") && drNew["Ma_DvCs"].ToString() == "")
                        drNew["Ma_DvCs"] = RosySystem.Element.Element.sysMa_DvCs;

                    if (drNew.Table.Columns.Contains("Ma_Data") && drNew["Ma_Data"].ToString() == "")
                        drNew["Ma_Data"] = RosySystem.Element.Element.sysMa_Data;

                    if (drNew.Table.Columns.Contains("Create_Log"))
                        drNew["Create_Log"] = Common.GetCurrent_Log();

                    if (DataTool.SQLUpdate(enuEdit.New, "R80SDV", ref drNew))
                    {
                        dtImportDest.Rows.Add(drNew);
                    }
                }
            }
        }


        public static void ImportExcel_SDV_CP(string strTableName, DataTable dtImportDest)
        {
            if (!Common.CheckPermission("IMPORT_" + strTableName, enuPermission_Type.Allow_Access))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to Import " : "Bạn không đc cấp quyền Import " + Languages.GetLanguage(strTableName) + "!";
                Common.MsgCancel(strMsg);
                return;
            }

            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                if (!frmImport.dtImport.Columns.Contains("Nam") || !frmImport.dtImport.Columns.Contains("Ma_Kho") || !frmImport.dtImport.Columns.Contains("Ma_Vt"))
                {
                    Common.MsgCancel("Thiếu một trong các trường dữ liệu [Nam, Ma_Kho, Ma_Vt]");
                    return;
                }

                string strSttPrefix = Element.sysMa_Data + "SDVCP" + Element.sysWorkingYear.ToString().Trim();
                int iStt = (int)SQLExec.ExecuteReturnValue("SELECT CAST(ISNULL(MAX(SUBSTRING(Stt, 11, 5)), 0) AS INT) FROM R80SDV_CP WHERE Stt LIKE '" + strSttPrefix + "%'");

                //Thực hiện Import
                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    if (drImport.RowState == DataRowState.Deleted)
                        continue;

                    if (Convert.ToInt32(drImport["Nam"]) != Element.sysWorkingYear)
                    {
                        Common.MsgCancel("Không đúng năm làm việc");
                        continue;
                    }

                    iStt++;

                    DataRow drNew = dtImportDest.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);

                    Common.CopyDataRow(drImport, drNew);

                    drNew["Stt"] = strSttPrefix + iStt.ToString().Trim().PadLeft(3, '0');
                    drNew["Nam"] = Element.sysWorkingYear;

                    if (drNew["Ngay_Ct"] == DBNull.Value || drNew["Ngay_Ct"].ToString() == "")
                        drNew["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, 1, 1);

                    if (drNew.Table.Columns.Contains("Ma_DvCs") && drNew["Ma_DvCs"].ToString() == "")
                        drNew["Ma_DvCs"] = RosySystem.Element.Element.sysMa_DvCs;

                    if (drNew.Table.Columns.Contains("Ma_Data") && drNew["Ma_Data"].ToString() == "")
                        drNew["Ma_Data"] = RosySystem.Element.Element.sysMa_Data;

                    if (drNew.Table.Columns.Contains("Create_Log"))
                        drNew["Create_Log"] = Common.GetCurrent_Log();

                    if (DataTool.SQLUpdate(enuEdit.New, "R80SDV_CP", ref drNew))
                    {
                        dtImportDest.Rows.Add(drNew);
                    }
                }
            }
        }

        public static void ImportExcel_SDK(string strTableName, DataTable dtImportDest)
        {
            if (!Common.CheckPermission("IMPORT_" + strTableName, enuPermission_Type.Allow_Access))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to Import " : "Bạn không đc cấp quyền Import " + Languages.GetLanguage(strTableName) + "!";
                Common.MsgCancel(strMsg);
                return;
            }

            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                if (!frmImport.dtImport.Columns.Contains("Nam") || !frmImport.dtImport.Columns.Contains("Tk") || !frmImport.dtImport.Columns.Contains("Ma_Dt") || !frmImport.dtImport.Columns.Contains("Ma_Vt_Sp"))
                {
                    Common.MsgCancel("Thiếu một trong các trường dữ liệu [Nam, Tk, Ma_Dt, Ma_Vt_Sp]");
                    return;
                }

                string strSttPrefix = Element.sysMa_Data + "SDK" + Element.sysWorkingYear.ToString().Trim();
                int iStt = (int)SQLExec.ExecuteReturnValue("SELECT CAST(ISNULL(MAX(SUBSTRING(Stt, 11, 5)), 0) AS INT) FROM R80SDK WHERE Stt LIKE '" + strSttPrefix + "%'");

                //Thực hiện Import
                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    if (drImport.RowState == DataRowState.Deleted)
                        continue;

                    if (Convert.ToInt32(drImport["Nam"]) != Element.sysWorkingYear)
                    {
                        Common.MsgCancel("Không đúng năm làm việc");
                        continue;
                    }

                    iStt++;

                    DataRow drNew = dtImportDest.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);

                    Common.CopyDataRow(drImport, drNew);

                    drNew["Stt"] = strSttPrefix + iStt.ToString().Trim().PadLeft(5, '0');
                    drNew["Nam"] = Element.sysWorkingYear;

                    if (drNew["Ngay_Ct"] == DBNull.Value || drNew["Ngay_Ct"].ToString() == "")
                        drNew["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, 1, 1);

                    if (drNew.Table.Columns.Contains("Ma_DvCs") && drNew["Ma_DvCs"].ToString() == "")
                        drNew["Ma_DvCs"] = RosySystem.Element.Element.sysMa_DvCs;

                    if (drNew.Table.Columns.Contains("Ma_Data") && drNew["Ma_Data"].ToString() == "")
                        drNew["Ma_Data"] = RosySystem.Element.Element.sysMa_Data;

                    if (drNew.Table.Columns.Contains("Create_Log"))
                        drNew["Create_Log"] = Common.GetCurrent_Log();

                    if (DataTool.SQLUpdate(enuEdit.New, "R80SDK", ref drNew))
                    {
                        dtImportDest.Rows.Add(drNew);
                    }
                }
            }
        }

        public static void ImportExcel_KIEMKE(string strTableName, DataTable dtImportDest)
        {
            if (!Common.CheckPermission("KKV", enuPermission_Type.Allow_Access))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to Import " : "Bạn không đc cấp quyền Import " + Languages.GetLanguage(strTableName) + "!";
                Common.MsgCancel(strMsg);
                return;
            }

            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                //Thực hiện Import
                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    if (drImport.RowState == DataRowState.Deleted)
                        continue;

                    DataRow drNew = dtImportDest.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);

                    Common.CopyDataRow(drImport, drNew);

                    //if (drNew["Ngay_Ct"] == DBNull.Value || drNew["Ngay_Ct"].ToString() == "")
                    //    drNew["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, 1, 1);

                    if (drNew.Table.Columns.Contains("Ma_DvCs") && drNew["Ma_DvCs"].ToString() == "")
                        drNew["Ma_DvCs"] = RosySystem.Element.Element.sysMa_DvCs;

                    if (drNew.Table.Columns.Contains("Ma_Data") && drNew["Ma_Data"].ToString() == "")
                        drNew["Ma_Data"] = RosySystem.Element.Element.sysMa_Data;

                    if (drNew.Table.Columns.Contains("Create_Log"))
                        drNew["Create_Log"] = Common.GetCurrent_Log();

                    if (DataTool.SQLUpdate(enuEdit.New, "R05KIEMKE", ref drNew))
                    {
                        dtImportDest.Rows.Add(drNew);
                    }
                }
            }
        }

        public static void ImportExcel_SDHanTt(string strTableName, DataTable dtImportDest)
        {
            if (!Common.CheckPermission("IMPORT_" + strTableName, enuPermission_Type.Allow_Access))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to Import " : "Bạn không đc cấp quyền Import " + Languages.GetLanguage(strTableName) + "!";
                Common.MsgCancel(strMsg);
                return;
            }

            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                if (!frmImport.dtImport.Columns.Contains("Nam") || !frmImport.dtImport.Columns.Contains("Tk") || !frmImport.dtImport.Columns.Contains("Ma_Dt") || !frmImport.dtImport.Columns.Contains("Ma_Ct") || !frmImport.dtImport.Columns.Contains("Ngay_Ct"))
                {
                    Common.MsgCancel("Thiếu một trong các trường dữ liệu [Nam, Tk, Ma_Dt, Ma_Ct, Ngay_Ct]");
                    return;
                }

                string strSttPrefix = Element.sysMa_Data + "080" + Element.sysWorkingYear.ToString().Trim();
                int iStt = (int)SQLExec.ExecuteReturnValue("SELECT CAST(ISNULL(MAX(SUBSTRING(Stt, 11, 5)), 0) AS INT) FROM R80SDHanTt WHERE Stt LIKE '" + strSttPrefix + "%'");

                //Thực hiện Import
                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    if (drImport.RowState == DataRowState.Deleted)
                        continue;

                    if (Convert.ToInt32(drImport["Nam"]) != Element.sysWorkingYear)
                    {
                        Common.MsgCancel("Không đúng năm làm việc");
                        continue;
                    }

                    iStt++;

                    DataRow drNew = dtImportDest.NewRow();

                    DataTool.SetDefaultDataRow(ref drNew);

                    Common.CopyDataRow(drImport, drNew);

                    drNew["Stt"] = strSttPrefix + iStt.ToString().Trim().PadLeft(5, '0');
                    drNew["Nam"] = Element.sysWorkingYear;

                    if (drNew["Ngay_Ct"] == DBNull.Value || drNew["Ngay_Ct"].ToString() == "")
                        drNew["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, 1, 1);

                    if (drNew.Table.Columns.Contains("Ma_DvCs") && drNew["Ma_DvCs"].ToString() == "")
                        drNew["Ma_DvCs"] = RosySystem.Element.Element.sysMa_DvCs;

                    if (drNew.Table.Columns.Contains("Ma_Data") && drNew["Ma_Data"].ToString() == "")
                        drNew["Ma_Data"] = RosySystem.Element.Element.sysMa_Data;

                    if (drNew.Table.Columns.Contains("Create_Log"))
                        drNew["Create_Log"] = Common.GetCurrent_Log();

                    if (DataTool.SQLUpdate(enuEdit.New, "R80SDHanTt", ref drNew))
                    {
                        dtImportDest.Rows.Add(drNew);
                    }
                }
            }
        }

        //Cập nhật Create_Log, LastModify_Log cho PH và Ct
        public static void Update_Log(frmVoucher_Edit frmEditCt)
        {
            string strCurrent_Log = Common.GetCurrent_Log();

            if (frmEditCt.enuNew_Edit == enuEdit.New || frmEditCt.enuNew_Edit == enuEdit.Copy)
            {
                frmEditCt.drEditPh["Create_Log"] = strCurrent_Log;
                frmEditCt.drEditPh["LastModify_Log"] = "";

                foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                        continue;

                    if (frmEditCt.dtEditCt.Columns.Contains("Create_Log"))
                        dr["Create_Log"] = strCurrent_Log;

                    if (frmEditCt.dtEditCt.Columns.Contains("LastModify_Log"))
                        dr["LastModify_Log"] = "";
                }
            }
            else
            {
                frmEditCt.drEditPh["LastModify_Log"] = Common.GetCurrent_Log();

                if (frmEditCt.dtEditCt.Columns.Contains("LastModify_Log"))
                {
                    foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
                    {
                        if (dr.RowState == DataRowState.Deleted)
                            continue;

                        dr["LastModify_Log"] = strCurrent_Log;
                    }
                }
            }
        }

        public static void InheritVoucherXuatPhoi_SetData(frmInheritVoucher frmInherit, frmVoucher_Edit frmEdit)
        {
            if (frmInherit.dtInheritVoucher.Select("Chon = true").Length == 0)
                return;

            DataRow drEditPh = frmEdit.drEditPh;
            DataTable dtEditCt = frmEdit.dtEditCt;
            DataRow drEditCt = dtEditCt.NewRow();

            Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);

            if (frmInherit.chkInheritOverwrite.Checked)
                dtEditCt.Rows.Clear();

            int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0"));

            foreach (DataRow drSelect in frmInherit.dtInheritVoucher.Select("Chon = true"))
            {
                iStt0 += 1;

                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);

                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drEditCtNew["Ma_Vt"]);

                if (drDmVt != null)
                {
                    drEditCtNew["Ten_Vt"] = drDmVt["Ten_Vt"];
                    drEditCtNew["Dvt"] = drDmVt["Dvt"];
                    drEditCtNew["He_So9"] = 1;
                }
                drEditCtNew["So_Luong9"] = drSelect["So_Luong"];
                drEditCtNew["So_Luong_Barem"] = drSelect["So_Luong"];
                drEditCtNew["So_Luong"] = drSelect["So_Luong"];
                //drEditCtNew["So_Luong9 "] = drSelect["So_Luong"];

                drEditCtNew["Stt"] = frmEdit.strStt;
                drEditCtNew["Stt0"] = iStt0.ToString();

                dtEditCt.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();

            }
        }
        public static double XuLyHanTt(DataRow drCurrent)
        {
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT", drCurrent["Ngay_Ct"]);
            ht.Add("HT_TT", drCurrent["Ht_Tt"]);
            ht.Add("TK", "");

            return Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_XuLyNgayTt(@Ngay_Ct, @Ht_Tt, @Tk)", ht, CommandType.Text));
        }
        public static void InheritVoucher_SetData(frmVoucher_Edit frmEdit, DataTable dtInheritData)
        {
            if (dtInheritData.Rows.Count == 0)
                return;

            DataRow drEditPh = frmEdit.drEditPh;
            DataTable dtEditCt = frmEdit.dtEditCt;
            DataRow drEditCt = dtEditCt.NewRow();

            Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);

            dtEditCt.Clear();
            if (dtInheritData.Rows.Count > 0)
            {

                DataRow drInheritVoucher = dtInheritData.Rows[0];
                string strMa_Dt = drInheritVoucher["Ma_Dt_CbNv"].ToString();

                Common.GatherMemvar(frmEdit, ref drEditPh);

                drEditPh["Ma_Dt"] = strMa_Dt;
                string strTen_Dt = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt);

                if (drEditPh.Table.Columns.Contains("Ngay_Ct") && drInheritVoucher.Table.Columns.Contains("Ngay_Ct"))
                    drEditPh["Ngay_Ct"] = (DateTime)drInheritVoucher["Ngay_Ct"];

                if (drEditPh.Table.Columns.Contains("Dien_Giai") && drInheritVoucher.Table.Columns.Contains("Dien_Giai"))
                {
                    drEditPh["Dien_Giai"] = drInheritVoucher["Dien_Giai"].ToString();
                }
                if (drEditPh.Table.Columns.Contains("Dia_Chi") && drInheritVoucher.Table.Columns.Contains("Dia_Chi"))
                    drEditPh["Dia_Chi"] = drInheritVoucher["Dia_Chi"].ToString();

                if (drEditPh.Table.Columns.Contains("Ong_Ba") && drInheritVoucher.Table.Columns.Contains("Ong_Ba"))
                    drEditPh["Ong_Ba"] = drInheritVoucher["Ong_Ba"].ToString();

                if (drEditPh.Table.Columns.Contains("Ma_Hd") && drInheritVoucher.Table.Columns.Contains("Ma_Hd"))
                    drEditPh["Ma_Hd"] = drInheritVoucher["Ma_Hd"].ToString();
                
                if (drEditPh.Table.Columns.Contains("Ma_CTrinh") && drInheritVoucher.Table.Columns.Contains("Ma_CTrinh"))
                    drEditPh["Ma_CTrinh"] = drInheritVoucher["Ma_CTrinh"].ToString();

                if (drEditPh.Table.Columns.Contains("So_QD") && drInheritVoucher.Table.Columns.Contains("So_QD"))
                    drEditPh["So_QD"] = drInheritVoucher["So_QD"].ToString();

                if (drEditPh.Table.Columns.Contains("SO_LXH") && drInheritVoucher.Table.Columns.Contains("SO_LXH"))
                    drEditPh["SO_LXH"] = drInheritVoucher["SO_LXH"].ToString();

                if (drEditPh.Table.Columns.Contains("SO_DH_KH") && drInheritVoucher.Table.Columns.Contains("SO_DH_KH"))
                    drEditPh["SO_DH_KH"] = drInheritVoucher["SO_DH_KH"].ToString();

                if (drEditPh.Table.Columns.Contains("ID_DT_VC") && drInheritVoucher.Table.Columns.Contains("ID_DT_VC"))
                    drEditPh["ID_DT_VC"] = drInheritVoucher["ID_DT_VC"].ToString();

                if (drEditPh.Table.Columns.Contains("TEN_DT_VC") && drInheritVoucher.Table.Columns.Contains("TEN_DT_VC"))
                    drEditPh["TEN_DT_VC"] = drInheritVoucher["TEN_DT_VC"].ToString();

                if (drEditPh.Table.Columns.Contains("MA_DT_VC") && drInheritVoucher.Table.Columns.Contains("MA_DT_VC"))
                    drEditPh["MA_DT_VC"] = drInheritVoucher["MA_DT_VC"].ToString();

                if (drEditPh.Table.Columns.Contains("ID_DT_NHAN") && drInheritVoucher.Table.Columns.Contains("ID_DT_NHAN"))
                    drEditPh["ID_DT_NHAN"] = drInheritVoucher["ID_DT_NHAN"].ToString();

                if (drEditPh.Table.Columns.Contains("TEN_DT_NHAN") && drInheritVoucher.Table.Columns.Contains("TEN_DT_NHAN"))
                    drEditPh["TEN_DT_NHAN"] = drInheritVoucher["TEN_DT_NHAN"].ToString();

                if (drEditPh.Table.Columns.Contains("Ht_Tt") && drInheritVoucher.Table.Columns.Contains("Ht_Tt"))
                    drEditPh["Ht_Tt"] = drInheritVoucher["Ht_Tt"].ToString();

                if (drEditPh.Table.Columns.Contains("So_Xe") && drInheritVoucher.Table.Columns.Contains("So_Xe"))
                    drEditPh["So_Xe"] = drInheritVoucher["So_Xe"].ToString();

                if (drEditPh.Table.Columns.Contains("So_Xa_Lan_Tau") && drInheritVoucher.Table.Columns.Contains("So_Xa_Lan_Tau"))
                    drEditPh["So_Xa_Lan_Tau"] = drInheritVoucher["So_Xa_Lan_Tau"].ToString();

                if (drEditPh.Table.Columns.Contains("Han_Tt") && drInheritVoucher.Table.Columns.Contains("Han_Tt"))
                    drEditPh["Han_Tt"] = drInheritVoucher["Han_Tt"].ToString();



                drEditPh.AcceptChanges();

                Common.ScaterMemvar(frmEdit, ref drEditPh);
            }



            int iStt0 = 0;// Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0"));

            foreach (DataRow drSelect in dtInheritData.Rows)
            {

                iStt0 += 1;

                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);



                if ((string)frmEdit.drDmCt["Nh_Ct"] == "2" && drEditCtNew.Table.Columns.Contains("Auto_Cost"))
                    drEditCtNew["Auto_Cost"] = true;

                if ((string)frmEdit.drDmCt["Vt_Kt"].ToString() == "V")
                {
                    DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drEditCtNew["Ma_Vt"]);

                    if (drDmVt != null)
                    {
                        if (drEditCtNew.Table.Columns.Contains("Ten_Vt") && drSelect.Table.Columns.Contains("Ten_Vt"))
                            drEditCtNew["Ten_Vt"] = drSelect["Ten_Vt"];
                        else
                            drEditCtNew["Ten_Vt"] = drDmVt["Ten_Vt"];

                    }
                }
                drEditCtNew["Ma_Bp"] = drSelect["Ma_Bp_Sd"];
                drEditCtNew["Stt"] = frmEdit.strStt;
                drEditCtNew["Stt_Org"] = drSelect["Stt"];

                if (dtEditCt.Columns.Contains("Stt0_Org"))
                    drEditCtNew["Stt0_Org"] = drSelect["Stt0"];



                drEditCtNew["Stt0"] = iStt0.ToString();

             

                dtEditCt.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }

        }

        public static void InheritVoucher_SetData(frmInheritVoucher frmInherit, frmVoucher_Edit frmEdit)
        {
            if (frmInherit.dtInheritVoucher.Select("Chon = true").Length == 0)
                return;

            DataRow drEditPh = frmEdit.drEditPh;
            DataTable dtEditCt = frmEdit.dtEditCt;
            DataRow drEditCt = dtEditCt.NewRow();

            Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);

            if (frmInherit.chkInheritOverwrite.Checked)
                dtEditCt.Rows.Clear();

            int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0"));



            if (frmInherit.dtInheritVoucher.Rows.Count > 0)
            {
                if (!Common.InlistLike((string)drEditCt["Ma_Ct"], "DT,PXPH,BBPT,BBTH,DNX,POCG,BTTT,BTKH,CTSC,BTNT,DTCP,BBBG,BBBN,BBXE,GRVC,BN"))
                {
                    DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Select("Chon = 1")[0];
                    string strMa_Dt = drInheritVoucher["Ma_Dt"].ToString();

                    Common.GatherMemvar(frmEdit, ref drEditPh);

                    drEditPh["Ma_Dt"] = strMa_Dt;
                    string strTen_Dt = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt);
                    DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_DT", strMa_Dt);
                    if (!Common.InlistLike((string)drEditCt["Ma_Ct"], "LXH,PXDC,PXBR,HD,PX,BBNL"))
                    {
                        if (drEditPh.Table.Columns.Contains("Ngay_Ct") && drInheritVoucher.Table.Columns.Contains("Ngay_Ct"))
                            drEditPh["Ngay_Ct"] = (DateTime)drInheritVoucher["Ngay_Ct"];
                    }
                    if (drEditPh.Table.Columns.Contains("Dien_Giai") && drInheritVoucher.Table.Columns.Contains("Dien_Giai"))
                    {
                        drEditPh["Dien_Giai"] = drInheritVoucher["Dien_Giai"].ToString();
                    }

                    if (drEditPh.Table.Columns.Contains("Dien_Giai") && drInheritVoucher.Table.Columns.Contains("Ma_Dt") && drEditPh["Ma_Ct"].ToString().StartsWith("HD"))
                    {
                        //drEditPh["Dien_Giai"] = drInheritVoucher["Dien_Giai"].ToString();

                        drEditPh["Dien_Giai"] = "Xuất bán " + strTen_Dt;
                    }

                    if (drEditPh.Table.Columns.Contains("Ghi_Chu") && drInheritVoucher.Table.Columns.Contains("Ghi_Chu"))
                    {
                        drEditPh["Ghi_Chu"] = drInheritVoucher["Ghi_Chu"].ToString();
                    }
                    
                    if (drEditPh.Table.Columns.Contains("Ma_Kho_CalGia") && drInheritVoucher.Table.Columns.Contains("Ma_Kho_CalGia"))
                        drEditPh["Ma_Kho_CalGia"] = drInheritVoucher["Ma_Kho_CalGia"].ToString();
                    else if (drEditPh.Table.Columns.Contains("Ma_Kho_CalGia") && !drInheritVoucher.Table.Columns.Contains("Ma_Kho_CalGia"))
                        drEditPh["Ma_Kho_CalGia"] = drInheritVoucher["Ma_Kho"].ToString();

                    if (drEditPh.Table.Columns.Contains("Dia_Chi") && drInheritVoucher.Table.Columns.Contains("Dia_Chi"))
                        drEditPh["Dia_Chi"] = drInheritVoucher["Dia_Chi"].ToString();

                    if (drEditPh.Table.Columns.Contains("Ong_Ba") && drInheritVoucher.Table.Columns.Contains("Ong_Ba"))
                        drEditPh["Ong_Ba"] = drInheritVoucher["Ong_Ba"].ToString();

                    if (drEditPh.Table.Columns.Contains("Ma_Dt_Cbnv") && drInheritVoucher.Table.Columns.Contains("Ma_Dt_Cbnv"))
                        drEditPh["Ma_Dt_Cbnv"] = drInheritVoucher["Ma_Dt_Cbnv"].ToString();

                    if (drEditPh.Table.Columns.Contains("Ma_Hd") && drInheritVoucher.Table.Columns.Contains("Ma_Hd"))
                        drEditPh["Ma_Hd"] = drInheritVoucher["Ma_Hd"].ToString();


                    if (drEditPh.Table.Columns.Contains("Ma_Kho") && drInheritVoucher.Table.Columns.Contains("Ma_Kho"))
                        drEditPh["Ma_Kho"] = drInheritVoucher["Ma_Kho"].ToString();

                    if (drEditPh.Table.Columns.Contains("So_QD") && drInheritVoucher.Table.Columns.Contains("So_QD"))
                        drEditPh["So_QD"] = drInheritVoucher["So_QD"].ToString();

                    if (drEditPh.Table.Columns.Contains("Ma_CTrinh") && drInheritVoucher.Table.Columns.Contains("Ma_CTrinh"))
                        drEditPh["Ma_CTrinh"] = drInheritVoucher["Ma_CTrinh"].ToString();

                    if (drEditPh.Table.Columns.Contains("Ma_PLCTrinh") && drInheritVoucher.Table.Columns.Contains("Ma_PLCTrinh"))
                        drEditPh["Ma_PLCTrinh"] = drInheritVoucher["Ma_PLCTrinh"].ToString();

                    if (drEditPh.Table.Columns.Contains("HT_TT") && drInheritVoucher.Table.Columns.Contains("HT_TT"))
                        drEditPh["HT_TT"] = drInheritVoucher["HT_TT"].ToString();

                    if (drEditPh.Table.Columns.Contains("Han_Tt") && drInheritVoucher.Table.Columns.Contains("Han_Tt"))
                        drEditPh["Han_Tt"] = drInheritVoucher["Han_Tt"];

                    if (drEditPh.Table.Columns.Contains("HT_GN") && drInheritVoucher.Table.Columns.Contains("HT_GN"))
                        drEditPh["HT_GN"] = drInheritVoucher["HT_GN"].ToString();

                    if (drEditPh.Table.Columns.Contains("PT_VC") && drInheritVoucher.Table.Columns.Contains("PT_VC"))
                        drEditPh["PT_VC"] = drInheritVoucher["PT_VC"].ToString();

                    if (drEditPh.Table.Columns.Contains("SO_LXH") && drInheritVoucher.Table.Columns.Contains("SO_LXH"))
                        drEditPh["SO_LXH"] = drInheritVoucher["SO_LXH"].ToString();

                    if (drEditPh.Table.Columns.Contains("SO_DH_KH") && drInheritVoucher.Table.Columns.Contains("SO_DH_KH"))
                        drEditPh["SO_DH_KH"] = drInheritVoucher["SO_DH_KH"].ToString();

                    if (drEditPh.Table.Columns.Contains("ID_DT_VC") && drInheritVoucher.Table.Columns.Contains("ID_DT_VC"))
                        drEditPh["ID_DT_VC"] = drInheritVoucher["ID_DT_VC"].ToString();

                    if (drEditPh.Table.Columns.Contains("SO_XE") && drInheritVoucher.Table.Columns.Contains("SO_XE"))
                        drEditPh["SO_XE"] = drInheritVoucher["SO_XE"].ToString();

                    if (drEditPh.Table.Columns.Contains("SO_XA_LAN_TAU") && drInheritVoucher.Table.Columns.Contains("SO_XA_LAN_TAU"))
                        drEditPh["SO_XA_LAN_TAU"] = drInheritVoucher["SO_XA_LAN_TAU"].ToString();

                    if (drEditPh.Table.Columns.Contains("TEN_DT_VC") && drInheritVoucher.Table.Columns.Contains("TEN_DT_VC"))
                        drEditPh["TEN_DT_VC"] = drInheritVoucher["TEN_DT_VC"].ToString();

                    if (drEditPh.Table.Columns.Contains("MA_DT_VC") && drInheritVoucher.Table.Columns.Contains("MA_DT_VC"))
                        drEditPh["MA_DT_VC"] = drInheritVoucher["MA_DT_VC"].ToString();

                    if (drEditPh.Table.Columns.Contains("ID_DT_NHAN") && drInheritVoucher.Table.Columns.Contains("ID_DT_NHAN"))
                        drEditPh["ID_DT_NHAN"] = drInheritVoucher["ID_DT_NHAN"].ToString();

                    if (drEditPh.Table.Columns.Contains("TEN_DT_NHAN") && drInheritVoucher.Table.Columns.Contains("TEN_DT_NHAN"))
                        drEditPh["TEN_DT_NHAN"] = drInheritVoucher["TEN_DT_NHAN"].ToString();

                    if (drEditPh.Table.Columns.Contains("Ghi_Chu_HD") && drInheritVoucher.Table.Columns.Contains("Ghi_Chu_HD"))
                        drEditPh["Ghi_Chu_HD"] = drInheritVoucher["Ghi_Chu_HD"].ToString();

                    if (drEditPh.Table.Columns.Contains("So_Luong0") && drInheritVoucher.Table.Columns.Contains("So_Luong0"))
                        drEditPh["So_Luong0"] = drInheritVoucher["So_Luong0"].ToString();

                    if (drEditPh.Table.Columns.Contains("So_Luong_CNXX") && drInheritVoucher.Table.Columns.Contains("So_Luong_CNXX"))
                        drEditPh["So_Luong_CNXX"] = drInheritVoucher["So_Luong_CNXX"].ToString();

                    if (drEditPh.Table.Columns.Contains("So_Luong_TPH") && drInheritVoucher.Table.Columns.Contains("So_Luong_TPH"))
                        drEditPh["So_Luong_TPH"] = drInheritVoucher["So_Luong_TPH"].ToString();

                    if (drEditPh.Table.Columns.Contains("Is_KCS") && drInheritVoucher.Table.Columns.Contains("Is_KCS"))
                        drEditPh["Is_KCS"] = drInheritVoucher["Is_KCS"];

                    if (drEditPh.Table.Columns.Contains("Is_CNXX") && drInheritVoucher.Table.Columns.Contains("Is_CNXX"))
                        drEditPh["Is_CNXX"] = drInheritVoucher["Is_CNXX"];

                    if (drEditPh.Table.Columns.Contains("Is_TPH") && drInheritVoucher.Table.Columns.Contains("Is_TPH"))
                        drEditPh["Is_TPH"] = drInheritVoucher["Is_TPH"];

                    if (drEditPh.Table.Columns.Contains("Ma_Tte") && drInheritVoucher.Table.Columns.Contains("Ma_Tte"))
                        drEditPh["Ma_Tte"] = drInheritVoucher["Ma_Tte"].ToString();

                    if (drEditPh.Table.Columns.Contains("Ty_Gia") && drInheritVoucher.Table.Columns.Contains("Ty_Gia"))
                        drEditPh["Ty_Gia"] = drInheritVoucher["Ty_Gia"].ToString();

                    if (drEditPh.Table.Columns.Contains("Ngay_Ct0") && drInheritVoucher.Table.Columns.Contains("Ngay_Ct0"))
                        drEditPh["Ngay_Ct0"] = drEditPh["Ngay_Ct"];

                    if (drEditPh.Table.Columns.Contains("Ma_Km") && drInheritVoucher.Table.Columns.Contains("Ma_Km"))
                        drEditPh["Ma_Km"] = drInheritVoucher["Ma_Km"].ToString();
                    
                    if (drEditPh.Table.Columns.Contains("Ma_Bp") && drInheritVoucher.Table.Columns.Contains("Ma_Bp"))
                        drEditPh["Ma_Bp"] = drInheritVoucher["Ma_Bp"].ToString();

                    
                    if (drEditPh.Table.Columns.Contains("Ngay_Ct") && drInheritVoucher.Table.Columns.Contains("Ngay_Ct") && drEditPh["Ma_Ct"].ToString() == "PXDC" && drInheritVoucher["Ma_Ct"].ToString() == "NMHH")
                    { drEditPh["Ngay_Ct"] = drInheritVoucher["Ngay_Ct"]; drEditPh["Ngay_Ct0"] = drInheritVoucher["Ngay_Ct"]; }

                    if (drEditPh.Table.Columns.Contains("Ma_KhoN") && drInheritVoucher.Table.Columns.Contains("Ma_KhoN"))
                        drEditPh["Ma_KhoN"] = drInheritVoucher["Ma_KhoN"].ToString();

                    

                    if (drEditPh["Ma_Ct"].ToString().StartsWith("PXSB"))
                    {
                        if (drEditPh.Table.Columns.Contains("So_Phieu_Can"))
                            drEditPh["So_Phieu_Can"] = drInheritVoucher["So_Ct"].ToString();
                        if (drEditPh.Table.Columns.Contains("So_Xe"))
                            drEditPh["So_Xe"] = drInheritVoucher["So_Xe"].ToString();
                        if (drEditPh.Table.Columns.Contains("Ma_Hang"))
                            drEditPh["Ma_Hang"] = drInheritVoucher["Ma_Vt"].ToString();
                    }
                    //Cập nhật tên đối tượng
                    if (drEditPh.Table.Columns.Contains("Ten_Dt"))
                    {
                        

                        drEditPh["Ten_Dt"] = (drDmDt != null) ? drDmDt["Ten_Dt"] : drInheritVoucher["Ong_Ba"].ToString();
                        if (drEditPh.Table.Columns.Contains("Ong_Ba"))
                            if ((string)drEditPh["Ong_Ba"] == "")
                                drEditPh["Ong_Ba"] = drDmDt["Ong_Ba"].ToString();

                        if (drEditPh.Table.Columns.Contains("Dia_Chi"))
                            //if ((string)drEditPh["Dia_Chi"] == "")
                                drEditPh["Dia_Chi"] = drDmDt["Dia_Chi"].ToString();

                        if (drEditPh.Table.Columns.Contains("Ten_DtGtGt"))
                            drEditPh["Ten_DtGtGt"] = drDmDt["Ten_Dt"].ToString();

                        if (drEditPh.Table.Columns.Contains("Ma_So_Thue"))
                            drEditPh["Ma_So_Thue"] = drDmDt["Ma_So_Thue"].ToString();
                    }

                    drEditPh.AcceptChanges();

                    Common.ScaterMemvar(frmEdit, ref drEditPh);
                }
                else if (Common.InlistLike((string)drEditCt["Ma_Ct"], "BBPT,BBTH"))
                {
                    DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Select("Chon = 1")[0];

                    if (drInheritVoucher.Table.Columns.Contains("Ma_Dt_Pyc"))
                    {
                        drEditPh["Ma_Dt"] = drInheritVoucher["Ma_Dt_Pyc"].ToString();
                        drEditPh["Ong_Ba"] = drInheritVoucher["Ong_Ba_Pyc"].ToString();
                        drEditPh["Dien_Giai"] = drInheritVoucher["Dien_Giai"].ToString();
                    }
                    if (drEditPh.Table.Columns.Contains("DaiDien_KHVT") && drInheritVoucher.Table.Columns.Contains("Ten_Dt_CbNv") && drEditPh["Ma_Ct"].ToString().StartsWith("BB"))
                        drEditPh["DaiDien_KHVT"] = drInheritVoucher["Ten_Dt_CbNv"].ToString();
                    drEditPh.AcceptChanges();

                    Common.ScaterMemvar(frmEdit, ref drEditPh);
                }
                else if (Common.InlistLike((string)drEditCt["Ma_Ct"], "CTSC,BBBG,GRVC"))
                {
                    DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Select("Chon = 1")[0];

                    //drEditPh["Noi_Dung"] = drInheritVoucher["Noi_Dung"].ToString();
                    drEditPh["Ma_Nh_Tb"] = drInheritVoucher["Ma_Nh_Tb"].ToString();
                    //drEditPh["Stt_Org"] = drInheritVoucher["Stt"].ToString();
                    //drEditPh["Stt0_Org"] = drInheritVoucher["Stt0_Org"];
                    //drEditPh["Stt0_Org"] = drInheritVoucher["Stt0"];

                    drEditPh.AcceptChanges();

                    Common.ScaterMemvar(frmEdit, ref drEditPh);
                }
                else if (Common.InlistLike((string)drEditCt["Ma_Ct"], "BTBN,BBBN,BBXE,DTCP"))
                {
                    DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Select("Chon = 1")[0];
                    drEditPh["Ma_Nh_Tb"] = drInheritVoucher["Ma_Nh_Tb"].ToString();


                    drEditPh.AcceptChanges();

                    Common.ScaterMemvar(frmEdit, ref drEditPh);
                }

                else if (Common.InlistLike((string)drEditCt["Ma_Ct"], "DT"))
                {
                    DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Select("Chon = 1")[0];

                    if (drInheritVoucher.Table.Columns.Contains("GD_Duyet"))
                    {
                        drEditPh["GD_Duyet"] = drInheritVoucher["GD_Duyet"].ToString();
                    }

                    drEditPh.AcceptChanges();

                    Common.ScaterMemvar(frmEdit, ref drEditPh);
                }
                else if (Common.InlistLike((string)drEditCt["Ma_Ct"], "BN"))
                {
                    DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Select("Chon = 1")[0];

                    if (drInheritVoucher.Table.Columns.Contains("Dien_Giai"))
                    {
                        drEditPh["Dien_Giai"] = drInheritVoucher["Dien_Giai"].ToString();
                    }
                    if (drInheritVoucher.Table.Columns.Contains("Ma_Dt"))
                    {
                        drEditPh["Ma_Dt"] = drInheritVoucher["Ma_Dt"].ToString();
                    }
                    if (drInheritVoucher.Table.Columns.Contains("Ong_Ba"))
                    {
                        drEditPh["Ong_Ba"] = drInheritVoucher["Ong_Ba"].ToString();
                    }
                    if (drInheritVoucher.Table.Columns.Contains("Dia_Chi"))
                    {
                        drEditPh["Dia_Chi"] = drInheritVoucher["Dia_Chi"].ToString();
                    }
                    if (drInheritVoucher.Table.Columns.Contains("Ma_Tte"))
                    {
                        drEditPh["Ma_Tte"] = drInheritVoucher["Ma_Tte"].ToString();
                    }
                    if (drInheritVoucher.Table.Columns.Contains("Ty_Gia"))
                    {
                        drEditPh["Ty_Gia"] = drInheritVoucher["Ty_Gia"].ToString();
                    }
                    if (drInheritVoucher.Table.Columns.Contains("Ma_Hd"))
                    {
                        drEditPh["Ma_Hd"] = drInheritVoucher["Ma_Hd"].ToString();
                    }
                    if (drEditPh.Table.Columns.Contains("Tk_Nh_B") && drInheritVoucher.Table.Columns.Contains("Tk_Nh_B"))
                    {
                        drEditPh["Tk_Nh_B"] = drInheritVoucher["Tk_Nh_B"].ToString();
                        drEditPh["Ten_Nh_B"] = drInheritVoucher["Ten_Nh_B"].ToString();
                        drEditPh["Ten_Dv_B"] = drInheritVoucher["Ong_Ba"].ToString();
                    }
                    drEditPh.AcceptChanges();

                    Common.ScaterMemvar(frmEdit, ref drEditPh);
                }
            }

            string strSo_LGH_List = string.Empty;
            string strSo_LGH = string.Empty;
            //if (Common.InlistLike(drEditCt["Ma_Ct"].ToString(), "PXBR,PXDC"))
            //{ }
            //else
            //{ 
            foreach (DataRow drSelect in frmInherit.dtInheritVoucher.Select("Chon = true"))
            {
                iStt0 += 1;

                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);



                if ((string)frmEdit.drDmCt["Nh_Ct"] == "2" && drEditCtNew.Table.Columns.Contains("Auto_Cost"))
                    drEditCtNew["Auto_Cost"] = true;

                if (Common.InlistLike(drEditCt["Ma_Ct"].ToString(), "PXBR,PXDC"))
                {
                    if (drSelect.Table.Columns.Contains("So_LGH"))
                    {
                        if (strSo_LGH != drSelect["So_LGH"].ToString())
                        {
                            strSo_LGH = drSelect["So_LGH"].ToString();
                            strSo_LGH_List = strSo_LGH + "," + strSo_LGH_List;
                        }
                    }
                }
                if (frmEdit.strMa_Ct.StartsWith("HD"))
                {
                    drEditCtNew["Tien_Nt"] = 0;
                    drEditCtNew["Tien"] = 0;
                    drEditCtNew["Gia_Nt"] = 0;
                    drEditCtNew["Gia"] = 0;
                    drEditCtNew["Tk_Co"] = "";
                    drEditCtNew["Tk_No"] = "";
                }

                if (Common.InlistLike(drEditCt["Ma_Ct"].ToString(), "DT,DTVPP"))
                {
                    if (drSelect.Table.Columns.Contains("Tk_No"))
                    {
                        drEditCtNew["So_Luong0"] = drSelect["So_Luong1"];
                        drEditCtNew["So_Luong9"] = drSelect["So_Luong1"];

                    }
                    drEditCtNew["Ma_Vt_Tt"] = drSelect["Ma_Vt"];
                }

                if ((string)frmEdit.drDmCt["Vt_Kt"].ToString() == "V")
                {
                    DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drEditCtNew["Ma_Vt"]);

                    if (drDmVt != null)
                    {
                        if ((bool)frmEdit.drDmCt["Is_HD"])
                        {
                            drEditCtNew["Ten_Vt"] = drDmVt["Ten_Vt"];

                            if ((string)frmEdit.drDmCt["Nh_Ct"] == "1")
                            {
                                drEditCtNew["Tk_No2"] = drDmVt["Tk_HBTL"];
                                drEditCtNew["Tk_Co"] = "";
                                drEditCtNew["Tk_No"] = "";


                            }
                            else
                            {

                            }

                        }


                        else
                        {
                            if ((string)frmEdit.drDmCt["Nh_Ct"] == "1" && drEditCtNew.Table.Columns.Contains("Tk_No"))
                                drEditCtNew["Tk_No"] = drDmVt["Tk_VTu"];

                            if (drEditCtNew.Table.Columns.Contains("Ten_Vt_Tt") && drSelect.Table.Columns.Contains("Ten_Vt_Tt"))
                                drEditCtNew["Ten_Vt_Tt"] = drSelect["Ten_Vt"];

                            if (drEditCtNew.Table.Columns.Contains("Ten_Vt") && drSelect.Table.Columns.Contains("Ten_Vt"))
                                drEditCtNew["Ten_Vt"] = drSelect["Ten_Vt"];
                            else
                                drEditCtNew["Ten_Vt"] = drDmVt["Ten_Vt"];
                        }
                    }
                }

                if (drEditPh["Ma_Ct"].ToString().StartsWith("DNX") && drEditCtNew.Table.Columns.Contains("So_Luong_KtCdAt"))
                {
                    drEditCtNew["So_Luong0"] = drSelect["So_Luong9"];
                    drEditCtNew["So_Luong"] = drSelect["So_Luong9"];
                    drEditCtNew["So_Luong_KtCdAt"] = drSelect["So_Luong9"];
                    drEditCtNew["So_Luong_Tp"] = drSelect["So_Luong9"];

                }

                if (drEditCtNew.Table.Columns.Contains("Is_Print_Barem"))
                    drEditCtNew["Is_Print_Barem"] = 1;

                if (drEditCtNew.Table.Columns.Contains("Stt0_Org") && drSelect.Table.Columns.Contains("Stt0"))
                    drEditCtNew["Stt0_Org"] = drSelect["Stt0"];

                if (drEditCtNew.Table.Columns.Contains("Thong_So_Kt"))
                {
                    if (drSelect.Table.Columns.Contains("Mo_Ta_Kt"))
                        drEditCtNew["Thong_So_Kt"] = drSelect["Mo_Ta_Kt"];
                }
                if (drEditCtNew.Table.Columns.Contains("So_Ct_Org"))
                {
                    if (drSelect.Table.Columns.Contains("So_Ct"))
                        drEditCtNew["So_Ct_Org"] = drSelect["So_Ct"];
                }
                if ((string)drEditCt["Ma_Ct"] == "DNX")
                {
                    drEditCtNew["So_Luong_KtCdAt"] = 0;
                    drEditCtNew["So_Luong0"] = drSelect["So_Luong"];
                }

                if (frmInherit.txtMa_Ct.Text == "DNX" && drSelect.Table.Columns.Contains("Ma_Bp_Sd") && drEditCtNew.Table.Columns.Contains("Ma_Bp"))
                    drEditCtNew["Ma_Bp"] = drSelect["Ma_Bp_Sd"];

                if (drEditCtNew.Table.Columns.Contains("Tk_Co") && drSelect.Table.Columns.Contains("Tk_Co"))
                    drEditCtNew["Tk_Co"] = drSelect["Tk_Co"];
                
                
                if (drSelect.Table.Columns.Contains("So_Luong_Cl"))
                {
                    if(drEditCtNew.Table.Columns.Contains("So_Luong0"))
                        drEditCtNew["So_Luong0"] = drSelect["So_Luong_Cl"];
                    drEditCtNew["So_Luong9"] = drSelect["So_Luong_Cl"];
                    drEditCtNew["So_Luong"] = drSelect["So_Luong_Cl"];
                }
                if (drSelect.Table.Columns.Contains("Stt_PYC") && drEditCtNew.Table.Columns.Contains("Stt_PYC"))
                {
                    drEditCtNew["Stt_PYC"] = drSelect["Stt_PYC"];
                    drEditCtNew["Stt0_PYC"] = drSelect["Stt0_PYC"];
                }
                if (drSelect.Table.Columns.Contains("Ma_Dt_CbNv_Th") && drEditCtNew.Table.Columns.Contains("Ma_Dt_CbNv_Th"))
                    drEditCtNew["Ma_Dt_CbNv_Th"] = drSelect["Ma_Dt_CbNv_Th"];

                if (drSelect.Table.Columns.Contains("Ma_Tb") && drEditCtNew.Table.Columns.Contains("Ma_Tb"))
                    drEditCtNew["Ma_Tb"] = drSelect["Ma_Tb"];

                if ((string)drEditCt["Ma_Ct"] == "DTCP")
                {
                    drEditCtNew["Muc_Dich"] = drSelect["Noi_Dung"];
                    drEditCtNew["Ma_Vt"] = drSelect["Ma_Vt"];
                    //drEditCtNew["Muc_Dich"] = drSelect["Noi_Dung"];
                }
                if (drEditCtNew.Table.Columns.Contains("So_Luong_Can") && drSelect.Table.Columns.Contains("So_Luong_Can"))
                    drEditCtNew["So_Luong_Can"] = drSelect["So_Luong_Can"].ToString();

                if (drEditCtNew.Table.Columns.Contains("So_Luong_Barem") && drSelect.Table.Columns.Contains("So_Luong_Barem"))
                    drEditCtNew["So_Luong_Barem"] = drSelect["So_Luong_Barem"].ToString();

                if (drEditCtNew.Table.Columns.Contains("So_Luong_Bacode") && drSelect.Table.Columns.Contains("So_Luong_Bacode"))
                    drEditCtNew["So_Luong_Bacode"] = drSelect["So_Luong_Bacode"].ToString();

                if (drEditCtNew.Table.Columns.Contains("Ma_Kho") && drSelect.Table.Columns.Contains("Ma_Kho"))
                    drEditCtNew["Ma_Kho"] = drSelect["Ma_Kho"].ToString();

                if (drEditCtNew.Table.Columns.Contains("So_LXH_Goc") && drSelect.Table.Columns.Contains("So_LXH_Goc"))
                    drEditCtNew["So_LXH_Goc"] = drSelect["So_LXH_Goc"].ToString();

                if ((string)drEditCt["Ma_Ct"] == "LXH")
                {

                    // Danh so_ct LGH theo dinh dang So_Ct_SO_xxx xxx: so lan ke thua
                    string strMa_Ct = ((string)drEditPh["Ma_Ct"]).Trim();
                    DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Select("Chon = 1")[0];
                    DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
                    if ((string)drInheritVoucher["Ht_Gn"] == "GK")
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("MA_CT", frmEdit.drEdit["Ma_Ct"]);
                        ht.Add("NGAY_CT", GetDate_Server());

                        drEditPh["So_Ct"] = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSo_Ct_SO(@Ma_Ct, @Ngay_Ct)", ht, CommandType.Text);
                        Hashtable htPara = new Hashtable();
                        htPara.Add("TABLENAME", drDmCt["Table_Ph"].ToString());
                        htPara.Add("COLUMNNAME", "So_Ct");
                        htPara.Add("CURRENTID", drEditPh["So_Ct"].ToString());
                        htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + strMa_Ct + "'");
                        htPara.Add("PREFIXLEN", 1);
                        htPara.Add("SUFFIXLEN", 9);
                        drEditPh["So_Ct"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                    }
                    else
                    {
                        drEditPh["So_Ct"] = (string)drInheritVoucher["So_Ct"] + "_001";

                        Hashtable htPara = new Hashtable();
                        htPara.Add("TABLENAME", drDmCt["Table_Ph"].ToString());
                        htPara.Add("COLUMNNAME", "So_Ct");
                        htPara.Add("CURRENTID", drEditPh["So_Ct"].ToString());
                        htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + strMa_Ct + "'");
                        htPara.Add("PREFIXLEN", Convert.ToInt32(frmEdit.drDmCt["PrefixLen"]));
                        htPara.Add("SUFFIXLEN", Convert.ToInt32(frmEdit.drDmCt["SuffixLen"]));
                        drEditPh["So_Ct"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                    }
                    drEditCtNew["So_Ct"] = drEditPh["So_Ct"].ToString();
                    frmEdit.Controls["txtSo_Ct"].Text = drEditPh["So_Ct"].ToString();

                    //Lấy So_luòn làm số lượng tạm để so sánh khi sửa So_Luong9-- ko lớn hơn So_luong9 đc kế thừa
                    drEditCtNew["So_Luong_Bill"] = drSelect["So_Luong_CL"];
                    drEditCtNew["So_Luong"] = drEditCtNew["So_Luong9"] = drSelect["So_Luong_CL"];
                    drEditCtNew["So_Luong_Bo"] = drSelect["So_Luong_Bo_CL"];
                    drEditCtNew["So_Luong_Cay_Le"] = drSelect["So_Luong_Cay_Le_CL"];
                    drEditCtNew["He_So9"] = 1;

                }
                if ((string)drEditCt["Ma_Ct"] == "BBPT")
                {
                    if (Convert.ToDouble(drSelect["So_Luong_CL"]) > 10)
                        drEditCtNew["So_Lan_In"] = 10;
                    else
                        drEditCtNew["So_Lan_In"] = drSelect["So_Luong_CL"];
                }
                if ((string)drEditCt["Ma_Ct"] == "NM")
                {
                    if (drSelect.Table.Columns.Contains("Ghi_Chu_Dh"))
                        frmEdit.Controls["lbtNotice"].Text = drSelect["Ghi_Chu_Dh"].ToString();
                }
                drEditCtNew["Stt"] = frmEdit.strStt;
                drEditCtNew["Stt_Org"] = drSelect["Stt"];
                drEditCtNew["Stt0"] = iStt0.ToString();



                dtEditCt.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();


                //Hiển thị số phiếu đã được kế thừa
                if (frmEdit.Controls.ContainsKey("txtInherit"))
                {
                    string strInheritText = frmInherit.dtInheritVoucher.Rows[0]["Ma_Ct"].ToString() + ":" + frmInherit.dtInheritVoucher.Rows[0]["So_Ct"].ToString();

                    if (frmInherit.chkInheritOverwrite.Checked)
                    {
                        frmEdit.Controls["txtInherit"].Text = "";
                    }

                    if (!frmEdit.Controls["txtInherit"].Text.Contains(strInheritText))
                        frmEdit.Controls["txtInherit"].Text += strInheritText + ",";
                }
            }


            if (drEditPh.Table.Columns.Contains("So_LGH_List"))
            {
                drEditPh["So_LGH_List"] = strSo_LGH_List;
                drEditPh.AcceptChanges();

                Common.ScaterMemvar(frmEdit, ref drEditPh);
            }

        }

        //public static void InheritVoucher_SetData_Nhap_Barcode(frmInherit_Nhap_Barcode frmInherit, frmVoucher_Edit frmEdit)
        //{
        //    if (frmInherit.dtInheritVoucher.Select("Chon = true").Length == 0)
        //        return;

        //    DataRow drEditPh = frmEdit.drEditPh;
        //    DataTable dtEditCt = frmEdit.dtEditCt;
        //    DataRow drEditCt = dtEditCt.NewRow();

        //    Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);

        //    int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0"));

        //    if (frmInherit.dtInheritVoucher.Rows.Count > 0)
        //    {
        //        DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Select("Chon = 1")[0];
        //        //string strMa_Dt = drInheritVoucher["Ma_Dt"].ToString();

        //        Common.GatherMemvar(frmEdit, ref drEditPh);

        //        drEditPh["Ngay_Ct"] = (DateTime)drInheritVoucher["Ngay_Ct"];

        //        drEditPh.AcceptChanges();

        //        Common.ScaterMemvar(frmEdit, ref drEditPh);
        //    }

        //    foreach (DataRow drSelect in frmInherit.dtInheritVoucher.Select("Chon = true"))
        //    {
        //        iStt0 += 1;

        //        DataRow drEditCtNew = dtEditCt.NewRow();
        //        Common.CopyDataRow(drSelect, drEditCtNew);
        //        Common.SetDefaultDataRow(ref drEditCtNew);

        //        if ((string)frmEdit.drDmCt["Nh_Ct"] == "2" && drEditCtNew.Table.Columns.Contains("Auto_Cost"))
        //            drEditCtNew["Auto_Cost"] = true;

        //        drEditCtNew["Stt"] = frmEdit.strStt;
        //        drEditCtNew["Stt0"] = iStt0.ToString();

        //        dtEditCt.Rows.Add(drEditCtNew);
        //        drEditCtNew.AcceptChanges();
        //    }
        //}

        public static void Inherit_PNSB_SetData(frmInherit_PNSB frmInherit, frmVoucher_Edit frmEdit)
        {

            DataTable dtInherit = frmInherit.dtInheritVoucher;

            if (dtInherit.Select("Chon = true").Length == 0)
                return;


            DataRow drEditPh = frmEdit.drEditPh;
            DataTable dtEditCt = frmEdit.dtEditCt;
            DataRow drEditCt = dtEditCt.NewRow();

            Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);

            if (frmInherit.chkInheritOverwrite.Checked)
                dtEditCt.Rows.Clear();

            int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0"));

            foreach (DataRow drSelect in frmInherit.dtInheritVoucher.Select("Chon = true"))
            {
                iStt0 += 1;

                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);

                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drEditCtNew["Ma_Vt"]);
                drEditCtNew["Ten_Vt"] = drDmVt["Ten_Vt"];
                drEditCtNew["Dvt"] = drDmVt["Dvt"];

                drEditCtNew["Stt0"] = iStt0;
                drEditCtNew["So_Luong_Cay"] = drSelect["Sl_Ton"];
                drEditCtNew["So_Luong_Cl_Max"] = drSelect["Sl_Ton"];
                drEditCtNew["Phan_Loai_Phoi"] = drSelect["Phan_Loai_Phoi"];
                drEditCtNew["So_Luong9"] = drSelect["So_Luong"];
                drEditCtNew["Ma_Kho"] = drSelect["Ma_Kho"];



                if (dtEditCt.Columns.Contains("SL_Phoi_Nong_Oil"))
                    drEditCtNew["SL_Phoi_Nong_Oil"] = drSelect["SL_Phoi_Nong"];
                if (dtEditCt.Columns.Contains("SL_Phoi_TG_Oil"))
                    drEditCtNew["SL_Phoi_TG_Oil"] = drSelect["SL_Phoi_TG"];
                if (dtEditCt.Columns.Contains("SL_Phoi_Nguoi_Oil"))
                    drEditCtNew["SL_Phoi_Nguoi_Oil"] = drSelect["SL_Phoi_Nguoi"];
                if (dtEditCt.Columns.Contains("So_Luong_Oil"))
                    drEditCtNew["So_Luong_Oil"] = drSelect["So_Luong"];

                if (dtEditCt.Columns.Contains("So_Luong_TB_Nong"))
                    drEditCtNew["So_Luong_TB_Nong"] = drSelect["So_Luong_TB_Nong"];

                if (dtEditCt.Columns.Contains("So_Luong_TB_Nguoi"))
                    drEditCtNew["So_Luong_TB_Nguoi"] = drSelect["So_Luong_TB_Nguoi"];

                dtEditCt.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }

        }
        public static void Inherit_BarcodePH_SetData(frmInherit_PNSB frmInherit, frmVoucher_Edit frmEdit)
        {

            DataTable dtInherit = frmInherit.dtInheritVoucher;

            if (dtInherit.Select("Chon = true").Length == 0)
                return;


            DataRow drEditPh = frmEdit.drEditPh;
            DataTable dtEditCt = frmEdit.dtEditCt;
            DataRow drEditCt = dtEditCt.NewRow();

            Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);

            if (frmInherit.chkInheritOverwrite.Checked)
                dtEditCt.Rows.Clear();

            int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0"));

            foreach (DataRow drSelect in frmInherit.dtInheritVoucher.Select("Chon = true"))
            {
                iStt0 += 1;

                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);

                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drEditCtNew["Ma_Vt"]);
                drEditCtNew["Ten_Vt"] = drDmVt["Ten_Vt"];
                drEditCtNew["Dvt"] = drDmVt["Dvt"];
                drEditCtNew["Loai_Phoi"] = drDmVt["Loai_Phoi"];

                drEditCtNew["Stt0"] = iStt0;
                drEditCtNew["Is_Barcode"] = true;
                if (dtEditCt.Columns.Contains("SL_Phoi_Nong"))
                    drEditCtNew["SL_Phoi_Nong"] = drSelect["SL_Phoi_Nong"];
                if (dtEditCt.Columns.Contains("So_Luong_Nong"))
                    drEditCtNew["So_Luong_Nong"] = drSelect["So_Luong_Nong"];
                if (dtEditCt.Columns.Contains("So_Luong_TB_Nong"))
                    drEditCtNew["So_Luong_TB_Nong"] = drSelect["So_Luong_TB_Nong"];

                if (dtEditCt.Columns.Contains("So_Luong_TB_Nguoi"))
                    drEditCtNew["So_Luong_TB_Nguoi"] = drSelect["So_Luong_TB_Nguoi"];

                if (dtEditCt.Columns.Contains("Phan_Loai_Phoi"))
                    drEditCtNew["Phan_Loai_Phoi"] = drSelect["Phan_Loai_Phoi"];

                if (dtEditCt.Columns.Contains("Ma_Kho"))
                    drEditCtNew["Ma_Kho"] = drSelect["Ma_Kho"];


                dtEditCt.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }

        }
        public static void Inherit_Phoi_SetData(frmInherit_PNSB frmInherit, frmVoucher_Edit frmEdit)
        {

            DataTable dtInherit = frmInherit.dtInheritVoucher;

            if (dtInherit.Select("Chon = true").Length == 0)
                return;


            DataRow drEditPh = frmEdit.drEditPh;
            DataTable dtEditCt = frmEdit.dtEditCt;
            DataRow drEditCt = dtEditCt.NewRow();

            Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);

            if (frmInherit.chkInheritOverwrite.Checked)
                dtEditCt.Rows.Clear();

            int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0"));

            foreach (DataRow drSelect in frmInherit.dtInheritVoucher.Select("Chon = true"))
            {
                iStt0 += 1;

                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);

                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drEditCtNew["Ma_Vt"]);
                drEditCtNew["Ten_Vt"] = drDmVt["Ten_Vt"];
                drEditCtNew["Dvt"] = drDmVt["Dvt"];

                drEditCtNew["Stt0"] = iStt0;
                drEditCtNew["So_Luong"] = drEditCtNew["So_Luong9"] = drSelect["So_Luong"];

                dtEditCt.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }

        }

        public static void ImportExcel_Voucher()
        {
            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                if (Common.MsgYes_No("Bạn có chắc chắn import các chứng từ trên vào CSDL hay không?") == false)
                    return;

                if (frmImport.dtImport.Rows.Count == 0 || !frmImport.dtImport.Columns.Contains("Ma_Ct"))
                {
                    Common.MsgCancel("Dữ liệu không hợp lệ!");
                    return;
                }

                DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", frmImport.dtImport.Rows[0]["Ma_Ct"].ToString());

                SqlCommand sqlcom = SQLExec.GetSQLCommand();
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Clear();
                sqlcom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
                sqlcom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());

                SqlParameter para = new SqlParameter();
                para.ParameterName = "@TVP_Import";
                para.SqlDbType = SqlDbType.Structured;

                if (drDmCt["Table_Ct"].ToString().ToUpper() == "R01CTTIEN")
                {
                    para.TypeName = "ImportTVP_CtTien";
                    para.Value = Voucher.GetTVPValue("R01CtTien", "ImportTVP_CtTien", frmImport.dtImport);

                    sqlcom.Parameters.Add(para);

                    sqlcom.CommandText = "sp_ImportTVP_CtTien";
                }
                else if (drDmCt["Table_Ct"].ToString().ToUpper() == "R02CTNM")
                {
                    para.TypeName = "ImportTVP_CtNM";
                    para.Value = Voucher.GetTVPValue("R02CtNM", "ImportTVP_CtNM", frmImport.dtImport);

                    sqlcom.Parameters.Add(para);

                    sqlcom.CommandText = "sp_ImportTVP_CtNM";
                }
                else if (drDmCt["Table_Ct"].ToString().ToUpper() == "R04CTHD")
                {
                    para.TypeName = "ImportTVP_CtHD";
                    para.Value = Voucher.GetTVPValue("R04CtHD", "ImportTVP_CtHD", frmImport.dtImport);

                    sqlcom.Parameters.Add(para);

                    sqlcom.CommandText = "sp_ImportTVP_CtHD";
                }
                else if (drDmCt["Table_Ct"].ToString().ToUpper() == "R05CTNX")
                {
                    para.TypeName = "ImportTVP_CtNX";
                    para.Value = Voucher.GetTVPValue("R05CtNX", "ImportTVP_CtNX", frmImport.dtImport);

                    sqlcom.Parameters.Add(para);

                    sqlcom.CommandText = "sp_ImportTVP_CtNX";
                }
                else if (drDmCt["Table_Ct"].ToString().ToUpper() == "R80CTKT")
                {
                    para.TypeName = "ImportTVP_CtKT";
                    para.Value = Voucher.GetTVPValue("R80CtKT", "ImportTVP_CtKT", frmImport.dtImport);

                    sqlcom.Parameters.Add(para);

                    sqlcom.CommandText = "sp_ImportTVP_CtKT";
                }

                try
                {
                    sqlcom.ExecuteNonQuery();
                    Common.MsgOk(Languages.GetLanguage("END_PROCESS"));
                }
                catch (Exception ex)
                {
                    Common.MsgOk(ex.Message);
                }
            }
        }

        public static DateTime GetDate_Server() //trả về ngày 2023-11-27
        {
            return Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()"));
        }
        public static DateTime GetDateServer() // 2023-11-27 09:15:19.913
        {
            return Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetDateServer()"));
        }
        public static DateTime GetTimeServer()
        {
            return Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetTimeServer()"));
        }
        //Check Locked Barcode
        public static bool CheckDataLocked_Barcode(DateTime dteNgay_Ct)
        {
            Hashtable htCheckDataLocked = new Hashtable();
            htCheckDataLocked.Add("NGAY_CT", dteNgay_Ct);
            htCheckDataLocked.Add("MA_DVCS", Element.sysMa_DvCs);

            bool bCheckDataLocked = (bool)SQLExec.ExecuteReturnValue("sp_CheckDataLocked_Barcode", htCheckDataLocked, CommandType.StoredProcedure);

            return bCheckDataLocked;
        }

        //Check Locked Phoi NHỚ KHÓA ĐI
        public static bool CheckDataLocked_Phoi(DateTime dteNgay_Ct)
        {
            Hashtable htCheckDataLocked = new Hashtable();
            htCheckDataLocked.Add("NGAY_CT", dteNgay_Ct);
            htCheckDataLocked.Add("MA_DVCS", Element.sysMa_DvCs);

            bool bCheckDataLocked = (bool)SQLExec.ExecuteReturnValue("sp_CheckDataLocked_Phoi", htCheckDataLocked, CommandType.StoredProcedure);

            return bCheckDataLocked;
        }
        ////Check Inherit
        //public static bool CheckInherit(string strStt, string strTableName)
        //{
        //    bool bCheckInherit = false;
        //    double iCount = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM "+ strTableName +" WHERE Stt_Org = '" + strStt + "'"));

        //    if(iCount > 0 )
        //     bCheckInherit = true;

        //    return bCheckInherit;
        //}
        public static bool CheckInheritAllTable(string strStt)
        {
            bool bCheckInherit = false;

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            DataTable dtInherit = SQLExec.ExecuteReturnDt("dbo.sp_CheckSttOrgList", ht, CommandType.StoredProcedure);

            if (dtInherit.Rows.Count > 0)
                bCheckInherit = true;

            return bCheckInherit;
        }
        public static void LockMa_Vt_Inherit(rsDataGridView dgv, DataTable dtEdit, string strMa_Ct) // Kiểm tra dòng đã kế thừa thì khóa dữ trường mã vật tư
        {
            if (dgv.Columns.Contains("Ma_Vt") && dtEdit.Columns.Contains("Stt_Org") && !Common.Inlist(strMa_Ct, "DT,DNX"))
            {
                foreach (DataRow dr in dtEdit.Rows)
                {
                    if (dr["Stt_Org"].ToString() != "")
                        dgv.Columns["Ma_Vt"].ReadOnly = true;
                }
            }
            else if (dgv.Columns.Contains("Ma_Vt") && dtEdit.Columns.Contains("Stt_Org") && Common.Inlist(strMa_Ct, "DT"))
            {
                foreach (DataRow dr in dtEdit.Rows)
                {
                    if (dr["Stt_Org"].ToString() != "")
                        dgv.Columns["Ma_Vt_Tt"].ReadOnly = true;
                }
            }
        }

        public static bool Access_Price_Xuat(DataTable dtEditCt, string strMa_Ct, DataGridView dgvEditCt1)
        {
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
            if (DataTool.SQLCheckExist("R00Object", "Object_ID", "ACCESS_PRICE_PX") &&
                   (!Common.CheckPermission("ACCESS_PRICE_PX", enuPermission_Type.Allow_Access) && drDmCt["Vt_Kt"].ToString() == "V" && drDmCt["Nh_Ct"].ToString() == "2") ||
                   (!Common.CheckPermission("ACCESS_PRICE_PN", enuPermission_Type.Allow_Access) && Common.Inlist(drDmCt["Ma_Ct"].ToString(),"DT,NM") && drDmCt["Nh_Ct"].ToString() == "1"))
            {
                foreach (DataColumn dc in dtEditCt.Columns)
                {
                    if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TIEN"))
                    {
                        if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal) || dc.DataType == typeof(string))
                        {
                            //Gán cột dữ liệu về 0
                            //foreach (DataRow dr in dtEditCt.Rows)
                            //{
                            //    dr[dc] = 0;
                            //}

                            //Ẩn cột dữ liệu
                            if (dgvEditCt1.Columns.Contains(dc.ColumnName))
                                dgvEditCt1.Columns[dc.ColumnName].Visible = false;

                        }
                    }
                }
                if (dgvEditCt1.Columns.Contains("GIA_DCHINH"))
                    dgvEditCt1.Columns["GIA_DCHINH"].Visible = true;

                return false;
            }
            else if (DataTool.SQLCheckExist("R00Object", "Object_ID", "ACCESS_PRICE_PX") &&
                  Common.CheckPermission("ACCESS_PRICE_PX", enuPermission_Type.Allow_Access) && drDmCt["Vt_Kt"].ToString() == "V" && drDmCt["Nh_Ct"].ToString() == "2")
                return true;

            return false;
        }
        public static System.Data.DataTable ReadExcelToFrom(string strFilePath, int iSheetIndex, int iRowHeader, int iColEnd, int iFromRow, int iToRow)
        {
            if (System.IO.File.Exists(strFilePath))
            {
                Microsoft.Office.Interop.Excel.Application excelApp = null;
                Microsoft.Office.Interop.Excel.Workbook excelWB = null;
                Microsoft.Office.Interop.Excel.Worksheet excelWS = null;
                Microsoft.Office.Interop.Excel.Range excelRange = null;
                Object missing = System.Reflection.Missing.Value;

                try
                {
                    excelApp = new Microsoft.Office.Interop.Excel.Application();

                    //excelWB = excelApp.Workbooks.Open(txtFilePath.Text,
                    //            missing, missing, missing, missing, missing, missing, missing,
                    //            missing, missing, missing, missing, missing, missing, missing);

                    object UpdateLinks = 2,
                            ReadOnly = true,
                            Format = missing,
                            Password = missing,
                            WriteResPassword = missing,
                            IgnoreReadOnlyRecommended = true,
                            Origin = missing,
                            Delimiter = missing,
                            Editable = false,
                            Notify = false,
                            Converter = missing,
                            AddToMru = false,
                            Local = missing,
                            CorruptLoad = missing;

                    excelWB = excelApp.Workbooks.Open(strFilePath,
                                    UpdateLinks, ReadOnly, Format, Password, WriteResPassword, IgnoreReadOnlyRecommended, Origin,
                                    Delimiter, Editable, Notify, Converter, AddToMru, Local, CorruptLoad);



                    excelWS = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[iSheetIndex];

                    #region

                    #endregion
                    int iRowEnd = Convert.ToInt16(iToRow) - Convert.ToInt16(iFromRow) + 1;
                    //excelRange = excelWS.get_Range(excelApp.Cells[iRowHeader, 1], excelApp.Cells[iRowEnd, iColEnd]);
                    string strAddr1 = excelApp.Cells[iRowHeader, 1].Address;
                    string strAddr2 = excelApp.Cells[iRowEnd, iColEnd].Address;
                    excelRange = excelWS.get_Range(strAddr1, strAddr2);
                    System.Data.DataTable dtImport = new System.Data.DataTable();

                    //Tao cau truc bang
                    for (int i = 1; i <= iColEnd; i++)
                    {
                        //excelWS.Columns.GetType() == typeof(
                        string strColName = "Column" + i.ToString();

                        //if (excelWS.get_Range(excelApp.Cells[numRowHeader.Value, i], excelApp.Cells[numRowHeader.Value, i]).Value2 != null)
                        if (((Microsoft.Office.Interop.Excel.Range)excelRange[iRowHeader, i]).Value2 != null)
                        {
                            strColName = ((Microsoft.Office.Interop.Excel.Range)excelRange[iRowHeader, i]).Value2.ToString();
                        }

                        if (strColName.StartsWith("Ngay"))
                            dtImport.Columns.Add(strColName, typeof(DateTime));
                        else if (strColName.StartsWith("Tien") || strColName.StartsWith("Ps_No") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("So_Luong") || strColName.StartsWith("Gia"))
                            dtImport.Columns.Add(strColName, typeof(double));
                        else
                            dtImport.Columns.Add(strColName, typeof(string));
                    }

                    //Dua du lieu vao: Duyet dong
                    //for (int i = Convert.ToInt32(iRowHeader + 1); i <= iRowEnd; i++)
                    for (int i = Convert.ToInt32(iFromRow); i <= iToRow; i++)
                    {
                        bool bRowNull = true;
                        DataRow drNew = dtImport.NewRow();

                        //Duyet Cot
                        for (int j = 1; j <= iColEnd; j++)
                        {
                            //drNew[j-1] = excelWS.get_Range(excelApp.Cells[i, j], excelApp.Cells[i, j]).Value2; //Import tung Cell
                            if (((Microsoft.Office.Interop.Excel.Range)excelRange[i, j]).Value2 != null)
                            {
                                string strColName = drNew.Table.Columns[j - 1].ColumnName;

                                try
                                {
                                    if (strColName.StartsWith("Ngay"))
                                        //drNew[j - 1] = Convert.ToDateTime(((Microsoft.Office.Interop.Excel.Range)excelRange[i, j]).Value2);
                                        drNew[j - 1] = Convert.ToDateTime(((Microsoft.Office.Interop.Excel.Range)excelRange[i, j]).Cells.get_Value(Type.Missing)); //Hải đổi phương thức lấy dữ liệu từ Cell trên excel
                                    else if (strColName.StartsWith("Tien") || strColName.StartsWith("Ps_No") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("So_Luong") || strColName.StartsWith("Gia"))
                                        //drNew[j - 1] = Convert.ToDouble(((Microsoft.Office.Interop.Excel.Range)excelRange[i, j]).Value2);
                                        drNew[j - 1] = Convert.ToDouble(((Microsoft.Office.Interop.Excel.Range)excelRange[i, j]).Cells.get_Value(Type.Missing));
                                    else
                                        //drNew[j - 1] = ((Microsoft.Office.Interop.Excel.Range)excelRange[i, j]).Value2;
                                        drNew[j - 1] = ((Microsoft.Office.Interop.Excel.Range)excelRange[i, j]).Cells.get_Value(Type.Missing);

                                    bRowNull = false;
                                }
                                catch (Exception ex)
                                {
                                    Common.MsgCancel("Không nhận được dữ liệu [" + strColName + "] = " + ((Microsoft.Office.Interop.Excel.Range)excelRange[i, j]).Value2.ToString());
                                    continue;
                                }
                            }
                        }

                        if (!bRowNull)
                        {
                            Common.SetDefaultDataRow(ref drNew);
                            dtImport.Rows.Add(drNew);
                        }
                    }

                    // Cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelRange);
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWS);

                    excelWB.Close(Type.Missing, Type.Missing, Type.Missing);
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWB);

                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
                    //

                    return dtImport;
                }
                catch (Exception)
                {
                    return null;
                    throw;
                }
            }

            return null;
        }
        public static void CheckVTPTTD(DataTable dtEdit, ref DataTable dtCheck)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "Sp_CheckDataVTPTTD";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_CHECKVTTD";
            paraCt.Value = Voucher.GetTVPValue("R04CTPO", "TVP_CHECKVTTD", dtEdit);
            sqlCom.Parameters.Add(paraCt);

            SqlDataReader sqlReader = sqlCom.ExecuteReader();

            if (sqlReader.HasRows)
                dtCheck.Load(sqlReader);



        }
        public static void UpdataDKSuatAnNT(DataTable dtEdit, string strStt)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@STT", strStt);
            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
            
            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_DKSuatAn";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_CBNVTHEOCA";
            paraCt.Value = Voucher.GetTVPValue("R10DSCBNVTHEOCA", "TVP_CBNVTHEOCA", dtEdit);
            sqlCom.Parameters.Add(paraCt);

            try
            {
                sqlCom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.Clear();
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                
            }


        }
        public static bool Create_Auto_LXH(string strMa_Ct, string strStt)
        {
            DataTable dtDuyet_Ph;
            DataTable dtDuyet_Ct;
            //DataTable dtDuyet_Ct_KhoLe = new DataTable();
            BindingSource bdsDuyet_Ph = new BindingSource();
            BindingSource bdsDuyet = new BindingSource();

            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            Hashtable htPara = new Hashtable();
            htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
            htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
            htPara.Add("STT", strStt);
            htPara.Add("USER_LOGIN", Element.sysUser_Id);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", htPara, CommandType.StoredProcedure);

            dtDuyet_Ph = dsVoucher.Tables[0];
            dtDuyet_Ct = dsVoucher.Tables[1];
            //dtDuyet_Ct_KhoLe = dsVoucher.Tables[1].Select("Is_KhoLe = 1 AND So_Luong_Cay_Le <> 0");

            bdsDuyet_Ph.DataSource = dtDuyet_Ph;
            bdsDuyet.DataSource = dtDuyet_Ct;

            DataRow drDuyet_Ph = ((DataRowView)bdsDuyet_Ph.Current).Row;
            string strSo_Ct_LXH = string.Empty; //string strSo_Ct_LXH_KhoLe = string.Empty;

            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();
            //SqlConnection sqlCon_KhoLe = SQLExec.GetNewSQLConnection();
            //SqlCommand sqlCom_KhoLe = sqlCon.CreateCommand();

            // Xu ly khi duyệt SO tự động tạo LXH
            string strStt_LXH = string.Empty; //string strStt_LXH_KhoLe = string.Empty; double iNum_Bars = 0; 
            //string strMa_Vt = "";
            bool bDuyet_Tp = (bool)drDuyet_Ph["Duyet_TP"];
            bool bBocHang = false;// this.chkIs_Vt_Nhan.Checked;
            //Bổ sung nếu duyệt tự động thì tạo LXH
            int iAutoDuyetBH = Convert.ToInt16(SQLExec.ExecuteReturnValue("SELECT MAX(Type_Value) FROM R81DMTYPE WHERE Type_ID = 'ISDUYETHMBHAUTO'"));
            bool bDuyetKT = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet FROM R80PH WHERE Stt = '" + strStt + "' "));

            bool bAutoDuyet = false;

            if (bDuyetKT)
                bAutoDuyet = true;

            if (strMa_Ct == "SO" && bDuyet_Tp && (bBocHang || bAutoDuyet))
            {
                string strCreate_User = (string)drDuyet_Ph["Create_Log"];
                strStt_LXH = "A0104" + drDuyet_Ph["Create_Log"].ToString().Substring(0, 6) + "X" + drDuyet_Ph["So_Ct"].ToString().Substring(1, 3);
                strSo_Ct_LXH = (string)drDuyet_Ph["So_Ct"] + "_001";

                //xử lý hàng xuất kho lẻ
                //strStt_LXH = "A0104" + drDuyet_Ph["Create_Log"].ToString().Substring(0, 6) + "L" + drDuyet_Ph["So_Ct"].ToString().Substring(1, 3);
                //strSo_Ct_LXH = (string)drDuyet_Ph["So_Ct"] + "_002";

                //foreach(DataRow dr in dtDuyet_Ct.Rows)
                //{
                //    if ((bool)dr["Is_KhoLe"] && dr["Ma_Vt"].ToString().StartsWith("BD"))
                //    {
                //        strMa_Vt = dr["Ma_Vt"].ToString();
                //        dr["So_Luong_Cay_Le"] = 0;
                //        iNum_Bars = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Num_Bar", dr["Ma_Vt"].ToString()));
                //        dr["So_Luong_Cay"] = Convert.ToDouble(dr["So_Luong_Bo"]) * iNum_Bars;
                //        dr["So_Luong"] = dr["So_Luong"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremBo('"+ strMa_Vt +"',"+ dr["So_Luong_Cay"] + ",0)"));
                        
                //        DataRow drNew = dtDuyet_Ct_KhoLe.NewRow();
                //        Common.CopyDataRow(dr, drNew);
                //        dtDuyet_Ct_KhoLe.Rows.Add(drNew);

                //    }
                        
                //}
                //foreach (DataRow dr in dtDuyet_Ct_KhoLe.Rows)
                //{
                //    if ((bool)dr["Is_KhoLe"] && dr["Ma_Vt"].ToString().StartsWith("BD"))
                //    {
                //        strMa_Vt = dr["Ma_Vt"].ToString();
                //        dr["So_Luong_Bo"] = 0; dr["So_Luong_Cay"] = dr["So_Luong_Cay_Le"];
                //        dr["So_Luong"] = dr["So_Luong"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremBo('" + strMa_Vt + "',0," + dr["So_Luong_Cay_Le"] + ")"));

                //    }

                //}
                //Xử lý người tạo và time tạo LXH tự động
                string strCreate_Log = Common.GetCurrent_Log();
                string strUser = drDuyet_Ph["Create_Log"].ToString().Substring(14, drDuyet_Ph["Create_Log"].ToString().Length - 14);
                //lấy tên người tạo phiếu 110820:085438:YENNTN
                strCreate_Log = Common.GetCurrent_Log().Substring(0, 14) + strUser;

                drDuyet_Ph["Stt"] = strStt_LXH;
                drDuyet_Ph["So_Ct"] = strSo_Ct_LXH;
                drDuyet_Ph["Ma_Ct"] = "LXH";
                drDuyet_Ph["Duyet"] = false;
                drDuyet_Ph["Duyet_Log"] = "";
                drDuyet_Ph["Duyet_PKD"] = false;
                drDuyet_Ph["Duyet_Log_PKD"] = "";
                drDuyet_Ph["Duyet_TP"] = false;
                drDuyet_Ph["Print_Count"] = 0;
                drDuyet_Ph["Create_Log"] = strCreate_Log;
                drDuyet_Ph["LastModify_Log"] = "";
                drDuyet_Ph["USER_PRINT"] = 0;
                foreach (DataRow drCt in dtDuyet_Ct.Rows)
                {
                    if (drCt.RowState == DataRowState.Deleted)
                        continue;

                    drCt["Stt_Org"] = drCt["Stt"];
                    drCt["Stt0_Org"] = drCt["Stt0"];
                    drCt["Stt"] = strStt_LXH;
                    drCt["So_Ct"] = strSo_Ct_LXH;
                    drCt["Ma_Ct"] = "LXH";
                    drCt["Ma_NVu"] = "LXH01";

                }
                //foreach (DataRow drCt in dtDuyet_Ct_KhoLe.Rows)
                //{
                //    if (drCt.RowState == DataRowState.Deleted)
                //        continue;

                //    drCt["Stt_Org"] = drCt["Stt"];
                //    drCt["Stt0_Org"] = drCt["Stt0"];
                //    drCt["Stt"] = strStt_LXH;
                //    drCt["So_Ct"] = strSo_Ct_LXH;
                //    drCt["Ma_Ct"] = "LXH";
                //    drCt["Ma_NVu"] = "LXH01";
                //    drCt["Ma_Kho"] = "052TMN";
                //}

                dtDuyet_Ph.AcceptChanges();
                dtDuyet_Ct.AcceptChanges();
                //dtDuyet_Ct_KhoLe.AcceptChanges();

                sqlCom.CommandText = "sp_Update_Ct";
                sqlCom.CommandType = CommandType.StoredProcedure;

                //kho 04tp lần 1
                sqlCom.Parameters.Clear();

                if (DataTool.SQLCheckExist("R80PH", "Stt", strStt_LXH))
                    sqlCom.Parameters.AddWithValue("@strNew_Edit", "E");
                else
                    sqlCom.Parameters.AddWithValue("@strNew_Edit", "N");

                sqlCom.Parameters.AddWithValue("@Stt", strStt_LXH);
                sqlCom.Parameters.AddWithValue("@Ma_Ct", "LXH");
                sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

                sqlCom.CommandText = "sp_Update_CtSO";

                SqlParameter paraPH = new SqlParameter();
                paraPH.SqlDbType = SqlDbType.Structured;
                paraPH.ParameterName = "@PH";

                SqlParameter paraCt = new SqlParameter();
                paraCt.SqlDbType = SqlDbType.Structured;
                paraCt.ParameterName = "@Ct";

                //TVP_PH
                paraPH.TypeName = "TVP_PHSO";
                paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHSO", dtDuyet_Ph);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CtSO";
                paraCt.Value = Voucher.GetTVPValue("R04CtSO", "TVP_CtSO", dtDuyet_Ct);
                sqlCom.Parameters.Add(paraCt);

                try
                {
                    sqlCom.ExecuteNonQuery();


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
                ////kho lẻ lần 2
                //if(dtDuyet_Ct_KhoLe.Rows.Count>0)
                //{
                //    sqlCom_KhoLe.Parameters.Clear();

                //    if (DataTool.SQLCheckExist("R80PH", "Stt", strStt_LXH_KhoLe))
                //        sqlCom_KhoLe.Parameters.AddWithValue("@strNew_Edit", "E");
                //    else
                //        sqlCom_KhoLe.Parameters.AddWithValue("@strNew_Edit", "N");

                //    sqlCom_KhoLe.Parameters.AddWithValue("@Stt", strStt_LXH_KhoLe);
                //    sqlCom_KhoLe.Parameters.AddWithValue("@Ma_Ct", "LXH");
                //    sqlCom_KhoLe.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

                //    sqlCom_KhoLe.CommandText = "sp_Update_CtSO";

                //    SqlParameter paraPH_KhoLe = new SqlParameter();
                //    paraPH_KhoLe.SqlDbType = SqlDbType.Structured;
                //    paraPH_KhoLe.ParameterName = "@PH";

                //    SqlParameter paraCt_KhoLe = new SqlParameter();
                //    paraCt_KhoLe.SqlDbType = SqlDbType.Structured;
                //    paraCt_KhoLe.ParameterName = "@Ct";

                //    //TVP_PH
                //    paraPH_KhoLe.TypeName = "TVP_PHSO";
                //    paraPH_KhoLe.Value = Voucher.GetTVPValue("R80PH", "TVP_PHSO", dtDuyet_Ph);
                //    sqlCom_KhoLe.Parameters.Add(paraPH_KhoLe);

                //    //Tạo Table cho TVP_CtSO
                //    paraCt_KhoLe.TypeName = "TVP_CtSO";
                //    paraCt_KhoLe.Value = Voucher.GetTVPValue("R04CtSO", "TVP_CtSO", dtDuyet_Ct_KhoLe);
                //    sqlCom_KhoLe.Parameters.Add(paraCt_KhoLe);

                //    try
                //    {
                //        sqlCom_KhoLe.ExecuteNonQuery();


                //    }
                //    catch (Exception ex)
                //    {
                //        sqlCom_KhoLe.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                //        sqlCom_KhoLe.CommandType = CommandType.Text;
                //        sqlCom_KhoLe.Parameters.Clear();
                //        sqlCom_KhoLe.ExecuteNonQuery();

                //        MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                //        return false;
                //    }

                //}
            }
            else if (strMa_Ct == "SO" && ((bDuyet_Tp && bBocHang) || (bDuyet_Tp && !bBocHang) || (!bDuyet_Tp && !bBocHang)))
            {
                strStt_LXH = "A0104" + drDuyet_Ph["Create_Log"].ToString().Substring(0, 6) + "X" + drDuyet_Ph["So_Ct"].ToString().Substring(1, 3);
                SQLExec.Execute("DELETE FROM R04CTSO WHERE STT = '" + strStt_LXH + "'");
                SQLExec.Execute("DELETE FROM R80PH WHERE STT = '" + strStt_LXH + "'");

                //strStt_LXH_KhoLe = "A0104" + drDuyet_Ph["Create_Log"].ToString().Substring(0, 6) + "L" + drDuyet_Ph["So_Ct"].ToString().Substring(1, 3);
                //SQLExec.Execute("DELETE FROM R04CTSO WHERE STT = '" + strStt_LXH_KhoLe + "'");
                //SQLExec.Execute("DELETE FROM R80PH WHERE STT = '" + strStt_LXH_KhoLe + "'");
            }
            return true;
        }
        public static bool CheckTenDtGtGT(frmVoucher_Edit frmEdit)
        {
            string strMa_Dt = frmEdit.drEditPh["Ma_Dt"].ToString();
            if (strMa_Dt != "" && !Common.InlistLike(strMa_Dt, "M") && !Common.InlistLike(strMa_Dt, "1000043") && !frmEdit.dtEditCt.Columns.Contains("Ma_Dt_Hq"))
            {
                if (frmEdit.dtEditCt.Rows[0]["Ma_Dt_Hq"].ToString() != string.Empty)
                {
                    DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", strMa_Dt);

                    string strTen_DtGtGt = drDmDt["Ten_Dt"].ToString();
                    string strMa_So_Thue = drDmDt["Ma_So_Thue"].ToString();

                    foreach (DataRow dr in frmEdit.dtEditCt.Rows)
                    {
                        if ((dr["Ten_DtGtGt"].ToString() != strTen_DtGtGt && dr["Ten_DtGtGt"].ToString() != string.Empty) || (dr["Ma_So_Thue"].ToString() != strMa_So_Thue && dr["Ma_So_Thue"].ToString() != string.Empty))
                            return false;

                    }
                }
            }
            return true;
        }
        public static DateTime GetFirstDayOfMonth(DateTime dtInput) // ngày đầu tháng
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        public static DateTime GetLastDayOfMonth(DateTime dtInput) // ngày cuối tháng
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        public static DateTime GetLastDayOfMonth(int iYear, int iMonth) //lay ngay cuoi cua thang
        {
            DateTime dtResult = new DateTime(iYear, iMonth, 1);
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        public static DateTime GetLastDayOfMonthBefore(int iYear, int iMonth)   //lay ngay cuoi cua thang trước
        {
            DateTime dtResult = new DateTime(iYear, iMonth, 1);
            //dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        public static DataTable GetLoaiCC()
        {
            DataTable dtLoaiCC = SQLExec.ExecuteReturnDt("SELECT 'HC' AS Loai_CC, N'Hành chính' AS Ten_CC" +
                        " UNION ALL SELECT 'HCS' AS Loai_CC, N'HC Sáng' AS Ten_CC UNION ALL SELECT 'HCC', N'HC Chiều' AS Ten_CC " +
                        " UNION ALL SELECT 'C1_1' AS Loai_CC, N'C1 (làm 12 nghỉ 12 ngày)' AS Ten_CC UNION ALL SELECT 'C2_1', N'C2 (làm 12 nghỉ 12 đêm)' AS Ten_CC " +
                        " UNION ALL SELECT 'C1_2' AS Loai_CC, N'C1 (làm 12 nghỉ 12 ngày 11h - 23h)' AS Ten_CC" +
                        " UNION ALL SELECT 'CAA' AS Loai_CC, 'Ca A' AS Ten_CC UNION ALL SELECT 'CAB', 'Ca B' AS Ten_CC UNION ALL SELECT 'CAC' , 'Ca C' AS Ten_CC");

            return dtLoaiCC;
        }
        public static DataTable GetLoaiCC(string strNghi)
        {
            DataTable dtLoaiCC = SQLExec.ExecuteReturnDt("SELECT 'HC' AS Loai_CC, N'Hành chính' AS Ten_CC" +
                        " UNION ALL SELECT 'HCS' AS Loai_CC, N'HC Sáng' AS Ten_CC UNION ALL SELECT 'HCC', N'HC Chiều' AS Ten_CC " +
                        " UNION ALL SELECT 'C1_1' AS Loai_CC, N'C1 (làm 12 nghỉ 12 ngày)' AS Ten_CC UNION ALL SELECT 'C2_1', N'C2 (làm 12 nghỉ 12 đêm)' AS Ten_CC " +
                        " UNION ALL SELECT 'C1_2' AS Loai_CC, N'C1 (làm 12 nghỉ 12 ngày 11h - 23h)' AS Ten_CC" +
                        " UNION ALL SELECT 'CAA' AS Loai_CC, 'Ca A' AS Ten_CC UNION ALL SELECT 'CAB', 'Ca B' AS Ten_CC UNION ALL SELECT 'CAC' , 'Ca C' AS Ten_CC" +
                        " UNION ALL SELECT 'N' AS Loai_CC, N'Nghỉ do nhu cầu công việc' AS Ten_CC");

            return dtLoaiCC;
        }
        public static DataTable GetLoaiCCNT()
        {
            DataTable dtLoaiCC = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMCANT");

            return dtLoaiCC;
        }
        public static DataTable GetTinhTrangCong()
        {
            DataTable dtLoaiCC = SQLExec.ExecuteReturnDt("SELECT Ma_CC, Ten_CC FROM R81DmTTCCong");

            return dtLoaiCC;
        }
        public static bool LockCongLuong(string strLock, int iNam, int iThang, DateTime dtTu_Ngay, DateTime dtDen_Ngay)
        {
            bool bLock = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT " + strLock + " FROM R00LOCKEDLUONG WHERE NAM = " + iNam + " AND Thang = " + iThang + ""));
            if(bLock && strLock == "Lock_Cong")
            {
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT1", dtTu_Ngay);
                ht.Add("NGAY_CT2", dtDen_Ngay);
                bLock = Convert.ToBoolean(SQLExec.ExecuteReturnValue("dbo.sp_CheckDataLocked_CongLuong",ht,CommandType.StoredProcedure));
            }
            if (bLock)
                return true;
            else
                return false;

        }
        
        public static bool Check_User_Server(frmVoucher_Edit frmEditCt, string strNam, string strSo_Ct, string strMa_Ct)
        {
            string strPath = string.Empty;
            string strFileName = string.Empty;

            //Xác định đường dẫn tại server
            strPath = Parameters.GetParaValue("PATH_CTPO").ToString();
            //ma_ct
            strPath = Path.Combine(strPath, strMa_Ct);
            //năm
            strPath = Path.Combine(strPath, strNam);
            //số ct
            strPath = Path.Combine(strPath, strSo_Ct.Substring(0, 11));
            try
            {
                //gán server
                strPath = "\\\\" + Tool.GetIPServer() + strPath;
                //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
                if (!Directory.Exists(strPath))
                    System.IO.Directory.CreateDirectory(strPath);
                return true;
            }
            catch (Exception ex)
            {
                if (Common.InlistLike(ex.Message, "The user name or password is incorrect."))
                {
                    Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\192.168.1.18 để đính kèm file, sau đó đính kèm lại file!!!");
                    System.Diagnostics.Process.Start("explorer.exe", @"\\192.168.1.18");

                }
                return false;
            }
        }
        public static bool Open_File_Dm(string strPathFile)
        {
            string strPath = "\\\\" + Tool.GetIPServer() + strPathFile;
         
            if (strPath != null)
            {
                FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);

                fileStream.Close();
                System.Diagnostics.Process.Start(strPath);
            }


            return true;
        }
        public static bool Delete_File_Dm( string strPathFile)
        {
           string strPath = "\\\\" + Tool.GetIPServer() + strPathFile;
            
            if(File.Exists(strPath))
                File.Delete(strPath);

            return true;
        }
        public static bool Attach_File_Dm(string strPathServer, string strMa, string strPathFile, object objFile)
        {
            string strPath = string.Empty;
            string strFileName = string.Empty;

            //Xác định đường dẫn tại server
            strPath = Parameters.GetParaValue(strPathServer).ToString();
            //gán server
            strPath = "\\\\" + Tool.GetIPServer() + strPath;
            //mã
            strPath = Path.Combine(strPath, strMa);

            if (objFile != null)
            { 
                //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
                if (!Directory.Exists(strPath))
                    System.IO.Directory.CreateDirectory(strPath);

                //COPY FILE VÀO SERVER
                if(File.Exists(Path.Combine(strPath, Path.GetFileNameWithoutExtension(strPathFile) + Path.GetExtension(strPathFile))))
                {
                    File.Delete(Path.Combine(strPath, Path.GetFileNameWithoutExtension(strPathFile) + Path.GetExtension(strPathFile)));
                    File.Copy(strPathFile, Path.Combine(strPath, Path.GetFileNameWithoutExtension(strPathFile) + Path.GetExtension(strPathFile)));
                }
            }
            return true;
        }
        public static bool Attach_File(frmVoucher_Edit frmEditCt, DataTable dtReSource, string strNam, string strSo_Ct, string strMa_Ct)
        {
            string strPath = string.Empty;
            string strFileName = string.Empty;

            //Xác định đường dẫn tại server
            strPath = Parameters.GetParaValue("PATH_CTPO").ToString();
            //ma_ct
            strPath = Path.Combine(strPath, strMa_Ct);
            //năm
            strPath = Path.Combine(strPath, strNam);
            //số ct
            strPath = Path.Combine(strPath, strSo_Ct.Substring(0, 11));
            try
            {
                //gán server
                strPath = "\\\\" + Tool.GetIPServer() + strPath;

                //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
                if (!Directory.Exists(strPath))
                    System.IO.Directory.CreateDirectory(strPath);

                Copy_Save_File(dtReSource, "File_Path_New", strPath, frmEditCt.strStt);

            }
            catch (Exception ex)
            {
                if (Common.InlistLike(ex.Message, "The user name or password is incorrect."))
                {
                    Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\192.168.1.18 để đính kèm file, sau đó đính kèm lại file!!!");
                    System.Diagnostics.Process.Start("explorer.exe", @"\\192.168.1.18");

                }
            }
            return true;
        }
        public static void Copy_Save_File(DataTable dtReSource, string strColumn, string strPath, string strStt)
        {
            string strFileName = string.Empty;
            //object objFile;
            string strCreate_Log = "";
            string strLastModify_Log = "";
            string strPathSave = "";
            string strSQLExec = "";
            foreach (DataRow dr in dtReSource.Select("" + strColumn + " <> ''"))
            {


                strFileName = dr[strColumn].ToString();
                strPathSave = Path.Combine(strPath, dr["File_Path"].ToString());



                if (!File.Exists(strPathSave))
                {
                    try
                    {
                        File.Copy(dr[strColumn].ToString(), strPathSave);
                        //lƯU ĐƯỜNG DẪN FILE
                        strPathSave = strPathSave.Replace("\\\\" + Tool.GetIPServer(), "");
                        Hashtable htPara = new Hashtable();
                        htPara.Add("STT", strStt);
                        htPara.Add("STT0", dr["Stt0"]);
                        htPara.Add("FILE_NAME", dr["File_Name"]);
                        htPara.Add("FILE_PATH", strPathSave);
                        htPara.Add("TAG", dr["Tag"]);
                        //htPara.Add("IMAGE", dr["Image"]);
                        htPara.Add("IS_BIENBAN", false);

                        strCreate_Log = Common.GetCurrent_Log();
                        htPara.Add("CREATE_LOG", strCreate_Log);
                        htPara.Add("LASTMODIFY_LOG", strLastModify_Log);


                        strSQLExec = @"INSERT INTO R04CTSO_Resource(Stt, Stt0, File_Name, Tag, Is_BienBan, Create_Log,LastModify_Log, File_Path) "+ 
                                "VALUES(@Stt, @Stt0, @File_Name, @Tag, @Is_BienBan, @Create_Log, @LastModify_Log, @File_Path)";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        if (Common.InlistLike(ex.Message, "The user name or password is incorrect."))
                        {
                            Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\192.168.1.18 để mở file");
                            System.Diagnostics.Process.Start("explorer.exe", @"\\192.168.1.18");
                        }
                    }
                }

                else
                    Common.MsgOk("Có lỗi xảy ra với file attach. Vui lòng liên lạc PCNTT để kiểm tra!!!");
            }
        }
        public static void DuyetCt(string strTable_Name, string strStt, DataRow drCt, string strColS, string strColE, string strColE_Log, rsDataGridView dgvViewPh)
        {
            bool bDuyetS = false; bool bDuyetE = false;
            if (strColS != "")
                bDuyetS = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select " + strColS + " FROM " + strTable_Name + " WHERE Stt = '" + strStt + "'"));
            else
                bDuyetS = true;

            bDuyetE = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select " + strColE + " FROM " + strTable_Name + " WHERE Stt = '" + strStt + "'"));
            //nếu chưa duyệt phía trước thì không làm gì
            if (!bDuyetS)
                return;

            string strCreate_User = Convert.ToString(SQLExec.ExecuteReturnValue("Select Create_Log FROM " + strTable_Name + " WHERE Stt = '" + strStt + "'"));
            string strUser_Allow = string.Empty;
            string strUser_Group = string.Empty;


            if (strCreate_User != string.Empty)
            {
                strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                strUser_Group = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + Element.sysUser_Id + "')") + "";
            }
            if (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
            {
                //hiển thị form duyệt
                frmDuyetYeuCau frm = new frmDuyetYeuCau();
                frm.Load(drCt, bDuyetE, strColE);

                if (frm.Is_Accept)
                {
                    dgvViewPh.Columns[strColE].ReadOnly = false;
                    drCt[strColE] = frm.chkDuyet.Checked;

                    string strSQLExec = string.Empty;
                    Hashtable htPara = new Hashtable();
                    htPara.Add("DUYET", (bool)drCt[strColE]);
                    htPara.Add("STT", strStt);
                    htPara.Add("DUYET_LOG", Common.GetCurrent_Log());


                    strSQLExec = "UPDATE " + strTable_Name + " SET " + strColE + " = @DUYET, " + strColE_Log + "_LOG = @DUYET_LOG WHERE STT = @STT";
                    SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                }

            }
        }
        public static void DuyetCtBTTB(string strTable_Name, string strStt, DataRow drCt, string strColS, string strColE, string strColE_Log, rsDataGridView dgvViewPh)
        {
            bool bDuyetS = false; bool bDuyetE = false;
            if (strColS != "")
                bDuyetS = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select " + strColS + " FROM " + strTable_Name + " WHERE Stt = '" + strStt + "'"));
            else
                bDuyetS = true;

            bDuyetE = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select " + strColE + " FROM " + strTable_Name + " WHERE Stt = '" + strStt + "'"));
            //nếu chưa duyệt phía trước thì không làm gì
            if (!bDuyetS)
                return;

            string strCreate_User = Convert.ToString(SQLExec.ExecuteReturnValue("Select Create_Log FROM " + strTable_Name + " WHERE Stt = '" + strStt + "'"));
            string strUser_Allow = string.Empty;
            string strUser_Group = string.Empty;


            if (strCreate_User != string.Empty)
            {
                strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                strUser_Group = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + Element.sysUser_Id + "')") + "";
            }
            if (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
            {
                //hiển thị form duyệt
                frmDuyetQLMMTB frm = new frmDuyetQLMMTB();
                frm.Load(drCt, bDuyetE, strColE);

                if (frm.Is_Accept)
                {
                    dgvViewPh.Columns[strColE].ReadOnly = false;
                    drCt[strColE] = frm.chkDuyet.Checked;

                    string strSQLExec = string.Empty;
                    Hashtable htPara = new Hashtable();
                    htPara.Add("DUYET", (bool)drCt[strColE]);
                    htPara.Add("STT", strStt);
                    htPara.Add("DUYET_LOG", Common.GetCurrent_Log());

                    strSQLExec = "UPDATE " + strTable_Name + " SET " + strColE + " = @DUYET, " + strColE_Log + "_LOG = @DUYET_LOG WHERE STT = @STT";


                    SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                }

            }
        }
        public static void DuyetNghiemThu(string strTable_Name, string strMa_Vt_Sp, DateTime dteNgayCt, string strCaSx, string strColS, string strColE, bool chkDuyet, string strColLog)
        {
            bool bDuyetS = false;

            if (strColS != string.Empty || strColS != "")
                bDuyetS = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select " + strColS + " FROM " + strTable_Name + " WHERE Ma_Vt_Sp = '" + strMa_Vt_Sp + "' AND Ngay_Ct = '" + Library.DateToStr(dteNgayCt) + "' AND Ca_Sx LIKE '%" + strCaSx + "%'"));

            bool bDuyetE = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select " + strColE + " FROM " + strTable_Name + " WHERE Ma_Vt_Sp = '" + strMa_Vt_Sp + "' AND Ngay_Ct = '" + Library.DateToStr(dteNgayCt) + "' AND Ca_Sx LIKE '%" + strCaSx + "%'"));

            //nếu chưa duyệt phía trước thì không làm gì
            if (!bDuyetS && strColS != string.Empty)
            {
                Common.MsgOk("Phiếu chưa được duyệt bởi " + strColS + "");
                return;
            }
            string strSQLExec = string.Empty;
            Hashtable htPara = new Hashtable();

            htPara.Add("DUYET", chkDuyet);
            htPara.Add("DUYET_LOG", Common.GetCurrent_Log());
            htPara.Add("MA_VT_SP", strMa_Vt_Sp);
            htPara.Add("NGAY_CT", dteNgayCt);


            strSQLExec = "UPDATE " + strTable_Name + " SET " + strColE + " = @DUYET, " + strColLog + " = @DUYET_LOG WHERE  Ma_Vt_Sp = @Ma_Vt_Sp AND Ngay_Ct = @Ngay_Ct AND Ca_Sx LIKE '%" + strCaSx + "%'";
            SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
        }
        public static void CreateFilePDF(string strPath, string strFileName, DataTable dtHeader, DataTable dtDetail, string strReport_File, string strTable_Name, string strStt_List)
        {
            bool Allow_Backup = true;

            string strPath_Export_Temp = string.Empty;
            string strPath_Export = string.Empty;
            string strSqlExec = string.Empty;
            bool bShowDialog = false;
            bool bPrint = false;
            bool bPreview = false;

            if (!Directory.Exists(strPath))
                System.IO.Directory.CreateDirectory(strPath);

            if (!Directory.Exists(strPath))
            {
                try { Directory.CreateDirectory(strPath); }
                catch { Common.MsgCancel("Đường dẫn này không tồn tại, Vui lòng kiểm tra lại trước khi xuất giấy CNXX điện tử"); Allow_Backup = false; }
            }

            if (File.Exists(Path.Combine(strPath, strFileName + ".pdf")))
                File.Delete(Path.Combine(strPath, strFileName + ".pdf"));

            if (Allow_Backup)
            {

                //Tạo từng HDDT

                int iVersion = 0;

                strPath_Export_Temp = Path.Combine(strPath, strFileName + ".pdf");
                if (!File.Exists(strPath_Export_Temp))
                {
                    
                    strPath_Export = strPath_Export_Temp;
                    if (strTable_Name != "" && strStt_List != "")
                    {
                        Hashtable ht = new Hashtable();

                        ht.Add("STT", strStt_List);
                        ht.Add("NGUOI_TAO", Common.GetCurrent_Log());
                        strSqlExec = "UPDATE " + strTable_Name + " SET CNXXNguoiTao = @Nguoi_Tao WHERE Stt IN (Select String FROM dbo.fn_Split(@Stt))";
                        SQLExec.Execute(strSqlExec, ht, CommandType.Text);

                    }


                    RosyReportTMN.frmReportPrint frmPrint = new RosyReportTMN.frmReportPrint();
                    frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export, bPrint);

                    Common.ShowStatus(Languages.GetLanguage("In_Process") + " tạo giấy CNXX");
                }


            }

        }
        public static void OpenOutLook(string strEmail, string strSub, string strBody, string strPathZipFile, string strMa_So_Thue, bool bAuto)
        {
            try
            {

                int iE; string strEmail_List;
                List<string> lstAllRecipients = new List<string>();
                if (strEmail.Contains(";"))
                {
                    strEmail_List = strEmail;
                    while (strEmail_List.Length > 0)
                    {
                        if (strEmail_List.Contains(";"))
                        {
                            iE = strEmail_List.IndexOf(";");
                            strEmail = strEmail_List.Substring(0, iE);
                            strEmail_List = strEmail_List.Replace(strEmail + ";", "");
                        }
                        else
                        {
                            strEmail = strEmail_List.Substring(0, strEmail_List.Length);
                            strEmail_List = strEmail_List.Replace(strEmail, "");
                        }
                        lstAllRecipients.Add(strEmail);
                    }
                }
                else
                    lstAllRecipients.Add(strEmail);
                //lstAllRecipients.Add("cuongpn@thepmiennam.com.vn");

                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;

                // Recipient
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                foreach (String recipient in lstAllRecipients)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }

                //Add CC
                //Outlook.Recipient oCCRecip = oRecips.Add("THIYAGARAJAN.DURAIRAJAN@testmail.com");
                //oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                //oCCRecip.Resolve();

                //Add Subject
                oMailItem.Subject = strSub;

                // body, bcc etc...
                oMailItem.Body = strBody;
                //attach file nén
                string[] fileList = Directory.GetFiles(strPathZipFile, strMa_So_Thue + "*.zip");


                foreach (string filename in fileList)
                    oMailItem.Attachments.Add(filename);
                if (bAuto)
                {
                    //Display the mailbox
                    oMailItem.Display(false);
                    oMailItem.Send();
                }
                else
                    oMailItem.Display(true);
                //if (oMailItem.Send())
                //{
                MoveFile_CNXX(strPathZipFile, strMa_So_Thue);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        public static string CreateTableOutLook(string strBody, DataTable dtInfo, DataTable dtInfoCt)
        {
            if (dtInfo.Rows.Count == 0)
                return "";

            string strTH = "1. Tổng hợp:";
            string strCT = "2. Chi tiết:";
            string messageBody = "<font>"+ strBody + ": </font><br><br>";

      
            string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
            string htmlTableEnd = "</table>";
            string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
            string htmlHeaderRowEnd = "</tr>";
            string htmlTrStart = "<tr style =\"color:#555555;\">";
            string htmlTrEnd = "</tr>";
            string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
            string htmlTdEnd = "</td>";
            //bắt đầu tổng hợp
            messageBody += "<font>" + strTH + " </font><br><br>";
            messageBody += htmlTableStart;
            messageBody += htmlHeaderRowStart;
            foreach (DataColumn Column in dtInfo.Columns)
            {
                messageBody += htmlTdStart + Column.ColumnName + htmlTdEnd;
            }
            //cột cuối của Header 
            messageBody += htmlHeaderRowEnd;
            //add dòng
          
            foreach (DataRow Row in dtInfo.Rows)
            {
                messageBody = messageBody + htmlTrStart;
                foreach (DataColumn Column in dtInfo.Columns)
                    messageBody += htmlTdStart + Row[Column] + htmlTdEnd;    
            }
            messageBody = messageBody + htmlTrEnd;
            //cột cuối của Table
            messageBody = messageBody + htmlTableEnd;
            //xong tổng hợp



            //bắt đầu chi tiết
            messageBody += "<font>" + strCT + " </font><br><br>";
            messageBody += htmlTableStart;
            messageBody += htmlHeaderRowStart;
            foreach (DataColumn Column in dtInfoCt.Columns)
            {
                messageBody += htmlTdStart + Column.ColumnName + htmlTdEnd;
            }
            //cột cuối của Header 
            messageBody += htmlHeaderRowEnd;
            //add dòng

            foreach (DataRow Row in dtInfoCt.Rows)
            {
                messageBody = messageBody + htmlTrStart;
                foreach (DataColumn Column in dtInfoCt.Columns)
                    messageBody += htmlTdStart + Row[Column] + htmlTdEnd;
            }
            messageBody = messageBody + htmlTrEnd;
            //cột cuối của Table
            messageBody = messageBody + htmlTableEnd;
            //xong chi tiết
            return messageBody;
        }


        public static void OpenOutLook_ReminderDuyet(string strEmail, string strSub, string strBody, DataTable data_table, DataTable data_tableCt, bool bAuto)
        {
            try
            {
                int iE; string strEmail_List;
                List<string> lstAllRecipients = new List<string>();
                if (strEmail.Contains(";"))
                {
                    strEmail_List = strEmail;
                    while (strEmail_List.Length > 0)
                    {
                        if (strEmail_List.Contains(";"))
                        {
                            iE = strEmail_List.IndexOf(";");
                            strEmail = strEmail_List.Substring(0, iE);
                            strEmail_List = strEmail_List.Replace(strEmail + ";", "");
                        }
                        else
                        {
                            strEmail = strEmail_List.Substring(0, strEmail_List.Length);
                            strEmail_List = strEmail_List.Replace(strEmail, "");
                        }
                        lstAllRecipients.Add(strEmail);
                    }
                }
                else
                    lstAllRecipients.Add(strEmail);
                
                //lstAllRecipients.Add("cuongpn@thepmiennam.com.vn");

                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;

                // Recipient
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                foreach (String recipient in lstAllRecipients)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }
                //Add CC
                //Outlook.Recipient oCCRecip = oRecips.Add("THIYAGARAJAN.DURAIRAJAN@testmail.com");
                //oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                //oCCRecip.Resolve();

                //Add Subject
                oMailItem.Subject = strSub;

                // body, bcc etc...

                //
                //
                //oMailItem.Body = // textBody; //strBody +
                oMailItem.HTMLBody = CreateTableOutLook(strBody, data_table, data_tableCt);
                //
                if (bAuto)
                {
                    //Display the mailbox
                    oMailItem.Display(false);
                    
                    oMailItem.Send();
                }
                else
                    oMailItem.Display(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        public static void OpenOutLook_BBXNCN(string strEmail, string strSub, string strBody, string strPathZipFile, string strMa_So_Thue, bool bAuto)
       {
           try
           {

               int iE; string strEmail_List;
               List<string> lstAllRecipients = new List<string>();
               if (strEmail.Contains(";"))
               {
                   strEmail_List = strEmail;
                   while (strEmail_List.Length > 0)
                   {
                       if (strEmail_List.Contains(";"))
                       {
                           iE = strEmail_List.IndexOf(";");
                           strEmail = strEmail_List.Substring(0, iE);
                           strEmail_List = strEmail_List.Replace(strEmail + ";", "");
                       }
                       else
                       {
                           strEmail = strEmail_List.Substring(0, strEmail_List.Length);
                           strEmail_List = strEmail_List.Replace(strEmail, "");
                       }
                       lstAllRecipients.Add(strEmail);
                   }
               }
               else
                   lstAllRecipients.Add(strEmail);
               //lstAllRecipients.Add("cuongpn@thepmiennam.com.vn");

               Outlook.Application outlookApp = new Outlook.Application();
               Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
               Outlook.Inspector oInspector = oMailItem.GetInspector;

               // Recipient
               Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
               foreach (String recipient in lstAllRecipients)
               {
                   Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                   oRecip.Resolve();
               }

               //Add CC
               //Outlook.Recipient oCCRecip = oRecips.Add("THIYAGARAJAN.DURAIRAJAN@testmail.com");
               //oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
               //oCCRecip.Resolve();

               //Add Subject
               oMailItem.Subject = strSub;

               // body, bcc etc...
               oMailItem.Body = strBody;
               //attach file nén
               string[] fileList = Directory.GetFiles(strPathZipFile, "*" + strMa_So_Thue + "*");


               foreach (string filename in fileList)
                   oMailItem.Attachments.Add(filename);
               if (bAuto)
               {
                   //Display the mailbox
                   oMailItem.Display(false);
                   oMailItem.Send();
               }
               else
                   oMailItem.Display(true);
               //if (oMailItem.Send())
               //{
               //MoveFile_CNXX(strPathZipFile, strMa_So_Thue);
               //}
               //xóa file đã gửi đi
               foreach (string filename in fileList)
                   File.Delete(Path.Combine(strPathZipFile, Path.GetFileName(filename)));
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());

           }
       }
       public static void MoveFile_CNXX(string strPathZipFile, string strMST_Customer)
       {
           //Lấy các file trong đường dẫn truyền vào             
           string[] fileList = Directory.GetFiles(strPathZipFile, "*" + strMST_Customer + "*.*");
           string strPathZipFile_Dest = "D:\\CNXX_DaGui";

           if (!Directory.Exists(strPathZipFile_Dest))
               Directory.CreateDirectory(strPathZipFile_Dest);
           
        
           
           foreach (string fileName in fileList)
           {
               string[] files = Directory.GetFiles(strPathZipFile, "*" + strMST_Customer + "*.*");
               //Copy các file có mst khách hàng vào thư mục                   
               foreach (var item in files)
               {
                   //nếu ko tồn tại thì ko copy
                   if (File.Exists(Path.Combine(strPathZipFile_Dest, Path.Combine(strPathZipFile_Dest, Path.GetFileName(item)))))
                   {
                       File.Delete(Path.Combine(strPathZipFile_Dest, Path.GetFileName(item)));
                      
                   }
                   File.Move(item, Path.Combine(strPathZipFile_Dest, Path.GetFileName(item)));
               }
           }
       }
       public static void CreateFileZip_CNXX(string strPathZipFile, string strMST_Customer)
       {
           //LẤY NGÀY GIỜ HIỆN TẠI
           string strNgay_Gio = Voucher.GetDate_Server().ToString("yyyyMMdd") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
           //Lấy các file trong đường dẫn truyền vào             
           string[] fileList = Directory.GetFiles(strPathZipFile,  "*" + strMST_Customer + ".pdf");

          
               //tạo thư muc chứa MST khách hàng
               //nếu chưa có thư mục MST khách hàng thì tạo
               if (!Directory.Exists(Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio)))
                   Directory.CreateDirectory(Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio));

               string[] files = Directory.GetFiles(strPathZipFile,  "*" + strMST_Customer + "*");
               //Copy các file có mst khách hàng vào thư mục                   
               foreach (var item in files)
               {
                   //nếu ko tồn tại thì ko copy
                   if (!File.Exists(Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio) + "\\" + Path.GetFileName(item)))
                       File.Copy(item, Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio) + "\\" + Path.GetFileName(item));
               }

               //Nén file 
               string folderName = Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio);
               string strOutZip = Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio + ".zip");
               if (!File.Exists(Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio) + ".zip"))
                   CreateFileZip(strOutZip, folderName);
               //Xóa thư mục con sau khi tạo file nén
               if (Directory.Exists(Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio)))
               {
                   //nếu có file thì phải xóa file đi
                   string[] strfile_Del = Directory.GetFiles(Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio));
                   foreach (string file_Del in strfile_Del)
                       File.Delete(Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio) + "\\" + Path.GetFileName(file_Del));

                   Directory.Delete(Path.Combine(strPathZipFile, strMST_Customer + "_" + strNgay_Gio));
               }

               //oMailItem.Attachments = 
           
       }
       public static void CreateFileZip(string outPathname, string folderName)
       {
           if (!Directory.Exists(outPathname))
           {
               FileStream fsOut = File.Create(outPathname);
               ZipOutputStream zipStream = new ZipOutputStream(fsOut);

               zipStream.SetLevel(9); //0-9,có 9 mức nén, mức 9 là cao nhất, khuyến nghị 3

               int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

               CompressFolder(folderName, zipStream, folderOffset);

               zipStream.IsStreamOwner = true;
               zipStream.Close();
           }
       }
       public static void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
       {

           string[] files = Directory.GetFiles(path);

           foreach (string filename in files)
           {

               FileInfo fi = new FileInfo(filename);

               string entryName = filename.Substring(folderOffset);
               entryName = ZipEntry.CleanName(entryName);
               ZipEntry newEntry = new ZipEntry(entryName);
               newEntry.DateTime = fi.LastWriteTime;

               newEntry.Size = fi.Length;

               zipStream.PutNextEntry(newEntry);

               byte[] buffer = new byte[4096];
               using (FileStream streamReader = File.OpenRead(filename))
               {
                   StreamUtils.Copy(streamReader, zipStream, buffer);
               }
               zipStream.CloseEntry();
           }
           string[] folders = Directory.GetDirectories(path);
           foreach (string folder in folders)
           {
               CompressFolder(folder, zipStream, folderOffset);
           }
       }
       public static Object GetTypeOfTable(string strTableName, string strColumnName, string strValue)
       {
           Object objValue = string.Empty;
           string strSQLExec = "SELECT system_type_id from sys.columns where  OBJECT_NAME(OBJECT_ID) = '" + strTableName + "' AND name = '" + strColumnName + "'";
           string strColumnType = Convert.ToString(SQLExec.ExecuteReturnValue(strSQLExec));

           if (Common.Inlist(strColumnType, "167,231"))
               objValue = (string)(strValue);
           else if (Common.Inlist(strColumnType, "60"))
               objValue = Convert.ToDouble(strValue);
           else if (Common.Inlist(strColumnType, "40,61"))
               objValue = Convert.ToDateTime(strValue);
           else if (Common.Inlist(strColumnType, "104"))
               objValue = Convert.ToBoolean(strValue);
           else if (Common.Inlist(strColumnType, "56"))
               objValue = Convert.ToInt32(strValue);

           return objValue;
       }
       public static string GetBpOfUser()
       {
           string strMa_Bp = SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt IN (SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_ID = '"+ Element.sysUser_Id +"')").ToString();

           return strMa_Bp;
       }
       public static string GetFormatID(string strID)
       {

           string str_ID = SQLExec.ExecuteReturnValue("SELECT [dbo].[fn_GetSoCCCD]('" + strID  + "')").ToString();

           return str_ID;
       }
       public static string GetFormatSoXe(string strID)
       {

           string str_ID = SQLExec.ExecuteReturnValue("SELECT [dbo].[fn_GetSoXe]('" + strID + "')").ToString();

           return str_ID;
       }
       public static string GetFormatSoXaLan(string strID)
       {

           string str_ID = SQLExec.ExecuteReturnValue("SELECT [dbo].[fn_GetSoXaLan]('" + strID + "')").ToString();

           return str_ID;
       }
       public static string GetSoCt0(string strSo_Ct)
       {
            string strSo_Ct0 = string.Empty;
            if (strSo_Ct.Length < 8 && strSo_Ct != string.Empty)
                strSo_Ct0 = SQLExec.ExecuteReturnValue("select [dbo].[fn_GetSoCt0] ('" + strSo_Ct + "')").ToString();
            else
                strSo_Ct0 = strSo_Ct;

            return strSo_Ct0;
        }
        public static string GetTenHd(string strMa_Hd)
        {
            string strTen_Hd = "";
            DataTable dtDmHd = SQLExec.ExecuteReturnDt("Select * From R81DMHD Where Ma_Hd = '" + strMa_Hd + "'");
            if (dtDmHd.Rows.Count > 0)
                strTen_Hd = "Số HĐ:" + dtDmHd.Rows[0]["So_Hd"].ToString();
            
            return strTen_Hd;

        }
        public static void LoadCombo(RosySystem.Control.rsMultiComboBox cboMa_Bp, DataTable dt, string strColumnName)
       {
           cboMa_Bp.lstItem.BuildListView("" + strColumnName + ":100");
           cboMa_Bp.lstItem.DataSource = dt;
           cboMa_Bp.lstItem.Size = new Size(400, cboMa_Bp.lstItem.Items.Count * 20);
           cboMa_Bp.lstItem.GridLines = true;
       }
        public static void LoadComboBpNT(RosySystem.Control.rsMultiComboBox cboMa_Bp)
        {
            DataTable dtDmBp;
            DataSet dsBp;
            string strMa_Bp = GetBpOfUser();

            //Gắn Ma_Bp vào ComboBox
            dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
            dtDmBp = dsBp.Tables[0];

            if (!Element.sysIs_Admin & !Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
            {
                cboMa_Bp.Enabled = false;

            }

            Hashtable ht = new Hashtable();
            ht.Add("MA_BP", strMa_Bp);
            ht.Add("LOGIN_ID", Element.sysUser_Id);
            dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
            dtDmBp = dsBp.Tables[0];
            DataRow dr = dtDmBp.Rows[0];

            cboMa_Bp.lstItem.BuildListView("Ma_Bp:100,Ten_Bp:200");
            cboMa_Bp.lstItem.DataSource = dtDmBp;
            cboMa_Bp.lstItem.Size = new Size(800, cboMa_Bp.lstItem.Items.Count * 20);
            cboMa_Bp.lstItem.GridLines = true;


        }
       
        public static void LoadComboBp(RosySystem.Control.rsMultiComboBox cboMa_Bp, RosySystem.Control.rsMultiComboBox cboMa_Bp_Ct)
       {
           DataTable dtDmBpCt, dtDmBp;
           DataSet dsBp;
           string strMa_Bp = GetBpOfUser();

           //Gắn Ma_Bp vào ComboBox
           dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
           dtDmBp = dsBp.Tables[0];

           if (!Element.sysIs_Admin & !Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
           {
               cboMa_Bp.Enabled = false;

           }
               
            Hashtable ht = new Hashtable();
            ht.Add("MA_BP", strMa_Bp);
            ht.Add("LOGIN_ID", Element.sysUser_Id);
            dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
            dtDmBp = dsBp.Tables[0];
            DataRow dr = dtDmBp.Rows[0];
           
          

            if (cboMa_Bp.Text != "")
            {

                dtDmBpCt = dsBp.Tables[1];
                cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
                cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
                cboMa_Bp_Ct.lstItem.Size = new Size(400, cboMa_Bp_Ct.lstItem.Items.Count * 20);
                cboMa_Bp_Ct.lstItem.GridLines = true;
            }

            cboMa_Bp.lstItem.BuildListView("Ma_Bp:100,Ten_Bp:200");
            cboMa_Bp.lstItem.DataSource = dtDmBp;
            cboMa_Bp.lstItem.Size = new Size(800, cboMa_Bp.lstItem.Items.Count * 20);
            cboMa_Bp.lstItem.GridLines = true;
         

       }
        public static bool CheckThue(string strSo_Ct0, string strSo_Seri0, string strMa_So_Thue, string strMa_Thue, string strNgay_Ct0, double dbTien, double dbTien3)
        {
            double dbThueSuat = 0;
            
            if (strMa_Thue != "")
                dbThueSuat = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMTHUE", "Ma_Thue", "Thue_Suat", strMa_Thue));

            //kiểm tra logic số hd, số seri và ngày hóa đơn
            if (!(bool)(strSo_Ct0 == "" && strSo_Seri0 == "" && strMa_So_Thue == "" && strMa_Thue == ""
                        && Library.StrToDate(strNgay_Ct0) == Library.StrToDate("19000101")) &&
            (!(bool)(strSo_Ct0 != "" && strSo_Seri0 != "" && strMa_So_Thue != "" && strMa_Thue != ""
                        && Library.StrToDate(strNgay_Ct0) != Library.StrToDate("19000101"))))
            {
                Common.MsgOk("Số HĐ, ngày HD, Số Seri, mã số thuế phải khác rỗng hoặc tất cả bằng rỗng. Vui lòng kiểm tra lại dữ liệu !!!");
                return false;
            }

            if (strMa_So_Thue != string.Empty && (strMa_So_Thue.Length != 10 && strMa_So_Thue.Length != 12 && strMa_So_Thue.Length != 14)) // kiểm tra chiều dài của MST
            {
                Common.MsgOk("Chiều dài của MST " + strMa_So_Thue + " không đúng quy tắc. Vui lòng kiểm tra lại dữ liệu !!!");
                return false;
            }
            if(strSo_Seri0 != string.Empty  && strSo_Seri0.Length != 7)
            {
                Common.MsgOk("Chiều dài của số seri " + strSo_Seri0 + " phải là 7 ký tự. Vui lòng kiểm tra lại dữ liệu !!!");
                return false;
            }
            if (strSo_Ct0 != string.Empty && strSo_Ct0.Length != 8)
            {
                Common.MsgOk("Chiều dài của số hóa đơn " + strSo_Ct0 + " phải là 8 ký tự. Vui lòng nhấn enter qua số hóa đơn trước khi lưu !!!");
                return false;
            }
            if(dbTien3 != 0 && dbThueSuat == 0)
            {
                Common.MsgOk("Tiền thuế của " + strSo_Ct0 + " có mã thuế là "+ strMa_Thue +". Vui lòng nhấn enter qua mã thuế để tính lại tiền thuế trước khi lưu !!!");
                return false;
            }
            if (dbTien3 != 0 && dbTien != 0 && Math.Round(dbTien*(dbThueSuat/100), MidpointRounding.AwayFromZero) != dbTien3)
            {
                if (!Common.MsgYes_No("Tiền thuế VAT tại dòng HĐ " + strSo_Ct0 + " đang khác với tiền hàng * thuế suất/100. Anh (chị) có muốn lưu không?", "N"))
                    return false;
            }
            if (strMa_So_Thue != string.Empty && (strMa_So_Thue.Length == 14)) // kiểm tra chiều dài của MST
            {
                int index = strMa_So_Thue.IndexOf("-");
                //int index_ = strMa_So_Thue.LastIndexOf("-");
                if (!strMa_So_Thue.Contains("-"))
                {
                    Common.MsgOk("Chiều dài của MST " + strMa_So_Thue + " không đúng quy tắc. Vui lòng kiểm tra lại dữ liệu !!!");
                    return false;
                }
                if(strMa_So_Thue.Length - index != 4 || index != 10)// || strMa_So_Thue.Length - index_ != 3)
                {
                    Common.MsgOk("MST " + strMa_So_Thue + " không đúng quy tắc. Vui lòng kiểm tra lại dữ liệu vị trí dấu sau dấu - phải có 3 ký tự, trước dấu - phải 10 ký tự !!!");
                    return false;
                }
            }
            return true;
        }
        public static void SetIPAddress(string ipv4, string ip, string ipdns1, string ipdns2)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "netsh interface ip set address name=Ethernet static "+ ipv4 + " 255.255.255.0 "+ ip + " netsh interface ip set dns name=Ethernet static "+ ipdns1 + " netsh interface ip add dns name=Ethernet " + ipdns2 + " index=2";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
        }

    }
  
}
