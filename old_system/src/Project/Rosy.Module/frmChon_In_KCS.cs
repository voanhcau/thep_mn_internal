using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RosyModule
{
	public partial class frmChon_In_KCS: RosySystem.Customize.frmEdit
	{
		public frmChon_In_KCS()
		{
			InitializeComponent();

			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btPath.Click += new EventHandler(btPath_Click);
		}

		new public void Load()
		{
			this.dteNgay_Ct.Text = DateTime.Now.ToShortDateString();
			this.ShowDialog();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
        void btPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;

            //folderBrowserDialog.
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;


            txtPath.Text = folderBrowserDialog.SelectedPath;

        }
		void btAccept_Click(object sender, EventArgs e)
		{
			isAccept = true;
			this.Close();
		}
	}
}
