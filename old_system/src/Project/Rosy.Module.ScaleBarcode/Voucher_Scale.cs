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

namespace RosyModule.ScaleBarcode
{
	public static class Voucher_Scale
	{
		//SQLUpdateCt
		public static bool SQLUpdateCt(frmVoucher_Scale_Edit frmEditCt)
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

			if (frmEditCt.drDmCt["Table_Ct"].ToString().ToUpper() == "R05CTN_BARCODE")
			{
				sqlCom.CommandText = "sp_Update_CtN_Barcode";

				//TVP_PH
				paraPH.TypeName = "TVP_PH_SCALE_N";
				paraPH.Value = GetTVPValue("R80PH_SCALE", "TVP_PH_SCALE_N", frmEditCt.dtEditPh);
				sqlCom.Parameters.Add(paraPH);

				//Tạo Table cho TVP_CtHD
				paraCt.TypeName = "TVP_CTN_BARCODE";
				paraCt.Value = GetTVPValue("R05CTN_BARCODE", "TVP_CTN_BARCODE", frmEditCt.dtEditCt);
				sqlCom.Parameters.Add(paraCt);

			}

			try
			{
				sqlCom.ExecuteNonQuery();

				Voucher_Scale.Update_dsVoucher(frmEditCt);
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
				string strCreate_User = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Create_Log), '') FROM R80Ph_Scale WHERE Stt = '" + strStt + "'");

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

					Common.CopyDataRow(drSource, drNew);
					dtTVPStructure.Rows.Add(drNew);
				}
			}

			return dtTVPStructure;
		}

		//Update_Header, Update_Detail
		public static void Update_Header(frmVoucher_Scale_Edit frmEditCt)
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

		public static void Update_Detail(frmVoucher_Scale_Edit frmEditCt)
		{// Update du lieu tu drPh xuong dtCt

			string strColumnList = ((string)frmEditCt.drDmCt["Update_Detail"]);

			Update_Detail(frmEditCt, strColumnList);
		}

		public static void Update_Detail(frmVoucher_Scale_Edit frmEditCt, string strColumnList)
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

		public static bool AddRow(frmVoucher_Scale_Edit frmEditCt)
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

		public static void CopyNewRow(frmVoucher_Scale_Edit frmEditCt)
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

		public static void DeleteRow(frmVoucher_Scale_Edit frmEditCt, dgvVoucher dgvEditCt)
		{
			if (dgvEditCt.Focused == false)
				return;

			//Phieu tra lai barcode. Neu barcode do da duoc chuyen trang thai tu cho xu ly sang loai khac, thi khong cho phep xoa dong do
			if (frmEditCt.strMa_Ct.StartsWith("PNTLB"))
			{
				frmEditCt.drCurrent = ((DataRowView)frmEditCt.bdsEditCt.Current).Row;
				
				object objValue = SQLExec.ExecuteReturnValue("SELECT Is_Wait_Process FROM R81DMBARCODE WITH(NOLOCK) WHERE Barcode = '" + frmEditCt.drCurrent["Barcode"] + "'");
				if (objValue != null && objValue.ToString() != string.Empty)
				{
					if (!Convert.ToBoolean(objValue))
					{
						Common.MsgCancel("Bó thép này đã được xử lý rồi.Không được xóa bỏ dòng này.");
						return;
					}
				}

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
			}
			else
			{
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
			}
		}

		//Stt, Gia_Vt, dsVoucher
		public static void Update_Stt(frmVoucher_Scale_Edit frmEditCt)
		{//Kiem tra frmEditCt.strStt co bi trung khong, roi update cho cac table lien quan

			string strTable_Ph = (string)frmEditCt.drDmCt["Table_Ph"];

			if (frmEditCt.enuNew_Edit == enuEdit.New || frmEditCt.enuNew_Edit == enuEdit.Copy)
			{
				while (DataTool.SQLCheckExist(strTable_Ph, "Stt", frmEditCt.strStt))
				{
					frmEditCt.strStt = Voucher_Scale.GetNewStt("80");
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

		public static void Update_dsVoucher(frmVoucher_Scale_Edit frmEditCt)
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

		public static void UpdateSo_Ct(frmVoucher_Scale_Edit frmEditCt)
		{
			if (frmEditCt.enuNew_Edit == enuEdit.New || frmEditCt.enuNew_Edit == enuEdit.Copy)
			{
				frmEditCt.drEditPh["So_Ct"] = Voucher_Scale.GetNewSo_Ct();

				foreach (DataRow dr in frmEditCt.dtEditCt.Rows)
				{
					if (dr.RowState == DataRowState.Deleted)
						continue;

					dr["So_Ct"] = frmEditCt.drEditPh["So_Ct"];
				}
			}
		}

		public static string GetInheritScaleBarcode(frmVoucher_Scale_Edit frmEditCt)
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

		public static void Update_DmNvu(frmVoucher_Scale_Edit frmEditCt)
		{
			string strDefaultColumnList = "Tk_No,Tk_Co,Tk_No2,Tk_Co2,Ma_Bp,Ma_Km,Ma_Vt_Sp,Ma_Hd,Ma_Job,Ma_Dt_CbNv,Ma_Thue,Ma_Kho";
			bool bCheckExist_DefaultValue = DataTool.SQLCheckExist("sys.procedures", "Name", "sp_GetDmNvu_DefaultValue");

			if (frmEditCt.enuNew_Edit == enuEdit.Edit && !(frmEditCt.Controls["txtMa_Nvu"].Focused && ((rsTextBox)frmEditCt.Controls["txtMa_Nvu"]).bTextChange))
				return;

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

		//Cập nhật Create_Log, LastModify_Log cho PH và Ct
		public static void Update_Log(frmVoucher_Scale_Edit frmEditCt)
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

		public static void InheritVoucher_SetData_Barcode(frmInherit_Xuat_Barcode frmInherit, frmVoucher_Scale_Edit frmEdit)
		{
			if (frmInherit.dtInherit.Rows == null)
				return;

			if (frmInherit.dtInherit.Select("Chon = true").Length == 0)
				return;

			DataRow drEditPh_Inherit = frmEdit.drEditPh;
			DataTable dtEditCt_Inherit = frmEdit.dtEditCt;
			DataRow drEditCt_Inherit = dtEditCt_Inherit.NewRow();

			Common.CopyDataRow(dtEditCt_Inherit.Rows[0], drEditCt_Inherit);

			if (frmInherit.chkInheritOverwrite.Checked)
				dtEditCt_Inherit.Rows.Clear();

			int iStt0 = Convert.ToInt32(Common.MaxDCValue(frmEdit.dtEditCt, "Stt0"));

			if (frmInherit.dtInherit.Rows.Count > 0)
			{
				DataRow drInheritVoucher = frmInherit.dtInherit.Rows[0];

				frmEdit.drEditPh["Ma_Dt"] = drInheritVoucher["Ma_Dt"];
				frmEdit.drEditPh["Dien_Giai"] = drInheritVoucher["Dien_Giai"];
				frmEdit.drEditPh["So_Xe"] = drInheritVoucher["So_Xe"];
				frmEdit.drEditPh["So_Xa_Lan_Tau"] = drInheritVoucher["So_Xa_Lan_Tau"];
				frmEdit.drEditPh["Ma_Vt_Sp"] = drInheritVoucher["Ma_Vt_Sp_Ph"];
				
				frmEdit.drEditPh["Stt_Org"] = drInheritVoucher["Stt"];
				frmEdit.drEditPh["Ma_Vt_Org"] = string.Empty;

				frmEdit.drEditPh.AcceptChanges();

				Common.ScaterMemvar(frmEdit, ref frmEdit.drEditPh);
			}

			foreach (DataRow drSelect in frmInherit.dtInherit.Select("Chon = true"))
			{
				DataRow drEditCtNew = dtEditCt_Inherit.NewRow();
				Common.CopyDataRow(drSelect, drEditCtNew);
				Common.SetDefaultDataRow(ref drEditCtNew);

				drEditCtNew["Stt"] = frmEdit.strStt;
				drEditCtNew["So_Ct"] = frmEdit.strStt;
				drEditCtNew["Ma_Ct"] = frmEdit.strMa_Ct;
				drEditCtNew["Ma_Vt_Org"] = string.Empty;
				drEditCtNew["Stt_Org"] = drSelect["Stt"];
				drEditCtNew["Stt0"] = iStt0 + 1;

				iStt0 += 1;

				frmEdit.dtEditCt.Rows.Add(drEditCtNew);
				drEditCtNew.AcceptChanges();
			}

		}

		public static string GetNewStt(string strModule)
		{
			string strMa_Dvcs = Element.sysMa_DvCs.Trim().PadLeft(3, '0');
			strModule = strModule.Trim().PadLeft(2, '0');

			string strSQL = @"SELECT ISNULL(MAX(SUBSTRING(Stt, 6, 10)), 0)
								FROM R80PH_SCALE WITH(NOLOCK)
								WHERE Stt LIKE '___" + strModule + "%' AND ISNUMERIC(SUBSTRING(Stt, 6, 10)) = 1";

			long iStt = Convert.ToInt64(SQLExec.ExecuteReturnValue(strSQL)) + 1;

			string strStt = iStt.ToString().Trim().PadLeft(10, '0');

			return strMa_Dvcs + strModule + strStt;
		}

		public static string GetNewSo_Ct()
		{
			string strSQL = @"SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(So_Ct)) AS BIGINT)), 0) FROM R80PH_SCALE WHERE YEAR(Ngay_Ct) = YEAR(GETDATE())";
			long iStt = Convert.ToInt64(SQLExec.ExecuteReturnValue(strSQL)) + 1;
			string So_Ct = iStt.ToString().Trim().PadLeft(6, '0');
			return So_Ct;
		}

        
        public static bool CheckInheritBarCode_PNTLB(string strBarCode)
        {
            bool bIs_Accept = false;
            bIs_Accept = (bool)SQLExec.ExecuteReturnValue("SELECT dbo.fn_CheckInheritBarCode_PNTLB ('" + strBarCode + "')");
            return bIs_Accept;
        }
        public static bool CheckInheritBarCode_PNSB(string strBarCode)
        {
            bool bIs_Accept = false;
            bIs_Accept = (bool)SQLExec.ExecuteReturnValue("SELECT dbo.fn_CheckInheritBarCode_PNSB ('" + strBarCode + "')");
            return bIs_Accept;
        }
	}
}
