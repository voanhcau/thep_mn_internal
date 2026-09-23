using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;

namespace RosyModule.HRM
{
    public partial class frmInThucDon : RosySystem.Customize.frmEdit
	{
      

		public frmInThucDon()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);
            
		}

		public void Load()
		{
            DateTime dteNgay_Ct2 = DateTime.Now;
            DateTime dteNgay_Ct1 = dteNgay_Ct2.AddDays((-7) + 1);

            this.dteNgay_Ct1.Text = Library.DateToStr(dteNgay_Ct1);
            this.dteNgay_Ct2.Text = Library.DateToStr(dteNgay_Ct2);

			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}

        private bool Print()
        {
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintThucDon", ht, CommandType.StoredProcedure);

           DataTable dtHeader = dsPrintVoucher.Tables[0];
           DataTable dtDetail = dsPrintVoucher.Tables[1];

           dtHeader.Columns.Add("REPORT_FILE", typeof(string));
           dtHeader.Columns.Add("TITLE", typeof(string));
           dtHeader.Columns.Add("IS_VND", typeof(bool));
           dtHeader.Columns.Add("DOC_TIEN", typeof(string));
           dtHeader.Columns.Add("DOC_TIENE", typeof(string));
           dtHeader.Columns.Add("SUBTITLE2", typeof(string));

           DataRow drHeader = dtHeader.Rows[0];

           drHeader["Is_Vnd"] = true;
           drHeader["Title"] = string.Empty;
           drHeader["Report_File"] = "rptThucDon";
           RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
           return frmPrint.Load(drHeader, dtDetail, true, true);
        }

		private void btAccept_Click(object sender, EventArgs e)
		{
            Print();
            isAccept = true;
            this.Close();
            
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
      
	}
}
