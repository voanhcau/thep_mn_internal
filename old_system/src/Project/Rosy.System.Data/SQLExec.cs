using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RosySystem.Element;

namespace RosySystem.Data
{
	public class SQLExec
	{
		#region Tao SqlCommand da gan SqlConnection vao

		public static SqlCommand GetSQLCommand()
		{
			return GetSQLCommand("");
		}

		/// <summary>
		/// Ham tra ve 1 SqlCommand, da duoc gan connection.open()
		/// </summary>
		/// <param name="strSQLExec">Chuoi thuc thi SQL</param>
		/// <returns>SqlCommand</returns>
		public static SqlCommand GetSQLCommand(string strSQLExec)
		{
			//SqlCommand sqlCom = new SqlCommand();
			SqlCommand sqlCom = Element.Element.sysConnection.CreateCommand();

			sqlCom.CommandText = strSQLExec;
			sqlCom.Connection = Element.Element.sysConnection;
			sqlCom.CommandTimeout = 0;

			if (sqlCom.Connection.State != ConnectionState.Open)
			{
				try
				{
					sqlCom.Connection.Open();
					new SqlCommand("SET DATEFORMAT DMY", sqlCom.Connection).ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
				}
			}

			return sqlCom;
		}

		#endregion

		#region Thuc thi (Execute) SQLServer: true - thanh cong, false - That bai
		/// <summary>
		/// Thực thi một câu lệnh SQL (CommandText)
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <returns>return true nếu thành công, false nếu thất bại</returns>
		public static bool Execute(string strSQLExec)
		{
			return Execute(strSQLExec, CommandType.Text);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL hoac Sp
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh Sql, Sp_Name</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>return true nếu thành công, false nếu thất bại</returns>
		public static bool Execute(string strSQLExec, CommandType cmdType)
		{
			return Execute(strSQLExec, new Hashtable(), cmdType);
		}

		/// <summary>
		/// Thực thi một câu lệnh SQL (CommandText)
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="drSQLPara">Tham so truyen vao luu o DataRow</param>
		/// <returns>return true nếu thành công, false nếu thất bại</returns>
		public static bool Execute(string strSQLExec, DataRow drSQLPara)
		{
			return Execute(strSQLExec, drSQLPara, CommandType.Text);
		}

		/// <summary>
		/// Thực thi một câu lệnh SQL hoac Sp
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh Sql, Sp_Name</param>
		/// <param name="strSQLPara">Tham so truyen vao luu trong DataRow</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>return true nếu thành công, false nếu thất bại</returns>
		public static bool Execute(string strSQLExec, DataRow drSQLPara, CommandType cmdType)
		{
			Hashtable htSQLPara = new Hashtable();

			foreach (DataColumn dc in drSQLPara.Table.Columns)
			{
				string strParaName = dc.ColumnName.Replace("@", "").ToUpper();
				object objParaValue = drSQLPara[dc];

				htSQLPara.Add(strParaName, objParaValue);
			}

			return Execute(strSQLExec, htSQLPara, cmdType);
		}

		/// <summary>
		/// Thực thi một câu lệnh SQL (CommandText)
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">Mang danh sach cac tham so truyen vao</param>
		/// <param name="objArrParaValue">Mang gia tri cac tham so truyen vao</param>
		/// <returns>return true nếu thành công, false nếu thất bại</returns>
		public static bool Execute(string strSQLExec, string[] strArrParaName, object[] objArrParaValue)
		{
			return Execute(strSQLExec, strArrParaName, objArrParaValue, CommandType.Text);
		}

		/// <summary>
		/// Thực thi một câu lệnh SQL hoac Sp
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">Mang danh sach cac tham so truyen vao</param>
		/// <param name="objArrParaValue">Mang gia tri cac tham so truyen vao</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>return true nếu thành công, false nếu thất bại</returns>
		public static bool Execute(string strSQLExec, string[] strArrParaName, object[] objArrParaValue, CommandType cmdType)
		{
			Hashtable htSQLPara = new Hashtable();

			for (int i = 0; i <= strArrParaName.Length - 1; i++)
			{
				string strParaName = strArrParaName[i].Replace("@", "").ToUpper();
				object objParaValue = objArrParaValue[i];

				if (!htSQLPara.Contains(strParaName))
					htSQLPara.Add(strParaName, objParaValue);
			}

			return Execute(strSQLExec, htSQLPara, cmdType);
		}

		/// <summary>
		/// Thực thi một câu lệnh SQL hoac Sp
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh Sql, Sp_Name</param>
		/// <param name="htSQLPara">Tham so truyen vao luu trong HashTable</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>return true nếu thành công, false nếu thất bại</returns>
		public static bool Execute(string strSQLExec, Hashtable htSQLPara, CommandType cmdType)
		{
			SqlCommand sqlCom = GetSQLCommand();

			sqlCom.CommandText = strSQLExec;
			sqlCom.CommandType = cmdType;

			if (htSQLPara.Count > 0)
			{//Add Parameter

				if (sqlCom.CommandType == CommandType.StoredProcedure)
				{//Duyet tung Parameters trong sp

					string strKey = "Object_id = Object_id('" + strSQLExec + "')";
					DataTable dtPara = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

					foreach (DataRow dr in dtPara.Rows)
					{
						string strColumnName = ((string)dr["Name"]).Replace("@", "").ToUpper();

						if (!htSQLPara.Contains(strColumnName))
							continue;

						sqlCom.Parameters.AddWithValue("@" + strColumnName, htSQLPara[strColumnName]);
					}
				}
				else
				{//Duyet tung Paramaters trong strSQLExec

					string strSQLPara = GetSplitList(strSQLExec, "@");
					string[] strArrSQLPara = strSQLPara.Split(',');

					for (int i = 0; i <= strArrSQLPara.Length - 1; i++)
					{
						string strColumnName = strArrSQLPara[i].Trim().Replace("@", "").ToUpper();

						if (!htSQLPara.Contains(strColumnName))
							continue;

						sqlCom.Parameters.AddWithValue("@" + strColumnName, htSQLPara[strColumnName]);
					}
				}
			}

			try
			{
				sqlCom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
				return false;
			}
			return true;
		}

		#endregion

		#region Thuc thi (Execute) SQLServer: tra ve ket qua la DataTable

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <returns>Ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec)
		{
			return ExecuteReturnDt(strSQLExec, CommandType.Text);
		}

		/// <summary>
		/// Thực hiện một câu lệnh SQL hoac Sp: Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh Sql, Sp_Name</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>Ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec, CommandType cmdType)
		{
			return ExecuteReturnDt(strSQLExec, new Hashtable(), cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="drSQLPara">Tham so truyen vao luu o DataRow</param>
		/// <returns>Ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec, DataRow drSQLPara)
		{
			return ExecuteReturnDt(strSQLExec, drSQLPara, CommandType.Text);
		}

		/// <summary>
		/// Phuong thuc thuc thi cau lenh SQL hay Sp: Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Cau lenh SQL, Sp_Name</param>
		/// <param name="drSQLPara">Tham so luu trong datarow</param>
		/// <returns>Tra ve ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec, DataRow drSQLPara, CommandType cmdType)
		{
			Hashtable htSQLPara = new Hashtable();

			foreach (DataColumn dc in drSQLPara.Table.Columns)
			{
				string strParaName = dc.ColumnName.Replace("@", "").ToUpper();
				object objParaValue = drSQLPara[dc];

				htSQLPara.Add(strParaName, objParaValue);
			}

			return ExecuteReturnDt(strSQLExec, htSQLPara, cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">1 tham so truyen vao</param>
		/// <param name="objArrParaValue">1 gia tri tham so truyen vao</param>
		/// <returns>Ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec, string strParaName, object objParaValue)
		{
			return ExecuteReturnDt(strSQLExec, strParaName, objParaValue, CommandType.Text);
		}

		/// <summary>
		/// Phuong thuc thuc thi cau lenh SQL hay Sp: Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">1 tham so truyen vao</param>
		/// <param name="objArrParaValue">1 gia tri tham so truyen vao</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>Ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec, string strParaName, object objParaValue, CommandType cmdType)
		{
			return ExecuteReturnDt(strSQLExec, new string[] { strParaName }, new object[] { objParaValue }, cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">Mang ten cac tham so truyen vao</param>
		/// <param name="objArrParaValue">Mang gia tri cac tham so truyen vao</param>
		/// <returns>Ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec, string[] strArrParaName, object[] objArrParaValue)
		{
			return ExecuteReturnDt(strSQLExec, strArrParaName, objArrParaValue, CommandType.Text);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">Mang ten cac tham so truyen vao</param>
		/// <param name="objArrParaValue">Mang gia tri cac tham so truyen vao</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>Ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec, string[] strArrParaName, object[] objArrParaValue, CommandType cmdType)
		{
			Hashtable htSQLPara = new Hashtable();

			for (int i = 0; i <= strArrParaName.Length - 1; i++)
			{
				string strParaName = strArrParaName[i].Replace("@", "").ToUpper();
				object objParaValue = objArrParaValue[i];

				if (!htSQLPara.Contains(strParaName))
					htSQLPara.Add(strParaName, objParaValue);
			}

			return ExecuteReturnDt(strSQLExec, htSQLPara, cmdType);
		}

		/// <summary>
		/// Phuong thuc thuc thi cau lenh SQL hay Sp: Tra ve ket qua DataTable
		/// </summary>
		/// <param name="strSQLExec">Cau lenh SQL, Sp_Name</param>
		/// <param name="htSQLPara">Tham so luu trong HastTable</param>
		/// <returns>Tra ve ket qua la DataTable</returns>
		public static DataTable ExecuteReturnDt(string strSQLExec, Hashtable htSQLPara, CommandType cmdType)
		{
			SqlCommand sqlCom = GetSQLCommand();

			sqlCom.CommandText = strSQLExec;
			sqlCom.CommandType = cmdType;

			if (htSQLPara.Count > 0)
			{//Add Parameter

				if (sqlCom.CommandType == CommandType.StoredProcedure)
				{//Duyet tung Parameters trong sp

					string strKey = "Object_id = Object_id('" + strSQLExec + "')";
					DataTable dtPara = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

					foreach (DataRow dr in dtPara.Rows)
					{
						string strColumnName = ((string)dr["Name"]).Replace("@", "").ToUpper();

						if (!htSQLPara.Contains(strColumnName))
							continue;

						sqlCom.Parameters.AddWithValue("@" + strColumnName, htSQLPara[strColumnName]);
					}
				}
				else
				{//Duyet tung Paramaters trong strSQLExec

					string strSQLPara = GetSplitList(strSQLExec, "@").Replace(" ", "");
					string[] strArrSQLPara = strSQLPara.Split(',');

					for (int i = 0; i <= strArrSQLPara.Length - 1; i++)
					{
						string strColumnName = strArrSQLPara[i].Trim().Replace("@", "").ToUpper();

						if (!htSQLPara.Contains(strColumnName))
							continue;

						sqlCom.Parameters.AddWithValue("@" + strColumnName, htSQLPara[strColumnName]);
					}
				}
			}

			SqlDataAdapter da = new SqlDataAdapter(sqlCom);
			DataTable dtReturn = new DataTable();

			try
			{
				da.Fill(dtReturn);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error :" + ex.Message);
				string strErrorExec = string.Empty;
				for (int i = 0; i < sqlCom.Parameters.Count - 1; i++)
				{
					strErrorExec += strErrorExec == string.Empty ? " " : ",";
					strErrorExec += sqlCom.Parameters[i].Value.GetType().Name == "String" ? "'" : "";
					strErrorExec += sqlCom.Parameters[i].Value.ToString();
					strErrorExec += sqlCom.Parameters[i].Value.GetType().Name == "String" ? "'" : "";
				}
				Clipboard.SetText(sqlCom.CommandText + " " + strErrorExec);

				return null;
			}

			foreach (DataColumn dc in dtReturn.Columns)
			{
				dc.ColumnName = dc.ColumnName.ToUpper();

				if (dc.DataType.Name == "DateTime")
				{
					foreach (DataRow dr in dtReturn.Rows)
					{
						if (dr[dc] == DBNull.Value)
							continue;

						if ((DateTime)dr[dc] == Element.Element.sysNgay_Min)
							dr[dc] = DBNull.Value;
					}
				}
			}

			return dtReturn;
		}

		#endregion

		#region Thuc thi (Execute) SQLServer: tra ve ket qua la DataSet

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataSet
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <returns>Ket qua la DataSet</returns>
		public static DataSet ExecuteReturnDs(string strSQLExec)
		{
			return ExecuteReturnDs(strSQLExec, CommandType.Text);
		}

		/// <summary>
		/// Thực hiện một câu lệnh SQL hoac Sp: Tra ve ket qua DataSet
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh Sql, Sp_Name</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>Ket qua la DataSet</returns>
		public static DataSet ExecuteReturnDs(string strSQLExec, CommandType cmdType)
		{
			return ExecuteReturnDs(strSQLExec, new Hashtable(), cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataSet
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="drSQLPara">Tham so truyen vao luu o DataRow</param>
		/// <returns>Ket qua la DataSet</returns>
		public static DataSet ExecuteReturnDs(string strSQLExec, DataRow drSQLPara)
		{
			return ExecuteReturnDs(strSQLExec, drSQLPara, CommandType.Text);
		}

		/// <summary>
		/// Phuong thuc thuc thi cau lenh SQL hay Sp: Tra ve ket qua DataSet
		/// </summary>
		/// <param name="strSQLExec">Cau lenh SQL, Sp_Name</param>
		/// <param name="drSQLPara">Tham so luu trong datarow</param>
		/// <returns>Tra ve ket qua la DataSet</returns>
		public static DataSet ExecuteReturnDs(string strSQLExec, DataRow drSQLPara, CommandType cmdType)
		{
			Hashtable htSQLPara = new Hashtable();

			foreach (DataColumn dc in drSQLPara.Table.Columns)
			{
				string strParaName = dc.ColumnName.Replace("@", "").ToUpper();
				object objParaValue = drSQLPara[dc];

				htSQLPara.Add(strParaName, objParaValue);
			}

			return ExecuteReturnDs(strSQLExec, htSQLPara, cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataSet
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">1 tham so truyen vao</param>
		/// <param name="objArrParaValue">1 gia tri tham so truyen vao</param>
		/// <returns>Ket qua la DataSet</returns>
		public static DataSet ExecuteReturnDs(string strSQLExec, string strParaName, object objParaValue)
		{
			return ExecuteReturnDs(strSQLExec, strParaName, objParaValue, CommandType.Text);
		}

		/// <summary>
		/// Phuong thuc thuc thi cau lenh SQL hay Sp: Tra ve ket qua DataSet
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">1 tham so truyen vao</param>
		/// <param name="objArrParaValue">1 gia tri tham so truyen vao</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>Ket qua la DataSet</returns>
		public static DataSet ExecuteReturnDs(string strSQLExec, string strParaName, object objParaValue, CommandType cmdType)
		{
			return ExecuteReturnDs(strSQLExec, new string[] { strParaName }, new object[] { objParaValue }, cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua DataSet
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">Mang ten cac tham so truyen vao</param>
		/// <param name="objArrParaValue">Mang gia tri cac tham so truyen vao</param>
		/// <returns>Ket qua la DataSet</returns>
		public static DataSet ExecuteReturnDs(string strSQLExec, string[] strArrParaName, object[] objArrParaValue)
		{
			return ExecuteReturnDs(strSQLExec, strArrParaName, objArrParaValue, CommandType.Text);
		}

		public static DataSet ExecuteReturnDs(string strSQLExec, string[] strArrParaName, object[] objArrParaValue, CommandType cmdType)
		{
			Hashtable htSQLPara = new Hashtable();

			for (int i = 0; i <= strArrParaName.Length - 1; i++)
			{
				string strParaName = strArrParaName[i].Replace("@", "").ToUpper();
				object objParaValue = objArrParaValue[i];

				if (!htSQLPara.Contains(strParaName))
					htSQLPara.Add(strParaName, objParaValue);
			}

			return ExecuteReturnDs(strSQLExec, htSQLPara, cmdType);
		}

		public static DataSet ExecuteReturnDs(string strSQLExec, Hashtable htSQLPara, CommandType cmdType)
		{
			SqlCommand sqlCom = GetSQLCommand();

			sqlCom.CommandText = strSQLExec;
			sqlCom.CommandType = cmdType;

			if (htSQLPara.Count > 0)
			{//Add Parameter

				if (sqlCom.CommandType == CommandType.StoredProcedure)
				{//Duyet tung Parameters trong sp

					string strKey = "Object_id = Object_id('" + strSQLExec + "')";
					DataTable dtPara = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

					foreach (DataRow dr in dtPara.Rows)
					{
						string strColumnName = ((string)dr["Name"]).Replace("@", "").ToUpper();

						if (!htSQLPara.Contains(strColumnName))
							continue;

						sqlCom.Parameters.AddWithValue("@" + strColumnName, htSQLPara[strColumnName]);
					}
				}
				else
				{//Duyet tung Paramaters trong strSQLExec

					string strSQLPara = GetSplitList(strSQLExec, "@").Replace(" ", "");
					string[] strArrSQLPara = strSQLPara.Split(',');

					for (int i = 0; i <= strArrSQLPara.Length - 1; i++)
					{
						string strColumnName = strArrSQLPara[i].Trim().Replace("@", "").ToUpper();

						if (!htSQLPara.Contains(strColumnName))
							continue;

						sqlCom.Parameters.AddWithValue("@" + strColumnName, htSQLPara[strColumnName]);
					}
				}
			}

			SqlDataAdapter da = new SqlDataAdapter(sqlCom);
			DataSet dsReturn = new DataSet();

			try
			{
				da.Fill(dsReturn);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error :" + ex.Message);
				string strErrorExec = string.Empty;
				for (int i = 0; i < sqlCom.Parameters.Count - 1; i++)
				{
					strErrorExec += strErrorExec == string.Empty ? " " : ",";
					strErrorExec += sqlCom.Parameters[i].Value.GetType().Name == "String" ? "'" : "";
					strErrorExec += sqlCom.Parameters[i].Value.ToString();
					strErrorExec += sqlCom.Parameters[i].Value.GetType().Name == "String" ? "'" : "";
				}
				Clipboard.SetText(sqlCom.CommandText + " " + strErrorExec);

				return null;
			}

			foreach (DataTable dt in dsReturn.Tables)
			{
				foreach (DataColumn dc in dt.Columns)
				{
					dc.ColumnName = dc.ColumnName.ToUpper();

					if (dc.DataType.Name == "DateTime")
					{
						foreach (DataRow dr in dt.Rows)
						{
							if (dr[dc] == DBNull.Value)
								continue;

							if ((DateTime)dr[dc] == Element.Element.sysNgay_Min)
								dr[dc] = DBNull.Value;
						}
					}
				}
			}

			return dsReturn;
		}
		#endregion

		#region Thuc thi (Execute) SQLServer: tra ve ket qua la 1 Object Value

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua 1 Object value
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <returns>Ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec)
		{
			return ExecuteReturnValue(strSQLExec, CommandType.Text);
		}

		/// <summary>
		/// Thực hiện một câu lệnh SQL hoac Sp: Tra ve ket qua Object value
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh Sql, Sp_Name</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>Ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec, CommandType cmdType)
		{
			return ExecuteReturnValue(strSQLExec, new Hashtable(), cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua Object value
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="drSQLPara">Tham so truyen vao luu o DataRow</param>
		/// <returns>Ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec, DataRow drSQLPara)
		{
			return ExecuteReturnValue(strSQLExec, drSQLPara, CommandType.Text);
		}

		/// <summary>
		/// Phuong thuc thuc thi cau lenh SQL hay Sp: Tra ve ket qua Object value
		/// </summary>
		/// <param name="strSQLExec">Cau lenh SQL, Sp_Name</param>
		/// <param name="drSQLPara">Tham so luu trong datarow</param>
		/// <returns>Tra ve ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec, DataRow drSQLPara, CommandType cmdType)
		{
			Hashtable htSQLPara = new Hashtable();

			foreach (DataColumn dc in drSQLPara.Table.Columns)
			{
				string strParaName = dc.ColumnName.Replace("@", "").ToUpper();
				object objParaValue = drSQLPara[dc];

				htSQLPara.Add(strParaName, objParaValue);
			}

			return ExecuteReturnValue(strSQLExec, htSQLPara, cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua Object value
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">1 tham so truyen vao</param>
		/// <param name="objArrParaValue">1 gia tri tham so truyen vao</param>
		/// <returns>Ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec, string strParaName, object objParaValue)
		{
			return ExecuteReturnValue(strSQLExec, strParaName, objParaValue, CommandType.Text);
		}

		/// <summary>
		/// Phuong thuc thuc thi cau lenh SQL hay Sp: Tra ve ket qua Object value
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">1 tham so truyen vao</param>
		/// <param name="objArrParaValue">1 gia tri tham so truyen vao</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>Ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec, string strParaName, object objParaValue, CommandType cmdType)
		{
			return ExecuteReturnValue(strSQLExec, new string[] { strParaName }, new object[] { objParaValue }, cmdType);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua Object value
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">Mang ten cac tham so truyen vao</param>
		/// <param name="objArrParaValue">Mang gia tri cac tham so truyen vao</param>
		/// <returns>Ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec, string[] strArrParaName, object[] objArrParaValue)
		{
			return ExecuteReturnValue(strSQLExec, strArrParaName, objArrParaValue, CommandType.Text);
		}

		/// <summary>
		/// Thực thi câu lệnh SQL (CommandText): Tra ve ket qua Object value
		/// </summary>
		/// <param name="strSQLExec">Câu lệnh SQL</param>
		/// <param name="strArrParaName">Mang ten cac tham so truyen vao</param>
		/// <param name="objArrParaValue">Mang gia tri cac tham so truyen vao</param>
		/// <param name="cmdType">CommandText, StoreProcedure</param>
		/// <returns>Ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec, string[] strArrParaName, object[] objArrParaValue, CommandType cmdType)
		{
			Hashtable htSQLPara = new Hashtable();

			for (int i = 0; i <= strArrParaName.Length - 1; i++)
			{
				string strParaName = strArrParaName[i].Replace("@", "").ToUpper();
				object objParaValue = objArrParaValue[i];

				if (!htSQLPara.Contains(strParaName))
					htSQLPara.Add(strParaName, objParaValue);
			}

			return ExecuteReturnValue(strSQLExec, htSQLPara, cmdType);
		}

		/// <summary>
		/// Phuong thuc thuc thi cau lenh SQL hay Sp: Tra ve ket qua Object value
		/// </summary>
		/// <param name="strSQLExec">Cau lenh SQL, Sp_Name</param>
		/// <param name="htSQLPara">Tham so luu trong HastTable</param>
		/// <returns>Tra ve ket qua la Object value</returns>
		public static Object ExecuteReturnValue(string strSQLExec, Hashtable htSQLPara, CommandType cmdType)
		{
			SqlCommand sqlCom = GetSQLCommand();

			sqlCom.CommandText = strSQLExec;
			sqlCom.CommandType = cmdType;

			if (htSQLPara.Count > 0)
			{//Add Parameter

				if (sqlCom.CommandType == CommandType.StoredProcedure)
				{//Duyet tung Parameters trong sp

					string strKey = "Object_id = Object_id('" + strSQLExec + "')";
					DataTable dtPara = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

					foreach (DataRow dr in dtPara.Rows)
					{
						string strColumnName = ((string)dr["Name"]).Replace("@", "").ToUpper();

						if (!htSQLPara.Contains(strColumnName))
							continue;

						sqlCom.Parameters.AddWithValue("@" + strColumnName, htSQLPara[strColumnName]);
					}
				}
				else
				{//Duyet tung Paramaters trong strSQLExec

					string strSQLPara = GetSplitList(strSQLExec, "@").Replace(" ", "");
					string[] strArrSQLPara = strSQLPara.Split(',');

					for (int i = 0; i <= strArrSQLPara.Length - 1; i++)
					{
						string strColumnName = strArrSQLPara[i].Trim().Replace("@", "").ToUpper();

						if (!htSQLPara.Contains(strColumnName))
							continue;

						sqlCom.Parameters.AddWithValue("@" + strColumnName, htSQLPara[strColumnName]);
					}
				}
			}

			Object objResult = new Object();

			try
			{
				objResult = sqlCom.ExecuteScalar();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
				return null;
			}

			return objResult;
		}

		#endregion

		public static SqlConnection GetNewSQLConnection()
		{
			//SqlConnection sqlCon = new SqlConnection(Element.sysConnection.ConnectionString);

			Environment.CurrentDirectory = Application.StartupPath; //Hải chuyển đường dẫn về Startup

			SqlConnection sqlCon = new SqlConnection(Element.Core.ConnectionString());

			try
			{
				sqlCon.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}

			return sqlCon;
		}

		/// <summary>
		/// Tra ve DataReader tu cac tham so goi vao
		/// </summary>
		/// <param name="strTableName">Ten table</param>
		/// <param name="strColumnLst">Danh sach column</param>
		/// <param name="strKey">Dieu kien where</param>
		/// <param name="strOrder">Sap xep</param>
		/// <returns></returns>
		public static SqlDataReader GetDataReader(string strTableName, string strColumnLst, string strKey, string strOrder)
		{
			if (strColumnLst == null || strColumnLst == "")
				strColumnLst = " * ";

			string strQuery = "SELECT " + strColumnLst + " FROM " + strTableName;

			if (!(strKey == null || strKey == ""))
				strQuery += " WHERE " + strKey;

			if (!(strOrder == null || strOrder == ""))
				strQuery += " ORDER BY " + strOrder;

			return GetDataReader(strQuery);
		}

		/// <summary>
		/// Trả về SqlDataReader  từ câu truy vấn
		/// </summary>
		/// <param name="Query">Chuỗi truy vấn</param>
		/// <returns></returns>
		public static SqlDataReader GetDataReader(string strQuery)
		{
			SqlCommand sqlCom = GetSQLCommand(strQuery);

			SqlDataReader sqlDr = sqlCom.ExecuteReader();

			return sqlDr;
		}

		/// <summary>
		/// Ham lay danh sach cac column tu 1 chuoi can cu vao ky tu dac biet Signal
		/// </summary>
		/// <param name="strSplit"></param>
		/// <param name="strSignal"></param>
		/// <returns></returns>
		static string GetSplitList(string strSplit, string strSignal)
		{
			string strSplitList = string.Empty;

			while (strSplit.Contains(strSignal))
			{
				strSplit = strSplit.Substring(strSplit.IndexOf(strSignal) + 1);
				int i = 0;

				while (i <= strSplit.Length - 1)
				{
					if (" .,()".Contains(strSplit.Substring(i, 1)))
						break;

					i++;
				}

				if (strSplitList != string.Empty)
					strSplitList += ", ";

				strSplitList += strSignal + strSplit.Substring(0, i);
			}

			return strSplitList;
		}

	}
}
