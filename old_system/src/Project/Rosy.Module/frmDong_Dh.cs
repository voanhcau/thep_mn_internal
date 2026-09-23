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
	public partial class frmDong_Dh : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtDuyet_Ct;
		public DataTable dtDuyet_Ph;
		public DataTable dtResource;
		public DataTable dtCtYeuCau;
		

		BindingSource bdsDuyet = new BindingSource();
		BindingSource bdsDuyet_Ph = new BindingSource();
		BindingSource bdsResource = new BindingSource();
		BindingSource bdsCtYeuCau = new BindingSource();

		DataRow drDuyet;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;

		bool bDuyet_Tp = false;
		bool bDuyet_PxCd = false;
		bool bDuyet_KtCdAt = false;
		bool bDuyet_KhVt = false;
        bool bDuyet_TcHc = false;
		bool bDuyet_KtTc = false;
		bool bDuyet_Gd = false;

		bool bDuyet_Tp_Ph = false;
		bool bDuyet_PxCd_Ph = false;
		bool bDuyet_KtCdAt_Ph = false;
		bool bDuyet_KtTc_Ph = false;
		bool bDuyet_KhVt_Ph = false;
        bool bDuyet_TcHc_Ph = false;
		bool bDuyet_Gd_Ph = false;

		#endregion

		#region Contructor

        public frmDong_Dh()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);	
		}

       

		
		#endregion

		#region Method

        public void Load(string strMa_Ct)
        {
            this.strMa_Ct = strMa_Ct;
            this.dteNgay_Ct.Text = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).ToString();
            Build();
            FillData();
            BindingLanguage();
            this.ShowDialog();
        }
		
        private void BindingTong_Tien()
        {
           

        }
		void LoadDicName()
		{
           
		}

		void Build()
		{
            dgvDuyet.strZone = "SO_DONGDH";
			dgvDuyet.BuildGridView();
		

			foreach (DataGridViewColumn dgvc in dgvDuyet.Columns)
				dgvc.ReadOnly = true;
		}

		void FillData()
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
			Hashtable htPara = new Hashtable();

            htPara.Add("MA_CT", strMa_Ct);
            htPara.Add("NGAY_CT", dteNgay_Ct.Text);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetSOHuy", htPara, CommandType.StoredProcedure);

			dtDuyet_Ph = dsVoucher.Tables[0];
		
			bdsDuyet_Ph.DataSource = dtDuyet_Ph;
			dgvDuyet.DataSource = bdsDuyet_Ph;
		
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		bool Save()
		{
			
			


			try
			{
				
				
			}
			catch (Exception ex)
			{
				

				MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
				return false;
			}

			return true;
		}
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
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