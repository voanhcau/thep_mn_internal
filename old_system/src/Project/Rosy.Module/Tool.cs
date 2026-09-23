using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Customize;
using RosySystem.Common;

namespace RosyModule
{
    public static class Tool
    {
        public static string GetIPServer()
        {
            string strIPServer = "";
            if (System.IO.File.Exists("config.xml"))
            {
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.Load("config.xml");
                if (xmldoc.DocumentElement.InnerXml.Contains("<Server>"))
                {
                    strIPServer = xmldoc.DocumentElement["Server"].InnerText;
                }
            }
            return strIPServer;
        }
        public static DataRow ShowLookup(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid)
        {
            strLookupValue = (strLookupValue == null ? string.Empty : strLookupValue);
            strLookupValue = strLookupValue.ToUpper();

            DataRow drLookupAsm = DataTool.SQLGetDataRowByID("R00Lookup", "ColumnID", strLookupColumn);

            if (drLookupAsm == null)
            {
                Common.MsgCancel("Chưa khai báo Lookup cho [" + strLookupColumn + "]");
                return null;
            }

            //Nếu không cần bắt buộc nhập thì thoát
            if (!bLookupRequire && strLookupValue == string.Empty)
                return null;

            //Kiem tra co trong CSDL hay không
            string strWhere = "0 = 0";// "( " + drLookupAsm["ColumnID_Lookup"] + " = N'" + strLookupValue + "' )";

            if (!(strLookupKeyFilter == null || strLookupKeyFilter == string.Empty))
                strWhere += " AND (" + strLookupKeyFilter + ")";

            if (!(strLookupKeyValid == null || strLookupKeyValid == string.Empty))
                strWhere += " AND (" + strLookupKeyValid + ")";

            //Kiem tra co trong CSDL hay không
            DataTable dtFind = DataTool.SQLGetDataTable(drLookupAsm["Table_Lookup"].ToString(), null, strWhere, "Ngay_Ct DESC");
             
            if (dtFind.Rows.Count == 1)
            {
                return dtFind.Rows[0];
            }
            else
            {//Hien Form Lookup

                frmView frmLookup;
                Assembly asm;
                Type objType;

                if (drLookupAsm == null)
                {
                    Common.MsgCancel("Bạn chưa khai báo Lookup");
                    return null;
                }

                string strAssembly = drLookupAsm["Assembly"].ToString();

                try
                {
                    asm = Assembly.Load(strAssembly.Split(':')[0]); //File dll
                    objType = asm.GetType(strAssembly.Split(':')[1]); //Namespace + '.' + Class
                    frmLookup = (frmView)Activator.CreateInstance(objType);

                    //frmLookup = (frmView)Activator.CreateInstance(Type.GetType(strAssembly.Split(':')[1]) + "," + strAssembly.Split(':')[0], true));
                }
                catch (Exception ex)
                {
                    Common.MsgCancel("Có lỗi xảy ra: " + ex.Message + "/n" + "Kiểm tra lại khai báo Lookup: " + strAssembly);
                    return null;
                }
                frmLookup.isLookup = true;
                frmLookup.strLookupColumn = drLookupAsm["ColumnID_Lookup"].ToString();
                frmLookup.strLookupValue = strLookupValue;
                frmLookup.strLookupKeyFilter = strLookupKeyFilter;
                frmLookup.strLookupKeyValid = strLookupKeyValid;

                //frmLookup.LoadToolStrip();
                frmLookup.LoadLookup();

                return frmLookup.drLookup;
            }
        }

        public static DataRow ShowLookup_NotNgay(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid)
        {
            strLookupValue = (strLookupValue == null ? string.Empty : strLookupValue);
            strLookupValue = strLookupValue.ToUpper();

            DataRow drLookupAsm = DataTool.SQLGetDataRowByID("R00Lookup", "ColumnID", strLookupColumn);

            if (drLookupAsm == null)
            {
                Common.MsgCancel("Chưa khai báo Lookup cho [" + strLookupColumn + "]");
                return null;
            }

            //Nếu không cần bắt buộc nhập thì thoát
            if (!bLookupRequire && strLookupValue == string.Empty)
                return null;

            //Kiem tra co trong CSDL hay không
            string strWhere = "0 = 0";// "( " + drLookupAsm["ColumnID_Lookup"] + " = N'" + strLookupValue + "' )";

            if (!(strLookupKeyFilter == null || strLookupKeyFilter == string.Empty))
                strWhere += " AND (" + strLookupKeyFilter + ")";

            if (!(strLookupKeyValid == null || strLookupKeyValid == string.Empty))
                strWhere += " AND (" + strLookupKeyValid + ")";

            //Kiem tra co trong CSDL hay không
            DataTable dtFind = DataTool.SQLGetDataTable(drLookupAsm["Table_Lookup"].ToString(), null, strWhere, "");

            if (dtFind.Rows.Count == 1)
            {
                return dtFind.Rows[0];
            }
            else
            {//Hien Form Lookup

                frmView frmLookup;
                Assembly asm;
                Type objType;

                if (drLookupAsm == null)
                {
                    Common.MsgCancel("Bạn chưa khai báo Lookup");
                    return null;
                }

                string strAssembly = drLookupAsm["Assembly"].ToString();

                try
                {
                    asm = Assembly.Load(strAssembly.Split(':')[0]); //File dll
                    objType = asm.GetType(strAssembly.Split(':')[1]); //Namespace + '.' + Class
                    frmLookup = (frmView)Activator.CreateInstance(objType);

                    //frmLookup = (frmView)Activator.CreateInstance(Type.GetType(strAssembly.Split(':')[1]) + "," + strAssembly.Split(':')[0], true));
                }
                catch (Exception ex)
                {
                    Common.MsgCancel("Có lỗi xảy ra: " + ex.Message + "/n" + "Kiểm tra lại khai báo Lookup: " + strAssembly);
                    return null;
                }
                frmLookup.isLookup = true;
                frmLookup.strLookupColumn = drLookupAsm["ColumnID_Lookup"].ToString();
                frmLookup.strLookupValue = strLookupValue;
                frmLookup.strLookupKeyFilter = strLookupKeyFilter;
                frmLookup.strLookupKeyValid = strLookupKeyValid;

                //frmLookup.LoadToolStrip();
                frmLookup.LoadLookup();

                return frmLookup.drLookup;
            }
        }

   
    }
}
