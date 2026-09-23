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

namespace RosyModule.Receivable
{
    public partial class frmKGHD : RosySystem.Customize.frmView
	{
		#region Khai bao bien
		
		DataTable dtDmDt;

	
		BindingSource bdsDmDt = new BindingSource();

		private DataRow drCurrent;

		#endregion

		#region Contructor

        public frmKGHD()
		{
			InitializeComponent();

            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtSo_Qd.Validating += new CancelEventHandler(txtSo_Qd_Validating);

            dgvDmDt.CellValidated += new DataGridViewCellEventHandler(dgvDmDt_CellValidated);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvDmDt.strZone = "INHERITPXKG";
			dgvDmDt.BuildGridView();

            dgvDmDt.BuildGridView();

            ExportControl = dgvDmDt;
            dgvDmDt.ReadOnly = false;

            foreach (DataGridViewColumn dgvc in dgvDmDt.Columns)
                dgvc.ReadOnly = true;

            if (dgvDmDt.Columns.Contains("CHON"))
                dgvDmDt.Columns["CHON"].ReadOnly = false;
            if (dgvDmDt.Columns.Contains("SO_LUONG"))
                dgvDmDt.Columns["SO_LUONG"].ReadOnly = false;

            txtMa_Ct.Text = "PXHCP";
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
		}

        private void Refresh()
        {
            Hashtable ht = new Hashtable();

            ht.Add("MA_CT", txtMa_Ct.Text);
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_DT", txtMa_Dt.Text);
            ht.Add("TK_NO", txtTk_No.Text);
            ht.Add("TK_CO", txtTk_Co.Text);
            ht.Add("SO_QD", txtSo_Qd.Text);

            dtDmDt = SQLExec.ExecuteReturnDt("sp_GetKGPXHD", ht, CommandType.StoredProcedure);
            bdsDmDt.DataSource = dtDmDt;
            dgvDmDt.DataSource = bdsDmDt;

            bdsSearch = bdsDmDt;
            bdsLookup = bdsDmDt;
        
        }
		private void FillData()
		{
            txtMa_Dt.bUseAutoDropDown = true;
            txtSo_Qd.bUseAutoDropDown = true;

           

            //Refresh();
		}

		#endregion

		#region Update


        void dgvDmDt_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            drCurrent = ((DataRowView)bdsDmDt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "SO_LUONG,GIA"))
            {
                drCurrent["Tien"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia"]);
            }
        }

		
		#endregion
        
        void txtSo_Qd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_Qd.Text.Trim();
            if (strValue == string.Empty)
                return;
            bool bRequire = false;


            string strKeyValid = "";
            string strKeyFilter = string.Empty;
            strKeyFilter = "(CHARINDEX('" + txtMa_Dt.Text.Trim() + "',Nhom_Dt) > 0 OR Nhom_Dt LIKE '%*')" +
                                 " AND (Ngay_Het_Han >= '" + dteNgay_Ct2.Text + "'  OR Ngay_Het_Han <='19000101')";


            DataRow drLookup = Lookup.ShowLookup("So_Qd_Dt", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = false;

            if (drLookup == null)
            {
                txtSo_Qd.Text = string.Empty;
            }
            else
            {
                txtSo_Qd.Text = drLookup["So_QD"].ToString();
              
            }
        }

        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
            }
        }
        void txtMa_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Ct.Text.Trim();
            bool bRequire = true;
            string strKey = string.Empty;

            
            DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, strKey);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
                txtMa_Ct.Text = string.Empty;
            else
            {
                txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
            }
        }
        void btRefresh_Click(object sender, EventArgs e)
		{
            Refresh();
		}
        void btExit_Click(object sender, EventArgs e)
        {
           this.Close();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
        private void Save()
        {
            if (dtDmDt == null)
                return;
            
            DataTable dtSave = dtDmDt.Clone();
            DataRow[] Result = dtDmDt.Select("Chon = 1");

            foreach (DataRow dr in Result)
                dtSave.ImportRow(dr);

            SqlCommand sqlCom = SQLExec.GetSQLCommand();
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.CommandText = "Sp_Update_BBKG_PXHD";

            SqlParameter sqlPara = new SqlParameter();
            sqlPara.ParameterName = "@TVP_KGPXHD";

            sqlPara.SqlDbType = SqlDbType.Structured;
            sqlPara.TypeName = "TVP_KGPXHD";
            sqlPara.Value = Voucher.GetTVPValue("R04CTKG_PXHD", "TVP_KGPXHD", dtSave);

            sqlCom.Parameters.Add(sqlPara);
            try
            {
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.Message);
            }



        }
        void btPrint_Click(object sender, EventArgs e)
        {
           //Luu phiếu
            Save();
           // In phiếu
        }
	}
}
