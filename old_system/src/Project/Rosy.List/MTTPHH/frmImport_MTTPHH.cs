using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Common;
using Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Win32;

namespace RosyList
{
	public partial class frmImport_MTTPHH : RosySystem.Customize.frmView
	{
		public System.Data.DataTable dtImport;
		BindingSource bdsImport = new BindingSource();
		
		public bool isAccept = false;

		public frmImport_MTTPHH()
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
			if (GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "Import_RowHeader") != null)
				numRowHeader.Value = Int32.Parse(GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "Import_RowHeader"));
			else
				numRowHeader.Value = 1;

			if (GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "Import_RowEnd") != null)
				numRowEnd.Value = Int32.Parse(GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "Import_RowEnd"));
			else
				numRowEnd.Value = 100;

			if (GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "Import_ColEnd") != null)
				numColEnd.Value = Int32.Parse(GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "Import_ColEnd"));
			else
				numColEnd.Value = 30;

			if (GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "ImportExcelPath") != null)
				txtFilePath.Text = GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "ImportExcelPath");
			else
				txtFilePath.Text = string.Empty;

			if (GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "Import_Not_All_Melt") != null)
				rdbImport_Not_All_Melt.Checked = Convert.ToBoolean(GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "Import_Not_All_Melt"));
			else
				rdbImport_All.Checked = true;

			
			cboFile_Name.DataSource = RosySystem.Data.SQLExec.ExecuteReturnDt("SELECT * FROM R00Resource WHERE Catalog = 'IMPORTEXCEL' AND File_Type = 'XLS'");
			cboFile_Name.ValueMember = "FILE_NAME";
			cboFile_Name.DisplayMember = "FILE_NAME";

			this.BindingLanguage();

			this.ShowDialog();
		}

		void FillData()
		{
			dtImport = Common.ReadExcel(txtFilePath.Text, 1, Convert.ToInt32(numRowHeader.Value), Convert.ToInt32(numRowEnd.Value), Convert.ToInt32(numColEnd.Value));

			if (dtImport != null)
			{
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

			if (GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "ImportExcelPath") != null)
				ofd.InitialDirectory = GetSetRegestry.GetBufferValue("IMPORT MTTPHH", "ImportExcelPath");
			else
				ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtFilePath.Text = ofd.FileName;
				GetSetRegestry.SetBufferValue("IMPORT MTTPHH", "ImportExcelPath", txtFilePath.Text);
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
			GetSetRegestry.SetBufferValue("IMPORT MTTPHH", "Import_RowHeader", numRowHeader.Value);
			GetSetRegestry.SetBufferValue("IMPORT MTTPHH", "Import_RowEnd", numRowEnd.Value);
			GetSetRegestry.SetBufferValue("IMPORT MTTPHH", "Import_ColEnd", numColEnd.Value);
			GetSetRegestry.SetBufferValue("IMPORT MTTPHH", "ImportExcelPath", txtFilePath.Text);
			GetSetRegestry.SetBufferValue("IMPORT MTTPHH", "Import_Not_All_Melt", rdbImport_Not_All_Melt.Checked);

			this.isAccept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
	}

	public static class GetSetRegestry
	{
		public static bool SetBufferValue(string strFolder, string strBufferName, object objBufferValue)
		{
			try
			{
				RegistryKey rk = Registry.CurrentUser;
				RegistryKey sk1 = rk.CreateSubKey("SOFTWARE\\VietRoad\\ROSY-ERP 5.0\\" + strFolder + "\\");
				sk1.SetValue(strBufferName, objBufferValue);

				return true;
			}
			catch (Exception e)
			{
				Common.MsgCancel("Writing registry " + strBufferName);
				return false;
			}

			return true;
		}

		public static string GetBufferValue(string strFolder, string strBufferName)
		{
			try
			{
				RegistryKey rk = Registry.CurrentUser;
				RegistryKey sk1 = rk.OpenSubKey("SOFTWARE\\VietRoad\\ROSY-ERP 5.0\\" + strFolder + "\\");

				if (sk1 == null)
				{
					return null;
				}
				else
				{
					return (string)sk1.GetValue(strBufferName);
				}
			}
			catch (Exception e)
			{
				Common.MsgCancel("Error reading registry " + strBufferName);

				return null;
			}
		}
	}
}
