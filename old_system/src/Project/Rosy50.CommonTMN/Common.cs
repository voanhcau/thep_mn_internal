using DataDynamics.ActiveReports;
using DevExpress.XtraTreeList.Columns;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using RosySystem;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Library;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RosyController;
using System.Diagnostics;


namespace RosyCommonTMN
{
    
    public class CommonTMN
    {
       

        public static void Export(object ExportControl, string strTitle, string strSubTitle, string strLoai)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //dictionary.set_Item("TEN_DV", RosySystem.Element.Element.get_sysTen_Dvi().ToUpper());
            //dictionary.set_Item("DIA_CHI_DV", RosySystem.Element.Element.get_sysDia_Chi_Dv());
            //dictionary.set_Item("TITLE", strTitle.ToUpper());
           frmExportTMN export = new frmExportTMN();
            export.Load(strTitle);
            if (export.isAccept)
            {
                string strPath = export.strPath;
                string str2 = export.cboExportType_Bk.Text;
                if (str2.StartsWith("1"))
                {
                    ExportExcel(ExportControl, strTitle, strSubTitle, strPath, export.enuFormatFont.Text.Trim(), strLoai);
                }
               
            }
        }
        public static void ExportExcel(object ExportControl, string strTitle, string strSubTitle, string strFileName, string strDestFont, string strLoai)
        {
            Microsoft.Office.Interop.Excel.Application application = null;
            Workbook workbook = null;
            Worksheet worksheet = null;
            Exception exception;
            System.Data.DataTable table;
            System.Windows.Forms.BindingSource dataSource;
            object[,] objArray;
            object[,] objArray2;
            object[,] objArray3;
            int count;
            int visibleNodesCount;
            rsTreeList list;
            int num6;
            rsDataGridView view;
            DataTable dtView;
            int num8;

            try
            {
                application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
                workbook = application.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                worksheet = (Worksheet)workbook.Worksheets[1];
            }
            catch (Exception exception1)
            {
                exception = exception1;
                MsgCancel("Kh\x00f4ng thể kết xuất được dữ liệu! Error " + exception.Message);
                return;
            }

            bool flag = true;
            if (File.Exists(strFileName))
            {
                try
                {
                    if (MsgYes_No("File [" + strFileName + "] đ\x00e3 tồn tại, c\x00f3 chắc chắn ghi đ\x00e8 file?", "Y"))
                    {
                        File.Delete(strFileName);
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    MsgCancel(exception.Message);
                    return;
                }
            }

            int num4 = -1;
            int num5 = -1;
            if (Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
            {
                list = (rsTreeList)ExportControl;
                dataSource = (BindingSource)list.DataSource;
                table = (System.Data.DataTable)dataSource.DataSource;
                count = list.Columns.Count;
                visibleNodesCount = list.VisibleNodesCount;
                objArray = new object[1, count];
                objArray2 = new object[1, count];
                objArray3 = new object[visibleNodesCount, count];
                for (num6 = 0; num6 < objArray.Length; num6++)
                {
                    objArray[0, num6] = list.Columns[num6].Caption;
                    objArray2[0, num6] = list.Columns[num6].FieldName;
                    if (objArray2[0, num6].ToString().ToUpper() == "BOLD")
                    {
                        num4 = num6;
                    }
                }
            }
            
            else
            {
                view = (rsDataGridView)ExportControl;
                dataSource = (BindingSource)view.DataSource;
                table = (System.Data.DataTable)dataSource.DataSource;

                if (strLoai == "REPORT")//báo cáo
                    count = view.Columns.Count;
                else//form
                {
                    if (view.Columns.Count > 0)
                        count = view.Columns.Count - 4;
                    else
                        count = view.Columns.Count;
                }
                visibleNodesCount = view.Rows.Count;
                objArray = new object[1, count];
                objArray2 = new object[1, count];
                objArray3 = new object[visibleNodesCount, count];
                for (num6 = 0; num6 < count; num6++)
                {
                    objArray[0, num6] = view.Columns[num6].HeaderText;
                    objArray2[0, num6] = view.Columns[num6].DataPropertyName;
                    //if (objArray2[0, num6].ToString().ToUpper() == "BOLD")
                    //{
                    //    num4 = num6;
                    //}
                    //if (objArray2[0, num6].ToString().ToUpper() == "CONG_THUC")
                    //{
                    //    num5 = num6;
                    //}
                }
            }

            //application.Cells[1, 1] = RosySystem.Element.Element.sysTen_Dvi.ToUpper();
            //application.Cells[2, 1] = RosySystem.Element.Element.sysDia_Chi_Dv.ToUpper();
            //application.Cells[3, 1] = strTitle;
            string[] strArray = strSubTitle.Split((char[])new char[] { '|' });
            int length = strArray.Length;
            //for (num8 = 0; num8 < length; num8++)
            //{
            //    application.Cells[4 + num8, 1] = strArray[num8];
            //}
            //((Range)application.Cells[1, 1]).Font.Bold = true;
            //((Range)application.Cells[2, 1]).Font.Bold = true;
            //((Range)application.Cells[3, 1]).Font.Bold = true;
            //((Range)application.Cells[1, 1]).Font.Size = 10;
            //((Range)application.Cells[2, 1]).Font.Size = 10;
            //((Range)application.Cells[3, 1]).Font.Size = 0x12;
            //for (num6 = 0; num6 < length; num6++)
            //{
            //    ((Range)application.Cells[4 + num6, 1]).Font.Bold = true;
            //    ((Range)application.Cells[4 + num6, 1]).Font.Italic = true;
            //    ((Range)application.Cells[4 + num6, 1]).Font.Size = 10;
            //}
            //string str = (string)(((dynamic)application.Cells[1, 1]).Address);
            //string str2 = (string)(((dynamic)application.Cells[1, objArray.Length]).Address);
            //application.get_Range(str, str2).MergeCells = true;
            //str = (string)(((dynamic)application.Cells[2, 1]).Address);
            //str2 = (string)(((dynamic)application.Cells[2, objArray.Length]).Address);
            //application.get_Range(str, str2).MergeCells = true;
            //str = (string)(((dynamic)application.Cells[3, 1]).Address);
            //str2 = (string)(((dynamic)application.Cells[3, objArray.Length]).Address);
            //application.get_Range(str, str2).MergeCells = true;
            //for (num8 = 0; num8 < length; num8++)
            //{
            //    str = (string)(((dynamic)application.Cells[4 + num8, 1]).Address);
            //    str2 = (string)(((dynamic)application.Cells[4 + num8, objArray.Length]).Address);
            //    application.get_Range(str, str2).MergeCells = true;
            //}
            //((Range)application.Cells[3, 1]).HorizontalAlignment = XlVAlign.xlVAlignCenter;
            //num8 = 0;
            //while (num8 < length)
            //{
            //    ((Range)application.Cells[4 + num8, 1]).HorizontalAlignment = XlVAlign.xlVAlignCenter;
            //    num8++;
            //}
            //int num3 = (4 + length);
            
            int num3;
             if(strLoai == "REPORT") //Báo cáo
                num3 = (-1 + length);
            else
                num3 = (0 + length);

            string str = (string)((dynamic)worksheet.Cells[num3, 1]).Address;
            string str2 = (string)((dynamic)worksheet.Cells[num3, count]).Address;
            Range range = application.get_Range(str, str2);
            range.Value2 = objArray;
            range.EntireRow.Font.Bold = true;
            range.Borders.LineStyle = XlLineStyle.xlContinuous;
            Marshal.ReleaseComObject(range);
            range = null;
            num3++;
            str = (string)((dynamic)worksheet.Cells[num3, 1]).Address;
            str2 = (string)((dynamic)worksheet.Cells[(num3 + visibleNodesCount) - 1, count]).Address;
            Range range2 = application.get_Range(str, str2);
            range2.Borders.LineStyle = XlLineStyle.xlContinuous;
            for (num6 = 0; num6 < count; num6++)
            {
                string name = objArray2[0, num6].ToString();
                if (table.Columns.Contains(name))
                {
                    try
                    {
                        if (table.Columns[name].DataType.Equals(typeof(string)))
                        {
                            ((Range)range2.Cells[num3, num6 + 1]).EntireColumn.NumberFormat = "@";
                        }
                        else if (table.Columns[name].DataType == typeof(DateTime))
                        {
                            ((Range)range2.Cells[(int)num3, num6 + 1]).EntireColumn.NumberFormat = "dd/MM/yyyy";
                        }
                        else if (table.Columns[name].DataType.Equals(typeof(double)) || table.Columns[name].DataType.Equals(typeof(decimal)))
                        {
                            if (Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
                            {
                                view = (rsDataGridView)ExportControl;
                                if(view.Columns.GetType().Name == "dgvNumericColumn")
                                {
                                    string str4 = "".PadRight(((dgvNumericColumn)view.Columns[name]).Scale, '0');
                                    ((Range)range2.Cells[num3, num6 + 1]).EntireColumn.NumberFormat = "#,##0" + ((str4 != "") ? "." : "") + str4;
                                }
                            }
                            else
                            {
                                ((Range)range2.Cells[num3, num6 + 1]).EntireColumn.NumberFormat = "#,##0.00";
                            }
                        }
                    }
                    catch (Exception exception3)
                    {
                        MsgCancel(exception3.Message);
                        throw;
                    }
                }
            }
            Marshal.ReleaseComObject(range2);
            range2 = null;
            try
            {
                int num9 = 0;
                int num10 = 0;
                int num11 = 0x2710;
                while (num9 < visibleNodesCount)
                {
                    ShowStatus("Exporting row at " + num9.ToString());
                    num10 = Math.Min(num9 + num11, visibleNodesCount);
                    str = (string)((dynamic)worksheet.Cells[num3 + num9, 1]).Address;
                    str2 = (string)((dynamic)worksheet.Cells[(num3 + num10) - 1, count]).Address;
                    Range range3 = application.get_Range(str, str2);
                    objArray3 = new object[Math.Min(num10 - num9, num11), count];
                    for (num8 = num9; num8 < (num9 + num11); num8++)
                    {
                        if (num8 < visibleNodesCount)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
                                {
                                    list = (rsTreeList)ExportControl;
                                    objArray3[num8 - num9, i] = list.GetNodeByVisibleIndex(num8).GetValue(list.Columns[i].FieldName);
                                }
                                else
                                {
                                    view = (rsDataGridView)ExportControl;
                                    objArray3[num8 - num9, i] = view.Rows[num8].Cells[i].Value;
                                    
                                }
                            }
                            if ((((num4 >= 0) && (objArray3[num8 - num9, num4] != null)) && objArray3[num8 - num9, num4].GetType().Equals(typeof(bool))) && ((bool)objArray3[num8 - num9, num4]))
                            {
                                ((Range)range3.Cells[(num8 - num9) + 1, 1]).EntireRow.Font.Bold = true;
                            }
                          
                        }

                        
                    }

                    range3.Value2 = objArray3;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.SuppressFinalize(objArray3);
                    GC.SuppressFinalize(range3);
                    Marshal.ReleaseComObject(range3);
                    range3 = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    num9 += num11;
                }
            } 
            catch (Exception exception4)
            {
                exception = exception4;
                MsgCancel("C\x00f3 lỗi xảy ra: " + exception.Message);
            }
            EndShowStatus();
            application.Visible = true;
            worksheet.Columns.AutoFit();
            if (flag)
            {
                try
                {
                    object fileFormat = Missing.Value;
                    application.DisplayAlerts = false;
                    application.AlertBeforeOverwriting = true;
                    if (Directory.Exists(Path.GetDirectoryName(strFileName)))
                    {
                        workbook.SaveAs(strFileName, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat, XlSaveAsAccessMode.xlExclusive, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat);
                    }
                }
                catch (Exception exception5)
                {
                    exception = exception5;
                    throw;
                }
            }
            Marshal.ReleaseComObject(worksheet);
            worksheet = null;
            Marshal.ReleaseComObject(workbook);
            workbook = null;
            Marshal.ReleaseComObject(application);
            application = null;
        
        }
        //XỬ LÝ ĐỂ EXPORT BCAO RA FILE XLSL
        public static void ExportExcelXlsx(object ExportControl, string strTitle, string strSubTitle, string strFileName, string strDestFont, bool chkOpenFile)
        {
            bool daLuuFileThanhCong = false;
            string fileExcelDaLuu = "";

            Microsoft.Office.Interop.Excel.Application application = null;
            Workbook workbook = null;
            Worksheet worksheet = null;

            Range rangeHeader = null;
            Range rangeData = null;
            Range rangeTemp = null;

            bool flag = true;

            try
            {
                // Ép file xuất ra .xlsx
                //strFileName = DoiDuoiFileThanhXlsx(strFileName);

                application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(
                    Type.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046"))
                );

                application.Visible = false;
                application.DisplayAlerts = false;
                application.ScreenUpdating = false;

                workbook = application.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                worksheet = (Worksheet)workbook.Worksheets[1];
            }
            catch (Exception ex)
            {
                MsgCancel("Không thể kết xuất được dữ liệu! Error " + ex.Message);
                return;
            }

            try
            {
                if (File.Exists(strFileName))
                {
                    try
                    {
                        if (MsgYes_No("File [" + strFileName + "] đã tồn tại, có chắc chắn ghi đè file?", "Y"))
                        {
                            File.Delete(strFileName);
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    catch (Exception ex2)
                    {
                        MsgCancel(ex2.Message);
                        return;
                    }
                }

                if (!flag)
                    return;

                int num = -1;   // Cột BOLD
                int num2 = -1;  // Cột CONG_THUC, giữ lại theo cấu trúc cũ nếu sau này dùng

                System.Data.DataTable dataTable;
                int count;
                int num3;

                object[,] array;
                object[,] array2;

                bool isTreeList = Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList");

                if (isTreeList)
                {
                    rsTreeList rsTreeList = (rsTreeList)ExportControl;
                    BindingSource bindingSource = (BindingSource)rsTreeList.DataSource;

                    dataTable = (System.Data.DataTable)bindingSource.DataSource;
                    count = rsTreeList.Columns.Count;
                    num3 = rsTreeList.VisibleNodesCount;

                    array = new object[1, count];
                    array2 = new object[1, count];

                    for (int i = 0; i < count; i++)
                    {
                        array[0, i] = rsTreeList.Columns[i].Caption;
                        array2[0, i] = rsTreeList.Columns[i].FieldName;

                        if (array2[0, i] != null && array2[0, i].ToString().ToUpper() == "BOLD")
                            num = i;
                    }
                }
                else
                {
                    rsDataGridView rsDataGridView = (rsDataGridView)ExportControl;
                    BindingSource bindingSource = (BindingSource)rsDataGridView.DataSource;

                    dataTable = (System.Data.DataTable)bindingSource.DataSource;
                    count = rsDataGridView.Columns.Count;
                    num3 = rsDataGridView.Rows.Count;

                    array = new object[1, count];
                    array2 = new object[1, count];

                    for (int j = 0; j < count; j++)
                    {
                        array[0, j] = rsDataGridView.Columns[j].HeaderText;
                        array2[0, j] = rsDataGridView.Columns[j].DataPropertyName;

                        if (array2[0, j] != null && array2[0, j].ToString().ToUpper() == "BOLD")
                            num = j;

                        if (array2[0, j] != null && array2[0, j].ToString().ToUpper() == "CONG_THUC")
                            num2 = j;
                    }
                }

                // =========================
                // GHI PHẦN TIÊU ĐỀ
                // =========================

                worksheet.Cells[1, 1] = DataTool.SQLGetNameByCode(
                    "R00DMDVCS",
                    "Ma_Dvcs",
                    "Ten_Dvcs",
                    RosySystem.Element.Element.sysMa_DvCs
                );

                worksheet.Cells[2, 1] = RosySystem.Element.Element.sysDia_Chi_Dv;
                worksheet.Cells[3, 1] = strTitle;

                string[] array4 = strSubTitle.Split('|');
                int num4 = array4.Length;

                for (int k = 0; k < num4; k++)
                {
                    worksheet.Cells[4 + k, 1] = array4[k];
                }

                // Format tiêu đề
                SetCellFont(worksheet, 1, 1, true, false, 10);
                SetCellFont(worksheet, 2, 1, true, false, 10);
                SetCellFont(worksheet, 3, 1, true, false, 18);

                for (int l = 0; l < num4; l++)
                {
                    SetCellFont(worksheet, 4 + l, 1, true, true, 10);
                }

                // Merge tiêu đề theo số cột
                MergeRow(worksheet, 1, count);
                MergeRow(worksheet, 2, count);
                MergeRow(worksheet, 3, count);

                for (int m = 0; m < num4; m++)
                {
                    MergeRow(worksheet, 4 + m, count);
                }

                ((Range)worksheet.Cells[3, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;

                for (int n = 0; n < num4; n++)
                {
                    ((Range)worksheet.Cells[4 + n, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                }

                // =========================
                // GHI HEADER
                // =========================

                int num5 = 4 + num4;

                rangeHeader = worksheet.Range[
                    worksheet.Cells[num5, 1],
                    worksheet.Cells[num5, count]
                ];

                rangeHeader.Value2 = array;
                rangeHeader.EntireRow.Font.Bold = true;
                rangeHeader.Borders.LineStyle = XlLineStyle.xlContinuous;

                ReleaseComObject(rangeHeader);
                rangeHeader = null;

                num5++;

                // =========================
                // FORMAT VÙNG DỮ LIỆU
                // =========================

                if (num3 > 0)
                {
                    rangeData = worksheet.Range[
                        worksheet.Cells[num5, 1],
                        worksheet.Cells[num5 + num3 - 1, count]
                    ];

                    rangeData.Borders.LineStyle = XlLineStyle.xlContinuous;

                    for (int num6 = 0; num6 < count; num6++)
                    {
                        string text = array2[0, num6] == null ? "" : array2[0, num6].ToString();

                        if (!dataTable.Columns.Contains(text))
                            continue;

                        try
                        {
                            Range colRange = null;

                            try
                            {
                                colRange = worksheet.Range[
                                    worksheet.Cells[num5, num6 + 1],
                                    worksheet.Cells[num5 + num3 - 1, num6 + 1]
                                ];

                                if (dataTable.Columns[text].DataType.Equals(typeof(string)))
                                {
                                    colRange.NumberFormat = "@";
                                }
                                else if (dataTable.Columns[text].DataType.Equals(typeof(DateTime)))
                                {
                                    colRange.NumberFormat = "dd/MM/yyyy";
                                }
                                else if (
                                    dataTable.Columns[text].DataType.Equals(typeof(double)) ||
                                    dataTable.Columns[text].DataType.Equals(typeof(decimal)) ||
                                    dataTable.Columns[text].DataType.Equals(typeof(float))
                                )
                                {
                                    if (Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
                                    {
                                        rsDataGridView rsDataGridView2 = (rsDataGridView)ExportControl;

                                        if (rsDataGridView2.Columns[text].GetType().Name == "dgvNumericColumn")
                                        {
                                            string text2 = "".PadRight(((dgvNumericColumn)rsDataGridView2.Columns[text]).Scale, '0');
                                            colRange.NumberFormat = "#,##0" + ((text2 != "") ? "." : "") + text2;
                                        }
                                    }
                                    else
                                    {
                                        colRange.NumberFormat = "#,##0.00";
                                    }
                                }
                            }
                            finally
                            {
                                ReleaseComObject(colRange);
                            }
                        }
                        catch (Exception ex3)
                        {
                            MsgCancel(ex3.Message);
                            throw;
                        }
                    }

                    ReleaseComObject(rangeData);
                    rangeData = null;
                }

                // =========================
                // GHI DỮ LIỆU THEO BLOCK
                // =========================

                try
                {
                    int num7 = 0;
                    int num8 = 0;
                    int blockSize = 10000;

                    List<int> boldExcelRows = new List<int>();

                    for (; num7 < num3; num7 += blockSize)
                    {
                        ShowStatus("Exporting row at " + num7);

                        num8 = Math.Min(num7 + blockSize, num3);

                        Range rangeBlock = null;

                        try
                        {
                            rangeBlock = worksheet.Range[
                                worksheet.Cells[num5 + num7, 1],
                                worksheet.Cells[num5 + num8 - 1, count]
                            ];

                            object[,] array3 = new object[num8 - num7, count];

                            for (int num10 = num7; num10 < num8; num10++)
                            {
                                for (int num11 = 0; num11 < count; num11++)
                                {
                                    if (isTreeList)
                                    {
                                        rsTreeList rsTreeList2 = (rsTreeList)ExportControl;

                                        array3[num10 - num7, num11] =
                                            rsTreeList2.GetNodeByVisibleIndex(num10)
                                                       .GetValue(rsTreeList2.Columns[num11].FieldName);

                                        continue;
                                    }

                                    rsDataGridView rsDataGridView3 = (rsDataGridView)ExportControl;

                                    if (strTitle.ToUpper() == "KẾT QUẢ HOẠT ĐỘNG KINH DOANH")
                                    {
                                        object formulaValue = LayCongThucKetQuaHoatDongKinhDoanh(
                                            rsDataGridView3,
                                            num10,
                                            num11
                                        );

                                        if (formulaValue != null)
                                            array3[num10 - num7, num11] = formulaValue;
                                        else
                                            array3[num10 - num7, num11] = rsDataGridView3.Rows[num10].Cells[num11].Value;
                                    }
                                    else
                                    {
                                        array3[num10 - num7, num11] = rsDataGridView3.Rows[num10].Cells[num11].Value;
                                    }
                                }

                                // Không format Bold ngay tại đây để tránh gọi COM nhiều lần.
                                // Chỉ lưu lại dòng Excel cần Bold.
                                if (
                                    num >= 0 &&
                                    array3[num10 - num7, num] != null &&
                                    array3[num10 - num7, num].GetType().Equals(typeof(bool)) &&
                                    (bool)array3[num10 - num7, num]
                                )
                                {
                                    boldExcelRows.Add(num5 + num10);
                                }
                            }

                            // Ghi nguyên block vào Excel một lần
                            rangeBlock.Value2 = array3;
                        }
                        finally
                        {
                            ReleaseComObject(rangeBlock);
                        }
                    }

                    // Format Bold sau khi đã đổ dữ liệu xong
                    foreach (int excelRow in boldExcelRows)
                    {
                        Range rowRange = null;

                        try
                        {
                            rowRange = worksheet.Range[
                                worksheet.Cells[excelRow, 1],
                                worksheet.Cells[excelRow, count]
                            ];

                            rowRange.Font.Bold = true;
                        }
                        finally
                        {
                            ReleaseComObject(rowRange);
                        }
                    }
                }
                catch (Exception ex4)
                {
                    MsgCancel("Có lỗi xảy ra: " + ex4.Message);
                }

                EndShowStatus();

                // AutoFit sau cùng
                worksheet.Columns.AutoFit();

                // =========================
                // SAVE AS .XLSX
                // =========================

                try
                {
                    object missing = Missing.Value;

                    application.DisplayAlerts = false;
                    application.AlertBeforeOverwriting = false;

                    string folder = Path.GetDirectoryName(strFileName);

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    // 51 = xlOpenXMLWorkbook = .xlsx
                    object fileFormatXlsx = 51;

                    workbook.SaveAs(
                        strFileName,
                        fileFormatXlsx,
                        missing,
                        missing,
                        false,
                        false,
                        XlSaveAsAccessMode.xlNoChange,
                        missing,
                        missing,
                        missing,
                        missing,
                        missing
                    );
                    // Đánh dấu đã lưu file thành công
                    daLuuFileThanhCong = true;
                    fileExcelDaLuu = strFileName;
                }
                catch (Exception exSave)
                {
                    MsgCancel("Không lưu được file Excel .xlsx: " + exSave.Message);
                    throw;
                }
            }
            finally
            {
                try
                {
                    if (workbook != null)
                    {
                        workbook.Close(false, Missing.Value, Missing.Value);
                    }
                }
                catch
                {
                }

                try
                {
                    if (application != null)
                    {
                        application.ScreenUpdating = true;
                        application.DisplayAlerts = true;
                        application.Quit();
                    }
                }
                catch
                {
                }

                ReleaseComObject(rangeTemp);
                ReleaseComObject(rangeData);
                ReleaseComObject(rangeHeader);
                ReleaseComObject(worksheet);
                ReleaseComObject(workbook);
                ReleaseComObject(application);

                worksheet = null;
                workbook = null;
                application = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (daLuuFileThanhCong && File.Exists(fileExcelDaLuu) && (bool)chkOpenFile)
                {
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo();

                        psi.FileName = fileExcelDaLuu;
                        psi.UseShellExecute = true;

                        Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        MsgCancel("Đã export file Excel thành công nhưng không mở được file. Chi tiết: " + ex.Message);
                    }
                }
            }
        }
        private static void SetCellFont(Worksheet worksheet, int row, int col, bool bold, bool italic, int size)
        {
            Range range = null;

            try
            {
                range = (Range)worksheet.Cells[row, col];

                range.Font.Bold = bold;
                range.Font.Italic = italic;
                range.Font.Size = size;
            }
            finally
            {
                ReleaseComObject(range);
            }
        }
        private static void MergeRow(Worksheet worksheet, int row, int columnCount)
        {
            Range range = null;

            try
            {
                range = worksheet.Range[
                    worksheet.Cells[row, 1],
                    worksheet.Cells[row, columnCount]
                ];

                range.MergeCells = true;
            }
            finally
            {
                ReleaseComObject(range);
            }
        }
        private static void ReleaseComObject(object obj)
        {
            try
            {
                if (obj != null && Marshal.IsComObject(obj))
                {
                    Marshal.FinalReleaseComObject(obj);
                }
            }
            catch
            {
                // Không throw lỗi ở đây để tránh làm hỏng luồng export
            }
        }
        private static object LayCongThucKetQuaHoatDongKinhDoanh(rsDataGridView grid, int rowIndex, int colIndex)
        {
            string columnName = grid.Columns[colIndex].Name;

            object maSoObj = grid.Rows[rowIndex].Cells["Ma_So"].Value;

            if (maSoObj == null)
                return null;

            string maSo = maSoObj.ToString();

            if (columnName == "NAM_NAY")
            {
                if (maSo == "10") return "=E7-E8";
                if (maSo == "20") return "=E9-E10";
                if (maSo == "30") return "=E11+E12-E13-E15-E16";
                if (maSo == "40") return "=E18-E19";
                if (maSo == "50") return "=E17+E20";
                if (maSo == "60") return "=E21-E22-E23";
            }
            else if (columnName == "NAM_TRUOC")
            {
                if (maSo == "10") return "=F7-F8";
                if (maSo == "20") return "=F9-F10";
                if (maSo == "30") return "=F11+F12-F13-F15-F16";
                if (maSo == "40") return "=F18-F19";
                if (maSo == "50") return "=F17+F20";
                if (maSo == "60") return "=F21-F22-F23";
            }
            else if (columnName == "NAM_NAY_LK")
            {
                if (maSo == "10") return "=G7-G8";
                if (maSo == "20") return "=G9-G10";
                if (maSo == "30") return "=G11+G12-G13-G15-G16";
                if (maSo == "40") return "=G18-G19";
                if (maSo == "50") return "=G17+G20";
                if (maSo == "60") return "=G21-G22-G23";
            }
            else if (columnName == "NAM_TRUOC_LK")
            {
                if (maSo == "10") return "=H7-H8";
                if (maSo == "20") return "=H9-H10";
                if (maSo == "30") return "=H11+H12-H13-H15-H16";
                if (maSo == "40") return "=H18-H19";
                if (maSo == "50") return "=H17+H20";
                if (maSo == "60") return "=H21-H22-H23";
            }

            return null;
        }
        public static void ExportXLSX(object ExportControl, string strTitle, string strSubTitle)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
          
            frmExportTMN export = new frmExportTMN();
            export.Load(strTitle);
            if (export.isAccept)
            {
                string strPath = export.strPath;
                string str2 = export.cboExportType.Text;
                if (str2.StartsWith("1"))
                {
                    ExportExcelXlsx(ExportControl, strTitle, strSubTitle, strPath, export.enuFormatFont.Text.Trim(), export.chkOpenFile.Checked);
                }
                else if (str2.StartsWith("7"))
                {
                    ExportExcel(ExportControl, strTitle, strSubTitle, strPath, export.enuFormatFont.Text.Trim(), "");
                }
                else
                    MessageBox.Show("Loại export chưa được lập trình");

            }
        }
        public static bool MsgYes_No(string strMsg, string strDefaultY_N)
        {
            return (bool)(MessageBox.Show(strMsg, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, (strDefaultY_N == "Y") ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
        public static bool MsgYes_No(string strMsg)
        {
            return (bool)(MessageBox.Show(strMsg, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }
        public static void ShowStatus(string strStatusText)
        {
            if (RosySystem.Element.Element.frmMain != null)
            {
                ((frmMain)RosySystem.Element.Element.frmMain).ssMain.ShowStatus(strStatusText);
            }
        }
        public static bool InlistLike(string strExpr, string strExprList)
        {
            string[] strArray = strExprList.Split((char[])new char[] { ',' });
            for (int i = 0; i <= (strArray.Length - 1); i = (int)(i + 1))
            {
                if (strExpr.StartsWith(strArray[i].Trim()))
                {
                    return true;
                }
            }
            return false;
        }     
       

       

      
        public static bool Inlist(string strExpr, string strExprList)
        {
            string[] strArray = strExprList.Split((char[])new char[] { ',' });
            for (int i = 0; i <= (strArray.Length - 1); i = (int)(i + 1))
            {
                if (strExpr == strArray[i].Trim())
                {
                    return true;
                }
            }
            return false;
        }
        public static void EndShowStatus()
        {
            if (RosySystem.Element.Element.frmMain != null)
            {
                ((frmMain)RosySystem.Element.Element.frmMain).ssMain.EndShowStatus();
            }
        }
        public static bool MsgCancel(string strMsg)
        {
            MessageBox.Show(strMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return true;
        }
    }
}
