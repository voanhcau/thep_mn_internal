using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Library;
using RosySystem.Element;
using RosySystem.Common;
using System.Collections;
using RosySystem.Data;
using RosySystem.Public;
using System.IO;
using RosySystem;
using Rosy.Module;
using System.Reflection;
using System.Globalization;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Core;

using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using RosySystem.Control;

using RosySystem.Customize;
using System.Threading;
using System.Net.Sockets;




namespace RosyModule.Receivable
{
	public partial class frmInBBXN : RosySystem.Customize.frmView
	{
        DataSet dsViewPh;

		DataTable dtViewPh;
		BindingSource bdsViewPh = new BindingSource();
        rsDataGridView dgvViewPh = new rsDataGridView();

        string strStt = "";
        string strStt_List = "";

        DataRow drCurrent;
       
        DataTable dtHeader;
        DataTable dtDetail;
        
        string strReport_File = string.Empty;
      
        
     
       


        public frmInBBXN()
		{
			InitializeComponent();

			this.btFilter.Click += new EventHandler(btFilter_Click);
			
            this.KeyDown += new KeyEventHandler(frmHDDT_KeyDown);
            txtMa_Ct.Validating += TxtMa_Ct_Validating;
            btIn.Click += BtIn_Click;
            btThoat.Click += BtThoat_Click;
           
            dteNgay_Ct1.LostFocus += new EventHandler(dteNgay_Ct1_LostFocus);
            dteNgay_Ct2.LostFocus += new EventHandler(dteNgay_Ct2_LostFocus);
            dteNgay_Ct1.TextChanged += new EventHandler(dteNgay_Ct1_TextChanged);
		}

        

        void dteNgay_Ct1_TextChanged(object sender, EventArgs e)
        {
            
        }

           
        #region Buld, Filldata
        new public void Load()
		{
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            dteNgay_Ct1.Text = dteNgay_Ct1.Text = Element.sysNgay_Ct2.Subtract(new TimeSpan(2, 0, 0, 0)).ToString();
           
            //Add dữ liệu vào commbo
         
			this.Build();
			this.BindingLanguage();
			this.Change_Language();

            dgvViewPh.Visible = true;
           
			

			this.Show();
		}

		private void Change_Language()
		{
            //this.txtMa_Dt.bUseAutoDropDown = true;
		}

		private void Build()
		{
            dgvViewPh.Dock = DockStyle.Fill;
            dgvViewPh.strZone = "PXDT";
            dgvViewPh.BuildGridView();
            this.rsSplitContainer1.Panel2.Controls.Add(dgvViewPh);
    } 

		private void FillData()
		{
            Hashtable ht = new Hashtable();

            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_CT", txtMa_Ct.Text);
            ht.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
            ht.Add("SO_DH_KH", txtSo_Dh_Kh.Text);

            dsViewPh = SQLExec.ExecuteReturnDs("sp_GetPXDCXalan", ht,  CommandType.StoredProcedure);
            
            dtViewPh = dsViewPh.Tables[0];
			bdsViewPh.DataSource = dtViewPh;
			dgvViewPh.DataSource = bdsViewPh;
			bdsViewPh.Position = 0;
            DataTable dtCt = dsViewPh.Tables[1];
            strStt = Convert.ToString(dtCt.Rows[0]["Stt"]);
            strStt_List = Convert.ToString(dtCt.Rows[0]["Stt_List"]);


        }
        #endregion
        #region Event
        
       
        void dteNgay_Ct2_LostFocus(object sender, EventArgs e)
        {
            //FillData();
        }

        void dteNgay_Ct1_LostFocus(object sender, EventArgs e)
        {
           // FillData();
        }
        void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}
        private void TxtMa_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Ct.Text.Trim();
            bool bRequire = true;
            string strKey = string.Empty;

            //frmQuickLookup frmLookup = new frmQuickLookup("R00DMCT", "DMCT");
            DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, strKey);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
                txtMa_Ct.Text = string.Empty;
            else
            {
                txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
            }
        }
        private void BtIn_Click(object sender, EventArgs e)
        {
            if (strStt_List == string.Empty || txtSo_Xa_Lan_Tau.Text == "")
                Common.MsgOk("Dữ liệu in BB Giao nhận chưa có. Vui lòng nhập số xà lan!!!");
            else
                Print(strStt, strStt_List, txtMa_Ct.Text, "VND", "rptCT_PXDC_BBXNDD");
        }
        private bool Print(string strStt, string strStt_List, string strMa_Ct, string strMa_Tte, string strReport_File)
        {
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
            bool bIs_Vnd = true;

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("STT_LIST", strStt_List);
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("IS_VND", bIs_Vnd);
            ht.Add("HD_TU_IN", true);
            ht.Add("LOGIN_USER", Element.sysUser_Id);
            ht.Add("LANGUAGE_TYPE", "V");

            DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintVoucher_BBGNXalan", ht, CommandType.StoredProcedure);

            dtHeader = dsPrintVoucher.Tables[0];
            dtDetail = dsPrintVoucher.Tables[1];

            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("TITLE", typeof(string));
            dtHeader.Columns.Add("IS_VND", typeof(bool));
            dtHeader.Columns.Add("DOC_TIEN", typeof(string));
            dtHeader.Columns.Add("DOC_TIENE", typeof(string));
            dtHeader.Columns.Add("SUBTITLE2", typeof(string));

            DataRow drHeader = dtHeader.Rows[0];

            drHeader["Is_Vnd"] = bIs_Vnd;
            drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();
            drHeader["Report_File"] = strReport_File;

            if (Element.sysLanguage == enuLanguageType.Vietnamese)
            {

                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoney(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
                

            }
            else if (Element.sysLanguage == enuLanguageType.English)
                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
            else
                dtHeader.Rows[0]["Doc_Tien"] = Common.ReadNumberC(Convert.ToDouble(drHeader["TTien_Nt"]));

            if (Element.sysLanguage == enuLanguageType.Vietnamese && Common.Inlist(strMa_Ct, "HDXK"))
            {
                dtHeader.Rows[0]["Doc_TienE"] = Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) + ".";

            }

            return frmPrint.Load(dtHeader.Rows[0], dtDetail, true, true);
            //return true;
        }
        private void BtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool FormcheckValid()
        {
            return true;
        }
        
        
        #endregion

        void frmHDDT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    this.FillData();
                    break;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
                
            //}
        }
        protected override void OnShown(EventArgs e)
        {
           base.OnShown(e);
        }

        private void frmInBBXN_Load(object sender, EventArgs e)
        {

        }
    }
}
