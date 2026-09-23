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


namespace RosyModule.Manufactory
{
    class Manufactory
    {
        public bool CheckLock(string strStt)
        {
            bool bLock = false;
            string strSQL = "SELECT Lock FROM R80PH_QLSX WHERE Stt = '" + strStt + "'";
            bLock = (bool)SQLExec.ExecuteReturnValue(strSQL);
            return bLock;
        }
    }
}
