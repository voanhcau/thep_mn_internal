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
	public partial class frmDuyetCongTangCa : RosySystem.Customize.frmView
	{
		#region Declare
        //private rsDataGridView dgvPhanHoiKHVT= new rsDataGridView();

		public DataTable dtEditCt;
		BindingSource bdsEditCt = new BindingSource();

        public DataTable dtDuyet;
        BindingSource bdsDuyet = new BindingSource();

        string strMa_Bp = string.Empty;
        DateTime dtNgay_Ct1; DateTime dtNgay_Ct2;
        DataRow drCurrent;

        int iThang;
        int iNam;

		public bool Is_Accept = false;
        bool Is_DuyetCong = false;
		#endregion

		#region Contructor

        public frmDuyetCongTangCa()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.KeyDown += new KeyEventHandler(frmDuyetCongTangCa_KeyDown);
            chkDuyet.CheckedChanged += new EventHandler(chkDuyet_CheckedChanged);
            chkDuyet_Huy.CheckedChanged += new EventHandler(chkDuyet_Huy_CheckedChanged);
            chkAll.CheckedChanged += new EventHandler(chkAll_CheckedChanged);
            dgvDuyetBangCong.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyetBangCong_CellValidating);
			
		}

        void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            Is_DuyetCong = false;
            FillData();
        }

        void chkDuyet_Huy_CheckedChanged(object sender, EventArgs e)
        {
            chkDuyet.Checked = false;
        }

        void chkDuyet_CheckedChanged(object sender, EventArgs e)
        {
            chkDuyet_Huy.Checked = false;
        }

       
      

		#endregion

		#region Method

		public void Load(string strMa_Bp, DateTime dtNgay_Ct1, DateTime dtNgay_Ct2, bool Is_DuyetCong)
		{
            this.strMa_Bp = strMa_Bp;
            this.dtNgay_Ct1 = dtNgay_Ct1;
            this.dtNgay_Ct2 = dtNgay_Ct2;
            this.Is_DuyetCong = Is_DuyetCong;

            iThang = dtNgay_Ct1.Month;
            iNam = dtNgay_Ct1.Year;

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
            if (!Is_DuyetCong)
            {
                this.chkDuyet.Visible = false;
                this.chkDuyet_Huy.Visible = false;
                lbtGhi_Chu.Visible = false;
                this.chkAll.Visible = true;

                this.TabPhanHoi.TabPages.Remove(tpChamCong);
            }
            else
            {
                this.chkDuyet.Visible = true;
                this.chkDuyet_Huy.Visible = true;
                lbtGhi_Chu.Visible = true;

                this.chkAll.Visible = false;
                this.TabPhanHoi.TabPages.Remove(tpCongTangCa);

                this.Text = "Duyệt bảng chấm công từ ngày " + dtNgay_Ct1.ToShortDateString() + " đến ngày " + dtNgay_Ct2.ToShortDateString() + "";
            }

			dgvDuyetTangCa.strZone = "DUYETCONGTANGCA";
			dgvDuyetTangCa.BuildGridView();
			
			foreach (DataGridViewColumn dgvc in dgvDuyetTangCa.Columns)
				dgvc.ReadOnly = true;

            if (dgvDuyetTangCa.Columns.Contains("So_Gio"))
                dgvDuyetTangCa.Columns["So_Gio"].ReadOnly = false;
            if (dgvDuyetTangCa.Columns.Contains("Chon"))
                dgvDuyetTangCa.Columns["Chon"].ReadOnly = false;


            dgvDuyetBangCong.strZone = "KQCHAMCONGDUYET";
            dgvDuyetBangCong.BuildGridView();

            foreach (DataGridViewColumn dgvc in dgvDuyetBangCong.Columns)
                dgvc.ReadOnly = true;

            if (dgvDuyetBangCong.Columns.Contains("LOAI_ABC"))
                dgvDuyetBangCong.Columns["LOAI_ABC"].ReadOnly = false;
            if (dgvDuyetBangCong.Columns.Contains("GHI_CHU"))
                dgvDuyetBangCong.Columns["GHI_CHU"].ReadOnly = false;

            this.dgvDuyetBangCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuyetBangCong.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

            if (this.dgvDuyetBangCong.Columns.Contains("Ten_Dt_CbNv"))
                this.dgvDuyetBangCong.Columns["Ten_Dt_CbNv"].Frozen = true;
		}

		void FillData()
		{

            Hashtable ht = new Hashtable();
            ht.Add("MA_BP", strMa_Bp);
            ht.Add("NGAY_CT1", dtNgay_Ct1);
            ht.Add("NGAY_CT2", dtNgay_Ct2);
           
             if (!Is_DuyetCong)
            {
                string strKey = " AND 0 = 0 ";
               
                 if (chkAll.Checked != true)
                    strKey += " AND Duyet_TP = 0";

                string strSQL = "SELECT T1.*, T2.Ten_Dt AS Ten_Dt_CbNv, Ma_Bp, Ma_Bp_Ct, CAST(CASE WHEN Duyet_TP = 1 THEN 1 ELSE 0 END AS BIT) AS Chon FROM R10CONGTANGCA T1 JOIN (SELECT Ma_Dt, Ten_Dt, Ma_Bp, Ma_Bp_Ct FROM R81DMDT) T2 " +
                        " ON T1.Ma_Dt_CbNv = T2.Ma_Dt WHERE Ma_Bp = @Ma_Bp AND Ngay_Cham_Cong BETWEEN @Ngay_Ct1 AND @Ngay_Ct2 " + strKey;

                dtEditCt = SQLExec.ExecuteReturnDt(strSQL, ht, CommandType.Text);

                bdsEditCt.DataSource = dtEditCt;
                dgvDuyetTangCa.DataSource = bdsEditCt;
            }
            else
            {
                dtDuyet = SQLExec.ExecuteReturnDt("SP_GetDuyetBangCong", ht, CommandType.StoredProcedure);
                bdsDuyet.DataSource = dtDuyet;
                dgvDuyetBangCong.DataSource = bdsDuyet;
                
                 chkDuyet.Checked = Convert.ToBoolean(dtDuyet.Rows[0]["Duyet_Cong"]);
                 lblDuyet_Log.Text = Convert.ToString(dtDuyet.Rows[0]["Duyet_Log"]);
            }
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		#region Event

        void dgvDuyetBangCong_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsDuyet.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            bool bLookup = true;

            if (strColumnName == "LOAI_ABC")
                bLookup = dgvLookupMa_Vt_Tt(ref dgvCell);
        }


        private bool dgvLookupMa_Vt_Tt(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;
            string strFilter = "Type='HS_ABC'";

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "HS_ABC");
            DataRow drLookup = Lookup.ShowLookup("HS_ABC", strValue, bRequire, strFilter, "", htField);

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsDuyet.Current).Row;

                dgvDuyetBangCong.CancelEdit();
                dgvCell.Value = drLookup["Type_ID"].ToString();
                dgvCell.Tag = drLookup["Type_Name"].ToString();

                drCurrent["Hs_Luong_Bp"] = Convert.ToDouble(drLookup["Type_Value"]);
            }

            return true;





        }

        #endregion

        #region Update
        

	

		bool Save()
		{
            foreach (DataRow dr in dtEditCt.Rows)
            {
                
                Hashtable HT = new Hashtable();
                HT.Add("DUYET_TP", (bool)dr["Chon"]);
                HT.Add("DUYET_TP_LOG", Common.GetCurrent_Log());
                HT.Add("IDENT00", dr["Ident00"]);

                string strSQLEXEC = "UPDATE R10CONGTANGCA SET Duyet_Tp = @Duyet_Tp, Duyet_Tp_Log = @Duyet_Tp_Log WHERE Ident00 = @Ident00";
                SQLExec.Execute(strSQLEXEC,HT, CommandType.Text);
                
            }

			return true;
		}
        void UpdateDLLuong(DataTable dtImport)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

           

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@THANG", iThang);
            sqlCom.Parameters.AddWithValue("@NAM", iNam);
            sqlCom.Parameters.AddWithValue("@MA_BP", strMa_Bp);

            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_DLCONG";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_DLCONG";
            paraCt.Value = Voucher.GetTVPValue("R10BANGCONG", "TVP_DLCONG", dtImport);
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
        bool DuyetBangCong()
        {
            if (chkDuyet.Checked == true)
            {
                // kiểm tra trước khi lưu
                foreach (DataRow dr in dtDuyet.Rows)
                {

                    if (dr["Loai_ABC"].ToString() != "A" && dr["Ghi_Chu"].ToString() == "" && dr["Ma_Dt_CbNv"].ToString()!= "")
                    {
                        Common.MsgOk("Cần bổ sung lý do điều chỉnh HS ABC cho nhân viên " + dr["Ten_Dt_CbNv"] + " !!!");
                        return false;
                    }
                }

                // chuyển dữ liệu sang bảng công

                try
                {
                    UpdateDLLuong(dtDuyet);
                    Common.MsgOk("Đã duyệt bảng công của đơn vị trong tháng " + iThang + " năm "+ iNam +"");
                    return true;
                }
                catch (Exception ex)
                {
                    Common.MsgOk(ex.Message);
                }
            }
            else if (chkDuyet_Huy.Checked == true)
            {
                Hashtable ht = new Hashtable ();
                ht.Add("NAM", iNam);
                ht.Add("THANG", iThang);
                ht.Add("MA_BP", strMa_Bp);
                SQLExec.Execute("DELETE FROM R10BANGCONG WHERE NAM = @NAM AND THANG = @THANG AND MA_BP = @MA_BP", ht, CommandType.Text);
                Common.MsgOk(Languages.GetLanguage("SUCCESS"));
                return true;
            }
            return true;
        }

		void btAccept_Click(object sender, EventArgs e)
		{
			if(!Is_DuyetCong)
			{
                if (this.Save())
                {
                    this.Is_Accept = true;
                    this.Close();
                }
			}
            else 
            {
                if (this.DuyetBangCong())
                {
                    this.Is_Accept = true;
                    this.Close();
                }
            }

		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

        void frmDuyetCongTangCa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {

                for (int i = 0; i < dgvDuyetTangCa.Rows.Count; i++)
                {
                    dtEditCt.Rows[i]["CHON"] = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.U)
            {

                for (int i = 0; i < dgvDuyetTangCa.Rows.Count; i++)
                {
                    dtEditCt.Rows[i]["CHON"] = false;
                }
            }
        }
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
        }

        #endregion

    }

}