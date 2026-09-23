using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;

namespace RosyModule.CRM
{
	public class CRMLib
	{
		public static void GetNewMa_Dt(DataRow dr)
		{
			int iAutoNumber = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Auto_Number), 0) + 1 FROM R81DmDt"));
			string strID = "KH" + iAutoNumber.ToString().Trim();

			while (DataTool.SQLCheckExist("R81DmDt", "Ma_Dt", strID))
			{
				iAutoNumber++;
				strID = "KH" + iAutoNumber.ToString().Trim();
			}

			dr["Auto_Number"] = iAutoNumber;
			dr["Ma_Dt"] = strID;
		}

		public static void GetNewMa_Hd(DataRow dr)
		{
			int iAutoNumber = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Auto_Number), 0) + 1 FROM R81DmHd"));
			string strID = iAutoNumber.ToString().Trim();

			while (DataTool.SQLCheckExist("R81DmHd", "Ma_Hd", strID))
			{
				iAutoNumber++;
				strID = "HD" + iAutoNumber.ToString().Trim();
			}

			dr["Auto_Number"] = iAutoNumber;
			dr["Ma_Hd"] = strID;
		}

		public static void GetNewTask_ID(DataRow dr)
		{
			int iAutoNumber = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Auto_Number), 0) + 1 FROM R08Task"));
			string strID = Element.sysUser_Id + iAutoNumber.ToString().Trim();

			while (DataTool.SQLCheckExist("R08Task", "Task_ID", strID))
			{
				iAutoNumber++;
				strID = Element.sysUser_Id + iAutoNumber.ToString().Trim();
			}

			dr["Auto_Number"] = iAutoNumber;
			dr["Task_ID"] = strID;
		}

		public static void GetNewContact_ID(DataRow dr)
		{
			int iAutoNumber = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Auto_Number), 0) + 1 FROM R08Contact"));
			string strID = "LL" + iAutoNumber.ToString().Trim();

			while (DataTool.SQLCheckExist("R08Contact", "Contact_ID", strID))
			{
				iAutoNumber++;
				strID = "LL" + iAutoNumber.ToString().Trim();
			}

			dr["Auto_Number"] = iAutoNumber;
			dr["Contact_ID"] = strID;
		}

		public static string GetInfo_Dt(string strMa_Dt)
		{
			string strTen_Dt = string.Empty;

			strTen_Dt =  Convert.ToString(SQLExec.ExecuteReturnValue(@"SELECT Ten_Dt + '" + "\r\n" + "' + Dia_Chi + '" + "\r\n" + 
							"' + 'Phone: ' + So_Phone + '" + "\t\t" + "' + 'Fax: ' + So_Fax + '" + "\t\t" + 
							"' + 'Email: ' + Email + '" + "\t\t" + "' + 'Website: ' + Website " + 
							" FROM R81DMDT " +
							" WHERE Ma_Dt = '" + strMa_Dt + "'"));

			return strTen_Dt.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t").Replace("\\v", "\v");
		}
	}
}
