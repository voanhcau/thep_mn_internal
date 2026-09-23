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
using Microsoft.Office.Interop.Excel;
using RosySystem.Data;

namespace RosyModule
{
	public partial class frmReadExcel_ToFrom : RosySystem.Customize.frmView
	{
		public System.Data.DataTable dtImport;
		BindingSource bdsImport = new BindingSource();

		public bool isAccept = false;
        string strLoaiDL = "";

        public frmReadExcel_ToFrom()
		{
			InitializeComponent();

			btDownload.Click += new EventHandler(btDownload_Click);

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

            if (strLoaiDL == "DLSX")
            {
                numColEnd.Value = 70;
                numToRow.Value = 18;
            }
            else if (strLoaiDL == "SUCO")
            {
                numColEnd.Value = 6;
                numToRow.Value = 40;
            }
            else if (strLoaiDL == "THSX")
            {
                numColEnd.Value = 2;
                numToRow.Value = 40;
            }
            else if (strLoaiDL == "VTTB")
            {
                numColEnd.Value = 5;
                numFromRow.Value = 2;
                numToRow.Value = 100;
            }
            else if (strLoaiDL == "LYLICH")
            {
                numColEnd.Value = 8;
                numFromRow.Value = 2;
                numToRow.Value = 100;
            }
            else if (strLoaiDL == "KHVTBTTB")
            {
                numColEnd.Value = 6;
                numFromRow.Value = 2;
                numToRow.Value = 100;
            }
            else if (strLoaiDL == "DMTH")
            {
                numColEnd.Value = 6;
                numFromRow.Value = 2;
                numToRow.Value = 200;
            }
            else if (strLoaiDL == "THONGTINCAN")
            {
                numColEnd.Value = 18;
                numFromRow.Value = 2;
                numToRow.Value = 200;
            }
            else if (strLoaiDL == "LSXCAN")
            {
                numColEnd.Value = 10;
                numFromRow.Value = 2;
                numToRow.Value = 210;
            }
                //if (Common.GetBufferValue("ImportVoucher_ColEnd") != null)
                //    numColEnd.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_ColEnd"));
                //else
                //    numColEnd.Value = 35;

			cboFile_Name.DataSource = RosySystem.Data.SQLExec.ExecuteReturnDt("SELECT * FROM R00Resource WHERE Catalog = 'IMPORTEXCEL' AND File_Type = 'XLS'");
			cboFile_Name.ValueMember = "FILE_NAME";
			cboFile_Name.DisplayMember = "FILE_NAME";

			

			this.BindingLanguage();

			this.ShowDialog();
		}

        public void Load(string strLoaiDL)
		{
            this.strLoaiDL = strLoaiDL;
			
			this.Load();
		}
       
		void FillData()
		{
            dtImport = Voucher.ReadExcelToFrom(txtFilePath.Text, 1, Convert.ToInt32(numRowHeader.Value), Convert.ToInt32(numColEnd.Value), Convert.ToInt32(numFromRow.Value), Convert.ToInt32(numToRow.Value));
            
            string strColumnName = string.Empty;
            string strColumnType = string.Empty;
            string strSQLExec = string.Empty;

			if (dtImport != null)
			{
                if (dtImport.Columns.Contains("MgOball"))
                {
                  
                    foreach (DataColumn dc in dtImport.Columns)
                    {
                        strColumnName = dc.ColumnName;
                        strSQLExec = "select name from sys.columns where  OBJECT_NAME(OBJECT_ID) = 'R11DLSXLUYEN' AND system_type_id = 60 AND name = '" + strColumnName + "'";
                        strColumnType = (string)SQLExec.ExecuteReturnValue(strSQLExec);
                        if (strColumnName == strColumnType)
                        {
                            foreach (DataRow dr in dtImport.Rows)
                                if (dr[strColumnName] == null || dr[strColumnName] == "" || dr[strColumnName] == string.Empty)
                                    dr[strColumnName] = 0;
                        }
                    }

                }
                else if (strLoaiDL == "THONGTINCAN")
                {
                    
                    foreach (DataColumn dc in dtImport.Columns)
                    {
                        strColumnName = dc.ColumnName;
                        strSQLExec = "select name from sys.columns where  OBJECT_NAME(OBJECT_ID) = 'R09CANHANG' AND system_type_id = 60 AND name = '" + strColumnName + "'";
                        strColumnType = (string)SQLExec.ExecuteReturnValue(strSQLExec);
                        if (strColumnName == strColumnType)
                        {
                            foreach (DataRow dr in dtImport.Rows)
                                if (dr[strColumnName] == null || dr[strColumnName] == "" || dr[strColumnName] == string.Empty)
                                    dr[strColumnName] = 0;
                        }
                    }
                }
                else if (strLoaiDL == "LSXCAN")
                {
                   
                    if (dtImport.Columns.Contains("Time_Change"))
                    {

                        foreach (DataColumn dc in dtImport.Columns)
                        {
                            strColumnName = dc.ColumnName;
                            strSQLExec = "select name from sys.columns where  OBJECT_NAME(OBJECT_ID) = 'R13CT_LSX' AND system_type_id = 60 AND name = '" + strColumnName + "'";
                            strColumnType = (string)SQLExec.ExecuteReturnValue(strSQLExec);
                            if (strColumnName == strColumnType)
                            {
                                foreach (DataRow dr in dtImport.Rows)
                                    if (dr[strColumnName] == null || dr[strColumnName] == "" || dr[strColumnName] == string.Empty)
                                        dr[strColumnName] = 0;
                            }
                        }
                    }
                 
                }
                else
                {
                    if (dtImport.Columns.Contains("So_Luong_LD"))
                    {
                       
                        foreach (DataColumn dc in dtImport.Columns)
                        {
                            strColumnName = dc.ColumnName;
                            strSQLExec = "select name from sys.columns where  OBJECT_NAME(OBJECT_ID) = 'R06VTTB' AND system_type_id = 60 AND name = '" + strColumnName + "'";
                            strColumnType = (string)SQLExec.ExecuteReturnValue(strSQLExec);
                            if (strColumnName == strColumnType)
                            {
                                foreach (DataRow dr in dtImport.Rows)
                                    if (dr[strColumnName] == null || dr[strColumnName] == "" || dr[strColumnName] == string.Empty)
                                        dr[strColumnName] = 0;
                            }
                        }
                    }

                }
			    bdsImport.DataSource = dtImport;
				
				dgvImport.AutoGenerateColumns = true;
				dgvImport.DataSource = bdsImport;

				this.ExportControl = dgvImport;
				this.bdsSearch = bdsImport;
			}
		}

		void btFilePath_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel files (.xls or .xlsx)|*.xls;*.xlsx";
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

		void btDownload_Click(object sender, EventArgs e)
		{
			object objFile_Content = RosySystem.Common.Resource.LoadResource("IMPORTEXCEL", cboFile_Name.Text, "XLS");

			if (objFile_Content != null)
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "(*.XLS;*.XLSX)|*.XLS;*.XLSX|All files (*.*)|*.*";
				sfd.FileName = cboFile_Name.Text;

				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					System.IO.FileStream fileStream = new System.IO.FileStream(sfd.FileName, FileMode.Create, FileAccess.ReadWrite);
					fileStream.Write((byte[])objFile_Content, 0, ((byte[])objFile_Content).Length);
					fileStream.Close();
					fileStream.Dispose();

					System.Diagnostics.Process.Start(sfd.FileName);
				}
			}
			else
			{
				Common.MsgCancel("Không tồn tại file mẫu [" + cboFile_Name.Text + "]");
			}
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			Common.SetBufferValue("ImportVoucher_RowHeader", numRowHeader.Value);
			
			Common.SetBufferValue("ImportVoucher_ColEnd", numColEnd.Value);

			this.isAccept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

	}
}
