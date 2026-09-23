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
using RosyList;
using RosySystem;
using RosySystem.Library;
using RosySystem.Element;
using System.Collections;
using System.Data.SqlClient;

namespace RosyModule.Machinery
{
	public partial class frmKHBTDK : RosySystem.Customize.frmView
	{
		DataTable dtKHBTDK;
        DataTable dtSo_Ct;
		BindingSource bdsKHBTDK = new BindingSource();
		DataRow drCurrent;
        string strReportFile = "rptCT_BTKH";
        bool bUpdateKQ = false;
		public frmKHBTDK()
		{
			InitializeComponent();
		
			this.btExit.Click += new EventHandler(btExit_Click);
			this.btCreate.Click += new EventHandler(btFilter_Click);
            this.btPrint.Click += new EventHandler(btPrint_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
            this.btUpdate_KQ.Click += new EventHandler(btUpdate_KQ_Click);
            btDelete.Click += new EventHandler(btDelete_Click);

            this.btDuyetGD.Click += new EventHandler(btDuyetGD_Click);
            this.btDuyetKTDT.Click += new EventHandler(btDuyetKTDT_Click);

            dgvKHBTDK.KeyDown += new KeyEventHandler(dgvKHVTPKTDT_KeyDown);
            cboDot_BT.SelectedValueChanged += new EventHandler(cboSo_Ct_SelectedValueChanged);
            numNam.TextChanged += new EventHandler(numNam_LostFocus);
		}

        void numNam_LostFocus(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            dtSo_Ct = SQLExec.ExecuteReturnDt("SELECT So_Ct FROM R06KHBTDK WHERE Nam = " + numNam.Value + " GROUP BY So_Ct ORDER BY So_Ct");
            DataRow drSo_Ct = dtSo_Ct.NewRow();
            drSo_Ct["So_Ct"] = "";
            dtSo_Ct.Rows.Add(drSo_Ct);
            dtSo_Ct.AcceptChanges();

            cboDot_BT.DataSource = dtSo_Ct;
            cboDot_BT.ValueMember = "So_Ct";
            cboDot_BT.DisplayMember = "So_Ct";
            cboDot_BT.SelectedValue = "";
        }

		new public void Load()
		{
            numNam.Value = Element.sysWorkingYear;


            LoadCombo();
			this.Build();
            FillData();
			this.BindingLanguage();
            
            
            //PHÂN QUYỀN
            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
            {
                btCreate.Enabled = false;
                btDelete.Enabled = false;
                btUpdate_KQ.Enabled = false;
                btSave.Enabled = false;
                btDuyetGD.Enabled = false;
                btDuyetKTDT.Enabled = false;
                
            }

			this.Show();
		}

		private void Build()
		{
			dgvKHBTDK.strZone = "KHBTDK";
			dgvKHBTDK.BuildGridView();

            dgvKHBTDK.ReadOnly = false;
            foreach (DataGridViewColumn dgvc in dgvKHBTDK.Columns)
                dgvc.ReadOnly = true;
           
            if(dgvKHBTDK.Columns.Contains("MA_BP_TH"))
                dgvKHBTDK.Columns["MA_BP_TH"].ReadOnly = false;
            if (dgvKHBTDK.Columns.Contains("MA_BP_PH"))
                dgvKHBTDK.Columns["MA_BP_PH"].ReadOnly = false;
           
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("SO_CT", cboDot_BT.Text);
            ht.Add("NAM", numNam.Value);
			dtKHBTDK = SQLExec.ExecuteReturnDt("sp_GetKHBTDK", ht, CommandType.StoredProcedure);
			bdsKHBTDK.DataSource = dtKHBTDK;
			dgvKHBTDK.DataSource = bdsKHBTDK;

            bdsSearch = bdsKHBTDK;
            ExportControl = dgvKHBTDK;
		}

		void btFilter_Click(object sender, EventArgs e)
		{
            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
            {
                frmCreateBTTBDK frm = new frmCreateBTTBDK();
                frm.Load();
                if (frm.isAccept)
                {
                    cboDot_BT.Text = frm.strSo_Ct;
                    this.FillData();
                }
            }
            
		}

        private bool printDetail_Tb(bool bPreview)
        {
            if (bdsKHBTDK.Position < 0)
                return false;
            
            frmIn_KHTBDK frm = new frmIn_KHTBDK();
            frm.Load();

            if (frm.rdbKHBTTB.Checked == true)
                strReportFile = "rptCT_BTKH";
            else
                strReportFile = "rptCT_KQBTKH";

            DataRow drKHVTPKTDT = ((DataRowView)bdsKHBTDK.Current).Row;
          
            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            Hashtable ht = new Hashtable();
            ht.Add("SO_CT", cboDot_BT.Text);
            ht.Add("NAM", numNam.Value);
            ht.Add("USER_PRINT", Element.sysUser_Id);

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintKHBTDK", ht, CommandType.StoredProcedure);
            dtHeader = ds.Tables[0];
            dtDetail = ds.Tables[1];

            if (!dtKHBTDK.Columns.Contains("NGAY_CT"))
                dtKHBTDK.Columns.Add("NGAY_CT", typeof(DateTime));

            if (!dtKHBTDK.Columns.Contains("REPORT_FILE"))
                dtKHBTDK.Columns.Add("REPORT_FILE", typeof(string));

            drKHVTPKTDT["REPORT_FILE"] = strReportFile;
            drKHVTPKTDT["NGAY_CT"] = Element.sysNgay_Ct1;
           
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drKHVTPKTDT, dtDetail, bPreview, true);
                        
        }
        private void Design()
        {
            frmIn_KHTBDK frm = new frmIn_KHTBDK();
            frm.Load();

            if(frm.rdbKHBTTB.Checked ==  true)
                strReportFile = "rptCT_BTKH";
            else
                strReportFile = "rptCT_KQBTKH";
            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
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
            if (e.Control && e.KeyCode == Keys.A)
            {

                for (int i = 0; i < dtKHBTDK.Rows.Count; i++)
                {
                    dtKHBTDK.Rows[i]["IS_HT"] = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.U)
            {

                for (int i = 0; i < dtKHBTDK.Rows.Count; i++)
                {
                    dtKHBTDK.Rows[i]["IS_HT"] = false;
                }
            }
        }
        void cboSo_Ct_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboDot_BT.Text != "" && this.cboDot_BT.Text != "System.Data.DataRowView")
            {
                DataRow dr = DataTool.SQLGetDataRowByID("R06DSBAOTRI", "Ma_DotBT", cboDot_BT.Text);
                lbtTen_DotBT.Text = Convert.ToDateTime(dr["Ngay_Ct1"]).ToShortDateString() + " đến " + Convert.ToDateTime(dr["Ngay_Ct2"]).ToShortDateString();
                //chkIs_Kt.Checked = Convert.ToBoolean(dr["Is_Kt"]);
                string strUpdate = "SELECT DATEDIFF(DAY,@Ngay_Ct1, @Ngay_Ct2)";
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT1", dr["Ngay_Ct1"]);
                ht.Add("NGAY_CT2", dr["Ngay_Ct2"]);
                int dbNgay = Convert.ToInt16(SQLExec.ExecuteReturnValue(strUpdate, ht, CommandType.Text));
                int i = dbNgay + 1;
                int j = 0;
                while (j <= i)
                {
                    j++;
                    if (dgvKHBTDK.Columns.Contains("Ngay_0" + j + ""))
                        dgvKHBTDK.Columns["Ngay_0" + j + ""].Visible = true;
                    if (dgvKHBTDK.Columns.Contains("Ngay_" + j + ""))
                        dgvKHBTDK.Columns["Ngay_" + j + ""].Visible = true;
                }
                while (i <= 25)
                {
                    i++;
                    if (dgvKHBTDK.Columns.Contains("Ngay_0" + i + ""))
                        dgvKHBTDK.Columns["Ngay_0" + i + ""].Visible = false;
                    if (dgvKHBTDK.Columns.Contains("Ngay_" + i + ""))
                        dgvKHBTDK.Columns["Ngay_" + i + ""].Visible = false;


                }
            }
            FillData();
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            this.printDetail_Tb(true);
        }
        void btSave_Click(object sender, EventArgs e)
        {
            bool bDuyet_KTDT = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select Duyet_KTDT FROM R06KHBTDK WHERE So_Ct = '" + cboDot_BT.Text + "' GROUP BY Duyet_KTDT"));
            if (bDuyet_KTDT && !bUpdateKQ)
                Common.MsgOk("Phiếu đã được PKTDT duyệt");
            else
            {
                if (Save("", false))
                    Common.MsgOk("Bạn đã cập nhật xong");
            }
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            string strSo_Ct = string.Empty;
            
            strSo_Ct = SQLExec.ExecuteReturnValue("SELECT So_Ct FROM R06KHBTDK WHERE Duyet_GiamDoc = 0 AND So_Ct = '" + cboDot_BT.Text + "'").ToString();
            
            if (strSo_Ct != string.Empty)
            {
                string strSQL = "DELETE FROM R06KHBTDK WHERE So_Ct = '" + cboDot_BT.Text + "'";
                SQLExec.Execute(strSQL);
                FillData();
            }
            else
                Common.MsgOk("Kế hoạch đã được PKTDT duyệt. Không cho phép xóa!");
        }
        void btUpdate_KQ_Click(object sender, EventArgs e)
        {
            bool bDuyet_GD = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select Duyet_GiamDoc FROM R06KHBTDK WHERE So_Ct = '" + cboDot_BT.Text + "' GROUP BY Duyet_GiamDoc"));
            if (bDuyet_GD)
            {
                string strUpdate = "UPDATE R06KHBTDK SET Is_Ht = 1 FROM R06KHBTDK T1 JOIN (SELECT Stt, Stt0 FROM R06CT_BTTB WHERE Ma_Ct = 'BTTT' AND Tinh_Trang <> '') T2 ON T1.Stt_Org = T2.Stt AND T1.Stt0_Org = T2.Stt0 WHERE T1.So_Ct = '" + cboDot_BT.Text +"'";
                SQLExec.Execute(strUpdate);

                if (dgvKHBTDK.Columns.Contains("GHI_CHU_KQ"))
                    dgvKHBTDK.Columns["GHI_CHU_KQ"].ReadOnly = false;
                bUpdateKQ = true;
                FillData();
            }
            else
                Common.MsgOk("Phiếu chưa được giám đốc duyệt");

        }
        bool Save(string strLoaiDuyet, bool bDuyet)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@Loai_Duyet", strLoaiDuyet);
            sqlCom.Parameters.AddWithValue("@Duyet", bDuyet);
            sqlCom.Parameters.AddWithValue("@Log_Duyet", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_KHBTDK";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_KHBTDK";
            paraCt.Value = Voucher.GetTVPValue("R06KHBTDK", "TVP_KHBTDK", this.dtKHBTDK);
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
        void btDuyetKTDT_Click(object sender, EventArgs e)
        {
            bool bDuyet_Gd = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select Duyet_GiamDoc FROM R06KHBTDK WHERE So_Ct = '" + cboDot_BT.Text + "' GROUP BY Duyet_GiamDoc"));
            if (!Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else if (bDuyet_Gd)
                Common.MsgOk("Tổng giám đốc đã duyệt. Bạn không được gỡ!!!");   
            else
            {
                bool bDuyet_KTDT = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select Duyet_KTDT FROM R06KHBTDK WHERE So_Ct = '" + cboDot_BT.Text + "' GROUP BY Duyet_KTDT"));
                if (bDuyet_KTDT)
                {
                    if (Common.MsgYes_No("Bạn có thực sự muốn gỡ duyệt không?", "Y"))
                    {
                        if (Save("KTDT", false))
                            Common.MsgOk("Bạn đã gỡ duyệt xong");
                    }
                }
                else
                    if (Save("KTDT", true))
                        Common.MsgOk("Bạn đã duyệt xong");
                FillData();
            }
        }

        void btDuyetGD_Click(object sender, EventArgs e)
        {
            bool bDuyet_KTDT = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select Duyet_KTDT FROM R06KHBTDK WHERE So_Ct = '" + cboDot_BT.Text + "' GROUP BY Duyet_KTDT"));
            if (!Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else if (!bDuyet_KTDT)
                Common.MsgOk("PKTDT chưa duyệt, bạn vui lòng chờ!!!");
            else
            {
                bool bDuyet_GD = Convert.ToBoolean(SQLExec.ExecuteReturnValue("Select Duyet_GiamDoc FROM R06KHBTDK WHERE So_Ct = '" + cboDot_BT.Text + "' GROUP BY Duyet_GiamDoc"));
                if (bDuyet_GD)
                {
                    if (Common.MsgYes_No("Bạn có thực sự muốn gỡ duyệt không?", "Y"))
                    {
                        if (Save("GD", false))
                            Common.MsgOk("Bạn đã gỡ duyệt xong");
                    }
                }
                else
                    if (Save("GD", true))
                        Common.MsgOk("Bạn đã duyệt xong");
                FillData();
            }
        }

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        
	}
}
