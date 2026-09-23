using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Data;
using RosySystem;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Element;

namespace RosyModule
{
    public static class ExportExcel
	{
		public static void ExportExcel_CtYc(DataRow drHeader, DataTable dtDetail, string strFile_Tag)
		{

			SaveFileDialog sfdlg = new SaveFileDialog();
			sfdlg.OverwritePrompt = true;
			sfdlg.InitialDirectory = Common.GetBufferValue("EXPORT_EXCEL_PATH");
			sfdlg.DefaultExt = "xls";
			sfdlg.Filter = "*.xls|*.xls";
			sfdlg.FileName = drHeader["Title"].ToString();

			if (sfdlg.ShowDialog() == DialogResult.OK)
			{
				Common.SetBufferValue("EXPORT_EXCEL_PATH", System.IO.Path.GetDirectoryName(sfdlg.FileName));
			}

			try
			{
				string strPath = sfdlg.FileName;
				object objFileContent = RosySystem.Common.Resource.LoadResource("EXPORT", strFile_Tag, "XLS");

				if (objFileContent != null)
					using (System.IO.Stream s = new System.IO.MemoryStream())
					{
						System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
						formatter.Serialize(s, objFileContent);
					}

				System.IO.FileStream fileStream = new System.IO.FileStream(strPath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
				fileStream.Write((byte[])objFileContent, 0, ((byte[])objFileContent).Length);
				fileStream.Close();

				//Export Data
				Object missing = Type.Missing;
				Microsoft.Office.Interop.Excel.Application excel = null;
				Microsoft.Office.Interop.Excel.Workbook wBook = null;
				Microsoft.Office.Interop.Excel.Worksheet wSheet = null;

				try
				{
					excel = new Microsoft.Office.Interop.Excel.Application();
					excel.DisplayAlerts = false;
					excel.Visible = false;

					wBook = excel.Workbooks.Open(sfdlg.FileName, Notify: false);


					wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
					excel.Worksheets.Copy((Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1]);
					wSheet = wBook.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
					wSheet.Name = strFile_Tag;
				}
				catch (Exception ex)
				{
					Common.MsgCancel("Không thể kết xuất được dữ liệu! Error " + ex.Message);

					excel.UserControl = false;
					excel.Quit();

					System.Runtime.InteropServices.Marshal.ReleaseComObject(wSheet);
					wSheet = null;

					System.Runtime.InteropServices.Marshal.ReleaseComObject(wBook);
					wBook = null;

					System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
					excel = null;
					return;
				}

				Microsoft.Office.Interop.Excel.Range currentFind = null;
				Microsoft.Office.Interop.Excel.Range firstFind = null;
				Microsoft.Office.Interop.Excel.Range Fruits = excel.get_Range("$A$1", "$Z$1000");

				string strAddress = ""; string strAddress_Format = "";
				Microsoft.Office.Interop.Excel.Range dataCells = null;

				#region Header

				foreach (DataColumn dc in drHeader.Table.Columns)
				{
					string strColumn = dc.ColumnName.ToUpper();

					currentFind = Fruits.Find("[" + strColumn + "]", missing, Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
													Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
													Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
													Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, false, missing, missing);
					firstFind = currentFind;
					if (firstFind != null)
					{
						strAddress = firstFind.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing);

						dataCells = excel.get_Range(strAddress);

						if (strColumn.StartsWith("NGAY"))
							dataCells.Value = Convert.ToDateTime(drHeader[strColumn]).ToShortDateString();
						else
							dataCells.Value = drHeader[strColumn];
					}
				}

				//currentFind = Fruits.Find("[TEN_DT_MERGE]", missing, Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
				//                                    Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
				//                                    Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
				//                                    Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, false, missing, missing);
				//firstFind = currentFind;
				//if (firstFind != null)
				//{
				//    strAddress = firstFind.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing);

				//    dataCells = excel.get_Range(strAddress);

				//    if (drHeader.Table.Columns.Contains("TEN_DT"))
				//        dataCells.Value = "Kính gửi: " + drHeader["TEN_DT"];
				//    else
				//        dataCells.Value = "Khách hàng (Customer): ";
				//}

				#endregion

				#region Detail

				//Fill Data Into Detail
				currentFind = Fruits.Find("[DETAIL]", missing, Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
													Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
													Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
													Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, false, missing, missing);
				firstFind = currentFind;
				if (firstFind != null)
				{
					strAddress = firstFind.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing);

					int iColLength, iRowLength, iNextRow = Convert.ToInt32(strAddress.Substring(3, strAddress.Length - 3));

					string strAddr1_TSo_Luong, strAddr2_TSo_Luong;
					object[,] objRowValues;

					iColLength = dtDetail.Columns.Count;
					iRowLength = dtDetail.Rows.Count;
					objRowValues = new object[iRowLength, iColLength];

					int iFetch1 = 0, iFetch2 = 0, iFetchLen = 10000;//Mỗi lần Fetch 10.000 dòng
					string strAddr1, strAddr2 = string.Empty;
					iFetch2 = Math.Min(iFetch1 + iFetchLen, iRowLength);

					Microsoft.Office.Interop.Excel.Range dataCellsFetch = null;

					if (iRowLength > 1)
					{
						strAddr1 = wSheet.Cells[iNextRow + iFetch1 + 1, 1].Address;
						strAddr2 = wSheet.Cells[iNextRow + iFetch2 - 1, iColLength].Address;

						dataCellsFetch = excel.get_Range(strAddr1, strAddr2);
						dataCellsFetch.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, missing);

						//Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)wSheet.Range[wSheet.Cells[iNextRow + iFetch1 + 1, 1], wSheet.Cells[iNextRow + iFetch2 - 1, iColLength]].EntireRow;
						//range.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
					}

					currentFind = (Microsoft.Office.Interop.Excel.Range)wSheet.Cells[iNextRow + iFetch1, iColLength - 1];
					strAddr1_TSo_Luong = currentFind.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing);

					currentFind = (Microsoft.Office.Interop.Excel.Range)wSheet.Cells[iNextRow + iFetch2 - 1, iColLength - 1];
					strAddr2_TSo_Luong = currentFind.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing);

					while (iFetch1 < iRowLength)
					{
						Common.ShowStatus("Exporting row at " + iFetch1.ToString());
						iFetch2 = Math.Min(iFetch1 + iFetchLen, iRowLength);

						strAddr1 = wSheet.Cells[iNextRow + iFetch1, 1].Address;
						strAddr2 = wSheet.Cells[iNextRow + iFetch2 - 1, iColLength].Address;

						dataCellsFetch = excel.get_Range(strAddr1, strAddr2);

						//Format line
						currentFind = (Microsoft.Office.Interop.Excel.Range)wSheet.Cells[iNextRow + iRowLength, iColLength];
						strAddress_Format = currentFind.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing);
						wSheet.Range[strAddress + ":" + strAddress_Format].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

						objRowValues = new object[Math.Min(iFetch2 - iFetch1, iFetchLen), iColLength]; //Tạo mảng với số dòng tối đa bằng iFetchLen

						for (int j = iFetch1; j < iFetch1 + iFetchLen; j++)
						{
							if (j < iRowLength) //Chỉ lấy dữ liệu khi j < Số dòng
							{
								for (int k = 0; k < iColLength; k++) //Điền dữ liệu vào objRowValues
								{
									if (dtDetail.Columns[k].DataType.Equals(typeof(DateTime)))
									{
										objRowValues[j - iFetch1, k] = "'" + Convert.ToDateTime(dtDetail.Rows[j][k]).ToShortDateString();
									}
									else if (Common.Inlist(dtDetail.Columns[k].DataType.Name.ToString().ToLower(), "double,decimal,int"))
									{
										if (Convert.ToDouble(dtDetail.Rows[j][k]) != 0)
											objRowValues[j - iFetch1, k] = dtDetail.Rows[j][k].ToString();
										else
											objRowValues[j - iFetch1, k] = string.Empty;
									}
									else if (Common.InlistLike(dtDetail.Columns[k].ColumnName, "FORMAT"))
									{
										objRowValues[j - iFetch1, k] = "'" + dtDetail.Rows[j][k].ToString();
									}
									else
									{
										objRowValues[j - iFetch1, k] = dtDetail.Rows[j][k].ToString();
									}
								}
							}
						}

						//Replace [TSO_LUONG]
						currentFind = Fruits.Find("[TSO_LUONG]", missing, Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
															Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
															Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
															Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, false, missing, missing);
						firstFind = currentFind;
						if (firstFind != null)
						{
							strAddress = firstFind.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing);
							dataCells = excel.get_Range(strAddress);
							dataCells.Value = "=SUM(" + strAddr1_TSo_Luong + ":" + strAddr2_TSo_Luong + ")";
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
				}

				#endregion

				((Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveWorkbook.Sheets["TEMPLATE"]).Activate();
				((Microsoft.Office.Interop.Excel.Worksheet)excel.Application.ActiveWorkbook.Sheets["TEMPLATE"]).Delete();

				//((Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveWorkbook.ActiveSheet).Protect("Rosy123", missing, missing, missing, missing, false, false, false, false, false, false, false, false, false, false, missing);
				//wBook.Protect("Rosy123", true, false);

				wBook.Save();
				wBook.Close();

				excel.UserControl = false;
				excel.Quit();

				System.Runtime.InteropServices.Marshal.ReleaseComObject(wSheet);
				wSheet = null;

				System.Runtime.InteropServices.Marshal.ReleaseComObject(wBook);
				wBook = null;

				System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
				excel = null;

				System.Diagnostics.Process.Start(sfdlg.FileName);
			}
			catch { return; }


		}
        public static void ExportToExcel(this System.Data.DataTable DataTable, string ExcelFilePath = null)
        {
           try
        {
            int ColumnsCount;

            if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");

            // load excel, and create a new workbook
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbooks.Add();

            // single worksheet
            Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;

            object[] Header = new object[ColumnsCount];

            // column headings               
            for (int i = 0; i < ColumnsCount; i++)
                Header[i] = DataTable.Columns[i].ColumnName;

            Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
            HeaderRange.Value = Header;
            HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            HeaderRange.Font.Bold = true;

            // DataCells
            int RowsCount = DataTable.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];

            for (int j = 0; j < RowsCount; j++)
                for (int i = 0; i < ColumnsCount; i++)
                    Cells[j, i] = DataTable.Rows[j][i];

            Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;

            // check fielpath
            if (ExcelFilePath != null && ExcelFilePath != "")
            {
                try
                {
                    Worksheet.SaveAs(ExcelFilePath);
                    Excel.Quit();
                  MessageBox.Show("Excel file saved!");
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                        + ex.Message);
                }
            }
            else    // no filepath is given
            {
                Excel.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("ExportToExcel: \n" + ex.Message);
        }
    

        }
        public static System.Data.DataTable ReadExcel(string strFilePath, int iSheetIndex, int iRowHeader, int iRowEnd, int iColEnd)
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

                    ////Điền dữ liệu vào ComboBox
                    ////cboSheet.DataSource = ((Microsoft.Office.Interop.Excel._Workbook)excelWB).Names;
                    //for (int i = 1; i <= excelWB.Sheets.Count; i++)
                    //{
                    //    ((Microsoft.Office.Interop.Excel._Worksheet)excelWB.Worksheets[i]).Name

                    //    //(Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[1]

                    //    cboSheet.Items.Add(((Microsoft.Office.Interop.Excel._Worksheet)excelWB.Worksheets[i]).Name);

                    //    if (i == 1) //Lấy Sheet đầu tiên làm mặc định
                    //        cboSheet.SelectedIndex = 0;
                    //}

                    excelWS = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[iSheetIndex];

                    #region
                    ////Điền vị trí dòng dữ liệu Header và giới hạn dòng (RowEnd)
                    //int iLastRowEnd = 0;
                    //for (int i = 1; i < excelWS.Rows.Count; i++)
                    //{
                    //    if (numRowHeader.Value == 0) //Nếu chưa có Header
                    //    {
                    //        if (excelWS.get_Range(excelApp.Cells[i, 1], excelApp.Cells[i, 1]).Value2.ToString().Trim() != "")
                    //        {
                    //            numRowHeader.Value = i;
                    //        }
                    //    }
                    //    else //Đã xác định được Header, xác định thêm vị trí kết thúc dòng: Bằng vị trí dòng cuối cùng có dữ liệu + 10 dòng rỗng nữa
                    //    {
                    //        if (excelWS.get_Range(excelApp.Cells[i, 1], excelApp.Cells[i, 1]).Value2 != null)
                    //            iLastRowEnd ++;
                    //        else
                    //            iLastRowEnd = 0;

                    //        if (iLastRowEnd >= 10)
                    //        {
                    //            numRowEnd.Value = i;
                    //            break;
                    //        }
                    //    }
                    //}

                    ////Điền vị trí giới hạn Cột (ColEnd)
                    //if (numRowHeader.Value > 0)
                    //{
                    //    int iLastColEnd = 0;
                    //    for (int i = 1; i < excelWS.Columns.Count; i++)
                    //    {
                    //        if (excelWS.get_Range(excelApp.Cells[numRowHeader.Value, i], excelApp.Cells[numRowHeader.Value, i]).Value2 != null)
                    //            iLastColEnd ++;
                    //        else
                    //            iLastColEnd = 0;

                    //        if (iLastColEnd >= 10)
                    //        {
                    //            numColEnd.Value = i;
                    //            break;
                    //        }
                    //    }
                    //}
                    #endregion

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

                        if (strColName.StartsWith("Tien") || strColName.StartsWith("Ps_No") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("So_Luong") || strColName.StartsWith("Gia"))
                            dtImport.Columns.Add(strColName, typeof(double));
                        else
                            dtImport.Columns.Add(strColName, typeof(string));
                    }

                    //Dua du lieu vao: Duyet dong
                    for (int i = Convert.ToInt32(iRowHeader + 1); i <= iRowEnd; i++)
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
                                    if (strColName.StartsWith("Tien") || strColName.StartsWith("Ps_No") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("So_Luong") || strColName.StartsWith("Gia"))
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
	}

		
}
