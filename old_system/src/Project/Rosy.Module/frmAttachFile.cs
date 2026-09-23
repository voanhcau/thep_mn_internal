using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;
using System.Data.SqlClient;
using System.Net;

namespace RosyModule
{
	public partial class frmAttachFile : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtXuatVTriKho;
        public string strFile_Name;
		BindingSource bdsXuatVTriKho = new BindingSource();

        object objFile = null;
        string strFile_Tag = string.Empty;

        DataRow drPh;
		DataRow drCurrent;
		string strStt = string.Empty;
        int iStt0 = 0;

        enuEdit enuEdit = new enuEdit();
		public bool Is_Accept = false;

		#endregion

		#region Contructor

        public frmAttachFile()
		{
			InitializeComponent();

			
			
            //this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
            btAttach.Click += new EventHandler(btAttach_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btOpen.Click += new EventHandler(btOpen_Click);
            btAccept.Click+=new EventHandler(btAccept_Click);
            btCancel.Click += new EventHandler(btClose_Click);
            btAddFile.Click += new EventHandler(btAddFile_Click);
		}

        void btAddFile_Click(object sender, EventArgs e)
        {
            DataTable dtAddFile = SQLExec.ExecuteReturnDt("SELECT Stt, Stt0, File_Name, Tag, File_Path_Goc from TAM");
            string strPath = string.Empty;
            string strFileName = string.Empty;
            foreach (DataRow dr in dtAddFile.Rows)
            {

                strPath = dr["File_Path_Goc"].ToString();

                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                strPath += "\\";

                strFileName = dr["File_Name"].ToString();
                strFileName += ".";
                strFileName += dr["Tag"].ToString();

                if (!File.Exists(strPath))
                {
                    
                    Hashtable htPara = new Hashtable();
                    htPara.Add("STT", dr["Stt"]);
                    htPara.Add("STT0", dr["Stt0"]);
                    htPara.Add("FILE_NAME", dr["File_Name"]);
                    //object objFile = SQLExec.ExecuteReturnValue("SELECT Image FROM R50THEPMN3_RESOURCE..R04CTSO_Resource WHERE Stt = @Stt AND Stt0 = @Stt0 AND File_Name = @File_Name ", htPara, CommandType.Text);

                    if (!File.Exists(Path.Combine(strPath + strFileName)))
                    {
                        if (objFile != null && objFile != DBNull.Value && ((Byte[])objFile).Length > 0)
                        {
                            FileStream fileStream = new FileStream(strPath + strFileName, FileMode.Create, FileAccess.ReadWrite);

                            fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);

                            fileStream.Close();

                        }
                    }
                }
            }

            

            Common.MsgOk("Xong");
        }

		#endregion

		#region Method

		public void Load(string strStt)
		{

            if (Element.sysIs_Admin)
                btAddFile.Visible = true;
            this.strStt = strStt;
			
			Build();
			FillData();
			BindingLanguage();

			this.ShowDialog();
		}

        public void Load(string strStt, int iStt0, enuEdit enuEdit)
        {

            if (Element.sysIs_Admin)
                btAddFile.Visible = true;

            this.strStt = strStt;
            this.iStt0 = iStt0;
            this.enuEdit = enuEdit;

            Build();
            FillData();
            BindingLanguage();

            if (enuEdit == enuEdit.Edit)
            {
                if (Common.InlistLike(strStt, "A0104,A0107"))
                {
                    drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
                }
                else if (Common.InlistLike(strStt, "A0106"))
                {
                    drPh = DataTool.SQLGetDataRowByID("R06PH_BTTB", "Stt", strStt);
                }
                if ((bool)drPh["Duyet_Tp"])
                {
                    btAttach.Enabled = false;
                    btDelete.Enabled = false;

                }
            }
            this.ShowDialog();
        }

		void Build()
		{
            dgvInheritVoucher.strZone = "RESOURCE_SO";
			
			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

		

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;
		}

		void FillData()
		{
            if (enuEdit == enuEdit.New)
            {
                strStt = "";
            }
			Hashtable htPara = new Hashtable();

			htPara.Add("STT", strStt);
            htPara.Add("STT0", iStt0);

			dtXuatVTriKho = SQLExec.ExecuteReturnDt("Sp_GetFileAttach", htPara, CommandType.StoredProcedure);

			bdsXuatVTriKho.DataSource = dtXuatVTriKho;
			dgvInheritVoucher.DataSource = bdsXuatVTriKho;

			bdsSearch = bdsXuatVTriKho;
			bdsLookup = bdsXuatVTriKho;
			
		}
        void AttachFile()
        {
           
            drCurrent = dtXuatVTriKho.NewRow(); //((DataRowView)bdsXuatVTriKho.Current).Row;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "All files (*.*)|*.*";

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            this.objFile = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);

            if (objFile != null)
            {


                var fileName = fileDialog.FileName;
            

                strFile_Tag = Path.GetExtension(fileDialog.FileName).Substring(1).ToUpper();

                drCurrent["TAG"] = strFile_Tag;
                //drCurrent["IMAGE"] = objFile;
                drCurrent["File_Name"] = Path.GetFileNameWithoutExtension(fileDialog.FileName);
               
                drCurrent["File_Path"] = Path.GetFileNameWithoutExtension(fileDialog.FileName) + Path.GetExtension(fileDialog.FileName);
                drCurrent["File_Path_New"] = fileDialog.FileName;
                
                //drCurrent["Open_File"] = drCurrent["File_Name"];
                this.strFile_Name = Path.GetFileNameWithoutExtension(fileDialog.FileName) + ",";
              
                

                //SaveFile(Path.GetFileNameWithoutExtension(fileDialog.FileName), strFile_Tag, true);
                dtXuatVTriKho.Rows.Add(drCurrent);
                dtXuatVTriKho.AcceptChanges();
                //}
            }
        }
       
        void DeleteFile()
        {
            bool bAccept_Del = false;
            string strSQLExec = "";
            //string strSQLExec1 = "";
            drCurrent = ((DataRowView)bdsXuatVTriKho.Current).Row;

            if (!Element.sysIs_Admin)
            {
                string strCreate_User = (string)drCurrent["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                   bAccept_Del = false;
                else
                   bAccept_Del = true;

                
            }
            if (bAccept_Del)
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("STT", strStt);
                htPara.Add("STT0", iStt0);
                htPara.Add("FILE_NAME", drCurrent["File_Name"]);

                strSQLExec = @"DELETE FROM R04CTSO_Resource WHERE Stt = @Stt AND Stt0 = @Stt0 AND File_Name = @File_Name";
                // ẩn mục này
                //strSQLExec1 = @"DELETE FROM R50THEPMN3_RESOURCE..R04CTSO_Resource WHERE Stt = @Stt AND Stt0 = @Stt0  AND File_Name = @File_Name";

                SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                //SQLExec.Execute(strSQLExec1, htPara, CommandType.Text);

                //xóa file tại server
                drCurrent["File_Path"] = "\\\\" + Tool.GetIPServer() + drCurrent["File_Path"];
                File.Delete(drCurrent["File_Path"].ToString());
            }
            else
                Common.MsgOk("Bạn không có quyền xóa file vào chứng từ của người không được phân quyền");

            FillData();
        }
        void OpenFile()
        {
            if (bdsXuatVTriKho.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsXuatVTriKho.Current).Row;
           
            if ((string)drCurrent["File_Name"] == null)
            {
                Common.MsgOk("Không có file Attach");
                return;
            }
            object objFile = (object)drCurrent["File_Path"];
            string strPath = (string)drCurrent["File_Path"];
            strPath = "\\\\" + Tool.GetIPServer() + strPath;
            try
            {

                if (objFile != null && objFile != DBNull.Value)// && ((Byte[])objFile).Length > 0)
                {
                    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                    fileStream.Close();
                    System.Diagnostics.Process.Start(strPath);
                }
            }
            catch (Exception ex)
            {
                if (Common.InlistLike(ex.Message, "Could not find a part of the path"))
                {

                    NetworkCredential myCred = new NetworkCredential(
                                   "thepmiennam\bangvtk", "bang160619", "192.168.1.18");

                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(new Uri("192.168.1.18"), "Basic", myCred);
                    WebRequest wr = WebRequest.Create("192.168.1.18");
                    wr.Credentials = myCache;


                    //CredentialCache myCache = new CredentialCache();

                    ////myCache.Add(new Uri(Tool.GetIPServer()), "Basic", new NetworkCredential("thepmiennam\bangvtk", "bang160619"));
                    //myCache.Add(new Uri("\\192.168.1.18"), "Basic", new NetworkCredential("bangvtk", "bang160619"));
                    ////myCache.Add(new Uri("http://www.contoso.com/"), "Digest", new NetworkCredential(UserName, SecurelyStoredPassword, Domain));
                    //WebRequest wReq = WebRequest.Create(Tool.GetIPServer());
                   
                    //wReq.Credentials = myCache;

                }
                else if (Common.InlistLike(ex.Message, "The user name or password is incorrect."))
                {
                    Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\192.168.1.18 để mở file");
          
                    System.Diagnostics.Process.Start("explorer.exe", @"\\192.168.1.18");

                }
            }
            
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            DeleteFile();
        }

        void btAttach_Click(object sender, EventArgs e)
        {

            AttachFile();
        }

        void btOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        void btClose_Click(object sender, EventArgs e)
        {
            if (strFile_Name == null)
                strFile_Name = SQLExec.ExecuteReturnValue("SELECT MAX(File_Name) FROM R04CTSO_RESOURCE WHERE Stt = '" + strStt + "'").ToString();

            this.Is_Accept = false;
            this.Close();
        }
		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		#region Event

       
		bool Save()
		{
			
			return true;
		}
		

		void btAccept_Click(object sender, EventArgs e)
		{
            if (strFile_Name == null)
                strFile_Name = SQLExec.ExecuteReturnValue("SELECT MAX(File_Name) FROM R04CTSO_RESOURCE WHERE Stt = '" + strStt + "'").ToString();

            this.Is_Accept = true;
            this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
            //if (strFile_Name == null)
            //    strFile_Name = SQLExec.ExecuteReturnValue("SELECT MAX(File_Name) FROM R04CTSO_RESOURCE WHERE Stt = '"+ strStt +"'").ToString();

			this.Is_Accept = false;
			this.Close();
		}

		


		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

		#endregion

	}
}
