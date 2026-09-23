using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.Payable
{
	public partial class frmInheritDnTt : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();

		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;
        public string strMa_Ct = string.Empty;
        string strMa_Hd = string.Empty;
		#endregion

		#region Contructor

        public frmInheritDnTt()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.btSearch.Click += new EventHandler(btSearch_Click);

			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            this.KeyDown += new KeyEventHandler(frmInheritDnTt_KeyDown);
		}

       

		#endregion

		#region Method

		public void Load(string strMa_Ct)
		{
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

            this.strMa_Ct = strMa_Ct;
            txtMa_Ct.Text = strMa_Ct;
            //drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", drHeader["Ma_Ct"].ToString());

			Build();
			FillData();
			BindingLanguage();

			this.ShowDialog();
		}
        public void Load(string strMa_Ct, string strMa_Hd)
        {
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

            this.strMa_Ct = strMa_Ct;
            txtMa_Ct.Text = strMa_Ct;
            this.strMa_Hd = strMa_Hd;

            Build();
            FillData();
            BindingLanguage();

            this.ShowDialog();
        }
		void Build()
		{
			//DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", frmVoucher_Edit.strMa_Ct);
			if (strMa_Ct == "DNXNL")
				dgvInheritVoucher.strZone = "INHERITDNXNL";
            else if (strMa_Ct == "DNX")
				dgvInheritVoucher.strZone = "INHERITDNX";
			else
				dgvInheritVoucher.strZone = "INHERITDNTU";

			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

			if (dgvInheritVoucher.Columns.Contains("CHON"))
				dgvInheritVoucher.Columns["CHON"].ReadOnly = false;
		}

		void FillData()
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

			if (drDmCt == null)
				return;

			string strKey = "(1=1) ";
            string strQuery = string.Empty;
			string strTablePh = drDmCt["Table_Ph"].ToString();
            string strTableCt = drDmCt["Table_Ct"].ToString();

            if (strTablePh == string.Empty)
				return;

            DataTable dtTestData = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM " + strTablePh + " WHERE 0 = 1");

			if (txtMa_Ct.Text != string.Empty)
				strKey += " AND Ma_Ct = '" + txtMa_Ct.Text + "'";

			if (txtSo_Ct.Text != string.Empty)
				strKey += " AND So_Ct = '" + txtSo_Ct.Text + "'";

			if (!dteNgay_Ct1.IsNull)
				strKey += " AND Ngay_Ct >= '" + dteNgay_Ct1.Text + "'";

            if (!dteNgay_Ct2.IsNull)
                strKey += " AND Ngay_Ct <= '" + dteNgay_Ct2.Text + "'";

            if (txtMa_Dt.Text != string.Empty)
            {
                if (txtMa_Ct.Text == "BT")
                    strKey += " AND (Ma_Dt = '" + txtMa_Dt.Text + "' OR Ma_Dt_Co = '" + txtMa_Dt.Text + "')";
                else
                    strKey += " AND Ma_Dt = '" + txtMa_Dt.Text + "'";
            }
			if (txtMa_Vt.Text != "" && dtTestData.Columns.Contains("Ma_Vt"))
				strKey += " AND Ma_Vt = '" + txtMa_Vt.Text + "'";

			if(strMa_Hd != string.Empty)
                strKey += " AND T1.Ma_Hd = '" + strMa_Hd + "'";

            if (strMa_Ct == "DNX")
            {
                strKey = "0 = 0";
                if (txtSo_Ct.Text != string.Empty)
                    strKey += " AND So_Ct = '" + txtSo_Ct.Text + "'";

                if (!dteNgay_Ct1.IsNull)
                    strKey += " AND Ngay_Ct >= '" + dteNgay_Ct1.Text + "'";

                if (!dteNgay_Ct2.IsNull)
                    strKey += " AND Ngay_Ct <= '" + dteNgay_Ct2.Text + "'";

                if (txtMa_Dt.Text != string.Empty)
                    strKey += " AND Ma_Dt = '" + txtMa_Dt.Text + "'";
            }
//            //if (chkInheritedExcept.Checked)
//            //    strKey += " AND Stt NOT IN (SELECT Stt_Org FROM " + drDmCt_Current["Table_Ct"].ToString() + " WHERE Stt_Org <> '')";

            
            Hashtable htPara = new Hashtable();
            htPara.Add("TABLE_CT", strTableCt);
            htPara.Add("MA_CT", txtMa_Ct.Text);
            htPara.Add("KEY", strKey);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtInheritVoucher = SQLExec.ExecuteReturnDt("Sp_Inherit_DnTt",htPara, CommandType.StoredProcedure);

			bdsInheritVoucher.DataSource = dtInheritVoucher;
			dgvInheritVoucher.DataSource = bdsInheritVoucher;

			bdsSearch = bdsInheritVoucher;
			bdsLookup = bdsInheritVoucher;
		}

		bool FormCheckValid()
		{
			if (dtInheritVoucher == null || dtInheritVoucher.Select("Chon = true").Length == 0)
			{
				Common.MsgCancel("Không có dữ liệu kế thừa!");
				return false;
			}

			return true;
		}

		#endregion

		#region Event

		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
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

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				this.Is_Accept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}
        void frmInheritDnTt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {

                for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
                {
                    dtInheritVoucher.Rows[i]["CHON"] = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.U)
            {

                for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
                {
                    dtInheritVoucher.Rows[i]["CHON"] = false;
                }
            }
        }
		void btSearch_Click(object sender, EventArgs e)
		{
			bool bRequire = true;
			string strKey = "Ma_Ct LIKE '" + txtMa_Ct.Text + "%'";

			if (chkInheritedExcept.Checked)
				strKey += " AND Stt NOT IN (SELECT Stt_Org FROM " + drDmCt_Current["Table_Ct"].ToString() + " WHERE Stt_Org <> '')";

			//frmQuickLookup frmLookup = new frmQuickLookup("R80PH", "PH");
			DataRow drLookup = Lookup.ShowLookup("Stt", "", bRequire, strKey);

			if (drLookup != null)
			{
				txtMa_Ct.Text = (string)drLookup["Ma_Ct"];
				dteNgay_Ct1.Text = Library.DateToStr((DateTime)drLookup["Ngay_Ct"]);
				txtSo_Ct.Text = (string)drLookup["So_Ct"];
				txtMa_Dt.Text = (string)drLookup["Ma_Dt"];

				DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;

                FillData();

			}
		}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                this.FillData();
            else if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                    foreach (DataRow dr in dtInheritVoucher.Rows)
                        dr["Chon"] = true;
                else if (e.KeyCode == Keys.U)
                    foreach (DataRow dr in dtInheritVoucher.Rows)
                    {
                        dr["Chon"] = false;
                        if (dtInheritVoucher.Columns.Contains("Stt_Order"))
                            dr["Stt_Order"] = 0;
                    }
            }
            else
                base.OnKeyDown(e);
        }
		#endregion
	}
}
