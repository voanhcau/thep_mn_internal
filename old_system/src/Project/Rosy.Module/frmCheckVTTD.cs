using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;
using RosySystem.Element;
using System.Data.SqlClient;

namespace RosyModule
{
	public partial class frmCheckVTTD: RosySystem.Customize.frmView
	{

		#region Khai bao bien
		public DataTable dtViewPn;
		BindingSource bdsViewPn = new BindingSource();
		//rsDataGridView dgvViewPn = new rsDataGridView();

        public bool Is_Accept;
		
		#endregion 						

		#region Contructor

		public frmCheckVTTD()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(DataTable dtViewPn)
		{

            this.dtViewPn = dtViewPn;


			Build();
			FillData();
			BindingLanguage();

		
			ShowDialog();		  
		}	
		
		#endregion

		#region Build, FillData
		private void Build()
		{
			//dgvViewPn.Dock = DockStyle.Fill;
			dgvViewPn.strZone = "CHECKVTPTTD";
			dgvViewPn.BuildGridView(this.isLookup);

			this.Controls.Add(dgvViewPn);
			dgvViewPn.ReadOnly = false;
		}

		private void FillData()
		{

                
            bdsViewPn.DataSource = dtViewPn;
            dgvViewPn.DataSource = bdsViewPn;

            bdsViewPn.Position = 0;

            

			

			foreach (DataGridViewColumn dgvc in dgvViewPn.Columns)
				dgvc.ReadOnly = true;

			
			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsViewPn;
		}

		#endregion		

		#region Su kien	

		protected override void OnKeyDown(KeyEventArgs e)
		{
            Is_Accept = true;
			base.OnKeyDown(e);
		}

		void btAccept_Click(object sender, EventArgs e)
		{
            Is_Accept = true;
            this.Close();
		}
		void btCancel_Click(object sender, EventArgs e)
		{
            Is_Accept = true;
			this.Close();
		}

		#endregion 
	}
}