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
	public partial class frmQDGia_Edit : RosySystem.Customize.frmView
	{
        string strSo_QD;
        private DataTable dtPH;
		private DataTable dtQDGia;
		private BindingSource bdsQDGia = new BindingSource();		
		private DataRow drCurrent;
        public bool isAccept = false;
        bool bEdit = true;
		#region Phuong thuc

        public frmQDGia_Edit()
		{
			InitializeComponent();

            btAccept.Click += new EventHandler(btAccept_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btInherit.Click += new EventHandler(btInherit_Click);
            btBrCtrinh.Click += new EventHandler(btBrCtrinh_Click);
            btBrHtGn.Click += new EventHandler(btBrHtGn_Click);
            btBrHtTt.Click += new EventHandler(btBrHtTt_Click);
            btBrPtVc.Click += new EventHandler(btBrPtVc_Click);
            btImport.Click += new EventHandler(btImport_Click);
            dgvQDGia.CellValidated += new DataGridViewCellEventHandler(dgvQDGia_CellValidated);
            dgvQDGia.CellClick += new DataGridViewCellEventHandler(dgvQDGia_CellClick);
            
            //numStt_QD.TextChanged += new EventHandler(numStt_QD_TextChanged);
            numStt_QD.Validating += new CancelEventHandler(numStt_QD_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Dt_Chung.Validating += new CancelEventHandler(txtMa_Dt_Chung_Validating);
            txtMa_CTrinh.Validating += new CancelEventHandler(txtMa_CTrinh_Validating);
            txtSo_Qd_Ck.Validating += new CancelEventHandler(txtSo_Qd_Ck_Validating);
            txtSo_Qd_Modify.Validating += new CancelEventHandler(txtSo_Qd_Modify_Validating);
		}

       

      

       

       

      

        

        new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
            if (enuNew_Edit == enuEdit.New)
            {
                dteNgay_QD.Text = dteNgay_BD.Text = dteNgay_KT.Text = dteNgay_TTrinh.Text = DateTime.Now.ToShortDateString();
                bEdit = false;

                txtHt_Gn.Text = drEdit["Ht_Gn"].ToString();
                txtPt_Vc.Text = drEdit["Pt_Vc"].ToString();
                txtMa_Dt.Text = drEdit["Ma_Dt"].ToString();
                txtMa_Dt_Chung.Text = drEdit["Ma_Dt_Chung"].ToString();
                txtMa_CTrinh.Text = drEdit["Ma_CTrinh"].ToString();
                txtMa_PLCTrinh_List.Text = drEdit["Ma_PLCTrinh_List"].ToString();
                //txtMa_PLCTrinh_List.Text = drEdit["Ma_PLCTrinh_List"].ToString();
                numSo_Luong_Max.Value = Convert.ToDouble(drEdit["So_Luong_Max"]);
                numChenh_Lech.Value = Convert.ToDouble(drEdit["Chenh_Lech"]);
                this.strSo_QD = "0";
            }
            else
                this.strSo_QD = drEdit["So_Qd"].ToString();

            txtMa_Dt.bUseAutoDropDown = true;

          
			
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

            foreach (DataGridViewColumn dgvc in dgvQDGia.Columns)
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
            if (dgvQDGia.Columns.Contains("Bold"))
                dgvQDGia.Columns["Bold"].ReadOnly = false;
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
                numChenh_Lech.Value = Convert.ToInt64(dtPH.Rows[0]["Chenh_Lech"]);
                txtSo_Qd.Text = dtPH.Rows[0]["So_Qd"].ToString();
                txtMa_Dt.Text = dtPH.Rows[0]["Ma_Dt"].ToString();
                lbtTen_Dt.Text = dtPH.Rows[0]["Ten_Dt"].ToString();
                txtMa_Dt_Chung.Text = dtPH.Rows[0]["Ma_Dt_Chung"].ToString();
                lbtTen_Dt_Chung.Text = dtPH.Rows[0]["Ten_Dt_Chung"].ToString();
                dteNgay_QD.Text = Convert.ToDateTime(dtPH.Rows[0]["Ngay_Qd"]).ToShortDateString();
                dteNgay_BD.Text = Convert.ToDateTime(dtPH.Rows[0]["Ngay_Bd"]).ToShortDateString();
                dteNgay_KT.Text = Convert.ToDateTime(dtPH.Rows[0]["Ngay_Kt"]).ToShortDateString();
                dteNgay_TTrinh.Text = dtPH.Rows[0]["Ngay_TTrinh"].ToString() != "" ? Convert.ToDateTime(dtPH.Rows[0]["Ngay_TTrinh"]).ToShortDateString() : "";
                chkIs_CK.Checked = Convert.ToBoolean(dtPH.Rows[0]["Is_Ck"]);
                txtHt_Gn.Text = dtPH.Rows[0]["Ht_Gn"].ToString();
                txtPt_Vc.Text = dtPH.Rows[0]["Pt_Vc"].ToString();
                txtMa_CTrinh.Text = dtPH.Rows[0]["Ma_CTrinh"].ToString();
                txtMa_PLCTrinh_List.Text = dtPH.Rows[0]["Ma_PLCTrinh_List"].ToString();
                txtSo_Qd_Org.Text = dtPH.Rows[0]["So_Qd_Org"].ToString();
                txtSo_TTrinh.Text = dtPH.Rows[0]["So_TTrinh"].ToString();
                txtSo_Qd_Ck.Text = dtPH.Rows[0]["So_Qd_Ck"].ToString();
                dteNgay_Qd_Ck.Text = dtPH.Rows[0]["Ngay_Qd_Ck"].ToString() != "" ? Convert.ToDateTime(dtPH.Rows[0]["Ngay_Qd_Ck"]).ToShortDateString() : "";
                txtHt_Tt.Text = dtPH.Rows[0]["Ht_Tt"].ToString();
            }
            //CT
            dtQDGia = dsQDGia.Tables[1];
            bdsQDGia.DataSource = dtQDGia;
            dgvQDGia.DataSource = bdsQDGia;
        }
		private bool FormCheckValid()
		{
            bool bvalid = true;
            if (txtHt_Tt.Text == "")
            {
                Common.MsgOk("Hình thức thanh toán không được phép rỗng!!!");
                bvalid = false;
            }
		

			

			return bvalid;
		}
        private void Save()
        {
            string strPH = string.Empty; 
            Hashtable htPH = new Hashtable();
            htPH.Add("SO_QD",txtSo_Qd.Text);
            htPH.Add("SO_QD_CK", txtSo_Qd_Ck.Text);
            htPH.Add("SO_TTRINH", txtSo_TTrinh.Text);
            htPH.Add("NGAY_QD",dteNgay_QD.Text);
            htPH.Add("MA_DT",txtMa_Dt.Text);
            htPH.Add("MA_DT_CHUNG",txtMa_Dt_Chung.Text);
            htPH.Add("STT_QD",numStt_QD.Value);
            htPH.Add("SO_LUONG_MAX",numSo_Luong_Max.Value);
            htPH.Add("CHENH_LECH", numChenh_Lech.Value);
            htPH.Add("NGAY_BD",dteNgay_BD.Text);
            htPH.Add("NGAY_KT",dteNgay_KT.Text);
            htPH.Add("NGAY_TTRINH", dteNgay_TTrinh.Text);
            htPH.Add("NGAY_QD_CK", dteNgay_Qd_Ck.Text == "  /  /" ? "01/01/1900" : dteNgay_Qd_Ck.Text);
            htPH.Add("NGAY_THAY_THE", dteNgay_Thay_The.Text == "  /  /" ? "01/01/1900" : dteNgay_Thay_The.Text);
            htPH.Add("SO_QD_MODIFY", txtSo_Qd_Modify.Text);
            htPH.Add("SO_QD_ORG",txtSo_Qd_Org.Text);
            htPH.Add("MA_CTRINH", txtMa_CTrinh.Text);
            htPH.Add("MA_PLCTRINH_LIST",txtMa_PLCTrinh_List.Text);
         
            htPH.Add("PT_VC",txtPt_Vc.Text);
            htPH.Add("HT_GN",txtHt_Gn.Text);
            htPH.Add("HT_TT", txtHt_Tt.Text);
            htPH.Add("IS_CK",chkIs_CK.Checked);
            htPH.Add("CREATE_LOG", Common.GetCurrent_Log());
            htPH.Add("MA_DVCS", Element.sysMa_DvCs);
            //PH
            if(!bEdit)
            {
                strPH = "INSERT INTO R80PH_QDGIA( So_Qd, Stt_Qd, So_TTrinh, Ngay_Qd, Ma_Dt, Ma_Dt_Chung,So_Qd_Ck, Ma_PLCTrinh_List, Ma_Ctrinh, So_Luong_Max, Chenh_Lech, Ngay_Bd, Ngay_Kt, Ngay_TTrinh, Ngay_QD_CK, So_Qd_Org, Pt_Vc, Ht_Gn, Ht_Tt, Is_Ck, Create_Log, LastModify_Log, Ma_DvCs, So_Qd_Modify, Ngay_Thay_The)" +
                            " SELECT @So_Qd, @Stt_Qd, @So_TTrinh, @Ngay_Qd, @Ma_Dt, @Ma_Dt_Chung, @So_Qd_Ck, @Ma_PLCTrinh_List, @Ma_CTrinh, @So_Luong_Max, @Chenh_Lech, @Ngay_Bd, @Ngay_Kt, @Ngay_TTrinh, @Ngay_QD_CK, @So_Qd_Org, @Pt_Vc, @Ht_Gn, @Ht_Tt, @Is_Ck, @Create_Log, '', @Ma_DvCs, @So_Qd_Modify, @Ngay_Thay_The";
            }
            else
            {
                htPH.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
                strPH = "UPDATE R80PH_QDGIA SET Ngay_Qd = @Ngay_Qd, So_TTrinh = @So_TTrinh, Ma_Dt = @Ma_Dt, Ma_Dt_Chung=@Ma_Dt_Chung, So_Qd_Ck = @So_Qd_Ck, Ht_Tt = @Ht_Tt, Ngay_QD_CK = @Ngay_QD_CK, Ma_PLCTrinh_List = @Ma_PLCTrinh_List, Ma_CTrinh = @Ma_CTrinh, Chenh_Lech = @Chenh_Lech, So_Luong_Max = @So_Luong_Max, Ngay_Bd = @Ngay_Bd, Ngay_Kt = @Ngay_Kt, Ngay_TTrinh = @Ngay_TTrinh,  So_Qd_Org = @So_Qd_Org, Pt_Vc = @Pt_Vc, Ht_Gn = @Ht_Gn, Is_Ck = @Is_Ck, LastModify_Log = @LastModify_Log, So_Qd_Modify = @So_Qd_Modify, Ngay_Thay_The = @Ngay_Thay_The WHERE So_QD = @So_Qd";
            }
            SQLExec.Execute(strPH, htPH, CommandType.Text);
            //CT
             UpdateQDGia(dtQDGia);
            
        }
        void SETDATA(DataTable dtImport)
        {
            foreach (DataRow drSelect in dtImport.Rows)
            {
                DataRow drEditCtNew = dtQDGia.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);
                string strTen_Vt = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", drSelect["Ma_Vt"].ToString());
                drEditCtNew["Ma_Vt"] = drSelect["Ma_Vt"];
                drEditCtNew["Ten_Vt"] = strTen_Vt;
                drEditCtNew["Gia_PL2"] = drSelect["Gia_PL2"];
                drEditCtNew["Gia_CKTM"] = drSelect["Gia_CKTM"];
                drEditCtNew["Gia_CKSL"] = drSelect["Gia_CKSL"];
                drEditCtNew["Gia_TNgay"] = drSelect["Gia_TNgay"];
                drEditCtNew["Gia_HTCT"] = drSelect["Gia_HTCT"];
                drEditCtNew["Gia_VC"] = drSelect["Gia_VC"];

                drEditCtNew["Gia_Duyet"] = drSelect["Gia_Duyet"];
                drEditCtNew["Gia_CLPL2"] = drSelect["Gia_CLPL2"];
                drEditCtNew["GiaTC"] = drSelect["GiaTC"];
                drEditCtNew["GiaTN"] = drSelect["GiaTN"];
                dtQDGia.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }
        }
        void btImport_Click(object sender, EventArgs e)
        {
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("QDGIA");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                SETDATA(frmImport.dtImport);
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

        void btInherit_Click(object sender, EventArgs e)
        {
            frmInherit_QDGia frm = new frmInherit_QDGia();
            frm.Load(Convert.ToDateTime(dteNgay_QD.Text));
            if (frm.is_Accept)
            {
                if (frm.dtInheritVoucher.Select("Chon = true").Length == 0)
                    return;

                DataRow drInheritVoucher = frm.dtInheritVoucher.Select("Chon = 1")[0];

                txtSo_Qd_Org.Text = frm.dtInheritVoucher.Rows[0]["So_Qd"].ToString();
                foreach (DataRow drSelect in frm.dtInheritVoucher.Select("Chon = true"))
                {
                    DataRow drEditCtNew = dtQDGia.NewRow();
                    Common.CopyDataRow(drSelect, drEditCtNew);
                    Common.SetDefaultDataRow(ref drEditCtNew);

                    drEditCtNew["Ma_Vt"] = drSelect["Ma_Vt"];
                    drEditCtNew["Ten_Vt"] = drSelect["Ten_Vt"];
                    drEditCtNew["Gia_PL2"] = drSelect["Gia_TC40"];
                    drEditCtNew["Gia_Duyet"] = drSelect["Gia_TC40"];
                    dtQDGia.Rows.Add(drEditCtNew);
                    drEditCtNew.AcceptChanges();
                }
            }
        }


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
        void txtSo_Qd_Modify_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_Qd_Modify.Text.Trim();
            if (strValue == string.Empty)
                return;
            bool bRequire = false;


            string strKeyValid = "";
            string strKeyFilter = string.Empty;
            strKeyFilter = " So_Qd_Dt <> '" + txtSo_Qd.Text + "' AND (CHARINDEX('" + txtMa_Dt.Text.Trim() + "',Nhom_Dt) > 0 OR Nhom_Dt LIKE '%*')" +
                                
                                 " AND Ma_CTrinh='" + txtMa_CTrinh.Text.Trim() + "' " +
                                 " AND (Ngay_Het_Han >= '" + dteNgay_KT.Text + "'  OR Ngay_Het_Han <='19000101')";
            // " AND (CHARINDEX('" + txtMa_Kho.Text.Trim() + "',Ma_Kho_List) > 0 OR Ma_Kho_List LIKE '%*')" +

            DataRow drLookup = Lookup.ShowLookup("So_Qd_Dt", strValue, bRequire, strKeyFilter, strKeyValid);
            if (drLookup == null)
            {
                txtSo_Qd_Modify.Text = string.Empty;

            }
            else
            {
                txtSo_Qd_Modify.Text = drLookup["So_Qd_Dt"].ToString();
            }
        }
        void txtSo_Qd_Ck_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_Qd_Ck.Text.Trim();
            bool bRequire = false;

            string strFilter = "Type='SOQD_CHIETKHAU'";
            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "SOQD_CHIETKHAU");
           
            DataRow drLookup = Lookup.ShowMultiLookup("SOQD_CHIETKHAU", txtSo_Qd_Ck.Text, bRequire, strFilter, "");
            if (drLookup == null)
            {
                txtSo_Qd_Ck.Text = string.Empty;
               
            }
            else
            {
                txtSo_Qd_Ck.Text = drLookup["MultiSelectValue"].ToString();
                


            }
        }
        void txtMa_CTrinh_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_CTrinh.Text.Trim();
            bool bRequire = false;
          

            DataRow drLookup = Lookup.ShowLookup("Ma_CTrinh", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_CTrinh.Text = string.Empty;
                lbtTen_CTrinh.Text = string.Empty;
            }
            else
            {
                txtMa_CTrinh.Text = ((string)drLookup["Ma_CTrinh"]).Trim();
                lbtTen_CTrinh.Text = ((string)drLookup["Ten_CTrinh"]).Trim();
            }
        }
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

        void btBrHtTt_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowMultiLookup("Loai_Gia", txtHt_Tt.Text, bRequire, "Type='Loai_Gia'", "");

            if (drLookup == null)
            {
                txtHt_Tt.Text = string.Empty;
            }
            else
            {
                txtHt_Tt.Text = drLookup["MultiSelectValue"].ToString();
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

        void btBrCtrinh_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_PLCtrinh", txtMa_PLCTrinh_List.Text, bRequire, "Ma_CTrinh = '"+ txtMa_CTrinh.Text +"'", "");

            if (drLookup == null)
            {
                txtMa_PLCTrinh_List.Text = string.Empty;
            }
            else
            {
                txtMa_PLCTrinh_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }
		#endregion      

        //private void rsLabel20_Click(object sender, EventArgs e)
        //{

        //}

        //private void txtSo_Qd_Modify_TextChanged(object sender, EventArgs e)
        //{

        //}
        
	}
}