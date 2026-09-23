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

namespace RosyModule.Machinery
{
	public partial class frmQuery_KHVT : RosySystem.Customize.frmView
	{
		DataTable dtKHVTPKTDT;
		BindingSource bdsKHVTPKTDT = new BindingSource();
		DataRow drCurrent;

		public frmQuery_KHVT()
		{
			InitializeComponent();
		
			this.btExit.Click += new EventHandler(btExit_Click);
			this.btFilter.Click += new EventHandler(btFilter_Click);
            this.btPrint.Click += new EventHandler(btPrint_Click);

            dgvKHVTPKTDT.KeyDown += new KeyEventHandler(dgvKHVTPKTDT_KeyDown);
		}

        

        

		new public void Load()
		{
			this.Build();
            FillData();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
			dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());
			dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());
            numNam.Value = Element.sysWorkingYear;

			dgvKHVTPKTDT.strZone = "KHVT_PKTDT";
			dgvKHVTPKTDT.BuildGridView();
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("NAM", numNam.Value);
			dtKHVTPKTDT = SQLExec.ExecuteReturnDt("sp_KHVTPTPKTDT", ht, CommandType.StoredProcedure);
			bdsKHVTPKTDT.DataSource = dtKHVTPKTDT;
			dgvKHVTPKTDT.DataSource = bdsKHVTPKTDT;
		}

		void btFilter_Click(object sender, EventArgs e)
		{
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("NAM", numNam.Value);
            ht.Add("CREATE_LOG", Common.GetCurrent_Log());
            SQLExec.Execute("sp_UpdateKHVTPT", ht, CommandType.StoredProcedure);
			
            this.FillData();
		}

        private bool printDetail_Tb(bool bPreview)
        {
            if (bdsKHVTPKTDT.Position < 0)
                return false;

            DataRow drKHVTPKTDT = ((DataRowView)bdsKHVTPKTDT.Current).Row;
          
            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            Hashtable ht = new Hashtable();
            ht.Add("NAM", numNam.Value);
            

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintKHVTPKTDT", ht, CommandType.StoredProcedure);
            dtHeader = ds.Tables[0];
            dtDetail = ds.Tables[1];

            string strReportFile = "rptCT_KHVTPKTDT";

            if (!dtKHVTPKTDT.Columns.Contains("REPORT_FILE"))
                dtKHVTPKTDT.Columns.Add("REPORT_FILE", typeof(string));

            drKHVTPKTDT["REPORT_FILE"] = strReportFile;
           
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drKHVTPKTDT, dtDetail, bPreview, true);
                        
        }
        private void Design()
        {
            string strReportFile = "rptCT_KHVTPKTDT";

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
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            this.printDetail_Tb(true);
        }
		

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        
	}
}
