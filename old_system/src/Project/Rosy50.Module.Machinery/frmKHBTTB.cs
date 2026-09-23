using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using System.Data.SqlClient;

namespace RosyModule.Machinery
{
    public partial class frmKHBTTB : RosySystem.Customize.frmView
    {
        object objActive = null;

        public DataSet dsMachinery = new DataSet("dsMachinery");
        string strReportFile = string.Empty;
        object objFileContent = null;

        DataTable dtDmNhVtTb = new DataTable();
        BindingSource bdsDmNhVtTb = new BindingSource();
        rsTreeList tlDmNhVtTb = new rsTreeList();
        DataRow drDmNhVtTb;

        DataSet dsDmCtVtTb = new DataSet();
        DataTable dtDmCtVtTb = new DataTable();
        BindingSource bdsDmCtVtTb = new BindingSource();
        rsTreeList tlDmCtVtTb = new rsTreeList();
        DataRow drDmCtVtTb;

        rsDataGridView dgvKHBTTB = new rsDataGridView();
        DataTable dtKHBTTB = new DataTable();
        BindingSource bdsKHBTTB = new BindingSource();
        DataRow drKHBTTB;

        rsDataGridView dgvKHVTPT = new rsDataGridView();
        DataTable dtKHVTPT = new DataTable();
        BindingSource bdsKHVTPT = new BindingSource();
        DataRow drKHVTPT;

        private DataRow drCurrent;
        string strLoaiDuyet = string.Empty;
        
        public frmKHBTTB()
        {
            InitializeComponent();
            bdsDmNhVtTb.PositionChanged += new EventHandler(bdsDmNhVtTb_PositionChanged);
            bdsDmCtVtTb.PositionChanged += new EventHandler(bdsDmVtTb_PositionChanged);
            bdsKHBTTB.PositionChanged += new EventHandler(bdsKHBTTB_PositionChanged);

            dgvKHBTTB.KeyDown += new KeyEventHandler(dgvKHBTTB_KeyDown);
            dgvKHVTPT.KeyDown += new KeyEventHandler(dgvKHVTPT_KeyDown);
            dgvKHBTTB.CellContentClick += new DataGridViewCellEventHandler(dgvKHBTTB_CellContentClick);
            dgvKHBTTB.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvKHBTTB_CellFormatting);

            dgvKHBTTB.Enter += new EventHandler(dgvKHBTTB_Enter);
            dgvKHVTPT.Enter += new EventHandler(dgvKHVTPT_Enter);

            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btPreview_KHBT.Click += new EventHandler(btPreview_KHBT_Click);
            btImport.Click += new EventHandler(btImport_Click);
            btCopy.Click += new EventHandler(btCopy_Click);
            btCopy1.Click += new EventHandler(btCopy1_Click);
            btDuyetTp.Click += new EventHandler(btDuyetTp_Click);
            btDuyetKTDT.Click += new EventHandler(btDuyetKTDT_Click);
            btDuyetKHVT.Click += new EventHandler(btDuyetKHVT_Click);
            btDuyetGD.Click += new EventHandler(btDuyetGD_Click);

            btKHBTTP.Click += new EventHandler(btKHBTTP_Click);
            btKHBTPKTDT.Click += new EventHandler(btKHBTPKTDT_Click);
            btKHBTGD.Click += new EventHandler(btKHBTGD_Click);
        }

        

           

        public override void Load()
        {
            
            this.Build();
            this.FillData();
            this.Show();
          
            BindingData();
            tlDmNhVtTb.Focus();
        }
        private void Build()
        {
            
            //Nhóm thiết bị
            tlDmNhVtTb.KeyFieldName = "MA_NH_TB";
            tlDmNhVtTb.ParentFieldName = "MA_NH_TB_PARENT";
            tlDmNhVtTb.Dock = DockStyle.Fill;
            tlDmNhVtTb.strZone = "DMNHTB";
            tlDmNhVtTb.BuildTreeList(this.isLookup);
            this.tabDmNhVtTb.Controls.Add(tlDmNhVtTb);

            tlDmCtVtTb.KeyFieldName = "MA_TB";
            tlDmCtVtTb.ParentFieldName = "MA_NH_TB";
            tlDmCtVtTb.Dock = DockStyle.Fill;
            tlDmCtVtTb.strZone = "DMCTVTTB";
            tlDmCtVtTb.BuildTreeList(this.isLookup);
            this.pageDmCtVtTb.Controls.Add(tlDmCtVtTb);

            dgvKHBTTB.Dock = DockStyle.Fill;
            dgvKHBTTB.strZone = "KHBTTB";
            dgvKHBTTB.BuildGridView();
            this.splitContainer2.Panel1.Controls.Add(dgvKHBTTB);

            dgvKHVTPT.Dock = DockStyle.Fill;
            dgvKHVTPT.strZone = "KHVTPT";
            dgvKHVTPT.BuildGridView();
            this.splitContainer2.Panel2.Controls.Add(dgvKHVTPT);

            dgvKHBTTB.ReadOnly = true;
            dgvKHVTPT.ReadOnly = true;

            if (dgvKHBTTB.Columns.Contains("Noi_Dung"))
            {
                dgvKHBTTB.Columns["Noi_Dung"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvKHBTTB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvKHVTPT.Columns.Contains("Mo_Ta_Kt"))
            {
                dgvKHVTPT.Columns["Mo_Ta_Kt"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvKHVTPT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvKHVTPT.Columns.Contains("So_Luong"))
            {
                dgvKHVTPT.Columns["So_Luong"].HeaderText = "Số lượng cần mua";
                
            }
        }

        private void FillData()
        {
            dsMachinery.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("NAM", Element.sysWorkingYear);
            dsMachinery = SQLExec.ExecuteReturnDs("sp_GetMachineryKHBTTB", ht, CommandType.StoredProcedure);

            //Nhóm vật tư thiết bị
            dtDmNhVtTb = dsMachinery.Tables[0];
            bdsDmNhVtTb.DataSource = dtDmNhVtTb;
            tlDmNhVtTb.DataSource = bdsDmNhVtTb;

            tlDmNhVtTb.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNhVtTb.strZone + "'");

            dtDmCtVtTb = dsMachinery.Tables[1];
            bdsDmCtVtTb.DataSource = dtDmCtVtTb;
            tlDmCtVtTb.DataSource = bdsDmCtVtTb;

            dtKHBTTB = dsMachinery.Tables[2];
            bdsKHBTTB.DataSource = dtKHBTTB;
            dgvKHBTTB.DataSource = bdsKHBTTB;

            dtKHVTPT = dsMachinery.Tables[3];
            bdsKHVTPT.DataSource = dtKHVTPT;
            dgvKHVTPT.DataSource = bdsKHVTPT;

            bdsSearch = bdsDmNhVtTb;
            ExportControl = tlDmNhVtTb;
        }
        
        private void BindingData()
        {

        }
        
        #region Print
        private bool printDetail_VtPt(bool bPreview)
        {
            if (bdsKHVTPT.Position < 0)
                return false;

            //if (bdsDmVtTb.Position < 0)
            //    return false;

            drKHVTPT = ((DataRowView)bdsKHVTPT.Current).Row;


            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            //Load form chọn in
            string strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
            string strMa_Bp = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt_CbNv + "'");
            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drKHVTPT, false, strMa_Bp);

            if (frm.isAccept)
            {
                bool bIs_Th = false;
                
                if (frm.btPlan_KHVTPT_02.Checked == true)
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

                if (!dtKHVTPT.Columns.Contains("REPORT_FILE"))
                    dtKHVTPT.Columns.Add("REPORT_FILE", typeof(string));

                if (!dtKHVTPT.Columns.Contains("NGAY_CT"))
                    dtKHVTPT.Columns.Add("NGAY_CT", typeof(DateTime));

                drKHVTPT["REPORT_FILE"] = strReportFile;
                drKHVTPT["NGAY_CT"] = Element.sysNgay_Ct2;
                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                return frmPrint.Load(drKHVTPT, dtDetail, bPreview, true);

            }
            else
                return false;
        }

        private bool printDetail_KHBTTB(bool bPreview)
        {
            if (bdsDmNhVtTb.Position < 0)
                return false;

            //if (bdsDmVtTb.Position < 0)
            //    return false;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
          

            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            //Load form chọn in
            string strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
            string strMa_Bp = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt_CbNv + "'");
            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drDmNhVtTb, false, strMa_Bp);
            string strLoai_BTTB = "";
            bool bIs_Th = false;
            if (frm.isAccept)
            {
                if (frm.btPlan_KHVTPT_02.Checked == false)
                {

                    if (frm.rdbPlan_BTTB_NB.Checked == true )
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
                    ht.Add("MA_DVCS", Element.sysMa_DvCs);

                    DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLichBTTB", ht, CommandType.StoredProcedure);
                    dtHeader = ds.Tables[0];
                    dtDetail = ds.Tables[1];

                    if (strLoai_BTTB == "BN")
                        strReportFile = "rptPlan_BTTB_BN";
                    else
                        strReportFile = "rptPlan_BTTB_NB";

                    if (!dtDmNhVtTb.Columns.Contains("REPORT_FILE"))
                        dtDmNhVtTb.Columns.Add("REPORT_FILE", typeof(string));

                    if (!dtDmNhVtTb.Columns.Contains("NGAY_CT"))
                        dtDmNhVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

                    drDmNhVtTb["REPORT_FILE"] = strReportFile;
                    drDmNhVtTb["NGAY_CT"] = Element.sysNgay_Ct2;
                    RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                    return frmPrint.Load(drDmNhVtTb, dtDetail, bPreview, true);

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

                    if (!dtDmNhVtTb.Columns.Contains("REPORT_FILE"))
                        dtDmNhVtTb.Columns.Add("REPORT_FILE", typeof(string));

                    if (!dtDmNhVtTb.Columns.Contains("NGAY_CT"))
                        dtDmNhVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

                    drDmNhVtTb["REPORT_FILE"] = strReportFile;
                    drDmNhVtTb["NGAY_CT"] = Element.sysNgay_Ct2;
                    RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                    return frmPrint.Load(drDmNhVtTb, dtDetail, bPreview, true);
                }
            }
            return false;
        }

        private void Design()
        {
            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drDmNhVtTb, true,"PCNTT");

            //string strLoai_BTTB = "ALL";
            if (frm.isAccept)
            {
                if (frm.rdbPlan_BTTB_NB.Checked == true)
                    strReportFile = "rptPlan_BTTB_NB";
                else if (frm.rdbPlan_BTTB_BN.Checked == true)
                    strReportFile = "rptPlan_BTTB_BN";
                else if (frm.rdbLyLich2.Checked == true)
                    strReportFile = "rptLyLichTb2";
                else if (frm.btPlan_KHVTPT_02.Checked == true)
                    strReportFile = "rptPlan_VTPT";
               
            }
            else
                return;

            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }

        
        #endregion
        void btKHBTTP_Click(object sender, EventArgs e)
        {
            if (!Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access) && !Common.CheckPermission("IS_PTP", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else
            {
                frmDuyetKHBT frm = new frmDuyetKHBT();
                frm.Load("TP", false);
            }
        }
        void btKHBTGD_Click(object sender, EventArgs e)
        {
            if (!Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else
            {
                frmDuyetKHBT frm = new frmDuyetKHBT();
                frm.Load("GD", false);
            }
        }

        void btKHBTPKTDT_Click(object sender, EventArgs e)
        {
            if (!Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else
            {
                frmDuyetKHBT frm = new frmDuyetKHBT();
                frm.Load("KTDT", false);
            }
        }
        void btDuyetTp_Click(object sender, EventArgs e)
        {
            if (!Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access) || Common.CheckPermission("IS_PTP", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else
            {
                frmDuyetKHBT frm = new frmDuyetKHBT();
                frm.Load("TP", true);
            }
        }
        void btDuyetGD_Click(object sender, EventArgs e)
        {
            if (!Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else
            {
                frmDuyetKHBT frm = new frmDuyetKHBT();
                frm.Load("GD", true);
            }
        }

        void btDuyetKHVT_Click(object sender, EventArgs e)
        {
            if (!Common.CheckPermission("IS_TP_KHVT", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else
            {
                frmDuyetKHBT frm = new frmDuyetKHBT();
                frm.Load("KHVT", true);
            }
        }

        void btDuyetKTDT_Click(object sender, EventArgs e)
        {
            if (!Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access))
                Common.MsgOk("Bạn không có quyền duyệt!!!");
            else
            {
                frmDuyetKHBT frm = new frmDuyetKHBT();
                frm.Load("KTDT", true);
            }
        }
        void ImportVTPT()
        {
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("KHVTBTTB");

            drKHBTTB = ((DataRowView)bdsKHBTTB.Current).Row;

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                string strSQL = string.Empty;
                foreach (DataRow dr in frmImport.dtImport.Rows)
                {
                    if (DataTool.SQLCheckExist("R06KHVTPT", new string[] { "Nam", "Stt_Nd", "Ma_Tb", "Ma_Vt" }, new object[] { Element.sysWorkingYear, drKHBTTB["Stt_Nd"], drKHBTTB["Ma_Tb"].ToString(), dr["Ma_Vt"].ToString() }))
                    {
                        string strMsg = "Mã thiết bị = {" + dr["Ma_Tb"].ToString() + "}, Ma_Vt = {" + dr["Ma_Vt"].ToString() + "}";
                        strMsg += Element.sysLanguage == enuLanguageType.English ? " already exist, do you want to add more?" : " đã tồn tại, Bạn không tạo 2 dòng có mã thiết bị VTPT cùng loại!!!";
                        Common.MsgOk(strMsg);
                        continue;


                    }
                    else
                    {
                        strSQL = "INSERT INTO R06KHVTPT ( Nam, Ma_Bp, Ma_Nh_Tb, Ma_Tb, Stt_Nd, Ma_Vt, So_Luong_Ld, So_Luong_TonKho, So_Luong_Dn, So_Luong, Create_Log, Thang_Sd)"+
                            "SELECT " + drKHBTTB["Nam"] + ", '" + dr["Ma_Bp"] + "', '" + drKHBTTB["Ma_Nh_Tb"].ToString() + "', '" + drKHBTTB["Ma_Tb"].ToString() + "', "+ drKHBTTB["Stt_Nd"].ToString() +", '" + dr["Ma_Vt"].ToString() + "'," +
                                "" + dr["So_Luong_LD"].ToString() + ", 0, " + dr["So_Luong_Dn"].ToString() + ", " + dr["So_Luong"].ToString() + ", '" + Common.GetCurrent_Log() + "', '" + dr["Thang_Sd"].ToString() + "'";
                        
                        SQLExec.Execute(strSQL);

                        FillData();
                        //DataRow drEditCtNew = dtKHVTPT.NewRow();
                        //Common.CopyDataRow(dr, drEditCtNew);
                        //Common.SetDefaultDataRow(ref drEditCtNew);
                        //DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", dr["Ma_Vt"].ToString());
                        //drEditCtNew["Ma_Vt"] = dr["Ma_Vt"];
                        //drEditCtNew["So_Luong_Ld"] = dr["So_Luong_Ld"];
                        //drEditCtNew["So_Luong_Dn"] = dr["So_Luong_Dn"];
                        //drEditCtNew["So_Luong"] = dr["So_Luong"];
                        //drEditCtNew["Thang_Sd"] = dr["Thang_Sd"];
                        
                        //drEditCtNew["Ten_Vt"] = drDmVt["Ten_Vt"];
                        //dtKHVTPT.Rows.Add(drEditCtNew);
                        //drEditCtNew.AcceptChanges();
                    }
                }
            }
            
        }
        void btImport_Click(object sender, EventArgs e)
        {
            ImportVTPT();
        }
        void btCopy_Click(object sender, EventArgs e)
        {
            frmCopyCVBT frm = new frmCopyCVBT();
            frm.Load();
        }
        void btCopy1_Click(object sender, EventArgs e)
        {
            frmCopyCVBT_Nam frm = new frmCopyCVBT_Nam();
            frm.Load();
        }
        void btPreview_KHBT_Click(object sender, EventArgs e)
        {
            this.printDetail_KHBTTB(true);
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvKHBTTB)
                KHBTTB_Delete();
            else if (this.objActive == dgvKHVTPT)
                KHVTPT_Delete();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvKHBTTB)
                KHBTTB_Edit(enuEdit.Edit);
            else if (this.objActive == dgvKHVTPT)
                KHVTPT_Edit(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvKHBTTB)
                KHBTTB_Edit(enuEdit.New);
            else if (this.objActive == dgvKHVTPT)
                KHVTPT_Edit(enuEdit.New);
        }
        void dgvKHVTPT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvKHVTPT;
        }

        void dgvKHBTTB_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvKHBTTB;
        }
        void bdsKHBTTB_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsKHBTTB.Position < 0)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;
            drKHBTTB = ((DataRowView)bdsKHBTTB.Current).Row;
            bdsKHVTPT.Filter = "Ma_Tb = '" + (string)drKHBTTB["Ma_Tb"] + "' AND Stt_Nd = '" + drKHBTTB["Stt_Nd"] + "' AND Nam = "+ drKHBTTB["Nam"] +"";
        }
        void bdsDmVtTb_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            bdsKHBTTB.Filter = "Ma_Tb LIKE '" + (string)drDmCtVtTb["Ma_Tb"] + "%'";
            bdsKHVTPT.Filter = "Ma_Tb LIKE '" + (string)drDmCtVtTb["Ma_Tb"] + "%'";
        }
        void bdsDmNhVtTb_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            if (drDmNhVtTb["Ma_Nh_Tb"].ToString().Length == 1)
            {
                bdsDmCtVtTb.Filter = "Ma_Tb_Cha LIKE '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
                bdsKHBTTB.Filter = "Ma_Nh_Tb LIKE '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "%'";
                bdsKHVTPT.Filter = "Ma_Nh_Tb LIKE '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "%'";
            }
            else
            {
                bdsDmCtVtTb.Filter = "Ma_Nh_Tb_Parent = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
                bdsKHBTTB.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
                bdsKHVTPT.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            }
        }
        void KHBTTB_Edit(enuEdit enuNew_Edit)
        {
            if (bdsKHBTTB.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;
            //Copy dòng hiện tại
            if (bdsKHBTTB.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsKHBTTB.Current).Row, ref drKHBTTB);
            else
                drKHBTTB = dtKHBTTB.NewRow();

            if (enuNew_Edit == enuEdit.New)
            {
                drKHBTTB["Duyet_TP"] = false;
                drKHBTTB["Duyet_KTDT"] = false;
                drKHBTTB["Duyet_GiamDoc"] = false;
                

                drKHBTTB["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
                drKHBTTB["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            }
            frmKHBTTB_Edit frmEdit = new frmKHBTTB_Edit();
            frmEdit.Load(enuNew_Edit, drKHBTTB, "USER");

            //Khi người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (drKHBTTB.Table.Columns.Contains("Noi_Dung_Px"))
                    drKHBTTB["Noi_Dung_Px"] = frmEdit.txtNoi_Dung.Text;
                

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsKHBTTB.Position >= 0)
                        dtKHBTTB.ImportRow(drKHBTTB);
                    else
                        dtKHBTTB.Rows.Add(drKHBTTB);

                    bdsKHBTTB.Position = bdsKHBTTB.Find("Ident00", drKHBTTB["Ident00"]);
                }
                else
                    Common.CopyDataRow(drKHBTTB, ((DataRowView)bdsKHBTTB.Current).Row);



                dtKHBTTB.AcceptChanges();
            }
            else
                dtKHBTTB.RejectChanges();
        }
        void KHVTPT_Edit(enuEdit enuNew_Edit)
        {
            if (bdsKHVTPT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

           
            drKHBTTB = ((DataRowView)bdsKHBTTB.Current).Row;

            //Copy dòng hiện tại
            if (bdsKHVTPT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsKHVTPT.Current).Row, ref drKHVTPT);
            else
                drKHVTPT = dtKHVTPT.NewRow();

            if (enuNew_Edit == enuEdit.New)
            {
                drKHVTPT["Duyet_TP"] = false;
                drKHVTPT["Duyet_KTDT"] = false;
                drKHVTPT["Duyet_KHVT"] = false;
                drKHVTPT["Duyet_GiamDoc"] = false;

                drKHVTPT["Ma_Nh_Tb"] = drKHBTTB["Ma_Nh_Tb"];
                drKHVTPT["Ma_Tb"] = drKHBTTB["Ma_Tb"];
                drKHVTPT["Nam"] = drKHBTTB["Nam"];
                drKHVTPT["Stt_Nd"] = drKHBTTB["Stt_Nd"];
                drKHVTPT["Ma_Bp"] = drKHBTTB["Ma_Bp"];
            }
            frmKHVTPT_Edit frmEdit = new frmKHVTPT_Edit();
            frmEdit.Load(enuNew_Edit, drKHVTPT, false);

            //Khi người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drKHVTPT["Ma_Vt"].ToString());
                drKHVTPT["Ten_Vt"] = drDmVt["Ten_Vt_Chuan"];
                drKHVTPT["Dvt"] = drDmVt["Dvt"];
                drKHVTPT["Mo_Ta_Kt"] = drDmVt["Ten_Vt"];

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsKHVTPT.Position >= 0)
                        dtKHVTPT.ImportRow(drKHVTPT);
                    else
                        dtKHVTPT.Rows.Add(drKHVTPT);

                    bdsKHVTPT.Position = bdsKHVTPT.Find("Ident00", drKHVTPT["Ident00"]);
                }
                else
                    Common.CopyDataRow(drKHVTPT, ((DataRowView)bdsKHVTPT.Current).Row);

                dtKHVTPT.AcceptChanges();
            }
            else
                dtKHVTPT.RejectChanges();
        }

        void KHBTTB_Delete()
        {
            if (bdsKHBTTB.Position < 0)
                return;

            drKHBTTB = ((DataRowView)bdsKHBTTB.Current).Row;
            if ((bool)drKHBTTB["Duyet_Tp"])
            {
                Common.MsgOk("Không được xóa do trưởng phòng đã duyệt!!!");
                return;
            }
            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("R06KHBTTB", drKHBTTB))
                {
                    bdsKHBTTB.RemoveAt(bdsKHBTTB.Position);
                    dtKHBTTB.AcceptChanges();
                }
            }
        }
        void KHVTPT_Delete()
        {
            if (bdsKHVTPT.Position < 0)
                return;

            drKHBTTB = ((DataRowView)bdsKHBTTB.Current).Row;
            drKHVTPT = ((DataRowView)bdsKHVTPT.Current).Row;
            if ((bool)drKHVTPT["Duyet_Tp"])
            {
                Common.MsgOk("Không được xóa do trưởng phòng đã duyệt!!!");
                return;
            }
            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("R06KHVTPT", drKHVTPT))
                {
                    bdsKHVTPT.RemoveAt(bdsKHVTPT.Position);
                    dtKHVTPT.AcceptChanges();
                }
            }
        }
        void dgvKHBTTB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (bdsKHBTTB.Position < 0)
                return;

            //if (Convert.ToDouble(dgvKHBTTB.Rows[e.RowIndex].Cells["CHANGE"].Value) != 0)
            //{
            //    e.CellStyle.BackColor = Color.Lime;
            //    e.CellStyle.Font = new Font(dgvKHBTTB.Font, FontStyle.Bold);
            //}
        }

        void dgvKHBTTB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			if (bdsKHBTTB.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsKHBTTB.Current).Row;
			string strColumn_Name = dgvKHBTTB.Columns[e.ColumnIndex].DataPropertyName;
			
			

        }
        void dgvKHVTPT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    KHVTPT_Edit(enuEdit.New);
                    break;
                case Keys.F3:
                    KHVTPT_Edit(enuEdit.Edit);
                    break;
                case Keys.F8:
                    KHVTPT_Delete();
                    break;
            }
        }
        void dgvKHBTTB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    KHBTTB_Edit(enuEdit.New);
                    break;
                case Keys.F3:
                    KHBTTB_Edit(enuEdit.Edit);
                    break;
                case Keys.F8:
                    KHBTTB_Delete();
                    break;
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

       

       
        
    }
}
