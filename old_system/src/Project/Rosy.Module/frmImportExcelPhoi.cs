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
using Microsoft.Office.Interop.Excel;

namespace RosyModule
{
	public partial class frmImportExcelPhoi : RosySystem.Customize.frmView
	{
		public System.Data.DataTable dtImport;
		public BindingSource bdsImport = new BindingSource();

		public bool isAccept = false;
		string strMa_Ct = "";

		public frmImportExcelPhoi()
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

			if (Common.GetBufferValue("ImportVoucher_RowEnd") != null)
				numRowEnd.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_RowEnd"));
			else
				numRowEnd.Value = 100;

			if (Common.GetBufferValue("ImportVoucher_ColEnd") != null)
				numColEnd.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_ColEnd"));
			else
				numColEnd.Value = 35;

			cboFile_Name.DataSource = RosySystem.Data.SQLExec.ExecuteReturnDt("SELECT * FROM R00Resource WHERE Catalog = 'IMPORTEXCEL' AND File_Type = 'XLS'");
			cboFile_Name.ValueMember = "FILE_NAME";
			cboFile_Name.DisplayMember = "FILE_NAME";

			if (this.strMa_Ct == "BANGCANDOI")
			{
				numColEnd.Value = 17;
				numRowEnd.Value = 7;
			}

			this.BindingLanguage();

			this.ShowDialog();
		}

		public void Load(string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;
			
			this.Load();
		}

		void FillData()
		{
			dtImport = Common.ReadExcel(txtFilePath.Text, 1, Convert.ToInt32(numRowHeader.Value), Convert.ToInt32(numRowEnd.Value), Convert.ToInt32(numColEnd.Value));

			if (dtImport != null)
			{

				bdsImport.DataSource = Voucher.ImportExcelPhoi_SetData(this);

				dgvImport.AutoGenerateColumns = true;
				dgvImport.DataSource = bdsImport;

				this.ExportControl = dgvImport;
				this.bdsSearch = bdsImport;
			}
		}

		void btFilePath_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "xls files (*.xls)|*.xls";
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
			Common.SetBufferValue("ImportVoucher_RowEnd", numRowEnd.Value);
			Common.SetBufferValue("ImportVoucher_ColEnd", numColEnd.Value);

			this.isAccept = true;

			//Insert vao bang R05CTNX

			

			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

	}
}
