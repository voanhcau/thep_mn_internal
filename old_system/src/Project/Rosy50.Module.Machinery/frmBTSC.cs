using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using System.Collections;

namespace RosyModule.Machinery
{
    public partial class frmBTSC : RosySystem.Customize.frmView
    {
        DataTable dtBTSC;
        BindingSource bdsBTSC = new BindingSource();
        rsDataGridView dgvBTSC = new rsDataGridView();
        DataRow drCurrent;

        public frmBTSC()
        {
            InitializeComponent();
            dgvBTSC.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvKHBTSC_CellMouseClick);
            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.KeyDown += new KeyEventHandler(frmBTSC_KeyDown);
            //btPreview.Click += new EventHandler(btPreview_Click);
            //btPreviewYCSC.Click += new EventHandler(btPreviewYCSC_Click);
        }

        void btPreviewYCSC_Click(object sender, EventArgs e)
        {
            this.PrintYCSC(true);
        }

        void btPreview_Click(object sender, EventArgs e)
        {
            this.print(true);
        }

        #region event

        void dgvKHBTSC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumnName = dgvBTSC.Columns[e.ColumnIndex].Name;
            drCurrent = ((DataRowView)bdsBTSC.Current).Row;

            if (strColumnName.ToUpper() == "DUYET" || strColumnName.ToUpper() == "HOAN_THANH")
            {
                frmDuyet frm = new frmDuyet();
                frm.Load(drCurrent);
            }
        }

        void btNew_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.New);
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.Edit);
        }

        void btDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        #endregion

        public override void Load()
        {
            Build();
            FillData();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }

        private void Build()
        {
            dgvBTSC.Dock = DockStyle.Fill;
            dgvBTSC.strZone = "BTSC";
            dgvBTSC.BuildGridView();

            this.rsSplitContainer1.Panel1.Controls.Add(dgvBTSC);
        }

        private void FillData()
        {
            dtBTSC = SQLExec.ExecuteReturnDt("sp_GetBTSC", CommandType.StoredProcedure);
            
            bdsBTSC.DataSource = dtBTSC;
            dgvBTSC.DataSource = bdsBTSC;

            bdsSearch = bdsBTSC;
            ExportControl = dgvBTSC;
        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsBTSC.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dong hien tai
            if (bdsBTSC.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBTSC.Current).Row, ref drCurrent);
            else
                drCurrent = dtBTSC.NewRow();

            frmBTSC_Edit frmEdit = new frmBTSC_Edit();
            if (enuNew_Edit == enuEdit.New && drCurrent.Table.Columns.Contains("Trong_Ke_Hoach"))
                drCurrent["Trong_Ke_Hoach"] = true;
            frmEdit.Load(enuNew_Edit, drCurrent, false);

            if (frmEdit.isAccept)
            {
                if (drCurrent.Table.Columns.Contains("Ten_Dt_Cbnv_Bt"))
                    drCurrent["Ten_Dt_Cbnv_Bt"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", drCurrent["Ma_Dt_Cbnv_Bt"].ToString());

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsBTSC.Position >= 0)
                        dtBTSC.ImportRow(drCurrent);
                    else
                        dtBTSC.Rows.Add(drCurrent);

                    bdsBTSC.Position = bdsBTSC.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsBTSC.Current).Row);

                dtBTSC.AcceptChanges();
            }
            else
                dtBTSC.RejectChanges();
        }


        public override void Delete()
        {
            if (bdsBTSC.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsBTSC.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06BTSC", drCurrent))
            {
                bdsBTSC.RemoveAt(bdsBTSC.Position);
                dtBTSC.AcceptChanges();
            }
        }

        private bool print(bool bPreview)
        {
            if (bdsBTSC.Position < 0)
                return false;

            drCurrent = ((DataRowView)bdsBTSC.Current).Row;

            if (!dtBTSC.Columns.Contains("NGAY_CT"))
                dtBTSC.Columns.Add("NGAY_CT", typeof(DateTime));

            if (!dtBTSC.Columns.Contains("REPORT_FILE"))
                dtBTSC.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtBTSC.Columns.Contains("STT"))
                dtBTSC.Columns.Add("STT", typeof(int));

            drCurrent["REPORT_FILE"] = "rptTHEBAOTRI";
            drCurrent["NGAY_CT"] = DateTime.Now;

            Hashtable ht = new Hashtable();
            ht.Add("IDENT00", drCurrent["Ident00"]);

            DataTable dtPrint = SQLExec.ExecuteReturnDt("sp_GetTheBaoTri", ht, CommandType.StoredProcedure);
            
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drCurrent, dtPrint, bPreview, true);
        }

        private bool PrintYCSC(bool bPreview)
        {
            if (bdsBTSC.Position < 0)
                return false;

            drCurrent = ((DataRowView)bdsBTSC.Current).Row;

            Hashtable ht = new Hashtable();
            ht.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));

            DataTable dtYCSC_Print = SQLExec.ExecuteReturnDt("sp_PrintYCSC", ht, CommandType.StoredProcedure);

            if (!dtYCSC_Print.Columns.Contains("REPORT_FILE"))
                dtYCSC_Print.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtYCSC_Print.Columns.Contains("NGAY_CT"))
                dtYCSC_Print.Columns.Add("NGAY_CT", typeof(DateTime));

            dtYCSC_Print.Rows[0]["REPORT_FILE"] = "rpt_YCSC";
            dtYCSC_Print.Rows[0]["NGAY_CT"] = RosySystem.Element.Element.sysNgay_Ct2;

            DataRow drPrint = dtYCSC_Print.Rows[0];

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drPrint, dtYCSC_Print, bPreview, true);
        }

        private void Design()
        {
            string strReportFile = "rptTHEBAOTRI";

            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }

        void frmBTSC_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            this.print(true);
                            break;

                        case Keys.Shift:
                            this.Design();
                            break;
                    }
                    break;
            }
        }

    }
}
