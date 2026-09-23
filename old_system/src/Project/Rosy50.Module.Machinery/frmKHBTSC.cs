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
    public partial class frmKHBTSC : RosySystem.Customize.frmView
    {
        #region variable

        DataTable dtKHBTSC;
        BindingSource bdsKHBTSC = new BindingSource();
        rsDataGridView dgvKHBTSC = new rsDataGridView();
        DataRow drCurrent;

        #endregion

        #region contructor

        public frmKHBTSC()
        {
            InitializeComponent();
            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
			btPreview.Click += new EventHandler(btPreview_Click);

			dgvKHBTSC.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvKHBTSC_CellMouseClick);
			KeyDown += new KeyEventHandler(frmKHBTSC_KeyDown);
			
        }

		void frmKHBTSC_KeyDown(object sender, KeyEventArgs e)
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
		private void Design()
		{
			string strReport_File = "rpt_YCBT";
			RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strReport_File);
		}

		void btPreview_Click(object sender, EventArgs e)
		{
			this.Print(true);
		}

		private bool Print(bool bPreview)
		{
			if (bdsKHBTSC.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsKHBTSC.Current).Row;

			frmIn_YCBT frm = new frmIn_YCBT();
			frm.Load(drCurrent);

			if (frm.isAccept == true)
			{
				System.Collections.Hashtable ht = new System.Collections.Hashtable();
				ht.Add("NGAY_CT1", Library.StrToDate(frm.dteNgay_Ct1.Text));
				ht.Add("NGAY_CT2", Library.StrToDate(frm.dteNgay_Ct2.Text));
				ht.Add("LOAI_KE_HOACH", "Bảo dưỡng");
				ht.Add("PRINT", true);

				DataTable dtYCSC_Print = SQLExec.ExecuteReturnDt("sp_GetKHBTSC", ht, CommandType.StoredProcedure);

				if (!dtYCSC_Print.Columns.Contains("REPORT_FILE"))
					dtYCSC_Print.Columns.Add("REPORT_FILE", typeof(string));

				if (!dtYCSC_Print.Columns.Contains("NGAY_CT"))
					dtYCSC_Print.Columns.Add("NGAY_CT", typeof(DateTime));

				dtYCSC_Print.Rows[0]["REPORT_FILE"] = "rpt_YCBT";
				dtYCSC_Print.Rows[0]["NGAY_CT"] = DateTime.Now;

				DataRow drPrint = dtYCSC_Print.Rows[0];

				RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
				return frmPrint.Load(drPrint, dtYCSC_Print, bPreview, true);
			}
			else
				return false;
		}

		void dgvKHBTSC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;

			string strColumnName = dgvKHBTSC.Columns[e.ColumnIndex].Name;
			drCurrent = ((DataRowView)bdsKHBTSC.Current).Row;

			if (strColumnName.ToUpper() == "DUYET_KT")
			{
				frmDuyet_KT frm = new frmDuyet_KT();
				frm.Load(drCurrent, "Bảo dưỡng");

				if (frm.isAccept)
				{
					drCurrent["DUYET_KT"] = true;
				}
			}
		}

        public void Load()
        {
			Load("0");
        }

		public void Load(string strDinh_Ky)
		{
			this.Build();
			this.Filldata(strDinh_Ky);

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

        private void Build()
        {
            dgvKHBTSC.Dock = DockStyle.Fill;
            dgvKHBTSC.strZone = "KHBTSC";
            dgvKHBTSC.BuildGridView(this.isLookup);

            this.splitContainer1.Panel1.Controls.Add(dgvKHBTSC);
        }

        private void Filldata(string strDinh_Ky)
        {
			Hashtable ht = new Hashtable();
			ht.Add("NGAY_CT", DateTime.Now);
			ht.Add("DINH_KY", Convert.ToInt32(strDinh_Ky));
			ht.Add("LOAI_KE_HOACH", "Bảo dưỡng");
			ht.Add("MA_DVCS", Element.sysMa_DvCs);

			dtKHBTSC = SQLExec.ExecuteReturnDt("sp_GetKHBTSC", ht, CommandType.StoredProcedure);

            bdsKHBTSC.DataSource = dtKHBTSC;
            dgvKHBTSC.DataSource = bdsKHBTSC;

            this.bdsSearch = bdsKHBTSC;
            this.ExportControl = dgvKHBTSC;
        }

        #endregion

        #region event

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

        #region Method

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsKHBTSC.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dòng hiện tại
            if (bdsKHBTSC.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsKHBTSC.Current).Row, ref drCurrent);
            else
                drCurrent = dtKHBTSC.NewRow();


            frmKHBTSC_Edit frmKHBTSC_Edit = new frmKHBTSC_Edit();
            frmKHBTSC_Edit.load(enuNew_Edit, drCurrent);

            if (frmKHBTSC_Edit.isAccept)
            {
                if (drCurrent.Table.Columns.Contains("Ten_Vt_Tb"))
                    drCurrent["Ten_Vt_Tb"] = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", drCurrent["Ma_Vt_Tb"].ToString());

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsKHBTSC.Position >= 0)
                        dtKHBTSC.ImportRow(drCurrent);
                    else
                        dtKHBTSC.Rows.Add(drCurrent);

                    bdsKHBTSC.Position = bdsKHBTSC.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsKHBTSC.Current).Row);

                dtKHBTSC.AcceptChanges();
            }
            else
                dtKHBTSC.RejectChanges();

        }

        public override void Delete()
        {
            if (bdsKHBTSC.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsKHBTSC.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06KHBTSC", drCurrent))
            {
                bdsKHBTSC.RemoveAt(bdsKHBTSC.Position);
                dtKHBTSC.AcceptChanges();
            }
        }

        #endregion
    }
}
