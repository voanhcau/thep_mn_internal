using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Machinery
{
    public partial class frmYCSC : RosySystem.Customize.frmView
    {
        #region variable

        DataTable dtYCSC;
        BindingSource bdsYCSC = new BindingSource();
        rsDataGridView dgvYCSC = new rsDataGridView();
        DataRow drCurrent;

        #endregion

        #region contructor

        public frmYCSC()
        {
            InitializeComponent();
            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btPreview.Click += new EventHandler(btPreview_Click);

            this.KeyDown += new KeyEventHandler(frmYCSC_KeyDown);
            dgvYCSC.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvYCSC_CellMouseClick);
        }

        public override void Load()
        {
            this.Build();
            this.Filldata();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }

        private void Build()
        {
            dgvYCSC.Dock = DockStyle.Fill;
            dgvYCSC.strZone = "YCSC";
            dgvYCSC.BuildGridView(this.isLookup);

            if (dgvYCSC.Columns.Contains("Ten_Vt_Tb"))
                dgvYCSC.Columns["Ten_Vt_Tb"].Frozen = true;

            this.splitContainer1.Panel1.Controls.Add(dgvYCSC);
        }

        private void Filldata()
        {
            dtYCSC = SQLExec.ExecuteReturnDt("sp_GetYCSC", CommandType.StoredProcedure);

            bdsYCSC.DataSource = dtYCSC;
            dgvYCSC.DataSource = bdsYCSC;

            bdsSearch = bdsYCSC;
            ExportControl = dgvYCSC;
        }

        #endregion

        #region event

        void frmYCSC_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            this.Design();
                            break;

                        case Keys.Control:
                            this.Print(false);
                            break;
                    }
                    break;
            }
        }

        void btPreview_Click(object sender, EventArgs e)
        {
            this.Print(true);
        }

        void dgvYCSC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string strColumnName = dgvYCSC.Columns[e.ColumnIndex].Name;
            drCurrent = ((DataRowView)bdsYCSC.Current).Row;

            if (strColumnName.ToUpper() == "DUYET_YC")
            {
                frmDuyet_YC frm = new frmDuyet_YC();
                frm.Load(drCurrent);

                if (frm.isAccept)
                {
                    drCurrent["DUYET_YC"] = true;
                }
            }
        }

        void btDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.New);
        }


        #endregion

        #region method

        private bool Print(bool bPreview)
        {
            if (bdsYCSC.Position < 0)
                return false;

            drCurrent = ((DataRowView)bdsYCSC.Current).Row;

            Hashtable ht = new Hashtable();
            ht.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));

            DataTable dtYCSC_Print = SQLExec.ExecuteReturnDt("sp_PrintYCSC", ht, CommandType.StoredProcedure);

            if (!dtYCSC_Print.Columns.Contains("REPORT_FILE"))
                dtYCSC_Print.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtYCSC_Print.Columns.Contains("NGAY_CT"))
                dtYCSC_Print.Columns.Add("NGAY_CT", typeof(DateTime));

            dtYCSC_Print.Rows[0]["REPORT_FILE"] = "rpt_YCSC";
            dtYCSC_Print.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

            DataRow drPrint = dtYCSC_Print.Rows[0];

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drPrint, dtYCSC_Print, bPreview, true);
        }

        private void Design()
        {
            string strReport_File = "rpt_" + this.Tag;
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReport_File);
        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsYCSC.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dòng hiện tại
            if (bdsYCSC.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsYCSC.Current).Row, ref drCurrent);
            else
                drCurrent = dtYCSC.NewRow();

            frmBTSC_Edit frmEdit = new frmBTSC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, true);

            if (frmEdit.isAccept)
            {
                if (drCurrent.Table.Columns.Contains("Ten_Vt_Tb"))
                    drCurrent["Ten_Vt_Tb"] = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", (string)drCurrent["Ma_Vt_Tb"]);

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsYCSC.Position >= 0)
                        dtYCSC.ImportRow(drCurrent);
                    else
                        dtYCSC.Rows.Add(drCurrent);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsYCSC.Current).Row);

                dtYCSC.AcceptChanges();
            }
            else
                dtYCSC.RejectChanges();
        }

        public override void Delete()
        {
            if (bdsYCSC.Position < 0)
                return;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            drCurrent = ((DataRowView)bdsYCSC.Current).Row;

            if (DataTool.SQLDelete("R06BTSC", drCurrent))
            {
                bdsYCSC.RemoveAt(bdsYCSC.Position);
                dtYCSC.AcceptChanges();
            }
        }

        #endregion
    }
}
