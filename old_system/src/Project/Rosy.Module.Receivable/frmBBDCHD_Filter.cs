using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Data;
using System.Collections;
using RosySystem.Public;

namespace RosyModule.Receivable
{
    public partial class frmBBDCHD_Filter : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		
		public DataTable dtBBDCHD;

	
		BindingSource bdsBBDCHD = new BindingSource();
        
		private DataRow drCurrent;

		#endregion

		#region Contructor

        public frmBBDCHD_Filter()
		{
			InitializeComponent();

            btRefresh.Click += new EventHandler(btRefresh_Click);
            btAccept.Click += new EventHandler(btAccept_Click);

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
		}

       

       

        

		public override void Load()
		{
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			this.Build();
            this.FillData();

			this.BindingLanguage();

            this.ShowDialog();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvBBDCHD.strZone = "BBDC_FILTER";
			dgvBBDCHD.BuildGridView();

            txtMa_Dt.bUseAutoDropDown = true;

            ExportControl = dgvBBDCHD;
            dgvBBDCHD.ReadOnly = false;

            foreach (DataGridViewColumn dgvc in dgvBBDCHD.Columns)
                dgvc.ReadOnly = true;

            if (dgvBBDCHD.Columns.Contains("CHON"))
                dgvBBDCHD.Columns["CHON"].ReadOnly = false;
		}

		private void FillData()
		{			
			
            Hashtable htPara = new Hashtable();
            htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
            htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
            htPara.Add("MA_DT", txtMa_Dt.Text);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);
            dtBBDCHD = SQLExec.ExecuteReturnDt("sp_BBDCHD_Filter", htPara, CommandType.StoredProcedure);

            bdsBBDCHD.DataSource = dtBBDCHD;
            dgvBBDCHD.DataSource = bdsBBDCHD;

            ExportControl = dgvBBDCHD;
            this.bdsSearch = bdsBBDCHD;
		}

		#endregion

		#region Update

		#endregion

        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
            }
        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
