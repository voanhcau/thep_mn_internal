using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RosySystem.Control;
using RosySystem.Common;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using RosySystem.Data;
//using ExcelDataReader;

namespace RosyModule.General
{
	public partial class frmReadExcel_ThueEasy : RosySystem.Customize.frmView
	{
		public System.Data.DataTable dtImport;
		BindingSource bdsImport = new BindingSource();

		public bool isAccept = false;
		string strMa_Ct = "";
		

		public frmReadExcel_ThueEasy()
		{
			InitializeComponent();

			btFilePath.Click += new EventHandler(btFilePath_Click);
			btRefresh.Click += new EventHandler(btRefresh_Click);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public override void Load()
		{
			if (Common.GetBufferValue("ImportVoucher_RowHeader") != null)
				numRowHeader.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_RowHeader"));
			else
				numRowHeader.Value = 1;

			if (Common.GetBufferValue("ImportVoucher_RowEnd") != null)
				numRowEnd.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_RowEnd"));
			else
				numRowEnd.Value = 100;

			if (Common.GetBufferValue("ImportVoucher_ColEnd") != null)
				numColEnd.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_ColEnd"));
			else
				numColEnd.Value = 35;

			
			//txtObject.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("IMPORT_CT");//"MA_KM,MA_BP,TK_NO,MA_KHO"; //,TK_CO



			this.BindingLanguage();
			
			this.Show();
		}

		public void Load(string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;
			
			this.Load();
		}

		void FillData()
		{
			//dtImport = Common.ReadExcel(txtFilePath.Text, 1, Convert.ToInt32(numRowHeader.Value), Convert.ToInt32(numRowEnd.Value), Convert.ToInt32(numColEnd.Value));
			dtImport = DocFileExcelBangKeMuaVao(txtFilePath.Text);

			if (dtImport != null)
			{
                
			    bdsImport.DataSource = dtImport;
				
				dgvImport.AutoGenerateColumns = true;
				dgvImport.DataSource = bdsImport;

				this.ExportControl = dgvImport;
				this.bdsSearch = bdsImport;
			}
		}
		private DataTable DocFileExcelBangKeMuaVao(string filePath)
		{
			DataTable dt = new DataTable();

			for (int i = 1; i <= 13; i++)
			{
				//if(i < 3)
				//	dt.Columns.Add("Cot" + i.ToString(), typeof(object));
				if (i == 1)
					dt.Columns.Add("TT", typeof(object));
				if (i == 2)
					dt.Columns.Add("Ma_Ky_Hieu_HDon", typeof(string));
				if (i == 3)
					dt.Columns.Add("So_Seri0", typeof(string));
				if (i == 4)
					dt.Columns.Add("So_Ct0", typeof(string));
				if (i == 5)
					dt.Columns.Add("Ngay_Ct0", typeof(object));
				if (i == 6)
					dt.Columns.Add("Ten_DtGtGt", typeof(string));
				if (i == 7)
					dt.Columns.Add("Ma_So_Thue", typeof(string));
				if (i == 8)
					dt.Columns.Add("Tien", typeof(object));
				if (i == 9)
					dt.Columns.Add("Tien3", typeof(object));
				if (i == 10)
					dt.Columns.Add("Trang_Thai_HD", typeof(string));
				if (i == 11)
					dt.Columns.Add("Ghi_Chu", typeof(string));
				if (i == 12)
					dt.Columns.Add("Trang_Thai_MST", typeof(string));
				if (i == 13)
					dt.Columns.Add("Tien_Phi", typeof(string));
			}

			
			Excel.Application xlApp = null;
			Excel.Workbook workbook = null;
			Excel.Worksheet worksheet = null;

			Excel.Range usedRange = null;
			Excel.Range startCell = null;
			Excel.Range endCell = null;
			Excel.Range dataRange = null;

			try
			{
				xlApp = new Excel.Application();
				xlApp.Visible = false;
				xlApp.DisplayAlerts = false;

				workbook = xlApp.Workbooks.Open(
					filePath,
					Type.Missing,
					true,          // ReadOnly = true
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing,
					Type.Missing
				);

				// Lấy sheet đầu tiên
				worksheet = workbook.Worksheets[1] as Excel.Worksheet;

				usedRange = worksheet.UsedRange;

				int lastRow = usedRange.Row + usedRange.Rows.Count - 1;

				// Nếu file không có dữ liệu từ dòng 6 trở đi
				if (lastRow < 6)
					return dt;

				// Vùng cần đọc: từ dòng 6, cột 1 đến dòng cuối, cột 13
				startCell = worksheet.Cells[6, 1] as Excel.Range;
				endCell = worksheet.Cells[lastRow, 13] as Excel.Range;

				dataRange = worksheet.Range[startCell, endCell];

				object[,] data = dataRange.Value2 as object[,];

				if (data == null)
					return dt;

				int rowCount = data.GetLength(0);

				for (int r = 1; r <= rowCount; r++)
				{
					// Cột thứ 2 trong Excel tương ứng data[r, 2]
					object giaTriCot2 = data[r, 2];

					// Gặp cột thứ 2 rỗng thì dừng đọc
					if (LaGiaTriRong(giaTriCot2))
						break;

					DataRow row = dt.NewRow();

					// Lấy cột 1 đến cột 13
					for (int c = 1; c <= 13; c++)
					{
						object value = data[r, c];

						if (LaGiaTriRong(value))
							row[c - 1] = DBNull.Value;
						else
							row[c - 1] = value;
					}

					dt.Rows.Add(row);
				}

				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception("Không đọc được file Excel. Chi tiết: " + ex.Message, ex);
			}
			finally
			{
				// Đóng workbook và Excel
				if (workbook != null)
				{
					workbook.Close(false, Type.Missing, Type.Missing);
				}

				if (xlApp != null)
				{
					xlApp.Quit();
				}

				// Giải phóng COM object để tránh treo EXCEL.EXE trong Task Manager
				ReleaseComObject(dataRange);
				ReleaseComObject(endCell);
				ReleaseComObject(startCell);
				ReleaseComObject(usedRange);
				ReleaseComObject(worksheet);
				ReleaseComObject(workbook);
				ReleaseComObject(xlApp);

				GC.Collect();
				GC.WaitForPendingFinalizers();

				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			//using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			//{
			//	using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
			//	{
			//		int rowIndex = 0;

			//		while (reader.Read())
			//		{
			//			rowIndex++;

			//			// Bỏ qua dòng 1 đến dòng 5
			//			if (rowIndex < 6)
			//				continue;

			//			// Cột thứ 2 trong Excel là index 1
			//			object giaTriCot2 = reader.GetValue(1);

			//			// Gặp cột thứ 2 rỗng thì dừng
			//			if (giaTriCot2 == null || string.IsNullOrWhiteSpace(giaTriCot2.ToString()))
			//				break;

			//			DataRow row = dt.NewRow();

			//			// Lấy cột 1 đến cột 13
			//			for (int col = 0; col < 13; col++)
			//			{
			//				object value = reader.GetValue(col);
			//				row[col] = value == null ? DBNull.Value : value;
			//			}

			//			dt.Rows.Add(row);
			//		}
			//	}
			//}

			return dt;
		}
		private bool LaGiaTriRong(object value)
		{
			if (value == null)
				return true;

			if (value == DBNull.Value)
				return true;

			if (string.IsNullOrWhiteSpace(value.ToString()))
				return true;

			return false;
		}
		private void ReleaseComObject(object obj)
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
				// Không throw lỗi tại đây để tránh làm hỏng luồng import
			}
		}
		void btFilePath_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "xlsx files (*.xlsx)|*.xlsx";
			ofd.RestoreDirectory = true;

			if (Common.GetBufferValue("ImportExcelPath") != string.Empty)
				ofd.InitialDirectory = Common.GetBufferValue("ImportExcelPath");
			else
				ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtFilePath.Text = ofd.FileName;

				Common.SetBufferValue("ImportExcelPath", System.IO.Path.GetDirectoryName(ofd.FileName));

				this.FillData();
			}
		}

		
	
		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			//Common.SetBufferValue("ImportVoucher_RowHeader", numRowHeader.Value);
			//Common.SetBufferValue("ImportVoucher_RowEnd", numRowEnd.Value);
			//Common.SetBufferValue("ImportVoucher_ColEnd", numColEnd.Value);
            if (Save())
            {
                Common.MsgOk("Đã cập nhật xong!");
            }
            else
            { Common.MsgOk("Cập nhật không thành công!"); }
            //this.isAccept = true;
            //this.Close();
		}
        bool Save()
        {

            if (dtImport != null)
            {
                SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
                SqlCommand sqlCom = sqlCon.CreateCommand();

                sqlCom.CommandText = "sp_Update_Ct";
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlCom.Parameters.Clear();
                sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());

                //Tạo Table cho TVP_PH
                SqlParameter paraCt = new SqlParameter();
                paraCt.SqlDbType = SqlDbType.Structured;
                paraCt.ParameterName = "@TVP_Import";

                sqlCom.CommandText = "sp_Update_IMPDATATHUE";
                //sp_Update_KHVTPT

                //TVP_CT
                paraCt.TypeName = "TVP_IMPDATATHUE";
                paraCt.Value = Voucher.GetTVPValue("R82DATATHUE_IMP", "TVP_IMPDATATHUE", dtImport);
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
            else
            {
                Common.MsgOk("Không có dữ liệu cập nhật!!!");
                return false;
            }
            return true;
        }
		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

	}
}
