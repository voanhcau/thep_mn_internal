using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Common;

namespace RosyModule
{
	public partial class frmExportExcel_ : RosySystem.Customize.frmEdit
	{
		public string strPath = string.Empty;
		string strTen_Bc = string.Empty;

		public frmExportExcel_()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			btPath.Click += new EventHandler(btPath_Click);
		}

		public void Load()
		{
			if (Common.GetBufferValue("EXPORT_EXCEL_PATH") == null)
				txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			else
				txtPath.Text = Common.GetBufferValue("EXPORT_EXCEL_PATH");

			txtPath.Text = txtPath.Text + (txtPath.Text.EndsWith(@"\") ? "" : @"\") + strTen_Bc.Trim() + ".xls";

			this.ShowDialog();
		}

		void btPath_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfdlg = new SaveFileDialog();
			sfdlg.OverwritePrompt = true;
			sfdlg.InitialDirectory = Common.GetBufferValue("EXPORT_EXCEL_PATH");
			sfdlg.DefaultExt = "xls";
			sfdlg.Filter = "*.xls|*.xls";

			if (sfdlg.ShowDialog() == DialogResult.OK)
			{
				strPath = sfdlg.FileName;
				txtPath.Text = strPath;

				Common.SetBufferValue("EXPORT_EXCEL_PATH", System.IO.Path.GetDirectoryName(sfdlg.FileName));
			}
		}	

		void btAccept_Click(object sender, EventArgs e)
		{
			strPath = txtPath.Text.Trim();

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
