using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RosyModule
{
	public static class Variables
	{
		// Fields
		public static StatusInputType StatusInputType = StatusInputType.CANDTTUDONG;
		public static double dbSlopes_Up = 0;
		public static double dbSlopes_Down = 0;
		public static double dbZero_Coefficient;
		public static double dbSpan_Coefficient;
		public static double dbNet_Weight_Min;
		public static double dbNet_Weight_Max;
		public static int iNum_Ticket_Print = 0;
		public static int iStable_Count = 0;
		public static int iStable_Time = 0;
		public static int iStable_Range = 20;
		public static string strPrint_Report = "";
		public static string strPrint_Barcode = "";
		public static string strPrint_Eticket = "";
		public static int iCode;
		public static string strEquip_ID = "";
		public static string strBarcode;
		public static bool bManual = false;
		public static bool bOperator = false;
		
	} 

}
