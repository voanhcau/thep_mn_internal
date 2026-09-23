using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosyList;
using RosySystem.Customize;
using RosySystem;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;
using RosySystem.Element;
using System.Data.SqlClient;

namespace RosyModule.Receivable
{
	public partial class frmDuyetQDGia : RosySystem.Customize.frmView
	{
        string strSo_QD;
        private DataTable dtPH;
		private DataTable dtQDGia;
        private DataTable dtCTrinh;
		private BindingSource bdsQDGia = new BindingSource();
        private BindingSource bdsCTrinh = new BindingSource();	
		private DataRow drCurrent;
        public bool isAccept = false;
        bool bEdit = true;
        string strLoaiDuyet;
		#region Phuong thuc

        public frmDuyetQDGia()
		{
			InitializeComponent();

            btAccept.Click += new EventHandler(btAccept_Click);
            btExit.Click += new EventHandler(btExit_Click);
          
           
            btBrHtGn.Click += new EventHandler(btBrHtGn_Click);
          
            btBrPtVc.Click += new EventHandler(btBrPtVc_Click);
            
            dgvQDGia.CellValidated += new DataGridViewCellEventHandler(dgvQDGia_CellValidated);
            dgvQDGia.CellClick += new DataGridViewCellEventHandler(dgvQDGia_CellClick);
            
          
            numStt_QD.Validating += new CancelEventHandler(numStt_QD_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Dt_Chung.Validating += new CancelEventHandler(txtMa_Dt_Chung_Validating);
            
		}

      

        

        new public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strLoaiDuyet)
        {

            this.strSo_QD = drEdit["So_Qd"].ToString();
            this.strLoaiDuyet = strLoaiDuyet;

            numStt_QD.ReadOnly = true;
            numSo_Luong_Max.ReadOnly = true;
            txtSo_Qd.ReadOnly = true;
            txtHt_Gn.ReadOnly = true;
            txtPt_Vc.ReadOnly = true;
            txtMa_Dt.ReadOnly = true;
            txtMa_Dt_Chung.ReadOnly = true;
            dteNgay_QD.ReadOnly = true;
            dteNgay_BD.ReadOnly = true;
            dteNgay_KT.ReadOnly = true;
            
            Build();
            FillData(strSo_QD);

            BindingLanguage();

            this.ShowDialog();
        }
        private void Build()
        {

            dgvQDGia.strZone = "QDGIA_EDITCT";
            dgvQDGia.Dock = DockStyle.Fill;
            dgvQDGia.BuildGridView(false);

            dgvCTrinh.strZone = "CTRINH_QDGIA";
            dgvCTrinh.Dock = DockStyle.Fill;
            dgvCTrinh.BuildGridView(false);

            foreach (DataGridViewColumn dgvc in dgvQDGia.Columns)
                dgvc.ReadOnly = true;


            foreach (DataGridViewColumn dgvc in dgvCTrinh.Columns)
                dgvc.ReadOnly = true;

            if (dgvQDGia.Columns.Contains("Gia_PL2"))
                dgvQDGia.Columns["Gia_PL2"].ReadOnly = false;
            if (dgvQDGia.Columns.Contains("Gia_CKTM"))
                dgvQDGia.Columns["Gia_CKTM"].ReadOnly = false;
            if (dgvQDGia.Columns.Contains("Gia_CKSL"))
                dgvQDGia.Columns["Gia_CKSL"].ReadOnly = false;
            if (dgvQDGia.Columns.Contains("Gia_TNgay"))
                dgvQDGia.Columns["Gia_TNgay"].ReadOnly = false;
            if (dgvQDGia.Columns.Contains("Gia_HTCT"))
                dgvQDGia.Columns["Gia_HTCT"].ReadOnly = false;
            if (dgvQDGia.Columns.Contains("Gia_VC"))
                dgvQDGia.Columns["Gia_VC"].ReadOnly = false;
            if (dgvQDGia.Columns.Contains("Gia_Duyet"))
                dgvQDGia.Columns["Gia_Duyet"].ReadOnly = false;
            if (dgvQDGia.Columns.Contains("Gia_CLPL2"))
                dgvQDGia.Columns["Gia_CLPL2"].ReadOnly = false;
        }

        private void FillData(string strSo_QD)
        {
            
            Hashtable ht = new Hashtable();
            ht.Add("SO_QD", strSo_QD);
            DataSet dsQDGia = SQLExec.ExecuteReturnDs("sp_GetQDGIA", ht, CommandType.StoredProcedure);
            //PH
            dtPH = dsQDGia.Tables[0];
            if (dtPH.Rows.Count > 0)
            {
                numStt_QD.Value = Convert.ToInt16(dtPH.Rows[0]["Stt_Qd"]);
                numSo_Luong_Max.Value = Convert.ToInt64(dtPH.Rows[0]["So_Luong_Max"]);
                txtSo_Qd.Text = dtPH.Rows[0]["So_Qd"].ToString();
                txtMa_Dt.Text = dtPH.Rows[0]["Ma_Dt"].ToString();
                lbtTen_Dt.Text = dtPH.Rows[0]["Ten_Dt"].ToString();
                txtMa_Dt_Chung.Text = dtPH.Rows[0]["Ma_Dt_Chung"].ToString();
                lbtTen_Dt_Chung.Text = dtPH.Rows[0]["Ten_Dt_Chung"].ToString();
                dteNgay_QD.Text = Convert.ToDateTime(dtPH.Rows[0]["Ngay_Qd"]).ToShortDateString();
                dteNgay_BD.Text = Convert.ToDateTime(dtPH.Rows[0]["Ngay_Bd"]).ToShortDateString();
                dteNgay_KT.Text = Convert.ToDateTime(dtPH.Rows[0]["Ngay_Kt"]).ToShortDateString();
                chkIs_CK.Checked = Convert.ToBoolean(dtPH.Rows[0]["Is_Ck"]);
                txtHt_Gn.Text = dtPH.Rows[0]["Ht_Gn"].ToString();
                txtPt_Vc.Text = dtPH.Rows[0]["Pt_Vc"].ToString();
               
                txtSo_Qd_Org.Text = dtPH.Rows[0]["So_Qd_Org"].ToString();

                if (strLoaiDuyet == "PKD")
                    chkDuyet.Checked = Convert.ToBoolean(dtPH.Rows[0]["Duyet_PKD"]);
                else if (strLoaiDuyet == "GD")
                    chkDuyet.Checked = Convert.ToBoolean(dtPH.Rows[0]["Duyet_Gd"]);
            }
            //CT
            dtQDGia = dsQDGia.Tables[1];
            bdsQDGia.DataSource = dtQDGia;
            dgvQDGia.DataSource = bdsQDGia;

            //CTRINH
            dtCTrinh = dsQDGia.Tables[2];
            bdsCTrinh.DataSource = dtCTrinh;
            dgvCTrinh.DataSource = bdsCTrinh;
        }
		private bool FormCheckValid()
		{
			bool bvalid = true;

			

			return bvalid;
		}
        private void Save()
        {
            string strPH = string.Empty;
            Hashtable htPH = new Hashtable();
            if (isAccept)
            {
                if (strLoaiDuyet == "PKD")
                {
                    htPH.Add("DUYET_LOG_PKD", Common.GetCurrent_Log());
                    htPH.Add("DUYET_PKD", chkDuyet.Checked);
                    htPH.Add("SO_QD", txtSo_Qd.Text);
                    strPH = "UPDATE R80PH_QDGIA SET DUYET_PKD = @DUYET_PKD, DUYET_LOG_PKD = @DUYET_LOG_PKD WHERE So_QD = @So_Qd";
                }
                else
                {
                    htPH.Add("DUYET_LOG_GD", Common.GetCurrent_Log());
                    htPH.Add("DUYET_GD", chkDuyet.Checked);
                    htPH.Add("SO_QD", txtSo_Qd.Text);
                    strPH = "UPDATE R80PH_QDGIA SET DUYET_GD = @DUYET_GD, DUYET_LOG_GD = @DUYET_LOG_GD WHERE So_QD = @So_Qd";
                }
                SQLExec.Execute(strPH, htPH, CommandType.Text);
                //CT
                UpdateQDGia(dtQDGia);
            }
        }
       
       
        void btAccept_Click(object sender, EventArgs e)
        {
            isAccept = true;
            Save();
            this.Close();
        }

        void btExit_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }
		#endregion
      
        void UpdateQDGia(DataTable dtImport)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@strNew_Edit", bEdit ? "E" : "N");
            sqlCom.Parameters.AddWithValue("@SO_QD", txtSo_Qd.Text);

            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_CTQDGIA";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_CTQDGIA";
            paraCt.Value = Voucher.GetTVPValue("R04CT_QDGIA", "TVP_CTQDGIA", dtImport);
            sqlCom.Parameters.Add(paraCt);

            try
            {
                sqlCom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.Clear();
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);

            }
        }
     
        #region Su kien

       


        void dgvQDGia_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            drCurrent = ((DataRowView)bdsQDGia.Current).Row;
            Cal_Gia(drCurrent);
           
           
        }
        private void Cal_Gia(DataRow drEditCt)
        {
            drEditCt["Gia_Duyet"] = Convert.ToDouble(drEditCt["Gia_PL2"]) - Convert.ToDouble(drEditCt["Gia_CKTM"]) - Convert.ToDouble(drEditCt["Gia_CKSL"]) - Convert.ToDouble(drEditCt["Gia_TNgay"]) - Convert.ToDouble(drEditCt["Gia_HTCT"]) - Convert.ToDouble(drEditCt["Gia_VC"]);
            drEditCt["GiaTC"] = Convert.ToDouble(drEditCt["Gia_Duyet"]) + Convert.ToDouble(drEditCt["Gia_CKSL"]);
            drEditCt["GiaTN"] = Convert.ToDouble(drEditCt["GiaTC"]) - 150;
            drEditCt.AcceptChanges();
        }
        void dgvQDGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            drCurrent = ((DataRowView)bdsQDGia.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.InlistLike(strColumnName, "CHON"))
            {
               
            }
        }
        void numStt_QD_Validating(object sender, CancelEventArgs e)
        {
            if (dteNgay_QD.Text != "")
                txtSo_Qd.Text = Convert.ToString(numStt_QD.Value) + "-" + Convert.ToDateTime(dteNgay_QD.Text).ToString("yyyy") + "/QD-TMN";
        }
        //void numStt_QD_TextChanged(object sender, EventArgs e)
        //{
        //    if (numStt_QD.bTextChange && dteNgay_QD.bTextChange)
                
        //}

        void txtMa_Dt_Chung_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Chung.Text.Trim();
            bool bRequire = false;
            if (txtMa_Dt.Text.Trim() == string.Empty)
                bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_Chung.Text = string.Empty;
                lbtTen_Dt_Chung.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Chung.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt_Chung.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }

        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = true;
            if (txtMa_Dt_Chung.Text.Trim() == string.Empty)
                bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }
        void btBrPtVc_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowMultiLookup("Pt_Vc", txtPt_Vc.Text, bRequire, "Type='PT_VC'", "");

            if (drLookup == null)
            {
                txtPt_Vc.Text = string.Empty;
            }
            else
            {
                txtPt_Vc.Text = drLookup["MultiSelectValue"].ToString();
            }
        }

        

        void btBrHtGn_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowMultiLookup("Type_ID", txtHt_Gn.Text, bRequire, "TYPE = 'HT_GN'", "");

            if (drLookup == null)
            {
                txtHt_Gn.Text = string.Empty;
            }
            else
            {
                txtHt_Gn.Text = drLookup["MultiSelectValue"].ToString();
            }
        }

        
		#endregion      
        
	}
}