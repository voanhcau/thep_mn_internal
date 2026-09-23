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


namespace RosyModule
{
	public partial class frmCheck_Gia_Mua : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtCheck_Gia;
		BindingSource bdsDuyet = new BindingSource();
		DataRow drDuyet;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		
		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;

        bool bCheckVTPTTD = false;
		#endregion

		#region Contructor

		public frmCheck_Gia_Mua()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);	
			
		}

		#endregion

		#region Method

		public void Load(DataRow drDuyet)
		{
			this.drDuyet = drDuyet;

			this.strMa_Ct = (string)drDuyet["Ma_Ct"];
			this.strStt = (string)drDuyet["Stt"];

			Build();
            FillData();
			BindingLanguage();

			this.LoadDicName();
			this.ShowDialog();
		}

		public void Load1(string strMa_Vt)
		{
			
			Build();
			FillData(strMa_Vt);
			BindingLanguage();

			this.LoadDicName();
			this.ShowDialog();
		}
        public void Load2(DataTable dtCheckVTPTTD)
        {
            this.bCheckVTPTTD = true;
            Build();
            FillData(dtCheckVTPTTD);
            BindingLanguage();

            this.LoadDicName();
            this.ShowDialog();
        }

		void LoadDicName()
		{
			
		}

		void Build()
		{
            if(bCheckVTPTTD)
                dgvCheck_Gia.strZone = "CHECK_VTPTTD";
            else
			    dgvCheck_Gia.strZone = "CHECK_GIA_MUA";
			
			dgvCheck_Gia.BuildGridView();

			foreach (DataGridViewColumn dgvc in dgvCheck_Gia.Columns)
				dgvc.ReadOnly = true;
		}
		void FillData(string strMa_Vt)
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("STT", strStt);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			string strSQL = "SELECT T1.*, T2.Ten_Vt, T3.Ten_Dt FROM R02CTNM T1 JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt " +
				"JOIN R81DMDT T3 ON T1.Ma_Dt = T3.Ma_Dt " +
				"WHERE T1.Ma_Vt = '"+ strMa_Vt +"'" +
				" ORDER BY Ngay_Ct DESC";

			dtCheck_Gia = SQLExec.ExecuteReturnDt(strSQL, htPara, CommandType.Text);

			bdsDuyet.DataSource = dtCheck_Gia;
			dgvCheck_Gia.DataSource = bdsDuyet;


		}

        void FillData(DataTable dtCheck)
        {

            dtCheck_Gia = dtCheck;

            bdsDuyet.DataSource = dtCheck_Gia;
            dgvCheck_Gia.DataSource = bdsDuyet;


        }
		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("STT", strStt);


			dtCheck_Gia = SQLExec.ExecuteReturnDt("dbo.sp_CheckGia",htPara,CommandType.StoredProcedure);

			bdsDuyet.DataSource = dtCheck_Gia;
			dgvCheck_Gia.DataSource = bdsDuyet;

			
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		//#region Event
	
		bool Save()
		{
			return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.Is_Accept = true;
				this.Close();
			}
		}

		

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}
			


	}

}