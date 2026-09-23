using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Common;

namespace RosyCommonTMN
{
	public partial class frmExportTMN : RosySystem.Customize.frmEdit
    {
        public string strPath;
        public string strTen_Bc;
    

        public frmExportTMN()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
            btPath.Click += new EventHandler(btPath_Click);
            cboExportType.Validated += new EventHandler(cboExportType_Validated);
		}

        void cboExportType_Validated(object sender, EventArgs e)
        {
            if (RosySystem.Common.Common.GetBufferValue("EXPORT_EXCEL_PATH") == null)
            {
                this.strPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }
            else
            {
                this.strPath = RosySystem.Common.Common.GetBufferValue("EXPORT_EXCEL_PATH");
            }
            switch (this.cboExportType.Text.Substring(0, 1))
            {
                case "1":
                    this.txtPath.Text =  this.strPath.Trim() +  @"\" + this.strTen_Bc.Trim() + ".xlsx";// "\"  & this.strTen_Bc.Trim() + ".xlsx";
                    break;

                case "2":
                    //this.txtPath = this.strPath + "\" + this.strTen_Bc.Trim() + ".docx";
                    break;

                //case "3":
                //    this.txtPath.Text(this.strPath + @"\" + this.strTen_Bc.Trim() + ".pdf");
                //    break;

                //case "4":
                //    this.txtPath.set_Text(this.strPath + @"\" + this.strTen_Bc.Trim() + ".htm");
                //    break;

                //case "5":
                //    this.txtPath.set_Text(this.strPath + @"\" + this.strTen_Bc.Trim() + ".dbf");
                //    break;

                //case "6":
                //    this.txtPath.set_Text(this.strPath + @"\" + this.strTen_Bc.Trim() + ".txt");
                //    break;

                case "7":
                    this.txtPath.Text = this.strPath.Trim() + @"\" + this.strTen_Bc.Trim() + ".xls";// 
                    break;
            }
        }

        void btPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.CreatePrompt = true;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = (RosySystem.Common.Common.GetBufferValue("EXPORT_EXCEL_PATH"));
            
            switch (this.cboExportType.Text.Substring(0, 1))
            {
                case "1":
                    dialog.DefaultExt = "xlsx";
                    dialog.Filter = "*.xlsx|*.xlsx";
                    break;

                case "2":
                    dialog.DefaultExt = "docx";
                    dialog.Filter = ("*.doc|*.docx");
                    break;

                case "3":
                    dialog.DefaultExt = ("pdf");
                    dialog.Filter = ("*.pdf|*.pdf");
                    break;

                case "4":
                    dialog.DefaultExt = ("Htm");
                    dialog.Filter = ("*.Htm|*.Htm");
                    break;

                case "5":
                    dialog.DefaultExt = ("Dbf");
                    dialog.Filter = ("*.Dbf|*.Dbf");
                    break;

                case "6":
                    dialog.DefaultExt = ("txt");
                    dialog.Filter = ("*.txt|*.txt");
                    break;
                
                case "7":
                    dialog.DefaultExt = "xls";
                    dialog.Filter = "*.xls|*.xls";
                    break;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.strPath = dialog.FileName;
                this.txtPath.Text = this.strPath;
                RosySystem.Common.Common.SetBufferValue("EXPORT_EXCEL_PATH", System.IO.Path.GetDirectoryName(dialog.FileName));
            }
        }

        new public void Load(string strTen_Bc)
        {
            this.strTen_Bc = strTen_Bc;
           

            cboExportType.Items.Clear();
            cboExportType.Items.AddRange(new string[] { "1 - Excel Wordbook (*.xlsx)", "2 - Export to MS word", "3 - Export to PDF type","4 - Export to HTML type","5 - Export to Foxpro (.dbf)","6 - Export to .txt file", "7 - Excel 97-2003 (*.xls)"});
            cboExportType.SelectedIndex = 0;

            if (Common.GetBufferValue("EXPORT_EXCEL_PATH") == null)
                txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                txtPath.Text = Common.GetBufferValue("EXPORT_EXCEL_PATH");

            txtPath.Text = txtPath.Text + (txtPath.Text.EndsWith(@"\") ? "" : @"\") + strTen_Bc.Trim() + ".xlsx";
           
            base.ShowDialog();
		}

		private void LoadDicName() { }

		private bool FormCheckValid()
		{
			

			return true;
		}

		private bool Save()
		{
			

			return true; 
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
            this.strPath = this.txtPath.Text.Trim();
            base.isAccept = true;
            base.Close();
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
            this.isAccept = false;
            this.Close();
		}


    }
}