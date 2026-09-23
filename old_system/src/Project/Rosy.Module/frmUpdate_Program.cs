using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using System.Net;
using System.IO;

namespace RosyModule
{
	public partial class frmUpdate_Program : RosySystem.Customize.frmView
	{
        DataTable dtWs = new DataTable();
        BindingSource bdsWS = new BindingSource();
        public frmUpdate_Program()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load()
		{
            Build();
            FillData();

            this.Show();
		}
        void Build()
        {
            dgvWS.bSortMode = false;
            dgvWS.strZone = "WS";
            dgvWS.BuildGridView();
        }
        void FillData()
        {
            dtWs = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Is_Conect FROM R00WS WHERE Check_Active IS NOT NULL AND CONVERT(VARCHAR(10),Last_Login,120) = CONVERT(VARCHAR(10),GETDATE(),120)");
            
            foreach (DataRow dr in dtWs.Rows)
                dr["Is_Conect"] = IsLocalIpAddress((string)dr["Local_IP"]);
            
            bdsWS.DataSource = dtWs;
            dgvWS.DataSource = bdsWS;
        }
        public static bool IsLocalIpAddress(string host)
        {
            try
            { // get host IP addresses
                IPAddress[] hostIPs = Dns.GetHostAddresses(host);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                // test if any host IP equals to any local IP or to localhost
                foreach (IPAddress hostIP in hostIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(hostIP)) return true;
                    // is local address
                    foreach (IPAddress localIP in localIPs)
                    {
                        if (hostIP.Equals(localIP)) return true;
                    }
                }
            }
            catch { }
            return false;
        }

        void Update_Program()
        {
            // lấy thông tin các máy đã được active
            
            foreach (DataRow dr in dtWs.Rows)
            {
                //Lấy đường dẫn từng máy
                string strPath = (string)dr["Local_IP"] + " " + (string)dr["Program_Path"];

                string fileName = "test.txt";// "Your File Name"; 
                string filePath = @"C:\FT\";//Your File Path;
                byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
                byte[] fileData = File.ReadAllBytes(filePath + fileName);
                byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                fileNameLen.CopyTo(clientData, 0);
                fileNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fileNameByte.Length); 
            }
            //string strFileName = (string)drCurrent["File_Name"] + '.' + drCurrent["Tag"];
            //string strPath = @"\\192.168.1.18\BaoGia\"; 

            //if (!Directory.Exists(strPath))
            //    Directory.CreateDirectory(strPath);

            //Hashtable htPara = new Hashtable();

            //htPara.Add("STT", (string)drCurrent["Stt"]);
            //htPara.Add("FILE_NAME", drCurrent["FILE_NAME"]);


            //object objFile = SQLExec.ExecuteReturnValue("SELECT Image FROM R50THEPMN3_RESOURCE..R04CtSo_Resource WHERE File_Name = @File_Name AND Stt = @Stt ", htPara, CommandType.Text);

            //if (objFile != null && objFile != DBNull.Value && ((Byte[])objFile).Length > 0)
            //{
            //    FileStream fileStream = new FileStream(strPath + strFileName, FileMode.Create, FileAccess.ReadWrite);
            //    fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
            //    fileStream.Close();
            //    System.Diagnostics.Process.Start(strPath + strFileName);
            //}
        }
      
		private void btAccept_Click(object sender, EventArgs e)
		{
            
                
         }

		private void btCancel_Click(object sender, EventArgs e)
		{
			
		}
      
	}
}
