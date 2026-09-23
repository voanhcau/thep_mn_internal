using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using RosySystem.Control;
using RosyModule;
using System.Data.SqlClient;
using RosySystem.Customize;
using RosySystem.Public;


namespace RosyModule.Machinery
{
    public partial class frmDuyetKHBT : RosySystem.Customize.frmView
	{
		DataTable dtKHVTPKTDT;
		BindingSource bdsKHVTPKTDT = new BindingSource();
		DataRow drCurrent;
        string strLoaiDuyet = string.Empty;
        bool bKHVT = false;
        string strFilterTb = string.Empty;
        public frmDuyetKHBT()
		{
			InitializeComponent();

            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
            txtPt_Bt.Validating += new CancelEventHandler(txtPt_Bt_Validating);

			this.btExit.Click += new EventHandler(btExit_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
            this.btPrint.Click += new EventHandler(btPrint_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
            dgvKHVTPKTDT.KeyDown += new KeyEventHandler(dgvKHVTPKTDT_KeyDown);
            dgvKHVTPKTDT.CellContentClick += new DataGridViewCellEventHandler(dgvKHVTPKTDT_CellContentClick);
            chkDuyet.Click += new EventHandler(chkDuyet_Click);
		}

       

        new public void Load(string strLoaiDuyet, bool bKHVT)
		{
            this.strLoaiDuyet = strLoaiDuyet;
            this.bKHVT = bKHVT;
            string strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
            txtMa_Bp.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt_CbNv + "'");

			this.Build();
            //FillData();
			this.BindingLanguage();

			this.ShowDialog();
		}

		private void Build()
		{
            txtMa_Tb.bUseAutoDropDown = true;
            txtMa_Nh_Tb.bUseAutoDropDown = true;
            txtMa_Bp.bUseAutoDropDown = true;

            numNam.Value = Element.sysWorkingYear;
           
            if(!(bool)bKHVT)
			    dgvKHVTPKTDT.strZone = "DUYETKHBT";
            else
                dgvKHVTPKTDT.strZone = "DUYETKHVTPT";
            
            dgvKHVTPKTDT.BuildGridView();          
           
            dgvKHVTPKTDT.ReadOnly = false;
            foreach (DataGridViewColumn dgvc in dgvKHVTPKTDT.Columns)
                dgvc.ReadOnly = true;
            if (strLoaiDuyet == "TP" & dgvKHVTPKTDT.Columns.Contains("Duyet_TP"))
                dgvKHVTPKTDT.Columns["Duyet_TP"].ReadOnly = false;
            else if (strLoaiDuyet == "KTDT" & dgvKHVTPKTDT.Columns.Contains("Duyet_KTDT"))
                dgvKHVTPKTDT.Columns["Duyet_KTDT"].ReadOnly = false;
            else if (strLoaiDuyet == "KHVT" & dgvKHVTPKTDT.Columns.Contains("Duyet_KHVT"))
                dgvKHVTPKTDT.Columns["Duyet_KHVT"].ReadOnly = false;
            else if (strLoaiDuyet == "GD" & dgvKHVTPKTDT.Columns.Contains("Duyet_GiamDoc"))
                dgvKHVTPKTDT.Columns["Duyet_GiamDoc"].ReadOnly = false;

            if ((bool)bKHVT)
            {
                txtThang_Th.Visible = false;
                txtPt_Bt.Visible = false;
                lbtThang_Th.Visible = false;
                lbtPt_Bt.Visible = false;
            }
            if(strLoaiDuyet == "TP" && dgvKHVTPKTDT.Columns.Contains("SO_LUONG_TP"))
                dgvKHVTPKTDT.Columns["SO_LUONG_TP"].ReadOnly = false;
            else if (strLoaiDuyet == "KTDT" && dgvKHVTPKTDT.Columns.Contains("SO_LUONG_KTDT"))
                dgvKHVTPKTDT.Columns["SO_LUONG_KTDT"].ReadOnly = false;
            else if (strLoaiDuyet == "KHVT" && dgvKHVTPKTDT.Columns.Contains("SO_LUONG_KHVT"))
                dgvKHVTPKTDT.Columns["SO_LUONG_KHVT"].ReadOnly = false;
            else if (strLoaiDuyet == "GD" && dgvKHVTPKTDT.Columns.Contains("SO_LUONG_GD"))
                dgvKHVTPKTDT.Columns["SO_LUONG_GD"].ReadOnly = false;

            if (dgvKHVTPKTDT.Columns.Contains("Noi_Dung"))
            {
                dgvKHVTPKTDT.Columns["Noi_Dung"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvKHVTPKTDT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvKHVTPKTDT.Columns.Contains("Noi_Dung_Th"))
            {
                dgvKHVTPKTDT.Columns["Noi_Dung_Th"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvKHVTPKTDT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            
            
            bool bDuyet_KtDt = false;
            bool bDuyet_KhVt = false;
            bool bDuyet_Gd = false;
            if (bKHVT)
            {

                bDuyet_KtDt = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_KTDT FROM R06KHVTPT WHERE Nam = " + numNam.Value + " GROUP BY Duyet_KTDT "));
                bDuyet_KhVt = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_KHVT FROM R06KHVTPT WHERE Nam = " + numNam.Value + " GROUP BY Duyet_KHVT "));
                bDuyet_Gd = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_GiamDoc FROM R06KHVTPT WHERE Nam = " + numNam.Value + " GROUP BY Duyet_GiamDoc "));
                if (strLoaiDuyet == "TP" && bDuyet_KtDt)
                {
                    chkDuyet.Enabled = false;
                    btSave.Enabled = false;
                }
                else if (strLoaiDuyet == "KTDT" && bDuyet_KhVt)
                {
                    chkDuyet.Enabled = false;
                    btSave.Enabled = false;
                }
                else if (strLoaiDuyet == "KHVT" && bDuyet_Gd)
                {
                    chkDuyet.Enabled = false;
                    btSave.Enabled = false;
                }
            }
            else
            {
                
                bDuyet_KtDt = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_KTDT FROM R06KHBTTB WHERE Nam = " + numNam.Value + " GROUP BY Duyet_KTDT "));
                bDuyet_Gd = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_GiamDoc FROM R06KHBTTB WHERE Nam = " + numNam.Value + " GROUP BY Duyet_GiamDoc "));
                if (strLoaiDuyet == "TP" && bDuyet_KtDt)
                {
                    chkDuyet.Enabled = false;
                    btSave.Enabled = false;
                }
                else if (strLoaiDuyet == "KTDT" && bDuyet_Gd)
                {
                    chkDuyet.Enabled = false;
                    btSave.Enabled = false;
                }
            }
            if (dgvKHVTPKTDT.Columns.Contains("So_Luong"))
            {
                dgvKHVTPKTDT.Columns["So_Luong"].HeaderText = "Số lượng cần mua";
            }
		}

		private void FillData()
		{
            bool bNotDuyet = false;
            
            if (chkNotDuyet.Checked)
                bNotDuyet = true;
            
            Hashtable ht = new Hashtable();
            ht.Add("NAM", numNam.Value);
            ht.Add("MA_NH_TB", txtMa_Nh_Tb.Text);
            ht.Add("MA_TB", txtMa_Tb.Text);
            ht.Add("PT_BT", txtPt_Bt.Text);
            ht.Add("MA_BP", txtMa_Bp.Text);
            ht.Add("THANG_TH", txtThang_Th.Text);
            ht.Add("LOAI_DUYET", strLoaiDuyet);
            ht.Add("IS_VTPT", bKHVT);
            ht.Add("IS_NOTDUYET", bNotDuyet);
            dtKHVTPKTDT = SQLExec.ExecuteReturnDt("sp_GetKHBTTB", ht, CommandType.StoredProcedure);
			bdsKHVTPKTDT.DataSource = dtKHVTPKTDT;
			dgvKHVTPKTDT.DataSource = bdsKHVTPKTDT;
		}

        void dgvKHVTPKTDT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            this.Design();
                            break;
                    }
                    break;
            }
        }
        bool Save_KHBT()
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
         
            sqlCom.Parameters.AddWithValue("@Loai_Duyet", strLoaiDuyet);
            sqlCom.Parameters.AddWithValue("@Duyet", chkDuyet.Checked);
            sqlCom.Parameters.AddWithValue("@Log_Duyet", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_KHBTTB";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_KHBTTB";
            paraCt.Value = Voucher.GetTVPValue("R06KHBTTB", "TVP_KHBTTB", this.dtKHVTPKTDT);
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
                return false;
            }
            return true;
        }
        bool Save_KHVTPT()
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@Loai_Duyet", strLoaiDuyet);
            sqlCom.Parameters.AddWithValue("@Duyet", chkDuyet.Checked);
            sqlCom.Parameters.AddWithValue("@Log_Duyet", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_KHVTPT";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_KHVTPT";
            paraCt.Value = Voucher.GetTVPValue("R06KHVTPT", "TVP_KHVTPT", this.dtKHVTPKTDT);
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
                return false;
            }
            return true;
        }
        void btSave_Click(object sender, EventArgs e)
        {
            if (!bKHVT)
            {
                if (Save_KHBT())
                {
                    Common.MsgOk("Bạn đã duyệt xong!!!");
                    this.Close();
                }
            }
            else
            {
                if (Save_KHVTPT())
                {
                    Common.MsgOk("Bạn đã duyệt xong!!!");
                    this.Close();
                }
            }
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            this.printDetail_Tb(true);
        }
        private void Design()
        {
            string strReportFile = string.Empty;

            DataRow drKHVTPKTDT = ((DataRowView)bdsKHVTPKTDT.Current).Row;


            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            //Load form chọn in

            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drKHVTPKTDT, false,"");

            if (frm.isAccept)
            {
                string strLoai_BTTB = "";
                
                if (frm.rdbPlan_BTTB_NB.Checked == true)
                    strLoai_BTTB = "NB";
                else if (frm.rdbPlan_BTTB_BN.Checked == true)
                    strLoai_BTTB = "BN";
                else
                    strLoai_BTTB = "VTPT";

                if (strLoai_BTTB == "BN")
                    strReportFile = "rptPlan_BTTB_BN";
                else if (strLoai_BTTB == "NB")
                    strReportFile = "rptPlan_BTTB_NB";
                else
                    strReportFile = "rptPlan_VTPT";

                RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
                frmDesign.Load(strReportFile);
            }
        }
        private bool printDetail_Tb(bool bPreview)
        {
            string strReportFile = string.Empty;
            
            if (bdsKHVTPKTDT.Position < 0)
                return false;

            DataRow drKHVTPKTDT = ((DataRowView)bdsKHVTPKTDT.Current).Row;


            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            //Load form chọn in

            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drKHVTPKTDT, false, txtMa_Bp.Text);

            if (frm.isAccept)
            {
                string strLoai_BTTB = "";
                bool bIs_Th = false;
                if (frm.btPlan_KHVTPT_02.Checked == false)
                {
                    if (frm.rdbPlan_BTTB_NB.Checked == true)
                        strLoai_BTTB = "NB";
                    else
                        strLoai_BTTB = "BN";

                    
                        bIs_Th = true;

                    Hashtable ht = new Hashtable();
                    ht.Add("MA_NH_TB", frm.txtMa_Nh_Tb.Text);
                    ht.Add("LOAI_BTTB", strLoai_BTTB);
                    ht.Add("IS_TH", bIs_Th);
                    ht.Add("NAM", frm.txtNam.Text);
                    ht.Add("MA_BP", frm.txtMa_Bp.Text);
                    ht.Add("USER_LOGIN", Element.sysUser_Id);

                    ht.Add("MA_DVCS", Element.sysMa_DvCs);

                    DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLichBTTB", ht, CommandType.StoredProcedure);
                    dtHeader = ds.Tables[0];
                    dtDetail = ds.Tables[1];

                    if (strLoai_BTTB == "BN")
                        strReportFile = "rptPlan_BTTB_BN";
                    else
                        strReportFile = "rptPlan_BTTB_NB";

                    if (!dtKHVTPKTDT.Columns.Contains("REPORT_FILE"))
                        dtKHVTPKTDT.Columns.Add("REPORT_FILE", typeof(string));
                    if (!dtKHVTPKTDT.Columns.Contains("NGAY_CT"))
                        dtKHVTPKTDT.Columns.Add("NGAY_CT", typeof(DateTime));


                    drKHVTPKTDT["NGAY_CT"] = Element.sysNgay_Ct2;
                    drKHVTPKTDT["REPORT_FILE"] = strReportFile;

                    RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                    return frmPrint.Load(drKHVTPKTDT, dtDetail, bPreview, true);

                }

                else
                {
                    bIs_Th = true;

                    Hashtable ht = new Hashtable();
                    ht.Add("MA_NH_TB", frm.txtMa_Nh_Tb.Text);
                    ht.Add("IS_TH", bIs_Th);
                    ht.Add("NAM", frm.txtNam.Text);
                    ht.Add("MA_BP", frm.txtMa_Bp.Text);
                    ht.Add("MA_DVCS", Element.sysMa_DvCs);

                    DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintKHVTPT", ht, CommandType.StoredProcedure);
                    dtHeader = ds.Tables[0];
                    dtDetail = ds.Tables[1];

                    strReportFile = "rptPlan_VTPT";

                    if (!dtKHVTPKTDT.Columns.Contains("REPORT_FILE"))
                        dtKHVTPKTDT.Columns.Add("REPORT_FILE", typeof(string));

                    if (!dtKHVTPKTDT.Columns.Contains("NGAY_CT"))
                        dtKHVTPKTDT.Columns.Add("NGAY_CT", typeof(DateTime));

                    drKHVTPKTDT["REPORT_FILE"] = strReportFile;
                    drKHVTPKTDT["NGAY_CT"] = Element.sysNgay_Ct2;
                    RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                    return frmPrint.Load(drKHVTPKTDT, dtDetail, bPreview, true);
                }
            }
            return false;
        }
        void chkDuyet_Click(object sender, EventArgs e)
        {
            
            if (bKHVT)
            {
                if (strLoaiDuyet == "TP")
                {
                    
                    foreach (DataRow dr in dtKHVTPKTDT.Rows)
                    {
                        if ((bool)dr["Duyet_KTDT"])
                            Common.MsgOk(dr["Noi_Dung"] + " " + dr["Ten_Vt"] + " đã được duyệt bởi PKTDT. Bạn không gỡ duyệt!!!");
                        else
                        {
                            dr["So_Luong_Tp"] = dr["So_Luong"];
                            dr["Duyet_Tp"] = chkDuyet.Checked;
                        }
                    }
                    
                }
                else if (strLoaiDuyet == "KTDT")
                {
                    foreach (DataRow dr in dtKHVTPKTDT.Rows)
                    {
                        if ((bool)dr["Duyet_KHVT"])
                            Common.MsgOk(dr["Noi_Dung"] + " " + dr["Ten_Vt"] + " đã được duyệt bởi PKHVT. Bạn không gỡ duyệt!!!");
                        else
                        {
                            dr["So_Luong_KTDT"] = dr["So_Luong_Tp"];
                            dr["Duyet_KTDT"] = chkDuyet.Checked;
                        }
                    }
                }
                else if (strLoaiDuyet == "KHVT")
                {
                    
                    foreach (DataRow dr in dtKHVTPKTDT.Rows)
                    {
                        if ((bool)dr["Duyet_GiamDoc"])
                            Common.MsgOk(dr["Noi_Dung"] +" "+ dr["Ten_Vt"] + " đã được duyệt bởi giám đốc. Bạn không gỡ duyệt!!!");
                        else
                        {
                            dr["So_Luong_KHVT"] = dr["So_Luong_KTDT"];
                            dr["Duyet_KHVT"] = chkDuyet.Checked;
                        }
                    }
                }
                else if (strLoaiDuyet == "GD")
                {
                    foreach (DataRow dr in dtKHVTPKTDT.Rows)
                    {
                        dr["So_Luong_GD"] = dr["So_Luong_KHVT"];
                        dr["Duyet_GiamDoc"] = chkDuyet.Checked;
                    }
                }
            }
            else
            {
                if (strLoaiDuyet == "TP")
                {
                    foreach (DataRow dr in dtKHVTPKTDT.Rows)
                    {


                        if ((bool)dr["Duyet_KTDT"] && chkDuyet.Checked == true)
                        {

                        }
                        else if ((bool)dr["Duyet_KTDT"] && chkDuyet.Checked == false)
                        {
                            Common.MsgOk(dr["Noi_Dung_Th"] + " đã được duyệt bởi PKTDT. Bạn không gỡ duyệt!!!");
                            return;
                        }
                        else
                            dr["Duyet_Tp"] = chkDuyet.Checked;
                    }
                }
                else if (strLoaiDuyet == "KTDT")
                {
                    if (chkDuyet.Checked == true)
                    {
                        foreach (DataRow dr in dtKHVTPKTDT.Select("Duyet_TP = 1 AND Duyet_KTDT = 0 AND Duyet_GiamDoc = 0"))
                        {
                            if ((bool)dr["Duyet_GiamDoc"])
                                Common.MsgOk(dr["Noi_Dung_Th"] + " đã được duyệt bởi giám đốc. Bạn không gỡ duyệt!!!");
                            else
                                dr["Duyet_KTDT"] = chkDuyet.Checked;

                        }
                    }
                    else
                    {
                        foreach (DataRow dr in dtKHVTPKTDT.Select("Duyet_TP = 1 AND Duyet_KTDT = 1 AND Duyet_GiamDoc = 0"))
                        {
                           dr["Duyet_KTDT"] = chkDuyet.Checked;

                        }
                    }
                }
                else if (strLoaiDuyet == "GD")
                {
                    foreach (DataRow dr in dtKHVTPKTDT.Rows)
                    {
                        dr["Duyet_GiamDoc"] = chkDuyet.Checked;
                    }
                }
            }
        }
        void dgvKHVTPKTDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (bdsKHVTPKTDT.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsKHVTPKTDT.Current).Row;
            string strColumn_Name = dgvKHVTPKTDT.Columns[e.ColumnIndex].DataPropertyName;

            if (strColumn_Name == "EDIT")
            {
                DataRow drKHVTPKTDT = ((DataRowView)bdsKHVTPKTDT.Current).Row;
                DataRow drEdit = DataTool.SQLGetDataRowByID("R06KHBTTB", "Ident00", drKHVTPKTDT["Ident00"].ToString());
                frmKHBTTB_Edit frm = new frmKHBTTB_Edit();
                frm.Load(enuEdit.Edit, drEdit, strLoaiDuyet);
                if (frm.isAccept)
                {
                    //if (drKHVTPKTDT.Table.Columns.Contains("Noi_Dung_KTDT"))
                    //    drKHBTTB["Noi_Dung_KTDT"] = frm.txtNoi_Dung_KTDT.Text;

                    FillData();
                    //Common.CopyDataRow(drKHVTPKTDT, ((DataRowView)bdsKHVTPKTDT.Current).Row);
                    //dtKHVTPKTDT.AcceptChanges();

                }
            }
        }

        void txtPt_Bt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtPt_Bt.Text.Trim();
            bool bRequire = false;

            string strFilter = "Type='PT_BT'";
            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "PT_BT");
            DataRow drLookup = Lookup.ShowLookup("PT_BT", txtPt_Bt.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtPt_Bt.Text = string.Empty;
               
            }
            else
            {
                txtPt_Bt.Text = (string)drLookup["Type_ID"];
                


            }
        }

        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb.Text.Trim();
            bool bRequire = false;
            DataRow drLookup;

            if (strFilterTb != string.Empty)
                drLookup = Lookup.ShowLookup("MA_TB", txtMa_Tb.Text, bRequire, "Ma_Tb LIKE '"+ strFilterTb +"%'", "");
            else
                drLookup = Lookup.ShowLookup("MA_TB", txtMa_Tb.Text, bRequire, "", "");

            if (drLookup == null)
            {
                txtMa_Tb.Text = string.Empty;
                lbtTen_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Tb.Text = (string)drLookup["Ma_Tb"];
                lbtTen_Tb.Text = (string)drLookup["Ten_Tb"];

            }
        }

        void txtMa_Nh_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = false;


            DataRow drLookup = Lookup.ShowLookup("MA_NH_TB", txtMa_Nh_Tb.Text, bRequire, "Nh_Cuoi = 1", "");

            if (drLookup == null)
            {
                txtMa_Nh_Tb.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_Tb.Text = (string)drLookup["Ma_Nh_Tb"];
                lbtTen_Nh_Tb.Text = (string)drLookup["Ten_Nh_Tb"];
                strFilterTb = (string)drLookup["Ma_Nh_Tb"];
            }
        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }
		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

             

        
	}
}
