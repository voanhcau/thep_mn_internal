using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RosySystem.Common;



using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Customize;
using System.Data;
using System.Windows.Forms;

namespace RosyCommonTMN
{
    public class ExportExcel
    {
        public static void ExportExcelTMN(object ExportControl, string strTitle, string strSubTitle, string strFileName, string strDestFont)
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            //Microsoft.Office.Interop.Excel.Workbook wBook = default(Microsoft.Office.Interop.Excel.Workbook);
            //Microsoft.Office.Interop.Excel.Worksheet wSheet = default(Microsoft.Office.Interop.Excel.Worksheet);

            //wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;

            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook wBook = null;
            Microsoft.Office.Interop.Excel.Worksheet wSheet = null;
            //Microsoft.Office.Interop.Excel._Worksheet wSheet = null;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
                //Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)wBook.Worksheets.get_Item(1);
                //wSheet = (Microsoft.Office.Interop.Excel._Worksheet)wBook.Worksheets.get_Item(1);

            }
            catch (Exception ex)
            {
                Common.MsgCancel("Không thể kết xuất được dữ liệu! Error " + ex.Message);
                return;
            }

            bool bOverwrite = true;
            if (System.IO.File.Exists(strFileName))
            {
                try
                {
                    if (Common.MsgYes_No("File [" + strFileName + "] đã tồn tại, có chắc chắn ghi đè file?", "Y"))
                    {
                        System.IO.File.Delete(strFileName);
                    }
                    else
                        bOverwrite = false;
                }
                catch (Exception ex)
                {
                    Common.MsgCancel(ex.Message);
                    return;
                }
            }

            //excel.Visible = true;

            DataTable dtExport;
            BindingSource bdsExport;

            object[,] objColNames, objFieldNames;
            object[,] objRowValues, objRowValues2;
            int iColLength, iRowLength, iNextRow;
            int iBold = -1;
            int iCongThuc = -1;

            string strAddr1, strAddr2;

            if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
            {
                rsTreeList tlExport = (rsTreeList)ExportControl;
                bdsExport = (BindingSource)tlExport.DataSource;
                dtExport = (DataTable)bdsExport.DataSource;

                iColLength = tlExport.Columns.Count;
                iRowLength = tlExport.VisibleNodesCount;
                //iRowLength = tlExport.Nodes.Count;

                objColNames = new object[1, iColLength];
                objFieldNames = new object[1, iColLength];
                objRowValues = new object[iRowLength, iColLength];

                //Điền dữ liệu vào objColNames
                for (int i = 0; i < objColNames.Length; i++)
                {
                    objColNames[0, i] = tlExport.Columns[i].Caption;
                    objFieldNames[0, i] = tlExport.Columns[i].FieldName;

                    if (objFieldNames[0, i].ToString().ToUpper() == "BOLD")
                        iBold = i;
                }

                ////Điền dữ liệu vào objRowValues
                //for (int j = 0; j < tlExport.Nodes.Count; j++)
                //{
                //    for (int k = 0; k < iColLength; k++)
                //    {
                //        objRowValues[j, k] = tlExport.Nodes[j].GetValue(tlExport.Columns[k].FieldName);
                //    }
                //}
            }
            else
            {
                rsDataGridView dgvExport = (rsDataGridView)ExportControl;

                string strDel = "BOLD,COLOR,FORE_COLOR,BACK_COLOR";
                if (dgvExport.Columns.Contains("BOLD"))
                    dgvExport.Columns.Remove("BOLD");
                if (dgvExport.Columns.Contains("COLOR"))
                    dgvExport.Columns.Remove("COLOR");
                if (dgvExport.Columns.Contains("FORE_COLOR"))
                    dgvExport.Columns.Remove("FORE_COLOR");
                if (dgvExport.Columns.Contains("BACK_COLOR"))
                    dgvExport.Columns.Remove("BACK_COLOR");
                bdsExport = (BindingSource)dgvExport.DataSource;
                dtExport = (DataTable)bdsExport.DataSource;

                iColLength = dgvExport.Columns.Count;
                iRowLength = dgvExport.Rows.Count;
             

                objColNames = new object[1, iColLength];
                objFieldNames = new object[1, iColLength];
                objRowValues = new object[iRowLength, iColLength];

                //Điền dữ liệu vào objColNames
                for (int i = 0; i < iColLength; i++)
                {
                    objColNames[0, i] = dgvExport.Columns[i].HeaderText;
                    objFieldNames[0, i] = dgvExport.Columns[i].DataPropertyName;

                    if (objFieldNames[0, i].ToString().ToUpper() == "BOLD")
                        iBold = i;

                    if (objFieldNames[0, i].ToString().ToUpper() == "CONG_THUC")
                        iCongThuc = i;
                }

                ////Điền dữ liệu vào objRowValues
                //foreach (DataGridViewRow dgvr in dgvExport.Rows)
                //{
                //    for (int k = 0; k < iColLength; k++)
                //    {
                //        objRowValues[dgvr.Index, k] = dgvr.Cells[k].Value;
                //    }
                //}
            }

            #region Header

            //Dòng Ten_Dvi
            //excel.Cells[1, 1] = RosySystem.Element.Element.sysTen_Dvi.ToUpper();
            excel.Cells[1, 1] = DataTool.SQLGetNameByCode("R00DMDVCS", "Ma_Dvcs", "Ten_Dvcs", Element.sysMa_DvCs);
            excel.Cells[2, 1] = Element.sysDia_Chi_Dv;

            //Title và SubTitle
            excel.Cells[3, 1] = strTitle;

            string[] strArrSubTitle = strSubTitle.Split('|');
            int iSubTitleLen = strArrSubTitle.Length;
            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                excel.Cells[4 + j, 1] = strArrSubTitle[j];
            }

            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Font.Size = 10;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Font.Size = 10;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Font.Size = 18;

            for (int i = 0; i < iSubTitleLen; i++)//SubTitle
            {
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + i, 1]).Font.Bold = true;
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + i, 1]).Font.Italic = true;
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + i, 1]).Font.Size = 10;
            }

            //11/11/2012: Hải bỏ vì báo lỗi đối với framework 4.0
            //excel.get_Range(excel.Cells[1, 1], excel.Cells[1, objColNames.Length]).MergeCells = true;
            //excel.get_Range(excel.Cells[2, 1], excel.Cells[2, objColNames.Length]).MergeCells = true;
            //excel.get_Range(excel.Cells[3, 1], excel.Cells[3, objColNames.Length]).MergeCells = true;

            strAddr1 = excel.Cells[1, 1].Address; strAddr2 = excel.Cells[1, objColNames.Length].Address;
            excel.get_Range(strAddr1, strAddr2).MergeCells = true;

            strAddr1 = excel.Cells[2, 1].Address; strAddr2 = excel.Cells[2, objColNames.Length].Address;
            excel.get_Range(strAddr1, strAddr2).MergeCells = true;

            strAddr1 = excel.Cells[3, 1].Address; strAddr2 = excel.Cells[3, objColNames.Length].Address;
            excel.get_Range(strAddr1, strAddr2).MergeCells = true;

            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                strAddr1 = excel.Cells[4 + j, 1].Address;
                strAddr2 = excel.Cells[4 + j, objColNames.Length].Address;

                excel.get_Range(strAddr1, strAddr2).MergeCells = true;
                //excel.get_Range(excel.Cells[4 + j, 1], excel.Cells[4 + j, objColNames.Length]).MergeCells = true;
            }

            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            }
            #endregion

            //Điền dữ liệu Header
            iNextRow = 4 + iSubTitleLen;

            strAddr1 = wSheet.Cells[iNextRow, 1].Address;
            strAddr2 = wSheet.Cells[iNextRow, iColLength].Address;

            Microsoft.Office.Interop.Excel.Range columnsNamesRange = excel.get_Range(strAddr1, strAddr2);
            columnsNamesRange.Value2 = objColNames;
            columnsNamesRange.EntireRow.Font.Bold = true;
            columnsNamesRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            System.Runtime.InteropServices.Marshal.ReleaseComObject(columnsNamesRange);
            columnsNamesRange = null;

            //Điền dữ liệu Detail
            iNextRow = iNextRow + 1;

            if (1 == 1)
            {
                strAddr1 = wSheet.Cells[iNextRow, 1].Address;
                strAddr2 = wSheet.Cells[iNextRow + iRowLength - 1, iColLength].Address;

                Microsoft.Office.Interop.Excel.Range dataCells = excel.get_Range(strAddr1, strAddr2);
                //Microsoft.Office.Interop.Excel.Range dataCells = wSheet.get_Range(wSheet.Cells[iNextRow, 1], wSheet.Cells[iNextRow + iRowLength - 1, iColLength]);
                dataCells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //formating the columns before polulating the data
                for (int i = 0; i < iColLength; i++)
                {
                    string strColName = objFieldNames[0, i].ToString();

                    if (!dtExport.Columns.Contains(strColName))
                        continue;

                    try
                    {
                        if (dtExport.Columns[strColName].DataType.Equals(typeof(string)))
                            ((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "@";
                        else if (dtExport.Columns[strColName].DataType.Equals(typeof(DateTime)))
                            ((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "dd/MM/yyyy";
                        else if ((dtExport.Columns[strColName].DataType.Equals(typeof(double))) || (dtExport.Columns[strColName].DataType.Equals(typeof(decimal))))
                        {
                            if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
                            {
                                rsDataGridView dgvExport = (rsDataGridView)ExportControl;

                                if (dgvExport.Columns[strColName].GetType().Name == "dgvNumericColumn")
                                {
                                    string strTag = "".PadRight(((dgvNumericColumn)dgvExport.Columns[strColName]).Scale, '0');
                                    ((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0" + (strTag != "" ? "." : "") + strTag;
                                }
                            }
                            else
                                ((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0.00";
                        }
                        //else if ((dtExport.Columns[strColName].DataType.Equals(typeof(int))))
                        //    ((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0";
                    }
                    catch (Exception ex)
                    {
                        Common.MsgCancel(ex.Message);
                        throw;
                    }
                }


                //release range
                System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCells);
                dataCells = null;

                //polulating the data
                try
                {
                    int iFetch1 = 0, iFetch2 = 0, iFetchLen = 10000; //Mỗi lần Fetch 10.000 dòng
                    while (iFetch1 < iRowLength)
                    {
                        Common.ShowStatus("Exporting row at " + iFetch1.ToString());
                        iFetch2 = Math.Min(iFetch1 + iFetchLen, iRowLength);

                        strAddr1 = wSheet.Cells[iNextRow + iFetch1, 1].Address;
                        strAddr2 = wSheet.Cells[iNextRow + iFetch2 - 1, iColLength].Address;

                        Microsoft.Office.Interop.Excel.Range dataCellsFetch = excel.get_Range(strAddr1, strAddr2);
                        //Microsoft.Office.Interop.Excel.Range dataCellsFetch = wSheet.get_Range(wSheet.Cells[iNextRow + iFetch1, 1], wSheet.Cells[iNextRow + iFetch2 - 1, iColLength]);
                        objRowValues = new object[Math.Min(iFetch2 - iFetch1, iFetchLen), iColLength]; //Tạo mảng với số dòng tối đa bằng iFetchLen

                        for (int j = iFetch1; j < iFetch1 + iFetchLen; j++)
                        {
                            if (j < iRowLength) //Chỉ lấy dữ liệu khi j < Số dòng
                            {
                                for (int k = 0; k < iColLength; k++) //Điền dữ liệu vào objRowValues
                                {
                                    if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
                                    {
                                        rsTreeList tlExport = (rsTreeList)ExportControl;
                                        objRowValues[j - iFetch1, k] = tlExport.GetNodeByVisibleIndex(j).GetValue(tlExport.Columns[k].FieldName);
                                        //objRowValues[j - iFetch1, k] = tlExport.Nodes[j].GetValue(tlExport.Columns[k].FieldName);
                                    }
                                    else
                                    {
                                        rsDataGridView dgvExport = (rsDataGridView)ExportControl;

                                        if (strTitle.ToUpper() == "KẾT QUẢ HOẠT ĐỘNG KINH DOANH")
                                        {
                                            if (dgvExport.Columns[k].Name == "NAM_NAY")
                                            {
                                                if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "10")
                                                    objRowValues[j - iFetch1, k] = "=E7-E8";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "20")
                                                    objRowValues[j - iFetch1, k] = "=E9-E10";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "30")
                                                    objRowValues[j - iFetch1, k] = "=E11+E12-E13-E15-E16";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "40")
                                                    objRowValues[j - iFetch1, k] = "=E18-E19";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "50")
                                                    objRowValues[j - iFetch1, k] = "=E17+E20";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "60")
                                                    objRowValues[j - iFetch1, k] = "=E21-E22-E23";
                                                else
                                                    objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;
                                            }
                                            else if (dgvExport.Columns[k].Name == "NAM_TRUOC")
                                            {
                                                if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "10")
                                                    objRowValues[j - iFetch1, k] = "=F7-F8";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "20")
                                                    objRowValues[j - iFetch1, k] = "=F9-F10";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "30")
                                                    objRowValues[j - iFetch1, k] = "=F11+F12-F13-F15-F16";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "40")
                                                    objRowValues[j - iFetch1, k] = "=F18-F19";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "50")
                                                    objRowValues[j - iFetch1, k] = "=F17+F20";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "60")
                                                    objRowValues[j - iFetch1, k] = "=F21-F22-F23";
                                                else
                                                    objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;
                                            }
                                            else if (dgvExport.Columns[k].Name == "NAM_NAY_LK")
                                            {
                                                if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "10")
                                                    objRowValues[j - iFetch1, k] = "=G7-G8";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "20")
                                                    objRowValues[j - iFetch1, k] = "=G9-G10";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "30")
                                                    objRowValues[j - iFetch1, k] = "=G11+G12-G13-G15-G16";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "40")
                                                    objRowValues[j - iFetch1, k] = "=G18-G19";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "50")
                                                    objRowValues[j - iFetch1, k] = "=G17+G20";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "60")
                                                    objRowValues[j - iFetch1, k] = "=G21-G22-G23";
                                                else
                                                    objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;
                                            }
                                            else if (dgvExport.Columns[k].Name == "NAM_TRUOC_LK")
                                            {
                                                if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "10")
                                                    objRowValues[j - iFetch1, k] = "=H7-H8";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "20")
                                                    objRowValues[j - iFetch1, k] = "=H9-H10";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "30")
                                                    objRowValues[j - iFetch1, k] = "=H11+H12-H13-H15-H16";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "40")
                                                    objRowValues[j - iFetch1, k] = "=H18-H19";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "50")
                                                    objRowValues[j - iFetch1, k] = "=H17+H20";
                                                else if (dgvExport.Rows[j].Cells["Ma_So"].Value.ToString() == "60")
                                                    objRowValues[j - iFetch1, k] = "=H21-H22-H23";
                                                else
                                                    objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;
                                            }
                                            else
                                                objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;
                                        }
                                        else
                                            objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;

                                        //if (dgvExport.Columns.Contains("CONG_THUC") && dgvExport.Rows[j].Cells["Cong_Thuc"].Value.ToString() != string.Empty)
                                        //{
                                        //    string strCong_Thuc = dgvExport.Rows[j].Cells["Cong_Thuc"].Value.ToString();

                                        //    string strAddress = wSheet.Cells[j + iNextRow, k + 1].Address;

                                        //    objRowValues[j - iFetch1, k] = "=" + strAddress;
                                        //}
                                        //else
                                        //    objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;

                                    }
                                }

                                if (iBold >= 0 && objRowValues[j - iFetch1, iBold] != null && objRowValues[j - iFetch1, iBold].GetType().Equals(typeof(bool)) && (bool)objRowValues[j - iFetch1, iBold])
                                {
                                    ((Microsoft.Office.Interop.Excel.Range)dataCellsFetch.Cells[j - iFetch1 + 1, 1]).EntireRow.Font.Bold = true;
                                }
                            }
                        }

                        dataCellsFetch.Value2 = objRowValues;

                        //release range
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        GC.SuppressFinalize(objRowValues);
                        GC.SuppressFinalize(dataCellsFetch);

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCellsFetch);
                        dataCellsFetch = null;

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        iFetch1 += iFetchLen;
                    }

                    ////release range
                    //System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCells);
                    //dataCells = null;

                }
                catch (Exception ex)
                {
                    Common.MsgCancel("Có lỗi xảy ra: " + ex.Message);
                }
            }

            Common.EndShowStatus();
            excel.Visible = true;
            wSheet.Columns.AutoFit();

            //Ghi file lên đĩa
            if (bOverwrite)
            {
                try
                {
                    Object emptyItem = System.Reflection.Missing.Value;
                    excel.DisplayAlerts = false;
                    excel.AlertBeforeOverwriting = true;

                    if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileName))) //.GetFullPath(strFileName)))
                    {
                        //wBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
                        //wBook.SaveAs(strFileName, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem);
                        wBook.SaveAs(strFileName, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem);
                    }
                }
                catch (Exception ex)
                {
                    //Common.MsgCancel("Không thể kết xuất được dữ liệu!");
                    //MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(wSheet);
            wSheet = null;

            System.Runtime.InteropServices.Marshal.ReleaseComObject(wBook);
            wBook = null;

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            excel = null;
        }
    }
}
