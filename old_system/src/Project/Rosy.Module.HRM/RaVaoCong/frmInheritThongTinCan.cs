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

namespace RosyModule.HRM
{
	public partial class frmInheritThongTinCan : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();

		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;
        public string strMa_Ct = string.Empty;
        
		#endregion

		#region Contructor

        public frmInheritThongTinCan()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
            //this.txtSo_Xe.LostFocus += new EventHandler(txtSo_Xe_LostFocus);
            this.KeyDown += new KeyEventHandler(frmInheritDnTt_KeyDown);
		}

       

		#endregion

		#region Method

		public void Load(string strMa_Ct)
		{
            //dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            //dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            DateTime dteNgay_Ct1_ = Element.sysNgay_Ct2;// Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetDate(YEAR(Getdate()), MONTH(GETDATE()), 1)"));
            DateTime dteNgay_Ct2_ = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT DATEADD(DAY, -1, DATEADD(MONTH,1,dbo.fn_GetDate(YEAR(Getdate()), MONTH(GETDATE()), 1)))"));
            dteNgay_Ct1.Text = Library.DateToStr(dteNgay_Ct1_);
            dteNgay_Ct2.Text = Library.DateToStr(dteNgay_Ct2_);
            this.strMa_Ct = strMa_Ct;
          

			Build();
			FillData();
			BindingLanguage();

			this.ShowDialog();
		}
        public void Load()
        {

            
            DateTime dteNgay_Ct1_ = Element.sysNgay_Ct2;// Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetDate(YEAR(Getdate()), MONTH(GETDATE()), 1)"));
            DateTime dteNgay_Ct2_ = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT DATEADD(DAY, -1, DATEADD(MONTH,1,dbo.fn_GetDate(YEAR(Getdate()), MONTH(GETDATE()), 1)))"));
            dteNgay_Ct1.Text = Library.DateToStr(dteNgay_Ct1_);
            dteNgay_Ct2.Text = Library.DateToStr(dteNgay_Ct2_);
        

            Build();
            FillData();
            BindingLanguage();
            
            this.ShowDialog();
        }
		void Build()
		{
		     dgvInheritVoucher.strZone = "INHERITTHONGTINCAN";

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
            //string strKey = "(1=1) ";
            string strQuery = string.Empty;
			
            //if (txtSo_Xe.Text != string.Empty)
            //    strKey += " AND So_Xe LIKE '%" + txtSo_Xe.Text + "%'";

            //if (!dteNgay_Ct1.IsNull)
            //    strKey += " AND Ngay_Ct1 >= '" + dteNgay_Ct1.Text + "'";

            //if (!dteNgay_Ct2.IsNull)
            //    strKey += " AND Ngay_Ct2 <= '" + dteNgay_Ct2.Text + "'";

            Hashtable htPara = new Hashtable();
            htPara.Add("SO_XE", txtSo_Xe.Text);
            htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
            htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
            htPara.Add("MA_VT_SP", strMa_Ct);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtInheritVoucher = SQLExec.ExecuteReturnDt("Sp_InheritThongTinCan", htPara, CommandType.StoredProcedure);

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

        //private void tabPage1_Click(object sender, EventArgs e)
        //{

        //}
	}
}
