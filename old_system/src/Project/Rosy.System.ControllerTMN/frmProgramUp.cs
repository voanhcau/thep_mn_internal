using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Element;

namespace RosyControllerTMN
{
	public partial class frmProgramUp : RosySystem.Customize.frmView
	{
		
		#region Khai bao bien

		private DataTable dtProgram;
		private BindingSource bdsProgram = new BindingSource();

		private DataRow drCurrent;
        string strFile_Name = string.Empty;
		#endregion

		#region Contructor

        public frmProgramUp()
		{
			InitializeComponent();


            this.btExit.Click += new EventHandler(btExit_Click);

			
		}

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Load(string strFile_Name)
		{
            this.strFile_Name = strFile_Name;
			Build();
			FillData();
			BindingLanguage();

			this.ShowDialog();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvProgram.strZone = "PROGRAMUP";
			dgvProgram.BuildGridView(false);
		}

		private void FillData()
		{
            dtProgram = SQLExec.ExecuteReturnDt("SELECT * FROM R00PROUP WHERE File_Name = '" + strFile_Name + "' ORDER BY UpLoad_Date");

			bdsProgram.DataSource = dtProgram;
			dgvProgram.DataSource = bdsProgram;

			bdsProgram.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsProgram;
		}

		#endregion

		#region Update

		

		#endregion
		
		#region Su kien

		

		
			

		#endregion
	}
}
