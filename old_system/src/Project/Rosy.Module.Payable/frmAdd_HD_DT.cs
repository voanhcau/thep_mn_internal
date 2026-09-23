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


namespace RosyModule.Payable
{
	public partial class frmAdd_HD_DT : RosySystem.Customize.frmView
	{
		#region Declare
        //private rsDataGridView dgvPhanHoiKHVT= new rsDataGridView();

		public DataTable dtEditCt;
		public DataTable dtEditPh;
		public DataTable dtPhanHoiKTCDAT;

		BindingSource bdsPhanHoiKTCDAT = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
		BindingSource bdsEditPh = new BindingSource();
		
		DataRow drDuyet;
        DataRow drCurrent;
		string strMa_Dt = string.Empty;
        string strMa_Hd = string.Empty;
		
		public bool Is_Accept = false;
		#endregion

		#region Contructor

		public frmAdd_HD_DT()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            
            dgvCtDt.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
          
			
		}

      

		#endregion

		#region Method

        public void Load(string strMa_Dt, string strMa_Hd)
		{

            this.strMa_Dt = strMa_Dt;
            this.strMa_Hd = strMa_Hd;

			Build();
			FillData();
			BindingLanguage();

			this.LoadDicName();
			this.ShowDialog();
		}

		void LoadDicName()
		{
			
		}

		void Build()
		{
			dgvCtDt.strZone = "ADD_HD_DT";
            dgvCtDt.BuildGridView();
            

			foreach (DataGridViewColumn dgvc in dgvCtDt.Columns)
				dgvc.ReadOnly = true;

            if (dgvCtDt.Columns.Contains("Chon"))
                dgvCtDt.Columns["Chon"].ReadOnly = false;
           
		}

		void FillData()
		{
			
			Hashtable htPara = new Hashtable();
            htPara.Add("MA_DT", strMa_Dt);

            dtEditCt = SQLExec.ExecuteReturnDt("sp_GetDmHd_Dt", htPara, CommandType.StoredProcedure);

			bdsEditCt.DataSource = dtEditCt;
			dgvCtDt.DataSource = bdsEditCt; 
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		#region Event
      
        void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            bool bLookup = true;
           if (strColumnName == "MA_HD")
                bLookup = dgvLookupMa_Hd(ref dgvCell);
          
        }
        private bool dgvLookupMa_Hd(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCtDt.CancelEdit();
                dgvCell.Value = drLookup["Ma_Hd"].ToString();
                dgvCell.Tag = drLookup["Ten_Hd"].ToString();

            }
            return true;
        }
        #endregion

        #region Update
      

		

		bool Save()
		{
            foreach (DataRow dr in dtEditCt.Select("Chon = 1"))
            {
                string strSql = "UPDATE R04CTPO SET Ma_Hd = '" + strMa_Hd + "' WHERE Stt = '" + dr["Stt"] + "'";
                SQLExec.Execute(strSql);
            }

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

        #endregion

    }

}