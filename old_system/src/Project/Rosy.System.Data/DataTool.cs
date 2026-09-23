using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;

namespace RosySystem.Data
{
	public class DataTool
	{
		/// <summary>
		/// Tra ve DataTable tu cac tham so goi vao
		/// </summary>
		/// <param name="strTableName">Ten table</param>
		/// <param name="strColumnLst">Danh sach column</param>
		/// <param name="strKey">Dieu kien where</param>
		/// <param name="strOrder">Sap xep</param>
		/// <returns></returns>
		public static DataTable SQLGetDataTable(string strTableName, string strColumnLst, string strKey, string strOrder)
		{
			if (strColumnLst == null || strColumnLst == "")
				strColumnLst = " * ";

			if (strKey == null) 
				strKey = "";

			string strQuery = "SELECT " + strColumnLst + " FROM " + strTableName + " WITH (NOLOCK) ";

			if (!(strKey == null || strKey == ""))
				strQuery += " WHERE " + strKey;

			//Xây dựng điều kiện lọc Ngay_Begin, Ngay_End, Ma_Data
			DataTable tbLstColumn = SQLExec.ExecuteReturnDt(" SELECT  ',' + RTRIM(Name) FROM sys.columns " +
													 " WHERE Object_Id = Object_Id('" + strTableName + "') FOR XML PATH('')");

			if (tbLstColumn.Rows.Count > 0)
			{
				string strLstColumn = ((string)tbLstColumn.Rows[0][0]).Trim();
				if (strLstColumn.Contains("Ngay_Begin") && strLstColumn.Contains("Ngay_End"))
				{
					//string strWhereNgay = " ((Ngay_Begin = '01/01/1900' OR  Ngay_Begin <= '" + Element.sysNgay_Begin.ToString("dd/MM/yyyy") + "' ) " +
					//                "     AND (Ngay_End = '01/01/1900' OR Ngay_End >= '" + Element.sysNgay_End.ToString("dd/MM/yyyy") + "' )) ";

					string strWhereNgay = " ((Ngay_Begin = '01/01/1900' OR YEAR(Ngay_Begin) <= " + Element.Element.sysWorkingYear.ToString() + ") " +
										"     AND (Ngay_End = '01/01/1900' OR YEAR(Ngay_End) >= " + Element.Element.sysWorkingYear.ToString() + ")) ";
					if (strQuery.Contains("WHERE"))
						strQuery += " AND " + strWhereNgay;
					else
						strQuery += " WHERE " + strWhereNgay;
				}

				if (!Element.Element.sysTong_Hop)
				{
					if (strLstColumn.Contains("Ma_Data"))
					{
						if (strKey.Contains("Ma_Data")) //Hải sửa: Nếu trong điều kiện Where đã có lọc Ma_Data rồi thì không phải lọc ở đây nữa
						{ //Do nothing
						}
						else
						{
							if (strQuery.Contains("WHERE"))
								strQuery += " AND ( Ma_Data = '*' OR Ma_Data = '" + Element.Element.sysMa_Data + "')";
							else
								strQuery += " WHERE ( Ma_Data = '*' OR Ma_Data = '" + Element.Element.sysMa_Data + "')";
						}
					}
				}
			}

			if (!(strOrder == null || strOrder == ""))
				strQuery += " ORDER BY " + strOrder;

			return SQLExec.ExecuteReturnDt(strQuery);
		}

		/// <summary>
		/// Trả về giá trị của trường tên
		/// </summary>
		/// <param name="strTableName">Tên bảng</param>
		/// <param name="strFiledCode">Trường Mã</param>
		/// <param name="strFiledName">Trường tên</param>
		/// <param name="strCodeValue">Giá trị của trường mã</param>
		/// <returns></returns>
		public static string SQLGetNameByCode(string strTableName, string strFieldCode, string strFieldName, string strCodeValue)
		{
			return SQLGetNameByCode(strTableName, strFieldCode, strFieldName, strCodeValue, "");
		}

		/// <summary>
		/// Trả về giá trị của trường tên
		/// </summary>
		/// <param name="strTableName">Tên bảng</param>
		/// <param name="strFiledCode">Trường Mã</param>
		/// <param name="strFiledName">Trường tên</param>
		/// <param name="strCodeValue">Giá trị của trường mã</param>
		/// <param name="strKey">Filter</param>
		/// <returns></returns>
		public static string SQLGetNameByCode(string strTableName, string strFieldCode, string strFieldName, string strCodeValue, string strKey)
		{
			string strKey1 = "(" + strFieldCode + " = '" + strCodeValue + "')";

			if (strKey != "")
				strKey1 = strKey1 + " AND " + strKey;

			DataTable dt = SQLGetDataTable(strTableName, strFieldName, strKey1, null);

			if (dt.Rows.Count == 0)
				return string.Empty;

			return dt.Rows[0][strFieldName].ToString().Trim();
		}

		/// <summary>
		/// Tra ve dong du lieu loc tu CSDL can cu vao ColumnID
		/// </summary>
		/// <param name="strTableName">Ten bang</param>
		/// <param name="strColumnID">Column loc</param>
		/// <param name="strValue">Gia tri tuong ung Column</param>
		/// <returns></returns>
		public static DataRow SQLGetDataRowByID(string strTableName, string strColumnID, string strValue)
		{
			string strKey = "(" + strColumnID + " = '" + strValue.Trim() + "')";

			DataTable dt = SQLGetDataTable(strTableName, "*", strKey, null);

			if (dt.Rows.Count > 0)
				return dt.Rows[0];
			else
				return null;
		}

		/// <summary>
		/// Delete mot bang voi tham so la DataRow
		/// </summary>
		/// <param name="strTableName"></param>
		/// <param name="dr"></param>
		/// <returns></returns>
		public static bool SQLDelete(string strTableName, DataRow dr)
		{
			// Xây dựng cậu lệnh Delete
			string strDeleteCommand = string.Empty;
			string strWhereCommand = string.Empty;
			strDeleteCommand = " DELETE " + strTableName + " WHERE ";

			// Xây dựng điều kiện WHERE 
			DataTable dtKeys = SQLGetPrimaryKey(strTableName);
			if (dtKeys.Rows.Count == 0)
			{
				MessageBox.Show("Bảng " + strTableName + " không có khóa nên không xóa được được");
				return false;
			}
			string strKeys = (string)dtKeys.Rows[0]["PrimaryKey_Name"];
			string[] arrStrKeys = strKeys.Split(',');

			DataTable dtPara = new DataTable();

			for (int i = 0; i <= arrStrKeys.Length - 1; i++)
			{
				if (i == arrStrKeys.Length - 1) // gia tri cuoi mang
					strWhereCommand += arrStrKeys[i] + " = @" + arrStrKeys[i];
				else
					strWhereCommand += arrStrKeys[i] + " = @" + arrStrKeys[i] + " AND ";

				dtPara.Columns.Add(arrStrKeys[i]);
			}

			DataRow drPara = dtPara.NewRow();

			for (int i = 0; i <= arrStrKeys.Length - 1; i++)
			{
				drPara[i] = dr[arrStrKeys[i]];
			}

			strDeleteCommand += strWhereCommand;

			//Ghi nhật ký LastModify_Log trước khi xóa
			if (DataTool.SQLCheckExist("INFORMATION_SCHEMA.COLUMNS", new string[] { "Table_Name", "Column_Name" }, new object[] { strTableName, "LastModify_Log" }))
			{
				SQLExec.Execute("UPDATE " + strTableName + " SET LastModify_Log = '" + GetCurrent_Log() + "' WHERE " + strWhereCommand, drPara);
			}

			return SQLExec.Execute(strDeleteCommand, drPara);
		}

		/// <summary>
		/// Delete bang voi tham so dua vao la mang
		/// </summary>
		/// <param name="strTableName">Tan bang</param>
		/// <param name="strColumnList">Danh sach cac cot</param>
		/// <param name="objValueList">Danh sach cac gia tri tuong ung voi cot</param>
		/// <returns></returns>
		public static bool SQLDelete(string strTableName, string[] strColumnList, object[] objValueList)
		{

			// Xây dựng cậu lệnh Delete
			string strDeleteCommand = string.Empty;
			string strWhereCommand = string.Empty;
			strDeleteCommand = " DELETE " + strTableName + " WHERE ";

			DataTable dtPara = new DataTable();

			// Xây dựng điều kiện WHERE 				
			for (int i = 0; i <= strColumnList.Length - 1; i++)
			{
				if (i == strColumnList.Length - 1) // gia tri cuoi mang
					strWhereCommand += strColumnList[i] + " = @" + strColumnList[i];
				else
					strWhereCommand += strColumnList[i] + " = @" + strColumnList[i] + " AND ";

				dtPara.Columns.Add(strColumnList[i]);
			}

			DataRow drPara = dtPara.NewRow();

			for (int i = 0; i <= objValueList.Length - 1; i++)
			{
				drPara[i] = objValueList[i];
			}

			strDeleteCommand += strWhereCommand;

			//Ghi nhật ký LastModify_Log trước khi xóa
			if (DataTool.SQLCheckExist("INFORMATION_SCHEMA.COLUMNS", new string[] { "Table_Name", "Column_Name" }, new object[] { strTableName, "LastModify_Log" }))
			{
				SQLExec.Execute("UPDATE " + strTableName + " SET LastModify_Log = '" + GetCurrent_Log() + "' WHERE " + strWhereCommand, drPara);
			}

			return SQLExec.Execute(strDeleteCommand, drPara);
		}

		/// <summary>
		/// Delete bang voi dieu kien strColumnName = objValue
		/// </summary>
		/// <param name="strTableName">Ten cot</param>
		/// <param name="strColumnName"></param>
		/// <param name="objValue">Gai tri</param>
		/// <returns></returns>
		public static bool SQLDelete(string strTableName, string strColumnName, object objValue)
		{
			return SQLDelete(strTableName, new string[] { strColumnName }, new object[] { objValue });
		}

		/// <summary>
		/// gán giá trị mặc định cho những cột null
		/// </summary>
		/// <param name="dr"></param>
		public static void SetDefaultDataRow(ref DataRow dr)
		{
			if (dr.Table.Columns.Contains("Ma_Data") && dr["Ma_Data"] == DBNull.Value)
				dr["Ma_Data"] = Element.Element.sysMa_Data;

			if (dr.Table.Columns.Contains("Ma_DvCs") && (dr["Ma_DvCs"] == DBNull.Value || ((string)dr["Ma_DvCs"]).ToString().Trim() == string.Empty))
				dr["Ma_DvCs"] = Element.Element.sysMa_DvCs;

			for (int i = 0; i <= dr.Table.Columns.Count - 1; i++)
			{
				//Nếu là có giá trị rồi thi không gán nữa
				if (dr[i] != DBNull.Value)
					continue;
				switch (dr.Table.Columns[i].DataType.ToString())
				{

					case "System.Boolean":
					case "System.Byte":
					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.Decimal":
					case "System.Double":
						dr[i] = 0;
						break;
					case "System.String":
						dr[i] = "";
						break;
					case "System.DateTime":
						dr[i] = Element.Element.sysNgay_Min;
						break;
				}
			}
		}

		/// <summary>
		/// Thu tuc cap nhat (INSERT, UPDATE) xuong co so du lieu
		/// </summary>
		/// <param name="enuNew_Edit">N-Nhap moi, E-Sua</param>
		/// <param name="tbName"></param>
		/// <param name="dtRow"></param>
		/// <returns></returns>
		public static bool SQLUpdate(enuEdit enuNew_Edit, string tbName, ref DataRow dr)
		{
			//Kiem tra trung khóa, hay Unique
			if (SQLCheckValid(enuNew_Edit, tbName, dr))
			{
				//Save du lieu xuong Database SQL
				return SQLSave(enuNew_Edit, tbName, ref dr); ;
			}
			return false;
		}

		/// <summary>
		/// Hàm kiểm tra tính hợp lệ dữ liệu (datarow) trước khi luu vào Database
		/// kiem tra trung PrimaryKey, Unique: trùng return true, không trùng return false
		/// </summary>
		/// <param name="strTableName"></param>
		/// <param name="?"></param>
		/// <param name="?"></param>
		/// <returns></returns>
		public static bool SQLCheckValid(enuEdit enuNew_Edit, string strTableName, DataRow dr)
		{
			bool bValid = true;
			bool bEditChange = false;

			DataTable dtUnique = SQLGetUnique(strTableName);
			string strErrorMessage = "Thông báo giá trị : {";

			for (int i = 0; i <= dtUnique.Rows.Count - 1; i++)
			{
				//Tach chuoi cac truong Unique
				string strColumnUnique = ((string)dtUnique.Rows[i]["Unique_ColumnLst"]);
				string[] arrStrColumnUnique = strColumnUnique.Split(',');

				//Kiểm tra Unique có thay đổi hay không trong trường hợp Edit
				if (enuNew_Edit == enuEdit.Edit)
				{
					bool bUniqueChange = false;
					for (int j = 0; j <= arrStrColumnUnique.Length - 1; j++)
					{
						if (!dr[arrStrColumnUnique[j]].Equals(dr[arrStrColumnUnique[j], DataRowVersion.Original]))
						{
							bUniqueChange = true;
							break;
						}
					}

					if (!bUniqueChange)
						continue;
				}

				List<object> lstObjColumnValue = new List<object>();
				for (int j = 0; j <= arrStrColumnUnique.Length - 1; j++)
				{
					lstObjColumnValue.Add(dr[arrStrColumnUnique[j]]);
					strErrorMessage += arrStrColumnUnique[j] + " = " + dr[arrStrColumnUnique[j]].ToString() + ",";
				}

				//Kiem tra ton tai trung khoa va tra ve ket qua
				if (SQLCheckDuplicate(strTableName, arrStrColumnUnique, lstObjColumnValue.ToArray()))
				{
					strErrorMessage = strErrorMessage.Substring(0, strErrorMessage.Length - 1) + "} đã tồn tại trong bảng " + strTableName;
					bValid = false;
					break;
				}
			}

			//Neu la kiem tra edit thi kiem tra them co chinh sua so voi du lieu cu hay khong -> tra ve bien bEditChange
			if (enuNew_Edit == enuEdit.Edit)
			{
				DataTable dtPrimaryKey = SQLGetPrimaryKey(strTableName);

				//Tach chuoi cac truong Unique
				string strColumnPrimaryKey = ((string)dtPrimaryKey.Rows[0]["PrimaryKey_Name"]);
				string[] arrStrColumnPrimaryKey = strColumnPrimaryKey.Split(',');

				for (int j = 0; j <= arrStrColumnPrimaryKey.Length - 1; j++)
				{
					if (!dr[arrStrColumnPrimaryKey[j]].Equals(dr[arrStrColumnPrimaryKey[j], DataRowVersion.Original]))
					{
						bEditChange = true;
						break;
					}
				}

				//Neu khi edit ma khong thay doi gia tri tren cac column PrimaryKey, Unique thi Ok
				if (bEditChange == false)
				{
					bValid = true;
				}
			}

			//Nếu kiểm tra valid, không hợp lệ => xuất hiện thông điệp báo trùng
			if (bValid == false)
			{
				MessageBox.Show(strErrorMessage);
			}

			return bValid;
		}

		/// <summary>
		/// Phuong thuc luu du lieu xuong Database
		/// </summary>
		/// <param name="enuNew_Edit"></param>
		/// <param name="strTableName"></param>
		/// <param name="dr"></param>
		/// <returns></returns>
		public static bool SQLSave(enuEdit enuNew_Edit, string strTableName, ref DataRow dr)
		{
			//Thiết lập giá trị Default cho cac Column
			SetDefaultDataRow(ref dr);

			//Tao cau lenh SQL luu xuong CSDL
			string strSQLCommand = string.Empty;
			string strSQLCommand_Pra = string.Empty;
			string strPrimaryKeyWhere = string.Empty;

			//Lay danh sach cac column Identity
			DataTable dtColIdentity;
            string strKeyIdentity = "Object_Id = Object_Id('" + strTableName + "') AND Is_Identity = 1";
			string strColIdentityName = string.Empty;

			dtColIdentity = SQLGetDataTable("Sys.Columns", "UPPER(Name) AS Name", strKeyIdentity, "");

			// Lay danh sách các tên cột trong bảng strTableName
			DataTable tbLstColumn = SQLExec.ExecuteReturnDt(" SELECT  ',' + UPPER(RTRIM(Name)) FROM sys.columns " +
													 " WHERE Object_Id = Object_Id('" + strTableName + "') AND system_type_id NOT IN (34,165) " + //Hải loại trừ kiểu dữ liệu Image và VarBinary khi lưu vào, phải lưu theo kiểu khác
													 " FOR XML PATH('')");
			string strLstColumn = string.Empty;

			if (tbLstColumn.Rows.Count > 0)
				strLstColumn = ((string)tbLstColumn.Rows[0][0]).Trim();

			DataTable dtPara = dr.Table.Clone();

			DataRow drNew = dtPara.NewRow();
			CopyDataRow(dr, drNew);
			dtPara.Rows.Add(drNew);

			if (enuNew_Edit == enuEdit.New) //Tao cau lenh cho truong hop INSERT
			{
				strSQLCommand = string.Empty;
				strSQLCommand_Pra = string.Empty;

				//Tao danh sach cot insert tu dr
				for (int i = 0; i <= dr.Table.Columns.Count - 1; i++)
				{
					string strColumnName = dr.Table.Columns[i].ColumnName.ToUpper();

					//Kiem tra truong du lieu identity
					if ((dtColIdentity.Rows.Count > 0) && (((string)dtColIdentity.Rows[0]["Name"]).Trim() == strColumnName))
					{
						strColIdentityName = strColumnName;
						continue;
					}
                    //Kiem tra truong du lieu rowguid đồng bộ dữ liệu
                    if ((dtColIdentity.Rows.Count > 0) && (strColumnName == "ROWGUID"))
                        continue;
                    
					//Nếu ColumnName trong dr không có trong CSDL thi không Insert vào
					if (!("," + strLstColumn + ",").Contains("," + strColumnName + ","))
						continue;


					if (strSQLCommand != string.Empty)
					{
						strSQLCommand += ", ";
						strSQLCommand_Pra += ", ";
					}

					strSQLCommand += strColumnName;
					strSQLCommand_Pra += "@" + strColumnName;

				}

				strSQLCommand = " INSERT INTO " + strTableName + "(" + strSQLCommand + ") " +
								" VALUES (" + strSQLCommand_Pra + ")";
			}
			else //Tao cau lenh cho truong hop UPDATE
			{

				strSQLCommand = string.Empty;

				//Tao danh sach cac column cap nhat
				for (int i = 0; i <= dr.Table.Columns.Count - 1; i++)
				{
					string strColumnName = dr.Table.Columns[i].ColumnName.ToUpper();

					//Kiem tra truong du lieu identity
					if ((dtColIdentity.Rows.Count > 0) && (((string)dtColIdentity.Rows[0]["Name"]).Trim() == strColumnName))
					{
						strColIdentityName = strColumnName;
						continue;
					}

					//Nếu ColumnName trong dr không có trong CSDL thi không Insert vào
					if (!("," + strLstColumn + ",").Contains("," + strColumnName + ",")) 
						continue;

					if (strSQLCommand != string.Empty) //Column tiep theo phai chen dau ',' vao
						strSQLCommand += ", ";

					strSQLCommand += strColumnName + " = @" + strColumnName;
				}

				strSQLCommand = " UPDATE " + strTableName + " SET " + strSQLCommand;

				//Tao dieu kien where cho cau lenh insert
				DataTable dtPrimaryKey = SQLGetPrimaryKey(strTableName);
				if (dtPrimaryKey.Rows.Count == 0)
				{
					MessageBox.Show("Bảng " + strTableName + " không có khóa, khong thuc hien duoc!");
					return false;
				}

				strPrimaryKeyWhere = (string)dtPrimaryKey.Rows[0]["PrimaryKey_Name"];
				string[] arrStrPrimaryKeyWhere = strPrimaryKeyWhere.Split(',');
				strPrimaryKeyWhere = " WHERE ";

				for (int i = 0; i <= arrStrPrimaryKeyWhere.Length - 1; i++)
				{
					string strPrimaryColumn = "Old" + arrStrPrimaryKeyWhere[i];

					if (i == arrStrPrimaryKeyWhere.Length - 1) // gia tri cuoi mang
						strPrimaryKeyWhere += arrStrPrimaryKeyWhere[i] + " = @" + strPrimaryColumn;
					else
						strPrimaryKeyWhere += arrStrPrimaryKeyWhere[i] + " = @" + strPrimaryColumn + " AND ";

					dtPara.Columns.Add(strPrimaryColumn);
					dtPara.Rows[0][strPrimaryColumn] = dr[arrStrPrimaryKeyWhere[i], DataRowVersion.Original];
				}

				strSQLCommand = strSQLCommand + strPrimaryKeyWhere;
			}

			if (enuNew_Edit == enuEdit.New && strColIdentityName != string.Empty)
			{//Neu table ton tai truong Identity thi update vao datarow

				strSQLCommand += " SELECT @@IDENTITY";

				DataTable dtReturn = SQLExec.ExecuteReturnDt(strSQLCommand, dtPara.Rows[0]);

				if (dtReturn.Rows.Count > 0)
					dr[strColIdentityName] = Convert.ToInt32(dtReturn.Rows[0][0]);

				return true;
			}
			else
				return SQLExec.Execute(strSQLCommand, dtPara.Rows[0]);
		}

		/// <summary>
		/// Hàm kiểm tra tồn tại khóa hay chưa
		/// </summary>
		/// <param name="tableName">Tên bảng</param>
		/// <param name="keyName">Tên của khóa</param>
		/// <param name="keyValue">Giá trị của khóa kiểm tra</param>
		/// <returns></returns>        
		private static bool SQLCheckDuplicate(string strTableName, string[] strKeyNames, object[] objKeyValue)
		{
			string strSelect = "SELECT COUNT(" + strKeyNames[0] + ") FROM " + strTableName + " WITH (NOLOCK) WHERE ";

			//Tạo câu lệnh SELECT
			for (int i = 0; i <= strKeyNames.Length - 1; i++)
			{
				if (i == strKeyNames.Length - 1)
					strSelect += strKeyNames[i] + " = @" + strKeyNames[i];
				else
					strSelect += strKeyNames[i] + " = @" + strKeyNames[i] + " AND ";
			}

			//Trường hợp sửa (edit) thì loại bỏ dòng hiện hành


			DataTable dtResult = SQLExec.ExecuteReturnDt(strSelect, strKeyNames, objKeyValue);

			if (dtResult == null)
				return false;

			if ((int)dtResult.Rows[0][0] > 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Kiểm tra giá trị objValue có tồn tại trong Column cua bảng strTableName hay không,
		/// nếu có return true, nếu không return false
		/// </summary>
		/// <param name="strTableName"></param>
		/// <param name="strColumnName"></param>
		/// <param name="objValue"></param>
		/// <returns></returns>
		public static bool SQLCheckExist(string strTableName, string strColumnName, object objValue)
		{
			return SQLCheckDuplicate(strTableName, new string[] { strColumnName }, new object[] { objValue });
		}

		public static bool SQLCheckExist(string strTableName, string[] strColumnNameList, object[] objValueList)
		{
			return SQLCheckDuplicate(strTableName, strColumnNameList, objValueList);
		}

		public static bool SQLChangeID(string strColumn_Type, DataRow drValue)
		{
			if (drValue.Table.Columns.Contains(strColumn_Type))
			{
				object objOldValue = drValue[strColumn_Type, DataRowVersion.Original];
				object objNewValue = drValue[strColumn_Type];

				if (objOldValue != objNewValue)
				{
					return SQLExec.Execute("Sp_ChangeID",
						new string[] { "Column_Type", "OldValue", "NewValue" },
						new object[] { strColumn_Type, objOldValue, objNewValue }, CommandType.StoredProcedure);
				}
			}

			return true;
		}

		public static bool SQLMergeID(string strColumn_Type, string strTableName, object objOldValue, object objNewValue)
		{
			if (objOldValue != objNewValue)
			{
				if (SQLExec.Execute("Sp_ChangeID",
					new string[] { "Column_Type", "OldValue", "NewValue" },
					new object[] { strColumn_Type, objOldValue, objNewValue }, CommandType.StoredProcedure))
				{
					System.Collections.Hashtable htPara = new System.Collections.Hashtable();
					htPara.Add("OLDVALUE", objOldValue);

					string strSQLExec = "DELETE FROM " + strTableName + " WHERE " + strColumn_Type + " = @OldValue";

					return SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
					//return true;
				}
			}

			return true;
		}

		/// <summary>
		/// Hàm trả về bảng PrimaryKey, Unique
		/// </summary>
		/// <param name="table_Name"></param>
		/// <returns></returns>
		static DataTable SQLGetUnique(string strTableName)
		{
			return SQLExec.ExecuteReturnDt("EXEC sp_GetUnique " + strTableName);
		}

		/// <summary>
		///  Hàm trả về bảng PrimaryKey
		/// </summary>
		/// <param name="table_Name"></param>
		/// <returns></returns>
		static DataTable SQLGetPrimaryKey(string strTableName)
		{
			return SQLExec.ExecuteReturnDt("EXEC sp_GetPrimaryKey " + strTableName);
		}

		public static void CopyDataRow(DataRow drSource, DataRow drDest)
		{
			string strColumn = String.Empty;

			for (int i = 0; i <= drSource.Table.Columns.Count - 1; i++)
			{
				strColumn = drSource.Table.Columns[i].ColumnName;

				if (drDest.Table.Columns.Contains(strColumn))
				{
					drDest[strColumn] = drSource[strColumn];
				}
			}
		}

		public static DataTable GetTVPValue(string strTableName, string strTableTypeName, DataTable dtTableSource)
		{
			//Tạo cấu trúc bảng 
			string strSQLExec = @"
					DECLARE @_ColList VARCHAR(1000)
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

					CopyDataRow(drSource, drNew);
					dtTVPStructure.Rows.Add(drNew);
				}
			}

			return dtTVPStructure;
		}

		/// <summary>
		/// Tra ve chuoi Log(34) hien hanh : DDMMYY:HHMNSS:USER_ID(20)
		/// </summary>
		/// <returns></returns>
		public static string GetCurrent_Log()
		{
			string strCurrent_Log = string.Empty;
			DateTime dte = DateTime.Now;

			strCurrent_Log += dte.Day.ToString().PadLeft(2, '0');
			strCurrent_Log += dte.Month.ToString().PadLeft(2, '0');
			strCurrent_Log += dte.Year.ToString().Substring(2, 2);
			strCurrent_Log += ":";
			strCurrent_Log += dte.Hour.ToString().PadLeft(2, '0');
			strCurrent_Log += dte.Minute.ToString().PadLeft(2, '0');
			strCurrent_Log += dte.Second.ToString().PadLeft(2, '0');
			strCurrent_Log += ":";
			strCurrent_Log += Element.Element.sysUser_Id;

			return strCurrent_Log;
		}
	}
}
